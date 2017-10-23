using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a OBJETIVOS_OFICINA.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class OBJETIVOS_OFICINA 
	{
	
	/// <summary>
    ///  Set or get the ANO property.
    /// </summary>
    
		public Int32 ANO { get; set; }
 
	/// <summary>
    ///  Set or get the MES property.
    /// </summary>
    
		public byte MES { get; set; }
 
	/// <summary>
    ///  Set or get the OFICINA property.
    /// </summary>
    
		public string OFICINA { get; set; }
 
	/// <summary>
    ///  Set or get the IMPORTE property.
    /// </summary>
    
		public Decimal? IMPORTE { get; set; }
 
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
