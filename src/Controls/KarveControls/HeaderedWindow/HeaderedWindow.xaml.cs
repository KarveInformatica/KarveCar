using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using KarveCommonInterfaces;

namespace KarveControls.HeaderedWindow
{
    /// <summary>
    /// Interaction logic for HeaderedWindow.xaml
    /// </summary>
    public partial class HeaderedWindow : UserControl, IHeaderedView
    {
        public string Header { get; set; }
        public HeaderedWindow()
        {
            InitializeComponent();

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
        // this.HeaderPart.MaxWidth = this.ActualWidth ; 
//             this.LinesPart.MaxWidth = this.ActualWidth * 0.87;
        // this.FooterPart.MaxWidth = this.ActualWidth;
        }

        private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //this.HeaderPart.MaxWidth = this.ActualWidth * 0.87;
            //this.LinesPart.MaxWidth = this.ActualWidth * 0.87;
           // this.FooterPart.MaxWidth = this.ActualWidth * 0.87;
        }
    }
}
