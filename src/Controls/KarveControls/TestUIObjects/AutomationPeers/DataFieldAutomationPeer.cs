using KarveControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation.Peers;
using System.Windows.Documents;

namespace TestUIComponents.AutomationPeers
{
    /// <summary>
    ///  This is a class for the automation of a data field control.
    /// </summary>
    class DataFieldAutomationPeer : FrameworkElementAutomationPeer
    {
        /// <summary>
        ///  Automation peer for a data field
        /// </summary>
        /// <param name="owner"></param>
        public DataFieldAutomationPeer(DataField owner): base(owner)
        {
            if (!(owner is DataField))
                throw new ArgumentOutOfRangeException();
        }

    }
}
