using System.Collections.Generic;
using System.Collections.ObjectModel;
using KarveDataServices;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;
using Prism.Mvvm;

namespace DataAccessLayer.Model
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
            Value = new BookingDto();
            Valid = true;
            
        }

        /// <summary>
        /// Get or Set the booking data. Value to be used.
        /// </summary>
        public BookingDto Value { get; set; }

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
        private IEnumerable<OfficeDtos> _reservationOfficeDeparture;
        private IEnumerable<OfficeDtos> _reservationOfficeArrival;
        private IEnumerable<OfficeDtos> _office1;
        private IEnumerable<BudgetDto> _budget;
        private IEnumerable<FareDto> _fare;
        private IEnumerable<VehicleGroupDto> _vehicleGroup;
        private IEnumerable<CommissionAgentSummaryDto> _broker;
        private IEnumerable<VehicleSummaryDto> _vehicleSummary;
        private IEnumerable<ClientSummaryExtended> _driver2;
        private IEnumerable<ClientSummaryExtended> _driver3;
        private IEnumerable<ClientSummaryExtended> _driver4;
        private IEnumerable<ClientSummaryExtended> _driver5;
        private IEnumerable<CityDto> _city3;
        private IEnumerable<CountryDto> _country2;
        private IEnumerable<CountryDto> _country3;
        private IEnumerable<CountryDto> _country4;
        private IEnumerable<ProvinciaDto> _province3;
        private IEnumerable<CompanyDto> _company;


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
        public IEnumerable<CompanyDto> CompanyDto {
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
        public IEnumerable<OfficeDtos> ReservationOfficeDeparture
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
        public IEnumerable<OfficeDtos> ReservationOfficeArrival
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
        public IEnumerable<BudgetDto> BudgetDto
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
        public IEnumerable<FareDto> FareDto
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
        public IEnumerable<VehicleGroupDto> VehicleGroupDto
        {
            get => _vehicleGroup;
            set => _vehicleGroup = value; 
        }
        /// <summary>
        ///  Set or get the brokerdto
        /// </summary>
        public IEnumerable<CommissionAgentSummaryDto> BrokerDto
        {
            get => _broker;

        set => _broker = value;
        }
        public IEnumerable<OfficeDtos> OfficeDto
        {   get => _office1;
            set => _office1 = value;
        }
        public IEnumerable<VehicleSummaryDto> VehicleDto
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
        public IEnumerable<CityDto> CityDto3
        {
            get => _city3;
            set => _city3 = value;
        }
        public IEnumerable<CountryDto> DriverCountryList { get => _country2; set => _country2 = value; }
        public IEnumerable<CountryDto> CountryDto3 { get => _country3; set => _country3 = value; }
        public IEnumerable<ProvinciaDto> ProvinceDto3 { get => _province3; set => _province3 = value; }
        public IEnumerable<OrigenDto> OriginDto { get ; set ; }
        public IEnumerable<BookingMediaDto> BookingMediaDto { get ; set; }
        public IEnumerable<BookingTypeDto> BookingTypeDto { get; set ; }
        public IEnumerable<AgencyEmployeeDto> AgencyEmployeeDto { get; set ; }
        public IEnumerable<ContactsDto> ContactsDto1 { get; set; }
        public IEnumerable<PaymentFormDto> PaymentFormDto { get ; set ; }
        public IEnumerable<PrintingTypeDto> PrintingTypeDto { get; set; }
        public IEnumerable<VehicleActivitiesDto> VehicleActivitiesDto { get ; set; }
        public IEnumerable<BudgetSummaryDto> BookingBudget { get; set; }
        public IEnumerable<DeliveringPlaceDto> DepartureDeliveryDto { set; get; }
        public IEnumerable<DeliveringPlaceDto> PlaceOfReturnDto { set; get; }
        public IEnumerable<CountryDto> SecondDriverCountryDto { get ; set; }
        public IEnumerable<CityDto> SecondDriverCityDto { get; set; }
        public IEnumerable<ProvinciaDto> SecondDriverProvinceDto { get ; set; }
        public IEnumerable<BookingRefusedDto> BookingRefusedDto { get; set; }
    }
}
