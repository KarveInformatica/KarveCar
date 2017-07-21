using System.Windows;
using System.Windows.Controls;
using ExtendedGrid.ExtendedGridControl;

namespace ExtendedGrid.Classes
{
    /// <summary>
    /// Class for displaying the row numbers in the row headers.
    /// </summary>
    public class DataGridBehavior
    {
        public static DependencyProperty DisplayRowNumberProperty =
            DependencyProperty.RegisterAttached("DisplayRowNumber",
                                                typeof(bool),
                                                typeof(DataGridBehavior),
                                                new FrameworkPropertyMetadata(false, OnRowNumbersChanged));

        /// <summary>
        /// Gets the DisplayRowNumberProperty's value.
        /// </summary>
        /// <param name="target">The target to get the value from</param>
        /// <returns>The value</returns>
        public static bool GetRowNumber(DependencyObject target)
        {
            return (bool)target.GetValue(DisplayRowNumberProperty);
        }//end GetDisplayRowNumber

        /// <summary>
        /// Sets the DisplayRowNumberProperty to value.
        /// </summary>
        /// <param name="target">The target to set the property of</param>
        /// <param name="value">The value to set the property to</param>
        public static void SetRowNumber(DependencyObject target, bool value)
        {
            target.SetValue(DisplayRowNumberProperty, value);
        }//end SetDisplayRowNumber

        /// <summary>
        /// Subscribes or unsubscribes the LoadingRow and UnloadingRow events to the RefreshRowNumbers method
        /// in order to properly update the row numbers when rows are added or deleted.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        private static void OnRowNumbersChanged(DependencyObject source, DependencyPropertyChangedEventArgs args)
        {
            DataGrid grid = source as DataGrid;
            if (grid == null)
                return;

            if ((bool)args.NewValue)
            {
                grid.LoadingRow += RefreshRowNumbers;
                grid.UnloadingRow += RefreshRowNumbers;
            }
            else
            {
                grid.LoadingRow -= RefreshRowNumbers;
                grid.UnloadingRow -= RefreshRowNumbers;
            }
        }//end OnRowNumbersChanged

        /// <summary>
        /// Event handler that handles refreshing the row numbers in the row headers.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private static void RefreshRowNumbers(object sender, DataGridRowEventArgs args)
        {
            var grid = sender as ExtendedDataGrid;
            if (grid == null)
                return;
            if (grid.IsGroupByOn)
                return;
            foreach (var item in grid.Items)
            {
                var row = (DataGridRow)grid.ItemContainerGenerator.ContainerFromItem(item);
                if (row != null && row.GetIndex()!=-1)
                    row.Header = (row.GetIndex() + 1).ToString();
            }
        }//end RefreshRowNumbers

    }//end class DataGridBehavior
}//end namespace