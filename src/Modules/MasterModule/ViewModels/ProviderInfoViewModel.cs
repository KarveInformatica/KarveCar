using KarveCommon.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using AutoMapper;
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
using KarveDataServices.ViewObjects;
using KarveDataServices;
using KarveDataServices.Assist;
using KarveCommonInterfaces;
using DataAccessLayer.DtoWrapper;

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
        private IEnumerable<ProvinceViewObject> _provinceGridView = new List<ProvinceViewObject>();
        private IEnumerable<OfficeViewObject> _officeDtos = new List<OfficeViewObject>();
        private IEnumerable<CountryViewObject> _countryDtos = new List<CountryViewObject>();
        private IEnumerable<CompanyViewObject> _companyDto;
        private static long _uniqueCounter = 0;
        private IMapper mapper;
       

        private const string ProviderInfoVm = "ProviderInfoViewModel";
       
        private IEnumerable<PaymentFormViewObject> _paymentDtos;
        private IEnumerable<MonthsViewObject> _monthsDto;
        private IEnumerable<BanksViewObject> _banksDto;
        private IEnumerable<LanguageViewObject> _languagesDto;
        private IEnumerable<AccountViewObject> _account1Dto;
        private IEnumerable<AccountViewObject> _account2Dto;
        private IEnumerable<CurrencyViewObject> _currencyDtos;
        private IEnumerable<MonthsViewObject> _monthsDto2;
        private IEnumerable<AccountViewObject> _account3Dto;
        private IEnumerable<AccountViewObject> _account4Dto;
        private IEnumerable<AccountViewObject> _account5Dto;
        private IEnumerable<AccountViewObject> _account6Dto;
        private IEnumerable<AccountViewObject> _account7Dto;
        private IEnumerable<AccountViewObject> _account8Dto;
        private IEnumerable<CountryViewObject> _countryDto1 = new ObservableCollection<CountryViewObject>();
        private IEnumerable<CountryViewObject> _countryDto2 = new ObservableCollection<CountryViewObject>();
        private IEnumerable<CityViewObject> _cityDto1 = new ObservableCollection<CityViewObject>();
        private IEnumerable<CityViewObject> _cityDto2 = new ObservableCollection<CityViewObject>();
        // this is ok.
        private IEnumerable<ProvinceViewObject> _provinciaDtos2 = new ObservableCollection<ProvinceViewObject>();
        private IEnumerable<ProvinceViewObject> _provinciaDto2 = new ObservableCollection<ProvinceViewObject>();
        private IEnumerable<ProvinceViewObject> _provinciaDto3 = new ObservableCollection<ProvinceViewObject>();
        private IEnumerable<ProvinceViewObject> _provinciaDto1 = new ObservableCollection<ProvinceViewObject>();
        private IEnumerable<CountryViewObject> _countryDto3 = new ObservableCollection<CountryViewObject>();
        private IEnumerable<CountryViewObject> _countryDto4 = new ObservableCollection<CountryViewObject>();
        private IEnumerable<CityViewObject> _cityDto3 = new ObservableCollection<CityViewObject>();
        private IEnumerable<CityViewObject> _cityDto11 = new ObservableCollection<CityViewObject>();
        private ICommand _contactChangedCommand;
        private string _mailBoxName = string.Empty;
        private IEnumerable<ViaViewObject> _viaDtos;
        private IEnumerable<PaymentFormViewObject> _formaDtos;
        private IEnumerable<PriceConditionViewObject> _priceConditionDto;
        private IEnumerable<DeliveringFormViewObject> _deliveryFromDto;
        private IEnumerable<DeliveringWayViewObject> _deliveryWayDto;
        private IEnumerable<SupplierTypeViewObject> _supplierTypeDto = new ObservableCollection<SupplierTypeViewObject>();

        private event SetPrimaryKey<BranchesViewObject> _onBranchesPrimaryKey;
        private event SetPrimaryKey<ContactsViewObject> _onContactsPrimaryKey;
        //private IncrementalItemsSource = new IncrementalList<OrderInfo>(LoadMoreItems) { MaxItemCount = 1000 };

    public IEnumerable<CountryViewObject> CountryDto
        {
            set { _countryDto1 = value; RaisePropertyChanged(); }
            get { return _countryDto1; }
        }
        public IEnumerable<CountryViewObject> CountryDto1
        {
            set { _countryDto2 = value; RaisePropertyChanged(); }
            get { return _countryDto2; }
        }

        public IEnumerable<CountryViewObject> CountryDto2
        {
            set
            {
                _countryDto3 = value;
                RaisePropertyChanged();
            }
            get { return _countryDto3; }

        }

        public IEnumerable<CityViewObject> CityDto
        {
            set { _cityDto1 = value; RaisePropertyChanged(); }
            get { return _cityDto1; }
        }
        public IEnumerable<CityViewObject> CityDto1
        {
            set { _cityDto11 = value; RaisePropertyChanged(); }
            get { return _cityDto11; }
        }
        public IEnumerable<CityViewObject> CityDto2
        {
            set { _cityDto2 = value; RaisePropertyChanged(); }
            get { return _cityDto2; }
        }
        public IEnumerable<CityViewObject> CityDto3
        {
            set { _cityDto3 = value; RaisePropertyChanged(); }
            get { return _cityDto3; }
        }
        public IEnumerable<ProvinceViewObject> ProvinceDto2
        {
            set { _provinciaDtos2 = value; RaisePropertyChanged(); }
            get { return _provinciaDtos2; }
        }
        public IEnumerable<ProvinceViewObject> ProvinceDto3
        {
            set { _provinciaDto3 = value; RaisePropertyChanged(); }
            get { return _provinciaDto3; }
        }

        public IEnumerable<CountryViewObject> CountryDto3
        {

            set { _countryDto3 = value; RaisePropertyChanged(); }
            get { return _countryDto3; }

        }

        public IEnumerable<ViaViewObject> ViaDtos
        {
            set { _viaDtos = value; RaisePropertyChanged(); }
            get { return _viaDtos; }
        }

        public IEnumerable<PaymentFormViewObject> FormasDtos
        {
            set { _formaDtos = value; RaisePropertyChanged(); }
            get { return _formaDtos; }
        }

        public ICommand DelegationGridChangedCommand { set; get; }



        private IAssistDataService _assistDataService;
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
            _assistDataService = dataServices.GetAssistDataServices();
            SubSystem = DataSubSystem.SupplierSubsystem;
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
        private void ProviderInfoViewModel__onContactsPrimaryKey(ref ContactsViewObject primaryKey)
        {
            primaryKey.ContactsKeyId = PrimaryKeyValue;
        }

        private void ProviderInfoViewModel__onBranchesPrimaryKey(ref BranchesViewObject primaryKey)
        {
            primaryKey.BranchKeyId = PrimaryKeyValue;
        }
        
        /// <summary>
        ///  Handle the delegation grid changes.
        /// </summary>
        /// <param name="obj">This send a delegation fo the changed command</param>
        private async void DelegationChangedCommandHandler(object obj)
        {

            await GridChangedNotification<BranchesViewObject, ProDelega>(obj, _onBranchesPrimaryKey, DataSubSystem.SupplierSubsystem).ConfigureAwait(false);

        }

        private async void ContactsChangedCommandHandler(object obj)
        {
            await GridChangedNotification<ContactsViewObject, ProContactos>(obj, _onContactsPrimaryKey, DataSubSystem.SupplierSubsystem).ConfigureAwait(false);
        }
        // This register the different assist types.


        private void OnAssistCommand(object param)
        {
            IDictionary<string, string> values = param as Dictionary<string, string>;

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

        private List<MonthsViewObject> fillMonths()
        {
            var supplier = new List<MonthsViewObject>()
            {
                new MonthsViewObject() {NUMERO_MES = 1, MES= "Enero"},
                new MonthsViewObject() {NUMERO_MES = 2, MES= "Febrero"},
                new MonthsViewObject() {NUMERO_MES = 3, MES= "Marzo"},
                new MonthsViewObject() {NUMERO_MES = 4, MES= "Avril"},
                new MonthsViewObject() {NUMERO_MES = 5, MES= "Mayo"},
                new MonthsViewObject() {NUMERO_MES = 6, MES= "Junio"},
                new MonthsViewObject() {NUMERO_MES = 7, MES= "Julio"},
                new MonthsViewObject() {NUMERO_MES = 8, MES= "Agosto"},
                new MonthsViewObject() {NUMERO_MES = 9, MES= "Septiembre"},
                new MonthsViewObject() {NUMERO_MES = 10, MES= "Octubre"},
                new MonthsViewObject() {NUMERO_MES = 11, MES= "Noviembre"},
                new MonthsViewObject() {NUMERO_MES = 12, MES= "Diciembre"}

            };
            return supplier;
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
        private async void AssistQueryRequestHandler(string mappedName, string assistQuery)
        {


           var mapper = _assistDataService.Mapper;
           var res = await mapper.ExecuteAssistGeneric(mappedName, assistQuery);
            if (res is NullAssist)
            {
                return;
            }
            switch (mappedName)
            {
                case "PROVINCIA":
                    {
                        var value = (IEnumerable<ProvinceViewObject>)res;
                        ProvinceDto = value;
                        break;
                    }
                case "PROV_PAGO":
                    {
                        var value = (IEnumerable<ProvinceViewObject>)res;
                        ProvinceDto1 = value;
                        break;
                    }
                case "PROV_RECL":
                    {
                        var value = (IEnumerable<ProvinceViewObject>)res;
                        ProvinceDto2 = value;
                        break;
                    }
                case "PROV_DEVO":
                    {
                        var value= (IEnumerable<ProvinceViewObject>)res;
                        ProvinceDto3 =value;
                        break;
                    }
                case "PAIS_PAGO":
                    {
                        var value = (IEnumerable<CountryViewObject>)res;
                        CountryDto1 = value;
                        break;
                    }
                case "PAIS_RECL":
                    {
                        var value = (IEnumerable<CountryViewObject>)res;
                        CountryDto2 = value; 
                        break;
                    }
                case "PAIS_DEVO":
                    {
                        var value = (IEnumerable<CountryViewObject>)res;
                        CountryDto3 = value; 
                        break;
                    }
                case "TL_CONDICION_PRECIO":
                {
                    var value = (IEnumerable<PriceConditionViewObject>)res;
                        PriceConditionDto = value;
                    break;
                }
                case "POBLACIONES_PAGO":
                {
                    var value = (IEnumerable<CityViewObject>)res;
                    CityDto1 =value; 
                    break;
                }
                case "FORMAS_PEDENT":
                {
                    var value = (IEnumerable<DeliveringFormViewObject>)res;
                    DeliveringFormDto = value;
                    break;
                }
                case "VIASPEDIPRO":
                {
                   var vias = (IEnumerable<DeliveringWayViewObject>)res;
                   DeliveringWayDto = vias;
                    break;
                }

                case "TIPOPROVE":
                    {
                        var tipoprove = (IEnumerable<SupplierTypeViewObject>)res;
                        SupplierTypeDto1 = tipoprove;
                        break;
                    }
                case "POBLACIONES_RECL":
                    {
                        var value = (IEnumerable<CityViewObject>)res;
                        CityDto2 = value;
                        break;
                    }

                case "POBLACIONES_DEVO":
                    {
                        var value = (IEnumerable<CityViewObject>)res;
                       
                        CityDto3 = value; 
                        break;
                    }
                case "CITY_ASSIST":
                    {
                        var value = (IEnumerable<CityViewObject>)res;
                        CityDto = value;
                        break;
                    }
                case "OFICINAS":
                    {                  
                        var office = (IEnumerable<OfficeViewObject>)res;
                        OfficeDtos = office;
                        break;
                    }
                case "SUBLICEN":
                    {
                        var value = (IEnumerable<CompanyViewObject>)res;
                        CompanyDtos = value;
                        break;
                    }
                case "DIVISAS":
                    {
                        var value = (IEnumerable<CurrencyViewObject>)res;
                        CurrencyDtos = value;
                        break;
                    }
                case "FORMAS":
                    {
                        var value = (IEnumerable<PaymentFormViewObject>)res;
                        PaymentDtos = value;
                        break;
                    }
                case "MESES":
                    {
                        MonthsDtos = fillMonths(); 
                        break;
                    }
                case "MESES2":
                    {
                        var meses = fillMonths();
                        MonthsDtos2 = meses;
                        break;
                    }
                case "BANCO":
                    {
                        var value = (IEnumerable<BanksViewObject>)res;
                        BanksDtos = value;
                        break;
                    }
                case "IDIOMAS":
                    {
                        var value = (IEnumerable<LanguageViewObject>)res;
                        LanguageDtos = value;
                        break;
                    }
                case "CU1":
                    {
                        var value= (IEnumerable<AccountViewObject>)res;
                        Account1Dtos = value;
                        break;
                    }
                case "CU1Gasto":
                    {
                        var value = (IEnumerable<AccountViewObject>)res;

                        Account2Dtos = value;
                        break;

                    }
                case "CU1Retencion":
                    {
                        var value = (IEnumerable<AccountViewObject>)res;

                        Account3Dtos = value;
                        break;
                    }
                case "CU1Pago":
                    {
                        var value = (IEnumerable<AccountViewObject>)res;

                        Account4Dtos = value;
                        break;
                    }
                case "CU1CP":
                    {
                        var value = (IEnumerable<AccountViewObject>)res;

                        Account5Dtos = value;
                        break;
                    }
                case "CU1LP":
                    {
                        var value = (IEnumerable<AccountViewObject>)res;

                        Account6Dtos = value;
                       break;
                    }
                case "CU1Intraco":
                    {
                        var value = (IEnumerable<AccountViewObject>)res;

                        Account7Dtos = value;
                        break;
                    }
                case "CU1Reper":
                    {
                        var value = (IEnumerable<AccountViewObject>)res;

                        Account8Dtos =value;
                        break;
                    }
                case "PAIS":
                    {

                        var countryDto = (IEnumerable<CountryViewObject>)res;
                        CountryDto = countryDto;
                        // see any dups.
                        CountryDtos = CountryDto;
                        break;
                    }
            }
        }
        public IEnumerable<SupplierTypeViewObject> SupplierTypeDto1
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

        
        public IEnumerable<BranchesViewObject> DelegationCollection { get; set; }
        public IEnumerable<VisitsViewObject> VisitCollection { get; set; }
        public IEnumerable<ContactsViewObject> ContactsCollection { get; set; }
    
        public IEnumerable<ProvinceViewObject> ProvinceDto
        {
            get { return _provinceGridView; }
            set { _provinceGridView = value; RaisePropertyChanged("ProvinceDto"); }
        }



        public IEnumerable<OfficeViewObject> OfficeDtos
        {
            get { return _officeDtos; }
            set { _officeDtos = value; RaisePropertyChanged(); }
        }

        public IEnumerable<CountryViewObject> CountryDtos
        {

            get { return _countryDtos; }
            set { _countryDtos = value; RaisePropertyChanged(); }
        }
        public IEnumerable<CompanyViewObject> CompanyDtos
        {

            get { return _companyDto; }
            set { _companyDto = value; RaisePropertyChanged(); }
        }

        public IEnumerable<PaymentFormViewObject> PaymentDtos
        {
            get { return _paymentDtos; }
            set { _paymentDtos = value; RaisePropertyChanged(); }
        }
        public IEnumerable<MonthsViewObject> MonthsDtos
        {
            get { return _monthsDto; }
            set { _monthsDto = value; RaisePropertyChanged(); }
        }
        public IEnumerable<MonthsViewObject> MonthsDtos2
        {
            get { return _monthsDto2; }
            set { _monthsDto2 = value; RaisePropertyChanged(); }
        }
        public IEnumerable<BanksViewObject> BanksDtos
        {
            get { return _banksDto; }
            set { _banksDto = value; RaisePropertyChanged(); }
        }

        public IEnumerable<LanguageViewObject> LanguageDtos
        {
            get { return _languagesDto; }
            set { _languagesDto = value; RaisePropertyChanged(); }
        }

        public IEnumerable<AccountViewObject> Account1Dtos
        {
            get { return _account1Dto; }
            set
            {
                _account1Dto = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<AccountViewObject> Account2Dtos
        {
            get { return _account2Dto; }
            set
            {
                _account2Dto = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<CurrencyViewObject> CurrencyDtos
        {
            get { return _currencyDtos; }
            set
            {
                _currencyDtos = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<AccountViewObject> Account3Dtos
        {
            get { return _account3Dto; }
            set
            {
                _account3Dto = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<AccountViewObject> Account4Dtos
        {
            get { return _account4Dto; }
            set
            {
                _account4Dto = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<AccountViewObject> Account5Dtos
        {
            get { return _account5Dto; }
            set
            {
                _account5Dto = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<AccountViewObject> Account6Dtos
        {
            get { return _account6Dto; }
            set
            {
                _account6Dto = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<AccountViewObject> Account7Dtos
        {
            get { return _account7Dto; }
            set
            {
                _account7Dto = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<AccountViewObject> Account8Dtos
        {
            get { return _account8Dto; }
            set
            {
                _account8Dto = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<ProvinceViewObject> ProvinceDto1
        {
            get { return _provinciaDto1; }
            set { _provinciaDto1 = value; RaisePropertyChanged(); }
        }

        public IEnumerable<PriceConditionViewObject> PriceConditionDto
        {
            get { return _priceConditionDto; }
            set { _priceConditionDto = value; RaisePropertyChanged(); }
        }

        public IEnumerable<DeliveringFormViewObject> DeliveringFormDto
        {
            get { return _deliveryFromDto; }
            set { _deliveryFromDto = value; RaisePropertyChanged(); }
        }
        public IEnumerable<DeliveringWayViewObject> DeliveringWayDto {
            get { return _deliveryWayDto; }
            set { _deliveryWayDto = value; RaisePropertyChanged(); }
        }
        public ICommand LoadOtherData { set; get; }
        private void StartBackGroundRefresh(ISupplierData supplierData)
        {
            
            ProvinceDto1 = supplierData.ProvinceDtos;
            CountryDto1 = supplierData.CountryDtos;
            ProvinceDto2 = supplierData.ProvinceDtos;
            CountryDto2 = supplierData.CountryDtos;
            ProvinceDto3 = supplierData.ProvinceDtos;
            CountryDto3 = supplierData.CountryDtos;
            CountryDto1 = supplierData.CountryDtos;
            CityDto3 = supplierData.CityDtos;
            CityDto1 = supplierData.CityDtos;
            CityDto2 = supplierData.CityDtos;
            PaymentDtos = supplierData.PaymentDtos;
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
        private void ClearAll()
        {
            CleanupHelper<ProvinceViewObject>.CleanList(_supplierData.ProvinceDtos);
            CleanupHelper<OfficeViewObject>.CleanList(_supplierData.OfficeDtos);
          //  CleanupHelper<CountryDto>.CleanList(CountryDto);

        }
        private void StartRefresh(ISupplierData supplierData)
        {
            SupplierTypeDto1 = supplierData.Type;
          
            ProvinceDto = supplierData.ProvinceDtos;
            CityDto = supplierData.CityDtos;
            OfficeDtos = supplierData.OfficeDtos;
            CompanyDtos = supplierData.CompanyDtos;
           
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
                _supplierData = payload.DataObject as ISupplierData;
                DataObject = _supplierData;

                if (_supplierData != null)
                {

                    StartRefresh(_supplierData);
                    StartBackGroundRefresh(_supplierData);


                }

             //   EventManager.SendMessage(UpperBarViewSupplierViewModel.Name, payload);
                Logger.Info("ProviderInfoViewModel has activated the provider subsystem as current with directive " + payload.PayloadType.ToString());
                ActiveSubSystem();
               
            }
        }


        // <summary>
        /// This is the start notify.
        /// </summary>
        public void StartAndNotify()
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

        public void ClearList()
        {
           
            if (this.DataObject.ProvinceDtos is IList<ProvinceViewObject> dto)
            {
                dto.Clear();
            }
            if (this.DataObject.CountryDtos is IList<CountryViewObject> cdto)
            {
                cdto?.Clear();
            }
            
            if (this.DataObject.CityDtos is IList<CityViewObject> cdto1)
            {
                cdto1?.Clear();
            }
            if (this.DataObject.AccountDtos is IList<AccountViewObject> dtoAccount)
            {
                var account1 = _account1Dto as IList<AccountViewObject>;
                var account2 = _account2Dto as IList<AccountViewObject>;
                var account3 = _account3Dto as IList<AccountViewObject>;
                var account4 = _account4Dto as IList<AccountViewObject>;
                var account5 = _account5Dto as IList<AccountViewObject>;
                var account6 = _account6Dto as IList<AccountViewObject>;
                var account7 = _account7Dto as IList<AccountViewObject>;
                var account8 = _account8Dto as IList<AccountViewObject>;
                
                account1.Clear();
                account2.Clear();
                account3.Clear();
                account4.Clear();
                account5.Clear();
                account6.Clear();
                account7.Clear();
                account8.Clear();


            }
            var cityDto = _cityDto1 as List<CityViewObject>;
            cityDto?.Clear();
        }
        public override void DisposeEvents()
        {
            base.DisposeEvents();

            EventManager.DeleteObserverSubSystem(MasterModuleConstants.ProviderSubsystemName, this);
            DeleteMailBox(_mailBoxName);
            ClearList();
            var value = new Supplier();
            DataObject = value;
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

        public override async Task SetContactsCharge(PersonalPositionViewObject personal, ContactsViewObject contactsDto)
        {
            var supplierData = DataObject as ISupplierData;
            IEnumerable<ContactsViewObject> contactsDtos = supplierData.ContactsDto;
            var ev = SetContacts(personal, contactsDto, DataObject, contactsDtos);
            await GridChangedNotification<ContactsViewObject, ProContactos>(ev, _onContactsPrimaryKey, DataSubSystem.SupplierSubsystem).ConfigureAwait(false);
            RaisePropertyChanged("DataObject");
            RaisePropertyChanged("DataObject.ContactsDto");
        }
        internal override Task SetClientData(ClientSummaryExtended p, VisitsViewObject visitsDto)
        {
            throw new NotImplementedException();     
       
        }

        internal override async Task SetVisitContacts(ContactsViewObject p, VisitsViewObject visitsDto)

        {
            //set the id to the current visit.
            visitsDto.ClientId = PrimaryKeyValue;
            var currentObject = DataObject as ISupplierData;
            var ev = CreateGridEvent<ContactsViewObject, VisitsViewObject>(p, visitsDto, currentObject.VisitsDto, this.ContactMagnifierCommand);
            var newList = new List<VisitsViewObject>();
            newList.Add(visitsDto);
            var exitDto = currentObject.VisitsDto;
            var mergedList = exitDto.Union<VisitsViewObject>(newList);
            currentObject.VisitsDto = mergedList;
            ev["DataObject"] =currentObject;
            // Notify the toolbar.
            await GridChangedNotification<VisitsViewObject, VISITAS_PROV>(ev, _onVisitPrimaryKey, DataSubSystem.SupplierSubsystem).ConfigureAwait(false);
        
        }

        private void _onVisitPrimaryKey(ref VisitsViewObject visitsDto)
        {
            visitsDto.KeyId = PrimaryKey;
        }

        internal override async Task SetBranchProvince(ProvinceViewObject p, BranchesViewObject b)
        {
            var currentObject = DataObject as ISupplierData;
            if (currentObject!=null)
            {
                var ev = SetBranchProvince(p, b, DataObject, currentObject.BranchesDto);
                await GridChangedNotification<BranchesViewObject, ProDelega>(ev, _onBranchesPrimaryKey, DataSubSystem.SupplierSubsystem).ConfigureAwait(false);
            }
           
        }

        internal override Task SetVisitReseller(ResellerViewObject param, VisitsViewObject b)
        {
            throw new NotImplementedException();
        }

        public override void Dispose()
        {
        }
    }
}

