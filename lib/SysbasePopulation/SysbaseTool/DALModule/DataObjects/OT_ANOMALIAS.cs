using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a OT_ANOMALIAS.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class OT_ANOMALIAS 
	{
	
	/// <summary>
    ///  Set or get the OT_NUMERO_AN property.
    /// </summary>
    
		public string OT_NUMERO_AN { get; set; }
 
	/// <summary>
    ///  Set or get the LINEA_AN property.
    /// </summary>
    
		public Int32 LINEA_AN { get; set; }
 
	/// <summary>
    ///  Set or get the DESCRIPCION_AN property.
    /// </summary>
    
		public string DESCRIPCION_AN { get; set; }
 
	/// <summary>
    ///  Set or get the ANULAR_AN property.
    /// </summary>
    
		public byte? ANULAR_AN { get; set; }
	}
}
