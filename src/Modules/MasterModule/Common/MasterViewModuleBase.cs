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
using KarveControls.Generic;
using KarveControls.Interactivity;
using Prism.Unity;
using System.Collections;
using KarveCommon;

namespace MasterModule.Common
{
    /// <summary>
    ///  Base class for the view model.
    /// </summary>
    public abstract class MasterViewModuleBase : KarveControlViewModel, INavigationAware
    {
        // local application data for the serialization.


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
        public MailBoxMessageHandler MessageHandlerMailBox;

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

        // Primary Key. TODO: remove the new.
        public new string PrimaryKeyValue
        {
            set => _primaryKeyValue = value;
            get { return _primaryKeyValue; }
        }

        protected string PrimaryKey
        {
            set { _primaryKey = value; }
            get { return _primaryKey; }
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
                var helper = await HelperDataServices.GetPagedSummaryDoAsync<LanguageDto, IDIOMAS>(1, DefaultPageSize);
               // var currentHelper = new IncrementalList<LanguageDto>
                return helper;
            });

            AssistMapper.Configure("CURRENCY_ASSIST", async (query) => {
                var helper = await HelperDataServices.GetPagedSummaryDoAsync<CurrenciesDto, CURRENCIES>(1, DefaultPageSize);
                return helper;
            });
            AssistMapper.Configure("CONTABLE_DELEGA_ASSIST", async (query) =>
            {
                var helper = await HelperDataServices.GetPagedSummaryDoAsync<DelegaContableDto, DELEGA>(1, DefaultPageSize);
                return helper;
            });
            AssistMapper.Configure("PROVINCE_ASSIST", async (query) => {
                var helper = await HelperDataServices.GetPagedSummaryDoAsync<ProvinciaDto, PROVINCIA>(1, DefaultPageSize);
                return helper;
            });
            AssistMapper.Configure("CITY_ASSIST", async (query) => {
                var helper = await HelperDataServices.GetPagedSummaryDoAsync<CityDto, POBLACIONES>(1, DefaultPageSize);
                return helper;
            });
            AssistMapper.Configure("COUNTRY_ASSIST", async (query) => {
                var helper = await HelperDataServices.GetPagedSummaryDoAsync<CountryDto, Country>(1, DefaultPageSize);
                return helper;
            });
            AssistMapper.Configure("COMPANY_ASSIST", async (query) => {
                var helper = await HelperDataServices.GetPagedSummaryDoAsync<CompanyDto, SUBLICEN>(1, DefaultPageSize);
                return helper;
            });
            AssistMapper.Configure("OFFICE_ASSIST", async (query) => {
                var helper = await HelperDataServices.GetPagedSummaryDoAsync<OfficeDtos, OFICINAS>(1,DefaultPageSize);
                return helper;
            });
            AssistMapper.Configure("BROKER_ASSIST", async (query) => {

                var helper = await DataServices.GetCommissionAgentDataServices().GetPagedSummaryDoAsync(1, DefaultPageSize);
                return helper;
            });
            AssistMapper.Configure("ORIGIN_ASSIST", async (query) => {
                var helper = await HelperDataServices.GetPagedSummaryDoAsync<OrigenDto, ORIGEN>(1, DefaultPageSize);
                return helper;
            });
            AssistMapper.Configure("MARKET_ASSIST", async (query) => {
                var helper = await HelperDataServices.GetPagedSummaryDoAsync<MercadoDto, MERCADO>(1, DefaultPageSize);
                return helper;
            });
            AssistMapper.Configure("RESELLER_ASSIST", async (query) => {
                var helper = await HelperDataServices.GetPagedSummaryDoAsync<ResellerDto, VENDEDOR>(1, DefaultPageSize);
                return helper;
            });
            AssistMapper.Configure("BUSINESS_ASSIST", async (query) =>
            {
                var helper = await HelperDataServices.GetPagedSummaryDoAsync<BusinessDto, NEGOCIO>(1, DefaultPageSize);
                return helper;
            });
            AssistMapper.Configure("CLIENT_TYPE_ASSIST", async (query) => {
                var helper = await HelperDataServices.GetPagedSummaryDoAsync<ClientTypeDto, TIPOCLI>(1, DefaultPageSize);
                return helper;
            });
            AssistMapper.Configure("CLIENT_TYPE_UPPER", async (query) => {
                var helper = await HelperDataServices.GetPagedSummaryDoAsync<ClientTypeDto, TIPOCLI>(1, DefaultPageSize);
                return helper;
            });
            AssistMapper.Configure("ACTIVITY_ASSIST", async (query) => {
                var helper = await HelperDataServices.GetPagedSummaryDoAsync<ActividadDto, ACTIVI>(1, DefaultPageSize);
                return helper;
            });
            AssistMapper.Configure("RENT_USAGE_ASSIST", async (query) => {
                var helper = await HelperDataServices.GetPagedSummaryDoAsync<RentingUseDto, USO_ALQUILER>(1, DefaultPageSize);
                return helper;
            });
            AssistMapper.Configure("OFFICE_ZONE_ASSIST", async (query) => {
                var helper = await HelperDataServices.GetPagedSummaryDoAsync<ZonaOfiDto, ZONAOFI>(1, DefaultPageSize);
                return helper;
            });

            AssistMapper.Configure("CLIENT_PAYMENT_FORM", async (query) => {
                var helper = await HelperDataServices.GetPagedSummaryDoAsync<PaymentFormDto, FORMAS>(1, DefaultPageSize);
                return helper;
            });
            AssistMapper.Configure("CLIENT_ZONE", async (query) => {
                var helper = await HelperDataServices.GetPagedSummaryDoAsync<ClientZoneDto, ZONAS>(1, DefaultPageSize);
                return helper;
            });
            AssistMapper.Configure("CLIENT_INVOICE_BLOCKS", async (query) => {

                var helper = await HelperDataServices.GetPagedSummaryDoAsync<InvoiceBlockDto, BLOQUEFAC>(1, DefaultPageSize);
                return helper;
            });
            AssistMapper.Configure("CLIENT_BROKER", async (query) =>
            {
                var helper = await DataServices.GetCommissionAgentDataServices().GetPagedSummaryDoAsync(1, DefaultPageSize);
                return helper;
            });
            AssistMapper.Configure("CLIENT_TYPE", async (query) =>
            {
                var helper = await HelperDataServices.GetPagedSummaryDoAsync<ClientTypeDto, TIPOCLI>(1,DefaultPageSize);
                return helper;
            });
            AssistMapper.Configure("BUDGET_KEY", async (query) =>
            {
                var helper = await HelperDataServices.GetPagedSummaryDoAsync<BudgetKeyDto, CLAVEPTO>(1, DefaultPageSize);
                return helper;
            });
            AssistMapper.Configure("CHANNEL_TYPE", async (query) =>
            {
                var helper = await HelperDataServices.GetPagedSummaryDoAsync<ChannelDto, CANAL>(1, DefaultPageSize);
                return helper;
            });
            AssistMapper.Configure("CLIENT_BUDGET", async (query) =>
            {
                var helper = await HelperDataServices.GetPagedSummaryDoAsync<BudgetKeyDto, CLAVEPTO>(1, DefaultPageSize);

                return helper;
            });
            AssistMapper.Configure("CREDIT_CARD", async (query) =>
            {
                var helper = await HelperDataServices.GetPagedSummaryDoAsync<CreditCardDto, TARCREDI>(1, DefaultPageSize);
                return helper;
            });
            AssistMapper.Configure("CLIENT_DRIVER", async (query) =>
            {
                var helper = await DataServices.GetClientDataServices().GetPagedSummaryDoAsync(1, DefaultPageSize);
               // GetSummaryDo(GenericSql.ExtendedClientsSummaryQuery);
                return helper;
            });
            AssistMapper.Configure("CLIENT_ASSIST", async (query) =>
            {
                var helper = await DataServices.GetClientDataServices().GetPagedSummaryDoAsync(1, DefaultPageSize);
                return helper;
            });
            AssistMapper.Configure("BROKER_ASSIST", async (query) =>
            {
                var helper = await DataServices.GetCommissionAgentDataServices().GetPagedSummaryDoAsync(1, DefaultPageSize);
                return helper;
            });
        }


        

        protected object EnforceCityChangeRule(object dataObject)
        {
            var newDataObject = dataObject;
            var cpValue = KarveCommon.ComponentUtils.GetTextDo(newDataObject, "CP", DataType.Any);
            if (cpValue != null)
            {
                var provinceValue = cpValue.Substring(0, 2);
                KarveCommon.ComponentUtils.SetPropValue(newDataObject, "PROV", provinceValue);
            }
            return newDataObject;
        }
            /// <summary>
            ///  This function enforces the base payload.
            /// </summary>
            /// <param name="eventDictionary">Dictionary of events</param>
            /// <param name="payLoad">Payload</param>
            protected void  SetBasePayLoad(IDictionary<string, object> eventDictionary, ref DataPayLoad payLoad) 
            {
                var fieldName = string.Empty;
                object valueName = null;
                if (eventDictionary == null)
                {
                    return;
                }
                if (eventDictionary.Count == 0)
                {
                    return;
                }

                if (payLoad == null)
                {
                    return;
                }

            if (eventDictionary.ContainsKey("DataObject"))
            {
                var data = eventDictionary["DataObject"];
                if (eventDictionary.ContainsKey("Field"))
                {
                    fieldName = eventDictionary["Field"] as string;
                    if (fieldName != null)
                    {
                        fieldName = fieldName.ToUpper();
                    }
                    if (fieldName == "CP")
                    {
                        data = EnforceCityChangeRule(data);
                    }

                }
               if (eventDictionary.ContainsKey("ChangedValue"))
               {
                    valueName = eventDictionary["ChangedValue"];
               }
               payLoad.DataObject = data;

                if ((valueName != null) && (!string.IsNullOrEmpty(fieldName)))
                {
                    var currentObject = payLoad.DataObject;
                    var currentValue = !fieldName.Contains("Value") ? "Value." + fieldName : fieldName;
                    KarveCommon.ComponentUtils.SetPropValue(currentObject, currentValue, valueName , true);
                    payLoad.DataObject = currentObject;
                }   
            }
            
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

        public MasterViewModuleBase(
            IConfigurationService configurationService,
            IEventManager eventManager,
            IDataServices services,
            IDialogService dialogService,
            IRegionManager regionManager,
            IInteractionRequestController requestController) : base(services,requestController,  dialogService, eventManager)
        {
           
            ConfigurationService = configurationService;
            EventManager = eventManager;
            DataServices = services;
            RegionManager = regionManager;
            _notifyState = 0;
            CurrentOperationalState = DataPayLoad.Type.Show;
            EmailCommand = new DelegateCommand<object>(LaunchMailClient);
            ClickSearchWebAddressCommand = new DelegateCommand<object>(LaunchWebBrowser);
            DeleteEventHandler += OnDeleteTask;
        }

        private void OnDeleteTask(object sender, PropertyChangedEventArgs e)
        {
            string propertyName = e.PropertyName;
            INotifyTaskCompletion<bool> currentSender = sender as INotifyTaskCompletion<bool>;
                if (currentSender.IsSuccessfullyCompleted)
                {
                    var result = currentSender.Task.Result;
                    CanDeleteRegion = true;
                    if (CanDeleteRegion)
                    {
                        DeleteRegion(KeyDeleted);
                        StartAndNotify();
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
        protected async Task<DataPayLoad> GridChangedCommand<DtoType, DBType>(object gridDictionary,

        SetPrimaryKey<DtoType> setPrimary, DataSubSystem dataSub) where DBType : class
        where DtoType : class

        {
            DtoType dtoType = null;
            DataPayLoad payLoad = new DataPayLoad();
            IDictionary<string, object> gridParam = gridDictionary as Dictionary<string, object>;
            if ((gridParam != null) && (gridParam.ContainsKey(OperationConstKey)))
            {
                // this is useful for extracting the name of the attribute.
             
                IList<DtoType> list = new List<DtoType>();
                DBType pro = Activator.CreateInstance<DBType>();
                payLoad.DataObject = gridParam["DataObject"];
                payLoad.HasRelatedObject = true;
                payLoad.RelatedObject = gridParam["ChangedValue"];
                payLoad.Subsystem = dataSub;
                var changedValues = gridParam["ChangedValue"] as IEnumerable;

                _delegationGridState = (ControlExt.GridOp)gridParam[OperationConstKey];
                switch (_delegationGridState)
                {
                    case ControlExt.GridOp.Insert:
                        {

                            foreach (var value in changedValues)
                            {
                                dtoType = value as DtoType;
                                if (dtoType != null)
                                {
                                    var key = await DataServices.GetHelperDataServices().GetUniqueId<DBType>(pro);
                                    PropertyInfo info = PrimaryKeyAttribute.SearchAttribute<DtoType>(dtoType);
                                    info?.SetValue(dtoType, key);
                                    setPrimary(ref dtoType);
                                    list.Add(dtoType);
                                }
                            }
                            payLoad.PayloadType = DataPayLoad.Type.UpdateInsertGrid;
                            break;
                        }
                    case ControlExt.GridOp.Update:
                        {
                            foreach (var value in changedValues)
                            {
                                dtoType = value as DtoType;
                                if (dtoType != null)
                                {
                                    setPrimary(ref dtoType);
                                    list.Add(dtoType);
                                }
                            }
                            payLoad.PayloadType = DataPayLoad.Type.UpdateInsertGrid;
                            break;
                        }
                    case ControlExt.GridOp.Delete:
                        {
                            foreach (var value in changedValues)
                            {
                                dtoType = value as DtoType;
                                if (dtoType != null)
                                {
                                    setPrimary(ref dtoType);
                                    list.Add(dtoType);
                                }
                            }
                            payLoad.PayloadType = DataPayLoad.Type.DeleteGrid;
                            break;
                        }
                }
                payLoad.RelatedObject = list.Distinct();

                

            }
            return payLoad;
        }

        protected async Task GridChangedNotification<DtoType, EntityType>(object obj, 
            SetPrimaryKey<DtoType> setPrimary, DataSubSystem dataSub) where DtoType : class where EntityType : class
        {
            IDictionary<string, object> eventDictionary = obj as Dictionary<string, object>;
            if ((eventDictionary != null) && (eventDictionary.ContainsKey("DataObject")))
            {
                // This is the return value of the data subsystem.
                DataPayLoad retValue = await GridChangedCommand<DtoType, EntityType>(obj, setPrimary, dataSub).ConfigureAwait(false);
                
                if (retValue != null)
                {
                    retValue.Subsystem = dataSub;
                    EventManager.NotifyToolBar(retValue);
                }
            }
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
        ///  Can delete region.
        /// </summary>
        public abstract bool CanDeleteRegion { set; get; }

        /// <summary>
        ///  Payload trasnfer.
        /// </summary>
        /// <param name="payLoad"></param>
        /// 
        protected override void DeleteItem(DataPayLoad payLoad)
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
             var notification = sender as 
                INotifyTaskCompletion<T>;
            Contract.Requires(notification != null, "Notification required");
            var propertyName = propertyChangedEventArgs.PropertyName;

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

            var propertyName = propertyChangedEventArgs.PropertyName;

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
        /// SetDataObject. The idea is to provide a common inteface to trigger in a base class the raise propery changed.
        /// </summary>
        /// <param name="result">DataObject to be set.</param>
        protected abstract void SetDataObject(object result);

       

        /// <summary>
        ///  Navigation support.
        /// </summary>
        /// <param name="navigationContext"></param>
        /// <returns></returns>
        public override bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }

        /// <summary>
        ///  Navigation support 
        /// </summary>
        /// <param name="navigationContext"></param>
        public override void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        /// <summary>
        /// This is the navigation context.
        /// </summary>
        /// <param name="navigationContext">Naviagation Context.</param>
        public override void OnNavigatedTo(NavigationContext navigationContext)
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
            var currentPayload = new DataPayLoad();
            var routedName = GetRouteName(name);
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

            var tableName = table.TableName;
            var foundTable = false;
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
