using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace KarveCommon.Converter
{
    public class InvertedBooleanToVisibility: IValueConverter
    {
        // Value to convert.
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            bool bValue = false;
            if (value is bool)
            {
                bValue = (bool)value;
            }
            else if (value is Nullable<bool>)
            {
                Nullable<bool> tmp = (Nullable<bool>)value;
                bValue = tmp.HasValue ? tmp.Value : false;
            }
            return (!bValue) ? Visibility.Visible : Visibility.Collapsed;
            
        }
        // Value to converback.
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Visibility)
            {
                return (Visibility)value != Visibility.Visible;
            }
            
                return true;
            
        
        }
    }
}
