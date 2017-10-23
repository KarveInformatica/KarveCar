using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a TP_CONFE.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class TP_CONFE 
	{
	
	/// <summary>
    ///  Set or get the CODIGO_CO property.
    /// </summary>
    
		public Int32 CODIGO_CO { get; set; }
 
	/// <summary>
    ///  Set or get the EVENTO_CO property.
    /// </summary>
    
		public string EVENTO_CO { get; set; }
 
	/// <summary>
    ///  Set or get the NOMBRE_CO property.
    /// </summary>
    
		public string NOMBRE_CO { get; set; }
 
	/// <summary>
    ///  Set or get the SALA_CO property.
    /// </summary>
    
		public Int32? SALA_CO { get; set; }
 
	/// <summary>
    ///  Set or get the FECHA_CO property.
    /// </summary>
    
		public DateTime? FECHA_CO { get; set; }
 
	/// <summary>
    ///  Set or get the HORAINI_CO property.
    /// </summary>
    
		public TimeSpan? HORAINI_CO { get; set; }
 
	/// <summary>
    ///  Set or get the HORAFIN_CO property.
    /// </summary>
    
		public TimeSpan? HORAFIN_CO { get; set; }
	}
}
