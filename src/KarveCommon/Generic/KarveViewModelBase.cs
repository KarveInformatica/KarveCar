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
using Prism.Commands;
using Prism.Mvvm;
using Syncfusion.UI.Xaml.Grid;

namespace KarveCommon.Generic
{
    /// <summary>
    /// View model base. It is at the top of any view model in the infrastructure. 
    /// It implement the mailbox notification. Each view model can receive mail message, when 
    /// a mail comes from the event manager, it triggers an event to notify a new DataPayload message.
    /// </summary>
    public class KarveViewModelBase: BindableBase, IDisposeEvents
    {

        protected const string InsertState = "Estado Agregar.";
        protected const string UpdateState = " Estado Modificar.";
        protected const string DeletedSuccess = "Valor borrado con exito.";
        protected const string DefaultState = "Estado consultar.";
        /// <summary>
        /// Each view model has associated an unique uri.
        /// </summary>
        protected Uri ViewModelUri;
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
        private ObservableCollection<GridSettingsDto> _currentGridSettings = new ObservableCollection<GridSettingsDto>();

        protected Guid Guid;
        private KarveGridParameters _gridParm = new KarveGridParameters();
        private long _gridIdentifer = long.MinValue;
        private string _header;
        private object _messageLock = new object();
        private string _itemName;
        protected string PrimaryKeyValue = string.Empty;


        /// <summary>
        ///  empty constructor
        /// </summary>
        public KarveViewModelBase()
        {
            InitViewModelState();
            Header = "DefaultTab";
        }
        public KarveViewModelBase(IDataServices services)
        {
            DataServices = services;
            var assistDataService = services.GetAssistDataServices();
            if (assistDataService != null)
            {
                AssistMapper = assistDataService.Mapper;
            }
            HelperDataServices = services.GetHelperDataServices();
            InitViewModelState();
        }
        /// <summary>
        /// KarveViewModelBase. Base view model of the all structure
        /// </summary>
        /// <param name="services">DataServices to be used.</param>
        public KarveViewModelBase(IDataServices services, IInteractionRequestController requestController) : this(services)
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
        public KarveViewModelBase(IDataServices services, IInteractionRequestController requestController, IDialogService dialogService) : this(services, requestController)
        {
            DialogService = dialogService;
        }
        private void InitViewModelState()
        {
            Guid = Guid.NewGuid();
            //GridIdentifier = ""
            GridResizeCommand = new DelegateCommand<object>(OnGridResize);
            GridRegisterCommand = new DelegateCommand<object>(OnGridRegister);
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
           List<long> numberLists = new List<long>();
           numberLists.Add(id);
           ObservableCollection<GridSettingsDto> settingsDto =
                await services.GetSettingsDataService().GetMagnifierSettingByIds(numberLists);
           return settingsDto;
        }


        /// <summary>
        ///  Command happened during the resize.
        /// </summary>
        /// <param name="var"></param>
        private async void OnGridResize(object var)
        {
            KarveGridParameters param = var as KarveGridParameters;
            if (param != null)
            {
                ISettingsDataServices dataService = DataServices.GetSettingsDataService();
                GridSettingsDto settingsDto = new GridSettingsDto();
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
            KarveGridParameters param = var as KarveGridParameters;
            if (param != null)
            {
                
                RegisteredGridIds.Add(param.GridIdentifier);
                InitGridSettings(DataServices, param.GridIdentifier);
            }
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
                INotifyTaskCompletion<ObservableCollection<GridSettingsDto>> task = sender as INotifyTaskCompletion<ObservableCollection<GridSettingsDto>>;
                if (task != null)
                {
                   
                    ObservableCollection<GridSettingsDto> m = task.Result;
                    CurrentGridSettings = m;
                    OnGridChange(m);
                }
            }
            if ((DialogService!=null) && (MagnifierInitializationNotifier != null))
            {
                if (MagnifierInitializationNotifier.IsFaulted)
                {
                    DialogService.ShowErrorMessage(MagnifierInitializationNotifier.ErrorMessage);
                }
            }
        }

        /// <summary>
        ///  This is get invoked by the KarveBaseViewModel
        /// </summary>
        /// <param name="dto"></param>
        protected virtual void OnGridChange(ObservableCollection<GridSettingsDto> dto)
        {
            if (dto != null)
            {
                GridSettingsDto gridSettingsDto = dto.FirstOrDefault();
                if (gridSettingsDto != null)
                {
                    GridParam = new KarveGridParameters(gridSettingsDto.GridIdentifier, gridSettingsDto.GridName,
                        gridSettingsDto.XmlBase64);
                }
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
        ///<summary>
        /// When a region get destroyed we can dispose the events.
        /// </summary>
        public virtual void DisposeEvents()
        {
            
        }

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
            var dtos = await dataServices.GetAsyncAllClientSummary();
            ShowDataTransferObjects<ClientSummaryExtended>(dtos, title, properties, callback);
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
        /// <param name="item">Item selected from the column</param>
        /// <param name="callback">Callback to be called</param>

        public virtual async Task OnAssistAsync<Dto, Entity>(string title, string properties, Action<Dto> callback)
            where Dto : class
            where Entity : class
        {
            IHelperDataServices services = DataServices.GetHelperDataServices();
            var dtos = await services.GetMappedAllAsyncHelper<Dto, Entity>().ConfigureAwait(false);
            ShowDataTransferObjects<Dto>(dtos, title, properties, callback);            
        }

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
            var summary = await vehicleDataServices.GetAsyncVehicleSummary().ConfigureAwait(false);
            ShowDataTransferObjects<VehicleSummaryDto>(summary, title, properties, callback);
        }

        public virtual async Task OnContractSummaryAsync(string title, string properties, Action<ContractSummaryDto> callback)
        {
            var contractDataServices = DataServices.GetContractDataServices();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var summary = await contractDataServices.GetContractSummaryAsync().ConfigureAwait(false);
            sw.Stop();
            var elapsed = sw.ElapsedMilliseconds;
            ShowDataTransferObjects<ContractSummaryDto>(summary, title, properties, callback);
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
      

    }
}
