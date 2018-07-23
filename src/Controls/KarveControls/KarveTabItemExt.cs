using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KarveControls
{
    public class KarveTabItemExt
    {
        
        public static Visibility GetCloseButtonVisibility(DependencyObject obj)
        {
            return (Visibility)obj.GetValue(CloseButtonVisibilityProperty);
        }

        public static void SetCloseButtonVisibility(DependencyObject obj, Visibility value)
        {
            obj.SetValue(CloseButtonVisibilityProperty, value);
        }

        
        // Using a DependencyProperty as the backing store for IsSpecialTab.  This enables animation, styling, binding, etc...

        public static readonly DependencyProperty CloseButtonVisibilityProperty =
        DependencyProperty.RegisterAttached("CloseButtonVisibility", typeof(Visibility), typeof(KarveTabItemExt), new PropertyMetadata(Visibility.Hidden));

    }
}
