using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a CLIENTE_HIST_MANDATO.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class CLIENTE_HIST_MANDATO 
	{
	
	/// <summary>
    ///  Set or get the CLIENTE_HM property.
    /// </summary>
    
		public string CLIENTE_HM { get; set; }
 
	/// <summary>
    ///  Set or get the NMANDATO_HM property.
    /// </summary>
    
		public string NMANDATO_HM { get; set; }
 
	/// <summary>
    ///  Set or get the IBAN_HM property.
    /// </summary>
    
		public string IBAN_HM { get; set; }
 
	/// <summary>
    ///  Set or get the FECHA_ENVIO_HM property.
    /// </summary>
    
		public DateTime? FECHA_ENVIO_HM { get; set; }
 
	/// <summary>
    ///  Set or get the CARTA_AUTORIZA_RECIBIDA_HM property.
    /// </summary>
    
		public DateTime? CARTA_AUTORIZA_RECIBIDA_HM { get; set; }
 
	/// <summary>
    ///  Set or get the DELEGA_HM property.
    /// </summary>
    
		public string DELEGA_HM { get; set; }
	}
}
