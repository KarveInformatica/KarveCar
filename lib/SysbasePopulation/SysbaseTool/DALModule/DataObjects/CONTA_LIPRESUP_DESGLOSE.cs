using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a CONTA_LIPRESUP_DESGLOSE.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class CONTA_LIPRESUP_DESGLOSE 
	{
	
	/// <summary>
    ///  Set or get the PRESUPUESTO property.
    /// </summary>
    
		public string PRESUPUESTO { get; set; }
 
	/// <summary>
    ///  Set or get the ORDENTR property.
    /// </summary>
    
		public Int32 ORDENTR { get; set; }
 
	/// <summary>
    ///  Set or get the LINDESGLOSE property.
    /// </summary>
    
		public Int32 LINDESGLOSE { get; set; }
 
	/// <summary>
    ///  Set or get the FACTURA property.
    /// </summary>
    
		public string FACTURA { get; set; }
 
	/// <summary>
    ///  Set or get the IMPPRESU_DESGLOSE property.
    /// </summary>
    
		public Decimal? IMPPRESU_DESGLOSE { get; set; }
 
	/// <summary>
    ///  Set or get the NOTA property.
    /// </summary>
    
		public string NOTA { get; set; }
	}
}
