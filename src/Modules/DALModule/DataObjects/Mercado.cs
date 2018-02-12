using System;
using KarveDapper.Extensions;

namespace DataAccessLayer.DataObjects
{
    /// <summary>
    /// Represents a MERCADO.
    /// NOTE: This class is generated from a T4 template - you should not modify it manually.
    /// </summary>
    [Table("MERCADO")]
    public class MERCADO 
	{	
	    /// <summary>
        ///  Set or get the USUARIO property.
        /// </summary>
		public string USUARIO { get; set; } 
	    /// <summary>
        ///  Set or get the CODIGO property.
        /// </summary>
        [Key]
        [FieldSize("2")]
        [MagnifierCode]
		public string CODIGO { get; set; }
 
	/// <summary>
    ///  Set or get the ULTMODI property.
    /// </summary>
    
		public string ULTMODI { get; set; }
 
	/// <summary>
    ///  Set or get the NOMBRE property.
    /// </summary>
        [MagnifierValue]
		public string NOMBRE { get; set; }
	}
}
