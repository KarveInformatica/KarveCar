using Syncfusion.UI.Xaml.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.Data;
using System.Collections.ObjectModel;
using KarveCommon;
using KarveCommon.Generic;
using System.Windows.Input;
using KarveCommonInterfaces;
using System.Windows;
using System.ComponentModel;

namespace KarveControls.Behaviour.Grid
{

    /// <summary>
    /// 
    /// </summary>
    public class GridFilterBehavior : KarveBehaviorBase<SfDataGrid>
    {
        public enum SortOrder { Ascending, Descending };

        private GridColumn _currentColumn;
        private SortOrder _currentSortOrder = SortOrder.Ascending;
        private int _currentIndex;
        private int _sortDescending = 0;
        public static readonly DependencyProperty commandProperty =
        DependencyProperty.Register("Command", typeof(ICommand), typeof(GridFilterBehavior));
        

        /// <summary>
        /// Gets or sets the type of SfDataGrid binding with FilterStatusBar.
        /// </summary>     
        public SfDataGrid DataGrid
        {
            get { return (SfDataGrid)GetValue(DataGridProperty); }
            set { SetValue(DataGridProperty, value); }
        }


        public static readonly DependencyProperty DataGridProperty =
       DependencyProperty.Register("DataGrid", typeof(SfDataGrid), typeof(GridFilterBehavior), new PropertyMetadata(null));

        public static readonly DependencyProperty ItemSource =
           DependencyProperty.Register("ItemSource", typeof(object), typeof(GridFilterBehavior));
        /// <summary>
        ///  Command is the related to the properties. 
        /// </summary>
        public ICommand Command
        {
            set
            {
                SetValue(commandProperty, value);
            }
            get
            {
                return (ICommand)GetValue(commandProperty);
            }
        }
       

        public GridFilterBehavior()
        {
        }

        protected override void OnSetup()
        {

            this.AssociatedObject.SortColumnsChanging += DataGrid_SortColumnsChanging;
        //    this.AssociatedObject.FilterChanged += dataGrid_FilterChanged;
            this.AssociatedObject.CurrentCellEndEdit += dataGrid_CurrentCellEndEdit;
            this.AssociatedObject.CurrentCellBeginEdit += dataGrid_BeginCellEdit;
        }

        private void dataGrid_FilterChanged(object sender, GridFilterEventArgs e)
        {
          //  MessageBox.Show("FilterChanged");
           
        ///    var records = (sender as SfDataGrid).View.Records;
            //records.Reverse();
        }

        /// <summary>
        ///  This update the dictonary value adding the value of each sort operation that has been done by the 
        ///  columns
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="sort"></param>
        /// <param name="sortDictionary"></param>
        /// <param name="direction"></param>
        private void UpdateDictionary(string columnName, 
                                    SortDescription sort,
                                    ref Dictionary<string, ListSortDirection> sortDictionary, 
                                    ListSortDirection direction)
        {
            if (sort.Direction == direction)
            {
                if (!sortDictionary.ContainsKey(columnName))
                {
                    sortDictionary.Add(columnName, sort.Direction);

                }
                else
                {
                    sortDictionary[columnName] = sort.Direction;
                }
            }
        }
        private void DataGrid_SortColumnsChanging(object sender, GridSortColumnsChangingEventArgs e)
        {
            var viewModel = this.AssociatedObject.DataContext as KarveViewModelBase;
            var sortDictionary = new Dictionary<string, ListSortDirection>();
            foreach (var sortColumn in this.AssociatedObject.View.SortDescriptions)
            {
                var columnName = sortColumn.PropertyName;
                if (sortColumn.Direction == ListSortDirection.Ascending)
                {
                    UpdateDictionary(columnName, sortColumn, ref sortDictionary, ListSortDirection.Ascending);
                }
                else
                {
                    UpdateDictionary(columnName, sortColumn, ref sortDictionary, ListSortDirection.Descending);
                }
            }
            if (viewModel.SortCommand != null)
            {
                viewModel.SortCommand.Execute(sortDictionary);
            }
        }

        private void dataGrid_BeginCellEdit(object sender, CurrentCellBeginEditEventArgs e)
        {
            this._currentColumn = e.Column;
            //_currentIndex = e.RowColumnIndex.ColumnIndex;

        }

        private void dataGrid_CurrentCellEndEdit(object sender, CurrentCellEndEditEventArgs args)
        {
              //  this.AssociatedObject.SelectedIndex = _currentIndex + 1;
            
        }
        protected override void OnCleanup()
        {
          
            this.AssociatedObject.CurrentCellEndEdit -= dataGrid_CurrentCellEndEdit;
            this.AssociatedObject.CurrentCellBeginEdit -= dataGrid_BeginCellEdit;
        }
    }
}
