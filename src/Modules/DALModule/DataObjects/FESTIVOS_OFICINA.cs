using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a FESTIVOS_OFICINA.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class FESTIVOS_OFICINA 
	{
	
	/// <summary>
    ///  Set or get the OFICINA property.
    /// </summary>
    
		public string OFICINA { get; set; }
 
	/// <summary>
    ///  Set or get the FESTIVO property.
    /// </summary>
    
		public DateTime FESTIVO { get; set; }
 
	/// <summary>
    ///  Set or get the PARTE_DIA property.
    /// </summary>
    
		public byte? PARTE_DIA { get; set; }
 
	/// <summary>
    ///  Set or get the HORA_DESDE property.
    /// </summary>
    
		public TimeSpan? HORA_DESDE { get; set; }
 
	/// <summary>
    ///  Set or get the HORA_HASTA property.
    /// </summary>
    
		public TimeSpan? HORA_HASTA { get; set; }
	}
}
