using KarveDataServices.DataObjects;
using System.Threading.Tasks;
using KarveDataServices.DataTransferObject;
using System.Collections.Generic;
using KarveDataServices;

namespace DataAccessLayer.Model
{
    /// <summary>
    ///  Null client is an empty object.
    /// </summary>
    public class NullClient : DomainObject, IClientData
    {
       private ClientDto _clientDto = new ClientDto();
        /// <summary>
        ///  Null client.s
        /// </summary>
        public NullClient()
        {
            Valid = false;
        }
        /// <summary>
        ///  Value is the value of the clients.
        /// </summary>
        public ClientDto Value
        {
            get => _clientDto;
            set { _clientDto = value; }
        }
        /// <summary>
        ///  Valid
        /// </summary>
        public bool Valid
        {
            get; set;
        }
        public IEnumerable<ProvinciaDto> ProvinciaDto { get ; set ; }
        public IEnumerable<CountryDto> CountryDto { get ; set; }
        public IEnumerable<CityDto> CityDto { get ; set; }
        public IEnumerable<ClientZoneDto> ZoneDto { get; set; }
        public IEnumerable<OrigenDto> OrigenDto { get; set; }
      
        public IEnumerable<MercadoDto> ClientMarketDto { get; set; }
        public IEnumerable<ResellerDto> ResellerDto { get; set; }
        public IEnumerable<ActividadDto> ActivityDto { get; set; }
        public IEnumerable<ClientTypeDto> ClientTypeDto { get ; set; }
        public IEnumerable<CompanyDto> CompanyDto { get; set; }
        public IEnumerable<OfficeDtos> OfficeDto { get; set; }
        public IEnumerable<BusinessDto> BusinessDto { get; set; }
        public IEnumerable<ChannelDto> ChannelDto { get; set; }
        public IEnumerable<BudgetKeyDto> BudgetKeyDto { get; set; }
        public IEnumerable<PaymentFormDto> ClientPaymentForm { get; set; }
        public IEnumerable<CreditCardDto> CreditCardType { get; set; }
        public IEnumerable<InvoiceBlockDto> InvoiceBlock { get ; set; }
        public IEnumerable<RentingUseDto> RentUsage { get; set; }
        public IEnumerable<CommissionAgentSummaryDto> BrokerDto { get; set ; }
        public IEnumerable<RentingUseDto> RentUsageDto { get ; set ; }
        public IEnumerable<LanguageDto> LanguageDto { get; set ; }
        public IEnumerable<ClientSummaryDto> DriversDto { get; set; }
        public IEnumerable<ContactsDto> ContactsDto { get; set; }
        public IEnumerable<ZonaOfiDto> ClientZoneDto { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }


        /// <summary>
        ///  Delete asynchronous value.
        /// </summary>
        /// <returns></returns>
        public async Task<bool> DeleteAsync()
        {
            await Task.Delay(1);
            return false; 
        }
        /// <summary>
        ///  Load codigo desde il valore
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public async Task<bool> LoadValue(string code)
        {
            await Task.Delay(1);
            return false;
        }
        /// <summary>
        // Save the data.
        /// </summary>
        /// <returns></returns>
        public async Task<bool> SaveAll()
        {
            await Task.Delay(1);
            return false;
        }
    }
}
