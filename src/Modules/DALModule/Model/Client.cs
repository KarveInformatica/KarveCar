using System.Collections.Generic;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;
using NLog;


namespace DataAccessLayer.Model
{

    public class ClientFactory
    {
        /// <summary>
        ///  Create a client wrapper from a data transfer object.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        static IClientData CreateClient(ClientDto dto)
        {
           var value = new Client();
           value.Value = dto;
           return value;
        }
    }
    /// <summary>
    ///  Wrapper of the domain object for the client.
    ///  It is useful for detecting changes and working with client related tables. 
    /// </summary>
    public class Client : DomainObject, IClientData
    {
        protected Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        ///  Helpper setter and getter.
        /// </summary>
        public IEnumerable<ActividadDto> ActivityDto { get; set; }
        public IEnumerable<ClientTypeDto> ClientTypeDto { get; set; }
        public IEnumerable<CreditCardDto> CreditCardType { get; set; }
        public IEnumerable<ProvinciaDto> ProvinciaDto { get; set; }
        public IEnumerable<CountryDto> CountryDto { get; set; }
        public IEnumerable<CityDto> CityDto { get; set; }
        public IEnumerable<ClientZoneDto> ZoneDto { get; set; }
        public IEnumerable<DelegaContableDto> ContableDelegaDto { get; set; }
        public IEnumerable<OrigenDto> OrigenDto { get; set; }
        public IEnumerable<CommissionAgentSummaryDto> BrokerDto { get; set; }
        public IEnumerable<MercadoDto> ClientMarketDto { get; set; }
        public IEnumerable<ResellerDto> ResellerDto { get; set; }
        public IEnumerable<CompanyDto> CompanyDto { get; set; }
        public IEnumerable<OfficeDtos> OfficeDto { get; set; }
        public IEnumerable<BusinessDto> BusinessDto { get; set; }
        public IEnumerable<ChannelDto> ChannelDto { get; set; }
        public IEnumerable<BudgetKeyDto> BudgetKeyDto { get; set; }
        public IEnumerable<PaymentFormDto> ClientPaymentForm { get; set; }
        public IEnumerable<InvoiceBlockDto> InvoiceBlock { get; set; }
        public IEnumerable<RentingUseDto> RentUsageDto { get; set; }
        public IEnumerable<LanguageDto> LanguageDto { get; set; }
        public IEnumerable<ClientSummaryDto> DriversDto { get; set; }
        public IEnumerable<ContactsDto> ContactsDto { get; set; }
        public IEnumerable<InvoiceFareDto> InvoiceFare { get; set; }
        /// <summary>
        ///  Value of the client data trasnfer object.
        /// </summary>
        public ClientDto Value { get; set; }
        
        public IEnumerable<ZonaOfiDto> ClientZoneDto { get; set; }
    }
}
