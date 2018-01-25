using System;
using KarveDapper.Extensions;

namespace DataAccessLayer.DataObjects
{
    /// <summary>
    /// Represents a USO_ALQUILER.
    /// NOTE: This class is generated from a T4 template - you should not modify it manually.
    /// </summary>
    [Table("USO_ALQUILER")]
    public class USO_ALQUILER
    {

    /// <summary>
    ///  Set or get the CODIGO property.
    /// </summary>
        [Key]
        [FieldSize("2")]
		public byte CODIGO { get; set; }
 
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
	}
}
