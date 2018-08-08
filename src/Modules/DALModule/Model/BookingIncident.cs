using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;
using System.Collections.Generic;

namespace DataAccessLayer.Model
{
    public class BookingIncident : IBookingIncidentData
    {
        private BookingIncidentDto _bookingIncidentDto;
        public BookingIncident(BookingIncidentDto dto)
        {
            _bookingIncidentDto = dto;
        }
        public bool Valid { get ; set ; }
        public BookingIncidentDto Value
        {   get
            {
                return _bookingIncidentDto;
            }
            set
            {
                _bookingIncidentDto = value;
            }
        }
        /// <summary>
        ///  Set or Get the IncidentOfficeDto
        /// </summary>
        public IEnumerable<OfficeDtos> IncidentOfficeDto { get ; set ; }
        /// <summary>
        ///  Set or Get the IncidentSupplierDto
        /// </summary>
        public IEnumerable<SupplierSummaryDto> IncidentSupplierDto { get; set; }
        /// <summary>
        ///  Set or Get the IncidentVehicleDto
        /// </summary>
        public IEnumerable<VehicleSummaryDto> IncidentVehicleDto { get ; set; }
        /// <summary>
        ///  Set or Get the IncidentClientDto
        /// </summary>
        public IEnumerable<ClientSummaryExtended> IncidentClientDto { get ; set; }
        /// <summary>
        ///  Set or Get the incident type dto.
        /// </summary>
        public IEnumerable<IncidentTypeDto> IncidentTypeDto { get; set ; }
    }
}
