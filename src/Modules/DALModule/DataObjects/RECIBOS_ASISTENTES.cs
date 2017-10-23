using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a RECIBOS_ASISTENTES.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class RECIBOS_ASISTENTES 
	{
	
	/// <summary>
    ///  Set or get the RECIBOS_AC property.
    /// </summary>
    
		public string RECIBOS_AC { get; set; }
 
	/// <summary>
    ///  Set or get the EXTENSION_AC property.
    /// </summary>
    
		public string EXTENSION_AC { get; set; }
 
	/// <summary>
    ///  Set or get the ASISTENTE_AC property.
    /// </summary>
    
		public string ASISTENTE_AC { get; set; }
 
	/// <summary>
    ///  Set or get the CONFIRMADO_AC property.
    /// </summary>
    
		public byte? CONFIRMADO_AC { get; set; }
 
	/// <summary>
    ///  Set or get the DESCARTADO_AC property.
    /// </summary>
    
		public byte? DESCARTADO_AC { get; set; }
	}
}
