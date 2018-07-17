using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    /// <summary>
    ///  Budget wrapper for Budget Dto.
    /// </summary>
    public class Budget : DomainObject, IBudgetData
    {
        private BudgetDto _dto;
        /// <summary>
        ///  Budget
        /// </summary>
        /// <param name="value"></param>
        public Budget(BudgetDto value)
        {
            _dto = value;
            Code = value.NUMERO_PRE;
            Valid = true;
        }
        /// <summary>
        ///  Get the budget data object.
        /// </summary>
        public BudgetDto Value
        {
          get => _dto;
          set => _dto = value;
        }
    }
}
