using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TestUIComponents.TestingViews;
using System.Windows.Automation.Peers;
using TestUIComponents.AutomationPeers;

namespace TestUIComponents
{
    [TestFixture]
    class TestDataField
    {
        private DataFieldWindow _dataFieldWindow;
        private WindowAutomationPeer _windowPeer;
        private DataFieldAutomationPeer _dataFieldAutomationPeer;

        [SetUp]
        public void SetUp()
        {
            _dataFieldWindow = new DataFieldWindow();
            _windowPeer = new WindowAutomationPeer(_dataFieldWindow);
            List<AutomationPeer> children = _windowPeer.GetChildren();

            /*   windowPeer = new WindowAutomationPeer(window);
               List<AutomationPeer> children = windowPeer.GetChildren();
               buttonPeer = (ButtonAutomationPeer)children[0];
               textBoxPeer = (TextBoxAutomationPeer)children[1];
               */
        }

    }
}
