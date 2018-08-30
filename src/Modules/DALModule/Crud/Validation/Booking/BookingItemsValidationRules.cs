namespace DataAccessLayer.Crud.Validation
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using KarveCommonInterfaces;
    using KarveDataServices.ViewObjects;

    /// <summary>
    /// Validation class for the booking items.
    /// </summary>
    public class BookingItemsValidationRules : ValidationChain<BookingViewObject>
    {
        /// <summary>
        /// Validate a booking view object.
        /// </summary>
        /// <param name="request">
        /// Request to validate.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// Returns true or false for the request in case of a successful or unsuccessful validation.
        /// </returns>
        public override bool Validate(BookingViewObject request)
        {
            var items = request.Items;
            return ValidateItems(items);
        }
        /// <summary>
        ///  Check the days.
        /// </summary>
        /// <param name="days">Number of days</param>
        /// <returns>True if the value is positive</returns>
        private bool CheckDays(int days)
        {
            return days >= 0;
        }
        /// <summary>
        ///  Validate items of booking.
        /// </summary>
        /// <param name="items">Items of the reservation.</param>
        /// <returns></returns>
        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        private bool ValidateItems(IEnumerable<BookingItemsViewObject> items)
        {
            foreach (var bookingItemView in items)
            {
                var days = -1;
                int.TryParse(bookingItemView.Days, out days);
                if (!CheckDays(days))
                {
                    ErrorMessage = "Dias no validos";
                    return false;
                }

                if (bookingItemView.Quantity < 0)
                {
                    ErrorMessage = "Cantidad no valida";
                    return false;
                }

                if (bookingItemView.Price < 0)
                {
                    ErrorMessage = "Precio no valido";
                    return false;
                }
                if (bookingItemView.Discount < 0)
                {
                    ErrorMessage = "Descuento no valido";
                    return false;
                }

            }
            return true;
        }

    }
}
