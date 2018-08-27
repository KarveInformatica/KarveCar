using System.Collections.Generic;
using KarveDataServices.DataObjects;
using KarveDataServices.ViewObjects;
using NLog;


namespace DataAccessLayer.DtoWrapper
{
    public class ClientFactory
    {
        /// <summary>
        ///  Create a client wrapper from a data transfer object.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        static IClientData CreateClient(ClientViewObject dto)
        {
           var value = new Client(dto);
           return value;
        }
    }
    /// <summary>
    ///  Wrapper of the domain object for the client.
    ///  It contains the ClientDto in the Value.
    /// </summary>
    public class Client : DomainObject, IClientData
    {
        private ClientViewObject _dto; 
        protected Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        ///  Helpper setter and getter.
        /// </summary>
        public IEnumerable<ActividadViewObject> ActivityDto { get; set; }
        public IEnumerable<ClientTypeViewObject> ClientTypeDto { get; set; }
        public IEnumerable<CreditCardViewObject> CreditCardType { get; set; }
        public IEnumerable<ProvinceViewObject> ProvinciaDto { get; set; }
        public IEnumerable<CountryViewObject> CountryDto { get; set; }
        public IEnumerable<CityViewObject> CityDto { get; set; }
        public IEnumerable<ClientZoneViewObject> ZoneDto { get; set; }
        public IEnumerable<DelegaContableViewObject> ContableDelegaDto { get; set; }
        public IEnumerable<OrigenViewObject> OrigenDto { get; set; }
        public IEnumerable<CommissionAgentSummaryViewObject> BrokerDto { get; set; }
        public IEnumerable<MarketViewObject> ClientMarketDto { get; set; }
        public IEnumerable<ResellerViewObject> ResellerDto { get; set; }
        public IEnumerable<CompanyViewObject> CompanyDto { get; set; }
        public IEnumerable<OfficeViewObject> OfficeDto { get; set; }
        public IEnumerable<BusinessViewObject> BusinessDto { get; set; }
        public IEnumerable<ChannelViewObject> ChannelDto { get; set; }
        public IEnumerable<BudgetKeyViewObject> BudgetKeyDto { get; set; }
        public IEnumerable<PaymentFormViewObject> ClientPaymentForm { get; set; }
        public IEnumerable<InvoiceBlockViewObject> InvoiceBlock { get; set; }
        public IEnumerable<RentingUseViewObject> RentUsageDto { get; set; }
        public IEnumerable<LanguageViewObject> LanguageDto { get; set; }
        public IEnumerable<ClientSummaryViewObject> DriversDto { get; set; }
        public IEnumerable<ContactsViewObject> ContactsDto { get; set; }
        public IEnumerable<InvoiceViewObject> InvoiceFare { get; set; }
        public IEnumerable<ZonaOfiViewObject> ClientZoneDto { get; set; }

        /// <summary>
        ///  Value of the client data trasnfer object.
        /// </summary>

        public ClientViewObject Value
        {
            get
            {
                return _dto;
            }
            set
            {
                _dto = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        /// Constructor of the client
        /// </summary>
        /// <param name="dto">Data object of the client</param>
        public Client(ClientViewObject dto)
        {
            _dto = dto;
            Code = dto.NUMERO_CLI;
            Valid = true;
        }

    }
}
