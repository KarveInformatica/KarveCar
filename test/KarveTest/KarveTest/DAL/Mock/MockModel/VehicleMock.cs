using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;

namespace KarveTest.DAL.Mock.MockModel
{
    class VehicleMock : IVehicleData
    {
        public VehicleDto Value { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool Valid { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IEnumerable<BrandVehicleDto> BrandDtos { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IEnumerable<ModelVehicleDto> ModelDtos { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IEnumerable<ColorDto> ColorDtos { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IEnumerable<VehicleGroupDto> VehicleGroupDtos { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IEnumerable<MaintainanceDto> MaintenanceHistory { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string AssistModelQuery => throw new NotImplementedException();

        public Task<bool> DeleteAsyncData()
        {
            throw new NotImplementedException();
        }

        public Task<bool> LoadValue(IDictionary<string, string> fields, string cCodiint)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Save()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
