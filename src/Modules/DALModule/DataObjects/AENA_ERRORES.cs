using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a AENA_ERRORES.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class AENA_ERRORES 
	{
	
	/// <summary>
    ///  Set or get the CONTRATO property.
    /// </summary>
    
		public string CONTRATO { get; set; }
 
	/// <summary>
    ///  Set or get the OPERACION property.
    /// </summary>
    
		public Int32? OPERACION { get; set; }
 
	/// <summary>
    ///  Set or get the ERROR property.
    /// </summary>
    
		public Int32? ERROR { get; set; }
 
	/// <summary>
    ///  Set or get the FECHA_OPERACION property.
    /// </summary>
    
		public DateTime? FECHA_OPERACION { get; set; }
 
	/// <summary>
    ///  Set or get the VIENE_DE_WS property.
    /// </summary>
    
		public byte? VIENE_DE_WS { get; set; }
 
	/// <summary>
    ///  Set or get the REQUEST property.
    /// </summary>
    
		public string REQUEST { get; set; }
 
	/// <summary>
    ///  Set or get the TRANSACCION property.
    /// </summary>
    
		public string TRANSACCION { get; set; }
	}
}
