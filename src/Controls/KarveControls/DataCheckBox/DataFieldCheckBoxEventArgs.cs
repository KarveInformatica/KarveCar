using System.Collections.Generic;
using System.Windows;

namespace KarveControls
{
        /// <summary>
        /// This is the data field check box event.
        /// </summary>
        public class DataFieldCheckBoxEventArgs : RoutedEventArgs
        {
            private bool _isSelected = false;
            private bool _fieldData = false;
            private object obj = null;
            private IDictionary<string, object> _changedValues = new Dictionary<string, object>();
            /// <summary>
            /// Data field to be delivered. Object to be selected.
            /// </summary>
            public bool FieldPath
            {
                get { return _fieldData; }
                set { _fieldData = value; }
            }
            /// <summary>
            ///  Data object
            /// </summary>
            /// <param name="value"></param>
            public void DataObject(object value)
            {
                obj = value;
            }
            /// <summary>
            ///  Selected status. True if it has been selected. False otherwise
            /// </summary>
            public bool IsSelected
            {
                get { return _isSelected; }
                set { _isSelected = value; }
            }
            /// <summary>
            /// ChangedValues status. Dictionary for the changed values.
            /// </summary>
            public IDictionary<string, object> ChangedValuesObjects
            {
                get { return _changedValues; }
                set { _changedValues = value; }
            }

            /// <summary>
            /// Constructor for the datafield..
            /// </summary>
            public DataFieldCheckBoxEventArgs() : base()
            {

            }
            /// <summary>
            ///  C
            /// </summary>
            /// <param name="routedEvent"></param>
            public DataFieldCheckBoxEventArgs(RoutedEvent routedEvent) : base(routedEvent)
            {

            }
        }
    
}