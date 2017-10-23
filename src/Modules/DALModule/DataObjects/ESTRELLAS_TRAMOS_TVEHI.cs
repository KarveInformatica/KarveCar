using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a ESTRELLAS_TRAMOS_TVEHI.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class ESTRELLAS_TRAMOS_TVEHI 
	{
	
	/// <summary>
    ///  Set or get the REGISTRO property.
    /// </summary>
    
		public Int32 REGISTRO { get; set; }
 
	/// <summary>
    ///  Set or get the LINEA property.
    /// </summary>
    
		public Int32 LINEA { get; set; }
 
	/// <summary>
    ///  Set or get the EMPRESA property.
    /// </summary>
    
		public string EMPRESA { get; set; }
 
	/// <summary>
    ///  Set or get the DESDE property.
    /// </summary>
    
		public Decimal? DESDE { get; set; }
 
	/// <summary>
    ///  Set or get the HASTA property.
    /// </summary>
    
		public Decimal? HASTA { get; set; }
 
	/// <summary>
    ///  Set or get the VALOR_S property.
    /// </summary>
    
		public Int32? VALOR_S { get; set; }
 
	/// <summary>
    ///  Set or get the VALOR_C property.
    /// </summary>
    
		public Int32? VALOR_C { get; set; }
	}
}
