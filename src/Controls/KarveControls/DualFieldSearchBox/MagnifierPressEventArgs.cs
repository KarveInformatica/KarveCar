using KarveControls.Generic;
using System.Collections.Generic;
using System.Windows;

namespace KarveControls
{
    public partial class DualFieldSearchBox
    {

        public class SelectedItemEventArgs: KarveRoutedEventsArgs
        {

        }
        /// <summary>
        /// MagnifierPressEventArgs. This is the event pressed when
        /// </summary>
        public class MagnifierPressEventArgs : KarveRoutedEventsArgs
        {
            /// <summary> 
            /// Constant to access to the tableName in the parameters of the event
            /// </summary>
            public const string ASSISTTABLE = "AssistTable";
            /// <summary>
            /// Constant to access to the queries in the parameters of the event
            /// </summary>
            public const string ASSISTQUERY = "AssistQuery";
            /// <summary>
            /// MagnifierPressEvents. Constructor 
            /// </summary>
            public MagnifierPressEventArgs() : base()
            {
                AssistQuery = string.Empty;
            }
            /// <summary>
            /// MagnifierPressEventsArgs. Event constructor 
            /// </summary>
            public MagnifierPressEventArgs(RoutedEvent routedEvent) : base(routedEvent)
            {
                AssistQuery = string.Empty;
            }
            /// <summary>
            ///  Parameters to be conveyed.
            /// </summary>
            public IDictionary<string, string> AssistParameters
            {
                get
                {
                    Dictionary<string, string> dictionary = new Dictionary<string, string>();
                    dictionary.Add(ASSISTTABLE, TableName);
                    dictionary.Add(ASSISTQUERY, AssistQuery);
                    return dictionary;
                }
            }
        
            /// <summary>
            /// Set or Get the query.
            /// </summary>
            public string AssistQuery { get; set; }
            /// <summary>
            /// Set or Get the tableName.
            /// </summary>
            public string TableName { get; set; }
        }
    }
}