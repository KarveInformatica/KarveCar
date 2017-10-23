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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using KarveControls.UIObjects;
using MasterModule.Common;
using MasterModule.Interfaces;
namespace MasterModule.Views
{
    /// <summary>
    /// Interaction logic for ProviderInfoView.xaml
    /// </summary>
    public partial class ProviderInfoView : UserControl, ISupplierInfoView
    {
        public ProviderInfoView()
        {
            InitializeComponent();
            Header = "";
        }

        public string Header
        { set; get; }

        

    }
    
    

}
