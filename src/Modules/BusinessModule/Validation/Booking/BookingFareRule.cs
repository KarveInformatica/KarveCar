using KarveCommonInterfaces;
using KarveDataServices;
using KarveDataServices.ViewObjects;
using KarveDapper.Extensions;
using DataAccessLayer.DataObjects;

namespace DataAccessLayer.Crud.Validation
{
    class BookingFareRule: ValidationChain<BookingViewObject>
    {
        private readonly ISqlExecutor _sqlExecutor;

        public BookingFareRule(ISqlExecutor executor)
        {
            _sqlExecutor = executor;
        }
        /// <summary>
        ///  This validates the new concept.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public override bool Validate(BookingViewObject request)
        {
            var nullFare = string.IsNullOrEmpty(request.TARIFA_RES1);
            if (nullFare)
            {
                ErrorMessage = "La tarifa es vacia";
                return false;
            }
           
            if (_sqlExecutor != null)
            {
                using (var dbConnection = _sqlExecutor.OpenNewDbConnection())
                {
                    try
                    {
                        var value = dbConnection.Get<NTARI>(request.TARIFA_RES1);
                        if (value == null)
                        {
                            ErrorMessage = "La tarifa no existe";
                            return false;
                        }
                    }
#pragma warning disable 168
                    catch (System.Exception ex)
#pragma warning restore 168
                    {
                        ErrorMessage = "La tarifa no existe";
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
