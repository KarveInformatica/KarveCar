namespace BookingModule.Service
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using KarveCar.Model;

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

            // in this case we just check if the office is changed.
            if (eventData.ContainsKey("Field"))
            {
                var dataObject = data.Value;
                var field = eventData["Field"] as string;
                data.CompanyDto = await IsOfficeChanged(eventData, data).ConfigureAwait(false);
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
            IList<CompanyViewObject> list = new List<CompanyViewObject>();
            if (eventData.ContainsKey("Field"))
            {
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
            }
            return list;
        }
    }
}
