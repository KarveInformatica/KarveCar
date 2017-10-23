using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a COORD_GPS.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class COORD_GPS 
	{
	
	/// <summary>
    ///  Set or get the ID property.
    /// </summary>
    
		public Int64 ID { get; set; }
 
	/// <summary>
    ///  Set or get the FECHAHORA property.
    /// </summary>
    
		public DateTime? FECHAHORA { get; set; }
 
	/// <summary>
    ///  Set or get the LATITUD property.
    /// </summary>
    
		public string LATITUD { get; set; }
 
	/// <summary>
    ///  Set or get the LONGITUD property.
    /// </summary>
    
		public string LONGITUD { get; set; }
 
	/// <summary>
    ///  Set or get the VEHICULO property.
    /// </summary>
    
		public string VEHICULO { get; set; }
 
	/// <summary>
    ///  Set or get the CHOFER property.
    /// </summary>
    
		public string CHOFER { get; set; }
 
	/// <summary>
    ///  Set or get the KM_H property.
    /// </summary>
    
		public Decimal? KM_H { get; set; }
	}
}
