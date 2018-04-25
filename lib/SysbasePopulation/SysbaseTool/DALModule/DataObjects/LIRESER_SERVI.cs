using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a LIRESER_SERVI.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class LIRESER_SERVI 
	{
	
	/// <summary>
    ///  Set or get the RESERVA property.
    /// </summary>
    
		public string RESERVA { get; set; }
 
	/// <summary>
    ///  Set or get the LINEA property.
    /// </summary>
    
		public Int32 LINEA { get; set; }
 
	/// <summary>
    ///  Set or get the DESDE property.
    /// </summary>
    
		public DateTime DESDE { get; set; }
 
	/// <summary>
    ///  Set or get the HASTA property.
    /// </summary>
    
		public DateTime HASTA { get; set; }
 
	/// <summary>
    ///  Set or get the PENSION property.
    /// </summary>
    
		public byte? PENSION { get; set; }
 
	/// <summary>
    ///  Set or get the DESAYUNO property.
    /// </summary>
    
		public byte? DESAYUNO { get; set; }
 
	/// <summary>
    ///  Set or get the COMIDA property.
    /// </summary>
    
		public byte? COMIDA { get; set; }
 
	/// <summary>
    ///  Set or get the CENA property.
    /// </summary>
    
		public byte? CENA { get; set; }
	}
}
