using System;
using System.Windows;
using System.Windows.Controls;

namespace ToolBarModule
{
    /// <summary>
    /// Interaction logic for KarveToolBarView.xaml
    /// </summary>
    public partial class KarveToolBarView : UserControl, IToolBarView
    {
        public KarveToolBarView()
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
