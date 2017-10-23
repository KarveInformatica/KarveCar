using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a TARJETAS_CLIENTE_SIPAY.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class TARJETAS_CLIENTE_SIPAY 
	{
	
	/// <summary>
    ///  Set or get the ID property.
    /// </summary>
    
		public Int64 ID { get; set; }
 
	/// <summary>
    ///  Set or get the NUMERO_CLI property.
    /// </summary>
    
		public string NUMERO_CLI { get; set; }
 
	/// <summary>
    ///  Set or get the CONTRACT_NUMBER property.
    /// </summary>
    
		public string CONTRACT_NUMBER { get; set; }
 
	/// <summary>
    ///  Set or get the TARCADU property.
    /// </summary>
    
		public string TARCADU { get; set; }
 
	/// <summary>
    ///  Set or get the FCADU property.
    /// </summary>
    
		public DateTime FCADU { get; set; }
	}
}
