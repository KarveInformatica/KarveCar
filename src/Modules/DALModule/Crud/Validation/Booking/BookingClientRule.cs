// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BookingClientRule.cs" company="KarveInformatica S.L.">
//   
// </copyright>
// <summary>
//   Booking client validation rule.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessModule.Validation.Booking
{
    using DataAccessLayer.DataObjects;

    using KarveCommonInterfaces;

    using KarveDapper.Extensions;

    using KarveDataServices;
    using KarveDataServices.ViewObjects;

    /// <summary>
    ///  Booking client validation rule.
    /// </summary>
    internal class BookingClientRule : ValidationChain<BookingViewObject>
    {
        /// <summary>
        /// Sql lowe level executor
        /// </summary>
        private readonly ISqlExecutor _executor;

        public BookingClientRule(ISqlExecutor executor)
        {
            this._executor = executor;
        }
        public override bool Validate(BookingViewObject request)
        {
            if (string.IsNullOrEmpty(request.CLIENTE_RES1))
            {
                return false;
            }
            using (var connection = this._executor.OpenNewDbConnection())
            {

                try
                {
                    var client = connection.Get<CLIENTES1>(request.CLIENTE_RES1);
                    if (client == null)
                    {
                        this.ErrorMessage = "Cliente no valido";

                        return false;
                    }
                }
                catch (System.Exception ex)
                {
                    this.ErrorMessage = "Cliente no valido";
                    return false;
                }

            }

            return true;
        }
    }
}
