using System;
using System.Globalization;
using System.Windows.Data;

namespace KarveCommon.Converter
{

    class TimeSpanToDateTimeConverter : IValueConverter
    {
  
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                TimeSpan ts = (TimeSpan)(value);
                DateTime dt = DateTime.Today + ts;
                //Get the timespan from subtracting the date from the original DateTime
                //this returns a timespan representing the time component of the DateTime
                return dt;
            }
            catch (Exception ex)
            {
                return DateTime.Today;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
              
                DateTime dt = (DateTime) value;
                TimeSpan ts = dt - DateTime.Today;
                return ts;
            }
            catch (Exception ex)
            {
                return TimeSpan.MinValue;
            }
        }
    }
}
