using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.SQL;
using KarveDataServices;
using KarveDataServices.ViewObjects;

namespace DataAccessLayer.Crud.Budget
{
    /// <summary>
    ///  Loader for the budget table.
    /// </summary>
    class BudgetDataLoader: IDataLoader<BudgetViewObject>
    {
        private ISqlExecutor sqlExecutor;
        private QueryStoreFactory queryStoreFactory;

        public BudgetDataLoader(ISqlExecutor sqlExecutor)
        {
            this.sqlExecutor = sqlExecutor;
            this.queryStoreFactory = new QueryStoreFactory();
        }

        public Task<IEnumerable<BudgetViewObject>> LoadAsyncAll()
        {
            throw new NotImplementedException();
        }

        public async Task<BudgetViewObject> LoadValueAsync(string code)
        {
            var currentCode = code;
            var currentQueryStore = queryStoreFactory.GetQueryStore();
            var budget = new BudgetViewObject();
            return budget;
        }
    
        public Task<IEnumerable<BudgetViewObject>> LoadValueAtMostAsync(int n, int back = 0)
        {
            throw new NotImplementedException();
        }
    }
}
