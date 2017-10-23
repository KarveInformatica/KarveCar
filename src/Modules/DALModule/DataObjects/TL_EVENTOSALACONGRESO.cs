using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a TL_EVENTOSALACONGRESO.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class TL_EVENTOSALACONGRESO 
	{
	
	/// <summary>
    ///  Set or get the CLAVE property.
    /// </summary>
    
		public Int32 CLAVE { get; set; }
 
	/// <summary>
    ///  Set or get the EVENTO property.
    /// </summary>
    
		public string EVENTO { get; set; }
 
	/// <summary>
    ///  Set or get the SALA property.
    /// </summary>
    
		public Int32? SALA { get; set; }
 
	/// <summary>
    ///  Set or get the ASISTENTE property.
    /// </summary>
    
		public string ASISTENTE { get; set; }
 
	/// <summary>
    ///  Set or get the FECHA property.
    /// </summary>
    
		public DateTime? FECHA { get; set; }
 
	/// <summary>
    ///  Set or get the HORA property.
    /// </summary>
    
		public TimeSpan? HORA { get; set; }
	}
}
