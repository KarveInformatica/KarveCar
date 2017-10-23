using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a XML_SII.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class XML_SII 
	{
	
	/// <summary>
    ///  Set or get the ID property.
    /// </summary>
    
		public Int64 ID { get; set; }
 
	/// <summary>
    ///  Set or get the FECHA property.
    /// </summary>
    
		public DateTime FECHA { get; set; }
 
	/// <summary>
    ///  Set or get the ODBC property.
    /// </summary>
    
		public string ODBC { get; set; }
 
	/// <summary>
    ///  Set or get the EMPRESA property.
    /// </summary>
    
		public string EMPRESA { get; set; }
 
	/// <summary>
    ///  Set or get the TIPO property.
    /// </summary>
    
		public string TIPO { get; set; }
 
	/// <summary>
    ///  Set or get the ERROR property.
    /// </summary>
    
		public Boolean? ERROR { get; set; }
 
	/// <summary>
    ///  Set or get the FECHA_RESP property.
    /// </summary>
    
		public DateTime? FECHA_RESP { get; set; }
 
	/// <summary>
    ///  Set or get the XML property.
    /// </summary>
    
		public string XML { get; set; }
 
	/// <summary>
    ///  Set or get the XML_RESP property.
    /// </summary>
    
		public string XML_RESP { get; set; }
 
	/// <summary>
    ///  Set or get the MENSA_RESP property.
    /// </summary>
    
		public string MENSA_RESP { get; set; }
	}
}
