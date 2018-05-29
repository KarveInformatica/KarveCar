using System;
using System.Windows;
using System.Windows.Controls;

namespace InvoiceModule.Views
{
    /// <summary>
    ///     Interaction logic for InvoiceControlView.xaml
    /// </summary>
    public partial class InvoiceControlView : UserControl
    {
        public InvoiceControlView()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public string Header { get; } = "Facturas";
    }
}