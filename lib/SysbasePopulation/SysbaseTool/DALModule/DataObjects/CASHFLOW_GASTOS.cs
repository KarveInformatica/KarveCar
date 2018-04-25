using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a CASHFLOW_GASTOS.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class CASHFLOW_GASTOS 
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
    ///  Set or get the FECHA_GASTO property.
    /// </summary>
    
		public DateTime? FECHA_GASTO { get; set; }
 
	/// <summary>
    ///  Set or get the VTO_PAGO property.
    /// </summary>
    
		public DateTime? VTO_PAGO { get; set; }
 
	/// <summary>
    ///  Set or get the PROVEEDOR property.
    /// </summary>
    
		public string PROVEEDOR { get; set; }
 
	/// <summary>
    ///  Set or get the CONCEPTO property.
    /// </summary>
    
		public string CONCEPTO { get; set; }
 
	/// <summary>
    ///  Set or get the IMPORTE property.
    /// </summary>
    
		public Decimal? IMPORTE { get; set; }
 
	/// <summary>
    ///  Set or get the TIPO property.
    /// </summary>
    
		public byte? TIPO { get; set; }
 
	/// <summary>
    ///  Set or get the FECHABAJA property.
    /// </summary>
    
		public DateTime? FECHABAJA { get; set; }
	}
}
