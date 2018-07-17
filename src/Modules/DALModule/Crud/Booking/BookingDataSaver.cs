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

namespace DataAccessLayer.Crud.Booking
{
    /// <summary>
    ///  BookingDataSaver. It saves the booking.
    /// </summary>
    class BookingDataSaver: IDataSaver<BookingDto>
    {
        private ISqlExecutor _executor;
        private IMapper _mapper;
        public BookingDataSaver(ISqlExecutor sqlExecutor, IMapper mapper)
        {
            _executor = sqlExecutor;
            _mapper = mapper;
        }
        private IEnumerable<LIRESER> RemapItems(IEnumerable<BookingItemsDto> items)
        {
            if (items == null)
            {
                return new List<LIRESER>();
            }
            return _mapper.Map<IEnumerable<BookingItemsDto>, IEnumerable<LIRESER>>(items);
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
            var items = save.Items;
            IEnumerable<BookingItemsDto> toUpdateItems = new List<BookingItemsDto>();
            IEnumerable<BookingItemsDto> toInsertItems = new List<BookingItemsDto>();
            IEnumerable<BookingItemsDto> toDeleteItems = new List<BookingItemsDto>();

            toUpdateItems = items.Where<BookingItemsDto>(x => (x.IsDirty && !x.IsNew && !x.IsDeleted));
            toInsertItems = items.Where<BookingItemsDto>(x => (x.IsNew));
            toDeleteItems = items.Where<BookingItemsDto>(x => (x.IsDeleted));

            IEnumerable<LIRESER> toUpdateLires = RemapItems(toUpdateItems);
            IEnumerable<LIRESER> toDeleteLires = RemapItems(toDeleteItems);
            IEnumerable<LIRESER> toInsertLires = RemapItems(toInsertItems);

            var booking = _mapper.Map<IEnumerable<BookingItemsDto>, IEnumerable<LIRESER>>(items);
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
                        throw new DataAccessLayerException("Error during saving the data", ex);
                    }
                }
            }
            return returnValue;
        }
    }
}
