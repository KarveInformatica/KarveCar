using KarveDataServices.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveBusinessServices.Objects
{
    public class Booking : IBusinessObject<BookingDto>
    {
        private BookingDto _bookingDto;
        public Booking()
        {
            _bookingDto = new BookingDto();
        }
        private void Update(BookingDto dto)
        {
            _bookingDto = dto;
            // here does the business changes.
        }
        public BookingDto Value
        {
            get {
                return _bookingDto;
            }
            set
            {
                Update(value);
            }
        }
    }
}
