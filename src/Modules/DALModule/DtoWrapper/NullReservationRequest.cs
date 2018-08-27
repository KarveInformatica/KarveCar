using System.Collections.Generic;
using KarveDataServices;
using KarveDataServices.ViewObjects;

namespace DataAccessLayer.DtoWrapper
{
    /// <summary>
    ///  Null reservatin request to be seen.
    /// </summary>
    internal class NullReservationRequest: IReservationRequest
    {
        public NullReservationRequest()
        {
        }
        public ReservationRequestViewObject Value { get => new ReservationRequestViewObject(); set => throw new System.NotImplementedException(); }
        public bool Valid { get => false; set => throw new System.NotImplementedException(); }
        public IEnumerable<ActividadViewObject> ActivityDto { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public IEnumerable<ClientTypeViewObject> ClientTypeDto { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public IEnumerable<CreditCardViewObject> CreditCardType { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public IEnumerable<OrigenViewObject> OrigenDto { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public IEnumerable<CommissionAgentSummaryViewObject> BrokerDto { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public IEnumerable<MarketViewObject> ClientMarketDto { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public IEnumerable<ResellerViewObject> ResellerDto { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public IEnumerable<CompanyViewObject> CompanyDto { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public IEnumerable<OfficeViewObject> OfficeDto { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public IEnumerable<BusinessViewObject> BusinessDto { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public IEnumerable<ChannelViewObject> ChannelDto { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public IEnumerable<BudgetKeyViewObject> BudgetKeyDto { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public IEnumerable<PaymentFormViewObject> ClientPaymentForm { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public IEnumerable<InvoiceBlockViewObject> InvoiceBlock { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public IEnumerable<RentingUseViewObject> RentUsageDto { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public IEnumerable<LanguageViewObject> LanguageDto { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public IEnumerable<ClientSummaryViewObject> DriversDto { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public IEnumerable<ContactsViewObject> ContactsDto { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public IEnumerable<ProvinceViewObject> ProvinciaDto { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public IEnumerable<CountryViewObject> CountryDto { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public IEnumerable<CityViewObject> CityDto { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public IEnumerable<ZonaOfiViewObject> ClientZoneDto { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public IEnumerable<ClientZoneViewObject> ZoneDto { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public IEnumerable<DelegaContableViewObject> ContableDelegaDto { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public IEnumerable<VehicleGroupViewObject> GroupDto { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public IEnumerable<ClientSummaryExtended> ClientDto { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public IEnumerable<FareViewObject> FareDto { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public IEnumerable<VehicleSummaryViewObject> VehicleDto { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public IEnumerable<OrigenViewObject> OriginDto { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public IEnumerable<RequestReasonViewObject> ResquestReasonDto { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    }
}