using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a migrate_sql_defn.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class migrate_sql_defn 
	{
	
	/// <summary>
    ///  Set or get the id property.
    /// </summary>
    
		public Int32 id { get; set; }
 
	/// <summary>
    ///  Set or get the et_table_id property.
    /// </summary>
    
		public Int32? et_table_id { get; set; }
 
	/// <summary>
    ///  Set or get the unld_str property.
    /// </summary>
    
		public string unld_str { get; set; }
	}
}
