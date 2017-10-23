using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a CHOFERES_REMU.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class CHOFERES_REMU 
	{
	
	/// <summary>
    ///  Set or get the CODIGO property.
    /// </summary>
    
		public string CODIGO { get; set; }
 
	/// <summary>
    ///  Set or get the CHOFER property.
    /// </summary>
    
		public string CHOFER { get; set; }
 
	/// <summary>
    ///  Set or get the CONCEPTO property.
    /// </summary>
    
		public Int32? CONCEPTO { get; set; }
 
	/// <summary>
    ///  Set or get the FIJO_CONCEPTO property.
    /// </summary>
    
		public Decimal? FIJO_CONCEPTO { get; set; }
 
	/// <summary>
    ///  Set or get the POR_CONCEPTO property.
    /// </summary>
    
		public Decimal? POR_CONCEPTO { get; set; }
	}
}
