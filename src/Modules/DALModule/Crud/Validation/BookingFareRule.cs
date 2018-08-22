using DataAccessLayer.SQL;
using KarveCommonInterfaces;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using KarveDapper.Extensions;
using DataAccessLayer.DataObjects;

namespace DataAccessLayer.Crud.Validation
{
    class BookingFareRule: ValidationChain<BookingDto>
    {
        private ISqlExecutor _sqlExecutor;

        public BookingFareRule(ISqlExecutor executor)
        {
            _sqlExecutor = executor;
        }
        /// <summary>
        ///  This validates the new concept.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public override bool Validate(BookingDto request)
        {
            var nullFare = string.IsNullOrEmpty(request.TARIFA_RES1);
            if (nullFare)
            {
                ErrorMessage = "La tarifa es vacia";
                return false;
            }
            /*
            if (_sqlExecutor != null)
            {
                // la tarifa existe.
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
                    catch (System.Exception ex)
                    {
                        ErrorMessage = "La tarifa no existe";
                        return false;
                    }
                }
            }
            */
            return true;
        }
    }
}
