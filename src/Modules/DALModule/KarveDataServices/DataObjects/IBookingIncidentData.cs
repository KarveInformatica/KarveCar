using KarveDataServices.ViewObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataServices.DataObjects
{
    public interface IBookingIncidentData : IValidDomainObject, IValueObject<BookingIncidentViewObject>
    {
        IEnumerable<OfficeViewObject> IncidentOfficeDto { get; set; }
        IEnumerable<SupplierSummaryViewObject> IncidentSupplierDto { get; set; }
        IEnumerable<VehicleSummaryViewObject> IncidentVehicleDto { get; set; }
        IEnumerable<ClientSummaryExtended> IncidentClientDto { get; set; }
        IEnumerable<IncidentTypeViewObject> IncidentTypeDto { get; set; }
    }
}
