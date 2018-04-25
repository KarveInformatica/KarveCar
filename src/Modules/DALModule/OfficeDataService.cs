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

namespace DataAccessLayer
{
    /// <inheritdoc />
    /// <summary>
    ///  DataLayer service for handling the offices.
    /// </summary>
    internal sealed class OfficeDataService: IOfficeDataServices
    {
        private readonly ISqlExecutor _sqlExecutor;
        private readonly IMapper _mapper;
        private readonly OfficeDataLoader _loader;
        private readonly OfficeDataSaver _saver;
        private readonly OfficeDataDeleter _deleter;
        private readonly QueryStoreFactory _queryStoreFactory;
      
        /// <summary>
        ///  Office data service constructor
        /// </summary>
        /// <param name="sqlExecutor">Sql Executor, interface for ADO.NET/Dapper access</param>
        public OfficeDataService(ISqlExecutor sqlExecutor)
        {
            _sqlExecutor = sqlExecutor;
            _mapper = MapperField.GetMapper();
            _loader = new OfficeDataLoader(sqlExecutor, _mapper);
            _saver = new OfficeDataSaver(sqlExecutor, _mapper);
            _deleter = new OfficeDataDeleter(sqlExecutor, _mapper);
            _queryStoreFactory = new QueryStoreFactory();
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
        public async Task<IEnumerable<OfficeSummaryDto>> GetAsyncAllOfficeSummary()
        {
            IEnumerable<OfficeSummaryDto> summaryCollection;
            var qs = _queryStoreFactory.GetQueryStore();
            qs.AddParam(QueryType.QueryOfficeSummary);
            var query = qs.BuildQuery();
            using (IDbConnection conn = _sqlExecutor.OpenNewDbConnection())
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
        public async Task<IOfficeData> GetAsyncOfficeDo(string identifier)
        {
            var data =  await _loader.LoadValueAsync(identifier).ConfigureAwait(false);
            var office = new Office();
            if (data != null)
            { 
                
                office.Value = data;
                office.Valid = true;
            }
            else
            {
                throw new DataLayerException("Invalid office identifier " + identifier);
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
            var qs = _queryStoreFactory.GetQueryStore();
            qs.AddParam(QueryType.QueryOfficeSummaryByCompany, companyCode);
            var query = qs.BuildQuery();
            using (var conn = _sqlExecutor.OpenNewDbConnection())
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
            using (var conn = _sqlExecutor.OpenNewDbConnection())
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
                Codigo = code
                
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
            IQueryStore store = _queryStoreFactory.GetQueryStore();
            store.Clear();
            IEnumerable<DailyTime> times = new List<DailyTime>();
            using (IDbConnection connection = _sqlExecutor.OpenNewDbConnection())
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
        /// The holidays for the office
        /// </summary>
        /// <param name="officeId">Identifier of the office</param>
        /// <returns>The list of the office company</returns>
        public async Task<IEnumerable<HolidayDto>> GetHolidaysAsync(string officeId)
        {
            IQueryStore store = _queryStoreFactory.GetQueryStore();
            IEnumerable<HolidayDto> times;
            using (var connection = _sqlExecutor.OpenNewDbConnection())
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
    }
}