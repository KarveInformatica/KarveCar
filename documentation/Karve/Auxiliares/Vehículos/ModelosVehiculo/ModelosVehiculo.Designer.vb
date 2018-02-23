<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ModelosVehiculo
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
        Me.pvpGeneral = New CustomControls.PageViewPage()
        Me.pnlGenRight = New CustomControls.Panel()
        Me.grbR = New CustomControls.GroupBox()
        Me.pnlOtros = New CustomControls.Panel()
        Me.Panel1 = New CustomControls.Panel()
        Me.pnlOtrosL2 = New CustomControls.Panel()
        Me.DatafieldLabel3 = New CustomControls.DatafieldLabel()
        Me.DatafieldLabel4 = New CustomControls.DatafieldLabel()
        Me.pnlSeparator_2 = New CustomControls.Panel()
        Me.pnlOtrosL = New CustomControls.Panel()
        Me.DatafieldLabel2 = New CustomControls.DatafieldLabel()
        Me.DatafieldLabel1 = New CustomControls.DatafieldLabel()
        Me.dtfObs = New CustomControls.DataAreaLabel()
        Me.dtfSeguridad = New CustomControls.DataAreaLabel()
        Me.dtfMotor = New CustomControls.DatafieldLabel()
        Me.dtfCilindrada = New CustomControls.DatafieldLabel()
        Me.dtfPrefijoBastidor = New CustomControls.DatafieldLabel()
        Me.pnlMantecada = New CustomControls.Panel()
        Me.dtfMantecada = New CustomControls.DatafieldLabel()
        Me.pnlMantecadaR = New CustomControls.Panel()
        Me.dfMantecada = New CustomControls.Datafield()
        Me.pnlConsumo = New CustomControls.Panel()
        Me.dtfConsumo = New CustomControls.DatafieldLabel()
        Me.pnlConsumoR = New CustomControls.Panel()
        Me.dfConsumo = New CustomControls.Datafield()
        Me.pnlDeposito = New CustomControls.Panel()
        Me.dtfDeposito = New CustomControls.DatafieldLabel()
        Me.pnlDepositoLiteral = New CustomControls.Panel()
        Me.dfDeposito = New CustomControls.Datafield()
        Me.pnlGenLeft = New CustomControls.Panel()
        Me.grbGenOps = New CustomControls.GroupBox()
        Me.pnlOpsR = New CustomControls.Panel()
        Me.dtfPlazas = New CustomControls.DatafieldLabel()
        Me.dtfPuertas = New CustomControls.DatafieldLabel()
        Me.dtfAirbags = New CustomControls.DatafieldLabel()
        Me.pnlLeftOps = New CustomControls.Panel()
        Me.pnlRightOpsCh = New CustomControls.Panel()
        Me.chhDirAsis = New CustomControls.DataCheck()
        Me.chkAbs = New CustomControls.DataCheck()
        Me.pnlLeftOpsCh = New CustomControls.Panel()
        Me.chkAA = New CustomControls.DataCheck()
        Me.chkRadio = New CustomControls.DataCheck()
        Me.rdgTipoCombus = New CustomControls.RadioGroup()
        Me.dtsElectrico = New CustomControls.DataRadio()
        Me.dtrGasolina = New CustomControls.DataRadio()
        Me.dtrDiesel = New CustomControls.DataRadio()
        Me.rdgTipoCambio = New CustomControls.RadioGroup()
        Me.dtrCambioSem = New CustomControls.DataRadio()
        Me.dtrCambioAut = New CustomControls.DataRadio()
        Me.dtrCambioMan = New CustomControls.DataRadio()
        Me.pnlSeparator_1 = New CustomControls.Panel()
        Me.grbGen = New CustomControls.GroupBox()
        Me.dtaExtra = New CustomControls.DataAreaLabel()
        Me.pnlFechas = New CustomControls.Panel()
        Me.pnlFecBaja = New CustomControls.Panel()
        Me.dtdFecBaja = New CustomControls.DataDateLabel()
        Me.pnlFecMod = New CustomControls.Panel()
        Me.dtdFecMod = New CustomControls.DataDateLabel()
        Me.dtfDescLlavero = New CustomControls.DatafieldLabel()
        Me.dtfGrupo = New CustomControls.DualDatafieldLabel()
        Me.dtfReferencia = New CustomControls.DatafieldLabel()
        Me.pnlPpalSoporte = New CustomControls.Panel()
        Me.pnlPpal = New CustomControls.Panel()
        Me.pnlPie = New CustomControls.Panel()
        Me.pnlCodVarMar = New CustomControls.Panel()
        Me.dtfNombre = New CustomControls.DatafieldLabel()
        Me.pnlCodVar = New CustomControls.Panel()
        Me.dfVariante = New CustomControls.Datafield()
        Me.pnlCiegoCodModVar = New CustomControls.Panel()
        Me.dtfCod = New CustomControls.DatafieldLabel()
        Me.pnlLeftMargin = New CustomControls.Panel()
        Me.pnlCodigo = New CustomControls.Panel()
        Me.pnlMarca = New CustomControls.Panel()
        Me.dtfMarca = New CustomControls.DualDataFieldEditableLabel()
        Me.pnlCiego = New CustomControls.Panel()
        Me.dtfCodigo = New CustomControls.DatafieldLabel()
        Me.pnlLeftMarginCodigo = New CustomControls.Panel()
        Me.pnlBottomGen = New CustomControls.Panel()
        Me.dtlUltmodi = New CustomControls.DataLabel()
        Me.dtlUsumodi = New CustomControls.DataLabel()
        Me.pvpMantenimientos = New CustomControls.PageViewPage()
        Me.pnlManSoporte = New CustomControls.Panel()
        Me.pvpFoto = New CustomControls.PageViewPage()
        Me.pnlFotoSoporte = New CustomControls.Panel()
        Me.pvpExtras = New CustomControls.PageViewPage()
        Me.dgvExtras = New Karve.frm.Auxiliares.GridExtras()
        Me.pnlExtrasSoporte = New CustomControls.Panel()
        Me.pvpFichaTecnica = New CustomControls.PageViewPage()
        Me.ftecModelo = New Karve.frm.Auxiliares.FichaTecnica()
        Me.pnlFtecSoporte = New CustomControls.Panel()
        CType(Me.pnlBlock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pvwBase, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pvwBase.SuspendLayout()
        CType(Me.stbBase, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pvpGeneral.SuspendLayout()
        CType(Me.pnlGenRight, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlGenRight.SuspendLayout()
        CType(Me.grbR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbR.SuspendLayout()
        CType(Me.pnlOtros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlOtros.SuspendLayout()
        CType(Me.Panel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.pnlOtrosL2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlOtrosL2.SuspendLayout()
        CType(Me.pnlSeparator_2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlOtrosL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlOtrosL.SuspendLayout()
        CType(Me.pnlMantecada, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMantecada.SuspendLayout()
        CType(Me.pnlMantecadaR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMantecadaR.SuspendLayout()
        CType(Me.pnlConsumo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlConsumo.SuspendLayout()
        CType(Me.pnlConsumoR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlConsumoR.SuspendLayout()
        CType(Me.pnlDeposito, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDeposito.SuspendLayout()
        CType(Me.pnlDepositoLiteral, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDepositoLiteral.SuspendLayout()
        CType(Me.pnlGenLeft, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlGenLeft.SuspendLayout()
        CType(Me.grbGenOps, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbGenOps.SuspendLayout()
        CType(Me.pnlOpsR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlOpsR.SuspendLayout()
        CType(Me.pnlLeftOps, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlLeftOps.SuspendLayout()
        CType(Me.pnlRightOpsCh, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlRightOpsCh.SuspendLayout()
        CType(Me.chhDirAsis, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkAbs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlLeftOpsCh, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlLeftOpsCh.SuspendLayout()
        CType(Me.chkAA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkRadio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rdgTipoCombus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rdgTipoCombus.SuspendLayout()
        CType(Me.dtsElectrico, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtrGasolina, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtrDiesel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rdgTipoCambio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rdgTipoCambio.SuspendLayout()
        CType(Me.dtrCambioSem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtrCambioAut, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtrCambioMan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSeparator_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grbGen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbGen.SuspendLayout()
        CType(Me.pnlFechas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFechas.SuspendLayout()
        CType(Me.pnlFecBaja, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFecBaja.SuspendLayout()
        CType(Me.pnlFecMod, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFecMod.SuspendLayout()
        CType(Me.pnlPpalSoporte, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPpalSoporte.SuspendLayout()
        CType(Me.pnlPpal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPpal.SuspendLayout()
        CType(Me.pnlPie, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlCodVarMar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCodVarMar.SuspendLayout()
        CType(Me.pnlCodVar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCodVar.SuspendLayout()
        CType(Me.pnlCiegoCodModVar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlLeftMargin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlCodigo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCodigo.SuspendLayout()
        CType(Me.pnlMarca, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMarca.SuspendLayout()
        CType(Me.pnlCiego, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlLeftMarginCodigo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlBottomGen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBottomGen.SuspendLayout()
        CType(Me.dtlUltmodi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtlUsumodi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pvpMantenimientos.SuspendLayout()
        CType(Me.pnlManSoporte, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pvpFoto.SuspendLayout()
        CType(Me.pnlFotoSoporte, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pvpExtras.SuspendLayout()
        CType(Me.dgvExtras, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvExtras.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlExtrasSoporte, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pvpFichaTecnica.SuspendLayout()
        CType(Me.pnlFtecSoporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlBlock
        '
        Me.pnlBlock.Location = New System.Drawing.Point(0, 429)
        '
        'pvwBase
        '
        Me.pvwBase.Controls.Add(Me.pvpGeneral)
        Me.pvwBase.Controls.Add(Me.pvpMantenimientos)
        Me.pvwBase.Controls.Add(Me.pvpFoto)
        Me.pvwBase.Controls.Add(Me.pvpExtras)
        Me.pvwBase.Controls.Add(Me.pvpFichaTecnica)
        Me.pvwBase.SelectedPage = Me.pvpFichaTecnica
        Me.pvwBase.Size = New System.Drawing.Size(1077, 499)
        Me.pvwBase.Text = ""
        CType(Me.pvwBase.GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.StripViewItemLayout).BorderInnerColor = System.Drawing.SystemColors.Control
        '
        'stbBase
        '
        Me.stbBase.Location = New System.Drawing.Point(0, 499)
        Me.stbBase.Size = New System.Drawing.Size(1077, 25)
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
        Me.pvpGeneral.Controls.Add(Me.pnlGenRight)
        Me.pvpGeneral.Controls.Add(Me.pnlGenLeft)
        Me.pvpGeneral.Controls.Add(Me.pnlPpalSoporte)
        Me.pvpGeneral.ItemSize = New System.Drawing.SizeF(102.0!, 23.0!)
        Me.pvpGeneral.Location = New System.Drawing.Point(129, 5)
        Me.pvpGeneral.Name = "pvpGeneral"
        Me.pvpGeneral.PanelCabezeraContainer = Nothing
        Me.pvpGeneral.Size = New System.Drawing.Size(943, 489)
        Me.pvpGeneral.Text = "General"
        '
        'pnlGenRight
        '
        Me.pnlGenRight.Auto_Size = False
        Me.pnlGenRight.BackColor = System.Drawing.SystemColors.Control
        Me.pnlGenRight.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlGenRight.ChangeDock = True
        Me.pnlGenRight.Control_Resize = False
        Me.pnlGenRight.Controls.Add(Me.grbR)
        Me.pnlGenRight.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlGenRight.isSpace = False
        Me.pnlGenRight.Location = New System.Drawing.Point(470, 64)
        Me.pnlGenRight.Name = "pnlGenRight"
        Me.pnlGenRight.numRows = 0
        Me.pnlGenRight.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.pnlGenRight.Reorder = True
        Me.pnlGenRight.Size = New System.Drawing.Size(470, 425)
        Me.pnlGenRight.TabIndex = 1
        '
        'grbR
        '
        Me.grbR.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.grbR.Controls.Add(Me.pnlOtros)
        Me.grbR.Controls.Add(Me.dtfObs)
        Me.grbR.Controls.Add(Me.dtfSeguridad)
        Me.grbR.Controls.Add(Me.dtfMotor)
        Me.grbR.Controls.Add(Me.dtfCilindrada)
        Me.grbR.Controls.Add(Me.dtfPrefijoBastidor)
        Me.grbR.Controls.Add(Me.pnlMantecada)
        Me.grbR.Controls.Add(Me.pnlConsumo)
        Me.grbR.Controls.Add(Me.pnlDeposito)
        Me.grbR.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbR.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.grbR.HeaderText = ""
        Me.grbR.Location = New System.Drawing.Point(6, 0)
        Me.grbR.Name = "grbR"
        Me.grbR.numRows = 0
        Me.grbR.Padding = New System.Windows.Forms.Padding(6)
        Me.grbR.Reorder = True
        Me.grbR.Size = New System.Drawing.Size(464, 425)
        Me.grbR.TabIndex = 0
        Me.grbR.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.grbR.ThemeName = "Windows8"
        Me.grbR.Title = ""
        '
        'pnlOtros
        '
        Me.pnlOtros.Auto_Size = False
        Me.pnlOtros.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlOtros.ChangeDock = True
        Me.pnlOtros.Control_Resize = False
        Me.pnlOtros.Controls.Add(Me.Panel1)
        Me.pnlOtros.Controls.Add(Me.pnlOtrosL)
        Me.pnlOtros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlOtros.isSpace = False
        Me.pnlOtros.Location = New System.Drawing.Point(6, 347)
        Me.pnlOtros.Name = "pnlOtros"
        Me.pnlOtros.numRows = 0
        Me.pnlOtros.Reorder = True
        Me.pnlOtros.Size = New System.Drawing.Size(452, 56)
        Me.pnlOtros.TabIndex = 8
        '
        'Panel1
        '
        Me.Panel1.Auto_Size = False
        Me.Panel1.BorderColor = System.Drawing.SystemColors.Control
        Me.Panel1.ChangeDock = True
        Me.Panel1.Control_Resize = False
        Me.Panel1.Controls.Add(Me.pnlOtrosL2)
        Me.Panel1.Controls.Add(Me.pnlSeparator_2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.isSpace = False
        Me.Panel1.Location = New System.Drawing.Point(159, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.numRows = 0
        Me.Panel1.Reorder = True
        Me.Panel1.Size = New System.Drawing.Size(293, 56)
        Me.Panel1.TabIndex = 1
        '
        'pnlOtrosL2
        '
        Me.pnlOtrosL2.Auto_Size = False
        Me.pnlOtrosL2.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlOtrosL2.ChangeDock = True
        Me.pnlOtrosL2.Control_Resize = False
        Me.pnlOtrosL2.Controls.Add(Me.DatafieldLabel3)
        Me.pnlOtrosL2.Controls.Add(Me.DatafieldLabel4)
        Me.pnlOtrosL2.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlOtrosL2.isSpace = False
        Me.pnlOtrosL2.Location = New System.Drawing.Point(6, 0)
        Me.pnlOtrosL2.Name = "pnlOtrosL2"
        Me.pnlOtrosL2.numRows = 0
        Me.pnlOtrosL2.Reorder = True
        Me.pnlOtrosL2.Size = New System.Drawing.Size(169, 56)
        Me.pnlOtrosL2.TabIndex = 1
        '
        'DatafieldLabel3
        '
        Me.DatafieldLabel3.Allow_Empty = True
        Me.DatafieldLabel3.Allow_Negative = True
        Me.DatafieldLabel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.DatafieldLabel3.BackColor = System.Drawing.SystemColors.Control
        Me.DatafieldLabel3.Data_Allowed = CustomControls.Datafield.List_Data.nDouble
        Me.DatafieldLabel3.DataField = "IMPUESTO"
        Me.DatafieldLabel3.DataTable = "MOD"
        Me.DatafieldLabel3.Descripcion = "Impuesto"
        Me.DatafieldLabel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.DatafieldLabel3.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.DatafieldLabel3.FocoEnAgregar = False
        Me.DatafieldLabel3.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.DatafieldLabel3.Image = Nothing
        Me.DatafieldLabel3.Label_Space = 90
        Me.DatafieldLabel3.Length_Data = 32767
        Me.DatafieldLabel3.Location = New System.Drawing.Point(0, 26)
        Me.DatafieldLabel3.Max_Value = 0.0R
        Me.DatafieldLabel3.MensajeIncorrectoCustom = Nothing
        Me.DatafieldLabel3.Name = "DatafieldLabel3"
        Me.DatafieldLabel3.Null_on_Empty = True
        Me.DatafieldLabel3.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.DatafieldLabel3.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.DatafieldLabel3.ReadOnly_Data = False
        Me.DatafieldLabel3.Show_Button = False
        Me.DatafieldLabel3.Size = New System.Drawing.Size(169, 26)
        Me.DatafieldLabel3.TabIndex = 1
        Me.DatafieldLabel3.Text_Data = ""
        Me.DatafieldLabel3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.DatafieldLabel3.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.DatafieldLabel3.TopPadding = 0
        Me.DatafieldLabel3.Upper_Case = False
        Me.DatafieldLabel3.Validate_on_lost_focus = True
        '
        'DatafieldLabel4
        '
        Me.DatafieldLabel4.Allow_Empty = True
        Me.DatafieldLabel4.Allow_Negative = True
        Me.DatafieldLabel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.DatafieldLabel4.BackColor = System.Drawing.SystemColors.Control
        Me.DatafieldLabel4.Data_Allowed = CustomControls.Datafield.List_Data.nDouble
        Me.DatafieldLabel4.DataField = "CO2_GRxKM"
        Me.DatafieldLabel4.DataTable = "MOD"
        Me.DatafieldLabel4.Descripcion = "Emisiones CO2"
        Me.DatafieldLabel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.DatafieldLabel4.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.DatafieldLabel4.FocoEnAgregar = False
        Me.DatafieldLabel4.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.DatafieldLabel4.Image = Nothing
        Me.DatafieldLabel4.Label_Space = 90
        Me.DatafieldLabel4.Length_Data = 32767
        Me.DatafieldLabel4.Location = New System.Drawing.Point(0, 0)
        Me.DatafieldLabel4.Max_Value = 0.0R
        Me.DatafieldLabel4.MensajeIncorrectoCustom = Nothing
        Me.DatafieldLabel4.Name = "DatafieldLabel4"
        Me.DatafieldLabel4.Null_on_Empty = True
        Me.DatafieldLabel4.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.DatafieldLabel4.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.DatafieldLabel4.ReadOnly_Data = False
        Me.DatafieldLabel4.Show_Button = False
        Me.DatafieldLabel4.Size = New System.Drawing.Size(169, 26)
        Me.DatafieldLabel4.TabIndex = 0
        Me.DatafieldLabel4.Text_Data = ""
        Me.DatafieldLabel4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.DatafieldLabel4.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.DatafieldLabel4.TopPadding = 0
        Me.DatafieldLabel4.Upper_Case = False
        Me.DatafieldLabel4.Validate_on_lost_focus = True
        '
        'pnlSeparator_2
        '
        Me.pnlSeparator_2.Auto_Size = False
        Me.pnlSeparator_2.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSeparator_2.ChangeDock = True
        Me.pnlSeparator_2.Control_Resize = False
        Me.pnlSeparator_2.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSeparator_2.isSpace = True
        Me.pnlSeparator_2.Location = New System.Drawing.Point(0, 0)
        Me.pnlSeparator_2.Name = "pnlSeparator_2"
        Me.pnlSeparator_2.numRows = 0
        Me.pnlSeparator_2.Reorder = True
        Me.pnlSeparator_2.Size = New System.Drawing.Size(6, 56)
        Me.pnlSeparator_2.TabIndex = 0
        '
        'pnlOtrosL
        '
        Me.pnlOtrosL.Auto_Size = False
        Me.pnlOtrosL.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlOtrosL.ChangeDock = True
        Me.pnlOtrosL.Control_Resize = False
        Me.pnlOtrosL.Controls.Add(Me.DatafieldLabel2)
        Me.pnlOtrosL.Controls.Add(Me.DatafieldLabel1)
        Me.pnlOtrosL.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlOtrosL.isSpace = False
        Me.pnlOtrosL.Location = New System.Drawing.Point(0, 0)
        Me.pnlOtrosL.Name = "pnlOtrosL"
        Me.pnlOtrosL.numRows = 0
        Me.pnlOtrosL.Reorder = True
        Me.pnlOtrosL.Size = New System.Drawing.Size(159, 56)
        Me.pnlOtrosL.TabIndex = 0
        '
        'DatafieldLabel2
        '
        Me.DatafieldLabel2.Allow_Empty = True
        Me.DatafieldLabel2.Allow_Negative = True
        Me.DatafieldLabel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.DatafieldLabel2.BackColor = System.Drawing.SystemColors.Control
        Me.DatafieldLabel2.Data_Allowed = CustomControls.Datafield.List_Data.nDouble
        Me.DatafieldLabel2.DataField = "PVP"
        Me.DatafieldLabel2.DataTable = "MOD"
        Me.DatafieldLabel2.Descripcion = "Precio Venta"
        Me.DatafieldLabel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.DatafieldLabel2.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.DatafieldLabel2.FocoEnAgregar = False
        Me.DatafieldLabel2.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.DatafieldLabel2.Image = Nothing
        Me.DatafieldLabel2.Label_Space = 90
        Me.DatafieldLabel2.Length_Data = 32767
        Me.DatafieldLabel2.Location = New System.Drawing.Point(0, 26)
        Me.DatafieldLabel2.Max_Value = 0.0R
        Me.DatafieldLabel2.MensajeIncorrectoCustom = Nothing
        Me.DatafieldLabel2.Name = "DatafieldLabel2"
        Me.DatafieldLabel2.Null_on_Empty = True
        Me.DatafieldLabel2.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.DatafieldLabel2.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.DatafieldLabel2.ReadOnly_Data = False
        Me.DatafieldLabel2.Show_Button = False
        Me.DatafieldLabel2.Size = New System.Drawing.Size(159, 26)
        Me.DatafieldLabel2.TabIndex = 1
        Me.DatafieldLabel2.Text_Data = ""
        Me.DatafieldLabel2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.DatafieldLabel2.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.DatafieldLabel2.TopPadding = 0
        Me.DatafieldLabel2.Upper_Case = False
        Me.DatafieldLabel2.Validate_on_lost_focus = True
        '
        'DatafieldLabel1
        '
        Me.DatafieldLabel1.Allow_Empty = True
        Me.DatafieldLabel1.Allow_Negative = True
        Me.DatafieldLabel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.DatafieldLabel1.BackColor = System.Drawing.SystemColors.Control
        Me.DatafieldLabel1.Data_Allowed = CustomControls.Datafield.List_Data.nDouble
        Me.DatafieldLabel1.DataField = "PCOMPRA"
        Me.DatafieldLabel1.DataTable = "MOD"
        Me.DatafieldLabel1.Descripcion = "Precio Compra"
        Me.DatafieldLabel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.DatafieldLabel1.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.DatafieldLabel1.FocoEnAgregar = False
        Me.DatafieldLabel1.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.DatafieldLabel1.Image = Nothing
        Me.DatafieldLabel1.Label_Space = 90
        Me.DatafieldLabel1.Length_Data = 32767
        Me.DatafieldLabel1.Location = New System.Drawing.Point(0, 0)
        Me.DatafieldLabel1.Max_Value = 0.0R
        Me.DatafieldLabel1.MensajeIncorrectoCustom = Nothing
        Me.DatafieldLabel1.Name = "DatafieldLabel1"
        Me.DatafieldLabel1.Null_on_Empty = True
        Me.DatafieldLabel1.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.DatafieldLabel1.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.DatafieldLabel1.ReadOnly_Data = False
        Me.DatafieldLabel1.Show_Button = False
        Me.DatafieldLabel1.Size = New System.Drawing.Size(159, 26)
        Me.DatafieldLabel1.TabIndex = 0
        Me.DatafieldLabel1.Text_Data = ""
        Me.DatafieldLabel1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.DatafieldLabel1.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.DatafieldLabel1.TopPadding = 0
        Me.DatafieldLabel1.Upper_Case = False
        Me.DatafieldLabel1.Validate_on_lost_focus = True
        '
        'dtfObs
        '
        Me.dtfObs.Allow_Empty = True
        Me.dtfObs.Allow_Negative = True
        Me.dtfObs.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfObs.BackColor = System.Drawing.SystemColors.Control
        Me.dtfObs.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfObs.DataField = "OBS1"
        Me.dtfObs.DataTable = "MOD"
        Me.dtfObs.Descripcion = "Observaciones"
        Me.dtfObs.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfObs.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfObs.FocoEnAgregar = False
        Me.dtfObs.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfObs.Length_Data = 32767
        Me.dtfObs.Location = New System.Drawing.Point(6, 256)
        Me.dtfObs.Max_Value = 0.0R
        Me.dtfObs.MensajeIncorrectoCustom = Nothing
        Me.dtfObs.Name = "dtfObs"
        Me.dtfObs.Null_on_Empty = True
        Me.dtfObs.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfObs.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfObs.ReadOnly_Data = False
        Me.dtfObs.Size = New System.Drawing.Size(452, 91)
        Me.dtfObs.TabIndex = 7
        Me.dtfObs.Text_Data = ""
        Me.dtfObs.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfObs.TopPadding = 0
        Me.dtfObs.Upper_Case = False
        Me.dtfObs.Validate_on_lost_focus = True
        '
        'dtfSeguridad
        '
        Me.dtfSeguridad.Allow_Empty = True
        Me.dtfSeguridad.Allow_Negative = True
        Me.dtfSeguridad.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfSeguridad.BackColor = System.Drawing.SystemColors.Control
        Me.dtfSeguridad.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfSeguridad.DataField = "SEGURI_MOD"
        Me.dtfSeguridad.DataTable = "MOD"
        Me.dtfSeguridad.Descripcion = "Seguridad"
        Me.dtfSeguridad.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfSeguridad.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfSeguridad.FocoEnAgregar = False
        Me.dtfSeguridad.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfSeguridad.Length_Data = 32767
        Me.dtfSeguridad.Location = New System.Drawing.Point(6, 165)
        Me.dtfSeguridad.Max_Value = 0.0R
        Me.dtfSeguridad.MensajeIncorrectoCustom = Nothing
        Me.dtfSeguridad.Name = "dtfSeguridad"
        Me.dtfSeguridad.Null_on_Empty = True
        Me.dtfSeguridad.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfSeguridad.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfSeguridad.ReadOnly_Data = False
        Me.dtfSeguridad.Size = New System.Drawing.Size(452, 91)
        Me.dtfSeguridad.TabIndex = 6
        Me.dtfSeguridad.Text_Data = ""
        Me.dtfSeguridad.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfSeguridad.TopPadding = 0
        Me.dtfSeguridad.Upper_Case = False
        Me.dtfSeguridad.Validate_on_lost_focus = True
        '
        'dtfMotor
        '
        Me.dtfMotor.Allow_Empty = True
        Me.dtfMotor.Allow_Negative = True
        Me.dtfMotor.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfMotor.BackColor = System.Drawing.SystemColors.Control
        Me.dtfMotor.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfMotor.DataField = "MOTOR_MOD"
        Me.dtfMotor.DataTable = "MOD"
        Me.dtfMotor.Descripcion = "Motor"
        Me.dtfMotor.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfMotor.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfMotor.FocoEnAgregar = False
        Me.dtfMotor.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfMotor.Image = Nothing
        Me.dtfMotor.Label_Space = 125
        Me.dtfMotor.Length_Data = 32767
        Me.dtfMotor.Location = New System.Drawing.Point(6, 139)
        Me.dtfMotor.Max_Value = 0.0R
        Me.dtfMotor.MensajeIncorrectoCustom = Nothing
        Me.dtfMotor.Name = "dtfMotor"
        Me.dtfMotor.Null_on_Empty = True
        Me.dtfMotor.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfMotor.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfMotor.ReadOnly_Data = False
        Me.dtfMotor.Show_Button = False
        Me.dtfMotor.Size = New System.Drawing.Size(452, 26)
        Me.dtfMotor.TabIndex = 5
        Me.dtfMotor.Text_Data = ""
        Me.dtfMotor.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfMotor.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfMotor.TopPadding = 0
        Me.dtfMotor.Upper_Case = False
        Me.dtfMotor.Validate_on_lost_focus = True
        '
        'dtfCilindrada
        '
        Me.dtfCilindrada.Allow_Empty = True
        Me.dtfCilindrada.Allow_Negative = True
        Me.dtfCilindrada.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfCilindrada.BackColor = System.Drawing.SystemColors.Control
        Me.dtfCilindrada.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfCilindrada.DataField = "CILIN_MOD"
        Me.dtfCilindrada.DataTable = "MOD"
        Me.dtfCilindrada.Descripcion = "Cilindrada"
        Me.dtfCilindrada.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfCilindrada.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfCilindrada.FocoEnAgregar = False
        Me.dtfCilindrada.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfCilindrada.Image = Nothing
        Me.dtfCilindrada.Label_Space = 125
        Me.dtfCilindrada.Length_Data = 32767
        Me.dtfCilindrada.Location = New System.Drawing.Point(6, 113)
        Me.dtfCilindrada.Max_Value = 0.0R
        Me.dtfCilindrada.MensajeIncorrectoCustom = Nothing
        Me.dtfCilindrada.Name = "dtfCilindrada"
        Me.dtfCilindrada.Null_on_Empty = True
        Me.dtfCilindrada.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfCilindrada.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfCilindrada.ReadOnly_Data = False
        Me.dtfCilindrada.Show_Button = False
        Me.dtfCilindrada.Size = New System.Drawing.Size(452, 26)
        Me.dtfCilindrada.TabIndex = 4
        Me.dtfCilindrada.Text_Data = ""
        Me.dtfCilindrada.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfCilindrada.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfCilindrada.TopPadding = 0
        Me.dtfCilindrada.Upper_Case = False
        Me.dtfCilindrada.Validate_on_lost_focus = True
        '
        'dtfPrefijoBastidor
        '
        Me.dtfPrefijoBastidor.Allow_Empty = True
        Me.dtfPrefijoBastidor.Allow_Negative = True
        Me.dtfPrefijoBastidor.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfPrefijoBastidor.BackColor = System.Drawing.SystemColors.Control
        Me.dtfPrefijoBastidor.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfPrefijoBastidor.DataField = "CHASIS"
        Me.dtfPrefijoBastidor.DataTable = "MOD"
        Me.dtfPrefijoBastidor.Descripcion = "Prefijo Bastidor"
        Me.dtfPrefijoBastidor.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfPrefijoBastidor.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfPrefijoBastidor.FocoEnAgregar = False
        Me.dtfPrefijoBastidor.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfPrefijoBastidor.Image = Nothing
        Me.dtfPrefijoBastidor.Label_Space = 125
        Me.dtfPrefijoBastidor.Length_Data = 32767
        Me.dtfPrefijoBastidor.Location = New System.Drawing.Point(6, 87)
        Me.dtfPrefijoBastidor.Max_Value = 0.0R
        Me.dtfPrefijoBastidor.MensajeIncorrectoCustom = Nothing
        Me.dtfPrefijoBastidor.Name = "dtfPrefijoBastidor"
        Me.dtfPrefijoBastidor.Null_on_Empty = True
        Me.dtfPrefijoBastidor.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfPrefijoBastidor.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfPrefijoBastidor.ReadOnly_Data = False
        Me.dtfPrefijoBastidor.Show_Button = False
        Me.dtfPrefijoBastidor.Size = New System.Drawing.Size(452, 26)
        Me.dtfPrefijoBastidor.TabIndex = 3
        Me.dtfPrefijoBastidor.Text_Data = ""
        Me.dtfPrefijoBastidor.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfPrefijoBastidor.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfPrefijoBastidor.TopPadding = 0
        Me.dtfPrefijoBastidor.Upper_Case = False
        Me.dtfPrefijoBastidor.Validate_on_lost_focus = True
        '
        'pnlMantecada
        '
        Me.pnlMantecada.Auto_Size = False
        Me.pnlMantecada.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlMantecada.ChangeDock = True
        Me.pnlMantecada.Control_Resize = False
        Me.pnlMantecada.Controls.Add(Me.dtfMantecada)
        Me.pnlMantecada.Controls.Add(Me.pnlMantecadaR)
        Me.pnlMantecada.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlMantecada.isSpace = False
        Me.pnlMantecada.Location = New System.Drawing.Point(6, 60)
        Me.pnlMantecada.Name = "pnlMantecada"
        Me.pnlMantecada.numRows = 0
        Me.pnlMantecada.Reorder = True
        Me.pnlMantecada.Size = New System.Drawing.Size(452, 27)
        Me.pnlMantecada.TabIndex = 2
        '
        'dtfMantecada
        '
        Me.dtfMantecada.Allow_Empty = True
        Me.dtfMantecada.Allow_Negative = True
        Me.dtfMantecada.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfMantecada.BackColor = System.Drawing.SystemColors.Control
        Me.dtfMantecada.Data_Allowed = CustomControls.Datafield.List_Data.nDouble
        Me.dtfMantecada.DataField = "MANTECADA"
        Me.dtfMantecada.DataTable = "MOD"
        Me.dtfMantecada.Descripcion = "Mantenimiento Cada"
        Me.dtfMantecada.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfMantecada.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfMantecada.FocoEnAgregar = False
        Me.dtfMantecada.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfMantecada.Image = Nothing
        Me.dtfMantecada.Label_Space = 125
        Me.dtfMantecada.Length_Data = 32767
        Me.dtfMantecada.Location = New System.Drawing.Point(0, 0)
        Me.dtfMantecada.Max_Value = 0.0R
        Me.dtfMantecada.MensajeIncorrectoCustom = Nothing
        Me.dtfMantecada.Name = "dtfMantecada"
        Me.dtfMantecada.Null_on_Empty = True
        Me.dtfMantecada.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfMantecada.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfMantecada.ReadOnly_Data = False
        Me.dtfMantecada.Show_Button = False
        Me.dtfMantecada.Size = New System.Drawing.Size(200, 26)
        Me.dtfMantecada.TabIndex = 0
        Me.dtfMantecada.Text_Data = ""
        Me.dtfMantecada.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.dtfMantecada.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfMantecada.TopPadding = 0
        Me.dtfMantecada.Upper_Case = False
        Me.dtfMantecada.Validate_on_lost_focus = True
        '
        'pnlMantecadaR
        '
        Me.pnlMantecadaR.Auto_Size = False
        Me.pnlMantecadaR.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlMantecadaR.ChangeDock = True
        Me.pnlMantecadaR.Control_Resize = False
        Me.pnlMantecadaR.Controls.Add(Me.dfMantecada)
        Me.pnlMantecadaR.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlMantecadaR.isSpace = False
        Me.pnlMantecadaR.Location = New System.Drawing.Point(200, 0)
        Me.pnlMantecadaR.Name = "pnlMantecadaR"
        Me.pnlMantecadaR.numRows = 0
        Me.pnlMantecadaR.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.pnlMantecadaR.Reorder = True
        Me.pnlMantecadaR.Size = New System.Drawing.Size(252, 27)
        Me.pnlMantecadaR.TabIndex = 1
        '
        'dfMantecada
        '
        Me.dfMantecada.Allow_Empty = True
        Me.dfMantecada.Allow_Negative = True
        Me.dfMantecada.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dfMantecada.BackColor = System.Drawing.SystemColors.Control
        Me.dfMantecada.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dfMantecada.DataField = Nothing
        Me.dfMantecada.DataTable = ""
        Me.dfMantecada.Descripcion = Nothing
        Me.dfMantecada.Dock = System.Windows.Forms.DockStyle.Top
        Me.dfMantecada.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dfMantecada.FocoEnAgregar = False
        Me.dfMantecada.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dfMantecada.Length_Data = 32767
        Me.dfMantecada.Location = New System.Drawing.Point(6, 0)
        Me.dfMantecada.Max_Value = 0.0R
        Me.dfMantecada.MensajeIncorrectoCustom = Nothing
        Me.dfMantecada.Name = "dfMantecada"
        Me.dfMantecada.Null_on_Empty = True
        Me.dfMantecada.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dfMantecada.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dfMantecada.ReadOnly_Data = True
        Me.dfMantecada.Size = New System.Drawing.Size(246, 26)
        Me.dfMantecada.TabIndex = 0
        Me.dfMantecada.TabStop = False
        Me.dfMantecada.Text_Data = ""
        Me.dfMantecada.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dfMantecada.TopPadding = 0
        Me.dfMantecada.Upper_Case = False
        Me.dfMantecada.Validate_on_lost_focus = True
        '
        'pnlConsumo
        '
        Me.pnlConsumo.Auto_Size = False
        Me.pnlConsumo.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlConsumo.ChangeDock = True
        Me.pnlConsumo.Control_Resize = False
        Me.pnlConsumo.Controls.Add(Me.dtfConsumo)
        Me.pnlConsumo.Controls.Add(Me.pnlConsumoR)
        Me.pnlConsumo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlConsumo.isSpace = False
        Me.pnlConsumo.Location = New System.Drawing.Point(6, 33)
        Me.pnlConsumo.Name = "pnlConsumo"
        Me.pnlConsumo.numRows = 0
        Me.pnlConsumo.Reorder = True
        Me.pnlConsumo.Size = New System.Drawing.Size(452, 27)
        Me.pnlConsumo.TabIndex = 1
        '
        'dtfConsumo
        '
        Me.dtfConsumo.Allow_Empty = True
        Me.dtfConsumo.Allow_Negative = True
        Me.dtfConsumo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfConsumo.BackColor = System.Drawing.SystemColors.Control
        Me.dtfConsumo.Data_Allowed = CustomControls.Datafield.List_Data.nDouble
        Me.dtfConsumo.DataField = "CONSUMO"
        Me.dtfConsumo.DataTable = "MOD"
        Me.dtfConsumo.Descripcion = "Consumo"
        Me.dtfConsumo.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfConsumo.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfConsumo.FocoEnAgregar = False
        Me.dtfConsumo.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfConsumo.Image = Nothing
        Me.dtfConsumo.Label_Space = 105
        Me.dtfConsumo.Length_Data = 32767
        Me.dtfConsumo.Location = New System.Drawing.Point(0, 0)
        Me.dtfConsumo.Max_Value = 0.0R
        Me.dtfConsumo.MensajeIncorrectoCustom = Nothing
        Me.dtfConsumo.Name = "dtfConsumo"
        Me.dtfConsumo.Null_on_Empty = True
        Me.dtfConsumo.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfConsumo.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfConsumo.ReadOnly_Data = False
        Me.dtfConsumo.Show_Button = False
        Me.dtfConsumo.Size = New System.Drawing.Size(170, 26)
        Me.dtfConsumo.TabIndex = 0
        Me.dtfConsumo.Text_Data = ""
        Me.dtfConsumo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.dtfConsumo.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfConsumo.TopPadding = 0
        Me.dtfConsumo.Upper_Case = False
        Me.dtfConsumo.Validate_on_lost_focus = True
        '
        'pnlConsumoR
        '
        Me.pnlConsumoR.Auto_Size = False
        Me.pnlConsumoR.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlConsumoR.ChangeDock = True
        Me.pnlConsumoR.Control_Resize = False
        Me.pnlConsumoR.Controls.Add(Me.dfConsumo)
        Me.pnlConsumoR.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlConsumoR.isSpace = False
        Me.pnlConsumoR.Location = New System.Drawing.Point(170, 0)
        Me.pnlConsumoR.Name = "pnlConsumoR"
        Me.pnlConsumoR.numRows = 0
        Me.pnlConsumoR.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.pnlConsumoR.Reorder = True
        Me.pnlConsumoR.Size = New System.Drawing.Size(282, 27)
        Me.pnlConsumoR.TabIndex = 1
        '
        'dfConsumo
        '
        Me.dfConsumo.Allow_Empty = True
        Me.dfConsumo.Allow_Negative = True
        Me.dfConsumo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dfConsumo.BackColor = System.Drawing.SystemColors.Control
        Me.dfConsumo.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dfConsumo.DataField = Nothing
        Me.dfConsumo.DataTable = ""
        Me.dfConsumo.Descripcion = Nothing
        Me.dfConsumo.Dock = System.Windows.Forms.DockStyle.Top
        Me.dfConsumo.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dfConsumo.FocoEnAgregar = False
        Me.dfConsumo.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dfConsumo.Length_Data = 32767
        Me.dfConsumo.Location = New System.Drawing.Point(6, 0)
        Me.dfConsumo.Max_Value = 0.0R
        Me.dfConsumo.MensajeIncorrectoCustom = Nothing
        Me.dfConsumo.Name = "dfConsumo"
        Me.dfConsumo.Null_on_Empty = True
        Me.dfConsumo.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dfConsumo.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dfConsumo.ReadOnly_Data = True
        Me.dfConsumo.Size = New System.Drawing.Size(276, 26)
        Me.dfConsumo.TabIndex = 0
        Me.dfConsumo.TabStop = False
        Me.dfConsumo.Text_Data = ""
        Me.dfConsumo.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dfConsumo.TopPadding = 0
        Me.dfConsumo.Upper_Case = False
        Me.dfConsumo.Validate_on_lost_focus = True
        '
        'pnlDeposito
        '
        Me.pnlDeposito.Auto_Size = False
        Me.pnlDeposito.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlDeposito.ChangeDock = True
        Me.pnlDeposito.Control_Resize = False
        Me.pnlDeposito.Controls.Add(Me.dtfDeposito)
        Me.pnlDeposito.Controls.Add(Me.pnlDepositoLiteral)
        Me.pnlDeposito.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlDeposito.isSpace = False
        Me.pnlDeposito.Location = New System.Drawing.Point(6, 6)
        Me.pnlDeposito.Name = "pnlDeposito"
        Me.pnlDeposito.numRows = 0
        Me.pnlDeposito.Reorder = True
        Me.pnlDeposito.Size = New System.Drawing.Size(452, 27)
        Me.pnlDeposito.TabIndex = 0
        '
        'dtfDeposito
        '
        Me.dtfDeposito.Allow_Empty = True
        Me.dtfDeposito.Allow_Negative = True
        Me.dtfDeposito.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfDeposito.BackColor = System.Drawing.SystemColors.Control
        Me.dtfDeposito.Data_Allowed = CustomControls.Datafield.List_Data.nDouble
        Me.dtfDeposito.DataField = "DEPOSITO"
        Me.dtfDeposito.DataTable = "MOD"
        Me.dtfDeposito.Descripcion = "Capac. Depósito"
        Me.dtfDeposito.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfDeposito.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfDeposito.FocoEnAgregar = False
        Me.dtfDeposito.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfDeposito.Image = Nothing
        Me.dtfDeposito.Label_Space = 105
        Me.dtfDeposito.Length_Data = 32767
        Me.dtfDeposito.Location = New System.Drawing.Point(0, 0)
        Me.dtfDeposito.Max_Value = 0.0R
        Me.dtfDeposito.MensajeIncorrectoCustom = Nothing
        Me.dtfDeposito.Name = "dtfDeposito"
        Me.dtfDeposito.Null_on_Empty = True
        Me.dtfDeposito.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfDeposito.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfDeposito.ReadOnly_Data = False
        Me.dtfDeposito.Show_Button = False
        Me.dtfDeposito.Size = New System.Drawing.Size(170, 26)
        Me.dtfDeposito.TabIndex = 0
        Me.dtfDeposito.Text_Data = ""
        Me.dtfDeposito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.dtfDeposito.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfDeposito.TopPadding = 0
        Me.dtfDeposito.Upper_Case = False
        Me.dtfDeposito.Validate_on_lost_focus = True
        '
        'pnlDepositoLiteral
        '
        Me.pnlDepositoLiteral.Auto_Size = False
        Me.pnlDepositoLiteral.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlDepositoLiteral.ChangeDock = True
        Me.pnlDepositoLiteral.Control_Resize = False
        Me.pnlDepositoLiteral.Controls.Add(Me.dfDeposito)
        Me.pnlDepositoLiteral.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDepositoLiteral.isSpace = False
        Me.pnlDepositoLiteral.Location = New System.Drawing.Point(170, 0)
        Me.pnlDepositoLiteral.Name = "pnlDepositoLiteral"
        Me.pnlDepositoLiteral.numRows = 0
        Me.pnlDepositoLiteral.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.pnlDepositoLiteral.Reorder = True
        Me.pnlDepositoLiteral.Size = New System.Drawing.Size(282, 27)
        Me.pnlDepositoLiteral.TabIndex = 1
        '
        'dfDeposito
        '
        Me.dfDeposito.Allow_Empty = True
        Me.dfDeposito.Allow_Negative = True
        Me.dfDeposito.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dfDeposito.BackColor = System.Drawing.SystemColors.Control
        Me.dfDeposito.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dfDeposito.DataField = Nothing
        Me.dfDeposito.DataTable = ""
        Me.dfDeposito.Descripcion = Nothing
        Me.dfDeposito.Dock = System.Windows.Forms.DockStyle.Top
        Me.dfDeposito.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dfDeposito.FocoEnAgregar = False
        Me.dfDeposito.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dfDeposito.Length_Data = 32767
        Me.dfDeposito.Location = New System.Drawing.Point(6, 0)
        Me.dfDeposito.Max_Value = 0.0R
        Me.dfDeposito.MensajeIncorrectoCustom = Nothing
        Me.dfDeposito.Name = "dfDeposito"
        Me.dfDeposito.Null_on_Empty = True
        Me.dfDeposito.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dfDeposito.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dfDeposito.ReadOnly_Data = True
        Me.dfDeposito.Size = New System.Drawing.Size(276, 26)
        Me.dfDeposito.TabIndex = 0
        Me.dfDeposito.TabStop = False
        Me.dfDeposito.Text_Data = ""
        Me.dfDeposito.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dfDeposito.TopPadding = 0
        Me.dfDeposito.Upper_Case = False
        Me.dfDeposito.Validate_on_lost_focus = True
        '
        'pnlGenLeft
        '
        Me.pnlGenLeft.Auto_Size = False
        Me.pnlGenLeft.BackColor = System.Drawing.SystemColors.Control
        Me.pnlGenLeft.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlGenLeft.ChangeDock = True
        Me.pnlGenLeft.Control_Resize = False
        Me.pnlGenLeft.Controls.Add(Me.grbGenOps)
        Me.pnlGenLeft.Controls.Add(Me.rdgTipoCombus)
        Me.pnlGenLeft.Controls.Add(Me.rdgTipoCambio)
        Me.pnlGenLeft.Controls.Add(Me.pnlSeparator_1)
        Me.pnlGenLeft.Controls.Add(Me.grbGen)
        Me.pnlGenLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlGenLeft.isSpace = False
        Me.pnlGenLeft.Location = New System.Drawing.Point(0, 64)
        Me.pnlGenLeft.Name = "pnlGenLeft"
        Me.pnlGenLeft.numRows = 0
        Me.pnlGenLeft.Reorder = True
        Me.pnlGenLeft.Size = New System.Drawing.Size(470, 425)
        Me.pnlGenLeft.TabIndex = 0
        '
        'grbGenOps
        '
        Me.grbGenOps.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.grbGenOps.Controls.Add(Me.pnlOpsR)
        Me.grbGenOps.Controls.Add(Me.pnlLeftOps)
        Me.grbGenOps.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbGenOps.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.grbGenOps.HeaderText = "Opciones"
        Me.grbGenOps.Location = New System.Drawing.Point(0, 326)
        Me.grbGenOps.Name = "grbGenOps"
        Me.grbGenOps.numRows = 0
        Me.grbGenOps.Padding = New System.Windows.Forms.Padding(6, 18, 6, 6)
        Me.grbGenOps.Reorder = True
        Me.grbGenOps.Size = New System.Drawing.Size(470, 99)
        Me.grbGenOps.TabIndex = 4
        Me.grbGenOps.Text = "Opciones"
        Me.grbGenOps.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.grbGenOps.ThemeName = "Windows8"
        Me.grbGenOps.Title = "Opciones"
        '
        'pnlOpsR
        '
        Me.pnlOpsR.Auto_Size = False
        Me.pnlOpsR.BackColor = System.Drawing.SystemColors.Control
        Me.pnlOpsR.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlOpsR.ChangeDock = True
        Me.pnlOpsR.Control_Resize = False
        Me.pnlOpsR.Controls.Add(Me.dtfPlazas)
        Me.pnlOpsR.Controls.Add(Me.dtfPuertas)
        Me.pnlOpsR.Controls.Add(Me.dtfAirbags)
        Me.pnlOpsR.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlOpsR.isSpace = False
        Me.pnlOpsR.Location = New System.Drawing.Point(282, 18)
        Me.pnlOpsR.Name = "pnlOpsR"
        Me.pnlOpsR.numRows = 0
        Me.pnlOpsR.Reorder = True
        Me.pnlOpsR.Size = New System.Drawing.Size(182, 75)
        Me.pnlOpsR.TabIndex = 1
        '
        'dtfPlazas
        '
        Me.dtfPlazas.Allow_Empty = True
        Me.dtfPlazas.Allow_Negative = True
        Me.dtfPlazas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfPlazas.BackColor = System.Drawing.SystemColors.Control
        Me.dtfPlazas.Data_Allowed = CustomControls.Datafield.List_Data.nInteger
        Me.dtfPlazas.DataField = "PLAZAS_MOD"
        Me.dtfPlazas.DataTable = "MOD"
        Me.dtfPlazas.Descripcion = "NºPlazas"
        Me.dtfPlazas.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfPlazas.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfPlazas.FocoEnAgregar = False
        Me.dtfPlazas.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfPlazas.Image = Nothing
        Me.dtfPlazas.Label_Space = 110
        Me.dtfPlazas.Length_Data = 32767
        Me.dtfPlazas.Location = New System.Drawing.Point(0, 52)
        Me.dtfPlazas.Max_Value = 0.0R
        Me.dtfPlazas.MensajeIncorrectoCustom = Nothing
        Me.dtfPlazas.Name = "dtfPlazas"
        Me.dtfPlazas.Null_on_Empty = True
        Me.dtfPlazas.Padding = New System.Windows.Forms.Padding(0, 0, 1, 3)
        Me.dtfPlazas.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfPlazas.ReadOnly_Data = False
        Me.dtfPlazas.Show_Button = False
        Me.dtfPlazas.Size = New System.Drawing.Size(182, 26)
        Me.dtfPlazas.TabIndex = 2
        Me.dtfPlazas.Text_Data = ""
        Me.dtfPlazas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.dtfPlazas.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfPlazas.TopPadding = 0
        Me.dtfPlazas.Upper_Case = False
        Me.dtfPlazas.Validate_on_lost_focus = True
        '
        'dtfPuertas
        '
        Me.dtfPuertas.Allow_Empty = True
        Me.dtfPuertas.Allow_Negative = True
        Me.dtfPuertas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfPuertas.BackColor = System.Drawing.SystemColors.Control
        Me.dtfPuertas.Data_Allowed = CustomControls.Datafield.List_Data.nInteger
        Me.dtfPuertas.DataField = "PUERTAS_MOD"
        Me.dtfPuertas.DataTable = "MOD"
        Me.dtfPuertas.Descripcion = "NºPuertas"
        Me.dtfPuertas.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfPuertas.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfPuertas.FocoEnAgregar = False
        Me.dtfPuertas.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfPuertas.Image = Nothing
        Me.dtfPuertas.Label_Space = 110
        Me.dtfPuertas.Length_Data = 32767
        Me.dtfPuertas.Location = New System.Drawing.Point(0, 26)
        Me.dtfPuertas.Max_Value = 0.0R
        Me.dtfPuertas.MensajeIncorrectoCustom = Nothing
        Me.dtfPuertas.Name = "dtfPuertas"
        Me.dtfPuertas.Null_on_Empty = True
        Me.dtfPuertas.Padding = New System.Windows.Forms.Padding(0, 0, 1, 3)
        Me.dtfPuertas.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfPuertas.ReadOnly_Data = False
        Me.dtfPuertas.Show_Button = False
        Me.dtfPuertas.Size = New System.Drawing.Size(182, 26)
        Me.dtfPuertas.TabIndex = 1
        Me.dtfPuertas.Text_Data = ""
        Me.dtfPuertas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.dtfPuertas.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfPuertas.TopPadding = 0
        Me.dtfPuertas.Upper_Case = False
        Me.dtfPuertas.Validate_on_lost_focus = True
        '
        'dtfAirbags
        '
        Me.dtfAirbags.Allow_Empty = True
        Me.dtfAirbags.Allow_Negative = True
        Me.dtfAirbags.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfAirbags.BackColor = System.Drawing.SystemColors.Control
        Me.dtfAirbags.Data_Allowed = CustomControls.Datafield.List_Data.nInteger
        Me.dtfAirbags.DataField = "AIRBAGS_MOD"
        Me.dtfAirbags.DataTable = "MOD"
        Me.dtfAirbags.Descripcion = "Airbags"
        Me.dtfAirbags.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfAirbags.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfAirbags.FocoEnAgregar = False
        Me.dtfAirbags.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfAirbags.Image = Nothing
        Me.dtfAirbags.Label_Space = 110
        Me.dtfAirbags.Length_Data = 32767
        Me.dtfAirbags.Location = New System.Drawing.Point(0, 0)
        Me.dtfAirbags.Max_Value = 0.0R
        Me.dtfAirbags.MensajeIncorrectoCustom = Nothing
        Me.dtfAirbags.Name = "dtfAirbags"
        Me.dtfAirbags.Null_on_Empty = True
        Me.dtfAirbags.Padding = New System.Windows.Forms.Padding(0, 0, 1, 3)
        Me.dtfAirbags.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfAirbags.ReadOnly_Data = False
        Me.dtfAirbags.Show_Button = False
        Me.dtfAirbags.Size = New System.Drawing.Size(182, 26)
        Me.dtfAirbags.TabIndex = 0
        Me.dtfAirbags.Text_Data = ""
        Me.dtfAirbags.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.dtfAirbags.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfAirbags.TopPadding = 0
        Me.dtfAirbags.Upper_Case = False
        Me.dtfAirbags.Validate_on_lost_focus = True
        '
        'pnlLeftOps
        '
        Me.pnlLeftOps.Auto_Size = False
        Me.pnlLeftOps.BackColor = System.Drawing.SystemColors.Control
        Me.pnlLeftOps.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlLeftOps.ChangeDock = True
        Me.pnlLeftOps.Control_Resize = False
        Me.pnlLeftOps.Controls.Add(Me.pnlRightOpsCh)
        Me.pnlLeftOps.Controls.Add(Me.pnlLeftOpsCh)
        Me.pnlLeftOps.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlLeftOps.isSpace = False
        Me.pnlLeftOps.Location = New System.Drawing.Point(6, 18)
        Me.pnlLeftOps.Name = "pnlLeftOps"
        Me.pnlLeftOps.numRows = 0
        Me.pnlLeftOps.Reorder = True
        Me.pnlLeftOps.Size = New System.Drawing.Size(276, 75)
        Me.pnlLeftOps.TabIndex = 0
        '
        'pnlRightOpsCh
        '
        Me.pnlRightOpsCh.Auto_Size = False
        Me.pnlRightOpsCh.BackColor = System.Drawing.SystemColors.Control
        Me.pnlRightOpsCh.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlRightOpsCh.ChangeDock = True
        Me.pnlRightOpsCh.Control_Resize = False
        Me.pnlRightOpsCh.Controls.Add(Me.chhDirAsis)
        Me.pnlRightOpsCh.Controls.Add(Me.chkAbs)
        Me.pnlRightOpsCh.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlRightOpsCh.isSpace = False
        Me.pnlRightOpsCh.Location = New System.Drawing.Point(118, 0)
        Me.pnlRightOpsCh.Name = "pnlRightOpsCh"
        Me.pnlRightOpsCh.numRows = 0
        Me.pnlRightOpsCh.Reorder = True
        Me.pnlRightOpsCh.Size = New System.Drawing.Size(158, 75)
        Me.pnlRightOpsCh.TabIndex = 1
        '
        'chhDirAsis
        '
        Me.chhDirAsis.DataField = "DIR_ASIS_MOD"
        Me.chhDirAsis.DataTable = "MOD"
        Me.chhDirAsis.Descripcion = "Direc.Asistida"
        Me.chhDirAsis.Dock = System.Windows.Forms.DockStyle.Top
        Me.chhDirAsis.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.chhDirAsis.Location = New System.Drawing.Point(0, 18)
        Me.chhDirAsis.Name = "chhDirAsis"
        Me.chhDirAsis.Size = New System.Drawing.Size(158, 18)
        Me.chhDirAsis.TabIndex = 1
        Me.chhDirAsis.Text = "Direc.Asistida"
        Me.chhDirAsis.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.chhDirAsis.ThemeName = "Windows8"
        Me.chhDirAsis.Value = False
        '
        'chkAbs
        '
        Me.chkAbs.DataField = "ABS"
        Me.chkAbs.DataTable = "MOD"
        Me.chkAbs.Descripcion = "Abs"
        Me.chkAbs.Dock = System.Windows.Forms.DockStyle.Top
        Me.chkAbs.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.chkAbs.Location = New System.Drawing.Point(0, 0)
        Me.chkAbs.Name = "chkAbs"
        Me.chkAbs.Size = New System.Drawing.Size(158, 18)
        Me.chkAbs.TabIndex = 0
        Me.chkAbs.Text = "Abs"
        Me.chkAbs.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.chkAbs.ThemeName = "Windows8"
        Me.chkAbs.Value = False
        '
        'pnlLeftOpsCh
        '
        Me.pnlLeftOpsCh.Auto_Size = False
        Me.pnlLeftOpsCh.BackColor = System.Drawing.SystemColors.Control
        Me.pnlLeftOpsCh.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlLeftOpsCh.ChangeDock = True
        Me.pnlLeftOpsCh.Control_Resize = False
        Me.pnlLeftOpsCh.Controls.Add(Me.chkAA)
        Me.pnlLeftOpsCh.Controls.Add(Me.chkRadio)
        Me.pnlLeftOpsCh.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlLeftOpsCh.isSpace = False
        Me.pnlLeftOpsCh.Location = New System.Drawing.Point(0, 0)
        Me.pnlLeftOpsCh.Name = "pnlLeftOpsCh"
        Me.pnlLeftOpsCh.numRows = 0
        Me.pnlLeftOpsCh.Reorder = True
        Me.pnlLeftOpsCh.Size = New System.Drawing.Size(118, 75)
        Me.pnlLeftOpsCh.TabIndex = 0
        '
        'chkAA
        '
        Me.chkAA.DataField = "AIREA_MOD"
        Me.chkAA.DataTable = "MOD"
        Me.chkAA.Descripcion = "A.A"
        Me.chkAA.Dock = System.Windows.Forms.DockStyle.Top
        Me.chkAA.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.chkAA.Location = New System.Drawing.Point(0, 18)
        Me.chkAA.Name = "chkAA"
        Me.chkAA.Size = New System.Drawing.Size(118, 18)
        Me.chkAA.TabIndex = 1
        Me.chkAA.Text = "A.A"
        Me.chkAA.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.chkAA.ThemeName = "Windows8"
        Me.chkAA.Value = False
        '
        'chkRadio
        '
        Me.chkRadio.DataField = "RADIO_MOD"
        Me.chkRadio.DataTable = "MOD"
        Me.chkRadio.Descripcion = "Radio"
        Me.chkRadio.Dock = System.Windows.Forms.DockStyle.Top
        Me.chkRadio.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.chkRadio.Location = New System.Drawing.Point(0, 0)
        Me.chkRadio.Name = "chkRadio"
        Me.chkRadio.Size = New System.Drawing.Size(118, 18)
        Me.chkRadio.TabIndex = 0
        Me.chkRadio.Text = "Radio"
        Me.chkRadio.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.chkRadio.ThemeName = "Windows8"
        Me.chkRadio.Value = False
        '
        'rdgTipoCombus
        '
        Me.rdgTipoCombus.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.rdgTipoCombus.Controls.Add(Me.dtsElectrico)
        Me.rdgTipoCombus.Controls.Add(Me.dtrGasolina)
        Me.rdgTipoCombus.Controls.Add(Me.dtrDiesel)
        Me.rdgTipoCombus.DataField = "TIPOGAS"
        Me.rdgTipoCombus.DataTable = "MOD"
        Me.rdgTipoCombus.Descripcion = "Tipo de Combustible"
        Me.rdgTipoCombus.Dock = System.Windows.Forms.DockStyle.Top
        Me.rdgTipoCombus.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.rdgTipoCombus.HeaderText = "Tipo de Combustible"
        Me.rdgTipoCombus.Index = Nothing
        Me.rdgTipoCombus.Location = New System.Drawing.Point(0, 278)
        Me.rdgTipoCombus.Name = "rdgTipoCombus"
        Me.rdgTipoCombus.numRows = 0
        Me.rdgTipoCombus.Padding = New System.Windows.Forms.Padding(6, 18, 6, 6)
        Me.rdgTipoCombus.Reorder = True
        Me.rdgTipoCombus.Size = New System.Drawing.Size(470, 48)
        Me.rdgTipoCombus.TabIndex = 3
        Me.rdgTipoCombus.Text = "Tipo de Combustible"
        Me.rdgTipoCombus.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.rdgTipoCombus.ThemeName = "Windows8"
        Me.rdgTipoCombus.Title = "Tipo de Combustible"
        '
        'dtsElectrico
        '
        Me.dtsElectrico.BackColor = System.Drawing.SystemColors.Control
        Me.dtsElectrico.Checked = False
        Me.dtsElectrico.Descripcion = "Eléctrico"
        Me.dtsElectrico.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtsElectrico.Index = "2"
        Me.dtsElectrico.Location = New System.Drawing.Point(261, 21)
        Me.dtsElectrico.Name = "dtsElectrico"
        Me.dtsElectrico.Size = New System.Drawing.Size(71, 18)
        Me.dtsElectrico.TabIndex = 2
        Me.dtsElectrico.TabStop = True
        Me.dtsElectrico.Text = "Eléctrico"
        Me.dtsElectrico.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtsElectrico.ThemeName = "Windows8"
        '
        'dtrGasolina
        '
        Me.dtrGasolina.BackColor = System.Drawing.SystemColors.Control
        Me.dtrGasolina.Checked = False
        Me.dtrGasolina.Descripcion = "Gasolina"
        Me.dtrGasolina.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtrGasolina.Index = "0"
        Me.dtrGasolina.Location = New System.Drawing.Point(142, 21)
        Me.dtrGasolina.Name = "dtrGasolina"
        Me.dtrGasolina.Size = New System.Drawing.Size(72, 18)
        Me.dtrGasolina.TabIndex = 1
        Me.dtrGasolina.TabStop = True
        Me.dtrGasolina.Text = "Gasolina"
        Me.dtrGasolina.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtrGasolina.ThemeName = "Windows8"
        '
        'dtrDiesel
        '
        Me.dtrDiesel.BackColor = System.Drawing.SystemColors.Control
        Me.dtrDiesel.Checked = False
        Me.dtrDiesel.Descripcion = "Diesel"
        Me.dtrDiesel.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtrDiesel.Index = "1"
        Me.dtrDiesel.Location = New System.Drawing.Point(36, 21)
        Me.dtrDiesel.Name = "dtrDiesel"
        Me.dtrDiesel.Size = New System.Drawing.Size(58, 18)
        Me.dtrDiesel.TabIndex = 0
        Me.dtrDiesel.TabStop = True
        Me.dtrDiesel.Text = "Diesel"
        Me.dtrDiesel.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtrDiesel.ThemeName = "Windows8"
        '
        'rdgTipoCambio
        '
        Me.rdgTipoCambio.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.rdgTipoCambio.Controls.Add(Me.dtrCambioSem)
        Me.rdgTipoCambio.Controls.Add(Me.dtrCambioAut)
        Me.rdgTipoCambio.Controls.Add(Me.dtrCambioMan)
        Me.rdgTipoCambio.DataField = "CAMBIO_MOD"
        Me.rdgTipoCambio.DataTable = "MOD"
        Me.rdgTipoCambio.Descripcion = "Tipo de Cambio"
        Me.rdgTipoCambio.Dock = System.Windows.Forms.DockStyle.Top
        Me.rdgTipoCambio.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.rdgTipoCambio.HeaderText = "Tipo de Cambio"
        Me.rdgTipoCambio.Index = Nothing
        Me.rdgTipoCambio.Location = New System.Drawing.Point(0, 230)
        Me.rdgTipoCambio.Name = "rdgTipoCambio"
        Me.rdgTipoCambio.numRows = 0
        Me.rdgTipoCambio.Padding = New System.Windows.Forms.Padding(6, 18, 6, 6)
        Me.rdgTipoCambio.Reorder = True
        Me.rdgTipoCambio.Size = New System.Drawing.Size(470, 48)
        Me.rdgTipoCambio.TabIndex = 2
        Me.rdgTipoCambio.Text = "Tipo de Cambio"
        Me.rdgTipoCambio.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.rdgTipoCambio.ThemeName = "Windows8"
        Me.rdgTipoCambio.Title = "Tipo de Cambio"
        '
        'dtrCambioSem
        '
        Me.dtrCambioSem.BackColor = System.Drawing.SystemColors.Control
        Me.dtrCambioSem.Checked = False
        Me.dtrCambioSem.Descripcion = "Semiautomático"
        Me.dtrCambioSem.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtrCambioSem.Index = "3"
        Me.dtrCambioSem.Location = New System.Drawing.Point(261, 21)
        Me.dtrCambioSem.Name = "dtrCambioSem"
        Me.dtrCambioSem.Size = New System.Drawing.Size(112, 17)
        Me.dtrCambioSem.TabIndex = 2
        Me.dtrCambioSem.TabStop = True
        Me.dtrCambioSem.Text = "Semiautomático"
        Me.dtrCambioSem.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtrCambioSem.ThemeName = "Windows8"
        '
        'dtrCambioAut
        '
        Me.dtrCambioAut.BackColor = System.Drawing.SystemColors.Control
        Me.dtrCambioAut.Checked = False
        Me.dtrCambioAut.Descripcion = "Automático"
        Me.dtrCambioAut.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtrCambioAut.Index = "2"
        Me.dtrCambioAut.Location = New System.Drawing.Point(142, 21)
        Me.dtrCambioAut.Name = "dtrCambioAut"
        Me.dtrCambioAut.Size = New System.Drawing.Size(85, 17)
        Me.dtrCambioAut.TabIndex = 1
        Me.dtrCambioAut.TabStop = True
        Me.dtrCambioAut.Text = "Automático"
        Me.dtrCambioAut.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtrCambioAut.ThemeName = "Windows8"
        '
        'dtrCambioMan
        '
        Me.dtrCambioMan.BackColor = System.Drawing.SystemColors.Control
        Me.dtrCambioMan.Checked = False
        Me.dtrCambioMan.Descripcion = "Manual"
        Me.dtrCambioMan.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtrCambioMan.Index = "1"
        Me.dtrCambioMan.Location = New System.Drawing.Point(36, 21)
        Me.dtrCambioMan.Name = "dtrCambioMan"
        Me.dtrCambioMan.Size = New System.Drawing.Size(64, 18)
        Me.dtrCambioMan.TabIndex = 0
        Me.dtrCambioMan.TabStop = True
        Me.dtrCambioMan.Text = "Manual"
        Me.dtrCambioMan.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtrCambioMan.ThemeName = "Windows8"
        '
        'pnlSeparator_1
        '
        Me.pnlSeparator_1.Auto_Size = False
        Me.pnlSeparator_1.BackColor = System.Drawing.SystemColors.Control
        Me.pnlSeparator_1.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSeparator_1.ChangeDock = True
        Me.pnlSeparator_1.Control_Resize = False
        Me.pnlSeparator_1.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlSeparator_1.isSpace = True
        Me.pnlSeparator_1.Location = New System.Drawing.Point(0, 225)
        Me.pnlSeparator_1.Name = "pnlSeparator_1"
        Me.pnlSeparator_1.numRows = 0
        Me.pnlSeparator_1.Reorder = True
        Me.pnlSeparator_1.Size = New System.Drawing.Size(470, 5)
        Me.pnlSeparator_1.TabIndex = 1
        '
        'grbGen
        '
        Me.grbGen.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.grbGen.Controls.Add(Me.dtaExtra)
        Me.grbGen.Controls.Add(Me.pnlFechas)
        Me.grbGen.Controls.Add(Me.dtfDescLlavero)
        Me.grbGen.Controls.Add(Me.dtfGrupo)
        Me.grbGen.Controls.Add(Me.dtfReferencia)
        Me.grbGen.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbGen.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.grbGen.HeaderText = ""
        Me.grbGen.Location = New System.Drawing.Point(0, 0)
        Me.grbGen.Name = "grbGen"
        Me.grbGen.numRows = 0
        Me.grbGen.Padding = New System.Windows.Forms.Padding(6, 6, 6, 10)
        Me.grbGen.Reorder = True
        Me.grbGen.Size = New System.Drawing.Size(470, 225)
        Me.grbGen.TabIndex = 0
        Me.grbGen.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.grbGen.ThemeName = "Windows8"
        Me.grbGen.Title = ""
        '
        'dtaExtra
        '
        Me.dtaExtra.Allow_Empty = True
        Me.dtaExtra.Allow_Negative = True
        Me.dtaExtra.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtaExtra.BackColor = System.Drawing.SystemColors.Control
        Me.dtaExtra.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtaExtra.DataField = "MEXTRAS"
        Me.dtaExtra.DataTable = "MOD"
        Me.dtaExtra.Descripcion = "Extras"
        Me.dtaExtra.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtaExtra.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtaExtra.FocoEnAgregar = False
        Me.dtaExtra.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtaExtra.Length_Data = 32767
        Me.dtaExtra.Location = New System.Drawing.Point(6, 133)
        Me.dtaExtra.Max_Value = 0.0R
        Me.dtaExtra.MensajeIncorrectoCustom = Nothing
        Me.dtaExtra.Name = "dtaExtra"
        Me.dtaExtra.Null_on_Empty = True
        Me.dtaExtra.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtaExtra.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtaExtra.ReadOnly_Data = False
        Me.dtaExtra.Size = New System.Drawing.Size(458, 91)
        Me.dtaExtra.TabIndex = 4
        Me.dtaExtra.Text_Data = ""
        Me.dtaExtra.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtaExtra.TopPadding = 0
        Me.dtaExtra.Upper_Case = False
        Me.dtaExtra.Validate_on_lost_focus = True
        '
        'pnlFechas
        '
        Me.pnlFechas.Auto_Size = False
        Me.pnlFechas.BackColor = System.Drawing.SystemColors.Control
        Me.pnlFechas.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlFechas.ChangeDock = True
        Me.pnlFechas.Control_Resize = False
        Me.pnlFechas.Controls.Add(Me.pnlFecBaja)
        Me.pnlFechas.Controls.Add(Me.pnlFecMod)
        Me.pnlFechas.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFechas.isSpace = False
        Me.pnlFechas.Location = New System.Drawing.Point(6, 84)
        Me.pnlFechas.Name = "pnlFechas"
        Me.pnlFechas.numRows = 0
        Me.pnlFechas.Reorder = True
        Me.pnlFechas.Size = New System.Drawing.Size(458, 49)
        Me.pnlFechas.TabIndex = 3
        '
        'pnlFecBaja
        '
        Me.pnlFecBaja.Auto_Size = False
        Me.pnlFecBaja.BackColor = System.Drawing.SystemColors.Control
        Me.pnlFecBaja.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlFecBaja.ChangeDock = True
        Me.pnlFecBaja.Control_Resize = False
        Me.pnlFecBaja.Controls.Add(Me.dtdFecBaja)
        Me.pnlFecBaja.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFecBaja.isSpace = False
        Me.pnlFecBaja.Location = New System.Drawing.Point(0, 25)
        Me.pnlFecBaja.Name = "pnlFecBaja"
        Me.pnlFecBaja.numRows = 0
        Me.pnlFecBaja.Reorder = True
        Me.pnlFecBaja.Size = New System.Drawing.Size(458, 25)
        Me.pnlFecBaja.TabIndex = 1
        '
        'dtdFecBaja
        '
        Me.dtdFecBaja.Allow_Empty = True
        Me.dtdFecBaja.DataField = "FEBAJA"
        Me.dtdFecBaja.DataTable = "MOD"
        Me.dtdFecBaja.Default_Value = Nothing
        Me.dtdFecBaja.Descripcion = "Fec.Baja"
        Me.dtdFecBaja.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtdFecBaja.FocoEnAgregar = False
        Me.dtdFecBaja.Label_Space = 80
        Me.dtdFecBaja.Location = New System.Drawing.Point(0, 0)
        Me.dtdFecBaja.Max_Value = Nothing
        Me.dtdFecBaja.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdFecBaja.MensajeIncorrectoCustom = Nothing
        Me.dtdFecBaja.Min_Value = Nothing
        Me.dtdFecBaja.MinDate = New Date(CType(0, Long))
        Me.dtdFecBaja.MinimumSize = New System.Drawing.Size(170, 26)
        Me.dtdFecBaja.Name = "dtdFecBaja"
        Me.dtdFecBaja.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdFecBaja.ReadOnly_Data = False
        Me.dtdFecBaja.Size = New System.Drawing.Size(190, 26)
        Me.dtdFecBaja.TabIndex = 0
        Me.dtdFecBaja.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdFecBaja.Validate_on_lost_focus = True
        Me.dtdFecBaja.Value_Data = Nothing
        '
        'pnlFecMod
        '
        Me.pnlFecMod.Auto_Size = False
        Me.pnlFecMod.BackColor = System.Drawing.SystemColors.Control
        Me.pnlFecMod.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlFecMod.ChangeDock = True
        Me.pnlFecMod.Control_Resize = False
        Me.pnlFecMod.Controls.Add(Me.dtdFecMod)
        Me.pnlFecMod.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFecMod.isSpace = False
        Me.pnlFecMod.Location = New System.Drawing.Point(0, 0)
        Me.pnlFecMod.Name = "pnlFecMod"
        Me.pnlFecMod.numRows = 0
        Me.pnlFecMod.Reorder = True
        Me.pnlFecMod.Size = New System.Drawing.Size(458, 25)
        Me.pnlFecMod.TabIndex = 0
        '
        'dtdFecMod
        '
        Me.dtdFecMod.Allow_Empty = True
        Me.dtdFecMod.DataField = "FEMODELO"
        Me.dtdFecMod.DataTable = "MOD"
        Me.dtdFecMod.Default_Value = Nothing
        Me.dtdFecMod.Descripcion = "Fec.Modelo"
        Me.dtdFecMod.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtdFecMod.FocoEnAgregar = False
        Me.dtdFecMod.Label_Space = 80
        Me.dtdFecMod.Location = New System.Drawing.Point(0, 0)
        Me.dtdFecMod.Max_Value = Nothing
        Me.dtdFecMod.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdFecMod.MensajeIncorrectoCustom = Nothing
        Me.dtdFecMod.Min_Value = Nothing
        Me.dtdFecMod.MinDate = New Date(CType(0, Long))
        Me.dtdFecMod.MinimumSize = New System.Drawing.Size(170, 26)
        Me.dtdFecMod.Name = "dtdFecMod"
        Me.dtdFecMod.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdFecMod.ReadOnly_Data = False
        Me.dtdFecMod.Size = New System.Drawing.Size(190, 26)
        Me.dtdFecMod.TabIndex = 0
        Me.dtdFecMod.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdFecMod.Validate_on_lost_focus = True
        Me.dtdFecMod.Value_Data = Nothing
        '
        'dtfDescLlavero
        '
        Me.dtfDescLlavero.Allow_Empty = True
        Me.dtfDescLlavero.Allow_Negative = True
        Me.dtfDescLlavero.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfDescLlavero.BackColor = System.Drawing.SystemColors.Control
        Me.dtfDescLlavero.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfDescLlavero.DataField = "LLAVERO"
        Me.dtfDescLlavero.DataTable = "MOD"
        Me.dtfDescLlavero.Descripcion = "Desc.Llavero"
        Me.dtfDescLlavero.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfDescLlavero.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfDescLlavero.FocoEnAgregar = False
        Me.dtfDescLlavero.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfDescLlavero.Image = Nothing
        Me.dtfDescLlavero.Label_Space = 80
        Me.dtfDescLlavero.Length_Data = 32767
        Me.dtfDescLlavero.Location = New System.Drawing.Point(6, 58)
        Me.dtfDescLlavero.Max_Value = 0.0R
        Me.dtfDescLlavero.MensajeIncorrectoCustom = Nothing
        Me.dtfDescLlavero.Name = "dtfDescLlavero"
        Me.dtfDescLlavero.Null_on_Empty = True
        Me.dtfDescLlavero.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfDescLlavero.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfDescLlavero.ReadOnly_Data = False
        Me.dtfDescLlavero.Show_Button = False
        Me.dtfDescLlavero.Size = New System.Drawing.Size(458, 26)
        Me.dtfDescLlavero.TabIndex = 2
        Me.dtfDescLlavero.Text_Data = ""
        Me.dtfDescLlavero.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfDescLlavero.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfDescLlavero.TopPadding = 0
        Me.dtfDescLlavero.Upper_Case = False
        Me.dtfDescLlavero.Validate_on_lost_focus = True
        '
        'dtfGrupo
        '
        Me.dtfGrupo.Allow_Empty = False
        Me.dtfGrupo.Allow_Negative = True
        Me.dtfGrupo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfGrupo.BackColor = System.Drawing.SystemColors.Control
        Me.dtfGrupo.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfGrupo.DataField = "CATEGORIA"
        Me.dtfGrupo.DataTable = "MOD"
        Me.dtfGrupo.DB = Connection1
        Me.dtfGrupo.Desc_Datafield = "NOMBRE"
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
        Me.dtfGrupo.Formulario = "Karve.ConfiguracionApp.MarcasVehiculo"
        Me.dtfGrupo.Label_Space = 80
        Me.dtfGrupo.Length_Data = 32767
        Me.dtfGrupo.Location = New System.Drawing.Point(6, 32)
        Me.dtfGrupo.Lupa = ""
        Me.dtfGrupo.Max_Value = 0.0R
        Me.dtfGrupo.MensajeIncorrectoCustom = Nothing
        Me.dtfGrupo.Name = "dtfGrupo"
        Me.dtfGrupo.Null_on_Empty = True
        Me.dtfGrupo.OpenForm = "Karve.ConfiguracionApp.MarcasVehiculo"
        Me.dtfGrupo.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfGrupo.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfGrupo.Query_on_Text_Changed = True
        Me.dtfGrupo.ReadOnly_Data = False
        Me.dtfGrupo.ShowButton = True
        Me.dtfGrupo.Size = New System.Drawing.Size(458, 26)
        Me.dtfGrupo.TabIndex = 1
        Me.dtfGrupo.Text_Data = ""
        Me.dtfGrupo.Text_Data_Desc = ""
        Me.dtfGrupo.Text_Width = 58
        Me.dtfGrupo.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfGrupo.TopPadding = 0
        Me.dtfGrupo.Upper_Case = False
        Me.dtfGrupo.Validate_on_lost_focus = True
        '
        'dtfReferencia
        '
        Me.dtfReferencia.Allow_Empty = True
        Me.dtfReferencia.Allow_Negative = True
        Me.dtfReferencia.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfReferencia.BackColor = System.Drawing.SystemColors.Control
        Me.dtfReferencia.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfReferencia.DataField = "REFERE"
        Me.dtfReferencia.DataTable = "MOD"
        Me.dtfReferencia.Descripcion = "Referencia"
        Me.dtfReferencia.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfReferencia.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfReferencia.FocoEnAgregar = False
        Me.dtfReferencia.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfReferencia.Image = Nothing
        Me.dtfReferencia.Label_Space = 80
        Me.dtfReferencia.Length_Data = 32767
        Me.dtfReferencia.Location = New System.Drawing.Point(6, 6)
        Me.dtfReferencia.Max_Value = 0.0R
        Me.dtfReferencia.MensajeIncorrectoCustom = Nothing
        Me.dtfReferencia.Name = "dtfReferencia"
        Me.dtfReferencia.Null_on_Empty = True
        Me.dtfReferencia.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfReferencia.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfReferencia.ReadOnly_Data = False
        Me.dtfReferencia.Show_Button = False
        Me.dtfReferencia.Size = New System.Drawing.Size(458, 26)
        Me.dtfReferencia.TabIndex = 0
        Me.dtfReferencia.Text_Data = ""
        Me.dtfReferencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfReferencia.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfReferencia.TopPadding = 0
        Me.dtfReferencia.Upper_Case = False
        Me.dtfReferencia.Validate_on_lost_focus = True
        '
        'pnlPpalSoporte
        '
        Me.pnlPpalSoporte.Auto_Size = False
        Me.pnlPpalSoporte.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.pnlPpalSoporte.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlPpalSoporte.ChangeDock = False
        Me.pnlPpalSoporte.Control_Resize = False
        Me.pnlPpalSoporte.Controls.Add(Me.pnlPpal)
        Me.pnlPpalSoporte.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlPpalSoporte.isSpace = False
        Me.pnlPpalSoporte.Location = New System.Drawing.Point(0, 0)
        Me.pnlPpalSoporte.Name = "pnlPpalSoporte"
        Me.pnlPpalSoporte.numRows = 0
        Me.pnlPpalSoporte.Reorder = True
        Me.pnlPpalSoporte.Size = New System.Drawing.Size(943, 64)
        Me.pnlPpalSoporte.TabIndex = 2
        '
        'pnlPpal
        '
        Me.pnlPpal.Auto_Size = False
        Me.pnlPpal.BackColor = System.Drawing.SystemColors.Control
        Me.pnlPpal.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlPpal.ChangeDock = False
        Me.pnlPpal.Control_Resize = False
        Me.pnlPpal.Controls.Add(Me.pnlPie)
        Me.pnlPpal.Controls.Add(Me.pnlCodVarMar)
        Me.pnlPpal.Controls.Add(Me.pnlCodigo)
        Me.pnlPpal.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlPpal.isSpace = False
        Me.pnlPpal.Location = New System.Drawing.Point(0, 0)
        Me.pnlPpal.Name = "pnlPpal"
        Me.pnlPpal.numRows = 0
        Me.pnlPpal.Reorder = True
        Me.pnlPpal.Size = New System.Drawing.Size(943, 64)
        Me.pnlPpal.TabIndex = 0
        '
        'pnlPie
        '
        Me.pnlPie.Auto_Size = False
        Me.pnlPie.BackColor = System.Drawing.SystemColors.ControlDark
        Me.pnlPie.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlPie.ChangeDock = True
        Me.pnlPie.Control_Resize = False
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlPie.isSpace = False
        Me.pnlPie.Location = New System.Drawing.Point(0, 56)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.numRows = 0
        Me.pnlPie.Reorder = True
        Me.pnlPie.Size = New System.Drawing.Size(943, 3)
        Me.pnlPie.TabIndex = 2
        '
        'pnlCodVarMar
        '
        Me.pnlCodVarMar.Auto_Size = False
        Me.pnlCodVarMar.BackColor = System.Drawing.SystemColors.Control
        Me.pnlCodVarMar.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlCodVarMar.ChangeDock = True
        Me.pnlCodVarMar.Control_Resize = False
        Me.pnlCodVarMar.Controls.Add(Me.dtfNombre)
        Me.pnlCodVarMar.Controls.Add(Me.pnlCodVar)
        Me.pnlCodVarMar.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCodVarMar.isSpace = False
        Me.pnlCodVarMar.Location = New System.Drawing.Point(0, 30)
        Me.pnlCodVarMar.Name = "pnlCodVarMar"
        Me.pnlCodVarMar.numRows = 0
        Me.pnlCodVarMar.Reorder = True
        Me.pnlCodVarMar.Size = New System.Drawing.Size(943, 26)
        Me.pnlCodVarMar.TabIndex = 1
        '
        'dtfNombre
        '
        Me.dtfNombre.Allow_Empty = False
        Me.dtfNombre.Allow_Negative = True
        Me.dtfNombre.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfNombre.BackColor = System.Drawing.SystemColors.Control
        Me.dtfNombre.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfNombre.DataField = "NOMBRE"
        Me.dtfNombre.DataTable = "MOD"
        Me.dtfNombre.Descripcion = "Nombre"
        Me.dtfNombre.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfNombre.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfNombre.FocoEnAgregar = False
        Me.dtfNombre.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfNombre.Image = Nothing
        Me.dtfNombre.Label_Space = 75
        Me.dtfNombre.Length_Data = 32767
        Me.dtfNombre.Location = New System.Drawing.Point(253, 0)
        Me.dtfNombre.Max_Value = 0.0R
        Me.dtfNombre.MensajeIncorrectoCustom = Nothing
        Me.dtfNombre.Name = "dtfNombre"
        Me.dtfNombre.Null_on_Empty = True
        Me.dtfNombre.Padding = New System.Windows.Forms.Padding(0, 0, 5, 3)
        Me.dtfNombre.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfNombre.ReadOnly_Data = False
        Me.dtfNombre.Show_Button = False
        Me.dtfNombre.Size = New System.Drawing.Size(690, 26)
        Me.dtfNombre.TabIndex = 1
        Me.dtfNombre.Text_Data = ""
        Me.dtfNombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfNombre.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfNombre.TopPadding = 0
        Me.dtfNombre.Upper_Case = False
        Me.dtfNombre.Validate_on_lost_focus = True
        '
        'pnlCodVar
        '
        Me.pnlCodVar.Auto_Size = False
        Me.pnlCodVar.BackColor = System.Drawing.SystemColors.Control
        Me.pnlCodVar.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlCodVar.ChangeDock = True
        Me.pnlCodVar.Control_Resize = False
        Me.pnlCodVar.Controls.Add(Me.dfVariante)
        Me.pnlCodVar.Controls.Add(Me.pnlCiegoCodModVar)
        Me.pnlCodVar.Controls.Add(Me.dtfCod)
        Me.pnlCodVar.Controls.Add(Me.pnlLeftMargin)
        Me.pnlCodVar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlCodVar.isSpace = False
        Me.pnlCodVar.Location = New System.Drawing.Point(0, 0)
        Me.pnlCodVar.Name = "pnlCodVar"
        Me.pnlCodVar.numRows = 0
        Me.pnlCodVar.Reorder = True
        Me.pnlCodVar.Size = New System.Drawing.Size(253, 26)
        Me.pnlCodVar.TabIndex = 0
        '
        'dfVariante
        '
        Me.dfVariante.Allow_Empty = True
        Me.dfVariante.Allow_Negative = True
        Me.dfVariante.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dfVariante.BackColor = System.Drawing.SystemColors.Control
        Me.dfVariante.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dfVariante.DataField = "VARIANTE"
        Me.dfVariante.DataTable = "MOD"
        Me.dfVariante.Descripcion = Nothing
        Me.dfVariante.Dock = System.Windows.Forms.DockStyle.Left
        Me.dfVariante.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dfVariante.FocoEnAgregar = False
        Me.dfVariante.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dfVariante.Length_Data = 32767
        Me.dfVariante.Location = New System.Drawing.Point(165, 0)
        Me.dfVariante.Max_Value = 0.0R
        Me.dfVariante.MensajeIncorrectoCustom = Nothing
        Me.dfVariante.Name = "dfVariante"
        Me.dfVariante.Null_on_Empty = True
        Me.dfVariante.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dfVariante.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dfVariante.ReadOnly_Data = False
        Me.dfVariante.Size = New System.Drawing.Size(46, 26)
        Me.dfVariante.TabIndex = 3
        Me.dfVariante.Text_Data = ""
        Me.dfVariante.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dfVariante.TopPadding = 0
        Me.dfVariante.Upper_Case = False
        Me.dfVariante.Validate_on_lost_focus = True
        '
        'pnlCiegoCodModVar
        '
        Me.pnlCiegoCodModVar.Auto_Size = False
        Me.pnlCiegoCodModVar.BackColor = System.Drawing.SystemColors.Control
        Me.pnlCiegoCodModVar.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlCiegoCodModVar.ChangeDock = True
        Me.pnlCiegoCodModVar.Control_Resize = False
        Me.pnlCiegoCodModVar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlCiegoCodModVar.isSpace = False
        Me.pnlCiegoCodModVar.Location = New System.Drawing.Point(161, 0)
        Me.pnlCiegoCodModVar.Name = "pnlCiegoCodModVar"
        Me.pnlCiegoCodModVar.numRows = 0
        Me.pnlCiegoCodModVar.Reorder = True
        Me.pnlCiegoCodModVar.Size = New System.Drawing.Size(4, 26)
        Me.pnlCiegoCodModVar.TabIndex = 2
        '
        'dtfCod
        '
        Me.dtfCod.Allow_Empty = True
        Me.dtfCod.Allow_Negative = True
        Me.dtfCod.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfCod.BackColor = System.Drawing.SystemColors.Control
        Me.dtfCod.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfCod.DataField = "CODIGO"
        Me.dtfCod.DataTable = "MOD"
        Me.dtfCod.Descripcion = "Modelo/Variante"
        Me.dtfCod.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfCod.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfCod.FocoEnAgregar = False
        Me.dtfCod.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfCod.Image = Nothing
        Me.dtfCod.Label_Space = 110
        Me.dtfCod.Length_Data = 32767
        Me.dtfCod.Location = New System.Drawing.Point(10, 0)
        Me.dtfCod.Max_Value = 0.0R
        Me.dtfCod.MensajeIncorrectoCustom = Nothing
        Me.dtfCod.Name = "dtfCod"
        Me.dtfCod.Null_on_Empty = True
        Me.dtfCod.Padding = New System.Windows.Forms.Padding(0, 0, 1, 3)
        Me.dtfCod.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfCod.ReadOnly_Data = False
        Me.dtfCod.Show_Button = False
        Me.dtfCod.Size = New System.Drawing.Size(151, 26)
        Me.dtfCod.TabIndex = 1
        Me.dtfCod.Text_Data = ""
        Me.dtfCod.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfCod.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfCod.TopPadding = 0
        Me.dtfCod.Upper_Case = False
        Me.dtfCod.Validate_on_lost_focus = True
        '
        'pnlLeftMargin
        '
        Me.pnlLeftMargin.Auto_Size = False
        Me.pnlLeftMargin.BackColor = System.Drawing.SystemColors.Control
        Me.pnlLeftMargin.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlLeftMargin.ChangeDock = True
        Me.pnlLeftMargin.Control_Resize = False
        Me.pnlLeftMargin.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlLeftMargin.isSpace = False
        Me.pnlLeftMargin.Location = New System.Drawing.Point(0, 0)
        Me.pnlLeftMargin.Name = "pnlLeftMargin"
        Me.pnlLeftMargin.numRows = 0
        Me.pnlLeftMargin.Reorder = True
        Me.pnlLeftMargin.Size = New System.Drawing.Size(10, 26)
        Me.pnlLeftMargin.TabIndex = 0
        '
        'pnlCodigo
        '
        Me.pnlCodigo.Auto_Size = False
        Me.pnlCodigo.BackColor = System.Drawing.SystemColors.Control
        Me.pnlCodigo.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlCodigo.ChangeDock = True
        Me.pnlCodigo.Control_Resize = False
        Me.pnlCodigo.Controls.Add(Me.pnlMarca)
        Me.pnlCodigo.Controls.Add(Me.pnlCiego)
        Me.pnlCodigo.Controls.Add(Me.dtfCodigo)
        Me.pnlCodigo.Controls.Add(Me.pnlLeftMarginCodigo)
        Me.pnlCodigo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCodigo.isSpace = False
        Me.pnlCodigo.Location = New System.Drawing.Point(0, 0)
        Me.pnlCodigo.Name = "pnlCodigo"
        Me.pnlCodigo.numRows = 0
        Me.pnlCodigo.Padding = New System.Windows.Forms.Padding(0, 5, 5, 5)
        Me.pnlCodigo.Reorder = True
        Me.pnlCodigo.Size = New System.Drawing.Size(943, 30)
        Me.pnlCodigo.TabIndex = 0
        '
        'pnlMarca
        '
        Me.pnlMarca.Auto_Size = False
        Me.pnlMarca.BackColor = System.Drawing.SystemColors.Control
        Me.pnlMarca.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlMarca.ChangeDock = True
        Me.pnlMarca.Control_Resize = False
        Me.pnlMarca.Controls.Add(Me.dtfMarca)
        Me.pnlMarca.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlMarca.isSpace = False
        Me.pnlMarca.Location = New System.Drawing.Point(253, 5)
        Me.pnlMarca.Name = "pnlMarca"
        Me.pnlMarca.numRows = 0
        Me.pnlMarca.Reorder = True
        Me.pnlMarca.Size = New System.Drawing.Size(685, 20)
        Me.pnlMarca.TabIndex = 3
        '
        'dtfMarca
        '
        Me.dtfMarca.Allow_Empty = False
        Me.dtfMarca.Allow_Negative = True
        Me.dtfMarca.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfMarca.BackColor = System.Drawing.SystemColors.Control
        Me.dtfMarca.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfMarca.DataField = "MARCA"
        Me.dtfMarca.DataField_DescEdit = "NOMMARCA"
        Me.dtfMarca.DataTable = "MOD"
        Me.dtfMarca.DataTable_DescEdit = "MOD"
        Me.dtfMarca.DB = Connection2
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
        Me.dtfMarca.ShowButton = True
        Me.dtfMarca.Size = New System.Drawing.Size(685, 26)
        Me.dtfMarca.TabIndex = 0
        Me.dtfMarca.Text_Data = ""
        Me.dtfMarca.Text_Data_Desc = ""
        Me.dtfMarca.Text_Width = 58
        Me.dtfMarca.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfMarca.TopPadding = 0
        Me.dtfMarca.Upper_Case = False
        Me.dtfMarca.Validate_on_lost_focus = True
        '
        'pnlCiego
        '
        Me.pnlCiego.Auto_Size = False
        Me.pnlCiego.BackColor = System.Drawing.SystemColors.Control
        Me.pnlCiego.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlCiego.ChangeDock = True
        Me.pnlCiego.Control_Resize = False
        Me.pnlCiego.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlCiego.isSpace = True
        Me.pnlCiego.Location = New System.Drawing.Point(211, 5)
        Me.pnlCiego.Name = "pnlCiego"
        Me.pnlCiego.numRows = 0
        Me.pnlCiego.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.pnlCiego.Reorder = True
        Me.pnlCiego.Size = New System.Drawing.Size(42, 20)
        Me.pnlCiego.TabIndex = 2
        '
        'dtfCodigo
        '
        Me.dtfCodigo.Allow_Empty = False
        Me.dtfCodigo.Allow_Negative = True
        Me.dtfCodigo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfCodigo.BackColor = System.Drawing.SystemColors.Control
        Me.dtfCodigo.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfCodigo.DataField = "COD_MOD"
        Me.dtfCodigo.DataTable = "MOD"
        Me.dtfCodigo.Descripcion = "Código"
        Me.dtfCodigo.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfCodigo.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfCodigo.FocoEnAgregar = False
        Me.dtfCodigo.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfCodigo.Image = Nothing
        Me.dtfCodigo.Label_Space = 110
        Me.dtfCodigo.Length_Data = 32767
        Me.dtfCodigo.Location = New System.Drawing.Point(10, 5)
        Me.dtfCodigo.Max_Value = 0.0R
        Me.dtfCodigo.MensajeIncorrectoCustom = Nothing
        Me.dtfCodigo.Name = "dtfCodigo"
        Me.dtfCodigo.Null_on_Empty = True
        Me.dtfCodigo.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfCodigo.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfCodigo.ReadOnly_Data = True
        Me.dtfCodigo.Show_Button = False
        Me.dtfCodigo.Size = New System.Drawing.Size(201, 20)
        Me.dtfCodigo.TabIndex = 1
        Me.dtfCodigo.TabStop = False
        Me.dtfCodigo.Text_Data = ""
        Me.dtfCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfCodigo.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfCodigo.TopPadding = 0
        Me.dtfCodigo.Upper_Case = True
        Me.dtfCodigo.Validate_on_lost_focus = True
        '
        'pnlLeftMarginCodigo
        '
        Me.pnlLeftMarginCodigo.Auto_Size = False
        Me.pnlLeftMarginCodigo.BackColor = System.Drawing.SystemColors.Control
        Me.pnlLeftMarginCodigo.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlLeftMarginCodigo.ChangeDock = True
        Me.pnlLeftMarginCodigo.Control_Resize = False
        Me.pnlLeftMarginCodigo.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlLeftMarginCodigo.isSpace = True
        Me.pnlLeftMarginCodigo.Location = New System.Drawing.Point(0, 5)
        Me.pnlLeftMarginCodigo.Name = "pnlLeftMarginCodigo"
        Me.pnlLeftMarginCodigo.numRows = 0
        Me.pnlLeftMarginCodigo.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.pnlLeftMarginCodigo.Reorder = True
        Me.pnlLeftMarginCodigo.Size = New System.Drawing.Size(10, 20)
        Me.pnlLeftMarginCodigo.TabIndex = 0
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
        Me.pnlBottomGen.Location = New System.Drawing.Point(0, 524)
        Me.pnlBottomGen.Name = "pnlBottomGen"
        Me.pnlBottomGen.numRows = 1
        Me.pnlBottomGen.Reorder = True
        Me.pnlBottomGen.Size = New System.Drawing.Size(1077, 26)
        Me.pnlBottomGen.TabIndex = 3
        '
        'dtlUltmodi
        '
        Me.dtlUltmodi.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtlUltmodi.AutoSize = False
        Me.dtlUltmodi.BorderVisible = True
        Me.dtlUltmodi.DataField = "ULTMODI"
        Me.dtlUltmodi.DataTable = "MOD"
        Me.dtlUltmodi.Descripcion = ""
        Me.dtlUltmodi.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtlUltmodi.Fromat = CustomControls.DataLabel.fotmatType.ultmodi
        Me.dtlUltmodi.Location = New System.Drawing.Point(945, 6)
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
        Me.dtlUsumodi.DataTable = "MOD"
        Me.dtlUsumodi.Descripcion = ""
        Me.dtlUsumodi.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtlUsumodi.Fromat = CustomControls.DataLabel.fotmatType.plain
        Me.dtlUsumodi.Location = New System.Drawing.Point(901, 6)
        Me.dtlUsumodi.Name = "dtlUsumodi"
        Me.dtlUsumodi.Size = New System.Drawing.Size(38, 17)
        Me.dtlUsumodi.TabIndex = 0
        Me.dtlUsumodi.TextAlignment = System.Drawing.ContentAlignment.TopCenter
        '
        'pvpMantenimientos
        '
        Me.pvpMantenimientos.Controls.Add(Me.pnlManSoporte)
        Me.pvpMantenimientos.ItemSize = New System.Drawing.SizeF(102.0!, 23.0!)
        Me.pvpMantenimientos.Location = New System.Drawing.Point(129, 5)
        Me.pvpMantenimientos.Name = "pvpMantenimientos"
        Me.pvpMantenimientos.PanelCabezeraContainer = Nothing
        Me.pvpMantenimientos.Size = New System.Drawing.Size(943, 489)
        Me.pvpMantenimientos.Text = "Mantenimientos"
        '
        'pnlManSoporte
        '
        Me.pnlManSoporte.Auto_Size = False
        Me.pnlManSoporte.BackColor = System.Drawing.SystemColors.Control
        Me.pnlManSoporte.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlManSoporte.ChangeDock = False
        Me.pnlManSoporte.Control_Resize = False
        Me.pnlManSoporte.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlManSoporte.isSpace = False
        Me.pnlManSoporte.Location = New System.Drawing.Point(0, 0)
        Me.pnlManSoporte.Name = "pnlManSoporte"
        Me.pnlManSoporte.numRows = 0
        Me.pnlManSoporte.Reorder = True
        Me.pnlManSoporte.Size = New System.Drawing.Size(943, 80)
        Me.pnlManSoporte.TabIndex = 0
        '
        'pvpFoto
        '
        Me.pvpFoto.Controls.Add(Me.pnlFotoSoporte)
        Me.pvpFoto.ItemSize = New System.Drawing.SizeF(102.0!, 23.0!)
        Me.pvpFoto.Location = New System.Drawing.Point(129, 5)
        Me.pvpFoto.Name = "pvpFoto"
        Me.pvpFoto.PanelCabezeraContainer = Nothing
        Me.pvpFoto.Size = New System.Drawing.Size(943, 489)
        Me.pvpFoto.Text = "Foto"
        '
        'pnlFotoSoporte
        '
        Me.pnlFotoSoporte.Auto_Size = False
        Me.pnlFotoSoporte.BackColor = System.Drawing.SystemColors.Control
        Me.pnlFotoSoporte.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlFotoSoporte.ChangeDock = False
        Me.pnlFotoSoporte.Control_Resize = False
        Me.pnlFotoSoporte.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFotoSoporte.isSpace = False
        Me.pnlFotoSoporte.Location = New System.Drawing.Point(0, 0)
        Me.pnlFotoSoporte.Name = "pnlFotoSoporte"
        Me.pnlFotoSoporte.numRows = 0
        Me.pnlFotoSoporte.Reorder = True
        Me.pnlFotoSoporte.Size = New System.Drawing.Size(943, 80)
        Me.pnlFotoSoporte.TabIndex = 1
        '
        'pvpExtras
        '
        Me.pvpExtras.Controls.Add(Me.dgvExtras)
        Me.pvpExtras.Controls.Add(Me.pnlExtrasSoporte)
        Me.pvpExtras.ItemSize = New System.Drawing.SizeF(102.0!, 23.0!)
        Me.pvpExtras.Location = New System.Drawing.Point(129, 5)
        Me.pvpExtras.Name = "pvpExtras"
        Me.pvpExtras.PanelCabezeraContainer = Nothing
        Me.pvpExtras.Size = New System.Drawing.Size(943, 489)
        Me.pvpExtras.Text = "Extras"
        '
        'dgvExtras
        '
        Me.dgvExtras.ColRel = Nothing
        Me.dgvExtras.ColSelectFilter = Nothing
        Me.dgvExtras.DataGridType = CustomControls.DataGrid.GridType.Edit
        Me.dgvExtras.DBConnection = Nothing
        Me.dgvExtras.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvExtras.EnforceConstrains = True
        Me.dgvExtras.idRel = Nothing
        Me.dgvExtras.Location = New System.Drawing.Point(0, 80)
        Me.dgvExtras.MarcarFilas = False
        '
        'dgvExtras
        '
        Me.dgvExtras.MasterTemplate.EnableFiltering = True
        Me.dgvExtras.MasterTemplate.MultiSelect = True
        Me.dgvExtras.MasterTemplate.SelectionMode = Telerik.WinControls.UI.GridViewSelectionMode.CellSelect
        Me.dgvExtras.Name = "dgvExtras"
        Me.dgvExtras.Size = New System.Drawing.Size(943, 409)
        Me.dgvExtras.TabIndex = 2
        Me.dgvExtras.TablaEdit = Nothing
        Me.dgvExtras.Text = "GridExtras1"
        Me.dgvExtras.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dgvExtras.ThemeName = "TelerikMetroBlue"
        '
        'pnlExtrasSoporte
        '
        Me.pnlExtrasSoporte.Auto_Size = False
        Me.pnlExtrasSoporte.BackColor = System.Drawing.SystemColors.Control
        Me.pnlExtrasSoporte.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlExtrasSoporte.ChangeDock = False
        Me.pnlExtrasSoporte.Control_Resize = False
        Me.pnlExtrasSoporte.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlExtrasSoporte.isSpace = False
        Me.pnlExtrasSoporte.Location = New System.Drawing.Point(0, 0)
        Me.pnlExtrasSoporte.Name = "pnlExtrasSoporte"
        Me.pnlExtrasSoporte.numRows = 0
        Me.pnlExtrasSoporte.Reorder = True
        Me.pnlExtrasSoporte.Size = New System.Drawing.Size(943, 80)
        Me.pnlExtrasSoporte.TabIndex = 1
        '
        'pvpFichaTecnica
        '
        Me.pvpFichaTecnica.Controls.Add(Me.ftecModelo)
        Me.pvpFichaTecnica.Controls.Add(Me.pnlFtecSoporte)
        Me.pvpFichaTecnica.ItemSize = New System.Drawing.SizeF(102.0!, 23.0!)
        Me.pvpFichaTecnica.Location = New System.Drawing.Point(129, 5)
        Me.pvpFichaTecnica.Name = "pvpFichaTecnica"
        Me.pvpFichaTecnica.PanelCabezeraContainer = Nothing
        Me.pvpFichaTecnica.Size = New System.Drawing.Size(943, 489)
        Me.pvpFichaTecnica.Text = "Ficha Tecnica"
        '
        'ftecModelo
        '
        Me.ftecModelo.DataTable = "MOD"
        Me.ftecModelo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ftecModelo.Location = New System.Drawing.Point(0, 80)
        Me.ftecModelo.Name = "ftecModelo"
        Me.ftecModelo.Size = New System.Drawing.Size(943, 409)
        Me.ftecModelo.TabIndex = 0
        '
        'pnlFtecSoporte
        '
        Me.pnlFtecSoporte.Auto_Size = False
        Me.pnlFtecSoporte.BackColor = System.Drawing.SystemColors.Control
        Me.pnlFtecSoporte.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlFtecSoporte.ChangeDock = False
        Me.pnlFtecSoporte.Control_Resize = False
        Me.pnlFtecSoporte.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFtecSoporte.isSpace = False
        Me.pnlFtecSoporte.Location = New System.Drawing.Point(0, 0)
        Me.pnlFtecSoporte.Name = "pnlFtecSoporte"
        Me.pnlFtecSoporte.numRows = 0
        Me.pnlFtecSoporte.Reorder = True
        Me.pnlFtecSoporte.Size = New System.Drawing.Size(943, 80)
        Me.pnlFtecSoporte.TabIndex = 1
        '
        'ModelosVehiculo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1077, 710)
        Me.Controls.Add(Me.pnlBottomGen)
        Me.Name = "ModelosVehiculo"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "ModelosVehiculo"
        Me.Controls.SetChildIndex(Me.pnlBottomGen, 0)
        Me.Controls.SetChildIndex(Me.stbBase, 0)
        Me.Controls.SetChildIndex(Me.pvwBase, 0)
        Me.Controls.SetChildIndex(Me.pnlBlock, 0)
        CType(Me.pnlBlock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pvwBase, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pvwBase.ResumeLayout(False)
        CType(Me.stbBase, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pvpGeneral.ResumeLayout(False)
        CType(Me.pnlGenRight, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlGenRight.ResumeLayout(False)
        CType(Me.grbR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbR.ResumeLayout(False)
        CType(Me.pnlOtros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlOtros.ResumeLayout(False)
        CType(Me.Panel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.pnlOtrosL2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlOtrosL2.ResumeLayout(False)
        CType(Me.pnlSeparator_2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlOtrosL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlOtrosL.ResumeLayout(False)
        CType(Me.pnlMantecada, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMantecada.ResumeLayout(False)
        CType(Me.pnlMantecadaR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMantecadaR.ResumeLayout(False)
        CType(Me.pnlConsumo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlConsumo.ResumeLayout(False)
        CType(Me.pnlConsumoR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlConsumoR.ResumeLayout(False)
        CType(Me.pnlDeposito, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDeposito.ResumeLayout(False)
        CType(Me.pnlDepositoLiteral, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDepositoLiteral.ResumeLayout(False)
        CType(Me.pnlGenLeft, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlGenLeft.ResumeLayout(False)
        CType(Me.grbGenOps, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbGenOps.ResumeLayout(False)
        CType(Me.pnlOpsR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlOpsR.ResumeLayout(False)
        CType(Me.pnlLeftOps, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlLeftOps.ResumeLayout(False)
        CType(Me.pnlRightOpsCh, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlRightOpsCh.ResumeLayout(False)
        Me.pnlRightOpsCh.PerformLayout()
        CType(Me.chhDirAsis, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkAbs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlLeftOpsCh, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlLeftOpsCh.ResumeLayout(False)
        Me.pnlLeftOpsCh.PerformLayout()
        CType(Me.chkAA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkRadio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rdgTipoCombus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rdgTipoCombus.ResumeLayout(False)
        Me.rdgTipoCombus.PerformLayout()
        CType(Me.dtsElectrico, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtrGasolina, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtrDiesel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rdgTipoCambio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rdgTipoCambio.ResumeLayout(False)
        Me.rdgTipoCambio.PerformLayout()
        CType(Me.dtrCambioSem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtrCambioAut, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtrCambioMan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSeparator_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grbGen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbGen.ResumeLayout(False)
        CType(Me.pnlFechas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFechas.ResumeLayout(False)
        CType(Me.pnlFecBaja, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFecBaja.ResumeLayout(False)
        CType(Me.pnlFecMod, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFecMod.ResumeLayout(False)
        CType(Me.pnlPpalSoporte, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPpalSoporte.ResumeLayout(False)
        CType(Me.pnlPpal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPpal.ResumeLayout(False)
        CType(Me.pnlPie, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlCodVarMar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCodVarMar.ResumeLayout(False)
        CType(Me.pnlCodVar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCodVar.ResumeLayout(False)
        CType(Me.pnlCiegoCodModVar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlLeftMargin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlCodigo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCodigo.ResumeLayout(False)
        CType(Me.pnlMarca, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMarca.ResumeLayout(False)
        CType(Me.pnlCiego, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlLeftMarginCodigo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlBottomGen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBottomGen.ResumeLayout(False)
        CType(Me.dtlUltmodi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtlUsumodi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pvpMantenimientos.ResumeLayout(False)
        CType(Me.pnlManSoporte, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pvpFoto.ResumeLayout(False)
        CType(Me.pnlFotoSoporte, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pvpExtras.ResumeLayout(False)
        CType(Me.dgvExtras.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvExtras, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlExtrasSoporte, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pvpFichaTecnica.ResumeLayout(False)
        CType(Me.pnlFtecSoporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pvpGeneral As CustomControls.PageViewPage
    Friend WithEvents pnlBottomGen As CustomControls.Panel
    Friend WithEvents dtlUltmodi As CustomControls.DataLabel
    Friend WithEvents dtlUsumodi As CustomControls.DataLabel
    Friend WithEvents pvpMantenimientos As CustomControls.PageViewPage
    Friend WithEvents pvpFoto As CustomControls.PageViewPage
    Friend WithEvents pvpExtras As CustomControls.PageViewPage
    Friend WithEvents pvpFichaTecnica As CustomControls.PageViewPage
    Friend WithEvents pnlGenRight As CustomControls.Panel
    Friend WithEvents pnlGenLeft As CustomControls.Panel
    Friend WithEvents grbGen As CustomControls.GroupBox
    Friend WithEvents dtfReferencia As CustomControls.DatafieldLabel
    Friend WithEvents dtfGrupo As CustomControls.DualDatafieldLabel
    Friend WithEvents dtfDescLlavero As CustomControls.DatafieldLabel
    Friend WithEvents pnlFechas As CustomControls.Panel
    Friend WithEvents pnlFecBaja As CustomControls.Panel
    Friend WithEvents dtdFecBaja As CustomControls.DataDateLabel
    Friend WithEvents pnlFecMod As CustomControls.Panel
    Friend WithEvents dtdFecMod As CustomControls.DataDateLabel
    Friend WithEvents pnlSeparator_1 As CustomControls.Panel
    Friend WithEvents rdgTipoCambio As CustomControls.RadioGroup
    Friend WithEvents dtaExtra As CustomControls.DataAreaLabel
    Friend WithEvents dtrCambioSem As CustomControls.DataRadio
    Friend WithEvents dtrCambioAut As CustomControls.DataRadio
    Friend WithEvents dtrCambioMan As CustomControls.DataRadio
    Friend WithEvents grbR As CustomControls.GroupBox
    Friend WithEvents pnlConsumo As CustomControls.Panel
    Friend WithEvents dtfConsumo As CustomControls.DatafieldLabel
    Friend WithEvents pnlConsumoR As CustomControls.Panel
    Friend WithEvents dfConsumo As CustomControls.Datafield
    Friend WithEvents pnlDeposito As CustomControls.Panel
    Friend WithEvents dtfDeposito As CustomControls.DatafieldLabel
    Friend WithEvents pnlDepositoLiteral As CustomControls.Panel
    Friend WithEvents dfDeposito As CustomControls.Datafield
    Friend WithEvents pnlMantecada As CustomControls.Panel
    Friend WithEvents dtfMantecada As CustomControls.DatafieldLabel
    Friend WithEvents pnlMantecadaR As CustomControls.Panel
    Friend WithEvents dfMantecada As CustomControls.Datafield
    Friend WithEvents dtfPrefijoBastidor As CustomControls.DatafieldLabel
    Friend WithEvents dtfObs As CustomControls.DataAreaLabel
    Friend WithEvents dtfSeguridad As CustomControls.DataAreaLabel
    Friend WithEvents dtfMotor As CustomControls.DatafieldLabel
    Friend WithEvents dtfCilindrada As CustomControls.DatafieldLabel
    Friend WithEvents pnlOtros As CustomControls.Panel
    Friend WithEvents Panel1 As CustomControls.Panel
    Friend WithEvents pnlOtrosL2 As CustomControls.Panel
    Friend WithEvents DatafieldLabel3 As CustomControls.DatafieldLabel
    Friend WithEvents DatafieldLabel4 As CustomControls.DatafieldLabel
    Friend WithEvents pnlSeparator_2 As CustomControls.Panel
    Friend WithEvents pnlOtrosL As CustomControls.Panel
    Friend WithEvents DatafieldLabel2 As CustomControls.DatafieldLabel
    Friend WithEvents DatafieldLabel1 As CustomControls.DatafieldLabel
    Friend WithEvents grbGenOps As CustomControls.GroupBox
    Friend WithEvents pnlOpsR As CustomControls.Panel
    Friend WithEvents dtfPlazas As CustomControls.DatafieldLabel
    Friend WithEvents dtfPuertas As CustomControls.DatafieldLabel
    Friend WithEvents dtfAirbags As CustomControls.DatafieldLabel
    Friend WithEvents pnlLeftOps As CustomControls.Panel
    Friend WithEvents pnlRightOpsCh As CustomControls.Panel
    Friend WithEvents chhDirAsis As CustomControls.DataCheck
    Friend WithEvents chkAbs As CustomControls.DataCheck
    Friend WithEvents pnlLeftOpsCh As CustomControls.Panel
    Friend WithEvents chkAA As CustomControls.DataCheck
    Friend WithEvents chkRadio As CustomControls.DataCheck
    Friend WithEvents rdgTipoCombus As CustomControls.RadioGroup
    Friend WithEvents dtsElectrico As CustomControls.DataRadio
    Friend WithEvents dtrGasolina As CustomControls.DataRadio
    Friend WithEvents dtrDiesel As CustomControls.DataRadio
    Friend WithEvents ftecModelo As Karve.frm.Auxiliares.FichaTecnica
    Friend WithEvents pnlPpalSoporte As CustomControls.Panel
    Friend WithEvents pnlPpal As CustomControls.Panel
    Friend WithEvents pnlPie As CustomControls.Panel
    Friend WithEvents pnlCodVarMar As CustomControls.Panel
    Friend WithEvents dtfNombre As CustomControls.DatafieldLabel
    Friend WithEvents pnlCodVar As CustomControls.Panel
    Friend WithEvents dfVariante As CustomControls.Datafield
    Friend WithEvents pnlCiegoCodModVar As CustomControls.Panel
    Friend WithEvents dtfCod As CustomControls.DatafieldLabel
    Friend WithEvents pnlLeftMargin As CustomControls.Panel
    Friend WithEvents pnlCodigo As CustomControls.Panel
    Friend WithEvents pnlMarca As CustomControls.Panel
    Friend WithEvents dtfMarca As CustomControls.DualDataFieldEditableLabel
    Friend WithEvents pnlCiego As CustomControls.Panel
    Friend WithEvents dtfCodigo As CustomControls.DatafieldLabel
    Friend WithEvents pnlLeftMarginCodigo As CustomControls.Panel
    Friend WithEvents pnlManSoporte As CustomControls.Panel
    Friend WithEvents pnlFotoSoporte As CustomControls.Panel
    Friend WithEvents pnlExtrasSoporte As CustomControls.Panel
    Friend WithEvents pnlFtecSoporte As CustomControls.Panel
    Friend WithEvents dgvExtras As Karve.frm.Auxiliares.GridExtras
End Class
