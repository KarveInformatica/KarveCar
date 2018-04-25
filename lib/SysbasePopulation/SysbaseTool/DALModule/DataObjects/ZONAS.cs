using System;
using KarveDapper.Extensions;

namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a ZONAS.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	[Table("ZONAS")]
	public class ZONAS 
	{
	
	/// <summary>
    ///  Set or get the NUM_ZONA property.
    /// </summary>
        [Key]
        [FieldSize("5")]
		public string NUM_ZONA { get; set; }
 
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
    ///  Set or get the BAJAZONA property.
    /// </summary>
    
		public DateTime? BAJAZONA { get; set; }
 
	/// <summary>
    ///  Set or get the ULTIMA_VISITA_ZN property.
    /// </summary>
    
		public DateTime? ULTIMA_VISITA_ZN { get; set; }
	}
}
