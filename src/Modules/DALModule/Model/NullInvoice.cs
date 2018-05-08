using System.Collections.Generic;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;

namespace DataAccessLayer.Model
{
    /// <inheritdoc />
    /// <summary>
    ///  this is the null pattern 
    /// </summary>
    public class NullInvoice: IInvoiceData
    {
        public NullInvoice()
        {

            Value = new InvoiceDto
            {
                NUMERO_FAC = "0"
            };
            Valid = false;
        }
        /// <summary>
        ///  Return a default dto value
        /// </summary>
        public InvoiceDto Value { get; set; }
        /// <summary>
        ///  Check if the values is valid or not
        /// </summary>
        public bool Valid { get; set; }
        /// <inheritdoc />
        /// <summary>
        ///  Set or Get the summary of all invoices.
        /// The private is set because the only the data layer shall have the responsability to set it.
        /// </summary>
        public IEnumerable<InvoiceSummaryValueDto> InvoiceSummary { get; private set; }
        /// <inheritdoc />
        /// <summary>
        ///  Set or Get the contact of all invoice
        /// The private is set because the only the data layer shall have the responsability to set it.
        /// </summary>
        public IEnumerable<ContractDto> ContractSummary { get; private set; }
        /// <summary>
        ///  Set or Get the contact of all invoice
        /// The private is set because the only the data layer shall have the responsability to set it.
        /// </summary>
        public IEnumerable<ClientSummaryDto> ClientSummary { get; private set; }
        /// <summary>
        ///  Set or Get the contact of all invoice
        /// </summary>
        public IEnumerable<InvoiceSummaryDto> InvoiceItems { get ; set ; }
    }

    
}
