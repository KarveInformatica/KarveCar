using System.Windows;

namespace KarveGrid
{
    namespace Events
    {
        public class QueryDataTableEventArgs : RoutedEventArgs
        {
            private string _table = "";
            private string _alias = "";
            private bool _merge = false;
            public string Table
            {
                get { return _table; }
                set => _table = value;
            }
            public string Alias
            {
                get => _alias; set { _alias = value; }
            }

            public bool Merge
            {
                get => _merge; set { _merge = value; }
            }
            public QueryDataTableEventArgs() : base()
            {

            }
            public QueryDataTableEventArgs(RoutedEvent routedEvent) : base(routedEvent)
            {

            }
        }
    }
}
