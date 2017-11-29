using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using Prism.Regions;

namespace MasterModule.Views
{
    /// <summary>
    /// Interaction logic for ProviderInfoView.xaml
    /// </summary>
    public partial class ProviderInfoView : UserControl, ISupplierInfoView, INavigationAware
    {
        public ProviderInfoView()
        {
            Stopwatch startStopwatch = new Stopwatch();
            startStopwatch.Start();
            InitializeComponent();
            startStopwatch.Stop();
            long width = startStopwatch.ElapsedMilliseconds;
            
            Header = "";
        }

        public string Header
        { set; get; }


        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            Header = navigationContext.Parameters[ScopedRegionNavigationContentLoader.DefaultViewName] as string;

        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
           
        }
    }
    
    

}
