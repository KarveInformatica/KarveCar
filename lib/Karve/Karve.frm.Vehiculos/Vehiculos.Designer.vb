<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Vehiculos
    Inherits Bases.frmBase

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim Connection1 As ASADB.Connection = New ASADB.Connection()
        Dim Connection2 As ASADB.Connection = New ASADB.Connection()
        Dim Connection3 As ASADB.Connection = New ASADB.Connection()
        Dim Connection4 As ASADB.Connection = New ASADB.Connection()
        Dim Connection15 As ASADB.Connection = New ASADB.Connection()
        Dim Connection16 As ASADB.Connection = New ASADB.Connection()
        Dim Connection17 As ASADB.Connection = New ASADB.Connection()
        Dim Connection18 As ASADB.Connection = New ASADB.Connection()
        Dim Connection19 As ASADB.Connection = New ASADB.Connection()
        Dim Connection20 As ASADB.Connection = New ASADB.Connection()
        Dim Connection21 As ASADB.Connection = New ASADB.Connection()
        Dim Connection10 As ASADB.Connection = New ASADB.Connection()
        Dim Connection11 As ASADB.Connection = New ASADB.Connection()
        Dim Connection12 As ASADB.Connection = New ASADB.Connection()
        Dim Connection13 As ASADB.Connection = New ASADB.Connection()
        Dim Connection14 As ASADB.Connection = New ASADB.Connection()
        Dim Connection5 As ASADB.Connection = New ASADB.Connection()
        Dim Connection6 As ASADB.Connection = New ASADB.Connection()
        Dim Connection7 As ASADB.Connection = New ASADB.Connection()
        Dim Connection8 As ASADB.Connection = New ASADB.Connection()
        Dim Connection9 As ASADB.Connection = New ASADB.Connection()
        Me.pvpGeneral = New CustomControls.PageViewPage()
        Me.pnPpal = New CustomControls.Panel()
        Me.pnlPpal_Fill = New CustomControls.Panel()
        Me.dtfActividad = New CustomControls.DualDatafieldLabel()
        Me.DataAreaLabel1 = New CustomControls.DataAreaLabel()
        Me.dtaExtras = New CustomControls.DataAreaLabel()
        Me.dtfGrupo = New CustomControls.DualDatafieldLabel()
        Me.pnlSpace = New CustomControls.Panel()
        Me.pnPpal_Izq = New CustomControls.Panel()
        Me.pnlFechas = New CustomControls.Panel()
        Me.dtfDevPrev = New CustomControls.DataDateLabel()
        Me.dtdFMatric = New CustomControls.DataDateLabel()
        Me.dtdFFabrica = New CustomControls.DataDateLabel()
        Me.dtdFBaja = New CustomControls.DataDateLabel()
        Me.dtdFCompra = New CustomControls.DataDateLabel()
        Me.dtaObserva = New CustomControls.DataAreaLabel()
        Me.dtaDanos = New CustomControls.DataAreaLabel()
        Me.dtfBastidor = New CustomControls.DatafieldLabel()
        Me.penGenGen = New CustomControls.Panel()
        Me.pnlGen = New CustomControls.Panel()
        Me.pnlAsocia = New CustomControls.Panel()
        Me.dtfModelo = New Karve.frm.Vehiculos.LupaModelo()
        Me.Panel2 = New CustomControls.Panel()
        Me.pnlMarca = New CustomControls.Panel()
        Me.dtfMarca = New CustomControls.DualDataFieldEditableLabel()
        Me.pnlCodigo = New CustomControls.Panel()
        Me.dtfColor = New CustomControls.DualDatafieldLabel()
        Me.Panel1 = New CustomControls.Panel()
        Me.dtfMatricula = New CustomControls.DatafieldLabel()
        Me.pnlSpace1 = New CustomControls.Panel()
        Me.dtfCodigo = New CustomControls.DatafieldLabel()
        Me.pvpCompraVenta = New CustomControls.PageViewPage()
        Me.pnlComVenDer = New CustomControls.Panel()
        Me.gbxImpuesto = New CustomControls.GroupBox()
        Me.dtfZonaImpuesto = New CustomControls.DualDatafieldLabel()
        Me.dtfPoblacionImp = New CustomControls.DualDatafieldLabel()
        Me.Panel14 = New CustomControls.Panel()
        Me.dtfImporteImp = New CustomControls.DatafieldLabel()
        Me.Panel16 = New CustomControls.Panel()
        Me.dtlFechaAltaImp = New CustomControls.DataDateLabel()
        Me.gbxVentaVeh = New CustomControls.GroupBox()
        Me.Panel4 = New CustomControls.Panel()
        Me.dtlTransfer = New CustomControls.DataDateLabel()
        Me.Panel3 = New CustomControls.Panel()
        Me.dtlBajaSeguro = New CustomControls.DataDateLabel()
        Me.Panel5 = New CustomControls.Panel()
        Me.dtlBajaTrafico = New CustomControls.DataDateLabel()
        Me.Panel9 = New CustomControls.Panel()
        Me.dtfPrecioVenta = New CustomControls.DatafieldLabel()
        Me.Panel10 = New CustomControls.Panel()
        Me.dtfVendedor = New CustomControls.DualDatafieldLabel()
        Me.Panel12 = New CustomControls.Panel()
        Me.dtfPrecioVentaVeh = New CustomControls.DatafieldLabel()
        Me.Panel13 = New CustomControls.Panel()
        Me.dtfFechaVenta = New CustomControls.DataDateLabel()
        Me.pnlSpace15 = New CustomControls.Panel()
        Me.dtfFactura = New CustomControls.DatafieldLabel()
        Me.dtfComprador = New CustomControls.DualDatafieldLabel()
        Me.pnlComVenIzq = New CustomControls.Panel()
        Me.gbxLeasing = New CustomControls.GroupBox()
        Me.dtaNotasLeasing = New CustomControls.DataAreaLabel()
        Me.pnlCuotaLeasing = New CustomControls.Panel()
        Me.pnlSpace5 = New CustomControls.Panel()
        Me.Label1 = New CustomControls.Label()
        Me.dtfInteresMorat = New CustomControls.DatafieldLabel()
        Me.pnlSpace6 = New CustomControls.Panel()
        Me.dtfKMExc = New CustomControls.DatafieldLabel()
        Me.pnlOtorgamiento = New CustomControls.Panel()
        Me.dtfImpFinan = New CustomControls.DatafieldLabel()
        Me.pnlSpace7 = New CustomControls.Panel()
        Me.dtfDiaPago = New CustomControls.DatafieldLabel()
        Me.pnlSpace8 = New CustomControls.Panel()
        Me.dtfComisionOto = New CustomControls.DatafieldLabel()
        Me.pnlContratoLeasing = New CustomControls.Panel()
        Me.dtfCuota = New CustomControls.DatafieldLabel()
        Me.pnlSpace11 = New CustomControls.Panel()
        Me.lblPorcen1 = New CustomControls.Label()
        Me.dtfInteres = New CustomControls.DatafieldLabel()
        Me.pnlSpace10 = New CustomControls.Panel()
        Me.dtfContrato = New CustomControls.DatafieldLabel()
        Me.pnlFechasLeasing = New CustomControls.Panel()
        Me.dtlFinal = New CustomControls.DataDateLabel()
        Me.pnlSpace9 = New CustomControls.Panel()
        Me.dtlInicio = New CustomControls.DataDateLabel()
        Me.dtfCompañia = New CustomControls.DualDatafieldLabel()
        Me.gbxCompra = New CustomControls.GroupBox()
        Me.pnlPrecioFranco = New CustomControls.Panel()
        Me.dtfPrecioFrancoOp = New CustomControls.DatafieldLabel()
        Me.pnlSpace14 = New CustomControls.Panel()
        Me.dtfPrecioFranco = New CustomControls.DatafieldLabel()
        Me.Panel7 = New CustomControls.Panel()
        Me.dtfTTransporte = New CustomControls.DatafieldLabel()
        Me.pnlSpace3 = New CustomControls.Panel()
        Me.dtfBonificacion = New CustomControls.DatafieldLabel()
        Me.pnlFechasCompra = New CustomControls.Panel()
        Me.dtlMatriculacion = New CustomControls.DataDateLabel()
        Me.pnlSpace4 = New CustomControls.Panel()
        Me.dtfNombre = New CustomControls.DatafieldLabel()
        Me.pnlFormaPago = New CustomControls.Panel()
        Me.dtlFechaCompra = New CustomControls.DataDateLabel()
        Me.pnlSpace12 = New CustomControls.Panel()
        Me.dtfPrecio = New CustomControls.DatafieldLabel()
        Me.pnlPreciosCompra = New CustomControls.Panel()
        Me.dtfFormaPagoCompra = New CustomControls.DualDatafieldLabel()
        Me.pnlSpace13 = New CustomControls.Panel()
        Me.dtfFacturaN = New CustomControls.DatafieldLabel()
        Me.dtfProveedor = New CustomControls.DualDatafieldLabel()
        Me.pnlCabeceraCV = New CustomControls.Panel()
        Me.pvpFichaTecnica = New CustomControls.PageViewPage()
        Me.ftvVehi = New Karve.frm.Auxiliares.FichaTecnicaVehiculo()
        Me.pnlGenFichaTec = New CustomControls.Panel()
        Me.pvpseguros = New CustomControls.PageViewPage()
        Me.Panel37 = New CustomControls.Panel()
        Me.Panel64 = New CustomControls.Panel()
        Me.btnParteAmis = New CustomControls.Button()
        Me.Panel65 = New CustomControls.Panel()
        Me.btnHistorico = New CustomControls.Button()
        Me.gbxSegAd3 = New CustomControls.GroupBox()
        Me.pnlSupSA3inf = New CustomControls.Panel()
        Me.Panel58 = New CustomControls.Panel()
        Me.dtlVencimientoSA2 = New CustomControls.DataDateLabel()
        Me.pnlSpace30 = New CustomControls.Panel()
        Me.dtlFechaAltaSA2 = New CustomControls.DataDateLabel()
        Me.pnlSupSA3mid = New CustomControls.Panel()
        Me.dtfTelefAssistSA2 = New CustomControls.DatafieldLabel()
        Me.pnlSpace29 = New CustomControls.Panel()
        Me.dtfImporteSA2 = New CustomControls.DatafieldLabel()
        Me.pnlSupSA3top = New CustomControls.Panel()
        Me.dtfCompañiaSA2 = New CustomControls.DualDatafieldLabel()
        Me.pnlSpace28 = New CustomControls.Panel()
        Me.dtfPolizaSA2 = New CustomControls.DatafieldLabel()
        Me.gbxSegAd2 = New CustomControls.GroupBox()
        Me.pnlSupSA2inf = New CustomControls.Panel()
        Me.Panel51 = New CustomControls.Panel()
        Me.dtlVencimientoSA = New CustomControls.DataDateLabel()
        Me.pnlSpace27 = New CustomControls.Panel()
        Me.dtlFechaAltaSA = New CustomControls.DataDateLabel()
        Me.pnlSupSA2mid = New CustomControls.Panel()
        Me.dtfTelefAssistSA = New CustomControls.DatafieldLabel()
        Me.pnlSpace26 = New CustomControls.Panel()
        Me.dtfImporteSA = New CustomControls.DatafieldLabel()
        Me.pnlSupSA2top = New CustomControls.Panel()
        Me.dtfCompañiaSA = New CustomControls.DualDatafieldLabel()
        Me.pnlSpace25 = New CustomControls.Panel()
        Me.dtfPolizaSA = New CustomControls.DatafieldLabel()
        Me.gbxSegAd1 = New CustomControls.GroupBox()
        Me.pnlSupSA1inf = New CustomControls.Panel()
        Me.Panel48 = New CustomControls.Panel()
        Me.dtlVencimientoSA3 = New CustomControls.DataDateLabel()
        Me.pnlSpace24 = New CustomControls.Panel()
        Me.dtlFechaAltaSA3 = New CustomControls.DataDateLabel()
        Me.pnlSupSA1mid = New CustomControls.Panel()
        Me.dtfTelefAssistSA3 = New CustomControls.DatafieldLabel()
        Me.pnlSpace23 = New CustomControls.Panel()
        Me.dtfImporteSA3 = New CustomControls.DatafieldLabel()
        Me.pnlSupSA1top = New CustomControls.Panel()
        Me.dtfCompañiaSA3 = New CustomControls.DualDatafieldLabel()
        Me.pnlSpace22 = New CustomControls.Panel()
        Me.dtfPolizaSA3 = New CustomControls.DatafieldLabel()
        Me.gbxOtrosDSeg = New CustomControls.GroupBox()
        Me.pnlOtrosDSegInf = New CustomControls.Panel()
        Me.chkEnVehic = New CustomControls.DataCheck()
        Me.pnlSpace21 = New CustomControls.Panel()
        Me.chkTenemosRec = New CustomControls.DataCheck()
        Me.pnlSpace20 = New CustomControls.Panel()
        Me.chkTodoRiesgo = New CustomControls.DataCheck()
        Me.pnlOtrosDSegSup = New CustomControls.Panel()
        Me.dtfCartaVerde = New CustomControls.DatafieldLabel()
        Me.pnlSpace19 = New CustomControls.Panel()
        Me.chkSegInternacional = New CustomControls.DataCheck()
        Me.pnlIzqSeguro = New CustomControls.Panel()
        Me.gbxPagos = New CustomControls.GroupBox()
        Me.Panel36 = New CustomControls.Panel()
        Me.pnlPagoSeg4 = New CustomControls.Panel()
        Me.chkPagado4 = New CustomControls.DataCheck()
        Me.pnlSpace40 = New CustomControls.Panel()
        Me.dtfImp4 = New CustomControls.DatafieldLabel()
        Me.pnlSpace34 = New CustomControls.Panel()
        Me.dtlVen4 = New CustomControls.DataDateLabel()
        Me.pnlPagoSeg3 = New CustomControls.Panel()
        Me.chkPagado3 = New CustomControls.DataCheck()
        Me.pnlSpace39 = New CustomControls.Panel()
        Me.dtfImp3 = New CustomControls.DatafieldLabel()
        Me.pnlSpace33 = New CustomControls.Panel()
        Me.dtlVen3 = New CustomControls.DataDateLabel()
        Me.pnlPagoSeg2 = New CustomControls.Panel()
        Me.chkPagado2 = New CustomControls.DataCheck()
        Me.pnlSpace38 = New CustomControls.Panel()
        Me.dtfImp2 = New CustomControls.DatafieldLabel()
        Me.pnlSpace32 = New CustomControls.Panel()
        Me.dtlVen2 = New CustomControls.DataDateLabel()
        Me.pnlPagoSeg1 = New CustomControls.Panel()
        Me.chkPagado1 = New CustomControls.DataCheck()
        Me.pnlSpace37 = New CustomControls.Panel()
        Me.dtfImp1 = New CustomControls.DatafieldLabel()
        Me.pnlSpace31 = New CustomControls.Panel()
        Me.dtlVen1 = New CustomControls.DataDateLabel()
        Me.gbxDatosSeguro = New CustomControls.GroupBox()
        Me.pnlDatosSegInf = New CustomControls.Panel()
        Me.Panel68 = New CustomControls.Panel()
        Me.rdgFormaPagoSeg = New CustomControls.RadioGroup()
        Me.radFP4 = New CustomControls.DataRadio()
        Me.radFP3 = New CustomControls.DataRadio()
        Me.radFP2 = New CustomControls.DataRadio()
        Me.radFP1 = New CustomControls.DataRadio()
        Me.pnlSpace18 = New CustomControls.Panel()
        Me.pnlTipoSegObs = New CustomControls.Panel()
        Me.dtaObsSeguro = New CustomControls.DataAreaLabel()
        Me.dtaTipoSeguro = New CustomControls.DataAreaLabel()
        Me.pnlPrimaPendSeg = New CustomControls.Panel()
        Me.Panel23 = New CustomControls.Panel()
        Me.dtfPendienteSeguro = New CustomControls.DatafieldLabel()
        Me.Panel22 = New CustomControls.Panel()
        Me.dtfExtorno = New CustomControls.DatafieldLabel()
        Me.pnlSpace35 = New CustomControls.Panel()
        Me.dtfPrimaSeguro = New CustomControls.DatafieldLabel()
        Me.pnlFechasSeg = New CustomControls.Panel()
        Me.dtlBajaSeg = New CustomControls.DataDateLabel()
        Me.Panel19 = New CustomControls.Panel()
        Me.dtlVenciSeg = New CustomControls.DataDateLabel()
        Me.pnlSpace36 = New CustomControls.Panel()
        Me.dtlAltaSeg = New CustomControls.DataDateLabel()
        Me.pnlAgenteFranq = New CustomControls.Panel()
        Me.dtfAgenteSeg = New CustomControls.DualDatafieldLabel()
        Me.pnlSpace16 = New CustomControls.Panel()
        Me.dtfFranquiciaSeg = New CustomControls.DatafieldLabel()
        Me.Panel6 = New CustomControls.Panel()
        Me.dtfCompañiaSeg = New CustomControls.DualDatafieldLabel()
        Me.pnlSpace17 = New CustomControls.Panel()
        Me.dtfPolizaSeg = New CustomControls.DatafieldLabel()
        Me.pnlCabeceraSeguro = New CustomControls.Panel()
        Me.pvpOtros = New CustomControls.PageViewPage()
        Me.pnlOtrosDer = New CustomControls.Panel()
        Me.pnlGarantiaExt = New CustomControls.Panel()
        Me.dtfKmsOtros = New CustomControls.DatafieldLabel()
        Me.pnlSpace60 = New CustomControls.Panel()
        Me.dtdGarantiaFinOtros = New CustomControls.DataDateLabel()
        Me.pnlSpace59 = New CustomControls.Panel()
        Me.dtdGarantiaOtros = New CustomControls.DataDateLabel()
        Me.pnlPuestaEnServ = New CustomControls.Panel()
        Me.btnDocVeh = New CustomControls.Button()
        Me.pnlSpace58 = New CustomControls.Panel()
        Me.dtdServicioFinOtros = New CustomControls.DataDateLabel()
        Me.pnlSpace57 = New CustomControls.Panel()
        Me.dtdServicioOtros = New CustomControls.DataDateLabel()
        Me.pnlitvOtros = New CustomControls.Panel()
        Me.dtdProximaITV = New CustomControls.DataDateLabel()
        Me.pnlSpace56 = New CustomControls.Panel()
        Me.dtdUltimaITV = New CustomControls.DataDateLabel()
        Me.pnlManteOtros = New CustomControls.Panel()
        Me.dtdHastaMante = New CustomControls.DataDateLabel()
        Me.pnlSpace55 = New CustomControls.Panel()
        Me.dtdManteOtros = New CustomControls.DataDateLabel()
        Me.pnlContratoOtros = New CustomControls.Panel()
        Me.dtfConductorSit2 = New CustomControls.Datafield()
        Me.pnlSpace54 = New CustomControls.Panel()
        Me.dtdFRetornoOtros = New CustomControls.DataDateLabel()
        Me.pnlSpace53 = New CustomControls.Panel()
        Me.dtfContratoOtros = New CustomControls.DatafieldLabel()
        Me.pnlClienteSit = New CustomControls.Panel()
        Me.dtfConductorSit = New CustomControls.Datafield()
        Me.pnlSpace52 = New CustomControls.Panel()
        Me.dtfClienteSitu = New CustomControls.DualDatafieldLabel()
        Me.pnlSituacionOtros = New CustomControls.Panel()
        Me.DataCheck1 = New CustomControls.DataCheck()
        Me.pnlSpace51 = New CustomControls.Panel()
        Me.btnRecalcularSit = New CustomControls.Button()
        Me.pnlSpace50 = New CustomControls.Panel()
        Me.dtfSituacionOtros = New CustomControls.DualDatafieldLabel()
        Me.pnlUbicacionOtros = New CustomControls.Panel()
        Me.dtfUbicacionOtros = New CustomControls.DatafieldLabel()
        Me.pnlOficinasOtros = New CustomControls.Panel()
        Me.dtfOficinaAsig = New CustomControls.DualDatafieldLabel()
        Me.pnlSpace49 = New CustomControls.Panel()
        Me.dtfOficinaActual = New CustomControls.DualDatafieldLabel()
        Me.pnlOtrosIzq = New CustomControls.Panel()
        Me.pnlLocalizador = New CustomControls.Panel()
        Me.btnHistoricoOtros = New CustomControls.Button()
        Me.Panel18 = New CustomControls.Panel()
        Me.btnIncidencias = New CustomControls.Button()
        Me.Panel8 = New CustomControls.Panel()
        Me.dtcLocalizadorOtros = New CustomControls.DataCheck()
        Me.pnlCuentaOtros = New CustomControls.Panel()
        Me.dtfCuentaOtros = New CustomControls.DualDatafieldLabel()
        Me.pnlModeloDiasMax = New CustomControls.Panel()
        Me.DatafieldLabel1 = New CustomControls.DatafieldLabel()
        Me.Panel17 = New CustomControls.Panel()
        Me.dtfAnyoModelo = New CustomControls.DatafieldLabel()
        Me.pnlMotorTap = New CustomControls.Panel()
        Me.EmpresaOficina1 = New CustomControls.EmpresaOficina()
        Me.dtfTapiceria = New CustomControls.DatafieldLabel()
        Me.Panel15 = New CustomControls.Panel()
        Me.dtfNMotor = New CustomControls.DatafieldLabel()
        Me.pnlCodBateria = New CustomControls.Panel()
        Me.dtfversionOtros = New CustomControls.DatafieldLabel()
        Me.Panel11 = New CustomControls.Panel()
        Me.dtfCodBateria = New CustomControls.DatafieldLabel()
        Me.pnlPlazasPuertas = New CustomControls.Panel()
        Me.dtfNPuertas = New CustomControls.DatafieldLabel()
        Me.pnlSpace48 = New CustomControls.Panel()
        Me.dtfNPlazas = New CustomControls.DatafieldLabel()
        Me.pnlSpace47 = New CustomControls.Panel()
        Me.dtfTelAsociado = New CustomControls.DatafieldLabel()
        Me.pclCodLlave = New CustomControls.Panel()
        Me.dtfLlaveMag = New CustomControls.DatafieldLabel()
        Me.pnlSpace46 = New CustomControls.Panel()
        Me.dtfCodLlave = New CustomControls.DatafieldLabel()
        Me.pnlDepoLitros = New CustomControls.Panel()
        Me.lblOctavos = New CustomControls.Label()
        Me.dtfOctavos = New CustomControls.Datafield()
        Me.pnlSpace45 = New CustomControls.Panel()
        Me.dtfDepositoLitros = New CustomControls.DatafieldLabel()
        Me.pnlKmMaximoOtros = New CustomControls.Panel()
        Me.dtfKmMaximos = New CustomControls.DatafieldLabel()
        Me.pnlSpace44 = New CustomControls.Panel()
        Me.dtfCombustibleOtros = New CustomControls.DatafieldLabel()
        Me.pnlKmOtros = New CustomControls.Panel()
        Me.dtdFechaKmRes = New CustomControls.DataDate()
        Me.pnlSpace42 = New CustomControls.Panel()
        Me.dtfKmResOtros = New CustomControls.DatafieldLabel()
        Me.pnlSpace43 = New CustomControls.Panel()
        Me.dtdFechaKm = New CustomControls.DataDate()
        Me.pnlSpace41 = New CustomControls.Panel()
        Me.dtfKmOtros = New CustomControls.DatafieldLabel()
        Me.pnlCabeceraOtros = New CustomControls.Panel()
        Me.pvpMantenimiento = New CustomControls.PageViewPage()
        Me.PageViewPage2 = New CustomControls.PageViewPage()
        CType(Me.pnlBlock,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pvwBase,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pvwBase.SuspendLayout
        CType(Me.stbBase,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pvpGeneral.SuspendLayout
        CType(Me.pnPpal,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnPpal.SuspendLayout
        CType(Me.pnlPpal_Fill,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlPpal_Fill.SuspendLayout
        CType(Me.pnlSpace,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pnPpal_Izq,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnPpal_Izq.SuspendLayout
        CType(Me.pnlFechas,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlFechas.SuspendLayout
        CType(Me.penGenGen,System.ComponentModel.ISupportInitialize).BeginInit
        Me.penGenGen.SuspendLayout
        CType(Me.pnlGen,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlGen.SuspendLayout
        CType(Me.pnlAsocia,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlAsocia.SuspendLayout
        CType(Me.Panel2,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pnlMarca,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlMarca.SuspendLayout
        CType(Me.pnlCodigo,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlCodigo.SuspendLayout
        CType(Me.Panel1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pnlSpace1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pvpCompraVenta.SuspendLayout
        CType(Me.pnlComVenDer,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlComVenDer.SuspendLayout
        CType(Me.gbxImpuesto,System.ComponentModel.ISupportInitialize).BeginInit
        Me.gbxImpuesto.SuspendLayout
        CType(Me.Panel14,System.ComponentModel.ISupportInitialize).BeginInit
        Me.Panel14.SuspendLayout
        CType(Me.Panel16,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.gbxVentaVeh,System.ComponentModel.ISupportInitialize).BeginInit
        Me.gbxVentaVeh.SuspendLayout
        CType(Me.Panel4,System.ComponentModel.ISupportInitialize).BeginInit
        Me.Panel4.SuspendLayout
        CType(Me.Panel3,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.Panel5,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.Panel9,System.ComponentModel.ISupportInitialize).BeginInit
        Me.Panel9.SuspendLayout
        CType(Me.Panel10,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.Panel12,System.ComponentModel.ISupportInitialize).BeginInit
        Me.Panel12.SuspendLayout
        CType(Me.Panel13,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pnlSpace15,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pnlComVenIzq,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlComVenIzq.SuspendLayout
        CType(Me.gbxLeasing,System.ComponentModel.ISupportInitialize).BeginInit
        Me.gbxLeasing.SuspendLayout
        CType(Me.pnlCuotaLeasing,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlCuotaLeasing.SuspendLayout
        CType(Me.pnlSpace5,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.Label1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pnlSpace6,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pnlOtorgamiento,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlOtorgamiento.SuspendLayout
        CType(Me.pnlSpace7,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pnlSpace8,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pnlContratoLeasing,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlContratoLeasing.SuspendLayout
        CType(Me.pnlSpace11,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.lblPorcen1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pnlSpace10,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pnlFechasLeasing,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlFechasLeasing.SuspendLayout
        CType(Me.pnlSpace9,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.gbxCompra,System.ComponentModel.ISupportInitialize).BeginInit
        Me.gbxCompra.SuspendLayout
        CType(Me.pnlPrecioFranco,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlPrecioFranco.SuspendLayout
        CType(Me.pnlSpace14,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.Panel7,System.ComponentModel.ISupportInitialize).BeginInit
        Me.Panel7.SuspendLayout
        CType(Me.pnlSpace3,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pnlFechasCompra,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlFechasCompra.SuspendLayout
        CType(Me.pnlSpace4,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pnlFormaPago,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlFormaPago.SuspendLayout
        CType(Me.pnlSpace12,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pnlPreciosCompra,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlPreciosCompra.SuspendLayout
        CType(Me.pnlSpace13,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pnlCabeceraCV,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pvpFichaTecnica.SuspendLayout
        CType(Me.pnlGenFichaTec,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pvpseguros.SuspendLayout
        CType(Me.Panel37,System.ComponentModel.ISupportInitialize).BeginInit
        Me.Panel37.SuspendLayout
        CType(Me.Panel64,System.ComponentModel.ISupportInitialize).BeginInit
        Me.Panel64.SuspendLayout
        CType(Me.btnParteAmis,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.Panel65,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.btnHistorico,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.gbxSegAd3,System.ComponentModel.ISupportInitialize).BeginInit
        Me.gbxSegAd3.SuspendLayout
        CType(Me.pnlSupSA3inf,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlSupSA3inf.SuspendLayout
        CType(Me.Panel58,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pnlSpace30,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pnlSupSA3mid,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlSupSA3mid.SuspendLayout
        CType(Me.pnlSpace29,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pnlSupSA3top,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlSupSA3top.SuspendLayout
        CType(Me.pnlSpace28,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.gbxSegAd2,System.ComponentModel.ISupportInitialize).BeginInit
        Me.gbxSegAd2.SuspendLayout
        CType(Me.pnlSupSA2inf,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlSupSA2inf.SuspendLayout
        CType(Me.Panel51,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pnlSpace27,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pnlSupSA2mid,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlSupSA2mid.SuspendLayout
        CType(Me.pnlSpace26,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pnlSupSA2top,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlSupSA2top.SuspendLayout
        CType(Me.pnlSpace25,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.gbxSegAd1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.gbxSegAd1.SuspendLayout
        CType(Me.pnlSupSA1inf,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlSupSA1inf.SuspendLayout
        CType(Me.Panel48,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pnlSpace24,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pnlSupSA1mid,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlSupSA1mid.SuspendLayout
        CType(Me.pnlSpace23,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pnlSupSA1top,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlSupSA1top.SuspendLayout
        CType(Me.pnlSpace22,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.gbxOtrosDSeg,System.ComponentModel.ISupportInitialize).BeginInit
        Me.gbxOtrosDSeg.SuspendLayout
        CType(Me.pnlOtrosDSegInf,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlOtrosDSegInf.SuspendLayout
        CType(Me.chkEnVehic,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pnlSpace21,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.chkTenemosRec,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pnlSpace20,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.chkTodoRiesgo,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pnlOtrosDSegSup,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlOtrosDSegSup.SuspendLayout
        CType(Me.pnlSpace19,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.chkSegInternacional,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pnlIzqSeguro,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlIzqSeguro.SuspendLayout
        CType(Me.gbxPagos,System.ComponentModel.ISupportInitialize).BeginInit
        Me.gbxPagos.SuspendLayout
        CType(Me.Panel36,System.ComponentModel.ISupportInitialize).BeginInit
        Me.Panel36.SuspendLayout
        CType(Me.pnlPagoSeg4,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlPagoSeg4.SuspendLayout
        CType(Me.chkPagado4,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pnlSpace40,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pnlSpace34,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pnlPagoSeg3,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlPagoSeg3.SuspendLayout
        CType(Me.chkPagado3,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pnlSpace39,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pnlSpace33,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pnlPagoSeg2,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlPagoSeg2.SuspendLayout
        CType(Me.chkPagado2,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pnlSpace38,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pnlSpace32,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pnlPagoSeg1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlPagoSeg1.SuspendLayout
        CType(Me.chkPagado1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pnlSpace37,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pnlSpace31,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.gbxDatosSeguro,System.ComponentModel.ISupportInitialize).BeginInit
        Me.gbxDatosSeguro.SuspendLayout
        CType(Me.pnlDatosSegInf,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlDatosSegInf.SuspendLayout
        CType(Me.Panel68,System.ComponentModel.ISupportInitialize).BeginInit
        Me.Panel68.SuspendLayout
        CType(Me.rdgFormaPagoSeg,System.ComponentModel.ISupportInitialize).BeginInit
        Me.rdgFormaPagoSeg.SuspendLayout
        CType(Me.radFP4,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.radFP3,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.radFP2,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.radFP1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pnlSpace18,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pnlTipoSegObs,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlTipoSegObs.SuspendLayout
        CType(Me.pnlPrimaPendSeg,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlPrimaPendSeg.SuspendLayout
        CType(Me.Panel23,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.Panel22,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pnlSpace35,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pnlFechasSeg,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlFechasSeg.SuspendLayout
        CType(Me.Panel19,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pnlSpace36,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pnlAgenteFranq,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlAgenteFranq.SuspendLayout
        CType(Me.pnlSpace16,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.Panel6,System.ComponentModel.ISupportInitialize).BeginInit
        Me.Panel6.SuspendLayout
        CType(Me.pnlSpace17,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pnlCabeceraSeguro,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pvpOtros.SuspendLayout
        CType(Me.pnlOtrosDer,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlOtrosDer.SuspendLayout
        CType(Me.pnlGarantiaExt,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlGarantiaExt.SuspendLayout
        CType(Me.pnlSpace60,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pnlSpace59,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pnlPuestaEnServ,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlPuestaEnServ.SuspendLayout
        CType(Me.btnDocVeh,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pnlSpace58,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pnlSpace57,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pnlitvOtros,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlitvOtros.SuspendLayout
        CType(Me.pnlSpace56,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pnlManteOtros,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlManteOtros.SuspendLayout
        CType(Me.pnlSpace55,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pnlContratoOtros,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlContratoOtros.SuspendLayout
        CType(Me.pnlSpace54,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pnlSpace53,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pnlClienteSit,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlClienteSit.SuspendLayout
        CType(Me.pnlSpace52,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pnlSituacionOtros,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlSituacionOtros.SuspendLayout
        CType(Me.DataCheck1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pnlSpace51,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.btnRecalcularSit,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pnlSpace50,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pnlUbicacionOtros,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlUbicacionOtros.SuspendLayout
        CType(Me.pnlOficinasOtros,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlOficinasOtros.SuspendLayout
        CType(Me.pnlSpace49,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pnlOtrosIzq,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlOtrosIzq.SuspendLayout
        CType(Me.pnlLocalizador,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlLocalizador.SuspendLayout
        CType(Me.btnHistoricoOtros,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.Panel18,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.btnIncidencias,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.Panel8,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.dtcLocalizadorOtros,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pnlCuentaOtros,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlCuentaOtros.SuspendLayout
        CType(Me.pnlModeloDiasMax,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlModeloDiasMax.SuspendLayout
        CType(Me.Panel17,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pnlMotorTap,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlMotorTap.SuspendLayout
        CType(Me.Panel15,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pnlCodBateria,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlCodBateria.SuspendLayout
        CType(Me.Panel11,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pnlPlazasPuertas,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlPlazasPuertas.SuspendLayout
        CType(Me.pnlSpace48,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pnlSpace47,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pclCodLlave,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pclCodLlave.SuspendLayout
        CType(Me.pnlSpace46,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pnlDepoLitros,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlDepoLitros.SuspendLayout
        CType(Me.lblOctavos,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pnlSpace45,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pnlKmMaximoOtros,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlKmMaximoOtros.SuspendLayout
        CType(Me.pnlSpace44,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pnlKmOtros,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlKmOtros.SuspendLayout
        CType(Me.pnlSpace42,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pnlSpace43,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pnlSpace41,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pnlCabeceraOtros,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'pnlBlock
        '
        Me.pnlBlock.Location = New System.Drawing.Point(0, 479)
        '
        'pvwBase
        '
        Me.pvwBase.Controls.Add(Me.pvpGeneral)
        Me.pvwBase.Controls.Add(Me.pvpOtros)
        Me.pvwBase.Controls.Add(Me.pvpFichaTecnica)
        Me.pvwBase.Controls.Add(Me.pvpseguros)
        Me.pvwBase.Controls.Add(Me.pvpCompraVenta)
        Me.pvwBase.Controls.Add(Me.pvpMantenimiento)
        Me.pvwBase.Controls.Add(Me.PageViewPage2)
        Me.pvwBase.PanelCabezera = Me.pnlGen
        Me.pvwBase.SelectedPage = Me.pvpOtros
        Me.pvwBase.Size = New System.Drawing.Size(1272, 510)
        '
        'stbBase
        '
        Me.stbBase.Location = New System.Drawing.Point(0, 510)
        Me.stbBase.Size = New System.Drawing.Size(1272, 25)
        '
        'rbtEdicion
        '
        Me.rbtEdicion.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.rbtEdicion.BorderColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.rbtEdicion.BorderGradientStyle = Telerik.WinControls.GradientStyles.Solid
        Me.rbtEdicion.Bounds = New System.Drawing.Rectangle(0, 0, 64, 28)
        Me.rbtEdicion.ClipDrawing = True
        Me.rbtEdicion.ClipText = True
        Me.rbtEdicion.DrawBorder = True
        Me.rbtEdicion.DrawFill = True
        Me.rbtEdicion.ForeColor = System.Drawing.Color.Black
        Me.rbtEdicion.GradientStyle = Telerik.WinControls.GradientStyles.Solid
        Me.rbtEdicion.ImageAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.rbtEdicion.ImageLayout = System.Windows.Forms.ImageLayout.None
        Me.rbtEdicion.MinSize = New System.Drawing.Size(8, 8)
        Me.rbtEdicion.NumberOfColors = 1
        Me.rbtEdicion.Padding = New System.Windows.Forms.Padding(4)
        Me.rbtEdicion.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.rbtEdicion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.Color.Transparent
        Me.btnAdd.Bounds = New System.Drawing.Rectangle(0, 0, 51, 75)
        Me.btnAdd.CanFocus = True
        Me.btnAdd.ForeColor = System.Drawing.Color.Black
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.Transparent
        Me.btnSave.Bounds = New System.Drawing.Rectangle(0, 0, 52, 75)
        Me.btnSave.CanFocus = True
        Me.btnSave.ForeColor = System.Drawing.Color.Black
        '
        'btnRecargar
        '
        Me.btnRecargar.BackColor = System.Drawing.Color.Transparent
        Me.btnRecargar.Bounds = New System.Drawing.Rectangle(0, 0, 57, 75)
        Me.btnRecargar.CanFocus = True
        Me.btnRecargar.ForeColor = System.Drawing.Color.Black
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.Color.Transparent
        Me.btnDelete.Bounds = New System.Drawing.Rectangle(0, 0, 52, 75)
        Me.btnDelete.CanFocus = True
        Me.btnDelete.ForeColor = System.Drawing.Color.Black
        '
        'rbgEdicion
        '
        Me.rbgEdicion.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.rbgEdicion.Bounds = New System.Drawing.Rectangle(0, 0, 246, 96)
        Me.rbgEdicion.ForeColor = System.Drawing.Color.Black
        '
        'rbgDesplaza
        '
        Me.rbgDesplaza.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.rbgDesplaza.Bounds = New System.Drawing.Rectangle(0, 0, 243, 92)
        Me.rbgDesplaza.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.rbgDesplaza.ForeColor = System.Drawing.Color.Black
        Me.rbgDesplaza.Margin = New System.Windows.Forms.Padding(2)
        Me.rbgDesplaza.MaxSize = New System.Drawing.Size(0, 100)
        Me.rbgDesplaza.MinSize = New System.Drawing.Size(20, 86)
        '
        'btnPrimero
        '
        Me.btnPrimero.BackColor = System.Drawing.Color.Transparent
        Me.btnPrimero.Bounds = New System.Drawing.Rectangle(0, 0, 52, 70)
        Me.btnPrimero.CanFocus = True
        Me.btnPrimero.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.btnPrimero.ForeColor = System.Drawing.Color.Black
        '
        'btnAnterior
        '
        Me.btnAnterior.BackColor = System.Drawing.Color.Transparent
        Me.btnAnterior.Bounds = New System.Drawing.Rectangle(0, 0, 52, 70)
        Me.btnAnterior.CanFocus = True
        Me.btnAnterior.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.btnAnterior.ForeColor = System.Drawing.Color.Black
        '
        'btnSiguiente
        '
        Me.btnSiguiente.BackColor = System.Drawing.Color.Transparent
        Me.btnSiguiente.Bounds = New System.Drawing.Rectangle(0, 0, 53, 70)
        Me.btnSiguiente.CanFocus = True
        Me.btnSiguiente.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.btnSiguiente.ForeColor = System.Drawing.Color.Black
        '
        'btnUltimo
        '
        Me.btnUltimo.BackColor = System.Drawing.Color.Transparent
        Me.btnUltimo.Bounds = New System.Drawing.Rectangle(0, 0, 52, 70)
        Me.btnUltimo.CanFocus = True
        Me.btnUltimo.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.btnUltimo.ForeColor = System.Drawing.Color.Black
        '
        'rbgImpresion
        '
        Me.rbgImpresion.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.rbgImpresion.Bounds = New System.Drawing.Rectangle(0, 0, 120, 92)
        Me.rbgImpresion.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.rbgImpresion.ForeColor = System.Drawing.Color.Black
        Me.rbgImpresion.Margin = New System.Windows.Forms.Padding(2)
        Me.rbgImpresion.MaxSize = New System.Drawing.Size(0, 100)
        Me.rbgImpresion.MinSize = New System.Drawing.Size(20, 86)
        '
        'btnImprimir
        '
        Me.btnImprimir.BackColor = System.Drawing.Color.Transparent
        Me.btnImprimir.Bounds = New System.Drawing.Rectangle(0, 0, 52, 70)
        Me.btnImprimir.CanFocus = True
        Me.btnImprimir.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.btnImprimir.ForeColor = System.Drawing.Color.Black
        '
        'btnMail
        '
        Me.btnMail.BackColor = System.Drawing.Color.Transparent
        Me.btnMail.Bounds = New System.Drawing.Rectangle(0, 0, 52, 70)
        Me.btnMail.CanFocus = True
        Me.btnMail.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.btnMail.ForeColor = System.Drawing.Color.Black
        '
        'pvpGeneral
        '
        Me.pvpGeneral.Controls.Add(Me.pnPpal)
        Me.pvpGeneral.Controls.Add(Me.penGenGen)
        Me.pvpGeneral.ItemSize = New System.Drawing.SizeF(102.0!, 23.0!)
        Me.pvpGeneral.Location = New System.Drawing.Point(129, 5)
        Me.pvpGeneral.Name = "pvpGeneral"
        Me.pvpGeneral.PanelCabezeraContainer = Me.penGenGen
        Me.pvpGeneral.Size = New System.Drawing.Size(1138, 500)
        Me.pvpGeneral.Text = "General"
        '
        'pnPpal
        '
        Me.pnPpal.Auto_Size = False
        Me.pnPpal.BackColor = System.Drawing.Color.Honeydew
        Me.pnPpal.BorderColor = System.Drawing.SystemColors.Control
        Me.pnPpal.ChangeDock = False
        Me.pnPpal.Control_Resize = False
        Me.pnPpal.Controls.Add(Me.pnlPpal_Fill)
        Me.pnPpal.Controls.Add(Me.pnlSpace)
        Me.pnPpal.Controls.Add(Me.pnPpal_Izq)
        Me.pnPpal.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnPpal.isSpace = False
        Me.pnPpal.Location = New System.Drawing.Point(0, 62)
        Me.pnPpal.Name = "pnPpal"
        Me.pnPpal.numRows = 0
        Me.pnPpal.Reorder = True
        Me.pnPpal.Size = New System.Drawing.Size(1138, 453)
        Me.pnPpal.TabIndex = 4
        '
        'pnlPpal_Fill
        '
        Me.pnlPpal_Fill.Auto_Size = False
        Me.pnlPpal_Fill.BackColor = System.Drawing.Color.Pink
        Me.pnlPpal_Fill.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlPpal_Fill.ChangeDock = True
        Me.pnlPpal_Fill.Control_Resize = False
        Me.pnlPpal_Fill.Controls.Add(Me.dtfActividad)
        Me.pnlPpal_Fill.Controls.Add(Me.DataAreaLabel1)
        Me.pnlPpal_Fill.Controls.Add(Me.dtaExtras)
        Me.pnlPpal_Fill.Controls.Add(Me.dtfGrupo)
        Me.pnlPpal_Fill.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlPpal_Fill.isSpace = False
        Me.pnlPpal_Fill.Location = New System.Drawing.Point(398, 0)
        Me.pnlPpal_Fill.Name = "pnlPpal_Fill"
        Me.pnlPpal_Fill.numRows = 0
        Me.pnlPpal_Fill.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.pnlPpal_Fill.Reorder = True
        Me.pnlPpal_Fill.Size = New System.Drawing.Size(740, 453)
        Me.pnlPpal_Fill.TabIndex = 2
        '
        'dtfActividad
        '
        Me.dtfActividad.Allow_Empty = True
        Me.dtfActividad.Allow_Negative = True
        Me.dtfActividad.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfActividad.BackColor = System.Drawing.SystemColors.Control
        Me.dtfActividad.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfActividad.DataField = "ACTIVIDAD"
        Me.dtfActividad.DataTable = "V1"
        Me.dtfActividad.DB = Connection1
        Me.dtfActividad.Desc_Datafield = "NOMBRE"
        Me.dtfActividad.Desc_DBPK = "NUM_ACTIVEHI"
        Me.dtfActividad.Desc_DBTable = "ACTIVEHI"
        Me.dtfActividad.Desc_Where = Nothing
        Me.dtfActividad.Desc_WhereObligatoria = Nothing
        Me.dtfActividad.Descripcion = "Actividad"
        Me.dtfActividad.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfActividad.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfActividad.ExtraSQL = ""
        Me.dtfActividad.FocoEnAgregar = False
        Me.dtfActividad.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfActividad.Formulario = Nothing
        Me.dtfActividad.Label_Space = 80
        Me.dtfActividad.Length_Data = 32767
        Me.dtfActividad.Location = New System.Drawing.Point(0, 211)
        Me.dtfActividad.Lupa = Nothing
        Me.dtfActividad.Max_Value = 0.0R
        Me.dtfActividad.MensajeIncorrectoCustom = Nothing
        Me.dtfActividad.Name = "dtfActividad"
        Me.dtfActividad.Null_on_Empty = True
        Me.dtfActividad.OpenForm = Nothing
        Me.dtfActividad.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfActividad.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfActividad.Query_on_Text_Changed = True
        Me.dtfActividad.ReadOnly_Data = False
        Me.dtfActividad.ReQuery = False
        Me.dtfActividad.ShowButton = True
        Me.dtfActividad.Size = New System.Drawing.Size(740, 26)
        Me.dtfActividad.TabIndex = 3
        Me.dtfActividad.Text_Data = ""
        Me.dtfActividad.Text_Data_Desc = ""
        Me.dtfActividad.Text_Width = 80
        Me.dtfActividad.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfActividad.TopPadding = 0
        Me.dtfActividad.Upper_Case = False
        Me.dtfActividad.Validate_on_lost_focus = True
        '
        'DataAreaLabel1
        '
        Me.DataAreaLabel1.Allow_Empty = True
        Me.DataAreaLabel1.Allow_Negative = True
        Me.DataAreaLabel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.DataAreaLabel1.BackColor = System.Drawing.SystemColors.Control
        Me.DataAreaLabel1.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.DataAreaLabel1.DataField = "ACCESORIOS_VH"
        Me.DataAreaLabel1.DataTable = "V1"
        Me.DataAreaLabel1.Descripcion = "Accesorios"
        Me.DataAreaLabel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.DataAreaLabel1.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.DataAreaLabel1.FocoEnAgregar = False
        Me.DataAreaLabel1.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.DataAreaLabel1.Length_Data = 32767
        Me.DataAreaLabel1.Location = New System.Drawing.Point(0, 120)
        Me.DataAreaLabel1.Max_Value = 0.0R
        Me.DataAreaLabel1.MensajeIncorrectoCustom = Nothing
        Me.DataAreaLabel1.Name = "DataAreaLabel1"
        Me.DataAreaLabel1.Null_on_Empty = True
        Me.DataAreaLabel1.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.DataAreaLabel1.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.DataAreaLabel1.ReadOnly_Data = False
        Me.DataAreaLabel1.Size = New System.Drawing.Size(740, 91)
        Me.DataAreaLabel1.TabIndex = 2
        Me.DataAreaLabel1.Text_Data = ""
        Me.DataAreaLabel1.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.DataAreaLabel1.TopPadding = 0
        Me.DataAreaLabel1.Upper_Case = False
        Me.DataAreaLabel1.Validate_on_lost_focus = True
        '
        'dtaExtras
        '
        Me.dtaExtras.Allow_Empty = True
        Me.dtaExtras.Allow_Negative = True
        Me.dtaExtras.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtaExtras.BackColor = System.Drawing.SystemColors.Control
        Me.dtaExtras.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtaExtras.DataField = "LEXTRAS"
        Me.dtaExtras.DataTable = "V1"
        Me.dtaExtras.Descripcion = "Extras"
        Me.dtaExtras.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtaExtras.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtaExtras.FocoEnAgregar = False
        Me.dtaExtras.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtaExtras.Length_Data = 32767
        Me.dtaExtras.Location = New System.Drawing.Point(0, 29)
        Me.dtaExtras.Max_Value = 0.0R
        Me.dtaExtras.MensajeIncorrectoCustom = Nothing
        Me.dtaExtras.Name = "dtaExtras"
        Me.dtaExtras.Null_on_Empty = True
        Me.dtaExtras.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtaExtras.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtaExtras.ReadOnly_Data = False
        Me.dtaExtras.Size = New System.Drawing.Size(740, 91)
        Me.dtaExtras.TabIndex = 1
        Me.dtaExtras.Text_Data = ""
        Me.dtaExtras.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtaExtras.TopPadding = 0
        Me.dtaExtras.Upper_Case = False
        Me.dtaExtras.Validate_on_lost_focus = True
        '
        'dtfGrupo
        '
        Me.dtfGrupo.Allow_Empty = True
        Me.dtfGrupo.Allow_Negative = True
        Me.dtfGrupo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfGrupo.BackColor = System.Drawing.SystemColors.Control
        Me.dtfGrupo.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfGrupo.DataField = "GRUPO"
        Me.dtfGrupo.DataTable = "V1"
        Me.dtfGrupo.DB = Connection2
        Me.dtfGrupo.Desc_Datafield = "NOMBRE n0"
        Me.dtfGrupo.Desc_DBPK = "CODIGO"
        Me.dtfGrupo.Desc_DBTable = "GRUPOS"
        Me.dtfGrupo.Desc_Where = Nothing
        Me.dtfGrupo.Desc_WhereObligatoria = Nothing
        Me.dtfGrupo.Descripcion = "Grupo"
        Me.dtfGrupo.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfGrupo.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfGrupo.ExtraSQL = ""
        Me.dtfGrupo.FocoEnAgregar = False
        Me.dtfGrupo.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfGrupo.Formulario = Nothing
        Me.dtfGrupo.Label_Space = 80
        Me.dtfGrupo.Length_Data = 32767
        Me.dtfGrupo.Location = New System.Drawing.Point(0, 3)
        Me.dtfGrupo.Lupa = Nothing
        Me.dtfGrupo.Max_Value = 0.0R
        Me.dtfGrupo.MensajeIncorrectoCustom = Nothing
        Me.dtfGrupo.Name = "dtfGrupo"
        Me.dtfGrupo.Null_on_Empty = True
        Me.dtfGrupo.OpenForm = Nothing
        Me.dtfGrupo.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfGrupo.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfGrupo.Query_on_Text_Changed = True
        Me.dtfGrupo.ReadOnly_Data = False
        Me.dtfGrupo.ReQuery = False
        Me.dtfGrupo.ShowButton = True
        Me.dtfGrupo.Size = New System.Drawing.Size(740, 26)
        Me.dtfGrupo.TabIndex = 0
        Me.dtfGrupo.Text_Data = ""
        Me.dtfGrupo.Text_Data_Desc = ""
        Me.dtfGrupo.Text_Width = 80
        Me.dtfGrupo.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfGrupo.TopPadding = 0
        Me.dtfGrupo.Upper_Case = False
        Me.dtfGrupo.Validate_on_lost_focus = True
        '
        'pnlSpace
        '
        Me.pnlSpace.Auto_Size = False
        Me.pnlSpace.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace.ChangeDock = True
        Me.pnlSpace.Control_Resize = False
        Me.pnlSpace.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace.isSpace = True
        Me.pnlSpace.Location = New System.Drawing.Point(392, 0)
        Me.pnlSpace.Name = "pnlSpace"
        Me.pnlSpace.numRows = 0
        Me.pnlSpace.Reorder = True
        Me.pnlSpace.Size = New System.Drawing.Size(6, 453)
        Me.pnlSpace.TabIndex = 1
        '
        'pnPpal_Izq
        '
        Me.pnPpal_Izq.Auto_Size = False
        Me.pnPpal_Izq.BackColor = System.Drawing.Color.Pink
        Me.pnPpal_Izq.BorderColor = System.Drawing.SystemColors.Control
        Me.pnPpal_Izq.ChangeDock = True
        Me.pnPpal_Izq.Control_Resize = False
        Me.pnPpal_Izq.Controls.Add(Me.pnlFechas)
        Me.pnPpal_Izq.Controls.Add(Me.dtaObserva)
        Me.pnPpal_Izq.Controls.Add(Me.dtaDanos)
        Me.pnPpal_Izq.Controls.Add(Me.dtfBastidor)
        Me.pnPpal_Izq.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnPpal_Izq.isSpace = False
        Me.pnPpal_Izq.Location = New System.Drawing.Point(0, 0)
        Me.pnPpal_Izq.Name = "pnPpal_Izq"
        Me.pnPpal_Izq.numRows = 0
        Me.pnPpal_Izq.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.pnPpal_Izq.Reorder = True
        Me.pnPpal_Izq.Size = New System.Drawing.Size(392, 453)
        Me.pnPpal_Izq.TabIndex = 0
        '
        'pnlFechas
        '
        Me.pnlFechas.Auto_Size = False
        Me.pnlFechas.BackColor = System.Drawing.SystemColors.Control
        Me.pnlFechas.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlFechas.ChangeDock = True
        Me.pnlFechas.Control_Resize = False
        Me.pnlFechas.Controls.Add(Me.dtfDevPrev)
        Me.pnlFechas.Controls.Add(Me.dtdFMatric)
        Me.pnlFechas.Controls.Add(Me.dtdFFabrica)
        Me.pnlFechas.Controls.Add(Me.dtdFBaja)
        Me.pnlFechas.Controls.Add(Me.dtdFCompra)
        Me.pnlFechas.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlFechas.isSpace = False
        Me.pnlFechas.Location = New System.Drawing.Point(0, 211)
        Me.pnlFechas.Name = "pnlFechas"
        Me.pnlFechas.numRows = 0
        Me.pnlFechas.Reorder = True
        Me.pnlFechas.Size = New System.Drawing.Size(214, 242)
        Me.pnlFechas.TabIndex = 3
        '
        'dtfDevPrev
        '
        Me.dtfDevPrev.Allow_Empty = True
        Me.dtfDevPrev.DataField = "FDEVO"
        Me.dtfDevPrev.DataTable = "V2"
        Me.dtfDevPrev.Default_Value = New Date(2015, 8, 28, 0, 0, 0, 0)
        Me.dtfDevPrev.Descripcion = "Devolución Prevista"
        Me.dtfDevPrev.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfDevPrev.FocoEnAgregar = False
        Me.dtfDevPrev.Label_Space = 120
        Me.dtfDevPrev.Location = New System.Drawing.Point(0, 104)
        Me.dtfDevPrev.Max_Value = Nothing
        Me.dtfDevPrev.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtfDevPrev.MensajeIncorrectoCustom = Nothing
        Me.dtfDevPrev.Min_Value = Nothing
        Me.dtfDevPrev.MinDate = New Date(CType(0, Long))
        Me.dtfDevPrev.MinimumSize = New System.Drawing.Size(210, 26)
        Me.dtfDevPrev.Name = "dtfDevPrev"
        Me.dtfDevPrev.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfDevPrev.ReadOnly_Data = False
        Me.dtfDevPrev.Size = New System.Drawing.Size(214, 26)
        Me.dtfDevPrev.TabIndex = 4
        Me.dtfDevPrev.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfDevPrev.Validate_on_lost_focus = True
        Me.dtfDevPrev.Value_Data = New Date(2015, 8, 28, 0, 0, 0, 0)
        '
        'dtdFMatric
        '
        Me.dtdFMatric.Allow_Empty = True
        Me.dtdFMatric.DataField = "FMATRI"
        Me.dtdFMatric.DataTable = "V2"
        Me.dtdFMatric.Default_Value = New Date(2015, 8, 28, 0, 0, 0, 0)
        Me.dtdFMatric.Descripcion = "Fecha Matriculación"
        Me.dtdFMatric.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtdFMatric.FocoEnAgregar = False
        Me.dtdFMatric.Label_Space = 120
        Me.dtdFMatric.Location = New System.Drawing.Point(0, 78)
        Me.dtdFMatric.Max_Value = Nothing
        Me.dtdFMatric.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdFMatric.MensajeIncorrectoCustom = Nothing
        Me.dtdFMatric.Min_Value = Nothing
        Me.dtdFMatric.MinDate = New Date(CType(0, Long))
        Me.dtdFMatric.MinimumSize = New System.Drawing.Size(210, 26)
        Me.dtdFMatric.Name = "dtdFMatric"
        Me.dtdFMatric.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdFMatric.ReadOnly_Data = False
        Me.dtdFMatric.Size = New System.Drawing.Size(214, 26)
        Me.dtdFMatric.TabIndex = 3
        Me.dtdFMatric.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdFMatric.Validate_on_lost_focus = True
        Me.dtdFMatric.Value_Data = New Date(2015, 8, 28, 0, 0, 0, 0)
        '
        'dtdFFabrica
        '
        Me.dtdFFabrica.Allow_Empty = True
        Me.dtdFFabrica.DataField = "FFABRI"
        Me.dtdFFabrica.DataTable = "V1"
        Me.dtdFFabrica.Default_Value = New Date(2015, 8, 28, 0, 0, 0, 0)
        Me.dtdFFabrica.Descripcion = "Fecha Fabricación"
        Me.dtdFFabrica.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtdFFabrica.FocoEnAgregar = False
        Me.dtdFFabrica.Label_Space = 120
        Me.dtdFFabrica.Location = New System.Drawing.Point(0, 52)
        Me.dtdFFabrica.Max_Value = Nothing
        Me.dtdFFabrica.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdFFabrica.MensajeIncorrectoCustom = Nothing
        Me.dtdFFabrica.Min_Value = Nothing
        Me.dtdFFabrica.MinDate = New Date(CType(0, Long))
        Me.dtdFFabrica.MinimumSize = New System.Drawing.Size(210, 26)
        Me.dtdFFabrica.Name = "dtdFFabrica"
        Me.dtdFFabrica.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdFFabrica.ReadOnly_Data = False
        Me.dtdFFabrica.Size = New System.Drawing.Size(214, 26)
        Me.dtdFFabrica.TabIndex = 2
        Me.dtdFFabrica.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdFFabrica.Validate_on_lost_focus = True
        Me.dtdFFabrica.Value_Data = New Date(2015, 8, 28, 0, 0, 0, 0)
        '
        'dtdFBaja
        '
        Me.dtdFBaja.Allow_Empty = True
        Me.dtdFBaja.DataField = "FEBAJA"
        Me.dtdFBaja.DataTable = "V2"
        Me.dtdFBaja.Default_Value = New Date(2015, 8, 28, 0, 0, 0, 0)
        Me.dtdFBaja.Descripcion = "Último Día en Flota"
        Me.dtdFBaja.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtdFBaja.FocoEnAgregar = False
        Me.dtdFBaja.Label_Space = 120
        Me.dtdFBaja.Location = New System.Drawing.Point(0, 26)
        Me.dtdFBaja.Max_Value = Nothing
        Me.dtdFBaja.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdFBaja.MensajeIncorrectoCustom = Nothing
        Me.dtdFBaja.Min_Value = Nothing
        Me.dtdFBaja.MinDate = New Date(CType(0, Long))
        Me.dtdFBaja.MinimumSize = New System.Drawing.Size(210, 26)
        Me.dtdFBaja.Name = "dtdFBaja"
        Me.dtdFBaja.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdFBaja.ReadOnly_Data = False
        Me.dtdFBaja.Size = New System.Drawing.Size(214, 26)
        Me.dtdFBaja.TabIndex = 1
        Me.dtdFBaja.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdFBaja.Validate_on_lost_focus = True
        Me.dtdFBaja.Value_Data = New Date(2015, 8, 28, 0, 0, 0, 0)
        '
        'dtdFCompra
        '
        Me.dtdFCompra.Allow_Empty = True
        Me.dtdFCompra.DataField = "FECHACO"
        Me.dtdFCompra.DataTable = "V2"
        Me.dtdFCompra.Default_Value = New Date(2015, 8, 28, 0, 0, 0, 0)
        Me.dtdFCompra.Descripcion = "Primer Día en Flota"
        Me.dtdFCompra.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtdFCompra.FocoEnAgregar = False
        Me.dtdFCompra.Label_Space = 120
        Me.dtdFCompra.Location = New System.Drawing.Point(0, 0)
        Me.dtdFCompra.Max_Value = Nothing
        Me.dtdFCompra.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdFCompra.MensajeIncorrectoCustom = Nothing
        Me.dtdFCompra.Min_Value = Nothing
        Me.dtdFCompra.MinDate = New Date(CType(0, Long))
        Me.dtdFCompra.MinimumSize = New System.Drawing.Size(210, 26)
        Me.dtdFCompra.Name = "dtdFCompra"
        Me.dtdFCompra.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdFCompra.ReadOnly_Data = False
        Me.dtdFCompra.Size = New System.Drawing.Size(214, 26)
        Me.dtdFCompra.TabIndex = 0
        Me.dtdFCompra.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdFCompra.Validate_on_lost_focus = True
        Me.dtdFCompra.Value_Data = New Date(2015, 8, 28, 0, 0, 0, 0)
        '
        'dtaObserva
        '
        Me.dtaObserva.Allow_Empty = True
        Me.dtaObserva.Allow_Negative = True
        Me.dtaObserva.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtaObserva.BackColor = System.Drawing.SystemColors.Control
        Me.dtaObserva.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtaObserva.DataField = "OBSERVA"
        Me.dtaObserva.DataTable = "V1"
        Me.dtaObserva.Descripcion = "Observaciones"
        Me.dtaObserva.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtaObserva.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtaObserva.FocoEnAgregar = False
        Me.dtaObserva.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtaObserva.Length_Data = 32767
        Me.dtaObserva.Location = New System.Drawing.Point(0, 120)
        Me.dtaObserva.Max_Value = 0.0R
        Me.dtaObserva.MensajeIncorrectoCustom = Nothing
        Me.dtaObserva.Name = "dtaObserva"
        Me.dtaObserva.Null_on_Empty = True
        Me.dtaObserva.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtaObserva.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtaObserva.ReadOnly_Data = False
        Me.dtaObserva.Size = New System.Drawing.Size(392, 91)
        Me.dtaObserva.TabIndex = 2
        Me.dtaObserva.Text_Data = ""
        Me.dtaObserva.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtaObserva.TopPadding = 0
        Me.dtaObserva.Upper_Case = False
        Me.dtaObserva.Validate_on_lost_focus = True
        '
        'dtaDanos
        '
        Me.dtaDanos.Allow_Empty = True
        Me.dtaDanos.Allow_Negative = True
        Me.dtaDanos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtaDanos.BackColor = System.Drawing.SystemColors.Control
        Me.dtaDanos.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtaDanos.DataField = "DANOS"
        Me.dtaDanos.DataTable = "V1"
        Me.dtaDanos.Descripcion = "Daños"
        Me.dtaDanos.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtaDanos.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtaDanos.FocoEnAgregar = False
        Me.dtaDanos.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtaDanos.Length_Data = 32767
        Me.dtaDanos.Location = New System.Drawing.Point(0, 29)
        Me.dtaDanos.Max_Value = 0.0R
        Me.dtaDanos.MensajeIncorrectoCustom = Nothing
        Me.dtaDanos.Name = "dtaDanos"
        Me.dtaDanos.Null_on_Empty = True
        Me.dtaDanos.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtaDanos.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtaDanos.ReadOnly_Data = False
        Me.dtaDanos.Size = New System.Drawing.Size(392, 91)
        Me.dtaDanos.TabIndex = 1
        Me.dtaDanos.Text_Data = ""
        Me.dtaDanos.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtaDanos.TopPadding = 0
        Me.dtaDanos.Upper_Case = False
        Me.dtaDanos.Validate_on_lost_focus = True
        '
        'dtfBastidor
        '
        Me.dtfBastidor.Allow_Empty = False
        Me.dtfBastidor.Allow_Negative = True
        Me.dtfBastidor.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfBastidor.BackColor = System.Drawing.SystemColors.Control
        Me.dtfBastidor.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfBastidor.DataField = "BASTIDOR"
        Me.dtfBastidor.DataTable = "V1"
        Me.dtfBastidor.Descripcion = "Bastidor"
        Me.dtfBastidor.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfBastidor.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfBastidor.FocoEnAgregar = False
        Me.dtfBastidor.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfBastidor.Image = Nothing
        Me.dtfBastidor.Label_Space = 75
        Me.dtfBastidor.Length_Data = 32767
        Me.dtfBastidor.Location = New System.Drawing.Point(0, 3)
        Me.dtfBastidor.Max_Value = 0.0R
        Me.dtfBastidor.MensajeIncorrectoCustom = Nothing
        Me.dtfBastidor.Name = "dtfBastidor"
        Me.dtfBastidor.Null_on_Empty = True
        Me.dtfBastidor.OpenForm = Nothing
        Me.dtfBastidor.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfBastidor.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfBastidor.ReadOnly_Data = False
        Me.dtfBastidor.Show_Button = False
        Me.dtfBastidor.Size = New System.Drawing.Size(392, 26)
        Me.dtfBastidor.TabIndex = 0
        Me.dtfBastidor.Text_Data = ""
        Me.dtfBastidor.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfBastidor.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfBastidor.TopPadding = 0
        Me.dtfBastidor.Upper_Case = True
        Me.dtfBastidor.Validate_on_lost_focus = True
        '
        'penGenGen
        '
        Me.penGenGen.Auto_Size = False
        Me.penGenGen.BackColor = System.Drawing.Color.PeachPuff
        Me.penGenGen.BorderColor = System.Drawing.SystemColors.Control
        Me.penGenGen.ChangeDock = False
        Me.penGenGen.Control_Resize = False
        Me.penGenGen.Controls.Add(Me.pnlGen)
        Me.penGenGen.Dock = System.Windows.Forms.DockStyle.Top
        Me.penGenGen.isSpace = False
        Me.penGenGen.Location = New System.Drawing.Point(0, 0)
        Me.penGenGen.Name = "penGenGen"
        Me.penGenGen.numRows = 0
        Me.penGenGen.Reorder = True
        Me.penGenGen.Size = New System.Drawing.Size(1138, 62)
        Me.penGenGen.TabIndex = 3
        '
        'pnlGen
        '
        Me.pnlGen.Auto_Size = False
        Me.pnlGen.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.pnlGen.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlGen.ChangeDock = True
        Me.pnlGen.Control_Resize = False
        Me.pnlGen.Controls.Add(Me.pnlAsocia)
        Me.pnlGen.Controls.Add(Me.pnlCodigo)
        Me.pnlGen.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlGen.isSpace = False
        Me.pnlGen.Location = New System.Drawing.Point(0, 0)
        Me.pnlGen.Name = "pnlGen"
        Me.pnlGen.numRows = 0
        Me.pnlGen.Reorder = True
        Me.pnlGen.Size = New System.Drawing.Size(1138, 62)
        Me.pnlGen.TabIndex = 0
        '
        'pnlAsocia
        '
        Me.pnlAsocia.Auto_Size = False
        Me.pnlAsocia.BackColor = System.Drawing.SystemColors.Control
        Me.pnlAsocia.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlAsocia.ChangeDock = True
        Me.pnlAsocia.Control_Resize = False
        Me.pnlAsocia.Controls.Add(Me.dtfModelo)
        Me.pnlAsocia.Controls.Add(Me.Panel2)
        Me.pnlAsocia.Controls.Add(Me.pnlMarca)
        Me.pnlAsocia.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlAsocia.isSpace = False
        Me.pnlAsocia.Location = New System.Drawing.Point(0, 30)
        Me.pnlAsocia.Name = "pnlAsocia"
        Me.pnlAsocia.numRows = 0
        Me.pnlAsocia.Reorder = True
        Me.pnlAsocia.Size = New System.Drawing.Size(1138, 30)
        Me.pnlAsocia.TabIndex = 1
        '
        'dtfModelo
        '
        Me.dtfModelo.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfModelo.Location = New System.Drawing.Point(398, 0)
        Me.dtfModelo.Marca = Nothing
        Me.dtfModelo.Name = "dtfModelo"
        Me.dtfModelo.QueryOnTextChanged = True
        Me.dtfModelo.Size = New System.Drawing.Size(740, 23)
        Me.dtfModelo.TabIndex = 2
        '
        'Panel2
        '
        Me.Panel2.Auto_Size = False
        Me.Panel2.BorderColor = System.Drawing.SystemColors.Control
        Me.Panel2.ChangeDock = True
        Me.Panel2.Control_Resize = False
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.isSpace = True
        Me.Panel2.Location = New System.Drawing.Point(388, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.numRows = 0
        Me.Panel2.Reorder = True
        Me.Panel2.Size = New System.Drawing.Size(10, 30)
        Me.Panel2.TabIndex = 1
        '
        'pnlMarca
        '
        Me.pnlMarca.Auto_Size = False
        Me.pnlMarca.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlMarca.ChangeDock = True
        Me.pnlMarca.Control_Resize = False
        Me.pnlMarca.Controls.Add(Me.dtfMarca)
        Me.pnlMarca.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlMarca.isSpace = False
        Me.pnlMarca.Location = New System.Drawing.Point(0, 0)
        Me.pnlMarca.Name = "pnlMarca"
        Me.pnlMarca.numRows = 0
        Me.pnlMarca.Reorder = True
        Me.pnlMarca.Size = New System.Drawing.Size(388, 30)
        Me.pnlMarca.TabIndex = 0
        '
        'dtfMarca
        '
        Me.dtfMarca.Allow_Empty = False
        Me.dtfMarca.Allow_Negative = True
        Me.dtfMarca.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfMarca.BackColor = System.Drawing.SystemColors.Control
        Me.dtfMarca.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfMarca.DataField = "MAR"
        Me.dtfMarca.DataField_DescEdit = "MARCA"
        Me.dtfMarca.DataTable = "V1"
        Me.dtfMarca.DataTable_DescEdit = "V1"
        Me.dtfMarca.DB = Connection3
        Me.dtfMarca.Desc_Datafield = "NOMBRE"
        Me.dtfMarca.Desc_DBPK = "CODIGO"
        Me.dtfMarca.Desc_DBTable = "MARCAS"
        Me.dtfMarca.Desc_Where = Nothing
        Me.dtfMarca.Desc_WhereObligatoria = Nothing
        Me.dtfMarca.Descripcion = "Marca"
        Me.dtfMarca.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfMarca.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfMarca.ExtraSQL = ""
        Me.dtfMarca.FocoEnAgregar = False
        Me.dtfMarca.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfMarca.Formulario = "Karve.ConfiguracionApp.MarcasVehiculo"
        Me.dtfMarca.Label_Space = 75
        Me.dtfMarca.Length_Data = 32767
        Me.dtfMarca.Location = New System.Drawing.Point(0, 0)
        Me.dtfMarca.Lupa = ""
        Me.dtfMarca.Max_Value = 0.0R
        Me.dtfMarca.MensajeIncorrectoCustom = Nothing
        Me.dtfMarca.Name = "dtfMarca"
        Me.dtfMarca.Null_on_Empty = True
        Me.dtfMarca.OpenForm = "Karve.ConfiguracionApp.MarcasVehiculo"
        Me.dtfMarca.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfMarca.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfMarca.Query_on_Text_Changed = True
        Me.dtfMarca.ReadOnly_Data = False
        Me.dtfMarca.ReadOnly_Desc = True
        Me.dtfMarca.ReQuery = False
        Me.dtfMarca.ShowButton = True
        Me.dtfMarca.Size = New System.Drawing.Size(388, 26)
        Me.dtfMarca.TabIndex = 0
        Me.dtfMarca.Text_Data = ""
        Me.dtfMarca.Text_Data_Desc = ""
        Me.dtfMarca.Text_Width = 58
        Me.dtfMarca.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfMarca.TopPadding = 0
        Me.dtfMarca.Upper_Case = False
        Me.dtfMarca.Validate_on_lost_focus = True
        '
        'pnlCodigo
        '
        Me.pnlCodigo.Auto_Size = False
        Me.pnlCodigo.BackColor = System.Drawing.SystemColors.Control
        Me.pnlCodigo.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlCodigo.ChangeDock = True
        Me.pnlCodigo.Control_Resize = False
        Me.pnlCodigo.Controls.Add(Me.dtfColor)
        Me.pnlCodigo.Controls.Add(Me.Panel1)
        Me.pnlCodigo.Controls.Add(Me.dtfMatricula)
        Me.pnlCodigo.Controls.Add(Me.pnlSpace1)
        Me.pnlCodigo.Controls.Add(Me.dtfCodigo)
        Me.pnlCodigo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCodigo.isSpace = False
        Me.pnlCodigo.Location = New System.Drawing.Point(0, 0)
        Me.pnlCodigo.Name = "pnlCodigo"
        Me.pnlCodigo.numRows = 0
        Me.pnlCodigo.Padding = New System.Windows.Forms.Padding(0, 5, 5, 5)
        Me.pnlCodigo.Reorder = True
        Me.pnlCodigo.Size = New System.Drawing.Size(1138, 30)
        Me.pnlCodigo.TabIndex = 0
        '
        'dtfColor
        '
        Me.dtfColor.Allow_Empty = True
        Me.dtfColor.Allow_Negative = True
        Me.dtfColor.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfColor.BackColor = System.Drawing.SystemColors.Control
        Me.dtfColor.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfColor.DataField = "COLOR"
        Me.dtfColor.DataTable = "V1"
        Me.dtfColor.DB = Connection4
        Me.dtfColor.Desc_Datafield = "NOMBRE n1"
        Me.dtfColor.Desc_DBPK = "CODIGO"
        Me.dtfColor.Desc_DBTable = "COLORFL"
        Me.dtfColor.Desc_Where = Nothing
        Me.dtfColor.Desc_WhereObligatoria = Nothing
        Me.dtfColor.Descripcion = "Color"
        Me.dtfColor.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfColor.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfColor.ExtraSQL = ""
        Me.dtfColor.FocoEnAgregar = False
        Me.dtfColor.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfColor.Formulario = Nothing
        Me.dtfColor.Label_Space = 80
        Me.dtfColor.Length_Data = 32767
        Me.dtfColor.Location = New System.Drawing.Point(398, 5)
        Me.dtfColor.Lupa = Nothing
        Me.dtfColor.Max_Value = 0.0R
        Me.dtfColor.MensajeIncorrectoCustom = Nothing
        Me.dtfColor.Name = "dtfColor"
        Me.dtfColor.Null_on_Empty = True
        Me.dtfColor.OpenForm = Nothing
        Me.dtfColor.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfColor.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfColor.Query_on_Text_Changed = True
        Me.dtfColor.ReadOnly_Data = False
        Me.dtfColor.ReQuery = False
        Me.dtfColor.ShowButton = True
        Me.dtfColor.Size = New System.Drawing.Size(740, 20)
        Me.dtfColor.TabIndex = 4
        Me.dtfColor.Text_Data = ""
        Me.dtfColor.Text_Data_Desc = ""
        Me.dtfColor.Text_Width = 80
        Me.dtfColor.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfColor.TopPadding = 0
        Me.dtfColor.Upper_Case = False
        Me.dtfColor.Validate_on_lost_focus = True
        '
        'Panel1
        '
        Me.Panel1.Auto_Size = False
        Me.Panel1.BorderColor = System.Drawing.SystemColors.Control
        Me.Panel1.ChangeDock = True
        Me.Panel1.Control_Resize = False
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.isSpace = True
        Me.Panel1.Location = New System.Drawing.Point(320, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.numRows = 0
        Me.Panel1.Reorder = True
        Me.Panel1.Size = New System.Drawing.Size(78, 20)
        Me.Panel1.TabIndex = 3
        '
        'dtfMatricula
        '
        Me.dtfMatricula.Allow_Empty = False
        Me.dtfMatricula.Allow_Negative = True
        Me.dtfMatricula.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfMatricula.BackColor = System.Drawing.SystemColors.Control
        Me.dtfMatricula.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfMatricula.DataField = "MATRICULA"
        Me.dtfMatricula.DataTable = "V1"
        Me.dtfMatricula.Descripcion = "Matrícula"
        Me.dtfMatricula.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfMatricula.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfMatricula.FocoEnAgregar = False
        Me.dtfMatricula.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfMatricula.Image = Nothing
        Me.dtfMatricula.Label_Space = 75
        Me.dtfMatricula.Length_Data = 32767
        Me.dtfMatricula.Location = New System.Drawing.Point(160, 5)
        Me.dtfMatricula.Max_Value = 0.0R
        Me.dtfMatricula.MensajeIncorrectoCustom = Nothing
        Me.dtfMatricula.Name = "dtfMatricula"
        Me.dtfMatricula.Null_on_Empty = True
        Me.dtfMatricula.OpenForm = Nothing
        Me.dtfMatricula.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfMatricula.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfMatricula.ReadOnly_Data = False
        Me.dtfMatricula.Show_Button = False
        Me.dtfMatricula.Size = New System.Drawing.Size(160, 20)
        Me.dtfMatricula.TabIndex = 2
        Me.dtfMatricula.Text_Data = ""
        Me.dtfMatricula.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfMatricula.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfMatricula.TopPadding = 0
        Me.dtfMatricula.Upper_Case = True
        Me.dtfMatricula.Validate_on_lost_focus = True
        '
        'pnlSpace1
        '
        Me.pnlSpace1.Auto_Size = False
        Me.pnlSpace1.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace1.ChangeDock = True
        Me.pnlSpace1.Control_Resize = False
        Me.pnlSpace1.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace1.isSpace = True
        Me.pnlSpace1.Location = New System.Drawing.Point(154, 5)
        Me.pnlSpace1.Name = "pnlSpace1"
        Me.pnlSpace1.numRows = 0
        Me.pnlSpace1.Reorder = True
        Me.pnlSpace1.Size = New System.Drawing.Size(6, 20)
        Me.pnlSpace1.TabIndex = 1
        '
        'dtfCodigo
        '
        Me.dtfCodigo.Allow_Empty = False
        Me.dtfCodigo.Allow_Negative = True
        Me.dtfCodigo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfCodigo.BackColor = System.Drawing.SystemColors.Control
        Me.dtfCodigo.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfCodigo.DataField = "CODIINT"
        Me.dtfCodigo.DataTable = "V1"
        Me.dtfCodigo.Descripcion = "Código"
        Me.dtfCodigo.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfCodigo.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfCodigo.FocoEnAgregar = True
        Me.dtfCodigo.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfCodigo.Image = Nothing
        Me.dtfCodigo.Label_Space = 75
        Me.dtfCodigo.Length_Data = 32767
        Me.dtfCodigo.Location = New System.Drawing.Point(0, 5)
        Me.dtfCodigo.Max_Value = 0.0R
        Me.dtfCodigo.MensajeIncorrectoCustom = Nothing
        Me.dtfCodigo.Name = "dtfCodigo"
        Me.dtfCodigo.Null_on_Empty = True
        Me.dtfCodigo.OpenForm = Nothing
        Me.dtfCodigo.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfCodigo.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfCodigo.ReadOnly_Data = True
        Me.dtfCodigo.Show_Button = False
        Me.dtfCodigo.Size = New System.Drawing.Size(154, 20)
        Me.dtfCodigo.TabIndex = 0
        Me.dtfCodigo.TabStop = False
        Me.dtfCodigo.Text_Data = ""
        Me.dtfCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfCodigo.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfCodigo.TopPadding = 0
        Me.dtfCodigo.Upper_Case = True
        Me.dtfCodigo.Validate_on_lost_focus = True
        '
        'pvpCompraVenta
        '
        Me.pvpCompraVenta.Controls.Add(Me.pnlComVenDer)
        Me.pvpCompraVenta.Controls.Add(Me.pnlComVenIzq)
        Me.pvpCompraVenta.Controls.Add(Me.pnlCabeceraCV)
        Me.pvpCompraVenta.ItemSize = New System.Drawing.SizeF(102.0!, 23.0!)
        Me.pvpCompraVenta.Location = New System.Drawing.Point(129, 5)
        Me.pvpCompraVenta.Name = "pvpCompraVenta"
        Me.pvpCompraVenta.PanelCabezeraContainer = Me.pnlCabeceraCV
        Me.pvpCompraVenta.Size = New System.Drawing.Size(1138, 500)
        Me.pvpCompraVenta.Text = "Compra Venta"
        '
        'pnlComVenDer
        '
        Me.pnlComVenDer.Auto_Size = False
        Me.pnlComVenDer.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlComVenDer.ChangeDock = True
        Me.pnlComVenDer.Control_Resize = False
        Me.pnlComVenDer.Controls.Add(Me.gbxImpuesto)
        Me.pnlComVenDer.Controls.Add(Me.gbxVentaVeh)
        Me.pnlComVenDer.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlComVenDer.isSpace = False
        Me.pnlComVenDer.Location = New System.Drawing.Point(568, 88)
        Me.pnlComVenDer.Name = "pnlComVenDer"
        Me.pnlComVenDer.numRows = 0
        Me.pnlComVenDer.Padding = New System.Windows.Forms.Padding(3)
        Me.pnlComVenDer.Reorder = True
        Me.pnlComVenDer.Size = New System.Drawing.Size(568, 412)
        Me.pnlComVenDer.TabIndex = 5
        '
        'gbxImpuesto
        '
        Me.gbxImpuesto.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.gbxImpuesto.Controls.Add(Me.dtfZonaImpuesto)
        Me.gbxImpuesto.Controls.Add(Me.dtfPoblacionImp)
        Me.gbxImpuesto.Controls.Add(Me.Panel14)
        Me.gbxImpuesto.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbxImpuesto.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.gbxImpuesto.HeaderText = "Impuesto de Circulación"
        Me.gbxImpuesto.Location = New System.Drawing.Point(3, 137)
        Me.gbxImpuesto.Name = "gbxImpuesto"
        Me.gbxImpuesto.numRows = 0
        Me.gbxImpuesto.Padding = New System.Windows.Forms.Padding(6, 18, 6, 6)
        Me.gbxImpuesto.Reorder = True
        Me.gbxImpuesto.Size = New System.Drawing.Size(562, 105)
        Me.gbxImpuesto.TabIndex = 1
        Me.gbxImpuesto.Text = "Impuesto de Circulación"
        Me.gbxImpuesto.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.gbxImpuesto.ThemeName = "Windows8"
        Me.gbxImpuesto.Title = "Impuesto de Circulación"
        '
        'dtfZonaImpuesto
        '
        Me.dtfZonaImpuesto.Allow_Empty = True
        Me.dtfZonaImpuesto.Allow_Negative = True
        Me.dtfZonaImpuesto.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfZonaImpuesto.BackColor = System.Drawing.SystemColors.Control
        Me.dtfZonaImpuesto.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfZonaImpuesto.DataField = "ZONA_IMP"
        Me.dtfZonaImpuesto.DataTable = "V1"
        Me.dtfZonaImpuesto.DB = Connection15
        Me.dtfZonaImpuesto.Desc_Datafield = "NOMBRE"
        Me.dtfZonaImpuesto.Desc_DBPK = "NUM_ZONA"
        Me.dtfZonaImpuesto.Desc_DBTable = "ZONAS"
        Me.dtfZonaImpuesto.Desc_Where = Nothing
        Me.dtfZonaImpuesto.Desc_WhereObligatoria = Nothing
        Me.dtfZonaImpuesto.Descripcion = "Zona"
        Me.dtfZonaImpuesto.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfZonaImpuesto.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfZonaImpuesto.ExtraSQL = ""
        Me.dtfZonaImpuesto.FocoEnAgregar = False
        Me.dtfZonaImpuesto.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfZonaImpuesto.Formulario = Nothing
        Me.dtfZonaImpuesto.Label_Space = 80
        Me.dtfZonaImpuesto.Length_Data = 32767
        Me.dtfZonaImpuesto.Location = New System.Drawing.Point(6, 70)
        Me.dtfZonaImpuesto.Lupa = Nothing
        Me.dtfZonaImpuesto.Max_Value = 0.0R
        Me.dtfZonaImpuesto.MensajeIncorrectoCustom = Nothing
        Me.dtfZonaImpuesto.Name = "dtfZonaImpuesto"
        Me.dtfZonaImpuesto.Null_on_Empty = True
        Me.dtfZonaImpuesto.OpenForm = Nothing
        Me.dtfZonaImpuesto.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfZonaImpuesto.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfZonaImpuesto.Query_on_Text_Changed = True
        Me.dtfZonaImpuesto.ReadOnly_Data = False
        Me.dtfZonaImpuesto.ReQuery = False
        Me.dtfZonaImpuesto.ShowButton = True
        Me.dtfZonaImpuesto.Size = New System.Drawing.Size(550, 26)
        Me.dtfZonaImpuesto.TabIndex = 2
        Me.dtfZonaImpuesto.Text_Data = ""
        Me.dtfZonaImpuesto.Text_Data_Desc = ""
        Me.dtfZonaImpuesto.Text_Width = 25
        Me.dtfZonaImpuesto.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfZonaImpuesto.TopPadding = 0
        Me.dtfZonaImpuesto.Upper_Case = False
        Me.dtfZonaImpuesto.Validate_on_lost_focus = True
        '
        'dtfPoblacionImp
        '
        Me.dtfPoblacionImp.Allow_Empty = True
        Me.dtfPoblacionImp.Allow_Negative = True
        Me.dtfPoblacionImp.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfPoblacionImp.BackColor = System.Drawing.SystemColors.Control
        Me.dtfPoblacionImp.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfPoblacionImp.DataField = ""
        Me.dtfPoblacionImp.DataTable = ""
        Me.dtfPoblacionImp.DB = Connection16
        Me.dtfPoblacionImp.Desc_Datafield = "POBLA"
        Me.dtfPoblacionImp.Desc_DBPK = "CP"
        Me.dtfPoblacionImp.Desc_DBTable = "POBLACIONES"
        Me.dtfPoblacionImp.Desc_Where = Nothing
        Me.dtfPoblacionImp.Desc_WhereObligatoria = Nothing
        Me.dtfPoblacionImp.Descripcion = "Población"
        Me.dtfPoblacionImp.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfPoblacionImp.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfPoblacionImp.ExtraSQL = ""
        Me.dtfPoblacionImp.FocoEnAgregar = False
        Me.dtfPoblacionImp.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfPoblacionImp.Formulario = Nothing
        Me.dtfPoblacionImp.Label_Space = 80
        Me.dtfPoblacionImp.Length_Data = 32767
        Me.dtfPoblacionImp.Location = New System.Drawing.Point(6, 44)
        Me.dtfPoblacionImp.Lupa = Nothing
        Me.dtfPoblacionImp.Max_Value = 0.0R
        Me.dtfPoblacionImp.MensajeIncorrectoCustom = Nothing
        Me.dtfPoblacionImp.Name = "dtfPoblacionImp"
        Me.dtfPoblacionImp.Null_on_Empty = True
        Me.dtfPoblacionImp.OpenForm = Nothing
        Me.dtfPoblacionImp.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfPoblacionImp.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfPoblacionImp.Query_on_Text_Changed = True
        Me.dtfPoblacionImp.ReadOnly_Data = False
        Me.dtfPoblacionImp.ReQuery = False
        Me.dtfPoblacionImp.ShowButton = True
        Me.dtfPoblacionImp.Size = New System.Drawing.Size(550, 26)
        Me.dtfPoblacionImp.TabIndex = 1
        Me.dtfPoblacionImp.Text_Data = ""
        Me.dtfPoblacionImp.Text_Data_Desc = ""
        Me.dtfPoblacionImp.Text_Width = 25
        Me.dtfPoblacionImp.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfPoblacionImp.TopPadding = 0
        Me.dtfPoblacionImp.Upper_Case = False
        Me.dtfPoblacionImp.Validate_on_lost_focus = True
        '
        'Panel14
        '
        Me.Panel14.Auto_Size = False
        Me.Panel14.BorderColor = System.Drawing.SystemColors.Control
        Me.Panel14.ChangeDock = True
        Me.Panel14.Control_Resize = False
        Me.Panel14.Controls.Add(Me.dtfImporteImp)
        Me.Panel14.Controls.Add(Me.Panel16)
        Me.Panel14.Controls.Add(Me.dtlFechaAltaImp)
        Me.Panel14.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel14.isSpace = False
        Me.Panel14.Location = New System.Drawing.Point(6, 18)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.numRows = 1
        Me.Panel14.Reorder = True
        Me.Panel14.Size = New System.Drawing.Size(550, 26)
        Me.Panel14.TabIndex = 0
        '
        'dtfImporteImp
        '
        Me.dtfImporteImp.Allow_Empty = False
        Me.dtfImporteImp.Allow_Negative = True
        Me.dtfImporteImp.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfImporteImp.BackColor = System.Drawing.SystemColors.Control
        Me.dtfImporteImp.Data_Allowed = CustomControls.Datafield.List_Data.Libre
        Me.dtfImporteImp.DataField = "IMP_CIRC_V1"
        Me.dtfImporteImp.DataTable = "V1"
        Me.dtfImporteImp.Descripcion = "Importe"
        Me.dtfImporteImp.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfImporteImp.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfImporteImp.FocoEnAgregar = False
        Me.dtfImporteImp.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfImporteImp.Image = Nothing
        Me.dtfImporteImp.Label_Space = 80
        Me.dtfImporteImp.Length_Data = 32767
        Me.dtfImporteImp.Location = New System.Drawing.Point(181, 0)
        Me.dtfImporteImp.Max_Value = 0.0R
        Me.dtfImporteImp.MensajeIncorrectoCustom = Nothing
        Me.dtfImporteImp.Name = "dtfImporteImp"
        Me.dtfImporteImp.Null_on_Empty = True
        Me.dtfImporteImp.OpenForm = Nothing
        Me.dtfImporteImp.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfImporteImp.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfImporteImp.ReadOnly_Data = False
        Me.dtfImporteImp.Show_Button = False
        Me.dtfImporteImp.Size = New System.Drawing.Size(177, 26)
        Me.dtfImporteImp.TabIndex = 2
        Me.dtfImporteImp.Text_Data = ""
        Me.dtfImporteImp.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfImporteImp.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfImporteImp.TopPadding = 0
        Me.dtfImporteImp.Upper_Case = False
        Me.dtfImporteImp.Validate_on_lost_focus = True
        '
        'Panel16
        '
        Me.Panel16.Auto_Size = False
        Me.Panel16.BorderColor = System.Drawing.SystemColors.Control
        Me.Panel16.ChangeDock = True
        Me.Panel16.Control_Resize = False
        Me.Panel16.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel16.isSpace = True
        Me.Panel16.Location = New System.Drawing.Point(175, 0)
        Me.Panel16.Name = "Panel16"
        Me.Panel16.numRows = 0
        Me.Panel16.Reorder = True
        Me.Panel16.Size = New System.Drawing.Size(6, 26)
        Me.Panel16.TabIndex = 1
        '
        'dtlFechaAltaImp
        '
        Me.dtlFechaAltaImp.Allow_Empty = True
        Me.dtlFechaAltaImp.DataField = "FEC_CIRC_V1"
        Me.dtlFechaAltaImp.DataTable = "V1"
        Me.dtlFechaAltaImp.Default_Value = New Date(2016, 4, 12, 0, 0, 0, 0)
        Me.dtlFechaAltaImp.Descripcion = "Fecha Alta"
        Me.dtlFechaAltaImp.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtlFechaAltaImp.FocoEnAgregar = False
        Me.dtlFechaAltaImp.Label_Space = 80
        Me.dtlFechaAltaImp.Location = New System.Drawing.Point(0, 0)
        Me.dtlFechaAltaImp.Max_Value = Nothing
        Me.dtlFechaAltaImp.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtlFechaAltaImp.MensajeIncorrectoCustom = Nothing
        Me.dtlFechaAltaImp.Min_Value = Nothing
        Me.dtlFechaAltaImp.MinDate = New Date(CType(0, Long))
        Me.dtlFechaAltaImp.MinimumSize = New System.Drawing.Size(170, 26)
        Me.dtlFechaAltaImp.Name = "dtlFechaAltaImp"
        Me.dtlFechaAltaImp.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtlFechaAltaImp.ReadOnly_Data = False
        Me.dtlFechaAltaImp.Size = New System.Drawing.Size(175, 26)
        Me.dtlFechaAltaImp.TabIndex = 0
        Me.dtlFechaAltaImp.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtlFechaAltaImp.Validate_on_lost_focus = True
        Me.dtlFechaAltaImp.Value_Data = New Date(2016, 4, 12, 0, 0, 0, 0)
        '
        'gbxVentaVeh
        '
        Me.gbxVentaVeh.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.gbxVentaVeh.Controls.Add(Me.Panel4)
        Me.gbxVentaVeh.Controls.Add(Me.Panel9)
        Me.gbxVentaVeh.Controls.Add(Me.Panel12)
        Me.gbxVentaVeh.Controls.Add(Me.dtfComprador)
        Me.gbxVentaVeh.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbxVentaVeh.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.gbxVentaVeh.HeaderText = "Venta del Vehículo"
        Me.gbxVentaVeh.Location = New System.Drawing.Point(3, 3)
        Me.gbxVentaVeh.Name = "gbxVentaVeh"
        Me.gbxVentaVeh.numRows = 0
        Me.gbxVentaVeh.Padding = New System.Windows.Forms.Padding(6, 18, 6, 6)
        Me.gbxVentaVeh.Reorder = True
        Me.gbxVentaVeh.Size = New System.Drawing.Size(562, 134)
        Me.gbxVentaVeh.TabIndex = 0
        Me.gbxVentaVeh.Text = "Venta del Vehículo"
        Me.gbxVentaVeh.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.gbxVentaVeh.ThemeName = "Windows8"
        Me.gbxVentaVeh.Title = "Venta del Vehículo"
        '
        'Panel4
        '
        Me.Panel4.Auto_Size = False
        Me.Panel4.BorderColor = System.Drawing.SystemColors.Control
        Me.Panel4.ChangeDock = True
        Me.Panel4.Control_Resize = False
        Me.Panel4.Controls.Add(Me.dtlTransfer)
        Me.Panel4.Controls.Add(Me.Panel3)
        Me.Panel4.Controls.Add(Me.dtlBajaSeguro)
        Me.Panel4.Controls.Add(Me.Panel5)
        Me.Panel4.Controls.Add(Me.dtlBajaTrafico)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.isSpace = False
        Me.Panel4.Location = New System.Drawing.Point(6, 96)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.numRows = 1
        Me.Panel4.Reorder = True
        Me.Panel4.Size = New System.Drawing.Size(550, 26)
        Me.Panel4.TabIndex = 3
        '
        'dtlTransfer
        '
        Me.dtlTransfer.Allow_Empty = True
        Me.dtlTransfer.DataField = "FTRANS"
        Me.dtlTransfer.DataTable = "V1"
        Me.dtlTransfer.Default_Value = New Date(2016, 4, 12, 0, 0, 0, 0)
        Me.dtlTransfer.Descripcion = "Transferencia"
        Me.dtlTransfer.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtlTransfer.FocoEnAgregar = False
        Me.dtlTransfer.Label_Space = 80
        Me.dtlTransfer.Location = New System.Drawing.Point(360, 0)
        Me.dtlTransfer.Max_Value = Nothing
        Me.dtlTransfer.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtlTransfer.MensajeIncorrectoCustom = Nothing
        Me.dtlTransfer.Min_Value = Nothing
        Me.dtlTransfer.MinDate = New Date(CType(0, Long))
        Me.dtlTransfer.MinimumSize = New System.Drawing.Size(170, 26)
        Me.dtlTransfer.Name = "dtlTransfer"
        Me.dtlTransfer.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtlTransfer.ReadOnly_Data = False
        Me.dtlTransfer.Size = New System.Drawing.Size(190, 26)
        Me.dtlTransfer.TabIndex = 4
        Me.dtlTransfer.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtlTransfer.Validate_on_lost_focus = True
        Me.dtlTransfer.Value_Data = New Date(2016, 4, 12, 0, 0, 0, 0)
        '
        'Panel3
        '
        Me.Panel3.Auto_Size = False
        Me.Panel3.BorderColor = System.Drawing.SystemColors.Control
        Me.Panel3.ChangeDock = True
        Me.Panel3.Control_Resize = False
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.isSpace = True
        Me.Panel3.Location = New System.Drawing.Point(350, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.numRows = 0
        Me.Panel3.Reorder = True
        Me.Panel3.Size = New System.Drawing.Size(10, 26)
        Me.Panel3.TabIndex = 3
        '
        'dtlBajaSeguro
        '
        Me.dtlBajaSeguro.Allow_Empty = True
        Me.dtlBajaSeguro.DataField = "FSEGUBA"
        Me.dtlBajaSeguro.DataTable = "V2"
        Me.dtlBajaSeguro.Default_Value = New Date(2016, 4, 12, 0, 0, 0, 0)
        Me.dtlBajaSeguro.Descripcion = "Baja Seguro"
        Me.dtlBajaSeguro.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtlBajaSeguro.FocoEnAgregar = False
        Me.dtlBajaSeguro.Label_Space = 80
        Me.dtlBajaSeguro.Location = New System.Drawing.Point(180, 0)
        Me.dtlBajaSeguro.Max_Value = Nothing
        Me.dtlBajaSeguro.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtlBajaSeguro.MensajeIncorrectoCustom = Nothing
        Me.dtlBajaSeguro.Min_Value = Nothing
        Me.dtlBajaSeguro.MinDate = New Date(CType(0, Long))
        Me.dtlBajaSeguro.MinimumSize = New System.Drawing.Size(170, 26)
        Me.dtlBajaSeguro.Name = "dtlBajaSeguro"
        Me.dtlBajaSeguro.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtlBajaSeguro.ReadOnly_Data = False
        Me.dtlBajaSeguro.Size = New System.Drawing.Size(170, 26)
        Me.dtlBajaSeguro.TabIndex = 2
        Me.dtlBajaSeguro.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtlBajaSeguro.Validate_on_lost_focus = True
        Me.dtlBajaSeguro.Value_Data = New Date(2016, 4, 12, 0, 0, 0, 0)
        '
        'Panel5
        '
        Me.Panel5.Auto_Size = False
        Me.Panel5.BorderColor = System.Drawing.SystemColors.Control
        Me.Panel5.ChangeDock = True
        Me.Panel5.Control_Resize = False
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel5.isSpace = True
        Me.Panel5.Location = New System.Drawing.Point(170, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.numRows = 0
        Me.Panel5.Reorder = True
        Me.Panel5.Size = New System.Drawing.Size(10, 26)
        Me.Panel5.TabIndex = 1
        '
        'dtlBajaTrafico
        '
        Me.dtlBajaTrafico.Allow_Empty = True
        Me.dtlBajaTrafico.DataField = "FTRAFB"
        Me.dtlBajaTrafico.DataTable = "V2"
        Me.dtlBajaTrafico.Default_Value = New Date(2016, 4, 12, 0, 0, 0, 0)
        Me.dtlBajaTrafico.Descripcion = "Baja Tráfico"
        Me.dtlBajaTrafico.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtlBajaTrafico.FocoEnAgregar = False
        Me.dtlBajaTrafico.Label_Space = 80
        Me.dtlBajaTrafico.Location = New System.Drawing.Point(0, 0)
        Me.dtlBajaTrafico.Max_Value = Nothing
        Me.dtlBajaTrafico.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtlBajaTrafico.MensajeIncorrectoCustom = Nothing
        Me.dtlBajaTrafico.Min_Value = Nothing
        Me.dtlBajaTrafico.MinDate = New Date(CType(0, Long))
        Me.dtlBajaTrafico.MinimumSize = New System.Drawing.Size(170, 26)
        Me.dtlBajaTrafico.Name = "dtlBajaTrafico"
        Me.dtlBajaTrafico.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtlBajaTrafico.ReadOnly_Data = False
        Me.dtlBajaTrafico.Size = New System.Drawing.Size(170, 26)
        Me.dtlBajaTrafico.TabIndex = 0
        Me.dtlBajaTrafico.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtlBajaTrafico.Validate_on_lost_focus = True
        Me.dtlBajaTrafico.Value_Data = New Date(2016, 4, 12, 0, 0, 0, 0)
        '
        'Panel9
        '
        Me.Panel9.Auto_Size = False
        Me.Panel9.BorderColor = System.Drawing.SystemColors.Control
        Me.Panel9.ChangeDock = True
        Me.Panel9.Control_Resize = False
        Me.Panel9.Controls.Add(Me.dtfPrecioVenta)
        Me.Panel9.Controls.Add(Me.Panel10)
        Me.Panel9.Controls.Add(Me.dtfVendedor)
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel9.isSpace = False
        Me.Panel9.Location = New System.Drawing.Point(6, 70)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.numRows = 1
        Me.Panel9.Reorder = True
        Me.Panel9.Size = New System.Drawing.Size(550, 26)
        Me.Panel9.TabIndex = 2
        '
        'dtfPrecioVenta
        '
        Me.dtfPrecioVenta.Allow_Empty = False
        Me.dtfPrecioVenta.Allow_Negative = True
        Me.dtfPrecioVenta.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfPrecioVenta.BackColor = System.Drawing.SystemColors.Control
        Me.dtfPrecioVenta.Data_Allowed = CustomControls.Datafield.List_Data.Libre
        Me.dtfPrecioVenta.DataField = "PVP"
        Me.dtfPrecioVenta.DataTable = "V1"
        Me.dtfPrecioVenta.Descripcion = "Precio Venta"
        Me.dtfPrecioVenta.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfPrecioVenta.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfPrecioVenta.FocoEnAgregar = False
        Me.dtfPrecioVenta.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfPrecioVenta.Image = Nothing
        Me.dtfPrecioVenta.Label_Space = 91
        Me.dtfPrecioVenta.Length_Data = 32767
        Me.dtfPrecioVenta.Location = New System.Drawing.Point(321, 0)
        Me.dtfPrecioVenta.Max_Value = 0.0R
        Me.dtfPrecioVenta.MensajeIncorrectoCustom = Nothing
        Me.dtfPrecioVenta.Name = "dtfPrecioVenta"
        Me.dtfPrecioVenta.Null_on_Empty = True
        Me.dtfPrecioVenta.OpenForm = Nothing
        Me.dtfPrecioVenta.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfPrecioVenta.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfPrecioVenta.ReadOnly_Data = False
        Me.dtfPrecioVenta.Show_Button = False
        Me.dtfPrecioVenta.Size = New System.Drawing.Size(157, 26)
        Me.dtfPrecioVenta.TabIndex = 2
        Me.dtfPrecioVenta.Text_Data = ""
        Me.dtfPrecioVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfPrecioVenta.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfPrecioVenta.TopPadding = 0
        Me.dtfPrecioVenta.Upper_Case = False
        Me.dtfPrecioVenta.Validate_on_lost_focus = True
        '
        'Panel10
        '
        Me.Panel10.Auto_Size = False
        Me.Panel10.BorderColor = System.Drawing.SystemColors.Control
        Me.Panel10.ChangeDock = True
        Me.Panel10.Control_Resize = False
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel10.isSpace = True
        Me.Panel10.Location = New System.Drawing.Point(308, 0)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.numRows = 0
        Me.Panel10.Reorder = True
        Me.Panel10.Size = New System.Drawing.Size(13, 26)
        Me.Panel10.TabIndex = 1
        '
        'dtfVendedor
        '
        Me.dtfVendedor.Allow_Empty = True
        Me.dtfVendedor.Allow_Negative = True
        Me.dtfVendedor.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfVendedor.BackColor = System.Drawing.SystemColors.Control
        Me.dtfVendedor.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfVendedor.DataField = "VENDEDOR_VTA"
        Me.dtfVendedor.DataTable = "V1"
        Me.dtfVendedor.DB = Connection17
        Me.dtfVendedor.Desc_Datafield = "NOMBRE"
        Me.dtfVendedor.Desc_DBPK = "NUM_VENDE"
        Me.dtfVendedor.Desc_DBTable = "VENDEDOR"
        Me.dtfVendedor.Desc_Where = Nothing
        Me.dtfVendedor.Desc_WhereObligatoria = Nothing
        Me.dtfVendedor.Descripcion = "Vendedor"
        Me.dtfVendedor.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfVendedor.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfVendedor.ExtraSQL = ""
        Me.dtfVendedor.FocoEnAgregar = False
        Me.dtfVendedor.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfVendedor.Formulario = Nothing
        Me.dtfVendedor.Label_Space = 80
        Me.dtfVendedor.Length_Data = 32767
        Me.dtfVendedor.Location = New System.Drawing.Point(0, 0)
        Me.dtfVendedor.Lupa = Nothing
        Me.dtfVendedor.Max_Value = 0.0R
        Me.dtfVendedor.MensajeIncorrectoCustom = Nothing
        Me.dtfVendedor.Name = "dtfVendedor"
        Me.dtfVendedor.Null_on_Empty = True
        Me.dtfVendedor.OpenForm = Nothing
        Me.dtfVendedor.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfVendedor.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfVendedor.Query_on_Text_Changed = True
        Me.dtfVendedor.ReadOnly_Data = False
        Me.dtfVendedor.ReQuery = False
        Me.dtfVendedor.ShowButton = True
        Me.dtfVendedor.Size = New System.Drawing.Size(308, 26)
        Me.dtfVendedor.TabIndex = 0
        Me.dtfVendedor.Text_Data = ""
        Me.dtfVendedor.Text_Data_Desc = ""
        Me.dtfVendedor.Text_Width = 55
        Me.dtfVendedor.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfVendedor.TopPadding = 0
        Me.dtfVendedor.Upper_Case = False
        Me.dtfVendedor.Validate_on_lost_focus = True
        '
        'Panel12
        '
        Me.Panel12.Auto_Size = False
        Me.Panel12.BorderColor = System.Drawing.SystemColors.Control
        Me.Panel12.ChangeDock = True
        Me.Panel12.Control_Resize = False
        Me.Panel12.Controls.Add(Me.dtfPrecioVentaVeh)
        Me.Panel12.Controls.Add(Me.Panel13)
        Me.Panel12.Controls.Add(Me.dtfFechaVenta)
        Me.Panel12.Controls.Add(Me.pnlSpace15)
        Me.Panel12.Controls.Add(Me.dtfFactura)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel12.isSpace = False
        Me.Panel12.Location = New System.Drawing.Point(6, 44)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.numRows = 1
        Me.Panel12.Reorder = True
        Me.Panel12.Size = New System.Drawing.Size(550, 26)
        Me.Panel12.TabIndex = 1
        '
        'dtfPrecioVentaVeh
        '
        Me.dtfPrecioVentaVeh.Allow_Empty = False
        Me.dtfPrecioVentaVeh.Allow_Negative = True
        Me.dtfPrecioVentaVeh.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfPrecioVentaVeh.BackColor = System.Drawing.SystemColors.Control
        Me.dtfPrecioVentaVeh.Data_Allowed = CustomControls.Datafield.List_Data.Libre
        Me.dtfPrecioVentaVeh.DataField = "PREVENTA"
        Me.dtfPrecioVentaVeh.DataTable = "V2"
        Me.dtfPrecioVentaVeh.Descripcion = "Precio"
        Me.dtfPrecioVentaVeh.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfPrecioVentaVeh.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfPrecioVentaVeh.FocoEnAgregar = False
        Me.dtfPrecioVentaVeh.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfPrecioVentaVeh.Image = Nothing
        Me.dtfPrecioVentaVeh.Label_Space = 51
        Me.dtfPrecioVentaVeh.Length_Data = 32767
        Me.dtfPrecioVentaVeh.Location = New System.Drawing.Point(361, 0)
        Me.dtfPrecioVentaVeh.Max_Value = 0.0R
        Me.dtfPrecioVentaVeh.MensajeIncorrectoCustom = Nothing
        Me.dtfPrecioVentaVeh.Name = "dtfPrecioVentaVeh"
        Me.dtfPrecioVentaVeh.Null_on_Empty = True
        Me.dtfPrecioVentaVeh.OpenForm = Nothing
        Me.dtfPrecioVentaVeh.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfPrecioVentaVeh.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfPrecioVentaVeh.ReadOnly_Data = False
        Me.dtfPrecioVentaVeh.Show_Button = False
        Me.dtfPrecioVentaVeh.Size = New System.Drawing.Size(117, 26)
        Me.dtfPrecioVentaVeh.TabIndex = 4
        Me.dtfPrecioVentaVeh.Text_Data = ""
        Me.dtfPrecioVentaVeh.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfPrecioVentaVeh.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfPrecioVentaVeh.TopPadding = 0
        Me.dtfPrecioVentaVeh.Upper_Case = False
        Me.dtfPrecioVentaVeh.Validate_on_lost_focus = True
        '
        'Panel13
        '
        Me.Panel13.Auto_Size = False
        Me.Panel13.BorderColor = System.Drawing.SystemColors.Control
        Me.Panel13.ChangeDock = True
        Me.Panel13.Control_Resize = False
        Me.Panel13.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel13.isSpace = True
        Me.Panel13.Location = New System.Drawing.Point(351, 0)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.numRows = 0
        Me.Panel13.Reorder = True
        Me.Panel13.Size = New System.Drawing.Size(10, 26)
        Me.Panel13.TabIndex = 3
        '
        'dtfFechaVenta
        '
        Me.dtfFechaVenta.Allow_Empty = True
        Me.dtfFechaVenta.DataField = "FFRA"
        Me.dtfFechaVenta.DataTable = "V1"
        Me.dtfFechaVenta.Default_Value = New Date(2016, 4, 12, 0, 0, 0, 0)
        Me.dtfFechaVenta.Descripcion = "F.Factura"
        Me.dtfFechaVenta.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfFechaVenta.FocoEnAgregar = False
        Me.dtfFechaVenta.Label_Space = 72
        Me.dtfFechaVenta.Location = New System.Drawing.Point(189, 0)
        Me.dtfFechaVenta.Max_Value = Nothing
        Me.dtfFechaVenta.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtfFechaVenta.MensajeIncorrectoCustom = Nothing
        Me.dtfFechaVenta.Min_Value = Nothing
        Me.dtfFechaVenta.MinDate = New Date(CType(0, Long))
        Me.dtfFechaVenta.MinimumSize = New System.Drawing.Size(162, 26)
        Me.dtfFechaVenta.Name = "dtfFechaVenta"
        Me.dtfFechaVenta.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfFechaVenta.ReadOnly_Data = False
        Me.dtfFechaVenta.Size = New System.Drawing.Size(162, 26)
        Me.dtfFechaVenta.TabIndex = 2
        Me.dtfFechaVenta.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfFechaVenta.Validate_on_lost_focus = True
        Me.dtfFechaVenta.Value_Data = New Date(2016, 4, 12, 0, 0, 0, 0)
        '
        'pnlSpace15
        '
        Me.pnlSpace15.Auto_Size = False
        Me.pnlSpace15.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace15.ChangeDock = True
        Me.pnlSpace15.Control_Resize = False
        Me.pnlSpace15.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace15.isSpace = True
        Me.pnlSpace15.Location = New System.Drawing.Point(177, 0)
        Me.pnlSpace15.Name = "pnlSpace15"
        Me.pnlSpace15.numRows = 0
        Me.pnlSpace15.Reorder = True
        Me.pnlSpace15.Size = New System.Drawing.Size(12, 26)
        Me.pnlSpace15.TabIndex = 1
        '
        'dtfFactura
        '
        Me.dtfFactura.Allow_Empty = False
        Me.dtfFactura.Allow_Negative = True
        Me.dtfFactura.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfFactura.BackColor = System.Drawing.SystemColors.Control
        Me.dtfFactura.Data_Allowed = CustomControls.Datafield.List_Data.Libre
        Me.dtfFactura.DataField = "FRAVEN"
        Me.dtfFactura.DataTable = "V1"
        Me.dtfFactura.Descripcion = "Nº Factura"
        Me.dtfFactura.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfFactura.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfFactura.FocoEnAgregar = False
        Me.dtfFactura.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfFactura.Image = Nothing
        Me.dtfFactura.Label_Space = 80
        Me.dtfFactura.Length_Data = 32767
        Me.dtfFactura.Location = New System.Drawing.Point(0, 0)
        Me.dtfFactura.Max_Value = 0.0R
        Me.dtfFactura.MensajeIncorrectoCustom = Nothing
        Me.dtfFactura.Name = "dtfFactura"
        Me.dtfFactura.Null_on_Empty = True
        Me.dtfFactura.OpenForm = Nothing
        Me.dtfFactura.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfFactura.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfFactura.ReadOnly_Data = False
        Me.dtfFactura.Show_Button = False
        Me.dtfFactura.Size = New System.Drawing.Size(177, 26)
        Me.dtfFactura.TabIndex = 0
        Me.dtfFactura.Text_Data = ""
        Me.dtfFactura.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfFactura.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfFactura.TopPadding = 0
        Me.dtfFactura.Upper_Case = False
        Me.dtfFactura.Validate_on_lost_focus = True
        '
        'dtfComprador
        '
        Me.dtfComprador.Allow_Empty = True
        Me.dtfComprador.Allow_Negative = True
        Me.dtfComprador.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfComprador.BackColor = System.Drawing.SystemColors.Control
        Me.dtfComprador.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfComprador.DataField = "comprador"
        Me.dtfComprador.DataTable = "V2"
        Me.dtfComprador.DB = Connection18
        Me.dtfComprador.Desc_Datafield = "NOMBRE"
        Me.dtfComprador.Desc_DBPK = "NUMERO_CLI"
        Me.dtfComprador.Desc_DBTable = "CLIENTES1"
        Me.dtfComprador.Desc_Where = Nothing
        Me.dtfComprador.Desc_WhereObligatoria = Nothing
        Me.dtfComprador.Descripcion = "Comprador"
        Me.dtfComprador.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfComprador.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfComprador.ExtraSQL = ""
        Me.dtfComprador.FocoEnAgregar = False
        Me.dtfComprador.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfComprador.Formulario = Nothing
        Me.dtfComprador.Label_Space = 80
        Me.dtfComprador.Length_Data = 32767
        Me.dtfComprador.Location = New System.Drawing.Point(6, 18)
        Me.dtfComprador.Lupa = Nothing
        Me.dtfComprador.Max_Value = 0.0R
        Me.dtfComprador.MensajeIncorrectoCustom = Nothing
        Me.dtfComprador.Name = "dtfComprador"
        Me.dtfComprador.Null_on_Empty = True
        Me.dtfComprador.OpenForm = Nothing
        Me.dtfComprador.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfComprador.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfComprador.Query_on_Text_Changed = True
        Me.dtfComprador.ReadOnly_Data = False
        Me.dtfComprador.ReQuery = False
        Me.dtfComprador.ShowButton = True
        Me.dtfComprador.Size = New System.Drawing.Size(550, 26)
        Me.dtfComprador.TabIndex = 0
        Me.dtfComprador.Text_Data = ""
        Me.dtfComprador.Text_Data_Desc = ""
        Me.dtfComprador.Text_Width = 97
        Me.dtfComprador.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfComprador.TopPadding = 0
        Me.dtfComprador.Upper_Case = False
        Me.dtfComprador.Validate_on_lost_focus = True
        '
        'pnlComVenIzq
        '
        Me.pnlComVenIzq.Auto_Size = False
        Me.pnlComVenIzq.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlComVenIzq.ChangeDock = True
        Me.pnlComVenIzq.Control_Resize = False
        Me.pnlComVenIzq.Controls.Add(Me.gbxLeasing)
        Me.pnlComVenIzq.Controls.Add(Me.gbxCompra)
        Me.pnlComVenIzq.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlComVenIzq.isSpace = False
        Me.pnlComVenIzq.Location = New System.Drawing.Point(0, 88)
        Me.pnlComVenIzq.Name = "pnlComVenIzq"
        Me.pnlComVenIzq.numRows = 0
        Me.pnlComVenIzq.Padding = New System.Windows.Forms.Padding(3)
        Me.pnlComVenIzq.Reorder = True
        Me.pnlComVenIzq.Size = New System.Drawing.Size(568, 412)
        Me.pnlComVenIzq.TabIndex = 3
        '
        'gbxLeasing
        '
        Me.gbxLeasing.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.gbxLeasing.Controls.Add(Me.dtaNotasLeasing)
        Me.gbxLeasing.Controls.Add(Me.pnlCuotaLeasing)
        Me.gbxLeasing.Controls.Add(Me.pnlOtorgamiento)
        Me.gbxLeasing.Controls.Add(Me.pnlContratoLeasing)
        Me.gbxLeasing.Controls.Add(Me.pnlFechasLeasing)
        Me.gbxLeasing.Controls.Add(Me.dtfCompañia)
        Me.gbxLeasing.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbxLeasing.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.gbxLeasing.HeaderText = "Datos del Leasing / Financiación"
        Me.gbxLeasing.Location = New System.Drawing.Point(3, 179)
        Me.gbxLeasing.Name = "gbxLeasing"
        Me.gbxLeasing.numRows = 0
        Me.gbxLeasing.Padding = New System.Windows.Forms.Padding(6, 18, 6, 6)
        Me.gbxLeasing.Reorder = True
        Me.gbxLeasing.Size = New System.Drawing.Size(562, 233)
        Me.gbxLeasing.TabIndex = 1
        Me.gbxLeasing.Text = "Datos del Leasing / Financiación"
        Me.gbxLeasing.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.gbxLeasing.ThemeName = "Windows8"
        Me.gbxLeasing.Title = "Datos del Leasing / Financiación"
        '
        'dtaNotasLeasing
        '
        Me.dtaNotasLeasing.Allow_Empty = True
        Me.dtaNotasLeasing.Allow_Negative = True
        Me.dtaNotasLeasing.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtaNotasLeasing.BackColor = System.Drawing.SystemColors.Control
        Me.dtaNotasLeasing.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtaNotasLeasing.DataField = "OBS1"
        Me.dtaNotasLeasing.DataTable = "V1"
        Me.dtaNotasLeasing.Descripcion = "Notas"
        Me.dtaNotasLeasing.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtaNotasLeasing.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtaNotasLeasing.FocoEnAgregar = False
        Me.dtaNotasLeasing.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtaNotasLeasing.Length_Data = 32767
        Me.dtaNotasLeasing.Location = New System.Drawing.Point(6, 148)
        Me.dtaNotasLeasing.Max_Value = 0.0R
        Me.dtaNotasLeasing.MensajeIncorrectoCustom = Nothing
        Me.dtaNotasLeasing.Name = "dtaNotasLeasing"
        Me.dtaNotasLeasing.Null_on_Empty = True
        Me.dtaNotasLeasing.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtaNotasLeasing.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtaNotasLeasing.ReadOnly_Data = False
        Me.dtaNotasLeasing.Size = New System.Drawing.Size(550, 82)
        Me.dtaNotasLeasing.TabIndex = 5
        Me.dtaNotasLeasing.Text_Data = ""
        Me.dtaNotasLeasing.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtaNotasLeasing.TopPadding = 0
        Me.dtaNotasLeasing.Upper_Case = False
        Me.dtaNotasLeasing.Validate_on_lost_focus = True
        '
        'pnlCuotaLeasing
        '
        Me.pnlCuotaLeasing.Auto_Size = False
        Me.pnlCuotaLeasing.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlCuotaLeasing.ChangeDock = True
        Me.pnlCuotaLeasing.Control_Resize = False
        Me.pnlCuotaLeasing.Controls.Add(Me.pnlSpace5)
        Me.pnlCuotaLeasing.Controls.Add(Me.Label1)
        Me.pnlCuotaLeasing.Controls.Add(Me.dtfInteresMorat)
        Me.pnlCuotaLeasing.Controls.Add(Me.pnlSpace6)
        Me.pnlCuotaLeasing.Controls.Add(Me.dtfKMExc)
        Me.pnlCuotaLeasing.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCuotaLeasing.isSpace = False
        Me.pnlCuotaLeasing.Location = New System.Drawing.Point(6, 122)
        Me.pnlCuotaLeasing.Name = "pnlCuotaLeasing"
        Me.pnlCuotaLeasing.numRows = 1
        Me.pnlCuotaLeasing.Reorder = True
        Me.pnlCuotaLeasing.Size = New System.Drawing.Size(550, 26)
        Me.pnlCuotaLeasing.TabIndex = 4
        '
        'pnlSpace5
        '
        Me.pnlSpace5.Auto_Size = False
        Me.pnlSpace5.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace5.ChangeDock = True
        Me.pnlSpace5.Control_Resize = False
        Me.pnlSpace5.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace5.isSpace = True
        Me.pnlSpace5.Location = New System.Drawing.Point(334, 0)
        Me.pnlSpace5.Name = "pnlSpace5"
        Me.pnlSpace5.numRows = 0
        Me.pnlSpace5.Reorder = True
        Me.pnlSpace5.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace5.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.Label1.Location = New System.Drawing.Point(316, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.Label1.Size = New System.Drawing.Size(18, 26)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "%"
        '
        'dtfInteresMorat
        '
        Me.dtfInteresMorat.Allow_Empty = False
        Me.dtfInteresMorat.Allow_Negative = True
        Me.dtfInteresMorat.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfInteresMorat.BackColor = System.Drawing.SystemColors.Control
        Me.dtfInteresMorat.Data_Allowed = CustomControls.Datafield.List_Data.Libre
        Me.dtfInteresMorat.DataField = "PORC_MORATORIO"
        Me.dtfInteresMorat.DataTable = "V2"
        Me.dtfInteresMorat.Descripcion = "Interes M."
        Me.dtfInteresMorat.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfInteresMorat.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfInteresMorat.FocoEnAgregar = False
        Me.dtfInteresMorat.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfInteresMorat.Image = Nothing
        Me.dtfInteresMorat.Label_Space = 59
        Me.dtfInteresMorat.Length_Data = 32767
        Me.dtfInteresMorat.Location = New System.Drawing.Point(206, 0)
        Me.dtfInteresMorat.Max_Value = 0.0R
        Me.dtfInteresMorat.MensajeIncorrectoCustom = Nothing
        Me.dtfInteresMorat.Name = "dtfInteresMorat"
        Me.dtfInteresMorat.Null_on_Empty = True
        Me.dtfInteresMorat.OpenForm = Nothing
        Me.dtfInteresMorat.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfInteresMorat.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfInteresMorat.ReadOnly_Data = False
        Me.dtfInteresMorat.Show_Button = False
        Me.dtfInteresMorat.Size = New System.Drawing.Size(110, 26)
        Me.dtfInteresMorat.TabIndex = 2
        Me.dtfInteresMorat.Text_Data = ""
        Me.dtfInteresMorat.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfInteresMorat.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfInteresMorat.TopPadding = 0
        Me.dtfInteresMorat.Upper_Case = False
        Me.dtfInteresMorat.Validate_on_lost_focus = True
        '
        'pnlSpace6
        '
        Me.pnlSpace6.Auto_Size = False
        Me.pnlSpace6.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace6.ChangeDock = True
        Me.pnlSpace6.Control_Resize = False
        Me.pnlSpace6.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace6.isSpace = True
        Me.pnlSpace6.Location = New System.Drawing.Point(200, 0)
        Me.pnlSpace6.Name = "pnlSpace6"
        Me.pnlSpace6.numRows = 0
        Me.pnlSpace6.Reorder = True
        Me.pnlSpace6.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace6.TabIndex = 1
        '
        'dtfKMExc
        '
        Me.dtfKMExc.Allow_Empty = False
        Me.dtfKMExc.Allow_Negative = True
        Me.dtfKMExc.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfKMExc.BackColor = System.Drawing.SystemColors.Control
        Me.dtfKMExc.Data_Allowed = CustomControls.Datafield.List_Data.Libre
        Me.dtfKMExc.DataField = "CUOTA_KM"
        Me.dtfKMExc.DataTable = "V2"
        Me.dtfKMExc.Descripcion = "Cuota Km. Exc."
        Me.dtfKMExc.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfKMExc.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfKMExc.FocoEnAgregar = False
        Me.dtfKMExc.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfKMExc.Image = Nothing
        Me.dtfKMExc.Label_Space = 110
        Me.dtfKMExc.Length_Data = 32767
        Me.dtfKMExc.Location = New System.Drawing.Point(0, 0)
        Me.dtfKMExc.Max_Value = 0.0R
        Me.dtfKMExc.MensajeIncorrectoCustom = Nothing
        Me.dtfKMExc.Name = "dtfKMExc"
        Me.dtfKMExc.Null_on_Empty = True
        Me.dtfKMExc.OpenForm = Nothing
        Me.dtfKMExc.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfKMExc.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfKMExc.ReadOnly_Data = False
        Me.dtfKMExc.Show_Button = False
        Me.dtfKMExc.Size = New System.Drawing.Size(200, 26)
        Me.dtfKMExc.TabIndex = 0
        Me.dtfKMExc.Text_Data = ""
        Me.dtfKMExc.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfKMExc.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfKMExc.TopPadding = 0
        Me.dtfKMExc.Upper_Case = False
        Me.dtfKMExc.Validate_on_lost_focus = True
        '
        'pnlOtorgamiento
        '
        Me.pnlOtorgamiento.Auto_Size = False
        Me.pnlOtorgamiento.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlOtorgamiento.ChangeDock = True
        Me.pnlOtorgamiento.Control_Resize = False
        Me.pnlOtorgamiento.Controls.Add(Me.dtfImpFinan)
        Me.pnlOtorgamiento.Controls.Add(Me.pnlSpace7)
        Me.pnlOtorgamiento.Controls.Add(Me.dtfDiaPago)
        Me.pnlOtorgamiento.Controls.Add(Me.pnlSpace8)
        Me.pnlOtorgamiento.Controls.Add(Me.dtfComisionOto)
        Me.pnlOtorgamiento.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlOtorgamiento.isSpace = False
        Me.pnlOtorgamiento.Location = New System.Drawing.Point(6, 96)
        Me.pnlOtorgamiento.Name = "pnlOtorgamiento"
        Me.pnlOtorgamiento.numRows = 1
        Me.pnlOtorgamiento.Reorder = True
        Me.pnlOtorgamiento.Size = New System.Drawing.Size(550, 26)
        Me.pnlOtorgamiento.TabIndex = 3
        '
        'dtfImpFinan
        '
        Me.dtfImpFinan.Allow_Empty = False
        Me.dtfImpFinan.Allow_Negative = True
        Me.dtfImpFinan.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfImpFinan.BackColor = System.Drawing.SystemColors.Control
        Me.dtfImpFinan.Data_Allowed = CustomControls.Datafield.List_Data.Libre
        Me.dtfImpFinan.DataField = ""
        Me.dtfImpFinan.DataTable = ""
        Me.dtfImpFinan.Descripcion = "Imp. Financiado"
        Me.dtfImpFinan.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfImpFinan.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfImpFinan.FocoEnAgregar = False
        Me.dtfImpFinan.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfImpFinan.Image = Nothing
        Me.dtfImpFinan.Label_Space = 94
        Me.dtfImpFinan.Length_Data = 32767
        Me.dtfImpFinan.Location = New System.Drawing.Point(299, 0)
        Me.dtfImpFinan.Max_Value = 0.0R
        Me.dtfImpFinan.MensajeIncorrectoCustom = Nothing
        Me.dtfImpFinan.Name = "dtfImpFinan"
        Me.dtfImpFinan.Null_on_Empty = True
        Me.dtfImpFinan.OpenForm = Nothing
        Me.dtfImpFinan.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfImpFinan.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfImpFinan.ReadOnly_Data = False
        Me.dtfImpFinan.Show_Button = False
        Me.dtfImpFinan.Size = New System.Drawing.Size(150, 26)
        Me.dtfImpFinan.TabIndex = 4
        Me.dtfImpFinan.Text_Data = ""
        Me.dtfImpFinan.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfImpFinan.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfImpFinan.TopPadding = 0
        Me.dtfImpFinan.Upper_Case = False
        Me.dtfImpFinan.Validate_on_lost_focus = True
        '
        'pnlSpace7
        '
        Me.pnlSpace7.Auto_Size = False
        Me.pnlSpace7.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace7.ChangeDock = True
        Me.pnlSpace7.Control_Resize = False
        Me.pnlSpace7.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace7.isSpace = True
        Me.pnlSpace7.Location = New System.Drawing.Point(293, 0)
        Me.pnlSpace7.Name = "pnlSpace7"
        Me.pnlSpace7.numRows = 0
        Me.pnlSpace7.Reorder = True
        Me.pnlSpace7.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace7.TabIndex = 3
        '
        'dtfDiaPago
        '
        Me.dtfDiaPago.Allow_Empty = False
        Me.dtfDiaPago.Allow_Negative = True
        Me.dtfDiaPago.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfDiaPago.BackColor = System.Drawing.SystemColors.Control
        Me.dtfDiaPago.Data_Allowed = CustomControls.Datafield.List_Data.Libre
        Me.dtfDiaPago.DataField = "DIA_PAGO"
        Me.dtfDiaPago.DataTable = "V2"
        Me.dtfDiaPago.Descripcion = "Dia Pago"
        Me.dtfDiaPago.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfDiaPago.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfDiaPago.FocoEnAgregar = False
        Me.dtfDiaPago.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfDiaPago.Image = Nothing
        Me.dtfDiaPago.Label_Space = 60
        Me.dtfDiaPago.Length_Data = 32767
        Me.dtfDiaPago.Location = New System.Drawing.Point(206, 0)
        Me.dtfDiaPago.Max_Value = 0.0R
        Me.dtfDiaPago.MensajeIncorrectoCustom = Nothing
        Me.dtfDiaPago.Name = "dtfDiaPago"
        Me.dtfDiaPago.Null_on_Empty = True
        Me.dtfDiaPago.OpenForm = Nothing
        Me.dtfDiaPago.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfDiaPago.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfDiaPago.ReadOnly_Data = False
        Me.dtfDiaPago.Show_Button = False
        Me.dtfDiaPago.Size = New System.Drawing.Size(87, 26)
        Me.dtfDiaPago.TabIndex = 2
        Me.dtfDiaPago.Text_Data = ""
        Me.dtfDiaPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfDiaPago.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfDiaPago.TopPadding = 0
        Me.dtfDiaPago.Upper_Case = False
        Me.dtfDiaPago.Validate_on_lost_focus = True
        '
        'pnlSpace8
        '
        Me.pnlSpace8.Auto_Size = False
        Me.pnlSpace8.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace8.ChangeDock = True
        Me.pnlSpace8.Control_Resize = False
        Me.pnlSpace8.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace8.isSpace = True
        Me.pnlSpace8.Location = New System.Drawing.Point(200, 0)
        Me.pnlSpace8.Name = "pnlSpace8"
        Me.pnlSpace8.numRows = 0
        Me.pnlSpace8.Reorder = True
        Me.pnlSpace8.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace8.TabIndex = 1
        '
        'dtfComisionOto
        '
        Me.dtfComisionOto.Allow_Empty = False
        Me.dtfComisionOto.Allow_Negative = True
        Me.dtfComisionOto.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfComisionOto.BackColor = System.Drawing.SystemColors.Control
        Me.dtfComisionOto.Data_Allowed = CustomControls.Datafield.List_Data.Libre
        Me.dtfComisionOto.DataField = "COMI_OTOR"
        Me.dtfComisionOto.DataTable = "V2"
        Me.dtfComisionOto.Descripcion = "C.Otorgamiento"
        Me.dtfComisionOto.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfComisionOto.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfComisionOto.FocoEnAgregar = False
        Me.dtfComisionOto.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfComisionOto.Image = Nothing
        Me.dtfComisionOto.Label_Space = 110
        Me.dtfComisionOto.Length_Data = 32767
        Me.dtfComisionOto.Location = New System.Drawing.Point(0, 0)
        Me.dtfComisionOto.Max_Value = 0.0R
        Me.dtfComisionOto.MensajeIncorrectoCustom = Nothing
        Me.dtfComisionOto.Name = "dtfComisionOto"
        Me.dtfComisionOto.Null_on_Empty = True
        Me.dtfComisionOto.OpenForm = Nothing
        Me.dtfComisionOto.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfComisionOto.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfComisionOto.ReadOnly_Data = False
        Me.dtfComisionOto.Show_Button = False
        Me.dtfComisionOto.Size = New System.Drawing.Size(200, 26)
        Me.dtfComisionOto.TabIndex = 0
        Me.dtfComisionOto.Text_Data = ""
        Me.dtfComisionOto.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfComisionOto.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfComisionOto.TopPadding = 0
        Me.dtfComisionOto.Upper_Case = False
        Me.dtfComisionOto.Validate_on_lost_focus = True
        '
        'pnlContratoLeasing
        '
        Me.pnlContratoLeasing.Auto_Size = False
        Me.pnlContratoLeasing.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlContratoLeasing.ChangeDock = True
        Me.pnlContratoLeasing.Control_Resize = False
        Me.pnlContratoLeasing.Controls.Add(Me.dtfCuota)
        Me.pnlContratoLeasing.Controls.Add(Me.pnlSpace11)
        Me.pnlContratoLeasing.Controls.Add(Me.lblPorcen1)
        Me.pnlContratoLeasing.Controls.Add(Me.dtfInteres)
        Me.pnlContratoLeasing.Controls.Add(Me.pnlSpace10)
        Me.pnlContratoLeasing.Controls.Add(Me.dtfContrato)
        Me.pnlContratoLeasing.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlContratoLeasing.isSpace = False
        Me.pnlContratoLeasing.Location = New System.Drawing.Point(6, 70)
        Me.pnlContratoLeasing.Name = "pnlContratoLeasing"
        Me.pnlContratoLeasing.numRows = 1
        Me.pnlContratoLeasing.Reorder = True
        Me.pnlContratoLeasing.Size = New System.Drawing.Size(550, 26)
        Me.pnlContratoLeasing.TabIndex = 2
        '
        'dtfCuota
        '
        Me.dtfCuota.Allow_Empty = False
        Me.dtfCuota.Allow_Negative = True
        Me.dtfCuota.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfCuota.BackColor = System.Drawing.SystemColors.Control
        Me.dtfCuota.Data_Allowed = CustomControls.Datafield.List_Data.Libre
        Me.dtfCuota.DataField = "CUOTA"
        Me.dtfCuota.DataTable = "V1"
        Me.dtfCuota.Descripcion = "Cuota"
        Me.dtfCuota.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfCuota.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfCuota.FocoEnAgregar = False
        Me.dtfCuota.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfCuota.Image = Nothing
        Me.dtfCuota.Label_Space = 45
        Me.dtfCuota.Length_Data = 32767
        Me.dtfCuota.Location = New System.Drawing.Point(317, 0)
        Me.dtfCuota.Max_Value = 0.0R
        Me.dtfCuota.MensajeIncorrectoCustom = Nothing
        Me.dtfCuota.Name = "dtfCuota"
        Me.dtfCuota.Null_on_Empty = True
        Me.dtfCuota.OpenForm = Nothing
        Me.dtfCuota.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfCuota.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfCuota.ReadOnly_Data = False
        Me.dtfCuota.Show_Button = False
        Me.dtfCuota.Size = New System.Drawing.Size(132, 26)
        Me.dtfCuota.TabIndex = 5
        Me.dtfCuota.Text_Data = ""
        Me.dtfCuota.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfCuota.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfCuota.TopPadding = 0
        Me.dtfCuota.Upper_Case = False
        Me.dtfCuota.Validate_on_lost_focus = True
        '
        'pnlSpace11
        '
        Me.pnlSpace11.Auto_Size = False
        Me.pnlSpace11.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace11.ChangeDock = True
        Me.pnlSpace11.Control_Resize = False
        Me.pnlSpace11.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace11.isSpace = True
        Me.pnlSpace11.Location = New System.Drawing.Point(311, 0)
        Me.pnlSpace11.Name = "pnlSpace11"
        Me.pnlSpace11.numRows = 0
        Me.pnlSpace11.Reorder = True
        Me.pnlSpace11.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace11.TabIndex = 4
        '
        'lblPorcen1
        '
        Me.lblPorcen1.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblPorcen1.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblPorcen1.Location = New System.Drawing.Point(293, 0)
        Me.lblPorcen1.Name = "lblPorcen1"
        Me.lblPorcen1.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.lblPorcen1.Size = New System.Drawing.Size(18, 26)
        Me.lblPorcen1.TabIndex = 3
        Me.lblPorcen1.Text = "%"
        '
        'dtfInteres
        '
        Me.dtfInteres.Allow_Empty = False
        Me.dtfInteres.Allow_Negative = True
        Me.dtfInteres.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfInteres.BackColor = System.Drawing.SystemColors.Control
        Me.dtfInteres.Data_Allowed = CustomControls.Datafield.List_Data.Libre
        Me.dtfInteres.DataField = "INTERES"
        Me.dtfInteres.DataTable = "V2"
        Me.dtfInteres.Descripcion = "Interés"
        Me.dtfInteres.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfInteres.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfInteres.FocoEnAgregar = False
        Me.dtfInteres.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfInteres.Image = Nothing
        Me.dtfInteres.Label_Space = 45
        Me.dtfInteres.Length_Data = 32767
        Me.dtfInteres.Location = New System.Drawing.Point(206, 0)
        Me.dtfInteres.Max_Value = 0.0R
        Me.dtfInteres.MensajeIncorrectoCustom = Nothing
        Me.dtfInteres.Name = "dtfInteres"
        Me.dtfInteres.Null_on_Empty = True
        Me.dtfInteres.OpenForm = Nothing
        Me.dtfInteres.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfInteres.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfInteres.ReadOnly_Data = False
        Me.dtfInteres.Show_Button = False
        Me.dtfInteres.Size = New System.Drawing.Size(87, 26)
        Me.dtfInteres.TabIndex = 2
        Me.dtfInteres.Text_Data = ""
        Me.dtfInteres.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfInteres.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfInteres.TopPadding = 0
        Me.dtfInteres.Upper_Case = False
        Me.dtfInteres.Validate_on_lost_focus = True
        '
        'pnlSpace10
        '
        Me.pnlSpace10.Auto_Size = False
        Me.pnlSpace10.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace10.ChangeDock = True
        Me.pnlSpace10.Control_Resize = False
        Me.pnlSpace10.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace10.isSpace = True
        Me.pnlSpace10.Location = New System.Drawing.Point(200, 0)
        Me.pnlSpace10.Name = "pnlSpace10"
        Me.pnlSpace10.numRows = 0
        Me.pnlSpace10.Reorder = True
        Me.pnlSpace10.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace10.TabIndex = 1
        '
        'dtfContrato
        '
        Me.dtfContrato.Allow_Empty = False
        Me.dtfContrato.Allow_Negative = True
        Me.dtfContrato.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfContrato.BackColor = System.Drawing.SystemColors.Control
        Me.dtfContrato.Data_Allowed = CustomControls.Datafield.List_Data.Libre
        Me.dtfContrato.DataField = "CONTLEAS"
        Me.dtfContrato.DataTable = "V2"
        Me.dtfContrato.Descripcion = "Número Contrato"
        Me.dtfContrato.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfContrato.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfContrato.FocoEnAgregar = False
        Me.dtfContrato.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfContrato.Image = Nothing
        Me.dtfContrato.Label_Space = 110
        Me.dtfContrato.Length_Data = 32767
        Me.dtfContrato.Location = New System.Drawing.Point(0, 0)
        Me.dtfContrato.Max_Value = 0.0R
        Me.dtfContrato.MensajeIncorrectoCustom = Nothing
        Me.dtfContrato.Name = "dtfContrato"
        Me.dtfContrato.Null_on_Empty = True
        Me.dtfContrato.OpenForm = Nothing
        Me.dtfContrato.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfContrato.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfContrato.ReadOnly_Data = False
        Me.dtfContrato.Show_Button = False
        Me.dtfContrato.Size = New System.Drawing.Size(200, 26)
        Me.dtfContrato.TabIndex = 0
        Me.dtfContrato.Text_Data = ""
        Me.dtfContrato.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfContrato.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfContrato.TopPadding = 0
        Me.dtfContrato.Upper_Case = False
        Me.dtfContrato.Validate_on_lost_focus = True
        '
        'pnlFechasLeasing
        '
        Me.pnlFechasLeasing.Auto_Size = False
        Me.pnlFechasLeasing.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlFechasLeasing.ChangeDock = True
        Me.pnlFechasLeasing.Control_Resize = False
        Me.pnlFechasLeasing.Controls.Add(Me.dtlFinal)
        Me.pnlFechasLeasing.Controls.Add(Me.pnlSpace9)
        Me.pnlFechasLeasing.Controls.Add(Me.dtlInicio)
        Me.pnlFechasLeasing.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFechasLeasing.isSpace = False
        Me.pnlFechasLeasing.Location = New System.Drawing.Point(6, 44)
        Me.pnlFechasLeasing.Name = "pnlFechasLeasing"
        Me.pnlFechasLeasing.numRows = 1
        Me.pnlFechasLeasing.Reorder = True
        Me.pnlFechasLeasing.Size = New System.Drawing.Size(550, 26)
        Me.pnlFechasLeasing.TabIndex = 1
        '
        'dtlFinal
        '
        Me.dtlFinal.Allow_Empty = True
        Me.dtlFinal.DataField = "VTOLEAS"
        Me.dtlFinal.DataTable = "V2"
        Me.dtlFinal.Default_Value = New Date(2016, 4, 12, 0, 0, 0, 0)
        Me.dtlFinal.Descripcion = "Fecha Final"
        Me.dtlFinal.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtlFinal.FocoEnAgregar = False
        Me.dtlFinal.Label_Space = 90
        Me.dtlFinal.Location = New System.Drawing.Point(206, 0)
        Me.dtlFinal.Max_Value = Nothing
        Me.dtlFinal.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtlFinal.MensajeIncorrectoCustom = Nothing
        Me.dtlFinal.Min_Value = Nothing
        Me.dtlFinal.MinDate = New Date(CType(0, Long))
        Me.dtlFinal.MinimumSize = New System.Drawing.Size(180, 26)
        Me.dtlFinal.Name = "dtlFinal"
        Me.dtlFinal.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtlFinal.ReadOnly_Data = False
        Me.dtlFinal.Size = New System.Drawing.Size(180, 26)
        Me.dtlFinal.TabIndex = 2
        Me.dtlFinal.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtlFinal.Validate_on_lost_focus = True
        Me.dtlFinal.Value_Data = New Date(2016, 4, 12, 0, 0, 0, 0)
        '
        'pnlSpace9
        '
        Me.pnlSpace9.Auto_Size = False
        Me.pnlSpace9.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace9.ChangeDock = True
        Me.pnlSpace9.Control_Resize = False
        Me.pnlSpace9.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace9.isSpace = True
        Me.pnlSpace9.Location = New System.Drawing.Point(200, 0)
        Me.pnlSpace9.Name = "pnlSpace9"
        Me.pnlSpace9.numRows = 0
        Me.pnlSpace9.Reorder = True
        Me.pnlSpace9.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace9.TabIndex = 1
        '
        'dtlInicio
        '
        Me.dtlInicio.Allow_Empty = True
        Me.dtlInicio.DataField = "INILEAS"
        Me.dtlInicio.DataTable = "V2"
        Me.dtlInicio.Default_Value = New Date(2016, 4, 12, 0, 0, 0, 0)
        Me.dtlInicio.Descripcion = "Fecha Inicio"
        Me.dtlInicio.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtlInicio.FocoEnAgregar = False
        Me.dtlInicio.Label_Space = 110
        Me.dtlInicio.Location = New System.Drawing.Point(0, 0)
        Me.dtlInicio.Max_Value = Nothing
        Me.dtlInicio.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtlInicio.MensajeIncorrectoCustom = Nothing
        Me.dtlInicio.Min_Value = Nothing
        Me.dtlInicio.MinDate = New Date(CType(0, Long))
        Me.dtlInicio.MinimumSize = New System.Drawing.Size(200, 26)
        Me.dtlInicio.Name = "dtlInicio"
        Me.dtlInicio.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtlInicio.ReadOnly_Data = False
        Me.dtlInicio.Size = New System.Drawing.Size(200, 26)
        Me.dtlInicio.TabIndex = 0
        Me.dtlInicio.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtlInicio.Validate_on_lost_focus = True
        Me.dtlInicio.Value_Data = New Date(2016, 4, 12, 0, 0, 0, 0)
        '
        'dtfCompañia
        '
        Me.dtfCompañia.Allow_Empty = True
        Me.dtfCompañia.Allow_Negative = True
        Me.dtfCompañia.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfCompañia.BackColor = System.Drawing.SystemColors.Control
        Me.dtfCompañia.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfCompañia.DataField = "CIALEAS"
        Me.dtfCompañia.DataTable = "V1"
        Me.dtfCompañia.DB = Connection19
        Me.dtfCompañia.Desc_Datafield = "NOMBRE"
        Me.dtfCompañia.Desc_DBPK = "NUM_PROVEE"
        Me.dtfCompañia.Desc_DBTable = "provee1"
        Me.dtfCompañia.Desc_Where = Nothing
        Me.dtfCompañia.Desc_WhereObligatoria = Nothing
        Me.dtfCompañia.Descripcion = "Compañía"
        Me.dtfCompañia.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfCompañia.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfCompañia.ExtraSQL = ""
        Me.dtfCompañia.FocoEnAgregar = False
        Me.dtfCompañia.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfCompañia.Formulario = Nothing
        Me.dtfCompañia.Label_Space = 110
        Me.dtfCompañia.Length_Data = 32767
        Me.dtfCompañia.Location = New System.Drawing.Point(6, 18)
        Me.dtfCompañia.Lupa = Nothing
        Me.dtfCompañia.Max_Value = 0.0R
        Me.dtfCompañia.MensajeIncorrectoCustom = Nothing
        Me.dtfCompañia.Name = "dtfCompañia"
        Me.dtfCompañia.Null_on_Empty = True
        Me.dtfCompañia.OpenForm = Nothing
        Me.dtfCompañia.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfCompañia.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfCompañia.Query_on_Text_Changed = True
        Me.dtfCompañia.ReadOnly_Data = False
        Me.dtfCompañia.ReQuery = False
        Me.dtfCompañia.ShowButton = True
        Me.dtfCompañia.Size = New System.Drawing.Size(550, 26)
        Me.dtfCompañia.TabIndex = 0
        Me.dtfCompañia.Text_Data = ""
        Me.dtfCompañia.Text_Data_Desc = ""
        Me.dtfCompañia.Text_Width = 25
        Me.dtfCompañia.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfCompañia.TopPadding = 0
        Me.dtfCompañia.Upper_Case = False
        Me.dtfCompañia.Validate_on_lost_focus = True
        '
        'gbxCompra
        '
        Me.gbxCompra.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.gbxCompra.Controls.Add(Me.pnlPrecioFranco)
        Me.gbxCompra.Controls.Add(Me.Panel7)
        Me.gbxCompra.Controls.Add(Me.pnlFechasCompra)
        Me.gbxCompra.Controls.Add(Me.pnlFormaPago)
        Me.gbxCompra.Controls.Add(Me.pnlPreciosCompra)
        Me.gbxCompra.Controls.Add(Me.dtfProveedor)
        Me.gbxCompra.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbxCompra.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.gbxCompra.HeaderText = "Compra del Vehículo"
        Me.gbxCompra.Location = New System.Drawing.Point(3, 3)
        Me.gbxCompra.Name = "gbxCompra"
        Me.gbxCompra.numRows = 6
        Me.gbxCompra.Padding = New System.Windows.Forms.Padding(6, 18, 6, 6)
        Me.gbxCompra.Reorder = True
        Me.gbxCompra.Size = New System.Drawing.Size(562, 176)
        Me.gbxCompra.TabIndex = 0
        Me.gbxCompra.Text = "Compra del Vehículo"
        Me.gbxCompra.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.gbxCompra.ThemeName = "Windows8"
        Me.gbxCompra.Title = "Compra del Vehículo"
        '
        'pnlPrecioFranco
        '
        Me.pnlPrecioFranco.Auto_Size = False
        Me.pnlPrecioFranco.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlPrecioFranco.ChangeDock = True
        Me.pnlPrecioFranco.Control_Resize = False
        Me.pnlPrecioFranco.Controls.Add(Me.dtfPrecioFrancoOp)
        Me.pnlPrecioFranco.Controls.Add(Me.pnlSpace14)
        Me.pnlPrecioFranco.Controls.Add(Me.dtfPrecioFranco)
        Me.pnlPrecioFranco.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlPrecioFranco.isSpace = False
        Me.pnlPrecioFranco.Location = New System.Drawing.Point(6, 148)
        Me.pnlPrecioFranco.Name = "pnlPrecioFranco"
        Me.pnlPrecioFranco.numRows = 1
        Me.pnlPrecioFranco.Reorder = True
        Me.pnlPrecioFranco.Size = New System.Drawing.Size(550, 26)
        Me.pnlPrecioFranco.TabIndex = 5
        '
        'dtfPrecioFrancoOp
        '
        Me.dtfPrecioFrancoOp.Allow_Empty = False
        Me.dtfPrecioFrancoOp.Allow_Negative = True
        Me.dtfPrecioFrancoOp.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfPrecioFrancoOp.BackColor = System.Drawing.SystemColors.Control
        Me.dtfPrecioFrancoOp.Data_Allowed = CustomControls.Datafield.List_Data.Libre
        Me.dtfPrecioFrancoOp.DataField = "PFF_OPCIONES"
        Me.dtfPrecioFrancoOp.DataTable = "V1"
        Me.dtfPrecioFrancoOp.Descripcion = "Precio Franco Fabrica Opc."
        Me.dtfPrecioFrancoOp.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfPrecioFrancoOp.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfPrecioFrancoOp.FocoEnAgregar = False
        Me.dtfPrecioFrancoOp.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfPrecioFrancoOp.Image = Nothing
        Me.dtfPrecioFrancoOp.Label_Space = 160
        Me.dtfPrecioFrancoOp.Length_Data = 32767
        Me.dtfPrecioFrancoOp.Location = New System.Drawing.Point(227, 0)
        Me.dtfPrecioFrancoOp.Max_Value = 0.0R
        Me.dtfPrecioFrancoOp.MensajeIncorrectoCustom = Nothing
        Me.dtfPrecioFrancoOp.Name = "dtfPrecioFrancoOp"
        Me.dtfPrecioFrancoOp.Null_on_Empty = True
        Me.dtfPrecioFrancoOp.OpenForm = Nothing
        Me.dtfPrecioFrancoOp.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfPrecioFrancoOp.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfPrecioFrancoOp.ReadOnly_Data = False
        Me.dtfPrecioFrancoOp.Show_Button = False
        Me.dtfPrecioFrancoOp.Size = New System.Drawing.Size(221, 26)
        Me.dtfPrecioFrancoOp.TabIndex = 2
        Me.dtfPrecioFrancoOp.Text_Data = "10000,00"
        Me.dtfPrecioFrancoOp.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfPrecioFrancoOp.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfPrecioFrancoOp.TopPadding = 0
        Me.dtfPrecioFrancoOp.Upper_Case = False
        Me.dtfPrecioFrancoOp.Validate_on_lost_focus = True
        '
        'pnlSpace14
        '
        Me.pnlSpace14.Auto_Size = False
        Me.pnlSpace14.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace14.ChangeDock = True
        Me.pnlSpace14.Control_Resize = False
        Me.pnlSpace14.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace14.isSpace = True
        Me.pnlSpace14.Location = New System.Drawing.Point(221, 0)
        Me.pnlSpace14.Name = "pnlSpace14"
        Me.pnlSpace14.numRows = 0
        Me.pnlSpace14.Reorder = True
        Me.pnlSpace14.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace14.TabIndex = 1
        '
        'dtfPrecioFranco
        '
        Me.dtfPrecioFranco.Allow_Empty = False
        Me.dtfPrecioFranco.Allow_Negative = True
        Me.dtfPrecioFranco.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfPrecioFranco.BackColor = System.Drawing.SystemColors.Control
        Me.dtfPrecioFranco.Data_Allowed = CustomControls.Datafield.List_Data.Libre
        Me.dtfPrecioFranco.DataField = "PFF"
        Me.dtfPrecioFranco.DataTable = "V1"
        Me.dtfPrecioFranco.Descripcion = "Precio Franco Fabrica"
        Me.dtfPrecioFranco.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfPrecioFranco.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfPrecioFranco.FocoEnAgregar = False
        Me.dtfPrecioFranco.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfPrecioFranco.Image = Nothing
        Me.dtfPrecioFranco.Label_Space = 140
        Me.dtfPrecioFranco.Length_Data = 32767
        Me.dtfPrecioFranco.Location = New System.Drawing.Point(0, 0)
        Me.dtfPrecioFranco.Max_Value = 0.0R
        Me.dtfPrecioFranco.MensajeIncorrectoCustom = Nothing
        Me.dtfPrecioFranco.Name = "dtfPrecioFranco"
        Me.dtfPrecioFranco.Null_on_Empty = True
        Me.dtfPrecioFranco.OpenForm = Nothing
        Me.dtfPrecioFranco.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfPrecioFranco.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfPrecioFranco.ReadOnly_Data = False
        Me.dtfPrecioFranco.Show_Button = False
        Me.dtfPrecioFranco.Size = New System.Drawing.Size(221, 26)
        Me.dtfPrecioFranco.TabIndex = 0
        Me.dtfPrecioFranco.Text_Data = "10000,00"
        Me.dtfPrecioFranco.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfPrecioFranco.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfPrecioFranco.TopPadding = 0
        Me.dtfPrecioFranco.Upper_Case = False
        Me.dtfPrecioFranco.Validate_on_lost_focus = True
        '
        'Panel7
        '
        Me.Panel7.Auto_Size = False
        Me.Panel7.BorderColor = System.Drawing.SystemColors.Control
        Me.Panel7.ChangeDock = True
        Me.Panel7.Control_Resize = False
        Me.Panel7.Controls.Add(Me.dtfTTransporte)
        Me.Panel7.Controls.Add(Me.pnlSpace3)
        Me.Panel7.Controls.Add(Me.dtfBonificacion)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel7.isSpace = False
        Me.Panel7.Location = New System.Drawing.Point(6, 122)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.numRows = 1
        Me.Panel7.Reorder = True
        Me.Panel7.Size = New System.Drawing.Size(550, 26)
        Me.Panel7.TabIndex = 4
        '
        'dtfTTransporte
        '
        Me.dtfTTransporte.Allow_Empty = False
        Me.dtfTTransporte.Allow_Negative = True
        Me.dtfTTransporte.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfTTransporte.BackColor = System.Drawing.SystemColors.Control
        Me.dtfTTransporte.Data_Allowed = CustomControls.Datafield.List_Data.Libre
        Me.dtfTTransporte.DataField = "TARTRANS"
        Me.dtfTTransporte.DataTable = "V1"
        Me.dtfTTransporte.Descripcion = "Tarjeta Transporte"
        Me.dtfTTransporte.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfTTransporte.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfTTransporte.FocoEnAgregar = False
        Me.dtfTTransporte.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfTTransporte.Image = Nothing
        Me.dtfTTransporte.Label_Space = 110
        Me.dtfTTransporte.Length_Data = 32767
        Me.dtfTTransporte.Location = New System.Drawing.Point(0, 0)
        Me.dtfTTransporte.Max_Value = 0.0R
        Me.dtfTTransporte.MensajeIncorrectoCustom = Nothing
        Me.dtfTTransporte.Name = "dtfTTransporte"
        Me.dtfTTransporte.Null_on_Empty = True
        Me.dtfTTransporte.OpenForm = Nothing
        Me.dtfTTransporte.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfTTransporte.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfTTransporte.ReadOnly_Data = False
        Me.dtfTTransporte.Show_Button = False
        Me.dtfTTransporte.Size = New System.Drawing.Size(364, 26)
        Me.dtfTTransporte.TabIndex = 0
        Me.dtfTTransporte.Text_Data = ""
        Me.dtfTTransporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfTTransporte.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfTTransporte.TopPadding = 0
        Me.dtfTTransporte.Upper_Case = False
        Me.dtfTTransporte.Validate_on_lost_focus = True
        '
        'pnlSpace3
        '
        Me.pnlSpace3.Auto_Size = False
        Me.pnlSpace3.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace3.ChangeDock = True
        Me.pnlSpace3.Control_Resize = False
        Me.pnlSpace3.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSpace3.isSpace = True
        Me.pnlSpace3.Location = New System.Drawing.Point(364, 0)
        Me.pnlSpace3.Name = "pnlSpace3"
        Me.pnlSpace3.numRows = 0
        Me.pnlSpace3.Reorder = True
        Me.pnlSpace3.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace3.TabIndex = 1
        '
        'dtfBonificacion
        '
        Me.dtfBonificacion.Allow_Empty = False
        Me.dtfBonificacion.Allow_Negative = True
        Me.dtfBonificacion.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfBonificacion.BackColor = System.Drawing.SystemColors.Control
        Me.dtfBonificacion.Data_Allowed = CustomControls.Datafield.List_Data.Libre
        Me.dtfBonificacion.DataField = "BONIFICA"
        Me.dtfBonificacion.DataTable = "V1"
        Me.dtfBonificacion.Descripcion = "Bonificación"
        Me.dtfBonificacion.Dock = System.Windows.Forms.DockStyle.Right
        Me.dtfBonificacion.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfBonificacion.FocoEnAgregar = False
        Me.dtfBonificacion.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfBonificacion.Image = Nothing
        Me.dtfBonificacion.Label_Space = 80
        Me.dtfBonificacion.Length_Data = 32767
        Me.dtfBonificacion.Location = New System.Drawing.Point(370, 0)
        Me.dtfBonificacion.Max_Value = 0.0R
        Me.dtfBonificacion.MensajeIncorrectoCustom = Nothing
        Me.dtfBonificacion.Name = "dtfBonificacion"
        Me.dtfBonificacion.Null_on_Empty = True
        Me.dtfBonificacion.OpenForm = Nothing
        Me.dtfBonificacion.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfBonificacion.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfBonificacion.ReadOnly_Data = False
        Me.dtfBonificacion.Show_Button = False
        Me.dtfBonificacion.Size = New System.Drawing.Size(180, 26)
        Me.dtfBonificacion.TabIndex = 2
        Me.dtfBonificacion.Text_Data = ""
        Me.dtfBonificacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfBonificacion.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfBonificacion.TopPadding = 0
        Me.dtfBonificacion.Upper_Case = False
        Me.dtfBonificacion.Validate_on_lost_focus = True
        '
        'pnlFechasCompra
        '
        Me.pnlFechasCompra.Auto_Size = False
        Me.pnlFechasCompra.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlFechasCompra.ChangeDock = True
        Me.pnlFechasCompra.Control_Resize = False
        Me.pnlFechasCompra.Controls.Add(Me.dtlMatriculacion)
        Me.pnlFechasCompra.Controls.Add(Me.pnlSpace4)
        Me.pnlFechasCompra.Controls.Add(Me.dtfNombre)
        Me.pnlFechasCompra.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFechasCompra.isSpace = False
        Me.pnlFechasCompra.Location = New System.Drawing.Point(6, 96)
        Me.pnlFechasCompra.Name = "pnlFechasCompra"
        Me.pnlFechasCompra.numRows = 1
        Me.pnlFechasCompra.Reorder = True
        Me.pnlFechasCompra.Size = New System.Drawing.Size(550, 26)
        Me.pnlFechasCompra.TabIndex = 3
        '
        'dtlMatriculacion
        '
        Me.dtlMatriculacion.Allow_Empty = True
        Me.dtlMatriculacion.DataField = "FMATRI"
        Me.dtlMatriculacion.DataTable = "V2"
        Me.dtlMatriculacion.Default_Value = New Date(2016, 4, 12, 0, 0, 0, 0)
        Me.dtlMatriculacion.Descripcion = "F. Matriculación"
        Me.dtlMatriculacion.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtlMatriculacion.FocoEnAgregar = False
        Me.dtlMatriculacion.Label_Space = 95
        Me.dtlMatriculacion.Location = New System.Drawing.Point(206, 0)
        Me.dtlMatriculacion.Max_Value = Nothing
        Me.dtlMatriculacion.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtlMatriculacion.MensajeIncorrectoCustom = Nothing
        Me.dtlMatriculacion.Min_Value = Nothing
        Me.dtlMatriculacion.MinDate = New Date(CType(0, Long))
        Me.dtlMatriculacion.MinimumSize = New System.Drawing.Size(185, 26)
        Me.dtlMatriculacion.Name = "dtlMatriculacion"
        Me.dtlMatriculacion.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtlMatriculacion.ReadOnly_Data = False
        Me.dtlMatriculacion.Size = New System.Drawing.Size(185, 26)
        Me.dtlMatriculacion.TabIndex = 2
        Me.dtlMatriculacion.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtlMatriculacion.Validate_on_lost_focus = True
        Me.dtlMatriculacion.Value_Data = New Date(2016, 4, 12, 0, 0, 0, 0)
        '
        'pnlSpace4
        '
        Me.pnlSpace4.Auto_Size = False
        Me.pnlSpace4.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace4.ChangeDock = True
        Me.pnlSpace4.Control_Resize = False
        Me.pnlSpace4.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace4.isSpace = True
        Me.pnlSpace4.Location = New System.Drawing.Point(200, 0)
        Me.pnlSpace4.Name = "pnlSpace4"
        Me.pnlSpace4.numRows = 0
        Me.pnlSpace4.Reorder = True
        Me.pnlSpace4.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace4.TabIndex = 1
        '
        'dtfNombre
        '
        Me.dtfNombre.Allow_Empty = False
        Me.dtfNombre.Allow_Negative = True
        Me.dtfNombre.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfNombre.BackColor = System.Drawing.SystemColors.Control
        Me.dtfNombre.Data_Allowed = CustomControls.Datafield.List_Data.Libre
        Me.dtfNombre.DataField = "MATRI2"
        Me.dtfNombre.DataTable = "V2"
        Me.dtfNombre.Descripcion = "Matrícula anterior"
        Me.dtfNombre.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfNombre.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfNombre.FocoEnAgregar = False
        Me.dtfNombre.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfNombre.Image = Nothing
        Me.dtfNombre.Label_Space = 110
        Me.dtfNombre.Length_Data = 32767
        Me.dtfNombre.Location = New System.Drawing.Point(0, 0)
        Me.dtfNombre.Max_Value = 0.0R
        Me.dtfNombre.MensajeIncorrectoCustom = Nothing
        Me.dtfNombre.Name = "dtfNombre"
        Me.dtfNombre.Null_on_Empty = True
        Me.dtfNombre.OpenForm = Nothing
        Me.dtfNombre.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfNombre.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfNombre.ReadOnly_Data = False
        Me.dtfNombre.Show_Button = False
        Me.dtfNombre.Size = New System.Drawing.Size(200, 26)
        Me.dtfNombre.TabIndex = 0
        Me.dtfNombre.Text_Data = "1234 abc"
        Me.dtfNombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfNombre.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfNombre.TopPadding = 0
        Me.dtfNombre.Upper_Case = False
        Me.dtfNombre.Validate_on_lost_focus = True
        '
        'pnlFormaPago
        '
        Me.pnlFormaPago.Auto_Size = False
        Me.pnlFormaPago.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlFormaPago.ChangeDock = True
        Me.pnlFormaPago.Control_Resize = False
        Me.pnlFormaPago.Controls.Add(Me.dtlFechaCompra)
        Me.pnlFormaPago.Controls.Add(Me.pnlSpace12)
        Me.pnlFormaPago.Controls.Add(Me.dtfPrecio)
        Me.pnlFormaPago.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFormaPago.isSpace = False
        Me.pnlFormaPago.Location = New System.Drawing.Point(6, 70)
        Me.pnlFormaPago.Name = "pnlFormaPago"
        Me.pnlFormaPago.numRows = 1
        Me.pnlFormaPago.Reorder = True
        Me.pnlFormaPago.Size = New System.Drawing.Size(550, 26)
        Me.pnlFormaPago.TabIndex = 2
        '
        'dtlFechaCompra
        '
        Me.dtlFechaCompra.Allow_Empty = True
        Me.dtlFechaCompra.DataField = "FECCOMPRA"
        Me.dtlFechaCompra.DataTable = "V2"
        Me.dtlFechaCompra.Default_Value = New Date(2016, 4, 12, 0, 0, 0, 0)
        Me.dtlFechaCompra.Descripcion = "Fecha Compra"
        Me.dtlFechaCompra.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtlFechaCompra.FocoEnAgregar = False
        Me.dtlFechaCompra.Label_Space = 95
        Me.dtlFechaCompra.Location = New System.Drawing.Point(206, 0)
        Me.dtlFechaCompra.Max_Value = Nothing
        Me.dtlFechaCompra.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtlFechaCompra.MensajeIncorrectoCustom = Nothing
        Me.dtlFechaCompra.Min_Value = Nothing
        Me.dtlFechaCompra.MinDate = New Date(CType(0, Long))
        Me.dtlFechaCompra.MinimumSize = New System.Drawing.Size(185, 26)
        Me.dtlFechaCompra.Name = "dtlFechaCompra"
        Me.dtlFechaCompra.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtlFechaCompra.ReadOnly_Data = False
        Me.dtlFechaCompra.Size = New System.Drawing.Size(185, 26)
        Me.dtlFechaCompra.TabIndex = 2
        Me.dtlFechaCompra.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtlFechaCompra.Validate_on_lost_focus = True
        Me.dtlFechaCompra.Value_Data = New Date(2016, 4, 12, 0, 0, 0, 0)
        '
        'pnlSpace12
        '
        Me.pnlSpace12.Auto_Size = False
        Me.pnlSpace12.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace12.ChangeDock = True
        Me.pnlSpace12.Control_Resize = False
        Me.pnlSpace12.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace12.isSpace = True
        Me.pnlSpace12.Location = New System.Drawing.Point(200, 0)
        Me.pnlSpace12.Name = "pnlSpace12"
        Me.pnlSpace12.numRows = 0
        Me.pnlSpace12.Reorder = True
        Me.pnlSpace12.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace12.TabIndex = 1
        '
        'dtfPrecio
        '
        Me.dtfPrecio.Allow_Empty = False
        Me.dtfPrecio.Allow_Negative = True
        Me.dtfPrecio.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfPrecio.BackColor = System.Drawing.SystemColors.Control
        Me.dtfPrecio.Data_Allowed = CustomControls.Datafield.List_Data.Libre
        Me.dtfPrecio.DataField = "COSTE"
        Me.dtfPrecio.DataTable = "V2"
        Me.dtfPrecio.Descripcion = "Precio Compra"
        Me.dtfPrecio.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfPrecio.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfPrecio.FocoEnAgregar = False
        Me.dtfPrecio.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfPrecio.Image = Nothing
        Me.dtfPrecio.Label_Space = 110
        Me.dtfPrecio.Length_Data = 32767
        Me.dtfPrecio.Location = New System.Drawing.Point(0, 0)
        Me.dtfPrecio.Max_Value = 0.0R
        Me.dtfPrecio.MensajeIncorrectoCustom = Nothing
        Me.dtfPrecio.Name = "dtfPrecio"
        Me.dtfPrecio.Null_on_Empty = True
        Me.dtfPrecio.OpenForm = Nothing
        Me.dtfPrecio.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfPrecio.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfPrecio.ReadOnly_Data = False
        Me.dtfPrecio.Show_Button = False
        Me.dtfPrecio.Size = New System.Drawing.Size(200, 26)
        Me.dtfPrecio.TabIndex = 0
        Me.dtfPrecio.Text_Data = ""
        Me.dtfPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfPrecio.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfPrecio.TopPadding = 0
        Me.dtfPrecio.Upper_Case = False
        Me.dtfPrecio.Validate_on_lost_focus = True
        '
        'pnlPreciosCompra
        '
        Me.pnlPreciosCompra.Auto_Size = False
        Me.pnlPreciosCompra.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlPreciosCompra.ChangeDock = True
        Me.pnlPreciosCompra.Control_Resize = False
        Me.pnlPreciosCompra.Controls.Add(Me.dtfFormaPagoCompra)
        Me.pnlPreciosCompra.Controls.Add(Me.pnlSpace13)
        Me.pnlPreciosCompra.Controls.Add(Me.dtfFacturaN)
        Me.pnlPreciosCompra.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlPreciosCompra.isSpace = False
        Me.pnlPreciosCompra.Location = New System.Drawing.Point(6, 44)
        Me.pnlPreciosCompra.Name = "pnlPreciosCompra"
        Me.pnlPreciosCompra.numRows = 1
        Me.pnlPreciosCompra.Reorder = True
        Me.pnlPreciosCompra.Size = New System.Drawing.Size(550, 26)
        Me.pnlPreciosCompra.TabIndex = 1
        '
        'dtfFormaPagoCompra
        '
        Me.dtfFormaPagoCompra.Allow_Empty = True
        Me.dtfFormaPagoCompra.Allow_Negative = True
        Me.dtfFormaPagoCompra.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfFormaPagoCompra.BackColor = System.Drawing.SystemColors.Control
        Me.dtfFormaPagoCompra.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfFormaPagoCompra.DataField = "FORPAGOCO"
        Me.dtfFormaPagoCompra.DataTable = "V2"
        Me.dtfFormaPagoCompra.DB = Connection20
        Me.dtfFormaPagoCompra.Desc_Datafield = "NOMBRE"
        Me.dtfFormaPagoCompra.Desc_DBPK = "CODIGO"
        Me.dtfFormaPagoCompra.Desc_DBTable = "FORPRO"
        Me.dtfFormaPagoCompra.Desc_Where = Nothing
        Me.dtfFormaPagoCompra.Desc_WhereObligatoria = Nothing
        Me.dtfFormaPagoCompra.Descripcion = "Forma de Pago"
        Me.dtfFormaPagoCompra.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfFormaPagoCompra.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfFormaPagoCompra.ExtraSQL = ""
        Me.dtfFormaPagoCompra.FocoEnAgregar = False
        Me.dtfFormaPagoCompra.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfFormaPagoCompra.Formulario = Nothing
        Me.dtfFormaPagoCompra.Label_Space = 95
        Me.dtfFormaPagoCompra.Length_Data = 32767
        Me.dtfFormaPagoCompra.Location = New System.Drawing.Point(206, 0)
        Me.dtfFormaPagoCompra.Lupa = Nothing
        Me.dtfFormaPagoCompra.Max_Value = 0.0R
        Me.dtfFormaPagoCompra.MensajeIncorrectoCustom = Nothing
        Me.dtfFormaPagoCompra.Name = "dtfFormaPagoCompra"
        Me.dtfFormaPagoCompra.Null_on_Empty = True
        Me.dtfFormaPagoCompra.OpenForm = Nothing
        Me.dtfFormaPagoCompra.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfFormaPagoCompra.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfFormaPagoCompra.Query_on_Text_Changed = True
        Me.dtfFormaPagoCompra.ReadOnly_Data = False
        Me.dtfFormaPagoCompra.ReQuery = False
        Me.dtfFormaPagoCompra.ShowButton = True
        Me.dtfFormaPagoCompra.Size = New System.Drawing.Size(344, 26)
        Me.dtfFormaPagoCompra.TabIndex = 2
        Me.dtfFormaPagoCompra.Text_Data = ""
        Me.dtfFormaPagoCompra.Text_Data_Desc = ""
        Me.dtfFormaPagoCompra.Text_Width = 40
        Me.dtfFormaPagoCompra.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfFormaPagoCompra.TopPadding = 0
        Me.dtfFormaPagoCompra.Upper_Case = False
        Me.dtfFormaPagoCompra.Validate_on_lost_focus = True
        '
        'pnlSpace13
        '
        Me.pnlSpace13.Auto_Size = False
        Me.pnlSpace13.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace13.ChangeDock = True
        Me.pnlSpace13.Control_Resize = False
        Me.pnlSpace13.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace13.isSpace = True
        Me.pnlSpace13.Location = New System.Drawing.Point(200, 0)
        Me.pnlSpace13.Name = "pnlSpace13"
        Me.pnlSpace13.numRows = 0
        Me.pnlSpace13.Reorder = True
        Me.pnlSpace13.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace13.TabIndex = 1
        '
        'dtfFacturaN
        '
        Me.dtfFacturaN.Allow_Empty = False
        Me.dtfFacturaN.Allow_Negative = True
        Me.dtfFacturaN.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfFacturaN.BackColor = System.Drawing.SystemColors.Control
        Me.dtfFacturaN.Data_Allowed = CustomControls.Datafield.List_Data.Libre
        Me.dtfFacturaN.DataField = "COMPRAFRA"
        Me.dtfFacturaN.DataTable = "V1"
        Me.dtfFacturaN.Descripcion = "Número Factura"
        Me.dtfFacturaN.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfFacturaN.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfFacturaN.FocoEnAgregar = False
        Me.dtfFacturaN.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfFacturaN.Image = Nothing
        Me.dtfFacturaN.Label_Space = 110
        Me.dtfFacturaN.Length_Data = 32767
        Me.dtfFacturaN.Location = New System.Drawing.Point(0, 0)
        Me.dtfFacturaN.Max_Value = 0.0R
        Me.dtfFacturaN.MensajeIncorrectoCustom = Nothing
        Me.dtfFacturaN.Name = "dtfFacturaN"
        Me.dtfFacturaN.Null_on_Empty = True
        Me.dtfFacturaN.OpenForm = Nothing
        Me.dtfFacturaN.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfFacturaN.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfFacturaN.ReadOnly_Data = False
        Me.dtfFacturaN.Show_Button = False
        Me.dtfFacturaN.Size = New System.Drawing.Size(200, 26)
        Me.dtfFacturaN.TabIndex = 0
        Me.dtfFacturaN.Text_Data = ""
        Me.dtfFacturaN.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfFacturaN.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfFacturaN.TopPadding = 0
        Me.dtfFacturaN.Upper_Case = False
        Me.dtfFacturaN.Validate_on_lost_focus = True
        '
        'dtfProveedor
        '
        Me.dtfProveedor.Allow_Empty = True
        Me.dtfProveedor.Allow_Negative = True
        Me.dtfProveedor.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfProveedor.BackColor = System.Drawing.SystemColors.Control
        Me.dtfProveedor.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfProveedor.DataField = "proveedor"
        Me.dtfProveedor.DataTable = "V1"
        Me.dtfProveedor.DB = Connection21
        Me.dtfProveedor.Desc_Datafield = "NOMBRE"
        Me.dtfProveedor.Desc_DBPK = "NUM_PROVEE"
        Me.dtfProveedor.Desc_DBTable = "provee1"
        Me.dtfProveedor.Desc_Where = Nothing
        Me.dtfProveedor.Desc_WhereObligatoria = Nothing
        Me.dtfProveedor.Descripcion = "Proveedor"
        Me.dtfProveedor.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfProveedor.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfProveedor.ExtraSQL = ""
        Me.dtfProveedor.FocoEnAgregar = False
        Me.dtfProveedor.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfProveedor.Formulario = Nothing
        Me.dtfProveedor.Label_Space = 110
        Me.dtfProveedor.Length_Data = 32767
        Me.dtfProveedor.Location = New System.Drawing.Point(6, 18)
        Me.dtfProveedor.Lupa = Nothing
        Me.dtfProveedor.Max_Value = 0.0R
        Me.dtfProveedor.MensajeIncorrectoCustom = Nothing
        Me.dtfProveedor.Name = "dtfProveedor"
        Me.dtfProveedor.Null_on_Empty = True
        Me.dtfProveedor.OpenForm = Nothing
        Me.dtfProveedor.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfProveedor.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfProveedor.Query_on_Text_Changed = True
        Me.dtfProveedor.ReadOnly_Data = False
        Me.dtfProveedor.ReQuery = False
        Me.dtfProveedor.ShowButton = True
        Me.dtfProveedor.Size = New System.Drawing.Size(550, 26)
        Me.dtfProveedor.TabIndex = 0
        Me.dtfProveedor.Text_Data = ""
        Me.dtfProveedor.Text_Data_Desc = ""
        Me.dtfProveedor.Text_Width = 90
        Me.dtfProveedor.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfProveedor.TopPadding = 0
        Me.dtfProveedor.Upper_Case = False
        Me.dtfProveedor.Validate_on_lost_focus = True
        '
        'pnlCabeceraCV
        '
        Me.pnlCabeceraCV.Auto_Size = False
        Me.pnlCabeceraCV.BackColor = System.Drawing.Color.RosyBrown
        Me.pnlCabeceraCV.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlCabeceraCV.ChangeDock = False
        Me.pnlCabeceraCV.Control_Resize = False
        Me.pnlCabeceraCV.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCabeceraCV.isSpace = False
        Me.pnlCabeceraCV.Location = New System.Drawing.Point(0, 0)
        Me.pnlCabeceraCV.Name = "pnlCabeceraCV"
        Me.pnlCabeceraCV.numRows = 0
        Me.pnlCabeceraCV.Reorder = True
        Me.pnlCabeceraCV.Size = New System.Drawing.Size(1138, 88)
        Me.pnlCabeceraCV.TabIndex = 2
        '
        'pvpFichaTecnica
        '
        Me.pvpFichaTecnica.Controls.Add(Me.ftvVehi)
        Me.pvpFichaTecnica.Controls.Add(Me.pnlGenFichaTec)
        Me.pvpFichaTecnica.ItemSize = New System.Drawing.SizeF(102.0!, 23.0!)
        Me.pvpFichaTecnica.Location = New System.Drawing.Point(129, 5)
        Me.pvpFichaTecnica.Name = "pvpFichaTecnica"
        Me.pvpFichaTecnica.PanelCabezeraContainer = Me.pnlGenFichaTec
        Me.pvpFichaTecnica.Size = New System.Drawing.Size(1138, 500)
        Me.pvpFichaTecnica.Text = "Ficha Técnica"
        '
        'ftvVehi
        '
        Me.ftvVehi.DataTable = "V2"
        Me.ftvVehi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ftvVehi.Location = New System.Drawing.Point(0, 88)
        Me.ftvVehi.Name = "ftvVehi"
        Me.ftvVehi.Size = New System.Drawing.Size(1138, 412)
        Me.ftvVehi.TabIndex = 2
        '
        'pnlGenFichaTec
        '
        Me.pnlGenFichaTec.Auto_Size = False
        Me.pnlGenFichaTec.BackColor = System.Drawing.Color.RosyBrown
        Me.pnlGenFichaTec.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlGenFichaTec.ChangeDock = False
        Me.pnlGenFichaTec.Control_Resize = False
        Me.pnlGenFichaTec.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlGenFichaTec.isSpace = False
        Me.pnlGenFichaTec.Location = New System.Drawing.Point(0, 0)
        Me.pnlGenFichaTec.Name = "pnlGenFichaTec"
        Me.pnlGenFichaTec.numRows = 0
        Me.pnlGenFichaTec.Reorder = True
        Me.pnlGenFichaTec.Size = New System.Drawing.Size(1138, 88)
        Me.pnlGenFichaTec.TabIndex = 1
        '
        'pvpseguros
        '
        Me.pvpseguros.Controls.Add(Me.Panel37)
        Me.pvpseguros.Controls.Add(Me.pnlIzqSeguro)
        Me.pvpseguros.Controls.Add(Me.pnlCabeceraSeguro)
        Me.pvpseguros.ItemSize = New System.Drawing.SizeF(102.0!, 23.0!)
        Me.pvpseguros.Location = New System.Drawing.Point(129, 5)
        Me.pvpseguros.Name = "pvpseguros"
        Me.pvpseguros.PanelCabezeraContainer = Me.pnlCabeceraSeguro
        Me.pvpseguros.Size = New System.Drawing.Size(1138, 500)
        Me.pvpseguros.Text = "Seguros"
        '
        'Panel37
        '
        Me.Panel37.Auto_Size = False
        Me.Panel37.BorderColor = System.Drawing.SystemColors.Control
        Me.Panel37.ChangeDock = True
        Me.Panel37.Control_Resize = False
        Me.Panel37.Controls.Add(Me.Panel64)
        Me.Panel37.Controls.Add(Me.gbxSegAd3)
        Me.Panel37.Controls.Add(Me.gbxSegAd2)
        Me.Panel37.Controls.Add(Me.gbxSegAd1)
        Me.Panel37.Controls.Add(Me.gbxOtrosDSeg)
        Me.Panel37.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel37.isSpace = False
        Me.Panel37.Location = New System.Drawing.Point(568, 88)
        Me.Panel37.MinimumSize = New System.Drawing.Size(467, 0)
        Me.Panel37.Name = "Panel37"
        Me.Panel37.numRows = 0
        Me.Panel37.Padding = New System.Windows.Forms.Padding(3)
        Me.Panel37.Reorder = True
        '
        '
        '
        Me.Panel37.RootElement.MinSize = New System.Drawing.Size(467, 0)
        Me.Panel37.Size = New System.Drawing.Size(568, 412)
        Me.Panel37.TabIndex = 4
        '
        'Panel64
        '
        Me.Panel64.Auto_Size = False
        Me.Panel64.BorderColor = System.Drawing.SystemColors.Control
        Me.Panel64.ChangeDock = True
        Me.Panel64.Control_Resize = False
        Me.Panel64.Controls.Add(Me.btnParteAmis)
        Me.Panel64.Controls.Add(Me.Panel65)
        Me.Panel64.Controls.Add(Me.btnHistorico)
        Me.Panel64.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel64.isSpace = False
        Me.Panel64.Location = New System.Drawing.Point(3, 381)
        Me.Panel64.Name = "Panel64"
        Me.Panel64.numRows = 1
        Me.Panel64.Reorder = True
        Me.Panel64.Size = New System.Drawing.Size(562, 26)
        Me.Panel64.TabIndex = 4
        '
        'btnParteAmis
        '
        Me.btnParteAmis.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnParteAmis.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnParteAmis.Location = New System.Drawing.Point(159, 0)
        Me.btnParteAmis.Name = "btnParteAmis"
        Me.btnParteAmis.Size = New System.Drawing.Size(100, 26)
        Me.btnParteAmis.TabIndex = 2
        Me.btnParteAmis.Text = "Parte Amistoso"
        Me.btnParteAmis.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.btnParteAmis.ThemeName = "Windows8"
        '
        'Panel65
        '
        Me.Panel65.Auto_Size = False
        Me.Panel65.BorderColor = System.Drawing.SystemColors.Control
        Me.Panel65.ChangeDock = True
        Me.Panel65.Control_Resize = False
        Me.Panel65.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel65.isSpace = True
        Me.Panel65.Location = New System.Drawing.Point(153, 0)
        Me.Panel65.Name = "Panel65"
        Me.Panel65.numRows = 0
        Me.Panel65.Reorder = True
        Me.Panel65.Size = New System.Drawing.Size(6, 26)
        Me.Panel65.TabIndex = 1
        '
        'btnHistorico
        '
        Me.btnHistorico.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnHistorico.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnHistorico.Location = New System.Drawing.Point(0, 0)
        Me.btnHistorico.Name = "btnHistorico"
        Me.btnHistorico.Size = New System.Drawing.Size(153, 26)
        Me.btnHistorico.TabIndex = 0
        Me.btnHistorico.Text = "Ver Histórico de Seguros"
        Me.btnHistorico.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.btnHistorico.ThemeName = "Windows8"
        '
        'gbxSegAd3
        '
        Me.gbxSegAd3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.gbxSegAd3.Controls.Add(Me.pnlSupSA3inf)
        Me.gbxSegAd3.Controls.Add(Me.pnlSupSA3mid)
        Me.gbxSegAd3.Controls.Add(Me.pnlSupSA3top)
        Me.gbxSegAd3.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbxSegAd3.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.gbxSegAd3.HeaderText = "Poliza Asistencia Adicional"
        Me.gbxSegAd3.Location = New System.Drawing.Point(3, 276)
        Me.gbxSegAd3.Name = "gbxSegAd3"
        Me.gbxSegAd3.numRows = 0
        Me.gbxSegAd3.Padding = New System.Windows.Forms.Padding(6, 18, 6, 6)
        Me.gbxSegAd3.Reorder = True
        Me.gbxSegAd3.Size = New System.Drawing.Size(562, 105)
        Me.gbxSegAd3.TabIndex = 3
        Me.gbxSegAd3.Text = "Poliza Asistencia Adicional"
        Me.gbxSegAd3.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.gbxSegAd3.ThemeName = "Windows8"
        Me.gbxSegAd3.Title = "Poliza Asistencia Adicional"
        '
        'pnlSupSA3inf
        '
        Me.pnlSupSA3inf.Auto_Size = False
        Me.pnlSupSA3inf.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSupSA3inf.ChangeDock = True
        Me.pnlSupSA3inf.Control_Resize = False
        Me.pnlSupSA3inf.Controls.Add(Me.Panel58)
        Me.pnlSupSA3inf.Controls.Add(Me.dtlVencimientoSA2)
        Me.pnlSupSA3inf.Controls.Add(Me.pnlSpace30)
        Me.pnlSupSA3inf.Controls.Add(Me.dtlFechaAltaSA2)
        Me.pnlSupSA3inf.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlSupSA3inf.isSpace = False
        Me.pnlSupSA3inf.Location = New System.Drawing.Point(6, 70)
        Me.pnlSupSA3inf.Name = "pnlSupSA3inf"
        Me.pnlSupSA3inf.numRows = 1
        Me.pnlSupSA3inf.Reorder = True
        Me.pnlSupSA3inf.Size = New System.Drawing.Size(550, 26)
        Me.pnlSupSA3inf.TabIndex = 2
        '
        'Panel58
        '
        Me.Panel58.Auto_Size = False
        Me.Panel58.BorderColor = System.Drawing.SystemColors.Control
        Me.Panel58.ChangeDock = True
        Me.Panel58.Control_Resize = False
        Me.Panel58.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel58.isSpace = True
        Me.Panel58.Location = New System.Drawing.Point(376, 0)
        Me.Panel58.Name = "Panel58"
        Me.Panel58.numRows = 0
        Me.Panel58.Reorder = True
        Me.Panel58.Size = New System.Drawing.Size(6, 26)
        Me.Panel58.TabIndex = 3
        '
        'dtlVencimientoSA2
        '
        Me.dtlVencimientoSA2.Allow_Empty = True
        Me.dtlVencimientoSA2.DataField = "VTOADA2"
        Me.dtlVencimientoSA2.DataTable = "V1"
        Me.dtlVencimientoSA2.Default_Value = New Date(2016, 4, 12, 0, 0, 0, 0)
        Me.dtlVencimientoSA2.Descripcion = "Fecha Vencimiento"
        Me.dtlVencimientoSA2.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtlVencimientoSA2.FocoEnAgregar = False
        Me.dtlVencimientoSA2.Label_Space = 115
        Me.dtlVencimientoSA2.Location = New System.Drawing.Point(166, 0)
        Me.dtlVencimientoSA2.Max_Value = Nothing
        Me.dtlVencimientoSA2.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtlVencimientoSA2.MensajeIncorrectoCustom = Nothing
        Me.dtlVencimientoSA2.Min_Value = Nothing
        Me.dtlVencimientoSA2.MinDate = New Date(CType(0, Long))
        Me.dtlVencimientoSA2.MinimumSize = New System.Drawing.Size(205, 26)
        Me.dtlVencimientoSA2.Name = "dtlVencimientoSA2"
        Me.dtlVencimientoSA2.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtlVencimientoSA2.ReadOnly_Data = False
        Me.dtlVencimientoSA2.Size = New System.Drawing.Size(210, 26)
        Me.dtlVencimientoSA2.TabIndex = 2
        Me.dtlVencimientoSA2.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtlVencimientoSA2.Validate_on_lost_focus = True
        Me.dtlVencimientoSA2.Value_Data = New Date(2016, 4, 12, 0, 0, 0, 0)
        '
        'pnlSpace30
        '
        Me.pnlSpace30.Auto_Size = False
        Me.pnlSpace30.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace30.ChangeDock = True
        Me.pnlSpace30.Control_Resize = False
        Me.pnlSpace30.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace30.isSpace = True
        Me.pnlSpace30.Location = New System.Drawing.Point(160, 0)
        Me.pnlSpace30.Name = "pnlSpace30"
        Me.pnlSpace30.numRows = 0
        Me.pnlSpace30.Reorder = True
        Me.pnlSpace30.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace30.TabIndex = 1
        '
        'dtlFechaAltaSA2
        '
        Me.dtlFechaAltaSA2.Allow_Empty = True
        Me.dtlFechaAltaSA2.DataField = "ALTAADA2"
        Me.dtlFechaAltaSA2.DataTable = "V2"
        Me.dtlFechaAltaSA2.Default_Value = New Date(2016, 4, 12, 0, 0, 0, 0)
        Me.dtlFechaAltaSA2.Descripcion = "Fecha Alta"
        Me.dtlFechaAltaSA2.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtlFechaAltaSA2.FocoEnAgregar = False
        Me.dtlFechaAltaSA2.Label_Space = 70
        Me.dtlFechaAltaSA2.Location = New System.Drawing.Point(0, 0)
        Me.dtlFechaAltaSA2.Max_Value = Nothing
        Me.dtlFechaAltaSA2.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtlFechaAltaSA2.MensajeIncorrectoCustom = Nothing
        Me.dtlFechaAltaSA2.Min_Value = Nothing
        Me.dtlFechaAltaSA2.MinDate = New Date(CType(0, Long))
        Me.dtlFechaAltaSA2.MinimumSize = New System.Drawing.Size(160, 26)
        Me.dtlFechaAltaSA2.Name = "dtlFechaAltaSA2"
        Me.dtlFechaAltaSA2.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtlFechaAltaSA2.ReadOnly_Data = False
        Me.dtlFechaAltaSA2.Size = New System.Drawing.Size(160, 26)
        Me.dtlFechaAltaSA2.TabIndex = 0
        Me.dtlFechaAltaSA2.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtlFechaAltaSA2.Validate_on_lost_focus = True
        Me.dtlFechaAltaSA2.Value_Data = New Date(2016, 4, 12, 0, 0, 0, 0)
        '
        'pnlSupSA3mid
        '
        Me.pnlSupSA3mid.Auto_Size = False
        Me.pnlSupSA3mid.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSupSA3mid.ChangeDock = True
        Me.pnlSupSA3mid.Control_Resize = False
        Me.pnlSupSA3mid.Controls.Add(Me.dtfTelefAssistSA2)
        Me.pnlSupSA3mid.Controls.Add(Me.pnlSpace29)
        Me.pnlSupSA3mid.Controls.Add(Me.dtfImporteSA2)
        Me.pnlSupSA3mid.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlSupSA3mid.isSpace = False
        Me.pnlSupSA3mid.Location = New System.Drawing.Point(6, 44)
        Me.pnlSupSA3mid.Name = "pnlSupSA3mid"
        Me.pnlSupSA3mid.numRows = 1
        Me.pnlSupSA3mid.Reorder = True
        '
        '
        '
        Me.pnlSupSA3mid.RootElement.MinSize = New System.Drawing.Size(0, 0)
        Me.pnlSupSA3mid.Size = New System.Drawing.Size(550, 26)
        Me.pnlSupSA3mid.TabIndex = 1
        '
        'dtfTelefAssistSA2
        '
        Me.dtfTelefAssistSA2.Allow_Empty = False
        Me.dtfTelefAssistSA2.Allow_Negative = True
        Me.dtfTelefAssistSA2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfTelefAssistSA2.BackColor = System.Drawing.SystemColors.Control
        Me.dtfTelefAssistSA2.Data_Allowed = CustomControls.Datafield.List_Data.Libre
        Me.dtfTelefAssistSA2.DataField = ""
        Me.dtfTelefAssistSA2.DataTable = ""
        Me.dtfTelefAssistSA2.Descripcion = "Teléf. Assist."
        Me.dtfTelefAssistSA2.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfTelefAssistSA2.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfTelefAssistSA2.FocoEnAgregar = False
        Me.dtfTelefAssistSA2.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfTelefAssistSA2.Image = Nothing
        Me.dtfTelefAssistSA2.Label_Space = 80
        Me.dtfTelefAssistSA2.Length_Data = 32767
        Me.dtfTelefAssistSA2.Location = New System.Drawing.Point(154, 0)
        Me.dtfTelefAssistSA2.Max_Value = 0.0R
        Me.dtfTelefAssistSA2.MensajeIncorrectoCustom = Nothing
        Me.dtfTelefAssistSA2.Name = "dtfTelefAssistSA2"
        Me.dtfTelefAssistSA2.Null_on_Empty = True
        Me.dtfTelefAssistSA2.OpenForm = Nothing
        Me.dtfTelefAssistSA2.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfTelefAssistSA2.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfTelefAssistSA2.ReadOnly_Data = False
        Me.dtfTelefAssistSA2.Show_Button = False
        Me.dtfTelefAssistSA2.Size = New System.Drawing.Size(178, 26)
        Me.dtfTelefAssistSA2.TabIndex = 2
        Me.dtfTelefAssistSA2.Text_Data = ""
        Me.dtfTelefAssistSA2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfTelefAssistSA2.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfTelefAssistSA2.TopPadding = 0
        Me.dtfTelefAssistSA2.Upper_Case = False
        Me.dtfTelefAssistSA2.Validate_on_lost_focus = True
        '
        'pnlSpace29
        '
        Me.pnlSpace29.Auto_Size = False
        Me.pnlSpace29.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace29.ChangeDock = True
        Me.pnlSpace29.Control_Resize = False
        Me.pnlSpace29.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace29.isSpace = True
        Me.pnlSpace29.Location = New System.Drawing.Point(148, 0)
        Me.pnlSpace29.Name = "pnlSpace29"
        Me.pnlSpace29.numRows = 0
        Me.pnlSpace29.Reorder = True
        Me.pnlSpace29.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace29.TabIndex = 1
        '
        'dtfImporteSA2
        '
        Me.dtfImporteSA2.Allow_Empty = True
        Me.dtfImporteSA2.Allow_Negative = True
        Me.dtfImporteSA2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfImporteSA2.BackColor = System.Drawing.SystemColors.Control
        Me.dtfImporteSA2.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfImporteSA2.DataField = "IMPADA2"
        Me.dtfImporteSA2.DataTable = "V1"
        Me.dtfImporteSA2.Descripcion = "Importe"
        Me.dtfImporteSA2.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfImporteSA2.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfImporteSA2.FocoEnAgregar = False
        Me.dtfImporteSA2.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfImporteSA2.Image = Nothing
        Me.dtfImporteSA2.Label_Space = 60
        Me.dtfImporteSA2.Length_Data = 32767
        Me.dtfImporteSA2.Location = New System.Drawing.Point(0, 0)
        Me.dtfImporteSA2.Max_Value = 0.0R
        Me.dtfImporteSA2.MensajeIncorrectoCustom = Nothing
        Me.dtfImporteSA2.Name = "dtfImporteSA2"
        Me.dtfImporteSA2.Null_on_Empty = True
        Me.dtfImporteSA2.OpenForm = Nothing
        Me.dtfImporteSA2.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfImporteSA2.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfImporteSA2.ReadOnly_Data = False
        Me.dtfImporteSA2.Show_Button = False
        Me.dtfImporteSA2.Size = New System.Drawing.Size(148, 26)
        Me.dtfImporteSA2.TabIndex = 0
        Me.dtfImporteSA2.Text_Data = ""
        Me.dtfImporteSA2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfImporteSA2.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfImporteSA2.TopPadding = 0
        Me.dtfImporteSA2.Upper_Case = False
        Me.dtfImporteSA2.Validate_on_lost_focus = True
        '
        'pnlSupSA3top
        '
        Me.pnlSupSA3top.Auto_Size = False
        Me.pnlSupSA3top.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSupSA3top.ChangeDock = True
        Me.pnlSupSA3top.Control_Resize = False
        Me.pnlSupSA3top.Controls.Add(Me.dtfCompañiaSA2)
        Me.pnlSupSA3top.Controls.Add(Me.pnlSpace28)
        Me.pnlSupSA3top.Controls.Add(Me.dtfPolizaSA2)
        Me.pnlSupSA3top.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlSupSA3top.isSpace = False
        Me.pnlSupSA3top.Location = New System.Drawing.Point(6, 18)
        Me.pnlSupSA3top.Name = "pnlSupSA3top"
        Me.pnlSupSA3top.numRows = 1
        Me.pnlSupSA3top.Reorder = True
        '
        '
        '
        Me.pnlSupSA3top.RootElement.MinSize = New System.Drawing.Size(0, 0)
        Me.pnlSupSA3top.Size = New System.Drawing.Size(550, 26)
        Me.pnlSupSA3top.TabIndex = 0
        '
        'dtfCompañiaSA2
        '
        Me.dtfCompañiaSA2.Allow_Empty = True
        Me.dtfCompañiaSA2.Allow_Negative = True
        Me.dtfCompañiaSA2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfCompañiaSA2.BackColor = System.Drawing.SystemColors.Control
        Me.dtfCompañiaSA2.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfCompañiaSA2.DataField = "CIAADA2"
        Me.dtfCompañiaSA2.DataTable = "V1"
        Me.dtfCompañiaSA2.DB = Connection10
        Me.dtfCompañiaSA2.Desc_Datafield = "NOMBRE"
        Me.dtfCompañiaSA2.Desc_DBPK = "NUM_PROVEE"
        Me.dtfCompañiaSA2.Desc_DBTable = "PROVEE1"
        Me.dtfCompañiaSA2.Desc_Where = Nothing
        Me.dtfCompañiaSA2.Desc_WhereObligatoria = Nothing
        Me.dtfCompañiaSA2.Descripcion = "Compañía"
        Me.dtfCompañiaSA2.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfCompañiaSA2.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfCompañiaSA2.ExtraSQL = ""
        Me.dtfCompañiaSA2.FocoEnAgregar = False
        Me.dtfCompañiaSA2.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfCompañiaSA2.Formulario = Nothing
        Me.dtfCompañiaSA2.Label_Space = 60
        Me.dtfCompañiaSA2.Length_Data = 32767
        Me.dtfCompañiaSA2.Location = New System.Drawing.Point(0, 0)
        Me.dtfCompañiaSA2.Lupa = Nothing
        Me.dtfCompañiaSA2.Max_Value = 0.0R
        Me.dtfCompañiaSA2.MensajeIncorrectoCustom = Nothing
        Me.dtfCompañiaSA2.Name = "dtfCompañiaSA2"
        Me.dtfCompañiaSA2.Null_on_Empty = True
        Me.dtfCompañiaSA2.OpenForm = Nothing
        Me.dtfCompañiaSA2.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfCompañiaSA2.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfCompañiaSA2.Query_on_Text_Changed = True
        Me.dtfCompañiaSA2.ReadOnly_Data = False
        Me.dtfCompañiaSA2.ReQuery = True
        Me.dtfCompañiaSA2.ShowButton = True
        Me.dtfCompañiaSA2.Size = New System.Drawing.Size(380, 26)
        Me.dtfCompañiaSA2.TabIndex = 0
        Me.dtfCompañiaSA2.Text_Data = ""
        Me.dtfCompañiaSA2.Text_Data_Desc = ""
        Me.dtfCompañiaSA2.Text_Width = 60
        Me.dtfCompañiaSA2.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfCompañiaSA2.TopPadding = 0
        Me.dtfCompañiaSA2.Upper_Case = False
        Me.dtfCompañiaSA2.Validate_on_lost_focus = True
        '
        'pnlSpace28
        '
        Me.pnlSpace28.Auto_Size = False
        Me.pnlSpace28.BackColor = System.Drawing.Color.Red
        Me.pnlSpace28.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace28.ChangeDock = True
        Me.pnlSpace28.Control_Resize = False
        Me.pnlSpace28.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSpace28.isSpace = True
        Me.pnlSpace28.Location = New System.Drawing.Point(380, 0)
        Me.pnlSpace28.Name = "pnlSpace28"
        Me.pnlSpace28.numRows = 0
        Me.pnlSpace28.Reorder = True
        Me.pnlSpace28.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace28.TabIndex = 1
        '
        'dtfPolizaSA2
        '
        Me.dtfPolizaSA2.Allow_Empty = False
        Me.dtfPolizaSA2.Allow_Negative = True
        Me.dtfPolizaSA2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfPolizaSA2.BackColor = System.Drawing.SystemColors.Control
        Me.dtfPolizaSA2.Data_Allowed = CustomControls.Datafield.List_Data.Libre
        Me.dtfPolizaSA2.DataField = "ADA2"
        Me.dtfPolizaSA2.DataTable = "V1"
        Me.dtfPolizaSA2.Descripcion = "Póliza"
        Me.dtfPolizaSA2.Dock = System.Windows.Forms.DockStyle.Right
        Me.dtfPolizaSA2.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfPolizaSA2.FocoEnAgregar = False
        Me.dtfPolizaSA2.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfPolizaSA2.Image = Nothing
        Me.dtfPolizaSA2.Label_Space = 35
        Me.dtfPolizaSA2.Length_Data = 32767
        Me.dtfPolizaSA2.Location = New System.Drawing.Point(386, 0)
        Me.dtfPolizaSA2.Max_Value = 0.0R
        Me.dtfPolizaSA2.MensajeIncorrectoCustom = Nothing
        Me.dtfPolizaSA2.Name = "dtfPolizaSA2"
        Me.dtfPolizaSA2.Null_on_Empty = True
        Me.dtfPolizaSA2.OpenForm = Nothing
        Me.dtfPolizaSA2.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfPolizaSA2.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfPolizaSA2.ReadOnly_Data = False
        Me.dtfPolizaSA2.Show_Button = False
        Me.dtfPolizaSA2.Size = New System.Drawing.Size(164, 26)
        Me.dtfPolizaSA2.TabIndex = 2
        Me.dtfPolizaSA2.Text_Data = ""
        Me.dtfPolizaSA2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfPolizaSA2.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfPolizaSA2.TopPadding = 0
        Me.dtfPolizaSA2.Upper_Case = False
        Me.dtfPolizaSA2.Validate_on_lost_focus = True
        '
        'gbxSegAd2
        '
        Me.gbxSegAd2.AccessibleName = ""
        Me.gbxSegAd2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.gbxSegAd2.Controls.Add(Me.pnlSupSA2inf)
        Me.gbxSegAd2.Controls.Add(Me.pnlSupSA2mid)
        Me.gbxSegAd2.Controls.Add(Me.pnlSupSA2top)
        Me.gbxSegAd2.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbxSegAd2.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.gbxSegAd2.HeaderText = "Asistencia"
        Me.gbxSegAd2.Location = New System.Drawing.Point(3, 181)
        Me.gbxSegAd2.Name = "gbxSegAd2"
        Me.gbxSegAd2.numRows = 0
        Me.gbxSegAd2.Padding = New System.Windows.Forms.Padding(6, 18, 6, 6)
        Me.gbxSegAd2.Reorder = True
        Me.gbxSegAd2.Size = New System.Drawing.Size(562, 95)
        Me.gbxSegAd2.TabIndex = 2
        Me.gbxSegAd2.Text = "Asistencia"
        Me.gbxSegAd2.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.gbxSegAd2.ThemeName = "Windows8"
        Me.gbxSegAd2.Title = "Asistencia"
        '
        'pnlSupSA2inf
        '
        Me.pnlSupSA2inf.Auto_Size = False
        Me.pnlSupSA2inf.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSupSA2inf.ChangeDock = True
        Me.pnlSupSA2inf.Control_Resize = False
        Me.pnlSupSA2inf.Controls.Add(Me.Panel51)
        Me.pnlSupSA2inf.Controls.Add(Me.dtlVencimientoSA)
        Me.pnlSupSA2inf.Controls.Add(Me.pnlSpace27)
        Me.pnlSupSA2inf.Controls.Add(Me.dtlFechaAltaSA)
        Me.pnlSupSA2inf.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlSupSA2inf.isSpace = False
        Me.pnlSupSA2inf.Location = New System.Drawing.Point(6, 70)
        Me.pnlSupSA2inf.Name = "pnlSupSA2inf"
        Me.pnlSupSA2inf.numRows = 1
        Me.pnlSupSA2inf.Reorder = True
        Me.pnlSupSA2inf.Size = New System.Drawing.Size(550, 22)
        Me.pnlSupSA2inf.TabIndex = 2
        '
        'Panel51
        '
        Me.Panel51.Auto_Size = False
        Me.Panel51.BorderColor = System.Drawing.SystemColors.Control
        Me.Panel51.ChangeDock = True
        Me.Panel51.Control_Resize = False
        Me.Panel51.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel51.isSpace = True
        Me.Panel51.Location = New System.Drawing.Point(376, 0)
        Me.Panel51.Name = "Panel51"
        Me.Panel51.numRows = 0
        Me.Panel51.Reorder = True
        Me.Panel51.Size = New System.Drawing.Size(6, 22)
        Me.Panel51.TabIndex = 3
        '
        'dtlVencimientoSA
        '
        Me.dtlVencimientoSA.Allow_Empty = True
        Me.dtlVencimientoSA.DataField = "VTOADA"
        Me.dtlVencimientoSA.DataTable = "V2"
        Me.dtlVencimientoSA.Default_Value = New Date(2016, 4, 12, 0, 0, 0, 0)
        Me.dtlVencimientoSA.Descripcion = "Fecha Vencimiento"
        Me.dtlVencimientoSA.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtlVencimientoSA.FocoEnAgregar = False
        Me.dtlVencimientoSA.Label_Space = 115
        Me.dtlVencimientoSA.Location = New System.Drawing.Point(166, 0)
        Me.dtlVencimientoSA.Max_Value = Nothing
        Me.dtlVencimientoSA.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtlVencimientoSA.MensajeIncorrectoCustom = Nothing
        Me.dtlVencimientoSA.Min_Value = Nothing
        Me.dtlVencimientoSA.MinDate = New Date(CType(0, Long))
        Me.dtlVencimientoSA.MinimumSize = New System.Drawing.Size(205, 26)
        Me.dtlVencimientoSA.Name = "dtlVencimientoSA"
        Me.dtlVencimientoSA.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtlVencimientoSA.ReadOnly_Data = False
        Me.dtlVencimientoSA.Size = New System.Drawing.Size(210, 26)
        Me.dtlVencimientoSA.TabIndex = 2
        Me.dtlVencimientoSA.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtlVencimientoSA.Validate_on_lost_focus = True
        Me.dtlVencimientoSA.Value_Data = New Date(2016, 4, 12, 0, 0, 0, 0)
        '
        'pnlSpace27
        '
        Me.pnlSpace27.Auto_Size = False
        Me.pnlSpace27.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace27.ChangeDock = True
        Me.pnlSpace27.Control_Resize = False
        Me.pnlSpace27.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace27.isSpace = True
        Me.pnlSpace27.Location = New System.Drawing.Point(160, 0)
        Me.pnlSpace27.Name = "pnlSpace27"
        Me.pnlSpace27.numRows = 0
        Me.pnlSpace27.Reorder = True
        Me.pnlSpace27.Size = New System.Drawing.Size(6, 22)
        Me.pnlSpace27.TabIndex = 1
        '
        'dtlFechaAltaSA
        '
        Me.dtlFechaAltaSA.Allow_Empty = True
        Me.dtlFechaAltaSA.DataField = "ALTAADA"
        Me.dtlFechaAltaSA.DataTable = "V2"
        Me.dtlFechaAltaSA.Default_Value = New Date(2016, 4, 12, 0, 0, 0, 0)
        Me.dtlFechaAltaSA.Descripcion = "Fecha Alta"
        Me.dtlFechaAltaSA.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtlFechaAltaSA.FocoEnAgregar = False
        Me.dtlFechaAltaSA.Label_Space = 70
        Me.dtlFechaAltaSA.Location = New System.Drawing.Point(0, 0)
        Me.dtlFechaAltaSA.Max_Value = Nothing
        Me.dtlFechaAltaSA.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtlFechaAltaSA.MensajeIncorrectoCustom = Nothing
        Me.dtlFechaAltaSA.Min_Value = Nothing
        Me.dtlFechaAltaSA.MinDate = New Date(CType(0, Long))
        Me.dtlFechaAltaSA.MinimumSize = New System.Drawing.Size(160, 26)
        Me.dtlFechaAltaSA.Name = "dtlFechaAltaSA"
        Me.dtlFechaAltaSA.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtlFechaAltaSA.ReadOnly_Data = False
        Me.dtlFechaAltaSA.Size = New System.Drawing.Size(160, 26)
        Me.dtlFechaAltaSA.TabIndex = 0
        Me.dtlFechaAltaSA.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtlFechaAltaSA.Validate_on_lost_focus = True
        Me.dtlFechaAltaSA.Value_Data = New Date(2016, 4, 12, 0, 0, 0, 0)
        '
        'pnlSupSA2mid
        '
        Me.pnlSupSA2mid.Auto_Size = False
        Me.pnlSupSA2mid.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSupSA2mid.ChangeDock = True
        Me.pnlSupSA2mid.Control_Resize = False
        Me.pnlSupSA2mid.Controls.Add(Me.dtfTelefAssistSA)
        Me.pnlSupSA2mid.Controls.Add(Me.pnlSpace26)
        Me.pnlSupSA2mid.Controls.Add(Me.dtfImporteSA)
        Me.pnlSupSA2mid.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlSupSA2mid.isSpace = False
        Me.pnlSupSA2mid.Location = New System.Drawing.Point(6, 44)
        Me.pnlSupSA2mid.Name = "pnlSupSA2mid"
        Me.pnlSupSA2mid.numRows = 1
        Me.pnlSupSA2mid.Reorder = True
        '
        '
        '
        Me.pnlSupSA2mid.RootElement.MinSize = New System.Drawing.Size(0, 0)
        Me.pnlSupSA2mid.Size = New System.Drawing.Size(550, 26)
        Me.pnlSupSA2mid.TabIndex = 1
        '
        'dtfTelefAssistSA
        '
        Me.dtfTelefAssistSA.Allow_Empty = False
        Me.dtfTelefAssistSA.Allow_Negative = True
        Me.dtfTelefAssistSA.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfTelefAssistSA.BackColor = System.Drawing.SystemColors.Control
        Me.dtfTelefAssistSA.Data_Allowed = CustomControls.Datafield.List_Data.Libre
        Me.dtfTelefAssistSA.DataField = ""
        Me.dtfTelefAssistSA.DataTable = ""
        Me.dtfTelefAssistSA.Descripcion = "Teléf. Assist."
        Me.dtfTelefAssistSA.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfTelefAssistSA.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfTelefAssistSA.FocoEnAgregar = False
        Me.dtfTelefAssistSA.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfTelefAssistSA.Image = Nothing
        Me.dtfTelefAssistSA.Label_Space = 80
        Me.dtfTelefAssistSA.Length_Data = 32767
        Me.dtfTelefAssistSA.Location = New System.Drawing.Point(154, 0)
        Me.dtfTelefAssistSA.Max_Value = 0.0R
        Me.dtfTelefAssistSA.MensajeIncorrectoCustom = Nothing
        Me.dtfTelefAssistSA.Name = "dtfTelefAssistSA"
        Me.dtfTelefAssistSA.Null_on_Empty = True
        Me.dtfTelefAssistSA.OpenForm = Nothing
        Me.dtfTelefAssistSA.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfTelefAssistSA.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfTelefAssistSA.ReadOnly_Data = False
        Me.dtfTelefAssistSA.Show_Button = False
        Me.dtfTelefAssistSA.Size = New System.Drawing.Size(178, 26)
        Me.dtfTelefAssistSA.TabIndex = 2
        Me.dtfTelefAssistSA.Text_Data = ""
        Me.dtfTelefAssistSA.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfTelefAssistSA.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfTelefAssistSA.TopPadding = 0
        Me.dtfTelefAssistSA.Upper_Case = False
        Me.dtfTelefAssistSA.Validate_on_lost_focus = True
        '
        'pnlSpace26
        '
        Me.pnlSpace26.Auto_Size = False
        Me.pnlSpace26.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace26.ChangeDock = True
        Me.pnlSpace26.Control_Resize = False
        Me.pnlSpace26.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace26.isSpace = True
        Me.pnlSpace26.Location = New System.Drawing.Point(148, 0)
        Me.pnlSpace26.Name = "pnlSpace26"
        Me.pnlSpace26.numRows = 0
        Me.pnlSpace26.Reorder = True
        Me.pnlSpace26.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace26.TabIndex = 1
        '
        'dtfImporteSA
        '
        Me.dtfImporteSA.Allow_Empty = True
        Me.dtfImporteSA.Allow_Negative = True
        Me.dtfImporteSA.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfImporteSA.BackColor = System.Drawing.SystemColors.Control
        Me.dtfImporteSA.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfImporteSA.DataField = "IMPADA"
        Me.dtfImporteSA.DataTable = "V2"
        Me.dtfImporteSA.Descripcion = "Importe"
        Me.dtfImporteSA.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfImporteSA.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfImporteSA.FocoEnAgregar = False
        Me.dtfImporteSA.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfImporteSA.Image = Nothing
        Me.dtfImporteSA.Label_Space = 60
        Me.dtfImporteSA.Length_Data = 32767
        Me.dtfImporteSA.Location = New System.Drawing.Point(0, 0)
        Me.dtfImporteSA.Max_Value = 0.0R
        Me.dtfImporteSA.MensajeIncorrectoCustom = Nothing
        Me.dtfImporteSA.Name = "dtfImporteSA"
        Me.dtfImporteSA.Null_on_Empty = True
        Me.dtfImporteSA.OpenForm = Nothing
        Me.dtfImporteSA.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfImporteSA.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfImporteSA.ReadOnly_Data = False
        Me.dtfImporteSA.Show_Button = False
        Me.dtfImporteSA.Size = New System.Drawing.Size(148, 26)
        Me.dtfImporteSA.TabIndex = 0
        Me.dtfImporteSA.Text_Data = ""
        Me.dtfImporteSA.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfImporteSA.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfImporteSA.TopPadding = 0
        Me.dtfImporteSA.Upper_Case = False
        Me.dtfImporteSA.Validate_on_lost_focus = True
        '
        'pnlSupSA2top
        '
        Me.pnlSupSA2top.Auto_Size = False
        Me.pnlSupSA2top.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSupSA2top.ChangeDock = True
        Me.pnlSupSA2top.Control_Resize = False
        Me.pnlSupSA2top.Controls.Add(Me.dtfCompañiaSA)
        Me.pnlSupSA2top.Controls.Add(Me.pnlSpace25)
        Me.pnlSupSA2top.Controls.Add(Me.dtfPolizaSA)
        Me.pnlSupSA2top.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlSupSA2top.isSpace = False
        Me.pnlSupSA2top.Location = New System.Drawing.Point(6, 18)
        Me.pnlSupSA2top.Name = "pnlSupSA2top"
        Me.pnlSupSA2top.numRows = 1
        Me.pnlSupSA2top.Reorder = True
        '
        '
        '
        Me.pnlSupSA2top.RootElement.MinSize = New System.Drawing.Size(0, 0)
        Me.pnlSupSA2top.Size = New System.Drawing.Size(550, 26)
        Me.pnlSupSA2top.TabIndex = 0
        '
        'dtfCompañiaSA
        '
        Me.dtfCompañiaSA.Allow_Empty = True
        Me.dtfCompañiaSA.Allow_Negative = True
        Me.dtfCompañiaSA.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfCompañiaSA.BackColor = System.Drawing.SystemColors.Control
        Me.dtfCompañiaSA.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfCompañiaSA.DataField = "CIAADA"
        Me.dtfCompañiaSA.DataTable = "V1"
        Me.dtfCompañiaSA.DB = Connection11
        Me.dtfCompañiaSA.Desc_Datafield = "NOMBRE"
        Me.dtfCompañiaSA.Desc_DBPK = "NUM_PROVEE"
        Me.dtfCompañiaSA.Desc_DBTable = "PROVEE1"
        Me.dtfCompañiaSA.Desc_Where = Nothing
        Me.dtfCompañiaSA.Desc_WhereObligatoria = Nothing
        Me.dtfCompañiaSA.Descripcion = "Compañía"
        Me.dtfCompañiaSA.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfCompañiaSA.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfCompañiaSA.ExtraSQL = ""
        Me.dtfCompañiaSA.FocoEnAgregar = False
        Me.dtfCompañiaSA.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfCompañiaSA.Formulario = Nothing
        Me.dtfCompañiaSA.Label_Space = 60
        Me.dtfCompañiaSA.Length_Data = 32767
        Me.dtfCompañiaSA.Location = New System.Drawing.Point(0, 0)
        Me.dtfCompañiaSA.Lupa = Nothing
        Me.dtfCompañiaSA.Max_Value = 0.0R
        Me.dtfCompañiaSA.MensajeIncorrectoCustom = Nothing
        Me.dtfCompañiaSA.Name = "dtfCompañiaSA"
        Me.dtfCompañiaSA.Null_on_Empty = True
        Me.dtfCompañiaSA.OpenForm = Nothing
        Me.dtfCompañiaSA.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfCompañiaSA.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfCompañiaSA.Query_on_Text_Changed = True
        Me.dtfCompañiaSA.ReadOnly_Data = False
        Me.dtfCompañiaSA.ReQuery = True
        Me.dtfCompañiaSA.ShowButton = True
        Me.dtfCompañiaSA.Size = New System.Drawing.Size(380, 26)
        Me.dtfCompañiaSA.TabIndex = 0
        Me.dtfCompañiaSA.Text_Data = ""
        Me.dtfCompañiaSA.Text_Data_Desc = ""
        Me.dtfCompañiaSA.Text_Width = 60
        Me.dtfCompañiaSA.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfCompañiaSA.TopPadding = 0
        Me.dtfCompañiaSA.Upper_Case = False
        Me.dtfCompañiaSA.Validate_on_lost_focus = True
        '
        'pnlSpace25
        '
        Me.pnlSpace25.Auto_Size = False
        Me.pnlSpace25.BackColor = System.Drawing.Color.Red
        Me.pnlSpace25.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace25.ChangeDock = True
        Me.pnlSpace25.Control_Resize = False
        Me.pnlSpace25.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSpace25.isSpace = True
        Me.pnlSpace25.Location = New System.Drawing.Point(380, 0)
        Me.pnlSpace25.Name = "pnlSpace25"
        Me.pnlSpace25.numRows = 0
        Me.pnlSpace25.Reorder = True
        Me.pnlSpace25.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace25.TabIndex = 1
        '
        'dtfPolizaSA
        '
        Me.dtfPolizaSA.Allow_Empty = False
        Me.dtfPolizaSA.Allow_Negative = True
        Me.dtfPolizaSA.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfPolizaSA.BackColor = System.Drawing.SystemColors.Control
        Me.dtfPolizaSA.Data_Allowed = CustomControls.Datafield.List_Data.Libre
        Me.dtfPolizaSA.DataField = "ADA"
        Me.dtfPolizaSA.DataTable = "V2"
        Me.dtfPolizaSA.Descripcion = "Póliza"
        Me.dtfPolizaSA.Dock = System.Windows.Forms.DockStyle.Right
        Me.dtfPolizaSA.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfPolizaSA.FocoEnAgregar = False
        Me.dtfPolizaSA.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfPolizaSA.Image = Nothing
        Me.dtfPolizaSA.Label_Space = 35
        Me.dtfPolizaSA.Length_Data = 32767
        Me.dtfPolizaSA.Location = New System.Drawing.Point(386, 0)
        Me.dtfPolizaSA.Max_Value = 0.0R
        Me.dtfPolizaSA.MensajeIncorrectoCustom = Nothing
        Me.dtfPolizaSA.Name = "dtfPolizaSA"
        Me.dtfPolizaSA.Null_on_Empty = True
        Me.dtfPolizaSA.OpenForm = Nothing
        Me.dtfPolizaSA.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfPolizaSA.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfPolizaSA.ReadOnly_Data = False
        Me.dtfPolizaSA.Show_Button = False
        Me.dtfPolizaSA.Size = New System.Drawing.Size(164, 26)
        Me.dtfPolizaSA.TabIndex = 2
        Me.dtfPolizaSA.Text_Data = ""
        Me.dtfPolizaSA.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfPolizaSA.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfPolizaSA.TopPadding = 0
        Me.dtfPolizaSA.Upper_Case = False
        Me.dtfPolizaSA.Validate_on_lost_focus = True
        '
        'gbxSegAd1
        '
        Me.gbxSegAd1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.gbxSegAd1.Controls.Add(Me.pnlSupSA1inf)
        Me.gbxSegAd1.Controls.Add(Me.pnlSupSA1mid)
        Me.gbxSegAd1.Controls.Add(Me.pnlSupSA1top)
        Me.gbxSegAd1.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbxSegAd1.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.gbxSegAd1.HeaderText = "Seguro Adicional"
        Me.gbxSegAd1.Location = New System.Drawing.Point(3, 80)
        Me.gbxSegAd1.Name = "gbxSegAd1"
        Me.gbxSegAd1.numRows = 0
        Me.gbxSegAd1.Padding = New System.Windows.Forms.Padding(6, 18, 6, 6)
        Me.gbxSegAd1.Reorder = True
        Me.gbxSegAd1.Size = New System.Drawing.Size(562, 101)
        Me.gbxSegAd1.TabIndex = 1
        Me.gbxSegAd1.Text = "Seguro Adicional"
        Me.gbxSegAd1.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.gbxSegAd1.ThemeName = "Windows8"
        Me.gbxSegAd1.Title = "Seguro Adicional"
        '
        'pnlSupSA1inf
        '
        Me.pnlSupSA1inf.Auto_Size = False
        Me.pnlSupSA1inf.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSupSA1inf.ChangeDock = True
        Me.pnlSupSA1inf.Control_Resize = False
        Me.pnlSupSA1inf.Controls.Add(Me.Panel48)
        Me.pnlSupSA1inf.Controls.Add(Me.dtlVencimientoSA3)
        Me.pnlSupSA1inf.Controls.Add(Me.pnlSpace24)
        Me.pnlSupSA1inf.Controls.Add(Me.dtlFechaAltaSA3)
        Me.pnlSupSA1inf.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlSupSA1inf.isSpace = False
        Me.pnlSupSA1inf.Location = New System.Drawing.Point(6, 70)
        Me.pnlSupSA1inf.Name = "pnlSupSA1inf"
        Me.pnlSupSA1inf.numRows = 1
        Me.pnlSupSA1inf.Reorder = True
        Me.pnlSupSA1inf.Size = New System.Drawing.Size(550, 26)
        Me.pnlSupSA1inf.TabIndex = 2
        '
        'Panel48
        '
        Me.Panel48.Auto_Size = False
        Me.Panel48.BorderColor = System.Drawing.SystemColors.Control
        Me.Panel48.ChangeDock = True
        Me.Panel48.Control_Resize = False
        Me.Panel48.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel48.isSpace = True
        Me.Panel48.Location = New System.Drawing.Point(376, 0)
        Me.Panel48.Name = "Panel48"
        Me.Panel48.numRows = 0
        Me.Panel48.Reorder = True
        Me.Panel48.Size = New System.Drawing.Size(6, 26)
        Me.Panel48.TabIndex = 3
        '
        'dtlVencimientoSA3
        '
        Me.dtlVencimientoSA3.Allow_Empty = True
        Me.dtlVencimientoSA3.DataField = "VTOADA3"
        Me.dtlVencimientoSA3.DataTable = "V2"
        Me.dtlVencimientoSA3.Default_Value = New Date(2016, 4, 12, 0, 0, 0, 0)
        Me.dtlVencimientoSA3.Descripcion = "Fecha Vencimiento"
        Me.dtlVencimientoSA3.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtlVencimientoSA3.FocoEnAgregar = False
        Me.dtlVencimientoSA3.Label_Space = 115
        Me.dtlVencimientoSA3.Location = New System.Drawing.Point(166, 0)
        Me.dtlVencimientoSA3.Max_Value = Nothing
        Me.dtlVencimientoSA3.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtlVencimientoSA3.MensajeIncorrectoCustom = Nothing
        Me.dtlVencimientoSA3.Min_Value = Nothing
        Me.dtlVencimientoSA3.MinDate = New Date(CType(0, Long))
        Me.dtlVencimientoSA3.MinimumSize = New System.Drawing.Size(205, 26)
        Me.dtlVencimientoSA3.Name = "dtlVencimientoSA3"
        Me.dtlVencimientoSA3.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtlVencimientoSA3.ReadOnly_Data = False
        Me.dtlVencimientoSA3.Size = New System.Drawing.Size(210, 26)
        Me.dtlVencimientoSA3.TabIndex = 2
        Me.dtlVencimientoSA3.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtlVencimientoSA3.Validate_on_lost_focus = True
        Me.dtlVencimientoSA3.Value_Data = New Date(2016, 4, 12, 0, 0, 0, 0)
        '
        'pnlSpace24
        '
        Me.pnlSpace24.Auto_Size = False
        Me.pnlSpace24.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace24.ChangeDock = True
        Me.pnlSpace24.Control_Resize = False
        Me.pnlSpace24.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace24.isSpace = True
        Me.pnlSpace24.Location = New System.Drawing.Point(160, 0)
        Me.pnlSpace24.Name = "pnlSpace24"
        Me.pnlSpace24.numRows = 0
        Me.pnlSpace24.Reorder = True
        Me.pnlSpace24.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace24.TabIndex = 1
        '
        'dtlFechaAltaSA3
        '
        Me.dtlFechaAltaSA3.Allow_Empty = True
        Me.dtlFechaAltaSA3.DataField = "ALTAADA3"
        Me.dtlFechaAltaSA3.DataTable = "V2"
        Me.dtlFechaAltaSA3.Default_Value = New Date(2016, 4, 12, 0, 0, 0, 0)
        Me.dtlFechaAltaSA3.Descripcion = "Fecha Alta"
        Me.dtlFechaAltaSA3.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtlFechaAltaSA3.FocoEnAgregar = False
        Me.dtlFechaAltaSA3.Label_Space = 70
        Me.dtlFechaAltaSA3.Location = New System.Drawing.Point(0, 0)
        Me.dtlFechaAltaSA3.Max_Value = Nothing
        Me.dtlFechaAltaSA3.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtlFechaAltaSA3.MensajeIncorrectoCustom = Nothing
        Me.dtlFechaAltaSA3.Min_Value = Nothing
        Me.dtlFechaAltaSA3.MinDate = New Date(CType(0, Long))
        Me.dtlFechaAltaSA3.MinimumSize = New System.Drawing.Size(160, 26)
        Me.dtlFechaAltaSA3.Name = "dtlFechaAltaSA3"
        Me.dtlFechaAltaSA3.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtlFechaAltaSA3.ReadOnly_Data = False
        Me.dtlFechaAltaSA3.Size = New System.Drawing.Size(160, 26)
        Me.dtlFechaAltaSA3.TabIndex = 0
        Me.dtlFechaAltaSA3.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtlFechaAltaSA3.Validate_on_lost_focus = True
        Me.dtlFechaAltaSA3.Value_Data = New Date(2016, 4, 12, 0, 0, 0, 0)
        '
        'pnlSupSA1mid
        '
        Me.pnlSupSA1mid.Auto_Size = False
        Me.pnlSupSA1mid.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSupSA1mid.ChangeDock = True
        Me.pnlSupSA1mid.Control_Resize = False
        Me.pnlSupSA1mid.Controls.Add(Me.dtfTelefAssistSA3)
        Me.pnlSupSA1mid.Controls.Add(Me.pnlSpace23)
        Me.pnlSupSA1mid.Controls.Add(Me.dtfImporteSA3)
        Me.pnlSupSA1mid.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlSupSA1mid.isSpace = False
        Me.pnlSupSA1mid.Location = New System.Drawing.Point(6, 44)
        Me.pnlSupSA1mid.Name = "pnlSupSA1mid"
        Me.pnlSupSA1mid.numRows = 1
        Me.pnlSupSA1mid.Reorder = True
        '
        '
        '
        Me.pnlSupSA1mid.RootElement.MinSize = New System.Drawing.Size(0, 0)
        Me.pnlSupSA1mid.Size = New System.Drawing.Size(550, 26)
        Me.pnlSupSA1mid.TabIndex = 1
        '
        'dtfTelefAssistSA3
        '
        Me.dtfTelefAssistSA3.Allow_Empty = False
        Me.dtfTelefAssistSA3.Allow_Negative = True
        Me.dtfTelefAssistSA3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfTelefAssistSA3.BackColor = System.Drawing.SystemColors.Control
        Me.dtfTelefAssistSA3.Data_Allowed = CustomControls.Datafield.List_Data.Libre
        Me.dtfTelefAssistSA3.DataField = ""
        Me.dtfTelefAssistSA3.DataTable = ""
        Me.dtfTelefAssistSA3.Descripcion = "Teléf. Assist."
        Me.dtfTelefAssistSA3.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfTelefAssistSA3.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfTelefAssistSA3.FocoEnAgregar = False
        Me.dtfTelefAssistSA3.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfTelefAssistSA3.Image = Nothing
        Me.dtfTelefAssistSA3.Label_Space = 80
        Me.dtfTelefAssistSA3.Length_Data = 32767
        Me.dtfTelefAssistSA3.Location = New System.Drawing.Point(154, 0)
        Me.dtfTelefAssistSA3.Max_Value = 0.0R
        Me.dtfTelefAssistSA3.MensajeIncorrectoCustom = Nothing
        Me.dtfTelefAssistSA3.Name = "dtfTelefAssistSA3"
        Me.dtfTelefAssistSA3.Null_on_Empty = True
        Me.dtfTelefAssistSA3.OpenForm = Nothing
        Me.dtfTelefAssistSA3.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfTelefAssistSA3.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfTelefAssistSA3.ReadOnly_Data = False
        Me.dtfTelefAssistSA3.Show_Button = False
        Me.dtfTelefAssistSA3.Size = New System.Drawing.Size(178, 26)
        Me.dtfTelefAssistSA3.TabIndex = 2
        Me.dtfTelefAssistSA3.Text_Data = ""
        Me.dtfTelefAssistSA3.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfTelefAssistSA3.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfTelefAssistSA3.TopPadding = 0
        Me.dtfTelefAssistSA3.Upper_Case = False
        Me.dtfTelefAssistSA3.Validate_on_lost_focus = True
        '
        'pnlSpace23
        '
        Me.pnlSpace23.Auto_Size = False
        Me.pnlSpace23.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace23.ChangeDock = True
        Me.pnlSpace23.Control_Resize = False
        Me.pnlSpace23.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace23.isSpace = True
        Me.pnlSpace23.Location = New System.Drawing.Point(148, 0)
        Me.pnlSpace23.Name = "pnlSpace23"
        Me.pnlSpace23.numRows = 0
        Me.pnlSpace23.Reorder = True
        Me.pnlSpace23.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace23.TabIndex = 1
        '
        'dtfImporteSA3
        '
        Me.dtfImporteSA3.Allow_Empty = True
        Me.dtfImporteSA3.Allow_Negative = True
        Me.dtfImporteSA3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfImporteSA3.BackColor = System.Drawing.SystemColors.Control
        Me.dtfImporteSA3.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfImporteSA3.DataField = "IMPADA3"
        Me.dtfImporteSA3.DataTable = "V2"
        Me.dtfImporteSA3.Descripcion = "Importe"
        Me.dtfImporteSA3.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfImporteSA3.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfImporteSA3.FocoEnAgregar = False
        Me.dtfImporteSA3.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfImporteSA3.Image = Nothing
        Me.dtfImporteSA3.Label_Space = 60
        Me.dtfImporteSA3.Length_Data = 32767
        Me.dtfImporteSA3.Location = New System.Drawing.Point(0, 0)
        Me.dtfImporteSA3.Max_Value = 0.0R
        Me.dtfImporteSA3.MensajeIncorrectoCustom = Nothing
        Me.dtfImporteSA3.Name = "dtfImporteSA3"
        Me.dtfImporteSA3.Null_on_Empty = True
        Me.dtfImporteSA3.OpenForm = Nothing
        Me.dtfImporteSA3.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfImporteSA3.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfImporteSA3.ReadOnly_Data = False
        Me.dtfImporteSA3.Show_Button = False
        Me.dtfImporteSA3.Size = New System.Drawing.Size(148, 26)
        Me.dtfImporteSA3.TabIndex = 0
        Me.dtfImporteSA3.Text_Data = ""
        Me.dtfImporteSA3.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfImporteSA3.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfImporteSA3.TopPadding = 0
        Me.dtfImporteSA3.Upper_Case = False
        Me.dtfImporteSA3.Validate_on_lost_focus = True
        '
        'pnlSupSA1top
        '
        Me.pnlSupSA1top.AccessibleName = "pnlSpace24"
        Me.pnlSupSA1top.Auto_Size = False
        Me.pnlSupSA1top.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSupSA1top.ChangeDock = True
        Me.pnlSupSA1top.Control_Resize = False
        Me.pnlSupSA1top.Controls.Add(Me.dtfCompañiaSA3)
        Me.pnlSupSA1top.Controls.Add(Me.pnlSpace22)
        Me.pnlSupSA1top.Controls.Add(Me.dtfPolizaSA3)
        Me.pnlSupSA1top.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlSupSA1top.isSpace = False
        Me.pnlSupSA1top.Location = New System.Drawing.Point(6, 18)
        Me.pnlSupSA1top.Name = "pnlSupSA1top"
        Me.pnlSupSA1top.numRows = 1
        Me.pnlSupSA1top.Reorder = True
        '
        '
        '
        Me.pnlSupSA1top.RootElement.MinSize = New System.Drawing.Size(0, 0)
        Me.pnlSupSA1top.Size = New System.Drawing.Size(550, 26)
        Me.pnlSupSA1top.TabIndex = 0
        '
        'dtfCompañiaSA3
        '
        Me.dtfCompañiaSA3.Allow_Empty = True
        Me.dtfCompañiaSA3.Allow_Negative = True
        Me.dtfCompañiaSA3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfCompañiaSA3.BackColor = System.Drawing.SystemColors.Control
        Me.dtfCompañiaSA3.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfCompañiaSA3.DataField = "CIAADA3"
        Me.dtfCompañiaSA3.DataTable = "V1"
        Me.dtfCompañiaSA3.DB = Connection12
        Me.dtfCompañiaSA3.Desc_Datafield = "NOMBRE"
        Me.dtfCompañiaSA3.Desc_DBPK = "NUM_PROVEE"
        Me.dtfCompañiaSA3.Desc_DBTable = "PROVEE1"
        Me.dtfCompañiaSA3.Desc_Where = Nothing
        Me.dtfCompañiaSA3.Desc_WhereObligatoria = Nothing
        Me.dtfCompañiaSA3.Descripcion = "Compañía"
        Me.dtfCompañiaSA3.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfCompañiaSA3.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfCompañiaSA3.ExtraSQL = ""
        Me.dtfCompañiaSA3.FocoEnAgregar = False
        Me.dtfCompañiaSA3.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfCompañiaSA3.Formulario = Nothing
        Me.dtfCompañiaSA3.Label_Space = 60
        Me.dtfCompañiaSA3.Length_Data = 32767
        Me.dtfCompañiaSA3.Location = New System.Drawing.Point(0, 0)
        Me.dtfCompañiaSA3.Lupa = Nothing
        Me.dtfCompañiaSA3.Max_Value = 0.0R
        Me.dtfCompañiaSA3.MensajeIncorrectoCustom = Nothing
        Me.dtfCompañiaSA3.Name = "dtfCompañiaSA3"
        Me.dtfCompañiaSA3.Null_on_Empty = True
        Me.dtfCompañiaSA3.OpenForm = Nothing
        Me.dtfCompañiaSA3.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfCompañiaSA3.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfCompañiaSA3.Query_on_Text_Changed = True
        Me.dtfCompañiaSA3.ReadOnly_Data = False
        Me.dtfCompañiaSA3.ReQuery = True
        Me.dtfCompañiaSA3.ShowButton = True
        Me.dtfCompañiaSA3.Size = New System.Drawing.Size(380, 26)
        Me.dtfCompañiaSA3.TabIndex = 0
        Me.dtfCompañiaSA3.Text_Data = ""
        Me.dtfCompañiaSA3.Text_Data_Desc = ""
        Me.dtfCompañiaSA3.Text_Width = 60
        Me.dtfCompañiaSA3.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfCompañiaSA3.TopPadding = 0
        Me.dtfCompañiaSA3.Upper_Case = False
        Me.dtfCompañiaSA3.Validate_on_lost_focus = True
        '
        'pnlSpace22
        '
        Me.pnlSpace22.Auto_Size = False
        Me.pnlSpace22.BackColor = System.Drawing.Color.Red
        Me.pnlSpace22.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace22.ChangeDock = True
        Me.pnlSpace22.Control_Resize = False
        Me.pnlSpace22.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSpace22.isSpace = True
        Me.pnlSpace22.Location = New System.Drawing.Point(380, 0)
        Me.pnlSpace22.Name = "pnlSpace22"
        Me.pnlSpace22.numRows = 0
        Me.pnlSpace22.Reorder = True
        Me.pnlSpace22.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace22.TabIndex = 1
        '
        'dtfPolizaSA3
        '
        Me.dtfPolizaSA3.Allow_Empty = False
        Me.dtfPolizaSA3.Allow_Negative = True
        Me.dtfPolizaSA3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfPolizaSA3.BackColor = System.Drawing.SystemColors.Control
        Me.dtfPolizaSA3.Data_Allowed = CustomControls.Datafield.List_Data.Libre
        Me.dtfPolizaSA3.DataField = "ADA3"
        Me.dtfPolizaSA3.DataTable = "V2"
        Me.dtfPolizaSA3.Descripcion = "Póliza"
        Me.dtfPolizaSA3.Dock = System.Windows.Forms.DockStyle.Right
        Me.dtfPolizaSA3.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfPolizaSA3.FocoEnAgregar = False
        Me.dtfPolizaSA3.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfPolizaSA3.Image = Nothing
        Me.dtfPolizaSA3.Label_Space = 35
        Me.dtfPolizaSA3.Length_Data = 32767
        Me.dtfPolizaSA3.Location = New System.Drawing.Point(386, 0)
        Me.dtfPolizaSA3.Max_Value = 0.0R
        Me.dtfPolizaSA3.MensajeIncorrectoCustom = Nothing
        Me.dtfPolizaSA3.Name = "dtfPolizaSA3"
        Me.dtfPolizaSA3.Null_on_Empty = True
        Me.dtfPolizaSA3.OpenForm = Nothing
        Me.dtfPolizaSA3.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfPolizaSA3.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfPolizaSA3.ReadOnly_Data = False
        Me.dtfPolizaSA3.Show_Button = False
        Me.dtfPolizaSA3.Size = New System.Drawing.Size(164, 26)
        Me.dtfPolizaSA3.TabIndex = 2
        Me.dtfPolizaSA3.Text_Data = ""
        Me.dtfPolizaSA3.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfPolizaSA3.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfPolizaSA3.TopPadding = 0
        Me.dtfPolizaSA3.Upper_Case = False
        Me.dtfPolizaSA3.Validate_on_lost_focus = True
        '
        'gbxOtrosDSeg
        '
        Me.gbxOtrosDSeg.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.gbxOtrosDSeg.Controls.Add(Me.pnlOtrosDSegInf)
        Me.gbxOtrosDSeg.Controls.Add(Me.pnlOtrosDSegSup)
        Me.gbxOtrosDSeg.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbxOtrosDSeg.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.gbxOtrosDSeg.HeaderText = "Otros Datos del Seguro"
        Me.gbxOtrosDSeg.Location = New System.Drawing.Point(3, 3)
        Me.gbxOtrosDSeg.Name = "gbxOtrosDSeg"
        Me.gbxOtrosDSeg.numRows = 0
        Me.gbxOtrosDSeg.Padding = New System.Windows.Forms.Padding(6, 18, 6, 6)
        Me.gbxOtrosDSeg.Reorder = True
        Me.gbxOtrosDSeg.Size = New System.Drawing.Size(562, 77)
        Me.gbxOtrosDSeg.TabIndex = 0
        Me.gbxOtrosDSeg.Text = "Otros Datos del Seguro"
        Me.gbxOtrosDSeg.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.gbxOtrosDSeg.ThemeName = "Windows8"
        Me.gbxOtrosDSeg.Title = "Otros Datos del Seguro"
        '
        'pnlOtrosDSegInf
        '
        Me.pnlOtrosDSegInf.AccessibleName = ""
        Me.pnlOtrosDSegInf.Auto_Size = False
        Me.pnlOtrosDSegInf.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlOtrosDSegInf.ChangeDock = True
        Me.pnlOtrosDSegInf.Control_Resize = False
        Me.pnlOtrosDSegInf.Controls.Add(Me.chkEnVehic)
        Me.pnlOtrosDSegInf.Controls.Add(Me.pnlSpace21)
        Me.pnlOtrosDSegInf.Controls.Add(Me.chkTenemosRec)
        Me.pnlOtrosDSegInf.Controls.Add(Me.pnlSpace20)
        Me.pnlOtrosDSegInf.Controls.Add(Me.chkTodoRiesgo)
        Me.pnlOtrosDSegInf.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlOtrosDSegInf.isSpace = False
        Me.pnlOtrosDSegInf.Location = New System.Drawing.Point(6, 44)
        Me.pnlOtrosDSegInf.Name = "pnlOtrosDSegInf"
        Me.pnlOtrosDSegInf.numRows = 1
        Me.pnlOtrosDSegInf.Reorder = True
        Me.pnlOtrosDSegInf.Size = New System.Drawing.Size(550, 26)
        Me.pnlOtrosDSegInf.TabIndex = 1
        '
        'chkEnVehic
        '
        Me.chkEnVehic.DataField = "SEGURO_EN_VEHI"
        Me.chkEnVehic.DataTable = "V1"
        Me.chkEnVehic.Descripcion = "en el vehículo"
        Me.chkEnVehic.Dock = System.Windows.Forms.DockStyle.Left
        Me.chkEnVehic.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.chkEnVehic.Location = New System.Drawing.Point(235, 0)
        Me.chkEnVehic.Name = "chkEnVehic"
        Me.chkEnVehic.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.chkEnVehic.Size = New System.Drawing.Size(102, 26)
        Me.chkEnVehic.TabIndex = 4
        Me.chkEnVehic.Text = "en el vehículo"
        Me.chkEnVehic.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.chkEnVehic.ThemeName = "Windows8"
        Me.chkEnVehic.Value = False
        '
        'pnlSpace21
        '
        Me.pnlSpace21.Auto_Size = False
        Me.pnlSpace21.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace21.ChangeDock = True
        Me.pnlSpace21.Control_Resize = False
        Me.pnlSpace21.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace21.isSpace = True
        Me.pnlSpace21.Location = New System.Drawing.Point(229, 0)
        Me.pnlSpace21.Name = "pnlSpace21"
        Me.pnlSpace21.numRows = 0
        Me.pnlSpace21.Reorder = True
        Me.pnlSpace21.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace21.TabIndex = 3
        '
        'chkTenemosRec
        '
        Me.chkTenemosRec.DataField = "RECIBO_V1"
        Me.chkTenemosRec.DataTable = "V1"
        Me.chkTenemosRec.Descripcion = "Tenemos el Recibo"
        Me.chkTenemosRec.Dock = System.Windows.Forms.DockStyle.Left
        Me.chkTenemosRec.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.chkTenemosRec.Location = New System.Drawing.Point(99, 0)
        Me.chkTenemosRec.Name = "chkTenemosRec"
        Me.chkTenemosRec.Size = New System.Drawing.Size(130, 26)
        Me.chkTenemosRec.TabIndex = 2
        Me.chkTenemosRec.Text = "Tenemos el Recibo"
        Me.chkTenemosRec.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.chkTenemosRec.ThemeName = "Windows8"
        Me.chkTenemosRec.Value = False
        '
        'pnlSpace20
        '
        Me.pnlSpace20.Auto_Size = False
        Me.pnlSpace20.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace20.ChangeDock = True
        Me.pnlSpace20.Control_Resize = False
        Me.pnlSpace20.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace20.isSpace = True
        Me.pnlSpace20.Location = New System.Drawing.Point(93, 0)
        Me.pnlSpace20.Name = "pnlSpace20"
        Me.pnlSpace20.numRows = 0
        Me.pnlSpace20.Reorder = True
        Me.pnlSpace20.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace20.TabIndex = 1
        '
        'chkTodoRiesgo
        '
        Me.chkTodoRiesgo.DataField = "SEGU_TODORIESGO"
        Me.chkTodoRiesgo.DataTable = "V1"
        Me.chkTodoRiesgo.Descripcion = "Todo Riesgo"
        Me.chkTodoRiesgo.Dock = System.Windows.Forms.DockStyle.Left
        Me.chkTodoRiesgo.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.chkTodoRiesgo.Location = New System.Drawing.Point(0, 0)
        Me.chkTodoRiesgo.Name = "chkTodoRiesgo"
        Me.chkTodoRiesgo.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.chkTodoRiesgo.Size = New System.Drawing.Size(93, 26)
        Me.chkTodoRiesgo.TabIndex = 0
        Me.chkTodoRiesgo.Text = "Todo Riesgo"
        Me.chkTodoRiesgo.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.chkTodoRiesgo.ThemeName = "Windows8"
        Me.chkTodoRiesgo.Value = False
        '
        'pnlOtrosDSegSup
        '
        Me.pnlOtrosDSegSup.Auto_Size = False
        Me.pnlOtrosDSegSup.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlOtrosDSegSup.ChangeDock = True
        Me.pnlOtrosDSegSup.Control_Resize = False
        Me.pnlOtrosDSegSup.Controls.Add(Me.dtfCartaVerde)
        Me.pnlOtrosDSegSup.Controls.Add(Me.pnlSpace19)
        Me.pnlOtrosDSegSup.Controls.Add(Me.chkSegInternacional)
        Me.pnlOtrosDSegSup.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlOtrosDSegSup.isSpace = False
        Me.pnlOtrosDSegSup.Location = New System.Drawing.Point(6, 18)
        Me.pnlOtrosDSegSup.Name = "pnlOtrosDSegSup"
        Me.pnlOtrosDSegSup.numRows = 1
        Me.pnlOtrosDSegSup.Reorder = True
        Me.pnlOtrosDSegSup.Size = New System.Drawing.Size(550, 26)
        Me.pnlOtrosDSegSup.TabIndex = 0
        '
        'dtfCartaVerde
        '
        Me.dtfCartaVerde.Allow_Empty = False
        Me.dtfCartaVerde.Allow_Negative = True
        Me.dtfCartaVerde.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfCartaVerde.BackColor = System.Drawing.SystemColors.Control
        Me.dtfCartaVerde.Data_Allowed = CustomControls.Datafield.List_Data.Libre
        Me.dtfCartaVerde.DataField = "CARTAVERDE"
        Me.dtfCartaVerde.DataTable = "V2"
        Me.dtfCartaVerde.Descripcion = "Carta Verde"
        Me.dtfCartaVerde.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfCartaVerde.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfCartaVerde.FocoEnAgregar = False
        Me.dtfCartaVerde.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfCartaVerde.Image = Nothing
        Me.dtfCartaVerde.Label_Space = 80
        Me.dtfCartaVerde.Length_Data = 32767
        Me.dtfCartaVerde.Location = New System.Drawing.Point(104, 0)
        Me.dtfCartaVerde.Max_Value = 0.0R
        Me.dtfCartaVerde.MensajeIncorrectoCustom = Nothing
        Me.dtfCartaVerde.Name = "dtfCartaVerde"
        Me.dtfCartaVerde.Null_on_Empty = True
        Me.dtfCartaVerde.OpenForm = Nothing
        Me.dtfCartaVerde.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfCartaVerde.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfCartaVerde.ReadOnly_Data = False
        Me.dtfCartaVerde.Show_Button = False
        Me.dtfCartaVerde.Size = New System.Drawing.Size(228, 26)
        Me.dtfCartaVerde.TabIndex = 2
        Me.dtfCartaVerde.Text_Data = ""
        Me.dtfCartaVerde.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfCartaVerde.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfCartaVerde.TopPadding = 0
        Me.dtfCartaVerde.Upper_Case = False
        Me.dtfCartaVerde.Validate_on_lost_focus = True
        '
        'pnlSpace19
        '
        Me.pnlSpace19.Auto_Size = False
        Me.pnlSpace19.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace19.ChangeDock = True
        Me.pnlSpace19.Control_Resize = False
        Me.pnlSpace19.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace19.isSpace = True
        Me.pnlSpace19.Location = New System.Drawing.Point(98, 0)
        Me.pnlSpace19.Name = "pnlSpace19"
        Me.pnlSpace19.numRows = 0
        Me.pnlSpace19.Reorder = True
        Me.pnlSpace19.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace19.TabIndex = 1
        '
        'chkSegInternacional
        '
        Me.chkSegInternacional.DataField = "SEGU_INTERNACIONAL"
        Me.chkSegInternacional.DataTable = "V1"
        Me.chkSegInternacional.Descripcion = "Internacional"
        Me.chkSegInternacional.Dock = System.Windows.Forms.DockStyle.Left
        Me.chkSegInternacional.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.chkSegInternacional.Location = New System.Drawing.Point(0, 0)
        Me.chkSegInternacional.Name = "chkSegInternacional"
        Me.chkSegInternacional.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.chkSegInternacional.Size = New System.Drawing.Size(98, 26)
        Me.chkSegInternacional.TabIndex = 0
        Me.chkSegInternacional.Text = "Internacional"
        Me.chkSegInternacional.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.chkSegInternacional.ThemeName = "Windows8"
        Me.chkSegInternacional.Value = False
        '
        'pnlIzqSeguro
        '
        Me.pnlIzqSeguro.Auto_Size = False
        Me.pnlIzqSeguro.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlIzqSeguro.ChangeDock = True
        Me.pnlIzqSeguro.Control_Resize = False
        Me.pnlIzqSeguro.Controls.Add(Me.gbxPagos)
        Me.pnlIzqSeguro.Controls.Add(Me.gbxDatosSeguro)
        Me.pnlIzqSeguro.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlIzqSeguro.isSpace = False
        Me.pnlIzqSeguro.Location = New System.Drawing.Point(0, 88)
        Me.pnlIzqSeguro.MinimumSize = New System.Drawing.Size(467, 0)
        Me.pnlIzqSeguro.Name = "pnlIzqSeguro"
        Me.pnlIzqSeguro.numRows = 0
        Me.pnlIzqSeguro.Padding = New System.Windows.Forms.Padding(3)
        Me.pnlIzqSeguro.Reorder = True
        '
        '
        '
        Me.pnlIzqSeguro.RootElement.MinSize = New System.Drawing.Size(467, 0)
        Me.pnlIzqSeguro.Size = New System.Drawing.Size(568, 412)
        Me.pnlIzqSeguro.TabIndex = 3
        '
        'gbxPagos
        '
        Me.gbxPagos.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.gbxPagos.Controls.Add(Me.Panel36)
        Me.gbxPagos.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbxPagos.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.gbxPagos.HeaderText = "Pagos"
        Me.gbxPagos.Location = New System.Drawing.Point(3, 277)
        Me.gbxPagos.Name = "gbxPagos"
        Me.gbxPagos.numRows = 0
        Me.gbxPagos.Padding = New System.Windows.Forms.Padding(6, 18, 6, 6)
        Me.gbxPagos.Reorder = True
        Me.gbxPagos.Size = New System.Drawing.Size(562, 135)
        Me.gbxPagos.TabIndex = 1
        Me.gbxPagos.Text = "Pagos"
        Me.gbxPagos.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.gbxPagos.ThemeName = "Windows8"
        Me.gbxPagos.Title = "Pagos"
        '
        'Panel36
        '
        Me.Panel36.Auto_Size = False
        Me.Panel36.BorderColor = System.Drawing.SystemColors.Control
        Me.Panel36.ChangeDock = True
        Me.Panel36.Control_Resize = False
        Me.Panel36.Controls.Add(Me.pnlPagoSeg4)
        Me.Panel36.Controls.Add(Me.pnlPagoSeg3)
        Me.Panel36.Controls.Add(Me.pnlPagoSeg2)
        Me.Panel36.Controls.Add(Me.pnlPagoSeg1)
        Me.Panel36.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel36.isSpace = False
        Me.Panel36.Location = New System.Drawing.Point(6, 18)
        Me.Panel36.Name = "Panel36"
        Me.Panel36.numRows = 0
        Me.Panel36.Reorder = True
        Me.Panel36.Size = New System.Drawing.Size(550, 111)
        Me.Panel36.TabIndex = 0
        '
        'pnlPagoSeg4
        '
        Me.pnlPagoSeg4.Auto_Size = False
        Me.pnlPagoSeg4.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlPagoSeg4.ChangeDock = True
        Me.pnlPagoSeg4.Control_Resize = False
        Me.pnlPagoSeg4.Controls.Add(Me.chkPagado4)
        Me.pnlPagoSeg4.Controls.Add(Me.pnlSpace40)
        Me.pnlPagoSeg4.Controls.Add(Me.dtfImp4)
        Me.pnlPagoSeg4.Controls.Add(Me.pnlSpace34)
        Me.pnlPagoSeg4.Controls.Add(Me.dtlVen4)
        Me.pnlPagoSeg4.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlPagoSeg4.isSpace = False
        Me.pnlPagoSeg4.Location = New System.Drawing.Point(0, 78)
        Me.pnlPagoSeg4.Name = "pnlPagoSeg4"
        Me.pnlPagoSeg4.numRows = 1
        Me.pnlPagoSeg4.Reorder = True
        Me.pnlPagoSeg4.Size = New System.Drawing.Size(550, 26)
        Me.pnlPagoSeg4.TabIndex = 3
        '
        'chkPagado4
        '
        Me.chkPagado4.DataField = "Pagado4"
        Me.chkPagado4.DataTable = "V1"
        Me.chkPagado4.Descripcion = "Pagado"
        Me.chkPagado4.Dock = System.Windows.Forms.DockStyle.Left
        Me.chkPagado4.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.chkPagado4.Location = New System.Drawing.Point(374, 0)
        Me.chkPagado4.Name = "chkPagado4"
        Me.chkPagado4.Size = New System.Drawing.Size(65, 26)
        Me.chkPagado4.TabIndex = 4
        Me.chkPagado4.Text = "Pagado"
        Me.chkPagado4.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.chkPagado4.ThemeName = "Windows8"
        Me.chkPagado4.Value = False
        '
        'pnlSpace40
        '
        Me.pnlSpace40.Auto_Size = False
        Me.pnlSpace40.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace40.ChangeDock = True
        Me.pnlSpace40.Control_Resize = False
        Me.pnlSpace40.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace40.isSpace = True
        Me.pnlSpace40.Location = New System.Drawing.Point(368, 0)
        Me.pnlSpace40.Name = "pnlSpace40"
        Me.pnlSpace40.numRows = 0
        Me.pnlSpace40.Reorder = True
        Me.pnlSpace40.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace40.TabIndex = 3
        '
        'dtfImp4
        '
        Me.dtfImp4.Allow_Empty = True
        Me.dtfImp4.Allow_Negative = True
        Me.dtfImp4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfImp4.BackColor = System.Drawing.SystemColors.Control
        Me.dtfImp4.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfImp4.DataField = "IMPSEG4"
        Me.dtfImp4.DataTable = "V1"
        Me.dtfImp4.Descripcion = "Importe"
        Me.dtfImp4.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfImp4.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfImp4.FocoEnAgregar = False
        Me.dtfImp4.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfImp4.Image = Nothing
        Me.dtfImp4.Label_Space = 60
        Me.dtfImp4.Length_Data = 32767
        Me.dtfImp4.Location = New System.Drawing.Point(176, 0)
        Me.dtfImp4.Max_Value = 0.0R
        Me.dtfImp4.MensajeIncorrectoCustom = Nothing
        Me.dtfImp4.Name = "dtfImp4"
        Me.dtfImp4.Null_on_Empty = True
        Me.dtfImp4.OpenForm = Nothing
        Me.dtfImp4.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfImp4.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfImp4.ReadOnly_Data = False
        Me.dtfImp4.Show_Button = False
        Me.dtfImp4.Size = New System.Drawing.Size(192, 26)
        Me.dtfImp4.TabIndex = 2
        Me.dtfImp4.Text_Data = ""
        Me.dtfImp4.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfImp4.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfImp4.TopPadding = 0
        Me.dtfImp4.Upper_Case = False
        Me.dtfImp4.Validate_on_lost_focus = True
        '
        'pnlSpace34
        '
        Me.pnlSpace34.Auto_Size = False
        Me.pnlSpace34.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace34.ChangeDock = True
        Me.pnlSpace34.Control_Resize = False
        Me.pnlSpace34.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace34.isSpace = True
        Me.pnlSpace34.Location = New System.Drawing.Point(170, 0)
        Me.pnlSpace34.Name = "pnlSpace34"
        Me.pnlSpace34.numRows = 0
        Me.pnlSpace34.Reorder = True
        Me.pnlSpace34.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace34.TabIndex = 1
        '
        'dtlVen4
        '
        Me.dtlVen4.Allow_Empty = True
        Me.dtlVen4.DataField = "FPAGO4"
        Me.dtlVen4.DataTable = "V1"
        Me.dtlVen4.Default_Value = New Date(2016, 4, 12, 0, 0, 0, 0)
        Me.dtlVen4.Descripcion = "Vencimiento4"
        Me.dtlVen4.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtlVen4.FocoEnAgregar = False
        Me.dtlVen4.Label_Space = 80
        Me.dtlVen4.Location = New System.Drawing.Point(0, 0)
        Me.dtlVen4.Max_Value = Nothing
        Me.dtlVen4.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtlVen4.MensajeIncorrectoCustom = Nothing
        Me.dtlVen4.Min_Value = Nothing
        Me.dtlVen4.MinDate = New Date(CType(0, Long))
        Me.dtlVen4.MinimumSize = New System.Drawing.Size(170, 26)
        Me.dtlVen4.Name = "dtlVen4"
        Me.dtlVen4.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtlVen4.ReadOnly_Data = False
        Me.dtlVen4.Size = New System.Drawing.Size(170, 26)
        Me.dtlVen4.TabIndex = 0
        Me.dtlVen4.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtlVen4.Validate_on_lost_focus = True
        Me.dtlVen4.Value_Data = New Date(2016, 4, 12, 0, 0, 0, 0)
        '
        'pnlPagoSeg3
        '
        Me.pnlPagoSeg3.Auto_Size = False
        Me.pnlPagoSeg3.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlPagoSeg3.ChangeDock = True
        Me.pnlPagoSeg3.Control_Resize = False
        Me.pnlPagoSeg3.Controls.Add(Me.chkPagado3)
        Me.pnlPagoSeg3.Controls.Add(Me.pnlSpace39)
        Me.pnlPagoSeg3.Controls.Add(Me.dtfImp3)
        Me.pnlPagoSeg3.Controls.Add(Me.pnlSpace33)
        Me.pnlPagoSeg3.Controls.Add(Me.dtlVen3)
        Me.pnlPagoSeg3.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlPagoSeg3.isSpace = False
        Me.pnlPagoSeg3.Location = New System.Drawing.Point(0, 52)
        Me.pnlPagoSeg3.Name = "pnlPagoSeg3"
        Me.pnlPagoSeg3.numRows = 1
        Me.pnlPagoSeg3.Reorder = True
        Me.pnlPagoSeg3.Size = New System.Drawing.Size(550, 26)
        Me.pnlPagoSeg3.TabIndex = 2
        '
        'chkPagado3
        '
        Me.chkPagado3.DataField = "Pagado3"
        Me.chkPagado3.DataTable = "V1"
        Me.chkPagado3.Descripcion = "Pagado"
        Me.chkPagado3.Dock = System.Windows.Forms.DockStyle.Left
        Me.chkPagado3.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.chkPagado3.Location = New System.Drawing.Point(374, 0)
        Me.chkPagado3.Name = "chkPagado3"
        Me.chkPagado3.Size = New System.Drawing.Size(65, 26)
        Me.chkPagado3.TabIndex = 4
        Me.chkPagado3.Text = "Pagado"
        Me.chkPagado3.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.chkPagado3.ThemeName = "Windows8"
        Me.chkPagado3.Value = False
        '
        'pnlSpace39
        '
        Me.pnlSpace39.Auto_Size = False
        Me.pnlSpace39.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace39.ChangeDock = True
        Me.pnlSpace39.Control_Resize = False
        Me.pnlSpace39.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace39.isSpace = True
        Me.pnlSpace39.Location = New System.Drawing.Point(368, 0)
        Me.pnlSpace39.Name = "pnlSpace39"
        Me.pnlSpace39.numRows = 0
        Me.pnlSpace39.Reorder = True
        Me.pnlSpace39.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace39.TabIndex = 3
        '
        'dtfImp3
        '
        Me.dtfImp3.Allow_Empty = True
        Me.dtfImp3.Allow_Negative = True
        Me.dtfImp3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfImp3.BackColor = System.Drawing.SystemColors.Control
        Me.dtfImp3.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfImp3.DataField = "IMPSEG3"
        Me.dtfImp3.DataTable = "V1"
        Me.dtfImp3.Descripcion = "Importe"
        Me.dtfImp3.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfImp3.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfImp3.FocoEnAgregar = False
        Me.dtfImp3.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfImp3.Image = Nothing
        Me.dtfImp3.Label_Space = 60
        Me.dtfImp3.Length_Data = 32767
        Me.dtfImp3.Location = New System.Drawing.Point(176, 0)
        Me.dtfImp3.Max_Value = 0.0R
        Me.dtfImp3.MensajeIncorrectoCustom = Nothing
        Me.dtfImp3.Name = "dtfImp3"
        Me.dtfImp3.Null_on_Empty = True
        Me.dtfImp3.OpenForm = Nothing
        Me.dtfImp3.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfImp3.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfImp3.ReadOnly_Data = False
        Me.dtfImp3.Show_Button = False
        Me.dtfImp3.Size = New System.Drawing.Size(192, 26)
        Me.dtfImp3.TabIndex = 2
        Me.dtfImp3.Text_Data = ""
        Me.dtfImp3.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfImp3.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfImp3.TopPadding = 0
        Me.dtfImp3.Upper_Case = False
        Me.dtfImp3.Validate_on_lost_focus = True
        '
        'pnlSpace33
        '
        Me.pnlSpace33.Auto_Size = False
        Me.pnlSpace33.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace33.ChangeDock = True
        Me.pnlSpace33.Control_Resize = False
        Me.pnlSpace33.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace33.isSpace = True
        Me.pnlSpace33.Location = New System.Drawing.Point(170, 0)
        Me.pnlSpace33.Name = "pnlSpace33"
        Me.pnlSpace33.numRows = 0
        Me.pnlSpace33.Reorder = True
        Me.pnlSpace33.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace33.TabIndex = 1
        '
        'dtlVen3
        '
        Me.dtlVen3.Allow_Empty = True
        Me.dtlVen3.DataField = "FPAGO3"
        Me.dtlVen3.DataTable = "V1"
        Me.dtlVen3.Default_Value = New Date(2016, 4, 12, 0, 0, 0, 0)
        Me.dtlVen3.Descripcion = "Vencimiento3"
        Me.dtlVen3.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtlVen3.FocoEnAgregar = False
        Me.dtlVen3.Label_Space = 80
        Me.dtlVen3.Location = New System.Drawing.Point(0, 0)
        Me.dtlVen3.Max_Value = Nothing
        Me.dtlVen3.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtlVen3.MensajeIncorrectoCustom = Nothing
        Me.dtlVen3.Min_Value = Nothing
        Me.dtlVen3.MinDate = New Date(CType(0, Long))
        Me.dtlVen3.MinimumSize = New System.Drawing.Size(170, 26)
        Me.dtlVen3.Name = "dtlVen3"
        Me.dtlVen3.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtlVen3.ReadOnly_Data = False
        Me.dtlVen3.Size = New System.Drawing.Size(170, 26)
        Me.dtlVen3.TabIndex = 0
        Me.dtlVen3.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtlVen3.Validate_on_lost_focus = True
        Me.dtlVen3.Value_Data = New Date(2016, 4, 12, 0, 0, 0, 0)
        '
        'pnlPagoSeg2
        '
        Me.pnlPagoSeg2.Auto_Size = False
        Me.pnlPagoSeg2.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlPagoSeg2.ChangeDock = True
        Me.pnlPagoSeg2.Control_Resize = False
        Me.pnlPagoSeg2.Controls.Add(Me.chkPagado2)
        Me.pnlPagoSeg2.Controls.Add(Me.pnlSpace38)
        Me.pnlPagoSeg2.Controls.Add(Me.dtfImp2)
        Me.pnlPagoSeg2.Controls.Add(Me.pnlSpace32)
        Me.pnlPagoSeg2.Controls.Add(Me.dtlVen2)
        Me.pnlPagoSeg2.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlPagoSeg2.isSpace = False
        Me.pnlPagoSeg2.Location = New System.Drawing.Point(0, 26)
        Me.pnlPagoSeg2.Name = "pnlPagoSeg2"
        Me.pnlPagoSeg2.numRows = 1
        Me.pnlPagoSeg2.Reorder = True
        Me.pnlPagoSeg2.Size = New System.Drawing.Size(550, 26)
        Me.pnlPagoSeg2.TabIndex = 1
        '
        'chkPagado2
        '
        Me.chkPagado2.DataField = "Pagado2"
        Me.chkPagado2.DataTable = "V1"
        Me.chkPagado2.Descripcion = "Pagado"
        Me.chkPagado2.Dock = System.Windows.Forms.DockStyle.Left
        Me.chkPagado2.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.chkPagado2.Location = New System.Drawing.Point(374, 0)
        Me.chkPagado2.Name = "chkPagado2"
        Me.chkPagado2.Size = New System.Drawing.Size(65, 26)
        Me.chkPagado2.TabIndex = 4
        Me.chkPagado2.Text = "Pagado"
        Me.chkPagado2.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.chkPagado2.ThemeName = "Windows8"
        Me.chkPagado2.Value = False
        '
        'pnlSpace38
        '
        Me.pnlSpace38.Auto_Size = False
        Me.pnlSpace38.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace38.ChangeDock = True
        Me.pnlSpace38.Control_Resize = False
        Me.pnlSpace38.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace38.isSpace = True
        Me.pnlSpace38.Location = New System.Drawing.Point(368, 0)
        Me.pnlSpace38.Name = "pnlSpace38"
        Me.pnlSpace38.numRows = 0
        Me.pnlSpace38.Reorder = True
        Me.pnlSpace38.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace38.TabIndex = 3
        '
        'dtfImp2
        '
        Me.dtfImp2.Allow_Empty = True
        Me.dtfImp2.Allow_Negative = True
        Me.dtfImp2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfImp2.BackColor = System.Drawing.SystemColors.Control
        Me.dtfImp2.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfImp2.DataField = "IMPSEG2"
        Me.dtfImp2.DataTable = "V1"
        Me.dtfImp2.Descripcion = "Importe"
        Me.dtfImp2.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfImp2.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfImp2.FocoEnAgregar = False
        Me.dtfImp2.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfImp2.Image = Nothing
        Me.dtfImp2.Label_Space = 60
        Me.dtfImp2.Length_Data = 32767
        Me.dtfImp2.Location = New System.Drawing.Point(176, 0)
        Me.dtfImp2.Max_Value = 0.0R
        Me.dtfImp2.MensajeIncorrectoCustom = Nothing
        Me.dtfImp2.Name = "dtfImp2"
        Me.dtfImp2.Null_on_Empty = True
        Me.dtfImp2.OpenForm = Nothing
        Me.dtfImp2.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfImp2.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfImp2.ReadOnly_Data = False
        Me.dtfImp2.Show_Button = False
        Me.dtfImp2.Size = New System.Drawing.Size(192, 26)
        Me.dtfImp2.TabIndex = 2
        Me.dtfImp2.Text_Data = ""
        Me.dtfImp2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfImp2.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfImp2.TopPadding = 0
        Me.dtfImp2.Upper_Case = False
        Me.dtfImp2.Validate_on_lost_focus = True
        '
        'pnlSpace32
        '
        Me.pnlSpace32.Auto_Size = False
        Me.pnlSpace32.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace32.ChangeDock = True
        Me.pnlSpace32.Control_Resize = False
        Me.pnlSpace32.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace32.isSpace = True
        Me.pnlSpace32.Location = New System.Drawing.Point(170, 0)
        Me.pnlSpace32.Name = "pnlSpace32"
        Me.pnlSpace32.numRows = 0
        Me.pnlSpace32.Reorder = True
        Me.pnlSpace32.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace32.TabIndex = 1
        '
        'dtlVen2
        '
        Me.dtlVen2.Allow_Empty = True
        Me.dtlVen2.DataField = "FPAGO2"
        Me.dtlVen2.DataTable = "V1"
        Me.dtlVen2.Default_Value = New Date(2016, 4, 12, 0, 0, 0, 0)
        Me.dtlVen2.Descripcion = "Vencimiento2"
        Me.dtlVen2.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtlVen2.FocoEnAgregar = False
        Me.dtlVen2.Label_Space = 80
        Me.dtlVen2.Location = New System.Drawing.Point(0, 0)
        Me.dtlVen2.Max_Value = Nothing
        Me.dtlVen2.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtlVen2.MensajeIncorrectoCustom = Nothing
        Me.dtlVen2.Min_Value = Nothing
        Me.dtlVen2.MinDate = New Date(CType(0, Long))
        Me.dtlVen2.MinimumSize = New System.Drawing.Size(170, 26)
        Me.dtlVen2.Name = "dtlVen2"
        Me.dtlVen2.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtlVen2.ReadOnly_Data = False
        Me.dtlVen2.Size = New System.Drawing.Size(170, 26)
        Me.dtlVen2.TabIndex = 0
        Me.dtlVen2.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtlVen2.Validate_on_lost_focus = True
        Me.dtlVen2.Value_Data = New Date(2016, 4, 12, 0, 0, 0, 0)
        '
        'pnlPagoSeg1
        '
        Me.pnlPagoSeg1.Auto_Size = False
        Me.pnlPagoSeg1.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlPagoSeg1.ChangeDock = True
        Me.pnlPagoSeg1.Control_Resize = False
        Me.pnlPagoSeg1.Controls.Add(Me.chkPagado1)
        Me.pnlPagoSeg1.Controls.Add(Me.pnlSpace37)
        Me.pnlPagoSeg1.Controls.Add(Me.dtfImp1)
        Me.pnlPagoSeg1.Controls.Add(Me.pnlSpace31)
        Me.pnlPagoSeg1.Controls.Add(Me.dtlVen1)
        Me.pnlPagoSeg1.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlPagoSeg1.isSpace = False
        Me.pnlPagoSeg1.Location = New System.Drawing.Point(0, 0)
        Me.pnlPagoSeg1.Name = "pnlPagoSeg1"
        Me.pnlPagoSeg1.numRows = 1
        Me.pnlPagoSeg1.Reorder = True
        Me.pnlPagoSeg1.Size = New System.Drawing.Size(550, 26)
        Me.pnlPagoSeg1.TabIndex = 0
        '
        'chkPagado1
        '
        Me.chkPagado1.DataField = "Pagado1"
        Me.chkPagado1.DataTable = "V1"
        Me.chkPagado1.Descripcion = "Pagado"
        Me.chkPagado1.Dock = System.Windows.Forms.DockStyle.Left
        Me.chkPagado1.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.chkPagado1.Location = New System.Drawing.Point(374, 0)
        Me.chkPagado1.Name = "chkPagado1"
        Me.chkPagado1.Size = New System.Drawing.Size(65, 26)
        Me.chkPagado1.TabIndex = 4
        Me.chkPagado1.Text = "Pagado"
        Me.chkPagado1.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.chkPagado1.ThemeName = "Windows8"
        Me.chkPagado1.Value = False
        '
        'pnlSpace37
        '
        Me.pnlSpace37.Auto_Size = False
        Me.pnlSpace37.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace37.ChangeDock = True
        Me.pnlSpace37.Control_Resize = False
        Me.pnlSpace37.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace37.isSpace = True
        Me.pnlSpace37.Location = New System.Drawing.Point(368, 0)
        Me.pnlSpace37.Name = "pnlSpace37"
        Me.pnlSpace37.numRows = 0
        Me.pnlSpace37.Reorder = True
        Me.pnlSpace37.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace37.TabIndex = 3
        '
        'dtfImp1
        '
        Me.dtfImp1.Allow_Empty = True
        Me.dtfImp1.Allow_Negative = True
        Me.dtfImp1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfImp1.BackColor = System.Drawing.SystemColors.Control
        Me.dtfImp1.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfImp1.DataField = "IMPSEG1"
        Me.dtfImp1.DataTable = "V1"
        Me.dtfImp1.Descripcion = "Importe"
        Me.dtfImp1.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfImp1.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfImp1.FocoEnAgregar = False
        Me.dtfImp1.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfImp1.Image = Nothing
        Me.dtfImp1.Label_Space = 60
        Me.dtfImp1.Length_Data = 32767
        Me.dtfImp1.Location = New System.Drawing.Point(176, 0)
        Me.dtfImp1.Max_Value = 0.0R
        Me.dtfImp1.MensajeIncorrectoCustom = Nothing
        Me.dtfImp1.Name = "dtfImp1"
        Me.dtfImp1.Null_on_Empty = True
        Me.dtfImp1.OpenForm = Nothing
        Me.dtfImp1.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfImp1.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfImp1.ReadOnly_Data = False
        Me.dtfImp1.Show_Button = False
        Me.dtfImp1.Size = New System.Drawing.Size(192, 26)
        Me.dtfImp1.TabIndex = 2
        Me.dtfImp1.Text_Data = ""
        Me.dtfImp1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfImp1.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfImp1.TopPadding = 0
        Me.dtfImp1.Upper_Case = False
        Me.dtfImp1.Validate_on_lost_focus = True
        '
        'pnlSpace31
        '
        Me.pnlSpace31.Auto_Size = False
        Me.pnlSpace31.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace31.ChangeDock = True
        Me.pnlSpace31.Control_Resize = False
        Me.pnlSpace31.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace31.isSpace = True
        Me.pnlSpace31.Location = New System.Drawing.Point(170, 0)
        Me.pnlSpace31.Name = "pnlSpace31"
        Me.pnlSpace31.numRows = 0
        Me.pnlSpace31.Reorder = True
        Me.pnlSpace31.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace31.TabIndex = 1
        '
        'dtlVen1
        '
        Me.dtlVen1.Allow_Empty = True
        Me.dtlVen1.DataField = "FPAGO1"
        Me.dtlVen1.DataTable = "V1"
        Me.dtlVen1.Default_Value = New Date(2016, 4, 12, 0, 0, 0, 0)
        Me.dtlVen1.Descripcion = "Vencimiento1"
        Me.dtlVen1.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtlVen1.FocoEnAgregar = False
        Me.dtlVen1.Label_Space = 80
        Me.dtlVen1.Location = New System.Drawing.Point(0, 0)
        Me.dtlVen1.Max_Value = Nothing
        Me.dtlVen1.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtlVen1.MensajeIncorrectoCustom = Nothing
        Me.dtlVen1.Min_Value = Nothing
        Me.dtlVen1.MinDate = New Date(CType(0, Long))
        Me.dtlVen1.MinimumSize = New System.Drawing.Size(170, 26)
        Me.dtlVen1.Name = "dtlVen1"
        Me.dtlVen1.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtlVen1.ReadOnly_Data = False
        Me.dtlVen1.Size = New System.Drawing.Size(170, 26)
        Me.dtlVen1.TabIndex = 0
        Me.dtlVen1.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtlVen1.Validate_on_lost_focus = True
        Me.dtlVen1.Value_Data = New Date(2016, 4, 12, 0, 0, 0, 0)
        '
        'gbxDatosSeguro
        '
        Me.gbxDatosSeguro.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.gbxDatosSeguro.Controls.Add(Me.pnlDatosSegInf)
        Me.gbxDatosSeguro.Controls.Add(Me.pnlPrimaPendSeg)
        Me.gbxDatosSeguro.Controls.Add(Me.pnlFechasSeg)
        Me.gbxDatosSeguro.Controls.Add(Me.pnlAgenteFranq)
        Me.gbxDatosSeguro.Controls.Add(Me.Panel6)
        Me.gbxDatosSeguro.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbxDatosSeguro.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.gbxDatosSeguro.HeaderText = "Datos del Seguro"
        Me.gbxDatosSeguro.Location = New System.Drawing.Point(3, 3)
        Me.gbxDatosSeguro.Name = "gbxDatosSeguro"
        Me.gbxDatosSeguro.numRows = 6
        Me.gbxDatosSeguro.Padding = New System.Windows.Forms.Padding(6, 18, 6, 6)
        Me.gbxDatosSeguro.Reorder = True
        Me.gbxDatosSeguro.Size = New System.Drawing.Size(562, 274)
        Me.gbxDatosSeguro.TabIndex = 0
        Me.gbxDatosSeguro.Text = "Datos del Seguro"
        Me.gbxDatosSeguro.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.gbxDatosSeguro.ThemeName = "Windows8"
        Me.gbxDatosSeguro.Title = "Datos del Seguro"
        '
        'pnlDatosSegInf
        '
        Me.pnlDatosSegInf.Auto_Size = False
        Me.pnlDatosSegInf.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlDatosSegInf.ChangeDock = True
        Me.pnlDatosSegInf.Control_Resize = False
        Me.pnlDatosSegInf.Controls.Add(Me.Panel68)
        Me.pnlDatosSegInf.Controls.Add(Me.pnlSpace18)
        Me.pnlDatosSegInf.Controls.Add(Me.pnlTipoSegObs)
        Me.pnlDatosSegInf.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlDatosSegInf.isSpace = False
        Me.pnlDatosSegInf.Location = New System.Drawing.Point(6, 122)
        Me.pnlDatosSegInf.Name = "pnlDatosSegInf"
        Me.pnlDatosSegInf.numRows = 0
        Me.pnlDatosSegInf.Reorder = True
        Me.pnlDatosSegInf.Size = New System.Drawing.Size(550, 144)
        Me.pnlDatosSegInf.TabIndex = 4
        '
        'Panel68
        '
        Me.Panel68.Auto_Size = False
        Me.Panel68.BorderColor = System.Drawing.SystemColors.Control
        Me.Panel68.ChangeDock = True
        Me.Panel68.Control_Resize = False
        Me.Panel68.Controls.Add(Me.rdgFormaPagoSeg)
        Me.Panel68.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel68.isSpace = False
        Me.Panel68.Location = New System.Drawing.Point(308, 0)
        Me.Panel68.Name = "Panel68"
        Me.Panel68.numRows = 0
        Me.Panel68.Reorder = True
        Me.Panel68.Size = New System.Drawing.Size(173, 144)
        Me.Panel68.TabIndex = 2
        '
        'rdgFormaPagoSeg
        '
        Me.rdgFormaPagoSeg.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.rdgFormaPagoSeg.Controls.Add(Me.radFP4)
        Me.rdgFormaPagoSeg.Controls.Add(Me.radFP3)
        Me.rdgFormaPagoSeg.Controls.Add(Me.radFP2)
        Me.rdgFormaPagoSeg.Controls.Add(Me.radFP1)
        Me.rdgFormaPagoSeg.DataField = "FPAGOSEGURO"
        Me.rdgFormaPagoSeg.DataTable = "V1"
        Me.rdgFormaPagoSeg.DefaultIndex = Nothing
        Me.rdgFormaPagoSeg.Descripcion = "Forma de Pago"
        Me.rdgFormaPagoSeg.Dock = System.Windows.Forms.DockStyle.Left
        Me.rdgFormaPagoSeg.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.rdgFormaPagoSeg.HeaderText = "Forma de Pago"
        Me.rdgFormaPagoSeg.Index = Nothing
        Me.rdgFormaPagoSeg.Location = New System.Drawing.Point(0, 0)
        Me.rdgFormaPagoSeg.Name = "rdgFormaPagoSeg"
        Me.rdgFormaPagoSeg.numRows = 0
        Me.rdgFormaPagoSeg.Padding = New System.Windows.Forms.Padding(6, 18, 6, 6)
        Me.rdgFormaPagoSeg.Reorder = True
        Me.rdgFormaPagoSeg.Size = New System.Drawing.Size(170, 144)
        Me.rdgFormaPagoSeg.TabIndex = 0
        Me.rdgFormaPagoSeg.Text = "Forma de Pago"
        Me.rdgFormaPagoSeg.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.rdgFormaPagoSeg.ThemeName = "Windows8"
        Me.rdgFormaPagoSeg.Title = "Forma de Pago"
        '
        'radFP4
        '
        Me.radFP4.BackColor = System.Drawing.SystemColors.Control
        Me.radFP4.Checked = True
        Me.radFP4.CheckState = System.Windows.Forms.CheckState.Checked
        Me.radFP4.Descripcion = "Emite y paga Cliente"
        Me.radFP4.Dock = System.Windows.Forms.DockStyle.Top
        Me.radFP4.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.radFP4.Index = "3"
        Me.radFP4.Location = New System.Drawing.Point(6, 72)
        Me.radFP4.Name = "radFP4"
        Me.radFP4.Size = New System.Drawing.Size(158, 18)
        Me.radFP4.TabIndex = 3
        Me.radFP4.TabStop = True
        Me.radFP4.Text = "Emite y paga Cliente"
        Me.radFP4.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.radFP4.ThemeName = "Windows8"
        Me.radFP4.ToggleState = Telerik.WinControls.Enumerations.ToggleState.[On]
        '
        'radFP3
        '
        Me.radFP3.BackColor = System.Drawing.SystemColors.Control
        Me.radFP3.Checked = False
        Me.radFP3.Descripcion = "Emite Emp. paga Cli."
        Me.radFP3.Dock = System.Windows.Forms.DockStyle.Top
        Me.radFP3.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.radFP3.Index = "2"
        Me.radFP3.Location = New System.Drawing.Point(6, 54)
        Me.radFP3.Name = "radFP3"
        Me.radFP3.Size = New System.Drawing.Size(158, 18)
        Me.radFP3.TabIndex = 2
        Me.radFP3.Text = "Emite Emp. paga Cli."
        Me.radFP3.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.radFP3.ThemeName = "Windows8"
        '
        'radFP2
        '
        Me.radFP2.BackColor = System.Drawing.SystemColors.Control
        Me.radFP2.Checked = False
        Me.radFP2.Descripcion = "Emite y paga Empresa"
        Me.radFP2.Dock = System.Windows.Forms.DockStyle.Top
        Me.radFP2.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.radFP2.Index = "1"
        Me.radFP2.Location = New System.Drawing.Point(6, 36)
        Me.radFP2.Name = "radFP2"
        Me.radFP2.Size = New System.Drawing.Size(158, 18)
        Me.radFP2.TabIndex = 1
        Me.radFP2.Text = "Emite y paga Empresa"
        Me.radFP2.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.radFP2.ThemeName = "Windows8"
        '
        'radFP1
        '
        Me.radFP1.BackColor = System.Drawing.SystemColors.Control
        Me.radFP1.Checked = False
        Me.radFP1.Descripcion = "No Definido"
        Me.radFP1.Dock = System.Windows.Forms.DockStyle.Top
        Me.radFP1.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.radFP1.Index = "0"
        Me.radFP1.Location = New System.Drawing.Point(6, 18)
        Me.radFP1.Name = "radFP1"
        Me.radFP1.Size = New System.Drawing.Size(158, 18)
        Me.radFP1.TabIndex = 0
        Me.radFP1.Text = "No Definido"
        Me.radFP1.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.radFP1.ThemeName = "Windows8"
        '
        'pnlSpace18
        '
        Me.pnlSpace18.Auto_Size = False
        Me.pnlSpace18.BackColor = System.Drawing.Color.Blue
        Me.pnlSpace18.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace18.ChangeDock = True
        Me.pnlSpace18.Control_Resize = False
        Me.pnlSpace18.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace18.isSpace = True
        Me.pnlSpace18.Location = New System.Drawing.Point(302, 0)
        Me.pnlSpace18.Name = "pnlSpace18"
        Me.pnlSpace18.numRows = 0
        Me.pnlSpace18.Reorder = True
        Me.pnlSpace18.Size = New System.Drawing.Size(6, 144)
        Me.pnlSpace18.TabIndex = 1
        '
        'pnlTipoSegObs
        '
        Me.pnlTipoSegObs.Auto_Size = False
        Me.pnlTipoSegObs.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlTipoSegObs.ChangeDock = True
        Me.pnlTipoSegObs.Control_Resize = False
        Me.pnlTipoSegObs.Controls.Add(Me.dtaObsSeguro)
        Me.pnlTipoSegObs.Controls.Add(Me.dtaTipoSeguro)
        Me.pnlTipoSegObs.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlTipoSegObs.isSpace = False
        Me.pnlTipoSegObs.Location = New System.Drawing.Point(0, 0)
        Me.pnlTipoSegObs.Name = "pnlTipoSegObs"
        Me.pnlTipoSegObs.numRows = 0
        Me.pnlTipoSegObs.Reorder = True
        Me.pnlTipoSegObs.Size = New System.Drawing.Size(302, 144)
        Me.pnlTipoSegObs.TabIndex = 0
        '
        'dtaObsSeguro
        '
        Me.dtaObsSeguro.Allow_Empty = True
        Me.dtaObsSeguro.Allow_Negative = True
        Me.dtaObsSeguro.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtaObsSeguro.BackColor = System.Drawing.SystemColors.Control
        Me.dtaObsSeguro.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtaObsSeguro.DataField = "OBS_SEGURO"
        Me.dtaObsSeguro.DataTable = "V1"
        Me.dtaObsSeguro.Descripcion = "Observaciones"
        Me.dtaObsSeguro.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtaObsSeguro.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtaObsSeguro.FocoEnAgregar = False
        Me.dtaObsSeguro.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtaObsSeguro.Length_Data = 32767
        Me.dtaObsSeguro.Location = New System.Drawing.Point(0, 73)
        Me.dtaObsSeguro.Max_Value = 0.0R
        Me.dtaObsSeguro.MensajeIncorrectoCustom = Nothing
        Me.dtaObsSeguro.Name = "dtaObsSeguro"
        Me.dtaObsSeguro.Null_on_Empty = True
        Me.dtaObsSeguro.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtaObsSeguro.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtaObsSeguro.ReadOnly_Data = False
        Me.dtaObsSeguro.Size = New System.Drawing.Size(302, 73)
        Me.dtaObsSeguro.TabIndex = 1
        Me.dtaObsSeguro.Text_Data = ""
        Me.dtaObsSeguro.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtaObsSeguro.TopPadding = 0
        Me.dtaObsSeguro.Upper_Case = False
        Me.dtaObsSeguro.Validate_on_lost_focus = True
        '
        'dtaTipoSeguro
        '
        Me.dtaTipoSeguro.Allow_Empty = True
        Me.dtaTipoSeguro.Allow_Negative = True
        Me.dtaTipoSeguro.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtaTipoSeguro.BackColor = System.Drawing.SystemColors.Control
        Me.dtaTipoSeguro.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtaTipoSeguro.DataField = "TIPOSEGU"
        Me.dtaTipoSeguro.DataTable = "V1"
        Me.dtaTipoSeguro.Descripcion = "Tipo de Seguros"
        Me.dtaTipoSeguro.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtaTipoSeguro.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtaTipoSeguro.FocoEnAgregar = False
        Me.dtaTipoSeguro.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtaTipoSeguro.Length_Data = 32767
        Me.dtaTipoSeguro.Location = New System.Drawing.Point(0, 0)
        Me.dtaTipoSeguro.Max_Value = 0.0R
        Me.dtaTipoSeguro.MensajeIncorrectoCustom = Nothing
        Me.dtaTipoSeguro.Name = "dtaTipoSeguro"
        Me.dtaTipoSeguro.Null_on_Empty = True
        Me.dtaTipoSeguro.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtaTipoSeguro.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtaTipoSeguro.ReadOnly_Data = False
        Me.dtaTipoSeguro.Size = New System.Drawing.Size(302, 73)
        Me.dtaTipoSeguro.TabIndex = 0
        Me.dtaTipoSeguro.Text_Data = ""
        Me.dtaTipoSeguro.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtaTipoSeguro.TopPadding = 0
        Me.dtaTipoSeguro.Upper_Case = False
        Me.dtaTipoSeguro.Validate_on_lost_focus = True
        '
        'pnlPrimaPendSeg
        '
        Me.pnlPrimaPendSeg.Auto_Size = False
        Me.pnlPrimaPendSeg.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlPrimaPendSeg.ChangeDock = True
        Me.pnlPrimaPendSeg.Control_Resize = False
        Me.pnlPrimaPendSeg.Controls.Add(Me.Panel23)
        Me.pnlPrimaPendSeg.Controls.Add(Me.dtfPendienteSeguro)
        Me.pnlPrimaPendSeg.Controls.Add(Me.Panel22)
        Me.pnlPrimaPendSeg.Controls.Add(Me.dtfExtorno)
        Me.pnlPrimaPendSeg.Controls.Add(Me.pnlSpace35)
        Me.pnlPrimaPendSeg.Controls.Add(Me.dtfPrimaSeguro)
        Me.pnlPrimaPendSeg.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlPrimaPendSeg.isSpace = False
        Me.pnlPrimaPendSeg.Location = New System.Drawing.Point(6, 96)
        Me.pnlPrimaPendSeg.Name = "pnlPrimaPendSeg"
        Me.pnlPrimaPendSeg.numRows = 1
        Me.pnlPrimaPendSeg.Reorder = True
        Me.pnlPrimaPendSeg.Size = New System.Drawing.Size(550, 26)
        Me.pnlPrimaPendSeg.TabIndex = 3
        '
        'Panel23
        '
        Me.Panel23.Auto_Size = False
        Me.Panel23.BorderColor = System.Drawing.SystemColors.Control
        Me.Panel23.ChangeDock = True
        Me.Panel23.Control_Resize = False
        Me.Panel23.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel23.isSpace = True
        Me.Panel23.Location = New System.Drawing.Point(308, 0)
        Me.Panel23.Name = "Panel23"
        Me.Panel23.numRows = 0
        Me.Panel23.Reorder = True
        Me.Panel23.Size = New System.Drawing.Size(6, 26)
        Me.Panel23.TabIndex = 4
        '
        'dtfPendienteSeguro
        '
        Me.dtfPendienteSeguro.Allow_Empty = True
        Me.dtfPendienteSeguro.Allow_Negative = True
        Me.dtfPendienteSeguro.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfPendienteSeguro.BackColor = System.Drawing.SystemColors.Control
        Me.dtfPendienteSeguro.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfPendienteSeguro.DataField = Nothing
        Me.dtfPendienteSeguro.DataTable = ""
        Me.dtfPendienteSeguro.Descripcion = "Pendiente"
        Me.dtfPendienteSeguro.Dock = System.Windows.Forms.DockStyle.Right
        Me.dtfPendienteSeguro.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfPendienteSeguro.FocoEnAgregar = False
        Me.dtfPendienteSeguro.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfPendienteSeguro.Image = Nothing
        Me.dtfPendienteSeguro.Label_Space = 60
        Me.dtfPendienteSeguro.Length_Data = 32767
        Me.dtfPendienteSeguro.Location = New System.Drawing.Point(403, 0)
        Me.dtfPendienteSeguro.Max_Value = 0.0R
        Me.dtfPendienteSeguro.MensajeIncorrectoCustom = Nothing
        Me.dtfPendienteSeguro.Name = "dtfPendienteSeguro"
        Me.dtfPendienteSeguro.Null_on_Empty = True
        Me.dtfPendienteSeguro.OpenForm = Nothing
        Me.dtfPendienteSeguro.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfPendienteSeguro.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfPendienteSeguro.ReadOnly_Data = False
        Me.dtfPendienteSeguro.Show_Button = False
        Me.dtfPendienteSeguro.Size = New System.Drawing.Size(147, 26)
        Me.dtfPendienteSeguro.TabIndex = 5
        Me.dtfPendienteSeguro.Text_Data = ""
        Me.dtfPendienteSeguro.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfPendienteSeguro.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfPendienteSeguro.TopPadding = 0
        Me.dtfPendienteSeguro.Upper_Case = False
        Me.dtfPendienteSeguro.Validate_on_lost_focus = True
        '
        'Panel22
        '
        Me.Panel22.Auto_Size = False
        Me.Panel22.BorderColor = System.Drawing.SystemColors.Control
        Me.Panel22.ChangeDock = True
        Me.Panel22.Control_Resize = False
        Me.Panel22.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel22.isSpace = True
        Me.Panel22.Location = New System.Drawing.Point(302, 0)
        Me.Panel22.Name = "Panel22"
        Me.Panel22.numRows = 0
        Me.Panel22.Reorder = True
        Me.Panel22.Size = New System.Drawing.Size(6, 26)
        Me.Panel22.TabIndex = 3
        '
        'dtfExtorno
        '
        Me.dtfExtorno.Allow_Empty = True
        Me.dtfExtorno.Allow_Negative = True
        Me.dtfExtorno.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfExtorno.BackColor = System.Drawing.SystemColors.Control
        Me.dtfExtorno.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfExtorno.DataField = "EXTORNO"
        Me.dtfExtorno.DataTable = "V2"
        Me.dtfExtorno.Descripcion = "Extorno"
        Me.dtfExtorno.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfExtorno.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfExtorno.FocoEnAgregar = False
        Me.dtfExtorno.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfExtorno.Image = Nothing
        Me.dtfExtorno.Label_Space = 60
        Me.dtfExtorno.Length_Data = 32767
        Me.dtfExtorno.Location = New System.Drawing.Point(154, 0)
        Me.dtfExtorno.Max_Value = 0.0R
        Me.dtfExtorno.MensajeIncorrectoCustom = Nothing
        Me.dtfExtorno.Name = "dtfExtorno"
        Me.dtfExtorno.Null_on_Empty = True
        Me.dtfExtorno.OpenForm = Nothing
        Me.dtfExtorno.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfExtorno.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfExtorno.ReadOnly_Data = False
        Me.dtfExtorno.Show_Button = False
        Me.dtfExtorno.Size = New System.Drawing.Size(148, 26)
        Me.dtfExtorno.TabIndex = 2
        Me.dtfExtorno.Text_Data = ""
        Me.dtfExtorno.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfExtorno.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfExtorno.TopPadding = 0
        Me.dtfExtorno.Upper_Case = False
        Me.dtfExtorno.Validate_on_lost_focus = True
        '
        'pnlSpace35
        '
        Me.pnlSpace35.Auto_Size = False
        Me.pnlSpace35.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace35.ChangeDock = True
        Me.pnlSpace35.Control_Resize = False
        Me.pnlSpace35.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace35.isSpace = True
        Me.pnlSpace35.Location = New System.Drawing.Point(148, 0)
        Me.pnlSpace35.Name = "pnlSpace35"
        Me.pnlSpace35.numRows = 0
        Me.pnlSpace35.Reorder = True
        Me.pnlSpace35.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace35.TabIndex = 1
        '
        'dtfPrimaSeguro
        '
        Me.dtfPrimaSeguro.Allow_Empty = True
        Me.dtfPrimaSeguro.Allow_Negative = True
        Me.dtfPrimaSeguro.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfPrimaSeguro.BackColor = System.Drawing.SystemColors.Control
        Me.dtfPrimaSeguro.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfPrimaSeguro.DataField = "PRIMA"
        Me.dtfPrimaSeguro.DataTable = "V2"
        Me.dtfPrimaSeguro.Descripcion = "Prima"
        Me.dtfPrimaSeguro.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfPrimaSeguro.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfPrimaSeguro.FocoEnAgregar = False
        Me.dtfPrimaSeguro.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfPrimaSeguro.Image = Nothing
        Me.dtfPrimaSeguro.Label_Space = 60
        Me.dtfPrimaSeguro.Length_Data = 32767
        Me.dtfPrimaSeguro.Location = New System.Drawing.Point(0, 0)
        Me.dtfPrimaSeguro.Max_Value = 0.0R
        Me.dtfPrimaSeguro.MensajeIncorrectoCustom = Nothing
        Me.dtfPrimaSeguro.Name = "dtfPrimaSeguro"
        Me.dtfPrimaSeguro.Null_on_Empty = True
        Me.dtfPrimaSeguro.OpenForm = Nothing
        Me.dtfPrimaSeguro.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfPrimaSeguro.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfPrimaSeguro.ReadOnly_Data = False
        Me.dtfPrimaSeguro.Show_Button = False
        Me.dtfPrimaSeguro.Size = New System.Drawing.Size(148, 26)
        Me.dtfPrimaSeguro.TabIndex = 0
        Me.dtfPrimaSeguro.Text_Data = ""
        Me.dtfPrimaSeguro.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfPrimaSeguro.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfPrimaSeguro.TopPadding = 0
        Me.dtfPrimaSeguro.Upper_Case = False
        Me.dtfPrimaSeguro.Validate_on_lost_focus = True
        '
        'pnlFechasSeg
        '
        Me.pnlFechasSeg.Auto_Size = False
        Me.pnlFechasSeg.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlFechasSeg.ChangeDock = True
        Me.pnlFechasSeg.Control_Resize = False
        Me.pnlFechasSeg.Controls.Add(Me.dtlBajaSeg)
        Me.pnlFechasSeg.Controls.Add(Me.Panel19)
        Me.pnlFechasSeg.Controls.Add(Me.dtlVenciSeg)
        Me.pnlFechasSeg.Controls.Add(Me.pnlSpace36)
        Me.pnlFechasSeg.Controls.Add(Me.dtlAltaSeg)
        Me.pnlFechasSeg.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFechasSeg.isSpace = False
        Me.pnlFechasSeg.Location = New System.Drawing.Point(6, 70)
        Me.pnlFechasSeg.Name = "pnlFechasSeg"
        Me.pnlFechasSeg.numRows = 1
        Me.pnlFechasSeg.Reorder = True
        Me.pnlFechasSeg.Size = New System.Drawing.Size(550, 26)
        Me.pnlFechasSeg.TabIndex = 2
        '
        'dtlBajaSeg
        '
        Me.dtlBajaSeg.Allow_Empty = True
        Me.dtlBajaSeg.DataField = "FBAJA_SEGU"
        Me.dtlBajaSeg.DataTable = "V2"
        Me.dtlBajaSeg.Default_Value = New Date(2016, 4, 12, 0, 0, 0, 0)
        Me.dtlBajaSeg.Descripcion = "F.Baja"
        Me.dtlBajaSeg.Dock = System.Windows.Forms.DockStyle.Right
        Me.dtlBajaSeg.FocoEnAgregar = False
        Me.dtlBajaSeg.Label_Space = 43
        Me.dtlBajaSeg.Location = New System.Drawing.Point(415, 0)
        Me.dtlBajaSeg.Max_Value = Nothing
        Me.dtlBajaSeg.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtlBajaSeg.MensajeIncorrectoCustom = Nothing
        Me.dtlBajaSeg.Min_Value = Nothing
        Me.dtlBajaSeg.MinDate = New Date(CType(0, Long))
        Me.dtlBajaSeg.MinimumSize = New System.Drawing.Size(133, 26)
        Me.dtlBajaSeg.Name = "dtlBajaSeg"
        Me.dtlBajaSeg.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtlBajaSeg.ReadOnly_Data = False
        Me.dtlBajaSeg.Size = New System.Drawing.Size(135, 26)
        Me.dtlBajaSeg.TabIndex = 4
        Me.dtlBajaSeg.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtlBajaSeg.Validate_on_lost_focus = True
        Me.dtlBajaSeg.Value_Data = New Date(2016, 4, 12, 0, 0, 0, 0)
        '
        'Panel19
        '
        Me.Panel19.Auto_Size = False
        Me.Panel19.BorderColor = System.Drawing.SystemColors.Control
        Me.Panel19.ChangeDock = True
        Me.Panel19.Control_Resize = False
        Me.Panel19.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel19.isSpace = True
        Me.Panel19.Location = New System.Drawing.Point(291, 0)
        Me.Panel19.Name = "Panel19"
        Me.Panel19.numRows = 0
        Me.Panel19.Reorder = True
        Me.Panel19.Size = New System.Drawing.Size(6, 26)
        Me.Panel19.TabIndex = 3
        '
        'dtlVenciSeg
        '
        Me.dtlVenciSeg.Allow_Empty = True
        Me.dtlVenciSeg.DataField = "VTOSEGU"
        Me.dtlVenciSeg.DataTable = "V2"
        Me.dtlVenciSeg.Default_Value = New Date(2016, 4, 12, 0, 0, 0, 0)
        Me.dtlVenciSeg.Descripcion = "F. Vto."
        Me.dtlVenciSeg.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtlVenciSeg.FocoEnAgregar = False
        Me.dtlVenciSeg.Label_Space = 45
        Me.dtlVenciSeg.Location = New System.Drawing.Point(156, 0)
        Me.dtlVenciSeg.Max_Value = Nothing
        Me.dtlVenciSeg.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtlVenciSeg.MensajeIncorrectoCustom = Nothing
        Me.dtlVenciSeg.Min_Value = Nothing
        Me.dtlVenciSeg.MinDate = New Date(CType(0, Long))
        Me.dtlVenciSeg.MinimumSize = New System.Drawing.Size(135, 26)
        Me.dtlVenciSeg.Name = "dtlVenciSeg"
        Me.dtlVenciSeg.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtlVenciSeg.ReadOnly_Data = False
        Me.dtlVenciSeg.Size = New System.Drawing.Size(135, 26)
        Me.dtlVenciSeg.TabIndex = 2
        Me.dtlVenciSeg.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtlVenciSeg.Validate_on_lost_focus = True
        Me.dtlVenciSeg.Value_Data = New Date(2016, 4, 12, 0, 0, 0, 0)
        '
        'pnlSpace36
        '
        Me.pnlSpace36.Auto_Size = False
        Me.pnlSpace36.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace36.ChangeDock = True
        Me.pnlSpace36.Control_Resize = False
        Me.pnlSpace36.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace36.isSpace = True
        Me.pnlSpace36.Location = New System.Drawing.Point(150, 0)
        Me.pnlSpace36.Name = "pnlSpace36"
        Me.pnlSpace36.numRows = 0
        Me.pnlSpace36.Reorder = True
        Me.pnlSpace36.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace36.TabIndex = 1
        '
        'dtlAltaSeg
        '
        Me.dtlAltaSeg.Allow_Empty = True
        Me.dtlAltaSeg.DataField = "ALTASEGU"
        Me.dtlAltaSeg.DataTable = "V2"
        Me.dtlAltaSeg.Default_Value = New Date(2016, 4, 12, 0, 0, 0, 0)
        Me.dtlAltaSeg.Descripcion = "F. Alta"
        Me.dtlAltaSeg.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtlAltaSeg.FocoEnAgregar = False
        Me.dtlAltaSeg.Label_Space = 60
        Me.dtlAltaSeg.Location = New System.Drawing.Point(0, 0)
        Me.dtlAltaSeg.Max_Value = Nothing
        Me.dtlAltaSeg.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtlAltaSeg.MensajeIncorrectoCustom = Nothing
        Me.dtlAltaSeg.Min_Value = Nothing
        Me.dtlAltaSeg.MinDate = New Date(CType(0, Long))
        Me.dtlAltaSeg.MinimumSize = New System.Drawing.Size(150, 26)
        Me.dtlAltaSeg.Name = "dtlAltaSeg"
        Me.dtlAltaSeg.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtlAltaSeg.ReadOnly_Data = False
        Me.dtlAltaSeg.Size = New System.Drawing.Size(150, 26)
        Me.dtlAltaSeg.TabIndex = 0
        Me.dtlAltaSeg.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtlAltaSeg.Validate_on_lost_focus = True
        Me.dtlAltaSeg.Value_Data = New Date(2016, 4, 12, 0, 0, 0, 0)
        '
        'pnlAgenteFranq
        '
        Me.pnlAgenteFranq.Auto_Size = False
        Me.pnlAgenteFranq.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlAgenteFranq.ChangeDock = True
        Me.pnlAgenteFranq.Control_Resize = False
        Me.pnlAgenteFranq.Controls.Add(Me.dtfAgenteSeg)
        Me.pnlAgenteFranq.Controls.Add(Me.pnlSpace16)
        Me.pnlAgenteFranq.Controls.Add(Me.dtfFranquiciaSeg)
        Me.pnlAgenteFranq.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlAgenteFranq.isSpace = False
        Me.pnlAgenteFranq.Location = New System.Drawing.Point(6, 44)
        Me.pnlAgenteFranq.Name = "pnlAgenteFranq"
        Me.pnlAgenteFranq.numRows = 1
        Me.pnlAgenteFranq.Reorder = True
        Me.pnlAgenteFranq.Size = New System.Drawing.Size(550, 26)
        Me.pnlAgenteFranq.TabIndex = 1
        '
        'dtfAgenteSeg
        '
        Me.dtfAgenteSeg.Allow_Empty = True
        Me.dtfAgenteSeg.Allow_Negative = True
        Me.dtfAgenteSeg.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfAgenteSeg.BackColor = System.Drawing.SystemColors.Control
        Me.dtfAgenteSeg.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfAgenteSeg.DataField = "AGENTE"
        Me.dtfAgenteSeg.DataTable = "V1"
        Me.dtfAgenteSeg.DB = Connection13
        Me.dtfAgenteSeg.Desc_Datafield = "NOMBRE"
        Me.dtfAgenteSeg.Desc_DBPK = "NUM_AG"
        Me.dtfAgenteSeg.Desc_DBTable = "AGENTES"
        Me.dtfAgenteSeg.Desc_Where = Nothing
        Me.dtfAgenteSeg.Desc_WhereObligatoria = Nothing
        Me.dtfAgenteSeg.Descripcion = "Agente"
        Me.dtfAgenteSeg.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfAgenteSeg.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfAgenteSeg.ExtraSQL = ""
        Me.dtfAgenteSeg.FocoEnAgregar = False
        Me.dtfAgenteSeg.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfAgenteSeg.Formulario = Nothing
        Me.dtfAgenteSeg.Label_Space = 60
        Me.dtfAgenteSeg.Length_Data = 32767
        Me.dtfAgenteSeg.Location = New System.Drawing.Point(0, 0)
        Me.dtfAgenteSeg.Lupa = Nothing
        Me.dtfAgenteSeg.Max_Value = 0.0R
        Me.dtfAgenteSeg.MensajeIncorrectoCustom = Nothing
        Me.dtfAgenteSeg.Name = "dtfAgenteSeg"
        Me.dtfAgenteSeg.Null_on_Empty = True
        Me.dtfAgenteSeg.OpenForm = Nothing
        Me.dtfAgenteSeg.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfAgenteSeg.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfAgenteSeg.Query_on_Text_Changed = True
        Me.dtfAgenteSeg.ReadOnly_Data = False
        Me.dtfAgenteSeg.ReQuery = False
        Me.dtfAgenteSeg.ShowButton = True
        Me.dtfAgenteSeg.Size = New System.Drawing.Size(380, 26)
        Me.dtfAgenteSeg.TabIndex = 0
        Me.dtfAgenteSeg.Text_Data = ""
        Me.dtfAgenteSeg.Text_Data_Desc = ""
        Me.dtfAgenteSeg.Text_Width = 60
        Me.dtfAgenteSeg.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfAgenteSeg.TopPadding = 0
        Me.dtfAgenteSeg.Upper_Case = False
        Me.dtfAgenteSeg.Validate_on_lost_focus = True
        '
        'pnlSpace16
        '
        Me.pnlSpace16.Auto_Size = False
        Me.pnlSpace16.BackColor = System.Drawing.Color.Blue
        Me.pnlSpace16.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace16.ChangeDock = True
        Me.pnlSpace16.Control_Resize = False
        Me.pnlSpace16.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSpace16.isSpace = True
        Me.pnlSpace16.Location = New System.Drawing.Point(380, 0)
        Me.pnlSpace16.Name = "pnlSpace16"
        Me.pnlSpace16.numRows = 0
        Me.pnlSpace16.Reorder = True
        Me.pnlSpace16.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace16.TabIndex = 1
        '
        'dtfFranquiciaSeg
        '
        Me.dtfFranquiciaSeg.Allow_Empty = False
        Me.dtfFranquiciaSeg.Allow_Negative = True
        Me.dtfFranquiciaSeg.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfFranquiciaSeg.BackColor = System.Drawing.SystemColors.Control
        Me.dtfFranquiciaSeg.Data_Allowed = CustomControls.Datafield.List_Data.Libre
        Me.dtfFranquiciaSeg.DataField = "FRANQUICIA"
        Me.dtfFranquiciaSeg.DataTable = "V2"
        Me.dtfFranquiciaSeg.Descripcion = "Franquicia"
        Me.dtfFranquiciaSeg.Dock = System.Windows.Forms.DockStyle.Right
        Me.dtfFranquiciaSeg.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfFranquiciaSeg.FocoEnAgregar = False
        Me.dtfFranquiciaSeg.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfFranquiciaSeg.Image = Nothing
        Me.dtfFranquiciaSeg.Label_Space = 70
        Me.dtfFranquiciaSeg.Length_Data = 32767
        Me.dtfFranquiciaSeg.Location = New System.Drawing.Point(386, 0)
        Me.dtfFranquiciaSeg.Max_Value = 0.0R
        Me.dtfFranquiciaSeg.MensajeIncorrectoCustom = Nothing
        Me.dtfFranquiciaSeg.Name = "dtfFranquiciaSeg"
        Me.dtfFranquiciaSeg.Null_on_Empty = True
        Me.dtfFranquiciaSeg.OpenForm = Nothing
        Me.dtfFranquiciaSeg.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfFranquiciaSeg.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfFranquiciaSeg.ReadOnly_Data = False
        Me.dtfFranquiciaSeg.Show_Button = False
        Me.dtfFranquiciaSeg.Size = New System.Drawing.Size(164, 26)
        Me.dtfFranquiciaSeg.TabIndex = 2
        Me.dtfFranquiciaSeg.Text_Data = ""
        Me.dtfFranquiciaSeg.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfFranquiciaSeg.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfFranquiciaSeg.TopPadding = 0
        Me.dtfFranquiciaSeg.Upper_Case = False
        Me.dtfFranquiciaSeg.Validate_on_lost_focus = True
        '
        'Panel6
        '
        Me.Panel6.Auto_Size = False
        Me.Panel6.BorderColor = System.Drawing.SystemColors.Control
        Me.Panel6.ChangeDock = True
        Me.Panel6.Control_Resize = False
        Me.Panel6.Controls.Add(Me.dtfCompañiaSeg)
        Me.Panel6.Controls.Add(Me.pnlSpace17)
        Me.Panel6.Controls.Add(Me.dtfPolizaSeg)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.isSpace = False
        Me.Panel6.Location = New System.Drawing.Point(6, 18)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.numRows = 1
        Me.Panel6.Reorder = True
        '
        '
        '
        Me.Panel6.RootElement.MinSize = New System.Drawing.Size(0, 0)
        Me.Panel6.Size = New System.Drawing.Size(550, 26)
        Me.Panel6.TabIndex = 0
        '
        'dtfCompañiaSeg
        '
        Me.dtfCompañiaSeg.Allow_Empty = True
        Me.dtfCompañiaSeg.Allow_Negative = True
        Me.dtfCompañiaSeg.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfCompañiaSeg.BackColor = System.Drawing.SystemColors.Control
        Me.dtfCompañiaSeg.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfCompañiaSeg.DataField = "CIASEGU"
        Me.dtfCompañiaSeg.DataTable = "V1"
        Me.dtfCompañiaSeg.DB = Connection14
        Me.dtfCompañiaSeg.Desc_Datafield = "NOMBRE"
        Me.dtfCompañiaSeg.Desc_DBPK = "NUM_PROVEE"
        Me.dtfCompañiaSeg.Desc_DBTable = "PROVEE1"
        Me.dtfCompañiaSeg.Desc_Where = Nothing
        Me.dtfCompañiaSeg.Desc_WhereObligatoria = Nothing
        Me.dtfCompañiaSeg.Descripcion = "Compañía"
        Me.dtfCompañiaSeg.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfCompañiaSeg.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfCompañiaSeg.ExtraSQL = ""
        Me.dtfCompañiaSeg.FocoEnAgregar = False
        Me.dtfCompañiaSeg.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfCompañiaSeg.Formulario = Nothing
        Me.dtfCompañiaSeg.Label_Space = 60
        Me.dtfCompañiaSeg.Length_Data = 32767
        Me.dtfCompañiaSeg.Location = New System.Drawing.Point(0, 0)
        Me.dtfCompañiaSeg.Lupa = Nothing
        Me.dtfCompañiaSeg.Max_Value = 0.0R
        Me.dtfCompañiaSeg.MensajeIncorrectoCustom = Nothing
        Me.dtfCompañiaSeg.Name = "dtfCompañiaSeg"
        Me.dtfCompañiaSeg.Null_on_Empty = True
        Me.dtfCompañiaSeg.OpenForm = Nothing
        Me.dtfCompañiaSeg.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfCompañiaSeg.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfCompañiaSeg.Query_on_Text_Changed = True
        Me.dtfCompañiaSeg.ReadOnly_Data = False
        Me.dtfCompañiaSeg.ReQuery = True
        Me.dtfCompañiaSeg.ShowButton = True
        Me.dtfCompañiaSeg.Size = New System.Drawing.Size(380, 26)
        Me.dtfCompañiaSeg.TabIndex = 0
        Me.dtfCompañiaSeg.Text_Data = ""
        Me.dtfCompañiaSeg.Text_Data_Desc = ""
        Me.dtfCompañiaSeg.Text_Width = 60
        Me.dtfCompañiaSeg.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfCompañiaSeg.TopPadding = 0
        Me.dtfCompañiaSeg.Upper_Case = False
        Me.dtfCompañiaSeg.Validate_on_lost_focus = True
        '
        'pnlSpace17
        '
        Me.pnlSpace17.Auto_Size = False
        Me.pnlSpace17.BackColor = System.Drawing.Color.Red
        Me.pnlSpace17.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace17.ChangeDock = True
        Me.pnlSpace17.Control_Resize = False
        Me.pnlSpace17.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSpace17.isSpace = True
        Me.pnlSpace17.Location = New System.Drawing.Point(380, 0)
        Me.pnlSpace17.Name = "pnlSpace17"
        Me.pnlSpace17.numRows = 0
        Me.pnlSpace17.Reorder = True
        Me.pnlSpace17.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace17.TabIndex = 1
        '
        'dtfPolizaSeg
        '
        Me.dtfPolizaSeg.Allow_Empty = False
        Me.dtfPolizaSeg.Allow_Negative = True
        Me.dtfPolizaSeg.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfPolizaSeg.BackColor = System.Drawing.SystemColors.Control
        Me.dtfPolizaSeg.Data_Allowed = CustomControls.Datafield.List_Data.Libre
        Me.dtfPolizaSeg.DataField = "TIPOREV"
        Me.dtfPolizaSeg.DataTable = "V2"
        Me.dtfPolizaSeg.Descripcion = "Póliza"
        Me.dtfPolizaSeg.Dock = System.Windows.Forms.DockStyle.Right
        Me.dtfPolizaSeg.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfPolizaSeg.FocoEnAgregar = False
        Me.dtfPolizaSeg.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfPolizaSeg.Image = Nothing
        Me.dtfPolizaSeg.Label_Space = 35
        Me.dtfPolizaSeg.Length_Data = 32767
        Me.dtfPolizaSeg.Location = New System.Drawing.Point(386, 0)
        Me.dtfPolizaSeg.Max_Value = 0.0R
        Me.dtfPolizaSeg.MensajeIncorrectoCustom = Nothing
        Me.dtfPolizaSeg.Name = "dtfPolizaSeg"
        Me.dtfPolizaSeg.Null_on_Empty = True
        Me.dtfPolizaSeg.OpenForm = Nothing
        Me.dtfPolizaSeg.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfPolizaSeg.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfPolizaSeg.ReadOnly_Data = False
        Me.dtfPolizaSeg.Show_Button = False
        Me.dtfPolizaSeg.Size = New System.Drawing.Size(164, 26)
        Me.dtfPolizaSeg.TabIndex = 2
        Me.dtfPolizaSeg.Text_Data = ""
        Me.dtfPolizaSeg.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfPolizaSeg.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfPolizaSeg.TopPadding = 0
        Me.dtfPolizaSeg.Upper_Case = False
        Me.dtfPolizaSeg.Validate_on_lost_focus = True
        '
        'pnlCabeceraSeguro
        '
        Me.pnlCabeceraSeguro.Auto_Size = False
        Me.pnlCabeceraSeguro.BackColor = System.Drawing.Color.RosyBrown
        Me.pnlCabeceraSeguro.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlCabeceraSeguro.ChangeDock = False
        Me.pnlCabeceraSeguro.Control_Resize = False
        Me.pnlCabeceraSeguro.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCabeceraSeguro.isSpace = False
        Me.pnlCabeceraSeguro.Location = New System.Drawing.Point(0, 0)
        Me.pnlCabeceraSeguro.Name = "pnlCabeceraSeguro"
        Me.pnlCabeceraSeguro.numRows = 0
        Me.pnlCabeceraSeguro.Reorder = True
        Me.pnlCabeceraSeguro.Size = New System.Drawing.Size(1138, 88)
        Me.pnlCabeceraSeguro.TabIndex = 2
        '
        'pvpOtros
        '
        Me.pvpOtros.Controls.Add(Me.pnlOtrosDer)
        Me.pvpOtros.Controls.Add(Me.pnlOtrosIzq)
        Me.pvpOtros.Controls.Add(Me.pnlCabeceraOtros)
        Me.pvpOtros.ItemSize = New System.Drawing.SizeF(102.0!, 23.0!)
        Me.pvpOtros.Location = New System.Drawing.Point(129, 5)
        Me.pvpOtros.Name = "pvpOtros"
        Me.pvpOtros.PanelCabezeraContainer = Me.pnlCabeceraOtros
        Me.pvpOtros.Size = New System.Drawing.Size(1138, 500)
        Me.pvpOtros.Text = "Otros"
        '
        'pnlOtrosDer
        '
        Me.pnlOtrosDer.Auto_Size = False
        Me.pnlOtrosDer.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlOtrosDer.ChangeDock = True
        Me.pnlOtrosDer.Control_Resize = False
        Me.pnlOtrosDer.Controls.Add(Me.pnlGarantiaExt)
        Me.pnlOtrosDer.Controls.Add(Me.pnlPuestaEnServ)
        Me.pnlOtrosDer.Controls.Add(Me.pnlitvOtros)
        Me.pnlOtrosDer.Controls.Add(Me.pnlManteOtros)
        Me.pnlOtrosDer.Controls.Add(Me.pnlContratoOtros)
        Me.pnlOtrosDer.Controls.Add(Me.pnlClienteSit)
        Me.pnlOtrosDer.Controls.Add(Me.pnlSituacionOtros)
        Me.pnlOtrosDer.Controls.Add(Me.pnlUbicacionOtros)
        Me.pnlOtrosDer.Controls.Add(Me.pnlOficinasOtros)
        Me.pnlOtrosDer.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlOtrosDer.isSpace = False
        Me.pnlOtrosDer.Location = New System.Drawing.Point(568, 88)
        Me.pnlOtrosDer.Name = "pnlOtrosDer"
        Me.pnlOtrosDer.numRows = 0
        Me.pnlOtrosDer.Padding = New System.Windows.Forms.Padding(3)
        Me.pnlOtrosDer.Reorder = True
        Me.pnlOtrosDer.Size = New System.Drawing.Size(568, 412)
        Me.pnlOtrosDer.TabIndex = 4
        '
        'pnlGarantiaExt
        '
        Me.pnlGarantiaExt.Auto_Size = False
        Me.pnlGarantiaExt.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlGarantiaExt.ChangeDock = True
        Me.pnlGarantiaExt.Control_Resize = False
        Me.pnlGarantiaExt.Controls.Add(Me.dtfKmsOtros)
        Me.pnlGarantiaExt.Controls.Add(Me.pnlSpace60)
        Me.pnlGarantiaExt.Controls.Add(Me.dtdGarantiaFinOtros)
        Me.pnlGarantiaExt.Controls.Add(Me.pnlSpace59)
        Me.pnlGarantiaExt.Controls.Add(Me.dtdGarantiaOtros)
        Me.pnlGarantiaExt.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlGarantiaExt.isSpace = False
        Me.pnlGarantiaExt.Location = New System.Drawing.Point(3, 211)
        Me.pnlGarantiaExt.Name = "pnlGarantiaExt"
        Me.pnlGarantiaExt.numRows = 1
        Me.pnlGarantiaExt.Reorder = True
        Me.pnlGarantiaExt.Size = New System.Drawing.Size(562, 26)
        Me.pnlGarantiaExt.TabIndex = 8
        '
        'dtfKmsOtros
        '
        Me.dtfKmsOtros.Allow_Empty = True
        Me.dtfKmsOtros.Allow_Negative = True
        Me.dtfKmsOtros.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfKmsOtros.BackColor = System.Drawing.SystemColors.Control
        Me.dtfKmsOtros.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfKmsOtros.DataField = "GAEXT_KM_V1"
        Me.dtfKmsOtros.DataTable = "V1"
        Me.dtfKmsOtros.Descripcion = "Kms"
        Me.dtfKmsOtros.Dock = System.Windows.Forms.DockStyle.Right
        Me.dtfKmsOtros.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfKmsOtros.FocoEnAgregar = False
        Me.dtfKmsOtros.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfKmsOtros.Image = Nothing
        Me.dtfKmsOtros.Label_Space = 35
        Me.dtfKmsOtros.Length_Data = 32767
        Me.dtfKmsOtros.Location = New System.Drawing.Point(452, 0)
        Me.dtfKmsOtros.Max_Value = 0.0R
        Me.dtfKmsOtros.MensajeIncorrectoCustom = Nothing
        Me.dtfKmsOtros.Name = "dtfKmsOtros"
        Me.dtfKmsOtros.Null_on_Empty = True
        Me.dtfKmsOtros.OpenForm = Nothing
        Me.dtfKmsOtros.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfKmsOtros.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfKmsOtros.ReadOnly_Data = False
        Me.dtfKmsOtros.Show_Button = False
        Me.dtfKmsOtros.Size = New System.Drawing.Size(110, 26)
        Me.dtfKmsOtros.TabIndex = 4
        Me.dtfKmsOtros.Text_Data = ""
        Me.dtfKmsOtros.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfKmsOtros.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfKmsOtros.TopPadding = 0
        Me.dtfKmsOtros.Upper_Case = False
        Me.dtfKmsOtros.Validate_on_lost_focus = True
        '
        'pnlSpace60
        '
        Me.pnlSpace60.Auto_Size = False
        Me.pnlSpace60.BackColor = System.Drawing.Color.Red
        Me.pnlSpace60.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace60.ChangeDock = True
        Me.pnlSpace60.Control_Resize = False
        Me.pnlSpace60.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace60.isSpace = True
        Me.pnlSpace60.Location = New System.Drawing.Point(356, 0)
        Me.pnlSpace60.Name = "pnlSpace60"
        Me.pnlSpace60.numRows = 0
        Me.pnlSpace60.Reorder = True
        Me.pnlSpace60.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace60.TabIndex = 3
        '
        'dtdGarantiaFinOtros
        '
        Me.dtdGarantiaFinOtros.Allow_Empty = True
        Me.dtdGarantiaFinOtros.DataField = "GAEXT_FFIN_V1"
        Me.dtdGarantiaFinOtros.DataTable = "V1"
        Me.dtdGarantiaFinOtros.Default_Value = New Date(2016, 5, 10, 0, 0, 0, 0)
        Me.dtdGarantiaFinOtros.Descripcion = "Fin:"
        Me.dtdGarantiaFinOtros.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtdGarantiaFinOtros.FocoEnAgregar = False
        Me.dtdGarantiaFinOtros.Label_Space = 30
        Me.dtdGarantiaFinOtros.Location = New System.Drawing.Point(236, 0)
        Me.dtdGarantiaFinOtros.Max_Value = Nothing
        Me.dtdGarantiaFinOtros.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdGarantiaFinOtros.MensajeIncorrectoCustom = Nothing
        Me.dtdGarantiaFinOtros.Min_Value = Nothing
        Me.dtdGarantiaFinOtros.MinDate = New Date(CType(0, Long))
        Me.dtdGarantiaFinOtros.MinimumSize = New System.Drawing.Size(120, 26)
        Me.dtdGarantiaFinOtros.Name = "dtdGarantiaFinOtros"
        Me.dtdGarantiaFinOtros.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdGarantiaFinOtros.ReadOnly_Data = False
        Me.dtdGarantiaFinOtros.Size = New System.Drawing.Size(120, 26)
        Me.dtdGarantiaFinOtros.TabIndex = 2
        Me.dtdGarantiaFinOtros.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdGarantiaFinOtros.Validate_on_lost_focus = True
        Me.dtdGarantiaFinOtros.Value_Data = New Date(2016, 5, 10, 0, 0, 0, 0)
        '
        'pnlSpace59
        '
        Me.pnlSpace59.Auto_Size = False
        Me.pnlSpace59.BackColor = System.Drawing.Color.Red
        Me.pnlSpace59.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace59.ChangeDock = True
        Me.pnlSpace59.Control_Resize = False
        Me.pnlSpace59.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace59.isSpace = True
        Me.pnlSpace59.Location = New System.Drawing.Point(230, 0)
        Me.pnlSpace59.Name = "pnlSpace59"
        Me.pnlSpace59.numRows = 0
        Me.pnlSpace59.Reorder = True
        Me.pnlSpace59.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace59.TabIndex = 1
        '
        'dtdGarantiaOtros
        '
        Me.dtdGarantiaOtros.Allow_Empty = True
        Me.dtdGarantiaOtros.DataField = "GAEXT_FINI_V1"
        Me.dtdGarantiaOtros.DataTable = "V1"
        Me.dtdGarantiaOtros.Default_Value = New Date(2016, 5, 10, 0, 0, 0, 0)
        Me.dtdGarantiaOtros.Descripcion = "Garantía Exten.: Ini."
        Me.dtdGarantiaOtros.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtdGarantiaOtros.FocoEnAgregar = False
        Me.dtdGarantiaOtros.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtdGarantiaOtros.Label_Space = 140
        Me.dtdGarantiaOtros.Location = New System.Drawing.Point(0, 0)
        Me.dtdGarantiaOtros.Max_Value = Nothing
        Me.dtdGarantiaOtros.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdGarantiaOtros.MensajeIncorrectoCustom = Nothing
        Me.dtdGarantiaOtros.Min_Value = Nothing
        Me.dtdGarantiaOtros.MinDate = New Date(CType(0, Long))
        Me.dtdGarantiaOtros.MinimumSize = New System.Drawing.Size(230, 26)
        Me.dtdGarantiaOtros.Name = "dtdGarantiaOtros"
        Me.dtdGarantiaOtros.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdGarantiaOtros.ReadOnly_Data = False
        Me.dtdGarantiaOtros.Size = New System.Drawing.Size(230, 26)
        Me.dtdGarantiaOtros.TabIndex = 0
        Me.dtdGarantiaOtros.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdGarantiaOtros.Validate_on_lost_focus = True
        Me.dtdGarantiaOtros.Value_Data = New Date(2016, 5, 10, 0, 0, 0, 0)
        '
        'pnlPuestaEnServ
        '
        Me.pnlPuestaEnServ.Auto_Size = False
        Me.pnlPuestaEnServ.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlPuestaEnServ.ChangeDock = True
        Me.pnlPuestaEnServ.Control_Resize = False
        Me.pnlPuestaEnServ.Controls.Add(Me.btnDocVeh)
        Me.pnlPuestaEnServ.Controls.Add(Me.pnlSpace58)
        Me.pnlPuestaEnServ.Controls.Add(Me.dtdServicioFinOtros)
        Me.pnlPuestaEnServ.Controls.Add(Me.pnlSpace57)
        Me.pnlPuestaEnServ.Controls.Add(Me.dtdServicioOtros)
        Me.pnlPuestaEnServ.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlPuestaEnServ.isSpace = False
        Me.pnlPuestaEnServ.Location = New System.Drawing.Point(3, 185)
        Me.pnlPuestaEnServ.Name = "pnlPuestaEnServ"
        Me.pnlPuestaEnServ.numRows = 1
        Me.pnlPuestaEnServ.Reorder = True
        Me.pnlPuestaEnServ.Size = New System.Drawing.Size(562, 26)
        Me.pnlPuestaEnServ.TabIndex = 7
        '
        'btnDocVeh
        '
        Me.btnDocVeh.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnDocVeh.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnDocVeh.Location = New System.Drawing.Point(487, 0)
        Me.btnDocVeh.Name = "btnDocVeh"
        Me.btnDocVeh.Size = New System.Drawing.Size(75, 26)
        Me.btnDocVeh.TabIndex = 4
        Me.btnDocVeh.Text = "Doc.Vehi"
        Me.btnDocVeh.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.btnDocVeh.ThemeName = "Windows8"
        '
        'pnlSpace58
        '
        Me.pnlSpace58.Auto_Size = False
        Me.pnlSpace58.BackColor = System.Drawing.Color.Red
        Me.pnlSpace58.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace58.ChangeDock = True
        Me.pnlSpace58.Control_Resize = False
        Me.pnlSpace58.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace58.isSpace = True
        Me.pnlSpace58.Location = New System.Drawing.Point(356, 0)
        Me.pnlSpace58.Name = "pnlSpace58"
        Me.pnlSpace58.numRows = 0
        Me.pnlSpace58.Reorder = True
        Me.pnlSpace58.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace58.TabIndex = 3
        '
        'dtdServicioFinOtros
        '
        Me.dtdServicioFinOtros.Allow_Empty = True
        Me.dtdServicioFinOtros.DataField = "PSERV_FFIN_V1"
        Me.dtdServicioFinOtros.DataTable = "V1"
        Me.dtdServicioFinOtros.Default_Value = New Date(2016, 5, 10, 0, 0, 0, 0)
        Me.dtdServicioFinOtros.Descripcion = "Fin:"
        Me.dtdServicioFinOtros.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtdServicioFinOtros.FocoEnAgregar = False
        Me.dtdServicioFinOtros.Label_Space = 30
        Me.dtdServicioFinOtros.Location = New System.Drawing.Point(236, 0)
        Me.dtdServicioFinOtros.Max_Value = Nothing
        Me.dtdServicioFinOtros.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdServicioFinOtros.MensajeIncorrectoCustom = Nothing
        Me.dtdServicioFinOtros.Min_Value = Nothing
        Me.dtdServicioFinOtros.MinDate = New Date(CType(0, Long))
        Me.dtdServicioFinOtros.MinimumSize = New System.Drawing.Size(120, 26)
        Me.dtdServicioFinOtros.Name = "dtdServicioFinOtros"
        Me.dtdServicioFinOtros.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdServicioFinOtros.ReadOnly_Data = False
        Me.dtdServicioFinOtros.Size = New System.Drawing.Size(120, 26)
        Me.dtdServicioFinOtros.TabIndex = 2
        Me.dtdServicioFinOtros.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdServicioFinOtros.Validate_on_lost_focus = True
        Me.dtdServicioFinOtros.Value_Data = New Date(2016, 5, 10, 0, 0, 0, 0)
        '
        'pnlSpace57
        '
        Me.pnlSpace57.Auto_Size = False
        Me.pnlSpace57.BackColor = System.Drawing.Color.Red
        Me.pnlSpace57.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace57.ChangeDock = True
        Me.pnlSpace57.Control_Resize = False
        Me.pnlSpace57.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace57.isSpace = True
        Me.pnlSpace57.Location = New System.Drawing.Point(230, 0)
        Me.pnlSpace57.Name = "pnlSpace57"
        Me.pnlSpace57.numRows = 0
        Me.pnlSpace57.Reorder = True
        Me.pnlSpace57.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace57.TabIndex = 1
        '
        'dtdServicioOtros
        '
        Me.dtdServicioOtros.Allow_Empty = True
        Me.dtdServicioOtros.DataField = "PSERV_FINI_V1"
        Me.dtdServicioOtros.DataTable = "V1"
        Me.dtdServicioOtros.Default_Value = New Date(2016, 5, 10, 0, 0, 0, 0)
        Me.dtdServicioOtros.Descripcion = "Puesta en Servicio: Ini."
        Me.dtdServicioOtros.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtdServicioOtros.FocoEnAgregar = False
        Me.dtdServicioOtros.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtdServicioOtros.Label_Space = 140
        Me.dtdServicioOtros.Location = New System.Drawing.Point(0, 0)
        Me.dtdServicioOtros.Max_Value = Nothing
        Me.dtdServicioOtros.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdServicioOtros.MensajeIncorrectoCustom = Nothing
        Me.dtdServicioOtros.Min_Value = Nothing
        Me.dtdServicioOtros.MinDate = New Date(CType(0, Long))
        Me.dtdServicioOtros.MinimumSize = New System.Drawing.Size(230, 26)
        Me.dtdServicioOtros.Name = "dtdServicioOtros"
        Me.dtdServicioOtros.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdServicioOtros.ReadOnly_Data = False
        Me.dtdServicioOtros.Size = New System.Drawing.Size(230, 26)
        Me.dtdServicioOtros.TabIndex = 0
        Me.dtdServicioOtros.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdServicioOtros.Validate_on_lost_focus = True
        Me.dtdServicioOtros.Value_Data = New Date(2016, 5, 10, 0, 0, 0, 0)
        '
        'pnlitvOtros
        '
        Me.pnlitvOtros.Auto_Size = False
        Me.pnlitvOtros.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlitvOtros.ChangeDock = True
        Me.pnlitvOtros.Control_Resize = False
        Me.pnlitvOtros.Controls.Add(Me.dtdProximaITV)
        Me.pnlitvOtros.Controls.Add(Me.pnlSpace56)
        Me.pnlitvOtros.Controls.Add(Me.dtdUltimaITV)
        Me.pnlitvOtros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlitvOtros.isSpace = False
        Me.pnlitvOtros.Location = New System.Drawing.Point(3, 159)
        Me.pnlitvOtros.Name = "pnlitvOtros"
        Me.pnlitvOtros.numRows = 1
        Me.pnlitvOtros.Reorder = True
        Me.pnlitvOtros.Size = New System.Drawing.Size(562, 26)
        Me.pnlitvOtros.TabIndex = 6
        '
        'dtdProximaITV
        '
        Me.dtdProximaITV.Allow_Empty = True
        Me.dtdProximaITV.DataField = "FITV2"
        Me.dtdProximaITV.DataTable = "V2"
        Me.dtdProximaITV.Default_Value = New Date(2016, 5, 10, 0, 0, 0, 0)
        Me.dtdProximaITV.Descripcion = "Próxima:"
        Me.dtdProximaITV.Dock = System.Windows.Forms.DockStyle.Right
        Me.dtdProximaITV.FocoEnAgregar = False
        Me.dtdProximaITV.Label_Space = 55
        Me.dtdProximaITV.Location = New System.Drawing.Point(417, 0)
        Me.dtdProximaITV.Max_Value = Nothing
        Me.dtdProximaITV.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdProximaITV.MensajeIncorrectoCustom = Nothing
        Me.dtdProximaITV.Min_Value = Nothing
        Me.dtdProximaITV.MinDate = New Date(CType(0, Long))
        Me.dtdProximaITV.MinimumSize = New System.Drawing.Size(145, 26)
        Me.dtdProximaITV.Name = "dtdProximaITV"
        Me.dtdProximaITV.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdProximaITV.ReadOnly_Data = False
        Me.dtdProximaITV.Size = New System.Drawing.Size(145, 26)
        Me.dtdProximaITV.TabIndex = 2
        Me.dtdProximaITV.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdProximaITV.Validate_on_lost_focus = True
        Me.dtdProximaITV.Value_Data = New Date(2016, 5, 10, 0, 0, 0, 0)
        '
        'pnlSpace56
        '
        Me.pnlSpace56.Auto_Size = False
        Me.pnlSpace56.BackColor = System.Drawing.Color.Red
        Me.pnlSpace56.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace56.ChangeDock = True
        Me.pnlSpace56.Control_Resize = False
        Me.pnlSpace56.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace56.isSpace = True
        Me.pnlSpace56.Location = New System.Drawing.Point(280, 0)
        Me.pnlSpace56.Name = "pnlSpace56"
        Me.pnlSpace56.numRows = 0
        Me.pnlSpace56.Reorder = True
        Me.pnlSpace56.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace56.TabIndex = 1
        '
        'dtdUltimaITV
        '
        Me.dtdUltimaITV.Allow_Empty = True
        Me.dtdUltimaITV.DataField = "FITV"
        Me.dtdUltimaITV.DataTable = "V2"
        Me.dtdUltimaITV.Default_Value = New Date(2016, 5, 10, 0, 0, 0, 0)
        Me.dtdUltimaITV.Descripcion = "Última ITV"
        Me.dtdUltimaITV.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtdUltimaITV.FocoEnAgregar = False
        Me.dtdUltimaITV.Label_Space = 190
        Me.dtdUltimaITV.Location = New System.Drawing.Point(0, 0)
        Me.dtdUltimaITV.Max_Value = Nothing
        Me.dtdUltimaITV.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdUltimaITV.MensajeIncorrectoCustom = Nothing
        Me.dtdUltimaITV.Min_Value = Nothing
        Me.dtdUltimaITV.MinDate = New Date(CType(0, Long))
        Me.dtdUltimaITV.MinimumSize = New System.Drawing.Size(280, 26)
        Me.dtdUltimaITV.Name = "dtdUltimaITV"
        Me.dtdUltimaITV.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdUltimaITV.ReadOnly_Data = False
        Me.dtdUltimaITV.Size = New System.Drawing.Size(280, 26)
        Me.dtdUltimaITV.TabIndex = 0
        Me.dtdUltimaITV.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdUltimaITV.Validate_on_lost_focus = True
        Me.dtdUltimaITV.Value_Data = New Date(2016, 5, 10, 0, 0, 0, 0)
        '
        'pnlManteOtros
        '
        Me.pnlManteOtros.Auto_Size = False
        Me.pnlManteOtros.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlManteOtros.ChangeDock = True
        Me.pnlManteOtros.Control_Resize = False
        Me.pnlManteOtros.Controls.Add(Me.dtdHastaMante)
        Me.pnlManteOtros.Controls.Add(Me.pnlSpace55)
        Me.pnlManteOtros.Controls.Add(Me.dtdManteOtros)
        Me.pnlManteOtros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlManteOtros.isSpace = False
        Me.pnlManteOtros.Location = New System.Drawing.Point(3, 133)
        Me.pnlManteOtros.Name = "pnlManteOtros"
        Me.pnlManteOtros.numRows = 1
        Me.pnlManteOtros.Reorder = True
        Me.pnlManteOtros.Size = New System.Drawing.Size(562, 26)
        Me.pnlManteOtros.TabIndex = 5
        '
        'dtdHastaMante
        '
        Me.dtdHastaMante.Allow_Empty = True
        Me.dtdHastaMante.DataField = "CONTRAMAN_HASTA"
        Me.dtdHastaMante.DataTable = "V1"
        Me.dtdHastaMante.Default_Value = New Date(2016, 5, 10, 0, 0, 0, 0)
        Me.dtdHastaMante.Descripcion = "Hasta:"
        Me.dtdHastaMante.Dock = System.Windows.Forms.DockStyle.Right
        Me.dtdHastaMante.FocoEnAgregar = False
        Me.dtdHastaMante.Label_Space = 55
        Me.dtdHastaMante.Location = New System.Drawing.Point(417, 0)
        Me.dtdHastaMante.Max_Value = Nothing
        Me.dtdHastaMante.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdHastaMante.MensajeIncorrectoCustom = Nothing
        Me.dtdHastaMante.Min_Value = Nothing
        Me.dtdHastaMante.MinDate = New Date(CType(0, Long))
        Me.dtdHastaMante.MinimumSize = New System.Drawing.Size(145, 26)
        Me.dtdHastaMante.Name = "dtdHastaMante"
        Me.dtdHastaMante.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdHastaMante.ReadOnly_Data = False
        Me.dtdHastaMante.Size = New System.Drawing.Size(145, 26)
        Me.dtdHastaMante.TabIndex = 2
        Me.dtdHastaMante.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdHastaMante.Validate_on_lost_focus = True
        Me.dtdHastaMante.Value_Data = New Date(2016, 5, 10, 0, 0, 0, 0)
        '
        'pnlSpace55
        '
        Me.pnlSpace55.Auto_Size = False
        Me.pnlSpace55.BackColor = System.Drawing.Color.Red
        Me.pnlSpace55.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace55.ChangeDock = True
        Me.pnlSpace55.Control_Resize = False
        Me.pnlSpace55.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace55.isSpace = True
        Me.pnlSpace55.Location = New System.Drawing.Point(280, 0)
        Me.pnlSpace55.Name = "pnlSpace55"
        Me.pnlSpace55.numRows = 0
        Me.pnlSpace55.Reorder = True
        Me.pnlSpace55.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace55.TabIndex = 1
        '
        'dtdManteOtros
        '
        Me.dtdManteOtros.Allow_Empty = True
        Me.dtdManteOtros.DataField = "CONTRAMAN_DESDE"
        Me.dtdManteOtros.DataTable = "V1"
        Me.dtdManteOtros.Default_Value = New Date(2016, 5, 10, 0, 0, 0, 0)
        Me.dtdManteOtros.Descripcion = "Contrato Mantenimiento Desde:"
        Me.dtdManteOtros.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtdManteOtros.FocoEnAgregar = False
        Me.dtdManteOtros.Label_Space = 190
        Me.dtdManteOtros.Location = New System.Drawing.Point(0, 0)
        Me.dtdManteOtros.Max_Value = Nothing
        Me.dtdManteOtros.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdManteOtros.MensajeIncorrectoCustom = Nothing
        Me.dtdManteOtros.Min_Value = Nothing
        Me.dtdManteOtros.MinDate = New Date(CType(0, Long))
        Me.dtdManteOtros.MinimumSize = New System.Drawing.Size(280, 26)
        Me.dtdManteOtros.Name = "dtdManteOtros"
        Me.dtdManteOtros.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdManteOtros.ReadOnly_Data = False
        Me.dtdManteOtros.Size = New System.Drawing.Size(280, 26)
        Me.dtdManteOtros.TabIndex = 0
        Me.dtdManteOtros.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdManteOtros.Validate_on_lost_focus = True
        Me.dtdManteOtros.Value_Data = New Date(2016, 5, 10, 0, 0, 0, 0)
        '
        'pnlContratoOtros
        '
        Me.pnlContratoOtros.Auto_Size = False
        Me.pnlContratoOtros.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlContratoOtros.ChangeDock = True
        Me.pnlContratoOtros.Control_Resize = False
        Me.pnlContratoOtros.Controls.Add(Me.dtfConductorSit2)
        Me.pnlContratoOtros.Controls.Add(Me.pnlSpace54)
        Me.pnlContratoOtros.Controls.Add(Me.dtdFRetornoOtros)
        Me.pnlContratoOtros.Controls.Add(Me.pnlSpace53)
        Me.pnlContratoOtros.Controls.Add(Me.dtfContratoOtros)
        Me.pnlContratoOtros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlContratoOtros.isSpace = False
        Me.pnlContratoOtros.Location = New System.Drawing.Point(3, 107)
        Me.pnlContratoOtros.Name = "pnlContratoOtros"
        Me.pnlContratoOtros.numRows = 1
        Me.pnlContratoOtros.Reorder = True
        Me.pnlContratoOtros.Size = New System.Drawing.Size(562, 26)
        Me.pnlContratoOtros.TabIndex = 4
        '
        'dtfConductorSit2
        '
        Me.dtfConductorSit2.Allow_Empty = True
        Me.dtfConductorSit2.Allow_Negative = True
        Me.dtfConductorSit2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfConductorSit2.BackColor = System.Drawing.SystemColors.Control
        Me.dtfConductorSit2.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfConductorSit2.DataField = Nothing
        Me.dtfConductorSit2.DataTable = ""
        Me.dtfConductorSit2.Descripcion = Nothing
        Me.dtfConductorSit2.Dock = System.Windows.Forms.DockStyle.Right
        Me.dtfConductorSit2.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfConductorSit2.FocoEnAgregar = False
        Me.dtfConductorSit2.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfConductorSit2.Length_Data = 32767
        Me.dtfConductorSit2.Location = New System.Drawing.Point(417, 0)
        Me.dtfConductorSit2.Max_Value = 0.0R
        Me.dtfConductorSit2.MensajeIncorrectoCustom = Nothing
        Me.dtfConductorSit2.Name = "dtfConductorSit2"
        Me.dtfConductorSit2.Null_on_Empty = True
        Me.dtfConductorSit2.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfConductorSit2.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfConductorSit2.ReadOnly_Data = True
        Me.dtfConductorSit2.Size = New System.Drawing.Size(145, 26)
        Me.dtfConductorSit2.TabIndex = 4
        Me.dtfConductorSit2.TabStop = False
        Me.dtfConductorSit2.Text_Data = ""
        Me.dtfConductorSit2.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfConductorSit2.TopPadding = 0
        Me.dtfConductorSit2.Upper_Case = False
        Me.dtfConductorSit2.Validate_on_lost_focus = True
        '
        'pnlSpace54
        '
        Me.pnlSpace54.Auto_Size = False
        Me.pnlSpace54.BackColor = System.Drawing.Color.Red
        Me.pnlSpace54.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace54.ChangeDock = True
        Me.pnlSpace54.Control_Resize = False
        Me.pnlSpace54.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace54.isSpace = True
        Me.pnlSpace54.Location = New System.Drawing.Point(351, 0)
        Me.pnlSpace54.Name = "pnlSpace54"
        Me.pnlSpace54.numRows = 0
        Me.pnlSpace54.Reorder = True
        Me.pnlSpace54.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace54.TabIndex = 3
        '
        'dtdFRetornoOtros
        '
        Me.dtdFRetornoOtros.Allow_Empty = True
        Me.dtdFRetornoOtros.DataField = "FECHADEV"
        Me.dtdFRetornoOtros.DataTable = "V1"
        Me.dtdFRetornoOtros.Default_Value = New Date(2016, 5, 10, 0, 0, 0, 0)
        Me.dtdFRetornoOtros.Descripcion = "Retorno"
        Me.dtdFRetornoOtros.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtdFRetornoOtros.FocoEnAgregar = False
        Me.dtdFRetornoOtros.Label_Space = 55
        Me.dtdFRetornoOtros.Location = New System.Drawing.Point(206, 0)
        Me.dtdFRetornoOtros.Max_Value = Nothing
        Me.dtdFRetornoOtros.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdFRetornoOtros.MensajeIncorrectoCustom = Nothing
        Me.dtdFRetornoOtros.Min_Value = Nothing
        Me.dtdFRetornoOtros.MinDate = New Date(CType(0, Long))
        Me.dtdFRetornoOtros.MinimumSize = New System.Drawing.Size(145, 26)
        Me.dtdFRetornoOtros.Name = "dtdFRetornoOtros"
        Me.dtdFRetornoOtros.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdFRetornoOtros.ReadOnly_Data = False
        Me.dtdFRetornoOtros.Size = New System.Drawing.Size(145, 26)
        Me.dtdFRetornoOtros.TabIndex = 2
        Me.dtdFRetornoOtros.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdFRetornoOtros.Validate_on_lost_focus = True
        Me.dtdFRetornoOtros.Value_Data = New Date(2016, 5, 10, 0, 0, 0, 0)
        '
        'pnlSpace53
        '
        Me.pnlSpace53.Auto_Size = False
        Me.pnlSpace53.BackColor = System.Drawing.Color.Red
        Me.pnlSpace53.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace53.ChangeDock = True
        Me.pnlSpace53.Control_Resize = False
        Me.pnlSpace53.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace53.isSpace = True
        Me.pnlSpace53.Location = New System.Drawing.Point(200, 0)
        Me.pnlSpace53.Name = "pnlSpace53"
        Me.pnlSpace53.numRows = 0
        Me.pnlSpace53.Reorder = True
        Me.pnlSpace53.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace53.TabIndex = 1
        '
        'dtfContratoOtros
        '
        Me.dtfContratoOtros.Allow_Empty = True
        Me.dtfContratoOtros.Allow_Negative = True
        Me.dtfContratoOtros.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfContratoOtros.BackColor = System.Drawing.SystemColors.Control
        Me.dtfContratoOtros.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfContratoOtros.DataField = Nothing
        Me.dtfContratoOtros.DataTable = ""
        Me.dtfContratoOtros.Descripcion = "Contrato"
        Me.dtfContratoOtros.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfContratoOtros.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfContratoOtros.FocoEnAgregar = False
        Me.dtfContratoOtros.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfContratoOtros.Image = Nothing
        Me.dtfContratoOtros.Label_Space = 65
        Me.dtfContratoOtros.Length_Data = 32767
        Me.dtfContratoOtros.Location = New System.Drawing.Point(0, 0)
        Me.dtfContratoOtros.Max_Value = 0.0R
        Me.dtfContratoOtros.MensajeIncorrectoCustom = Nothing
        Me.dtfContratoOtros.Name = "dtfContratoOtros"
        Me.dtfContratoOtros.Null_on_Empty = True
        Me.dtfContratoOtros.OpenForm = "Karve.frm.RentACar.Contratos.vb"
        Me.dtfContratoOtros.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfContratoOtros.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfContratoOtros.ReadOnly_Data = True
        Me.dtfContratoOtros.Show_Button = True
        Me.dtfContratoOtros.Size = New System.Drawing.Size(200, 26)
        Me.dtfContratoOtros.TabIndex = 0
        Me.dtfContratoOtros.TabStop = False
        Me.dtfContratoOtros.Text_Data = ""
        Me.dtfContratoOtros.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfContratoOtros.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfContratoOtros.TopPadding = 0
        Me.dtfContratoOtros.Upper_Case = False
        Me.dtfContratoOtros.Validate_on_lost_focus = True
        '
        'pnlClienteSit
        '
        Me.pnlClienteSit.Auto_Size = False
        Me.pnlClienteSit.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlClienteSit.ChangeDock = True
        Me.pnlClienteSit.Control_Resize = False
        Me.pnlClienteSit.Controls.Add(Me.dtfConductorSit)
        Me.pnlClienteSit.Controls.Add(Me.pnlSpace52)
        Me.pnlClienteSit.Controls.Add(Me.dtfClienteSitu)
        Me.pnlClienteSit.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlClienteSit.isSpace = False
        Me.pnlClienteSit.Location = New System.Drawing.Point(3, 81)
        Me.pnlClienteSit.Name = "pnlClienteSit"
        Me.pnlClienteSit.numRows = 1
        Me.pnlClienteSit.Reorder = True
        Me.pnlClienteSit.Size = New System.Drawing.Size(562, 26)
        Me.pnlClienteSit.TabIndex = 3
        '
        'dtfConductorSit
        '
        Me.dtfConductorSit.Allow_Empty = True
        Me.dtfConductorSit.Allow_Negative = True
        Me.dtfConductorSit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfConductorSit.BackColor = System.Drawing.SystemColors.Control
        Me.dtfConductorSit.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfConductorSit.DataField = Nothing
        Me.dtfConductorSit.DataTable = ""
        Me.dtfConductorSit.Descripcion = Nothing
        Me.dtfConductorSit.Dock = System.Windows.Forms.DockStyle.Right
        Me.dtfConductorSit.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfConductorSit.FocoEnAgregar = False
        Me.dtfConductorSit.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfConductorSit.Length_Data = 32767
        Me.dtfConductorSit.Location = New System.Drawing.Point(417, 0)
        Me.dtfConductorSit.Max_Value = 0.0R
        Me.dtfConductorSit.MensajeIncorrectoCustom = Nothing
        Me.dtfConductorSit.Name = "dtfConductorSit"
        Me.dtfConductorSit.Null_on_Empty = True
        Me.dtfConductorSit.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfConductorSit.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfConductorSit.ReadOnly_Data = True
        Me.dtfConductorSit.Size = New System.Drawing.Size(145, 26)
        Me.dtfConductorSit.TabIndex = 2
        Me.dtfConductorSit.TabStop = False
        Me.dtfConductorSit.Text_Data = ""
        Me.dtfConductorSit.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfConductorSit.TopPadding = 0
        Me.dtfConductorSit.Upper_Case = False
        Me.dtfConductorSit.Validate_on_lost_focus = True
        '
        'pnlSpace52
        '
        Me.pnlSpace52.Auto_Size = False
        Me.pnlSpace52.BackColor = System.Drawing.Color.Red
        Me.pnlSpace52.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace52.ChangeDock = True
        Me.pnlSpace52.Control_Resize = False
        Me.pnlSpace52.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace52.isSpace = True
        Me.pnlSpace52.Location = New System.Drawing.Point(349, 0)
        Me.pnlSpace52.Name = "pnlSpace52"
        Me.pnlSpace52.numRows = 0
        Me.pnlSpace52.Reorder = True
        Me.pnlSpace52.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace52.TabIndex = 1
        '
        'dtfClienteSitu
        '
        Me.dtfClienteSitu.Allow_Empty = True
        Me.dtfClienteSitu.Allow_Negative = True
        Me.dtfClienteSitu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfClienteSitu.BackColor = System.Drawing.SystemColors.Control
        Me.dtfClienteSitu.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfClienteSitu.DataField = "cliente"
        Me.dtfClienteSitu.DataTable = "V1"
        Me.dtfClienteSitu.DB = Connection5
        Me.dtfClienteSitu.Desc_Datafield = "NOMBRE n2"
        Me.dtfClienteSitu.Desc_DBPK = "NUMERO_CLI"
        Me.dtfClienteSitu.Desc_DBTable = "CLIENTES1"
        Me.dtfClienteSitu.Desc_Where = Nothing
        Me.dtfClienteSitu.Desc_WhereObligatoria = Nothing
        Me.dtfClienteSitu.Descripcion = "Cliente"
        Me.dtfClienteSitu.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfClienteSitu.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfClienteSitu.ExtraSQL = ""
        Me.dtfClienteSitu.FocoEnAgregar = False
        Me.dtfClienteSitu.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfClienteSitu.Formulario = Nothing
        Me.dtfClienteSitu.Label_Space = 65
        Me.dtfClienteSitu.Length_Data = 32767
        Me.dtfClienteSitu.Location = New System.Drawing.Point(0, 0)
        Me.dtfClienteSitu.Lupa = Nothing
        Me.dtfClienteSitu.Max_Value = 0.0R
        Me.dtfClienteSitu.MensajeIncorrectoCustom = Nothing
        Me.dtfClienteSitu.Name = "dtfClienteSitu"
        Me.dtfClienteSitu.Null_on_Empty = True
        Me.dtfClienteSitu.OpenForm = Nothing
        Me.dtfClienteSitu.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfClienteSitu.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfClienteSitu.Query_on_Text_Changed = True
        Me.dtfClienteSitu.ReadOnly_Data = True
        Me.dtfClienteSitu.ReQuery = True
        Me.dtfClienteSitu.ShowButton = False
        Me.dtfClienteSitu.Size = New System.Drawing.Size(349, 26)
        Me.dtfClienteSitu.TabIndex = 0
        Me.dtfClienteSitu.TabStop = False
        Me.dtfClienteSitu.Text_Data = ""
        Me.dtfClienteSitu.Text_Data_Desc = ""
        Me.dtfClienteSitu.Text_Width = 60
        Me.dtfClienteSitu.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfClienteSitu.TopPadding = 0
        Me.dtfClienteSitu.Upper_Case = False
        Me.dtfClienteSitu.Validate_on_lost_focus = True
        '
        'pnlSituacionOtros
        '
        Me.pnlSituacionOtros.Auto_Size = False
        Me.pnlSituacionOtros.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSituacionOtros.ChangeDock = True
        Me.pnlSituacionOtros.Control_Resize = False
        Me.pnlSituacionOtros.Controls.Add(Me.DataCheck1)
        Me.pnlSituacionOtros.Controls.Add(Me.pnlSpace51)
        Me.pnlSituacionOtros.Controls.Add(Me.btnRecalcularSit)
        Me.pnlSituacionOtros.Controls.Add(Me.pnlSpace50)
        Me.pnlSituacionOtros.Controls.Add(Me.dtfSituacionOtros)
        Me.pnlSituacionOtros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlSituacionOtros.isSpace = False
        Me.pnlSituacionOtros.Location = New System.Drawing.Point(3, 55)
        Me.pnlSituacionOtros.Name = "pnlSituacionOtros"
        Me.pnlSituacionOtros.numRows = 1
        Me.pnlSituacionOtros.Reorder = True
        Me.pnlSituacionOtros.Size = New System.Drawing.Size(562, 26)
        Me.pnlSituacionOtros.TabIndex = 2
        '
        'DataCheck1
        '
        Me.DataCheck1.DataField = "VER_EN_PLANNING"
        Me.DataCheck1.DataTable = "V1"
        Me.DataCheck1.Descripcion = "Ver en Planning"
        Me.DataCheck1.Dock = System.Windows.Forms.DockStyle.Left
        Me.DataCheck1.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.DataCheck1.Location = New System.Drawing.Point(331, 0)
        Me.DataCheck1.Name = "DataCheck1"
        Me.DataCheck1.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.DataCheck1.Size = New System.Drawing.Size(113, 26)
        Me.DataCheck1.TabIndex = 4
        Me.DataCheck1.Text = "Ver en Planning"
        Me.DataCheck1.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.DataCheck1.ThemeName = "Windows8"
        Me.DataCheck1.Value = False
        '
        'pnlSpace51
        '
        Me.pnlSpace51.Auto_Size = False
        Me.pnlSpace51.BackColor = System.Drawing.Color.Red
        Me.pnlSpace51.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace51.ChangeDock = True
        Me.pnlSpace51.Control_Resize = False
        Me.pnlSpace51.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace51.isSpace = True
        Me.pnlSpace51.Location = New System.Drawing.Point(325, 0)
        Me.pnlSpace51.Name = "pnlSpace51"
        Me.pnlSpace51.numRows = 0
        Me.pnlSpace51.Reorder = True
        Me.pnlSpace51.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace51.TabIndex = 3
        '
        'btnRecalcularSit
        '
        Me.btnRecalcularSit.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnRecalcularSit.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnRecalcularSit.Location = New System.Drawing.Point(250, 0)
        Me.btnRecalcularSit.Name = "btnRecalcularSit"
        Me.btnRecalcularSit.Size = New System.Drawing.Size(75, 26)
        Me.btnRecalcularSit.TabIndex = 2
        Me.btnRecalcularSit.Text = "Recalcular"
        Me.btnRecalcularSit.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.btnRecalcularSit.ThemeName = "Windows8"
        '
        'pnlSpace50
        '
        Me.pnlSpace50.Auto_Size = False
        Me.pnlSpace50.BackColor = System.Drawing.Color.Red
        Me.pnlSpace50.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace50.ChangeDock = True
        Me.pnlSpace50.Control_Resize = False
        Me.pnlSpace50.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace50.isSpace = True
        Me.pnlSpace50.Location = New System.Drawing.Point(244, 0)
        Me.pnlSpace50.Name = "pnlSpace50"
        Me.pnlSpace50.numRows = 0
        Me.pnlSpace50.Reorder = True
        Me.pnlSpace50.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace50.TabIndex = 1
        '
        'dtfSituacionOtros
        '
        Me.dtfSituacionOtros.Allow_Empty = True
        Me.dtfSituacionOtros.Allow_Negative = True
        Me.dtfSituacionOtros.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfSituacionOtros.BackColor = System.Drawing.SystemColors.Control
        Me.dtfSituacionOtros.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfSituacionOtros.DataField = "situacion"
        Me.dtfSituacionOtros.DataTable = "V1"
        Me.dtfSituacionOtros.DB = Connection6
        Me.dtfSituacionOtros.Desc_Datafield = "Nombre n3"
        Me.dtfSituacionOtros.Desc_DBPK = "Numero"
        Me.dtfSituacionOtros.Desc_DBTable = "SITUACION"
        Me.dtfSituacionOtros.Desc_Where = Nothing
        Me.dtfSituacionOtros.Desc_WhereObligatoria = Nothing
        Me.dtfSituacionOtros.Descripcion = "Situación"
        Me.dtfSituacionOtros.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfSituacionOtros.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfSituacionOtros.ExtraSQL = ""
        Me.dtfSituacionOtros.FocoEnAgregar = False
        Me.dtfSituacionOtros.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfSituacionOtros.Formulario = Nothing
        Me.dtfSituacionOtros.Label_Space = 65
        Me.dtfSituacionOtros.Length_Data = 32767
        Me.dtfSituacionOtros.Location = New System.Drawing.Point(0, 0)
        Me.dtfSituacionOtros.Lupa = Nothing
        Me.dtfSituacionOtros.Max_Value = 0.0R
        Me.dtfSituacionOtros.MensajeIncorrectoCustom = Nothing
        Me.dtfSituacionOtros.Name = "dtfSituacionOtros"
        Me.dtfSituacionOtros.Null_on_Empty = True
        Me.dtfSituacionOtros.OpenForm = Nothing
        Me.dtfSituacionOtros.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfSituacionOtros.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfSituacionOtros.Query_on_Text_Changed = True
        Me.dtfSituacionOtros.ReadOnly_Data = False
        Me.dtfSituacionOtros.ReQuery = False
        Me.dtfSituacionOtros.ShowButton = True
        Me.dtfSituacionOtros.Size = New System.Drawing.Size(244, 26)
        Me.dtfSituacionOtros.TabIndex = 0
        Me.dtfSituacionOtros.Text_Data = ""
        Me.dtfSituacionOtros.Text_Data_Desc = ""
        Me.dtfSituacionOtros.Text_Width = 58
        Me.dtfSituacionOtros.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfSituacionOtros.TopPadding = 0
        Me.dtfSituacionOtros.Upper_Case = False
        Me.dtfSituacionOtros.Validate_on_lost_focus = True
        '
        'pnlUbicacionOtros
        '
        Me.pnlUbicacionOtros.Auto_Size = False
        Me.pnlUbicacionOtros.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlUbicacionOtros.ChangeDock = True
        Me.pnlUbicacionOtros.Control_Resize = False
        Me.pnlUbicacionOtros.Controls.Add(Me.dtfUbicacionOtros)
        Me.pnlUbicacionOtros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlUbicacionOtros.isSpace = False
        Me.pnlUbicacionOtros.Location = New System.Drawing.Point(3, 29)
        Me.pnlUbicacionOtros.Name = "pnlUbicacionOtros"
        Me.pnlUbicacionOtros.numRows = 1
        Me.pnlUbicacionOtros.Reorder = True
        Me.pnlUbicacionOtros.Size = New System.Drawing.Size(562, 26)
        Me.pnlUbicacionOtros.TabIndex = 1
        '
        'dtfUbicacionOtros
        '
        Me.dtfUbicacionOtros.Allow_Empty = True
        Me.dtfUbicacionOtros.Allow_Negative = True
        Me.dtfUbicacionOtros.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfUbicacionOtros.BackColor = System.Drawing.SystemColors.Control
        Me.dtfUbicacionOtros.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfUbicacionOtros.DataField = "ubica"
        Me.dtfUbicacionOtros.DataTable = "V1"
        Me.dtfUbicacionOtros.Descripcion = "Ubicación"
        Me.dtfUbicacionOtros.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfUbicacionOtros.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfUbicacionOtros.FocoEnAgregar = False
        Me.dtfUbicacionOtros.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfUbicacionOtros.Image = Nothing
        Me.dtfUbicacionOtros.Label_Space = 65
        Me.dtfUbicacionOtros.Length_Data = 32767
        Me.dtfUbicacionOtros.Location = New System.Drawing.Point(0, 0)
        Me.dtfUbicacionOtros.Max_Value = 0.0R
        Me.dtfUbicacionOtros.MensajeIncorrectoCustom = Nothing
        Me.dtfUbicacionOtros.Name = "dtfUbicacionOtros"
        Me.dtfUbicacionOtros.Null_on_Empty = True
        Me.dtfUbicacionOtros.OpenForm = Nothing
        Me.dtfUbicacionOtros.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfUbicacionOtros.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfUbicacionOtros.ReadOnly_Data = False
        Me.dtfUbicacionOtros.Show_Button = False
        Me.dtfUbicacionOtros.Size = New System.Drawing.Size(562, 26)
        Me.dtfUbicacionOtros.TabIndex = 0
        Me.dtfUbicacionOtros.Text_Data = ""
        Me.dtfUbicacionOtros.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfUbicacionOtros.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfUbicacionOtros.TopPadding = 0
        Me.dtfUbicacionOtros.Upper_Case = False
        Me.dtfUbicacionOtros.Validate_on_lost_focus = True
        '
        'pnlOficinasOtros
        '
        Me.pnlOficinasOtros.Auto_Size = False
        Me.pnlOficinasOtros.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlOficinasOtros.ChangeDock = True
        Me.pnlOficinasOtros.Control_Resize = False
        Me.pnlOficinasOtros.Controls.Add(Me.dtfOficinaAsig)
        Me.pnlOficinasOtros.Controls.Add(Me.pnlSpace49)
        Me.pnlOficinasOtros.Controls.Add(Me.dtfOficinaActual)
        Me.pnlOficinasOtros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlOficinasOtros.isSpace = False
        Me.pnlOficinasOtros.Location = New System.Drawing.Point(3, 3)
        Me.pnlOficinasOtros.Name = "pnlOficinasOtros"
        Me.pnlOficinasOtros.numRows = 1
        Me.pnlOficinasOtros.Reorder = True
        Me.pnlOficinasOtros.Size = New System.Drawing.Size(562, 26)
        Me.pnlOficinasOtros.TabIndex = 0
        '
        'dtfOficinaAsig
        '
        Me.dtfOficinaAsig.Allow_Empty = True
        Me.dtfOficinaAsig.Allow_Negative = True
        Me.dtfOficinaAsig.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfOficinaAsig.BackColor = System.Drawing.SystemColors.Control
        Me.dtfOficinaAsig.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfOficinaAsig.DataField = "baseasig"
        Me.dtfOficinaAsig.DataTable = "V2"
        Me.dtfOficinaAsig.DB = Connection7
        Me.dtfOficinaAsig.Desc_Datafield = "Nombre n3"
        Me.dtfOficinaAsig.Desc_DBPK = "Codigo"
        Me.dtfOficinaAsig.Desc_DBTable = "OFICINAS"
        Me.dtfOficinaAsig.Desc_Where = Nothing
        Me.dtfOficinaAsig.Desc_WhereObligatoria = Nothing
        Me.dtfOficinaAsig.Descripcion = "Ofi. Asign"
        Me.dtfOficinaAsig.Dock = System.Windows.Forms.DockStyle.Right
        Me.dtfOficinaAsig.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfOficinaAsig.ExtraSQL = ""
        Me.dtfOficinaAsig.FocoEnAgregar = False
        Me.dtfOficinaAsig.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfOficinaAsig.Formulario = Nothing
        Me.dtfOficinaAsig.Label_Space = 75
        Me.dtfOficinaAsig.Length_Data = 32767
        Me.dtfOficinaAsig.Location = New System.Drawing.Point(312, 0)
        Me.dtfOficinaAsig.Lupa = Nothing
        Me.dtfOficinaAsig.Max_Value = 0.0R
        Me.dtfOficinaAsig.MensajeIncorrectoCustom = Nothing
        Me.dtfOficinaAsig.Name = "dtfOficinaAsig"
        Me.dtfOficinaAsig.Null_on_Empty = True
        Me.dtfOficinaAsig.OpenForm = Nothing
        Me.dtfOficinaAsig.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfOficinaAsig.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfOficinaAsig.Query_on_Text_Changed = True
        Me.dtfOficinaAsig.ReadOnly_Data = False
        Me.dtfOficinaAsig.ReQuery = False
        Me.dtfOficinaAsig.ShowButton = True
        Me.dtfOficinaAsig.Size = New System.Drawing.Size(250, 26)
        Me.dtfOficinaAsig.TabIndex = 2
        Me.dtfOficinaAsig.Text_Data = ""
        Me.dtfOficinaAsig.Text_Data_Desc = ""
        Me.dtfOficinaAsig.Text_Width = 30
        Me.dtfOficinaAsig.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfOficinaAsig.TopPadding = 0
        Me.dtfOficinaAsig.Upper_Case = False
        Me.dtfOficinaAsig.Validate_on_lost_focus = True
        '
        'pnlSpace49
        '
        Me.pnlSpace49.Auto_Size = False
        Me.pnlSpace49.BackColor = System.Drawing.Color.Red
        Me.pnlSpace49.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace49.ChangeDock = True
        Me.pnlSpace49.Control_Resize = False
        Me.pnlSpace49.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace49.isSpace = True
        Me.pnlSpace49.Location = New System.Drawing.Point(244, 0)
        Me.pnlSpace49.Name = "pnlSpace49"
        Me.pnlSpace49.numRows = 0
        Me.pnlSpace49.Reorder = True
        Me.pnlSpace49.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace49.TabIndex = 1
        '
        'dtfOficinaActual
        '
        Me.dtfOficinaActual.Allow_Empty = True
        Me.dtfOficinaActual.Allow_Negative = True
        Me.dtfOficinaActual.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfOficinaActual.BackColor = System.Drawing.SystemColors.Control
        Me.dtfOficinaActual.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfOficinaActual.DataField = "OFICINA"
        Me.dtfOficinaActual.DataTable = "V2"
        Me.dtfOficinaActual.DB = Connection8
        Me.dtfOficinaActual.Desc_Datafield = "NOMBRE n4"
        Me.dtfOficinaActual.Desc_DBPK = "CODIGO"
        Me.dtfOficinaActual.Desc_DBTable = "OFICINAS"
        Me.dtfOficinaActual.Desc_Where = Nothing
        Me.dtfOficinaActual.Desc_WhereObligatoria = Nothing
        Me.dtfOficinaActual.Descripcion = "Ofi. Actual"
        Me.dtfOficinaActual.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfOficinaActual.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfOficinaActual.ExtraSQL = ""
        Me.dtfOficinaActual.FocoEnAgregar = False
        Me.dtfOficinaActual.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfOficinaActual.Formulario = Nothing
        Me.dtfOficinaActual.Label_Space = 65
        Me.dtfOficinaActual.Length_Data = 32767
        Me.dtfOficinaActual.Location = New System.Drawing.Point(0, 0)
        Me.dtfOficinaActual.Lupa = Nothing
        Me.dtfOficinaActual.Max_Value = 0.0R
        Me.dtfOficinaActual.MensajeIncorrectoCustom = Nothing
        Me.dtfOficinaActual.Name = "dtfOficinaActual"
        Me.dtfOficinaActual.Null_on_Empty = True
        Me.dtfOficinaActual.OpenForm = Nothing
        Me.dtfOficinaActual.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfOficinaActual.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfOficinaActual.Query_on_Text_Changed = True
        Me.dtfOficinaActual.ReadOnly_Data = False
        Me.dtfOficinaActual.ReQuery = True
        Me.dtfOficinaActual.ShowButton = True
        Me.dtfOficinaActual.Size = New System.Drawing.Size(244, 26)
        Me.dtfOficinaActual.TabIndex = 0
        Me.dtfOficinaActual.Text_Data = ""
        Me.dtfOficinaActual.Text_Data_Desc = ""
        Me.dtfOficinaActual.Text_Width = 30
        Me.dtfOficinaActual.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfOficinaActual.TopPadding = 0
        Me.dtfOficinaActual.Upper_Case = False
        Me.dtfOficinaActual.Validate_on_lost_focus = True
        '
        'pnlOtrosIzq
        '
        Me.pnlOtrosIzq.Auto_Size = False
        Me.pnlOtrosIzq.BackColor = System.Drawing.SystemColors.Control
        Me.pnlOtrosIzq.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlOtrosIzq.ChangeDock = True
        Me.pnlOtrosIzq.Control_Resize = False
        Me.pnlOtrosIzq.Controls.Add(Me.pnlLocalizador)
        Me.pnlOtrosIzq.Controls.Add(Me.pnlCuentaOtros)
        Me.pnlOtrosIzq.Controls.Add(Me.pnlModeloDiasMax)
        Me.pnlOtrosIzq.Controls.Add(Me.pnlMotorTap)
        Me.pnlOtrosIzq.Controls.Add(Me.pnlCodBateria)
        Me.pnlOtrosIzq.Controls.Add(Me.pnlPlazasPuertas)
        Me.pnlOtrosIzq.Controls.Add(Me.pclCodLlave)
        Me.pnlOtrosIzq.Controls.Add(Me.pnlDepoLitros)
        Me.pnlOtrosIzq.Controls.Add(Me.pnlKmMaximoOtros)
        Me.pnlOtrosIzq.Controls.Add(Me.pnlKmOtros)
        Me.pnlOtrosIzq.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlOtrosIzq.isSpace = False
        Me.pnlOtrosIzq.Location = New System.Drawing.Point(0, 88)
        Me.pnlOtrosIzq.Name = "pnlOtrosIzq"
        Me.pnlOtrosIzq.numRows = 0
        Me.pnlOtrosIzq.Padding = New System.Windows.Forms.Padding(3)
        Me.pnlOtrosIzq.Reorder = True
        Me.pnlOtrosIzq.Size = New System.Drawing.Size(568, 412)
        Me.pnlOtrosIzq.TabIndex = 3
        '
        'pnlLocalizador
        '
        Me.pnlLocalizador.Auto_Size = False
        Me.pnlLocalizador.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlLocalizador.ChangeDock = True
        Me.pnlLocalizador.Control_Resize = False
        Me.pnlLocalizador.Controls.Add(Me.btnHistoricoOtros)
        Me.pnlLocalizador.Controls.Add(Me.Panel18)
        Me.pnlLocalizador.Controls.Add(Me.btnIncidencias)
        Me.pnlLocalizador.Controls.Add(Me.Panel8)
        Me.pnlLocalizador.Controls.Add(Me.dtcLocalizadorOtros)
        Me.pnlLocalizador.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlLocalizador.isSpace = False
        Me.pnlLocalizador.Location = New System.Drawing.Point(3, 237)
        Me.pnlLocalizador.Name = "pnlLocalizador"
        Me.pnlLocalizador.numRows = 1
        Me.pnlLocalizador.Reorder = True
        Me.pnlLocalizador.Size = New System.Drawing.Size(562, 43)
        Me.pnlLocalizador.TabIndex = 9
        '
        'btnHistoricoOtros
        '
        Me.btnHistoricoOtros.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnHistoricoOtros.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnHistoricoOtros.Location = New System.Drawing.Point(174, 0)
        Me.btnHistoricoOtros.Name = "btnHistoricoOtros"
        Me.btnHistoricoOtros.Size = New System.Drawing.Size(75, 43)
        Me.btnHistoricoOtros.TabIndex = 4
        Me.btnHistoricoOtros.Text = "Histórico"
        Me.btnHistoricoOtros.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.btnHistoricoOtros.ThemeName = "Windows8"
        '
        'Panel18
        '
        Me.Panel18.Auto_Size = False
        Me.Panel18.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Panel18.BorderColor = System.Drawing.SystemColors.Control
        Me.Panel18.ChangeDock = True
        Me.Panel18.Control_Resize = False
        Me.Panel18.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel18.isSpace = True
        Me.Panel18.Location = New System.Drawing.Point(168, 0)
        Me.Panel18.Name = "Panel18"
        Me.Panel18.numRows = 0
        Me.Panel18.Reorder = True
        Me.Panel18.Size = New System.Drawing.Size(6, 43)
        Me.Panel18.TabIndex = 3
        '
        'btnIncidencias
        '
        Me.btnIncidencias.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnIncidencias.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnIncidencias.Location = New System.Drawing.Point(93, 0)
        Me.btnIncidencias.Name = "btnIncidencias"
        Me.btnIncidencias.Size = New System.Drawing.Size(75, 43)
        Me.btnIncidencias.TabIndex = 2
        Me.btnIncidencias.Text = "Incidencias"
        Me.btnIncidencias.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.btnIncidencias.ThemeName = "Windows8"
        '
        'Panel8
        '
        Me.Panel8.Auto_Size = False
        Me.Panel8.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Panel8.BorderColor = System.Drawing.SystemColors.Control
        Me.Panel8.ChangeDock = True
        Me.Panel8.Control_Resize = False
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel8.isSpace = True
        Me.Panel8.Location = New System.Drawing.Point(87, 0)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.numRows = 0
        Me.Panel8.Reorder = True
        Me.Panel8.Size = New System.Drawing.Size(6, 43)
        Me.Panel8.TabIndex = 1
        '
        'dtcLocalizadorOtros
        '
        Me.dtcLocalizadorOtros.DataField = Nothing
        Me.dtcLocalizadorOtros.DataTable = ""
        Me.dtcLocalizadorOtros.Descripcion = "Localizador"
        Me.dtcLocalizadorOtros.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtcLocalizadorOtros.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtcLocalizadorOtros.Location = New System.Drawing.Point(0, 0)
        Me.dtcLocalizadorOtros.Name = "dtcLocalizadorOtros"
        Me.dtcLocalizadorOtros.Size = New System.Drawing.Size(87, 43)
        Me.dtcLocalizadorOtros.TabIndex = 0
        Me.dtcLocalizadorOtros.Text = "Localizador"
        Me.dtcLocalizadorOtros.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtcLocalizadorOtros.ThemeName = "Windows8"
        Me.dtcLocalizadorOtros.Value = False
        '
        'pnlCuentaOtros
        '
        Me.pnlCuentaOtros.Auto_Size = False
        Me.pnlCuentaOtros.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlCuentaOtros.ChangeDock = True
        Me.pnlCuentaOtros.Control_Resize = False
        Me.pnlCuentaOtros.Controls.Add(Me.dtfCuentaOtros)
        Me.pnlCuentaOtros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCuentaOtros.isSpace = False
        Me.pnlCuentaOtros.Location = New System.Drawing.Point(3, 211)
        Me.pnlCuentaOtros.Name = "pnlCuentaOtros"
        Me.pnlCuentaOtros.numRows = 1
        Me.pnlCuentaOtros.Reorder = True
        Me.pnlCuentaOtros.Size = New System.Drawing.Size(562, 26)
        Me.pnlCuentaOtros.TabIndex = 8
        '
        'dtfCuentaOtros
        '
        Me.dtfCuentaOtros.Allow_Empty = True
        Me.dtfCuentaOtros.Allow_Negative = True
        Me.dtfCuentaOtros.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfCuentaOtros.BackColor = System.Drawing.SystemColors.Control
        Me.dtfCuentaOtros.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfCuentaOtros.DataField = "CUENTA"
        Me.dtfCuentaOtros.DataTable = "V2"
        Me.dtfCuentaOtros.DB = Connection9
        Me.dtfCuentaOtros.Desc_Datafield = "DESCRIP"
        Me.dtfCuentaOtros.Desc_DBPK = "CODIGO"
        Me.dtfCuentaOtros.Desc_DBTable = "CU1"
        Me.dtfCuentaOtros.Desc_Where = Nothing
        Me.dtfCuentaOtros.Desc_WhereObligatoria = Nothing
        Me.dtfCuentaOtros.Descripcion = "Cuenta"
        Me.dtfCuentaOtros.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfCuentaOtros.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfCuentaOtros.ExtraSQL = ""
        Me.dtfCuentaOtros.FocoEnAgregar = False
        Me.dtfCuentaOtros.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfCuentaOtros.Formulario = Nothing
        Me.dtfCuentaOtros.Label_Space = 95
        Me.dtfCuentaOtros.Length_Data = 32767
        Me.dtfCuentaOtros.Location = New System.Drawing.Point(0, 0)
        Me.dtfCuentaOtros.Lupa = Nothing
        Me.dtfCuentaOtros.Max_Value = 0.0R
        Me.dtfCuentaOtros.MensajeIncorrectoCustom = Nothing
        Me.dtfCuentaOtros.Name = "dtfCuentaOtros"
        Me.dtfCuentaOtros.Null_on_Empty = True
        Me.dtfCuentaOtros.OpenForm = Nothing
        Me.dtfCuentaOtros.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfCuentaOtros.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfCuentaOtros.Query_on_Text_Changed = True
        Me.dtfCuentaOtros.ReadOnly_Data = False
        Me.dtfCuentaOtros.ReQuery = True
        Me.dtfCuentaOtros.ShowButton = True
        Me.dtfCuentaOtros.Size = New System.Drawing.Size(418, 26)
        Me.dtfCuentaOtros.TabIndex = 0
        Me.dtfCuentaOtros.Text_Data = ""
        Me.dtfCuentaOtros.Text_Data_Desc = ""
        Me.dtfCuentaOtros.Text_Width = 60
        Me.dtfCuentaOtros.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfCuentaOtros.TopPadding = 0
        Me.dtfCuentaOtros.Upper_Case = False
        Me.dtfCuentaOtros.Validate_on_lost_focus = True
        '
        'pnlModeloDiasMax
        '
        Me.pnlModeloDiasMax.Auto_Size = False
        Me.pnlModeloDiasMax.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlModeloDiasMax.ChangeDock = True
        Me.pnlModeloDiasMax.Control_Resize = False
        Me.pnlModeloDiasMax.Controls.Add(Me.DatafieldLabel1)
        Me.pnlModeloDiasMax.Controls.Add(Me.Panel17)
        Me.pnlModeloDiasMax.Controls.Add(Me.dtfAnyoModelo)
        Me.pnlModeloDiasMax.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlModeloDiasMax.isSpace = False
        Me.pnlModeloDiasMax.Location = New System.Drawing.Point(3, 185)
        Me.pnlModeloDiasMax.Name = "pnlModeloDiasMax"
        Me.pnlModeloDiasMax.numRows = 1
        Me.pnlModeloDiasMax.Reorder = True
        Me.pnlModeloDiasMax.Size = New System.Drawing.Size(562, 26)
        Me.pnlModeloDiasMax.TabIndex = 7
        '
        'DatafieldLabel1
        '
        Me.DatafieldLabel1.Allow_Empty = True
        Me.DatafieldLabel1.Allow_Negative = True
        Me.DatafieldLabel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.DatafieldLabel1.BackColor = System.Drawing.SystemColors.Control
        Me.DatafieldLabel1.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.DatafieldLabel1.DataField = "DIASMAXALQ"
        Me.DatafieldLabel1.DataTable = "V1"
        Me.DatafieldLabel1.Descripcion = "Días Max.Alq"
        Me.DatafieldLabel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.DatafieldLabel1.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.DatafieldLabel1.FocoEnAgregar = False
        Me.DatafieldLabel1.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.DatafieldLabel1.Image = Nothing
        Me.DatafieldLabel1.Label_Space = 85
        Me.DatafieldLabel1.Length_Data = 32767
        Me.DatafieldLabel1.Location = New System.Drawing.Point(202, 0)
        Me.DatafieldLabel1.Max_Value = 0.0R
        Me.DatafieldLabel1.MensajeIncorrectoCustom = Nothing
        Me.DatafieldLabel1.Name = "DatafieldLabel1"
        Me.DatafieldLabel1.Null_on_Empty = True
        Me.DatafieldLabel1.OpenForm = Nothing
        Me.DatafieldLabel1.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.DatafieldLabel1.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.DatafieldLabel1.ReadOnly_Data = False
        Me.DatafieldLabel1.Show_Button = False
        Me.DatafieldLabel1.Size = New System.Drawing.Size(120, 26)
        Me.DatafieldLabel1.TabIndex = 2
        Me.DatafieldLabel1.Text_Data = ""
        Me.DatafieldLabel1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.DatafieldLabel1.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.DatafieldLabel1.TopPadding = 0
        Me.DatafieldLabel1.Upper_Case = False
        Me.DatafieldLabel1.Validate_on_lost_focus = True
        '
        'Panel17
        '
        Me.Panel17.Auto_Size = False
        Me.Panel17.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Panel17.BorderColor = System.Drawing.SystemColors.Control
        Me.Panel17.ChangeDock = True
        Me.Panel17.Control_Resize = False
        Me.Panel17.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel17.isSpace = True
        Me.Panel17.Location = New System.Drawing.Point(196, 0)
        Me.Panel17.Name = "Panel17"
        Me.Panel17.numRows = 0
        Me.Panel17.Reorder = True
        Me.Panel17.Size = New System.Drawing.Size(6, 26)
        Me.Panel17.TabIndex = 1
        '
        'dtfAnyoModelo
        '
        Me.dtfAnyoModelo.Allow_Empty = True
        Me.dtfAnyoModelo.Allow_Negative = True
        Me.dtfAnyoModelo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfAnyoModelo.BackColor = System.Drawing.SystemColors.Control
        Me.dtfAnyoModelo.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfAnyoModelo.DataField = "AnoModelo"
        Me.dtfAnyoModelo.DataTable = "V1"
        Me.dtfAnyoModelo.Descripcion = "Año Modelo"
        Me.dtfAnyoModelo.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfAnyoModelo.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfAnyoModelo.FocoEnAgregar = False
        Me.dtfAnyoModelo.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfAnyoModelo.Image = Nothing
        Me.dtfAnyoModelo.Label_Space = 95
        Me.dtfAnyoModelo.Length_Data = 32767
        Me.dtfAnyoModelo.Location = New System.Drawing.Point(0, 0)
        Me.dtfAnyoModelo.Max_Value = 0.0R
        Me.dtfAnyoModelo.MensajeIncorrectoCustom = Nothing
        Me.dtfAnyoModelo.Name = "dtfAnyoModelo"
        Me.dtfAnyoModelo.Null_on_Empty = True
        Me.dtfAnyoModelo.OpenForm = Nothing
        Me.dtfAnyoModelo.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfAnyoModelo.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfAnyoModelo.ReadOnly_Data = False
        Me.dtfAnyoModelo.Show_Button = False
        Me.dtfAnyoModelo.Size = New System.Drawing.Size(196, 26)
        Me.dtfAnyoModelo.TabIndex = 0
        Me.dtfAnyoModelo.Text_Data = ""
        Me.dtfAnyoModelo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfAnyoModelo.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfAnyoModelo.TopPadding = 0
        Me.dtfAnyoModelo.Upper_Case = False
        Me.dtfAnyoModelo.Validate_on_lost_focus = True
        '
        'pnlMotorTap
        '
        Me.pnlMotorTap.Auto_Size = False
        Me.pnlMotorTap.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlMotorTap.ChangeDock = True
        Me.pnlMotorTap.Control_Resize = False
        Me.pnlMotorTap.Controls.Add(Me.EmpresaOficina1)
        Me.pnlMotorTap.Controls.Add(Me.dtfTapiceria)
        Me.pnlMotorTap.Controls.Add(Me.Panel15)
        Me.pnlMotorTap.Controls.Add(Me.dtfNMotor)
        Me.pnlMotorTap.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlMotorTap.isSpace = False
        Me.pnlMotorTap.Location = New System.Drawing.Point(3, 159)
        Me.pnlMotorTap.Name = "pnlMotorTap"
        Me.pnlMotorTap.numRows = 1
        Me.pnlMotorTap.Reorder = True
        Me.pnlMotorTap.Size = New System.Drawing.Size(562, 26)
        Me.pnlMotorTap.TabIndex = 6
        '
        'EmpresaOficina1
        '
        Me.EmpresaOficina1.DataField_Empresa = ""
        Me.EmpresaOficina1.DataField_Oficina = ""
        Me.EmpresaOficina1.DataTable_Empresa = ""
        Me.EmpresaOficina1.DataTable_Oficina = ""
        Me.EmpresaOficina1.Descripcion = Nothing
        Me.EmpresaOficina1.FocoEnAgregar = False
        Me.EmpresaOficina1.Location = New System.Drawing.Point(519, 20)
        Me.EmpresaOficina1.Lupa = Nothing
        Me.EmpresaOficina1.MensajeIncorrectoCustom = Nothing
        Me.EmpresaOficina1.Name = "EmpresaOficina1"
        Me.EmpresaOficina1.OficinaReadOnly = False
        Me.EmpresaOficina1.ShowLupa = True
        Me.EmpresaOficina1.Size = New System.Drawing.Size(450, 26)
        Me.EmpresaOficina1.Size_Empresa = 85
        Me.EmpresaOficina1.TabIndex = 3
        Me.EmpresaOficina1.Text_Empresa = ""
        Me.EmpresaOficina1.Text_Oficina = ""
        '
        'dtfTapiceria
        '
        Me.dtfTapiceria.Allow_Empty = True
        Me.dtfTapiceria.Allow_Negative = True
        Me.dtfTapiceria.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfTapiceria.BackColor = System.Drawing.SystemColors.Control
        Me.dtfTapiceria.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfTapiceria.DataField = "TAPICERIA"
        Me.dtfTapiceria.DataTable = "V1"
        Me.dtfTapiceria.Descripcion = "Tapicería"
        Me.dtfTapiceria.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfTapiceria.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfTapiceria.FocoEnAgregar = False
        Me.dtfTapiceria.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfTapiceria.Image = Nothing
        Me.dtfTapiceria.Label_Space = 85
        Me.dtfTapiceria.Length_Data = 32767
        Me.dtfTapiceria.Location = New System.Drawing.Point(202, 0)
        Me.dtfTapiceria.Max_Value = 0.0R
        Me.dtfTapiceria.MensajeIncorrectoCustom = Nothing
        Me.dtfTapiceria.Name = "dtfTapiceria"
        Me.dtfTapiceria.Null_on_Empty = True
        Me.dtfTapiceria.OpenForm = Nothing
        Me.dtfTapiceria.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfTapiceria.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfTapiceria.ReadOnly_Data = False
        Me.dtfTapiceria.Show_Button = False
        Me.dtfTapiceria.Size = New System.Drawing.Size(216, 26)
        Me.dtfTapiceria.TabIndex = 2
        Me.dtfTapiceria.Text_Data = ""
        Me.dtfTapiceria.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfTapiceria.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfTapiceria.TopPadding = 0
        Me.dtfTapiceria.Upper_Case = False
        Me.dtfTapiceria.Validate_on_lost_focus = True
        '
        'Panel15
        '
        Me.Panel15.Auto_Size = False
        Me.Panel15.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Panel15.BorderColor = System.Drawing.SystemColors.Control
        Me.Panel15.ChangeDock = True
        Me.Panel15.Control_Resize = False
        Me.Panel15.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel15.isSpace = True
        Me.Panel15.Location = New System.Drawing.Point(196, 0)
        Me.Panel15.Name = "Panel15"
        Me.Panel15.numRows = 0
        Me.Panel15.Reorder = True
        Me.Panel15.Size = New System.Drawing.Size(6, 26)
        Me.Panel15.TabIndex = 1
        '
        'dtfNMotor
        '
        Me.dtfNMotor.Allow_Empty = True
        Me.dtfNMotor.Allow_Negative = True
        Me.dtfNMotor.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfNMotor.BackColor = System.Drawing.SystemColors.Control
        Me.dtfNMotor.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfNMotor.DataField = "NUM_MOTOR"
        Me.dtfNMotor.DataTable = "V1"
        Me.dtfNMotor.Descripcion = "Nº Motor"
        Me.dtfNMotor.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfNMotor.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfNMotor.FocoEnAgregar = False
        Me.dtfNMotor.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfNMotor.Image = Nothing
        Me.dtfNMotor.Label_Space = 95
        Me.dtfNMotor.Length_Data = 32767
        Me.dtfNMotor.Location = New System.Drawing.Point(0, 0)
        Me.dtfNMotor.Max_Value = 0.0R
        Me.dtfNMotor.MensajeIncorrectoCustom = Nothing
        Me.dtfNMotor.Name = "dtfNMotor"
        Me.dtfNMotor.Null_on_Empty = True
        Me.dtfNMotor.OpenForm = Nothing
        Me.dtfNMotor.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfNMotor.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfNMotor.ReadOnly_Data = False
        Me.dtfNMotor.Show_Button = False
        Me.dtfNMotor.Size = New System.Drawing.Size(196, 26)
        Me.dtfNMotor.TabIndex = 0
        Me.dtfNMotor.Text_Data = ""
        Me.dtfNMotor.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfNMotor.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfNMotor.TopPadding = 0
        Me.dtfNMotor.Upper_Case = False
        Me.dtfNMotor.Validate_on_lost_focus = True
        '
        'pnlCodBateria
        '
        Me.pnlCodBateria.Auto_Size = False
        Me.pnlCodBateria.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlCodBateria.ChangeDock = True
        Me.pnlCodBateria.Control_Resize = False
        Me.pnlCodBateria.Controls.Add(Me.dtfversionOtros)
        Me.pnlCodBateria.Controls.Add(Me.Panel11)
        Me.pnlCodBateria.Controls.Add(Me.dtfCodBateria)
        Me.pnlCodBateria.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCodBateria.isSpace = False
        Me.pnlCodBateria.Location = New System.Drawing.Point(3, 133)
        Me.pnlCodBateria.Name = "pnlCodBateria"
        Me.pnlCodBateria.numRows = 1
        Me.pnlCodBateria.Reorder = True
        Me.pnlCodBateria.Size = New System.Drawing.Size(562, 26)
        Me.pnlCodBateria.TabIndex = 5
        '
        'dtfversionOtros
        '
        Me.dtfversionOtros.Allow_Empty = True
        Me.dtfversionOtros.Allow_Negative = True
        Me.dtfversionOtros.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfversionOtros.BackColor = System.Drawing.SystemColors.Control
        Me.dtfversionOtros.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfversionOtros.DataField = "VERSION_VH"
        Me.dtfversionOtros.DataTable = "V1"
        Me.dtfversionOtros.Descripcion = "Versión"
        Me.dtfversionOtros.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfversionOtros.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfversionOtros.FocoEnAgregar = False
        Me.dtfversionOtros.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfversionOtros.Image = Nothing
        Me.dtfversionOtros.Label_Space = 85
        Me.dtfversionOtros.Length_Data = 32767
        Me.dtfversionOtros.Location = New System.Drawing.Point(202, 0)
        Me.dtfversionOtros.Max_Value = 0.0R
        Me.dtfversionOtros.MensajeIncorrectoCustom = Nothing
        Me.dtfversionOtros.Name = "dtfversionOtros"
        Me.dtfversionOtros.Null_on_Empty = True
        Me.dtfversionOtros.OpenForm = Nothing
        Me.dtfversionOtros.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfversionOtros.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfversionOtros.ReadOnly_Data = False
        Me.dtfversionOtros.Show_Button = False
        Me.dtfversionOtros.Size = New System.Drawing.Size(216, 26)
        Me.dtfversionOtros.TabIndex = 2
        Me.dtfversionOtros.Text_Data = ""
        Me.dtfversionOtros.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfversionOtros.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfversionOtros.TopPadding = 0
        Me.dtfversionOtros.Upper_Case = False
        Me.dtfversionOtros.Validate_on_lost_focus = True
        '
        'Panel11
        '
        Me.Panel11.Auto_Size = False
        Me.Panel11.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Panel11.BorderColor = System.Drawing.SystemColors.Control
        Me.Panel11.ChangeDock = True
        Me.Panel11.Control_Resize = False
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel11.isSpace = True
        Me.Panel11.Location = New System.Drawing.Point(196, 0)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.numRows = 0
        Me.Panel11.Reorder = True
        Me.Panel11.Size = New System.Drawing.Size(6, 26)
        Me.Panel11.TabIndex = 1
        '
        'dtfCodBateria
        '
        Me.dtfCodBateria.Allow_Empty = True
        Me.dtfCodBateria.Allow_Negative = True
        Me.dtfCodBateria.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfCodBateria.BackColor = System.Drawing.SystemColors.Control
        Me.dtfCodBateria.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfCodBateria.DataField = "COD_BATERIA"
        Me.dtfCodBateria.DataTable = "V1"
        Me.dtfCodBateria.Descripcion = "Código batería"
        Me.dtfCodBateria.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfCodBateria.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfCodBateria.FocoEnAgregar = False
        Me.dtfCodBateria.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfCodBateria.Image = Nothing
        Me.dtfCodBateria.Label_Space = 95
        Me.dtfCodBateria.Length_Data = 32767
        Me.dtfCodBateria.Location = New System.Drawing.Point(0, 0)
        Me.dtfCodBateria.Max_Value = 0.0R
        Me.dtfCodBateria.MensajeIncorrectoCustom = Nothing
        Me.dtfCodBateria.Name = "dtfCodBateria"
        Me.dtfCodBateria.Null_on_Empty = True
        Me.dtfCodBateria.OpenForm = Nothing
        Me.dtfCodBateria.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfCodBateria.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfCodBateria.ReadOnly_Data = False
        Me.dtfCodBateria.Show_Button = False
        Me.dtfCodBateria.Size = New System.Drawing.Size(196, 26)
        Me.dtfCodBateria.TabIndex = 0
        Me.dtfCodBateria.Text_Data = ""
        Me.dtfCodBateria.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfCodBateria.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfCodBateria.TopPadding = 0
        Me.dtfCodBateria.Upper_Case = False
        Me.dtfCodBateria.Validate_on_lost_focus = True
        '
        'pnlPlazasPuertas
        '
        Me.pnlPlazasPuertas.Auto_Size = False
        Me.pnlPlazasPuertas.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlPlazasPuertas.ChangeDock = True
        Me.pnlPlazasPuertas.Control_Resize = False
        Me.pnlPlazasPuertas.Controls.Add(Me.dtfNPuertas)
        Me.pnlPlazasPuertas.Controls.Add(Me.pnlSpace48)
        Me.pnlPlazasPuertas.Controls.Add(Me.dtfNPlazas)
        Me.pnlPlazasPuertas.Controls.Add(Me.pnlSpace47)
        Me.pnlPlazasPuertas.Controls.Add(Me.dtfTelAsociado)
        Me.pnlPlazasPuertas.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlPlazasPuertas.isSpace = False
        Me.pnlPlazasPuertas.Location = New System.Drawing.Point(3, 107)
        Me.pnlPlazasPuertas.Name = "pnlPlazasPuertas"
        Me.pnlPlazasPuertas.numRows = 1
        Me.pnlPlazasPuertas.Reorder = True
        Me.pnlPlazasPuertas.Size = New System.Drawing.Size(562, 26)
        Me.pnlPlazasPuertas.TabIndex = 4
        '
        'dtfNPuertas
        '
        Me.dtfNPuertas.Allow_Empty = True
        Me.dtfNPuertas.Allow_Negative = True
        Me.dtfNPuertas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfNPuertas.BackColor = System.Drawing.SystemColors.Control
        Me.dtfNPuertas.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfNPuertas.DataField = "NUMPUERTAS"
        Me.dtfNPuertas.DataTable = "V1"
        Me.dtfNPuertas.Descripcion = "Nº Puertas"
        Me.dtfNPuertas.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfNPuertas.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfNPuertas.FocoEnAgregar = False
        Me.dtfNPuertas.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfNPuertas.Image = Nothing
        Me.dtfNPuertas.Label_Space = 65
        Me.dtfNPuertas.Length_Data = 32767
        Me.dtfNPuertas.Location = New System.Drawing.Point(322, 0)
        Me.dtfNPuertas.Max_Value = 0.0R
        Me.dtfNPuertas.MensajeIncorrectoCustom = Nothing
        Me.dtfNPuertas.Name = "dtfNPuertas"
        Me.dtfNPuertas.Null_on_Empty = True
        Me.dtfNPuertas.OpenForm = Nothing
        Me.dtfNPuertas.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfNPuertas.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfNPuertas.ReadOnly_Data = False
        Me.dtfNPuertas.Show_Button = False
        Me.dtfNPuertas.Size = New System.Drawing.Size(96, 26)
        Me.dtfNPuertas.TabIndex = 4
        Me.dtfNPuertas.Text_Data = ""
        Me.dtfNPuertas.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfNPuertas.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfNPuertas.TopPadding = 0
        Me.dtfNPuertas.Upper_Case = False
        Me.dtfNPuertas.Validate_on_lost_focus = True
        '
        'pnlSpace48
        '
        Me.pnlSpace48.Auto_Size = False
        Me.pnlSpace48.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pnlSpace48.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace48.ChangeDock = True
        Me.pnlSpace48.Control_Resize = False
        Me.pnlSpace48.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace48.isSpace = True
        Me.pnlSpace48.Location = New System.Drawing.Point(316, 0)
        Me.pnlSpace48.Name = "pnlSpace48"
        Me.pnlSpace48.numRows = 0
        Me.pnlSpace48.Reorder = True
        Me.pnlSpace48.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace48.TabIndex = 3
        '
        'dtfNPlazas
        '
        Me.dtfNPlazas.Allow_Empty = True
        Me.dtfNPlazas.Allow_Negative = True
        Me.dtfNPlazas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfNPlazas.BackColor = System.Drawing.SystemColors.Control
        Me.dtfNPlazas.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfNPlazas.DataField = "NumPlazas"
        Me.dtfNPlazas.DataTable = "V1"
        Me.dtfNPlazas.Descripcion = "Nº Plazas"
        Me.dtfNPlazas.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfNPlazas.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfNPlazas.FocoEnAgregar = False
        Me.dtfNPlazas.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfNPlazas.Image = Nothing
        Me.dtfNPlazas.Label_Space = 85
        Me.dtfNPlazas.Length_Data = 32767
        Me.dtfNPlazas.Location = New System.Drawing.Point(202, 0)
        Me.dtfNPlazas.Max_Value = 0.0R
        Me.dtfNPlazas.MensajeIncorrectoCustom = Nothing
        Me.dtfNPlazas.Name = "dtfNPlazas"
        Me.dtfNPlazas.Null_on_Empty = True
        Me.dtfNPlazas.OpenForm = Nothing
        Me.dtfNPlazas.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfNPlazas.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfNPlazas.ReadOnly_Data = False
        Me.dtfNPlazas.Show_Button = False
        Me.dtfNPlazas.Size = New System.Drawing.Size(114, 26)
        Me.dtfNPlazas.TabIndex = 2
        Me.dtfNPlazas.Text_Data = ""
        Me.dtfNPlazas.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfNPlazas.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfNPlazas.TopPadding = 0
        Me.dtfNPlazas.Upper_Case = False
        Me.dtfNPlazas.Validate_on_lost_focus = True
        '
        'pnlSpace47
        '
        Me.pnlSpace47.Auto_Size = False
        Me.pnlSpace47.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pnlSpace47.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace47.ChangeDock = True
        Me.pnlSpace47.Control_Resize = False
        Me.pnlSpace47.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace47.isSpace = True
        Me.pnlSpace47.Location = New System.Drawing.Point(196, 0)
        Me.pnlSpace47.Name = "pnlSpace47"
        Me.pnlSpace47.numRows = 0
        Me.pnlSpace47.Reorder = True
        Me.pnlSpace47.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace47.TabIndex = 1
        '
        'dtfTelAsociado
        '
        Me.dtfTelAsociado.Allow_Empty = True
        Me.dtfTelAsociado.Allow_Negative = True
        Me.dtfTelAsociado.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfTelAsociado.BackColor = System.Drawing.SystemColors.Control
        Me.dtfTelAsociado.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfTelAsociado.DataField = "TEL_VEHI"
        Me.dtfTelAsociado.DataTable = "V1"
        Me.dtfTelAsociado.Descripcion = "Tel. Asociado"
        Me.dtfTelAsociado.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfTelAsociado.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfTelAsociado.FocoEnAgregar = False
        Me.dtfTelAsociado.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfTelAsociado.Image = Nothing
        Me.dtfTelAsociado.Label_Space = 95
        Me.dtfTelAsociado.Length_Data = 32767
        Me.dtfTelAsociado.Location = New System.Drawing.Point(0, 0)
        Me.dtfTelAsociado.Max_Value = 0.0R
        Me.dtfTelAsociado.MensajeIncorrectoCustom = Nothing
        Me.dtfTelAsociado.Name = "dtfTelAsociado"
        Me.dtfTelAsociado.Null_on_Empty = True
        Me.dtfTelAsociado.OpenForm = Nothing
        Me.dtfTelAsociado.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfTelAsociado.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfTelAsociado.ReadOnly_Data = False
        Me.dtfTelAsociado.Show_Button = False
        Me.dtfTelAsociado.Size = New System.Drawing.Size(196, 26)
        Me.dtfTelAsociado.TabIndex = 0
        Me.dtfTelAsociado.Text_Data = ""
        Me.dtfTelAsociado.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfTelAsociado.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfTelAsociado.TopPadding = 0
        Me.dtfTelAsociado.Upper_Case = False
        Me.dtfTelAsociado.Validate_on_lost_focus = True
        '
        'pclCodLlave
        '
        Me.pclCodLlave.Auto_Size = False
        Me.pclCodLlave.BorderColor = System.Drawing.SystemColors.Control
        Me.pclCodLlave.ChangeDock = True
        Me.pclCodLlave.Control_Resize = False
        Me.pclCodLlave.Controls.Add(Me.dtfLlaveMag)
        Me.pclCodLlave.Controls.Add(Me.pnlSpace46)
        Me.pclCodLlave.Controls.Add(Me.dtfCodLlave)
        Me.pclCodLlave.Dock = System.Windows.Forms.DockStyle.Top
        Me.pclCodLlave.isSpace = False
        Me.pclCodLlave.Location = New System.Drawing.Point(3, 81)
        Me.pclCodLlave.Name = "pclCodLlave"
        Me.pclCodLlave.numRows = 1
        Me.pclCodLlave.Reorder = True
        Me.pclCodLlave.Size = New System.Drawing.Size(562, 26)
        Me.pclCodLlave.TabIndex = 3
        '
        'dtfLlaveMag
        '
        Me.dtfLlaveMag.Allow_Empty = True
        Me.dtfLlaveMag.Allow_Negative = True
        Me.dtfLlaveMag.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfLlaveMag.BackColor = System.Drawing.SystemColors.Control
        Me.dtfLlaveMag.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfLlaveMag.DataField = "LLAVE2"
        Me.dtfLlaveMag.DataTable = "V2"
        Me.dtfLlaveMag.Descripcion = "Llave Mag."
        Me.dtfLlaveMag.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfLlaveMag.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfLlaveMag.FocoEnAgregar = False
        Me.dtfLlaveMag.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfLlaveMag.Image = Nothing
        Me.dtfLlaveMag.Label_Space = 85
        Me.dtfLlaveMag.Length_Data = 32767
        Me.dtfLlaveMag.Location = New System.Drawing.Point(202, 0)
        Me.dtfLlaveMag.Max_Value = 0.0R
        Me.dtfLlaveMag.MensajeIncorrectoCustom = Nothing
        Me.dtfLlaveMag.Name = "dtfLlaveMag"
        Me.dtfLlaveMag.Null_on_Empty = True
        Me.dtfLlaveMag.OpenForm = Nothing
        Me.dtfLlaveMag.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfLlaveMag.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfLlaveMag.ReadOnly_Data = False
        Me.dtfLlaveMag.Show_Button = False
        Me.dtfLlaveMag.Size = New System.Drawing.Size(216, 26)
        Me.dtfLlaveMag.TabIndex = 2
        Me.dtfLlaveMag.Text_Data = ""
        Me.dtfLlaveMag.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfLlaveMag.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfLlaveMag.TopPadding = 0
        Me.dtfLlaveMag.Upper_Case = False
        Me.dtfLlaveMag.Validate_on_lost_focus = True
        '
        'pnlSpace46
        '
        Me.pnlSpace46.Auto_Size = False
        Me.pnlSpace46.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pnlSpace46.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace46.ChangeDock = True
        Me.pnlSpace46.Control_Resize = False
        Me.pnlSpace46.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace46.isSpace = True
        Me.pnlSpace46.Location = New System.Drawing.Point(196, 0)
        Me.pnlSpace46.Name = "pnlSpace46"
        Me.pnlSpace46.numRows = 0
        Me.pnlSpace46.Reorder = True
        Me.pnlSpace46.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace46.TabIndex = 1
        '
        'dtfCodLlave
        '
        Me.dtfCodLlave.Allow_Empty = True
        Me.dtfCodLlave.Allow_Negative = True
        Me.dtfCodLlave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfCodLlave.BackColor = System.Drawing.SystemColors.Control
        Me.dtfCodLlave.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfCodLlave.DataField = "LLAVE"
        Me.dtfCodLlave.DataTable = "V2"
        Me.dtfCodLlave.Descripcion = "Código llave"
        Me.dtfCodLlave.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfCodLlave.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfCodLlave.FocoEnAgregar = False
        Me.dtfCodLlave.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfCodLlave.Image = Nothing
        Me.dtfCodLlave.Label_Space = 95
        Me.dtfCodLlave.Length_Data = 32767
        Me.dtfCodLlave.Location = New System.Drawing.Point(0, 0)
        Me.dtfCodLlave.Max_Value = 0.0R
        Me.dtfCodLlave.MensajeIncorrectoCustom = Nothing
        Me.dtfCodLlave.Name = "dtfCodLlave"
        Me.dtfCodLlave.Null_on_Empty = True
        Me.dtfCodLlave.OpenForm = Nothing
        Me.dtfCodLlave.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfCodLlave.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfCodLlave.ReadOnly_Data = False
        Me.dtfCodLlave.Show_Button = False
        Me.dtfCodLlave.Size = New System.Drawing.Size(196, 26)
        Me.dtfCodLlave.TabIndex = 0
        Me.dtfCodLlave.Text_Data = ""
        Me.dtfCodLlave.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfCodLlave.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfCodLlave.TopPadding = 0
        Me.dtfCodLlave.Upper_Case = False
        Me.dtfCodLlave.Validate_on_lost_focus = True
        '
        'pnlDepoLitros
        '
        Me.pnlDepoLitros.Auto_Size = False
        Me.pnlDepoLitros.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlDepoLitros.ChangeDock = True
        Me.pnlDepoLitros.Control_Resize = False
        Me.pnlDepoLitros.Controls.Add(Me.lblOctavos)
        Me.pnlDepoLitros.Controls.Add(Me.dtfOctavos)
        Me.pnlDepoLitros.Controls.Add(Me.pnlSpace45)
        Me.pnlDepoLitros.Controls.Add(Me.dtfDepositoLitros)
        Me.pnlDepoLitros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlDepoLitros.isSpace = False
        Me.pnlDepoLitros.Location = New System.Drawing.Point(3, 55)
        Me.pnlDepoLitros.Name = "pnlDepoLitros"
        Me.pnlDepoLitros.numRows = 1
        Me.pnlDepoLitros.Reorder = True
        Me.pnlDepoLitros.Size = New System.Drawing.Size(562, 26)
        Me.pnlDepoLitros.TabIndex = 2
        '
        'lblOctavos
        '
        Me.lblOctavos.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblOctavos.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblOctavos.Location = New System.Drawing.Point(196, 0)
        Me.lblOctavos.Name = "lblOctavos"
        Me.lblOctavos.Size = New System.Drawing.Size(52, 26)
        Me.lblOctavos.TabIndex = 3
        Me.lblOctavos.Text = "Octavos"
        '
        'dtfOctavos
        '
        Me.dtfOctavos.Allow_Empty = True
        Me.dtfOctavos.Allow_Negative = True
        Me.dtfOctavos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfOctavos.BackColor = System.Drawing.SystemColors.Control
        Me.dtfOctavos.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfOctavos.DataField = Nothing
        Me.dtfOctavos.DataTable = ""
        Me.dtfOctavos.Descripcion = Nothing
        Me.dtfOctavos.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfOctavos.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfOctavos.FocoEnAgregar = False
        Me.dtfOctavos.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfOctavos.Length_Data = 32767
        Me.dtfOctavos.Location = New System.Drawing.Point(159, 0)
        Me.dtfOctavos.Max_Value = 0.0R
        Me.dtfOctavos.MensajeIncorrectoCustom = Nothing
        Me.dtfOctavos.Name = "dtfOctavos"
        Me.dtfOctavos.Null_on_Empty = True
        Me.dtfOctavos.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfOctavos.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfOctavos.ReadOnly_Data = False
        Me.dtfOctavos.Size = New System.Drawing.Size(37, 26)
        Me.dtfOctavos.TabIndex = 2
        Me.dtfOctavos.Text_Data = "/8"
        Me.dtfOctavos.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfOctavos.TopPadding = 0
        Me.dtfOctavos.Upper_Case = False
        Me.dtfOctavos.Validate_on_lost_focus = True
        '
        'pnlSpace45
        '
        Me.pnlSpace45.Auto_Size = False
        Me.pnlSpace45.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pnlSpace45.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace45.ChangeDock = True
        Me.pnlSpace45.Control_Resize = False
        Me.pnlSpace45.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace45.isSpace = True
        Me.pnlSpace45.Location = New System.Drawing.Point(153, 0)
        Me.pnlSpace45.Name = "pnlSpace45"
        Me.pnlSpace45.numRows = 0
        Me.pnlSpace45.Reorder = True
        Me.pnlSpace45.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace45.TabIndex = 1
        '
        'dtfDepositoLitros
        '
        Me.dtfDepositoLitros.Allow_Empty = True
        Me.dtfDepositoLitros.Allow_Negative = True
        Me.dtfDepositoLitros.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfDepositoLitros.BackColor = System.Drawing.SystemColors.Control
        Me.dtfDepositoLitros.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfDepositoLitros.DataField = "litros"
        Me.dtfDepositoLitros.DataTable = "V2"
        Me.dtfDepositoLitros.Descripcion = "Depósito Litros"
        Me.dtfDepositoLitros.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfDepositoLitros.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfDepositoLitros.FocoEnAgregar = False
        Me.dtfDepositoLitros.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfDepositoLitros.Image = Nothing
        Me.dtfDepositoLitros.Label_Space = 95
        Me.dtfDepositoLitros.Length_Data = 32767
        Me.dtfDepositoLitros.Location = New System.Drawing.Point(0, 0)
        Me.dtfDepositoLitros.Max_Value = 0.0R
        Me.dtfDepositoLitros.MensajeIncorrectoCustom = Nothing
        Me.dtfDepositoLitros.Name = "dtfDepositoLitros"
        Me.dtfDepositoLitros.Null_on_Empty = True
        Me.dtfDepositoLitros.OpenForm = Nothing
        Me.dtfDepositoLitros.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfDepositoLitros.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfDepositoLitros.ReadOnly_Data = False
        Me.dtfDepositoLitros.Show_Button = False
        Me.dtfDepositoLitros.Size = New System.Drawing.Size(153, 26)
        Me.dtfDepositoLitros.TabIndex = 0
        Me.dtfDepositoLitros.Text_Data = ""
        Me.dtfDepositoLitros.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfDepositoLitros.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfDepositoLitros.TopPadding = 0
        Me.dtfDepositoLitros.Upper_Case = False
        Me.dtfDepositoLitros.Validate_on_lost_focus = True
        '
        'pnlKmMaximoOtros
        '
        Me.pnlKmMaximoOtros.Auto_Size = False
        Me.pnlKmMaximoOtros.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlKmMaximoOtros.ChangeDock = True
        Me.pnlKmMaximoOtros.Control_Resize = False
        Me.pnlKmMaximoOtros.Controls.Add(Me.dtfKmMaximos)
        Me.pnlKmMaximoOtros.Controls.Add(Me.pnlSpace44)
        Me.pnlKmMaximoOtros.Controls.Add(Me.dtfCombustibleOtros)
        Me.pnlKmMaximoOtros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlKmMaximoOtros.isSpace = False
        Me.pnlKmMaximoOtros.Location = New System.Drawing.Point(3, 29)
        Me.pnlKmMaximoOtros.Name = "pnlKmMaximoOtros"
        Me.pnlKmMaximoOtros.numRows = 1
        Me.pnlKmMaximoOtros.Reorder = True
        Me.pnlKmMaximoOtros.Size = New System.Drawing.Size(562, 26)
        Me.pnlKmMaximoOtros.TabIndex = 1
        '
        'dtfKmMaximos
        '
        Me.dtfKmMaximos.Allow_Empty = True
        Me.dtfKmMaximos.Allow_Negative = True
        Me.dtfKmMaximos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfKmMaximos.BackColor = System.Drawing.SystemColors.Control
        Me.dtfKmMaximos.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfKmMaximos.DataField = "kmMax"
        Me.dtfKmMaximos.DataTable = "V2"
        Me.dtfKmMaximos.Descripcion = "Kms Máx."
        Me.dtfKmMaximos.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfKmMaximos.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfKmMaximos.FocoEnAgregar = False
        Me.dtfKmMaximos.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfKmMaximos.Image = Nothing
        Me.dtfKmMaximos.Label_Space = 60
        Me.dtfKmMaximos.Length_Data = 32767
        Me.dtfKmMaximos.Location = New System.Drawing.Point(202, 0)
        Me.dtfKmMaximos.Max_Value = 0.0R
        Me.dtfKmMaximos.MensajeIncorrectoCustom = Nothing
        Me.dtfKmMaximos.Name = "dtfKmMaximos"
        Me.dtfKmMaximos.Null_on_Empty = True
        Me.dtfKmMaximos.OpenForm = Nothing
        Me.dtfKmMaximos.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfKmMaximos.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfKmMaximos.ReadOnly_Data = False
        Me.dtfKmMaximos.Show_Button = False
        Me.dtfKmMaximos.Size = New System.Drawing.Size(120, 26)
        Me.dtfKmMaximos.TabIndex = 2
        Me.dtfKmMaximos.Text_Data = ""
        Me.dtfKmMaximos.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfKmMaximos.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfKmMaximos.TopPadding = 0
        Me.dtfKmMaximos.Upper_Case = False
        Me.dtfKmMaximos.Validate_on_lost_focus = True
        '
        'pnlSpace44
        '
        Me.pnlSpace44.Auto_Size = False
        Me.pnlSpace44.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pnlSpace44.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace44.ChangeDock = True
        Me.pnlSpace44.Control_Resize = False
        Me.pnlSpace44.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace44.isSpace = True
        Me.pnlSpace44.Location = New System.Drawing.Point(196, 0)
        Me.pnlSpace44.Name = "pnlSpace44"
        Me.pnlSpace44.numRows = 0
        Me.pnlSpace44.Reorder = True
        Me.pnlSpace44.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace44.TabIndex = 1
        '
        'dtfCombustibleOtros
        '
        Me.dtfCombustibleOtros.Allow_Empty = True
        Me.dtfCombustibleOtros.Allow_Negative = True
        Me.dtfCombustibleOtros.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfCombustibleOtros.BackColor = System.Drawing.SystemColors.Control
        Me.dtfCombustibleOtros.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfCombustibleOtros.DataField = "COMBUS"
        Me.dtfCombustibleOtros.DataTable = "V2"
        Me.dtfCombustibleOtros.Descripcion = "Combustible"
        Me.dtfCombustibleOtros.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfCombustibleOtros.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfCombustibleOtros.FocoEnAgregar = False
        Me.dtfCombustibleOtros.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfCombustibleOtros.Image = Nothing
        Me.dtfCombustibleOtros.Label_Space = 95
        Me.dtfCombustibleOtros.Length_Data = 32767
        Me.dtfCombustibleOtros.Location = New System.Drawing.Point(0, 0)
        Me.dtfCombustibleOtros.Max_Value = 0.0R
        Me.dtfCombustibleOtros.MensajeIncorrectoCustom = Nothing
        Me.dtfCombustibleOtros.Name = "dtfCombustibleOtros"
        Me.dtfCombustibleOtros.Null_on_Empty = True
        Me.dtfCombustibleOtros.OpenForm = Nothing
        Me.dtfCombustibleOtros.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfCombustibleOtros.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfCombustibleOtros.ReadOnly_Data = True
        Me.dtfCombustibleOtros.Show_Button = False
        Me.dtfCombustibleOtros.Size = New System.Drawing.Size(196, 26)
        Me.dtfCombustibleOtros.TabIndex = 0
        Me.dtfCombustibleOtros.TabStop = False
        Me.dtfCombustibleOtros.Text_Data = ""
        Me.dtfCombustibleOtros.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfCombustibleOtros.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfCombustibleOtros.TopPadding = 0
        Me.dtfCombustibleOtros.Upper_Case = False
        Me.dtfCombustibleOtros.Validate_on_lost_focus = True
        '
        'pnlKmOtros
        '
        Me.pnlKmOtros.Auto_Size = False
        Me.pnlKmOtros.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlKmOtros.ChangeDock = True
        Me.pnlKmOtros.Control_Resize = False
        Me.pnlKmOtros.Controls.Add(Me.dtdFechaKmRes)
        Me.pnlKmOtros.Controls.Add(Me.pnlSpace42)
        Me.pnlKmOtros.Controls.Add(Me.dtfKmResOtros)
        Me.pnlKmOtros.Controls.Add(Me.pnlSpace43)
        Me.pnlKmOtros.Controls.Add(Me.dtdFechaKm)
        Me.pnlKmOtros.Controls.Add(Me.pnlSpace41)
        Me.pnlKmOtros.Controls.Add(Me.dtfKmOtros)
        Me.pnlKmOtros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlKmOtros.isSpace = False
        Me.pnlKmOtros.Location = New System.Drawing.Point(3, 3)
        Me.pnlKmOtros.Name = "pnlKmOtros"
        Me.pnlKmOtros.numRows = 1
        Me.pnlKmOtros.Reorder = True
        Me.pnlKmOtros.Size = New System.Drawing.Size(562, 26)
        Me.pnlKmOtros.TabIndex = 0
        '
        'dtdFechaKmRes
        '
        Me.dtdFechaKmRes.Allow_Empty = True
        Me.dtdFechaKmRes.DataField = "FECKMSCHG_V2"
        Me.dtdFechaKmRes.DataTable = "V2"
        Me.dtdFechaKmRes.Default_Value = New Date(2016, 5, 2, 0, 0, 0, 0)
        Me.dtdFechaKmRes.Descripcion = Nothing
        Me.dtdFechaKmRes.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtdFechaKmRes.FocoEnAgregar = False
        Me.dtdFechaKmRes.Location = New System.Drawing.Point(328, 0)
        Me.dtdFechaKmRes.Max_Value = Nothing
        Me.dtdFechaKmRes.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdFechaKmRes.MensajeIncorrectoCustom = Nothing
        Me.dtdFechaKmRes.Min_Value = Nothing
        Me.dtdFechaKmRes.MinDate = New Date(CType(0, Long))
        Me.dtdFechaKmRes.Name = "dtdFechaKmRes"
        Me.dtdFechaKmRes.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdFechaKmRes.ReadOnly_Data = False
        Me.dtdFechaKmRes.Size = New System.Drawing.Size(90, 26)
        Me.dtdFechaKmRes.TabIndex = 6
        Me.dtdFechaKmRes.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdFechaKmRes.Validate_on_lost_focus = True
        Me.dtdFechaKmRes.Value_Data = New Date(2016, 5, 2, 0, 0, 0, 0)
        '
        'pnlSpace42
        '
        Me.pnlSpace42.Auto_Size = False
        Me.pnlSpace42.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pnlSpace42.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace42.ChangeDock = True
        Me.pnlSpace42.Control_Resize = False
        Me.pnlSpace42.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace42.isSpace = True
        Me.pnlSpace42.Location = New System.Drawing.Point(322, 0)
        Me.pnlSpace42.Name = "pnlSpace42"
        Me.pnlSpace42.numRows = 0
        Me.pnlSpace42.Reorder = True
        Me.pnlSpace42.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace42.TabIndex = 5
        '
        'dtfKmResOtros
        '
        Me.dtfKmResOtros.Allow_Empty = True
        Me.dtfKmResOtros.Allow_Negative = True
        Me.dtfKmResOtros.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfKmResOtros.BackColor = System.Drawing.SystemColors.Control
        Me.dtfKmResOtros.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfKmResOtros.DataField = "kmresta"
        Me.dtfKmResOtros.DataTable = "V1"
        Me.dtfKmResOtros.Descripcion = "KmRes."
        Me.dtfKmResOtros.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfKmResOtros.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfKmResOtros.FocoEnAgregar = False
        Me.dtfKmResOtros.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfKmResOtros.Image = Nothing
        Me.dtfKmResOtros.Label_Space = 60
        Me.dtfKmResOtros.Length_Data = 32767
        Me.dtfKmResOtros.Location = New System.Drawing.Point(202, 0)
        Me.dtfKmResOtros.Max_Value = 0.0R
        Me.dtfKmResOtros.MensajeIncorrectoCustom = Nothing
        Me.dtfKmResOtros.Name = "dtfKmResOtros"
        Me.dtfKmResOtros.Null_on_Empty = True
        Me.dtfKmResOtros.OpenForm = Nothing
        Me.dtfKmResOtros.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfKmResOtros.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfKmResOtros.ReadOnly_Data = False
        Me.dtfKmResOtros.Show_Button = False
        Me.dtfKmResOtros.Size = New System.Drawing.Size(120, 26)
        Me.dtfKmResOtros.TabIndex = 4
        Me.dtfKmResOtros.Text_Data = ""
        Me.dtfKmResOtros.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfKmResOtros.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfKmResOtros.TopPadding = 0
        Me.dtfKmResOtros.Upper_Case = False
        Me.dtfKmResOtros.Validate_on_lost_focus = True
        '
        'pnlSpace43
        '
        Me.pnlSpace43.Auto_Size = False
        Me.pnlSpace43.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pnlSpace43.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace43.ChangeDock = True
        Me.pnlSpace43.Control_Resize = False
        Me.pnlSpace43.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace43.isSpace = True
        Me.pnlSpace43.Location = New System.Drawing.Point(196, 0)
        Me.pnlSpace43.Name = "pnlSpace43"
        Me.pnlSpace43.numRows = 0
        Me.pnlSpace43.Reorder = True
        Me.pnlSpace43.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace43.TabIndex = 3
        '
        'dtdFechaKm
        '
        Me.dtdFechaKm.Allow_Empty = True
        Me.dtdFechaKm.DataField = "FCAMBIO_KM"
        Me.dtdFechaKm.DataTable = "V2"
        Me.dtdFechaKm.Default_Value = New Date(2016, 5, 2, 0, 0, 0, 0)
        Me.dtdFechaKm.Descripcion = Nothing
        Me.dtdFechaKm.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtdFechaKm.FocoEnAgregar = False
        Me.dtdFechaKm.Location = New System.Drawing.Point(106, 0)
        Me.dtdFechaKm.Max_Value = Nothing
        Me.dtdFechaKm.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdFechaKm.MensajeIncorrectoCustom = Nothing
        Me.dtdFechaKm.Min_Value = Nothing
        Me.dtdFechaKm.MinDate = New Date(CType(0, Long))
        Me.dtdFechaKm.Name = "dtdFechaKm"
        Me.dtdFechaKm.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdFechaKm.ReadOnly_Data = False
        Me.dtdFechaKm.Size = New System.Drawing.Size(90, 26)
        Me.dtdFechaKm.TabIndex = 2
        Me.dtdFechaKm.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdFechaKm.Validate_on_lost_focus = True
        Me.dtdFechaKm.Value_Data = New Date(2016, 5, 2, 0, 0, 0, 0)
        '
        'pnlSpace41
        '
        Me.pnlSpace41.Auto_Size = False
        Me.pnlSpace41.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pnlSpace41.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace41.ChangeDock = True
        Me.pnlSpace41.Control_Resize = False
        Me.pnlSpace41.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace41.isSpace = True
        Me.pnlSpace41.Location = New System.Drawing.Point(100, 0)
        Me.pnlSpace41.Name = "pnlSpace41"
        Me.pnlSpace41.numRows = 0
        Me.pnlSpace41.Reorder = True
        Me.pnlSpace41.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace41.TabIndex = 1
        '
        'dtfKmOtros
        '
        Me.dtfKmOtros.Allow_Empty = True
        Me.dtfKmOtros.Allow_Negative = True
        Me.dtfKmOtros.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfKmOtros.BackColor = System.Drawing.SystemColors.Control
        Me.dtfKmOtros.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfKmOtros.DataField = "km"
        Me.dtfKmOtros.DataTable = "V2"
        Me.dtfKmOtros.Descripcion = "Km"
        Me.dtfKmOtros.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfKmOtros.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfKmOtros.FocoEnAgregar = False
        Me.dtfKmOtros.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfKmOtros.Image = Nothing
        Me.dtfKmOtros.Label_Space = 35
        Me.dtfKmOtros.Length_Data = 32767
        Me.dtfKmOtros.Location = New System.Drawing.Point(0, 0)
        Me.dtfKmOtros.Max_Value = 0.0R
        Me.dtfKmOtros.MensajeIncorrectoCustom = Nothing
        Me.dtfKmOtros.Name = "dtfKmOtros"
        Me.dtfKmOtros.Null_on_Empty = True
        Me.dtfKmOtros.OpenForm = Nothing
        Me.dtfKmOtros.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfKmOtros.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfKmOtros.ReadOnly_Data = False
        Me.dtfKmOtros.Show_Button = False
        Me.dtfKmOtros.Size = New System.Drawing.Size(100, 26)
        Me.dtfKmOtros.TabIndex = 0
        Me.dtfKmOtros.Text_Data = ""
        Me.dtfKmOtros.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfKmOtros.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfKmOtros.TopPadding = 0
        Me.dtfKmOtros.Upper_Case = False
        Me.dtfKmOtros.Validate_on_lost_focus = True
        '
        'pnlCabeceraOtros
        '
        Me.pnlCabeceraOtros.Auto_Size = False
        Me.pnlCabeceraOtros.BackColor = System.Drawing.Color.RosyBrown
        Me.pnlCabeceraOtros.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlCabeceraOtros.ChangeDock = False
        Me.pnlCabeceraOtros.Control_Resize = False
        Me.pnlCabeceraOtros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCabeceraOtros.isSpace = False
        Me.pnlCabeceraOtros.Location = New System.Drawing.Point(0, 0)
        Me.pnlCabeceraOtros.Name = "pnlCabeceraOtros"
        Me.pnlCabeceraOtros.numRows = 0
        Me.pnlCabeceraOtros.Reorder = True
        Me.pnlCabeceraOtros.Size = New System.Drawing.Size(1138, 88)
        Me.pnlCabeceraOtros.TabIndex = 2
        '
        'pvpMantenimiento
        '
        Me.pvpMantenimiento.ItemSize = New System.Drawing.SizeF(102.0!, 23.0!)
        Me.pvpMantenimiento.Location = New System.Drawing.Point(129, 5)
        Me.pvpMantenimiento.Name = "pvpMantenimiento"
        Me.pvpMantenimiento.PanelCabezeraContainer = Nothing
        Me.pvpMantenimiento.Size = New System.Drawing.Size(1138, 500)
        Me.pvpMantenimiento.Text = "Mantenimientos"
        '
        'PageViewPage2
        '
        Me.PageViewPage2.ItemSize = New System.Drawing.SizeF(102.0!, 23.0!)
        Me.PageViewPage2.Location = New System.Drawing.Point(129, 5)
        Me.PageViewPage2.Name = "PageViewPage2"
        Me.PageViewPage2.PanelCabezeraContainer = Nothing
        Me.PageViewPage2.Size = New System.Drawing.Size(1138, 500)
        Me.PageViewPage2.Text = "PageViewPage2"
        '
        'Vehiculos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1272, 695)
        Me.Name = "Vehiculos"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = true
        Me.Text = "Vehiculos"
        CType(Me.pnlBlock,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pvwBase,System.ComponentModel.ISupportInitialize).EndInit
        Me.pvwBase.ResumeLayout(false)
        CType(Me.stbBase,System.ComponentModel.ISupportInitialize).EndInit
        Me.pvpGeneral.ResumeLayout(false)
        CType(Me.pnPpal,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnPpal.ResumeLayout(false)
        CType(Me.pnlPpal_Fill,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlPpal_Fill.ResumeLayout(false)
        CType(Me.pnlSpace,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pnPpal_Izq,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnPpal_Izq.ResumeLayout(false)
        CType(Me.pnlFechas,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlFechas.ResumeLayout(false)
        CType(Me.penGenGen,System.ComponentModel.ISupportInitialize).EndInit
        Me.penGenGen.ResumeLayout(false)
        CType(Me.pnlGen,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlGen.ResumeLayout(false)
        CType(Me.pnlAsocia,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlAsocia.ResumeLayout(false)
        CType(Me.Panel2,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pnlMarca,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlMarca.ResumeLayout(false)
        CType(Me.pnlCodigo,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlCodigo.ResumeLayout(false)
        CType(Me.Panel1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pnlSpace1,System.ComponentModel.ISupportInitialize).EndInit
        Me.pvpCompraVenta.ResumeLayout(false)
        CType(Me.pnlComVenDer,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlComVenDer.ResumeLayout(false)
        CType(Me.gbxImpuesto,System.ComponentModel.ISupportInitialize).EndInit
        Me.gbxImpuesto.ResumeLayout(false)
        CType(Me.Panel14,System.ComponentModel.ISupportInitialize).EndInit
        Me.Panel14.ResumeLayout(false)
        CType(Me.Panel16,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.gbxVentaVeh,System.ComponentModel.ISupportInitialize).EndInit
        Me.gbxVentaVeh.ResumeLayout(false)
        CType(Me.Panel4,System.ComponentModel.ISupportInitialize).EndInit
        Me.Panel4.ResumeLayout(false)
        CType(Me.Panel3,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.Panel5,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.Panel9,System.ComponentModel.ISupportInitialize).EndInit
        Me.Panel9.ResumeLayout(false)
        CType(Me.Panel10,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.Panel12,System.ComponentModel.ISupportInitialize).EndInit
        Me.Panel12.ResumeLayout(false)
        CType(Me.Panel13,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pnlSpace15,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pnlComVenIzq,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlComVenIzq.ResumeLayout(false)
        CType(Me.gbxLeasing,System.ComponentModel.ISupportInitialize).EndInit
        Me.gbxLeasing.ResumeLayout(false)
        CType(Me.pnlCuotaLeasing,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlCuotaLeasing.ResumeLayout(false)
        Me.pnlCuotaLeasing.PerformLayout
        CType(Me.pnlSpace5,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.Label1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pnlSpace6,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pnlOtorgamiento,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlOtorgamiento.ResumeLayout(false)
        CType(Me.pnlSpace7,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pnlSpace8,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pnlContratoLeasing,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlContratoLeasing.ResumeLayout(false)
        Me.pnlContratoLeasing.PerformLayout
        CType(Me.pnlSpace11,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.lblPorcen1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pnlSpace10,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pnlFechasLeasing,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlFechasLeasing.ResumeLayout(false)
        CType(Me.pnlSpace9,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.gbxCompra,System.ComponentModel.ISupportInitialize).EndInit
        Me.gbxCompra.ResumeLayout(false)
        CType(Me.pnlPrecioFranco,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlPrecioFranco.ResumeLayout(false)
        CType(Me.pnlSpace14,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.Panel7,System.ComponentModel.ISupportInitialize).EndInit
        Me.Panel7.ResumeLayout(false)
        CType(Me.pnlSpace3,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pnlFechasCompra,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlFechasCompra.ResumeLayout(false)
        CType(Me.pnlSpace4,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pnlFormaPago,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlFormaPago.ResumeLayout(false)
        CType(Me.pnlSpace12,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pnlPreciosCompra,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlPreciosCompra.ResumeLayout(false)
        CType(Me.pnlSpace13,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pnlCabeceraCV,System.ComponentModel.ISupportInitialize).EndInit
        Me.pvpFichaTecnica.ResumeLayout(false)
        CType(Me.pnlGenFichaTec,System.ComponentModel.ISupportInitialize).EndInit
        Me.pvpseguros.ResumeLayout(false)
        CType(Me.Panel37,System.ComponentModel.ISupportInitialize).EndInit
        Me.Panel37.ResumeLayout(false)
        CType(Me.Panel64,System.ComponentModel.ISupportInitialize).EndInit
        Me.Panel64.ResumeLayout(false)
        CType(Me.btnParteAmis,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.Panel65,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.btnHistorico,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.gbxSegAd3,System.ComponentModel.ISupportInitialize).EndInit
        Me.gbxSegAd3.ResumeLayout(false)
        CType(Me.pnlSupSA3inf,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlSupSA3inf.ResumeLayout(false)
        CType(Me.Panel58,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pnlSpace30,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pnlSupSA3mid,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlSupSA3mid.ResumeLayout(false)
        CType(Me.pnlSpace29,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pnlSupSA3top,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlSupSA3top.ResumeLayout(false)
        CType(Me.pnlSpace28,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.gbxSegAd2,System.ComponentModel.ISupportInitialize).EndInit
        Me.gbxSegAd2.ResumeLayout(false)
        CType(Me.pnlSupSA2inf,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlSupSA2inf.ResumeLayout(false)
        CType(Me.Panel51,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pnlSpace27,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pnlSupSA2mid,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlSupSA2mid.ResumeLayout(false)
        CType(Me.pnlSpace26,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pnlSupSA2top,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlSupSA2top.ResumeLayout(false)
        CType(Me.pnlSpace25,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.gbxSegAd1,System.ComponentModel.ISupportInitialize).EndInit
        Me.gbxSegAd1.ResumeLayout(false)
        CType(Me.pnlSupSA1inf,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlSupSA1inf.ResumeLayout(false)
        CType(Me.Panel48,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pnlSpace24,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pnlSupSA1mid,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlSupSA1mid.ResumeLayout(false)
        CType(Me.pnlSpace23,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pnlSupSA1top,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlSupSA1top.ResumeLayout(false)
        CType(Me.pnlSpace22,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.gbxOtrosDSeg,System.ComponentModel.ISupportInitialize).EndInit
        Me.gbxOtrosDSeg.ResumeLayout(false)
        CType(Me.pnlOtrosDSegInf,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlOtrosDSegInf.ResumeLayout(false)
        Me.pnlOtrosDSegInf.PerformLayout
        CType(Me.chkEnVehic,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pnlSpace21,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.chkTenemosRec,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pnlSpace20,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.chkTodoRiesgo,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pnlOtrosDSegSup,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlOtrosDSegSup.ResumeLayout(false)
        Me.pnlOtrosDSegSup.PerformLayout
        CType(Me.pnlSpace19,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.chkSegInternacional,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pnlIzqSeguro,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlIzqSeguro.ResumeLayout(false)
        CType(Me.gbxPagos,System.ComponentModel.ISupportInitialize).EndInit
        Me.gbxPagos.ResumeLayout(false)
        CType(Me.Panel36,System.ComponentModel.ISupportInitialize).EndInit
        Me.Panel36.ResumeLayout(false)
        CType(Me.pnlPagoSeg4,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlPagoSeg4.ResumeLayout(false)
        Me.pnlPagoSeg4.PerformLayout
        CType(Me.chkPagado4,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pnlSpace40,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pnlSpace34,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pnlPagoSeg3,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlPagoSeg3.ResumeLayout(false)
        Me.pnlPagoSeg3.PerformLayout
        CType(Me.chkPagado3,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pnlSpace39,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pnlSpace33,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pnlPagoSeg2,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlPagoSeg2.ResumeLayout(false)
        Me.pnlPagoSeg2.PerformLayout
        CType(Me.chkPagado2,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pnlSpace38,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pnlSpace32,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pnlPagoSeg1,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlPagoSeg1.ResumeLayout(false)
        Me.pnlPagoSeg1.PerformLayout
        CType(Me.chkPagado1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pnlSpace37,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pnlSpace31,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.gbxDatosSeguro,System.ComponentModel.ISupportInitialize).EndInit
        Me.gbxDatosSeguro.ResumeLayout(false)
        CType(Me.pnlDatosSegInf,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlDatosSegInf.ResumeLayout(false)
        CType(Me.Panel68,System.ComponentModel.ISupportInitialize).EndInit
        Me.Panel68.ResumeLayout(false)
        CType(Me.rdgFormaPagoSeg,System.ComponentModel.ISupportInitialize).EndInit
        Me.rdgFormaPagoSeg.ResumeLayout(false)
        Me.rdgFormaPagoSeg.PerformLayout
        CType(Me.radFP4,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.radFP3,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.radFP2,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.radFP1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pnlSpace18,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pnlTipoSegObs,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlTipoSegObs.ResumeLayout(false)
        CType(Me.pnlPrimaPendSeg,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlPrimaPendSeg.ResumeLayout(false)
        CType(Me.Panel23,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.Panel22,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pnlSpace35,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pnlFechasSeg,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlFechasSeg.ResumeLayout(false)
        CType(Me.Panel19,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pnlSpace36,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pnlAgenteFranq,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlAgenteFranq.ResumeLayout(false)
        CType(Me.pnlSpace16,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.Panel6,System.ComponentModel.ISupportInitialize).EndInit
        Me.Panel6.ResumeLayout(false)
        CType(Me.pnlSpace17,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pnlCabeceraSeguro,System.ComponentModel.ISupportInitialize).EndInit
        Me.pvpOtros.ResumeLayout(false)
        CType(Me.pnlOtrosDer,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlOtrosDer.ResumeLayout(false)
        CType(Me.pnlGarantiaExt,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlGarantiaExt.ResumeLayout(false)
        CType(Me.pnlSpace60,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pnlSpace59,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pnlPuestaEnServ,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlPuestaEnServ.ResumeLayout(false)
        CType(Me.btnDocVeh,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pnlSpace58,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pnlSpace57,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pnlitvOtros,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlitvOtros.ResumeLayout(false)
        CType(Me.pnlSpace56,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pnlManteOtros,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlManteOtros.ResumeLayout(false)
        CType(Me.pnlSpace55,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pnlContratoOtros,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlContratoOtros.ResumeLayout(false)
        CType(Me.pnlSpace54,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pnlSpace53,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pnlClienteSit,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlClienteSit.ResumeLayout(false)
        CType(Me.pnlSpace52,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pnlSituacionOtros,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlSituacionOtros.ResumeLayout(false)
        Me.pnlSituacionOtros.PerformLayout
        CType(Me.DataCheck1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pnlSpace51,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.btnRecalcularSit,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pnlSpace50,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pnlUbicacionOtros,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlUbicacionOtros.ResumeLayout(false)
        CType(Me.pnlOficinasOtros,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlOficinasOtros.ResumeLayout(false)
        CType(Me.pnlSpace49,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pnlOtrosIzq,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlOtrosIzq.ResumeLayout(false)
        CType(Me.pnlLocalizador,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlLocalizador.ResumeLayout(false)
        Me.pnlLocalizador.PerformLayout
        CType(Me.btnHistoricoOtros,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.Panel18,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.btnIncidencias,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.Panel8,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.dtcLocalizadorOtros,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pnlCuentaOtros,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlCuentaOtros.ResumeLayout(false)
        CType(Me.pnlModeloDiasMax,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlModeloDiasMax.ResumeLayout(false)
        CType(Me.Panel17,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pnlMotorTap,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlMotorTap.ResumeLayout(false)
        CType(Me.Panel15,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pnlCodBateria,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlCodBateria.ResumeLayout(false)
        CType(Me.Panel11,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pnlPlazasPuertas,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlPlazasPuertas.ResumeLayout(false)
        CType(Me.pnlSpace48,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pnlSpace47,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pclCodLlave,System.ComponentModel.ISupportInitialize).EndInit
        Me.pclCodLlave.ResumeLayout(false)
        CType(Me.pnlSpace46,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pnlDepoLitros,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlDepoLitros.ResumeLayout(false)
        Me.pnlDepoLitros.PerformLayout
        CType(Me.lblOctavos,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pnlSpace45,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pnlKmMaximoOtros,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlKmMaximoOtros.ResumeLayout(false)
        CType(Me.pnlSpace44,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pnlKmOtros,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlKmOtros.ResumeLayout(false)
        CType(Me.pnlSpace42,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pnlSpace43,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pnlSpace41,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pnlCabeceraOtros,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents pvpGeneral As CustomControls.PageViewPage
    Friend WithEvents pvpCompraVenta As CustomControls.PageViewPage
    Friend WithEvents penGenGen As CustomControls.Panel
    Friend WithEvents pnlGen As CustomControls.Panel
    Friend WithEvents pnlCodigo As CustomControls.Panel
    Friend WithEvents dtfColor As CustomControls.DualDatafieldLabel
    Friend WithEvents Panel1 As CustomControls.Panel
    Friend WithEvents dtfMatricula As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace1 As CustomControls.Panel
    Friend WithEvents dtfCodigo As CustomControls.DatafieldLabel
    Friend WithEvents pnlAsocia As CustomControls.Panel
    Friend WithEvents pnlMarca As CustomControls.Panel
    Friend WithEvents dtfMarca As CustomControls.DualDataFieldEditableLabel
    Friend WithEvents Panel2 As CustomControls.Panel
    Friend WithEvents pnPpal As CustomControls.Panel
    Friend WithEvents pnlPpal_Fill As CustomControls.Panel
    Friend WithEvents pnPpal_Izq As CustomControls.Panel
    Friend WithEvents dtfBastidor As CustomControls.DatafieldLabel
    Friend WithEvents dtfGrupo As CustomControls.DualDatafieldLabel
    Friend WithEvents pnlSpace As CustomControls.Panel
    Friend WithEvents dtaObserva As CustomControls.DataAreaLabel
    Friend WithEvents dtaDanos As CustomControls.DataAreaLabel
    Friend WithEvents DataAreaLabel1 As CustomControls.DataAreaLabel
    Friend WithEvents dtaExtras As CustomControls.DataAreaLabel
    Friend WithEvents pnlFechas As CustomControls.Panel
    Friend WithEvents dtdFCompra As CustomControls.DataDateLabel
    Friend WithEvents dtdFBaja As CustomControls.DataDateLabel
    Friend WithEvents dtfModelo As Karve.frm.Vehiculos.LupaModelo
    Friend WithEvents dtdFMatric As CustomControls.DataDateLabel
    Friend WithEvents dtdFFabrica As CustomControls.DataDateLabel
    Friend WithEvents dtfActividad As CustomControls.DualDatafieldLabel
    Friend WithEvents dtfDevPrev As CustomControls.DataDateLabel
    Friend WithEvents pvpFichaTecnica As CustomControls.PageViewPage
    Friend WithEvents pnlGenFichaTec As CustomControls.Panel
    Friend WithEvents ftvVehi As Karve.frm.Auxiliares.FichaTecnicaVehiculo
    Friend WithEvents gbxCompra As CustomControls.GroupBox
    Friend WithEvents pnlComVenDer As CustomControls.Panel
    Friend WithEvents pnlComVenIzq As CustomControls.Panel
    Friend WithEvents pnlCabeceraCV As CustomControls.Panel
    Friend WithEvents gbxImpuesto As CustomControls.GroupBox
    Friend WithEvents pnlPrecioFranco As CustomControls.Panel
    Friend WithEvents dtfPrecioFrancoOp As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace14 As CustomControls.Panel
    Friend WithEvents dtfPrecioFranco As CustomControls.DatafieldLabel
    Friend WithEvents Panel7 As CustomControls.Panel
    Friend WithEvents dtfTTransporte As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace3 As CustomControls.Panel
    Friend WithEvents dtfBonificacion As CustomControls.DatafieldLabel
    Friend WithEvents pnlFechasCompra As CustomControls.Panel
    Friend WithEvents dtfNombre As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace4 As CustomControls.Panel
    Friend WithEvents dtlMatriculacion As CustomControls.DataDateLabel
    Friend WithEvents pnlFormaPago As CustomControls.Panel
    Friend WithEvents pnlSpace12 As CustomControls.Panel
    Friend WithEvents dtfPrecio As CustomControls.DatafieldLabel
    Friend WithEvents pnlPreciosCompra As CustomControls.Panel
    Friend WithEvents pnlSpace13 As CustomControls.Panel
    Friend WithEvents dtfFacturaN As CustomControls.DatafieldLabel
    Friend WithEvents dtfProveedor As CustomControls.DualDatafieldLabel
    Friend WithEvents dtlFechaCompra As CustomControls.DataDateLabel
    Friend WithEvents dtfFormaPagoCompra As CustomControls.DualDatafieldLabel
    Friend WithEvents gbxVentaVeh As CustomControls.GroupBox
    Friend WithEvents gbxLeasing As CustomControls.GroupBox
    Friend WithEvents dtaNotasLeasing As CustomControls.DataAreaLabel
    Friend WithEvents pnlCuotaLeasing As CustomControls.Panel
    Friend WithEvents pnlSpace5 As CustomControls.Panel
    Friend WithEvents Label1 As CustomControls.Label
    Friend WithEvents dtfInteresMorat As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace6 As CustomControls.Panel
    Friend WithEvents dtfKMExc As CustomControls.DatafieldLabel
    Friend WithEvents pnlOtorgamiento As CustomControls.Panel
    Friend WithEvents dtfImpFinan As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace7 As CustomControls.Panel
    Friend WithEvents dtfDiaPago As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace8 As CustomControls.Panel
    Friend WithEvents dtfComisionOto As CustomControls.DatafieldLabel
    Friend WithEvents pnlContratoLeasing As CustomControls.Panel
    Friend WithEvents dtfCuota As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace11 As CustomControls.Panel
    Friend WithEvents lblPorcen1 As CustomControls.Label
    Friend WithEvents dtfInteres As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace10 As CustomControls.Panel
    Friend WithEvents dtfContrato As CustomControls.DatafieldLabel
    Friend WithEvents pnlFechasLeasing As CustomControls.Panel
    Friend WithEvents dtlFinal As CustomControls.DataDateLabel
    Friend WithEvents pnlSpace9 As CustomControls.Panel
    Friend WithEvents dtlInicio As CustomControls.DataDateLabel
    Friend WithEvents dtfCompañia As CustomControls.DualDatafieldLabel
    Friend WithEvents dtfZonaImpuesto As CustomControls.DualDatafieldLabel
    Friend WithEvents dtfPoblacionImp As CustomControls.DualDatafieldLabel
    Friend WithEvents Panel14 As CustomControls.Panel
    Friend WithEvents dtfImporteImp As CustomControls.DatafieldLabel
    Friend WithEvents Panel16 As CustomControls.Panel
    Friend WithEvents dtlFechaAltaImp As CustomControls.DataDateLabel
    Friend WithEvents Panel4 As CustomControls.Panel
    Friend WithEvents dtlTransfer As CustomControls.DataDateLabel
    Friend WithEvents Panel3 As CustomControls.Panel
    Friend WithEvents dtlBajaSeguro As CustomControls.DataDateLabel
    Friend WithEvents Panel5 As CustomControls.Panel
    Friend WithEvents dtlBajaTrafico As CustomControls.DataDateLabel
    Friend WithEvents Panel9 As CustomControls.Panel
    Friend WithEvents dtfPrecioVenta As CustomControls.DatafieldLabel
    Friend WithEvents Panel10 As CustomControls.Panel
    Friend WithEvents dtfVendedor As CustomControls.DualDatafieldLabel
    Friend WithEvents Panel12 As CustomControls.Panel
    Friend WithEvents dtfPrecioVentaVeh As CustomControls.DatafieldLabel
    Friend WithEvents Panel13 As CustomControls.Panel
    Friend WithEvents dtfFechaVenta As CustomControls.DataDateLabel
    Friend WithEvents pnlSpace15 As CustomControls.Panel
    Friend WithEvents dtfFactura As CustomControls.DatafieldLabel
    Friend WithEvents dtfComprador As CustomControls.DualDatafieldLabel
    Friend WithEvents pvpseguros As CustomControls.PageViewPage
    Friend WithEvents pnlIzqSeguro As CustomControls.Panel
    Friend WithEvents pnlCabeceraSeguro As CustomControls.Panel
    Friend WithEvents gbxPagos As CustomControls.GroupBox
    Friend WithEvents Panel37 As CustomControls.Panel
    Friend WithEvents gbxOtrosDSeg As CustomControls.GroupBox
    Friend WithEvents pnlOtrosDSegSup As CustomControls.Panel
    Friend WithEvents chkSegInternacional As CustomControls.DataCheck
    Friend WithEvents dtfCartaVerde As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace19 As CustomControls.Panel
    Friend WithEvents Panel64 As CustomControls.Panel
    Friend WithEvents btnParteAmis As CustomControls.Button
    Friend WithEvents Panel65 As CustomControls.Panel
    Friend WithEvents btnHistorico As CustomControls.Button
    Friend WithEvents gbxSegAd3 As CustomControls.GroupBox
    Friend WithEvents pnlSupSA3inf As CustomControls.Panel
    Friend WithEvents Panel58 As CustomControls.Panel
    Friend WithEvents dtlVencimientoSA2 As CustomControls.DataDateLabel
    Friend WithEvents pnlSpace30 As CustomControls.Panel
    Friend WithEvents dtlFechaAltaSA2 As CustomControls.DataDateLabel
    Friend WithEvents pnlSupSA3mid As CustomControls.Panel
    Friend WithEvents dtfTelefAssistSA2 As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace29 As CustomControls.Panel
    Friend WithEvents dtfImporteSA2 As CustomControls.DatafieldLabel
    Friend WithEvents gbxSegAd2 As CustomControls.GroupBox
    Friend WithEvents pnlSupSA2inf As CustomControls.Panel
    Friend WithEvents Panel51 As CustomControls.Panel
    Friend WithEvents dtlVencimientoSA As CustomControls.DataDateLabel
    Friend WithEvents pnlSpace27 As CustomControls.Panel
    Friend WithEvents dtlFechaAltaSA As CustomControls.DataDateLabel
    Friend WithEvents pnlSupSA2mid As CustomControls.Panel
    Friend WithEvents dtfTelefAssistSA As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace26 As CustomControls.Panel
    Friend WithEvents dtfImporteSA As CustomControls.DatafieldLabel
    Friend WithEvents gbxSegAd1 As CustomControls.GroupBox
    Friend WithEvents pnlSupSA1inf As CustomControls.Panel
    Friend WithEvents Panel48 As CustomControls.Panel
    Friend WithEvents dtlVencimientoSA3 As CustomControls.DataDateLabel
    Friend WithEvents pnlSpace24 As CustomControls.Panel
    Friend WithEvents dtlFechaAltaSA3 As CustomControls.DataDateLabel
    Friend WithEvents pnlSupSA1mid As CustomControls.Panel
    Friend WithEvents dtfTelefAssistSA3 As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace23 As CustomControls.Panel
    Friend WithEvents dtfImporteSA3 As CustomControls.DatafieldLabel
    Friend WithEvents pnlOtrosDSegInf As CustomControls.Panel
    Friend WithEvents chkEnVehic As CustomControls.DataCheck
    Friend WithEvents pnlSpace20 As CustomControls.Panel
    Friend WithEvents pnlSpace21 As CustomControls.Panel
    Friend WithEvents chkTodoRiesgo As CustomControls.DataCheck
    Friend WithEvents chkTenemosRec As CustomControls.DataCheck
    Friend WithEvents pnlSupSA3top As CustomControls.Panel
    Friend WithEvents dtfCompañiaSA2 As CustomControls.DualDatafieldLabel
    Friend WithEvents pnlSpace28 As CustomControls.Panel
    Friend WithEvents dtfPolizaSA2 As CustomControls.DatafieldLabel
    Friend WithEvents pnlSupSA2top As CustomControls.Panel
    Friend WithEvents dtfCompañiaSA As CustomControls.DualDatafieldLabel
    Friend WithEvents pnlSpace25 As CustomControls.Panel
    Friend WithEvents dtfPolizaSA As CustomControls.DatafieldLabel
    Friend WithEvents pnlSupSA1top As CustomControls.Panel
    Friend WithEvents dtfCompañiaSA3 As CustomControls.DualDatafieldLabel
    Friend WithEvents pnlSpace22 As CustomControls.Panel
    Friend WithEvents dtfPolizaSA3 As CustomControls.DatafieldLabel
    Friend WithEvents gbxDatosSeguro As CustomControls.GroupBox
    Friend WithEvents pnlDatosSegInf As CustomControls.Panel
    Friend WithEvents Panel68 As CustomControls.Panel
    Friend WithEvents pnlTipoSegObs As CustomControls.Panel
    Friend WithEvents dtaObsSeguro As CustomControls.DataAreaLabel
    Friend WithEvents dtaTipoSeguro As CustomControls.DataAreaLabel
    Friend WithEvents pnlPrimaPendSeg As CustomControls.Panel
    Friend WithEvents Panel23 As CustomControls.Panel
    Friend WithEvents dtfPendienteSeguro As CustomControls.DatafieldLabel
    Friend WithEvents Panel22 As CustomControls.Panel
    Friend WithEvents dtfExtorno As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace35 As CustomControls.Panel
    Friend WithEvents dtfPrimaSeguro As CustomControls.DatafieldLabel
    Friend WithEvents pnlFechasSeg As CustomControls.Panel
    Friend WithEvents dtlBajaSeg As CustomControls.DataDateLabel
    Friend WithEvents Panel19 As CustomControls.Panel
    Friend WithEvents dtlVenciSeg As CustomControls.DataDateLabel
    Friend WithEvents pnlSpace36 As CustomControls.Panel
    Friend WithEvents dtlAltaSeg As CustomControls.DataDateLabel
    Friend WithEvents pnlAgenteFranq As CustomControls.Panel
    Friend WithEvents dtfAgenteSeg As CustomControls.DualDatafieldLabel
    Friend WithEvents pnlSpace16 As CustomControls.Panel
    Friend WithEvents dtfFranquiciaSeg As CustomControls.DatafieldLabel
    Friend WithEvents Panel6 As CustomControls.Panel
    Friend WithEvents dtfCompañiaSeg As CustomControls.DualDatafieldLabel
    Friend WithEvents pnlSpace17 As CustomControls.Panel
    Friend WithEvents dtfPolizaSeg As CustomControls.DatafieldLabel
    Friend WithEvents Panel36 As CustomControls.Panel
    Friend WithEvents pnlPagoSeg4 As CustomControls.Panel
    Friend WithEvents chkPagado4 As CustomControls.DataCheck
    Friend WithEvents pnlSpace40 As CustomControls.Panel
    Friend WithEvents dtfImp4 As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace34 As CustomControls.Panel
    Friend WithEvents dtlVen4 As CustomControls.DataDateLabel
    Friend WithEvents pnlPagoSeg3 As CustomControls.Panel
    Friend WithEvents chkPagado3 As CustomControls.DataCheck
    Friend WithEvents pnlSpace39 As CustomControls.Panel
    Friend WithEvents dtfImp3 As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace33 As CustomControls.Panel
    Friend WithEvents dtlVen3 As CustomControls.DataDateLabel
    Friend WithEvents pnlPagoSeg2 As CustomControls.Panel
    Friend WithEvents chkPagado2 As CustomControls.DataCheck
    Friend WithEvents pnlSpace38 As CustomControls.Panel
    Friend WithEvents dtfImp2 As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace32 As CustomControls.Panel
    Friend WithEvents dtlVen2 As CustomControls.DataDateLabel
    Friend WithEvents pnlPagoSeg1 As CustomControls.Panel
    Friend WithEvents chkPagado1 As CustomControls.DataCheck
    Friend WithEvents pnlSpace37 As CustomControls.Panel
    Friend WithEvents dtfImp1 As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace31 As CustomControls.Panel
    Friend WithEvents dtlVen1 As CustomControls.DataDateLabel
    Friend WithEvents rdgFormaPagoSeg As CustomControls.RadioGroup
    Friend WithEvents radFP4 As CustomControls.DataRadio
    Friend WithEvents radFP3 As CustomControls.DataRadio
    Friend WithEvents radFP2 As CustomControls.DataRadio
    Friend WithEvents radFP1 As CustomControls.DataRadio
    Friend WithEvents pnlSpace18 As CustomControls.Panel
    Friend WithEvents pnlOtrosDer As CustomControls.Panel
    Friend WithEvents pnlOtrosIzq As CustomControls.Panel
    Friend WithEvents pvpOtros As CustomControls.PageViewPage
    Friend WithEvents pnlCabeceraOtros As CustomControls.Panel
    Friend WithEvents pvpMantenimiento As CustomControls.PageViewPage
    Friend WithEvents pnlSpace44 As CustomControls.Panel
    Friend WithEvents pnlKmMaximoOtros As CustomControls.Panel
    Friend WithEvents pnlKmOtros As CustomControls.Panel
    Friend WithEvents dtdFechaKm As CustomControls.DataDate
    Friend WithEvents pnlSpace41 As CustomControls.Panel
    Friend WithEvents dtfKmOtros As CustomControls.DatafieldLabel
    Friend WithEvents dtdFechaKmRes As CustomControls.DataDate
    Friend WithEvents pnlSpace42 As CustomControls.Panel
    Friend WithEvents dtfKmResOtros As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace43 As CustomControls.Panel
    Friend WithEvents pclCodLlave As CustomControls.Panel
    Friend WithEvents dtfLlaveMag As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace46 As CustomControls.Panel
    Friend WithEvents dtfCodLlave As CustomControls.DatafieldLabel
    Friend WithEvents dtfCombustibleOtros As CustomControls.DatafieldLabel
    Friend WithEvents pnlPlazasPuertas As CustomControls.Panel
    Friend WithEvents dtfNPuertas As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace48 As CustomControls.Panel
    Friend WithEvents dtfNPlazas As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace47 As CustomControls.Panel
    Friend WithEvents dtfTelAsociado As CustomControls.DatafieldLabel
    Friend WithEvents pnlCodBateria As CustomControls.Panel
    Friend WithEvents dtfversionOtros As CustomControls.DatafieldLabel
    Friend WithEvents Panel11 As CustomControls.Panel
    Friend WithEvents dtfCodBateria As CustomControls.DatafieldLabel
    Friend WithEvents pnlMotorTap As CustomControls.Panel
    Friend WithEvents dtfTapiceria As CustomControls.DatafieldLabel
    Friend WithEvents Panel15 As CustomControls.Panel
    Friend WithEvents dtfNMotor As CustomControls.DatafieldLabel
    Friend WithEvents pnlModeloDiasMax As CustomControls.Panel
    Friend WithEvents DatafieldLabel1 As CustomControls.DatafieldLabel
    Friend WithEvents Panel17 As CustomControls.Panel
    Friend WithEvents dtfAnyoModelo As CustomControls.DatafieldLabel
    Friend WithEvents pnlLocalizador As CustomControls.Panel
    Friend WithEvents btnHistoricoOtros As CustomControls.Button
    Friend WithEvents Panel18 As CustomControls.Panel
    Friend WithEvents btnIncidencias As CustomControls.Button
    Friend WithEvents Panel8 As CustomControls.Panel
    Friend WithEvents dtcLocalizadorOtros As CustomControls.DataCheck
    Friend WithEvents pnlCuentaOtros As CustomControls.Panel
    Friend WithEvents dtfCuentaOtros As CustomControls.DualDatafieldLabel
    Friend WithEvents pnlDepoLitros As CustomControls.Panel
    Friend WithEvents lblOctavos As CustomControls.Label
    Friend WithEvents dtfOctavos As CustomControls.Datafield
    Friend WithEvents pnlSpace45 As CustomControls.Panel
    Friend WithEvents dtfDepositoLitros As CustomControls.DatafieldLabel
    Friend WithEvents dtfKmMaximos As CustomControls.DatafieldLabel
    Friend WithEvents pnlSituacionOtros As CustomControls.Panel
    Friend WithEvents DataCheck1 As CustomControls.DataCheck
    Friend WithEvents pnlSpace51 As CustomControls.Panel
    Friend WithEvents btnRecalcularSit As CustomControls.Button
    Friend WithEvents pnlSpace50 As CustomControls.Panel
    Friend WithEvents dtfSituacionOtros As CustomControls.DualDatafieldLabel
    Friend WithEvents pnlUbicacionOtros As CustomControls.Panel
    Friend WithEvents dtfUbicacionOtros As CustomControls.DatafieldLabel
    Friend WithEvents pnlOficinasOtros As CustomControls.Panel
    Friend WithEvents dtfOficinaAsig As CustomControls.DualDatafieldLabel
    Friend WithEvents pnlSpace49 As CustomControls.Panel
    Friend WithEvents dtfOficinaActual As CustomControls.DualDatafieldLabel
    Friend WithEvents EmpresaOficina1 As CustomControls.EmpresaOficina
    Friend WithEvents pnlClienteSit As CustomControls.Panel
    Friend WithEvents dtfConductorSit As CustomControls.Datafield
    Friend WithEvents pnlSpace52 As CustomControls.Panel
    Friend WithEvents dtfClienteSitu As CustomControls.DualDatafieldLabel
    Friend WithEvents pnlContratoOtros As CustomControls.Panel
    Friend WithEvents dtfConductorSit2 As CustomControls.Datafield
    Friend WithEvents pnlSpace54 As CustomControls.Panel
    Friend WithEvents dtdFRetornoOtros As CustomControls.DataDateLabel
    Friend WithEvents pnlSpace53 As CustomControls.Panel
    Friend WithEvents dtfContratoOtros As CustomControls.DatafieldLabel
    Friend WithEvents pnlitvOtros As CustomControls.Panel
    Friend WithEvents dtdProximaITV As CustomControls.DataDateLabel
    Friend WithEvents pnlSpace56 As CustomControls.Panel
    Friend WithEvents dtdUltimaITV As CustomControls.DataDateLabel
    Friend WithEvents pnlManteOtros As CustomControls.Panel
    Friend WithEvents dtdHastaMante As CustomControls.DataDateLabel
    Friend WithEvents pnlSpace55 As CustomControls.Panel
    Friend WithEvents dtdManteOtros As CustomControls.DataDateLabel
    Friend WithEvents pnlPuestaEnServ As CustomControls.Panel
    Friend WithEvents dtdServicioFinOtros As CustomControls.DataDateLabel
    Friend WithEvents pnlSpace57 As CustomControls.Panel
    Friend WithEvents dtdServicioOtros As CustomControls.DataDateLabel
    Friend WithEvents pnlGarantiaExt As CustomControls.Panel
    Friend WithEvents dtfKmsOtros As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace60 As CustomControls.Panel
    Friend WithEvents dtdGarantiaFinOtros As CustomControls.DataDateLabel
    Friend WithEvents pnlSpace59 As CustomControls.Panel
    Friend WithEvents dtdGarantiaOtros As CustomControls.DataDateLabel
    Friend WithEvents btnDocVeh As CustomControls.Button
    Friend WithEvents pnlSpace58 As CustomControls.Panel
    Friend WithEvents PageViewPage2 As CustomControls.PageViewPage
End Class
