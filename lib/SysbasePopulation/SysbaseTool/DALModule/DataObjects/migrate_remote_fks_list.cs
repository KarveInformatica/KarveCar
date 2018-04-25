using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a migrate_remote_fks_list.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class migrate_remote_fks_list 
	{
	
	/// <summary>
    ///  Set or get the fk_id property.
    /// </summary>
    
		public Int32 fk_id { get; set; }
 
	/// <summary>
    ///  Set or get the pk_database property.
    /// </summary>
    
		public string pk_database { get; set; }
 
	/// <summary>
    ///  Set or get the pk_owner property.
    /// </summary>
    
		public string pk_owner { get; set; }
 
	/// <summary>
    ///  Set or get the pk_table property.
    /// </summary>
    
		public string pk_table { get; set; }
 
	/// <summary>
    ///  Set or get the pk_column property.
    /// </summary>
    
		public string pk_column { get; set; }
 
	/// <summary>
    ///  Set or get the fk_database property.
    /// </summary>
    
		public string fk_database { get; set; }
 
	/// <summary>
    ///  Set or get the fk_owner property.
    /// </summary>
    
		public string fk_owner { get; set; }
 
	/// <summary>
    ///  Set or get the fk_table property.
    /// </summary>
    
		public string fk_table { get; set; }
 
	/// <summary>
    ///  Set or get the fk_column property.
    /// </summary>
    
		public string fk_column { get; set; }
 
	/// <summary>
    ///  Set or get the key_seq property.
    /// </summary>
    
		public Int32 key_seq { get; set; }
 
	/// <summary>
    ///  Set or get the fk_name property.
    /// </summary>
    
		public string fk_name { get; set; }
 
	/// <summary>
    ///  Set or get the pk_name property.
    /// </summary>
    
		public string pk_name { get; set; }
 
	/// <summary>
    ///  Set or get the created property.
    /// </summary>
    
		public Boolean created { get; set; }
	}
}
