using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using DataAccessLayer.Model;
using DesignByContract;
using KarveCommon.Generic;
using KarveDataServices;
using KarveDataServices.DataObjects;

namespace DataAccessLayer
{
    /// <summary>
    /// This is an implementation of the data access layer for the data services.
    /// </summary>
    internal class VehiclesDataAccessLayer : AbstractDataAccessLayer, IVehicleDataServices
    {
        private readonly ISqlExecutor _sqlExecutor;
        private const string PrimaryKey = "CODIINT";
        private const string VehicleDataFile = @"\Data\VehicleFields.xml";
        private VehicleFactory _factory = null;
        /// <summary>
        /// VehicleDataAccessLayer class.
        /// </summary>
        /// <param name="sqlExecutor">Executor of the sql commands</param>
        public VehiclesDataAccessLayer(ISqlExecutor sqlExecutor): base(sqlExecutor)
        {
            _sqlExecutor = sqlExecutor;
            base.InitData(VehicleDataFile);
            _factory = VehicleFactory.GetFactory(_sqlExecutor);
        }

        /// <summary>
        ///  This returns a vehicle agent summary.
        /// </summary>
        /// <returns>Returns a data set for the vehicles</returns>
        public async Task<DataSet> GetAsyncVehicleSummary()
        {
            return await GetVehiclesAgentSummary(0, 0);

        }
        /// <summary>
        /// Get a paged version of the summary.
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public async Task<DataSet> GetVehiclesAgentSummary(int pageSize, int offset)
        {
            DataSet set = new DataSet();
            if (pageSize == 0)
            {
                set = await _sqlExecutor.AsyncDataSetLoad(GenericSql.VehiclesSummaryQuery);

            }
            else
            {
                string vehicles = string.Format(GenericSql.VehiclesSummaryQueryPaged, pageSize, offset);
                set = await _sqlExecutor.AsyncDataSetLoad(vehicles);
            }
            return set;

        }
        /// <summary>
        ///  Generate an unique id from the base class.
        /// </summary>
        /// <returns></returns>
        public string GetNewId()
        {
            return GenerateUniqueId();
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
            Dbc.Requires(!string.IsNullOrEmpty(vehicleId), "A valid id is needed");

            IDictionary<string, string> queries;
            if (queryDictionary == null)
            {
                queries = base.baseQueryDictionary;
            }
            else
            {
                queries = queryDictionary;
            }
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
        public async Task<IEnumerable<IVehicleData>> GetVehicleCollection(IDictionary<string, string> fields, int pageSize = 0, int startAt = 0)
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
            IDictionary<string, string> queries = base.baseQueryDictionary;  
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
            Dbc.Requires(data != null, "Cant save a null vehicle");
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
            Dbc.Requires(vehicleData != null, "Cant save a null vehicle");
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
            bool value = await vehicleData.DeleteAsyncData();
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
           bool saved = await data.SaveChanges();
           return saved;
        }
        /// <summary>
        /// Delete a vehicle 
        /// </summary>
        /// <param name="sqlQuery">Query to be executed for deleting a vehicle</param>
        /// <param name="vehicleId">Vehicle id to be included</param>
        /// <param name="set">DataSet to be included</param>
        /// <returns></returns>
        public bool DeleteVehicle(string sqlQuery, string vehicleId, DataSet set)
        {
            bool retValue = false;
            if (set == null)
            {
                return false;
            }
            retValue = DeleteData(sqlQuery, vehicleId, PrimaryKey, set);
            return retValue;
        }
        /// <summary>
        ///  This is get called from above.
        /// </summary>
        /// <param name="id">Identifier unique.</param>
        /// <returns></returns>
        protected override bool UniqueId(string id)
        {
            string str = "SELECT CODIINT FROM VEHICULO1 WHERE CODIINT='{0}'";
            str = string.Format(str, id);
            IDbConnection connection = _sqlExecutor.Connection;
            IEnumerable<string> strResult = connection.Query<string>(str);
            bool unique = (strResult.Distinct().Count() == 0);
            return unique;
           
        }

    }
}