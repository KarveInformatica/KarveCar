using System.Collections.Generic;
using System.Windows.Controls;
using KarveCommon.Generic;
using KarveControls.UIObjects;
using MasterModule.Interfaces;
using MasterModule.ViewModels;
using Prism.Regions;

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
}
