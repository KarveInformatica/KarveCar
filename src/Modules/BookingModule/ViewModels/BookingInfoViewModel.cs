using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using KarveCommon.Generic;
using KarveCommon.Services;
using KarveCommonInterfaces;
using KarveDataServices;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;
using Prism.Regions;
using Prism.Commands;
using Syncfusion.UI.Xaml.Grid;
using System.Collections.ObjectModel;
using KarveControls.Behaviour.Grid;
using Microsoft.Practices.Unity;
using BookingModule.Views;
using System.ComponentModel;
using KarveControls.ViewModels;
using KarveControls.HeaderedWindow;
using MasterModule;
using MasterModule.Common;
using System.Windows.Controls;
using DataAccessLayer.DataObjects;

namespace BookingModule.ViewModels
{
    /// <summary>
    ///  BookingInfoViewModel
    /// </summary>
    internal class BookingInfoViewModel : HeaderedLineViewModelBase<IBookingData, BookingDto, BookingItemsDto>
    {
        /// <summary>
        /// BookingInfoViewModel
        /// </summary>
        /// <param name="dataServices">Data Access Layer service facade</param>
        /// <param name="dialogServices">Dialog service instance.</param>
        /// <param name="manager">Event manager. It allows the communication between view models</param>
        /// <param name="regionManager">Region manager for working with regions.</param>
        /// <param name="controller">Request controller for dialog boxes</param>
        public BookingInfoViewModel(IDataServices dataServices,
            IDialogService dialogServices,
            IEventManager manager,
            IUnityContainer container,
            IRegionManager regionManager,
            IInteractionRequestController controller) : base(dataServices,
            dialogServices, manager, regionManager, dataServices.GetBookingDataService(), controller)
        {
            ViewModelUri = new Uri("karve://booking/viewmodel?id=" + Guid.ToString());
            InitViewModel();
            _container = container;
            _regionManager = regionManager;
            DefaultPageSize = 200;
            bookingClientsIncrementalList = new IncrementalList<ClientSummaryExtended>(LoadMoreClients);
            _clientHandler += LoadClientEvent;
            IsChanged = false;


        }
        /// <summary>
        ///  Command to show the fares
        /// </summary>
        public DelegateCommand<object> ShowFares { get; private set; }
        /// <summary>
        ///  Command to create a vehicle.
        /// </summary>
        public DelegateCommand<object> CreateVehicleCommand { get; private set; }
        /// <summary>
        ///  Command to show a client.
        /// </summary>
        public ICommand ShowClient { set; get; }
        /// <summary>
        ///  Command to create a client.
        /// </summary>
        public ICommand CreateClient { set; get; }
        /// <summary>
        ///  Compute the totals of the grid.
        /// </summary>
        /// <param name="aggregated">Values to be aggregated</param>
        /// <returns>A booking dto with the total due to the booking</returns>
        public override BookingDto ComputeTotals(BookingDto aggregated)
        {
            return aggregated;
        }
        /// <summary>
        /// Method called every time a component changes. 
        /// It handles the change and forward the change to the toolbar for saving.
        /// </summary>
        /// <param name="eventDictionary">Dictionary of events.</param>
        public void OnChangedField(object eventDictionary)
        {
            if (eventDictionary is IDictionary<string, object> eventData)
            {
                /*
                 * This part send directly to the toolbar any change that cames from the grid or the object
                 * independently.
                 */
                IsChanged = true;
                OnChangedCommand(DataObject,
                                       eventData,
                                       DataSubSystem.BookingSubsystem,
                                       EventSubSystemName,
                                       ViewModelUri.ToString());
            }
        }

        public IList<Type> ClearCollection<Type>(IEnumerable<Type> collection)
        {
            List<Type> t = new List<Type>();
            if (collection is IList<Type> clearable)
            {
                clearable.Clear();
                return clearable;
            }
            return t;
        }
        public void ClearCollections()
        {
            CityDto = ClearCollection(CityDto);
            ClientDto = ClearCollection(ClientDto);
            VehicleDto = ClearCollection(VehicleDto);
            BrokerDto = ClearCollection(BrokerDto);
            VehicleGroupDto = ClearCollection(VehicleGroupDto);
            ActiveFareDto = ClearCollection(ActiveFareDto);

        }
        /// <summary>
        ///  Method called when we close a tab. 
        ///  It should free all the object used in this view model.
        ///  Deregister the toolbar and any event handler.
        /// </summary>
        public override void DisposeEvents()
        {
            base.DisposeEvents();
            ClearList(DataObject);
            ClearCollections();
            var dataObject = DataObject;
            dataObject.ClearErrors();
            DataObject = dataObject;
            dataObject = null;
            UnregisterToolBar(PrimaryKeyValue, _newCommand, _saveCommand);
            EventManager.DeleteObserverSubSystem(BookingModule.BookingSubSystem, this);
            DeleteMailBox(ViewModelUri.ToString());
            DataPayLoad payload = new DataPayLoad();
            payload.ObjectPath = ViewModelUri;
            payload.PayloadType = DataPayLoad.Type.Dispose;
            EventManager.NotifyToolBar(payload);
        }

        /// <summary>
        ///     Data object for the reservation
        /// </summary>
        public BookingDto DataObject
        {
            set
            {
                _bookingDtoValue = value;
                RaisePropertyChanged();
            }
            get => _bookingDtoValue;
        }

        /// <summary>
        ///  Set or Get the ClientDto.
        /// </summary>
        public IEnumerable<ClientSummaryExtended> ClientDto
        {
            get { return _clientDto; }
            set
            {
                _clientDto = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        ///  Set or Get the CityDto.
        /// </summary>
        public IEnumerable<CityDto> CityDto
        {
            get
            {
                return _cityDto;
            }
            set
            {
                _cityDto = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        ///  Set or Get the VehicleDto.
        /// </summary>
        public IEnumerable<VehicleSummaryDto> VehicleDto
        {
            get
            {
                return _vehicle;
            }
            set
            {
                _vehicle = value;
            }
        }
        /// <summary>
        ///  Set or Get the BrokerDto.
        /// </summary>
        public IEnumerable<CommissionAgentSummaryDto> BrokerDto
        {
            get
            {
                return _brokers;
            }
            set
            {
                _brokers = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        ///  Set or Get the VehicleGroupDto
        /// </summary>
        public IEnumerable<VehicleGroupDto> VehicleGroupDto
        {
            get
            {
                return _vehicleGroup;
            }
            set
            {
                _vehicleGroup = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        ///  Set or Get the ActiveFareDto
        /// </summary>
        public IEnumerable<ActiveFareDto> ActiveFareDto
        {
            get
            {
                return _activeFareDto;
            }
            set
            {
                _activeFareDto = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        ///  Get or Set the Client dto.
        /// </summary>
        public IEnumerable<ContractByClientDto> ContractByClientDto
        {
            get
            {
                return _contractClientDto;
            }
            set
            {
                _contractClientDto = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        ///  Get or Set the driver dto.
        /// </summary>
        public IEnumerable<ClientSummaryExtended> DriverDto
        {
            get
            {
                return _drivers;
            }
            set
            {
                _drivers = value;
                RaisePropertyChanged();
            }
        }

        public ICommand OpenItemCommand { get; set; }
        public ICommand ShowDrivers { get; set; }
        public DelegateCommand<object> ShowClients { get; private set; }
        public ICommand ShowClientOrDrivers { get; set; }
        public DelegateCommand<object> ShowSingleDriver { get; private set; }
        public ICommand OtherDataShowCommand { get; set; }
        public ObservableCollection<CellPresenterItem> CellGridPresentation
        {
            get
            {
                return _cellGridPresentation;
            }
            set
            {
                _cellGridPresentation = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<OfficeDtos> ReservationOffice
        {
          get
            {
                return _reservationOffice;
            }
          set
            {
                _reservationOffice = new ObservableCollection<OfficeDtos>(value);
                RaisePropertyChanged();
            }
        }


        /// <summary>
        /// Load incrementally the clients related to the Grid
        /// </summary>
        /// <param name="sender">Task of the sender</param>
        /// <param name="e">Arguments to be used</param>
        private void LoadClientEvent(object sender, PropertyChangedEventArgs e)
        {
            if (sender is INotifyTaskCompletion<IEnumerable<ClientSummaryExtended>> clients)
            {
                bookingClientsIncrementalList.LoadItems(clients.Result);
            }

        }
        /// <summary>
        ///  This loads more client
        /// </summary>
        /// <param name="arg1">Count</param>
        /// <param name="arg2">StartIndex to load</param>
        private void LoadMoreClients(uint arg1, int arg2)
        {
            var clientData = DataServices.GetClientDataServices();
            NotifyTaskCompletion.Create(clientData.GetPagedSummaryDoAsync(arg2, DefaultPageSize), _clientHandler);

        }
        /// <summary>
        ///  Fetch the grid settings from the user 
        /// </summary>
        private void FetchGridsSettings()
        {
            if (_container != null)
            {
                _configurationService = _container.Resolve<IConfigurationService>();
                if (_configurationService != null)
                   {
                    _userSettings = _configurationService.GetUserSettings();
                    var columsSettings = _userSettings.FindSetting<string>(UserSettingConstants.BookingDriverGridColumnsKey);
                    GridColumns = TokenizeGridColumns(columsSettings);
                    var clientViewSettings = _userSettings.FindSetting<string>(UserSettingConstants.BookingClientGridColumnsKey);
                    _gridColumnsKey = clientViewSettings;
                    _gridDriverColumnsKey = columsSettings;
                }
            }
        }

        private List<string> TokenizeGridColumns(string cols)
        {
            var colSummary = cols.Split(',');
            var values = new List<string>();
            foreach (var currentValue in colSummary)
            {
                values.Add(currentValue.Trim());
            }
            return values;
        }
        /// <summary>
        /// Init the communication.
        /// </summary>
        private void InitCommunication()
        {
            EventSubSystemName = EventSubsystem.BookingSubsystemVm;
            MailBoxHandler += IncomingMailBox;
            RegisterMailBox(ViewModelUri.ToString());
            EventManager.RegisterObserverSubsystem(BookingModule.BookingSubSystem, this);

        }
        /// <summary>
        ///  Init the view model.
        /// </summary>
        private void InitViewModel()
        {
            InitCommunication();
            AssistCommand = new DelegateCommand<object>(OnAssistCommand);
            ItemChangedCommand = new DelegateCommand<object>(OnChangedField);
            OpenItemCommand = new DelegateCommand<object>(OpenCurrentItem);
            ShowDrivers = new DelegateCommand<object>(OnShowDrivers);
            ShowClients = new DelegateCommand<object>(ShowBookingClients);
            ShowSingleDriver = new DelegateCommand<object>(ShowBookingDriver);
            ShowClient = new DelegateCommand<object>(ShowCurrentClient);
            CreateClient = new DelegateCommand<object>(CreateNewClient);
            ShowFares = new DelegateCommand<object>(ShowClientFares);
            CreateVehicleCommand = new DelegateCommand<object>(CreateVehicle);

            _bookingDataService = DataServices.GetBookingDataService();
            OtherDataShowCommand = new DelegateCommand<object>(OtherDataShow);
            GridColumns = new List<string>()
            {
                "Desccon","Bill", "Included", "Quantity", "Price", "Subtotal", "Extra", "Iva","Days", "Unity"
            };
            var presenter = new ObservableCollection<CellPresenterItem>()
            {
                new NavigationAwareItem() { DataTemplateName="NavigateBookingConcept", MappingName="Desccon", RegionName=RegionNames.LineRegion},
                new NavigationAwareItem() { DataTemplateName="NavigateBookingUnit", MappingName="Unity", RegionName=RegionNames.LineRegion},
                 new NavigationAwareItem() { DataTemplateName="BookingInclude", MappingName="Included", RegionName=RegionNames.LineRegion},
                 new NavigationAwareItem() { DataTemplateName="BillToBookin",
                     MappingName ="Bill", RegionName=RegionNames.LineRegion},
            };
            _assistDataService = DataServices.GetAssistDataServices();
            AssistMapper = _assistDataService.Mapper;
            CellGridPresentation = presenter;
            _newCommand = new DelegateCommand<object>(NewViewCommand);
            _saveCommand = new DelegateCommand<object>(SaveViewCommand);
            FetchGridsSettings();
           // ReservationOffice = FetchOffices();
           // _deleteCommand = new DelegateCommand<o>
        }
        /// <summary>
        ///  This function fetch all the offices to be used in the collection.
        /// </summary>
        /// <returns></returns>
        private ObservableCollection<OfficeDtos> FetchOffices()
        {
            var collection = new ObservableCollection<OfficeDtos>();
            var helpers = DataServices.GetHelperDataServices();
            var office = NotifyTaskCompletion.Create<IEnumerable<OfficeDtos>>
                (helpers.GetMappedAllAsyncHelper<OfficeDtos, OFICINAS>(), (task, sender) =>
                {
                    if (task is INotifyTaskCompletion<IEnumerable<OfficeDtos>> result)
                    {
                        if (result.IsSuccessfullyCompleted)
                        {
                           collection = new ObservableCollection<OfficeDtos>(result.Result);
                        }
                    }
                });
            return collection;
        }
        private void SaveViewCommand(object obj)
        {

            _bookingData.Value = DataObject;
            NotifyTaskCompletion.Create<bool>(_bookingDataService.SaveAsync(_bookingData), (sender, ev) => {
                if (sender is INotifyTaskCompletion<bool> task)
                {
                    if ((task.IsSuccessfullyCompleted) && (task.Result == true))
                    {
                        DialogService?.ShowErrorMessage("Reservation saved with success!");
                        IsChanged = false;
                    }
                    else
                    {
                        DialogService?.ShowErrorMessage("Errro during saving reservation");
                    }
                }
            });
        }
    private void DeleteViewCommand(object obj)
    {
        var activeView = RegionManager.Regions[RegionNames.TabRegion].ActiveViews.FirstOrDefault();
        var viewDeleter = new ViewDeleter<IBookingData, BookingSummaryDto>(_bookingDataService, DialogService, EventManager);
        /// i shall check that i am on foreground
        if (activeView is UserControl control)
        {
            if (control.DataContext is KarveViewModelBase baseViewModel)
            {
                // its is me....
                if (baseViewModel.ViewModelUri == ViewModelUri)
                {
                        /*
                         *  Just to clarify. 
                         */
                        DataPayLoad payLoad = new DataPayLoad()
                        { DataObject = DataObject,
                            HasDataObject = true,
                            ObjectPath = ViewModelUri,
                            Sender = ViewModelUri.ToString(),
                            PayloadType = DataPayLoad.Type.UpdateView };

                        if (viewDeleter.DeleteView(payLoad))
                        {
                            /* 
                             * Since i have deleted with success 
                             * i notify my group and i unregister the //toolbar.
                             */
                            viewDeleter.Notify(ViewModelUri.ToString(), EventSubsystem.BookingSubsystemVm);
                            UnregisterToolBar(payLoad.PrimaryKeyValue);
                            DeleteRegion();
                        }

                }
            }
        }
    }
    private void NewViewCommand(object obj)
    {
        ViewFactory<BookingInfoView, BookingFooterView, IBookingData, BookingSummaryDto> viewFactory = new ViewFactory<BookingInfoView, BookingFooterView, IBookingData, BookingSummaryDto>(_regionManager, _container, EventManager, _bookingDataService, _bookingDataService);
        var activeView = RegionManager.Regions[RegionNames.TabRegion].ActiveViews.FirstOrDefault();
        /// i shall check that i am on foreground
        if (activeView is UserControl control)
        {
            if (control.DataContext is KarveViewModelBase baseViewModel)
            {
                // its is me....
                if (baseViewModel.ViewModelUri == ViewModelUri)
                {
                    viewFactory.NewItem("booking", DataSubSystem.BookingSubsystem, EventSubsystem.BookingSubsystemVm);

                }
            }
        }
    }

    private void ShowClientFares(object obj)
    {
        DialogService?.ShowErrorMessage("FareModule Not Implemeted");
    }

    private void CreateVehicle(object obj)
    {
        var vehicleRepository = DataServices.GetVehicleDataServices();
        var numberCode = vehicleRepository.NewId();
        var payLoad = vehicleRepository.GetNewDo(numberCode);
        if (payLoad == null)
        {
            DialogService?.ShowErrorMessage("Cannot navigate to a new vehicle");

        }
        var viewName = numberCode + "." + payLoad.Value.MARCA;
        var factory = DataPayloadFactory.GetInstance();
        var dataPayload = factory.BuildInsertPayLoadDo<IVehicleData>(viewName, payLoad, DataSubSystem.VehicleSubsystem, ViewModelUri.ToString());
        Navigate<MasterModule.ViewModels.VehicleInfoViewModel>(_regionManager, numberCode, viewName);
        EventManager.NotifyObserverSubsystem(MasterModuleConstants.VehiclesSystemName, dataPayload);

    }

    /// <summary>
    ///  Create new client.
    /// </summary>
    /// <param name="client"></param>
    private void CreateNewClient(object obj)
    {
        var clientDataService = DataServices.GetClientDataServices();
        var numberCode = clientDataService.GetNewId();
        var payload = clientDataService.GetNewDo(numberCode);
        var viewName = payload.Value.NOMBRE + "." + numberCode;
        var factory = DataPayloadFactory.GetInstance();
        var dataPayload = factory.BuildInsertPayLoadDo<IClientData>(viewName, payload, DataSubSystem.ClientSubsystem, ViewModelUri.ToString(), ViewModelUri.ToString(), ViewModelUri);
        Navigate<MasterModule.ViewModels.ClientsInfoViewModel>(_regionManager, numberCode, viewName);
        EventManager.NotifyObserverSubsystem(MasterModuleConstants.ClientSubSystemName, dataPayload);
    }
    /// <summary>
    ///  Show current client.
    /// </summary>
    /// <param name="clientNumber">Client Number</param>
    private async void ShowCurrentClient(object clientNumber)
    {
        if (clientNumber is string numberCode)
        {
            var clientDataSevice = DataServices.GetClientDataServices();
            var payload = await clientDataSevice.GetDoAsync(numberCode);
            var viewName = payload.Value.NOMBRE + "." + numberCode;
            var factory = DataPayloadFactory.GetInstance();
            var dataPayload = factory.BuildShowPayLoadDo<IClientData>(viewName, payload, DataSubSystem.ClientSubsystem, ViewModelUri.ToString(), ViewModelUri.ToString(), ViewModelUri);
            Navigate<MasterModule.ViewModels.ClientsInfoViewModel>(_regionManager, numberCode, viewName);
            EventManager.NotifyObserverSubsystem(MasterModuleConstants.ClientSubSystemName, dataPayload);
        }
    }
    private async void ShowBookingDriver(object obj)
    {
        _gridColumnsKey = "";
        await ShowBookingDriversOrClients(obj).ConfigureAwait(false);
        ShowDataTransferObjects<ClientSummaryExtended>(bookingClientsIncrementalList,
                                          "Conductores",
                                          _gridColumnsKey,
                                          (selectedItem) =>
                                          {
                                              if (selectedItem != null)
                                              {
                                                  DriverDto = DriverDto.Union(new List<ClientSummaryExtended>() { selectedItem });



                                              }
                                          });

        RaisePropertyChanged("DataHelper");
    }

    private void LoadMoreItems(uint index, uint baseIndex)
    {
        //  var clientData = DataServices.GetClientDataServices();
        //  NotifyTaskCompletion.Create(clientData.GetPagedSummaryDoAsync(index, DefaultPageSize), handler);
    }

    private async Task ShowBookingDriversOrClients(object obj)
    {
        var clientData = DataServices.GetClientDataServices();
        var pageCount = await clientData.GetPageCount(DefaultPageSize).ConfigureAwait(false);
        var maxCount = clientData.NumberItems;
        var firstData = await clientData.GetPagedSummaryDoAsync(1, 200).ConfigureAwait(false);
        bookingClientsIncrementalList = new IncrementalList<ClientSummaryExtended>(LoadMoreClients)
        { MaxItemCount = (int)maxCount };
        // configure the incremental loading just using lambda function now we can pass 
        // the first to the interaction controller
        bookingClientsIncrementalList.LoadItems(firstData);
    }
    private async void ShowContractByReservation(object obj)
    {
        var contractDataService = DataServices.GetContractDataServices();
        // i doubt that i will more than 1000 contacts.
        var contractByClient = await contractDataService.GetContractByClientAsync(DataObject.CLIENTE_RES1);
        /// This show uip  a magnifier updating the raise property changed,
        ShowDataTransferObjects<ContractByClientDto>(contractByClient, "Contractos per cliente", "Contract,DepartureDate, ForecastDeparture,ReturnDate,Days,Driver,Matricula,Brand,Model,Fare,InvoiceNumber,GrossInvoice", (selectedItem) =>
         {
             if (selectedItem != null)
             {
                 if (ContractByClientDto == null)
                 {
                     ContractByClientDto = new List<ContractByClientDto>();
                 }
                 ContractByClientDto.Union<ContractByClientDto>(new List<ContractByClientDto>() { selectedItem });
                 RaisePropertyChanged("DataHelper");
             }
         });
    }
    private async void ShowBookingClients(object obj)
    {
        await ShowBookingDriversOrClients(obj).ConfigureAwait(false);
        // we use the show data transfer object that is present in KarveViewModelBase
        // Basically it uses internally a prism interaction request showing up a modal 
        // window. As callback we use a lambda function so the code is concise and it shall
        // update the data object or the data helper when needed.
        // The load is always incremental.
        ShowDataTransferObjects<ClientSummaryExtended>(bookingClientsIncrementalList,
                                           "Clientes",
                                           _gridColumnsKey,
                                           (selectedItem) =>
                                           {
                                               if (selectedItem != null)
                                               {
                                                   if (ClientDto == null)
                                                   {
                                                       ClientDto = new List<ClientSummaryExtended>();
                                                   }
                                                   ClientDto.Union<ClientSummaryExtended>(new List<ClientSummaryExtended>() { selectedItem });

                                               }
                                           });
    }
    private void ClearList(BookingDto dto)
    {
        if (dto == null)
        {
          return;
        }
        if (dto.Items is IList<BookingItemsDto> list)
        {
            list.Clear();
        }

    }
    private void OtherDataShow(object obj)
    {
        var otherDataView = _container.Resolve<BookingDataView>();
        var detailsRegion = _regionManager.Regions[RegionNames.TabRegion];
        otherDataView.Header = "OtherData";
        _otherDataRegionManager = detailsRegion.Add(otherDataView, null, true);
        otherDataView.DataContext = this;
        otherDataView.Focus();
    }
    private void OnShowDrivers(object obj)
    {

        var driverView = _container.Resolve<BookingDrivers>();
        var detailsRegion = _regionManager.Regions[RegionNames.TabRegion];
        driverView.Header = "Conductores";
        _showDriversRegionManager = detailsRegion.Add(driverView, null, true);
        driverView.DataContext = this;
        driverView.Focus();
    }

    private void OpenCurrentItem(object obj)
    {
        // this shall be not happen here.
    }


    private void OnAssistCommand(object param)
    {
        IDictionary<string, string> values = (Dictionary<string, string>)param;
        string assistTableName = values.ContainsKey("AssistTable") ? values["AssistTable"] as string : null;
        string assistQuery = values.ContainsKey("AssistQuery") ? values["AssistQuery"] as string : null;
        this.AssistNotifierInitialized = NotifyTaskCompletion.Create<bool>(AssistQueryRequestHandler(assistTableName, assistQuery), (sender, ev) => {
        });
    }

    private async Task<bool> AssistQueryRequestHandler(string assistTableName, string assistQuery)
    {
        var assistContext = new Dictionary<string, object>()
            {
                {"query", assistQuery },
                { "clientCode", DataObject.CLIENTE_RES1 }
            };
        var collectionValue = await AssistMapper.ExecuteAssistGeneric(assistTableName, assistQuery);
        if (collectionValue == null)
        {
            return false;
        }
        switch (assistTableName)
        {
            case "CITY_ASSIST":
                {
                    CityDto = (IEnumerable<CityDto>)collectionValue;
                    break;
                }
            case "CLIENT_ASSIST":
                {

                    ClientDto = (IEnumerable<ClientSummaryExtended>)collectionValue;
                    break;
                }
            case "VEHICLE_ASSIST":
                {
                    VehicleDto = (IEnumerable<VehicleSummaryDto>)collectionValue;
                    break;
                }
            case "BROKER_ASSIST":
                {

                    BrokerDto = collectionValue as IEnumerable<CommissionAgentSummaryDto>;
                    break;
                }
            case "VEHICLE_GROUP_ASSIST":
                {
                    VehicleGroupDto = collectionValue as IEnumerable<VehicleGroupDto>;
                    break;
                }
            case "ACTIVE_FARE_ASSIST":
                {
                    ActiveFareDto = collectionValue as IEnumerable<ActiveFareDto>;
                    break;
                }
            case "CONTRACT_CLIENT_ASSIST":
                {
                    ContractByClientDto = collectionValue as IEnumerable<ContractByClientDto>;
                    break;
                }

            default:
                {
                    throw new ArgumentException("In the assist you neeed simply a valid tag");
                }

        }

        return true;
    }

    protected override string GetRouteName(string name)
    {
        return ViewModelUri.ToString();
    }


    /// <summary>
    ///  This delete asynchronously. 
    /// </summary>
    /// <param name="primaryKey">Value of the primary key.</param>
    /// <param name="subSystem">Kind of subsystem</param>
    /// <param name="eventSubSystem">Event subsystem</param>
    /// <returns></returns>
    private async Task<bool> DeleteAsync(string primaryKey, DataSubSystem subSystem, string eventSubSystem)
    {
        if (string.IsNullOrEmpty(primaryKey))
            throw new ArgumentNullException();
        var deleted = false;
        try
        {
            deleted = await _bookingDataService.DeleteAsync(_bookingData).ConfigureAwait(false);

        } catch (Exception e)
        {
            DialogService?.ShowErrorMessage(e.Message);
        }
        return deleted;
    }

    protected override void Init(string value, DataPayLoad payload, bool insertion)
    {
        if (!payload.HasDataObject) return;

        if (payload.PayloadType == DataPayLoad.Type.Insert)
        {
            if (payload.DataObject is IBookingData dataBooking)
            {
                _bookingData = dataBooking;
                _bookingData.ItemsDtos = new List<BookingItemsDto>();
                var dataObject = dataBooking.Value;
                dataObject.Items = new List<BookingItemsDto>();
                DataObject = dataObject;
            }
        }

        if (payload.DataObject is IBookingData data)
        {
            _bookingData = data;
            var dataObject = data.Value;
            dataObject.Items = data.ItemsDtos;
            DataObject = dataObject;
            PrimaryKeyValue = dataObject.NUMERO_RES;

            _dataItems = data.ItemsDtos;
            SourceView = new IncrementalList<BookingItemsDto>(LoadMoreItems) { MaxItemCount = data.ItemsDtos.Count() };
            var list = data.ItemsDtos.Take(DefaultPageSize);
            SourceView.LoadItems(list);
            RegisterToolBar();
            ActiveSubSystem();
        }

    }

    private void LoadMoreItems(uint arg1, int arg2)
    {
        var item = _dataItems.Skip(arg2).Take(100);
        SourceView.LoadItems(item);
    }

    protected override void SetRegistrationPayLoad(ref DataPayLoad payLoad)
    {
        if (payLoad == null)
        {
            payLoad = new DataPayLoad();
        }
        payLoad.Subsystem = DataSubSystem.BookingSubsystem;
        payLoad.PayloadType = DataPayLoad.Type.RegistrationPayload;
        payLoad.HasDataObject = false;
        payLoad.HasRelatedObject = false;
        payLoad.HasNewCommand = true;
        payLoad.NewCommand = _newCommand;
        payLoad.HasSaveCommand = true;
        payLoad.SaveCommand = _saveCommand;
        payLoad.ObjectPath = ViewModelUri;
        payLoad.Sender = ViewModelUri.ToString();
    }

    protected override async Task<bool> DeleteAsync(DataPayLoad payLoad)
    {
        var value = await _bookingDataService.GetDoAsync(payLoad.PrimaryKeyValue);
        if (!value.IsValid) return false;
        var retValue = await _bookingDataService.DeleteAsync(value);
        return retValue;
    }

    protected override void CleanUp(DataPayLoad payLoad, DataSubSystem subsystem, string eventSubsystem)
    {
        var pKey = payLoad.PrimaryKeyValue;
        payLoad.Subsystem = DataSubSystem.BookingSubsystem;
        payLoad.ObjectPath = ViewModelUri;
        base.DeleteItem(payLoad);
    }




    private IEnumerable<BookingItemsDto> _dataItems;
    private ObservableCollection<CellPresenterItem> _cellGridPresentation;
    private IRegionManager _otherDataRegionManager;
    private IRegionManager _showDriversRegionManager;
    private IConfigurationService _configurationService;
    private IUserSettings _userSettings;
    private string _gridColumnsKey;
    private string _gridDriverColumnsKey;
    private IBookingData _bookingData;
    private IEnumerable<ClientSummaryExtended> _clientDto;
    private IEnumerable<CityDto> _cityDto;
    private IEnumerable<VehicleSummaryDto> _vehicle;
    private IEnumerable<CommissionAgentSummaryDto> _brokers;
    private IEnumerable<VehicleGroupDto> _vehicleGroup;
    private IEnumerable<ActiveFareDto> _activeFareDto;
    private IEnumerable<ContractByClientDto> _contractClientDto;
    private IEnumerable<ClientSummaryExtended> _drivers;
    private BookingDto _bookingDtoValue;
    private IBookingDataService _bookingDataService;
  
    private readonly IUnityContainer _container;
    private readonly IRegionManager _regionManager;
    private IAssistDataService _assistDataService;
    private PropertyChangedEventHandler _clientHandler;
    private IncrementalList<ClientSummaryExtended> bookingClientsIncrementalList;
    private ICommand _newCommand;
    private DelegateCommand<object> _saveCommand;
    private ViewDeleter<IBookingData, BookingDto> _viewDeleter;
        private ObservableCollection<OfficeDtos> _reservationOffice;
    }
}
