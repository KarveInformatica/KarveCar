using System;
using DevExpress.Xpo;

namespace KarveDataServices.DataObjects
{

    public interface IInvoiceData
    {
        string Code { set; get; }
        InvoiceDto Value { set; get; }
    }

}