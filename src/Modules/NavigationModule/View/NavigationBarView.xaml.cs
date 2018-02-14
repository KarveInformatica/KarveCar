using System;
using System.Windows;
using System.Windows.Controls;

namespace NavigationBarModule
{
    /// <summary>
    /// Interaction logic for NavigationBarView.xaml
    /// </summary>
    public partial class NavigationBarView : UserControl
    {
        public NavigationBarView()
        {
            try
            {
                InitializeComponent();
            } catch (Exception e)
            {
                MessageBox.Show(e.Message, "KarveError", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
