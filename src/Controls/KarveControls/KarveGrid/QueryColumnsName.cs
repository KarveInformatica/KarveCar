using System.Windows;

namespace KarveControls.KarveGrid
{
    namespace Events
    {
        public class QueryColumnsName : RoutedEventArgs
        {
            private string _sqlString;
            private string _aliasName;
            private string _tableName;

            public string SqlQuery
            {
                get { return _sqlString; }
                set { _sqlString = value; }

            }
            public string AliasName
            {
                get { return _aliasName; }
                set { _aliasName = value; }
            }

            public string TableName
            {
                get { return _tableName; }
                set { _tableName = value; }
            }
        }
    }
}
