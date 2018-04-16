using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
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
using Prism.Regions;
using DelegateCommand = Prism.Commands.DelegateCommand;
using KarveCommonInterfaces;
using System.Linq;
using KarveControls;
using Prism.Commands;

namespace MasterModule.ViewModels
{
    /// <summary>
    /// This view model is the commission agent view model
    /// </summary>
    /// CommissionAgentInfoViewModel
    internal sealed partial class CommissionAgentInfoViewModel : MasterInfoViewModuleBase, IDataErrorInfo, IEventObserver
    {

        private Visibility _visibility;
        private IDictionary<string, string> _queries;
        private string _primaryKeyValue = "";
        private bool _isInsertion = false;
        private ObservableCollection<UiDfSearch> _leftObservableCollection;
        private ObservableCollection<IUiObject> _rightObservableCollection;
        private ObservableCollection<IUiObject> _upperObservableCollection;
        private ICommissionAgentDataServices _commissionAgentDataServices;
        private INotifyTaskCompletion<ICommissionAgent> _initializationTable;
        private INotifyTaskCompletion<DataPayLoad> _deleteNotifyTaskCompletion;
        private INotifyTaskCompletion<bool> _changeTask;



        /// <summary>
        /// Auxiliares tables. Each aux table has associated a data transfer object. 
        /// A DTO is an object that carries data between processes in order to reduce the number of method calls.
        /// This allows us to customize the number of columns to be shown in the grid.
        /// </summary>
        private ICommissionAgent _commissionAgentDo;
        private IEnumerable<ProvinciaDto> _provincia = new List<ProvinciaDto>();
        private IEnumerable<CountryDto> _country = new List<CountryDto>();
        private IEnumerable<TIPOCOMI> _tipoComi = new List<TIPOCOMI>();
        private IEnumerable<ClientDto> _clientOne = new List<ClientDto>();
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

        #region Properties
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
        /// Province Delegation.
        /// </summary>
        public IEnumerable<ProvinciaDto> ProvinceBranches
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
        public IEnumerable<ClientDto> ClientOne
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
        /// Products of the view model
        /// </summary>
        public IEnumerable<CommissionTypeDto> BrokerTypeDto
        {
            get { return _brokerType; }
            set { _brokerType = value; RaisePropertyChanged(); }
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

     #endregion

        /// <summary>
        ///  Primary  key on branches
        /// </summary>
        private event SetPrimaryKey<BranchesDto> _onBranchesPrimaryKey;
        /// <summary>
        ///  Primary key on contacts.
        /// </summary>
        private event SetPrimaryKey<ContactsDto> _onContactsPrimaryKey;
        /// <summary>
        /// Primary key on visits.
        /// </summary>
        private event SetPrimaryKey<VisitsDto> _onVisitPrimaryKey;
 
        public ICommand PrintAssociate { set; get; }
        public ICommand DelegationChangedRowsCommand { set; get; }
        private IRegionManager _regionManager;

        private ObservableCollection<CityDto> _cityDto = new ObservableCollection<CityDto>();
        private string _mailBoxName;
        private IEnumerable<CommissionTypeDto> _brokerType;
        

        /// <summary>
        /// Commision agent info view model.
        /// </summary>
        /// <param name="configurationService"></param>
        /// <param name="eventManager"></param>
        /// <param name="services"></param>
        /// <param name="dialogService"></param>
        /// <param name="regionManager"></param>
        /// <param name="controller"></param>
        public CommissionAgentInfoViewModel(IConfigurationService configurationService,
                                            IEventManager eventManager,
                                            IDataServices services,
                                            IDialogService dialogService,
                                            IRegionManager regionManager,                                                        IInteractionRequestController controller
                                            ) : base(eventManager, 
                                                configurationService,
                                                services,
                                                dialogService,
                                               
                                                regionManager, 
                                                controller)
        {

            _queries = new Dictionary<string, string>();
            _visibility = Visibility.Collapsed;
            _commissionAgentDataServices = DataServices.GetCommissionAgentDataServices();
            _regionManager = regionManager;
            _onBranchesPrimaryKey += CommissionAgentInfoViewModel__onBranchesPrimaryKey;
            _onContactsPrimaryKey += CommissionAgentInfoViewModel__onContactsPrimaryKey;
            _onVisitPrimaryKey += CommissionAgentInfoViewModel__onVisitPrimaryKey;
            IsVisible = Visibility.Collapsed;
            AssistQueryDictionary = new Dictionary<string, string>();
            PrimaryKeyValue = string.Empty;
            ConfigurationService = configurationService;
            InitEvents();
            InitCommands();
            EventManager.RegisterObserverSubsystem(MasterModuleConstants.CommissionAgentSystemName, this);
            // update the assist.
            UpdateAssist(ref _leftSideDualDfSearchBoxes);
            // register itself in the broacast.
            EventManager.RegisterObserver(this);
        }


        /// <summary>
        ///  Set Contacts Charge.
        /// </summary>
        /// <param name="personal">Personal Position Dto.</param>
        /// <param name="contactsDto">Contacts Dto.</param>
        public override async Task SetContactsCharge(PersonalPositionDto personal, ContactsDto contactsDto)
        {
                var contacts = DataObject.ContactsDto;

            Dictionary<string, object> ev = new Dictionary<string, object>();
            ev["DataObject"] = DataObject;
            var items = new List<ContactsDto>();


            var contact =contacts.Where(x => x.ContactId == contactsDto.ContactId).FirstOrDefault();
            if (contact == null)
            {
                ev["Operation"] = ControlExt.GridOp.Insert;
                // insert case
                contact = contactsDto;
                contact.IsNew = true;
                contact.IsDirty = true;
            }
            else
            {
                contact = contactsDto;
                ev["Operation"] = ControlExt.GridOp.Update;
                contact.IsChanged = true;
                contact.IsDirty = true;
                contact.IsNew = false;
               
            }
            contact.ResponsabilitySource = personal;
            personal.ShowCommand = this.ContactChargeMagnifierCommand;
            contact.ResponsabilitySource = personal;
            // add the changed value to the branch.
            items.Add(contact);
            ev["ChangedValue"] = items;
           
           
            await GridChangedNotification<ContactsDto, CONTACTOS_COMI>(ev, _onContactsPrimaryKey, DataSubSystem.CommissionAgentSubystem).ConfigureAwait(false);
            RaisePropertyChanged("DataObject");
            RaisePropertyChanged("DataObject.ContactsDto");
        }

        /// <summary>
        ///  Set Branch province
        /// </summary>
        /// <param name="province">It allows the province branch.</param>
        /// <param name="branchesDto">It allows the branches dto.</param>
        internal override async Task SetBranchProvince(ProvinciaDto province, BranchesDto branchesDto)
        {
            var delegation = DataObject.BranchesDto;

            Dictionary<string, object> ev = new Dictionary<string, object>();
            ev["DataObject"] = DataObject;
            var items = new List<BranchesDto>();
            
           
            var branch = delegation.Where(x => x.BranchId == branchesDto.BranchId).FirstOrDefault();
            if (branch == null)
            {
                ev["Operation"] = ControlExt.GridOp.Insert;
                // insert case
                branch = branchesDto;
                branch.IsNew = true;
                branch.IsDirty = true;
            }
            else
            {
                ev["Operation"] = ControlExt.GridOp.Update;
                
                branch = branchesDto;
                branch.IsChanged = true;
                branch.IsDirty = true;
                branch.IsNew = false;
            }
            branch.ProvinceSource = province;
            province.ShowCommand = DelegationProvinceMagnifierCommand;
            branch.ProvinceId = province.Code;
            branch.ProvinceName = province.Name;
            branch.Province = province;
            branch.ProvinceSource = province;
            // add the changed value to the branch.
            items.Add(branch);
            ev["ChangedValue"] = items;
            RaisePropertyChanged("DataObject");
            // craft the event dictionary.
            await GridChangedNotification<BranchesDto, COMI_DELEGA>(ev, _onBranchesPrimaryKey, DataSubSystem.CommissionAgentSubystem).ConfigureAwait(false);   
        }
        private void OnPrintCommand(object obj)
        {
        }

        public override void DisposeEvents()
        {
            EventManager.DeleteObserver(this);
            EventManager.DeleteObserverSubSystem(MasterModuleConstants.ProviderSubsystemName, this);
            DeleteMailBox(_mailBoxName);
        }
        // TODO: remove duplications.
        private void CommissionAgentInfoViewModel__onContactsPrimaryKey(ref ContactsDto primaryKey)
        {
            primaryKey.CodeId = PrimaryKeyValue;
            primaryKey.ContactsKeyId = PrimaryKeyValue;
        }
        private void CommissionAgentInfoViewModel__onBranchesPrimaryKey(ref BranchesDto primaryKey)
        {
            primaryKey.CodeId = PrimaryKeyValue;
            primaryKey.BranchKeyId = PrimaryKeyValue;
        }
        private void CommissionAgentInfoViewModel__onVisitPrimaryKey(ref VisitsDto primaryKey)
        {
            primaryKey.CodeId = PrimaryKeyValue;
            primaryKey.KeyId = PrimaryKeyValue;
        }
        private void ItemChangedHandler(object obj)
        {
            _changeTask = NotifyTaskCompletion.Create(HandleChangedHandler(obj), changedTaskEvent);   
        }

        private void changedTaskEvent(object sender, PropertyChangedEventArgs e)
        {
            INotifyTaskCompletion<bool> taskCompletion = sender as INotifyTaskCompletion<bool>;
            if (taskCompletion.IsFaulted)
            {
                if (DialogService!=null)
                {
                    DialogService.ShowErrorMessage(taskCompletion.ErrorMessage);
                }
            }
        }


        /// <summary>
        /// This is enabled to the change the handler
        /// The command deliver some parmetes.
        /// </summary>
        /// <param name="obj">The object conveyed from the command.</param>
        private async Task<bool> HandleChangedHandler(object obj)
        {

            IDictionary<string, object> eventDictionary = (Dictionary<string, object>)obj;
            if (eventDictionary.ContainsKey(OperationConstKey))
            {
                var value = eventDictionary["DataSourcePath"] as string;
                if (value == "ContactsDtos")
                {
                   
                   await ContactsChangedCommandHandler(eventDictionary);
                   
                }
                else
                {
                   await DelegationChangedCommandHandler(eventDictionary);
                   
                }
            }
            else
            {
                OnChangedField(eventDictionary);
            }

            return true;
        }
        /// <summary>
        ///  Handle the delegation grid changes.
        /// </summary>
        /// <param name="obj">This send a delegation fo the changed command</param>
        private async Task DelegationChangedCommandHandler(object obj)
        {
           
            await GridChangedNotification<BranchesDto, COMI_DELEGA>(obj, _onBranchesPrimaryKey, DataSubSystem.CommissionAgentSubystem).ConfigureAwait(false);
        }
        /// <summary>
        ///  This change the contact grid
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private async Task ContactsChangedCommandHandler(object obj)
        {

            await GridChangedNotification<ContactsDto, CONTACTOS_COMI>(obj, _onContactsPrimaryKey, DataSubSystem.CommissionAgentSubystem);
        }
        /// <summary>
        /// This item is enabled to the magnifier command. When the user press the magnifier.
        /// </summary>
        /// <param name="param">Parameter of the command</param>
        /// 
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
                case "TIPOCOMI":
                    {
                        string query = string.Format("SELECT NUM_TICOMI, NOMBRE FROM TIPOCOMI");
                        BrokerTypeDto = await helperDataServices.GetMappedAsyncHelper<CommissionTypeDto, TIPOCOMI>(query);
                        break;

                    }
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
                case "PROVINCE_BRANCHES":
                    {
                        var provDtos = await helperDataServices.GetMappedAllAsyncHelper<ProvinciaDto, PROVINCIA>
                            ();
                            
                        currentView = provDtos;
                        break;
                    }
                case "POBLACIONES":
                    {
                        var prov = await helperDataServices.GetMappedAllAsyncHelper<CityDto, POBLACIONES>();
                        CityDto = prov;
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
                        IEnumerable<ClientDto> cli = mapper.Map<IEnumerable<CLIENTES1>, IEnumerable<ClientDto>>
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
        private void UpdateAssist(ref ObservableCollection<UiDfSearch> search)
        {
            for (int i = 0; i < search.Count; ++i)
            {
                search[i].AssistCommand = new Prism.Commands.DelegateCommand<object>(MagnifierCommandHandler);

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
        ///  This return the magnifier button
        /// </summary>
        public string MagnifierButtonImage
        {
            get { return MasterModuleConstants.ImagePath; }
        }


        /// <summary>
        ///  Set or Get the vehicle is visible.
        /// </summary>
        public Visibility IsVisible
        {
            get { return _visibility; }
            set { _visibility = value; RaisePropertyChanged(); }
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
                agent = await _commissionAgentDataServices.GetCommissionAgentDo(primaryKeyValue).ConfigureAwait(false);
               
            }
           
            return agent;
        }

        /// <summary>
        /// Returns a data object.
        /// </summary>
        public ICommissionAgent DataObject
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

            SetBasePayLoad(eventDictionary, ref payLoad);

            if (eventDictionary["DataObject"] == null)
            {
                MessageBox.Show("DataObject is null.");
            }
            else
            {
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
                // this will refresh the change through the visual tree.
                DataObject = handlerDo.DataObject;
            }

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
                                _leftSideDualDfSearchBoxes[i].ChangedItem = ItemChangedCommand;
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
        public ICommand DelegationMagnifierCommand { set; get; }

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
                Delegation = _commissionAgentDo.BranchesDto;
                TipoComission = _commissionAgentDo.CommisionTypeDto;
                ClientOne = _commissionAgentDo.ClientsDto;
                CityDto = _commissionAgentDo.CityDtos;
                // configure branches command.
                ConfigureBranchesCommand(_commissionAgentDo.BranchesDto);
                // configure contacts command.
                ConfigureContactsCommand(_commissionAgentDo.ContactsDto);
				// configure visits command.
				ConfigureVisitsCommand(_commissionAgentDo.VisitsDto);
                DataObject = _commissionAgentDo;
                VisitTypeDto = _commissionAgentDo.VisitTypeDto;
                RaisePropertyChanged("DataObject");



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
                _deleteNotifyTaskCompletion = NotifyTaskCompletion.Create<DataPayLoad>(HandleDeleteItem(dataPayload), DeleteEventHandler);
                _primaryKeyValue = "";
            }
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

        public DelegateCommand<object> MagnifierCommand { get; set; }
        


        private void InitEvents()
        {
            MailBoxHandler += MessageHandler;
            _onBranchesPrimaryKey += CommissionAgentInfoViewModel__onBranchesPrimaryKey;
            _onContactsPrimaryKey += CommissionAgentInfoViewModel__onContactsPrimaryKey;
        }
        private void InitCommands()
        {
            PrintAssociate = new DelegateCommand<object>(OnPrintCommand);
            ActiveSubsystemCommand = new DelegateCommand(ActiveSubSystem);
            AssistCommand = new DelegateCommand<object>(MagnifierCommandHandler);
            MagnifierCommand = new DelegateCommand<object>(MagnifierCommandHandler);
            ItemChangedCommand = new DelegateCommand<object>(ItemChangedHandler);  
        }

        internal override async Task SetClientData(ClientSummaryExtended p, VisitsDto visitsDto)
        {
        
            var ev = CreateGridEvent<ClientSummaryExtended, VisitsDto>(p, visitsDto,  DataObject.VisitsDto, this.ClientMagnifierCommand);
            visitsDto.ClientId = PrimaryKeyValue;
            var newList = new List<VisitsDto>();
            newList.Add(visitsDto);

            var mergedList = DataObject.VisitsDto.Union<VisitsDto>(newList);
            DataObject.VisitsDto = mergedList;
            ev["DataObject"] = DataObject;
            // craft the event dictionary.
            await GridChangedNotification<VisitsDto, VISITAS_COMI>(ev, _onVisitPrimaryKey, DataSubSystem.CommissionAgentSubystem).ConfigureAwait(false);
        }

        internal override async Task SetVisitContacts(ContactsDto p, VisitsDto visitsDto)
        {
          
            var ev = CreateGridEvent<ContactsDto, VisitsDto>(p, visitsDto, DataObject.VisitsDto, this.ContactMagnifierCommand);
            visitsDto.ClientId = PrimaryKeyValue;
            var newList = new List<VisitsDto>();
            newList.Add(visitsDto);
            var mergedList = DataObject.VisitsDto.Union<VisitsDto>(newList);
            DataObject.VisitsDto = mergedList;
            ev["DataObject"] = DataObject;
            // Notify the toolbar.
            await GridChangedNotification<VisitsDto, VISITAS_COMI>(ev, _onVisitPrimaryKey, DataSubSystem.CommissionAgentSubystem).ConfigureAwait(false);
          //  RaisePropertyChanged("DataObject");
          //  RaisePropertyChanged("DataObject.VisitDto");
        }

        internal override async Task SetVisitReseller(ResellerDto param, VisitsDto visitsDto)
        {
            var ev = CreateGridEvent<ResellerDto, VisitsDto>(param, visitsDto, DataObject.VisitsDto, this.ResellerMagnifierCommand);
            visitsDto.ClientId = PrimaryKeyValue;
            ev["DataObject"] = DataObject;
            var newList = new List<VisitsDto>();
            newList.Add(visitsDto);
            var mergedList = DataObject.VisitsDto.Union<VisitsDto>(newList);
            DataObject.VisitsDto = mergedList;

            // craft the event dictionary.
            await GridChangedNotification<VisitsDto, VENDEDOR>(ev, _onVisitPrimaryKey, DataSubSystem.CommissionAgentSubystem).ConfigureAwait(false);
            RaisePropertyChanged("DataObject");
            RaisePropertyChanged("DataObject.VisitDto");
        }

        
    }
}
