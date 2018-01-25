using System;
using KarveDapper.Extensions;
using KarveDataServices.DataTransferObject;

namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a PROVINCIA.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	[Table("PROVINCIA")]
	public class PROVINCIA 
	{
	
	/// <summary>
    ///  Set or get the SIGLAS property.
    /// </summary>
        [Key]
        [FieldSize("3")]
		public string SIGLAS { get; set; }
 
	/// <summary>
    ///  Set or get the PROV property.
    /// </summary>
    
		public string PROV { get; set; }
 
	/// <summary>
    ///  Set or get the PREFIJO property.
    /// </summary>
    
		public string PREFIJO { get; set; }
 
	/// <summary>
    ///  Set or get the CP property.
    /// </summary>
    
		public string CP { get; set; }
 
	/// <summary>
    ///  Set or get the PAIS property.
    /// </summary>
    
		public string PAIS { get; set; }
 
	/// <summary>
    ///  Set or get the ULTMODI property.
    /// </summary>
    
		public string ULTMODI { get; set; }
 
	/// <summary>
    ///  Set or get the USUARIO property.
    /// </summary>
    
		public string USUARIO { get; set; }
 
	/// <summary>
    ///  Set or get the CAPITAL property.
    /// </summary>
    
		public string CAPITAL { get; set; }
 
	/// <summary>
    ///  Set or get the ABREVIA property.
    /// </summary>
    
		public string ABREVIA { get; set; }
 
	/// <summary>
    ///  Set or get the CCAA property.
    /// </summary>
    
		public string CCAA { get; set; }
 
	/// <summary>
    ///  Set or get the CONCESIO_PROV property.
    /// </summary>
    
		public string CONCESIO_PROV { get; set; }
 
	/// <summary>
    ///  Set or get the RUTA property.
    /// </summary>
    
		public Int32? RUTA { get; set; }
	}
}
