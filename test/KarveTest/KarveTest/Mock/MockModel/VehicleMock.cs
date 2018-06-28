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
        public IEnumerable<OwnerDto> OwnerDtos { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IEnumerable<VehicleGroupDto> VehicleGroupDtos { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IEnumerable<MaintainanceDto> MaintenanceHistory { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string AssistModelQuery => throw new NotImplementedException();

        public IEnumerable<AgentDto> AgentsDto { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IEnumerable<ActividadDto> ActivityDtos { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IEnumerable<PictureDto> PicturesDtos { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IEnumerable<SupplierDto> Supplier1 { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IEnumerable<PaymentFormDto> PaymentForm { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IEnumerable<ClientSummaryExtended> ClientDto { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IEnumerable<ResellerDto> ResellerDto => throw new NotImplementedException();

        public IEnumerable<SupplierSummaryDto> Supplier2 { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IEnumerable<CityDto> RoadTaxesCityDto { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IEnumerable<ZonaOfiDto> RoadOfficeZoneDto { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IEnumerable<SupplierSummaryDto> AssistencePolicyDto { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IEnumerable<SupplierSummaryDto> AssistenceAssuranceDto { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IEnumerable<SupplierSummaryDto> AdditionalAssuranceDto { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IEnumerable<SupplierSummaryDto> AssuranceDto { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IEnumerable<AgentDto> AssuranceAgentDto { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        IEnumerable<SupplierSummaryDto> IVehicleData.Supplier1 { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        IEnumerable<ResellerDto> IVehicleData.ResellerDto { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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
