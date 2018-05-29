using System;
using KarveDapper.Extensions;
using KarveDataServices.DataTransferObject;

namespace DataAccessLayer.DataObjects
{
    /// <summary>
    /// Represents a VEHICULO1.
    /// NOTE: This class is generated from a T4 template - you should not modify it manually.
    /// </summary>
    [Table("VEHICULO1")]
    public class VEHICULO1 
	{
	
	/// <summary>
    ///  Set or get the CODIINT property.
    /// </summary>
       
        [PrimaryKey]
        [Key]
        [FieldSize("7")]
        public string CODIINT { get; set; }
 
	/// <summary>
    ///  Set or get the MATRICULA property.
    /// </summary>
    
		public string MATRICULA { get; set; }
 
	/// <summary>
    ///  Set or get the MARCA property.
    /// </summary>
    
		public string MARCA { get; set; }
 
	/// <summary>
    ///  Set or get the MODELO property.
    /// </summary>
    
		public string MODELO { get; set; }
 
	/// <summary>
    ///  Set or get the GRUPO property.
    /// </summary>
    
		public string GRUPO { get; set; }
 
	/// <summary>
    ///  Set or get the ACTIVIDAD property.
    /// </summary>
    
		public string ACTIVIDAD { get; set; }
 
	/// <summary>
    ///  Set or get the USUARIO property.
    /// </summary>
    
		public string USUARIO { get; set; }
 
	/// <summary>
    ///  Set or get the COLOR property.
    /// </summary>
    
		public string COLOR { get; set; }
 
	/// <summary>
    ///  Set or get the MAR property.
    /// </summary>
    
		public string MAR { get; set; }
 
	/// <summary>
    ///  Set or get the MO1 property.
    /// </summary>
    
		public string MO1 { get; set; }
 
	/// <summary>
    ///  Set or get the MO2 property.
    /// </summary>
    
		public string MO2 { get; set; }
 
	/// <summary>
    ///  Set or get the CIALEAS property.
    /// </summary>
    
		public string CIALEAS { get; set; }
 
	/// <summary>
    ///  Set or get the CIASEGU property.
    /// </summary>
    
		public string CIASEGU { get; set; }
 
	/// <summary>
    ///  Set or get the TIPOSEGU property.
    /// </summary>
    
		public string TIPOSEGU { get; set; }
 
	/// <summary>
    ///  Set or get the OBS1 property.
    /// </summary>
    
		public string OBS1 { get; set; }
 
	/// <summary>
    ///  Set or get the COMPRAFRA property.
    /// </summary>
    
		public string COMPRAFRA { get; set; }
 
	/// <summary>
    ///  Set or get the PROVEEDOR property.
    /// </summary>
    
		public string PROVEEDOR { get; set; }
 
	/// <summary>
    ///  Set or get the FINANCIA property.
    /// </summary>
    
		public string FINANCIA { get; set; }
 
	/// <summary>
    ///  Set or get the PROPIE property.
    /// </summary>
    
		public string PROPIE { get; set; }
 
	/// <summary>
    ///  Set or get the CIAADA property.
    /// </summary>
    
		public string CIAADA { get; set; }
 
	/// <summary>
    ///  Set or get the SUBLICEN property.
    /// </summary>
    
		public string SUBLICEN { get; set; }
 
	/// <summary>
    ///  Set or get the COINMO property.
    /// </summary>
    
		public string COINMO { get; set; }
 
	/// <summary>
    ///  Set or get the BASTIDOR property.
    /// </summary>
    
		public string BASTIDOR { get; set; }
 
	/// <summary>
    ///  Set or get the ULTMODI property.
    /// </summary>
    
		public string ULTMODI { get; set; }
 
	/// <summary>
    ///  Set or get the CLIENTE property.
    /// </summary>
    
		public string CLIENTE { get; set; }
 
	/// <summary>
    ///  Set or get the FECHADEV property.
    /// </summary>
    
		public DateTime? FECHADEV { get; set; }
 
	/// <summary>
    ///  Set or get the SITUACION property.
    /// </summary>
    
		public byte? SITUACION { get; set; }
 
	/// <summary>
    ///  Set or get the AGENTE property.
    /// </summary>
    
		public string AGENTE { get; set; }
 
	/// <summary>
    ///  Set or get the OPCIONES property.
    /// </summary>
    
		public string OPCIONES { get; set; }
 
	/// <summary>
    ///  Set or get the UBICA property.
    /// </summary>
    
		public string UBICA { get; set; }
 
	/// <summary>
    ///  Set or get the FFRA property.
    /// </summary>
    
		public DateTime? FFRA { get; set; }
 
	/// <summary>
    ///  Set or get the FTRANS property.
    /// </summary>
    
		public DateTime? FTRANS { get; set; }
 
	/// <summary>
    ///  Set or get the IMPUESTO property.
    /// </summary>
    
		public Decimal? IMPUESTO { get; set; }
 
	/// <summary>
    ///  Set or get the FPAGO1 property.
    /// </summary>
    
		public DateTime? FPAGO1 { get; set; }
 
	/// <summary>
    ///  Set or get the FPAGO2 property.
    /// </summary>
    
		public DateTime? FPAGO2 { get; set; }
 
	/// <summary>
    ///  Set or get the FPAGO3 property.
    /// </summary>
    
		public DateTime? FPAGO3 { get; set; }
 
	/// <summary>
    ///  Set or get the FPAGO4 property.
    /// </summary>
    
		public DateTime? FPAGO4 { get; set; }
 
	/// <summary>
    ///  Set or get the PAGADO1 property.
    /// </summary>
    
		public byte? PAGADO1 { get; set; }
 
	/// <summary>
    ///  Set or get the PAGADO2 property.
    /// </summary>
    
		public byte? PAGADO2 { get; set; }
 
	/// <summary>
    ///  Set or get the PAGADO3 property.
    /// </summary>
    
		public byte? PAGADO3 { get; set; }
 
	/// <summary>
    ///  Set or get the PAGADO4 property.
    /// </summary>
    
		public byte? PAGADO4 { get; set; }
 
	/// <summary>
    ///  Set or get the MONEDA property.
    /// </summary>
    
		public string MONEDA { get; set; }
 
	/// <summary>
    ///  Set or get the IMPSEG1 property.
    /// </summary>
    
		public Decimal? IMPSEG1 { get; set; }
 
	/// <summary>
    ///  Set or get the IMPSEG2 property.
    /// </summary>
    
		public Decimal? IMPSEG2 { get; set; }
 
	/// <summary>
    ///  Set or get the IMPSEG3 property.
    /// </summary>
    
		public Decimal? IMPSEG3 { get; set; }
 
	/// <summary>
    ///  Set or get the IMPSEG4 property.
    /// </summary>
    
		public Decimal? IMPSEG4 { get; set; }
 
	/// <summary>
    ///  Set or get the LOPCIONES property.
    /// </summary>
    
		public string LOPCIONES { get; set; }
 
	/// <summary>
    ///  Set or get the LEXTRAS property.
    /// </summary>
    
		public string LEXTRAS { get; set; }
 
	/// <summary>
    ///  Set or get the ERRORES property.
    /// </summary>
    
		public Int32? ERRORES { get; set; }
 
	/// <summary>
    ///  Set or get the ULT_TRANS property.
    /// </summary>
    
		public string ULT_TRANS { get; set; }
 
	/// <summary>
    ///  Set or get the CUOTA property.
    /// </summary>
    
		public Decimal? CUOTA { get; set; }
 
	/// <summary>
    ///  Set or get the RECIBO_V1 property.
    /// </summary>
    
	//	public Boolean? RECIBO_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the NUMPLAZAS property.
    /// </summary>
    
		public byte? NUMPLAZAS { get; set; }
 
	/// <summary>
    ///  Set or get the VERSION property.
    /// </summary>
    
		public string VERSION { get; set; }
 
	/// <summary>
    ///  Set or get the CILINDRADA property.
    /// </summary>
    
		public string CILINDRADA { get; set; }
 
	/// <summary>
    ///  Set or get the TIPOCOLOR property.
    /// </summary>
    
		public string TIPOCOLOR { get; set; }
 
	/// <summary>
    ///  Set or get the NUMPUERTAS property.
    /// </summary>
    
		public string NUMPUERTAS { get; set; }
 
	/// <summary>
    ///  Set or get the VENGO property.
    /// </summary>
    
		public string VENGO { get; set; }
 
	/// <summary>
    ///  Set or get the RUTAFOTO property.
    /// </summary>
    
		public string RUTAFOTO { get; set; }
 
	/// <summary>
    ///  Set or get the METROS_CUB property.
    /// </summary>
    
		public Decimal? METROS_CUB { get; set; }
 
	/// <summary>
    ///  Set or get the MEDIDAS property.
    /// </summary>
    
		public string MEDIDAS { get; set; }
 
	/// <summary>
    ///  Set or get the FINGARAN property.
    /// </summary>
    
		public DateTime? FINGARAN { get; set; }
 
	/// <summary>
    ///  Set or get the DANOS property.
    /// </summary>
    
		public string DANOS { get; set; }
 
	/// <summary>
    ///  Set or get the PROD_VENTA property.
    /// </summary>
    
		public string PROD_VENTA { get; set; }
 
	/// <summary>
    ///  Set or get the PVP property.
    /// </summary>
    
		public Double? PVP { get; set; }
 
	/// <summary>
    ///  Set or get the MANTE_DEFECTO_V1 property.
    /// </summary>
    
		public Int32? MANTE_DEFECTO_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the CIASEGU2 property.
    /// </summary>
    
		public string CIASEGU2 { get; set; }
 
	/// <summary>
    ///  Set or get the AGENTE2 property.
    /// </summary>
    
		public string AGENTE2 { get; set; }
 
	/// <summary>
    ///  Set or get the CIAADA3 property.
    /// </summary>
    
		public string CIAADA3 { get; set; }
 
	/// <summary>
    ///  Set or get the PSERV_FINI_V1 property.
    /// </summary>
    
		public DateTime? PSERV_FINI_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the PSERV_FFIN_V1 property.
    /// </summary>
    
		public DateTime? PSERV_FFIN_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the GAEXT_FINI_V1 property.
    /// </summary>
    
		public DateTime? GAEXT_FINI_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the GAEXT_FFIN_V1 property.
    /// </summary>
    
		public DateTime? GAEXT_FFIN_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the GAEXT_KM_V1 property.
    /// </summary>
    
		public Int32? GAEXT_KM_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the CLIPROPIE property.
    /// </summary>
    
		public string CLIPROPIE { get; set; }
 
	/// <summary>
    ///  Set or get the KMRESTA property.
    /// </summary>
    
		public Double? KMRESTA { get; set; }
 
	/// <summary>
    ///  Set or get the CIAADA2 property.
    /// </summary>
    
		public string CIAADA2 { get; set; }
 
	/// <summary>
    ///  Set or get the ADA2 property.
    /// </summary>
    
		public string ADA2 { get; set; }
 
	/// <summary>
    ///  Set or get the VTOADA2 property.
    /// </summary>
    
		public DateTime? VTOADA2 { get; set; }
 
	/// <summary>
    ///  Set or get the IMPADA2 property.
    /// </summary>
    
		public Decimal? IMPADA2 { get; set; }
 
	/// <summary>
    ///  Set or get the IMP_CIRC_V1 property.
    /// </summary>
    
		public Single? IMP_CIRC_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the FEC_CIRC_V1 property.
    /// </summary>
    
		public DateTime? FEC_CIRC_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the RUTACROQUIS property.
    /// </summary>
    
		public string RUTACROQUIS { get; set; }
 
	/// <summary>
    ///  Set or get the COSTEANUAL property.
    /// </summary>
    
		public Double? COSTEANUAL { get; set; }
 
	/// <summary>
    ///  Set or get the ZONA_VH property.
    /// </summary>
    
		public string ZONA_VH { get; set; }
 
	/// <summary>
    ///  Set or get the NUM_MOTOR property.
    /// </summary>
    
		public string NUM_MOTOR { get; set; }
 
	/// <summary>
    ///  Set or get the RUEDAS property.
    /// </summary>
    
		public string RUEDAS { get; set; }
 
	/// <summary>
    ///  Set or get the FFABRI property.
    /// </summary>
    
		public DateTime? FFABRI { get; set; }
 
	/// <summary>
    ///  Set or get the OBSERVA property.
    /// </summary>
    
		public string OBSERVA { get; set; }
 
	/// <summary>
    ///  Set or get the FBAJADEF property.
    /// </summary>
    
		public DateTime? FBAJADEF { get; set; }
 
	/// <summary>
    ///  Set or get the BONIFICA property.
    /// </summary>
    
		public Decimal? BONIFICA { get; set; }
 
	/// <summary>
    ///  Set or get the ANOMODELO property.
    /// </summary>
    
		public string ANOMODELO { get; set; }
 
	/// <summary>
    ///  Set or get the POTENCIA property.
    /// </summary>
    
		public string POTENCIA { get; set; }
 
	/// <summary>
    ///  Set or get the TEL_VEHI property.
    /// </summary>
    
		public string TEL_VEHI { get; set; }
 
	/// <summary>
    ///  Set or get the MOTOR property.
    /// </summary>
    
		public string MOTOR { get; set; }
 
	/// <summary>
    ///  Set or get the DIST_EJES property.
    /// </summary>
    
		public string DIST_EJES { get; set; }
 
	/// <summary>
    ///  Set or get the TARTRANS property.
    /// </summary>
    
		public string TARTRANS { get; set; }
 
	/// <summary>
    ///  Set or get the FURGO_CARGA property.
    /// </summary>
    
		public byte? FURGO_CARGA { get; set; }
 
	/// <summary>
    ///  Set or get the PLAT_ELEVADORA property.
    /// </summary>
    
		public byte? PLAT_ELEVADORA { get; set; }
 
	/// <summary>
    ///  Set or get the TOLDO property.
    /// </summary>
    
		public byte? TOLDO { get; set; }
 
	/// <summary>
    ///  Set or get the TECHOSOBREELEVA property.
    /// </summary>
    
		public byte? TECHOSOBREELEVA { get; set; }
 
	/// <summary>
    ///  Set or get the METROS_PLAT property.
    /// </summary>
    
		public byte? METROS_PLAT { get; set; }
 
	/// <summary>
    ///  Set or get the AVISO property.
    /// </summary>
    
		public string AVISO { get; set; }
 
	/// <summary>
    ///  Set or get the CAJON property.
    /// </summary>
    
		public byte? CAJON { get; set; }
 
	/// <summary>
    ///  Set or get the VTO_ATP property.
    /// </summary>
    
		public DateTime? VTO_ATP { get; set; }
 
	/// <summary>
    ///  Set or get the COD_BATERIA property.
    /// </summary>
    
		public string COD_BATERIA { get; set; }
 
	/// <summary>
    ///  Set or get the SEGURO_EN_VEHI property.
    /// </summary>
    
		public byte? SEGURO_EN_VEHI { get; set; }
 
	/// <summary>
    ///  Set or get the DIRVEHI property.
    /// </summary>
    
		public string DIRVEHI { get; set; }
 
	/// <summary>
    ///  Set or get the FREVITACO property.
    /// </summary>
    
		public DateTime? FREVITACO { get; set; }
 
	/// <summary>
    ///  Set or get the DESCRIP property.
    /// </summary>
    
		public string DESCRIP { get; set; }
 
	/// <summary>
    ///  Set or get the ALTURA_TOTAL property.
    /// </summary>
    
		public string ALTURA_TOTAL { get; set; }
 
	/// <summary>
    ///  Set or get the ANCHO_TOTAL property.
    /// </summary>
    
		public string ANCHO_TOTAL { get; set; }
 
	/// <summary>
    ///  Set or get the VIA_ANTPOST property.
    /// </summary>
    
		public string VIA_ANTPOST { get; set; }
 
	/// <summary>
    ///  Set or get the LONGI_TOTAL property.
    /// </summary>
    
		public string LONGI_TOTAL { get; set; }
 
	/// <summary>
    ///  Set or get the VOLADIZ_POST property.
    /// </summary>
    
		public string VOLADIZ_POST { get; set; }
 
	/// <summary>
    ///  Set or get the MANTECONTRA property.
    /// </summary>
    
		public string MANTECONTRA { get; set; }
 
	/// <summary>
    ///  Set or get the COORDGPS property.
    /// </summary>
    
		public string COORDGPS { get; set; }
 
	/// <summary>
    ///  Set or get the NUEVA property.
    /// </summary>
    
		public byte? NUEVA { get; set; }
 
	/// <summary>
    ///  Set or get the DIASMAXALQ property.
    /// </summary>
    
		public Int32? DIASMAXALQ { get; set; }
 
	/// <summary>
    ///  Set or get the AGENTE_VEHI property.
    /// </summary>
    
		public string AGENTE_VEHI { get; set; }
 
	/// <summary>
    ///  Set or get the TAPICERIA property.
    /// </summary>
    
		public string TAPICERIA { get; set; }
 
	/// <summary>
    ///  Set or get the FPAGOSEGURO property.
    /// </summary>
    
		public byte? FPAGOSEGURO { get; set; }
 
	/// <summary>
    ///  Set or get the PFF property.
    /// </summary>
    
		public Decimal? PFF { get; set; }
 
	/// <summary>
    ///  Set or get the PFF_OPCIONES property.
    /// </summary>
    
		public Decimal? PFF_OPCIONES { get; set; }
 
	/// <summary>
    ///  Set or get the IMPORTE_FINANCIADO property.
    /// </summary>
    
		public Decimal? IMPORTE_FINANCIADO { get; set; }
 
	/// <summary>
    ///  Set or get the REF property.
    /// </summary>
    
		public string REF { get; set; }
 
	/// <summary>
    ///  Set or get the ULT_ATP property.
    /// </summary>
    
		public DateTime? ULT_ATP { get; set; }
 
	/// <summary>
    ///  Set or get the OBS_ATP property.
    /// </summary>
    
		public string OBS_ATP { get; set; }
 
	/// <summary>
    ///  Set or get the ULT_TAC property.
    /// </summary>
    
		public DateTime? ULT_TAC { get; set; }
 
	/// <summary>
    ///  Set or get the OBS_TAC property.
    /// </summary>
    
		public string OBS_TAC { get; set; }
 
	/// <summary>
    ///  Set or get the FURGO_TAMANO property.
    /// </summary>
    
		public byte? FURGO_TAMANO { get; set; }
 
	/// <summary>
    ///  Set or get the NOPUBLICARWEB property.
    /// </summary>
    
		public byte? NOPUBLICARWEB { get; set; }
 
	/// <summary>
    ///  Set or get the ORDENWEB property.
    /// </summary>
    
		public Int32? ORDENWEB { get; set; }
 
	/// <summary>
    ///  Set or get the NOTACAMBIO_HORAS property.
    /// </summary>
    
		public string NOTACAMBIO_HORAS { get; set; }
 
	/// <summary>
    ///  Set or get the FCAMBIO property.
    /// </summary>
    
		public DateTime? FCAMBIO { get; set; }
 
	/// <summary>
    ///  Set or get the ID_TSER property.
    /// </summary>
    
		public Int32? ID_TSER { get; set; }
 
	/// <summary>
    ///  Set or get the ID_DES property.
    /// </summary>
    
		public Int32? ID_DES { get; set; }
 
	/// <summary>
    ///  Set or get the ID_NOM property.
    /// </summary>
    
		public Int32? ID_NOM { get; set; }
 
	/// <summary>
    ///  Set or get the ES_SUBALQUILER property.
    /// </summary>
    
		public byte? ES_SUBALQUILER { get; set; }
 
	/// <summary>
    ///  Set or get the SUPLIDO property.
    /// </summary>
    
		public Decimal? SUPLIDO { get; set; }
 
	/// <summary>
    ///  Set or get the IVAALQ property.
    /// </summary>
    
		public Decimal? IVAALQ { get; set; }
 
	/// <summary>
    ///  Set or get the CUOTAMESUNO property.
    /// </summary>
    
		public byte? CUOTAMESUNO { get; set; }
 
	/// <summary>
    ///  Set or get the SAM property.
    /// </summary>
    
		public string SAM { get; set; }
 
	/// <summary>
    ///  Set or get the TIPOTRANS_SP property.
    /// </summary>
    
		public byte? TIPOTRANS_SP { get; set; }
 
	/// <summary>
    ///  Set or get the TIPOTRANS_MP property.
    /// </summary>
    
		public byte? TIPOTRANS_MP { get; set; }
 
	/// <summary>
    ///  Set or get the TIPOTRANS_NAC property.
    /// </summary>
    
		public byte? TIPOTRANS_NAC { get; set; }
 
	/// <summary>
    ///  Set or get the TIPOTRANS_INT property.
    /// </summary>
    
		public byte? TIPOTRANS_INT { get; set; }
 
	/// <summary>
    ///  Set or get the TIPOTRANS_REP property.
    /// </summary>
    
		public byte? TIPOTRANS_REP { get; set; }
 
	/// <summary>
    ///  Set or get the TIPOTRANS_NOREP property.
    /// </summary>
    
		public byte? TIPOTRANS_NOREP { get; set; }
 
	/// <summary>
    ///  Set or get the ACCESORIOS_VH property.
    /// </summary>
    
		public string ACCESORIOS_VH { get; set; }
 
	/// <summary>
    ///  Set or get the VERSION_VH property.
    /// </summary>
    
		public string VERSION_VH { get; set; }
 
	/// <summary>
    ///  Set or get the SEGURO_LUNAS property.
    /// </summary>
    
		public byte? SEGURO_LUNAS { get; set; }
 
	/// <summary>
    ///  Set or get the SEGURO_BAJA property.
    /// </summary>
    
		public DateTime? SEGURO_BAJA { get; set; }
 
	/// <summary>
    ///  Set or get the FENTPREV property.
    /// </summary>
    
		public DateTime? FENTPREV { get; set; }
 
	/// <summary>
    ///  Set or get the INCIDENCIAS_SEGU property.
    /// </summary>
    
		public string INCIDENCIAS_SEGU { get; set; }
 
	/// <summary>
    ///  Set or get the RISK_0 property.
    /// </summary>
    
		public byte? RISK_0 { get; set; }
 
	/// <summary>
    ///  Set or get the RISK_1 property.
    /// </summary>
    
		public byte? RISK_1 { get; set; }
 
	/// <summary>
    ///  Set or get the RISK_2 property.
    /// </summary>
    
		public byte? RISK_2 { get; set; }
 
	/// <summary>
    ///  Set or get the RISK_3 property.
    /// </summary>
    
		public byte? RISK_3 { get; set; }
 
	/// <summary>
    ///  Set or get the RISK_4 property.
    /// </summary>
    
		public byte? RISK_4 { get; set; }
 
	/// <summary>
    ///  Set or get the AVISO_CONFORMIDAD property.
    /// </summary>
    
		public DateTime? AVISO_CONFORMIDAD { get; set; }
 
	/// <summary>
    ///  Set or get the TIPOMERCA property.
    /// </summary>
    
		public Int32? TIPOMERCA { get; set; }
 
	/// <summary>
    ///  Set or get the NUMCOMISION property.
    /// </summary>
    
		public string NUMCOMISION { get; set; }
 
	/// <summary>
    ///  Set or get the CONCESIONARIO property.
    /// </summary>
    
		public string CONCESIONARIO { get; set; }
 
	/// <summary>
    ///  Set or get the ESVEHICULO property.
    /// </summary>
    
		public byte? ESVEHICULO { get; set; }
 
	/// <summary>
    ///  Set or get the CLI_DELEGA property.
    /// </summary>
    
		public string CLI_DELEGA { get; set; }
 
	/// <summary>
    ///  Set or get the COMEN_SEGU property.
    /// </summary>
    
		public string COMEN_SEGU { get; set; }
 
	/// <summary>
    ///  Set or get the FCOMPROMISO property.
    /// </summary>
    
		public DateTime? FCOMPROMISO { get; set; }
 
	/// <summary>
    ///  Set or get the SEGU_INTERNACIONAL property.
    /// </summary>
    
		public byte? SEGU_INTERNACIONAL { get; set; }
 
	/// <summary>
    ///  Set or get the SEGU_TODORIESGO property.
    /// </summary>
    
		public byte? SEGU_TODORIESGO { get; set; }
 
	/// <summary>
    ///  Set or get the ROTULADO property.
    /// </summary>
    
		public byte? ROTULADO { get; set; }
 
	/// <summary>
    ///  Set or get the VALOR_PARASEGURO property.
    /// </summary>
    
		public Decimal? VALOR_PARASEGURO { get; set; }
 
	/// <summary>
    ///  Set or get the SITUTMP property.
    /// </summary>
    
		public byte? SITUTMP { get; set; }
 
	/// <summary>
    ///  Set or get the PREC_CESION_CONCE property.
    /// </summary>
    
		public Decimal? PREC_CESION_CONCE { get; set; }
 
	/// <summary>
    ///  Set or get the MANTECADA property.
    /// </summary>
    
		public Int32? MANTECADA { get; set; }
 
	/// <summary>
    ///  Set or get the PREC_MANT_NUEVO property.
    /// </summary>
    
		public Decimal? PREC_MANT_NUEVO { get; set; }
 
	/// <summary>
    ///  Set or get the MARGEN_MANT_NUEVO property.
    /// </summary>
    
		public Decimal? MARGEN_MANT_NUEVO { get; set; }
 
	/// <summary>
    ///  Set or get the KMS_AMPLIA property.
    /// </summary>
    
		public Decimal? KMS_AMPLIA { get; set; }
 
	/// <summary>
    ///  Set or get the FEC_AMPLIA property.
    /// </summary>
    
		public DateTime? FEC_AMPLIA { get; set; }
 
	/// <summary>
    ///  Set or get the FEC_VNC_ACT property.
    /// </summary>
    
		public DateTime? FEC_VNC_ACT { get; set; }
 
	/// <summary>
    ///  Set or get the IMP_VR property.
    /// </summary>
    
		public Decimal? IMP_VR { get; set; }
 
	/// <summary>
    ///  Set or get the IMP_VNC_ACT property.
    /// </summary>
    
		public Decimal? IMP_VNC_ACT { get; set; }
 
	/// <summary>
    ///  Set or get the DURACION_PROLONGA property.
    /// </summary>
    
		public Int32? DURACION_PROLONGA { get; set; }
 
	/// <summary>
    ///  Set or get the INTERES_OFERTA property.
    /// </summary>
    
		public Decimal? INTERES_OFERTA { get; set; }
 
	/// <summary>
    ///  Set or get the FACTURANDO_CONCESIO property.
    /// </summary>
    
		public byte? FACTURANDO_CONCESIO { get; set; }
 
	/// <summary>
    ///  Set or get the UFACTURA_CONCESIO property.
    /// </summary>
    
		public string UFACTURA_CONCESIO { get; set; }
 
	/// <summary>
    ///  Set or get the IMP_CARGO_KM property.
    /// </summary>
    
		public Decimal? IMP_CARGO_KM { get; set; }
 
	/// <summary>
    ///  Set or get the IMP_ABONO_KM_0 property.
    /// </summary>
    
		public Decimal? IMP_ABONO_KM_0 { get; set; }
 
	/// <summary>
    ///  Set or get the IMP_ABONO_KM_1 property.
    /// </summary>
    
		public Decimal? IMP_ABONO_KM_1 { get; set; }
 
	/// <summary>
    ///  Set or get the ImpCircuCliente property.
    /// </summary>
    
		public byte? ImpCircuCliente { get; set; }
 
	/// <summary>
    ///  Set or get the AUM_DIFKM property.
    /// </summary>
    
		public Decimal? AUM_DIFKM { get; set; }
 
	/// <summary>
    ///  Set or get the FEC_ACEPTA property.
    /// </summary>
    
		public DateTime? FEC_ACEPTA { get; set; }
 
	/// <summary>
    ///  Set or get the IO_MAN property.
    /// </summary>
    
		public Decimal? IO_MAN { get; set; }
 
	/// <summary>
    ///  Set or get the MARGEN_AMP property.
    /// </summary>
    
		public Decimal? MARGEN_AMP { get; set; }
 
	/// <summary>
    ///  Set or get the APROBADO_AMP property.
    /// </summary>
    
		public byte? APROBADO_AMP { get; set; }
 
	/// <summary>
    ///  Set or get the CALCULO_TIR property.
    /// </summary>
    
		public Decimal? CALCULO_TIR { get; set; }
 
	/// <summary>
    ///  Set or get the CFO property.
    /// </summary>
    
		public Decimal? CFO { get; set; }
 
	/// <summary>
    ///  Set or get the OFERTA_AMPLIA property.
    /// </summary>
    
		public string OFERTA_AMPLIA { get; set; }
 
	/// <summary>
    ///  Set or get the CARPETA property.
    /// </summary>
    
		public string CARPETA { get; set; }
 
	/// <summary>
    ///  Set or get the PUB_WEB property.
    /// </summary>
    
		public byte? PUB_WEB { get; set; }
 
	/// <summary>
    ///  Set or get the REFRESCARWEB property.
    /// </summary>
    
		public byte? REFRESCARWEB { get; set; }
 
	/// <summary>
    ///  Set or get the BI_AMP property.
    /// </summary>
    
		public Decimal? BI_AMP { get; set; }
 
	/// <summary>
    ///  Set or get the SUPLIDO_AMP property.
    /// </summary>
    
		public Decimal? SUPLIDO_AMP { get; set; }
 
	/// <summary>
    ///  Set or get the TOTAL_AMP property.
    /// </summary>
    
		public Decimal? TOTAL_AMP { get; set; }
 
	/// <summary>
    ///  Set or get the TASA property.
    /// </summary>
    
		public Decimal? TASA { get; set; }
 
	/// <summary>
    ///  Set or get the CFO_MAN property.
    /// </summary>
    
		public Decimal? CFO_MAN { get; set; }
 
	/// <summary>
    ///  Set or get the FEC_APROBA_RISK property.
    /// </summary>
    
		public DateTime? FEC_APROBA_RISK { get; set; }
 
	/// <summary>
    ///  Set or get the HSTRABAJODIA property.
    /// </summary>
    
		public Decimal? HSTRABAJODIA { get; set; }
 
	/// <summary>
    ///  Set or get the CLI_DELEGA_V1 property.
    /// </summary>
    
		public string CLI_DELEGA_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the INTRO_VTA_V1 property.
    /// </summary>
    
		public byte? INTRO_VTA_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the PERMISO_CIRCULACION_VTA_V1 property.
    /// </summary>
    
		public byte? PERMISO_CIRCULACION_VTA_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the FICHA_TECNICA_VTA_V1 property.
    /// </summary>
    
		public byte? FICHA_TECNICA_VTA_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the ITV_CADUCADA_VTA_V1 property.
    /// </summary>
    
		public byte? ITV_CADUCADA_VTA_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the IMPUESTO_CIRCULACION_VTA_V1 property.
    /// </summary>
    
		public byte? IMPUESTO_CIRCULACION_VTA_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the SOLICITUD_TRANSMISION_VTA_V1 property.
    /// </summary>
    
		public byte? SOLICITUD_TRANSMISION_VTA_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the ATP_VTA_V1 property.
    /// </summary>
    
		public byte? ATP_VTA_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the ADR_VTA_V1 property.
    /// </summary>
    
		public byte? ADR_VTA_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the CUADERNO_MANTE_VTA_V1 property.
    /// </summary>
    
		public byte? CUADERNO_MANTE_VTA_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the LIBRO_INSTRUCCIONES_VTA_V1 property.
    /// </summary>
    
		public byte? LIBRO_INSTRUCCIONES_VTA_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the FOVENTA property.
    /// </summary>
    
		public DateTime? FOVENTA { get; set; }
 
	/// <summary>
    ///  Set or get the EXTERNO_RESTOS property.
    /// </summary>
    
		public byte? EXTERNO_RESTOS { get; set; }
 
	/// <summary>
    ///  Set or get the OBS_DOCU_VTA_V1 property.
    /// </summary>
    
		public string OBS_DOCU_VTA_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the OBS_COND_VTA_V1 property.
    /// </summary>
    
		public string OBS_COND_VTA_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the VR_VTA_V1 property.
    /// </summary>
    
		public Decimal? VR_VTA_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the VNC_VTA_V1 property.
    /// </summary>
    
		public Decimal? VNC_VTA_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the PREC_VTA_V1 property.
    /// </summary>
    
		public Decimal? PREC_VTA_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the PREWSTS_VTA_V1 property.
    /// </summary>
    
		public Decimal? PREWSTS_VTA_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the INDEMNIZA_VTA_V1 property.
    /// </summary>
    
		public Decimal? INDEMNIZA_VTA_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the RESTOS_VTA_V1 property.
    /// </summary>
    
		public Decimal? RESTOS_VTA_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the COSTE_CANCELA_VTA_V1 property.
    /// </summary>
    
		public Decimal? COSTE_CANCELA_VTA_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the COSTE_CANCELA_AJUSTADA_VTA_V1 property.
    /// </summary>
    
		public Decimal? COSTE_CANCELA_AJUSTADA_VTA_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the OPT_CANCELA_VTA_V1 property.
    /// </summary>
    
		public byte? OPT_CANCELA_VTA_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the SALDO_VTA_V1 property.
    /// </summary>
    
		public Decimal? SALDO_VTA_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the NUM_TARJETA_UTECARS property.
    /// </summary>
    
		public string NUM_TARJETA_UTECARS { get; set; }
 
	/// <summary>
    ///  Set or get the HORAS_FRIGO_V1 property.
    /// </summary>
    
		public Int32? HORAS_FRIGO_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the POBLA_IMP property.
    /// </summary>
    
		public string POBLA_IMP { get; set; }
 
	/// <summary>
    ///  Set or get the ZONA_IMP property.
    /// </summary>
    
		public string ZONA_IMP { get; set; }
 
	/// <summary>
    ///  Set or get the NO_REPARTO_PROVEE property.
    /// </summary>
    
		public byte? NO_REPARTO_PROVEE { get; set; }
 
	/// <summary>
    ///  Set or get the USU_MODI_VTA property.
    /// </summary>
    
		public string USU_MODI_VTA { get; set; }
 
	/// <summary>
    ///  Set or get the FEC_MODI_VTA property.
    /// </summary>
    
		public DateTime? FEC_MODI_VTA { get; set; }
 
	/// <summary>
    ///  Set or get the USU_RE_VTA property.
    /// </summary>
    
		public string USU_RE_VTA { get; set; }
 
	/// <summary>
    ///  Set or get the FEC_RE_VTA property.
    /// </summary>
    
		public DateTime? FEC_RE_VTA { get; set; }
 
	/// <summary>
    ///  Set or get the EQUIPOLI property.
    /// </summary>
    
		public byte? EQUIPOLI { get; set; }
 
	/// <summary>
    ///  Set or get the CTA_SEG_GTOSDIF property.
    /// </summary>
    
		public string CTA_SEG_GTOSDIF { get; set; }
 
	/// <summary>
    ///  Set or get the CTA_SEG_BANCO property.
    /// </summary>
    
		public string CTA_SEG_BANCO { get; set; }
 
	/// <summary>
    ///  Set or get the CTA_SEG_SEGURO property.
    /// </summary>
    
		public string CTA_SEG_SEGURO { get; set; }
 
	/// <summary>
    ///  Set or get the ASIENTO_SEGU property.
    /// </summary>
    
		public string ASIENTO_SEGU { get; set; }
 
	/// <summary>
    ///  Set or get the NO_ENVIAR_PERITO property.
    /// </summary>
    
		public byte? NO_ENVIAR_PERITO { get; set; }
 
	/// <summary>
    ///  Set or get the REF_CLI_MAQ property.
    /// </summary>
    
		public string REF_CLI_MAQ { get; set; }
 
	/// <summary>
    ///  Set or get the LP_MANTESAHORA property.
    /// </summary>
    
		public Int32? LP_MANTESAHORA { get; set; }
 
	/// <summary>
    ///  Set or get the RENDIMIENTO_VEHICULO_VH property.
    /// </summary>
    
		public string RENDIMIENTO_VEHICULO_VH { get; set; }
 
	/// <summary>
    ///  Set or get the RENDIMIENTO_CARRETERA_VH property.
    /// </summary>
    
		public string RENDIMIENTO_CARRETERA_VH { get; set; }
 
	/// <summary>
    ///  Set or get the RENDIMIENTO_CIUDAD_VH property.
    /// </summary>
    
		public string RENDIMIENTO_CIUDAD_VH { get; set; }
 
	/// <summary>
    ///  Set or get the CILINDROS_VH property.
    /// </summary>
    
		public string CILINDROS_VH { get; set; }
 
	/// <summary>
    ///  Set or get the RUTACERTI property.
    /// </summary>
    
		public string RUTACERTI { get; set; }
 
	/// <summary>
    ///  Set or get the RUTACONTRA property.
    /// </summary>
    
		public string RUTACONTRA { get; set; }
 
	/// <summary>
    ///  Set or get the RUTASEGU property.
    /// </summary>
    
		public string RUTASEGU { get; set; }
 
	/// <summary>
    ///  Set or get the FINANCIADO property.
    /// </summary>
    
		public byte? FINANCIADO { get; set; }
 
	/// <summary>
    ///  Set or get the POLIZASEGU property.
    /// </summary>
    
		public string POLIZASEGU { get; set; }
 
	/// <summary>
    ///  Set or get the CONTRAFINAN property.
    /// </summary>
    
		public string CONTRAFINAN { get; set; }
 
	/// <summary>
    ///  Set or get the BANCOFINAN property.
    /// </summary>
    
		public string BANCOFINAN { get; set; }
 
	/// <summary>
    ///  Set or get the CLIENTECOMPRA property.
    /// </summary>
    
		public string CLIENTECOMPRA { get; set; }
 
	/// <summary>
    ///  Set or get the VER_EN_PLANNING property.
    /// </summary>
    
		public byte? VER_EN_PLANNING { get; set; }
 
	/// <summary>
    ///  Set or get the REPARACIONES property.
    /// </summary>
    
		public string REPARACIONES { get; set; }
 
	/// <summary>
    ///  Set or get the SITUMAQ property.
    /// </summary>
    
		public string SITUMAQ { get; set; }
 
	/// <summary>
    ///  Set or get the DOCMAQ_CEE property.
    /// </summary>
    
		public string DOCMAQ_CEE { get; set; }
 
	/// <summary>
    ///  Set or get the COSTE_ENTREGA property.
    /// </summary>
    
		public Decimal? COSTE_ENTREGA { get; set; }
 
	/// <summary>
    ///  Set or get the VFINAL_PT property.
    /// </summary>
    
		public Decimal? VFINAL_PT { get; set; }
 
	/// <summary>
    ///  Set or get the PVP_PT property.
    /// </summary>
    
		public Decimal? PVP_PT { get; set; }
 
	/// <summary>
    ///  Set or get the FECHA_PT property.
    /// </summary>
    
		public DateTime? FECHA_PT { get; set; }
 
	/// <summary>
    ///  Set or get the FEC_SALIDA_TD property.
    /// </summary>
    
		public DateTime? FEC_SALIDA_TD { get; set; }
 
	/// <summary>
    ///  Set or get the FEC_LLEGA_TD property.
    /// </summary>
    
		public DateTime? FEC_LLEGA_TD { get; set; }
 
	/// <summary>
    ///  Set or get the COSTETRANSCOMP property.
    /// </summary>
    
		public Decimal? COSTETRANSCOMP { get; set; }
 
	/// <summary>
    ///  Set or get the COSTETRANSDEPO property.
    /// </summary>
    
		public Decimal? COSTETRANSDEPO { get; set; }
 
	/// <summary>
    ///  Set or get the COSTETRANSVTA property.
    /// </summary>
    
		public Decimal? COSTETRANSVTA { get; set; }
 
	/// <summary>
    ///  Set or get the SINBATERIA property.
    /// </summary>
    
		public byte? SINBATERIA { get; set; }
 
	/// <summary>
    ///  Set or get the ROBADO_V1 property.
    /// </summary>
    
		public byte? ROBADO_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the AMORTI property.
    /// </summary>
    
		public Decimal? AMORTI { get; set; }
 
	/// <summary>
    ///  Set or get the PROD_REVISION property.
    /// </summary>
    
		public string PROD_REVISION { get; set; }
 
	/// <summary>
    ///  Set or get the ESTADOBAT property.
    /// </summary>
    
		public string ESTADOBAT { get; set; }
 
	/// <summary>
    ///  Set or get the REALQUILADO_V1 property.
    /// </summary>
    
		public byte? REALQUILADO_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the COSTE_CANCELA_DEFINITIVA_VTA_V1 property.
    /// </summary>
    
		public Decimal? COSTE_CANCELA_DEFINITIVA_VTA_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the IMPASEGU property.
    /// </summary>
    
		public Decimal? IMPASEGU { get; set; }
 
	/// <summary>
    ///  Set or get the FOTOMAQ2 property.
    /// </summary>
    
		public Int32? FOTOMAQ2 { get; set; }
 
	/// <summary>
    ///  Set or get the REACONDICIONAMIENTO property.
    /// </summary>
    
		public Decimal? REACONDICIONAMIENTO { get; set; }
 
	/// <summary>
    ///  Set or get the DEPRECIACION property.
    /// </summary>
    
		public Decimal? DEPRECIACION { get; set; }
 
	/// <summary>
    ///  Set or get the TIR_V1 property.
    /// </summary>
    
		public Decimal? TIR_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the NPEDIDO_V1 property.
    /// </summary>
    
		public string NPEDIDO_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the AUTORIZA_FRA_VEHI_V1 property.
    /// </summary>
    
		public byte? AUTORIZA_FRA_VEHI_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the AUTORIZA_FRA_CARRO_V1 property.
    /// </summary>
    
		public byte? AUTORIZA_FRA_CARRO_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the PRECFINAL_MANUAL property.
    /// </summary>
    
		public byte? PRECFINAL_MANUAL { get; set; }
 
	/// <summary>
    ///  Set or get the PROD_DESPLAZAMIENTO property.
    /// </summary>
    
		public string PROD_DESPLAZAMIENTO { get; set; }
 
	/// <summary>
    ///  Set or get the MANTE_MBZC property.
    /// </summary>
    
		public Decimal? MANTE_MBZC { get; set; }
 
	/// <summary>
    ///  Set or get the FREVTERM property.
    /// </summary>
    
		public DateTime? FREVTERM { get; set; }
 
	/// <summary>
    ///  Set or get the ULT_TEMR property.
    /// </summary>
    
		public DateTime? ULT_TEMR { get; set; }
 
	/// <summary>
    ///  Set or get the OBS_TERM property.
    /// </summary>
    
		public string OBS_TERM { get; set; }
 
	/// <summary>
    ///  Set or get the TIPOTRANS_VHCTR property.
    /// </summary>
    
		public byte? TIPOTRANS_VHCTR { get; set; }
 
	/// <summary>
    ///  Set or get the PEDI_IMPORTA property.
    /// </summary>
    
		public string PEDI_IMPORTA { get; set; }
 
	/// <summary>
    ///  Set or get the PUERTO property.
    /// </summary>
    
		public string PUERTO { get; set; }
 
	/// <summary>
    ///  Set or get the INIGARAN property.
    /// </summary>
    
		public DateTime? INIGARAN { get; set; }
 
	/// <summary>
    ///  Set or get the CLIGARAN property.
    /// </summary>
    
		public string CLIGARAN { get; set; }
 
	/// <summary>
    ///  Set or get the PROVINCIA_VH property.
    /// </summary>
    
		public string PROVINCIA_VH { get; set; }
 
	/// <summary>
    ///  Set or get the PVP_DIVISA property.
    /// </summary>
    
		public Decimal? PVP_DIVISA { get; set; }
 
	/// <summary>
    ///  Set or get the CABILDO_VH property.
    /// </summary>
    
		public string CABILDO_VH { get; set; }
 
	/// <summary>
    ///  Set or get the TIPO_VTA_V1 property.
    /// </summary>
    
		public Int32? TIPO_VTA_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the COND_RECOMPRA_V1 property.
    /// </summary>
    
		public string COND_RECOMPRA_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the RECOMPRA_VEHI_V1 property.
    /// </summary>
    
		public byte? RECOMPRA_VEHI_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the EUROTAX_V1 property.
    /// </summary>
    
		public Decimal? EUROTAX_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the IMP_LIBROS_FFIN_V1 property.
    /// </summary>
    
		public Decimal? IMP_LIBROS_FFIN_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the IMP_CANCELA_ANT_V1 property.
    /// </summary>
    
		public Decimal? IMP_CANCELA_ANT_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the CARGO_ABONO_KMS_V1 property.
    /// </summary>
    
		public Decimal? CARGO_ABONO_KMS_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the DANOS_PERITADOS_V1 property.
    /// </summary>
    
		public Decimal? DANOS_PERITADOS_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the DANOS_FACTURADOS_V1 property.
    /// </summary>
    
		public Decimal? DANOS_FACTURADOS_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the BENEF_PERD_BRUTA_V1 property.
    /// </summary>
    
		public Decimal? BENEF_PERD_BRUTA_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the BENEF_PERD_NETA_V1 property.
    /// </summary>
    
		public Decimal? BENEF_PERD_NETA_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the VTOCOMPRAFRA_V1 property.
    /// </summary>
    
		public DateTime? VTOCOMPRAFRA_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the FRAVEN property.
    /// </summary>
    
		public string FRAVEN { get; set; }
 
	/// <summary>
    ///  Set or get the COMPRAFRA_BASE property.
    /// </summary>
    
		public Decimal? COMPRAFRA_BASE { get; set; }
 
	/// <summary>
    ///  Set or get the COMPRAFRA_CUOTA property.
    /// </summary>
    
		public Decimal? COMPRAFRA_CUOTA { get; set; }
 
	/// <summary>
    ///  Set or get the COMPRAFRA_TOTAL property.
    /// </summary>
    
		public Decimal? COMPRAFRA_TOTAL { get; set; }
 
	/// <summary>
    ///  Set or get the LOCALIZADOR_V1 property.
    /// </summary>
    
		public byte? LOCALIZADOR_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the TIPOSERVICIO_V1 property.
    /// </summary>
    
		public byte? TIPOSERVICIO_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the PVP_PROFE property.
    /// </summary>
    
		public Decimal? PVP_PROFE { get; set; }
 
	/// <summary>
    ///  Set or get the TIPO_ASSET_V1 property.
    /// </summary>
    
		public string TIPO_ASSET_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the TIPO_CAMS property.
    /// </summary>
    
		public string TIPO_CAMS { get; set; }
 
	/// <summary>
    ///  Set or get the OBS_SEGURO property.
    /// </summary>
    
		public string OBS_SEGURO { get; set; }
 
	/// <summary>
    ///  Set or get the FALTA_CABILDO property.
    /// </summary>
    
		public DateTime? FALTA_CABILDO { get; set; }
 
	/// <summary>
    ///  Set or get the FBAJA_CABILDO property.
    /// </summary>
    
		public DateTime? FBAJA_CABILDO { get; set; }
 
	/// <summary>
    ///  Set or get the VENDEDOR_VTA property.
    /// </summary>
    
		public string VENDEDOR_VTA { get; set; }
 
	/// <summary>
    ///  Set or get the IMPMATRI_VENTA property.
    /// </summary>
    
		public Decimal? IMPMATRI_VENTA { get; set; }
 
	/// <summary>
    ///  Set or get the CARROCERIA property.
    /// </summary>
    
		public Decimal? CARROCERIA { get; set; }
 
	/// <summary>
    ///  Set or get the CP property.
    /// </summary>
    
		public string CP { get; set; }
 
	/// <summary>
    ///  Set or get the CLIPOTEN property.
    /// </summary>
    
		public string CLIPOTEN { get; set; }
 
	/// <summary>
    ///  Set or get the CTA_FINAN_MBC property.
    /// </summary>
    
		public Decimal? CTA_FINAN_MBC { get; set; }
 
	/// <summary>
    ///  Set or get the USUARIO_WEB_V1 property.
    /// </summary>
    
		public string USUARIO_WEB_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the VTOSEGU1 property.
    /// </summary>
    
		public DateTime? VTOSEGU1 { get; set; }
 
	/// <summary>
    ///  Set or get the VTOSEGU2 property.
    /// </summary>
    
		public DateTime? VTOSEGU2 { get; set; }
 
	/// <summary>
    ///  Set or get the VTOSEGU3 property.
    /// </summary>
    
		public DateTime? VTOSEGU3 { get; set; }
 
	/// <summary>
    ///  Set or get the CONTRAMAN_DESDE property.
    /// </summary>
    
		public DateTime? CONTRAMAN_DESDE { get; set; }
 
	/// <summary>
    ///  Set or get the CONTRAMAN_HASTA property.
    /// </summary>
    
		public DateTime? CONTRAMAN_HASTA { get; set; }
 
	/// <summary>
    ///  Set or get the EQFRIO_MODELO property.
    /// </summary>
    
		public string EQFRIO_MODELO { get; set; }
 
	/// <summary>
    ///  Set or get the EQFRIO_SERIE property.
    /// </summary>
    
		public string EQFRIO_SERIE { get; set; }
 
	/// <summary>
    ///  Set or get the EQFRIO_GARAN1 property.
    /// </summary>
    
		public DateTime? EQFRIO_GARAN1 { get; set; }
 
	/// <summary>
    ///  Set or get the EQFRIO_GARAN2 property.
    /// </summary>
    
		public DateTime? EQFRIO_GARAN2 { get; set; }
 
	/// <summary>
    ///  Set or get the EQFRIO_OBS property.
    /// </summary>
    
		public string EQFRIO_OBS { get; set; }
 
	/// <summary>
    ///  Set or get the PLATAF_MODELO property.
    /// </summary>
    
		public string PLATAF_MODELO { get; set; }
 
	/// <summary>
    ///  Set or get the PLATAF_SERIE property.
    /// </summary>
    
		public string PLATAF_SERIE { get; set; }
 
	/// <summary>
    ///  Set or get the PLATAF_GARAN1 property.
    /// </summary>
    
		public DateTime? PLATAF_GARAN1 { get; set; }
 
	/// <summary>
    ///  Set or get the PLATAF_GARAN2 property.
    /// </summary>
    
		public DateTime? PLATAF_GARAN2 { get; set; }
 
	/// <summary>
    ///  Set or get the PLATAF_OBS property.
    /// </summary>
    
		public string PLATAF_OBS { get; set; }
 
	/// <summary>
    ///  Set or get the FBAJATEMPORAL property.
    /// </summary>
    
		public DateTime? FBAJATEMPORAL { get; set; }
 
	/// <summary>
    ///  Set or get the IFRS_V1 property.
    /// </summary>
    
		public Decimal? IFRS_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the PRECVEHI_IFRS_V1 property.
    /// </summary>
    
		public Decimal? PRECVEHI_IFRS_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the VR_IFRS_V1 property.
    /// </summary>
    
		public Decimal? VR_IFRS_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the TIR_IFRS_V1 property.
    /// </summary>
    
		public Decimal? TIR_IFRS_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the PLAZO_IFRS_V1 property.
    /// </summary>
    
		public Decimal? PLAZO_IFRS_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the VA_IFRS_V1 property.
    /// </summary>
    
		public Decimal? VA_IFRS_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the RATIO_VA_IFRS_V1 property.
    /// </summary>
    
		public Decimal? RATIO_VA_IFRS_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the KMS_MAQ_V1 property.
    /// </summary>
    
		public Int32? KMS_MAQ_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the ACT_SP property.
    /// </summary>
    
		public byte? ACT_SP { get; set; }
 
	/// <summary>
    ///  Set or get the FECHA_ACT_SEGURO_V1 property.
    /// </summary>
    
		public DateTime? FECHA_ACT_SEGURO_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the USU_ABPNN property.
    /// </summary>
    
		public string USU_ABPNN { get; set; }
 
	/// <summary>
    ///  Set or get the FEC_ABPNN property.
    /// </summary>
    
		public DateTime? FEC_ABPNN { get; set; }
 
	/// <summary>
    ///  Set or get the USU_ACT_IMP_V1 property.
    /// </summary>
    
		public string USU_ACT_IMP_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the FEC_ACT_IMP_V1 property.
    /// </summary>
    
		public DateTime? FEC_ACT_IMP_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the CODIGOINTERNO_MAQ property.
    /// </summary>
    
		public string CODIGOINTERNO_MAQ { get; set; }
 
	/// <summary>
    ///  Set or get the DUR_PREVISTA_V1 property.
    /// </summary>
    
		public Int32? DUR_PREVISTA_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the OBRA property.
    /// </summary>
    
		public string OBRA { get; set; }
 
	/// <summary>
    ///  Set or get the LIQUIDA100 property.
    /// </summary>
    
		public byte? LIQUIDA100 { get; set; }
 
	/// <summary>
    ///  Set or get the CABINA_V1 property.
    /// </summary>
    
		public string CABINA_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the IMP_DTO_WA_V1 property.
    /// </summary>
    
		public Decimal? IMP_DTO_WA_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the POR_DTO_WA_V1 property.
    /// </summary>
    
		public Decimal? POR_DTO_WA_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the TIPO_VEHI_WA_V1 property.
    /// </summary>
    
		public byte? TIPO_VEHI_WA_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the ESTADO_VEHI_WA_V1 property.
    /// </summary>
    
		public byte? ESTADO_VEHI_WA_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the NO_TRALADOS property.
    /// </summary>
    
		public byte? NO_TRALADOS { get; set; }
 
	/// <summary>
    ///  Set or get the MAX7DIAS property.
    /// </summary>
    
		public byte? MAX7DIAS { get; set; }
 
	/// <summary>
    ///  Set or get the EQFRIO_FFABRICA property.
    /// </summary>
    
		public DateTime? EQFRIO_FFABRICA { get; set; }
 
	/// <summary>
    ///  Set or get the PLATAF_FFABRICA property.
    /// </summary>
    
		public DateTime? PLATAF_FFABRICA { get; set; }
 
	/// <summary>
    ///  Set or get the PLATAF_MARCA property.
    /// </summary>
    
		public string PLATAF_MARCA { get; set; }
 
	/// <summary>
    ///  Set or get the EQFRIO_MARCA property.
    /// </summary>
    
		public string EQFRIO_MARCA { get; set; }
 
	/// <summary>
    ///  Set or get the EN_WEB_DEME_V1 property.
    /// </summary>
    
		public byte? EN_WEB_DEME_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the MANTE_TIEMPO property.
    /// </summary>
    
		public Decimal? MANTE_TIEMPO { get; set; }
 
	/// <summary>
    ///  Set or get the CLI_DELEGA_FAC_V1 property.
    /// </summary>
    
		public string CLI_DELEGA_FAC_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the FUEITV_V1 property.
    /// </summary>
    
		public DateTime? FUEITV_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the TIPOVEHI_MBF_V1 property.
    /// </summary>
    
		public Int32? TIPOVEHI_MBF_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the CATEGOVEHI_MBF_V1 property.
    /// </summary>
    
		public Int32? CATEGOVEHI_MBF_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the NUMLOCALIZA property.
    /// </summary>
    
		public string NUMLOCALIZA { get; set; }
 
	/// <summary>
    ///  Set or get the SILLAS_V1 property.
    /// </summary>
    
		public byte? SILLAS_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the ULT_FF property.
    /// </summary>
    
		public DateTime? ULT_FF { get; set; }
 
	/// <summary>
    ///  Set or get the VTO_FF property.
    /// </summary>
    
		public DateTime? VTO_FF { get; set; }
 
	/// <summary>
    ///  Set or get the OBS_FF property.
    /// </summary>
    
		public string OBS_FF { get; set; }
 
	/// <summary>
    ///  Set or get the COPIADO_DE_V1 property.
    /// </summary>
    
		public string COPIADO_DE_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the FEC_ACTIVA_COFICO_V1 property.
    /// </summary>
    
		public DateTime? FEC_ACTIVA_COFICO_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the FEC_PAGO_COFICO_V1 property.
    /// </summary>
    
		public DateTime? FEC_PAGO_COFICO_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the CTR_COFICO_V1 property.
    /// </summary>
    
		public Int32? CTR_COFICO_V1 { get; set; }
 
	/// <summary>
    ///  Set or get the COSTE_REG_ESP property.
    /// </summary>
    
		public Decimal? COSTE_REG_ESP { get; set; }
	}
}
