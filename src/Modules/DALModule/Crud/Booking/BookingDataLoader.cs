using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Dapper;
using DataAccessLayer.DataObjects;
using DataAccessLayer.Logic;
using DataAccessLayer.SQL;
using KarveDataServices;
using KarveDataServices.ViewObjects;
using System.Linq;
using System.Text;
using NLog;

namespace DataAccessLayer.Crud.Booking
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    ///  BookingDataLoader. This loads the booking.
    /// </summary>
    internal class BookingDataLoader : IDataLoader<BookingViewObject>
    {

        private readonly ISqlExecutor _sqlExecutor;
        private readonly IMapper _mapper;
        private readonly QueryStoreFactory _queryStoreFactory;
        private int _currentPos;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

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
        public async Task<IEnumerable<BookingViewObject>> LoadAsyncAll()
        {
            var store = _queryStoreFactory.GetQueryStore();
            store.AddParam(QueryType.QueryBookingSummary);
            var query = store.BuildQuery();
            using (var dbConnection = _sqlExecutor.OpenNewDbConnection())
            {
                if (dbConnection == null)
                {
                    return new List<BookingViewObject>();
                }
                Logger.Log(LogLevel.Debug, query);
                var reservation = await dbConnection.QueryAsync<BookingViewObject>(query);
                return reservation;
            }
        }

        /// <inheritdoc />
        /// <summary>
        ///  Load a single value.
        /// </summary>
        /// <param name="code">Reservation code.</param>
        /// <returns>An empty booking dto in case of fault, </returns>
        public async Task<BookingViewObject> LoadValueAsync(string code)
        {
            var reservationDto = new BookingViewObject {IsValid = false};
            if (string.IsNullOrEmpty(code))
            {
                return reservationDto;
            }
            using (var dbConnection = _sqlExecutor.OpenNewDbConnection())
            {

                var queryStore = _queryStoreFactory.GetQueryStore();

                var query = queryStore.AddParam(QueryType.QueryBooking, code).BuildQuery();
                Logger.Log(LogLevel.Debug, query);
                var multi = await dbConnection.QueryMultipleAsync(query).ConfigureAwait(false);
                var reservation = multi.Read<BookingPoco>().FirstOrDefault();
                var reservationItems = multi.Read<LIRESER>();
                if (reservation != null)
                {
                    reservationDto = _mapper.Map<BookingPoco, BookingViewObject>(reservation);
                }
                else
                {
                    return reservationDto;
                }

                if (reservationItems != null)
                {
                    
                    reservationDto.Items = _mapper.Map<IEnumerable<LIRESER>, IEnumerable<BookingItemsViewObject>>(reservationItems);
                   
                }
                 reservationDto.IsValid = true;
                
            }
            return reservationDto;
        }
        /// <summary>
        ///  Parse the data from the helper.
        /// </summary>
        /// <param name="data">Booking object to be used.</param>
        /// <param name="reader">Reader to be used.</param>
        private void ParseAuxData(ref BookingViewObject data, SqlMapper.GridReader reader)
        {
            data.Drivers = SelectionHelpers.WrappedSelectedDto<ClientSummaryExtended, ClientSummaryExtended>(data.CONDUCTOR_RES1, _mapper, reader);
            data.Clients = SelectionHelpers.WrappedSelectedDto<ClientSummaryExtended, ClientSummaryExtended>(data.CLIENTE_RES1, _mapper, reader);
        }

        /// <summary>
        ///  Create a single query.
        /// </summary>
        /// <param name="data">Data to be used in a reservation.</param>
        /// <returns>Returns a query.</returns>
        private string CreateAuxQuery(BookingViewObject data)
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

        /// <inheritdoc />
        /// <summary>
        ///  Load at most m reservation.
        /// </summary>
        /// <param name="n">Number of element</param>
        /// <param name="back">If you can go head or back.</param>
        /// <returns>A list of booking dto.</returns>
        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1101:PrefixLocalCallsWithThis", Justification = "Reviewed. Suppression is OK here.")]
        public async Task<IEnumerable<BookingViewObject>> LoadValueAtMostAsync(int n, int back = 0)
        {
            List<BookingViewObject> reservationDto;
            using (var connection
                = this._sqlExecutor.OpenNewDbConnection() ?? throw new ArgumentNullException("Cannot Open Connection"))
            {
                _currentPos += back;
                if (_currentPos < 1)
                {
                    _currentPos = 1;
                }
                var queryStore = _queryStoreFactory.GetQueryStore();
                var query = queryStore.AddParamRange(QueryType.QueryBookedPaged, _currentPos, n).BuildQuery();
                var result = await connection.QueryAsync<BookingPoco>(query);
                var dtoList = _mapper.Map<IEnumerable<BookingPoco>, IEnumerable<BookingViewObject>>(result);
                reservationDto = dtoList.ToList<BookingViewObject>();
            }
            return reservationDto;
        }
    }
}
