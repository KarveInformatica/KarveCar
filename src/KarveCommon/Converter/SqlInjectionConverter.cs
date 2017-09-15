using System;
using System.Globalization;
using System.Windows.Data;

namespace KarveCommon.Converter
{
    public class SqlInjectionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
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
            if (value != null)
            {
                return value.ToString().Replace("'", string.Empty)
                                       .Replace("--", string.Empty)
                                       .Replace("/*", string.Empty)
                                       .Replace("*/", string.Empty)
                                       .Replace(";", string.Empty);
            }
            else
            {
                return string.Empty;
            }
        }        
    }
}
