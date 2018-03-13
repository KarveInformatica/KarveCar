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

namespace InvoiceModule.ViewModels
{

    /// <summary>
    ///  This object has the resposability to show the list of invoices.
    /// </summary>
    public sealed class InvoiceControlViewModel: KarveRoutingBaseViewModel, INavigationAware, IEventObserver
    {
        /// <summary>
        ///  data to be load
        /// </summary>
        private INotifyTaskCompletion<IEnumerable<InvoiceSummaryValueDto>> _taskInit;
        private PropertyChangedEventHandler _initEventHandler;
        public const string InvoiceSubSystem = "InvoiceSubsystem";
        private const string _mailboxName = "InvoiceSubsystemVM";
        private IEnumerable<InvoiceSummaryValueDto> _invoiceSummaryDtos;
        private bool _isBusy;


    // new IncrementalList<OrderInfo>(LoadMoreItems) { MaxItemCount = 1000 };

    /// <summary>
    /// Control view for the invoice.
    /// </summary>
    /// <param name="dataServices">DataServices. This service provide access to the data layer</param>
    /// <param name="service">Dialog service. This service is used to show modal errors.</param>
    /// <param name="manager">Region Manager. This service is used to compose regions.</param>
    /// <param name="eventManager">Event Manager. This service is used to communicate with other viewmodels.</param>
    public InvoiceControlViewModel(IDataServices dataServices, 
                                       IDialogService service,
                                       IRegionManager manager, 
                                       IEventManager eventManager): base(dataServices, service, eventManager)
        {
            _regionManager = manager;
            _isBusy = false;
           
            OpenItemCommand = new DelegateCommand<object>(OpenCurrentItem);
            InitViewModel();
            StartAndNotify();
        }
        /// <summary>
        ///  This is a mailbox handler name.
        /// </summary>
        /// <param name="payLoad">Payload of the mailbox.</param>
        private void MailboxHandlerName(DataPayLoad payLoad)
        {
            
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
            IInvoiceDataServices dataServices = DataServices.GetInvoiceDataServices();
            var value = await dataServices.GetInvoiceSummaryAsync();
            return value;
        }
        /// <summary>
        ///  OpenItemCommand.
        /// </summary>
        public ICommand OpenItemCommand { set; get; }
        
        /// <summary>
        /// This view is a summary to fill the control table for the invoice.
        /// </summary>
        public IncrementalList<InvoiceSummaryValueDto> SummaryView { 
            get
            {
                return _summaryView;
            }
            set
            {
                _summaryView = value;
                RaisePropertyChanged("SummaryView");
            }
        }

        /// <summary>
        ///  InitViewModel. It initializes the view model.
        /// </summary>
        private void InitViewModel()
        {
            GridIdentifier = GridIdentifiers.InvoiceSummaryGrid;
            MailBoxHandler += MailboxHandlerName;
            MailboxName = _mailboxName;
            RegisterMailBox(_mailboxName);
        }
        /// <summary>
        ///  This is an handler after loading the summary view
        /// </summary>
        /// <param name="sender">Sender of the notification</param>
        /// <param name="e">Events to be loaded</param>
        private void OnLoadedSummary(object sender, PropertyChangedEventArgs e)
        {
            INotifyTaskCompletion<IEnumerable<InvoiceSummaryValueDto>> s = sender as INotifyTaskCompletion<IEnumerable<InvoiceSummaryValueDto>>;
            if (s.IsSuccessfullyCompleted)
            {
                /* this is the correct mechanism for any summary grid to support incremental loading */
                _invoiceSummaryDtos = s.Task.Result;
                SummaryView = new IncrementalList<InvoiceSummaryValueDto>(LoadMoreItems) { MaxItemCount = _invoiceSummaryDtos.Count() };
               
            }
            if (s.IsFaulted)
            {
                if (DialogService!=null)
                {
                    DialogService.ShowErrorMessage(s.ErrorMessage);
                }
            }
        }

        public bool IsBusy
        {
            get { return _isBusy; }
            set { _isBusy = value; RaisePropertyChanged("IsBusy"); }
        }

        private void LoadMoreItems(uint count, int baseIndex)
        {
            _isBusy = true;
            var list = _invoiceSummaryDtos.Skip(baseIndex).Take(100).ToList();
            SummaryView.LoadItems(list);
            _isBusy = false;
        }

        /// <summary>
        ///  Get the route name.
        /// </summary>
        /// <param name="name">Name of the route</param>
        /// <returns></returns>
        protected override string GetRouteName(string name)
        {
            var route = @"invoice://"+InvoiceSubSystem + "//" + name;
            string routedName = new Uri(route).AbsoluteUri;
            return routedName;
        }
        /// <summary>
        ///  This open a current item value. 
        ///  TODO: see if a delegate command support a better way than an async.
        /// </summary>
        /// <param name="value">value recevied</param>
        private async void OpenCurrentItem(object value)
        {
            InvoiceSummaryValueDto invoice = value as InvoiceSummaryValueDto;
            if (invoice != null)
            {
                string name = invoice.InvoiceName;
                string id = invoice.InvoiceCode;
                string tabName = id + "." + name;
                var navigationParameters = new NavigationParameters();
                navigationParameters.Add("Id", id);
                navigationParameters.Add(ScopedRegionNavigationContentLoader.DefaultViewName, tabName);
                var uri = new Uri(typeof(InvoiceInfoView).FullName + navigationParameters, UriKind.Relative);
                _regionManager.RequestNavigate("TabRegion", uri);
                IInvoiceData provider = await DataServices.GetInvoiceDataServices().GetInvoiceDoAsync(id);
                DataPayLoad currentPayload = BuildShowPayLoadDo(tabName, provider);
                currentPayload.DataObject = provider.Value;
                currentPayload.Subsystem = DataSubSystem.InvoiceSubsystem;
                currentPayload.PrimaryKeyValue = id;
                EventManager.RegisterObserverSubsystem(InvoiceSubSystem, this);
                ActiveSubSystem();
                currentPayload.Sender = MailboxName;
                EventManager.NotifyObserverSubsystem(InvoiceSubSystem, currentPayload);
            }

        }
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }
        public void OnNavigatedTo(NavigationContext navigationContext)
        {   
        }
        public override void DisposeEvents()
        {
            MailBoxHandler -= MailboxHandlerName;
            DeleteMailBox(_mailboxName);
        }

        protected override void SetRegistrationPayLoad(ref DataPayLoad payLoad)
        {
            payLoad.PayloadType = DataPayLoad.Type.RegistrationPayload;
            payLoad.Subsystem = DataSubSystem.InvoiceSubsystem;
        }

        public void IncomingPayload(DataPayLoad payload)
        {
            ///throw new NotImplementedException();
        }

        #region attributes

        private IRegionManager _regionManager;
        private IncrementalList<InvoiceSummaryValueDto> _summaryView;

        #endregion

    }

}