using KarveDataServices.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using System.Collections.ObjectModel;

namespace DataAccessLayer.Model
{
    /// <summary>
    ///  This is a null reservation to be used.
    /// </summary>
    public class NullReservation : IBookingData
    {
        private BookingDto _bookingDto;
        private bool _isValid;
        private IHelperBase _base;
        private IEnumerable<BookingItemsDto> _bookingItems;
        private IEnumerable<ContractSummaryDto> _contracts;
        private IEnumerable<ClientSummaryExtended> _clients;
        private IEnumerable<ClientSummaryExtended> _drivers;
        public NullReservation()
        {
            _bookingDto = new BookingDto();
            _isValid = false;
            _bookingItems = new List<BookingItemsDto>();
            _base = new HelperBase();
            _contracts = new ObservableCollection<ContractSummaryDto>();
            _clients = new ObservableCollection<ClientSummaryExtended>();
            _drivers = new ObservableCollection<ClientSummaryExtended>();
        }
        /// <summary>
        ///  Set or Get the Value.
        /// </summary>
        public BookingDto Value { get => new BookingDto(); set => _bookingDto = value; }
        /// <summary>
        ///  Thi
        /// </summary>
        public IHelperBase Helper { get => _base; set => _base= value; }
        /// <summary>
        ///  Set or Get the value if it is valid
        /// </summary>
        public bool IsValid { get => _isValid; set => _isValid = value; }
        /// <summary>
        ///  Set or Get the items dto.
        /// </summary>
        public IEnumerable<BookingItemsDto> ItemsDtos { get => _bookingItems; set => _bookingItems = value; }
        /// <summary>
        ///  Set or Get Contracts
        /// </summary>
        public IEnumerable<ContractSummaryDto> Contracts { get => _contracts; set => _contracts = value; }
        /// <summary>
        ///  Set or Get Clients.
        /// </summary>
        public IEnumerable<ClientSummaryExtended> Clients { get => _clients; set => _clients =value; }
        /// <summary>
        ///  Ser or Get Drivers.
        /// </summary>
        public IEnumerable<ClientSummaryExtended> Drivers { get => _drivers; set => _drivers = value; }
        public bool Valid { get; set; } = false;
        public IEnumerable<OfficeDtos> ReservationOfficeDeparture { get; set; } = new List<OfficeDtos>();
        public IEnumerable<OfficeDtos> ReservationOfficeArrival { get ; set ; } = new List<OfficeDtos>();
       
        public IEnumerable<FareDto> FareDto { get; set; } = new List<FareDto>();
        public IEnumerable<VehicleGroupDto> VehicleGroupDto { get; set; } = new List<VehicleGroupDto>();
        public IEnumerable<CommissionAgentSummaryDto> BrokerDto { get; set; } = new List<CommissionAgentSummaryDto>();
        public IEnumerable<OfficeDtos> OfficeDto { get; set; } = new List<OfficeDtos>();
        public IEnumerable<VehicleSummaryDto> VehicleDto { get;set;} = new List<VehicleSummaryDto>();
        public IEnumerable<ClientSummaryExtended> DriverDto3 { get; set; } = new List<ClientSummaryExtended>();
        public IEnumerable<ClientSummaryExtended> DriverDto4 { get; set; } = new List<ClientSummaryExtended>();
        public IEnumerable<ClientSummaryExtended> DriverDto5 { get; set; } = new List<ClientSummaryExtended>();
        public IEnumerable<ClientSummaryExtended> DriverDto2 { get; set; } = new List<ClientSummaryExtended>();
        public IEnumerable<CityDto> CityDto3 { get; set; } = new List<CityDto>();
        public IEnumerable<CountryDto> DriverCountryList { get; set; } = new List<CountryDto>();
        public IEnumerable<CountryDto> CountryDto3 { get; set; } = new List<CountryDto>();
        public IEnumerable<ProvinciaDto> ProvinceDto3 { get; set; } = new List<ProvinciaDto>();
        public IEnumerable<OrigenDto> OriginDto { get; set; } = new List<OrigenDto>();
        public IEnumerable<BookingMediaDto> BookingMediaDto { get; set; } = new List<BookingMediaDto>();
        public IEnumerable<BookingTypeDto> BookingTypeDto { get; set; } = new List<BookingTypeDto>();
        public IEnumerable<AgencyEmployeeDto> AgencyEmployeeDto { get; set; } = new List<AgencyEmployeeDto>();
        public IEnumerable<ContactsDto> ContactsDto1 { get; set; } = new List<ContactsDto>();
        public IEnumerable<PaymentFormDto> PaymentFormDto { get; set; } = new List<PaymentFormDto>();
        public IEnumerable<PrintingTypeDto> PrintingTypeDto { get; set ; }
        public IEnumerable<VehicleActivitiesDto> VehicleActivitiesDto { get; set; }
        public IEnumerable<BudgetSummaryDto> BookingBudget { get ; set ; }
        public IEnumerable<BudgetDto> BudgetDto { get ; set; }
        public IEnumerable<CompanyDto> CompanyDto { get; set; }
        public IEnumerable<DeliveringPlaceDto> DepartureDeliveryDto { get; set; }
        public IEnumerable<DeliveringPlaceDto> PlaceOfReturnDto { get ; set ; }
        public IEnumerable<CountryDto> SecondDriverCountryDto { get; set; }
        public IEnumerable<CityDto> SecondDriverCityDto { get ; set ; }
        public IEnumerable<ProvinciaDto> SecondDriverProvinceDto { get; set; }
        public IEnumerable<BookingRefusedDto> BookingRefusedDto { get ; set; }
    }
}
