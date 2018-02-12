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
        /// <returns>True if the data has been deleted correctly</returns>
        public async Task<bool> DeleteClientAsyncDo(IClientData clientData)
        {
            return await _dataDeleter.DeleteAsync(clientData.Value);
        }
        /// <summary>
        ///  Get async client summary.
        /// </summary>
        /// <returns>A dataset containing the complete list of clients</returns>
        public async Task<DataSet> GetAsyncAllClientSummary()
        {
            string str = GenericSql.ClientsSummaryQuery;
            DataSet summary = await _sqlExecutor.AsyncDataSetLoad(str).ConfigureAwait(false);
            return summary;
        }

     
        /// <summary>
        /// This code return a client model wrapper.
        /// </summary>
        /// <param name="clientIndentifier"></param>
        /// <returns></returns>
        public async Task<IClientData> GetAsyncClientDo(string clientIndentifier)
        {
            ClientDto dto = await _dataLoader.LoadValueAsync(clientIndentifier);
            IClientData client = new Client();
            client.Value = dto;
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
                    summaryDtos = await connection.QueryAsync<ClientSummaryDto>(clientsSummaryQuery);
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
            return await _dataSaver.SaveAsync(clientData.Value);
        }
    }
}