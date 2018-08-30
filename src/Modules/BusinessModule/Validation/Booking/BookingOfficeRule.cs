namespace DataAccessLayer.Crud.Validation
{
    using System;
    using System.Collections.Generic;
    using System.Data;
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
    /// The booking office rule.
    /// </summary>
    class BookingOfficeRule: ValidationChain<BookingViewObject>
    {

        private readonly ISqlExecutor _sqlExecutor;

        /// <summary>
        ///  Booking Office Type.
        /// </summary>
        /// <param name="executor"></param>
        /// <param name="officeType"></param>
        public BookingOfficeRule(ISqlExecutor executor)
        {
            this._sqlExecutor = executor;
            
        }
        /// <summary>
        ///  This validate the booking request.
        /// </summary>
        /// <param name="request">Booking request</param>
        /// <returns></returns>
        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        public override bool Validate(BookingViewObject request)
        {
            var validation = CheckOffice(request.OFICINA_RES1) && 
                             CheckOffice(request.OFISALIDA_RES1)
                             && CheckOffice(request.OFIRETORNO_RES1);
            return validation;
        }
        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        private bool CheckOffice(string code)
        {
            if (_sqlExecutor != null)
            {
                using (var dbConnection = _sqlExecutor.OpenNewDbConnection())
                {
                    try
                    {
                        var value = dbConnection.Get<OFICINAS>(code);
                        if (value == null)
                        {
                            ErrorMessage = "La oficina no existe";
                            return false;
                        }
                    }
#pragma warning disable 168
                    catch (System.Exception ex)
#pragma warning restore 168
                    {
                        ErrorMessage = "La oficina no existe";
                        return false;
                    }
                }
            }
            return true;
        }

    }
}
