using KarveControls.Generic;
using System.Windows;

namespace DualFieldSearchBox
{
    public partial class DualFieldSearchBox
    {
        /// <summary>
        ///  This event gets raise when a code has been raised.
        /// </summary>
        public class SearchBoxResolvedEventArgs : KarveRoutedEventsArgs
        {
            /// <summary>
            ///  SearchBoxResolvedEventArgs.
            /// </summary>
            public SearchBoxResolvedEventArgs() : base()
            {
            }

            public SearchBoxResolvedEventArgs(RoutedEvent routedEvent) : base(routedEvent)
            {
            }

            /// <summary>
            /// Set or Get the query.
            /// </summary>
            public string Code { get; set; }
            /// <summary>
            /// Set or Get the data.
            /// </summary>
            public string Data { get; set; }

        }
    }

}