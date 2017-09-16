using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataServices.DataObjects
{
    public interface ISupplierVisitData
    {
        object Fecha { set; get; }
        object Delegacion { set; get; }
        object Vendedor { set; get; }
        object Poblacion { set; get; }
        object CP { set; get; }
        object Provincia { set; get; }
        object Telefono { set; get; }
        object Email { set; get; }
    }
}
