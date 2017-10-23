using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a SEGUIMIENTO.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class SEGUIMIENTO 
	{
	
	/// <summary>
    ///  Set or get the ID_SEG property.
    /// </summary>
    
		public Int32 ID_SEG { get; set; }
 
	/// <summary>
    ///  Set or get the ALBARAN_SEG property.
    /// </summary>
    
		public string ALBARAN_SEG { get; set; }
 
	/// <summary>
    ///  Set or get the TRANSPORTE_SEG property.
    /// </summary>
    
		public string TRANSPORTE_SEG { get; set; }
 
	/// <summary>
    ///  Set or get the VISITACLI_SEG property.
    /// </summary>
    
		public string VISITACLI_SEG { get; set; }
 
	/// <summary>
    ///  Set or get the VISITAPOT_SEG property.
    /// </summary>
    
		public string VISITAPOT_SEG { get; set; }
 
	/// <summary>
    ///  Set or get the VISITAPROV_SEG property.
    /// </summary>
    
		public string VISITAPROV_SEG { get; set; }
 
	/// <summary>
    ///  Set or get the ESTADO_SEG property.
    /// </summary>
    
		public byte? ESTADO_SEG { get; set; }
 
	/// <summary>
    ///  Set or get the VENDEDOR_SEG property.
    /// </summary>
    
		public string VENDEDOR_SEG { get; set; }
 
	/// <summary>
    ///  Set or get the OPERARIO_SEG property.
    /// </summary>
    
		public string OPERARIO_SEG { get; set; }
 
	/// <summary>
    ///  Set or get the FECHA_SEG property.
    /// </summary>
    
		public DateTime? FECHA_SEG { get; set; }
 
	/// <summary>
    ///  Set or get the HORA_SEG property.
    /// </summary>
    
		public TimeSpan? HORA_SEG { get; set; }
	}
}
