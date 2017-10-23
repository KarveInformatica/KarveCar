using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a MBCP_ANEXO.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class MBCP_ANEXO 
	{
	
	/// <summary>
    ///  Set or get the NUMERO property.
    /// </summary>
    
		public string NUMERO { get; set; }
 
	/// <summary>
    ///  Set or get the FECHA property.
    /// </summary>
    
		public DateTime? FECHA { get; set; }
 
	/// <summary>
    ///  Set or get the CLIENTE property.
    /// </summary>
    
		public string CLIENTE { get; set; }
 
	/// <summary>
    ///  Set or get the TIPO property.
    /// </summary>
    
		public byte? TIPO { get; set; }
 
	/// <summary>
    ///  Set or get the FECHA_CREA property.
    /// </summary>
    
		public DateTime? FECHA_CREA { get; set; }
 
	/// <summary>
    ///  Set or get the ULTMODI_AUTORIZA_PRINT_ANEXO property.
    /// </summary>
    
		public string ULTMODI_AUTORIZA_PRINT_ANEXO { get; set; }
 
	/// <summary>
    ///  Set or get the ULTMODI_SOLICITA_PRINT_ANEXO property.
    /// </summary>
    
		public string ULTMODI_SOLICITA_PRINT_ANEXO { get; set; }
 
	/// <summary>
    ///  Set or get the USU_AUTORIZA_PRINT_ANEXO property.
    /// </summary>
    
		public string USU_AUTORIZA_PRINT_ANEXO { get; set; }
 
	/// <summary>
    ///  Set or get the USU_SOLICITA_PRINT_ANEXO property.
    /// </summary>
    
		public string USU_SOLICITA_PRINT_ANEXO { get; set; }
 
	/// <summary>
    ///  Set or get the INCLUIR_VEHI_IGUAL_FECHA property.
    /// </summary>
    
		public byte? INCLUIR_VEHI_IGUAL_FECHA { get; set; }
	}
}
