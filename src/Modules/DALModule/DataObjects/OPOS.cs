using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a OPOS.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class OPOS 
	{
	
	/// <summary>
    ///  Set or get the CODIGO property.
    /// </summary>
    
		public byte CODIGO { get; set; }
 
	/// <summary>
    ///  Set or get the NOMBRE property.
    /// </summary>
    
		public string NOMBRE { get; set; }
 
	/// <summary>
    ///  Set or get the CARRERA property.
    /// </summary>
    
		public byte? CARRERA { get; set; }
 
	/// <summary>
    ///  Set or get the INGLES property.
    /// </summary>
    
		public string INGLES { get; set; }
 
	/// <summary>
    ///  Set or get the CATALAN property.
    /// </summary>
    
		public string CATALAN { get; set; }
	}
}
