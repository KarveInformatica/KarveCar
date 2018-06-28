using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using KarveDapper;
using KarveDapper.Extensions;
using Dapper;
using DataAccessLayer.DataObjects;
using DataAccessLayer.Logic;
using DataAccessLayer.SQL;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using System.Linq;

namespace DataAccessLayer.Crud.Booking
{
    /// <summary>
    ///  BookingDataLoader. This loads the boooking.
    /// </summary>
    internal class BookingDataLoader: IDataLoader<BookingDto>
    {

        private readonly ISqlExecutor _sqlExecutor;
        private readonly IMapper _mapper;
        private readonly QueryStoreFactory _queryStoreFactory;
        private int _currentPos;

        /// <summary>
        ///  Constructor for the booking data loader.
        /// </summary>
        /// <param name="sqlExecutor">Sql executor interface</param>
        /// <param name="mapper">Maps the mapper</param>
        public BookingDataLoader(ISqlExecutor sqlExecutor, IMapper mapper)
        {
            _sqlExecutor = sqlExecutor;
            _mapper = MapperField.GetMapper();
            _queryStoreFactory = new QueryStoreFactory();

        }
        /// <summary>
        ///  Load the asynchronous async load.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<BookingDto>> LoadAsyncAll()
        {
            var store = _queryStoreFactory.GetQueryStore();
            store.AddParam(QueryType.QueryBookingSummary);
            var query = store.BuildQuery();
            using (var dbConnection = _sqlExecutor.OpenNewDbConnection())
            {
                if (dbConnection != null)
                {
                    var reservation = await dbConnection.QueryAsync<BookingDto>(query);
                    return reservation;
                }
            }
            return new List<BookingDto>();
        }


        /// <summary>
        ///  Load a single value.
        /// </summary>
        /// <param name="code">Reservation code.</param>
        /// <returns>An empty booking dto in case of fault, </returns>
        public async Task<BookingDto> LoadValueAsync(string code)
        {
            var reservationDto = new BookingDto();
            reservationDto.IsValid = false;
            if (string.IsNullOrEmpty(code))
            {
                return reservationDto;
            }
            using (var dbConnection = _sqlExecutor.OpenNewDbConnection())
            {
                var queryStore = _queryStoreFactory.GetQueryStore();
               
                var query = queryStore.AddParam(QueryType.QueryBooking, code).BuildQuery();
                using (var multi = await dbConnection.QueryMultipleAsync(query))
                {
                    var reservation = multi.Read<BookingPoco>().FirstOrDefault();
                    if (reservation != null)
                    {
                        reservationDto = _mapper.Map<BookingPoco, BookingDto>(reservation);
                    }
                    else
                    {
                        return reservationDto;
                    }

                    var reservationItems = multi.Read<LIRESER>().ToList();
                    if (reservationItems != null)
                    {
                        reservationDto.Items = _mapper.Map<IEnumerable<LIRESER>, IEnumerable<BookingItemsDto>>(reservationItems);
                    }
                    reservationDto.IsValid = true;
                }
            }
            return reservationDto;
        }
        /// <summary>
        ///  Load at most m reservation.
        /// </summary>
        /// <param name="n">Number of element</param>
        /// <param name="back">If you can go head or back.</param>
        /// <returns>A list of booking dto.</returns>
        public async Task<IEnumerable<BookingDto>> LoadValueAtMostAsync(int n, int back = 0)
        {
            var reservationDto = new List<BookingDto>();
            using (var dbConnection = _sqlExecutor.OpenNewDbConnection())
            {
                _currentPos += back;
                if (_currentPos < 1)
                {
                    _currentPos = 1;
                }
                var queryStore = _queryStoreFactory.GetQueryStore();
                var query = queryStore.AddParamRange(QueryType.QueryBookedPaged, _currentPos, n).BuildQuery();
                var result = await dbConnection.QueryAsync(query);

            }
           return reservationDto;
        }
    }
}
