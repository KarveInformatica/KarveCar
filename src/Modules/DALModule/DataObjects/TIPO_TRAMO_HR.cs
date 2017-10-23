using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a TIPO_TRAMO_HR.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class TIPO_TRAMO_HR 
	{
	
	/// <summary>
    ///  Set or get the TIPO_TRAMO property.
    /// </summary>
    
		public string TIPO_TRAMO { get; set; }
 
	/// <summary>
    ///  Set or get the LINEA property.
    /// </summary>
    
		public byte LINEA { get; set; }
 
	/// <summary>
    ///  Set or get the DESDE property.
    /// </summary>
    
		public byte? DESDE { get; set; }
 
	/// <summary>
    ///  Set or get the HASTA property.
    /// </summary>
    
		public byte? HASTA { get; set; }
 
	/// <summary>
    ///  Set or get the PRECIO property.
    /// </summary>
    
		public Decimal? PRECIO { get; set; }
 
	/// <summary>
    ///  Set or get the ULTMODI property.
    /// </summary>
    
		public string ULTMODI { get; set; }
 
	/// <summary>
    ///  Set or get the USUARIO property.
    /// </summary>
    
		public string USUARIO { get; set; }
	}
}
