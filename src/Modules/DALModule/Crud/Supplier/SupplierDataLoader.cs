using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KarveDataServices.DataTransferObject;
using DataAccessLayer.SQL;
using KarveDataServices;

namespace DataAccessLayer.Crud.Supplier
{

    public class SupplierDataLoader : IDataLoader<SupplierDto>
    {
        private QueryStoreFactory _queryStoreFactory;
        private ISqlExecutor _sqlExecutor;
        public SupplierDataLoader(ISqlExecutor sqlExecutor) : base()
        {
            _queryStoreFactory = new QueryStoreFactory();
            _sqlExecutor = sqlExecutor;
        }        
        public Task<IEnumerable<SupplierDto>> LoadAsyncAll()
        {
            throw new NotImplementedException();
        }

        public async Task<SupplierDto> LoadValueAsync(string code)
        {
            var queryStore = _queryStoreFactory.GetQueryStore();
            queryStore.AddParam(QueryType.QuerySupplierById, code);
            queryStore.AddParam(QueryType.QuerySuppliersBranches, code);
            queryStore.AddParam(QueryType.QuerySuppliersContacts, code);
            var query = queryStore.BuildQuery();
           // var multiple = 
            throw new NotImplementedException();
        }
      
        public Task<IEnumerable<SupplierDto>> LoadValueAtMostAsync(int n, int back = 0)
        {
            throw new NotImplementedException();
        }
    }

}