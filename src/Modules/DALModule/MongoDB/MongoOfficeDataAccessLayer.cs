using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using KarveDataServices;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;

namespace DataAccessLayer.MongoDB
{
    internal class MongoOfficeDataAccessLayer : IOfficeDataServices
    {
        public int NumberPage { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public long NumberItems { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public Task<bool> DeleteAsync(IOfficeData booking)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteOfficeAsyncDo(IOfficeData data)
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

        public Task<IOfficeData> GetDoAsync(string code)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<HolidayDto>> GetHolidaysAsync(string officeId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<IOfficeData>> GetListAsync(IList<IOfficeData> primaryKeys)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<IOfficeData>> GetListAsync(IList<string> primaryKeys)
        {
            throw new System.NotImplementedException();
        }

        public IOfficeData GetNewDo(string value)
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

        public Task<int> GetPageCount(int pageSize)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<OfficeSummaryDto>> GetPagedSummaryDoAsync(int baseIndex, int defaultPageSize)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<OfficeSummaryDto>> GetSortedCollectionPagedAsync(Dictionary<string, ListSortDirection> sortChain, long index, int pageSize)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<OfficeSummaryDto>> GetSummaryAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<DailyTime>> GetTimeTableAsync(string officeId, string companyId)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> SaveAsync(IOfficeData data)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> SaveHolidaysAsync(IEnumerable<HolidayDto> holidaysDates)
        {
            throw new System.NotImplementedException();
        }

        public Task SaveHolidaysAsync(OfficeDtos dto, IEnumerable<HolidayDto> holidaysDates)
        {
            throw new System.NotImplementedException();
        }
    }
}