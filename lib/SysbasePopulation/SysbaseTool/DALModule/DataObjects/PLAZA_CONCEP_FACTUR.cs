using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a PLAZA_CONCEP_FACTUR.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class PLAZA_CONCEP_FACTUR 
	{
	
	/// <summary>
    ///  Set or get the PLAZA property.
    /// </summary>
    
		public string PLAZA { get; set; }
 
	/// <summary>
    ///  Set or get the CONCEPTO property.
    /// </summary>
    
		public Int32 CONCEPTO { get; set; }
 
	/// <summary>
    ///  Set or get the PRECIO property.
    /// </summary>
    
		public Decimal? PRECIO { get; set; }
 
	/// <summary>
    ///  Set or get the PRECIO_USD property.
    /// </summary>
    
		public Decimal? PRECIO_USD { get; set; }
 
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
