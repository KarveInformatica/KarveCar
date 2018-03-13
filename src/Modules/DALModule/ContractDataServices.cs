using KarveDataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveDataServices.DataTransferObject;

namespace DataAccessLayer
{
    /// <summary>
    ///  ContractDataServices. 
    /// </summary>
    internal class ContractDataServices: IContractDataServices
    {
        /// <summary>
        ///  ContractDataServices.
        /// </summary>
        /// <param name="sqlExecutor">SqlExectur</param>
        public ContractDataServices(ISqlExecutor sqlExecutor)
        {

        }
        /// <summary>
        ///  Returns a contract with the id.
        /// </summary>
        /// <param name="id">Identifier of the contract</param>
        /// <returns>A contract from the identifier</returns>
        public async Task<ContractDto> GetContractAsync(string id)
        {
            ContractDto dto = new ContractDto();
          
            return dto;
        }
        /// <summary>
        ///  Return the contract by the conductor in asynchronous way.
        /// </summary>
        /// <param name="vehicleId">Identifier of the vehicle</param>
        /// <returns></returns>
        public async Task<IEnumerable<ContractByConductorDto>> GetContractByConductorAsync(string vehicleId)
        {
            // this returns the contract by conductor.
            var l = new List<ContractByConductorDto>();
            return l;
        }
        /// <summary>
        ///  Return the contract summary in asynchronous way.
        /// </summary>
        /// <returns>Return the contract.</returns>
        public async Task<IEnumerable<ContractSummaryDto>> GetContractSummaryAsync()
        {
            var contractSummary = new List<ContractSummaryDto>();
            contractSummary.Add(new ContractSummaryDto());
            return contractSummary;
        }
    }
}
