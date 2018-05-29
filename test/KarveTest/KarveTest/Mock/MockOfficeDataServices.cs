using System.Collections.Generic;
using System.Threading.Tasks;
using KarveDataServices;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;
using DataAccessLayer.Model;
using System.ComponentModel;

namespace KarveTest.Mock
{
    internal class MockOfficeDataServices : IOfficeDataServices
    {
     

        /// <summary>
        /// 
        /// </summary>
        /// <param name="commissionAgent"></param>
        /// <returns></returns>
        public async Task<bool> DeleteOfficeAsyncDo(IOfficeData commissionAgent)
        {
            IOfficeData data = new Office();
            OfficeDtos dto = new OfficeDtos();
            data.Value = dto;
            data.Valid = true;
            if (string.IsNullOrEmpty(data.Value.Codigo))
            {
                throw new DataLayerException("Exception");
            }
            await Task.Delay(1000);
            return true;
        }
        public async Task<IEnumerable<OfficeSummaryDto>> GetAsyncAllOfficeSummary()
        {
            var officeSummary = new List<OfficeSummaryDto>()
            {
                new OfficeSummaryDto(){ Code="0001", City="Barcelona",Name="IBM R&D",CompanyName="IBM",Direction="Calle Paris 54",OfficeZone="RL1"},
                new OfficeSummaryDto(){ Code="0002", City="Barcelona",Name="Karve R&D",CompanyName="Karve Informatica S.L.",Direction="Calle Paris 54",OfficeZone="RL2"},
                new OfficeSummaryDto(){ Code="0003", City="Paris",Name="HP R&D",CompanyName="HP",Direction="Rue Bellvenue 54",OfficeZone="RL1"},
                new OfficeSummaryDto(){ Code="0004", City="Amsterdam",Name="Bank of America R&D",CompanyName="Bank of America",Direction="Calle Paris 54",OfficeZone="RL1"}
            };
            await Task.Delay(1000);
            return officeSummary;
        }
        public async Task<IOfficeData> GetAsyncOfficeDo(string clientIndentifier)
        {
            IOfficeData data = new Office();
            OfficeDtos dto = new OfficeDtos();
            data.Value = dto;
            data.Valid = true;
            if (string.IsNullOrEmpty(clientIndentifier))
            {
                throw new DataLayerException("Exception");
            }
            return data;
        }

        public async Task<IEnumerable<OfficeSummaryDto>> GetCompanyOffices(string companyCode)
        {
            List<OfficeSummaryDto> officeSummary = new List<OfficeSummaryDto>()
            {
                new OfficeSummaryDto(){ Code="0001", City="Barcelona",Name="IBM R&D",CompanyName="IBM",Direction="Calle Paris 54",OfficeZone="RL1"},
                new OfficeSummaryDto(){ Code="0002", City="Barcelona",Name="Karve R&D",CompanyName="Karve Informatica S.L.",Direction="Calle Paris 54",OfficeZone="RL2"},
                new OfficeSummaryDto(){ Code="0003", City="Paris",Name="HP R&D",CompanyName="HP",Direction="Rue Bellvenue 54",OfficeZone="RL1"},
                new OfficeSummaryDto(){ Code="0004", City="Amsterdam",Name="Bank of America R&D",CompanyName="Bank of America",Direction="Calle Paris 54",OfficeZone="RL1"}
            };
            await Task.Delay(1000);
            return officeSummary;
        }

        public Task<IEnumerable<HolidayDto>> GetHolidaysAsync(string officeId)
        {
            throw new System.NotImplementedException();
        }

        public string GetNewId()
        {
            return "00001";
        }
        public IOfficeData GetNewOfficeDo(string code)
        {
            IOfficeData data = new Office();
            OfficeDtos dto = new OfficeDtos();
            data.Value = dto;
            data.Valid = true;
            return data;
        }

        public Task<int> GetPageCount(int pageSize)
        {
            throw new System.NotImplementedException();
        }

        public int NumberPage { get; set; }
        public long NumberItems { get; set; }

        public Task<IEnumerable<OfficeSummaryDto>> GetPagedSummaryDoAsync(int baseIndex, int defaultPageSize)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<DailyTime>> GetTimeTableAsync(string officeId, string companyId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> SaveAsync(IOfficeData clientData)
        {
            OfficeDtos dto = clientData.Value;
            if (!clientData.Valid)
            {
                throw new DataLayerException("Trying to save invalid paramter");
            }
            await Task.Delay(1000);
            return true;
        }

        public Task<IEnumerable<OfficeSummaryDto>> GetSortedCollectionPagedAsync(Dictionary<string, ListSortDirection> sortChain, long index, int pageSize)
        {
            throw new System.NotImplementedException();
        }
    }
}