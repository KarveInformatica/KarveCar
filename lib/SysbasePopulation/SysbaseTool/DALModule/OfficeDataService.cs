using System.Collections.Generic;
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

namespace DataAccessLayer
{
    /// <summary>
    ///  DataLayer service for handling the offices.
    /// </summary>
    internal class OfficeDataService: IOfficeDataServices
    {
        private ISqlExecutor _sqlExecutor;
        private OfficeDataLoader _loader;
        private OfficeDataSaver _saver;
        private OfficeDataDeleter _deleter;
        private QueryStoreFactory _queryStoreFactory;
        /// <summary>
        ///  Office data service constructor
        /// </summary>
        /// <param name="sqlExecutor">Sql Executor, interface for ADO.NET/Dapper access</param>
        public OfficeDataService(ISqlExecutor sqlExecutor)
        {
            _sqlExecutor = sqlExecutor;
            _loader = new OfficeDataLoader(sqlExecutor);
            _saver = new OfficeDataSaver(sqlExecutor);
            _deleter = new OfficeDataDeleter(sqlExecutor);
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
            IEnumerable<OfficeSummaryDto> summaryCollection = new List<OfficeSummaryDto>();
            IQueryStore qs = _queryStoreFactory.GetQueryStore();
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
           OfficeDtos data =  await _loader.LoadValueAsync(identifier).ConfigureAwait(false);
            IOfficeData office = new Office();
            if (data != null)
            { 
                office.Value = data;
                office.Valid = true;
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
            IEnumerable<OfficeSummaryDto> summaryCollection = new List<OfficeSummaryDto>();
            IQueryStore qs = _queryStoreFactory.GetQueryStore();
            qs.AddParam(QueryType.QueryOfficeSummaryByCompany, companyCode);
            var query = qs.BuildQuery();
            using (IDbConnection conn = _sqlExecutor.OpenNewDbConnection())
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
            OFICINAS oficinas = new OFICINAS();
            string id = string.Empty;
            using (IDbConnection conn = _sqlExecutor.OpenNewDbConnection())
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
            OfficeDtos data = new OfficeDtos();
            data.Codigo = code;
         
            IOfficeData office = new Office();
            office.Value = data;
            office.Valid = true;
            return office;
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