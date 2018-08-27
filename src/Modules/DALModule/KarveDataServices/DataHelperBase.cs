using Prism.Mvvm;
using System.Collections.Generic;
using KarveDataServices.ViewObjects;

namespace KarveDataServices
{
    /// <summary>
    ///  Helperbase class for the all related objects.
    /// </summary>
    public class DataHelperBase : BindableBase, IHelperData
    {
        private IEnumerable<VehicleSummaryViewObject> _vehicleDto;
        private IEnumerable<CreditCardViewObject> _creditCardType;
        private IEnumerable<ClientTypeViewObject> _clientTypeDto;
        private IEnumerable<ActividadViewObject> _activityDto;
        private IEnumerable<OrigenViewObject> _origenDto;
        private IEnumerable<CommissionAgentSummaryViewObject> _brokerDto;
        private IEnumerable<MarketViewObject> _clientMarketDto;
        private IEnumerable<ResellerViewObject> _resellerDto;
        private IEnumerable<CompanyViewObject> _companyDto;
        private IEnumerable<OfficeViewObject> _officeDto;
        private IEnumerable<BusinessViewObject> _businessDto;
        private IEnumerable<ChannelViewObject> _channelDto;
        private IEnumerable<BudgetKeyViewObject> _bookingDto;
        private IEnumerable<PaymentFormViewObject> _clientPaymentForm;
        private IEnumerable<InvoiceBlockViewObject> _invoiceBlock;
        private IEnumerable<RentingUseViewObject> _rentUsage;
        private IEnumerable<LanguageViewObject> _languageDto;
        private IEnumerable<ClientSummaryViewObject> _clientSummaryDto;
        private IEnumerable<ContactsViewObject> _contactsDto;
        private IEnumerable<ProvinceViewObject> _provinciaDto;
        private IEnumerable<CountryViewObject> _countryDto;
        private IEnumerable<CityViewObject> _cityDto;
        private IEnumerable<ZonaOfiViewObject> _clientZoneDto;
        private IEnumerable<ClientZoneViewObject> _zoneDto;
        private IEnumerable<VehicleGroupViewObject> _vehicleGroup;
        private IEnumerable<DelegaContableViewObject> _contableDelegaDto;
        private IEnumerable<FareViewObject> _fareDto;

        public virtual IEnumerable<ActividadViewObject> ActivityDto {
            get {
                return _activityDto;
            }
            set {
                _activityDto = value;
                RaisePropertyChanged();
            }
        } 
        public virtual IEnumerable<ClientTypeViewObject> ClientTypeDto
        {
            get {
                return _clientTypeDto;
            }
            set {
                _clientTypeDto = value;
                RaisePropertyChanged();
            }
        }
        public virtual IEnumerable<CreditCardViewObject> CreditCardType
        {
            get {
                return _creditCardType;
            }
            set {
                _creditCardType = value;
                RaisePropertyChanged();
            }
        }
        public virtual IEnumerable<OrigenViewObject> OrigenDto
        {
            get {
                return _origenDto;
            }
            set
            {
                _origenDto = value;
                RaisePropertyChanged();
            }
        }
        public virtual IEnumerable<CommissionAgentSummaryViewObject> 
            BrokerDto {
            get {
                return _brokerDto;
            }
            set {
                _brokerDto = value;
                RaisePropertyChanged();
            }
        }

        public virtual IEnumerable<MarketViewObject> ClientMarketDto
        {
            get
            {
                return _clientMarketDto;
            }
            set {
                _clientMarketDto = value;
                RaisePropertyChanged();
            }
        }
        public virtual IEnumerable<ResellerViewObject> ResellerDto
        {
            get
            {
                return _resellerDto;
            } 
            set
            {
                _resellerDto = value;
                RaisePropertyChanged();
            }
        }
        public virtual IEnumerable<CompanyViewObject> CompanyDto {
            get
            {
                return _companyDto;

            }
            set
            {
                _companyDto = value;
                RaisePropertyChanged();
            }
        }
        public virtual IEnumerable<OfficeViewObject> OfficeDto
        {
            get
            {
                return _officeDto;
            }
            set
            {
                _officeDto = value;
                RaisePropertyChanged();
            }
        }
        public virtual IEnumerable<BusinessViewObject> BusinessDto
        { get
          {
                return _businessDto;
          }
            set
            {
                _businessDto = value;
                RaisePropertyChanged();

            } 
        }

        public virtual IEnumerable<ChannelViewObject> ChannelDto
        {
            get { return _channelDto;  }
            set { _channelDto = value;
                RaisePropertyChanged(); }
        }
        public virtual IEnumerable<BudgetKeyViewObject> BudgetKeyDto {
            get { return _bookingDto; } 
            set { _bookingDto = value;  RaisePropertyChanged();
            }
        }
        public virtual IEnumerable<PaymentFormViewObject> ClientPaymentForm
        {
          get { return _clientPaymentForm; }
          set { _clientPaymentForm = value; RaisePropertyChanged(); }
        }
        public virtual IEnumerable<InvoiceBlockViewObject> InvoiceBlock
        {

            get { return _invoiceBlock; }
            set { _invoiceBlock = value; }
        }

        public virtual IEnumerable<RentingUseViewObject> RentUsageDto {
            get { return _rentUsage; } 
            set { _rentUsage = value; RaisePropertyChanged(); }
        }
        public virtual IEnumerable<LanguageViewObject> LanguageDto {
            get { return _languageDto;  }
            set { _languageDto = value; RaisePropertyChanged(); }
        }
        public virtual IEnumerable<ClientSummaryViewObject> DriversDto
        {
            get { return _clientSummaryDto; } 
            set { _clientSummaryDto = value; RaisePropertyChanged(); }
        }
        public virtual IEnumerable<ContactsViewObject> ContactsDto
        {
            get { return _contactsDto; }
            set { _contactsDto = value; RaisePropertyChanged(); }
        }
        public virtual IEnumerable<ProvinceViewObject> ProvinciaDto
        {   get { return _provinciaDto; }
            set { _provinciaDto = value; RaisePropertyChanged(); }
        }
        public virtual IEnumerable<CountryViewObject> CountryDto
        {
            get { return _countryDto; }
            set { _countryDto = value; RaisePropertyChanged(); }
        }
        public virtual IEnumerable<CityViewObject> CityDto {
            get { return _cityDto; }
            set { _cityDto = value; RaisePropertyChanged(); }
        }
        public virtual IEnumerable<ZonaOfiViewObject> ClientZoneDto
        { get { return _clientZoneDto; }
            set { _clientZoneDto = value; } }
        public virtual IEnumerable<ClientZoneViewObject> ZoneDto {
            get {
                return _zoneDto;
            }
            set {
                _zoneDto = value;
                RaisePropertyChanged();
            }
        }
        public virtual IEnumerable<VehicleSummaryViewObject> VehicleDto {
            get { return _vehicleDto; }
            set
            {
                _vehicleDto = value;
                RaisePropertyChanged();
            }
        }
        public virtual IEnumerable<VehicleGroupViewObject> VehicleGroupDto {
            set
            {
                _vehicleGroup = value;
            }

            get {
                return _vehicleGroup;
            }
        }
        public virtual IEnumerable<DelegaContableViewObject> ContableDelegaDto
        {
            get
            {
                return _contableDelegaDto;
            }
            set
            {
                _contableDelegaDto = value;
                RaisePropertyChanged();
            }
        }
        public virtual IEnumerable<FareViewObject> FareDto {
            set
            {
                _fareDto = value;
                RaisePropertyChanged();

            }
            get
            {
                return _fareDto;
            }
        }
    }
}
