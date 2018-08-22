using KarveBusinessServices.Objects;
using KarveDataServices.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveBusinessServices
{
    public class BookingService 
    {
        private Booking _booking;
        private BookingDto _value;
        public BookingDto Value => _value;
        public BookingService(BookingDto dto)
        {
          
        }

        public bool CanChange(BookingDto valueObject)
        {
            _value = valueObject;
            return true;
        }
        public bool CanCreate(BookingDto valueObject)
        {
            return true;
        }
        public void Change()
        {
        }
    }
}
