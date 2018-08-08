using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Threading.Tasks;
using KarveDataServices;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;

namespace DataAccessLayer.MongoDB
{
    internal class MongoCommissionAgentDataAccessLayer : ICommissionAgentDataServices
    {
        public Task<int> GetPageCount(int pageSize)
        {
            throw new System.NotImplementedException();
        }
        public Task<ICommissionAgent> GetCommissionAgentDo(string commissionAgentId, IDictionary<string, string> queryDictionary = null)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<ICommissionAgent>> GetCommissionAgentCollection(IDictionary<string, string> fields, int pageSize = 0, int startAt = 0)
        {
            throw new System.NotImplementedException();
        }

        public Task<DataSet> GetDataSetSummaryAsync(bool paged = false, long pageSize = 0)
        {
            throw new System.NotImplementedException();
        }
        public Task<IEnumerable<CommissionAgentSummaryDto>> GetSortedCollectionPagedAsync(Dictionary<string, ListSortDirection> sortChain, long index, int pageSize)
        {
            throw new System.NotImplementedException();
        }

        public string NewId()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<CommissionAgentSummaryDto>> GetSummaryAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<ICommissionAgent> GetDoAsync(string code)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> SaveAsync(ICommissionAgent bookingData)
        {
            throw new System.NotImplementedException();
        }

        public ICommissionAgent GetNewDo(string value)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteAsync(ICommissionAgent booking)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<CommissionAgentSummaryDto>> GetPagedSummaryDoAsync(int index, int pageSize)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<ICommissionAgent>> GetListAsync(IList<ICommissionAgent> primaryKeys)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<ICommissionAgent>> GetListAsync(IList<string> primaryKeys)
        {
            throw new System.NotImplementedException();
        }

        public int NumberPage { get; set; }
        public long NumberItems { get; set; }
    }
}