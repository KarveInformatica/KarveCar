using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a SMS.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class SMS 
	{
	
	/// <summary>
    ///  Set or get the CODIGO property.
    /// </summary>
    
		public Int32 CODIGO { get; set; }
 
	/// <summary>
    ///  Set or get the ID_SMS property.
    /// </summary>
    
		public string ID_SMS { get; set; }
 
	/// <summary>
    ///  Set or get the FECHA property.
    /// </summary>
    
		public DateTime FECHA { get; set; }
 
	/// <summary>
    ///  Set or get the MOVIL property.
    /// </summary>
    
		public string MOVIL { get; set; }
 
	/// <summary>
    ///  Set or get the MSJ property.
    /// </summary>
    
		public string MSJ { get; set; }
 
	/// <summary>
    ///  Set or get the USUARIO property.
    /// </summary>
    
		public string USUARIO { get; set; }
 
	/// <summary>
    ///  Set or get the AQUIEN property.
    /// </summary>
    
		public string AQUIEN { get; set; }
 
	/// <summary>
    ///  Set or get the ORIGEN property.
    /// </summary>
    
		public byte? ORIGEN { get; set; }
 
	/// <summary>
    ///  Set or get the ENVIO property.
    /// </summary>
    
		public byte? ENVIO { get; set; }
 
	/// <summary>
    ///  Set or get the NOLEIDO property.
    /// </summary>
    
		public byte? NOLEIDO { get; set; }
 
	/// <summary>
    ///  Set or get the USU_TRATA property.
    /// </summary>
    
		public string USU_TRATA { get; set; }
 
	/// <summary>
    ///  Set or get the IAQUIEN property.
    /// </summary>
    
		public Int32? IAQUIEN { get; set; }
 
	/// <summary>
    ///  Set or get the COD_AQUIEN property.
    /// </summary>
    
		public string COD_AQUIEN { get; set; }
 
	/// <summary>
    ///  Set or get the IDOCUMENTO property.
    /// </summary>
    
		public Int32? IDOCUMENTO { get; set; }
 
	/// <summary>
    ///  Set or get the DOCUMENTO property.
    /// </summary>
    
		public string DOCUMENTO { get; set; }
	}
}
