using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using DataAccessLayer.Crud.Clients;
using DataAccessLayer.DataObjects;
using DataAccessLayer.Model;
using KarveCommon.Generic;
using KarveDapper.Extensions;
using KarveDataServices;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;
using DataAccessLayer.SQL;
using System.Diagnostics;
using System.Linq;

namespace DataAccessLayer
{
     /// <summary>
     /// This class has the resposability to handle the client wrapper and delete, insert, update values. 
     /// </summary>
    internal class ClientDataAccessLayer : IClientDataServices
    {
        private IDataLoader<ClientDto> _dataLoader;
        private IDataSaver<ClientDto> _dataSaver;
        private IDataDeleter<ClientDto> _dataDeleter;
        
        /// <summary>
        ///  Sql executor.
        /// </summary>
        private readonly ISqlExecutor _sqlExecutor;

        /// <summary>
        ///  Constructor
        /// </summary>
        /// <param name="sqlExecutor">SqlExecutor value</param>
        public ClientDataAccessLayer(ISqlExecutor sqlExecutor)
        {
            _sqlExecutor = sqlExecutor;
            _dataLoader = new ClientDataLoader(sqlExecutor);
            _dataSaver = new ClientDataSaver(sqlExecutor);
            _dataDeleter= new ClientDeleter(sqlExecutor);
        }
        /// <summary>
        ///  Delete the client.
        /// </summary>
        /// <param name="clientData">The client value to delete</param>
        /// <returns>True if has been deleted correctly</returns>
        public async Task<bool> DeleteClientAsyncDo(IClientData clientData)
        {
            return await _dataDeleter.DeleteAsync(clientData.Value).ConfigureAwait(false);
        }
        /// <summary>
        ///  Get async client summary.
        /// </summary>
        /// <returns>A list containing the complete list of clients</returns>
        public async Task<IEnumerable<ClientSummaryExtended>> GetAsyncAllClientSummary()
        {
            QueryStore store = new QueryStore();
            store.AddParam(QueryStore.QueryType.QueryClientSummaryExt);
            var query = store.BuildQuery();
            IEnumerable<ClientSummaryExtended> summaryDtos = new List<ClientSummaryExtended>();
            using (IDbConnection connection = _sqlExecutor.OpenNewDbConnection())
            {
                summaryDtos = await connection.QueryAsync<ClientSummaryExtended>(query).ConfigureAwait(false);
                var value = summaryDtos.FirstOrDefault();
                if (value != null)
                {
                    // init the dapper buffer.
                    QueryStore clientPocoQueryStore = new QueryStore();
                    clientPocoQueryStore.AddParam(QueryStore.QueryType.QueryClient1, value.Code);
                    clientPocoQueryStore.AddParam(QueryStore.QueryType.QueryClient2, value.Code);
                    var q = clientPocoQueryStore.BuildQuery();
                    var pocoReader = await connection.QueryMultipleAsync(q).ConfigureAwait(false);
                    var clients1 = pocoReader.Read<CLIENTES1>(true).FirstOrDefault();
                    var clients2 = pocoReader.Read<CLIENTES2>(true).FirstOrDefault();
                   
           
                }
            }
            return summaryDtos;
        }

     
        /// <summary>
        /// This code return a client model wrapper.
        /// </summary>
        /// <param name="clientIndentifier"></param>
        /// <returns></returns>
        public async Task<IClientData> GetAsyncClientDo(string clientIndentifier)
        {
           
            var entity = await _dataLoader.LoadValueAsync(clientIndentifier).ConfigureAwait(false);
            IClientData client = new Client();
            client.Value = entity;
           
            return client;
        }
        /// <summary>
        ///  Get client summary
        /// </summary>
        /// <param name="clientsSummaryQuery">Query of the client summary.</param>
        /// <returns></returns>
        public async Task<IEnumerable<ClientSummaryDto>> GetClientSummaryDo(string clientsSummaryQuery)
        {
          
            IEnumerable<ClientSummaryDto> summaryDtos = new List<ClientSummaryDto>();
            using (IDbConnection connection = _sqlExecutor.OpenNewDbConnection())
            {
                try
                {
                    summaryDtos = await connection.QueryAsync<ClientSummaryDto>(clientsSummaryQuery).ConfigureAwait(false);
                }
                finally
                {
                    connection.Close();
                }
            }
            return summaryDtos;
        }
        public IClientData GetNewClientAgentDo(string code)
        {
            IClientData varClientData = new Client();
            varClientData.Value = new ClientDto();
            varClientData.Value.NUMERO_CLI = code;
            return varClientData;
        }
        /// <summary>
        ///  Generate an unique id from the entity key.
        /// </summary>
        /// <returns>Return a string with the client dto.</returns>
        public string GetNewId()
        {
            CLIENTES1  value = new CLIENTES1();
            string uniqueIdTask = string.Empty;
            using (IDbConnection connection = _sqlExecutor.OpenNewDbConnection())
            {
                try
                {
                    uniqueIdTask =  connection.UniqueId(value);

                }
                finally
                {
                    connection.Close();
                }    
            }
            return uniqueIdTask;
        }

        /// <summary>
        ///  Value to save in the client data.
        ///  REMARK: in this case the domain wrapper does the job, this might change in future because it is coupled.
        /// </summary>
        /// <param name="clientData"></param>
        /// <returns>True if the data has been saved correctly</returns>

        public async Task<bool> SaveAsync(IClientData clientData)
        {
            return await _dataSaver.SaveAsync(clientData.Value).ConfigureAwait(false);
        }
    }
}