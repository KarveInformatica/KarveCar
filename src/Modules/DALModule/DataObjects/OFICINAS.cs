using System;
using System.ComponentModel;
using KarveDapper.Extensions;

namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a OFICINAS.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	[Table("OFICINAS")]
	public class OFICINAS 
	{
	
	/// <summary>
    ///  Set or get the CODIGO property.
    /// </summary>
        [Key]
		public string CODIGO { get; set; }
 
	/// <summary>
    ///  Set or get the SUBLICEN property.
    /// </summary>
    
		public string SUBLICEN { get; set; }
 
	/// <summary>
    ///  Set or get the NOMBRE property.
    /// </summary>
    
		public string NOMBRE { get; set; }
 
	/// <summary>
    ///  Set or get the DIRECCION property.
    /// </summary>
    
		public string DIRECCION { get; set; }
 
	/// <summary>
    ///  Set or get the POBLACION property.
    /// </summary>
    
		public string POBLACION { get; set; }
 
	/// <summary>
    ///  Set or get the PROVINCIA property.
    /// </summary>
    
		public string PROVINCIA { get; set; }

        /// <summary>
        ///  Set or get the CP property.
        /// </summary>
       
        public string CP { get; set; }

        /// <summary>
        ///  Set or get the RESPONSA property.
        /// </summary>
        public string RESPONSA { get; set; }

        /// <summary>
        ///  Set or get the PROPIO property.
        /// </summary>
        public string PROPIO { get; set; }

        /// <summary>
        ///  Set or get the TELEFONO property.
        /// </summary>
       
        public string TELEFONO { get; set; }

        /// <summary>
        ///  Set or get the MODEM property.
        /// </summary>
        public string MODEM { get; set; }
 
	/// <summary>
    ///  Set or get the FAX property.
    /// </summary>
    
		public string FAX { get; set; }

        /// <summary>
        ///  Set or get the OBS1 property.
        /// </summary>
        public string OBS1 { get; set; }

        /// <summary>
        ///  Set or get the MULTAS property.
        /// </summary>
        public string MULTAS { get; set; }

        /// <summary>
        ///  Set or get the DNIMULTAS property.
        /// </summary>
        public string DNIMULTAS { get; set; }

        /// <summary>
        ///  Set or get the TIPO1 property.
        /// </summary>
        public string TIPO1 { get; set; }

        /// <summary>
        ///  Set or get the TIPO2 property.
        /// </summary>
        [Browsable(false)]
        public string TIPO2 { get; set; }

        /// <summary>
        ///  Set or get the TIPO3 property.
        /// </summary>
        [Browsable(false)]
        public string TIPO3 { get; set; }

        /// <summary>
        ///  Set or get the TIPO4 property.
        /// </summary>
        [Browsable(false)]
        public string TIPO4 { get; set; }

        /// <summary>
        ///  Set or get the ULTMODI property.
        /// </summary>
        [Browsable(false)]
        public string ULTMODI { get; set; }

        /// <summary>
        ///  Set or get the USUARIO property.
        /// </summary>
        [Browsable(false)]
        public string USUARIO { get; set; }
 
	/// <summary>
    ///  Set or get the NIF property.
    /// </summary>
    
		public string NIF { get; set; }

        /// <summary>
        ///  Set or get the OFI_RED property.
        /// </summary>
        [Browsable(false)]
        public string OFI_RED { get; set; }

        /// <summary>
        ///  Set or get the FEC_ALTA property.
        /// </summary>
        
        public DateTime? FEC_ALTA { get; set; }
 
	/// <summary>
    ///  Set or get the FEC_BAJA property.
    /// </summary>
    
		public DateTime? FEC_BAJA { get; set; }

        /// <summary>
        ///  Set or get the HORARIO property.
        /// </summary>
        [Browsable(false)]
        public string HORARIO { get; set; }

        /// <summary>
        ///  Set or get the COMO_LLEGAR property.
        /// </summary>
        [Browsable(false)]
        public string COMO_LLEGAR { get; set; }

        /// <summary>
        ///  Set or get the ZONA_OF property.
        /// </summary>
        [Browsable(false)]
        public string ZONA_OF { get; set; }

        /// <summary>
        ///  Set or get the N_EMPLEADOS_OF property.
        /// </summary>
        [Browsable(false)]
        public byte? N_EMPLEADOS_OF { get; set; }

        /// <summary>
        ///  Set or get the DTOMAX property.
        /// </summary>
        [Browsable(false)]
        public Decimal? DTOMAX { get; set; }

        /// <summary>
        ///  Set or get the ZONAOFI property.
        /// </summary>
        [Browsable(false)]
        public string ZONAOFI { get; set; }

        /// <summary>
        ///  Set or get the DiaIni_Temporada property.
        /// </summary>
        [Browsable(false)]
        public byte? DiaIni_Temporada { get; set; }

        /// <summary>
        ///  Set or get the MesIni_Temporada property.
        /// </summary>
        [Browsable(false)]
        public byte? MesIni_Temporada { get; set; }

        /// <summary>
        ///  Set or get the DiaFi_Temporada property.
        /// </summary>
        [Browsable(false)]
        public byte? DiaFi_Temporada { get; set; }

        /// <summary>
        ///  Set or get the MesFi_Temporada property.
        /// </summary>
        [Browsable(false)]
        public byte? MesFi_Temporada { get; set; }

        /// <summary>
        ///  Set or get the Recogida property.
        /// </summary>
        [Browsable(false)]
        public byte? Recogida { get; set; }
 
	/// <summary>
    ///  Set or get the EMAIL_OFI property.
    /// </summary>
    
		public string EMAIL_OFI { get; set; }

        /// <summary>
        ///  Set or get the OFI_FLOTA property.
        /// </summary>
        [Browsable(false)]
        public string OFI_FLOTA { get; set; }

        /// <summary>
        ///  Set or get the IVA_WEB property.
        /// </summary>
        [Browsable(false)]
        public Decimal? IVA_WEB { get; set; }

        /// <summary>
        ///  Set or get the HOR_LUNES property.
        /// </summary>
        [Browsable(false)]
        public byte? HOR_LUNES { get; set; }

        /// <summary>
        ///  Set or get the HOR_MARTES property.
        /// </summary>
        [Browsable(false)]
        public byte? HOR_MARTES { get; set; }

        /// <summary>
        ///  Set or get the HOR_MIERCOLES property.
        /// </summary>
        [Browsable(false)]
        public byte? HOR_MIERCOLES { get; set; }

        /// <summary>
        ///  Set or get the HOR_JUEVES property.
        /// </summary>
        [Browsable(false)]
        public byte? HOR_JUEVES { get; set; }

        /// <summary>
        ///  Set or get the HOR_VIERNES property.
        /// </summary>
        [Browsable(false)]
        public byte? HOR_VIERNES { get; set; }

        /// <summary>
        ///  Set or get the HOR_SABADO property.
        /// </summary>
        [Browsable(false)]
        public byte? HOR_SABADO { get; set; }

        /// <summary>
        ///  Set or get the HOR_DOMINGO property.
        /// </summary>
        [Browsable(false)]
        public byte? HOR_DOMINGO { get; set; }

        /// <summary>
        ///  Set or get the ABRE_MA_LUNES property.
        /// </summary>
        [Browsable(false)]
        public TimeSpan? ABRE_MA_LUNES { get; set; }

        /// <summary>
        ///  Set or get the ABRE_MA_MARTES property.
        /// </summary>
        [Browsable(false)]
        public TimeSpan? ABRE_MA_MARTES { get; set; }
 
	/// <summary>
    ///  Set or get the ABRE_MA_MIERCOLES property.
    /// </summary>
    
		public TimeSpan? ABRE_MA_MIERCOLES { get; set; }
 
	/// <summary>
    ///  Set or get the ABRE_MA_JUEVES property.
    /// </summary>
    
		public TimeSpan? ABRE_MA_JUEVES { get; set; }
 
	/// <summary>
    ///  Set or get the ABRE_MA_VIERNES property.
    /// </summary>
    
		public TimeSpan? ABRE_MA_VIERNES { get; set; }
 
	/// <summary>
    ///  Set or get the ABRE_MA_SABADO property.
    /// </summary>
    
		public TimeSpan? ABRE_MA_SABADO { get; set; }
 
	/// <summary>
    ///  Set or get the ABRE_MA_DOMINGO property.
    /// </summary>
    
		public TimeSpan? ABRE_MA_DOMINGO { get; set; }
 
	/// <summary>
    ///  Set or get the CIERRA_MA_LUNES property.
    /// </summary>
    
		public TimeSpan? CIERRA_MA_LUNES { get; set; }
 
	/// <summary>
    ///  Set or get the CIERRA_MA_MARTES property.
    /// </summary>
    
		public TimeSpan? CIERRA_MA_MARTES { get; set; }
 
	/// <summary>
    ///  Set or get the CIERRA_MA_MIERCOLES property.
    /// </summary>
    
		public TimeSpan? CIERRA_MA_MIERCOLES { get; set; }
 
	/// <summary>
    ///  Set or get the CIERRA_MA_JUEVES property.
    /// </summary>
    
		public TimeSpan? CIERRA_MA_JUEVES { get; set; }
 
	/// <summary>
    ///  Set or get the CIERRA_MA_VIERNES property.
    /// </summary>
    
		public TimeSpan? CIERRA_MA_VIERNES { get; set; }
 
	/// <summary>
    ///  Set or get the CIERRA_MA_SABADO property.
    /// </summary>
    
		public TimeSpan? CIERRA_MA_SABADO { get; set; }
 
	/// <summary>
    ///  Set or get the CIERRA_MA_DOMINGO property.
    /// </summary>
    
		public TimeSpan? CIERRA_MA_DOMINGO { get; set; }
 
	/// <summary>
    ///  Set or get the ABRE_TA_LUNES property.
    /// </summary>
    
		public TimeSpan? ABRE_TA_LUNES { get; set; }
 
	/// <summary>
    ///  Set or get the ABRE_TA_MARTES property.
    /// </summary>
    
		public TimeSpan? ABRE_TA_MARTES { get; set; }
 
	/// <summary>
    ///  Set or get the ABRE_TA_MIERCOLES property.
    /// </summary>
    
		public TimeSpan? ABRE_TA_MIERCOLES { get; set; }
 
	/// <summary>
    ///  Set or get the ABRE_TA_JUEVES property.
    /// </summary>
    
		public TimeSpan? ABRE_TA_JUEVES { get; set; }
 
	/// <summary>
    ///  Set or get the ABRE_TA_VIERNES property.
    /// </summary>
    
		public TimeSpan? ABRE_TA_VIERNES { get; set; }
 
	/// <summary>
    ///  Set or get the ABRE_TA_SABADO property.
    /// </summary>
    
		public TimeSpan? ABRE_TA_SABADO { get; set; }
 
	/// <summary>
    ///  Set or get the ABRE_TA_DOMINGO property.
    /// </summary>
    
		public TimeSpan? ABRE_TA_DOMINGO { get; set; }
 
	/// <summary>
    ///  Set or get the CIERRA_TA_LUNES property.
    /// </summary>
    
		public TimeSpan? CIERRA_TA_LUNES { get; set; }
 
	/// <summary>
    ///  Set or get the CIERRA_TA_MARTES property.
    /// </summary>
    
		public TimeSpan? CIERRA_TA_MARTES { get; set; }
 
	/// <summary>
    ///  Set or get the CIERRA_TA_MIERCOLES property.
    /// </summary>
    
		public TimeSpan? CIERRA_TA_MIERCOLES { get; set; }
 
	/// <summary>
    ///  Set or get the CIERRA_TA_JUEVES property.
    /// </summary>
    
		public TimeSpan? CIERRA_TA_JUEVES { get; set; }
 
	/// <summary>
    ///  Set or get the CIERRA_TA_VIERNES property.
    /// </summary>
    
		public TimeSpan? CIERRA_TA_VIERNES { get; set; }
 
	/// <summary>
    ///  Set or get the CIERRA_TA_SABADO property.
    /// </summary>
    
		public TimeSpan? CIERRA_TA_SABADO { get; set; }
 
	/// <summary>
    ///  Set or get the CIERRA_TA_DOMINGO property.
    /// </summary>
    
		public TimeSpan? CIERRA_TA_DOMINGO { get; set; }
 
	/// <summary>
    ///  Set or get the DEPARTA property.
    /// </summary>
    
		public string DEPARTA { get; set; }
 
	/// <summary>
    ///  Set or get the TARTRANS property.
    /// </summary>
    
		public string TARTRANS { get; set; }
 
	/// <summary>
    ///  Set or get the ORIGEN_CONFIG property.
    /// </summary>
    
		public byte? ORIGEN_CONFIG { get; set; }
 
	/// <summary>
    ///  Set or get the COD_SOCIEDAD property.
    /// </summary>
    
		public string COD_SOCIEDAD { get; set; }
 
	/// <summary>
    ///  Set or get the VER_CLIENTESOFICINA property.
    /// </summary>
    
		public byte? VER_CLIENTESOFICINA { get; set; }
 
	/// <summary>
    ///  Set or get the REF_OFI property.
    /// </summary>
    
		public string REF_OFI { get; set; }
 
	/// <summary>
    ///  Set or get the COD_EXTERNO property.
    /// </summary>
    
		public string COD_EXTERNO { get; set; }
 
	/// <summary>
    ///  Set or get the TOFI property.
    /// </summary>
    
		public string TOFI { get; set; }
 
	/// <summary>
    ///  Set or get the STATUS property.
    /// </summary>
    
		public byte? STATUS { get; set; }
 
	/// <summary>
    ///  Set or get the AF property.
    /// </summary>
    
		public byte? AF { get; set; }
 
	/// <summary>
    ///  Set or get the TXTINVENTARIO property.
    /// </summary>
    
		public string TXTINVENTARIO { get; set; }
 
	/// <summary>
    ///  Set or get the CLIENTE_CONCESIONARIO property.
    /// </summary>
    
		public string CLIENTE_CONCESIONARIO { get; set; }
 
	/// <summary>
    ///  Set or get the NOMWEB property.
    /// </summary>
    
		public string NOMWEB { get; set; }
 
	/// <summary>
    ///  Set or get the MOSTRAR property.
    /// </summary>
    
		public byte? MOSTRAR { get; set; }
 
	/// <summary>
    ///  Set or get the NOTASWEB property.
    /// </summary>
    
		public string NOTASWEB { get; set; }
 
	/// <summary>
    ///  Set or get the TELFEMERGENCIA property.
    /// </summary>
    
		public string TELFEMERGENCIA { get; set; }
 
	/// <summary>
    ///  Set or get the RESOFLINE property.
    /// </summary>
    
		public byte? RESOFLINE { get; set; }
 
	/// <summary>
    ///  Set or get the RESONLINE property.
    /// </summary>
    
		public byte? RESONLINE { get; set; }
 
	/// <summary>
    ///  Set or get the ABRECONT property.
    /// </summary>
    
		public byte? ABRECONT { get; set; }
 
	/// <summary>
    ///  Set or get the ES_AERO property.
    /// </summary>
    
		public byte? ES_AERO { get; set; }
 
	/// <summary>
    ///  Set or get the UTILIZAIGIC property.
    /// </summary>
    
		public byte? UTILIZAIGIC { get; set; }
 
	/// <summary>
    ///  Set or get the IMPRIMIR_EN_INGLES property.
    /// </summary>
    
		public byte? IMPRIMIR_EN_INGLES { get; set; }
 
	/// <summary>
    ///  Set or get the NOMCOMER property.
    /// </summary>
    
		public string NOMCOMER { get; set; }
 
	/// <summary>
    ///  Set or get the TLL_ALMACEN_DEFECTO_ALQ property.
    /// </summary>
    
		public string TLL_ALMACEN_DEFECTO_ALQ { get; set; }
 
	/// <summary>
    ///  Set or get the TLL_ALMACEN_DEFECTO_SAT property.
    /// </summary>
    
		public string TLL_ALMACEN_DEFECTO_SAT { get; set; }
 
	/// <summary>
    ///  Set or get the ES_AEROPUERTO property.
    /// </summary>
    
		public byte? ES_AEROPUERTO { get; set; }
 
	/// <summary>
    ///  Set or get the NACIO property.
    /// </summary>
    
		public string NACIO { get; set; }
 
	/// <summary>
    ///  Set or get the STATION_NUM property.
    /// </summary>
    
		public Int32? STATION_NUM { get; set; }
 
	/// <summary>
    ///  Set or get the PROPIE_OFI property.
    /// </summary>
    
		public string PROPIE_OFI { get; set; }
 
	/// <summary>
    ///  Set or get the ONWAYNAC_ONREQ property.
    /// </summary>
    
		public byte? ONWAYNAC_ONREQ { get; set; }
 
	/// <summary>
    ///  Set or get the ADMITEREC_FUERAHORAS property.
    /// </summary>
    
		public byte? ADMITEREC_FUERAHORAS { get; set; }
 
	/// <summary>
    ///  Set or get the CODIGO_JD property.
    /// </summary>
    
		public string CODIGO_JD { get; set; }
 
	/// <summary>
    ///  Set or get the COORDGPS_OFI property.
    /// </summary>
    
		public string COORDGPS_OFI { get; set; }
 
	/// <summary>
    ///  Set or get the SIEMPRE_ONREQUEST property.
    /// </summary>
    
		public byte? SIEMPRE_ONREQUEST { get; set; }
 
	/// <summary>
    ///  Set or get the BANREGIO_CLABE property.
    /// </summary>
    
		public string BANREGIO_CLABE { get; set; }
 
	/// <summary>
    ///  Set or get the BANREGIO_PORTAL property.
    /// </summary>
    
		public string BANREGIO_PORTAL { get; set; }
 
	/// <summary>
    ///  Set or get the REGION property.
    /// </summary>
    
		public string REGION { get; set; }
 
	/// <summary>
    ///  Set or get the TIENE_DEPO_GASOIL_OFI property.
    /// </summary>
    
		public byte? TIENE_DEPO_GASOIL_OFI { get; set; }
 
	/// <summary>
    ///  Set or get the LAT_COORDOFI property.
    /// </summary>
    
		public Decimal? LAT_COORDOFI { get; set; }
 
	/// <summary>
    ///  Set or get the LONG_COORDOFI property.
    /// </summary>
    
		public Decimal? LONG_COORDOFI { get; set; }
 
	/// <summary>
    ///  Set or get the USUARIO_WEB property.
    /// </summary>
    
		public string USUARIO_WEB { get; set; }
 
	/// <summary>
    ///  Set or get the PWD_WEB property.
    /// </summary>
    
		public string PWD_WEB { get; set; }
 
	/// <summary>
    ///  Set or get the CURRENCY_OFI property.
    /// </summary>
    
		public string CURRENCY_OFI { get; set; }
 
	/// <summary>
    ///  Set or get the EMAIL_BOOKING property.
    /// </summary>
    
		public byte? EMAIL_BOOKING { get; set; }
 
	/// <summary>
    ///  Set or get the OFI_TRACTORAS property.
    /// </summary>
    
		public byte? OFI_TRACTORAS { get; set; }
 
	/// <summary>
    ///  Set or get the OFICINA_WEB_OFI property.
    /// </summary>
    
		public string OFICINA_WEB_OFI { get; set; }
 
	/// <summary>
    ///  Set or get the SUCURSAL_DGI property.
    /// </summary>
    
		public string SUCURSAL_DGI { get; set; }
 
	/// <summary>
    ///  Set or get the HORARIO_TEXTO_OFI property.
    /// </summary>
    
		public string HORARIO_TEXTO_OFI { get; set; }
 
	/// <summary>
    ///  Set or get the ID_CONTRATO_SAVIA property.
    /// </summary>
    
		public string ID_CONTRATO_SAVIA { get; set; }
 
	/// <summary>
    ///  Set or get the ID_LOCAL_SAVIA property.
    /// </summary>
    
		public string ID_LOCAL_SAVIA { get; set; }
 
	/// <summary>
    ///  Set or get the ID_CLIENTE property.
    /// </summary>
    
		public Int32? ID_CLIENTE { get; set; }
 
	/// <summary>
    ///  Set or get the IATA property.
    /// </summary>
    
		public string IATA { get; set; }
 
	/// <summary>
    ///  Set or get the CANON property.
    /// </summary>
    
		public Decimal? CANON { get; set; }
 
	/// <summary>
    ///  Set or get the USUARIO_AENA property.
    /// </summary>
    
		public string USUARIO_AENA { get; set; }
 
	/// <summary>
    ///  Set or get the PASS_AENA property.
    /// </summary>
    
		public string PASS_AENA { get; set; }
 
	/// <summary>
    ///  Set or get the PREFIJO_AENA property.
    /// </summary>
    
		public string PREFIJO_AENA { get; set; }
 
	/// <summary>
    ///  Set or get the ES_ESTACION property.
    /// </summary>
    
		public byte? ES_ESTACION { get; set; }
 
	/// <summary>
    ///  Set or get the ADMITEENT_FUERAHORAS property.
    /// </summary>
    
		public byte? ADMITEENT_FUERAHORAS { get; set; }
 
	/// <summary>
    ///  Set or get the ENT_FUERAHORAS_NO_ONREQUEST property.
    /// </summary>
    
		public byte? ENT_FUERAHORAS_NO_ONREQUEST { get; set; }
 
	/// <summary>
    ///  Set or get the REC_FUERAHORAS_NO_ONREQUEST property.
    /// </summary>
    
		public byte? REC_FUERAHORAS_NO_ONREQUEST { get; set; }
 
	/// <summary>
    ///  Set or get the EMAIL_RESCONFIRM property.
    /// </summary>
    
		public string EMAIL_RESCONFIRM { get; set; }
 
	/// <summary>
    ///  Set or get the EMAIL_RESONREQ property.
    /// </summary>
    
		public string EMAIL_RESONREQ { get; set; }
 
	/// <summary>
    ///  Set or get the EMAIL_RESRECHAZA property.
    /// </summary>
    
		public string EMAIL_RESRECHAZA { get; set; }
 
	/// <summary>
    ///  Set or get the REC_FESTIVO_NO_ONREQUEST property.
    /// </summary>
    
		public byte? REC_FESTIVO_NO_ONREQUEST { get; set; }
 
	/// <summary>
    ///  Set or get the ENT_FUERAHORAS_SINCOSTE property.
    /// </summary>
    
		public byte? ENT_FUERAHORAS_SINCOSTE { get; set; }
 
	/// <summary>
    ///  Set or get the REC_FUERAHORAS_SINCOSTE property.
    /// </summary>
    
		public byte? REC_FUERAHORAS_SINCOSTE { get; set; }
 
	/// <summary>
    ///  Set or get the CANON_OTROS property.
    /// </summary>
    
		public Decimal? CANON_OTROS { get; set; }
	}
}
