using System;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace KarveCommon.Converter
{
    public class NullDateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && !value.ToString().Equals("01/01/0001 0:00:00"))
            {
                return ((DateTime)value).Date;
            }
            else
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            StringBuilder text = new StringBuilder(value as string);
            if (text != null)
            {
                text.Replace(" ", "");

                DateTime dateValue;
                DateTime.TryParse(text.ToString(), out dateValue);

                return dateValue;
            }
            return null;
        }
    }
}
