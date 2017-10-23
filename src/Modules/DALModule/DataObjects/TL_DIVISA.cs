using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a TL_DIVISA.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class TL_DIVISA 
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
    ///  Set or get the XCONVEURO property.
    /// </summary>
    
		public Decimal? XCONVEURO { get; set; }
 
	/// <summary>
    ///  Set or get the USUARIO property.
    /// </summary>
    
		public string USUARIO { get; set; }
 
	/// <summary>
    ///  Set or get the ULTMODI property.
    /// </summary>
    
		public string ULTMODI { get; set; }
 
	/// <summary>
    ///  Set or get the DREAL property.
    /// </summary>
    
		public Decimal? DREAL { get; set; }
 
	/// <summary>
    ///  Set or get the FREAL property.
    /// </summary>
    
		public DateTime? FREAL { get; set; }
 
	/// <summary>
    ///  Set or get the FULTCAMBIO property.
    /// </summary>
    
		public DateTime? FULTCAMBIO { get; set; }
	}
}
