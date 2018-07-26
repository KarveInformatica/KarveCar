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
    public interface IBookingData : IValidDomainObject
    {
        /// <summary>
        ///  Data object to be binded outside.
        /// </summary>
        BookingDto Value { get; set; }
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
        IEnumerable<ClientSummaryExtended> Drivers { set; get; }
        IEnumerable<OfficeDtos> ReservationOfficeDeparture { get; set; }
        IEnumerable<OfficeDtos> ReservationOfficeArrival { get; set; }
        IEnumerable<BudgetDto> BudgetDto { get; set; }
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
        IEnumerable<CountryDto> Country2Dto { get; set; }
        IEnumerable<CountryDto> CountryDto3 { get; set; }
        IEnumerable<ProvinciaDto> ProvinceDto3 { get; set; }
    }
}
