<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Proveedores
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
        Dim Connection5 As ASADB.Connection = New ASADB.Connection()
        Dim Connection6 As ASADB.Connection = New ASADB.Connection()
        Dim Connection7 As ASADB.Connection = New ASADB.Connection()
        Dim Connection8 As ASADB.Connection = New ASADB.Connection()
        Dim Connection9 As ASADB.Connection = New ASADB.Connection()
        Dim Connection10 As ASADB.Connection = New ASADB.Connection()
        Dim Connection11 As ASADB.Connection = New ASADB.Connection()
        Dim Connection12 As ASADB.Connection = New ASADB.Connection()
        Dim Connection13 As ASADB.Connection = New ASADB.Connection()
        Dim Connection14 As ASADB.Connection = New ASADB.Connection()
        Dim Connection15 As ASADB.Connection = New ASADB.Connection()
        Dim Connection16 As ASADB.Connection = New ASADB.Connection()
        Dim Connection17 As ASADB.Connection = New ASADB.Connection()
        Dim Connection18 As ASADB.Connection = New ASADB.Connection()
        Dim Connection19 As ASADB.Connection = New ASADB.Connection()
        Dim Connection20 As ASADB.Connection = New ASADB.Connection()
        Dim Connection21 As ASADB.Connection = New ASADB.Connection()
        Me.pvpDatosGenerales = New CustomControls.PageViewPage()
        Me.pnlGenDer = New CustomControls.Panel()
        Me.pnlBottomGen = New CustomControls.Panel()
        Me.dtlUltmodi = New CustomControls.DataLabel()
        Me.dtlUsumodi = New CustomControls.DataLabel()
        Me.dtaObservaciones = New CustomControls.DataAreaLabel()
        Me.dtaNotas = New CustomControls.DataAreaLabel()
        Me.pnlGenIzq = New CustomControls.Panel()
        Me.pnlOtros = New CustomControls.Panel()
        Me.pnlFaltaFbaja = New CustomControls.Panel()
        Me.dtdFBaja = New CustomControls.DataDateLabel()
        Me.pnlSpace5 = New CustomControls.Panel()
        Me.dtdFAlta = New CustomControls.DataDateLabel()
        Me.pnlEmpOfi = New CustomControls.Panel()
        Me.dtfOficina = New CustomControls.DualDatafieldLabel()
        Me.pnlSpace10 = New CustomControls.Panel()
        Me.dtfEmpresa = New CustomControls.DualDatafieldLabel()
        Me.dtfContacto = New CustomControls.DatafieldLabel()
        Me.dtfWeb = New CustomControls.DatafieldLabel()
        Me.dtfEMail = New CustomControls.DatafieldLabel()
        Me.pnlTelefonos = New CustomControls.Panel()
        Me.dtfTelefonos = New CustomControls.DatafieldLabel()
        Me.pnlSpace3 = New CustomControls.Panel()
        Me.dtfMovil = New CustomControls.DatafieldLabel()
        Me.pnlSpace4 = New CustomControls.Panel()
        Me.dtfFax = New CustomControls.DatafieldLabel()
        Me.dirPrincipal = New CustomControls.DataDir()
        Me.pnlGenS = New CustomControls.Panel()
        Me.pnlGen = New CustomControls.Panel()
        Me.pnlGenF = New CustomControls.Panel()
        Me.pnlNifNombre = New CustomControls.Panel()
        Me.dtfNombre = New CustomControls.DatafieldLabel()
        Me.pnlSpace2 = New CustomControls.Panel()
        Me.dtfNif = New CustomControls.DatafieldLabel()
        Me.pnlCodigo = New CustomControls.Panel()
        Me.dtfNombreComercial = New CustomControls.DatafieldLabel()
        Me.pnlSpace1 = New CustomControls.Panel()
        Me.dtfCodigo = New CustomControls.DatafieldLabel()
        Me.pnlGenR = New CustomControls.Panel()
        Me.dtfTipoProvee = New CustomControls.DualDatafieldLabel()
        Me.pvpFacturacionContable = New CustomControls.PageViewPage()
        Me.pnlContables = New CustomControls.Panel()
        Me.gbxContable = New CustomControls.GroupBox()
        Me.rdgTipoCompra = New CustomControls.RadioGroup()
        Me.dtrInmovilizado = New CustomControls.DataRadio()
        Me.dtrGasto = New CustomControls.DataRadio()
        Me.dtrCompra = New CustomControls.DataRadio()
        Me.gbxIntracomunitario = New CustomControls.GroupBox()
        Me.dtfIntracoRepercutido = New CustomControls.DualDatafieldLabel()
        Me.dtfIntracoSoportado = New CustomControls.DualDatafieldLabel()
        Me.gbxLeasings = New CustomControls.GroupBox()
        Me.dtcLeasing = New CustomControls.DataCheck()
        Me.dtfCtaLp = New CustomControls.DualDatafieldLabel()
        Me.dtfCtaCP = New CustomControls.DualDatafieldLabel()
        Me.dtfCtaGastoAbono = New CustomControls.DualDatafieldLabel()
        Me.dtfCtaPago = New CustomControls.DualDatafieldLabel()
        Me.pnlRetencion = New CustomControls.Panel()
        Me.dtfCtaRetencion = New CustomControls.DualDatafieldLabel()
        Me.pnlSpace12 = New CustomControls.Panel()
        Me.dtfPorcenRetencion = New CustomControls.DatafieldLabel()
        Me.pnlCtaCompGasto = New CustomControls.Panel()
        Me.dtfCtaCompGasto = New CustomControls.DualDatafieldLabel()
        Me.pnlSpace13 = New CustomControls.Panel()
        Me.btnCompGastoAplicar = New CustomControls.Button()
        Me.dtfCtaContable = New CustomControls.DualDatafieldLabel()
        Me.pnlCtaContable = New CustomControls.Panel()
        Me.dtfSaldo = New CustomControls.DatafieldLabel()
        Me.dtcNoAparecer347349 = New CustomControls.DataCheck()
        Me.pnlSpace11 = New CustomControls.Panel()
        Me.dtfPrefijoCta = New CustomControls.DatafieldLabel()
        Me.pnlFacturacion = New CustomControls.Panel()
        Me.gbxFacturacion = New CustomControls.GroupBox()
        Me.pnlChecks = New CustomControls.Panel()
        Me.pnlChecks2 = New CustomControls.Panel()
        Me.dtcAutoFacMante = New CustomControls.DataCheck()
        Me.dtcAlbaranesCosteTransp = New CustomControls.DataCheck()
        Me.dtcExenOperInter = New CustomControls.DataCheck()
        Me.pnlChecksIzq = New CustomControls.Panel()
        Me.dtcGestAlba = New CustomControls.DataCheck()
        Me.dtcEsIntracomunitario = New CustomControls.DataCheck()
        Me.dtcGestIvaImportacion = New CustomControls.DataCheck()
        Me.dtcMargenNoAuto = New CustomControls.DataCheck()
        Me.Panel1 = New CustomControls.Panel()
        Me.DatafieldLabel1 = New CustomControls.DatafieldLabel()
        Me.Panel2 = New CustomControls.Panel()
        Me.DatafieldLabel2 = New CustomControls.DatafieldLabel()
        Me.Panel3 = New CustomControls.Panel()
        Me.DatafieldLabel3 = New CustomControls.DatafieldLabel()
        Me.PnlIdiomaDivisa = New CustomControls.Panel()
        Me.dftIdioma = New CustomControls.DualDatafieldLabel()
        Me.pnlSpace23 = New CustomControls.Panel()
        Me.DualDatafieldLabel2 = New CustomControls.DualDatafieldLabel()
        Me.dtfBanco = New CustomControls.DualDatafieldLabel()
        Me.dtfCC = New CustomControls.DatafieldLabel()
        Me.pnlIbanSwift = New CustomControls.Panel()
        Me.dtfIban = New CustomControls.DatafieldLabel()
        Me.pnlSpace20 = New CustomControls.Panel()
        Me.dtfSwift = New CustomControls.DatafieldLabel()
        Me.pnlVacaciones = New CustomControls.Panel()
        Me.dtfMesVacaciones2 = New CustomControls.DualDatafield()
        Me.pnlSpace19 = New CustomControls.Panel()
        Me.dtfMesVacaciones = New CustomControls.DualDatafieldLabel()
        Me.pnlDtos = New CustomControls.Panel()
        Me.dtfTipoIVA = New CustomControls.DatafieldLabel()
        Me.pnlSpace21 = New CustomControls.Panel()
        Me.dtfDtoPP = New CustomControls.DatafieldLabel()
        Me.pnlSpace22 = New CustomControls.Panel()
        Me.dtfDTO = New CustomControls.DatafieldLabel()
        Me.pnlPlazosPago = New CustomControls.Panel()
        Me.dtfDiaPago3 = New CustomControls.Datafield()
        Me.pnlSpace18 = New CustomControls.Panel()
        Me.dtfDiaPago2 = New CustomControls.Datafield()
        Me.pnlSpace17 = New CustomControls.Panel()
        Me.dtfDiaPago = New CustomControls.DatafieldLabel()
        Me.pnlSpace16 = New CustomControls.Panel()
        Me.dtfPlazoPago3 = New CustomControls.Datafield()
        Me.pnlSpace15 = New CustomControls.Panel()
        Me.dtfPlazoPago2 = New CustomControls.Datafield()
        Me.pnlSpace14 = New CustomControls.Panel()
        Me.dtfPlazoPago = New CustomControls.DatafieldLabel()
        Me.dftFormaPago = New CustomControls.DualDatafieldLabel()
        Me.pnlFacContaS = New CustomControls.Panel()
        Me.pvpDelegaciones = New CustomControls.PageViewPage()
        Me.dgvDelegacion = New Karve.frm.Proveedores.GridDelegacion()
        Me.pnlDelegaS = New CustomControls.Panel()
        Me.pvpContactos = New CustomControls.PageViewPage()
        Me.dgvContactos = New Karve.frm.Proveedores.GridContactos()
        Me.pnlContactosS = New CustomControls.Panel()
        Me.pvpAcumulados = New CustomControls.PageViewPage()
        Me.pnlAcumS = New CustomControls.Panel()
        Me.pvpVisitas = New CustomControls.PageViewPage()
        Me.pnlVisitasS = New CustomControls.Panel()
        Me.pvpDirecciones = New CustomControls.PageViewPage()
        Me.pnlDireccDer = New CustomControls.Panel()
        Me.gbxDireDevo = New CustomControls.GroupBox()
        Me.dtfEmailDevo = New CustomControls.DatafieldLabel()
        Me.dtfPersonaDevo = New CustomControls.DatafieldLabel()
        Me.pnlTelfDevo = New CustomControls.Panel()
        Me.dtfTelfDevo = New CustomControls.DatafieldLabel()
        Me.pnlSpace8 = New CustomControls.Panel()
        Me.dtfFaxDevo = New CustomControls.DatafieldLabel()
        Me.dtdDevo = New CustomControls.DataDir()
        Me.gbxDirReclama = New CustomControls.GroupBox()
        Me.dtfEmailReclama = New CustomControls.DatafieldLabel()
        Me.dtfPersonaReclama = New CustomControls.DatafieldLabel()
        Me.pnlTelfReclama = New CustomControls.Panel()
        Me.dtfTelfReclama = New CustomControls.DatafieldLabel()
        Me.pnlSpace7 = New CustomControls.Panel()
        Me.dtfFaxReclama = New CustomControls.DatafieldLabel()
        Me.dtdReclama = New CustomControls.DataDir()
        Me.pnlDireccIzq = New CustomControls.Panel()
        Me.gbxLugarEntrega = New CustomControls.GroupBox()
        Me.dtfLuentre6 = New CustomControls.Datafield()
        Me.dtfLuentre5 = New CustomControls.Datafield()
        Me.dtfLuentre4 = New CustomControls.Datafield()
        Me.dtfLuentre3 = New CustomControls.Datafield()
        Me.dtfLuentre2 = New CustomControls.Datafield()
        Me.dtfLuentre1 = New CustomControls.Datafield()
        Me.gbxComunicaPedidos = New CustomControls.GroupBox()
        Me.dtfCondicionVentaComunicaPedidos = New CustomControls.DualDatafieldLabel()
        Me.dtfFEntregaComunicaPedidos = New CustomControls.DualDatafieldLabel()
        Me.dtfEmailComunicaPedidos = New CustomControls.DatafieldLabel()
        Me.dtfViaComunicaPedidos = New CustomControls.DualDatafieldLabel()
        Me.gbxDirPago = New CustomControls.GroupBox()
        Me.dtfEmailPago = New CustomControls.DatafieldLabel()
        Me.dtfPersonaPago = New CustomControls.DatafieldLabel()
        Me.pnlTelfPago = New CustomControls.Panel()
        Me.dtfTelfPago = New CustomControls.DatafieldLabel()
        Me.pnlSpace6 = New CustomControls.Panel()
        Me.dtfFaxPago = New CustomControls.DatafieldLabel()
        Me.dtdPago = New CustomControls.DataDir()
        Me.pnlDirS = New CustomControls.Panel()
        Me.pvpEvaluacion = New CustomControls.PageViewPage()
        Me.pnlEvaS = New CustomControls.Panel()
        CType(Me.pnlBlock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pvwBase, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pvwBase.SuspendLayout()
        CType(Me.stbBase, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pvpDatosGenerales.SuspendLayout()
        CType(Me.pnlGenDer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlGenDer.SuspendLayout()
        CType(Me.pnlBottomGen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBottomGen.SuspendLayout()
        CType(Me.dtlUltmodi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtlUsumodi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlGenIzq, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlGenIzq.SuspendLayout()
        CType(Me.pnlOtros, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlFaltaFbaja, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFaltaFbaja.SuspendLayout()
        CType(Me.pnlSpace5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlEmpOfi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEmpOfi.SuspendLayout()
        CType(Me.pnlSpace10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlTelefonos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTelefonos.SuspendLayout()
        CType(Me.pnlSpace3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSpace4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlGenS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlGenS.SuspendLayout()
        CType(Me.pnlGen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlGen.SuspendLayout()
        CType(Me.pnlGenF, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlGenF.SuspendLayout()
        CType(Me.pnlNifNombre, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlNifNombre.SuspendLayout()
        CType(Me.pnlSpace2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlCodigo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCodigo.SuspendLayout()
        CType(Me.pnlSpace1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlGenR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlGenR.SuspendLayout()
        Me.pvpFacturacionContable.SuspendLayout()
        CType(Me.pnlContables, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlContables.SuspendLayout()
        CType(Me.gbxContable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxContable.SuspendLayout()
        CType(Me.rdgTipoCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rdgTipoCompra.SuspendLayout()
        CType(Me.dtrInmovilizado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtrGasto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtrCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbxIntracomunitario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxIntracomunitario.SuspendLayout()
        CType(Me.gbxLeasings, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxLeasings.SuspendLayout()
        CType(Me.dtcLeasing, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlRetencion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlRetencion.SuspendLayout()
        CType(Me.pnlSpace12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlCtaCompGasto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCtaCompGasto.SuspendLayout()
        CType(Me.pnlSpace13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnCompGastoAplicar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlCtaContable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCtaContable.SuspendLayout()
        CType(Me.dtcNoAparecer347349, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSpace11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlFacturacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFacturacion.SuspendLayout()
        CType(Me.gbxFacturacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxFacturacion.SuspendLayout()
        CType(Me.pnlChecks, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlChecks.SuspendLayout()
        CType(Me.pnlChecks2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlChecks2.SuspendLayout()
        CType(Me.dtcAutoFacMante, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtcAlbaranesCosteTransp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtcExenOperInter, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlChecksIzq, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlChecksIzq.SuspendLayout()
        CType(Me.dtcGestAlba, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtcEsIntracomunitario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtcGestIvaImportacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtcMargenNoAuto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Panel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.Panel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Panel3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PnlIdiomaDivisa, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlIdiomaDivisa.SuspendLayout()
        CType(Me.pnlSpace23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlIbanSwift, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlIbanSwift.SuspendLayout()
        CType(Me.pnlSpace20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlVacaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlVacaciones.SuspendLayout()
        CType(Me.pnlSpace19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlDtos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDtos.SuspendLayout()
        CType(Me.pnlSpace21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSpace22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlPlazosPago, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPlazosPago.SuspendLayout()
        CType(Me.pnlSpace18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSpace17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSpace16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSpace15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSpace14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlFacContaS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pvpDelegaciones.SuspendLayout()
        CType(Me.dgvDelegacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDelegacion.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlDelegaS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pvpContactos.SuspendLayout()
        CType(Me.dgvContactos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvContactos.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlContactosS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pvpAcumulados.SuspendLayout()
        CType(Me.pnlAcumS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pvpVisitas.SuspendLayout()
        CType(Me.pnlVisitasS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pvpDirecciones.SuspendLayout()
        CType(Me.pnlDireccDer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDireccDer.SuspendLayout()
        CType(Me.gbxDireDevo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxDireDevo.SuspendLayout()
        CType(Me.pnlTelfDevo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTelfDevo.SuspendLayout()
        CType(Me.pnlSpace8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbxDirReclama, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxDirReclama.SuspendLayout()
        CType(Me.pnlTelfReclama, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTelfReclama.SuspendLayout()
        CType(Me.pnlSpace7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlDireccIzq, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDireccIzq.SuspendLayout()
        CType(Me.gbxLugarEntrega, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxLugarEntrega.SuspendLayout()
        CType(Me.gbxComunicaPedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxComunicaPedidos.SuspendLayout()
        CType(Me.gbxDirPago, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxDirPago.SuspendLayout()
        CType(Me.pnlTelfPago, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTelfPago.SuspendLayout()
        CType(Me.pnlSpace6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlDirS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pvpEvaluacion.SuspendLayout()
        CType(Me.pnlEvaS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        'pnlBlock
        '
        Me.pnlBlock.Location = New System.Drawing.Point(0, 621)
        '
        'pvwBase
        '
        Me.pvwBase.BackColor = System.Drawing.SystemColors.Control
        Me.pvwBase.Controls.Add(Me.pvpDatosGenerales)
        Me.pvwBase.Controls.Add(Me.pvpFacturacionContable)
        Me.pvwBase.Controls.Add(Me.pvpDelegaciones)
        Me.pvwBase.Controls.Add(Me.pvpContactos)
        Me.pvwBase.Controls.Add(Me.pvpAcumulados)
        Me.pvwBase.Controls.Add(Me.pvpVisitas)
        Me.pvwBase.Controls.Add(Me.pvpDirecciones)
        Me.pvwBase.Controls.Add(Me.pvpEvaluacion)
        Me.pvwBase.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.pvwBase.PanelCabezera = Me.pnlGen
        Me.pvwBase.SelectedPage = Me.pvpDatosGenerales
        Me.pvwBase.Size = New System.Drawing.Size(1067, 528)
        Me.pvwBase.Text = ""
        '
        'rbgEdicion
        '
        Me.rbgEdicion.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.rbgEdicion.Bounds = New System.Drawing.Rectangle(0, 0, 246, 96)
        Me.rbgEdicion.ForeColor = System.Drawing.Color.Black
        '
        'stbBase
        '
        Me.stbBase.Location = New System.Drawing.Point(0, 528)
        Me.stbBase.Size = New System.Drawing.Size(1067, 25)
        '
        'pvpDatosGenerales
        '
        Me.pvpDatosGenerales.Controls.Add(Me.pnlGenDer)
        Me.pvpDatosGenerales.Controls.Add(Me.pnlGenIzq)
        Me.pvpDatosGenerales.Controls.Add(Me.pnlGenS)
        Me.pvpDatosGenerales.ItemSize = New System.Drawing.SizeF(106.0!, 23.0!)
        Me.pvpDatosGenerales.Location = New System.Drawing.Point(129, 5)
        Me.pvpDatosGenerales.Name = "pvpDatosGenerales"
        Me.pvpDatosGenerales.PanelCabezeraContainer = Me.pnlGenS
        Me.pvpDatosGenerales.Size = New System.Drawing.Size(933, 518)
        Me.pvpDatosGenerales.Text = "Datos Generales"
        '
        'pnlGenDer
        '
        Me.pnlGenDer.Auto_Size = False
        Me.pnlGenDer.BackColor = System.Drawing.SystemColors.Control
        Me.pnlGenDer.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlGenDer.ChangeDock = True
        Me.pnlGenDer.Control_Resize = False
        Me.pnlGenDer.Controls.Add(Me.pnlBottomGen)
        Me.pnlGenDer.Controls.Add(Me.dtaObservaciones)
        Me.pnlGenDer.Controls.Add(Me.dtaNotas)
        Me.pnlGenDer.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlGenDer.isSpace = False
        Me.pnlGenDer.Location = New System.Drawing.Point(467, 54)
        Me.pnlGenDer.MinimumSize = New System.Drawing.Size(467, 0)
        Me.pnlGenDer.Name = "pnlGenDer"
        Me.pnlGenDer.numRows = 0
        Me.pnlGenDer.Padding = New System.Windows.Forms.Padding(3)
        Me.pnlGenDer.Reorder = True
        '
        '
        '
        Me.pnlGenDer.RootElement.MinSize = New System.Drawing.Size(467, 0)
        Me.pnlGenDer.Size = New System.Drawing.Size(467, 464)
        Me.pnlGenDer.TabIndex = 1
        '
        'pnlBottomGen
        '
        Me.pnlBottomGen.Auto_Size = False
        Me.pnlBottomGen.BackColor = System.Drawing.SystemColors.Control
        Me.pnlBottomGen.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlBottomGen.ChangeDock = True
        Me.pnlBottomGen.Control_Resize = False
        Me.pnlBottomGen.Controls.Add(Me.dtlUltmodi)
        Me.pnlBottomGen.Controls.Add(Me.dtlUsumodi)
        Me.pnlBottomGen.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBottomGen.isSpace = False
        Me.pnlBottomGen.Location = New System.Drawing.Point(3, 435)
        Me.pnlBottomGen.Name = "pnlBottomGen"
        Me.pnlBottomGen.numRows = 1
        Me.pnlBottomGen.Reorder = True
        Me.pnlBottomGen.Size = New System.Drawing.Size(461, 26)
        Me.pnlBottomGen.TabIndex = 2
        '
        'dtlUltmodi
        '
        Me.dtlUltmodi.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtlUltmodi.AutoSize = False
        Me.dtlUltmodi.BorderVisible = True
        Me.dtlUltmodi.DataField = "ULTMODI"
        Me.dtlUltmodi.DataTable = "PR1"
        Me.dtlUltmodi.Descripcion = ""
        Me.dtlUltmodi.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtlUltmodi.Fromat = CustomControls.DataLabel.fotmatType.ultmodi
        Me.dtlUltmodi.Location = New System.Drawing.Point(329, 6)
        Me.dtlUltmodi.Name = "dtlUltmodi"
        Me.dtlUltmodi.Size = New System.Drawing.Size(132, 17)
        Me.dtlUltmodi.TabIndex = 1
        Me.dtlUltmodi.TextAlignment = System.Drawing.ContentAlignment.TopCenter
        '
        'dtlUsumodi
        '
        Me.dtlUsumodi.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtlUsumodi.AutoSize = False
        Me.dtlUsumodi.BorderVisible = True
        Me.dtlUsumodi.DataField = "USUARIO"
        Me.dtlUsumodi.DataTable = "PR1"
        Me.dtlUsumodi.Descripcion = ""
        Me.dtlUsumodi.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtlUsumodi.Fromat = CustomControls.DataLabel.fotmatType.plain
        Me.dtlUsumodi.Location = New System.Drawing.Point(285, 6)
        Me.dtlUsumodi.Name = "dtlUsumodi"
        Me.dtlUsumodi.Size = New System.Drawing.Size(38, 17)
        Me.dtlUsumodi.TabIndex = 0
        Me.dtlUsumodi.TextAlignment = System.Drawing.ContentAlignment.TopCenter
        '
        'dtaObservaciones
        '
        Me.dtaObservaciones.Allow_Empty = True
        Me.dtaObservaciones.Allow_Negative = True
        Me.dtaObservaciones.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtaObservaciones.BackColor = System.Drawing.SystemColors.Control
        Me.dtaObservaciones.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtaObservaciones.DataField = "OBSERVA"
        Me.dtaObservaciones.DataTable = "PR1"
        Me.dtaObservaciones.Descripcion = "Observaciones"
        Me.dtaObservaciones.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtaObservaciones.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtaObservaciones.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtaObservaciones.Length_Data = 32767
        Me.dtaObservaciones.Location = New System.Drawing.Point(3, 211)
        Me.dtaObservaciones.Max_Value = 0.0R
        Me.dtaObservaciones.MensajeIncorrectoCustom = Nothing
        Me.dtaObservaciones.Name = "dtaObservaciones"
        Me.dtaObservaciones.Null_on_Empty = True
        Me.dtaObservaciones.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtaObservaciones.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtaObservaciones.ReadOnly_Data = False
        Me.dtaObservaciones.Size = New System.Drawing.Size(461, 208)
        Me.dtaObservaciones.TabIndex = 1
        Me.dtaObservaciones.Text_Data = ""
        Me.dtaObservaciones.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtaObservaciones.TopPadding = 0
        Me.dtaObservaciones.Upper_Case = False
        Me.dtaObservaciones.Validate_on_lost_focus = True
        '
        'dtaNotas
        '
        Me.dtaNotas.Allow_Empty = True
        Me.dtaNotas.Allow_Negative = True
        Me.dtaNotas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtaNotas.BackColor = System.Drawing.SystemColors.Control
        Me.dtaNotas.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtaNotas.DataField = "NOTAS"
        Me.dtaNotas.DataTable = "PR1"
        Me.dtaNotas.Descripcion = "Notas"
        Me.dtaNotas.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtaNotas.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtaNotas.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtaNotas.Length_Data = 32767
        Me.dtaNotas.Location = New System.Drawing.Point(3, 3)
        Me.dtaNotas.Max_Value = 0.0R
        Me.dtaNotas.MensajeIncorrectoCustom = Nothing
        Me.dtaNotas.Name = "dtaNotas"
        Me.dtaNotas.Null_on_Empty = True
        Me.dtaNotas.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtaNotas.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtaNotas.ReadOnly_Data = False
        Me.dtaNotas.Size = New System.Drawing.Size(461, 208)
        Me.dtaNotas.TabIndex = 0
        Me.dtaNotas.Text_Data = ""
        Me.dtaNotas.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtaNotas.TopPadding = 0
        Me.dtaNotas.Upper_Case = False
        Me.dtaNotas.Validate_on_lost_focus = True
        '
        'pnlGenIzq
        '
        Me.pnlGenIzq.Auto_Size = False
        Me.pnlGenIzq.BackColor = System.Drawing.SystemColors.Control
        Me.pnlGenIzq.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlGenIzq.ChangeDock = True
        Me.pnlGenIzq.Control_Resize = False
        Me.pnlGenIzq.Controls.Add(Me.pnlOtros)
        Me.pnlGenIzq.Controls.Add(Me.pnlFaltaFbaja)
        Me.pnlGenIzq.Controls.Add(Me.pnlEmpOfi)
        Me.pnlGenIzq.Controls.Add(Me.dtfContacto)
        Me.pnlGenIzq.Controls.Add(Me.dtfWeb)
        Me.pnlGenIzq.Controls.Add(Me.dtfEMail)
        Me.pnlGenIzq.Controls.Add(Me.pnlTelefonos)
        Me.pnlGenIzq.Controls.Add(Me.dirPrincipal)
        Me.pnlGenIzq.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlGenIzq.isSpace = False
        Me.pnlGenIzq.Location = New System.Drawing.Point(0, 54)
        Me.pnlGenIzq.MinimumSize = New System.Drawing.Size(467, 0)
        Me.pnlGenIzq.Name = "pnlGenIzq"
        Me.pnlGenIzq.numRows = 0
        Me.pnlGenIzq.Padding = New System.Windows.Forms.Padding(3)
        Me.pnlGenIzq.Reorder = True
        '
        '
        '
        Me.pnlGenIzq.RootElement.MinSize = New System.Drawing.Size(467, 0)
        Me.pnlGenIzq.Size = New System.Drawing.Size(467, 464)
        Me.pnlGenIzq.TabIndex = 0
        '
        'pnlOtros
        '
        Me.pnlOtros.Auto_Size = False
        Me.pnlOtros.BackColor = System.Drawing.SystemColors.Control
        Me.pnlOtros.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlOtros.ChangeDock = True
        Me.pnlOtros.Control_Resize = False
        Me.pnlOtros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlOtros.isSpace = False
        Me.pnlOtros.Location = New System.Drawing.Point(3, 315)
        Me.pnlOtros.Name = "pnlOtros"
        Me.pnlOtros.numRows = 4
        Me.pnlOtros.Reorder = True
        Me.pnlOtros.Size = New System.Drawing.Size(461, 104)
        Me.pnlOtros.TabIndex = 7
        '
        'pnlFaltaFbaja
        '
        Me.pnlFaltaFbaja.Auto_Size = False
        Me.pnlFaltaFbaja.BackColor = System.Drawing.SystemColors.Control
        Me.pnlFaltaFbaja.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlFaltaFbaja.ChangeDock = True
        Me.pnlFaltaFbaja.Control_Resize = False
        Me.pnlFaltaFbaja.Controls.Add(Me.dtdFBaja)
        Me.pnlFaltaFbaja.Controls.Add(Me.pnlSpace5)
        Me.pnlFaltaFbaja.Controls.Add(Me.dtdFAlta)
        Me.pnlFaltaFbaja.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFaltaFbaja.isSpace = False
        Me.pnlFaltaFbaja.Location = New System.Drawing.Point(3, 289)
        Me.pnlFaltaFbaja.Name = "pnlFaltaFbaja"
        Me.pnlFaltaFbaja.numRows = 1
        Me.pnlFaltaFbaja.Reorder = True
        Me.pnlFaltaFbaja.Size = New System.Drawing.Size(461, 26)
        Me.pnlFaltaFbaja.TabIndex = 6
        '
        'dtdFBaja
        '
        Me.dtdFBaja.Allow_Empty = True
        Me.dtdFBaja.DataField = "FBAJA"
        Me.dtdFBaja.DataTable = "PR1"
        Me.dtdFBaja.Default_Value = Nothing
        Me.dtdFBaja.Descripcion = "Fecha de Baja"
        Me.dtdFBaja.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtdFBaja.Label_Space = 91
        Me.dtdFBaja.Location = New System.Drawing.Point(187, 0)
        Me.dtdFBaja.Max_Value = Nothing
        Me.dtdFBaja.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdFBaja.MensajeIncorrectoCustom = Nothing
        Me.dtdFBaja.Min_Value = Nothing
        Me.dtdFBaja.MinDate = New Date(CType(0, Long))
        Me.dtdFBaja.MinimumSize = New System.Drawing.Size(181, 26)
        Me.dtdFBaja.Name = "dtdFBaja"
        Me.dtdFBaja.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdFBaja.ReadOnly_Data = False
        Me.dtdFBaja.Size = New System.Drawing.Size(181, 26)
        Me.dtdFBaja.TabIndex = 2
        Me.dtdFBaja.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdFBaja.Validate_on_lost_focus = True
        Me.dtdFBaja.Value_Data = Nothing
        '
        'pnlSpace5
        '
        Me.pnlSpace5.Auto_Size = False
        Me.pnlSpace5.BackColor = System.Drawing.SystemColors.Control
        Me.pnlSpace5.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace5.ChangeDock = True
        Me.pnlSpace5.Control_Resize = False
        Me.pnlSpace5.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace5.isSpace = False
        Me.pnlSpace5.Location = New System.Drawing.Point(181, 0)
        Me.pnlSpace5.Name = "pnlSpace5"
        Me.pnlSpace5.numRows = 0
        Me.pnlSpace5.Reorder = False
        Me.pnlSpace5.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace5.TabIndex = 1
        '
        'dtdFAlta
        '
        Me.dtdFAlta.Allow_Empty = True
        Me.dtdFAlta.DataField = "FALTA"
        Me.dtdFAlta.DataTable = "PR1"
        Me.dtdFAlta.Default_Value = Nothing
        Me.dtdFAlta.Descripcion = "Fecha de Alta"
        Me.dtdFAlta.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtdFAlta.Label_Space = 91
        Me.dtdFAlta.Location = New System.Drawing.Point(0, 0)
        Me.dtdFAlta.Max_Value = Nothing
        Me.dtdFAlta.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdFAlta.MensajeIncorrectoCustom = Nothing
        Me.dtdFAlta.Min_Value = Nothing
        Me.dtdFAlta.MinDate = New Date(CType(0, Long))
        Me.dtdFAlta.MinimumSize = New System.Drawing.Size(181, 26)
        Me.dtdFAlta.Name = "dtdFAlta"
        Me.dtdFAlta.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdFAlta.ReadOnly_Data = False
        Me.dtdFAlta.Size = New System.Drawing.Size(181, 26)
        Me.dtdFAlta.TabIndex = 0
        Me.dtdFAlta.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdFAlta.Validate_on_lost_focus = True
        Me.dtdFAlta.Value_Data = Nothing
        '
        'pnlEmpOfi
        '
        Me.pnlEmpOfi.Auto_Size = False
        Me.pnlEmpOfi.BackColor = System.Drawing.SystemColors.Control
        Me.pnlEmpOfi.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlEmpOfi.ChangeDock = True
        Me.pnlEmpOfi.Control_Resize = False
        Me.pnlEmpOfi.Controls.Add(Me.dtfOficina)
        Me.pnlEmpOfi.Controls.Add(Me.pnlSpace10)
        Me.pnlEmpOfi.Controls.Add(Me.dtfEmpresa)
        Me.pnlEmpOfi.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEmpOfi.isSpace = False
        Me.pnlEmpOfi.Location = New System.Drawing.Point(3, 263)
        Me.pnlEmpOfi.Name = "pnlEmpOfi"
        Me.pnlEmpOfi.numRows = 1
        Me.pnlEmpOfi.Reorder = True
        Me.pnlEmpOfi.Size = New System.Drawing.Size(461, 26)
        Me.pnlEmpOfi.TabIndex = 5
        '
        'dtfOficina
        '
        Me.dtfOficina.Allow_Empty = True
        Me.dtfOficina.Allow_Negative = True
        Me.dtfOficina.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfOficina.BackColor = System.Drawing.SystemColors.Control
        Me.dtfOficina.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfOficina.DataField = "OFICINA"
        Me.dtfOficina.DataTable = "PR1"
        Me.dtfOficina.DB = Connection1
        Me.dtfOficina.Desc_Datafield = "NOMBRE"
        Me.dtfOficina.Desc_DBPK = "CODIGO"
        Me.dtfOficina.Desc_DBTable = "OFICINAS"
        Me.dtfOficina.Desc_Where = Nothing
        Me.dtfOficina.Desc_WhereObligatoria = Nothing
        Me.dtfOficina.Descripcion = "Oficina"
        Me.dtfOficina.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfOficina.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfOficina.ExtraSQL = "SUBLICEN"
        Me.dtfOficina.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfOficina.Formulario = Nothing
        Me.dtfOficina.Label_Space = 55
        Me.dtfOficina.Length_Data = 32767
        Me.dtfOficina.Location = New System.Drawing.Point(232, 0)
        Me.dtfOficina.Lupa = Nothing
        Me.dtfOficina.Max_Value = 0.0R
        Me.dtfOficina.MensajeIncorrectoCustom = Nothing
        Me.dtfOficina.Name = "dtfOficina"
        Me.dtfOficina.Null_on_Empty = True
        Me.dtfOficina.OpenForm = Nothing
        Me.dtfOficina.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfOficina.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfOficina.Query_on_Text_Changed = True
        Me.dtfOficina.ReadOnly_Data = False
        Me.dtfOficina.ShowButton = True
        Me.dtfOficina.Size = New System.Drawing.Size(229, 26)
        Me.dtfOficina.TabIndex = 2
        Me.dtfOficina.Text_Data = ""
        Me.dtfOficina.Text_Data_Desc = ""
        Me.dtfOficina.Text_Width = 25
        Me.dtfOficina.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfOficina.TopPadding = 0
        Me.dtfOficina.Upper_Case = False
        Me.dtfOficina.Validate_on_lost_focus = True
        '
        'pnlSpace10
        '
        Me.pnlSpace10.Auto_Size = False
        Me.pnlSpace10.BackColor = System.Drawing.SystemColors.Control
        Me.pnlSpace10.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace10.ChangeDock = True
        Me.pnlSpace10.Control_Resize = False
        Me.pnlSpace10.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace10.isSpace = False
        Me.pnlSpace10.Location = New System.Drawing.Point(226, 0)
        Me.pnlSpace10.Name = "pnlSpace10"
        Me.pnlSpace10.numRows = 0
        Me.pnlSpace10.Reorder = False
        Me.pnlSpace10.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace10.TabIndex = 1
        '
        'dtfEmpresa
        '
        Me.dtfEmpresa.Allow_Empty = True
        Me.dtfEmpresa.Allow_Negative = True
        Me.dtfEmpresa.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfEmpresa.BackColor = System.Drawing.SystemColors.Control
        Me.dtfEmpresa.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfEmpresa.DataField = "SUBLICEN"
        Me.dtfEmpresa.DataTable = "PR1"
        Me.dtfEmpresa.DB = Connection2
        Me.dtfEmpresa.Desc_Datafield = "NOMBRE"
        Me.dtfEmpresa.Desc_DBPK = "CODIGO"
        Me.dtfEmpresa.Desc_DBTable = "SUBLICEN"
        Me.dtfEmpresa.Desc_Where = Nothing
        Me.dtfEmpresa.Desc_WhereObligatoria = Nothing
        Me.dtfEmpresa.Descripcion = "Empresa"
        Me.dtfEmpresa.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfEmpresa.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfEmpresa.ExtraSQL = ""
        Me.dtfEmpresa.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfEmpresa.Formulario = Nothing
        Me.dtfEmpresa.Label_Space = 75
        Me.dtfEmpresa.Length_Data = 32767
        Me.dtfEmpresa.Location = New System.Drawing.Point(0, 0)
        Me.dtfEmpresa.Lupa = Nothing
        Me.dtfEmpresa.Max_Value = 0.0R
        Me.dtfEmpresa.MensajeIncorrectoCustom = Nothing
        Me.dtfEmpresa.Name = "dtfEmpresa"
        Me.dtfEmpresa.Null_on_Empty = True
        Me.dtfEmpresa.OpenForm = Nothing
        Me.dtfEmpresa.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfEmpresa.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfEmpresa.Query_on_Text_Changed = True
        Me.dtfEmpresa.ReadOnly_Data = True
        Me.dtfEmpresa.ShowButton = False
        Me.dtfEmpresa.Size = New System.Drawing.Size(226, 26)
        Me.dtfEmpresa.TabIndex = 0
        Me.dtfEmpresa.TabStop = False
        Me.dtfEmpresa.Text_Data = ""
        Me.dtfEmpresa.Text_Data_Desc = ""
        Me.dtfEmpresa.Text_Width = 25
        Me.dtfEmpresa.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfEmpresa.TopPadding = 0
        Me.dtfEmpresa.Upper_Case = False
        Me.dtfEmpresa.Validate_on_lost_focus = True
        '
        'dtfContacto
        '
        Me.dtfContacto.Allow_Empty = True
        Me.dtfContacto.Allow_Negative = True
        Me.dtfContacto.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfContacto.BackColor = System.Drawing.SystemColors.Control
        Me.dtfContacto.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfContacto.DataField = "PERSONA"
        Me.dtfContacto.DataTable = "PR1"
        Me.dtfContacto.Descripcion = "Contacto"
        Me.dtfContacto.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfContacto.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfContacto.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfContacto.Image = Nothing
        Me.dtfContacto.Label_Space = 75
        Me.dtfContacto.Length_Data = 32767
        Me.dtfContacto.Location = New System.Drawing.Point(3, 237)
        Me.dtfContacto.Max_Value = 0.0R
        Me.dtfContacto.MensajeIncorrectoCustom = Nothing
        Me.dtfContacto.Name = "dtfContacto"
        Me.dtfContacto.Null_on_Empty = True
        Me.dtfContacto.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfContacto.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfContacto.ReadOnly_Data = False
        Me.dtfContacto.Show_Button = False
        Me.dtfContacto.Size = New System.Drawing.Size(461, 26)
        Me.dtfContacto.TabIndex = 4
        Me.dtfContacto.Text_Data = ""
        Me.dtfContacto.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfContacto.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfContacto.TopPadding = 0
        Me.dtfContacto.Upper_Case = False
        Me.dtfContacto.Validate_on_lost_focus = True
        '
        'dtfWeb
        '
        Me.dtfWeb.Allow_Empty = True
        Me.dtfWeb.Allow_Negative = True
        Me.dtfWeb.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfWeb.BackColor = System.Drawing.SystemColors.Control
        Me.dtfWeb.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfWeb.DataField = "INTERNET"
        Me.dtfWeb.DataTable = "PR1"
        Me.dtfWeb.Descripcion = "Web"
        Me.dtfWeb.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfWeb.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfWeb.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfWeb.Image = Nothing
        Me.dtfWeb.Label_Space = 75
        Me.dtfWeb.Length_Data = 32767
        Me.dtfWeb.Location = New System.Drawing.Point(3, 211)
        Me.dtfWeb.Max_Value = 0.0R
        Me.dtfWeb.MensajeIncorrectoCustom = Nothing
        Me.dtfWeb.Name = "dtfWeb"
        Me.dtfWeb.Null_on_Empty = True
        Me.dtfWeb.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfWeb.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfWeb.ReadOnly_Data = False
        Me.dtfWeb.Show_Button = False
        Me.dtfWeb.Size = New System.Drawing.Size(461, 26)
        Me.dtfWeb.TabIndex = 3
        Me.dtfWeb.Text_Data = ""
        Me.dtfWeb.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfWeb.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfWeb.TopPadding = 0
        Me.dtfWeb.Upper_Case = False
        Me.dtfWeb.Validate_on_lost_focus = True
        '
        'dtfEMail
        '
        Me.dtfEMail.Allow_Empty = True
        Me.dtfEMail.Allow_Negative = True
        Me.dtfEMail.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfEMail.BackColor = System.Drawing.SystemColors.Control
        Me.dtfEMail.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfEMail.DataField = "EMAIL"
        Me.dtfEMail.DataTable = "PR1"
        Me.dtfEMail.Descripcion = "Email"
        Me.dtfEMail.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfEMail.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfEMail.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfEMail.Image = Nothing
        Me.dtfEMail.Label_Space = 75
        Me.dtfEMail.Length_Data = 32767
        Me.dtfEMail.Location = New System.Drawing.Point(3, 185)
        Me.dtfEMail.Max_Value = 0.0R
        Me.dtfEMail.MensajeIncorrectoCustom = Nothing
        Me.dtfEMail.Name = "dtfEMail"
        Me.dtfEMail.Null_on_Empty = True
        Me.dtfEMail.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfEMail.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfEMail.ReadOnly_Data = False
        Me.dtfEMail.Show_Button = True
        Me.dtfEMail.Size = New System.Drawing.Size(461, 26)
        Me.dtfEMail.TabIndex = 2
        Me.dtfEMail.Text_Data = ""
        Me.dtfEMail.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfEMail.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfEMail.TopPadding = 0
        Me.dtfEMail.Upper_Case = False
        Me.dtfEMail.Validate_on_lost_focus = True
        '
        'pnlTelefonos
        '
        Me.pnlTelefonos.Auto_Size = False
        Me.pnlTelefonos.BackColor = System.Drawing.SystemColors.Control
        Me.pnlTelefonos.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlTelefonos.ChangeDock = True
        Me.pnlTelefonos.Control_Resize = False
        Me.pnlTelefonos.Controls.Add(Me.dtfTelefonos)
        Me.pnlTelefonos.Controls.Add(Me.pnlSpace3)
        Me.pnlTelefonos.Controls.Add(Me.dtfMovil)
        Me.pnlTelefonos.Controls.Add(Me.pnlSpace4)
        Me.pnlTelefonos.Controls.Add(Me.dtfFax)
        Me.pnlTelefonos.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTelefonos.isSpace = False
        Me.pnlTelefonos.Location = New System.Drawing.Point(3, 159)
        Me.pnlTelefonos.Name = "pnlTelefonos"
        Me.pnlTelefonos.numRows = 1
        Me.pnlTelefonos.Reorder = True
        Me.pnlTelefonos.Size = New System.Drawing.Size(461, 26)
        Me.pnlTelefonos.TabIndex = 1
        '
        'dtfTelefonos
        '
        Me.dtfTelefonos.Allow_Empty = True
        Me.dtfTelefonos.Allow_Negative = True
        Me.dtfTelefonos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfTelefonos.BackColor = System.Drawing.SystemColors.Control
        Me.dtfTelefonos.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfTelefonos.DataField = "TELEFONO"
        Me.dtfTelefonos.DataTable = "PR1"
        Me.dtfTelefonos.Descripcion = "Telefonos"
        Me.dtfTelefonos.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfTelefonos.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfTelefonos.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfTelefonos.Image = Nothing
        Me.dtfTelefonos.Label_Space = 75
        Me.dtfTelefonos.Length_Data = 32767
        Me.dtfTelefonos.Location = New System.Drawing.Point(0, 0)
        Me.dtfTelefonos.Max_Value = 0.0R
        Me.dtfTelefonos.MensajeIncorrectoCustom = Nothing
        Me.dtfTelefonos.Name = "dtfTelefonos"
        Me.dtfTelefonos.Null_on_Empty = True
        Me.dtfTelefonos.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfTelefonos.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfTelefonos.ReadOnly_Data = False
        Me.dtfTelefonos.Show_Button = False
        Me.dtfTelefonos.Size = New System.Drawing.Size(169, 26)
        Me.dtfTelefonos.TabIndex = 0
        Me.dtfTelefonos.Text_Data = ""
        Me.dtfTelefonos.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfTelefonos.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfTelefonos.TopPadding = 0
        Me.dtfTelefonos.Upper_Case = False
        Me.dtfTelefonos.Validate_on_lost_focus = True
        '
        'pnlSpace3
        '
        Me.pnlSpace3.Auto_Size = False
        Me.pnlSpace3.BackColor = System.Drawing.SystemColors.Control
        Me.pnlSpace3.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace3.ChangeDock = True
        Me.pnlSpace3.Control_Resize = False
        Me.pnlSpace3.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSpace3.isSpace = True
        Me.pnlSpace3.Location = New System.Drawing.Point(169, 0)
        Me.pnlSpace3.Name = "pnlSpace3"
        Me.pnlSpace3.numRows = 0
        Me.pnlSpace3.Reorder = False
        Me.pnlSpace3.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace3.TabIndex = 1
        '
        'dtfMovil
        '
        Me.dtfMovil.Allow_Empty = True
        Me.dtfMovil.Allow_Negative = True
        Me.dtfMovil.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfMovil.BackColor = System.Drawing.SystemColors.Control
        Me.dtfMovil.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfMovil.DataField = "MOVIL"
        Me.dtfMovil.DataTable = "PR1"
        Me.dtfMovil.Descripcion = "Movil"
        Me.dtfMovil.Dock = System.Windows.Forms.DockStyle.Right
        Me.dtfMovil.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfMovil.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfMovil.Image = Nothing
        Me.dtfMovil.Label_Space = 40
        Me.dtfMovil.Length_Data = 32767
        Me.dtfMovil.Location = New System.Drawing.Point(175, 0)
        Me.dtfMovil.Max_Value = 0.0R
        Me.dtfMovil.MensajeIncorrectoCustom = Nothing
        Me.dtfMovil.Name = "dtfMovil"
        Me.dtfMovil.Null_on_Empty = True
        Me.dtfMovil.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfMovil.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfMovil.ReadOnly_Data = False
        Me.dtfMovil.Show_Button = False
        Me.dtfMovil.Size = New System.Drawing.Size(140, 26)
        Me.dtfMovil.TabIndex = 2
        Me.dtfMovil.Text_Data = ""
        Me.dtfMovil.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfMovil.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfMovil.TopPadding = 0
        Me.dtfMovil.Upper_Case = False
        Me.dtfMovil.Validate_on_lost_focus = True
        '
        'pnlSpace4
        '
        Me.pnlSpace4.Auto_Size = False
        Me.pnlSpace4.BackColor = System.Drawing.SystemColors.Control
        Me.pnlSpace4.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace4.ChangeDock = True
        Me.pnlSpace4.Control_Resize = False
        Me.pnlSpace4.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSpace4.isSpace = True
        Me.pnlSpace4.Location = New System.Drawing.Point(315, 0)
        Me.pnlSpace4.Name = "pnlSpace4"
        Me.pnlSpace4.numRows = 0
        Me.pnlSpace4.Reorder = False
        Me.pnlSpace4.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace4.TabIndex = 3
        '
        'dtfFax
        '
        Me.dtfFax.Allow_Empty = True
        Me.dtfFax.Allow_Negative = True
        Me.dtfFax.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfFax.BackColor = System.Drawing.SystemColors.Control
        Me.dtfFax.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfFax.DataField = "FAX"
        Me.dtfFax.DataTable = "PR1"
        Me.dtfFax.Descripcion = "Fax"
        Me.dtfFax.Dock = System.Windows.Forms.DockStyle.Right
        Me.dtfFax.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfFax.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfFax.Image = Nothing
        Me.dtfFax.Label_Space = 40
        Me.dtfFax.Length_Data = 32767
        Me.dtfFax.Location = New System.Drawing.Point(321, 0)
        Me.dtfFax.Max_Value = 0.0R
        Me.dtfFax.MensajeIncorrectoCustom = Nothing
        Me.dtfFax.Name = "dtfFax"
        Me.dtfFax.Null_on_Empty = True
        Me.dtfFax.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfFax.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfFax.ReadOnly_Data = False
        Me.dtfFax.Show_Button = False
        Me.dtfFax.Size = New System.Drawing.Size(140, 26)
        Me.dtfFax.TabIndex = 4
        Me.dtfFax.Text_Data = ""
        Me.dtfFax.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfFax.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfFax.TopPadding = 0
        Me.dtfFax.Upper_Case = False
        Me.dtfFax.Validate_on_lost_focus = True
        '
        'dirPrincipal
        '
        Me.dirPrincipal.AutoSize = True
        Me.dirPrincipal.Datafield_CP = "CP"
        Me.dirPrincipal.Datafield_Direccion = "DIRECCION"
        Me.dirPrincipal.Datafield_Direccion2L = "DIREC2"
        Me.dirPrincipal.Datafield_GPS = "COORDGPS"
        Me.dirPrincipal.Datafield_Pais = "NACIOPER"
        Me.dirPrincipal.Datafield_Poblacion = "POBLACION"
        Me.dirPrincipal.Datafield_Provincia = "PROV"
        Me.dirPrincipal.Datatable_CP = "PR1"
        Me.dirPrincipal.Datatable_Direccion = "PR1"
        Me.dirPrincipal.Datatable_Direccion2L = "PR1"
        Me.dirPrincipal.Datatable_GPS = "PR1"
        Me.dirPrincipal.Datatable_Pais = "PR1"
        Me.dirPrincipal.Datatable_Poblacion = "PR1"
        Me.dirPrincipal.Datatable_Provincia = "PR1"
        Me.dirPrincipal.Descripcion = Nothing
        Me.dirPrincipal.Dock = System.Windows.Forms.DockStyle.Top
        Me.dirPrincipal.Label_Space = 75
        Me.dirPrincipal.Location = New System.Drawing.Point(3, 3)
        Me.dirPrincipal.Name = "dirPrincipal"
        Me.dirPrincipal.ReadOnly_Data = False
        Me.dirPrincipal.requeryCP = False
        Me.dirPrincipal.Show_Dir2L = True
        Me.dirPrincipal.Show_GPS = True
        Me.dirPrincipal.Size = New System.Drawing.Size(461, 156)
        Me.dirPrincipal.TabIndex = 0
        Me.dirPrincipal.Text_Data_CP = ""
        Me.dirPrincipal.Text_Data_Direccion = ""
        Me.dirPrincipal.Text_Data_Direccion2L = ""
        Me.dirPrincipal.Text_Data_GPS = ""
        Me.dirPrincipal.Text_Data_Pais = ""
        Me.dirPrincipal.Text_Data_Poblacion = ""
        Me.dirPrincipal.Text_Data_Provincia = ""
        '
        'pnlGenS
        '
        Me.pnlGenS.Auto_Size = False
        Me.pnlGenS.BackColor = System.Drawing.SystemColors.Control
        Me.pnlGenS.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlGenS.ChangeDock = False
        Me.pnlGenS.Control_Resize = False
        Me.pnlGenS.Controls.Add(Me.pnlGen)
        Me.pnlGenS.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlGenS.isSpace = False
        Me.pnlGenS.Location = New System.Drawing.Point(0, 0)
        Me.pnlGenS.Name = "pnlGenS"
        Me.pnlGenS.numRows = 0
        Me.pnlGenS.Padding = New System.Windows.Forms.Padding(0, 0, 0, 2)
        Me.pnlGenS.Reorder = True
        Me.pnlGenS.Size = New System.Drawing.Size(933, 54)
        Me.pnlGenS.TabIndex = 2
        '
        'pnlGen
        '
        Me.pnlGen.Auto_Size = False
        Me.pnlGen.BackColor = System.Drawing.SystemColors.Control
        Me.pnlGen.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlGen.ChangeDock = False
        Me.pnlGen.Control_Resize = False
        Me.pnlGen.Controls.Add(Me.pnlGenF)
        Me.pnlGen.Controls.Add(Me.pnlGenR)
        Me.pnlGen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlGen.isSpace = False
        Me.pnlGen.Location = New System.Drawing.Point(0, 0)
        Me.pnlGen.Name = "pnlGen"
        Me.pnlGen.numRows = 0
        Me.pnlGen.Reorder = True
        Me.pnlGen.Size = New System.Drawing.Size(933, 52)
        Me.pnlGen.TabIndex = 0
        '
        'pnlGenF
        '
        Me.pnlGenF.Auto_Size = False
        Me.pnlGenF.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlGenF.ChangeDock = True
        Me.pnlGenF.Control_Resize = False
        Me.pnlGenF.Controls.Add(Me.pnlNifNombre)
        Me.pnlGenF.Controls.Add(Me.pnlCodigo)
        Me.pnlGenF.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlGenF.isSpace = False
        Me.pnlGenF.Location = New System.Drawing.Point(0, 0)
        Me.pnlGenF.Name = "pnlGenF"
        Me.pnlGenF.numRows = 0
        Me.pnlGenF.Reorder = True
        Me.pnlGenF.Size = New System.Drawing.Size(467, 52)
        Me.pnlGenF.TabIndex = 0
        '
        'pnlNifNombre
        '
        Me.pnlNifNombre.Auto_Size = False
        Me.pnlNifNombre.BackColor = System.Drawing.SystemColors.Control
        Me.pnlNifNombre.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlNifNombre.ChangeDock = True
        Me.pnlNifNombre.Control_Resize = False
        Me.pnlNifNombre.Controls.Add(Me.dtfNombre)
        Me.pnlNifNombre.Controls.Add(Me.pnlSpace2)
        Me.pnlNifNombre.Controls.Add(Me.dtfNif)
        Me.pnlNifNombre.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlNifNombre.isSpace = False
        Me.pnlNifNombre.Location = New System.Drawing.Point(0, 26)
        Me.pnlNifNombre.Name = "pnlNifNombre"
        Me.pnlNifNombre.numRows = 1
        Me.pnlNifNombre.Reorder = True
        Me.pnlNifNombre.Size = New System.Drawing.Size(467, 26)
        Me.pnlNifNombre.TabIndex = 1
        Me.pnlNifNombre.ThemeName = "Windows8"
        '
        'dtfNombre
        '
        Me.dtfNombre.Allow_Empty = False
        Me.dtfNombre.Allow_Negative = True
        Me.dtfNombre.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfNombre.BackColor = System.Drawing.SystemColors.Control
        Me.dtfNombre.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfNombre.DataField = "NOMBRE"
        Me.dtfNombre.DataTable = "PR1"
        Me.dtfNombre.Descripcion = "Nombre"
        Me.dtfNombre.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfNombre.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfNombre.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfNombre.Image = Nothing
        Me.dtfNombre.Label_Space = 75
        Me.dtfNombre.Length_Data = 32767
        Me.dtfNombre.Location = New System.Drawing.Point(0, 0)
        Me.dtfNombre.Max_Value = 0.0R
        Me.dtfNombre.MensajeIncorrectoCustom = Nothing
        Me.dtfNombre.Name = "dtfNombre"
        Me.dtfNombre.Null_on_Empty = True
        Me.dtfNombre.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfNombre.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfNombre.ReadOnly_Data = False
        Me.dtfNombre.Show_Button = False
        Me.dtfNombre.Size = New System.Drawing.Size(321, 26)
        Me.dtfNombre.TabIndex = 0
        Me.dtfNombre.Text_Data = ""
        Me.dtfNombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfNombre.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfNombre.TopPadding = 0
        Me.dtfNombre.Upper_Case = False
        Me.dtfNombre.Validate_on_lost_focus = True
        '
        'pnlSpace2
        '
        Me.pnlSpace2.Auto_Size = False
        Me.pnlSpace2.BackColor = System.Drawing.SystemColors.Control
        Me.pnlSpace2.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace2.ChangeDock = True
        Me.pnlSpace2.Control_Resize = False
        Me.pnlSpace2.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSpace2.isSpace = True
        Me.pnlSpace2.Location = New System.Drawing.Point(321, 0)
        Me.pnlSpace2.Name = "pnlSpace2"
        Me.pnlSpace2.numRows = 0
        Me.pnlSpace2.Reorder = False
        Me.pnlSpace2.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace2.TabIndex = 1
        '
        'dtfNif
        '
        Me.dtfNif.Allow_Empty = True
        Me.dtfNif.Allow_Negative = True
        Me.dtfNif.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfNif.BackColor = System.Drawing.SystemColors.Control
        Me.dtfNif.Data_Allowed = CustomControls.Datafield.List_Data.NIF
        Me.dtfNif.DataField = "NIF"
        Me.dtfNif.DataTable = "PR1"
        Me.dtfNif.Descripcion = "NIF"
        Me.dtfNif.Dock = System.Windows.Forms.DockStyle.Right
        Me.dtfNif.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfNif.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfNif.Image = Nothing
        Me.dtfNif.Label_Space = 40
        Me.dtfNif.Length_Data = 32767
        Me.dtfNif.Location = New System.Drawing.Point(327, 0)
        Me.dtfNif.Max_Value = 0.0R
        Me.dtfNif.MensajeIncorrectoCustom = Nothing
        Me.dtfNif.Name = "dtfNif"
        Me.dtfNif.Null_on_Empty = True
        Me.dtfNif.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfNif.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfNif.ReadOnly_Data = False
        Me.dtfNif.Show_Button = False
        Me.dtfNif.Size = New System.Drawing.Size(140, 26)
        Me.dtfNif.TabIndex = 2
        Me.dtfNif.Text_Data = ""
        Me.dtfNif.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfNif.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfNif.TopPadding = 0
        Me.dtfNif.Upper_Case = False
        Me.dtfNif.Validate_on_lost_focus = True
        '
        'pnlCodigo
        '
        Me.pnlCodigo.Auto_Size = False
        Me.pnlCodigo.BackColor = System.Drawing.SystemColors.Control
        Me.pnlCodigo.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlCodigo.ChangeDock = True
        Me.pnlCodigo.Control_Resize = False
        Me.pnlCodigo.Controls.Add(Me.dtfNombreComercial)
        Me.pnlCodigo.Controls.Add(Me.pnlSpace1)
        Me.pnlCodigo.Controls.Add(Me.dtfCodigo)
        Me.pnlCodigo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCodigo.isSpace = False
        Me.pnlCodigo.Location = New System.Drawing.Point(0, 0)
        Me.pnlCodigo.Name = "pnlCodigo"
        Me.pnlCodigo.numRows = 1
        Me.pnlCodigo.Reorder = True
        Me.pnlCodigo.Size = New System.Drawing.Size(467, 26)
        Me.pnlCodigo.TabIndex = 0
        Me.pnlCodigo.ThemeName = "Windows8"
        '
        'dtfNombreComercial
        '
        Me.dtfNombreComercial.Allow_Empty = True
        Me.dtfNombreComercial.Allow_Negative = True
        Me.dtfNombreComercial.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfNombreComercial.BackColor = System.Drawing.SystemColors.Control
        Me.dtfNombreComercial.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfNombreComercial.DataField = "COMERCIAL"
        Me.dtfNombreComercial.DataTable = "PR2"
        Me.dtfNombreComercial.Descripcion = "Nom. Comercial"
        Me.dtfNombreComercial.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfNombreComercial.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfNombreComercial.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfNombreComercial.Image = Nothing
        Me.dtfNombreComercial.Label_Space = 100
        Me.dtfNombreComercial.Length_Data = 32767
        Me.dtfNombreComercial.Location = New System.Drawing.Point(166, 0)
        Me.dtfNombreComercial.Max_Value = 0.0R
        Me.dtfNombreComercial.MensajeIncorrectoCustom = Nothing
        Me.dtfNombreComercial.Name = "dtfNombreComercial"
        Me.dtfNombreComercial.Null_on_Empty = True
        Me.dtfNombreComercial.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfNombreComercial.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfNombreComercial.ReadOnly_Data = False
        Me.dtfNombreComercial.Show_Button = False
        Me.dtfNombreComercial.Size = New System.Drawing.Size(301, 26)
        Me.dtfNombreComercial.TabIndex = 2
        Me.dtfNombreComercial.Text_Data = ""
        Me.dtfNombreComercial.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfNombreComercial.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfNombreComercial.TopPadding = 0
        Me.dtfNombreComercial.Upper_Case = False
        Me.dtfNombreComercial.Validate_on_lost_focus = True
        '
        'pnlSpace1
        '
        Me.pnlSpace1.Auto_Size = False
        Me.pnlSpace1.BackColor = System.Drawing.SystemColors.Control
        Me.pnlSpace1.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace1.ChangeDock = True
        Me.pnlSpace1.Control_Resize = False
        Me.pnlSpace1.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace1.isSpace = True
        Me.pnlSpace1.Location = New System.Drawing.Point(160, 0)
        Me.pnlSpace1.Name = "pnlSpace1"
        Me.pnlSpace1.numRows = 0
        Me.pnlSpace1.Reorder = False
        Me.pnlSpace1.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace1.TabIndex = 1
        '
        'dtfCodigo
        '
        Me.dtfCodigo.Allow_Empty = False
        Me.dtfCodigo.Allow_Negative = True
        Me.dtfCodigo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfCodigo.BackColor = System.Drawing.SystemColors.Control
        Me.dtfCodigo.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfCodigo.DataField = "NUM_PROVEE"
        Me.dtfCodigo.DataTable = "PR1"
        Me.dtfCodigo.Descripcion = "Número"
        Me.dtfCodigo.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfCodigo.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfCodigo.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfCodigo.Image = Nothing
        Me.dtfCodigo.Label_Space = 75
        Me.dtfCodigo.Length_Data = 32767
        Me.dtfCodigo.Location = New System.Drawing.Point(0, 0)
        Me.dtfCodigo.Max_Value = 0.0R
        Me.dtfCodigo.MensajeIncorrectoCustom = Nothing
        Me.dtfCodigo.Name = "dtfCodigo"
        Me.dtfCodigo.Null_on_Empty = True
        Me.dtfCodigo.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfCodigo.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfCodigo.ReadOnly_Data = True
        Me.dtfCodigo.Show_Button = False
        Me.dtfCodigo.Size = New System.Drawing.Size(160, 26)
        Me.dtfCodigo.TabIndex = 0
        Me.dtfCodigo.TabStop = False
        Me.dtfCodigo.Text_Data = ""
        Me.dtfCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfCodigo.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfCodigo.TopPadding = 0
        Me.dtfCodigo.Upper_Case = False
        Me.dtfCodigo.Validate_on_lost_focus = True
        '
        'pnlGenR
        '
        Me.pnlGenR.Auto_Size = False
        Me.pnlGenR.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlGenR.ChangeDock = True
        Me.pnlGenR.Control_Resize = False
        Me.pnlGenR.Controls.Add(Me.dtfTipoProvee)
        Me.pnlGenR.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlGenR.isSpace = False
        Me.pnlGenR.Location = New System.Drawing.Point(467, 0)
        Me.pnlGenR.Name = "pnlGenR"
        Me.pnlGenR.numRows = 0
        Me.pnlGenR.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.pnlGenR.Reorder = True
        Me.pnlGenR.Size = New System.Drawing.Size(466, 52)
        Me.pnlGenR.TabIndex = 1
        '
        'dtfTipoProvee
        '
        Me.dtfTipoProvee.Allow_Empty = True
        Me.dtfTipoProvee.Allow_Negative = True
        Me.dtfTipoProvee.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfTipoProvee.BackColor = System.Drawing.SystemColors.Control
        Me.dtfTipoProvee.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfTipoProvee.DataField = "TIPO"
        Me.dtfTipoProvee.DataTable = "PR1"
        Me.dtfTipoProvee.DB = Connection3
        Me.dtfTipoProvee.Desc_Datafield = "NOMBRE"
        Me.dtfTipoProvee.Desc_DBPK = "NUM_TIPROVE"
        Me.dtfTipoProvee.Desc_DBTable = "TIPOPROVE"
        Me.dtfTipoProvee.Desc_Where = Nothing
        Me.dtfTipoProvee.Desc_WhereObligatoria = Nothing
        Me.dtfTipoProvee.Descripcion = "Tipo Provee."
        Me.dtfTipoProvee.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfTipoProvee.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfTipoProvee.ExtraSQL = ""
        Me.dtfTipoProvee.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfTipoProvee.Formulario = Nothing
        Me.dtfTipoProvee.Label_Space = 75
        Me.dtfTipoProvee.Length_Data = 32767
        Me.dtfTipoProvee.Location = New System.Drawing.Point(3, 0)
        Me.dtfTipoProvee.Lupa = Nothing
        Me.dtfTipoProvee.Max_Value = 0.0R
        Me.dtfTipoProvee.MensajeIncorrectoCustom = Nothing
        Me.dtfTipoProvee.Name = "dtfTipoProvee"
        Me.dtfTipoProvee.Null_on_Empty = True
        Me.dtfTipoProvee.OpenForm = Nothing
        Me.dtfTipoProvee.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfTipoProvee.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfTipoProvee.Query_on_Text_Changed = True
        Me.dtfTipoProvee.ReadOnly_Data = False
        Me.dtfTipoProvee.ShowButton = True
        Me.dtfTipoProvee.Size = New System.Drawing.Size(463, 26)
        Me.dtfTipoProvee.TabIndex = 0
        Me.dtfTipoProvee.Text_Data = ""
        Me.dtfTipoProvee.Text_Data_Desc = ""
        Me.dtfTipoProvee.Text_Width = 25
        Me.dtfTipoProvee.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfTipoProvee.TopPadding = 0
        Me.dtfTipoProvee.Upper_Case = False
        Me.dtfTipoProvee.Validate_on_lost_focus = True
        '
        'pvpFacturacionContable
        '
        Me.pvpFacturacionContable.Controls.Add(Me.pnlContables)
        Me.pvpFacturacionContable.Controls.Add(Me.pnlFacturacion)
        Me.pvpFacturacionContable.Controls.Add(Me.pnlFacContaS)
        Me.pvpFacturacionContable.ItemSize = New System.Drawing.SizeF(106.0!, 36.0!)
        Me.pvpFacturacionContable.Location = New System.Drawing.Point(129, 5)
        Me.pvpFacturacionContable.Name = "pvpFacturacionContable"
        Me.pvpFacturacionContable.PanelCabezeraContainer = Me.pnlFacContaS
        Me.pvpFacturacionContable.Size = New System.Drawing.Size(933, 518)
        Me.pvpFacturacionContable.Text = "Facturación" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Contables"
        '
        'pnlContables
        '
        Me.pnlContables.Auto_Size = False
        Me.pnlContables.BackColor = System.Drawing.SystemColors.Control
        Me.pnlContables.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlContables.ChangeDock = True
        Me.pnlContables.Control_Resize = False
        Me.pnlContables.Controls.Add(Me.gbxContable)
        Me.pnlContables.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlContables.isSpace = False
        Me.pnlContables.Location = New System.Drawing.Point(467, 67)
        Me.pnlContables.MinimumSize = New System.Drawing.Size(467, 0)
        Me.pnlContables.Name = "pnlContables"
        Me.pnlContables.numRows = 0
        Me.pnlContables.Padding = New System.Windows.Forms.Padding(3)
        Me.pnlContables.Reorder = True
        '
        '
        '
        Me.pnlContables.RootElement.MinSize = New System.Drawing.Size(467, 0)
        Me.pnlContables.Size = New System.Drawing.Size(467, 451)
        Me.pnlContables.TabIndex = 2
        '
        'gbxContable
        '
        Me.gbxContable.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.gbxContable.Controls.Add(Me.rdgTipoCompra)
        Me.gbxContable.Controls.Add(Me.gbxIntracomunitario)
        Me.gbxContable.Controls.Add(Me.gbxLeasings)
        Me.gbxContable.Controls.Add(Me.dtfCtaGastoAbono)
        Me.gbxContable.Controls.Add(Me.dtfCtaPago)
        Me.gbxContable.Controls.Add(Me.pnlRetencion)
        Me.gbxContable.Controls.Add(Me.pnlCtaCompGasto)
        Me.gbxContable.Controls.Add(Me.dtfCtaContable)
        Me.gbxContable.Controls.Add(Me.pnlCtaContable)
        Me.gbxContable.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbxContable.HeaderText = "Contables"
        Me.gbxContable.Location = New System.Drawing.Point(3, 3)
        Me.gbxContable.Name = "gbxContable"
        Me.gbxContable.numRows = 0
        Me.gbxContable.Padding = New System.Windows.Forms.Padding(6, 18, 6, 6)
        Me.gbxContable.Reorder = True
        Me.gbxContable.Size = New System.Drawing.Size(461, 445)
        Me.gbxContable.TabIndex = 0
        Me.gbxContable.Text = "Contables"
        Me.gbxContable.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.gbxContable.ThemeName = "Windows8"
        Me.gbxContable.Title = "Contables"
        '
        'rdgTipoCompra
        '
        Me.rdgTipoCompra.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.rdgTipoCompra.Controls.Add(Me.dtrInmovilizado)
        Me.rdgTipoCompra.Controls.Add(Me.dtrGasto)
        Me.rdgTipoCompra.Controls.Add(Me.dtrCompra)
        Me.rdgTipoCompra.DataField = "TIPOCOMP_P1"
        Me.rdgTipoCompra.DataTable = "PR1"
        Me.rdgTipoCompra.Descripcion = "Tipo de Compra"
        Me.rdgTipoCompra.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.rdgTipoCompra.HeaderText = "Tipo de Compra"
        Me.rdgTipoCompra.Index = "0"
        Me.rdgTipoCompra.Location = New System.Drawing.Point(6, 348)
        Me.rdgTipoCompra.Name = "rdgTipoCompra"
        Me.rdgTipoCompra.numRows = 0
        Me.rdgTipoCompra.Padding = New System.Windows.Forms.Padding(6, 18, 6, 6)
        Me.rdgTipoCompra.Reorder = True
        Me.rdgTipoCompra.Size = New System.Drawing.Size(122, 93)
        Me.rdgTipoCompra.TabIndex = 8
        Me.rdgTipoCompra.Text = "Tipo de Compra"
        Me.rdgTipoCompra.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.rdgTipoCompra.ThemeName = "Windows8"
        Me.rdgTipoCompra.Title = "Tipo de Compra"
        '
        'dtrInmovilizado
        '
        Me.dtrInmovilizado.BackColor = System.Drawing.SystemColors.Control
        Me.dtrInmovilizado.Checked = False
        Me.dtrInmovilizado.Descripcion = "Inmovilizado"
        Me.dtrInmovilizado.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtrInmovilizado.Index = "2"
        Me.dtrInmovilizado.Location = New System.Drawing.Point(9, 69)
        Me.dtrInmovilizado.Name = "dtrInmovilizado"
        Me.dtrInmovilizado.Size = New System.Drawing.Size(96, 18)
        Me.dtrInmovilizado.TabIndex = 2
        Me.dtrInmovilizado.Text = "Inmovilizado"
        Me.dtrInmovilizado.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtrInmovilizado.ThemeName = "Windows8"
        '
        'dtrGasto
        '
        Me.dtrGasto.BackColor = System.Drawing.SystemColors.Control
        Me.dtrGasto.Checked = False
        Me.dtrGasto.Descripcion = "Gasto"
        Me.dtrGasto.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtrGasto.Index = "1"
        Me.dtrGasto.Location = New System.Drawing.Point(9, 45)
        Me.dtrGasto.Name = "dtrGasto"
        Me.dtrGasto.Size = New System.Drawing.Size(56, 18)
        Me.dtrGasto.TabIndex = 1
        Me.dtrGasto.Text = "Gasto"
        Me.dtrGasto.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtrGasto.ThemeName = "Windows8"
        '
        'dtrCompra
        '
        Me.dtrCompra.BackColor = System.Drawing.SystemColors.Control
        Me.dtrCompra.Checked = True
        Me.dtrCompra.CheckState = System.Windows.Forms.CheckState.Checked
        Me.dtrCompra.Descripcion = "Compra"
        Me.dtrCompra.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtrCompra.Index = "0"
        Me.dtrCompra.Location = New System.Drawing.Point(9, 21)
        Me.dtrCompra.Name = "dtrCompra"
        Me.dtrCompra.Size = New System.Drawing.Size(68, 18)
        Me.dtrCompra.TabIndex = 0
        Me.dtrCompra.TabStop = True
        Me.dtrCompra.Text = "Compra"
        Me.dtrCompra.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtrCompra.ThemeName = "Windows8"
        Me.dtrCompra.ToggleState = Telerik.WinControls.Enumerations.ToggleState.[On]
        '
        'gbxIntracomunitario
        '
        Me.gbxIntracomunitario.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.gbxIntracomunitario.Controls.Add(Me.dtfIntracoRepercutido)
        Me.gbxIntracomunitario.Controls.Add(Me.dtfIntracoSoportado)
        Me.gbxIntracomunitario.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbxIntracomunitario.HeaderText = "Intracomunitario"
        Me.gbxIntracomunitario.Location = New System.Drawing.Point(6, 271)
        Me.gbxIntracomunitario.Name = "gbxIntracomunitario"
        Me.gbxIntracomunitario.numRows = 2
        Me.gbxIntracomunitario.Padding = New System.Windows.Forms.Padding(6, 18, 6, 6)
        Me.gbxIntracomunitario.Reorder = True
        Me.gbxIntracomunitario.Size = New System.Drawing.Size(449, 71)
        Me.gbxIntracomunitario.TabIndex = 7
        Me.gbxIntracomunitario.Text = "Intracomunitario"
        Me.gbxIntracomunitario.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.gbxIntracomunitario.ThemeName = "Windows8"
        Me.gbxIntracomunitario.Title = "Intracomunitario"
        '
        'dtfIntracoRepercutido
        '
        Me.dtfIntracoRepercutido.Allow_Empty = True
        Me.dtfIntracoRepercutido.Allow_Negative = True
        Me.dtfIntracoRepercutido.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfIntracoRepercutido.BackColor = System.Drawing.SystemColors.Control
        Me.dtfIntracoRepercutido.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfIntracoRepercutido.DataField = "CTAINTRACOPREP"
        Me.dtfIntracoRepercutido.DataTable = "PR1"
        Me.dtfIntracoRepercutido.DB = Connection4
        Me.dtfIntracoRepercutido.Desc_Datafield = "DESCRIP"
        Me.dtfIntracoRepercutido.Desc_DBPK = "CODIGO"
        Me.dtfIntracoRepercutido.Desc_DBTable = "CU1"
        Me.dtfIntracoRepercutido.Desc_Where = Nothing
        Me.dtfIntracoRepercutido.Desc_WhereObligatoria = Nothing
        Me.dtfIntracoRepercutido.Descripcion = "Cta. Repercutido"
        Me.dtfIntracoRepercutido.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfIntracoRepercutido.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfIntracoRepercutido.ExtraSQL = "SUBLICEN"
        Me.dtfIntracoRepercutido.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfIntracoRepercutido.Formulario = Nothing
        Me.dtfIntracoRepercutido.Label_Space = 109
        Me.dtfIntracoRepercutido.Length_Data = 32767
        Me.dtfIntracoRepercutido.Location = New System.Drawing.Point(6, 44)
        Me.dtfIntracoRepercutido.Lupa = Nothing
        Me.dtfIntracoRepercutido.Max_Value = 0.0R
        Me.dtfIntracoRepercutido.MensajeIncorrectoCustom = Nothing
        Me.dtfIntracoRepercutido.Name = "dtfIntracoRepercutido"
        Me.dtfIntracoRepercutido.Null_on_Empty = True
        Me.dtfIntracoRepercutido.OpenForm = Nothing
        Me.dtfIntracoRepercutido.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfIntracoRepercutido.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfIntracoRepercutido.Query_on_Text_Changed = True
        Me.dtfIntracoRepercutido.ReadOnly_Data = False
        Me.dtfIntracoRepercutido.ShowButton = True
        Me.dtfIntracoRepercutido.Size = New System.Drawing.Size(437, 26)
        Me.dtfIntracoRepercutido.TabIndex = 1
        Me.dtfIntracoRepercutido.Text_Data = ""
        Me.dtfIntracoRepercutido.Text_Data_Desc = ""
        Me.dtfIntracoRepercutido.Text_Width = 100
        Me.dtfIntracoRepercutido.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfIntracoRepercutido.TopPadding = 0
        Me.dtfIntracoRepercutido.Upper_Case = False
        Me.dtfIntracoRepercutido.Validate_on_lost_focus = True
        '
        'dtfIntracoSoportado
        '
        Me.dtfIntracoSoportado.Allow_Empty = True
        Me.dtfIntracoSoportado.Allow_Negative = True
        Me.dtfIntracoSoportado.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfIntracoSoportado.BackColor = System.Drawing.SystemColors.Control
        Me.dtfIntracoSoportado.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfIntracoSoportado.DataField = "CTAINTRACOP"
        Me.dtfIntracoSoportado.DataTable = "PR1"
        Me.dtfIntracoSoportado.DB = Connection5
        Me.dtfIntracoSoportado.Desc_Datafield = "DESCRIP"
        Me.dtfIntracoSoportado.Desc_DBPK = "CODIGO"
        Me.dtfIntracoSoportado.Desc_DBTable = "CU1"
        Me.dtfIntracoSoportado.Desc_Where = Nothing
        Me.dtfIntracoSoportado.Desc_WhereObligatoria = Nothing
        Me.dtfIntracoSoportado.Descripcion = "Cta. Soportado"
        Me.dtfIntracoSoportado.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfIntracoSoportado.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfIntracoSoportado.ExtraSQL = "SUBLICEN"
        Me.dtfIntracoSoportado.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfIntracoSoportado.Formulario = Nothing
        Me.dtfIntracoSoportado.Label_Space = 109
        Me.dtfIntracoSoportado.Length_Data = 32767
        Me.dtfIntracoSoportado.Location = New System.Drawing.Point(6, 18)
        Me.dtfIntracoSoportado.Lupa = Nothing
        Me.dtfIntracoSoportado.Max_Value = 0.0R
        Me.dtfIntracoSoportado.MensajeIncorrectoCustom = Nothing
        Me.dtfIntracoSoportado.Name = "dtfIntracoSoportado"
        Me.dtfIntracoSoportado.Null_on_Empty = True
        Me.dtfIntracoSoportado.OpenForm = Nothing
        Me.dtfIntracoSoportado.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfIntracoSoportado.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfIntracoSoportado.Query_on_Text_Changed = True
        Me.dtfIntracoSoportado.ReadOnly_Data = False
        Me.dtfIntracoSoportado.ShowButton = True
        Me.dtfIntracoSoportado.Size = New System.Drawing.Size(437, 26)
        Me.dtfIntracoSoportado.TabIndex = 0
        Me.dtfIntracoSoportado.Text_Data = ""
        Me.dtfIntracoSoportado.Text_Data_Desc = ""
        Me.dtfIntracoSoportado.Text_Width = 100
        Me.dtfIntracoSoportado.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfIntracoSoportado.TopPadding = 0
        Me.dtfIntracoSoportado.Upper_Case = False
        Me.dtfIntracoSoportado.Validate_on_lost_focus = True
        '
        'gbxLeasings
        '
        Me.gbxLeasings.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.gbxLeasings.Controls.Add(Me.dtcLeasing)
        Me.gbxLeasings.Controls.Add(Me.dtfCtaLp)
        Me.gbxLeasings.Controls.Add(Me.dtfCtaCP)
        Me.gbxLeasings.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbxLeasings.HeaderText = "Leasings"
        Me.gbxLeasings.Location = New System.Drawing.Point(6, 174)
        Me.gbxLeasings.Name = "gbxLeasings"
        Me.gbxLeasings.numRows = 3
        Me.gbxLeasings.Padding = New System.Windows.Forms.Padding(6, 18, 6, 6)
        Me.gbxLeasings.Reorder = True
        Me.gbxLeasings.Size = New System.Drawing.Size(449, 97)
        Me.gbxLeasings.TabIndex = 6
        Me.gbxLeasings.Text = "Leasings"
        Me.gbxLeasings.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.gbxLeasings.ThemeName = "Windows8"
        Me.gbxLeasings.Title = "Leasings"
        '
        'dtcLeasing
        '
        Me.dtcLeasing.DataField = "PROVEELEAS"
        Me.dtcLeasing.DataTable = "PR1"
        Me.dtcLeasing.Descripcion = "Es Proveedor de Leasing"
        Me.dtcLeasing.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtcLeasing.Location = New System.Drawing.Point(6, 70)
        Me.dtcLeasing.Name = "dtcLeasing"
        Me.dtcLeasing.Size = New System.Drawing.Size(163, 18)
        Me.dtcLeasing.TabIndex = 2
        Me.dtcLeasing.Text = "Es Proveedor de Leasing"
        Me.dtcLeasing.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtcLeasing.ThemeName = "Windows8"
        Me.dtcLeasing.Value = False
        '
        'dtfCtaLp
        '
        Me.dtfCtaLp.Allow_Empty = True
        Me.dtfCtaLp.Allow_Negative = True
        Me.dtfCtaLp.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfCtaLp.BackColor = System.Drawing.SystemColors.Control
        Me.dtfCtaLp.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfCtaLp.DataField = "CTALP"
        Me.dtfCtaLp.DataTable = "PR1"
        Me.dtfCtaLp.DB = Connection6
        Me.dtfCtaLp.Desc_Datafield = "DESCRIP"
        Me.dtfCtaLp.Desc_DBPK = "CODIGO"
        Me.dtfCtaLp.Desc_DBTable = "CU1"
        Me.dtfCtaLp.Desc_Where = Nothing
        Me.dtfCtaLp.Desc_WhereObligatoria = Nothing
        Me.dtfCtaLp.Descripcion = "Cuenta L/P"
        Me.dtfCtaLp.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfCtaLp.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfCtaLp.ExtraSQL = "SUBLICEN"
        Me.dtfCtaLp.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfCtaLp.Formulario = Nothing
        Me.dtfCtaLp.Label_Space = 109
        Me.dtfCtaLp.Length_Data = 32767
        Me.dtfCtaLp.Location = New System.Drawing.Point(6, 44)
        Me.dtfCtaLp.Lupa = Nothing
        Me.dtfCtaLp.Max_Value = 0.0R
        Me.dtfCtaLp.MensajeIncorrectoCustom = Nothing
        Me.dtfCtaLp.Name = "dtfCtaLp"
        Me.dtfCtaLp.Null_on_Empty = True
        Me.dtfCtaLp.OpenForm = Nothing
        Me.dtfCtaLp.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfCtaLp.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfCtaLp.Query_on_Text_Changed = True
        Me.dtfCtaLp.ReadOnly_Data = False
        Me.dtfCtaLp.ShowButton = True
        Me.dtfCtaLp.Size = New System.Drawing.Size(437, 26)
        Me.dtfCtaLp.TabIndex = 1
        Me.dtfCtaLp.Text_Data = ""
        Me.dtfCtaLp.Text_Data_Desc = ""
        Me.dtfCtaLp.Text_Width = 100
        Me.dtfCtaLp.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfCtaLp.TopPadding = 0
        Me.dtfCtaLp.Upper_Case = False
        Me.dtfCtaLp.Validate_on_lost_focus = True
        '
        'dtfCtaCP
        '
        Me.dtfCtaCP.Allow_Empty = True
        Me.dtfCtaCP.Allow_Negative = True
        Me.dtfCtaCP.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfCtaCP.BackColor = System.Drawing.SystemColors.Control
        Me.dtfCtaCP.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfCtaCP.DataField = "CTACP"
        Me.dtfCtaCP.DataTable = "PR1"
        Me.dtfCtaCP.DB = Connection7
        Me.dtfCtaCP.Desc_Datafield = "DESCRIP"
        Me.dtfCtaCP.Desc_DBPK = "CODIGO"
        Me.dtfCtaCP.Desc_DBTable = "CU1"
        Me.dtfCtaCP.Desc_Where = Nothing
        Me.dtfCtaCP.Desc_WhereObligatoria = Nothing
        Me.dtfCtaCP.Descripcion = "Cuenta C/P"
        Me.dtfCtaCP.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfCtaCP.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfCtaCP.ExtraSQL = "SUBLICEN"
        Me.dtfCtaCP.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfCtaCP.Formulario = Nothing
        Me.dtfCtaCP.Label_Space = 109
        Me.dtfCtaCP.Length_Data = 32767
        Me.dtfCtaCP.Location = New System.Drawing.Point(6, 18)
        Me.dtfCtaCP.Lupa = Nothing
        Me.dtfCtaCP.Max_Value = 0.0R
        Me.dtfCtaCP.MensajeIncorrectoCustom = Nothing
        Me.dtfCtaCP.Name = "dtfCtaCP"
        Me.dtfCtaCP.Null_on_Empty = True
        Me.dtfCtaCP.OpenForm = Nothing
        Me.dtfCtaCP.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfCtaCP.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfCtaCP.Query_on_Text_Changed = True
        Me.dtfCtaCP.ReadOnly_Data = False
        Me.dtfCtaCP.ShowButton = True
        Me.dtfCtaCP.Size = New System.Drawing.Size(437, 26)
        Me.dtfCtaCP.TabIndex = 0
        Me.dtfCtaCP.Text_Data = ""
        Me.dtfCtaCP.Text_Data_Desc = ""
        Me.dtfCtaCP.Text_Width = 100
        Me.dtfCtaCP.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfCtaCP.TopPadding = 0
        Me.dtfCtaCP.Upper_Case = False
        Me.dtfCtaCP.Validate_on_lost_focus = True
        '
        'dtfCtaGastoAbono
        '
        Me.dtfCtaGastoAbono.Allow_Empty = True
        Me.dtfCtaGastoAbono.Allow_Negative = True
        Me.dtfCtaGastoAbono.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfCtaGastoAbono.BackColor = System.Drawing.SystemColors.Control
        Me.dtfCtaGastoAbono.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfCtaGastoAbono.DataField = "CUGASTOABONO"
        Me.dtfCtaGastoAbono.DataTable = "PR1"
        Me.dtfCtaGastoAbono.DB = Connection8
        Me.dtfCtaGastoAbono.Desc_Datafield = "DESCRIP"
        Me.dtfCtaGastoAbono.Desc_DBPK = "CODIGO"
        Me.dtfCtaGastoAbono.Desc_DBTable = "CU1"
        Me.dtfCtaGastoAbono.Desc_Where = Nothing
        Me.dtfCtaGastoAbono.Desc_WhereObligatoria = Nothing
        Me.dtfCtaGastoAbono.Descripcion = "Cta. Gasto Abono"
        Me.dtfCtaGastoAbono.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfCtaGastoAbono.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfCtaGastoAbono.ExtraSQL = "SUBLICEN"
        Me.dtfCtaGastoAbono.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfCtaGastoAbono.Formulario = Nothing
        Me.dtfCtaGastoAbono.Label_Space = 115
        Me.dtfCtaGastoAbono.Length_Data = 32767
        Me.dtfCtaGastoAbono.Location = New System.Drawing.Point(6, 148)
        Me.dtfCtaGastoAbono.Lupa = Nothing
        Me.dtfCtaGastoAbono.Max_Value = 0.0R
        Me.dtfCtaGastoAbono.MensajeIncorrectoCustom = Nothing
        Me.dtfCtaGastoAbono.Name = "dtfCtaGastoAbono"
        Me.dtfCtaGastoAbono.Null_on_Empty = True
        Me.dtfCtaGastoAbono.OpenForm = Nothing
        Me.dtfCtaGastoAbono.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfCtaGastoAbono.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfCtaGastoAbono.Query_on_Text_Changed = True
        Me.dtfCtaGastoAbono.ReadOnly_Data = False
        Me.dtfCtaGastoAbono.ShowButton = True
        Me.dtfCtaGastoAbono.Size = New System.Drawing.Size(449, 26)
        Me.dtfCtaGastoAbono.TabIndex = 5
        Me.dtfCtaGastoAbono.Text_Data = ""
        Me.dtfCtaGastoAbono.Text_Data_Desc = ""
        Me.dtfCtaGastoAbono.Text_Width = 100
        Me.dtfCtaGastoAbono.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfCtaGastoAbono.TopPadding = 0
        Me.dtfCtaGastoAbono.Upper_Case = False
        Me.dtfCtaGastoAbono.Validate_on_lost_focus = True
        '
        'dtfCtaPago
        '
        Me.dtfCtaPago.Allow_Empty = True
        Me.dtfCtaPago.Allow_Negative = True
        Me.dtfCtaPago.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfCtaPago.BackColor = System.Drawing.SystemColors.Control
        Me.dtfCtaPago.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfCtaPago.DataField = "CTAPAGO"
        Me.dtfCtaPago.DataTable = "PR1"
        Me.dtfCtaPago.DB = Connection9
        Me.dtfCtaPago.Desc_Datafield = "DESCRIP"
        Me.dtfCtaPago.Desc_DBPK = "CODIGO"
        Me.dtfCtaPago.Desc_DBTable = "CU1"
        Me.dtfCtaPago.Desc_Where = Nothing
        Me.dtfCtaPago.Desc_WhereObligatoria = Nothing
        Me.dtfCtaPago.Descripcion = "Cuenta Pago"
        Me.dtfCtaPago.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfCtaPago.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfCtaPago.ExtraSQL = "SUBLICEN"
        Me.dtfCtaPago.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfCtaPago.Formulario = Nothing
        Me.dtfCtaPago.Label_Space = 115
        Me.dtfCtaPago.Length_Data = 32767
        Me.dtfCtaPago.Location = New System.Drawing.Point(6, 122)
        Me.dtfCtaPago.Lupa = Nothing
        Me.dtfCtaPago.Max_Value = 0.0R
        Me.dtfCtaPago.MensajeIncorrectoCustom = Nothing
        Me.dtfCtaPago.Name = "dtfCtaPago"
        Me.dtfCtaPago.Null_on_Empty = True
        Me.dtfCtaPago.OpenForm = Nothing
        Me.dtfCtaPago.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfCtaPago.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfCtaPago.Query_on_Text_Changed = True
        Me.dtfCtaPago.ReadOnly_Data = False
        Me.dtfCtaPago.ShowButton = True
        Me.dtfCtaPago.Size = New System.Drawing.Size(449, 26)
        Me.dtfCtaPago.TabIndex = 4
        Me.dtfCtaPago.Text_Data = ""
        Me.dtfCtaPago.Text_Data_Desc = ""
        Me.dtfCtaPago.Text_Width = 100
        Me.dtfCtaPago.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfCtaPago.TopPadding = 0
        Me.dtfCtaPago.Upper_Case = False
        Me.dtfCtaPago.Validate_on_lost_focus = True
        '
        'pnlRetencion
        '
        Me.pnlRetencion.Auto_Size = False
        Me.pnlRetencion.BackColor = System.Drawing.SystemColors.Control
        Me.pnlRetencion.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlRetencion.ChangeDock = True
        Me.pnlRetencion.Control_Resize = False
        Me.pnlRetencion.Controls.Add(Me.dtfCtaRetencion)
        Me.pnlRetencion.Controls.Add(Me.pnlSpace12)
        Me.pnlRetencion.Controls.Add(Me.dtfPorcenRetencion)
        Me.pnlRetencion.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlRetencion.isSpace = False
        Me.pnlRetencion.Location = New System.Drawing.Point(6, 96)
        Me.pnlRetencion.Name = "pnlRetencion"
        Me.pnlRetencion.numRows = 1
        Me.pnlRetencion.Reorder = True
        Me.pnlRetencion.Size = New System.Drawing.Size(449, 26)
        Me.pnlRetencion.TabIndex = 3
        '
        'dtfCtaRetencion
        '
        Me.dtfCtaRetencion.Allow_Empty = True
        Me.dtfCtaRetencion.Allow_Negative = True
        Me.dtfCtaRetencion.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfCtaRetencion.BackColor = System.Drawing.SystemColors.Control
        Me.dtfCtaRetencion.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfCtaRetencion.DataField = "RETENCION"
        Me.dtfCtaRetencion.DataTable = "PR2"
        Me.dtfCtaRetencion.DB = Connection10
        Me.dtfCtaRetencion.Desc_Datafield = "DESCRIP"
        Me.dtfCtaRetencion.Desc_DBPK = "CODIGO"
        Me.dtfCtaRetencion.Desc_DBTable = "CU1"
        Me.dtfCtaRetencion.Desc_Where = Nothing
        Me.dtfCtaRetencion.Desc_WhereObligatoria = Nothing
        Me.dtfCtaRetencion.Descripcion = "Cuenta Retención"
        Me.dtfCtaRetencion.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfCtaRetencion.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfCtaRetencion.ExtraSQL = "SUBLICEN"
        Me.dtfCtaRetencion.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfCtaRetencion.Formulario = Nothing
        Me.dtfCtaRetencion.Label_Space = 115
        Me.dtfCtaRetencion.Length_Data = 32767
        Me.dtfCtaRetencion.Location = New System.Drawing.Point(0, 0)
        Me.dtfCtaRetencion.Lupa = Nothing
        Me.dtfCtaRetencion.Max_Value = 0.0R
        Me.dtfCtaRetencion.MensajeIncorrectoCustom = Nothing
        Me.dtfCtaRetencion.Name = "dtfCtaRetencion"
        Me.dtfCtaRetencion.Null_on_Empty = True
        Me.dtfCtaRetencion.OpenForm = Nothing
        Me.dtfCtaRetencion.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfCtaRetencion.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfCtaRetencion.Query_on_Text_Changed = True
        Me.dtfCtaRetencion.ReadOnly_Data = False
        Me.dtfCtaRetencion.ShowButton = True
        Me.dtfCtaRetencion.Size = New System.Drawing.Size(343, 26)
        Me.dtfCtaRetencion.TabIndex = 0
        Me.dtfCtaRetencion.Text_Data = ""
        Me.dtfCtaRetencion.Text_Data_Desc = ""
        Me.dtfCtaRetencion.Text_Width = 100
        Me.dtfCtaRetencion.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfCtaRetencion.TopPadding = 0
        Me.dtfCtaRetencion.Upper_Case = False
        Me.dtfCtaRetencion.Validate_on_lost_focus = True
        '
        'pnlSpace12
        '
        Me.pnlSpace12.Auto_Size = False
        Me.pnlSpace12.BackColor = System.Drawing.SystemColors.Control
        Me.pnlSpace12.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace12.ChangeDock = True
        Me.pnlSpace12.Control_Resize = False
        Me.pnlSpace12.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSpace12.isSpace = True
        Me.pnlSpace12.Location = New System.Drawing.Point(343, 0)
        Me.pnlSpace12.Name = "pnlSpace12"
        Me.pnlSpace12.numRows = 0
        Me.pnlSpace12.Reorder = False
        Me.pnlSpace12.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace12.TabIndex = 1
        '
        'dtfPorcenRetencion
        '
        Me.dtfPorcenRetencion.Allow_Empty = True
        Me.dtfPorcenRetencion.Allow_Negative = False
        Me.dtfPorcenRetencion.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfPorcenRetencion.BackColor = System.Drawing.SystemColors.Control
        Me.dtfPorcenRetencion.Data_Allowed = CustomControls.Datafield.List_Data.nDouble
        Me.dtfPorcenRetencion.DataField = "PORRETEN"
        Me.dtfPorcenRetencion.DataTable = "PR1"
        Me.dtfPorcenRetencion.Descripcion = "% Reten."
        Me.dtfPorcenRetencion.Dock = System.Windows.Forms.DockStyle.Right
        Me.dtfPorcenRetencion.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfPorcenRetencion.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfPorcenRetencion.Image = Nothing
        Me.dtfPorcenRetencion.Label_Space = 60
        Me.dtfPorcenRetencion.Length_Data = 32767
        Me.dtfPorcenRetencion.Location = New System.Drawing.Point(349, 0)
        Me.dtfPorcenRetencion.Max_Value = 100.0R
        Me.dtfPorcenRetencion.MensajeIncorrectoCustom = Nothing
        Me.dtfPorcenRetencion.Name = "dtfPorcenRetencion"
        Me.dtfPorcenRetencion.Null_on_Empty = True
        Me.dtfPorcenRetencion.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfPorcenRetencion.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfPorcenRetencion.ReadOnly_Data = False
        Me.dtfPorcenRetencion.Show_Button = False
        Me.dtfPorcenRetencion.Size = New System.Drawing.Size(100, 26)
        Me.dtfPorcenRetencion.TabIndex = 2
        Me.dtfPorcenRetencion.Text_Data = ""
        Me.dtfPorcenRetencion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.dtfPorcenRetencion.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfPorcenRetencion.TopPadding = 0
        Me.dtfPorcenRetencion.Upper_Case = False
        Me.dtfPorcenRetencion.Validate_on_lost_focus = True
        '
        'pnlCtaCompGasto
        '
        Me.pnlCtaCompGasto.Auto_Size = False
        Me.pnlCtaCompGasto.BackColor = System.Drawing.SystemColors.Control
        Me.pnlCtaCompGasto.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlCtaCompGasto.ChangeDock = True
        Me.pnlCtaCompGasto.Control_Resize = False
        Me.pnlCtaCompGasto.Controls.Add(Me.dtfCtaCompGasto)
        Me.pnlCtaCompGasto.Controls.Add(Me.pnlSpace13)
        Me.pnlCtaCompGasto.Controls.Add(Me.btnCompGastoAplicar)
        Me.pnlCtaCompGasto.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCtaCompGasto.isSpace = False
        Me.pnlCtaCompGasto.Location = New System.Drawing.Point(6, 70)
        Me.pnlCtaCompGasto.Name = "pnlCtaCompGasto"
        Me.pnlCtaCompGasto.numRows = 1
        Me.pnlCtaCompGasto.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.pnlCtaCompGasto.Reorder = True
        Me.pnlCtaCompGasto.Size = New System.Drawing.Size(449, 26)
        Me.pnlCtaCompGasto.TabIndex = 2
        '
        'dtfCtaCompGasto
        '
        Me.dtfCtaCompGasto.Allow_Empty = True
        Me.dtfCtaCompGasto.Allow_Negative = True
        Me.dtfCtaCompGasto.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfCtaCompGasto.BackColor = System.Drawing.SystemColors.Control
        Me.dtfCtaCompGasto.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfCtaCompGasto.DataField = "CUGASTO"
        Me.dtfCtaCompGasto.DataTable = "PR2"
        Me.dtfCtaCompGasto.DB = Connection11
        Me.dtfCtaCompGasto.Desc_Datafield = "DESCRIP"
        Me.dtfCtaCompGasto.Desc_DBPK = "CODIGO"
        Me.dtfCtaCompGasto.Desc_DBTable = "CU1"
        Me.dtfCtaCompGasto.Desc_Where = Nothing
        Me.dtfCtaCompGasto.Desc_WhereObligatoria = Nothing
        Me.dtfCtaCompGasto.Descripcion = "Cta. Compra/Gasto"
        Me.dtfCtaCompGasto.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfCtaCompGasto.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfCtaCompGasto.ExtraSQL = "SUBLICEN"
        Me.dtfCtaCompGasto.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfCtaCompGasto.Formulario = Nothing
        Me.dtfCtaCompGasto.Label_Space = 115
        Me.dtfCtaCompGasto.Length_Data = 32767
        Me.dtfCtaCompGasto.Location = New System.Drawing.Point(0, 0)
        Me.dtfCtaCompGasto.Lupa = Nothing
        Me.dtfCtaCompGasto.Max_Value = 0.0R
        Me.dtfCtaCompGasto.MensajeIncorrectoCustom = Nothing
        Me.dtfCtaCompGasto.Name = "dtfCtaCompGasto"
        Me.dtfCtaCompGasto.Null_on_Empty = True
        Me.dtfCtaCompGasto.OpenForm = Nothing
        Me.dtfCtaCompGasto.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfCtaCompGasto.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfCtaCompGasto.Query_on_Text_Changed = True
        Me.dtfCtaCompGasto.ReadOnly_Data = False
        Me.dtfCtaCompGasto.ShowButton = True
        Me.dtfCtaCompGasto.Size = New System.Drawing.Size(383, 26)
        Me.dtfCtaCompGasto.TabIndex = 0
        Me.dtfCtaCompGasto.Text_Data = ""
        Me.dtfCtaCompGasto.Text_Data_Desc = ""
        Me.dtfCtaCompGasto.Text_Width = 100
        Me.dtfCtaCompGasto.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfCtaCompGasto.TopPadding = 0
        Me.dtfCtaCompGasto.Upper_Case = False
        Me.dtfCtaCompGasto.Validate_on_lost_focus = True
        '
        'pnlSpace13
        '
        Me.pnlSpace13.Auto_Size = False
        Me.pnlSpace13.BackColor = System.Drawing.SystemColors.Control
        Me.pnlSpace13.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace13.ChangeDock = True
        Me.pnlSpace13.Control_Resize = False
        Me.pnlSpace13.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSpace13.isSpace = True
        Me.pnlSpace13.Location = New System.Drawing.Point(383, 0)
        Me.pnlSpace13.Name = "pnlSpace13"
        Me.pnlSpace13.numRows = 0
        Me.pnlSpace13.Reorder = False
        Me.pnlSpace13.Size = New System.Drawing.Size(6, 20)
        Me.pnlSpace13.TabIndex = 1
        '
        'btnCompGastoAplicar
        '
        Me.btnCompGastoAplicar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnCompGastoAplicar.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnCompGastoAplicar.Location = New System.Drawing.Point(389, 0)
        Me.btnCompGastoAplicar.Name = "btnCompGastoAplicar"
        Me.btnCompGastoAplicar.Size = New System.Drawing.Size(60, 20)
        Me.btnCompGastoAplicar.TabIndex = 2
        Me.btnCompGastoAplicar.Text = "Aplicar"
        Me.btnCompGastoAplicar.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.btnCompGastoAplicar.ThemeName = "Windows8"
        '
        'dtfCtaContable
        '
        Me.dtfCtaContable.Allow_Empty = True
        Me.dtfCtaContable.Allow_Negative = True
        Me.dtfCtaContable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfCtaContable.BackColor = System.Drawing.SystemColors.Control
        Me.dtfCtaContable.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfCtaContable.DataField = "CONTABLE"
        Me.dtfCtaContable.DataTable = "PR2"
        Me.dtfCtaContable.DB = Connection12
        Me.dtfCtaContable.Desc_Datafield = "DESCRIP"
        Me.dtfCtaContable.Desc_DBPK = "CODIGO"
        Me.dtfCtaContable.Desc_DBTable = "CU1"
        Me.dtfCtaContable.Desc_Where = Nothing
        Me.dtfCtaContable.Desc_WhereObligatoria = Nothing
        Me.dtfCtaContable.Descripcion = "Cuenta Contable"
        Me.dtfCtaContable.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfCtaContable.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfCtaContable.ExtraSQL = "SUBLICEN"
        Me.dtfCtaContable.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfCtaContable.Formulario = Nothing
        Me.dtfCtaContable.Label_Space = 115
        Me.dtfCtaContable.Length_Data = 32767
        Me.dtfCtaContable.Location = New System.Drawing.Point(6, 44)
        Me.dtfCtaContable.Lupa = Nothing
        Me.dtfCtaContable.Max_Value = 0.0R
        Me.dtfCtaContable.MensajeIncorrectoCustom = Nothing
        Me.dtfCtaContable.Name = "dtfCtaContable"
        Me.dtfCtaContable.Null_on_Empty = True
        Me.dtfCtaContable.OpenForm = Nothing
        Me.dtfCtaContable.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfCtaContable.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfCtaContable.Query_on_Text_Changed = True
        Me.dtfCtaContable.ReadOnly_Data = False
        Me.dtfCtaContable.ShowButton = True
        Me.dtfCtaContable.Size = New System.Drawing.Size(449, 26)
        Me.dtfCtaContable.TabIndex = 1
        Me.dtfCtaContable.Text_Data = ""
        Me.dtfCtaContable.Text_Data_Desc = ""
        Me.dtfCtaContable.Text_Width = 100
        Me.dtfCtaContable.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfCtaContable.TopPadding = 0
        Me.dtfCtaContable.Upper_Case = False
        Me.dtfCtaContable.Validate_on_lost_focus = True
        '
        'pnlCtaContable
        '
        Me.pnlCtaContable.Auto_Size = False
        Me.pnlCtaContable.BackColor = System.Drawing.SystemColors.Control
        Me.pnlCtaContable.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlCtaContable.ChangeDock = True
        Me.pnlCtaContable.Control_Resize = False
        Me.pnlCtaContable.Controls.Add(Me.dtfSaldo)
        Me.pnlCtaContable.Controls.Add(Me.dtcNoAparecer347349)
        Me.pnlCtaContable.Controls.Add(Me.pnlSpace11)
        Me.pnlCtaContable.Controls.Add(Me.dtfPrefijoCta)
        Me.pnlCtaContable.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCtaContable.isSpace = False
        Me.pnlCtaContable.Location = New System.Drawing.Point(6, 18)
        Me.pnlCtaContable.Name = "pnlCtaContable"
        Me.pnlCtaContable.numRows = 1
        Me.pnlCtaContable.Reorder = True
        Me.pnlCtaContable.Size = New System.Drawing.Size(449, 26)
        Me.pnlCtaContable.TabIndex = 0
        '
        'dtfSaldo
        '
        Me.dtfSaldo.Allow_Empty = True
        Me.dtfSaldo.Allow_Negative = True
        Me.dtfSaldo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfSaldo.BackColor = System.Drawing.SystemColors.Control
        Me.dtfSaldo.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfSaldo.DataField = ""
        Me.dtfSaldo.DataTable = ""
        Me.dtfSaldo.Descripcion = "Saldo"
        Me.dtfSaldo.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfSaldo.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfSaldo.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfSaldo.Image = Nothing
        Me.dtfSaldo.Label_Space = 50
        Me.dtfSaldo.Length_Data = 32767
        Me.dtfSaldo.Location = New System.Drawing.Point(172, 0)
        Me.dtfSaldo.Max_Value = 0.0R
        Me.dtfSaldo.MensajeIncorrectoCustom = Nothing
        Me.dtfSaldo.Name = "dtfSaldo"
        Me.dtfSaldo.Null_on_Empty = True
        Me.dtfSaldo.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfSaldo.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfSaldo.ReadOnly_Data = True
        Me.dtfSaldo.Show_Button = False
        Me.dtfSaldo.Size = New System.Drawing.Size(112, 26)
        Me.dtfSaldo.TabIndex = 2
        Me.dtfSaldo.TabStop = False
        Me.dtfSaldo.Text_Data = ""
        Me.dtfSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfSaldo.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfSaldo.TopPadding = 0
        Me.dtfSaldo.Upper_Case = False
        Me.dtfSaldo.Validate_on_lost_focus = True
        '
        'dtcNoAparecer347349
        '
        Me.dtcNoAparecer347349.DataField = Nothing
        Me.dtcNoAparecer347349.DataTable = ""
        Me.dtcNoAparecer347349.Descripcion = "No aparecer en 347/349"
        Me.dtcNoAparecer347349.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtcNoAparecer347349.Location = New System.Drawing.Point(290, 0)
        Me.dtcNoAparecer347349.Name = "dtcNoAparecer347349"
        Me.dtcNoAparecer347349.Size = New System.Drawing.Size(162, 18)
        Me.dtcNoAparecer347349.TabIndex = 3
        Me.dtcNoAparecer347349.Text = "No aparecer en 347/349"
        Me.dtcNoAparecer347349.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtcNoAparecer347349.ThemeName = "Windows8"
        Me.dtcNoAparecer347349.Value = False
        '
        'pnlSpace11
        '
        Me.pnlSpace11.Auto_Size = False
        Me.pnlSpace11.BackColor = System.Drawing.SystemColors.Control
        Me.pnlSpace11.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace11.ChangeDock = True
        Me.pnlSpace11.Control_Resize = False
        Me.pnlSpace11.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace11.isSpace = True
        Me.pnlSpace11.Location = New System.Drawing.Point(166, 0)
        Me.pnlSpace11.Name = "pnlSpace11"
        Me.pnlSpace11.numRows = 0
        Me.pnlSpace11.Reorder = False
        Me.pnlSpace11.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace11.TabIndex = 1
        '
        'dtfPrefijoCta
        '
        Me.dtfPrefijoCta.Allow_Empty = True
        Me.dtfPrefijoCta.Allow_Negative = True
        Me.dtfPrefijoCta.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfPrefijoCta.BackColor = System.Drawing.SystemColors.Control
        Me.dtfPrefijoCta.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfPrefijoCta.DataField = "PREFIJO"
        Me.dtfPrefijoCta.DataTable = "PR2"
        Me.dtfPrefijoCta.Descripcion = "Prefijo Cuenta"
        Me.dtfPrefijoCta.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfPrefijoCta.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfPrefijoCta.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfPrefijoCta.Image = Nothing
        Me.dtfPrefijoCta.Label_Space = 115
        Me.dtfPrefijoCta.Length_Data = 32767
        Me.dtfPrefijoCta.Location = New System.Drawing.Point(0, 0)
        Me.dtfPrefijoCta.Max_Value = 0.0R
        Me.dtfPrefijoCta.MensajeIncorrectoCustom = Nothing
        Me.dtfPrefijoCta.Name = "dtfPrefijoCta"
        Me.dtfPrefijoCta.Null_on_Empty = True
        Me.dtfPrefijoCta.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfPrefijoCta.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfPrefijoCta.ReadOnly_Data = False
        Me.dtfPrefijoCta.Show_Button = False
        Me.dtfPrefijoCta.Size = New System.Drawing.Size(166, 26)
        Me.dtfPrefijoCta.TabIndex = 0
        Me.dtfPrefijoCta.Text_Data = ""
        Me.dtfPrefijoCta.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfPrefijoCta.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfPrefijoCta.TopPadding = 0
        Me.dtfPrefijoCta.Upper_Case = False
        Me.dtfPrefijoCta.Validate_on_lost_focus = True
        '
        'pnlFacturacion
        '
        Me.pnlFacturacion.Auto_Size = False
        Me.pnlFacturacion.BackColor = System.Drawing.SystemColors.Control
        Me.pnlFacturacion.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlFacturacion.ChangeDock = True
        Me.pnlFacturacion.Control_Resize = False
        Me.pnlFacturacion.Controls.Add(Me.gbxFacturacion)
        Me.pnlFacturacion.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlFacturacion.isSpace = False
        Me.pnlFacturacion.Location = New System.Drawing.Point(0, 67)
        Me.pnlFacturacion.MinimumSize = New System.Drawing.Size(467, 0)
        Me.pnlFacturacion.Name = "pnlFacturacion"
        Me.pnlFacturacion.numRows = 0
        Me.pnlFacturacion.Padding = New System.Windows.Forms.Padding(3)
        Me.pnlFacturacion.Reorder = True
        '
        '
        '
        Me.pnlFacturacion.RootElement.MinSize = New System.Drawing.Size(467, 0)
        Me.pnlFacturacion.Size = New System.Drawing.Size(467, 451)
        Me.pnlFacturacion.TabIndex = 3
        '
        'gbxFacturacion
        '
        Me.gbxFacturacion.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.gbxFacturacion.Controls.Add(Me.pnlChecks)
        Me.gbxFacturacion.Controls.Add(Me.Panel1)
        Me.gbxFacturacion.Controls.Add(Me.PnlIdiomaDivisa)
        Me.gbxFacturacion.Controls.Add(Me.dtfBanco)
        Me.gbxFacturacion.Controls.Add(Me.dtfCC)
        Me.gbxFacturacion.Controls.Add(Me.pnlIbanSwift)
        Me.gbxFacturacion.Controls.Add(Me.pnlVacaciones)
        Me.gbxFacturacion.Controls.Add(Me.pnlDtos)
        Me.gbxFacturacion.Controls.Add(Me.pnlPlazosPago)
        Me.gbxFacturacion.Controls.Add(Me.dftFormaPago)
        Me.gbxFacturacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbxFacturacion.HeaderText = "Facturación"
        Me.gbxFacturacion.Location = New System.Drawing.Point(3, 3)
        Me.gbxFacturacion.Name = "gbxFacturacion"
        Me.gbxFacturacion.numRows = 0
        Me.gbxFacturacion.Padding = New System.Windows.Forms.Padding(6, 18, 6, 6)
        Me.gbxFacturacion.Reorder = True
        Me.gbxFacturacion.Size = New System.Drawing.Size(461, 445)
        Me.gbxFacturacion.TabIndex = 0
        Me.gbxFacturacion.Text = "Facturación"
        Me.gbxFacturacion.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.gbxFacturacion.ThemeName = "Windows8"
        Me.gbxFacturacion.Title = "Facturación"
        '
        'pnlChecks
        '
        Me.pnlChecks.Auto_Size = False
        Me.pnlChecks.BackColor = System.Drawing.SystemColors.Control
        Me.pnlChecks.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlChecks.ChangeDock = True
        Me.pnlChecks.Control_Resize = False
        Me.pnlChecks.Controls.Add(Me.pnlChecks2)
        Me.pnlChecks.Controls.Add(Me.pnlChecksIzq)
        Me.pnlChecks.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlChecks.isSpace = False
        Me.pnlChecks.Location = New System.Drawing.Point(6, 252)
        Me.pnlChecks.Name = "pnlChecks"
        Me.pnlChecks.numRows = 4
        Me.pnlChecks.Reorder = True
        Me.pnlChecks.Size = New System.Drawing.Size(449, 102)
        Me.pnlChecks.TabIndex = 9
        '
        'pnlChecks2
        '
        Me.pnlChecks2.Auto_Size = False
        Me.pnlChecks2.BackColor = System.Drawing.SystemColors.Control
        Me.pnlChecks2.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlChecks2.ChangeDock = True
        Me.pnlChecks2.Control_Resize = False
        Me.pnlChecks2.Controls.Add(Me.dtcAutoFacMante)
        Me.pnlChecks2.Controls.Add(Me.dtcAlbaranesCosteTransp)
        Me.pnlChecks2.Controls.Add(Me.dtcExenOperInter)
        Me.pnlChecks2.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlChecks2.isSpace = False
        Me.pnlChecks2.Location = New System.Drawing.Point(208, 0)
        Me.pnlChecks2.Name = "pnlChecks2"
        Me.pnlChecks2.numRows = 0
        Me.pnlChecks2.Reorder = True
        Me.pnlChecks2.Size = New System.Drawing.Size(247, 102)
        Me.pnlChecks2.TabIndex = 1
        '
        'dtcAutoFacMante
        '
        Me.dtcAutoFacMante.DataField = "AUTOFAC_MANTE"
        Me.dtcAutoFacMante.DataTable = "PR1"
        Me.dtcAutoFacMante.Descripcion = "Generar Autofactura de Mantenimiento"
        Me.dtcAutoFacMante.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtcAutoFacMante.Location = New System.Drawing.Point(0, 54)
        Me.dtcAutoFacMante.Name = "dtcAutoFacMante"
        Me.dtcAutoFacMante.Size = New System.Drawing.Size(245, 18)
        Me.dtcAutoFacMante.TabIndex = 2
        Me.dtcAutoFacMante.Text = "Generar Autofactura de Mantenimiento"
        Me.dtcAutoFacMante.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtcAutoFacMante.ThemeName = "Windows8"
        Me.dtcAutoFacMante.Value = False
        '
        'dtcAlbaranesCosteTransp
        '
        Me.dtcAlbaranesCosteTransp.DataField = "PROALB_COSTE_TRANSP"
        Me.dtcAlbaranesCosteTransp.DataTable = "PR1"
        Me.dtcAlbaranesCosteTransp.Descripcion = "Albaranes Coste Transporte"
        Me.dtcAlbaranesCosteTransp.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtcAlbaranesCosteTransp.Location = New System.Drawing.Point(0, 6)
        Me.dtcAlbaranesCosteTransp.Name = "dtcAlbaranesCosteTransp"
        Me.dtcAlbaranesCosteTransp.Size = New System.Drawing.Size(181, 18)
        Me.dtcAlbaranesCosteTransp.TabIndex = 0
        Me.dtcAlbaranesCosteTransp.Text = "Albaranes Coste Transporte"
        Me.dtcAlbaranesCosteTransp.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtcAlbaranesCosteTransp.ThemeName = "Windows8"
        Me.dtcAlbaranesCosteTransp.Value = False
        '
        'dtcExenOperInter
        '
        Me.dtcExenOperInter.DataField = "EXENCIONES_INT"
        Me.dtcExenOperInter.DataTable = "PR1"
        Me.dtcExenOperInter.Descripcion = "Exenciones en Operaciones Interiores"
        Me.dtcExenOperInter.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtcExenOperInter.Location = New System.Drawing.Point(0, 30)
        Me.dtcExenOperInter.Name = "dtcExenOperInter"
        Me.dtcExenOperInter.Size = New System.Drawing.Size(238, 18)
        Me.dtcExenOperInter.TabIndex = 1
        Me.dtcExenOperInter.Text = "Exenciones en Operaciones Interiores"
        Me.dtcExenOperInter.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtcExenOperInter.ThemeName = "Windows8"
        Me.dtcExenOperInter.Value = False
        '
        'pnlChecksIzq
        '
        Me.pnlChecksIzq.Auto_Size = False
        Me.pnlChecksIzq.BackColor = System.Drawing.SystemColors.Control
        Me.pnlChecksIzq.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlChecksIzq.ChangeDock = True
        Me.pnlChecksIzq.Control_Resize = False
        Me.pnlChecksIzq.Controls.Add(Me.dtcGestAlba)
        Me.pnlChecksIzq.Controls.Add(Me.dtcEsIntracomunitario)
        Me.pnlChecksIzq.Controls.Add(Me.dtcGestIvaImportacion)
        Me.pnlChecksIzq.Controls.Add(Me.dtcMargenNoAuto)
        Me.pnlChecksIzq.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlChecksIzq.isSpace = False
        Me.pnlChecksIzq.Location = New System.Drawing.Point(0, 0)
        Me.pnlChecksIzq.Name = "pnlChecksIzq"
        Me.pnlChecksIzq.numRows = 0
        Me.pnlChecksIzq.Reorder = True
        Me.pnlChecksIzq.Size = New System.Drawing.Size(208, 102)
        Me.pnlChecksIzq.TabIndex = 0
        '
        'dtcGestAlba
        '
        Me.dtcGestAlba.DataField = "PALBARAN"
        Me.dtcGestAlba.DataTable = "PR2"
        Me.dtcGestAlba.Descripcion = "Gestión de albaranes"
        Me.dtcGestAlba.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtcGestAlba.Location = New System.Drawing.Point(0, 6)
        Me.dtcGestAlba.Name = "dtcGestAlba"
        Me.dtcGestAlba.Size = New System.Drawing.Size(143, 18)
        Me.dtcGestAlba.TabIndex = 0
        Me.dtcGestAlba.Text = "Gestión de albaranes"
        Me.dtcGestAlba.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtcGestAlba.ThemeName = "Windows8"
        Me.dtcGestAlba.Value = False
        '
        'dtcEsIntracomunitario
        '
        Me.dtcEsIntracomunitario.DataField = "INTRACO"
        Me.dtcEsIntracomunitario.DataTable = "PR2"
        Me.dtcEsIntracomunitario.Descripcion = "Es Intracomunitario"
        Me.dtcEsIntracomunitario.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtcEsIntracomunitario.Location = New System.Drawing.Point(0, 30)
        Me.dtcEsIntracomunitario.Name = "dtcEsIntracomunitario"
        Me.dtcEsIntracomunitario.Size = New System.Drawing.Size(136, 18)
        Me.dtcEsIntracomunitario.TabIndex = 1
        Me.dtcEsIntracomunitario.Text = "Es Intracomunitario"
        Me.dtcEsIntracomunitario.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtcEsIntracomunitario.ThemeName = "Windows8"
        Me.dtcEsIntracomunitario.Value = False
        '
        'dtcGestIvaImportacion
        '
        Me.dtcGestIvaImportacion.DataField = "GESTION_IVA_IMPORTA"
        Me.dtcGestIvaImportacion.DataTable = "PR1"
        Me.dtcGestIvaImportacion.Descripcion = "Gestionar IVA Importación"
        Me.dtcGestIvaImportacion.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtcGestIvaImportacion.Location = New System.Drawing.Point(0, 54)
        Me.dtcGestIvaImportacion.Name = "dtcGestIvaImportacion"
        Me.dtcGestIvaImportacion.Size = New System.Drawing.Size(175, 18)
        Me.dtcGestIvaImportacion.TabIndex = 2
        Me.dtcGestIvaImportacion.Text = "Gestionar IVA Importación"
        Me.dtcGestIvaImportacion.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtcGestIvaImportacion.ThemeName = "Windows8"
        Me.dtcGestIvaImportacion.Value = False
        '
        'dtcMargenNoAuto
        '
        Me.dtcMargenNoAuto.DataField = "NOAUTOMARGEN"
        Me.dtcMargenNoAuto.DataTable = "PR1"
        Me.dtcMargenNoAuto.Descripcion = "Margen No Automático"
        Me.dtcMargenNoAuto.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtcMargenNoAuto.Location = New System.Drawing.Point(0, 78)
        Me.dtcMargenNoAuto.Name = "dtcMargenNoAuto"
        Me.dtcMargenNoAuto.Size = New System.Drawing.Size(153, 18)
        Me.dtcMargenNoAuto.TabIndex = 3
        Me.dtcMargenNoAuto.Text = "Margen No Automático"
        Me.dtcMargenNoAuto.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtcMargenNoAuto.ThemeName = "Windows8"
        Me.dtcMargenNoAuto.Value = False
        '
        'Panel1
        '
        Me.Panel1.Auto_Size = False
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.BorderColor = System.Drawing.SystemColors.Control
        Me.Panel1.ChangeDock = True
        Me.Panel1.Control_Resize = False
        Me.Panel1.Controls.Add(Me.DatafieldLabel1)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.DatafieldLabel2)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.DatafieldLabel3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.isSpace = False
        Me.Panel1.Location = New System.Drawing.Point(6, 226)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.numRows = 1
        Me.Panel1.Reorder = True
        Me.Panel1.Size = New System.Drawing.Size(449, 26)
        Me.Panel1.TabIndex = 8
        '
        'DatafieldLabel1
        '
        Me.DatafieldLabel1.Allow_Empty = True
        Me.DatafieldLabel1.Allow_Negative = False
        Me.DatafieldLabel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.DatafieldLabel1.BackColor = System.Drawing.SystemColors.Control
        Me.DatafieldLabel1.Data_Allowed = CustomControls.Datafield.List_Data.nDouble
        Me.DatafieldLabel1.DataField = "TIPOIVA"
        Me.DatafieldLabel1.DataTable = "PR1"
        Me.DatafieldLabel1.Descripcion = "Tipo IVA"
        Me.DatafieldLabel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.DatafieldLabel1.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.DatafieldLabel1.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.DatafieldLabel1.Image = Nothing
        Me.DatafieldLabel1.Label_Space = 70
        Me.DatafieldLabel1.Length_Data = 32767
        Me.DatafieldLabel1.Location = New System.Drawing.Point(312, 0)
        Me.DatafieldLabel1.Max_Value = 100.0R
        Me.DatafieldLabel1.MensajeIncorrectoCustom = Nothing
        Me.DatafieldLabel1.Name = "DatafieldLabel1"
        Me.DatafieldLabel1.Null_on_Empty = True
        Me.DatafieldLabel1.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.DatafieldLabel1.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.DatafieldLabel1.ReadOnly_Data = False
        Me.DatafieldLabel1.Show_Button = False
        Me.DatafieldLabel1.Size = New System.Drawing.Size(137, 26)
        Me.DatafieldLabel1.TabIndex = 4
        Me.DatafieldLabel1.Text_Data = ""
        Me.DatafieldLabel1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.DatafieldLabel1.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.DatafieldLabel1.TopPadding = 0
        Me.DatafieldLabel1.Upper_Case = False
        Me.DatafieldLabel1.Validate_on_lost_focus = True
        '
        'Panel2
        '
        Me.Panel2.Auto_Size = False
        Me.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.Panel2.BorderColor = System.Drawing.SystemColors.Control
        Me.Panel2.ChangeDock = True
        Me.Panel2.Control_Resize = False
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.isSpace = True
        Me.Panel2.Location = New System.Drawing.Point(306, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.numRows = 0
        Me.Panel2.Reorder = True
        Me.Panel2.Size = New System.Drawing.Size(6, 26)
        Me.Panel2.TabIndex = 3
        '
        'DatafieldLabel2
        '
        Me.DatafieldLabel2.Allow_Empty = True
        Me.DatafieldLabel2.Allow_Negative = False
        Me.DatafieldLabel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.DatafieldLabel2.BackColor = System.Drawing.SystemColors.Control
        Me.DatafieldLabel2.Data_Allowed = CustomControls.Datafield.List_Data.nDouble
        Me.DatafieldLabel2.DataField = "PP"
        Me.DatafieldLabel2.DataTable = "PR2"
        Me.DatafieldLabel2.Descripcion = "Pronto Pago"
        Me.DatafieldLabel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.DatafieldLabel2.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.DatafieldLabel2.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.DatafieldLabel2.Image = Nothing
        Me.DatafieldLabel2.Label_Space = 85
        Me.DatafieldLabel2.Length_Data = 32767
        Me.DatafieldLabel2.Location = New System.Drawing.Point(156, 0)
        Me.DatafieldLabel2.Max_Value = 100.0R
        Me.DatafieldLabel2.MensajeIncorrectoCustom = Nothing
        Me.DatafieldLabel2.Name = "DatafieldLabel2"
        Me.DatafieldLabel2.Null_on_Empty = True
        Me.DatafieldLabel2.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.DatafieldLabel2.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.DatafieldLabel2.ReadOnly_Data = False
        Me.DatafieldLabel2.Show_Button = False
        Me.DatafieldLabel2.Size = New System.Drawing.Size(150, 26)
        Me.DatafieldLabel2.TabIndex = 2
        Me.DatafieldLabel2.Text_Data = ""
        Me.DatafieldLabel2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.DatafieldLabel2.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.DatafieldLabel2.TopPadding = 0
        Me.DatafieldLabel2.Upper_Case = False
        Me.DatafieldLabel2.Validate_on_lost_focus = True
        '
        'Panel3
        '
        Me.Panel3.Auto_Size = False
        Me.Panel3.BackColor = System.Drawing.SystemColors.Control
        Me.Panel3.BorderColor = System.Drawing.SystemColors.Control
        Me.Panel3.ChangeDock = True
        Me.Panel3.Control_Resize = False
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.isSpace = True
        Me.Panel3.Location = New System.Drawing.Point(150, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.numRows = 0
        Me.Panel3.Reorder = True
        Me.Panel3.Size = New System.Drawing.Size(6, 26)
        Me.Panel3.TabIndex = 1
        '
        'DatafieldLabel3
        '
        Me.DatafieldLabel3.Allow_Empty = True
        Me.DatafieldLabel3.Allow_Negative = False
        Me.DatafieldLabel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.DatafieldLabel3.BackColor = System.Drawing.SystemColors.Control
        Me.DatafieldLabel3.Data_Allowed = CustomControls.Datafield.List_Data.nDouble
        Me.DatafieldLabel3.DataField = "DTO"
        Me.DatafieldLabel3.DataTable = "PR2"
        Me.DatafieldLabel3.Descripcion = "Descuento"
        Me.DatafieldLabel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.DatafieldLabel3.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.DatafieldLabel3.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.DatafieldLabel3.Image = Nothing
        Me.DatafieldLabel3.Label_Space = 100
        Me.DatafieldLabel3.Length_Data = 32767
        Me.DatafieldLabel3.Location = New System.Drawing.Point(0, 0)
        Me.DatafieldLabel3.Max_Value = 100.0R
        Me.DatafieldLabel3.MensajeIncorrectoCustom = Nothing
        Me.DatafieldLabel3.Name = "DatafieldLabel3"
        Me.DatafieldLabel3.Null_on_Empty = True
        Me.DatafieldLabel3.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.DatafieldLabel3.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.DatafieldLabel3.ReadOnly_Data = False
        Me.DatafieldLabel3.Show_Button = False
        Me.DatafieldLabel3.Size = New System.Drawing.Size(150, 26)
        Me.DatafieldLabel3.TabIndex = 0
        Me.DatafieldLabel3.Text_Data = "99.99"
        Me.DatafieldLabel3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.DatafieldLabel3.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.DatafieldLabel3.TopPadding = 0
        Me.DatafieldLabel3.Upper_Case = False
        Me.DatafieldLabel3.Validate_on_lost_focus = True
        '
        'PnlIdiomaDivisa
        '
        Me.PnlIdiomaDivisa.Auto_Size = False
        Me.PnlIdiomaDivisa.BackColor = System.Drawing.SystemColors.Control
        Me.PnlIdiomaDivisa.BorderColor = System.Drawing.SystemColors.Control
        Me.PnlIdiomaDivisa.ChangeDock = True
        Me.PnlIdiomaDivisa.Control_Resize = False
        Me.PnlIdiomaDivisa.Controls.Add(Me.dftIdioma)
        Me.PnlIdiomaDivisa.Controls.Add(Me.pnlSpace23)
        Me.PnlIdiomaDivisa.Controls.Add(Me.DualDatafieldLabel2)
        Me.PnlIdiomaDivisa.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlIdiomaDivisa.isSpace = False
        Me.PnlIdiomaDivisa.Location = New System.Drawing.Point(6, 200)
        Me.PnlIdiomaDivisa.Name = "PnlIdiomaDivisa"
        Me.PnlIdiomaDivisa.numRows = 1
        Me.PnlIdiomaDivisa.Reorder = True
        Me.PnlIdiomaDivisa.Size = New System.Drawing.Size(449, 26)
        Me.PnlIdiomaDivisa.TabIndex = 7
        '
        'dftIdioma
        '
        Me.dftIdioma.Allow_Empty = True
        Me.dftIdioma.Allow_Negative = True
        Me.dftIdioma.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dftIdioma.BackColor = System.Drawing.SystemColors.Control
        Me.dftIdioma.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dftIdioma.DataField = "IDIOMA_PR1"
        Me.dftIdioma.DataTable = "PR1"
        Me.dftIdioma.DB = Connection13
        Me.dftIdioma.Desc_Datafield = "NOMBRE"
        Me.dftIdioma.Desc_DBPK = "CODIGO"
        Me.dftIdioma.Desc_DBTable = "IDIOMAS"
        Me.dftIdioma.Desc_Where = Nothing
        Me.dftIdioma.Desc_WhereObligatoria = Nothing
        Me.dftIdioma.Descripcion = "Idioma"
        Me.dftIdioma.Dock = System.Windows.Forms.DockStyle.Top
        Me.dftIdioma.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dftIdioma.ExtraSQL = ""
        Me.dftIdioma.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dftIdioma.Formulario = Nothing
        Me.dftIdioma.Label_Space = 100
        Me.dftIdioma.Length_Data = 32767
        Me.dftIdioma.Location = New System.Drawing.Point(0, 0)
        Me.dftIdioma.Lupa = Nothing
        Me.dftIdioma.Max_Value = 0.0R
        Me.dftIdioma.MensajeIncorrectoCustom = Nothing
        Me.dftIdioma.Name = "dftIdioma"
        Me.dftIdioma.Null_on_Empty = True
        Me.dftIdioma.OpenForm = Nothing
        Me.dftIdioma.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dftIdioma.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dftIdioma.Query_on_Text_Changed = True
        Me.dftIdioma.ReadOnly_Data = False
        Me.dftIdioma.ShowButton = True
        Me.dftIdioma.Size = New System.Drawing.Size(232, 26)
        Me.dftIdioma.TabIndex = 0
        Me.dftIdioma.Text_Data = ""
        Me.dftIdioma.Text_Data_Desc = ""
        Me.dftIdioma.Text_Width = 30
        Me.dftIdioma.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dftIdioma.TopPadding = 0
        Me.dftIdioma.Upper_Case = False
        Me.dftIdioma.Validate_on_lost_focus = True
        '
        'pnlSpace23
        '
        Me.pnlSpace23.Auto_Size = False
        Me.pnlSpace23.BackColor = System.Drawing.SystemColors.Control
        Me.pnlSpace23.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace23.ChangeDock = True
        Me.pnlSpace23.Control_Resize = False
        Me.pnlSpace23.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSpace23.isSpace = True
        Me.pnlSpace23.Location = New System.Drawing.Point(232, 0)
        Me.pnlSpace23.Name = "pnlSpace23"
        Me.pnlSpace23.numRows = 0
        Me.pnlSpace23.Reorder = True
        Me.pnlSpace23.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace23.TabIndex = 1
        '
        'DualDatafieldLabel2
        '
        Me.DualDatafieldLabel2.Allow_Empty = True
        Me.DualDatafieldLabel2.Allow_Negative = True
        Me.DualDatafieldLabel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.DualDatafieldLabel2.BackColor = System.Drawing.SystemColors.Control
        Me.DualDatafieldLabel2.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.DualDatafieldLabel2.DataField = "DIVISA"
        Me.DualDatafieldLabel2.DataTable = "PR2"
        Me.DualDatafieldLabel2.DB = Connection14
        Me.DualDatafieldLabel2.Desc_Datafield = "NOMBRE"
        Me.DualDatafieldLabel2.Desc_DBPK = "CODIGO"
        Me.DualDatafieldLabel2.Desc_DBTable = "DIVISAS"
        Me.DualDatafieldLabel2.Desc_Where = Nothing
        Me.DualDatafieldLabel2.Desc_WhereObligatoria = Nothing
        Me.DualDatafieldLabel2.Descripcion = "Divisa"
        Me.DualDatafieldLabel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.DualDatafieldLabel2.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.DualDatafieldLabel2.ExtraSQL = ""
        Me.DualDatafieldLabel2.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.DualDatafieldLabel2.Formulario = Nothing
        Me.DualDatafieldLabel2.Label_Space = 50
        Me.DualDatafieldLabel2.Length_Data = 32767
        Me.DualDatafieldLabel2.Location = New System.Drawing.Point(238, 0)
        Me.DualDatafieldLabel2.Lupa = Nothing
        Me.DualDatafieldLabel2.Max_Value = 0.0R
        Me.DualDatafieldLabel2.MensajeIncorrectoCustom = Nothing
        Me.DualDatafieldLabel2.Name = "DualDatafieldLabel2"
        Me.DualDatafieldLabel2.Null_on_Empty = True
        Me.DualDatafieldLabel2.OpenForm = Nothing
        Me.DualDatafieldLabel2.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.DualDatafieldLabel2.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.DualDatafieldLabel2.Query_on_Text_Changed = True
        Me.DualDatafieldLabel2.ReadOnly_Data = False
        Me.DualDatafieldLabel2.ShowButton = True
        Me.DualDatafieldLabel2.Size = New System.Drawing.Size(211, 26)
        Me.DualDatafieldLabel2.TabIndex = 2
        Me.DualDatafieldLabel2.Text_Data = ""
        Me.DualDatafieldLabel2.Text_Data_Desc = ""
        Me.DualDatafieldLabel2.Text_Width = 50
        Me.DualDatafieldLabel2.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.DualDatafieldLabel2.TopPadding = 0
        Me.DualDatafieldLabel2.Upper_Case = False
        Me.DualDatafieldLabel2.Validate_on_lost_focus = True
        '
        'dtfBanco
        '
        Me.dtfBanco.Allow_Empty = True
        Me.dtfBanco.Allow_Negative = True
        Me.dtfBanco.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfBanco.BackColor = System.Drawing.SystemColors.Control
        Me.dtfBanco.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfBanco.DataField = "BANCO"
        Me.dtfBanco.DataTable = "PR1"
        Me.dtfBanco.DB = Connection15
        Me.dtfBanco.Desc_Datafield = "NOMBRE"
        Me.dtfBanco.Desc_DBPK = "CODBAN"
        Me.dtfBanco.Desc_DBTable = "BANCO"
        Me.dtfBanco.Desc_Where = Nothing
        Me.dtfBanco.Desc_WhereObligatoria = Nothing
        Me.dtfBanco.Descripcion = "Banco"
        Me.dtfBanco.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfBanco.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfBanco.ExtraSQL = ""
        Me.dtfBanco.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfBanco.Formulario = Nothing
        Me.dtfBanco.Label_Space = 100
        Me.dtfBanco.Length_Data = 32767
        Me.dtfBanco.Location = New System.Drawing.Point(6, 174)
        Me.dtfBanco.Lupa = Nothing
        Me.dtfBanco.Max_Value = 0.0R
        Me.dtfBanco.MensajeIncorrectoCustom = Nothing
        Me.dtfBanco.Name = "dtfBanco"
        Me.dtfBanco.Null_on_Empty = True
        Me.dtfBanco.OpenForm = Nothing
        Me.dtfBanco.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfBanco.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfBanco.Query_on_Text_Changed = True
        Me.dtfBanco.ReadOnly_Data = False
        Me.dtfBanco.ShowButton = True
        Me.dtfBanco.Size = New System.Drawing.Size(449, 26)
        Me.dtfBanco.TabIndex = 6
        Me.dtfBanco.Text_Data = ""
        Me.dtfBanco.Text_Data_Desc = ""
        Me.dtfBanco.Text_Width = 66
        Me.dtfBanco.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfBanco.TopPadding = 0
        Me.dtfBanco.Upper_Case = False
        Me.dtfBanco.Validate_on_lost_focus = True
        '
        'dtfCC
        '
        Me.dtfCC.Allow_Empty = True
        Me.dtfCC.Allow_Negative = True
        Me.dtfCC.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfCC.BackColor = System.Drawing.SystemColors.Control
        Me.dtfCC.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfCC.DataField = "CC"
        Me.dtfCC.DataTable = "PR1"
        Me.dtfCC.Descripcion = "Cuenta Bancaria"
        Me.dtfCC.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfCC.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfCC.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfCC.Image = Nothing
        Me.dtfCC.Label_Space = 100
        Me.dtfCC.Length_Data = 32767
        Me.dtfCC.Location = New System.Drawing.Point(6, 148)
        Me.dtfCC.Max_Value = 0.0R
        Me.dtfCC.MensajeIncorrectoCustom = Nothing
        Me.dtfCC.Name = "dtfCC"
        Me.dtfCC.Null_on_Empty = True
        Me.dtfCC.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfCC.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfCC.ReadOnly_Data = False
        Me.dtfCC.Show_Button = False
        Me.dtfCC.Size = New System.Drawing.Size(449, 26)
        Me.dtfCC.TabIndex = 5
        Me.dtfCC.Text_Data = ""
        Me.dtfCC.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfCC.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfCC.TopPadding = 0
        Me.dtfCC.Upper_Case = False
        Me.dtfCC.Validate_on_lost_focus = True
        '
        'pnlIbanSwift
        '
        Me.pnlIbanSwift.Auto_Size = False
        Me.pnlIbanSwift.BackColor = System.Drawing.SystemColors.Control
        Me.pnlIbanSwift.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlIbanSwift.ChangeDock = True
        Me.pnlIbanSwift.Control_Resize = False
        Me.pnlIbanSwift.Controls.Add(Me.dtfIban)
        Me.pnlIbanSwift.Controls.Add(Me.pnlSpace20)
        Me.pnlIbanSwift.Controls.Add(Me.dtfSwift)
        Me.pnlIbanSwift.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlIbanSwift.isSpace = False
        Me.pnlIbanSwift.Location = New System.Drawing.Point(6, 122)
        Me.pnlIbanSwift.Name = "pnlIbanSwift"
        Me.pnlIbanSwift.numRows = 1
        Me.pnlIbanSwift.Reorder = True
        Me.pnlIbanSwift.Size = New System.Drawing.Size(449, 26)
        Me.pnlIbanSwift.TabIndex = 4
        '
        'dtfIban
        '
        Me.dtfIban.Allow_Empty = True
        Me.dtfIban.Allow_Negative = True
        Me.dtfIban.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfIban.BackColor = System.Drawing.SystemColors.Control
        Me.dtfIban.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfIban.DataField = "IBAN"
        Me.dtfIban.DataTable = "PR1"
        Me.dtfIban.Descripcion = "IBAN"
        Me.dtfIban.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfIban.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfIban.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfIban.Image = Nothing
        Me.dtfIban.Label_Space = 100
        Me.dtfIban.Length_Data = 32767
        Me.dtfIban.Location = New System.Drawing.Point(0, 0)
        Me.dtfIban.Max_Value = 0.0R
        Me.dtfIban.MensajeIncorrectoCustom = Nothing
        Me.dtfIban.Name = "dtfIban"
        Me.dtfIban.Null_on_Empty = True
        Me.dtfIban.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfIban.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfIban.ReadOnly_Data = False
        Me.dtfIban.Show_Button = False
        Me.dtfIban.Size = New System.Drawing.Size(282, 26)
        Me.dtfIban.TabIndex = 0
        Me.dtfIban.Text_Data = ""
        Me.dtfIban.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfIban.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfIban.TopPadding = 0
        Me.dtfIban.Upper_Case = False
        Me.dtfIban.Validate_on_lost_focus = True
        '
        'pnlSpace20
        '
        Me.pnlSpace20.Auto_Size = False
        Me.pnlSpace20.BackColor = System.Drawing.SystemColors.Control
        Me.pnlSpace20.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace20.ChangeDock = True
        Me.pnlSpace20.Control_Resize = False
        Me.pnlSpace20.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSpace20.isSpace = True
        Me.pnlSpace20.Location = New System.Drawing.Point(282, 0)
        Me.pnlSpace20.Name = "pnlSpace20"
        Me.pnlSpace20.numRows = 0
        Me.pnlSpace20.Reorder = True
        Me.pnlSpace20.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace20.TabIndex = 1
        '
        'dtfSwift
        '
        Me.dtfSwift.Allow_Empty = True
        Me.dtfSwift.Allow_Negative = True
        Me.dtfSwift.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfSwift.BackColor = System.Drawing.SystemColors.Control
        Me.dtfSwift.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfSwift.DataField = "SWIFT"
        Me.dtfSwift.DataTable = "PR1"
        Me.dtfSwift.Descripcion = "SWIFT"
        Me.dtfSwift.Dock = System.Windows.Forms.DockStyle.Right
        Me.dtfSwift.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfSwift.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfSwift.Image = Nothing
        Me.dtfSwift.Label_Space = 50
        Me.dtfSwift.Length_Data = 32767
        Me.dtfSwift.Location = New System.Drawing.Point(288, 0)
        Me.dtfSwift.Max_Value = 0.0R
        Me.dtfSwift.MensajeIncorrectoCustom = Nothing
        Me.dtfSwift.Name = "dtfSwift"
        Me.dtfSwift.Null_on_Empty = True
        Me.dtfSwift.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfSwift.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfSwift.ReadOnly_Data = False
        Me.dtfSwift.Show_Button = False
        Me.dtfSwift.Size = New System.Drawing.Size(161, 26)
        Me.dtfSwift.TabIndex = 2
        Me.dtfSwift.Text_Data = ""
        Me.dtfSwift.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfSwift.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfSwift.TopPadding = 0
        Me.dtfSwift.Upper_Case = False
        Me.dtfSwift.Validate_on_lost_focus = True
        '
        'pnlVacaciones
        '
        Me.pnlVacaciones.Auto_Size = False
        Me.pnlVacaciones.BackColor = System.Drawing.SystemColors.Control
        Me.pnlVacaciones.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlVacaciones.ChangeDock = True
        Me.pnlVacaciones.Control_Resize = False
        Me.pnlVacaciones.Controls.Add(Me.dtfMesVacaciones2)
        Me.pnlVacaciones.Controls.Add(Me.pnlSpace19)
        Me.pnlVacaciones.Controls.Add(Me.dtfMesVacaciones)
        Me.pnlVacaciones.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlVacaciones.isSpace = False
        Me.pnlVacaciones.Location = New System.Drawing.Point(6, 96)
        Me.pnlVacaciones.Name = "pnlVacaciones"
        Me.pnlVacaciones.numRows = 1
        Me.pnlVacaciones.Reorder = True
        Me.pnlVacaciones.Size = New System.Drawing.Size(449, 26)
        Me.pnlVacaciones.TabIndex = 3
        '
        'dtfMesVacaciones2
        '
        Me.dtfMesVacaciones2.Allow_Empty = True
        Me.dtfMesVacaciones2.Allow_Negative = False
        Me.dtfMesVacaciones2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfMesVacaciones2.BackColor = System.Drawing.SystemColors.Control
        Me.dtfMesVacaciones2.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfMesVacaciones2.DataField = "MESVACA2"
        Me.dtfMesVacaciones2.DataTable = "PR1"
        Me.dtfMesVacaciones2.DB = Connection16
        Me.dtfMesVacaciones2.Desc_Datafield = "MES"
        Me.dtfMesVacaciones2.Desc_DBPK = "NUMERO_MES"
        Me.dtfMesVacaciones2.Desc_DBTable = "MESES"
        Me.dtfMesVacaciones2.Desc_Where = Nothing
        Me.dtfMesVacaciones2.Desc_WhereObligatoria = Nothing
        Me.dtfMesVacaciones2.Descripcion = "Mes Vacaciones"
        Me.dtfMesVacaciones2.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfMesVacaciones2.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfMesVacaciones2.ExtraSQL = ""
        Me.dtfMesVacaciones2.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfMesVacaciones2.Formulario = Nothing
        Me.dtfMesVacaciones2.Length_Data = 32767
        Me.dtfMesVacaciones2.Location = New System.Drawing.Point(288, 0)
        Me.dtfMesVacaciones2.Lupa = Nothing
        Me.dtfMesVacaciones2.Max_Value = 12.0R
        Me.dtfMesVacaciones2.MensajeIncorrectoCustom = Nothing
        Me.dtfMesVacaciones2.Name = "dtfMesVacaciones2"
        Me.dtfMesVacaciones2.Null_on_Empty = True
        Me.dtfMesVacaciones2.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfMesVacaciones2.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfMesVacaciones2.Query_on_Text_Changed = True
        Me.dtfMesVacaciones2.ReadOnly_Data = False
        Me.dtfMesVacaciones2.Size = New System.Drawing.Size(161, 26)
        Me.dtfMesVacaciones2.TabIndex = 2
        Me.dtfMesVacaciones2.Text_Data = ""
        Me.dtfMesVacaciones2.Text_Data_Desc = ""
        Me.dtfMesVacaciones2.Text_Width = 30
        Me.dtfMesVacaciones2.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfMesVacaciones2.TopPadding = 0
        Me.dtfMesVacaciones2.Upper_Case = False
        Me.dtfMesVacaciones2.Validate_on_lost_focus = True
        '
        'pnlSpace19
        '
        Me.pnlSpace19.Auto_Size = False
        Me.pnlSpace19.BackColor = System.Drawing.SystemColors.Control
        Me.pnlSpace19.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace19.ChangeDock = True
        Me.pnlSpace19.Control_Resize = False
        Me.pnlSpace19.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace19.isSpace = True
        Me.pnlSpace19.Location = New System.Drawing.Point(282, 0)
        Me.pnlSpace19.Name = "pnlSpace19"
        Me.pnlSpace19.numRows = 0
        Me.pnlSpace19.Reorder = True
        Me.pnlSpace19.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace19.TabIndex = 1
        '
        'dtfMesVacaciones
        '
        Me.dtfMesVacaciones.Allow_Empty = True
        Me.dtfMesVacaciones.Allow_Negative = False
        Me.dtfMesVacaciones.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfMesVacaciones.BackColor = System.Drawing.SystemColors.Control
        Me.dtfMesVacaciones.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfMesVacaciones.DataField = "MESVACA"
        Me.dtfMesVacaciones.DataTable = "PR1"
        Me.dtfMesVacaciones.DB = Connection17
        Me.dtfMesVacaciones.Desc_Datafield = "MES"
        Me.dtfMesVacaciones.Desc_DBPK = "NUMERO_MES"
        Me.dtfMesVacaciones.Desc_DBTable = "MESES"
        Me.dtfMesVacaciones.Desc_Where = Nothing
        Me.dtfMesVacaciones.Desc_WhereObligatoria = Nothing
        Me.dtfMesVacaciones.Descripcion = "Mes Vacaciones"
        Me.dtfMesVacaciones.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfMesVacaciones.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfMesVacaciones.ExtraSQL = ""
        Me.dtfMesVacaciones.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfMesVacaciones.Formulario = Nothing
        Me.dtfMesVacaciones.Label_Space = 100
        Me.dtfMesVacaciones.Length_Data = 32767
        Me.dtfMesVacaciones.Location = New System.Drawing.Point(0, 0)
        Me.dtfMesVacaciones.Lupa = Nothing
        Me.dtfMesVacaciones.Max_Value = 12.0R
        Me.dtfMesVacaciones.MensajeIncorrectoCustom = Nothing
        Me.dtfMesVacaciones.Name = "dtfMesVacaciones"
        Me.dtfMesVacaciones.Null_on_Empty = True
        Me.dtfMesVacaciones.OpenForm = Nothing
        Me.dtfMesVacaciones.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfMesVacaciones.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfMesVacaciones.Query_on_Text_Changed = True
        Me.dtfMesVacaciones.ReadOnly_Data = False
        Me.dtfMesVacaciones.ShowButton = False
        Me.dtfMesVacaciones.Size = New System.Drawing.Size(282, 26)
        Me.dtfMesVacaciones.TabIndex = 0
        Me.dtfMesVacaciones.Text_Data = ""
        Me.dtfMesVacaciones.Text_Data_Desc = ""
        Me.dtfMesVacaciones.Text_Width = 30
        Me.dtfMesVacaciones.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfMesVacaciones.TopPadding = 0
        Me.dtfMesVacaciones.Upper_Case = False
        Me.dtfMesVacaciones.Validate_on_lost_focus = True
        '
        'pnlDtos
        '
        Me.pnlDtos.Auto_Size = False
        Me.pnlDtos.BackColor = System.Drawing.SystemColors.Control
        Me.pnlDtos.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlDtos.ChangeDock = True
        Me.pnlDtos.Control_Resize = False
        Me.pnlDtos.Controls.Add(Me.dtfTipoIVA)
        Me.pnlDtos.Controls.Add(Me.pnlSpace21)
        Me.pnlDtos.Controls.Add(Me.dtfDtoPP)
        Me.pnlDtos.Controls.Add(Me.pnlSpace22)
        Me.pnlDtos.Controls.Add(Me.dtfDTO)
        Me.pnlDtos.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlDtos.isSpace = False
        Me.pnlDtos.Location = New System.Drawing.Point(6, 70)
        Me.pnlDtos.Name = "pnlDtos"
        Me.pnlDtos.numRows = 1
        Me.pnlDtos.Reorder = True
        Me.pnlDtos.Size = New System.Drawing.Size(449, 26)
        Me.pnlDtos.TabIndex = 2
        '
        'dtfTipoIVA
        '
        Me.dtfTipoIVA.Allow_Empty = True
        Me.dtfTipoIVA.Allow_Negative = False
        Me.dtfTipoIVA.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfTipoIVA.BackColor = System.Drawing.SystemColors.Control
        Me.dtfTipoIVA.Data_Allowed = CustomControls.Datafield.List_Data.nDouble
        Me.dtfTipoIVA.DataField = "TIPOIVA"
        Me.dtfTipoIVA.DataTable = "PR1"
        Me.dtfTipoIVA.Descripcion = "Tipo IVA"
        Me.dtfTipoIVA.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfTipoIVA.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfTipoIVA.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfTipoIVA.Image = Nothing
        Me.dtfTipoIVA.Label_Space = 70
        Me.dtfTipoIVA.Length_Data = 32767
        Me.dtfTipoIVA.Location = New System.Drawing.Point(312, 0)
        Me.dtfTipoIVA.Max_Value = 100.0R
        Me.dtfTipoIVA.MensajeIncorrectoCustom = Nothing
        Me.dtfTipoIVA.Name = "dtfTipoIVA"
        Me.dtfTipoIVA.Null_on_Empty = True
        Me.dtfTipoIVA.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfTipoIVA.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfTipoIVA.ReadOnly_Data = False
        Me.dtfTipoIVA.Show_Button = False
        Me.dtfTipoIVA.Size = New System.Drawing.Size(137, 26)
        Me.dtfTipoIVA.TabIndex = 4
        Me.dtfTipoIVA.Text_Data = ""
        Me.dtfTipoIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.dtfTipoIVA.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfTipoIVA.TopPadding = 0
        Me.dtfTipoIVA.Upper_Case = False
        Me.dtfTipoIVA.Validate_on_lost_focus = True
        '
        'pnlSpace21
        '
        Me.pnlSpace21.Auto_Size = False
        Me.pnlSpace21.BackColor = System.Drawing.SystemColors.Control
        Me.pnlSpace21.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace21.ChangeDock = True
        Me.pnlSpace21.Control_Resize = False
        Me.pnlSpace21.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace21.isSpace = True
        Me.pnlSpace21.Location = New System.Drawing.Point(306, 0)
        Me.pnlSpace21.Name = "pnlSpace21"
        Me.pnlSpace21.numRows = 0
        Me.pnlSpace21.Reorder = True
        Me.pnlSpace21.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace21.TabIndex = 3
        '
        'dtfDtoPP
        '
        Me.dtfDtoPP.Allow_Empty = True
        Me.dtfDtoPP.Allow_Negative = False
        Me.dtfDtoPP.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfDtoPP.BackColor = System.Drawing.SystemColors.Control
        Me.dtfDtoPP.Data_Allowed = CustomControls.Datafield.List_Data.nDouble
        Me.dtfDtoPP.DataField = "PP"
        Me.dtfDtoPP.DataTable = "PR2"
        Me.dtfDtoPP.Descripcion = "Pronto Pago"
        Me.dtfDtoPP.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfDtoPP.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfDtoPP.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfDtoPP.Image = Nothing
        Me.dtfDtoPP.Label_Space = 85
        Me.dtfDtoPP.Length_Data = 32767
        Me.dtfDtoPP.Location = New System.Drawing.Point(156, 0)
        Me.dtfDtoPP.Max_Value = 100.0R
        Me.dtfDtoPP.MensajeIncorrectoCustom = Nothing
        Me.dtfDtoPP.Name = "dtfDtoPP"
        Me.dtfDtoPP.Null_on_Empty = True
        Me.dtfDtoPP.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfDtoPP.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfDtoPP.ReadOnly_Data = False
        Me.dtfDtoPP.Show_Button = False
        Me.dtfDtoPP.Size = New System.Drawing.Size(150, 26)
        Me.dtfDtoPP.TabIndex = 2
        Me.dtfDtoPP.Text_Data = ""
        Me.dtfDtoPP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.dtfDtoPP.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfDtoPP.TopPadding = 0
        Me.dtfDtoPP.Upper_Case = False
        Me.dtfDtoPP.Validate_on_lost_focus = True
        '
        'pnlSpace22
        '
        Me.pnlSpace22.Auto_Size = False
        Me.pnlSpace22.BackColor = System.Drawing.SystemColors.Control
        Me.pnlSpace22.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace22.ChangeDock = True
        Me.pnlSpace22.Control_Resize = False
        Me.pnlSpace22.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace22.isSpace = True
        Me.pnlSpace22.Location = New System.Drawing.Point(150, 0)
        Me.pnlSpace22.Name = "pnlSpace22"
        Me.pnlSpace22.numRows = 0
        Me.pnlSpace22.Reorder = True
        Me.pnlSpace22.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace22.TabIndex = 1
        '
        'dtfDTO
        '
        Me.dtfDTO.Allow_Empty = True
        Me.dtfDTO.Allow_Negative = False
        Me.dtfDTO.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfDTO.BackColor = System.Drawing.SystemColors.Control
        Me.dtfDTO.Data_Allowed = CustomControls.Datafield.List_Data.nDouble
        Me.dtfDTO.DataField = "DTO"
        Me.dtfDTO.DataTable = "PR2"
        Me.dtfDTO.Descripcion = "Descuento"
        Me.dtfDTO.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfDTO.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfDTO.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfDTO.Image = Nothing
        Me.dtfDTO.Label_Space = 100
        Me.dtfDTO.Length_Data = 32767
        Me.dtfDTO.Location = New System.Drawing.Point(0, 0)
        Me.dtfDTO.Max_Value = 100.0R
        Me.dtfDTO.MensajeIncorrectoCustom = Nothing
        Me.dtfDTO.Name = "dtfDTO"
        Me.dtfDTO.Null_on_Empty = True
        Me.dtfDTO.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfDTO.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfDTO.ReadOnly_Data = False
        Me.dtfDTO.Show_Button = False
        Me.dtfDTO.Size = New System.Drawing.Size(150, 26)
        Me.dtfDTO.TabIndex = 0
        Me.dtfDTO.Text_Data = "99.99"
        Me.dtfDTO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.dtfDTO.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfDTO.TopPadding = 0
        Me.dtfDTO.Upper_Case = False
        Me.dtfDTO.Validate_on_lost_focus = True
        '
        'pnlPlazosPago
        '
        Me.pnlPlazosPago.Auto_Size = False
        Me.pnlPlazosPago.BackColor = System.Drawing.SystemColors.Control
        Me.pnlPlazosPago.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlPlazosPago.ChangeDock = True
        Me.pnlPlazosPago.Control_Resize = False
        Me.pnlPlazosPago.Controls.Add(Me.dtfDiaPago3)
        Me.pnlPlazosPago.Controls.Add(Me.pnlSpace18)
        Me.pnlPlazosPago.Controls.Add(Me.dtfDiaPago2)
        Me.pnlPlazosPago.Controls.Add(Me.pnlSpace17)
        Me.pnlPlazosPago.Controls.Add(Me.dtfDiaPago)
        Me.pnlPlazosPago.Controls.Add(Me.pnlSpace16)
        Me.pnlPlazosPago.Controls.Add(Me.dtfPlazoPago3)
        Me.pnlPlazosPago.Controls.Add(Me.pnlSpace15)
        Me.pnlPlazosPago.Controls.Add(Me.dtfPlazoPago2)
        Me.pnlPlazosPago.Controls.Add(Me.pnlSpace14)
        Me.pnlPlazosPago.Controls.Add(Me.dtfPlazoPago)
        Me.pnlPlazosPago.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlPlazosPago.isSpace = False
        Me.pnlPlazosPago.Location = New System.Drawing.Point(6, 44)
        Me.pnlPlazosPago.Name = "pnlPlazosPago"
        Me.pnlPlazosPago.numRows = 1
        Me.pnlPlazosPago.Reorder = True
        Me.pnlPlazosPago.Size = New System.Drawing.Size(449, 26)
        Me.pnlPlazosPago.TabIndex = 1
        '
        'dtfDiaPago3
        '
        Me.dtfDiaPago3.Allow_Empty = True
        Me.dtfDiaPago3.Allow_Negative = False
        Me.dtfDiaPago3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfDiaPago3.BackColor = System.Drawing.SystemColors.Control
        Me.dtfDiaPago3.Data_Allowed = CustomControls.Datafield.List_Data.nInteger
        Me.dtfDiaPago3.DataField = "DIA3"
        Me.dtfDiaPago3.DataTable = "PR2"
        Me.dtfDiaPago3.Descripcion = "Dias de Pago"
        Me.dtfDiaPago3.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfDiaPago3.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfDiaPago3.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfDiaPago3.Length_Data = 32767
        Me.dtfDiaPago3.Location = New System.Drawing.Point(360, 0)
        Me.dtfDiaPago3.Max_Value = 31.0R
        Me.dtfDiaPago3.MensajeIncorrectoCustom = Nothing
        Me.dtfDiaPago3.Name = "dtfDiaPago3"
        Me.dtfDiaPago3.Null_on_Empty = True
        Me.dtfDiaPago3.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfDiaPago3.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfDiaPago3.ReadOnly_Data = False
        Me.dtfDiaPago3.Size = New System.Drawing.Size(30, 26)
        Me.dtfDiaPago3.TabIndex = 10
        Me.dtfDiaPago3.Text_Data = ""
        Me.dtfDiaPago3.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfDiaPago3.TopPadding = 0
        Me.dtfDiaPago3.Upper_Case = False
        Me.dtfDiaPago3.Validate_on_lost_focus = True
        '
        'pnlSpace18
        '
        Me.pnlSpace18.Auto_Size = False
        Me.pnlSpace18.BackColor = System.Drawing.SystemColors.Control
        Me.pnlSpace18.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace18.ChangeDock = True
        Me.pnlSpace18.Control_Resize = False
        Me.pnlSpace18.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace18.isSpace = True
        Me.pnlSpace18.Location = New System.Drawing.Point(354, 0)
        Me.pnlSpace18.Name = "pnlSpace18"
        Me.pnlSpace18.numRows = 0
        Me.pnlSpace18.Reorder = True
        Me.pnlSpace18.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace18.TabIndex = 9
        '
        'dtfDiaPago2
        '
        Me.dtfDiaPago2.Allow_Empty = True
        Me.dtfDiaPago2.Allow_Negative = False
        Me.dtfDiaPago2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfDiaPago2.BackColor = System.Drawing.SystemColors.Control
        Me.dtfDiaPago2.Data_Allowed = CustomControls.Datafield.List_Data.nInteger
        Me.dtfDiaPago2.DataField = "DIA2"
        Me.dtfDiaPago2.DataTable = "PR2"
        Me.dtfDiaPago2.Descripcion = "Dias de Pago"
        Me.dtfDiaPago2.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfDiaPago2.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfDiaPago2.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfDiaPago2.Length_Data = 32767
        Me.dtfDiaPago2.Location = New System.Drawing.Point(324, 0)
        Me.dtfDiaPago2.Max_Value = 31.0R
        Me.dtfDiaPago2.MensajeIncorrectoCustom = Nothing
        Me.dtfDiaPago2.Name = "dtfDiaPago2"
        Me.dtfDiaPago2.Null_on_Empty = True
        Me.dtfDiaPago2.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfDiaPago2.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfDiaPago2.ReadOnly_Data = False
        Me.dtfDiaPago2.Size = New System.Drawing.Size(30, 26)
        Me.dtfDiaPago2.TabIndex = 8
        Me.dtfDiaPago2.Text_Data = ""
        Me.dtfDiaPago2.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfDiaPago2.TopPadding = 0
        Me.dtfDiaPago2.Upper_Case = False
        Me.dtfDiaPago2.Validate_on_lost_focus = True
        '
        'pnlSpace17
        '
        Me.pnlSpace17.Auto_Size = False
        Me.pnlSpace17.BackColor = System.Drawing.SystemColors.Control
        Me.pnlSpace17.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace17.ChangeDock = True
        Me.pnlSpace17.Control_Resize = False
        Me.pnlSpace17.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace17.isSpace = True
        Me.pnlSpace17.Location = New System.Drawing.Point(318, 0)
        Me.pnlSpace17.Name = "pnlSpace17"
        Me.pnlSpace17.numRows = 0
        Me.pnlSpace17.Reorder = True
        Me.pnlSpace17.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace17.TabIndex = 7
        '
        'dtfDiaPago
        '
        Me.dtfDiaPago.Allow_Empty = True
        Me.dtfDiaPago.Allow_Negative = False
        Me.dtfDiaPago.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfDiaPago.BackColor = System.Drawing.SystemColors.Control
        Me.dtfDiaPago.Data_Allowed = CustomControls.Datafield.List_Data.nInteger
        Me.dtfDiaPago.DataField = "DIA"
        Me.dtfDiaPago.DataTable = "PR2"
        Me.dtfDiaPago.Descripcion = "Dias de Pago"
        Me.dtfDiaPago.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfDiaPago.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfDiaPago.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfDiaPago.Image = Nothing
        Me.dtfDiaPago.Label_Space = 80
        Me.dtfDiaPago.Length_Data = 32767
        Me.dtfDiaPago.Location = New System.Drawing.Point(208, 0)
        Me.dtfDiaPago.Max_Value = 31.0R
        Me.dtfDiaPago.MensajeIncorrectoCustom = Nothing
        Me.dtfDiaPago.Name = "dtfDiaPago"
        Me.dtfDiaPago.Null_on_Empty = True
        Me.dtfDiaPago.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfDiaPago.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfDiaPago.ReadOnly_Data = False
        Me.dtfDiaPago.Show_Button = False
        Me.dtfDiaPago.Size = New System.Drawing.Size(110, 26)
        Me.dtfDiaPago.TabIndex = 6
        Me.dtfDiaPago.Text_Data = ""
        Me.dtfDiaPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfDiaPago.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfDiaPago.TopPadding = 0
        Me.dtfDiaPago.Upper_Case = False
        Me.dtfDiaPago.Validate_on_lost_focus = True
        '
        'pnlSpace16
        '
        Me.pnlSpace16.Auto_Size = False
        Me.pnlSpace16.BackColor = System.Drawing.SystemColors.Control
        Me.pnlSpace16.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace16.ChangeDock = True
        Me.pnlSpace16.Control_Resize = False
        Me.pnlSpace16.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace16.isSpace = True
        Me.pnlSpace16.Location = New System.Drawing.Point(202, 0)
        Me.pnlSpace16.Name = "pnlSpace16"
        Me.pnlSpace16.numRows = 0
        Me.pnlSpace16.Reorder = True
        Me.pnlSpace16.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace16.TabIndex = 5
        '
        'dtfPlazoPago3
        '
        Me.dtfPlazoPago3.Allow_Empty = True
        Me.dtfPlazoPago3.Allow_Negative = False
        Me.dtfPlazoPago3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfPlazoPago3.BackColor = System.Drawing.SystemColors.Control
        Me.dtfPlazoPago3.Data_Allowed = CustomControls.Datafield.List_Data.nInteger
        Me.dtfPlazoPago3.DataField = "PLAZO3"
        Me.dtfPlazoPago3.DataTable = "PR2"
        Me.dtfPlazoPago3.Descripcion = "Plazo de Pago"
        Me.dtfPlazoPago3.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfPlazoPago3.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfPlazoPago3.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfPlazoPago3.Length_Data = 32767
        Me.dtfPlazoPago3.Location = New System.Drawing.Point(172, 0)
        Me.dtfPlazoPago3.Max_Value = 31.0R
        Me.dtfPlazoPago3.MensajeIncorrectoCustom = Nothing
        Me.dtfPlazoPago3.Name = "dtfPlazoPago3"
        Me.dtfPlazoPago3.Null_on_Empty = True
        Me.dtfPlazoPago3.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfPlazoPago3.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfPlazoPago3.ReadOnly_Data = False
        Me.dtfPlazoPago3.Size = New System.Drawing.Size(30, 26)
        Me.dtfPlazoPago3.TabIndex = 4
        Me.dtfPlazoPago3.Text_Data = ""
        Me.dtfPlazoPago3.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfPlazoPago3.TopPadding = 0
        Me.dtfPlazoPago3.Upper_Case = False
        Me.dtfPlazoPago3.Validate_on_lost_focus = True
        '
        'pnlSpace15
        '
        Me.pnlSpace15.Auto_Size = False
        Me.pnlSpace15.BackColor = System.Drawing.SystemColors.Control
        Me.pnlSpace15.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace15.ChangeDock = True
        Me.pnlSpace15.Control_Resize = False
        Me.pnlSpace15.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace15.isSpace = True
        Me.pnlSpace15.Location = New System.Drawing.Point(166, 0)
        Me.pnlSpace15.Name = "pnlSpace15"
        Me.pnlSpace15.numRows = 0
        Me.pnlSpace15.Reorder = True
        Me.pnlSpace15.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace15.TabIndex = 3
        '
        'dtfPlazoPago2
        '
        Me.dtfPlazoPago2.Allow_Empty = True
        Me.dtfPlazoPago2.Allow_Negative = False
        Me.dtfPlazoPago2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfPlazoPago2.BackColor = System.Drawing.SystemColors.Control
        Me.dtfPlazoPago2.Data_Allowed = CustomControls.Datafield.List_Data.nInteger
        Me.dtfPlazoPago2.DataField = "PLAZO2"
        Me.dtfPlazoPago2.DataTable = "PR2"
        Me.dtfPlazoPago2.Descripcion = "Plazo de Pago"
        Me.dtfPlazoPago2.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfPlazoPago2.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfPlazoPago2.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfPlazoPago2.Length_Data = 32767
        Me.dtfPlazoPago2.Location = New System.Drawing.Point(136, 0)
        Me.dtfPlazoPago2.Max_Value = 31.0R
        Me.dtfPlazoPago2.MensajeIncorrectoCustom = Nothing
        Me.dtfPlazoPago2.Name = "dtfPlazoPago2"
        Me.dtfPlazoPago2.Null_on_Empty = True
        Me.dtfPlazoPago2.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfPlazoPago2.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfPlazoPago2.ReadOnly_Data = False
        Me.dtfPlazoPago2.Size = New System.Drawing.Size(30, 26)
        Me.dtfPlazoPago2.TabIndex = 2
        Me.dtfPlazoPago2.Text_Data = ""
        Me.dtfPlazoPago2.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfPlazoPago2.TopPadding = 0
        Me.dtfPlazoPago2.Upper_Case = False
        Me.dtfPlazoPago2.Validate_on_lost_focus = True
        '
        'pnlSpace14
        '
        Me.pnlSpace14.Auto_Size = False
        Me.pnlSpace14.BackColor = System.Drawing.SystemColors.Control
        Me.pnlSpace14.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace14.ChangeDock = True
        Me.pnlSpace14.Control_Resize = False
        Me.pnlSpace14.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace14.isSpace = True
        Me.pnlSpace14.Location = New System.Drawing.Point(130, 0)
        Me.pnlSpace14.Name = "pnlSpace14"
        Me.pnlSpace14.numRows = 0
        Me.pnlSpace14.Reorder = True
        Me.pnlSpace14.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace14.TabIndex = 1
        '
        'dtfPlazoPago
        '
        Me.dtfPlazoPago.Allow_Empty = True
        Me.dtfPlazoPago.Allow_Negative = False
        Me.dtfPlazoPago.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfPlazoPago.BackColor = System.Drawing.SystemColors.Control
        Me.dtfPlazoPago.Data_Allowed = CustomControls.Datafield.List_Data.nInteger
        Me.dtfPlazoPago.DataField = "PLAZO"
        Me.dtfPlazoPago.DataTable = "PR2"
        Me.dtfPlazoPago.Descripcion = "Plazo de Pago"
        Me.dtfPlazoPago.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfPlazoPago.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfPlazoPago.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfPlazoPago.Image = Nothing
        Me.dtfPlazoPago.Label_Space = 100
        Me.dtfPlazoPago.Length_Data = 32767
        Me.dtfPlazoPago.Location = New System.Drawing.Point(0, 0)
        Me.dtfPlazoPago.Max_Value = 0.0R
        Me.dtfPlazoPago.MensajeIncorrectoCustom = Nothing
        Me.dtfPlazoPago.Name = "dtfPlazoPago"
        Me.dtfPlazoPago.Null_on_Empty = True
        Me.dtfPlazoPago.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfPlazoPago.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfPlazoPago.ReadOnly_Data = False
        Me.dtfPlazoPago.Show_Button = False
        Me.dtfPlazoPago.Size = New System.Drawing.Size(130, 26)
        Me.dtfPlazoPago.TabIndex = 0
        Me.dtfPlazoPago.Text_Data = ""
        Me.dtfPlazoPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfPlazoPago.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfPlazoPago.TopPadding = 0
        Me.dtfPlazoPago.Upper_Case = False
        Me.dtfPlazoPago.Validate_on_lost_focus = True
        '
        'dftFormaPago
        '
        Me.dftFormaPago.Allow_Empty = True
        Me.dftFormaPago.Allow_Negative = True
        Me.dftFormaPago.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dftFormaPago.BackColor = System.Drawing.SystemColors.Control
        Me.dftFormaPago.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dftFormaPago.DataField = "FORPA"
        Me.dftFormaPago.DataTable = "PR2"
        Me.dftFormaPago.DB = Connection18
        Me.dftFormaPago.Desc_Datafield = "NOMBRE"
        Me.dftFormaPago.Desc_DBPK = "CODIGO"
        Me.dftFormaPago.Desc_DBTable = "FORMAS"
        Me.dftFormaPago.Desc_Where = Nothing
        Me.dftFormaPago.Desc_WhereObligatoria = Nothing
        Me.dftFormaPago.Descripcion = "Forma de Pago"
        Me.dftFormaPago.Dock = System.Windows.Forms.DockStyle.Top
        Me.dftFormaPago.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dftFormaPago.ExtraSQL = ""
        Me.dftFormaPago.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dftFormaPago.Formulario = Nothing
        Me.dftFormaPago.Label_Space = 100
        Me.dftFormaPago.Length_Data = 32767
        Me.dftFormaPago.Location = New System.Drawing.Point(6, 18)
        Me.dftFormaPago.Lupa = Nothing
        Me.dftFormaPago.Max_Value = 0.0R
        Me.dftFormaPago.MensajeIncorrectoCustom = Nothing
        Me.dftFormaPago.Name = "dftFormaPago"
        Me.dftFormaPago.Null_on_Empty = True
        Me.dftFormaPago.OpenForm = Nothing
        Me.dftFormaPago.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dftFormaPago.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dftFormaPago.Query_on_Text_Changed = True
        Me.dftFormaPago.ReadOnly_Data = False
        Me.dftFormaPago.ShowButton = True
        Me.dftFormaPago.Size = New System.Drawing.Size(449, 26)
        Me.dftFormaPago.TabIndex = 0
        Me.dftFormaPago.Text_Data = ""
        Me.dftFormaPago.Text_Data_Desc = ""
        Me.dftFormaPago.Text_Width = 66
        Me.dftFormaPago.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dftFormaPago.TopPadding = 0
        Me.dftFormaPago.Upper_Case = False
        Me.dftFormaPago.Validate_on_lost_focus = True
        '
        'pnlFacContaS
        '
        Me.pnlFacContaS.Auto_Size = False
        Me.pnlFacContaS.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.pnlFacContaS.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlFacContaS.ChangeDock = False
        Me.pnlFacContaS.Control_Resize = False
        Me.pnlFacContaS.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFacContaS.isSpace = False
        Me.pnlFacContaS.Location = New System.Drawing.Point(0, 0)
        Me.pnlFacContaS.Name = "pnlFacContaS"
        Me.pnlFacContaS.numRows = 0
        Me.pnlFacContaS.Reorder = True
        Me.pnlFacContaS.Size = New System.Drawing.Size(933, 67)
        Me.pnlFacContaS.TabIndex = 5
        '
        'pvpDelegaciones
        '
        Me.pvpDelegaciones.Controls.Add(Me.dgvDelegacion)
        Me.pvpDelegaciones.Controls.Add(Me.pnlDelegaS)
        Me.pvpDelegaciones.ItemSize = New System.Drawing.SizeF(106.0!, 23.0!)
        Me.pvpDelegaciones.Location = New System.Drawing.Point(129, 5)
        Me.pvpDelegaciones.Name = "pvpDelegaciones"
        Me.pvpDelegaciones.PanelCabezeraContainer = Me.pnlDelegaS
        Me.pvpDelegaciones.Size = New System.Drawing.Size(933, 518)
        Me.pvpDelegaciones.Text = "Delegaciones"
        '
        'dgvDelegacion
        '
        Me.dgvDelegacion.ColRel = Nothing
        Me.dgvDelegacion.ColSelectFilter = Nothing
        Me.dgvDelegacion.DataGridType = CustomControls.DataGrid.GridType.Edit
        Me.dgvDelegacion.DBConnection = Nothing
        Me.dgvDelegacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDelegacion.idRel = Nothing
        Me.dgvDelegacion.Location = New System.Drawing.Point(0, 54)
        Me.dgvDelegacion.MarcarFilas = False
        '
        'dgvDelegacion
        '
        Me.dgvDelegacion.MasterTemplate.EnableFiltering = True
        Me.dgvDelegacion.MasterTemplate.MultiSelect = True
        Me.dgvDelegacion.MasterTemplate.SelectionMode = Telerik.WinControls.UI.GridViewSelectionMode.CellSelect
        Me.dgvDelegacion.Name = "dgvDelegacion"
        Me.dgvDelegacion.Size = New System.Drawing.Size(933, 464)
        Me.dgvDelegacion.TabIndex = 0
        Me.dgvDelegacion.TablaEdit = Nothing
        Me.dgvDelegacion.Text = "GridDelegacion1"
        Me.dgvDelegacion.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dgvDelegacion.ThemeName = "TelerikMetroBlue"
        '
        'pnlDelegaS
        '
        Me.pnlDelegaS.Auto_Size = False
        Me.pnlDelegaS.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.pnlDelegaS.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlDelegaS.ChangeDock = False
        Me.pnlDelegaS.Control_Resize = False
        Me.pnlDelegaS.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlDelegaS.isSpace = False
        Me.pnlDelegaS.Location = New System.Drawing.Point(0, 0)
        Me.pnlDelegaS.Name = "pnlDelegaS"
        Me.pnlDelegaS.numRows = 0
        Me.pnlDelegaS.Reorder = True
        Me.pnlDelegaS.Size = New System.Drawing.Size(933, 54)
        Me.pnlDelegaS.TabIndex = 5
        '
        'pvpContactos
        '
        Me.pvpContactos.Controls.Add(Me.dgvContactos)
        Me.pvpContactos.Controls.Add(Me.pnlContactosS)
        Me.pvpContactos.ItemSize = New System.Drawing.SizeF(106.0!, 23.0!)
        Me.pvpContactos.Location = New System.Drawing.Point(129, 5)
        Me.pvpContactos.Name = "pvpContactos"
        Me.pvpContactos.PanelCabezeraContainer = Me.pnlContactosS
        Me.pvpContactos.Size = New System.Drawing.Size(933, 518)
        Me.pvpContactos.Text = "Contactos"
        '
        'dgvContactos
        '
        Me.dgvContactos.ColRel = Nothing
        Me.dgvContactos.ColSelectFilter = Nothing
        Me.dgvContactos.DataGridType = CustomControls.DataGrid.GridType.Edit
        Me.dgvContactos.DBConnection = Nothing
        Me.dgvContactos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvContactos.idRel = Nothing
        Me.dgvContactos.Location = New System.Drawing.Point(0, 54)
        Me.dgvContactos.MarcarFilas = False
        '
        'dgvContactos
        '
        Me.dgvContactos.MasterTemplate.EnableFiltering = True
        Me.dgvContactos.MasterTemplate.MultiSelect = True
        Me.dgvContactos.MasterTemplate.SelectionMode = Telerik.WinControls.UI.GridViewSelectionMode.CellSelect
        Me.dgvContactos.Name = "dgvContactos"
        Me.dgvContactos.Size = New System.Drawing.Size(933, 464)
        Me.dgvContactos.TabIndex = 0
        Me.dgvContactos.TablaEdit = Nothing
        Me.dgvContactos.Text = "GridContactos1"
        Me.dgvContactos.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dgvContactos.ThemeName = "TelerikMetroBlue"
        '
        'pnlContactosS
        '
        Me.pnlContactosS.Auto_Size = False
        Me.pnlContactosS.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.pnlContactosS.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlContactosS.ChangeDock = False
        Me.pnlContactosS.Control_Resize = False
        Me.pnlContactosS.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlContactosS.isSpace = False
        Me.pnlContactosS.Location = New System.Drawing.Point(0, 0)
        Me.pnlContactosS.Name = "pnlContactosS"
        Me.pnlContactosS.numRows = 0
        Me.pnlContactosS.Reorder = True
        Me.pnlContactosS.Size = New System.Drawing.Size(933, 54)
        Me.pnlContactosS.TabIndex = 5
        '
        'pvpAcumulados
        '
        Me.pvpAcumulados.Controls.Add(Me.pnlAcumS)
        Me.pvpAcumulados.ItemSize = New System.Drawing.SizeF(106.0!, 23.0!)
        Me.pvpAcumulados.Location = New System.Drawing.Point(129, 5)
        Me.pvpAcumulados.Name = "pvpAcumulados"
        Me.pvpAcumulados.PanelCabezeraContainer = Me.pnlAcumS
        Me.pvpAcumulados.Size = New System.Drawing.Size(933, 518)
        Me.pvpAcumulados.Text = "Acumulados"
        '
        'pnlAcumS
        '
        Me.pnlAcumS.Auto_Size = False
        Me.pnlAcumS.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.pnlAcumS.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlAcumS.ChangeDock = False
        Me.pnlAcumS.Control_Resize = False
        Me.pnlAcumS.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlAcumS.isSpace = False
        Me.pnlAcumS.Location = New System.Drawing.Point(0, 0)
        Me.pnlAcumS.Name = "pnlAcumS"
        Me.pnlAcumS.numRows = 0
        Me.pnlAcumS.Reorder = True
        Me.pnlAcumS.Size = New System.Drawing.Size(933, 54)
        Me.pnlAcumS.TabIndex = 6
        '
        'pvpVisitas
        '
        Me.pvpVisitas.Controls.Add(Me.pnlVisitasS)
        Me.pvpVisitas.ItemSize = New System.Drawing.SizeF(106.0!, 23.0!)
        Me.pvpVisitas.Location = New System.Drawing.Point(129, 5)
        Me.pvpVisitas.Name = "pvpVisitas"
        Me.pvpVisitas.PanelCabezeraContainer = Me.pnlVisitasS
        Me.pvpVisitas.Size = New System.Drawing.Size(933, 518)
        Me.pvpVisitas.Text = "Visitas"
        '
        'pnlVisitasS
        '
        Me.pnlVisitasS.Auto_Size = False
        Me.pnlVisitasS.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.pnlVisitasS.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlVisitasS.ChangeDock = False
        Me.pnlVisitasS.Control_Resize = False
        Me.pnlVisitasS.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlVisitasS.isSpace = False
        Me.pnlVisitasS.Location = New System.Drawing.Point(0, 0)
        Me.pnlVisitasS.Name = "pnlVisitasS"
        Me.pnlVisitasS.numRows = 0
        Me.pnlVisitasS.Reorder = True
        Me.pnlVisitasS.Size = New System.Drawing.Size(933, 54)
        Me.pnlVisitasS.TabIndex = 5
        '
        'pvpDirecciones
        '
        Me.pvpDirecciones.AutoScroll = True
        Me.pvpDirecciones.Controls.Add(Me.pnlDireccDer)
        Me.pvpDirecciones.Controls.Add(Me.pnlDireccIzq)
        Me.pvpDirecciones.Controls.Add(Me.pnlDirS)
        Me.pvpDirecciones.ItemSize = New System.Drawing.SizeF(106.0!, 23.0!)
        Me.pvpDirecciones.Location = New System.Drawing.Point(129, 5)
        Me.pvpDirecciones.Name = "pvpDirecciones"
        Me.pvpDirecciones.PanelCabezeraContainer = Me.pnlDirS
        Me.pvpDirecciones.Size = New System.Drawing.Size(933, 518)
        Me.pvpDirecciones.Text = "Direcciones"
        '
        'pnlDireccDer
        '
        Me.pnlDireccDer.Auto_Size = False
        Me.pnlDireccDer.BackColor = System.Drawing.SystemColors.Control
        Me.pnlDireccDer.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlDireccDer.ChangeDock = True
        Me.pnlDireccDer.Control_Resize = False
        Me.pnlDireccDer.Controls.Add(Me.gbxDireDevo)
        Me.pnlDireccDer.Controls.Add(Me.gbxDirReclama)
        Me.pnlDireccDer.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlDireccDer.isSpace = False
        Me.pnlDireccDer.Location = New System.Drawing.Point(467, 54)
        Me.pnlDireccDer.MinimumSize = New System.Drawing.Size(467, 0)
        Me.pnlDireccDer.Name = "pnlDireccDer"
        Me.pnlDireccDer.numRows = 0
        Me.pnlDireccDer.Padding = New System.Windows.Forms.Padding(3)
        Me.pnlDireccDer.Reorder = True
        '
        '
        '
        Me.pnlDireccDer.RootElement.MinSize = New System.Drawing.Size(467, 0)
        Me.pnlDireccDer.Size = New System.Drawing.Size(467, 447)
        Me.pnlDireccDer.TabIndex = 2
        '
        'gbxDireDevo
        '
        Me.gbxDireDevo.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.gbxDireDevo.Controls.Add(Me.dtfEmailDevo)
        Me.gbxDireDevo.Controls.Add(Me.dtfPersonaDevo)
        Me.gbxDireDevo.Controls.Add(Me.pnlTelfDevo)
        Me.gbxDireDevo.Controls.Add(Me.dtdDevo)
        Me.gbxDireDevo.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbxDireDevo.HeaderText = "Dirección de Devolución"
        Me.gbxDireDevo.Location = New System.Drawing.Point(3, 230)
        Me.gbxDireDevo.Name = "gbxDireDevo"
        Me.gbxDireDevo.numRows = 8
        Me.gbxDireDevo.Padding = New System.Windows.Forms.Padding(6, 18, 6, 6)
        Me.gbxDireDevo.Reorder = True
        Me.gbxDireDevo.Size = New System.Drawing.Size(461, 227)
        Me.gbxDireDevo.TabIndex = 1
        Me.gbxDireDevo.Text = "Dirección de Devolución"
        Me.gbxDireDevo.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.gbxDireDevo.ThemeName = "Windows8"
        Me.gbxDireDevo.Title = "Dirección de Devolución"
        '
        'dtfEmailDevo
        '
        Me.dtfEmailDevo.Allow_Empty = True
        Me.dtfEmailDevo.Allow_Negative = True
        Me.dtfEmailDevo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfEmailDevo.BackColor = System.Drawing.SystemColors.Control
        Me.dtfEmailDevo.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfEmailDevo.DataField = "MAIL_DEVO"
        Me.dtfEmailDevo.DataTable = "PR1"
        Me.dtfEmailDevo.Descripcion = "Email"
        Me.dtfEmailDevo.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfEmailDevo.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfEmailDevo.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfEmailDevo.Image = Nothing
        Me.dtfEmailDevo.Label_Space = 75
        Me.dtfEmailDevo.Length_Data = 32767
        Me.dtfEmailDevo.Location = New System.Drawing.Point(6, 200)
        Me.dtfEmailDevo.Max_Value = 0.0R
        Me.dtfEmailDevo.MensajeIncorrectoCustom = Nothing
        Me.dtfEmailDevo.Name = "dtfEmailDevo"
        Me.dtfEmailDevo.Null_on_Empty = True
        Me.dtfEmailDevo.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfEmailDevo.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfEmailDevo.ReadOnly_Data = False
        Me.dtfEmailDevo.Show_Button = False
        Me.dtfEmailDevo.Size = New System.Drawing.Size(449, 26)
        Me.dtfEmailDevo.TabIndex = 3
        Me.dtfEmailDevo.Text_Data = ""
        Me.dtfEmailDevo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfEmailDevo.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfEmailDevo.TopPadding = 0
        Me.dtfEmailDevo.Upper_Case = False
        Me.dtfEmailDevo.Validate_on_lost_focus = True
        '
        'dtfPersonaDevo
        '
        Me.dtfPersonaDevo.Allow_Empty = True
        Me.dtfPersonaDevo.Allow_Negative = True
        Me.dtfPersonaDevo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfPersonaDevo.BackColor = System.Drawing.SystemColors.Control
        Me.dtfPersonaDevo.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfPersonaDevo.DataField = "PERSONA_DEVO"
        Me.dtfPersonaDevo.DataTable = "PR1"
        Me.dtfPersonaDevo.Descripcion = "Persona"
        Me.dtfPersonaDevo.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfPersonaDevo.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfPersonaDevo.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfPersonaDevo.Image = Nothing
        Me.dtfPersonaDevo.Label_Space = 75
        Me.dtfPersonaDevo.Length_Data = 32767
        Me.dtfPersonaDevo.Location = New System.Drawing.Point(6, 174)
        Me.dtfPersonaDevo.Max_Value = 0.0R
        Me.dtfPersonaDevo.MensajeIncorrectoCustom = Nothing
        Me.dtfPersonaDevo.Name = "dtfPersonaDevo"
        Me.dtfPersonaDevo.Null_on_Empty = True
        Me.dtfPersonaDevo.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfPersonaDevo.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfPersonaDevo.ReadOnly_Data = False
        Me.dtfPersonaDevo.Show_Button = False
        Me.dtfPersonaDevo.Size = New System.Drawing.Size(449, 26)
        Me.dtfPersonaDevo.TabIndex = 2
        Me.dtfPersonaDevo.Text_Data = ""
        Me.dtfPersonaDevo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfPersonaDevo.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfPersonaDevo.TopPadding = 0
        Me.dtfPersonaDevo.Upper_Case = False
        Me.dtfPersonaDevo.Validate_on_lost_focus = True
        '
        'pnlTelfDevo
        '
        Me.pnlTelfDevo.Auto_Size = False
        Me.pnlTelfDevo.BackColor = System.Drawing.SystemColors.Control
        Me.pnlTelfDevo.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlTelfDevo.ChangeDock = True
        Me.pnlTelfDevo.Control_Resize = False
        Me.pnlTelfDevo.Controls.Add(Me.dtfTelfDevo)
        Me.pnlTelfDevo.Controls.Add(Me.pnlSpace8)
        Me.pnlTelfDevo.Controls.Add(Me.dtfFaxDevo)
        Me.pnlTelfDevo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTelfDevo.isSpace = False
        Me.pnlTelfDevo.Location = New System.Drawing.Point(6, 148)
        Me.pnlTelfDevo.Name = "pnlTelfDevo"
        Me.pnlTelfDevo.numRows = 1
        Me.pnlTelfDevo.Reorder = True
        Me.pnlTelfDevo.Size = New System.Drawing.Size(449, 26)
        Me.pnlTelfDevo.TabIndex = 1
        '
        'dtfTelfDevo
        '
        Me.dtfTelfDevo.Allow_Empty = True
        Me.dtfTelfDevo.Allow_Negative = True
        Me.dtfTelfDevo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfTelfDevo.BackColor = System.Drawing.SystemColors.Control
        Me.dtfTelfDevo.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfTelfDevo.DataField = "TELF_DEVO"
        Me.dtfTelfDevo.DataTable = "PR1"
        Me.dtfTelfDevo.Descripcion = "Telefonos"
        Me.dtfTelfDevo.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfTelfDevo.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfTelfDevo.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfTelfDevo.Image = Nothing
        Me.dtfTelfDevo.Label_Space = 75
        Me.dtfTelfDevo.Length_Data = 32767
        Me.dtfTelfDevo.Location = New System.Drawing.Point(0, 0)
        Me.dtfTelfDevo.Max_Value = 0.0R
        Me.dtfTelfDevo.MensajeIncorrectoCustom = Nothing
        Me.dtfTelfDevo.Name = "dtfTelfDevo"
        Me.dtfTelfDevo.Null_on_Empty = True
        Me.dtfTelfDevo.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfTelfDevo.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfTelfDevo.ReadOnly_Data = False
        Me.dtfTelfDevo.Show_Button = False
        Me.dtfTelfDevo.Size = New System.Drawing.Size(243, 26)
        Me.dtfTelfDevo.TabIndex = 0
        Me.dtfTelfDevo.Text_Data = ""
        Me.dtfTelfDevo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfTelfDevo.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfTelfDevo.TopPadding = 0
        Me.dtfTelfDevo.Upper_Case = False
        Me.dtfTelfDevo.Validate_on_lost_focus = True
        '
        'pnlSpace8
        '
        Me.pnlSpace8.Auto_Size = False
        Me.pnlSpace8.BackColor = System.Drawing.SystemColors.Control
        Me.pnlSpace8.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace8.ChangeDock = True
        Me.pnlSpace8.Control_Resize = False
        Me.pnlSpace8.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSpace8.isSpace = True
        Me.pnlSpace8.Location = New System.Drawing.Point(243, 0)
        Me.pnlSpace8.Name = "pnlSpace8"
        Me.pnlSpace8.numRows = 0
        Me.pnlSpace8.Reorder = False
        Me.pnlSpace8.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace8.TabIndex = 1
        '
        'dtfFaxDevo
        '
        Me.dtfFaxDevo.Allow_Empty = True
        Me.dtfFaxDevo.Allow_Negative = True
        Me.dtfFaxDevo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfFaxDevo.BackColor = System.Drawing.SystemColors.Control
        Me.dtfFaxDevo.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfFaxDevo.DataField = "FAX_DEVO"
        Me.dtfFaxDevo.DataTable = "PR1"
        Me.dtfFaxDevo.Descripcion = "Fax"
        Me.dtfFaxDevo.Dock = System.Windows.Forms.DockStyle.Right
        Me.dtfFaxDevo.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfFaxDevo.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfFaxDevo.Image = Nothing
        Me.dtfFaxDevo.Label_Space = 40
        Me.dtfFaxDevo.Length_Data = 32767
        Me.dtfFaxDevo.Location = New System.Drawing.Point(249, 0)
        Me.dtfFaxDevo.Max_Value = 0.0R
        Me.dtfFaxDevo.MensajeIncorrectoCustom = Nothing
        Me.dtfFaxDevo.Name = "dtfFaxDevo"
        Me.dtfFaxDevo.Null_on_Empty = True
        Me.dtfFaxDevo.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfFaxDevo.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfFaxDevo.ReadOnly_Data = False
        Me.dtfFaxDevo.Show_Button = False
        Me.dtfFaxDevo.Size = New System.Drawing.Size(200, 26)
        Me.dtfFaxDevo.TabIndex = 2
        Me.dtfFaxDevo.Text_Data = ""
        Me.dtfFaxDevo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfFaxDevo.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfFaxDevo.TopPadding = 0
        Me.dtfFaxDevo.Upper_Case = False
        Me.dtfFaxDevo.Validate_on_lost_focus = True
        '
        'dtdDevo
        '
        Me.dtdDevo.AutoSize = True
        Me.dtdDevo.Datafield_CP = "CP_DEVO"
        Me.dtdDevo.Datafield_Direccion = "DIR_DEVO"
        Me.dtdDevo.Datafield_Direccion2L = "DIR2_DEVO"
        Me.dtdDevo.Datafield_GPS = ""
        Me.dtdDevo.Datafield_Pais = "PAIS_DEVO"
        Me.dtdDevo.Datafield_Poblacion = "POB_DEVO"
        Me.dtdDevo.Datafield_Provincia = "PROV_DEVO"
        Me.dtdDevo.Datatable_CP = "PR1"
        Me.dtdDevo.Datatable_Direccion = "PR1"
        Me.dtdDevo.Datatable_Direccion2L = "PR1"
        Me.dtdDevo.Datatable_GPS = ""
        Me.dtdDevo.Datatable_Pais = "PR1"
        Me.dtdDevo.Datatable_Poblacion = "PR1"
        Me.dtdDevo.Datatable_Provincia = "PR1"
        Me.dtdDevo.Descripcion = Nothing
        Me.dtdDevo.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtdDevo.Label_Space = 75
        Me.dtdDevo.Location = New System.Drawing.Point(6, 18)
        Me.dtdDevo.Name = "dtdDevo"
        Me.dtdDevo.ReadOnly_Data = False
        Me.dtdDevo.requeryCP = False
        Me.dtdDevo.Show_Dir2L = True
        Me.dtdDevo.Show_GPS = False
        Me.dtdDevo.Size = New System.Drawing.Size(449, 130)
        Me.dtdDevo.TabIndex = 0
        Me.dtdDevo.Text_Data_CP = ""
        Me.dtdDevo.Text_Data_Direccion = ""
        Me.dtdDevo.Text_Data_Direccion2L = ""
        Me.dtdDevo.Text_Data_GPS = ""
        Me.dtdDevo.Text_Data_Pais = ""
        Me.dtdDevo.Text_Data_Poblacion = ""
        Me.dtdDevo.Text_Data_Provincia = ""
        '
        'gbxDirReclama
        '
        Me.gbxDirReclama.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.gbxDirReclama.Controls.Add(Me.dtfEmailReclama)
        Me.gbxDirReclama.Controls.Add(Me.dtfPersonaReclama)
        Me.gbxDirReclama.Controls.Add(Me.pnlTelfReclama)
        Me.gbxDirReclama.Controls.Add(Me.dtdReclama)
        Me.gbxDirReclama.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbxDirReclama.HeaderText = "Dirección de Reclamaciones"
        Me.gbxDirReclama.Location = New System.Drawing.Point(3, 3)
        Me.gbxDirReclama.Name = "gbxDirReclama"
        Me.gbxDirReclama.numRows = 8
        Me.gbxDirReclama.Padding = New System.Windows.Forms.Padding(6, 18, 6, 6)
        Me.gbxDirReclama.Reorder = True
        Me.gbxDirReclama.Size = New System.Drawing.Size(461, 227)
        Me.gbxDirReclama.TabIndex = 0
        Me.gbxDirReclama.Text = "Dirección de Reclamaciones"
        Me.gbxDirReclama.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.gbxDirReclama.ThemeName = "Windows8"
        Me.gbxDirReclama.Title = "Dirección de Reclamaciones"
        '
        'dtfEmailReclama
        '
        Me.dtfEmailReclama.Allow_Empty = True
        Me.dtfEmailReclama.Allow_Negative = True
        Me.dtfEmailReclama.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfEmailReclama.BackColor = System.Drawing.SystemColors.Control
        Me.dtfEmailReclama.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfEmailReclama.DataField = "MAIL_RECLAMA"
        Me.dtfEmailReclama.DataTable = "PR1"
        Me.dtfEmailReclama.Descripcion = "Email"
        Me.dtfEmailReclama.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfEmailReclama.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfEmailReclama.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfEmailReclama.Image = Nothing
        Me.dtfEmailReclama.Label_Space = 75
        Me.dtfEmailReclama.Length_Data = 32767
        Me.dtfEmailReclama.Location = New System.Drawing.Point(6, 200)
        Me.dtfEmailReclama.Max_Value = 0.0R
        Me.dtfEmailReclama.MensajeIncorrectoCustom = Nothing
        Me.dtfEmailReclama.Name = "dtfEmailReclama"
        Me.dtfEmailReclama.Null_on_Empty = True
        Me.dtfEmailReclama.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfEmailReclama.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfEmailReclama.ReadOnly_Data = False
        Me.dtfEmailReclama.Show_Button = False
        Me.dtfEmailReclama.Size = New System.Drawing.Size(449, 26)
        Me.dtfEmailReclama.TabIndex = 3
        Me.dtfEmailReclama.Text_Data = ""
        Me.dtfEmailReclama.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfEmailReclama.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfEmailReclama.TopPadding = 0
        Me.dtfEmailReclama.Upper_Case = False
        Me.dtfEmailReclama.Validate_on_lost_focus = True
        '
        'dtfPersonaReclama
        '
        Me.dtfPersonaReclama.Allow_Empty = True
        Me.dtfPersonaReclama.Allow_Negative = True
        Me.dtfPersonaReclama.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfPersonaReclama.BackColor = System.Drawing.SystemColors.Control
        Me.dtfPersonaReclama.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfPersonaReclama.DataField = "PERSONA_RECLAMA"
        Me.dtfPersonaReclama.DataTable = "PR1"
        Me.dtfPersonaReclama.Descripcion = "Persona"
        Me.dtfPersonaReclama.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfPersonaReclama.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfPersonaReclama.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfPersonaReclama.Image = Nothing
        Me.dtfPersonaReclama.Label_Space = 75
        Me.dtfPersonaReclama.Length_Data = 32767
        Me.dtfPersonaReclama.Location = New System.Drawing.Point(6, 174)
        Me.dtfPersonaReclama.Max_Value = 0.0R
        Me.dtfPersonaReclama.MensajeIncorrectoCustom = Nothing
        Me.dtfPersonaReclama.Name = "dtfPersonaReclama"
        Me.dtfPersonaReclama.Null_on_Empty = True
        Me.dtfPersonaReclama.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfPersonaReclama.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfPersonaReclama.ReadOnly_Data = False
        Me.dtfPersonaReclama.Show_Button = False
        Me.dtfPersonaReclama.Size = New System.Drawing.Size(449, 26)
        Me.dtfPersonaReclama.TabIndex = 2
        Me.dtfPersonaReclama.Text_Data = ""
        Me.dtfPersonaReclama.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfPersonaReclama.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfPersonaReclama.TopPadding = 0
        Me.dtfPersonaReclama.Upper_Case = False
        Me.dtfPersonaReclama.Validate_on_lost_focus = True
        '
        'pnlTelfReclama
        '
        Me.pnlTelfReclama.Auto_Size = False
        Me.pnlTelfReclama.BackColor = System.Drawing.SystemColors.Control
        Me.pnlTelfReclama.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlTelfReclama.ChangeDock = True
        Me.pnlTelfReclama.Control_Resize = False
        Me.pnlTelfReclama.Controls.Add(Me.dtfTelfReclama)
        Me.pnlTelfReclama.Controls.Add(Me.pnlSpace7)
        Me.pnlTelfReclama.Controls.Add(Me.dtfFaxReclama)
        Me.pnlTelfReclama.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTelfReclama.isSpace = False
        Me.pnlTelfReclama.Location = New System.Drawing.Point(6, 148)
        Me.pnlTelfReclama.Name = "pnlTelfReclama"
        Me.pnlTelfReclama.numRows = 1
        Me.pnlTelfReclama.Reorder = True
        Me.pnlTelfReclama.Size = New System.Drawing.Size(449, 26)
        Me.pnlTelfReclama.TabIndex = 1
        '
        'dtfTelfReclama
        '
        Me.dtfTelfReclama.Allow_Empty = True
        Me.dtfTelfReclama.Allow_Negative = True
        Me.dtfTelfReclama.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfTelfReclama.BackColor = System.Drawing.SystemColors.Control
        Me.dtfTelfReclama.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfTelfReclama.DataField = "TELF_RECLAMA"
        Me.dtfTelfReclama.DataTable = "PR1"
        Me.dtfTelfReclama.Descripcion = "Telefonos"
        Me.dtfTelfReclama.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfTelfReclama.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfTelfReclama.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfTelfReclama.Image = Nothing
        Me.dtfTelfReclama.Label_Space = 75
        Me.dtfTelfReclama.Length_Data = 32767
        Me.dtfTelfReclama.Location = New System.Drawing.Point(0, 0)
        Me.dtfTelfReclama.Max_Value = 0.0R
        Me.dtfTelfReclama.MensajeIncorrectoCustom = Nothing
        Me.dtfTelfReclama.Name = "dtfTelfReclama"
        Me.dtfTelfReclama.Null_on_Empty = True
        Me.dtfTelfReclama.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfTelfReclama.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfTelfReclama.ReadOnly_Data = False
        Me.dtfTelfReclama.Show_Button = False
        Me.dtfTelfReclama.Size = New System.Drawing.Size(243, 26)
        Me.dtfTelfReclama.TabIndex = 0
        Me.dtfTelfReclama.Text_Data = ""
        Me.dtfTelfReclama.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfTelfReclama.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfTelfReclama.TopPadding = 0
        Me.dtfTelfReclama.Upper_Case = False
        Me.dtfTelfReclama.Validate_on_lost_focus = True
        '
        'pnlSpace7
        '
        Me.pnlSpace7.Auto_Size = False
        Me.pnlSpace7.BackColor = System.Drawing.SystemColors.Control
        Me.pnlSpace7.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace7.ChangeDock = True
        Me.pnlSpace7.Control_Resize = False
        Me.pnlSpace7.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSpace7.isSpace = True
        Me.pnlSpace7.Location = New System.Drawing.Point(243, 0)
        Me.pnlSpace7.Name = "pnlSpace7"
        Me.pnlSpace7.numRows = 0
        Me.pnlSpace7.Reorder = False
        Me.pnlSpace7.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace7.TabIndex = 1
        '
        'dtfFaxReclama
        '
        Me.dtfFaxReclama.Allow_Empty = True
        Me.dtfFaxReclama.Allow_Negative = True
        Me.dtfFaxReclama.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfFaxReclama.BackColor = System.Drawing.SystemColors.Control
        Me.dtfFaxReclama.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfFaxReclama.DataField = "FAX_RECLAMA"
        Me.dtfFaxReclama.DataTable = "PR1"
        Me.dtfFaxReclama.Descripcion = "Fax"
        Me.dtfFaxReclama.Dock = System.Windows.Forms.DockStyle.Right
        Me.dtfFaxReclama.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfFaxReclama.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfFaxReclama.Image = Nothing
        Me.dtfFaxReclama.Label_Space = 40
        Me.dtfFaxReclama.Length_Data = 32767
        Me.dtfFaxReclama.Location = New System.Drawing.Point(249, 0)
        Me.dtfFaxReclama.Max_Value = 0.0R
        Me.dtfFaxReclama.MensajeIncorrectoCustom = Nothing
        Me.dtfFaxReclama.Name = "dtfFaxReclama"
        Me.dtfFaxReclama.Null_on_Empty = True
        Me.dtfFaxReclama.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfFaxReclama.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfFaxReclama.ReadOnly_Data = False
        Me.dtfFaxReclama.Show_Button = False
        Me.dtfFaxReclama.Size = New System.Drawing.Size(200, 26)
        Me.dtfFaxReclama.TabIndex = 2
        Me.dtfFaxReclama.Text_Data = ""
        Me.dtfFaxReclama.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfFaxReclama.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfFaxReclama.TopPadding = 0
        Me.dtfFaxReclama.Upper_Case = False
        Me.dtfFaxReclama.Validate_on_lost_focus = True
        '
        'dtdReclama
        '
        Me.dtdReclama.AutoSize = True
        Me.dtdReclama.Datafield_CP = "CP_RECLAMA"
        Me.dtdReclama.Datafield_Direccion = "DIR_RECLAMA"
        Me.dtdReclama.Datafield_Direccion2L = "DIR2_RECLAMA"
        Me.dtdReclama.Datafield_GPS = ""
        Me.dtdReclama.Datafield_Pais = "PAIS_RECLAMA"
        Me.dtdReclama.Datafield_Poblacion = "POB_RECLAMA"
        Me.dtdReclama.Datafield_Provincia = "PROV_RECLAMA"
        Me.dtdReclama.Datatable_CP = "PR1"
        Me.dtdReclama.Datatable_Direccion = "PR1"
        Me.dtdReclama.Datatable_Direccion2L = "PR1"
        Me.dtdReclama.Datatable_GPS = ""
        Me.dtdReclama.Datatable_Pais = "PR1"
        Me.dtdReclama.Datatable_Poblacion = "PR1"
        Me.dtdReclama.Datatable_Provincia = "PR1"
        Me.dtdReclama.Descripcion = Nothing
        Me.dtdReclama.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtdReclama.Label_Space = 75
        Me.dtdReclama.Location = New System.Drawing.Point(6, 18)
        Me.dtdReclama.Name = "dtdReclama"
        Me.dtdReclama.ReadOnly_Data = False
        Me.dtdReclama.requeryCP = False
        Me.dtdReclama.Show_Dir2L = True
        Me.dtdReclama.Show_GPS = False
        Me.dtdReclama.Size = New System.Drawing.Size(449, 130)
        Me.dtdReclama.TabIndex = 0
        Me.dtdReclama.Text_Data_CP = ""
        Me.dtdReclama.Text_Data_Direccion = ""
        Me.dtdReclama.Text_Data_Direccion2L = ""
        Me.dtdReclama.Text_Data_GPS = ""
        Me.dtdReclama.Text_Data_Pais = ""
        Me.dtdReclama.Text_Data_Poblacion = ""
        Me.dtdReclama.Text_Data_Provincia = ""
        '
        'pnlDireccIzq
        '
        Me.pnlDireccIzq.Auto_Size = False
        Me.pnlDireccIzq.BackColor = System.Drawing.SystemColors.Control
        Me.pnlDireccIzq.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlDireccIzq.ChangeDock = True
        Me.pnlDireccIzq.Control_Resize = False
        Me.pnlDireccIzq.Controls.Add(Me.gbxLugarEntrega)
        Me.pnlDireccIzq.Controls.Add(Me.gbxComunicaPedidos)
        Me.pnlDireccIzq.Controls.Add(Me.gbxDirPago)
        Me.pnlDireccIzq.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlDireccIzq.isSpace = False
        Me.pnlDireccIzq.Location = New System.Drawing.Point(0, 54)
        Me.pnlDireccIzq.MinimumSize = New System.Drawing.Size(467, 0)
        Me.pnlDireccIzq.Name = "pnlDireccIzq"
        Me.pnlDireccIzq.numRows = 0
        Me.pnlDireccIzq.Padding = New System.Windows.Forms.Padding(3)
        Me.pnlDireccIzq.Reorder = True
        '
        '
        '
        Me.pnlDireccIzq.RootElement.MinSize = New System.Drawing.Size(467, 0)
        Me.pnlDireccIzq.Size = New System.Drawing.Size(467, 447)
        Me.pnlDireccIzq.TabIndex = 1
        '
        'gbxLugarEntrega
        '
        Me.gbxLugarEntrega.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.gbxLugarEntrega.Controls.Add(Me.dtfLuentre6)
        Me.gbxLugarEntrega.Controls.Add(Me.dtfLuentre5)
        Me.gbxLugarEntrega.Controls.Add(Me.dtfLuentre4)
        Me.gbxLugarEntrega.Controls.Add(Me.dtfLuentre3)
        Me.gbxLugarEntrega.Controls.Add(Me.dtfLuentre2)
        Me.gbxLugarEntrega.Controls.Add(Me.dtfLuentre1)
        Me.gbxLugarEntrega.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbxLugarEntrega.HeaderText = "Lugar de Entrega"
        Me.gbxLugarEntrega.Location = New System.Drawing.Point(3, 353)
        Me.gbxLugarEntrega.Name = "gbxLugarEntrega"
        Me.gbxLugarEntrega.numRows = 6
        Me.gbxLugarEntrega.Padding = New System.Windows.Forms.Padding(6, 18, 6, 6)
        Me.gbxLugarEntrega.Reorder = True
        Me.gbxLugarEntrega.Size = New System.Drawing.Size(461, 175)
        Me.gbxLugarEntrega.TabIndex = 2
        Me.gbxLugarEntrega.Text = "Lugar de Entrega"
        Me.gbxLugarEntrega.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.gbxLugarEntrega.ThemeName = "Windows8"
        Me.gbxLugarEntrega.Title = "Lugar de Entrega"
        '
        'dtfLuentre6
        '
        Me.dtfLuentre6.Allow_Empty = True
        Me.dtfLuentre6.Allow_Negative = True
        Me.dtfLuentre6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfLuentre6.BackColor = System.Drawing.SystemColors.Control
        Me.dtfLuentre6.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfLuentre6.DataField = "DIRENVIO6"
        Me.dtfLuentre6.DataTable = "PR1"
        Me.dtfLuentre6.Descripcion = Nothing
        Me.dtfLuentre6.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfLuentre6.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfLuentre6.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfLuentre6.Length_Data = 32767
        Me.dtfLuentre6.Location = New System.Drawing.Point(6, 118)
        Me.dtfLuentre6.Max_Value = 0.0R
        Me.dtfLuentre6.MensajeIncorrectoCustom = Nothing
        Me.dtfLuentre6.Name = "dtfLuentre6"
        Me.dtfLuentre6.Null_on_Empty = True
        Me.dtfLuentre6.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfLuentre6.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfLuentre6.ReadOnly_Data = False
        Me.dtfLuentre6.Size = New System.Drawing.Size(449, 20)
        Me.dtfLuentre6.TabIndex = 5
        Me.dtfLuentre6.Text_Data = ""
        Me.dtfLuentre6.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfLuentre6.TopPadding = 0
        Me.dtfLuentre6.Upper_Case = False
        Me.dtfLuentre6.Validate_on_lost_focus = True
        '
        'dtfLuentre5
        '
        Me.dtfLuentre5.Allow_Empty = True
        Me.dtfLuentre5.Allow_Negative = True
        Me.dtfLuentre5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfLuentre5.BackColor = System.Drawing.SystemColors.Control
        Me.dtfLuentre5.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfLuentre5.DataField = "DIRENVIO5"
        Me.dtfLuentre5.DataTable = "PR1"
        Me.dtfLuentre5.Descripcion = Nothing
        Me.dtfLuentre5.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfLuentre5.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfLuentre5.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfLuentre5.Length_Data = 32767
        Me.dtfLuentre5.Location = New System.Drawing.Point(6, 98)
        Me.dtfLuentre5.Max_Value = 0.0R
        Me.dtfLuentre5.MensajeIncorrectoCustom = Nothing
        Me.dtfLuentre5.Name = "dtfLuentre5"
        Me.dtfLuentre5.Null_on_Empty = True
        Me.dtfLuentre5.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfLuentre5.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfLuentre5.ReadOnly_Data = False
        Me.dtfLuentre5.Size = New System.Drawing.Size(449, 20)
        Me.dtfLuentre5.TabIndex = 4
        Me.dtfLuentre5.Text_Data = ""
        Me.dtfLuentre5.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfLuentre5.TopPadding = 0
        Me.dtfLuentre5.Upper_Case = False
        Me.dtfLuentre5.Validate_on_lost_focus = True
        '
        'dtfLuentre4
        '
        Me.dtfLuentre4.Allow_Empty = True
        Me.dtfLuentre4.Allow_Negative = True
        Me.dtfLuentre4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfLuentre4.BackColor = System.Drawing.SystemColors.Control
        Me.dtfLuentre4.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfLuentre4.DataField = "DIRENVIO4"
        Me.dtfLuentre4.DataTable = "PR1"
        Me.dtfLuentre4.Descripcion = Nothing
        Me.dtfLuentre4.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfLuentre4.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfLuentre4.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfLuentre4.Length_Data = 32767
        Me.dtfLuentre4.Location = New System.Drawing.Point(6, 78)
        Me.dtfLuentre4.Max_Value = 0.0R
        Me.dtfLuentre4.MensajeIncorrectoCustom = Nothing
        Me.dtfLuentre4.Name = "dtfLuentre4"
        Me.dtfLuentre4.Null_on_Empty = True
        Me.dtfLuentre4.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfLuentre4.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfLuentre4.ReadOnly_Data = False
        Me.dtfLuentre4.Size = New System.Drawing.Size(449, 20)
        Me.dtfLuentre4.TabIndex = 3
        Me.dtfLuentre4.Text_Data = ""
        Me.dtfLuentre4.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfLuentre4.TopPadding = 0
        Me.dtfLuentre4.Upper_Case = False
        Me.dtfLuentre4.Validate_on_lost_focus = True
        '
        'dtfLuentre3
        '
        Me.dtfLuentre3.Allow_Empty = True
        Me.dtfLuentre3.Allow_Negative = True
        Me.dtfLuentre3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfLuentre3.BackColor = System.Drawing.SystemColors.Control
        Me.dtfLuentre3.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfLuentre3.DataField = "DIRENVIO3"
        Me.dtfLuentre3.DataTable = "PR1"
        Me.dtfLuentre3.Descripcion = Nothing
        Me.dtfLuentre3.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfLuentre3.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfLuentre3.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfLuentre3.Length_Data = 32767
        Me.dtfLuentre3.Location = New System.Drawing.Point(6, 58)
        Me.dtfLuentre3.Max_Value = 0.0R
        Me.dtfLuentre3.MensajeIncorrectoCustom = Nothing
        Me.dtfLuentre3.Name = "dtfLuentre3"
        Me.dtfLuentre3.Null_on_Empty = True
        Me.dtfLuentre3.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfLuentre3.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfLuentre3.ReadOnly_Data = False
        Me.dtfLuentre3.Size = New System.Drawing.Size(449, 20)
        Me.dtfLuentre3.TabIndex = 2
        Me.dtfLuentre3.Text_Data = ""
        Me.dtfLuentre3.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfLuentre3.TopPadding = 0
        Me.dtfLuentre3.Upper_Case = False
        Me.dtfLuentre3.Validate_on_lost_focus = True
        '
        'dtfLuentre2
        '
        Me.dtfLuentre2.Allow_Empty = True
        Me.dtfLuentre2.Allow_Negative = True
        Me.dtfLuentre2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfLuentre2.BackColor = System.Drawing.SystemColors.Control
        Me.dtfLuentre2.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfLuentre2.DataField = "DIRENVIO2"
        Me.dtfLuentre2.DataTable = "PR1"
        Me.dtfLuentre2.Descripcion = Nothing
        Me.dtfLuentre2.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfLuentre2.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfLuentre2.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfLuentre2.Length_Data = 32767
        Me.dtfLuentre2.Location = New System.Drawing.Point(6, 38)
        Me.dtfLuentre2.Max_Value = 0.0R
        Me.dtfLuentre2.MensajeIncorrectoCustom = Nothing
        Me.dtfLuentre2.Name = "dtfLuentre2"
        Me.dtfLuentre2.Null_on_Empty = True
        Me.dtfLuentre2.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfLuentre2.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfLuentre2.ReadOnly_Data = False
        Me.dtfLuentre2.Size = New System.Drawing.Size(449, 20)
        Me.dtfLuentre2.TabIndex = 1
        Me.dtfLuentre2.Text_Data = ""
        Me.dtfLuentre2.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfLuentre2.TopPadding = 0
        Me.dtfLuentre2.Upper_Case = False
        Me.dtfLuentre2.Validate_on_lost_focus = True
        '
        'dtfLuentre1
        '
        Me.dtfLuentre1.Allow_Empty = True
        Me.dtfLuentre1.Allow_Negative = True
        Me.dtfLuentre1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfLuentre1.BackColor = System.Drawing.SystemColors.Control
        Me.dtfLuentre1.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfLuentre1.DataField = "DIRENVIO1"
        Me.dtfLuentre1.DataTable = "PR1"
        Me.dtfLuentre1.Descripcion = Nothing
        Me.dtfLuentre1.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfLuentre1.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfLuentre1.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfLuentre1.Length_Data = 32767
        Me.dtfLuentre1.Location = New System.Drawing.Point(6, 18)
        Me.dtfLuentre1.Max_Value = 0.0R
        Me.dtfLuentre1.MensajeIncorrectoCustom = Nothing
        Me.dtfLuentre1.Name = "dtfLuentre1"
        Me.dtfLuentre1.Null_on_Empty = True
        Me.dtfLuentre1.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfLuentre1.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfLuentre1.ReadOnly_Data = False
        Me.dtfLuentre1.Size = New System.Drawing.Size(449, 20)
        Me.dtfLuentre1.TabIndex = 0
        Me.dtfLuentre1.Text_Data = ""
        Me.dtfLuentre1.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfLuentre1.TopPadding = 0
        Me.dtfLuentre1.Upper_Case = False
        Me.dtfLuentre1.Validate_on_lost_focus = True
        '
        'gbxComunicaPedidos
        '
        Me.gbxComunicaPedidos.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.gbxComunicaPedidos.Controls.Add(Me.dtfCondicionVentaComunicaPedidos)
        Me.gbxComunicaPedidos.Controls.Add(Me.dtfFEntregaComunicaPedidos)
        Me.gbxComunicaPedidos.Controls.Add(Me.dtfEmailComunicaPedidos)
        Me.gbxComunicaPedidos.Controls.Add(Me.dtfViaComunicaPedidos)
        Me.gbxComunicaPedidos.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbxComunicaPedidos.HeaderText = "Modo de Comunicación de Pedidos"
        Me.gbxComunicaPedidos.Location = New System.Drawing.Point(3, 230)
        Me.gbxComunicaPedidos.Name = "gbxComunicaPedidos"
        Me.gbxComunicaPedidos.numRows = 4
        Me.gbxComunicaPedidos.Padding = New System.Windows.Forms.Padding(6, 18, 6, 6)
        Me.gbxComunicaPedidos.Reorder = True
        Me.gbxComunicaPedidos.Size = New System.Drawing.Size(461, 123)
        Me.gbxComunicaPedidos.TabIndex = 1
        Me.gbxComunicaPedidos.Text = "Modo de Comunicación de Pedidos"
        Me.gbxComunicaPedidos.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.gbxComunicaPedidos.ThemeName = "Windows8"
        Me.gbxComunicaPedidos.Title = "Modo de Comunicación de Pedidos"
        '
        'dtfCondicionVentaComunicaPedidos
        '
        Me.dtfCondicionVentaComunicaPedidos.Allow_Empty = True
        Me.dtfCondicionVentaComunicaPedidos.Allow_Negative = True
        Me.dtfCondicionVentaComunicaPedidos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfCondicionVentaComunicaPedidos.BackColor = System.Drawing.SystemColors.Control
        Me.dtfCondicionVentaComunicaPedidos.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfCondicionVentaComunicaPedidos.DataField = "CONDICION_VENTA"
        Me.dtfCondicionVentaComunicaPedidos.DataTable = "PR1"
        Me.dtfCondicionVentaComunicaPedidos.DB = Connection19
        Me.dtfCondicionVentaComunicaPedidos.Desc_Datafield = "NOMBRE"
        Me.dtfCondicionVentaComunicaPedidos.Desc_DBPK = "CODIGO"
        Me.dtfCondicionVentaComunicaPedidos.Desc_DBTable = "TL_CONDICION_PRECIO"
        Me.dtfCondicionVentaComunicaPedidos.Desc_Where = Nothing
        Me.dtfCondicionVentaComunicaPedidos.Desc_WhereObligatoria = Nothing
        Me.dtfCondicionVentaComunicaPedidos.Descripcion = "Condición Venta"
        Me.dtfCondicionVentaComunicaPedidos.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfCondicionVentaComunicaPedidos.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfCondicionVentaComunicaPedidos.ExtraSQL = ""
        Me.dtfCondicionVentaComunicaPedidos.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfCondicionVentaComunicaPedidos.Formulario = Nothing
        Me.dtfCondicionVentaComunicaPedidos.Label_Space = 100
        Me.dtfCondicionVentaComunicaPedidos.Length_Data = 32767
        Me.dtfCondicionVentaComunicaPedidos.Location = New System.Drawing.Point(6, 96)
        Me.dtfCondicionVentaComunicaPedidos.Lupa = Nothing
        Me.dtfCondicionVentaComunicaPedidos.Max_Value = 0.0R
        Me.dtfCondicionVentaComunicaPedidos.MensajeIncorrectoCustom = Nothing
        Me.dtfCondicionVentaComunicaPedidos.Name = "dtfCondicionVentaComunicaPedidos"
        Me.dtfCondicionVentaComunicaPedidos.Null_on_Empty = True
        Me.dtfCondicionVentaComunicaPedidos.OpenForm = Nothing
        Me.dtfCondicionVentaComunicaPedidos.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfCondicionVentaComunicaPedidos.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfCondicionVentaComunicaPedidos.Query_on_Text_Changed = True
        Me.dtfCondicionVentaComunicaPedidos.ReadOnly_Data = False
        Me.dtfCondicionVentaComunicaPedidos.ShowButton = True
        Me.dtfCondicionVentaComunicaPedidos.Size = New System.Drawing.Size(449, 26)
        Me.dtfCondicionVentaComunicaPedidos.TabIndex = 3
        Me.dtfCondicionVentaComunicaPedidos.Text_Data = ""
        Me.dtfCondicionVentaComunicaPedidos.Text_Data_Desc = ""
        Me.dtfCondicionVentaComunicaPedidos.Text_Width = 58
        Me.dtfCondicionVentaComunicaPedidos.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfCondicionVentaComunicaPedidos.TopPadding = 0
        Me.dtfCondicionVentaComunicaPedidos.Upper_Case = False
        Me.dtfCondicionVentaComunicaPedidos.Validate_on_lost_focus = True
        '
        'dtfFEntregaComunicaPedidos
        '
        Me.dtfFEntregaComunicaPedidos.Allow_Empty = True
        Me.dtfFEntregaComunicaPedidos.Allow_Negative = True
        Me.dtfFEntregaComunicaPedidos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfFEntregaComunicaPedidos.BackColor = System.Drawing.SystemColors.Control
        Me.dtfFEntregaComunicaPedidos.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfFEntregaComunicaPedidos.DataField = "FORMA_ENVIO"
        Me.dtfFEntregaComunicaPedidos.DataTable = "PR1"
        Me.dtfFEntregaComunicaPedidos.DB = Connection20
        Me.dtfFEntregaComunicaPedidos.Desc_Datafield = "NOMBRE"
        Me.dtfFEntregaComunicaPedidos.Desc_DBPK = "CODIGO"
        Me.dtfFEntregaComunicaPedidos.Desc_DBTable = "FORMAS_PEDENT"
        Me.dtfFEntregaComunicaPedidos.Desc_Where = Nothing
        Me.dtfFEntregaComunicaPedidos.Desc_WhereObligatoria = Nothing
        Me.dtfFEntregaComunicaPedidos.Descripcion = "F. Entrega"
        Me.dtfFEntregaComunicaPedidos.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfFEntregaComunicaPedidos.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfFEntregaComunicaPedidos.ExtraSQL = ""
        Me.dtfFEntregaComunicaPedidos.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfFEntregaComunicaPedidos.Formulario = Nothing
        Me.dtfFEntregaComunicaPedidos.Label_Space = 75
        Me.dtfFEntregaComunicaPedidos.Length_Data = 32767
        Me.dtfFEntregaComunicaPedidos.Location = New System.Drawing.Point(6, 70)
        Me.dtfFEntregaComunicaPedidos.Lupa = Nothing
        Me.dtfFEntregaComunicaPedidos.Max_Value = 0.0R
        Me.dtfFEntregaComunicaPedidos.MensajeIncorrectoCustom = Nothing
        Me.dtfFEntregaComunicaPedidos.Name = "dtfFEntregaComunicaPedidos"
        Me.dtfFEntregaComunicaPedidos.Null_on_Empty = True
        Me.dtfFEntregaComunicaPedidos.OpenForm = Nothing
        Me.dtfFEntregaComunicaPedidos.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfFEntregaComunicaPedidos.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfFEntregaComunicaPedidos.Query_on_Text_Changed = True
        Me.dtfFEntregaComunicaPedidos.ReadOnly_Data = False
        Me.dtfFEntregaComunicaPedidos.ShowButton = True
        Me.dtfFEntregaComunicaPedidos.Size = New System.Drawing.Size(449, 26)
        Me.dtfFEntregaComunicaPedidos.TabIndex = 2
        Me.dtfFEntregaComunicaPedidos.Text_Data = ""
        Me.dtfFEntregaComunicaPedidos.Text_Data_Desc = ""
        Me.dtfFEntregaComunicaPedidos.Text_Width = 58
        Me.dtfFEntregaComunicaPedidos.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfFEntregaComunicaPedidos.TopPadding = 0
        Me.dtfFEntregaComunicaPedidos.Upper_Case = False
        Me.dtfFEntregaComunicaPedidos.Validate_on_lost_focus = True
        '
        'dtfEmailComunicaPedidos
        '
        Me.dtfEmailComunicaPedidos.Allow_Empty = True
        Me.dtfEmailComunicaPedidos.Allow_Negative = True
        Me.dtfEmailComunicaPedidos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfEmailComunicaPedidos.BackColor = System.Drawing.SystemColors.Control
        Me.dtfEmailComunicaPedidos.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfEmailComunicaPedidos.DataField = "PERSONA"
        Me.dtfEmailComunicaPedidos.DataTable = "PR1"
        Me.dtfEmailComunicaPedidos.Descripcion = "Email"
        Me.dtfEmailComunicaPedidos.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfEmailComunicaPedidos.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfEmailComunicaPedidos.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfEmailComunicaPedidos.Image = Nothing
        Me.dtfEmailComunicaPedidos.Label_Space = 75
        Me.dtfEmailComunicaPedidos.Length_Data = 32767
        Me.dtfEmailComunicaPedidos.Location = New System.Drawing.Point(6, 44)
        Me.dtfEmailComunicaPedidos.Max_Value = 0.0R
        Me.dtfEmailComunicaPedidos.MensajeIncorrectoCustom = Nothing
        Me.dtfEmailComunicaPedidos.Name = "dtfEmailComunicaPedidos"
        Me.dtfEmailComunicaPedidos.Null_on_Empty = True
        Me.dtfEmailComunicaPedidos.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfEmailComunicaPedidos.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfEmailComunicaPedidos.ReadOnly_Data = False
        Me.dtfEmailComunicaPedidos.Show_Button = False
        Me.dtfEmailComunicaPedidos.Size = New System.Drawing.Size(449, 26)
        Me.dtfEmailComunicaPedidos.TabIndex = 1
        Me.dtfEmailComunicaPedidos.Text_Data = ""
        Me.dtfEmailComunicaPedidos.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfEmailComunicaPedidos.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfEmailComunicaPedidos.TopPadding = 0
        Me.dtfEmailComunicaPedidos.Upper_Case = False
        Me.dtfEmailComunicaPedidos.Validate_on_lost_focus = True
        '
        'dtfViaComunicaPedidos
        '
        Me.dtfViaComunicaPedidos.Allow_Empty = True
        Me.dtfViaComunicaPedidos.Allow_Negative = True
        Me.dtfViaComunicaPedidos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfViaComunicaPedidos.BackColor = System.Drawing.SystemColors.Control
        Me.dtfViaComunicaPedidos.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfViaComunicaPedidos.DataField = "VIA"
        Me.dtfViaComunicaPedidos.DataTable = "PR1"
        Me.dtfViaComunicaPedidos.DB = Connection21
        Me.dtfViaComunicaPedidos.Desc_Datafield = "NOMBRE"
        Me.dtfViaComunicaPedidos.Desc_DBPK = "CODIGO"
        Me.dtfViaComunicaPedidos.Desc_DBTable = "VIASPEDIPRO"
        Me.dtfViaComunicaPedidos.Desc_Where = Nothing
        Me.dtfViaComunicaPedidos.Desc_WhereObligatoria = Nothing
        Me.dtfViaComunicaPedidos.Descripcion = "Via"
        Me.dtfViaComunicaPedidos.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfViaComunicaPedidos.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfViaComunicaPedidos.ExtraSQL = ""
        Me.dtfViaComunicaPedidos.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfViaComunicaPedidos.Formulario = Nothing
        Me.dtfViaComunicaPedidos.Label_Space = 75
        Me.dtfViaComunicaPedidos.Length_Data = 32767
        Me.dtfViaComunicaPedidos.Location = New System.Drawing.Point(6, 18)
        Me.dtfViaComunicaPedidos.Lupa = Nothing
        Me.dtfViaComunicaPedidos.Max_Value = 0.0R
        Me.dtfViaComunicaPedidos.MensajeIncorrectoCustom = Nothing
        Me.dtfViaComunicaPedidos.Name = "dtfViaComunicaPedidos"
        Me.dtfViaComunicaPedidos.Null_on_Empty = True
        Me.dtfViaComunicaPedidos.OpenForm = Nothing
        Me.dtfViaComunicaPedidos.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfViaComunicaPedidos.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfViaComunicaPedidos.Query_on_Text_Changed = True
        Me.dtfViaComunicaPedidos.ReadOnly_Data = False
        Me.dtfViaComunicaPedidos.ShowButton = True
        Me.dtfViaComunicaPedidos.Size = New System.Drawing.Size(449, 26)
        Me.dtfViaComunicaPedidos.TabIndex = 0
        Me.dtfViaComunicaPedidos.Text_Data = ""
        Me.dtfViaComunicaPedidos.Text_Data_Desc = ""
        Me.dtfViaComunicaPedidos.Text_Width = 58
        Me.dtfViaComunicaPedidos.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfViaComunicaPedidos.TopPadding = 0
        Me.dtfViaComunicaPedidos.Upper_Case = False
        Me.dtfViaComunicaPedidos.Validate_on_lost_focus = True
        '
        'gbxDirPago
        '
        Me.gbxDirPago.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.gbxDirPago.Controls.Add(Me.dtfEmailPago)
        Me.gbxDirPago.Controls.Add(Me.dtfPersonaPago)
        Me.gbxDirPago.Controls.Add(Me.pnlTelfPago)
        Me.gbxDirPago.Controls.Add(Me.dtdPago)
        Me.gbxDirPago.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbxDirPago.HeaderText = "Dirección de Pago"
        Me.gbxDirPago.Location = New System.Drawing.Point(3, 3)
        Me.gbxDirPago.Name = "gbxDirPago"
        Me.gbxDirPago.numRows = 8
        Me.gbxDirPago.Padding = New System.Windows.Forms.Padding(6, 18, 6, 6)
        Me.gbxDirPago.Reorder = True
        Me.gbxDirPago.Size = New System.Drawing.Size(461, 227)
        Me.gbxDirPago.TabIndex = 0
        Me.gbxDirPago.Text = "Dirección de Pago"
        Me.gbxDirPago.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.gbxDirPago.ThemeName = "Windows8"
        Me.gbxDirPago.Title = "Dirección de Pago"
        '
        'dtfEmailPago
        '
        Me.dtfEmailPago.Allow_Empty = True
        Me.dtfEmailPago.Allow_Negative = True
        Me.dtfEmailPago.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfEmailPago.BackColor = System.Drawing.SystemColors.Control
        Me.dtfEmailPago.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfEmailPago.DataField = "MAIL_PAGO"
        Me.dtfEmailPago.DataTable = "PR1"
        Me.dtfEmailPago.Descripcion = "Email"
        Me.dtfEmailPago.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfEmailPago.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfEmailPago.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfEmailPago.Image = Nothing
        Me.dtfEmailPago.Label_Space = 75
        Me.dtfEmailPago.Length_Data = 32767
        Me.dtfEmailPago.Location = New System.Drawing.Point(6, 200)
        Me.dtfEmailPago.Max_Value = 0.0R
        Me.dtfEmailPago.MensajeIncorrectoCustom = Nothing
        Me.dtfEmailPago.Name = "dtfEmailPago"
        Me.dtfEmailPago.Null_on_Empty = True
        Me.dtfEmailPago.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfEmailPago.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfEmailPago.ReadOnly_Data = False
        Me.dtfEmailPago.Show_Button = False
        Me.dtfEmailPago.Size = New System.Drawing.Size(449, 26)
        Me.dtfEmailPago.TabIndex = 3
        Me.dtfEmailPago.Text_Data = ""
        Me.dtfEmailPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfEmailPago.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfEmailPago.TopPadding = 0
        Me.dtfEmailPago.Upper_Case = False
        Me.dtfEmailPago.Validate_on_lost_focus = True
        '
        'dtfPersonaPago
        '
        Me.dtfPersonaPago.Allow_Empty = True
        Me.dtfPersonaPago.Allow_Negative = True
        Me.dtfPersonaPago.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfPersonaPago.BackColor = System.Drawing.SystemColors.Control
        Me.dtfPersonaPago.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfPersonaPago.DataField = "PERSONA_PAGO"
        Me.dtfPersonaPago.DataTable = "PR1"
        Me.dtfPersonaPago.Descripcion = "Persona"
        Me.dtfPersonaPago.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfPersonaPago.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfPersonaPago.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfPersonaPago.Image = Nothing
        Me.dtfPersonaPago.Label_Space = 75
        Me.dtfPersonaPago.Length_Data = 32767
        Me.dtfPersonaPago.Location = New System.Drawing.Point(6, 174)
        Me.dtfPersonaPago.Max_Value = 0.0R
        Me.dtfPersonaPago.MensajeIncorrectoCustom = Nothing
        Me.dtfPersonaPago.Name = "dtfPersonaPago"
        Me.dtfPersonaPago.Null_on_Empty = True
        Me.dtfPersonaPago.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfPersonaPago.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfPersonaPago.ReadOnly_Data = False
        Me.dtfPersonaPago.Show_Button = False
        Me.dtfPersonaPago.Size = New System.Drawing.Size(449, 26)
        Me.dtfPersonaPago.TabIndex = 2
        Me.dtfPersonaPago.Text_Data = ""
        Me.dtfPersonaPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfPersonaPago.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfPersonaPago.TopPadding = 0
        Me.dtfPersonaPago.Upper_Case = False
        Me.dtfPersonaPago.Validate_on_lost_focus = True
        '
        'pnlTelfPago
        '
        Me.pnlTelfPago.Auto_Size = False
        Me.pnlTelfPago.BackColor = System.Drawing.SystemColors.Control
        Me.pnlTelfPago.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlTelfPago.ChangeDock = True
        Me.pnlTelfPago.Control_Resize = False
        Me.pnlTelfPago.Controls.Add(Me.dtfTelfPago)
        Me.pnlTelfPago.Controls.Add(Me.pnlSpace6)
        Me.pnlTelfPago.Controls.Add(Me.dtfFaxPago)
        Me.pnlTelfPago.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTelfPago.isSpace = False
        Me.pnlTelfPago.Location = New System.Drawing.Point(6, 148)
        Me.pnlTelfPago.Name = "pnlTelfPago"
        Me.pnlTelfPago.numRows = 1
        Me.pnlTelfPago.Reorder = True
        Me.pnlTelfPago.Size = New System.Drawing.Size(449, 26)
        Me.pnlTelfPago.TabIndex = 1
        '
        'dtfTelfPago
        '
        Me.dtfTelfPago.Allow_Empty = True
        Me.dtfTelfPago.Allow_Negative = True
        Me.dtfTelfPago.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfTelfPago.BackColor = System.Drawing.SystemColors.Control
        Me.dtfTelfPago.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfTelfPago.DataField = "TELF_PAGO"
        Me.dtfTelfPago.DataTable = "PR1"
        Me.dtfTelfPago.Descripcion = "Telefonos"
        Me.dtfTelfPago.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfTelfPago.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfTelfPago.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfTelfPago.Image = Nothing
        Me.dtfTelfPago.Label_Space = 75
        Me.dtfTelfPago.Length_Data = 32767
        Me.dtfTelfPago.Location = New System.Drawing.Point(0, 0)
        Me.dtfTelfPago.Max_Value = 0.0R
        Me.dtfTelfPago.MensajeIncorrectoCustom = Nothing
        Me.dtfTelfPago.Name = "dtfTelfPago"
        Me.dtfTelfPago.Null_on_Empty = True
        Me.dtfTelfPago.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfTelfPago.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfTelfPago.ReadOnly_Data = False
        Me.dtfTelfPago.Show_Button = False
        Me.dtfTelfPago.Size = New System.Drawing.Size(243, 26)
        Me.dtfTelfPago.TabIndex = 0
        Me.dtfTelfPago.Text_Data = ""
        Me.dtfTelfPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfTelfPago.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfTelfPago.TopPadding = 0
        Me.dtfTelfPago.Upper_Case = False
        Me.dtfTelfPago.Validate_on_lost_focus = True
        '
        'pnlSpace6
        '
        Me.pnlSpace6.Auto_Size = False
        Me.pnlSpace6.BackColor = System.Drawing.SystemColors.Control
        Me.pnlSpace6.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace6.ChangeDock = True
        Me.pnlSpace6.Control_Resize = False
        Me.pnlSpace6.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSpace6.isSpace = True
        Me.pnlSpace6.Location = New System.Drawing.Point(243, 0)
        Me.pnlSpace6.Name = "pnlSpace6"
        Me.pnlSpace6.numRows = 0
        Me.pnlSpace6.Reorder = False
        Me.pnlSpace6.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace6.TabIndex = 1
        '
        'dtfFaxPago
        '
        Me.dtfFaxPago.Allow_Empty = True
        Me.dtfFaxPago.Allow_Negative = True
        Me.dtfFaxPago.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfFaxPago.BackColor = System.Drawing.SystemColors.Control
        Me.dtfFaxPago.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfFaxPago.DataField = "FAX_PAGO"
        Me.dtfFaxPago.DataTable = "PR1"
        Me.dtfFaxPago.Descripcion = "Fax"
        Me.dtfFaxPago.Dock = System.Windows.Forms.DockStyle.Right
        Me.dtfFaxPago.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfFaxPago.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfFaxPago.Image = Nothing
        Me.dtfFaxPago.Label_Space = 40
        Me.dtfFaxPago.Length_Data = 32767
        Me.dtfFaxPago.Location = New System.Drawing.Point(249, 0)
        Me.dtfFaxPago.Max_Value = 0.0R
        Me.dtfFaxPago.MensajeIncorrectoCustom = Nothing
        Me.dtfFaxPago.Name = "dtfFaxPago"
        Me.dtfFaxPago.Null_on_Empty = True
        Me.dtfFaxPago.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfFaxPago.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfFaxPago.ReadOnly_Data = False
        Me.dtfFaxPago.Show_Button = False
        Me.dtfFaxPago.Size = New System.Drawing.Size(200, 26)
        Me.dtfFaxPago.TabIndex = 2
        Me.dtfFaxPago.Text_Data = ""
        Me.dtfFaxPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfFaxPago.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfFaxPago.TopPadding = 0
        Me.dtfFaxPago.Upper_Case = False
        Me.dtfFaxPago.Validate_on_lost_focus = True
        '
        'dtdPago
        '
        Me.dtdPago.AutoSize = True
        Me.dtdPago.Datafield_CP = "CP_PAGO"
        Me.dtdPago.Datafield_Direccion = "DIR_PAGO"
        Me.dtdPago.Datafield_Direccion2L = "DIR2_PAGO"
        Me.dtdPago.Datafield_GPS = ""
        Me.dtdPago.Datafield_Pais = "PAIS_PAGO"
        Me.dtdPago.Datafield_Poblacion = "POB_PAGO"
        Me.dtdPago.Datafield_Provincia = "PROV_PAGO"
        Me.dtdPago.Datatable_CP = "PR1"
        Me.dtdPago.Datatable_Direccion = "PR1"
        Me.dtdPago.Datatable_Direccion2L = "PR1"
        Me.dtdPago.Datatable_GPS = ""
        Me.dtdPago.Datatable_Pais = "PR1"
        Me.dtdPago.Datatable_Poblacion = "PR1"
        Me.dtdPago.Datatable_Provincia = "PR1"
        Me.dtdPago.Descripcion = Nothing
        Me.dtdPago.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtdPago.Label_Space = 75
        Me.dtdPago.Location = New System.Drawing.Point(6, 18)
        Me.dtdPago.Name = "dtdPago"
        Me.dtdPago.ReadOnly_Data = False
        Me.dtdPago.requeryCP = False
        Me.dtdPago.Show_Dir2L = True
        Me.dtdPago.Show_GPS = False
        Me.dtdPago.Size = New System.Drawing.Size(449, 130)
        Me.dtdPago.TabIndex = 0
        Me.dtdPago.Text_Data_CP = ""
        Me.dtdPago.Text_Data_Direccion = ""
        Me.dtdPago.Text_Data_Direccion2L = ""
        Me.dtdPago.Text_Data_GPS = ""
        Me.dtdPago.Text_Data_Pais = ""
        Me.dtdPago.Text_Data_Poblacion = ""
        Me.dtdPago.Text_Data_Provincia = ""
        '
        'pnlDirS
        '
        Me.pnlDirS.Auto_Size = False
        Me.pnlDirS.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.pnlDirS.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlDirS.ChangeDock = False
        Me.pnlDirS.Control_Resize = False
        Me.pnlDirS.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlDirS.isSpace = False
        Me.pnlDirS.Location = New System.Drawing.Point(0, 0)
        Me.pnlDirS.Name = "pnlDirS"
        Me.pnlDirS.numRows = 0
        Me.pnlDirS.Reorder = True
        Me.pnlDirS.Size = New System.Drawing.Size(934, 54)
        Me.pnlDirS.TabIndex = 5
        '
        'pvpEvaluacion
        '
        Me.pvpEvaluacion.Controls.Add(Me.pnlEvaS)
        Me.pvpEvaluacion.ItemSize = New System.Drawing.SizeF(106.0!, 23.0!)
        Me.pvpEvaluacion.Location = New System.Drawing.Point(129, 5)
        Me.pvpEvaluacion.Name = "pvpEvaluacion"
        Me.pvpEvaluacion.PanelCabezeraContainer = Me.pnlEvaS
        Me.pvpEvaluacion.Size = New System.Drawing.Size(933, 518)
        Me.pvpEvaluacion.Text = "Evaluación"
        '
        'pnlEvaS
        '
        Me.pnlEvaS.Auto_Size = False
        Me.pnlEvaS.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.pnlEvaS.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlEvaS.ChangeDock = False
        Me.pnlEvaS.Control_Resize = False
        Me.pnlEvaS.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEvaS.isSpace = False
        Me.pnlEvaS.Location = New System.Drawing.Point(0, 0)
        Me.pnlEvaS.Name = "pnlEvaS"
        Me.pnlEvaS.numRows = 0
        Me.pnlEvaS.Reorder = True
        Me.pnlEvaS.Size = New System.Drawing.Size(933, 54)
        Me.pnlEvaS.TabIndex = 5
        '
        'Proveedores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1067, 713)
        Me.Name = "Proveedores"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Proveedores"
        CType(Me.pnlBlock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pvwBase, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pvwBase.ResumeLayout(False)
        CType(Me.stbBase, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pvpDatosGenerales.ResumeLayout(False)
        CType(Me.pnlGenDer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlGenDer.ResumeLayout(False)
        CType(Me.pnlBottomGen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBottomGen.ResumeLayout(False)
        CType(Me.dtlUltmodi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtlUsumodi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlGenIzq, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlGenIzq.ResumeLayout(False)
        Me.pnlGenIzq.PerformLayout()
        CType(Me.pnlOtros, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlFaltaFbaja, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFaltaFbaja.ResumeLayout(False)
        CType(Me.pnlSpace5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlEmpOfi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEmpOfi.ResumeLayout(False)
        CType(Me.pnlSpace10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlTelefonos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTelefonos.ResumeLayout(False)
        CType(Me.pnlSpace3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSpace4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlGenS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlGenS.ResumeLayout(False)
        CType(Me.pnlGen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlGen.ResumeLayout(False)
        CType(Me.pnlGenF, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlGenF.ResumeLayout(False)
        CType(Me.pnlNifNombre, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlNifNombre.ResumeLayout(False)
        CType(Me.pnlSpace2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlCodigo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCodigo.ResumeLayout(False)
        CType(Me.pnlSpace1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlGenR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlGenR.ResumeLayout(False)
        Me.pvpFacturacionContable.ResumeLayout(False)
        CType(Me.pnlContables, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlContables.ResumeLayout(False)
        CType(Me.gbxContable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxContable.ResumeLayout(False)
        CType(Me.rdgTipoCompra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rdgTipoCompra.ResumeLayout(False)
        Me.rdgTipoCompra.PerformLayout()
        CType(Me.dtrInmovilizado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtrGasto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtrCompra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbxIntracomunitario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxIntracomunitario.ResumeLayout(False)
        CType(Me.gbxLeasings, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxLeasings.ResumeLayout(False)
        Me.gbxLeasings.PerformLayout()
        CType(Me.dtcLeasing, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlRetencion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlRetencion.ResumeLayout(False)
        CType(Me.pnlSpace12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlCtaCompGasto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCtaCompGasto.ResumeLayout(False)
        CType(Me.pnlSpace13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnCompGastoAplicar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlCtaContable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCtaContable.ResumeLayout(False)
        Me.pnlCtaContable.PerformLayout()
        CType(Me.dtcNoAparecer347349, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSpace11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlFacturacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFacturacion.ResumeLayout(False)
        CType(Me.gbxFacturacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxFacturacion.ResumeLayout(False)
        CType(Me.pnlChecks, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlChecks.ResumeLayout(False)
        CType(Me.pnlChecks2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlChecks2.ResumeLayout(False)
        Me.pnlChecks2.PerformLayout()
        CType(Me.dtcAutoFacMante, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtcAlbaranesCosteTransp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtcExenOperInter, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlChecksIzq, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlChecksIzq.ResumeLayout(False)
        Me.pnlChecksIzq.PerformLayout()
        CType(Me.dtcGestAlba, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtcEsIntracomunitario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtcGestIvaImportacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtcMargenNoAuto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Panel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.Panel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Panel3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PnlIdiomaDivisa, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlIdiomaDivisa.ResumeLayout(False)
        CType(Me.pnlSpace23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlIbanSwift, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlIbanSwift.ResumeLayout(False)
        CType(Me.pnlSpace20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlVacaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlVacaciones.ResumeLayout(False)
        CType(Me.pnlSpace19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlDtos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDtos.ResumeLayout(False)
        CType(Me.pnlSpace21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSpace22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlPlazosPago, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPlazosPago.ResumeLayout(False)
        CType(Me.pnlSpace18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSpace17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSpace16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSpace15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSpace14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlFacContaS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pvpDelegaciones.ResumeLayout(False)
        CType(Me.dgvDelegacion.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDelegacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlDelegaS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pvpContactos.ResumeLayout(False)
        CType(Me.dgvContactos.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvContactos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlContactosS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pvpAcumulados.ResumeLayout(False)
        CType(Me.pnlAcumS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pvpVisitas.ResumeLayout(False)
        CType(Me.pnlVisitasS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pvpDirecciones.ResumeLayout(False)
        CType(Me.pnlDireccDer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDireccDer.ResumeLayout(False)
        CType(Me.gbxDireDevo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxDireDevo.ResumeLayout(False)
        Me.gbxDireDevo.PerformLayout()
        CType(Me.pnlTelfDevo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTelfDevo.ResumeLayout(False)
        CType(Me.pnlSpace8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbxDirReclama, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxDirReclama.ResumeLayout(False)
        Me.gbxDirReclama.PerformLayout()
        CType(Me.pnlTelfReclama, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTelfReclama.ResumeLayout(False)
        CType(Me.pnlSpace7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlDireccIzq, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDireccIzq.ResumeLayout(False)
        CType(Me.gbxLugarEntrega, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxLugarEntrega.ResumeLayout(False)
        CType(Me.gbxComunicaPedidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxComunicaPedidos.ResumeLayout(False)
        CType(Me.gbxDirPago, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxDirPago.ResumeLayout(False)
        Me.gbxDirPago.PerformLayout()
        CType(Me.pnlTelfPago, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTelfPago.ResumeLayout(False)
        CType(Me.pnlSpace6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlDirS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pvpEvaluacion.ResumeLayout(False)
        CType(Me.pnlEvaS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pvpDatosGenerales As CustomControls.PageViewPage
    Friend WithEvents pnlGenIzq As CustomControls.Panel
    Friend WithEvents pnlGenDer As CustomControls.Panel
    Friend WithEvents dirPrincipal As CustomControls.DataDir
    Friend WithEvents pnlTelefonos As CustomControls.Panel
    Friend WithEvents pnlSpace3 As CustomControls.Panel
    Friend WithEvents dtfMovil As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace4 As CustomControls.Panel
    Friend WithEvents dtfFax As CustomControls.DatafieldLabel
    Friend WithEvents dtfTelefonos As CustomControls.DatafieldLabel
    Friend WithEvents dtfEMail As CustomControls.DatafieldLabel
    Friend WithEvents dtfWeb As CustomControls.DatafieldLabel
    Friend WithEvents dtfContacto As CustomControls.DatafieldLabel
    Friend WithEvents pnlFaltaFbaja As CustomControls.Panel
    Friend WithEvents dtdFBaja As CustomControls.DataDateLabel
    Friend WithEvents pnlSpace5 As CustomControls.Panel
    Friend WithEvents dtdFAlta As CustomControls.DataDateLabel
    Friend WithEvents dtaNotas As CustomControls.DataAreaLabel
    Friend WithEvents dtaObservaciones As CustomControls.DataAreaLabel
    Friend WithEvents pvpFacturacionContable As CustomControls.PageViewPage
    Friend WithEvents pnlOtros As CustomControls.Panel
    Friend WithEvents pnlEmpOfi As CustomControls.Panel
    Friend WithEvents dtfOficina As CustomControls.DualDatafieldLabel
    Friend WithEvents pnlSpace10 As CustomControls.Panel
    Friend WithEvents dtfEmpresa As CustomControls.DualDatafieldLabel
    Friend WithEvents pnlBottomGen As CustomControls.Panel
    Friend WithEvents dtlUltmodi As CustomControls.DataLabel
    Friend WithEvents dtlUsumodi As CustomControls.DataLabel
    Friend WithEvents pvpDelegaciones As CustomControls.PageViewPage
    Friend WithEvents pvpContactos As CustomControls.PageViewPage
    Friend WithEvents dgvDelegacion As Karve.frm.Proveedores.GridDelegacion
    Friend WithEvents dgvContactos As Karve.frm.Proveedores.GridContactos
    Friend WithEvents pvpAcumulados As CustomControls.PageViewPage
    Friend WithEvents pvpVisitas As CustomControls.PageViewPage
    Friend WithEvents pvpDirecciones As CustomControls.PageViewPage
    Friend WithEvents pvpEvaluacion As CustomControls.PageViewPage
    Friend WithEvents pnlDireccDer As CustomControls.Panel
    Friend WithEvents pnlDireccIzq As CustomControls.Panel
    Friend WithEvents gbxDireDevo As CustomControls.GroupBox
    Friend WithEvents dtfEmailDevo As CustomControls.DatafieldLabel
    Friend WithEvents dtfPersonaDevo As CustomControls.DatafieldLabel
    Friend WithEvents pnlTelfDevo As CustomControls.Panel
    Friend WithEvents dtfTelfDevo As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace8 As CustomControls.Panel
    Friend WithEvents dtfFaxDevo As CustomControls.DatafieldLabel
    Friend WithEvents dtdDevo As CustomControls.DataDir
    Friend WithEvents gbxDirReclama As CustomControls.GroupBox
    Friend WithEvents dtfEmailReclama As CustomControls.DatafieldLabel
    Friend WithEvents dtfPersonaReclama As CustomControls.DatafieldLabel
    Friend WithEvents pnlTelfReclama As CustomControls.Panel
    Friend WithEvents dtfTelfReclama As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace7 As CustomControls.Panel
    Friend WithEvents dtfFaxReclama As CustomControls.DatafieldLabel
    Friend WithEvents dtdReclama As CustomControls.DataDir
    Friend WithEvents gbxComunicaPedidos As CustomControls.GroupBox
    Friend WithEvents gbxDirPago As CustomControls.GroupBox
    Friend WithEvents dtfEmailPago As CustomControls.DatafieldLabel
    Friend WithEvents dtfPersonaPago As CustomControls.DatafieldLabel
    Friend WithEvents pnlTelfPago As CustomControls.Panel
    Friend WithEvents dtfTelfPago As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace6 As CustomControls.Panel
    Friend WithEvents dtfFaxPago As CustomControls.DatafieldLabel
    Friend WithEvents dtdPago As CustomControls.DataDir
    Friend WithEvents gbxLugarEntrega As CustomControls.GroupBox
    Friend WithEvents dtfCondicionVentaComunicaPedidos As CustomControls.DualDatafieldLabel
    Friend WithEvents dtfFEntregaComunicaPedidos As CustomControls.DualDatafieldLabel
    Friend WithEvents dtfEmailComunicaPedidos As CustomControls.DatafieldLabel
    Friend WithEvents dtfViaComunicaPedidos As CustomControls.DualDatafieldLabel
    Friend WithEvents dtfLuentre6 As CustomControls.Datafield
    Friend WithEvents dtfLuentre5 As CustomControls.Datafield
    Friend WithEvents dtfLuentre4 As CustomControls.Datafield
    Friend WithEvents dtfLuentre3 As CustomControls.Datafield
    Friend WithEvents dtfLuentre2 As CustomControls.Datafield
    Friend WithEvents dtfLuentre1 As CustomControls.Datafield
    Friend WithEvents pnlFacturacion As CustomControls.Panel
    Friend WithEvents pnlContables As CustomControls.Panel
    Friend WithEvents pnlCtaContable As CustomControls.Panel
    Friend WithEvents dtfCtaContable As CustomControls.DualDatafieldLabel
    Friend WithEvents pnlSpace11 As CustomControls.Panel
    Friend WithEvents dtfPrefijoCta As CustomControls.DatafieldLabel
    Friend WithEvents gbxFacturacion As CustomControls.GroupBox
    Friend WithEvents gbxContable As CustomControls.GroupBox
    Friend WithEvents dtfCtaCompGasto As CustomControls.DualDatafieldLabel
    Friend WithEvents dtfSaldo As CustomControls.DatafieldLabel
    Friend WithEvents pnlRetencion As CustomControls.Panel
    Friend WithEvents pnlSpace12 As CustomControls.Panel
    Friend WithEvents dtfCtaRetencion As CustomControls.DualDatafieldLabel
    Friend WithEvents dtfPorcenRetencion As CustomControls.DatafieldLabel
    Friend WithEvents dtfCtaPago As CustomControls.DualDatafieldLabel
    Friend WithEvents dtfIntracoRepercutido As CustomControls.DualDatafieldLabel
    Friend WithEvents dtfIntracoSoportado As CustomControls.DualDatafieldLabel
    Friend WithEvents dtfCtaGastoAbono As CustomControls.DualDatafieldLabel
    Friend WithEvents gbxLeasings As CustomControls.GroupBox
    Friend WithEvents dtfCtaLp As CustomControls.DualDatafieldLabel
    Friend WithEvents dtfCtaCP As CustomControls.DualDatafieldLabel
    Friend WithEvents dtcLeasing As CustomControls.DataCheck
    Friend WithEvents gbxIntracomunitario As CustomControls.GroupBox
    Friend WithEvents dtcNoAparecer347349 As CustomControls.DataCheck
    Friend WithEvents rdgTipoCompra As CustomControls.RadioGroup
    Friend WithEvents dtrInmovilizado As CustomControls.DataRadio
    Friend WithEvents dtrGasto As CustomControls.DataRadio
    Friend WithEvents dtrCompra As CustomControls.DataRadio
    Friend WithEvents pnlCtaCompGasto As CustomControls.Panel
    Friend WithEvents pnlSpace13 As CustomControls.Panel
    Friend WithEvents btnCompGastoAplicar As CustomControls.Button
    Friend WithEvents dftFormaPago As CustomControls.DualDatafieldLabel
    Friend WithEvents pnlPlazosPago As CustomControls.Panel
    Friend WithEvents pnlSpace18 As CustomControls.Panel
    Friend WithEvents dtfDiaPago2 As CustomControls.Datafield
    Friend WithEvents pnlSpace17 As CustomControls.Panel
    Friend WithEvents dtfDiaPago As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace14 As CustomControls.Panel
    Friend WithEvents dtfPlazoPago As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace16 As CustomControls.Panel
    Friend WithEvents dtfPlazoPago3 As CustomControls.Datafield
    Friend WithEvents pnlSpace15 As CustomControls.Panel
    Friend WithEvents dtfPlazoPago2 As CustomControls.Datafield
    Friend WithEvents dtfDiaPago3 As CustomControls.Datafield
    Friend WithEvents pnlVacaciones As CustomControls.Panel
    Friend WithEvents pnlSpace19 As CustomControls.Panel
    Friend WithEvents dtfMesVacaciones2 As CustomControls.DualDatafield
    Friend WithEvents dtfMesVacaciones As CustomControls.DualDatafieldLabel
    Friend WithEvents pnlIbanSwift As CustomControls.Panel
    Friend WithEvents dtfIban As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace20 As CustomControls.Panel
    Friend WithEvents dtfSwift As CustomControls.DatafieldLabel
    Friend WithEvents dtfCC As CustomControls.DatafieldLabel
    Friend WithEvents pnlDtos As CustomControls.Panel
    Friend WithEvents dtfDtoPP As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace22 As CustomControls.Panel
    Friend WithEvents pnlSpace21 As CustomControls.Panel
    Friend WithEvents dtfDTO As CustomControls.DatafieldLabel
    Friend WithEvents dtfTipoIVA As CustomControls.DatafieldLabel
    Friend WithEvents dtfBanco As CustomControls.DualDatafieldLabel
    Friend WithEvents PnlIdiomaDivisa As CustomControls.Panel
    Friend WithEvents pnlSpace23 As CustomControls.Panel
    Friend WithEvents dftIdioma As CustomControls.DualDatafieldLabel
    Friend WithEvents DualDatafieldLabel2 As CustomControls.DualDatafieldLabel
    Friend WithEvents pnlChecks As CustomControls.Panel
    Friend WithEvents dtcEsIntracomunitario As CustomControls.DataCheck
    Friend WithEvents dtcGestAlba As CustomControls.DataCheck
    Friend WithEvents dtcMargenNoAuto As CustomControls.DataCheck
    Friend WithEvents dtcGestIvaImportacion As CustomControls.DataCheck
    Friend WithEvents pnlChecks2 As CustomControls.Panel
    Friend WithEvents dtcAlbaranesCosteTransp As CustomControls.DataCheck
    Friend WithEvents dtcExenOperInter As CustomControls.DataCheck
    Friend WithEvents pnlChecksIzq As CustomControls.Panel
    Friend WithEvents dtcAutoFacMante As CustomControls.DataCheck
    Friend WithEvents Panel1 As CustomControls.Panel
    Friend WithEvents DatafieldLabel1 As CustomControls.DatafieldLabel
    Friend WithEvents Panel2 As CustomControls.Panel
    Friend WithEvents DatafieldLabel2 As CustomControls.DatafieldLabel
    Friend WithEvents Panel3 As CustomControls.Panel
    Friend WithEvents DatafieldLabel3 As CustomControls.DatafieldLabel
    Friend WithEvents pnlGenS As CustomControls.Panel
    Friend WithEvents pnlFacContaS As CustomControls.Panel
    Friend WithEvents pnlDelegaS As CustomControls.Panel
    Friend WithEvents pnlContactosS As CustomControls.Panel
    Friend WithEvents pnlVisitasS As CustomControls.Panel
    Friend WithEvents pnlDirS As CustomControls.Panel
    Friend WithEvents pnlEvaS As CustomControls.Panel
    Friend WithEvents pnlAcumS As CustomControls.Panel
    Friend WithEvents pnlGen As CustomControls.Panel
    Friend WithEvents pnlGenF As CustomControls.Panel
    Friend WithEvents pnlNifNombre As CustomControls.Panel
    Friend WithEvents dtfNombre As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace2 As CustomControls.Panel
    Friend WithEvents dtfNif As CustomControls.DatafieldLabel
    Friend WithEvents pnlCodigo As CustomControls.Panel
    Friend WithEvents dtfNombreComercial As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace1 As CustomControls.Panel
    Friend WithEvents dtfCodigo As CustomControls.DatafieldLabel
    Friend WithEvents pnlGenR As CustomControls.Panel
    Friend WithEvents dtfTipoProvee As CustomControls.DualDatafieldLabel
End Class
