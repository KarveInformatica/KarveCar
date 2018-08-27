 
using System;
using KarveDapper.Extensions;
using KarveDataServices.ViewObjects;

namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a ORIGEN.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	[Table("ORIGEN")]
	public class ORIGEN 
	{

	    /// <summary>
	    ///  Set or get the NUM_ORIGEN property.
	    /// </summary>
	    [Key]
	    [PrimaryKey]
        public Int32 NUM_ORIGEN { get; set; }

	    /// <summary>
    ///  Set or get the NOMBRE property.
    /// </summary>
    
		public string NOMBRE { get; set; }
 
	/// <summary>
    ///  Set or get the CLAFEE property.
    /// </summary>
    
		public string CLAFEE { get; set; }
 
	/// <summary>
    ///  Set or get the GRUPO property.
    /// </summary>
    
		public string GRUPO { get; set; }
 
	/// <summary>
    ///  Set or get the ULTMODI property.
    /// </summary>
    
		public string ULTMODI { get; set; }
 
	/// <summary>
    ///  Set or get the USUARIO property.
    /// </summary>
    
		public string USUARIO { get; set; }
 
	/// <summary>
    ///  Set or get the TELF_TC property.
    /// </summary>
    
		public string TELF_TC { get; set; }
 
	/// <summary>
    ///  Set or get the MAIL_TC property.
    /// </summary>
    
		public string MAIL_TC { get; set; }
 
	/// <summary>
    ///  Set or get the LOGO_TC property.
    /// </summary>
    
		public Int32? LOGO_TC { get; set; }
 
	/// <summary>
    ///  Set or get the DIR_TC property.
    /// </summary>
    
		public string DIR_TC { get; set; }
 
	/// <summary>
    ///  Set or get the DIR2_TC property.
    /// </summary>
    
		public string DIR2_TC { get; set; }
 
	/// <summary>
    ///  Set or get the PAIS_TC property.
    /// </summary>
    
		public string PAIS_TC { get; set; }
 
	/// <summary>
    ///  Set or get the CP_TC property.
    /// </summary>
    
		public string CP_TC { get; set; }
 
	/// <summary>
    ///  Set or get the POBLA_TC property.
    /// </summary>
    
		public string POBLA_TC { get; set; }
 
	/// <summary>
    ///  Set or get the PROV_TC property.
    /// </summary>
    
		public string PROV_TC { get; set; }
 
	/// <summary>
    ///  Set or get the FAX_TC property.
    /// </summary>
    
		public string FAX_TC { get; set; }
 
	/// <summary>
    ///  Set or get the WEB_TC property.
    /// </summary>
    
		public string WEB_TC { get; set; }
 
	/// <summary>
    ///  Set or get the USUARIO_MAIL_ORI property.
    /// </summary>
    
		public string USUARIO_MAIL_ORI { get; set; }
 
	/// <summary>
    ///  Set or get the PW_MAIL_ORI property.
    /// </summary>
    
		public string PW_MAIL_ORI { get; set; }
 
	/// <summary>
    ///  Set or get the SMTP_MAIL_ORI property.
    /// </summary>
    
		public string SMTP_MAIL_ORI { get; set; }
 
	/// <summary>
    ///  Set or get the PUERTO_SMTP_MAIL_ORI property.
    /// </summary>
    
		public string PUERTO_SMTP_MAIL_ORI { get; set; }
 
	/// <summary>
    ///  Set or get the FIRMAOUTLOOK_ORI property.
    /// </summary>
    
		public string FIRMAOUTLOOK_ORI { get; set; }
 
	/// <summary>
    ///  Set or get the MAIL_SSL_ORI property.
    /// </summary>
    
		public byte? MAIL_SSL_ORI { get; set; }
 
	/// <summary>
    ///  Set or get the NOMBRE_TC property.
    /// </summary>
    
		public string NOMBRE_TC { get; set; }
 
	/// <summary>
    ///  Set or get the POR_BENEF property.
    /// </summary>
    
		public Decimal? POR_BENEF { get; set; }
 
	/// <summary>
    ///  Set or get the COMISIO_ORI property.
    /// </summary>
    
		public string COMISIO_ORI { get; set; }
 
	/// <summary>
    ///  Set or get the USU_TC property.
    /// </summary>
    
		public string USU_TC { get; set; }
	}
}
