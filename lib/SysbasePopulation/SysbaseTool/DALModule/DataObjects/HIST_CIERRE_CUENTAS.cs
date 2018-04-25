using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a HIST_CIERRE_CUENTAS.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class HIST_CIERRE_CUENTAS 
	{
	
	/// <summary>
    ///  Set or get the CODIGO property.
    /// </summary>
    
		public Int32 CODIGO { get; set; }
 
	/// <summary>
    ///  Set or get the CUENTA property.
    /// </summary>
    
		public string CUENTA { get; set; }
 
	/// <summary>
    ///  Set or get the FECHA property.
    /// </summary>
    
		public DateTime FECHA { get; set; }
 
	/// <summary>
    ///  Set or get the IMPORTE property.
    /// </summary>
    
		public Decimal? IMPORTE { get; set; }
 
	/// <summary>
    ///  Set or get the ULTMODI property.
    /// </summary>
    
		public string ULTMODI { get; set; }
 
	/// <summary>
    ///  Set or get the USUARIO property.
    /// </summary>
    
		public string USUARIO { get; set; }
 
	/// <summary>
    ///  Set or get the EMPRESA property.
    /// </summary>
    
		public string EMPRESA { get; set; }
	}
}
