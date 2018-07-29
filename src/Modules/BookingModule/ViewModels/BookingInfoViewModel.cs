using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Syncfusion.UI.Xaml.Grid;
using System.Collections.ObjectModel;
using Microsoft.Practices.Unity;
using BookingModule.Views;
using System.ComponentModel;
using MasterModule.Common;
using System.Windows.Controls;
using DataAccessLayer.DataObjects;
using System.Diagnostics.Contracts;
using Prism.Regions;
using Prism.Commands;
using KarveCommon.Generic;
using KarveCommon.Services;
using KarveCommonInterfaces;
using KarveDataServices;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;
using KarveControls.Behaviour.Grid;
using KarveControls.ViewModels;
using KarveCar.Navigation;
using SkyScanner.Services;
using System.Windows;
using KarveDataServices.Assist;

namespace BookingModule.ViewModels
{
    /// <summary>
    ///  BookingInfoViewModel. Single resposability to manage the BookingInfoView in a view first approach.
    /// </summary>
    internal partial class BookingInfoViewModel : HeaderedLineViewModelBase<IBookingData, BookingDto, BookingItemsDto>
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
           IKarveNavigator karveNavigator,
            IInteractionRequestController controller) : base(dataServices,
            dialogServices, manager, regionManager, dataServices.GetBookingDataService(), controller)
        {

            InitViewModel();
            _karveNavigator = karveNavigator;
            _container = container;
            _regionManager = regionManager;
            DefaultPageSize = 100;
            IsReady = false;

            // this shall be at the configuration service
            BrokerGridColumns = "Code,Name,Nif,Person,Zip,City,Province,Country,IATA,Company,OfficeZone,CurrentUser,LastModification";
            VehicleGridColumns = "Code,Brand,Model,Matricula,VehicleGroup,Situation,Office,Places,CubeMeters,Activity,Color,Owner,OwnerName,Policy,LeasingCompany,StartingDate,EndingDate,ClientNumber,Client,PurchaseInvoice,Frame,MotorNumber,Reference,KeyCode,StorageKey,User,Modification";
            ClientsConductor = "Code,Name,Nif,Phone,Movil,Email,Card,ReplacementCar,Zip,City,CreditCardType,NumberCreditCard, PaymentForm,AccountableAccount,Sector,Zona,Origin,Office,Falta,BirthDate,DrivingLicence";
            BookingInfoCols = "BudgetNumber,BudgetOffice,ClientName,GroupCode,BudgetCreationDate,DepartureDate,BookingNumber,BrokerName,Origin";
            _bookingClientsIncrementalList = new IncrementalList<ClientSummaryExtended>(LoadMoreClients);
            _clientHandler += LoadClientEvent;
            IsChanged = false;
            LineVisible = true;
            FooterVisible = false;
            _selectedIndex = 0;
            /* This instruct the toolbar to skip its is own handlers. Avoiding complexity. 
             * It will be just the view to save itself with composite command and to alert it subsystem.
             *  This with the SetRegistrationPayLoad set properly it will permit to save itself.
             *  Each view will save itself.
             */
            CompositeCommandOnly = true;
        }
        #region CommonProperties
        /// <summary>
        ///  Set or Get command for creating a new fare.
        /// </summary>
        public ICommand ShowFares { get; private set; }
        /// <summary>
        ///  Set or Get command for creating a new vehicle view.
        /// </summary>
        public ICommand CreateVehicleCommand { get; set; }
        /// <summary>
        /// Set or Get command for showing a client.
        /// </summary>
        public ICommand ShowClient { set; get; }
        /// <summary>
        ///  Set or Get command for creating a new client.
        /// </summary>
        public ICommand CreateClient { set; get; }

        /// <summary>
        /// Create a new fare.
        /// </summary>
        public ICommand CreateNewFare { get; set; }
        /// <summary>
        /// Create a new vehicle.
        /// </summary>
        public ICommand CreateNewVehicle { get; set; }
        /// <summary>
        ///  Create a new broker.
        /// </summary>
        public ICommand CreateNewBroker { set; get; }

        /// <summary>
        ///  Create a new group.
        /// </summary>
        public ICommand CreateNewGroup { set; get; }
        /// <summary>
        ///  Create a new driver
        /// </summary>
        public ICommand CreateNewDriver { get; set; }
        /// <summary>
        ///  Command for opening a new item
        /// </summary>
        public ICommand OpenItemCommand { get; set; }
        /// <summary>
        ///  Set or Get command
        /// </summary>
        public ICommand ShowDrivers { get; set; }
        /// <summary>
        ///  Set or Get the command for showing clients inside this view.
        /// </summary>
        public ICommand ShowClients { get; set; }
        /// <summary>
        ///  Set or Get the command for showing client or drivers inside this view.
        /// </summary>
        public ICommand ShowClientOrDrivers { get; set; }
        /// <summary>
        ///  Set or Get the command for showing a single driver inside this view.
        /// </summary>
        public ICommand ShowSingleDriver { get; private set; }
        /// <summary>
        /// Set or get the command for showing other data command inside this view.
        /// </summary>
        public ICommand OtherDataShowCommand { get; set; }
        /// <summary>
        ///  Create an amount command
        /// </summary>
        public ICommand AmountCommand { get; set; }
        /// <summary>
        ///  Create a recompute import.
        /// </summary>
        public ICommand RecomputeImport { get; set; }
        /// <summary>
        ///  Set or Get the command for looking up a flight
        /// </summary>
        public ICommand LookupFlightCommand { set; get; }
        /// <summary>
        ///  Set or Get the grid columns.
        /// </summary>
        public string VehicleGridColumns { set; get; }
        /// <summary>
        ///  Set or Get the grid columns.
        /// </summary>
        public string ClientsConductor { get; set; }
        /// <summary>
        /// Set or Get the columns
        /// </summary>
        public string BookingInfoCols { get; private set; }

        /// <summary>
        /// Set or Get the reservation office departure.
        /// </summary>
        public IEnumerable<OfficeDtos> ReservationOfficeDeparture
        {
            set
            {
                _reservationOfficeDeparture = value;
                RaisePropertyChanged();
            }
            get
            {
                return _reservationOfficeDeparture;
            }
        }
        /// <summary>
        /// Set or Get the reservation office departure.
        /// </summary>
        public IEnumerable<OfficeDtos> ReservationOfficeArrival
        {
            set
            {
                _reservationOfficeArrival = value;
                RaisePropertyChanged();
            }
            get
            {
                return _reservationOfficeArrival;
            }
        }
        /// <summary>
        ///  Set or get the templates list to configure dynamically the grid.
        /// </summary>
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
        /// <summary>
        ///  Set the reservation office collection for autocomplete the reservation
        /// </summary>
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
        ///  Set or Get the OfficeDto
        /// </summary>
        public IEnumerable<OfficeDtos> OfficeDto
        {
            get { return _officeDto; }
            set
            {
                _officeDto = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        ///  Set or get the budget dto.
        /// </summary>
        public IEnumerable<BudgetSummaryDto> BudgetDto
        {
            get
            {
                return _budgetDto;
            }
            set
            {
                _budgetDto = value;
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
                RaisePropertyChanged();
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
        /// Set or Get ExpireCardYear
        /// </summary>
        public string ExpireCardYear
        {
            get
            {
                return _driverCreditCardExpireYear;
            }
            set
            {
                _driverCreditCardExpireYear = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        ///  Set or Get ExpireCardMonth
        /// </summary>
        public string ExpireCardMonth
        {
            get
            {
                return _driverCreditCardExpireMonth;
            }
            set
            {
                _driverCreditCardExpireMonth = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        ///  Set or Get the ActiveFareDto
        /// </summary>
        public IEnumerable<FareDto> ActiveFareDto
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
        /// <summary>
        ///  The second driver.
        /// </summary>
        public IEnumerable<ClientSummaryExtended> DriverDto2
        {
            get
            {
                return _drivers2;
            }
            set
            {
                _drivers2 = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        ///  The second driver.
        /// </summary>
        public IEnumerable<ClientSummaryExtended> DriverDto3
        {
            get
            {
                return _drivers3;
            }
            set
            {
                _drivers3 = value;
                RaisePropertyChanged();
            }
        }
        // the third driver
        public IEnumerable<ClientSummaryExtended> DriverDto4
        {
            get
            {
                return _drivers4;
            }
            set
            {
                _drivers4 = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        ///  the forth driver.
        /// </summary>
        public IEnumerable<ClientSummaryExtended> DriverDto5
        {
            get
            {
                return _drivers5;
            }
            set
            {
                _drivers5 = value;
                RaisePropertyChanged();
            }
        }

        public void ReconfigureUri(Uri viewModelUri)
        {
            EventManager.DeleteMailBoxSubscription(viewModelUri.ToString());
            ViewModelUri = viewModelUri;
        }
        

        public ICommand ShowBookingConcept
        {
            get => _bookingConcept;
            set
            {
                _bookingConcept = value;
                RaisePropertyChanged();
            }
        }

        public ICommand AddNewBookingCommand
        {
            get
            {
                return _newBookingCommand;
            }
            set
            {
                _newBookingCommand = value;
                RaisePropertyChanged();
            }
        }


        /// <summary>
        ///  ConceptDto. 
        /// </summary>
        public IEnumerable<FareConceptDto> ConceptDto
        {
            get
            {
                return _concepts;
            }
            set
            {
                _concepts = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        /// Set or get a new fare. 
        /// </summary>
        public IEnumerable<FareDto> FareDto
        {
            get
            {
                return _fare;
            }
            set
            {
                _fare = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        public int SelectedIndex
        {
            set
            {
                _selectedIndex = value;
                if (_selectedIndex > 0)
                {
                    LineVisible = false;
                    FooterVisible = false;
                }
                else
                {
                    LineVisible = true;
                    FooterVisible = true;
                }
                RaisePropertyChanged();
            }
            get
            {
                return _selectedIndex;
            }
        }

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
            Contract.Requires(eventDictionary != null);
            if (OperationalState != DataPayLoad.Type.Raw)
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
                Contract.Ensures(IsChanged == true);
            }
        }
        /// <summary>
        ///  Method called when we close a tab. 
        ///  It should free all the object used in this view model.
        ///  Deregister the toolbar and any event handler.
        /// </summary>
        public override void DisposeEvents()
        {
            base.DisposeEvents();
            // First i would like to clear any collection that i expose;
            ClearList(DataObject);
            ClearCollections();

            ReservationOffice?.Clear();
            // Now i want to clear any error a propagate a cleared error data object to the binding.
            var dataObject = DataObject;
            dataObject?.ClearErrors();

            DataObject = dataObject;
            dataObject = null;
            // Now i want remove any communication with the view model and event manager.
            UnregisterToolBar(PrimaryKeyValue, _newCommand, _saveCommand);
            EventManager.DeleteObserverSubSystem(BookingModule.BookingSubSystem, this);
            if (ViewModelUri != null)
            {
                DeleteMailBox(ViewModelUri.ToString());
            }
            // Now i communicate the last time with the event manager to cleaning up its all resources assigned to me.
            DataPayLoad payload = new DataPayLoad();
            payload.ObjectPath = ViewModelUri;
            payload.PayloadType = DataPayLoad.Type.Dispose;
            EventManager.NotifyToolBar(payload);
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
                _bookingClientsIncrementalList.LoadItems(clients.Result);
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
            //    MailBoxHandler += IncomingMailBox;
            RegisterMailBox(ViewModelUri.ToString());
            EventManager.RegisterObserverSubsystem(BookingModule.BookingSubSystem, this);
        }


        private void InitCommands()
        {
            AssistCommand = new DelegateCommand<object>(OnAssistCommand);
            ItemChangedCommand = new DelegateCommand<object>(OnChangedField);
            ShowClients = new DelegateCommand<object>(ShowBookingClients);
            ShowSingleDriver = new DelegateCommand<object>(ShowBookingDriver);
            ShowClient = new DelegateCommand<object>(ShowCurrentClient);
            CreateClient = new DelegateCommand<object>(CreateNewClient);
            ShowFares = new DelegateCommand<object>(ShowClientFares);
            CreateVehicleCommand = new DelegateCommand<object>(CreateVehicle);
            LookupFlightCommand = new DelegateCommand<object>(OnLookupFlight);
            CreateNewFare = new DelegateCommand<object>(OnCreateNewFare);
            CreateNewVehicle = new DelegateCommand<object>(OnCreateNewVehicle);
            CreateNewBroker = new DelegateCommand<object>(OnCreateNewBroker);
            CreateNewGroup = new DelegateCommand<object>(OnCreateNewGroup);
            CreateNewDriver = new DelegateCommand<object>(CreateNewClient);
            AmountCommand = new DelegateCommand<object>(OnAmountCommand);
            RecomputeImport = new DelegateCommand(OnRecomputeImport);
            _newCommand = new DelegateCommand<object>(NewViewCommand);
            _saveCommand = new DelegateCommand<object>(SaveViewCommand);
            _deleteCommand = new DelegateCommand<object>(DeleteViewCommand);
            ShowBookingConcept = new DelegateCommand(OnShowConcepts);
            AddNewConceptCommand = new DelegateCommand(OnAddNewConcept);
        }

        private void OnAddNewConcept()
        {
            MessageBox.Show("Not yet implemented");
        }

        private void OnShowConcepts()
        {
            MessageBox.Show("Not yet implemented");

        }

        /// <summary>
        ///  Set or Get the credit card.
        /// </summary>
        public IEnumerable<CreditCardDto> CreditCardView
        {
            get
            {
                return _creditCardView;
            }
            set
            {
                _creditCardView = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        ///  Set or Get the country
        /// </summary>
        public IEnumerable<CountryDto> CountryDto
        {
            get
            {
                return _country;
            }
            set
            {
                _country = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        /// Set or Get thje country
        /// </summary>
        public IEnumerable<CountryDto> DriverCountryList
        {
            get
            {
                return _country2;
            }
            set
            {
                _country2 = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        ///  Set or Get the city
        /// </summary>
        public IEnumerable<CityDto> CityDto3
        {
            get
            {
                return _city;
            }
            set
            {
                _city = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        ///  Set or Get the country dto.
        /// </summary>
        public IEnumerable<CountryDto> CountryDto3
        {
            get
            {
                return _countryDto;
            }
            set
            {
                _countryDto = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        ///  Set or get the province.
        /// </summary>
        public IEnumerable<ProvinciaDto> ProvinceDto3
        {
            get
            {
                return _provinceDto;
            }
            set
            {
                _provinceDto = value;
                RaisePropertyChanged();
            }
        }
        private void OnCreateNewGroup(object obj)
        {
            MessageBox.Show("Cannot open a vehicle group");
        }

        private void OnRecomputeImport()
        {
        }
        private void OnAmountCommand(object obj)
        {
        }


        public string ExpireMonth
        {
            get { return _expirationMonth; }
            set
            {
                _expirationMonth = value;
                RaisePropertyChanged();
            }
        }

        
        private void InitServices()
        {
            // services.
            _bookingDataService = DataServices.GetBookingDataService();
            _assistDataService = DataServices.GetAssistDataServices();
        }
        private ObservableCollection<CellPresenterItem> InitGridColumns()
        {
            var presenter = new ObservableCollection<CellPresenterItem>()
            {
                new NavigationAwareItem() { DataTemplateName="NavigateBookingConcept", MappingName="Desccon", RegionName=RegionNames.LineRegion},
                 new NavigationAwareItem() { DataTemplateName="BookingInclude", MappingName="Included", RegionName=RegionNames.LineRegion},
                 new NavigationAwareItem() { DataTemplateName="BillToBookin",
                     MappingName ="Bill", RegionName=RegionNames.LineRegion},
            };
            return presenter;
        }
        
        /// <summary>
        ///  Init the view model.
        /// </summary>
        private void InitViewModel()
        {
          
            ViewModelUri = new Uri("karve://booking/viewmodel?id="+ Guid.ToString());
            InitCommunication();
            InitCommands();
            InitServices();
            CellGridPresentation = InitGridColumns();
            GeneralInfoCollection = CreateCollectionForOtherData();
            /* The columns names are coupled with data object properties.
             * The idea here is to get a subset of properties.
             */
            GridColumns = new List<string>()
            {
                "Desccon","Bill", "Included", "Quantity", "Price", "Subtotal", "Extra", "Iva","Days", "Unity"
            };
            /*
             *  This goes to a data template to configure directly the grid with its mapping.
             */
            
            AssistMapper = _assistDataService.Mapper;
    
            FetchGridsSettings();
            ReservationOffice = FetchOffices();
        }



        private void OnCreateNewBroker(object obj)
        {
            _karveNavigator.NewBrokerView(ViewModelUri);
        }

        private void OnCreateNewVehicle(object obj)
        {
            _karveNavigator.NewVehicleView(ViewModelUri);
        }

        private void OnCreateNewFare(object obj)
        {
            _karveNavigator.NewFareView(ViewModelUri);
        }

        private void OnLookupFlight(object obj)
        {
            System.Diagnostics.Process.Start("http://www.skyscanner.es");
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
        /// <summary>
        ///  Save data from the view.
        /// </summary>
        /// <param name="obj">Save data from the view command.</param>
        private void SaveViewCommand(object obj)
        {
            var activeView = RegionManager.Regions[RegionNames.TabRegion].ActiveViews.FirstOrDefault();
           
            _bookingData.Value = DataObject;
            NotifyTaskCompletion.Create<bool>(_bookingDataService.SaveAsync(_bookingData), (sender, ev) =>
            {
                if (sender is INotifyTaskCompletion<bool> task)
                {
                    if ((task.IsSuccessfullyCompleted) && (task.Result == true))
                    {
                        DialogService?.ShowErrorMessage("Reservation saved with success!");
                        IsChanged = false;
                        OperationalState = DataPayLoad.Type.Show;
                    }
                    else
                    {
                        DialogService?.ShowErrorMessage("Error during saving reservation :" + task.ErrorMessage);
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
                        _bookingData.Value = DataObject;
                        DataPayLoad payLoad = new DataPayLoad()
                        {
                            DataObject = _bookingData,
                            HasDataObject = true,
                            ObjectPath = ViewModelUri,
                            PrimaryKeyValue = PrimaryKeyValue,
                            Sender = ViewModelUri.ToString(),
                            PayloadType = DataPayLoad.Type.UpdateView
                        };

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
        /// <summary>
        ///  Generate a new view
        /// </summary>
        /// <param name="obj"></param>
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
                        viewFactory.NewItem(KarveLocale.Properties.Resources.lbooking, "karve://booking/viewmodel?id=", DataSubSystem.BookingSubsystem, BookingModule.BookingSubSystem);
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
            _bookingClientsIncrementalList = await ShowBookingDriversOrClients(obj).ConfigureAwait(false);
            ShowDataTransferObjects<ClientSummaryExtended>(_bookingClientsIncrementalList,
                                              "Conductores",
                                              _gridColumnsKey,
                                              (selectedItem) =>
                                              {
                                                  if (selectedItem != null)
                                                  {
                                                      DriverDto = DriverDto.Union(new List<ClientSummaryExtended>() { selectedItem });

                                                  }
                                              });
        }

        private void LoadMoreItems(uint index, uint baseIndex)
        {
            //  var clientData = DataServices.GetClientDataServices();
            //  NotifyTaskCompletion.Create(clientData.GetPagedSummaryDoAsync(index, DefaultPageSize), handler);
        }

        private async Task<IncrementalList<ClientSummaryExtended>> ShowBookingDriversOrClients(object obj)
        {
            var clientData = DataServices.GetClientDataServices();
            var pageCount = await clientData.GetPageCount(DefaultPageSize).ConfigureAwait(false);
            var maxCount = clientData.NumberItems;
            var firstData = await clientData.GetPagedSummaryDoAsync(1, 200).ConfigureAwait(false);
            _bookingClientsIncrementalList.Clear();
            _bookingClientsIncrementalList = new IncrementalList<ClientSummaryExtended>(LoadMoreClients)
            { MaxItemCount = (int)maxCount };
            // configure the incremental loading just using lambda function now we can pass 
            // the first to the interaction controller
            _bookingClientsIncrementalList.LoadItems(firstData);
            return _bookingClientsIncrementalList;
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
            _bookingClientsIncrementalList = await ShowBookingDriversOrClients(obj).ConfigureAwait(false);
            // we use the show data transfer object that is present in KarveViewModelBase
            // Basically it uses internally a prism interaction request showing up a modal 
            // window. As callback we use a lambda function so the code is concise and it shall
            // update the data object or the data helper when needed.
            // The load is always incremental.
            ShowDataTransferObjects<ClientSummaryExtended>(_bookingClientsIncrementalList,
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
                                                       ClientDto = ClientDto.Union<ClientSummaryExtended>(new List<ClientSummaryExtended>() { selectedItem });

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
            _bookingClientsIncrementalList.Clear();

        }


        /// <summary>
        ///  Get the name of the route.
        /// </summary>
        /// <param name="name">Name of the route</param>
        /// <returns></returns>
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

            }
            catch (Exception e)
            {
                DialogService?.ShowErrorMessage(e.Message);
            }
            return deleted;
        }
        /// <summary>
        /// Initalization state.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="payload">Kind of payload</param>
        /// <param name="insertion">If we want to insert or not</param>
        protected override void Init(string value, DataPayLoad payload, bool insertion)
        {
            Contract.Requires(payload != null);
            Contract.Requires(payload.DataObject != null, "Null Data Object");
            if (!payload.HasDataObject) return;
              

            if (payload.DataObject is IBookingData data)
            {
                _bookingData = data;
                switch (payload.PayloadType)
                {
                    case DataPayLoad.Type.Insert:
                        {
                           if (payload.Destination == null)
                            {
                                return;
                            }
                           if (payload.Destination != ViewModelUri)
                            {
                                return;
                            }
                           //it is me.
                            _bookingData.Value.Items = new List<BookingItemsDto>();
                            PrimaryKeyValue = payload.PrimaryKeyValue;
                            
                            break;
                        }
                    default:
                        {
                            var dataObject = data.Value;
                            PrimaryKeyValue = dataObject.NUMERO_RES;
                            SourceView = new IncrementalList<BookingItemsDto>((uint x, int y) => { }) { MaxItemCount = dataObject.Items.Count() };
                            
                            SourceView.LoadItems(dataObject.Items);
                            break;
                        }

                }
                GeneralInfoCollection = SetDataObject(data.Value, _generalInfoCollection);
                DataObject = data.Value;
                UpdateAux(data);
                // register the view model.
                ActiveSubSystem();
                OperationalState = payload.PayloadType;
                GeneralInfoCollection = _generalInfoCollection;
                IsReady = true;
            }
        }

        private void UpdateGenericCollection(IBookingData data)
        {
                var builder = GeneralInfoCollection;
                 builder[0].SourceView = data.OriginDto;
                builder[1].SourceView = data.BookingMediaDto;
                builder[2].SourceView = data.BookingTypeDto;
                builder[3].SourceView = data.AgencyEmployeeDto;
                builder[4].SourceView = data.ContactsDto1;
                builder[5].SourceView = data.PaymentFormDto;
                builder[6].SourceView = data.PrintingTypeDto;
                builder[7].SourceView = data.VehicleActivitiesDto;
                RaisePropertyChanged("GeneralCollectionInfo");



        }
        private void UpdateAux(IBookingData data)
        {
            UpdateGenericCollection(data);

            this.BookingAgencyEmployee = data.AgencyEmployeeDto;
            this.BookingContacts = data.ContactsDto1;
            this.BookingMedia = data.BookingMediaDto;
            this.BookingOrigen = data.OriginDto;
            this.BookingPaymentFormDto = data.PaymentFormDto;
            this.BookingType = data.BookingTypeDto;
            this.BookingVehicleActivity = data.VehicleActivitiesDto;
            this.BrokerDto = data.BrokerDto;
            this.BudgetDto = data.BookingBudget;
            this.ClientDto = data.Clients;
            this.DriverDto = data.DriverDto2;
            this.DriverDto2 = new ObservableCollection<ClientSummaryExtended>(data.DriverDto2);
            this.DriverDto3 = data.DriverDto3;
            this.DriverDto4 = data.DriverDto4;
            this.DriverDto5 = data.DriverDto5;
            this.CountryDto3 = data.CountryDto3;
            this.ProvinceDto3 = data.ProvinceDto3;
            this.CityDto3 = data.CityDto3;
          
           //  this.SecondDriverCountryDto = data.SecondDriverCountry;
          //  this.SecondDriverCityDto = data.SecondDriverCity;
          //  this.SecondDriverProvinceDto = data.SecondDriverProvince;
            this.ActiveFareDto = data.FareDto;
            this.OfficeDto = data.OfficeDto;
            this.BookingOrigen = data.OriginDto;
            this.VehicleDto = data.VehicleDto;
            this.VehicleGroupDto = data.VehicleGroupDto;
            this.ReservationOfficeArrival = data.ReservationOfficeArrival;
            this.ReservationOfficeDeparture = data.ReservationOfficeDeparture;
            
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
            payLoad.DeleteCommand = _deleteCommand;
            payLoad.HasDeleteCommand = true;
            payLoad.ObjectPath = ViewModelUri;
            payLoad.Sender = ViewModelUri.ToString();
        }

        protected override async Task<bool> DeleteAsync(DataPayLoad payLoad)
        {
            var value = await _bookingDataService.GetDoAsync(payLoad.PrimaryKeyValue).ConfigureAwait(false);
            if (!value.Valid) return false;
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

        #region Private Methods
        private void OnAssistCommand(object param)
        {
            Contract.Requires(param != null);
            bool notified = false;
            if (param == null)
            {
                return;
            }
            // it should not be happen that the parameter is not a dictionary.
            var values = param as Dictionary<string, string>;
            if (values != null)
            {
                string assistTableName = values.ContainsKey("AssistTable") ? values["AssistTable"] as string : null;
                string assistQuery = values.ContainsKey("AssistQuery") ? values["AssistQuery"] as string : null;
                //special case of booking contacts.
                if ((assistTableName == "BOOKING_CONTACTO_ASSIST") && (DataObject != null))
                {
                    // ok in this cse we use the client.
                    assistQuery = DataObject.CLIENTE_RES1;
                }
                this.AssistNotifierInitialized = NotifyTaskCompletion.Create<bool>(AssistQueryRequestHandler(assistTableName, assistQuery), (sender, ev) =>
                {
                    if (sender is INotifyTaskCompletion<bool> task)
                    {
                        notified = true;
                        if (task.IsFaulted)
                        {
                            DialogService?.ShowErrorMessage("Assist Failed for the following reason :" + task.ErrorMessage);
                        }
                    }
                });
            }
            Contract.Ensures(notified == true);
        }

        /// <summary>
        /// Request Handler for any searchbox available in the view. Each view can configure what 
        /// listen or now. The idea is to use the AssistDataservice which will expose an AssistMapper.
        /// The AssistMapper has the resposability to multiplex/demultiplex requests. A request
        /// might have a query but has an AssistTableName. The AssistTableName is just an identifier for 
        /// the searchbox query.
        /// </summary>
        /// <param name="assistTableName">Identifier for the searchbox query</param>
        /// <param name="assistQuery">A search box can configured with a default query so we need this parameter</param>
        /// <returns>True or False if there is a correct match in the assist service</returns>
        private async Task<bool> AssistQueryRequestHandler(string assistTableName, string assistQuery)
        {
            Contract.Requires(!string.IsNullOrEmpty(assistTableName));
            var collectionValue = await AssistMapper.ExecuteAssistGeneric(assistTableName, assistQuery).ConfigureAwait(false);
            var collection = GeneralInfoCollection;
            /* In the assist mapper we use the null object pattern provides 
             * a no-functional object in place of a null reference 
             * and therefore allows methods to be called on it
             */
            if (collectionValue is NullAssist)
            {
                DialogService?.ShowErrorMessage("Assist not configured in the system");
                return false;
            }
            if (collectionValue == null)
            {
                return false;
            }
            switch (assistTableName)
            {
                case "BOOKING_FCOBRO_ASSIST":
                    {
                       
                        var value = collection[5];
                        value.SourceView = collectionValue as IEnumerable<PaymentFormDto>;
                        
                        break;
                    }
                case "BOOKING_CONTRATIPIMPR_ASSIST":
                    {
                        collection[6].SourceView = collectionValue as IEnumerable<PrintingTypeDto>;
                        RaisePropertyChanged("GeneralCollectionInfo");
                        break;
                    }
                case "BOOKING_ACTIVEHI_RES1_ASSIST":
                    {
                        collection[7].SourceView = collectionValue as IEnumerable<VehicleActivitiesDto>;
                        RaisePropertyChanged("GeneralCollectionInfo");
                        break;
                    }
                case "BROKER_ASSIST":
                    {
                        BrokerDto = (IEnumerable<CommissionAgentSummaryDto>)collectionValue;
                        RaisePropertyChanged("GeneralCollectionInfo");
                        break;
                    }
                case "BOOKING_CONTACTO_ASSIST":
                    {
                        collection[4].SourceView  = collectionValue as IEnumerable<ContactsDto>;
                        RaisePropertyChanged("GeneralCollectionInfo");
                        break;
                    }
                case "BOOKING_ORIGIN_ASSIST":
                    {
                        collection[0].SourceView = collectionValue as IEnumerable<OrigenDto>;
                        RaisePropertyChanged("GeneralCollectionInfo");
                        break;
                    }
                case "BOOKING_MEDIO_ASSIST":
                    {
                        //collection[1].SourceView = null;

                        collection[1].SourceView = collectionValue as IEnumerable<BookingMediaDto>;
                        RaisePropertyChanged("GeneralCollectionInfo");

                        break;
                    }
                case "BOOKING_TYPE_ASSIST":
                    {
                        collection[2].SourceView = collectionValue as IEnumerable<BookingTypeDto>;
                        RaisePropertyChanged("GeneralCollectionInfo");
                        break;
                    }
                case "BUDGET_ASSIST":
                    {
                        BudgetDto = (IEnumerable<BudgetSummaryDto>)collectionValue;
                        break;
                    }
                case "CITY_ASSIST":
                    {
                        CityDto = (IEnumerable<CityDto>)collectionValue;
                        break;
                    }
                case "CITY_ASSIST_2":
                    {
                        SecondDriverCityDto = (IEnumerable<CityDto>)collectionValue;
                        break;
                    }
                case "CLIENT_ASSIST":
                    {

                        ClientDto = (IEnumerable<ClientSummaryExtended>)collectionValue;
                        break;
                    }
                case "CONTRACT_CLIENT_ASSIST":
                    {
                        ContractByClientDto = collectionValue as IEnumerable<ContractByClientDto>;
                        break;
                    }
                case "COUNTRY_ASSIST":
                    {
                        CountryDto = (IEnumerable<CountryDto>)collectionValue;
                        break;
                    }
                case "COUNTRY_ASSIST_2":
                    {
                        DriverCountryList = (IEnumerable<CountryDto>)collectionValue;
                        break;
                    }
                case "COUNTRY_ASSIST_3":
                    {
                        SecondDriverCountryDto = (IEnumerable<CountryDto>)collectionValue;
                        break;
                    }
                case "COUNTRY_ASSIST_4":
                    {
                        CountryDto4 = (IEnumerable<CountryDto>)collectionValue;
                        break;
                    }
                case "PAIS":
                    {
                        Country = (IEnumerable<CountryDto>)collectionValue;
                        break;
                    }
                case "CREDIT_CARD_ASSIST":
                    {
                        CreditCardView = (IEnumerable<CreditCardDto>)collectionValue;
                        break;
                    }
                case "CRM_PROVIDER_ASSIST":
                    {
                        CrmSupplierDto = (IEnumerable<SupplierSummaryDto>)collectionValue;
                        break;
                    }
                case "DRIVER_PROV":
                    {

                        ProvinceDto3 = (IEnumerable<ProvinciaDto>)collectionValue;
                        break;
                    }
                case "DRIVER_ASSIST_1":
                    {
                        DriverDto = (IEnumerable<ClientSummaryExtended>)collectionValue;
                        break;
                    }
                case "DRIVER_ASSIST_2":
                    {
                        DriverDto2 = (IEnumerable<ClientSummaryExtended>)collectionValue;
                        break;
                    }
                case "DRIVER_ASSIST_3":
                    {
                        DriverDto3 = (IEnumerable<ClientSummaryExtended>)collectionValue;
                        break;
                    }
                case "DRIVER_ASSIST_4":
                    {
                        DriverDto4 = (IEnumerable<ClientSummaryExtended>)collectionValue;
                        break;
                    }
                case "DRIVER_ASSIST_5":
                    {
                        DriverDto5 = (IEnumerable<ClientSummaryExtended>)collectionValue;
                        break;
                    }
                case "DRIVER_CITY":
                    {
                        CityDto3 = (IEnumerable<CityDto>)collectionValue;
                        break;
                    }
                case "DRIVER_COUNTRY":
                    {
                        CountryDto3 = (IEnumerable<CountryDto>)collectionValue;
                        break;
                    }
                case "FARE_ASSIST":
                    {
                        ActiveFareDto = (IEnumerable<FareDto>)collectionValue;
                        break;
                    }
                case "FARE_CONCEPT_ASSIST":
                    {
                        ConceptDto = (IEnumerable<FareConceptDto>)collectionValue;
                        break;
                    }
                case "EMPLEAGE_ASSIST":
                    {
                        BookingAgencyEmployee = collectionValue as IEnumerable<AgencyEmployeeDto>;
                        break;
                    }
                case "COMPANY_ASSIST":
                    {
                        CompanyDto = (IEnumerable<CompanyDto>) collectionValue;
                        break;
                    }
                case "OFICINA1":
                    {
                        ReservationOfficeDeparture = (IEnumerable<OfficeDtos>)collectionValue;
                        break;
                    }
                case "OFICINA2":
                    {
                        ReservationOfficeArrival = (IEnumerable<OfficeDtos>)collectionValue;
                        break;
                    }
                case "OFFICE_ASSIST":
                    {
                        OfficeDto = (IEnumerable<OfficeDtos>)collectionValue;
                        break;
                    }
                case "PROMOTION_ASSIST":
                    {
                        PromotionDto = (IEnumerable<PromotionCodesDto>)collectionValue;
                        break;
                    }
                case "PROVINCE_ASSIST_2":
                    {
                        SecondDriverProvinceDto = (IEnumerable<ProvinciaDto>)collectionValue;
                        break;
                    }
                case "VEHICLE_GROUP_ASSIST":
                    {
                        VehicleGroupDto = (IEnumerable<VehicleGroupDto>)collectionValue;
                        break;
                    }
                case "VEHICLE_ASSIST":
                    {
                        VehicleDto = (IEnumerable<VehicleSummaryDto>)collectionValue;
                        break;
                    }
                default:
                    {
                        throw new ArgumentException("In the assist you need simply a valid tag");
                    }
            }
            return true;
        }
        /// <summary>
        /// Clear any list collection given a type
        /// </summary>
        /// <typeparam name="Type">Data type to be cleaned</typeparam>
        /// <param name="collection">List to be cleaned.</param>
        /// <returns></returns>
        private IList<Type> ClearCollection<Type>(IEnumerable<Type> collection)
        {
            List<Type> t = new List<Type>();
            if (collection == null)
            {
                return t;
            }
            if (collection is IList<Type> clearable)
            {
                clearable.Clear();
                return clearable;
            }
            return t;
        }
        /// <summary>
        ///  Important method to clean all resources.
        /// </summary>
        private void ClearCollections()
        {
            Contract.Requires(CityDto != null);
            Contract.Requires(ClientDto != null);
            Contract.Requires(VehicleDto != null);
            Contract.Requires(BrokerDto != null);
            Contract.Requires(ActiveFareDto != null);
            Contract.Requires(VehicleGroupDto != null);
            CityDto = ClearCollection(CityDto);
            ClientDto = ClearCollection(ClientDto);
            VehicleDto = ClearCollection(VehicleDto);
            BrokerDto = ClearCollection(BrokerDto);
            VehicleGroupDto = ClearCollection(VehicleGroupDto);
            ActiveFareDto = ClearCollection(ActiveFareDto);
            Contract.Ensures(CityDto.Count() == 0);
            Contract.Ensures(ClientDto.Count() == 0);
            Contract.Ensures(VehicleDto.Count() == 0);
            Contract.Ensures(BrokerDto.Count() == 0);
            Contract.Ensures(VehicleGroupDto.Count() == 0);
            Contract.Ensures(ActiveFareDto.Count() == 0);
        }
        #endregion

        public string BrokerGridColumns { get; private set; }

        /// <summary>
        ///  Second driver city
        /// </summary>
        public IEnumerable<CityDto> SecondDriverCityDto
        {
            get { return _secondCityDriver; }
            set
            {
                _secondCityDriver = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<ProvinciaDto> SecondDriverProvinceDto
        {
            get { return _secondProvinceDriver; }
            set
            {
                _secondProvinceDriver = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<CountryDto> SecondDriverCountryDto
        {
            get
            {
                return _secondDriverCountry;
            }
            set
            {
                _secondDriverCountry = value;
                RaisePropertyChanged();
            }
        }
        public ICommand SaveToClient { set; get; }

        public IEnumerable<SupplierSummaryDto> CrmSupplierDto {
            get
            {
                return _crmSupplierDto;
            }
            set
            {
                _crmSupplierDto = value;
                RaisePropertyChanged();
            }
        }


     
        public IEnumerable<CountryDto> CountryDto4
        {
          get
          {
                return _countryDto4;
          }
          set
          {
                _countryDto4 = value;
                RaisePropertyChanged();
          }
        }

        public IEnumerable<PromotionCodesDto> PromotionDto
        {
            get { return _promotionDto;  }
            set { _promotionDto = value; RaisePropertyChanged(); }

        }

        public IEnumerable<CountryDto> Country
        {
            get {
                return _countryDto6;
            }
            set { _countryDto6 = value; RaisePropertyChanged();
            }
        }
        public IEnumerable<CompanyDto> CompanyDto
        {
            get => _company;

            set { _company = value; RaisePropertyChanged(); }
        }

        public ICommand CreateCommand { set; get; }
        public ICommand AddNewConceptCommand { set; get; }
        public ICommand RejectBooking { set; get; }
        public ICommand ConfirmBooking { set; get; }
        public ICommand IncidentLookup { set; get; }
        public ICommand CreateNewPromoCodeView { set; get; }
        public ICommand MailOffice { set; get; }
        public ICommand MailProforma { set; get; }
        public ICommand MailClient { set; get; }
        private ICommand _newCommand;
        private ICommand _bookingConcept;
        private ICommand _newBookingCommand;


        private IncrementalList<ClientSummaryExtended> _bookingClientsIncrementalList;
        private DelegateCommand<object> _saveCommand;
        private DelegateCommand<object> _deleteCommand;
        private ViewDeleter<IBookingData, BookingDto> _viewDeleter;
        private IKarveNavigator _karveNavigator;
        private ObservableCollection<OfficeDtos> _reservationOffice;
        private IEnumerable<CompanyDto> _company;
        private IEnumerable<BudgetSummaryDto> _budgetDto;
        private IEnumerable<FareConceptDto> _concepts;
        private IEnumerable<FareDto> _fare;
        private IEnumerable<VehicleSummaryDto> _vehicle;
        private IEnumerable<CityDto> _cityDto;
        private IEnumerable<CommissionAgentSummaryDto> _brokers;
        private IEnumerable<VehicleGroupDto> _vehicleGroup;
        private IEnumerable<FareDto> _activeFareDto;
        private IEnumerable<ContractByClientDto> _contractClientDto;
        private IEnumerable<ClientSummaryExtended> _clientDto;
        private IEnumerable<ClientSummaryExtended> _drivers;
        private IEnumerable<ClientSummaryExtended> _drivers2;
        private IEnumerable<ClientSummaryExtended> _drivers3;
        private IEnumerable<OfficeDtos> _officeDto;
        private IEnumerable<OfficeDtos> _reservationOfficeDeparture;
        private IEnumerable<OfficeDtos> _reservationOfficeArrival;
        private IEnumerable<CountryDto> _country;
        private IEnumerable<CityDto> _city;
        private IEnumerable<CountryDto> _countryDto;
        private IEnumerable<ProvinciaDto> _provinceDto;
        private IEnumerable<CountryDto> _country2;
        private IEnumerable<CreditCardDto> _creditCardView;
        private int _selectedIndex;
        private IEnumerable<ClientSummaryExtended> _drivers4;
        private IEnumerable<ClientSummaryExtended> _drivers5;
        private IEnumerable<CityDto> _secondCityDriver;
        private IEnumerable<ProvinciaDto> _secondProvinceDriver;
        private IEnumerable<CountryDto> _secondDriverCountry;
        private IEnumerable<BookingItemsDto> _dataItems;
        private ObservableCollection<CellPresenterItem> _cellGridPresentation;
        private IRegionManager _otherDataRegionManager;
        private IRegionManager _showDriversRegionManager;
        private IConfigurationService _configurationService;
        private IUserSettings _userSettings;
        private string _gridColumnsKey;
        private string _gridDriverColumnsKey;
        private IBookingData _bookingData;
        private BookingDto _bookingDtoValue;
        private IBookingDataService _bookingDataService;
        private readonly IUnityContainer _container;
        private readonly IRegionManager _regionManager;
        private IAssistDataService _assistDataService;
        private PropertyChangedEventHandler _clientHandler;
        private string _driverCreditCardExpireYear;
        private string _driverCreditCardExpireMonth;
        private IEnumerable<SupplierSummaryDto> _crmSupplierDto;
        private IEnumerable<CountryDto> _countryDto4;
        private IEnumerable<PromotionCodesDto> _promotionDto;
        private IEnumerable<CountryDto> _countryDto6;
        private IEnumerable<CompanyDto> _companyDto;
        private string _expirationMonth;
    }
}
