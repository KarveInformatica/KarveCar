using KarveDapper.Extensions;
using System;
using System.Collections.Generic;

namespace DataAccessLayer.DataObjects
{
    /// <summary>
    /// Represents a COLORFL.
    /// NOTE: This class is generated from a T4 template - you should not modify it manually.
    /// </summary>
    [Table("COLORFL")]
    public class COLORFL 
	{
	
	/// <summary>
    ///  Set or get the CODIGO property.
    /// </summary>
       [Key]
       [FieldSize("6")]
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
    ///  Set or get the TIPOCOLOR property.
    /// </summary>
    
		public string TIPOCOLOR { get; set; }
	}
}
