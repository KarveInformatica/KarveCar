using KarveCommonInterfaces;
using KarveDataServices.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Crud.Validation
{
    class BookingDateCorrectRule : ValidationChain<BookingDto>
    {
        public override bool Validate(BookingDto request)
        {
            var dateNotNull = request.FSALIDA_RES1.HasValue && request.FPREV_RES1.HasValue && request.HSALIDA_RES1.HasValue && request.HPREV_RES1.HasValue;
            if (dateNotNull)
            {
                // we can go
                if (request.FSALIDA_RES1 > request.FPREV_RES1)
                { 
                    return false;
                }
                if ((request.FSALIDA_RES1 == request.FPREV_RES1) && (request.HPREV_RES1 > request.HSALIDA_RES1)) 
                {
                    return false;
                }
                return true;
            }
            return false;
        }
    }
}
