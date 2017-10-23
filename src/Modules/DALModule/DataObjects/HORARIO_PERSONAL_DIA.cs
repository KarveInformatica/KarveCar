using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a HORARIO_PERSONAL_DIA.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class HORARIO_PERSONAL_DIA 
	{
	
	/// <summary>
    ///  Set or get the PERSONA property.
    /// </summary>
    
		public string PERSONA { get; set; }
 
	/// <summary>
    ///  Set or get the DIA property.
    /// </summary>
    
		public DateTime DIA { get; set; }
 
	/// <summary>
    ///  Set or get the DE property.
    /// </summary>
    
		public TimeSpan? DE { get; set; }
 
	/// <summary>
    ///  Set or get the A property.
    /// </summary>
    
		public TimeSpan? A { get; set; }
 
	/// <summary>
    ///  Set or get the LINEA property.
    /// </summary>
    
		public Int32 LINEA { get; set; }
	}
}
