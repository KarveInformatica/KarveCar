using System;
using Dapper;
using KarveDapper.Extensions;

namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a TIPOPROVE.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
    [Table("TIPOPROVE")]
	public class TIPOPROVE 
	{
	
	/// <summary>
    ///  Set or get the NUM_TIPROVE property.
    /// </summary>
        [Key]
        [FieldSize("2")]
		public Int16 NUM_TIPROVE { get; set; }
 
	/// <summary>
    ///  Set or get the USUARIO property.
    /// </summary>
    
		public string USUARIO { get; set; }
 
	/// <summary>
    ///  Set or get the ULTMODI property.
    /// </summary>
    
		public string ULTMODI { get; set; }
 
	/// <summary>
    ///  Set or get the NOMBRE property.
    /// </summary>
    
		public string NOMBRE { get; set; }
 
	/// <summary>
    ///  Set or get the CTAGASTO property.
    /// </summary>
    
		public string CTAGASTO { get; set; }
	}
}
