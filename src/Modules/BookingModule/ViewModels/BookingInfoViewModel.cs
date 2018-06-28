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

namespace BookingModule.ViewModels
{
    /// <summary>
    ///  BookingInfoViewModel
    /// </summary>
    internal class BookingInfoViewModel : HeaderedLineViewModelBase<IBookingData, BookingDto, BookingItemsDto>
    {

        private BookingDto _bookingDtoValue;
        private IBookingDataService _bookingDataService;
        private IEnumerable<BookingItemsDto> _dataSource;
        private readonly IUnityContainer _container;
        private readonly IRegionManager _regionManager;
        private IAssistDataService _assistDataService;
        private PropertyChangedEventHandler _clientHandler;
        private IncrementalList<ClientSummaryExtended> bookingClientsIncrementalList;


        /// <summary>
        /// BookingInfoViewModel
        /// </summary>
        /// <param name="dataServices"></param>
        /// <param name="dialogServices"></param>
        /// <param name="manager"></param>
        /// <param name="regionManager"></param>
        /// <param name="controller"></param>
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
        public ICommand ShowClient { set; get; }

        public ICommand CreateClient { set; get; }
        /// <summary>
        ///  Fetch the grid settings.
        /// </summary>
        private void FetchGridsSettigs()
        {
            _configurationService = _container.Resolve<IConfigurationService>();
            _userSettings = _configurationService.GetUserSettings();
            var columsSettings = _userSettings.FindSetting<string>(UserSettingConstants.BookingDriverGridColumnsKey);
            GridColumns =  TokenizeGridColumns(columsSettings);
        }

        List<string> TokenizeGridColumns(string cols)
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
            DataHelper = new BookingDataHelper();
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
        /// <param name="obj"></param>
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
        /// <param name="obj"></param>
        private async void ShowCurrentClient(object obj)
        {
            if (obj is string numberCode)
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
            await ShowBookingDriversOrClients(obj).ConfigureAwait(false);
            ShowDataTransferObjects<ClientSummaryExtended>(bookingClientsIncrementalList,
                                              "Conductores",
                                              _gridColumnsKey,
                                              (selectedItem) =>
                                              {
                                                  if (selectedItem != null)
                                                  {
                                                      DataHelper.DriverDto.Union(new List<ClientSummaryExtended>() { selectedItem });
                                                    

                                                      RaisePropertyChanged("DataHelper");
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
            ShowDataTransferObjects<ContractByClientDto>(contractByClient, "Contractos per cliente","Contract,DepartureDate, ForecastDeparture,ReturnDate,Days,Driver,Matricula,Brand,Model,Fare,InvoiceNumber,GrossInvoice", (selectedItem) => 
            {
                if (selectedItem!=null)
                {
                    if (DataHelper.ContractByClientDto == null)
                    {
                        DataHelper.ContractByClientDto = new List<ContractByClientDto>();
                    }
                    DataHelper.ContractByClientDto.Union<ContractByClientDto>(new List<ContractByClientDto>() { selectedItem });
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
                                                       if (DataHelper.ClientDto == null)
                                                       {
                                                           DataHelper.ClientDto = new List<ClientSummaryExtended>();
                                                       }
                                                       DataHelper.ClientDto.Union<ClientSummaryExtended>(new List<ClientSummaryExtended>() { selectedItem });
                                                       RaisePropertyChanged("DataHelper");
                                                   }
                                               });
        }
        public override void DisposeEvents()
        {
            base.DisposeEvents();
            EventManager.DeleteObserverSubSystem(BookingModule.BookingSubSystem, this);
            DeleteMailBox(ViewModelUri.ToString());
            DataPayLoad payload = new DataPayLoad();
            payload.ObjectPath = ViewModelUri;
            payload.PayloadType = DataPayLoad.Type.Dispose;
            EventManager.NotifyToolBar(payload);

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
            this.AssistNotifierInitialized = NotifyTaskCompletion.Create<bool>(AssistQueryRequestHandler(assistTableName, assistQuery), (sender, ev)=> {
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
                        DataHelper.CityDto = (IEnumerable<CityDto>)collectionValue;
                        break;
                    }
                case "CLIENT_ASSIST":
                    {

                        DataHelper.ClientDto = (IEnumerable<ClientSummaryExtended>)collectionValue;
                        break;
                    }
                case "VEHICLE_ASSIST":
                    {
                        DataHelper.VehicleDto = (IEnumerable<VehicleSummaryDto>)collectionValue;
                        break;
                    }
                case "BROKER_ASSIST":
                    {

                        DataHelper.BrokerDto = collectionValue as IEnumerable<CommissionAgentSummaryDto>;
                        break;
                    }
                case "VEHICLE_GROUP_ASSIST":
                    {
                        DataHelper.VehicleGroupDto = collectionValue as IEnumerable<VehicleGroupDto>;
                        break;
                    }
                case "ACTIVE_FARE_ASSIST":
                    {
                        DataHelper.ActiveFareDto = collectionValue as IEnumerable<ActiveFareDto>;
                        break;
                    }
                case "CONTRACT_CLIENT_ASSIST":
                    {
                        DataHelper.ContractByClientDto = collectionValue as IEnumerable<ContractByClientDto>;
                        break;
                    }
            
                default:
                    {
                        throw new ArgumentException("In the assist you neeed simply a valid tag");
                    }

            }
            RaisePropertyChanged("DataHelper");

            return true;
        }
        
        public void OnChangedField(object eventDictionary)
        {
            if (eventDictionary is IDictionary<string, object> eventData)
            {
               /*
                * This part send directly to the toolbar any change that cames from the grid or the object
                * independently.
                */
               OnChangedCommand(DataObject, 
                                      eventData, 
                                      DataSubSystem.BookingSubsystem, 
                                      EventSubSystemName, 
                                      ViewModelUri.ToString());
            }
        }
        protected override string GetRouteName(string name)
        {
            return ViewModelUri.ToString();
        }

        /// <summary>
        ///  This is the data helper that is used for the cross reference.
        ///  Theoretically we shall use just the dto but it is handy to have this.
        /// </summary>
        public BookingDataHelper DataHelper
        {

            set
            {
                _dataHelper = value;
                RaisePropertyChanged("DataHelper");
            }
            get
            {
                return _dataHelper;
            }
        }

        public DelegateCommand<object> ShowFares { get; private set; }
        public DelegateCommand<object> CreateVehicleCommand { get; private set; }

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
            if (payload.PayloadType==DataPayLoad.Type.Insert)
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
        /// <summary>
        ///  Compute the totals of the grid.
        /// </summary>
        /// <param name="aggregated">Values to be aggregated</param>
        /// <returns></returns>
        public override BookingDto ComputeTotals(BookingDto aggregated)
        {
            return aggregated;
        }

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

        private IEnumerable<BookingItemsDto> _dataItems;
        private ObservableCollection<CellPresenterItem> _cellGridPresentation;
        private IRegionManager _detailsRegionManager;
        private IRegionManager _otherDataRegionManager;
        private IRegionManager _showDriversRegionManager;
        private IConfigurationService _configurationService;
        private IUserSettings _userSettings;
        private string _gridColumnsKey;
        private string _gridDriverColumnsKey;
        private BookingDataHelper _dataHelper;
        private IBookingData _bookingData;
        public ICommand OpenItemCommand { get; set; }
     
        public ICommand ShowDrivers { get; set; }
        public DelegateCommand<object> ShowClients { get; private set; }
        public ICommand ShowClientOrDrivers { get; set; }
        public DelegateCommand<object> ShowSingleDriver { get; private set; }
        public ICommand OtherDataShowCommand { get; set; }
    }
}
