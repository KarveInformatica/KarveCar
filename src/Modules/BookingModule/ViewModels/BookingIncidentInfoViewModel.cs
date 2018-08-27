using KarveCommon.Generic;
using KarveCommon.Services;
using KarveCommonInterfaces;
using KarveDataServices;
using KarveDataServices.ViewObjects;
using KarveDataServices.DataObjects;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using KarveCar.Navigation;
using Prism.Regions;
using Microsoft.Practices.Unity;
using System.Windows.Controls;
using BookingModule.Views;
using KarveControls.Annotations;

namespace BookingModule.ViewModels
{
    /// <summary>
    ///  View model that has the responsibility for the booking incident form.
    ///  
    /// </summary>
    public class BookingIncidentInfoViewModel : KarveRoutingBaseViewModel, ICreateRegionManagerScope, IEventObserver, INavigationAware
    {
        private readonly ICommand _deleteCommand;
        private readonly ICommand _saveCommand;
        private readonly DelegateCommand<object> _newCommand;
        private readonly IBookingIncidentDataService _dataIncidentService;
        private BookingIncidentViewObject _dataObject;
        #region ServiceDeclaration
        private IAssistDataService _assistDataService;
        #endregion
        private IBookingIncidentData _dtoWrapperData;

        private IKarveNavigator _navigator;

        private IUserSettings _userSettings;

        private readonly IUnityContainer _unityContainer;
        #region auxhelpers
        private IEnumerable<OfficeViewObject> _bookingIncidentOfficeDtoValue;
        private IEnumerable<ClientSummaryExtended> _bookingIncidentClientDtoValue;
        private IEnumerable<ClientSummaryExtended> _bookingIncidentDriverDtoValue;
        private IEnumerable<IncidentTypeViewObject> _bookingIncidentTypeDtoValue;
        private IEnumerable<SupplierSummaryViewObject> _bookingIncidentSupplierDtoValue;
        private IEnumerable<VehicleSummaryViewObject> _bookingIncidentVehicleDtoValue;
        #endregion
        private string _vehicleColumns;
        private string _clientColumns;
        /// <summary>
        ///  Constructor.
        /// </summary>
        /// <param name="services">Data service for data retrieving</param>
        /// <param name="controller">Interaction controller for showing popup</param>
        /// <param name="dialogService">Error message dialog controller</param>
        /// <param name="unityContainer"></param>
        /// <param name="eventManager"></param>
        /// <param name="navigation"></param>
        /// <param name="configurationService"></param>
        /// <param name="regionManager"></param>
        public BookingIncidentInfoViewModel(IDataServices services, IInteractionRequestController controller,
                               IDialogService dialogService,
                               IUnityContainer unityContainer,
                               IEventManager eventManager,
                               IKarveNavigator navigation,
                               IConfigurationService configurationService,
                               IRegionManager regionManager) : base(services, controller, dialogService, eventManager, regionManager)
        {
            AssistCommand = new DelegateCommand<object>(OnAssistCommand);
            ItemChangedCommand = new DelegateCommand<object>(OnChangedField);

            SubSystem = DataSubSystem.BookingSubsystem;

            ViewModelUri = new Uri("karve://booking/incident/show/viewmodel?id=" + Guid.ToString());
            _unityContainer = unityContainer;
            _navigator = navigation;
            _userSettings = configurationService.UserSettings;
            _deleteCommand = new DelegateCommand<object>(DeleteViewCommand);
            _saveCommand = new DelegateCommand<object>(SaveViewCommand);
            _newCommand = new DelegateCommand<object>(NewViewCommand);
            _dataIncidentService = services.GetBookingIncidentDataService();
            _assistDataService = services.GetAssistDataServices();
            _unityContainer = unityContainer;
            CompositeCommandOnly = true;
            VehicleColumns = "Code,Brand,Model,Matricula,VehicleGroup,Situation,Office,Places,CubeMeters,Activity,Owner";
            ClientsConductorColumns = "Code,Name,Nif,Phone,Movil,Email,Card,ReplacementCar,Zip,City,CreditCardType,NumberCreditCard, PaymentForm,AccountableAccount,Sector,Zona,Origin,Office,Falta,BirthDate,DrivingLicence";
            AssistMapper = _assistDataService.Mapper;
            EventManager.RegisterObserverSubsystem(BookingModule.GroupBookingIncident, this);
            EventManager.RegisterObserverSubsystem(BookingModule.BookingSubSystem, this);
        }


        public string ClientsConductorColumns {
            set
            {
                _clientColumns = value;
                RaisePropertyChanged();
            }
            get
            {
                return _clientColumns;
            }
         }
        /// <summary>
        ///  Generate a new view
        /// </summary>
        /// <param name="obj"></param>
        private void NewViewCommand(object obj)
        {
            var viewFactory = new ViewFactory<IBookingIncidentData, BookingIncidentSummaryViewObject>(RegionManager, _unityContainer, EventManager, _dataIncidentService, _dataIncidentService);
            var activeView = RegionManager.Regions[RegionNames.TabRegion].ActiveViews.FirstOrDefault();
           
            if (activeView is UserControl control)
            {
                if (control.DataContext is KarveViewModelBase baseViewModel)
                {
                    // its is me....
                    if (baseViewModel.ViewModelUri == ViewModelUri)
                    {
                        viewFactory.NewItem<BookingIncidentInfoView>("Incidencia Reserva", "karve://booking/incident/viewmodel?id=", DataSubSystem.BookingSubsystem, BookingModule.BookingSubSystem);
                    }
                }
            }
        }
        private void DeleteViewCommand(object obj)
        {
            var activeView = RegionManager.Regions[RegionNames.TabRegion].ActiveViews.FirstOrDefault();
            var viewDeleter = new ViewDeleter<IBookingIncidentData, BookingIncidentSummaryViewObject>(_dataIncidentService, DialogService, EventManager);

            if (!(activeView is UserControl control))
            {
                return;
            }

            if (!(control.DataContext is KarveViewModelBase baseViewModel))
            {
                return;
            }
            // its is me....
            if (baseViewModel.ViewModelUri != ViewModelUri)
            {
                return;
            }
            _dtoWrapperData.Value = DataObject;
            // craft for new payload.
            var payLoad = new DataPayLoad()
            {
                DataObject = _dtoWrapperData,
                HasDataObject = true,
                ObjectPath = ViewModelUri,
                PrimaryKeyValue = PrimaryKeyValue,
                Sender = ViewModelUri.ToString(),
                PayloadType = DataPayLoad.Type.UpdateView
            };
            // Delete failed.
            if (!viewDeleter.DeleteView(payLoad))
            {
                return;
            }
            // Delete success.
            viewDeleter.Notify(ViewModelUri.ToString(), BookingModule.BookingSubSystem);
            UnregisterToolBar(payLoad.PrimaryKeyValue);
            DeleteRegion();
        }
        private void SaveViewCommand(object obj)
        {
            _dtoWrapperData.Valid = true;

            var saver = new ViewSaver<IBookingIncidentData, BookingIncidentSummaryViewObject, BookingIncidentViewObject>(RegionManager, _dataIncidentService, _dtoWrapperData);
            var changed = IsChanged;
            var opState = OperationalState;
            
            if (!saver.Save(PrimaryKeyValue, _dtoWrapperData.Value, ref changed, ref opState))
            {
                return;
            }
            // saved with success.
            DialogService.ShowMessage("Incidencia", "Nueva incidencia registrata!");
            IsChanged = changed;
            OperationalState = opState;
        }
        private void OnChangedField(object ev)
        {
            if (ev is IDictionary<string, object> eventData)
            {

                OnChangedCommand(DataObject,
                                       eventData,
                                       DataSubSystem.BookingSubsystem,
                                       BookingModule.GroupBookingIncident,
                                       ViewModelUri.ToString());
            }
        }

        public override void DisposeEvents()
        {
            base.DisposeEvents();
            EventManager.DeleteObserverSubSystem(BookingModule.GroupBookingIncident, this);
            UnregisterToolBar(PrimaryKeyValue, _newCommand, _saveCommand, _deleteCommand);
        }

        private void OnAssistCommand(object param)
        {
            IDictionary<string, string> values = (Dictionary<string, string>)param;
            var assistTableName = values.ContainsKey("AssistTable") ? values["AssistTable"] as string : null;
            var assistQuery = values.ContainsKey("AssistQuery") ? values["AssistQuery"] as string : null;
            this.AssistNotifierInitialized = NotifyTaskCompletion.Create<bool>(AssistQueryRequestHandler(assistTableName, assistQuery), (sender, ev) => {
                if (sender is INotifyTaskCompletion<bool> notified)
                {
                    if (notified.IsFaulted)
                    {
                        DialogService?.ShowErrorMessage(notified.ErrorMessage);
                    }
                }
            });
        }
        private async Task<bool> AssistQueryRequestHandler(string assistTableName, string assistQuery)
        {
            var collectionValue = await AssistMapper.ExecuteAssistGeneric(assistTableName, assistQuery);

            switch (assistTableName)
            {
                
                case "CLIENT_ASSIST":
                    {
                        BookingIncidentClientDto = (IEnumerable<ClientSummaryExtended>)collectionValue;
                        break;
                    };
                
                case "SUPPLIER_ASSIST":
                    {
                        BookingIncidentSupplierDto = (IEnumerable<SupplierSummaryViewObject>)collectionValue;
                        break;
                    };
                
                case "OFFICE_ASSIST":
                    {
                        BookingIncidentOfficeDto = (IEnumerable<OfficeViewObject>)collectionValue;
                        break;
                    };

                case "DRIVER_ASSIST_1":
                    {
                        BookingIncidentDriversDto = (IEnumerable<ClientSummaryExtended>)collectionValue;
                        break;
                    };
                case "VEHICLE_ASSIST":
                    {
                        BookingIncidentVehicleDto = (IEnumerable<VehicleSummaryViewObject>)collectionValue;
                        break;
                    };
                
                case "BOOKING_INCIDENT_TYPE":
                    {
                        BookingIncidentTypeDto = (IEnumerable<IncidentTypeViewObject>)collectionValue;
                        break;
                    };
                
            }
            return true;
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
                deleted = await _dataIncidentService.DeleteAsync(_dtoWrapperData).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                DialogService?.ShowErrorMessage(e.Message);
            }
            return deleted;
        }

        public bool CreateRegionManagerScope => false;


        public void IncomingPayload(DataPayLoad dataPayLoad)
        {
            if (dataPayLoad == null) return;
            if (dataPayLoad.PayloadType != DataPayLoad.Type.Insert)
            {
                if ((dataPayLoad.Sender != null) && (dataPayLoad.Sender.Equals(ViewModelUri)))
                {
                    return;
                }
            }
                var interpreter = new PayloadInterpeter<IBookingIncidentData>();
                var currentId = _dataIncidentService.NewId();
                interpreter.Init = Init;
                interpreter.CleanUp = CleanUp;

                if (string.IsNullOrEmpty(PrimaryKeyValue)) PrimaryKeyValue = dataPayLoad.PrimaryKeyValue;

                if (string.IsNullOrEmpty(PrimaryKeyValue))
                    return;
                // i check what i have to do.
                OperationalState = interpreter.CheckOperationalType(dataPayLoad);
                // i act on the system and notify the subsystem
                interpreter.ActionOnPayload(dataPayLoad, PrimaryKeyValue, currentId, SubSystem,
                    EventSubsystem.BookingSubsystemVm);
            
        }

        protected void CleanUp(DataPayLoad payLoad, DataSubSystem subsystem, string eventSubsystem)
        {
            //    DeleteItem(payLoad);
        }
        /// <summary>
        ///  Called at initializing the form.
        /// </summary>
        /// <param name="value">Value of the PrimaryKeyValue</param>
        /// <param name="payload">Value of the Payload</param>
        /// <param name="insertion">True if it is inserted or false otherwise</param>
        protected void Init(string value, DataPayLoad payload, bool insertion)
        {
            if (payload == null)
            {
                throw new ArgumentNullException("Invalid Payload");
            }
            if (payload.DataObject==null)
            {
                return;
            }
           if (!(payload.DataObject is IBookingIncidentData))
            {
                return;
            }
            _dtoWrapperData = payload.DataObject as IBookingIncidentData;
            DataObject = _dtoWrapperData.Value;
            
             
            RegisterToolBar();
            ActiveSubSystem();
        }

        public BookingIncidentViewObject DataObject
        {
            set
            {
                _dataObject = value;
                RaisePropertyChanged();
            }
            get => _dataObject;
        }
      
      
        public override bool DeleteView(object key)
        {
            base.DeleteView(key);
            DataPayLoad payload = new DataPayLoad();
            payload.DataObject = _dtoWrapperData;
            payload.HasDataObject = true;
            payload.PrimaryKeyValue = DataObject.Code;
            DeleteItem(payload);
            return true;
        }
        protected override void DeleteItem(DataPayLoad payLoad)
        {
            var isDeleted = false;
            NotifyTaskCompletion.Create(DeleteAsync(payLoad),
                (sender, args) =>
                {

                    if (sender is INotifyTaskCompletion<bool> taskCompletion)
                    {
                        if (taskCompletion.IsFaulted)
                            DialogService?.ShowErrorMessage("Error during deleting");

                        if (!taskCompletion.IsSuccessfullyCompleted) return;
                        isDeleted = true;

                    }
                });

            if (!isDeleted)
            {
                return;
            }
            var dataPayLoad = new DataPayLoad
            {
                Sender = ViewModelUri.ToString(),
                PayloadType = DataPayLoad.Type.UpdateView
            };
            EventManager.NotifyObserverSubsystem("{data.name}Group", dataPayLoad);
            UnregisterToolBar(payLoad.PrimaryKeyValue);
            DeleteRegion();
        }
        private async Task<bool> DeleteAsync([NotNull] DataPayLoad payLoad)
        {
            if (payLoad == null)
            {
                throw new ArgumentNullException(nameof(payLoad));
            }
            var retValue = false;

            if (!(payLoad.DataObject is IBookingIncidentData request))
            {
                return false;
            }
            try
            {
                retValue = await _dataIncidentService.DeleteAsync(request).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                var msg = "Error during saving request:" + ex.Message;
                DialogService?.ShowErrorMessage(msg);
            }
            return retValue;
        }
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }

        protected override string GetRouteName(string name)
        {
            return ViewModelUri.ToString();
        }

        protected override void SetRegistrationPayLoad(ref DataPayLoad payLoad)
        {
            payLoad.Subsystem = DataSubSystem.BookingSubsystem;
            payLoad.ObjectPath = ViewModelUri;
            payLoad.Sender = ViewModelUri.ToString();
            payLoad.HasNewCommand = true;
            payLoad.HasSaveCommand = true;
            payLoad.HasDeleteCommand = true;
            payLoad.NewCommand = _newCommand;
            payLoad.SaveCommand = _saveCommand;
            payLoad.DeleteCommand = _deleteCommand;

        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }
     
        #region Exposing View Objects
      
        
        public IEnumerable<OfficeViewObject> BookingIncidentOfficeDto
        {
            get => _bookingIncidentOfficeDtoValue;
            set
            {
                _bookingIncidentOfficeDtoValue = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<ClientSummaryExtended> BookingIncidentClientDto
        {
            get => _bookingIncidentClientDtoValue;
            set
            {
                _bookingIncidentClientDtoValue = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<ClientSummaryExtended> BookingIncidentDriversDto
        {
            get => _bookingIncidentDriverDtoValue;
            set
            {
                _bookingIncidentDriverDtoValue = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<SupplierSummaryViewObject> BookingIncidentSupplierDto {
            get => _bookingIncidentSupplierDtoValue;
            set
            {
                _bookingIncidentSupplierDtoValue = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        ///  Get or Set the vehicle columns
        /// </summary>
        public string VehicleColumns
        {
            set
            {
                _vehicleColumns = value;
                RaisePropertyChanged("VehicleColumns");
            }
            get => _vehicleColumns;
        }
        /// <summary>
        ///  Set or get the incident vehicle dto for the list.
        /// </summary>
        public IEnumerable<VehicleSummaryViewObject> BookingIncidentVehicleDto
        {
            get => _bookingIncidentVehicleDtoValue;
            set
            {
                _bookingIncidentVehicleDtoValue = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<IncidentTypeViewObject> BookingIncidentTypeDto
        {
            get => _bookingIncidentTypeDtoValue;
            set
            {
                _bookingIncidentTypeDtoValue = value;
                RaisePropertyChanged();
            }
        }
        #endregion DtoProperties
    }
}