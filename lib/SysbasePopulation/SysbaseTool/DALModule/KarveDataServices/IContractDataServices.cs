using System.Collections.Generic;
using System.Threading.Tasks;
using KarveDataServices.DataTransferObject;
namespace KarveDataServices
{
    public interface IContractDataServices
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
        Task<ContractDto> GetContractAsync(string id);
        /// <summary>
        /// Get a list of agreement by conductor.
        /// </summary>
        /// <returns>A list of agreement and conductors summary </returns>
        Task<IEnumerable<ContractByConductorDto>> GetContractByConductorAsync(string vehicleId);

    }
}