using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using DataAccessLayer.SQL;
using Dapper;


namespace DataAccessLayer
{
    class FareDataServices : AbstractDataAccessLayer, IFareDataServices
    {
        private QueryStoreFactory _factory = new QueryStoreFactory();
        public FareDataServices(ISqlExecutor executor): base(executor)
        {
           
        }
        public Task<bool> DeleteAsync(FareDto booking)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ActiveFareDto>> GetActiveSummaryFarePaged(string code, int index, int pageSize)
        {
            var queryStore = _factory.GetQueryStore();
            queryStore.AddParam(QueryType.QueryActiveFare, code, index,  pageSize);
            var query = queryStore.BuildQuery();
            using (var connection = SqlExecutor.OpenNewDbConnection())
            {
                if (connection!=null)
                {
                    var result = await connection.QueryAsync<ActiveFareDto>(query);
                    return result;
                }
            }
            return new List<ActiveFareDto>();
        }

        public Task<FareDto> GetDoAsync(string code)
        {
            throw new NotImplementedException();
        }

        public FareDto GetNewDo(string value)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<FareSummaryDto>> GetPagedSummaryDoAsync(int index, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<FareSummaryDto>> GetSummaryAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveAsync(FareDto bookingData)
        {
            throw new NotImplementedException();
        }

        public  async Task<int> GetNumberOfActiveFares()
        {
            var queryStore = _factory.GetQueryStore();
            queryStore.AddParam(QueryType.QueryCountActiveFare);
            var query = queryStore.BuildQuery();
            using (var connection = SqlExecutor.OpenNewDbConnection())
            {
                if (connection != null)
                {
                    var result = await connection.QueryFirstOrDefault(query);
                    if (result != null)
                    {
                        return Convert.ToInt32(result);
                    }
                    return result;
                }
            }
            return -1;
        }
    }
}
