using AutoMapper;
using DataAccessLayer.DataObjects;
using DataAccessLayer.Logic;
using KarveDataServices;
using KarveDataServices.ViewObjects;
using System;
using System.Threading.Tasks;
using System.Transactions;

namespace DataAccessLayer.Crud.Budget
{
    /// <summary>
    ///  Class that has the single resposability to delete a budget.
    /// </summary>
    class BudgetDataDeleter : IDataDeleter<BudgetViewObject>
    {
        private ISqlExecutor _sqlExecutor;
        private IMapper _mapper;
        /// <summary>
        ///  Constructor.
        /// </summary>
        /// <param name="sqlExector"></param>
        public BudgetDataDeleter(ISqlExecutor sqlExector)
        {
            _sqlExecutor = sqlExector;
            _mapper = MapperField.GetMapper();
        }
        public async Task<bool> DeleteAsync(BudgetViewObject data)
        {
            var presup1 = new PRESUP1() { NUMERO_PRE = data.NUMERO_PRE };
            var presup2 = new PRESUP2() { NUMERO_PRE = data.NUMERO_PRE };
            var resultValue = false;
            using (var deleter = _sqlExecutor.OpenNewDbConnection())
            {
                using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    resultValue = await  DeleteHelper.DeleteAsync<PRESUP1, PRESUP2, PRESUP1>(_sqlExecutor, presup1, presup2);
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
