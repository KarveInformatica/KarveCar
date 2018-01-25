using System;
using KarveDapper.Extensions;

namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a POBLACIONES.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	[Table("POBLACIONES")]
	public class POBLACIONES 
	{
	
	/// <summary>
    ///  Set or get the PAIS property.
    /// </summary>
    
		public string PAIS { get; set; }
 
	/// <summary>
    ///  Set or get the CP property.
    /// </summary>
        [Key]
        [FieldSize("7")]
		public string CP { get; set; }
 
	/// <summary>
    ///  Set or get the POBLA property.
    /// </summary>
    
		public string POBLA { get; set; }
 
	/// <summary>
    ///  Set or get the USUARIO property.
    /// </summary>
    
		public string USUARIO { get; set; }
 
	/// <summary>
    ///  Set or get the ULTMODI property.
    /// </summary>
    
		public string ULTMODI { get; set; }
 
	/// <summary>
    ///  Set or get the ZONA_CP property.
    /// </summary>
    
		public string ZONA_CP { get; set; }
 
	/// <summary>
    ///  Set or get the ZONACOMER_CP property.
    /// </summary>
    
		public string ZONACOMER_CP { get; set; }
	}
}
