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
using MasterModule.Interfaces;

namespace MasterModule.Views
{
    /// <summary>
    /// Interaction logic for CommisionView.xaml
    /// </summary>
    public partial class CommissionAgentControlView : UserControl, ICommissionAgentView
    {
        private string _header = KarveLocale.Properties.Resources.lrbtnComisionistas;
        public CommissionAgentControlView()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Comisionista
        /// </summary>
        public string Header
        {
            get { return _header; }
        }
    }
}
