using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using KarveDataServices;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;

namespace KarveTest.Mock
{

    internal class MockVehicleDataService : IVehicleDataServices
    {
        public int NumberPage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public long NumberItems { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Task<bool> DeleteAsync(IVehicleData booking)
        {
            throw new NotImplementedException();
        }

        public Task<IVehicleData> GetDoAsync(string code)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IVehicleData>> GetListAsync(IList<IVehicleData> primaryKeys)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IVehicleData>> GetListAsync(IList<string> primaryKeys)
        {
            throw new NotImplementedException();
        }

        public IVehicleData GetNewDo(string value)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetPageCount(int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<VehicleSummaryDto>> GetPagedSummaryDoAsync(int index, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<VehicleSummaryDto>> GetSummaryAllAsync()
        {
            throw new NotImplementedException();
        }

        public string NewId()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveAsync(IVehicleData bookingData)
        {
            throw new NotImplementedException();
        }
    }
}