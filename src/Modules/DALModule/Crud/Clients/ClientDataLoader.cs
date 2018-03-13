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

namespace DataAccessLayer.Crud.Clients
{
    /// <summary>
    /// This load and expose a client wrapper.
    /// </summary>
    internal sealed class ClientDataLoader : IDataLoader<ClientDto>
    {
        private ISqlExecutor _sqlExecutor;
        private IMapper _mapper;
        private ClientPoco _currentPoco;
        private IHelperData _helper = new HelperBase();
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
            _currentPoco = new ClientPoco();
            Valid = true;
            _currentQueryPos = 0;
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
                    QueryStore store = CreateQueryStore(_currentPoco);
                    string multipleQuery = store.BuildQuery();
                    if (!string.IsNullOrEmpty(multipleQuery))
                    {
                        reader = await conn.QueryMultipleAsync(multipleQuery);
                        SetDataTransferObject(reader, _currentPoco);
                        string delega = string.Format(_queryDelegations, DefaultDelegation, _currentPoco.NUMERO_CLI);
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
        ///  Set the transfer objects. We create the transfer object from the entity.
        /// </summary>
        /// <param name="reader">GridReader reader of dapper results</param>
        /// <param name="clientPoco">Poco to check if there is a null parameter.</param>
        /// 
        private void SetDataTransferObject(SqlMapper.GridReader reader, ClientPoco clientPoco)
        {
            if (reader == null)
                return;
            if (!string.IsNullOrEmpty(clientPoco.CP))
            {

                Helper.CityDto = MapperUtils.GetMappedValue<POBLACIONES, CityDto>(reader.Read<POBLACIONES>()
                    .FirstOrDefault(), _mapper);
            }
            if (!string.IsNullOrEmpty(clientPoco.TIPOCLI))
            {
                Helper.ClientTypeDto = MapperUtils.GetMappedValue<TIPOCLI, ClientTypeDto>(reader.Read<TIPOCLI>()
                    .FirstOrDefault(), _mapper);
            }
            if (!string.IsNullOrEmpty(clientPoco.MERCADO))
            {
                Helper.ClientMarketDto = MapperUtils.GetMappedValue<MERCADO, MercadoDto>(reader.Read<MERCADO>()
                    .FirstOrDefault(), _mapper);
            }
            if (!string.IsNullOrEmpty(clientPoco.ZONA))
            {
                Helper.ZoneDto = MapperUtils.GetMappedValue<ZONAS, ClientZoneDto>(reader.Read<ZONAS>().FirstOrDefault(), _mapper);
            }
            if (clientPoco.IDIOMA.HasValue)
            {
                Helper.LanguageDto = MapperUtils.GetMappedValue<IDIOMAS, LanguageDto>(reader.Read<IDIOMAS>().FirstOrDefault(), _mapper);
            }
            if (!string.IsNullOrEmpty(clientPoco.TARTI))
            {
                Helper.CreditCardType = MapperUtils.GetMappedValue<TARCREDI, CreditCardDto>(reader.Read<TARCREDI>().FirstOrDefault(), _mapper);
            }
            if (!string.IsNullOrEmpty(clientPoco.CANAL))
            {
                Helper.ChannelDto = MapperUtils.GetMappedValue<CANAL, ChannelDto>(reader.Read<CANAL>().FirstOrDefault(), _mapper);
            }
            if (!string.IsNullOrEmpty(clientPoco.SUBLICEN))
            {
                Helper.CompanyDto = MapperUtils.GetMappedValue<SUBLICEN, CompanyDto>(reader.Read<SUBLICEN>().FirstOrDefault(), _mapper);
            }
            if (!string.IsNullOrEmpty(clientPoco.OFICINA))
            {
                Helper.OfficeDto = MapperUtils.GetMappedValue<OFICINAS, OfficeDtos>(reader.Read<OFICINAS>().FirstOrDefault(), _mapper);
            }
            if ((clientPoco.USO_ALQUILER.HasValue) && (clientPoco.USO_ALQUILER > 0))
            {
                Helper.RentUsageDto =
                    MapperUtils.GetMappedValue<USO_ALQUILER, RentingUseDto>(reader.Read<USO_ALQUILER>().FirstOrDefault(), _mapper);
            }
            if (!string.IsNullOrEmpty(clientPoco.SECTOR))
            {
                Helper.ActivityDto = MapperUtils.GetMappedValue<ACTIVI, ActividadDto>(reader.Read<ACTIVI>().FirstOrDefault(), _mapper);
            }
            if (!string.IsNullOrEmpty(clientPoco.CLIENTEFAC))
            {
                var cli = reader.Read<ClientSummaryDto>().FirstOrDefault();
                var drivers = new ObservableCollection<ClientSummaryDto>();
                drivers.Add(cli);
                Helper.DriversDto = drivers;
            }
            IEnumerable<CliContactsPoco> con = reader.Read<CliContactsPoco>();
            Helper.ContactsDto = _mapper.Map<IEnumerable<CliContactsPoco>, IEnumerable<ContactsDto>>(con);
            if (_currentPoco.FPAGO.HasValue)
            {
                Helper.ClientPaymentForm =
                    MapperUtils.GetMappedValue<FORMAS, PaymentFormDto>(reader.Read<FORMAS>().FirstOrDefault(), _mapper);
            }

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
            var mapper = MapperField.GetMapper();
            if (clientPoco)
            {
                dto = mapper.Map<ClientPoco, ClientDto>(_currentPoco);
            }
            return dto;
        }
        private QueryStore CreateQueryStore(ClientPoco clientPoco)
        {
            QueryStore store = new QueryStore();
            store.AddParam(QueryStore.QueryType.QueryCity, clientPoco.CP);
            store.AddParam(QueryStore.QueryType.QueryClientType, clientPoco.TIPOCLI);
            store.AddParam(QueryStore.QueryType.QueryMarket, clientPoco.MERCADO);
            store.AddParam(QueryStore.QueryType.QueryZone, clientPoco.ZONA);
            store.AddParam(QueryStore.QueryType.QueryLanguage, ValueToString(clientPoco.IDIOMA));
            store.AddParam(QueryStore.QueryType.QueryCreditCard, clientPoco.TARTI);
            store.AddParam(QueryStore.QueryType.QueryChannel, clientPoco.CANAL);
            store.AddParam(QueryStore.QueryType.QueryCompany, clientPoco.SUBLICEN);
            store.AddParam(QueryStore.QueryType.QueryOffice, clientPoco.OFICINA);
            store.AddParam(QueryStore.QueryType.QueryRentingUse, ValueToString(clientPoco.USO_ALQUILER));
            store.AddParam(QueryStore.QueryType.QueryActivity, clientPoco.SECTOR);
            store.AddParam(QueryStore.QueryType.QueryClientSummary, clientPoco.CLIENTEFAC);
            store.AddParam(QueryStore.QueryType.QueryClientContacts, clientPoco.NUMERO_CLI);
            store.AddParam(QueryStore.QueryType.QueryPaymentForm, ValueToString(clientPoco.FPAGO));
            return store;
        }
        private async Task<ClientPoco> LoadEntity(IDbConnection conn, string code)
        {
            QueryStore clientPocoQueryStore = new QueryStore();
            clientPocoQueryStore.AddParam(QueryStore.QueryType.QueryClient1, code);
            clientPocoQueryStore.AddParam(QueryStore.QueryType.QueryClient2, code);
            var query = clientPocoQueryStore.BuildQuery();
            var pocoReader = await conn.QueryMultipleAsync(query);
            var clients1 = pocoReader.Read<CLIENTES1>().FirstOrDefault();
            var clients2 = pocoReader.Read<CLIENTES2>().FirstOrDefault();
            var poco1 = _mapper.Map<CLIENTES1, ClientPoco>(clients1);
            var poco2 = _mapper.Map<CLIENTES2, ClientPoco>(clients2);
            MergePOCO<ClientPoco> merger = new MergePOCO<ClientPoco>();
            IDictionary<string, ClientPoco> ctx = new Dictionary<string, ClientPoco>();
            ctx.Add(MergePOCO<ClientPoco>.EntityName, poco2);
            ClientPoco poco = merger.Convert(poco1, ctx);
            return poco;
        }
        private string ValueToString(byte? b)
        {
            if (b.HasValue)
            {
                if (b == 0)
                {
                    return "0";
                }
                return "1";
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
            QueryStore store = new QueryStore();
            store.AddParamRange(QueryStore.QueryType.QueryPagedClient, _currentQueryPos, n);
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