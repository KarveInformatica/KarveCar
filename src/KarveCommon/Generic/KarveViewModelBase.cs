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
using KarveDataServices.DataTransferObject;
using NLog;
using Prism.Commands;
using Prism.Mvvm;
using Syncfusion.UI.Xaml.Grid;

namespace KarveCommon.Generic
{
    /// <inheritdoc />
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

        public DataPayLoad.Type OperationalState { get; set; }
        /// <summary>
        /// Each view model has associated an unique uri.
        /// </summary>
        private Uri _viewModelUri;

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
        ///  Assis mapper / mapeo de las lupas.
        /// </summary>
        protected IAssistMapper<BaseDto> AssistMapper;
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

        public bool IsChanged { set; get; }
        public bool Faulted { set; get; }
        /// <summary>
        ///  Disable/Enable any popup from the dialog service.
        /// </summary>
        public bool SilentMode { set; get; }

        public IInteractionRequestController Controller { get; private set; }

        /// <summary>
        ///  Dialog service for showing the view model things.
        /// </summary>
        protected IDialogService DialogService;

        /// <summary>
        ///  Assist service for showing magnifier popup.
        /// </summary>
        protected IAssistService AssistService;

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
        private long _gridIdentifer = long.MinValue;
        private string _header;
        private object _messageLock = new object();
        private string _itemName;
        protected string PrimaryKeyValue = string.Empty;
        private int _defaultPageSize = 800;
        private int _defaultPagingSize = 80;
        private int _defaultPageCount = 0;
        private object _extendedData;
        private IncrementalList<ClientSummaryExtended> _clientAssistList;
        private ICommand _changeCommand;
        private ICommand _changedCommand;
        private IncrementalList<ContractSummaryDto> _contractAuxiliar;
        private IncrementalList<VehicleSummaryDto> _vehicleAuxiliar;
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
        protected virtual void OnSortCommand(object sortCommand) {}

        /// <summary>
        /// KarveViewModelBase. Base view model of the all structure
        /// </summary>
        /// <param name="services">DataServices to be used.</param>
        public KarveViewModelBase(IDataServices services, IInteractionRequestController requestController) :
            this(services)
        {
            DataServices = services;
            Controller = requestController;
           
            HelperDataServices = services.GetHelperDataServices();
        }

        /// <summary>
        ///  KarveViewModelBase.
        /// </summary>
        /// <param name="services">DataServices to be used</param>
        /// <param name="dialogService">DialogServices to be used</param>
        public KarveViewModelBase(IDataServices services, IInteractionRequestController requestController,
            IDialogService dialogService) : this(services, requestController)
        {
            DialogService = dialogService;
        }

        private void InitViewModelState()
        {
            Guid = Guid.NewGuid();
            OperationalState = DataPayLoad.Type.Raw;
            //GridIdentifier = ""
            PagingEvent += OnPagedEvent;
            GridResizeCommand = new DelegateCommand<object>(OnGridResize);
            GridRegisterCommand = new DelegateCommand<object>(OnGridRegister);
        }
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
                _itemName = (string) value;
                RaisePropertyChanged("ItemName");
            }
        }
        public DataSubSystem SubSystem { set; get; }

        /// <summary>
        ///  Name of the header to be used.
        /// </summary>
        public string Header
        {
            get => _header;
            set
            {
                _header = (string) value;
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
            } while (RegisteredGridIds.Contains(value));

            // in case we have a minvalue.
            if (value == Int64.MinValue)
            {
                maxTries = 0;
            }

            if (maxTries == 0)
            {
                value = RegisteredGridIds.Max + 1;
                RegisteredGridIds.Add(value);
            }

            return value;
        }

       
        /// <summary>
        ///  Command to detect a change.
        /// </summary>
        public ICommand ItemChangedCommand { set; get; }

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
            set
            {
                _currentGridSettings = value;
                RaisePropertyChanged();
            }
            get => _currentGridSettings;
        }

        private void InitGridSettings(IDataServices services, long id)
        {
            MagnifierInitializationNotifier =
                NotifyTaskCompletion.Create<ObservableCollection<GridSettingsDto>>(LoadSettings(services, id),
                    InitializationNotifierOnSettingsChanged);
        }

        private async Task<ObservableCollection<GridSettingsDto>> LoadSettings(IDataServices services, long id)
        {
            var numberLists = new List<long>();
            numberLists.Add(id);
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
                var settingsDto = new GridSettingsDto();
                settingsDto.GridName = param.GridName;
                settingsDto.GridIdentifier = param.GridIdentifier;
                settingsDto.XmlBase64 = param.Xml;
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
        public virtual bool IsDeleter {  get; } = false;
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
            set { _gridParm = value; RaisePropertyChanged(); }
            get { return _gridParm; }
        }

        public long GridIdentifier
        {
            set { _gridIdentifer = value; RaisePropertyChanged(); }
            get { return _gridIdentifer; }
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
            _clientAssistList = new IncrementalList<ClientSummaryExtended>(LoadMoreAssistClients) { MaxItemCount = (int) maxItems };
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
                                                Action<Dto> callback) where Dto: class
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
        public virtual async Task OnAssistPagedAsync<Dto, Entity>(string title, string properties, string query,Action<Dto> callback)
            where Dto : class
            where Entity : class
        {
            var services = DataServices.GetHelperDataServices();
            var dtos = await services.GetPagedAsyncHelper<Dto, Entity>(query, _assistPaged, DefaultPageSize).ConfigureAwait(false);
            ShowDataTransferObjects<Dto>(dtos, title, properties, callback);
        }
        // GetPagedQueryDoAsync<
        public virtual async Task OnAssistQueryAsync<Dto, Entity>(string title, string properties, string query,
            Action<Dto> callback) where Dto: class 
                                   where Entity: class
        {
            var services = DataServices.GetHelperDataServices();
            var dtos = await services.GetMappedAsyncHelper<Dto, Entity>(query).ConfigureAwait(false);
            ShowDataTransferObjects<Dto>(dtos, title, properties,callback);
        }

        public virtual async Task OnVehicleSummaryAsync(string title, string properties, Action<VehicleSummaryDto> callback )
        {
           
            var vehicleDataServices =DataServices.GetVehicleDataServices(); 
            var vehicleList = await vehicleDataServices.GetPagedSummaryDoAsync(1, DefaultPageSize).ConfigureAwait(false);
            _vehicleAuxiliar = new IncrementalList<VehicleSummaryDto>(LoadMoreVehicles);
            _vehicleAuxiliar.LoadItems(vehicleList);
            ShowDataTransferObjects<VehicleSummaryDto>(_vehicleAuxiliar, title, properties, callback);
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
            NotifyTaskCompletion.Create(contractDataServices.GetPagedSummaryDoAsync(1, index), (sender, ev)=>
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
            set { _gridParameters = value; RaisePropertyChanged(); }
            get { return _gridParameters; }
        }
      
        /// <summary>
        ///  Each view model can have a grid resize command.
        /// </summary>
        public ICommand GridResizeCommand { set; get; }
        /// <summary>
        ///  Property useful for doing an assist query and bind it to the xaml.
        /// </summary>
        public string AssistQuery
        {
            set
            {
                _sqlQuery = value;
                RaisePropertyChanged();
            }
            get { return _sqlQuery; }

        }
        /// <summary>
        ///  Page size to retrieve the data
        /// </summary>
        public int DefaultPageSize
        {
            get { return _defaultPageSize; }
            set { _defaultPageSize = value; }
        }
        /// <summary>
        ///  Page size to show the data in the data pager.
        /// </summary>
        public int DefaultPagingSize
        {
            set
            {
                _defaultPagingSize = value;
                RaisePropertyChanged();
            }
            get
            {
                return _defaultPagingSize;
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
        public ICommand AssistCommand { set; get; }
        public string DirectSubsystem { get; set; }
        public Uri ViewModelUri { set { _viewModelUri = value; } get { return _viewModelUri; } }

    }
}
