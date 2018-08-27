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
        Task<bool> IsChangeTriggered(IDictionary<string, object> eventData, IBookingData data);
    }
}
