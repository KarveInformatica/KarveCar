using System;
using KarveDapper.Extensions;

namespace DataAccessLayer.DataObjects
{
    /// <summary>
    /// Represents a PICTURES.
    /// NOTE: This class is generated from a T4 template - you should not modify it manually.
    /// </summary>
    [Table("PICTURES")]
    public class PICTURES 
	{
	
	/// <summary>
    ///  Set or get the CODIGO property.
    /// </summary>
       [Key]
		public string CODIGO { get; set; }
 
	/// <summary>
    ///  Set or get the EMPRESA property.
    /// </summary>
    
		public string EMPRESA { get; set; }
 
	/// <summary>
    ///  Set or get the COD_ASOCIADO property.
    /// </summary>
    
		public string COD_ASOCIADO { get; set; }
 
	/// <summary>
    ///  Set or get the FILENAME property.
    /// </summary>
    
		public string FILENAME { get; set; }
 
	/// <summary>
    ///  Set or get the PICTURE property.
    /// </summary>
    
		public byte[] PICTURE { get; set; }
 
	/// <summary>
    ///  Set or get the IDEN property.
    /// </summary>
    
		public string IDEN { get; set; }
	}
}
