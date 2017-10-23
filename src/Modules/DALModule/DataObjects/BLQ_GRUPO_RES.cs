using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a BLQ_GRUPO_RES.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class BLQ_GRUPO_RES 
	{
	
	/// <summary>
    ///  Set or get the USUARIO property.
    /// </summary>
    
		public string USUARIO { get; set; }
 
	/// <summary>
    ///  Set or get the GRUPO property.
    /// </summary>
    
		public string GRUPO { get; set; }
 
	/// <summary>
    ///  Set or get the FALTA property.
    /// </summary>
    
		public DateTime? FALTA { get; set; }
 
	/// <summary>
    ///  Set or get the HALTA property.
    /// </summary>
    
		public TimeSpan? HALTA { get; set; }
 
	/// <summary>
    ///  Set or get the FBAJA property.
    /// </summary>
    
		public DateTime? FBAJA { get; set; }
 
	/// <summary>
    ///  Set or get the HBAJA property.
    /// </summary>
    
		public TimeSpan? HBAJA { get; set; }
 
	/// <summary>
    ///  Set or get the RESERVA property.
    /// </summary>
    
		public string RESERVA { get; set; }
	}
}
