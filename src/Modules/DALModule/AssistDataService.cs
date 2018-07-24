using DataAccessLayer.DataObjects;
using KarveCommon.Generic;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using Syncfusion.UI.Xaml.Grid;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using System.Globalization;
using KarveDataServices.DataObjects;

namespace DataAccessLayer
{
    class AssistDataService : IAssistDataService
    {
        /// <summary>
        ///  Assis mapper / mapeo de las lupas.
        /// </summary>
        private IAssistMapper<BaseDto> _assistMapper = new AssistMapper<BaseDto>();
        private IHelperDataServices _helperDataServices;
        private IDataServices _dataServices;
        private object currentHelper;
        private string _clientFareCode = "0";
        private string _clientCode;

        /// <summary>
        ///  Assist Data Service.
        /// </summary>
        /// <param name="services"></param>
        public AssistDataService(IDataServices services)
        {
            _helperDataServices = services.GetHelperDataServices();
            _dataServices = services;
            DefaultPage = 30;
            ConfigureAssist();
        }
        /// <summary>
        ///  Assist Mapper.
        /// </summary>
        public IAssistMapper<BaseDto> Mapper
        {
            get
            {
                return _assistMapper;
            }
        }

        public int DefaultPage { get; private set; }

        /// <summary>
        ///  MakeAssitThroughHelper.
        /// </summary>
        /// <typeparam name="DtoType">Type of the data transfer object.</typeparam>
        /// <typeparam name="Entity">Type of the entity to be used.</typeparam>
        /// <param name="dataServices">Service to be used.</param>
        /// <param name="loadAction">Load action to be used.</param>
        public async Task<object> CreateAssistThroughHelper<DtoType, Entity>(IDataServices dataServices, Action<uint, int> loadAction) where DtoType : BaseDto where Entity : class
        {
            var helperDataServices = dataServices.GetHelperDataServices();
            var page = await _helperDataServices.GetPagedSummaryDoAsync<DtoType, Entity>(1, DefaultPage);
            var count = await _helperDataServices.GetItemsCount<Entity>();
            currentHelper = new IncrementalList<DtoType>(loadAction) { MaxItemCount = count };
            if (currentHelper is IncrementalList<DtoType> helper)
            {
                helper.LoadItems(page);
                currentHelper = helper;
            }
            return currentHelper;
        }

        private IncrementalList<DtoType> LoadMoreData<DtoType, Entity>(int baseIndex, object list) where Entity : class
            where DtoType : BaseDto
        {

            var currentList = list;
            var creation = NotifyTaskCompletion.Create<IEnumerable<DtoType>>(_helperDataServices.GetPagedSummaryDoAsync<DtoType, Entity>(baseIndex, DefaultPage), (sender, ev) =>
            {
                if (sender is INotifyTaskCompletion<IEnumerable<DtoType>> task)
                {
                    if (task.IsSuccessfullyCompleted)
                    {
                        if (list is IncrementalList<DtoType> l)
                        {
                            var items = task.Result as IEnumerable<DtoType>;
                            l.LoadItems(items);
                            currentList = l;
                        }
                    }
                }

            });
            return currentList as IncrementalList<DtoType>;
        }
        /// <summary>
        /// Retrieve incrementally data using a generic function
        /// </summary>
        /// <typeparam name="DtoType">Type of the data transfer object</typeparam>
        /// <param name="baseIndex">Index of the page</param>
        /// <param name="list">Current list of argument</param>
        /// <param name="dataRetriever">Function for retrieving data</param>
        /// <param name="code">Code to retrieve data</param>
        /// <returns></returns>
        private IncrementalList<DtoType> LoadMoreDataAction<DtoType>(int baseIndex, object list, Func<int, int, string, Task<IEnumerable<DtoType>>> dataRetriever)
           where DtoType : BaseDto
        {

            var currentList = list;
            var creation = NotifyTaskCompletion.Create<IEnumerable<DtoType>>(dataRetriever.Invoke(baseIndex, DefaultPage, _clientFareCode), (sender, ev) =>
            {
                if (sender is INotifyTaskCompletion<IEnumerable<DtoType>> task)
                {
                    if (task.IsSuccessfullyCompleted)
                    {
                        if (list is IncrementalList<DtoType> l)
                        {
                            var items = task.Result as IEnumerable<DtoType>;
                            l.LoadItems(items);
                            currentList = l;
                        }
                    }
                }

            });
            return currentList as IncrementalList<DtoType>;
        }

        // do just a single funcion with generics.

        private async Task<object> CreateSupplierHelper()
        {
            var supplierDataServices = _dataServices.GetSupplierDataServices();
            var page = await supplierDataServices.GetPagedSummaryDoAsync(1, DefaultPage).ConfigureAwait(false);
            var count = await _helperDataServices.GetItemsCount<PROVEE1>().ConfigureAwait(false);
            currentHelper = new IncrementalList<SupplierSummaryDto>(LoadMoreSuppliers) { MaxItemCount = count };
            if (currentHelper is IncrementalList<SupplierSummaryDto> summary)
            {
                summary.LoadItems(page);
            }
            return currentHelper;

        }
        private async Task<object> CreateBrokerHelper()
        {
            var commissionAgent = _dataServices.GetCommissionAgentDataServices();
            var page = await commissionAgent.GetPagedSummaryDoAsync(1, DefaultPage).ConfigureAwait(false);
            var count = await _helperDataServices.GetItemsCount<COMISIO>().ConfigureAwait(false);
            currentHelper = new IncrementalList<CommissionAgentSummaryDto>(LoadMoreBrokers) { MaxItemCount = count };
            if (currentHelper is IncrementalList<CommissionAgentSummaryDto> summary)
            {
                summary.LoadItems(page);
            }
            return currentHelper;
        }
        private async Task<object> CreateVehicleHelper()
        {
            var vehicleDataServices = _dataServices.GetVehicleDataServices();
            var page = await vehicleDataServices.GetPagedSummaryDoAsync(1, DefaultPage).ConfigureAwait(false);
            var count = await _helperDataServices.GetItemsCount<VEHICULO1>().ConfigureAwait(false);
            currentHelper = new IncrementalList<VehicleSummaryDto>(LoadMoreVehicles) { MaxItemCount = count };
            if (currentHelper is IncrementalList<VehicleSummaryDto> summary)
            {
                summary.LoadItems(page);
            }
            return currentHelper;
        }

        private void LoadMoreVehicles(uint arg1, int arg2)
        {
            var vehicleDataServices = _dataServices.GetVehicleDataServices();

            var creation = NotifyTaskCompletion.Create<IEnumerable<VehicleSummaryDto>>(vehicleDataServices.GetPagedSummaryDoAsync(arg2, DefaultPage), (sender, ev) =>
            {
                if (sender is INotifyTaskCompletion<IEnumerable<VehicleSummaryDto>> task)
                {
                    if (task.IsSuccessfullyCompleted)
                    {
                        if (currentHelper is IncrementalList<VehicleSummaryDto> list)
                        {
                            list.LoadItems(task.Result);
                            currentHelper = list;
                        }
                    }
                }

            });

        }

        private void LoadMoreSuppliers(uint arg1, int arg2)
        {
            var supplierDataServices = _dataServices.GetSupplierDataServices();

            var creation = NotifyTaskCompletion.Create<IEnumerable<SupplierSummaryDto>>(supplierDataServices.GetPagedSummaryDoAsync(arg2, DefaultPage), (sender, ev) =>
            {
                if (sender is INotifyTaskCompletion<IEnumerable<SupplierSummaryDto>> task)
                {
                    if (task.IsSuccessfullyCompleted)
                    {
                        if (currentHelper is IncrementalList<SupplierSummaryDto> list)
                        {
                            list.LoadItems(task.Result);
                            currentHelper = list;
                        }
                    }
                }

            });

        }
        private List<MonthsDto> fillMonths()
        {
            var months = DateTimeFormatInfo.CurrentInfo.MonthNames;
            var index = 0;
            var monthsList = new List<MonthsDto>();
            foreach (var month in months)
            {
                var m = new MonthsDto() { NUMERO_MES = index++, MES = month };
                m.Code = m.NUMERO_MES.ToString();
                monthsList.Add(m);
            }
            return monthsList;
        }
        private void LoadMoreBrokers(uint arg1, int arg2)
        {
            var commissionAgent = _dataServices.GetCommissionAgentDataServices();
            var creation = NotifyTaskCompletion.Create<IEnumerable<CommissionAgentSummaryDto>>(commissionAgent.GetPagedSummaryDoAsync(arg2, DefaultPage), (sender, ev) =>
            {
                if (sender is INotifyTaskCompletion<IEnumerable<CommissionAgentSummaryDto>> task)
                {
                    if (task.IsSuccessfullyCompleted)
                    {
                        if (currentHelper is IncrementalList<CommissionAgentSummaryDto> list)
                        {
                            list.LoadItems(task.Result);
                            currentHelper = list;
                        }
                    }
                }

            });
        }
        /// <summary>
        /// Create a generic helper for summary domain object, i.e ClientSummaryExtended, BookingSummaryExtended
        /// </summary>
        /// <typeparam name="Entity">Entity to be used.</typeparam>
        /// <typeparam name="Domain">Domain to be used.</typeparam>
        /// <typeparam name="SummaryDto">Summary object to be used.</typeparam>
        /// <param name="dataProvider">Data service provider for loading data</param>
        /// <param name="loadMoreItemFunc">Function to be used for loading more items.</param>
        /// <returns> An incremental list of items loaded up to DefaultPage</returns>
        private async Task<object> CreateComplexHelper<Entity, Domain, SummaryDto>(IDataProvider<Domain, SummaryDto> dataProvider, Action<uint, int> loadMoreItemsFunc)
        {
            var page = await dataProvider.GetPagedSummaryDoAsync(1, DefaultPage).ConfigureAwait(false);
            var count = await _helperDataServices.GetItemsCount<Entity>().ConfigureAwait(false);
            currentHelper = new IncrementalList<SummaryDto>(LoadMoreClients) { MaxItemCount = count };
            if (currentHelper is IncrementalList<SummaryDto> summary)
            {
                summary.LoadItems(page);
            }
            return currentHelper;
        }
        /// <summary>
        ///  
        /// </summary>
        /// <returns>An incremental list of items loaded up to defaultPage</returns>
        private async Task<object> CreateClientHelper()
        {
            var clientDataService = _dataServices.GetClientDataServices();
            var page = await clientDataService.GetPagedSummaryDoAsync(1, DefaultPage).ConfigureAwait(false);
            var count = await _helperDataServices.GetItemsCount<CLIENTES1>();
            currentHelper = new IncrementalList<ClientSummaryExtended>(LoadMoreClients) { MaxItemCount = count };
            if (currentHelper is IncrementalList<ClientSummaryExtended> summary)
            {
                summary.LoadItems(page);
            }
            return currentHelper;
        }
        private async Task<object> CreateInvoicesHelper()
        {
            var invoicesDataService = _dataServices.GetInvoiceDataServices();
            var page = await invoicesDataService.GetPagedSummaryDoAsync(1, DefaultPage).ConfigureAwait(false);
            var count = await _helperDataServices.GetItemsCount<FACTURAS>();
            currentHelper = new IncrementalList<InvoiceSummaryValueDto>(LoadMoreInvoices) { MaxItemCount = count };
            if (currentHelper is IncrementalList<InvoiceSummaryValueDto> summary)
            {
                summary.LoadItems(page);
            }
            return currentHelper;
        }
        private async void LoadMoreInvoices(uint arg1, int index)
        {
            var invoicesDataService = _dataServices.GetInvoiceDataServices();
            if (currentHelper is IncrementalList<InvoiceSummaryValueDto> extended)
            {
                var page = await invoicesDataService.GetPagedSummaryDoAsync(index, DefaultPage).ConfigureAwait(false);
                extended.LoadItems(page);
            }
        }
        private async void LoadMoreClients(uint arg1, int index)
        {
            var clientDataService = _dataServices.GetClientDataServices();
            if (currentHelper is IncrementalList<ClientSummaryExtended> extended)
            {
                var page = await clientDataService.GetPagedSummaryDoAsync(index, DefaultPage).ConfigureAwait(false);
                extended.LoadItems(page);
            }
        }
        private async void LoadMoreBudget(uint arg1, int index)
        {
            var budgetDataService = _dataServices.GetBudgetDataServices();
            if (currentHelper is IncrementalList<BudgetSummaryDto> extended)
            {
                var page = await budgetDataService.GetPagedSummaryDoAsync(index, DefaultPage).ConfigureAwait(false);
                extended.LoadItems(page);
            }

        }


        private async Task<object> CreateAssistByQuery<Dto, Entity>(string query) where Dto : BaseDto, new() where Entity : class
        {
            if (string.IsNullOrEmpty(query))
                return null;
            Dto helper = Activator.CreateInstance<Dto>();

            var helperData = _dataServices.GetHelperDataServices();
            // code query 
            if (!string.IsNullOrEmpty(query))
            {
                string[] values = query.Split('=');
                if (values.Length == 2)
                {
                    var code = values[0].Trim();
                    var fieldValue = values[1].Trim();
                    try
                    {
                        helper = await helperData.GetSingleMappedAsyncHelper<Dto, Entity>(fieldValue).ConfigureAwait(false);
                    }
                    catch (System.Exception ex)
                    {
                        throw new AssistDataException("Assist DataService Exception", ex);

                    }
                    var list = new List<Dto>();
                    list.Add(helper);
                    return list;
                }
            }
            return null;
        }
        /// <summary>
        ///  This configure the standard mapper to answer query to answer questions.
        ///  We associate a single lambda foreach assist tag.
        /// </summary>
        private void ConfigureAssist()
        {

            _assistMapper.Configure("ACCOUNT_ACCUMULATED_REPAYMENT", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<AccountDto, CU1>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<AccountDto, CU1>(_dataServices, LoadMoreAccounts).ConfigureAwait(false);

                }
                return currentHelper;
            });
            _assistMapper.Configure("ACCOUNT_INMOVILIZADO", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<AccountDto, CU1>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<AccountDto, CU1>(_dataServices, LoadMoreAccounts).ConfigureAwait(false);
                }
                return currentHelper;

            });
            _assistMapper.Configure("ACCOUNT_PAYMENT_ACCOUNT", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<AccountDto, CU1>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<AccountDto, CU1>(_dataServices, LoadMoreAccounts).ConfigureAwait(false);
                }
                return currentHelper;

            });
            _assistMapper.Configure("ACCOUNT_PREVIUOS_PAYMENT", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<AccountDto, CU1>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<AccountDto, CU1>(_dataServices, LoadMoreAccounts).ConfigureAwait(false);
                }
                return currentHelper;

            });
            _assistMapper.Configure("ACTIVITY_ASSIST", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<ActividadDto, ACTIVI>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<ActividadDto, ACTIVI>(_dataServices, LoadMoreActivities).ConfigureAwait(false);
                }
                return currentHelper;
            });
            _assistMapper.Configure("AGENTES", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<AgentDto, AGENTES>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<AgentDto, AGENTES>(_dataServices, LoadMoreAgents);
                }
                return currentHelper;
            });
            _assistMapper.Configure("ACTIVEHI", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<ActividadDto, ACTIVEHI>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<ActividadDto, ACTIVEHI>(_dataServices, LoadMoreActivities);
                }
                return currentHelper;
            });
            _assistMapper.Configure("ASSURANCE", async (query) =>
            {
                var supplierHelper = await CreateSupplierHelper().ConfigureAwait(false);
                currentHelper = supplierHelper;
                return currentHelper;
            });
            _assistMapper.Configure("ASSURANCE_1", async (query) =>
            {
                var supplierHelper = await CreateSupplierHelper().ConfigureAwait(false);
                currentHelper = supplierHelper;
                return currentHelper;
            });
            _assistMapper.Configure("ASSURANCE_2", async (query) =>
            {
                var supplierHelper = await CreateSupplierHelper().ConfigureAwait(false);
                currentHelper = supplierHelper;
                return currentHelper;
            });
            _assistMapper.Configure("ASSURANCE_3", async (query) =>
            {
                var supplierHelper = await CreateSupplierHelper().ConfigureAwait(false);
                currentHelper = supplierHelper;
                return currentHelper;
            });

            _assistMapper.Configure("ASSURANCE_AGENT", async (query) =>
            {
                var supplierHelper = await CreateSupplierHelper().ConfigureAwait(false);
                currentHelper = supplierHelper;
                return currentHelper;
            });
            _assistMapper.Configure("BANCO", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<BanksDto, BANCO>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<BanksDto, BANCO>(_dataServices, LoadMoreBanks).ConfigureAwait(false);
                }
                return currentHelper;
            });
            _assistMapper.Configure("BOOKING_MEDIO_ASSIST", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<BookingMediaDto, MEDIO_RES>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<BookingMediaDto, MEDIO_RES>(_dataServices, LoadMoreBookingMedia).ConfigureAwait(false);
                }
                return currentHelper;
            });
            _assistMapper.Configure("BOOKING_ORIGIN_ASSIST", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<OrigenDto, ORIGEN>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<OrigenDto, ORIGEN>(_dataServices, LoadMoreOrigin).ConfigureAwait(false);
                }
                return currentHelper;
            });
            _assistMapper.Configure("BOOKING_TYPE_ASSIST", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<BookingTypeDto, TIPOS_RESERVAS>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<BookingTypeDto, TIPOS_RESERVAS>(_dataServices, LoadMoreBookingType).ConfigureAwait(false);
                }
                return currentHelper;
            });
            _assistMapper.Configure("EMPLEAGE_ASSIST", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<AgencyEmployeeDto, EAGE>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<AgencyEmployeeDto, EAGE>(_dataServices, LoadMoreBookingType).ConfigureAwait(false);
                }
                return currentHelper;
            });
            _assistMapper.Configure("BOOKING_FCOBRO_ASSIST", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<PaymentFormDto, FORMAS>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<PaymentFormDto, FORMAS>(_dataServices, LoadMoreBookingType).ConfigureAwait(false);
                }
                return currentHelper;
            });
            _assistMapper.Configure("BOOKING_CONTRATIPIMPR_ASSIST", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<PrintingTypeDto, CONTRATIPIMPR>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<PrintingTypeDto, CONTRATIPIMPR>(_dataServices, LoadMoreBookingType).ConfigureAwait(false);
                }
                return currentHelper;
            });
            _assistMapper.Configure("BOOKING_ACTIVEHI_RES1_ASSIST", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<VehicleActivitiesDto, ACTIVEHI>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<VehicleActivitiesDto, ACTIVEHI>(_dataServices, LoadMoreBookingType).ConfigureAwait(false);
                }
                return currentHelper;
            });
            _assistMapper.Configure("BROKER_ASSIST", async (query) =>
            {

                currentHelper = await CreateBrokerHelper().ConfigureAwait(false);
                return currentHelper;
            });
            _assistMapper.Configure("BUDGET_ASSIST", async (query) =>
            {
                var currentHelper = await CreateBudgetHelper().ConfigureAwait(false);
                return currentHelper;
            });
            _assistMapper.Configure("BUSINESS_ASSIST", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<BusinessDto, NEGOCIO>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<BusinessDto, NEGOCIO>(_dataServices, LoadMoreBusiness).ConfigureAwait(false);
                }
                return currentHelper;
            });
            _assistMapper.Configure("CITY_ASSIST", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<CityDto, POBLACIONES>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<CityDto, POBLACIONES>(_dataServices, LoadMoreCities).ConfigureAwait(false);
                }
                return currentHelper;

            });
            _assistMapper.Configure("CITY_ASSIST_2", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<CityDto, POBLACIONES>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<CityDto, POBLACIONES>(_dataServices, LoadMoreCities).ConfigureAwait(false);
                }
                return currentHelper;

            });
            _assistMapper.Configure("CITY_ASSIST_3", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<CityDto, POBLACIONES>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<CityDto, POBLACIONES>(_dataServices, LoadMoreCities).ConfigureAwait(false);
                }
                return currentHelper;

            });
            _assistMapper.Configure("CLIENT_ASSIST_COMI", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<ClientDto, CLIENTES1>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<ClientDto, CLIENTES1>(_dataServices, LoadMoreActivities).ConfigureAwait(false);
                }
                return currentHelper;
            });
            _assistMapper.Configure("CLIENT_PAYMENT_FORM", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<PaymentFormDto, FORMAS>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<PaymentFormDto, FORMAS>(_dataServices, LoadClientPaymentForm).ConfigureAwait(false);
                }
                return currentHelper;
            });
            _assistMapper.Configure("CLIENT_ZONE", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<ClientZoneDto, ZONAS>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<ClientZoneDto, ZONAS>(_dataServices, LoadClientZones).ConfigureAwait(false);
                }
                return currentHelper;
            });
            _assistMapper.Configure("CLIENT_INVOICE_BLOCKS", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<InvoiceBlockDto, BLOQUEFAC>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<InvoiceBlockDto, BLOQUEFAC>(_dataServices, LoadClientInvoicesBlock).ConfigureAwait(false);
                }
                return currentHelper;
            });
            _assistMapper.Configure("CLIENT_BROKER", async (query) =>
            {
                currentHelper = await CreateBrokerHelper().ConfigureAwait(false);

                return currentHelper;
            });
            _assistMapper.Configure("CLIENT_TYPE", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<ClientTypeDto, TIPOCLI>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {

                    currentHelper = await CreateAssistThroughHelper<ClientTypeDto, TIPOCLI>(_dataServices, LoadMoreClientType).ConfigureAwait(false);
                }
                return currentHelper;
            });
            _assistMapper.Configure("CLIENT_TYPE_ASSIST", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<ClientTypeDto, TIPOCLI>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<ClientTypeDto, TIPOCLI>(_dataServices, LoadMoreClientType).ConfigureAwait(false);

                }
                return currentHelper;
            });
            _assistMapper.Configure("CLIENT_TYPE_UPPER", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<ClientTypeDto, TIPOCLI>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<ClientTypeDto, TIPOCLI>(_dataServices, LoadMoreClientType).ConfigureAwait(false);
                }
                return currentHelper;
            });
            _assistMapper.Configure("COMPANY_ASSIST", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<CompanyDto, SUBLICEN>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<CompanyDto, SUBLICEN>(_dataServices, LoadMoreCompanies).ConfigureAwait(false);

                }
                return currentHelper;
            });

            _assistMapper.Configure("CONTABLE_DELEGA_ASSIST", async (query) =>
            {

                currentHelper = await CreateAssistByQuery<DelegaContableDto, DELEGA>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<DelegaContableDto, DELEGA>(_dataServices, LoadMoreContableDelega).ConfigureAwait(false);
                }
                return currentHelper;
            });
            _assistMapper.Configure("COUNTRY_ASSIST", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<CountryDto, Country>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {

                    currentHelper = await CreateAssistThroughHelper<CountryDto, Country>(_dataServices, LoadMoreCountries).ConfigureAwait(false);

                }
                return currentHelper;
            });
            _assistMapper.Configure("COUNTRY_ASSIST_2", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<CountryDto, Country>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {

                    currentHelper = await CreateAssistThroughHelper<CountryDto, Country>(_dataServices, LoadMoreCountries).ConfigureAwait(false);

                }
                return currentHelper;
            });
            _assistMapper.Configure("COUNTRY_ASSIST_3", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<CountryDto, Country>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {

                    currentHelper = await CreateAssistThroughHelper<CountryDto, Country>(_dataServices, LoadMoreCountries).ConfigureAwait(false);

                }
                return currentHelper;
            });
            _assistMapper.Configure("COUNTRY_ASSIST_4", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<CountryDto, Country>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {

                    currentHelper = await CreateAssistThroughHelper<CountryDto, Country>(_dataServices, LoadMoreCountries).ConfigureAwait(false);

                }
                return currentHelper;
            });
            _assistMapper.Configure("CU1", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<AccountDto, CU1>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<AccountDto, CU1>(_dataServices, LoadMoreAccounts).ConfigureAwait(false);
                }
                return currentHelper;

            });
            _assistMapper.Configure("CU1CP", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<AccountDto, CU1>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<AccountDto, CU1>(_dataServices, LoadMoreAccounts).ConfigureAwait(false);
                }
                return currentHelper;

            });
            _assistMapper.Configure("CRM_PROVIDER_ASSIST", async (query) =>
            {
                var currentHelper = await CreateSupplierHelper().ConfigureAwait(false);
                return currentHelper;
            });
            _assistMapper.Configure("CU1LP", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<AccountDto, CU1>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<AccountDto, CU1>(_dataServices, LoadMoreAccounts).ConfigureAwait(false);
                }
                return currentHelper;

            });
            _assistMapper.Configure("CU1Gasto", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<AccountDto, CU1>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<AccountDto, CU1>(_dataServices, LoadMoreAccounts).ConfigureAwait(false);
                }
                return currentHelper;

            });
            _assistMapper.Configure("CU1Pago", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<AccountDto, CU1>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {

                    currentHelper = await CreateAssistThroughHelper<AccountDto, CU1>(_dataServices, LoadMoreAccounts).ConfigureAwait(false);
                }
                return currentHelper;

            });
            _assistMapper.Configure("CU1Reper", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<AccountDto, CU1>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {

                    currentHelper = await CreateAssistThroughHelper<AccountDto, CU1>(_dataServices, LoadMoreAccounts).ConfigureAwait(false);
                }
                return currentHelper;

            });
            _assistMapper.Configure("CU1Intraco", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<AccountDto, CU1>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {

                    currentHelper = await CreateAssistThroughHelper<AccountDto, CU1>(_dataServices, LoadMoreAccounts).ConfigureAwait(false);
                }
                return currentHelper;

            });
            _assistMapper.Configure("CU1Retencion", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<AccountDto, CU1>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {

                    currentHelper = await CreateAssistThroughHelper<AccountDto, CU1>(_dataServices, LoadMoreAccounts).ConfigureAwait(false);
                }
                return currentHelper;

            });
            _assistMapper.Configure("CURRENCY_ASSIST", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<CurrenciesDto, CURRENCIES>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<CurrenciesDto, CURRENCIES>(_dataServices, LoadCurrencies).ConfigureAwait(false);
                }
                return currentHelper;
            });

            _assistMapper.Configure("DRIVER_CITY", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<CityDto, POBLACIONES>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<CityDto, POBLACIONES>(_dataServices, LoadMoreCities).ConfigureAwait(false);
                }
                return currentHelper;

            });
            _assistMapper.Configure("DRIVER_COUNTRY", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<CountryDto, Country>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {

                    currentHelper = await CreateAssistThroughHelper<CountryDto, Country>(_dataServices, LoadMoreCountries).ConfigureAwait(false);

                }
                return currentHelper;
            });

            _assistMapper.Configure("DIVISAS", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<CurrencyDto, DIVISAS>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {

                    currentHelper = await CreateAssistThroughHelper<CurrencyDto, DIVISAS>(_dataServices, LoadDivisas);
                }
                return currentHelper;
            });
            _assistMapper.Configure("FARE_CONCEPT_ASSIST", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<FareConceptDto, CONCEP_FACTUR>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<FareConceptDto, CONCEP_FACTUR>(_dataServices, LoadMoreBanks).ConfigureAwait(false);
                }
                return currentHelper;
            });
            _assistMapper.Configure("FORMAS_PEDENT", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<DeliveringFormDto, FORMAS_PEDENT>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {

                    currentHelper = await CreateAssistThroughHelper<DeliveringFormDto, FORMAS_PEDENT>(_dataServices, LoadFormasPedent);
                }
                return currentHelper;
            });
            _assistMapper.Configure("FORMAS", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<PaymentFormDto, FORMAS>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<PaymentFormDto, FORMAS>(_dataServices, LoadFormas);
                }
                return currentHelper;
            });
            _assistMapper.Configure("LANGUAGE_ASSIST", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<LanguageDto, IDIOMAS>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {

                    currentHelper = await CreateAssistThroughHelper<LanguageDto, IDIOMAS>(_dataServices, LoadLanguage);
                }
                return currentHelper;
            });

            _assistMapper.Configure("PROVINCE_ASSIST", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<ProvinciaDto, PROVINCIA>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<ProvinciaDto, PROVINCIA>(_dataServices, LoadProvincia);
                }
                return currentHelper;
            });

            _assistMapper.Configure("PROVINCE_ASSIST_2", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<ProvinciaDto, PROVINCIA>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<ProvinciaDto, PROVINCIA>(_dataServices, LoadProvincia);
                }
                return currentHelper;
            });
            _assistMapper.Configure("PROVINCE_ASSIST_3", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<ProvinciaDto, PROVINCIA>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<ProvinciaDto, PROVINCIA>(_dataServices, LoadProvincia);
                }
                return currentHelper;
            });
            _assistMapper.Configure("PROVINCIA", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<ProvinciaDto, PROVINCIA>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {

                    currentHelper = await CreateAssistThroughHelper<ProvinciaDto, PROVINCIA>(_dataServices, LoadProvincia);
                }
                return currentHelper;

            });
            _assistMapper.Configure("PROMOTION_ASSIST", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<PromotionCodesDto, CODIGOS_PROMOCIONALES>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {

                    currentHelper = await CreateAssistThroughHelper<PromotionCodesDto, CODIGOS_PROMOCIONALES>(_dataServices, LoadPromoCodes);
                }
                return currentHelper;
            });
           
            _assistMapper.Configure("DRIVER_PROV", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<ProvinciaDto, PROVINCIA>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {

                    currentHelper = await CreateAssistThroughHelper<ProvinciaDto, PROVINCIA>(_dataServices, LoadProvincia);
                }
                return currentHelper;
            });
            _assistMapper.Configure("PROVINCE_BRANCHES", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<ProvinciaDto, PROVINCIA>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {

                    currentHelper = await CreateAssistThroughHelper<ProvinciaDto, PROVINCIA>(_dataServices, LoadProvincia);
                }
                return currentHelper;
            });
            _assistMapper.Configure("PROV_PAGO", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<ProvinciaDto, PROVINCIA>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<ProvinciaDto, PROVINCIA>(_dataServices, LoadProvincia);
                }
                return currentHelper;
            });
            _assistMapper.Configure("PROV_RECL", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<ProvinciaDto, PROVINCIA>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {

                    currentHelper = await CreateAssistThroughHelper<ProvinciaDto, PROVINCIA>(_dataServices, LoadProvincia);
                }
                return currentHelper;
            });

            _assistMapper.Configure("MESES", async (query)=>
            {
                currentHelper = fillMonths();
                await Task.Delay(1);
                return currentHelper;
            });
            _assistMapper.Configure("MESES2", async (query)=>
            {
                currentHelper = fillMonths();
                await Task.Delay(1);
                return currentHelper;
            });
           
            _assistMapper.Configure("PROV_DEVO", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<ProvinciaDto, PROVINCIA>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<ProvinciaDto, PROVINCIA>(_dataServices, LoadProvincia);
                }
                return currentHelper;
            });
            _assistMapper.Configure("PAIS_PAGO", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<CountryDto, Country>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {

                    currentHelper = await CreateAssistThroughHelper<CountryDto, Country>(_dataServices, LoadCountry);
                }
                return currentHelper;
            });

            _assistMapper.Configure("PAIS_DEVO", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<CountryDto, Country>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {

                    currentHelper = await CreateAssistThroughHelper<CountryDto, Country>(_dataServices, LoadCountry);
                }
                return currentHelper;

            });
            _assistMapper.Configure("PAIS_RECL", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<CountryDto, Country>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<CountryDto, Country>(_dataServices, LoadCountry);
                }
                return currentHelper;

            });
            _assistMapper.Configure("PAIS", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<CountryDto, Country>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {

                    currentHelper = await CreateAssistThroughHelper<CountryDto, Country>(_dataServices, LoadCountry);
                }
                return currentHelper;
            });
            _assistMapper.Configure("POBLACIONES_PAGO", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<CityDto, POBLACIONES>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {

                    currentHelper = await CreateAssistThroughHelper<CityDto, POBLACIONES>(_dataServices, LoadMoreCities);
                }
                return currentHelper;
            });
            _assistMapper.Configure("POBLACIONES_DEVO", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<CityDto, POBLACIONES>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {

                    currentHelper = await CreateAssistThroughHelper<CityDto, POBLACIONES>(_dataServices, LoadMoreCities);
                }
                return currentHelper;
            });
            _assistMapper.Configure("POBLACIONES_RECL", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<CityDto, POBLACIONES>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {

                    currentHelper = await CreateAssistThroughHelper<CityDto, POBLACIONES>(_dataServices, LoadMoreCities);
                }
                return currentHelper;
            });
            _assistMapper.Configure("POBLACIONES", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<CityDto, POBLACIONES>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {

                    currentHelper = await CreateAssistThroughHelper<CityDto, POBLACIONES>(_dataServices, LoadMoreCities);
                }
                return currentHelper;
            });

            _assistMapper.Configure("IDIOMAS", async (query) =>
            {
                /* there are not more than  6,909  languages, but in europe there are at most 30 languges. no incremental is needed. The default page is at most 500 items
                 */
                currentHelper = await CreateAssistByQuery<LanguageDto, IDIOMAS>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await _helperDataServices.GetPagedSummaryDoAsync<LanguageDto, IDIOMAS>(1, DefaultPage);
                }
                return currentHelper;
            });
            _assistMapper.Configure("OFFICE_ASSIST", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<OfficeDtos, OFICINAS>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<OfficeDtos, OFICINAS>(_dataServices, LoadMoreOffices);
                }
                return currentHelper;
            });
            _assistMapper.Configure("OFICINAS", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<OfficeDtos, OFICINAS>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<OfficeDtos, OFICINAS>(_dataServices, LoadMoreOffices);
                }
                return currentHelper;
            });
            _assistMapper.Configure("OFICINA1", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<OfficeDtos, OFICINAS>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<OfficeDtos, OFICINAS>(_dataServices, LoadMoreOffices);
                }
                return currentHelper;

            });
            _assistMapper.Configure("OFICINA2", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<OfficeDtos, OFICINAS>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<OfficeDtos, OFICINAS>(_dataServices, LoadMoreOffices);
                }
                return currentHelper;
            });
            _assistMapper.Configure("ORIGIN_ASSIST", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<OrigenDto, ORIGEN>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {

                    currentHelper = await CreateAssistThroughHelper<OrigenDto, ORIGEN>(_dataServices, LoadMoreOrigin).ConfigureAwait(false);
                }
                return currentHelper;
            });
            _assistMapper.Configure("MARKET_ASSIST", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<MercadoDto, MERCADO>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {

                    currentHelper = await CreateAssistThroughHelper<MercadoDto, MERCADO>(_dataServices, LoadMoreMarkets).ConfigureAwait(false);
                }
                return currentHelper;
            });
            _assistMapper.Configure("BOOKING_CONTACTO_ASSIST", async (query) =>
            {
                currentHelper = await CreateBookingContactsHelperAsync(query).ConfigureAwait(false);
                return currentHelper;

            });
            _assistMapper.Configure("RESELLER_ASSIST", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<ResellerDto, VENDEDOR>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<ResellerDto, VENDEDOR>(_dataServices, LoadMoreReseller).ConfigureAwait(false);
                }
                return currentHelper;
            });
            _assistMapper.Configure("VENDEDOR", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<ResellerDto, VENDEDOR>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {

                    currentHelper = await CreateAssistThroughHelper<ResellerDto, VENDEDOR>(_dataServices, LoadMoreReseller).ConfigureAwait(false);
                }
                return currentHelper;
            });
            _assistMapper.Configure("SUBLICEN", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<CompanyDto, SUBLICEN>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<CompanyDto, SUBLICEN>(_dataServices, LoadMoreCompanies).ConfigureAwait(false);
                }
                return currentHelper;
            });

            _assistMapper.Configure("RENT_USAGE_ASSIST", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<RentingUseDto, USO_ALQUILER>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<RentingUseDto, USO_ALQUILER>(_dataServices, LoadMoreRentingUse).ConfigureAwait(false);
                }
                return currentHelper;
            });
            _assistMapper.Configure("OFFICE_ZONE_ASSIST", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<ZonaOfiDto, ZONAOFI>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<ZonaOfiDto, ZONAOFI>(_dataServices, LoadMoreOffices).ConfigureAwait(false);
                }
                return currentHelper;
            });
            _assistMapper.Configure("ROAD_TAXES_ZONAOFI", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<ZonaOfiDto, ZONAOFI>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<ZonaOfiDto, ZONAOFI>(_dataServices, LoadMoreOffices).ConfigureAwait(false);
                }
                return currentHelper;
            });
            _assistMapper.Configure("REQUEST_REASON", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<RequestReasonDto, MOPETI>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<RequestReasonDto, MOPETI>(_dataServices, LoadMoreRequestReason).ConfigureAwait(false);
                }
                return currentHelper;
            });
            _assistMapper.Configure("FARE_ASSIST", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<FareDto, NTARI>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<FareDto, NTARI>(_dataServices, LoadMoreRequestReason).ConfigureAwait(false);
                }
                return currentHelper;
            });
            _assistMapper.Configure("BUDGET_KEY", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<BudgetKeyDto, CLAVEPTO>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<BudgetKeyDto, CLAVEPTO>(_dataServices, LoadMoreRequestReason).ConfigureAwait(false);
                }
                return currentHelper;
            });
            _assistMapper.Configure("CHANNEL_TYPE", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<ChannelDto, CANAL>(query as string).ConfigureAwait(false);

                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<ChannelDto, CANAL>(_dataServices, LoadMoreRequestReason).ConfigureAwait(false);
                }
                return currentHelper;
            });
            _assistMapper.Configure("CLIENT_BUDGET", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<BudgetKeyDto, CLAVEPTO>(query as string).ConfigureAwait(false);

                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<BudgetKeyDto, CLAVEPTO>(_dataServices, LoadMoreRequestReason).ConfigureAwait(false);
                }
                return currentHelper;
            });
            _assistMapper.Configure("CREDIT_CARD", async (query) =>
            {
                // in the world there are not more than 10 credi card.
                currentHelper = await _helperDataServices.GetPagedSummaryDoAsync<CreditCardDto, TARCREDI>(1, DefaultPage).ConfigureAwait(false);
                return currentHelper;
            });
            _assistMapper.Configure("CREDIT_CARD_ASSIST", async (query) =>
            {
                // in the world there are not more than 10 credi card.
                currentHelper = await _helperDataServices.GetPagedSummaryDoAsync<CreditCardDto, TARCREDI>(1, DefaultPage).ConfigureAwait(false);
                return currentHelper;
            });
            _assistMapper.Configure("CLIENT_DRIVER", async (query) =>
            {
                currentHelper = await CreateClientHelper().ConfigureAwait(false);
                return currentHelper;
            });
            _assistMapper.Configure("INVOICE_ASSIST", async (query) =>
            {
                currentHelper = await CreateInvoicesHelper().ConfigureAwait(false);
                return currentHelper;
            });
            _assistMapper.Configure("CLIENT_ASSIST", async (query) =>
            {
                currentHelper = await CreateClientHelper().ConfigureAwait(false);
                return currentHelper;
            });
            _assistMapper.Configure("DRIVER_ASSIST_1", async (query) =>
            {
                currentHelper = await CreateClientHelper().ConfigureAwait(false);
                return currentHelper;
            });
            _assistMapper.Configure("DRIVER_ASSIST_2", async (query) =>
            {
                currentHelper = await CreateClientHelper().ConfigureAwait(false);
                return currentHelper;
            });
            _assistMapper.Configure("DRIVER_ASSIST_3", async (query) =>
            {
                currentHelper = await CreateClientHelper().ConfigureAwait(false);
                return currentHelper;
            });
            _assistMapper.Configure("DRIVER_ASSIST_4", async (query) =>
            {
                currentHelper = await CreateClientHelper().ConfigureAwait(false);
                return currentHelper;
            });
            _assistMapper.Configure("DRIVER_ASSIST_5", async (query) =>
            {
                currentHelper = await CreateClientHelper().ConfigureAwait(false);
                return currentHelper;
            });
            _assistMapper.Configure("CLIENTES1", async (query) =>
            {
                currentHelper = await CreateClientHelper().ConfigureAwait(false);
                return currentHelper;
            });
            _assistMapper.Configure("VEHICLE_ASSIST", async (query) =>
            {
                currentHelper = await CreateVehicleHelper().ConfigureAwait(false);
                return currentHelper;
            });
            _assistMapper.Configure("ACTIVE_FARE_ASSIST", async (query) =>
            {
                if (query is Dictionary<string, object> context)
                {
                    currentHelper = await CreateActiveFareAssist(context);
                }
                // in any case should i throw an exception here?
                return currentHelper;

            });
            _assistMapper.Configure("CONTRACT_CLIENT_ASSIST", async (query) =>
            {
                var contractDataServices = _dataServices.GetContractDataServices();

                if (query is Dictionary<string, object> context)
                {
                    if (context.ContainsKey("clientCode"))
                    {
                        _clientFareCode = context["clientCode"] as string;
                    }

                    var contract = await contractDataServices.GetContractByClientAsync(_clientFareCode);
                    currentHelper = contract;
                }
                return currentHelper;
            });
            _assistMapper.Configure("BROKER_ASSIST", async (query) =>
            {
                currentHelper = await CreateBrokerHelper();
                return currentHelper;
            });
            _assistMapper.Configure("TIPOPROVE", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<SupplierTypeDto, TIPOPROVE>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await _helperDataServices.GetPagedSummaryDoAsync<SupplierTypeDto, TIPOPROVE>(1, DefaultPage);
                }
                return currentHelper;
            });
            _assistMapper.Configure("VIASPEDIPRO", async (query) =>
            {
                // the number of deliviering ways is always minor than 500
                currentHelper = await CreateAssistByQuery<DeliveringWayDto, VIASPEDIPRO>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {

                    currentHelper = await _helperDataServices.GetPagedSummaryDoAsync<DeliveringWayDto, VIASPEDIPRO>(1, DefaultPage);
                }
                return currentHelper;
            });
            _assistMapper.Configure("GRUPOS", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<VehicleGroupDto, GRUPOS>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<VehicleGroupDto, GRUPOS>(_dataServices, LoadMoreGroups);
                }
                return currentHelper;
            });
            _assistMapper.Configure("PROPIE", async (query) =>
            {
                currentHelper = await CreateAssistThroughHelper<OwnerDto, PROPIE>(_dataServices, LoadMoreOwners);
                return currentHelper;
            });
            _assistMapper.Configure("PROVEE1", async (query) =>
            {
                var currentHelper = await CreateSupplierHelper().ConfigureAwait(false);
                return currentHelper;
            });
            _assistMapper.Configure("COLORFL", async (query) =>
            {
                currentHelper = await _helperDataServices.GetPagedSummaryDoAsync<ColorDto, COLORFL>(1, DefaultPage).ConfigureAwait(false);
                return currentHelper;
            });
            _assistMapper.Configure("COLORFL", async (query) =>
            {
                currentHelper = await _helperDataServices.GetPagedSummaryDoAsync<ColorDto, COLORFL>(1, DefaultPage).ConfigureAwait(false);
                return currentHelper;
            });
            _assistMapper.Configure("MODELO", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<ModelVehicleDto, MODELO>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<ModelVehicleDto, MODELO>(_dataServices, LoadMoreModels).ConfigureAwait(false);
                }
                return currentHelper;
            });
            _assistMapper.Configure("MARCAS", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<BrandVehicleDto, MARCAS>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<BrandVehicleDto, MARCAS>(_dataServices, LoadMoreModels).ConfigureAwait(false);
                }
                return currentHelper;
            });
            _assistMapper.Configure("GRUPO", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<VehicleGroupDto, GRUPOS>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<VehicleGroupDto, GRUPOS>(_dataServices, LoadMoreGroups).ConfigureAwait(false);
                }
                return currentHelper;
            });
            _assistMapper.Configure("SITUATION", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<CurrentSituationDto, SITUACION>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await _helperDataServices.GetPagedSummaryDoAsync<CurrentSituationDto, SITUACION>(1, DefaultPage).ConfigureAwait(false);
                }
                return currentHelper;
            });
            _assistMapper.Configure("ROAD_TAXES_CITY", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<CityDto, POBLACIONES>(query as string).ConfigureAwait(false);

                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<CityDto, POBLACIONES>(_dataServices, LoadMoreCities).ConfigureAwait(false);

                }
                return currentHelper;
            });
           
            _assistMapper.Configure("PRODUCTS", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<ProductsDto, PRODUCTS>(query as string).ConfigureAwait(false);

                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<ProductsDto, PRODUCTS>(_dataServices, LoadMoreProducts).ConfigureAwait(false);

                }
                return currentHelper;
            });

            _assistMapper.Configure("TIPOCOMI", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<CommissionTypeDto, TIPOCOMI>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await _helperDataServices.GetPagedSummaryDoAsync<CommissionTypeDto, TIPOCOMI>(1, DefaultPage);
                }
                return currentHelper;
            });
            _assistMapper.Configure("TIPOCOMISION", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<CommissionTypeDto, TIPOCOMISION>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await _helperDataServices.GetPagedSummaryDoAsync<CommissionTypeDto, TIPOCOMISION>(1, DefaultPage);
                }
                return currentHelper;
            });
            
            _assistMapper.Configure("PROVEE2", async (query) =>
            {
                var supplierHelper = await CreateSupplierHelper().ConfigureAwait(false);
                currentHelper = supplierHelper;
                return currentHelper;
            });
            _assistMapper.Configure("TL_CONDICION_PRECIO", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<PriceConditionDto, TL_CONDICION_PRECIO>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<PriceConditionDto, TL_CONDICION_PRECIO>(_dataServices, LoadConditionPrice);
                }
                return currentHelper;
            });
            _assistMapper.Configure("VEHICLE_GROUP_ASSIST", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<VehicleGroupDto, GRUPOS>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {

                    currentHelper = await CreateAssistThroughHelper<VehicleGroupDto, GRUPOS>(_dataServices, LoadMoreVehicleGroup);
                }
                return currentHelper;
            });
        }

        private async Task<object> CreateBookingContactsHelperAsync(object query)
        {
            currentHelper = new List<ContactsDto>();
            var currentQuery = query as string;
            if (!string.IsNullOrEmpty(currentQuery))
            {

                _clientCode = currentQuery;
                var dataServices = _dataServices.GetClientDataServices();
                IEnumerable<ContactsDto> contactsByClient = await dataServices.GetPagedContactsByClient(_clientCode, 1, DefaultPage).ConfigureAwait(false);
                var count = await _helperDataServices.GetItemsCount<CliContactos>().ConfigureAwait(false);

                currentHelper = new IncrementalList<ContactsDto>(LoadMoreContactsByClients) { MaxItemCount = count };
                if (currentHelper is IncrementalList<ContactsDto> summary)
                {
                    summary.LoadItems(contactsByClient);
                }
                return currentHelper;
            }
            return currentHelper;
        }

        private void LoadMoreContactsByClients(uint arg1, int arg2)
        {
            var helper = _dataServices.GetHelperDataServices();
            var dataServices = _dataServices.GetClientDataServices();
            var creation = NotifyTaskCompletion.Create<IEnumerable<ContactsDto>>(dataServices.GetPagedContactsByClient(_clientCode, 1, DefaultPage), (sender, ev) =>
            {
                if (sender is INotifyTaskCompletion<IEnumerable<VehicleGroupDto>> task)
                {
                    if (task.IsSuccessfullyCompleted)
                    {
                        if (currentHelper is IncrementalList<VehicleGroupDto> list)
                        {
                            list.LoadItems(task.Result);
                            currentHelper = list;
                        }
                    }
                }
            });
        }
        private async Task<object> CreateBudgetHelper()
        {
            var dataServices = _dataServices.GetBudgetDataServices();
            var page = await dataServices.GetPagedSummaryDoAsync(1, DefaultPage).ConfigureAwait(false);
            var count = await _helperDataServices.GetItemsCount<PRESUP1>().ConfigureAwait(false);
            currentHelper = new IncrementalList<BudgetSummaryDto>(LoadMoreBudget) { MaxItemCount = count };
            if (currentHelper is IncrementalList<BudgetSummaryDto> summary)
            {
                summary.LoadItems(page);
            }
            return currentHelper;
        }

        private void LoadMoreContableDelega(uint arg1, int index)
        {
            LoadMoreData<DelegaContableDto, DELEGA>(index, currentHelper);
        }
        private void LoadMoreProducts(uint arg1, int index)
        {
            LoadMoreData<ProductsDto, PRODUCTS>(index, currentHelper);
        }

        private void LoadMoreGroups(uint arg1, int arg2)
        {
            var helper = _dataServices.GetHelperDataServices();
            var creation = NotifyTaskCompletion.Create<IEnumerable<VehicleGroupDto>>(helper.GetPagedSummaryDoAsync<VehicleGroupDto, GRUPOS>(1, DefaultPage), (sender, ev) =>
            {
                if (sender is INotifyTaskCompletion<IEnumerable<VehicleGroupDto>> task)
                {
                    if (task.IsSuccessfullyCompleted)
                    {
                        if (currentHelper is IncrementalList<VehicleGroupDto> list)
                        {
                            list.LoadItems(task.Result);
                            currentHelper = list;
                        }
                    }
                }

            });
        }

        private void LoadMoreModels(uint arg1, int arg2)
        {
            var helper = _dataServices.GetHelperDataServices();
            var creation = NotifyTaskCompletion.Create<IEnumerable<ModelVehicleDto>>(helper.GetPagedSummaryDoAsync<ModelVehicleDto, MODELO>(1, DefaultPage), (sender, ev) =>
            {
                if (sender is INotifyTaskCompletion<IEnumerable<ModelVehicleDto>> task)
                {
                    if (task.IsSuccessfullyCompleted)
                    {
                        if (currentHelper is IncrementalList<ModelVehicleDto> list)
                        {
                            list.LoadItems(task.Result);
                            currentHelper = list;
                        }
                    }
                }

            });

        }
        private void LoadMoreOwners(uint arg1, int arg2)
        {
            var helper = _dataServices.GetHelperDataServices();
            var creation = NotifyTaskCompletion.Create<IEnumerable<VehicleOwnerDto>>(helper.GetPagedSummaryDoAsync<VehicleOwnerDto, PROPIE>(1, DefaultPage), (sender, ev) =>
            {
                if (sender is INotifyTaskCompletion<IEnumerable<VehicleOwnerDto>> task)
                {
                    if (task.IsSuccessfullyCompleted)
                    {
                        if (currentHelper is IncrementalList<VehicleOwnerDto> list)
                        {
                            list.LoadItems(task.Result);
                            currentHelper = list;
                        }
                    }
                }

            });

        }

        private void LoadMoreVehicleActivities(uint arg1, int arg2)
        {
            var helper = _dataServices.GetHelperDataServices();
            var creation = NotifyTaskCompletion.Create<IEnumerable<VehicleActivitiesDto>>(helper.GetPagedSummaryDoAsync<VehicleActivitiesDto, ACTIVEHI>(1, DefaultPage), (sender, ev) =>
            {
                if (sender is INotifyTaskCompletion<IEnumerable<VehicleActivitiesDto>> task)
                {
                    if (task.IsSuccessfullyCompleted)
                    {
                        if (currentHelper is IncrementalList<VehicleActivitiesDto> list)
                        {
                            list.LoadItems(task.Result);
                            currentHelper = list;
                        }
                    }
                }

            });
        }
        private async Task<object> CreateActiveFareAssist(Dictionary<string, object> context)
        {
            var fareDataServices = _dataServices.GetFareDataServices();
            if (context.ContainsKey("clientCode"))
            {
                _clientFareCode = context["clientCode"] as string;
            }
            var page = await fareDataServices.GetActiveSummaryFarePaged(_clientFareCode, 1, DefaultPage).ConfigureAwait(false);
            var count = await fareDataServices.GetNumberOfActiveFares().ConfigureAwait(false);
            currentHelper = new IncrementalList<ActiveFareDto>(LoadMoreActiveFare) { MaxItemCount = count };
            if (currentHelper is IncrementalList<ActiveFareDto> summary)
            {
                summary.LoadItems(page);
            }
            return currentHelper;
        }

        private void LoadMoreActiveFare(uint arg1, int arg2)
        {
            var fareDataServices = _dataServices.GetFareDataServices();
            var creation = NotifyTaskCompletion.Create<IEnumerable<ActiveFareDto>>(fareDataServices.GetActiveSummaryFarePaged(_clientFareCode, arg2, DefaultPage), (sender, ev) =>
            {
                if (sender is INotifyTaskCompletion<IEnumerable<ActiveFareDto>> task)
                {
                    if (task.IsSuccessfullyCompleted)
                    {
                        if (currentHelper is IncrementalList<ActiveFareDto> list)
                        {
                            list.LoadItems(task.Result);
                            currentHelper = list;
                        }
                    }
                }

            });
        }


        /*
         *  From this point we have the list of incremental handlers.
         */
        private void LoadMoreRentingUse(uint arg1, int index)
        {
            LoadMoreData<RentingUseDto, USO_ALQUILER>(index, currentHelper);
        }

        private void LoadMoreChannels(uint arg1, int index)
        {
            LoadMoreData<ChannelDto, CANAL>(index, currentHelper);
        }

        private void LoadMoreBudgetKey(uint arg1, int index)
        {
            LoadMoreData<BudgetKeyDto, CLAVEPTO>(index, currentHelper);

        }

        private void LoadClientInvoicesBlock(uint arg1, int index)
        {
            LoadMoreData<InvoiceBlockDto, BLOQUEFAC>(index, currentHelper);
        }

        private void LoadClientZones(uint arg1, int index)
        {
            LoadMoreData<ClientZoneDto, ZONAS>(index, currentHelper);

        }

        private void LoadClientPaymentForm(uint arg1, int index)
        {
            LoadMoreData<PaymentFormDto, FORMAS>(index, currentHelper);

        }

        private void LoadMoreAgents(uint arg1, int index)
        {
            LoadMoreData<AgentDto, AGENTES>(index, currentHelper);

        }
        private void LoadMoreActivities(uint arg1, int index)
        {
            LoadMoreData<BudgetKeyDto, CLAVEPTO>(index, currentHelper);

        }

        private void LoadMoreReseller(uint arg1, int index)
        {
            LoadMoreData<BudgetKeyDto, CLAVEPTO>(index, currentHelper);

        }

        private void LoadMoreMarkets(uint arg1, int index)
        {
            LoadMoreData<BudgetKeyDto, CLAVEPTO>(index, currentHelper);
        }

        private void LoadMoreOrigin(uint arg1, int index)
        {
            LoadMoreData<OrigenDto, ORIGEN>(index, currentHelper);

        }

        private void LoadMoreOffices(uint arg1, int index)
        {
            LoadMoreData<OfficeDtos, OFICINAS>(index, currentHelper);

        }

        private void LoadCountry(uint arg1, int index)
        {
            LoadMoreData<CountryDto, Country>(index, currentHelper);

        }

        private void LoadConditionPrice(uint arg1, int index)
        {
            LoadMoreData<PriceConditionDto, TL_CONDICION_PRECIO>(index, currentHelper);

        }



        private void LoadProvincia(uint arg1, int index)
        {
            LoadMoreData<ProvinciaDto, PROVINCIA>(index, currentHelper);

        }

        private void LoadLanguage(uint arg1, int index)
        {
            LoadMoreData<LanguageDto, IDIOMAS>(index, currentHelper);
        }

        private void LoadFormas(uint arg1, int index)
        {
            LoadMoreData<PaymentFormDto, FORMAS>(index, currentHelper);


        }

        private void LoadFormasPedent(uint arg1, int index)
        {
            LoadMoreData<DeliveringFormDto, FORMAS_PEDENT>(index, currentHelper);
        }

        private void LoadDivisas(uint arg1, int index)
        {
            LoadMoreData<CurrenciesDto, DIVISAS>(index, currentHelper);

        }

        private void LoadMoreVehicleGroup(uint arg1, int index)
        {
            LoadMoreData<VehicleGroupDto, GRUPOS>(index, currentHelper);
        }

        private void LoadCurrencies(uint arg1, int index)
        {
            LoadMoreData<CurrenciesDto, CURRENCIES>(index, currentHelper);
        }

        private void LoadMoreAccounts(uint arg1, int index)
        {
            LoadMoreData<AccountDto, CU1>(index, currentHelper);
        }
        private void LoadMoreCompanies(uint arg1, int index)
        {
            LoadMoreData<CompanyDto, SUBLICEN>(index, currentHelper);


        }
        private void LoadMoreCountries(uint arg1, int index)
        {
            LoadMoreData<CountryDto, Country>(index, currentHelper);
        }

        private void LoadMoreCities(uint arg1, int index)
        {
            LoadMoreData<CityDto, POBLACIONES>(index, currentHelper);
        }

        private void LoadMoreRequestReason(uint arg1, int index)
        {
            LoadMoreData<RequestReasonDto, MOPETI>(index, currentHelper);
        }
        private void LoadMoreFares(uint arg1, int index)
        {
            LoadMoreData<FareDto, NTARI>(index, currentHelper);
        }
        private void LoadMoreClientType(uint arg1, int index)
        {
            LoadMoreData<ClientTypeDto, TIPOCLI>(index, currentHelper);
        }
        private void LoadMoreBusiness(uint arg1, int index)
        {
            LoadMoreData<BusinessDto, NEGOCIO>(index, currentHelper);
        }

        private void LoadMoreBanks(uint arg1, int index)
        {
            LoadMoreData<BanksDto, BANCO>(index, currentHelper);
        }

        private void LoadPromoCodes(uint arg1, int index)
        {
            LoadMoreData<PromotionCodesDto, CODIGOS_PROMOCIONALES>(index, currentHelper);

        }
        private void LoadMoreBookingType(uint arg1, int index)
        {
            LoadMoreData<BookingTypeDto, TIPOS_RESERVAS>(index, currentHelper);
        }
        private void LoadMoreBookingMedia(uint arg1, int index)
        {
            LoadMoreData<BookingMediaDto, MEDIO_RES>(index, currentHelper);
        }

    }
}
