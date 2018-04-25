using System;
using KarveDapper.Extensions;

namespace DataAccessLayer.DataObjects
{
    /// <summary>
    /// Represents a ProDelega.
    /// NOTE: This class is generated from a T4 template - you should not modify it manually.
    /// </summary>
    [Table("ProDelega")]
	public class ProDelega 
	{
	
	/// <summary>
    ///  Set or get the cldIdDelega property.
    /// </summary>
        [Key]
		public string cldIdDelega { get; set; }
 
	/// <summary>
    ///  Set or get the cldDelegacion property.
    /// </summary>
    
		public string cldDelegacion { get; set; }
 
	/// <summary>
    ///  Set or get the cldDireccion1 property.
    /// </summary>
    
		public string cldDireccion1 { get; set; }
 
	/// <summary>
    ///  Set or get the cldDireccion2 property.
    /// </summary>
    
		public string cldDireccion2 { get; set; }
 
	/// <summary>
    ///  Set or get the cldIdCliente property.
    /// </summary>
    
		public string cldIdCliente { get; set; }
 
	/// <summary>
    ///  Set or get the cldCP property.
    /// </summary>
    
		public string cldCP { get; set; }
 
	/// <summary>
    ///  Set or get the cldPoblacion property.
    /// </summary>
    
		public string cldPoblacion { get; set; }
 
	/// <summary>
    ///  Set or get the cldIdProvincia property.
    /// </summary>
    
		public string cldIdProvincia { get; set; }
 
	/// <summary>
    ///  Set or get the cldTelefono1 property.
    /// </summary>
    
		public string cldTelefono1 { get; set; }
 
	/// <summary>
    ///  Set or get the cldTelefono2 property.
    /// </summary>
    
		public string cldTelefono2 { get; set; }
 
	/// <summary>
    ///  Set or get the cldFax property.
    /// </summary>
    
		public string cldFax { get; set; }
 
	/// <summary>
    ///  Set or get the cldEMail property.
    /// </summary>
    
		public string cldEMail { get; set; }
 
	/// <summary>
    ///  Set or get the cldMovil property.
    /// </summary>
    
		public string cldMovil { get; set; }
 
	/// <summary>
    ///  Set or get the cldObservaciones property.
    /// </summary>
    
		public string cldObservaciones { get; set; }
 
	/// <summary>
    ///  Set or get the ULTMODI property.
    /// </summary>
    
		public string ULTMODI { get; set; }
 
	/// <summary>
    ///  Set or get the USUARIO property.
    /// </summary>
    
		public string USUARIO { get; set; }
 
	/// <summary>
    ///  Set or get the SEQ_NUM property.
    /// </summary>
    
		public Int32? SEQ_NUM { get; set; }
 
	/// <summary>
    ///  Set or get the cldPREFE property.
    /// </summary>
    
		public byte? cldPREFE { get; set; }
	}
}
