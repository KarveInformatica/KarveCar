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

namespace HelperModule.Views
{
    /// <summary>
    /// Interaction logic for RequestReason.xaml
    /// </summary>
    public partial class RequestReason : UserControl
    {
        private string _header = KarveLocale.Properties.Resources.lreason;
        public string Header { get { return _header; }  set { _header = value; } }
        public RequestReason()
        {
            InitializeComponent();
        }
    }
}
