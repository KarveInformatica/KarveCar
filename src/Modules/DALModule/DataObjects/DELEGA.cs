using KarveDapper.Extensions;
using System;
 
namespace DataAccessLayer.DataObjects
{
    /// <summary>
    /// Represents a DELEGA.
    /// NOTE: This class is generated from a T4 template - you should not modify it manually.
    /// </summary>
    [Table("DELEGA")]
    public class DELEGA 
	{
	
	/// <summary>
    ///  Set or get the NUM_DELEGA property.
    /// </summary>
        [Key]   
		public string NUM_DELEGA { get; set; }
 
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
    ///  Set or get the Gastos_Grl property.
    /// </summary>
    
		public Double? Gastos_Grl { get; set; }
 
	/// <summary>
    ///  Set or get the MAIL_DIRECTOR property.
    /// </summary>
    
		public string MAIL_DIRECTOR { get; set; }
 
	/// <summary>
    ///  Set or get the GASTODPT property.
    /// </summary>
    
		public string GASTODPT { get; set; }
 
	/// <summary>
    ///  Set or get the USU_DIRECTOR property.
    /// </summary>
    
		public string USU_DIRECTOR { get; set; }
 
	/// <summary>
    ///  Set or get the TXTFACTURA property.
    /// </summary>
    
		public string TXTFACTURA { get; set; }
 
	/// <summary>
    ///  Set or get the IMPFACTURA property.
    /// </summary>
    
		public Decimal? IMPFACTURA { get; set; }
 
	/// <summary>
    ///  Set or get the CLIENTE_DEP property.
    /// </summary>
    
		public string CLIENTE_DEP { get; set; }
 
	/// <summary>
    ///  Set or get the DPT_JD property.
    /// </summary>
    
		public string DPT_JD { get; set; }
 
	/// <summary>
    ///  Set or get the EMPRESA_DPT property.
    /// </summary>
    
		public string EMPRESA_DPT { get; set; }
	}
}
