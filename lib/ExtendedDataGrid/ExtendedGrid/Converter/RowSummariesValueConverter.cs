using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using ExtendedGrid.Classes;
using ExtendedGrid.ExtendedGridControl;


namespace ExtendedGrid.Converter
{
    internal class RowSummariesValueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            UIElement currentStackPanel=null;
            object value=null;
            StackPanel stackPanel = null;
            DataTable dt = null;
            DataGridColumnHeader currentColumn = null;
            ExtendedDataGrid grid;
            try
            {
                if (values[0] == DependencyProperty.UnsetValue || values[1] == DependencyProperty.UnsetValue)
                    return "";
                currentColumn = (DataGridColumnHeader)values[0];
                grid = FindControls.FindParent<ExtendedDataGrid>(currentColumn);
                if (grid == null)
                    return "";
                dt = ((DataTable)values[1]);
                if (currentColumn.Column == null)
                {
                    return "";
                }
                string computation = parameter.ToString();
                stackPanel = FindControls.FindChild<System.Windows.Controls.StackPanel>(currentColumn, null);
                var currentColumnName = currentColumn.Column.SortMemberPath;
                if (currentColumnName == null)
                    return "";
                switch (computation)
                {
                    case "Count":
                        value = dt.Rows[ExtendedDataGrid.Count][currentColumnName];
                         currentStackPanel = stackPanel == null ? null : stackPanel.Children[ExtendedDataGrid.Count];
                         return value == DBNull.Value ? string.Empty : (string.IsNullOrEmpty(grid.RowSummaryCountFormat) ? value : System.Convert.ToDecimal(value).ToString(grid.RowSummaryCountFormat, CultureInfo.InvariantCulture));
                    case "Sum":
                         value = dt.Rows[ExtendedDataGrid.Sum][currentColumnName];
                         currentStackPanel = stackPanel == null ? null : stackPanel.Children[ExtendedDataGrid.Sum];
                         return value == DBNull.Value ? string.Empty : (string.IsNullOrEmpty(grid.RowSummarySumFormat) ? value : System.Convert.ToDecimal(value).ToString(grid.RowSummarySumFormat, CultureInfo.InvariantCulture));
                    case "Average":
                        value = dt.Rows[ExtendedDataGrid.Average][currentColumnName];
                         currentStackPanel = stackPanel == null ? null : stackPanel.Children[ExtendedDataGrid.Average];
                         return value == DBNull.Value ? string.Empty : (string.IsNullOrEmpty(grid.RowSummaryAverageFormat) ? value : System.Convert.ToDecimal(value).ToString(grid.RowSummaryAverageFormat, CultureInfo.InvariantCulture));
                    case "Min":
                        value = dt.Rows[ExtendedDataGrid.Min][currentColumnName];
                         currentStackPanel = stackPanel == null ? null : stackPanel.Children[ExtendedDataGrid.Min];
                         return value == DBNull.Value ? string.Empty : (string.IsNullOrEmpty(grid.RowSummaryMinFormat) ? value : System.Convert.ToDecimal(value).ToString(grid.RowSummaryMinFormat, CultureInfo.InvariantCulture));
                    case "Max":
                        value = dt.Rows[ExtendedDataGrid.Max][currentColumnName];
                         currentStackPanel = stackPanel == null ? null : stackPanel.Children[ExtendedDataGrid.Max];
                         return value == DBNull.Value ? string.Empty : (string.IsNullOrEmpty(grid.RowSummaryMaxFormat) ? value : System.Convert.ToDecimal(value).ToString(grid.RowSummaryMaxFormat, CultureInfo.InvariantCulture));
                    case "Smallest":
                        value = dt.Rows[ExtendedDataGrid.Smallest][currentColumnName];
                         currentStackPanel = stackPanel == null ? null : stackPanel.Children[ExtendedDataGrid.Smallest];
                         return value == DBNull.Value ? string.Empty : (string.IsNullOrEmpty(grid.RowSummarySmallestFormat) ? value : System.Convert.ToDecimal(value).ToString(grid.RowSummarySmallestFormat, CultureInfo.InvariantCulture));
                    case "Largest":
                        value = dt.Rows[ExtendedDataGrid.Largest][currentColumnName];
                         currentStackPanel = stackPanel == null ? null : stackPanel.Children[ExtendedDataGrid.Largest];
                         return value == DBNull.Value ? string.Empty : (string.IsNullOrEmpty(grid.RowSummaryLargestFormat) ? value : System.Convert.ToDecimal(value).ToString(grid.RowSummaryLargestFormat, CultureInfo.InvariantCulture));
                }
                return "";
            }
            catch (Exception)
            {
                return "";
            }
            finally
            {
                if (currentStackPanel!=null)
                {
                    currentStackPanel.Visibility = string.IsNullOrEmpty(System.Convert.ToString(value)) ? Visibility.Collapsed : Visibility.Visible;
                }
                //Adjust height of the summary row
                //get the actual height of one text box
                if (stackPanel != null)
                {
                    var heightOfSingleElement = ((TextBlock)((System.Windows.Controls.StackPanel)(stackPanel.Children[ExtendedDataGrid.Sum])).Children[0]).ActualHeight;
                    var countOfRowSummaries = new List<int>();
                    foreach(DataColumn col in dt.Columns)
                    {
                        int count = 0;
                        foreach(DataRow row in dt.Rows)
                        {
                            if(!string.IsNullOrEmpty(System.Convert.ToString(row[col.ColumnName])))
                            {
                                count++;
                            }
                        }
                        countOfRowSummaries.Add(count);
                    }
                    int maximumCount = countOfRowSummaries.Max();
                    var summariesGrid = FindControls.FindParent<DataGrid>(currentColumn);
                    if(summariesGrid!=null)
                    {
                        if (maximumCount>0)
                         summariesGrid.Height = maximumCount*heightOfSingleElement+5;
                        else
                         summariesGrid.Height = 0;
                    }
                }
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}


