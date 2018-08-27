using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KarveDataServices.ViewObjects
{
    public class AgentViewObject : BaseViewObject
    {

        /// <summary>
        ///  Set or get the NUM_PROPIE property.
        /// </summary>
        [PrimaryKey]
        [Required]
        public string Codigo { get; set; }

        /// <summary>
        ///  Set or get the NOMBRE property.
        /// </summary>
        [Required]
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

        public override bool HasErrors
        {
            get
            {
                var chain = false;
                if (Nombre == null)
                {
                    ErrorList.Add(ConstantDataError.AgentNamePresent);
                    chain = true;
                }
                if ((Nombre != null) && (Nombre.Length > 30))
                {
                    ErrorList.Add(ConstantDataError.AgentNameTooLong);
                    chain = chain || true;
                }
               
                return chain;
            }
        }
    }
}
