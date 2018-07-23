using KarveCommon.Services;
using KarveCommonInterfaces;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using MasterModule.Common;
using Prism.Commands;
using Prism.Regions;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel;
using KarveCommon.Generic;
using System.Diagnostics.Contracts;
using KarveDataServices.DataObjects;
using System;
using DataAccessLayer.Model;
using KarveCommon;
using Microsoft.Practices.Unity;
using System.Linq;
using System.Windows.Controls;
using MasterModule.Views;
using System.Windows.Input;
using KarveControls;

namespace MasterModule.ViewModels
{

    internal sealed class OfficeInfoViewModel : MasterInfoViewModuleBase, IEventObserver, IDisposeEvents
    {

        #region Constructor 
        /// <summary>
        /// Office Info view model.
        /// </summary>
        /// <param name="eventManager">Event manager</param>
        /// <param name="configurationService">Configuration service</param>
        /// <param name="dataServices">Data services</param>
        /// <param name="dialogService">Dialog services</param>
        /// <param name="container">Unity Manager</param>
        /// <param name="manager">Region Manager</param>
        /// <param name="requestController">Request controller</param>

        public OfficeInfoViewModel(IEventManager eventManager, IConfigurationService configurationService,
            IDataServices dataServices,
            IDialogService dialogService,
            IUnityContainer container,
            IRegionManager manager,
            IInteractionRequestController requestController) : base(eventManager, configurationService, dataServices, dialogService, manager, requestController)
        {
            _assistDataService = dataServices.GetAssistDataServices();
            _officeDataService = dataServices.GetOfficeDataServices();
            _newOfficeCommand = new DelegateCommand(OnNewOffice);
            _newOfficeSave = new DelegateCommand(OnSaveOffice);
            _provinciaDto = new System.Collections.ObjectModel.ObservableCollection<ProvinciaDto>();
            _openDays = new System.Collections.ObjectModel.ObservableCollection<DailyTime>();
            _currentHolidays = new Dictionary<DateTime, HolidayDto>();
            _currentPartOfDay = null;

            AssistMapper = _assistDataService.Mapper;
            AssistCommand = new DelegateCommand<object>(OnAssistCommand);
            ItemChangedCommand = new DelegateCommand<object>(OnChangedField);
            AssistExecuted += OfficeAssistResult;
            DataObject = new OfficeDtos();
            DateTime dt = DateTime.Now;
            ProvinciaDto = _provinciaDto;
            CurrentYear = dt.Year.ToString();
            ViewModelUri = new Uri("karve://office/viewmodel?id=" + Guid.ToString());
            TimePickerSaveCommand = new DelegateCommand<object>(OnPickerSaveCommand);
            TimePickerResetCommand = new DelegateCommand<object>(OnPickerResetCommand);
            SelectedDaysCommand = new DelegateCommand<object>(OnSelectedDaysCommand);
            PartOfDaySelection = new DelegateCommand<object>(OnPartOfDaySelection);
            EventManager.RegisterObserverSubsystem(MasterModuleConstants.OfficeSubSytemName, this);
            ActiveSubSystem();
        }
        private void OnPartOfDaySelection(object selectedValue)
        {
            if (selectedValue is int selectedIndex)
            {
                switch (selectedIndex)
                {
                    case -1: _currentPartOfDay = null; break;
                    case 0: _currentPartOfDay = 0; break;
                    case 1: _currentPartOfDay = 1; break;
                }
            }

        }
        private void CreateHolidayItem(ref HolidayDto dto, DateTime time, bool isNew, bool isDeleted)
        {
            dto.PARTE_DIA = _currentPartOfDay;
            dto.FESTIVO = time;
            dto.OFICINA = DataObject.Codigo;
            dto.HORA_DESDE = _holidayTimeSpanFrom;
            dto.HORA_HASTA = _holidayTimeSpanTo;
            dto.IsDirty = true;
            dto.IsDeleted = isDeleted;
            dto.IsNew = isNew;
            dto.IsChanged = true;
        }

        private void OnSelectedDaysCommand(object obj)
        {
            var dictionary = obj as IDictionary<HolidayCalendar.Status, object>;
            var holidays = dictionary[HolidayCalendar.Status.CurrentHolidays];
            var changedValue = dictionary[HolidayCalendar.Status.ChangedValue] as Tuple<DateTime, bool>;
            var holidayDto = new HolidayDto();
            CreateHolidayItem(ref holidayDto, changedValue.Item1, changedValue.Item2, !changedValue.Item2);
            _lastSelectedDay = holidayDto;
            if (_holidaysDates.Contains(holidayDto, new HolidayDateComparer()))
            {
                var holidayList = _holidaysDates.ToList();
                holidayList.Remove(holidayDto);
                if (!holidayDto.IsDeleted)
                {
                    holidayList.Add(holidayDto);
                }
                _holidaysDates = holidayList;
            }
            else
            {
                _holidaysDates = _holidaysDates.Union(new List<HolidayDto>() { holidayDto });
            }
        }
        public class HolidayDateComparer : IEqualityComparer<HolidayDto>
        {

            public bool Equals(HolidayDto x, HolidayDto y)
            {
                return ((x.FESTIVO == y.FESTIVO) &&
                    (x.OFICINA == y.OFICINA));
            }

            public int GetHashCode(HolidayDto obj)
            {
                //Get hash code for the Name field if it is not null. 
                int hashFestivo = obj.FESTIVO == null ? 0 : obj.FESTIVO.GetHashCode();

                //Get hash code for the Code field. 
                int hashOfficina = obj.OFICINA.GetHashCode();

                //Calculate the hash code for the product. 
                return hashFestivo ^ hashOfficina;
            }
        }
        public TimeSpan? HolidayTimeFrom
        {
            set { _holidayTimeSpanFrom = value; RaisePropertyChanged(); }
            get { return _holidayTimeSpanFrom; }
        }
        public TimeSpan? HolidayTimeTo
        {
            set { _holidayTimeSpanTo = value; RaisePropertyChanged(); }
            get { return _holidayTimeSpanTo; }
        }

        private void OnSaveOffice()
        {

            /* _officeData.Value = DataObject;
             NotifyTaskCompletion.Create(_officeDataService.SaveAsync(_officeData), (sender, ev) => {
                 if (sender is INotifyTaskCompletion<bool> task)
                 {

                 }
             });
             */
        }

        private void OnNewOffice()
        {
            var activeView = RegionManager.Regions[RegionNames.TabRegion].ActiveViews.FirstOrDefault();
            /// i shall check that i am on foreground
            if (activeView is UserControl control)
            {
                if (control.DataContext is KarveViewModelBase baseViewModel)
                {
                    // its is me....
                    if (baseViewModel.ViewModelUri == ViewModelUri)
                    {
                        NewItem();

                    }
                }
            }
        }
        protected override void NewItem()
        {

            string name = "NuevaOficina";
            string officeId = DataServices.GetOfficeDataServices().GetNewId();
            string viewNameValue = officeId + "." + name;
            // here shall be added to the region
            var navigationParameters = new NavigationParameters
            {
                { "Id", officeId },
                { ScopedRegionNavigationContentLoader.DefaultViewName, viewNameValue }
            };
            var uri = new Uri(typeof(OfficeInfoView).FullName + navigationParameters, UriKind.Relative);
            RegionManager.RequestNavigate("TabRegion", uri);
            DataPayLoad currentPayload = BuildShowPayLoadDo(viewNameValue);
            currentPayload.Subsystem = DataSubSystem.OfficeSubsystem;
            currentPayload.PayloadType = DataPayLoad.Type.Insert;
            currentPayload.PrimaryKeyValue = officeId;
            currentPayload.DataObject = _officeDataService.GetNewOfficeDo(officeId);
            currentPayload.HasDataObject = true;
            currentPayload.Sender = EventSubsystem.OfficeSummaryVm;
            EventManager.NotifyObserverSubsystem(MasterModuleConstants.OfficeSubSytemName, currentPayload);

        }
        private void OnPickerResetCommand(object obj)
        {
            CurrentVacationDays = this._savedVacationDays;
        }

        private async void OnPickerSaveCommand(object obj)
        {
            // it shall save juse the festivos.
            var value = _holidaysDates.FirstOrDefault(x => (x.FESTIVO == _lastSelectedDay.FESTIVO) && (x.OFICINA == _lastSelectedDay.OFICINA));
            if (value != null)
            {
                _holidaysDates = _holidaysDates.Union(new List<HolidayDto>() { value });
            }
            Task savedValueOnPicker = _officeDataService.SaveHolidaysAsync(_officeData.Value, _holidaysDates);
            await savedValueOnPicker;
            if (!savedValueOnPicker.IsFaulted)
            {
                DialogService?.ShowMessage("Festivo", "Festivo guardado con exito");
            }
            else
            {
                DialogService?.ShowErrorMessage("Error for the festivos");
            }
        }
        #endregion
        public ICommand PartOfDaySelection
        {
            set; get;
        }

        #region Properties
        /// <summary>
        ///  Data object
        /// </summary>
        public OfficeDtos DataObject
        {
            set
            {
                _currentOfficeDto = value;
                RaisePropertyChanged();
            }
            get => _currentOfficeDto;
        }

        /// <summary>
        ///  Helper data.
        /// </summary>
        public IHelperBase OfficeHelper
        {
            set
            {
                _officeHelper = value;
                RaisePropertyChanged();
            }
            get => _officeHelper;
        }

        public IEnumerable<ProvinciaDto> ProvinciaDto
        {
            get => _provinciaDto;
            set
            {
                _provinciaDto = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<CityDto> CityDto
        {
            get => _cityDto;
            set
            {
                _cityDto = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<CountryDto> CountryDto
        {
            get => _countryDto;
            set
            {
                _countryDto = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        ///  Days. It is the weekly opening.
        /// </summary>
        public System.Collections.ObjectModel.ObservableCollection<DailyTime> Days
        {
            get => _openDays;
            set
            {
                _openDays = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        ///  Show brokers data objects.
        /// </summary>
        public string CurrentYear
        {
            get => _currentYear;
            set
            {
                _currentYear = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        ///  BrokersDto
        /// </summary>
        public IEnumerable<CommissionAgentSummaryDto> BrokersDto
        {
            get => _brokers;
            set
            {
                _brokers = value;
                RaisePropertyChanged();
            }
        }
        // currency dto.
        public IEnumerable<CurrenciesDto> CurrenciesDto
        {
            set
            {
                _currencyDto = value;
                RaisePropertyChanged();
            }
            get => _currencyDto;
        }
        public IEnumerable<string> PartOfDay
        {
            get
            {
                return new List<string>() { "Mañana", "Tarde" };
            }
        }
        /// <summary>
        ///  ClientDto.
        /// </summary>
        public IEnumerable<ClientSummaryExtended> ClientDto
        {
            get => _client;
            set
            {
                _client = value;
                RaisePropertyChanged();
            }
        }
        public ICommand SelectedDaysCommand
        {
            set; get;
        }

        #endregion


        #region Public Methods

        /// <summary>
        ///  Incoming Payload
        /// </summary>
        /// <param name="payload">Data payload</param>
        public override void IncomingPayload(DataPayLoad payload)
        {


            if (payload != null)
            {
                if (string.IsNullOrEmpty(payload.PrimaryKeyValue))
                {
                    return;
                }
                IOfficeData dto = payload.DataObject as IOfficeData;
                if (dto.Value == null)
                {
                    return;
                }

                if ((payload.PayloadType == DataPayLoad.Type.Insert) &&
                (PrimaryKeyValue == payload.PrimaryKeyValue))
                {
                    return;
                }
                if (PrimaryKeyValue.Length > 0)
                {
                    // check if the message if for me.
                    if (dto.Value.NUM_OFI != PrimaryKeyValue)
                        return;
                }
                
                RegisterPrimaryKey(payload);
                // here i can fix the primary key
                /// FIXME-DRY (Dont repeat yourself): try to move to an upper class except for a couple of methods:
                /// a property called CurrentSubsystem.
                switch (payload.PayloadType)
                {
                    case DataPayLoad.Type.UpdateData:
                        {
                            if (payload.HasDataObject)
                            {
                                var clientData = payload.DataObject as OfficeDtos;
                                DataObject = clientData;
                            }
                            break;
                        }
                    case DataPayLoad.Type.UpdateView:
                    case DataPayLoad.Type.Show:
                        {
                            Init(PrimaryKeyValue, payload, false);
                            CurrentOperationalState = DataPayLoad.Type.Show;
                            break;
                        }
                    case DataPayLoad.Type.Insert:
                        {
                            CurrentOperationalState = DataPayLoad.Type.Insert;
                            PrimaryKeyValue = payload.PrimaryKeyValue;
                            if (string.IsNullOrEmpty(PrimaryKeyValue))
                            {
                                PrimaryKeyValue = DataServices.GetOfficeDataServices().GetNewId();
                            }
                            Init(PrimaryKeyValue, payload, true);
                            break;
                        }
                    case DataPayLoad.Type.Delete:
                        {

                            if (PrimaryKey == payload.PrimaryKey)
                            {
                                DeleteEventCleanup(payload.PrimaryKeyValue, PrimaryKeyValue, DataSubSystem.OfficeSubsystem,
                                    MasterModuleConstants.OfficeSubSytemName);
                                DeleteRegion(payload.PrimaryKeyValue);
                            }
                            break;
                        }
                }
            }
        }

        public void Init(string primaryKey, DataPayLoad payload, bool isInsert)
        {
            if (payload.HasDataObject)
            {
                Logger.Info("OfficeInfoViewModel has received payload type " + payload.PayloadType.ToString());

                switch (payload.DataObject)
                {
                    case null:
                        return;
                    case IOfficeData officeData:
                        {

                            _officeData = officeData;
                            _officeHelper = officeData;
                            DataObject = _officeData.Value;
                            OfficeHelper = officeData;
                            ProvinciaDto = _officeData.Value.Province;
                            CityDto = _officeData.Value.City;
                            CountryDto = _officeData.Value.Country;
                            ClientDto = _officeData.Value.ClientDto;
                            ContableDelegaDto = _officeData.Value.DelegaContable;
                            OfficeZoneDto = _officeData.Value.OfficeZone;
                            _holidaysDates = _officeData.Value.HolidayDates;
                            CreateHolidayMap(_officeData.Value.HolidayDates);
                            SavedVacationDays = CurrentVacationDays;
                            // no perf issues because at most 14 itmes.
                            CurrentYear = DateTime.Now.Year.ToString();
                            var value = new System.Collections.ObjectModel.ObservableCollection<DailyTime>(_officeData.Value.TimeTable);
                            Days = value;
                            Logger.Info(
                                "OfficeInfoViewModel has activated the client subsystem as current with directive " +
                                payload.PayloadType.ToString());
                            ActiveSubSystem();

                        }
                        break;

                }
            }
        }

        private void CreateHolidayMap(IEnumerable<HolidayDto> holidayDates)
        {
            _currentHolidays = new Dictionary<DateTime, HolidayDto>();
            foreach (var date in holidayDates)
            {
                _currentHolidays.Add(date.FESTIVO, date);
            }
            var value = new System.Collections.ObjectModel.ObservableCollection<DateTime>(_currentHolidays.Keys);
            CurrentVacationDays = value;
        }
        #endregion

        #region Protected Methods
        /// <summary>
        ///  This method set the registration payload.
        /// </summary>
        /// <param name="payLoad"></param>
        protected override void SetRegistrationPayLoad(ref DataPayLoad payLoad)
        {
            payLoad.PayloadType = DataPayLoad.Type.RegistrationPayload;
            payLoad.Subsystem = DataSubSystem.OfficeSubsystem;
            payLoad.NewCommand = this._newOfficeCommand;
            payLoad.HasNewCommand = true;
            payLoad.ObjectPath = ViewModelUri;
            payLoad.HasSaveCommand = true;
            payLoad.SaveCommand = _newOfficeSave;
        }
        #endregion

        #region Private Methods

        private void OnAssistCommand(object param)
        {
            IDictionary<string, string> values = (Dictionary<string, string>)param;
            string assistTableName = values.ContainsKey("AssistTable") ? values["AssistTable"] as string : null;
            string assistQuery = values.ContainsKey("AssistQuery") ? values["AssistQuery"] as string : null;
            AssistNotifierInitialized = NotifyTaskCompletion.Create<bool>(AssistQueryRequestHandler(assistTableName, assistQuery), AssistExecuted);
        }

        private void OfficeAssistResult(object sender, PropertyChangedEventArgs e)
        {
            string propertyName = e.PropertyName;
            if (propertyName.Equals("Status"))
            {
                if (AssistNotifierInitialized.IsSuccessfullyCompleted)
                {
                    bool value = AssistNotifierInitialized.Task.Result;
                    if (!value)
                    {
                        Logger.Error("Executed Assist invalid");
                    }

                }
            }




        }
        private async Task<bool> AssistQueryRequestHandler(string assistTableName, string assistQuery)
        {
            var value = await AssistMapper.ExecuteAssistGeneric(assistTableName, assistQuery);
            bool retValue = false;
            if (value != null)
            {
                switch (assistTableName)
                {
                    case "CITY_ASSIST":
                        {
                            CityDto = (IEnumerable<CityDto>)value;
                            retValue = true;
                            break;
                        }
                    case "PROVINCE_ASSIST":
                        {
                            ProvinciaDto = (IEnumerable<ProvinciaDto>)value;
                            retValue = true;
                            break;
                        }
                    case "COUNTRY_ASSIST":
                        {
                            CountryDto = (IEnumerable<CountryDto>)value;
                            retValue = true;
                            break;
                        }
                    case "CONTABLE_DELEGA_ASSIST":
                        {
                            ContableDelegaDto = (IEnumerable<DelegaContableDto>)value;
                            retValue = true;
                            break;
                        }
                    case "OFFICE_ZONE_ASSIST":
                        {
                            OfficeZoneDto = (IEnumerable<ZonaOfiDto>)value;
                            retValue = true;

                            break;
                        }
                    case "BROKER_ASSIST":
                        {
                            BrokersDto = (IEnumerable<CommissionAgentSummaryDto>)value;
                            retValue = true;
                            break;
                        }
                    case "CURRENCY_ASSIST":
                        {
                            CurrenciesDto = (IEnumerable<CurrenciesDto>)value;
                            break;
                        }
                }
                RaisePropertyChanged("OfficeHelper");

            }
            return retValue;
        }

        /// <summary>
        /// Change field.
        /// </summary>
        /// <param name="objectChanged">Event that comes from lower level.</param>
        private void OnChangedField(object objectChanged)
        {
            IDictionary<string, object> eventDictionary = (IDictionary<string, object>)objectChanged;
            OnChangedField(eventDictionary);
        }

        private void OnChangedField(IDictionary<string, object> eventDictionary)
        {

            DataPayLoad payLoad = BuildDataPayload(eventDictionary);
            payLoad.Subsystem = DataSubSystem.OfficeSubsystem;
            payLoad.SubsystemName = MasterModuleConstants.OfficeSubSytemName;
            payLoad.PayloadType = DataPayLoad.Type.Update;
            if ((payLoad != null) && (payLoad.DataObject is OfficeDtos dto))
            {
                // the first update is on and we can add a value.
                if (dto.IsNew)
                {
                    DataObject.IsNew = false;
                }
                if (dto.Codigo == null)
                    return;
            }
            SetBasePayLoad(eventDictionary, ref payLoad);

            ChangeFieldHandlerDo<OfficeDtos> handlerDo = new ChangeFieldHandlerDo<OfficeDtos>(EventManager, DataSubSystem.OfficeSubsystem);

            if (CurrentOperationalState == DataPayLoad.Type.Insert)
            {
                handlerDo.OnInsert(payLoad, eventDictionary);
            }
            else
            {
                payLoad.PayloadType = DataPayLoad.Type.Update;
                handlerDo.OnUpdate(payLoad, eventDictionary);
            }
        }
        // <summary>
        ///  This register the primary key
        /// </summary>
        /// <param name="payLoad">Payload to be registered</param>
        private void RegisterPrimaryKey(DataPayLoad payLoad)
        {
            Contract.Assert(PrimaryKeyValue != null, "RegisterPrimaryKey error");
            Contract.Assert(payLoad != null, "RegisterPrimaryKey error");
            if (PrimaryKeyValue.Length == 0)
            {
                PrimaryKeyValue = payLoad.PrimaryKeyValue;
                _mailBoxName = "Office." + PrimaryKeyValue + "." + UniqueId;
                if (!string.IsNullOrEmpty(PrimaryKeyValue))
                {
                    if (MailBoxHandler != null)
                    {
                        EventManager.RegisterMailBox(_mailBoxName, MailBoxHandler);
                    }
                }
            }
        }

        public override void DisposeEvents()
        {
            base.DisposeEvents();
            // cleanup the toolbar keeper.
            DisposeToolBar();
            // Unregister itself.
            UnregisterToolBar(PrimaryKeyValue, _newOfficeCommand, null, null);
            EventManager.DeleteMailBoxSubscription(_mailBoxName);
            EventManager.DeleteObserverSubSystem(MasterModuleConstants.OfficeSubSytemName, this);
            if (AssistExecuted != null)
            {
                AssistExecuted -= OfficeAssistResult;
            }
        }

        /* TODO this means that we shall have an interface segragation, at the base class.
        * The interface and related stuff to a grid shall be separated in another class to give an option to implement or not
        * that interface.
        */
        internal override Task SetClientData(ClientSummaryExtended p, VisitsDto b)
        {
            var t = Task.FromResult(0);
            return t;
        }

        internal override Task SetVisitContacts(ContactsDto p, VisitsDto visitsDto)
        {
            var t = Task.FromResult(0);
            return t;
        }

        internal override Task SetBranchProvince(ProvinciaDto p, BranchesDto b)
        {
            var t = Task.FromResult(0);
            return t;
        }

        internal override Task SetVisitReseller(ResellerDto param, VisitsDto b)
        {
            var t = Task.FromResult(0);
            return t;
        }

        public override void Dispose()
        {
            throw new NotImplementedException();
        }
        #endregion


        public DelegateCommand<object> TimePickerSaveCommand { set; get; }
        public DelegateCommand<object> TimePickerDeleteCommand { set; get; }
        public DelegateCommand<object> TimePickerResetCommand { get; }
        public IEnumerable<DelegaContableDto> ContableDelegaDto
        {
            get
            {
                return _contableDto;
            }
            set
            {
                _contableDto = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<ZonaOfiDto> OfficeZoneDto
        {
            get
            {
                return _officeZoneDto;
            }
            set
            {
                _officeZoneDto = value;
                RaisePropertyChanged();
            }
        }

        private IEnumerable<HolidayDto> _holidaysDates;

        public System.Collections.ObjectModel.ObservableCollection<DateTime> CurrentVacationDays
        {
            get
            {
                return _currentVacationDays;
            }
            set
            {
                _currentVacationDays = value;
                RaisePropertyChanged();
            }
        }
        public System.Collections.ObjectModel.ObservableCollection<DateTime> SavedVacationDays
        {
            get
            {
                return _savedVacationDays;
            }
            set
            {
                _savedVacationDays = value;
                RaisePropertyChanged();
            }
        }



        #region Private Fields
        private IOfficeData _officeData = new Office();
        private string _mailBoxName;
        private IHelperBase _officeHelper = new Office();
        private IAssistDataService _assistDataService;
        private OfficeDtos _currentOfficeDto = new OfficeDtos();
        private string _currentYear;
        private IEnumerable<CommissionAgentSummaryDto> _brokers;
        private IEnumerable<ClientSummaryExtended> _client;
        private IEnumerable<CurrenciesDto> _currencyDto;
        private System.Collections.ObjectModel.ObservableCollection<DailyTime> _openDays;
        private IEnumerable<ProvinciaDto> _provinciaDto;
        private IEnumerable<CityDto> _cityDto;
        private IEnumerable<CountryDto> _countryDto;
        private IEnumerable<DelegaContableDto> _contableDto;
        private IEnumerable<ZonaOfiDto> _officeZoneDto;
        private DelegateCommand _newOfficeCommand;
        private DelegateCommand _newOfficeSave;
        private IOfficeDataServices _officeDataService;
        private TimeSpan? _holidayTimeSpanFrom;
        private TimeSpan? _holidayTimeSpanTo;
        private HolidayDto _lastSelectedDay;
        private IDictionary<DateTime, HolidayDto> _currentHolidays;
        private System.Collections.ObjectModel.ObservableCollection<DateTime> _currentVacationDays = new System.Collections.ObjectModel.ObservableCollection<DateTime>();
        private byte? _currentPartOfDay;
        private System.Collections.ObjectModel.ObservableCollection<DateTime> _savedVacationDays;
        private System.Collections.ObjectModel.ObservableCollection<DateTime> _savedVactionDays;


        #endregion


    }

}
