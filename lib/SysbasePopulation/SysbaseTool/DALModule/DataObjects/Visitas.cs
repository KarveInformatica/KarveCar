using System;
using KarveDapper.Extensions;

namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a Visitas.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	[Table("Visitas")]
	public class Visitas 
	{
	
	/// <summary>
    ///  Set or get the visIdVisita property.
    /// </summary>
        [Key]
		public string visIdVisita { get; set; }
 
	/// <summary>
    ///  Set or get the visIdCliente property.
    /// </summary>
    
		public string visIdCliente { get; set; }
 
	/// <summary>
    ///  Set or get the visIdContacto property.
    /// </summary>
    
		public string visIdContacto { get; set; }
 
	/// <summary>
    ///  Set or get the visFecha property.
    /// </summary>
    
		public DateTime? visFecha { get; set; }
 
	/// <summary>
    ///  Set or get the visIdVendedor property.
    /// </summary>
    
		public string visIdVendedor { get; set; }
 
	/// <summary>
    ///  Set or get the USUARIO property.
    /// </summary>
    
		public string USUARIO { get; set; }
 
	/// <summary>
    ///  Set or get the visIdVisitaTipo property.
    /// </summary>
    
		public string visIdVisitaTipo { get; set; }
 
	/// <summary>
    ///  Set or get the visTexto property.
    /// </summary>
    
		public string visTexto { get; set; }
 
	/// <summary>
    ///  Set or get the visAlta property.
    /// </summary>
    
		public DateTime? visAlta { get; set; }
 
	/// <summary>
    ///  Set or get the visPrevisto property.
    /// </summary>
    
		public byte? visPrevisto { get; set; }
 
	/// <summary>
    ///  Set or get the ULTMODI property.
    /// </summary>
    
		public string ULTMODI { get; set; }
 
	/// <summary>
    ///  Set or get the VisitaTipo property.
    /// </summary>
    
		public string VisitaTipo { get; set; }
 
	/// <summary>
    ///  Set or get the visMinutos property.
    /// </summary>
    
		public Int32? visMinutos { get; set; }
 
	/// <summary>
    ///  Set or get the VISITA property.
    /// </summary>
    
		public byte? VISITA { get; set; }
 
	/// <summary>
    ///  Set or get the PEDIDO property.
    /// </summary>
    
		public byte? PEDIDO { get; set; }
 
	/// <summary>
    ///  Set or get the HDESDE property.
    /// </summary>
    
		public string HDESDE { get; set; }
 
	/// <summary>
    ///  Set or get the HHASTA property.
    /// </summary>
    
		public string HHASTA { get; set; }
 
	/// <summary>
    ///  Set or get the visIdObra property.
    /// </summary>
    
		public string visIdObra { get; set; }
 
	/// <summary>
    ///  Set or get the EMAIL property.
    /// </summary>
    
		public string EMAIL { get; set; }
 
	/// <summary>
    ///  Set or get the RESULTADO_VISITA property.
    /// </summary>
    
		public string RESULTADO_VISITA { get; set; }
 
	/// <summary>
    ///  Set or get the visASUNTO property.
    /// </summary>
    
		public string visASUNTO { get; set; }
 
	/// <summary>
    ///  Set or get the QUIEN property.
    /// </summary>
    
		public byte? QUIEN { get; set; }
 
	/// <summary>
    ///  Set or get the CONCLUSION property.
    /// </summary>
    
		public string CONCLUSION { get; set; }
 
	/// <summary>
    ///  Set or get the FICHA property.
    /// </summary>
    
		public string FICHA { get; set; }
 
	/// <summary>
    ///  Set or get the OFERTA property.
    /// </summary>
    
		public string OFERTA { get; set; }
 
	/// <summary>
    ///  Set or get the TIPO_MAQ property.
    /// </summary>
    
		public string TIPO_MAQ { get; set; }
 
	/// <summary>
    ///  Set or get the MARCA_MAQ property.
    /// </summary>
    
		public string MARCA_MAQ { get; set; }
 
	/// <summary>
    ///  Set or get the NUEVA property.
    /// </summary>
    
		public byte? NUEVA { get; set; }
 
	/// <summary>
    ///  Set or get the USADA property.
    /// </summary>
    
		public byte? USADA { get; set; }
 
	/// <summary>
    ///  Set or get the GANADA property.
    /// </summary>
    
		public byte? GANADA { get; set; }
 
	/// <summary>
    ///  Set or get the PERDIDA property.
    /// </summary>
    
		public byte? PERDIDA { get; set; }
 
	/// <summary>
    ///  Set or get the DESESTIMADA property.
    /// </summary>
    
		public byte? DESESTIMADA { get; set; }
 
	/// <summary>
    ///  Set or get the APLAZADA property.
    /// </summary>
    
		public byte? APLAZADA { get; set; }
 
	/// <summary>
    ///  Set or get the CONTACTADO property.
    /// </summary>
    
		public byte? CONTACTADO { get; set; }
 
	/// <summary>
    ///  Set or get the SOLICIT property.
    /// </summary>
    
		public byte? SOLICIT { get; set; }
 
	/// <summary>
    ///  Set or get the PROSPECCION property.
    /// </summary>
    
		public byte? PROSPECCION { get; set; }
 
	/// <summary>
    ///  Set or get the PENDIENTE property.
    /// </summary>
    
		public byte? PENDIENTE { get; set; }
 
	/// <summary>
    ///  Set or get the SEGUIMIENTO property.
    /// </summary>
    
		public byte? SEGUIMIENTO { get; set; }
 
	/// <summary>
    ///  Set or get the visDELEGACION property.
    /// </summary>
    
		public string visDELEGACION { get; set; }
 
	/// <summary>
    ///  Set or get the visMAQUINA property.
    /// </summary>
    
		public string visMAQUINA { get; set; }
 
	/// <summary>
    ///  Set or get the NOMCONTACTO property.
    /// </summary>
    
		public string NOMCONTACTO { get; set; }
 
	/// <summary>
    ///  Set or get the presu_vis property.
    /// </summary>
    
		public string presu_vis { get; set; }
 
	/// <summary>
    ///  Set or get the visOrigen property.
    /// </summary>
    
		public Int32? visOrigen { get; set; }
 
	/// <summary>
    ///  Set or get the visComisio property.
    /// </summary>
    
		public string visComisio { get; set; }
 
	/// <summary>
    ///  Set or get the APROX property.
    /// </summary>
    
		public byte? APROX { get; set; }
 
	/// <summary>
    ///  Set or get the AUTO property.
    /// </summary>
    
		public byte? AUTO { get; set; }
 
	/// <summary>
    ///  Set or get the GESOVIS property.
    /// </summary>
    
		public byte? GESOVIS { get; set; }
	}
}
