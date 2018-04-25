using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a GASCLI.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class GASCLI 
	{
	
	/// <summary>
    ///  Set or get the NUMERO property.
    /// </summary>
    
		public Int32 NUMERO { get; set; }
 
	/// <summary>
    ///  Set or get the FECHA property.
    /// </summary>
    
		public DateTime? FECHA { get; set; }
 
	/// <summary>
    ///  Set or get the CLIENTE property.
    /// </summary>
    
		public string CLIENTE { get; set; }
 
	/// <summary>
    ///  Set or get the CONCEPTO property.
    /// </summary>
    
		public Int32? CONCEPTO { get; set; }
 
	/// <summary>
    ///  Set or get the IMPORTE property.
    /// </summary>
    
		public Decimal? IMPORTE { get; set; }
 
	/// <summary>
    ///  Set or get the COMENTARIO property.
    /// </summary>
    
		public string COMENTARIO { get; set; }
 
	/// <summary>
    ///  Set or get the USUARIO property.
    /// </summary>
    
		public string USUARIO { get; set; }
 
	/// <summary>
    ///  Set or get the ULTMODI property.
    /// </summary>
    
		public string ULTMODI { get; set; }
	}
}
