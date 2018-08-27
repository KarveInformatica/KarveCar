using KarveDataServices.DataObjects;
using KarveDataServices.ViewObjects;
using System;
using System.Collections.Generic;

namespace KarveDataServices
{ 
    public interface IReservationRequest : IValidDomainObject
    {
         ReservationRequestViewObject Value { get ; set ; }
         IEnumerable<VehicleGroupViewObject> GroupDto { get; set ; }
         IEnumerable<ClientSummaryExtended> ClientDto { get ; set ; }
         IEnumerable<ResellerViewObject> ResellerDto { get ; set; }
         IEnumerable<FareViewObject> FareDto { get ; set; }
         IEnumerable<VehicleSummaryViewObject> VehicleDto { get; set ; }
        IEnumerable<CompanyViewObject> CompanyDto { get; set; }
        IEnumerable<OrigenViewObject> OriginDto { get; set; }
        IEnumerable<RequestReasonViewObject> ResquestReasonDto { get; set; }
        IEnumerable<OfficeViewObject> OfficeDto { get; set; }
    }
}