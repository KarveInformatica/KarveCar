using System.Windows;
using System.Windows.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.UI.Xaml.Grid.Helpers;
using System.IO;

namespace KarveControls.KarveGrid
{

    /// <summary>
    ///  This is a public extension for the karve grid.
    /// </summary>
    public class KarveGridExt : DependencyObject
    {


        // in application data.
        private static string _gridOptionPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
    
        private enum GridColumnEventState {
            ResizeStart = 0, ResizeStop = 1
        };

        private static GridColumnEventState _resizeState = GridColumnEventState.ResizeStop;

        private static int _lastMovedCol = 0;
        private static int _nextMovedPos = -1;
      
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
            /// <summary>
            ///  Swapped from 
            /// </summary>
            public int SwappedFrom { set; get; }
            /// <summary>
            ///  SwwappedTo
            /// </summary>
            public int SwappedTo { set; get; }

            public bool OrderChanged { set; get; }  
            /// <summary>
            ///  ColumnsList size.
            /// </summary>
            public IList<ColParamSize> ColumnList { set; get; }
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

        private static void SerializeAndRefresh(SfDataGrid grid, string combinePath)
        {
            
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
                    // FIXME: usare la base de datos con los colmmans para riversar la serialization in a memory stream.
                    var combinePath = Path.Combine(_gridOptionPath, "GridOptions_" + dataGrid.Name + ".xml");
                    using (var file = File.Open(combinePath, FileMode.Open))
                    {
                        dataGrid.Deserialize(file);
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

        private static bool _orderChanged = false;

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
                dataGrid.QueryColumnDragging += DataGrid_QueryColumnDragging;
                _orderChanged = false;

            }
        }

      
        private static void DataGrid_QueryColumnDragging(object sender, QueryColumnDraggingEventArgs e)
        {

            if (e.Reason == QueryColumnDraggingReason.Dropped)
            {
                SfDataGrid grid = sender as SfDataGrid;
                var combinePath = Path.Combine(_gridOptionPath, "GridOptions_" + grid.Name + ".xml");
                using (var file = File.Create(combinePath))
                {
                    SerializationOptions options = new SerializationOptions();
                    grid.Serialize(file, options);
                }
            }
          
            
        }

        private static void DataGrid_MouseLeave(object sender, MouseEventArgs e)
        {
            DependencyPropertyChangedEventArgs ev = new DependencyPropertyChangedEventArgs();
            ColParamSize param = new ColParamSize();
            param.ColumnList = new List<ColParamSize>();
            int idx = 0;
            if (_resizeState == GridColumnEventState.ResizeStart)
            {
                _resizeState = GridColumnEventState.ResizeStop;
                param.ColumnIndex = _lastMovedCol;
                SfDataGrid grid = sender as SfDataGrid;
                if (grid != null)
                {
                    Columns cls = grid.Columns;
                    GridColumn column = cls[_lastMovedCol];
                    param.ColumnName = column.HeaderText;
                    param.ColumnWidth = column.ActualWidth;
                    foreach (var c in cls)
                    {
                        ColParamSize currentParam = new ColParamSize();
                        currentParam.ColumnIndex = idx++;
                        currentParam.ColumnName = c.HeaderText;
                        currentParam.ColumnWidth = c.ActualWidth;
                        param.ColumnList.Add(currentParam);
                    }
                    var dependencyObject = sender as DependencyObject;
                    var command = KarveGridExt.GetResizeColumnCommand(dependencyObject, ev);
                    command?.Execute(param);
                }
            }         
        }

        private static void DataGrid_ResizingColumns(object sender, ResizingColumnsEventArgs e)
        {
            _resizeState = GridColumnEventState.ResizeStart;
            _lastMovedCol = e.ColumnIndex;
            _orderChanged = false;
        }

        /// <summary>
        ///  This is the karve grid extension
        /// </summary>
        public KarveGridExt()
        {
        }
         
    }

}