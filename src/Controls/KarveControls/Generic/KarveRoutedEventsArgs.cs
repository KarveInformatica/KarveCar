using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KarveControls.Generic
{
    /// <summary>
    ///  Base class for our custom events.
    /// </summary>
    public class KarveRoutedEventsArgs : RoutedEventArgs
    {
        private string _fieldData = "";
        private IDictionary<string, object> _changedValues = new Dictionary<string, object>();
        /// <summary>
        /// Field or property changed.
        /// </summary>
        public string FieldData
        {
            get { return _fieldData; }
            set { _fieldData = value; }
        }
        /// <summary>
        ///  Dictionary of keys that delivering information about changed values
        /// </summary>
        public IDictionary<string, object> ChangedValuesObjects
        {
            get { return _changedValues; }
            set { _changedValues = value; }
        }
        /// <summary>
        /// Constructor
        /// </summary>
        public KarveRoutedEventsArgs() : base()
        {

        }
        /// <summary>
        ///  Constructor with event args
        /// </summary>
        /// <param name="routedEvent"></param>
        public KarveRoutedEventsArgs(RoutedEvent routedEvent) : base(routedEvent)
        {

        }
    }
}
