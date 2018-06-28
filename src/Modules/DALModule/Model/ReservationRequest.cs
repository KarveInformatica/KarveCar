using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveDataServices.DataTransferObject;
using KarveDataServices;

namespace DataAccessLayer.Model
{
    /// <summary>
    ///  Domain model for the reservation request
    /// </summary>
    public class ReservationRequest : IReservationRequest
    {
        private ReservationRequestDto _dto;
        private bool _valid;
        private IEnumerable<VehicleGroupDto> _group;
        private IEnumerable<ClientSummaryExtended> _client;
        private IEnumerable<ResellerDto> _reseller;
        private IEnumerable<FareDto> _fare;
        private IEnumerable<VehicleSummaryDto> _vehicleSummary;
        private IEnumerable<CompanyDto> _companyDto;
        private IEnumerable<OrigenDto> _origenDto;
        private IEnumerable<RequestReasonDto> _requestReasonDto;
        private IEnumerable<OfficeDtos> _office;

        public ReservationRequest(ReservationRequestDto dto)
        {
            this._dto = dto;
            this._group = new List<VehicleGroupDto>();
            this._client = new List<ClientSummaryExtended>();
            this._reseller = new List<ResellerDto>();
            this._fare = new List<FareDto>();
            this._vehicleSummary = new List<VehicleSummaryDto>();
        }
        public ReservationRequestDto Value { get => _dto; set => _dto = value; }
        public bool Valid { get => _valid; set => _valid = value; }
        public IEnumerable<VehicleGroupDto> GroupDto { get => _group; set => _group = value; }
        public IEnumerable<ClientSummaryExtended> ClientDto { get => _client; set => _client = value; }
        public IEnumerable<ResellerDto> ResellerDto { get => _reseller; set => _reseller = value; }
        public IEnumerable<FareDto> FareDto { get => _fare; set => _fare = value; }
        public IEnumerable<VehicleSummaryDto> VehicleDto { get => _vehicleSummary; set => _vehicleSummary = value; }
        public IEnumerable<CompanyDto> CompanyDto { get => _companyDto; set => _companyDto = value; }
        public IEnumerable<OrigenDto> OriginDto { get => _origenDto; set => _origenDto =value; }
        public IEnumerable<RequestReasonDto> ResquestReasonDto { get => _requestReasonDto; set => _requestReasonDto = value; }
        public IEnumerable<OfficeDtos> OfficeDto { get => _office; set => _office = value; }
    }
}
