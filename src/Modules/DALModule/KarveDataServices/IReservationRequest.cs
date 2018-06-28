using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;
using System;
using System.Collections.Generic;

namespace KarveDataServices
{ 
    public interface IReservationRequest : IValidDomainObject
    {
         ReservationRequestDto Value { get ; set ; }
         IEnumerable<VehicleGroupDto> GroupDto { get; set ; }
         IEnumerable<ClientSummaryExtended> ClientDto { get ; set ; }
         IEnumerable<ResellerDto> ResellerDto { get ; set; }
         IEnumerable<FareDto> FareDto { get ; set; }
         IEnumerable<VehicleSummaryDto> VehicleDto { get; set ; }
        IEnumerable<CompanyDto> CompanyDto { get; set; }
        IEnumerable<OrigenDto> OriginDto { get; set; }
        IEnumerable<RequestReasonDto> ResquestReasonDto { get; set; }
        IEnumerable<OfficeDtos> OfficeDto { get; set; }
    }
}