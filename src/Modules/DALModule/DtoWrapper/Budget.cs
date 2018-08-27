using KarveDataServices.DataObjects;
using KarveDataServices.ViewObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DtoWrapper
{
    /// <summary>
    ///  Budget wrapper for Budget Dto.
    /// </summary>
    public class Budget : DomainObject, IBudgetData
    {
        private BudgetViewObject _dto;
        /// <summary>
        ///  Budget
        /// </summary>
        /// <param name="value"></param>
        public Budget(BudgetViewObject value)
        {
            _dto = value;
            Code = value.NUMERO_PRE;
            Valid = true;
        }
        /// <summary>
        ///  Get the budget data object.
        /// </summary>
        public BudgetViewObject Value
        {
          get => _dto;
          set => _dto = value;
        }
    }
}
