using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using KarveDataServices;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;

namespace DataAccessLayer.MongoDB
{
    internal class CommisionAgentMongoDBServices : ICommissionAgentDataServices
    {
        public Task<ICommissionAgent> GetCommissionAgentDo(string commissionAgentId, IDictionary<string, string> queryDictionary = null)
        {
            throw new System.NotImplementedException();
        }

        public Task<DataSet> GetCommissionAgent(IDictionary<string, string> query)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<ICommissionAgent>> GetCommissionAgentCollection(IDictionary<string, string> fields, int pageSize = 0, int startAt = 0)
        {
            throw new System.NotImplementedException();
        }

        public ICommissionAgent GetNewCommissionAgentDo()
        {
            throw new System.NotImplementedException();
        }

        public ICommissionAgent GetNewCommissionAgentDo(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<DataSet> GetAsyncCommissionAgentInfo(IDictionary<string, string> queryList)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> SaveCommissionAgent(ICommissionAgent commissionAgent)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteCommissionAgent(ICommissionAgent commissionAgent)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteCommissionAgent(string sqlQuery, string commissionAgentId, DataSet set)
        {
            throw new System.NotImplementedException();
        }

        public Task<DataSet> GetCommissionAgentSummary(bool paged = false, long pageSize = 0)
        {
            throw new System.NotImplementedException();
        }

        public string GetNewId()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> SaveChangesCommissionAgent(ICommissionAgent commissionAgent)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<CommissionAgentSummaryDto>> GetCommissionAgentSummaryDo()
        {
            throw new System.NotImplementedException();
        }
    }
}