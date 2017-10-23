using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a SITUACION.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class SITUACION 
	{
	
	/// <summary>
    ///  Set or get the NUMERO property.
    /// </summary>
    
		public byte NUMERO { get; set; }
 
	/// <summary>
    ///  Set or get the NOMBRE property.
    /// </summary>
    
		public string NOMBRE { get; set; }
 
	/// <summary>
    ///  Set or get the ULTMODI property.
    /// </summary>
    
		public string ULTMODI { get; set; }
 
	/// <summary>
    ///  Set or get the USUARIO property.
    /// </summary>
    
		public string USUARIO { get; set; }
 
	/// <summary>
    ///  Set or get the NO_RECALC property.
    /// </summary>
    
		public byte? NO_RECALC { get; set; }
 
	/// <summary>
    ///  Set or get the SITUACION_ANTES_CIERRE property.
    /// </summary>
    
		public byte? SITUACION_ANTES_CIERRE { get; set; }
	}
}
