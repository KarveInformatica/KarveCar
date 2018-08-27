using DataAccessLayer.DataObjects;
using KarveCommonInterfaces;
using KarveDataServices;
using KarveDataServices.ViewObjects;
using Dapper;
using KarveDapper.Extensions;


namespace DataAccessLayer.Crud.Validation
{
   
    class BookingGroupCorrectRule : ValidationChain<BookingViewObject>
    {
        private readonly ISqlExecutor _executor;

        public BookingGroupCorrectRule(ISqlExecutor executor)
        {
            _executor = executor;
        }

        public override bool Validate(BookingViewObject request)
        {
            if (string.IsNullOrEmpty(request.GRUPO_RES1))
            {
                ErrorMessage =  KarveLocale.Properties.Resources.lgroupvalidationError;
                return false;
            }
            using (var dbConnection = _executor.OpenNewDbConnection())
            {
                try
                {
                    var value = dbConnection.Get<GRUPOS>(request.GRUPO_RES1);
                    if (value == null)
                    {
                        ErrorMessage = KarveLocale.Properties.Resources.lgroupvalidationError;
                        return false;
                    }
                }
#pragma warning disable 168
                catch (System.Exception ex)
#pragma warning restore 168
                {
                    ErrorMessage = KarveLocale.Properties.Resources.lgroupvalidationError;
                    return false;
                }
            }
            return true;
        }
    }
}
