using DataAccessLayer.DataObjects;
using KarveCommon.Generic;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using System.Collections.Generic;

namespace DataAccessLayer
{
    class AssistDataService: IAssistDataService
    {
        /// <summary>
        ///  Assis mapper / mapeo de las lupas.
        /// </summary>
        private IAssistMapper<BaseDto> _assistMapper = new AssistMapper<BaseDto>();
        private IHelperDataServices _helperDataServices;
        private IDataServices _dataServices;
        /// <summary>
        ///  Assist Data Service.
        /// </summary>
        /// <param name="services"></param>
        public AssistDataService(IDataServices services)
        {
            _helperDataServices = services.GetHelperDataServices();
            _dataServices = services;
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
       /// <summary>
       ///  This configure the standard mapper to answer query to answer questions.
       /// </summary>
        private void ConfigureAssist()
        {
            // here the parameter query is never used.
            _assistMapper.Configure("BANCO", async (query) =>
            {
                var helper = await _helperDataServices.GetMappedAllAsyncHelper<BanksDto, BANCO>();
                return helper;
            });
            _assistMapper.Configure("BROKER_ASSIST", async (query) =>
            {

                var helper = await _dataServices.GetCommissionAgentDataServices().GetCommissionAgentSummaryDo();
                return helper;
            });

            _assistMapper.Configure("BUSINESS_ASSIST", async (query) =>
            {
                var helper = await _helperDataServices.GetMappedAllAsyncHelper<BusinessDto, NEGOCIO>();
                return helper;
            });
            _assistMapper.Configure("CLIENT_TYPE_ASSIST", async (query) =>
            {
                var helper = await _helperDataServices.GetMappedAllAsyncHelper<ClientTypeDto, TIPOCLI>();
                return helper;
            });
            _assistMapper.Configure("CLIENT_TYPE_UPPER", async (query) =>
            {
                var helper = await _helperDataServices.GetMappedAllAsyncHelper<ClientTypeDto, TIPOCLI>();
                return helper;
            });

            _assistMapper.Configure("CITY_ASSIST", async (query) =>
            {
                var helper = await _helperDataServices.GetMappedAllAsyncHelper<CityDto, POBLACIONES>();
                return helper;
            });
            _assistMapper.Configure("COMPANY_ASSIST", async (query) =>
            {
                var helper = await _helperDataServices.GetMappedAllAsyncHelper<CompanyDto, SUBLICEN>();
                return helper;
            });
            _assistMapper.Configure("COUNTRY_ASSIST", async (query) =>
            {
                var helper = await _helperDataServices.GetMappedAllAsyncHelper<CountryDto, Country>();
                return helper;
            });
            _assistMapper.Configure("CU1", async (query) =>
            {
                IEnumerable<AccountDto> helper = new List<AccountDto>();
                var qvalue = query as string;
                if (qvalue != null)
                {
                    helper = await _helperDataServices.GetMappedAsyncHelper<AccountDto, CU1>(qvalue);
                }
                return helper;
            });
            _assistMapper.Configure("CURRENCY_ASSIST", async (query) =>
            {
                var helper = await _helperDataServices.GetMappedAllAsyncHelper<CurrenciesDto, CURRENCIES>();
                return helper;
            });
            _assistMapper.Configure("DIVISAS", async (query) =>
            {
                var helper = await _helperDataServices.GetMappedAllAsyncHelper<CurrenciesDto, DIVISAS>();
                return helper;
            });
            
            _assistMapper.Configure("FORMA_PEDENT", async (query) =>
            {
                var helper = await _helperDataServices.GetMappedAllAsyncHelper<DeliveringFormDto, FORMAS_PEDENT>();
                return helper;
            });
            _assistMapper.Configure("FORMAS", async (query) =>
            {
                var helper = await _helperDataServices.GetMappedAllAsyncHelper<PaymentFormDto, FORMAS>();
                return helper;
            });
            _assistMapper.Configure("LANGUAGE_ASSIST", async (query) =>
            {
                var helper = await _helperDataServices.GetMappedAllAsyncHelper<LanguageDto, IDIOMAS>();
                return helper;
            });

            _assistMapper.Configure("PROVINCE_ASSIST", async (query) =>
            {
                var helper = await _helperDataServices.GetMappedAllAsyncHelper<ProvinciaDto, PROVINCIA>();
                return helper;
            });
          
           
            _assistMapper.Configure("PROVINCIA", async (query) =>
            {
                var helper = await _helperDataServices.GetMappedAllAsyncHelper<ProvinciaDto, PROVINCIA>();
                return helper;
            });
           
            
           
            _assistMapper.Configure("PROV_PAGO", async (query) =>
            {
                var helper = await _helperDataServices.GetMappedAllAsyncHelper<ProvinciaDto, PROVINCIA>();
                return helper;
            });
            _assistMapper.Configure("PROV_RECL", async (query) =>
            {
                var helper = await _helperDataServices.GetMappedAllAsyncHelper<ProvinciaDto, PROVINCIA>();
                return helper;
            });
            _assistMapper.Configure("MESES", async (query) =>
            {
                var helper = await _helperDataServices.GetMappedAllAsyncHelper<MonthsDto, MESES>();
                return helper;
            });
            _assistMapper.Configure("MESES2", async (query) =>
            {
                var helper = await _helperDataServices.GetMappedAllAsyncHelper<MonthsDto, MESES>();
                return helper;
            });
            _assistMapper.Configure("TL_CONDICION_PRECIO", async (query) =>
            {
                var helper = await _helperDataServices.GetMappedAllAsyncHelper<PriceConditionDto, TL_CONDICION_PRECIO>();
                return helper;
            });
            _assistMapper.Configure("PROV_DEVO", async (query) =>
            {
                var helper = await _helperDataServices.GetMappedAllAsyncHelper<ProvinciaDto, PROVINCIA>();
                return helper;
            });
            _assistMapper.Configure("PAIS_PAGO", async (query) =>
            {
                var helper = await _helperDataServices.GetMappedAllAsyncHelper<CountryDto, Country>();
                return helper;
            });

            _assistMapper.Configure("PAIS_DEVO", async (query) =>
            {
                var helper = await _helperDataServices.GetMappedAllAsyncHelper<CountryDto, Country>();
                return helper;
            });
            _assistMapper.Configure("PAIS_RECL", async (query) =>
            {
                var helper = await _helperDataServices.GetMappedAllAsyncHelper<CountryDto, Country>();
                return helper;
            });
            _assistMapper.Configure("PAIS", async (query) =>
            {
                var helper = await _helperDataServices.GetMappedAllAsyncHelper<CountryDto, Country>();
                return helper;
            });
            _assistMapper.Configure("POBLACIONES_PAGO", async (query) =>
            {
                var helper = await _helperDataServices.GetMappedAllAsyncHelper<CityDto, POBLACIONES>();
                return helper;
            });
            _assistMapper.Configure("POBLACIONES_DEVO", async (query) =>
            {
                var helper = await _helperDataServices.GetMappedAllAsyncHelper<CityDto, POBLACIONES>();
                return helper;
            });
            _assistMapper.Configure("POBLACIONES_RECL", async (query) =>
            {
                var helper = await _helperDataServices.GetMappedAllAsyncHelper<CityDto, POBLACIONES>();
                return helper;
            });
            _assistMapper.Configure("POBLACIONES", async (query) =>
            {
                var helper = await _helperDataServices.GetMappedAllAsyncHelper<CityDto, POBLACIONES>();
                return helper;
            });
           
            _assistMapper.Configure("IDIOMAS", async (query) =>
            {
                var helper = await _helperDataServices.GetMappedAllAsyncHelper<LanguageDto, IDIOMAS>();
                return helper;
            });
            _assistMapper.Configure("OFFICE_ASSIST", async (query) =>
            {
                var helper = await _helperDataServices.GetMappedAllAsyncHelper<OfficeDtos, OFICINAS>();
                return helper;
            });
            _assistMapper.Configure("OFFICE_ASSIST", async (query) =>
            {
                var helper = await _helperDataServices.GetMappedAllAsyncHelper<OfficeDtos, OFICINAS>();
                return helper;
            });
            _assistMapper.Configure("OFICINAS", async (query) =>
            {
                var helper = await _helperDataServices.GetMappedAllAsyncHelper<OfficeDtos, OFICINAS>();
                return helper;
            });
            _assistMapper.Configure("ORIGIN_ASSIST", async (query) =>
            {
                var helper = await _helperDataServices.GetMappedAllAsyncHelper<OrigenDto, ORIGEN>();
                return helper;
            });
            _assistMapper.Configure("MARKET_ASSIST", async (query) =>
            {
                var helper = await _helperDataServices.GetMappedAllAsyncHelper<MercadoDto, MERCADO>();
                return helper;
            });
            _assistMapper.Configure("RESELLER_ASSIST", async (query) =>
            {
                var helper = await _helperDataServices.GetMappedAllAsyncHelper<ResellerDto, VENDEDOR>();
                return helper;
            });
            _assistMapper.Configure("SUBLICEN", async (query) =>
            {
                var helper = await _helperDataServices.GetMappedAllAsyncHelper<CompanyDto, SUBLICEN>();
                return helper;
            });

            _assistMapper.Configure("ACTIVITY_ASSIST", async (query) =>
            {
                var helper = await _helperDataServices.GetMappedAllAsyncHelper<ActividadDto, ACTIVI>();
                return helper;
            });
            _assistMapper.Configure("RENT_USAGE_ASSIST", async (query) =>
            {
                var helper = await _helperDataServices.GetMappedAllAsyncHelper<RentingUseDto, USO_ALQUILER>();
                return helper;
            });
            _assistMapper.Configure("OFFICE_ZONE_ASSIST", async (query) =>
            {
                var helper = await _helperDataServices.GetMappedAllAsyncHelper<ZonaOfiDto, ZONAOFI>();
                return helper;
            });

            _assistMapper.Configure("CLIENT_PAYMENT_FORM", async (query) =>
            {
                var helper = await _helperDataServices.GetMappedAllAsyncHelper<PaymentFormDto, FORMAS>();
                return helper;
            });
            _assistMapper.Configure("CLIENT_ZONE", async (query) =>
            {
                var helper = await _helperDataServices.GetMappedAllAsyncHelper<ClientZoneDto, ZONAS>();
                return helper;
            });
            _assistMapper.Configure("CLIENT_INVOICE_BLOCKS", async (query) =>
            {

                var helper = await _helperDataServices.GetMappedAllAsyncHelper<InvoiceBlockDto, BLOQUEFAC>();
                return helper;
            });
            _assistMapper.Configure("CLIENT_BROKER", async (query) =>
            {
                var helper = await _dataServices.GetCommissionAgentDataServices().GetCommissionAgentSummaryDo();
                return helper;
            });
            _assistMapper.Configure("CLIENT_TYPE", async (query) =>
            {
                var helper = await _helperDataServices.GetMappedAllAsyncHelper<ClientTypeDto, TIPOCLI>();
                return helper;
            });
            _assistMapper.Configure("BUDGET_KEY", async (query) =>
            {
                var helper = await _helperDataServices.GetMappedAllAsyncHelper<BudgetKeyDto, CLAVEPTO>();
                return helper;
            });
            _assistMapper.Configure("CHANNEL_TYPE", async (query) =>
            {
                var helper = await _helperDataServices.GetMappedAllAsyncHelper<ChannelDto, CANAL>();
                return helper;
            });
            _assistMapper.Configure("CLIENT_BUDGET", async (query) =>
            {
                var helper = await _helperDataServices.GetMappedAllAsyncHelper<BudgetKeyDto, CLAVEPTO>();
                return helper;
            });
            _assistMapper.Configure("CREDIT_CARD", async (query) =>
            {
                var helper = await _helperDataServices.GetMappedAllAsyncHelper<CreditCardDto, TARCREDI>();
                return helper;
            });
            _assistMapper.Configure("CLIENT_DRIVER", async (query) =>
            {
                var helper = await _dataServices.GetClientDataServices().GetClientSummaryDo(GenericSql.ExtendedClientsSummaryQuery);
                return helper;
            });
            _assistMapper.Configure("CLIENT_ASSIST", async (query) =>
            {
                var helper = await _dataServices.GetClientDataServices().GetClientSummaryDo(GenericSql.ExtendedClientsSummaryQuery);
                return helper;
            });
            _assistMapper.Configure("BROKER_ASSIST", async (query) =>
            {
                var helper = await _dataServices.GetCommissionAgentDataServices().GetCommissionAgentSummaryDo();
                return helper;
            });
            _assistMapper.Configure("TIPOPROVE", async (query) =>
            {
                var helper = await _helperDataServices.GetMappedAllAsyncHelper<SupplierTypeDto, TIPOPROVE>();
                return helper;
            });
            _assistMapper.Configure("VIASPEDIPRO", async (query) =>
            {
                var helper = await _helperDataServices.GetMappedAllAsyncHelper<DeliveringWayDto, VIASPEDIPRO>();
                return helper;
            });
        }
    }
}
