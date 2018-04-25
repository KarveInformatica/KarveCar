using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataServices.DataObjects
{
    public interface ISupplierBranchesData
    {
        object Codigo { set; get; } 
        object Nombre { set; get; }
        object Direccion { set; get; }
        object Poblacion { set; get; }
        object CP { set; get; }
        object Provincia { set; get; }
        object Telefono { set; get; }
        object Email { set; get; }      
    }
}
