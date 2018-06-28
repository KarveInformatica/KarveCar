using System;
using KarveDapper.Extensions;
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a CCAA.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
    [Table("CCAA")]
	public class CCAA 
	{
	
	/// <summary>
    ///  Set or get the CODIGO_CCAA property.
    /// </summary>
        [Key]
        [FieldSize("2")]
		public string CODIGO_CCAA { get; set; }
 
	/// <summary>
    ///  Set or get the NOMBRE_CCAA property.
    /// </summary>
    
		public string NOMBRE_CCAA { get; set; }
	}
}
