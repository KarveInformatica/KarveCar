// ------------------------------------------------------------------------------------------------------------------
// <copyright file="IBookingService.cs" company="KarveInformatica S.L.">
//   
// </copyright>
// <summary>
//   Business logic interface for the reservation process.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BookingModule.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using KarveCar.Model;

    using KarveDataServices.DataObjects;
    using KarveDataServices.ViewObjects;

    /// <summary>
    /// Business logic interface for the reservation process.
    /// </summary>
    public interface IBookingService
    {


        /// <summary>
        ///  True if a change can be triggered.
        /// </summary>
        /// <param name="eventData">Event data containing changed fields</param>
        /// <param name="data">Domain data to be used.</param>
        /// <returns>True or false if a change has been done.</returns>
        Task<bool> IsChangeTriggered(IDictionary<string, object> eventData, IBookingData data);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventData"></param>
        /// <param name="data"></param>
        /// <returns></returns>

        Task<bool> TiggerAReservationQuotation(IDictionary<string, object> eventData, IBookingData data);


        /// <summary>
        ///  Validate if a reservation can be added.
        /// </summary>
        /// <param name="data">Data to be added</param>
        /// <returns>if the validation is not correct</returns>
     

        bool CanAddReservation(IBookingData data);
        
        /// <summary>
        ///  Compute Booking total
        /// </summary>
        /// <param name="data">Data objeect to be used.</param>
        /// <returns></returns>

        void ComputeBookingTotal(IBookingData data);

        /// <summary>
        /// Business service for the reservation quotation.
        /// </summary>
        /// <param name="fare">Type of the fare</param>
        /// <param name="group">Type of the group</param>
        /// <param name="days">Number of days</param>
        /// <param name="daysDiv">Number of days divisional</param>
        /// <param name="discount">Value of discount</param>
        /// <returns>A list of booking view object relative to the function.</returns>
        Task<IEnumerable<BookingItemsViewObject>> ReservationQuotation(
            string fare,
            string group,
            short? days,
            short? daysDiv,
            int discount);

    }
}
