using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataServices.DataTransferObject
{
    public class CurrencyDto: BaseDto
    {
        /// <summary>
        ///  Set or get the CODIGO property.
        /// </summary>
        [Display(Name="Codigo")]
        public string Codigo { get; set; }

        /// <summary>
        ///  Set or get the NOMBRE property.
        /// </summary>
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        /// <summary>
        ///  Set or get the VENTA property.
        /// </summary>

        public Decimal? VENTA { get; set; }

        /// <summary>
        ///  Set or get the COMPRA property.
        /// </summary>

        public Decimal? COMPRA { get; set; }

        /// <summary>
        ///  Set or get the FEBAJA property.
        /// </summary>

        public DateTime? FEBAJA { get; set; }

        /// <summary>
        ///  Set or get the ULTMODI property.
        /// </summary>

        public string ULTMODI { get; set; }

        /// <summary>
        ///  Set or get the USUARIO property.
        /// </summary>

        public string USUARIO { get; set; }

    }
}
