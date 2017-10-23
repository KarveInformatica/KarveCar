using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Transactions;
using DataAccessLayer.DataObjects;
using KarveCommon.Generic;
using KarveDataServices;
using KarveDataServices.DataObjects;

namespace DataAccessLayer
{
    /// <summary>
    /// This is an implementation of the data access layer for the data services.
    /// </summary>
    public class VehiclesDataAccessLayer : AbstractDataAccessLayer, IVehicleDataServices
    {
        private readonly ISqlQueryExecutor _sqlQueryExecutor;
        private const string PrimaryKey = "CODIINT";
        /// <summary>
        /// VehicleDataAccessLayer class.
        /// </summary>
        /// <param name="sqlQueryExecutor">Executor of the sql commands</param>
        public VehiclesDataAccessLayer(ISqlQueryExecutor sqlQueryExecutor): base(sqlQueryExecutor)
        {
            _sqlQueryExecutor = sqlQueryExecutor;
        }

        public IList<IVehicleData> GetVehicleDatas()
        {
            IList<IVehicleData> vehicleDatas = new List<IVehicleData>();
            return vehicleDatas;
        }
        /// <summary>
        ///  This is  
        /// </summary>
        /// <param name="pageSize">Dimension of the page</param>
        /// <param name="offset">Offset of the vehicle</param>
        /// <returns></returns>
        public async Task<DataSet> GetVehiclesAgentSummary(int pageSize = 0, int offset =0)
        {
            DataSet set = new DataSet();
            using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                if (pageSize == 0)
                {
                    set = await _sqlQueryExecutor.AsyncDataSetLoad(GenericSql.VehiclesSummaryQuery);

                }
                else
                {
                    string vehicles = string.Format(GenericSql.VehiclesSummaryQueryPaged, pageSize, offset);
                    set = await _sqlQueryExecutor.AsyncDataSetLoad(vehicles);
                }
            }
            return set;
        }
        /// <summary>
        /// This saves the changes.
        /// </summary>
        /// <param name="data">Vehicle data to be saved</param>
        /// <returns></returns>
        public async Task<bool> SaveChanges(IVehicleData data)
        {

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
            bool changedTask = await vehicleData.Save();
            return changedTask;
        }
        /// <summary>
        /// This returns the dataset for a vehicle.
        /// </summary>
        /// <param name="queryList">List of queries associated with the vehicle</param>
        /// <returns></returns>
        public async Task<IDataWrapper<IVehicleData>> GetAsyncVehicleInfo(IDictionary<string, string> queryList)
        {
            DataSet summary = await _sqlQueryExecutor.AsyncDataSetLoadBatch(queryList);
            IDataWrapper<IVehicleData> data = new DataWrapper<IVehicleData>();
            data.HasDataSet = true;
            data.Set = summary;
            return data;
        }

        /// <summary>
        /// Delete vehicle data.
        /// </summary>
        /// <param name="vehicleData">Commission agent saved.</param>
        /// <returns></returns>
        public async Task<bool> DeleteVehicleData(IVehicleData vehicleData)
        {
            bool value = false;
            IDbConnection connection = _sqlQueryExecutor.Connection;
            using (connection)
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                value = await vehicleData.DeleteAsyncData();
            }
            return value;
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
    }
}