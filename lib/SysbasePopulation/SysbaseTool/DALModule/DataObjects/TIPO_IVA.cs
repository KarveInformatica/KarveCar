using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a TIPO_IVA.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class TIPO_IVA 
	{
	
	/// <summary>
    ///  Set or get the CODIGO property.
    /// </summary>
    
		public string CODIGO { get; set; }
 
	/// <summary>
    ///  Set or get the TIIVA property.
    /// </summary>
    
		public Decimal TIIVA { get; set; }
 
	/// <summary>
    ///  Set or get the NOMBRE_TI property.
    /// </summary>
    
		public string NOMBRE_TI { get; set; }
 
	/// <summary>
    ///  Set or get the FALTA_TI property.
    /// </summary>
    
		public DateTime? FALTA_TI { get; set; }
 
	/// <summary>
    ///  Set or get the FBAJA_TI property.
    /// </summary>
    
		public DateTime? FBAJA_TI { get; set; }
 
	/// <summary>
    ///  Set or get the GENERAL_TI property.
    /// </summary>
    
		public Int32? GENERAL_TI { get; set; }
 
	/// <summary>
    ///  Set or get the TIPO_IVA_GR property.
    /// </summary>
    
		public string TIPO_IVA_GR { get; set; }
	}
}
