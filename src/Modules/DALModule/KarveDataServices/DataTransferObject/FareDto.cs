using System;
using System.ComponentModel.DataAnnotations;

namespace KarveDataServices.DataTransferObject
{
	
	public class FareDto: BaseDto
	{
	
	/// <summary>
    ///  Set or get the CODIGO property.
    /// </summary>
    [Display(Name="Codigo", Description ="Codigo Tarifa")]
		public string Code { get; set; }

        /// <summary>
        ///  Set or get the NOMBRE property.
        /// </summary>
        [Display(Name = "Nombre", Description = "Nombre Tarifa")]
        public string Name { get; set; }
        /// <summary>
        ///  Cod
        /// </summary>
         [Display(Name="Codigo Promotional", Description ="Codigo Promotional")]
        public string PromotionCode { set; get; }

 
	}
}
