using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataServices.ViewObjects
{
    /// <summary>
    ///  InvoiceComponent.
    /// </summary>
    public interface InvoiceComponent
    {
        /// <summary>
        ///  Subtotal. This gives you a subtotal.
        /// </summary>
       decimal Subtotal { get; set; }
        /// <summary>
        /// Coste. This gives me the cost.
        /// </summary>
       decimal Coste { get; set; }
        /// <summary>
        ///  Double iva.
        /// </summary>
        decimal Iva { get; set; }
        /// <summary>
        /// Cantiad lif.
        /// </summary>
        decimal Cantidad { get; set; }
    }
}
