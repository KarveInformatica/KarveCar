using System;
using KarveCommon;
using KarveCommon.Generic;
using Prism.Regions;
using KarveCommonInterfaces;
using KarveDataServices;
using KarveCommon.Services;
using Prism.Commands;
using System.Windows.Input;
using KarveDataServices.DataTransferObject;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;
using KarveDataServices.DataObjects;
using Syncfusion.UI.Xaml.Grid;
using System.Linq;
using InvoiceModule.Views;
using Microsoft.Practices.Unity;
using KarveControls.HeaderedWindow;
using MasterModule.Views;

namespace InvoiceModule.ViewModels
{

    /// <summary>
    ///  This object has the resposability to show the list of invoices.
    /// </summary>
    public sealed class InvoiceControlViewModel: KarveRoutingBaseViewModel, INavigationAware, IEventObserver, IDisposeEvents
    {
        /// <summary>
        ///  data to be load
        /// </summary>
        private INotifyTaskCompletion<IEnumerable<InvoiceSummaryValueDto>> _taskInit;
        private PropertyChangedEventHandler _initEventHandler;
       
        private const string MailboxName = "InvoiceSubsystemVM";
        private const string SummaryViewConst = "SummaryView";
        private IEnumerable<InvoiceSummaryValueDto> _invoiceSummaryDtos;
        private bool _isBusy;
        private readonly IUnityContainer _container;
        private IRegionManager _detailsRegionManager;
        private const int LoadStep = 50;

        /// <summary>
   /// Control the invoce control view model.
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
                                   IEventManager eventManager): base(dataServices,requestService, service, eventManager)
        {
            _regionManager = manager;
            IsBusy = false;
            _container = container;
            OpenItemCommand = new DelegateCommand<object>(OpenCurrentItem);
            InitViewModel();
            ItemName = "Facturas";
            ShowClientCommand = new DelegateCommand<object>(OnShowClient);
               
            ViewModelUri = new Uri("karve://invoice/viewmodel?id=" + UniqueId);
            EventManager.RegisterObserverSubsystem(InvoiceModule.InvoiceSubSystem, this);
            RegisterMailBox(ViewModelUri.ToString());
            StartAndNotify();
        }

        private async void OnShowClient(object obj)
        {
            var code = obj as string;
            if (code == null)
            {
                return;
            }

            var clientServices = DataServices.GetClientDataServices();
            var data = await  clientServices.GetAsyncClientDo(code);
            // i want just avoid a fetch of the client name.
            var viewName = data.Value.NUMERO_CLI + data.Value.NOMBRE;
            var navigationParameters = new NavigationParameters
            {
                { "id", code },
                { ScopedRegionNavigationContentLoader.DefaultViewName, viewName }
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
        ///  This is a mailbox handler name.
        /// </summary>
        /// <param name="payLoad">Payload of the mailbox.</param>
        private void MailboxHandlerName(DataPayLoad payLoad)
        {
            if (payLoad != null)
            {
                if (payLoad.PayloadType == DataPayLoad.Type.Insert)
                {
                    NewItem();
                }

                if (payLoad.PayloadType == DataPayLoad.Type.Delete)
                {
                    var delete = "";
                }
            }
        }
        /// <summary>
        ///  Start the asynchronous load of the invoice.
        /// </summary>
        public void StartAndNotify()
        {
            _initEventHandler += OnLoadedSummary;
            _taskInit = NotifyTaskCompletion.Create<IEnumerable<InvoiceSummaryValueDto>>(LoadAsync(), _initEventHandler);
        }
        /// <summary>
        /// This load asynchronously a list of invoice summary values.
        /// </summary>
        /// <returns>This returns the summary value data transfer object</returns>
        private async Task<IEnumerable<InvoiceSummaryValueDto>> LoadAsync()
        {
            var dataServices = DataServices.GetInvoiceDataServices();
            var value = await dataServices.GetInvoiceSummaryAsync();
            if (value == null)
            {
                return value;
            }
            var invoiceSummaryValueDtos = value as InvoiceSummaryValueDto[] ?? value.ToArray();
            foreach (var item in invoiceSummaryValueDtos )
            {
                item.ShowCommand = ShowClientCommand;
            }
            return invoiceSummaryValueDtos;
        }

        public ICommand ShowClientCommand { set; get; }
        /// <summary>
        ///  OpenItemCommand.
        /// </summary>
        public ICommand OpenItemCommand { set; get; }
        
        /// <summary>
        /// This view is a summary to fill the control table for the invoice.
        /// </summary>
        public IncrementalList<InvoiceSummaryValueDto> SummaryView { 
            get => _summaryView;
            set
            {
                _summaryView = value;
                RaisePropertyChanged(SummaryViewConst);
            }
        }

        /// <summary>
        ///  InitViewModel. It initializes the view model.
        /// </summary>
        private void InitViewModel()
        {
           
            GridIdentifier = GridIdentifiers.InvoiceSummaryGrid;
            MailBoxHandler += MailboxHandlerName;
            base.MailboxName = MailboxName;
          //  RegisterMailBox(ViewModelUri.ToString());
        }
        /// <summary>
        ///  This is an handler after loading the summary view
        /// </summary>
        /// <param name="sender">Sender of the notification</param>
        /// <param name="e">Events to be loaded</param>
        private void OnLoadedSummary(object sender, PropertyChangedEventArgs e)
        {
            INotifyTaskCompletion<IEnumerable<InvoiceSummaryValueDto>> s = sender as INotifyTaskCompletion<IEnumerable<InvoiceSummaryValueDto>>;
            if (s != null && s.IsSuccessfullyCompleted)
            {
                /* this is the correct mechanism for any summary grid to support incremental loading */
                _invoiceSummaryDtos = s.Task.Result;
                SummaryView = new IncrementalList<InvoiceSummaryValueDto>(LoadMoreItems) { MaxItemCount = _invoiceSummaryDtos.Count() };
               
            }
            if (s != null && s.IsFaulted)
            {
                DialogService?.ShowErrorMessage(s.ErrorMessage);
            }
        }
        /// <summary>
        ///  Return true if the value is busy.
        /// </summary>
        public bool IsBusy
        {
            get => _isBusy;
            set { _isBusy = value; RaisePropertyChanged("IsBusy"); }
        }

        private void LoadMoreItems(uint count, int baseIndex)
        {
            IsBusy = true;
            var list = _invoiceSummaryDtos.Skip(baseIndex).Take(LoadStep).ToList();
            SummaryView.LoadItems(list);
            IsBusy = false;
        }

        /// <summary>
        ///  Get the route name.
        /// </summary>
        /// <param name="name">Name of the route</param>
        /// <returns></returns>
        protected override string GetRouteName(string name)
        {
            var route = @"invoice://"+ InvoiceModule.InvoiceSubSystem + "//" + name;
            var routedName = new Uri(route).AbsoluteUri;
            return routedName;
        }
        /// <summary>
        ///  This open a current item value.
        ///  Asyc void shall be considered bad always
        ///  except when used through command.s 
        /// </summary>
        /// <param name="value">value recevied</param>
        private async void OpenCurrentItem(object value)
        {
            if (!(value is InvoiceSummaryValueDto invoice))
            {
                return;
            }
            var name = invoice.ClientName;
            var id = invoice.InvoiceName;
            var tabName = id + "." + name;
            CreateNewItem(tabName);
            var provider = await DataServices.GetInvoiceDataServices().GetInvoiceDoAsync(id);
            var currentPayload = BuildShowPayLoadDo(tabName, provider);
            currentPayload.DataObject = provider;
            currentPayload.Subsystem = DataSubSystem.InvoiceSubsystem;
            currentPayload.PrimaryKeyValue = id;
          //  EventManager.RegisterObserverSubsystem(InvoiceModule.InvoiceSubSystem, this);
            ActiveSubSystem();
            currentPayload.Sender = base.MailboxName;
            EventManager.NotifyObserverSubsystem(InvoiceModule.InvoiceSubSystem, currentPayload);

        }
        private void CreateNewItem(string name)
        {
            // The composite.
            var detailsRegion = this._regionManager.Regions[RegionNames.TabRegion];
            var headeredWindow = _container.Resolve<HeaderedWindow>();
            headeredWindow.Header = name;
            var infoView = _container.Resolve<InvoiceInfoView>();
            var lineview = _container.Resolve<KarveControls.HeaderedWindow.LineGridView>();
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
            headerRegion.Add(infoView,null, true);
            footerRegion.Add(footerView, null, true);
            headeredWindow.Focus();
        }

        /// <summary>
        ///  This true if it is a navigation target.
        /// </summary>
        /// <param name="navigationContext"></param>
        /// <returns></returns>
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }
        /// <summary>
        ///  This is if it is navigated from.
        /// </summary>
        /// <param name="navigationContext"></param>
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }
        /// <summary>
        ///  This is if it is navigated to
        /// </summary>
        /// <param name="navigationContext"></param>
        public void OnNavigatedTo(NavigationContext navigationContext)
        {   
        }
        public override void DisposeEvents()
        {
            if (MailBoxHandler != null)
            {
                MailBoxHandler -= MailboxHandlerName;
            }
            EventManager.DeleteObserverSubSystem(InvoiceModule.InvoiceSubSystem, this);
            DeleteMailBox(MailboxName);
            // do what to do with _detailsRegionManager.
        }

        protected override void SetRegistrationPayLoad(ref DataPayLoad payLoad)
        {
            payLoad.PayloadType = DataPayLoad.Type.RegistrationPayload;
            payLoad.Subsystem = DataSubSystem.InvoiceSubsystem;
        }

        public void IncomingPayload(DataPayLoad payload)
        {
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

        #region attributes

        private readonly IRegionManager _regionManager;
        private IncrementalList<InvoiceSummaryValueDto> _summaryView;

        #endregion

        /// <summary>
        ///  Create a new invoice.
        /// </summary>
        protected override void NewItem()
        {
            var viewName = string.Empty;
            var invoiceDataServices = DataServices.GetInvoiceDataServices();
            var id = invoiceDataServices.NewId();
            var invoiceDs = invoiceDataServices.GetNewInvoiceDo(id);
            var tabName = "Nuova "+ "." + id;
            CreateNewItem(id);
            var currentPayload = BuildShowPayLoadDo<IInvoiceData>(viewName,invoiceDs);
            currentPayload.Subsystem = DataSubSystem.InvoiceSubsystem;
            currentPayload.PayloadType = DataPayLoad.Type.Insert;
            currentPayload.PrimaryKeyValue = id;
            currentPayload.Sender = ViewModelUri.ToString();
            EventManager.NotifyObserverSubsystem(InvoiceModule.InvoiceSubSystem, currentPayload);
        }
    }

}