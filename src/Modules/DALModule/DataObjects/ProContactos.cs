using System;
using KarveDapper.Extensions;

namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a ProContactos.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	[Table("ProContactos")]
	public class ProContactos 
	{
	
       
	/// <summary>
    ///  Set or get the ccoIdContacto property.
    /// </summary>
        [Key]
		public string ccoIdContacto { get; set; }
 
	/// <summary>
    ///  Set or get the ccoContacto property.
    /// </summary>
    
		public string ccoContacto { get; set; }
 
	/// <summary>
    ///  Set or get the ccoCargo property.
    /// </summary>
    
		public string ccoCargo { get; set; }
 
	/// <summary>
    ///  Set or get the ccoTelefono property.
    /// </summary>
    
		public string ccoTelefono { get; set; }
 
	/// <summary>
    ///  Set or get the ccoMovil property.
    /// </summary>
    
		public string ccoMovil { get; set; }
 
	/// <summary>
    ///  Set or get the ccoMail property.
    /// </summary>
    
		public string ccoMail { get; set; }
 
	/// <summary>
    ///  Set or get the ccoIdCliente property.
    /// </summary>
    
		public string ccoIdCliente { get; set; }
 
	/// <summary>
    ///  Set or get the USUARIO property.
    /// </summary>
    
		public string USUARIO { get; set; }
 
	/// <summary>
    ///  Set or get the ccoAlta property.
    /// </summary>
    
		public DateTime? ccoAlta { get; set; }
 
	/// <summary>
    ///  Set or get the ccoFax property.
    /// </summary>
    
		public string ccoFax { get; set; }
 
	/// <summary>
    ///  Set or get the ccoObserv property.
    /// </summary>
    
		public string ccoObserv { get; set; }
 
	/// <summary>
    ///  Set or get the ccoIdDelega property.
    /// </summary>
    
		public string ccoIdDelega { get; set; }
 
	/// <summary>
    ///  Set or get the ccoDepto property.
    /// </summary>
    
		public string ccoDepto { get; set; }
 
	/// <summary>
    ///  Set or get the ccoMailing property.
    /// </summary>
    
		public byte? ccoMailing { get; set; }
 
	/// <summary>
    ///  Set or get the ULTMODI property.
    /// </summary>
    
		public string ULTMODI { get; set; }
 
	/// <summary>
    ///  Set or get the ccoIdCargo property.
    /// </summary>
    
		public Int32? ccoIdCargo { get; set; }
	}
}
