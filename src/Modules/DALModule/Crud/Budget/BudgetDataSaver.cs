using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataAccessLayer.Logic;
using KarveCommonInterfaces;
using KarveDataServices;
using KarveDataServices.ViewObjects;

namespace DataAccessLayer.Crud.Budget
{
    /// <summary>
    ///  Class that has the single resposability to save a budget.
    /// </summary>
    class BudgetDataSaver: IDataSaver<BudgetViewObject>
    {
        private ISqlExecutor _sqlExecutor;
        private IMapper _mapper;
        private IValidationChain<BudgetViewObject> _validationChain;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="sqlExecutor">sql executor</param>
        public BudgetDataSaver(ISqlExecutor sqlExecutor)
        {
            this._sqlExecutor = sqlExecutor;
            this._mapper = MapperField.GetMapper();
        }


        ///  Returns the validation chain
        /// </summary>
        public IValidationChain<BudgetViewObject> ValidationChain
        {
            set { _validationChain = value; }
            get { return _validationChain; }
        }
        /// <summary>
        ///  Save a value asynchronously.
        /// </summary>
        /// <param name="data">Data to be saved</param>
        /// <returns></returns>
        public async Task<bool> SaveAsync(BudgetViewObject data)
        {
            throw new NotImplementedException();
        }
    }
}
