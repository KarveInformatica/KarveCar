using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using AutoMapper;
using DataAccessLayer.DataObjects;
using KarveDapper.Extensions;
using KarveDataServices;
using KarveDataServices.DataTransferObject;

namespace DataAccessLayer.Crud.Booking
{
    /// <summary>
    ///  This object has the single resposability of deleting an object.
    /// </summary>
    class BookingDataDeleter: IDataDeleter<BookingDto>
    {
        private readonly ISqlExecutor _executor;
        private readonly IMapper _mapper;
        /// <summary>
        /// Delete a reservation
        /// </summary>
        /// <param name="sqlExecutor">Executor of a sql query.</param>
        /// <param name="mapper">Mapper object</param>
        public BookingDataDeleter(ISqlExecutor sqlExecutor, IMapper mapper)
        {
            _executor = sqlExecutor;
            _mapper = mapper;
        }
        /// <summary>
        ///  Delete asynchronosly the booking data
        /// </summary>
        /// <param name="data">Data transfer object to delete</param>
        /// <returns>Data value</returns>
        public async Task<bool> DeleteAsync(BookingDto data)
        {
            var resultValue = true;
            var book1 = new RESERVAS1() { NUMERO_RES = data.NUMERO_RES };
            var book2 = new RESERVAS2() { NUMERO_RES = data.NUMERO_RES };

            // var book1 = _mapper.Map<BookingDto, RESERVAS1>(data);
            // var book2 = _mapper.Map<BookingDto, RESERVAS2>(data);
            var bookItems = _mapper.Map<IEnumerable<BookingItemsDto>, IEnumerable<LIRESER>>(data.Items);
            using (var deleter = _executor.OpenNewDbConnection())
            {
                using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    resultValue = await deleter.DeleteAsync(book1).ConfigureAwait(false);
                    resultValue = resultValue && await deleter.DeleteAsync(book2).ConfigureAwait(false);

                    if (bookItems.Any())
                    {
                        resultValue = resultValue && await deleter.DeleteCollectionAsync(bookItems).ConfigureAwait(false);
                    }
                    if (resultValue)
                    {
                        transactionScope.Complete();
                    }
                    else
                    {
                        transactionScope.Dispose();
                    }
                }
            }
            return resultValue;
        }
    }
}
