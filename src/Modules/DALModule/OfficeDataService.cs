using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using KarveDataServices;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;
using DataAccessLayer.Crud.Office;
using DataAccessLayer.Model;
using DataAccessLayer.SQL;
using System.Data;
using Dapper;
using KarveDapper.Extensions;
using DataAccessLayer.DataObjects;
using DataAccessLayer.Crud;
using AutoMapper;
using DataAccessLayer.Logic;
using System.Linq;
using System.ComponentModel;

namespace DataAccessLayer
{
    /// <inheritdoc />
    /// <summary>
    ///  DataLayer service for handling the offices.
    /// </summary>
    internal sealed class OfficeDataService: AbstractDataAccessLayer,IOfficeDataServices
    {
      
        private readonly IMapper _mapper;
        private readonly OfficeDataLoader _loader;
        private readonly OfficeDataSaver _saver;
        private readonly OfficeDataDeleter _deleter;
       
        /// <summary>
        ///  Office data service constructor
        /// </summary>
        /// <param name="sqlExecutor">Sql Executor, interface for ADO.NET/Dapper access</param>
        public OfficeDataService(ISqlExecutor sqlExecutor): base(sqlExecutor)
        {
            _mapper = MapperField.GetMapper();
            _loader = new OfficeDataLoader(SqlExecutor, _mapper);
            _saver = new OfficeDataSaver(SqlExecutor, _mapper);
            _deleter = new OfficeDataDeleter(SqlExecutor, _mapper);
            // it is useful for the page count.
            TableName = "OFICINAS";

        }
        /// <summary>
        ///  Delete asynchronously an office.
        /// </summary>
        /// <param name="office">Office Entity to delete</param>
        /// <returns>True o false in case we have an office to delete.</returns>
        public async Task<bool> DeleteOfficeAsyncDo(IOfficeData office)
        {
            return await _deleter.DeleteAsync(office.Value).ConfigureAwait(false);
        }
        /// <summary>
        ///  Get the list asychronously of all offices.
        /// </summary>
        /// <returns>A list of summary office data transfer objects</returns>
        public async Task<IEnumerable<OfficeSummaryDto>> GetSummaryAllAsync()
        {
            IEnumerable<OfficeSummaryDto> summaryCollection;
            var qs = QueryStoreFactory.GetQueryStore();
            qs.AddParam(QueryType.QueryOfficeSummary);
            var query = qs.BuildQuery();
            using (var conn = SqlExecutor.OpenNewDbConnection())
            {
              summaryCollection = await conn.QueryAsync<OfficeSummaryDto>(query).ConfigureAwait(false);
            }
            return summaryCollection;
        }
        /// <summary>
        ///  Get an office from its code identifier.
        /// </summary>
        /// <param name="identifier">Identifier of the office</param>
        /// <returns>A single office data</returns>
        public async Task<IOfficeData> GetDoAsync(string code)
        {
            var data =  await _loader.LoadValueAsync(code).ConfigureAwait(false);
            var office = new Office();
            office.Valid = data.IsValid;
            if ((data != null) && (data.IsValid))
            { 
                
                office.Value = data;
            }
            else
            {
                throw new DataLayerException("Invalid office identifier " + code);
            }
          return office;
        }
        /// <summary>
        /// This gives all the offices from the company.
        /// </summary>
        /// <param name="companyCode">Code of the company</param>
        /// <returns>Returns the collection of offices.</returns>
        public async Task<IEnumerable<OfficeSummaryDto>> GetCompanyOffices(string companyCode)
        {
            IEnumerable<OfficeSummaryDto> summaryCollection;
            var qs = QueryStoreFactory.GetQueryStore();
            qs.AddParam(QueryType.QueryOfficeSummaryByCompany, companyCode);
            var query = qs.BuildQuery();
            using (var conn = SqlExecutor.OpenNewDbConnection())
            {
                summaryCollection = await conn.QueryAsync<OfficeSummaryDto>(query).ConfigureAwait(false);
            }
            return summaryCollection;
        }
        /// <summary>
        ///  Get an unique id for the office table. The id is a new identifier that it can be used for inserting 
        ///  a new office in the database
        /// </summary>
        /// <returns>Return a new identifier</returns>
        public string GetNewId()
        {
            var oficinas = new OFICINAS();
            var id = string.Empty;
            using (var conn = SqlExecutor.OpenNewDbConnection())
            {
                id = conn.UniqueId<OFICINAS>(oficinas);
            }
            return id;
        }
        /// <summary>
        /// Get a new office. 
        /// </summary>
        /// <param name="code">Create a new dto for the office.</param>
        /// <returns>Returns a new office.</returns>
        public IOfficeData GetNewOfficeDo(string code)
        {

            var data = new OfficeDtos
            {
                Codigo = code,
                IsNew = true
                
            };
           
            var office = new Office
            {
               
                ClientZoneDto = new ObservableCollection<ZonaOfiDto>(),
                ContableDelegaDto = new ObservableCollection<DelegaContableDto>(),
                CountryDto = new ObservableCollection<CountryDto>(),
                CityDto = new ObservableCollection<CityDto>(),
                CurrenciesDto = new ObservableCollection<CurrenciesDto>(),
                ProvinciaDto =  new ObservableCollection<ProvinciaDto>(),
                ZoneDto = new ObservableCollection<ClientZoneDto>(),
                Value = data,
                Valid = true
            };
            return office;
        }
        /// <summary>
        /// Get the time table from asynchronous office.
        /// </summary>
        /// <param name="officeId">Office identifier</param>
        /// <param name="companyId">Company identifier</param>
        /// <returns>The timetable of the office for the week</returns>
        public async Task<IEnumerable<DailyTime>> GetTimeTableAsync(string officeId, string companyId)
        {
            var store = QueryStoreFactory.GetQueryStore();
            store.Clear();
            IEnumerable<DailyTime> times = new List<DailyTime>();
            using (var connection = SqlExecutor.OpenNewDbConnection())
            {
                IList<string> param = new List<string>();
                param.Add(officeId);
                param.Add(companyId);
                var query = store.BuildQuery(QueryType.QueryOfficeByCompany, param);
                var offices = await connection.QueryAsync<OFICINAS>(query);
                var currentOffice = offices.FirstOrDefault();
                if (currentOffice != null)
                {
                    times = _mapper.Map<OFICINAS, IList<DailyTime>>(currentOffice);
                }
            }
            return times;
        }

        /// <summary>
        ///  Get Pages
        /// </summary>
        /// <param name="baseIndex"></param>
        /// <param name="defaultPageSize"></param>
        /// <returns></returns>
        public async Task<IEnumerable<OfficeSummaryDto>> GetPagedSummaryDoAsync(int baseIndex, int defaultPageSize)
        {
          var dataPager = new DataPager<OfficeSummaryDto>(SqlExecutor);
            var pageStart = baseIndex;
            if (pageStart == 0)
                pageStart = 1;
            NumberPage = await GetPageCount(defaultPageSize);
            var pages = await  dataPager.GetPagedSummaryDoAsync(QueryType.QueryOfficeSummaryPaged, pageStart, defaultPageSize);
          return pages;
        }

        /// <summary>
        /// The holidays for the office
        /// </summary>
        /// <param name="officeId">Identifier of the office</param>
        /// <returns>The list of the office company</returns>
        public async Task<IEnumerable<HolidayDto>> GetHolidaysAsync(string officeId)
        {
            var store = QueryStoreFactory.GetQueryStore();
            IEnumerable<HolidayDto> times;
            using (var connection = SqlExecutor.OpenNewDbConnection())
            {
                store.AddParam(QueryType.HolidaysByOffice, officeId);
                var build = store.BuildQuery();
                var holidays = await connection.QueryAsync<FESTIVOS_OFICINA>(build);
                times = _mapper.Map<IEnumerable<FESTIVOS_OFICINA>, IEnumerable<HolidayDto>>(holidays);
            }
            return times;
        }

        /// <summary>
        ///  This save/insert asynchronously an office.
        /// </summary>
        /// <param name="client">Office to save.</param>
        /// <returns>Returns true o false in case of saving office data.</returns>
        public async Task<bool> SaveAsync(IOfficeData client)
        {
            if (client.Valid)
            {
                return await _saver.SaveAsync(client.Value).ConfigureAwait(false);
            }
            return false;
        }
        /// <summary>
        ///  This returns a sorted summary sorted and extended collection.
        /// </summary>
        /// <param name="sortChain">Sort direction</param>
        /// <param name="pageIndex">Index of the page</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>A list of sorted clients</returns>
        public async Task<IEnumerable<OfficeSummaryDto>> GetSortedCollectionPagedAsync(Dictionary<string, ListSortDirection> sortChain, long pageIndex, int pageSize)
        {
            var dataPager = new DataPager<OfficeSummaryDto>(SqlExecutor);
            var pageStart = pageIndex;
            if (pageStart == 0)
                pageStart = 1;
            NumberPage = await GetPageCount(pageSize).ConfigureAwait(false);
            var datas = await dataPager.GetPagedSummaryDoSortedAsync(QueryType.QueryClientPagedSummary, sortChain, pageIndex, pageSize);
            return datas;
        }
        /// <summary>
        ///  Create a new data office which contains a new data object.
        /// </summary>
        /// <param name="value">Office identifier</param>
        /// <returns>An data office</returns>
        public IOfficeData GetNewDo(string value)
        {
            return GetNewOfficeDo(value);
        }
        /// <summary>
        /// Delete a new data office.
        /// </summary>
        /// <param name="booking">A booking data office.</param>
        /// <returns>true or false in case has been deleted</returns>
        public async Task<bool> DeleteAsync(IOfficeData booking)
        {
            return await DeleteOfficeAsyncDo(booking).ConfigureAwait(false);
        }
        /// <summary>
        ///  Retrieve the complete list of offices.
        /// </summary>
        /// <returns>A list office summary</returns>
        public async Task<IEnumerable<OfficeSummaryDto>> GetAsyncAllOfficeSummary()
        {
            return await GetSummaryAllAsync().ConfigureAwait(false);
        }
        /// <summary>
        ///  Retrieve a single office.
        /// </summary>
        /// <param name="officeIdentifier">Identifier of the office.</param>
        /// <returns></returns>
        public async Task<IOfficeData> GetAsyncOfficeDo(string officeIdentifier)
        {
            return await GetDoAsync(officeIdentifier).ConfigureAwait(false);
        }

        public async Task SaveHolidaysAsync(OfficeDtos dto, IEnumerable<HolidayDto> holidaysDates)
        {

            await _saver.SaveHolidaysAsync(dto, holidaysDates).ConfigureAwait(false);
        }

        public Task<IEnumerable<IOfficeData>> GetListAsync(IList<string> primaryKeys)
        {
            throw new System.NotImplementedException();
        }
        /// <summary>
        ///  Get the collection from the company.
        /// </summary>
        /// <param name="office"></param>
        /// <returns>This returns the company list</returns>
        public async Task<IEnumerable<CompanyDto>> GetCompanyAsync(string office)
        {
            IEnumerable<CompanyDto> companyCollection = new List<CompanyDto>();
            var qs = QueryStoreFactory.GetQueryStore();
            qs.AddParam(QueryType.QueryCompanyByOffice, office);
            using (var dbConnection = SqlExecutor.OpenNewDbConnection())
            {
                var builder = qs.BuildQuery();

                var entityCollection = await dbConnection.QueryAsync<SUBLICEN>(builder);
                companyCollection = _mapper.Map<IEnumerable<CompanyDto>>(entityCollection);
            }
            return companyCollection;   
        }
    }
}