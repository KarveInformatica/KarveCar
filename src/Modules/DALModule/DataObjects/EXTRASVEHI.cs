using System;
using KarveDapper.Extensions;

namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a EXTRASVEHI.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	[Table("EXTRASVEHI")]
	public class EXTRASVEHI 
	{
	
	/// <summary>
    ///  Set or get the CODIGO property.
    /// </summary>
        [Key]
        [FieldSize("10")]
		public Int32 CODIGO { get; set; }
 
	/// <summary>
    ///  Set or get the REFERENCIA property.
    /// </summary>
    
		public string REFERENCIA { get; set; }
 
	/// <summary>
    ///  Set or get the OBS property.
    /// </summary>
    
		public string OBS { get; set; }
 
	/// <summary>
    ///  Set or get the USUARIO property.
    /// </summary>
    
		public string USUARIO { get; set; }
 
	/// <summary>
    ///  Set or get the ULTMODI property.
    /// </summary>
    
		public string ULTMODI { get; set; }
 
	/// <summary>
    ///  Set or get the TIPO_VEHI property.
    /// </summary>
    
		public string TIPO_VEHI { get; set; }
 
	/// <summary>
    ///  Set or get the PVP_EXT property.
    /// </summary>
    
		public Decimal? PVP_EXT { get; set; }
 
	/// <summary>
    ///  Set or get the NOMBRE property.
    /// </summary>
    
		public string NOMBRE { get; set; }
	}
}
