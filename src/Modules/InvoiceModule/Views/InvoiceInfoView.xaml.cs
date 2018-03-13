using System.Windows.Controls;

namespace InvoiceModule.Views
{
    /// <summary>
    /// Interaction logic for InvoiceInfoView
    /// </summary>
    public partial class InvoiceInfoView : UserControl
    {
        /// <summary>
        ///  Set a new tab within the control header.
        /// </summary>
        public string Header { get; set;  }
        public InvoiceInfoView()
        {
            InitializeComponent();
        }
    }
}
