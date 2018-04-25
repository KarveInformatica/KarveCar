using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a MSN.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class MSN 
	{
	
	/// <summary>
    ///  Set or get the CODIGO property.
    /// </summary>
    
		public Int32 CODIGO { get; set; }
 
	/// <summary>
    ///  Set or get the USU_EMI property.
    /// </summary>
    
		public string USU_EMI { get; set; }
 
	/// <summary>
    ///  Set or get the USU_DES property.
    /// </summary>
    
		public string USU_DES { get; set; }
 
	/// <summary>
    ///  Set or get the FECHA property.
    /// </summary>
    
		public DateTime FECHA { get; set; }
 
	/// <summary>
    ///  Set or get the MSJ property.
    /// </summary>
    
		public string MSJ { get; set; }
 
	/// <summary>
    ///  Set or get the LEIDO property.
    /// </summary>
    
		public byte? LEIDO { get; set; }
 
	/// <summary>
    ///  Set or get the RESP property.
    /// </summary>
    
		public Int32? RESP { get; set; }
	}
}
