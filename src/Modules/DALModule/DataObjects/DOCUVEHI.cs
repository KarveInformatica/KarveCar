using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a DOCUVEHI.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class DOCUVEHI 
	{
	
	/// <summary>
    ///  Set or get the ID_DOCUMENTO property.
    /// </summary>
    
		public Int32 ID_DOCUMENTO { get; set; }
 
	/// <summary>
    ///  Set or get the NUMERO property.
    /// </summary>
    
		public string NUMERO { get; set; }
 
	/// <summary>
    ///  Set or get the NOMBRE property.
    /// </summary>
    
		public string NOMBRE { get; set; }
 
	/// <summary>
    ///  Set or get the TIPO property.
    /// </summary>
    
		public Int32? TIPO { get; set; }
 
	/// <summary>
    ///  Set or get the FECHA property.
    /// </summary>
    
		public DateTime? FECHA { get; set; }
 
	/// <summary>
    ///  Set or get the OBSERVACIONES property.
    /// </summary>
    
		public string OBSERVACIONES { get; set; }
 
	/// <summary>
    ///  Set or get the RUTA property.
    /// </summary>
    
		public string RUTA { get; set; }
 
	/// <summary>
    ///  Set or get the USUARIO property.
    /// </summary>
    
		public string USUARIO { get; set; }
 
	/// <summary>
    ///  Set or get the ULTMODI property.
    /// </summary>
    
		public string ULTMODI { get; set; }
 
	/// <summary>
    ///  Set or get the CATEGO property.
    /// </summary>
    
		public Int32? CATEGO { get; set; }
 
	/// <summary>
    ///  Set or get the CARPETA_DOC property.
    /// </summary>
    
		public byte? CARPETA_DOC { get; set; }
	}
}
