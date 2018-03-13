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

namespace InvoiceModule.Views
{
    /// <summary>
    /// Interaction logic for InvoiceControlView.xaml
    /// </summary>
    public partial class InvoiceControlView : UserControl
    {

        private string _header = "Facturas";

        public string Header { get { return _header; } }

        public InvoiceControlView()
        {
            try
            {
                InitializeComponent();
            } catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
