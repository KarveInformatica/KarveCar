using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using KarveDataServices.ViewObjects;

namespace KarveDataServices.DataObjects
{
    /// <summary>
    ///  This inteface specifies the interface to a model wrapper 
    ///  that allows to write, save, load all the entities related 
    ///  to a model domain element.
    ///  In this case the vehicle. 
    /// </summary>
    public interface IVehicleData: IValidDomainObject, IValueObject<VehicleViewObject>
    {
        /// <summary>
        ///  This delete all data in async way 
        /// </summary>
        /// <returns></returns>
        Task<bool> DeleteAsyncData();
        /// <summary>
        /// Save the vehicle data.
        /// </summary>
        /// <returns></returns>
        Task<bool> Save();
        /// <summary>
        ///  Save all updates in the vehicle
        /// </summary>
        /// <returns></returns>
        Task<bool> SaveChanges();
        /// <summary>
        /// Load valed
        /// </summary>
        /// <param name="fields">Dictionary of the fields</param>
        /// <param name="cCodiint">Vehicle code primary key</param>
        /// <returns></returns>
        Task<bool> LoadValue(IDictionary<string, string> fields, string cCodiint);
     
        /// <summary>
        //  Brand data trasnfer object. Usually a vehicle has just one brand.
        /// </summary>
        IEnumerable<BrandVehicleViewObject> BrandDtos { get; set; }
        /// <summary>
        /// Model data transfer object. Usually a vehicle has just one model/
        /// </summary>
        IEnumerable<ModelVehicleViewObject> ModelDtos { get; set; }
        /// <summary>
        ///  Color data transfer object.
        /// </summary>
        IEnumerable<ColorViewObject> ColorDtos { get; set; }
        /// <summary>
        ///  Color data transfer object.
        /// </summary>
        IEnumerable<OwnerViewObject> OwnerDtos { get; set; }
        /// <summary>
        ///  Vehicle group viewObject.
        /// </summary>
        IEnumerable<VehicleGroupViewObject> VehicleGroupDtos { get; set; }
        /// <summary>
        ///  History of the maintenance of the vehicle.
        /// </summary>
        IEnumerable<MaintainanceViewObject> MaintenanceHistory { get; set; }
        /// <summary>
        ///  Query of the model.
        /// </summary>
        string AssistModelQuery { get; }

        /// <summary>
        ///  Agents viewObject
        /// </summary>
        IEnumerable<AgentViewObject> AgentsDto { get; set; }
        /// <summary>
        ///  Activities viewObject.
        /// </summary>
        IEnumerable<VehicleActivitiesViewObject> ActivityDtos { get; set; }
        IEnumerable<PictureDto> PicturesDtos { get; set; }
        IEnumerable<SupplierSummaryViewObject> Supplier1 { get; set; }
        IEnumerable<PaymentFormViewObject> PaymentForm { get; set; }
        IEnumerable<ClientSummaryExtended> ClientDto { get; set; }
        IEnumerable<ResellerViewObject> ResellerDto { get; set; }
        IEnumerable<SupplierSummaryViewObject> Supplier2 { get; set; }
        IEnumerable<CityViewObject> RoadTaxesCityDto { get; set; }
        IEnumerable<ZonaOfiViewObject> RoadOfficeZoneDto { get; set; }
        IEnumerable<SupplierSummaryViewObject> AssistencePolicyDto { get; set; }
        IEnumerable<SupplierSummaryViewObject> AssistenceAssuranceDto { get; set; }
        IEnumerable<SupplierSummaryViewObject> AdditionalAssuranceDto { get; set; }
        IEnumerable<SupplierSummaryViewObject> AssuranceDto { get; set; }
        IEnumerable<AgentViewObject> AssuranceAgentDto { get; set; }
    }
}