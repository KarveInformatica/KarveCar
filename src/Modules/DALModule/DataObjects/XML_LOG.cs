using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a XML_LOG.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class XML_LOG 
	{
	
	/// <summary>
    ///  Set or get the ID property.
    /// </summary>
    
		public Int64 ID { get; set; }
 
	/// <summary>
    ///  Set or get the RESERVA property.
    /// </summary>
    
		public Int64? RESERVA { get; set; }
 
	/// <summary>
    ///  Set or get the FECHA property.
    /// </summary>
    
		public DateTime? FECHA { get; set; }
 
	/// <summary>
    ///  Set or get the ERROR property.
    /// </summary>
    
		public Boolean ERROR { get; set; }
 
	/// <summary>
    ///  Set or get the RESULTADO property.
    /// </summary>
    
		public string RESULTADO { get; set; }
 
	/// <summary>
    ///  Set or get the XML property.
    /// </summary>
    
		public string XML { get; set; }
 
	/// <summary>
    ///  Set or get the TRATADO property.
    /// </summary>
    
		public Boolean? TRATADO { get; set; }
 
	/// <summary>
    ///  Set or get the RESERVA_KV property.
    /// </summary>
    
		public string RESERVA_KV { get; set; }
	}
}
