using System;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace KarveCommon.Converter
{
    public class NullDoubleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && !value.ToString().Equals("0"))
            {
                return value;
            }
            else
            {
                return string.Empty;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            StringBuilder text = new StringBuilder(value as string);
            if (text != null)
            {
                text.Replace(" ", "");

                if (text.ToString().Contains("."))
                {
                    text.Replace(".", ",");
                }
                double doubleValue;
                double.TryParse(text.ToString(), out doubleValue);

                return Math.Round(doubleValue, 2);
            }
            return string.Empty;
        }
    }
}