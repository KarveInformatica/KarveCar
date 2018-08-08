using System;
using System.Globalization;
using System.Windows.Data;

namespace KarveCommon.Converter
{
    /// <summary>
    ///  This converter is used to convert one of the three incident types
    /// </summary>
    public class IncidentTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
