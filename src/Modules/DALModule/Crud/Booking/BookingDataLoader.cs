using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Dapper;
using DataAccessLayer.DataObjects;
using DataAccessLayer.Logic;
using DataAccessLayer.SQL;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using System.Linq;
using System.Text;
using NLog;

namespace DataAccessLayer.Crud.Booking
{
    /// <summary>
    ///  BookingDataLoader. This loads the boooking.
    /// </summary>
    internal class BookingDataLoader : IDataLoader<BookingDto>
    {

        private readonly ISqlExecutor _sqlExecutor;
        private readonly IMapper _mapper;
        private readonly QueryStoreFactory _queryStoreFactory;
        private int _currentPos;
        private static Logger _logger = LogManager.GetCurrentClassLogger();

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
        /// <returns>A list of booking</returns>
        public async Task<IEnumerable<BookingDto>> LoadAsyncAll()
        {
            var store = _queryStoreFactory.GetQueryStore();
            store.AddParam(QueryType.QueryBookingSummary);
            var query = store.BuildQuery();
            using (var dbConnection = _sqlExecutor.OpenNewDbConnection())
            {
                if (dbConnection != null)
                {
                    _logger.Log(LogLevel.Debug, query);
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
                _logger.Log(LogLevel.Debug, query);
                var multi = await dbConnection.QueryMultipleAsync(query).ConfigureAwait(false);
                var reservation = multi.Read<BookingPoco>().FirstOrDefault();
                var reservationItems = multi.Read<LIRESER>();
                if (reservation != null)
                {
                    reservationDto = _mapper.Map<BookingPoco, BookingDto>(reservation);
                }
                else
                {
                    return reservationDto;
                }

                if (reservationItems != null)
                {
                    
                    reservationDto.Items = _mapper.Map<IEnumerable<LIRESER>, IEnumerable<BookingItemsDto>>(reservationItems);
                   
                }
                if (reservationDto != null)
                {
                     string auxQuery = CreateAuxQuery(reservationDto);
                    _logger.Log(LogLevel.Debug, auxQuery);
                    var auxData = await dbConnection.QueryMultipleAsync(auxQuery).ConfigureAwait(false);
                    ParseAuxData(ref reservationDto, auxData);
                    
                }
                reservationDto.IsValid = true;
                
            }
            return reservationDto;
        }
        /// <summary>
        ///  Parse the data from the auxiliar 
        /// </summary>
        /// <param name="data">Booking object to be used.</param>
        /// <param name="reader">Reader to be used.</param>
        private void ParseAuxData(ref BookingDto data, SqlMapper.GridReader reader)
        {
            data.Drivers = SelectionHelpers.WrappedSelectedDto<ClientSummaryExtended, ClientSummaryExtended>(data.CONDUCTOR_RES1, _mapper, reader);
            data.Clients = SelectionHelpers.WrappedSelectedDto<ClientSummaryExtended, ClientSummaryExtended>(data.CLIENTE_RES1, _mapper, reader);
        }

        /// <summary>
        ///  Create a single query.
        /// </summary>
        /// <param name="data">Data to be used in a reservation.</param>
        /// <returns>Returns a query.</returns>
        private string CreateAuxQuery(BookingDto data)
        {
            var queryStore = _queryStoreFactory.GetQueryStore();
            queryStore.AddParamCount(QueryType.QueryClientSummaryExtById, data.CONDUCTOR_RES1);
            var builder = new StringBuilder();
            var queryStore2 = _queryStoreFactory.GetQueryStore();
            queryStore2.AddParamCount(QueryType.QueryClientSummaryExtById, data.CLIENTE_RES1);
            builder.Append(queryStore.BuildQuery());
            builder.Append(queryStore2.BuildQuery());
            var executableQuery = builder.ToString();
            builder.Clear();
            return executableQuery;
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
                var result = await dbConnection.QueryAsync<BookingPoco>(query);
                var dtoList = _mapper.Map<IEnumerable<BookingPoco>, IEnumerable<BookingDto>>(result);
                reservationDto = dtoList.ToList<BookingDto>();
            }
            return reservationDto;
        }
    }
}
