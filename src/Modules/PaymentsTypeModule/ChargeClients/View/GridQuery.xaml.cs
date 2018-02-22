using System.Windows.Controls;
using PaymentTypeModule.ChargeClients.ViewModel;

namespace PaymentTypeModule.ChargeClients.View
{
    /// <summary>
    /// Interaction logic for GridQuery.xaml
    /// </summary>
    public partial class GridQuery : UserControl
    {
        public GridQuery()
        {
            InitializeComponent();   
        }
        public GridQuery(GridPopUpViewModel vm)
        {
            this.DataContext = vm;
            InitializeComponent();
        }
    }
}
