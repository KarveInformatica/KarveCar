using System.Collections.Generic;
using System.Threading.Tasks;
using KarveDataServices;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;
using DataAccessLayer.Crud.Office;

namespace DataAccessLayer
{
    internal class OfficeDataService: IOfficeDataServices
    {
        private ISqlExecutor _sqlExecutor;
        private OfficeDataLoader _loader;
        private OfficeDataSaver _saver;
        private OfficeDataDeleter _deleter;
       

        public OfficeDataService(ISqlExecutor sqlExecutor)
        {
            _sqlExecutor = sqlExecutor;
            _loader = new OfficeDataLoader(sqlExecutor);
            _saver = new OfficeDataSaver(sqlExecutor);
            _deleter = new OfficeDataDeleter(sqlExecutor);
        }

        public async Task<bool> DeleteOfficeAsyncDo(IOfficeData office)
        {
            return await _deleter.DeleteAsync(office.Value).ConfigureAwait(false);
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