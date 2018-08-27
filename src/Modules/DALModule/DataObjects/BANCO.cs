using System;
using KarveDapper.Extensions;
using KarveDataServices.ViewObjects;

namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a BANCO.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	[Table("BANCO")]
	public class BANCO 
	{
	
	/// <summary>
    ///  Set or get the CODBAN property.
    /// </summary>
        [PrimaryKey]
        [Key]
        [FieldSize("4")]
		public string CODBAN { get; set; }
 
	/// <summary>
    ///  Set or get the ULTMODI property.
    /// </summary>
    
		public string ULTMODI { get; set; }
 
	/// <summary>
    ///  Set or get the USUARIO property.
    /// </summary>
    
		public string USUARIO { get; set; }
 
	/// <summary>
    ///  Set or get the NOMBRE property.
    /// </summary>
    
		public string NOMBRE { get; set; }
 
	/// <summary>
    ///  Set or get the GESTIONAR property.
    /// </summary>
    
		public byte? GESTIONAR { get; set; }
 
	/// <summary>
    ///  Set or get the SWIFT property.
    /// </summary>
    
		public string SWIFT { get; set; }
 
	/// <summary>
    ///  Set or get the CTAPAGO_ASOCIA property.
    /// </summary>
    
		public string CTAPAGO_ASOCIA { get; set; }
	}
}
