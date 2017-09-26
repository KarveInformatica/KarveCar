using System.Data;
using System.Windows;
using Telerik.WinControls.UI;

namespace KarveGrid
{
    internal class GridRowModifiedCellEventArgs : RoutedEventArgs
    {
        public GridRowModifiedCellEventArgs(RoutedEvent modifiedCellRoutedEvent) : base(modifiedCellRoutedEvent)
        {
        }

        public GridViewRowInfo CurrentRow { get; set; }
        public DataSet CurrentDataSet { get; set; }
        public string TableName { get; set; }
        public string TableAlias { get; set; }
    }

}