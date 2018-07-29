using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        [Display(Name = "Concepto")]

        public Int32 Concept { get; set; }
        ///  [Display(Name = "Contracto", Description = "Codigo de Contracto")]
        /// <summary>
        ///  Set or get the DESCCON property.
        /// </summary>
        [Display(Name = "Descuento")]
        public string Desccon{ get; set; }


        /// <summary>
        ///  Set or get the INCLUIDO property.
        /// </summary>
        [Display(Name = "Incluido")]
        public Int16? Included { get; set; }

        /// <summary>
        ///  Set or get the CANTIDAD property.
        /// </summary>
        [Display(Name = "Cantidad")]
        public Int32? Quantity { get; set; }

        /// <summary>
        ///  Set or get the UNIDAD property.
        /// </summary>
        [Display(Name = "Unidad")]
        public string Unity { get; set; }

        /// <summary>
        ///  Set or get the PRECIO property.
        /// </summary>
        [Display(Name = "Precio")]
        public Decimal? Price { get; set; }

        /// <summary>
        ///  Set or get the SUBTOTAL property.
        /// </summary>
        [Display(Name = "Subtotal")]
        public Decimal? Subtotal { get; set; }

        /// <summary>
        ///  Set or get the NUMERO property.
        /// </summary>
        [Display(Name = "Numero")]
        public string Number { get; set; }

        /// <summary>
        ///  Set or Get the EXTRA property.
        /// </summary>
        [Display(Name = "Extra")]
        public Int16? Extra { get; set; }



        [Display(Name="Minimo")]
        public Int32 Min { set; get; }

        [Display(Name="Max")]
        public Int32 Max { set; get; }



        /// <summary>
        /// Set or Get the number of days.
        /// </summary>
        [Display(Name = "Dias")]
        public string Days { get; set; }
        /// <summary>
        ///  Set or get the Type property.
        /// </summary>
        [Display(Name = "Tipo")]

        public byte? Type { get; set; }

        /// <summary>
        ///  Set or get the MONEDA property.
        /// </summary>
        public string Money { get; set; }

        /// <summary>
        ///  Set or get the IVA property.
        /// </summary>
        [Display(Name ="Iva")]
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
        [Display(Name ="Costo Unitario")]
        public Decimal? UnityCost { get; set; }

        /// <summary>
        ///  Set or get the COSTE property.
        /// </summary>
        [Display(Name = "Costo")]
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
        ///  Set or get the FACTURAR property.
        /// </summary>
        [Display(Name = "Facturar a")]
        public byte? Bill { get; set; }

        /// <summary>
        ///  Set or get the COT_MULTI property.
        /// </summary>

        public byte? MultipleQuote { get; set; }

        /// <summary>
        ///  Set or get the DTO property.
        /// </summary>
        [Display(Name = "Disconto")]
        public Decimal? Discount { get; set; }
    }
}
