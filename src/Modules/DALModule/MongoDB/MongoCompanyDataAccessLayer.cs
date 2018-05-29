using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using KarveDataServices;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;

namespace DataAccessLayer.MongoDB
{
    internal class MongoCompanyDataAccessLayer : ICompanyDataServices
    {
        public int NumberPage { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public long NumberItems { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public Task<bool> DeleteCompanyAsyncDo(ICompanyData companyData)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<CompanySummaryDto>> GetAsyncAllCompanySummary()
        {
            throw new System.NotImplementedException();
        }

        public Task<ICompanyData> GetAsyncCompanyDo(string clientIndentifier)
        {
            throw new System.NotImplementedException();
        }

        public ICompanyData GetNewCompanyDo(string code)
        {
            throw new System.NotImplementedException();
        }

        public string GetNewId()
        {
            throw new System.NotImplementedException();
        }

        public Task<int> GetPageCount(int pageSize)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<CompanySummaryDto>> GetPagedSummaryDoAsync(int baseIndex, int defaultPageSize)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<CompanySummaryDto>> GetSortedCollectionPagedAsync(Dictionary<string, ListSortDirection> sortChain, long index, int pageSize)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> SaveAsync(ICompanyData clientData)
        {
            throw new System.NotImplementedException();
        }
    }
}