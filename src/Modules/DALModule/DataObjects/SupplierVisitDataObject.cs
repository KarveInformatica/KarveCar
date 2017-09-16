using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveDataServices;
using KarveDataServices.DataObjects;

namespace KarveDataAccessLayer.DataObjects
{
    class SupplierVisitDataObject : ISupplierVisitData
    {
        public object Fecha { get; set; }
        public object Delegacion { get; set; }
        public object Vendedor { get; set ; }
        public object Poblacion { get; set ; }
        public object CP { get ; set ; }
        public object Provincia { get ; set; }
        public object Telefono { get ; set ; }
        public object Email { get ; set ; }
    }
}
