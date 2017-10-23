using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a LIN_LECTURAS.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class LIN_LECTURAS 
	{
	
	/// <summary>
    ///  Set or get the NUMERO_LIN property.
    /// </summary>
    
		public string NUMERO_LIN { get; set; }
 
	/// <summary>
    ///  Set or get the LINEA property.
    /// </summary>
    
		public Int32 LINEA { get; set; }
 
	/// <summary>
    ///  Set or get the MAQUINA property.
    /// </summary>
    
		public string MAQUINA { get; set; }
 
	/// <summary>
    ///  Set or get the KMS property.
    /// </summary>
    
		public Decimal? KMS { get; set; }
 
	/// <summary>
    ///  Set or get the ALBARAN property.
    /// </summary>
    
		public string ALBARAN { get; set; }
 
	/// <summary>
    ///  Set or get the ULT_LEC property.
    /// </summary>
    
		public Decimal? ULT_LEC { get; set; }
 
	/// <summary>
    ///  Set or get the KMS_INI property.
    /// </summary>
    
		public Decimal? KMS_INI { get; set; }
 
	/// <summary>
    ///  Set or get the DIFERENCIA property.
    /// </summary>
    
		public Decimal? DIFERENCIA { get; set; }
 
	/// <summary>
    ///  Set or get the FACTURA property.
    /// </summary>
    
		public string FACTURA { get; set; }
 
	/// <summary>
    ///  Set or get the NO_FACTURAR property.
    /// </summary>
    
		public byte? NO_FACTURAR { get; set; }
 
	/// <summary>
    ///  Set or get the DEVOLUCION property.
    /// </summary>
    
		public string DEVOLUCION { get; set; }
 
	/// <summary>
    ///  Set or get the DIFKM property.
    /// </summary>
    
		public Int32? DIFKM { get; set; }
	}
}
