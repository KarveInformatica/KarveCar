using System.Windows.Automation.Peers;

namespace TestUIComponents.CustomItems
{
    internal class KarveCalendarAutomationPeer : UIElementAutomationPeer
    {
        private readonly KarveCalendarUIElement _karveCalendarUIElement;

        public KarveCalendarAutomationPeer(KarveCalendarUIElement karveCalendarUIElement): base(karveCalendarUIElement)
        {
            _karveCalendarUIElement = karveCalendarUIElement;
        }
        protected override string GetClassNameCore()
        {
            return _karveCalendarUIElement.GetType().Name;
        }

        protected override string GetNameCore()
        {
            return _karveCalendarUIElement.Name;
        }

        protected override string GetAutomationIdCore()
        {
            return _karveCalendarUIElement.GetType().Name;
        }
    }
}