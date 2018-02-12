using System.Data;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;
using System.Transactions;
using AutoMapper;
using Dapper;
using DataAccessLayer.DataObjects;
using DataAccessLayer.Logic;
using DataAccessLayer.SQL;
using KarveDataServices;
using KarveDapper.Extensions;
using KarveDataServices.DataTransferObject;

namespace DataAccessLayer.Crud.Clients
{
    /// <summary>
    ///  This class has the single resposability to delete a client
    /// </summary>
    sealed class ClientDeleter : IDataDeleter<ClientDto>
    {
        private IMapper _mapper;
        private ISqlExecutor _executor;

        /// <summary>
        ///  Constructor for the sql deleter.
        /// </summary>
        /// <param name="executor">SqlExecutor to delete</param>
        public ClientDeleter(ISqlExecutor executor)
        {
            _mapper = MapperField.GetMapper();
            _executor = executor;
        }

        private async Task<bool> DeleteReferredTables(ClientDto data)
        {
            QueryStore store = new QueryStore();
            store.AddParam(QueryStore.QueryType.DeleteClientContacts, data.NUMERO_CLI);
            store.AddParam(QueryStore.QueryType.DeleteClientBranches, data.NUMERO_CLI);
            store.AddParam(QueryStore.QueryType.DeleteClientBranches, data.NUMERO_CLI);
            int retValue = 0;
            var query = store.BuildQuery();
            using (IDbConnection connection = _executor.OpenNewDbConnection())
            {
                retValue = await connection.ExecuteAsync(query);
            }
            return retValue > 0;
        }
        /// <summary>
        ///  This delete asynchronous data
        /// </summary>
        /// <param name="data">Client data object</param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(ClientDto data)
        {
            Contract.Assert(data != null, "Invalid data transfer object");
            var currentPoco = _mapper.Map<ClientDto, ClientPoco>(data);
            CLIENTES1 client1 = _mapper.Map<ClientPoco, CLIENTES1>(currentPoco);
            CLIENTES2 client2 = _mapper.Map<ClientPoco, CLIENTES2>(currentPoco);
            bool retValue = false;
            if ((client1 == null) || (client2 == null))
            {
                return false;
            }
            using (IDbConnection connection = _executor.OpenNewDbConnection())
            {
                try
                {
                    using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                    {
                        retValue = await connection.DeleteAsync<CLIENTES1>(client1);
                        if (retValue)
                        {
                            retValue = await connection.DeleteAsync<CLIENTES2>(client2);
                        }
                        retValue = retValue && await DeleteReferredTables(data);
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
    }
}
