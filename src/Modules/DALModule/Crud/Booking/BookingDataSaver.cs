

namespace DataAccessLayer.Crud.Booking
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Transactions;

    using AutoMapper;

    using BusinessModule.Validation.Booking;

    using DataAccessLayer.Crud.Validation;
    using DataAccessLayer.DataObjects;
    using DataAccessLayer.Exception;

    using KarveCommon.Generic;

    using KarveCommonInterfaces;

    using KarveDapper.Extensions;

    using KarveDataServices;
    using KarveDataServices.ViewObjects;

    /// <summary>
    ///  BookingDataSaver. It saves the booking.
    /// </summary>
    class BookingDataSaver: IDataSaver<BookingViewObject>
    {
        /// <summary>
        /// Executor of command towards the data base.
        /// </summary>
        private readonly ISqlExecutor _executor;
        
        /// <summary>
        /// Mapper instance for converting the view objects to data entities.
        /// </summary>
        private IMapper _mapper;
        private ValidationChain<BookingViewObject> _validationChain;

        public BookingDataSaver(ISqlExecutor sqlExecutor, IMapper mapper)
        {
            this._executor = sqlExecutor;
            this._mapper = mapper;
            this._validationChain = new BookingNotNullRule();
            this.LoadValidationRules(sqlExecutor);
        }

        /// <summary>
        /// The load validation rules.
        /// </summary>
        /// <param name="executor">
        /// SqlExecutor. It allows to validate the data for the execution.
        /// </param>
        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1101:PrefixLocalCallsWithThis", Justification = "Reviewed. Suppression is OK here.")]
        private void LoadValidationRules(ISqlExecutor executor)
        {
            var conceptValidation = new BookingConceptRule();
            var correctRule = new BookingDateCorrectRule();
            var fare = new BookingFareRule(executor);
            var driver = new BookingDriverRule(executor);
            var client = new BookingClientRule(executor);
            var groupRule = new BookingGroupCorrectRule(executor);
            var office = new BookingOfficeRule(executor);
            var bookingItemsValidation = new BookingItemsValidationRules();
            _validationChain.SetNext(fare);
            fare.SetNext(conceptValidation);
            conceptValidation.SetNext(driver);
            driver.SetNext(client);
            client.SetNext(correctRule);
            correctRule.SetNext(groupRule);
            groupRule.SetNext(office);
            office.SetNext(bookingItemsValidation);

        }

        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1101:PrefixLocalCallsWithThis", Justification = "Reviewed. Suppression is OK here.")]
        private IEnumerable<LIRESER> RemapItems(IEnumerable<BookingItemsViewObject> items, string group, string numero)
        {
            if (items == null)
            {
                return new List<LIRESER>();
            }
  
            var mappedItems = _mapper.Map<IEnumerable<BookingItemsViewObject>, IEnumerable<LIRESER>>(items.ToList<BookingItemsViewObject>());
            // it is mandatory the group for each lines. And the group shall be the group of the reservation.
            mappedItems.ToList().ForEach(i => i.GRUPO = group);
            mappedItems.ToList().ForEach(i => i.NUMERO = numero);

            return mappedItems;
        }

        /// <summary>
        ///  This verify if the collection has the crud action to be executed.
        /// </summary>
        /// <param name="dtos">Enumerable to be used.</param>
        /// <param name="crudAction">Crud action to be used.</param>
        /// <returns></returns>
        private Task<bool> DoCrudAction(IEnumerable<LIRESER> dtos, Func<IEnumerable<LIRESER>, Task<bool>> crudAction)
        {
            if (!dtos.Any())
            {
                return Task.FromResult(true);
            }
            return crudAction(dtos);
        }

        /// <summary>
        ///  This function updates or insert an asynchronous entity value.
        /// </summary>
        /// <typeparam name="T">Type to be inserted</typeparam>
        /// <param name="connection">Connection to be inserted</param>
        /// <param name="entity">Entity to be inserted.</param>
        /// <returns>A boolean value to be used in this case.</returns>
        private async Task<bool> UpdateOrInsertAsyncEntity<T>(IDbConnection connection, T entity) where T: class
        {
            var returnValue = true;
            if (connection.IsPresent<T>(entity))
            {
                returnValue = await connection.UpdateAsync<T>(entity).ConfigureAwait(false);
            }
            else
            {
                returnValue = await connection.InsertAsync<T>(entity).ConfigureAwait(false) > 0;
            }
            return returnValue;
        }

        /// <summary>
        /// The save asynchronously a booking object.
        /// </summary>
        /// <param name="save">
        /// Object to be s
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        /// <exception cref="DataAccessLayerException"> An exception when the data validation fails
        /// or a database update fails.
        /// </exception>
        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1101:PrefixLocalCallsWithThis", Justification = "Reviewed. Suppression is OK here.")]
        public async Task<bool> SaveAsync(BookingViewObject save)
        {

            var returnValue = false;

            // first of all we check if it is valid. In no case at data layer we shall allow invalid data.
            if (!_validationChain.CheckRequest(save))
            {
                var value = KarveLocale.Properties.Resources.ldatavalidationError + " " + _validationChain.ErrorMessage;
                throw new DataAccessLayerException(value);
            }

            save.LastModification = DateUtils.GetKarveDateTimeNow();
            if (save.Items == null)
            {
                throw new DataAccessLayerException("Cannot save without items");
            }

            if (!save.Items.Any())
            {
                throw new DataAccessLayerException("Cannot save without items");
            }

            var items = save.Items;
            var toUpdateItems = items.Where<BookingItemsViewObject>(x => (x.IsDirty && !x.IsNew && !x.IsDeleted));
            var toInsertItems = items.Where<BookingItemsViewObject>(x => (x.IsNew));
            var toDeleteItems = items.Where<BookingItemsViewObject>(x => (x.IsDeleted));
           
            // the database has the weird thing that the booking group shall be present in lines.
            // we convert the booking items to the database columns.
           
            var bookigItemsTobeUpdated = RemapItems(toUpdateItems, save.GRUPO_RES1, save.NUMERO_RES);
            var toDeleteLires = RemapItems(toDeleteItems, save.GRUPO_RES1, save.NUMERO_RES);
            var bookingItemsViewObjects = toInsertItems.ToList();
            var toInsertLires = RemapItems(bookingItemsViewObjects, save.GRUPO_RES1, save.NUMERO_RES);

            var booking = _mapper.Map<IEnumerable<BookingItemsViewObject>, IEnumerable<LIRESER>>(items);
            // here since we have at lower level multiple tables. We shall split the items to the real stuff.
            var bookedTableValue1 = _mapper.Map<RESERVAS1>(save);
            var bookedTableValue2 = _mapper.Map<RESERVAS2>(save);
            using (var dbConnection = _executor.OpenNewDbConnection())
            {
                using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    try
                    {
                        returnValue = await UpdateOrInsertAsyncEntity<RESERVAS1>(dbConnection,bookedTableValue1);
                        returnValue = returnValue && await UpdateOrInsertAsyncEntity<RESERVAS2>(dbConnection, bookedTableValue2);
                        returnValue = returnValue && await DoCrudAction(bookigItemsTobeUpdated, async (lires) => dbConnection != null && await dbConnection.UpdateAsync<IEnumerable<LIRESER>>(lires).ConfigureAwait(false));
                        returnValue = returnValue &&  await DoCrudAction(toInsertLires, async (lires) => dbConnection != null && await dbConnection.InsertAsync<IEnumerable<LIRESER>>(lires).ConfigureAwait(false) > 0);
                        returnValue = returnValue &&  await DoCrudAction(toDeleteLires, async (lires) => dbConnection != null && await dbConnection.DeleteCollectionAsync(lires).ConfigureAwait(false));

                        if (!returnValue)
                        {
                            scope.Dispose();
                        }
                        else
                        {
                            foreach (var item in bookingItemsViewObjects)
                            {
                                item.IsNew = false;
                            }
                            scope.Complete();
                            returnValue = true;
                        }
                    }
                    catch (System.Exception ex)
                    {
                        var message = "Reservation Error: " + ex.Message;
                        throw new DataAccessLayerException(message, ex);
                    }
                }
            }
            return returnValue;
        }
    }
}
