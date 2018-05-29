using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataServices.DataTransferObject
{
    /// <summary>
    ///  Booking dto is the booking data transfer object that convey the information outside the data layer.
    ///  Remark: It will important in the mapper field just map the fields needed because otherwise
    /// it will heavy and slow the load/store.
    /// </summary>
    public class BookingDto: BaseDto
    {
        [PrimaryKey]
        public string NUMERO_RES { get; set; }

        /// <summary>
        ///  Set or get the LOCALIZA_RES1 property.
        /// </summary>

        public string LOCALIZA_RES1 { get; set; }

        /// <summary>
        ///  Set or get the OFICINA_RES1 property.
        /// </summary>

        public string OFICINA_RES1 { get; set; }

        /// <summary>
        ///  Set or get the OFIRETORNO_RES1 property.
        /// </summary>

        public string OFIRETORNO_RES1 { get; set; }

        /// <summary>
        ///  Set or get the OFISALIDA_RES1 property.
        /// </summary>

        public string OFISALIDA_RES1 { get; set; }

        /// <summary>
        ///  Set or get the SUBLICEN_RES1 property.
        /// </summary>

        public string SUBLICEN_RES1 { get; set; }

        /// <summary>
        ///  Set or get the ULTMODI_RES1 property.
        /// </summary>

        public string ULTMODI_RES1 { get; set; }

        /// <summary>
        ///  Set or get the USUARIO_RES1 property.
        /// </summary>

        public string USUARIO_RES1 { get; set; }

        /// <summary>
        ///  Set or get the FPREV_RES1 property.
        /// </summary>

        public DateTime? FPREV_RES1 { get; set; }

        /// <summary>
        ///  Set or get the FSALIDA_RES1 property.
        /// </summary>

        public DateTime? FSALIDA_RES1 { get; set; }

        /// <summary>
        ///  Set or get the HPREV_RES1 property.
        /// </summary>

        public TimeSpan? HPREV_RES1 { get; set; }

        /// <summary>
        ///  Set or get the HSALIDA_RES1 property.
        /// </summary>

        public TimeSpan? HSALIDA_RES1 { get; set; }

        /// <summary>
        ///  Set or get the LUDEVO_RES1 property.
        /// </summary>

        public string LUDEVO_RES1 { get; set; }

        /// <summary>
        ///  Set or get the LUENTRE_RES1 property.
        /// </summary>

        public string LUENTRE_RES1 { get; set; }

        /// <summary>
        ///  Set or get the DIAFAC_RES1 property.
        /// </summary>

        public Int16? DIAFAC_RES1 { get; set; }

        /// <summary>
        ///  Set or get the DIAS_RES1 property.
        /// </summary>

        public Int16? DIAS_RES1 { get; set; }

        /// <summary>
        ///  Set or get the CIAAEREA_RES1 property.
        /// </summary>

        public string CIAAEREA_RES1 { get; set; }

        /// <summary>
        ///  Set or get the VUELO_RES1 property.
        /// </summary>

        public string VUELO_RES1 { get; set; }

        /// <summary>
        ///  Set or get the CLIENTE_RES1 property.
        /// </summary>

        public string CLIENTE_RES1 { get; set; }

        /// <summary>
        ///  Set or get the CONDUCTOR_RES1 property.
        /// </summary>

        public string CONDUCTOR_RES1 { get; set; }

        /// <summary>
        ///  Set or get the FECHA_RES1 property.
        /// </summary>

        public DateTime? FECHA_RES1 { get; set; }

        /// <summary>
        ///  Set or get the GRUPO_RES1 property.
        /// </summary>

        public string GRUPO_RES1 { get; set; }

        /// <summary>
        ///  Set or get the HORA_RES1 property.
        /// </summary>

        public TimeSpan? HORA_RES1 { get; set; }

        /// <summary>
        ///  Set or get the NOMBRE_RES1 property.
        /// </summary>

        public string NOMBRE_RES1 { get; set; }

        /// <summary>
        ///  Set or get the NOMCLI_RES1 property.
        /// </summary>

        public string NOMCLI_RES1 { get; set; }

        /// <summary>
        ///  Set or get the NOTAS_RES1 property.
        /// </summary>

        public string NOTAS_RES1 { get; set; }

        /// <summary>
        ///  Set or get the TARIFA_RES1 property.
        /// </summary>

        public string TARIFA_RES1 { get; set; }

        /// <summary>
        ///  Set or get the CONTRATO_RES1 property.
        /// </summary>

        public string CONTRATO_RES1 { get; set; }

        /// <summary>
        ///  Set or get the MEDIO_RES1 property.
        /// </summary>

        public string MEDIO_RES1 { get; set; }

        /// <summary>
        ///  Set or get the SUBCREA_RES1 property.
        /// </summary>

        public string SUBCREA_RES1 { get; set; }

        /// <summary>
        ///  Set or get the RENTAL1_RES1 property.
        /// </summary>

        public string RENTAL1_RES1 { get; set; }

        /// <summary>
        ///  Set or get the USUANULA_RES1 property.
        /// </summary>

        public string USUANULA_RES1 { get; set; }

        /// <summary>
        ///  Set or get the TIPOPAGO_RES1 property.
        /// </summary>

        public string TIPOPAGO_RES1 { get; set; }

        /// <summary>
        ///  Set or get the REFERENCIA_RES1 property.
        /// </summary>

        public string REFERENCIA_RES1 { get; set; }

        /// <summary>
        ///  Set or get the DISPONIBLE_RES1 property.
        /// </summary>

        public string DISPONIBLE_RES1 { get; set; }

        /// <summary>
        ///  Set or get the FECHAESPLAZA_RES1 property.
        /// </summary>

        public DateTime? FECHAESPLAZA_RES1 { get; set; }

        /// <summary>
        ///  Set or get the HORAESPLAZA_RES1 property.
        /// </summary>

        public TimeSpan? HORAESPLAZA_RES1 { get; set; }

        /// <summary>
        ///  Set or get the VCACT_RES1 property.
        /// </summary>

        public string VCACT_RES1 { get; set; }

        /// <summary>
        ///  Set or get the FECHAESPLAZASAL_RES1 property.
        /// </summary>

        public DateTime? FECHAESPLAZASAL_RES1 { get; set; }

        /// <summary>
        ///  Set or get the HORAESPLAZASAL_RES1 property.
        /// </summary>

        public TimeSpan? HORAESPLAZASAL_RES1 { get; set; }

        /// <summary>
        ///  Set or get the KILOMETROS property.
        /// </summary>

        public Int32? KILOMETROS { get; set; }

        /// <summary>
        ///  Set or get the ESCONCHOFER_RES1 property.
        /// </summary>

        public byte? ESCONCHOFER_RES1 { get; set; }

        /// <summary>
        ///  Set or get the CHOFER_RES1 property.
        /// </summary>

        public string CHOFER_RES1 { get; set; }

        /// <summary>
        ///  Set or get the PRESUPUESTO_RES1 property.
        /// </summary>

        public string PRESUPUESTO_RES1 { get; set; }

        /// <summary>
        ///  Set or get the PERSONA_RES1 property.
        /// </summary>

        public string PERSONA_RES1 { get; set; }

        /// <summary>
        ///  Set or get the COMBUSTIBLE property.
        /// </summary>

        public string COMBUSTIBLE { get; set; }

        /// <summary>
        ///  Set or get the PREHORAMO property.
        /// </summary>

        public string PREHORAMO { get; set; }

        /// <summary>
        ///  Set or get the AYUDANTE1 property.
        /// </summary>

        public string AYUDANTE1 { get; set; }

        /// <summary>
        ///  Set or get the FRANQUIDEPO_CON4 property.
        /// </summary>

        public Decimal? FRANQUIDEPO_CON4 { get; set; }

        /// <summary>
        ///  Set or get the FRANQUIROBO_CON4 property.
        /// </summary>

        public Decimal? FRANQUIROBO_CON4 { get; set; }

        /// <summary>
        ///  Set or get the PRINT_RES1 property.
        /// </summary>

        public byte? PRINT_RES1 { get; set; }

        /// <summary>
        ///  Set or get the HORA_CEREMONIA property.
        /// </summary>

        public TimeSpan? HORA_CEREMONIA { get; set; }

        /// <summary>
        ///  Set or get the NUM_CONTACTO property.
        /// </summary>

        public string NUM_CONTACTO { get; set; }

        /// <summary>
        ///  Set or get the NUM_PEDIDO_RES1 property.
        /// </summary>

        public string NUM_PEDIDO_RES1 { get; set; }

        /// <summary>
        ///  Set or get the FCOBRO_RES1 property.
        /// </summary>

        public byte? FCOBRO_RES1 { get; set; }

        /// <summary>
        ///  Set or get the DELEGA_RES1 property.
        /// </summary>

        public string DELEGA_RES1 { get; set; }

        /// <summary>
        ///  Set or get the PROVEEDOR property.
        /// </summary>

        public string PROVEEDOR { get; set; }

        /// <summary>
        ///  Set or get the COSTE_RES1 property.
        /// </summary>

        public Decimal? COSTE_RES1 { get; set; }

        /// <summary>
        ///  Set or get the DOCUMENTO property.
        /// </summary>

        public string DOCUMENTO { get; set; }

        /// <summary>
        ///  Set or get the DE_ENVIO_DOC property.
        /// </summary>

        public string DE_ENVIO_DOC { get; set; }

        /// <summary>
        ///  Set or get the FEC_ENVIO_DOC property.
        /// </summary>

        public DateTime? FEC_ENVIO_DOC { get; set; }

        /// <summary>
        ///  Set or get the PARA_ENVIO_DOC property.
        /// </summary>

        public string PARA_ENVIO_DOC { get; set; }

        /// <summary>
        ///  Set or get the TELFAX_ENVIO_DOC property.
        /// </summary>

        public string TELFAX_ENVIO_DOC { get; set; }

        /// <summary>
        ///  Set or get the ORIGEN_ENVIO_DOC property.
        /// </summary>

        public byte? ORIGEN_ENVIO_DOC { get; set; }

        /// <summary>
        ///  Set or get the OBS_ENVIO_DOC property.
        /// </summary>

        public string OBS_ENVIO_DOC { get; set; }

        /// <summary>
        ///  Set or get the ENTREGA_ENVIO_DOC property.
        /// </summary>

        public string ENTREGA_ENVIO_DOC { get; set; }

        /// <summary>
        ///  Set or get the DESTINO_ENVIO_DOC property.
        /// </summary>

        public string DESTINO_ENVIO_DOC { get; set; }

        /// <summary>
        ///  Set or get the IDIOMA_ENVIO_DOC property.
        /// </summary>

        public string IDIOMA_ENVIO_DOC { get; set; }

        /// <summary>
        ///  Set or get the N_DOCU property.
        /// </summary>

        public string N_DOCU { get; set; }

        /// <summary>
        ///  Set or get the ENT_CALLE property.
        /// </summary>

        public string ENT_CALLE { get; set; }

        /// <summary>
        ///  Set or get the ENT_NUM property.
        /// </summary>

        public string ENT_NUM { get; set; }

        /// <summary>
        ///  Set or get the ENT_POB property.
        /// </summary>

        public string ENT_POB { get; set; }

        /// <summary>
        ///  Set or get the ENT_CP property.
        /// </summary>

        public string ENT_CP { get; set; }

        /// <summary>
        ///  Set or get the ENT_CALLER property.
        /// </summary>

        public string ENT_CALLER { get; set; }

        /// <summary>
        ///  Set or get the ENT_NUMR property.
        /// </summary>

        public string ENT_NUMR { get; set; }

        /// <summary>
        ///  Set or get the ENT_POBR property.
        /// </summary>

        public string ENT_POBR { get; set; }

        /// <summary>
        ///  Set or get the ENT_CPR property.
        /// </summary>

        public string ENT_CPR { get; set; }

        /// <summary>
        ///  Set or get the NO_TENER_ENCUENTA_DIETAS property.
        /// </summary>

        public byte? NO_TENER_ENCUENTA_DIETAS { get; set; }

        /// <summary>
        ///  Set or get the KMINCL_RES1 property.
        /// </summary>

        public Decimal? KMINCL_RES1 { get; set; }

        /// <summary>
        ///  Set or get the BLQ_KMCTR property.
        /// </summary>

        public byte? BLQ_KMCTR { get; set; }

        /// <summary>
        ///  Set or get the GESTION_UFSC property.
        /// </summary>

        public byte? GESTION_UFSC { get; set; }

        /// <summary>
        ///  Set or get the NPERSONAS_RES1 property.
        /// </summary>

        public byte? NPERSONAS_RES1 { get; set; }

        /// <summary>
        ///  Set or get the CONTRATIPIMPR_RES property.
        /// </summary>

        public byte? CONTRATIPIMPR_RES { get; set; }

        /// <summary>
        ///  Set or get the TIPORES_res1 property.
        /// </summary>

        public string TIPORES_res1 { get; set; }

        /// <summary>
        ///  Set or get the BATCH property.
        /// </summary>

        public string BATCH { get; set; }

        /// <summary>
        ///  Set or get the PCODE_RES1 property.
        /// </summary>

        public string PCODE_RES1 { get; set; }

        /// <summary>
        ///  Set or get the AF property.
        /// </summary>

        public Decimal? AF { get; set; }

        /// <summary>
        ///  Set or get the IMP_AF property.
        /// </summary>

        public Decimal? IMP_AF { get; set; }

        /// <summary>
        ///  Set or get the USUARIO_CWEB property.
        /// </summary>

        public string USUARIO_CWEB { get; set; }

        /// <summary>
        ///  Set or get the NOTAS_INTERNAS property.
        /// </summary>

        public string NOTAS_INTERNAS { get; set; }

        /// <summary>
        ///  Set or get the TIPOCALC_RES1 property.
        /// </summary>

        public byte? TIPOCALC_RES1 { get; set; }

        /// <summary>
        ///  Set or get the VERSION_RES1 property.
        /// </summary>

        public string VERSION_RES1 { get; set; }

        /// <summary>
        ///  Set or get the FLIQCREARES_RES1 property.
        /// </summary>

        public DateTime? FLIQCREARES_RES1 { get; set; }

        /// <summary>
        ///  Set or get the LIQCREARES_RES1 property.
        /// </summary>

        public Decimal? LIQCREARES_RES1 { get; set; }

        /// <summary>
        ///  Set or get the NOCOMI_LIQCREARES_RES1 property.
        /// </summary>

        public byte? NOCOMI_LIQCREARES_RES1 { get; set; }

        /// <summary>
        ///  Set or get the OBS_COBROS property.
        /// </summary>

        public string OBS_COBROS { get; set; }

        /// <summary>
        ///  Set or get the REFERE_RES1 property.
        /// </summary>

        public string REFERE_RES1 { get; set; }

        /// <summary>
        ///  Set or get the USUCONFIRM_RES1 property.
        /// </summary>

        public string USUCONFIRM_RES1 { get; set; }

        /// <summary>
        ///  Set or get the FCONFIRM_RES1 property.
        /// </summary>

        public DateTime? FCONFIRM_RES1 { get; set; }

        /// <summary>
        ///  Set or get the HCONFIRM_RES1 property.
        /// </summary>

        public TimeSpan? HCONFIRM_RES1 { get; set; }

        /// <summary>
        ///  Set or get the CONFIRMADA_RES1 property.
        /// </summary>

        public byte? CONFIRMADA_RES1 { get; set; }

        /// <summary>
        ///  Set or get the FCHECKOUT_RES1 property.
        /// </summary>

        public DateTime? FCHECKOUT_RES1 { get; set; }

        /// <summary>
        ///  Set or get the FPROFO_RES1 property.
        /// </summary>

        public DateTime? FPROFO_RES1 { get; set; }

        /// <summary>
        ///  Set or get the FACTURANDO_RES1 property.
        /// </summary>

        public byte? FACTURANDO_RES1 { get; set; }

        /// <summary>
        ///  Set or get the USUBLQ_RES1 property.
        /// </summary>

        public string USUBLQ_RES1 { get; set; }

        /// <summary>
        ///  Set or get the ULTFRANUM_RES1 property.
        /// </summary>

        public string ULTFRANUM_RES1 { get; set; }

        /// <summary>
        ///  Set or get the PROMO property.
        /// </summary>

        public byte? PROMO { get; set; }

        /// <summary>
        ///  Set or get the ULTFRANUM_OCU_RES1 property.
        /// </summary>

        public string ULTFRANUM_OCU_RES1 { get; set; }

        /// <summary>
        ///  Set or get the COLOR_RES1 property.
        /// </summary>

        public Int32? COLOR_RES1 { get; set; }

        /// <summary>
        ///  Set or get the IMPRODUC property.
        /// </summary>

        public byte? IMPRODUC { get; set; }

        /// <summary>
        ///  Set or get the CP_RES1 property.
        /// </summary>

        public string CP_RES1 { get; set; }

        /// <summary>
        ///  Set or get the TOTAL_MANUAL property.
        /// </summary>

        public Decimal? TOTAL_MANUAL { get; set; }

        /// <summary>
        ///  Set or get the NOVALORADO_RES1 property.
        /// </summary>

        public byte? NOVALORADO_RES1 { get; set; }

        /// <summary>
        ///  Set or get the ORDEN_RES1 property.
        /// </summary>

        public Int32? ORDEN_RES1 { get; set; }

        /// <summary>
        ///  Set or get the PENSION_RES1 property.
        /// </summary>

        public Int32? PENSION_RES1 { get; set; }

        /// <summary>
        ///  Set or get the PEND_AUTORIZAR property.
        /// </summary>

        public byte? PEND_AUTORIZAR { get; set; }

        /// <summary>
        ///  Set or get the FIANZA_DEPOSITO_RES1 property.
        /// </summary>

        public Decimal? FIANZA_DEPOSITO_RES1 { get; set; }

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
        ///  Set or get the COD_LUENTRE_RES1 property.
        /// </summary>

        public Int32? COD_LUENTRE_RES1 { get; set; }

        /// <summary>
        ///  Set or get the COD_LUDEVO_RES1 property.
        /// </summary>

        public Int32? COD_LUDEVO_RES1 { get; set; }

        /// <summary>
        ///  Set or get the PPEDIDO_RES1 property.
        /// </summary>

        public string PPEDIDO_RES1 { get; set; }

        /// <summary>
        ///  Set or get the ACTIVEHI_RES1 property.
        /// </summary>

        public string ACTIVEHI_RES1 { get; set; }

        /// <summary>
        ///  Set or get the USUCREA_RES1 property.
        /// </summary>

        public string USUCREA_RES1 { get; set; }

        /// <summary>
        ///  Set or get the HPREVENT_res1 property.
        /// </summary>

        public TimeSpan? HPREVENT_res1 { get; set; }

        /// <summary>
        ///  Set or get the HPREVSAL_res1 property.
        /// </summary>

        public TimeSpan? HPREVSAL_res1 { get; set; }

        /// <summary>
        ///  Set or get the RECHAZAMOTI property.
        /// </summary>

        public string RECHAZAMOTI { get; set; }

        /// <summary>
        ///  Set or get the RECHAZAUSU property.
        /// </summary>

        public string RECHAZAUSU { get; set; }

        /// <summary>
        ///  Set or get the RECHAZAFECHA property.
        /// </summary>

        public DateTime? RECHAZAFECHA { get; set; }

        /// <summary>
        ///  Set or get the RECHAZADA_RES1 property.
        /// </summary>

        public byte? RECHAZADA_RES1 { get; set; }

        /// <summary>
        ///  Set or get the RECHAZAOBS_RES1 property.
        /// </summary>

        public string RECHAZAOBS_RES1 { get; set; }

        /// <summary>
        ///  Set or get the STATUS_RFX property.
        /// </summary>

        public string STATUS_RFX { get; set; }

        /// <summary>
        ///  Set or get the CONTESTADA property.
        /// </summary>

        public byte? CONTESTADA { get; set; }

        /// <summary>
        ///  Set or get the CONTESTADA_QUIEN property.
        /// </summary>

        public string CONTESTADA_QUIEN { get; set; }

        /// <summary>
        ///  Set or get the APELLIDO1 property.
        /// </summary>

        public string APELLIDO1 { get; set; }

        /// <summary>
        ///  Set or get the APELLIDO2 property.
        /// </summary>

        public string APELLIDO2 { get; set; }

        /// <summary>
        ///  Set or get the NOMBRESOLO property.
        /// </summary>

        public string NOMBRESOLO { get; set; }

        /// <summary>
        ///  Set or get the CODPROMO_RES1 property.
        /// </summary>

        public string CODPROMO_RES1 { get; set; }

        /// <summary>
        ///  Set or get the CALLCENTER_RES property.
        /// </summary>

        public string CALLCENTER_RES { get; set; }

        /// <summary>
        ///  Set or get the CALLCENTERLIN_RES property.
        /// </summary>

        public Int32? CALLCENTERLIN_RES { get; set; }

        /// <summary>
        ///  Set or get the RECORRIDO_RES1 property.
        /// </summary>

        public string RECORRIDO_RES1 { get; set; }

        /// <summary>
        ///  Set or get the ID_DESCUENTO property.
        /// </summary>

        public Int32? ID_DESCUENTO { get; set; }

        /// <summary>
        ///  Set or get the ID_AFILIADO property.
        /// </summary>

        public string ID_AFILIADO { get; set; }


        /// <summary>
        ///  Set or get the ULTMODIENVIO property.
        /// </summary>

        public string ULTMODIENVIO { get; set; }

        /// <summary>
        ///  Set or get the ARCHIVO_RUTA property.
        /// </summary>

        public string ARCHIVO_RUTA { get; set; }

        /// <summary>
        ///  Set or get the KMS_RUTA property.
        /// </summary>

        public string KMS_RUTA { get; set; }

        /// <summary>
        ///  Set or get the TIEMPO_RUTA property.
        /// </summary>

        public string TIEMPO_RUTA { get; set; }

        /// <summary>
        ///  Set or get the AVISO_EN_CTR_RES property.
        /// </summary>

        public string AVISO_EN_CTR_RES { get; set; }

        /// <summary>
        ///  Set or get the KMDIA_RES1 property.
        /// </summary>

        public Int32? KMDIA_RES1 { get; set; }

        /// <summary>
        ///  Set or get the KMMAX_RES1 property.
        /// </summary>

        public Int32? KMMAX_RES1 { get; set; }

        /// <summary>
        ///  Set or get the PRECIOKM_RES1 property.
        /// </summary>

        public Decimal? PRECIOKM_RES1 { get; set; }

        /// <summary>
        ///  Set or get the PRECIOCOMBUS_RES1 property.
        /// </summary>

        public Decimal? PRECIOCOMBUS_RES1 { get; set; }

        /// <summary>
        ///  Set or get the COORDGPS_SAL property.
        /// </summary>

        public string COORDGPS_SAL { get; set; }

        /// <summary>
        ///  Set or get the COORDGPS_RET property.
        /// </summary>

        public string COORDGPS_RET { get; set; }

        /// <summary>
        ///  Set or get the ID_PROMOCODE property.
        /// </summary>

        public Int32? ID_PROMOCODE { get; set; }

        /// <summary>
        ///  Set or get the NUM_VENDE_RES1 property.
        /// </summary>

        public string NUM_VENDE_RES1 { get; set; }

        /// <summary>
        ///  Set or get the PAISORIGEN_RES1 property.
        /// </summary>

        public string PAISORIGEN_RES1 { get; set; }

        /// <summary>
        ///  Set or get the PAISDESTINO_RES1 property.
        /// </summary>

        public string PAISDESTINO_RES1 { get; set; }

        /// <summary>
        ///  Set or get the CURRENCY_RES property.
        /// </summary>

        public string CURRENCY_RES { get; set; }

        /// <summary>
        ///  Set or get the VALUE_CURRENCY_RES property.
        /// </summary>

        public Decimal? VALUE_CURRENCY_RES { get; set; }

        /// <summary>
        ///  Set or get the TRANSFERDESDE property.
        /// </summary>

        public Int32? TRANSFERDESDE { get; set; }

        /// <summary>
        ///  Set or get the TRANSFERHASTA property.
        /// </summary>

        public Int32? TRANSFERHASTA { get; set; }

        /// <summary>
        ///  Set or get the COMENTARIOS_INT property.
        /// </summary>

        public string COMENTARIOS_INT { get; set; }

        /// <summary>
        ///  Set or get the TRANSFER property.
        /// </summary>

        public byte? TRANSFER { get; set; }

        /// <summary>
        ///  Set or get the IDADE_RES1 property.
        /// </summary>

        public string IDADE_RES1 { get; set; }

        /// <summary>
        ///  Set or get the REMERCA_CLI property.
        /// </summary>

        public string REMERCA_CLI { get; set; }

        /// <summary>
        ///  Set or get the OPCION_COMPRA_RES1 property.
        /// </summary>

        public byte? OPCION_COMPRA_RES1 { get; set; }

        /// <summary>
        ///  Set or get the VALORVEHI_RES1 property.
        /// </summary>

        public Decimal? VALORVEHI_RES1 { get; set; }

        /// <summary>
        ///  Set or get the PROVECRM_RES1 property.
        /// </summary>

        public string PROVECRM_RES1 { get; set; }

        /// <summary>
        ///  Set or get the OBSFIANZA_RES1 property.
        /// </summary>

        public string OBSFIANZA_RES1 { get; set; }

        /// <summary>
        ///  Set or get the CURRENCY2_RES property.
        /// </summary>

        public string CURRENCY2_RES { get; set; }

        /// <summary>
        ///  Set or get the VALUE_CURRENCY2_RES property.
        /// </summary>

        public Decimal? VALUE_CURRENCY2_RES { get; set; }

        /// <summary>
        ///  Set or get the RESERVA_TARGET property.
        /// </summary>

        public string RESERVA_TARGET { get; set; }

        /// <summary>
        ///  Set or get the EMAIL_RES1 property.
        /// </summary>

        public string EMAIL_RES1 { get; set; }

        /// <summary>
        ///  Set or get the LISTADTOS_RES1 property.
        /// </summary>

        public string LISTADTOS_RES1 { get; set; }

        /// <summary>
        ///  Set or get the TELFPERS_RES1 property.
        /// </summary>

        public string TELFPERS_RES1 { get; set; }

        /// <summary>
        ///  Set or get the REDUCCION_RES1 property.
        /// </summary>

        public Decimal? REDUCCION_RES1 { get; set; }

        /// <summary>
        ///  Set or get the FRANQUI_DEPO_RES1 property.
        /// </summary>

        public Decimal? FRANQUI_DEPO_RES1 { get; set; }

        /// <summary>
        ///  Set or get the FRANQUIROBO_RES1 property.
        /// </summary>

        public Decimal? FRANQUIROBO_RES1 { get; set; }

        /// <summary>
        ///  Set or get the FRANQUICIA_REDUCIDA_RES1 property.
        /// </summary>

        public Decimal? FRANQUICIA_REDUCIDA_RES1 { get; set; }

        /// <summary>
        ///  Set or get the ABONOKM property.
        /// </summary>

        public Decimal? ABONOKM { get; set; }

        /// <summary>
        ///  Set or get the CARGOKM property.
        /// </summary>

        public Decimal? CARGOKM { get; set; }

        /// <summary>
        ///  Set or get the ASIGNA_VEHI_RES1 property.
        /// </summary>

        public DateTime? ASIGNA_VEHI_RES1 { get; set; }

        /// <summary>
        ///  Set or get the IMPORTEWEB_RES1 property.
        /// </summary>

        public Decimal? IMPORTEWEB_RES1 { get; set; }

        /// <summary>
        ///  Set or get the PREFERE_RES1 property.
        /// </summary>

        public string PREFERE_RES1 { get; set; }

        /// <summary>
        ///  Set or get the DTO_RES1 property.
        /// </summary>

        public Decimal? DTO_RES1 { get; set; }

        /// <summary>
        ///  Set or get the NO_CAMBIAR_VEHI_RES1 property.
        /// </summary>

        public byte? NO_CAMBIAR_VEHI_RES1 { get; set; }

        /// <summary>
        ///  Set or get the USU_AUTORIZA_RES_VEHI_INMO_RES1 property.
        /// </summary>

        public string USU_AUTORIZA_RES_VEHI_INMO_RES1 { get; set; }

        /// <summary>
        ///  Set or get the USUARIO_DESCARTA_CAMBIOVEHI_RES1 property.
        /// </summary>

        public string USUARIO_DESCARTA_CAMBIOVEHI_RES1 { get; set; }

        /// <summary>
        ///  Set or get the FECHA_DESCARTA_CAMBIOVEHI_RES1 property.
        /// </summary>

        public DateTime? FECHA_DESCARTA_CAMBIOVEHI_RES1 { get; set; }

        /// <summary>
        ///  Set or get the REQUEST_SOAP property.
        /// </summary>

        public string REQUEST_SOAP { get; set; }

        /// <summary>
        ///  Set or get the REQUEST_SQL property.
        /// </summary>

        public string REQUEST_SQL { get; set; }

        /// <summary>
        ///  Set or get the RESPONSE_SOAP property.
        /// </summary>

        public string RESPONSE_SOAP { get; set; }

        /// <summary>
        ///  Set or get the LICENSE_PLATE property.
        /// </summary>

        public string LICENSE_PLATE { get; set; }

        /// <summary>
        ///  Set or get the COMENT_CLI property.
        /// </summary>

        public string COMENT_CLI { get; set; }

        /// <summary>
        ///  Set or get the SEGUNDOS_BLOQUEO property.
        /// </summary>

        public Int32? SEGUNDOS_BLOQUEO { get; set; }

        /// <summary>
        ///  Set or get the HORA_BLOQUEO property.
        /// </summary>

        public DateTime? HORA_BLOQUEO { get; set; }

        /// <summary>
        ///  Set or get the ORDEN_REDSYS property.
        /// </summary>

        public string ORDEN_REDSYS { get; set; }

        /// <summary>
        ///  Set or get the NO_STOPSELL property.
        /// </summary>

        public byte? NO_STOPSELL { get; set; }
        /// <summary>
        ///  Set or get the TIIVA_RES2 property.
        /// </summary>

        public Decimal? TIIVA_RES2 { get; set; }

        /// <summary>
        ///  Set or get the TOLON_RES2 property.
        /// </summary>

        public Decimal? TOLON_RES2 { get; set; }

        /// <summary>
        ///  Set or get the OTROCOND_RES2 property.
        /// </summary>

        public string OTROCOND_RES2 { get; set; }

        /// <summary>
        ///  Set or get the OTRO2COND_RES2 property.
        /// </summary>

        public string OTRO2COND_RES2 { get; set; }

        /// <summary>
        ///  Set or get the OTRO3COND_RES2 property.
        /// </summary>

        public string OTRO3COND_RES2 { get; set; }

        /// <summary>
        ///  Set or get the CLIFAC_RES2 property.
        /// </summary>

        public string CLIFAC_RES2 { get; set; }

        /// <summary>
        ///  Set or get the CONFIRMADA_RES2 property.
        /// </summary>

        public string CONFIRMADA_RES2 { get; set; }

        /// <summary>
        ///  Set or get the MOTIVO_RES2 property.
        /// </summary>

        public string MOTIVO_RES2 { get; set; }

        /// <summary>
        ///  Set or get the FEANU_RES2 property.
        /// </summary>

        public DateTime? FEANU_RES2 { get; set; }

        /// <summary>
        ///  Set or get the MONEDA_RES2 property.
        /// </summary>

        public string MONEDA_RES2 { get; set; }

        /// <summary>
        ///  Set or get the BASEI_RES2 property.
        /// </summary>

        public Decimal? BASEI_RES2 { get; set; }

        /// <summary>
        ///  Set or get the BONOAURO_RES2 property.
        /// </summary>

        public string BONOAURO_RES2 { get; set; }

        /// <summary>
        ///  Set or get the BONONUM_RES2 property.
        /// </summary>

        public string BONONUM_RES2 { get; set; }

        /// <summary>
        ///  Set or get the BONOSI_RES2 property.
        /// </summary>

        public string BONOSI_RES2 { get; set; }

        /// <summary>
        ///  Set or get the TIPOBONO_RES2 property.
        /// </summary>

        public string TIPOBONO_RES2 { get; set; }

        /// <summary>
        ///  Set or get the COMISIO_RES2 property.
        /// </summary>

        public string COMISIO_RES2 { get; set; }

        /// <summary>
        ///  Set or get the EMPLEAGE_RES2 property.
        /// </summary>

        public string EMPLEAGE_RES2 { get; set; }

        /// <summary>
        ///  Set or get the ORIGEN_RES2 property.
        /// </summary>

        public byte? ORIGEN_RES2 { get; set; }

        /// <summary>
        ///  Set or get the OBS1_RES2 property.
        /// </summary>

        public string OBS1_RES2 { get; set; }

        /// <summary>
        ///  Set or get the DIRCOND_RES2 property.
        /// </summary>

        public string DIRCOND_RES2 { get; set; }

        /// <summary>
        ///  Set or get the DNICOND_RES2 property.
        /// </summary>

        public string DNICOND_RES2 { get; set; }

        /// <summary>
        ///  Set or get the FEEXPE_RES2 property.
        /// </summary>

        public DateTime? FEEXPE_RES2 { get; set; }

        /// <summary>
        ///  Set or get the FENACI_RES2 property.
        /// </summary>

        public DateTime? FENACI_RES2 { get; set; }

        /// <summary>
        ///  Set or get the LUEXPE_RES2 property.
        /// </summary>

        public string LUEXPE_RES2 { get; set; }

        /// <summary>
        ///  Set or get the LUNACI_RES2 property.
        /// </summary>

        public string LUNACI_RES2 { get; set; }

        /// <summary>
        ///  Set or get the NACIO_RES2 property.
        /// </summary>

        public string NACIO_RES2 { get; set; }

        /// <summary>
        ///  Set or get the PERMISO_RES2 property.
        /// </summary>

        public string PERMISO_RES2 { get; set; }

        /// <summary>
        ///  Set or get the POCOND_RES2 property.
        /// </summary>

        public string POCOND_RES2 { get; set; }

        /// <summary>
        ///  Set or get the TARCADU_RES2 property.
        /// </summary>

        public string TARCADU_RES2 { get; set; }

        /// <summary>
        ///  Set or get the TARNUM_RES2 property.
        /// </summary>

        public string TARNUM_RES2 { get; set; }

        /// <summary>
        ///  Set or get the TARTI_RES2 property.
        /// </summary>

        public string TARTI_RES2 { get; set; }

        /// <summary>
        ///  Set or get the CPCOND_RES2 property.
        /// </summary>

        public string CPCOND_RES2 { get; set; }

        /// <summary>
        ///  Set or get the CLASE_RES2 property.
        /// </summary>

        public string CLASE_RES2 { get; set; }

        /// <summary>
        ///  Set or get the TELCOND_RES2 property.
        /// </summary>

        public string TELCOND_RES2 { get; set; }

        /// <summary>
        ///  Set or get the IVA_RES2 property.
        /// </summary>

        public Decimal? IVA_RES2 { get; set; }

        /// <summary>
        ///  Set or get the CONTACTO_RES2 property.
        /// </summary>

        public string CONTACTO_RES2 { get; set; }

        /// <summary>
        ///  Set or get the MULDIR_RES2 property.
        /// </summary>

        public string MULDIR_RES2 { get; set; }

        /// <summary>
        ///  Set or get the MULCP_RES2 property.
        /// </summary>

        public string MULCP_RES2 { get; set; }

        /// <summary>
        ///  Set or get the MULPOB_RES2 property.
        /// </summary>

        public string MULPOB_RES2 { get; set; }

        /// <summary>
        ///  Set or get the MULPAIS_RES2 property.
        /// </summary>

        public string MULPAIS_RES2 { get; set; }

        /// <summary>
        ///  Set or get the RUTAFOTO property.
        /// </summary>

        public string RUTAFOTO { get; set; }

        /// <summary>
        ///  Set or get the LINEA1ROT_RES2 property.
        /// </summary>

        public string LINEA1ROT_RES2 { get; set; }

        /// <summary>
        ///  Set or get the LINEA2ROT_RES2 property.
        /// </summary>

        public string LINEA2ROT_RES2 { get; set; }

        /// <summary>
        ///  Set or get the LINEA3ROT_RES2 property.
        /// </summary>

        public string LINEA3ROT_RES2 { get; set; }

        /// <summary>
        ///  Set or get the OTROFEXPE_RES2 property.
        /// </summary>

        public DateTime? OTROFEXPE_RES2 { get; set; }

        /// <summary>
        ///  Set or get the OTRO2FEXPE_RES2 property.
        /// </summary>

        public DateTime? OTRO2FEXPE_RES2 { get; set; }

        /// <summary>
        ///  Set or get the OTRO3FEXPE_RES2 property.
        /// </summary>

        public DateTime? OTRO3FEXPE_RES2 { get; set; }

        /// <summary>
        ///  Set or get the COMICLAVE_RES2 property.
        /// </summary>

        public string COMICLAVE_RES2 { get; set; }

        /// <summary>
        ///  Set or get the COMISIO2_RES2 property.
        /// </summary>

        public string COMISIO2_RES2 { get; set; }

        /// <summary>
        ///  Set or get the USUANU property.
        /// </summary>

        public string USUANU { get; set; }

        /// <summary>
        ///  Set or get the COD_COND1_RES2 property.
        /// </summary>

        public string COD_COND1_RES2 { get; set; }

        /// <summary>
        ///  Set or get the COD_COND2_RES2 property.
        /// </summary>

        public string COD_COND2_RES2 { get; set; }

        /// <summary>
        ///  Set or get the COD_COND3_RES2 property.
        /// </summary>

        public string COD_COND3_RES2 { get; set; }

        /// <summary>
        ///  Set or get the PROVCOND_RES2 property.
        /// </summary>

        public string PROVCOND_RES2 { get; set; }

        /// <summary>
        ///  Set or get the MAILCLI_RES2 property.
        /// </summary>

        public string MAILCLI_RES2 { get; set; }

        /// <summary>
        ///  Set or get the FECADU_RES2 property.
        /// </summary>

        public DateTime? FECADU_RES2 { get; set; }

        /// <summary>
        ///  Set or get the VALOR_RES2 property.
        /// </summary>

        public Decimal? VALOR_RES2 { get; set; }

        /// <summary>
        ///  Set or get the ALOJAMIENTO_RES2 property.
        /// </summary>

        public Decimal? ALOJAMIENTO_RES2 { get; set; }

        /// <summary>
        ///  Set or get the CARGOS_RES2 property.
        /// </summary>

        public Decimal? CARGOS_RES2 { get; set; }

        /// <summary>
        ///  Set or get the DTO_RES2 property.
        /// </summary>

        public Decimal? DTO_RES2 { get; set; }

        /// <summary>
        ///  Set or get the IMPRESA property.
        /// </summary>

        public byte? IMPRESA { get; set; }

        /// <summary>
        ///  Set or get the REVISADA_RES2 property.
        /// </summary>

        public byte? REVISADA_RES2 { get; set; }

        /// <summary>
        ///  Set or get the PAISCOND_RES2 property.
        /// </summary>

        public string PAISCOND_RES2 { get; set; }

        /// <summary>
        ///  Set or get the MAILCOND_RES2 property.
        /// </summary>

        public string MAILCOND_RES2 { get; set; }

        /// <summary>
        ///  Set or get the TEL2COND_RES2 property.
        /// </summary>

        public string TEL2COND_RES2 { get; set; }

        /// <summary>
        ///  Set or get the BASECALC_RES2 property.
        /// </summary>

        public Decimal? BASECALC_RES2 { get; set; }

        /// <summary>
        ///  Set or get the IVACALC_RES2 property.
        /// </summary>

        public Decimal? IVACALC_RES2 { get; set; }

        /// <summary>
        ///  Set or get the PORIVACALC_RES2 property.
        /// </summary>

        public Decimal? PORIVACALC_RES2 { get; set; }

        /// <summary>
        ///  Set or get the PAISNIFCOND_RES2 property.
        /// </summary>

        public string PAISNIFCOND_RES2 { get; set; }

        /// <summary>
        ///  Set or get the FCADUNIFCOND_RES2 property.
        /// </summary>

        public DateTime? FCADUNIFCOND_RES2 { get; set; }

        /// <summary>
        ///  Set or get the DIRHOTELCOND_RES2 property.
        /// </summary>

        public string DIRHOTELCOND_RES2 { get; set; }

        /// <summary>
        ///  Set or get the OBS_LOAD_MAIL property.
        /// </summary>

        public string OBS_LOAD_MAIL { get; set; }

        /// <summary>
        ///  Set or get the DRV1_DRIVER_SALUTATION property.
        /// </summary>

        public string DRV1_DRIVER_SALUTATION { get; set; }

        /// <summary>
        ///  Set or get the DRV1_DRIVER_FIRSTNAME property.
        /// </summary>

        public string DRV1_DRIVER_FIRSTNAME { get; set; }

        /// <summary>
        ///  Set or get the DRV1_DRIVER_LASTNAME property.
        /// </summary>

        public string DRV1_DRIVER_LASTNAME { get; set; }

        /// <summary>
        ///  Set or get the DRV2_DRIVER_SALUTATION property.
        /// </summary>

        public string DRV2_DRIVER_SALUTATION { get; set; }

        /// <summary>
        ///  Set or get the DRV2_DRIVER_FIRSTNAME property.
        /// </summary>

        public string DRV2_DRIVER_FIRSTNAME { get; set; }

        /// <summary>
        ///  Set or get the DRV2_DRIVER_LASTNAME property.
        /// </summary>

        public string DRV2_DRIVER_LASTNAME { get; set; }

        /// <summary>
        ///  Set or get the DRV2_BIRTHDATE property.
        /// </summary>

        public DateTime? DRV2_BIRTHDATE { get; set; }

        /// <summary>
        ///  Set or get the DRV2_CITY_OF_BIRTH property.
        /// </summary>

        public string DRV2_CITY_OF_BIRTH { get; set; }

        /// <summary>
        ///  Set or get the DRV2_COU_CODE property.
        /// </summary>

        public string DRV2_COU_CODE { get; set; }

        /// <summary>
        ///  Set or get the DRV2_STREET property.
        /// </summary>

        public string DRV2_STREET { get; set; }

        /// <summary>
        ///  Set or get the DRV2_ZIP_CODE property.
        /// </summary>

        public string DRV2_ZIP_CODE { get; set; }

        /// <summary>
        ///  Set or get the DRV2_CITY property.
        /// </summary>

        public string DRV2_CITY { get; set; }

        /// <summary>
        ///  Set or get the DRV2_LICENSE_NR property.
        /// </summary>

        public string DRV2_LICENSE_NR { get; set; }

        /// <summary>
        ///  Set or get the DRV2_ID_CARD_NR property.
        /// </summary>

        public string DRV2_ID_CARD_NR { get; set; }

        /// <summary>
        ///  Set or get the DRV2_LICENSE_ISSUE_AUTHORITY property.
        /// </summary>

        public string DRV2_LICENSE_ISSUE_AUTHORITY { get; set; }

        /// <summary>
        ///  Set or get the DRV2_ID_CARD_ISSUE_AUTHORITY property.
        /// </summary>

        public string DRV2_ID_CARD_ISSUE_AUTHORITY { get; set; }

        /// <summary>
        ///  Set or get the DRV2_LICENSE_COU_CODE property.
        /// </summary>

        public string DRV2_LICENSE_COU_CODE { get; set; }

        /// <summary>
        ///  Set or get the DRV2_ID_CARD_COU_CODE property.
        /// </summary>

        public string DRV2_ID_CARD_COU_CODE { get; set; }

        /// <summary>
        ///  Set or get the DRV2_LICENSE_ISSUE_DATE property.
        /// </summary>

        public DateTime? DRV2_LICENSE_ISSUE_DATE { get; set; }

        /// <summary>
        ///  Set or get the DRV2_ID_CARD_ISSUE_DATE property.
        /// </summary>

        public DateTime? DRV2_ID_CARD_ISSUE_DATE { get; set; }

        /// <summary>
        ///  Set or get the DRV2_ID_CARD_VALID_DATE property.
        /// </summary>

        public DateTime? DRV2_ID_CARD_VALID_DATE { get; set; }

        /// <summary>
        ///  Set or get the DRV2_MAIL property.
        /// </summary>

        public string DRV2_MAIL { get; set; }

        /// <summary>
        ///  Set or get the DRV2_TEL property.
        /// </summary>

        public string DRV2_TEL { get; set; }

        /// <summary>
        ///  Set or get the DRV2_MOBIL property.
        /// </summary>

        public string DRV2_MOBIL { get; set; }

        /// <summary>
        ///  Set or get the DRV1_LICENSE_COU_CODE property.
        /// </summary>

        public string DRV1_LICENSE_COU_CODE { get; set; }

        /// <summary>
        ///  Set or get the DRV1_ID_CARD_ISSUE_DATE property.
        /// </summary>

        public DateTime? DRV1_ID_CARD_ISSUE_DATE { get; set; }

        /// <summary>
        ///  Set or get the DRV1_ID_CARD_ISSUE_AUTHORITY property.
        /// </summary>

        public string DRV1_ID_CARD_ISSUE_AUTHORITY { get; set; }

        /// <summary>
        ///  Set or get the TARCADU_DATE_RES2 property.
        /// </summary>

        public DateTime? TARCADU_DATE_RES2 { get; set; }

        /// <summary>
        ///  Set or get the TITULAR_RES2 property.
        /// </summary>

        public string TITULAR_RES2 { get; set; }

        /// <summary>
        ///  Set or get the DRV2_CLASE_RES2 property.
        /// </summary>

        public string DRV2_CLASE_RES2 { get; set; }

        /// <summary>
        ///  Set or get the RENTFOX_CUSTOMER_GROUP property.
        /// </summary>

        public string RENTFOX_CUSTOMER_GROUP { get; set; }

        /// <summary>
        ///  Set or get the RENTFOX_CUSTOMER_ID property.
        /// </summary>

        public string RENTFOX_CUSTOMER_ID { get; set; }

        /// <summary>
        ///  Set or get the RENTFOX_DRIVER_ID property.
        /// </summary>

        public string RENTFOX_DRIVER_ID { get; set; }

        /// <summary>
        ///  Set or get the OTROFVTO_RES2 property.
        /// </summary>

        public DateTime? OTROFVTO_RES2 { get; set; }

        /// <summary>
        ///  Set or get the OTRO2FVTO_RES2 property.
        /// </summary>

        public DateTime? OTRO2FVTO_RES2 { get; set; }

        /// <summary>
        ///  Set or get the OTRO3FVTO_RES2 property.
        /// </summary>

        public DateTime? OTRO3FVTO_RES2 { get; set; }

        /// <summary>
        ///  Set or get the SECONFIRMO_RES2 property.
        /// </summary>

        public byte? SECONFIRMO_RES2 { get; set; }

        /// <summary>
        ///  Set or get the OTRONAC_RES2 property.
        /// </summary>

        public DateTime? OTRONAC_RES2 { get; set; }

        /// <summary>
        ///  Set or get the OTRONAC2_RES2 property.
        /// </summary>

        public DateTime? OTRONAC2_RES2 { get; set; }

        /// <summary>
        ///  Set or get the OTRONAC3_RES2 property.
        /// </summary>

        public DateTime? OTRONAC3_RES2 { get; set; }

        /// <summary>
        ///  Set or get the OBS1_RTF_RES2 property.
        /// </summary>

        public string OBS1_RTF_RES2 { get; set; }

        /// <summary>
        ///  Set or get the ACCESORIOS_RES2 property.
        /// </summary>

        public string ACCESORIOS_RES2 { get; set; }

        /// <summary>
        ///  Set or get the OBS_RESERVITA_RES2 property.
        /// </summary>

        public string OBS_RESERVITA_RES2 { get; set; }

        /// <summary>
        ///  Set or get the PRINT_RESERVITAS_RES2 property.
        /// </summary>

        public Int32? PRINT_RESERVITAS_RES2 { get; set; }

        /// <summary>
        ///  Set or get the NUMOTROCOND_RES2 property.
        /// </summary>

        public string NUMOTROCOND_RES2 { get; set; }

        /// <summary>
        ///  Set or get the NUMOTRO2COND_RES2 property.
        /// </summary>

        public string NUMOTRO2COND_RES2 { get; set; }

        /// <summary>
        ///  Set or get the NUMOTRO3COND_RES2 property.
        /// </summary>

        public string NUMOTRO3COND_RES2 { get; set; }

        /// <summary>
        ///  Set or get the TOTAL_PP property.
        /// </summary>

        public Decimal? TOTAL_PP { get; set; }

        /// <summary>
        ///  Set or get the TOTAL_POA property.
        /// </summary>

        public Decimal? TOTAL_POA { get; set; }

        /// <summary>
        ///  Set or get the CRM_RES2 property.
        /// </summary>

        public byte? CRM_RES2 { get; set; }

        /// <summary>
        ///  Set or get the PRECONTRA_RES2 property.
        /// </summary>

        public byte? PRECONTRA_RES2 { get; set; }

        /// <summary>
        ///  Set or get the AMBITO_RES2 property.
        /// </summary>

        public string AMBITO_RES2 { get; set; }

        /// <summary>
        ///  Set or get the ECOTASA_RES2 property.
        /// </summary>

        public Decimal? ECOTASA_RES2 { get; set; }

        /// <summary>
        ///  Set or get the TOTAL_ALQ_RES2 property.
        /// </summary>

        public Decimal? TOTAL_ALQ_RES2 { get; set; }

        /// <summary>
        ///  Set or get the TOTAL_EXTRAS_RES2 property.
        /// </summary>

        public Decimal? TOTAL_EXTRAS_RES2 { get; set; }

        /// <summary>
        ///  Set or get the IMPORTE_PREPAGADO_RES2 property.
        /// </summary>

        public Decimal? IMPORTE_PREPAGADO_RES2 { get; set; }

        /// <summary>
        ///  Set or get the OTROPER_RES2 property.
        /// </summary>

        public string OTROPER_RES2 { get; set; }

        /// <summary>
        ///  Set or get the OTRO2PER_RES2 property.
        /// </summary>

        public string OTRO2PER_RES2 { get; set; }

        /// <summary>
        ///  Set or get the OTRO3PER_RES2 property.
        /// </summary>

        public string OTRO3PER_RES2 { get; set; }

        /// <summary>
        ///  Set or get the OBSINTERNAS_RES2 property.
        /// </summary>

        public string OBSINTERNAS_RES2 { get; set; }

        /// <summary>
        ///  Set or get the MOTIVO_NOCONFIRM_RES2 property.
        /// </summary>
        public string MOTIVO_NOCONFIRM_RES2 { get; set; }


        /// <summary>
        ///  Items of the booking.
        /// </summary>
        public IEnumerable<BookingItemsDto> BookingItems { set; get; }

    }
}
