using System.Collections.Generic;
using KarveDataServices.ViewObjects;

namespace KarveDataServices.DataObjects
{
    /// <summary>
    ///  Marker interface
    /// </summary>
    public interface IInvoiceData: IValidDomainObject, IValueObject<InvoiceViewObject>
    {
        /// <summary>
        /// ContractSummary 
        /// </summary>
        IEnumerable<ContractViewObject> ContractSummary { get; }
        /// <summary>
        /// Client summary viewObject.
        /// </summary>
        IEnumerable<ClientSummaryExtended> ClientSummary { get; }

        /// <summary>
        /// InvoiceSummary
        /// </summary>
        IEnumerable<InvoiceSummaryViewObject> InvoiceItems { get; set; }
        /// <summary>
        /// InvoiceSummary
        /// </summary>
        IEnumerable<InvoiceSummaryValueViewObject> InvoiceSummary { get; }
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