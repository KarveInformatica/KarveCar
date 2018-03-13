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
using Syncfusion.UI.Xaml.Grid;
using System.Collections.ObjectModel;

namespace MasterModule.ViewModels
{
    internal sealed class DriversControlViewModel: KarveViewModelBase, INavigationAware
    {
        IRegionManager _regionManager;
        IRegionNavigationJournal _journal;
        private INotifyTaskCompletion<IEnumerable<ClientSummaryDto>> _notifyTaskCompletion;
        private PropertyChangedEventHandler _notificationHandler;
        private IncrementalList<ClientSummaryDto> _drivers;
        private IEnumerable<ClientSummaryDto> _currentDrivers;
        private bool _isBusy;

        public bool IsBusy { get { return _isBusy; }
                             set { _isBusy = value;
                RaisePropertyChanged(); } }

        public DriversControlViewModel(IDataServices services, IRegionManager manager): base(services)
        {
            _regionManager = manager;
            GoBackCommand = new DelegateCommand(GoBack);
            _drivers = new IncrementalList<ClientSummaryDto>(LoadMoreItems) { MaxItemCount = 2000 }; ;
            GoForwardCommand = new DelegateCommand(GoForward);
            _notifyTaskCompletion = NotifyTaskCompletion.Create<IEnumerable<ClientSummaryDto>>(LoadData(services), _notificationHandler);
            _notificationHandler += OnLoadedNotification;
          
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
                    _currentDrivers = value;
                    IsBusy = true;
                    _drivers = new IncrementalList<ClientSummaryDto>(LoadMoreItems) { MaxItemCount = 3000 };
                    RaisePropertyChanged("Drivers");
                    IsBusy = false;
                 
                }
                else
                {
                    // message boxes shall be moved with 
                    MessageBox.Show(clientSummary.ErrorMessage);
                }
            }
        }

        void LoadMoreItems(uint count, int baseIndex)
        {
            var _orders = _currentDrivers;
            var list = _orders.Skip(baseIndex).Take(50).ToList();
            Drivers.LoadItems(list);
        }
        private async Task<IEnumerable<ClientSummaryDto>> LoadData(IDataServices services)
        {
            IClientDataServices clientDataServices = services.GetClientDataServices();
            var result = await clientDataServices.GetClientSummaryDo(GenericSql.ExtendedClientsSummaryQuery);
            _currentDrivers = result;
            return result;
        }

       
        public DelegateCommand GoForwardCommand { get; set; }
        public DelegateCommand GoBackCommand { get; set; }

        public IncrementalList<ClientSummaryDto> Drivers
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
