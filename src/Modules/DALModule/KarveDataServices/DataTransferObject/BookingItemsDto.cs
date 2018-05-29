using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataServices.DataTransferObject
{

    /// <summary>
    /// BookingItems Data Transfer Object.
    /// </summary>
    public class BookingItemsDto: BaseDto
    {
        /// <summary>
        ///  Set or get the TARIFA property.
        /// </summary>

        public string Fare { get; set; }

        /// <summary>
        ///  Set or get the GRUPO property.
        /// </summary>

        public string Group { get; set; }

        /// <summary>
        ///  Set or get the CONCEPTO property.
        /// </summary>

        public Int32 Concept { get; set; }

        /// <summary>
        ///  Set or get the DESCCON property.
        /// </summary>

        public string Desccon{ get; set; }

        /// <summary>
        ///  Set or get the FACTURAR property.
        /// </summary>

        public byte? Bill { get; set; }

        /// <summary>
        ///  Set or get the INCLUIDO property.
        /// </summary>

        public Int16? Included { get; set; }

        /// <summary>
        ///  Set or get the CANTIDAD property.
        /// </summary>

        public Int32? Quantity { get; set; }

        /// <summary>
        ///  Set or get the UNIDAD property.
        /// </summary>

        public string Unity { get; set; }

        /// <summary>
        ///  Set or get the PRECIO property.
        /// </summary>

        public Decimal? Price { get; set; }

        /// <summary>
        ///  Set or get the SUBTOTAL property.
        /// </summary>

        public Decimal? Subtotal { get; set; }

        /// <summary>
        ///  Set or get the NUMERO property.
        /// </summary>

        public string Number { get; set; }

        /// <summary>
        ///  Set or Get the EXTRA property.
        /// </summary>

        public Int16? Extra { get; set; }

        /// <summary>
        /// Set or Get the number of days.
        /// </summary>
        public string Days { get; set; }
        /// <summary>
        ///  Set or get the Type property.
        /// </summary>
        public byte? Type { get; set; }

        /// <summary>
        ///  Set or get the MONEDA property.
        /// </summary>

        public string Money { get; set; }

        /// <summary>
        ///  Set or get the IVA property.
        /// </summary>

        public Decimal? Iva { get; set; }

        /// <summary>
        ///  Set or get the BookingKey.
        /// </summary>

        public Int64 BookingKey { get; set; }

        /// <summary>
        ///  Set or get the MAQUINA property.
        /// </summary>

        public string Machine { get; set; }

        /// <summary>
        ///  Set or get the COSTEU property.
        /// </summary>

        public Decimal? UnityCost { get; set; }

        /// <summary>
        ///  Set or get the COSTE property.
        /// </summary>

        public Decimal? Cost { get; set; }

        /// <summary>
        ///  Set or get the PRECIO_TT property.
        /// </summary>

        public Decimal? TotalPriceTT { get; set; }

        /// <summary>
        ///  Set or get the SUBTOTAL_TT property.
        /// </summary>

        public Decimal? SubtotalTt { get; set; }

        /// <summary>
        ///  Set or get the PRECIO_IMP property.
        /// </summary>

        public Decimal? TaxablePrice { get; set; }

        /// <summary>
        ///  Set or get the SUBTOTAL_IMP property.
        /// </summary>

        public Decimal? TaxableSubtotal { get; set; }

        /// <summary>
        ///  Set or get the COT_MULTI property.
        /// </summary>

        public byte? MultipleQuote { get; set; }

        /// <summary>
        ///  Set or get the DTO property.
        /// </summary>

        public Decimal? Discount { get; set; }
    }
}
