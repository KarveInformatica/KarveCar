using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a CONTROL_BLOQUEO_REGISTROS.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class CONTROL_BLOQUEO_REGISTROS 
	{
	
	/// <summary>
    ///  Set or get the ID_CBR property.
    /// </summary>
    
		public Int32 ID_CBR { get; set; }
 
	/// <summary>
    ///  Set or get the TABLA property.
    /// </summary>
    
		public string TABLA { get; set; }
 
	/// <summary>
    ///  Set or get the REGISTRO property.
    /// </summary>
    
		public string REGISTRO { get; set; }
 
	/// <summary>
    ///  Set or get the INICIO property.
    /// </summary>
    
		public DateTime? INICIO { get; set; }
 
	/// <summary>
    ///  Set or get the CONTROL property.
    /// </summary>
    
		public DateTime? CONTROL { get; set; }
 
	/// <summary>
    ///  Set or get the FINAL property.
    /// </summary>
    
		public DateTime? FINAL { get; set; }
 
	/// <summary>
    ///  Set or get the USUARIO property.
    /// </summary>
    
		public string USUARIO { get; set; }
	}
}
