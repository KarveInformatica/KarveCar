using System.Windows.Controls;

namespace HelperModule.Views
{
    /// <summary>
    /// Interaction logic for SupplierCurrency
    /// </summary>
    public partial class SupplierCurrency : UserControl
    {
        private string _header = KarveLocale.Properties.Resources.lrbtnDivisas;
        public string Header { get { return _header; } }
        public SupplierCurrency()
        {
            InitializeComponent();
        }
    }
}
