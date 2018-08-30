// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BookingDateCorrectRule.cs" company="KarveInformatica S.L">
//   
// </copyright>
// <summary>
//   Defines the BookingDateCorrectRule type for date validation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessModule.Validation.Booking
{
    using KarveCommonInterfaces;

    using KarveDataServices.ViewObjects;

    /// <summary>
    /// The booking date correct rule.
    /// </summary>
    internal class BookingDateCorrectRule : ValidationChain<BookingViewObject>
    {
        /// <summary>
        /// The validate.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public override bool Validate(BookingViewObject request)
        {
            var dateNotNull = request.FSALIDA_RES1.HasValue && request.FPREV_RES1.HasValue && request.HSALIDA_RES1.HasValue && request.HPREV_RES1.HasValue;
            if (dateNotNull)
            {
                // we can go
                if (request.FSALIDA_RES1 > request.FPREV_RES1)
                {
                    this.ErrorMessage = "Las data no estan correctas";
                    return false;
                }
                if ((request.FSALIDA_RES1 == request.FPREV_RES1) && (request.HPREV_RES1 > request.HSALIDA_RES1)) 
                {
                    this.ErrorMessage = "Las data no estan correctas";
                    return false;
                }
                return true;
            }
            this.ErrorMessage = "Las data no estan correctas";
            return false;
        }
    }
}
