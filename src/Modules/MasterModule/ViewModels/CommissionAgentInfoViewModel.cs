﻿
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
using KarveDataServices.ViewObjects;
using MasterModule.Common;
using MasterModule.UIObjects.CommissionAgents;
using Prism.Regions;
using DelegateCommand = Prism.Commands.DelegateCommand;
using KarveCommonInterfaces;
using System.Linq;
using KarveCommon;
using KarveControls;
using Prism.Commands;
using System.Collections;

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
        private readonly ICommissionAgentDataServices _commissionAgentDataServices;
        private INotifyTaskCompletion<ICommissionAgent> _initializationTable;
        private INotifyTaskCompletion<DataPayLoad> _deleteNotifyTaskCompletion;
        private INotifyTaskCompletion<bool> _changeTask;



        /// <summary>
        /// helper tables. Each aux table has associated a data transfer object. 
        /// A DTO is an object that carries data between processes in order to reduce the number of method calls.
        /// This allows us to customize the number of columns to be shown in the grid.
        /// </summary>
        private ICommissionAgent _commissionAgentDo;
        private IEnumerable<ProvinceViewObject> _provincia = new List<ProvinceViewObject>();
        private IEnumerable<CountryViewObject> _country = new List<CountryViewObject>();
        private IEnumerable<TIPOCOMI> _tipoComi = new List<TIPOCOMI>();
        private IEnumerable<ClientViewObject> _clientOne = new List<ClientViewObject>();
        private IEnumerable<ProductsViewObject> _products = new List<ProductsViewObject>();
        private IEnumerable<BusinessViewObject> _negocios = new List<BusinessViewObject>();
        private IEnumerable<MarketViewObject> _mercados = new List<MarketViewObject>();
        private IEnumerable<ChannelViewObject> _canal = new List<ChannelViewObject>();
        private IEnumerable<ResellerViewObject> _vendedor = new List<ResellerViewObject>();
        private IEnumerable<CommissionTypeViewObject> _tipocomisions = new List<CommissionTypeViewObject>();
        private IEnumerable<ZonaOfiViewObject> _officies = new List<ZonaOfiViewObject>();
        private IEnumerable<BudgetKeyViewObject> _clavePto = new List<BudgetKeyViewObject>();
        private IEnumerable<LanguageViewObject> _language = new List<LanguageViewObject>();
        private IEnumerable<BranchesViewObject> _branchesDto = new ObservableCollection<BranchesViewObject>();
        private string _uniqueId = "";

        #region Properties
        /// <summary>
        ///  Data Transfer Objects for mercados
        /// </summary>
        public IEnumerable<MarketViewObject> Mercado
        {
            get { return _mercados; }
            set { _mercados = value; RaisePropertyChanged(); }
        }
        /// <summary>
        ///  Data Transfer objects for negocio
        /// </summary>
        public IEnumerable<BusinessViewObject> Negocio
        {
            get { return _negocios; }
            set { _negocios = value; RaisePropertyChanged(); }
        }
        /// <summary>
        ///  Data Trasnfer object for canal
        /// </summary>
        public IEnumerable<ChannelViewObject> Canal
        {
            get { return _canal; }
            set { _canal = value; RaisePropertyChanged(); }
        }
        public IEnumerable<ResellerViewObject> Vendedor
        {
            get { return _vendedor; }
            set { _vendedor = value; RaisePropertyChanged(); }
        }
        public IEnumerable<CommissionTypeViewObject> TipoComission
        {
            get { return _tipocomisions; }
            set { _tipocomisions = value; RaisePropertyChanged(); }
        }
        /// <summary>
        /// ClavePto.
        /// </summary>
        public IEnumerable<BudgetKeyViewObject> Clavepto
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
        public IEnumerable<OrigenViewObject> Origen { get; set; }

        /// <summary>
        /// Province
        /// </summary>
        public IEnumerable<ProvinceViewObject> Province
        {
            get { return _provincia; }
            set { _provincia = value; RaisePropertyChanged(); }
        }
        /// <summary>
        /// Province Delegation.
        /// </summary>
        public IEnumerable<ProvinceViewObject> ProvinceBranches
        {
            get { return _provincia; }
            set { _provincia = value; RaisePropertyChanged(); }
        }
        /// <summary>
        /// Country
        /// </summary>
        public IEnumerable<CountryViewObject> Country
        {
            get { return _country; }
            set { _country = value; RaisePropertyChanged(); }

        }
        /// <summary>
        /// Language viewObject.
        /// </summary>
        public IEnumerable<LanguageViewObject> Language
        {
            get { return _language; }
            set { _language = value; RaisePropertyChanged(); }
        }
        /// <summary>
        /// Offices.
        /// </summary>
        public IEnumerable<ZonaOfiViewObject> Offices
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
        public IEnumerable<ClientViewObject> ClientOne
        {
            get { return _clientOne; }
            set { _clientOne = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// Products of the view model
        /// </summary>

        public IEnumerable<ProductsViewObject> Products
        {
            get { return _products; }
            set { _products = value; RaisePropertyChanged(); }
        }
        /// <summary>
        /// Products of the view model
        /// </summary>
        public IEnumerable<CommissionTypeViewObject> BrokerTypeDto
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
        private event SetPrimaryKey<BranchesViewObject> _onBranchesPrimaryKey;
        /// <summary>
        ///  Primary key on contacts.
        /// </summary>
        private event SetPrimaryKey<ContactsViewObject> _onContactsPrimaryKey;
        /// <summary>
        /// Primary key on visits.
        /// </summary>
        private event SetPrimaryKey<VisitsViewObject> _onVisitPrimaryKey;

        public ICommand PrintAssociate { set; get; }
        public ICommand DelegationChangedRowsCommand { set; get; }
        private IRegionManager _regionManager;

        private ObservableCollection<CityViewObject> _cityDto = new ObservableCollection<CityViewObject>();
        private string _mailBoxName;
        private IEnumerable<CommissionTypeViewObject> _brokerType;
        private IMapper _mapper;
        private int _countTime;


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
                                            IRegionManager regionManager, IInteractionRequestController controller
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
            ViewModelUri = new Uri("karve://broker/viewmodel?id=" + Guid.ToString());
            _mapper = MapperField.GetMapper();
            EventManager.RegisterObserverSubsystem(MasterModuleConstants.CommissionAgentSystemName, this);
            // update the assist.
            UpdateAssist(ref _leftSideDualDfSearchBoxes);
            UpdateChangeCommand(ref _leftSideDualDfSearchBoxes);
            // register itself in the broacast.
            EventManager.RegisterObserver(this);
            _countTime = 0;
        }




        /// <summary>
        ///  Set Contacts Charge.
        /// </summary>
        /// <param name="personal">Personal Position Dto.</param>
        /// <param name="contactsViewObject">Contacts Dto.</param>
        public override async Task SetContactsCharge(PersonalPositionViewObject personal, ContactsViewObject contactsViewObject)
        {
            var contacts = DataObject.ContactsDto;
            Dictionary<string, object> ev = new Dictionary<string, object> { ["DataObject"] = DataObject };
            var items = new List<ContactsViewObject>();


            var contact = contacts.FirstOrDefault(x => x.ContactId == contactsViewObject.ContactId);
            if (contact == null)
            {
                ev["Operation"] = ControlExt.GridOp.Insert;
                // insert case
                contact = contactsViewObject;
                contact.IsNew = true;
                contact.IsDirty = true;
            }
            else
            {
                contact = contactsViewObject;
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


            await GridChangedNotification<ContactsViewObject, CONTACTOS_COMI>(ev, _onContactsPrimaryKey, DataSubSystem.CommissionAgentSubystem).ConfigureAwait(false);
            RaisePropertyChanged("DataObject");
            RaisePropertyChanged("DataObject.ContactsViewObject");
        }

        /// <summary>
        ///  Set Branch province
        /// </summary>
        /// <param name="province">It allows the province branch.</param>
        /// <param name="branchesViewObject">It allows the branches viewObject.</param>
        internal override async Task SetBranchProvince(ProvinceViewObject province, BranchesViewObject branchesViewObject)
        {
            // set the base event dictionary
            IDictionary<string, object> ev = SetBranchProvince(province, branchesViewObject, DataObject, DataObject.BranchesDto);
            // send the opportune event where it is needed.
            await GridChangedNotification<BranchesViewObject, COMI_DELEGA>(ev,
                _onBranchesPrimaryKey, DataSubSystem.CommissionAgentSubystem).ConfigureAwait(false);
        }
        private void OnPrintCommand(object obj)
        {
        }

        public override void DisposeEvents()
        {
            base.DisposeEvents();
            EventManager.DeleteObserver(this);
            EventManager.DeleteObserverSubSystem(MasterModuleConstants.ProviderSubsystemName, this);
            DeleteMailBox(_mailBoxName);
            var payload = new DataPayLoad
            {
                ObjectPath = ViewModelUri,
                PayloadType = DataPayLoad.Type.Dispose
            };
            EventManager.NotifyToolBar(payload);
        }
        // TODO: remove duplications.
        private void CommissionAgentInfoViewModel__onContactsPrimaryKey(ref ContactsViewObject primaryKey)
        {
            primaryKey.Code = PrimaryKeyValue;
            primaryKey.ContactsKeyId = PrimaryKeyValue;
        }
        private void CommissionAgentInfoViewModel__onBranchesPrimaryKey(ref BranchesViewObject primaryKey)
        {
            primaryKey.Code = PrimaryKeyValue;
            primaryKey.BranchKeyId = PrimaryKeyValue;
        }
        private void CommissionAgentInfoViewModel__onVisitPrimaryKey(ref VisitsViewObject primaryKey)
        {
            primaryKey.Code = PrimaryKeyValue;
            primaryKey.KeyId = PrimaryKeyValue;
        }
        private void ItemChangedHandler(object obj)
        {
            _changeTask = NotifyTaskCompletion.Create(HandleChangedHandler(obj), ChangedTaskEvent);
        }

        private void ChangedTaskEvent(object sender, PropertyChangedEventArgs e)
        {
            if (sender is INotifyTaskCompletion<bool> taskCompletion)
            {
                if (taskCompletion.IsFaulted)
                {
                    if (!Faulted)
                    {
                        DialogService?.ShowErrorMessage(taskCompletion.ErrorMessage);
                        Faulted = true;
                    }
                }
                if (taskCompletion.IsSuccessfullyCompleted)
                {
                    Faulted = false;
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
                switch (value)
                {
                    case "Contacts":
                        {
                            await ContactsChangedCommandHandler(eventDictionary).ConfigureAwait(false);
                            break;
                        }
                    case "Visits":
                        {
                            await VisitsChangedCommandHandler(eventDictionary).ConfigureAwait(false);
                            break;
                        }
                    case "Delegation":
                        {
                            await DelegationChangedCommandHandler(eventDictionary).ConfigureAwait(false);
                            break;
                        }

                } }
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
            await GridChangedNotification<BranchesViewObject, COMI_DELEGA>(obj, _onBranchesPrimaryKey, DataSubSystem.CommissionAgentSubystem).ConfigureAwait(false);
        }
        /// <summary>
        ///  This change the contact grid
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private async Task ContactsChangedCommandHandler(object obj)
        {
            await GridChangedNotification<ContactsViewObject, CONTACTOS_COMI>(obj, _onContactsPrimaryKey, DataSubSystem.CommissionAgentSubystem);
        }
        private async Task VisitsChangedCommandHandler(object obj)
        {
            await GridChangedNotification<VisitsViewObject, VISITAS_COMI>(obj, _onVisitPrimaryKey, DataSubSystem.CommissionAgentSubystem);
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
            try
            {

                await AssistQueryRequestHandlerDo(assistTableName, assistQuery).ConfigureAwait(false);
            } catch (Exception ex)
            {
                DialogService?.ShowErrorMessage("Input no permitido: "+ ex.Message);
                Faulted = true;
            }
        }

        // move to the master view model or to a data layer
        private async Task AssistQueryRequestHandlerDo(string assistTableName, string assistQuery)
        {
            IHelperDataServices helperDataServices = DataServices.GetHelperDataServices();
            object currentView = null;
            IMapper mapper = MapperField.GetMapper();
            var assistDataService = DataServices.GetAssistDataServices();
            var resultData = await assistDataService.Mapper.ExecuteAssistGeneric(assistTableName.ToUpper(), assistQuery);

            switch (assistTableName)
            {
                case "TIPOCOMI":
                    {

                        BrokerTypeDto = (IEnumerable<CommissionTypeViewObject>)(resultData);
                        break;

                    }
                case "PAIS":
                    {
                        IEnumerable<CountryViewObject> countryDtos = (IEnumerable<CountryViewObject>)(resultData);
                        Country = countryDtos;
                        currentView = countryDtos;
                        break;
                    }
                case "PROVINCIA":
                    {
                       
                        Province = (IEnumerable<ProvinceViewObject>) resultData;
                        break;
                    }
                case "PROVINCE_BRANCHES":
                    {
                        var provDtos = (IEnumerable<ProvinceViewObject>)resultData;
    
                        currentView = provDtos;
                        break;
                    }
                case "POBLACIONES":
                    {
                        var prov = (IEnumerable<CityViewObject>)resultData;
                        CityDto = prov;
                        currentView = CityDto;
                        break;
                    }
                case "PRODUCTS":
                    {
                        IEnumerable<ProductsViewObject> productDto = (IEnumerable<ProductsViewObject>)(resultData);
                        Products = productDto;
                        currentView = productDto;
                        break;
                    }

                case "VENDEDOR":
                    {

                        IEnumerable<ResellerViewObject> vendedorDto = (IEnumerable<ResellerViewObject>)(resultData);
                        Vendedor = vendedorDto;
                        currentView = Vendedor;
                        break;
                    }
                case "MARKET_ASSIST":
                    {
                        IEnumerable<MarketViewObject> mercadoDtos = (IEnumerable<MarketViewObject>)(resultData);
                        Mercado = mercadoDtos;
                        currentView = Mercado;
                        break;
                    }
                case "BUSINESS_ASSIST":
                    {
                        
                        IEnumerable<BusinessViewObject> negocios = (IEnumerable<BusinessViewObject>)(resultData);
                        Negocio = negocios;
                        currentView = Negocio;
                        break;

                    }
                case "CLIENT_ASSIST_COMI":
                    {

                        ClientOne = (IEnumerable<ClientViewObject>)(resultData);
                        currentView = ClientOne;

                        break;
                    }
                case "CHANNEL_TYPE":
                    {
                        IEnumerable<ChannelViewObject> cli = (IEnumerable<ChannelViewObject>)(resultData);
                        Canal = cli;
                        currentView = Canal;
                        break;
                    }
                case "TIPOCOMISION":
                    {
                        IEnumerable<CommissionTypeViewObject> cli = (IEnumerable<CommissionTypeViewObject>)(resultData);
                        
                        TipoComission = cli;
                        currentView = TipoComission;
                        break;
                    }
                case "OFFICE_ZONE_ASSIST":
                    {
                        IEnumerable<ZonaOfiViewObject> cli = (IEnumerable<ZonaOfiViewObject>)(resultData);
                        Offices = cli;
                        currentView = Offices;
                        break;
                    }
                case "CLIENT_BUDGET":
                    {
                        IEnumerable<BudgetKeyViewObject> cli = (IEnumerable<BudgetKeyViewObject>)(resultData);
                        Clavepto = cli;
                        currentView = Clavepto;
                        break;
                    }
                case "ORIGIN_ASSIST":
                    {
                        IEnumerable<OrigenViewObject> cli = (IEnumerable<OrigenViewObject>)(resultData);
                        
                        Origen = cli;
                        currentView = Origen;
                        break;
                    }
                case "IDIOMAS":
                    {
                        IEnumerable<LanguageViewObject> cli = (IEnumerable<LanguageViewObject>)(resultData);
                        Language = cli;
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
        private void UpdateChangeCommand(ref ObservableCollection<UiDfSearch> search)
        {
            for (int i = 0; i < search.Count; ++i)
            {
                search[i].ChangedItem = new Prism.Commands.DelegateCommand<object>(ItemChangedHandler);

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
                bool returnValue = await _commissionAgentDataServices.DeleteAsync(agent);
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
        public  void StartAndNotify()
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
                agent = await _commissionAgentDataServices.GetDoAsync(_primaryKeyValue);
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
        public IEnumerable<BranchesViewObject> Delegation
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
            payLoad.ObjectPath = ViewModelUri;
            payLoad.HasDataObject = true;

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
                var handlerDo = new ChangeFieldHandlerDo<ICommissionAgent>(EventManager,
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
               // DataObject = handlerDo.DataObject;
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
        public override void IncomingPayload(DataPayLoad dataPayLoad)
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

                        PrimaryKeyValue = _commissionAgentDataServices.NewId();
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

        public new ICommand ItemChangedCommand { set; get; }
        public ICommand DelegationMagnifierCommand { set; get; }

        /// <summary>
        /// This adds a primary and a payload
        /// </summary>
        /// <param name="primaryKeyValue">PrimaryKey</param>
        /// <param name="payload">Data payload to be loaded</param>
        /// <param name="insertable">Is an insert operation</param>
        private void Init(string primaryKeyValue, DataPayLoad payload, bool insertable)
        {
            _countTime++;

            if (payload.HasDataObject)
            {
                _commissionAgentDo = (ICommissionAgent)payload.DataObject;
                // review.
                IDictionary<string, object> lookup = new Dictionary<string, object>();
                lookup.Add("BUSINESS_ASSIST", _commissionAgentDo.NegocioDto);
                lookup.Add("VENDEDOR", _commissionAgentDo.VendedorDto);
                lookup.Add("MARKET_ASSIST", _commissionAgentDo.MercadoDto);
                lookup.Add("CHANNEL_TYPE", _commissionAgentDo.CanalDto);
                lookup.Add("ORIGIN_ASSIST", _commissionAgentDo.OrigenDto);
                lookup.Add("OFFICE_ZONE_ASSIST", _commissionAgentDo.ZonaOfiDto);
                lookup.Add("CLIENT_BUDGET", _commissionAgentDo.ClavePptoDto);

                Province = _commissionAgentDo.ProvinceDto;
                Country = _commissionAgentDo.CountryDto;
                Products = _commissionAgentDo.ProductsDto;
                Language = _commissionAgentDo.LanguageDto;  
                Delegation = _commissionAgentDo.BranchesDto;
                BrokerTypeDto = _commissionAgentDo.CommisionTypeDto;

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
            var primaryKey = primaryKeyValue;
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

        public IEnumerable<CityViewObject> CityDto
        {
            get { return _cityDto; }
            set
            {
                _cityDto = new ObservableCollection<CityViewObject>(value);
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

        internal override async Task SetClientData(ClientSummaryExtended p, VisitsViewObject visitsViewObject)
        {
        
            var ev = CreateGridEvent<ClientSummaryExtended, VisitsViewObject>(p, visitsViewObject,  DataObject.VisitsDto, this.ClientMagnifierCommand);
            visitsViewObject.ClientId = PrimaryKeyValue;
            var newList = new List<VisitsViewObject>();
            newList.Add(visitsViewObject);

            var mergedList = DataObject.VisitsDto.Union<VisitsViewObject>(newList);
            DataObject.VisitsDto = mergedList;
            ev["DataObject"] = DataObject;

            await Task.Delay(1);
            // craft the event dictionary.
            //  await GridChangedNotification<VisitsViewObject, VISITAS_COMI>(ev, _onVisitPrimaryKey, DataSubSystem.CommissionAgentSubystem).ConfigureAwait(false);
        }

        internal override async Task SetVisitContacts(ContactsViewObject p, VisitsViewObject visitsViewObject)
        {
          
            var ev = CreateGridEvent<ContactsViewObject, VisitsViewObject>(p, visitsViewObject, DataObject.VisitsDto, this.ContactMagnifierCommand);
            visitsViewObject.ClientId = PrimaryKeyValue;
            var newList = new List<VisitsViewObject>();
            newList.Add(visitsViewObject);
            var mergedList = DataObject.VisitsDto.Union<VisitsViewObject>(newList);
            DataObject.VisitsDto = mergedList;
            ev["DataObject"] = DataObject;
            // Notify the toolbar.
//            await GridChangedNotification<VisitsViewObject, VISITAS_COMI>(ev, _onVisitPrimaryKey, DataSubSystem.CommissionAgentSubystem).ConfigureAwait(false);
         
        }

        internal override async Task SetVisitReseller(ResellerViewObject param, VisitsViewObject visitsViewObject)
        {
            var ev = CreateGridEvent<ResellerViewObject, VisitsViewObject>(param, visitsViewObject, DataObject.VisitsDto, this.ResellerMagnifierCommand);
            visitsViewObject.ClientId = PrimaryKeyValue;
            ev["DataObject"] = DataObject;
            var newList = new List<VisitsViewObject>();
            newList.Add(visitsViewObject);
            var mergedList = DataObject.VisitsDto.Union<VisitsViewObject>(newList);
            DataObject.VisitsDto = mergedList;

            // craft the event dictionary.
  //          await GridChangedNotification<VisitsViewObject, VENDEDOR>(ev, _onVisitPrimaryKey, DataSubSystem.CommissionAgentSubystem).ConfigureAwait(false);
            RaisePropertyChanged("DataObject");
            RaisePropertyChanged("DataObject.VisitDto");
        }

        public override void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
