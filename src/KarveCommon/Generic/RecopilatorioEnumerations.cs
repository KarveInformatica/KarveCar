namespace KarveCommon.Generic
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

            rbtnBancosClientes,
            rbtnBloqueFacturacion,
            rbtnCambioCodigoCliente,
            rbtnCanales,
            rbtnCargosPersonal,
            rbtnCCAA,
            rbtnClavesPresupuesto,
            rbtnClientes,
            rbtnEntradaRapida,
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
            rbtnZonasCliente,

            rbtnComisionistas,
            rbtnEmpleadosAgencia,
            rbtnTipoComisionista,

            rbtnTiposIncidenciasClientes,
            rbtnTiposIncidenciasContratos,
            rbtnTiposIncidenciasProveedores,
            rbtnTiposIncidenciasReservas,

            rbtnDivisas,
            rbtnFormaPagoProveedor,
            rbtnTiposProveedores,
            rbtnProveedores,

            rbtnClavesFee,
            rbtnMediosRecepcion,
            rbtnMotivosAnulacionReservas,
            rbtnMotivosNoServicio,

            rbtnCambioCodigoTarifas,
            rbtnConceptosFacturacion,
            rbtnCrearTarifaDesdeOtraTarifa,
            rbtnGruposTarifa,           
            rbtnIncrementoPrecios,
            rbtnTarifas,
            rbtnTarifaCliente,
            rbtnTarifasComisionista,
            rbtnVerTarifa,
            rbtnVincularClienteTarifa,

            rbtnAccesoriosVehiculos,
            rbtnActividadesVehiculos,
            rbtnCambioCodigoVehiculo,
            rbtnCodigosInmovilizacion,
            rbtnCodigosMantenimiento,
            rbtnColores,
            rbtnExtras,
            rbtnFormasTraslado,
            rbtnGruposVehiculos,
            rbtnGrupoVehiculoPrecioPorDefecto,
            rbtnMarcas,
            rbtnModelos,
            rbtnModificacionMasivaAux,
            rbtnMotivosRepostaje,
            rbtnPropietarios,
            rbtnRecalculoMantenimiento,
            rbtnTiposVehiculos,
            rbtnVehiculos,

            rbtnAccesorios,
            rbtnCategoriasPersonal,
            rbtnConceptosSalidaCaja,
            rbtnLugaresEntrega,
            rbtnMotivosAnulacionContratos,
            rbtnMotivosCambioVehiculo,
            rbtnMotivosCancelacion,
            rbtnMotivosImproductivo,
            rbtnTextosEstandars,
            rbtnTipoContactoPotencial,
            rbtnTiposDocumentos,
            rbtnTipoImpresoContrato,
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

            #region Servicios
            rbtnDescargarMultas,
            rbtnMantenimientoServicios,
            rbtnMultas,
            rbtnNeumaticos,
            rbtnTarjetaCombustible,
            rbtnVehiculoSustitucion,
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

            Default
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
            rbtbServicios,
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
        public enum EControlCambio
        {
            Null,
            Delete,
            Insert,
            Update,
            HasNull
        }
       
    }
}
