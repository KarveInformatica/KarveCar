using System;
using KarveDapper.Extensions;

namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a VISITAS_COMI.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
    [Table("VISITAS_COMI")]
	public class VISITAS_COMI 
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
    ///  Set or get the PREAVISO property.
    /// </summary>
    
		public Int32? PREAVISO { get; set; }
 
	/// <summary>
    ///  Set or get the visIdObra property.
    /// </summary>
    
		public string visIdObra { get; set; }
 
	/// <summary>
    ///  Set or get the EMAIL property.
    /// </summary>
		public string EMAIL { get; set; }
	/// <summary>
    ///  Set or get the DESCOBRA property.
    /// </summary>
		public string DESCOBRA { get; set; }
	/// <summary>
    ///  Set or get the CONCLUSION property.
    /// </summary>    
		public string CONCLUSION { get; set; }
	}
}
