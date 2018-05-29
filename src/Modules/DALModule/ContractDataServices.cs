using KarveDataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DataAccessLayer.SQL;
using KarveDataServices.DataTransferObject;
using System.ComponentModel;

namespace DataAccessLayer
{
    /// <summary>
    ///  ContractDataServices. 
    /// </summary>
    internal class ContractDataServices: AbstractDataAccessLayer, IContractDataServices
    {
     
        /// <summary>
        ///  ContractDataServices.
        /// </summary>
        /// <param name="sqlExecutor">SqlExectur</param>
        public ContractDataServices(ISqlExecutor sqlExecutor): base(sqlExecutor)
        {     
            TableName = "CONTRATOS1";
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
            IQueryStore store = QueryStoreFactory.GetQueryStore();
            store.AddParam(QueryType.QueryContractSummaryBasic);
            var query = store.BuildQuery();
            using (var conn = SqlExecutor.OpenNewDbConnection())
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
        ///  This returns a sorted summary sorted and extended collection.
        /// </summary>
        /// <param name="sortChain">Sort direction</param>
        /// <param name="pageIndex">Index of the page</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>A list of sorted items following the sorting criteria</returns>
        public async Task<IEnumerable<ContractSummaryDto>> GetSortedCollectionPagedAsync(Dictionary<string, ListSortDirection> sortChain, long pageIndex, int pageSize)
        {
            var dataPager = new DataPager<ContractSummaryDto>(SqlExecutor);
            var pageStart = pageIndex;
            if (pageStart == 0)
                pageStart = 1;
            NumberPage = await GetPageCount(pageSize).ConfigureAwait(false);
            var datas = await dataPager.GetPagedSummaryDoSortedAsync(QueryType.QueryContractSummaryPaged, sortChain, pageIndex, pageSize);
            return datas;
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
