using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a PORCEN_CUPO_OFI.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class PORCEN_CUPO_OFI 
	{
	
	/// <summary>
    ///  Set or get the OFICINA_CO property.
    /// </summary>
    
		public string OFICINA_CO { get; set; }
 
	/// <summary>
    ///  Set or get the ANO_CO property.
    /// </summary>
    
		public Int32 ANO_CO { get; set; }
 
	/// <summary>
    ///  Set or get the SEMANA_CO property.
    /// </summary>
    
		public byte SEMANA_CO { get; set; }
 
	/// <summary>
    ///  Set or get the DESDE_CO property.
    /// </summary>
    
		public DateTime? DESDE_CO { get; set; }
 
	/// <summary>
    ///  Set or get the HASTA_CO property.
    /// </summary>
    
		public DateTime? HASTA_CO { get; set; }
 
	/// <summary>
    ///  Set or get the PORCEN_CO property.
    /// </summary>
    
		public Decimal? PORCEN_CO { get; set; }
	}
}
