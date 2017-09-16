using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataObjects
{
    public class SupplierSummaryDataObject: BaseAuxDataObject
    {
        public string Numero { get; set; }
        public string Name { get; set; }
        public string Nif { get; set; }
    }
}
