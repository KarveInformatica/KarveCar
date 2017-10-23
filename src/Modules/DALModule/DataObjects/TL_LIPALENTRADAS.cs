using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a TL_LIPALENTRADAS.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class TL_LIPALENTRADAS 
	{
	
	/// <summary>
    ///  Set or get the NUMERO property.
    /// </summary>
    
		public string NUMERO { get; set; }
 
	/// <summary>
    ///  Set or get the CONTADOR property.
    /// </summary>
    
		public byte CONTADOR { get; set; }
 
	/// <summary>
    ///  Set or get the CODIINT property.
    /// </summary>
    
		public string CODIINT { get; set; }
 
	/// <summary>
    ///  Set or get the PRODUCTO property.
    /// </summary>
    
		public string PRODUCTO { get; set; }
 
	/// <summary>
    ///  Set or get the LINEA property.
    /// </summary>
    
		public byte? LINEA { get; set; }
 
	/// <summary>
    ///  Set or get the BASTIDOR property.
    /// </summary>
    
		public string BASTIDOR { get; set; }
 
	/// <summary>
    ///  Set or get the LINPROD property.
    /// </summary>
    
		public Int32? LINPROD { get; set; }
 
	/// <summary>
    ///  Set or get the PORTES_MAQ property.
    /// </summary>
    
		public Decimal? PORTES_MAQ { get; set; }
	}
}
