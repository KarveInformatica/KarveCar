using System.Data;
using System.Windows.Input;
using Prism.Mvvm;
using KarveDataServices;
using KarveCommon.Services;
using Prism.Commands;
using KarveDataServices.DataObjects;
using Microsoft.Practices.Unity;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.ComponentModel;
using System.Windows;
using KarveCommon.Generic;

namespace ProvidersModule.ViewModels
{
    public class ProvidersControlViewModel : BindableBase, IProvidersViewModel
    {

        /// <summary>
        ///  Type of payment data services.
        /// </summary>
        private readonly IEventManager _eventManager;

        private readonly IConfigurationService _configurationService;
        private readonly IDataServices _dataServices;
        private readonly IUnityContainer _container;
        private static string PROVIDER_SUMMARY_VM = "ProvidersControlViewModel";
        private DataTable _extendedSupplierDataTable;
        private ICommand _openItemCommand;
        private DataSet _completeSummary;
        private ICommand _pagedItemCommand;
        private NotifyTaskCompletion<DataSet> _initializationNotifier;
        private NotifyTaskCompletion<DataSet> _completeSummaryInitialization;
        public MailBoxMessageHandler _messageHandler;
        private object _notifyStateObject = new object();
        private int _notifyState = 0;

        public ProvidersControlViewModel(IConfigurationService configurationService,
            IUnityContainer container,
            IDataServices services,
            IEventManager eventManager)
        {
            _configurationService = configurationService;
            _eventManager = eventManager;
            _container = container;
            _dataServices = services;
            _extendedSupplierDataTable = new DataTable();
            _openItemCommand = new DelegateCommand<object>(OpenCurrentItem);
            _pagedItemCommand = new DelegateCommand<object>(LoadNewPage);
            StartAndNotify();
        }

        private void StartAndNotify()
        {
            _messageHandler += MessageHandler;
            _eventManager.RegisterMailBox(ProvidersControlViewModel.PROVIDER_SUMMARY_VM, _messageHandler);
            _initializationNotifier = new NotifyTaskCompletion<DataSet>(StartDataLayer());
            _initializationNotifier.PropertyChanged += InitializationNotifierOnPropertyChanged;
          
        }

        private void MessageHandler(DataPayLoad payLoad)
        {
            if ((payLoad.PayloadType == DataPayLoad.Type.UpdateView) && (_notifyState == 0))
            {
                lock (_notifyStateObject)
                {
                    _notifyState = 1;
                }
                StartAndNotify();
            }
            if (payLoad.PayloadType == DataPayLoad.Type.Delete)
            {
                // forward data to the current payload.
                _eventManager.notifyObserverSubsystem(ProviderModule.NAME, payLoad);
            }
            if (payLoad.PayloadType == DataPayLoad.Type.Insert)
            {
                OpenNewItem();
            }
        }

        private void CompleteSummaryInitializationOnPropertyChanged(object sender,
            PropertyChangedEventArgs propertyChangedEventArgs)
        {
            if (_completeSummaryInitialization.IsSuccessfullyCompleted)
            {

                _completeSummary = _completeSummaryInitialization.Task.Result;
            }
        }

        private async Task<DataSet> LoadCompleteSummary()
        {
            ISupplierDataServices supplier = _dataServices.GetSupplierDataServices();
            // load the dataset of provee1 and provee2.
            DataSet set = await supplier.GetAsyncSuppliers();
            return set;
        }

        private void InitializationNotifierOnPropertyChanged(object sender,
            PropertyChangedEventArgs propertyChangedEventArgs)
        {
            if (_initializationNotifier.IsSuccessfullyCompleted)
            {
                _extendedSupplierDataTable = _initializationNotifier.Task.Result.Tables[0];
                RaisePropertyChanged("SummaryView");
                /* ok the first load has been successfully i can do the second one while the UI Thread is refreshing*/
                _completeSummaryInitialization = new NotifyTaskCompletion<DataSet>(LoadCompleteSummary());
                _completeSummaryInitialization.PropertyChanged += CompleteSummaryInitializationOnPropertyChanged;
                lock (_notifyStateObject)
                {
                    _notifyState = 0;
                }
                // each module notify the toolbar.
                DataPayLoad payLoad = new DataPayLoad();
                payLoad.PayloadType = DataPayLoad.Type.RegistrationPayload;
                payLoad.Subsystem = DataSubSystem.SupplierSubsystem;
               _eventManager.NotifyToolBar(payLoad);
            }

        }

        /// <summary>
        ///  TODO this is for supporting the paging..
        /// </summary>
        /// <param name="obj"></param>
        private void LoadNewPage(object obj)
        {

            long pageIndex = Convert.ToInt64(obj);
            string index = "" + pageIndex;
            // i modify the page index as new command.

        }

        public DataTable SummaryView
        {
            get
            {
                return _extendedSupplierDataTable;
                ;
            }
        }

        private async Task<DataSet> StartDataLayer()
        {
            ISupplierDataServices supplier = _dataServices.GetSupplierDataServices();
            DataSet set = await supplier.GetAsyncAllSupplierSummary();
            return set;
        }

        private DataPayLoad BuildShowPayLoad(string name, DataSet completeSummary)
        {
            DataPayLoad currentPayload = new DataPayLoad();
            string routedName = "ProviderModule:" + name;
            currentPayload.PayloadType = DataPayLoad.Type.Show;
            currentPayload.Registration = routedName;
            currentPayload.Set = completeSummary;
            currentPayload.HasDataSet = true;
            return currentPayload;
        }

        private void OpenNewItem()
        {
            string name = ProvidersModule.Properties.Resources.ProvidersControlViewModel_OpenNewItem_NewSupplier;
            string codigo = "";
            ISupplierInfoView view = _container.Resolve<ISupplierInfoView>();
            _configurationService.AddMainTab(view, name);
            DataPayLoad currentPayload = BuildShowPayLoad(name, _completeSummary);
            currentPayload.SubsystemViewModel = "ProvidersControlViewModel";
            currentPayload.Subsystem = DataSubSystem.SupplierSubsystem;
            currentPayload.PayloadType = DataPayLoad.Type.Insert;
            currentPayload.PrimaryKeyValue = codigo;
            _eventManager.notifyObserverSubsystem(ProviderModule.NAME, currentPayload);
           
        }

        private void OpenCurrentItem(object currentItem)
        {
            DataRowView rowView = currentItem as DataRowView;
            if (rowView != null)
            {
                DataRow row = rowView.Row;
                string name = row["Nombre"] as string;
                string supplierId = row["Codigo"] as string;
                string tabName = supplierId + "." + name;
                ISupplierInfoView view = _container.Resolve<ISupplierInfoView>();
                _configurationService.AddMainTab(view, tabName);
                DataPayLoad currentPayload = BuildShowPayLoad(tabName, _completeSummary);
                currentPayload.PrimaryKeyValue = supplierId;
                _eventManager.notifyObserverSubsystem(ProviderModule.NAME, currentPayload);
            }

        }

        public ICommand PageChangedCommand { set; get; }
        public ICommand OpenItem
        {
            get { return _openItemCommand; }
            set { _openItemCommand = value; }
        }
        
        
       }
}
