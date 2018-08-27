using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveDataServices;
using KarveDataServices.ViewObjects;
using Prism.Mvvm;

namespace DataAccessLayer
{
    public class HelperBase : BindableBase, IHelperData
    {
        private IEnumerable<ActividadViewObject> _activityDto;
        private IEnumerable<ClientTypeViewObject> _clientTypeDto;
        private IEnumerable<CreditCardViewObject> _creditCardType;
        private IEnumerable<ProvinceViewObject> _provinciaDto;
        private IEnumerable<CountryViewObject> _countryDto;
        private IEnumerable<CityViewObject> _cityDto;
        private IEnumerable<DelegaContableViewObject> _contableDelega;
        private IEnumerable<ClientZoneViewObject> _clientZoneDto;
        private IEnumerable<OrigenViewObject> _origenDto;
        private IEnumerable<MarketViewObject> _mercadoDto;
        private IEnumerable<CommissionAgentSummaryViewObject> _brokerDto;
        private IEnumerable<ResellerViewObject> _resellerDto;
        private IEnumerable<PaymentFormViewObject> _clientpayment;
        private IEnumerable<InvoiceBlockViewObject> _invoiceBlockDto;
        private IEnumerable<RentingUseViewObject> _rentUsageDto;

        public IEnumerable<ActividadViewObject> ActivityDto
        {
            get => _activityDto;
            set
            {
                _activityDto = value;
                RaisePropertyChanged();

            }
        }

        public IEnumerable<ClientTypeViewObject> ClientTypeDto
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
        public IEnumerable<CreditCardViewObject> CreditCardType
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

        public IEnumerable<ProvinceViewObject> ProvinciaDto
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
        public IEnumerable<CountryViewObject> CountryDto
        {
            get
            {
                return _countryDto;

            }
            set { _countryDto = value; RaisePropertyChanged(); }
        }

        public IEnumerable<CityViewObject> CityDto
        {
            get { return _cityDto; }
            set { _cityDto = value; RaisePropertyChanged(); }
        }
        public IEnumerable<ClientZoneViewObject> ZoneDto
        {
            get { return _clientZoneDto; }
            set { _clientZoneDto = value; }
        }

        public IEnumerable<DelegaContableViewObject> ContableDelegaDto
        {
            get { return _contableDelega; }
            set
            {
                _contableDelega = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<OrigenViewObject> OrigenDto
        {
            get {  return _origenDto; }
            set { _origenDto = value; RaisePropertyChanged(); }
        }
        public IEnumerable<CommissionAgentSummaryViewObject> BrokerDto
        { get { return _brokerDto; }
            set { _brokerDto = value; RaisePropertyChanged(); } }
        public IEnumerable<MarketViewObject> ClientMarketDto
        {
            get
            {
                return _mercadoDto;
            } set { _mercadoDto = value; RaisePropertyChanged(); }
        }
        public IEnumerable<ResellerViewObject> ResellerDto { get { return _resellerDto; } set { _resellerDto = value; RaisePropertyChanged(); } }
        public IEnumerable<CompanyViewObject> CompanyDto { get ; set; }
        public IEnumerable<OfficeViewObject> OfficeDto { get; set; }
        public IEnumerable<BusinessViewObject> BusinessDto { get; set; }
        public IEnumerable<ChannelViewObject> ChannelDto { get; set; }
        public IEnumerable<BudgetKeyViewObject> BudgetKeyDto { get; set; }
        public IEnumerable<PaymentFormViewObject> ClientPaymentForm { get { return _clientpayment; } set { _clientpayment = value; RaisePropertyChanged(); }  }
        public IEnumerable<InvoiceBlockViewObject> InvoiceBlock { get { return _invoiceBlockDto;  } set { _invoiceBlockDto = value; RaisePropertyChanged(); } }
        public IEnumerable<RentingUseViewObject> RentUsageDto { get { return _rentUsageDto;  } set { _rentUsageDto = value; RaisePropertyChanged(); } }
        public IEnumerable<LanguageViewObject> LanguageDto { get; set; }
        public IEnumerable<ClientSummaryViewObject> DriversDto { get; set; }
        public IEnumerable<ContactsViewObject> ContactsDto { get; set; }
        public IEnumerable<ZonaOfiViewObject> ClientZoneDto { get ; set ; }
    }
}
