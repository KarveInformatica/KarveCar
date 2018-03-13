using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows;
using System.Windows.Data;


namespace KarveCommon.Converter
{
        public class BoolToVisiblityConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo language)
            {
                return (bool)value ? Visibility.Visible : Visibility.Collapsed;
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo language)
            {
                return (Visibility)value == Visibility.Visible;
            }
        }
}
