using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using KarveDataServices;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;
using MongoDB.Driver;

namespace DataAccessLayer.MongoDB
{
    internal class ClientMongoDBServices : IClientDataServices
    {
        private IMongoClient _executor;
      
        public ClientMongoDBServices(IMongoClient executor)
        {
            _executor = executor;
        }

        public async Task GetAsyncAllClientSummary()
        {
           await _executor.GetDatabase("Clients").ListCollectionsAsync();
        }

        public IClientData GetNewClientAgentDo(string code)
        {
           
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteClientAsyncDo(IClientData commissionAgent)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> SaveAsync(IClientData clientData)
        {
            throw new System.NotImplementedException();
        }

        public Task<IClientData> GetAsyncClientDo(string clientIndentifier)
        {
            throw new System.NotImplementedException();
        }

        public string GetNewId()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<ClientSummaryDto>> GetClientSummaryDo(string clientsSummaryQuery)
        {
            throw new System.NotImplementedException();
        }

       
        Task<IEnumerable<ClientSummaryExtended>> IClientDataServices.GetAsyncAllClientSummary()
        {
            throw new System.NotImplementedException();
        }
    }
}