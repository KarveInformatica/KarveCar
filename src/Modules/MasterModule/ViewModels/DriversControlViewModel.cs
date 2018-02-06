using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveCommon.Generic;
using KarveDataServices;
using Prism.Commands;
using Prism.Regions;

namespace MasterModule.ViewModels
{
    class DriversControlViewModel: KarveViewModelBase, INavigationAware
    {
        IRegionManager _regionManager;
        IRegionNavigationJournal _journal;

        public DriversControlViewModel(IDataServices services, IRegionManager manager): base(services)
        {
            _regionManager = manager;
            GoBackCommand = new DelegateCommand(GoBack);
            GoForwardCommand = new DelegateCommand(GoForward);
        }
      //  public DelegateCommand<> PersonSelectedCommand { get; private set; }
        public DelegateCommand GoForwardCommand { get; set; }

        public DelegateCommand GoBackCommand { get; set; }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            _journal = navigationContext.NavigationService.Journal;
            GoForwardCommand.RaiseCanExecuteChanged();
        }
        private void GoBack()
        {
            _journal.GoBack();
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        private void GoForward()
        {
            _journal.GoForward();
        }
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }
    }
}
