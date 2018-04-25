using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a CLIENTES_VIASPAGO.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class CLIENTES_VIASPAGO 
	{
	
	/// <summary>
    ///  Set or get the ID property.
    /// </summary>
    
		public Int64 ID { get; set; }
 
	/// <summary>
    ///  Set or get the VIA property.
    /// </summary>
    
		public string VIA { get; set; }
 
	/// <summary>
    ///  Set or get the CLIENTE property.
    /// </summary>
    
		public string CLIENTE { get; set; }
 
	/// <summary>
    ///  Set or get the INICIO property.
    /// </summary>
    
		public DateTime? INICIO { get; set; }
 
	/// <summary>
    ///  Set or get the FIN property.
    /// </summary>
    
		public DateTime? FIN { get; set; }
 
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
