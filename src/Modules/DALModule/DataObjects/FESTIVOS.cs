using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a FESTIVOS.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class FESTIVOS 
	{
	
	/// <summary>
    ///  Set or get the PROV_FES property.
    /// </summary>
    
		public string PROV_FES { get; set; }
 
	/// <summary>
    ///  Set or get the FECHA_FES property.
    /// </summary>
    
		public DateTime? FECHA_FES { get; set; }
 
	/// <summary>
    ///  Set or get the HORASCONVENIO_FES property.
    /// </summary>
    
		public Decimal? HORASCONVENIO_FES { get; set; }
 
	/// <summary>
    ///  Set or get the ESPECIAL_FES property.
    /// </summary>
    
		public byte? ESPECIAL_FES { get; set; }
	}
}
