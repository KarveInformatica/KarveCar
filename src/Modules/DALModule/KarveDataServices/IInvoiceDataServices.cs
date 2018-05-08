using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataServices
{
    public interface IInvoiceDataServices
    {
        /// <summary>
        ///  Returns the list of invoices.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<InvoiceSummaryValueDto>> GetInvoiceSummaryAsync();
        /// <summary>
        ///  The invoice data has an invoice code.
        /// </summary>
        /// <param name="code">Invoice code to fetch the data</param>
        /// <returns>The invoice data.</returns>
        Task<IInvoiceData> GetInvoiceDoAsync(string code);

        /// <summary>
        ///  This generate an unique identifier in the invoice.
        /// </summary>
        /// <returns>The unique identifier.</returns>
        string NewId();
        /// <summary>
        /// Save or update an invoice
        /// </summary>
        /// <param name="currentInvoice"></param>
        /// <returns></returns>
        Task<bool> SaveAsync(IInvoiceData currentInvoice);
        /// <summary>
        /// Generate an invoice structure.
        /// </summary>
        /// <param name="s">Invoice structure</param>
        /// <returns></returns>
        IInvoiceData GetNewInvoiceDo(string s);
        /// <summary>
        /// Data to await for in the invoice.
        /// </summary>
        /// <param name="invoice">Invoice data</param>
        /// <returns></returns>
        Task<bool> DeleteAsync(IInvoiceData invoice);
    }
}
