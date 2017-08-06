using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace KarveDataServices
{
    public interface IPaymentDataServices
    {
        /// <summary>
        ///  Get all kind of charging a payment 
        /// </summary>
        /// <returns></returns>
        DataTable GetChargeObjects();
        /// <summary>
        ///  Get all kind of invoices
        /// </summary>
        /// <returns></returns>
        DataTable GetAllInvoiceTypeDataTable();
        /// <summary>
        ///  Retrive the bank account name using a code
        /// </summary>
        /// <param name="inCode">bank account code </param>
        /// <returns></returns>
        string GetAccountDefinitionByCode(string inCode);
        /// <summary>
        /// Get all accounts
        /// </summary>
        /// <returns></returns>
        DataTable GetAllAccountsDataTable();
        /// <summary>
        /// Get the kind of payment charging options giving the input code of the payment.
        /// </summary>
        /// <param name="selectedItemCode"></param>
        /// <returns></returns>
        IDictionary<string, bool> GetChargeOptions(int selectedItemCode);
        /// <summary>
        /// Get all offices per invoice data table.
        /// </summary>
        /// <returns></returns>
        DataTable GetAllInvoiceOfficesDataTable();
    }
}
