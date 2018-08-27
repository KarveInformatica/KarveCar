using System;
using KarveDapper.Extensions;
using KarveDataServices.ViewObjects;

namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a TARCREDI.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	[Table("TARCREDI")]
	public class TARCREDI 
	{
	
	/// <summary>
    ///  Set or get the CODIGO property.
    /// </summary>
        [Key]
        [PrimaryKey]
        [FieldSize("2")]
		public string CODIGO { get; set; }
 
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
    ///  Set or get the MARCA property.
    /// </summary>
    
		public string MARCA { get; set; }
	}
}
