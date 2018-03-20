using KarveCommonInterfaces;
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

namespace MasterModule.Views
{
    /// <summary>
    /// Interaction logic for ClientsControlView.xaml
    /// </summary>
    public partial class ClientsControlView : UserControl, ICreateRegionManagerScope
    {
        public ClientsControlView()
        {
            InitializeComponent();
        }
        public string Header
        {
            get { return KarveLocale.Properties.Resources.lrgrMaestrosClientes; }

        }
        public bool CreateRegionManagerScope => false;
    }
}
