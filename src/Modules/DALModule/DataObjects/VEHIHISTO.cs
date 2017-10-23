using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a VEHIHISTO.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class VEHIHISTO 
	{
	
	/// <summary>
    ///  Set or get the VEHICULO property.
    /// </summary>
    
		public string VEHICULO { get; set; }
 
	/// <summary>
    ///  Set or get the FECHAENTRA property.
    /// </summary>
    
		public DateTime? FECHAENTRA { get; set; }
 
	/// <summary>
    ///  Set or get the FECHASALE property.
    /// </summary>
    
		public DateTime? FECHASALE { get; set; }
 
	/// <summary>
    ///  Set or get the OFICINA property.
    /// </summary>
    
		public string OFICINA { get; set; }
	}
}
