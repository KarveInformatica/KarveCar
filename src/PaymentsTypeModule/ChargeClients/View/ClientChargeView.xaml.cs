using System.Windows.Controls;

namespace PaymentTypeModule.ChargeClients.View
{
    /// <summary>
    /// Interaction logic for ClientChargeWindow.xaml
    /// </summary>
    public partial class ClientChargeView: UserControl, IPaymentView
    {
        public ClientChargeView()

        {
            InitializeComponent();
            this.PaymentSystem.Theme = ExtendedGrid.ExtendedGridControl.ExtendedDataGrid.Themes.Office2007Silver;
           
        }
    }
}
