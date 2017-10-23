using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a REG_SQL.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class REG_SQL 
	{
	
	/// <summary>
    ///  Set or get the ID property.
    /// </summary>
    
		public Int64 ID { get; set; }
 
	/// <summary>
    ///  Set or get the SQL property.
    /// </summary>
    
		public string SQL { get; set; }
 
	/// <summary>
    ///  Set or get the OK property.
    /// </summary>
    
		public byte? OK { get; set; }
 
	/// <summary>
    ///  Set or get the HORA property.
    /// </summary>
    
		public DateTime? HORA { get; set; }
	}
}
