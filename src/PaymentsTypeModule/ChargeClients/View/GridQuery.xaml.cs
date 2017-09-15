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
            this.QueryType.Theme = ExtendedGrid.ExtendedGridControl.ExtendedDataGrid.Themes.Office2007Silver;
            
        }
        public GridQuery(GridPopUpViewModel vm)
        {
            this.DataContext = vm;
            InitializeComponent();
            this.QueryType.Theme = ExtendedGrid.ExtendedGridControl.ExtendedDataGrid.Themes.Office2007Silver;
            
        }
    }
}
