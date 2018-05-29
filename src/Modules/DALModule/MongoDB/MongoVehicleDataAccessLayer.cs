using System.Collections.Generic;
using System.Threading.Tasks;
using KarveDataServices;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;

namespace DataAccessLayer.MongoDB
{
    internal class MongoVehicleDataAccessLayer : IVehicleDataServices
    {
        public int NumberPage { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public long NumberItems { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public Task<bool> DeleteVehicleData(IVehicleData vehicleData)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteVehicleDo(IVehicleData vehicle)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<IVehicleData>> GetAsyncVehicles()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<VehicleSummaryDto>> GetAsyncVehicleSummary()
        {
            throw new System.NotImplementedException();
        }

        public string GetNewId()
        {
            throw new System.NotImplementedException();
        }

        public IVehicleData GetNewVehicleDo(string primaryKeyValue)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> GetPageCount(int pageSize)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<VehicleSummaryDto>> GetPagedSummaryDoAsync(int baseIndex, int defaultPageSize)
        {
            throw new System.NotImplementedException();
        }

        public Task<IVehicleData> GetVehicleDo(string primaryKeyValue)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<VehicleSummaryDto>> GetVehiclesAgentSummary(int pageSize, int offset)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> SaveChangesVehicle(IVehicleData data)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> SaveVehicle(IVehicleData vehicleData)
        {
            throw new System.NotImplementedException();
        }
    }
}