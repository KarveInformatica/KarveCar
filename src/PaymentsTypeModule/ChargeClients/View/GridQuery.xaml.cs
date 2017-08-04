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
            //this.PayementSystem.Theme = ExtendedGrid.ExtendedGridControl.ExtendedDataGrid.Themes.Office2007Silver;
        }
        public GridQuery(GridPopUpViewModel vm)
        {
            this.DataContext = vm;
            InitializeComponent();
            this.QueryType.Theme = ExtendedGrid.ExtendedGridControl.ExtendedDataGrid.Themes.Office2007Silver;
            //this.PayementSystem.Theme = ExtendedGrid.ExtendedGridControl.ExtendedDataGrid.Themes.Office2007Silver;
        }
    }
}
