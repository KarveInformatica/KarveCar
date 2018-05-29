using System;
using Dapper;
using KarveDapper;
using KarveDapper.Extensions;

namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a PROVEE1.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	[Table("PROVEE1")]
	public class PROVEE1 
	{
	
	/// <summary>
    ///  Set or get the NUM_PROVEE property.
    /// </summary>
		 [Key]
		public string NUM_PROVEE { get; set; }
 
	/// <summary>
    ///  Set or get the NOMBRE property.
    /// </summary>
    
		public string NOMBRE { get; set; }
 
	/// <summary>
    ///  Set or get the DIRECCION property.
    /// </summary>
    
		public string DIRECCION { get; set; }
 
	/// <summary>
    ///  Set or get the DIREC2 property.
    /// </summary>
    
		public string DIREC2 { get; set; }
 
	/// <summary>
    ///  Set or get the POBLACION property.
    /// </summary>
    
		public string POBLACION { get; set; }
 
	/// <summary>
    ///  Set or get the CP property.
    /// </summary>
    
		public string CP { get; set; }
 
	/// <summary>
    ///  Set or get the PROV property.
    /// </summary>
    
		public string PROV { get; set; }
 
	/// <summary>
    ///  Set or get the NIF_OLD property.
    /// </summary>
    
		public string NIF_OLD { get; set; }
 
	/// <summary>
    ///  Set or get the TELEFONO property.
    /// </summary>
    
		public string TELEFONO { get; set; }
 
	/// <summary>
    ///  Set or get the FAX property.
    /// </summary>
    
		public string FAX { get; set; }
 
	/// <summary>
    ///  Set or get the MODEM property.
    /// </summary>
    
		public string MODEM { get; set; }
 
	/// <summary>
    ///  Set or get the PERSONA property.
    /// </summary>
    
		public string PERSONA { get; set; }
 
	/// <summary>
    ///  Set or get the BANCO property.
    /// </summary>
    
		public string BANCO { get; set; }
 
	/// <summary>
    ///  Set or get the CC property.
    /// </summary>
    
		public string CC { get; set; }
 
	/// <summary>
    ///  Set or get the INTERNET property.
    /// </summary>
    
		public string INTERNET { get; set; }
 
	/// <summary>
    ///  Set or get the EMAIL property.
    /// </summary>
    
		public string EMAIL { get; set; }
 
	/// <summary>
    ///  Set or get the NACIOPER property.
    /// </summary>
    
		public string NACIOPER { get; set; }
 
	/// <summary>
    ///  Set or get the NACIODOMI property.
    /// </summary>
    
		public string NACIODOMI { get; set; }
 
	/// <summary>
    ///  Set or get the PROACRE property.
    /// </summary>
    
		public string PROACRE { get; set; }
 
	/// <summary>
    ///  Set or get the ULTMODI property.
    /// </summary>
    
		public string ULTMODI { get; set; }
 
	/// <summary>
    ///  Set or get the OBSERVA property.
    /// </summary>
    
		public string OBSERVA { get; set; }
 
	/// <summary>
    ///  Set or get the NOTAS property.
    /// </summary>
    
		public string NOTAS { get; set; }
 
	/// <summary>
    ///  Set or get the USUARIO property.
    /// </summary>
    
		public string USUARIO { get; set; }
 
	/// <summary>
    ///  Set or get the TIPO property.
    /// </summary>
    
		public Int16? TIPO { get; set; }
 
	/// <summary>
    ///  Set or get the SUBLICEN property.
    /// </summary>
    
		public string SUBLICEN { get; set; }
 
	/// <summary>
    ///  Set or get the CTAPAGO property.
    /// </summary>
    
		public string CTAPAGO { get; set; }
 
	/// <summary>
    ///  Set or get the DESCRIP_COMP property.
    /// </summary>
    
		public string DESCRIP_COMP { get; set; }
 
	/// <summary>
    ///  Set or get the CTAINTRACOP property.
    /// </summary>
    
		public string CTAINTRACOP { get; set; }
 
	/// <summary>
    ///  Set or get the TIPOIVA property.
    /// </summary>
    
		public string TIPOIVA { get; set; }
 
	/// <summary>
    ///  Set or get the FALTA property.
    /// </summary>
    
		public DateTime? FALTA { get; set; }
 
	/// <summary>
    ///  Set or get the FBAJA property.
    /// </summary>
    
		public DateTime? FBAJA { get; set; }
 
	/// <summary>
    ///  Set or get the IBAN property.
    /// </summary>
    
		public string IBAN { get; set; }
 
	/// <summary>
    ///  Set or get the IDIOMA_PR1 property.
    /// </summary>
    
		public byte? IDIOMA_PR1 { get; set; }
 
	/// <summary>
    ///  Set or get the CTACP property.
    /// </summary>
    
		public string CTACP { get; set; }
 
	/// <summary>
    ///  Set or get the CTALP property.
    /// </summary>
    
		public string CTALP { get; set; }
 
	/// <summary>
    ///  Set or get the PLAZOENT property.
    /// </summary>
    
		public Int32? PLAZOENT { get; set; }
 
	/// <summary>
    ///  Set or get the DIR_PAGO property.
    /// </summary>
    
		public string DIR_PAGO { get; set; }
 
	/// <summary>
    ///  Set or get the DIR2_PAGO property.
    /// </summary>
    
		public string DIR2_PAGO { get; set; }
 
	/// <summary>
    ///  Set or get the CP_PAGO property.
    /// </summary>
    
		public string CP_PAGO { get; set; }
 
	/// <summary>
    ///  Set or get the POB_PAGO property.
    /// </summary>
    
		public string POB_PAGO { get; set; }
 
	/// <summary>
    ///  Set or get the PROV_PAGO property.
    /// </summary>
    
		public string PROV_PAGO { get; set; }
 
	/// <summary>
    ///  Set or get the PAIS_PAGO property.
    /// </summary>
    
		public string PAIS_PAGO { get; set; }
 
	/// <summary>
    ///  Set or get the TELF_PAGO property.
    /// </summary>
    
		public string TELF_PAGO { get; set; }
 
	/// <summary>
    ///  Set or get the FAX_PAGO property.
    /// </summary>
    
		public string FAX_PAGO { get; set; }
 
	/// <summary>
    ///  Set or get the MAIL_PAGO property.
    /// </summary>
    
		public string MAIL_PAGO { get; set; }
 
	/// <summary>
    ///  Set or get the PERSONA_PAGO property.
    /// </summary>
    
		public string PERSONA_PAGO { get; set; }
 
	/// <summary>
    ///  Set or get the DIR_RECLAMA property.
    /// </summary>
    
		public string DIR_RECLAMA { get; set; }
 
	/// <summary>
    ///  Set or get the DIR2_RECLAMA property.
    /// </summary>
    
		public string DIR2_RECLAMA { get; set; }
 
	/// <summary>
    ///  Set or get the CP_RECLAMA property.
    /// </summary>
    
		public string CP_RECLAMA { get; set; }
 
	/// <summary>
    ///  Set or get the POB_RECLAMA property.
    /// </summary>
    
		public string POB_RECLAMA { get; set; }
 
	/// <summary>
    ///  Set or get the PROV_RECLAMA property.
    /// </summary>
    
		public string PROV_RECLAMA { get; set; }
 
	/// <summary>
    ///  Set or get the PAIS_RECLAMA property.
    /// </summary>
    
		public string PAIS_RECLAMA { get; set; }
 
	/// <summary>
    ///  Set or get the TELF_RECLAMA property.
    /// </summary>
    
		public string TELF_RECLAMA { get; set; }
 
	/// <summary>
    ///  Set or get the FAX_RECLAMA property.
    /// </summary>
    
		public string FAX_RECLAMA { get; set; }
 
	/// <summary>
    ///  Set or get the MAIL_RECLAMA property.
    /// </summary>
    
		public string MAIL_RECLAMA { get; set; }
 
	/// <summary>
    ///  Set or get the PERSONA_RECLAMA property.
    /// </summary>
    
		public string PERSONA_RECLAMA { get; set; }
 
	/// <summary>
    ///  Set or get the PROVEELEAS property.
    /// </summary>
    
		public byte? PROVEELEAS { get; set; }
 
	/// <summary>
    ///  Set or get the MESVACA property.
    /// </summary>
    
		public byte? MESVACA { get; set; }
 
	/// <summary>
    ///  Set or get the PLAZO_SN property.
    /// </summary>
    
		public Int32? PLAZO_SN { get; set; }
 
	/// <summary>
    ///  Set or get the PLAZO_COMP property.
    /// </summary>
    
		public Int32? PLAZO_COMP { get; set; }
 
	/// <summary>
    ///  Set or get the PLAZO_ANT property.
    /// </summary>
    
		public Int32? PLAZO_ANT { get; set; }
 
	/// <summary>
    ///  Set or get the VIA property.
    /// </summary>
    
		public byte? VIA { get; set; }
 
	/// <summary>
    ///  Set or get the MARGEN property.
    /// </summary>
    
		public Decimal? MARGEN { get; set; }
 
	/// <summary>
    ///  Set or get the MAIL_PEDI property.
    /// </summary>
    
		public string MAIL_PEDI { get; set; }
 
	/// <summary>
    ///  Set or get the CUGASTOABONO property.
    /// </summary>
    
		public string CUGASTOABONO { get; set; }
 
	/// <summary>
    ///  Set or get the DIRENVIO1 property.
    /// </summary>
    
		public string DIRENVIO1 { get; set; }
 
	/// <summary>
    ///  Set or get the DIRENVIO2 property.
    /// </summary>
    
		public string DIRENVIO2 { get; set; }
 
	/// <summary>
    ///  Set or get the DIRENVIO3 property.
    /// </summary>
    
		public string DIRENVIO3 { get; set; }
 
	/// <summary>
    ///  Set or get the DIRENVIO4 property.
    /// </summary>
    
		public string DIRENVIO4 { get; set; }
 
	/// <summary>
    ///  Set or get the DIRENVIO5 property.
    /// </summary>
    
		public string DIRENVIO5 { get; set; }
 
	/// <summary>
    ///  Set or get the DIRENVIO6 property.
    /// </summary>
    
		public string DIRENVIO6 { get; set; }
 
	/// <summary>
    ///  Set or get the FORMA_ENVIO property.
    /// </summary>
    
		public byte? FORMA_ENVIO { get; set; }
 
	/// <summary>
    ///  Set or get the CONDICION_VENTA property.
    /// </summary>
    
		public byte? CONDICION_VENTA { get; set; }
 
	/// <summary>
    ///  Set or get the CODIEDI_PR1 property.
    /// </summary>
    
		public string CODIEDI_PR1 { get; set; }
 
	/// <summary>
    ///  Set or get the DISTRIB_PR1 property.
    /// </summary>
    
		public string DISTRIB_PR1 { get; set; }
 
	/// <summary>
    ///  Set or get the DIR_DEVO property.
    /// </summary>
    
		public string DIR_DEVO { get; set; }
 
	/// <summary>
    ///  Set or get the DIR2_DEVO property.
    /// </summary>
    
		public string DIR2_DEVO { get; set; }
 
	/// <summary>
    ///  Set or get the CP_DEVO property.
    /// </summary>
    
		public string CP_DEVO { get; set; }
 
	/// <summary>
    ///  Set or get the POB_DEVO property.
    /// </summary>
    
		public string POB_DEVO { get; set; }
 
	/// <summary>
    ///  Set or get the PROV_DEVO property.
    /// </summary>
    
		public string PROV_DEVO { get; set; }
 
	/// <summary>
    ///  Set or get the PAIS_DEVO property.
    /// </summary>
    
		public string PAIS_DEVO { get; set; }
 
	/// <summary>
    ///  Set or get the TELF_DEVO property.
    /// </summary>
    
		public string TELF_DEVO { get; set; }
 
	/// <summary>
    ///  Set or get the FAX_DEVO property.
    /// </summary>
    
		public string FAX_DEVO { get; set; }
 
	/// <summary>
    ///  Set or get the MAIL_DEVO property.
    /// </summary>
    
		public string MAIL_DEVO { get; set; }
 
	/// <summary>
    ///  Set or get the PERSONA_DEVO property.
    /// </summary>
    
		public string PERSONA_DEVO { get; set; }
 
	/// <summary>
    ///  Set or get the SWIFT property.
    /// </summary>
    
		public string SWIFT { get; set; }
 
	/// <summary>
    ///  Set or get the FAPROBACION property.
    /// </summary>
    
		public DateTime? FAPROBACION { get; set; }
 
	/// <summary>
    ///  Set or get the DIR_PROVEE property.
    /// </summary>
    
		public string DIR_PROVEE { get; set; }
 
	/// <summary>
    ///  Set or get the F_AEAT property.
    /// </summary>
    
		public DateTime? F_AEAT { get; set; }
 
	/// <summary>
    ///  Set or get the CTA_EFECTO property.
    /// </summary>
    
		public string CTA_EFECTO { get; set; }
 
	/// <summary>
    ///  Set or get the MOVIL property.
    /// </summary>
    
		public string MOVIL { get; set; }
 
	/// <summary>
    ///  Set or get the FINI_GESTINCI property.
    /// </summary>
    
		public DateTime? FINI_GESTINCI { get; set; }
 
	/// <summary>
    ///  Set or get the FFIN_GESTINCI property.
    /// </summary>
    
		public DateTime? FFIN_GESTINCI { get; set; }
 
	/// <summary>
    ///  Set or get the PRUEBA_HOMO property.
    /// </summary>
    
		public byte? PRUEBA_HOMO { get; set; }
 
	/// <summary>
    ///  Set or get the PERS_DPTALDI property.
    /// </summary>
    
		public string PERS_DPTALDI { get; set; }
 
	/// <summary>
    ///  Set or get the PERS_ATT property.
    /// </summary>
    
		public string PERS_ATT { get; set; }
 
	/// <summary>
    ///  Set or get the COD_SOCIEDAD property.
    /// </summary>
    
		public string COD_SOCIEDAD { get; set; }
 
	/// <summary>
    ///  Set or get the PORTES property.
    /// </summary>
    
		public byte? PORTES { get; set; }
 
	/// <summary>
    ///  Set or get the NOMBRESOLO property.
    /// </summary>
    
		public string NOMBRESOLO { get; set; }
 
	/// <summary>
    ///  Set or get the APELLIDO1 property.
    /// </summary>
    
		public string APELLIDO1 { get; set; }
 
	/// <summary>
    ///  Set or get the APELLIDO2 property.
    /// </summary>
    
		public string APELLIDO2 { get; set; }
 
	/// <summary>
    ///  Set or get the TIPOVIA property.
    /// </summary>
    
		public string TIPOVIA { get; set; }
 
	/// <summary>
    ///  Set or get the NO_ENVIAR property.
    /// </summary>
    
		public byte? NO_ENVIAR { get; set; }
 
	/// <summary>
    ///  Set or get the MESVACA2 property.
    /// </summary>
    
		public byte? MESVACA2 { get; set; }
 
	/// <summary>
    ///  Set or get the COORDGPS property.
    /// </summary>
    
		public string COORDGPS { get; set; }
 
	/// <summary>
    ///  Set or get the OFICINA property.
    /// </summary>
    
		public string OFICINA { get; set; }
 
	/// <summary>
    ///  Set or get the APARTADOCORREOS property.
    /// </summary>
    
		public string APARTADOCORREOS { get; set; }
 
	/// <summary>
    ///  Set or get the PORRETEN property.
    /// </summary>
    
		public Decimal? PORRETEN { get; set; }
 
	/// <summary>
    ///  Set or get the GESTION_IVA_IMPORTA property.
    /// </summary>
    
		public byte? GESTION_IVA_IMPORTA { get; set; }
 
	/// <summary>
    ///  Set or get the NUMCOMI_PR property.
    /// </summary>
    
		public string NUMCOMI_PR { get; set; }
 
	/// <summary>
    ///  Set or get the TRANSPORTE_PROPIO property.
    /// </summary>
    
		public byte? TRANSPORTE_PROPIO { get; set; }
 
	/// <summary>
    ///  Set or get the PROVEETIPO property.
    /// </summary>
    
		public string PROVEETIPO { get; set; }
 
	/// <summary>
    ///  Set or get the BD_DESTINO property.
    /// </summary>
    
		public string BD_DESTINO { get; set; }
 
	/// <summary>
    ///  Set or get the PROVEE_DEST property.
    /// </summary>
    
		public string PROVEE_DEST { get; set; }
 
	/// <summary>
    ///  Set or get the EMP_DEST property.
    /// </summary>
    
		public string EMP_DEST { get; set; }
 
	/// <summary>
    ///  Set or get the POR property.
    /// </summary>
    
		public Decimal? POR { get; set; }
 
	/// <summary>
    ///  Set or get the EXENCIONES_INT property.
    /// </summary>
    
		public byte? EXENCIONES_INT { get; set; }
 
	/// <summary>
    ///  Set or get the CUGASTO2 property.
    /// </summary>
    
		public string CUGASTO2 { get; set; }
 
	/// <summary>
    ///  Set or get the FVALIDEZ property.
    /// </summary>
    
		public DateTime? FVALIDEZ { get; set; }
 
	/// <summary>
    ///  Set or get the KCODIGO_CLI property.
    /// </summary>
    
		public string KCODIGO_CLI { get; set; }
 
	/// <summary>
    ///  Set or get the NUMMAX_CONFORMI property.
    /// </summary>
    
		public Int32? NUMMAX_CONFORMI { get; set; }
 
	/// <summary>
    ///  Set or get the ctaintracoPRep property.
    /// </summary>
    
		public string ctaintracoPRep { get; set; }
 
	/// <summary>
    ///  Set or get the ETIQ4X4 property.
    /// </summary>
    
		public byte? ETIQ4X4 { get; set; }
 
	/// <summary>
    ///  Set or get the ETIQSEGUIDO property.
    /// </summary>
    
		public byte? ETIQSEGUIDO { get; set; }

	/// <summary>
    ///  Set or get the PROMOWEB property.
    /// </summary>
    
		public string PROMOWEB { get; set; }
 
	/// <summary>
    ///  Set or get the PROALB_COSTE_TRANSP property.
    /// </summary>
    
		public byte? PROALB_COSTE_TRANSP { get; set; }
 
	/// <summary>
    ///  Set or get the POR_PAGO_PEDIDO property.
    /// </summary>
    
		public Decimal? POR_PAGO_PEDIDO { get; set; }
 
	/// <summary>
    ///  Set or get the POR_PAGO_ENTREGA property.
    /// </summary>
    
		public Decimal? POR_PAGO_ENTREGA { get; set; }
 
	/// <summary>
    ///  Set or get the POR_ARANCEL property.
    /// </summary>
    
		public Decimal? POR_ARANCEL { get; set; }
 
	/// <summary>
    ///  Set or get the CANAL_PR property.
    /// </summary>
    
		public Int32? CANAL_PR { get; set; }
 
	/// <summary>
    ///  Set or get the BPS_PROVE property.
    /// </summary>
    
		public string BPS_PROVE { get; set; }
 
	/// <summary>
    ///  Set or get the GESTIONAR_POR_PORTES property.
    /// </summary>
    
		public byte? GESTIONAR_POR_PORTES { get; set; }
 
	/// <summary>
    ///  Set or get the POR_PORTES property.
    /// </summary>
    
		public Decimal? POR_PORTES { get; set; }
 
	/// <summary>
    ///  Set or get the TIPOCOMP_P1 property.
    /// </summary>
    
		public string TIPOCOMP_P1 { get; set; }
 
	/// <summary>
    ///  Set or get the AUTOFAC_MANTE property.
    /// </summary>
    
		public byte? AUTOFAC_MANTE { get; set; }
 
	/// <summary>
    ///  Set or get the USA_CRITERIOCAJA property.
    /// </summary>
    
		public byte? USA_CRITERIOCAJA { get; set; }
 
	/// <summary>
    ///  Set or get the FINI_CRITERIOCAJA property.
    /// </summary>
    
		public DateTime? FINI_CRITERIOCAJA { get; set; }
 
	/// <summary>
    ///  Set or get the DISTRIB_PRO property.
    /// </summary>
    
		public string DISTRIB_PRO { get; set; }
 
	/// <summary>
    ///  Set or get the CORRESPONDE_BDPREC property.
    /// </summary>
    
		public string CORRESPONDE_BDPREC { get; set; }
 
	/// <summary>
    ///  Set or get the APROBADO_PR property.
    /// </summary>
    
		public byte? APROBADO_PR { get; set; }
 
	/// <summary>
    ///  Set or get the TIPOGASTO_COMP_PR property.
    /// </summary>
    
		public byte? TIPOGASTO_COMP_PR { get; set; }
 
	/// <summary>
    ///  Set or get the ES_AMAZON_PRO property.
    /// </summary>
    
		public byte? ES_AMAZON_PRO { get; set; }
 
	/// <summary>
    ///  Set or get the RETEN_IVA property.
    /// </summary>
    
		public byte? RETEN_IVA { get; set; }
 
	/// <summary>
    ///  Set or get the RETEN_IB property.
    /// </summary>
    
		public byte? RETEN_IB { get; set; }
 
	/// <summary>
    ///  Set or get the RETEN_GANAN property.
    /// </summary>
    
		public byte? RETEN_GANAN { get; set; }
 
	/// <summary>
    ///  Set or get the NUMEROCLI property.
    /// </summary>
    
		public string NUMEROCLI { get; set; }
 
	/// <summary>
    ///  Set or get the COLABORA_AMAZON property.
    /// </summary>
    
		public byte? COLABORA_AMAZON { get; set; }
 
	/// <summary>
    ///  Set or get the CLIENTE_DEST property.
    /// </summary>
    
		public string CLIENTE_DEST { get; set; }
 
	/// <summary>
    ///  Set or get the F_ULT_CAMBIO_PREC property.
    /// </summary>
    
		public DateTime? F_ULT_CAMBIO_PREC { get; set; }
 
	/// <summary>
    ///  Set or get the NOAUTOMARGEN property.
    /// </summary>
    
		public byte? NOAUTOMARGEN { get; set; }
 
	/// <summary>
    ///  Set or get the TIPO_PROVEE_IVA property.
    /// </summary>
    
		public byte? TIPO_PROVEE_IVA { get; set; }
 
	/// <summary>
    ///  Set or get the CODIGOEXTERNO property.
    /// </summary>
    
		public string CODIGOEXTERNO { get; set; }
 
	/// <summary>
    ///  Set or get the COD_DILVE property.
    /// </summary>
    
		public string COD_DILVE { get; set; }
 
	/// <summary>
    ///  Set or get the VENTA_ONLINE_PRO property.
    /// </summary>
    
		public byte? VENTA_ONLINE_PRO { get; set; }
 
	/// <summary>
    ///  Set or get the TIENE_NEWSLETTERS property.
    /// </summary>
    
		public byte? TIENE_NEWSLETTERS { get; set; }
 
	/// <summary>
    ///  Set or get the SIN_GASTOS_ENVIO_PR1 property.
    /// </summary>
    
		public byte? SIN_GASTOS_ENVIO_PR1 { get; set; }
 
	/// <summary>
    ///  Set or get the TEXTO_AMAZON property.
    /// </summary>
    
		public string TEXTO_AMAZON { get; set; }
 
	/// <summary>
    ///  Set or get the VISITASRARAS property.
    /// </summary>
    
		public byte? VISITASRARAS { get; set; }
 
	/// <summary>
    ///  Set or get the USA_STK_AMAZON_PR1 property.
    /// </summary>
    
		public byte? USA_STK_AMAZON_PR1 { get; set; }
 
	/// <summary>
    ///  Set or get the TIPOIVA_P1 property.
    /// </summary>
    
		public string TIPOIVA_P1 { get; set; }
 
	/// <summary>
    ///  Set or get the EMAIL_MAN_P1 property.
    /// </summary>
    
		public string EMAIL_MAN_P1 { get; set; }
 
	/// <summary>
    ///  Set or get the NIF property.
    /// </summary>
    
		public string NIF { get; set; }
	}
}
