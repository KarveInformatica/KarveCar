using KarveDataServices.DataTransferObject;
using System;

namespace KarveDataServices.DataObjects
{

    // FIXME: put the referencies to a contract/ client and so on.
    /// <summary>
    ///  Data trasnfer object for modeling the invoice.
    /// </summary>
    public class InvoiceDto : BaseDto
    {
        /// <summary>
        ///  Invoice data transfer object.
        /// </summary>

        public string NUMERO_FAC { get; set; }

        /// <summary>
        ///  Set or get the FECHA_FAC property.
        /// </summary>

        public DateTime? FECHA_FAC { get; set; }

        /// <summary>
        ///  Set or get the CLIENTE_FAC property.
        /// </summary>

        public string CLIENTE_FAC { get; set; }

        /// <summary>
        ///  Set or get the BRUTO_FAC property.
        /// </summary>

        public Decimal? BRUTO_FAC { get; set; }

        /// <summary>
        ///  Set or get the BASE_FAC property.
        /// </summary>

        public Decimal? BASE_FAC { get; set; }

        /// <summary>
        ///  Set or get the IVAPOR_FAC property.
        /// </summary>

        public Decimal? IVAPOR_FAC { get; set; }

        /// <summary>
        ///  Set or get the CUOTA_FAC property.
        /// </summary>

        public Decimal? CUOTA_FAC { get; set; }

        /// <summary>
        ///  Set or get the TODO_FAC property.
        /// </summary>

        public Decimal? TODO_FAC { get; set; }

        /// <summary>
        ///  Set or get the VTO1_FAC property.
        /// </summary>

        public DateTime? VTO1_FAC { get; set; }

        /// <summary>
        ///  Set or get the VTO2_FAC property.
        /// </summary>

        public DateTime? VTO2_FAC { get; set; }

        /// <summary>
        ///  Set or get the VTO3_FAC property.
        /// </summary>

        public DateTime? VTO3_FAC { get; set; }

        /// <summary>
        ///  Set or get the IMP1_FAC property.
        /// </summary>

        public Decimal? IMP1_FAC { get; set; }

        /// <summary>
        ///  Set or get the IMP2_FAC property.
        /// </summary>

        public Decimal? IMP2_FAC { get; set; }

        /// <summary>
        ///  Set or get the IMP3_FAC property.
        /// </summary>

        public Decimal? IMP3_FAC { get; set; }

        /// <summary>
        ///  Set or get the DTO_FAC property.
        /// </summary>

        public string DTO_FAC { get; set; }

        /// <summary>
        ///  Set or get the FPAGO_FAC property.
        /// </summary>

        public byte? FPAGO_FAC { get; set; }

        /// <summary>
        ///  Set or get the VENDEDOR_FAC property.
        /// </summary>

        public string VENDEDOR_FAC { get; set; }

        /// <summary>
        ///  Set or get the BANCO_FAC property.
        /// </summary>

        public string BANCO_FAC { get; set; }

        /// <summary>
        ///  Set or get the REFEREN_FAC property.
        /// </summary>

        public string REFEREN_FAC { get; set; }

        /// <summary>
        ///  Set or get the CUBANCO_FAC property.
        /// </summary>

        public string CUBANCO_FAC { get; set; }

        /// <summary>
        ///  Set or get the SUBLICEN_FAC property.
        /// </summary>

        public string SUBLICEN_FAC { get; set; }

        /// <summary>
        ///  Set or get the ULTMODI_FAC property.
        /// </summary>

        public string ULTMODI_FAC { get; set; }

        /// <summary>
        ///  Set or get the USUARIO_FAC property.
        /// </summary>

        public string USUARIO_FAC { get; set; }

        /// <summary>
        ///  Set or get the OFICINA_FAC property.
        /// </summary>

        public string OFICINA_FAC { get; set; }

        /// <summary>
        ///  Set or get the MONEDA property.
        /// </summary>

        public string MONEDA { get; set; }

        /// <summary>
        ///  Set or get the CLIENTE_REAL_FAC property.
        /// </summary>

        public string CLIENTE_REAL_FAC { get; set; }

        /// <summary>
        ///  Set or get the ASIENTO_FAC property.
        /// </summary>

        public string ASIENTO_FAC { get; set; }

        /// <summary>
        ///  Set or get the CONTRATO_FAC property.
        /// </summary>

        public string CONTRATO_FAC { get; set; }

        /// <summary>
        ///  Set or get the AUTOMATIC property.
        /// </summary>

        public string AUTOMATIC { get; set; }

        /// <summary>
        ///  Set or get the OBSERVACIONES_FAC property.
        /// </summary>

        public string OBSERVACIONES_FAC { get; set; }

        /// <summary>
        ///  Set or get the VIENEDE_FAC property.
        /// </summary>

        public byte? VIENEDE_FAC { get; set; }

        /// <summary>
        ///  Set or get the DTOPP property.
        /// </summary>

        public Decimal? DTOPP { get; set; }

        /// <summary>
        ///  Set or get the VTO4_FAC property.
        /// </summary>

        public DateTime? VTO4_FAC { get; set; }

        /// <summary>
        ///  Set or get the VTO5_FAC property.
        /// </summary>

        public DateTime? VTO5_FAC { get; set; }

        /// <summary>
        ///  Set or get the VTO6_FAC property.
        /// </summary>

        public DateTime? VTO6_FAC { get; set; }

        /// <summary>
        ///  Set or get the VTO7_FAC property.
        /// </summary>

        public DateTime? VTO7_FAC { get; set; }

        /// <summary>
        ///  Set or get the VTO8_FAC property.
        /// </summary>

        public DateTime? VTO8_FAC { get; set; }

        /// <summary>
        ///  Set or get the VTO9_FAC property.
        /// </summary>

        public DateTime? VTO9_FAC { get; set; }

        /// <summary>
        ///  Set or get the VTO10_FAC property.
        /// </summary>

        public DateTime? VTO10_FAC { get; set; }

        /// <summary>
        ///  Set or get the IMP4_FAC property.
        /// </summary>

        public Double? IMP4_FAC { get; set; }

        /// <summary>
        ///  Set or get the IMP5_FAC property.
        /// </summary>

        public Double? IMP5_FAC { get; set; }

        /// <summary>
        ///  Set or get the IMP6_FAC property.
        /// </summary>

        public Double? IMP6_FAC { get; set; }

        /// <summary>
        ///  Set or get the IMP7_FAC property.
        /// </summary>

        public Double? IMP7_FAC { get; set; }

        /// <summary>
        ///  Set or get the IMP8_FAC property.
        /// </summary>

        public Double? IMP8_FAC { get; set; }

        /// <summary>
        ///  Set or get the IMP9_FAC property.
        /// </summary>

        public Double? IMP9_FAC { get; set; }

        /// <summary>
        ///  Set or get the IMP10_FAC property.
        /// </summary>

        public Double? IMP10_FAC { get; set; }

        /// <summary>
        ///  Set or get the BASESIN property.
        /// </summary>

        public Decimal? BASESIN { get; set; }

        /// <summary>
        ///  Set or get the EXPORTA_FAC property.
        /// </summary>

        public byte? EXPORTA_FAC { get; set; }

        /// <summary>
        ///  Set or get the CTAVENTAS_FAC property.
        /// </summary>

        public string CTAVENTAS_FAC { get; set; }

        /// <summary>
        ///  Set or get the FAC_MAN_FAC property.
        /// </summary>

        public byte? FAC_MAN_FAC { get; set; }

        /// <summary>
        ///  Set or get the NO_IVA_FAC property.
        /// </summary>

        public byte? NO_IVA_FAC { get; set; }

        /// <summary>
        ///  Set or get the PERSONA_FAC property.
        /// </summary>

        public string PERSONA_FAC { get; set; }

        /// <summary>
        ///  Set or get the ABONODE_FAC property.
        /// </summary>

        public string ABONODE_FAC { get; set; }

        /// <summary>
        ///  Set or get the CLI_DELEGA_FAC property.
        /// </summary>

        public string CLI_DELEGA_FAC { get; set; }

        /// <summary>
        ///  Set or get the ULTFECFRA_FAC property.
        /// </summary>

        public DateTime? ULTFECFRA_FAC { get; set; }

        /// <summary>
        ///  Set or get the FAC_RECTIF_POR property.
        /// </summary>

        public string FAC_RECTIF_POR { get; set; }

        /// <summary>
        ///  Set or get the LOGOENFAC property.
        /// </summary>

        public byte? LOGOENFAC { get; set; }

        /// <summary>
        ///  Set or get the IVAPOR2_FAC property.
        /// </summary>

        public Decimal? IVAPOR2_FAC { get; set; }

        /// <summary>
        ///  Set or get the BASE2_FAC property.
        /// </summary>

        public Double? BASE2_FAC { get; set; }

        /// <summary>
        ///  Set or get the CUOTA2_FAC property.
        /// </summary>

        public Double? CUOTA2_FAC { get; set; }

        /// <summary>
        ///  Set or get the FRATIPIMPR property.
        /// </summary>

        public byte? FRATIPIMPR { get; set; }

        /// <summary>
        ///  Set or get the NEGOCIO_FAC property.
        /// </summary>

        public byte? NEGOCIO_FAC { get; set; }

        /// <summary>
        ///  Set or get the IS_RECAL_VTO property.
        /// </summary>

        public byte? IS_RECAL_VTO { get; set; }

        /// <summary>
        ///  Set or get the ABONAR_LIBERA property.
        /// </summary>

        public byte? ABONAR_LIBERA { get; set; }

        /// <summary>
        ///  Set or get the NOMBRE_CLI property.
        /// </summary>

        public string NOMBRE_CLI { get; set; }

        /// <summary>
        ///  Set or get the DIR_CLI property.
        /// </summary>

        public string DIR_CLI { get; set; }

        /// <summary>
        ///  Set or get the CP_CLI property.
        /// </summary>

        public string CP_CLI { get; set; }

        /// <summary>
        ///  Set or get the POB_CLI property.
        /// </summary>

        public string POB_CLI { get; set; }

        /// <summary>
        ///  Set or get the PRO_CLI property.
        /// </summary>

        public string PRO_CLI { get; set; }

        /// <summary>
        ///  Set or get the PAIS_CLI property.
        /// </summary>

        public string PAIS_CLI { get; set; }

        /// <summary>
        ///  Set or get the NO_PENDIENTE property.
        /// </summary>

        public byte? NO_PENDIENTE { get; set; }

        /// <summary>
        ///  Set or get the TXTFACTURA property.
        /// </summary>

        public string TXTFACTURA { get; set; }

        /// <summary>
        ///  Set or get the CUORECA property.
        /// </summary>

        public Decimal? CUORECA { get; set; }

        /// <summary>
        ///  Set or get the CUORECA2 property.
        /// </summary>

        public Decimal? CUORECA2 { get; set; }

        /// <summary>
        ///  Set or get the ANULADA property.
        /// </summary>

        public byte? ANULADA { get; set; }

        /// <summary>
        ///  Set or get the BANCOREM_FAC property.
        /// </summary>

        public string BANCOREM_FAC { get; set; }

        /// <summary>
        ///  Set or get the NUM_PEDIDO property.
        /// </summary>

        public string NUM_PEDIDO { get; set; }

        /// <summary>
        ///  Set or get the ABONADA_MANUAL property.
        /// </summary>

        public byte? ABONADA_MANUAL { get; set; }

        /// <summary>
        ///  Set or get the N_DOCU property.
        /// </summary>

        public string N_DOCU { get; set; }

        /// <summary>
        ///  Set or get the YA_IMPRESA property.
        /// </summary>

        public byte? YA_IMPRESA { get; set; }

        /// <summary>
        ///  Set or get the TIPO_OPERACION_FAC property.
        /// </summary>

        public string TIPO_OPERACION_FAC { get; set; }

        /// <summary>
        ///  Set or get the REGDOCU_FAC property.
        /// </summary>

        public string REGDOCU_FAC { get; set; }

        /// <summary>
        ///  Set or get the ENTREGA_FAC property.
        /// </summary>

        public string ENTREGA_FAC { get; set; }

        /// <summary>
        ///  Set or get the NIF_ENTREGA property.
        /// </summary>

        public string NIF_ENTREGA { get; set; }

        /// <summary>
        ///  Set or get the FECHA_ENTREGA property.
        /// </summary>

        public DateTime? FECHA_ENTREGA { get; set; }

        /// <summary>
        ///  Set or get the TIPO_REF property.
        /// </summary>

        public Int32? TIPO_REF { get; set; }

        /// <summary>
        ///  Set or get the FOLIO_REF property.
        /// </summary>

        public string FOLIO_REF { get; set; }

        /// <summary>
        ///  Set or get the MOTIVO_REF property.
        /// </summary>

        public string MOTIVO_REF { get; set; }

        /// <summary>
        ///  Set or get the FECHA_REF property.
        /// </summary>

        public DateTime? FECHA_REF { get; set; }

        /// <summary>
        ///  Set or get the PASADO_CPLUS property.
        /// </summary>

        public byte? PASADO_CPLUS { get; set; }

        /// <summary>
        ///  Set or get the IMPUF_FAC property.
        /// </summary>

        public Decimal? IMPUF_FAC { get; set; }

        /// <summary>
        ///  Set or get the CLAVEBANCO_FAC property.
        /// </summary>

        public string CLAVEBANCO_FAC { get; set; }

        /// <summary>
        ///  Set or get the SERIE_FAC property.
        /// </summary>

        public string SERIE_FAC { get; set; }

        /// <summary>
        ///  Set or get the FSERV_DE property.
        /// </summary>

        public DateTime? FSERV_DE { get; set; }

        /// <summary>
        ///  Set or get the FSERV_A property.
        /// </summary>

        public DateTime? FSERV_A { get; set; }

        /// <summary>
        ///  Set or get the ENVIADA_SAP property.
        /// </summary>

        public byte? ENVIADA_SAP { get; set; }

        /// <summary>
        ///  Set or get the IS_BIENES_USADOS property.
        /// </summary>

        public byte? IS_BIENES_USADOS { get; set; }

        /// <summary>
        ///  Set or get the RECARGO2 property.
        /// </summary>

        public Decimal? RECARGO2 { get; set; }

        /// <summary>
        ///  Set or get the ES_BOLETA_FAC property.
        /// </summary>

        public byte? ES_BOLETA_FAC { get; set; }

        /// <summary>
        ///  Set or get the RECARGO property.
        /// </summary>

        public Decimal? RECARGO { get; set; }

        /// <summary>
        ///  Set or get the VALOR_FAC property.
        /// </summary>

        public Decimal? VALOR_FAC { get; set; }

        /// <summary>
        ///  Set or get the PERSONA_SOLICITA_FAC property.
        /// </summary>

        public string PERSONA_SOLICITA_FAC { get; set; }

        /// <summary>
        ///  Set or get the NO_VINCULADA property.
        /// </summary>

        public byte? NO_VINCULADA { get; set; }

        /// <summary>
        ///  Set or get the HORA_CREA property.
        /// </summary>

        public TimeSpan? HORA_CREA { get; set; }

        /// <summary>
        ///  Set or get the NO_PRINT_CHOFER property.
        /// </summary>

        public byte? NO_PRINT_CHOFER { get; set; }

        /// <summary>
        ///  Set or get the OBRA_FAC property.
        /// </summary>

        public string OBRA_FAC { get; set; }

        /// <summary>
        ///  Set or get the FAC_A_CMP_COMPRA property.
        /// </summary>

        public string FAC_A_CMP_COMPRA { get; set; }

        /// <summary>
        ///  Set or get the CIERRE_CTR property.
        /// </summary>

        public byte? CIERRE_CTR { get; set; }

        /// <summary>
        ///  Set or get the TIPO_FACTURA_MBZ property.
        /// </summary>

        public byte? TIPO_FACTURA_MBZ { get; set; }

        /// <summary>
        ///  Set or get the NUM_INICIAL property.
        /// </summary>

        public string NUM_INICIAL { get; set; }

        /// <summary>
        ///  Set or get the TXT_FACTURA_FAC_MBZ property.
        /// </summary>

        public string TXT_FACTURA_FAC_MBZ { get; set; }

        /// <summary>
        ///  Set or get the RETENCION property.
        /// </summary>

        public Decimal? RETENCION { get; set; }

        /// <summary>
        ///  Set or get the HORA_FAC property.
        /// </summary>

        public TimeSpan? HORA_FAC { get; set; }

        /// <summary>
        ///  Set or get the FAC_CIERRE_FAC property.
        /// </summary>

        public byte? FAC_CIERRE_FAC { get; set; }

        /// <summary>
        ///  Set or get the IBAN_FAC property.
        /// </summary>

        public string IBAN_FAC { get; set; }

        /// <summary>
        ///  Set or get the SWIFT_FAC property.
        /// </summary>

        public string SWIFT_FAC { get; set; }

        /// <summary>
        ///  Set or get the DETALLE_SERVICIOS_FAC property.
        /// </summary>

        public string DETALLE_SERVICIOS_FAC { get; set; }

        /// <summary>
        ///  Set or get the NOMBRE_CV property.
        /// </summary>

        public string NOMBRE_CV { get; set; }

        /// <summary>
        ///  Set or get the TELEFONO_CV property.
        /// </summary>

        public string TELEFONO_CV { get; set; }

        /// <summary>
        ///  Set or get the FAX_CV property.
        /// </summary>

        public string FAX_CV { get; set; }

        /// <summary>
        ///  Set or get the MAIL_CV property.
        /// </summary>

        public string MAIL_CV { get; set; }

        /// <summary>
        ///  Set or get the NIF_CV property.
        /// </summary>

        public string NIF_CV { get; set; }

        /// <summary>
        ///  Set or get the BASE3_FAC property.
        /// </summary>

        public Double? BASE3_FAC { get; set; }

        /// <summary>
        ///  Set or get the CUOTA3_FAC property.
        /// </summary>

        public Double? CUOTA3_FAC { get; set; }

        /// <summary>
        ///  Set or get the IVAPOR3_FAC property.
        /// </summary>

        public Double? IVAPOR3_FAC { get; set; }

        /// <summary>
        ///  Set or get the RECARGO3 property.
        /// </summary>

        public Double? RECARGO3 { get; set; }

        /// <summary>
        ///  Set or get the CUORECA3 property.
        /// </summary>

        public Double? CUORECA3 { get; set; }

        /// <summary>
        ///  Set or get the METODO_PAGO_FAC property.
        /// </summary>

        public string METODO_PAGO_FAC { get; set; }

        /// <summary>
        ///  Set or get the NPAGO_FAC property.
        /// </summary>

        public string NPAGO_FAC { get; set; }

        /// <summary>
        ///  Set or get the FACAORIGEN property.
        /// </summary>

        public byte? FACAORIGEN { get; set; }

        /// <summary>
        ///  Set or get the MONEDA_FAC property.
        /// </summary>

        public string MONEDA_FAC { get; set; }

        /// <summary>
        ///  Set or get the CAMBIO_FAC property.
        /// </summary>

        public Decimal? CAMBIO_FAC { get; set; }

        /// <summary>
        ///  Set or get the TIPO_FACTURA property.
        /// </summary>

        public byte? TIPO_FACTURA { get; set; }

        /// <summary>
        ///  Set or get the TIPO_FACTURA_VTA property.
        /// </summary>

        public string TIPO_FACTURA_VTA { get; set; }

        /// <summary>
        ///  Set or get the NUMEROREAL property.
        /// </summary>

        public string NUMEROREAL { get; set; }

        /// <summary>
        ///  Set or get the EMPRESA_REFACTURA property.
        /// </summary>

        public string EMPRESA_REFACTURA { get; set; }

        /// <summary>
        ///  Set or get the FAC_SERVICIO property.
        /// </summary>

        public byte? FAC_SERVICIO { get; set; }

        /// <summary>
        ///  Set or get the DONDE_ENVIO_FAC property.
        /// </summary>

        public string DONDE_ENVIO_FAC { get; set; }

        /// <summary>
        ///  Set or get the DIR_ENVIO_FAC property.
        /// </summary>

        public string DIR_ENVIO_FAC { get; set; }

        /// <summary>
        ///  Set or get the TXTSUPLIDOS property.
        /// </summary>

        public string TXTSUPLIDOS { get; set; }

        /// <summary>
        ///  Set or get the ASI_FINMES property.
        /// </summary>

        public string ASI_FINMES { get; set; }

        /// <summary>
        ///  Set or get the FAC_GASTO_RECIBO property.
        /// </summary>

        public string FAC_GASTO_RECIBO { get; set; }

        /// <summary>
        ///  Set or get the FAC_GASTO_EXT property.
        /// </summary>

        public string FAC_GASTO_EXT { get; set; }

        /// <summary>
        ///  Set or get the ASI_PAGOINI property.
        /// </summary>

        public string ASI_PAGOINI { get; set; }

        /// <summary>
        ///  Set or get the EXPORTADA_PDF property.
        /// </summary>

        public byte? EXPORTADA_PDF { get; set; }

        /// <summary>
        ///  Set or get the EXPORTANDO_PDF property.
        /// </summary>

        public byte? EXPORTANDO_PDF { get; set; }

        /// <summary>
        ///  Set or get the CRITERIOCAJA_FAC property.
        /// </summary>

        public byte? CRITERIOCAJA_FAC { get; set; }

        /// <summary>
        ///  Set or get the NO_LISTADO property.
        /// </summary>

        public byte? NO_LISTADO { get; set; }

        /// <summary>
        ///  Set or get the NO_AJUSTAR_FAC property.
        /// </summary>

        public byte? NO_AJUSTAR_FAC { get; set; }

        /// <summary>
        ///  Set or get the NIF_FAC property.
        /// </summary>

        public string NIF_FAC { get; set; }

        /// <summary>
        ///  Set or get the TIPOVENTA_FAC property.
        /// </summary>

        public byte? TIPOVENTA_FAC { get; set; }

        /// <summary>
        ///  Set or get the SALE180_FAC property.
        /// </summary>

        public byte? SALE180_FAC { get; set; }

        /// <summary>
        ///  Set or get the PERCEPCION_FAC property.
        /// </summary>

        public Decimal? PERCEPCION_FAC { get; set; }

        /// <summary>
        ///  Set or get the DPT_FAC property.
        /// </summary>

        public string DPT_FAC { get; set; }

        /// <summary>
        ///  Set or get the DTOPIE_FAC property.
        /// </summary>

        public Decimal? DTOPIE_FAC { get; set; }

        /// <summary>
        ///  Set or get the N_PRINT_FAC property.
        /// </summary>

        public Int32? N_PRINT_FAC { get; set; }

        /// <summary>
        ///  Set or get the LIQUIDACION_FAC property.
        /// </summary>

        public byte? LIQUIDACION_FAC { get; set; }

        /// <summary>
        ///  Set or get the PERIO_DESDE_FAC property.
        /// </summary>

        public DateTime? PERIO_DESDE_FAC { get; set; }

        /// <summary>
        ///  Set or get the PERIO_HASTA_FAC property.
        /// </summary>

        public DateTime? PERIO_HASTA_FAC { get; set; }

        /// <summary>
        ///  Set or get the ISP_FAC property.
        /// </summary>

        public byte? ISP_FAC { get; set; }

        /// <summary>
        ///  Set or get the FEC_SERVICIO_SII property.
        /// </summary>

        public DateTime? FEC_SERVICIO_SII { get; set; }

        /// <summary>
        ///  Set or get the DESCRIP_SERVICIO_SII property.
        /// </summary>

        public string DESCRIP_SERVICIO_SII { get; set; }

        /// <summary>
        ///  Set or get the COMENT_HACIENDA_SII property.
        /// </summary>

        public string COMENT_HACIENDA_SII { get; set; }

        /// <summary>
        ///  Set or get the FEC_ADMISIONDUA_SII property.
        /// </summary>

        public DateTime? FEC_ADMISIONDUA_SII { get; set; }

        /// <summary>
        ///  Set or get the CLASIFICACION_FISCAL_SII property.
        /// </summary>

        public byte? CLASIFICACION_FISCAL_SII { get; set; }

        /// <summary>
        ///  Set or get the CLAVEHAC_FAC property.
        /// </summary>

        public string CLAVEHAC_FAC { get; set; }

        /// <summary>
        ///  Set or get the FACTERCEROS_FAC property.
        /// </summary>

        public byte? FACTERCEROS_FAC { get; set; }

        /// <summary>
        ///  Set or get the ID_SII property.
        /// </summary>

        public Int64? ID_SII { get; set; }

        /// <summary>
        ///  Set or get the ERROR_SII property.
        /// </summary>

        public byte? ERROR_SII { get; set; }

        /// <summary>
        ///  Set or get the MENSA_SII property.
        /// </summary>

        public string MENSA_SII { get; set; }

        /// <summary>
        ///  Set or get the FECHA_RESP_SII property.
        /// </summary>

        public DateTime? FECHA_RESP_SII { get; set; }

        /// <summary>
        ///  Set or get the PAIS_CV property.
        /// </summary>

        public string PAIS_CV { get; set; }

        /// <summary>
        ///  Set or get the CLAVERECTIFICA_FAC property.
        /// </summary>

        public string CLAVERECTIFICA_FAC { get; set; }

        /// <summary>
        ///  Set or get the DGI_TIPO property.
        /// </summary>

        public Int32? DGI_TIPO { get; set; }

        /// <summary>
        ///  Set or get the DGI_SERIE property.
        /// </summary>

        public string DGI_SERIE { get; set; }

        /// <summary>
        ///  Set or get the DGI_NUMERO property.
        /// </summary>

        public Int32? DGI_NUMERO { get; set; }

        /// <summary>
        ///  Set or get the TIPOFAC_SV property.
        /// </summary>

        public byte? TIPOFAC_SV { get; set; }

        /// <summary>
        ///  Set or get the AGRUPA_REF_FAC property.
        /// </summary>

        public byte? AGRUPA_REF_FAC { get; set; }

        /// <summary>
        ///  Set or get the VIAPAGO_FAC property.
        /// </summary>

        public string VIAPAGO_FAC { get; set; }

        /// <summary>
        ///  Set or get the CAMBIOTITULAR_FAC property.
        /// </summary>

        public byte? CAMBIOTITULAR_FAC { get; set; }

        /// <summary>
        ///  Set or get the CODIGO_SII_FAC property.
        /// </summary>

        public string CODIGO_SII_FAC { get; set; }

        /// <summary>
        ///  Set or get the FECHA_OPERACION_SII_FAC property.
        /// </summary>

        public DateTime? FECHA_OPERACION_SII_FAC { get; set; }

        /// <summary>
        ///  Set or get the TIPO_ABONO_FAC property.
        /// </summary>

        public byte? TIPO_ABONO_FAC { get; set; }

        /// <summary>
        ///  Set or get the TIPO_ABONO_RECUPERA_FAC property.
        /// </summary>

        public byte? TIPO_ABONO_RECUPERA_FAC { get; set; }

        /// <summary>
        ///  Set or get the NO_MODIFICA_BASE property.
        /// </summary>

        public byte? NO_MODIFICA_BASE { get; set; }

        /// <summary>
        ///  Set or get the NEGOCIO_ORI_FAC property.
        /// </summary>

        public string NEGOCIO_ORI_FAC { get; set; }

        /// <summary>
        ///  Set or get the SUBSIDIOPI_FAC property.
        /// </summary>

        public byte? SUBSIDIOPI_FAC { get; set; }

        /// <summary>
        ///  Set or get the NUM_PEDIDO_CLIENTE_MBF_FAC property.
        /// </summary>

        public string NUM_PEDIDO_CLIENTE_MBF_FAC { get; set; }

        /// <summary>
        ///  Set or get the ENVIANDO_MAIL_AUT_FAC property.
        /// </summary>

        public byte? ENVIANDO_MAIL_AUT_FAC { get; set; }

        /// <summary>
        ///  Set or get the ENVIADO_MAIL_AUT_FAC property.
        /// </summary>

        public byte? ENVIADO_MAIL_AUT_FAC { get; set; }

    }

}
