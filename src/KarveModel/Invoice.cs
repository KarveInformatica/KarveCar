using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveDataServices.DataObjects;

namespace KarveModel
{
    /// <summary>
    ///  Invoice model.
    /// </summary>
    public class Invoice : KarveModel.DomainObject, IInvoiceData
    {
        public InvoiceDto Value { get; set; }
        /// <summary>
        ///  An invoice holds a list of invoice items. 
        ///  Each item is a just a line for an invoice.
        /// </summary>
        public IEnumerable<InvoiceItem> InvoiceItems { get; set;}

        public override void AcceptChanges()
        {
            
        }
        public override IEnumerable GetErrors(string propertyName)
        {
            throw new NotImplementedException();
        }

        public override void RejectChanges()
        {
            
        }
    }
}
