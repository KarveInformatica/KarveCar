using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a VALES.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class VALES 
	{
	
	/// <summary>
    ///  Set or get the NUM_VALE property.
    /// </summary>
    
		public string NUM_VALE { get; set; }
 
	/// <summary>
    ///  Set or get the FECHA_VALE property.
    /// </summary>
    
		public DateTime FECHA_VALE { get; set; }
 
	/// <summary>
    ///  Set or get the PROVEE_VALE property.
    /// </summary>
    
		public string PROVEE_VALE { get; set; }
 
	/// <summary>
    ///  Set or get the CONCEPTO_VALE property.
    /// </summary>
    
		public string CONCEPTO_VALE { get; set; }
 
	/// <summary>
    ///  Set or get the IMPORTE_VALE property.
    /// </summary>
    
		public Decimal? IMPORTE_VALE { get; set; }
 
	/// <summary>
    ///  Set or get the USUARIO property.
    /// </summary>
    
		public string USUARIO { get; set; }
 
	/// <summary>
    ///  Set or get the ULTMODI property.
    /// </summary>
    
		public string ULTMODI { get; set; }
	}
}
