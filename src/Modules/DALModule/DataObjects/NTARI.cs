using System;
using Dapper;
using KarveDapper;
using KarveDapper.Extensions;

namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a NTARI.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
    [Table("NTARI")]
	public class NTARI 
	{
	
	/// <summary>
    ///  Set or get the CODIGO property.
    /// </summary>
    [Key]
		public string CODIGO { get; set; }
 
	/// <summary>
    ///  Set or get the NOMBRE property.
    /// </summary>
    
		public string NOMBRE { get; set; }
 
	/// <summary>
    ///  Set or get the FINSEMA property.
    /// </summary>
    
		public string FINSEMA { get; set; }
 
	/// <summary>
    ///  Set or get the MINIMO property.
    /// </summary>
    
		public byte? MINIMO { get; set; }
 
	/// <summary>
    ///  Set or get the MAXIMO property.
    /// </summary>
    
		public Int16? MAXIMO { get; set; }
 
	/// <summary>
    ///  Set or get the OBS1 property.
    /// </summary>
    
		public string OBS1 { get; set; }
 
	/// <summary>
    ///  Set or get the DESDE property.
    /// </summary>
    
		public DateTime? DESDE { get; set; }
 
	/// <summary>
    ///  Set or get the DIASANTES property.
    /// </summary>
    
		public Int16? DIASANTES { get; set; }
 
	/// <summary>
    ///  Set or get the TODOIN property.
    /// </summary>
    
		public string TODOIN { get; set; }
 
	/// <summary>
    ///  Set or get the MONEDA property.
    /// </summary>
    
		public string MONEDA { get; set; }
 
	/// <summary>
    ///  Set or get the INCLUYE property.
    /// </summary>
    
		public string INCLUYE { get; set; }
 
	/// <summary>
    ///  Set or get the EXCLUYE property.
    /// </summary>
    
		public string EXCLUYE { get; set; }
 
	/// <summary>
    ///  Set or get the KMILIM property.
    /// </summary>
    
		public string KMILIM { get; set; }
 
	/// <summary>
    ///  Set or get the ULTMODI property.
    /// </summary>
    
		public string ULTMODI { get; set; }
 
	/// <summary>
    ///  Set or get the USUARIO property.
    /// </summary>
    
		public string USUARIO { get; set; }
 
	/// <summary>
    ///  Set or get the HASTA property.
    /// </summary>
    
		public DateTime? HASTA { get; set; }
 
	/// <summary>
    ///  Set or get the REGDE property.
    /// </summary>
    
		public DateTime? REGDE { get; set; }
 
	/// <summary>
    ///  Set or get the CNR property.
    /// </summary>
    
		public string CNR { get; set; }
 
	/// <summary>
    ///  Set or get the DESTINO property.
    /// </summary>
    
		public string DESTINO { get; set; }
 
	/// <summary>
    ///  Set or get the REGHA property.
    /// </summary>
    
		public DateTime? REGHA { get; set; }
 
	/// <summary>
    ///  Set or get the _DTO_SN property.
    /// </summary>
    
		public string _DTO_SN { get; set; }
 
	/// <summary>
    ///  Set or get the KMInclu property.
    /// </summary>
    
		public Int16? KMInclu { get; set; }
 
	/// <summary>
    ///  Set or get the SUBLICEN property.
    /// </summary>
    
		public string SUBLICEN { get; set; }
 
	/// <summary>
    ///  Set or get the ACTIVA property.
    /// </summary>
    
		public string ACTIVA { get; set; }
 
	/// <summary>
    ///  Set or get the MAXDTO property.
    /// </summary>
    
		public Decimal? MAXDTO { get; set; }
 
	/// <summary>
    ///  Set or get the DESDEO property.
    /// </summary>
    
		public DateTime? DESDEO { get; set; }
 
	/// <summary>
    ///  Set or get the HASTAO property.
    /// </summary>
    
		public DateTime? HASTAO { get; set; }
 
	/// <summary>
    ///  Set or get the GRUPO_GT property.
    /// </summary>
    
		public string GRUPO_GT { get; set; }
 
	/// <summary>
    ///  Set or get the PUBLICA property.
    /// </summary>
    
		public string PUBLICA { get; set; }
 
	/// <summary>
    ///  Set or get the COMI_MAX property.
    /// </summary>
    
		public Decimal? COMI_MAX { get; set; }
 
	/// <summary>
    ///  Set or get the ES_OFERTA property.
    /// </summary>
    
		public string ES_OFERTA { get; set; }
 
	/// <summary>
    ///  Set or get the TITULO property.
    /// </summary>
    
		public string TITULO { get; set; }
 
	/// <summary>
    ///  Set or get the TEXTO_OF property.
    /// </summary>
    
		public string TEXTO_OF { get; set; }
 
	/// <summary>
    ///  Set or get the TARIDES property.
    /// </summary>
    
		public string TARIDES { get; set; }
 
	/// <summary>
    ///  Set or get the ONE_WAY property.
    /// </summary>
    
		public Int16? ONE_WAY { get; set; }
 
	/// <summary>
    ///  Set or get the COND_TAR property.
    /// </summary>
    
		public string COND_TAR { get; set; }
 
	/// <summary>
    ///  Set or get the SOLORESE property.
    /// </summary>
    
		public byte? SOLORESE { get; set; }
 
	/// <summary>
    ///  Set or get the NOMEJOR property.
    /// </summary>
    
		public byte? NOMEJOR { get; set; }
 
	/// <summary>
    ///  Set or get the CTR_COTIZA_NO_EDI property.
    /// </summary>
    
		public byte? CTR_COTIZA_NO_EDI { get; set; }
 
	/// <summary>
    ///  Set or get the FCOBRO property.
    /// </summary>
    
		public byte? FCOBRO { get; set; }
 
	/// <summary>
    ///  Set or get the USA_TARIFAPORHORAS property.
    /// </summary>
    
		public byte? USA_TARIFAPORHORAS { get; set; }
 
	/// <summary>
    ///  Set or get the HORAS_PREACUM property.
    /// </summary>
    
		public byte? HORAS_PREACUM { get; set; }
 
	/// <summary>
    ///  Set or get the MEDIODIA property.
    /// </summary>
    
		public byte? MEDIODIA { get; set; }
 
	/// <summary>
    ///  Set or get the HORAS_DEF property.
    /// </summary>
    
		public byte? HORAS_DEF { get; set; }
 
	/// <summary>
    ///  Set or get the ANUAL property.
    /// </summary>
    
		public byte? ANUAL { get; set; }
 
	/// <summary>
    ///  Set or get the CORPORATIVA property.
    /// </summary>
    
		public byte? CORPORATIVA { get; set; }
 
	/// <summary>
    ///  Set or get the SERV_SINHORAS property.
    /// </summary>
    
		public byte? SERV_SINHORAS { get; set; }
 
	/// <summary>
    ///  Set or get the NO_TENER_ENCUENTA_DIETAS property.
    /// </summary>
    
		public byte? NO_TENER_ENCUENTA_DIETAS { get; set; }
 
	/// <summary>
    ///  Set or get the NOPUBLICARWEB property.
    /// </summary>
    
		public byte? NOPUBLICARWEB { get; set; }
 
	/// <summary>
    ///  Set or get the ORDENWEB property.
    /// </summary>
    
		public byte? ORDENWEB { get; set; }
 
	/// <summary>
    ///  Set or get the ID_REG property.
    /// </summary>
    
		public Int32? ID_REG { get; set; }
 
	/// <summary>
    ///  Set or get the RESTA_TIEMPO property.
    /// </summary>
    
		public Decimal? RESTA_TIEMPO { get; set; }
 
	/// <summary>
    ///  Set or get the GESTION_UFS property.
    /// </summary>
    
		public byte? GESTION_UFS { get; set; }
 
	/// <summary>
    ///  Set or get the NO_REPLICAR property.
    /// </summary>
    
		public byte? NO_REPLICAR { get; set; }
 
	/// <summary>
    ///  Set or get the PRIORIDAD property.
    /// </summary>
    
		public byte? PRIORIDAD { get; set; }
 
	/// <summary>
    ///  Set or get the IVA_INCLUIDO property.
    /// </summary>
    
		public byte? IVA_INCLUIDO { get; set; }
 
	/// <summary>
    ///  Set or get the OPERADORES property.
    /// </summary>
    
		public byte? OPERADORES { get; set; }
 
	/// <summary>
    ///  Set or get the COBRO_ACT property.
    /// </summary>
    
		public byte? COBRO_ACT { get; set; }
 
	/// <summary>
    ///  Set or get the COBRO_A property.
    /// </summary>
    
		public byte? COBRO_A { get; set; }
 
	/// <summary>
    ///  Set or get the HORAS_TRAMOS_VAR property.
    /// </summary>
    
		public byte? HORAS_TRAMOS_VAR { get; set; }
 
	/// <summary>
    ///  Set or get the FBAJA_NT property.
    /// </summary>
    
		public DateTime? FBAJA_NT { get; set; }
 
	/// <summary>
    ///  Set or get the BONO_PREPAGO property.
    /// </summary>
    
		public byte? BONO_PREPAGO { get; set; }
 
	/// <summary>
    ///  Set or get the COD_PROMO property.
    /// </summary>
    
		public string COD_PROMO { get; set; }
 
	/// <summary>
    ///  Set or get the OBLIGA_COMI property.
    /// </summary>
    
		public byte? OBLIGA_COMI { get; set; }
 
	/// <summary>
    ///  Set or get the ORIGEN_TARI property.
    /// </summary>
    
		public Int32? ORIGEN_TARI { get; set; }
 
	/// <summary>
    ///  Set or get the TRATAR_FINSEMANA property.
    /// </summary>
    
		public byte? TRATAR_FINSEMANA { get; set; }
 
	/// <summary>
    ///  Set or get the NO_AEROPUERTO property.
    /// </summary>
    
		public byte? NO_AEROPUERTO { get; set; }
 
	/// <summary>
    ///  Set or get the NO_DOWNTOWN property.
    /// </summary>
    
		public byte? NO_DOWNTOWN { get; set; }
 
	/// <summary>
    ///  Set or get the DESDEO1 property.
    /// </summary>
    
		public DateTime? DESDEO1 { get; set; }
 
	/// <summary>
    ///  Set or get the HASTAO1 property.
    /// </summary>
    
		public DateTime? HASTAO1 { get; set; }
 
	/// <summary>
    ///  Set or get the DESDEO2 property.
    /// </summary>
    
		public DateTime? DESDEO2 { get; set; }
 
	/// <summary>
    ///  Set or get the HASTAO2 property.
    /// </summary>
    
		public DateTime? HASTAO2 { get; set; }
 
	/// <summary>
    ///  Set or get the DESDEO3 property.
    /// </summary>
    
		public DateTime? DESDEO3 { get; set; }
 
	/// <summary>
    ///  Set or get the HASTAO3 property.
    /// </summary>
    
		public DateTime? HASTAO3 { get; set; }
 
	/// <summary>
    ///  Set or get the NAMEXLS property.
    /// </summary>
    
		public string NAMEXLS { get; set; }
 
	/// <summary>
    ///  Set or get the ULT_LOAD property.
    /// </summary>
    
		public string ULT_LOAD { get; set; }
 
	/// <summary>
    ///  Set or get the USU_LOAD property.
    /// </summary>
    
		public string USU_LOAD { get; set; }
 
	/// <summary>
    ///  Set or get the CONCEPTO_HE property.
    /// </summary>
    
		public Int32? CONCEPTO_HE { get; set; }
 
	/// <summary>
    ///  Set or get the HORAS_TOPE property.
    /// </summary>
    
		public byte? HORAS_TOPE { get; set; }
 
	/// <summary>
    ///  Set or get the HORAS_TASOC property.
    /// </summary>
    
		public Int32? HORAS_TASOC { get; set; }
 
	/// <summary>
    ///  Set or get the TARIFA_ASOC property.
    /// </summary>
    
		public string TARIFA_ASOC { get; set; }
 
	/// <summary>
    ///  Set or get the OCULTAPRECIOS property.
    /// </summary>
    
		public byte? OCULTAPRECIOS { get; set; }
 
	/// <summary>
    ///  Set or get the RET_DESDE property.
    /// </summary>
    
		public DateTime? RET_DESDE { get; set; }
 
	/// <summary>
    ///  Set or get the RET_HASTA property.
    /// </summary>
    
		public DateTime? RET_HASTA { get; set; }
 
	/// <summary>
    ///  Set or get the RET_DESDEO property.
    /// </summary>
    
		public DateTime? RET_DESDEO { get; set; }
 
	/// <summary>
    ///  Set or get the RET_HASTAO property.
    /// </summary>
    
		public DateTime? RET_HASTAO { get; set; }
 
	/// <summary>
    ///  Set or get the RET_DESDEO1 property.
    /// </summary>
    
		public DateTime? RET_DESDEO1 { get; set; }
 
	/// <summary>
    ///  Set or get the RET_HASTAO1 property.
    /// </summary>
    
		public DateTime? RET_HASTAO1 { get; set; }
 
	/// <summary>
    ///  Set or get the RET_DESDEO2 property.
    /// </summary>
    
		public DateTime? RET_DESDEO2 { get; set; }
 
	/// <summary>
    ///  Set or get the RET_HASTAO2 property.
    /// </summary>
    
		public DateTime? RET_HASTAO2 { get; set; }
 
	/// <summary>
    ///  Set or get the RET_DESDEO3 property.
    /// </summary>
    
		public DateTime? RET_DESDEO3 { get; set; }
 
	/// <summary>
    ///  Set or get the RET_HASTAO3 property.
    /// </summary>
    
		public DateTime? RET_HASTAO3 { get; set; }
 
	/// <summary>
    ///  Set or get the DTO_WS property.
    /// </summary>
    
		public Decimal? DTO_WS { get; set; }
 
	/// <summary>
    ///  Set or get the EN_WEB_DEME_NT property.
    /// </summary>
    
		public byte? EN_WEB_DEME_NT { get; set; }
 
	/// <summary>
    ///  Set or get the FSEM_DDE_TARI property.
    /// </summary>
    
		public byte? FSEM_DDE_TARI { get; set; }
 
	/// <summary>
    ///  Set or get the FSEM_DA_TARI property.
    /// </summary>
    
		public byte? FSEM_DA_TARI { get; set; }
 
	/// <summary>
    ///  Set or get the FSEM_HDE_TARI property.
    /// </summary>
    
		public TimeSpan? FSEM_HDE_TARI { get; set; }
 
	/// <summary>
    ///  Set or get the FSEM_HA_TARI property.
    /// </summary>
    
		public TimeSpan? FSEM_HA_TARI { get; set; }
 
	/// <summary>
    ///  Set or get the FSEM_HORASMAX property.
    /// </summary>
    
		public byte? FSEM_HORASMAX { get; set; }
 
	/// <summary>
    ///  Set or get the FSEM_KM_EXTRA property.
    /// </summary>
    
		public Int32? FSEM_KM_EXTRA { get; set; }
 
	/// <summary>
    ///  Set or get the PERMITE_CIERRE_MISMO_DIA property.
    /// </summary>
    
		public byte? PERMITE_CIERRE_MISMO_DIA { get; set; }
	}
}
