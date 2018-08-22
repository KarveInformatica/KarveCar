using System.Collections.Generic;
using System.Threading.Tasks;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;

namespace KarveDataServices
{
    /// <summary>
    ///  This is a data service to handle the booking data retrieval.
    /// </summary>
    public interface IBookingDataService: IPageCounter, 
                                          IIdentifier, 
                                          IDataProvider<IBookingData, BookingSummaryDto>,
                                          IDataSearch<IBookingData, BookingSummaryDto>
    {
        /// <summary>
        ///  Booking items data object
        /// </summary>
        /// <returns>Booking items data transfer</returns>
        Task<IEnumerable<BookingItemsDto>> GetBookingItemsAsync(IBookingData data);
        /// <summary>
        /// Return the number of lines given the reservation code;
        /// </summary>
        /// <param name="code">Reservation number</param>
        /// <returns>The number of items or -1 in case of any errors.</returns>
        Task<int> GetBookingItemsCount(string code);
        /// <summary>
        ///  Returns the next line in the lines
        /// </summary>
        /// <returns>
        /// The number of lines inside the reservation.
        /// </returns>
        long GetNextLineId();

    }
}
