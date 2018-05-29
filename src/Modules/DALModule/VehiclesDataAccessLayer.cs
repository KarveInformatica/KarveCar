using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using DataAccessLayer.DataObjects;
using DataAccessLayer.Model;
using KarveCommon.Generic;
using KarveDataServices;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;
using DataAccessLayer.SQL;
using KarveDapper.Extensions;

namespace DataAccessLayer
{
    /*
     * Move to query store. 
     * Add incremental load 
     */
    /// <summary>
    /// This is an implementation of the data access layer for the data services.
    /// </summary>
    internal class VehiclesDataAccessLayer : AbstractDataAccessLayer, IVehicleDataServices
    {
        private readonly ISqlExecutor _sqlExecutor;
        private const string PrimaryKey = "CODIINT";
        private const string VehicleDataFile = @"\Data\VehicleFields.xml";
        private readonly VehicleFactory _factory = null;

        /// <summary>
        /// VehicleDataAccessLayer class.
        /// </summary>
        /// <param name="sqlExecutor">Executor of the sql commands</param>
        public VehiclesDataAccessLayer(ISqlExecutor sqlExecutor) : base(sqlExecutor)
        {
            _sqlExecutor = sqlExecutor;
            base.InitData(VehicleDataFile);
            _factory = VehicleFactory.GetFactory(_sqlExecutor);
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
            // TODO: Fix the usage of the query store.
            QueryStore store = new QueryStore();


           
            IEnumerable<VehicleSummaryDto> vehicles = null;
            string value = "";
            if (pageSize == 0)
            {
                store.AddParam(QueryType.QueryVehicleSummary);
                value = store.BuildQuery();
            }
            else
            {
                store.Clear();
                store.AddParamRange(QueryType.QueryVehicleSummaryPaged, pageSize, offset);
                var query = store.BuildQuery();

            }

            using (IDbConnection connection = _sqlExecutor.OpenNewDbConnection())
            {
                /*
                 *  Move to query store.
                 */
                vehicles = await connection.QueryAsync<VehicleSummaryDto>(GenericSql.VehiclesSummaryQuery);
            }

            return vehicles;
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
        ///  This return a new identifier for vehicle
        /// </summary>
        /// <returns></returns>
        public IVehicleData GetNewVehicleDo()
        {
            string identifier = GetNewId();
            IVehicleData dictionaryData = _factory.NewVehicle(identifier);
            return dictionaryData;
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

            // old method was too complicated.
            IVehicleData dictionaryData = await _factory.GetVehicle(queries, vehicleId);
            return dictionaryData;

        }



        /// <summary>
        /// Gives us a commission agent collection list
        /// </summary>
        /// <param name="fields">Fields to be present in the query</param>
        /// <param name="pageSize">Page dimension</param>
        /// <param name="startAt">Initialization of the object</param>
        /// <returns></returns>
        public async Task<IEnumerable<IVehicleData>> GetVehicleCollection(IDictionary<string, string> fields,
            int pageSize = 0, int startAt = 0)
        {
            IEnumerable<IVehicleData> vehicles = await _factory.CreateVehicleList(fields, pageSize, startAt);
            return vehicles;
        }

        /// <summary>
        ///  Fetch list of data objects for vehicles.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<IVehicleData>> GetAsyncVehicles()
        {
            var queries = base.BaseQueryDictionary;
            IEnumerable<IVehicleData> vehicleDatas = await _factory.CreateVehicleList(queries, 0, 0);
            return vehicleDatas;
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
            return await GetVehicleDo(primaryKeyValue, null);
        }

        /// <summary>
        /// Delete vehicle data.
        /// </summary>
        /// <param name="vehicleData">Delete a vehicle agent saved.</param>
        /// <returns></returns>
        public async Task<bool> DeleteVehicleDo(IVehicleData vehicleData)
        {
            var value = await vehicleData.DeleteAsyncData();
            return value;
        }

        /// <summary>
        ///  This gives to us a vehicle data object from the factory
        /// </summary>
        /// <param name="primaryKeyValue"></param>
        /// <returns></returns>
        public IVehicleData GetNewVehicleDo(string primaryKeyValue)
        {
            return _factory.NewVehicle(primaryKeyValue);
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
            var pager = new DataPager<VehicleSummaryDto>(SqlExecutor);
            var startIndex = (baseIndex == 0) ? 1 : defaultPageSize;
            NumberPage = await GetPageCount(defaultPageSize);
            var pagedSummary =
                await pager.GetPagedSummaryDoAsync(QueryType.QueryVehicleSummaryPaged, startIndex, defaultPageSize);
            return pagedSummary;

        }
    }
}