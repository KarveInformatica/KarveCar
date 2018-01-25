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
    /// Interaction logic for CompanyCard.xaml
    /// </summary>
    public partial class CompanyCard : UserControl
    {
        private string _header = KarveLocale.Properties.Resources.lrbtnTarjetasEmpresa;
        public CompanyCard()
        {
            InitializeComponent();
        }
        /// <summary>
        ///  Credit card header.
        /// </summary>
        public string Header
        {
            set { _header = value; }
            get { return _header; }
        }
    }
}
