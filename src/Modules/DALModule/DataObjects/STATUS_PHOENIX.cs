using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a STATUS_PHOENIX.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class STATUS_PHOENIX 
	{
	
	/// <summary>
    ///  Set or get the ID property.
    /// </summary>
    
		public byte ID { get; set; }
 
	/// <summary>
    ///  Set or get the STATUS_CODE property.
    /// </summary>
    
		public string STATUS_CODE { get; set; }
 
	/// <summary>
    ///  Set or get the SUB_STATUS_CODE property.
    /// </summary>
    
		public string SUB_STATUS_CODE { get; set; }
 
	/// <summary>
    ///  Set or get the STATUS_DESC property.
    /// </summary>
    
		public string STATUS_DESC { get; set; }
	}
}
