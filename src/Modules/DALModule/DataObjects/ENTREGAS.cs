using System;
using KarveDapper.Extensions;

namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a ENTREGAS.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
    [Table("ENTREGAS")]
	public class ENTREGAS 
	{
	
	/// <summary>
    ///  Set or get the CODIGO property.
    /// </summary>
        [Key]
		public Int32 CODIGO { get; set; }
 
	/// <summary>
    ///  Set or get the OFICINA property.
    /// </summary>
    
		public string OFICINA { get; set; }
 
	/// <summary>
    ///  Set or get the LUGAR property.
    /// </summary>
    
		public string LUGAR { get; set; }
 
	/// <summary>
    ///  Set or get the PRECIO property.
    /// </summary>
    
		public Decimal? PRECIO { get; set; }
 
	/// <summary>
    ///  Set or get the FALTA property.
    /// </summary>
    
		public DateTime? FALTA { get; set; }
 
	/// <summary>
    ///  Set or get the FBAJA property.
    /// </summary>
    
		public DateTime? FBAJA { get; set; }
 
	/// <summary>
    ///  Set or get the ULTMODI property.
    /// </summary>
    
		public string ULTMODI { get; set; }
 
	/// <summary>
    ///  Set or get the USUARIO property.
    /// </summary>
    
		public string USUARIO { get; set; }
 
	/// <summary>
    ///  Set or get the CALLE property.
    /// </summary>
    
		public string CALLE { get; set; }
 
	/// <summary>
    ///  Set or get the NUM property.
    /// </summary>
    
		public string NUM { get; set; }
 
	/// <summary>
    ///  Set or get the POBLACION property.
    /// </summary>
    
		public string POBLACION { get; set; }
 
	/// <summary>
    ///  Set or get the CP property.
    /// </summary>
    
		public string CP { get; set; }
 
	/// <summary>
    ///  Set or get the CORDGPS property.
    /// </summary>
    
		public string CORDGPS { get; set; }
 
	/// <summary>
    ///  Set or get the COLORFONDO_LE property.
    /// </summary>
    
		public Int32? COLORFONDO_LE { get; set; }
 
	/// <summary>
    ///  Set or get the ALIAS property.
    /// </summary>
    
		public string ALIAS { get; set; }
 
	/// <summary>
    ///  Set or get the PRODUCTO property.
    /// </summary>
    
		public string PRODUCTO { get; set; }
 
	/// <summary>
    ///  Set or get the HORAS property.
    /// </summary>
    
		public Decimal? HORAS { get; set; }
	}
}
