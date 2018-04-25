using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a TAREAS_DESTINATARIOS.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class TAREAS_DESTINATARIOS 
	{
	
	/// <summary>
    ///  Set or get the TAREA property.
    /// </summary>
    
		public Int32 TAREA { get; set; }
 
	/// <summary>
    ///  Set or get the USUARIO property.
    /// </summary>
    
		public string USUARIO { get; set; }
 
	/// <summary>
    ///  Set or get the FECHA property.
    /// </summary>
    
		public DateTime? FECHA { get; set; }
 
	/// <summary>
    ///  Set or get the HORA property.
    /// </summary>
    
		public TimeSpan? HORA { get; set; }
 
	/// <summary>
    ///  Set or get the TEXTO property.
    /// </summary>
    
		public string TEXTO { get; set; }
 
	/// <summary>
    ///  Set or get the ESTADO property.
    /// </summary>
    
		public byte? ESTADO { get; set; }
 
	/// <summary>
    ///  Set or get the FFIN_DEST property.
    /// </summary>
    
		public DateTime? FFIN_DEST { get; set; }
 
	/// <summary>
    ///  Set or get the HFIN_DEST property.
    /// </summary>
    
		public TimeSpan? HFIN_DEST { get; set; }
	}
}
