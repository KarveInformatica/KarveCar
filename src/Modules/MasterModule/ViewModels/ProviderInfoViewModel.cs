using KarveCommon.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using AutoMapper;
using DataAccessLayer.Assist;
using DataAccessLayer.DataObjects;
using DataAccessLayer.Logic;
using KarveCommon.Generic;
using MasterModule.Common;
using NLog;
using Prism.Commands;
using Prism.Regions;
using System;
using System.Linq;
using KarveCommon;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;
using KarveDataServices;
using KarveDataServices.Assist;
using KarveCommonInterfaces;
using KarveControls.Generic;

namespace MasterModule.ViewModels
{
    /// <summary>
    ///  ProviderInfoViewModel. 
    /// </summary>
   internal sealed class ProviderInfoViewModel : MasterInfoViewModuleBase, IEventObserver
    {
     
      
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private INotifyTaskCompletion<ISupplierData> _initializationTable;
        // FIXME: move to data layer.
        private string _accountAssistQuery = "SELECT CODIGO, DESCRIP, CC FROM CU1;";
        private bool _delegationReadonly;
        private ISupplierData _supplierData;
        private ISupplierData _dataObject;
        private Visibility _visibility;
        private IEnumerable<ProvinciaDto> _provinciaDtos = new ObservableCollection<ProvinciaDto>();
        private IEnumerable<OfficeDtos> _officeDtos = new ObservableCollection<OfficeDtos>();
        private IEnumerable<CountryDto> _countryDtos = new ObservableCollection<CountryDto>();
        private IEnumerable<CompanyDto> _companyDto;
        private static long _uniqueCounter = 0;
        private IMapper mapper;
       

        private const string ProviderInfoVm = "ProviderInfoViewModel";
       
        private IEnumerable<PaymentFormDto> _paymentDtos;
        private IEnumerable<MonthsDto> _monthsDto;
        private IEnumerable<BanksDto> _banksDto;
        private IEnumerable<LanguageDto> _languagesDto;
        private IEnumerable<AccountDto> _account1Dto;
        private IEnumerable<AccountDto> _account2Dto;
        private IEnumerable<CurrencyDto> _currencyDtos;
        private IEnumerable<MonthsDto> _monthsDto2;
        private IEnumerable<AccountDto> _account3Dto;
        private IEnumerable<AccountDto> _account4Dto;
        private IEnumerable<AccountDto> _account5Dto;
        private IEnumerable<AccountDto> _account6Dto;
        private IEnumerable<AccountDto> _account7Dto;
        private IEnumerable<AccountDto> _account8Dto;
        private ObservableCollection<CountryDto> _countryDto1 = new ObservableCollection<CountryDto>();
        private ObservableCollection<CountryDto> _countryDto2 = new ObservableCollection<CountryDto>();
        private ObservableCollection<CityDto> _cityDto1 = new ObservableCollection<CityDto>();
        private ObservableCollection<CityDto> _cityDto2 = new ObservableCollection<CityDto>();
        // this is ok.
        private ObservableCollection<ProvinciaDto> _provinciaDtos2 = new ObservableCollection<ProvinciaDto>();
        private ObservableCollection<ProvinciaDto> _provinciaDto2 = new ObservableCollection<ProvinciaDto>();
        private ObservableCollection<ProvinciaDto> _provinciaDto3 = new ObservableCollection<ProvinciaDto>();
        private ObservableCollection<ProvinciaDto> _provinciaDto1 = new ObservableCollection<ProvinciaDto>();
        private ObservableCollection<CountryDto> _countryDto3 = new ObservableCollection<CountryDto>();
        private ObservableCollection<CountryDto> _countryDto4 = new ObservableCollection<CountryDto>();
        private ObservableCollection<CityDto> _cityDto3;
        private ObservableCollection<CityDto> _cityDto11;
        private ICommand _contactChangedCommand;
        private string _mailBoxName = string.Empty;
        private ObservableCollection<ViaDto> _viaDtos;
        private ObservableCollection<PaymentFormDto> _formaDtos;
        private IEnumerable<PriceConditionDto> _priceConditionDto;
        private IEnumerable<DeliveringFormDto> _deliveryFromDto;
        private IEnumerable<DeliveringWayDto> _deliveryWayDto;
        private IEnumerable<SupplierTypeDto> _supplierTypeDto = new ObservableCollection<SupplierTypeDto>();

        private event SetPrimaryKey<BranchesDto> _onBranchesPrimaryKey;
        private event SetPrimaryKey<ContactsDto> _onContactsPrimaryKey;
     //   private IncrementalItemsSource = new IncrementalList<OrderInfo>(LoadMoreItems) { MaxItemCount = 1000 };

    public ObservableCollection<CountryDto> CountryDto
        {
            set { _countryDto1 = value; RaisePropertyChanged(); }
            get { return _countryDto1; }
        }
        public ObservableCollection<CountryDto> CountryDto1
        {
            set { _countryDto2 = value; RaisePropertyChanged(); }
            get { return _countryDto2; }
        }

        public ObservableCollection<CountryDto> CountryDto2
        {
            set
            {
                _countryDto3 = value;
                RaisePropertyChanged();
            }
            get { return _countryDto3; }

        }

        public ObservableCollection<CityDto> CityDto
        {
            set { _cityDto1 = value; RaisePropertyChanged(); }
            get { return _cityDto1; }
        }
        public ObservableCollection<CityDto> CityDto1
        {
            set { _cityDto11 = value; RaisePropertyChanged(); }
            get { return _cityDto11; }
        }
        public ObservableCollection<CityDto> CityDto2
        {
            set { _cityDto2 = value; RaisePropertyChanged(); }
            get { return _cityDto2; }
        }
        public ObservableCollection<CityDto> CityDto3
        {
            set { _cityDto3 = value; RaisePropertyChanged(); }
            get { return _cityDto3; }
        }
        public ObservableCollection<ProvinciaDto> ProvinceDto2
        {
            set { _provinciaDtos2 = value; RaisePropertyChanged(); }
            get { return _provinciaDtos2; }
        }
        public ObservableCollection<ProvinciaDto> ProvinceDto3
        {
            set { _provinciaDto3 = value; RaisePropertyChanged(); }
            get { return _provinciaDto3; }
        }

        public ObservableCollection<CountryDto> CountryDto3
        {

            set { _countryDto3 = value; RaisePropertyChanged(); }
            get { return _countryDto3; }

        }

        public ObservableCollection<ViaDto> ViaDtos
        {
            set { _viaDtos = value; RaisePropertyChanged(); }
            get { return _viaDtos; }
        }

        public ObservableCollection<PaymentFormDto> FormasDtos
        {
            set { _formaDtos = value; RaisePropertyChanged(); }
            get { return _formaDtos; }
        }

        public ICommand DelegationGridChangedCommand { set; get; }
        
        /// <summary>
        /// ProviderInfoViewModel.
        /// </summary>
        /// <param name="eventManager"></param>
        /// <param name="configurationService"></param>
        /// <param name="dataServices"></param>
        /// <param name="dialogService"></param>
        /// <param name="manager"></param>
        /// <param name="controller"></param>
        public ProviderInfoViewModel(IEventManager eventManager, IConfigurationService configurationService,
             IDataServices dataServices, IDialogService dialogService,
             IRegionManager manager, IInteractionRequestController controller) : base(eventManager, configurationService, dataServices, dialogService, manager, controller)
        {
            ConfigurationService = configurationService;
            MailBoxHandler += MessageHandler;   
            AccountAssistQuery = _accountAssistQuery;
            EventManager.RegisterObserverSubsystem(MasterModuleConstants.ProviderSubsystemName, this);
            // TODO: all the mapping shall be isolated.
            mapper = MapperField.GetMapper();
            _onBranchesPrimaryKey += ProviderInfoViewModel__onBranchesPrimaryKey;
            _onContactsPrimaryKey += ProviderInfoViewModel__onContactsPrimaryKey;
            _uniqueCounter++;
            ViewModelUri = new Uri("karve://supplier/viewmodel?id=" + Guid.ToString());
            InitVmCommands();
        }

        /// <summary>
        ///  This is useful for initialize the view model commands.
        /// </summary>
        private void InitVmCommands()
        {
            ClickSearchWebAddressCommand = new Prism.Commands.DelegateCommand<object>(LaunchWebBrowser);
            ItemChangedCommand = new Prism.Commands.DelegateCommand<object>(OnChangedField);
            AssistCommand = new Prism.Commands.DelegateCommand<object>(OnAssistCommand);
            ContactsChangedCommand= new DelegateCommand<object>(OnContactsChangedCommand);
        }
        public ICommand ContactsChangedCommand {
            get { return _contactChangedCommand;  }
            set { _contactChangedCommand = value; RaisePropertyChanged(); }
        }
        private void ProviderInfoViewModel__onContactsPrimaryKey(ref ContactsDto primaryKey)
        {
            primaryKey.ContactsKeyId = PrimaryKeyValue;
        }

        private void ProviderInfoViewModel__onBranchesPrimaryKey(ref BranchesDto primaryKey)
        {
            primaryKey.BranchKeyId = PrimaryKeyValue;
        }
        
        /// <summary>
        ///  Handle the delegation grid changes.
        /// </summary>
        /// <param name="obj">This send a delegation fo the changed command</param>
        private async void DelegationChangedCommandHandler(object obj)
        {

            await GridChangedNotification<BranchesDto, ProDelega>(obj, _onBranchesPrimaryKey, DataSubSystem.SupplierSubsystem).ConfigureAwait(false);

        }

        private async void ContactsChangedCommandHandler(object obj)
        {
            await GridChangedNotification<ContactsDto, ProContactos>(obj, _onContactsPrimaryKey, DataSubSystem.SupplierSubsystem).ConfigureAwait(false);
        }
        // This register the different assist types.

        private void OnAssistCommand(object param)
        {
            IDictionary<string, string> values = (Dictionary<string, string>)param;
            string assistTableName = values.ContainsKey("AssistTable") ? values["AssistTable"] as string : string.Empty;
            string assistQuery = values.ContainsKey("AssistQuery") ? values["AssistQuery"] as string : string.Empty;
            AssistQueryRequestHandler(assistTableName, assistQuery);
        }

        private void OnContactsChangedCommand(object obj)
        {
            IDictionary<string, object> eventDictionary = (IDictionary<string, object>)obj;
            ContactsChangedCommandHandler(eventDictionary);
        }
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
        ///  Data object.
        /// </summary>
        public ISupplierData DataObject
        {
            set
            {
                _dataObject = value;
                RaisePropertyChanged();
            }
            get { return _dataObject; }
        }
        
        /// <summary>
        ///  This shall be moved to another layer.
        /// </summary>
        public string AccountAssistQuery
        {
            set { _accountAssistQuery = value; RaisePropertyChanged(); }
            get { return _accountAssistQuery; }
        }


        public Visibility IsVisible
        {
            set
            {
                _visibility = value; RaisePropertyChanged();
            }
            get { return _visibility; }
        }

        public string DelegationDataBaseTableName
        {
            get
            {
                return ProviderConstants.DelegationDataBaseTable;
            }
        }

        public bool DelegationStateBinding
        {
            get
            {
                return false;
            }
            set
            {
                _delegationReadonly = value; RaisePropertyChanged();

            }
        }
        
        private void EmailLookupRequestHandler(string email)
        {
            LaunchMailClient(email);
        }
        /// <summary>
        ///  TODO: move all this to the assist map.
        /// </summary>
        /// <param name="assistTableName"></param>
        /// <param name="assistQuery"></param>
        private async void AssistQueryRequestHandler(string assistTableName, string assistQuery)
        {
            IAssist assist = new Assist();
            assist.Name = assistTableName;
            assist.Query = assistQuery;
            if (string.IsNullOrEmpty(assist.Query))
            {
                return;
            }
            // FIXME i have find no way to avoid return type case.
            AssistResponse dto = new AssistResponse(DataServices.GetHelperDataServices());
            switch (assist.Name)
            {
                case "PROVINCIA":
                    {

                        var province = await dto.HandleAssist<PROVINCIA>(assist);
                        ProvinceDto = mapper.Map<IEnumerable<PROVINCIA>, IEnumerable<ProvinciaDto>>(province.ResultList());
                        break;
                    }
                case "PROV_PAGO":
                    {
                        var province = await dto.HandleAssist<PROVINCIA>(assist);
                        var provinceList = mapper.Map<IEnumerable<PROVINCIA>, IEnumerable<ProvinciaDto>>(province.ResultList());
                        ProvinceDto1 = new ObservableCollection<ProvinciaDto>(provinceList);
                        break;
                    }
                case "PROV_RECL":
                    {
                        var province = await dto.HandleAssist<PROVINCIA>(assist);
                        var provinceList = mapper.Map<IEnumerable<PROVINCIA>, IEnumerable<ProvinciaDto>>(province.ResultList());
                        ProvinceDto2 = new ObservableCollection<ProvinciaDto>(provinceList);
                        break;
                    }
                case "PROV_DEVO":
                    {
                        var province = await dto.HandleAssist<PROVINCIA>(assist);
                        var manual1 = mapper.Map<IEnumerable<PROVINCIA>, IEnumerable<ProvinciaDto>>(province.ResultList());
                        ProvinceDto3 = new ObservableCollection<ProvinciaDto>(manual1);
                        break;
                    }
                case "PAIS_PAGO":
                    {
                        var country = await dto.HandleAssist<Country>(assist);
                        var value = mapper.Map<IEnumerable<Country>, IEnumerable<CountryDto>>(country.ResultList());
                        CountryDto1 = new ObservableCollection<CountryDto>(value);
                        break;
                    }
                case "PAIS_RECL":
                    {
                        var country = await dto.HandleAssist<Country>(assist);
                        var value = mapper.Map<IEnumerable<Country>, IEnumerable<CountryDto>>(country.ResultList());
                        CountryDto2 = new ObservableCollection<CountryDto>(value);
                        break;
                    }
                case "PAIS_DEVO":
                    {
                        var country = await dto.HandleAssist<Country>(assist);
                        var value = mapper.Map<IEnumerable<Country>, IEnumerable<CountryDto>>(country.ResultList());
                        CountryDto3 = new ObservableCollection<CountryDto>(value);
                        break;
                    }
                case "TL_CONDICION_PRECIO":
                {
                    var priceConf = await dto.HandleAssist<TL_CONDICION_PRECIO>(assist);
                    var value = mapper.Map<IEnumerable<TL_CONDICION_PRECIO>, IEnumerable<PriceConditionDto>>(priceConf.ResultList());
                    PriceConditionDto = value;
                    break;
                }
                case "POBLACIONES_PAGO":
                {
                    var poblacionQuery = "SELECT CP,POBLA FROM POBLACIONES";
                    assist.Query = poblacionQuery;
                    var poblacion = await dto.HandleAssist<POBLACIONES>(assist);
                    var value = mapper.Map<IEnumerable<POBLACIONES>, IEnumerable<CityDto>>(poblacion.ResultList());
                    CityDto1 = new ObservableCollection<CityDto>(value);
                    break;
                }
                case "FORMAS_PEDENT":
                {
                    var formas = "SELECT CODIGO,NOMBRE FROM FORMAS_PEDENT";
                    assist.Query = formas;
                    var deliveringForm = await dto.HandleAssist<FORMAS_PEDENT>(assist);
                    DeliveringFormDto = mapper.Map<IEnumerable<FORMAS_PEDENT>, IEnumerable<DeliveringFormDto>>(deliveringForm.ResultList());
                    break;
                }
                case "VIASPEDIPRO":
                {
                    var formas = "SELECT CODIGO,NOMBRE FROM VIASPEDIPRO";
                    assist.Query = formas;
                    var deliveringWay = await dto.HandleAssist<VIASPEDIPRO>(assist);
                    DeliveringWayDto = mapper.Map<IEnumerable<VIASPEDIPRO>, IEnumerable<DeliveringWayDto>>(deliveringWay.ResultList());
                   
                    break;
                }

                case "TIPOPROVE":
                    {
                        string value = "SELECT NUM_TIPROVE, NOMBRE FROM TIPOPROVE";
                        IHelperDataServices helperDataServices = DataServices.GetHelperDataServices();
                        var supplierType = await helperDataServices.GetAsyncHelper<TIPOPROVE>(value);
                        SupplierTypeDto1 = mapper.Map<IEnumerable<TIPOPROVE>, IEnumerable<SupplierTypeDto>>(supplierType);
                        break;
                    }
                case "POBLACIONES_RECL":
                    {
                        var poblacionQuery = "SELECT CP,POBLA FROM POBLACIONES";
                        assist.Query = poblacionQuery;
                        var poblacion = await dto.HandleAssist<POBLACIONES>(assist);
                        var value = mapper.Map<IEnumerable<POBLACIONES>, IEnumerable<CityDto>>(poblacion.ResultList());
                        CityDto2 = new ObservableCollection<CityDto>(value);
                        break;
                    }

                case "POBLACIONES_DEVO":
                    {
                        var poblacionQuery = "SELECT CP,POBLA FROM POBLACIONES";
                        assist.Query = poblacionQuery;
                        var poblacion = await dto.HandleAssist<POBLACIONES>(assist);
                        var value = mapper.Map<IEnumerable<POBLACIONES>, IEnumerable<CityDto>>(poblacion.ResultList());
                        CityDto3 = new ObservableCollection<CityDto>(value);
                        break;
                    }
                case "POBLACIONES":
                    {
                        var poblacionQuery = "SELECT CP,POBLA FROM POBLACIONES";
                        assist.Query = poblacionQuery;
                        var poblacion = await dto.HandleAssist<POBLACIONES>(assist);
                        var value = mapper.Map<IEnumerable<POBLACIONES>, IEnumerable<CityDto>>(poblacion.ResultList());
                        CityDto = new ObservableCollection<CityDto>(value);

                        break;
                    }
                case "OFICINAS":
                    {
                       
                        var office = await dto.HandleAssist<OFICINAS>(assist);
                        OfficeDtos = mapper.Map<IEnumerable<OFICINAS>, IEnumerable<OfficeDtos>>(office.ResultList());
                        break;
                    }
                case "SUBLICEN":
                    {
                        var company = await dto.HandleAssist<SUBLICEN>(assist);
                        CompanyDtos = mapper.Map<IEnumerable<SUBLICEN>, IEnumerable<CompanyDto>>(company.ResultList());
                        break;
                    }
                case "DIVISAS":
                    {
                        var divisas = await dto.HandleAssist<DIVISAS>(assist);
                        CurrencyDtos = mapper.Map<IEnumerable<DIVISAS>, IEnumerable<CurrencyDto>>(divisas.ResultList());
                        break;
                    }
                case "FORMAS":
                    {
                        var formas = await dto.HandleAssist<FORMAS>(assist);
                        PaymentDtos = mapper.Map<IEnumerable<FORMAS>, IEnumerable<PaymentFormDto>>(formas.ResultList());
                        break;
                    }
                case "MESES":
                    {
                        var meses = await dto.HandleAssist<MESES>(assist);
                        MonthsDtos = mapper.Map<IEnumerable<MESES>, IEnumerable<MonthsDto>>(meses.ResultList());
                        break;
                    }
                case "MESES2":
                    {
                        var mesesAssist = "SELECT NUMERO_MES, MES FROM MESES";
                        assist.Query = mesesAssist;
                        var meses = await dto.HandleAssist<MESES>(assist);
                        MonthsDtos2 = mapper.Map<IEnumerable<MESES>, IEnumerable<MonthsDto>>(meses.ResultList());
                        break;
                    }
                case "BANCO":
                    {
                        var banks = await dto.HandleAssist<BANCO>(assist);
                        BanksDtos = mapper.Map<IEnumerable<BANCO>, IEnumerable<BanksDto>>(banks.ResultList());
                        break;
                    }
                case "IDIOMAS":
                    {
                        var idiomas = await dto.HandleAssist<IDIOMAS>(assist);
                        LanguageDtos = mapper.Map<IEnumerable<IDIOMAS>, IEnumerable<LanguageDto>>(idiomas.ResultList());
                        break;
                    }
                case "CU1":
                    {
                        assist.Query = GenericSql.AccountSummaryQuery;
                        var cu = await dto.HandleAssist<CU1>(assist);
                        Account1Dtos = mapper.Map<IEnumerable<CU1>, IEnumerable<AccountDto>>(cu.ResultList());
                        break;
                    }
                case "CU1Gasto":
                    {
                        assist.Query = AccountAssistQuery;
                        var cu1Gasto = await dto.HandleAssist<CU1>(assist);
                        Account2Dtos = mapper.Map<IEnumerable<CU1>, IEnumerable<AccountDto>>(cu1Gasto.ResultList());
                        break;

                    }
                case "CU1Retencion":
                    {
                        assist.Query = AccountAssistQuery;
                        var cu1Retencion = await dto.HandleAssist<CU1>(assist);
                        Account3Dtos = mapper.Map<IEnumerable<CU1>, IEnumerable<AccountDto>>(cu1Retencion.ResultList());
                        break;
                    }
                case "CU1Pago":
                    {
                        assist.Query = AccountAssistQuery;
                        var cu1Pago = await dto.HandleAssist<CU1>(assist);
                        Account4Dtos = mapper.Map<IEnumerable<CU1>, IEnumerable<AccountDto>>(cu1Pago.ResultList());
                        break;
                    }
                case "CU1CP":
                    {
                        assist.Query = AccountAssistQuery;
                        var cu1Cp = await dto.HandleAssist<CU1>(assist);
                        Account5Dtos = mapper.Map<IEnumerable<CU1>, IEnumerable<AccountDto>>(cu1Cp.ResultList());
                        break;
                    }
                case "CU1LP":
                    {
                        assist.Query = AccountAssistQuery;
                        var cu1LP = await dto.HandleAssist<CU1>(assist);
                        Account6Dtos = mapper.Map<IEnumerable<CU1>, IEnumerable<AccountDto>>(cu1LP.ResultList());
                        break;
                    }
                case "CU1Intraco":
                    {
                        assist.Query = AccountAssistQuery;
                        var cu1Intraco = await dto.HandleAssist<CU1>(assist);
                        Account7Dtos = mapper.Map<IEnumerable<CU1>, IEnumerable<AccountDto>>(cu1Intraco.ResultList());
                        break;
                    }
                case "CU1Reper":
                    {
                        assist.Query = AccountAssistQuery;
                        var cu1Reper = await dto.HandleAssist<CU1>(assist);
                        Account8Dtos = mapper.Map<IEnumerable<CU1>, IEnumerable<AccountDto>>(cu1Reper.ResultList());
                        break;
                    }
                case "PAIS":
                    {

                        var country = await dto.HandleAssist<Country>(assist);
                        var value = mapper.Map<IEnumerable<Country>, IEnumerable<CountryDto>>(country.ResultList());
                        CountryDto = new ObservableCollection<CountryDto>(value);
                        // see any dups.
                        CountryDtos = CountryDto;
                        break;
                    }
            }
        }
        public IEnumerable<SupplierTypeDto> SupplierTypeDto1
        {
            set
            {
                _supplierTypeDto = value;
                RaisePropertyChanged("SupplierTypeDto1");
            }
            get
            {
                return _supplierTypeDto;
            }
        }
        private void OnChangedField(IDictionary<string, object> eventDictionary)
        {
            DataPayLoad payLoad = BuildDataPayload(eventDictionary);
            
            payLoad.Subsystem = DataSubSystem.SupplierSubsystem;
            payLoad.SubsystemName = MasterModuleConstants.ProviderSubsystemName;
            payLoad.PayloadType = DataPayLoad.Type.Update;
            ChangeFieldHandlerDo<ISupplierData> handlerDo = new ChangeFieldHandlerDo<ISupplierData>(EventManager,
                DataSubSystem.SupplierSubsystem);

            var fieldName = string.Empty;
           
            SetBasePayLoad(eventDictionary, ref payLoad);
            // FIXME: replace conditional with polymorphism.
            if (CurrentOperationalState == DataPayLoad.Type.Insert)
            {
                payLoad.PayloadType = DataPayLoad.Type.Insert;
                handlerDo.OnInsert(payLoad, eventDictionary);
            }
            else
            {
                payLoad.PayloadType = DataPayLoad.Type.Update;
                handlerDo.OnUpdate(payLoad, eventDictionary);
            }
        }

        
        public IEnumerable<BranchesDto> DelegationCollection { get; set; }
        public IEnumerable<VisitsDto> VisitCollection { get; set; }
        public IEnumerable<ContactsDto> ContactsCollection { get; set; }
    
        public IEnumerable<ProvinciaDto> ProvinceDto
        {
            get { return _provinciaDtos; }
            set { _provinciaDtos = value; RaisePropertyChanged(); }
        }



        public IEnumerable<OfficeDtos> OfficeDtos
        {
            get { return _officeDtos; }
            set { _officeDtos = value; RaisePropertyChanged(); }
        }

        public IEnumerable<CountryDto> CountryDtos
        {

            get { return _countryDtos; }
            set { _countryDtos = value; RaisePropertyChanged(); }
        }
        public IEnumerable<CompanyDto> CompanyDtos
        {

            get { return _companyDto; }
            set { _companyDto = value; RaisePropertyChanged(); }
        }

        public IEnumerable<PaymentFormDto> PaymentDtos
        {
            get { return _paymentDtos; }
            set { _paymentDtos = value; RaisePropertyChanged(); }
        }
        public IEnumerable<MonthsDto> MonthsDtos
        {
            get { return _monthsDto; }
            set { _monthsDto = value; RaisePropertyChanged(); }
        }
        public IEnumerable<MonthsDto> MonthsDtos2
        {
            get { return _monthsDto2; }
            set { _monthsDto2 = value; RaisePropertyChanged(); }
        }
        public IEnumerable<BanksDto> BanksDtos
        {
            get { return _banksDto; }
            set { _banksDto = value; RaisePropertyChanged(); }
        }

        public IEnumerable<LanguageDto> LanguageDtos
        {
            get { return _languagesDto; }
            set { _languagesDto = value; RaisePropertyChanged(); }
        }

        public IEnumerable<AccountDto> Account1Dtos
        {
            get { return _account1Dto; }
            set
            {
                _account1Dto = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<AccountDto> Account2Dtos
        {
            get { return _account2Dto; }
            set
            {
                _account2Dto = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<CurrencyDto> CurrencyDtos
        {
            get { return _currencyDtos; }
            set
            {
                _currencyDtos = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<AccountDto> Account3Dtos
        {
            get { return _account3Dto; }
            set
            {
                _account3Dto = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<AccountDto> Account4Dtos
        {
            get { return _account4Dto; }
            set
            {
                _account4Dto = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<AccountDto> Account5Dtos
        {
            get { return _account5Dto; }
            set
            {
                _account5Dto = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<AccountDto> Account6Dtos
        {
            get { return _account6Dto; }
            set
            {
                _account6Dto = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<AccountDto> Account7Dtos
        {
            get { return _account7Dto; }
            set
            {
                _account7Dto = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<AccountDto> Account8Dtos
        {
            get { return _account8Dto; }
            set
            {
                _account8Dto = value;
                RaisePropertyChanged();
            }
        }
        public ObservableCollection<ProvinciaDto> ProvinceDto1
        {
            get { return _provinciaDto1; }
            set { _provinciaDto1 = value; RaisePropertyChanged(); }
        }

        public IEnumerable<PriceConditionDto> PriceConditionDto
        {
            get { return _priceConditionDto; }
            set { _priceConditionDto = value; RaisePropertyChanged(); }
        }

        public IEnumerable<DeliveringFormDto> DeliveringFormDto
        {
            get { return _deliveryFromDto; }
            set { _deliveryFromDto = value; RaisePropertyChanged(); }
        }
        public IEnumerable<DeliveringWayDto> DeliveringWayDto {
            get { return _deliveryWayDto; }
            set { _deliveryWayDto = value; RaisePropertyChanged(); }
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
                Logger.Info("ProviderInfoViewModel has received payload type " + payload.PayloadType.ToString());
                var supplierData = payload.DataObject as ISupplierData;
                DataObject = supplierData;

                if (supplierData != null)
                {
                    ProvinceDto = supplierData.ProvinciaDtos;
                    ProvinceDto1 = new ObservableCollection<ProvinciaDto>(supplierData.ProvinciaDtos);
                    CountryDto1 = new ObservableCollection<CountryDto>(supplierData.CountryDtos);
                    ProvinceDto2 = new ObservableCollection<ProvinciaDto>(supplierData.ProvinciaDtos);
                    CountryDto2 = new ObservableCollection<CountryDto>(supplierData.CountryDtos);
                    ProvinceDto3 = new ObservableCollection<ProvinciaDto>(supplierData.ProvinciaDtos);
                    CountryDto3 = new ObservableCollection<CountryDto>(supplierData.CountryDtos);

                    CityDto3 = supplierData.CityDtos;
                    CityDto1 = supplierData.CityDtos;
                    CityDto2 = supplierData.CityDtos;
                    PaymentDtos = supplierData.PaymentDtos;
                    OfficeDtos = supplierData.OfficeDtos;
                    CompanyDtos = supplierData.CompanyDtos;
                    CityDto = supplierData.CityDtos;
                    CityDto1 = supplierData.CityDtos;
                    CityDto2 = supplierData.CityDtos;
                    CityDto3 = supplierData.CityDtos;
                    PaymentDtos = supplierData.PaymentDtos;
                    SupplierTypeDto1 = new ObservableCollection<SupplierTypeDto>(supplierData.Type);


                    // TODO: aux data shall be moved in a ax object and not present in the supplier.
                    MonthsDtos = supplierData.MonthsDtos;
                    MonthsDtos2 = supplierData.MonthsDtos;
                    BanksDtos = supplierData.BanksDtos;
                    LanguageDtos = supplierData.LanguageDtos;
                    CurrencyDtos = supplierData.CurrencyDtos;
                    Account1Dtos = supplierData.AccountDtos;
                    Account2Dtos = supplierData.AccountDtos;
                    Account3Dtos = supplierData.AccountDtos;
                    Account4Dtos = supplierData.AccountDtos;
                    Account5Dtos = supplierData.AccountDtos;
                    Account6Dtos = supplierData.AccountDtos;
                    Account7Dtos = supplierData.AccountDtos;
                    Account8Dtos = supplierData.AccountDtos;
                }

                EventManager.SendMessage(UpperBarViewSupplierViewModel.Name, payload);
                Logger.Info("ProviderInfoViewModel has activated the provider subsystem as current with directive " + payload.PayloadType.ToString());
                ActiveSubSystem();
               
            }
        }


        // <summary>
        /// This is the start notify.
        /// </summary>
        public override void StartAndNotify()
        {
            Logger.Log(LogLevel.Debug, "Started and notified.");
            _initializationTable =
                NotifyTaskCompletion.Create<ISupplierData>(LoadDataValue(PrimaryKeyValue, IsInsertion), InitializationDataObjectOnPropertyChanged);

        }

        /// <summary>
        /// This program loads the data from the data values.
        /// </summary>
        /// <param name="primaryKeyValue">Primary Key.</param>
        /// <param name="isInsertion">Inserted key.</param>
        /// <returns></returns>
        private async Task<ISupplierData> LoadDataValue(string primaryKeyValue, bool isInsertion)
        {

            ISupplierData supplier = null;
            if (isInsertion)
            {
                supplier = DataServices.GetSupplierDataServices().GetNewSupplierDo(PrimaryKeyValue);
                if (supplier != null)
                {
                    DataObject = supplier;
                }
            }
            else
            {
                supplier = await DataServices.GetSupplierDataServices().GetAsyncSupplierDo(primaryKeyValue);
                DataObject = supplier;
            }
            return supplier;
        }
        private void InitializationDataObjectOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (sender is ISupplierData)
            {
                ISupplierData supplierData = (ISupplierData)sender;
                DataObject = supplierData;
            }
        }

        /// <summary>
        /// Incoming payload . Refactor to the upper master layer.
        /// </summary>
        /// <param name="dataPayLoad">Payload to be used.</param>
        public override void IncomingPayload(DataPayLoad dataPayLoad)
        {
            DataPayLoad payload = dataPayLoad;

            ISupplierData pay = payload.DataObject as ISupplierData;
            if (pay == null)
            {

                return;
                /*     SupplierDto dto = pay.Value;
                     logger.Log(LogLevel.Debug, "ProviderViewModel Received " +dto.POB_PAGO);
                     */
            } // precondition not null
            if (dataPayLoad == null)
            {
                return;
            }
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
                    _mailBoxName = "Providers." + PrimaryKeyValue+ "."+ _uniqueCounter;
                    RegisterMailBox(_mailBoxName);
                }
                if (PrimaryKeyValue.Length > 0)
                {
                    // check if the message if for me.
                    if (pay.Value.NUM_PROVEE != PrimaryKeyValue)
                        return;
                    
                }
                // here i can fix the primary key. Consider to move up to the master module.
                
                switch (payload.PayloadType)
                {
                    case DataPayLoad.Type.UpdateData:
                        {
                            if (payload.HasDataObject)
                            {
                                DataObject = null;
                                DataObject = payload.DataObject as ISupplierData;
                                _supplierData = DataObject as ISupplierData;
                            }
                            break;
                        }
                    case DataPayLoad.Type.UpdateView:
                    case DataPayLoad.Type.Show:
                        {
                            if (!string.IsNullOrEmpty(PrimaryKeyValue))
                            {
                                Init(PrimaryKeyValue, payload, false);
                                //  StartAndNotify();
                                CurrentOperationalState = DataPayLoad.Type.Show;
                            }
                            break;
                        }
                    case DataPayLoad.Type.Insert:
                        {

                            CurrentOperationalState = DataPayLoad.Type.Insert;
                            if (string.IsNullOrEmpty(PrimaryKeyValue))
                            {
                                PrimaryKeyValue =
                                    DataServices.GetSupplierDataServices().GetNewId();

                            }
                            Init(PrimaryKeyValue, payload, true);
                            break;
                        }

                    case DataPayLoad.Type.Delete:
                        {
                            if (payload.PrimaryKeyValue == PrimaryKeyValue)
                            {
                                DeleteEventCleanup(payload.PrimaryKeyValue, PrimaryKeyValue, DataSubSystem.SupplierSubsystem, MasterModuleConstants.ProviderSubsystemName);
                                DeleteRegion(payload.PrimaryKeyValue);

                                PrimaryKeyValue = "";
                            }
                            break;
                        }
                }
            }

        }

        public override void DisposeEvents()
        {
            EventManager.DeleteObserverSubSystem(MasterModuleConstants.ProviderSubsystemName, this);
            DeleteMailBox(_mailBoxName);
            DataPayLoad payload = new DataPayLoad();
            payload.ObjectPath = ViewModelUri;
            payload.PayloadType = DataPayLoad.Type.Dispose;
            EventManager.NotifyToolBar(payload);

        }
        protected override void SetRegistrationPayLoad(ref DataPayLoad payLoad)
        {
            payLoad.PayloadType = DataPayLoad.Type.RegistrationPayload;
            payLoad.Subsystem = DataSubSystem.SupplierSubsystem;
        }
        protected override string GetRouteName(string name)
        {
            return "ProviderModule:" + name;
        }
        protected override void SetDataObject(object result)
        {
        }

        public override async Task SetContactsCharge(PersonalPositionDto personal, ContactsDto contactsDto)
        {
            var supplierData = DataObject as ISupplierData;
            IEnumerable<ContactsDto> contactsDtos = supplierData.ContactsDto;
            var ev = SetContacts(personal, contactsDto, DataObject, contactsDtos);
            await GridChangedNotification<ContactsDto, ProContactos>(ev, _onContactsPrimaryKey, DataSubSystem.SupplierSubsystem).ConfigureAwait(false);
            RaisePropertyChanged("DataObject");
            RaisePropertyChanged("DataObject.ContactsDto");
        }
        internal override Task SetClientData(ClientSummaryExtended p, VisitsDto visitsDto)
        {
            throw new NotImplementedException();     
       
        }

        internal override async Task SetVisitContacts(ContactsDto p, VisitsDto visitsDto)
        {
            var currentObject = DataObject as ISupplierData;
            var ev = CreateGridEvent<ContactsDto, VisitsDto>(p, visitsDto, currentObject.VisitsDto, this.ContactMagnifierCommand);
            visitsDto.ClientId = PrimaryKeyValue;
            var newList = new List<VisitsDto>();
            newList.Add(visitsDto);
            var exitDto = currentObject.VisitsDto;
            var mergedList = exitDto.Union<VisitsDto>(newList);
            currentObject.VisitsDto = mergedList;
            ev["DataObject"] =currentObject;
            // Notify the toolbar.
            await GridChangedNotification<VisitsDto, VISITAS_PROV>(ev, _onVisitPrimaryKey, DataSubSystem.SupplierSubsystem).ConfigureAwait(false);
        
        }

        private void _onVisitPrimaryKey(ref VisitsDto visitsDto)
        {
            visitsDto.KeyId = PrimaryKey;
        }

        internal override async Task SetBranchProvince(ProvinciaDto p, BranchesDto b)
        {
            var currentObject = DataObject as ISupplierData;
            if (currentObject!=null)
            {
                var ev = SetBranchProvince(p, b, DataObject, currentObject.BranchesDto);
                await GridChangedNotification<BranchesDto, ProDelega>(ev, _onBranchesPrimaryKey, DataSubSystem.SupplierSubsystem).ConfigureAwait(false);
            }
           
        }

        internal override Task SetVisitReseller(ResellerDto param, VisitsDto b)
        {
            throw new NotImplementedException();
        }
    }
}

