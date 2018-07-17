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
    }
}
