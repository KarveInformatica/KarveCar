using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a DIVI_HISTO.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class DIVI_HISTO 
	{
	
	/// <summary>
    ///  Set or get the CODIGO property.
    /// </summary>
    
		public Int32 CODIGO { get; set; }
 
	/// <summary>
    ///  Set or get the FECHA property.
    /// </summary>
    
		public DateTime? FECHA { get; set; }
 
	/// <summary>
    ///  Set or get the DIVISA property.
    /// </summary>
    
		public string DIVISA { get; set; }
 
	/// <summary>
    ///  Set or get the VENTA property.
    /// </summary>
    
		public Decimal? VENTA { get; set; }
 
	/// <summary>
    ///  Set or get the COMPRA property.
    /// </summary>
    
		public Decimal? COMPRA { get; set; }
 
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
