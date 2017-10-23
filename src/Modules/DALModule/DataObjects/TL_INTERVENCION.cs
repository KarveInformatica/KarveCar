using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a TL_INTERVENCION.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class TL_INTERVENCION 
	{
	
	/// <summary>
    ///  Set or get the CODIGO property.
    /// </summary>
    
		public string CODIGO { get; set; }
 
	/// <summary>
    ///  Set or get the NOMBRE property.
    /// </summary>
    
		public string NOMBRE { get; set; }
 
	/// <summary>
    ///  Set or get the OBSERVACION property.
    /// </summary>
    
		public string OBSERVACION { get; set; }
 
	/// <summary>
    ///  Set or get the ACTIVO property.
    /// </summary>
    
		public byte? ACTIVO { get; set; }
 
	/// <summary>
    ///  Set or get the USUARIO property.
    /// </summary>
    
		public string USUARIO { get; set; }
 
	/// <summary>
    ///  Set or get the ULTMODI property.
    /// </summary>
    
		public string ULTMODI { get; set; }
 
	/// <summary>
    ///  Set or get the MIN_ESTANDAR property.
    /// </summary>
    
		public Decimal? MIN_ESTANDAR { get; set; }
 
	/// <summary>
    ///  Set or get the FBAJA_INT property.
    /// </summary>
    
		public DateTime? FBAJA_INT { get; set; }
	}
}
