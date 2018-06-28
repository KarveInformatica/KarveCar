using KarveDapper.Extensions;
using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a CU1.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
    [Table("CU1")]
	public class CU1 
	{
	
	/// <summary>
    ///  Set or get the CODIGO property.
    /// </summary>
        [Key]
		public string CODIGO { get; set; }
 
	/// <summary>
    ///  Set or get the DESCRIP property.
    /// </summary>
    
		public string DESCRIP { get; set; }
 
	/// <summary>
    ///  Set or get the ACTIVO property.
    /// </summary>
    
		public string ACTIVO { get; set; }
 
	/// <summary>
    ///  Set or get the CC property.
    /// </summary>
    
		public string CC { get; set; }
 
	/// <summary>
    ///  Set or get the CCOSTE property.
    /// </summary>
    
		public string CCOSTE { get; set; }
 
	/// <summary>
    ///  Set or get the EXPLOTACIO property.
    /// </summary>
    
		public string EXPLOTACIO { get; set; }
 
	/// <summary>
    ///  Set or get the ULTMODI property.
    /// </summary>
    
		public string ULTMODI { get; set; }
 
	/// <summary>
    ///  Set or get the USUARIO property.
    /// </summary>
    
		public string USUARIO { get; set; }
 
	/// <summary>
    ///  Set or get the SUBLICEN property.
    /// </summary>
    
		public string SUBLICEN { get; set; }
 
	/// <summary>
    ///  Set or get the IMP_PRES property.
    /// </summary>
    
		public Double? IMP_PRES { get; set; }
 
	/// <summary>
    ///  Set or get the EXPORTA property.
    /// </summary>
    
		public byte? EXPORTA { get; set; }
 
	/// <summary>
    ///  Set or get the GRUPO property.
    /// </summary>
    
		public Int32? GRUPO { get; set; }
 
	/// <summary>
    ///  Set or get the SUBGRUPO property.
    /// </summary>
    
		public string SUBGRUPO { get; set; }
 
	/// <summary>
    ///  Set or get the FBAJA property.
    /// </summary>
    
		public DateTime? FBAJA { get; set; }
 
	/// <summary>
    ///  Set or get the FCIERRE property.
    /// </summary>
    
		public DateTime? FCIERRE { get; set; }
 
	/// <summary>
    ///  Set or get the AG_Nivel1 property.
    /// </summary>
    
		public Int32? AG_Nivel1 { get; set; }
 
	/// <summary>
    ///  Set or get the AG_Nivel2 property.
    /// </summary>
    
		public Int32? AG_Nivel2 { get; set; }
 
	/// <summary>
    ///  Set or get the OBLIGATORIO_DPTO property.
    /// </summary>
    
		public byte? OBLIGATORIO_DPTO { get; set; }
 
	/// <summary>
    ///  Set or get the OBLIGATORIO_CCOSTE property.
    /// </summary>
    
		public byte? OBLIGATORIO_CCOSTE { get; set; }
 
	/// <summary>
    ///  Set or get the CTA_COMI property.
    /// </summary>
    
		public string CTA_COMI { get; set; }
 
	/// <summary>
    ///  Set or get the CODSOCIO property.
    /// </summary>
    
		public string CODSOCIO { get; set; }
 
	/// <summary>
    ///  Set or get the CTA90 property.
    /// </summary>
    
		public string CTA90 { get; set; }
 
	/// <summary>
    ///  Set or get the CTA08 property.
    /// </summary>
    
		public string CTA08 { get; set; }
 
	/// <summary>
    ///  Set or get the CODBALANCE property.
    /// </summary>
    
		public string CODBALANCE { get; set; }
 
	/// <summary>
    ///  Set or get the DESCRIP2 property.
    /// </summary>
    
		public string DESCRIP2 { get; set; }
 
	/// <summary>
    ///  Set or get the PRODUCTO property.
    /// </summary>
    
		public string PRODUCTO { get; set; }
 
	/// <summary>
    ///  Set or get the SALDO_CIERRE property.
    /// </summary>
    
		public Decimal? SALDO_CIERRE { get; set; }
 
	/// <summary>
    ///  Set or get the FCIERRE_HIST property.
    /// </summary>
    
		public DateTime? FCIERRE_HIST { get; set; }
 
	/// <summary>
    ///  Set or get the ABREVIATURA property.
    /// </summary>
    
		public string ABREVIATURA { get; set; }
 
	/// <summary>
    ///  Set or get the LIMITE_CREDITO property.
    /// </summary>
    
		public Decimal? LIMITE_CREDITO { get; set; }
 
	/// <summary>
    ///  Set or get the EXPLOTACION property.
    /// </summary>
    
		public Int32? EXPLOTACION { get; set; }
 
	/// <summary>
    ///  Set or get the PROD_FAC property.
    /// </summary>
    
		public string PROD_FAC { get; set; }
 
	/// <summary>
    ///  Set or get the CTASTKNUEVAS property.
    /// </summary>
    
		public string CTASTKNUEVAS { get; set; }
 
	/// <summary>
    ///  Set or get the CTASTKUSADAS property.
    /// </summary>
    
		public string CTASTKUSADAS { get; set; }
 
	/// <summary>
    ///  Set or get the CTAVAREXNUEVAS property.
    /// </summary>
    
		public string CTAVAREXNUEVAS { get; set; }
 
	/// <summary>
    ///  Set or get the CTAVAREXUSADAS property.
    /// </summary>
    
		public string CTAVAREXUSADAS { get; set; }
 
	/// <summary>
    ///  Set or get the DESC_2IDIOMA_CU property.
    /// </summary>
    
		public string DESC_2IDIOMA_CU { get; set; }
 
	/// <summary>
    ///  Set or get the OBS property.
    /// </summary>
    
		public string OBS { get; set; }
 
	/// <summary>
    ///  Set or get the FCIERREDEF property.
    /// </summary>
    
		public DateTime? FCIERREDEF { get; set; }
 
	/// <summary>
    ///  Set or get the NOMODIFICA_DESC property.
    /// </summary>
    
		public byte? NOMODIFICA_DESC { get; set; }
 
	/// <summary>
    ///  Set or get the DEPART_CTA property.
    /// </summary>
    
		public string DEPART_CTA { get; set; }
 
	/// <summary>
    ///  Set or get the CODIGO_JD property.
    /// </summary>
    
		public string CODIGO_JD { get; set; }
 
	/// <summary>
    ///  Set or get the CTA_SAT property.
    /// </summary>
    
		public string CTA_SAT { get; set; }
 
	/// <summary>
    ///  Set or get the CTAGASTO_ASOCIADA property.
    /// </summary>
    
		public string CTAGASTO_ASOCIADA { get; set; }
 
	/// <summary>
    ///  Set or get the COD_RET_GANAN property.
    /// </summary>
    
		public Int32? COD_RET_GANAN { get; set; }
 
	/// <summary>
    ///  Set or get the COD_RET_IVA property.
    /// </summary>
    
		public Int32? COD_RET_IVA { get; set; }
 
	/// <summary>
    ///  Set or get the NOMOSTRARSALDOAUSU property.
    /// </summary>
    
		public byte? NOMOSTRARSALDOAUSU { get; set; }
 
	/// <summary>
    ///  Set or get the GRUPOCAR property.
    /// </summary>
    
		public string GRUPOCAR { get; set; }
 
	/// <summary>
    ///  Set or get the MUESTRA_SALIDASCAJA property.
    /// </summary>
    
		public byte? MUESTRA_SALIDASCAJA { get; set; }
	}
}
