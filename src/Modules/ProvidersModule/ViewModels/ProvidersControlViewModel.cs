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
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using KarveCommon.Generic;
using KarveControls.UIObjects;
using MasterModule.Common;

namespace MasterModule.ViewModels
{
    public class ProvidersControlViewModel : BindableBase, IProvidersViewModel
    {
        private const string ProviderNameColumn = "Nombre";
        private const string ProviderColumnCode = "Codigo";
        private Stopwatch _stopwatch = new Stopwatch();
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
        private INotifyTaskCompletion<DataSet> _initializationNotifier;
        public MailBoxMessageHandler _messageHandler;
        private object _notifyStateObject = new object();
        private int _notifyState = 0;
        private Stopwatch _timing = new Stopwatch();

        private static int value = 0;
        // Yes it violateds SRP it does two things. Show the main and fireup a new ui.

        public ProvidersControlViewModel(IConfigurationService configurationService,
            IUnityContainer container,
            IDataServices services,
            IEventManager eventManager)
        {
            _stopwatch = new Stopwatch();
            _configurationService = configurationService;
            _eventManager = eventManager;
            _container = container;
            _dataServices = services;
            _extendedSupplierDataTable = new DataTable();
            _openItemCommand = new DelegateCommand<object>(OpenCurrentItem);
            _pagedItemCommand = new DelegateCommand<object>(LoadNewPage);
            StartAndNotify();
            _stopwatch.Start();
        }

        

        private void StartAndNotify()
        {
            
            _messageHandler += MessageHandler;
            _eventManager.RegisterMailBox(ProvidersControlViewModel.PROVIDER_SUMMARY_VM, _messageHandler);
            ISupplierDataServices supplier = _dataServices.GetSupplierDataServices();
            _initializationNotifier = NotifyTaskCompletion.Create<DataSet>(supplier.GetAsyncAllSupplierSummary());
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
                _eventManager.notifyObserverSubsystem(MasterModule.NAME, payLoad);
            }
            if (payLoad.PayloadType == DataPayLoad.Type.Insert)
            {
                OpenNewItem();
            }
        }
        private void InitializationNotifierOnPropertyChanged(object sender,
            PropertyChangedEventArgs propertyChangedEventArgs)
        {

            string propertyName = propertyChangedEventArgs.PropertyName;

            if (propertyName.Equals("Status"))
            {
                    if (_initializationNotifier.IsSuccessfullyCompleted)
                    {
                        SummaryView = _initializationNotifier.Task.Result.Tables[0];
                    _stopwatch.Stop();
                        MessageBox.Show(string.Format("{0}", _stopwatch.ElapsedMilliseconds));
                        /* ok the first load has been successfully i can do the second one while the UI Thread is refreshing*/
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
                    else
                    {
                        MessageBox.Show("Error loading supplier data");
                    }

            }
        }



        private void fillViewModelAssistantQueries(ObservableCollection<IUiObject> collection,
            DataSet itemSource,
            ref IDictionary<string, string> assistantQueries)
        {
            foreach (IUiObject nameObject in collection)
            {
                if (!string.IsNullOrEmpty(nameObject.TableName))
                {
                    if (nameObject is UiDualDfSearchTextObject)
                    {
                        UiDualDfSearchTextObject dualDfSearch = (UiDualDfSearchTextObject) nameObject;
                        dualDfSearch.ComputeAssistantRefQuery(itemSource);
                        if (!string.IsNullOrEmpty(dualDfSearch.AssistRefQuery))
                        {
                            if (!assistantQueries.ContainsKey(dualDfSearch.AssistTableName))
                            {
                                assistantQueries.Add(dualDfSearch.AssistTableName, dualDfSearch.AssistRefQuery);
                            }
                        }
                    }
                    if (nameObject is UiMultipleDfObject)
                    {
                        UiMultipleDfObject multipleDfObject = (UiMultipleDfObject) nameObject;
                        IList<IUiObject> listOfSearchTextObjects =
                            multipleDfObject.FindObjects(UiMultipleDfObject.DfKind.UiDualDfSearch);
                        foreach (var currentUiObject in listOfSearchTextObjects)
                        {
                            UiDualDfSearchTextObject dualDfSearch = (UiDualDfSearchTextObject) currentUiObject;
                            dualDfSearch.ComputeAssistantRefQuery(itemSource);
                            if (!string.IsNullOrEmpty(dualDfSearch.AssistRefQuery))
                            {
                                if (!assistantQueries.ContainsKey(dualDfSearch.AssistTableName))
                                {
                                    assistantQueries.Add(dualDfSearch.AssistTableName, dualDfSearch.AssistRefQuery);
                                }
                            }
                        }
                    }
                }
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
        /// <summary>
        ///  Return the selected columns summary view for the suppliers. It might be paged.
        /// </summary>
        public DataTable SummaryView
        {
            get
            {
               
                return _extendedSupplierDataTable;
               
            }
            private set { _extendedSupplierDataTable = value; RaisePropertyChanged(); }
        }

        private async Task<DataSet> StartDataLayer()
        {
            ISupplierDataServices supplier = _dataServices.GetSupplierDataServices();
            DataSet set = await supplier.GetAsyncAllSupplierSummary();
            return set;
        }

        private DataPayLoad BuildShowPayLoad(string name, IList<DataSet> completeSummary)
        {
            DataPayLoad currentPayload = new DataPayLoad();
            string routedName = "ProviderModule:" + name;
            currentPayload.PayloadType = DataPayLoad.Type.Show;
            currentPayload.Registration = routedName;
            currentPayload.SetList = completeSummary;
            currentPayload.HasDataSetList = true;
            return currentPayload;
        }
        private void OpenNewItem()
        {
            string name = Properties.Resources.ProvidersControlViewModel_OpenNewItem_NewSupplier;
            string codigo = "";

            // move this to the configuration service.
            ISupplierInfoView view = _container.Resolve<ISupplierInfoView>();
            _configurationService.AddMainTab(view, name);
            // TODO: see this as set.
            IList<DataSet> dataSet = new List<DataSet>();
            dataSet.Add(new DataSet());
            dataSet.Add(new DataSet());
            DataPayLoad currentPayload = BuildShowPayLoad(name, dataSet);
            currentPayload.SubsystemViewModel = "ProvidersControlViewModel";
            currentPayload.Subsystem = DataSubSystem.SupplierSubsystem;
            currentPayload.PayloadType = DataPayLoad.Type.Insert;
            currentPayload.PrimaryKeyValue = codigo;
            _eventManager.notifyObserverSubsystem(MasterModule.NAME, currentPayload);
           

        }

        private ObservableCollection<IUiObject> MergeList(IList<ObservableCollection<IUiObject>> values)
        {
            ObservableCollection<IUiObject> obs = new ObservableCollection<IUiObject>();

            foreach (ObservableCollection<IUiObject> current in values)
            {
                if (current != null)
                {
                    foreach (IUiObject o in current)
                    {
                        if (o != null)
                        {
                            if (!string.IsNullOrEmpty(o.TableName))
                            {
                                obs.Add(o);
                            }
                        }
                    }
                }
            }
            return obs;
        }

        private async void OpenCurrentItem(object currentItem)
        {
            DataRowView rowView = currentItem as DataRowView;
            if (rowView != null)
            {
                DataRow row = rowView.Row;
                string name = row[ProviderNameColumn] as string;
                string supplierId = row[ProviderColumnCode] as string;
                string tabName = supplierId + "." + name;
                ISupplierInfoView view = _container.Resolve<ISupplierInfoView>();
                _configurationService.AddMainTab(view, tabName);
                UiGeneralPageBuilder generalPageBuilder = new UiGeneralPageBuilder();
                IDictionary<string, ObservableCollection<IUiObject>> pageObjects = generalPageBuilder.BuildPageObjects(null, null);
                ObservableCollection<IUiObject>  upperPartObservableCollection = pageObjects[ProviderConstants.UiUpperPart];
                ObservableCollection <IUiObject> middlePageObservableCollection= pageObjects[ProviderConstants.UiMiddlePartPage];
                IList<ObservableCollection<IUiObject>> obsList = new List<ObservableCollection<IUiObject>>();
                obsList.Add(upperPartObservableCollection);
                obsList.Add(middlePageObservableCollection);
                ObservableCollection<IUiObject> observableCollection = MergeList(obsList);
                IDictionary<string, string> current = SQLBuilder.SqlBuildSelectFromUiObjects(observableCollection, supplierId, false);
                DataSet currentSet = await _dataServices.GetSupplierDataServices().GetAsyncSupplierInfo(current);
                IDictionary<string, string> assistQueries = new Dictionary<string, string>();
                fillViewModelAssistantQueries(observableCollection, currentSet, ref assistQueries);
                DataSet assitDataSet = await _dataServices.GetHelperDataServices().GetAsyncHelper(assistQueries);
                IList<DataSet> dataSet = new List<DataSet>();
                dataSet.Add(currentSet);
                dataSet.Add(assitDataSet);
                DataPayLoad currentPayload = BuildShowPayLoad(tabName, dataSet);
                currentPayload.PrimaryKeyValue = supplierId;
                _eventManager.notifyObserverSubsystem(MasterModule.NAME, currentPayload);
            }

        }
        /// <summary>
        ///  Command to be triggeed from the control to support paging
        /// </summary>
        public ICommand PageChangedCommand { set; get; }
        /// <summary>
        ///  Command to open a new view for each detailed supplier.
        /// </summary>
        public ICommand OpenItem
        {
            get { return _openItemCommand; }
            set { _openItemCommand = value; }
        }
        
        
       }
}
