using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a TIPO_MODI_REGISTROS.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class TIPO_MODI_REGISTROS 
	{
	
	/// <summary>
    ///  Set or get the CODIGO_TMR property.
    /// </summary>
    
		public byte CODIGO_TMR { get; set; }
 
	/// <summary>
    ///  Set or get the NOMBRE_TMR property.
    /// </summary>
    
		public string NOMBRE_TMR { get; set; }
 
	/// <summary>
    ///  Set or get the RENTACAR_TMR property.
    /// </summary>
    
		public byte? RENTACAR_TMR { get; set; }
 
	/// <summary>
    ///  Set or get the CHOFER_TMR property.
    /// </summary>
    
		public byte? CHOFER_TMR { get; set; }
	}
}
