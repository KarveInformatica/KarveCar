using System.Collections.Generic;
using System.Windows;

namespace KarveControls
{
    public class DataAreaFieldEventsArgs : RoutedEventArgs
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
        public DataAreaFieldEventsArgs() : base()
        {

        }
        public DataAreaFieldEventsArgs(RoutedEvent routedEvent) : base(routedEvent)
        {

        }
    }
}