using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a TIN_MBZ.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class TIN_MBZ 
	{
	
	/// <summary>
    ///  Set or get the PLAZO property.
    /// </summary>
    
		public Int32? PLAZO { get; set; }
 
	/// <summary>
    ///  Set or get the TIN property.
    /// </summary>
    
		public Decimal? TIN { get; set; }
 
	/// <summary>
    ///  Set or get the SUBLICEN property.
    /// </summary>
    
		public string SUBLICEN { get; set; }
 
	/// <summary>
    ///  Set or get the LINEA property.
    /// </summary>
    
		public byte LINEA { get; set; }
	}
}
