using KarveCommon.Generic;
using KarveCommon.Services;
using KarveCommonInterfaces;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
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

namespace BookingModule.ViewModels
{
    /// <summary>
    ///  View model that has the responsability for the booking incident form.
    ///  
    /// </summary>
    public class BookingIncidentInfoViewModel : KarveRoutingBaseViewModel, ICreateRegionManagerScope, IEventObserver, INavigationAware
    {
        private ICommand _deleteCommand;
        private ICommand _saveCommand;
        private DelegateCommand<object> _newCommand;
        private IBookingIncidentDataService _dataIncidentService;
        private BookingIncidentDto _dataObject;

        private IAssistDataService _assistDataService;
        private IBookingIncidentData _domainObject;
        private IKarveNavigator _navigator;
        private IUserSettings _userSettings;
        private IUnityContainer _unityContainer;
        #region auxhelpers
        private IEnumerable<OfficeDtos> _bookingIncidentOfficeDtoValue;
        private IEnumerable<ClientSummaryExtended> _bookingIncidentClientDtoValue;
        private IEnumerable<ClientSummaryExtended> _bookingIncidentDriverDtoValue;
        private IEnumerable<IncidentTypeDto> _bookingIncidentTypeDtoValue;
        private IEnumerable<SupplierSummaryDto> _bookingIncidentSupplierDtoValue;
        private IEnumerable<VehicleSummaryDto> _bookingIncidentVehicleDtoValue;
        private string _vehicleColumns;
        private string _clientColumns;
        #endregion

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
            _userSettings = configurationService.GetUserSettings();
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
            var viewFactory = new ViewFactory<IBookingIncidentData, BookingIncidentSummaryDto>(RegionManager, _unityContainer, EventManager, _dataIncidentService, _dataIncidentService);
            var activeView = RegionManager.Regions[RegionNames.TabRegion].ActiveViews.FirstOrDefault();
            /// i shall check that i am on foreground
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
            var viewDeleter = new ViewDeleter<IBookingIncidentData, BookingIncidentSummaryDto>(_dataIncidentService, DialogService, EventManager);
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
                        _domainObject.Value = DataObject;
                        DataPayLoad payLoad = new DataPayLoad()
                        {
                            DataObject = _domainObject,
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
        private void SaveViewCommand(object obj)
        {
            _domainObject.Valid = true;

            var saver = new ViewSaver<IBookingIncidentData, BookingIncidentSummaryDto, BookingIncidentDto>(RegionManager, _dataIncidentService, _domainObject);
            var changed = IsChanged;
            var opState = OperationalState;
           
            if (saver.Save(PrimaryKeyValue, _domainObject.Value, ref changed, ref opState))
            {
                DialogService.ShowMessage("Incidencia", "Nueva incidencia registrata!");
                IsChanged = changed;
                OperationalState = opState;
            }
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
            string assistTableName = values.ContainsKey("AssistTable") ? values["AssistTable"] as string : null;
            string assistQuery = values.ContainsKey("AssistQuery") ? values["AssistQuery"] as string : null;
            this.AssistNotifierInitialized = NotifyTaskCompletion.Create<bool>(AssistQueryRequestHandler(assistTableName, assistQuery), (sender, ev) => {
                if (sender is INotifyTaskCompletion<bool> notifed)
                {
                    if (notifed.IsFaulted)
                    {
                        DialogService?.ShowErrorMessage(notifed.ErrorMessage);
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
                        BookingIncidentSupplierDto = (IEnumerable<SupplierSummaryDto>)collectionValue;
                        break;
                    };
                
                case "OFFICE_ASSIST":
                    {
                        BookingIncidentOfficeDto = (IEnumerable<OfficeDtos>)collectionValue;
                        break;
                    };

                case "DRIVER_ASSIST_1":
                    {
                        BookingIncidentDriversDto = (IEnumerable<ClientSummaryExtended>)collectionValue;
                        break;
                    };
                case "VEHICLE_ASSIST":
                    {
                        BookingIncidentVehicleDto = (IEnumerable<VehicleSummaryDto>)collectionValue;
                        break;
                    };
                
                case "BOOKING_INCIDENT_TYPE":
                    {
                        BookingIncidentTypeDto = (IEnumerable<IncidentTypeDto>)collectionValue;
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
                deleted = await _dataIncidentService.DeleteAsync(_domainObject).ConfigureAwait(false);
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
                var interpeter = new PayloadInterpeter<IBookingIncidentData>();
                var currentId = _dataIncidentService.NewId();
                interpeter.Init = Init;
                interpeter.CleanUp = CleanUp;

                if (string.IsNullOrEmpty(PrimaryKeyValue)) PrimaryKeyValue = dataPayLoad.PrimaryKeyValue;

                if (string.IsNullOrEmpty(PrimaryKeyValue))
                    return;
                // i checkj what i have to do.
                OperationalState = interpeter.CheckOperationalType(dataPayLoad);
                // i act baed on the system and notify the subsystem
                interpeter.ActionOnPayload(dataPayLoad, PrimaryKeyValue, currentId, SubSystem,
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
            if (payload.DataObject==null)
            {
                return;
            }
           if (!(payload.DataObject is IBookingIncidentData))
            {
                return;
            }
            _domainObject = payload.DataObject as IBookingIncidentData;
            DataObject = _domainObject.Value;
            
             
            RegisterToolBar();
            ActiveSubSystem();
        }

        public BookingIncidentDto DataObject
        {
            set
            {
                _dataObject = value;
                RaisePropertyChanged();
            }
            get
            {

                return _dataObject;
            }
        }
      
      
        public override bool DeleteView(object key)
        {
            base.DeleteView(key);
            DataPayLoad payload = new DataPayLoad();
            payload.DataObject = _domainObject;
            payload.HasDataObject = true;
            payload.PrimaryKeyValue = DataObject.Code;
            DeleteItem(payload);
            return true;
        }
        protected override void DeleteItem(DataPayLoad payLoad)
        {
            bool isDeleted = false;
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

            if (isDeleted)
            {
                var dataPayLoad = new DataPayLoad
                {
                    Sender = ViewModelUri.ToString(),
                    PayloadType = DataPayLoad.Type.UpdateView
                };
                EventManager.NotifyObserverSubsystem("{data.name}Group", dataPayLoad);
                UnregisterToolBar(payLoad.PrimaryKeyValue);
                DeleteRegion();
            }
        }
        private async Task<bool> DeleteAsync(DataPayLoad payLoad)
        {
            bool retValue = false;
            if (payLoad.DataObject is IBookingIncidentData request)
            {
                try
                {
                    retValue = await _dataIncidentService.DeleteAsync(request).ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    var msg = "Error during saving request:" + ex.Message;
                    DialogService?.ShowErrorMessage(msg);
                }
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
     
        #region DtoProperties
      
        
        public IEnumerable<OfficeDtos> BookingIncidentOfficeDto
        {  get
            {
                return _bookingIncidentOfficeDtoValue;
            }
            set
            {
                _bookingIncidentOfficeDtoValue = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<ClientSummaryExtended> BookingIncidentClientDto
        {
            get
            {
                return _bookingIncidentClientDtoValue;
            }
            set
            {
                _bookingIncidentClientDtoValue = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<ClientSummaryExtended> BookingIncidentDriversDto
        {
            get
            {
                return _bookingIncidentDriverDtoValue;
            }
            set
            {
                _bookingIncidentDriverDtoValue = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<SupplierSummaryDto> BookingIncidentSupplierDto {
            get
            {
                return _bookingIncidentSupplierDtoValue;
            }
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
            get
            {
                return _vehicleColumns;
            }
        }
        /// <summary>
        ///  Set or get the incident vehicle dto for the list.
        /// </summary>
        public IEnumerable<VehicleSummaryDto> BookingIncidentVehicleDto
        {
            get
            {
                return _bookingIncidentVehicleDtoValue;
            }
            set
            {
                _bookingIncidentVehicleDtoValue = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<IncidentTypeDto> BookingIncidentTypeDto
        {
            get
            {
                return _bookingIncidentTypeDtoValue;
            }
            set
            {
                _bookingIncidentTypeDtoValue = value;
                RaisePropertyChanged();
            }
        }
        #endregion DtoProperties
    }
}