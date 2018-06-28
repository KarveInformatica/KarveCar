using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataServices.DataTransferObject
{

    /// <summary>
    ///  Forma de pago dto.
    /// </summary>
    public class PaymentFormDto: BaseDto
    {
        /// <summary>
        ///  Set or get the CODIGO property.
        /// </summary>
        [Display(Name="Codigo")]
        [Required]
        public byte Codigo { get; set; }

        /// <summary>
        ///  Set or get the NOMBRE property.
        /// </summary>
        [Display(Name="Nombre")]
        public string Nombre { get; set; }

        /// <summary>
        ///  Set or get the CUENTA property.
        /// </summary>

        public string Cuenta { get; set; }
        
    }
}
