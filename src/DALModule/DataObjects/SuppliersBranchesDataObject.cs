using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KarveDataServices.DataObjects;

namespace DataAccessLayer.DataObjects
{
    // branches, delegaciones.
    public class SuppliersBranchesDataObject : ISupplierBranchesData
    {
        public object Codigo { get ; set ; }
        public object Nombre { get ; set; }
        public object Direccion { get; set ; }
        public object Poblacion { get ; set ; }
        public object CP { get ; set ; }
        public object Provincia { get ; set ; }
        public object Telefono { get ; set ; }
        public object Email { get; set ; }
    }
}
