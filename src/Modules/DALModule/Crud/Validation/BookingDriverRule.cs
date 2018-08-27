using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.DataObjects;
using KarveCommonInterfaces;
using KarveDapper.Extensions;
using KarveDataServices;
using KarveDataServices.ViewObjects;

namespace DataAccessLayer.Crud.Validation
{
    public class BookingDriverRule: ValidationChain<BookingViewObject>
    {
        private ISqlExecutor executor;

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
                using (var dbConnection = executor.OpenNewDbConnection())
                {
                    var client = dbConnection.Get<CLIENTES1>(request.CONDUCTOR_RES1);
                    if (client == null)
                    {
                        ErrorMessage = "Conductor no valido";
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
