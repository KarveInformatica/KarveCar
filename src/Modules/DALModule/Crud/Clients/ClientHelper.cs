using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveDataServices;
using KarveDataServices.DataTransferObject;

namespace DataAccessLayer.Crud.Clients
{
    internal class ClientHelper: IHelperData
    {
        public IEnumerable<ActividadDto> ActivityDto { get; set; }
        public IEnumerable<ClientTypeDto> ClientTypeDto { get; set; }
        public IEnumerable<CreditCardDto> CreditCardType { get; set; }
        public IEnumerable<ProvinciaDto> ProvinciaDto { get; set; }
        public IEnumerable<CountryDto> CountryDto { get; set; }
        public IEnumerable<CityDto> CityDto { get; set; }
        public IEnumerable<ClientZoneDto> ZoneDto { get; set; }
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
    }
}
