using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a K_REG_USU.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class K_REG_USU 
	{
	
	/// <summary>
    ///  Set or get the ID_KRU property.
    /// </summary>
    
		public Int32 ID_KRU { get; set; }
 
	/// <summary>
    ///  Set or get the USUARIO property.
    /// </summary>
    
		public string USUARIO { get; set; }
 
	/// <summary>
    ///  Set or get the FECHA property.
    /// </summary>
    
		public DateTime FECHA { get; set; }
 
	/// <summary>
    ///  Set or get the PRG property.
    /// </summary>
    
		public string PRG { get; set; }
 
	/// <summary>
    ///  Set or get the OFICINA property.
    /// </summary>
    
		public string OFICINA { get; set; }
 
	/// <summary>
    ///  Set or get the TS_ID property.
    /// </summary>
    
		public Int32? TS_ID { get; set; }
 
	/// <summary>
    ///  Set or get the PC_NOMBRE property.
    /// </summary>
    
		public string PC_NOMBRE { get; set; }
 
	/// <summary>
    ///  Set or get the PC_USUARIO property.
    /// </summary>
    
		public string PC_USUARIO { get; set; }
 
	/// <summary>
    ///  Set or get the FECHA_VERSION property.
    /// </summary>
    
		public string FECHA_VERSION { get; set; }
 
	/// <summary>
    ///  Set or get the CONNECT_ID property.
    /// </summary>
    
		public Int32? CONNECT_ID { get; set; }
 
	/// <summary>
    ///  Set or get the HORA_FIN property.
    /// </summary>
    
		public DateTime? HORA_FIN { get; set; }
 
	/// <summary>
    ///  Set or get the CONTROL_ACTIVIDAD property.
    /// </summary>
    
		public DateTime? CONTROL_ACTIVIDAD { get; set; }
 
	/// <summary>
    ///  Set or get the CERRADO_POR_INACTIVIDAD property.
    /// </summary>
    
		public DateTime? CERRADO_POR_INACTIVIDAD { get; set; }
	}
}
