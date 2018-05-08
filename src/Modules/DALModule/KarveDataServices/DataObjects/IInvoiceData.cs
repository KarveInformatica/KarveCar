using System.Collections.Generic;
using KarveDataServices.DataTransferObject;

namespace KarveDataServices.DataObjects
{
    /// <summary>
    ///  Marker interface
    /// </summary>
    public interface IInvoiceData: IValidDomainObject
    {
        /// <summary>
        ///  Return the value object from an entity.
        /// </summary>
        InvoiceDto Value { set; get; }
        /// <summary>
        /// ContractSummary 
        /// </summary>
        IEnumerable<ContractDto> ContractSummary { get; }
        /// <summary>
        /// Client summary dto.
        /// </summary>
        IEnumerable<ClientSummaryDto> ClientSummary { get; }

        /// <summary>
        /// InvoiceSummary
        /// </summary>
        IEnumerable<InvoiceSummaryDto> InvoiceItems { get; set; }
        /// <summary>
        /// InvoiceSummary
        /// </summary>
        IEnumerable<InvoiceSummaryValueDto> InvoiceSummary { get; }

    }

}