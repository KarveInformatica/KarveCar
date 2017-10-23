using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a KSYSINDEX.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class KSYSINDEX 
	{
	
	/// <summary>
    ///  Set or get the table_id property.
    /// </summary>
    
		public UInt32 table_id { get; set; }
 
	/// <summary>
    ///  Set or get the index_id property.
    /// </summary>
    
		public UInt32 index_id { get; set; }
 
	/// <summary>
    ///  Set or get the root property.
    /// </summary>
    
		public Int32 root { get; set; }
 
	/// <summary>
    ///  Set or get the file_id property.
    /// </summary>
    
		public Int16 file_id { get; set; }
 
	/// <summary>
    ///  Set or get the unique property.
    /// </summary>
    
		public string unique { get; set; }
 
	/// <summary>
    ///  Set or get the creator property.
    /// </summary>
    
		public UInt32 creator { get; set; }
 
	/// <summary>
    ///  Set or get the index_name property.
    /// </summary>
    
		public string index_name { get; set; }
 
	/// <summary>
    ///  Set or get the remarks property.
    /// </summary>
    
		public string remarks { get; set; }
 
	/// <summary>
    ///  Set or get the index_type property.
    /// </summary>
    
		public string index_type { get; set; }
 
	/// <summary>
    ///  Set or get the index_owner property.
    /// </summary>
    
		public string index_owner { get; set; }
 
	/// <summary>
    ///  Set or get the hash_limit property.
    /// </summary>
    
		public Int16 hash_limit { get; set; }
	}
}
