using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using KarveCommon.Generic;
using KarveDataServices;
using KarveDataServices.ViewObjects;
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
        private INotifyTaskCompletion<IEnumerable<ClientSummaryExtended>> _notifyTaskCompletion;
        private PropertyChangedEventHandler _notificationHandler;
        private IncrementalList<ClientSummaryExtended> _drivers;
        private IEnumerable<ClientSummaryExtended> _currentDrivers;
        private readonly IClientDataServices _clientDataServices;
        private bool _isBusy;

        public bool IsBusy { get { return _isBusy; }
                             set { _isBusy = value;
                RaisePropertyChanged(); } }

        public DriversControlViewModel(IDataServices services, IRegionManager manager): base(services)
        {
            _regionManager = manager;
            _clientDataServices = DataServices.GetClientDataServices();
            GoBackCommand = new DelegateCommand(GoBack);
            GoForwardCommand = new DelegateCommand(GoForward);
            _drivers    = new IncrementalList<ClientSummaryExtended>(LoadMoreItems);
            _notifyTaskCompletion = NotifyTaskCompletion.Create<IEnumerable<ClientSummaryExtended>>(_clientDataServices.GetPagedSummaryDoAsync(0, DefaultPageSize), PagingEvent); 
        }
      
        void LoadMoreItems(uint count, int baseIndex)
        {

            NotifyTaskCompletion.Create<IEnumerable<ClientSummaryExtended>>(
                _clientDataServices.GetPagedSummaryDoAsync(baseIndex, DefaultPageSize), PagingEvent);
        }
        public DelegateCommand GoForwardCommand { get; set; }
        public DelegateCommand GoBackCommand { get; set; }

        public IncrementalList<ClientSummaryExtended> Drivers
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
        public override void DisposeEvents()
        {
            base.DisposeEvents();
        }
        protected override void OnPagedEvent(object sender, PropertyChangedEventArgs e)
        {
            if (sender is INotifyTaskCompletion<IEnumerable<ClientSummaryExtended>> clientSummary && clientSummary.IsSuccessfullyCompleted)
            {
                var orders = clientSummary.Result;
                if (!Drivers.Any())
                {
                    Drivers = new IncrementalList<ClientSummaryExtended>(LoadMoreItems)
                    {
                        MaxItemCount = (int)_clientDataServices.NumberItems
                    };
                }
                Drivers.LoadItems(orders);
                RaisePropertyChanged("Drivers");
            }
           
        }
    }
}
