using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a CONFI_RETEN.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class CONFI_RETEN 
	{
	
	/// <summary>
    ///  Set or get the EMPRESA property.
    /// </summary>
    
		public string EMPRESA { get; set; }
 
	/// <summary>
    ///  Set or get the LINEA property.
    /// </summary>
    
		public Int32 LINEA { get; set; }
 
	/// <summary>
    ///  Set or get the DESDE property.
    /// </summary>
    
		public Decimal? DESDE { get; set; }
 
	/// <summary>
    ///  Set or get the HASTA property.
    /// </summary>
    
		public Decimal? HASTA { get; set; }
 
	/// <summary>
    ///  Set or get the RETEN property.
    /// </summary>
    
		public Decimal? RETEN { get; set; }
	}
}
