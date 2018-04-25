using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a DEFINICION_ASIENTOS_EMP.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class DEFINICION_ASIENTOS_EMP 
	{
	
	/// <summary>
    ///  Set or get the EMPRESA property.
    /// </summary>
    
		public string EMPRESA { get; set; }
 
	/// <summary>
    ///  Set or get the ID_TIPOASIENTO property.
    /// </summary>
    
		public Int32 ID_TIPOASIENTO { get; set; }
 
	/// <summary>
    ///  Set or get the LINEA property.
    /// </summary>
    
		public Int32 LINEA { get; set; }
 
	/// <summary>
    ///  Set or get the ACCOUNT property.
    /// </summary>
    
		public string ACCOUNT { get; set; }
 
	/// <summary>
    ///  Set or get the DEBE property.
    /// </summary>
    
		public byte? DEBE { get; set; }
 
	/// <summary>
    ///  Set or get the HABER property.
    /// </summary>
    
		public byte? HABER { get; set; }
 
	/// <summary>
    ///  Set or get the IMPORTE property.
    /// </summary>
    
		public Decimal? IMPORTE { get; set; }
 
	/// <summary>
    ///  Set or get the ACCT_STERN property.
    /// </summary>
    
		public string ACCT_STERN { get; set; }
	}
}
