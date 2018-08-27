using KarveDataServices.DataObjects;
using System.Threading.Tasks;
using KarveDataServices.ViewObjects;
using System.Collections.Generic;
using KarveDataServices;

namespace DataAccessLayer.DtoWrapper
{
    /// <summary>
    ///  Null client is an empty object.
    /// </summary>
    public class NullClient : DomainObject, IClientData
    {
       private ClientViewObject _clientViewObject = new ClientViewObject();
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
        public ClientViewObject Value
        {
            get => _clientViewObject;
            set { _clientViewObject = value; }
        }
        
        public IEnumerable<ProvinceViewObject> ProvinciaDto { get ; set ; }
        public IEnumerable<CountryViewObject> CountryDto { get ; set; }
        public IEnumerable<CityViewObject> CityDto { get ; set; }
        public IEnumerable<ClientZoneViewObject> ZoneDto { get; set; }
        public IEnumerable<DelegaContableViewObject> ContableDelegaDto { get; set; }
        public IEnumerable<OrigenViewObject> OrigenDto { get; set; }
      
        public IEnumerable<MarketViewObject> ClientMarketDto { get; set; }
        public IEnumerable<ResellerViewObject> ResellerDto { get; set; }
        public IEnumerable<ActividadViewObject> ActivityDto { get; set; }
        public IEnumerable<ClientTypeViewObject> ClientTypeDto { get ; set; }
        public IEnumerable<CompanyViewObject> CompanyDto { get; set; }
        public IEnumerable<OfficeViewObject> OfficeDto { get; set; }
        public IEnumerable<BusinessViewObject> BusinessDto { get; set; }
        public IEnumerable<ChannelViewObject> ChannelDto { get; set; }
        public IEnumerable<BudgetKeyViewObject> BudgetKeyDto { get; set; }
        public IEnumerable<PaymentFormViewObject> ClientPaymentForm { get; set; }
        public IEnumerable<CreditCardViewObject> CreditCardType { get; set; }
        public IEnumerable<InvoiceBlockViewObject> InvoiceBlock { get ; set; }
        public IEnumerable<RentingUseViewObject> RentUsage { get; set; }
        public IEnumerable<CommissionAgentSummaryViewObject> BrokerDto { get; set ; }
        public IEnumerable<RentingUseViewObject> RentUsageDto { get ; set ; }
        public IEnumerable<LanguageViewObject> LanguageDto { get; set ; }
        public IEnumerable<ClientSummaryViewObject> DriversDto { get; set; }
        public IEnumerable<ContactsViewObject> ContactsDto { get; set; }
        public IEnumerable<ZonaOfiViewObject> ClientZoneDto { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }


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
