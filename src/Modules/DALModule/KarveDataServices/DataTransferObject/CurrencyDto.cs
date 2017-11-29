using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataServices.DataTransferObject
{
    public class CurrencyDto
    {
        /// <summary>
        ///  Set or get the CODIGO property.
        /// </summary>

        public string CODIGO { get; set; }

        /// <summary>
        ///  Set or get the NOMBRE property.
        /// </summary>

        public string NOMBRE { get; set; }

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
