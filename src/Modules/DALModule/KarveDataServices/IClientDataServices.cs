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
        ///  This create a new client.
        /// </summary>
        /// <returns></returns>
        IClientData GetNewClientAgentDo();
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

    }
}
