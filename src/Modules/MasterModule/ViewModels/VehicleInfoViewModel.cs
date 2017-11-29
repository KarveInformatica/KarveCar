using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using KarveCommon.Services;
using KarveDataServices;
using MasterModule.Common;
using KarveDataServices.DataObjects;
using KarveCommon.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using AutoMapper;
using DataAccessLayer.DataObjects;
using DataAccessLayer.Logic;
using KarveDataServices.DataTransferObject;
using Prism.Commands;

namespace MasterModule.ViewModels
{
    /// <summary>
    ///  This represent the detailed class for the view model in case of each car.
    /// </summary>
    partial class VehicleInfoViewModel: MasterViewModuleBase, IEventObserver, IDataErrorInfo
    {
        /// <summary>
        ///  Vehicle Data Services.
        /// </summary>
        private IVehicleDataServices _vehicleDataServices;
        private IVehicleData _vehicleDo;
        private object _dataObject;
        private object _deleteNotifyTaskCompletion;
        private readonly PropertyChangedEventHandler _deleteEventHandler;
        private INotifyTaskCompletion<IVehicleData> _initializationTable;
        private DelegateCommand<object> _changedCommand;
        public ICommand AssistCommand { set; get; }
        private string _header;
        private string _assistQueryOwner;
        private ObservableCollection<ActividadDto> _activity;
        private ObservableCollection<AgentDto> _agents;
        private ObservableCollection<OwnerDto> _owner;
        private ObservableCollection<SupplierSummaryDto> _supplier;
        private ObservableCollection<PaymentFormDto> _paymentFormDto;
        private ObservableCollection<ClientsSummaryDto> _clients;
        private ObservableCollection<VendedorDto> _vendedor;
        private ObservableCollection<ClientsSummaryDto> _clientDto;
        private ObservableCollection<SupplierSummaryDto> _assuranceCompany;
        private ObservableCollection<SupplierSummaryDto> _assuranceAgent;

        // This returns the list of activity when asked.
        public ObservableCollection<ActividadDto> ActivityDtos
        {
            get
            {
                return _activity;
            }
            set
            {
                _activity= value;
                RaisePropertyChanged();
            }
            
        }

        public ObservableCollection<VendedorDto> VendedorDtos
        {
            get { return _vendedor; }
            set { _vendedor = value; RaisePropertyChanged(); }
        }
        /// <summary>
        ///  This returns the list of agents.
        /// </summary>
        public ObservableCollection<AgentDto> AgentDtos
        {
            get
            {
                return _agents;
            }
            set
            {
                _agents = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        ///  This returns the list of owners.
        /// </summary>
        public ObservableCollection<OwnerDto> OwnerDtos
        {
            get
            {
                return _owner;
            }
            set
            {
                _owner = value;
                RaisePropertyChanged();
            }
        }

        /// </summary>
        public ObservableCollection<SupplierSummaryDto> AssuranceDtos
        {
            get
            {
                return _assuranceCompany;
            }
            set
            {
                _assuranceCompany = value;
                RaisePropertyChanged();
            }
        }
        public ObservableCollection<SupplierSummaryDto> AssuranceAgentDtos
        {
            get
            {
                return _assuranceAgent;
            }
            set
            {
                _assuranceAgent = value;
                RaisePropertyChanged();
            }
        }
        public ObservableCollection<ClientsSummaryDto> ClientesDtos
        {
            get
            {
                return _clients;
            }
            set {
                _clients = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        ///  Constructor
        /// </summary>
        /// <param name="configurationService">This is the configurartion service</param>
        /// <param name="eventManager"> The event manager for sending/recieving messages from the view model</param>
        /// <param name="services">Data access layer interface</param>
        public VehicleInfoViewModel(IConfigurationService configurationService, IEventManager eventManager, IDataServices services) : 
            base(configurationService, eventManager, services)
        {
 			MailBoxHandler += MessageHandler;
            _vehicleDataServices = services.GetVehicleDataServices();
            ItemChangedCommand = new DelegateCommand<object>(ChangeUnpack);
            // In this tow cases i would use a collection of items with an itemscontrol.
            MetaDataObject = InitAssuranceObject();
            DataFieldCollection = InitDataField();
            EventManager.RegisterObserverSubsystem(MasterModuleConstants.VehiclesSystemName, this);
            AssistCommand = new DelegateCommand<object>(AssistCommandHelper);
        }

        private async void AssistCommandHelper(object param)
        {
            IDictionary<string, string> values = param as Dictionary<string, string>;
            string assistTableName = values.ContainsKey("AssistTable") ? values["AssistTable"]  : null;
            string assistQuery = values.ContainsKey("AssistQuery") ? values["AssistQuery"]  : null;
            /*  ok now i have to handle the assist helper.
             *  The smartest thing is to detect the table from the query.
             */
            IMapper mapper = MapperField.GetMapper();
            IHelperDataServices helperDataServices = DataServices.GetHelperDataServices();
            assistTableName = assistTableName.ToUpper();

            switch (assistTableName)
            {
                case "ACTIVI":
                {
                    var actividades = await helperDataServices.GetAsyncHelper<ACTIVI>(assistQuery);
                    var act = mapper.Map<IEnumerable<ACTIVI>, IEnumerable<ActividadDto>>(actividades);
                    ActivityDtos = new ObservableCollection<ActividadDto>(act);
                    break;
                }
                case "PROPIE":
                {
                    var propie = await helperDataServices.GetAsyncHelper<OwnerDto>(assistQuery);
                    ObservableCollection<OwnerDto> ownerDtos = new ObservableCollection<OwnerDto>(propie);
                    OwnerDtos = ownerDtos;
                    break;
                }
                case "AGENTES":
                {
                   
                    var agents = await helperDataServices.GetAsyncHelper<AgentDto>(assistQuery);
                    ObservableCollection<AgentDto> agentDtos = new ObservableCollection<AgentDto>(agents);   
                    AgentDtos = agentDtos;
                    break;
                }
                case "ASSURANCE":
                {
                    var provee =
                        await helperDataServices.GetAsyncHelper<SupplierSummaryDto>(GenericSql.SupplierSummaryQuery);
                    AssuranceDtos = new ObservableCollection<SupplierSummaryDto>(provee);
                    break;
                }
                case "ASSURANCE_AGENT":
                {
                    var provee =
                        await helperDataServices.GetAsyncHelper<SupplierSummaryDto>(GenericSql.SupplierSummaryQuery);
                    AssuranceAgentDtos = new ObservableCollection<SupplierSummaryDto>(provee);
                    break;

                }
                case "PROVEE1":
                {
                    var provee =
                        await helperDataServices.GetAsyncHelper<SupplierSummaryDto>(GenericSql.SupplierSummaryQuery);
                    ProveeDto = new ObservableCollection<SupplierSummaryDto>(provee);
                    break;
                }
                case "PROVEE2":
                {
                    var provee =
                        await helperDataServices.GetAsyncHelper<SupplierSummaryDto>(GenericSql.SupplierSummaryQuery);
                    ProveeDto2 = new ObservableCollection<SupplierSummaryDto>(provee);
                    break;
                }
                case "FORMAS":
                {
                    var formas = await helperDataServices.GetAsyncHelper<FORMAS>(assistQuery);
                    var paymentFrom = mapper.Map<IEnumerable<FORMAS>,IEnumerable<PaymentFormDto>>(formas);
                    PaymentFormDto = new ObservableCollection<PaymentFormDto>(paymentFrom);
                    break;
                }
                case "CLIENTES1":
                {
                    var clientes = await helperDataServices.GetAsyncHelper<ClientsSummaryDto>(GenericSql.SupplierSummaryQuery);
                    ClientsDto = new ObservableCollection<ClientsSummaryDto>(clientes);
                    break;
                   
                }
                case "VENDEDOR":
                {
                    var vendedor = await helperDataServices.GetAsyncHelper<VENDEDOR>(assistQuery);
                    IEnumerable<VendedorDto> cli = mapper.Map<IEnumerable<VENDEDOR>, IEnumerable<VendedorDto>>
                        (vendedor);
                    VendedorDtos = new ObservableCollection<VendedorDto>(cli);
                    break;
                }
            }
        }

        public ObservableCollection<SupplierSummaryDto> ProveeDto
        {
            get { return _supplier; }
            set { _supplier = value; RaisePropertyChanged(); }
        }
        public ObservableCollection<SupplierSummaryDto> ProveeDto2
        {
            get { return _supplier; }
            set { _supplier = value; RaisePropertyChanged(); }
        }

        public object DataObject
        {
            get { return _dataObject; }
            set { _dataObject = value;
                MetaDataObject = InitAssuranceObject();
                DataFieldCollection = InitDataField();
                RaisePropertyChanged();
            }
        }
        /// <summary>
        ///  Header 
        /// </summary>
        public string Header
        {
            set { _header = value; RaisePropertyChanged(); }
            get { return _header; }
        }
        private void ActiveSubSystem()
        {
            // change the active subsystem in the toolbar state.
            RegisterToolBar();
        }
        public string Error => throw new NotImplementedException();

        public string this[string columnName] => throw new NotImplementedException();

        /// <summary>
        /// This is the start notify.
        /// </summary>
        public override void StartAndNotify()
        {
            _initializationTable =
                NotifyTaskCompletion.Create<IVehicleData>(LoadDataValue(PrimaryKeyValue, IsInsertion), InitializationDataObjectOnPropertyChanged);
            
        }

        private void InitializationDataObjectOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (sender is IVehicleData)
            {
                IVehicleData vehicle = (IVehicleData) sender;
                DataObject = vehicle;
            }
        }
        public ICommand ItemChangedCommand { set; get; }

        private void ChangeUnpack(object value)
        {
            IDictionary<string,object> changedItem = value as IDictionary<string,object>;
            if (changedItem != null)
            {
                OnChangedField(changedItem);
            }
        }
        /// <summary>
        ///  OnChangedField. This method shall be changed.
        /// </summary>
        /// <param name="eventDictionary">Dictionary of events.</param>
        private void OnChangedField(IDictionary<string, object> eventDictionary)
        {
            DataPayLoad payLoad = new DataPayLoad();
            payLoad.Subsystem = DataSubSystem.VehicleSubsystem;
            if (string.IsNullOrEmpty(payLoad.PrimaryKeyValue))
            {
                payLoad.PrimaryKeyValue = PrimaryKeyValue;
                payLoad.PayloadType = DataPayLoad.Type.Update;
            }
            if (eventDictionary.ContainsKey("DataObject"))
            {
                if (eventDictionary["DataObject"] == null)
                {
                    MessageBox.Show("DataObject is null.");
                }
            }
            ChangeFieldHandlerDo<IVehicleData> handlerDo = new ChangeFieldHandlerDo<IVehicleData>(EventManager,
                ViewModelQueries,
                DataSubSystem.VehicleSubsystem);

            if (CurrentOperationalState == DataPayLoad.Type.Insert)
            {
                handlerDo.OnInsert(payLoad, eventDictionary);

            }
            else
            {
                handlerDo.OnUpdate(payLoad, eventDictionary);
            }
        }
        /// <summary>
        /// This program loads the data from the data values.
        /// </summary>
        /// <param name="primaryKeyValue">Primary Key.</param>
        /// <param name="isInsertion">Inserted key.</param>
        /// <returns></returns>
        private async Task<IVehicleData> LoadDataValue(string primaryKeyValue, bool isInsertion)
        {

            IVehicleData vehicle = null;
            if (isInsertion)
            {
                vehicle = _vehicleDataServices.GetNewVehicleDo(PrimaryKeyValue);
                if (vehicle != null)
                {
                    DataObject = vehicle;
                }
            }
            else
            {
                vehicle = await _vehicleDataServices.GetVehicleDo(primaryKeyValue);
                DataObject = vehicle;
                
            }
            return vehicle;
        }
        /// <summary>
        ///  assist owner
        /// </summary>
        public string AssistQueryOwner
        {
            get { return _assistQueryOwner; }
            set { _assistQueryOwner = value; }
        }
        /// <summary>
        ///  BuyerAssistQuery.
        /// </summary>
        public string BuyerAssistQuery
        {
            get { return GenericSql.ClientsSummaryQuery;  }
        }
        /// <summary>
        ///  name.
        /// </summary>
        public string LeasingSupplierQuery
        {
            get { return GenericSql.SupplierSummaryQuery; }
        }
            
            public ObservableCollection<PaymentFormDto> PaymentFormDto {
            get { return _paymentFormDto; }
            private set { _paymentFormDto = value; RaisePropertyChanged();}
        }

        public ObservableCollection<ClientsSummaryDto> ClientsDto
        {
            get { return _clientDto; }
            set
            {
                _clientDto = value;
                RaisePropertyChanged();
            }
            
        }

        public override void NewItem()
        {
        }
        protected override void SetTable(DataTable table)
        {
           
        }

        /// <summary>
        ///  This method set the registration payload.
        /// </summary>
        /// <param name="payLoad"></param>
        protected override void SetRegistrationPayLoad(ref DataPayLoad payLoad)
        {
            payLoad.PayloadType = DataPayLoad.Type.RegistrationPayload;
            payLoad.Subsystem = DataSubSystem.VehicleSubsystem;
        }
        protected override void SetDataObject(object result)
        {
        }

        /// <summary>
        ///  This give usa the routing name of a vehicle module.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        protected override string GetRouteName(string name)
        {
            return "VehicleMasterModule." + name;
        }

        /// <summary>
        /// This adds a primary and a payload
        /// </summary>
        /// <param name="primaryKeyValue">PrimaryKey</param>
        /// <param name="payload">Data payload to be loaded</param>
        /// <param name="insertable">Is an insert operation</param>
        private void Init(string primaryKeyValue, DataPayLoad payload, bool insertable)
        {
            Stopwatch srStopwatch = new Stopwatch();
            srStopwatch.Start();
            if (payload.HasDataObject)
            {
                _vehicleDo = (IVehicleData) payload.DataObject;
              
                DataObject = _vehicleDo;

                EventManager.SendMessage(UpperBarViewVehicleViewModel.Name, payload);
                ActiveSubSystem();
            }
            srStopwatch.Stop();
            var value = srStopwatch.ElapsedMilliseconds;

        }
        /// <summary>
        /// Primary key payload.
        /// </summary>
        /// <param name="primaryKeyValue">This deletes an item.</param>
        private void DeleteItem(string primaryKeyValue)
        {
            string primaryKey = primaryKeyValue;
            if (primaryKey == PrimaryKeyValue)
            {
                DataPayLoad dataPayload = new DataPayLoad();
                dataPayload.HasDataObject = true;
                dataPayload.PrimaryKeyValue = PrimaryKeyValue;
                _deleteNotifyTaskCompletion = NotifyTaskCompletion.Create<DataPayLoad>(HandleDeleteItem(dataPayload), _deleteEventHandler);
                PrimaryKeyValue = "";
            }
        }

        /// <summary>
        /// Delete a commission agent.
        /// </summary>
        /// <param name="inDataPayLoad"></param>
        /// <returns></returns>
        private async Task<DataPayLoad> HandleDeleteItem(DataPayLoad inDataPayLoad)
        {
            IVehicleData vehicle = await _vehicleDataServices.GetVehicleDo(inDataPayLoad.PrimaryKeyValue);
            DataPayLoad payload = new DataPayLoad();
            if (vehicle.Valid)
            {
                bool returnValue = await _vehicleDataServices.DeleteVehicleDo(vehicle);
                if (returnValue)
                {
                    payload.Subsystem = DataSubSystem.VehicleSubsystem;
                    payload.PrimaryKeyValue = inDataPayLoad.PrimaryKeyValue;
                    payload.PayloadType = DataPayLoad.Type.Delete;
                    EventManager.NotifyToolBar(payload);
                    PrimaryKeyValue = "";
                    _vehicleDo = null;
                }
            }
            return payload;
        }
        /// <summary>
        /// Incoming payload
        /// </summary>
        /// <param name="dataPayLoad">Payload to be used.</param>
        public void IncomingPayload(DataPayLoad dataPayLoad)
        {

            DataPayLoad payload = dataPayLoad;

            if (payload != null)
            {
                if (PrimaryKeyValue.Length == 0)
                {
                    PrimaryKeyValue = payload.PrimaryKeyValue;
                    string mailboxName = "Vehicles." + PrimaryKeyValue;
                    if (MailBoxHandler != null)
                    {
                        EventManager.RegisterMailBox(mailboxName, MailBoxHandler);
                    }
                }
                // here i can fix the primary key
                switch (payload.PayloadType)
                {
                    case DataPayLoad.Type.UpdateData:
                    {
                        if (payload.HasDataObject)
                        {
                          DataObject = MergeDataObject(DataObject, payload.DataObject);
                      //    DataObject = payload.DataObject;
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
                        if (string.IsNullOrEmpty(PrimaryKeyValue))
                        {
                            CurrentOperationalState = DataPayLoad.Type.Insert;
                            PrimaryKeyValue =
                                _vehicleDataServices.GetNewId();
                            Init(PrimaryKeyValue, true);
                        }
                        break;
                    }

                    case DataPayLoad.Type.Delete:
                    {
                        DeleteItem(payload.PrimaryKeyValue);
                        break;
                    }
                }
            }

        }

        private object MergeDataObject(object dataObject, object payloadDataObject)
        {
            return dataObject;
        }
    }
}
