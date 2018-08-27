using KarveCommonInterfaces;
using KarveDataServices.ViewObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Crud.Validation
{
    class BookingDateCorrectRule : ValidationChain<BookingViewObject>
    {
        public override bool Validate(BookingViewObject request)
        {
            var dateNotNull = request.FSALIDA_RES1.HasValue && request.FPREV_RES1.HasValue && request.HSALIDA_RES1.HasValue && request.HPREV_RES1.HasValue;
            if (dateNotNull)
            {
                // we can go
                if (request.FSALIDA_RES1 > request.FPREV_RES1)
                {
                    ErrorMessage = "Las data no estan correctas";
                    return false;
                }
                if ((request.FSALIDA_RES1 == request.FPREV_RES1) && (request.HPREV_RES1 > request.HSALIDA_RES1)) 
                {
                    ErrorMessage = "Las data no estan correctas";
                    return false;
                }
                return true;
            }
            ErrorMessage = "Las data no estan correctas";
            return false;
        }
    }
}
