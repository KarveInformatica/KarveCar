using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a PROMOS.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class PROMOS 
	{
	
	/// <summary>
    ///  Set or get the CODIGO property.
    /// </summary>
    
		public Int32 CODIGO { get; set; }
 
	/// <summary>
    ///  Set or get the NOMBRE property.
    /// </summary>
    
		public string NOMBRE { get; set; }
 
	/// <summary>
    ///  Set or get the PROVEE property.
    /// </summary>
    
		public string PROVEE { get; set; }
 
	/// <summary>
    ///  Set or get the INICIO property.
    /// </summary>
    
		public DateTime? INICIO { get; set; }
 
	/// <summary>
    ///  Set or get the FIN property.
    /// </summary>
    
		public DateTime? FIN { get; set; }
	}
}
