// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BookingService.cs" company="KarveInformatica S.L.">
//   
// </copyright>
// <summary>
//   Business service for the change.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BookingModule.Service
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Threading.Tasks;
    using KarveDataServices;
    using KarveDataServices.DataObjects;
    using KarveDataServices.ViewObjects;

    /// <summary>
    /// Business service for the change.
    /// </summary>
    public class BookingService : IBookingService
    {
        /// <summary>
        /// DataService. Service for accessing to data.
        /// </summary>
        private readonly IDataServices dataService;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookingService"/> class.
        /// </summary>
        /// <param name="dataServices">
        /// DataService. Service interface for accessing to the data access layer.
        /// </param>
        public BookingService(IDataServices dataServices)
        {
            this.dataService = dataServices;
        }



        /// <summary>
        ///  Trigger a reservation quotation for the days.
        /// </summary>
        /// <param name="eventData">Changed data from the user</param>
        /// <param name="data">Domain data to be used.</param>
        /// <returns></returns>
       
        public async Task<bool> TiggerAReservationQuotation(IDictionary<string, object> eventData, IBookingData data)
        {
            // in this case we just check if the office is changed.
            if (eventData.ContainsKey("Field"))
            {
                var dataObject = data.Value;
                var field = eventData["Field"] as string;
                switch (field)
                {
                    case "TARIFA_RES1":
                    case "GRUPO_RES1":
                    case "DIAS_RES1":
                    {
                        var quotationBooking = await ReservationQuotation(dataObject.TARIFA_RES1, dataObject.GRUPO_RES1,
                            dataObject.DIAS_RES1, dataObject.DIAS_RES1, 0).ConfigureAwait(false);
                        data.Value.Items = quotationBooking;
                            
                        return true;
                    }
                    default:
                    {
                        return false;
                    }
                }
            }
     
            return false;
        }

        /// <summary>
        /// The can add reservation.
        /// </summary>
        /// <param name="data">
        /// The data.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool CanAddReservation(IBookingData data)
        {
            return false;
        }

        public void ComputeBookingTotal(IBookingData data)
        {
            
        }

        /// <summary>
        ///  Reservation quotation.
        ///  This does "the cotiza" in english reservation quotation.
        /// </summary>
        /// <param name="fare">Fare to be quoted</param>
        /// <param name="group">Group to be used</param>
        /// <param name="days">Days to be used</param>
        /// <param name="daysDiv">Days prev.</param>
        /// <param name="discount">Discount to be used.</param>
        /// <returns>A list of booking items view object</returns>
        public async Task<IEnumerable<BookingItemsViewObject>> ReservationQuotation(string fare, string group, short? days, short? daysDiv, int discount)
        {
            var currentDays = days ?? 0;
            var currentDaysPrev = daysDiv ?? 0;
            var service = this.dataService.GetBookingDataService();
            var items = await service.GetReservationQuotation(fare, group, currentDays, currentDaysPrev, discount).ConfigureAwait(false);
            var bookingItemsViewObjects = items as BookingItemsViewObject[] ?? items.ToArray();
            foreach (var booking in bookingItemsViewObjects)
            {
                if (string.IsNullOrEmpty(booking.Days))
                {
                    booking.Days = "0";
                }
            }
            return bookingItemsViewObjects;
        }
         
        /// <summary>
        /// Every change of the view can trigger business rules.
        /// This function is the entry point foreach change in the fields.
        /// It checks if the changes can trigger business rules,
        /// and if they trigger it execute and update the data.
        /// </summary>
        /// <param name="eventData">
        /// Event dictionary that contains the changed data.
        /// </param>
        /// <param name="data">
        /// Aggregate that contains all needed information to be update.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>. Returr
        /// </returns>
        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1101:PrefixLocalCallsWithThis", Justification = "Reviewed. Suppression is OK here.")]
        public async Task<bool> IsChangeTriggered(IDictionary<string, object> eventData, IBookingData data)
        {
            var returnValue = false;
            if (eventData.ContainsKey("Field"))
            {
                var dataObject = data.Value;
                var field = eventData["Field"] as string;
                data.CompanyDto = await IsOfficeChanged(eventData, data).ConfigureAwait(false);
                returnValue = true;
            }
            WhenDateChanged(eventData, data);
            WhenDaysChanged(eventData, data);
            return true;
        }

        /// <summary>
        /// The when days changed.
        /// </summary>
        /// <param name="eventData">
        /// The event data.
        /// </param>
        /// <param name="data">
        /// The data.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool WhenDaysChanged(IDictionary<string, object> eventData, IBookingData data)
        {

            if (eventData.ContainsKey("DataSourcePath"))
            {
                var dataObject = data.Value;
                var field = eventData["DataSourcePath"] as string;
                if ((field == "DIAS_RES1") && 
                    dataObject.DIAS_RES1.HasValue
                    && dataObject.FSALIDA_RES1.HasValue)
                {
                    var days = dataObject.DIAS_RES1;
                    dataObject.FPREV_RES1 = dataObject.FSALIDA_RES1.Value.AddDays(days.Value);
                    return true;
                }                
            }
            return false;
        }

        /// <summary>
        /// The when date changed.
        /// </summary>
        /// <param name="eventData">
        /// The event data.
        /// </param>
        /// <param name="data">
        /// The data.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool WhenDateChanged(IDictionary<string, object> eventData, IBookingData data)
        {
            if (eventData.ContainsKey("Field"))
            {
                var dataObject = data.Value;
                var field = eventData["Field"] as string;
                switch (field)
                {
                    case "FSALIDA_RES1":
                    {
                        if (dataObject.DIAS_RES1.HasValue && dataObject.FSALIDA_RES1.HasValue)
                        {
                            dataObject.FPREV_RES1 = dataObject.FSALIDA_RES1.Value.AddDays(dataObject.DIAS_RES1.Value);
                        }
                        else if (dataObject.FSALIDA_RES1.HasValue && dataObject.FPREV_RES1.HasValue)
                        {
                            var arrivalDate = dataObject.FPREV_RES1;
                            var span = arrivalDate - dataObject.FSALIDA_RES1;
                            dataObject.DIAS_RES1 = (short)span.Value.Days;

                        }
                       break;
                    }
                    case "FPREV_RES1":
                    {
                        var arrivalDate = dataObject.FPREV_RES1;
                        var span = arrivalDate - dataObject.FSALIDA_RES1;
                        dataObject.DIAS_RES1 = (short) span.Value.Days;
                        break;
                    }
                }

                return true;
            }
            return false;
        }
        /// <summary>
        /// Check if the office is changed, so the company shall be the same of the office.
        /// </summary>
        /// <param name="eventData">Input data changed from the view </param>
        /// <param name="data">Aggregate to be updated.</param>
        /// <returns>A company object update.</returns>
        public async Task<IEnumerable<CompanyViewObject>> IsOfficeChanged(IDictionary<string, object> eventData, IBookingData data)
        {
            IList<CompanyViewObject> list;
            list = new List<CompanyViewObject>();
            if (!eventData.ContainsKey("Field"))
            {
                return list;
            }
            var dataObject = data.Value;
            var field = eventData["Field"] as string;
            if ((field != null) && (field == "OFICINA_RES1"))
            {
                var officeDataService = this.dataService.GetOfficeDataServices();
                var company = await officeDataService.GetCompanyAsync(dataObject.OFICINA_RES1).ConfigureAwait(false);
                var companyViewObjects = company as CompanyViewObject[] ?? company.ToArray();
                var currentCompany = companyViewObjects.FirstOrDefault();
                if (currentCompany != null)
                {
                    // ok now we have the company.
                    data.Value.SUBLICEN_RES1 = currentCompany.CODIGO;
                    data.CompanyDto = companyViewObjects;
                }

                return companyViewObjects;
            }
            return list;
        }
    }
}
