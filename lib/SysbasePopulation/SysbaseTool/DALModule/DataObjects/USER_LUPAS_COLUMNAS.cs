using System;
using KarveDapper.Extensions;
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a USER_LUPAS_COLUMNAS.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	[Table("USER_LUPAS_COLUMNAS")]
	public class USER_LUPAS_COLUMNAS
	{
        [Key]
	    public Int32 ID_COL { get; set; }
	
	/// <summary>
    ///  Set or get the ID_LUPA property.
    /// </summary>
    
		public Int32 ID_LUPA { get; set; }
 
	/// <summary>
    ///  Set or get the COLUMNA_NOMBRE property.
    /// </summary>
    
		public string COLUMNA_NOMBRE { get; set; }
 
	/// <summary>
    ///  Set or get the VISIBLE property.
    /// </summary>
    
		public byte? VISIBLE { get; set; }
 
	/// <summary>
    ///  Set or get the POSICION property.
    /// </summary>
    
		public Int32? POSICION { get; set; }
 
	/// <summary>
    ///  Set or get the ANCHO property.
    /// </summary>
    
		public Int32? ANCHO { get; set; }
	}
}
