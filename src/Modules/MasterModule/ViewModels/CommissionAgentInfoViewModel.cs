using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using AutoMapper;
using DataAccessLayer.DataObjects;
using DataAccessLayer.Logic;
using KarveCommon.Generic;
using KarveCommon.Services;
using KarveControls.UIObjects;
using KarveDataServices;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;
using MasterModule.Common;
using MasterModule.UIObjects.CommissionAgents;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Win32;
using Prism.Regions;
using Syncfusion.Windows.Shared;
using DelegateCommand = Prism.Commands.DelegateCommand;

namespace MasterModule.ViewModels
{
    /// <summary>
    /// This view model is the commission agent view model
    /// </summary>
    /// CommissionAgentInfoViewModel
    public partial class CommissionAgentInfoViewModel : MasterInfoViewModuleBase, IDataErrorInfo, IEventObserver
    {
        private const string TableNameComisio = "COMISIO";
        private Visibility _visibility;
        private DataTable _commissionTable;
        private IDictionary<string, string> _queries;
        private string _primaryKeyValue = "";
        private bool _isInsertion = false;
        private ObservableCollection<UiDfSearch> _leftObservableCollection;
        private ObservableCollection<IUiObject> _rightObservableCollection;
        private ObservableCollection<IUiObject> _upperObservableCollection;
        private ICommissionAgentDataServices _commissionAgentDataServices;
        private INotifyTaskCompletion<ICommissionAgent> _initializationTable;
        private INotifyTaskCompletion<DataPayLoad> _deleteNotifyTaskCompletion;
        private readonly PropertyChangedEventHandler _deleteEventHandler;

        /// <summary>
        /// Auxiliares tables. Each aux table has associated a data transfer object. 
        /// A DTO is an object that carries data between processes in order to reduce the number of method calls.
        /// This allows us to customize the number of columns to be shown in the grid.
        /// </summary>
        private ICommissionAgent _commissionAgentDo;
        private IEnumerable<ProvinciaDto> _provincia = new List<ProvinciaDto>();
        private IEnumerable<CountryDto> _country = new List<CountryDto>();
        private IEnumerable<TIPOCOMI> _tipoComi = new List<TIPOCOMI>();
        private IEnumerable<ClientesDto> _clientOne = new List<ClientesDto>();
        private IEnumerable<ProductsDto> _products = new List<ProductsDto>();
        private IEnumerable<BusinessDto> _negocios = new List<BusinessDto>();
        private IEnumerable<MercadoDto> _mercados = new List<MercadoDto>();
        private IEnumerable<ChannelDto> _canal = new List<ChannelDto>();
        private IEnumerable<ResellerDto> _vendedor = new List<ResellerDto>();
        private IEnumerable<CommissionTypeDto> _tipocomisions = new List<CommissionTypeDto>();
        private IEnumerable<ZonaOfiDto> _officies = new List<ZonaOfiDto>();
        private IEnumerable<ClavePtoDto> _clavePto = new List<ClavePtoDto>();
        private IEnumerable<LanguageDto> _language = new List<LanguageDto>();
        private IEnumerable<BranchesDto> _branchesDto = new ObservableCollection<BranchesDto>();
        private string _uniqueId = "";
        /// <summary>
        ///  Data Transfer Objects for mercados
        /// </summary>
        public IEnumerable<MercadoDto> Mercado
        {
            get { return _mercados; }
            set { _mercados = value; RaisePropertyChanged(); }
        }
        /// <summary>
        ///  Data Transfer objects for negocio
        /// </summary>
        public IEnumerable<BusinessDto> Negocio
        {
            get { return _negocios; }
            set { _negocios = value; RaisePropertyChanged(); }
        }
        /// <summary>
        ///  Data Trasnfer object for canal
        /// </summary>
        public IEnumerable<ChannelDto> Canal
        {
            get { return _canal; }
            set { _canal = value; RaisePropertyChanged(); }
        }
        public IEnumerable<ResellerDto> Vendedor
        {
            get { return _vendedor; }
            set { _vendedor = value; RaisePropertyChanged(); }
        }
        public IEnumerable<CommissionTypeDto> TipoComission
        {
            get { return _tipocomisions; }
            set { _tipocomisions = value; RaisePropertyChanged(); }
        }
        /// <summary>
        /// ClavePto.
        /// </summary>
        public IEnumerable<ClavePtoDto> Clavepto
        {
            get { return _clavePto; }
            set
            {
                _clavePto = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<OrigenDto> Origen { get; set; }

        /// <summary>
        /// Province
        /// </summary>
        public IEnumerable<ProvinciaDto> Province
        {
            get { return _provincia; }
            set { _provincia = value; RaisePropertyChanged(); }
        }
        /// <summary>
        /// Country
        /// </summary>
        public IEnumerable<CountryDto> Country
        {
            get { return _country; }
            set { _country = value; RaisePropertyChanged(); }

        }
        /// <summary>
        /// Language dto.
        /// </summary>
        public IEnumerable<LanguageDto> Language
        {
            get { return _language; }
            set { _language = value; RaisePropertyChanged(); }
        }
        /// <summary>
        /// Offices.
        /// </summary>
        public IEnumerable<ZonaOfiDto> Offices
        {
            get { return _officies; }
            set { _officies = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// CommissionType
        /// </summary>
        public IEnumerable<TIPOCOMI> CommissionType
        {
            get { return _tipoComi; }
            set { _tipoComi = value; RaisePropertyChanged(); }

        }
        /// <summary>
        /// ClientOne
        /// </summary>
        public IEnumerable<ClientesDto> ClientOne
        {
            get { return _clientOne; }
            set { _clientOne = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// Products of the view model
        /// </summary>

        public IEnumerable<ProductsDto> Products
        {
            get { return _products; }
            set { _products = value; RaisePropertyChanged(); }
        }


        /// <summary>
        /// UpperValueCollection. 
        /// </summary>
        public ObservableCollection<IUiObject> UpperValueCollection
        {
            get { return _upperObservableCollection; }
            set { _upperObservableCollection = value; }
        }


        /// <summary>
        ///  LeftValueCollection. This returns the left value collection
        /// </summary>
        public ObservableCollection<UiDfSearch> LeftValueCollection
        {
            set { _leftObservableCollection = value; RaisePropertyChanged(); }
            get { return _leftObservableCollection; }
        }
        /// <summary>
        ///  This return the right value collection.
        /// </summary>
        public ObservableCollection<IUiObject> RightValueCollection
        {
            set
            {
                _rightObservableCollection = value; RaisePropertyChanged();

            }
            get
            {
                return _rightObservableCollection;
            }
        }
        /// <summary>
        ///  
        /// </summary>
        public ICommand PrintAssociate { set; get; }

        public ICommand DelegationChangedRowsCommand { set; get; }

        private IRegionManager _regionManager;
        private ObservableCollection<CityDto> _cityDto = new ObservableCollection<CityDto>();
        private string _mailBoxName;

        protected event SetPrimaryKey<BranchesDto> _onBranchesPrimaryKey;
        protected event SetPrimaryKey<ContactsDto> _onContactsPrimaryKey;
        //
        // A part of the ui is made up different objects inserted in a observable collection.
        //
        /// <summary>
        /// ViewModel for the commission agent. 
        /// </summary>
        /// <param name="configurationService">The configuration service will be used in this case</param>
        /// <param name="eventManager">Event manager</param>
        /// <param name="services">Services to be used</param>

        public CommissionAgentInfoViewModel(IConfigurationService configurationService,
                                            IEventManager eventManager,
                                            IDataServices services,
                                            IRegionManager regionManager) : base(eventManager, configurationService, services, regionManager)
        {

            _queries = new Dictionary<string, string>();
            _visibility = Visibility.Collapsed;
            _commissionAgentDataServices = DataServices.GetCommissionAgentDataServices();
            _regionManager = regionManager;
            _onBranchesPrimaryKey += CommissionAgentInfoViewModel__onBranchesPrimaryKey;
            _onContactsPrimaryKey += CommissionAgentInfoViewModel__onContactsPrimaryKey;
            IsVisible = Visibility.Collapsed;
            AssistQueryDictionary = new Dictionary<string, string>();
            PrimaryKeyValue = string.Empty;
            ConfigurationService = configurationService;
            MailBoxHandler += MessageHandler;
            AssistCommand = new Prism.Commands.DelegateCommand<object>(MagnifierCommandHandler);
            ItemChangedCommand = new Prism.Commands.DelegateCommand<object>(ItemChangedHandler);
            ActiveSubsystemCommand = new DelegateCommand(ActiveSubSystem);
            PrintAssociate = new DelegateCommand<object>(OnPrintCommand);   
            EventManager.RegisterObserverSubsystem(MasterModuleConstants.CommissionAgentSystemName, this);
            // register itself in the broacast.
            EventManager.RegisterObserver(this);
         
        }
        public override void DisposeEvents()
        {
            EventManager.DeleteObserver(this);
            EventManager.DeleteObserverSubSystem(MasterModuleConstants.ProviderSubsystemName, this);
            DeleteMailBox(_mailBoxName);
        }

        private void CommissionAgentInfoViewModel__onContactsPrimaryKey(ref ContactsDto primaryKey)
        {
            primaryKey.ContactsKeyId = PrimaryKeyValue;
        }

        private void CommissionAgentInfoViewModel__onBranchesPrimaryKey(ref BranchesDto primaryKey)
        {
            primaryKey.BranchKeyId = PrimaryKeyValue;
        }

        private void OnPrintCommand(object obj)
        { 
        }

        

        /// <summary>
        /// This is enabled to the change the handler
        /// The command deliver some parmetes.
        /// </summary>
        /// <param name="obj">The object conveyed from the command.</param>
        private void ItemChangedHandler(object obj)
        {

            IDictionary<string, object> eventDictionary = (Dictionary<string, object>)obj;
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
        /// <param name="obj">This send a delegation fo the changed command</param>
        private async void DelegationChangedCommandHandler(object obj)
        {
            Tuple<bool, BranchesDto> retValue = await GridChangedCommand<BranchesDto, COMI_DELEGA>(obj,
                _onBranchesPrimaryKey,
                DataSubSystem.CommissionAgentSubystem);
            if (retValue.Item1)
            {
                if ((_commissionAgentDo != null) && (_commissionAgentDo.DelegationDto != null))
                {
                    var tmp = _commissionAgentDo.DelegationDto;
                    Union<BranchesDto>(ref tmp, retValue.Item2);
                    _commissionAgentDo.DelegationDto = tmp;
                }

            }
        }

        // FIXME: move GridChangedCommand to a lower level

        private async void ContactsChangedCommandHandler(object obj)
        {
            Tuple<bool, ContactsDto> retValue = await GridChangedCommand<ContactsDto, CONTACTOS_COMI>(obj,
                _onContactsPrimaryKey,
                DataSubSystem.SupplierSubsystem);
            if (retValue.Item1)
            {
                if ((_commissionAgentDo != null) && (_commissionAgentDo.ContactsDto != null))
                {
                    var contactDto = retValue.Item2;
                    contactDto.ContactsKeyId = PrimaryKeyValue;
                    IEnumerable<ContactsDto> contactsDtos = new ObservableCollection<ContactsDto>();
                    Union<ContactsDto>(ref contactsDtos, contactDto);
                    _commissionAgentDo.ContactsDto = contactsDtos;
                }
            }

        }
        /// <summary>
        /// This item is enabled to the magnifier command. When the user press the magnifier.
        /// </summary>
        /// <param name="param">Parameter of the command</param>
        private async void MagnifierCommandHandler(object param)
        {
            IDictionary<string, string> values = (Dictionary<string, string>)param;
            string assistTableName = values.ContainsKey("AssistTable") ? values["AssistTable"] as string : null;
            string assistQuery = values.ContainsKey("AssistQuery") ? values["AssistQuery"] as string : null;
            await AssistQueryRequestHandlerDo(assistTableName, assistQuery);
        }

        // move to the master view model or to a data layer
        private async Task AssistQueryRequestHandlerDo(string assistTableName, string assistQuery)
        {
            IHelperDataServices helperDataServices = DataServices.GetHelperDataServices();
            object currentView = null;
            IMapper mapper = MapperField.GetMapper();

            switch (assistTableName)
            {

                case "PAIS":
                    {
                        var countries = await helperDataServices.GetAsyncHelper<Country>(assistQuery);
                        IEnumerable<CountryDto> countryDtos = mapper.Map<IEnumerable<Country>, IEnumerable<CountryDto>>(countries);
                        Country = countryDtos;
                        currentView = countryDtos;
                        break;
                    }
                case "PROVINCIA":
                    {
                        var prov = await helperDataServices.GetAsyncHelper<PROVINCIA>(assistQuery);
                        IEnumerable<ProvinciaDto> provDtos = mapper.Map<IEnumerable<PROVINCIA>, IEnumerable<ProvinciaDto>>(prov);
                        Province = provDtos;
                        currentView = provDtos;
                        break;
                    }
                case "POBLACIONES":
                {
                    var prov = await helperDataServices.GetAsyncHelper<POBLACIONES>(assistQuery);
                    IEnumerable<CityDto> cities = mapper.Map<IEnumerable<POBLACIONES>, IEnumerable<CityDto>>(prov);
                    CityDto = new ObservableCollection<CityDto>(cities);
                    currentView = CityDto;
                    break;
                }
                case "PRODUCTS":
                    {
                        var prod = await helperDataServices.GetAsyncHelper<PRODUCTS>(assistQuery);
                        IEnumerable<ProductsDto> productDto = mapper.Map<IEnumerable<PRODUCTS>, IEnumerable<ProductsDto>>(prod);
                        Products = productDto;
                        currentView = productDto;
                        break;
                    }

                case "VENDEDOR":
                    {
                        var vendedor = await helperDataServices.GetAsyncHelper<VENDEDOR>(assistQuery);
                        IEnumerable<ResellerDto> vendedorDto = mapper.Map<IEnumerable<VENDEDOR>, IEnumerable<ResellerDto>>(vendedor);
                        Vendedor = vendedorDto;
                        currentView = Vendedor;
                        break;
                    }
                case "MERCADO":
                    {
                        var mercados = await helperDataServices.GetAsyncHelper<MERCADO>(assistQuery);
                        IEnumerable<MercadoDto> mercadoDtos = mapper.Map<IEnumerable<MERCADO>, IEnumerable<MercadoDto>>(mercados);
                        Mercado = mercadoDtos;
                        currentView = Mercado;
                        break;
                    }
                case "NEGOCIO":
                    {
                        var negocio = await helperDataServices.GetAsyncHelper<NEGOCIO>(assistQuery);
                        IEnumerable<BusinessDto> negocios = mapper.Map<IEnumerable<NEGOCIO>, IEnumerable<BusinessDto>>(negocio);
                        Negocio = negocios;
                        currentView = Negocio;
                        break;

                    }
                case "CLIENTES1":
                    {
                        var clientes = await helperDataServices.GetAsyncHelper<CLIENTES1>(assistQuery);
                        IEnumerable<ClientesDto> cli = mapper.Map<IEnumerable<CLIENTES1>, IEnumerable<ClientesDto>>
                            (clientes);
                        ClientOne = cli;
                        currentView = ClientOne;
                        break;
                    }
                case "CANAL":
                    {
                        var canal = await helperDataServices.GetAsyncHelper<CANAL>(assistQuery);
                        IEnumerable<ChannelDto> cli = mapper.Map<IEnumerable<CANAL>, IEnumerable<ChannelDto>>(canal);
                        Canal = cli;
                        currentView = Canal;
                        break;
                    }
                case "TIPOCOMISION":
                    {
                        var tipocomisions = await helperDataServices.GetAsyncHelper<TIPOCOMISION>(assistQuery);
                        IEnumerable<CommissionTypeDto> cli = mapper.Map<IEnumerable<TIPOCOMISION>, IEnumerable<CommissionTypeDto>>(tipocomisions);
                        TipoComission = cli;
                        currentView = TipoComission;
                        break;
                    }
                case "ZONAOFI":
                    {
                        var oficinas = await helperDataServices.GetAsyncHelper<ZONAOFI>(assistQuery);
                        IEnumerable<ZonaOfiDto> cli = mapper.Map<IEnumerable<ZONAOFI>, IEnumerable<ZonaOfiDto>>(oficinas);
                        Offices = cli;
                        currentView = Offices;
                        break;
                    }
                case "CLAVEPTO":
                    {
                        var clavePto = await helperDataServices.GetAsyncHelper<CLAVEPTO>(assistQuery);
                        IEnumerable<ClavePtoDto> cli =
                            mapper.Map<IEnumerable<CLAVEPTO>, IEnumerable<ClavePtoDto>>(clavePto);
                        Clavepto = cli;
                        currentView = Clavepto;
                        break;
                    }
                case "ORIGEN":
                    {
                        var origen = await helperDataServices.GetAsyncHelper<ORIGEN>(assistQuery);
                        IEnumerable<OrigenDto> orig =
                            mapper.Map<IEnumerable<ORIGEN>, IEnumerable<OrigenDto>>(origen);
                        Origen = orig;
                        currentView = Origen;
                        break;
                    }
                case "IDIOMAS":
                    {
                        var language = await helperDataServices.GetAsyncHelper<IDIOMAS>(assistQuery);
                        IEnumerable<LanguageDto> orig =
                            mapper.Map<IEnumerable<IDIOMAS>, IEnumerable<LanguageDto>>(language);
                        Language = new ObservableCollection<LanguageDto>(orig);

                        currentView = Language;
                        break;
                    }

            }
            UpdateCollections(currentView, assistTableName, ref _leftObservableCollection);
            LeftValueCollection = _leftObservableCollection;
        }


        private void UpdateCollections(object obj, string tableName, ref ObservableCollection<UiDfSearch> search)
        {
            for (int i = 0; i < search.Count; ++i)
            {
                if (search[i].AssistTableName == tableName)
                {
                    search[i].SourceView = obj;
                }
            }
        }

       


        /// <summary>
        /// Delete a commission agent.
        /// </summary>
        /// <param name="inDataPayLoad"></param>
        /// <returns></returns>
        private async Task<DataPayLoad> HandleDeleteItem(DataPayLoad inDataPayLoad)
        {
            ICommissionAgent agent = await _commissionAgentDataServices.GetCommissionAgentDo(inDataPayLoad.PrimaryKeyValue);
            DataPayLoad payload = new DataPayLoad();
            if (agent.Valid)
            {
                bool returnValue = await _commissionAgentDataServices.DeleteCommissionAgent(agent);
                if (returnValue)
                {
                    payload.Subsystem = DataSubSystem.CommissionAgentSubystem;
                    payload.PrimaryKeyValue = inDataPayLoad.PrimaryKeyValue;
                    payload.PayloadType = DataPayLoad.Type.Delete;
                    EventManager.NotifyToolBar(payload);
                    _primaryKeyValue = "";
                    _commissionAgentDo = null;
                }
            }
            return payload;
        }
        /// <summary>
        ///  This returns a data table for binding the objects.
        /// </summary>
        public DataTable CommissionTable
        {
            get
            {
                return _commissionTable;
            }
            set { _commissionTable = value; }

        }


        /// <summary>
        ///  This return the magnifier button
        /// </summary>
        public string MagnifierButtonImage
        {
            get { return MasterModuleConstants.ImagePath; }
        }
        /// <summary>
        ///  Command to be associated to on change.
        /// </summary>
        public ICommand AssistCommand { set; get; }
        /// <summary>
        /// This item changed command.
        /// </summary>
        public ICommand ItemChangedCommand { set; get; }
        /// <summary>
        ///  Set or Get the vehicle is visible.
        /// </summary>
        public Visibility IsVisible
        {
            get { return _visibility; }
            set { _visibility = value; RaisePropertyChanged(); }
        }

        /// <summary>
        ///  Return the commissionist table.
        /// </summary>
        public string TableName
        {
            get { return TableNameComisio; }
        }
        /// <summary>
        ///  Assistant queries. Set of the queries related to the magnifier.
        /// </summary>
        public IDictionary<string, string> AssistQueryDictionary { get; set; }

        /// <summary>
        ///  This is a query dictionary of all queries.
        ///  At this point we can start the notification load.
        ///  In the view model we have everything that we need for loading stuff.
        /// </summary>
        public IDictionary<string, string> QueryDictionary
        {
            get
            {
                return _queries;
            }
            set
            {
                _queries = value;
                // here we have the loader.
                if (_queries.Keys.Count > 0)
                    StartAndNotify();
            }
        }

        /// <summary>
        ///  This is the email button image that it is needed.
        /// </summary>
        public string EmailButtonImage
        {
            get { return MasterModuleConstants.EmailImagePath; }
        }
        /// <summary>
        /// This notify the toobar for a tab change.
        /// </summary>
        public ICommand ActiveSubsystemCommand { set; get; }
        /// <summary>
        /// This is the start and notify.
        /// </summary>
        public override void StartAndNotify()
        {
            IsVisible = Visibility.Visible;
            _initializationTable =
                NotifyTaskCompletion.Create<ICommissionAgent>(LoadDataValue(_primaryKeyValue, _isInsertion), InitializationDataObjectOnPropertyChanged);
        }




        /// <summary>
        ///  Initialization on property changed.
        /// </summary>
        /// <param name="sender">This is the sender.</param>
        /// <param name="e">Parameters</param>
        private void InitializationDataObjectOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            IsVisible = Visibility.Visible;
            if (sender is ICommissionAgent)
            {
                ICommissionAgent agent = (ICommissionAgent)sender;
                DataObject = agent;
                Province = agent.ProvinceDto;
                Country = agent.CountryDto;
                for (int i = 0; i < _leftSideDualDfSearchBoxes.Count; ++i)
                {
                    _leftSideDualDfSearchBoxes[i].DataSource = agent;
                }
                _leftObservableCollection = _leftSideDualDfSearchBoxes;
            }

        }
        /// <summary>
        /// This program loads the data from the data values.
        /// </summary>
        /// <param name="primaryKeyValue">Primary Key.</param>
        /// <param name="isInsertion">Inserted key.</param>
        /// <returns></returns>
        private async Task<ICommissionAgent> LoadDataValue(string primaryKeyValue, bool isInsertion)
        {

            ICommissionAgent agent = null;
            if (isInsertion)
            {
                agent = _commissionAgentDataServices.GetNewCommissionAgentDo(_primaryKeyValue);
                if (agent != null)
                {
                    DataObject = agent;
                }
            }
            else
            {
                agent = await _commissionAgentDataServices.GetCommissionAgentDo(primaryKeyValue);
            }
            return agent;
        }

        /// <summary>
        /// Returns a data object.
        /// </summary>
        public object DataObject
        {
            set
            {
                _commissionAgentDo = (ICommissionAgent)value;

                RaisePropertyChanged();
            }
            // Data object to get
            get => _commissionAgentDo;
        }

        /// <summary>
        /// Delegation.
        /// </summary>
        public IEnumerable<BranchesDto> Delegation
        {
            get
            {
                return _branchesDto;
            }
            set
            {
                _branchesDto = value;
                RaisePropertyChanged();
            }
        }



        /// <summary>
        ///  This method answer to the lookup of the assist query
        /// </summary>
        /// <param name="assistTableName">Assit TableName</param>
        /// <param name="assistQuery">Assist query</param>
        /// <param name="primaryKey">Primary Key of the table</param>
        private async void AssistQueryRequestHandler(string assistTableName, string assistQuery, string primaryKey)
        {
            IHelperDataServices helperDataServices = DataServices.GetHelperDataServices();
            DataSet dataSetAssistant = await helperDataServices.GetAsyncHelper(assistQuery, assistTableName);
            if ((dataSetAssistant != null) && (dataSetAssistant.Tables.Count > 0))
            {
                //UpdateSource(dataSetAssistant, primaryKey, ref UpperPartObservableCollection);

            }
        }


        /// <summary>
        ///  OnChangedField. This method shall be changed.
        /// </summary>
        /// <param name="eventDictionary">Dictionary of events.</param>
        private void OnChangedField(IDictionary<string, object> eventDictionary)
        {
            
            DataPayLoad payLoad = new DataPayLoad();
            payLoad.Subsystem = DataSubSystem.CommissionAgentSubystem;
            payLoad.SubsystemName = MasterModuleConstants.CommissionAgentSystemName;
            payLoad.PayloadType = DataPayLoad.Type.Update;
            
            if (string.IsNullOrEmpty(payLoad.PrimaryKeyValue))
            {
                payLoad.PrimaryKeyValue = _primaryKeyValue;
                payLoad.PayloadType = DataPayLoad.Type.Update;
            }
            if (eventDictionary["DataObject"] == null)
            {
                MessageBox.Show("DataObject is null.");
            }
            ChangeFieldHandlerDo<ICommissionAgent> handlerDo = new ChangeFieldHandlerDo<ICommissionAgent>(EventManager,
                                                        ViewModelQueries,
                                                        DataSubSystem.CommissionAgentSubystem);

            if (CurrentOperationalState == DataPayLoad.Type.Insert)
            {
                handlerDo.OnInsert(payLoad, eventDictionary);

            }
            else
            {
                handlerDo.OnUpdate(payLoad, eventDictionary);
            }
        }
        /// SetTable is not used here and newItem shall be moved over
        /// <summary>
        ///  This method start a new item when the user clicks over the toolbar
        /// </summary>
        public override void NewItem()
        {
            // throw new NotImplementedException();
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
            payLoad.Subsystem = DataSubSystem.CommissionAgentSubystem;
        }

        protected override void SetDataObject(object result)
        {
        }

        /// <summary>
        ///  Give the name for each mailbox.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        protected override string GetRouteName(string name)
        {
            return "CommisionAgentModule" + name;
        }
        /// <summary>
        /// Data Primary Key.
        /// </summary>
        /// <param name="dataPayLoad">Payload.</param>
        public void IncomingPayload(DataPayLoad dataPayLoad)
        {
            // precondition not null
            if (dataPayLoad == null)
            {
                return;
            }
            DataPayLoad payload = dataPayLoad;
            // ignore double insert
            if ((dataPayLoad.PayloadType == DataPayLoad.Type.Insert) &&
                (PrimaryKeyValue == dataPayLoad.PrimaryKeyValue))
            {
                return;
            }
            if (payload != null)
            {
                if (PrimaryKeyValue.Length == 0)
                {
                    PrimaryKeyValue = payload.PrimaryKeyValue;
                    _mailBoxName = "CommissionAgents." + PrimaryKeyValue;
                    if (MailBoxHandler != null)
                    {
                        EventManager.RegisterMailBox(_mailBoxName, MailBoxHandler);
                    }
                }
                // here i can fix the primary key
                switch (payload.PayloadType)
                {
                    case DataPayLoad.Type.UpdateView:
                    case DataPayLoad.Type.Show:
                        {
                            Init(PrimaryKey, payload, false);
                            CurrentOperationalState = DataPayLoad.Type.Show;
                            break;
                        }
                    case DataPayLoad.Type.Insert:
                        {
                            CurrentOperationalState = DataPayLoad.Type.Insert;

                            if (string.IsNullOrEmpty(PrimaryKeyValue))
                            {

                                PrimaryKeyValue = _commissionAgentDataServices.GetNewId();
                            }
                            //PrimaryKeyValue = payload.PrimaryKeyValue;
                            Init(PrimaryKeyValue, payload, true);

                            break;
                        }
                    case DataPayLoad.Type.CultureChange:
                        {
                            _leftSideDualDfSearchBoxes = UpdateItemControl();
                            // here we handle all the stuff.
                            for (int i = 0; i < _leftSideDualDfSearchBoxes.Count; ++i)
                            {
                                _leftSideDualDfSearchBoxes[i].OnAssistQueryDo += AssistQueryRequestHandlerDo;
                                _leftSideDualDfSearchBoxes[i].OnChangedField += OnChangedField;
                                _leftSideDualDfSearchBoxes[i].DataSource = DataObject;
                            }
                            LeftValueCollection = _leftSideDualDfSearchBoxes;
                            break;
                        }
                    case DataPayLoad.Type.Delete:
                        {

                            if (PrimaryKey == payload.PrimaryKey)
                            {
                                DeleteEventCleanup(payload.PrimaryKeyValue, PrimaryKeyValue, DataSubSystem.CommissionAgentSubystem, MasterModuleConstants.CommissionAgentSystemName);
                                DeleteRegion(payload.PrimaryKeyValue);
                            }
                            break;
                        }
                }
            }
        }
        /// <summary>
        /// This adds a primary and a payload
        /// </summary>
        /// <param name="primaryKeyValue">PrimaryKey</param>
        /// <param name="payload">Data payload to be loaded</param>
        /// <param name="insertable">Is an insert operation</param>
        private void Init(string primaryKeyValue, DataPayLoad payload, bool insertable)
        {
            if (payload.HasDataObject)
            {
                _commissionAgentDo = (ICommissionAgent)payload.DataObject;

                IDictionary<string, object> lookup = new Dictionary<string, object>();
                lookup.Add("NEGOCIO", _commissionAgentDo.NegocioDto);
                lookup.Add("VENDEDOR", _commissionAgentDo.VendedorDto);
                lookup.Add("MERCADO", _commissionAgentDo.MercadoDto);
                lookup.Add("CANAL", _commissionAgentDo.CanalDto);
                lookup.Add("ORIGEN", _commissionAgentDo.OrigenDto);
                lookup.Add("ZONAOFI", _commissionAgentDo.ZonaOfiDto);
                lookup.Add("CLAVEPTO", _commissionAgentDo.ClavePptoDto);

                Province = _commissionAgentDo.ProvinceDto;
                Country = _commissionAgentDo.CountryDto;
                Products = _commissionAgentDo.ProductsDto;
                Language = _commissionAgentDo.LanguageDto;
                Delegation = _commissionAgentDo.DelegationDto;

                TipoComission = _commissionAgentDo.CommisionTypeDto;
                ClientOne = _commissionAgentDo.ClientsDto;
                CityDto = _commissionAgentDo.CityDtos;
                DataObject = _commissionAgentDo;


                // Here we send a message to upper part of the view.
                // it is a component. When it will receive it, it will set the view model and the TipoComiDto.
                EventManager.SendMessage(UpperBarViewModel.Name, payload);


                /* Items controls to the left */

                for (int i = 0; i < _leftSideDualDfSearchBoxes.Count; ++i)
                {
                    _leftSideDualDfSearchBoxes[i].DataSource = _commissionAgentDo;

                    if (lookup.ContainsKey(_leftSideDualDfSearchBoxes[i].AssistTableName))

                    {
                        var currentDto = lookup[_leftSideDualDfSearchBoxes[i].AssistTableName];
                        _leftSideDualDfSearchBoxes[i].SourceView = currentDto;

                    }

                }
                LeftValueCollection = _leftSideDualDfSearchBoxes;
                // This register the last active payload.
                ActiveSubSystem();
            }
        }
        /// <summary>
        /// Primary key payload.
        /// </summary>
        /// <param name="primaryKeyValue">This deletes an item.</param>
        private void DeleteItem(string primaryKeyValue)
        {
            string primaryKey = primaryKeyValue;
            if (primaryKey == PrimaryKey)
            {
                DataPayLoad dataPayload = new DataPayLoad();
                dataPayload.HasDataObject = true;
                dataPayload.PrimaryKeyValue = PrimaryKey;
                _deleteNotifyTaskCompletion = NotifyTaskCompletion.Create<DataPayLoad>(HandleDeleteItem(dataPayload), _deleteEventHandler);
                _primaryKeyValue = "";
            }
        }
        
        public override Task<bool> DeleteAsync(string primaryKey, DataPayLoad payLoad)
        {
            throw new NotImplementedException();
        }
        public string this[string columnName]
        {
            get { throw new NotImplementedException(); }
        }

        public string Error { get; }
        /// <summary>
        ///  FIXME: UniqueId.
        /// </summary>
        public new string UniqueId
        {
            get => _uniqueId; set => _uniqueId = value;
        }

        public IEnumerable<CityDto> CityDto
        {
            get { return _cityDto; }
            set
            {
                _cityDto = new ObservableCollection<CityDto>(value);
                RaisePropertyChanged();
            }
        }
    }
}
