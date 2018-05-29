using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using KarveCommon.Generic;
using KarveCommonInterfaces;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace InvoiceModule.ViewModels
{
    /// <summary>
    ///     GenericGridViewModel. This view model is used for the navigation.
    ///     It is used specifically for each call inside a grid.
    ///     It will be navigate and go back to the original grid using the journaling function.
    /// </summary>
    internal class GenericGridViewModel : BindableBase, INavigationAware, IRegionMemberLifetime
    {
        private string _currentGridName;
        private string _currentIdentifier;
        private IDataServices _dataServices;
        private readonly IDialogService _dialogService;

        private PropertyChangedEventHandler _ev;
        private object _genericViewModel;
        private ICommand _goBackCommand;
        private IRegionNavigationJournal _journal;

        /// <summary>
        ///     GenericGridViewModel. This is a grid view model for every loading.
        /// </summary>
        public GenericGridViewModel(IDataServices dataServices, IDialogService dialogService)
        {
            GoBackCommand = new DelegateCommand(GoBack);
            _ev += OnLoadedHandler;
            _dataServices = dataServices;
            _dialogService = dialogService;
        }

        /// <summary>
        ///     GoBackCommand. The command is when you go back.
        /// </summary>
        public ICommand GoBackCommand
        {
            set
            {
                _goBackCommand = value;
                RaisePropertyChanged();
            }
            get => _goBackCommand;
        }

        public object GenericGridView
        {
            set
            {
                _genericViewModel = value;
                RaisePropertyChanged();
            }
            get => _genericViewModel;
        }

        /// <summary>
        ///     IsNavigationTarget
        /// </summary>
        /// <param name="navigationContext">The navigation context to be used.</param>
        /// <returns>True if the navigaion has been successfully</returns>
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            _currentIdentifier = navigationContext.Parameters["Id"] as string;
            _currentGridName = navigationContext.Parameters["AssistName"] as string;
            if (_currentGridName != null)
                return !string.IsNullOrEmpty(_currentGridName);
            return true;
        }

        /// <summary>
        ///     In this view model the navigation from is not implemented.
        /// </summary>
        /// <param name="navigationContext"></param>
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        /// <summary>
        ///     The navigation context
        /// </summary>
        /// <param name="navigationContext">Navigation context to be used in the view model.</param>
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            _journal = navigationContext.NavigationService.Journal;

            _currentIdentifier = navigationContext.Parameters["Id"] as string;
            _currentGridName = navigationContext.Parameters["AssistName"] as string;
        }

        public bool KeepAlive => false;

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoadedHandler(object sender, PropertyChangedEventArgs e)
        {
            var currentHandler = sender as INotifyTaskCompletion<IEnumerable<BaseDto>>;
            if (currentHandler != null)
            {
                if (currentHandler.IsSuccessfullyCompleted) GenericGridView = currentHandler.Task.Result;
                if (currentHandler.IsFaulted) _dialogService.ShowErrorMessage(currentHandler.ErrorMessage);
            }
        }

        private void GoBack()
        {
            _journal.GoBack();
        }
    }
}