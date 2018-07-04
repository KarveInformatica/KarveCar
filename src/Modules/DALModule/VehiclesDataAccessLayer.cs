using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;
using Dapper;
using DataAccessLayer.DataObjects;
using KarveCommon.Generic;
using KarveDataServices;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;
using DataAccessLayer.SQL;
using KarveDapper.Extensions;
using DataAccessLayer.Crud.Vehicle;
using DataAccessLayer.Model;

namespace DataAccessLayer
{
    
    /// <summary>
    /// This is an implementation of the data access layer for the data services.
    /// </summary>
    internal class VehiclesDataAccessLayer : AbstractDataAccessLayer, IVehicleDataServices
    {
        private readonly ISqlExecutor _sqlExecutor;
        private IDataLoader<IVehicleData> _dataLoader;
        private IDataDeleter<IVehicleData> _dataDeleter;
        private IDataSaver<IVehicleData> _dataSaver;
        private const string PrimaryKey = "CODIINT";
        private const string VehicleDataFile = @"\Data\VehicleFields.xml";
        ///private readonly VehicleFactory _factory = null;
        private QueryStoreFactory _queryStoreFactory;
        /// <summary>
        /// VehicleDataAccessLayer class.
        /// </summary>
        /// <param name="sqlExecutor">Executor of the sql commands</param>
        public VehiclesDataAccessLayer(ISqlExecutor sqlExecutor) : base(sqlExecutor)
        {
            _sqlExecutor = sqlExecutor;
            base.InitData(VehicleDataFile);
            _dataLoader = new VehicleDataLoader(_sqlExecutor);
            _dataSaver = new VehicleDataSaver(_sqlExecutor);
            _dataDeleter = new VehicleDataDeleter(_sqlExecutor);
            TableName = "VEHICULO1";
        }

        /// <summary>
        ///  This returns a vehicle agent summary.
        /// </summary>
        /// <returns>Returns a data set for the vehicles</returns>
        public async Task<IEnumerable<VehicleSummaryDto>> GetAsyncVehicleSummary()
        {
            return await GetVehiclesAgentSummary(0, 0);

        }

        /// <summary>
        /// Get a paged version of the summary.
        /// </summary>
        /// <param name="pageSize">Page dimension.</param>
        /// <param name="offset">Offset</param>
        /// <returns></returns>
        public async Task<IEnumerable<VehicleSummaryDto>> GetVehiclesAgentSummary(int pageSize, int offset)
        {
            IEnumerable<VehicleSummaryDto> summary = new List<VehicleSummaryDto>();
            IQueryStore store = _queryStoreFactory.GetQueryStore();
            store.AddParam(QueryType.QueryVehicleSummary);
            var query = store.BuildQuery();
            using (IDbConnection connection = _sqlExecutor.OpenNewDbConnection())
            {
                  summary = await connection.QueryAsync<VehicleSummaryDto>(query).ConfigureAwait(false);
            }
            return summary;
        }

        /// <summary>
        ///  Generate an unique id from the base class.
        /// </summary>
        /// <returns></returns>
        public string GetNewId()
        {
            var vehicle = new VEHICULO1();
            var uniqueStr = string.Empty;
            using (var dbConnection = _sqlExecutor.OpenNewDbConnection())
            {
                if (dbConnection != null)
                {
                    uniqueStr = dbConnection.UniqueId(vehicle);
                }   
            }
            return uniqueStr;
        }

       
        /// <summary>
        /// Fetch a single vehicle Data object
        /// </summary>
        /// <param name="vehicleId">Vehicle identifier</param>
        /// <param name="queryDictionary">Dictionary of the queries</param>
        /// <returns>A vehicle data objett</returns>
        public async Task<IVehicleData> GetVehicleDo(string vehicleId, IDictionary<string, string> queryDictionary)
        {
            Contract.Requires(!string.IsNullOrEmpty(vehicleId), "A valid id is needed");
            IDictionary<string, string> queries;
            queries = queryDictionary ?? base.BaseQueryDictionary;
            var item = await _dataLoader.LoadValueAsync(vehicleId).ConfigureAwait(false);
            return item;

        }
        /// <summary>
        ///  Save a new inserted vehicle.
        /// </summary>
        /// <param name="data">Vehicle data to be saved</param>
        /// <returns>True when the vehicle has been saved correctly</returns>
        public async Task<bool> SaveChanges(IVehicleData data)
        {
            Contract.Requires(data != null, "Cant save a null vehicle");
            bool ret = await data.SaveChanges();
            return ret;
        }

        /// <summary>
        /// Vehicle to be saved
        /// </summary>
        /// <param name="vehicleData">Vehicle to be saved.</param>
        /// <returns></returns>
        public async Task<bool> SaveVehicle(IVehicleData vehicleData)
        {
            Contract.Requires(vehicleData != null, "Cant save a null vehicle");
            bool changedTask = await vehicleData.Save();
            return changedTask;
        }

        /// <summary>
        ///  Delete a vehicle data.
        /// </summary>
        /// <param name="vehicleData">Vehicle to be deleted</param>
        /// <returns></returns>
        public async Task<bool> DeleteVehicleData(IVehicleData vehicleData)
        {
            bool value = false;
            value = await vehicleData.DeleteAsyncData();
            return value;
        }

        /// <summary>
        /// Get a new vehicle data object
        /// </summary>
        /// <param name="primaryKeyValue">Primary key to be saved.</param>
        /// <returns></returns>
        public async Task<IVehicleData> GetVehicleDo(string primaryKeyValue)
        {
            return await GetVehicleDo(primaryKeyValue, null).ConfigureAwait(false);
        }
    
        /// <summary>
        ///  Updates a vehicle changes
        /// </summary>
        /// <param name="data">Data to be saved.</param>
        /// <returns></returns>
        public async Task<bool> SaveChangesVehicle(IVehicleData data)
        {
            var saved = await data.SaveChanges();
            return saved;
        }
        /// <summary>
        ///  Update the paged summary data object asynchronous.
        /// </summary>
        /// <param name="baseIndex"></param>
        /// <param name="defaultPageSize"></param>
        /// <returns></returns>
        public async Task<IEnumerable<VehicleSummaryDto>> GetPagedSummaryDoAsync(int baseIndex, int defaultPageSize)
        {
            IEnumerable<VehicleSummaryDto> pagedSummary = new List<VehicleSummaryDto>(); 
            var pager = new DataPager<VehicleSummaryDto>(SqlExecutor);
            var startIndex = (baseIndex == 0) ? 1 : baseIndex;
            NumberPage = await GetPageCount(defaultPageSize);
            try
            {
                pagedSummary =
                    await pager.GetPagedSummaryDoAsync(QueryType.QueryVehicleSummaryPaged, startIndex, defaultPageSize);
            } catch (System.Exception ex)
            {
                throw new DataLayerException(ex.Message, ex);
            }
                return pagedSummary;
        }
        public async Task<IEnumerable<VehicleSummaryDto>> GetSummaryAllAsync()
        {
            IEnumerable<VehicleSummaryDto> summary = new List<VehicleSummaryDto>();
            IQueryStore store = _queryStoreFactory.GetQueryStore(); 
            store.AddParam(QueryType.QueryVehicleSummary);
            var query = store.BuildQuery();
        
            using (IDbConnection connection = _sqlExecutor.OpenNewDbConnection())
            {
                summary = await connection.QueryAsync<VehicleSummaryDto>(query).ConfigureAwait(false);
            }
            return summary;
        }
        public async Task<IVehicleData> GetDoAsync(string code)
        {
            var vehicleData = await _dataLoader.LoadValueAsync(code).ConfigureAwait(false);
            return vehicleData;
        }
        public async Task<bool> SaveAsync(IVehicleData data)
        {
            var retValue = await _dataSaver.SaveAsync(data).ConfigureAwait(false);
            return retValue;
        }
        public IVehicleData GetNewDo(string value)
        {
            IVehicleData vehicle = new Vehicle();
            vehicle.Value = new VehicleDto();
            vehicle.Value.CODIINT = value;
            vehicle.Valid = true;
            return vehicle;
        }
        public async Task<bool> DeleteAsync(IVehicleData vehicleData)
        {
            var retValue = await _dataDeleter.DeleteAsync(vehicleData).ConfigureAwait(false);
            return retValue;
        }

        public string NewId()
        {
            using (IDbConnection connection = _sqlExecutor.OpenNewDbConnection())
            {
                VEHICULO1 veiculo = new VEHICULO1();
                var id = connection.UniqueId<VEHICULO1>(veiculo);
                return id;
            }
        }
    }
}