using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a MBCP_LIANEXO.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class MBCP_LIANEXO 
	{
	
	/// <summary>
    ///  Set or get the NUMERO property.
    /// </summary>
    
		public string NUMERO { get; set; }
 
	/// <summary>
    ///  Set or get the LINEA property.
    /// </summary>
    
		public Int32 LINEA { get; set; }
 
	/// <summary>
    ///  Set or get the VEHICULO property.
    /// </summary>
    
		public string VEHICULO { get; set; }
 
	/// <summary>
    ///  Set or get the PLAZO property.
    /// </summary>
    
		public byte? PLAZO { get; set; }
 
	/// <summary>
    ///  Set or get the IMPORTE property.
    /// </summary>
    
		public Decimal? IMPORTE { get; set; }
 
	/// <summary>
    ///  Set or get the ALQ_MINIMO property.
    /// </summary>
    
		public Decimal? ALQ_MINIMO { get; set; }
 
	/// <summary>
    ///  Set or get the RECOMPRA property.
    /// </summary>
    
		public Decimal? RECOMPRA { get; set; }
 
	/// <summary>
    ///  Set or get the FBAJA_ANEXO property.
    /// </summary>
    
		public DateTime? FBAJA_ANEXO { get; set; }
	}
}
