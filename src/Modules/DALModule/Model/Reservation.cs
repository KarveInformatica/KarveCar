using System.Collections.Generic;
using KarveDataServices;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;
using Prism.Mvvm;

namespace DataAccessLayer.Model
{
    /// <summary>
    ///  Wrapper that allows us to deliver  its dto and a set of related things for the searchboxes.
    /// </summary>
    public class Reservation : BindableBase, IBookingData
    {
        public Reservation()
        {
            Value = new BookingDto();
            Valid = true;

            _contracts = new List<ContractSummaryDto>();
            _clients = new List<ClientSummaryExtended>();
            _drivers = new List<ClientSummaryExtended>();
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
        public bool Valid {
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
            get => _reservationOfficeDeparture;
            set => _reservationOfficeDeparture = value;
        }
        /// <summary>
        ///  Get or set the reservation office arrival
        /// </summary>
        public IEnumerable<OfficeDtos> ReservationOfficeArrival
        { get => _reservationOfficeArrival;
            set => _reservationOfficeArrival = value; }
        /// <summary>
        ///  Get ot set the budget dto
        /// </summary>
        public IEnumerable<BudgetDto> BudgetDto
        {
            get => _budget;
            set => _budget = value;
        }
        /// <summary>
        ///  Get or Set the fare dto.
        /// </summary>
        public IEnumerable<FareDto> FareDto
        {
            get => _fare;
            set => _fare = value;
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
        public IEnumerable<CountryDto> Country2Dto { get => _country2; set => _country2 = value; }
        public IEnumerable<CountryDto> CountryDto3 { get => _country3; set => _country3 = value; }
        public IEnumerable<ProvinciaDto> ProvinceDto3 { get => _province3; set => _province3 = value; }
    }
}
