using System;
using System.Data;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
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
     /// This class has the resposability to handle the client wrapper and delete, insert, update the values. 
     /// </summary>
    internal class ClientDataAccessLayer : IClientDataServices
    {
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
        }
        /// <summary>
        ///  Delete the client.
        /// </summary>
        /// <param name="clientData">The client value to delete</param>
        /// <returns>True if the data has been deleted correctly</returns>
        public async Task<bool> DeleteClientAsyncDo(IClientData clientData)
        {
           return await clientData.DeleteAsync();
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
        /// 
        /// </summary>
        /// <param name="clientIndentifier"></param>
        /// <returns></returns>
        public async Task<IClientData> GetAsyncClientDo(string clientIndentifier)
        {
            IClientData client = new Client(_sqlExecutor);
            bool retValue = await client.LoadValue(clientIndentifier);
            if (retValue)
            {
                return client;
            }
            else
            {
                return new NullClient();
            }
        }
        public IClientData GetNewClientAgentDo(string code)
        {
            IClientData varClientData = new Client(_sqlExecutor);
            varClientData.Value = new ClientesDto();
            varClientData.Value.NUMERO_CLI = code;
            return varClientData;
        }
        /// <summary>
        ///  Generate an unique id from the entity key.
        /// </summary>
        /// <returns></returns>
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
            return await clientData.SaveAll();
        }
    }
}