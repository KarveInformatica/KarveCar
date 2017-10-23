using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a COMI_EXCURSIONES.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class COMI_EXCURSIONES 
	{
	
	/// <summary>
    ///  Set or get the COMI property.
    /// </summary>
    
		public string COMI { get; set; }
 
	/// <summary>
    ///  Set or get the EXCURSION property.
    /// </summary>
    
		public Int32 EXCURSION { get; set; }
 
	/// <summary>
    ///  Set or get the ITEM property.
    /// </summary>
    
		public Int32 ITEM { get; set; }
 
	/// <summary>
    ///  Set or get the DESDE property.
    /// </summary>
    
		public DateTime? DESDE { get; set; }
 
	/// <summary>
    ///  Set or get the HASTA property.
    /// </summary>
    
		public DateTime? HASTA { get; set; }
 
	/// <summary>
    ///  Set or get the PREC_ADULTO property.
    /// </summary>
    
		public Decimal? PREC_ADULTO { get; set; }
 
	/// <summary>
    ///  Set or get the PREC_NINO property.
    /// </summary>
    
		public Decimal? PREC_NINO { get; set; }
 
	/// <summary>
    ///  Set or get the CUPO_CEXC property.
    /// </summary>
    
		public Decimal? CUPO_CEXC { get; set; }
 
	/// <summary>
    ///  Set or get the ZONA_CEX property.
    /// </summary>
    
		public string ZONA_CEX { get; set; }
	}
}
