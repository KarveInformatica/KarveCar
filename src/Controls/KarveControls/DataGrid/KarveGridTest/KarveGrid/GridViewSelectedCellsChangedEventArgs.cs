using System.Windows;
using Telerik.WinControls.UI;

namespace KarveGrid.Events
{
    internal class GridViewSelectedCellsChangedEventArgs: RoutedEventArgs
    {
        private RoutedEvent _gridSelectedRowChanged;
        private GridViewRowInfo _gridViewRowInfo;
        public GridViewSelectedCellsChangedEventArgs(RoutedEvent gridSelectedRowChanged): base(gridSelectedRowChanged)
        {
            this._gridSelectedRowChanged = gridSelectedRowChanged;
        }
        public GridViewRowInfo CurrentRow
        {
            get { return _gridViewRowInfo; }
            set { _gridViewRowInfo = value; }
        }
    }
}