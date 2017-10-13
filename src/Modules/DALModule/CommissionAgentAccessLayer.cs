using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Controls;
using KarveCommon.Generic;
using KarveDataServices;
using KarveDataServices.DataObjects;

namespace DataAccessLayer
{
    internal class CommissionAgentAccessLayer : ICommissionAgentDataServices
    {
        private readonly ISqlQueryExecutor _sqlQueryExecutor;

        public CommissionAgentAccessLayer(ISqlQueryExecutor sqlQueryExecutor)
        {
            this._sqlQueryExecutor = sqlQueryExecutor;
        }

        public Task<DataSet> GetCommissionAgent(IDictionary<string, string> query)
        {
            throw new System.NotImplementedException();
        }

        public Task<ICommissionAgent> GetCommissionAgentDo(IDictionary<string, string> query)
        {
            throw new System.NotImplementedException();
        }
        /// <summary>
        ///  This returns the commission agent summary query for the commission.
        /// </summary>
        /// <param name="paged"> Set the commission agent paged</param>
        /// <param name="pageSize">Set the commission agent page size </param>
        /// <returns></returns>
        public async Task<DataSet> GetCommissionAgentSummary(bool paged = false, long pageSize = 0)
        {
            DataSet set = new DataSet();
            if (!paged)
            {
                set = await _sqlQueryExecutor.AsyncDataSetLoad(GenericSql.CommissionAgentSummaryQuery);
               
            }
            return set;
        }

        public Task<IList<ICommissionAgent>> GetCommissionAgentDoList(long maxSize = 0)
        {
            throw new System.NotImplementedException();
        }

        public Task<DataSet> GetNewCommissionAgent(IDictionary<string, string> queryList)
        {
            throw new System.NotImplementedException();
        }

        public Task<ICommissionAgent> GetNewCommissionAgentDo(IDictionary<string, string> commissionAgent)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteCommissionAgent(string sqlQuery, string supplierId, DataSet supplierDataSet)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteCommissionAgents(IDictionary<string, string> queries, DataSet currentDataSet, IList<ValidationRule> validationRules)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteCommissionAgentDo(ICommissionAgent commissionAgent, IDictionary<string, string> queriesDictionary)
        {
            throw new System.NotImplementedException();
        }
    }
}