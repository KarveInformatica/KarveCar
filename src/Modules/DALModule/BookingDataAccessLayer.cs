using System.Collections.Generic;
using System.Security.AccessControl;
using System.Threading.Tasks;
using Dapper;
using DataAccessLayer.Crud.Booking;
using DataAccessLayer.DataObjects;
using DataAccessLayer.Logic;
using DataAccessLayer.Model;
using DataAccessLayer.SQL;
using KarveDapper.Extensions;
using KarveDataServices;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;
using System.ComponentModel;
using System;
using DataAccessLayer.Exception;

namespace DataAccessLayer
{
    /// <summary>
    /// BookingDataAccessLayer. It is the data access layer for the booking.
    /// </summary>
    internal class BookingDataAccessLayer: AbstractDataAccessLayer, IBookingDataService
    {
        private readonly IDataLoader<BookingDto> _dataLoader;
        private readonly IDataSaver<BookingDto> _dataSaver;
        private readonly IDataDeleter<BookingDto> _dataDeleter;
        private readonly IDataLoader<ReservationRequestDto> dataLoaderRequest;
        private readonly IDataSaver<ReservationRequestDto> _dataSaverRequest;
        private readonly IDataDeleter<ReservationRequestDto> _dataDeleterRequest;

        private readonly QueryStoreFactory _queryStoreFactory = new QueryStoreFactory();


        /// <summary>
        ///  Booking data access layer.
        /// </summary>
        /// <param name="executor">Executor handle database connection.</param>
        public BookingDataAccessLayer(ISqlExecutor executor): base(executor)
        {
            var mapper = MapperField.GetMapper();
            _dataLoader = new BookingDataLoader(SqlExecutor, mapper);
            _dataDeleter = new BookingDataDeleter(SqlExecutor, mapper);
            _dataSaver = new BookingDataSaver(SqlExecutor, mapper);
            TableName = "RESERVAS1";
        }
        /// <summary>
        /// Get the asynchronous summary
        /// </summary>
        /// <returns>The list of reservation in the system</returns>
        public async Task<IEnumerable<BookingSummaryDto>> GetAsyncAllSummary()
        {
            IEnumerable<BookingSummaryDto> summaryDto = new List<BookingSummaryDto>();
            using (var dbConnection = SqlExecutor.OpenNewDbConnection())
            {
                if (dbConnection == null)
                {
                    return summaryDto;
                }
                var queryStore = _queryStoreFactory.GetQueryStore();
                queryStore.AddParam(QueryType.QueryBookingSummaryExt);
                var currentQuery = queryStore.BuildQuery();
                summaryDto = await dbConnection.QueryAsync<BookingSummaryDto>(currentQuery);
                
            }
            return summaryDto;
        }

        /// <summary>
        ///  Get a new data object
        /// </summary>
        /// <param name="code">Code of the new object</param>
        /// <returns>Returns if the data is fetched with success.</returns>
        public IBookingData GetNewDo(string code)
        {
            var bookingValue = new RESERVAS1();
            var bookingData = new Reservation();
            using (var dbConnection = SqlExecutor.OpenNewDbConnection())
            {
                var reservations = string.Empty;
                if (dbConnection != null)
                {
                   reservations = dbConnection.UniqueId<RESERVAS1>(bookingValue);
                }
                var bookingDto = new BookingDto {NUMERO_RES = reservations};
                bookingData.Value = bookingDto;
            }
            return bookingData;
        }
        /// <summary>
        ///  Delete an asynchronous data object for booking.
        /// </summary>
        /// <param name="data">Data to be used</param>
        /// <returns>Returns true if the data is deleted with success.</returns>
        public async Task<bool> DeleteAsyncDo(IBookingData data)
        {
            if (data == null)
            {
                return false;
            }
            var currentValue = data.Value;
            var simpleResult = await _dataDeleter.DeleteAsync(currentValue).ConfigureAwait(false);
            return simpleResult;
        }
        /// <summary>
        ///  Save an asynchronous data object for booking.
        /// </summary>
        /// <param name="data">Data to be used</param>
        /// <returns>Value of the data</returns>
        public async Task<bool> SaveAsync(IBookingData data)
        {
            if ((data == null) || (!data.IsValid))
            {
                return false;
            }
            var value = data.Value;
            if (string.IsNullOrEmpty(data.Value.NUMERO_RES))
            {
                throw new DataAccessLayerException("Invalid Booking Number");
            }
            var boolValue = await _dataSaver.SaveAsync(value); 
            return boolValue;
        }
        /// <summary>
        ///  Serve an asynchronous data object 
        /// </summary>
        /// <param name="identifier">Identifier of the reservation</param>
        /// <returns>This returns a booking data</returns>
        public async Task<IBookingData> GetAsyncDo(string identifier)
        {
            var reservas = await _dataLoader.LoadValueAsync(identifier).ConfigureAwait(false);
            var reservation = new Reservation();
            if (reservas != null)
            {
                reservation.Value = reservas;
                reservation.IsValid = true;
            }
            reservation.Value = reservas;
            reservation.IsValid = false;
            return reservation;
        }

        /// <summary>
        ///  Get a new identifier for the reservas
        /// </summary>
        /// <returns>Returns an unique identifier for the booking. This is the booking number</returns>
        public string GetNewId()
        {
            var bookingValue = new RESERVAS1();
            var reservas = string.Empty;
            using (var dbConnection = SqlExecutor.OpenNewDbConnection())
            {
                if (dbConnection != null)
                {
                    reservas = dbConnection.UniqueId<RESERVAS1>(bookingValue);
                }
            }
            return reservas;
        }
        /// <summary>
        ///  Get the new summary data object.
        /// </summary>
        /// <param name="clientsSummaryQuery">Query to be used in query.</param>
        /// <returns>A list of booking summary</returns>
        public async Task<IEnumerable<BookingSummaryDto>> GetSummaryDo(string clientsSummaryQuery)
        {
            IEnumerable<BookingSummaryDto> bookingList = new List<BookingSummaryDto>();
            using (var dbConnection = SqlExecutor.OpenNewDbConnection())
            {
                if (dbConnection != null)
                {
                    var qs = _queryStoreFactory.GetQueryStore();
                    qs.AddParam(QueryType.QueryBookingSummaryExt);
                    var query = qs.BuildQuery();
                    bookingList = await dbConnection.QueryAsync<BookingSummaryDto>(query);
                }
            }
            return bookingList;
        }
      
        /// <summary>
        /// Get Summary all asynchronously
        /// </summary>
        /// <returns>Return a booking summary data object</returns>

        public async Task<IEnumerable<BookingSummaryDto>> GetSummaryAllAsync()
        {
           IEnumerable<BookingSummaryDto> bookingList = new List<BookingSummaryDto>();
            using (var dbConnection = SqlExecutor.OpenNewDbConnection())
            {
                if (dbConnection == null)
                {
                    return bookingList;
                }
                var qs = _queryStoreFactory.GetQueryStore();
                qs.AddParam(QueryType.QueryBookingSummaryExt);
                var query = qs.BuildQuery();
                bookingList = await dbConnection.QueryAsync<BookingSummaryDto>(query);
            }
            return bookingList;
        }
        /// <summary>
        ///  Get Data Object asynchronous
        /// </summary>
        /// <param name="code">Code</param>
        /// <returns>Returns  booking data.</returns>
        public async Task<IBookingData> GetDoAsync(string code)
        {
            var bookingData = await _dataLoader.LoadValueAsync(code);
           
            IBookingData data = new NullReservation();
            if ((bookingData != null) && (bookingData.IsValid))
            {
                data = new Reservation { Value = bookingData, IsValid = bookingData.IsValid, ItemsDtos = bookingData.Items };
            }
            if (data.IsValid)
            {

                var queryStore = _queryStoreFactory.GetQueryStore();
                queryStore.AddParam(QueryType.QueryContractsByClient, data.Value.CLIENTE_RES1);
                queryStore.AddParam(QueryType.QueryClientById, data.Value.CONDUCTOR_RES1);
                queryStore.AddParam(QueryType.QueryClientById, data.Value.CLIENTE_RES1);
                using (var connection = SqlExecutor.OpenNewDbConnection())
                {
                    if (connection != null)
                    {
                        var query = queryStore.BuildQuery();

                        var multipleQuery = await connection.QueryMultipleAsync(query);
                        data.IsValid = ParseResult(data, multipleQuery);
                    }
                }
            }
            return data;
        }

        private bool ParseResult(IBookingData data, SqlMapper.GridReader multi)
        {
            return true;
        }

        /// <summary>
        ///  Generate a new identifier.
        /// </summary>
        /// <returns></returns>
        public string NewId()
        {
            string uniqueId;
            var reservas = new RESERVAS1();
            using (var dbConnection = SqlExecutor.OpenNewDbConnection())
            {
                uniqueId = dbConnection.UniqueId<RESERVAS1>(reservas);
            }
            return uniqueId;
        }
        /// <summary>
        ///  Deleta an asynchronous data
        /// </summary>
        /// <param name="booking"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(IBookingData booking)
        {
            var book = booking.Value;
            var value = await _dataDeleter.DeleteAsync(book).ConfigureAwait(false);
            return value;
        }
        /// <summary>
        /// This is a list of a paged summary data object
        /// </summary>
        /// <param name="pageIndex">Index of the page</param>
        /// <param name="pageSize">Size of the page</param>
        /// <returns>Returns the list of bookings</returns>

        public async Task<IEnumerable<BookingSummaryDto>> GetPagedSummaryDoAsync(int pageIndex, int pageSize)
        {
            var pager = new DataPager<BookingSummaryDto>(SqlExecutor);
            var pageStart = pageIndex;
            if (pageStart == 0)
                pageStart = 1;
            NumberPage = await GetPageCount(pageSize).ConfigureAwait(false);
            var datas = await pager.GetPagedSummaryDoAsync(QueryType.QueryBookingPaged, pageStart, pageSize).ConfigureAwait(false);
            return datas;
        }

        /// <summary>
        ///  This returns a sorted summary sorted and extended collection.
        /// </summary>
        /// <param name="sortChain">Sort direction</param>
        /// <param name="pageIndex">Index of the page</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>A list of sorted items following the sorting criteria</returns>
        public async Task<IEnumerable<BookingSummaryDto>> GetSortedCollectionPagedAsync(Dictionary<string, ListSortDirection> sortChain, long pageIndex, int pageSize)
        {
            var dataPager = new DataPager<BookingSummaryDto>(SqlExecutor);
            var pageStart = pageIndex;
            if (pageStart == 0)
                pageStart = 1;
            NumberPage = await GetPageCount(pageSize).ConfigureAwait(false);
            var datas = await dataPager.GetPagedSummaryDoSortedAsync(QueryType.QueryBookingPaged, sortChain, pageIndex, pageSize);
            return datas;
        }
        /// <summary>
        ///  Get Booking Items
        /// </summary>
        /// <returns>This returns a list of booking items</returns>
        public async Task<IEnumerable<BookingItemsDto>> GetBookingItemsAsync(IBookingData bookingData)
        {
            IEnumerable<BookingItemsDto> bookingItems = new List<BookingItemsDto>();
            var data = bookingData.Value;
            var queryStore = QueryStoreFactory.GetQueryStore();
            queryStore.AddParam(QueryType.QueryBookingItems, data.NUMERO_RES);
            var qs = queryStore.BuildQuery();
            using (var dbConnection = SqlExecutor.OpenNewDbConnection())
            {
                bookingItems = await dbConnection.QueryAsync<BookingItemsDto>(qs);
            }
            return bookingItems;
        }
        /// <summary>
        /// This is the list of items witj a booking items coutn
        /// </summary>
        /// <param name="code">Code to be used</param>
        /// <returns>Value to be used.</returns>
        public async Task<int> GetBookingItemsCount(string code)
        {

            int numberOfItems = -1;
            if (string.IsNullOrEmpty(code))
            {
                throw new ArgumentNullException();
            }
            using (var dbConnection = SqlExecutor.OpenNewDbConnection())
            {
                var tuple = await dbConnection.GetPageCount<LIRESER>();
                numberOfItems =  tuple.Item1;
            }
            return numberOfItems;
        }

        
    }

}
