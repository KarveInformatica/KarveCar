using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a DIETISTAS_CLIENTES.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class DIETISTAS_CLIENTES 
	{
	
	/// <summary>
    ///  Set or get the DIETISTA_DICLI property.
    /// </summary>
    
		public string DIETISTA_DICLI { get; set; }
 
	/// <summary>
    ///  Set or get the LINEA_DICLI property.
    /// </summary>
    
		public Int32 LINEA_DICLI { get; set; }
 
	/// <summary>
    ///  Set or get the CLIENTE_DICLI property.
    /// </summary>
    
		public string CLIENTE_DICLI { get; set; }
 
	/// <summary>
    ///  Set or get the POR_DICLI property.
    /// </summary>
    
		public Decimal? POR_DICLI { get; set; }
 
	/// <summary>
    ///  Set or get the ALTA_DICLI property.
    /// </summary>
    
		public DateTime? ALTA_DICLI { get; set; }
 
	/// <summary>
    ///  Set or get the BAJA_DICLI property.
    /// </summary>
    
		public DateTime? BAJA_DICLI { get; set; }
 
	/// <summary>
    ///  Set or get the OBSERVACIONES_DICLI property.
    /// </summary>
    
		public string OBSERVACIONES_DICLI { get; set; }
	}
}
