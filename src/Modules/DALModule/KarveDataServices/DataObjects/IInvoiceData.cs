using System;
using DevExpress.Xpo;
using System.Collections;
using System.Collections.Generic;

namespace KarveDataServices.DataObjects
{
    /// <summary>
    ///  Marker interface
    /// </summary>
    public interface IInvoiceData
    {
        /// <summary>
        ///  Return the value object from an entity.
        /// </summary>
        InvoiceDto Value { set; get; }
        /// <summary>
        /// Invoice item to be modeled.
        /// </summary>
        IEnumerable<InvoiceItem>  InvoiceItems { get; set;} 
    }

}