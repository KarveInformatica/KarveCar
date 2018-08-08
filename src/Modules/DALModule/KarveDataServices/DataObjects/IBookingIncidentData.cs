using KarveDataServices.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataServices.DataObjects
{
    public interface IBookingIncidentData : IValidDomainObject, IValueObject<BookingIncidentDto>
    {
        IEnumerable<OfficeDtos> IncidentOfficeDto { get; set; }
        IEnumerable<SupplierSummaryDto> IncidentSupplierDto { get; set; }
        IEnumerable<VehicleSummaryDto> IncidentVehicleDto { get; set; }
        IEnumerable<ClientSummaryExtended> IncidentClientDto { get; set; }
        IEnumerable<IncidentTypeDto> IncidentTypeDto { get; set; }
    }
}
