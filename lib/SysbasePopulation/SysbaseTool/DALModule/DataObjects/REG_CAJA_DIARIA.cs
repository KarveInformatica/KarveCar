using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a REG_CAJA_DIARIA.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class REG_CAJA_DIARIA 
	{
	
	/// <summary>
    ///  Set or get the CODIGO_RCD property.
    /// </summary>
    
		public string CODIGO_RCD { get; set; }
 
	/// <summary>
    ///  Set or get the FECHA_RCD property.
    /// </summary>
    
		public DateTime? FECHA_RCD { get; set; }
 
	/// <summary>
    ///  Set or get the HORA_RCD property.
    /// </summary>
    
		public TimeSpan? HORA_RCD { get; set; }
 
	/// <summary>
    ///  Set or get the OFICINA_RCD property.
    /// </summary>
    
		public string OFICINA_RCD { get; set; }
 
	/// <summary>
    ///  Set or get the EMPRESA_RCD property.
    /// </summary>
    
		public string EMPRESA_RCD { get; set; }
 
	/// <summary>
    ///  Set or get the USUARIO_RCD property.
    /// </summary>
    
		public string USUARIO_RCD { get; set; }
 
	/// <summary>
    ///  Set or get the CIERRE_BANCO property.
    /// </summary>
    
		public byte? CIERRE_BANCO { get; set; }
	}
}
