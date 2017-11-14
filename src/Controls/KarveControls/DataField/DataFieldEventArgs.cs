using KarveControls.Generic;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace KarveControls
{
    public partial class DataField : UserControl
    {
        /// <summary>
        ///  Event args
        /// </summary>
        public class DataFieldEventArgs : KarveRoutedEventsArgs
        {
            
            /// <summary>
            ///  Constructror.
            /// </summary>
            public DataFieldEventArgs() : base()
            {

            }
            /// <summary>
            ///  Data field constructor.
            /// </summary>
            /// <param name="routedEvent"></param>
            public DataFieldEventArgs(RoutedEvent routedEvent) : base(routedEvent)
            {

            }
        }
    }
}
