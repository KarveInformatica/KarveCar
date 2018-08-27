using KarveDataServices.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveDataServices;
using KarveDataServices.ViewObjects;
using System.Collections.ObjectModel;

namespace DataAccessLayer.DtoWrapper
{
    /// <summary>
    ///  This is a null reservation to be used.
    /// </summary>
    public class NullReservation : IBookingData
    {
        private BookingViewObject _bookingDto;
        private bool _isValid;
        private IHelperBase _base;
        private IEnumerable<BookingItemsViewObject> _bookingItems;
        private IEnumerable<ContractSummaryDto> _contracts;
        private IEnumerable<ClientSummaryExtended> _clients;
        private IEnumerable<ClientSummaryExtended> _drivers;
        public NullReservation()
        {
            _bookingDto = new BookingViewObject();
            _isValid = false;
            _bookingItems = new List<BookingItemsViewObject>();
            _base = new HelperBase();
            _contracts = new ObservableCollection<ContractSummaryDto>();
            _clients = new ObservableCollection<ClientSummaryExtended>();
            _drivers = new ObservableCollection<ClientSummaryExtended>();
        }
        /// <summary>
        ///  Set or Get the Value.
        /// </summary>
        public BookingViewObject Value { get => new BookingViewObject(); set => _bookingDto = value; }
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
        public IEnumerable<BookingItemsViewObject> ItemsDtos { get => _bookingItems; set => _bookingItems = value; }
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
        public IEnumerable<OfficeViewObject> ReservationOfficeDeparture { get; set; } = new List<OfficeViewObject>();
        public IEnumerable<OfficeViewObject> ReservationOfficeArrival { get ; set ; } = new List<OfficeViewObject>();
       
        public IEnumerable<FareViewObject> FareDto { get; set; } = new List<FareViewObject>();
        public IEnumerable<VehicleGroupViewObject> VehicleGroupDto { get; set; } = new List<VehicleGroupViewObject>();
        public IEnumerable<CommissionAgentSummaryViewObject> BrokerDto { get; set; } = new List<CommissionAgentSummaryViewObject>();
        public IEnumerable<OfficeViewObject> OfficeDto { get; set; } = new List<OfficeViewObject>();
        public IEnumerable<VehicleSummaryViewObject> VehicleDto { get;set;} = new List<VehicleSummaryViewObject>();
        public IEnumerable<ClientSummaryExtended> DriverDto3 { get; set; } = new List<ClientSummaryExtended>();
        public IEnumerable<ClientSummaryExtended> DriverDto4 { get; set; } = new List<ClientSummaryExtended>();
        public IEnumerable<ClientSummaryExtended> DriverDto5 { get; set; } = new List<ClientSummaryExtended>();
        public IEnumerable<ClientSummaryExtended> DriverDto2 { get; set; } = new List<ClientSummaryExtended>();
        public IEnumerable<CityViewObject> CityDto3 { get; set; } = new List<CityViewObject>();
        public IEnumerable<CountryViewObject> DriverCountryList { get; set; } = new List<CountryViewObject>();
        public IEnumerable<CountryViewObject> CountryDto3 { get; set; } = new List<CountryViewObject>();
        public IEnumerable<ProvinceViewObject> ProvinceDto3 { get; set; } = new List<ProvinceViewObject>();
        public IEnumerable<OrigenViewObject> OriginDto { get; set; } = new List<OrigenViewObject>();
        public IEnumerable<BookingMediaViewObject> BookingMediaDto { get; set; } = new List<BookingMediaViewObject>();
        public IEnumerable<BookingTypeViewObject> BookingTypeDto { get; set; } = new List<BookingTypeViewObject>();
        public IEnumerable<AgencyEmployeeViewObject> AgencyEmployeeDto { get; set; } = new List<AgencyEmployeeViewObject>();
        public IEnumerable<ContactsViewObject> ContactsDto1 { get; set; } = new List<ContactsViewObject>();
        public IEnumerable<PaymentFormViewObject> PaymentFormDto { get; set; } = new List<PaymentFormViewObject>();
        public IEnumerable<PrintingTypeViewObject> PrintingTypeDto { get; set ; }
        public IEnumerable<VehicleActivitiesViewObject> VehicleActivitiesDto { get; set; }
        public IEnumerable<BudgetSummaryViewObject> BookingBudget { get ; set ; }
        public IEnumerable<BudgetViewObject> BudgetDto { get ; set; }
        public IEnumerable<CompanyViewObject> CompanyDto { get; set; }
        public IEnumerable<DeliveringPlaceViewObject> DepartureDeliveryDto { get; set; }
        public IEnumerable<DeliveringPlaceViewObject> PlaceOfReturnDto { get ; set ; }
        public IEnumerable<CountryViewObject> SecondDriverCountryDto { get; set; }
        public IEnumerable<CityViewObject> SecondDriverCityDto { get ; set ; }
        public IEnumerable<ProvinceViewObject> SecondDriverProvinceDto { get; set; }
        public IEnumerable<BookingRefusedViewObject> BookingRefusedDto { get ; set; }
    }
}
