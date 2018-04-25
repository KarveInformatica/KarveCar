using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a MSJMOVIL.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class MSJMOVIL 
	{
	
	/// <summary>
    ///  Set or get the CODIGO property.
    /// </summary>
    
		public Int32 CODIGO { get; set; }
 
	/// <summary>
    ///  Set or get the FECHA property.
    /// </summary>
    
		public DateTime FECHA { get; set; }
 
	/// <summary>
    ///  Set or get the MOVIL property.
    /// </summary>
    
		public string MOVIL { get; set; }
 
	/// <summary>
    ///  Set or get the MSJ property.
    /// </summary>
    
		public string MSJ { get; set; }
 
	/// <summary>
    ///  Set or get the USUARIO property.
    /// </summary>
    
		public string USUARIO { get; set; }
 
	/// <summary>
    ///  Set or get the AQUIEN property.
    /// </summary>
    
		public string AQUIEN { get; set; }
 
	/// <summary>
    ///  Set or get the ORIGEN property.
    /// </summary>
    
		public byte? ORIGEN { get; set; }
 
	/// <summary>
    ///  Set or get the RESP property.
    /// </summary>
    
		public byte? RESP { get; set; }
	}
}
