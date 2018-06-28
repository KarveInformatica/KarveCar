using System;
using KarveDapper.Extensions;

namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a FORMAS.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	[Table("FORMAS")]
	public class FORMAS 
	{
	
	/// <summary>
    ///  Set or get the CODIGO property.
    /// </summary>
        [Key]
        [FieldSize("3")]
		public byte CODIGO { get; set; }
 
	/// <summary>
    ///  Set or get the NOMBRE property.
    /// </summary>
    
		public string NOMBRE { get; set; }
 
	/// <summary>
    ///  Set or get the ULTMODI property.
    /// </summary>
    
		public string ULTMODI { get; set; }
 
	/// <summary>
    ///  Set or get the USUARIO property.
    /// </summary>
    
		public string USUARIO { get; set; }
 
	/// <summary>
    ///  Set or get the CUENTA property.
    /// </summary>
    
		public string CUENTA { get; set; }
 
	/// <summary>
    ///  Set or get the MOSTRADOR property.
    /// </summary>
    
		public string MOSTRADOR { get; set; }
 
	/// <summary>
    ///  Set or get the CTACLIENTE property.
    /// </summary>
    
		public string CTACLIENTE { get; set; }
 
	/// <summary>
    ///  Set or get the PEDIR property.
    /// </summary>
    
		public string PEDIR { get; set; }
 
	/// <summary>
    ///  Set or get the AF_CAJA property.
    /// </summary>
    
		public string AF_CAJA { get; set; }
 
	/// <summary>
    ///  Set or get the CUCOMIS property.
    /// </summary>
    
		public string CUCOMIS { get; set; }
 
	/// <summary>
    ///  Set or get the PORCOMIS property.
    /// </summary>
    
		public Decimal? PORCOMIS { get; set; }
 
	/// <summary>
    ///  Set or get the OFICINA property.
    /// </summary>
    
		public string OFICINA { get; set; }
 
	/// <summary>
    ///  Set or get the TELECHEQUE property.
    /// </summary>
    
		public byte? TELECHEQUE { get; set; }
 
	/// <summary>
    ///  Set or get the ESTARJETA property.
    /// </summary>
    
		public byte? ESTARJETA { get; set; }
 
	/// <summary>
    ///  Set or get the NO_REMESABLE property.
    /// </summary>
    
		public byte? NO_REMESABLE { get; set; }
 
	/// <summary>
    ///  Set or get the PLAZO1 property.
    /// </summary>
    
		public Int16? PLAZO1 { get; set; }
 
	/// <summary>
    ///  Set or get the PLAZO2 property.
    /// </summary>
    
		public Int16? PLAZO2 { get; set; }
 
	/// <summary>
    ///  Set or get the PLAZO3 property.
    /// </summary>
    
		public Int16? PLAZO3 { get; set; }
 
	/// <summary>
    ///  Set or get the PLAZO4 property.
    /// </summary>
    
		public Int16? PLAZO4 { get; set; }
 
	/// <summary>
    ///  Set or get the PLAZO5 property.
    /// </summary>
    
		public Int16? PLAZO5 { get; set; }
 
	/// <summary>
    ///  Set or get the BANCOREM_DEF property.
    /// </summary>
    
		public string BANCOREM_DEF { get; set; }
 
	/// <summary>
    ///  Set or get the BANCO_COBRO property.
    /// </summary>
    
		public string BANCO_COBRO { get; set; }
 
	/// <summary>
    ///  Set or get the CUENTA_COBRO property.
    /// </summary>
    
		public string CUENTA_COBRO { get; set; }
 
	/// <summary>
    ///  Set or get the EFECTOS property.
    /// </summary>
    
		public byte? EFECTOS { get; set; }
 
	/// <summary>
    ///  Set or get the CREDITO property.
    /// </summary>
    
		public byte? CREDITO { get; set; }
 
	/// <summary>
    ///  Set or get the COMI property.
    /// </summary>
    
		public Decimal? COMI { get; set; }
 
	/// <summary>
    ///  Set or get the RECIBO_DOMICILIADO property.
    /// </summary>
    
		public byte? RECIBO_DOMICILIADO { get; set; }
 
	/// <summary>
    ///  Set or get the MOSTRAR_EN_LISINGR_FO property.
    /// </summary>
    
		public byte? MOSTRAR_EN_LISINGR_FO { get; set; }
 
	/// <summary>
    ///  Set or get the NO_RECIBO property.
    /// </summary>
    
		public byte? NO_RECIBO { get; set; }
 
	/// <summary>
    ///  Set or get the FC_CAFE property.
    /// </summary>
    
		public byte? FC_CAFE { get; set; }
 
	/// <summary>
    ///  Set or get the EFECTIVO property.
    /// </summary>
    
		public byte? EFECTIVO { get; set; }
 
	/// <summary>
    ///  Set or get the ENVIAR_MAIL_FC property.
    /// </summary>
    
		public byte? ENVIAR_MAIL_FC { get; set; }
 
	/// <summary>
    ///  Set or get the CUENTA_CLI property.
    /// </summary>
    
		public string CUENTA_CLI { get; set; }
 
	/// <summary>
    ///  Set or get the COMI_2ASIENTOS property.
    /// </summary>
    
		public byte? COMI_2ASIENTOS { get; set; }
 
	/// <summary>
    ///  Set or get the CAMS property.
    /// </summary>
    
		public string CAMS { get; set; }
 
	/// <summary>
    ///  Set or get the IBAN property.
    /// </summary>
    
		public string IBAN { get; set; }
 
	/// <summary>
    ///  Set or get the SWIFT property.
    /// </summary>
    
		public string SWIFT { get; set; }
 
	/// <summary>
    ///  Set or get the EMPRESA_FC property.
    /// </summary>
    
		public string EMPRESA_FC { get; set; }
 
	/// <summary>
    ///  Set or get the CIERRE_BANCOS property.
    /// </summary>
    
		public byte? CIERRE_BANCOS { get; set; }
 
	/// <summary>
    ///  Set or get the ID_TRADUC property.
    /// </summary>
    
		public Int64? ID_TRADUC { get; set; }
 
	/// <summary>
    ///  Set or get the TIPO_FACE property.
    /// </summary>
    
		public string TIPO_FACE { get; set; }
 
	/// <summary>
    ///  Set or get the GARANTIA property.
    /// </summary>
    
		public byte? GARANTIA { get; set; }
 
	/// <summary>
    ///  Set or get the CONCEPTO_SALCAJA property.
    /// </summary>
    
		public string CONCEPTO_SALCAJA { get; set; }
 
	/// <summary>
    ///  Set or get the ES_CHEQUE property.
    /// </summary>
    
		public byte? ES_CHEQUE { get; set; }
 
	/// <summary>
    ///  Set or get the ASI_AUTOMATICO property.
    /// </summary>
    
		public byte? ASI_AUTOMATICO { get; set; }
 
	/// <summary>
    ///  Set or get the PREF_431 property.
    /// </summary>
    
		public string PREF_431 { get; set; }
 
	/// <summary>
    ///  Set or get the ESDEPOSITO property.
    /// </summary>
    
		public byte? ESDEPOSITO { get; set; }
 
	/// <summary>
    ///  Set or get the TIPO_FC property.
    /// </summary>
    
		public byte? TIPO_FC { get; set; }
 
	/// <summary>
    ///  Set or get the MAILFAC_FORMA property.
    /// </summary>
    
		public string MAILFAC_FORMA { get; set; }
 
	/// <summary>
    ///  Set or get the TIPO_AENA property.
    /// </summary>
    
		public byte? TIPO_AENA { get; set; }
 
	/// <summary>
    ///  Set or get the ES_FIANZA property.
    /// </summary>
    
		public byte? ES_FIANZA { get; set; }
 
	/// <summary>
    ///  Set or get the ZONAOFI property.
    /// </summary>
    
		public string ZONAOFI { get; set; }
	}
}
