using System;
using KarveDapper.Extensions;

namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a TIPOCLI.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
    [Table("TIPOCLI")]	
	public class TIPOCLI 
	{

        /// <summary>
        ///  Set or get the NUM_TICLI property.
        /// </summary>
        [FieldSize("2")]
        [Key]
		public string NUM_TICLI { get; set; }
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
    ///  Set or get the COLORLUPAS property.
    /// </summary>
    
		public Int32? COLORLUPAS { get; set; }
 
	/// <summary>
    ///  Set or get the PERIOVISITA property.
    /// </summary>
    
		public Int32? PERIOVISITA { get; set; }
 
	/// <summary>
    ///  Set or get the MINANO property.
    /// </summary>
    
		public Int32? MINANO { get; set; }
	}
}
