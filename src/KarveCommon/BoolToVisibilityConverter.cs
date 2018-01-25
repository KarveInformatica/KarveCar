using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace KarveCommon
{ 
    public class BoolToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Converter from Boolean to visible.
        /// </summary>
        /// <param name="value">Value to convert</param>
        /// <param name="targetType">Target type</param>
        /// <param name="parameter">Parameter</param>
        /// <param name="language">Language</param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo language)
        {
            return (bool) value ? Visibility.Visible : Visibility.Collapsed;
        }
        /// <summary>
        /// Convert back from the value type to boolean.
        /// </summary>
        /// <param name="value">Value to convert</param>
        /// <param name="targetType">Target type</param>
        /// <param name="parameter">Parameter</param>
        /// <param name="language">Language</param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo language)
        {
            return (Visibility) value == Visibility.Visible;
        }
    }
}