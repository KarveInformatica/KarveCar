using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a ACCESO.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class ACCESO 
	{
	
	/// <summary>
    ///  Set or get the ID_ACCESO property.
    /// </summary>
    
		public Int64 ID_ACCESO { get; set; }
 
	/// <summary>
    ///  Set or get the ID_USUARIO property.
    /// </summary>
    
		public string ID_USUARIO { get; set; }
 
	/// <summary>
    ///  Set or get the TOKEN property.
    /// </summary>
    
		public string TOKEN { get; set; }
 
	/// <summary>
    ///  Set or get the FECHA property.
    /// </summary>
    
		public DateTime? FECHA { get; set; }
	}
}
