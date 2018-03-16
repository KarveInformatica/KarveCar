using KarveCommon.Generic;
using KarveCommonInterfaces;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KarveCommon.ViewModels
{
    /// <summary>
    ///  GenericGridViewModel. This view model is used for the navigation. 
    ///  It is used specifically for each call inside a grid. 
    ///  It will be navigate and go back to the original grid using the journaling function.
    /// </summary>
    class GridDetailsViewModel : BindableBase, INavigationAware, IRegionMemberLifetime, IDisposable
    {
        private object _genericViewModel;
        private string _currentGridName;
        private string _currentIdentifier;

        public bool KeepAlive => false;
        private IRegionNavigationJournal _journal;
        private ICommand _goBackCommand;
        private IDataServices _dataServices;
        private IDialogService _dialogService;
        private INotifyTaskCompletion<IEnumerable<BaseDto>> _initializationTable;
        private PropertyChangedEventHandler _ev;

        /// <summary>
        ///  GenericGridViewModel. This is a grid view model for every loading.
        /// </summary>
        public GridDetailsViewModel(IDataServices dataServices, IDialogService dialogService)
        {
            GoBackCommand = new DelegateCommand(GoBack);
            _ev += OnLoadedHandler;
            _dataServices = dataServices;
            _dialogService = dialogService;
        }
        /// <summary>
        /// This load the value.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoadedHandler(object sender, PropertyChangedEventArgs e)
        {
            INotifyTaskCompletion<IEnumerable<BaseDto>> currentHandler = sender as INotifyTaskCompletion<IEnumerable<BaseDto>>;
            if (currentHandler != null)
            {
                if (currentHandler.IsSuccessfullyCompleted)
                {
                    DetailsView = currentHandler.Task.Result;
                }
                if (currentHandler.IsFaulted)
                {
                    if (_dialogService != null)
                    {
                        _dialogService.ShowErrorMessage(currentHandler.ErrorMessage);
                    }
                    
                }
            }
        }
        /// <summary>
        ///  IsNavigationTarget
        /// </summary>
        /// <param name="navigationContext">The navigation context to be used.</param>
        /// <returns>True if the navigaion has been successfully</returns>
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            _currentIdentifier = navigationContext.Parameters["Id"] as string;
            _currentGridName = navigationContext.Parameters["AssistName"] as string;
            if (_currentGridName != null)
                return !string.IsNullOrEmpty(_currentGridName);
            else
                return true;
        }
        /// <summary>
        /// GoBackCommand. The command is when you go back.
        /// </summary>
        public ICommand GoBackCommand
        {
            set
            {
                _goBackCommand = value;
                RaisePropertyChanged();
            }
            get
            {
                return _goBackCommand;
            }
        }
        /// <summary>
        ///  In this view model the navigation from is not implemented.
        /// </summary>
        /// <param name="navigationContext"></param>
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }
        private void GoBack()
        {
            _journal.GoBack();
        }
        /// <summary>
        ///  The navigation context
        /// </summary>
        /// <param name="navigationContext">Navigation context to be used in the view model.</param>
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            _journal = navigationContext.NavigationService.Journal;
            //_initializationTable = NotifyTaskCompletion.Create<IEnumerable<BaseDto>>(dataLoader.LoadAsync(_currentGridName, _currentIdentifier), _ev);
            // _currentIdentifier = navigationContext.Parameters["Id"] as string;
            // _currentGridName = navigationContext.Parameters["AssistName"] as string;
            //ProxyDataLoader dataLoader = new ProxyDataLoader(_dataServices, _currentGridName);

        }

        public void Dispose()
        {
            _ev -= OnLoadedHandler;
        }

        public object DetailsView
        {
            set
            {
                _genericViewModel = value;
                RaisePropertyChanged();
            }
            get
            {
                return _genericViewModel;
            }
        }
    }
    
}
