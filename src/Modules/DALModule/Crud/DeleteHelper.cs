using KarveDataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using KarveDapper;
using KarveDapper.Extensions;
using Dapper;

namespace DataAccessLayer.Crud
{
    public static class DeleteHelper
    {

        public static async Task<bool> DeleteAsync<Entity1, Entity2, Summary>(ISqlExecutor executor, Entity1 entity1, Entity2 entity2, IEnumerable<Summary> param = null) 
            where Entity1: class 
            where Entity2: class 
            where Summary: class
        {
            var resultValue = true;

            using (var deleter = executor.OpenNewDbConnection())
            {
                using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    resultValue = await deleter.DeleteAsync<Entity1>(entity1).ConfigureAwait(false);
                    resultValue = resultValue && await deleter.DeleteAsync(entity2).ConfigureAwait(false);
                    if ((param != null) && (param.Any()))
                    {
                        resultValue = resultValue && await deleter.DeleteCollectionAsync(param).ConfigureAwait(false);
                    }
                    if (resultValue)
                    {
                        transactionScope.Complete();
                    }
                    else
                    {
                        transactionScope.Dispose();
                    }
                }
            }
            return resultValue;
        }

    }
}
