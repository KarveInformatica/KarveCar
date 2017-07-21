using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ExtendedGrid.Converter
{
    class RowSummaryVisibiltyConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var showRowSummaries = (bool)value;
            return showRowSummaries ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
