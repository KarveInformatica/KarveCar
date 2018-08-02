using System;
using KarveDapper.Extensions;
using Dapper;

namespace DataAccessLayer.DataObjects
{
    /// <summary>
    /// Represents a RESERCONFIRM.
    /// NOTE: This class is generated from a T4 template - you should not modify it manually.
    /// </summary>
    [Table("RESERCONFIRM")]
    public class RESERCONFIRM
    { 
	/// <summary>
    ///  Set or get the CODIGO property.
    /// </summary>
        [Key]    
		public string CODIGO { get; set; }
 
	/// <summary>
    ///  Set or get the IDIOMA property.
    /// </summary>
    
		public byte? IDIOMA { get; set; }
 
	/// <summary>
    ///  Set or get the NOMBRE property.
    /// </summary>
    
		public string NOMBRE { get; set; }
 
	/// <summary>
    ///  Set or get the TEXTO property.
    /// </summary>
    
		public string TEXTO { get; set; }
 
	/// <summary>
    ///  Set or get the TITULO property.
    /// </summary>
    
		public string TITULO { get; set; }
 
	/// <summary>
    ///  Set or get the ES_HTML property.
    /// </summary>
    
		public byte? ES_HTML { get; set; }
 
	/// <summary>
    ///  Set or get the ANEXO property.
    /// </summary>
    
		public byte? ANEXO { get; set; }
 
	/// <summary>
    ///  Set or get the ALTA property.
    /// </summary>
    
		public DateTime? ALTA { get; set; }
 
	/// <summary>
    ///  Set or get the BAJA_TXT property.
    /// </summary>
    
		public DateTime? BAJA_TXT { get; set; }
 
	/// <summary>
    ///  Set or get the USUARIO property.
    /// </summary>
    
		public string USUARIO { get; set; }
 
	/// <summary>
    ///  Set or get the ULTMODI property.
    /// </summary>
    
		public string ULTMODI { get; set; }
 
	/// <summary>
    ///  Set or get the LABELASUNTO property.
    /// </summary>
    
		public string LABELASUNTO { get; set; }
	}
}
