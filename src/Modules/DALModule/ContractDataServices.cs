using KarveDataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DataAccessLayer.SQL;
using KarveDataServices.DataTransferObject;

namespace DataAccessLayer
{
    /// <summary>
    ///  ContractDataServices. 
    /// </summary>
    internal class ContractDataServices: IContractDataServices
    {
        private readonly QueryStoreFactory _queryStoreFactory;
        private readonly ISqlExecutor _executor;
        /// <summary>
        ///  ContractDataServices.
        /// </summary>
        /// <param name="sqlExecutor">SqlExectur</param>
        public ContractDataServices(ISqlExecutor sqlExecutor)
        {
            _queryStoreFactory = new QueryStoreFactory();
            _executor = sqlExecutor;
        }
        /// <summary>
        ///  Returns a contract with the id.
        /// </summary>
        /// <param name="id">Identifier of the contract</param>
        /// <returns>A contract from the identifier</returns>
        public async Task<ContractDto> GetContractAsync(string id)
        {
            await Task.Delay(1);
            throw new NotImplementedException();
        }
        /// <summary>
        /// This is a safe contract to be used.
        /// </summary>
        /// <returns>A list of contracts.</returns>
        public async Task<IEnumerable<ContractSummaryDto>> GetContractSummaryAsync()
        {
            IQueryStore store = _queryStoreFactory.GetQueryStore();
            store.AddParam(QueryType.QueryContractSummaryBasic);
            var query = store.BuildQuery();
            using (var conn = _executor.OpenNewDbConnection())
            {
                if (conn == null)
                {
                    return new List<ContractSummaryDto>();
                }
                var resultValues = await conn?.QueryAsync<ContractSummaryDto>(query);
                if (resultValues != null)
                {
                    return resultValues;
                }
            }
            // safe default in case of error.
            return new List<ContractSummaryDto>();
        }
        /// <summary>
        ///  Return the contract by the conductor in asynchronous way.
        /// </summary>
        /// <param name="vehicleId">Identifier of the vehicle</param>
        /// <returns></returns>
        public async Task<IEnumerable<ContractByConductorDto>> GetContractByConductorAsync(string vehicleId)
        {
            await Task.Delay(1);
            throw new NotImplementedException();
        }
    }
}
