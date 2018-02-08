using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using KarveDataServices;
using KarveDataServices.DataObjects;

namespace DataAccessLayer.MongoDB
{
    internal class VehicleMongoDBServices : IVehicleDataServices
    {
        private INoSqlExecutor _executor;

        public VehicleMongoDBServices(INoSqlExecutor executor)
        {
            _executor = executor;
        }

        public Task<DataSet> GetVehiclesAgentSummary(int pageSize, int offset)
        {
            throw new System.NotImplementedException();
        }

        public Task<DataSet> GetAsyncVehicleSummary()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> SaveVehicle(IVehicleData vehicleData)
        {
            throw new System.NotImplementedException();
        }

        public string GetNewId()
        {
            throw new System.NotImplementedException();
        }

        public Task<IVehicleData> GetVehicleDo(string primaryKeyValue)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteVehicleDo(IVehicleData vehicle)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteVehicleData(IVehicleData vehicleData)
        {
            throw new System.NotImplementedException();
        }

        public IVehicleData GetNewVehicleDo(string primaryKeyValue)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<IVehicleData>> GetAsyncVehicles()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> SaveChangesVehicle(IVehicleData data)
        {
            throw new System.NotImplementedException();
        }
    }
}