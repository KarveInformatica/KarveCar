using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a FICHAJES.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class FICHAJES 
	{
	
	/// <summary>
    ///  Set or get the NUMFICHAJE property.
    /// </summary>
    
		public Int32 NUMFICHAJE { get; set; }
 
	/// <summary>
    ///  Set or get the PERSONAL property.
    /// </summary>
    
		public string PERSONAL { get; set; }
 
	/// <summary>
    ///  Set or get the SUBLICEN property.
    /// </summary>
    
		public string SUBLICEN { get; set; }
 
	/// <summary>
    ///  Set or get the FECHA property.
    /// </summary>
    
		public DateTime? FECHA { get; set; }
 
	/// <summary>
    ///  Set or get the FESTIVO property.
    /// </summary>
    
		public byte? FESTIVO { get; set; }
 
	/// <summary>
    ///  Set or get the ENTRA property.
    /// </summary>
    
		public TimeSpan? ENTRA { get; set; }
 
	/// <summary>
    ///  Set or get the SALE property.
    /// </summary>
    
		public TimeSpan? SALE { get; set; }
 
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
