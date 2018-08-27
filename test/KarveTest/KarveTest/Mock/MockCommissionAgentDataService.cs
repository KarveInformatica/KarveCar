using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using KarveDataServices;
using KarveDataServices.DataObjects;
using KarveDataServices.ViewObjects;

namespace KarveTest.Mock
{
    internal class MockCommissionAgentDataService : ICommissionAgentDataServices
    {
        public int NumberPage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public long NumberItems { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Task<bool> DeleteAsync(ICommissionAgent booking)
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

        public Task<ICommissionAgent> GetDoAsync(string code)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ICommissionAgent>> GetListAsync(IList<ICommissionAgent> primaryKeys)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ICommissionAgent>> GetListAsync(IList<string> primaryKeys)
        {
            throw new NotImplementedException();
        }

        public ICommissionAgent GetNewDo(string value)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetPageCount(int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CommissionAgentSummaryViewObject>> GetPagedSummaryDoAsync(int index, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CommissionAgentSummaryViewObject>> GetSortedCollectionPagedAsync(Dictionary<string, ListSortDirection> sortChain, long index, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CommissionAgentSummaryViewObject>> GetSummaryAllAsync()
        {
            throw new NotImplementedException();
        }

        public string NewId()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveAsync(ICommissionAgent bookingData)
        {
            throw new NotImplementedException();
        }
    }
}