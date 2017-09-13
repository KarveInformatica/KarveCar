using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveDataServices.DataObjects;

namespace DataAccessLayer.DataObjects
{
    /// <summary>
    ///  Supplier contacts.
    /// </summary>
    class SupplierContactsDataObject : ISupplierContactsData
    {
        public object Nombre { get ; set; }
        public object Cargo { get; set; }
        public object Departemento { get; set; }
        public object Telefono { get; set; }
        public object EMail { get ; set ; }
    }
}
