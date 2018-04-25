using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a MODI_COTIZA.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class MODI_COTIZA 
	{
	
	/// <summary>
    ///  Set or get the CLAVE property.
    /// </summary>
    
		public Int32 CLAVE { get; set; }
 
	/// <summary>
    ///  Set or get the USUARIO property.
    /// </summary>
    
		public string USUARIO { get; set; }
 
	/// <summary>
    ///  Set or get the FECHA property.
    /// </summary>
    
		public DateTime? FECHA { get; set; }
 
	/// <summary>
    ///  Set or get the HORA property.
    /// </summary>
    
		public TimeSpan? HORA { get; set; }
 
	/// <summary>
    ///  Set or get the CONTRATO property.
    /// </summary>
    
		public string CONTRATO { get; set; }
 
	/// <summary>
    ///  Set or get the OBS property.
    /// </summary>
    
		public string OBS { get; set; }
 
	/// <summary>
    ///  Set or get the PRECIO property.
    /// </summary>
    
		public Decimal? PRECIO { get; set; }
 
	/// <summary>
    ///  Set or get the PRECIOTARI property.
    /// </summary>
    
		public Decimal? PRECIOTARI { get; set; }
	}
}
