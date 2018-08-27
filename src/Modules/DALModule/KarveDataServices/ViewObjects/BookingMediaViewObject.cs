using System.ComponentModel.DataAnnotations;

namespace KarveDataServices.ViewObjects
{
    /// <summary>
    ///  Set or get the medio res.
    /// </summary>
    public class BookingMediaViewObject: BaseViewObject
    {
        /// <summary>
        ///  Set or get the NOMBRE property.
        /// </summary>
        [Display(Name ="Codigo")]
        public new string Code { get; set; }

        /// <summary>
        ///  Set or get the CODIGO property.
        /// </summary>
        [Display(Name = "Nombre")]
        public new string Name { get; set; }
    }
}
