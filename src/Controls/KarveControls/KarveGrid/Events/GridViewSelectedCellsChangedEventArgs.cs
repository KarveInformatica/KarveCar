using System.Collections.Generic;
using System.Data;
using System.Windows;
using Telerik.WinControls.UI;

namespace KarveControls.KarveGrid.Events
{
    internal class GridViewSelectedCellsChangedEventArgs: RoutedEventArgs
    {
        private RoutedEvent _gridSelectedRowChanged;
        private GridViewRowInfo _gridViewRowInfo;
        private IDictionary<string, object> _currentGridDictionary =  new Dictionary<string, object>();
        public GridViewSelectedCellsChangedEventArgs(RoutedEvent gridSelectedRowChanged): base(gridSelectedRowChanged)
        {
            this._gridSelectedRowChanged = gridSelectedRowChanged;
        }
        private DataColumnCollection fetchCollection(GridViewRowInfo rows, out DataRow row)
        {
            System.Data.DataRowView view = rows.DataBoundItem as DataRowView;
            DataColumnCollection cols = null;
            row = view?.Row;
            cols = row?.Table.Columns;
            return cols;
        }
        IDictionary<string, object> TransformRowToMap(GridViewRowInfo rows)
        {
            IDictionary<string, object> currentDictionary = new Dictionary<string, object>();
            DataRow row;
            DataColumnCollection cols = fetchCollection(rows, out row);
            foreach (DataColumn col in cols)
            {
                string colName = col.ColumnName;
                if (row != null)
                {
                    object value = row[colName];
                    currentDictionary.Add(colName, value);
                }
            }
            return currentDictionary;
        }
        public GridViewRowInfo CurrentRow
        {
            get { return _gridViewRowInfo; }
            set { _gridViewRowInfo = value; TransformRowToMap(_gridViewRowInfo); }
        }
        public IDictionary<string, object> CurrentRowMap {
            get { return _currentGridDictionary; }
            set { _currentGridDictionary = value; }
        }
    }
}