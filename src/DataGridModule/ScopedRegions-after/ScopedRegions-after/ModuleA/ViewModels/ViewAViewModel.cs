using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using TabControlRegion.Core;

namespace ModuleA.ViewModels
{
    public class ViewAViewModel : ViewModelBase
    {
        private readonly IRegionManager _regionManager;

        public DelegateCommand<string> NavigateCommand { get; set; }

        public ViewAViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            Title = "View A"; 
            NavigateCommand = new DelegateCommand<string>(Navigate);
        }

        void Navigate(string navigationPath)
        {
            _regionManager.RequestNavigate("ChildRegion", navigationPath);
        }
    }
}
