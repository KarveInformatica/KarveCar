using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveDataServices.DataTransferObject;

namespace KarveDataServices.DataObjects
{
    /// <summary>
    ///  This is an interface for booking the data
    /// </summary>
    public interface IBookingData : IValidDomainObject, IValueObject<BookingDto>
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
        ///  Set or Get the Summary of drivers.
        /// </summary>
        IEnumerable<BudgetDto> BudgetDto { get; set; }
        IEnumerable<ClientSummaryExtended> Drivers { set; get; }
        IEnumerable<DeliveringPlaceDto> DepartureDeliveryDto { set; get; }
        IEnumerable<OfficeDtos> ReservationOfficeDeparture { get; set; }
        IEnumerable<OfficeDtos> ReservationOfficeArrival { get; set; }
        IEnumerable<FareDto> FareDto { get; set; }
        IEnumerable<VehicleGroupDto> VehicleGroupDto { get; set; }
        IEnumerable<CommissionAgentSummaryDto> BrokerDto { get; set; }
        IEnumerable<OfficeDtos> OfficeDto { get; set; }
        IEnumerable<VehicleSummaryDto> VehicleDto { get; set; }
        IEnumerable<ClientSummaryExtended> DriverDto3 { get; set; }
        IEnumerable<ClientSummaryExtended> DriverDto4 { get; set; }
        IEnumerable<ClientSummaryExtended> DriverDto5 { get; set; }
        IEnumerable<ClientSummaryExtended> DriverDto2 { get; set; }
        IEnumerable<CityDto> CityDto3 { get; set; }
        IEnumerable<CountryDto> DriverCountryList { get; set; }
        IEnumerable<CountryDto> CountryDto3 { get; set; }
        IEnumerable<ProvinciaDto> ProvinceDto3 { get; set; }
        IEnumerable<OrigenDto> OriginDto { get; set; }
        IEnumerable<BookingMediaDto> BookingMediaDto { get; set; }
        IEnumerable<BookingTypeDto> BookingTypeDto { get; set; }
        IEnumerable<AgencyEmployeeDto> AgencyEmployeeDto { get; set; }
        IEnumerable<ContactsDto> ContactsDto1 { get; set; }
        IEnumerable<PaymentFormDto> PaymentFormDto { get; set; }
        IEnumerable<PrintingTypeDto> PrintingTypeDto { get; set; }
        IEnumerable<VehicleActivitiesDto> VehicleActivitiesDto { get; set; }
        IEnumerable<BudgetSummaryDto> BookingBudget { get; set; }
        IEnumerable<CompanyDto> CompanyDto { get; set; }
        IEnumerable<DeliveringPlaceDto> PlaceOfReturnDto { set; get; }
        IEnumerable<CountryDto> SecondDriverCountryDto { set; get; }
        IEnumerable<CityDto> SecondDriverCityDto { set; get; }
        IEnumerable<ProvinciaDto> SecondDriverProvinceDto { set; get; }
    }
}
