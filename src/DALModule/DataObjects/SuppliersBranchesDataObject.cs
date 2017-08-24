using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataObjects
{
    public class SuppliersBranchesDataObject
    {
        public string Codigo { set; get; }
        public string Nombre { set; get; }
        public string Direccion { set; get; }
        public string CP { set; get; }
        public string Poblacion { set; get; }
        public string Provincia { set; get; }
        public string Telefono { set; get; }
        public string Email { set; get; }
    }
}
