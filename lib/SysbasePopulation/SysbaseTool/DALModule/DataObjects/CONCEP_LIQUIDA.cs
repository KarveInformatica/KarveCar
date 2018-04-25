using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a CONCEP_LIQUIDA.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class CONCEP_LIQUIDA 
	{
	
	/// <summary>
    ///  Set or get the CONCEPTO_CL property.
    /// </summary>
    
		public Int32 CONCEPTO_CL { get; set; }
 
	/// <summary>
    ///  Set or get the EMPRESA_CL property.
    /// </summary>
    
		public string EMPRESA_CL { get; set; }
 
	/// <summary>
    ///  Set or get the LIQSINDTO_CL property.
    /// </summary>
    
		public Decimal? LIQSINDTO_CL { get; set; }
 
	/// <summary>
    ///  Set or get the LIQCONDTO_CL property.
    /// </summary>
    
		public Decimal? LIQCONDTO_CL { get; set; }
	}
}
