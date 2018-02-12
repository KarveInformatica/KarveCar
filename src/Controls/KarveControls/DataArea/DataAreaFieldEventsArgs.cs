using KarveControls.Generic;
using System.Collections.Generic;
using System.Windows;

namespace KarveControls
{
    /// <summary>
    ///  Data Area Event when a change happens.
    /// </summary>
    public class DataAreaFieldEventsArgs : KarveRoutedEventsArgs
    {
        private IDictionary<string, object> _changedValues = new Dictionary<string, object>();
        /// <summary>
        ///  Public event raised.
        /// </summary>
        public DataAreaFieldEventsArgs() : base()
        {

        }
        /// <summary>
        /// event and args.
        /// </summary>
        /// <param name="routedEvent"></param>
        public DataAreaFieldEventsArgs(RoutedEvent routedEvent) : base(routedEvent)
        {

        }
    }
}