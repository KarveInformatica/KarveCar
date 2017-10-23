using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a DANOS_CONTRATO.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class DANOS_CONTRATO 
	{
	
	/// <summary>
    ///  Set or get the CONTRATO_DC property.
    /// </summary>
    
		public string CONTRATO_DC { get; set; }
 
	/// <summary>
    ///  Set or get the LINEA_DC property.
    /// </summary>
    
		public byte LINEA_DC { get; set; }
 
	/// <summary>
    ///  Set or get the PIEZA_DC property.
    /// </summary>
    
		public byte PIEZA_DC { get; set; }
 
	/// <summary>
    ///  Set or get the TIPO_DC property.
    /// </summary>
    
		public string TIPO_DC { get; set; }
 
	/// <summary>
    ///  Set or get the PRECIO_DC property.
    /// </summary>
    
		public Decimal? PRECIO_DC { get; set; }
	}
}
