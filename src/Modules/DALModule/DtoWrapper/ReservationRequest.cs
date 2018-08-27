using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveDataServices.ViewObjects;
using KarveDataServices;

namespace DataAccessLayer.DtoWrapper
{
    /// <summary>
    ///  Domain model for the reservation request
    /// </summary>
    public class ReservationRequest : IReservationRequest
    {
        private ReservationRequestViewObject _viewObject;
        private bool _valid;
        private IEnumerable<VehicleGroupViewObject> _group;
        private IEnumerable<ClientSummaryExtended> _client;
        private IEnumerable<ResellerViewObject> _reseller;
        private IEnumerable<FareViewObject> _fare;
        private IEnumerable<VehicleSummaryViewObject> _vehicleSummary;
        private IEnumerable<CompanyViewObject> _companyDto;
        private IEnumerable<OrigenViewObject> _origenDto;
        private IEnumerable<RequestReasonViewObject> _requestReasonDto;
        private IEnumerable<OfficeViewObject> _office;

        public ReservationRequest(ReservationRequestViewObject viewObject)
        {
            this._viewObject = viewObject;
            this._group = new List<VehicleGroupViewObject>();
            this._client = new List<ClientSummaryExtended>();
            this._reseller = new List<ResellerViewObject>();
            this._fare = new List<FareViewObject>();
            this._vehicleSummary = new List<VehicleSummaryViewObject>();
        }
        public ReservationRequestViewObject Value { get => _viewObject; set => _viewObject = value; }
        public bool Valid { get => _valid; set => _valid = value; }
        public IEnumerable<VehicleGroupViewObject> GroupDto { get => _group; set => _group = value; }
        public IEnumerable<ClientSummaryExtended> ClientDto { get => _client; set => _client = value; }
        public IEnumerable<ResellerViewObject> ResellerDto { get => _reseller; set => _reseller = value; }
        public IEnumerable<FareViewObject> FareDto { get => _fare; set => _fare = value; }
        public IEnumerable<VehicleSummaryViewObject> VehicleDto { get => _vehicleSummary; set => _vehicleSummary = value; }
        public IEnumerable<CompanyViewObject> CompanyDto { get => _companyDto; set => _companyDto = value; }
        public IEnumerable<OrigenViewObject> OriginDto { get => _origenDto; set => _origenDto =value; }
        public IEnumerable<RequestReasonViewObject> ResquestReasonDto { get => _requestReasonDto; set => _requestReasonDto = value; }
        public IEnumerable<OfficeViewObject> OfficeDto { get => _office; set => _office = value; }
    }
}
