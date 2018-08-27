using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveDataServices;
using KarveDataServices.ViewObjects;
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
        public Task<bool> DeleteAsync(FareViewObject booking)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ActiveFareViewObject>> GetActiveSummaryFarePaged(string code, int index, int pageSize)
        {
            var queryStore = _factory.GetQueryStore();
            queryStore.AddParam(QueryType.QueryActiveFare, code, index,  pageSize);
            var query = queryStore.BuildQuery();
            using (var connection = SqlExecutor.OpenNewDbConnection())
            {
                if (connection!=null)
                {
                    var result = await connection.QueryAsync<ActiveFareViewObject>(query);
                    return result;
                }
            }
            return new List<ActiveFareViewObject>();
        }

        public Task<FareViewObject> GetDoAsync(string code)
        {
            throw new NotImplementedException();
        }

        public FareViewObject GetNewDo(string value)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<FareSummaryViewObject>> GetPagedSummaryDoAsync(int index, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<FareSummaryViewObject>> GetSummaryAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveAsync(FareViewObject bookingData)
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

        public Task<IEnumerable<FareViewObject>> GetListAsync(IList<FareViewObject> primaryKeys)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<FareViewObject>> GetListAsync(IList<string> primaryKeys)
        {
            throw new NotImplementedException();
        }
    }
}
