using KarveDataServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KarveDataServices.DataTransferObject;
using DataAccessLayer.Crud;
using DataAccessLayer.DataObjects;
using DataAccessLayer.Model;
using DataAccessLayer.Exception;
using Dapper;
using DataAccessLayer.SQL;
using System.ComponentModel;
using DataAccessLayer.Logic;
using KarveDapper.Extensions;
using AutoMapper;
using KarveCommonInterfaces;
using KarveDataServices.DataObjects;
using System.Text;
using System.Linq;

namespace DataAccessLayer
{
	  /// <summary>
      ///  Data Access Layer Repository generated automagically by Karve CodeGenerator Project.
      /// </summary>
    public class BookingIncidentDataAccessLayer : AbstractDataAccessLayer, IBookingIncidentDataService
    {
        private IDataLoader<BookingIncidentDto> _dataLoader;
        private IDataSaver<BookingIncidentDto> _dataSaver;
        private IDataDeleter<BookingIncidentDto> _dataDeleter;
        private IMapper _mapper;
        /// <summary>
        /// BookingIncidentDataAccessLayer
        /// </summary>
        /// <param name="sqlExecutor">SQL executor</param>
        public BookingIncidentDataAccessLayer(ISqlExecutor sqlExecutor): base(sqlExecutor)
        {
            _dataLoader = new DataLoader<INCIRE, BookingIncidentDto>(sqlExecutor);
            _dataSaver = new DataSaver<INCIRE, BookingIncidentDto>(sqlExecutor);
            _dataDeleter = new DataDeleter<INCIRE, BookingIncidentDto>(sqlExecutor);
            TableName = "INCIRE";
            _mapper = MapperField.GetMapper();
        }
        /// <summary>
        ///  Delete a booking incident data
        /// </summary>
        /// <param name="domainObject">Domain object to be valid</param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(IBookingIncidentData domainObject)
        {
            if (!domainObject.Valid)
            {
                return false;
            }
            var dto = domainObject.Value;
            var result = await _dataDeleter.DeleteAsync(dto).ConfigureAwait(false);
            return result;
        }
        /// <summary>
        ///  Get a single domain object value from its code.
        /// </summary>
        /// <param name="code">Code to be used.</param>
        /// <returns>Incident data</returns>
        public async Task<IBookingIncidentData> GetDoAsync(string code)
        {
            IBookingIncidentData result = new NullBookingIncident();
            try
            {
                var dto  = await _dataLoader.LoadValueAsync(code).ConfigureAwait(false);
                result = new BookingIncident(dto);
                result.Valid = true;
            }
            catch (System.Exception ex)
            {
                throw new DataAccessLayerException("Invalid request received with "+code, ex);
            }
            // now i shall use a query store again for setting and loading related stuff.
            if (result.Valid)
            {
				result = await BuildAux(result).ConfigureAwait(false);
            }
            return result;
        }
        /// <summary>
        ///  Retrieve and build the auxiliar tables.
        /// </summary>
        /// <param name="result">Booking Inicident data to be used</param>
        /// <returns></returns>
		 public async Task<IBookingIncidentData> BuildAux(IBookingIncidentData result)
		 {
			 var auxQueryStore = QueryStoreFactory.GetQueryStore();
            var dto = result.Value;
                #region KarveCode Generator for query multiple
				// Code Generated that concatains multiple queries to be executed by QueryMultipleAsync.
                
                auxQueryStore.AddParamCount(QueryType.QueryOffice, dto.OFICINA);
                
                auxQueryStore.AddParamCount(QueryType.QuerySupplierSummary, dto.PROVEE);
                
                auxQueryStore.AddParamCount(QueryType.QueryVehicleSummary, dto.NOM_VEHI);
                
                auxQueryStore.AddParamCount(QueryType.QueryClientSummaryExtById, dto.CLIENTE);
                
                auxQueryStore.AddParamCount(QueryType.QueryBookingIncidentType, dto.TIPO);
                
				#endregion
                var query = auxQueryStore.BuildQuery();
                using (var connection = SqlExecutor.OpenNewDbConnection())
                {
                    if (connection != null)
                    {
                        var multipleResult = await connection.QueryMultipleAsync(query).ConfigureAwait(false);
                        result.Valid = ParseResult(result, multipleResult);
                    }
                }
				return result;
		 }
        private bool ParseResult(IBookingIncidentData request, SqlMapper.GridReader reader)
        {

         if ((request == null) || (reader==null))
         {
                return false;
         }
         if (request.Value == null)
            {
                return false;
            }
            try
            {
              
                request.IncidentOfficeDto = SelectionHelpers.WrappedSelectedDto<OFICINAS, OfficeDtos>(request.Value.OFICINA, _mapper, reader);
              
                request.IncidentSupplierDto = SelectionHelpers.WrappedSelectedDto<PROVEE1, SupplierSummaryDto>(request.Value.PROVEE, _mapper, reader);
              
                request.IncidentVehicleDto = SelectionHelpers.WrappedSelectedDto<VehicleSummaryDto, VehicleSummaryDto>(request.Value.NOM_VEHI, _mapper, reader);
              
                request.IncidentClientDto = SelectionHelpers.WrappedSelectedDto<ClientSummaryExtended, ClientSummaryExtended>(request.Value.CLIENTE, _mapper, reader);
              
                request.IncidentTypeDto = SelectionHelpers.WrappedSelectedDto<COINRE, IncidentTypeDto>(request.Value.TIPO, _mapper, reader);
              

#pragma warning disable CS0168 // Variable is declared but never used
            }
            catch (System.Exception ex)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                return false;
            }
            return true;
        }
        /// <summary>
        ///  Get a new incident data 
        /// </summary>
        /// <param name="value">Value to be used as incident data.</param>
        /// <returns>An incident data to be used.</returns>
        public IBookingIncidentData GetNewDo(string value)
        {
            var newDto = new BookingIncidentDto();
            newDto.COD_INCI = value;
            newDto.IsNew = true;
            var domainObject = new BookingIncident(newDto);
            return domainObject;
        }
        /// <summary>
        /// A list of paged summary asynchronous data.
        /// </summary>
        /// <param name="index">Index to be used</param>
        /// <param name="pageSize">Page size to be used</param>
        /// <returns></returns>
        public async Task<IEnumerable<BookingIncidentSummaryDto>> GetPagedSummaryDoAsync(int index, int pageSize)
        {
            if (pageSize <= 0)
            {
                throw new ArgumentException();
            }
            var pager = new DataPager<BookingIncidentSummaryDto>(SqlExecutor);
            var pageStart = index;
            if (pageStart <= 0)
                pageStart = 1;
            NumberPage = await GetPageCount(pageSize).ConfigureAwait(false);
            var datas = await pager.GetPagedSummaryDoAsync(QueryType.BookingIncidentSummaryPaged, pageStart, pageSize).ConfigureAwait(false);
            return datas;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sortChain">Direction of the sort chain</param>
        /// <param name="index">Index to be used</param>
        /// <param name="pageSize">Page size to be used</param>
        /// <returns>A task of the booking incident summary to be used.</returns>
        public async Task<IEnumerable<BookingIncidentSummaryDto>> GetSortedCollectionPagedAsync(Dictionary<string, ListSortDirection> sortChain, long index, int pageSize)
        {
            if (pageSize <=0)
            {
                throw new ArgumentException();
            }
            var dataPager = new DataPager<BookingIncidentSummaryDto>(SqlExecutor);
            var pageStart = index;
            if (pageStart <= 0)
                pageStart = 1;
            NumberPage = await GetPageCount(pageSize).ConfigureAwait(false);
            var datas = await dataPager.GetPagedSummaryDoSortedAsync(QueryStore.BookingIncidentSummaryPaged, sortChain, index, pageSize).ConfigureAwait(false);
            return datas;
        }
        /// <summary>
        ///  Retrieve complete list of summary async values.
        /// </summary>
        /// <returns>A list of BookingIncidentSummaryDto</returns>
        public async Task<IEnumerable<BookingIncidentSummaryDto>> GetSummaryAllAsync()
        {
            var queryStore = QueryStoreFactory.GetQueryStore();
            queryStore.AddParam(QueryType.QueryBookingIncidentSummary);
            var query = queryStore.BuildQuery();
            IEnumerable<BookingIncidentSummaryDto> outResult = new List<BookingIncidentSummaryDto>();
            using (var dbConnection = SqlExecutor.OpenNewDbConnection())
            {
              if (dbConnection == null)
                {
                    throw new DataAccessLayerException("GetSummaryAllAsync cannot connect");
                }
              outResult = await dbConnection.QueryAsync<BookingIncidentSummaryDto>(query).ConfigureAwait(false);
            }
            return outResult;
        }
        /// <summary>
        ///  Returns a new identifier
        /// </summary>
        /// <returns>A new identifier for the incident table.</returns>
        public string NewId()
        {
            string uniqueId = string.Empty;
            using (var connection = SqlExecutor.OpenNewDbConnection())
            {
                if (connection != null)
                {
                    var pet = new INCIRE();
                    uniqueId = connection.UniqueId(pet);
                    return uniqueId;
                }
            }
            return uniqueId;
        }
        /// <summary>
        /// Save an asynchronous domain incident.
        /// </summary>
        /// <param name="domainObject"></param>
        /// <returns></returns>
        public async Task<bool> SaveAsync(IBookingIncidentData domainObject)
        {
           if (!domainObject.Valid)
           {
                return false;
           }
            var savedReservation = await _dataSaver.SaveAsync(domainObject.Value).ConfigureAwait(false);
            return savedReservation;
        }

        /// <summary>
        ///  Get a list of a booking incident data
        /// </summary>
        /// <param name="primaryKeys">A list of primary keys.</param>
        /// <returns>A list of primary keys</returns>
        public async Task<IEnumerable<IBookingIncidentData>> GetListAsync(IList<string> primaryKeys)
        {
            var auxQueryStore = QueryStoreFactory.GetQueryStore();
            StringBuilder builder = new StringBuilder();
           
            IList<IBookingIncidentData> bookingIncidentData = new List<IBookingIncidentData>();
            foreach (var key in primaryKeys)
            {
                auxQueryStore.AddParam(QueryType.QueryBookingIncident, key);
                var query = auxQueryStore.BuildQuery();
                builder.Append(query);

            }
            var definitiveQuery = builder.ToString();

            using (var connection = SqlExecutor.OpenNewDbConnection())
            {
                if (connection == null)
                {
                    throw new DataLayerException("Error during loading incidents");
                }
                var reader = await connection.QueryMultipleAsync(definitiveQuery).ConfigureAwait(false);
                foreach (var key in primaryKeys)
                {
                    var incident = SelectionHelpers.WrappedSelectedDto<INCIRE, BookingIncidentDto>(key, _mapper, reader);
                    var currentIncident = incident.FirstOrDefault();
                    bookingIncidentData.Add(new BookingIncident(currentIncident));

                }
            }
            return bookingIncidentData;
           
        }

        public Task<IEnumerable<BookingIncidentSummaryDto>> SearchByDate(DateTime? from, DateTime? to)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BookingIncidentSummaryDto>> SearchByFilter(IQueryFilter filter)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BookingIncidentSummaryDto>> SearchByDatePaged(DateTime? from, DateTime? to, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BookingIncidentSummaryDto>> SearchByFilterPaged(IQueryFilter filter, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<IBookingIncidentData> SearchSingleByFilter(IQueryFilter filter)
        {
            throw new NotImplementedException();
        }

        public Task<IBookingIncidentData> SearchSingleByProperty(string name, string value)
        {
            throw new NotImplementedException();
        }

        
    }
}