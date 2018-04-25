using System;
using KarveDapper.Extensions;

namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a TIPOCOMI.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	[Table("TIPOCOMI")]
	public class TIPOCOMI 
	{
	
	/// <summary>
    ///  Set or get the NUM_TICOMI property.
    /// </summary>
        [Key]
		public string NUM_TICOMI { get; set; }
 
	/// <summary>
    ///  Set or get the ULTMODI property.
    /// </summary>
    
		public string ULTMODI { get; set; }
 
	/// <summary>
    ///  Set or get the USUARIO property.
    /// </summary>
    
		public string USUARIO { get; set; }
 
	/// <summary>
    ///  Set or get the NOMBRE property.
    /// </summary>
    
		public string NOMBRE { get; set; }
 
	/// <summary>
    ///  Set or get the OBSERVA_TC property.
    /// </summary>
    
		public string OBSERVA_TC { get; set; }
	}
}
