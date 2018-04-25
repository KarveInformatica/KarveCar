using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a PRECIOS_GRUPO.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class PRECIOS_GRUPO 
	{
	
	/// <summary>
    ///  Set or get the GRUPO property.
    /// </summary>
    
		public string GRUPO { get; set; }
 
	/// <summary>
    ///  Set or get the CONCEPTO property.
    /// </summary>
    
		public Int32 CONCEPTO { get; set; }
 
	/// <summary>
    ///  Set or get the PRECIO property.
    /// </summary>
    
		public Decimal? PRECIO { get; set; }
	}
}
