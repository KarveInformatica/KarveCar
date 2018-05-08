using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveDataServices.DataTransferObject;

namespace InvoiceModule.Common
{
    /// <summary>
    ///  Helpers for computing the invoice values
    /// </summary>
    internal static class InvoiceHelpers
    {
        /// <summary>
        ///  This function computes the gross total.
        /// </summary>
        /// <param name="invoiceSummaryDtos">List of invoice objects</param>
        /// <returns></returns>
        public static decimal ComputeGrossTotal(IEnumerable<InvoiceSummaryDto> invoiceSummaryDtos)
        {
            decimal grossTotal = 0;
            foreach (var invoiceLine in invoiceSummaryDtos)
            {
                if (invoiceLine.Subtotal.HasValue)
                {
                    grossTotal += invoiceLine.Subtotal.Value;
                }
            }
            return grossTotal;
        }

      /// <summary>
      /// This returns the base value of the computation
      /// </summary>
      /// <param name="invoiceSummaryDtos">List of totals</param>
      /// <param name="discount">Value of discount</param>
      /// <returns></returns>
        public static decimal ComputeBase(IEnumerable<InvoiceSummaryDto> invoiceSummaryDtos, decimal discount)
        {
            var grossTotal = ComputeGrossTotal(invoiceSummaryDtos);
            var baseValue = grossTotal - (discount / 100);
            return baseValue;
        }
        /// <summary>
        ///  This compute the base lines.
        /// </summary>
        /// <param name="invoiceSummaryDtos">List of totals</param>
        /// <returns></returns>
        public static IEnumerable<decimal?> ComputeBaseLines(IEnumerable<InvoiceSummaryDto> invoiceSummaryDtos)
        {
            var subtotalList = invoiceSummaryDtos.Select(x => (x.Subtotal - (x.Discount)/100));
            return subtotalList;
        }
        /// <summary>
        ///  This computes the iva.
        /// </summary>
        /// <param name="baseValue">Base value</param>
        /// <param name="ivaValue">IVA value</param>
        /// <returns></returns>
        public static decimal ComputeIva(decimal baseValue, decimal ivaValue)
        {
            return (baseValue * ivaValue) / 100;
        }
    }
}
