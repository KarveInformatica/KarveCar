using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a CONFI_EMP_ACUERDO.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class CONFI_EMP_ACUERDO 
	{
	
	/// <summary>
    ///  Set or get the EMPRESA property.
    /// </summary>
    
		public string EMPRESA { get; set; }
 
	/// <summary>
    ///  Set or get the LINEA property.
    /// </summary>
    
		public Int32 LINEA { get; set; }
 
	/// <summary>
    ///  Set or get the GAMA property.
    /// </summary>
    
		public string GAMA { get; set; }
 
	/// <summary>
    ///  Set or get the FALTA property.
    /// </summary>
    
		public DateTime? FALTA { get; set; }
 
	/// <summary>
    ///  Set or get the FBAJA property.
    /// </summary>
    
		public DateTime? FBAJA { get; set; }
 
	/// <summary>
    ///  Set or get the POR_GAMA property.
    /// </summary>
    
		public Decimal? POR_GAMA { get; set; }
	}
}
