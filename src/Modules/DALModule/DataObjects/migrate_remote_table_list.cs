using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a migrate_remote_table_list.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class migrate_remote_table_list 
	{
	
	/// <summary>
    ///  Set or get the table_id property.
    /// </summary>
    
		public Int32 table_id { get; set; }
 
	/// <summary>
    ///  Set or get the server_name property.
    /// </summary>
    
		public string server_name { get; set; }
 
	/// <summary>
    ///  Set or get the database_name property.
    /// </summary>
    
		public string database_name { get; set; }
 
	/// <summary>
    ///  Set or get the owner_name property.
    /// </summary>
    
		public string owner_name { get; set; }
 
	/// <summary>
    ///  Set or get the table_name property.
    /// </summary>
    
		public string table_name { get; set; }
 
	/// <summary>
    ///  Set or get the table_type property.
    /// </summary>
    
		public string table_type { get; set; }
 
	/// <summary>
    ///  Set or get the created_proxy property.
    /// </summary>
    
		public Boolean created_proxy { get; set; }
 
	/// <summary>
    ///  Set or get the created_real property.
    /// </summary>
    
		public Boolean created_real { get; set; }
 
	/// <summary>
    ///  Set or get the dropped property.
    /// </summary>
    
		public Boolean dropped { get; set; }
 
	/// <summary>
    ///  Set or get the data_migrated property.
    /// </summary>
    
		public Boolean data_migrated { get; set; }
	}
}
