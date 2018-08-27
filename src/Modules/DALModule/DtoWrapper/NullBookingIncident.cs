using KarveDataServices.DataObjects;
using KarveDataServices.ViewObjects;
using System.Collections.Generic;

namespace DataAccessLayer.DtoWrapper
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
        public BookingIncidentViewObject Value { get; set ; }
        /// <summary>
        ///  Get or Set the IncidentOfficeDto
        /// </summary>
        public IEnumerable<OfficeViewObject> IncidentOfficeDto { get ; set; }
        /// <summary>
        ///  Get or Set the IncidentSupplierDto
        /// </summary>
        public IEnumerable<SupplierSummaryViewObject> IncidentSupplierDto { get ; set; }
        /// <summary>
        ///  Get or Set the IncidentVehicleDto
        /// </summary>
        public IEnumerable<VehicleSummaryViewObject> IncidentVehicleDto { get ; set; }
        /// <summary>
        ///  Get or Set the IncidentClientDto
        /// </summary>
        public IEnumerable<ClientSummaryExtended> IncidentClientDto { get ; set; }
        /// <summary>
        ///  Set or Get the IncidentTypeDto.
        /// </summary>
        public IEnumerable<IncidentTypeViewObject> IncidentTypeDto { get; set; }
    }
}
