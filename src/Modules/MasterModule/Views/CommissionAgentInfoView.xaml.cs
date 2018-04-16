using System.Collections.Generic;
using System.Windows.Controls;
using KarveCommon.Generic;
using KarveControls.UIObjects;
using MasterModule.Interfaces;
using MasterModule.ViewModels;
using Prism.Regions;
using System.Windows.Data;
using System;
using System.Globalization;
using System.Diagnostics;
using Syncfusion.UI.Xaml.Grid;

namespace MasterModule.Views
{
    /// <summary>
    /// Interaction logic for CommissionAgentInfoView.xaml
    /// </summary>
    public partial class CommissionAgentInfoView : UserControl, ICommissionAgentView, INavigationAware
    {
        public CommissionAgentInfoView()
        {
            InitializeComponent();
         
           
        }
        public string Header
        { set; get; }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
          
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            Header = navigationContext.Parameters[ScopedRegionNavigationContentLoader.DefaultViewName] as string;
        }
        
    }
    public class DebugDummyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Debugger.Break();
            return value;
        }



        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Debugger.Break();
            return value;
        }


    }
}
