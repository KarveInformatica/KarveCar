using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a TIPODOCUMENTO.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class TIPODOCUMENTO 
	{
	
	/// <summary>
    ///  Set or get the CODIGO property.
    /// </summary>
    
		public byte CODIGO { get; set; }
 
	/// <summary>
    ///  Set or get the ULTMODI property.
    /// </summary>
    
		public string ULTMODI { get; set; }
 
	/// <summary>
    ///  Set or get the USUARIO property.
    /// </summary>
    
		public string USUARIO { get; set; }
 
	/// <summary>
    ///  Set or get the REQUIERE_TRATAMIENTO property.
    /// </summary>
    
		public Int32? REQUIERE_TRATAMIENTO { get; set; }
 
	/// <summary>
    ///  Set or get the REQUIERE_VISTOBUENO property.
    /// </summary>
    
		public Int32? REQUIERE_VISTOBUENO { get; set; }
 
	/// <summary>
    ///  Set or get the REQUIERE_SUPERVISION property.
    /// </summary>
    
		public Int32? REQUIERE_SUPERVISION { get; set; }
 
	/// <summary>
    ///  Set or get the NOMBRE property.
    /// </summary>
    
		public string NOMBRE { get; set; }
	}
}
