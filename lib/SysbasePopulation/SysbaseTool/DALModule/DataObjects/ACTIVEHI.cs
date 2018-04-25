using System;
using KarveDapper.Extensions;

namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a ACTIVEHI.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	[Table("ACTIVEHI")]
	public class ACTIVEHI 
	{
	
	/// <summary>
    ///  Set or get the NUM_ACTIVEHI property.
    /// </summary>
        [Key]
        [FieldSize("4")]
		public string NUM_ACTIVEHI { get; set; }
 
	/// <summary>
    ///  Set or get the NOMBRE property.
    /// </summary>
    
		public string NOMBRE { get; set; }
 
	/// <summary>
    ///  Set or get the ULTMODI property.
    /// </summary>
    
		public string ULTMODI { get; set; }
 
	/// <summary>
    ///  Set or get the USUARIO property.
    /// </summary>
    
		public string USUARIO { get; set; }
 
	/// <summary>
    ///  Set or get the CALCULO property.
    /// </summary>
    
		public string CALCULO { get; set; }
 
	/// <summary>
    ///  Set or get the SEGURO_ANUAL property.
    /// </summary>
    
		public Decimal? SEGURO_ANUAL { get; set; }
 
	/// <summary>
    ///  Set or get the ACTIVI_ALQ property.
    /// </summary>
    
		public byte? ACTIVI_ALQ { get; set; }
 
	/// <summary>
    ///  Set or get the SIGLAS_ACT property.
    /// </summary>
    
		public string SIGLAS_ACT { get; set; }
	}
}
