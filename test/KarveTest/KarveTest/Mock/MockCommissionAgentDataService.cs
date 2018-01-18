using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using KarveDataServices;
using KarveDataServices.DataObjects;

namespace KarveTest.Mock
{
    internal class MockCommissionAgentDataService : ICommissionAgentDataServices
    {
        public Task<bool> DeleteCommissionAgent(ICommissionAgent commissionAgent)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCommissionAgent(string sqlQuery, string commissionAgentId, DataSet set)
        {
            throw new NotImplementedException();
        }

        public Task<DataSet> GetAsyncCommissionAgentInfo(IDictionary<string, string> queryList)
        {
            throw new NotImplementedException();
        }

        public Task<DataSet> GetCommissionAgent(IDictionary<string, string> query)
        {
            throw new NotImplementedException();
        }

        public Task<IList<ICommissionAgent>> GetCommissionAgentCollection(IDictionary<string, string> fields, int pageSize = 0, int startAt = 0)
        {
            throw new NotImplementedException();
        }

        public Task<ICommissionAgent> GetCommissionAgentDo(string commissionAgentId, IDictionary<string, string> queryDictionary = null)
        {
            throw new NotImplementedException();
        }

        public Task<DataSet> GetCommissionAgentSummary(bool paged = false, long pageSize = 0)
        {
            throw new NotImplementedException();
        }

        public ICommissionAgent GetNewCommissionAgentDo()
        {
            throw new NotImplementedException();
        }

        public ICommissionAgent GetNewCommissionAgentDo(string id)
        {
            throw new NotImplementedException();
        }

        public string GetNewId()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChangesCommissionAgent(ICommissionAgent commissionAgent)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveCommissionAgent(ICommissionAgent commissionAgent)
        {
            throw new NotImplementedException();
        }
    }
}