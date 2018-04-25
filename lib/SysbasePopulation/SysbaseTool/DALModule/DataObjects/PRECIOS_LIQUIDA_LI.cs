using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a PRECIOS_LIQUIDA_LI.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class PRECIOS_LIQUIDA_LI 
	{
	
	/// <summary>
    ///  Set or get the CODIGO_PLL property.
    /// </summary>
    
		public byte CODIGO_PLL { get; set; }
 
	/// <summary>
    ///  Set or get the CONCEPTO_PLL property.
    /// </summary>
    
		public Int32 CONCEPTO_PLL { get; set; }
 
	/// <summary>
    ///  Set or get the FIJO_CONCEPTO_PLL property.
    /// </summary>
    
		public Decimal? FIJO_CONCEPTO_PLL { get; set; }
 
	/// <summary>
    ///  Set or get the POR_CONCEPTO_PLL property.
    /// </summary>
    
		public Decimal? POR_CONCEPTO_PLL { get; set; }
	}
}
