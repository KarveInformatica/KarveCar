using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a DTO_CATEGO.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class DTO_CATEGO 
	{
	
	/// <summary>
    ///  Set or get the CODIGO_DC property.
    /// </summary>
    
		public Int32 CODIGO_DC { get; set; }
 
	/// <summary>
    ///  Set or get the CATEGO_DC property.
    /// </summary>
    
		public string CATEGO_DC { get; set; }
 
	/// <summary>
    ///  Set or get the DESDE_DC property.
    /// </summary>
    
		public DateTime? DESDE_DC { get; set; }
 
	/// <summary>
    ///  Set or get the HASTA_DC property.
    /// </summary>
    
		public DateTime? HASTA_DC { get; set; }
 
	/// <summary>
    ///  Set or get the DTO_DC property.
    /// </summary>
    
		public Decimal? DTO_DC { get; set; }
 
	/// <summary>
    ///  Set or get the BAJA_DC property.
    /// </summary>
    
		public byte? BAJA_DC { get; set; }
	}
}
