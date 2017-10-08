using System.Data;
using System.Windows;

namespace KarveControls.KarveGrid.Events
{
    
        public class UpdateQueryEventArgs : RoutedEventArgs
        {
            private string _sqlQuery;
            private DataSet _dataSet;

            public string SqlQuery
            {
                get { return _sqlQuery; }
                set { _sqlQuery = value; }
            }

            public DataSet DataSet
            {
                get { return _dataSet; }
                set { _dataSet = value; }
            }

        }
}
