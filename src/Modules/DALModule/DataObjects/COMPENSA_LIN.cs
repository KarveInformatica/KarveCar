using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a COMPENSA_LIN.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class COMPENSA_LIN 
	{
	
	/// <summary>
    ///  Set or get the NUMERO property.
    /// </summary>
    
		public string NUMERO { get; set; }
 
	/// <summary>
    ///  Set or get the PAGO property.
    /// </summary>
    
		public byte PAGO { get; set; }
 
	/// <summary>
    ///  Set or get the NUM_REC property.
    /// </summary>
    
		public string NUM_REC { get; set; }
 
	/// <summary>
    ///  Set or get the EXT_REC property.
    /// </summary>
    
		public string EXT_REC { get; set; }
 
	/// <summary>
    ///  Set or get the IMPORTE property.
    /// </summary>
    
		public Decimal? IMPORTE { get; set; }
 
	/// <summary>
    ///  Set or get the VTO property.
    /// </summary>
    
		public DateTime? VTO { get; set; }
 
	/// <summary>
    ///  Set or get the OFICINA property.
    /// </summary>
    
		public string OFICINA { get; set; }
	}
}
