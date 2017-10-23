using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a CONTVEHI_ACC.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class CONTVEHI_ACC 
	{
	
	/// <summary>
    ///  Set or get the COD_CVA property.
    /// </summary>
    
		public Int32 COD_CVA { get; set; }
 
	/// <summary>
    ///  Set or get the ACC_CVA property.
    /// </summary>
    
		public Int32 ACC_CVA { get; set; }
 
	/// <summary>
    ///  Set or get the CONTRA_CVA property.
    /// </summary>
    
		public string CONTRA_CVA { get; set; }
 
	/// <summary>
    ///  Set or get the INC_CVA property.
    /// </summary>
    
		public Int32? INC_CVA { get; set; }
	}
}
