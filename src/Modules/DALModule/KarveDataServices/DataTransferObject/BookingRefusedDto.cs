using System.ComponentModel.DataAnnotations;

namespace KarveDataServices.DataTransferObject
{
    ///<summary>
    /// Refused booking
    ///</summary>
    public class BookingRefusedDto: BaseDto
    {
        /// <summary>
        ///  Set or get the CODIGO property.
        /// </summary>
        [Display(Name = "Codigo", Description = "Codigo")]
        public new string Code { get; set; }
        /// <summary>
        ///  Set or get the NOMBRE property.
        /// </summary>
        [Display(Name = "Motivo", Description = "Motivo de rechazo")]
        public new string Name { get; set; }
     }
}

