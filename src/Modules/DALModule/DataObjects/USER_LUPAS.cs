using System;
using KarveDapper;
using  KarveDapper.Extensions;
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a USER_LUPAS.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	[Table("USER_LUPAS")]
	public class USER_LUPAS 
	{
	
	/// <summary>
    ///  Set or get the ID property.
    /// </summary>
        [Key]
		public Int32 ID { get; set; }
 
	/// <summary>
    ///  Set or get the USUARIO property.
    /// </summary>
    
		public string USUARIO { get; set; }
 
	/// <summary>
    ///  Set or get the LUPA property.
    /// </summary>
    
		public string LUPA { get; set; }
 
	/// <summary>
    ///  Set or get the NOMBRE property.
    /// </summary>
    
		public string NOMBRE { get; set; }
 
	/// <summary>
    ///  Set or get the DEFECTO property.
    /// </summary>
    
		public byte? DEFECTO { get; set; }
 
	/// <summary>
    ///  Set or get the PUBLICA property.
    /// </summary>
    
		public byte? PUBLICA { get; set; }
 
	/// <summary>
    ///  Set or get the ULTMODI property.
    /// </summary>
    
		public string ULTMODI { get; set; }
	}
}
