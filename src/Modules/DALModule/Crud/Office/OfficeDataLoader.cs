using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.DataObjects;
using DataAccessLayer.SQL;
using KarveDataServices.DataTransferObject;
using KarveDataServices;

namespace DataAccessLayer.Crud.Office
{

    /// <summary>
    ///  Loader of the data 
    /// </summary>
    public class OfficeDataLoader: IDataLoader<OfficeDtos> 
    {
        private ISqlExecutor _executor;
        public OfficeDataLoader(ISqlExecutor executor)
        {
            _executor = executor;
        }

        public Task<IEnumerable<OfficeDtos>> LoadAsyncAll()
        {
            throw new NotImplementedException();
        }

        public Task<OfficeDtos> LoadValueAsync(string code)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OfficeDtos>> LoadValueAtMostAsync(int n, int back = 0)
        {
            throw new NotImplementedException();
        }

        private QueryStore CreateQueryStore(OFICINAS office)
        {
            QueryStore store = new QueryStore();
            store.AddParam(QueryStore.QueryType.QueryCity, office.CP);
            store.AddParam(QueryStore.QueryType.QueryOfficeZone, office.ZONAOFI);
            return store;
        }

    }

}