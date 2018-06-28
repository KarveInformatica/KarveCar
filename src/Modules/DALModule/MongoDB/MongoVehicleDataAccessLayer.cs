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

        public Task<bool> DeleteAsync(IVehicleData booking)
        {
            throw new System.NotImplementedException();
        }

        public Task<IVehicleData> GetDoAsync(string code)
        {
            throw new System.NotImplementedException();
        }

        public IVehicleData GetNewDo(string value)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> GetPageCount(int pageSize)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<VehicleSummaryDto>> GetPagedSummaryDoAsync(int index, int pageSize)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<VehicleSummaryDto>> GetSummaryAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public string NewId()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> SaveAsync(IVehicleData bookingData)
        {
            throw new System.NotImplementedException();
        }
    }
}