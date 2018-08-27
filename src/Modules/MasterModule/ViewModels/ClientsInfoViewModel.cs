using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using KarveCommon.Services;
using KarveCommonInterfaces;
using KarveDataServices;
using KarveDataServices.DataObjects;
using KarveDataServices.ViewObjects;
using MasterModule.Common;
using Prism.Regions;
using Prism.Commands;
using System.Windows;
using System.Windows.Controls;
using DataAccessLayer.DataObjects;
using KarveCommon.Generic;
using MasterModule.Views;
using System.ComponentModel;
using KarveCommon;
using DataAccessLayer;
using Syncfusion.UI.Xaml.Grid;
using MasterModule.Views.Clients;

namespace MasterModule.ViewModels
{
    /// <summary>
    /// This class is responsible for allowing the client info view to communicate with the other levels.
    /// </summary>
    public sealed class ClientsInfoViewModel: MasterInfoViewModuleBase, IEventObserver, IDisposeEvents, ICreateRegionManagerScope
    {
        #region Private Fields
        private IClientData _clientData;
        private IClientDataServices _clientDataServices;
        private HelperBase _helperData;
        private object _company;
        private IEnumerable<CompanyViewObject> _companyValue;
        private bool _stateVisible;
        private string _clientRegion;
        private ClientViewObject _currentClientDo = new ClientViewObject();
        private string _driverZone;
        private IEnumerable<CityViewObject> _currentCities = new List<CityViewObject>();
        private IEnumerable<ClientTypeViewObject> _clientTypeDto = new List<ClientTypeViewObject>();
      
        private IncrementalList<ClientSummaryExtended> _listOfDrivers;
        private PropertyChangedEventHandler eventHandler;
        
        private INotifyTaskCompletion<IEnumerable<ClientSummaryExtended>> _driversNotification;
        #endregion

        /// <summary>
        ///  Primary  key on branches
        /// </summary>
        private event SetPrimaryKey<BranchesViewObject> _onBranchesPrimaryKey;
        /// <summary>
        ///  Primary key on contacts.
        /// </summary>
        private event SetPrimaryKey<ContactsViewObject> _onContactsPrimaryKey;


        /// <summary>
        ///  ClientsInfoViewModel constructor.
        /// </summary>
        /// <param name="eventManager">Event manager</param>
        /// <param name="configurationService">Configuration service</param>
        /// <param name="dataServices">Data Service</param>
        /// <param name="manager">Region Manager</param>
        public ClientsInfoViewModel(IEventManager eventManager, 
            IConfigurationService configurationService, 
            IDataServices dataServices, 
            IDialogService dialogService,  
            IRegionManager manager,
            IInteractionRequestController controller) : base(eventManager, configurationService, dataServices,dialogService,manager, controller)
        {
            base.ConfigureAssist();

            ConfigurationService = configurationService;
            MailBoxHandler += MessageHandler;
            IsVisible = Visibility.Collapsed;
            EventManager.RegisterObserverSubsystem(MasterModuleConstants.ClientSubSystemName, this);
            InitVmCommands();            
            ClientInfoRightRegionName = CreateNameRegion("RightRegion");
            DriverZoneRegionName = CreateNameRegion("DriverZoneRegion");
            StateVisible = true;
            _onBranchesPrimaryKey += ClientOnBranchesPrimaryKey;
            _onContactsPrimaryKey += ClientOnContactsPrimaryKey;
            _clientDataServices = dataServices.GetClientDataServices();
            _clientData =_clientDataServices.GetNewDo("0");
            eventHandler += OnDriverUpdate;
            DefaultPageSize = 50;
            ViewModelUri = new Uri("karve://client/viewmodel?id=" + Guid.ToString());
            ActiveSubSystem();
            _initialized = false;
            
        }
        /// <summary>
        ///  Handle the notification of the driver event. 
        /// </summary>
        /// <param name="sender">Sender of the drivers.</param>
        /// <param name="e">Event coming</param>
        private void OnDriverUpdate(object sender, PropertyChangedEventArgs e)
        {
            if (sender is INotifyTaskCompletion<IEnumerable<ClientSummaryExtended>> value)
            {
                if (value.IsSuccessfullyCompleted)
                {
                  DriversList = new IncrementalList<ClientSummaryExtended>(LoadMoreDrivers);
                    DriversList.LoadItems(value.Task.Result);
                }
            }
        }
        private void LoadMoreDrivers(uint arg1, int index)
        {
            NotifyTaskCompletion.Create<IEnumerable<ClientSummaryExtended>>(_clientDataServices.GetPagedSummaryDoAsync(index, DefaultPageSize), (sender, ev) =>
            {
                if (sender is INotifyTaskCompletion<IEnumerable<ClientSummaryExtended>> value)
                {
                    if (value.IsSuccessfullyCompleted)
                    {
                        var result = value.Task.Result.Except(DriversList);
                        DriversList.LoadItems(result);
                    }
                }
            });
        }
        private void UpdateListOfDrivers()
        {
            _driversNotification = NotifyTaskCompletion.Create<IEnumerable<ClientSummaryExtended>>(_clientDataServices.GetPagedSummaryDoAsync(1, DefaultPageSize), eventHandler); 
        }
        /// <summary>
        ///  Set the registration payload for the toolbar
        /// </summary>
        /// <param name="payLoad"></param>
        protected override void SetRegistrationPayLoad(ref DataPayLoad payLoad)
        {
            payLoad.PayloadType = DataPayLoad.Type.RegistrationPayload;
            payLoad.Subsystem = DataSubSystem.ClientSubsystem;
            SubSystem = DataSubSystem.ClientSubsystem; 
        }
        private void ClientOnContactsPrimaryKey(ref ContactsViewObject primaryKey)
        {
            primaryKey.ContactsKeyId = PrimaryKeyValue;
        }

        private void ClientOnBranchesPrimaryKey(ref BranchesViewObject primaryKey)
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
            
            var visible = (_clientData.Value.PERSONA == "F");
            SelectedDrivers = visible;
            
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
            _helperData = new HelperBase();
        }

        private void OnContentAreaCommand(object obj)
        {
            var value = typeof(ClientsControlView).FullName;
            RegionManager.RequestNavigate(RegionNames.TabRegion, value);
        }

        /// <summary>
        ///  Select company or driver.
        /// </summary>
        /// <param name="selectionEvent">Event to be selected</param>
        private void OnCompanyOrDriver(object selectionEvent)
        {
            System.Windows.Controls.SelectionChangedEventArgs ev = selectionEvent as System.Windows.Controls.SelectionChangedEventArgs;
            if (ev?.Source is ComboBox item)
            {
               
                StateVisible = (item.SelectedIndex == 0);
            }
            SelectedDrivers = StateVisible;
        }

       
        /// <summary>
        ///  Helper data .
        /// </summary>
        public HelperBase ClientHelper
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
            await GridChangedNotification<BranchesViewObject, cliDelega>(obj, _onBranchesPrimaryKey, DataSubSystem.ClientSubsystem).ConfigureAwait(false);
            
        }
        /// <summary>
        /// Handle contact changed command
        /// </summary>
        /// <param name="obj">This send a contact for the changed command</param>
        private async void ContactsChangedCommandHandler(object obj)
        {
            await GridChangedNotification<ContactsViewObject, CliContactos>(obj,
              _onContactsPrimaryKey,
              DataSubSystem.ClientSubsystem).ConfigureAwait(false);
        }
        /// <summary>
        /// Dictionary of events.
        /// </summary>
        /// <param name="eventDictionary"></param>
        private void OnChangedField(IDictionary<string, object> eventDictionary)
        {
            object dataObject = DataObject;
            DataPayLoad payLoad = BuildDataPayload(eventDictionary);

            ChangeFieldHandlerDo<ClientViewObject> handlerDo = new ChangeFieldHandlerDo<ClientViewObject>(EventManager,
                DataSubSystem.ClientSubsystem);
            var fixedValue = DataObject;

            FixCreditCardInfo(ref fixedValue, ExpireMonth, ExpireYear);
            DataObject = fixedValue;

            if (string.IsNullOrEmpty(payLoad.PrimaryKeyValue))
            {
                payLoad.PrimaryKeyValue = PrimaryKeyValue;
            }
           
            SetBasePayLoad(eventDictionary, ref payLoad);
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
        public bool SelectedDrivers
        {
            get => _selectedDrivers;
            set
            {
                _selectedDrivers = value;
                RaisePropertyChanged();
            }
        }
        // move to the master, get rid of async void.
        private async void OnAssistCommand(object param)
        {
           
            IDictionary<string, string> values = (Dictionary<string, string>)param;
            var assistTableName = values.ContainsKey("AssistTable") ? values["AssistTable"] as string : null;
            var assistQuery = values.ContainsKey("AssistQuery") ? values["AssistQuery"] as string : null;
            var value = await AssistQueryRequestHandler(assistTableName, assistQuery).ConfigureAwait(false);
            if (!value)
            {
                MessageBox.Show("Assist Invalid!");
            }
        }
        void LoadMoreItems(uint count, int baseIndex)
        {
           var list =  (IEnumerable<CityViewObject>) _currentCities.Skip(baseIndex).Take(100).ToList();

            ClientHelper.CityDto = list; 
        }


        private async Task<bool> AssistQueryRequestHandler(string assistTableName, string assistQuery)
        {
           

            var value = await AssistMapper.ExecuteAssistGeneric(assistTableName, assistQuery);
            
            if (value != null)
            {
                switch (assistTableName)
                {
                    case "CITY_ASSIST":
                    {
                      
                        CityDto = (IEnumerable<CityViewObject>)value;        
                        break;
                    }
                    case "CHANNEL_TYPE":
                    {
                        ChannelDto= (IEnumerable<ChannelViewObject>) value;
                        break;
                    }
                    case "COUNTRY_ASSIST":
                    {
                        CountryDto = (IEnumerable<CountryViewObject>) value;
                        break;
                    }
                    case "PROVINCE_ASSIST":
                    {
                        ProvinciaDto = (IEnumerable<ProvinceViewObject>) value;
                        break;
                    }
                    case "COMPANY_ASSIST":
                    {
                        CompanyDto = (IEnumerable<CompanyViewObject>) value;
                        break;
                    }
                    case "ACTIVITY_ASSIST":
                    {
                        ActivityDto = (IEnumerable<ActividadViewObject>) value;
                        break;
                    }
                    case "OFFICE_ASSIST":
                    {
                        OfficeDto = (IEnumerable<OfficeViewObject>) value;
                        break;
                    }
                    case "BUDGET_KEY":
                    {
                        BudgetKeyDto = (IEnumerable<BudgetKeyViewObject>) value;
                        break;
                    }
                    case "CLIENT_ZONE":
                    {
                        ZoneDto = (IEnumerable<ClientZoneViewObject>) value;
                        break;
                    }
                    case "RENT_USAGE_ASSIST":
                    {
                        RentUsageDto = (IEnumerable<RentingUseViewObject>) value;
                        break;
                    }
                    case "CLIENT_TYPE":
                    {
                        ClientTypeDto = (IEnumerable<ClientTypeViewObject>) value;
                        break;
                    }
                    case "CLIENT_TYPE_UPPER":
                        {
                            ClientTypeDto = (IEnumerable<ClientTypeViewObject>)value;
                            break;
                        }
                    case "CLIENT_CREDIT_CARD":
                    {
                        CreditCardType = (IEnumerable<CreditCardViewObject>) value;
                        break;
                    }
                    case "CLIENT_PAYMENT_FORM":
                    {
                        ClientPaymentForm = (IEnumerable<PaymentFormViewObject>) value;
                        break;
                    }
                    case "CLIENT_INVOICE_BLOCKS":
                    {
                        InvoiceBlock = (IEnumerable<InvoiceBlockViewObject>) value;
                        break;
                    }
                    case "ORIGIN_ASSIST":
                    {
                        OrigenDto = (IEnumerable<OrigenViewObject>) value;
                        break;
                    }
                    case "MARKET_ASSIST":
                    {
                        ClientMarketDto = (IEnumerable<MarketViewObject>) value;
                        break;
                    }
                    case "RESELLER_ASSIST":
                    {
                        ResellerDto = (IEnumerable<ResellerViewObject>)value;
                        break;
                    }
                    case "CLIENT_BUDGET":
                    {
                        BudgetKeyDto = (IEnumerable<BudgetKeyViewObject>)value;
                        break;
                    }
                    case "BUSINESS_ASSIST":
                    {
                        BusinessDto = (IEnumerable<BusinessViewObject>)value;
                        break;
                    }
                    case "LANGUAGE_ASSIST":
                    {
                        LanguageDto = (IEnumerable<LanguageViewObject>) value;
                        break;
                    }
                    case "CLIENT_BROKER":
                    {
                        BrokerDto = (IEnumerable<CommissionAgentSummaryViewObject>) value;
                        break;
                    }
                    case "CLIENT_DRIVER":
                    {
                          
                            DriversDto = (IEnumerable<ClientSummaryViewObject>) value;
                            break;
                    }
                    case "CREDIT_CARD":
                    {
                        CreditCardType = (IEnumerable<CreditCardViewObject>) value;
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
        public ClientViewObject DataObject
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
        public override void IncomingPayload(DataPayLoad dataPayLoad)
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
                            var clientData = payload.DataObject as ClientViewObject;
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
                    // in this case load the item after a navigate.
                    case DataPayLoad.Type.ShowNavigate:
                    {
                        //StartAndNotify();
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
        private bool _selectedDrivers;
        private bool _initialized;
        private IEnumerable<CityViewObject> _city;
        private IEnumerable<ChannelViewObject> _channel;
        private IEnumerable<CountryViewObject> _country;
        private IEnumerable<ProvinceViewObject> _province;
        private IEnumerable<ActividadViewObject> _activity;
        private IEnumerable<OfficeViewObject> _office;
        private IEnumerable<CreditCardViewObject> _creditCardType;
        private IEnumerable<PaymentFormViewObject> _clientForm;
        private IEnumerable<InvoiceBlockViewObject> _invoiceBlock;
        private IEnumerable<OrigenViewObject> _origenDto;
        private IEnumerable<MarketViewObject> _clientMarket;
        private IEnumerable<ResellerViewObject> _resellerDto;
        private IEnumerable<BudgetKeyViewObject> _budgetKey;
        private IEnumerable<BusinessViewObject> _business;
        private IEnumerable<LanguageViewObject> _language;
        private IEnumerable<CommissionAgentSummaryViewObject> _broker;
        private IEnumerable<ClientSummaryViewObject> _drivers;
        private IEnumerable<RentingUseViewObject> _rentusage;
        private IEnumerable<ClientZoneViewObject> _zone;

        public string ExpireMonth {
            get { return _expirationMonth; }
            set
            {
                _expirationMonth = value;
                var data = DataObject;
                data.CreditCardExpiryMonth = value;
                DataObject = data;
                RaisePropertyChanged();
            }
        }
        // expiration year for the credit card
        public string ExpireYear
        {
            get { return _expirationYear; }
            set
            {
                _expirationYear = value;
                var data = DataObject;
                data.CreditCardExpiryYear = _expirationYear;
                DataObject = data;
                RaisePropertyChanged();
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
        public IEnumerable<ClientTypeViewObject> ClientTypeDto { get
            { return _clientTypeDto; }
            set { _clientTypeDto = value; RaisePropertyChanged(); } }

        public IncrementalList<ClientSummaryExtended> DriversList
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

        public bool CreateRegionManagerScope => true;

        public IEnumerable<CityViewObject> CityDto
        {
            get { return _city; }
            set
            {
                _city = value;
                if (_initialized)
                    RaisePropertyChanged();
            }
        }
        public IEnumerable<ChannelViewObject> ChannelDto {
            get { return _channel; }
            set
            {
                _channel = value;
                if (_initialized)
                    RaisePropertyChanged();
            }
        }
        public IEnumerable<CountryViewObject> CountryDto {
            get { return _country; }
            set
            {
                _country = value;
                if (_initialized)
                    RaisePropertyChanged();
            }
        }
        public IEnumerable<CompanyViewObject> CompanyDto {
            get { return _companyValue; }
            set
            {
                _companyValue = value;
                if (_initialized)
                    RaisePropertyChanged();
            }
             }
        public IEnumerable<ProvinceViewObject> ProvinciaDto
        {
            get { return _province; }
            set
            {
                _province = value;
                if (_initialized)
                    RaisePropertyChanged();
            }
        }
        public IEnumerable<ActividadViewObject> ActivityDto
        {
            get { return _activity; }
            set
            {
                _activity = value;
                if (_initialized)
                    RaisePropertyChanged();
            }
        }
        public IEnumerable<OfficeViewObject> OfficeDto
        {
            get { return _office; }
            set
            {
                _office = value;
                if (_initialized)
                    RaisePropertyChanged();
            }
        }
        public IEnumerable<CreditCardViewObject> CreditCardType
        {
            get { return _creditCardType; }
            set
            {
                _creditCardType = value;
                if (_initialized)
                    RaisePropertyChanged();
            }
        }
        public IEnumerable<PaymentFormViewObject> ClientPaymentForm
        {
            get { return _clientForm; }
            set
            {
                _clientForm = value;
                if (_initialized)
                    RaisePropertyChanged();
            }
        }
        public IEnumerable<InvoiceBlockViewObject> InvoiceBlock
        {
            get { return _invoiceBlock; }
            set
            {
                _invoiceBlock = value;
                if (_initialized)
                    RaisePropertyChanged();
            }
        }
        public IEnumerable<OrigenViewObject> OrigenDto
        {
            get { return _origenDto; }
            set
            {
                _origenDto = value;
                if (_initialized)
                    RaisePropertyChanged();
            }
        }
        public IEnumerable<MarketViewObject> ClientMarketDto
        {
            get { return _clientMarket; }
            set
            {
                _clientMarket = value;
                if (_initialized)
                    RaisePropertyChanged();
            }
        }
        public IEnumerable<ResellerViewObject> ResellerDto
        {
            get { return _resellerDto; }
            set
            {
                _resellerDto = value;
                if (_initialized)
                    RaisePropertyChanged();
            }
        }
        public IEnumerable<BudgetKeyViewObject> BudgetKeyDto
        {
            get { return _budgetKey; }
            set
            {
                _budgetKey = value;
                if (_initialized)
                    RaisePropertyChanged();
            }
        }
        public IEnumerable<BusinessViewObject> BusinessDto
        {
            get { return _business; }
            set
            {
                _business = value;
                if (_initialized)
                    RaisePropertyChanged();
            }
        }
        public IEnumerable<LanguageViewObject> LanguageDto
        {
            get { return _language; }
            set
            {
                _language = value;
                if (_initialized)
                    RaisePropertyChanged();
            }
        }
        public IEnumerable<CommissionAgentSummaryViewObject> BrokerDto
        {
            get { return _broker; }
            set
            {
                _broker = value;
                if (_initialized)
                    RaisePropertyChanged();
            }
        }
        public IEnumerable<ClientSummaryViewObject> DriversDto
        {
            get { return _drivers; }
            set
            {
                _drivers = value;
                if (_initialized)
                    RaisePropertyChanged();
            }
        }
        public IEnumerable<RentingUseViewObject> RentUsageDto
        {
            get { return _rentusage; }
            set
            {
                _rentusage = value;
                if (_initialized)
                    RaisePropertyChanged();
            }
        }
        public IEnumerable<ClientZoneViewObject> ZoneDto
        {
            get { return _zone; }
            set
            {
                _zone = value;
                if (_initialized)
                    RaisePropertyChanged();
            }
        }

        public void Init(string primaryKey, DataPayLoad payload, bool isInsert)
        {
            if (isInsert)
                return;
            if (payload.HasDataObject)
            {
                Logger.Info("ClientInfoViewModel has received payload type " + payload.PayloadType.ToString());
                var clientData = payload.DataObject as IClientData;
                if (clientData != null)
                {
                    _clientData = clientData;
                    // DRY

                    // check if this message is for me.
                    if (PrimaryKeyValue.Length > 0)
                    {
                        if (!(payload.DataObject is IClientData dto))
                        {
                            if (payload.DataObject is IClientData domainObject)
                                if (domainObject.Value.NUMERO_CLI != PrimaryKeyValue)
                                    return;
                        }
                        else
                        {
                            if (_clientData.Value.NUMERO_CLI!= PrimaryKeyValue) return;
                        }
                    }

                    //      DataObject = clientData.Value;
                    //      DataObject.NUMERO_CLI = clientData.Value.NUMERO_CLI;

                    // in this way we trigger just one time the raiseproperty changed.
                    if (clientData.Value != null)
                    {
                        
                        var clientHelper = clientData.Value.Helper;
                        ClientTypeDto = clientData.Value.Helper.ClientTypeDto;
                        ClientHelper = clientHelper as HelperBase;
                        CityDto = clientHelper.CityDto;
                        ChannelDto = clientHelper.ChannelDto;
                        CountryDto = clientHelper.CountryDto;
                        CompanyDto = clientHelper.CompanyDto;
                        ProvinciaDto = clientHelper.ProvinciaDto;
                        ActivityDto = clientHelper.ActivityDto;
                        OfficeDto = clientHelper.OfficeDto;
                        CreditCardType = clientHelper.CreditCardType;
                        ClientPaymentForm = clientHelper.ClientPaymentForm;
                        InvoiceBlock = clientHelper.InvoiceBlock;
                        OrigenDto = clientHelper.OrigenDto;
                        ClientMarketDto = clientHelper.ClientMarketDto;
                        ResellerDto = clientHelper.ResellerDto;
                        BudgetKeyDto = clientHelper.BudgetKeyDto;
                        BusinessDto = clientHelper.BusinessDto;
                        LanguageDto = clientHelper.LanguageDto;
                        BrokerDto = clientHelper.BrokerDto;
                        DriversDto = clientHelper.DriversDto;
                        RentUsageDto = clientHelper.RentUsageDto;
                        ZoneDto = clientHelper.ZoneDto;
                        ExpireMonth = clientData.Value.CreditCardExpiryMonth;
                        ExpireYear = clientData.Value.CreditCardExpiryYear;
                        _initialized = true;
                        
                        Logger.Info(
                            "ClientInfoViewModel has activated the client subsystem as current with directive " +
                            payload.PayloadType.ToString());
                        ActiveSubSystem();
                        NavigateDefault();
                    }

                   
                }
            }
        }
        public bool FixCreditCardInfo(ref ClientViewObject creditInfo, string month, string year)
        {
            var retValue = int.TryParse(month, out var resultValue);
            if ((retValue) && ((resultValue > 12) || (resultValue <1)))
            {
                return false;
            }

            if ((string.IsNullOrEmpty(month)) || (string.IsNullOrEmpty(year)))
            {
                return false;
            }
            creditInfo.TARCADU = $"{month}/{year}";
            creditInfo.CreditCardExpiryMonth = month;
            creditInfo.CreditCardExpiryYear = year;
            return true;
        }
        private bool ParseDataValue(string monthValue, out string parsedValue, int begin, int end)
        {
            var retValue = int.TryParse(monthValue, out var resultValue);
            parsedValue = string.Empty;
            if (retValue && ((resultValue > begin) && (resultValue < end)))
            {
                parsedValue = string.Format("{0}", resultValue);
                if (resultValue < 10)
                {
                    parsedValue = "0" + parsedValue;
                }
                return true;
            }
            return false;
        }

        private void UpdateCreditCardInfo(string tarcadu)
        {
            string month = string.Empty;
            if (!string.IsNullOrEmpty(tarcadu))
            {
                var yearmonth = tarcadu.Split('/');
                if (yearmonth.Length == 2)
                {
                    ParseDataValue(yearmonth[0], out month, 1, 13);
                    ExpireMonth = month;
                    var year = yearmonth[1];
                    // avoidin millenum bug.
                    if ((year.Length == 2) || (year.Length == 4))
                    {
                        ExpireYear = year;
                    }
                }
            }
        }

        internal override Task SetClientData(ClientSummaryExtended p, VisitsViewObject b)
        {
            throw new NotImplementedException();
        }

        internal override Task SetVisitContacts(ContactsViewObject p, VisitsViewObject visitsDto)
        {
            throw new NotImplementedException();
        }

        internal override async Task SetBranchProvince(ProvinceViewObject p, BranchesViewObject b)
        {
            IDictionary<string, object> ev = SetBranchProvince(p, b, DataObject, DataObject.BranchesDto);
            // send the opportune event where it is needed.
            await GridChangedNotification<BranchesViewObject, cliDelega>(ev,
                _onBranchesPrimaryKey, DataSubSystem.ClientSubsystem).ConfigureAwait(false);
        }

        internal override Task SetVisitReseller(ResellerViewObject param, VisitsViewObject b)
        {
            throw new NotImplementedException();
        }

        protected override void SetResult<T>(IEnumerable<T> result)
        {
            throw new NotImplementedException();
        }
        public override void Dispose()
        {
            
        }
    }
}
