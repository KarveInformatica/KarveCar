using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a GS1_ERRORES.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class GS1_ERRORES 
	{
	
	/// <summary>
    ///  Set or get the FACTURA property.
    /// </summary>
    
		public string FACTURA { get; set; }
 
	/// <summary>
    ///  Set or get the OPERACION property.
    /// </summary>
    
		public string OPERACION { get; set; }
 
	/// <summary>
    ///  Set or get the ERROR property.
    /// </summary>
    
		public Int32? ERROR { get; set; }
 
	/// <summary>
    ///  Set or get the FECHA_OPERACION property.
    /// </summary>
    
		public DateTime? FECHA_OPERACION { get; set; }
 
	/// <summary>
    ///  Set or get the GS1_MENSAGE property.
    /// </summary>
    
		public string GS1_MENSAGE { get; set; }
 
	/// <summary>
    ///  Set or get the REQUEST property.
    /// </summary>
    
		public string REQUEST { get; set; }
	}
}
