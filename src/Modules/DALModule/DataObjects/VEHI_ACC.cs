using System;
using KarveDapper.Extensions;
using KarveDataServices.DataTransferObject;

namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a VEHI_ACC.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	[Table("VEHI_ACC")]
	public class VEHI_ACC 
	{
	
	/// <summary>
    ///  Set or get the COD_ACC property.
    /// </summary>
        [PrimaryKey]
        [Key]
        [FieldSize("4")]
		public Int32 COD_ACC { get; set; }
	    /// <summary>
        ///  Set or get the NOM_ACC property.
        /// </summary>
		public string NOM_ACC { get; set; }
	}
}
