using KarveDapper.Extensions;
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a TIPOS_RESERVAS.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
    /// 
    [Table("TIPOS_RESERVAS")]
	public class TIPOS_RESERVAS 
	{
	    /// <summary>
        ///  Set or get the CODIGO property.
        /// </summary>
        [Key]
		public string CODIGO { get; set; }
	    /// <summary>
        ///  Set or get the NOMBRE property.
        /// </summary>
		public string NOMBRE { get; set; }
	}
}
