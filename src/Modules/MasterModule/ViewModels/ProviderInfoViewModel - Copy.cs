using KarveCommon.Services;
using KarveDataServices;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Input;
using AutoMapper;
using DataAccessLayer.Assist;
using DataAccessLayer.DataObjects;
using DataAccessLayer.Logic;
using KarveCommon.Generic;
using KarveDataServices.Assist;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;
using MasterModule.Common;
using Prism.Regions;
using Syncfusion.UI.Xaml.Grid;

namespace MasterModule.ViewModels
{
    /// <summary>
    /// </summary>
    public class ProviderInfoViewModel : MasterInfoViewModuleBase, IEventObserver
    {
        private bool _isInsertion;
        private string _header;
        private INotifyTaskCompletion<bool> _deleteInitializationTable;
        private INotifyTaskCompletion<ISupplierData> _initializationTable;
        // FIXME: move to data layer.
        private string _accountAssistQuery = "SELECT CODIGO, DESCRIP FROM CU1;";
        private bool _delegationReadonly;
        private DataSet _delegationSet;
        private string _delegationQuery = "";
        private ISupplierData _supplierData;
        private Visibility _visibility;
        private IEnumerable<ProvinciaDto> _provinciaDtos;
        private IEnumerable<OfficeDtos> _officeDtos;
        private IEnumerable<CountryDto> _countryDtos;
        private IEnumerable<CompanyDto> _companyDto;
       
        public ICommand ItemChangedCommand { set; get; }
        public ICommand ClickSearchWebAddressCommand { set; get; }
        private IMapper mapper;
        public DataTable DelegationTable
        {
            get
            {
                if (_delegationSet == null)
                {
                    return null;
                }
                if (_delegationSet.Tables.Count == 0)
                {
                    return null;
                }
                return _delegationSet.Tables[0];
            }
            set
            {
                if (_delegationSet == null)
                {
                    _delegationSet = new DataSet();
                    _delegationSet.Tables.Add(value);
                }
                else
                {
                    if (_delegationSet.Tables.Count == 0)
                    {
                        _delegationSet.Tables.Add(value);

                    }
                    else
                    {
                        _delegationSet.Tables[0].Merge(value);
                    }
                }
                RaisePropertyChanged("DelegationTable");
            }
        }

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
        private ObservableCollection<CountryDto> _countryDto1;
        private ObservableCollection<CountryDto> _countryDto2;
        private ObservableCollection<CityDto> _cityDto1;
        private ObservableCollection<CityDto> _cityDto2;
        // this is ok.
        private ObservableCollection<ProvinciaDto> _provinciaDtos2;
        private ObservableCollection<ProvinciaDto> _provinciaDto2;
        private ObservableCollection<ProvinciaDto> _provinciaDto3;
        private ObservableCollection<ProvinciaDto> _provinciaDto1;
        private ObservableCollection<CountryDto> _countryDto3;
        private ObservableCollection<CountryDto> _countryDto4;
        private ObservableCollection<CityDto> _cityDto3;

        public ObservableCollection<CountryDto> CountryDto
        {
            set { _countryDto1 = value; RaisePropertyChanged();}
            get { return _countryDto1; }
        }
        public ObservableCollection<CountryDto> CountryDto1
        {
            set { _countryDto2 = value; RaisePropertyChanged();}
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
        public ObservableCollection<CityDto> CityDto2
        {
         set { _cityDto2 = value; RaisePropertyChanged();}
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
        public override bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {

        }

        public override void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        public ICommand AssistCommand { set; get; }

        public ICommand EmailCommand { set; get; }
       
        public string Header
        {
            set
            {
                _header = value;
                RaisePropertyChanged();
            }
            get
            {
                return _header;
            }
        }
        /// <summary>
        /// ProviderInfoViewModel. 
        /// </summary>
        /// <param name="eventManager"></param>
        /// <param name="configurationService"></param>
        /// <param name="dataServices"></param>
        /// <param name="manager"></param>
        public ProviderInfoViewModel(IEventManager eventManager, IConfigurationService configurationService,
            IDataServices dataServices, IRegionManager manager) : base(eventManager, configurationService, dataServices, manager)
        {
            ConfigurationService = configurationService;
            MailBoxHandler += MessageHandler;
            DelegationChangedRowsCommand = new Prism.Commands.DelegateCommand<object>(DelegationChangeRows);
            //ContactsChangedRowsCommand = new DelegateCommand<object>(ContactsChangedRows);
            DelegationStateBinding = false;
            EmailCommand = new Prism.Commands.DelegateCommand<object>(LaunchMailClient);
            ClickSearchWebAddressCommand = new Prism.Commands.DelegateCommand<object>(LaunchWebBrowser);
            ItemChangedCommand = new Prism.Commands.DelegateCommand<object>(OnChangedField);
            AssistCommand = new Prism.Commands.DelegateCommand<object>(OnAssistCommand);
            AccountAssistQuery = _accountAssistQuery;
            //_deleteEventHandler += DeleteEventHandler;
            EventManager.RegisterObserverSubsystem(MasterModuleConstants.ProviderSubsystemName, this);
            // TODO: all the mapping shall be isolated.
            mapper = MapperField.GetMapper();
        }
        /*
        private void DeleteEventHandler(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            DataPayLoad payLoad = new DataPayLoad();
            payLoad.Subsystem = DataSubSystem.SupplierSubsystem;
            payLoad.SubsystemName = MasterModuleConstants.ProviderSubsystemName;
            payLoad.PrimaryKeyValue = PrimaryKeyValue;
            payLoad.PayloadType = DataPayLoad.Type.Delete;
            EventManager.NotifyToolBar(payLoad);
            PrimaryKeyValue = "";
        }
        */
       

        // This register the different assist types.

        private void OnAssistCommand(object param)
        {
            IDictionary<string, string> values = (Dictionary<string, string>)param;
            string assistTableName = values.ContainsKey("AssistTable") ? values["AssistTable"] as string : null;
            string assistQuery = values.ContainsKey("AssistQuery") ? values["AssistQuery"] as string : null;
            AssistQueryRequestHandler(assistTableName, assistQuery);
        }
        private void OnChangedField(object obj)
        {
            IDictionary<string, object> eventDictionary = (IDictionary<string, object>)obj;
            OnChangedField(eventDictionary);
        }
        /// <summary>
        ///  Handler for the delegation change rows
        ///  It handles the update, delete, insert
        /// </summary>
        /// <param name="parameter">Dictionary of parameters to be handled.</param>
        private void DelegationChangeRows(object parameter)
        {
            /*
            IDictionary<GridParams, object> eventParams = (IDictionary<GridParams, object>)parameter;
            DataTable table = (DataTable)eventParams[GridParams.DataSource];
            DataPayLoad payLoad = new DataPayLoad();
            payLoad.HasDataSet = true;
            payLoad.Queries = new Dictionary<string, string>();
            // Before doing the merge it shall check the alias field.
            string aliasField = (string)eventParams[GridParams.AliasField];
            if (!table.Columns.Contains(aliasField))
            {
                table.Columns.Add(aliasField);
            }
            foreach (DataRow row in table.Rows)
            {
                row[aliasField] = _primaryKeyValue;
            }
            table.TableName = DelegationDataBaseTableName;
            DelegationTable = table;
            payLoad.Set = _delegationSet;

            payLoad.Queries.Add(DelegationDataBaseTableName, ContainsAndAdd(_delegationQuery, aliasField));
            payLoad.Subsystem = DataSubSystem.SupplierSubsystem;
            payLoad.PrimaryKeyValue = ProviderConstants.DelegationesPrimaryKeyValue;
            if (eventParams.ContainsKey(GridParams.Operation))
            {
                GridOperation operation = (GridOperation)eventParams[GridParams.Operation];
                DataPayLoad.Type payLoadType = Convert(operation);
                payLoad.PayloadType = payLoadType;
                EventManager.NotifyToolBar(payLoad);
            }*/

        }

        /// <summary>
        ///  Data object.
        /// </summary>
        public object DataObject
        {
            set
            {
                _supplierData = (ISupplierData)value;
                RaisePropertyChanged();
            }
            get { return _supplierData; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="delegationQuery"></param>
        /// <param name="aliasField"></param>
        /// <returns></returns>
        private string ContainsAndAdd(string delegationQuery, string aliasField)
        {
            string str = ":";
            string[] stringValues = delegationQuery.Split(',');
            StringBuilder builder = new StringBuilder();
            int i = 0;
            foreach (string value in stringValues)
            {
                if (i == 1)
                {
                    builder.Append(aliasField);
                    builder.Append(",");
                }
                builder.Append(stringValues[i++]);
                if (i < stringValues.Length)
                    builder.Append(",");
            }
            str = builder.ToString();
            return str;
        }
        private DataPayLoad.Type Convert(GridOperation operation)
        {
            DataPayLoad.Type type = DataPayLoad.Type.Any;
            /*
            switch (operation)
            {
               
                case GridOperation.:
                    type = DataPayLoad.Type.Delete;
                    break;
                case GridOperation.Insert:
                    type = DataPayLoad.Type.Insert;
                    break;
                case GridOperation.Update:
                    type = DataPayLoad.Type.Update;
                    break;
                    
            }*/
            return type;
        }

        /// <summary>
        ///  This is an changed rows command.
        /// </summary>
        public ICommand DelegationChangedRowsCommand { set; get; }
        public ICommand ContactsChangedRowsCommand { set; get; }

        public string AccountAssistQuery
        {
            set { _accountAssistQuery = value; RaisePropertyChanged(); }
            get { return _accountAssistQuery; }
        }



        /// <summary>
        ///  TODO: remove the helper.
        /// </summary>
        /// <param name="primaryKeyValue"></param>
        /// <param name="isInsertion"></param>
        /// <param name="currentDataSet"></param>
        /// <param name="helper"></param>
        private void Init(string primaryKeyValue, bool isInsertion, DataPayLoad payLoad = null,
            DataSet currentDataSet = null, DataSet helper = null)
        {


            _isInsertion = isInsertion;
            if (payLoad != null)
            {

                if (payLoad.HasDataObject)
                {
                    _supplierData = (ISupplierData)payLoad.DataObject;
                    if (!string.IsNullOrEmpty(PrimaryKeyValue))
                    {
                        _supplierData.Value.NUM_PROVEE = this.PrimaryKeyValue;
                    }
                  DataObject = _supplierData;
                    
                    payLoad.Subsystem = DataSubSystem.SupplierSubsystem;
                    payLoad.SubsystemName = MasterModuleConstants.ProviderSubsystemName;
                    EventManager.SendMessage(UpperBarViewSupplierViewModel.Name, payLoad);
                    RegisterToolBar();
                }
            }

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
        ///  
        /// </summary>
        /// <param name="assistTableName"></param>
        /// <param name="assistQuery"></param>
        private async void AssistQueryRequestHandler(string assistTableName, string assistQuery)
        {
            IAssist assist = new Assist();
            assist.Name = assistTableName;
            assist.Query = assistQuery;
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
                    CountryDto = new ObservableCollection<CountryDto>(value);
                    break;
                }
                case "PAIS_RECL":
                {
                    var country = await dto.HandleAssist<Country>(assist);
                    var value = mapper.Map<IEnumerable<Country>, IEnumerable<CountryDto>>(country.ResultList());
                    CountryDto1 = new ObservableCollection<CountryDto>(value);
                    break;
                }
                case "PAIS_DEVO":
                {
                    var country = await dto.HandleAssist<Country>(assist);
                    var value = mapper.Map<IEnumerable<Country>, IEnumerable<CountryDto>>(country.ResultList());
                    CountryDto2 = new ObservableCollection<CountryDto>(value);
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
                        CompanyDtos = mapper.Map<IEnumerable<SUBLICEN>, IEnumerable<CompanyDto> >(company.ResultList());
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
                    assist.Query = AccountAssistQuery;
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

        private void OnChangedField(IDictionary<string, object> eventDictionary)
        {
            DataPayLoad payLoad = new DataPayLoad();
            payLoad.Subsystem = DataSubSystem.SupplierSubsystem;
            payLoad.SubsystemName = MasterModuleConstants.ProviderSubsystemName;

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
            // remove ViewModelQueries.
            ChangeFieldHandlerDo<ISupplierData> handlerDo = new ChangeFieldHandlerDo<ISupplierData>(EventManager,
                ViewModelQueries,
                DataSubSystem.SupplierSubsystem);

            if (CurrentOperationalState == DataPayLoad.Type.Insert)
            {
                handlerDo.OnInsert(payLoad, eventDictionary);

            }
            else
            {
                handlerDo.OnUpdate(payLoad, eventDictionary);
            }
        }
        private void LaunchMailClient(object value)
        {
            if (value != null)
            {
                string email = value as string;
                string emailUrl = "mailto:" + email + "?subject=KarveCar";

                System.Diagnostics.Process.Start(emailUrl);
            }
        }
        private void LaunchWebBrowser(object value)
        {
            if (value != null)
            {
                string webBrowser = value as string;
                if (webBrowser.Length > 0)
                {

                    System.Diagnostics.Process.Start(webBrowser);
                }
            }
        }
        public IEnumerable<BranchesDto> DelegationCollection { get; set; }
        public IEnumerable<VisitsDto> VisitCollection { get; set; }
        public IEnumerable<ContactsDto> ContactsCollection { get; set; }
        public string UniqueId { get; set; }
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

        public IEnumerable<PaymentFormDto> PaymentDtos {
            get { return _paymentDtos; }
            set { _paymentDtos = value; RaisePropertyChanged(); }
        }
        public IEnumerable<MonthsDto> MonthsDtos {
            get { return _monthsDto; }
            set { _monthsDto = value; RaisePropertyChanged();}
        }
        public IEnumerable<MonthsDto> MonthsDtos2
        {
            get { return _monthsDto2; }
            set { _monthsDto2 = value; RaisePropertyChanged(); }
        }
        public IEnumerable<BanksDto> BanksDtos {
            get { return _banksDto; }
            set { _banksDto =value; RaisePropertyChanged();}
        }

        public IEnumerable<LanguageDto> LanguageDtos
        {
            get { return _languagesDto; }
            set { _languagesDto = value; RaisePropertyChanged();}
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
                DataObject = null;
                if (payload.PrimaryKeyValue == primaryKeyValue)
                {

                    _supplierData = (ISupplierData)payload.DataObject;

                    ProvinceDto = _supplierData.ProvinciaDtos;
                    PaymentDtos = _supplierData.PaymentDtos;
                    OfficeDtos = _supplierData.OfficeDtos;
                    CompanyDtos = _supplierData.CompanyDtos;
                    CityDto = _supplierData.CityDtos;
                    // TODO: aux data shall be moved in a ax object and not present in the supplier.
                    MonthsDtos = _supplierData.MonthsDtos;
                    MonthsDtos2 = _supplierData.MonthsDtos;
                    BanksDtos = _supplierData.BanksDtos;
                    LanguageDtos = _supplierData.LanguageDtos;
                    CurrencyDtos = _supplierData.CurrencyDtos;
                    EventManager.SendMessage(UpperBarViewSupplierViewModel.Name, payload);
                    DataObject = _supplierData;
                    ActiveSubSystem();
                }
            }
        }
        /// <summary>
        /// Incoming payload . Refactor to the upper master layer.
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
                    string mailboxName = "Providers." + PrimaryKeyValue;
                    RegisterMailBox(mailboxName);
                }
                // here i can fix the primary key. Consider to move up to the master module.
                switch (payload.PayloadType)
                {
                    case DataPayLoad.Type.UpdateData:
                        {
                            if (payload.HasDataObject)
                            {
                                DataObject = null;
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
                               // DeleteRegion(payload.PrimaryKeyValue);
                                PrimaryKeyValue = "";
                            }
                            break;
                        }
                }
            }

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
            _supplierData = (ISupplierData)result;
        }
    }
}

