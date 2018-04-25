using System;
using KarveDapper.Extensions;

namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a ACTIVI.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	[Table("ACTIVI")]
	public class ACTIVI 
	{
	
	/// <summary>
    ///  Set or get the NUM_ACTIVI property.
    /// </summary>
        [Key]
		public string NUM_ACTIVI { get; set; }
 
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
    ///  Set or get the NUEVOCOD property.
    /// </summary>
    
		public string NUEVOCOD { get; set; }
	}
}
