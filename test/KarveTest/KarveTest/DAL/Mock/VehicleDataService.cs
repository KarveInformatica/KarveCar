using KarveDataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveDataServices.DataObjects;
using System.Data;

namespace KarveTest.DAL.Mock
{
    class VehicleDataService : IVehicleDataServices
    {
        private IList<IVehicleData> dataVehicles = new List<IVehicleData>();
        
        public Task<bool> DeleteVehicleData(IVehicleData vehicleData)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteVehicleDo(IVehicleData vehicle)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IVehicleData>> GetAsyncVehicles()
        {
            throw new NotImplementedException();
        }

        public Task<DataSet> GetAsyncVehicleSummary()
        {
            throw new NotImplementedException();
        }

        public string GetNewId()
        {
            throw new NotImplementedException();
        }

        public IVehicleData GetNewVehicleDo(string primaryKeyValue)
        {
            throw new NotImplementedException();
        }

        public Task<IVehicleData> GetVehicleDo(string primaryKeyValue)
        {
            throw new NotImplementedException();
        }

        public Task<DataSet> GetVehiclesAgentSummary(int pageSize, int offset)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChangesVehicle(IVehicleData data)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveVehicle(IVehicleData vehicleData)
        {
            throw new NotImplementedException();
        }
    }
}
