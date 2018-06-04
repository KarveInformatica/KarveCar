using DataAccessLayer.DataObjects;
using KarveCommon.Generic;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using Syncfusion.UI.Xaml.Grid;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;
using System.Threading.Tasks;

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
        /// <summary>
        ///  Assist Data Service.
        /// </summary>
        /// <param name="services"></param>
        public AssistDataService(IDataServices services)
        {
            _helperDataServices = services.GetHelperDataServices();
            _dataServices = services;
            DefaultPage = 500;
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
            var creation = NotifyTaskCompletion.Create <IEnumerable<DtoType>>(_helperDataServices.GetPagedSummaryDoAsync<DtoType, Entity>(baseIndex, DefaultPage), (sender, ev) => {
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

            var creation = NotifyTaskCompletion.Create<IEnumerable<VehicleSummaryDto>>(vehicleDataServices.GetPagedSummaryDoAsync(arg2, DefaultPage), (sender, ev) => {
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

        private void LoadMoreBrokers(uint arg1, int arg2)
        {
            var commissionAgent = _dataServices.GetCommissionAgentDataServices();
            var creation = NotifyTaskCompletion.Create<IEnumerable<CommissionAgentSummaryDto>>(commissionAgent.GetPagedSummaryDoAsync(arg2, DefaultPage), (sender, ev) => {
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

        /// <summary>
        ///  This configure the standard mapper to answer query to answer questions.
        /// </summary>
        private void ConfigureAssist()
        {
            // here the parameter query is never used.
            _assistMapper.Configure("BANCO", async (query) =>
            {
                currentHelper = await CreateAssistThroughHelper<BanksDto, BANCO>(_dataServices, LoadMoreBanks);
                return currentHelper;
            });
            _assistMapper.Configure("BROKER_ASSIST", async (query) =>
            {

                currentHelper = await CreateBrokerHelper();
                return currentHelper;
            });
            _assistMapper.Configure("BUSINESS_ASSIST", async (query) =>
            {
                currentHelper = await CreateAssistThroughHelper<BusinessDto, NEGOCIO>(_dataServices, LoadMoreBusiness);
                return currentHelper;
            });
            _assistMapper.Configure("CLIENT_TYPE_ASSIST", async (query) =>
            {
                currentHelper = await CreateAssistThroughHelper<ClientTypeDto, TIPOCLI>(_dataServices, LoadMoreClientType);
                return currentHelper;
            });

            _assistMapper.Configure("CLIENT_TYPE_UPPER", async (query) =>
            {
                currentHelper = await CreateAssistThroughHelper <ClientTypeDto, TIPOCLI>(_dataServices, LoadMoreClientType);
                return currentHelper;
            });

            _assistMapper.Configure("CITY_ASSIST", async (query) =>
            {
                currentHelper = await CreateAssistThroughHelper<CityDto, POBLACIONES>(_dataServices,LoadMoreCities);

                return currentHelper;
            });
            _assistMapper.Configure("COMPANY_ASSIST", async (query) =>
            {
                currentHelper = await CreateAssistThroughHelper<CompanyDto, SUBLICEN>(_dataServices, LoadMoreCompanies);
                return currentHelper;
            });
            _assistMapper.Configure("COUNTRY_ASSIST", async (query) =>
            {
                currentHelper = await CreateAssistThroughHelper<CountryDto, Country>(_dataServices, LoadMoreCountries);
                return currentHelper;
            });
            _assistMapper.Configure("CU1", async (query) =>
            {
                    currentHelper = await CreateAssistThroughHelper<AccountDto, CU1>(_dataServices, LoadMoreAccounts);
                    return currentHelper;
               
            });
            _assistMapper.Configure("VEHICLE_GROUP_ASSIST", async (query)=> 
               {
                   currentHelper = await CreateAssistThroughHelper<VehicleGroupDto, GRUPOS>(_dataServices, LoadMoreVehicleGroup);
                   return currentHelper;
               });

            _assistMapper.Configure("CURRENCY_ASSIST", async (query) =>
            {
             
                currentHelper = await CreateAssistThroughHelper<CurrenciesDto, CURRENCIES>(_dataServices, LoadCurrencies);
                return currentHelper;
            });
            _assistMapper.Configure("DIVISAS", async (query) =>
            {
                currentHelper = await CreateAssistThroughHelper<CurrenciesDto, DIVISAS>(_dataServices, LoadDivisas);
                return currentHelper;
            
            });
            
            _assistMapper.Configure("FORMA_PEDENT", async (query) =>
            {
                currentHelper = await CreateAssistThroughHelper<DeliveringFormDto, FORMAS_PEDENT>(_dataServices, LoadFormasPedent);
                return currentHelper;
            });
            _assistMapper.Configure("FORMAS", async (query) =>
            {
                currentHelper = await CreateAssistThroughHelper<PaymentFormDto, FORMAS>(_dataServices, LoadFormas);
       
                return currentHelper;
            });
            _assistMapper.Configure("LANGUAGE_ASSIST", async (query) =>
            {
                currentHelper = await CreateAssistThroughHelper<LanguageDto, IDIOMAS>(_dataServices, LoadLanguage);
                return currentHelper;
            });

            _assistMapper.Configure("PROVINCE_ASSIST", async (query) =>
            {
                currentHelper = await CreateAssistThroughHelper<ProvinciaDto, PROVINCIA>(_dataServices, LoadProvincia);
               
                return currentHelper;
            });
          
           
            _assistMapper.Configure("PROVINCIA", async (query) =>
            {
                currentHelper = await CreateAssistThroughHelper<ProvinciaDto, PROVINCIA>(_dataServices, LoadProvincia);
             
                return currentHelper;
            });
           
            
           
            _assistMapper.Configure("PROV_PAGO", async (query) =>
            {
                currentHelper = await CreateAssistThroughHelper<ProvinciaDto, PROVINCIA>(_dataServices, LoadProvincia);
               
                return currentHelper;
            });
            _assistMapper.Configure("PROV_RECL", async (query) =>
            {
                currentHelper = await CreateAssistThroughHelper<ProvinciaDto, PROVINCIA>(_dataServices, LoadProvincia);
               
                return currentHelper;
            });
           
            _assistMapper.Configure("MESES", async (query) =>
            {
                currentHelper = await _helperDataServices.GetPagedSummaryDoAsync<MonthsDto, MESES>(1, DefaultPage);
                return currentHelper;
            });
            _assistMapper.Configure("MESES2", async (query) =>
            {
                currentHelper = await _helperDataServices.GetPagedSummaryDoAsync<MonthsDto, MESES>(1, DefaultPage);
                return currentHelper;
            });
            _assistMapper.Configure("TL_CONDICION_PRECIO", async (query) =>
            {
                currentHelper = await CreateAssistThroughHelper<PriceConditionDto, TL_CONDICION_PRECIO>(_dataServices, LoadConditionPrice);
                return currentHelper;
            });
            _assistMapper.Configure("PROV_DEVO", async (query) =>
            {
                currentHelper = await CreateAssistThroughHelper<ProvinciaDto, PROVINCIA>(_dataServices, LoadProvincia);
               
                return currentHelper;
            });
            _assistMapper.Configure("PAIS_PAGO", async (query) =>
            {
                currentHelper = await CreateAssistThroughHelper<CountryDto, Country>(_dataServices, LoadCountry);
                return currentHelper;
            });

            _assistMapper.Configure("PAIS_DEVO", async (query) =>
            {
                currentHelper = await CreateAssistThroughHelper<CountryDto, Country>(_dataServices, LoadCountry);
                return currentHelper;
                
            });
            _assistMapper.Configure("PAIS_RECL", async (query) =>
            {
                currentHelper = await CreateAssistThroughHelper<CountryDto, Country>(_dataServices, LoadCountry);
                return currentHelper;
                
            });
            _assistMapper.Configure("PAIS", async (query) =>
            {
                currentHelper = await CreateAssistThroughHelper<CountryDto, Country>(_dataServices, LoadCountry);
                return currentHelper;
              });
            _assistMapper.Configure("POBLACIONES_PAGO", async (query) =>
            {
                currentHelper = await CreateAssistThroughHelper<CityDto, POBLACIONES>(_dataServices, LoadMoreCities);
                return currentHelper;
            });
            _assistMapper.Configure("POBLACIONES_DEVO", async (query) =>
            {

                currentHelper = await CreateAssistThroughHelper<CityDto, POBLACIONES>(_dataServices, LoadMoreCities);
                return currentHelper;
            });
            _assistMapper.Configure("POBLACIONES_RECL", async (query) =>
            {
                currentHelper = await CreateAssistThroughHelper<CityDto, POBLACIONES>(_dataServices, LoadMoreCities);
                return currentHelper;
            });
            _assistMapper.Configure("POBLACIONES", async (query) =>
            {
                currentHelper = await CreateAssistThroughHelper<CityDto, POBLACIONES>(_dataServices, LoadMoreCities);
                return currentHelper;
            });
           
            _assistMapper.Configure("IDIOMAS", async (query) =>
            {
                /* there are not more than  6,909  languages, but in europe there are at most 30 languges. no incremental is needed. The default page is at most 500 items
                 */
                currentHelper = await _helperDataServices.GetPagedSummaryDoAsync<LanguageDto, IDIOMAS>(1, DefaultPage) ;
                return currentHelper;
            });
            _assistMapper.Configure("OFFICE_ASSIST", async (query) =>
            {
                currentHelper = await CreateAssistThroughHelper<OfficeDtos, OFICINAS>(_dataServices, LoadMoreOffices);
                return currentHelper;
            });
            _assistMapper.Configure("OFICINAS", async (query) =>
            {
                currentHelper = await CreateAssistThroughHelper<OfficeDtos, OFICINAS>(_dataServices, LoadMoreOffices);
                return currentHelper;
            });
            _assistMapper.Configure("ORIGIN_ASSIST", async (query) =>
            {
                currentHelper = await CreateAssistThroughHelper<OrigenDto, ORIGEN>(_dataServices, LoadMoreOrigin);
                return currentHelper;
            });
            _assistMapper.Configure("MARKET_ASSIST", async (query) =>
            {
                currentHelper = await CreateAssistThroughHelper<MercadoDto, MERCADO>(_dataServices, LoadMoreMarkets);
                return currentHelper;
            });
            _assistMapper.Configure("RESELLER_ASSIST", async (query) =>
            {
                currentHelper = await CreateAssistThroughHelper<ResellerDto, VENDEDOR>(_dataServices, LoadMoreReseller);
                return currentHelper;
            });
            _assistMapper.Configure("SUBLICEN", async (query) =>
            {
                currentHelper = await CreateAssistThroughHelper<CompanyDto, SUBLICEN>(_dataServices, LoadMoreCompanies);
                return currentHelper;
            });

            _assistMapper.Configure("ACTIVITY_ASSIST", async (query) =>
            {
                currentHelper = await CreateAssistThroughHelper<ActividadDto, ACTIVI>(_dataServices, LoadMoreActivities);
                return currentHelper;
            });
            _assistMapper.Configure("RENT_USAGE_ASSIST", async (query) =>
            {
                currentHelper = await CreateAssistThroughHelper<RentingUseDto, USO_ALQUILER>(_dataServices, LoadMoreRentingUse);
                return currentHelper;
            });
            _assistMapper.Configure("OFFICE_ZONE_ASSIST", async (query) =>
            {
                currentHelper = await CreateAssistThroughHelper<ZonaOfiDto, ZONAOFI>(_dataServices, LoadMoreOffices);
                return currentHelper;
            });

            _assistMapper.Configure("CLIENT_PAYMENT_FORM", async (query) =>
            {
                currentHelper = await CreateAssistThroughHelper<PaymentFormDto, FORMAS>(_dataServices, LoadClientPaymentForm);
                return currentHelper;
            });
            _assistMapper.Configure("CLIENT_ZONE", async (query) =>
            {
                currentHelper = await CreateAssistThroughHelper<ClientZoneDto, ZONAS>(_dataServices, LoadClientZones);
                return currentHelper;
            });
            _assistMapper.Configure("CLIENT_INVOICE_BLOCKS", async (query) =>
            {
                currentHelper = await CreateAssistThroughHelper<InvoiceBlockDto, BLOQUEFAC>(_dataServices, LoadClientInvoicesBlock); 
                return currentHelper;
            });
            _assistMapper.Configure("CLIENT_BROKER", async (query) =>
            {
                currentHelper = await CreateBrokerHelper();
                return currentHelper;
            });
            _assistMapper.Configure("CLIENT_TYPE", async (query) =>
            {
                currentHelper = await CreateAssistThroughHelper<ClientTypeDto, TIPOCLI>(_dataServices, LoadMoreClientType);
                return currentHelper;
            });
            _assistMapper.Configure("BUDGET_KEY", async (query) =>
            {
                currentHelper = await CreateAssistThroughHelper<BudgetKeyDto, CLAVEPTO>(_dataServices, LoadMoreBudgetKey);
                return currentHelper;
            });
            _assistMapper.Configure("CHANNEL_TYPE", async (query) =>
            {
                currentHelper = await CreateAssistThroughHelper<ChannelDto, CANAL>(_dataServices, LoadMoreChannels);
                return currentHelper;
            });
            _assistMapper.Configure("CLIENT_BUDGET", async (query) =>
            {
                currentHelper = await CreateAssistThroughHelper<BudgetKeyDto, CLAVEPTO>(_dataServices, LoadMoreBudgetKey);
                return currentHelper;
            });
            _assistMapper.Configure("CREDIT_CARD", async (query) =>
            {
                // in the world there are not more than 10 credi card.
                currentHelper = await _helperDataServices.GetPagedSummaryDoAsync<CreditCardDto, TARCREDI>(1, DefaultPage);
                return currentHelper;
            });
            _assistMapper.Configure("CLIENT_DRIVER", async (query) =>
            {
                currentHelper = await CreateClientHelper();
                return currentHelper;
            });
            _assistMapper.Configure("INVOICE_ASSIST", async (query) =>
            {
                currentHelper = await CreateInvoicesHelper();
                return currentHelper;
            });
            _assistMapper.Configure("CLIENT_ASSIST", async (query) =>
            {
                currentHelper = await CreateClientHelper();
                return currentHelper;
            });
            _assistMapper.Configure("VEHICLE_ASSIST", async (query) =>
            {
                currentHelper = await CreateVehicleHelper();
                return currentHelper;
            });
            _assistMapper.Configure("BROKER_ASSIST", async (query) =>
            {
                currentHelper = await CreateBrokerHelper();
                return currentHelper;
            });
            _assistMapper.Configure("TIPOPROVE", async (query) =>
            {
                currentHelper = await _helperDataServices.GetPagedSummaryDoAsync<SupplierTypeDto, TIPOPROVE>(1, DefaultPage);
                return currentHelper;
            });
            _assistMapper.Configure("VIASPEDIPRO", async (query) =>
            {
                // the number of deliviering ways is always minor than 500
                currentHelper = await _helperDataServices.GetPagedSummaryDoAsync<DeliveringWayDto, VIASPEDIPRO>(1, DefaultPage);
                return currentHelper;
            });
        }

        /*
         *  From this point we have the list of incremental handlers.
         */
        private void LoadMoreRentingUse(uint arg1, int index)
        {
            LoadMoreData<RentingUseDto, USO_ALQUILER>(index, currentHelper);
        }

        private  void LoadMoreChannels(uint arg1, int index)
        {
           LoadMoreData<ChannelDto, CANAL>(index, currentHelper);
        }

        private  void LoadMoreBudgetKey(uint arg1, int index)
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
             LoadMoreData<PriceConditionDto,TL_CONDICION_PRECIO>(index, currentHelper);

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
    }
}
