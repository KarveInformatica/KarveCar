using System;
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
using DataAccessLayer.Crud;
using System.Reflection;
using System.Collections;

namespace DataAccessLayer.Crud.Clients
{
    /// <summary>
    /// This load and expose a client wrapper.
    /// </summary>
    internal  sealed partial class ClientDataLoader : IDataLoader<ClientDto>
    {
        private ISqlExecutor _sqlExecutor;
        private IMapper _mapper;
        private ClientDto _currentPoco;
        private IHelperData _helper = new HelperBase();
        private long _currentQueryPos;
        private QueryStoreFactory _queryStoreFactory;

        private EntityMapper _entityMapper = new EntityMapper();
        /// <summary>
        ///  Query delegation.
        /// </summary>
        private string _queryDelegations = "SELECT cldIdDelega,{0},PV.PROV AS NOM_PROV, PV.SIGLAS FROM cliDelega CC " +
                                           "LEFT OUTER JOIN PROVINCIA PV ON PV.SIGLAS = CC.cldIdProvincia" +
                                           " WHERE cldIdCliente='{1}' ORDER BY CC.cldIdDelega";
        /// <summary>
        /// Contacts Query.
        /// </summary>
        /*
        private string _queryContactos = "SELECT ccoIdContacto, ccoContacto,DL.cldIdDelega as idDelegacion, DL.cldDelegacion as nombreDelegacion, " +
                                         "NIF, ccoCargo, ccoTelefono, ccoMovil, ccoFax, ccoMail, CC.ULTMODI as ULTMODI, " +
                                         "CC.USUARIO as USUARIO FROM CliContactos AS CC " +
                                         "LEFT OUTER JOIN PERCARGOS AS PG ON CC.ccoCargo = PG.CODIGO " +
                                         "LEFT OUTER JOIN CliDelega AS DL ON CC.ccoIdDelega = DL.CLDIDDELEGA " +
                                         "AND CC.ccoIdCliente = DL.cldIdCliente  WHERE cldIdCliente = '{0}' ORDER BY CC.ccoContacto";
                                         */
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
        private IEnumerable<BranchesDto> branchesDto;
        /// <summary>
        /// This load a client using a valid executro.
        /// </summary>
        /// <param name="executor">Sql executor</param>
        public ClientDataLoader(ISqlExecutor executor)
        {
            _sqlExecutor = executor;
            _mapper = MapperField.GetMapper();
            _currentPoco = new ClientDto();
            _currentPoco.Helper = new HelperBase(); 
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

            IList<object> entities = new List<object>() { new POBLACIONES(),
                new TIPOCLI(),
                new MERCADO(),
                new ZONAS(),
                new IDIOMAS(),
                new TARCREDI(),
                new CANAL(),
                new SUBLICEN(),
                new OFICINAS(),
                new USO_ALQUILER(),
                new ACTIVI(),
                new ClientSummaryDto(),
                new CliContactsPoco(),
                new PaymentFormDto()
            };
            IList<object> dto = new List<object>()
            {
                new CityDto(),
                new ClientTypeDto(),
                new MercadoDto(),
                new ClientZoneDto(),
                new LanguageDto(),
                new CreditCardDto(),
                new ChannelDto(),
                new CompanyDto(),
                new OfficeDtos(),
                new RentingUseDto(),
                new ActividadDto(),
                new ClientSummaryDto(),
                new CliContactsPoco(),
                new PaymentFormDto()
            };

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
                    SqlMapper.GridReader reader = null;
                    IQueryStore store = CreateQueryStore(_currentPoco);
                    string multipleQuery = store.BuildQuery();
                    if (!string.IsNullOrEmpty(multipleQuery))
                    {
                        reader = await conn.QueryMultipleAsync(multipleQuery);
                        EntityDeserializer deserializer = new EntityDeserializer(entities, dto);
                        var mappedEntity = _entityMapper.Map(reader, deserializer);             
                        string delega = string.Format(_queryDelegations, DefaultDelegation, _currentPoco.NUMERO_CLI);
                        _currentPoco.Helper.ActivityDto =
                            deserializer.SelectDto<ACTIVI, ActividadDto>(_mapper, mappedEntity);
                        _currentPoco.Helper.CityDto = deserializer.SelectDto<POBLACIONES, CityDto>(_mapper, mappedEntity);
                        _currentPoco.Helper.ClientTypeDto =
                            deserializer.SelectDto<TIPOCLI, ClientTypeDto>(_mapper, mappedEntity);
                        _currentPoco.Helper.ClientMarketDto =
                            deserializer.SelectDto<MERCADO, MercadoDto>(_mapper, mappedEntity);

                        var delegations = await conn.QueryAsync<CliDelegaPoco, PROVINCIA, CliDelegaPoco>(delega,
                            (branch, prov) =>
                            {
                                branch.PROV = prov;
                                return branch;
                            }, splitOn: "SIGLAS");

                        if (delegations != null)
                        {
                            branchesDto =
                                _mapper.Map<IEnumerable<CliDelegaPoco>, IEnumerable<BranchesDto>>(delegations);
                        }
                    }
                }
                if (_currentPoco != null)
                {
                    returnValue = true;
                    Valid = true;

                }
            }

            return returnValue;
        }

      
        /// <summary>
        ///  Return all dtos mapped from the entities.
        /// </summary>
        /// <returns>This returns a list of entities</returns>
        public async Task<IEnumerable<ClientDto>> LoadAsyncAll()
        {
            ObservableCollection<ClientDto> dtoCollection =  new ObservableCollection<ClientDto>();
            using (IDbConnection conn = _sqlExecutor.OpenNewDbConnection())
            {
                IEnumerable<CLIENTES1> cli1 = await conn.GetAsyncAll<CLIENTES1>();
                IEnumerable<CLIENTES2> cli2 = await conn.GetAsyncAll<CLIENTES2>();
                var poco1 = _mapper.Map<IEnumerable<CLIENTES1>, IEnumerable<ClientPoco>>(cli1);
                var poco2 = _mapper.Map<IEnumerable<CLIENTES2>, IEnumerable<ClientPoco>>(cli2);
                var sortedPoco1 = poco1.OrderBy(x =>x.NUMERO_CLI);
                var sortedPoco2 = poco2.OrderBy(x => x.NUMERO_CLI);
                IEnumerator<ClientPoco> iter = sortedPoco2.GetEnumerator();
                ClientPoco second = iter.Current;
                List<ClientPoco> mergedValue = new List<ClientPoco>();
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
                _mapper.Map<IEnumerable<ClientPoco>, IEnumerable<ClientDto>>(mergedValue, dtoCollection);
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
            return dto;
        }
        private IQueryStore CreateQueryStore(ClientDto clientPoco)
        {
            IQueryStore store = _queryStoreFactory.GetQueryStore();
            store.AddParam(QueryType.QueryCity, clientPoco.CP);
            store.AddParam(QueryType.QueryClientType, clientPoco.TIPOCLI);
            store.AddParam(QueryType.QueryMarket, clientPoco.MERCADO);
            store.AddParam(QueryType.QueryZone, clientPoco.ZONA);
            store.AddParam(QueryType.QueryLanguage, ValueToString(clientPoco.IDIOMA));
            store.AddParam(QueryType.QueryCreditCard, clientPoco.TARTI);
            store.AddParam(QueryType.QueryChannel, clientPoco.CANAL);
            store.AddParam(QueryType.QueryCompany, clientPoco.SUBLICEN);
            store.AddParam(QueryType.QueryOffice, clientPoco.OFICINA);
            store.AddParam(QueryType.QueryRentingUse, ValueToString(clientPoco.USO_ALQUILER));
            store.AddParam(QueryType.QueryActivity, clientPoco.SECTOR);
            store.AddParam(QueryType.QueryClientSummary, clientPoco.CLIENTEFAC);
            store.AddParam(QueryType.QueryClientContacts, clientPoco.NUMERO_CLI);
            store.AddParam(QueryType.QueryPaymentForm, ValueToString(clientPoco.FPAGO));
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
            var pocoReader = await conn.QueryMultipleAsync(query);
            var clients1 = pocoReader.Read<CLIENTES1>().FirstOrDefault();
            var clients2 = pocoReader.Read<CLIENTES2>().FirstOrDefault();
            ClientDto outClient = new ClientDto();
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

        private string ValueToString(byte? b)
        {
            if (b.HasValue)
            {
                var value = (b == 0) ? "0" : "1";
                return value;
            }
            return string.Empty;
        }
        /// <summary>
        /// It load at most n entities. It retains the state in order to support paging.
        /// </summary>
        /// <param name="n">Number of state.</param>
        /// <returns>It returns a list of n client data transfer objects</returns>
        public async Task<IEnumerable<ClientDto>> LoadValueAtMostAsync(int n, int back)
        {
            IEnumerable<ClientDto> dtoCollection = new List<ClientDto>();
            IQueryStore store =  _queryStoreFactory.GetQueryStore();
            store.AddParamRange(QueryType.QueryPagedClient, _currentQueryPos, n);
            var query = store.BuildQuery();
            _currentQueryPos = _currentQueryPos + n - back; 
            using (IDbConnection conn = _sqlExecutor.OpenNewDbConnection())
            {
               var currentPoco  = await conn.QueryAsync<ClientPoco>(query);
               dtoCollection = _mapper.Map<IEnumerable<ClientPoco>, IEnumerable<ClientDto>>(currentPoco);
            }   
            return dtoCollection;
        }
    }

}