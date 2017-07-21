using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using ExtendedGrid.ExtendedGridControl;

namespace ExtendedGrid.Converter
{
    internal class GroupByButtonVisibilityConverter:IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var dataGridColumnHeader = values[0] as DataGridColumnHeader;
            var grid = values[2] as ExtendedDataGrid;
            if (dataGridColumnHeader != null && dataGridColumnHeader.Column != null)
            {
               
                if (grid != null)
                {
                    if (grid.GroupByControlVisibility == Visibility.Visible)
                    {
                        if (!grid.GroupByCollection.Any(x => x.SortMemberPath == dataGridColumnHeader.Column.SortMemberPath))
                        {
                            return Visibility.Visible;
                        }
                    }
                }
            }
            return Visibility.Collapsed;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
