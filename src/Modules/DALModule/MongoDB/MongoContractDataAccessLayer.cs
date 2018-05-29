using System.Collections.Generic;
using System.Threading.Tasks;
using KarveDataServices;
using KarveDataServices.DataTransferObject;

namespace DataAccessLayer.MongoDB
{
    internal class MongoContractDataAccessLayer : IContractDataServices
    {
        public int NumberPage { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public long NumberItems { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public Task<ContractDto> GetContractAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<ContractByConductorDto>> GetContractByConductorAsync(string vehicleId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<ContractSummaryDto>> GetContractSummaryAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<int> GetPageCount(int pageSize)
        {
            throw new System.NotImplementedException();
        }
    }
}