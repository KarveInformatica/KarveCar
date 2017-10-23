using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a AENA_LICON.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class AENA_LICON 
	{
	
	/// <summary>
    ///  Set or get the NUMERO property.
    /// </summary>
    
		public string NUMERO { get; set; }
 
	/// <summary>
    ///  Set or get the CONCEPTO property.
    /// </summary>
    
		public Int32 CONCEPTO { get; set; }
 
	/// <summary>
    ///  Set or get the IVA property.
    /// </summary>
    
		public Decimal IVA { get; set; }
 
	/// <summary>
    ///  Set or get the INCLUIDO property.
    /// </summary>
    
		public Int16 INCLUIDO { get; set; }
 
	/// <summary>
    ///  Set or get the SUBTOTAL property.
    /// </summary>
    
		public Decimal SUBTOTAL { get; set; }
	}
}
