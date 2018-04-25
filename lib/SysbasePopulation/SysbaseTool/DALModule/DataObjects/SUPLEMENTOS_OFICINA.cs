using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a SUPLEMENTOS_OFICINA.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class SUPLEMENTOS_OFICINA 
	{
	
	/// <summary>
    ///  Set or get the OFICINA property.
    /// </summary>
    
		public string OFICINA { get; set; }
 
	/// <summary>
    ///  Set or get the SUPLEMENTO property.
    /// </summary>
    
		public Int32 SUPLEMENTO { get; set; }
 
	/// <summary>
    ///  Set or get the SUPLEMENTOPOR property.
    /// </summary>
    
		public Int32 SUPLEMENTOPOR { get; set; }
 
	/// <summary>
    ///  Set or get the PORSUPLEMENTO property.
    /// </summary>
    
		public Decimal? PORSUPLEMENTO { get; set; }
 
	/// <summary>
    ///  Set or get the GESTIONAR property.
    /// </summary>
    
		public byte? GESTIONAR { get; set; }
 
	/// <summary>
    ///  Set or get the ULTMODI property.
    /// </summary>
    
		public string ULTMODI { get; set; }
 
	/// <summary>
    ///  Set or get the USUARIO property.
    /// </summary>
    
		public string USUARIO { get; set; }
	}
}
