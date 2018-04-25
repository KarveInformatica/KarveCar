using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a HISTORIA_VENDECLI.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class HISTORIA_VENDECLI 
	{
	
	/// <summary>
    ///  Set or get the ID property.
    /// </summary>
    
		public Int32 ID { get; set; }
 
	/// <summary>
    ///  Set or get the CLIENTE property.
    /// </summary>
    
		public string CLIENTE { get; set; }
 
	/// <summary>
    ///  Set or get the VENDE_VIEJO property.
    /// </summary>
    
		public string VENDE_VIEJO { get; set; }
 
	/// <summary>
    ///  Set or get the VENDE_NUEVO property.
    /// </summary>
    
		public string VENDE_NUEVO { get; set; }
 
	/// <summary>
    ///  Set or get the ULTMODI property.
    /// </summary>
    
		public string ULTMODI { get; set; }
 
	/// <summary>
    ///  Set or get the USUARIO property.
    /// </summary>
    
		public string USUARIO { get; set; }
 
	/// <summary>
    ///  Set or get the FECHA property.
    /// </summary>
    
		public DateTime? FECHA { get; set; }
 
	/// <summary>
    ///  Set or get the HORA property.
    /// </summary>
    
		public TimeSpan? HORA { get; set; }
	}
}
