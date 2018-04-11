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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AssistTestApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMainView
    {
        private IUnityContainer _container;

        public MainWindow()
        {
            InitializeComponent();
            if (Container!=null)
            {
                IAssistViewModel model = Container.Resolve<IAssistViewModel>();
                this.DataContext = model;
            }
        }
        public IUnityContainer Container
        {
            set
            {
                this._container = value;
                this.DataContext = _container.Resolve<IAssistViewModel>();
            }
            get
            {
                return this._container;
            }
        }
    }
}
