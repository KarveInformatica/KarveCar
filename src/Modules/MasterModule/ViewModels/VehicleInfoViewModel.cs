﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KarveCommon.Services;
using KarveDataServices;
using MasterModule.Common;
using KarveDataServices.DataObjects;
using KarveCommon.Generic;
using System.ComponentModel;
using AutoMapper;
using DataAccessLayer.Logic;
using KarveDataServices.ViewObjects;
using MasterModule.Views.Vehicles;
using Prism.Commands;
using Prism.Regions;
using KarveCommonInterfaces;
using DataAccessLayer.SQL;
using KarveCommon;
using System.Linq;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MasterModule.ViewModels
{
    /// <summary>
    ///  This represent the detailed class for the view model in case of each car.
    /// </summary>
    partial class VehicleInfoViewModel: MasterInfoViewModuleBase, IEventObserver, IDataErrorInfo
    {
        private const string DefaultViewInfoRegionName = "TabRegion";

        /// <summary>
        ///  Vehicle Data Services.
        /// </summary>
        private readonly IVehicleDataServices _vehicleDataServices;
        private IVehicleData _vehicleDo;
        private object _dataObject;
        private object _deleteNotifyTaskCompletion;
        private INotifyTaskCompletion<IVehicleData> _initializationTable;
       
        private string _assistQueryOwner;
        private IEnumerable<VehicleActivitiesViewObject> _activity;
        private IEnumerable<AgentViewObject> _agents;
        private IEnumerable<OwnerViewObject> _owner;
        private IEnumerable<SupplierSummaryViewObject> _supplier;
        private IEnumerable<PaymentFormViewObject> _paymentFormDto;
        private IEnumerable<ClientSummaryExtended> _clients;
        private IEnumerable<ResellerViewObject> _vendedor;
        private IEnumerable<ClientSummaryExtended> _clientDto;
        private IEnumerable<SupplierSummaryViewObject> _assuranceCompany;
        private IEnumerable<SupplierSummaryViewObject> _assuranceAgent;
        private IEnumerable<SupplierSummaryViewObject> _assuranceAdditionalCompany;
        private IEnumerable<SupplierSummaryViewObject> _assistanceAssuranceCompany;
        private IEnumerable<SupplierSummaryViewObject> _assistancePolicyAssuranceCompany;
        private IEnumerable<MaintainanceViewObject> _maintenaince;
        
        private INotifyTaskCompletion<IEnumerable<ElementDto>> _elementLoadNotifyTaskCompletion;

        // this is in the vehicle stuff.
        private readonly PropertyChangedEventHandler _deleteEventHandler;
        /// <summary>
        ///  vehicle revision
        /// </summary>
        private IEnumerable<UiComposedFieldObject> _vehicleRevision;
        /// <summary>
        ///  account stuff.
        /// </summary>
        private IEnumerable<AccountViewObject> _accountDto;
        private IEnumerable<ElementDto> _elementDto;
        private IEnumerable<AccountViewObject> _accountPreviousRepaymentDto;
        private IEnumerable<AccountViewObject> _accountImmobilizedDto;
        private IEnumerable<AccountViewObject> _accountDtoPaymentAccountDto;
        private IEnumerable<AccountViewObject> _accountDtoCapitalCp;
        private IEnumerable<AccountViewObject> _accomulatedRepayment;
        private IRegionManager _regionManager;
        private IEnumerable<CityViewObject> _cityDto;
        private IEnumerable<CityViewObject> _roadTaxesCities ;
        private IEnumerable<ZonaOfiViewObject> _officeZoneRoadTaxes;
        private IEnumerable<CurrentSituationViewObject> _situationDto;
        private IEnumerable<OfficeViewObject> _otherOffice1Dto;
        private IEnumerable<OfficeViewObject> _otherOffice2Dto ;
        private IEnumerable<OfficeViewObject> _otherOffice3Dto ;
        private IEnumerable<BrandVehicleViewObject> _brandDtos;
        private IEnumerable<ModelVehicleViewObject> _modelDtos;
        private IEnumerable<VehicleGroupViewObject> _vehicleGroupDtos;
        private IEnumerable<ColorViewObject> _colorDto;
        private readonly QueryStoreFactory _queryStoreFactory;
        private ICollection<string> _dataFieldCollection;
        private IAssistDataService _assistDataService;
        private IEnumerable<ResellerViewObject> _resellerDto;
        private ICommand _saveCommand;
        private IEnumerable<SupplierSummaryViewObject> _buyerSupplier = new List<SupplierSummaryViewObject>();

        // This returns the list of activity when asked.
        public IEnumerable<VehicleActivitiesViewObject> ActivityDtos
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

        public IEnumerable<ResellerViewObject> VendedorDtos
        {
            get { return _vendedor; }
            set { _vendedor = value; RaisePropertyChanged(); }
        }


        /// <summary>
        ///  This returns the list of agents.
        /// </summary>
        public IEnumerable<AccountViewObject> AccountDtos
        {
            get
            {
                return _accountDto;
            }
            set
            {
                _accountDto = value;
                RaisePropertyChanged();
            }
        }


        /// <summary>
        ///  This returns the list of agents.
        /// </summary>
        public IEnumerable<AccountViewObject> AccountDtosImmobilized
        {
            get
            {
                return _accountImmobilizedDto;
            }
            set
            {
                _accountImmobilizedDto = value;
                RaisePropertyChanged();
            }
        }

      


        /// <summary>
        ///  This returns the list of agents.
        /// </summary>
        public IEnumerable<AccountViewObject> AccountDtoPreviousRepayment
        {
            get
            {
                return _accountPreviousRepaymentDto;
            }
            set
            {
                _accountPreviousRepaymentDto = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        ///  This returns the list of agents.
        /// </summary>
        public IEnumerable<AccountViewObject> AccountDtoPaymentAccount
        {
            get
            {
                return _accountDtoPaymentAccountDto;
            }
            set
            {
                _accountDtoPaymentAccountDto = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        ///  This returns the list of agents.
        /// </summary>
        public IEnumerable<AccountViewObject> AccountDtoCapitalCp
        {
            get
            {
                return _accountDtoCapitalCp;
            }
            set
            {
                _accountDtoCapitalCp = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        ///  This returns the list of agents.
        /// </summary>
        public IEnumerable<ElementDto> ElementDtos
        {
            get
            {
                return _elementDto;
            }
            set
            {
                _elementDto = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        ///  This returns the list of agents.
        /// </summary>
        public IEnumerable<AgentViewObject> AgentDtos
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
        public IEnumerable<OwnerViewObject> OwnerDtos
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
        public IEnumerable<SupplierSummaryViewObject> AssuranceDtos
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

        public IEnumerable<SupplierSummaryViewObject> AdditionalAssuranceDtos
        {
            get
            {
                return _assuranceAdditionalCompany;
            }
            set
            {
                _assuranceAdditionalCompany = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<SupplierSummaryViewObject> AssistanceAssuranceDtos
        {
            get
            {
                return _assistanceAssuranceCompany;
            }
            set
            {
                _assistanceAssuranceCompany = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<SupplierSummaryViewObject> AssistancePolicyAssuranceDtos
        {
            get
            {
                return _assistancePolicyAssuranceCompany;
            }
            set
            {
                _assistancePolicyAssuranceCompany = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        ///  This returns a maintenance collection 
        /// </summary>
        public IEnumerable<MaintainanceViewObject> MaintenanceCollection
        {
            get
            {
                return _maintenaince;
            }
            set
            {
                _maintenaince = value;
                RaisePropertyChanged();
            }
        }


        public IEnumerable<AccountViewObject> AccountDtoAccmulatedRepayment
        {
            get { return _accomulatedRepayment; }
            set
            {
                _accomulatedRepayment = value; RaisePropertyChanged();
            }
        }

        /// <summary>
        ///  This is an assurance agent dtos.
        /// </summary>
        public IEnumerable<SupplierSummaryViewObject> AssuranceAgentDtos
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
        /// <summary>
        ///  This returns a client dtpo.
        /// </summary>
        public IEnumerable<ClientSummaryExtended> ClientesDtos
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
        /// <param name="dialogService"></param>
        /// <param name="services">Data access layer interface</param>
        public VehicleInfoViewModel(IConfigurationService configurationService, IEventManager eventManager, 
            IDialogService dialogService,
            IDataServices services, IRegionManager regionManager, IInteractionRequestController requestController) : 
            base(eventManager, configurationService,services ,dialogService,regionManager, requestController)
        {
            // by default is not initialized until it comes to Init completed.
            IsViewModelInitialized = false;
            SubSystem = DataSubSystem.VehicleSubsystem;
 			MailBoxHandler += MessageHandler;
            _vehicleDataServices = services.GetVehicleDataServices();
            _assistDataService = services.GetAssistDataServices();
            ItemChangedCommand = new DelegateCommand<object>(ChangeUnpack);
            MetaDataObject = InitAssuranceObject();
            DataFieldCollection = InitDataField();
            RevisionObject = InitRevisionComposedFieldObjects();
            MaintenanceCollection = _maintenaince;
            _regionManager = regionManager;
            _deleteEventHandler+=DeleteEventHandler;
            EventManager.RegisterObserverSubsystem(MasterModuleConstants.VehiclesSystemName, this);
            AssistCommand = new DelegateCommand<object>(AssistCommandHelper);
            _queryStoreFactory = new QueryStoreFactory();
            _saveCommand = new DelegateCommand<object>(OnSaveCommand);
            var gid = Guid.NewGuid();
             ViewModelUri = new Uri("karve://vehicle/viewmodel?id=" + gid.ToString());

            ActiveSubSystem();
        }

        private async void OnSaveCommand(object obj)
        {
            var data = DataObject as IVehicleData;
            var dataService = DataServices.GetVehicleDataServices();
            var task = dataService.SaveAsync(data).ConfigureAwait(false);
            var result = await task;
            if (!result)
            {
                DialogService?.ShowErrorMessage("Error during saving the object");
            }
        }

        private async Task<IEnumerable<ElementDto>> InitElements()
        {
            IEnumerable<ElementDto> value = await DataServices.GetHelperDataServices().GetAsyncHelper<ElementDto>(GenericSql.ElementsSummaryQuery);
            return value;
        }
        public IEnumerable<UiComposedFieldObject> RevisionObject
        {
             get { return _vehicleRevision; }
            set { _vehicleRevision = value; RaisePropertyChanged(); }
        }
        // TODO: using the configure
        private async void AssistCommandHelper(object param)
        {
            IDictionary<string, string> values = param as Dictionary<string, string>;
            string assistTableName = values != null && values.ContainsKey("AssistTable") ? values["AssistTable"]  : null;
            string assistQuery = values.ContainsKey("AssistQuery") ? values["AssistQuery"]  : null;
            /*  ok now i have to handle the assist helper.
             *  The smartest thing is to detect the table from the query.
             */

            var resultMap = await _assistDataService.Mapper.ExecuteAssistGeneric(assistTableName.ToUpper(), assistQuery);

            IMapper mapper = MapperField.GetMapper();
            IHelperDataServices helperDataServices = DataServices.GetHelperDataServices();
            if (assistTableName != null)
            {
                assistTableName = assistTableName.ToUpper();

                switch (assistTableName)
                {
                    case "ACTIVEHI":
                    {
                        ActivityDtos = resultMap as IEnumerable<VehicleActivitiesViewObject>;
                        break;
                    }
                    case "PROPIE":
                    {
                        OwnerDtos = resultMap as IEnumerable<OwnerViewObject>;
                        break;
                    }
                    case "AGENTES":
                    {
                        AgentDtos = resultMap as IEnumerable<AgentViewObject>;
                        break;
                    }
                    case "ASSURANCE":
                    {
                        AssuranceDtos = resultMap as IEnumerable<SupplierSummaryViewObject>;
                        break;
                    }
                    case "ASSURANCE_1":
                    {
                        AssistancePolicyAssuranceDtos = resultMap as IEnumerable<SupplierSummaryViewObject>;
                        break;
                    }
                    case "ASSURANCE_2":
                    {
                        AdditionalAssuranceDtos = resultMap as IEnumerable<SupplierSummaryViewObject>;
                        break;
                    }
                    case "ASSURANCE_3":
                    {
                        AssistanceAssuranceDtos = resultMap as IEnumerable<SupplierSummaryViewObject>;
                        break;
                    }
                    case "ASSURANCE_AGENT":
                    {
                        AssuranceAgentDtos = resultMap as IEnumerable<SupplierSummaryViewObject>;
                        break;
                    }
                    case "PROVEE1":
                    {
                        BuyerSupplierDto = resultMap as IEnumerable<SupplierSummaryViewObject>;
                        break;
                    }
                    case "PROVEE2":
                    {
                        ProveeDto2 = resultMap as IEnumerable<SupplierSummaryViewObject>;
                        break;
                    }

                    case "CU1":
                    {
                        AccountDtos = resultMap as IEnumerable<AccountViewObject>;
                        break;
                    }
                    case "FORMAS":
                    {
                        PaymentFormDto = resultMap as IEnumerable<PaymentFormViewObject>;
                        break;
                    }
                    case "CLIENTES1":
                    {
                        ClientsDto = resultMap as IEnumerable<ClientSummaryExtended>;
                        break;
                    }
                    case "CLIENT_ASSIST":
                        {
                            ClientsDto = resultMap as IEnumerable<ClientSummaryExtended>;
                            break;
                        }
                    case "ACCOUNT_INMOVILIZADO":
                    {
                        AccountDtosImmobilized = resultMap as IEnumerable<AccountViewObject>;
                        break;
                    }
                    case "ACCOUNT_PAYMENT_ACCOUNT":
                    {
                        AccountDtoPaymentAccount = resultMap as IEnumerable<AccountViewObject>;
                        break;
                    }
                    case "ACCOUNT_PREVIUOS_PAYMENT":
                    {
                            AccountDtoPreviousRepayment = resultMap as IEnumerable<AccountViewObject>;

                                                    break;
                    }
                    case "ACCOUNT_ACCUMULATED_REPAYMENT":
                    {
                        AccountDtoAccmulatedRepayment = resultMap as IEnumerable<AccountViewObject>;
                        break;
                    }
                    case "POBLACIONES":
                    {
                        CityDto = resultMap as IEnumerable<CityViewObject>;
                        break;
                    }
                    case "OFICINA1":
                    {
                        OtherOffice1Dto = resultMap as IEnumerable<OfficeViewObject>;
                        break;
                    }
                    case "OFICINA2":
                    {
                        OtherOffice2Dto = resultMap as IEnumerable<OfficeViewObject>;
                        break;
                    }
                    case "OFICINA3":
                    {
                        OtherOffice3Dto = resultMap as IEnumerable<OfficeViewObject>;
                        break;
                    }

                    case "COLORFL":
                    {
                        ColorDtos = resultMap as IEnumerable<ColorViewObject>;
                        break;
                    }
                    case "MARCAS":
                   {
                        BrandDtos = (IEnumerable<BrandVehicleViewObject>) resultMap;
                        break;
                    }
                    case "MODELO":
                    {
                        ModelDtos = resultMap as IEnumerable<ModelVehicleViewObject>;
                        break;
                    }
                    case "GRUPOS":
                    {
                        VehicleGroupDtos = resultMap as IEnumerable<VehicleGroupViewObject>;
                        break;
                    }
                    case "SITUATION":
                    {
                        CurrentSituationDto = resultMap as IEnumerable<CurrentSituationViewObject>;
                        break;
                    }
                    case "ROAD_TAXES_CITY":
                    {
                        RoadTaxesCityDto = resultMap as IEnumerable<CityViewObject>;
                        break;
                    }
                    case "ROAD_TAXES_ZONAOFI":
                    {
                        RoadTaxesOfficeZoneDto =resultMap as IEnumerable<ZonaOfiViewObject>;
                        break;
                    }
                    case "RESELLER_ASSIST":
                    {
                        ResellerDto = resultMap as IEnumerable<ResellerViewObject>;
                        break;
                    }
                }
            }
        }
        /// <summary>
        ///  SupplierAssitQuery
        /// </summary>
        public string SupplierAssistQuery
        {
            get
            {
                IQueryStore store = _queryStoreFactory.GetQueryStore();
                store.AddParam(QueryType.QuerySupplierSummary);
                return store.BuildQuery();
            }
        }
        /// <summary>
        ///  SellerAssistQuery.
        /// </summary>
        public string SellerAssistQuery
        {
            get
            {
                IQueryStore store = _queryStoreFactory.GetQueryStore();
                store.AddParam(QueryType.QuerySellerSummary);
                return store.BuildQuery();
            }
        }
        public IEnumerable<ZonaOfiViewObject> RoadTaxesOfficeZoneDto
        {
            get
            {
                return _officeZoneRoadTaxes;
            }
            set
            {
                _officeZoneRoadTaxes = value;
                RaisePropertyChanged();
            }
        }

        public ICollection<string> DataFieldList
        {
            get => _dataFieldCollection;
            set
            {
                _dataFieldCollection = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<CurrentSituationViewObject> SituationDto
        {
            get => _situationDto;
            set
            {
                _situationDto = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<SupplierSummaryViewObject> BuyerSupplierDto
        {
            get { return _buyerSupplier; }
            set { _buyerSupplier = value; RaisePropertyChanged(); }
        }
        public IEnumerable<SupplierSummaryViewObject> ProveeDto
        {
            get { return _supplier; }
            set { _supplier = value; RaisePropertyChanged(); }
        }
        public IEnumerable<SupplierSummaryViewObject> ProveeDto2
        {
            get { return _supplier; }
            set { _supplier = value; RaisePropertyChanged(); }
        }

        public object DataObject
        {
            get => _dataObject;
            set { _dataObject = value;
                MetaDataObject = InitAssuranceObject();
                DataFieldCollection = InitDataField();
                RaisePropertyChanged();
            }
        }
        
        
        
        public string Error => throw new NotImplementedException();

        public string this[string columnName] => throw new NotImplementedException();

        /// <summary>
        /// This is the start notify.
        /// </summary>
        public void StartAndNotify()
        {
            _initializationTable =
                NotifyTaskCompletion.Create<IVehicleData>(LoadDataValue(PrimaryKeyValue, IsInsertion), InitializationDataObjectOnPropertyChanged);
            
        }
        /// <summary>
        /// Load element account.
        /// </summary>
        private void LoadElementAccounts()
        {
            _elementLoadNotifyTaskCompletion =
                NotifyTaskCompletion.Create<IEnumerable<ElementDto>>(InitElements(), InitializationElementDto);
        }

        private void InitializationElementDto(object sender, PropertyChangedEventArgs e)
        {
            if (sender is IEnumerable<ElementDto>)
            {
                ElementDtos = (IEnumerable<ElementDto>) sender;

            }
        }

        private void InitializationDataObjectOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (sender is IVehicleData)
            {
                IVehicleData vehicle = (IVehicleData) sender;
                DataObject = vehicle;
             
            }
        }
      

        private void ChangeUnpack(object value)
        {
            if (value is IDictionary<string, object> changedItem)
            {
                OnChangedField(changedItem);
            }
        }
        /// <summary>
        ///  1. The process is receiving the eventDictionary from components.
        ///  2. Then we build an update or insert payload.
        ///  3. Then we send the payload to the toolbar.
        ///  OnChangedField. This method shall be changed moved to the upper level.
        /// </summary>
        /// <param name="eventDictionary">Dictionary of events.</param>
        private void OnChangedField(IDictionary<string, object> eventDictionary)
        {
            DataPayLoad payLoad = BuildDataPayload(eventDictionary);
            payLoad.Subsystem = DataSubSystem.VehicleSubsystem;
            if (string.IsNullOrEmpty(payLoad.PrimaryKeyValue))
            {
                payLoad.PrimaryKeyValue = PrimaryKeyValue;
                payLoad.PayloadType = DataPayLoad.Type.Update;
            }
            // set base payload
            SetBasePayLoad(eventDictionary, ref payLoad);

            ChangeFieldHandlerDo<IVehicleData> handlerDo = new ChangeFieldHandlerDo<IVehicleData>(EventManager,DataSubSystem.VehicleSubsystem);
            // enforce the data object value before sending to the toolbar.

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
                vehicle = _vehicleDataServices.GetNewDo(PrimaryKeyValue);
                if (vehicle != null)
                {
                    DataObject = vehicle;
                }
            }
            else
            {
                vehicle = await _vehicleDataServices.GetDoAsync(primaryKeyValue).ConfigureAwait(false);
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
            
            public IEnumerable<PaymentFormViewObject> PaymentFormDto {
            get { return _paymentFormDto; }
            private set { _paymentFormDto = value; RaisePropertyChanged();}
        }

        public IEnumerable<ClientSummaryExtended> ClientsDto
        {
            get { return _clientDto; }
            set
            {
                _clientDto = value;
                RaisePropertyChanged();
            }
            
        }
        /// <summary>
        ///  This method set the registration payload.
        /// </summary>
        /// <param name="payLoad"></param>
        protected override void SetRegistrationPayLoad(ref DataPayLoad payLoad)
        {
            payLoad.PayloadType = DataPayLoad.Type.RegistrationPayload;
            payLoad.Subsystem = DataSubSystem.VehicleSubsystem;
            payLoad.HasSaveCommand = true;
            payLoad.SaveCommand = _saveCommand;
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
            if (IsViewModelInitialized)
            {
                return;
            }
            if (!payload.HasDataObject)
            {
                return;
            }
            _vehicleDo = (IVehicleData) payload.DataObject;
            if (_vehicleDo == null)
            {
                DialogService?.ShowErrorMessage("There is an error while doing the last operation");
            }
            DataObject = _vehicleDo;
            ModelDtos = _vehicleDo?.ModelDtos;
            SetDataObjects(_vehicleDo);



            if (_vehicleDo?.MaintenanceHistory != null)
            {
                MaintenanceCollection = new ObservableCollection<MaintainanceViewObject>(_vehicleDo.MaintenanceHistory);
            }
            RevisionObject = InitRevisionComposedFieldObjects();
            ActiveSubSystem();
            IsViewModelInitialized = true;
        }
        private void SetDataObjects(IVehicleData vehicle)
        {
            if (vehicle.BrandDtos.Count() == 0)
            {
                var brand = new BrandVehicleViewObject();
                var firstModel = _vehicleDo.ModelDtos.FirstOrDefault();
                if (firstModel != null)
                {
                    brand.Code = firstModel.Marca;
                    brand.Name = firstModel.NomeMarca;
                    var brandVehi = new List<BrandVehicleViewObject>() { brand };
                    vehicle.BrandDtos = vehicle.BrandDtos.Union(brandVehi);
                }
            }
            else
            {
                BrandDtos = _vehicleDo?.BrandDtos;
            }
            ColorDtos = _vehicleDo?.ColorDtos;
            VehicleGroupDtos = _vehicleDo?.VehicleGroupDtos;
            MaintenanceCollection = _vehicleDo.MaintenanceHistory;



            if (_vehicleDo?.ActivityDtos != null)
            {
                ActivityDtos = _vehicleDo?.ActivityDtos;

            }
            if (_vehicleDo?.OwnerDtos != null)
            {
                OwnerDtos = _vehicleDo?.OwnerDtos;
            }
            if (_vehicleDo?.AgentsDto != null)
            {
                AgentDtos = _vehicleDo?.AgentsDto;
            }
            if (_vehicleDo?.Supplier1 != null)
            {
                this.BuyerSupplierDto = _vehicleDo.Supplier1;
            }
            if (_vehicleDo?.PaymentForm != null)
            {
                PaymentFormDto = _vehicleDo.PaymentForm;
            }
            if (_vehicleDo?.ResellerDto!=null)
            {
                ResellerDto = _vehicleDo.ResellerDto;
            }
            if (_vehicleDo?.ClientDto != null)
            {
                ClientsDto = _vehicleDo.ClientDto;
            }
            if (_vehicleDo?.Supplier2 != null)
            {
                this.ProveeDto2 = _vehicleDo.Supplier2;
            }
            if (_vehicleDo?.RoadOfficeZoneDto != null)
            {
                this.RoadTaxesOfficeZoneDto = _vehicleDo.RoadOfficeZoneDto;
            }
            if (_vehicleDo?.RoadOfficeZoneDto != null)
            {
                this.RoadTaxesCityDto = _vehicleDo.RoadTaxesCityDto;
            }
            if (_vehicleDo?.AdditionalAssuranceDto != null)
            {
                this.AdditionalAssuranceDtos = _vehicleDo.AdditionalAssuranceDto;
            }
            if (_vehicleDo?.AssistenceAssuranceDto != null)
            {
                this.AssistanceAssuranceDtos = _vehicleDo.AssistenceAssuranceDto;
            }
            if (_vehicleDo?.AssistencePolicyDto != null)
            {
                this.AssistancePolicyAssuranceDtos = _vehicleDo.AssistencePolicyDto;
            }

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
                DataPayLoad dataPayload = new DataPayLoad
                {
                    HasDataObject = true,
                    PrimaryKeyValue = PrimaryKeyValue
                };
                _deleteNotifyTaskCompletion = NotifyTaskCompletion.Create<DataPayLoad>(HandleDeleteItem(dataPayload), _deleteEventHandler);
                
              
            }
        }
        
        /// <summary>
        /// Delete a commission agent.
        /// </summary>
        /// <param name="inDataPayLoad"></param>
        /// <returns></returns>
        private async Task<DataPayLoad> HandleDeleteItem(DataPayLoad inDataPayLoad)
        {
           var vehicle = await _vehicleDataServices.GetDoAsync(inDataPayLoad.PrimaryKeyValue);
            var payload = new DataPayLoad();
            if (!vehicle.Valid)
            {
                return payload;
            }
            var returnValue = await _vehicleDataServices.DeleteAsync(vehicle);

            if (!returnValue)
            {
                return payload;
            }
            payload.Subsystem = DataSubSystem.VehicleSubsystem;
            payload.PrimaryKeyValue = inDataPayLoad.PrimaryKeyValue;
            payload.PayloadType = DataPayLoad.Type.Delete;
            EventManager.NotifyToolBar(payload);
            PrimaryKeyValue = "";
            _vehicleDo = null;
            // DeleteRegion(payload.PrimaryKeyValue);
            return payload;
        }
    
        public IEnumerable<CityViewObject> CityDto
        {
            get => _cityDto;
            set {
                _cityDto = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<CityViewObject> RoadTaxesCityDto
        {
            get
            {
                return _roadTaxesCities;
            }
            set
            {
                _roadTaxesCities = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<CurrentSituationViewObject> CurrentSituationDto
        {
            get { return _situationDto; }
            set { _situationDto = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// Other office 1 viewObject
        /// </summary>
        public IEnumerable<OfficeViewObject> OtherOffice1Dto
        {
            get { return _otherOffice1Dto; }
            set { _otherOffice1Dto = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// Other office 2 viewObject
        /// </summary>
        public IEnumerable<OfficeViewObject> OtherOffice2Dto
        {
            get { return _otherOffice2Dto; }
            set { _otherOffice2Dto = value; RaisePropertyChanged(); }
        }
        /// <summary>
        /// Other office 3 viewObject
        /// </summary>
        public IEnumerable<OfficeViewObject> OtherOffice3Dto
        {
            get { return _otherOffice3Dto; }
            set { _otherOffice3Dto = value; RaisePropertyChanged(); }
        }
        public IEnumerable<ResellerViewObject> ResellerDto
        {
            get { return _resellerDto; }
            set { _resellerDto = value; RaisePropertyChanged(); }
        }
        /// <summary>
        ///  BrandDtos. Brand Dto.
        /// </summary>
        public IEnumerable<BrandVehicleViewObject> BrandDtos
        {
            get
            {
                return _brandDtos;
            }
            set
            {
                _brandDtos = value;
                RaisePropertyChanged("BrandDtos");
            }
        }
        /// <summary>
        ///  ModelDtos. Model vehicle viewObject.
        /// </summary>
        public IEnumerable<ModelVehicleViewObject> ModelDtos
        {
            get => _modelDtos;
            set
            {
                _modelDtos = value;
                RaisePropertyChanged("ModelDtos");
            }
        }
        /// <summary>
        ///  VehicleGroup Dtos.
        /// </summary>
        public IEnumerable<VehicleGroupViewObject> VehicleGroupDtos {
            get
            {
                return _vehicleGroupDtos;
            }
            set
            {
                _vehicleGroupDtos = value;
                RaisePropertyChanged("VehicleGroupDtos");
            }
        }
        /// <summary>
        /// ColorDtos. 
        /// </summary>
        public IEnumerable<ColorViewObject> ColorDtos
        {
            get
            {
                return _colorDto;
            }
            set
            {
                _colorDto = value;
                RaisePropertyChanged("ColorDtos");
            }
        }
        public ISqlCommand VehicleCopyCommand
        {
            set; get;
        }
        // move this to the upper interface.
        /// <summary>
        /// Incoming payload
        /// </summary>
        /// <param name="dataPayLoad">Payload to be used.</param>
        public override void IncomingPayload(DataPayLoad dataPayLoad)
        {

            DataPayLoad payload = dataPayLoad;

            if (payload != null)
            {
                if (PrimaryKeyValue.Length == 0)
                {
                    PrimaryKeyValue = payload.PrimaryKeyValue;
                    string mailboxName = "Vehicles." + PrimaryKeyValue;
                    if (!string.IsNullOrEmpty(PrimaryKeyValue))
                    {
                        if (MailBoxHandler != null)
                        {
                            EventManager.RegisterMailBox(mailboxName, MailBoxHandler);
                        }
                    }
                }
                // here i can fix the primary key
                switch (payload.PayloadType)
                {
                    case DataPayLoad.Type.UpdateData:
                    {
                        if (payload.HasDataObject)
                        {
                          DataObject = payload.DataObject;
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
                                _vehicleDataServices.NewId();

                            CurrentOperationalState = DataPayLoad.Type.Insert;
                        }
                        Init(PrimaryKeyValue, payload, true);
                        break;
                    }
                    case DataPayLoad.Type.Delete:
                    {
                    
                            if (PrimaryKey == payload.PrimaryKey)
                            {
                                DeleteEventCleanup(payload.PrimaryKeyValue, PrimaryKeyValue, DataSubSystem.VehicleSubsystem, 
                                    MasterModuleConstants.VehiclesSystemName);
                                DeleteRegion(payload.PrimaryKeyValue);
                               
                            }
                        break;
                    }
                }
            }

        }

        internal override Task SetClientData(ClientSummaryExtended p, VisitsViewObject b)
        {
                 throw new NotImplementedException();
        }

        internal override Task SetVisitContacts(ContactsViewObject p, VisitsViewObject visitsViewObject)
        {
            throw new NotImplementedException();
        }

        internal override Task SetBranchProvince(ProvinceViewObject p, BranchesViewObject b)
        {
            throw new NotImplementedException();
        }

        internal override Task SetVisitReseller(ResellerViewObject param, VisitsViewObject b)
        {
            throw new NotImplementedException();
        }
    }
}
