using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using KarveCommon.Services;
using KarveCommonInterfaces;
using KarveDataServices;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;
using MasterModule.Common;
using Prism.Regions;
using Prism.Commands;
using System.Windows;
using System.Windows.Controls;
using DataAccessLayer.DataObjects;
using KarveCommon.Generic;
using MasterModule.Views;
using Syncfusion.UI.Xaml.Grid;
using System.ComponentModel;
using DataAccessLayer.SQL;

namespace MasterModule.ViewModels
{
    /// <summary>
    /// This class is responsible for allowing the client info view to communicate with the other levels.
    /// </summary>
    class ClientsInfoViewModel: MasterInfoViewModuleBase, IEventObserver, IDisposeEvents
    {
        #region Private Fields
        private IClientData _clientData;
        private IClientDataServices _clientDataServices;
        private IHelperData _helperData;
        private object _company;
        private bool _stateVisible;
        private string _clientRegion;
        private ClientDto _currentClientDo = new ClientDto();
        private string _driverZone;
        private IEnumerable<CityDto> _currentCities = new List<CityDto>();
        private IEnumerable<ClientTypeDto> _clientTypeDto = new List<ClientTypeDto>();
      
        private IEnumerable<ClientSummaryDto> _listOfDrivers;
        private PropertyChangedEventHandler eventHandler;
        private INotifyTaskCompletion<IEnumerable<ClientSummaryDto>> _driversNotification;
        #endregion

        /// <summary>
        ///  Primary  key on branches
        /// </summary>
        protected event SetPrimaryKey<BranchesDto> _onBranchesPrimaryKey;
        /// <summary>
        ///  Primary key on contacts.
        /// </summary>
        protected event SetPrimaryKey<ContactsDto> _onContactsPrimaryKey;


        /// <summary>
        ///  ClientsInfoViewModel constructor.
        /// </summary>
        /// <param name="eventManager">Event manager</param>
        /// <param name="configurationService">Configuration service</param>
        /// <param name="dataServices">Data Service</param>
        /// <param name="manager">Region Manager</param>
        public ClientsInfoViewModel(IEventManager eventManager, IConfigurationService configurationService, IDataServices dataServices, IDialogService dialogService, IAssistService service, IRegionManager manager) : base(eventManager, configurationService, dataServices,dialogService,service, manager)
        {
            base.ConfigureAssist();

            ConfigurationService = configurationService;
            MailBoxHandler += MessageHandler;
            _onBranchesPrimaryKey += ClientOnBranchesPrimaryKey;
            _onContactsPrimaryKey += ClientOnContactsPrimaryKey;
            IsVisible = Visibility.Collapsed;
            EventManager.RegisterObserverSubsystem(MasterModuleConstants.ClientSubSystemName, this);
            _clientDataServices = dataServices.GetClientDataServices();
            InitVmCommands();
            
            ClientInfoRightRegionName = CreateNameRegion("RightRegion");
            DriverZoneRegionName = CreateNameRegion("DriverZoneRegion");
            StateVisible = true;
            _clientData =_clientDataServices.GetNewClientAgentDo("0");
            eventHandler += OnDriverUpdate;
            ActiveSubSystem();
           
          
        }
        /// <summary>
        ///  Handle the notification of the driver event. 
        /// </summary>
        /// <param name="sender">Sender of the drivers.</param>
        /// <param name="e">Event coming</param>
        private void OnDriverUpdate(object sender, PropertyChangedEventArgs e)
        {
            INotifyTaskCompletion<IEnumerable<ClientSummaryDto>> value = sender as INotifyTaskCompletion<IEnumerable<ClientSummaryDto>>;
            if (value != null)
            {
                if (value.IsSuccessfullyCompleted)
                {
                  DriversList = value.Task.Result;
                }
            }
        }
        private void UpdateListOfDrivers()
        {
            _driversNotification = NotifyTaskCompletion.Create<IEnumerable<ClientSummaryDto>>(DataServices.GetClientDataServices().GetClientSummaryDo(GenericSql.ExtendedClientsSummaryQuery), eventHandler); 
        }
        /// <summary>
        ///  Set the registration payload for the toolbar
        /// </summary>
        /// <param name="payLoad"></param>
        protected override void SetRegistrationPayLoad(ref DataPayLoad payLoad)
        {
            payLoad.PayloadType = DataPayLoad.Type.RegistrationPayload;
            payLoad.Subsystem = DataSubSystem.ClientSubsystem;
        }
        private void ClientOnContactsPrimaryKey(ref ContactsDto primaryKey)
        {
            primaryKey.ContactsKeyId = PrimaryKeyValue;
        }

        private void ClientOnBranchesPrimaryKey(ref BranchesDto primaryKey)
        {
            primaryKey.BranchKeyId = PrimaryKeyValue;
        }

        private string CreateNameRegion(string regionName)
        {
            Guid uid = Guid.NewGuid();
            var uri = regionName + "."+uid.ToString();
            return uri;
        }
        /// <summary>
        /// Navigate to the view.
        /// </summary>
       
        private void NavigateDefault()
        {
            RegionManager.RequestNavigate(DriverZoneRegionName, "DriverLicense");
        }
        /// <summary>
        /// Navigate to drivers.
        /// </summary>
        /// <param name="viewName">Viewname to view</param>
        private void NavigateToDrivers(string viewName)
        {
            var navigationParameters = new NavigationParameters();
            navigationParameters.Add(ScopedRegionNavigationContentLoader.DefaultViewName, viewName);
            var uri = new Uri(typeof(DriversControlView).FullName + navigationParameters, UriKind.Relative);
            RegionManager.RequestNavigate("ContentRegion",typeof(DriversControlView).FullName);
        }

        /// <summary>
        ///  Initialize view model.
        /// </summary>
        private void InitVmCommands()
        {
            ItemChangedCommand = new Prism.Commands.DelegateCommand<object>(OnChangedField);
            AssistCommand = new Prism.Commands.DelegateCommand<object>(OnAssistCommand);
            SelectCompanyOrDriver = new DelegateCommand<object>(OnCompanyOrDriver);
            CurrentOperationalState = DataPayLoad.Type.Show;
            ContentAreaCommand = new DelegateCommand<object>(OnContentAreaCommand);
            _helperData = new HelperData();
        }

        private void OnContentAreaCommand(object obj)
        {
            var value = typeof(DriversControlView).FullName;
            RegionManager.RequestNavigate(DriverZoneRegionName, value);
        }

        /// <summary>
        ///  Select company or driver.
        /// </summary>
        /// <param name="selectionEvent">Event to be selected</param>
        private void OnCompanyOrDriver(object selectionEvent)
        {
            System.Windows.Controls.SelectionChangedEventArgs ev = selectionEvent as System.Windows.Controls.SelectionChangedEventArgs;
            ComboBox item = ev?.Source as ComboBox;
            if (item != null)
            {
               
                StateVisible = (item.SelectedIndex == 0);
            }
            if (StateVisible)
            {
                RegionManager.RequestNavigate(DriverZoneRegionName, "DriverLicense");
            }
            else
            {
                RegionManager.RequestNavigate(DriverZoneRegionName, "CompanyDrivers");
            }
        }

       
        /// <summary>
        ///  Helper data .
        /// </summary>
        public IHelperData ClientHelper
        {
            get { return _helperData; }
            set { _helperData = value; RaisePropertyChanged(); }
        }
        public ICommand LaunchMap { set; get; }
        private void OnChangedField(object obj)
        {
            IDictionary<string, object> eventDictionary = (IDictionary<string, object>)obj;
            if (eventDictionary.ContainsKey(OperationConstKey))
            {
                var value = eventDictionary["DataSourcePath"] as string;

                if (value == "ContactsDtos")
                {
                    ContactsChangedCommandHandler(eventDictionary);
                }
                else
                {
                    DelegationChangedCommandHandler(eventDictionary);
                }
            }
            else
            {
                OnChangedField(eventDictionary);
            }
        }
        /// <summary>
        ///  Handle the delegation grid changes.
        /// </summary>
        /// <param name="obj">This send a delegation for the changed command</param>
        private async void DelegationChangedCommandHandler(object obj)
        {
            await GridChangedNotification<BranchesDto, cliDelega>(obj, _onBranchesPrimaryKey, DataSubSystem.ClientSubsystem).ConfigureAwait(false);
            
        }
        /// <summary>
        /// Handle contact changed command
        /// </summary>
        /// <param name="obj">This send a contact for the changed command</param>
        private async void ContactsChangedCommandHandler(object obj)
        {
            await GridChangedNotification<ContactsDto, CliContactos>(obj,
              _onContactsPrimaryKey,
              DataSubSystem.ClientSubsystem).ConfigureAwait(false);
        }
        /// <summary>
        /// Dictionary of events.
        /// </summary>
        /// <param name="eventDictionary"></param>
        private void OnChangedField(IDictionary<string, object>  eventDictionary)
        {
            DataPayLoad payLoad = new DataPayLoad();
            payLoad.Subsystem = DataSubSystem.ClientSubsystem;
            payLoad.SubsystemName = MasterModuleConstants.ClientSubSystemName;
            payLoad.PayloadType = DataPayLoad.Type.Update;
            if (string.IsNullOrEmpty(payLoad.PrimaryKeyValue))
            {
                payLoad.PrimaryKeyValue = PrimaryKeyValue;

            }
            if (eventDictionary.ContainsKey("DataObject"))
            {
                if (eventDictionary["DataObject"] == null)
                {
                    MessageBox.Show("DataObject is null.");
                }

                var data = eventDictionary["DataObject"];
                if (eventDictionary.ContainsKey("Field"))
                {
                    var name = eventDictionary["Field"] as string;
                    if (eventDictionary.ContainsKey("ChangedCode"))
                    {
                        GenericObjectHelper.PropertySetValue(data, name, eventDictionary["ChangedCode"]);
                    }
                    else
                    {
                        GenericObjectHelper.PropertySetValue(data, name, eventDictionary["ChangedValue"]);
                    }
                }
                payLoad.DataObject = data; 
                payLoad.HasDataObject = true;
                eventDictionary["DataObject"] = data;

            }
            ChangeFieldHandlerDo<ClientDto> handlerDo = new ChangeFieldHandlerDo<ClientDto>(EventManager,
                DataSubSystem.ClientSubsystem);

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
        // move to the master, get rid of async void.
        private async void OnAssistCommand(object param)
        {
           
            IDictionary<string, string> values = (Dictionary<string, string>)param;
            string assistTableName = values.ContainsKey("AssistTable") ? values["AssistTable"] as string : null;
            string assistQuery = values.ContainsKey("AssistQuery") ? values["AssistQuery"] as string : null;
            bool value = await AssistQueryRequestHandler(assistTableName, assistQuery);
            if (!value)
            {
                MessageBox.Show("Assist Invalid!");
            }
        }
        void LoadMoreItems(uint count, int baseIndex)
        {
           var list =  (IEnumerable<CityDto>) _currentCities.Skip(baseIndex).Take(100).ToList();

            ClientHelper.CityDto = list; 
        }
            private async Task<bool> AssistQueryRequestHandler(string assistTableName, string assistQuery)
        {
           
            var value = await AssistMapper.ExecuteAssist(assistTableName, assistQuery);
            
            if (value != null)
            {
                switch (assistTableName)
                {
                    case "CITY_ASSIST":
                    {
                      
                        ClientHelper.CityDto = (IEnumerable<CityDto>)value;        
                        break;
                    }
                    case "CHANNEL_TYPE":
                    {
                        ClientHelper.ChannelDto= (IEnumerable<ChannelDto>) value;
                        break;
                    }
                    case "COUNTRY_ASSIST":
                    {
                        ClientHelper.CountryDto = (IEnumerable<CountryDto>) value;
                        break;
                    }
                    case "PROVINCE_ASSIST":
                    {
                        ClientHelper.ProvinciaDto = (IEnumerable<ProvinciaDto>) value;
                        break;
                    }
                    case "COMPANY_ASSIST":
                    {
                        ClientHelper.CompanyDto = (IEnumerable<CompanyDto>) value;
                        break;
                    }
                    case "ACTIVITY_ASSIST":
                    {
                        ClientHelper.ActivityDto = (IEnumerable<ActividadDto>) value;
                        break;
                    }
                    case "OFFICE_ASSIST":
                    {
                        ClientHelper.OfficeDto = (IEnumerable<OfficeDtos>) value;
                        break;
                    }
                    case "BUDGET_KEY":
                    {
                        ClientHelper.BudgetKeyDto = (IEnumerable<BudgetKeyDto>) value;
                        break;
                    }
                    case "CLIENT_ZONE":
                    {
                        ClientHelper.ZoneDto = (IEnumerable<ClientZoneDto>) value;
                        break;
                    }
                    case "RENT_USAGE_ASSIST":
                    {
                        ClientHelper.RentUsageDto = (IEnumerable<RentingUseDto>) value;
                        break;
                    }
                    case "CLIENT_TYPE":
                    {
                        ClientHelper.ClientTypeDto = (IEnumerable<ClientTypeDto>) value;
                        break;
                    }
                    case "CLIENT_TYPE_UPPER":
                        {
                            ClientTypeDto = (IEnumerable<ClientTypeDto>)value;
                            break;
                        }
                    case "CLIENT_CREDIT_CARD":
                    {
                        ClientHelper.CreditCardType = (IEnumerable<CreditCardDto>) value;
                        break;
                    }
                    case "CLIENT_PAYMENT_FORM":
                    {
                        ClientHelper.ClientPaymentForm = (IEnumerable<PaymentFormDto>) value;
                        break;
                    }
                    case "CLIENT_INVOICE_BLOCKS":
                    {
                        ClientHelper.InvoiceBlock = (IEnumerable<InvoiceBlockDto>) value;
                        break;
                    }
                    case "ORIGIN_ASSIST":
                    {
                        ClientHelper.OrigenDto = (IEnumerable<OrigenDto>) value;
                        break;
                    }
                    case "MARKET_ASSIST":
                    {
                        ClientHelper.ClientMarketDto = (IEnumerable<MercadoDto>) value;
                        break;
                    }
                    case "RESELLER_ASSIST":
                    {
                        ClientHelper.ResellerDto = (IEnumerable<ResellerDto>)value;
                        break;
                    }
                    case "CLIENT_BUDGET":
                    {
                        ClientHelper.BudgetKeyDto = (IEnumerable<BudgetKeyDto>)value;
                        break;
                    }
                    case "BUSINESS_ASSIST":
                    {
                        ClientHelper.BusinessDto = (IEnumerable<BusinessDto>)value;
                        break;
                    }
                    case "LANGUAGE_ASSIST":
                    {
                        ClientHelper.LanguageDto = (IEnumerable<LanguageDto>) value;
                        break;
                    }
                    case "CLIENT_BROKER":
                    {
                        ClientHelper.BrokerDto = (IEnumerable<CommissionAgentSummaryDto>) value;
                        break;
                    }
                    case "CLIENT_DRIVER":
                    {
                            ClientHelper.DriversDto = new List<ClientSummaryDto>();
                        ClientHelper.DriversDto = (IEnumerable<ClientSummaryDto>) value;
                            RaisePropertyChanged("ClientHelper.DriversDto");
                            break;
                    }
                    case "CREDIT_CARD":
                    {
                        ClientHelper.CreditCardType = (IEnumerable<CreditCardDto>) value;
                        break;
                    }
                    

                }
           
                RaisePropertyChanged("ClientHelper");
                
                return true;
            }
           
            return true;
        }
        /// <summary>
        ///  This returns the client data.
        ///  We have decied starting from this form to use just the dtos outside and not a complete model wrapper.
        /// </summary>
        public ClientDto DataObject
        {
            get { return _clientData.Value; }
            set { _clientData.Value = value; RaisePropertyChanged(); }
        }
        /// <summary>
        ///  This register the primary key
        /// </summary>
        /// <param name="payLoad">Payload to be registered</param>
        private void RegisterPrimaryKey(DataPayLoad payLoad)
        {
            Contract.Assert(PrimaryKeyValue!=null, "RegisterPrimaryKey error");
            Contract.Assert(payLoad!=null, "RegisterPrimaryKey error");
            if (PrimaryKeyValue.Length == 0)
            {
                PrimaryKeyValue = payLoad.PrimaryKeyValue;
                string mailboxName = "Clients." + PrimaryKeyValue;
                if (!string.IsNullOrEmpty(PrimaryKeyValue))
                {
                    if (MailBoxHandler != null)
                    {
                        EventManager.RegisterMailBox(mailboxName, MailBoxHandler);
                    }
                }
            }

        }
        /// <summary>
        ///  Handle the payload from the event manager
        /// </summary>
        /// <param name="dataPayLoad"></param>
        public void IncomingPayload(DataPayLoad dataPayLoad)
        {

            DataPayLoad payload = dataPayLoad;

            if (payload != null)
            {
                
                RegisterPrimaryKey(dataPayLoad);
                // here i can fix the primary key
                switch (payload.PayloadType)
                {
                    case DataPayLoad.Type.UpdateData:
                    {
                        if (payload.HasDataObject)
                        {
                            var clientData = payload.DataObject as ClientDto;
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
                        if (string.IsNullOrEmpty(PrimaryKeyValue))
                        {
                            PrimaryKeyValue =
                                DataServices.GetClientDataServices().GetNewId();

                            CurrentOperationalState = DataPayLoad.Type.Insert;
                        }
                        Init(PrimaryKeyValue, payload, true);
                        break;
                    }
                    case DataPayLoad.Type.Delete:
                    {

                        if (PrimaryKey == payload.PrimaryKey)
                        {
                            DeleteEventCleanup(payload.PrimaryKeyValue, PrimaryKeyValue, DataSubSystem.ClientSubsystem,
                                MasterModuleConstants.ClientSubSystemName);
                            DeleteRegion(payload.PrimaryKeyValue);

                        }
                        break;
                    }
                }
            }

        }
       
        // expiration month for the credit catd
        private string _expirationMonth;
        private string _expirationYear;
        public string ExpiryMonth {
            get { return _expirationMonth; }
            set
            {
                _expirationMonth = value;
            }
        }
        // expiration year for the credit card
        public string ExpiryYear
        {
            get { return _expirationYear; }
            set
            {
                _expirationYear = value;
               
                DataObject.TARCADU = string.Format("{0}/{1}", ExpiryMonth, ExpiryYear);
                RaisePropertyChanged("DataObject");
            }
        }



        public ICommand ValidateFrom { get; set; }
        public ICommand ContentAreaCommand { get; set; }
       
        public ICommand SelectCompanyOrDriver { get; set; }
        /// <summary>
        /// ClientInfoRightRegionName
        /// </summary>
        public string ClientInfoRightRegionName {
            get
            {
                return _clientRegion;
            }
            set { _clientRegion = value; RaisePropertyChanged(); }
        }

        public string DriverZoneRegionName
        {
            get { return _driverZone; }

            set
            {
                _driverZone = value;
                RaisePropertyChanged();
            }
        }

        public bool StateVisible
        {
            set { _stateVisible = value; RaisePropertyChanged(); }
            get { return _stateVisible; }
        }

        public object CompanyOrDriver
        {
            set { _company = value; }
            get { return _company; }
        }

        public Visibility IsVisible { get; private set; }
        public IEnumerable<ClientTypeDto> ClientTypeDto { get
            { return _clientTypeDto; }
            set { _clientTypeDto = value; RaisePropertyChanged(); } }

        public IEnumerable<ClientSummaryDto> DriversList
        {
            get
            {
                return _listOfDrivers;
            }
            set
            {
                _listOfDrivers = value;
                RaisePropertyChanged();
            }
        }

        public void Init(string primaryKey, DataPayLoad payload, bool isInsert)
        {
            if (payload.HasDataObject)
            {
                Logger.Info("ClientInfoViewModel has received payload type " + payload.PayloadType.ToString());
                var clientData = payload.DataObject as IClientData;
                if (clientData != null)
                {
                    _clientData = clientData;
                    
                   
                    DataObject = clientData.Value;
                    // in this way we trigger just one time the raiseproperty changed.
                    var clientHelper = clientData;                
                    ClientHelper = clientHelper;
                    // When the view model receive a message broadcast to its child view models.                
                    Logger.Info("ClientInfoViewModel has activated the client subsystem as current with directive " +
                                payload.PayloadType.ToString());
                    ActiveSubSystem();
                    NavigateDefault();


                   // RaisePropertyChanged("ClientHelper");
                }
            }
        }
    }
}
