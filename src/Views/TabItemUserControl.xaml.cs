using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace KarveCar.View
{
    /// <summary>
    /// Lógica de interacción para TabItemUserControl.xaml
    /// </summary>
    public partial class TabItemUserControl : TabItem
    {
        public TabItemUserControl()
        {
            InitializeComponent();
            //this.SizeChanged+=OnSizeChanged;
        }

        private void OnSizeChanged(object sender, SizeChangedEventArgs sizeChangedEventArgs)
        {
          //  SizeChangedEventArgs args = sizeChangedEventArgs;
          //  UIElement element = (UIElement)VisualTreeHelper.GetParent(this);
            
        }
    }
}
