using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using KarveDataServices;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;

namespace KarveTest.Mock
{
    internal class MockCommissionAgentDataService : ICommissionAgentDataServices
    {
        public int NumberPage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public long NumberItems { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Task<bool> DeleteDoAsync(ICommissionAgent commissionAgent)
        {
            throw new NotImplementedException();
        }

        public bool DeleteDo(string sqlQuery, string commissionAgentId, DataSet set)
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

        public Task<DataSet> GetDataSetSummaryAsync(bool paged = false, long pageSize = 0)
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

        public Task<IEnumerable<CommissionAgentSummaryDto>> GetSummaryDoAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveCommissionAgent(ICommissionAgent commissionAgent)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CommissionAgentSummaryDto>> GetPagedSummaryDoAsync(long pageIndex, long pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetPageCount(int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CommissionAgentSummaryDto>> GetPagedSummaryDoAsync(long pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CommissionAgentSummaryDto>> GetSortedCollectionPagedAsync(Dictionary<string, ListSortDirection> sortChain, long index, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}