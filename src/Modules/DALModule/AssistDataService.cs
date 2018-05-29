using DataAccessLayer.DataObjects;
using KarveCommon.Generic;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using Syncfusion.UI.Xaml.Grid;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;

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
        ///  This configure the standard mapper to answer query to answer questions.
        /// </summary>
        private void ConfigureAssist()
        {
            // here the parameter query is never used.
            _assistMapper.Configure("BANCO", async (query) =>
            {
                var page = await _helperDataServices.GetPagedSummaryDoAsync<BanksDto, BANCO>(1, DefaultPage);
                var count = await _helperDataServices.GetItemsCount<BANCO>();
                var helper = new IncrementalList<BanksDto>(LoadMoreBanks) { MaxItemCount = count };
                helper.LoadItems(page);
                return helper;
            });
            _assistMapper.Configure("BROKER_ASSIST", async (query) =>
            {

                var page = await _dataServices.GetCommissionAgentDataServices().GetPagedSummaryDoAsync(1, DefaultPage);
                var count = await _helperDataServices.GetItemsCount<COMISIO>();
                var helper = new IncrementalList<CommissionAgentSummaryDto>(LoadMoreBrokers) { MaxItemCount = count };
                helper.LoadItems(page);

                return helper;
            });

            _assistMapper.Configure("BUSINESS_ASSIST", async (query) =>
            {
                var page = await _helperDataServices.GetPagedSummaryDoAsync<BusinessDto, NEGOCIO>(1, DefaultPage);
                var count = await _helperDataServices.GetItemsCount<NEGOCIO>();
                var helper = new IncrementalList<BusinessDto>(LoadMoreBusiness) { MaxItemCount = count };
                helper.LoadItems(page);
                return helper;
            });
            _assistMapper.Configure("CLIENT_TYPE_ASSIST", async (query) =>
            {
                var helper = await _helperDataServices.GetPagedSummaryDoAsync<ClientTypeDto, TIPOCLI>(1, DefaultPage);
                return helper;
            });
            _assistMapper.Configure("CLIENT_TYPE_UPPER", async (query) =>
            {
                var helper = await _helperDataServices.GetPagedSummaryDoAsync<ClientTypeDto, TIPOCLI>(1,DefaultPage);
                return helper;
            });

            _assistMapper.Configure("CITY_ASSIST", async (query) =>
            {
                var helper = await _helperDataServices.GetPagedSummaryDoAsync<CityDto, POBLACIONES>(1,DefaultPage);
                return helper;
            });
            _assistMapper.Configure("COMPANY_ASSIST", async (query) =>
            {
                var helper = await _helperDataServices.GetPagedSummaryDoAsync<CompanyDto, SUBLICEN>(1, DefaultPage);
                return helper;
            });
            _assistMapper.Configure("COUNTRY_ASSIST", async (query) =>
            {
                var helper = await _helperDataServices.GetPagedSummaryDoAsync<CountryDto, Country>(1, DefaultPage);
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
                var helper = await _helperDataServices.GetPagedSummaryDoAsync<CurrenciesDto, CURRENCIES>(1, DefaultPage);
                return helper;
            });
            _assistMapper.Configure("DIVISAS", async (query) =>
            {
                var helper = await _helperDataServices.GetPagedSummaryDoAsync<CurrenciesDto, DIVISAS>(1,DefaultPage);
                return helper;
            });
            
            _assistMapper.Configure("FORMA_PEDENT", async (query) =>
            {
                var helper = await _helperDataServices.GetPagedSummaryDoAsync<DeliveringFormDto, FORMAS_PEDENT>(1, DefaultPage);
                return helper;
            });
            _assistMapper.Configure("FORMAS", async (query) =>
            {
                var helper = await _helperDataServices.GetPagedSummaryDoAsync<PaymentFormDto, FORMAS>(1, DefaultPage);
                return helper;
            });
            _assistMapper.Configure("LANGUAGE_ASSIST", async (query) =>
            {
                var helper = await _helperDataServices.GetPagedSummaryDoAsync<LanguageDto, IDIOMAS>(1, DefaultPage);
                return helper;
            });

            _assistMapper.Configure("PROVINCE_ASSIST", async (query) =>
            {
                var helper = await _helperDataServices.GetPagedSummaryDoAsync<ProvinciaDto, PROVINCIA>(1, DefaultPage);
                return helper;
            });
          
           
            _assistMapper.Configure("PROVINCIA", async (query) =>
            {
                var helper = await _helperDataServices.GetPagedSummaryDoAsync<ProvinciaDto, PROVINCIA>(1, DefaultPage);
                return helper;
            });
           
            
           
            _assistMapper.Configure("PROV_PAGO", async (query) =>
            {
                var helper = await _helperDataServices.GetPagedSummaryDoAsync<ProvinciaDto, PROVINCIA>(1, DefaultPage);
                return helper;
            });
            _assistMapper.Configure("PROV_RECL", async (query) =>
            {
                var helper = await _helperDataServices.GetPagedSummaryDoAsync<ProvinciaDto, PROVINCIA>(1, DefaultPage);
                return helper;
            });
           
            _assistMapper.Configure("MESES", async (query) =>
            {
                var helper = await _helperDataServices.GetPagedSummaryDoAsync<MonthsDto, MESES>(1, DefaultPage);
                return helper;
            });
            _assistMapper.Configure("MESES2", async (query) =>
            {
                var helper = await _helperDataServices.GetPagedSummaryDoAsync<MonthsDto, MESES>(1, DefaultPage);
                return helper;
            });
            _assistMapper.Configure("TL_CONDICION_PRECIO", async (query) =>
            {
                var helper = await _helperDataServices.GetPagedSummaryDoAsync<PriceConditionDto, TL_CONDICION_PRECIO>(1, DefaultPage);
                return helper;
            });
            _assistMapper.Configure("PROV_DEVO", async (query) =>
            {
                var helper = await _helperDataServices.GetPagedSummaryDoAsync<ProvinciaDto, PROVINCIA>(1, DefaultPage);
                return helper;
            });
            _assistMapper.Configure("PAIS_PAGO", async (query) =>
            {
                var helper = await _helperDataServices.GetPagedSummaryDoAsync<CountryDto, Country>(1, DefaultPage);
                return helper;
            });

            _assistMapper.Configure("PAIS_DEVO", async (query) =>
            {
                var helper = await _helperDataServices.GetPagedSummaryDoAsync<CountryDto, Country>(1, DefaultPage);
                return helper;
            });
            _assistMapper.Configure("PAIS_RECL", async (query) =>
            {
                var helper = await _helperDataServices.GetPagedSummaryDoAsync<CountryDto, Country>(1, DefaultPage);
                return helper;
            });
            _assistMapper.Configure("PAIS", async (query) =>
            {
                var helper = await _helperDataServices.GetPagedSummaryDoAsync<CountryDto, Country>(1, DefaultPage);
                return helper;
            });
            _assistMapper.Configure("POBLACIONES_PAGO", async (query) =>
            {
                var helper = await _helperDataServices.GetPagedSummaryDoAsync<CityDto, POBLACIONES>(1, DefaultPage);
                return helper;
            });
            _assistMapper.Configure("POBLACIONES_DEVO", async (query) =>
            {
                var helper = await _helperDataServices.GetPagedSummaryDoAsync<CityDto, POBLACIONES>(1, DefaultPage);
                return helper;
            });
            _assistMapper.Configure("POBLACIONES_RECL", async (query) =>
            {
                var helper = await _helperDataServices.GetPagedSummaryDoAsync<CityDto, POBLACIONES>(1, DefaultPage);
                return helper;
            });
            _assistMapper.Configure("POBLACIONES", async (query) =>
            {
                var helper = await _helperDataServices.GetPagedSummaryDoAsync<CityDto, POBLACIONES>(1, DefaultPage);
                return helper;
            });
           
            _assistMapper.Configure("IDIOMAS", async (query) =>
            {
                var helper = await _helperDataServices.GetPagedSummaryDoAsync<LanguageDto, IDIOMAS>(1, DefaultPage);
                return helper;
            });
            _assistMapper.Configure("OFFICE_ASSIST", async (query) =>
            {
                var helper = await _helperDataServices.GetPagedSummaryDoAsync<OfficeDtos, OFICINAS>(1, DefaultPage);
                return helper;
            });
            _assistMapper.Configure("OFFICE_ASSIST", async (query) =>
            {
                var helper = await _helperDataServices.GetPagedSummaryDoAsync<OfficeDtos, OFICINAS>(1, DefaultPage);
                return helper;
            });
            _assistMapper.Configure("OFICINAS", async (query) =>
            {
                var helper = await _helperDataServices.GetPagedSummaryDoAsync<OfficeDtos, OFICINAS>(1, DefaultPage);
                return helper;
            });
            _assistMapper.Configure("ORIGIN_ASSIST", async (query) =>
            {
                var helper = await _helperDataServices.GetPagedSummaryDoAsync<OrigenDto, ORIGEN>(1, DefaultPage);
                return helper;
            });
            _assistMapper.Configure("MARKET_ASSIST", async (query) =>
            {
                var helper = await _helperDataServices.GetPagedSummaryDoAsync<MercadoDto, MERCADO>(1, DefaultPage);
                return helper;
            });
            _assistMapper.Configure("RESELLER_ASSIST", async (query) =>
            {
                var helper = await _helperDataServices.GetPagedSummaryDoAsync<ResellerDto, VENDEDOR>(1, DefaultPage);
                return helper;
            });
            _assistMapper.Configure("SUBLICEN", async (query) =>
            {
                var helper = await _helperDataServices.GetPagedSummaryDoAsync<CompanyDto, SUBLICEN>(1, DefaultPage);
                return helper;
            });

            _assistMapper.Configure("ACTIVITY_ASSIST", async (query) =>
            {
                var helper = await _helperDataServices.GetPagedSummaryDoAsync<ActividadDto, ACTIVI>(1, DefaultPage);
                return helper;
            });
            _assistMapper.Configure("RENT_USAGE_ASSIST", async (query) =>
            {
                var helper = await _helperDataServices.GetPagedSummaryDoAsync<RentingUseDto, USO_ALQUILER>(1, DefaultPage);
                return helper;
            });
            _assistMapper.Configure("OFFICE_ZONE_ASSIST", async (query) =>
            {
                var helper = await _helperDataServices.GetPagedSummaryDoAsync<ZonaOfiDto, ZONAOFI>(1, DefaultPage);
                return helper;
            });

            _assistMapper.Configure("CLIENT_PAYMENT_FORM", async (query) =>
            {
                var helper = await _helperDataServices.GetPagedSummaryDoAsync<PaymentFormDto, FORMAS>(1, DefaultPage);
                return helper;
            });
            _assistMapper.Configure("CLIENT_ZONE", async (query) =>
            {
                var helper = await _helperDataServices.GetPagedSummaryDoAsync<ClientZoneDto, ZONAS>(1, DefaultPage);
                return helper;
            });
            _assistMapper.Configure("CLIENT_INVOICE_BLOCKS", async (query) =>
            {

                var helper = await _helperDataServices.GetPagedSummaryDoAsync<InvoiceBlockDto, BLOQUEFAC>(1, DefaultPage);
                return helper;
            });
            _assistMapper.Configure("CLIENT_BROKER", async (query) =>
            {
                var helper = await _dataServices.GetCommissionAgentDataServices().GetPagedSummaryDoAsync(1, DefaultPage);
                return helper;
            });
            _assistMapper.Configure("CLIENT_TYPE", async (query) =>
            {
                var helper = await _helperDataServices.GetPagedSummaryDoAsync<ClientTypeDto, TIPOCLI>(1, DefaultPage);
                return helper;
            });
            _assistMapper.Configure("BUDGET_KEY", async (query) =>
            {
                var helper = await _helperDataServices.GetPagedSummaryDoAsync<BudgetKeyDto, CLAVEPTO>(1, DefaultPage);
                return helper;
            });
            _assistMapper.Configure("CHANNEL_TYPE", async (query) =>
            {
                var helper = await _helperDataServices.GetPagedSummaryDoAsync<ChannelDto, CANAL>(1, DefaultPage);
                return helper;
            });
            _assistMapper.Configure("CLIENT_BUDGET", async (query) =>
            {
                var helper = await _helperDataServices.GetPagedSummaryDoAsync<BudgetKeyDto, CLAVEPTO>(1, DefaultPage);
                return helper;
            });
            _assistMapper.Configure("CREDIT_CARD", async (query) =>
            {
                var helper = await _helperDataServices.GetPagedSummaryDoAsync<CreditCardDto, TARCREDI>(1, DefaultPage);
                return helper;
            });
            _assistMapper.Configure("CLIENT_DRIVER", async (query) =>
            {
                var helper = await _dataServices.GetClientDataServices().GetSummaryDo(GenericSql.ExtendedClientsSummaryQuery);
                return helper;
            });
            _assistMapper.Configure("INVOICE_ASSIST", async (query) =>
            {
                var helper = await _dataServices.GetInvoiceDataServices().GetPagedSummaryDoAsync(1, DefaultPage);
                return helper;
            });
            _assistMapper.Configure("CLIENT_ASSIST", async (query) =>
            {
                var helper = await _dataServices.GetClientDataServices().GetSummaryDo(GenericSql.ExtendedClientsSummaryQuery);
                return helper;
            });
            _assistMapper.Configure("BROKER_ASSIST", async (query) =>
            {
                var helper = await _dataServices.GetCommissionAgentDataServices().GetSummaryDoAsync();
                return helper;
            });
            _assistMapper.Configure("TIPOPROVE", async (query) =>
            {
                var helper = await _helperDataServices.GetPagedSummaryDoAsync<SupplierTypeDto, TIPOPROVE>(1, DefaultPage);
                return helper;
            });
            _assistMapper.Configure("VIASPEDIPRO", async (query) =>
            {
                var helper = await _helperDataServices.GetPagedSummaryDoAsync<DeliveringWayDto, VIASPEDIPRO>(1, DefaultPage);
                return helper;
            });
        }

        private void LoadMoreBrokers(uint arg1, int arg2)
        {
            throw new NotImplementedException();
        }

        private void LoadMoreBusiness(uint arg1, int arg2)
        {
            throw new NotImplementedException();
        }

        private void LoadMoreBanks(uint arg1, int arg2)
        {
            throw new NotImplementedException();
        }
    }
}
