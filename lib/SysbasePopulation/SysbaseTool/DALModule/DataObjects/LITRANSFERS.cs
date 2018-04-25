using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a LITRANSFERS.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class LITRANSFERS 
	{
	
	/// <summary>
    ///  Set or get the TRANSFER property.
    /// </summary>
    
		public Int32 TRANSFER { get; set; }
 
	/// <summary>
    ///  Set or get the LINEA property.
    /// </summary>
    
		public Int32 LINEA { get; set; }
 
	/// <summary>
    ///  Set or get the GRUPO property.
    /// </summary>
    
		public string GRUPO { get; set; }
 
	/// <summary>
    ///  Set or get the PRECIO property.
    /// </summary>
    
		public Decimal? PRECIO { get; set; }
	}
}
