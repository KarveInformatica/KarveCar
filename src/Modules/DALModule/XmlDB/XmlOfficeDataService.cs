using System.Collections.Generic;
using System.Threading.Tasks;
using KarveDataServices;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;

namespace DataAccessLayer.XmlDB
{
    internal class XmlOfficeDataService : IOfficeDataServices
    {
        public Task<bool> DeleteOfficeAsyncDo(IOfficeData commissionAgent)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<OfficeSummaryDto>> GetAsyncAllOfficeSummary()
        {
            throw new System.NotImplementedException();
        }

        public Task<IOfficeData> GetAsyncOfficeDo(string clientIndentifier)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<OfficeSummaryDto>> GetCompanyOffices(string companyCode)
        {
            throw new System.NotImplementedException();
        }

        public string GetNewId()
        {
            throw new System.NotImplementedException();
        }

        public IOfficeData GetNewOfficeDo(string code)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> SaveAsync(IOfficeData clientData)
        {
            throw new System.NotImplementedException();
        }
    }
}