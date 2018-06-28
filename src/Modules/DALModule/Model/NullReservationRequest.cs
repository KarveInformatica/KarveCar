using System.Collections.Generic;
using KarveDataServices;
using KarveDataServices.DataTransferObject;

namespace DataAccessLayer.Model
{
    /// <summary>
    ///  Null reservatin request to be seen.
    /// </summary>
    internal class NullReservationRequest: IReservationRequest
    {
        public NullReservationRequest()
        {
        }
        public ReservationRequestDto Value { get => new ReservationRequestDto(); set => throw new System.NotImplementedException(); }
        public bool Valid { get => false; set => throw new System.NotImplementedException(); }
        public IEnumerable<ActividadDto> ActivityDto { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public IEnumerable<ClientTypeDto> ClientTypeDto { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public IEnumerable<CreditCardDto> CreditCardType { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public IEnumerable<OrigenDto> OrigenDto { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public IEnumerable<CommissionAgentSummaryDto> BrokerDto { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public IEnumerable<MercadoDto> ClientMarketDto { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public IEnumerable<ResellerDto> ResellerDto { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public IEnumerable<CompanyDto> CompanyDto { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public IEnumerable<OfficeDtos> OfficeDto { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public IEnumerable<BusinessDto> BusinessDto { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public IEnumerable<ChannelDto> ChannelDto { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public IEnumerable<BudgetKeyDto> BudgetKeyDto { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public IEnumerable<PaymentFormDto> ClientPaymentForm { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public IEnumerable<InvoiceBlockDto> InvoiceBlock { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public IEnumerable<RentingUseDto> RentUsageDto { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public IEnumerable<LanguageDto> LanguageDto { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public IEnumerable<ClientSummaryDto> DriversDto { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public IEnumerable<ContactsDto> ContactsDto { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public IEnumerable<ProvinciaDto> ProvinciaDto { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public IEnumerable<CountryDto> CountryDto { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public IEnumerable<CityDto> CityDto { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public IEnumerable<ZonaOfiDto> ClientZoneDto { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public IEnumerable<ClientZoneDto> ZoneDto { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public IEnumerable<DelegaContableDto> ContableDelegaDto { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public IEnumerable<VehicleGroupDto> GroupDto { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public IEnumerable<ClientSummaryExtended> ClientDto { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public IEnumerable<FareDto> FareDto { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public IEnumerable<VehicleSummaryDto> VehicleDto { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public IEnumerable<OrigenDto> OriginDto { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public IEnumerable<RequestReasonDto> ResquestReasonDto { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    }
}