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

        
    }
}
