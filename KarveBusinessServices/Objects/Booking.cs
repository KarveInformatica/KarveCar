using KarveDataServices.ViewObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveBusinessServices.Objects
{
    public class Booking : IBusinessObject<BookingViewObject>
    {
        private BookingViewObject _bookingViewObject;
        public Booking()
        {
            _bookingViewObject = new BookingViewObject();
        }
        private void Update(BookingViewObject viewObject)
        {
            _bookingViewObject = viewObject;
            // here does the business changes.
        }
        public BookingViewObject Value
        {
            get {
                return _bookingViewObject;
            }
            set
            {
                Update(value);
            }
        }
    }
}
