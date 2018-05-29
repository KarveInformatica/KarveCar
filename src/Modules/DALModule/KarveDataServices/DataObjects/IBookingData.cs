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
    public interface IBookingData
    {
        /// <summary>
        ///  Data object to be binded outside.
        /// </summary>
        BookingDto Value { get; set; }
        /// <summary>
        ///  Helper object for setting things
        /// </summary>
        IHelperBase Helper { get; set; }
        /// <summary>
        ///  Returns the profile, if it is valid.
        /// </summary>
        bool IsValid { get; set; }
        /// <summary>
        /// Get the items that are in a booking place.
        /// </summary>
        IEnumerable<BookingItemsDto> ItemsDtos { get; set; }


    }
}
