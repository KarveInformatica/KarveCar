using System.Windows.Controls;
using PaymentTypeModule.ChargeClients.ViewModel;

namespace PaymentTypeModule.ChargeClients.View
{
    /// <summary>
    /// Interaction logic for GridQueryOffices.xaml
    /// </summary>
    public partial class GridQueryOffices : UserControl
    {
        
        public GridQueryOffices()
        {
            InitializeComponent();
            this.QueryType.Theme = ExtendedGrid.ExtendedGridControl.ExtendedDataGrid.Themes.Office2007Silver;
        }

        public GridQueryOffices(GridPopUpViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
            this.QueryType.Theme = ExtendedGrid.ExtendedGridControl.ExtendedDataGrid.Themes.Office2007Silver;

        }
    }
}
