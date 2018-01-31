using System;
using System.Collections.Generic;
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
        /// <summary>
        ///  Client constructor
        /// </summary>
        /// <param name="executor">Executor of sql.</param>
        public Client(ISqlExecutor executor)
        {
            _mapper = MapperField.GetMapper();
            _sqlExecutor = executor;
           
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
            var whereClause = string.Format(WhereClause, code);
            var query = string.Format(Clientes, _currentFlags, whereClause);
            IDbConnection conn = null;
            bool returnValue = false;
            if (_sqlExecutor.Connection.State == ConnectionState.Open)
            {
                conn = _sqlExecutor.Connection;
            }
            else
            {
                conn = _sqlExecutor.OpenNewDbConnection();
            }
            if (conn != null)
            {
                var value = await conn.QueryAsync<ClientPoco>(query);
                _currentPoco = value.FirstOrDefault();
                if (_currentPoco != null)
                {
                    returnValue = true;
                    Valid = true;
                }
            }
            return returnValue;
        }

      
        /// <summary>
        ///  This save all clients.
        /// </summary>
        /// <returns></returns>
        public async Task<bool> SaveAll()
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


            return retValue;

        }

        private ClientesDto ConvertFromPoco(ClientPoco poco)
        {
            Contract.Assert(_mapper != null, "Mapping shall be initialized");
            var value = _mapper.Map<ClientPoco, ClientesDto>(poco);
            Contract.Ensures(value != null, "Mapping shall be done correctly");
            return value;
        }

        public ClientesDto Value {
            get
            {
                
            }
            set
            {
                
            }
        }
        public bool Valid { get; set; }
    }
}
