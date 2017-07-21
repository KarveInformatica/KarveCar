using System;
using System.Data;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using ExtendedGrid.Classes;


namespace ExtendedGrid.Converter
{
    class RowSummariesClearButtonIsEnabledConverter:IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            Button clearButton = null;
            bool value = false;
            var header = values[0] as DataGridColumnHeader;
            try
            {
                if (values[0] == DependencyProperty.UnsetValue || values[1] == DependencyProperty.UnsetValue)
                    return false;
                var dt = values[1] as DataTable;

                if (header == null || dt == null)
                    return false;
                if (header.Column == null)
                    return false;
                var currentColumnName = RowSummariesHelper.CurrentColumn;
                if (currentColumnName == null) return false;
                if (dt.Columns.Contains(currentColumnName))
                foreach (DataRow row in dt.Rows)
                {
                    if (!string.IsNullOrEmpty(System.Convert.ToString(row[currentColumnName])))
                    {
                        var dockPanel = FindControls.FindChild<DockPanel>(header, null);
                        if (dockPanel != null)
                        {
                            clearButton =
                               ((StackPanel)
                                (((Popup)(dockPanel.Children[1])).Child)).Children[
                                      0] as Button;
                            if (clearButton != null)
                            {
                                value = true;
                                clearButton.IsEnabled = true;
                            }
                        }

                    }
                }
                return false;
            }
            finally
            {
                if (value)
                {
                }
                else
                {
                    if (clearButton != null)
                    {
                        clearButton.IsEnabled = false;
                    }
                    else
                    {
                        var dockPanel = FindControls.FindChild<DockPanel>(header, null);
                        if (dockPanel != null)
                        {
                            clearButton =
                                ((StackPanel)
                                 (((Popup) (dockPanel.Children[1])).Child)).Children[
                                     0] as Button;
                            if (clearButton != null)
                            {
                                clearButton.IsEnabled = false;
                            }
                        }
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
