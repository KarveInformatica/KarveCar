using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a DIVISAS.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class DIVISAS 
	{
	
	/// <summary>
    ///  Set or get the CODIGO property.
    /// </summary>
    
		public string CODIGO { get; set; }
 
	/// <summary>
    ///  Set or get the NOMBRE property.
    /// </summary>
    
		public string NOMBRE { get; set; }
 
	/// <summary>
    ///  Set or get the VENTA property.
    /// </summary>
    
		public Decimal? VENTA { get; set; }
 
	/// <summary>
    ///  Set or get the COMPRA property.
    /// </summary>
    
		public Decimal? COMPRA { get; set; }
 
	/// <summary>
    ///  Set or get the FEBAJA property.
    /// </summary>
    
		public DateTime? FEBAJA { get; set; }
 
	/// <summary>
    ///  Set or get the ULTMODI property.
    /// </summary>
    
		public string ULTMODI { get; set; }
 
	/// <summary>
    ///  Set or get the USUARIO property.
    /// </summary>
    
		public string USUARIO { get; set; }
	}
}
