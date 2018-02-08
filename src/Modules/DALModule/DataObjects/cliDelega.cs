using System;
using KarveDapper.Extensions;

namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a cliDelega.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	[Table("cliDelega")]
	public class cliDelega 
	{
	
	/// <summary>
    ///  Set or get the cldIdDelega property.
    /// </summary>
        [Key]
		public string cldIdDelega { get; set; }
 
	/// <summary>
    ///  Set or get the cldDelegacion property.
    /// </summary>
    
		public string cldDelegacion { get; set; }
 
	/// <summary>
    ///  Set or get the cldDireccion1 property.
    /// </summary>
    
		public string cldDireccion1 { get; set; }
 
	/// <summary>
    ///  Set or get the cldDireccion2 property.
    /// </summary>
    
		public string cldDireccion2 { get; set; }
 
	/// <summary>
    ///  Set or get the cldIdCliente property.
    /// </summary>
    
		public string cldIdCliente { get; set; }
 
	/// <summary>
    ///  Set or get the cldCP property.
    /// </summary>
    
		public string cldCP { get; set; }
 
	/// <summary>
    ///  Set or get the cldPoblacion property.
    /// </summary>
    
		public string cldPoblacion { get; set; }
 
	/// <summary>
    ///  Set or get the cldIdProvincia property.
    /// </summary>
    
		public string cldIdProvincia { get; set; }
 
	/// <summary>
    ///  Set or get the cldTelefono1 property.
    /// </summary>
    
		public string cldTelefono1 { get; set; }
 
	/// <summary>
    ///  Set or get the cldTelefono2 property.
    /// </summary>
    
		public string cldTelefono2 { get; set; }
 
	/// <summary>
    ///  Set or get the cldFax property.
    /// </summary>
    
		public string cldFax { get; set; }
 
	/// <summary>
    ///  Set or get the cldEMail property.
    /// </summary>
    
		public string cldEMail { get; set; }
 
	/// <summary>
    ///  Set or get the cldMovil property.
    /// </summary>
    
		public string cldMovil { get; set; }
 
	/// <summary>
    ///  Set or get the cldObservaciones property.
    /// </summary>
    
		public string cldObservaciones { get; set; }
 
	/// <summary>
    ///  Set or get the ULTMODI property.
    /// </summary>
    
		public string ULTMODI { get; set; }
 
	/// <summary>
    ///  Set or get the USUARIO property.
    /// </summary>
    
		public string USUARIO { get; set; }
 
	/// <summary>
    ///  Set or get the REFERE property.
    /// </summary>
    
		public string REFERE { get; set; }
 
	/// <summary>
    ///  Set or get the COORDGPS property.
    /// </summary>
    
		public string COORDGPS { get; set; }
 
	/// <summary>
    ///  Set or get the DEPARTA property.
    /// </summary>
    
		public string DEPARTA { get; set; }
 
	/// <summary>
    ///  Set or get the DELEGA_CENTRAL property.
    /// </summary>
    
		public byte? DELEGA_CENTRAL { get; set; }
 
	/// <summary>
    ///  Set or get the cldFac property.
    /// </summary>
    
		public byte? cldFac { get; set; }
 
	/// <summary>
    ///  Set or get the CABECERA_FACTURA property.
    /// </summary>
    
		public string CABECERA_FACTURA { get; set; }
 
	/// <summary>
    ///  Set or get the CABECERA_CONTRATO property.
    /// </summary>
    
		public string CABECERA_CONTRATO { get; set; }
 
	/// <summary>
    ///  Set or get the FACTURAR_CLD property.
    /// </summary>
    
		public byte? FACTURAR_CLD { get; set; }
 
	/// <summary>
    ///  Set or get the CCC_CLD property.
    /// </summary>
    
		public string CCC_CLD { get; set; }
 
	/// <summary>
    ///  Set or get the EDI_CODIGO property.
    /// </summary>
    
		public string EDI_CODIGO { get; set; }
 
	/// <summary>
    ///  Set or get the LINEA property.
    /// </summary>
    
		public Int32? LINEA { get; set; }
 
	/// <summary>
    ///  Set or get the IBAN_CLD property.
    /// </summary>
    
		public string IBAN_CLD { get; set; }
 
	/// <summary>
    ///  Set or get the SWIFT_CLD property.
    /// </summary>
    
		public string SWIFT_CLD { get; set; }
 
	/// <summary>
    ///  Set or get the DURAMANDATO_CLD property.
    /// </summary>
    
		public string DURAMANDATO_CLD { get; set; }
 
	/// <summary>
    ///  Set or get the NUMMANDATO_CLD property.
    /// </summary>
    
		public string NUMMANDATO_CLD { get; set; }
 
	/// <summary>
    ///  Set or get the FENVIO_CLD property.
    /// </summary>
    
		public DateTime? FENVIO_CLD { get; set; }
 
	/// <summary>
    ///  Set or get the FRECEP_CLD property.
    /// </summary>
    
		public DateTime? FRECEP_CLD { get; set; }
 
	/// <summary>
    ///  Set or get the cldPREFE property.
    /// </summary>
    
		public byte? cldPREFE { get; set; }
 
	/// <summary>
    ///  Set or get the FACE_OFI_CONTABLE property.
    /// </summary>
    
		public string FACE_OFI_CONTABLE { get; set; }
 
	/// <summary>
    ///  Set or get the FACE_ORGANO_GESTOR property.
    /// </summary>
    
		public string FACE_ORGANO_GESTOR { get; set; }
 
	/// <summary>
    ///  Set or get the FACE_UNI_TRAMITADORA property.
    /// </summary>
    
		public string FACE_UNI_TRAMITADORA { get; set; }
 
	/// <summary>
    ///  Set or get the FACE_DEPARTA property.
    /// </summary>
    
		public string FACE_DEPARTA { get; set; }
 
	/// <summary>
    ///  Set or get the cldIdPais property.
    /// </summary>
    
		public string cldIdPais { get; set; }
 
	/// <summary>
    ///  Set or get the KMS_DIST_CLD property.
    /// </summary>
    
		public Int32? KMS_DIST_CLD { get; set; }
 
	/// <summary>
    ///  Set or get the USUWEB_DEL property.
    /// </summary>
    
		public string USUWEB_DEL { get; set; }
 
	/// <summary>
    ///  Set or get the PWWEB_DEL property.
    /// </summary>
    
		public string PWWEB_DEL { get; set; }
	}
}
