using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a MANTENIMIENTO_VEHICULO.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class MANTENIMIENTO_VEHICULO 
	{
	
	/// <summary>
    ///  Set or get the CODIGO_MV property.
    /// </summary>
    
		public string CODIGO_MV { get; set; }
 
	/// <summary>
    ///  Set or get the CODIGO_VEHI_MV property.
    /// </summary>
    
		public string CODIGO_VEHI_MV { get; set; }
 
	/// <summary>
    ///  Set or get the CODIGO_MANT_MV property.
    /// </summary>
    
		public string CODIGO_MANT_MV { get; set; }
 
	/// <summary>
    ///  Set or get the ULT_KM_MV property.
    /// </summary>
    
		public Int32? ULT_KM_MV { get; set; }
 
	/// <summary>
    ///  Set or get the ULT_FEC_MV property.
    /// </summary>
    
		public DateTime? ULT_FEC_MV { get; set; }
 
	/// <summary>
    ///  Set or get the PROX_KM_MV property.
    /// </summary>
    
		public Int32? PROX_KM_MV { get; set; }
 
	/// <summary>
    ///  Set or get the PROX_FEC_MV property.
    /// </summary>
    
		public DateTime? PROX_FEC_MV { get; set; }
 
	/// <summary>
    ///  Set or get the FBAJA_MV property.
    /// </summary>
    
		public DateTime? FBAJA_MV { get; set; }
 
	/// <summary>
    ///  Set or get the INCREMENTO property.
    /// </summary>
    
		public Int32? INCREMENTO { get; set; }
 
	/// <summary>
    ///  Set or get the OBSERVACIONES property.
    /// </summary>
    
		public string OBSERVACIONES { get; set; }
	}
}
