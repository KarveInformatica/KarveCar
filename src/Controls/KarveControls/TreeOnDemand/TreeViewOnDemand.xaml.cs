using System.Windows.Controls;


namespace KarveControls
{
    public partial class TreeViewOnDemand : UserControl
    {
        public LoadOnDemandDemoControl()
        {
            InitializeComponent();

//            Region[] regions = Database.GetRegions();
//            CountryViewModel viewModel = new CountryViewModel(regions);
            base.DataContext = viewModel;
        }
    }
}