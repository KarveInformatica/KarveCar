using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a EXCURSIONES_RECOGIDAS.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class EXCURSIONES_RECOGIDAS 
	{
	
	/// <summary>
    ///  Set or get the RECOGIDA property.
    /// </summary>
    
		public Int32 RECOGIDA { get; set; }
 
	/// <summary>
    ///  Set or get the EXCURSION property.
    /// </summary>
    
		public Int32 EXCURSION { get; set; }
 
	/// <summary>
    ///  Set or get the ITEM property.
    /// </summary>
    
		public Int32 ITEM { get; set; }
 
	/// <summary>
    ///  Set or get the HORA property.
    /// </summary>
    
		public TimeSpan? HORA { get; set; }
	}
}
