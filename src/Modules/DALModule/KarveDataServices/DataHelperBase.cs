using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveDataServices.DataTransferObject;

namespace KarveDataServices
{
    /// <summary>
    ///  Helperbase class for the all related objects.
    /// </summary>
    public class DataHelperBase : BindableBase, IHelperData
    {
        private IEnumerable<VehicleSummaryDto> _vehicleDto;
        private IEnumerable<CreditCardDto> _creditCardType;
        private IEnumerable<ClientTypeDto> _clientTypeDto;
        private IEnumerable<ActividadDto> _activityDto;
        private IEnumerable<OrigenDto> _origenDto;
        private IEnumerable<CommissionAgentSummaryDto> _brokerDto;
        private IEnumerable<MercadoDto> _clientMarketDto;
        private IEnumerable<ResellerDto> _resellerDto;
        private IEnumerable<CompanyDto> _companyDto;
        private IEnumerable<OfficeDtos> _officeDto;
        private IEnumerable<BusinessDto> _businessDto;
        private IEnumerable<ChannelDto> _channelDto;
        private IEnumerable<BudgetKeyDto> _bookingDto;
        private IEnumerable<PaymentFormDto> _clientPaymentForm;
        private IEnumerable<InvoiceBlockDto> _invoiceBlock;
        private IEnumerable<RentingUseDto> _rentUsage;
        private IEnumerable<LanguageDto> _languageDto;
        private IEnumerable<ClientSummaryDto> _clientSummaryDto;
        private IEnumerable<ContactsDto> _contactsDto;
        private IEnumerable<ProvinciaDto> _provinciaDto;
        private IEnumerable<CountryDto> _countryDto;
        private IEnumerable<CityDto> _cityDto;
        private IEnumerable<ZonaOfiDto> _clientZoneDto;
        private IEnumerable<ClientZoneDto> _zoneDto;
        private IEnumerable<VehicleGroupDto> _vehicleGroup;
        private IEnumerable<DelegaContableDto> _contableDelegaDto;
        private IEnumerable<FareDto> _fareDto;

        public virtual IEnumerable<ActividadDto> ActivityDto {
            get {
                return _activityDto;
            }
            set {
                _activityDto = value;
                RaisePropertyChanged();
            }
        } 
        public virtual IEnumerable<ClientTypeDto> ClientTypeDto
        {
            get {
                return _clientTypeDto;
            }
            set {
                _clientTypeDto = value;
                RaisePropertyChanged();
            }
        }
        public virtual IEnumerable<CreditCardDto> CreditCardType
        {
            get {
                return _creditCardType;
            }
            set {
                _creditCardType = value;
                RaisePropertyChanged();
            }
        }
        public virtual IEnumerable<OrigenDto> OrigenDto
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
        public virtual IEnumerable<CommissionAgentSummaryDto> 
            BrokerDto {
            get {
                return _brokerDto;
            }
            set {
                _brokerDto = value;
                RaisePropertyChanged();
            }
        }

        public virtual IEnumerable<MercadoDto> ClientMarketDto
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
        public virtual IEnumerable<ResellerDto> ResellerDto
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
        public virtual IEnumerable<CompanyDto> CompanyDto {
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
        public virtual IEnumerable<OfficeDtos> OfficeDto
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
        public virtual IEnumerable<BusinessDto> BusinessDto
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

        public virtual IEnumerable<ChannelDto> ChannelDto
        {
            get { return _channelDto;  }
            set { _channelDto = value;
                RaisePropertyChanged(); }
        }
        public virtual IEnumerable<BudgetKeyDto> BudgetKeyDto {
            get { return _bookingDto; } 
            set { _bookingDto = value;  RaisePropertyChanged();
            }
        }
        public virtual IEnumerable<PaymentFormDto> ClientPaymentForm
        {
          get { return _clientPaymentForm; }
          set { _clientPaymentForm = value; RaisePropertyChanged(); }
        }
        public virtual IEnumerable<InvoiceBlockDto> InvoiceBlock
        {

            get { return _invoiceBlock; }
            set { _invoiceBlock = value; }
        }

        public virtual IEnumerable<RentingUseDto> RentUsageDto {
            get { return _rentUsage; } 
            set { _rentUsage = value; RaisePropertyChanged(); }
        }
        public virtual IEnumerable<LanguageDto> LanguageDto {
            get { return _languageDto;  }
            set { _languageDto = value; RaisePropertyChanged(); }
        }
        public virtual IEnumerable<ClientSummaryDto> DriversDto
        {
            get { return _clientSummaryDto; } 
            set { _clientSummaryDto = value; RaisePropertyChanged(); }
        }
        public virtual IEnumerable<ContactsDto> ContactsDto
        {
            get { return _contactsDto; }
            set { _contactsDto = value; RaisePropertyChanged(); }
        }
        public virtual IEnumerable<ProvinciaDto> ProvinciaDto
        {   get { return _provinciaDto; }
            set { _provinciaDto = value; RaisePropertyChanged(); }
        }
        public virtual IEnumerable<CountryDto> CountryDto
        {
            get { return _countryDto; }
            set { _countryDto = value; RaisePropertyChanged(); }
        }
        public virtual IEnumerable<CityDto> CityDto {
            get { return _cityDto; }
            set { _cityDto = value; RaisePropertyChanged(); }
        }
        public virtual IEnumerable<ZonaOfiDto> ClientZoneDto
        { get { return _clientZoneDto; }
            set { _clientZoneDto = value; } }
        public virtual IEnumerable<ClientZoneDto> ZoneDto {
            get {
                return _zoneDto;
            }
            set {
                _zoneDto = value;
                RaisePropertyChanged();
            }
        }
        public virtual IEnumerable<VehicleSummaryDto> VehicleDto {
            get { return _vehicleDto; }
            set
            {
                _vehicleDto = value;
                RaisePropertyChanged();
            }
        }
        public virtual IEnumerable<VehicleGroupDto> VehicleGroupDto {
            set
            {
                _vehicleGroup = value;
            }

            get {
                return _vehicleGroup;
            }
        }
        public virtual IEnumerable<DelegaContableDto> ContableDelegaDto
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
        public virtual IEnumerable<FareDto> FareDto {
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
