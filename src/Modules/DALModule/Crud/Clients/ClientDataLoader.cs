using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using Dapper;
using DataAccessLayer.DataObjects;
using DataAccessLayer.Logic;
using DataAccessLayer.SQL;
using KarveDapper.Extensions;
using NLog;
using System;

namespace DataAccessLayer.Crud.Clients
{
    /// <summary>
    /// This load and expose a client wrapper.
    /// </summary>
    internal  sealed partial class ClientDataLoader : IDataLoader<ClientDto>
    {
        private readonly ISqlExecutor _sqlExecutor;
        private readonly IMapper _mapper;
        private readonly QueryStoreFactory _queryStoreFactory;
        private IHelperData _helper = new HelperBase();
        /// <summary>
        /// in some case i log even if it is an antipattern.
        /// </summary>
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private ClientDto _currentPoco;
        private long _currentQueryPos;
        /// <summary>
        ///  Query delegation.
        /// </summary>
        private string _queryDelegations = "SELECT cldIdDelega,{0},PV.PROV AS NOM_PROV, PV.SIGLAS FROM cliDelega CC " +
                                           "LEFT OUTER JOIN PROVINCIA PV ON PV.SIGLAS = CC.cldIdProvincia" +
                                           " WHERE cldIdCliente='{1}' ORDER BY CC.cldIdDelega";
        /// <summary>
        /// Contacts Query.
        /// </summary>
       
        // set if the load is valid or not.
        public bool Valid { set; get; }

        public IHelperData Helper
        {
            get { return _helper; }
            set { _helper = value; }
        }


        /// <summary>
        /// Branches fields
        /// </summary>
        private const string DefaultDelegation =
            "cldIdCliente, cldDelegacion, cldDireccion1, cldDireccion2, cldCP, cldPoblacion, cldIdProvincia,cldTelefono1, cldTelefono2, cldFax, cldEMail, cldMovil";
        
        /// <summary>
        /// This load a client using a valid executro.
        /// </summary>
        /// <param name="executor">Sql executor</param>
        public ClientDataLoader(ISqlExecutor executor)
        {
            _sqlExecutor = executor;
            _mapper = MapperField.GetMapper();
            _currentPoco = new ClientDto {Helper = new HelperBase()};

            Valid = true;
            _currentQueryPos = 0;
            _queryStoreFactory = new QueryStoreFactory();
        }
        /// <summary>
        ///  Open a connection.
        /// </summary>
        /// <returns>This open a client connection.</returns>
        public IDbConnection OpenConnection()
        {
            IDbConnection conn = null;
            if (_sqlExecutor.Connection.State == ConnectionState.Open)
            {
                conn = _sqlExecutor.Connection;
            }
            else
            {
                _sqlExecutor.Open();
                conn = _sqlExecutor.Connection;
            }
            return conn;
        }

        private IEnumerable<DtoType> SelectDto<EntityType, DtoType>(IMapper mapper, SqlMapper.GridReader gridReader) where DtoType: class
        {
            
            var hasValue = gridReader.ReadSingle<int>() > 0;
            if (hasValue)
            {
                var entityCollection = gridReader.Read<EntityType>();
                if (entityCollection != null)
                {
                    if (typeof(EntityType) != typeof(DtoType))
                    {
                        return mapper.Map<IEnumerable<EntityType>, IEnumerable<DtoType>>(entityCollection);
                    }
                    else
                    {
                        return entityCollection as IEnumerable<DtoType>;
                    }
                }
            }
            else
            {
            var badValue =   gridReader.Read();
            }
            var list = new List<DtoType>();
            return list;
        }

        private IEnumerable<DtoType> WrappedSelectedDto<EntityType, DtoType>(object value, IMapper mapper, SqlMapper.GridReader reader) where DtoType: class
        {
            if (value == null)
            {
                return new List<DtoType>();
            }
            try
            {
                
                var current = SelectDto<EntityType, DtoType>(mapper, reader);
                return current;
            } catch (System.Exception ex)
            {
                return new List<DtoType>();
            }
        }
        /// <summary>
        ///  Load a single client value
        /// </summary>
        /// <param name="code">Code to load</param>
        /// <returns></returns>
        public async Task<bool> LoadValue(string code)
        {
            Contract.Assert(!string.IsNullOrEmpty(code), "Client code shall be not empty");
            IDbConnection conn = null;
            bool returnValue = false;

          

            if (_sqlExecutor.Open())
            {
                conn = _sqlExecutor.Connection;
            }
            if (conn != null)
            {
                // here we shall load the entity and the helpers.
                _currentPoco = await LoadEntity(conn, code);
                // we load the helpers.
                if (_currentPoco != null)
                {
                    IQueryStore store = CreateQueryStore(_currentPoco);
                    string multipleQuery = store.BuildQuery();
                    if (!string.IsNullOrEmpty(multipleQuery))
                    {
                        var reader = await conn.QueryMultipleAsync(multipleQuery).ConfigureAwait(false);
                      
                            if (_currentPoco.Helper != null)
                            {
                                try
                                {
                                    
                                    _currentPoco.Helper.CityDto = WrappedSelectedDto<POBLACIONES, CityDto>(_currentPoco.CP,_mapper, reader);
                                    _currentPoco.Helper.ProvinciaDto = WrappedSelectedDto<PROVINCIA,ProvinciaDto>(_currentPoco.PROVINCIA,_mapper, reader);
                                    _currentPoco.Helper.CountryDto = WrappedSelectedDto<Country,CountryDto>(_currentPoco.NACIODOMI,_mapper, reader);
                                    _currentPoco.Helper.ClientTypeDto = WrappedSelectedDto<TIPOCLI, ClientTypeDto>(_currentPoco.TIPOCLI, _mapper, reader);
                                    _currentPoco.Helper.ClientMarketDto = WrappedSelectedDto<MERCADO, MercadoDto>(_currentPoco.MERCADO, _mapper, reader);
                                    _currentPoco.Helper.ZoneDto = WrappedSelectedDto<ZONAS, ClientZoneDto>(_currentPoco.ZONA, _mapper, reader);
                                    _currentPoco.Helper.LanguageDto = WrappedSelectedDto<IDIOMAS, LanguageDto>(_currentPoco.IDIOMA,_mapper, reader);
                                    _currentPoco.Helper.CreditCardType = WrappedSelectedDto<TARCREDI, CreditCardDto>(_currentPoco.TARTI, _mapper, reader);
                                    _currentPoco.Helper.ChannelDto = WrappedSelectedDto<CANAL, ChannelDto>(_currentPoco.CANAL, _mapper, reader);
                                    _currentPoco.Helper.CompanyDto = WrappedSelectedDto<SUBLICEN, CompanyDto>(_currentPoco.SUBLICEN,_mapper, reader);
                                    _currentPoco.Helper.OfficeDto = WrappedSelectedDto<OFICINAS, OfficeDtos>(_currentPoco.OFICINA, _mapper,reader);
                                    _currentPoco.Helper.ClientPaymentForm = WrappedSelectedDto<FORMAS, PaymentFormDto>(_currentPoco.FPAGO, _mapper, reader);
                                    _currentPoco.Helper.ResellerDto = WrappedSelectedDto<VENDEDOR, ResellerDto>(_currentPoco.VENDEDOR, _mapper, reader);
                                    _currentPoco.Helper.ActivityDto = WrappedSelectedDto<ACTIVI,ActividadDto>(_currentPoco.SECTOR, _mapper, reader);
                                    _currentPoco.Helper.OrigenDto = WrappedSelectedDto<ORIGEN, OrigenDto>(_currentPoco.ORIGEN, _mapper, reader);
                                    _currentPoco.Helper.BusinessDto = WrappedSelectedDto<NEGOCIO, BusinessDto>(_currentPoco.NEGOCIO, _mapper, reader);
                                    _currentPoco.Helper.InvoiceBlock = WrappedSelectedDto<BLOQUEFAC,InvoiceBlockDto>(_currentPoco.BLOQUEFAC, _mapper, reader);
                                    _currentPoco.Helper.BudgetKeyDto = WrappedSelectedDto<CLAVEPTO, BudgetKeyDto>(_currentPoco.CLAVEPTO, _mapper, reader);
                                    _currentPoco.Helper.DriversDto = WrappedSelectedDto<ClientSummaryDto, ClientSummaryDto>(_currentPoco.CLIENTEFAC, _mapper, reader);
                                    _currentPoco.Helper.BrokerDto = WrappedSelectedDto<CommissionAgentSummaryDto, CommissionAgentSummaryDto>(_currentPoco.COMISIO, _mapper, reader);
                                    _currentPoco.ContactsDto = WrappedSelectedDto<CliContactsPoco, ContactsDto>(_currentPoco.NUMERO_CLI,_mapper, reader);
                                    _currentPoco.BranchesDto = WrappedSelectedDto<CliContactsPoco, BranchesDto>(_currentPoco.NUMERO_CLI, _mapper, reader);
                                _currentPoco.Helper.RentUsageDto = WrappedSelectedDto<USO_ALQUILER, RentingUseDto>(_currentPoco.USO_ALQUILER, _mapper, reader);


                            }
                            catch (System.Exception ex)
                                {
                                    // this is an antipatter log and throw but i need the log.
                                    logger.Error(ex.Message);
                                    throw new DataLayerException(ex.Message, ex);
                                }

                            }

                    }
                                           
                }

                if (_currentPoco == null)
                {
                    return returnValue;
                }
                returnValue = true;
                Valid = true;
            }

            return returnValue;
        }

      
        /// <summary>
        ///  Return all dtos mapped from the entities.
        /// </summary>
        /// <returns>This returns a list of entities</returns>
        public async Task<IEnumerable<ClientDto>> LoadAsyncAll()
        {
           IEnumerable<ClientDto> dtoCollection = new ObservableCollection<ClientDto>();
            using (var conn = _sqlExecutor.OpenNewDbConnection())
            {
                var cli1 = await conn.GetAsyncAll<CLIENTES1>();
                var cli2 = await conn.GetAsyncAll<CLIENTES2>();
                var poco1 = _mapper.Map<IEnumerable<CLIENTES1>, IEnumerable<ClientPoco>>(cli1);
                var poco2 = _mapper.Map<IEnumerable<CLIENTES2>, IEnumerable<ClientPoco>>(cli2);
                var sortedPoco1 = poco1.OrderBy(x =>x.NUMERO_CLI);
                var sortedPoco2 = poco2.OrderBy(x => x.NUMERO_CLI);
                IEnumerator<ClientPoco> iter = sortedPoco2.GetEnumerator();
                var second = iter.Current;
                var mergedValue = new List<ClientPoco>();
                foreach (var p in sortedPoco1)
                {
                    MergePOCO<ClientPoco> merger = new MergePOCO<ClientPoco>();
                    IDictionary<string, ClientPoco> ctx = new Dictionary<string, ClientPoco>();
                    ctx.Add(MergePOCO<ClientPoco>.EntityName, second);
                    ClientPoco poco = merger.Convert(p, ctx);
                    iter.MoveNext();
                    second = iter.Current;
                    mergedValue.Add(poco);
                }
                dtoCollection = _mapper.Map<IEnumerable<ClientPoco>, IEnumerable<ClientDto>>(mergedValue, dtoCollection);
                iter.Dispose();

            }
            return dtoCollection;
        }

        /// <summary>
        ///  Load a value asynchronosuly
        /// </summary>
        /// <param name="code">Client code</param>
        /// <returns></returns>
        public async Task<ClientDto> LoadValueAsync(string code)
        {
            var dto = new ClientDto();
            var clientPoco = await LoadValue(code);
            
            if (clientPoco)
            {
                dto = _currentPoco;
            }
            else
            {
                dto.IsValid = false;
            }
            
            return dto;
        }
        private IQueryStore CreateQueryStore(ClientDto clientPoco)
        {
            IQueryStore store = _queryStoreFactory.GetQueryStore();
            
            store.AddParamCount(QueryType.QueryCity, "POBLACIONES", "CP", clientPoco.CP);
            store.AddParamCount(QueryType.QueryProvince, "PROVINCIA", "SIGLAS", clientPoco.PROVINCIA);
            store.AddParamCount(QueryType.QueryCountry, "PAIS", "SIGLAS", clientPoco.NACIODOMI);
            store.AddParamCount(QueryType.QueryClientType, "TIPOCLI", "NUM_TICLI", clientPoco.TIPOCLI);
            store.AddParamCount(QueryType.QueryMarket, "MERCADO", "CODIGO", clientPoco.MERCADO);
            store.AddParamCount(QueryType.QueryZone, "ZONAS", "NUM_ZONA", clientPoco.ZONA);
            store.AddParamCount(QueryType.QueryLanguage, "IDIOMAS", "CODIGO", ValueToString(clientPoco.IDIOMA));
            store.AddParamCount(QueryType.QueryCreditCard, "TARCREDI", "CODIGO",clientPoco.TARTI);
            store.AddParamCount(QueryType.QueryChannel, "CANAL", "CODIGO", clientPoco.CANAL);
            store.AddParamCount(QueryType.QueryCompany, "SUBLICEN", "CODIGO", clientPoco.SUBLICEN);
            store.AddParamCount(QueryType.QueryOffice, "OFICINAS", "CODIGO", clientPoco.OFICINA);
            
            store.AddParamCount(QueryType.QueryPaymentForm, "FORMAS", "CODIGO", ValueToString(clientPoco.FPAGO));
            store.AddParamCount(QueryType.QuerySeller, "VENDEDOR", "NUM_VENDE", clientPoco.VENDEDOR);
            store.AddParamCount(QueryType.QueryActivity, "ACTIVI", "NUM_ACTIVI", clientPoco.SECTOR);
            store.AddParamCount(QueryType.QueryOrigin, "ORIGEN", "NUM_ORIGEN", ValueToString(clientPoco.ORIGEN));
            store.AddParamCount(QueryType.QueryBusiness, "NEGOCIO", "CODIGO", clientPoco.NEGOCIO);
            store.AddParamCount(QueryType.QueryInvoiceBlocks, "BLOQUEFAC", "CODIGO", clientPoco.BLOQUEFAC);
            store.AddParamCount(QueryType.QueryBudgetKey, "CLAVEPTO", "COD_CLAVE", clientPoco.CLAVEPTO);
            store.AddParamCount(QueryType.QueryClientSummary, "CLIENTES1", "NUMERO_CLI", clientPoco.CLIENTEFAC);
            store.AddParamCount(QueryType.QueryCommissionAgentSummaryById, "COMISIO", "NUM_COMI", clientPoco.COMISIO);
            store.AddParamCount(QueryType.QueryClientDelegations, "CliDelega", "cldIdCliente", clientPoco.NUMERO_CLI);
            store.AddParamCount(QueryType.QueryClientContacts, "CliContactos", "ccoIdCliente", clientPoco.NUMERO_CLI);
            store.AddParamCount(QueryType.QueryRentingUse, "USO_ALQUILER", "CODIGO", ValueToString(clientPoco.USO_ALQUILER));
            return store;
        }
        /// <summary>
        /// Load an entity from clients and maps the entity to a data transfer object.
        /// </summary>
        /// <param name="conn">Connection to be used</param>
        /// <param name="code">Code of the entity</param>
        /// <returns>A data transfer object to be loaded.</returns>
        private async Task<ClientDto> LoadEntity(IDbConnection conn, string code)
        {
            IQueryStore clientPocoQueryStore = _queryStoreFactory.GetQueryStore();
            clientPocoQueryStore.AddParam(QueryType.QueryClient1, code);
            clientPocoQueryStore.AddParam(QueryType.QueryClient2, code);
            var query = clientPocoQueryStore.BuildQuery();
            var pocoReader = await conn.QueryMultipleAsync(query).ConfigureAwait(false);
            var clients1 = pocoReader.Read<CLIENTES1>().FirstOrDefault();
            var clients2 = pocoReader.Read<CLIENTES2>().FirstOrDefault();
            var outClient = new ClientDto
            {
                Helper = new HelperBase(),
                IsValid = (clients1!=null) && (clients2!=null)
            };
            var outType = outClient.GetType();
            if (clients1 != null)
            {
                foreach (var propertyInfo in clients1.GetType().GetProperties())
                {
                    var name = propertyInfo.Name;
                    var prop = outType.GetProperty(name);
                    if (prop != null)
                    {
                        // ok we have set the property
                        var v = propertyInfo.GetValue(clients1);
                        if (v != null)
                        {
                            prop.SetValue(outClient, v);
                        }
                    }
                }
            }
            if (clients2 != null)
            {
                foreach (var propertyInfo in clients2.GetType().GetProperties())
                {
                    var name = propertyInfo.Name;
                    var prop = outType.GetProperty(name);
                    if (prop != null)
                    {
                        // ok we have set the property
                        var v = propertyInfo.GetValue(clients2);
                        if (v != null)
                        {
                            prop.SetValue(outClient, v);
                        }
                    }
                }
            }
         
            return outClient;
        }
        private byte NumberToString(byte? b)
        {
            if (!b.HasValue)
            {
                return 0;
            }
            return b.Value;
        }
        private string ValueToString(byte? b)
        {
            if (!b.HasValue)
            {
                return string.Empty;
            }
            var value = Convert.ToString(b);
            return value;
        }
        private string ValueToString(int? b)
        {
            if (!b.HasValue)
            {
                return string.Empty;
            }
            var value = Convert.ToString(b);
            return value;
        }
        /// <summary>
        /// It load at most n entities. It retains the state in order to support paging.
        /// </summary>
        /// <param name="n">Number of state.</param>
        /// <returns>It returns a list of n client data transfer objects</returns>
        public async Task<IEnumerable<ClientDto>> LoadValueAtMostAsync(int n, int back)
        {
            IEnumerable<ClientDto> dtoCollection;
            var store =  _queryStoreFactory.GetQueryStore();
            var currentPos = _currentQueryPos;
            if (currentPos == 0)
            {
                currentPos = 1;
            }
            var query = store.BuildQuery(QueryType.QueryPagedClient, new List<string>() { currentPos.ToString(), n.ToString() });
            _currentQueryPos = _currentQueryPos + n - back; 
            using (var conn = _sqlExecutor.OpenNewDbConnection())
            {
               var currentPoco  = await conn.QueryAsync<ClientPoco>(query).ConfigureAwait(false);
               dtoCollection = _mapper.Map<IEnumerable<ClientPoco>, IEnumerable<ClientDto>>(currentPoco);
            }   
            return dtoCollection;
        }
    }

}