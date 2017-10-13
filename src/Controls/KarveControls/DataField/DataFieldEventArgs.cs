using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace KarveControls
{
    public partial class DataField : UserControl
    {
        public class DataFieldEventArgs : RoutedEventArgs
        {
            private string _fieldData = "";
            private IDictionary<string, object> _changedValues = new Dictionary<string, object>();

            public string FieldData
            {
                get { return _fieldData; }
                set { _fieldData = value; }
            }

            public IDictionary<string, object> ChangedValuesObjects
            {
                get { return _changedValues; }
                set { _changedValues = value; }
            }

            public DataFieldEventArgs() : base()
            {

            }

            public DataFieldEventArgs(RoutedEvent routedEvent) : base(routedEvent)
            {

            }
        }
    }
}
