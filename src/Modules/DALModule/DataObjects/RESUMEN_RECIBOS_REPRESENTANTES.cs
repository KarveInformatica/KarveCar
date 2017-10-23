using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a RESUMEN_RECIBOS_REPRESENTANTES.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class RESUMEN_RECIBOS_REPRESENTANTES 
	{
	
	/// <summary>
    ///  Set or get the ANNO property.
    /// </summary>
    
		public Int32 ANNO { get; set; }
 
	/// <summary>
    ///  Set or get the MES property.
    /// </summary>
    
		public Int32 MES { get; set; }
 
	/// <summary>
    ///  Set or get the VENDEDOR property.
    /// </summary>
    
		public string VENDEDOR { get; set; }
 
	/// <summary>
    ///  Set or get the HSL property.
    /// </summary>
    
		public Decimal? HSL { get; set; }
 
	/// <summary>
    ///  Set or get the FB property.
    /// </summary>
    
		public Decimal? FB { get; set; }
 
	/// <summary>
    ///  Set or get the FACTURACION property.
    /// </summary>
    
		public Decimal? FACTURACION { get; set; }
 
	/// <summary>
    ///  Set or get the POR_ANO property.
    /// </summary>
    
		public Decimal? POR_ANO { get; set; }
 
	/// <summary>
    ///  Set or get the POR_TOTAL property.
    /// </summary>
    
		public Decimal? POR_TOTAL { get; set; }
	}
}
