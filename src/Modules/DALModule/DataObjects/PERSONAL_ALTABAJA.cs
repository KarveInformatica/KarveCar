using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a PERSONAL_ALTABAJA.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class PERSONAL_ALTABAJA 
	{
	
	/// <summary>
    ///  Set or get the PERSONAL_PAB property.
    /// </summary>
    
		public string PERSONAL_PAB { get; set; }
 
	/// <summary>
    ///  Set or get the LINEA property.
    /// </summary>
    
		public Int32 LINEA { get; set; }
 
	/// <summary>
    ///  Set or get the ALTA_PAB property.
    /// </summary>
    
		public DateTime? ALTA_PAB { get; set; }
 
	/// <summary>
    ///  Set or get the BAJA_PAB property.
    /// </summary>
    
		public DateTime? BAJA_PAB { get; set; }
	}
}
