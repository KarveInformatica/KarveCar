using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a SERVICIOS_CORRESPONDENCIA.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class SERVICIOS_CORRESPONDENCIA 
	{
	
	/// <summary>
    ///  Set or get the SERVICIO property.
    /// </summary>
    
		public Int32 SERVICIO { get; set; }
 
	/// <summary>
    ///  Set or get the LINEA property.
    /// </summary>
    
		public Int32 LINEA { get; set; }
 
	/// <summary>
    ///  Set or get the FIELD_BD property.
    /// </summary>
    
		public string FIELD_BD { get; set; }
 
	/// <summary>
    ///  Set or get the FIELD_CHEK_BD property.
    /// </summary>
    
		public string FIELD_CHEK_BD { get; set; }
 
	/// <summary>
    ///  Set or get the OPERADOR property.
    /// </summary>
    
		public Int32? OPERADOR { get; set; }
 
	/// <summary>
    ///  Set or get the OPERADOR_S property.
    /// </summary>
    
		public string OPERADOR_S { get; set; }
	}
}
