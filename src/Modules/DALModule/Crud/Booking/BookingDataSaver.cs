using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using AutoMapper;
using DataAccessLayer.DataObjects;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using DataAccessLayer.Exception;
using KarveDapper.Extensions;
using System.Data;
using KarveCommonInterfaces;
using DataAccessLayer.Crud.Validation;
using KarveCommon.Generic;

namespace DataAccessLayer.Crud.Booking
{
    /// <summary>
    ///  BookingDataSaver. It saves the booking.
    /// </summary>
    class BookingDataSaver: IDataSaver<BookingDto>
    {
        private ISqlExecutor _executor;
        private IMapper _mapper;
        private ValidationChain<BookingDto> _validationChain;
        
        public BookingDataSaver(ISqlExecutor sqlExecutor, IMapper mapper)
        {
            _executor = sqlExecutor;
            _mapper = mapper;
            _validationChain = new BookingNotNullRule();
            LoadValidationRules(sqlExecutor);
        }
        /// <summary>
        ///  This load a list of validation rules. Chain of resposability design pattern.
        ///  Each rule check a single aspect of the data.
        /// </summary>
        private void LoadValidationRules(ISqlExecutor executor)
        {
            var conceptValidation = new BookingConceptRule();
            var correctRule = new BookingDateCorrectRule();
            var fare = new BookingFareRule(executor);
            var groupRule = new BookingGroupCorrectRule(executor);
            fare.SetNext(conceptValidation);
            conceptValidation.SetNext(correctRule);
            correctRule.SetNext(groupRule);
            _validationChain.SetNext(fare);

        }
        private IEnumerable<LIRESER> RemapItems(IEnumerable<BookingItemsDto> items, string group, string numero)
        {
            if (items == null)
            {
                return new List<LIRESER>();
            }
            var itemCount = items.Count();
            var mappedItems = _mapper.Map<IEnumerable<BookingItemsDto>, IEnumerable<LIRESER>>(items.ToList<BookingItemsDto>());
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
        /// <param name="dbConnection">Connection to be inserted</param>
        /// <param name="entity">Entity to be inserted.</param>
        /// <returns>A boolean value to be used in this case.</returns>
        private async Task<bool> UpdateOrInsertAsyncEntity<T>(IDbConnection dbConnection, T entity) where T: class
        {
            bool returnValue = true;
            if (dbConnection.IsPresent<T>(entity))
            {
                returnValue = await dbConnection.UpdateAsync<T>(entity).ConfigureAwait(false);
            }
            else
            {
                returnValue = await dbConnection.InsertAsync<T>(entity).ConfigureAwait(false) > 0;
            }
            return returnValue;
        }
        /// <summary>
        ///  This is save asynchronously the data.
        /// </summary>
        /// <param name="save">Booking data object save</param>
        /// <returns>True if it has been saved correctly or false if it has not been saved correctly</returns>
        public async Task<bool> SaveAsync(BookingDto save)
        {
            

            // first of all we check if it is valid. In no case at data layer we shall allow invalid data.
            if (!_validationChain.CheckRequest(save))
            {
                var value = KarveLocale.Properties.Resources.ldatavalidationError+ " "+_validationChain.ErrorMessage;
                throw new DataAccessLayerException(value);
            }
            save.LastModification = DateUtils.GetKarveDateTimeNow();
            var items = save.Items;
            var toUpdateItems = items.Where<BookingItemsDto>(x => (x.IsDirty && !x.IsNew && !x.IsDeleted));
            var toInsertItems = items.Where<BookingItemsDto>(x => (x.IsNew));
            var toDeleteItems = items.Where<BookingItemsDto>(x => (x.IsDeleted));
           
            // the database has the weird thing that the booking group shall be present in lines.
            // we convert the booking items to the database columns.
           
            var toUpdateLires = RemapItems(toUpdateItems, save.GRUPO_RES1, save.NUMERO_RES);
            var toDeleteLires = RemapItems(toDeleteItems, save.GRUPO_RES1, save.NUMERO_RES);
            var toInsertLires = RemapItems(toInsertItems, save.GRUPO_RES1, save.NUMERO_RES);

            var booking = _mapper.Map<IEnumerable<BookingItemsDto>, IEnumerable<LIRESER>>(items);
            // here since we have at lower level multiple tables. We shall split the items to the real stuff.
            var bookedTableValue1 = _mapper.Map<RESERVAS1>(save);
            var bookedTableValue2 = _mapper.Map<RESERVAS2>(save);
            var returnValue = true;
            using (var dbConnection = _executor.OpenNewDbConnection())
            {
                using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    try
                    {
                        returnValue = await UpdateOrInsertAsyncEntity<RESERVAS1>(dbConnection,bookedTableValue1);
                        returnValue = returnValue && await UpdateOrInsertAsyncEntity<RESERVAS2>(dbConnection, bookedTableValue2);
                        returnValue = returnValue && await DoCrudAction(toUpdateLires, async (lires) => { return await dbConnection.UpdateAsync<IEnumerable<LIRESER>>(lires).ConfigureAwait(false); });
                        returnValue = returnValue &&  await DoCrudAction(toInsertLires, async (lires) => { return await dbConnection.InsertAsync<IEnumerable<LIRESER>>(lires).ConfigureAwait(false) > 0; });
                        returnValue = returnValue &&  await DoCrudAction(toDeleteLires, async (lires) => { return await dbConnection.DeleteCollectionAsync(lires).ConfigureAwait(false); });


                        if (!returnValue)
                        {
                            scope.Dispose();
                        }
                        else
                        {
                            scope.Complete();
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
