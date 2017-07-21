using System.Windows.Media;
using System.Windows;

namespace ExtendedGrid.Classes
{
    public static class Helper
    {
        #region GetVisualChild

        public static T GetVisualChild<T>(Visual parent) where T : Visual
        {
            T child = default(T);

            int numVisuals = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < numVisuals; i++)
            {
                var v = (Visual)VisualTreeHelper.GetChild(parent, i);
                child = v as T ?? GetVisualChild<T>(v);
                if (child != null)
                {
                    break;
                }
            }

            return child;
        }

        #endregion GetVisualChild

        #region FindVisualParent

        public static T FindVisualParent<T>(UIElement element) where T : UIElement
        {
            UIElement parent = element;
            while (parent != null)
            {
                var correctlyTyped = parent as T;
                if (correctlyTyped != null)
                {
                    return correctlyTyped;
                }

                parent = VisualTreeHelper.GetParent(parent) as UIElement;
            }

            return null;
        }

        #endregion FindVisualParent

        #region FindPartByName

        public static DependencyObject FindPartByName(DependencyObject ele, string name)
        {
            if (ele == null)
            {
                return null;
            }
            if (name.Equals(ele.GetValue(FrameworkElement.NameProperty)))
            {
                return ele;
            }

            var numVisuals = VisualTreeHelper.GetChildrenCount(ele);
            for (var i = 0; i < numVisuals; i++)
            {
                DependencyObject vis = VisualTreeHelper.GetChild(ele, i);
                DependencyObject result;
                if ((result = FindPartByName(vis, name)) != null)
                {
                    return result;
                }
            }
            return null;
        }

        #endregion FindPartByName
    }
}
