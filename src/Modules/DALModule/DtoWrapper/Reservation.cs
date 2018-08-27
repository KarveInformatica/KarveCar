using System.Collections.Generic;
using System.Collections.ObjectModel;
using KarveDataServices;
using KarveDataServices.DataObjects;
using KarveDataServices.ViewObjects;
using Prism.Mvvm;

namespace DataAccessLayer.DtoWrapper
{
    /// <summary>
    ///  Wrapper that allows us to deliver  its dto and a set of related things for the searchboxes.
    ///  I think that those wrapper are simply vectors (they bring something). 
    ///  No need for raiseproperty change.
    /// </summary>
    public class Reservation : BindableBase, IBookingData
    {
        public Reservation()
        {
            Value = new BookingViewObject();
            Valid = true;
            InitFields();
            
        }
        private void InitFields()
        {
            _broker = new ObservableCollection<CommissionAgentSummaryViewObject>();
            _budget = new ObservableCollection<BudgetViewObject>();
            _city3 = new ObservableCollection<CityViewObject>();
            _clients = new ObservableCollection<ClientSummaryExtended>();
            _company = new ObservableCollection<CompanyViewObject>();
            _contracts = new ObservableCollection<ContractSummaryDto>();
            _country2 = new ObservableCollection<CountryViewObject>();
            _country3 = new ObservableCollection<CountryViewObject>();
            _country4 = new ObservableCollection<CountryViewObject>();
            _driver2 = new ObservableCollection<ClientSummaryExtended>();
            _driver3 = new ObservableCollection<ClientSummaryExtended>();
            _driver4 = new ObservableCollection<ClientSummaryExtended>();
            _driver5 = new ObservableCollection<ClientSummaryExtended>();
            _drivers = new ObservableCollection<ClientSummaryExtended>();
            _fare = new ObservableCollection<FareViewObject>();
            _office1 = new ObservableCollection<OfficeViewObject>();
            _province3 = new ObservableCollection<ProvinceViewObject>();
            _reservationOfficeArrival = new ObservableCollection<OfficeViewObject>();
            _reservationOfficeDeparture = new ObservableCollection<OfficeViewObject>();
            _vehicleGroup = new ObservableCollection<VehicleGroupViewObject>();
            _vehicleSummary = new ObservableCollection<VehicleSummaryViewObject>();
            this.AgencyEmployeeDto = new ObservableCollection<AgencyEmployeeViewObject>();

        }

        /// <summary>
        /// Get or Set the booking data. Value to be used.
        /// </summary>
        public BookingViewObject Value { get; set; }

        /// <summary>
        ///  Contract summary
        /// </summary>
        private IEnumerable<ContractSummaryDto> _contracts;
        /// <summary>
        ///  Client summary
        /// </summary>
        private IEnumerable<ClientSummaryExtended> _clients;
        /// <summary>
        ///  Drivers summary
        /// </summary>
        private IEnumerable<ClientSummaryExtended> _drivers;
        /// <summary>
        ///  Valid summary.
        /// </summary>
        private bool _valid;
        private IEnumerable<OfficeViewObject> _reservationOfficeDeparture;
        private IEnumerable<OfficeViewObject> _reservationOfficeArrival;
        private IEnumerable<OfficeViewObject> _office1;
        private IEnumerable<BudgetViewObject> _budget;
        private IEnumerable<FareViewObject> _fare;
        private IEnumerable<VehicleGroupViewObject> _vehicleGroup;
        private IEnumerable<CommissionAgentSummaryViewObject> _broker;
        private IEnumerable<VehicleSummaryViewObject> _vehicleSummary;
        private IEnumerable<ClientSummaryExtended> _driver2;
        private IEnumerable<ClientSummaryExtended> _driver3;
        private IEnumerable<ClientSummaryExtended> _driver4;
        private IEnumerable<ClientSummaryExtended> _driver5;
        private IEnumerable<CityViewObject> _city3;
        private IEnumerable<CountryViewObject> _country2;
        private IEnumerable<CountryViewObject> _country3;
        private IEnumerable<CountryViewObject> _country4;
        private IEnumerable<ProvinceViewObject> _province3;
        private IEnumerable<CompanyViewObject> _company;
        /// <summary>
        ///  List of Contracts.
        /// </summary>
        public IEnumerable<ContractSummaryDto> Contracts {
            get
            {
                return _contracts;
            }
            set
            {
                _contracts = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        ///  Set or get the company
        /// </summary>
        public IEnumerable<CompanyViewObject> CompanyDto {
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
        ///  Get or Set Clients
        /// </summary>
        public IEnumerable<ClientSummaryExtended> Clients
        {
            get
            {
                return _clients;
            }
            set
            {
                _clients = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        ///  Get or Set Drivers
        /// </summary>
        public IEnumerable<ClientSummaryExtended> Drivers
        {
            get
            {
                return _drivers;
            }
            set
            {
                _drivers = value;
                RaisePropertyChanged();
            }

        }
        /// <summary>
        ///  Set the validity of the domain object. In case of any error this gets false
        /// </summary>
        public bool Valid
        {
            get
            {
                return _valid;
            }
            set
            {
                _valid = true;
            }
        }
        /// <summary>
        ///  Set or get the reservation office departure
        /// </summary>
        public IEnumerable<OfficeViewObject> ReservationOfficeDeparture
        {
            get
            {
              return _reservationOfficeDeparture;
            }
            set
            {
                _reservationOfficeDeparture = value;
                RaisePropertyChanged();
            }

        }
        /// <summary>
        ///  Get or set the reservation office arrival
        /// </summary>
        public IEnumerable<OfficeViewObject> ReservationOfficeArrival
        {
            get
            {
                return _reservationOfficeArrival;
            }
            set
            {
                _reservationOfficeArrival = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        ///  Get ot set the budget dto
        /// </summary>
        public IEnumerable<BudgetViewObject> BudgetDto
        {
            get
            {
              return _budget;
            }
            set
            {
                _budget = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        ///  Get or Set the fare dto.
        /// </summary>
        public IEnumerable<FareViewObject> FareDto
        {
            get
            {
                return _fare;
            }
            set
            {
                _fare = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        ///  Set or Get the vehicle group dto.
        /// </summary>
        public IEnumerable<VehicleGroupViewObject> VehicleGroupDto
        {
            get => _vehicleGroup;
            set => _vehicleGroup = value; 
        }
        /// <summary>
        ///  Set or get the brokerdto
        /// </summary>
        public IEnumerable<CommissionAgentSummaryViewObject> BrokerDto
        {
            get => _broker;

        set => _broker = value;
        }
        public IEnumerable<OfficeViewObject> OfficeDto
        {   get => _office1;
            set => _office1 = value;
        }
        public IEnumerable<VehicleSummaryViewObject> VehicleDto
        {   get => _vehicleSummary;
            set => _vehicleSummary = value;
        }
        public IEnumerable<ClientSummaryExtended> DriverDto3
        {
            get => _driver3;
            set => _driver3 = value;
        }
        public IEnumerable<ClientSummaryExtended> DriverDto4
        {
            get => _driver4;
            set => _driver4 = value;
        }
        public IEnumerable<ClientSummaryExtended> DriverDto5
        {
            get => _driver5;
            set => _driver5 = value;
        }
        public IEnumerable<ClientSummaryExtended> DriverDto2
        {
            get => _driver2;
            set => _driver2 = value;
        }
        public IEnumerable<CityViewObject> CityDto3
        {
            get => _city3;
            set => _city3 = value;
        }
        public IEnumerable<CountryViewObject> DriverCountryList { get => _country2; set => _country2 = value; }
        public IEnumerable<CountryViewObject> CountryDto3 { get => _country3; set => _country3 = value; }
        public IEnumerable<ProvinceViewObject> ProvinceDto3 { get => _province3; set => _province3 = value; }
        public IEnumerable<OrigenViewObject> OriginDto { get ; set ; }
        public IEnumerable<BookingMediaViewObject> BookingMediaDto { get ; set; }
        public IEnumerable<BookingTypeViewObject> BookingTypeDto { get; set ; }
        public IEnumerable<AgencyEmployeeViewObject> AgencyEmployeeDto { get; set ; }
        public IEnumerable<ContactsViewObject> ContactsDto1 { get; set; }
        public IEnumerable<PaymentFormViewObject> PaymentFormDto { get ; set ; }
        public IEnumerable<PrintingTypeViewObject> PrintingTypeDto { get; set; }
        public IEnumerable<VehicleActivitiesViewObject> VehicleActivitiesDto { get ; set; }
        public IEnumerable<BudgetSummaryViewObject> BookingBudget { get; set; }
        public IEnumerable<DeliveringPlaceViewObject> DepartureDeliveryDto { set; get; }
        public IEnumerable<DeliveringPlaceViewObject> PlaceOfReturnDto { set; get; }
        public IEnumerable<CountryViewObject> SecondDriverCountryDto { get ; set; }
        public IEnumerable<CityViewObject> SecondDriverCityDto { get; set; }
        public IEnumerable<ProvinceViewObject> SecondDriverProvinceDto { get ; set; }
        public IEnumerable<BookingRefusedViewObject> BookingRefusedDto { get; set; }
    }
}
