using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using KarveDataServices.DataTransferObject;

namespace KarveDataServices.DataObjects
{
    /// <summary>
    ///  This inteface specifies the interface to a model wrapper 
    ///  that allows to write, save, load all the entities related 
    ///  to a model domain element.
    ///  In this case the vehicle. 
    /// </summary>
    public interface IVehicleData
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
        /// Vehicle Entity properties. 
        /// This hides all the entity of the model inside a VehicleDto.
        /// </summary>
        VehicleDto Value { set; get; }
        /// <summary>
        ///  This tells us if the data is valid or not.
        /// </summary>
        bool Valid { get; set; }
        /// <summary>
        //  Brand data trasnfer object. Usually a vehicle has just one brand.
        /// </summary>
        IEnumerable<BrandVehicleDto> BrandDtos { get; set; }
        /// <summary>
        /// Model data transfer object. Usually a vehicle has just one model/
        /// </summary>
        IEnumerable<ModelVehicleDto> ModelDtos { get; set; }
        /// <summary>
        ///  Color data transfer object.
        /// </summary>
        IEnumerable<ColorDto> ColorDtos { get; set; }
        /// <summary>
        ///  Color data transfer object.
        /// </summary>
        IEnumerable<OwnerDto> OwnerDtos { get; set; }
        /// <summary>
        ///  Vehicle group dto.
        /// </summary>
        IEnumerable<VehicleGroupDto> VehicleGroupDtos { get; set; }
        /// <summary>
        ///  History of the maintenance of the vehicle.
        /// </summary>
        IEnumerable<MaintainanceDto> MaintenanceHistory { get; set; }
        /// <summary>
        ///  Query of the model.
        /// </summary>
        string AssistModelQuery { get; }

        /// <summary>
        ///  Agents dto
        /// </summary>
        IEnumerable<AgentDto> AgentsDto { get; set; }
        /// <summary>
        ///  Activities dto.
        /// </summary>
        IEnumerable<ActividadDto> ActivityDtos { get; set; }
        IEnumerable<PictureDto> PicturesDtos { get; set; }
        IEnumerable<SupplierSummaryDto> Supplier1 { get; set; }
        IEnumerable<PaymentFormDto> PaymentForm { get; set; }
        IEnumerable<ClientSummaryExtended> ClientDto { get; set; }
        IEnumerable<ResellerDto> ResellerDto { get; set; }
        IEnumerable<SupplierSummaryDto> Supplier2 { get; set; }
        IEnumerable<CityDto> RoadTaxesCityDto { get; set; }
        IEnumerable<ZonaOfiDto> RoadOfficeZoneDto { get; set; }
        IEnumerable<SupplierSummaryDto> AssistencePolicyDto { get; set; }
        IEnumerable<SupplierSummaryDto> AssistenceAssuranceDto { get; set; }
        IEnumerable<SupplierSummaryDto> AdditionalAssuranceDto { get; set; }
        IEnumerable<SupplierSummaryDto> AssuranceDto { get; set; }
        IEnumerable<AgentDto> AssuranceAgentDto { get; set; }
    }
}