using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace KarveCommon.Generic
{

    /// <summary>
    /// An adapter for DependencyObject which implements ILinqToTree in
    /// order to allow Linq queries on the visual tree
    /// </summary>
    public class VisualTreeAdapter : ILinqToTree<DependencyObject>
    {
        private DependencyObject _item;

        public VisualTreeAdapter(DependencyObject item)
        {
            _item = item;
        }

        public IEnumerable<ILinqToTree<DependencyObject>> Children()
        {
            int childrenCount = VisualTreeHelper.GetChildrenCount(_item);
            for (int i = 0; i < childrenCount; i++)
            {
                yield return new VisualTreeAdapter(VisualTreeHelper.GetChild(_item, i));
            }
        }

        public ILinqToTree<DependencyObject> Parent
        {
            get
            {
                return new VisualTreeAdapter(VisualTreeHelper.GetParent(_item));
            }
        }

        public DependencyObject Item
        {
            get
            {
                return _item;
            }
        }

    }
    
}
