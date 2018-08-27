using KarveCommonInterfaces;
using KarveDataServices.ViewObjects;
using System.Linq;

namespace DataAccessLayer.Crud.Validation
{
    class BookingConceptRule : ValidationChain<BookingViewObject>
    {
        /// <summary>
        ///  This validates the new concept.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public override bool Validate(BookingViewObject request)
        {
            var items = request.Items;
            var nullConcept = items.FirstOrDefault(x => string.IsNullOrEmpty(x.Desccon));
            if (nullConcept != null)
            {
                ErrorMessage = "El concepto es nulo";
                return false;
            }
            return true;
        }
    }
}
