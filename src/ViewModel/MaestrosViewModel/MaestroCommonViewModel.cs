using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Regions;

namespace KarveCar.ViewModel.MaestrosViewModel
{
    /// <summary>
    ///  View model for the selection of the maestro registry from the main window.
    /// </summary>
    public class MaestroCommonViewModel
    {
        private readonly IRegionManager _regionManager;
        public DelegateCommand<string> NavigateCommand { get; set; }
        public MaestroCommonViewModel()
        {
            
        }
        public MaestroCommonViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            NavigateCommand = new DelegateCommand<string>(Navigate);
        }

        void Navigate(string navigationPath)
        {
            _regionManager.RequestNavigate("TabRegion", navigationPath);
        }
    }
}
