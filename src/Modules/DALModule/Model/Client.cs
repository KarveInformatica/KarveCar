using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using AutoMapper;
using Dapper;
using DataAccessLayer.DataObjects;
using DataAccessLayer.Logic;
using KarveDapper.Extensions;
using KarveDataServices;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;

namespace DataAccessLayer.Model
{
    /// <summary>
    ///  Wrapper of the domain object for the client.
    ///  It is useful for detecting changes and working with client related tables. 
    /// </summary>
    public class Client : DomainObject, IClientData
    {

        private const string Clientes =
            " SELECT {0} FROM CLIENTES1 INNER JOIN CLIENTES2 ON CLIENTES1.NUMERO_CLI=CLIENTES2.NUMERO_CLI {1}";

        private const string WhereClause = " WHERE NUMERO_CLI='{0}';";
        private string _currentFlags = "*";

        private IMapper _mapper;
        private ISqlExecutor _sqlExecutor;
        private ClientPoco _currentPoco;
        private IList<string> _fieldList = new List<string>();
        private ObservableCollection<ProvinciaDto> _provinciaDtos;
        private ObservableCollection<CountryDto> _countriesDto;
        private ObservableCollection<CityDto> _citiesDto;
        private ObservableCollection<ClientZoneDto> _clientDto;
        private ObservableCollection<OrigenDto> _origenDto;
        private ObservableCollection<ComisioDto> _brokerDto;
        private ObservableCollection<MercadoDto> _clientMarketDto;
        private ObservableCollection<ResellerDto> _resellerDto;
        private ObservableCollection<ClientTypeDto> _clientTypeDto;

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

        /// <summary>
        /// This load the value of clients.
        /// </summary>
        /// <param name="code">Client code primary key</param>
        /// <returns></returns>
        public async Task<bool> LoadValue(string code)
        {
            Contract.Assert(!string.IsNullOrEmpty(code), "Client code shall be not unique");
            //var whereClause = string.Format(WhereClause, code);
           // var query = string.Format(Clientes, _currentFlags, whereClause);
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
                var clients1 = await conn.GetAsync<CLIENTES1>(code);
                var clients2 = await conn.GetAsync<CLIENTES2>(code);
                var poco1 =  _mapper.Map<CLIENTES1, ClientPoco>(clients1);
                var poco2 = _mapper.Map<CLIENTES2, ClientPoco>(clients2);
                // merges clients to a single entity.
                MergePOCO<ClientPoco> merger = new MergePOCO<ClientPoco>();
                IDictionary<string, ClientPoco> ctx = new Dictionary<string, ClientPoco>();
                ctx.Add(MergePOCO<ClientPoco>.EntityName, poco2);
                _currentPoco = merger.Convert(poco1, ctx);
                if (_currentPoco != null)
                {
                    returnValue = true;
                    Valid = true;
   
                }
            }
            return returnValue;
        }

        private async Task<ObservableCollection<DataTransfer>> GetMappedAsync<T, DataTransfer>(dynamic id, IDbConnection connection) where  T: class
            where DataTransfer:  class, new()
        {
            ObservableCollection<DataTransfer> transfer = new ObservableCollection<DataTransfer>();
            if (id == null)
            {
                return transfer;
            }
            var current = await connection.GetAsync<T>(_currentPoco.PROVINCIA);
            var value =  _mapper.Map<T, DataTransfer>(current);
            transfer.Add(value);
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
                return valueClientesDto;
            }
            set => _currentPoco = ConvertFromDto(value);
        }
        public bool Valid { get; set; }

        public ObservableCollection<ProvinciaDto> ProvinciaDto
        {
            get => _provinciaDtos;
            set => _provinciaDtos = value;
        }

        public ObservableCollection<CountryDto> CountryDto
        {
            get => _countriesDto;
            set => _countriesDto = value;
        }

        public ObservableCollection<CityDto> CityDto => _citiesDto;

        public ObservableCollection<ClientZoneDto> ZoneDto => _clientDto;

        public ObservableCollection<OrigenDto> OrigenDto => _origenDto;

        public ObservableCollection<ComisioDto> BrokerDto => _brokerDto;

        public ObservableCollection<MercadoDto> ClientMarketDto
        {
            get => _clientMarketDto;
            set => _clientMarketDto = value;
        }

        public ObservableCollection<ResellerDto> ResellerDto => _resellerDto ;

        public ObservableCollection<ClientTypeDto> ClientTypeDto => _clientTypeDto;

    }
}
