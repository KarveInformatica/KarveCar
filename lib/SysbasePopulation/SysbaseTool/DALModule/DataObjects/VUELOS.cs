using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a VUELOS.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class VUELOS 
	{
	
	/// <summary>
    ///  Set or get the CODIGO property.
    /// </summary>
    
		public Int32 CODIGO { get; set; }
 
	/// <summary>
    ///  Set or get the CIA property.
    /// </summary>
    
		public string CIA { get; set; }
 
	/// <summary>
    ///  Set or get the VUELO property.
    /// </summary>
    
		public string VUELO { get; set; }
 
	/// <summary>
    ///  Set or get the ORIGEN property.
    /// </summary>
    
		public string ORIGEN { get; set; }
 
	/// <summary>
    ///  Set or get the HORA property.
    /// </summary>
    
		public TimeSpan? HORA { get; set; }
 
	/// <summary>
    ///  Set or get the OBS property.
    /// </summary>
    
		public string OBS { get; set; }
	}
}
