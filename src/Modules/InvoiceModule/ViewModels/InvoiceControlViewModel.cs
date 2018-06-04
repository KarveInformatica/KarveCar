using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using InvoiceModule.Views;
using KarveCommon.Generic;
using KarveCommon.Services;
using KarveCommonInterfaces;
using KarveControls.HeaderedWindow;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using MasterModule.Views;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Regions;
using Syncfusion.UI.Xaml.Grid;
using LineGridView = KarveControls.HeaderedWindow.LineGridView;

namespace InvoiceModule.ViewModels
{
    /// <summary>
    ///     This object has the resposability to show the list of invoices.
    /// </summary>
    public sealed class InvoiceControlViewModel : KarveRoutingBaseViewModel, INavigationAware, IEventObserver,
        IDisposeEvents
    {
      
        private const string SummaryViewConst = "SummaryView";
        private const int LoadStep = 50;
        private readonly IUnityContainer _container;
        private IRegionManager _detailsRegionManager;
        private PropertyChangedEventHandler _initEventHandler;
        private IEnumerable<InvoiceSummaryValueDto> _invoiceSummaryDtos;
        private IInvoiceDataServices _invoiceDataServices;
        private IncrementalList<InvoiceSummaryDto> _summaryValue;
        

        private bool _isBusy;

        /// <summary>
        ///     data to be load
        /// </summary>
        private INotifyTaskCompletion<IEnumerable<InvoiceSummaryValueDto>> _taskInit;

        /// <summary>
        ///     Control the invoce control view model.
        /// </summary>
        /// <param name="dataServices">Data Services</param>
        /// <param name="container">Unity container</param>
        /// <param name="service">Service</param>
        /// <param name="manager">Region Manager</param>
        /// <param name="requestService">Request service</param>
        /// <param name="eventManager">Event manager</param>
        public InvoiceControlViewModel(IDataServices dataServices,
            IUnityContainer container,
            IDialogService service,
            IRegionManager manager,
            IInteractionRequestController requestService,
            IEventManager eventManager) : base(dataServices, requestService, service, eventManager)
        {
            _regionManager = manager;
            IsBusy = false;
            _container = container;
            OpenItemCommand = new DelegateCommand<object>(OpenCurrentItem);
            InitViewModel();
            ItemName = "Facturas";
            ShowClientCommand = new DelegateCommand<object>(OnShowClient);
            _invoiceDataServices = DataServices.GetInvoiceDataServices();
            ViewModelUri = new Uri("karve://invoice/viewmodel?id=" + UniqueId);
            MailboxName = ViewModelUri.ToString();
            EventManager.RegisterObserverSubsystem(InvoiceModule.InvoiceSubSystem, this);
            RegisterMailBox(ViewModelUri.ToString());
            PagingEvent += OnPagedEvent;
          
            StartAndNotify();
        }




        protected  override void OnPagedEvent(object sender, PropertyChangedEventArgs e)
        {
            INotifyTaskCompletion<IEnumerable<InvoiceSummaryValueDto>> listCompletion =
                sender as INotifyTaskCompletion<IEnumerable<InvoiceSummaryValueDto>>;
            if ((listCompletion != null) && (listCompletion.IsSuccessfullyCompleted))
            {
                IsBusy = false;
                if (SummaryView is IncrementalList<InvoiceSummaryValueDto> summary)
                {
                    summary.LoadItems(listCompletion.Result);
                    SummaryView = summary;
                }
            }

            if ((listCompletion != null) && (listCompletion.IsFaulted))
            {
                DialogService?.ShowErrorMessage("Error Loading data " + listCompletion.ErrorMessage);
            }
        }

        public ICommand ShowClientCommand { set; get; }

        /// <summary>
        ///     OpenItemCommand.
        /// </summary>
        public ICommand OpenItemCommand { set; get; }

        /// <summary>
        ///     This view is a summary to fill the control table for the invoice.
        /// </summary>
        public new IncrementalList<InvoiceSummaryValueDto> SummaryView
        {
            get => _summaryView;
            set
            {
                _summaryView = value;
                RaisePropertyChanged(SummaryViewConst);
            }
        }

        /// <summary>
        ///     Return true if the value is busy.
        /// </summary>
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                RaisePropertyChanged("IsBusy");
            }
        }

        public override void DisposeEvents()
        {
            if (MailBoxHandler != null) MailBoxHandler -= MailboxHandlerName;
            EventManager.DeleteObserverSubSystem(InvoiceModule.InvoiceSubSystem, this);
            DeleteMailBox(MailboxName);
            PagingEvent -= OnPagedEvent;
            // do what to do with _detailsRegionManager.
        }

        public void IncomingPayload(DataPayLoad payload)
        {
            if (payload.Sender == null)
            {
                throw new ArgumentNullException("Sender of the payload shall be present");
            }
            _isTestPayload = payload.IsTest;
            if (payload.Sender == ViewModelUri.ToString()) return;
            switch (payload.PayloadType)
            {
                case DataPayLoad.Type.UpdateView:
                    StartAndNotify();
                    break;
                case DataPayLoad.Type.Insert:
                    
                        NewItem();
                    
                    break;
            }
        }

        /// <summary>
        ///     This true if it is a navigation target.
        /// </summary>
        /// <param name="navigationContext"></param>
        /// <returns></returns>
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        /// <summary>
        ///     This is if it is navigated from.
        /// </summary>
        /// <param name="navigationContext"></param>
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        /// <summary>
        ///     This is if it is navigated to
        /// </summary>
        /// <param name="navigationContext"></param>
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
        }

        private async void OnShowClient(object obj)
        {
            var code = obj as string;
            if (code == null) return;

            var clientServices = DataServices.GetClientDataServices();
            var data = await clientServices.GetDoAsync(code);
            // i want just avoid a fetch of the client name.
            var viewName = data.Value.NUMERO_CLI + data.Value.NOMBRE;
            var navigationParameters = new NavigationParameters
            {
                {"id", code},
                {ScopedRegionNavigationContentLoader.DefaultViewName, viewName}
            };
            var uri = new Uri(typeof(ClientsInfoView).FullName + navigationParameters, UriKind.Relative);
            _regionManager.RequestNavigate("TabRegion", uri);
            var currentPayload = new DataPayLoad
            {
                Subsystem = DataSubSystem.ClientSubsystem,
                PayloadType = DataPayLoad.Type.Show,
                PrimaryKeyValue = code,
                HasDataObject = true,
                DataObject = data,
                Sender = EventSubsystem.ClientSummaryVm
            };
            EventManager.NotifyObserverSubsystem(EventSubsystem.ClientSummaryVm, currentPayload);
        }

        /// <summary>
        ///     This is a mailbox handler name.
        /// </summary>
        /// <param name="payLoad">Payload of the mailbox.</param>
        private void MailboxHandlerName(DataPayLoad payLoad)
        {
            if (payLoad != null)
            {
                if (payLoad.PayloadType == DataPayLoad.Type.Insert) NewItem();

               
            }
        }

        /// <summary>
        ///     Start the asynchronous load of the invoice.
        /// </summary>
        public void StartAndNotify()
        {
            _initEventHandler += OnLoadedSummary;
            _taskInit = NotifyTaskCompletion.Create(LoadAsync(), _initEventHandler);
        }

        /// <summary>
        ///     This load asynchronously a list of invoice summary values.
        /// </summary>
        /// <returns>This returns the summary value data transfer object</returns>
        private async Task<IEnumerable<InvoiceSummaryValueDto>> LoadAsync()
        {
            var value = await _invoiceDataServices.GetPagedSummaryDoAsync(1, DefaultPageSize);
            if (value == null) return value;
            var invoiceSummaryValueDtos = value as InvoiceSummaryValueDto[] ?? value.ToArray();
            foreach (var item in invoiceSummaryValueDtos)
            {
                item.ShowCommand = ShowClientCommand;
            }
            return invoiceSummaryValueDtos;
        }

        /// <summary>
        ///     InitViewModel. It initializes the view model.
        /// </summary>
        private void InitViewModel()
        {
            GridIdentifier = GridIdentifiers.InvoiceSummaryGrid;
            MailBoxHandler += MailboxHandlerName;
            base.MailboxName = MailboxName;
            //  RegisterMailBox(ViewModelUri.ToString());
        }

        /// <summary>
        ///     This is an handler after loading the summary view
        /// </summary>
        /// <param name="sender">Sender of the notification</param>
        /// <param name="e">Events to be loaded</param>
        private void OnLoadedSummary(object sender, PropertyChangedEventArgs e)
        {
            var s = sender as INotifyTaskCompletion<IEnumerable<InvoiceSummaryValueDto>>;
            if (s != null && s.IsSuccessfullyCompleted)
            {
                /* this is the correct mechanism for any summary grid to support incremental loading */
                _invoiceSummaryDtos = s.Task.Result;
               var maxItems = _invoiceDataServices.NumberItems;
                PageCount = _invoiceDataServices.NumberPage;

                SummaryView =
                    new IncrementalList<InvoiceSummaryValueDto>(LoadMoreItems)
                    {
                         MaxItemCount = (int)maxItems
                    };
            }

            if (s != null && s.IsFaulted) DialogService?.ShowErrorMessage(s.ErrorMessage);
          
        }

       
        /// <summary>
        ///     Get the route name.
        /// </summary>
        /// <param name="name">Name of the route</param>
        /// <returns></returns>
        protected override string GetRouteName(string name)
        {
            var route = @"invoice://" + InvoiceModule.InvoiceSubSystem + "//" + name;
            var routedName = new Uri(route).AbsoluteUri;
            return routedName;
        }

        /// <summary>
        ///     This open a current item value.
        ///     Asyc void shall be considered bad always
        ///     except when used through command.s
        /// </summary>
        /// <param name="value">value recevied</param>
        private async void OpenCurrentItem(object value)
        {
            if (!(value is InvoiceSummaryValueDto invoice)) return;
            var name = invoice.ClientName;
            var id = invoice.InvoiceName;
            var tabName = id + "." + name;
            CreateNewItem(tabName);
            var provider = await DataServices.GetInvoiceDataServices().GetDoAsync(id);
            var currentPayload = BuildShowPayLoadDo(tabName, provider);

            currentPayload.DataObject = provider;
            currentPayload.Subsystem = DataSubSystem.InvoiceSubsystem;
            currentPayload.PrimaryKeyValue = id;
            currentPayload.Sender = ViewModelUri.ToString();
            //  EventManager.RegisterObserverSubsystem(InvoiceModule.InvoiceSubSystem, this);
            ActiveSubSystem();
            //currentPayload.Sender = base.MailboxName;
            EventManager.NotifyObserverSubsystem(InvoiceModule.InvoiceSubSystem, currentPayload);
        }

        private void CreateNewItem(string name)
        {
            if (_isTestPayload)
            {
                return;
            }
            // The composite.
            var detailsRegion = _regionManager.Regions[RegionNames.TabRegion];
            var headeredWindow = _container.Resolve<HeaderedWindow>();
            headeredWindow.Header = name;
            var infoView = _container.Resolve<InvoiceInfoView>();
            var lineview = _container.Resolve<LineGridView>();
            var footerView = _container.Resolve<InvoiceSummaryFooter>();
            /* 
             * Resolve the view model. Kind of view model first approach. We can use a LineGridView 
             * for every kind of subject and for the specific.
             *  This allows the reuse better than view.
             */
            var vm = _container.Resolve<InvoiceInfoViewModel>();
            infoView.DataContext = vm;
            lineview.DataContext = vm;
            footerView.DataContext = vm;
            headeredWindow.DataContext = vm;
            _detailsRegionManager = detailsRegion.Add(headeredWindow, null, true);
            var headerRegion = _detailsRegionManager.Regions[RegionNames.HeaderRegion];
            var lineRegion = _detailsRegionManager.Regions[RegionNames.LineRegion];
            var footerRegion = _detailsRegionManager.Regions[RegionNames.FooterRegion];
            lineRegion.Add(lineview, null, true);
            headerRegion.Add(infoView, null, true);
            footerRegion.Add(footerView, null, true);
            headeredWindow.Focus();
        }
        /// <summary>
        ///     Create a new invoice.
        /// </summary>
        protected override void NewItem()
        {
            var viewName = string.Empty;
            var invoiceDataServices = DataServices.GetInvoiceDataServices();
            var id = invoiceDataServices.NewId();
            var invoiceDs = invoiceDataServices.GetNewDo(id);
            var tabName = "Nueva " + "." + id;
            CreateNewItem(id);
            var currentPayload = BuildShowPayLoadDo(viewName, invoiceDs);
            currentPayload.Subsystem = DataSubSystem.InvoiceSubsystem;
            currentPayload.PayloadType = DataPayLoad.Type.Insert;
            currentPayload.PrimaryKeyValue = id;
            currentPayload.Sender = ViewModelUri.ToString();
            currentPayload.SubsystemName = EventSubsystem.InvoiceSubsystemVm;
            EventManager.NotifyObserverSubsystem(InvoiceModule.InvoiceSubSystem, currentPayload);
        }
        private void LoadMoreItems(uint count, int baseIndex)
        {
           
            NotifyTaskCompletion.Create<IEnumerable<InvoiceSummaryValueDto>>(
               _invoiceDataServices.GetPagedSummaryDoAsync(baseIndex, DefaultPageSize), PagingEvent);
           
        }


        protected override void SetRegistrationPayLoad(ref DataPayLoad payLoad)
        {
            if (payLoad == null)
            {
                payLoad = new DataPayLoad();
            }
            payLoad.Subsystem = DataSubSystem.InvoiceSubsystem;
            payLoad.PayloadType = DataPayLoad.Type.RegistrationPayload;
            payLoad.HasDataObject = false;
            payLoad.HasRelatedObject = false;
            payLoad.Sender = ViewModelUri.ToString();
        }
        #region attributes

        private readonly IRegionManager _regionManager;
        private IncrementalList<InvoiceSummaryValueDto> _summaryView;
        private bool _isTestPayload;

        #endregion
    }
}