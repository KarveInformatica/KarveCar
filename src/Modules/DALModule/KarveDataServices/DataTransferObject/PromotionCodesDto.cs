using System;
using System.ComponentModel.DataAnnotations;

namespace KarveDataServices.DataTransferObject
{
    /// <summary>
    ///  PromotionCodesDto. 
    /// This is a discount code to be used.
    /// </summary>
    public class PromotionCodesDto: BaseDto
    {
        /// <summary>
        ///  Set or get the CODIGO_PROMO property.
        /// </summary>
        [Display(Name= "Codigo Promoción")]
        public new string Code { get; set; }
        /// <summary>
        ///  Set or get the NOMBRE_PROMO property.
        /// </summary>
        [Display(Name ="Nombre")]
        public new string Name { get; set; }
        /// <summary>
        ///  Set or get the DTO_PROMO property.
        /// </summary>
        [Display(Name= "Descuento Promociónal")]
        public Decimal? Discount { get; set; }
        /// <summary>
        ///  Set or get the ES_ALQUILER_PROMO property.
        /// </summary>
        [Display(Name = "Promoción Alquiler")]
        public byte? IsRentingPromo { get; set; }
        /// <summary>
        ///  Set or get the ES_SEGURO_PROMO property.
        /// </summary>
        [Display(Name = "Promoción Seguro")]
        public byte? IsAssurancePromo { get; set; }

        /// <summary>
        ///  Set or get the CONCEPTO_PROMO property.
        /// </summary>
        [Display(Name = "Concepto")]
        public Int32? ConceptPromo { get; set; }
        /// <summary>
        ///  Set or get the DTO_FIJO_PROMO property.
        /// </summary>
        [Display(Name = "Promoción Descuento Fijo")]
        public Decimal? FixedDiscountPromo { get; set; }
        /// <summary>
        ///  Set or get the FALTA_PROMO property.
        /// </summary>
        [Display(Name = "Data de inicio promoción")]
        public DateTime? StartDatePromo { get; set; }
        /// <summary>
        ///  Set or get the FBAJA_PROMO property.
        /// </summary>
        [Display(Name = "Data de fine promoción")]
        public DateTime? EndDatePromo { get; set; }
        /// <summary>
        ///  Set or get the OBS_PROMO property.
        /// </summary>
        [Display(Name = "Observaciones")]
        public string NotesPromo { get; set; }
    }
}
