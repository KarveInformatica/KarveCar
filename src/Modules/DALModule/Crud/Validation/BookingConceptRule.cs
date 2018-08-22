using KarveCommonInterfaces;
using KarveDataServices.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Crud.Validation
{

    class BookingConceptRule : ValidationChain<BookingDto>
    {
        /// <summary>
        ///  This validates the new concept.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public override bool Validate(BookingDto request)
        {
            var items = request.Items;
            var nullConcept = items.FirstOrDefault(x => string.IsNullOrEmpty(x.Desccon));
            if (nullConcept != null)
            {
                return false;
            }
            return true;
        }
    }
}
