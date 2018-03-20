using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Windows.Input;
using DataAccessLayer.Assist;
using KarveCommon.Generic;
using KarveCommon.Services;
using KarveDataServices;
using Prism.Regions;
using MasterModule.Views;
using System.Linq;
using NLog;
using System.Reflection;
using KarveCommonInterfaces;
using KarveControls;
using KarveDataServices.DataTransferObject;
using DataAccessLayer.DataObjects;
using Prism.Commands;
using System.Diagnostics.Contracts;
using System.Windows;
using  RegionMan = Prism.Regions.RegionManager;
using Syncfusion.UI.Xaml.Grid;

namespace MasterModule.Common
{
    /// <summary>
    ///  Base class for the view model.
    /// </summary>
    public abstract class MasterViewModuleBase : KarveRoutingBaseViewModel, INavigationAware, IDisposeEvents
    {
        private const string RegionName = "TabRegion";
        // local application data for the serialization.

       
        protected Logger Logger = LogManager.GetCurrentClassLogger();
        protected INotifyTaskCompletion InitializationNotifierDo;

        protected INotifyTaskCompletion<DataSet> InitializationNotifier;
        protected PropertyChangedEventHandler InitEventHandler;
       


        protected PropertyChangedEventHandler DeleteEventHandler;

        protected ControlExt.GridOp _delegationGridState = ControlExt.GridOp.Any;
        /// <summary>
        ///  Each viewmodel refelct different types following the paylod that it receives
        /// </summary>
        protected DataPayLoad.Type CurrentOperationalState;

       
        /// <summary>
        ///  The configuration service is a way to set/get configurartions
        /// </summary>
        protected IConfigurationService ConfigurationService;


        /// <summary>
        ///  TODO: fixme read after write probelm
        /// </summary>
        private string KeyDeleted = string.Empty;

        /// <summary>
        ///  Mailbox where each view model can receive a message from other view models.
        /// </summary>
        protected MailBoxMessageHandler MessageHandlerMailBox;

        /// <summary>
        ///  This is a registry of an assit handlers.
        /// </summary>
        protected AssistHandlerRegistry AssistHandlerRegistry = new AssistHandlerRegistry();


        /// <summary>
        /// PrimaryKey field used from all view models.
        /// </summary>
        private string _primaryKey = "";


        
        /// <summary>
        /// This delegate set the primary key
        /// </summary>
        /// <typeparam name="T">Type of the primary key</typeparam>
        /// <param name="primaryKey">Value of the primaryKey</param>
        protected delegate void SetPrimaryKey<T>(ref T primaryKey);

        /// <summary>
        ///  PrimaryKey field used from all view models.
        /// </summary>
        private string _primaryKeyValue = "";

        // Primary Key.
        public string PrimaryKeyValue
        {
            set { _primaryKeyValue = value; }
            get { return _primaryKeyValue; }
        }

        protected string PrimaryKey
        {
            set { _primaryKey = value; }
            get { return _primaryKey; }
        }
        /// <summary>
        ///  Summary View used from all the control view models.
        ///  
        /// </summary>
        public object SummaryView
        {
            get { return ExtendedDataTable; }
            set
            {
                ExtendedDataTable = value;
                RaisePropertyChanged("SummaryView");
                
            }
        }
        /// <summary>
        ///  AllowedGridColumns
        /// </summary>
        public List<string> AllowedGridColumns
        {
            get { return _allowedGridColumns; }
            set
            {
                _allowedGridColumns = value;
                RaisePropertyChanged("AllowedGridColumns");
            }
        }
        private int _notifyState;

        protected bool IsInsertion = false;

        protected IRegionManager RegionManager;
       
        protected const string OperationConstKey = "Operation";

        /// <summary>
        /// Command to detect and assist in case of a window.
        /// </summary>
        public ICommand AssistCommand { set; get; }
        
        /// <summary>
        ///  This is a command for open a new window.
        /// </summary>
        public ICommand OpenItemCommand { set; get; }


        // shall be in a separate service.

        protected void ConfigureAssist()
        {
            // here the parameter query is never used.

            AssistMapper.Configure("LANGUAGE_ASSIST", async (query) => {
                var helper = await HelperDataServices.GetMappedAllAsyncHelper<LanguageDto, IDIOMAS>();
                return helper;
            });

            AssistMapper.Configure("CURRENCY_ASSIST", async (query) => {
                var helper = await HelperDataServices.GetMappedAllAsyncHelper<CurrenciesDto, CURRENCIES>();
                return helper;
            });

            AssistMapper.Configure("PROVINCE_ASSIST", async (query) => {
                var helper = await HelperDataServices.GetMappedAllAsyncHelper<ProvinciaDto, PROVINCIA>();
                return helper;
            });
            AssistMapper.Configure("CITY_ASSIST", async (query) => {
                var helper = await HelperDataServices.GetMappedAllAsyncHelper<CityDto, POBLACIONES>();
                return helper;
            });
            AssistMapper.Configure("COUNTRY_ASSIST", async (query) => {
                var helper = await HelperDataServices.GetMappedAllAsyncHelper<CountryDto, Country>();
                return helper;
            });
            AssistMapper.Configure("COMPANY_ASSIST", async (query) => {
                var helper = await HelperDataServices.GetMappedAllAsyncHelper<CompanyDto, SUBLICEN>();
                return helper;
            });
            AssistMapper.Configure("OFFICE_ASSIST", async (query) => {
                var helper = await HelperDataServices.GetMappedAllAsyncHelper<OfficeDtos, OFICINAS>();
                return helper;
            });
            AssistMapper.Configure("BROKER_ASSIST", async (query) => {

                var helper = await DataServices.GetCommissionAgentDataServices().GetCommissionAgentSummaryDo();
                return helper;
            });
            AssistMapper.Configure("ORIGIN_ASSIST", async (query) => {
                var helper = await HelperDataServices.GetMappedAllAsyncHelper<OrigenDto, ORIGEN>();
                return helper;
            });
            AssistMapper.Configure("MARKET_ASSIST", async (query) => {
                var helper = await HelperDataServices.GetMappedAllAsyncHelper<MercadoDto, MERCADO>();
                return helper;
            });
            AssistMapper.Configure("RESELLER_ASSIST", async (query) => {
                var helper = await HelperDataServices.GetMappedAllAsyncHelper<ResellerDto, VENDEDOR>();
                return helper;
            });
            AssistMapper.Configure("BUSINESS_ASSIST", async (query) =>
            {
                var helper = await HelperDataServices.GetMappedAllAsyncHelper<BusinessDto, NEGOCIO>();
                return helper;
            });
            AssistMapper.Configure("CLIENT_TYPE_ASSIST", async (query) => {
                var helper = await HelperDataServices.GetMappedAllAsyncHelper<ClientTypeDto, TIPOCLI>();
                return helper;
            });
            AssistMapper.Configure("CLIENT_TYPE_UPPER", async (query) => {
                var helper = await HelperDataServices.GetMappedAllAsyncHelper<ClientTypeDto, TIPOCLI>();
                return helper;
            });
            AssistMapper.Configure("ACTIVITY_ASSIST", async (query) => {
                var helper = await HelperDataServices.GetMappedAllAsyncHelper<ActividadDto, ACTIVI>();
                return helper;
            });
            AssistMapper.Configure("RENT_USAGE_ASSIST", async (query) => {
                var helper = await HelperDataServices.GetMappedAllAsyncHelper<RentingUseDto, USO_ALQUILER>();
                return helper;
            });
            AssistMapper.Configure("OFFICE_ZONE_ASSIST", async (query) => {
                var helper = await HelperDataServices.GetMappedAllAsyncHelper<ZonaOfiDto, ZONAOFI>();
                return helper;
            });
            
            AssistMapper.Configure("CLIENT_PAYMENT_FORM", async (query) => {
                var helper = await HelperDataServices.GetMappedAllAsyncHelper<PaymentFormDto, FORMAS>();
                return helper;
            });
            AssistMapper.Configure("CLIENT_ZONE", async (query) => {
                var helper = await HelperDataServices.GetMappedAllAsyncHelper<ClientZoneDto, ZONAS>();
                return helper;
            });
            AssistMapper.Configure("CLIENT_INVOICE_BLOCKS", async (query) => {

                var helper = await HelperDataServices.GetMappedAllAsyncHelper<InvoiceBlockDto, BLOQUEFAC>();
                return helper;
            });
            AssistMapper.Configure("CLIENT_BROKER", async (query) =>
            {
                var helper = await DataServices.GetCommissionAgentDataServices().GetCommissionAgentSummaryDo();
                return helper;
            });
            AssistMapper.Configure("CLIENT_TYPE", async (query) =>
            {
                var helper = await HelperDataServices.GetMappedAllAsyncHelper<ClientTypeDto, TIPOCLI>();
                return helper;
            });
            AssistMapper.Configure("BUDGET_KEY", async (query) =>
            {
                var helper = await HelperDataServices.GetMappedAllAsyncHelper<BudgetKeyDto, CLAVEPTO>();
                return helper;
            });
            AssistMapper.Configure("CHANNEL_TYPE", async (query) =>
            {
                var helper = await HelperDataServices.GetMappedAllAsyncHelper<ChannelDto, CANAL>();
                return helper;
            });
            AssistMapper.Configure("CLIENT_BUDGET", async (query) =>
            {
                var helper = await HelperDataServices.GetMappedAllAsyncHelper<BudgetKeyDto, CLAVEPTO>();
                return helper;
            });
            AssistMapper.Configure("CREDIT_CARD", async (query) =>
            {
                var helper = await HelperDataServices.GetMappedAllAsyncHelper<CreditCardDto, TARCREDI>();
                return helper;
            });
            AssistMapper.Configure("CLIENT_DRIVER", async (query) =>
            {
                var helper = await DataServices.GetClientDataServices().GetClientSummaryDo(GenericSql.ExtendedClientsSummaryQuery); 
                return helper;
            });
            AssistMapper.Configure("CLIENT_ASSIST", async (query) =>
            {
                var helper = await DataServices.GetClientDataServices().GetClientSummaryDo(GenericSql.ExtendedClientsSummaryQuery);
                return helper;
            });
            AssistMapper.Configure("BROKER_ASSIST", async (query) =>
            {
                var helper = await DataServices.GetCommissionAgentDataServices().GetCommissionAgentSummaryDo();
                return helper;
            });
        }
        /// <summary>
        /// Object to warrant the notifications.
        /// </summary>
        protected object NotifyStateObject = new object();

        /// <summary>
        /// Ok.
        /// </summary>
        protected int NotifyState
        {
            set { _notifyState = 0; }
            get { return _notifyState; }
        }

        protected void LaunchMailClient(object value)
        {
            if (value != null)
            {
                string email = value as string;
                string emailUrl = "mailto:" + email + "?subject=KarveCar";

                System.Diagnostics.Process.Start(emailUrl);
            }
        }
        protected void LaunchWebBrowser(object value)
        {
            if (value != null)
            {
                string webBrowser = value as string;
                if (webBrowser.Length > 0)
                {

                    System.Diagnostics.Process.Start(webBrowser);
                }
            }
        }
        /// <summary>
        ///  Command to launch the web
        /// </summary>
        public ICommand EmailCommand { set; get; }
        /// <summary>
        /// command to launch the web.
        /// </summary>
        public ICommand ClickSearchWebAddressCommand { get; set; }

        /// <summary>
        /// ViewModel base for the master registry.
        /// </summary>
        /// <param name="configurationService">It needs the configuration service</param>
        /// <param name="eventManager">The event manager</param>
        /// <param name="services">The dataservices value</param>

        public MasterViewModuleBase(IConfigurationService configurationService,
            IEventManager eventManager,
            IDataServices services,
            IDialogService dialogService,
            IRegionManager regionManager) : base(services, dialogService, eventManager)
        {
            ConfigurationService = configurationService;
            EventManager = eventManager;
            DataServices = services;
            RegionManager = regionManager;
            _notifyState = 0;
            CurrentOperationalState = DataPayLoad.Type.Show;

            EmailCommand = new Prism.Commands.DelegateCommand<object>(LaunchMailClient);
            ClickSearchWebAddressCommand = new Prism.Commands.DelegateCommand<object>(LaunchWebBrowser);
            DeleteEventHandler += OnDeleteTask;
        }

        private void OnDeleteTask(object sender, PropertyChangedEventArgs e)
        {
            string propertyName = e.PropertyName;

            if (propertyName.Equals("Status"))
            {
                if (DeleteInitializationTable.IsSuccessfullyCompleted)
                {
                    var result = InitializationNotifier.Task.Result;
                    CanDeleteRegion = true;
                    if (CanDeleteRegion)
                    {
                        DeleteRegion(KeyDeleted);
                        StartAndNotify();
                    }
                }
            }
           
        }

        protected void Union<T>(ref IEnumerable<T> dtoList, T dto)
        {
            DesignByContract.Dbc.Requires(dtoList != null, "DataTransfer List Object shall be not null");
            DesignByContract.Dbc.Requires(dto != null, "Data Transfer Obeject is not null");
            IList<T> list = new List<T>();
            list.Add(dto);
            var unionList = dtoList.Union(list);
            if (unionList.Any())
            {
                dtoList = new ObservableCollection<T>(unionList.ToList());
            }
        }

        /// <summary>
        /// This is the handler for the grid messages.
        /// </summary>
        /// <typeparam name="DtoType">Type of the data transfer object</typeparam>
        /// <typeparam name="DBType">Type of the data base entity</typeparam>
        /// <param name="gridDictionary">Dictionary of the event to be accessed.</param>
        /// <param name="setPrimary">Primary Key Delegate to be passed</param>
        /// <param name="dataSub">Subsystem to be passed</param>
        /// <returns></returns>
        protected async Task<Tuple<bool, DtoType>> GridChangedCommand<DtoType, DBType>(object gridDictionary,

        SetPrimaryKey<DtoType> setPrimary, DataSubSystem dataSub) where DBType : class
        where DtoType : class

        {
            DtoType dtoType = null;
            Tuple<bool, DtoType> retValue = new Tuple<bool, DtoType>(false, dtoType);

            IDictionary<string, object> gridParam = gridDictionary as Dictionary<string, object>;
            if ((gridParam != null) && (gridParam.ContainsKey(OperationConstKey)))
            {
                // this is useful for extracting the name of the attribute.
                DBType pro = Activator.CreateInstance<DBType>();
                dtoType = gridParam["ChangedValue"] as DtoType;
                BaseDto baseDto = dtoType as BaseDto;

                if (baseDto!=null)
                {
                    baseDto.IsDirty = true;                   
                }
                PropertyInfo info = PrimaryKeyAttribute.SearchAttribute<DtoType>(dtoType);
                var operationType = gridParam[OperationConstKey];
                _delegationGridState = (ControlExt.GridOp)operationType;
                switch (_delegationGridState)
                {
                    case ControlExt.GridOp.Insert:
                        {

                            if (dtoType != null)
                            {


                                var key = await DataServices.GetHelperDataServices().GetUniqueId<DBType>(pro);
                                setPrimary(ref dtoType);
                                info.SetValue(dtoType, key);
                                var opValue = await DataServices.GetHelperDataServices()
                                    .ExecuteInsertOrUpdate<DtoType, DBType>(dtoType);
                                retValue = new Tuple<bool, DtoType>(opValue, dtoType);

                            }
                            break;
                        }
                    case ControlExt.GridOp.Update:
                        {

                            if (dtoType != null)
                            {

                                setPrimary(ref dtoType);
                                DataPayLoad payLoad = new DataPayLoad();
                                payLoad.DataObject = gridParam["DataObject"];
                                payLoad.HasRelatedObject = true;
                                payLoad.RelatedObject = dtoType;
                                payLoad.PayloadType = DataPayLoad.Type.UpdateInsertGrid;
                                payLoad.Subsystem = dataSub;
                                retValue = new Tuple<bool, DtoType>(true, dtoType);
                                // ok we act to notify the toolbar.
                                EventManager.NotifyToolBar(payLoad);
                            }
                            break;
                        }

                    case ControlExt.GridOp.Delete:
                        {
                            setPrimary(ref dtoType);
                            DataPayLoad payLoad = new DataPayLoad();
                            payLoad.DataObject = gridParam["DataObject"];
                            payLoad.HasRelatedObject = true;
                            payLoad.RelatedObject = dtoType;
                            payLoad.PayloadType = DataPayLoad.Type.DeleteGrid;
                            payLoad.Subsystem = dataSub;
                            retValue = new Tuple<bool, DtoType>(true, dtoType);
                            // ok we act to notify the toolbar.
                            EventManager.NotifyToolBar(payLoad);
                            break;
                        }

                }

            }
            return retValue;
        }
        /// <summary>
        ///  This value returns foreach database row a tuple containing the value of the name and the id.
        /// </summary>
        /// <param name="rowView">Data Table Row</param>
        /// <param name="nameColumn">Name of the column</param>
        /// <param name="codeColumn">Code of the column</param>
        /// <returns></returns>
        protected Tuple<string, string> ComputeIdName(DataRowView rowView, string nameColumn, string codeColumn)
        {
            System.Data.DataRow row = rowView.Row;
            string name = row[nameColumn] as string;
            string commissionId = row[codeColumn] as string;
            Tuple<string, string> codeTuple = new Tuple<string, string>(commissionId, name);
            return codeTuple;
        }

        /// <summary>
        /// Extended Data Table
        /// </summary>
        protected object ExtendedDataTable;

        protected INotifyTaskCompletion<bool> DeleteInitializationTable;
        private List<string> _allowedGridColumns;

        /// <summary>
        ///  This starts the load of data from the lower data layer.
        /// </summary>
        public abstract void StartAndNotify();

        /// <summary>
        ///  This asks to the control view model to open a new item for insertion. 
        /// </summary>
        public abstract void NewItem();
        /// <summary>
        ///  Can delete region.
        /// </summary>
        public abstract bool CanDeleteRegion { set; get; }

        /// <summary>
        ///  Payload trasnfer.
        /// </summary>
        /// <param name="payLoad"></param>
        /// 
        public void DeleteItem(DataPayLoad payLoad)
        {
            
            string primaryKeyValue = payLoad.PrimaryKeyValue;
            DeleteInitializationTable =
                NotifyTaskCompletion.Create<bool>(DeleteAsync(primaryKeyValue, payLoad), DeleteEventHandler);
            KeyDeleted = primaryKeyValue;
           
        }

        public abstract Task<bool> DeleteAsync(string primaryKey, DataPayLoad payLoad);


        /// <summary>
        /// Query. Set the query from the ui.
        /// </summary>
        protected string Query { set; get; }

        /// <summary>
        /// This is the message handler.
        /// </summary>
        /// <param name="payLoad"></param>
        protected void MessageHandler(DataPayLoad payLoad)
        {

            // remove this if with table.
            if (payLoad.Subsystem == KarveCommon.Services.DataSubSystem.SupplierSubsystem)
            {
                payLoad.SubsystemName = MasterModuleConstants.ProviderSubsystemName;
            }
            if (payLoad.Subsystem == KarveCommon.Services.DataSubSystem.VehicleSubsystem)
            {
                payLoad.SubsystemName = MasterModuleConstants.VehiclesSystemName;

            }
            if (payLoad.Subsystem == KarveCommon.Services.DataSubSystem.CommissionAgentSubystem)
            {
                payLoad.SubsystemName = MasterModuleConstants.CommissionAgentSystemName;
            }
            if (payLoad.PayloadType == DataPayLoad.Type.UpdateView)
            {
                
                StartAndNotify();

                EventManager.NotifyObserverSubsystem(payLoad.SubsystemName, payLoad);
            }
            if (payLoad.PayloadType == DataPayLoad.Type.Delete)
            {
                DeleteItem(payLoad);
            }
            if (payLoad.PayloadType == DataPayLoad.Type.Insert)
            {
                NewItem();
            }
        }

        /// FIXME: this is a structure of based on type.
        /// <summary>
        ///  This module delete the region
        /// </summary>
        /// <param name="primaryKeyValue">The value of the primary key for the tab.</param>
        protected void DeleteRegion(string primaryKeyValue)
        {
           
            // get the active tab.
            var activeRegion = RegionManager.Regions[RegionName].ActiveViews.FirstOrDefault();
            if (activeRegion != null)
            {
                if (activeRegion is ProviderInfoView)
                {
                    var vehicleInfo = activeRegion as ProviderInfoView;
                    RegionManager.Regions[RegionName].Remove(vehicleInfo);
                    
                }
                if (activeRegion is CommissionAgentInfoView)
                {
                    var commissionAgent = activeRegion as CommissionAgentInfoView;
                    RegionManager.Regions[RegionName].Remove(commissionAgent);
                    //commissionAgent.ClearValue(RegionManager.);
                }
                if (activeRegion is VehicleInfoView)
                {
                    var commissionAgent = activeRegion as VehicleInfoView;
                    RegionManager.Regions[RegionName].Remove(commissionAgent);
                }
                if (activeRegion is ClientsInfoView)
                {
                    var commissionAgent = activeRegion as ClientsInfoView;
                    RegionManager.Regions[RegionName].Remove(commissionAgent);
                }
                if (activeRegion is OfficeInfoView)
                {
                    var commissionAgent = activeRegion as OfficeInfoView;
                    RegionManager.Regions[RegionName].Remove(commissionAgent);
                }
               if (activeRegion is FrameworkElement)
                {
                    var framework = activeRegion as FrameworkElement;
                    /*
                     *  This is needed for https://github.com/PrismLibrary/Prism/issues/953.
                     *  There is a bug in RegionManagerRegistrationBehavior. It is re-entrant and incorrect. As a consequence, the following does not work:
                        region1.Add(view, null, true); 
                        region1.Remove(view); 
                        region2.Add(view, null, true)
                        However the view still may be reused as a workaround by
                        region1.Add(view, null, true); 
                        region1.Remove(view); 
                        view.ClearValue(RegionManager.RegionManagerProperty);
                        region2.Add(view, null, true)
                     */
                    framework.ClearValue(RegionMan.RegionManagerProperty);
                }

            }
        }
        /// <summary>
        /// This method happens when the item is deleted for the toolbar.
        /// </summary>
        /// <param name="primaryKey"></param>
        /// <param name="PrimaryKeyValue"></param>
        /// <param name="subSystem"></param>
        /// <param name="subSystemName"></param>
        protected void DeleteEventCleanup(string primaryKey, string PrimaryKeyValue, DataSubSystem subSystem,
            string subSystemName)
        {
            if (primaryKey == PrimaryKeyValue)
            {
                DataPayLoad payLoad = new DataPayLoad();
                payLoad.Subsystem = subSystem;
                payLoad.SubsystemName = subSystemName;
                payLoad.PrimaryKeyValue = PrimaryKeyValue;
                payLoad.PayloadType = DataPayLoad.Type.Delete;
                EventManager.NotifyToolBar(payLoad);
                PrimaryKeyValue = "";
            }
        }

        /// <summary>
        /// Init a primary key.
        /// </summary>
        /// <param name="primaryKey">Primary Key</param>
        /// <param name="value">Insert Value.</param>
        protected void Init(string primaryKey, bool value)
        {
            // arriva el payload.
            _primaryKey = primaryKey;
            IsInsertion = value;

            if (value)
            {
                StartAndNotify();
            }
        }
        /// <summary>
        ///  This is shall be used by the different view model to set the value of the table initialzed;
        /// </summary>
        /// <param name="table"></param>
        protected abstract void SetTable(DataTable table);


      
        /// <summary>
        /// This is the initialization notifier on property changed data object
        /// </summary>
        /// <param name="sender">This is the sender</param>
        /// <param name="propertyChangedEventArgs">This are the parameters.</param>
        protected void InitializationNotifierOnPropertyChangedDo(object sender,
            PropertyChangedEventArgs propertyChangedEventArgs)
        {

            string propertyName = propertyChangedEventArgs.PropertyName;

            if (propertyName.Equals("Status"))
            {
                if (InitializationNotifier.IsSuccessfullyCompleted)
                {
                    var result = InitializationNotifier.Task.Result;
                    // TODO: check if this is really needed.
                    SetDataObject(result);
                    lock (NotifyStateObject)
                    {
                        NotifyState = 0;
                    }
                    // END TODO
                    DataPayLoad payLoad = new DataPayLoad
                    {
                        HasDataObject = true,
                        DataObject = result
                    };
                    // simply deletegate to the subsystem to add the fields that it needs for the payload (subsystem, id, objectpath)
                    SetRegistrationPayLoad(ref payLoad);
                    // ok we notify the toolbar with the payload set.
                    EventManager.NotifyToolBar(payLoad);
                }
            }
        }


        /// <summary>
        /// This initializatin notifier for the data object
        /// </summary>
        /// <param name="sender">The sender is</param>
        /// <param name="propertyChangedEventArgs"></param>
        protected void InitializationNotifierOnPropertyChangedSummary<T>(object sender,
            PropertyChangedEventArgs propertyChangedEventArgs)
        {
             INotifyTaskCompletion<T> notification = sender as 
                INotifyTaskCompletion<T>;
            Contract.Requires(notification != null, "Notification required");
            string propertyName = propertyChangedEventArgs.PropertyName;

            if (notification == null)
            {
                return;
            }
                if (notification.IsSuccessfullyCompleted)
                {

                SummaryView = notification.Task.Result;
                    
                }
                if (notification.IsFaulted)
                {
                    SummaryView = new ObservableCollection<T>();
               
                if (DialogService != null)
                {
                    DialogService.ShowDialogMessage("Error", "Exception during summary load :" + notification.Task.Exception.Message);
                }
                else
                {
                    MessageBox.Show("Exception during summary load :" + notification.Task.Exception.Message);
                }
                }

            
            Contract.Ensures(SummaryView != null, "The summary is not null");
        }


        

        /// <summary>
        /// This initializatin notifier for the data object
        /// </summary>
        /// <param name="sender">The sender is</param>
        /// <param name="propertyChangedEventArgs"></param>
        protected void InitializationNotifierOnPropertyChanged(object sender,
            PropertyChangedEventArgs propertyChangedEventArgs)
        {

            string propertyName = propertyChangedEventArgs.PropertyName;

            if (propertyName.Equals("Status"))
            {
                if (InitializationNotifier.IsSuccessfullyCompleted)
                {
                    SetTable(InitializationNotifier.Task.Result.Tables[0]);
                    /* ok the first load has been successfully i can do the second one while the UI Thread is refreshing*/
                    lock (NotifyStateObject)
                    {
                        NotifyState = 0;
                    }
                }


            }
        }

       
        
        
        /// <summary>
        /// SetDataObject. 
        /// </summary>
        /// <param name="result">DataObject to be set.</param>
        protected abstract void SetDataObject(object result);

       
        

        /// <summary>
        ///  Navigation support.
        /// </summary>
        /// <param name="navigationContext"></param>
        /// <returns></returns>
        public virtual bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }

        /// <summary>
        ///  Navigation support 
        /// </summary>
        /// <param name="navigationContext"></param>
        public virtual void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        /// <summary>
        /// This is the navigation context.
        /// </summary>
        /// <param name="navigationContext">Naviagation Context.</param>
        public virtual void OnNavigatedTo(NavigationContext navigationContext)
        {
        }

       
        /// <summary>
        ///  It detected the payload name following the data occurred.
        /// </summary>
        /// <param name="name">View name</param>
        /// <param name="completeSummary">List of loaded dataset to be passed.</param>
        /// <param name="queries">Dictionary of the queries indexed by table.</param>
        /// <returns></returns>
        protected DataPayLoad BuildShowPayLoad(string name, IList<DataSet> completeSummary,
            IDictionary<string, string> queries = null)
        {
            DataPayLoad currentPayload = new DataPayLoad();
            string routedName = GetRouteName(name);
            currentPayload.PayloadType = DataPayLoad.Type.Show;
            currentPayload.Registration = routedName;
            currentPayload.SetList = completeSummary;
            currentPayload.HasDataSetList = true;
            if (queries != null)
            {
                currentPayload.Queries = queries;
            }
            return currentPayload;
        }

        /// <summary>
        /// This function shows a payload data object
        /// </summary>
        /// <param name="name">Name of the module</param>
        /// <returns></returns>
        protected DataPayLoad BuildShowPayLoadDo(string name)
        {
            DataPayLoad currentPayload = new DataPayLoad();
            string routedName = GetRouteName(name);
            currentPayload.PayloadType = DataPayLoad.Type.Show;
            currentPayload.Registration = routedName;
            return currentPayload;

        }
        


        /// <summary>
        ///  This function merges the new table to the current dataset
        /// </summary>
        /// <param name="table">Table to be merged</param>
        /// <param name="currentDataSet">Current dataset to be merged</param>
        protected void MergeTableChanged(DataTable table, ref DataSet currentDataSet)
        {

            string tableName = table.TableName;
            bool foundTable = false;
            if (currentDataSet != null)
            {
                foreach (DataTable currentTable in currentDataSet.Tables)
                {
                    if (currentTable.TableName == tableName)
                    {
                        foundTable = true;
                        break;
                    }
                }
                if (foundTable)
                {
                    currentDataSet.Tables[tableName].Merge(table);
                }
            }
        }


        
    }
}
