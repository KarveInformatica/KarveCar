using Microsoft.Practices.Unity;
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
using System.Windows.Shapes;
using TestUIComponents.TestingViewsModels;

namespace TestUIComponents
{
    /// <summary>
    /// Interaction logic for DataFieldWindow.xaml
    /// </summary>
    public partial class TestMainWindow : Window
    {
        private IUnityContainer _container;
        public TestMainWindow()
        {
            InitializeComponent();

        }
        public new void Show()
        {
            var vmTest = _container.Resolve<TestMainWindowViewModel>();
            this.DataContext = vmTest;
            base.Show();
        }
        public IUnityContainer UnityContainer {
            set
            {
              
                _container = value;
            }
            get
            {
                return _container;
            }
        }
    }
}
