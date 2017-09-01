using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataServices.DataObjects
{
    public interface ISupplierAccountObjectInfo
    {
        string PrefixAccount { set; get; }
        string AccountableAccount { set; get; }
        string AccountName { set; get; }
        double AccountBalance { set; get; }
        string AccountDescription { set; get; }
        string AccountDescription2 { set; get; }
        string ExpensesAccountCode { set; get; }
        string ExpensesAccount {set; get;}
        // cuenta efectos
        string CustomerAccount { set; get; }
        string DeductionAccountCode { set; get; }
        object DeductionAccount { set; get; }
        object DeductionPercentage { set; get; }
        object PaymentAccountCode { set; get; }
        object PaymentAccount { set; get; }
        object IntraAccountSop { set; get; }
        object IntraAccountRep { set; get; }
        string IBAN { set; get; }
        object SWIFT { set; get; }
        string TransferAccount { set; get; }
        // ULTMODI
        string LastChange { set; get; }
        // USUARIO
        string ChangedByUser { set; get; }
        string Sublicen { get; set; }
        object Active { get; set; }
        bool IsInvoiceManagementEnabled { get; set; }
        object edKCli { get; set; }
        object Nif { get; set; }
        string CommissionNumber { get; set; }
    }
}
