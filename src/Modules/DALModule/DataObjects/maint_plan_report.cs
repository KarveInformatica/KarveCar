using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a maint_plan_report.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class maint_plan_report 
	{
	
	/// <summary>
    ///  Set or get the plan_id property.
    /// </summary>
    
		public UInt32 plan_id { get; set; }
 
	/// <summary>
    ///  Set or get the start_time property.
    /// </summary>
    
		public DateTime start_time { get; set; }
 
	/// <summary>
    ///  Set or get the finish_time property.
    /// </summary>
    
		public DateTime? finish_time { get; set; }
 
	/// <summary>
    ///  Set or get the success property.
    /// </summary>
    
		public Boolean success { get; set; }
 
	/// <summary>
    ///  Set or get the report property.
    /// </summary>
    
		public string report { get; set; }
	}
}
