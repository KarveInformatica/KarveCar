using DataAccessLayer.DataObjects;
using KarveCommon.Generic;
using KarveDataServices;
using KarveDataServices.ViewObjects;
using Syncfusion.UI.Xaml.Grid;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using System.Globalization;
using KarveDataServices.DataObjects;

namespace DataAccessLayer
{
    /// <summary>
    ///  Assist Data Service is the global service for resolving all searchboxes. 
    ///  It contains a map of a assist. An assist is just a tag. When the user clicks 
    ///  on the searchbox, the custom search box control (DualFieldSearchBox) raise an event
    ///  with an associated dictionary. The conceptual idea here that it does an assist to the viewmodel,
    ///  and the view model should smash the assist providing a new set of result.
    ///  Inside this dictionary there is a tag that it will be passed
    ///  to the assist data service. The resposability of the assist data service is ask to database 
    ///  the set of the paged results that corresponds to that tag.
    ///  The assist data service exposes the map to the world for allowing a custom configuration of the 
    ///  tags.
    /// </summary>
    class AssistDataService : IAssistDataService
    {
        /// <summary>
        ///  Assis mapper / mapeo de las lupas.
        /// </summary>
        private IAssistMapper<BaseViewObject> _assistMapper = new AssistMapper<BaseViewObject>();
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
        public IAssistMapper<BaseViewObject> Mapper
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
        public async Task<object> CreateAssistThroughHelper<DtoType, Entity>(IDataServices dataServices, Action<uint, int> loadAction) where DtoType : BaseViewObject where Entity : class
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
            where DtoType : BaseViewObject
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
           where DtoType : BaseViewObject
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
            currentHelper = new IncrementalList<SupplierSummaryViewObject>(LoadMoreSuppliers) { MaxItemCount = count };
            if (currentHelper is IncrementalList<SupplierSummaryViewObject> summary)
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
            currentHelper = new IncrementalList<CommissionAgentSummaryViewObject>(LoadMoreBrokers) { MaxItemCount = count };
            if (currentHelper is IncrementalList<CommissionAgentSummaryViewObject> summary)
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
            currentHelper = new IncrementalList<VehicleSummaryViewObject>(LoadMoreVehicles) { MaxItemCount = count };
            if (currentHelper is IncrementalList<VehicleSummaryViewObject> summary)
            {
                summary.LoadItems(page);
            }
            return currentHelper;
        }

        private void LoadMoreVehicles(uint arg1, int arg2)
        {
            var vehicleDataServices = _dataServices.GetVehicleDataServices();

            var creation = NotifyTaskCompletion.Create<IEnumerable<VehicleSummaryViewObject>>(vehicleDataServices.GetPagedSummaryDoAsync(arg2, DefaultPage), (sender, ev) =>
            {
                if (sender is INotifyTaskCompletion<IEnumerable<VehicleSummaryViewObject>> task)
                {
                    if (task.IsSuccessfullyCompleted)
                    {
                        if (currentHelper is IncrementalList<VehicleSummaryViewObject> list)
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

            var creation = NotifyTaskCompletion.Create<IEnumerable<SupplierSummaryViewObject>>(supplierDataServices.GetPagedSummaryDoAsync(arg2, DefaultPage), (sender, ev) =>
            {
                if (sender is INotifyTaskCompletion<IEnumerable<SupplierSummaryViewObject>> task)
                {
                    if (task.IsSuccessfullyCompleted)
                    {
                        if (currentHelper is IncrementalList<SupplierSummaryViewObject> list)
                        {
                            list.LoadItems(task.Result);
                            currentHelper = list;
                        }
                    }
                }

            });

        }
        private List<MonthsViewObject> fillMonths()
        {
            var months = DateTimeFormatInfo.CurrentInfo.MonthNames;
            var index = 0;
            var monthsList = new List<MonthsViewObject>();
            foreach (var month in months)
            {
                var m = new MonthsViewObject() { NUMERO_MES = index++, MES = month };
                m.Code = m.NUMERO_MES.ToString();
                monthsList.Add(m);
            }
            return monthsList;
        }
        private void LoadMoreBrokers(uint arg1, int arg2)
        {
            var commissionAgent = _dataServices.GetCommissionAgentDataServices();
            var creation = NotifyTaskCompletion.Create<IEnumerable<CommissionAgentSummaryViewObject>>(commissionAgent.GetPagedSummaryDoAsync(arg2, DefaultPage), (sender, ev) =>
            {
                if (sender is INotifyTaskCompletion<IEnumerable<CommissionAgentSummaryViewObject>> task)
                {
                    if (task.IsSuccessfullyCompleted)
                    {
                        if (currentHelper is IncrementalList<CommissionAgentSummaryViewObject> list)
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
        private async Task<object> CreateComplexHelper<Entity, Domain, SummaryDto>(IDataProvider<Domain, SummaryDto> dataProvider, Action<uint, int> loadMoreItemsFunc) where Entity: class
                                                             where Domain: class
                                                             where SummaryDto: BaseViewObject
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
            currentHelper = new IncrementalList<InvoiceSummaryValueViewObject>(LoadMoreInvoices) { MaxItemCount = count };
            if (currentHelper is IncrementalList<InvoiceSummaryValueViewObject> summary)
            {
                summary.LoadItems(page);
            }
            return currentHelper;
        }
        private async void LoadMoreInvoices(uint arg1, int index)
        {
            var invoicesDataService = _dataServices.GetInvoiceDataServices();
            if (currentHelper is IncrementalList<InvoiceSummaryValueViewObject> extended)
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
            if (currentHelper is IncrementalList<BudgetSummaryViewObject> extended)
            {
                var page = await budgetDataService.GetPagedSummaryDoAsync(index, DefaultPage).ConfigureAwait(false);
                extended.LoadItems(page);
            }

        }


        private async Task<object> CreateAssistByQuery<Dto, Entity>(string query) where Dto : BaseViewObject, new() where Entity : class
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
                    if (!string.IsNullOrEmpty(code) && !string.IsNullOrEmpty(fieldValue))
                    {
                        try
                        {
                            helper = await helperData.GetSingleMappedAsyncHelper<Dto, Entity>(fieldValue).ConfigureAwait(false);
                        }
                        catch (System.Exception ex)
                        {
                            throw new AssistDataException("Assist DataService Exception", ex);

                        }
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
                currentHelper = await CreateAssistByQuery<AccountViewObject, CU1>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<AccountViewObject, CU1>(_dataServices, LoadMoreAccounts).ConfigureAwait(false);

                }
                return currentHelper;
            });
            _assistMapper.Configure("ACCOUNT_INMOVILIZADO", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<AccountViewObject, CU1>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<AccountViewObject, CU1>(_dataServices, LoadMoreAccounts).ConfigureAwait(false);
                }
                return currentHelper;

            });
            _assistMapper.Configure("ACCOUNT_PAYMENT_ACCOUNT", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<AccountViewObject, CU1>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<AccountViewObject, CU1>(_dataServices, LoadMoreAccounts).ConfigureAwait(false);
                }
                return currentHelper;

            });
            _assistMapper.Configure("ACCOUNT_PREVIUOS_PAYMENT", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<AccountViewObject, CU1>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<AccountViewObject, CU1>(_dataServices, LoadMoreAccounts).ConfigureAwait(false);
                }
                return currentHelper;

            });
            _assistMapper.Configure("ACTIVITY_ASSIST", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<ActividadViewObject, ACTIVI>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<ActividadViewObject, ACTIVI>(_dataServices, LoadMoreActivities1).ConfigureAwait(false);
                }
                return currentHelper;
            });
            _assistMapper.Configure("AGENTES", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<AgentViewObject, AGENTES>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<AgentViewObject, AGENTES>(_dataServices, LoadMoreAgents);
                }
                return currentHelper;
            });
            _assistMapper.Configure("ACTIVEHI", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<VehicleActivitiesViewObject, ACTIVEHI>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<VehicleActivitiesViewObject, ACTIVEHI>(_dataServices, LoadMoreActivities2);
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
                currentHelper = await CreateAssistByQuery<BanksViewObject, BANCO>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<BanksViewObject, BANCO>(_dataServices, LoadMoreBanks).ConfigureAwait(false);
                }
                return currentHelper;
            });
            _assistMapper.Configure("BOOKING_CONF_MESSAGE_ASSIST", async (query)=> 
            {
                currentHelper = await _helperDataServices.GetPagedSummaryDoAsync<BookingConfirmMessageViewObject, RESERCONFIRM>(1, DefaultPage).ConfigureAwait(false);
                return currentHelper;
            });
            _assistMapper.Configure("BOOKING_REFUSE_ASSIST", async (query) =>
            {
                // come on we dont need more than 100 refuse motivation. Common sense overall. 
                currentHelper = await _helperDataServices.GetPagedSummaryDoAsync<BookingRefusedViewObject, MOTANU>(1, DefaultPage).ConfigureAwait(false);
                return currentHelper;
            });

            _assistMapper.Configure("BOOKING_INCIDENT_TYPE", async (query) =>
            {
                currentHelper = await _helperDataServices.GetPagedSummaryDoAsync<IncidentTypeViewObject, COINRE>(1, 1000).ConfigureAwait(false);
                return currentHelper;
            });
            _assistMapper.Configure("DELIVERY_PLACE_0", async(query)=>
            {
                currentHelper = await CreateAssistByQuery<DeliveringPlaceViewObject, ENTREGAS>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<DeliveringPlaceViewObject, ENTREGAS>(_dataServices, LoadMorePlaces).ConfigureAwait(false);
                }
                return currentHelper;
            });
            _assistMapper.Configure("DELIVERY_PLACE_1", async (query)=>
            {
                currentHelper = await CreateAssistByQuery<DeliveringPlaceViewObject, ENTREGAS>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper= await CreateAssistThroughHelper<DeliveringPlaceViewObject, ENTREGAS>(_dataServices, LoadMorePlaces).ConfigureAwait(false);
                }
                return currentHelper;
            });
            _assistMapper.Configure("BOOKING_MEDIO_ASSIST", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<BookingMediaViewObject, MEDIO_RES>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<BookingMediaViewObject, MEDIO_RES>(_dataServices, LoadMoreBookingMedia).ConfigureAwait(false);
                }
                return currentHelper;
            });
            _assistMapper.Configure("BOOKING_ORIGIN_ASSIST", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<OrigenViewObject, ORIGEN>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<OrigenViewObject, ORIGEN>(_dataServices, LoadMoreOrigin).ConfigureAwait(false);
                }
                return currentHelper;
            });
            _assistMapper.Configure("BOOKING_TYPE_ASSIST", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<BookingTypeViewObject, TIPOS_RESERVAS>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<BookingTypeViewObject, TIPOS_RESERVAS>(_dataServices, LoadMoreBookingType).ConfigureAwait(false);
                }
                return currentHelper;
            });
            _assistMapper.Configure("EMPLEAGE_ASSIST", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<AgencyEmployeeViewObject, EAGE>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<AgencyEmployeeViewObject, EAGE>(_dataServices, LoadMoreAgencies).ConfigureAwait(false);
                }
                return currentHelper;
            });
            _assistMapper.Configure("BOOKING_FCOBRO_ASSIST", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<PaymentFormViewObject, FORMAS>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<PaymentFormViewObject, FORMAS>(_dataServices, LoadMorePaymentTypes).ConfigureAwait(false);
                }
                return currentHelper;
            });
            _assistMapper.Configure("BOOKING_CONTRATIPIMPR_ASSIST", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<PrintingTypeViewObject, CONTRATIPIMPR>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<PrintingTypeViewObject, CONTRATIPIMPR>(_dataServices, LoadMoreBookingType).ConfigureAwait(false);
                }
                return currentHelper;
            });
            _assistMapper.Configure("BOOKING_ACTIVEHI_RES1_ASSIST", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<VehicleActivitiesViewObject, ACTIVEHI>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<VehicleActivitiesViewObject, ACTIVEHI>(_dataServices, LoadMoreVehicleActivities).ConfigureAwait(false);
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
                currentHelper = await CreateAssistByQuery<BusinessViewObject, NEGOCIO>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<BusinessViewObject, NEGOCIO>(_dataServices, LoadMoreBusiness).ConfigureAwait(false);
                }
                return currentHelper;
            });
            _assistMapper.Configure("CITY_ASSIST", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<CityViewObject, POBLACIONES>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<CityViewObject, POBLACIONES>(_dataServices, LoadMoreCities).ConfigureAwait(false);
                }
                return currentHelper;

            });
            _assistMapper.Configure("CITY_ASSIST_2", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<CityViewObject, POBLACIONES>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<CityViewObject, POBLACIONES>(_dataServices, LoadMoreCities).ConfigureAwait(false);
                }
                return currentHelper;

            });
            _assistMapper.Configure("CITY_ASSIST_3", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<CityViewObject, POBLACIONES>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<CityViewObject, POBLACIONES>(_dataServices, LoadMoreCities).ConfigureAwait(false);
                }
                return currentHelper;

            });
            _assistMapper.Configure("CLIENT_ASSIST_COMI", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<ClientViewObject, CLIENTES1>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<ClientViewObject, CLIENTES1>(_dataServices, LoadMoreClients).ConfigureAwait(false);
                }
                return currentHelper;
            });
            _assistMapper.Configure("CLIENT_PAYMENT_FORM", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<PaymentFormViewObject, FORMAS>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<PaymentFormViewObject, FORMAS>(_dataServices, LoadClientPaymentForm).ConfigureAwait(false);
                }
                return currentHelper;
            });
            _assistMapper.Configure("CLIENT_ZONE", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<ClientZoneViewObject, ZONAS>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<ClientZoneViewObject, ZONAS>(_dataServices, LoadClientZones).ConfigureAwait(false);
                }
                return currentHelper;
            });
            _assistMapper.Configure("CLIENT_INVOICE_BLOCKS", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<InvoiceBlockViewObject, BLOQUEFAC>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<InvoiceBlockViewObject, BLOQUEFAC>(_dataServices, LoadClientInvoicesBlock).ConfigureAwait(false);
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
                currentHelper = await CreateAssistByQuery<ClientTypeViewObject, TIPOCLI>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {

                    currentHelper = await CreateAssistThroughHelper<ClientTypeViewObject, TIPOCLI>(_dataServices, LoadMoreClientType).ConfigureAwait(false);
                }
                return currentHelper;
            });
            _assistMapper.Configure("CLIENT_TYPE_ASSIST", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<ClientTypeViewObject, TIPOCLI>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<ClientTypeViewObject, TIPOCLI>(_dataServices, LoadMoreClientType).ConfigureAwait(false);

                }
                return currentHelper;
            });
            _assistMapper.Configure("CLIENT_TYPE_UPPER", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<ClientTypeViewObject, TIPOCLI>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<ClientTypeViewObject, TIPOCLI>(_dataServices, LoadMoreClientType).ConfigureAwait(false);
                }
                return currentHelper;
            });
            _assistMapper.Configure("COMPANY_ASSIST", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<CompanyViewObject, SUBLICEN>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<CompanyViewObject, SUBLICEN>(_dataServices, LoadMoreCompanies).ConfigureAwait(false);

                }
                return currentHelper;
            });

            _assistMapper.Configure("CONTABLE_DELEGA_ASSIST", async (query) =>
            {

                currentHelper = await CreateAssistByQuery<DelegaContableViewObject, DELEGA>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<DelegaContableViewObject, DELEGA>(_dataServices, LoadMoreContableDelega).ConfigureAwait(false);
                }
                return currentHelper;
            });
            _assistMapper.Configure("COUNTRY_ASSIST", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<CountryViewObject, Country>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {

                    currentHelper = await CreateAssistThroughHelper<CountryViewObject, Country>(_dataServices, LoadMoreCountries).ConfigureAwait(false);

                }
                return currentHelper;
            });
            _assistMapper.Configure("COUNTRY_ASSIST_2", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<CountryViewObject, Country>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {

                    currentHelper = await CreateAssistThroughHelper<CountryViewObject, Country>(_dataServices, LoadMoreCountries).ConfigureAwait(false);

                }
                return currentHelper;
            });
            _assistMapper.Configure("COUNTRY_ASSIST_3", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<CountryViewObject, Country>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {

                    currentHelper = await CreateAssistThroughHelper<CountryViewObject, Country>(_dataServices, LoadMoreCountries).ConfigureAwait(false);

                }
                return currentHelper;
            });
            _assistMapper.Configure("COUNTRY_ASSIST_4", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<CountryViewObject, Country>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {

                    currentHelper = await CreateAssistThroughHelper<CountryViewObject, Country>(_dataServices, LoadMoreCountries).ConfigureAwait(false);

                }
                return currentHelper;
            });
            _assistMapper.Configure("CU1", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<AccountViewObject, CU1>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<AccountViewObject, CU1>(_dataServices, LoadMoreAccounts).ConfigureAwait(false);
                }
                return currentHelper;

            });
            _assistMapper.Configure("CU1CP", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<AccountViewObject, CU1>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<AccountViewObject, CU1>(_dataServices, LoadMoreAccounts).ConfigureAwait(false);
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
                currentHelper = await CreateAssistByQuery<AccountViewObject, CU1>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<AccountViewObject, CU1>(_dataServices, LoadMoreAccounts).ConfigureAwait(false);
                }
                return currentHelper;

            });
            _assistMapper.Configure("CU1Gasto", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<AccountViewObject, CU1>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<AccountViewObject, CU1>(_dataServices, LoadMoreAccounts).ConfigureAwait(false);
                }
                return currentHelper;

            });
            _assistMapper.Configure("CU1Pago", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<AccountViewObject, CU1>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {

                    currentHelper = await CreateAssistThroughHelper<AccountViewObject, CU1>(_dataServices, LoadMoreAccounts).ConfigureAwait(false);
                }
                return currentHelper;

            });
            _assistMapper.Configure("CU1Reper", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<AccountViewObject, CU1>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {

                    currentHelper = await CreateAssistThroughHelper<AccountViewObject, CU1>(_dataServices, LoadMoreAccounts).ConfigureAwait(false);
                }
                return currentHelper;

            });
            _assistMapper.Configure("CU1Intraco", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<AccountViewObject, CU1>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {

                    currentHelper = await CreateAssistThroughHelper<AccountViewObject, CU1>(_dataServices, LoadMoreAccounts).ConfigureAwait(false);
                }
                return currentHelper;

            });
            _assistMapper.Configure("CU1Retencion", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<AccountViewObject, CU1>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {

                    currentHelper = await CreateAssistThroughHelper<AccountViewObject, CU1>(_dataServices, LoadMoreAccounts).ConfigureAwait(false);
                }
                return currentHelper;

            });
            _assistMapper.Configure("CURRENCY_ASSIST", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<CurrenciesViewObject, CURRENCIES>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<CurrenciesViewObject, CURRENCIES>(_dataServices, LoadCurrencies).ConfigureAwait(false);
                }
                return currentHelper;
            });

            _assistMapper.Configure("DRIVER_CITY", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<CityViewObject, POBLACIONES>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<CityViewObject, POBLACIONES>(_dataServices, LoadMoreCities).ConfigureAwait(false);
                }
                return currentHelper;

            });
            _assistMapper.Configure("DRIVER_COUNTRY", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<CountryViewObject, Country>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {

                    currentHelper = await CreateAssistThroughHelper<CountryViewObject, Country>(_dataServices, LoadMoreCountries).ConfigureAwait(false);

                }
                return currentHelper;
            });

            _assistMapper.Configure("DIVISAS", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<CurrencyViewObject, DIVISAS>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {

                    currentHelper = await CreateAssistThroughHelper<CurrencyViewObject, DIVISAS>(_dataServices, LoadDivisas);
                }
                return currentHelper;
            });
            _assistMapper.Configure("FARE_CONCEPT_ASSIST", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<FareConceptViewObject, CONCEP_FACTUR>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<FareConceptViewObject, CONCEP_FACTUR>(_dataServices, LoadMoreBanks).ConfigureAwait(false);
                }
                return currentHelper;
            });
            _assistMapper.Configure("FORMAS_PEDENT", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<DeliveringFormViewObject, FORMAS_PEDENT>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {

                    currentHelper = await CreateAssistThroughHelper<DeliveringFormViewObject, FORMAS_PEDENT>(_dataServices, LoadFormasPedent);
                }
                return currentHelper;
            });
            _assistMapper.Configure("FORMAS", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<PaymentFormViewObject, FORMAS>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<PaymentFormViewObject, FORMAS>(_dataServices, LoadFormas);
                }
                return currentHelper;
            });
            _assistMapper.Configure("LANGUAGE_ASSIST", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<LanguageViewObject, IDIOMAS>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {

                    currentHelper = await CreateAssistThroughHelper<LanguageViewObject, IDIOMAS>(_dataServices, LoadLanguage);
                }
                return currentHelper;
            });

            _assistMapper.Configure("PROVINCE_ASSIST", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<ProvinceViewObject, PROVINCIA>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<ProvinceViewObject, PROVINCIA>(_dataServices, LoadProvincia);
                }
                return currentHelper;
            });

            _assistMapper.Configure("PROVINCE_ASSIST_2", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<ProvinceViewObject, PROVINCIA>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<ProvinceViewObject, PROVINCIA>(_dataServices, LoadProvincia);
                }
                return currentHelper;
            });
            _assistMapper.Configure("PROVINCE_ASSIST_3", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<ProvinceViewObject, PROVINCIA>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<ProvinceViewObject, PROVINCIA>(_dataServices, LoadProvincia);
                }
                return currentHelper;
            });
            _assistMapper.Configure("PROVINCIA", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<ProvinceViewObject, PROVINCIA>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {

                    currentHelper = await CreateAssistThroughHelper<ProvinceViewObject, PROVINCIA>(_dataServices, LoadProvincia);
                }
                return currentHelper;

            });
            _assistMapper.Configure("PROMOTION_ASSIST", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<PromotionCodesViewObject, CODIGOS_PROMOCIONALES>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {

                    currentHelper = await CreateAssistThroughHelper<PromotionCodesViewObject, CODIGOS_PROMOCIONALES>(_dataServices, LoadPromoCodes);
                }
                return currentHelper;
            });
           
            _assistMapper.Configure("DRIVER_PROV", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<ProvinceViewObject, PROVINCIA>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {

                    currentHelper = await CreateAssistThroughHelper<ProvinceViewObject, PROVINCIA>(_dataServices, LoadProvincia);
                }
                return currentHelper;
            });
            _assistMapper.Configure("PROVINCE_BRANCHES", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<ProvinceViewObject, PROVINCIA>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {

                    currentHelper = await CreateAssistThroughHelper<ProvinceViewObject, PROVINCIA>(_dataServices, LoadProvincia);
                }
                return currentHelper;
            });
            _assistMapper.Configure("PROV_PAGO", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<ProvinceViewObject, PROVINCIA>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<ProvinceViewObject, PROVINCIA>(_dataServices, LoadProvincia);
                }
                return currentHelper;
            });
            _assistMapper.Configure("PROV_RECL", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<ProvinceViewObject, PROVINCIA>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {

                    currentHelper = await CreateAssistThroughHelper<ProvinceViewObject, PROVINCIA>(_dataServices, LoadProvincia);
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
                currentHelper = await CreateAssistThroughHelper<ProvinceViewObject, PROVINCIA>(_dataServices, LoadProvincia);
                return currentHelper;
            });
            _assistMapper.Configure("PAIS_PAGO", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<CountryViewObject, Country>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {

                    currentHelper = await CreateAssistThroughHelper<CountryViewObject, Country>(_dataServices, LoadCountry);
                }
                return currentHelper;
            });

            _assistMapper.Configure("PAIS_DEVO", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<CountryViewObject, Country>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {

                    currentHelper = await CreateAssistThroughHelper<CountryViewObject, Country>(_dataServices, LoadCountry);
                }
                return currentHelper;

            });
            _assistMapper.Configure("PAIS_RECL", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<CountryViewObject, Country>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<CountryViewObject, Country>(_dataServices, LoadCountry);
                }
                return currentHelper;

            });
            _assistMapper.Configure("PAIS", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<CountryViewObject, Country>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {

                    currentHelper = await CreateAssistThroughHelper<CountryViewObject, Country>(_dataServices, LoadCountry);
                }
                return currentHelper;
            });
            _assistMapper.Configure("POBLACIONES_PAGO", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<CityViewObject, POBLACIONES>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {

                    currentHelper = await CreateAssistThroughHelper<CityViewObject, POBLACIONES>(_dataServices, LoadMoreCities);
                }
                return currentHelper;
            });
            _assistMapper.Configure("POBLACIONES_DEVO", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<CityViewObject, POBLACIONES>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {

                    currentHelper = await CreateAssistThroughHelper<CityViewObject, POBLACIONES>(_dataServices, LoadMoreCities);
                }
                return currentHelper;
            });
            _assistMapper.Configure("POBLACIONES_RECL", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<CityViewObject, POBLACIONES>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {

                    currentHelper = await CreateAssistThroughHelper<CityViewObject, POBLACIONES>(_dataServices, LoadMoreCities);
                }
                return currentHelper;
            });
            _assistMapper.Configure("POBLACIONES", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<CityViewObject, POBLACIONES>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {

                    currentHelper = await CreateAssistThroughHelper<CityViewObject, POBLACIONES>(_dataServices, LoadMoreCities);
                }
                return currentHelper;
            });

            _assistMapper.Configure("IDIOMAS", async (query) =>
            {
                /* there are not more than  6,909  languages, but in europe there are at most 30 languges. no incremental is needed. The default page is at most 500 items
                 */
                currentHelper = await CreateAssistByQuery<LanguageViewObject, IDIOMAS>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await _helperDataServices.GetPagedSummaryDoAsync<LanguageViewObject, IDIOMAS>(1, DefaultPage);
                }
                return currentHelper;
            });
            _assistMapper.Configure("OFFICE_ASSIST", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<OfficeViewObject, OFICINAS>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<OfficeViewObject, OFICINAS>(_dataServices, LoadMoreOffices);
                }
                return currentHelper;
            });
            _assistMapper.Configure("OFICINAS", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<OfficeViewObject, OFICINAS>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<OfficeViewObject, OFICINAS>(_dataServices, LoadMoreOffices);
                }
                return currentHelper;
            });
            _assistMapper.Configure("OFICINA1", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<OfficeViewObject, OFICINAS>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<OfficeViewObject, OFICINAS>(_dataServices, LoadMoreOffices);
                }
                return currentHelper;

            });
            _assistMapper.Configure("BOOKING_OFFICE_1", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<OfficeViewObject, OFICINAS>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<OfficeViewObject, OFICINAS>(_dataServices, LoadMoreOffices);
                }
                return currentHelper;

            });
            _assistMapper.Configure("BOOKING_OFFICE_2", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<OfficeViewObject, OFICINAS>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<OfficeViewObject, OFICINAS>(_dataServices, LoadMoreOffices);
                }
                return currentHelper;

            });
            _assistMapper.Configure("OFICINA2", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<OfficeViewObject, OFICINAS>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<OfficeViewObject, OFICINAS>(_dataServices, LoadMoreOffices);
                }
                return currentHelper;
            });
            _assistMapper.Configure("ORIGIN_ASSIST", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<OrigenViewObject, ORIGEN>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {

                    currentHelper = await CreateAssistThroughHelper<OrigenViewObject, ORIGEN>(_dataServices, LoadMoreOrigin).ConfigureAwait(false);
                }
                return currentHelper;
            });
            _assistMapper.Configure("MARKET_ASSIST", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<MarketViewObject, MERCADO>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {

                    currentHelper = await CreateAssistThroughHelper<MarketViewObject, MERCADO>(_dataServices, LoadMoreMarkets).ConfigureAwait(false);
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
                currentHelper = await CreateAssistByQuery<ResellerViewObject, VENDEDOR>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<ResellerViewObject, VENDEDOR>(_dataServices, LoadMoreReseller).ConfigureAwait(false);
                }
                return currentHelper;
            });
            _assistMapper.Configure("VENDEDOR", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<ResellerViewObject, VENDEDOR>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {

                    currentHelper = await CreateAssistThroughHelper<ResellerViewObject, VENDEDOR>(_dataServices, LoadMoreReseller).ConfigureAwait(false);
                }
                return currentHelper;
            });
            _assistMapper.Configure("SUBLICEN", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<CompanyViewObject, SUBLICEN>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<CompanyViewObject, SUBLICEN>(_dataServices, LoadMoreCompanies).ConfigureAwait(false);
                }
                return currentHelper;
            });
            _assistMapper.Configure("RENT_USAGE_ASSIST", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<RentingUseViewObject, USO_ALQUILER>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<RentingUseViewObject, USO_ALQUILER>(_dataServices, LoadMoreRentingUse).ConfigureAwait(false);
                }
                return currentHelper;
            });
            _assistMapper.Configure("OFFICE_ZONE_ASSIST", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<ZonaOfiViewObject, ZONAOFI>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<ZonaOfiViewObject, ZONAOFI>(_dataServices, LoadMoreOffices).ConfigureAwait(false);
                }
                return currentHelper;
            });
            _assistMapper.Configure("ROAD_TAXES_ZONAOFI", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<ZonaOfiViewObject, ZONAOFI>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<ZonaOfiViewObject, ZONAOFI>(_dataServices, LoadMoreOffices).ConfigureAwait(false);
                }
                return currentHelper;
            });
            _assistMapper.Configure("REQUEST_REASON", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<RequestReasonViewObject, MOPETI>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<RequestReasonViewObject, MOPETI>(_dataServices, LoadMoreRequestReason).ConfigureAwait(false);
                }
                return currentHelper;
            });
            _assistMapper.Configure("FARE_ASSIST", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<FareViewObject, NTARI>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<FareViewObject, NTARI>(_dataServices, LoadMoreRequestReason).ConfigureAwait(false);
                }
                return currentHelper;
            });
            _assistMapper.Configure("BUDGET_KEY", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<BudgetKeyViewObject, CLAVEPTO>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<BudgetKeyViewObject, CLAVEPTO>(_dataServices, LoadMoreRequestReason).ConfigureAwait(false);
                }
                return currentHelper;
            });
            _assistMapper.Configure("CHANNEL_TYPE", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<ChannelViewObject, CANAL>(query as string).ConfigureAwait(false);

                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<ChannelViewObject, CANAL>(_dataServices, LoadMoreRequestReason).ConfigureAwait(false);
                }
                return currentHelper;
            });
            _assistMapper.Configure("CLIENT_BUDGET", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<BudgetKeyViewObject, CLAVEPTO>(query as string).ConfigureAwait(false);

                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<BudgetKeyViewObject, CLAVEPTO>(_dataServices, LoadMoreRequestReason).ConfigureAwait(false);
                }
                return currentHelper;
            });
            _assistMapper.Configure("CREDIT_CARD", async (query) =>
            {
                // in the world there are not more than 10 credi card.
                currentHelper = await _helperDataServices.GetPagedSummaryDoAsync<CreditCardViewObject, TARCREDI>(1, DefaultPage).ConfigureAwait(false);
                return currentHelper;
            });
            _assistMapper.Configure("CREDIT_CARD_ASSIST", async (query) =>
            {
                // in the world there are not more than 10 credi card.
                currentHelper = await _helperDataServices.GetPagedSummaryDoAsync<CreditCardViewObject, TARCREDI>(1, DefaultPage).ConfigureAwait(false);
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
            _assistMapper.Configure("DRIVER_ASSIST_6", async (query) =>
            {
                currentHelper = await CreateClientHelper().ConfigureAwait(false);
                return currentHelper;
            });
            _assistMapper.Configure("DRIVER_ASSIST_7", async (query) =>
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
                currentHelper = await CreateAssistByQuery<SupplierTypeViewObject, TIPOPROVE>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await _helperDataServices.GetPagedSummaryDoAsync<SupplierTypeViewObject, TIPOPROVE>(1, DefaultPage);
                }
                return currentHelper;
            });
            _assistMapper.Configure("VIASPEDIPRO", async (query) =>
            {
                // the number of deliviering ways is always minor than 500
                currentHelper = await CreateAssistByQuery<DeliveringWayViewObject, VIASPEDIPRO>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {

                    currentHelper = await _helperDataServices.GetPagedSummaryDoAsync<DeliveringWayViewObject, VIASPEDIPRO>(1, DefaultPage);
                }
                return currentHelper;
            });

            _assistMapper.Configure("GRUPOS", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<VehicleGroupViewObject, GRUPOS>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<VehicleGroupViewObject, GRUPOS>(_dataServices, LoadMoreGroups);
                }
                return currentHelper;
            });
            _assistMapper.Configure("PROPIE", async (query) =>
            {
                currentHelper = await CreateAssistThroughHelper<OwnerViewObject, PROPIE>(_dataServices, LoadMoreOwners);
                return currentHelper;
            });
            _assistMapper.Configure("PROVEE1", async (query) =>
            {
                var currentHelper = await CreateSupplierHelper().ConfigureAwait(false);
                return currentHelper;
            });
            _assistMapper.Configure("COLORFL", async (query) =>
            {
                currentHelper = await _helperDataServices.GetPagedSummaryDoAsync<ColorViewObject, COLORFL>(1, DefaultPage).ConfigureAwait(false);
                return currentHelper;
            });
            _assistMapper.Configure("COLORFL", async (query) =>
            {
                currentHelper = await _helperDataServices.GetPagedSummaryDoAsync<ColorViewObject, COLORFL>(1, DefaultPage).ConfigureAwait(false);
                return currentHelper;
            });
            _assistMapper.Configure("MODELO", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<ModelVehicleViewObject, MODELO>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<ModelVehicleViewObject, MODELO>(_dataServices, LoadMoreModels).ConfigureAwait(false);
                }
                return currentHelper;
            });
            _assistMapper.Configure("MARCAS", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<BrandVehicleViewObject, MARCAS>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<BrandVehicleViewObject, MARCAS>(_dataServices, LoadMoreModels).ConfigureAwait(false);
                }
                return currentHelper;
            });
            _assistMapper.Configure("GRUPO", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<VehicleGroupViewObject, GRUPOS>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<VehicleGroupViewObject, GRUPOS>(_dataServices, LoadMoreGroups).ConfigureAwait(false);
                }
                return currentHelper;
            });
            _assistMapper.Configure("SITUATION", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<CurrentSituationViewObject, SITUACION>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await _helperDataServices.GetPagedSummaryDoAsync<CurrentSituationViewObject, SITUACION>(1, DefaultPage).ConfigureAwait(false);
                }
                return currentHelper;
            });
            _assistMapper.Configure("ROAD_TAXES_CITY", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<CityViewObject, POBLACIONES>(query as string).ConfigureAwait(false);

                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<CityViewObject, POBLACIONES>(_dataServices, LoadMoreCities).ConfigureAwait(false);

                }
                return currentHelper;
            });
           
            _assistMapper.Configure("PRODUCTS", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<ProductsViewObject, PRODUCTS>(query as string).ConfigureAwait(false);

                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<ProductsViewObject, PRODUCTS>(_dataServices, LoadMoreProducts).ConfigureAwait(false);

                }
                return currentHelper;
            });

            _assistMapper.Configure("TIPOCOMI", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<CommissionTypeViewObject, TIPOCOMI>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await _helperDataServices.GetPagedSummaryDoAsync<CommissionTypeViewObject, TIPOCOMI>(1, DefaultPage);
                }
                return currentHelper;
            });
            _assistMapper.Configure("TIPOCOMISION", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<CommissionTypeViewObject, TIPOCOMISION>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await _helperDataServices.GetPagedSummaryDoAsync<CommissionTypeViewObject, TIPOCOMISION>(1, DefaultPage);
                }
                return currentHelper;
            });
            _assistMapper.Configure("SUPPLIER_ASSIST", async (query) =>
            {
                var currentHelper = await CreateSupplierHelper().ConfigureAwait(false);
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
                currentHelper = await CreateAssistByQuery<PriceConditionViewObject, TL_CONDICION_PRECIO>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {
                    currentHelper = await CreateAssistThroughHelper<PriceConditionViewObject, TL_CONDICION_PRECIO>(_dataServices, LoadConditionPrice);
                }
                return currentHelper;
            });
            _assistMapper.Configure("VEHICLE_GROUP_ASSIST", async (query) =>
            {
                currentHelper = await CreateAssistByQuery<VehicleGroupViewObject, GRUPOS>(query as string).ConfigureAwait(false);
                if (currentHelper == null)
                {

                    currentHelper = await CreateAssistThroughHelper<VehicleGroupViewObject, GRUPOS>(_dataServices, LoadMoreVehicleGroup);
                }
                return currentHelper;
            });
        }

       

        private async Task<object> CreateBookingContactsHelperAsync(object query)
        {
            currentHelper = new List<ContactsViewObject>();
            var currentQuery = query as string;
            if (!string.IsNullOrEmpty(currentQuery))
            {

                _clientCode = currentQuery;
                var dataServices = _dataServices.GetClientDataServices();
                IEnumerable<ContactsViewObject> contactsByClient = await dataServices.GetPagedContactsByClient(_clientCode, 1, DefaultPage).ConfigureAwait(false);
                var count = await _helperDataServices.GetItemsCount<CliContactos>().ConfigureAwait(false);

                currentHelper = new IncrementalList<ContactsViewObject>(LoadMoreContactsByClients) { MaxItemCount = count };
                if (currentHelper is IncrementalList<ContactsViewObject> summary)
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
            var creation = NotifyTaskCompletion.Create<IEnumerable<ContactsViewObject>>(dataServices.GetPagedContactsByClient(_clientCode, 1, DefaultPage), (sender, ev) =>
            {
                if (sender is INotifyTaskCompletion<IEnumerable<VehicleGroupViewObject>> task)
                {
                    if (task.IsSuccessfullyCompleted)
                    {
                        if (currentHelper is IncrementalList<VehicleGroupViewObject> list)
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
            currentHelper = new IncrementalList<BudgetSummaryViewObject>(LoadMoreBudget) { MaxItemCount = count };
            if (currentHelper is IncrementalList<BudgetSummaryViewObject> summary)
            {
                summary.LoadItems(page);
            }
            return currentHelper;
        }

        private void LoadMoreContableDelega(uint arg1, int index)
        {
            LoadMoreData<DelegaContableViewObject, DELEGA>(index, currentHelper);
        }
        private void LoadMoreProducts(uint arg1, int index)
        {
            LoadMoreData<ProductsViewObject, PRODUCTS>(index, currentHelper);
        }

        private void LoadMoreGroups(uint arg1, int arg2)
        {
            var helper = _dataServices.GetHelperDataServices();
            var creation = NotifyTaskCompletion.Create<IEnumerable<VehicleGroupViewObject>>(helper.GetPagedSummaryDoAsync<VehicleGroupViewObject, GRUPOS>(1, DefaultPage), (sender, ev) =>
            {
                if (sender is INotifyTaskCompletion<IEnumerable<VehicleGroupViewObject>> task)
                {
                    if (task.IsSuccessfullyCompleted)
                    {
                        if (currentHelper is IncrementalList<VehicleGroupViewObject> list)
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
            var creation = NotifyTaskCompletion.Create<IEnumerable<ModelVehicleViewObject>>(helper.GetPagedSummaryDoAsync<ModelVehicleViewObject, MODELO>(1, DefaultPage), (sender, ev) =>
            {
                if (sender is INotifyTaskCompletion<IEnumerable<ModelVehicleViewObject>> task)
                {
                    if (task.IsSuccessfullyCompleted)
                    {
                        if (currentHelper is IncrementalList<ModelVehicleViewObject> list)
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
            var creation = NotifyTaskCompletion.Create<IEnumerable<VehicleActivitiesViewObject>>(helper.GetPagedSummaryDoAsync<VehicleActivitiesViewObject, ACTIVEHI>(1, DefaultPage), (sender, ev) =>
            {
                if (sender is INotifyTaskCompletion<IEnumerable<VehicleActivitiesViewObject>> task)
                {
                    if (task.IsSuccessfullyCompleted)
                    {
                        if (currentHelper is IncrementalList<VehicleActivitiesViewObject> list)
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
            currentHelper = new IncrementalList<ActiveFareViewObject>(LoadMoreActiveFare) { MaxItemCount = count };
            var summary = (IncrementalList<ActiveFareViewObject>) currentHelper;
            summary.LoadItems(page);
            return currentHelper;
        }

        private void LoadMoreActiveFare(uint arg1, int arg2)
        {
            var fareDataServices = _dataServices.GetFareDataServices();
            var creation = NotifyTaskCompletion.Create<IEnumerable<ActiveFareViewObject>>(fareDataServices.GetActiveSummaryFarePaged(_clientFareCode, arg2, DefaultPage), (sender, ev) =>
            {
                if (!(sender is INotifyTaskCompletion<IEnumerable<ActiveFareViewObject>> task))
                {
                    return;
        
                }
                if (task.IsSuccessfullyCompleted)
                {
                    if (currentHelper is IncrementalList<ActiveFareViewObject> list)
                    {
                        list.LoadItems(task.Result);
                        currentHelper = list;
                    }
                }

            });
        }


        /*
         *  From this point we have the list of incremental handlers.
         */
        private void LoadMoreRentingUse(uint arg1, int index)
        {
            LoadMoreData<RentingUseViewObject, USO_ALQUILER>(index, currentHelper);
        }

        private void LoadMoreChannels(uint arg1, int index)
        {
            LoadMoreData<ChannelViewObject, CANAL>(index, currentHelper);
        }

        private void LoadMoreBudgetKey(uint arg1, int index)
        {
            LoadMoreData<BudgetKeyViewObject, CLAVEPTO>(index, currentHelper);

        }

        private void LoadClientInvoicesBlock(uint arg1, int index)
        {
            LoadMoreData<InvoiceBlockViewObject, BLOQUEFAC>(index, currentHelper);
        }

        private void LoadClientZones(uint arg1, int index)
        {
            LoadMoreData<ClientZoneViewObject, ZONAS>(index, currentHelper);

        }

        private void LoadClientPaymentForm(uint arg1, int index)
        {
            LoadMoreData<PaymentFormViewObject, FORMAS>(index, currentHelper);

        }

        private void LoadMoreAgents(uint arg1, int index)
        {
            LoadMoreData<AgentViewObject, AGENTES>(index, currentHelper);

        }
        private void LoadMoreActivities1(uint arg1, int index)
        {
            LoadMoreData<ActividadViewObject, ACTIVI>(index, currentHelper);

        }
        private void LoadMoreActivities2(uint arg1, int index)
        {
            LoadMoreData<VehicleActivitiesViewObject, ACTIVEHI>(index, currentHelper);

        }
        /*
                private void LoadMoreBudgetKey(uint arg1, int index)
                {
                    LoadMoreData<BudgetKeyDto, CLAVEPTO>(index, currentHelper);

                }*/

        private void LoadMoreReseller(uint arg1, int index)
        {
            LoadMoreData<BudgetKeyViewObject, CLAVEPTO>(index, currentHelper);

        }

        private void LoadMoreMarkets(uint arg1, int index)
        {
            LoadMoreData<BudgetKeyViewObject, CLAVEPTO>(index, currentHelper);
        }

        private void LoadMoreOrigin(uint arg1, int index)
        {
            LoadMoreData<OrigenViewObject, ORIGEN>(index, currentHelper);

        }

        private void LoadMoreOffices(uint arg1, int index)
        {
            LoadMoreData<OfficeViewObject, OFICINAS>(index, currentHelper);

        }

        private void LoadCountry(uint arg1, int index)
        {
            LoadMoreData<CountryViewObject, Country>(index, currentHelper);

        }

        private void LoadConditionPrice(uint arg1, int index)
        {
            LoadMoreData<PriceConditionViewObject, TL_CONDICION_PRECIO>(index, currentHelper);

        }



        private void LoadProvincia(uint arg1, int index)
        {
            LoadMoreData<ProvinceViewObject, PROVINCIA>(index, currentHelper);

        }

        private void LoadLanguage(uint arg1, int index)
        {
            LoadMoreData<LanguageViewObject, IDIOMAS>(index, currentHelper);
        }

        private void LoadFormas(uint arg1, int index)
        {
            LoadMoreData<PaymentFormViewObject, FORMAS>(index, currentHelper);


        }

        private void LoadFormasPedent(uint arg1, int index)
        {
            LoadMoreData<DeliveringFormViewObject, FORMAS_PEDENT>(index, currentHelper);
        }

        private void LoadDivisas(uint arg1, int index)
        {
            LoadMoreData<CurrenciesViewObject, DIVISAS>(index, currentHelper);

        }

        private void LoadMoreVehicleGroup(uint arg1, int index)
        {
            LoadMoreData<VehicleGroupViewObject, GRUPOS>(index, currentHelper);
        }

        private void LoadCurrencies(uint arg1, int index)
        {
            LoadMoreData<CurrenciesViewObject, CURRENCIES>(index, currentHelper);
        }

        private void LoadMoreAccounts(uint arg1, int index)
        {
            LoadMoreData<AccountViewObject, CU1>(index, currentHelper);
        }
        private void LoadMoreCompanies(uint arg1, int index)
        {
            LoadMoreData<CompanyViewObject, SUBLICEN>(index, currentHelper);
        }
        private void LoadMoreCountries(uint arg1, int index)
        {
            LoadMoreData<CountryViewObject, Country>(index, currentHelper);
        }

        private void LoadMoreCities(uint arg1, int index)
        {
            LoadMoreData<CityViewObject, POBLACIONES>(index, currentHelper);
        }

        private void LoadMoreRequestReason(uint arg1, int index)
        {
            LoadMoreData<RequestReasonViewObject, MOPETI>(index, currentHelper);
        }
        private void LoadMoreFares(uint arg1, int index)
        {
            LoadMoreData<FareViewObject, NTARI>(index, currentHelper);
        }
        private void LoadMoreClientType(uint arg1, int index)
        {
            LoadMoreData<ClientTypeViewObject, TIPOCLI>(index, currentHelper);
        }
        private void LoadMoreBusiness(uint arg1, int index)
        {
            LoadMoreData<BusinessViewObject, NEGOCIO>(index, currentHelper);
        }
        private void LoadMoreBanks(uint arg1, int index)
        {
            LoadMoreData<BanksViewObject, BANCO>(index, currentHelper);
        }
        private void LoadPromoCodes(uint arg1, int index)
        {
            LoadMoreData<PromotionCodesViewObject, CODIGOS_PROMOCIONALES>(index, currentHelper);
        }
        private void LoadMoreBookingType(uint arg1, int index)
        {
            LoadMoreData<BookingTypeViewObject, TIPOS_RESERVAS>(index, currentHelper);
        }
        private void LoadMoreBookingMedia(uint arg1, int index)
        {
            LoadMoreData<BookingMediaViewObject, MEDIO_RES>(index, currentHelper);
        }
        private void LoadMorePlaces(uint arg1, int index)
        {
            LoadMoreData<DeliveringPlaceViewObject, ENTREGAS>(index, currentHelper);
        }
        private void LoadMorePaymentTypes(uint arg1, int index)
        {
            LoadMoreData<PaymentFormViewObject, FORMAS>(index, currentHelper);
        }
        private void LoadMoreAgencies(uint arg1, int index)
        {
            LoadMoreData<AgencyEmployeeViewObject, EAGE>(index, currentHelper);
        }
    }
}
