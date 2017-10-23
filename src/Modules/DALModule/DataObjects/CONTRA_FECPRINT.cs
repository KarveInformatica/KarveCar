using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a CONTRA_FECPRINT.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class CONTRA_FECPRINT 
	{
	
	/// <summary>
    ///  Set or get the CONTRATO property.
    /// </summary>
    
		public string CONTRATO { get; set; }
 
	/// <summary>
    ///  Set or get the LINEA property.
    /// </summary>
    
		public Int32 LINEA { get; set; }
 
	/// <summary>
    ///  Set or get the FSALIDA property.
    /// </summary>
    
		public DateTime? FSALIDA { get; set; }
 
	/// <summary>
    ///  Set or get the HSALIDA property.
    /// </summary>
    
		public TimeSpan? HSALIDA { get; set; }
 
	/// <summary>
    ///  Set or get the FRETORNO property.
    /// </summary>
    
		public DateTime? FRETORNO { get; set; }
 
	/// <summary>
    ///  Set or get the HRETORNO property.
    /// </summary>
    
		public TimeSpan? HRETORNO { get; set; }
	}
}
