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
            var book1 = new RESERVAS1() { NUMERO_RES = data.NUMERO_RES };
            var book2 = new RESERVAS2() { NUMERO_RES = data.NUMERO_RES };
            var bookItems = _mapper.Map<IEnumerable<BookingItemsDto>, IEnumerable<LIRESER>>(data.Items);
            var resultValue = await DeleteHelper.DeleteAsync<RESERVAS1, RESERVAS2, LIRESER>(_executor, book1, book2);
            return resultValue;
        }
    }
}
