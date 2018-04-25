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
using System.Collections.ObjectModel;
using DataAccessLayer.Model;
using Microsoft.Practices.Unity;

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
            base.ConfigureAssist();
            AssistCommand = new DelegateCommand<object>(OnAssistCommand);
            ItemChangedCommand = new DelegateCommand<object>(OnChangedField);
            AssistExecuted += OfficeAssistResult; 
              
            DataObject = new OfficeDtos();
            DateTime dt = DateTime.Now;
            _provinciaDto = new ObservableCollection<ProvinciaDto>();
            ProvinciaDto = _provinciaDto;
            var officeHelper = new Office();
            officeHelper.ProvinciaDto = new ObservableCollection<ProvinciaDto>();
            OfficeHelper = officeHelper;
            CurrentYear = dt.Year.ToString();
            ViewModelUri = new Uri("karve://office/viewmodel?id=" + Guid.ToString());
            TimePickerSaveCommand = new DelegateCommand<object>(OnPickerSaveCommand);
            TimePickerDeleteCommand= new DelegateCommand<object>(OnPickerDeleteCommand);
            TimePickerResetCommand = new DelegateCommand<object>(OnPickerResetCommand);
            EventManager.RegisterObserverSubsystem(MasterModuleConstants.OfficeSubSytemName, this);
            ActiveSubSystem();

        }

        private void OnPickerResetCommand(object obj)
        {
            throw new NotImplementedException();
        }

        private void OnPickerDeleteCommand(object obj)
        {
            throw new NotImplementedException();
        }

        private void OnPickerSaveCommand(object obj)
        {
            throw new NotImplementedException();
        }
        #endregion
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
      

        public DateTime HolidayTimeFrom
        {
            set
            {
                _holidayTimeFrom = value;
                RaisePropertyChanged();
            }
            get => _holidayTimeFrom;
        }

        public DateTime HolidayTimeTo
        {
            set { _holidayTimeTo = value;
                RaisePropertyChanged();
            }
            get => _holidayTimeTo;
        }
        /// <summary>
        ///  Days. It is the weekly opening.
        /// </summary>
        public ObservableCollection<DailyTime> Days
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

        /// <summary>
        ///  ClientDto.
        /// </summary>
        public IEnumerable<ClientSummaryDto> ClientDto
        {
            get => _client;
            set
            {
                _client = value;
                RaisePropertyChanged();
            }
        }

       
        #endregion


        #region Public Methods

        /// <summary>
        ///  Incoming Payload
        /// </summary>
        /// <param name="payload">Data payload</param>
        public void IncomingPayload(DataPayLoad payload)
        {


            if (payload != null)
            {

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
                            DataObject = _officeData.Value;
                            OfficeHelper = officeData;
                            OfficeHelper.ProvinciaDto = _officeData.Value.Province ?? new ObservableCollection<ProvinciaDto>();
                            OfficeHelper.CityDto = _officeData.Value.City ?? new ObservableCollection<CityDto>();
                            //PrimaryKeyValue = primaryKey;
                            //var value = new List<DailyTime>(DataObject.TimeTable);
                            Logger.Info(
                                "OfficeInfoViewModel has activated the client subsystem as current with directive " +
                                payload.PayloadType.ToString());
                            ActiveSubSystem();
                            
                        }
                        break;

                }
            }
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
            var value = await AssistMapper.ExecuteAssist(assistTableName, assistQuery);
            bool retValue = false;
            if (value != null)
            {
                switch (assistTableName)
                {
                    case "CITY_ASSIST":
                        {
                            OfficeHelper.CityDto = (IEnumerable<CityDto>)value;
                            retValue = true;
                            break;
                        }
                    case "PROVINCE_ASSIST":
                    {
                            OfficeHelper.ProvinciaDto = (IEnumerable<ProvinciaDto>)value;
                            retValue = true;
                            break;
                        }
                    case "COUNTRY_ASSIST":
                        {
                            OfficeHelper.CountryDto = (IEnumerable<CountryDto>)value;
                            retValue = true;
                            break;
                        }
                     case "CONTABLE_DELEGA_ASSIST":
                        {
                            OfficeHelper.ContableDelegaDto = (IEnumerable<DelegaContableDto>) value;
                            retValue = true;
                            break;
                        }
                    case "OFFICE_ZONE_ASSIST":
                        {
                            OfficeHelper.ClientZoneDto = (IEnumerable<ZonaOfiDto>)value;
                            retValue = true;

                            break;
                        }
                    case "BROKER_ASSIST":
                        {
                            BrokersDto = (IEnumerable<CommissionAgentSummaryDto>)value;
                            retValue = true;
                            break;
                        }
                    case "CLIENT_ASSIST":
                        {
                            ClientDto = (IEnumerable<ClientSummaryDto>)value;
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
            EventManager.DeleteMailBoxSubscription(_mailBoxName);
            EventManager.DeleteObserverSubSystem(MasterModuleConstants.OfficeSubSytemName, this);
            if (AssistExecuted != null)
            {
                AssistExecuted -= OfficeAssistResult;
            }
        }

        /* TODO this means that we shal have an interface segragation, at the base class.
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
        #endregion
     

        public DelegateCommand<object> TimePickerSaveCommand { set; get; }
        public DelegateCommand<object> TimePickerDeleteCommand { set; get; }
        public DelegateCommand<object> TimePickerResetCommand { get; }


        #region Private Fields
        private IOfficeData _officeData = new Office();
        private string _mailBoxName;
        private IHelperBase _officeHelper = new Office();
        private OfficeDtos _currentOfficeDto = new OfficeDtos();
        private string _currentYear;
        private IEnumerable<CommissionAgentSummaryDto> _brokers;
        private IEnumerable<ClientSummaryDto> _client;
        private IEnumerable<CurrenciesDto> _currencyDto;
        private ObservableCollection<DailyTime> _openDays;
        private DateTime _holidayTimeFrom;
        private DateTime _holidayTimeTo;
        private IEnumerable<ProvinciaDto> _provinciaDto;
        private UnityContainer _unityContainer;

        #endregion


    }

}
