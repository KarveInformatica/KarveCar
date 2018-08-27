

namespace BookingModule.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;


    using global::BookingModule.Service;
    using global::BookingModule.Views;
    using DataAccessLayer.DataObjects;

    using KarveCar.Navigation;

    using KarveCommon.Generic;
    using KarveCommon.Services;

    using KarveCommonInterfaces;

    using KarveControls.Behaviour.Grid;
    using KarveControls.Interactivity.ViewModels;
    using KarveControls.Interactivity.Views;
    using KarveControls.ViewModels;

    using KarveDataServices;
    using KarveDataServices.Assist;
    using KarveDataServices.DataObjects;
    using KarveDataServices.ViewObjects;

    using MasterModule.Common;

    using Microsoft.Practices.Unity;

    using Prism.Commands;
    using Prism.Regions;

    using SkyScanner.Services;

    using Syncfusion.UI.Xaml.Grid;

    /// <summary>
    ///  BookingInfoViewModel. Single responsibility to manage the BookingInfoView in a view first approach.
    /// </summary>
    internal sealed partial class BookingInfoViewModel : HeaderedLineViewModelBase<IBookingData, BookingViewObject, BookingItemsViewObject>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookingInfoViewModel"/> class.
        /// </summary>
        /// <param name="dataServices">
        /// The data services. Services for retrieving data from the data access layer
        /// </param>
        /// <param name="dialogService">
        /// The dialog service. Service for showing up popup views.
        /// </param>
        /// <param name="manager">
        /// The Event Manager. Mediator for communicating between view models.
        /// </param>
        /// <param name="container">
        /// The Unity Container for Inversion of Control.
        /// </param>
        /// <param name="regionManager">
        /// The region manager for composite views and view navigation.
        /// </param>
        /// <param name="karveNavigator">
        /// The karve navigator. High level service for navigation.
        /// </param>
        /// <param name="configurationService">
        /// The configuration service. Service for retrieving application settings.
        /// </param>
        /// <param name="controller">
        /// The interaction controller is a service for triggering modal views.
        /// </param>
        /// <param name="service">
        /// The Booking Service for the business logic. It is a thin layer over the model.
        /// </param>
        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        public BookingInfoViewModel(
            IDataServices dataServices,
            IDialogService dialogService,
            IEventManager manager,
            IUnityContainer container,
            IRegionManager regionManager,
            IKarveNavigator karveNavigator,
            IConfigurationService configurationService,
            IInteractionRequestController controller,
            IBookingService service)
            : base(
                dataServices,
                dialogService,
                manager,
                regionManager,
                dataServices.GetBookingDataService(),
                controller)
        {
            _karveNavigator = karveNavigator;
            _container = container;
            _regionManager = regionManager;
            _configurationService = configurationService;
            _regionManager = regionManager;
            InitFlags(); 
            InitViewModel();
            SetGridColumns();
            CollectionView = new ObservableCollection<BookingItemsViewObject>();
            _bookingClientsIncrementalList = new IncrementalList<ClientSummaryExtended>(LoadMoreClients);
            _clientHandler += this.LoadClientEvent;
            CompositeCommandOnly = true;
            BookingConfirmMessage = new BookingConfirmMessageViewObject() { Code = "0006" };
            MailClientCommand = new DelegateCommand<object>(this.OnMailClient);
            LabelImageSource = new MemoryStream();
            _bookingService = service;
        }
        #region Properties
        /// <summary>
        /// Gets or sets the label image source.
        /// </summary>
        public MemoryStream LabelImageSource { get; set; }

        /// <summary>
        /// Gets or sets the create command.
        /// </summary>
        public ICommand CreateCommand { get; set; }

        /// <summary>
        /// Gets or sets the add new concept command.
        /// </summary>
        public ICommand AddNewConceptCommand { get; set; }

        /// <summary>
        /// Gets or sets the reject booking command.
        /// </summary>
        public ICommand RejectBooking { get; set; }

        /// <summary>
        /// Gets or sets the confirm booking command.
        /// </summary>
        public ICommand ConfirmBooking { get; set; }

        /// <summary>
        /// Gets or sets the incident lookup.
        /// </summary>
        public ICommand IncidentLookup { get; set; }

        /// <summary>
        /// Gets or sets the create new promo code view.
        /// </summary>
        public ICommand CreateNewPromoCodeViewCommand { get; set; }

        /// <summary>
        /// Gets or sets the mail office command.
        /// </summary>
        public ICommand MailOfficeCommand { get; set; }

        /// <summary>
        /// Gets or sets the mail proforma command.
        /// </summary>
        public ICommand MailProformaCommand { get; set; }

        /// <summary>
        /// Gets or sets the mail client command.
        /// </summary>
        public ICommand MailClientCommand { get; set; }

        /// <summary>
        /// Gets the broker grid columns.
        /// </summary>
        public string BrokerGridColumns { get; private set; }

        /// <summary>
        /// Gets or sets the second driver city dto.
        /// </summary>
        public IEnumerable<CityViewObject> SecondDriverCityDto
        {
            get { return _secondCityDriver; }
            set
            {
                _secondCityDriver = value;
                RaisePropertyChangeAfterInit("SecondDriverCityDto");
            }
        }

        /// <summary>
        /// Gets or sets the second driver province dto.
        /// </summary>
        public IEnumerable<ProvinceViewObject> SecondDriverProvinceDto
        {
            get { return _secondProvinceDriver; }
            set
            {
                _secondProvinceDriver = value;
                RaisePropertyChangeAfterInit("SecondDriverProvinceDto");
            }
        }
        public IEnumerable<CountryViewObject> SecondDriverCountryDto
        {
            get
            {
                return _secondDriverCountry;
            }

            set
            {
                _secondDriverCountry = value;
                RaisePropertyChangeAfterInit("SecondDriverCountryDto");
            }
        }
        public ICommand SaveToClient { get; set; }

        public IEnumerable<SupplierSummaryViewObject> CrmSupplierDto
        {
            get
            {
                return _crmSupplierDto;
            }

            set
            {
                _crmSupplierDto = value;
                RaisePropertyChangeAfterInit("CrmSupplierDto");
            }
        }


        public IEnumerable<CountryViewObject> CountryDto4
        {
            get
            {
                return _countryDto4;
            }

            set
            {
                _countryDto4 = value;
                RaisePropertyChangeAfterInit("CountryDto4");
            }
        }

        public IEnumerable<PromotionCodesViewObject> PromotionDto
        {
            get { return _promotionDto; }
            set { _promotionDto = value; RaisePropertyChangeAfterInit("PromotionDto"); }

        }

        public IEnumerable<CountryViewObject> Country
        {
            get
            {
                return _countryDto6;
            }

            set
            {
                _countryDto6 = value; RaisePropertyChangeAfterInit("Country");
            }
        }
        public IEnumerable<CompanyViewObject> BookingCompanyDto
        {
            get => _company;

            set { _company = value; RaisePropertyChangeAfterInit("BookingCompanyDto"); }
        }

        public IEnumerable<LanguageViewObject> LanguageDto
        {
            get
            {
                return _languageDto;
            }

            set
            {
                _languageDto = value;
                RaisePropertyChangeAfterInit("LanguageViewObject");
            }

        }


        /// <summary>
        ///  Set or Get the delivery places viewObject.
        /// </summary>
        public IEnumerable<DeliveringPlaceViewObject>
            DeliveringPlaceDto
        {
            get
            {
                return _deliveryPlace;
            }

            set
            {
                _deliveryPlace = value;
                RaisePropertyChangeAfterInit("DeliveryPlaceDto");
            }
        }
        // Set or Get the return place viewObject.
        public IEnumerable<DeliveringPlaceViewObject> PlaceReturnDto
        {
            get
            {
                return _returnPlaceDto;

            }

            set
            {
                _returnPlaceDto = value;
                RaisePropertyChangeAfterInit("PlaceReturnDto");
            }
        }
        /// <summary>
        ///  Set or Get the booking confirmation message.
        /// </summary>
        public IEnumerable<BookingConfirmMessageViewObject> BookingConfirmMessageDto
        {
            get
            {
                return _bookingConfirm;
            }

            set
            {
                _bookingConfirm = value;
                RaisePropertyChangeAfterInit("BookingConfirmMessageViewObject");
            }
        }

        public IEnumerable<BookingRefusedViewObject> BookingRefusedDto
        {
            get
            {
                return _bookingRefused;
            }

            set
            {
                _bookingRefused = value;
                RaisePropertyChangeAfterInit("BookingRefusedViewObject");
            }
        }
        #endregion

        #region CommonProperties

        /// <summary>
        /// Gets the show fares command for triggering a new show fare dialog.
        /// </summary>
        public ICommand ShowFares { get; private set; }

        /// <summary>
        /// Gets or sets the create vehicle command for creating a new vehicle view.
        /// </summary>
        public ICommand CreateVehicleCommand { get; set; }

        /// <summary>
        /// Gets or sets the show client for triggering a new client dialog.
        /// </summary>
        public ICommand ShowClient { get; set; }


        /// <summary>
        /// Gets or sets the create client command for creating a new client view.
        /// </summary>
        public ICommand CreateClient { get; set; }

        /// <summary>
        /// Gets or sets the create new fare.
        /// </summary>
        public ICommand CreateNewFare { get; set; }

        /// <summary>
        /// Gets or sets the create new vehicle command for creating a new vehicle view
        /// </summary>
        public ICommand CreateNewVehicle { get; set; }

        /// <summary>
        /// Gets or sets the create new broker for creating a new broker view.
        /// </summary>
        public ICommand CreateNewBroker { get; set; }

        /// <summary>
        /// Gets or sets the create new group.
        /// </summary>
        public ICommand CreateNewGroup { get; set; }

        /// <summary>
        /// Gets or sets the create new driver.
        /// </summary>
        public ICommand CreateNewDriver { get; set; }

        /// <summary>
        /// Gets or sets the open item command for opening a new reservation.
        /// </summary>
        public ICommand OpenItemCommand { get; set; }

        /// <summary>
        /// Gets or sets the show drivers command for showing a driver view.
        /// </summary>
        public ICommand ShowDrivers { get; set; }

        /// <summary>
        /// Gets or sets the included checked. This has been exposed to be able
        /// to recompute the totals in the grid. 
        /// </summary>
        public ICommand IncludedCheckedCommand {
            get
            {
               
                return _includedCheckCommand;
            }
            set
            {
                _includedCheckCommand = value;
                RaisePropertyChanged("IncludedCheckedCommand");
            }
        }
        
        /// <summary>
        /// Gets or sets the show clients.
        /// </summary>
        public ICommand ShowClients { get; set; }

        /// <summary>
        /// Gets or sets the show client or drivers.
        /// </summary>
        public ICommand ShowClientOrDrivers { get; set; }

        /// <summary>
        /// Gets the show single driver for opening a driver
        /// </summary>
        public ICommand ShowSingleDriver { get; private set; }

        /// <summary>
        /// Gets or sets the other for opening other data.
        /// </summary>
        public ICommand OtherDataShowCommand { get; set; }

        /// <summary>
        /// Gets or sets the amount command.
        /// </summary>
        public ICommand AmountCommand { get; set; }

        /// <summary>
        /// Gets or sets the recompute import.
        /// </summary>
        public ICommand RecomputeImport { get; set; }

        /// <summary>
        /// Gets or sets the lookup flight command.
        /// </summary>
        public ICommand LookupFlightCommand { get; set; }

        /// <summary>
        /// Gets or sets the vehicle grid columns.
        /// </summary>
        public string VehicleGridColumns { get; set; }

        /// <summary>
        /// Gets or sets the clients conductor.
        /// </summary>
        public string ClientsConductor { get; set; }

        /// <summary>
        /// Gets or sets the booking info cols.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        public string BookingInfoCols
        {
            get => _bookingCols;
           
            set
            {
                _bookingCols = value;
                RaisePropertyChanged("BookingInfoCols");
            }
        }

        /// <summary>
        /// Gets or sets the collection view.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        public ObservableCollection<BookingItemsViewObject> CollectionView
        {
            get => _collectionView;
            set
            {
                this._collectionView = value;
                //DataObject.Items = value;
               // ComputeTotals(DataObject);
                this.RaisePropertyChanged("CollectionView");
            }
        }

        /// <summary>
        /// Gets or sets the reservation office departure.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        public IEnumerable<OfficeViewObject> ReservationOfficeDeparture
        {
            get => _reservationOfficeDeparture;
            set
            {
                this._reservationOfficeDeparture = value;
                this.RaisePropertyChangeAfterInit("ReservationOfficeDeparture");
            }
        }

        /// <summary>
        /// Gets or sets the reservation office arrival.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        public IEnumerable<OfficeViewObject> ReservationOfficeArrival
        {
            get => _reservationOfficeArrival;
            set
            {
                this._reservationOfficeArrival = value;
                this.RaisePropertyChangeAfterInit("ReservationOfficeArrival");
            }
        }

        /// <summary>
        /// Gets or sets the cell grid presentation template.
        /// The line grid can be configured with data templates.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        public ObservableCollection<CellPresenterItem> CellGridPresentation
        {
            get => _cellGridPresentation;
            set
            {
                _cellGridPresentation = value;
                RaisePropertyChanged("CellGridPresentation");

            }
        }

        /// <summary>
        /// Gets or sets the reservation office collection for the search box.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly", Justification = "Reviewed. Suppression is OK here.")]

        public ObservableCollection<OfficeViewObject> ReservationOffice
        {
            get => _reservationOffice;
            set
            {
                _reservationOffice = new ObservableCollection<OfficeViewObject>(value);
                RaisePropertyChangeAfterInit("ReservationOffice");
            }
        }

        /// <summary>
        /// Gets or sets the data object. The data object is a actually a data object view,
        /// it does view asynchronous validation using INotifyDataError interface.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly", Justification = "Reviewed. Suppression is OK here.")]

        public BookingViewObject DataObject
        {
            get => _bookingViewObjectValue;
            set
            {
                this._previousBookingData = this._bookingViewObjectValue;
                this._bookingViewObjectValue = value;
                this.RaisePropertyChanged("DataObject");
            }
        }

        /// <summary>
        /// Gets or sets the client collection to be shown in the search box client.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly", Justification = "Reviewed. Suppression is OK here.")]

        public IEnumerable<ClientSummaryExtended> ClientDto
        {
            get => _clientDto;
            set
            {
                _clientDto = value;
                RaisePropertyChangeAfterInit("ClientDto");
            }
        }

        /// <summary>
        /// Gets or sets the booking office dto.
        /// </summary>
        public IEnumerable<OfficeViewObject> BookingOfficeDto
        {
            get => _bookingData.OfficeDto;
            set
            {
                _bookingData.OfficeDto = value;
                RaisePropertyChangeAfterInit("BookingOfficeDto");
            }
        }
        /// <summary>
        ///  Set or get the budget viewObject.
        /// </summary>
        public IEnumerable<BudgetSummaryViewObject> BudgetDto
        {
            get => _budgetDto;
            set
            {
                _budgetDto = value;
                RaisePropertyChangeAfterInit("BudgetDto");
            }
        }

        /// <summary>
        ///  Set or Get the CityViewObject.
        /// </summary>
        public IEnumerable<CityViewObject> CityDto
        {
            get => _cityDto;
            set
            {
                _cityDto = value;
                RaisePropertyChangeAfterInit("CityDto");
            }
        }
        /// <summary>
        ///  Set or Get the VehicleViewObject.
        /// </summary>
        public IEnumerable<VehicleSummaryViewObject> VehicleDto
        {
            get => _vehicle;
            set
            {
                _vehicle = value;
                RaisePropertyChangeAfterInit();
            }
        }

        public ICommand ShowNewBooking { get; set; }

        /// <summary>
        ///  Set or Get the BrokerViewObject.
        /// </summary>
        public IEnumerable<CommissionAgentSummaryViewObject> BrokerDto
        {
            get => _brokers;
            set
            {
                _brokers = value;
                RaisePropertyChangeAfterInit("BrokerDto");
            }
        }
        /// <summary>
        ///  Set or Get the VehicleGroupViewObject
        /// </summary>
        public IEnumerable<VehicleGroupViewObject> VehicleGroupDto
        {
            get => _vehicleGroup;
            set
            {
                _vehicleGroup = value;
                RaisePropertyChangeAfterInit("VehicleGroupDto");
            }
        }
        /// <summary>
        /// Set or Get ExpireCardYear
        /// </summary>
        public string ExpireCardYear
        {
            get => _driverCreditCardExpireYear;
            set
            {
                _driverCreditCardExpireYear = value;
                RaisePropertyChanged("ExpireCardYear");
            }
        }
        /// <summary>
        ///  Set or Get ExpireCardMonth
        /// </summary>
        public string ExpireCardMonth
        {
            get => _driverCreditCardExpireMonth;
            set
            {
                _driverCreditCardExpireMonth = value;
                RaisePropertyChanged("ExpireCardMonth");
            }
        }
        /// <summary>
        ///  Set or Get the ActiveFareViewObject
        /// </summary>
        public IEnumerable<FareViewObject> ActiveFareDto
        {
            get => _activeFareDto;
            set
            {
                _activeFareDto = value;
                RaisePropertyChanged("ActiveFareDto");
            }
        }
        /// <summary>
        ///  Get or Set the Client viewObject.
        /// </summary>
        public IEnumerable<ContractByClientViewObject> ContractByClientDto
        {
            get => _contractClientDto;
            set
            {
                _contractClientDto = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        ///  Get or Set the driver viewObject.
        /// </summary>
        public IEnumerable<ClientSummaryExtended> DriverDto
        {
            get => _drivers;
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
            get => _drivers2;
            set
            {
                _drivers2 = value;
                RaisePropertyChangeAfterInit("DriverDto2");
            }
        }
        /// <summary>
        ///  The second driver.
        /// </summary>
        public IEnumerable<ClientSummaryExtended> DriverDto3
        {
            get => _drivers3;
            set
            {
                _drivers3 = value;
                RaisePropertyChangeAfterInit("DriverDto3");
            }
        }
       
        public IEnumerable<ClientSummaryExtended> DriverDto4
        {
            get => _drivers4;
            set
            {
                _drivers4 = value;
                RaisePropertyChangeAfterInit("DriverDto4");
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
                RaisePropertyChangeAfterInit("DriverDto5");
            }
        }

        public void ReconfigureUri(Uri viewModelUri)
        {
            EventManager.DeleteMailBoxSubscription(viewModelUri.ToString());
            ViewModelUri = viewModelUri;
        }

        public int SelectedIndex
        {
            get
            {
                return _selectedIndex;
            }

            set
            {
                this._selectedIndex = value;
                if (this._selectedIndex > 0)
                {
                    this.LineVisible = false;
                    this.FooterVisible = false;
                }
                else
                {
                    this.LineVisible = true;
                    this.FooterVisible = true;
                }

                this.RaisePropertyChanged();
            }
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

        public bool IsReservationCancelled
        {
            get
            {
                return _isReservationCancelled;
            }

            set
            {
                this._isReservationCancelled = value;
                this.RaisePropertyChanged("IsReservationCancelled");
            }
        }

        /// <summary>
        ///  ConceptDto. 
        /// </summary>
        public IEnumerable<FareConceptViewObject> ConceptDto
        {
            get
            {
                return _concepts;
            }

            set
            {
                _concepts = value;
                RaisePropertyChangeAfterInit("ConceptDto");
            }
        }
        /// <summary>
        /// Set or get a new fare. 
        /// </summary>
        public IEnumerable<FareViewObject> FareDto
        {
            get
            {
                return _fare;
            }

            set
            {
                _fare = value;
                RaisePropertyChanged("FareDto");
            }
        }

        #endregion

        /// <summary>
        ///  Compute the totals of the grid. This shall be moved to the business layer.
        /// </summary>
        /// <param name="aggregated">Values to be aggregated</param>
        /// <returns>A booking viewObject with the total due to the booking</returns>
        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        public override BookingViewObject ComputeTotals(BookingViewObject aggregated)
        {
          
            if (aggregated == null)
            {
                throw new ArgumentNullException(nameof(aggregated));
            }

            if (CollectionView == null)
            {
                return aggregated;
            }

            if (CollectionView.Any())
            {
                decimal subTotal = 0;
                foreach (var x in CollectionView)
                {
                    if (x.Included)
                    {
                        if (x.Subtotal.HasValue)
                        {
                            subTotal += x.Subtotal.Value;
                        }
                    }
                }

                /**
                 * Here we use Bankers Rounding, an algorithm for rounding quantities to integers, 
                 * in which numbers which are equidistant from the two nearest integers 
                 * are rounded to the nearest even integer. 
                 * Thus, 0.5 rounds down to 0; 1.5 rounds up to 2. 
                 * A similar algorithm can be constructed for rounding to other sets 
                 * besides the integers (in particular, sets which a constant interval between adjacent members). 
                 * Other decimal fractions round as you would expect--0.4 to 0, 0.6 to 1, 1.4 to 1, 1.6 to 2, etc. 
                 * Only x.5 numbers get the "special" treatment. So called because banks supposedly use it for certain computations. 
                 * The supposed advantage to bankers rounding is that it is unbiased, and thus produces better results with various operations that involve rounding. 
                 * It should be noted that it is unbiased only in the limit. That is, an average of all errors approaches 0.0.
                 */
                var tmp = DataObject;
                subTotal = decimal.Round(subTotal, 2, MidpointRounding.AwayFromZero);
                tmp.BASEI_RES2 = subTotal;              
                var computeIva = subTotal * 21 * (decimal)0.01;
                tmp.IVA_RES2 = decimal.Round(computeIva, 2, MidpointRounding.AwayFromZero);
                var total = subTotal + computeIva;
                tmp.TOLON_RES2 = decimal.Round(total, 2, MidpointRounding.AwayFromZero);
                DataObject = tmp;

            }
            else
            {
                var tmp = DataObject;
                tmp.BASEI_RES2 = 0;
                tmp.IVA_RES2 = 0;
                tmp.TOLON_RES2 = 0;
                DataObject = tmp;
            }

            return DataObject;
        }


        /// <summary>
        /// Method called every time a component changes. 
        /// It handles the change and forward the change to the toolbar for saving.
        /// </summary>
        /// <param name="eventDictionary">Dictionary of events.</param>
        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly", Justification = "Reviewed. Suppression is OK here.")]
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
                    if (IsViewModelInitialized)
                    {
                        IsChanged = true;
                        if (IsGridChanged(eventData))
                        {
                            UpdateObject(DataObject, eventData, CollectionView);
                            ComputeTotals(DataObject);
                        }

                        OnChangedCommand(
                            DataObject,
                            eventData,
                            DataSubSystem.BookingSubsystem,
                            EventSubSystemName,
                            ViewModelUri.ToString());

                        CheckBusinessRules(eventData, this._bookingData);
                    }

                    // here i shall check if oficna is changed.
                }

                Contract.Ensures(IsChanged == true);
            }
        }

        /// <summary>
        /// The check business rules.
        /// </summary>
        /// <param name="eventData">
        /// The event data.
        /// </param>
        /// <param name="bookingData">
        /// The booking data.
        /// </param>
        private void CheckBusinessRules(IDictionary<string, object> eventData, IBookingData bookingData)
        {
            this._bookingData.Value = this.DataObject;

            NotifyTaskCompletion.Create(
                this._bookingService.IsChangeTriggered(eventData, this._bookingData),
                (result, ev) =>
                    {
                        if (!(result is INotifyTaskCompletion<bool> taskResult))
                        {
                            return;
                        }

                        if (taskResult.IsFaulted)
                        {
                            this.DialogService?.ShowErrorMessage("Error retrieving company:" + taskResult.ErrorMessage);
                        }


                        if (taskResult.IsSuccessfullyCompleted && taskResult.Result)
                        {
                            this.DataObject = this._bookingData.Value;
                            this.BookingCompanyDto = this._bookingData.CompanyDto;
                        }
                    });
        }

        /// <summary>
        /// The fetch office by company async.
        /// </summary>
        /// <param name="eventData">
        /// The event data.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        /// 
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
            // Now i want remove any communication with the view model and event manager and toolbar
            UnregisterToolBar(PrimaryKeyValue, _newCommand, _saveCommand, _deleteCommand);
            EventManager.DeleteObserverSubSystem(BookingModule.BookingSubSystem, this);
            if (ViewModelUri != null)
            {
                DeleteMailBox(ViewModelUri.ToString());
            }

            // Now i communicate the last time with the event manager to cleaning up its all resources assigned to me.
            var payload = new DataPayLoad
            {
                ObjectPath = ViewModelUri,
                PayloadType = DataPayLoad.Type.Dispose
            };
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
                    _userSettings = _configurationService.UserSettings;
                    var columnsSettings = _userSettings.FindSetting<string>(UserSettingConstants.BookingDriverGridColumnsKey);
                //    GridColumns = TokenizeGridColumns(columnsSettings);
                    var clientViewSettings = _userSettings.FindSetting<string>(UserSettingConstants.BookingClientGridColumnsKey);
                    _gridColumnsKey = clientViewSettings;
                    _gridDriverColumnsKey = columnsSettings;
                }
            }
        }

        

        private List<string> TokenizeGridColumns(string cols)
        {
            var colSummary = cols.Split(',');
            return colSummary.Select(currentValue => currentValue.Trim()).ToList();
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

        /// <summary>
        /// Initialize the commands to be exposed to the view.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        private void InitCommands()
        {
            _newCommand = new DelegateCommand<object>(NewViewCommand);
            _saveCommand = new DelegateCommand<object>(SaveViewCommand, CanSave);
            _deleteCommand = new DelegateCommand<object>(DeleteViewCommand);
            AddNewConceptCommand = new DelegateCommand(OnAddNewConcept);
            AssistCommand = new DelegateCommand<object>(OnAssistCommand);
            AmountCommand = new DelegateCommand<object>(OnAmountCommand);
            this.CreateClient = new DelegateCommand<object>(OnCreateNewClient);
            CreateNewBroker = new DelegateCommand<object>(OnCreateNewBroker);
            CreateNewDriver = new DelegateCommand<object>(OnCreateNewClient);
            CreateNewFare = new DelegateCommand<object>(OnCreateNewFare);
            CreateNewGroup = new DelegateCommand<object>(OnCreateNewGroup);
            CreateNewVehicle = new DelegateCommand<object>(OnCreateNewVehicle);
            CreateVehicleCommand = new DelegateCommand<object>(CreateVehicle);
            ConfirmBooking = new DelegateCommand<object>(OnConfirmBooking);
            LookupFlightCommand = new DelegateCommand<object>(OnLookupFlight);
            IncidentLookup = new DelegateCommand<object>(OnBookingIncident);
            ItemChangedCommand = new DelegateCommand<object>(OnChangedField);
            PrintCommand = new DelegateCommand(OnPrintCommand);
            RecomputeImport = new DelegateCommand(OnRecomputeImport);
            RejectBooking = new DelegateCommand(OnRejectBooking);
            SaveToClient = new DelegateCommand<BookingViewObject>(OnExecuteSaveClient);
            ShowBookingConcept = new DelegateCommand<object>(OnShowConcepts);
            ShowClients = new DelegateCommand<object>(ShowBookingClients);
            ShowClient = new DelegateCommand<object>(ShowCurrentClient);
            ShowFares = new DelegateCommand<object>(ShowClientFares);
            ShowNewBooking = new DelegateCommand(OnShowNewBooking);
            ShowSingleDriver = new DelegateCommand<object>(ShowBookingDriver);
            IncludedCheckedCommand = new DelegateCommand<object>(OnCheckedChange);
        }

        /// <summary>
        /// The on checked change.
        /// </summary>
        /// <param name="obj">
        /// 
        /// </param>
        private void OnCheckedChange(object obj)
        {
            DataObject = ComputeTotals(DataObject);
        }

        private void OnRejectBooking()
        {
            throw new NotImplementedException();
        }

        private void OnConfirmBooking(object obj)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Function to print a pdf.
        /// </summary>
        private void OnPrintCommand()
        {
            var pdfCreation = new BookingPdfCreator(DataObject, LabelImageSource);
            var ms = pdfCreation.CreatePdf();
            var interaction = new InteractionReportViewModel {Document = ms, Title = "Impresion de Rotulo"};
         
            Controller.ShowView<InteractionReportViewModel, ReportView>(interaction);
        }

        /// <summary>
        /// The on booking incident.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        private async void OnBookingIncident(object obj)
        {
            var viewObject = obj as BookingViewObject;
            var clientData = DataServices.GetClientDataServices();
            var conductor = await clientData.GetDoAsync(viewObject.CONDUCTOR_RES1).ConfigureAwait(false);
            var conductorName = conductor.Value.NOMBRE;
            if (string.IsNullOrEmpty(conductorName))
            {
                var client = await clientData.GetDoAsync(viewObject.CLIENTE_RES1).ConfigureAwait(false);
                conductorName = conductor.Value.NOMBRE;
            }

            _karveNavigator.NewIncidentView(viewObject.NUMERO_RES, conductorName,ViewModelUri);
        }

        private async void OnShowNewBooking()
        {
            // I am looking all the future request from this moment
            var summary = await _bookingDataService.SearchByDate(DateTime.Now, DateTime.Now).ConfigureAwait(false);
            _karveNavigator.NewSummaryView<IBookingData, BookingSummaryViewObject>(summary, "Reservas Futura", typeof(BookingControlView).FullName);

        }
       
        private void OnAddNewConcept()
        {
            MessageBox.Show("Not yet implemented");
        }

        /// <summary>
        /// Create a new booking item using a concept description
        /// </summary>
        /// <param name="item">
        /// Concept description
        /// </param>
        /// <param name="booking">booking item to update</param>
        private void AddConcept(FareConceptViewObject item, BookingItemsViewObject booking)
        {
            booking.IsNew = true;
            booking.Number = DataObject.NUMERO_RES;
            booking.Fare = DataObject.TARIFA_RES1;
            booking.IsDirty = true;
            booking.Concept = int.Parse(item.Code);
            booking.Desccon = item.Name;
        }

        /// <summary>
        /// Build a new booking object.
        /// </summary>
        /// <param name="item">
        /// A newly created fare object.
        /// </param>
        /// <returns>
        /// The <see cref="BookingItemsViewObject"/>.
        /// </returns>
        private BookingItemsViewObject AddNewBooking(FareConceptViewObject item)
        {
            var newItems = new BookingItemsViewObject
                               {
                                   IsNew = true,
                                   Number = DataObject.NUMERO_RES,
                                   IsDirty = true,
                                   Fare =  DataObject.TARIFA_RES1,
                                   Concept = int.Parse(item.Code),
                                   Desccon = item.Name,
                                   BookingKey = ++_lineNextId
                               };
            return newItems;
        }

        /// <summary>
        /// Show a modal window for interaction with fare concepts to be selected.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        private void OnShowConcepts(object value)
        {

            FareConceptViewObject item = null;
            LoadConcepts();
            ShowDataTransferObjects<FareConceptViewObject>(
                ConceptDto,
                "Conceptos",
                "Code,Name",
                                              (selectedItem) =>
                                              {
                                                  if (selectedItem != null)
                                                  {
                                                      ConceptDto = ConceptDto.Union(new List<FareConceptViewObject>() { selectedItem });
                                                      item = selectedItem;
                                                  }
                                              });
            if (item == null)
            {
                return;
            }

            if (value is Syncfusion.UI.Xaml.Grid.Cells.DataContextHelper helper)
            {
                var bookingItem = helper.Record as BookingItemsViewObject;
              
                if (bookingItem == null) 
                {
                    var newItem = AddNewBooking(item);
                    CollectionView.Add(newItem);
                    SelectedItem = CollectionView[CollectionView.Count - 1];
                }
                else
                {
                    AddConcept(item, bookingItem);
                }

                RaisePropertyChanged("CollectionView");
            }
        }

        /// <summary>
        ///  Set or Get the client selected object.
        /// </summary>
        public ClientSummaryExtended ClientSelectedObject
        {
            get
            {
                return _clientSelectedObject;
            }

            set
            {
                this._clientSelectedObject = value;
                this.RaisePropertyChanged("ClientSelectedObject");
            }
        }

        /// <summary>
        ///  Set or get the driver selected object.
        /// </summary>
        public ClientSummaryExtended DriverSelectedObject
        {
            get
            {
                return _driverSelectedObject;
            }

            set
            {
                this._driverSelectedObject = value;
                this.RaisePropertyChanged("DriverSelectedObject");
            }
        }

        /// <summary>
        ///  Set or Get the credit card.
        /// </summary>
        public IEnumerable<CreditCardViewObject> CreditCardView
        {
            get
            {
                return _creditCardView;
            }

            set
            {
                _creditCardView = value;
                RaisePropertyChanged("CreditCardViww");
            }
        }
        /// <summary>
        ///  Set or Get the country
        /// </summary>
        public IEnumerable<CountryViewObject> CountryDto
        {
            get
            {
                return _country;
            }

            set
            {
                _country = value;
                RaisePropertyChanged("CountryViewObject");
            }
        }
        /// <summary>
        /// Set or Get thje country
        /// </summary>
        public IEnumerable<CountryViewObject> DriverCountryList
        {
            get
            {
                return _country2;
            }

            set
            {
                _country2 = value;
                RaisePropertyChanged("DriverCountryList");
            }
        }

        /// <summary>
        ///  Set or Get the city
        /// </summary>
        public IEnumerable<CityViewObject> CityDto3
        {
            get => _city;
            set
            {
                _city = value;
                RaisePropertyChanged("CityDto3");
            }
        }
        /// <summary>
        ///  Set or Get the country viewObject.
        /// </summary>
        public IEnumerable<CountryViewObject> CountryDto3
        {
            get
            {
                return _countryDto;
            }

            set
            {
                _countryDto = value;
                RaisePropertyChanged("CountryDto3");
            }
        }
        /// <summary>
        ///  Set or get the province.
        /// </summary>
        public IEnumerable<ProvinceViewObject> ProvinceDto3
        {
            get
            {
                return _provinceDto;
            }

            set
            {
                _provinceDto = value;
                RaisePropertyChanged("ProvinceDto3");
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
            get => _expirationMonth;
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
            _helperDataService = DataServices.GetHelperDataServices();
        }

        /// <summary>
        /// This create a collection of items to personalize the line grid.
        /// We have three types of items:
        /// 1. NavigationAwareItem. It allows a navigation to another region.
        /// 2. CellPresenterItem. It the simplest one.
        /// 3. CommandAwareItem. It allows to execute a command from the line,
        /// in this case has been used for the checkbox.
        /// </summary>
        /// <returns></returns>
        private ObservableCollection<CellPresenterItem> InitGridColumns()
        {
           
            var presenter = new ObservableCollection<CellPresenterItem>()
                                {
                                    new NavigationAwareItem()
                                        {
                                            DataTemplateName = "NavigateBookingConcept",
                                            MappingName = "Concept",
                                            RegionName = RegionNames.LineRegion,
                                            IsReadOnly = true
                                        },
                                    // here we want to enforce the readonly
                                    new CellPresenterItem()
                                        {
                                            NoTemplate = true, MappingName = "Desccon", IsReadOnly = true
                                        },
                                    new CellPresenterItem()
                                        {
                                            NoTemplate = true, MappingName = "Extra", IsReadOnly = true
                                        },
                                    new CellPresenterItem()
                                        {
                                            NoTemplate = true, MappingName = "Min", IsReadOnly = true
                                        },
                                    new CellPresenterItem()
                                        {
                                            NoTemplate = true, MappingName = "Max", IsReadOnly = true
                                        },
                                    new CellPresenterItem()
                                        {
                                            NoTemplate = true, MappingName = "Subtotal", IsReadOnly = true
                                        },
                                    new NavigationAwareItem()
                                        {
                                            DataTemplateName = "BookingInclude",
                                            MappingName = "Included",
                                            RegionName = RegionNames.LineRegion
                                        },
                                    new NavigationAwareItem()
                                        {
                                            DataTemplateName = "BillToBookin",
                                            MappingName = "Bill",
                                            RegionName = RegionNames.LineRegion,
                                            IsReadOnly = true
                                        },
                                    new NavigationAwareItem()
                                        {
                                            DataTemplateName = "NavigateBookingUnit",
                                            MappingName = "Unity",
                                            RegionName = RegionNames.LineRegion,
                                            IsReadOnly = true
                                        }
                                };
            return presenter;
        }

        /// <summary>
        ///  Init the view model.
        /// </summary>
        private void InitViewModel()
        {

            ViewModelUri = new Uri("karve://booking/viewmodel?id=" + Guid.ToString());
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
                "Concept","Desccon","Bill", "Included", "Quantity", "Price","Discount","Subtotal", "Extra", "Iva","Days","Min","Max","Unity"
            };
            /*
             *  This goes to a data template to configure directly the grid with its mapping.
             */

            AssistMapper = _assistDataService.Mapper;

            FetchGridsSettings();
            // ReservationOffice = FetchOffices();
            ConceptDto = new ObservableCollection<FareConceptViewObject>();
            this._lineNextId = _bookingDataService.GetNextLineId();
        }

        private void LoadConcepts()
        {
            var office = NotifyTaskCompletion.Create<IEnumerable<FareConceptViewObject>>
                (_helperDataService.GetMappedAllAsyncHelper<FareConceptViewObject, CONCEP_FACTUR>(), (task, sender) =>
                {
                    if (task is INotifyTaskCompletion<IEnumerable<FareConceptViewObject>> result)
                    {
                        if (result.IsSuccessfullyCompleted)
                        {
                            ConceptDto = new ObservableCollection<FareConceptViewObject>(result.Task.Result);
                        }
                    }
                });
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
        private ObservableCollection<OfficeViewObject> FetchOffices()
        {
            var collection = new ObservableCollection<OfficeViewObject>();
            var helpers = DataServices.GetHelperDataServices();
            var office = NotifyTaskCompletion.Create<IEnumerable<OfficeViewObject>>(
                helpers.GetMappedAllAsyncHelper<OfficeViewObject, OFICINAS>(),
                (task, sender) =>
                    {
                        if (!(task is INotifyTaskCompletion<IEnumerable<OfficeViewObject>> result))
                        {
                            return;
                        }
                        if (result.IsSuccessfullyCompleted)
                        {
                        collection = new ObservableCollection<OfficeViewObject>(result.Result);
                        }
            });
            return collection;
        }

        /// <summary>
        /// Checks if is possible to save the data object view following the current business
        /// logic and validation.
        /// </summary>
        /// <param name="arg">
        /// The param has been ignored.
        /// </param>
        /// <returns>
        /// Returns <see cref="bool"/> true if we can save the data.
        /// </returns>
        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        private bool CanSave(object arg)
        {
            var dataObject = DataObject;
            if (!IsCommandForMe())
            {
                return true;
            }

            if (!CollectionView.Any())
            {
                var value = "Reason: Reservas debe tener conceptos";
                DialogService?.ShowErrorMessage(KarveLocale.Properties.Resources.linvalidbookingdata + " " + dataObject.NUMERO_RES + "\n" + value);
                return false;
            }

            if (dataObject.HasErrors)
            {
                var value = "\nReason: " + dataObject.Errors.FirstOrDefault();
                DialogService?.ShowErrorMessage(KarveLocale.Properties.Resources.linvalidbookingdata + " " + dataObject.NUMERO_RES + " " + value);
                return false;
            }

            // here we can put the business validation.
            return true;
        }

        /// <summary>
        ///  Save data from the view.
        /// </summary>
        /// <param name="savedObject">Save data from the view command.</param>
        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        private void SaveViewCommand(object savedObject)
        {
            if (!IsCommandForMe())
            {
                return;
            }

            if (!CanSave(savedObject))
            {
                return;
            }

            var bookingDataObject = DataObject;
            bookingDataObject.Items = CollectionView;
            _bookingData.Value = bookingDataObject;
            var isErrorNotified = false;
            NotifyTaskCompletion.Create<bool>(
                _bookingDataService.SaveAsync(_bookingData),
                (sender, ev) =>
                    {
                        if (sender is INotifyTaskCompletion<bool> task)
                {
                    var number = _bookingData.Value.NUMERO_RES;
                    if (task.IsSuccessfullyCompleted && (task.Result == true))
                    {
                        var msg = $"Reserva {number} guardada con exito!";
                        DialogService?.ShowMessage("Reservation", msg);
                        IsChanged = false;
                        OperationalState = DataPayLoad.Type.Show;
                    }
                    else
                    {
                        if (isErrorNotified)
                        {
                            return;
                        }

                        var error = "Validation error while saving!";
                        if (!string.IsNullOrEmpty(task.ErrorMessage))
                        {
                            error = task.ErrorMessage;
                            isErrorNotified = true;
                        }

                        DialogService?.ShowErrorMessage(error);
                    }
                }
            });
        }

        private void DeleteViewCommand(object obj)
        {
            var activeView = RegionManager.Regions[RegionNames.TabRegion].ActiveViews.FirstOrDefault();
            var viewDeleter = new ViewDeleter<IBookingData, BookingSummaryViewObject>(_bookingDataService, DialogService, EventManager);
          
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
                            viewDeleter.Notify(ViewModelUri.ToString(), BookingModule.BookingSubSystem);
                            UnregisterToolBar(payLoad.PrimaryKeyValue);
                            DeleteRegion();
                        }

                    }
                }
            }
        }

        /// <summary>
        /// Create a new view and navigate to the new created view.
        /// </summary>
        /// <param name="obj">
        /// Not used.
        /// </param>
        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        private void NewViewCommand(object obj)
        {
            
            var activeView = RegionManager.Regions[RegionNames.TabRegion].ActiveViews.FirstOrDefault();
            if (activeView is UserControl control)
            {
                var viewFactory = new ViewFactory<BookingInfoView, BookingFooterView, IBookingData, BookingSummaryViewObject>(_regionManager, _container, EventManager, _bookingDataService, _bookingDataService);
                if (control.DataContext is KarveViewModelBase baseViewModel)
                {
                    // its is me....
                    if (baseViewModel.ViewModelUri == ViewModelUri)
                    {
                        viewFactory.NewItem<BookingInfoView>(
                            KarveLocale.Properties.Resources.lbooking,
                            "karve://booking/viewmodel?id=",
                            DataSubSystem.BookingSubsystem, 
                            BookingModule.BookingSubSystem);
                    }
                }
            }
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.")]
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
        private void OnCreateNewClient(object obj)
        {

            _karveNavigator.NewClientView(ViewModelUri);
        }

        /// <summary>
        ///  Show current client.
        /// </summary>
        /// <param name="clientNumber">Client Number</param>
        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        private async void ShowCurrentClient(object clientNumber)
        {
            if (clientNumber is string numberCode)
            {
                var clientDataService = DataServices.GetClientDataServices();
                var payload = await clientDataService.GetDoAsync(numberCode);
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
            ShowDataTransferObjects<ContractByClientViewObject>(contractByClient, "Contractos per cliente", "Contract,DepartureDate, ForecastDeparture,ReturnDate,Days,Driver,Matricula,Brand,Model,Fare,InvoiceNumber,GrossInvoice", (selectedItem) =>
             {
                 if (selectedItem != null)
                 {
                     if (ContractByClientDto == null)
                     {
                         ContractByClientDto = new List<ContractByClientViewObject>();
                     }

                     ContractByClientDto.Union<ContractByClientViewObject>(new List<ContractByClientViewObject>() { selectedItem });
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

        private void ClearList(BookingViewObject viewObject)
        {
            if (viewObject == null)
            {
                return;
            }

            if (viewObject.Items is IList<BookingItemsViewObject> list)
            {
                list.Clear();
            }

            _bookingClientsIncrementalList.Clear();

        }

        /// <summary>
        /// The create view model mail first.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="model">
        /// The model.
        /// </param>
        private void CreateViewModelMailFirst(string name, BookingMailViewModel model)
        {
            var detailsRegion = _regionManager.Regions[RegionNames.TabRegion];
            var clientWindow = _container.Resolve<BookingMail>();
            clientWindow.Header = name;
            clientWindow.DataContext = model;
            _mailRegionManager = detailsRegion.Add(clientWindow, null, true);
            clientWindow.Focus();
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
        /// Initalization state.
        /// </summary>
        /// <param name="value">Value of the primary key, in many cases is optional</param>
        /// <param name="payload">Kind of payload</param>
        /// <param name="insertion">If we want to insert or not</param>
        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        protected override void Init(string value, DataPayLoad payload, bool insertion)
        {
            Contract.Requires(payload != null);
            Contract.Requires(payload.DataObject != null, "Null Data Object");
            if (!payload.HasDataObject) return;

            // I shall always check if the message is for me.
            if (!insertion)
            {
                if (!IsForMe<IBookingData>(payload, (x) =>
                {
                    var booking = x.Value;
                    return (PrimaryKeyValue == booking.NUMERO_RES);
                }))
                {
                    return;
                }
            }

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
                            _bookingData.Value.Items = new ObservableCollection<BookingItemsViewObject>();
                            PrimaryKeyValue = payload.PrimaryKeyValue;
                            data.Value.NUMERO_RES = PrimaryKeyValue;

                            break;
                        }

                    default:
                        {
                            var dataObject = data.Value;
                            PrimaryKeyValue = dataObject.NUMERO_RES;
                            CollectionView = new ObservableCollection<BookingItemsViewObject>(dataObject.Items);
                            break;
                        }

                }
                GeneralInfoCollection = SetDataObject(data.Value, _generalInfoCollection);
                DataObject = data.Value;
                UpdateAux(data);

                // register the view model to the toolbar.
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

        public ObservableCollection<DtoType> SelectItem<DtoType>(IEnumerable<DtoType> item, IEnumerable<DtoType> collection)
        {
            ObservableCollection<DtoType> obsCollection = collection as ObservableCollection<DtoType>;
            var i = item.FirstOrDefault();
            if (i != null)
            {
                obsCollection.Add(i);
            }

            return obsCollection;
        }

        private void UpdateAux(IBookingData data)
        {

            if (data == null)
            {
                return;
            }

            UpdateGenericCollection(data);
            BookingAgencyEmployee = new ObservableCollection<AgencyEmployeeViewObject>(data.AgencyEmployeeDto);
            BookingContacts = data.ContactsDto1;
            BookingMedia = data.BookingMediaDto;
            BookingOrigen = data.OriginDto;
            BookingPaymentFormDto = data.PaymentFormDto;
            BookingType = data.BookingTypeDto;
            BookingVehicleActivity = data.VehicleActivitiesDto;
            BrokerDto = data.BrokerDto;
            BudgetDto = data.BookingBudget;
            ClientDto = data.Clients;
            DriverDto = data.DriverDto2;
            BookingCompanyDto = new ObservableCollection<CompanyViewObject>(data.CompanyDto);
            DeliveringPlaceDto = data.DepartureDeliveryDto;
            PlaceReturnDto = data.PlaceOfReturnDto;
            DriverCountryList = data.DriverCountryList;
            SecondDriverCityDto = data.SecondDriverCityDto;
            SecondDriverCountryDto = data.SecondDriverCountryDto;
            SecondDriverProvinceDto = data.SecondDriverProvinceDto;

            DriverSelectedObject = DriverDto.FirstOrDefault();
            ClientSelectedObject = ClientDto.FirstOrDefault();

            if (data.DriverDto2 != null)
            {
                DriverDto2 = new ObservableCollection<ClientSummaryExtended>(data.DriverDto2);
            }

            DriverDto3 = data.DriverDto3;
            DriverDto4 = data.DriverDto4;
            DriverDto5 = data.DriverDto5;
            CountryDto3 = data.CountryDto3;
            ProvinceDto3 = data.ProvinceDto3;
            if (data.CityDto3 != null)
            {
                var cityData = data.CityDto3.FirstOrDefault();
                if (cityData != null)
                {
                    this.CityDto3 = new ObservableCollection<CityViewObject>() { cityData };
                }
            }

            ActiveFareDto = data.FareDto;
            BookingOfficeDto = new ObservableCollection<OfficeViewObject>(data.OfficeDto);
            BookingOrigen = data.OriginDto;
            BookingRefusedDto = data.BookingRefusedDto;
            VehicleDto = data.VehicleDto;
            VehicleGroupDto = data.VehicleGroupDto;
            ReservationOfficeArrival = new ObservableCollection<OfficeViewObject>(data.ReservationOfficeArrival);
            ReservationOfficeDeparture = new ObservableCollection<OfficeViewObject>(data.ReservationOfficeDeparture);
            // this send an update to everyone
            RaisePropertyChanged(null);
            IsViewModelInitialized = true;


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
            payLoad.HasSaveCommand = true;
            payLoad.HasDeleteCommand = true;
            payLoad.NewCommand = _newCommand;
            payLoad.SaveCommand = _saveCommand;
            payLoad.DeleteCommand = _deleteCommand;
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
                var assistTableName = values.ContainsKey("AssistTable") ? values["AssistTable"] as string : null;
                var assistQuery = values.ContainsKey("AssistQuery") ? values["AssistQuery"] as string : null;
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
                        value.SourceView = collectionValue as IEnumerable<PaymentFormViewObject>;
                        break;
                    }

                case "BOOKING_CONTRATIPIMPR_ASSIST":
                    {
                        collection[6].SourceView = collectionValue as IEnumerable<PrintingTypeViewObject>;
                        RaisePropertyChanged("GeneralCollectionInfo");
                        break;
                    }

                case "BOOKING_ACTIVEHI_RES1_ASSIST":
                    {
                        collection[7].SourceView = collectionValue as IEnumerable<VehicleActivitiesViewObject>;
                        RaisePropertyChanged("GeneralCollectionInfo");
                        break;
                    }

                case "BROKER_ASSIST":
                    {
                        BrokerDto = (IEnumerable<CommissionAgentSummaryViewObject>)collectionValue;
                        RaisePropertyChanged("GeneralCollectionInfo");
                        break;
                    }

                case "BOOKING_CONTACTO_ASSIST":
                    {
                        collection[4].SourceView = collectionValue as IEnumerable<ContactsViewObject>;
                        RaisePropertyChanged("GeneralCollectionInfo");
                        break;
                    }

                case "BOOKING_ORIGIN_ASSIST":
                    {
                        collection[0].SourceView = collectionValue as IEnumerable<OrigenViewObject>;
                        RaisePropertyChanged("GeneralCollectionInfo");
                        break;
                    }

                case "BOOKING_MEDIO_ASSIST":
                    {
                        //collection[1].SourceView = null;

                        collection[1].SourceView = collectionValue as IEnumerable<BookingMediaViewObject>;
                        RaisePropertyChanged("GeneralCollectionInfo");

                        break;
                    }

                case "BOOKING_CONF_MESSAGE_ASSIST":
                    {
                        BookingConfirmMessageDto = (IEnumerable<BookingConfirmMessageViewObject>)collectionValue;

                        break;
                    }

                case "BOOKING_REFUSE_ASSIST":
                    {
                        BookingRefusedDto = (IEnumerable<BookingRefusedViewObject>)collectionValue;
                        break;
                    }

                case "BOOKING_TYPE_ASSIST":
                    {
                        collection[2].SourceView = collectionValue as IEnumerable<BookingTypeViewObject>;
                        RaisePropertyChanged("GeneralCollectionInfo");
                        break;
                    }

                case "BUDGET_ASSIST":
                    {
                        BudgetDto = (IEnumerable<BudgetSummaryViewObject>)collectionValue;
                        break;
                    }

                case "CITY_ASSIST":
                    {
                        CityDto = (IEnumerable<CityViewObject>)collectionValue;
                        break;
                    }

                case "CITY_ASSIST_2":
                    {
                        SecondDriverCityDto = (IEnumerable<CityViewObject>)collectionValue;
                        break;
                    }

                case "CLIENT_ASSIST":
                    {

                        ClientDto = (IEnumerable<ClientSummaryExtended>)collectionValue;
                        break;
                    }

                case "CONTRACT_CLIENT_ASSIST":
                    {
                        ContractByClientDto = collectionValue as IEnumerable<ContractByClientViewObject>;
                        break;
                    }

                case "COUNTRY_ASSIST":
                    {
                        CountryDto = (IEnumerable<CountryViewObject>)collectionValue;
                        break;
                    }

                case "COUNTRY_ASSIST_2":
                    {
                        DriverCountryList = (IEnumerable<CountryViewObject>)collectionValue;
                        break;
                    }

                case "COUNTRY_ASSIST_3":
                    {
                        SecondDriverCountryDto = (IEnumerable<CountryViewObject>)collectionValue;
                        break;
                    }

                case "COUNTRY_ASSIST_4":
                    {
                        CountryDto4 = (IEnumerable<CountryViewObject>)collectionValue;
                        break;
                    }

                case "PAIS":
                    {
                        Country = (IEnumerable<CountryViewObject>)collectionValue;
                        break;
                    }

                case "CREDIT_CARD_ASSIST":
                    {
                        CreditCardView = (IEnumerable<CreditCardViewObject>)collectionValue;
                        break;
                    }

                case "CRM_PROVIDER_ASSIST":
                    {
                        CrmSupplierDto = (IEnumerable<SupplierSummaryViewObject>)collectionValue;
                        break;
                    }

                case "DRIVER_PROV":
                    {

                        ProvinceDto3 = (IEnumerable<ProvinceViewObject>)collectionValue;
                        break;
                    }

                case "DELIVERY_PLACE_0":
                    {
                        DeliveringPlaceDto = (IEnumerable<DeliveringPlaceViewObject>)collectionValue;
                        break;
                    }

                case "DELIVERY_PLACE_1":
                    {
                        PlaceReturnDto = (IEnumerable<DeliveringPlaceViewObject>)collectionValue;
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
                        CityDto3 = (IEnumerable<CityViewObject>)collectionValue;
                        break;
                    }

                case "DRIVER_COUNTRY":
                    {
                        CountryDto3 = (IEnumerable<CountryViewObject>)collectionValue;
                        break;
                    }

                case "FARE_ASSIST":
                    {
                        ActiveFareDto = (IEnumerable<FareViewObject>)collectionValue;
                        break;
                    }

                case "FARE_CONCEPT_ASSIST":
                    {
                        ConceptDto = (IEnumerable<FareConceptViewObject>)collectionValue;
                        break;
                    }

                case "EMPLEAGE_ASSIST":
                    {
                        collection[3].SourceView = (IEnumerable<AgencyEmployeeViewObject>)collectionValue;
                        RaisePropertyChanged("GeneralCollectionInfo");

                        break;
                    }

                case "COMPANY_ASSIST":
                    {
                        BookingCompanyDto = (IEnumerable<CompanyViewObject>)collectionValue;
                        break;
                    }

                case "BOOKING_OFFICE_1":
                    {
                        ReservationOfficeDeparture = (IEnumerable<OfficeViewObject>)collectionValue;
                        break;
                    }

                case "BOOKING_OFFICE_2":
                    {
                        ReservationOfficeArrival = (IEnumerable<OfficeViewObject>)collectionValue;
                        break;
                    }

                case "OFFICE_ASSIST":
                    {
                        BookingOfficeDto = (IEnumerable<OfficeViewObject>)collectionValue;
                        break;
                    }

                case "LANGUAGE_ASSIST":
                    {
                        LanguageDto = (IEnumerable<LanguageViewObject>) collectionValue;
                        break;
                    }

                case "PROMOTION_ASSIST":
                    {
                        PromotionDto = (IEnumerable<PromotionCodesViewObject>)collectionValue;
                        break;
                    }

                case "PROVINCE_ASSIST_2":
                    {
                        SecondDriverProvinceDto = (IEnumerable<ProvinceViewObject>)collectionValue;
                        break;
                    }

                case "VEHICLE_GROUP_ASSIST":
                    {
                        VehicleGroupDto = (IEnumerable<VehicleGroupViewObject>)collectionValue;
                        break;
                    }

                case "VEHICLE_ASSIST":
                    {
                        VehicleDto = (IEnumerable<VehicleSummaryViewObject>)collectionValue;
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

        private ObservableCollection<Type> ClearObservableCollection<Type>(ObservableCollection<Type> collection)
        {
            ObservableCollection<Type> t = new ObservableCollection<Type>();
            if (collection == null)
            {
                return t;
            }

            if (collection is ObservableCollection<Type> clearable)
            {
                clearable.Clear();
                return clearable;
            }

            return t;
        }

        public BookingConfirmMessageViewObject BookingConfirmMessage
        {
            get
            {
                return _bookingConfirmMessage;
            }

            set
            {
                this._bookingConfirmMessage = value;
                this.RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Set default view model flags.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        private void InitFlags()
        {
            DefaultPageSize = 25;
            IsReady = false;
            IsChanged = false;
            LineVisible = true;
            FooterVisible = false;
            _selectedIndex = 0;
            _lineNextId = 0;
            IsViewModelInitialized = false;
            IsReservationCancelled = false;
        }

        /// <summary>
        /// Set the grid column names.
        /// It might use the configuration service for retrieving the names.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        private void SetGridColumns()
        {
            // this shall be at the configuration service
            BrokerGridColumns = "Code,Name,Nif,Person,Zip,City,Province,Country,IATA,Company,OfficeZone,CurrentUser,LastModification";
            VehicleGridColumns = "Code,Brand,Model,Matricula,VehicleGroup,Situation,Office,Places,CubeMeters,Activity,Color,Owner,OwnerName,Policy,LeasingCompany,StartingDate,EndingDate,ClientNumber,Client,PurchaseInvoice,Frame,MotorNumber,Reference,KeyCode,StorageKey,User,Modification";
            ClientsConductor = "Code,Name,Nif,Phone,Movil,Email,Card,ReplacementCar,Zip,City,CreditCardType,NumberCreditCard, PaymentForm,AccountableAccount,Sector,Zona,Origin,Office,Falta,BirthDate,DrivingLicence";
            BookingInfoCols = "BudgetNumber,BudgetOffice,ClientName,GroupCode,BudgetCreationDate,DepartureDate,BookingNumber,BrokerName,Origin";
        }

        /// <summary>
        /// Open the e-mail client view.
        /// Retrieve the client view object and lookup for the configured user mail address.
        /// And it will open a mail client.
        /// </summary>
        /// <param name="clientNumber">Number of the mail client.</param>
        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        private async void OnMailClient(object clientNumber)
        {
            if (!(clientNumber is string clientNumberValue))
            {
                return;
            }

            var client = await this.DataServices.GetClientDataServices().GetDoAsync(clientNumberValue).ConfigureAwait(false);

            if (client == null)
            {
                return;
            }

            var bookingMail = new BookingMailViewModel
            {
                DestinationAddress = client.Value.EMAIL,
                Subject = KarveLocale.Properties.Resources.lbookingnumber + " " + this.DataObject.NUMERO_RES
            };
            var userSettings = this._configurationService.UserSettings;
            if (userSettings == null)
            {
                return;
            }
            var user = userSettings.FindSetting<string>(UserSettingConstants.DefaultEmailAddress);
            if (!string.IsNullOrWhiteSpace(user))
            {
                bookingMail.SenderAddress = user;
            }
            CreateViewModelMailFirst("Mail Cliente", bookingMail);
        }

        /// <summary>
        /// The on execute save client.
        /// </summary>
        /// <param name="viewObject">
        /// The view object.
        /// </param>
        private async void OnExecuteSaveClient(BookingViewObject viewObject)
        {
            var taskBool = await SaveDrivingLicenseDriver(viewObject.COD_COND1_RES2, viewObject).ConfigureAwait(false);

        }


        private async Task<bool> SaveDrivingLicenseDriver(string code, BookingViewObject viewObject)
        {
            // i do not want trigger error in this case. it is safe and sound to save nothing
            if (string.IsNullOrEmpty(code))
            {
                return true;
            }

            var clientDataService = DataServices.GetClientDataServices();
            var firstDriver = await clientDataService.GetDoAsync(code).ConfigureAwait(false);
            if (!firstDriver.Valid)
            {
                return true;
            }
            var clientDto = firstDriver.Value;
            clientDto.DIRECCION = viewObject.DIRCOND_RES2;
            clientDto.POBLACION = viewObject.POCOND_RES2;
            clientDto.CP = viewObject.CPCOND_RES2;
            clientDto.PROVINCIA = viewObject.PROVCOND_RES2;
            clientDto.PAIS = viewObject.PAISCOND_RES2;
            clientDto.TELEFONO = viewObject.TELCOND_RES2;
            clientDto.FAX = viewObject.TEL2COND_RES2;
            clientDto.EMAIL = viewObject.EMAIL_RES1;
            clientDto.PERMISO = viewObject.PERMISO_RES2;
            clientDto.FEEXPE = viewObject.FEEXPE_RES2;
            clientDto.LUNACI = viewObject.LUNACI_RES2;
            clientDto.NIF = viewObject.PAISNIFCOND_RES2;
            clientDto.FENAC = viewObject.FENACI_RES2;
            clientDto.CLASE = viewObject.CLASE_RES2;
            firstDriver.Value = clientDto;
            return await clientDataService.SaveAsync(firstDriver).ConfigureAwait(false);
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
        ///  Important method to clean all resources.
        /// </summary>
        private void ClearCollections()
        {
            Contract.Requires(condition: this.CityDto != null);
            Contract.Requires(this.ClientDto != null);
            Contract.Requires(this.VehicleDto != null);
            Contract.Requires(this.BrokerDto != null);
            Contract.Requires(this.ActiveFareDto != null);
            Contract.Requires(this.VehicleGroupDto != null);
            CityDto = ClearCollection(CityDto);
            ClientDto = ClearCollection(ClientDto);
            VehicleDto = ClearCollection(VehicleDto);
            BrokerDto = ClearCollection(BrokerDto);
            VehicleGroupDto = ClearCollection(VehicleGroupDto);
            ActiveFareDto = ClearCollection(ActiveFareDto);
            ReservationOffice = ClearObservableCollection(ReservationOffice);

            Contract.Ensures(!this.CityDto.Any());
            Contract.Ensures(!this.ClientDto.Any());
            Contract.Ensures(!this.VehicleDto.Any());
            Contract.Ensures(!this.BrokerDto.Any());
            Contract.Ensures(!this.VehicleGroupDto.Any());
            Contract.Ensures(!this.ActiveFareDto.Any());
        }
       
        #endregion





        private ICommand _newCommand;
        private ICommand _bookingConcept;
        private ICommand _newBookingCommand;
        private string _expirationMonth;
        private ObservableCollection<CellPresenterItem> _cellGridPresentation;
        private IConfigurationService _configurationService;
        private IUserSettings _userSettings;
        private string _gridColumnsKey;
        private string _gridDriverColumnsKey;
        private IBookingData _bookingData;
        private BookingViewObject _bookingViewObjectValue;
        private IBookingDataService _bookingDataService;
        private readonly IUnityContainer _container;
        private readonly IRegionManager _regionManager;
        private IAssistDataService _assistDataService;
        private IHelperDataServices _helperDataService;
        private PropertyChangedEventHandler _clientHandler;
        private string _driverCreditCardExpireYear;
        private string _driverCreditCardExpireMonth;
        private IncrementalList<ClientSummaryExtended> _bookingClientsIncrementalList;
        private DelegateCommand<object> _saveCommand;
        private DelegateCommand<object> _deleteCommand;
      
        private IKarveNavigator _karveNavigator;

        private IEnumerable<BudgetSummaryViewObject> _budgetDto = new ObservableCollection<BudgetSummaryViewObject>();

        private IEnumerable<ClientSummaryExtended> _clientDto = new ObservableCollection<ClientSummaryExtended>();
        private IEnumerable<ClientSummaryExtended> _drivers = new ObservableCollection<ClientSummaryExtended>();
        private IEnumerable<ClientSummaryExtended> _drivers2 = new ObservableCollection<ClientSummaryExtended>();
        private IEnumerable<ClientSummaryExtended> _drivers3 = new ObservableCollection<ClientSummaryExtended>();
        private IEnumerable<ClientSummaryExtended> _drivers4 = new ObservableCollection<ClientSummaryExtended>();
        private IEnumerable<ClientSummaryExtended> _drivers5 = new ObservableCollection<ClientSummaryExtended>();

        private IEnumerable<CommissionAgentSummaryViewObject> _brokers;
        private IEnumerable<CompanyViewObject> _company = new ObservableCollection<CompanyViewObject>();
        private IEnumerable<ContractByClientViewObject> _contractClientDto = new ObservableCollection<ContractByClientViewObject>();

        private ObservableCollection<OfficeViewObject> _reservationOffice = new ObservableCollection<OfficeViewObject>();
        private IEnumerable<FareConceptViewObject> _concepts = new ObservableCollection<FareConceptViewObject>();
        private IEnumerable<FareViewObject> _fare = new ObservableCollection<FareViewObject>();
        private IEnumerable<VehicleSummaryViewObject> _vehicle = new ObservableCollection<VehicleSummaryViewObject>();
        private IEnumerable<CityViewObject> _cityDto = new ObservableCollection<CityViewObject>();
        private IEnumerable<VehicleGroupViewObject> _vehicleGroup = new ObservableCollection<VehicleGroupViewObject>();
        private IEnumerable<FareViewObject> _activeFareDto = new ObservableCollection<FareViewObject>();


        private IEnumerable<OfficeViewObject> _officeDto = new ObservableCollection<OfficeViewObject>();
        private IEnumerable<OfficeViewObject> _reservationOfficeDeparture = new ObservableCollection<OfficeViewObject>();
        private IEnumerable<OfficeViewObject> _reservationOfficeArrival = new ObservableCollection<OfficeViewObject>();
        private IEnumerable<CountryViewObject> _country = new ObservableCollection<CountryViewObject>();
        private IEnumerable<CityViewObject> _city = new ObservableCollection<CityViewObject>();
        private IEnumerable<CountryViewObject> _countryDto = new ObservableCollection<CountryViewObject>();
        private IEnumerable<ProvinceViewObject> _provinceDto = new ObservableCollection<ProvinceViewObject>();
        private IEnumerable<CountryViewObject> _country2 = new ObservableCollection<CountryViewObject>();
        private IEnumerable<CreditCardViewObject> _creditCardView = new ObservableCollection<CreditCardViewObject>();
        private int _selectedIndex;
        private IEnumerable<CityViewObject> _secondCityDriver = new ObservableCollection<CityViewObject>();
        private IEnumerable<ProvinceViewObject> _secondProvinceDriver = new ObservableCollection<ProvinceViewObject>();
        private IEnumerable<CountryViewObject> _secondDriverCountry = new ObservableCollection<CountryViewObject>();
        private IEnumerable<BookingItemsViewObject> _dataItems = new List<BookingItemsViewObject>();
        private IEnumerable<BookingConfirmMessageViewObject> _bookingConfirm = new ObservableCollection<BookingConfirmMessageViewObject>();
        private IEnumerable<SupplierSummaryViewObject> _crmSupplierDto = new ObservableCollection<SupplierSummaryViewObject>();
        private IEnumerable<CountryViewObject> _countryDto4 = new ObservableCollection<CountryViewObject>();
        private IEnumerable<PromotionCodesViewObject> _promotionDto = new ObservableCollection<PromotionCodesViewObject>();
        private IEnumerable<CountryViewObject> _countryDto6 = new ObservableCollection<CountryViewObject>();
        private IEnumerable<CompanyViewObject> _companyDto = new ObservableCollection<CompanyViewObject>();
        private IEnumerable<DeliveringPlaceViewObject> _deliveryPlace = new ObservableCollection<DeliveringPlaceViewObject>();
        private IEnumerable<DeliveringPlaceViewObject> _returnPlaceDto = new ObservableCollection<DeliveringPlaceViewObject>();
        private IEnumerable<LanguageViewObject> _languageDto;
        private BookingConfirmMessageViewObject _bookingConfirmMessage;
        private string _bookingCols;
        private IEnumerable<BookingRefusedViewObject> _bookingRefused;
        private bool _isReservationCancelled;
        private BookingModule.BookingState currentBookingState;
        private ClientSummaryExtended _clientSelectedObject;
        private ClientSummaryExtended _driverSelectedObject;
        private IRegionManager _mailRegionManager;
        private IBookingService _bookingService;
        private BookingViewObject _previousBookingData;

        private long _lineNextId;
        private ObservableCollection<BookingItemsViewObject> _collectionView;
        private ICommand _includedCheckCommand;
    }
}
