using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a COMPRA_BLQ.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class COMPRA_BLQ 
	{
	
	/// <summary>
    ///  Set or get the NUMERO property.
    /// </summary>
    
		public string NUMERO { get; set; }
 
	/// <summary>
    ///  Set or get the FECHA property.
    /// </summary>
    
		public DateTime FECHA { get; set; }
 
	/// <summary>
    ///  Set or get the PERSONA property.
    /// </summary>
    
		public string PERSONA { get; set; }
 
	/// <summary>
    ///  Set or get the FECHA_PAGO property.
    /// </summary>
    
		public DateTime? FECHA_PAGO { get; set; }
 
	/// <summary>
    ///  Set or get the FROMA_PAGO property.
    /// </summary>
    
		public byte? FROMA_PAGO { get; set; }
 
	/// <summary>
    ///  Set or get the CTA_PAGO property.
    /// </summary>
    
		public string CTA_PAGO { get; set; }
 
	/// <summary>
    ///  Set or get the BASE property.
    /// </summary>
    
		public Decimal? BASE { get; set; }
 
	/// <summary>
    ///  Set or get the TOTAL property.
    /// </summary>
    
		public Decimal? TOTAL { get; set; }
	}
}
