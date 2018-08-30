namespace BusinessModule.Validation.Booking
{
    using DataAccessLayer.DataObjects;

    using KarveCommonInterfaces;

    using KarveDapper.Extensions;

    using KarveDataServices;
    using KarveDataServices.ViewObjects;

    public class BookingDriverRule: ValidationChain<BookingViewObject>
    {
        private readonly ISqlExecutor executor;

        /// <summary>
        /// BookingDriverRule. 
        /// </summary>
        /// <param name="executor">Executor</param>
        public BookingDriverRule(ISqlExecutor executor)
        {
            this.executor = executor;
        }
        public override bool Validate(BookingViewObject request)
        { 
            try
            {
                using (var dbConnection = this.executor.OpenNewDbConnection())
                {
                    var client = dbConnection.Get<CLIENTES1>(request.CONDUCTOR_RES1);
                    if (client == null)
                    {
                        this.ErrorMessage = "Conductor no valido";
                        return false;
                    }
                }
            }
#pragma warning disable 168
            catch (System.Exception ex)
#pragma warning restore 168
            {
                return false;
            }
            return true;
        }
    }
}
