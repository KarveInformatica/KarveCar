using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveDataServices.DataObjects;
using KarveDataServices.ViewObjects;

namespace KarveTest.DAL.Mock.MockModel
{
    class VehicleMock : IVehicleData
    {
        public VehicleViewObject Value { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool Valid { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IEnumerable<BrandVehicleViewObject> BrandDtos { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IEnumerable<ModelVehicleViewObject> ModelDtos { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IEnumerable<ColorViewObject> ColorDtos { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IEnumerable<OwnerViewObject> OwnerDtos { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IEnumerable<VehicleGroupViewObject> VehicleGroupDtos { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IEnumerable<MaintainanceViewObject> MaintenanceHistory { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string AssistModelQuery => throw new NotImplementedException();

        public IEnumerable<AgentViewObject> AgentsDto { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IEnumerable<VehicleActivitiesViewObject> ActivityDtos { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IEnumerable<PictureDto> PicturesDtos { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IEnumerable<SupplierViewObject> Supplier1 { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IEnumerable<PaymentFormViewObject> PaymentForm { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IEnumerable<ClientSummaryExtended> ClientDto { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IEnumerable<ResellerViewObject> ResellerDto => throw new NotImplementedException();

        public IEnumerable<SupplierSummaryViewObject> Supplier2 { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IEnumerable<CityViewObject> RoadTaxesCityDto { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IEnumerable<ZonaOfiViewObject> RoadOfficeZoneDto { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IEnumerable<SupplierSummaryViewObject> AssistencePolicyDto { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IEnumerable<SupplierSummaryViewObject> AssistenceAssuranceDto { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IEnumerable<SupplierSummaryViewObject> AdditionalAssuranceDto { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IEnumerable<SupplierSummaryViewObject> AssuranceDto { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IEnumerable<AgentViewObject> AssuranceAgentDto { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        IEnumerable<SupplierSummaryViewObject> IVehicleData.Supplier1 { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        IEnumerable<ResellerViewObject> IVehicleData.ResellerDto { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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
