using System.Windows;

namespace KarveControls.KarveGrid.Events
{
    internal class PageChangingEventArgs: RoutedEventArgs
    {
        private RoutedEvent pageChangeEvent;

        public PageChangingEventArgs(RoutedEvent pageChangeEvent)
        {
            this.pageChangeEvent = pageChangeEvent;
        }

        public int PageIndex { get; internal set; }
    }
}