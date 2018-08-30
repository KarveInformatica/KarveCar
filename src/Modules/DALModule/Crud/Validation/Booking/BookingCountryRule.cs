// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BookingCountryRule.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the BookingCountryRule type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessModule.Validation.Booking
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using DataAccessLayer.DataObjects;

    using KarveCommonInterfaces;

    using KarveDapper.Extensions;

    using KarveDataServices;
    using KarveDataServices.ViewObjects;

    /// <summary>
    /// The booking country rule for validating country codes in the booking form.
    /// </summary>
    internal class BookingCountryRule : ValidationChain<BookingViewObject>
    {
        /// <summary>
        ///  database field for the country
        /// </summary>
        private readonly string fieldName;

        /// <summary>
        /// Sql command executor.
        /// </summary>
        private readonly ISqlExecutor executor;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookingCountryRule"/> class. 
        /// Booking country rule is a validation rule for any country field
        /// in the request.
        /// </summary>
        /// <param name="executor">
        /// Data layer for executing checks
        /// </param>
        /// <param name="fieldName">
        /// Name of country code field
        /// </param>
        public BookingCountryRule(ISqlExecutor executor, string fieldName)
        {
            this.fieldName = fieldName;
            this.executor = executor;
            
        }

        /// <summary>
        /// Validation for the country in the request.
        /// </summary>
        /// <param name="request">
        /// booking data object request.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>. Returns the validated value.
        /// </returns>
        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        public override bool Validate(BookingViewObject request)
        {
            var property = request.GetType().GetProperty(fieldName);
            if (property == null)
            {
                return false;
            }

            var countryCode = property.GetValue(request) as string;

            if (this.executor == null)
            {
                throw new ArgumentNullException("Sql executor is null");
            }

            using (var connection = this.executor.OpenNewDbConnection())
            {
                try
                {
                    var value = connection.Get<Country>(countryCode);
                    if (value == null)
                    {
                        this.ErrorMessage = KarveLocale.Properties.Resources.lnotexistcountry;
                        return false;
                    }
                }
#pragma warning disable 168
                catch (Exception ex)
#pragma warning restore 168
                {
                    this.ErrorMessage = KarveLocale.Properties.Resources.lnotexistcountry;
                    return false;
                }
            }

            return true;
        }
    }
}
