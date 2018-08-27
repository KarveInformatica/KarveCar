using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KarveDataServices.DataObjects;
using KarveDataServices.ViewObjects;

namespace KarveDataServices
{
    /// <summary>
    ///  This is the interface for managing all the clients.
    /// </summary>
    public interface IClientDataServices: IPageCounter, ISorterData<ClientSummaryExtended>
    {
        /// <summary>
        ///  This give us the summary query.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ClientSummaryExtended>> GetSummaryAllAsync();
        /// <summary>
        /// This return a client with a new code.
        /// </summary>
        /// <param name="code">Code to return.</param>
        /// <returns></returns>
        IClientData GetNewDo(string code);
        /// <summary>
        ///  This is a delete client.
        /// </summary>
        Task<bool> DeleteDoAsync(IClientData commissionAgent);
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
        Task<IClientData> GetDoAsync(string clientIndentifier);
        /// <summary>
        ///  This generate an unique id following the entity.
        /// </summary>
        /// <returns></returns>
        string GetNewId();
        /// <summary>
        ///  Get the summary of clients.
        /// </summary>
        /// <param name="clientsSummaryQuery">String of a client data to load.</param>
        /// <returns>A list of enumerable clients.</returns>
        Task<IEnumerable<ClientSummaryViewObject>> GetSummaryDo(string clientsSummaryQuery);
        /// <summary>
        ///  Get the async client paged
        /// </summary>
        /// <param name="pageIndex">Get the async client paged</param>
        /// <param name="pageSize">Page size of the client</param>
        /// <returns>Return the client extended summary</returns>
        Task<IEnumerable<ClientSummaryExtended>> GetPagedSummaryDoAsync(long pageIndex, int pageSize);
        /// <summary>
        /// Get the number of contacts paged by client.
        /// </summary>
        /// <param name="clientCode">Client Code to be used</param>
        /// <param name="baseIndex">Base Index to be used.</param>
        /// <param name="defaultPage">Page size to be used.</param>
        /// <returns>A list of contacts to be used.</returns>
        Task<IEnumerable<ContactsViewObject>> GetPagedContactsByClient(string clientCode, int baseIndex, int defaultPage);
    }

}
