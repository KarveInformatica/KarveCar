// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IBookingDataService.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the IBookingDataService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



namespace KarveDataServices
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DataObjects;
    using ViewObjects;

    /// <inheritdoc />
    /// <summary>
    ///  This is a data service to handle the booking data retrieval.
    /// </summary>
    public interface IBookingDataService : IPageCounter, 
                                          IIdentifier, 
                                          IDataProvider<IBookingData, BookingSummaryViewObject>,
                                          IDataSearch<IBookingData, BookingSummaryViewObject>
    {
        /// <summary>
        ///  Booking items data object
        /// </summary>
        /// <returns>Booking items data transfer</returns>
        Task<IEnumerable<BookingItemsViewObject>> GetBookingItemsAsync(IBookingData data);
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
       

        /// <summary>
        ///  Returns the reservation quotation.
        /// </summary>
        /// <param name="fare">Fare to be used.</param>
        /// <param name="group">Group to be used.</param>
        /// <param name="days">Days to be used.</param>
        /// <param name="daysDiv">Div days to be used.</param>
        /// <param name="discount">Possible discount to be used.</param>
        /// <returns>A list of booking items</returns>
        Task<IEnumerable<BookingItemsViewObject>> GetReservationQuotation(
            string fare,
            string group,
            short? days,
            short? daysDiv,
            int discount);
    }
}
