using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveDataServices.DataObjects;

namespace KarveDataServices
{
    /// <summary>
    ///  This is the interface for managing all the clients.
    /// </summary>
    public interface IClientDataServices
    {
        /// <summary>
        ///  This give us the summary query.
        /// </summary>
        /// <returns></returns>
        Task<DataSet> GetAsyncAllClientSummary();
        /// <summary>
        /// This return a client with a new code.
        /// </summary>
        /// <param name="code">Code to return.</param>
        /// <returns></returns>
        IClientData GetNewClientAgentDo(string code);
        /// <summary>
        ///  This is a delete client.
        /// </summary>
        Task<bool> DeleteClientAsyncDo(IClientData commissionAgent);
        /// <summary>
        ///  This save the client data.
        /// </summary>
        /// <param name="clientData"></param>
        /// <returns>true or false in case of a client.</returns>
        Task<bool> SaveAsync(IClientData clientData);
        /// <summary>
        ///  Client data object
        /// </summary>
        /// <param name="clientIndentifier">Identifier a client</param>
        /// <returns>Client data to receive</returns>
        Task<IClientData> GetAsyncClientDo(string clientIndentifier);
        /// <summary>
        ///  This generate an unique id following the entity.
        /// </summary>
        /// <returns></returns>
        string GetNewId();
    }
}
