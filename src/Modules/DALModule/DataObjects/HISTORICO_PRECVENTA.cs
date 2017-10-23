using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a HISTORICO_PRECVENTA.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class HISTORICO_PRECVENTA 
	{
	
	/// <summary>
    ///  Set or get the VEHICULO property.
    /// </summary>
    
		public string VEHICULO { get; set; }
 
	/// <summary>
    ///  Set or get the LINEA property.
    /// </summary>
    
		public Int32 LINEA { get; set; }
 
	/// <summary>
    ///  Set or get the FECHA property.
    /// </summary>
    
		public DateTime FECHA { get; set; }
 
	/// <summary>
    ///  Set or get the COMENTARIO property.
    /// </summary>
    
		public string COMENTARIO { get; set; }
 
	/// <summary>
    ///  Set or get the PRECIO property.
    /// </summary>
    
		public Decimal? PRECIO { get; set; }
 
	/// <summary>
    ///  Set or get the ENVIAR_MAIL property.
    /// </summary>
    
		public string ENVIAR_MAIL { get; set; }
 
	/// <summary>
    ///  Set or get the ENVIAR_MAIL_COD property.
    /// </summary>
    
		public Int32? ENVIAR_MAIL_COD { get; set; }
	}
}
