using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using KarveCommon.Generic;
using KarveDataServices;

namespace DataAccessLayer
{
    /// <summary>
    /// This is an implementation of the data access layer for the data services.
    /// </summary>
    internal class VehiclesDataAccessLayer : IVehicleDataServices
    {
        private readonly ISqlQueryExecutor _sqlQueryExecutor;

        internal VehiclesDataAccessLayer(ISqlQueryExecutor sqlQueryExecutor)
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
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<DataSet> GetVehiclesAgentSummary(int pageSize = 0)
        {
            DataSet set = new DataSet();
            if (pageSize == 0)
            {
                set = await _sqlQueryExecutor.AsyncDataSetLoad(GenericSql.VehiclesSummaryQuery);

            }
            return set;
            
        }

    }
}