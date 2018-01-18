using System.Collections.Specialized;

namespace KarveControls.KarveGrid
{
    internal class GridViewCollectionChangedEventArgs
    {
        public NotifyCollectionChangedAction Action { get; internal set; }
        public object NewItems { get; internal set; }
    }
}