using System.Windows;
using KarveCommon.Services;
using System.Windows.Input;
using System;
using System.Collections.ObjectModel;
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.UI.Xaml.Grid.Helpers;
using System.Threading;

namespace KarveControls.KarveGrid
{

    /// <summary>
    ///  This is a public extension for the karve grid.
    /// </summary>
    public class KarveGridExt : DependencyObject
    {


        private enum ResizeState {
            ResizeStart = 0, ResizeStop = 1
        };

        private static ResizeState _resizeState = ResizeState.ResizeStop;
        private static int _lastMovedCol = 0;

      
        /// <summary>
        /// Columns parameter name.
        /// </summary>
        public class ColParamSize
        {
            /// <summary>
            ///  This is the column index
            /// </summary>
            public int ColumnIndex { set; get; }
            /// <summary>
            ///  This is the case of the width.
            /// </summary>
            public double ColumnWidth { set; get; }
            /// <summary>
            ///  This is the case of the name.
            /// </summary>
            public string ColumnName { set; get; }
        }


        private static DateTime time;
        /// <summary>
        ///  This property allow us to resize a columns.
        /// </summary>
        public static readonly DependencyProperty DefaultColumnsSizeDependencyProperty =
            DependencyProperty.RegisterAttached(
                "DefaultColumnsSize",
                typeof(ObservableCollection<KarveGridExt.ColParamSize>),
                typeof(KarveGridExt),
                new PropertyMetadata(null, DefaultColumnsSizeCb));
        
        /// <summary>
        ///  DefaultColumnsSize dependency property.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        public static void SetDefaultColumnsSize(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            d.SetValue(DefaultColumnsSizeDependencyProperty, e);
        }
        /// <summary>
        ///  Get default columns size dependency property.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        public static ObservableCollection<KarveGridExt.ColParamSize> GetDefaultColumnsSize(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ObservableCollection<KarveGridExt.ColParamSize>  value = (ObservableCollection<KarveGridExt.ColParamSize>)d.GetValue(DefaultColumnsSizeDependencyProperty);
            return value;
        }

        
        private static void DefaultColumnsSizeCb(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SfDataGrid dataGrid  = d as SfDataGrid;
            if (d != null)
            {
                ObservableCollection<KarveGridExt.ColParamSize> cols = GetDefaultColumnsSize(d, e);
                // ok here we can set the columns.
                if (dataGrid != null)
                {
                    foreach (var value in cols)
                    {
                        if (value.ColumnIndex < dataGrid.Columns.Count)
                        {
                            dataGrid.Columns[value.ColumnIndex].Width = value.ColumnWidth;
                        }
                    }
                    dataGrid.RefreshColumns();
                }
            }
        }


        /// <summary>
        ///  This command get executed when a columns get resized. 
        ///  The view model in this case might know that this has been happened and save the settings in the configuration service.
        /// </summary>
        public static readonly DependencyProperty ResizeColumnCommandDependencyProperty =
            DependencyProperty.RegisterAttached(
                "ResizeColumnCommand",
                typeof(ICommand),
                typeof(KarveGridExt),
                new PropertyMetadata(null, GridColWidthChangedCommand));
        /// <summary>
        ///  This set the resize column command.
        /// </summary>
        /// <param name="d">Dependency Property object</param>
        /// <param name="e">Parameters for the changed events.</param>
        public static void SetResizeColumnCommand(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            d.SetValue(ResizeColumnCommandDependencyProperty, e);
        }
        /// <summary>
        /// This set the size column command.
        /// </summary>
        /// <param name="d">Dependency Property object</param>
        /// <param name="e">Parameters for the changed events</param>
        public static ICommand GetResizeColumnCommand(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            return (ICommand)d.GetValue(ResizeColumnCommandDependencyProperty);
        }
        private static void GridColWidthChangedCommand(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SfDataGrid dataGrid = d as SfDataGrid;
            if (dataGrid != null)
            {
                dataGrid.ResizingColumns += DataGrid_ResizingColumns;
                dataGrid.MouseUp += DataGrid_MouseLeave;
            }
        }

        private static void DataGrid_MouseLeave(object sender, MouseEventArgs e)
        {

            if (_resizeState == ResizeState.ResizeStart)
            {
                _resizeState = ResizeState.ResizeStop;
                DependencyPropertyChangedEventArgs ev = new DependencyPropertyChangedEventArgs();
                ColParamSize param = new ColParamSize();
                param.ColumnIndex = _lastMovedCol;
                SfDataGrid grid = sender as SfDataGrid;
                if (grid != null)
                {
                    Columns cls = grid.Columns;
                    GridColumn column = cls[_lastMovedCol];
                    param.ColumnName = column.HeaderText;
                    param.ColumnWidth = column.ActualWidth;
                    var dependencyObject = sender as DependencyObject;
                    var command = KarveGridExt.GetResizeColumnCommand(dependencyObject, ev);
                    command?.Execute(param);
                }
            }
        }

        private static void DataGrid_ResizingColumns(object sender, ResizingColumnsEventArgs e)
        {
            _resizeState = ResizeState.ResizeStart;
            _lastMovedCol = e.ColumnIndex;
        }

        /// <summary>
        ///  This is the karve grid extension
        /// </summary>
        public KarveGridExt()
        {
        }
         
    }

}