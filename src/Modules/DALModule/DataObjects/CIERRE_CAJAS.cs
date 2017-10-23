using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a CIERRE_CAJAS.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class CIERRE_CAJAS 
	{
	
	/// <summary>
    ///  Set or get the CODIGO_CIERRE property.
    /// </summary>
    
		public Int32 CODIGO_CIERRE { get; set; }
 
	/// <summary>
    ///  Set or get the FECHA_CIERRE property.
    /// </summary>
    
		public DateTime FECHA_CIERRE { get; set; }
 
	/// <summary>
    ///  Set or get the IMPORTE_CIERRE property.
    /// </summary>
    
		public Decimal IMPORTE_CIERRE { get; set; }
 
	/// <summary>
    ///  Set or get the EMPRESA_CIERRE property.
    /// </summary>
    
		public string EMPRESA_CIERRE { get; set; }
 
	/// <summary>
    ///  Set or get the OFICINA_CIERRE property.
    /// </summary>
    
		public string OFICINA_CIERRE { get; set; }
 
	/// <summary>
    ///  Set or get the ULTMODI property.
    /// </summary>
    
		public string ULTMODI { get; set; }
 
	/// <summary>
    ///  Set or get the USUARIO property.
    /// </summary>
    
		public string USUARIO { get; set; }
 
	/// <summary>
    ///  Set or get the HORA_CIERRE property.
    /// </summary>
    
		public TimeSpan? HORA_CIERRE { get; set; }
 
	/// <summary>
    ///  Set or get the SALDO_DESEADO property.
    /// </summary>
    
		public Decimal? SALDO_DESEADO { get; set; }
 
	/// <summary>
    ///  Set or get the DESDE_CC property.
    /// </summary>
    
		public DateTime? DESDE_CC { get; set; }
 
	/// <summary>
    ///  Set or get the HDESDE_CC property.
    /// </summary>
    
		public TimeSpan? HDESDE_CC { get; set; }
 
	/// <summary>
    ///  Set or get the HASTA_CC property.
    /// </summary>
    
		public DateTime? HASTA_CC { get; set; }
 
	/// <summary>
    ///  Set or get the HHASTA_CC property.
    /// </summary>
    
		public TimeSpan? HHASTA_CC { get; set; }
	}
}
