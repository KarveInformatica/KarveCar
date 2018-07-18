using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.SQL;
using KarveDataServices;
using KarveDataServices.DataTransferObject;

namespace DataAccessLayer.Crud.Budget
{
    /// <summary>
    ///  Loader for the budget table.
    /// </summary>
    class BudgetDataLoader: IDataLoader<BudgetDto>
    {
        private ISqlExecutor sqlExecutor;
        private QueryStoreFactory queryStoreFactory;

        public BudgetDataLoader(ISqlExecutor sqlExecutor)
        {
            this.sqlExecutor = sqlExecutor;
        }

        public Task<IEnumerable<BudgetDto>> LoadAsyncAll()
        {
            throw new NotImplementedException();
        }

        public async Task<BudgetDto> LoadValueAsync(string code)
        {
            var currentCode = code;
            var currentQueryStore = queryStoreFactory.GetQueryStore();
            var budget = new BudgetDto();
            return budget;
        }
    
        public Task<IEnumerable<BudgetDto>> LoadValueAtMostAsync(int n, int back = 0)
        {
            throw new NotImplementedException();
        }
    }
}
