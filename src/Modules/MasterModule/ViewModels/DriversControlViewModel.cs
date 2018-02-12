using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using KarveCommon.Generic;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using Prism.Commands;
using Prism.Regions;

namespace MasterModule.ViewModels
{
    class DriversControlViewModel: KarveViewModelBase, INavigationAware
    {
        IRegionManager _regionManager;
        IRegionNavigationJournal _journal;
        private INotifyTaskCompletion<IEnumerable<ClientSummaryDto>> _notifyTaskCompletion;
        private PropertyChangedEventHandler _notificationHandler;
        private IEnumerable<ClientSummaryDto> _drivers;

        public DriversControlViewModel(IDataServices services, IRegionManager manager): base(services)
        {
            _regionManager = manager;
            GoBackCommand = new DelegateCommand(GoBack);
            GoForwardCommand = new DelegateCommand(GoForward);
            _notificationHandler += OnLoadedNotification;
            _notifyTaskCompletion = NotifyTaskCompletion.Create<IEnumerable<ClientSummaryDto>>(LoadData(services), _notificationHandler);
        }

        /// <summary>
        ///  TODO: This is the correct version of load notification.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoadedNotification(object sender, PropertyChangedEventArgs e)
        {
            INotifyTaskCompletion<IEnumerable<ClientSummaryDto>> clientSummary =
                sender as INotifyTaskCompletion<IEnumerable<ClientSummaryDto>>;

            if (clientSummary != null)
            {
                if (clientSummary.IsSuccessfullyCompleted)
                {
                    var value = clientSummary.Task.Result;
                    Drivers = value;
                }
                else
                {
                    // message boxes shall be moved with 
                    MessageBox.Show(clientSummary.ErrorMessage);
                }
            }
        }

        private async Task<IEnumerable<ClientSummaryDto>> LoadData(IDataServices services)
        {
            IClientDataServices clientDataServices = services.GetClientDataServices();
            var result = await clientDataServices.GetClientSummaryDo(GenericSql.ExtendedClientsSummaryQuery);
            return result;
        }

        //  public DelegateCommand<> PersonSelectedCommand { get; private set; }
        public DelegateCommand GoForwardCommand { get; set; }
        public DelegateCommand GoBackCommand { get; set; }
        public IEnumerable<ClientSummaryDto> Drivers
        {
            get { return _drivers; }
            set { _drivers = value; RaisePropertyChanged(); }
        }
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
