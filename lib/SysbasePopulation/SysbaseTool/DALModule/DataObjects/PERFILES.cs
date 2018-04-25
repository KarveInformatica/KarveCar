using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a PERFILES.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class PERFILES 
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
    ///  Set or get the DESCRIP property.
    /// </summary>
    
		public string DESCRIP { get; set; }
 
	/// <summary>
    ///  Set or get the ASESOR property.
    /// </summary>
    
		public Int32? ASESOR { get; set; }
	}
}
