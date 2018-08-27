using System.Collections.Generic;
using System.Threading.Tasks;
using KarveDataServices.ViewObjects;
namespace KarveDataServices
{
    public interface IContractDataServices: IPageCounter
    {
        /// <summary>
        ///  Get the contract summary async.
        /// </summary>
        /// <returns>the list of the agreements</returns>
        Task<IEnumerable<ContractSummaryDto>> GetContractSummaryAsync();
        /// <summary>
        ///  Get the contract asynchronous.
        /// </summary>
        /// <param name="id">This return asynchrnously a contract</param>
        /// <returns>A single agreement.</returns>
        Task<ContractViewObject> GetContractAsync(string id);
        /// <summary>
        /// Get a list of agreement by conductor.
        /// </summary>
        /// <returns>A list of agreement and conductors summary </returns>
        Task<IEnumerable<ContractByConductorViewObject>> GetContractByConductorAsync(string vehicleId);
        /// <summary>
        ///  Returns a summary list of contract data used by the client.
        /// </summary>
        /// <param name="code"></param>
        /// <returns>A list of contracts</returns>
        Task<IEnumerable<ContractByClientViewObject>> GetContractByClientAsync(string code);
        /// <summary>
        /// Returns a list of contract data used by the client.
        /// </summary>
        /// <param name="first">First part of the event.</param>
        /// <param name="baseIndex">Base index to be used.</param>
        /// <returns>A list of contract summary.</returns>
        Task<IEnumerable<ContractSummaryDto>> GetPagedSummaryDoAsync(int first, int baseIndex);
    }
}