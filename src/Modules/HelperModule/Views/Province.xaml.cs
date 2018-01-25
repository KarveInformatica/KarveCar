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
    /// Interaction logic for Province.xaml
    /// </summary>
    public partial class Province : UserControl
    {
        private string _header = KarveLocale.Properties.Resources.lrbtnProvincias;
        public string Header { get { return _header; } }

        public Province()
        {
            InitializeComponent();
        }
    }
}
