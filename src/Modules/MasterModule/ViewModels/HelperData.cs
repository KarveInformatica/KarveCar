using System.Collections.Generic;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using Prism.Mvvm;
using DataAccessLayer.Model;

namespace MasterModule.ViewModels
{
    /// <summary>
    /// HelperData. Data services.
    /// </summary>
    public class HelperData : BindableBase, IHelperData
    {
        private IEnumerable<ProvinciaDto> _provinciaDto;
        private IEnumerable<CountryDto> _countryDto;
        private IEnumerable<CityDto> _cityDto;
        private IEnumerable<ClientZoneDto> _zoneDto;
        private IEnumerable<CreditCardDto> _creditType;
        private IEnumerable<MercadoDto> _clientMarket;
        private IEnumerable<OrigenDto> _origen;
        private IEnumerable<DelegaContableDto> _contable;
        private IEnumerable<ResellerDto> _reseller;
        private IEnumerable<ActividadDto> _actividad;
        private IEnumerable<ClientTypeDto> _clientType;
        private IEnumerable<PaymentFormDto> _paymentForm;
        private IEnumerable<CompanyDto> _company;
        private IEnumerable<OfficeDtos> _officeDto;
        private IEnumerable<BusinessDto> _businessDto;
        private IEnumerable<ChannelDto> _channelDto;
        private IEnumerable<BudgetKeyDto> _budgetKey;
        private IEnumerable<PaymentFormDto> _clientPaymentForm;

        /// <summary>
        ///  Provincia Data Transfer Object.
        /// </summary>
        public IEnumerable<ProvinciaDto> ProvinciaDto
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
        public IEnumerable<CountryDto> CountryDto
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
        public IEnumerable<CityDto> CityDto
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

        public IEnumerable<ClientZoneDto> ZoneDto
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

        public IEnumerable<DelegaContableDto> ContableDelegaDto
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
        public IEnumerable<OrigenDto> OrigenDto
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
        public IEnumerable<MercadoDto> ClientMarketDto
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
        public IEnumerable<ResellerDto> ResellerDto {
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
        public IEnumerable<ActividadDto> ActivityDto
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
        public IEnumerable<ClientTypeDto> 
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
        public IEnumerable<CompanyDto>
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
        public IEnumerable<OfficeDtos> OfficeDto { get
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
        public IEnumerable<BusinessDto> BusinessDto { get { return _businessDto; }
            set { _businessDto = value; RaisePropertyChanged(); } }
        /// <summary>
        ///  Channel data transfer object
        /// </summary>
        public IEnumerable<ChannelDto> ChannelDto {

                                get { return _channelDto;  }
                                set { _channelDto = value; RaisePropertyChanged();
                                    }
        }
        /// <summary>
        ///  Budget key data transfer objectg.
        /// </summary>
        public IEnumerable<BudgetKeyDto> BudgetKeyDto {
            get { return _budgetKey;  }
            set
            {
                _budgetKey = value;
            }
        }
        /// <summary>
        ///  Credit transfer object.
        /// </summary>
        public IEnumerable<CreditCardDto> CreditCardType
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
        public IEnumerable<PaymentFormDto> PaymentFormDto
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
        public IEnumerable<PaymentFormDto> ClientPaymentForm {
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
        /// InvoiceBlockDto.
        /// </summary>
        public IEnumerable<InvoiceBlockDto> InvoiceBlock { get; set; }
        /// <summary>
        ///  Commissionagent dto.
        /// </summary>
        public IEnumerable<CommissionAgentSummaryDto> BrokerDto { get; set; }
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

        public IEnumerable<ContactsDto> ContactsDto { get; set; }
        /// <summary>
        ///  Client Zone Dto.
        /// </summary>
        public IEnumerable<ZonaOfiDto> ClientZoneDto { get; set; }
        /// <summary>
        ///  Invoice Fare Dto.
        /// </summary>
        public IEnumerable<InvoiceFareDto> InvoiceFare { get; set; }

    }
}