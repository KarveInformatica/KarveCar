using System;
using System.ComponentModel.DataAnnotations;

namespace KarveDataServices.ViewObjects
{
	
	public class FareViewObject: BaseViewObject
	{
	
	/// <summary>
    ///  Set or get the CODIGO property.
    /// </summary>
    [Display(Name="Codigo", Description ="Codigo Tarifa")]
		public override string Code { get; set; }

        /// <summary>
        ///  Set or get the NOMBRE property.
        /// </summary>
        [Display(Name = "Nombre", Description = "Nombre Tarifa")]
        public override string Name { get; set; }
        /// <summary>
        ///  Cod
        /// </summary>
         [Display(Name="Codigo Promotional", Description ="Codigo Promotional")]
        public string PromotionCode { set; get; }

 
	}
}
