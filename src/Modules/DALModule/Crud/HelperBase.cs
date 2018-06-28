using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using Prism.Mvvm;

namespace DataAccessLayer
{
    public class HelperBase : BindableBase, IHelperData
    {
        private IEnumerable<ActividadDto> _activityDto;
        private IEnumerable<ClientTypeDto> _clientTypeDto;
        private IEnumerable<CreditCardDto> _creditCardType;
        private IEnumerable<ProvinciaDto> _provinciaDto;
        private IEnumerable<CountryDto> _countryDto;
        private IEnumerable<CityDto> _cityDto;
        private IEnumerable<DelegaContableDto> _contableDelega;
        private IEnumerable<ClientZoneDto> _clientZoneDto;
        private IEnumerable<OrigenDto> _origenDto;
        private IEnumerable<MercadoDto> _mercadoDto;
        private IEnumerable<CommissionAgentSummaryDto> _brokerDto;
        private IEnumerable<ResellerDto> _resellerDto;
        private IEnumerable<PaymentFormDto> _clientpayment;
        private IEnumerable<InvoiceBlockDto> _invoiceBlockDto;
        private IEnumerable<RentingUseDto> _rentUsageDto;

        public IEnumerable<ActividadDto> ActivityDto
        {
            get => _activityDto;
            set
            {
                _activityDto = value;
                RaisePropertyChanged();

            }
        }

        public IEnumerable<ClientTypeDto> ClientTypeDto
        {
            get
            {
                return _clientTypeDto;
            }
            set
            {
                _clientTypeDto = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<CreditCardDto> CreditCardType
        {
            get
            {
                return _creditCardType;
            }
            set
            {
                _creditCardType = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<ProvinciaDto> ProvinciaDto
        {
            get
            {
                return _provinciaDto;

            }
            set
            {
                _provinciaDto = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<CountryDto> CountryDto
        {
            get
            {
                return _countryDto;

            }
            set { _countryDto = value; RaisePropertyChanged(); }
        }

        public IEnumerable<CityDto> CityDto
        {
            get { return _cityDto; }
            set { _cityDto = value; RaisePropertyChanged(); }
        }
        public IEnumerable<ClientZoneDto> ZoneDto
        {
            get { return _clientZoneDto; }
            set { _clientZoneDto = value; }
        }

        public IEnumerable<DelegaContableDto> ContableDelegaDto
        {
            get { return _contableDelega; }
            set
            {
                _contableDelega = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<OrigenDto> OrigenDto
        {
            get {  return _origenDto; }
            set { _origenDto = value; RaisePropertyChanged(); }
        }
        public IEnumerable<CommissionAgentSummaryDto> BrokerDto
        { get { return _brokerDto; }
            set { _brokerDto = value; RaisePropertyChanged(); } }
        public IEnumerable<MercadoDto> ClientMarketDto
        {
            get
            {
                return _mercadoDto;
            } set { _mercadoDto = value; RaisePropertyChanged(); }
        }
        public IEnumerable<ResellerDto> ResellerDto { get { return _resellerDto; } set { _resellerDto = value; RaisePropertyChanged(); } }
        public IEnumerable<CompanyDto> CompanyDto { get ; set; }
        public IEnumerable<OfficeDtos> OfficeDto { get; set; }
        public IEnumerable<BusinessDto> BusinessDto { get; set; }
        public IEnumerable<ChannelDto> ChannelDto { get; set; }
        public IEnumerable<BudgetKeyDto> BudgetKeyDto { get; set; }
        public IEnumerable<PaymentFormDto> ClientPaymentForm { get { return _clientpayment; } set { _clientpayment = value; RaisePropertyChanged(); }  }
        public IEnumerable<InvoiceBlockDto> InvoiceBlock { get { return _invoiceBlockDto;  } set { _invoiceBlockDto = value; RaisePropertyChanged(); } }
        public IEnumerable<RentingUseDto> RentUsageDto { get { return _rentUsageDto;  } set { _rentUsageDto = value; RaisePropertyChanged(); } }
        public IEnumerable<LanguageDto> LanguageDto { get; set; }
        public IEnumerable<ClientSummaryDto> DriversDto { get; set; }
        public IEnumerable<ContactsDto> ContactsDto { get; set; }
        public IEnumerable<ZonaOfiDto> ClientZoneDto { get ; set ; }
    }
}
