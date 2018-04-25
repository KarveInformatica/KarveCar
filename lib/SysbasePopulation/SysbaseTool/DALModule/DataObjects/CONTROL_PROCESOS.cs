using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a CONTROL_PROCESOS.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class CONTROL_PROCESOS 
	{
	
	/// <summary>
    ///  Set or get the ID property.
    /// </summary>
    
		public Int64 ID { get; set; }
 
	/// <summary>
    ///  Set or get the PROCESO property.
    /// </summary>
    
		public string PROCESO { get; set; }
 
	/// <summary>
    ///  Set or get the USUARIO property.
    /// </summary>
    
		public string USUARIO { get; set; }
 
	/// <summary>
    ///  Set or get the FECHA property.
    /// </summary>
    
		public DateTime? FECHA { get; set; }
	}
}
