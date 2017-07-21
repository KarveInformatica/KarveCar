using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;

namespace ExtendedGrid.Converter
{
    internal class FrozenRowSplitterMarginConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var grid = (DataGrid)values[1];
            double offset = 0;
            if (grid != null)
            {
                if (grid.HeadersVisibility == DataGridHeadersVisibility.None || grid.HeadersVisibility == DataGridHeadersVisibility.Row)
                {
                    offset = 0;
                }
                else
                {
                    if (grid.ColumnHeaderHeight.ToString(CultureInfo.InvariantCulture) == Double.NaN.ToString(CultureInfo.InvariantCulture))
                    {
                        var columnPresenter = Classes.FindControls.FindChild<DataGridColumnHeadersPresenter>(grid,
                            "PART_ColumnHeadersPresenter");
                        if (columnPresenter!=null)
                        offset = columnPresenter.ActualHeight;
                    }
                    else
                    {
                        offset = grid.ColumnHeaderHeight;
                    }
                }
            }
            return new Thickness(0, (double)values[0] + offset-3, 0, 0);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
