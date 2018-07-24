using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace BookingModule.Views
{
    /// <summary>
    ///  BookingStateConverter.
    /// </summary>
    class BookingStateConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if ((values[0] == null) && (values[1] == null))
            {
          
                return 2;
            }
            string confirmed = values[1] as string;
            if (values[1] != null)
            {
                if ((!string.IsNullOrEmpty(confirmed)) && (confirmed[0] == '1'))
                {
                    return 0;
                }

            }
            if (values[0] != null)
            {
                /*
                byte? currentValue = (byte?)values[0];
                if (currentValue == null)
                {
                    return 2;
                }
                if ((currentValue.HasValue) && (currentValue == 1))
                {
                    return 1;
                }*/
            }
            return 2;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            object[] back = new object[2];
            /* if (value "No Reserva")
             {
                 return back;
             }*/
            return back;
        }
    }
}
