using System;
using KarveDapper.Extensions;

namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a MEDIO_RES.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
    [Table("MEDIO_RES")]
	public class MEDIO_RES
    { 
	/// <summary>
    ///  Set or get the USUARIO property.
    /// </summary>
        public string USUARIO { get; set; }
	/// <summary>
    ///  Set or get the ULTMODI property.
    /// </summary>
		public string ULTMODI { get; set; }
	/// <summary>
    ///  Set or get the NOMBRE property.
    /// </summary>
		public string NOMBRE { get; set; } 
	/// <summary>
    ///  Set or get the CODIGO property.
    /// </summary>
        [Key]
		public string CODIGO { get; set; }
	}
}
