using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a CANON_AENA.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class CANON_AENA 
	{
	
	/// <summary>
    ///  Set or get the ID property.
    /// </summary>
    
		public Int32 ID { get; set; }
 
	/// <summary>
    ///  Set or get the CONCEPTO property.
    /// </summary>
    
		public string CONCEPTO { get; set; }
 
	/// <summary>
    ///  Set or get the SUBCONCEPTO property.
    /// </summary>
    
		public string SUBCONCEPTO { get; set; }
 
	/// <summary>
    ///  Set or get the FECHA property.
    /// </summary>
    
		public DateTime? FECHA { get; set; }
 
	/// <summary>
    ///  Set or get the CANON property.
    /// </summary>
    
		public Decimal? CANON { get; set; }
	}
}
