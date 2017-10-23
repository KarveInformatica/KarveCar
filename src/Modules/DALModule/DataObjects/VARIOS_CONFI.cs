using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a VARIOS_CONFI.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class VARIOS_CONFI 
	{
	
	/// <summary>
    ///  Set or get the CODIGO property.
    /// </summary>
    
		public Int32 CODIGO { get; set; }
 
	/// <summary>
    ///  Set or get the NOMBRE_CF property.
    /// </summary>
    
		public string NOMBRE_CF { get; set; }
 
	/// <summary>
    ///  Set or get the STOCK_CF property.
    /// </summary>
    
		public Int32? STOCK_CF { get; set; }
 
	/// <summary>
    ///  Set or get the PRECIO_CF property.
    /// </summary>
    
		public Decimal? PRECIO_CF { get; set; }
 
	/// <summary>
    ///  Set or get the NO_BORRAR property.
    /// </summary>
    
		public byte? NO_BORRAR { get; set; }
 
	/// <summary>
    ///  Set or get the FINVEN property.
    /// </summary>
    
		public DateTime? FINVEN { get; set; }
	}
}
