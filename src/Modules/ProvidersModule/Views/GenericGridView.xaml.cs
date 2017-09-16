using ProvidersModule.ViewModels;
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

namespace ProvidersModule.Views
{
    /// <summary>
    /// Interaction logic for GenericGridView.xaml
    /// </summary>
    public partial class GenericGridView : UserControl
    {
        private string header;
        public GenericGridView()
        {
            InitializeComponent();
            this.SuppliersGeneric.Theme = ExtendedGrid.ExtendedGridControl.ExtendedDataGrid.Themes.Office2007Silver;
        }
        public string Header
        {
            get

            {
                TabViewModelBase tvm = this.DataContext as TabViewModelBase;
                return tvm.Header;

            }

            set
            {
                header = value;
               
            }
        }
    }
}
