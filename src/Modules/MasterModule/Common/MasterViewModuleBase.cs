using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Windows.Input;
using DataAccessLayer.Assist;
using KarveCommon.Generic;
using KarveCommon.Services;
using KarveDataServices;
using Prism.Regions;
using MasterModule.Views;
using System.Linq;
using Dapper;
using DataAccessLayer.DataObjects;
using DataAccessLayer.Model;
using KarveControls.KarveGrid;
using Prism.Commands;
using NLog;
using Syncfusion.UI.Xaml.Grid;
using DataRow = System.Data.DataRow;
using System.IO;
using System.Reflection;
using System.Windows.Controls;
using Dragablz;
using KarveCommonInterfaces;
using KarveControls;
using KarveDataServices.DataTransferObject;

namespace MasterModule.Common
{
    /// <summary>
    ///  Base class for the view model.
    /// </summary>
    public abstract class MasterViewModuleBase : BindableBase, INavigationAware, IDisposeEvents
    {
        private const string RegionName = "TabRegion";
        // local application data for the serialization.

        protected Logger Logger = LogManager.GetCurrentClassLogger();
        protected INotifyTaskCompletion InitializationNotifierDo;

        protected INotifyTaskCompletion<DataSet> InitializationNotifier;

        protected INotifyTaskCompletion<IMagnifierSettings> MagnifierInitializationNotifier;

        protected PropertyChangedEventHandler DeleteEventHandler;

        protected ControlExt.GridOp _delegationGridState = ControlExt.GridOp.Any;
        /// <summary>
        ///  Each viewmodel refelct different types following the paylod that it receives
        /// </summary>
        protected DataPayLoad.Type CurrentOperationalState;

        /// <summary>
        ///  Each view model receives messages in a mailbox. This allows any part of the system to comunicate with each view model.
        /// </summary>
        protected MailBoxMessageHandler MailBoxHandler;

        /// <summary>
        ///  The configuration service is a way to set/get configurartions
        /// </summary>
        protected IConfigurationService ConfigurationService;

        /// <summary>
        ///  This is a command for open a new window.
        /// </summary>
        protected ICommand OpenItemCommand;

        /// <summary>
        /// The event manager is responsabile to implement the communication between different view models
        /// </summary>
        protected IEventManager EventManager;

        /// <summary>
        ///  The data services allows any view model to communicate with the database via dataset or via dapper/dataobjects
        /// </summary>
        protected IDataServices DataServices;

        /// <summary>
        ///  Mailbox where each view model can receive a message from other view models.
        /// </summary>
        protected MailBoxMessageHandler MessageHandlerMailBox;

        /// <summary>
        ///  This is a registry of an assit handlers.
        /// </summary>
        protected AssistHandlerRegistry AssistHandlerRegistry = new AssistHandlerRegistry();


        /// <summary>
        ///  
        /// </summary>
        private ObservableCollection<KarveControls.KarveGridExt.ColParamSize> _defaultColParamSizes = new ObservableCollection<KarveControls.KarveGridExt.ColParamSize>();
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

        private int _notifyState;

        protected bool IsInsertion = false;

        protected IRegionManager RegionManager;
        protected KarveControls.KarveGridExt.ColParamSize DefaultSummaryViewColSize;
        protected ObservableCollection<KarveControls.KarveGridExt.ColParamSize> _observableCollection;
        protected const string OperationConstKey = "Operation";

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

        /// <summary>
        /// ViewModel base for the master registry.
        /// FIXME: It does too many things. Violate SRP.
        /// </summary>
        /// <param name="configurationService">It needs the configuration service</param>
        /// <param name="eventManager">The event manager</param>
        /// <param name="services">The dataservices value</param>

        public MasterViewModuleBase(IConfigurationService configurationService,
            IEventManager eventManager,
            IDataServices services,
            IRegionManager regionManager)
        {
            ConfigurationService = configurationService;
            EventManager = eventManager;
            DataServices = services;
            RegionManager = regionManager;
            _notifyState = 0;
            CurrentOperationalState = DataPayLoad.Type.Show;
            GridResizeCommand = new DelegateCommand<object>(OnGridResize);
        }

        protected void Union<T>(ref IEnumerable<T> dtoList, T dto)
        {
            DesignByContract.Dbc.Requires(dtoList != null, "DataTransfer List Object shall be not null");
            DesignByContract.Dbc.Requires(dto != null, "Data Transfer Obejct is not null");
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
                                retValue = new Tuple<bool, DtoType>(true, dtoType);                                // ok we act to notify the toolbar.
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
        public async Task MoveAllCols(KarveControls.KarveGridExt.ColParamSize colParam)
        {
            int gridId = Convert.ToInt32(GridId);
            IMagnifierSettings magnifiersSettings = await DataServices.GetSettingsDataService().GetMagnifierSettings(gridId);
            int swappedDrop = colParam.SwappedTo;
            List<IMagnifierColumns> columns = magnifiersSettings.MagnifierColumns.AsList<IMagnifierColumns>();
            // split the magnifier columns in two.
            // bool ret = await DataServices.GetSettingsDataService().SaveColumnsSettings(colParam.ColumnList);
            IList<KarveControls.KarveGridExt.ColParamSize> list = colParam.ColumnList;
            for (int i = 0; i < colParam.ColumnList.Count; ++i)
            {
                KarveControls.KarveGridExt.ColParamSize paramSize = list[i];
                MagnifierColumns cols = new MagnifierColumns();

                var column = columns.FirstOrDefault(s =>
                {
                    if (!string.IsNullOrEmpty(s.COLUMNA_NOMBRE))
                    {
                        return (s.COLUMNA_NOMBRE == paramSize.ColumnName);
                    }
                    return false;

                });
                cols.ANCHO = Convert.ToInt32(paramSize.ColumnWidth);
                cols.ID_LUPA = gridId;
                cols.POSICION = paramSize.ColumnIndex;
                if (column != null)
                {
                    cols.COLUMNA_NOMBRE = column.COLUMNA_NOMBRE;
                    cols.ID_COL = column.ID_COL;
                    cols.VISIBLE = column.VISIBLE;
                }
                columns.Add(cols);

            }
            bool ret = await DataServices.GetSettingsDataService().SaveColumnsSettings(columns);

            if (!ret)
            {
                Logger.Warn("Error during saving the settings");
            }
            // ok i can serialize this stuff.
        }

        public async Task GridResize(KarveControls.KarveGridExt.ColParamSize colsParam)
        {
            int gridId = Convert.ToInt32(GridId);
            _magnifierSettings = await DataServices.GetSettingsDataService().GetMagnifierSettings(gridId);
            _magnifierSettings.NOMBRE = MagnifierGridName;
            _magnifierSettings.LUPA = MagnifierGridName;
            var values = _magnifierSettings.MagnifierColumns;
            var column = values.FirstOrDefault(s =>
            {
                if (s.POSICION.HasValue)
                {
                    return (s.POSICION.Value == colsParam.ColumnIndex);
                }
                return false;

            });
            if (column != null)
            {

                column.ANCHO = Convert.ToInt32(colsParam.ColumnWidth);
                column.COLUMNA_NOMBRE = colsParam.ColumnName;
                column.POSICION = colsParam.ColumnIndex;
                bool retValue = await DataServices.GetSettingsDataService().SaveMagnifierSettings(_magnifierSettings);
                if (!retValue)
                {
                    Logger.Log(LogLevel.Error, "Cannot save a resize");
                }
            }
            else
            {
                IMagnifierColumns col = DataServices.GetSettingsDataService().NewMagnifierColumn();
                col.COLUMNA_NOMBRE = colsParam.ColumnName;
                col.ID_LUPA = Convert.ToInt32(GridId);
                col.POSICION = colsParam.ColumnIndex;
                col.ANCHO = Convert.ToInt32(colsParam.ColumnWidth);
                int retValue = await DataServices.GetSettingsDataService().CreateMagnifierColumn(col);
                if (retValue < 0)
                {
                    Logger.Log(LogLevel.Error, "Cannot create a new setting columns after a resize");
                }
            }
        }

        private async Task CreateNewCols(int pos, KarveControls.KarveGridExt.ColParamSize colsParam)
        {

            IMagnifierColumns col = DataServices.GetSettingsDataService().NewMagnifierColumn();
            col.COLUMNA_NOMBRE = colsParam.ColumnName;
            col.ID_LUPA = Convert.ToInt32(GridId);
            col.POSICION = pos;
            col.ANCHO = Convert.ToInt32(colsParam.ColumnWidth);
            int retValue = await DataServices.GetSettingsDataService().CreateMagnifierColumn(col);
            if (retValue < 0)
            {
                Logger.Log(LogLevel.Error, "Cannot create a new setting columns after a resize");
            }
        }
        public async void OnGridResize(object gridSize)
        {
            KarveControls.KarveGridExt.ColParamSize colsParam = gridSize as KarveControls.KarveGridExt.ColParamSize;

            if (colsParam == null)
            {
                return;
            }
            // check all cols.
            IMagnifierSettings magnifiersSettings = await DataServices.GetSettingsDataService().GetMagnifierSettings(Convert.ToInt32(GridId));
            // get all cols.
            List<IMagnifierColumns> columns = magnifiersSettings.MagnifierColumns.AsList<IMagnifierColumns>();
            // o(n*n). TODO find a better way.

            if (colsParam.ColumnList != null)
            {
                foreach (var col in colsParam.ColumnList)
                {
                    var swapToCol = columns.FirstOrDefault(s =>
                    {
                        if (s.POSICION.HasValue)
                        {
                            return (s.POSICION.Value == col.ColumnIndex);
                        }
                        return false;

                    });
                    if (swapToCol == null)
                    {
                        await CreateNewCols(col.ColumnIndex, col);
                    }
                }
            }
            // all columns are present in the db.
            // ok other things shall be taken in account.
            if (colsParam.OrderChanged)
            {
                await MoveAllCols(colsParam);
                return;
            }
            await GridResize(colsParam);

        }

        /// <summary>
        ///  This returns the grid column resize command
        /// </summary>
        public ICommand GridResizeCommand { set; get; }
        /// <summary>
        ///  This returns the default columns size.
        /// </summary>
        public ObservableCollection<KarveGridExt.ColParamSize> DefaultColumnsSize
        {
            set
            {
                _observableCollection = value;
                RaisePropertyChanged();
            }
            get { return _observableCollection; }
        }
        /// <summary>
        ///  This value returns foreach database row a tuple containing the value of the name and the id.
        /// </summary>
        /// <param name="rowView"></param>
        /// <param name="nameColumn"></param>
        /// <param name="codeColumn"></param>
        /// <returns></returns>
        protected Tuple<string, string> ComputeIdName(DataRowView rowView, string nameColumn, string codeColumn)
        {
            DataRow row = rowView.Row;
            string name = row[nameColumn] as string;
            string commissionId = row[codeColumn] as string;
            Tuple<string, string> codeTuple = new Tuple<string, string>(commissionId, name);
            return codeTuple;
        }

        /// <summary>
        /// Extended Data Table
        /// </summary>
        protected DataTable ExtendedDataTable;

        private INotifyTaskCompletion<bool> DeleteInitializationTable;

        private IMagnifierSettings _magnifierSettings;

        /// <summary>
        ///  This starts the load of data from the lower data layer.
        /// </summary>
        public abstract void StartAndNotify();

        /// <summary>
        ///  This asks to the control view model to open a new item for insertion. 
        /// </summary>
        public abstract void NewItem();

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
            DeleteRegion(primaryKeyValue);
            StartAndNotify();
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
            if ((payLoad.PayloadType == DataPayLoad.Type.UpdateView) && (NotifyState == 0))
            {
                lock (NotifyStateObject)
                {
                    _notifyState = 1;
                }
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

        /// <summary>
        ///  This module delete the region
        /// </summary>
        /// <param name="primaryKeyValue"></param>
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

        public virtual void DisposeEvents()
        {
            SaveMagnifierSettings(DefaultColumnsSize);

        }
        /// <summary>
        ///  This is shall be used by the different view model to set the value of the table initialzed;
        /// </summary>
        /// <param name="table"></param>
        protected abstract void SetTable(DataTable table);


        /// <summary>
        ///  This shall be used by different view models to set the registration payload.
        /// </summary>
        /// <param name="payLoad"> This is the payalod to be be registered</param>
        protected abstract void SetRegistrationPayLoad(ref DataPayLoad payLoad);

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
                    SetDataObject(result);
                    lock (NotifyStateObject)
                    {
                        NotifyState = 0;
                    }
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

        protected void InitializationNotifierOnSettingsChanged(object sender,
            PropertyChangedEventArgs propertyChangedEventArgs)
        {
            string propertyName = propertyChangedEventArgs.PropertyName;
            if (propertyName.Equals("Status"))
            {
                if (MagnifierInitializationNotifier.IsSuccessfullyCompleted)
                {
                    SetMagnifierSettings(MagnifierInitializationNotifier.Task.Result);
                }
            }
            else if (propertyName.Equals("IsSuccessfullyCompleted"))
            {
                INotifyTaskCompletion<IMagnifierSettings> task = sender as INotifyTaskCompletion<IMagnifierSettings>;
                if (task != null)
                {
                    IMagnifierSettings m = task.Result;
                    SetMagnifierSettings(m);
                }

            }
        }
        /// <summary>
        ///  FIXME: this is supposed to set the magnifier settings to the database.
        /// </summary>
        /// <param name="settings"></param>
        public void SetMagnifierSettings(IMagnifierSettings settings)
        {
            _magnifierSettings = settings;
            IEnumerable<IMagnifierColumns> columns = settings.MagnifierColumns;
            ObservableCollection<KarveControls.KarveGridExt.ColParamSize> colParams = new ObservableCollection<KarveControls.KarveGridExt.ColParamSize>();
            foreach (var col in columns)
            {

                KarveControls.KarveGridExt.ColParamSize paramSize = new KarveControls.KarveGridExt.ColParamSize();
                double value = Convert.ToDouble(col.ANCHO);
                paramSize.ColumnName = col.COLUMNA_NOMBRE;
                paramSize.ColumnWidth = value;
                if (col.POSICION.HasValue)
                {
                    paramSize.ColumnIndex = col.POSICION.Value;

                }
                colParams.Add(paramSize);
            }
         //   DefaultColumnsSize = colParams;
        }

        public void SaveMagnifierSettings(ObservableCollection<KarveControls.KarveGridExt.ColParamSize> colSize)
        {
            IDictionary<int, IMagnifierColumns> colDictionary = new Dictionary<int, IMagnifierColumns>();
            foreach (var col in _magnifierSettings.MagnifierColumns)
            {
                colDictionary.Add(col.POSICION.Value, col);
            }
            // copy back.            
            foreach (var col in DefaultColumnsSize)
            {
                IMagnifierColumns magnifierColumn = colDictionary[col.ColumnIndex];
              //  magnifierColumn.ANCHO = Convert.ToInt32(col.ColumnWidth);
              //  magnifierColumn.COLUMNA_NOMBRE = col.ColumnName;
                colDictionary.Remove(col.ColumnIndex);
                colDictionary.Add(col.ColumnIndex, magnifierColumn);

            }
            _magnifierSettings.ULTIMOD = DateTime.Now.ToLongTimeString();
            _magnifierSettings.MagnifierColumns = colDictionary.Values;
            _magnifierSettings.ID = Convert.ToInt32(GridId);
            _magnifierSettings.NOMBRE = MagnifierGridName;
            ConfigurationService.GetUserSettings().UserSettingsSaver.SaveMagnifierSettings(_magnifierSettings);

        }
        public abstract long GridId { set; get; }
        public abstract string MagnifierGridName { set; get; }

        /// <summary>
        /// SetDataObject. 
        /// </summary>
        /// <param name="result">DataObject to be set.</param>
        protected abstract void SetDataObject(object result);

        protected void RegisterMailBox(string mailboxName)
        {

            if (!string.IsNullOrEmpty(PrimaryKeyValue))
            {
                if (MailBoxHandler != null)
                {
                    EventManager.RegisterMailBox(mailboxName, MailBoxHandler);
                }
            }
        }
        protected void DeleteMailBox(string mailboxName)
        {

            if (!string.IsNullOrEmpty(PrimaryKeyValue))
            {
                if (MailBoxHandler != null)
                {
                    EventManager.DeleteMailBoxSubscription(mailboxName);
                }
            }
        }

        protected void ActiveSubSystem()
        {
            // change the active subsystem in the toolbar state.
            RegisterToolBar();
        }

        protected void RegisterToolBar()
        {
            // each module notify the toolbar.
            DataPayLoad payLoad = new DataPayLoad();
            SetRegistrationPayLoad(ref payLoad);
            EventManager.NotifyToolBar(payLoad);
            Logger.Log(LogLevel.Info, "Toolbar notified and subsystem active " + payLoad.Subsystem);
        }

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
        /// GetRouteName
        /// </summary>
        /// <param name="name">This is the route name. An unique name for the view model.</param>
        /// <returns></returns>
        protected abstract string GetRouteName(string name);

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
        /// Makes a payload with a data object or a data transfer object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name">Name of the form/tab</param>
        /// <param name="Object">Object to be sent to the data</param>
        /// <param name="queries">Queries optional to be sent to the info view.</param>
        /// <returns></returns>
        protected DataPayLoad BuildShowPayLoadDo<T>(string name, T Object, IDictionary<string, string> queries = null)
        {
            DataPayLoad currentPayload = new DataPayLoad();
            // name that it is give from the subclass, it may be a master
            string routedName = GetRouteName(name);
            currentPayload.PayloadType = DataPayLoad.Type.Show;
            currentPayload.Registration = routedName;
            currentPayload.HasDataObject = true;
            currentPayload.Subsystem = DataSubSystem.CommissionAgentSubystem;
            currentPayload.DataObject = Object;
            if (queries != null)
            {
                currentPayload.Queries = queries;
            }
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


        /// <summary>
        /// Callback to handle tab closing.
        /// </summary>        
        protected static void ClosingTabItemHandlerImpl(ItemActionCallbackArgs<TabablzControl> args)
        {
            //in here you can dispose stuff or cancel the close

            //here's your view model:
            var viewModel = args.DragablzItem.DataContext as HeaderedItemViewModel;
            CloseTabAction tabAction = new CloseTabAction();
            tabAction.Execute(args.DragablzItem);


            //here's how you can cancel stuff:
            //args.Cancel(); 
        }
    }
}
