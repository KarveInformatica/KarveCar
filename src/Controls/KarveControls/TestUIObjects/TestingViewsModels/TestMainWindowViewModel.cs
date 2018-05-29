using KarveControls.Interactivity;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Mvvm;
using Syncfusion.UI.Xaml.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using KarveDataServices;
using KarveDataAccessLayer;
using KarveDataServices.DataTransferObject;
using KarveCommonInterfaces;
using DataAccessLayer.FilterService;
using System.Windows;
using KarveCommon.Generic;
using System.ComponentModel;

namespace TestUIComponents.TestingViewsModels
{
    /// <summary>
    ///  Test the main windows model.
    /// </summary>
    class TestMainWindowViewModel: BindableBase
    {
        private IUnityContainer _unityContainer;
        private RequestController _controller = null;
        private string _assistProperties = string.Empty;
        private IDataServices dataServices;
        private IncrementalList<ClientSummaryExtended> _clientSummaryDto;
        private AbstractDomainWrapperFactory _domainFactory;
        private IDataFilterService _dataFilterService;
        private IClientDataServices _clientDataServices;
        private INotifyTaskCompletion<IEnumerable<ClientSummaryExtended>> notifyTaskCompletion;
        private PropertyChangedEventHandler evSummaryCompleted;
        private object _sourceView;
        /// <summary>
        ///  Unity 
        /// </summary>
        /// <param name="unityContainer">Container </param>
        public TestMainWindowViewModel(IUnityContainer unityContainer, IDataServices dataServices,ISqlExecutor executor)
        {
            _clientDataServices = dataServices.GetClientDataServices();
            _domainFactory = AbstractDomainWrapperFactory.GetFactory(dataServices);
            _unityContainer = unityContainer;
            evSummaryCompleted += OnEventCompleted;
            SourceView = new IncrementalList<ClientSummaryExtended>(LoadMoreItems) { MaxItemCount = 10000 };
            //Controller = _unityContainer.Resolve<RequestController>();
            ItemChangedCommand = new DelegateCommand<Dictionary<string,object>>(OnItemChangedCommand);
            AssistCommand = new DelegateCommand<object>(OnAssistCommand);
            GridCommand = new DelegateCommand<object>(OnGridFilterCommand);
            _dataFilterService = new DataFilterSummaryService<ClientSummaryExtended>(null, executor);
            _dataFilterService.FilterEventResult += _dataFilterService_FilterEventResult;
            notifyTaskCompletion = NotifyTaskCompletion.Create(_clientDataServices.GetPagedSummaryDoAsync(1,500), evSummaryCompleted);
        }

        private void OnEventCompleted(object sender, PropertyChangedEventArgs e)
        {
            var currentSender = sender as INotifyTaskCompletion<IEnumerable<ClientSummaryExtended>>;
            if (currentSender.IsSuccessfullyCompleted)
            {
                var result = currentSender.Result;
                if (SourceView is IncrementalList<ClientSummaryExtended> summary)
                {
                    summary.LoadItems(result);
                }
            }
        }

        private void _dataFilterService_FilterEventResult(object data)
        {
            var currentData = data;
            MessageBox.Show("Show current filter");
        }

        public ICommand GridCommand { set; get; }


        private async void OnGridFilterCommand(object obj)
        {
            IQueryFilter filter = obj as IQueryFilter;
            var query = filter.Resolve();
            await _dataFilterService.FilterDataAsync(query);
        }        
        private void OnAssistCommand(object obj)
        {
            
        }

        /// <summary>
        /// Load more items.
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        private async void LoadMoreItems(uint arg1, int arg2)
        {
            IEnumerable <ClientSummaryExtended> clientExtended=await _clientDataServices.GetPagedSummaryDoAsync(arg2, 200);
            if (SourceView is IncrementalList<ClientSummaryExtended> extededSummary)
            {
                extededSummary.LoadItems(clientExtended);
                SourceView = extededSummary;
            }
        }
        private void OnItemChangedCommand(Dictionary<string, object> obj)
        {   
        }
        public ICommand ItemChangedCommand { set; get; }
        public DelegateCommand<object> AssistCommand { get; }

        /// <summary>
        /// Set or Get the SourceViewMagnifier.
        /// </summary>
        public object SourceViewMagnifier
        {
            set
            {
                _sourceView = value;
                RaisePropertyChanged();
            }
            get
            {
                return _sourceView;
            }
        }

        // Set or Get IsVisible
        public bool IsVisible { set; get; }
        // Set or Get AssistProperties.
        public string AssistProperties { set
            {
                _assistProperties = value;
                RaisePropertyChanged();
            }
            get
            {
                return _assistProperties;
            }
        }
        /// <summary>
        ///  Set or Get the unity container.
        /// </summary>
        public IUnityContainer UnityContainer
        {
            set
            {
                _unityContainer = value;
                Controller = _unityContainer.Resolve<RequestController>();

            }
            get
            {
                return _unityContainer;
            }
        }
        /// <summary>
        /// Set or Get the source view.
        /// </summary>
        public object SourceView { set; get; }
        /// <summary>
        ///  Set or Get the selected item.
        /// </summary>
        public object SelectedItem { set; get; }
        /// <summary>
        ///  Set or Get The controller.
        /// </summary>
        public RequestController Controller {
            set
            {
                _controller = value;
                RaisePropertyChanged();
            }
            get
            {
                return _controller;
            }
        }

    }
}
