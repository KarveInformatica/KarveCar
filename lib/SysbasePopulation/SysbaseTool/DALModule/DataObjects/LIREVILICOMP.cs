using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a LIREVILICOMP.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class LIREVILICOMP 
	{
	
	/// <summary>
    ///  Set or get the LICOMP_LR property.
    /// </summary>
    
		public Int32 LICOMP_LR { get; set; }
 
	/// <summary>
    ///  Set or get the LINEA property.
    /// </summary>
    
		public Int32 LINEA { get; set; }
 
	/// <summary>
    ///  Set or get the VEHICULO_LR property.
    /// </summary>
    
		public string VEHICULO_LR { get; set; }
 
	/// <summary>
    ///  Set or get the FECHA_LR property.
    /// </summary>
    
		public DateTime? FECHA_LR { get; set; }
 
	/// <summary>
    ///  Set or get the KMS_LR property.
    /// </summary>
    
		public Int32? KMS_LR { get; set; }
	}
}
