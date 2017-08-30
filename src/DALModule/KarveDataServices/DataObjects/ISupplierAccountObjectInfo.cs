using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataServices.DataObjects
{
    public interface ISupplierAccountObjectInfo
    {
        object AccountDescription { set; get; }
        object ExpensesAccountCode { set; get; }
        object ExpensesAccount {set; get;}
        object DeductionAccountCode { set; get; }
        object DeductionAccount { set; get; }
        object DeductionPercentage { set; get; }
        object PaymentAccountCode { set; get; }
        object PaymentAccount { set; get; }
        object IntraAccountSop { set; get; }
        object IntraAccountRep { set; get; }
        string IBAN { set; get; }
        object SWIFT { set; get; }
        string TransferAccount { set; get; }
    }
}
