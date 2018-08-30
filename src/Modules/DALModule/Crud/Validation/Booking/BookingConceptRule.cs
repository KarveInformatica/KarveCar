// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BookingConceptRule.cs" company="KarveInformatica S.L">
//   
// </copyright>
// <summary>
//   Defines the BookingConceptRule type for validation of the concept in the booking grid.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessModule.Validation.Booking
{
    using System.Linq;

    using KarveCommonInterfaces;

    using KarveDataServices.ViewObjects;

    /// <summary>
    /// The booking concept rule validation.
    /// </summary>
    internal class BookingConceptRule : ValidationChain<BookingViewObject>
    {
        /// <summary>
        ///  This validates the new concept.
        /// </summary>
        /// <param name="request">Booking request to validate</param>
        /// <returns>True or false if the booking concept is correct.</returns>
        public override bool Validate(BookingViewObject request)
        {
            var items = request.Items;
            var nullConcept = items.FirstOrDefault(x => string.IsNullOrEmpty(x.Desccon));
            if (nullConcept != null)
            {
                this.ErrorMessage = KarveLocale.Properties.Resources.lnotexistconcept;
                return false;
            }
            return true;
        }
    }
}
