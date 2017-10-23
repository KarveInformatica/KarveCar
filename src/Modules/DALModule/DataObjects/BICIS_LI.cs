using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a BICIS_LI.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class BICIS_LI 
	{
	
	/// <summary>
    ///  Set or get the ALQUILER property.
    /// </summary>
    
		public string ALQUILER { get; set; }
 
	/// <summary>
    ///  Set or get the CODIINT property.
    /// </summary>
    
		public string CODIINT { get; set; }
 
	/// <summary>
    ///  Set or get the LINEA property.
    /// </summary>
    
		public Int32? LINEA { get; set; }
 
	/// <summary>
    ///  Set or get the PRECIO_BIL property.
    /// </summary>
    
		public Decimal? PRECIO_BIL { get; set; }
 
	/// <summary>
    ///  Set or get the SUBTOTAL_BIL property.
    /// </summary>
    
		public Decimal? SUBTOTAL_BIL { get; set; }
 
	/// <summary>
    ///  Set or get the FIJO_LI property.
    /// </summary>
    
		public byte? FIJO_LI { get; set; }
	}
}
