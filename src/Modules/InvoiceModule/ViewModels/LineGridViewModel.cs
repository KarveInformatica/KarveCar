
using Prism.Mvvm;
using Syncfusion.UI.Xaml.Grid;
using System.Collections.ObjectModel;
using Prism.Regions;
using System.Windows.Input;
using Prism.Commands;
using System.Windows;
using System.Collections.Generic;
using System.Windows.Controls;
using System;
using InvoiceModule.Views;
using static InvoiceModule.LineGridBehaviour;
using KarveDataServices.DataTransferObject;
using KarveCommonInterfaces;


namespace InvoiceModule.ViewModels
{
    /// <summary>
    ///  LineGridViewModel. This is the view model for the line grid.
    /// </summary>
    public class LineGridViewModel : BindableBase, INavigationAware, IRegionMemberLifetime
    {
        /// <summary>
        ///  Constructor of the items.
        /// </summary>
        public LineGridViewModel(IRegionManager regionManager, IDialogService dialogService)
        {
            _regionManager = regionManager;
            _dialogService = dialogService;
            SourceView = new ObservableCollection<InvoiceSummaryDto>()
            {
                new InvoiceSummaryDto() {
                                AgreementCode = "0",
                                Price = 10, Subtotal = 10},
                new InvoiceSummaryDto()
                {
                    AgreementCode="10",
                    Price=10,
                    Subtotal=10
                },
                new InvoiceSummaryDto()
                {
                    AgreementCode="10",
                    Price=10,
                    Subtotal=10
                },
                 new InvoiceSummaryDto()
                {
                    AgreementCode="10",
                    Price=10,
                    Subtotal=10
                }
            };
            CellTemplateCollection = new List<CellPresenterItem>()
            {
                new CellPresenterItem()
                {
                    MappingName="AgreementCode"
                },
                new CellPresenterItem()
                {
                    MappingName="Price"
                }
            };
            NavigateCommand = new DelegateCommand<object>(OnNavigate);
            NavigatedTo = new DelegateCommand<object>(OnNavigate);
        }


        /// <summary>
        /// Command for allowing forward or backward navigation in the  
        /// </summary>
        public ICommand NavigateCommand
        {
            set
            {
                _navigationValue = value;
                RaisePropertyChanged();
            }
            get
            {
                return _navigationValue;
            }
        }
        /// <summary>
        ///  Cell Modification and templating.
        /// </summary>
        public ObservableCollection<CellPresenterItem> CellPresentation
        {
            set
            {
                _cellPresentation = value;
                RaisePropertyChanged();
            }
            get
            {
                return _cellPresentation;
            }
        }
        /// <summary>
        ///  Navigation to the region.
        /// </summary>
        public ICommand NavigatedTo
        {
            set
            {
                _navigationValue = value;
                RaisePropertyChanged();
            }
            get
            {
                return _navigationValue;
            }
        }
        /// <summary>
        ///  This provide the list of data template foreach cell.
        /// </summary>
        public List<LineGridBehaviour.CellPresenterItem> CellTemplateCollection
        {
            set {
                _cellTemplateList = value;
                RaisePropertyChanged();
            }
            get {
                return _cellTemplateList;
            }
        }
       
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            _journal = navigationContext.NavigationService.Journal;
            GoForwardCommand.RaiseCanExecuteChanged();
        }
        
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public DelegateCommand GoForwardCommand { get; set; }

        public ObservableCollection<InvoiceSummaryDto> SourceView
        {
            set
            {
                _pagedSource = value;
                RaisePropertyChanged();
            }
            get { return _pagedSource; }
        }

        public bool IsBusy { get; private set; }
        public bool KeepAlive => false;
        
        
        
        #region Private Methods
        
        /// <summary>
        ///  This method is fired up by a delegate command in case of forward navigation
        /// </summary>
        /// <param name="param">TextBlock to be passed when then command gets executed.</param>
        private void OnNavigate(object param)
        {
            TextBlock value = param as TextBlock;
            string assistName = Behaviour.Ext.GetAssistName(value) as string;
            if (assistName != null)
            {
                var navigationParameters = new NavigationParameters();
                var id = value.Text;
                navigationParameters.Add("Id", id);
                navigationParameters.Add("AssistName", assistName);
                _regionManager.RequestNavigate("LineRegion", "GenericGridView", navigationParameters);
            }
        }
        private void GoForward()
        {
            _journal.GoForward();
        }
        private bool CanGoBack()
        {
            return true;
        }
        private bool CanGoForward()
        {
            return _journal != null && _journal.CanGoForward;
        }
        #endregion 
        #region Private Fields
        private List<CellPresenterItem> _cellTemplateList;
        private ObservableCollection<InvoiceSummaryDto> _pagedSource;
        private ICommand _navigationValue;
        private IRegionManager _regionManager;
        private IRegionNavigationJournal _journal;
        private IDialogService _dialogService;
        private ObservableCollection<CellPresenterItem> _cellPresentation;
        #endregion
    };
}
