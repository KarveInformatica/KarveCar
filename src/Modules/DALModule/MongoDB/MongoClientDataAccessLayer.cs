using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using KarveDataServices;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;

namespace DataAccessLayer.MongoDB
{
    [Serializable]
    internal class MongoClientDataAccessLayer : IClientDataServices
    {
        public MongoClientDataAccessLayer()
        {
        }

      
        public Task<int> GetPageCount(int pageSize)
        {
            throw new NotImplementedException();
        }

        public int NumberPage { get; set; }
        public long NumberItems { get; set; }
        public Task<IEnumerable<ClientSummaryExtended>> GetSummaryAllAsync()
        {
            throw new NotImplementedException();
        }

        public IClientData GetNewDo(string code)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteDoAsync(IClientData commissionAgent)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveAsync(IClientData clientData)
        {
            throw new NotImplementedException();
        }

        public Task<IClientData> GetDoAsync(string clientIndentifier)
        {
            throw new NotImplementedException();
        }

        public string GetNewId()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ClientSummaryDto>> GetSummaryDo(string clientsSummaryQuery)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ClientSummaryExtended>> GetPagedSummaryDoAsync(long pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ClientSummaryExtended>> GetSortedCollectionPagedAsync(Dictionary<string, ListSortDirection> sortChain, long index, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}