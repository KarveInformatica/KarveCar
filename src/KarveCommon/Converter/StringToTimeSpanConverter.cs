using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace KarveCommon.Converter
{
    public class StringToTimeSpanConverter : IValueConverter
    {
        /// <summary>
        ///  Convert the string to the value.
        /// </summary>
        /// <param name="value">Input value to be used.</param>
        /// <param name="targetType">Target ype to be used.</param>
        /// <param name="parameter">Input parameter.</param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return new TimeSpan(0, 0, 0);
            }
            if (value is TimeSpan span)
            {
                return span.ToString();
            }
            if (value is string timeValue)
            {
                var format = "g";
                TimeSpan timeSpanValue = new TimeSpan(0, 0, 0);        
                if (TimeSpan.TryParseExact(timeValue, format, CultureInfo.CurrentCulture, out timeSpanValue))
                {
                    return timeSpanValue;
                }
            }
            else
            {
                return new TimeSpan(0, 0, 0);
            }
            return new TimeSpan(0, 0, 0);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return "00:00";
            }
            if (value is DateTime myCurrentTime)
            {
                var timeSpan = myCurrentTime.TimeOfDay;
                return timeSpan.ToString();

            }
            if (value!=null)
            {
                if (value is TimeSpan span)
                {
                    return span.ToString("hh:mm");
                }
            }
            return "00:00";
        }
    }
}
