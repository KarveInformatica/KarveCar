using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using AutoMapper;
using Dapper;
using DataAccessLayer.DataObjects;
using DataAccessLayer.Logic;
using DataAccessLayer.SQL;
using KarveDapper.Extensions;
using KarveDataServices;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;
using NLog;

namespace DataAccessLayer.Model
{
    /// <summary>
    ///  Wrapper of the domain object for the client.
    ///  It is useful for detecting changes and working with client related tables. 
    /// </summary>
    public class Client : DomainObject, IClientData
    {
        protected Logger Logger = LogManager.GetCurrentClassLogger();

        private const string Clientes =
            " SELECT {0} FROM CLIENTES1 INNER JOIN CLIENTES2 ON CLIENTES1.NUMERO_CLI=CLIENTES2.NUMERO_CLI {1}";

        /// <summary>
        /// Delegation Query
        /// </summary>
        private string _queryDelegations = "SELECT cldIdDelega,{0},PV.PROV AS NOM_PROV, PV.SIGLAS FROM cliDelega CC " +
                                          "LEFT OUTER JOIN PROVINCIA PV ON PV.SIGLAS = CC.cldIdProvincia" +
                                          " WHERE cldIdCliente='{1}' ORDER BY CC.cldIdDelega";
        /// <summary>
        /// Contacts Query.
        /// </summary>
        private string _queryContactos = "SELECT ccoIdContacto, ccoContacto,DL.cldIdDelega as idDelegacion, DL.cldDelegacion as nombreDelegacion, " +
                                         "NIF, ccoCargo, ccoTelefono, ccoMovil, ccoFax, ccoMail, CC.ULTMODI as ULTMODI, " +
                                         "CC.USUARIO as USUARIO FROM CliContactos AS CC " +
                                         "LEFT OUTER JOIN PERCARGOS AS PG ON CC.ccoCargo = PG.CODIGO " +
                                         "LEFT OUTER JOIN CliDelega AS DL ON CC.ccoIdDelega = DL.CLDIDDELEGA " +
                                         "AND CC.ccoIdCliente = DL.cldIdCliente  WHERE cldIdCliente = '{0}' ORDER BY CC.ccoContacto";



        /// <summary>
        /// Branches fields
        /// </summary>
        private const string DefaultDelegation =
            "cldIdCliente, cldDelegacion, cldDireccion1, cldDireccion2, cldCP, cldPoblacion, cldIdProvincia,cldTelefono1, cldTelefono2, cldFax, cldEMail, cldMovil";

        private const string WhereClause = " WHERE NUMERO_CLI='{0}';";
        private string _currentFlags = "*";

        private IMapper _mapper;
        private ISqlExecutor _sqlExecutor;
        private ClientPoco _currentPoco;
        private IList<string> _fieldList = new List<string>();



        /// <summary>
        ///  Client constructor
        /// </summary>
        /// <param name="executor">Executor of sql.</param>
        public Client(ISqlExecutor executor)
        {

            _sqlExecutor = executor;
            _mapper = MapperField.GetMapper();

        }
        /// <summary>
        /// List of fields to be used  
        /// </summary>
        public IList<string> FieldList
        {
            get { return _fieldList; }
            set => SetCurrentFields(value);
        }
        /// <summary>
        /// Set the current fields
        /// </summary>
        /// <param name="fieldList"> List of fields to be used</param>
        private void SetCurrentFields(IList<string> fieldList)
        {
            // precondition.
            Contract.Assert(fieldList != null, "Cannot set the field list to null");
            StringBuilder sb = new StringBuilder();
            _fieldList = fieldList;
            int j = 0;
            foreach (var value in _fieldList)
            {
                sb.Append(value);
                if (j < _fieldList.Count - 1)
                {
                    sb.Append(",");
                }
                j++;
            }
            // post condition.
            Contract.Assert(_currentFlags.Length > 0, "Length is not ok");
        }

        private async Task<ClientPoco> GetClientAsync(IDbConnection conn, string code)
        {
            var clients1 = await conn.GetAsync<CLIENTES1>(code);
            var clients2 = await conn.GetAsync<CLIENTES2>(code);
            var poco1 = _mapper.Map<CLIENTES1, ClientPoco>(clients1);
            var poco2 = _mapper.Map<CLIENTES2, ClientPoco>(clients2);
            // merges clients to a single entity.
            MergePOCO<ClientPoco> merger = new MergePOCO<ClientPoco>();
            IDictionary<string, ClientPoco> ctx = new Dictionary<string, ClientPoco>();
            ctx.Add(MergePOCO<ClientPoco>.EntityName, poco2);
            ClientPoco poco = merger.Convert(poco1, ctx);
            return poco;
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
                    return "0";

                return "1";
            }
            return string.Empty;
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
               
                CitiesDto = GetMappedValue<POBLACIONES, CityDto>(reader.Read<POBLACIONES>()
                    .FirstOrDefault());
            }
            if (!string.IsNullOrEmpty(clientPoco.TIPOCLI))
            {
                ClientTypeDto = GetMappedValue<TIPOCLI, ClientTypeDto>(reader.Read<TIPOCLI>()
                    .FirstOrDefault());
            }
            if (!string.IsNullOrEmpty(clientPoco.MERCADO))
            {
                ClientMarketDto = GetMappedValue<MERCADO, MercadoDto>(reader.Read<MERCADO>()
                    .FirstOrDefault());
            }
            if (!string.IsNullOrEmpty(clientPoco.ZONA))
            {
                ClientZonaDto =  GetMappedValue<ZONAS, ClientZoneDto>(reader.Read<ZONAS>().FirstOrDefault());
            }
            if (clientPoco.IDIOMA.HasValue)
            {
                LanguageDto = GetMappedValue<IDIOMAS, LanguageDto>(reader.Read<IDIOMAS>().FirstOrDefault());
            }
            if (!string.IsNullOrEmpty(clientPoco.TARTI))
            {
                CreditCardDto = GetMappedValue<TARCREDI, CreditCardDto>(reader.Read<TARCREDI>().FirstOrDefault());
            }
            if (!string.IsNullOrEmpty(clientPoco.CANAL))
            {
                ChannelDto = GetMappedValue<CANAL, ChannelDto>(reader.Read<CANAL>().FirstOrDefault());
            }
            if (!string.IsNullOrEmpty(clientPoco.SUBLICEN))
            {
                CompanyDto = GetMappedValue<SUBLICEN, CompanyDto>(reader.Read<SUBLICEN>().FirstOrDefault());
            }
            if (!string.IsNullOrEmpty(clientPoco.OFICINA))
            {
                OfficeDto = GetMappedValue<OFICINAS, OfficeDtos>(reader.Read<OFICINAS>().FirstOrDefault());
            }
            if ((clientPoco.USO_ALQUILER.HasValue) && (clientPoco.USO_ALQUILER > 0))
            {
                RentUsageDto =
                    GetMappedValue<USO_ALQUILER, RentingUseDto>(reader.Read<USO_ALQUILER>().FirstOrDefault());
            }
            if (!string.IsNullOrEmpty(clientPoco.SECTOR))
            {
                ActivityDto = GetMappedValue<ACTIVI, ActividadDto>(reader.Read<ACTIVI>().FirstOrDefault());
            }
            if (!string.IsNullOrEmpty(clientPoco.CLIENTEFAC))
            {
                var cli = reader.Read<ClientSummaryDto>().FirstOrDefault();
                var drivers = new ObservableCollection<ClientSummaryDto>();
                drivers.Add(cli);
                DriversDto = drivers;
            }
            IEnumerable<CliContactsPoco> con = reader.Read<CliContactsPoco>();
            ContactsDto = _mapper.Map<IEnumerable<CliContactsPoco>, IEnumerable<ContactsDto>>(con);
            if (_currentPoco.FPAGO.HasValue)
            {
                PaymentFormDto = GetMappedValue<FORMAS, PaymentFormDto>(reader.Read<FORMAS>().FirstOrDefault());
            }
        }
        /// <summary>
        /// This load the value of clients.
        /// </summary>
        /// <param name="code">Client code primary key</param>
        /// <returns></returns>
        public async Task<bool> LoadValue(string code)
        {
            Contract.Assert(!string.IsNullOrEmpty(code), "Client code shall be not empty");
            IDbConnection conn = null;
            bool returnValue = false;
            if (_sqlExecutor.Connection.State == ConnectionState.Open)
            {
                conn = _sqlExecutor.Connection;
            }
            else
            {
                _sqlExecutor.Open();
                conn = _sqlExecutor.Connection;
            }
            if (conn != null)
            {

                Stopwatch wait = new Stopwatch();
                wait.Start();
                _currentPoco = await LoadEntity(conn, code);
                if (_currentPoco != null)
                {
                    SqlMapper.GridReader reader = null;
                    QueryStore store = CreateQueryStore(_currentPoco);
                    string multipleQuery = store.BuildQuery();
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
                        BranchesDto = _mapper.Map<IEnumerable<CliDelegaPoco>, IEnumerable<BranchesDto>>(delegations);
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



        private async Task<ObservableCollection<DataTransfer>> GetMappedAsync<T, DataTransfer>(string id, IDbConnection connection) where T : class
            where DataTransfer : class, new()
        {

            Contract.Assert(connection != null, "Connection shall be not null!");
            ObservableCollection<DataTransfer> transfer = new ObservableCollection<DataTransfer>();
            if (string.IsNullOrEmpty(id))
            {
                return transfer;
            }
            var current = await connection.GetCodeNameAsync<T>(id);
            if (current != null)
            {
                var value = _mapper.Map<T, DataTransfer>(current);
                transfer.Add(value);
                Contract.Ensures(transfer.Count > 0, "Count is not null");
            }
            return transfer;
        }

        private ObservableCollection<DataTransfer> GetMappedValue<T, DataTransfer>(T entity) where T : class
            where DataTransfer : class, new()
        {


            ObservableCollection<DataTransfer> transfer = new ObservableCollection<DataTransfer>();
            if (entity == null)
            {
                return transfer;
            }
            var value = _mapper.Map<T, DataTransfer>(entity);
            transfer.Add(value);
            Contract.Ensures(transfer.Count > 0, "Count is not null");
            return transfer;
        }
        private async Task<ObservableCollection<DataTransfer>> GetMappedAsync<T, DataTransfer>(byte id, IDbConnection connection) where T : class
            where DataTransfer : class, new()
        {
            Contract.Assert(connection != null, "Connection shall be not null!");
            ObservableCollection<DataTransfer> transfer = new ObservableCollection<DataTransfer>();
            var current = await connection.GetAsync<T>(id);
            if (current != null)
            {
                var value = _mapper.Map<T, DataTransfer>(current);
                transfer.Add(value);
                Contract.Ensures(transfer.Count > 0, "Count is not null");
            }
            return transfer;
        }
        private async Task<ObservableCollection<DataTransfer>> GetMappedTableAsync<T, DataTransfer>(string id,
            string table, IDbConnection connection) where T : class
            where DataTransfer : class, new()
        {

            Contract.Assert(connection != null, "Connection shall be not null!");
            ObservableCollection<DataTransfer> transfer = new ObservableCollection<DataTransfer>();
            var current = await connection.GetCodeNameAsync<T>(id);
            if (current != null)
            {
                var value = _mapper.Map<T, DataTransfer>(current);
                transfer.Add(value);
                Contract.Ensures(transfer.Count > 0, "Count is not null");
            }
            return transfer;
        }
        /// <summary>
        ///  This save all clients.
        /// </summary>
        /// <returns></returns>
        public async Task<bool> SaveAll()
        {
            IDbConnection connection = null;
            Contract.Assert(_currentPoco != null, "Invalid Poco");
            CLIENTES1 client1 = _mapper.Map<ClientPoco, CLIENTES1>(_currentPoco);
            CLIENTES2 client2 = _mapper.Map<ClientPoco, CLIENTES2>(_currentPoco);
            bool retValue = false;
            if ((client1 == null) || (client2 == null))
            {
                return false;
            }

            using (connection = _sqlExecutor.OpenNewDbConnection())
            {
                try
                {
                    ObservableCollection<CityDto> cityDto = await GetMappedAsync<POBLACIONES, CityDto>(client1.CP, connection);
                    var currentCity = cityDto.FirstOrDefault();
                    client1.POBLACION = currentCity?.Poblacion;

                    using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                    {
                        var present = connection.IsPresent<CLIENTES1>(client1);
                        if (!present)
                        {
                            retValue = await connection.InsertAsync<CLIENTES1>(client1) > 0;
                            if (retValue)
                            {
                                retValue = await connection.InsertAsync<CLIENTES2>(client2) > 0;
                            }
                        }
                        else
                        {
                            retValue = await connection.UpdateAsync<CLIENTES1>(client1);
                            if (retValue)
                            {
                                retValue = await connection.UpdateAsync<CLIENTES2>(client2);
                            }
                        }
                        scope.Complete();
                    }
                }
                finally
                {
                    connection.Close();
                }
            }
            Contract.Ensures(connection.State == ConnectionState.Closed);
            return retValue;
        }

        public async Task<bool> DeleteAsync()
        {
            Contract.Assert(_currentPoco != null, "Invalid Poco");
            CLIENTES1 client1 = _mapper.Map<ClientPoco, CLIENTES1>(_currentPoco);
            CLIENTES2 client2 = _mapper.Map<ClientPoco, CLIENTES2>(_currentPoco);
            bool retValue = false;
            if ((client1 == null) || (client2 == null))
            {
                return false;
            }

            using (IDbConnection connection = _sqlExecutor.OpenNewDbConnection())
            {
                try
                {
                    ObservableCollection<CityDto> cityDto = await GetMappedAsync<POBLACIONES, CityDto>(client1.CP, connection);
                    var currentCity = cityDto.FirstOrDefault();
                    client1.POBLACION = currentCity?.Poblacion;
                    using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                    {
                        var present = connection.IsPresent<CLIENTES1>(client1);
                        if (present)
                        {
                            retValue = await connection.InsertAsync<CLIENTES1>(client1) > 0;
                            if (retValue)
                            {
                                retValue = await connection.InsertAsync<CLIENTES2>(client2) > 0;
                            }
                        }
                        scope.Complete();
                    }
                }
                finally
                {
                    connection.Close();
                }
            }
            return retValue;
        }

        private ClientesDto ConvertFromPoco(ClientPoco poco)
        {
            Contract.Assert(_mapper != null, "Mapping shall be initialized");
            var value = _mapper.Map<ClientPoco, ClientesDto>(poco);
            Contract.Ensures(value != null, "Mapping shall be done correctly");
            return value;
        }
        private ClientPoco ConvertFromDto(ClientesDto poco)
        {
            Contract.Assert(_mapper != null, "Mapping shall be initialized");
            var value = _mapper.Map<ClientesDto, ClientPoco>(poco);
            Contract.Ensures(value != null, "Mapping shall be done correctly");
            return value;
        }
        public ClientesDto Value
        {
            get
            {
                var valueClientesDto = ConvertFromPoco(_currentPoco);
                valueClientesDto.BranchesDto = BranchesDto;
                valueClientesDto.ContactsDto = ContactsDto;
                return valueClientesDto;
            }
            set => _currentPoco = ConvertFromDto(value);
        }
        public bool Valid { get; set; }

        public IEnumerable<ProvinciaDto> ProvinciaDto { get; set; }
        public IEnumerable<PaymentFormDto> PaymentFormDto { get; set; }
        public IEnumerable<CountryDto> CountryDto { get; set; }
        public IEnumerable<ClientZoneDto> ZoneDto { get; set; }
        public IEnumerable<OrigenDto> OrigenDto { get; set; }
        public IEnumerable<CityDto> CityDto { get; set; }
        public IEnumerable<MercadoDto> ClientMarketDto { get; set; }
        public IEnumerable<ResellerDto> ResellerDto { get; set; }
        public IEnumerable<ClientTypeDto> ClientTypeDto { get; set; }
        public IEnumerable<CompanyDto> CompanyDto { get; set; }
        public IEnumerable<OfficeDtos> OfficeDto { get; set; }
        public IEnumerable<CreditCardDto> CreditCardType { get; set; }
        public IEnumerable<CityDto> CitiesDto { get; set; }
        public IEnumerable<ClientZoneDto> ClientZonaDto { get; set; }
        public IEnumerable<CreditCardDto> CreditCardDto { get; set; }
        public IEnumerable<LanguageDto> LanguageDto { get; set; }
        public IEnumerable<ActividadDto> ActivityDto { get; set; }
        public IEnumerable<BusinessDto> BusinessDto { get; set; }
        public IEnumerable<ChannelDto> ChannelDto { get; set; }
        public IEnumerable<BudgetKeyDto> BudgetKeyDto { get; set; }
        public IEnumerable<PaymentFormDto> ClientPaymentForm { get; set; }
        public IEnumerable<InvoiceBlockDto> InvoiceBlock { get; set; }
        public IEnumerable<CommissionAgentSummaryDto> BrokerDto { get; set; }
        public IEnumerable<RentingUseDto> RentUsageDto { get; set; }
        public IEnumerable<BranchesDto> BranchesDto { get; private set; }
        public IEnumerable<ContactsDto> ContactsDto { get; private set; }
        public IEnumerable<ClientSummaryDto> DriversDto { get; set; }
    }
}
