using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a PERSO_AUSENCIAS.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class PERSO_AUSENCIAS 
	{
	
	/// <summary>
    ///  Set or get the NUM_AUSENCIA property.
    /// </summary>
    
		public string NUM_AUSENCIA { get; set; }
 
	/// <summary>
    ///  Set or get the FDESDE property.
    /// </summary>
    
		public DateTime? FDESDE { get; set; }
 
	/// <summary>
    ///  Set or get the HDESDE property.
    /// </summary>
    
		public TimeSpan? HDESDE { get; set; }
 
	/// <summary>
    ///  Set or get the FHASTA property.
    /// </summary>
    
		public DateTime? FHASTA { get; set; }
 
	/// <summary>
    ///  Set or get the HHASTA property.
    /// </summary>
    
		public TimeSpan? HHASTA { get; set; }
 
	/// <summary>
    ///  Set or get the PERSONA property.
    /// </summary>
    
		public string PERSONA { get; set; }
 
	/// <summary>
    ///  Set or get the VACACIONES property.
    /// </summary>
    
		public byte? VACACIONES { get; set; }
 
	/// <summary>
    ///  Set or get the MOTIVO property.
    /// </summary>
    
		public string MOTIVO { get; set; }
 
	/// <summary>
    ///  Set or get the OBS property.
    /// </summary>
    
		public string OBS { get; set; }
 
	/// <summary>
    ///  Set or get the USUARIO property.
    /// </summary>
    
		public string USUARIO { get; set; }
 
	/// <summary>
    ///  Set or get the ULTMODI property.
    /// </summary>
    
		public string ULTMODI { get; set; }
 
	/// <summary>
    ///  Set or get the NDIAS property.
    /// </summary>
    
		public Decimal? NDIAS { get; set; }
 
	/// <summary>
    ///  Set or get the EJERCICIO property.
    /// </summary>
    
		public string EJERCICIO { get; set; }
 
	/// <summary>
    ///  Set or get the NHORAS property.
    /// </summary>
    
		public Decimal? NHORAS { get; set; }
 
	/// <summary>
    ///  Set or get the SOLICITUD property.
    /// </summary>
    
		public byte? SOLICITUD { get; set; }
 
	/// <summary>
    ///  Set or get the JUSTIFICANTE property.
    /// </summary>
    
		public byte? JUSTIFICANTE { get; set; }
 
	/// <summary>
    ///  Set or get the DEVENGABLES property.
    /// </summary>
    
		public byte? DEVENGABLES { get; set; }
 
	/// <summary>
    ///  Set or get the LABORABLES property.
    /// </summary>
    
		public byte? LABORABLES { get; set; }
 
	/// <summary>
    ///  Set or get the CONTRAPERS property.
    /// </summary>
    
		public string CONTRAPERS { get; set; }
 
	/// <summary>
    ///  Set or get the SECUENCIA property.
    /// </summary>
    
		public Int32? SECUENCIA { get; set; }
 
	/// <summary>
    ///  Set or get the NATURALES property.
    /// </summary>
    
		public byte? NATURALES { get; set; }
	}
}
