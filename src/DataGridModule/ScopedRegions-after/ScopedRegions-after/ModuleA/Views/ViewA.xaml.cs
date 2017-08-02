using System.Windows.Controls;
using Microsoft.Practices.Prism.Mvvm;
using TabControlRegion.Core.Prism;

namespace ModuleA.Views
{
    /// <summary>
    /// Interaction logic for ViewA.xaml
    /// </summary>
    public partial class ViewA : UserControl, IView, ICreateRegionManagerScope
    {
        public ViewA()
        {
            InitializeComponent();
        }

        public bool CreateRegionManagerScope
        {
            get { return true; }
        }
    }
}
