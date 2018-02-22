using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataServices.DataTransferObject
{
    public class SupplierSummaryDto
    {
        public string Codigo { get; set; }

        /// <summary>
        ///  Set or get the NOMBRE property.
        /// </summary>

        public string Nombre { get; set; }

        public string Proveedor { get; set; }

        public string Commercial { get; set; }
        /// <summary>
        ///  Set or get the DIRECCION property.
        /// </summary>

        public string Direccion { get; set; }

        /// <summary>
        ///  Set or get the DIREC2 property.
        /// </summary>

        public string Direccion2 { get; set; }

        /// <summary>
        ///  Set or get the POBLACION property.
        /// </summary>

        public string Poblacion { get; set; }

        /// <summary>
        ///  Set or get the CP property.
        /// </summary>

        public string CP { get; set; }

        /// <summary>
        ///  Set or get the PROV property.
        /// </summary>

        public string Provincia { get; set; }

        ///  Set or get the TELEFONO property.
       

        public string Telefono { get; set; }
        /// <summary>
        ///  AEAT
        /// </summary>

        public DateTime? F_AEAT { get; set; }

    }
}
