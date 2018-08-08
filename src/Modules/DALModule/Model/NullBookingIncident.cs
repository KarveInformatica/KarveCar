using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;
using System.Collections.Generic;

namespace DataAccessLayer.Model
{
    public class NullBookingIncident : IBookingIncidentData
    {
        public NullBookingIncident()
        {
            Valid = false;
        }
        /// <summary>
        ///  Set or Get the valid word.
        /// </summary>
        public bool Valid { set; get; }
        /// <summary>
        ///  Get or Set the Value.
        /// </summary>
        public BookingIncidentDto Value { get; set ; }
        /// <summary>
        ///  Get or Set the IncidentOfficeDto
        /// </summary>
        public IEnumerable<OfficeDtos> IncidentOfficeDto { get ; set; }
        /// <summary>
        ///  Get or Set the IncidentSupplierDto
        /// </summary>
        public IEnumerable<SupplierSummaryDto> IncidentSupplierDto { get ; set; }
        /// <summary>
        ///  Get or Set the IncidentVehicleDto
        /// </summary>
        public IEnumerable<VehicleSummaryDto> IncidentVehicleDto { get ; set; }
        /// <summary>
        ///  Get or Set the IncidentClientDto
        /// </summary>
        public IEnumerable<ClientSummaryExtended> IncidentClientDto { get ; set; }
        /// <summary>
        ///  Set or Get the IncidentTypeDto.
        /// </summary>
        public IEnumerable<IncidentTypeDto> IncidentTypeDto { get; set; }
    }
}
