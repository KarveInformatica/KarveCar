using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a CONTRA_SUBROGA.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class CONTRA_SUBROGA 
	{
	
	/// <summary>
    ///  Set or get the CONTRATO_CSR property.
    /// </summary>
    
		public string CONTRATO_CSR { get; set; }
 
	/// <summary>
    ///  Set or get the LINEA_CSR property.
    /// </summary>
    
		public Int32 LINEA_CSR { get; set; }
 
	/// <summary>
    ///  Set or get the FECHA_CSR property.
    /// </summary>
    
		public DateTime? FECHA_CSR { get; set; }
 
	/// <summary>
    ///  Set or get the CLIENTE_CSR property.
    /// </summary>
    
		public string CLIENTE_CSR { get; set; }
 
	/// <summary>
    ///  Set or get the DELEGA_CSR property.
    /// </summary>
    
		public string DELEGA_CSR { get; set; }
	}
}
