using KarveCar.Utility;
using static KarveCommon.Generic.RecopilatorioEnumerations;

namespace KarveCar.Logic.ToolBar
{
    public class EditarToolBarLogic
    {
        public static void EditarToolBar()
        {
            EOpcion opcion = TabControlAndTabItemUtil.TabControlSelectedItemEOpcion();

            switch (opcion)
            {
                #region Maestros
                case EOpcion.rbtnEmpresas:
                    break;
                case EOpcion.rbtnOficinas:
                    break;
                case EOpcion.rbtnZonasOficina:
                    break;

                case EOpcion.rbtnClientes:
                    break;
                case EOpcion.rbtnCambioCodigoCliente:
                    break;
                case EOpcion.rbtnEntradaRapida:
                    break;

                case EOpcion.rbtnComisionistas:
                    break;

                case EOpcion.rbtnProveedores:
                    break;

                case EOpcion.rbtnTarifas:
                    break;
                case EOpcion.rbtnCambioCodigoTarifas:
                    break;
                case EOpcion.rbtnCrearTarifaDesdeOtraTarifa:
                    break;
                case EOpcion.rbtnIncrementoPrecios:
                    break;
                case EOpcion.rbtnTarifaCliente:
                    break;
                case EOpcion.rbtnTarifasComisionista:
                    break;
                case EOpcion.rbtnVerTarifa:
                    break;
                case EOpcion.rbtnVincularClienteTarifa:
                    break;

                case EOpcion.rbtnVehiculos:
                    break;
                case EOpcion.rbtnCambioCodigoVehiculo:
                    break;
                case EOpcion.rbtnModificacionMasivaAux:
                    break;
                case EOpcion.rbtnRecalculoMantenimiento:
                    break;

                case EOpcion.rbtnBancosClientes:
                    break;
                case EOpcion.rbtnBloqueFacturacion:
                    break;
                case EOpcion.rbtnCanales:
                    break;
                case EOpcion.rbtnCargosPersonal:
                    break;
                case EOpcion.rbtnCCAA:
                    break;
                case EOpcion.rbtnClavesPresupuesto:
                    break;
                case EOpcion.rbtnFormasCobroClientes:
                    break;
                case EOpcion.rbtnMercados:
                    break;
                case EOpcion.rbtnNegocios:
                    break;
                case EOpcion.rbtnOrigenClientes:
                    break;
                case EOpcion.rbtnPaises:
                    break;
                case EOpcion.rbtnPoblaciones:
                    break;
                case EOpcion.rbtnProvincias:
                    break;
                case EOpcion.rbtnSectoresActividad:
                    break;
                case EOpcion.rbtnTarjetasCredito:
                    break;
                case EOpcion.rbtnTarjetasEmpresa:
                    break;
                case EOpcion.rbtnTiposCliente:
                    break;
                case EOpcion.rbtnTiposContacto:
                    break;
                case EOpcion.rbtnTiposVisita:
                    break;
                case EOpcion.rbtnUsoAlquiler:
                    break;
                case EOpcion.rbtnVendedores:
                    break;
                case EOpcion.rbtnZonasCliente:
                    break;

                case EOpcion.rbtnEmpleadosAgencia:
                    break;
                case EOpcion.rbtnTipoComisionista:
                    break;

                case EOpcion.rbtnAccesorios:
                    break;
                case EOpcion.rbtnLugaresEntrega:
                    break;
                case EOpcion.rbtnMotivosAnulacionContratos:
                    break;
                case EOpcion.rbtnMotivosCambioVehiculo:
                    break;
                case EOpcion.rbtnMotivosCancelacion:
                    break;
                case EOpcion.rbtnMotivosImproductivo:
                    break;
                case EOpcion.rbtnTipoImpresoContrato:
                    break;

                case EOpcion.rbtnTiposIncidenciasClientes:
                    break;
                case EOpcion.rbtnTiposIncidenciasContratos:
                    break;
                case EOpcion.rbtnTiposIncidenciasProveedores:
                    break;
                case EOpcion.rbtnTiposIncidenciasReservas:
                    break;

                case EOpcion.rbtnDivisas:
                    break;
                case EOpcion.rbtnFormaPagoProveedor:
                    break;
                case EOpcion.rbtnTiposProveedores:
                    break;

                case EOpcion.rbtnClavesFee:
                    break;
                case EOpcion.rbtnMediosRecepcion:
                    break;
                case EOpcion.rbtnMotivosAnulacionReservas:
                    break;
                case EOpcion.rbtnMotivosNoServicio:
                    break;

                case EOpcion.rbtnConceptosFacturacion:
                    break;
                case EOpcion.rbtnGruposTarifa:
                    break;

                case EOpcion.rbtnAccesoriosVehiculos:
                    break;
                case EOpcion.rbtnActividadesVehiculos:
                    break;
                case EOpcion.rbtnCodigosInmovilizacion:
                    break;
                case EOpcion.rbtnCodigosMantenimiento:
                    break;
                case EOpcion.rbtnColores:
                    break;
                case EOpcion.rbtnExtras:
                    break;
                case EOpcion.rbtnFormasTraslado:
                    break;
                case EOpcion.rbtnGruposVehiculos:
                    break;
                case EOpcion.rbtnMarcas:
                    break;
                case EOpcion.rbtnModelos:
                    break;
                case EOpcion.rbtnMotivosRepostaje:
                    break;
                case EOpcion.rbtnPropietarios:
                    break;
                case EOpcion.rbtnTiposVehiculos:
                    break;

                case EOpcion.rbtnCategoriasPersonal:
                    break;
                case EOpcion.rbtnConceptosSalidaCaja:
                    break;
                case EOpcion.rbtnTextosEstandars:
                    break;
                case EOpcion.rbtnTipoContactoPotencial:
                    break;
                case EOpcion.rbtnTiposDocumentos:
                    break;
                case EOpcion.rbtnTipoImpresoFactura:
                    break;
                #endregion

                #region Contratos
                case EOpcion.rbtnAbrirContrato:
                    break;
                case EOpcion.rbtnAnularContrato:
                    break;
                case EOpcion.rbtnCerrarContrato:
                    break;
                case EOpcion.rbtnConcultarContrato:
                    break;
                case EOpcion.rbtnReAbrirContrato:
                    break;

                case EOpcion.rbtnCambioConductor:
                    break;
                case EOpcion.rbtnCambioNumeroContrato:
                    break;
                case EOpcion.rbtnCambioOficinaContrato:
                    break;
                case EOpcion.rbtnCambioVehiculo:
                    break;

                case EOpcion.rbtnEntregaContratosOficina:
                    break;
                case EOpcion.rbtnImpresionBloqueContratos:
                    break;
                case EOpcion.rbtnPlantilla:
                    break;
                case EOpcion.rbtnProcesoCierreContratos:
                    break;
                case EOpcion.rbtnProlongacionAutomaticaContratos:
                    break;
                #endregion

                #region Reservas
                case EOpcion.rbtnReservas:
                    break;
                case EOpcion.rbtnAnularReserva:
                    break;
                case EOpcion.rbtnConvertirReservaContrato:
                    break;
                case EOpcion.rbtnCotizacionComparada:
                    break;
                case EOpcion.rbtnEliminarReservasNoShow:
                    break;
                case EOpcion.rbtnPeticiones:
                    break;
                #endregion

                #region Atipicos
                case EOpcion.rbtnAlquilerBicicletas:
                    break;
                case EOpcion.rbtnFacturasAtipicas:
                    break;
                case EOpcion.rbtnImpresionBloque:
                    break;
                case EOpcion.rbtnSalidaCaja:
                    break;
                case EOpcion.rbtnSeriesAtipicos:
                    break;
                #endregion

                #region Comercial
                case EOpcion.rbtnCustomerService:
                    break;
                case EOpcion.rbtnEntregaBonos:
                    break;
                case EOpcion.rbtnEMailingClientes:
                    break;
                case EOpcion.rbtneEMailingPotenciales:
                    break;
                case EOpcion.rbtnPotenciales:
                    break;
                #endregion

                #region Facturacion
                case EOpcion.rbtnAbonarFactura:
                    break;
                case EOpcion.rbtnBorrarFacturasPeriodo:
                    break;
                case EOpcion.rbtnCambioNumeroFactura:
                    break;
                case EOpcion.rbtnCambioVendedorFacturas:
                    break;
                case EOpcion.rbtnCartaPendientes:
                    break;
                case EOpcion.rbtnConsultaModificacion:
                    break;
                case EOpcion.rbtnModificarEmpresaOficinaFactura:
                    break;
                case EOpcion.rbtnModificarFacturaContrato:
                    break;
                case EOpcion.rbtnProcesoFacturacion:
                    break;

                case EOpcion.rbtnRecibos:
                    break;
                case EOpcion.rbtnCobrosIndividuales:
                    break;
                case EOpcion.rbtnGestionImpagados:
                    break;
                case EOpcion.rbtnRefundirRecibosNoCobrados:
                    break;

                case EOpcion.rbtnRemesas:
                    break;
                case EOpcion.rbtnAnulacionPaseRemesaContabilidad:
                    break;
                case EOpcion.rbtnBancosRemesas:
                    break;
                case EOpcion.rbtnPaseSoporteMagnetico:
                    break;
                case EOpcion.rbtnPaseRemesaContabilidad:
                    break;

                case EOpcion.rbtnAnulacionPase:
                    break;
                case EOpcion.rbtnPaseCobrosRecibos:
                    break;
                case EOpcion.rbtnPaseFacturas:
                    break;
                case EOpcion.rbtnPaseFacturasAtipicas:
                    break;
                case EOpcion.rbtnPaseTesoreriaCaja:
                    break;

                case EOpcion.rbtnExportacionFichero340:
                    break;
                case EOpcion.rbtnExportacionFichero347:
                    break;

                case EOpcion.rbtnImpresionBloqueFacturas:
                    break;
                case EOpcion.rbtnImpresionBloqueRecibos:
                    break;

                case EOpcion.rgrEstadisticasFacturas:
                    break;
                #endregion

                #region Flota
                case EOpcion.rbtnInmovilizaciones:
                    break;
                case EOpcion.rbtnEntradaGastosVehiculo:
                    break;
                case EOpcion.rbtnGeneradorEstadisticasInmovilizaciones:
                    break;

                case EOpcion.rbtnActualizarVtoITV:
                    break;
                case EOpcion.rbtnBastidorRadioLlave:
                    break;
                case EOpcion.rbtnCambioFechaBajaVehiculo:
                    break;
                case EOpcion.rbtnCambioUbicacionKMSituacion:
                    break;
                case EOpcion.rbtnDatosSeguros:
                    break;
                case EOpcion.rbtnFlotaVtoRecibosSeguros:
                    break;
                case EOpcion.rbtnModificacionMasivaFlota:
                    break;
                case EOpcion.rbtnTraslados:
                    break;

                case EOpcion.rbtnCambioEmpresa:
                    break;
                case EOpcion.rbtnCambioUbicacion:
                    break;
                case EOpcion.rbtnDescargarMultas:
                    break;
                case EOpcion.rbtnHistoricoSeguros:
                    break;
                case EOpcion.rbtnImpresionLlaveros:
                    break;
                case EOpcion.rbtnPrevisionEntradas:
                    break;
                case EOpcion.rbtnRecalculoSituación:
                    break;
                case EOpcion.rbtnRepostaje:
                    break;
                case EOpcion.rbtnSiniestros:
                    break;
                #endregion

                #region Incidencias
                case EOpcion.rbtnIncidenciasClientes:
                    break;
                case EOpcion.rbtnIncidenciasContratos:
                    break;
                case EOpcion.rbtnIncidenciasProveedores:
                    break;
                case EOpcion.rbtnIncidenciasReservas:
                    break;
                case EOpcion.rbtnIncidenciasVehiculos:
                    break;
                case EOpcion.rbtnEstadisticasAnaliticas:
                    break;
                #endregion

                #region Estadisticas
                case EOpcion.rbtnEstadisticasClientes:
                    break;
                case EOpcion.rbtnEstadisticasContratos:
                    break;
                case EOpcion.rbtnEstadisticasFacturas:
                    break;
                case EOpcion.rbtnEstadisticasPeticiones:
                    break;
                case EOpcion.rbtnEstadisticasProveedores:
                    break;
                case EOpcion.rbtnEstadisticasReservas:
                    break;
                case EOpcion.rbtnEstadisticasUtilitarios:
                    break;
                case EOpcion.rbtnEstadisticasVehiculos:
                    break;
                #endregion

                #region Listados
                case EOpcion.rbtnListadosClientes:
                    break;
                case EOpcion.rbtnListadosComisionistas:
                    break;
                case EOpcion.rbtnListadosContratos:
                    break;
                case EOpcion.rbtnListadosFicherosAuxiliares:
                    break;
                case EOpcion.rbtnListadosFacturas:
                    break;
                case EOpcion.rbtnListadosPeticiones:
                    break;
                case EOpcion.rbtnListadosPotenciales:
                    break;
                case EOpcion.rbtnListadosProveedores:
                    break;
                case EOpcion.rbtnListadosReservas:
                    break;
                case EOpcion.rbtnListadosVehiculos:
                    break;
                #endregion

                #region Configuracion
                case EOpcion.rbtnCinta:
                    break;
                case EOpcion.rbtnCodigosIniciales:
                    break;
                case EOpcion.rbtnEmpresa:
                    break;
                case EOpcion.rbtnEnlaceContabilidad:
                    break;
                case EOpcion.rbtnEquipo:
                    break;
                case EOpcion.rbtnFacturacion:
                    break;
                case EOpcion.rbtnbiImpresion:
                    break;
                case EOpcion.rbtnKarve:
                    break;
                case EOpcion.rbtnMaestros:
                    break;
                case EOpcion.rbtnOficina:
                    break;
                case EOpcion.rbtnOperaciones:
                    break;
                case EOpcion.rbtnOtros:
                    break;

                case EOpcion.rbtnInformes:
                    break;
                case EOpcion.rbtnPrograma:
                    break;

                case EOpcion.rbtnIdiomaESES:
                    break;
                case EOpcion.rbtnIdiomaCAES:
                    break;
                case EOpcion.rbtnIdiomaENGB:
                    break;

                case EOpcion.rbtnMailingPersonal:
                    break;
                case EOpcion.rbtnPersonal:
                    break;

                case EOpcion.rbtnBorrarFicherosEnvioEmail:
                    break;
                case EOpcion.rbtnCambiarIVA:
                    break;
                case EOpcion.rbtnComunicacionPolicia:
                    break;
                case EOpcion.rbtnConsultaSQL:
                    break;
                case EOpcion.rbtnDesbloquearContratosFacturando:
                    break;
                case EOpcion.rbtnDeteccionHuecos:
                    break;
                case EOpcion.rbtnDeteccionInconsistencias:
                    break;
                case EOpcion.rbtnDesvincularContratosReservas:
                    break;
                case EOpcion.rbtnLimpiarInformacionAntigua:
                    break;
                case EOpcion.rbtnLimpiarCodigosReserva:
                    break;
                case EOpcion.rbtnRecalcularMantenimientos:
                    break;
                case EOpcion.rbtnRecalcularPendientes:
                    break;
                case EOpcion.rbtnRehacerIndices:
                    break;
                case EOpcion.rbtnRelojesActivos:
                    break;
                case EOpcion.rbtnVincularContratosReservas:
                    break;
                case EOpcion.rbtnVincularContratosReservasNoVinculadas:
                    break;

                case EOpcion.rbtnCambiarContrasenyas:
                    break;
                case EOpcion.rbtnPreciosCombustible:
                    break;
                case EOpcion.rbtnUsuarios:
                    break;

                case EOpcion.rbtnAcercaDe:
                    break;
                case EOpcion.rbtnContrasenyasKarve:
                    break;
                case EOpcion.rbtnDescargarActualizacion:
                    break;
                case EOpcion.rbtnMensajeEntrada:
                    break;
                case EOpcion.rbtnNovedades:
                    break;
                #endregion
                default:
                    break;
            }
        }
    }
}
