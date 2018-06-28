using System.Windows.Controls;

namespace HelperModule.Views
{
    /// <summary>
    /// Interaction logic for PaymentForm
    /// </summary>
    public partial class PaymentForm : UserControl
    {
        private string _header = KarveLocale.Properties.Resources.lrbtnFormaPagoProveedor;
        public string Header { get { return _header; } }
        public PaymentForm()
        {
            InitializeComponent();
        }
    }
}
