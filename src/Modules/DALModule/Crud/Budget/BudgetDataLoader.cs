using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public BudgetDataLoader(ISqlExecutor sqlExecutor)
        {
            this.sqlExecutor = sqlExecutor;
        }

        public Task<IEnumerable<BudgetDto>> LoadAsyncAll()
        {
            throw new NotImplementedException();
        }

        public Task<BudgetDto> LoadValueAsync(string code)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BudgetDto>> LoadValueAtMostAsync(int n, int back = 0)
        {
            throw new NotImplementedException();
        }
    }
}
