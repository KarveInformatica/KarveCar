using System;
using KarveDapper.Extensions;
using KarveDataServices.DataTransferObject;

namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a MOT_REPOSTAJE.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	[Table("MOT_REPOSTAJE")]
	public class MOT_REPOSTAJE 
	{
	
	/// <summary>
    ///  Set or get the COD_MOT property.
    /// </summary>
        [PrimaryKey]
        [Key]
		public byte COD_MOT { get; set; } 
	/// <summary>
    ///  Set or get the NOM_MOT property.
    /// </summary>
    
		public string NOM_MOT { get; set; }
 
	/// <summary>
    ///  Set or get the USUARIO_MOT property.
    /// </summary>
    
		public string USUARIO_MOT { get; set; }
 
	/// <summary>
    ///  Set or get the ULTMODI_MOT property.
    /// </summary>
    
		public string ULTMODI_MOT { get; set; }
	}
}
