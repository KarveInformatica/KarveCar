using System.Collections.Generic;
using KarveDataServices;
using KarveDataServices.ViewObjects;
using Prism.Mvvm;


namespace MasterModule.ViewModels
{
    /// <summary>
    /// HelperData. Data services.
    /// </summary>
    public class HelperData : BindableBase, IHelperData
    {
        private IEnumerable<ProvinceViewObject> _provinciaDto;
        private IEnumerable<CountryViewObject> _countryDto;
        private IEnumerable<CityViewObject> _cityDto;
        private IEnumerable<ClientZoneViewObject> _zoneDto;
        private IEnumerable<CreditCardViewObject> _creditType;
        private IEnumerable<MarketViewObject> _clientMarket;
        private IEnumerable<OrigenViewObject> _origen;
        private IEnumerable<DelegaContableViewObject> _contable;
        private IEnumerable<ResellerViewObject> _reseller;
        private IEnumerable<ActividadViewObject> _actividad;
        private IEnumerable<ClientTypeViewObject> _clientType;
        private IEnumerable<PaymentFormViewObject> _paymentForm;
        private IEnumerable<CompanyViewObject> _company;
        private IEnumerable<OfficeViewObject> _officeDto;
        private IEnumerable<BusinessViewObject> _businessDto;
        private IEnumerable<ChannelViewObject> _channelDto;
        private IEnumerable<BudgetKeyViewObject> _budgetKey;
        private IEnumerable<PaymentFormViewObject> _clientPaymentForm;

        /// <summary>
        ///  Provincia Data Transfer Object.
        /// </summary>
        public IEnumerable<ProvinceViewObject> ProvinciaDto
        {
            get
            {
               return  _provinciaDto;
            }
            set
            {
                _provinciaDto = value;
                RaisePropertyChanged();

            }

        }
        /// <summary>
        ///  Country Data Trasfer Object.
        /// </summary>
        public IEnumerable<CountryViewObject> CountryDto
        {
            get
            {
               return _countryDto;
            }
            set
            {
                _countryDto = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        /// City Data Transfer Object
        /// </summary>
        public IEnumerable<CityViewObject> CityDto
        {
            get
            {
                return _cityDto;
            }
            set
            {
                _cityDto = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        ///  Client Zone Data Transfer Object
        /// </summary>

        public IEnumerable<ClientZoneViewObject> ZoneDto
        {
            get
            {
                return _zoneDto;
            }
            set
            {
                _zoneDto = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<DelegaContableViewObject> ContableDelegaDto
        {
            get
            {
                return _contable;
            }
            set
            {
                _contable = value;
                RaisePropertyChanged();

            }
        }

        /// <summary>
        /// Origen Data Transfer Object
        /// </summary>
        public IEnumerable<OrigenViewObject> OrigenDto
        {
            get
            {
                return _origen;
            }
            set
            {
                _origen = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        /// Client Market Dto.
        /// </summary>
        public IEnumerable<MarketViewObject> ClientMarketDto
        {
            get
            {
                return _clientMarket;
            }
            set
            {
                _clientMarket = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        ///  Reseller Data Transfer Object.
        /// </summary>
        public IEnumerable<ResellerViewObject> ResellerDto {
            get
            {
                return _reseller;
            }
            set
            {
                _reseller = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        ///  Activity Dto.
        /// </summary>
        public IEnumerable<ActividadViewObject> ActivityDto
        {
            get
            {
                return _actividad;
            }
            set
            {
                _actividad = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Client Type Data Transfer Object.
        /// </summary>
        public IEnumerable<ClientTypeViewObject> 
            ClientTypeDto {
            get {
                return _clientType;
            }
            set
            {
                _clientType = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        ///  Company Data Transfer Object.
        /// </summary>
        public IEnumerable<CompanyViewObject>
            CompanyDto {
            get
            {
                return _company;

            }
            set
            {
                _company = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        ///  Office Data Transfer Object
        /// </summary>
        public IEnumerable<OfficeViewObject> OfficeDto { get
            {
                return _officeDto;
            }
            set
            {
                _officeDto = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        ///  Business data transfer object
        /// </summary>
        public IEnumerable<BusinessViewObject> BusinessDto { get { return _businessDto; }
            set { _businessDto = value; RaisePropertyChanged(); } }
        /// <summary>
        ///  Channel data transfer object
        /// </summary>
        public IEnumerable<ChannelViewObject> ChannelDto {

                                get { return _channelDto;  }
                                set { _channelDto = value; RaisePropertyChanged();
                                    }
        }
        /// <summary>
        ///  Budget key data transfer objectg.
        /// </summary>
        public IEnumerable<BudgetKeyViewObject> BudgetKeyDto {
            get { return _budgetKey;  }
            set
            {
                _budgetKey = value;
            }
        }
        /// <summary>
        ///  Credit transfer object.
        /// </summary>
        public IEnumerable<CreditCardViewObject> CreditCardType
        {
            get
            {
                return _creditType;
            }
            set
            {
                _creditType = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        ///  Payement form data tarsnfer object.
        /// </summary>
        public IEnumerable<PaymentFormViewObject> PaymentFormDto
        {
            get
            {
                return _paymentForm;
            }
            set
            {
                _paymentForm = value;
                RaisePropertyChanged();

            }
        }
        /// <summary>
        /// Payement form 
        /// </summary>
        public IEnumerable<PaymentFormViewObject> ClientPaymentForm {
            get
            {
                return _clientPaymentForm;
            }
            set
            {
                _clientPaymentForm = value;
            }
        }
        /// <summary>
        /// InvoiceBlockViewObject.
        /// </summary>
        public IEnumerable<InvoiceBlockViewObject> InvoiceBlock { get; set; }
        /// <summary>
        ///  Commissionagent viewObject.
        /// </summary>
        public IEnumerable<CommissionAgentSummaryViewObject> BrokerDto { get; set; }
        /// <summary>
        ///  Rent usage.
        /// </summary>
        public IEnumerable<RentingUseViewObject> RentUsageDto { get; set; }
        /// <summary>
        /// Language usage.
        /// </summary>
        public IEnumerable<LanguageViewObject> LanguageDto { get; set; }
        /// <summary>
        ///  Gives you the list of drivers.
        /// </summary>
        public IEnumerable<ClientSummaryViewObject> DriversDto { get; set; }
        // Contacts viewObject.

        public IEnumerable<ContactsViewObject> ContactsDto { get; set; }
        /// <summary>
        ///  Client Zone Dto.
        /// </summary>
        public IEnumerable<ZonaOfiViewObject> ClientZoneDto { get; set; }
       // public IEnumerable<InvoiceFare> InvoiceFare { get; set; }

    }
}