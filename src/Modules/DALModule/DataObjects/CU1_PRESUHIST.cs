using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a CU1_PRESUHIST.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class CU1_PRESUHIST 
	{
	
	/// <summary>
    ///  Set or get the CTA property.
    /// </summary>
    
		public string CTA { get; set; }
 
	/// <summary>
    ///  Set or get the ANO property.
    /// </summary>
    
		public string ANO { get; set; }
 
	/// <summary>
    ///  Set or get the EMPRESA property.
    /// </summary>
    
		public string EMPRESA { get; set; }
 
	/// <summary>
    ///  Set or get the IMPORTE_PRES property.
    /// </summary>
    
		public Decimal? IMPORTE_PRES { get; set; }
 
	/// <summary>
    ///  Set or get the USUARIO property.
    /// </summary>
    
		public string USUARIO { get; set; }
 
	/// <summary>
    ///  Set or get the FECHAPASE property.
    /// </summary>
    
		public DateTime? FECHAPASE { get; set; }
	}
}
