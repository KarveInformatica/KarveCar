using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a CONCEP_TRADUC.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class CONCEP_TRADUC 
	{
	
	/// <summary>
    ///  Set or get the CONCEPTO_CT property.
    /// </summary>
    
		public Int32 CONCEPTO_CT { get; set; }
 
	/// <summary>
    ///  Set or get the EMPRESA_CT property.
    /// </summary>
    
		public string EMPRESA_CT { get; set; }
 
	/// <summary>
    ///  Set or get the CONCEPEMP_CT property.
    /// </summary>
    
		public string CONCEPEMP_CT { get; set; }
 
	/// <summary>
    ///  Set or get the ALLOWED property.
    /// </summary>
    
		public byte? ALLOWED { get; set; }
 
	/// <summary>
    ///  Set or get the PRICE property.
    /// </summary>
    
		public Decimal? PRICE { get; set; }
 
	/// <summary>
    ///  Set or get the MAXIMUM property.
    /// </summary>
    
		public Decimal? MAXIMUM { get; set; }
	}
}
