using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using DataAccessLayer.Crud.Booking;
using DataAccessLayer.DataObjects;
using DataAccessLayer.Logic;
using DataAccessLayer.DtoWrapper;
using DataAccessLayer.SQL;
using KarveDapper.Extensions;
using KarveDataServices;
using KarveDataServices.DataObjects;
using KarveDataServices.ViewObjects;
using System.ComponentModel;
using System;
using DataAccessLayer.Exception;
using AutoMapper;
using System.ComponentModel.DataAnnotations;
using KarveCommon.Generic;
using KarveCommon.Services;
using KarveCommonInterfaces;
using Syncfusion.UI.Xaml.Grid;

namespace DataAccessLayer
{
    /// <summary>
    /// BookingDataAccessLayer. It is the data access layer for the booking.
    /// </summary>
    internal partial class BookingDataAccessLayer: AbstractDataAccessLayer, IBookingDataService
    {
        private readonly IDataLoader<BookingViewObject> _dataLoader;
        private readonly IDataSaver<BookingViewObject> _dataSaver;
        private readonly IDataDeleter<BookingViewObject> _dataDeleter;
        private IMapper _mapper;
        private readonly IConfigurationService _configuration;
        private readonly QueryStoreFactory _queryStoreFactory = new QueryStoreFactory();
       

        /// <summary>
        ///  Booking data access layer.
        /// </summary>
        /// <param name="executor">Executor handle database connection.</param>
        public BookingDataAccessLayer(ISqlExecutor executor, IConfigurationService service): base(executor)
        {
            _mapper = MapperField.GetMapper();
            _dataLoader = new BookingDataLoader(SqlExecutor, _mapper);
            _dataDeleter = new BookingDataDeleter(SqlExecutor, _mapper);
            _dataSaver = new BookingDataSaver(SqlExecutor, _mapper);
            TableName = "RESERVAS1";
            _configuration = service;
        }
        /// <summary>
        /// Get the asynchronous summary
        /// </summary>
        /// <returns>The list of reservation in the system</returns>
        public async Task<IEnumerable<BookingSummaryViewObject>> GetAsyncAllSummary()
        {
            IEnumerable<BookingSummaryViewObject> summaryDto = new List<BookingSummaryViewObject>();
            using (var dbConnection = SqlExecutor.OpenNewDbConnection())
            {
                if (dbConnection == null)
                {
                    return summaryDto;
                }
                var queryStore = _queryStoreFactory.GetQueryStore();
                queryStore.AddParam(QueryType.QueryBookingSummaryExt);
                var currentQuery = queryStore.BuildQuery();
                summaryDto = await dbConnection.QueryAsync<BookingSummaryViewObject>(currentQuery);
                
            }
            return summaryDto;
        }

        /// <summary>
        ///  Get a new data object
        /// </summary>
        /// <param name="code">Office code for the booking</param>
        /// <returns>Returns if the data is fetched with success.</returns>
        public IBookingData GetNewDo(string code)
        {
            var bookingValue = new RESERVAS1();
            var officeCode = code.Substring(0, 2);
            var bookingData = new Reservation() { Valid = true };
            using (var dbConnection = SqlExecutor.OpenNewDbConnection())
            {
                if (dbConnection == null)
                {
                    return bookingData;
                }
                var bookingNumber = dbConnection.UniqueId<RESERVAS1>(bookingValue, null, null, officeCode);

                var bookingDto = new BookingViewObject
                    {NUMERO_RES = bookingNumber,
                        SUBLICEN_RES1 = "00", OFICINA_RES1 = officeCode, IsNew = true};
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
            if ((data == null) || (!data.Valid))
            {
                return false;
            }
            var value = data.Value;
            

            if (string.IsNullOrEmpty(data.Value.NUMERO_RES))
            {
                throw new DataAccessLayerException("Invalid Booking Number");
            }
            var boolValue = await _dataSaver.SaveAsync(value).ConfigureAwait(false);
            return boolValue;
        }

        /// <summary>
        ///  Serve an asynchronous data object 
        /// </summary>
        /// <param name="identifier">Identifier of the reservation</param>
        /// <returns>This returns a booking data</returns>
        public async Task<IBookingData> GetAsyncDo(string identifier)
        {
            var book = await _dataLoader.LoadValueAsync(identifier).ConfigureAwait(false);
            IBookingData reservation = new Reservation();
            if (book != null)
            {
                reservation.Value = book;
                reservation.Valid = true;
                return reservation;
            }
            reservation.Value = new BookingViewObject();
            reservation.Valid = false;
            try
            {
                reservation = await BuildAux(reservation).ConfigureAwait(false);
            } catch (System.Exception ex)
            {
                throw new DataLayerException("Helper table loading error", ex);
            }
            return reservation;
        }

        /// <summary>
        ///  Get a new identifier for the reservation.
        /// </summary>
        /// <returns>Returns the office identifier to be used in a new</returns>
        public string GetNewId()
        {
            /*
            var environment = _configuration.EnviromentVariables;
            var currentOfficeCode = environment.GetKey(EnvironmentConfig.KarveConfiguration,
                EnvironmentKey.CurrentOffice) as string;
                */
            // fixme.
            return "C1";
        }
        /// <summary>
        ///  Get the new summary data object.
        /// </summary>
        /// <param name="clientsSummaryQuery">Query to be used in query.</param>
        /// <returns>A list of booking summary</returns>
        public async Task<IEnumerable<BookingSummaryViewObject>> GetSummaryDo(string clientsSummaryQuery)
        {
            IEnumerable<BookingSummaryViewObject> bookingList = new List<BookingSummaryViewObject>();
            using (var dbConnection = SqlExecutor.OpenNewDbConnection())
            {
                if (dbConnection != null)
                {
                    var qs = _queryStoreFactory.GetQueryStore();
                    qs.AddParam(QueryType.QueryBookingSummaryExt);
                    var query = qs.BuildQuery();
                    bookingList = await dbConnection.QueryAsync<BookingSummaryViewObject>(query).ConfigureAwait(false);
                }
            }
            return bookingList;
        }
      
        /// <summary>
        /// Get Summary all asynchronously
        /// </summary>
        /// <returns>Return a booking summary data object</returns>

        public async Task<IEnumerable<BookingSummaryViewObject>> GetSummaryAllAsync()
        {
           IEnumerable<BookingSummaryViewObject> bookingList = new List<BookingSummaryViewObject>();
            using (var dbConnection = SqlExecutor.OpenNewDbConnection())
            {
                if (dbConnection == null)
                {
                    return bookingList;
                }
                var qs = _queryStoreFactory.GetQueryStore();
                qs.AddParam(QueryType.QueryBookingSummaryExt);
                var query = qs.BuildQuery();
                bookingList = await dbConnection.QueryAsync<BookingSummaryViewObject>(query).ConfigureAwait(false);
            }
            return bookingList;
        }

       /// <summary>
       ///  This validate the booking viewObject.
       /// </summary>
       /// <param name="viewObject">Booking data object to be validated.</param>
        public void Validate(BookingViewObject viewObject)
        {
            System.ComponentModel.DataAnnotations.ValidationContext context = new System.ComponentModel.DataAnnotations.ValidationContext(viewObject, null, null);

            List<ValidationResult> results = new List<ValidationResult>();
            bool valid = Validator.TryValidateObject(viewObject, context, results, true);
            if (!valid)
            {
              
                throw new DataAccessLayerException("Booking is not valid");
            }
            if (viewObject == null)
            {
                throw new DataAccessLayerException("Booking is null");
            }
            if (viewObject.Items == null)
            {
                throw new DataAccessLayerException("Items are null");
            }
            if (string.IsNullOrEmpty(viewObject.CLIENTE_RES1))
            {
                throw new DataAccessLayerException("Client should be not empty");
            }
            if (string.IsNullOrEmpty(viewObject.CONDUCTOR_RES1))
            {
                throw new DataAccessLayerException("Conductor should be not empty");
            }
            if (string.IsNullOrEmpty(viewObject.NUMERO_RES))
            {
                throw new DataAccessLayerException("Reservation number should be not empty");
            }

        }
        /// <summary>
        ///  Get Data Object asynchronous
        /// </summary>
        /// <param name="code">Primary Key</param>
        /// <returns>Returns  booking data.</returns>
        public async Task<IBookingData> GetDoAsync(string code)
        {
           var bookingData = await _dataLoader.LoadValueAsync(code).ConfigureAwait(false);
           
            IBookingData data = new NullReservation();
            
            if ((bookingData != null) && (bookingData.IsValid))
            {
                data = new Reservation { Value = bookingData, Valid = bookingData.IsValid};
            }
            if ((data.Value != null) && (data.Valid))
            {
                data.Clients = data.Value.Clients;
                data.Drivers = data.Value.Drivers;
                data.Contracts = data.Value.Contracts;
                try
                {
                    data = await BuildAux(data).ConfigureAwait(false);
                } catch (System.Exception ex)
                {
                    throw new DataAccessLayerException("Failed GetDoAsync:" + ex.Message, ex);
                }
            }
            return data;
        }


        
           
        /// <summary>
        ///  Generate a new identifier.
        /// </summary>
        /// <returns>An identifier for the name of the booking</returns>
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
        /// <returns>True or False in case no deleting</returns>
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

        public async Task<IEnumerable<BookingSummaryViewObject>> GetPagedSummaryDoAsync(int pageIndex, int pageSize)
        {
            var pager = new DataPager<BookingSummaryViewObject>(SqlExecutor);
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
        public async Task<IEnumerable<BookingSummaryViewObject>> GetSortedCollectionPagedAsync(Dictionary<string, ListSortDirection> sortChain, long pageIndex, int pageSize)
        {
            var dataPager = new DataPager<BookingSummaryViewObject>(SqlExecutor);
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
        public async Task<IEnumerable<BookingItemsViewObject>> GetBookingItemsAsync(IBookingData bookingData)
        {
            IEnumerable<BookingItemsViewObject> bookingItems = new List<BookingItemsViewObject>();
            var data = bookingData.Value;
            var queryStore = QueryStoreFactory.GetQueryStore();
            queryStore.AddParam(QueryType.QueryBookingItems, data.NUMERO_RES);
            var qs = queryStore.BuildQuery();
            using (var dbConnection = SqlExecutor.OpenNewDbConnection())
            {
                bookingItems = await dbConnection.QueryAsync<BookingItemsViewObject>(qs);
            }
            return bookingItems;
        }
        /// <summary>
        /// This is the list of items with a booking items count
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

        /// <summary>
        /// Retrieve a list of summaries in a date interval. Both dates cannot be null.
        /// </summary>
        /// <param name="from">Starting date. If it is null means all the past.</param>
        /// <param name="to">Ending date. It it is null means all the future.</param>
        /// <returns>List of summaries type</returns>

        public async Task<IEnumerable<BookingSummaryViewObject>> SearchByDate(DateTime? from, DateTime? to)
        {
            DateTime startDate = DateTime.Now;
            DateTime endDate  = DateTime.Now;
            IEnumerable<BookingSummaryViewObject> booking = new List<BookingSummaryViewObject>();
            if ((!from.HasValue) && (!to.HasValue))
            {
                throw new ArgumentException("One of the date shall have a value");
            }
            if (from.HasValue)
            {
                startDate = from.Value;
            }
            if (to.HasValue)
            {
                endDate = to.Value;
            }
            string queryWhere;

            var queryStore = _queryStoreFactory.GetQueryStore();
            var fromDate = startDate.ToString("yyyy-MM-dd");
            var toDate =endDate.ToString("yyyy-MM-dd");
            // 1.st case we have just to fix the start date

            if ((from.HasValue) && (!to.HasValue))
            {
                queryWhere = " ${(FSALIDA_RES1 >= fromDate) ";

            }
            else if ((to.HasValue) && (!from.HasValue))
            {
                queryWhere = " ${(FPREV_RES1 <= toDate) ";

            }
            else
            {
                queryWhere = " ${(FSALIDA_RES1 == fromDate) AND (FPREV_RES1==toDate} ";
            }
            var composedQuery = queryStore.Compose(QueryType.QueryBookingAllFields).Where(queryWhere);
            var query = composedQuery.BuildQuery();
            using (var dbConnection = SqlExecutor.OpenNewDbConnection())
            {
                booking = await dbConnection.QueryAsync<BookingSummaryViewObject>(query).ConfigureAwait(false);
            }
            return booking;
        }

        private async Task<IEnumerable<BookingSummaryViewObject>> SearchPaged(QueryType type, DateTime? from, DateTime? to)
        {
            DateTime startDate = DateTime.Now;
            DateTime endDate = DateTime.Now;
            IEnumerable<BookingSummaryViewObject> booking = new List<BookingSummaryViewObject>();
            if ((!from.HasValue) && (!to.HasValue))
            {
                throw new ArgumentException("One of the date shall have a value");
            }
            if (from.HasValue)
            {
                startDate = from.Value;
            }
            if (to.HasValue)
            {
                endDate = to.Value;
            }
            string queryWhere = string.Empty;

            var queryStore = _queryStoreFactory.GetQueryStore();
            var fromDate = startDate.ToString("yyyy-MM-dd");
            var toDate = endDate.ToString("yyyy-MM-dd");
            // 1.st case we have just to fix the start date

            if ((from.HasValue) && (!to.HasValue))
            {
                queryWhere = " ${(FSALIDA_RES1 >= fromDate) ";

            }
            else if ((to.HasValue) && (!from.HasValue))
            {
                queryWhere = " ${(FPREV_RES1 <= toDate) ";

            }
            else
            {
                queryWhere = " ${(FSALIDA_RES1 == fromDate) AND (FPREV_RES1==toDate} ";
            }
            var composedQuery = queryStore.Compose(type).Where(queryWhere);
            var query = composedQuery.BuildQuery();
            using (var dbConnection = SqlExecutor.OpenNewDbConnection())
            {
                booking = await dbConnection.QueryAsync<BookingSummaryViewObject>(query).ConfigureAwait(false);
            }
            return booking;
        }

        public Task<IEnumerable<BookingSummaryViewObject>> SearchByFilterPaged(IQueryFilter filter, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<IBookingData> SearchSingleByFilter(IQueryFilter filter)
        {
            throw new NotImplementedException();
        }

        public Task<IBookingData> SearchSingleByProperty(string name, string value)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BookingSummaryViewObject>> SearchByFilter(IQueryFilter filter)
        {
            throw new NotImplementedException();
        }
       
        public Task<IEnumerable<BookingSummaryViewObject>> SearchByDatePaged(DateTime? from, DateTime? to, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IBookingData>> GetListAsync(IList<string> primaryKeys)
        {
            throw new NotImplementedException();
        }

        public long GetNextLineId()
        {
            var bookingLines = "select TOP 1 CLAVE_LR from LIRESER ORDER BY  clave_lr desc;";
            long numberCount = 0;
            using (var dbConnection = SqlExecutor.OpenNewDbConnection())
            {
                var countName = (int)dbConnection.ExecuteScalar(bookingLines);
                numberCount = countName + 1;
            }
            return numberCount;
        }

    }

}
