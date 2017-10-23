using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a DANOS_VEHICULO.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class DANOS_VEHICULO 
	{
	
	/// <summary>
    ///  Set or get the CLAVE_DV property.
    /// </summary>
    
		public Int32 CLAVE_DV { get; set; }
 
	/// <summary>
    ///  Set or get the VEHI_DV property.
    /// </summary>
    
		public string VEHI_DV { get; set; }
 
	/// <summary>
    ///  Set or get the LINEA_DV property.
    /// </summary>
    
		public byte LINEA_DV { get; set; }
 
	/// <summary>
    ///  Set or get the PIEZA_DV property.
    /// </summary>
    
		public byte PIEZA_DV { get; set; }
 
	/// <summary>
    ///  Set or get the CONTRATO_DV property.
    /// </summary>
    
		public string CONTRATO_DV { get; set; }
 
	/// <summary>
    ///  Set or get the TIPO_DV property.
    /// </summary>
    
		public string TIPO_DV { get; set; }
 
	/// <summary>
    ///  Set or get the PRECIO_DV property.
    /// </summary>
    
		public Decimal? PRECIO_DV { get; set; }
 
	/// <summary>
    ///  Set or get the REPARADO_DV property.
    /// </summary>
    
		public byte? REPARADO_DV { get; set; }
	}
}
