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

namespace KarveControls
{
    /// <summary>
    /// Interaction logic for DriverUserControl.xaml
    /// </summary>
    public partial class DriverUserControl : UserControl
    {
        public DriverUserControl()
        {
            InitializeComponent();
            this.CreditCardDriver1.VisibilitySecurity = Visibility.Collapsed;
            this.CreditCardDriver1.VisibilityToken = Visibility.Collapsed;

        }
    }
}
