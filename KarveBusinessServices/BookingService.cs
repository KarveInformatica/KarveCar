using KarveBusinessServices.Objects;
using KarveDataServices.ViewObjects;

namespace KarveBusinessServices
{
    public class BookingService 
    {
        private Booking _booking;
        private BookingViewObject _value;
        public BookingViewObject Value => _value;
        public BookingService(BookingViewObject viewObject)
        {
          
        }

        public bool CanChange(BookingViewObject valueObject)
        {
            _value = valueObject;
            return true;
        }
        public bool CanCreate(BookingViewObject valueObject)
        {
            return true;
        }
        public void Change()
        {
        }
    }
}
