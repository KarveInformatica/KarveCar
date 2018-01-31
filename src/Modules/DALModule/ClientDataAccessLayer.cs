using System.Data;
using System.Threading.Tasks;
using DataAccessLayer.Model;
using KarveCommon.Generic;
using KarveDataServices;
using KarveDataServices.DataObjects;

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
        ///  This return a single client.
        /// </summary>
        /// <returns>True if the data has been saved correctly</returns>
        public IClientData GetNewClientAgentDo()
        {
           IClientData varClientData= new Client(_sqlExecutor);
           return varClientData;
        }
        /// <summary>
        ///  Value to save in the client data.
        /// </summary>
        /// <param name="clientData"></param>
        /// <returns>True if the data has been saved correctly</returns>
    
        public async Task<bool> SaveAsync(IClientData clientData)
        {
            return await clientData.SaveAll();
        }
    }
}