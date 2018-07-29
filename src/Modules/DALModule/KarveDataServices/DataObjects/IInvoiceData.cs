using System.Collections.Generic;
using KarveDataServices.DataTransferObject;

namespace KarveDataServices.DataObjects
{
    /// <summary>
    ///  Marker interface
    /// </summary>
    public interface IInvoiceData: IValidDomainObject, IValueObject<InvoiceDto>
    {
        /// <summary>
        /// ContractSummary 
        /// </summary>
        IEnumerable<ContractDto> ContractSummary { get; }
        /// <summary>
        /// Client summary dto.
        /// </summary>
        IEnumerable<ClientSummaryExtended> ClientSummary { get; }

        /// <summary>
        /// InvoiceSummary
        /// </summary>
        IEnumerable<InvoiceSummaryDto> InvoiceItems { get; set; }
        /// <summary>
        /// InvoiceSummary
        /// </summary>
        IEnumerable<InvoiceSummaryValueDto> InvoiceSummary { get; }
        /// <summary>
        ///  This gives the number of invoices.
        /// </summary>
        int NumberOfInvoices { get; set; }
        /// <summary>
        /// This gives the number of clients.
        /// </summary>
        int NumberOfClients { get; set; }

    }

}