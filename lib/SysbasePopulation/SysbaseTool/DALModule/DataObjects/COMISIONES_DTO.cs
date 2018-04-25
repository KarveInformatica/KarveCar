using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a COMISIONES_DTO.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class COMISIONES_DTO 
	{
	
	/// <summary>
    ///  Set or get the ID property.
    /// </summary>
    
		public Int32 ID { get; set; }
 
	/// <summary>
    ///  Set or get the OFICINA_CD property.
    /// </summary>
    
		public string OFICINA_CD { get; set; }
 
	/// <summary>
    ///  Set or get the DTO_CD property.
    /// </summary>
    
		public Decimal DTO_CD { get; set; }
 
	/// <summary>
    ///  Set or get the COMISION_CD property.
    /// </summary>
    
		public Decimal? COMISION_CD { get; set; }
	}
}
