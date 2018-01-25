using System;
using KarveDapper.Extensions;

namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a TARJETA_EMP.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	[Table("TARJETA_EMP")]
	public class TARJETA_EMP 
	{
	
	/// <summary>
    ///  Set or get the COD_TARJETA property.
    /// </summary>
        [Key]
        [FieldSize("2")]
		public string COD_TARJETA { get; set; }
 
	/// <summary>
    ///  Set or get the NOMBRE property.
    /// </summary>
    
		public string NOMBRE { get; set; }
 
	/// <summary>
    ///  Set or get the PRECIO property.
    /// </summary>
    
		public Decimal? PRECIO { get; set; }
 
	/// <summary>
    ///  Set or get the CONDICIONES property.
    /// </summary>
    
		public string CONDICIONES { get; set; }
 
	/// <summary>
    ///  Set or get the PREFIJO property.
    /// </summary>
    
		public string PREFIJO { get; set; }
	}
}
