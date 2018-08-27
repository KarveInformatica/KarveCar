
using DataAccessLayer.DataObjects;
using KarveCommonInterfaces;
using KarveDataServices;
using KarveDataServices.ViewObjects;
using KarveDapper.Extensions;

namespace DataAccessLayer.Crud.Validation
{
    /// <summary>
    ///  Booking client validation rule.
    /// </summary>
    class BookingClientRule : ValidationChain<BookingViewObject>
    {
        private readonly ISqlExecutor _executor;

        public BookingClientRule(ISqlExecutor executor)
        {
            _executor = executor;
        }
        public override bool Validate(BookingViewObject request)
        {
            if (string.IsNullOrEmpty(request.CLIENTE_RES1))
            {
                return false;
            }
            using (var dbConnection = _executor.OpenNewDbConnection())
            {

                try
                {
                    var client = dbConnection.Get<CLIENTES1>(request.CLIENTE_RES1);
                    if (client == null)
                    {
                        ErrorMessage = "Cliente no valido";

                        return false;
                    }
                }
                catch (System.Exception ex)
                {
                    ErrorMessage = "Cliente no valido";
                    return false;
                }

            }

            return true;
        }
    }
}
