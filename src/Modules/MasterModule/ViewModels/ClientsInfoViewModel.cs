using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;
using System.Windows.Input;
using AutoMapper;
using KarveCommon.Services;
using KarveCommonInterfaces;
using KarveDataServices;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;
using MasterModule.Common;
using Prism.Regions;
using DataAccessLayer.Logic;
using Prism.Commands;
using System.Windows;
using System.Windows.Controls;
using KarveCommon.Generic;
using MasterModule.Views;
using Syncfusion.Windows.PdfViewer;

namespace MasterModule.ViewModels
{
    /// <summary>
    /// This class is responsible for adding/modifying and viewing a view model.
    /// </summary>
    class ClientsInfoViewModel: MasterInfoViewModuleBase, IEventObserver, IDisposeEvents
    {
        private IClientData _clientData;
        private IClientDataServices _clientDataServices;
        private IHelperData _helperData;
        private object _province;
        private object _country;
        private object _company;
        private object _clientZone;
        private object _origenDto;
        private object _office;
        private bool _stateVisible;
        private string _clientRegion;

        /// <summary>
        ///  Constructor
        /// </summary>
        /// <param name="eventManager">Event manager</param>
        /// <param name="configurationService">Configuration service</param>
        /// <param name="dataServices">Data Service</param>
        /// <param name="manager">Region Manager</param>
        public ClientsInfoViewModel(IEventManager eventManager, IConfigurationService configurationService, IDataServices dataServices, IRegionManager manager) : base(eventManager, configurationService, dataServices, manager)
        {
            base.ConfigureAssist();

            ConfigurationService = configurationService;
            MailBoxHandler += MessageHandler;
            EventManager.RegisterObserverSubsystem(MasterModuleConstants.ClientSubSystemName, this);
            _clientDataServices = dataServices.GetClientDataServices();
            InitVmCommands();
            Guid uid = Guid.NewGuid();
            ClientInfoRightRegionName = CreateNameRightDetailRegion();
             StateVisible = true;
        }

        private string CreateNameRightDetailRegion()
        {
            Guid uid = Guid.NewGuid();
            var uri = typeof(RightDetailView).FullName + "."+uid.ToString();
            return uri;
        }
        /// <summary>
        /// Navigate to the view.
        /// </summary>
        /// <param name="viewName">Viewname to view</param>
        private void NavigateToRightDetail(string viewName)
        {
            var navigationParameters = new NavigationParameters();
            Guid uid = Guid.NewGuid();
            navigationParameters.Add(ScopedRegionNavigationContentLoader.DefaultViewName, uid.ToString());
            var uri = new Uri(ClientInfoRightRegionName + navigationParameters, UriKind.Relative);
            RegionManager.RequestNavigate("ClientInfoRightRegion", uri);
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
            RegionManager.RequestNavigate("DriversControlView", uri);
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
            _helperData = new HelperData();
            NavigateToRightDetail("RightDetailView");
        }
        /// <summary>
        ///  Select company or driver.
        /// </summary>
        /// <param name="selectionEvent">Event to be selected</param>
        private void OnCompanyOrDriver(object selectionEvent)
        {
            SelectionChangedEventArgs ev = selectionEvent as SelectionChangedEventArgs;
            ComboBox item = ev?.Source as ComboBox;
            if (item != null)
            {
                StateVisible = (item.SelectedIndex == 0);
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

        private void OnChangedField(object obj)
        {
            IDictionary<string, object> eventDictionary = (IDictionary<string, object>)obj;
            if (eventDictionary.ContainsKey(OperationConstKey))
            {
                var value = eventDictionary["DataSourcePath"] as string;

                /*if (value == "ContactsDtos")
                {
                    ContactsChangedCommandHandler(eventDictionary);
                }
                else
                {
                    DelegationChangedCommandHandler(eventDictionary);
                }*/
            }
            else
            {
                OnChangedField(eventDictionary);
            }
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
                payLoad.DataObject = eventDictionary["DataObject"];
                payLoad.HasDataObject = true;

            }
            ChangeFieldHandlerDo<ClientesDto> handlerDo = new ChangeFieldHandlerDo<ClientesDto>(EventManager,
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
        // move to the master,
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

        private async Task<bool> AssistQueryRequestHandler(string assistTableName, string assistQuery)
        {
            var value = await AssistMapper.ExecuteAssist(assistTableName, assistQuery);
            
            if (value != null)
            {
                switch (assistTableName)
                {
                    case "CITY_ASSIST":
                    {
                        ClientHelper.CityDto = (List<CityDto>) value;
                        break;
                    }
                    case "COUNTRY_ASSIST":
                    {
                        ClientHelper.CountryDto = (List<CountryDto>) value;
                        break;
                    }
                    case "PROVINCE_ASSIST":
                    {
                        ClientHelper.ProvinciaDto = (List<ProvinciaDto>) value;
                        break;
                    }
                    case "COMPANY_ASSIST":
                    {
                        ClientHelper.CompanyDto = (List<CompanyDto>) value;
                        break;
                    }
                    case "OFFICE_ASSIST":
                    {
                        ClientHelper.OfficeDto = (List<OfficeDtos>) value;
                        break;
                    }
                    case "CLIENT_ZONE":
                    {
                        ClientHelper.ZoneDto = (List<ClientZoneDto>) value;
                        break;
                    }
                    case "CLIENT_TYPE":
                    {
                        ClientHelper.ClientTypeDto = (List<ClientTypeDto>) value;
                        break;
                    }
                    case "CHANNEL_TYPE":
                    {
                        ClientHelper.ChannelDto = (List<ChannelDto>) value;
                        break;
                    }
                    case "CLIENT_CREDIT_CARD":
                    {
                        ClientHelper.CreditCardType = (List<CreditCardDto>) value;
                        break;
                    }
                    case "CLIENT_PAYMENT_FORM":
                    {
                        ClientHelper.ClientPaymentForm = (List<PaymentFormDto>) value;
                        break;
                    }
                    case "CLIENT_INVOICE_BLOCKS":
                    {
                        ClientHelper.InvoiceBlock = (List<InvoiceBlockDto>) value;
                        break;
                    }

                    case "CLIENT_BROKER":
                    {
                        ClientHelper.BrokerDto = (List<CommissionAgentSummaryDto>) value;
                        break;
                    }
                    case "CREDIT_CARD":
                    {
                        ClientHelper.CreditCardType = (List<CreditCardDto>) value;
                        break;
                    }
                }
           
                RaisePropertyChanged("ClientHelper");
                return true;
            }
            return false;
        }
        /// <summary>
        ///  This returns the client data.
        ///  We have decied starting from this form to use just the dtos outside and not a complete model wrapper.
        /// </summary>
        public ClientesDto DataObject
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
                            var clientData = payload.DataObject as ClientesDto;
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
        public ICommand ContentAreaCommand { get; set; }
        public ICommand ItemChangedCommand { get; set; }
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
                    /*
                    clientHelper.ActivityDto = clientData.ActivityDto;
                    clientHelper.BrokerDto = clientData.BrokerDto;
                    clientHelper.CityDto = clientData.CityDto;
                   
                    clientHelper.ClientMarketDto = clientData.ClientMarketDto;
                    clientHelper.ClientTypeDto = clientData.ClientTypeDto;
                    clientHelper.CompanyDto = clientData.CompanyDto;
                    clientHelper.CountryDto = clientData.CountryDto;
                    clientHelper.OrigenDto = clientData.OrigenDto;
                    clientHelper.ResellerDto = clientData.ResellerDto;
                    clientHelper.BudgetKey = clientData.BudgetKey;
                    clientHelper.BusinessDto = clientData.BusinessDto;
                    clientHelper.ChannelDto = clientData.ChannelDto;
    */                
                    ClientHelper = clientHelper;
                    // When the view model receive a message broadcast to its child view models.                
                    EventManager.SendMessage(UpperBarClientViewModel.Name, payload);
                    
                    string rightDetailUri = "master://" + typeof(RightDetailViewModel).FullName;
                    EventManager.SendMessage(rightDetailUri, payload);
                    Logger.Info("ClientInfoViewModel has activated the client subsystem as current with directive " +
                                payload.PayloadType.ToString());
                    ActiveSubSystem();
                }
            }
        }
    }
}
