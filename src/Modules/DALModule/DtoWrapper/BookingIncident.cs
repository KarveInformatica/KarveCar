using KarveDataServices.DataObjects;
using KarveDataServices.ViewObjects;
using System.Collections.Generic;

namespace DataAccessLayer.DtoWrapper
{
    public class BookingIncident : IBookingIncidentData
    {
        public BookingIncident(BookingIncidentViewObject dto)
        {
            Value = dto;
        }
        public bool Valid { get ; set ; }
        public BookingIncidentViewObject Value { get; set; }

        /// <summary>
        ///  Set or Get the IncidentOfficeDto
        /// </summary>
        public IEnumerable<OfficeViewObject> IncidentOfficeDto { get ; set ; }
        /// <summary>
        ///  Set or Get the IncidentSupplierDto
        /// </summary>
        public IEnumerable<SupplierSummaryViewObject> IncidentSupplierDto { get; set; }
        /// <summary>
        ///  Set or Get the IncidentVehicleDto
        /// </summary>
        public IEnumerable<VehicleSummaryViewObject> IncidentVehicleDto { get ; set; }
        /// <summary>
        ///  Set or Get the IncidentClientDto
        /// </summary>
        public IEnumerable<ClientSummaryExtended> IncidentClientDto { get ; set; }
        /// <summary>
        ///  Set or Get the incident type dto.
        /// </summary>
        public IEnumerable<IncidentTypeViewObject> IncidentTypeDto { get; set ; }
    }
}
