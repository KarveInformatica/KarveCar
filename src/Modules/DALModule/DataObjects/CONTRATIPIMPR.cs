using KarveDapper.Extensions;
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a CONTRATIPIMPR.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
    [Table("CONTRATIPIMPR")]
	public class CONTRATIPIMPR 
	{
	
	/// <summary>
    ///  Set or get the CODIGO property.
    /// </summary>
        [Key]    
		public byte CODIGO { get; set; }
 
	/// <summary>
    ///  Set or get the NOMBRE property.
    /// </summary>
    
		public string NOMBRE { get; set; }
 
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
