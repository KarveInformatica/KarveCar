using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataServices.DataObjects
{
   public interface ISupplierContactsData
    {
            object Nombre { set; get; }
            object Cargo { set; get; }
            object Departemento { set; get; }
            object Telefono { set; get; }
            object EMail { set; get; }
    }
}
