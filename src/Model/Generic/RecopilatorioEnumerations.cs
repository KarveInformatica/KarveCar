namespace KarveCar.Model.Generic
{
    public class RecopilatorioEnumerations
    {
        /// <summary>
        /// Enumeración de los tipos de datos maestros
        /// </summary>
        public enum EOpcion
        {
            #region Maestros
            rbtnEmpresas,
            rbtnOficinas,
            rbtnZonasOficina,

            rbtnClientes,
            rbtnCambioCodigoCliente,
            rbtnEntradaRapida,

            rbtnComisionistas,

            rbtnProveedores,

            rbtnTarifas,
            rbtnCambioCodigoTarifas,
            rbtnCrearTarifaDesdeOtraTarifa,
            rbtnIncrementoPrecios,
            rbtnTarifaCliente,
            rbtnTarifasComisionista,
            rbtnVerTarifa,
            rbtnVincularClienteTarifa,

            rbtnVehiculos,
            rbtnCambioCodigoVehiculo,
            rbtnModificacionMasivaAux,
            rbtnRecalculoMantenimiento,

            rbtnBancosClientes,
            rbtnBloqueFacturacion,
            rbtnCanales,
            rbtnCargosPersonal,
            rbtnClavesPresupuesto,
            rbtnFormasCobroClientes,
            rbtnMercados,
            rbtnNegocios,
            rbtnOrigenClientes,
            rbtnPaises,
            rbtnPoblaciones,
            rbtnProvincias,
            rbtnSectoresActividad,
            rbtnTarjetasCredito,
            rbtnTarjetasEmpresa,
            rbtnTiposCliente,
            rbtnTiposContacto,
            rbtnTiposVisita,
            rbtnUsoAlquiler,
            rbtnVendedores,
            rbtnZonas,

            rbtnEmpleadosAgencia,
            rbtnTipoComisionista,

            rbtnAccesorios,
            rbtnLugaresEntrega,
            rbtnMotivosAnulacionContratos,
            rbtnMotivosCambioVehiculo,
            rbtnMotivosCancelacion,
            rbtnMotivosImproductivo,
            rbtnTipoImpresoContrato,

            rbtnTiposIncidenciasClientes,
            rbtnTiposIncidenciasContratos,
            rbtnTiposIncidenciasProveedores,
            rbtnTiposIncidenciasReservas,

            rbtnDivisas,
            rbtnFormaPagoProveedor,
            rbtnTiposProveedores,

            rbtnClavesFee,
            rbtnMediosRecepcion,
            rbtnMotivosAnulacionReservas,
            rbtnMotivosNoServicio,

            rbtnConceptosFacturacion,
            rbtnGruposTarifa,

            rbtnAccesoriosVehiculos,
            rbtnActividadesVehiculos,
            rbtnCodigosInmovilizacion,
            rbtnCodigosMantenimiento,
            rbtnColores,
            rbtnExtras,
            rbtnFormasTraslado,
            rbtnGruposVehiculos,
            rbtnMarcas,
            rbtnModelos,
            rbtnMotivosRepostaje,
            rbtnPropietarios,
            rbtnTiposVehiculos,

            rbtnCategoriasPersonal,
            rbtnConceptosSalidaCaja,
            rbtnTextosEstandars,
            rbtnbitTipoContacto,
            rbtnTiposDocumentos,
            rbtnTipoImpresoFactura,
            #endregion

            #region Contratos
            rbtnAbrirContrato,
            rbtnAnularContrato,
            rbtnCerrarContrato,
            rbtnConcultarContrato,
            rbtnReAbrirContrato,

            rbtnCambioConductor,
            rbtnCambioNumeroContrato,
            rbtnCambioOficinaContrato,
            rbtnCambioVehiculo,

            rbtnEntregaContratosOficina,
            rbtnImpresionBloqueContratos,
            rbtnPlantilla,
            rbtnProcesoCierreContratos,
            rbtnProlongacionAutomaticaContratos,
            #endregion

            #region Reservas
            rbtnReservas,
            rbtnAnularReserva,
            rbtnConvertirReservaContrato,
            rbtnCotizacionComparada,
            rbtnEliminarReservasNoShow,
            rbtnPeticiones,
            #endregion

            #region Atipicos
            rbtnAlquilerBicicletas,
            rbtnFacturasAtipicas,
            rbtnImpresionBloque,
            rbtnSalidaCaja,
            rbtnSeriesAtipicos,
            #endregion

            #region Comercial
            rbtnCustomerService,
            rbtnEntregaBonos,
            rbtnEMailingClientes,
            rbtneEMailingPotenciales,
            rbtnPotenciales,
            #endregion

            #region Facturación
            rbtnAbonarFactura,
            rbtnBorrarFacturasPeriodo,
            rbtnCambioNumeroFactura,
            rbtnCambioVendedorFacturas,
            rbtnCartaPendientes,
            rbtnConsultaModificacion,
            rbtnModificarEmpresaOficinaFactura,
            rbtnModificarFacturaContrato,
            rbtnProcesoFacturacion,

            rbtnRecibos,
            rbtnCobrosIndividuales,
            rbtnGestionImpagados,
            rbtnRefundirRecibosNoCobrados,

            rbtnRemesas,
            rbtnAnulacionPaseRemesaContabilidad,
            rbtnBancosRemesas,
            rbtnPaseSoporteMagnetico,
            rbtnPaseRemesaContabilidad,

            rbtnAnulacionPase,
            rbtnPaseCobrosRecibos,
            rbtnPaseFacturas,
            rbtnPaseFacturasAtipicas,
            rbtnPaseTesoreriaCaja,

            rbtnExportacionFichero340,
            rbtnExportacionFichero347,

            rbtnImpresionBloqueFacturas,
            rbtnImpresionBloqueRecibos,

            rgrEstadisticasFacturas,
            #endregion

            #region Flota
            rbtnInmovilizaciones,
            rbtnEntradaGastosVehiculo,
            rbtnGeneradorEstadisticasInmovilizaciones,

            rbtnActualizarVtoITV,
            rbtnBastidorRadioLlave,
            rbtnCambioFechaBajaVehiculo,
            rbtnCambioUbicacionKMSituacion,
            rbtnDatosSeguros,
            rbtnFlotaVtoRecibosSeguros,
            rbtnModificacionMasivaFlota,
            rbtnTraslados,

            rbtnCambioEmpresa,
            rbtnCambioUbicacion,
            rbtnDescargarMultas,
            rbtnHistoricoSeguros,
            rbtnImpresionLlaveros,
            rbtnPrevisionEntradas,
            rbtnRecalculoSituación,
            rbtnRepostaje,
            rbtnSiniestros,
            #endregion

            #region Incidencias
            rbtnIncidenciasClientes,
            rbtnIncidenciasContratos,
            rbtnIncidenciasProveedores,
            rbtnIncidenciasReservas,
            rbtnIncidenciasVehiculos,
            #endregion

            #region Estadísticas
            rbtnEstadisticasAnaliticas,
            rbtnEstadisticasClientes,
            rbtnEstadisticasContratos,
            rbtnEstadisticasFacturas,
            rbtnEstadisticasPeticiones,
            rbtnEstadisticasProveedores,
            rbtnEstadisticasReservas,
            rbtnEstadisticasUtilitarios,
            rbtnEstadisticasVehiculos,
            #endregion

            #region Listados
            rbtnListadosClientes,
            rbtnListadosComisionistas,
            rbtnListadosContratos,
            rbtnListadosFicherosAuxiliares,
            rbtnListadosFacturas,
            rbtnListadosPeticiones,
            rbtnListadosPotenciales,
            rbtnListadosProveedores,
            rbtnListadosReservas,
            rbtnListadosVehiculos,
            #endregion

            #region Configuración
            rbtnCinta,
            rbtnCodigosIniciales,
            rbtnEmpresa,
            rbtnEnlaceContabilidad,
            rbtnEquipo,
            rbtnFacturacion,
            rbtnbiImpresion,
            rbtnKarve,
            rbtnMaestros,
            rbtnOficina,
            rbtnOperaciones,
            rbtnOtros,

            rbtnInformes,
            rbtnPrograma,

            rbtnIdiomaESES,
            rbtnIdiomaCAES,
            rbtnIdiomaENGB,

            rbtnMailingPersonal,
            rbtnPersonal,

            rbtnBorrarFicherosEnvioEmail,
            rbtnCambiarIVA,
            rbtnComunicacionPolicia,
            rbtnConsultaSQL,
            rbtnDesbloquearContratosFacturando,
            rbtnDeteccionHuecos,
            rbtnDeteccionInconsistencias,
            rbtnDesvincularContratosReservas,
            rbtnLimpiarInformacionAntigua,
            rbtnLimpiarCodigosReserva,
            rbtnRecalcularMantenimientos,
            rbtnRecalcularPendientes,
            rbtnRehacerIndices,
            rbtnRelojesActivos,
            rbtnVincularContratosReservas,
            rbtnVincularContratosReservasNoVinculadas,

            rbtnCambiarContrasenyas,
            rbtnPreciosCombustible,
            rbtnUsuarios,

            rbtnAcercaDe,
            rbtnContrasenyasKarve,
            rbtnDescargarActualizacion,
            rbtnMensajeEntrada,
            rbtnNovedades,
            #endregion

            Default,
        }


        /// <summary>
        /// Enumeración de los RibbonTab
        /// </summary>
        public enum ERibbonTab
        {
            rbtbMaestros,
            rbtbContratos,
            rbtbReservas,
            rbtbAtipicos,
            rbtbComercial,
            rbtbFacturacion,
            rbtbFlota,
            rbtbIncidencias,
            rbtbEstadisticas,
            rbtbListados,
            rbtbConfiguracion
        }

        /// <summary>
        /// Enumeración con los tipos de datos de las columnas de la BBDD
        /// </summary>
        public enum ETiposDatoColumnaDB
        {
            DBstring,
            DBchar,
            DBbool,
            DBbyte, //byte en C# = tinyint en la DB
            DBshort,
            DBint,
            DBlong,
            DBdecimal,
            DBdouble,
            DBdate,
            DBdatetime,
            DBsmalldatetime,
            DBtime,
            DBdefault
        }

        /// <summary>
        /// Enumeración con los tipos de de Control de Cambio de los DataGrid
        /// </summary>
        public enum EControlCambioDataGrid
        {
            Null,
            Delete,
            Insert,
            Update,
            HasNull
        }
    }
}
