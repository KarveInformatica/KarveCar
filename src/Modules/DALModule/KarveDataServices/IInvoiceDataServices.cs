using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataServices
{
    public interface IInvoiceDataServices: IPageCounter, IIdentifier, IDataProvider<IInvoiceData, InvoiceSummaryValueDto>
    {
       
       
    }
}
