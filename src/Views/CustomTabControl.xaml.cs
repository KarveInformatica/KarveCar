using KarveCar.Logic;
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

namespace KarveCar.View
{
    /// <summary>
    /// Interaction logic for CustomTabControl.xaml
    /// </summary>
    public partial class CustomTabControl : TabItem
    {
        private ConfigurationService.CustomTabItemViewModel _model = new ConfigurationService.CustomTabItemViewModel();
        public CustomTabControl()
        {
            InitializeComponent();
        }
        public ConfigurationService.CustomTabItemViewModel Model
        {
            set { _model=value; }
            get { return _model; }
        }

    }
}
