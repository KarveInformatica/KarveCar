using KarveCar.Utility;
using KarveCar.View;
using System.Windows;
using static KarveCar.Model.Generic.RecopilatorioEnumerations;

namespace KarveCar.Logic.ToolBar
{
    public class ToolBarLogic
    {
        /// <summary>
        /// Recupera el EOpcion del TabItem seleccionado del Tabcontrol para poder habilitar/deshabilitar 
        /// los Buttons y el TextBox de búsqueda del ToolBar según corresponda
        /// </summary>
        public static void EnabledDisabledToolBarButtonsByEOpcion()
        {
            EnabledDisabledToolBarButtonsByEOpcion(TabControlAndTabItemUtil.TabControlSelectedItemEOpcion());
        }

        /// <summary>
        /// Habilita/deshabilita los Buttons y el TextBox de búsqueda del ToolBar según el EOpcion recibido por params
        /// </summary>
        /// <param name="opcion"></param>
        public static void EnabledDisabledToolBarButtonsByEOpcion(EOpcion opcion)
        {
            switch (opcion)
            {
                #region Maestros
                case EOpcion.rbtnEmpresas:
                    break;
                case EOpcion.rbtnOficinas:
                    break;
                case EOpcion.rbtnZonasOficina:
                    ToolBarButtonsByEOpcion(false, false, false, true, true, true, true, true, false, true);
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
                    ToolBarButtonsByEOpcion(false, false, false, true, true, true, true, true, false, true);
                    break;
                case EOpcion.rbtnBloqueFacturacion:
                    ToolBarButtonsByEOpcion(false, false, false, true, true, true, true, true, false, true);
                    break;
                case EOpcion.rbtnCanales:
                    ToolBarButtonsByEOpcion(false, false, false, true, true, true, true, true, false, true);
                    break;
                case EOpcion.rbtnCargosPersonal:
                    ToolBarButtonsByEOpcion(false, false, false, true, true, true, true, true, false, true);
                    break;
                case EOpcion.rbtnCCAA:
                    ToolBarButtonsByEOpcion(false, false, false, true, true, true, true, true, false, true);
                    break;
                case EOpcion.rbtnClavesPresupuesto:
                    ToolBarButtonsByEOpcion(false, false, false, true, true, true, true, true, false, true);
                    break;
                case EOpcion.rbtnFormasCobroClientes:
                    break;
                case EOpcion.rbtnMercados:
                    ToolBarButtonsByEOpcion(false, false, false, true, true, true, true, true, false, true);
                    break;
                case EOpcion.rbtnNegocios:
                    ToolBarButtonsByEOpcion(false, false, false, true, true, true, true, true, false, true);
                    break;
                case EOpcion.rbtnOrigenClientes:
                    ToolBarButtonsByEOpcion(false, false, false, true, true, true, true, true, false, true);
                    break;
                case EOpcion.rbtnPaises:
                    break;
                case EOpcion.rbtnPoblaciones:
                    ToolBarButtonsByEOpcion(false, false, false, true, true, true, true, true, false, true);
                    break;
                case EOpcion.rbtnProvincias:
                    ToolBarButtonsByEOpcion(false, false, false, true, true, true, true, true, false, true);
                    break;
                case EOpcion.rbtnSectoresActividad:
                    ToolBarButtonsByEOpcion(false, false, false, true, true, true, true, true, false, true);
                    break;
                case EOpcion.rbtnTarjetasCredito:
                    ToolBarButtonsByEOpcion(false, false, false, true, true, true, true, true, false, true);
                    break;
                case EOpcion.rbtnTarjetasEmpresa:
                    ToolBarButtonsByEOpcion(false, false, false, true, true, true, true, true, false, true);
                    break;
                case EOpcion.rbtnTiposCliente:
                    ToolBarButtonsByEOpcion(false, false, false, true, true, true, true, true, false, true);
                    break;
                case EOpcion.rbtnTiposContacto:
                    ToolBarButtonsByEOpcion(false, false, false, true, true, true, true, true, false, true);
                    break;
                case EOpcion.rbtnTiposVisita:
                    break;
                case EOpcion.rbtnUsoAlquiler:
                    ToolBarButtonsByEOpcion(false, false, false, true, true, true, true, true, false, true);
                    break;
                case EOpcion.rbtnVendedores:
                    break;
                case EOpcion.rbtnZonasCliente:
                    ToolBarButtonsByEOpcion(false, false, false, true, true, true, true, true, false, true);
                    break;

                case EOpcion.rbtnEmpleadosAgencia:
                    break;
                case EOpcion.rbtnTipoComisionista:
                    ToolBarButtonsByEOpcion(false, false, false, true, true, true, false, false, false, true);
                    break;

                case EOpcion.rbtnAccesorios:
                    break;
                case EOpcion.rbtnLugaresEntrega:
                    break;
                case EOpcion.rbtnMotivosAnulacionContratos:
                    ToolBarButtonsByEOpcion(false, false, false, true, true, true, true, true, false, true);
                    break;
                case EOpcion.rbtnMotivosCambioVehiculo:
                    ToolBarButtonsByEOpcion(false, false, false, true, true, true, true, true, false, true);
                    break;
                case EOpcion.rbtnMotivosCancelacion:
                    ToolBarButtonsByEOpcion(false, false, false, true, true, true, true, true, false, true);
                    break;
                case EOpcion.rbtnMotivosImproductivo:
                    ToolBarButtonsByEOpcion(false, false, false, true, true, true, true, true, false, true);
                    break;
                case EOpcion.rbtnTipoImpresoContrato:
                    ToolBarButtonsByEOpcion(false, false, false, true, true, true, true, true, false, true);
                    break;

                case EOpcion.rbtnTiposIncidenciasClientes:
                    ToolBarButtonsByEOpcion(false, false, false, true, true, true, true, true, false, true);
                    break;
                case EOpcion.rbtnTiposIncidenciasContratos:
                    ToolBarButtonsByEOpcion(false, false, false, true, true, true, true, true, false, true);
                    break;
                case EOpcion.rbtnTiposIncidenciasProveedores:
                    ToolBarButtonsByEOpcion(false, false, false, true, true, true, true, true, false, true);
                    break;
                case EOpcion.rbtnTiposIncidenciasReservas:
                    ToolBarButtonsByEOpcion(false, false, false, true, true, true, true, true, false, true);
                    break;

                case EOpcion.rbtnDivisas:
                    ToolBarButtonsByEOpcion(false, false, false, true, true, true, true, true, false, true);
                    break;
                case EOpcion.rbtnFormaPagoProveedor:
                    ToolBarButtonsByEOpcion(false, false, false, true, true, true, false, false, false, true);
                    break;
                case EOpcion.rbtnTiposProveedores:
                    ToolBarButtonsByEOpcion(false, false, false, true, true, true, true, true, false, true);
                    break;

                case EOpcion.rbtnClavesFee:
                    ToolBarButtonsByEOpcion(false, false, false, true, true, true, true, true, false, true);
                    break;
                case EOpcion.rbtnMediosRecepcion:
                    ToolBarButtonsByEOpcion(false, false, false, true, true, true, true, true, false, true);
                    break;
                case EOpcion.rbtnMotivosAnulacionReservas:
                    ToolBarButtonsByEOpcion(false, false, false, true, true, true, true, true, false, true);
                    break;
                case EOpcion.rbtnMotivosNoServicio:
                    ToolBarButtonsByEOpcion(false, false, false, true, true, true, true, true, false, true);
                    break;

                case EOpcion.rbtnConceptosFacturacion:
                    break;
                case EOpcion.rbtnGruposTarifa:
                    ToolBarButtonsByEOpcion(false, false, false, true, true, true, false, false, false, true);
                    break;

                case EOpcion.rbtnAccesoriosVehiculos:
                    ToolBarButtonsByEOpcion(false, false, false, true, true, true, true, true, false, true);
                    break;
                case EOpcion.rbtnActividadesVehiculos:
                    ToolBarButtonsByEOpcion(false, false, false, true, true, true, true, true, false, true);
                    break;
                case EOpcion.rbtnCodigosInmovilizacion:
                    ToolBarButtonsByEOpcion(false, false, false, true, true, true, true, true, false, true);
                    break;
                case EOpcion.rbtnCodigosMantenimiento:
                    break;
                case EOpcion.rbtnColores:
                    ToolBarButtonsByEOpcion(false, false, false, true, true, true, true, true, false, true);
                    break;
                case EOpcion.rbtnExtras:
                    break;
                case EOpcion.rbtnFormasTraslado:
                    ToolBarButtonsByEOpcion(false, false, false, true, true, true, true, true, false, true);
                    break;
                case EOpcion.rbtnGruposVehiculos:
                    break;
                case EOpcion.rbtnMarcas:
                    break;
                case EOpcion.rbtnModelos:
                    break;
                case EOpcion.rbtnMotivosRepostaje:
                    ToolBarButtonsByEOpcion(false, false, false, true, true, true, true, true, false, true);
                    break;
                case EOpcion.rbtnPropietarios:
                    break;
                case EOpcion.rbtnTiposVehiculos:
                    ToolBarButtonsByEOpcion(false, false, false, true, true, true, true, true, false, true);
                    break;

                case EOpcion.rbtnCategoriasPersonal:
                    break;
                case EOpcion.rbtnConceptosSalidaCaja:
                    ToolBarButtonsByEOpcion(false, false, false, true, true, true, true, true, false, true);
                    break;
                case EOpcion.rbtnTextosEstandars:
                    break;
                case EOpcion.rbtnTipoContactoPotencial:
                    ToolBarButtonsByEOpcion(false, false, false, true, true, true, true, true, false, true);
                    break;
                case EOpcion.rbtnTiposDocumentos:
                    break;
                case EOpcion.rbtnTipoImpresoFactura:
                    ToolBarButtonsByEOpcion(false, false, false, true, true, true, true, true, false, true);
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
                    ToolBarButtonsByEOpcion(false, false, false, true, true, false, false, false, false, false);
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
                    ToolBarButtonsByEOpcion(false, false, false, false, false, false, false, false, false, false);
                    break;
            }
        }

        /// <summary>
        /// Establece para los Buttons del ToolBar y el TextBox de búsqueda, si cada uno de ellos debe estar habilitado/deshabilitado
        /// </summary>
        /// <param name="nuevo"></param>
        /// <param name="editar"></param>
        /// <param name="eliminar"></param>
        /// <param name="guardar"></param>
        /// <param name="cancelar"></param>
        /// <param name="imprimir"></param>
        /// <param name="anterior"></param>
        /// <param name="siguiente"></param>
        /// <param name="salir"></param>
        /// <param name="buscar"></param>
        private static void ToolBarButtonsByEOpcion(bool nuevo, bool editar, bool eliminar, bool guardar, bool cancelar, bool imprimir, bool anterior, bool siguiente, bool salir, bool buscar)
        {
            /*
            ((MainWindow)Application.Current.MainWindow).tbbtnNuevo.IsEnabled = nuevo;
            ((MainWindow)Application.Current.MainWindow).tbbtnEditar.IsEnabled = editar;
            ((MainWindow)Application.Current.MainWindow).tbbtnEliminar.IsEnabled = eliminar;
            ((MainWindow)Application.Current.MainWindow).tbbtnGuardar.IsEnabled = guardar;
            ((MainWindow)Application.Current.MainWindow).tbbtnCancelar.IsEnabled = cancelar;
            ((MainWindow)Application.Current.MainWindow).tbbtnImprimir.IsEnabled = imprimir;
            ((MainWindow)Application.Current.MainWindow).tbbtnAnterior.IsEnabled = anterior;
            ((MainWindow)Application.Current.MainWindow).tbbtnSiguiente.IsEnabled = siguiente;
            ((MainWindow)Application.Current.MainWindow).tbbtnSalir.IsEnabled = salir;

            ((MainWindow)Application.Current.MainWindow).tbbtnBuscar.IsEnabled = buscar;
            ((MainWindow)Application.Current.MainWindow).txtBuscar.IsEnabled = buscar;
            */
        }
    }
}
