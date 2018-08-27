using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveDataServices.ViewObjects;


namespace KarveDataServices.DataObjects
{
    /// <summary>
    ///  This is an interface for booking the data
    /// </summary>
    public interface IBookingData : IValidDomainObject, IValueObject<BookingViewObject>
    {
        // Helpers.
        /// <summary>
        ///  Set or Get the Summary of contracts.
        /// </summary>
        IEnumerable<ContractSummaryDto> Contracts { set; get; }
        /// <summary>
        ///  Set or Get the summary of clients.
        /// </summary>
        IEnumerable<ClientSummaryExtended> Clients { set; get; }
        /// <summary>
        ///  Set or Get all possible budget
        /// </summary>
        IEnumerable<BudgetViewObject> BudgetDto { get; set; }
        // Get or Set possible drivers
        IEnumerable<ClientSummaryExtended> Drivers { set; get; }
        IEnumerable<DeliveringPlaceViewObject> DepartureDeliveryDto { set; get; }
        IEnumerable<OfficeViewObject> ReservationOfficeDeparture { get; set; }
        IEnumerable<OfficeViewObject> ReservationOfficeArrival { get; set; }
        IEnumerable<FareViewObject> FareDto { get; set; }
        IEnumerable<VehicleGroupViewObject> VehicleGroupDto { get; set; }
        IEnumerable<CommissionAgentSummaryViewObject> BrokerDto { get; set; }
        IEnumerable<OfficeViewObject> OfficeDto { get; set; }
        IEnumerable<VehicleSummaryViewObject> VehicleDto { get; set; }
        IEnumerable<ClientSummaryExtended> DriverDto3 { get; set; }
        IEnumerable<ClientSummaryExtended> DriverDto4 { get; set; }
        IEnumerable<ClientSummaryExtended> DriverDto5 { get; set; }
        IEnumerable<ClientSummaryExtended> DriverDto2 { get; set; }
        IEnumerable<CityViewObject> CityDto3 { get; set; }
        IEnumerable<CountryViewObject> DriverCountryList { get; set; }
        IEnumerable<CountryViewObject> CountryDto3 { get; set; }
        IEnumerable<ProvinceViewObject> ProvinceDto3 { get; set; }
        IEnumerable<OrigenViewObject> OriginDto { get; set; }
        IEnumerable<BookingMediaViewObject> BookingMediaDto { get; set; }
        IEnumerable<BookingTypeViewObject> BookingTypeDto { get; set; }
        IEnumerable<AgencyEmployeeViewObject> AgencyEmployeeDto { get; set; }
        IEnumerable<ContactsViewObject> ContactsDto1 { get; set; }
        IEnumerable<PaymentFormViewObject> PaymentFormDto { get; set; }
        IEnumerable<PrintingTypeViewObject> PrintingTypeDto { get; set; }
        IEnumerable<VehicleActivitiesViewObject> VehicleActivitiesDto { get; set; }
        IEnumerable<BudgetSummaryViewObject> BookingBudget { get; set; }
        IEnumerable<CompanyViewObject> CompanyDto { get; set; }
        IEnumerable<DeliveringPlaceViewObject> PlaceOfReturnDto { set; get; }
        IEnumerable<CountryViewObject> SecondDriverCountryDto { set; get; }
        IEnumerable<CityViewObject> SecondDriverCityDto { set; get; }
        IEnumerable<ProvinceViewObject> SecondDriverProvinceDto { set; get; }
        IEnumerable<BookingRefusedViewObject> BookingRefusedDto { get; set; }
    }
}
