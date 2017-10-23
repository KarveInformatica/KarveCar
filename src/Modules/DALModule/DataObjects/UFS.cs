using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a UFS.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class UFS 
	{
	
	/// <summary>
    ///  Set or get the FECHA property.
    /// </summary>
    
		public DateTime FECHA { get; set; }
 
	/// <summary>
    ///  Set or get the VALOR property.
    /// </summary>
    
		public Decimal? VALOR { get; set; }
 
	/// <summary>
    ///  Set or get the USUARIO property.
    /// </summary>
    
		public string USUARIO { get; set; }
 
	/// <summary>
    ///  Set or get the ULTMODI property.
    /// </summary>
    
		public string ULTMODI { get; set; }
	}
}
