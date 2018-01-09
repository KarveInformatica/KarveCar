using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataServices.DataTransferObject
{
    public class PriceConditionDto
    {

        public byte Codigo { get; set; }

        /// <summary>
        ///  Set or get the NOMBRE property.
        /// </summary>

        public string Nombre { get; set; }

        /// <summary>
        ///  Set or get the DESCRIPCION property.
        /// </summary>

        public string Description { get; set; }
    }
}
