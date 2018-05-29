using System.Collections.Generic;
using KarveDataServices;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;

namespace DataAccessLayer.Model
{
    /// <summary>
    ///  This models the reservation data.
    /// </summary>
    public class Reservation: IBookingData
    {
        /// <summary>
        /// Get or Set the booking data. Value to be used.
        /// </summary>
        public BookingDto Value { get; set; }
        /// <summary>
        /// Get or Set the Helper data
        /// </summary>
        public IHelperBase Helper { get; set; }
        /// <summary>
        ///  Get or Set if the value is valid.
        /// </summary>
        public bool IsValid { get; set; }
       /// <summary>
       ///  List of reservations.
       /// </summary>
        public IEnumerable<BookingItemsDto> ItemsDtos { get; set; }
    }
}
