using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace KarveDataServices.DataTransferObject
{
    [DataContract]
    public class ClientDto: BaseDto
    {
        public ClientDto()
        {
            VisitsDto = new ObservableCollection<VisitsDto>();
            ContactsDto = new ObservableCollection<ContactsDto>();
            BranchesDto = new ObservableCollection<BranchesDto>();
        }
        [DataMember]
        public string Numero { get; set; }
        [DataMember]
        public string Movil { get;  set; }
        [DataMember]
        public string Nombre { get; set; }


        /// <summary>
        ///  Set or get the NUMERO_CLI property.
        /// </summary>
        
        [PrimaryKey]

        public string NUMERO_CLI { get; set; }

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
        ///  Set or get the NACIOPER property.
        /// </summary>

        public string NACIOPER { get; set; }

        /// <summary>
        ///  Set or get the NACIODOMI property.
        /// </summary>

        public string NACIODOMI { get; set; }

        /// <summary>
        ///  Set or get the NIF property.
        /// </summary>

        public string NIF { get; set; }

        /// <summary>
        ///  Set or get the FENAC property.
        /// </summary>

        public DateTime? FENAC { get; set; }

        /// <summary>
        ///  Set or get the LUDNI property.
        /// </summary>

        public string LUDNI { get; set; }

        /// <summary>
        ///  Set or get the FEDNI property.
        /// </summary>

        public DateTime? FEDNI { get; set; }

        /// <summary>
        ///  Set or get the CP property.
        /// </summary>

        public string CP { get; set; }

        /// <summary>
        ///  Set or get the TELEFONO property.
        /// </summary>

        public string TELEFONO { get; set; }

        /// <summary>
        ///  Set or get the TEL2 property.
        /// </summary>

        public string TEL2 { get; set; }

        /// <summary>
        ///  Set or get the FAX property.
        /// </summary>

        public string FAX { get; set; }

        /// <summary>
        ///  Set or get the NOTAS property.
        /// </summary>

        public string NOTAS { get; set; }

        /// <summary>
        ///  Set or get the CCOSTE property.
        /// </summary>

        public string CCOSTE { get; set; }

        /// <summary>
        ///  Set or get the TARTI property.
        /// </summary>

        public string TARTI { get; set; }

        /// <summary>
        ///  Set or get the TARNUM property.
        /// </summary>

        public string TARNUM { get; set; }

        /// <summary>
        ///  Set or get the TARCADU property.
        /// </summary>

        public string TARCADU { get; set; }

        /// <summary>
        ///  Set or get the DTO property.
        /// </summary>

        public Decimal? DTO { get; set; }

        /// <summary>
        ///  Set or get the PERMISO property.
        /// </summary>

        public string PERMISO { get; set; }

        /// <summary>
        ///  Set or get the CLASE property.
        /// </summary>

        public string CLASE { get; set; }

        /// <summary>
        ///  Set or get the FEEXPE property.
        /// </summary>

        public DateTime? FEEXPE { get; set; }

        /// <summary>
        ///  Set or get the LUEXPE property.
        /// </summary>

        public string LUEXPE { get; set; }

        /// <summary>
        ///  Set or get the OBSERVA property.
        /// </summary>

        public string OBSERVA { get; set; }

        /// <summary>
        ///  Set or get the BANCO property.
        /// </summary>

        public string BANCO { get; set; }

        /// <summary>
        ///  Set or get the CUBANCO property.
        /// </summary>

        public string CUBANCO { get; set; }

        /// <summary>
        ///  Set or get the MOROSO property.
        /// </summary>

        public byte? MOROSO { get; set; }

        /// <summary>
        ///  Set or get the DIA property.
        /// </summary>

        public byte? DIA { get; set; }

        /// <summary>
        ///  Set or get the DIA2 property.
        /// </summary>

        public byte? DIA2 { get; set; }

        /// <summary>
        ///  Set or get the PLAZO property.
        /// </summary>

        public Int16? PLAZO { get; set; }

        /// <summary>
        ///  Set or get the TARIFA property.
        /// </summary>

        public string TARIFA { get; set; }

        /// <summary>
        ///  Set or get the COBRAFRAN property.
        /// </summary>

        public byte? COBRAFRAN { get; set; }

        /// <summary>
        ///  Set or get the DIR2 property.
        /// </summary>

        public string DIR2 { get; set; }

        /// <summary>
        ///  Set or get the CP2 property.
        /// </summary>

        public string CP2 { get; set; }

        /// <summary>
        ///  Set or get the POB2 property.
        /// </summary>

        public string POB2 { get; set; }

        /// <summary>
        ///  Set or get the NACIODOMI2 property.
        /// </summary>

        public string NACIODOMI2 { get; set; }

        /// <summary>
        ///  Set or get the PROV2 property.
        /// </summary>

        public string PROV2 { get; set; }

        /// <summary>
        ///  Set or get the PERSONA property.
        /// </summary>

        public string PERSONA { get; set; }

        /// <summary>
        ///  Set or get the TAREMP property.
        /// </summary>

        public string TAREMP { get; set; }

        /// <summary>
        ///  Set or get the TARPUN property.
        /// </summary>

        public string TARPUN { get; set; }

        /// <summary>
        ///  Set or get the MATRI_SUST property.
        /// </summary>

        public string MATRI_SUST { get; set; }

        /// <summary>
        ///  Set or get the CLAVEPTO property.
        /// </summary>

        public string CLAVEPTO { get; set; }

        /// <summary>
        ///  Set or get the LUNACI property.
        /// </summary>

        public string LUNACI { get; set; }

        /// <summary>
        ///  Set or get the BAJA property.
        /// </summary>

        public DateTime? BAJA { get; set; }

        /// <summary>
        ///  Set or get the REF_A_COMI property.
        /// </summary>

        public string REF_A_COMI { get; set; }

        /// <summary>
        ///  Set or get the PAIS2 property.
        /// </summary>

        public string PAIS2 { get; set; }

        /// <summary>
        ///  Set or get the DTO_ONLINE property.
        /// </summary>

        public Decimal? DTO_ONLINE { get; set; }

        /// <summary>
        ///  Set or get the PAIS property.
        /// </summary>

        public string PAIS { get; set; }

        /// <summary>
        ///  Set or get the CODPROV_CLI1 property.
        /// </summary>

        public string CODPROV_CLI1 { get; set; }

        /// <summary>
        ///  Set or get the NOIMPRFAC property.
        /// </summary>

        public byte? NOIMPRFAC { get; set; }

        /// <summary>
        ///  Set or get the CLIENTEFAC property.
        /// </summary>

        public string CLIENTEFAC { get; set; }

        /// <summary>
        ///  Set or get the TAREMP_TIPO property.
        /// </summary>

        public string TAREMP_TIPO { get; set; }

        /// <summary>
        ///  Set or get the TAREMP_FCAD property.
        /// </summary>

        public DateTime? TAREMP_FCAD { get; set; }

        /// <summary>
        ///  Set or get the TAREMP_OBS property.
        /// </summary>

        public string TAREMP_OBS { get; set; }

        /// <summary>
        ///  Set or get the DTOPP property.
        /// </summary>

        public Decimal? DTOPP { get; set; }

        /// <summary>
        ///  Set or get the FECADU property.
        /// </summary>

        public DateTime? FECADU { get; set; }

        /// <summary>
        ///  Set or get the MOVIL property.
        /// </summary>

        public string MOVIL { get; set; }

        /// <summary>
        ///  Set or get the NUMCOPIASFAC property.
        /// </summary>

        public Int16? NUMCOPIASFAC { get; set; }

        /// <summary>
        ///  Set or get the PLAZO2 property.
        /// </summary>

        public Int16? PLAZO2 { get; set; }

        /// <summary>
        ///  Set or get the PLAZO3 property.
        /// </summary>

        public Int16? PLAZO3 { get; set; }

        /// <summary>
        ///  Set or get the MESVACA property.
        /// </summary>

        public byte? MESVACA { get; set; }

        /// <summary>
        ///  Set or get the TARTITULAR property.
        /// </summary>

        public string TARTITULAR { get; set; }

        /// <summary>
        ///  Set or get the TARJETA_COMI_CL1 property.
        /// </summary>

        public string TARJETA_COMI_CL1 { get; set; }

        /// <summary>
        ///  Set or get the BLOQUEFAC property.
        /// </summary>

        public string BLOQUEFAC { get; set; }

        /// <summary>
        ///  Set or get the RUTAFOTO property.
        /// </summary>

        public string RUTAFOTO { get; set; }

        /// <summary>
        ///  Set or get the DIRMAQ property.
        /// </summary>

        public string DIRMAQ { get; set; }

        /// <summary>
        ///  Set or get the DIRECCION2L property.
        /// </summary>

        public string DIRECCION2L { get; set; }

        /// <summary>
        ///  Set or get the DTO_PIEZAS property.
        /// </summary>

        public Double? DTO_PIEZAS { get; set; }

        /// <summary>
        ///  Set or get the DTO_MO property.
        /// </summary>

        public Double? DTO_MO { get; set; }

        /// <summary>
        ///  Set or get the MODULODES property.
        /// </summary>

        public string MODULODES { get; set; }

        /// <summary>
        ///  Set or get the MODULOTIE property.
        /// </summary>

        public string MODULOTIE { get; set; }

        /// <summary>
        ///  Set or get the EXPORTA_CLI property.
        /// </summary>

        public byte? EXPORTA_CLI { get; set; }

        /// <summary>
        ///  Set or get the HORARIO property.
        /// </summary>

        public string HORARIO { get; set; }

        /// <summary>
        ///  Set or get the LOGOENFAC property.
        /// </summary>

        public byte? LOGOENFAC { get; set; }

        /// <summary>
        ///  Set or get the TARCODI property.
        /// </summary>

        public string TARCODI { get; set; }

        /// <summary>
        ///  Set or get the IDIOMA property.
        /// </summary>

        public byte? IDIOMA { get; set; }

        /// <summary>
        ///  Set or get the PASAPORTE property.
        /// </summary>

        public string PASAPORTE { get; set; }

        /// <summary>
        ///  Set or get the NIFVIEJO property.
        /// </summary>

        public string NIFVIEJO { get; set; }

        /// <summary>
        ///  Set or get the NRC property.
        /// </summary>

        public string NRC { get; set; }

        /// <summary>
        ///  Set or get the NOFAC_AUT property.
        /// </summary>

        public byte? NOFAC_AUT { get; set; }

        /// <summary>
        ///  Set or get the FRATIPIMPR property.
        /// </summary>

        public byte? FRATIPIMPR { get; set; }

        /// <summary>
        ///  Set or get the RUTAFOTO2 property.
        /// </summary>

        public string RUTAFOTO2 { get; set; }

        /// <summary>
        ///  Set or get the USO_ALQUILER property.
        /// </summary>

        public byte? USO_ALQUILER { get; set; }

        /// <summary>
        ///  Set or get the F_AEAT property.
        /// </summary>

        public DateTime? F_AEAT { get; set; }

        /// <summary>
        ///  Set or get the RUTA property.
        /// </summary>

        public string RUTA { get; set; }

        /// <summary>
        ///  Set or get the IMPRODUC_CLI property.
        /// </summary>

        public byte? IMPRODUC_CLI { get; set; }

        /// <summary>
        ///  Set or get the TAREMP_FALTA property.
        /// </summary>

        public DateTime? TAREMP_FALTA { get; set; }

        /// <summary>
        ///  Set or get the COD_SOCIEDAD property.
        /// </summary>

        public string COD_SOCIEDAD { get; set; }

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
        ///  Set or get the COORDGPS property.
        /// </summary>

        public string COORDGPS { get; set; }

        /// <summary>
        ///  Set or get the CODPROVEE property.
        /// </summary>

        public string CODPROVEE { get; set; }

        /// <summary>
        ///  Set or get the EXPORTADO property.
        /// </summary>

        public byte? EXPORTADO { get; set; }

        /// <summary>
        ///  Set or get the REGMERCA property.
        /// </summary>

        public string REGMERCA { get; set; }

        /// <summary>
        ///  Set or get the IMPORTE_UF property.
        /// </summary>

        public Decimal? IMPORTE_UF { get; set; }

        /// <summary>
        ///  Set or get the FAC_PRECIOCOSTE property.
        /// </summary>

        public byte? FAC_PRECIOCOSTE { get; set; }

        /// <summary>
        ///  Set or get the EMAIL_MANT property.
        /// </summary>

        public string EMAIL_MANT { get; set; }

        /// <summary>
        ///  Set or get the PAPEL property.
        /// </summary>

        public byte? PAPEL { get; set; }

        /// <summary>
        ///  Set or get the TIPOTRANS_CLI property.
        /// </summary>

        public byte? TIPOTRANS_CLI { get; set; }

        /// <summary>
        ///  Set or get the POSTPAGABLE_CLI property.
        /// </summary>

        public byte? POSTPAGABLE_CLI { get; set; }

        /// <summary>
        ///  Set or get the CONTRATIPIMPR_CLI property.
        /// </summary>

        public byte? CONTRATIPIMPR_CLI { get; set; }

        /// <summary>
        ///  Set or get the TIPOIVA_CLI property.
        /// </summary>

        public string TIPOIVA_CLI { get; set; }

        /// <summary>
        ///  Set or get the TARCODI2 property.
        /// </summary>

        public string TARCODI2 { get; set; }

        /// <summary>
        ///  Set or get the CODPROV_CLI property.
        /// </summary>

        public string CODPROV_CLI { get; set; }

        /// <summary>
        ///  Set or get the CLICOND property.
        /// </summary>

        public byte? CLICOND { get; set; }

        /// <summary>
        ///  Set or get the OBS_CAMBIO_STATUS property.
        /// </summary>

        public string OBS_CAMBIO_STATUS { get; set; }

        /// <summary>
        ///  Set or get the STATUS_CLI property.
        /// </summary>

        public byte? STATUS_CLI { get; set; }

        /// <summary>
        ///  Set or get the FCAMBIO_STATUS property.
        /// </summary>

        public DateTime? FCAMBIO_STATUS { get; set; }

        /// <summary>
        ///  Set or get the FCAMBIO_CONTENCIOSO_INCIDEN property.
        /// </summary>

        public DateTime? FCAMBIO_CONTENCIOSO_INCIDEN { get; set; }

        /// <summary>
        ///  Set or get the FCIERRE_CTAS property.
        /// </summary>

        public DateTime? FCIERRE_CTAS { get; set; }

        /// <summary>
        ///  Set or get the FDEMANDA property.
        /// </summary>

        public DateTime? FDEMANDA { get; set; }

        /// <summary>
        ///  Set or get the FINI_INCIDEN property.
        /// </summary>

        public DateTime? FINI_INCIDEN { get; set; }

        /// <summary>
        ///  Set or get the NO_PERMITIR_COB_ENCTR property.
        /// </summary>

        public byte? NO_PERMITIR_COB_ENCTR { get; set; }

        /// <summary>
        ///  Set or get the NO_MOSTRAR_EN_LCTRPENDCOB property.
        /// </summary>

        public byte? NO_MOSTRAR_EN_LCTRPENDCOB { get; set; }

        /// <summary>
        ///  Set or get the GRUTARI_CLI property.
        /// </summary>

        public string GRUTARI_CLI { get; set; }

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
        ///  Set or get the NO_FORZAR_FACTURAS30_HF property.
        /// </summary>

        public byte? NO_FORZAR_FACTURAS30_HF { get; set; }

        /// <summary>
        ///  Set or get the REPRESENTANTE property.
        /// </summary>

        public string REPRESENTANTE { get; set; }

        /// <summary>
        ///  Set or get the CLI_COMUN_OFIS property.
        /// </summary>

        public byte? CLI_COMUN_OFIS { get; set; }

        /// <summary>
        ///  Set or get the BANCO_INF property.
        /// </summary>

        public string BANCO_INF { get; set; }

        /// <summary>
        ///  Set or get the FECHA_INF property.
        /// </summary>

        public DateTime? FECHA_INF { get; set; }

        /// <summary>
        ///  Set or get the RESPUESTA_INF property.
        /// </summary>

        public string RESPUESTA_INF { get; set; }

        /// <summary>
        ///  Set or get the SEXO property.
        /// </summary>

        public byte? SEXO { get; set; }

        /// <summary>
        ///  Set or get the EMAIL_DEV property.
        /// </summary>

        public string EMAIL_DEV { get; set; }

        /// <summary>
        ///  Set or get the DNIREPRE property.
        /// </summary>

        public string DNIREPRE { get; set; }

        /// <summary>
        ///  Set or get the COD_TXT_FACTURA_MBZ property.
        /// </summary>

        public string COD_TXT_FACTURA_MBZ { get; set; }

        /// <summary>
        ///  Set or get the TXT_FACTURA_MBZ property.
        /// </summary>

        public string TXT_FACTURA_MBZ { get; set; }

        /// <summary>
        ///  Set or get the NO_ENVIAR_PERITO property.
        /// </summary>

        public byte? NO_ENVIAR_PERITO { get; set; }

        /// <summary>
        ///  Set or get the COMPUTABLE_VENDEDOR property.
        /// </summary>

        public string COMPUTABLE_VENDEDOR { get; set; }

        /// <summary>
        ///  Set or get the NIF_EXTRANJERO property.
        /// </summary>

        public byte? NIF_EXTRANJERO { get; set; }

        /// <summary>
        ///  Set or get the NUMCOPIASCTR property.
        /// </summary>

        public byte? NUMCOPIASCTR { get; set; }

        /// <summary>
        ///  Set or get the NODTOPPALQ property.
        /// </summary>

        public byte? NODTOPPALQ { get; set; }

        /// <summary>
        ///  Set or get the DIA3 property.
        /// </summary>

        public byte? DIA3 { get; set; }

        /// <summary>
        ///  Set or get the TALBARAN property.
        /// </summary>

        public string TALBARAN { get; set; }

        /// <summary>
        ///  Set or get the HOSPITAL property.
        /// </summary>

        public string HOSPITAL { get; set; }

        /// <summary>
        ///  Set or get the LOGIN_WEB property.
        /// </summary>

        public string LOGIN_WEB { get; set; }

        /// <summary>
        ///  Set or get the PW_WEB property.
        /// </summary>

        public string PW_WEB { get; set; }

        /// <summary>
        ///  Set or get the BLQ_CTR_OTRAS_EMPS property.
        /// </summary>

        public byte? BLQ_CTR_OTRAS_EMPS { get; set; }

        /// <summary>
        ///  Set or get the IBAN property.
        /// </summary>

        public string IBAN { get; set; }

        /// <summary>
        ///  Set or get the CARTA_AUTORIZA_RECIBIDA property.
        /// </summary>

        public DateTime? CARTA_AUTORIZA_RECIBIDA { get; set; }

        /// <summary>
        ///  Set or get the SWIFT property.
        /// </summary>

        public string SWIFT { get; set; }

        /// <summary>
        ///  Set or get the NEWSLETTER_WEB property.
        /// </summary>

        public byte? NEWSLETTER_WEB { get; set; }

        /// <summary>
        ///  Set or get the TXTFACTURA_CLI property.
        /// </summary>

        public string TXTFACTURA_CLI { get; set; }

        /// <summary>
        ///  Set or get the AVISO_CONTRA property.
        /// </summary>

        public string AVISO_CONTRA { get; set; }

        /// <summary>
        ///  Set or get the AVISO_OT property.
        /// </summary>

        public string AVISO_OT { get; set; }

        /// <summary>
        ///  Set or get the AGRUPA_XSPO_CLI property.
        /// </summary>

        public byte? AGRUPA_XSPO_CLI { get; set; }

        /// <summary>
        ///  Set or get the MESVACA2 property.
        /// </summary>

        public byte? MESVACA2 { get; set; }

        /// <summary>
        ///  Set or get the RAC_CLI property.
        /// </summary>

        public byte? RAC_CLI { get; set; }

        /// <summary>
        ///  Set or get the CONCESIO_CLI property.
        /// </summary>

        public string CONCESIO_CLI { get; set; }

        /// <summary>
        ///  Set or get the N1944_YAENVIADO property.
        /// </summary>

        public byte? N1944_YAENVIADO { get; set; }

        /// <summary>
        ///  Set or get the EDI_CODIGO property.
        /// </summary>

        public string EDI_CODIGO { get; set; }

        /// <summary>
        ///  Set or get the SITUACION_RIESGO_CLI property.
        /// </summary>

        public string SITUACION_RIESGO_CLI { get; set; }

        /// <summary>
        ///  Set or get the CORPORATE property.
        /// </summary>

        public byte? CORPORATE { get; set; }

        /// <summary>
        ///  Set or get the CONCESIONARIO_CLI property.
        /// </summary>

        public string CONCESIONARIO_CLI { get; set; }

        /// <summary>
        ///  Set or get the OBS_KV property.
        /// </summary>

        public string OBS_KV { get; set; }

        /// <summary>
        ///  Set or get the REC_DESDE property.
        /// </summary>

        public DateTime? REC_DESDE { get; set; }

        /// <summary>
        ///  Set or get the REC_HASTA property.
        /// </summary>

        public DateTime? REC_HASTA { get; set; }

        /// <summary>
        ///  Set or get the DIASNATURALES property.
        /// </summary>

        public byte? DIASNATURALES { get; set; }

        /// <summary>
        ///  Set or get the NOIVA_ENBOLETIN property.
        /// </summary>

        public byte? NOIVA_ENBOLETIN { get; set; }

        /// <summary>
        ///  Set or get the TIPOCLIPV property.
        /// </summary>

        public Int16? TIPOCLIPV { get; set; }

        /// <summary>
        ///  Set or get the FACA_CLI property.
        /// </summary>

        public string FACA_CLI { get; set; }

        /// <summary>
        ///  Set or get the IMP_ENVIO property.
        /// </summary>

        public byte? IMP_ENVIO { get; set; }

        /// <summary>
        ///  Set or get the RAPPEL property.
        /// </summary>

        public Decimal? RAPPEL { get; set; }

        /// <summary>
        ///  Set or get the ALB_IVA property.
        /// </summary>

        public byte? ALB_IVA { get; set; }

        /// <summary>
        ///  Set or get the CARGOREPRE property.
        /// </summary>

        public string CARGOREPRE { get; set; }

        /// <summary>
        ///  Set or get the NOQUIERE property.
        /// </summary>

        public byte? NOQUIERE { get; set; }

        /// <summary>
        ///  Set or get the ALBARAN property.
        /// </summary>

        public string ALBARAN { get; set; }

        /// <summary>
        ///  Set or get the NOTITA property.
        /// </summary>

        public string NOTITA { get; set; }

        /// <summary>
        ///  Set or get the PLAZO4 property.
        /// </summary>

        public Int16? PLAZO4 { get; set; }

        /// <summary>
        ///  Set or get the PLAZO5 property.
        /// </summary>

        public Int16? PLAZO5 { get; set; }

        /// <summary>
        ///  Set or get the CALENDARIO_ESPECIAL property.
        /// </summary>

        public byte? CALENDARIO_ESPECIAL { get; set; }

        /// <summary>
        ///  Set or get the OCUPACION_CLI property.
        /// </summary>

        public string OCUPACION_CLI { get; set; }

        /// <summary>
        ///  Set or get the ESTADOCIVIL_CLI property.
        /// </summary>

        public string ESTADOCIVIL_CLI { get; set; }

        /// <summary>
        ///  Set or get the RESIDENCIA_CLI property.
        /// </summary>

        public string RESIDENCIA_CLI { get; set; }

        /// <summary>
        ///  Set or get the NACIO_CLI property.
        /// </summary>

        public string NACIO_CLI { get; set; }

        /// <summary>
        ///  Set or get the ENTIDAD_CLI property.
        /// </summary>

        public string ENTIDAD_CLI { get; set; }

        /// <summary>
        ///  Set or get the MONEDA_CLI property.
        /// </summary>

        public string MONEDA_CLI { get; set; }

        /// <summary>
        ///  Set or get the FINITRABAJO_CLI property.
        /// </summary>

        public DateTime? FINITRABAJO_CLI { get; set; }

        /// <summary>
        ///  Set or get the ROI property.
        /// </summary>

        public byte? ROI { get; set; }

        /// <summary>
        ///  Set or get the SEXO_MBF property.
        /// </summary>

        public string SEXO_MBF { get; set; }

        /// <summary>
        ///  Set or get the COREB2B property.
        /// </summary>

        public byte? COREB2B { get; set; }

        /// <summary>
        ///  Set or get the MOTIVO_COREB2B property.
        /// </summary>

        public string MOTIVO_COREB2B { get; set; }

        /// <summary>
        ///  Set or get the FECHA_COREB2B property.
        /// </summary>

        public DateTime? FECHA_COREB2B { get; set; }

        /// <summary>
        ///  Set or get the VOLUMEN_CLI property.
        /// </summary>

        public Int32? VOLUMEN_CLI { get; set; }

        /// <summary>
        ///  Set or get the Ntrabaja_cli property.
        /// </summary>

        public Int32? Ntrabaja_cli { get; set; }

        /// <summary>
        ///  Set or get the NMANDATO property.
        /// </summary>

        public string NMANDATO { get; set; }

        /// <summary>
        ///  Set or get the DURAMANDATO_CLI property.
        /// </summary>

        public string DURAMANDATO_CLI { get; set; }

        /// <summary>
        ///  Set or get the CARTA_AUTORIZA_ENVIADA property.
        /// </summary>

        public DateTime? CARTA_AUTORIZA_ENVIADA { get; set; }

        /// <summary>
        ///  Set or get the NO_USAR_FCOBRO property.
        /// </summary>

        public byte? NO_USAR_FCOBRO { get; set; }

        /// <summary>
        ///  Set or get the SEPA_INDIVIDUAL property.
        /// </summary>

        public byte? SEPA_INDIVIDUAL { get; set; }

        /// <summary>
        ///  Set or get the OMITIR_GENERAL_ENVIO_FAC property.
        /// </summary>

        public byte? OMITIR_GENERAL_ENVIO_FAC { get; set; }

        /// <summary>
        ///  Set or get the CTA651 property.
        /// </summary>

        public string CTA651 { get; set; }

        /// <summary>
        ///  Set or get the CCOSTE_CLI property.
        /// </summary>

        public string CCOSTE_CLI { get; set; }

        /// <summary>
        ///  Set or get the NOFACTURAR_PRIMERA_CUOTA_AUT property.
        /// </summary>

        public byte? NOFACTURAR_PRIMERA_CUOTA_AUT { get; set; }

        /// <summary>
        ///  Set or get the IMP_RESTA_LIQUIDA property.
        /// </summary>

        public Decimal? IMP_RESTA_LIQUIDA { get; set; }

        /// <summary>
        ///  Set or get the SALIR property.
        /// </summary>

        public byte? SALIR { get; set; }

        /// <summary>
        ///  Set or get the FEC_FACTURA_ULTMES property.
        /// </summary>

        public byte? FEC_FACTURA_ULTMES { get; set; }

        /// <summary>
        ///  Set or get the PROVISIONADA property.
        /// </summary>

        public Decimal? PROVISIONADA { get; set; }

        /// <summary>
        ///  Set or get the TIPOBLOQUEO property.
        /// </summary>

        public string TIPOBLOQUEO { get; set; }

        /// <summary>
        ///  Set or get the NO_ENVIAR_ESKER property.
        /// </summary>

        public byte? NO_ENVIAR_ESKER { get; set; }

        /// <summary>
        ///  Set or get the NO_REGISTRO_VIES property.
        /// </summary>

        public byte? NO_REGISTRO_VIES { get; set; }

        /// <summary>
        ///  Set or get the EXPORTA_EXCEL_FAC property.
        /// </summary>

        public byte? EXPORTA_EXCEL_FAC { get; set; }

        /// <summary>
        ///  Set or get the ES_CIA_SEGU property.
        /// </summary>

        public byte? ES_CIA_SEGU { get; set; }

        /// <summary>
        ///  Set or get the FACTURAE_CL1 property.
        /// </summary>

        public byte? FACTURAE_CL1 { get; set; }

        /// <summary>
        ///  Set or get the FACE_OFI_CONTABLE_CLI property.
        /// </summary>

        public string FACE_OFI_CONTABLE_CLI { get; set; }

        /// <summary>
        ///  Set or get the FACE_ORGANO_GESTOR_CLI property.
        /// </summary>

        public string FACE_ORGANO_GESTOR_CLI { get; set; }

        /// <summary>
        ///  Set or get the FACE_UNI_TRAMITADORA_CLI property.
        /// </summary>

        public string FACE_UNI_TRAMITADORA_CLI { get; set; }

        /// <summary>
        ///  Set or get the BLOQUEADO_CLI property.
        /// </summary>

        public byte? BLOQUEADO_CLI { get; set; }

        /// <summary>
        ///  Set or get the TXT_ENFRA_CLI property.
        /// </summary>

        public string TXT_ENFRA_CLI { get; set; }

        /// <summary>
        ///  Set or get the NOENCUESTA property.
        /// </summary>

        public byte? NOENCUESTA { get; set; }

        /// <summary>
        ///  Set or get the SON_AUTOFACS property.
        /// </summary>

        public byte? SON_AUTOFACS { get; set; }

        /// <summary>
        ///  Set or get the DEPO_GARAN property.
        /// </summary>

        public Decimal? DEPO_GARAN { get; set; }

        /// <summary>
        ///  Set or get the VTO_FIN_MES property.
        /// </summary>

        public byte? VTO_FIN_MES { get; set; }

        /// <summary>
        ///  Set or get the FACE_MODELO property.
        /// </summary>

        public byte? FACE_MODELO { get; set; }

        /// <summary>
        ///  Set or get the FACE_MATRI property.
        /// </summary>

        public byte? FACE_MATRI { get; set; }

        /// <summary>
        ///  Set or get the FACE_BASTIDOR property.
        /// </summary>

        public byte? FACE_BASTIDOR { get; set; }

        /// <summary>
        ///  Set or get the FACE_UBICA property.
        /// </summary>

        public byte? FACE_UBICA { get; set; }

        /// <summary>
        ///  Set or get the NOFACTURAR_CLI property.
        /// </summary>

        public byte? NOFACTURAR_CLI { get; set; }

        /// <summary>
        ///  Set or get the NO_FAC_MULTAS property.
        /// </summary>

        public byte? NO_FAC_MULTAS { get; set; }

        /// <summary>
        ///  Set or get the PRECIOS_LIQUIDA_CLI property.
        /// </summary>

        public byte? PRECIOS_LIQUIDA_CLI { get; set; }

        /// <summary>
        ///  Set or get the TIREPA_CLI property.
        /// </summary>

        public string TIREPA_CLI { get; set; }

        /// <summary>
        ///  Set or get the DIA4 property.
        /// </summary>

        public byte? DIA4 { get; set; }

        /// <summary>
        ///  Set or get the FACTURANDO_SRV_CLI property.
        /// </summary>

        public byte? FACTURANDO_SRV_CLI { get; set; }

        /// <summary>
        ///  Set or get the CODIGOEXTERNO property.
        /// </summary>

        public string CODIGOEXTERNO { get; set; }

        /// <summary>
        ///  Set or get the USUWEB_CLI property.
        /// </summary>

        public string USUWEB_CLI { get; set; }

        /// <summary>
        ///  Set or get the PWWEB_CLI property.
        /// </summary>

        public string PWWEB_CLI { get; set; }

        /// <summary>
        ///  Set or get the AUTORIDADDNI property.
        /// </summary>

        public string AUTORIDADDNI { get; set; }

        /// <summary>
        ///  Set or get the NACIODNI property.
        /// </summary>

        public string NACIODNI { get; set; }

        /// <summary>
        ///  Set or get the FECADUDNI property.
        /// </summary>

        public DateTime? FECADUDNI { get; set; }

        /// <summary>
        ///  Set or get the SALUDO property.
        /// </summary>

        public string SALUDO { get; set; }

        /// <summary>
        ///  Set or get the BROKER property.
        /// </summary>

        public byte? BROKER { get; set; }

        /// <summary>
        ///  Set or get the FECHA_EXE_MOROSO property.
        /// </summary>

        public DateTime? FECHA_EXE_MOROSO { get; set; }

        /// <summary>
        ///  Set or get the RECIBOS_EXE_MOROSO property.
        /// </summary>

        public string RECIBOS_EXE_MOROSO { get; set; }

        /// <summary>
        ///  Set or get the ENVIAR_A_CLI property.
        /// </summary>

        public string ENVIAR_A_CLI { get; set; }

        /// <summary>
        ///  Set or get the DESTINATARIO_CLI property.
        /// </summary>

        public string DESTINATARIO_CLI { get; set; }

        /// <summary>
        ///  Set or get the EXPEDIENTE_CLI property.
        /// </summary>

        public string EXPEDIENTE_CLI { get; set; }

        /// <summary>
        ///  Set or get the VIS_CADA property.
        /// </summary>

        public Int32? VIS_CADA { get; set; }

        /// <summary>
        ///  Set or get the TIPOESCRITURA property.
        /// </summary>

        public string TIPOESCRITURA { get; set; }

        /// <summary>
        ///  Set or get the PARTITA_IVA property.
        /// </summary>

        public string PARTITA_IVA { get; set; }

        /// <summary>
        ///  Set or get the VISITASRARAS property.
        /// </summary>

        public byte? VISITASRARAS { get; set; }

        /// <summary>
        ///  Set or get the NOTAS_TRASNPORTE_CLI property.
        /// </summary>

        public string NOTAS_TRASNPORTE_CLI { get; set; }

        /// <summary>
        ///  Set or get the SEGUIMIENTO_ALB_CLI1 property.
        /// </summary>

        public byte? SEGUIMIENTO_ALB_CLI1 { get; set; }

        /// <summary>
        ///  Set or get the TRATO_CCO_CLI1 property.
        /// </summary>

        public string TRATO_CCO_CLI1 { get; set; }

        /// <summary>
        ///  Set or get the CLICOMER_C1 property.
        /// </summary>

        public Int32? CLICOMER_C1 { get; set; }

        /// <summary>
        ///  Set or get the CARTA_AUTORIZA_ENVIADA2 property.
        /// </summary>

        public DateTime? CARTA_AUTORIZA_ENVIADA2 { get; set; }

        /// <summary>
        ///  Set or get the CARTA_AUTORIZA_RECIBIDA2 property.
        /// </summary>

        public DateTime? CARTA_AUTORIZA_RECIBIDA2 { get; set; }

        /// <summary>
        ///  Set or get the FACE_DEPARTA_CLI property.
        /// </summary>

        public string FACE_DEPARTA_CLI { get; set; }

        /// <summary>
        ///  Set or get the FACTERCEROS_CLI property.
        /// </summary>

        public byte? FACTERCEROS_CLI { get; set; }

        /// <summary>
        ///  Set or get the NOCENSADO_CLI property.
        /// </summary>

        public byte? NOCENSADO_CLI { get; set; }

        /// <summary>
        ///  Set or get the EXPEDIENTE_FISCAL_CLI property.
        /// </summary>

        public string EXPEDIENTE_FISCAL_CLI { get; set; }

        /// <summary>
        ///  Set or get the SERVICIOS_CLI property.
        /// </summary>

        public byte? SERVICIOS_CLI { get; set; }

        /// <summary>
        ///  Set or get the ES_IDIADA_CLI property.
        /// </summary>

        public byte? ES_IDIADA_CLI { get; set; }

        /// <summary>
        ///  Set or get the CTA438 property.
        /// </summary>

        public string CTA438 { get; set; }

        /// <summary>
        ///  Set or get the CTA560 property.
        /// </summary>

        public string CTA560 { get; set; }

        /// <summary>
        ///  Set or get the CTA485 property.
        /// </summary>

        public string CTA485 { get; set; }

        /// <summary>
        ///  Set or get the CTA439 property.
        /// </summary>

        public string CTA439 { get; set; }

        /// <summary>
        ///  Set or get the AENA_CLUB property.
        /// </summary>

        public string AENA_CLUB { get; set; }

        /// <summary>
        ///  Set or get the CARGADO_CLI property.
        /// </summary>

        public byte? CARGADO_CLI { get; set; }

        /// <summary>
        ///  Set or get the SALDO_PEND_CLI property.
        /// </summary>

        public Decimal? SALDO_PEND_CLI { get; set; }

        /// <summary>
        ///  Set or get the ENVIAR_FACTURA_VTA property.
        /// </summary>

        public byte? ENVIAR_FACTURA_VTA { get; set; }

        /// <summary>
        ///  Set or get the DTO_SEGUNNUMVEHI property.
        /// </summary>

        public Decimal? DTO_SEGUNNUMVEHI { get; set; }

        /// <summary>
        ///  Set or get the NUMVEHI property.
        /// </summary>

        public Int32? NUMVEHI { get; set; }

        /// <summary>
        ///  Set or get the CENTRO_TRABAJO_CLI property.
        /// </summary>

        public string CENTRO_TRABAJO_CLI { get; set; }

        /// <summary>
        ///  Set or get the USUWEB property.
        /// </summary>

        public string USUWEB { get; set; }

        /// <summary>
        ///  Set or get the PWWEB property.
        /// </summary>

        public string PWWEB { get; set; }

        /// <summary>
        ///  Set or get the HORAS_DESPLAZA property.
        /// </summary>

        public Decimal? HORAS_DESPLAZA { get; set; }

        /// <summary>
        ///  Set or get the TIPO_DOCU_FU_CL1 property.
        /// </summary>

        public byte? TIPO_DOCU_FU_CL1 { get; set; }

        /// <summary>
        ///  Set or get the ENVIO_MAIL_ALB_FIRMADO_CLI1 property.
        /// </summary>

        public byte? ENVIO_MAIL_ALB_FIRMADO_CLI1 { get; set; }

        /// <summary>
        ///  Set or get the TEXTO_EN_FACTURA_CLI property.
        /// </summary>

        public string TEXTO_EN_FACTURA_CLI { get; set; }

        /// <summary>
        ///  Set or get the NO_COND_ENFAC_CLI property.
        /// </summary>

        public byte? NO_COND_ENFAC_CLI { get; set; }

        /// <summary>
        ///  Set or get the NO_MODELO_ENFAC_CLI property.
        /// </summary>

        public byte? NO_MODELO_ENFAC_CLI { get; set; }

        /// <summary>
        ///  Set or get the NO_ENVIAR_MAIL_AUT_FAC property.
        /// </summary>

        public byte? NO_ENVIAR_MAIL_AUT_FAC { get; set; }

        /// <summary>
        ///  Set or get the CTA180 property.
        /// </summary>

        public string CTA180 { get; set; }

        /// <summary>
        ///  Set or get the CORTA property.
        /// </summary>

        public byte? CORTA { get; set; }

        /// <summary>
        ///  Set or get the LARGA property.
        /// </summary>

        public byte? LARGA { get; set; }

        /// <summary>
        ///  Set or get the CUENTA property.
        /// </summary>

        public string CUENTA { get; set; }

        /// <summary>
        ///  Set or get the FPAGO property.
        /// </summary>

        public byte? FPAGO { get; set; }

        /// <summary>
        ///  Set or get the ALTA property.
        /// </summary>

        public DateTime? ALTA { get; set; }

        /// <summary>
        ///  Set or get the ULTMODI property.
        /// </summary>

        public string ULTMODI { get; set; }

        /// <summary>
        ///  Set or get the COMISIO property.
        /// </summary>

        public string COMISIO { get; set; }

        /// <summary>
        ///  Set or get the SEGURO property.
        /// </summary>

        public string SEGURO { get; set; }

        /// <summary>
        ///  Set or get the CENTRO property.
        /// </summary>

        public string CENTRO { get; set; }

        /// <summary>
        ///  Set or get the PRODUCTO property.
        /// </summary>

        public string PRODUCTO { get; set; }

        /// <summary>
        ///  Set or get the SECTOR property.
        /// </summary>

        public string SECTOR { get; set; }

        /// <summary>
        ///  Set or get the ZONA property.
        /// </summary>

        public string ZONA { get; set; }

        /// <summary>
        ///  Set or get the VENDEDOR property.
        /// </summary>

        public string VENDEDOR { get; set; }

        /// <summary>
        ///  Set or get the ORIGEN property.
        /// </summary>

        public Int32? ORIGEN { get; set; }

        /// <summary>
        ///  Set or get the MARCA property.
        /// </summary>

        public string MARCA { get; set; }

        /// <summary>
        ///  Set or get the ENVIAR property.
        /// </summary>

        public byte? ENVIAR { get; set; }

        /// <summary>
        ///  Set or get the REPRELEGAL property.
        /// </summary>

        public string REPRELEGAL { get; set; }

        /// <summary>
        ///  Set or get the RIESGO property.
        /// </summary>

        public string RIESGO { get; set; }

        /// <summary>
        ///  Set or get the COMERCIAL property.
        /// </summary>

        public string COMERCIAL { get; set; }

        /// <summary>
        ///  Set or get the CONTABLE property.
        /// </summary>

        public string CONTABLE { get; set; }

        /// <summary>
        ///  Set or get the TIPOCLI property.
        /// </summary>

        public string TIPOCLI { get; set; }

        /// <summary>
        ///  Set or get the SUBLICEN property.
        /// </summary>

        public string SUBLICEN { get; set; }

        /// <summary>
        ///  Set or get the OFICINA property.
        /// </summary>

        public string OFICINA { get; set; }

        /// <summary>
        ///  Set or get the IMPOCON property.
        /// </summary>

        public byte? IMPOCON { get; set; }

        /// <summary>
        ///  Set or get the PERIODICI property.
        /// </summary>

        public string PERIODICI { get; set; }

        /// <summary>
        ///  Set or get the DIASEMA property.
        /// </summary>

        public string DIASEMA { get; set; }

        /// <summary>
        ///  Set or get the DIAMES property.
        /// </summary>

        public byte? DIAMES { get; set; }

        /// <summary>
        ///  Set or get the CENTRALIZA property.
        /// </summary>

        public string CENTRALIZA { get; set; }

        /// <summary>
        ///  Set or get the ULTIMO property.
        /// </summary>

        public DateTime? ULTIMO { get; set; }

        /// <summary>
        ///  Set or get the USUARIO property.
        /// </summary>

        public string USUARIO { get; set; }

        /// <summary>
        ///  Set or get the MERCADO property.
        /// </summary>

        public string MERCADO { get; set; }

        /// <summary>
        ///  Set or get the CANAL property.
        /// </summary>

        public string CANAL { get; set; }

        /// <summary>
        ///  Set or get the NEGOCIO property.
        /// </summary>

        public string NEGOCIO { get; set; }

        /// <summary>
        ///  Set or get the CPFRA property.
        /// </summary>

        public string CPFRA { get; set; }

        /// <summary>
        ///  Set or get the DIRFRA property.
        /// </summary>

        public string DIRFRA { get; set; }

        /// <summary>
        ///  Set or get the POBFRA property.
        /// </summary>

        public string POBFRA { get; set; }

        /// <summary>
        ///  Set or get the PROVFRA property.
        /// </summary>

        public string PROVFRA { get; set; }

        /// <summary>
        ///  Set or get the CLAVEPPTO property.
        /// </summary>

        public string CLAVEPPTO { get; set; }

        /// <summary>
        ///  Set or get the EMAIL property.
        /// </summary>

        public string EMAIL { get; set; }

        /// <summary>
        ///  Set or get the WEB property.
        /// </summary>

        public string WEB { get; set; }

        /// <summary>
        ///  Set or get the PAISFRA property.
        /// </summary>

        public string PAISFRA { get; set; }

        /// <summary>
        ///  Set or get the TEL1FRA property.
        /// </summary>

        public string TEL1FRA { get; set; }

        /// <summary>
        ///  Set or get the TEL2FRA property.
        /// </summary>

        public string TEL2FRA { get; set; }

        /// <summary>
        ///  Set or get the FAXFRA property.
        /// </summary>

        public string FAXFRA { get; set; }

        /// <summary>
        ///  Set or get the NIF_REP property.
        /// </summary>

        public string NIF_REP { get; set; }

        /// <summary>
        ///  Set or get the TEL1RE property.
        /// </summary>

        public string TEL1RE { get; set; }

        /// <summary>
        ///  Set or get the TEL2RE property.
        /// </summary>

        public string TEL2RE { get; set; }

        /// <summary>
        ///  Set or get the FAXRE property.
        /// </summary>

        public string FAXRE { get; set; }

        /// <summary>
        ///  Set or get the CONTACTO property.
        /// </summary>

        public string CONTACTO { get; set; }

        /// <summary>
        ///  Set or get the CONTRA_IMPORTES_SIN_VALORAR property.
        /// </summary>

        public byte? CONTRA_IMPORTES_SIN_VALORAR { get; set; }

        /// <summary>
        ///  Set or get the RIESGOIMP property.
        /// </summary>

        public Double? RIESGOIMP { get; set; }

        /// <summary>
        ///  Set or get the REPREDNI property.
        /// </summary>

        public string REPREDNI { get; set; }

        /// <summary>
        ///  Set or get the REPRETEL property.
        /// </summary>

        public string REPRETEL { get; set; }

        /// <summary>
        ///  Set or get the REPREDIR property.
        /// </summary>

        public string REPREDIR { get; set; }

        /// <summary>
        ///  Set or get the REPREPOB property.
        /// </summary>

        public string REPREPOB { get; set; }

        /// <summary>
        ///  Set or get the PODERFECHA property.
        /// </summary>

        public DateTime? PODERFECHA { get; set; }

        /// <summary>
        ///  Set or get the PODERNOTARIO property.
        /// </summary>

        public string PODERNOTARIO { get; set; }

        /// <summary>
        ///  Set or get the PODERPOBLA property.
        /// </summary>

        public string PODERPOBLA { get; set; }

        /// <summary>
        ///  Set or get the PODERPROTO property.
        /// </summary>

        public string PODERPROTO { get; set; }

        /// <summary>
        ///  Set or get the FECHACONTRA property.
        /// </summary>

        public DateTime? FECHACONTRA { get; set; }

        /// <summary>
        ///  Set or get the DIRFRA2 property.
        /// </summary>

        public string DIRFRA2 { get; set; }

        /// <summary>
        ///  Set or get the CONTABLEDTO property.
        /// </summary>

        public string CONTABLEDTO { get; set; }

        /// <summary>
        ///  Set or get the CONTRAMARCO property.
        /// </summary>

        public string CONTRAMARCO { get; set; }

        /// <summary>
        ///  Set or get the CUENTA431 property.
        /// </summary>

        public string CUENTA431 { get; set; }

        /// <summary>
        ///  Set or get the DIRCLIENTE property.
        /// </summary>

        public string DIRCLIENTE { get; set; }

        /// <summary>
        ///  Set or get the OLDNUMCLI property.
        /// </summary>

        public string OLDNUMCLI { get; set; }

        /// <summary>
        ///  Set or get the NEWNUMCLI property.
        /// </summary>

        public string NEWNUMCLI { get; set; }

        /// <summary>
        ///  Set or get the FACKMEX property.
        /// </summary>

        public byte? FACKMEX { get; set; }

        /// <summary>
        ///  Set or get the FACKMDEF property.
        /// </summary>

        public byte? FACKMDEF { get; set; }

        /// <summary>
        ///  Set or get the COMEN_SEGU property.
        /// </summary>

        public string COMEN_SEGU { get; set; }

        /// <summary>
        ///  Set or get the NUM_TERMINAL property.
        /// </summary>

        public string NUM_TERMINAL { get; set; }

        /// <summary>
        ///  Set or get the NOMBRE_CONTRA property.
        /// </summary>

        public string NOMBRE_CONTRA { get; set; }

        /// <summary>
        ///  Set or get the MAIL_CONTRA property.
        /// </summary>

        public string MAIL_CONTRA { get; set; }

        /// <summary>
        ///  Set or get the FIRMA_CONTRA property.
        /// </summary>

        public string FIRMA_CONTRA { get; set; }

        /// <summary>
        ///  Set or get the BANCO_CONTRA property.
        /// </summary>

        public string BANCO_CONTRA { get; set; }

        /// <summary>
        ///  Set or get the CCC_CONTRA property.
        /// </summary>

        public string CCC_CONTRA { get; set; }

        /// <summary>
        ///  Set or get the DNI_CONTRA property.
        /// </summary>

        public string DNI_CONTRA { get; set; }

        /// <summary>
        ///  Set or get the FMARCO_CONTRA property.
        /// </summary>

        public DateTime? FMARCO_CONTRA { get; set; }

        /// <summary>
        ///  Set or get the NOTIFICA_CONTRA property.
        /// </summary>

        public string NOTIFICA_CONTRA { get; set; }

        /// <summary>
        ///  Set or get the COMER_MAOTRAS property.
        /// </summary>

        public byte? COMER_MAOTRAS { get; set; }

        /// <summary>
        ///  Set or get the COMER_MAOTRAS_TL property.
        /// </summary>

        public byte? COMER_MAOTRAS_TL { get; set; }

        /// <summary>
        ///  Set or get the COMER_MAPILAD property.
        /// </summary>

        public byte? COMER_MAPILAD { get; set; }

        /// <summary>
        ///  Set or get the COMER_MAPILAD_TL property.
        /// </summary>

        public byte? COMER_MAPILAD_TL { get; set; }

        /// <summary>
        ///  Set or get the COMER_MATOT_ALQ property.
        /// </summary>

        public byte? COMER_MATOT_ALQ { get; set; }

        /// <summary>
        ///  Set or get the COMER_MATOT_TL property.
        /// </summary>

        public byte? COMER_MATOT_TL { get; set; }

        /// <summary>
        ///  Set or get the COMER_MCFDIES property.
        /// </summary>

        public byte? COMER_MCFDIES { get; set; }

        /// <summary>
        ///  Set or get the COMER_MCFDIES_TL property.
        /// </summary>

        public byte? COMER_MCFDIES_TL { get; set; }

        /// <summary>
        ///  Set or get the COMER_MCFELEC property.
        /// </summary>

        public byte? COMER_MCFELEC { get; set; }

        /// <summary>
        ///  Set or get the COMER_MCFELEC_TL property.
        /// </summary>

        public byte? COMER_MCFELEC_TL { get; set; }

        /// <summary>
        ///  Set or get the COMER_MCRETRA property.
        /// </summary>

        public byte? COMER_MCRETRA { get; set; }

        /// <summary>
        ///  Set or get the COMER_MCRETRA_TL property.
        /// </summary>

        public byte? COMER_MCRETRA_TL { get; set; }

        /// <summary>
        ///  Set or get the COMER_MCTTERR property.
        /// </summary>

        public byte? COMER_MCTTERR { get; set; }

        /// <summary>
        ///  Set or get the COMER_MCTTERR_TL property.
        /// </summary>

        public byte? COMER_MCTTERR_TL { get; set; }

        /// <summary>
        ///  Set or get the COMER_MPLATAF property.
        /// </summary>

        public byte? COMER_MPLATAF { get; set; }

        /// <summary>
        ///  Set or get the COMER_MPLATAF_TL property.
        /// </summary>

        public byte? COMER_MPLATAF_TL { get; set; }

        /// <summary>
        ///  Set or get the COMER_MTRANSE property.
        /// </summary>

        public byte? COMER_MTRANSE { get; set; }

        /// <summary>
        ///  Set or get the COMER_MTRANSE_TL property.
        /// </summary>

        public byte? COMER_MTRANSE_TL { get; set; }

        /// <summary>
        ///  Set or get the COMER_MTRANSM property.
        /// </summary>

        public byte? COMER_MTRANSM { get; set; }

        /// <summary>
        ///  Set or get the COMER_MTRANSM_TL property.
        /// </summary>

        public byte? COMER_MTRANSM_TL { get; set; }

        /// <summary>
        ///  Set or get the COMER_TELES property.
        /// </summary>

        public byte? COMER_TELES { get; set; }

        /// <summary>
        ///  Set or get the COMER_TELES_TL property.
        /// </summary>

        public byte? COMER_TELES_TL { get; set; }

        /// <summary>
        ///  Set or get the LIB_COMPRALIB property.
        /// </summary>

        public byte? LIB_COMPRALIB { get; set; }

        /// <summary>
        ///  Set or get the LIB_COMPRAREV property.
        /// </summary>

        public byte? LIB_COMPRAREV { get; set; }

        /// <summary>
        ///  Set or get the LIB_PROVEELIB property.
        /// </summary>

        public string LIB_PROVEELIB { get; set; }

        /// <summary>
        ///  Set or get the LIB_PROVEEREV property.
        /// </summary>

        public string LIB_PROVEEREV { get; set; }

        /// <summary>
        ///  Set or get the LIB_VOLUMENLIB property.
        /// </summary>

        public string LIB_VOLUMENLIB { get; set; }

        /// <summary>
        ///  Set or get the LIB_VOLUMENREV property.
        /// </summary>

        public string LIB_VOLUMENREV { get; set; }

        /// <summary>
        ///  Set or get the CAMBIO_VENDE property.
        /// </summary>

        public DateTime? CAMBIO_VENDE { get; set; }

        /// <summary>
        ///  Set or get the PORCOMISIO_MESANOANT_MENOR_S2 property.
        /// </summary>

        public Decimal? PORCOMISIO_MESANOANT_MENOR_S2 { get; set; }

        /// <summary>
        ///  Set or get the PORCOMISIO_MESANOANT_MAYOR_S2 property.
        /// </summary>

        public Decimal? PORCOMISIO_MESANOANT_MAYOR_S2 { get; set; }

        /// <summary>
        ///  Set or get the VEND_REFAC property.
        /// </summary>

        public string VEND_REFAC { get; set; }

        /// <summary>
        ///  Set or get the VEND_SERV property.
        /// </summary>

        public string VEND_SERV { get; set; }

        /// <summary>
        ///  Set or get the VEND_VENTA property.
        /// </summary>

        public string VEND_VENTA { get; set; }

        /// <summary>
        ///  Set or get the EMAILFAC property.
        /// </summary>

        public string EMAILFAC { get; set; }

        /// <summary>
        ///  Set or get the IDFOTO property.
        /// </summary>

        public Int32? IDFOTO { get; set; }

        /// <summary>
        ///  Set or get the EMAIL_MAN property.
        /// </summary>

        public string EMAIL_MAN { get; set; }

        /// <summary>
        ///  Set or get the DIAS_MAX_CREDITO property.
        /// </summary>

        public Decimal? DIAS_MAX_CREDITO { get; set; }

        /// <summary>
        ///  Set or get the CTARETEN_CLI property.
        /// </summary>

        public string CTARETEN_CLI { get; set; }

        /// <summary>
        ///  Set or get the ISP_CLI property.
        /// </summary>

        public byte? ISP_CLI { get; set; }

        /// <summary>
        ///  Set or get the PERSONA_FRA property.
        /// </summary>

        public string PERSONA_FRA { get; set; }

        /// <summary>
        ///  Set or get the CARGOREPRELEGAL property.
        /// </summary>

        public string CARGOREPRELEGAL { get; set; }

        /// <summary>
        ///  Set or get the RETEN_ITMBS property.
        /// </summary>

        public byte? RETEN_ITMBS { get; set; }

        /// <summary>
        ///  Set or get the OBJETIVOFAC property.
        /// </summary>

        public Decimal? OBJETIVOFAC { get; set; }

        /// <summary>
        ///  Set or get the SINPERMISODECONDUCIR property.
        /// </summary>

        public byte? SINPERMISODECONDUCIR { get; set; }

        /// <summary>
        ///  Set or get the CLASI_CLI property.
        /// </summary>

        public Int32? CLASI_CLI { get; set; }

        /// <summary>
        ///  Set or get the RIESGOIMP2 property.
        /// </summary>

        public Double? RIESGOIMP2 { get; set; }

        /// <summary>
        ///  Visit dto.
        /// </summary>
        public IEnumerable<VisitsDto> VisitsDto { get; set; }
        /// <summary>
        /// Contacts dto.
        /// </summary>
        public IEnumerable<ContactsDto> ContactsDto { get; set; }
        /// <summary>
        /// BranchesDto
        /// </summary>
        public IEnumerable<BranchesDto> BranchesDto { get; set; }

    }
}