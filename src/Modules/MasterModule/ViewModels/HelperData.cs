using System.Collections.Generic;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using Prism.Mvvm;

namespace MasterModule.ViewModels
{
    /// <summary>
    /// HelperData. Data services.
    /// </summary>
    internal class HelperData : BindableBase, IHelperData
    {

        /// <summary>
        ///  Provincia Data Transfer Object.
        /// </summary>
        public IEnumerable<ProvinciaDto> ProvinciaDto
        {
            get; set;
            
        }
        /// <summary>
        ///  Country Data Trasfer Object.
        /// </summary>
        public IEnumerable<CountryDto> CountryDto { get; set; }
        /// <summary>
        /// City Data Transfer Object
        /// </summary>
        public IEnumerable<CityDto> CityDto { get; set; }
        /// <summary>
        ///  Client Zone Data Transfer Object
        /// </summary>
        public IEnumerable<ClientZoneDto> ZoneDto { get; set; }
        /// <summary>
        /// Origen Data Transfer Object
        /// </summary>
        public IEnumerable<OrigenDto> OrigenDto { get; set; }
        /// <summary>
        /// Client Market Dto.
        /// </summary>
        public IEnumerable<MercadoDto> ClientMarketDto { get; set; }
        /// <summary>
        ///  Reseller Data Transfer Object.
        /// </summary>
        public IEnumerable<ResellerDto> ResellerDto { get; set; }

        public IEnumerable<ActividadDto> ActivityDto { get; set; }

        /// <summary>
        /// Client Type Data Transfer Object.
        /// </summary>
        public IEnumerable<ClientTypeDto> ClientTypeDto { get; set; }
        /// <summary>
        ///  Company Data Transfer Object.
        /// </summary>
        public IEnumerable<CompanyDto> CompanyDto { get; set; }
        /// <summary>
        ///  Office Data Transfer Object
        /// </summary>
        public IEnumerable<OfficeDtos> OfficeDto { get; set; }
        /// <summary>
        ///  Business data transfer object
        /// </summary>
        public IEnumerable<BusinessDto> BusinessDto { get; set; }
        /// <summary>
        ///  Channel data transfer object
        /// </summary>
        public IEnumerable<ChannelDto> ChannelDto { get; set; }
        /// <summary>
        ///  Budget key data transfer objectg.
        /// </summary>
        public IEnumerable<BudgetKeyDto> BudgetKeyDto { get; set; }
        /// <summary>
        ///  Credit transfer object.
        /// </summary>
        public IEnumerable<CreditCardDto> CreditCardType { get; set; }
        /// <summary>
        ///  Payement form data tarsnfer object.
        /// </summary>
        public IEnumerable<PaymentFormDto> PaymentFormDto { get; set; }
        /// <summary>
        /// Payement form 
        /// </summary>
        public IEnumerable<PaymentFormDto> ClientPaymentForm { get ; set; }
        /// <summary>
        /// InvoiceBlockDto.
        /// </summary>
        public IEnumerable<InvoiceBlockDto> InvoiceBlock { get ; set; }
        /// <summary>
        ///  Commissionagent dto.
        /// </summary>
        public IEnumerable<CommissionAgentSummaryDto> BrokerDto { get ; set ; }
        /// <summary>
        ///  Rent usage.
        /// </summary>
        public IEnumerable<RentingUseDto> RentUsageDto { get; set; }
        /// <summary>
        /// Language usage.
        /// </summary>
        public IEnumerable<LanguageDto> LanguageDto { get; set; }
        /// <summary>
        ///  Gives you the list of drivers.
        /// </summary>
        public IEnumerable<ClientSummaryDto> DriversDto { get; set; }
        // Contacts dto.

        public IEnumerable<ContactsDto> ContactsDto { get ; set; }
        /// <summary>
        ///  Client Zone Dto.
        /// </summary>
        public IEnumerable<ZonaOfiDto> ClientZoneDto { get ; set ; }
    }
}