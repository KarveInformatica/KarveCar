// --------------------------------------------------------------------------------------------------------------------
// <copyright file="KarveViewModelBase.cs" company="KarveInformatica S.L.">
// All right reserved.
// </copyright>
// <summary>
//   View model base. It is at the top of any view model in the infrastructure.
//   It implements:
//   1. Mailbox notification. Each view model can receive mail message, when
//   a mail comes from the event manager, it triggers an event to notify a new DataPayload message.
//   2. Assist Mapping. Each search box when the magnifier is pressed will execute a Magnifier command (an assist) to be intercepted by the assist mapper contained in the AssistDataService.
//   3. Unique global identifier for the view model. Each view model has an unique URI and Id.
//   4. Grid resizing. If a view has a grid associated. All the view models shall be able to serialize the columns and resize it.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace KarveCommon.Generic
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using KarveCommon.Services;
    using KarveCommonInterfaces;
    using KarveDataServices;
    using KarveDataServices.ViewObjects;
    using NLog;
    using Prism.Commands;
    using Prism.Mvvm;
    using Syncfusion.UI.Xaml.Grid;

    /// <summary>
    /// View model base. It is at the top of any view model in the infrastructure. 
    /// It implement the mailbox notification. Each view model can receive mail message, when 
    /// a mail comes from the event manager, it triggers an event to notify a new DataPayload message.
    /// </summary>
    public class KarveViewModelBase : BindableBase, IDisposeEvents
    {

        protected const string InsertState = "Estado Agregar.";
        protected const string UpdateState = " Estado Modificar.";
        protected const string DeletedSuccess = "Valor borrado con exito.";
        protected const string DefaultState = "Estado consultar.";



        protected Logger Logger = LogManager.GetCurrentClassLogger();


        protected OfficeViewObject CommonOfficeViewObject { set; get; }
        protected CompanyViewObject CommonCompanyViewObject { set; get; }


        public DataPayLoad.Type OperationalState { get; set; }

        /// <summary>
        /// Each view model has a mailbox. 
        /// A mailbox is a way to receive messages through the event manager/ event dispatcher.
        /// </summary>
        protected MailBoxMessageHandler MailBoxHandler;

        /// <summary>
        ///  Magnifier reference
        /// </summary>
        protected IHelperDataServices HelperDataServices;

        /// <summary>
        ///  Assist mapper. It has been used to trigger a popup when we press a popup.
        /// </summary>
        protected IAssistMapper<BaseViewObject> AssistMapper;
        /*
         * Notify task completion to avoid async void. Async void is bad:
         * Async void methods have different error-handling semantics. Exceptions are very awkward to handle.
         *  Async void methods have different composing semantics. This is an argument centered around code maintainability an * reuse.Async void methods are difficult to test.
         The return type of an assist is true or false.
             */

        protected INotifyTaskCompletion<bool> AssistNotifierInitialized;

        /// <summary>
        ///  Notification when an assist get executed.
        /// </summary>
        protected PropertyChangedEventHandler AssistExecuted;

        /// <summary>
        ///  Paging event for the notification.
        /// </summary>
        protected PropertyChangedEventHandler PagingEvent;

        /// <summary>
        ///  SqlQuery. This is an assist query.
        /// </summary>
        private string _sqlQuery;

        /// <summary>
        ///  GridParameters.
        /// </summary>
        private GridSettingsDto _gridParameters;

        /// <summary>
        ///  Handler to load all grid of all
        /// </summary>
        protected INotifyTaskCompletion<ObservableCollection<GridSettingsDto>> MagnifierInitializationNotifier;

        /// <summary>
        /// DataServices about grid parameters.
        /// </summary>
        protected IDataServices DataServices;

        public bool IsChanged { get; set; } = false;
        /// <summary>
        ///  A view model is ready when it has been initialized with its data.
        /// </summary>
        public bool IsReady { get; set; } = false;
        /// <summary>
        ///  
        /// </summary>
        public bool Faulted { get; set; } = false;
        /// <summary>
        ///  The view mode support composity command only. This means that it will register just composite command inside 
        ///  the toolbar and doesn't use any data handler of the toolbar.
        /// </summary>
        public bool CompositeCommandOnly { get; set; }

        /// <summary>
        ///  Disable/Enable any popup from the dialog service.
        /// </summary>
        public bool SilentMode { get; set; }

        public IInteractionRequestController Controller { get; private set; }

        /// <summary>
        ///  Dialog service for showing the view model things.
        /// </summary>
        protected IDialogService DialogService;

        /// <summary>
        ///  Assist service for showing magnifier popup.
        /// </summary>
        protected IAssistService AssistService;


        protected IConfigurationService ConfigurationService;
        /// <summary>
        ///  Registered grid list.
        /// </summary>

        protected static SortedSet<long> RegisteredGridIds = new SortedSet<long>();

        /// <summary>
        ///  Current grid settings.
        /// </summary>
        private ObservableCollection<GridSettingsDto>
            _currentGridSettings = new ObservableCollection<GridSettingsDto>();

        protected Guid Guid;
        private KarveGridParameters _gridParm = new KarveGridParameters();
        private long _gridIdentifer = Int64.MinValue;
        private string _header;
        private object _messageLock = new object();
        private string _itemName;
        protected string PrimaryKeyValue = string.Empty;
        private int _defaultPagingSize = 80;
        private int _defaultPageCount = 0;
        private object _extendedData;
        private IncrementalList<ClientSummaryExtended> _clientAssistList;
        private ICommand _changeCommand;
        private ICommand _changedCommand;
        private IncrementalList<ContractSummaryDto> _contractAuxiliar;
        private IncrementalList<VehicleSummaryViewObject> _vehicleAuxiliar;
        private int _assistPaged = 1;


        /// <summary>
        ///  empty constructor
        /// </summary>
        public KarveViewModelBase()
        {
            InitViewModelState();
            Header = "DefaultTab";
            SubSystem = DataSubSystem.None;
            DefaultPageSize = 100;

        }


        public KarveViewModelBase(IDataServices services)
        {
            DataServices = services;
            var assistDataService = services.GetAssistDataServices();
            if (assistDataService != null)
            {
                AssistMapper = assistDataService.Mapper;
            }

            SortCommand = new DelegateCommand<object>(OnSortCommand);
            HelperDataServices = services.GetHelperDataServices();
            InitViewModelState();
        }

        /// <summary>
        ///  Virtual class that id osent nothing.
        /// </summary>
        protected virtual void OnSortCommand(object sortCommand) { }

        /// <summary>
        /// KarveViewModelBase. Configuration service.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="requestController"></param>
        /// <param name="configurationService"></param>
        public KarveViewModelBase(IDataServices services, IInteractionRequestController requestController, IConfigurationService configurationService) :
            this(services)
        {
            DataServices = services;
            Controller = requestController;
            ConfigurationService = configurationService;
            HelperDataServices = services.GetHelperDataServices();
            InitConfiguration(ConfigurationService);
        }

        /// <summary>
        ///  KarveViewModelBase.
        /// </summary>
        /// <param name="services">DataServices to be used</param>
        /// <param name="dialogService">DialogServices to be used</param>
        public KarveViewModelBase(IDataServices services, IInteractionRequestController requestController,
            IDialogService dialogService, IConfigurationService configurationService) : this(services, requestController, configurationService)
        {
            DialogService = dialogService;
            
        }

        protected void InitConfiguration(IConfigurationService service)
        {
            var environ = service.EnviromentVariables;
            this.CurrentOffice = environ.GetKey(EnvironmentConfig.KarveConfiguration, EnvironmentKey.CurrentOffice) as string;
            this.CurrentUser = environ.GetKey(EnvironmentConfig.KarveConfiguration, EnvironmentKey.CurrentUser) as string;
            this.CurrentCompany = environ.GetKey(EnvironmentConfig.KarveConfiguration, EnvironmentKey.ConnectedCompany) as string;
           
        }

      

        /*
        private OfficeViewObject GetCurrentOffice()
        {
            var officeDataService = DataServices.GetOfficeDataServices();
            
            NotifyTaskCompletion.Create<bool>(authService.CanAccess(user, this.configurationService),
                (task, ev) =>
                {
                    if (task is INotifyTaskCompletion<bool> taskCompletion)
                    {
                        if (taskCompletion.IsSuccessfullyCompleted)
                        {
                            if (taskCompletion.Result)
                            {
                                IsLogged = true;
                                View?.Close();
                            }
                            else
                            {
                                IsLogged = false;
                                LoginError = KarveLocale.Properties.Resources.linvalidpass;
                            }
                        }
                    }
                });
        
        }
        */
       
        /// <summary>
        ///  Summary of the control magnifier.
        /// </summary>

        public object SummaryView
        {
            get => _extendedData;
            set
            {
                _extendedData = value;
                RaisePropertyChanged("SummaryView");

            }
        }

        /// <summary>
        /// The raise property change after viewmodel initialization.
        /// There is a case that you may want just trigger once all the notification
        /// from an object using RaisePropertyChange(null).
        /// This has better performance during view loading.
        /// </summary>
        /// <param name="propertyName">
        /// Name of the property to be loaded.
        /// </param>
        protected void RaisePropertyChangeAfterInit(string propertyName = null)
        {
            if (IsViewModelInitialized)
            {
                RaisePropertyChanged(propertyName);
            }
        }

        /// <summary>
        ///  This is meant to be overriden only when the PageEvent is needed
        /// </summary>
        /// <param name="sender">Sender of the paging</param>
        /// <param name="e">Event handler</param>
        protected virtual void OnPagedEvent(object sender, PropertyChangedEventArgs e)
        {
        }

        /// <summary>
        ///  This class is the event who is able to load an incremental list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnNotifyIncrementalList<T>(object sender, PropertyChangedEventArgs e)
        {
            var notification = sender as INotifyTaskCompletion<IEnumerable<T>>;
            if (notification != null && notification.IsSuccessfullyCompleted)
            {
                SetResult(notification.Task.Result);
            }

            if (notification != null && notification.IsFaulted)
            {
                DialogService?.ShowErrorMessage("Error loading grid data: " + notification.ErrorMessage);
            }
        }

        /// <summary>
        ///  This class set the results for the incremental load
        /// </summary>
        /// <typeparam name="T">Dto type to be set during the incremental load.</typeparam>
        /// <param name="result">Set to be loaded in the incremental load.</param>

        protected virtual void SetResult<T>(IEnumerable<T> taskResult)
        {
        }

        /// <summary>
        /// Name of the item to be used.
        /// </summary>
        public string ItemName
        {
            get => _itemName;
            set
            {
                _itemName = (string)value;
                RaisePropertyChanged("ItemName");
            }
        }
        public DataSubSystem SubSystem { get; set; }

        /// <summary>
        ///  Name of the header to be used.
        /// </summary>
        public string Header
        {
            get => _header;
            set
            {
                _header = (string)value;
                RaisePropertyChanged("Header");
            }
        }

        /// <summary>
        ///  Unique Id for the helpers.
        /// </summary>
        protected string UniqueId
        {
            get => Guid.ToString();
            set => Guid = Guid.Parse(value);
        }

        /// <summary>
        ///  GeneratedGridId. This generate a grid identifier.
        /// </summary>
        /// <returns></returns>
        protected long GenerateGridId()
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            // Buffer storage.
            byte[] data = new byte[8];
            long value;
            int maxTries = 10;
            do
            {
                // Fill buffer.
                rng.GetBytes(data);
                // Convert to int 32.
                value = Math.Abs(BitConverter.ToInt64(data, 0));
                maxTries--;
                if (maxTries == 0)
                {
                    break;
                }
            }

 while (RegisteredGridIds.Contains(value));

            // in case we have a minvalue.
            if (value == Int64.MinValue)
            {
                maxTries = 0;
            }

            if (maxTries != 0)
            {
                return value;
            }

            // no correct value found.
            value = RegisteredGridIds.Max + 1;
            RegisteredGridIds.Add(value);
            return value;
        }


        /// <summary>
        ///  Command to detect a change.
        /// </summary>
        public ICommand ItemChangedCommand { get; set; }

        /// <summary>
        ///  Grid register command
        /// </summary>
        public ICommand GridRegisterCommand { get; set; }

        public bool IsViewModelInitialized { get; set; }
        /// <summary>
        /// CurrentGrid Settings
        /// </summary>
        public ObservableCollection<GridSettingsDto> CurrentGridSettings
        {
            get => _currentGridSettings;
            set
            {
                this._currentGridSettings = value;
                this.RaisePropertyChanged();
            }
        }

        private void InitGridSettings(IDataServices services, long id)
        {
            MagnifierInitializationNotifier =
                NotifyTaskCompletion.Create<ObservableCollection<GridSettingsDto>>(LoadSettings(services, id),
                    InitializationNotifierOnSettingsChanged);
        }

        private async Task<ObservableCollection<GridSettingsDto>> LoadSettings(IDataServices services, long id)
        {
            var numberLists = new List<long> { id };
            var settingsDto =
                await services.GetSettingsDataService().GetMagnifierSettingByIds(numberLists);
            return settingsDto;
        }

        /// <summary>
        ///  Command happened during the resize.
        /// </summary>
        /// <param name="var"></param>
        private async void OnGridResize(object var)
        {
            var dataService = DataServices.GetSettingsDataService();
            if (var is KarveGridParameters param)
            {
                var settingsDto = new GridSettingsDto
                {
                    GridName = param.GridName,
                    GridIdentifier = param.GridIdentifier,
                    XmlBase64 = param.Xml
                };
                var value = false;
                try
                {

                    value = await dataService.SaveMagnifierSettings(settingsDto).ConfigureAwait(false);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

            }
        }

        private void OnGridRegister(object var)
        {
            if (var is KarveGridParameters param)
            {

                RegisteredGridIds.Add(param.GridIdentifier);
                InitGridSettings(DataServices, param.GridIdentifier);
            }
        }

        public virtual bool IsDeleter { get; } = false;
        /*
         * We want to give to each view the ability to save/delete himself. This function will be part of a composite command.
         */
        /// <summary>
        ///  Method to be overridden to allow the view to delete himself.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public virtual bool DeleteView(object key)
        {
            return false;
        }

        /// <summary>
        ///  Method to be overridden to allow the view to save himself..
        /// </summary>
        public virtual void SaveView()
        {
            return;
        }



        /// <summary>
        /// TODO: Handle errors in NotifierOnSettingsChanged.
        /// </summary>
        /// <param name="sender">Sender notifier</param>
        /// <param name="propertyChangedEventArgs">Parameters to be used.</param>
        protected void InitializationNotifierOnSettingsChanged(object sender,
            PropertyChangedEventArgs propertyChangedEventArgs)
        {
            string propertyName = propertyChangedEventArgs.PropertyName;
            if (propertyName.Equals("Status"))
            {
                if (MagnifierInitializationNotifier.IsSuccessfullyCompleted)
                {
                    ObservableCollection<GridSettingsDto> dto = MagnifierInitializationNotifier.Task.Result;
                    CurrentGridSettings = dto;

                }
            }
            else if (propertyName.Equals("IsSuccessfullyCompleted"))
            {
                if (sender is INotifyTaskCompletion<ObservableCollection<GridSettingsDto>> task)
                {

                    var m = task.Result;
                    CurrentGridSettings = m;
                    OnGridChange(m);
                }
            }

            if ((DialogService == null) || (MagnifierInitializationNotifier == null)) return;
            if (MagnifierInitializationNotifier.IsFaulted)
            {
                DialogService.ShowErrorMessage(MagnifierInitializationNotifier.ErrorMessage);
            }
        }

        /// <summary>
        ///  This is get invoked by the KarveBaseViewModel
        /// </summary>
        /// <param name="dto"></param>
        protected virtual void OnGridChange(ObservableCollection<GridSettingsDto> dto)
        {
            if (dto == null) return;
            var gridSettingsDto = dto.FirstOrDefault();
            if (gridSettingsDto != null)
            {
                GridParam = new KarveGridParameters(gridSettingsDto.GridIdentifier, gridSettingsDto.GridName,
                    gridSettingsDto.XmlBase64);
            }
        }

        public KarveGridParameters GridParam
        {
            get { return _gridParm; }
            set { this._gridParm = value; this.RaisePropertyChanged(); }
        }

        public long GridIdentifier
        {
            get { return _gridIdentifer; }
            set { this._gridIdentifer = value; this.RaisePropertyChanged(); }
        }

        /// <inheritdoc />
        /// <summary>
        ///  When a region get destroyed we can dispose the events.
        ///  </summary>
        public virtual void DisposeEvents()
        {
            PagingEvent -= OnPagedEvent;
            OperationalState = DataPayLoad.Type.Raw;
        }

        // TODO expose as generic.
        /// <summary>
        ///  AssitAsyncClient.
        /// </summary>
        /// <typeparam name="Dto"></typeparam>
        /// <typeparam name="Entity"></typeparam>
        /// <param name="title"></param>
        /// <param name="properties"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public virtual async Task OnAssistAsyncClient(string title, string properties, Action<ClientSummaryExtended> callback)
        {
            IClientDataServices dataServices = DataServices.GetClientDataServices();
            var pageNumberAndItems = await dataServices.GetPageCount(DefaultPageSize);
            var maxItems = dataServices.NumberItems;
            var dtos = await dataServices.GetPagedSummaryDoAsync(1, DefaultPageSize);
            _clientAssistList = new IncrementalList<ClientSummaryExtended>(LoadMoreAssistClients) { MaxItemCount = (int)maxItems };
            ShowDataTransferObjects<ClientSummaryExtended>(_clientAssistList, title, properties, callback);
        }

        protected virtual void LoadMoreAssistClients(uint arg1, int baseIndex)
        {
            IClientDataServices dataServices = DataServices.GetClientDataServices();
            NotifyTaskCompletion.Create(dataServices.GetPagedSummaryDoAsync(baseIndex, DefaultPageSize), (sender, args) =>
            {
                if (sender is INotifyTaskCompletion<IEnumerable<ClientSummaryExtended>> summary)
                {
                    if (summary.IsSuccessfullyCompleted)
                    {
                        _clientAssistList.LoadItems(summary.Result);
                    }
                    else
                    {
                        DialogService?.ShowErrorMessage("Cannot load client assist");
                    }
                }
            });
        }

        public void ShowDataTransferObjects<Dto>(IEnumerable<Dto> dtos,
                                                string title,
                                                string properties,
                                                Action<Dto> callback) where Dto : class
        {
            Stopwatch start = new Stopwatch();
            start.Start();
            Controller.ShowAssistView<Dto>(title, dtos, properties);
            start.Stop();
            var elapsed = start.ElapsedMilliseconds;
            if ((Controller.SelectedItem != null) && (Controller.SelectionState == SelectionState.OK))
            {
                if (!(Controller.SelectedItem is IList<object> items))
                {
                    return;
                }

                var currentValue = items.FirstOrDefault();
                switch (currentValue)
                {
                    case null:
                        return;
                    case GridRowInfo rowInfo:
                        var dtoData = rowInfo.RowData as Dto;
                        callback?.Invoke(dtoData);
                        break;
                }
            }
        }

        /// <summary>
        ///  This function is a generic function to raise interaction request and select an item
        /// </summary>
        /// <typeparam name="Dto">Data Transfer Object to select</typeparam>
        /// <typeparam name="Entity">Entity to select</typeparam>
        /// <param name="title">Title of the dialogbox</param>
        /// <param name="properties">Grid columns to filter</param>
        /// <param name="callback">Callback to be called</param>

        public virtual async Task OnAssistAsync<Dto, Entity>(string title, string properties, Action<Dto> callback)
            where Dto : class
            where Entity : class
        {
            var services = DataServices.GetHelperDataServices();
            var dtos = await services.GetMappedAllAsyncHelper<Dto, Entity>().ConfigureAwait(false);
            ShowDataTransferObjects<Dto>(dtos, title, properties, callback);
        }

        public virtual async Task OnAssistPagedAsync<Dto, Entity>(string title, string properties, string query, Action<Dto> callback)
            where Dto : class
            where Entity : class
        {
            var services = DataServices.GetHelperDataServices();
            var dtos = await services.GetPagedAsyncHelper<Dto, Entity>(query, _assistPaged, DefaultPageSize).ConfigureAwait(false);
            ShowDataTransferObjects<Dto>(dtos, title, properties, callback);
        }
   
        public virtual async Task OnAssistQueryAsync<Dto, Entity>(string title, string properties, string query,
            Action<Dto> callback) where Dto : class
                                   where Entity : class
        {
            var services = DataServices.GetHelperDataServices();
            var dtos = await services.GetMappedAsyncHelper<Dto, Entity>(query).ConfigureAwait(false);
            ShowDataTransferObjects<Dto>(dtos, title, properties, callback);
        }

        public virtual async Task OnVehicleSummaryAsync(string title, string properties, Action<VehicleSummaryViewObject> callback)
        {

            var vehicleDataServices = DataServices.GetVehicleDataServices();
            var vehicleList = await vehicleDataServices.GetPagedSummaryDoAsync(1, DefaultPageSize).ConfigureAwait(false);
            _vehicleAuxiliar = new IncrementalList<VehicleSummaryViewObject>(LoadMoreVehicles);
            _vehicleAuxiliar.LoadItems(vehicleList);
            ShowDataTransferObjects<VehicleSummaryViewObject>(_vehicleAuxiliar, title, properties, callback);
        }

        private async void LoadMoreVehicles(uint arg1, int idx)
        {
            var vehicleDataServices = DataServices.GetVehicleDataServices();
            var vehicleList = await vehicleDataServices.GetPagedSummaryDoAsync(idx, DefaultPageSize).ConfigureAwait(false);
            _vehicleAuxiliar.LoadItems(vehicleList);
        }

        public virtual async Task OnContractSummaryAsync(string title, string properties, Action<ContractSummaryDto> callback)
        {
            var contractDataServices = DataServices.GetContractDataServices();
            _contractAuxiliar = new IncrementalList<ContractSummaryDto>(
                LoadMoreContracts);
            var contractSummary = await contractDataServices.GetPagedSummaryDoAsync(1, DefaultPageSize).ConfigureAwait(false);
            _contractAuxiliar.LoadItems(contractSummary);

            ShowDataTransferObjects<ContractSummaryDto>(_contractAuxiliar, title, properties, callback);
        }

        private void LoadMoreContracts(uint arg1, int index)
        {
            var contractDataServices = DataServices.GetContractDataServices();
            NotifyTaskCompletion.Create(contractDataServices.GetPagedSummaryDoAsync(1, index), (sender, ev) =>
            {
                if (sender is INotifyTaskCompletion<IEnumerable<ContractSummaryDto>> task)
                {
                    if (task.IsSuccessfullyCompleted)
                    {
                        _contractAuxiliar.LoadItems(task.Result);
                    }
                    else
                    {
                        DialogService?.ShowErrorMessage("Cannot load more contracts");
                    }
                }
            });

        }

        /// <summary>
        /// GridSettings.
        /// </summary>
        public GridSettingsDto GridSettings
        {
            get => _gridParameters;
            set { this._gridParameters = value; this.RaisePropertyChanged(); }
        }

        /// <summary>
        ///  Each view model can have a grid resize command.
        /// </summary>
        public ICommand GridResizeCommand { get; set; }

        /// <summary>
        ///  Property useful for doing an assist query and bind it to the xaml.
        /// </summary>
        public string AssistQuery
        {
            get => _sqlQuery;
            set
            {
                this._sqlQuery = value;
                this.RaisePropertyChanged();
            }
        }
        /// <summary>
        ///  Set or get the current user
        /// </summary>
        protected string CurrentUser { set; get; }
        
        /// <summary>
        ///  Set or get the current company
        /// </summary>
        protected string CurrentCompany { set; get; }
        /// <summary>
        ///  Set or get the current office.
        /// </summary>
        protected string CurrentOffice { set; get; }

        /// <summary>
        ///  Page size to retrieve the data
        /// </summary>
        public int DefaultPageSize { get; set; } = 800;

        /// <summary>
        ///  Page size to show the data in the data pager.
        /// </summary>
        public int DefaultPagingSize
        {
            get => _defaultPagingSize;
            set
            {
                this._defaultPagingSize = value;
                this.RaisePropertyChanged();
            }
        }

        /// <summary>
        ///  Number of pages
        /// </summary>
        public int PageCount
        {
            get => _defaultPageCount;
            set { _defaultPageCount = value; RaisePropertyChanged(); }
        }
        /// <summary>
        ///  Command for the grid filter who gets paged information from the database.
        /// </summary>
        public ICommand SortCommand { get; set; }
        /// <summary>
        ///  Command for triggering the assist 
        /// </summary>
        public ICommand AssistCommand { get; set; }

        /// <summary>
        ///  Option to skip the toolbar logic for saving. It shall be deprecated.
        /// </summary>
        public string DirectSubsystem { get; set; }

        /// <summary>
        /// Set or Get a ViewModelUri.
        /// </summary>
        public Uri ViewModelUri { get; set; }

        private void InitViewModelState()
        {
            Guid = Guid.NewGuid();
            OperationalState = DataPayLoad.Type.Raw;
            //GridIdentifier = ""
            PagingEvent += OnPagedEvent;
            GridResizeCommand = new DelegateCommand<object>(OnGridResize);
            GridRegisterCommand = new DelegateCommand<object>(OnGridRegister);
        }
    }
}
