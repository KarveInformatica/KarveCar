using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataServices.DataTransferObject
{
    public class AgentDto
    {

        /// <summary>
        ///  Set or get the NUM_PROPIE property.
        /// </summary>

        public string Codigo { get; set; }

        /// <summary>
        ///  Set or get the NOMBRE property.
        /// </summary>

        public string Nombre { get; set; }

        /// <summary>
        ///  Set or get the DIRECCION property.
        /// </summary>

        public string Direccion { get; set; }

        /// <summary>
        ///  Set or get the POBLACION property.
        /// </summary>

        public string Poblacion { get; set; }
        /// <summary>
        ///  codigo postal
        /// </summary>
        public string CP { get; set; }


        public string Provincia { get; set; }
        /// <summary>
        ///  Set or get the NIF property.
        /// </summary>

        public string NIF { get; set; }

        /// <summary>
        ///  Set or get the TELEFONO property.
        /// </summary>
        public string Telefono { get; set; }
    }
}
