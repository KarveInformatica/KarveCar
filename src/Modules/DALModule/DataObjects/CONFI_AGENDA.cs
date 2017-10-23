using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a CONFI_AGENDA.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class CONFI_AGENDA 
	{
	
	/// <summary>
    ///  Set or get the EMPRESA property.
    /// </summary>
    
		public string EMPRESA { get; set; }
 
	/// <summary>
    ///  Set or get the TIEMPO_RECEPCION property.
    /// </summary>
    
		public TimeSpan? TIEMPO_RECEPCION { get; set; }
 
	/// <summary>
    ///  Set or get the TIEMPO_REPARACION property.
    /// </summary>
    
		public TimeSpan? TIEMPO_REPARACION { get; set; }
 
	/// <summary>
    ///  Set or get the TIEMPO_ENTREGA property.
    /// </summary>
    
		public TimeSpan? TIEMPO_ENTREGA { get; set; }
 
	/// <summary>
    ///  Set or get the TIEMPO_ANTERIOR_REPARACION property.
    /// </summary>
    
		public TimeSpan? TIEMPO_ANTERIOR_REPARACION { get; set; }
 
	/// <summary>
    ///  Set or get the TIEMPO_DESPUES_REPARACION property.
    /// </summary>
    
		public TimeSpan? TIEMPO_DESPUES_REPARACION { get; set; }
 
	/// <summary>
    ///  Set or get the USUARIO property.
    /// </summary>
    
		public string USUARIO { get; set; }
 
	/// <summary>
    ///  Set or get the ULTMODI property.
    /// </summary>
    
		public string ULTMODI { get; set; }
 
	/// <summary>
    ///  Set or get the HORA_INI_TALLER property.
    /// </summary>
    
		public TimeSpan? HORA_INI_TALLER { get; set; }
 
	/// <summary>
    ///  Set or get the HORA_FIN_TALLER property.
    /// </summary>
    
		public TimeSpan? HORA_FIN_TALLER { get; set; }
	}
}
