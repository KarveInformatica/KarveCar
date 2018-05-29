using System.Collections.Generic;
using System.Threading.Tasks;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;

namespace KarveDataServices
{
    /// <summary>
    ///  This is a data service to handle the booking data retrieval.
    /// </summary>
    public interface IBookingDataService: IPageCounter, IIdentifier
    {
        /// <summary>
        ///  Returns the list of invoices.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<BookingSummaryDto>> GetSummaryAllAsync();
        /// <summary>
        ///  This gets the booking data object asynchronously
        /// </summary>
        /// <param name="code">Invoice code to fetch the data</param>
        /// <returns>The invoice data.</returns>
        Task<IBookingData> GetDoAsync(string code);
        /// <summary>
        /// Save or update an invoice
        /// </summary>
        /// <param name="bookingData">Data to book</param>
        /// <returns></returns>
        Task<bool> SaveAsync(IBookingData bookingData);
        /// <summary>
        /// Generate a new booking.
        /// </summary>
        /// <param name="value">Booking value</param>
        /// <returns>Returns true if the data has been saved</returns>
        IBookingData GetNewDo(string value);
        /// <summary>
        /// Data to await for in the invoice.
        /// </summary>
        /// <param name="booking">Booking data</param>
        /// <returns>Delete the booking values</returns>
        Task<bool> DeleteAsync(IBookingData booking);
        /// <summary>
        /// Load the paged summary asynchronously.
        /// </summary>
        /// <param name="index">Index inside the paged stuff.</param>
        /// <param name="pageSize">Size of the page</param>
        /// <returns></returns>
        Task<IEnumerable<BookingSummaryDto>> GetPagedSummaryDoAsync(int index, int pageSize);
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
    }
}
