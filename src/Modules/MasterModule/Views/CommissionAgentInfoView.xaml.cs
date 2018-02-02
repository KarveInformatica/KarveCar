using System.Collections.Generic;
using System.Windows.Controls;
using KarveCommon.Generic;
using KarveControls.UIObjects;
using MasterModule.Interfaces;
using MasterModule.ViewModels;

namespace MasterModule.Views
{
    /// <summary>
    /// Interaction logic for CommissionAgentInfoView.xaml
    /// </summary>
    public partial class CommissionAgentInfoView : UserControl, ICommissionAgentView
    {
       public CommissionAgentInfoView()
        {
            InitializeComponent();
        }
        
        public string Header
        { set; get; }


    }
}
