using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace KarveCommon.Converter
{
    public class DateTimeToTimeSpanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var currentValue = value;
            if (currentValue is DateTime time)
            {
                var span = time.TimeOfDay;
                return new TimeSpan(span.Days, span.Hours, span.Seconds, span.Milliseconds);
            }
            return currentValue;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var currentValue = value;
            if (currentValue is TimeSpan ts)
            {
                var day = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, ts.Hours, ts.Minutes, ts.Seconds);
                return day;
            }
            return currentValue;
        }
    }
}
