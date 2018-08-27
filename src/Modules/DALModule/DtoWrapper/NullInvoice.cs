using System.Collections.Generic;
using KarveDataServices.DataObjects;
using KarveDataServices.ViewObjects;

namespace DataAccessLayer.DtoWrapper
{
    /// <inheritdoc />
    /// <summary>
    ///  this is the null pattern 
    /// </summary>
    public class NullInvoice: IInvoiceData
    {
        public NullInvoice()
        {

            Value = new InvoiceViewObject
            {
                NUMERO_FAC = "0"
            };
            Valid = false;
        }
        /// <summary>
        ///  Return a default viewObject value
        /// </summary>
        public InvoiceViewObject Value { get; set; }
        /// <summary>
        ///  Check if the values is valid or not
        /// </summary>
        public bool Valid { get; set; }
        /// <inheritdoc />
        /// <summary>
        ///  Set or Get the summary of all invoices.
        /// The private is set because the only the data layer shall have the responsability to set it.
        /// </summary>
        public IEnumerable<InvoiceSummaryValueViewObject> InvoiceSummary { get; private set; }
        /// <inheritdoc />
        /// <summary>
        ///  Set or Get the contact of all invoice
        /// The private is set because the only the data layer shall have the responsability to set it.
        /// </summary>
        public IEnumerable<ContractViewObject> ContractSummary { get; private set; }
        /// <summary>
        ///  Set or Get the contact of all invoice
        /// The private is set because the only the data layer shall have the responsability to set it.
        /// </summary>
        public IEnumerable<ClientSummaryExtended> ClientSummary { get; set; }
        /// <summary>
        ///  Set or Get the contact of all invoice
        /// </summary>
        public IEnumerable<InvoiceSummaryViewObject> InvoiceItems { get ; set ; }
        /// <summary>
        ///  Number of the invoices
        /// </summary>
        public int NumberOfInvoices { get; set; }
        /// <summary>
        ///  Number of the clients.
        /// </summary>
        public int NumberOfClients { get ; set; }

       
    }

    
}
