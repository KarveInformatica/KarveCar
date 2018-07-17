using System;
using KarveDapper;
using KarveDapper.Extensions;

namespace DataAccessLayer.DataObjects
{
    /// <summary>
    /// Represents a CONCEP_FACTUR.
    /// NOTE: This class is generated from a T4 template - you should not modify it manually.
    /// </summary>
    [Table("CONCEP_FACTUR")]
    public class CONCEP_FACTUR 
	{
	
	    /// <summary>
        ///  Set or get the CODIGO property.
        /// </summary>
        [Key]
		public Int32 CODIGO { get; set; }
 
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
    ///  Set or get the DTO property.
    /// </summary>
    
		public string DTO { get; set; }
 
	/// <summary>
    ///  Set or get the TIPO property.
    /// </summary>
    
		public byte? TIPO { get; set; }
 
	/// <summary>
    ///  Set or get the PERMITIDO property.
    /// </summary>
    
		public byte? PERMITIDO { get; set; }
 
	/// <summary>
    ///  Set or get the INCENTIVO_CF property.
    /// </summary>
    
		public byte? INCENTIVO_CF { get; set; }
 
	/// <summary>
    ///  Set or get the FACAQUIEN property.
    /// </summary>
    
		public byte? FACAQUIEN { get; set; }
 
	/// <summary>
    ///  Set or get the TIPOTRAMO property.
    /// </summary>
    
		public byte? TIPOTRAMO { get; set; }
 
	/// <summary>
    ///  Set or get the PRECIO property.
    /// </summary>
    
		public Double? PRECIO { get; set; }
 
	/// <summary>
    ///  Set or get the INCLUIDO property.
    /// </summary>
    
		public Int32? INCLUIDO { get; set; }
 
	/// <summary>
    ///  Set or get the AUTOMATICO property.
    /// </summary>
    
		public byte? AUTOMATICO { get; set; }
 
	/// <summary>
    ///  Set or get the HORAS property.
    /// </summary>
    
		public Decimal? HORAS { get; set; }
 
	/// <summary>
    ///  Set or get the IGIC property.
    /// </summary>
    
		public Decimal? IGIC { get; set; }
 
	/// <summary>
    ///  Set or get the CUENTA property.
    /// </summary>
    
		public string CUENTA { get; set; }
 
	/// <summary>
    ///  Set or get the PLUS_NOCTURNIDAD property.
    /// </summary>
    
		public byte? PLUS_NOCTURNIDAD { get; set; }
 
	/// <summary>
    ///  Set or get the COSTE_CHOFER property.
    /// </summary>
    
		public Decimal? COSTE_CHOFER { get; set; }
 
	/// <summary>
    ///  Set or get the FBAJA property.
    /// </summary>
    
		public DateTime? FBAJA { get; set; }
 
	/// <summary>
    ///  Set or get the BORRA_LINEA property.
    /// </summary>
    
		public byte? BORRA_LINEA { get; set; }
 
	/// <summary>
    ///  Set or get the PW property.
    /// </summary>
    
		public string PW { get; set; }
 
	/// <summary>
    ///  Set or get the LIQPOR_CONCEPTO property.
    /// </summary>
    
		public byte? LIQPOR_CONCEPTO { get; set; }
 
	/// <summary>
    ///  Set or get the GESTIONA_BONO property.
    /// </summary>
    
		public byte? GESTIONA_BONO { get; set; }
 
	/// <summary>
    ///  Set or get the NO_UFS property.
    /// </summary>
    
		public byte? NO_UFS { get; set; }
 
	/// <summary>
    ///  Set or get the PLAZA property.
    /// </summary>
    
		public byte? PLAZA { get; set; }
 
	/// <summary>
    ///  Set or get the HORAS_APROX property.
    /// </summary>
    
		public Int32? HORAS_APROX { get; set; }
 
	/// <summary>
    ///  Set or get the CTA_CF property.
    /// </summary>
    
		public byte? CTA_CF { get; set; }
 
	/// <summary>
    ///  Set or get the NOMBRE2 property.
    /// </summary>
    
		public string NOMBRE2 { get; set; }
 
	/// <summary>
    ///  Set or get the PASAR_COMI_RES_CTR property.
    /// </summary>
    
		public byte? PASAR_COMI_RES_CTR { get; set; }
 
	/// <summary>
    ///  Set or get the NOFRANKI property.
    /// </summary>
    
		public byte? NOFRANKI { get; set; }
 
	/// <summary>
    ///  Set or get the ACCESORIO property.
    /// </summary>
    
		public byte? ACCESORIO { get; set; }
 
	/// <summary>
    ///  Set or get the MOSTRAR_EN_LISINGR_CF property.
    /// </summary>
    
		public byte? MOSTRAR_EN_LISINGR_CF { get; set; }
 
	/// <summary>
    ///  Set or get the MODIFICAR_CON_PW property.
    /// </summary>
    
		public byte? MODIFICAR_CON_PW { get; set; }
 
	/// <summary>
    ///  Set or get the TIPO_SRV property.
    /// </summary>
    
		public byte? TIPO_SRV { get; set; }
 
	/// <summary>
    ///  Set or get the ORDEN_ENFAC property.
    /// </summary>
    
		public Int32? ORDEN_ENFAC { get; set; }
 
	/// <summary>
    ///  Set or get the DIETA property.
    /// </summary>
    
		public byte? DIETA { get; set; }
 
	/// <summary>
    ///  Set or get the KM property.
    /// </summary>
    
		public Int32? KM { get; set; }
 
	/// <summary>
    ///  Set or get the KM_INCLUIDOS_CF property.
    /// </summary>
    
		public Int32? KM_INCLUIDOS_CF { get; set; }
 
	/// <summary>
    ///  Set or get the MOSTRAR_WEB property.
    /// </summary>
    
		public byte? MOSTRAR_WEB { get; set; }
 
	/// <summary>
    ///  Set or get the PRE_PAID_CF property.
    /// </summary>
    
		public byte? PRE_PAID_CF { get; set; }
 
	/// <summary>
    ///  Set or get the MAXIMO_CF property.
    /// </summary>
    
		public Decimal? MAXIMO_CF { get; set; }
 
	/// <summary>
    ///  Set or get the PRIOR_CF property.
    /// </summary>
    
		public byte? PRIOR_CF { get; set; }
 
	/// <summary>
    ///  Set or get the PRECIO_IVA_INC property.
    /// </summary>
    
		public Decimal? PRECIO_IVA_INC { get; set; }
 
	/// <summary>
    ///  Set or get the MINIMO_CF property.
    /// </summary>
    
		public Decimal? MINIMO_CF { get; set; }
 
	/// <summary>
    ///  Set or get the ID_TRADUC property.
    /// </summary>
    
		public Int64? ID_TRADUC { get; set; }
 
	/// <summary>
    ///  Set or get the PERMITEVARIOS_CF property.
    /// </summary>
    
		public byte? PERMITEVARIOS_CF { get; set; }
 
	/// <summary>
    ///  Set or get the CONCEPTO_WEB_CF property.
    /// </summary>
    
		public Int32? CONCEPTO_WEB_CF { get; set; }
 
	/// <summary>
    ///  Set or get the ID_FAMILIA property.
    /// </summary>
    
		public Int32? ID_FAMILIA { get; set; }
 
	/// <summary>
    ///  Set or get the ID_SUBFAMILIA property.
    /// </summary>
    
		public Int32? ID_SUBFAMILIA { get; set; }
 
	/// <summary>
    ///  Set or get the ID_ARTICULO property.
    /// </summary>
    
		public string ID_ARTICULO { get; set; }
 
	/// <summary>
    ///  Set or get the ID_GS1 property.
    /// </summary>
    
		public string ID_GS1 { get; set; }
 
	/// <summary>
    ///  Set or get the NODO_XML property.
    /// </summary>
    
		public string NODO_XML { get; set; }
 
	/// <summary>
    ///  Set or get the CONCEP_CANON property.
    /// </summary>
    
		public string CONCEP_CANON { get; set; }
 
	/// <summary>
    ///  Set or get the SUBCONCEP_CANON property.
    /// </summary>
    
		public string SUBCONCEP_CANON { get; set; }
 
	/// <summary>
    ///  Set or get the NO_AUTOCOT property.
    /// </summary>
    
		public byte? NO_AUTOCOT { get; set; }
 
	/// <summary>
    ///  Set or get the REDUC_FRANQUI property.
    /// </summary>
    
		public byte? REDUC_FRANQUI { get; set; }
 
	/// <summary>
    ///  Set or get the CONCEP_CIERRE_CF property.
    /// </summary>
    
		public byte? CONCEP_CIERRE_CF { get; set; }
 
	/// <summary>
    ///  Set or get the CUENTA2 property.
    /// </summary>
    
		public string CUENTA2 { get; set; }
 
	/// <summary>
    ///  Set or get the OBS_CF property.
    /// </summary>
    
		public string OBS_CF { get; set; }
	}
}
