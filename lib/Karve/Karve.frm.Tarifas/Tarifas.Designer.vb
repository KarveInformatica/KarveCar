<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Tarifas
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
        Me.pvpGeneral = New CustomControls.PageViewPage()
        Me.pnlGeneralDer = New CustomControls.Panel()
        Me.dtaCondiciones = New CustomControls.DataAreaLabel()
        Me.dtaObservaciones = New CustomControls.DataAreaLabel()
        Me.gbxChecks = New CustomControls.GroupBox()
        Me.pnlChecksCol2 = New CustomControls.Panel()
        Me.DataCheck26 = New CustomControls.DataCheck()
        Me.DataCheck24 = New CustomControls.DataCheck()
        Me.DataCheck22 = New CustomControls.DataCheck()
        Me.DataCheck20 = New CustomControls.DataCheck()
        Me.DataCheck19 = New CustomControls.DataCheck()
        Me.DataCheck16 = New CustomControls.DataCheck()
        Me.DataCheck15 = New CustomControls.DataCheck()
        Me.DataCheck14 = New CustomControls.DataCheck()
        Me.DataCheck13 = New CustomControls.DataCheck()
        Me.DataCheck12 = New CustomControls.DataCheck()
        Me.DataCheck11 = New CustomControls.DataCheck()
        Me.DataCheck10 = New CustomControls.DataCheck()
        Me.DataCheck8 = New CustomControls.DataCheck()
        Me.pnlChecksCol1 = New CustomControls.Panel()
        Me.DataCheck25 = New CustomControls.DataCheck()
        Me.DataCheck23 = New CustomControls.DataCheck()
        Me.DataCheck21 = New CustomControls.DataCheck()
        Me.DataCheck18 = New CustomControls.DataCheck()
        Me.DataCheck17 = New CustomControls.DataCheck()
        Me.DataCheck7 = New CustomControls.DataCheck()
        Me.DataCheck6 = New CustomControls.DataCheck()
        Me.DataCheck5 = New CustomControls.DataCheck()
        Me.DataCheck4 = New CustomControls.DataCheck()
        Me.DataCheck3 = New CustomControls.DataCheck()
        Me.DataCheck9 = New CustomControls.DataCheck()
        Me.DataCheck2 = New CustomControls.DataCheck()
        Me.DataCheck1 = New CustomControls.DataCheck()
        Me.pnlGeneralIzq = New CustomControls.Panel()
        Me.DualDatafieldLabel4 = New CustomControls.DualDatafieldLabel()
        Me.DualDatafieldLabel3 = New CustomControls.DualDatafieldLabel()
        Me.DualDatafieldLabel2 = New CustomControls.DualDatafieldLabel()
        Me.pnlSapce25 = New CustomControls.Panel()
        Me.GroupBox1 = New CustomControls.GroupBox()
        Me.rdgCobrosDefecto = New CustomControls.RadioGroup()
        Me.DataRadio2 = New CustomControls.DataRadio()
        Me.DataRadio1 = New CustomControls.DataRadio()
        Me.DataCheck27 = New CustomControls.DataCheck()
        Me.DualDatafieldLabel1 = New CustomControls.DualDatafieldLabel()
        Me.pnlDtosPrioridad = New CustomControls.Panel()
        Me.DatafieldLabel5 = New CustomControls.DatafieldLabel()
        Me.pnlSapce23 = New CustomControls.Panel()
        Me.DatafieldLabel4 = New CustomControls.DatafieldLabel()
        Me.pnlSapce22 = New CustomControls.Panel()
        Me.DatafieldLabel3 = New CustomControls.DatafieldLabel()
        Me.pnlSapce21 = New CustomControls.Panel()
        Me.lblPorcenDto2 = New CustomControls.Label()
        Me.DatafieldLabel2 = New CustomControls.DatafieldLabel()
        Me.pnlSapce20 = New CustomControls.Panel()
        Me.lblPorcenDto = New CustomControls.Label()
        Me.DatafieldLabel1 = New CustomControls.DatafieldLabel()
        Me.pnlSpace19 = New CustomControls.Panel()
        Me.gbxFechasValidez = New CustomControls.GroupBox()
        Me.gbxVapidezPreaviso = New CustomControls.GroupBox()
        Me.dtfPreaviso = New CustomControls.DatafieldLabel()
        Me.pnlSpace18 = New CustomControls.Panel()
        Me.dtfValidezMaximo = New CustomControls.DatafieldLabel()
        Me.pnlSpace17 = New CustomControls.Panel()
        Me.dtfValidezMinimo = New CustomControls.DatafieldLabel()
        Me.pnlFechasSalidaRetorno = New CustomControls.Panel()
        Me.gbxRetorno = New CustomControls.GroupBox()
        Me.pnlRetornoDesde5 = New CustomControls.Panel()
        Me.dtdRetornoHasta5 = New CustomControls.DataDateLabel()
        Me.pnlSpace15 = New CustomControls.Panel()
        Me.dtdRetornoDesde5 = New CustomControls.DataDateLabel()
        Me.pnlRetornoDesde4 = New CustomControls.Panel()
        Me.dtdRetornoHasta4 = New CustomControls.DataDateLabel()
        Me.pnlSpace14 = New CustomControls.Panel()
        Me.dtdRetornoDesde4 = New CustomControls.DataDateLabel()
        Me.pnlRetornoDesde3 = New CustomControls.Panel()
        Me.dtdRetornoHasta3 = New CustomControls.DataDateLabel()
        Me.pnlSpace13 = New CustomControls.Panel()
        Me.dtdRetornoDesde3 = New CustomControls.DataDateLabel()
        Me.pnlRetornoDesde2 = New CustomControls.Panel()
        Me.dtdRetornoHasta2 = New CustomControls.DataDateLabel()
        Me.pnlSpace12 = New CustomControls.Panel()
        Me.dtdRetornoDesde2 = New CustomControls.DataDateLabel()
        Me.pnlRetornoDesde = New CustomControls.Panel()
        Me.dtdRetornoHasta = New CustomControls.DataDateLabel()
        Me.pnlSpace11 = New CustomControls.Panel()
        Me.dtdRetornoDesde = New CustomControls.DataDateLabel()
        Me.pnlSpace16 = New CustomControls.Panel()
        Me.gbxSalida = New CustomControls.GroupBox()
        Me.pnlSalidaDesde5 = New CustomControls.Panel()
        Me.dtdSalidaHasta5 = New CustomControls.DataDateLabel()
        Me.pnlSpace10 = New CustomControls.Panel()
        Me.dtdSalidaDesde5 = New CustomControls.DataDateLabel()
        Me.pnlSalidaDesde4 = New CustomControls.Panel()
        Me.dtdSalidaHasta4 = New CustomControls.DataDateLabel()
        Me.pnlSpace9 = New CustomControls.Panel()
        Me.dtdSalidaDesde4 = New CustomControls.DataDateLabel()
        Me.pnlSalidaDesde3 = New CustomControls.Panel()
        Me.dtdSalidaHasta3 = New CustomControls.DataDateLabel()
        Me.pnlSpace8 = New CustomControls.Panel()
        Me.dtdSalidaDesde3 = New CustomControls.DataDateLabel()
        Me.pnlSalidaDesde2 = New CustomControls.Panel()
        Me.dtdSalidaHasta2 = New CustomControls.DataDateLabel()
        Me.pnlSpace7 = New CustomControls.Panel()
        Me.dtdSalidaDesde2 = New CustomControls.DataDateLabel()
        Me.pnlSalidaDesde = New CustomControls.Panel()
        Me.dtdSalidaHasta = New CustomControls.DataDateLabel()
        Me.pnlSpace6 = New CustomControls.Panel()
        Me.dtdSalidaDesde = New CustomControls.DataDateLabel()
        Me.pnlRegistroDesde = New CustomControls.Panel()
        Me.dtdRegistroHasta = New CustomControls.DataDateLabel()
        Me.pnlSpace5 = New CustomControls.Panel()
        Me.dtdRegistroDesde = New CustomControls.DataDateLabel()
        Me.pnlCabeceraGeneral = New CustomControls.Panel()
        Me.pnlCabecera = New CustomControls.Panel()
        Me.dtfNombre = New CustomControls.DatafieldLabel()
        Me.pnlSpace3 = New CustomControls.Panel()
        Me.dtlUsumodi = New CustomControls.DataLabel()
        Me.pnlSpace2 = New CustomControls.Panel()
        Me.pnlSpace1 = New CustomControls.Panel()
        Me.dtfCodigo = New CustomControls.DatafieldLabel()
        Me.dtlUltmodi = New CustomControls.DataLabel()
        Me.RibbonTab1 = New Telerik.WinControls.UI.RibbonTab()
        Me.pvpTramos = New CustomControls.PageViewPage()
        Me.pnlTramosIzq = New CustomControls.Panel()
        Me.dgvTramos = New Karve.frm.Tarifas.GridTramos()
        Me.pnlCabeceraTramos = New CustomControls.Panel()
        Me.pvpComporta = New CustomControls.PageViewPage()
        Me.pnlCabeceraComporta = New CustomControls.Panel()
        Me.pvpPrecios = New CustomControls.PageViewPage()
        Me.pnlCabeceraPrecios = New CustomControls.Panel()
        Me.pvpDestinos = New CustomControls.PageViewPage()
        Me.pnlCabeceraDestinos = New CustomControls.Panel()
        Me.pvpFijos = New CustomControls.PageViewPage()
        Me.pnlCabeceraFijos = New CustomControls.Panel()
        CType(Me.pnlBlock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pvwBase, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pvwBase.SuspendLayout()
        CType(Me.stbBase, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pvpGeneral.SuspendLayout()
        CType(Me.pnlGeneralDer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlGeneralDer.SuspendLayout()
        CType(Me.gbxChecks, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxChecks.SuspendLayout()
        CType(Me.pnlChecksCol2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlChecksCol2.SuspendLayout()
        CType(Me.DataCheck26, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataCheck24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataCheck22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataCheck20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataCheck19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataCheck16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataCheck15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataCheck14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataCheck13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataCheck12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataCheck11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataCheck10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataCheck8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlChecksCol1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlChecksCol1.SuspendLayout()
        CType(Me.DataCheck25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataCheck23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataCheck21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataCheck18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataCheck17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataCheck7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataCheck6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataCheck5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataCheck4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataCheck3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataCheck9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataCheck2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataCheck1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlGeneralIzq, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlGeneralIzq.SuspendLayout()
        CType(Me.pnlSapce25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.rdgCobrosDefecto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rdgCobrosDefecto.SuspendLayout()
        CType(Me.DataRadio2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataRadio1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataCheck27, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlDtosPrioridad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDtosPrioridad.SuspendLayout()
        CType(Me.pnlSapce23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSapce22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSapce21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPorcenDto2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSapce20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPorcenDto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSpace19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbxFechasValidez, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxFechasValidez.SuspendLayout()
        CType(Me.gbxVapidezPreaviso, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxVapidezPreaviso.SuspendLayout()
        CType(Me.pnlSpace18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSpace17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlFechasSalidaRetorno, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFechasSalidaRetorno.SuspendLayout()
        CType(Me.gbxRetorno, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxRetorno.SuspendLayout()
        CType(Me.pnlRetornoDesde5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlRetornoDesde5.SuspendLayout()
        CType(Me.pnlSpace15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlRetornoDesde4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlRetornoDesde4.SuspendLayout()
        CType(Me.pnlSpace14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlRetornoDesde3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlRetornoDesde3.SuspendLayout()
        CType(Me.pnlSpace13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlRetornoDesde2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlRetornoDesde2.SuspendLayout()
        CType(Me.pnlSpace12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlRetornoDesde, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlRetornoDesde.SuspendLayout()
        CType(Me.pnlSpace11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSpace16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbxSalida, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxSalida.SuspendLayout()
        CType(Me.pnlSalidaDesde5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSalidaDesde5.SuspendLayout()
        CType(Me.pnlSpace10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSalidaDesde4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSalidaDesde4.SuspendLayout()
        CType(Me.pnlSpace9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSalidaDesde3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSalidaDesde3.SuspendLayout()
        CType(Me.pnlSpace8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSalidaDesde2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSalidaDesde2.SuspendLayout()
        CType(Me.pnlSpace7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSalidaDesde, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSalidaDesde.SuspendLayout()
        CType(Me.pnlSpace6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlRegistroDesde, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlRegistroDesde.SuspendLayout()
        CType(Me.pnlSpace5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlCabeceraGeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCabeceraGeneral.SuspendLayout()
        CType(Me.pnlCabecera, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCabecera.SuspendLayout()
        CType(Me.pnlSpace3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtlUsumodi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSpace2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSpace1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtlUltmodi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pvpTramos.SuspendLayout()
        CType(Me.pnlTramosIzq, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTramosIzq.SuspendLayout()
        CType(Me.dgvTramos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvTramos.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlCabeceraTramos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pvpComporta.SuspendLayout()
        CType(Me.pnlCabeceraComporta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pvpPrecios.SuspendLayout()
        CType(Me.pnlCabeceraPrecios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pvpDestinos.SuspendLayout()
        CType(Me.pnlCabeceraDestinos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pvpFijos.SuspendLayout()
        CType(Me.pnlCabeceraFijos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlBlock
        '
        Me.pnlBlock.Location = New System.Drawing.Point(0, 479)
        '
        'pvwBase
        '
        Me.pvwBase.Controls.Add(Me.pvpGeneral)
        Me.pvwBase.Controls.Add(Me.pvpTramos)
        Me.pvwBase.Controls.Add(Me.pvpComporta)
        Me.pvwBase.Controls.Add(Me.pvpPrecios)
        Me.pvwBase.Controls.Add(Me.pvpFijos)
        Me.pvwBase.Controls.Add(Me.pvpDestinos)
        Me.pvwBase.PanelCabezera = Me.pnlCabecera
        Me.pvwBase.SelectedPage = Me.pvpTramos
        Me.pvwBase.Size = New System.Drawing.Size(1358, 510)
        '
        'stbBase
        '
        Me.stbBase.Location = New System.Drawing.Point(0, 510)
        Me.stbBase.Size = New System.Drawing.Size(1358, 25)
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
        Me.pvpGeneral.Controls.Add(Me.pnlGeneralDer)
        Me.pvpGeneral.Controls.Add(Me.pnlGeneralIzq)
        Me.pvpGeneral.Controls.Add(Me.pnlCabeceraGeneral)
        Me.pvpGeneral.ItemSize = New System.Drawing.SizeF(114.0!, 23.0!)
        Me.pvpGeneral.Location = New System.Drawing.Point(129, 5)
        Me.pvpGeneral.Name = "pvpGeneral"
        Me.pvpGeneral.PanelCabezeraContainer = Me.pnlCabeceraGeneral
        Me.pvpGeneral.Size = New System.Drawing.Size(1246, 559)
        Me.pvpGeneral.Text = "General"
        '
        'pnlGeneralDer
        '
        Me.pnlGeneralDer.Auto_Size = False
        Me.pnlGeneralDer.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlGeneralDer.ChangeDock = True
        Me.pnlGeneralDer.Control_Resize = False
        Me.pnlGeneralDer.Controls.Add(Me.dtaCondiciones)
        Me.pnlGeneralDer.Controls.Add(Me.dtaObservaciones)
        Me.pnlGeneralDer.Controls.Add(Me.gbxChecks)
        Me.pnlGeneralDer.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlGeneralDer.isSpace = False
        Me.pnlGeneralDer.Location = New System.Drawing.Point(622, 26)
        Me.pnlGeneralDer.Name = "pnlGeneralDer"
        Me.pnlGeneralDer.numRows = 0
        Me.pnlGeneralDer.Padding = New System.Windows.Forms.Padding(3)
        Me.pnlGeneralDer.Reorder = True
        Me.pnlGeneralDer.Size = New System.Drawing.Size(622, 533)
        Me.pnlGeneralDer.TabIndex = 2
        '
        'dtaCondiciones
        '
        Me.dtaCondiciones.Allow_Empty = True
        Me.dtaCondiciones.Allow_Negative = True
        Me.dtaCondiciones.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtaCondiciones.BackColor = System.Drawing.SystemColors.Control
        Me.dtaCondiciones.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtaCondiciones.DataField = Nothing
        Me.dtaCondiciones.DataTable = ""
        Me.dtaCondiciones.Descripcion = "Condiciones"
        Me.dtaCondiciones.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtaCondiciones.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtaCondiciones.FocoEnAgregar = False
        Me.dtaCondiciones.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtaCondiciones.Length_Data = 32767
        Me.dtaCondiciones.Location = New System.Drawing.Point(3, 428)
        Me.dtaCondiciones.Max_Value = 0.0R
        Me.dtaCondiciones.MensajeIncorrectoCustom = Nothing
        Me.dtaCondiciones.Name = "dtaCondiciones"
        Me.dtaCondiciones.Null_on_Empty = True
        Me.dtaCondiciones.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtaCondiciones.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtaCondiciones.ReadOnly_Data = False
        Me.dtaCondiciones.Size = New System.Drawing.Size(616, 103)
        Me.dtaCondiciones.TabIndex = 2
        Me.dtaCondiciones.Text_Data = ""
        Me.dtaCondiciones.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtaCondiciones.TopPadding = 0
        Me.dtaCondiciones.Upper_Case = False
        Me.dtaCondiciones.Validate_on_lost_focus = True
        '
        'dtaObservaciones
        '
        Me.dtaObservaciones.Allow_Empty = True
        Me.dtaObservaciones.Allow_Negative = True
        Me.dtaObservaciones.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtaObservaciones.BackColor = System.Drawing.SystemColors.Control
        Me.dtaObservaciones.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtaObservaciones.DataField = Nothing
        Me.dtaObservaciones.DataTable = ""
        Me.dtaObservaciones.Descripcion = "Observaciones"
        Me.dtaObservaciones.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtaObservaciones.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtaObservaciones.FocoEnAgregar = False
        Me.dtaObservaciones.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtaObservaciones.Length_Data = 32767
        Me.dtaObservaciones.Location = New System.Drawing.Point(3, 325)
        Me.dtaObservaciones.Max_Value = 0.0R
        Me.dtaObservaciones.MensajeIncorrectoCustom = Nothing
        Me.dtaObservaciones.Name = "dtaObservaciones"
        Me.dtaObservaciones.Null_on_Empty = True
        Me.dtaObservaciones.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtaObservaciones.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtaObservaciones.ReadOnly_Data = False
        Me.dtaObservaciones.Size = New System.Drawing.Size(616, 103)
        Me.dtaObservaciones.TabIndex = 1
        Me.dtaObservaciones.Text_Data = ""
        Me.dtaObservaciones.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtaObservaciones.TopPadding = 0
        Me.dtaObservaciones.Upper_Case = False
        Me.dtaObservaciones.Validate_on_lost_focus = True
        '
        'gbxChecks
        '
        Me.gbxChecks.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.gbxChecks.Controls.Add(Me.pnlChecksCol2)
        Me.gbxChecks.Controls.Add(Me.pnlChecksCol1)
        Me.gbxChecks.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbxChecks.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.gbxChecks.HeaderText = ""
        Me.gbxChecks.Location = New System.Drawing.Point(3, 3)
        Me.gbxChecks.Name = "gbxChecks"
        Me.gbxChecks.numRows = 7
        Me.gbxChecks.Padding = New System.Windows.Forms.Padding(6)
        Me.gbxChecks.Reorder = True
        Me.gbxChecks.Size = New System.Drawing.Size(616, 322)
        Me.gbxChecks.TabIndex = 0
        Me.gbxChecks.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.gbxChecks.ThemeName = "Windows8"
        Me.gbxChecks.Title = ""
        '
        'pnlChecksCol2
        '
        Me.pnlChecksCol2.Auto_Size = False
        Me.pnlChecksCol2.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlChecksCol2.ChangeDock = True
        Me.pnlChecksCol2.Control_Resize = False
        Me.pnlChecksCol2.Controls.Add(Me.DataCheck26)
        Me.pnlChecksCol2.Controls.Add(Me.DataCheck24)
        Me.pnlChecksCol2.Controls.Add(Me.DataCheck22)
        Me.pnlChecksCol2.Controls.Add(Me.DataCheck20)
        Me.pnlChecksCol2.Controls.Add(Me.DataCheck19)
        Me.pnlChecksCol2.Controls.Add(Me.DataCheck16)
        Me.pnlChecksCol2.Controls.Add(Me.DataCheck15)
        Me.pnlChecksCol2.Controls.Add(Me.DataCheck14)
        Me.pnlChecksCol2.Controls.Add(Me.DataCheck13)
        Me.pnlChecksCol2.Controls.Add(Me.DataCheck12)
        Me.pnlChecksCol2.Controls.Add(Me.DataCheck11)
        Me.pnlChecksCol2.Controls.Add(Me.DataCheck10)
        Me.pnlChecksCol2.Controls.Add(Me.DataCheck8)
        Me.pnlChecksCol2.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlChecksCol2.isSpace = False
        Me.pnlChecksCol2.Location = New System.Drawing.Point(307, 6)
        Me.pnlChecksCol2.Name = "pnlChecksCol2"
        Me.pnlChecksCol2.numRows = 0
        Me.pnlChecksCol2.Reorder = True
        Me.pnlChecksCol2.Size = New System.Drawing.Size(208, 310)
        Me.pnlChecksCol2.TabIndex = 1
        '
        'DataCheck26
        '
        Me.DataCheck26.DataField = Nothing
        Me.DataCheck26.DataTable = ""
        Me.DataCheck26.Descripcion = "Importe en UFS"
        Me.DataCheck26.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.DataCheck26.Location = New System.Drawing.Point(0, 291)
        Me.DataCheck26.Name = "DataCheck26"
        Me.DataCheck26.Size = New System.Drawing.Size(113, 18)
        Me.DataCheck26.TabIndex = 12
        Me.DataCheck26.Text = "Importe en UFS"
        Me.DataCheck26.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.DataCheck26.ThemeName = "Windows8"
        Me.DataCheck26.Value = False
        '
        'DataCheck24
        '
        Me.DataCheck24.DataField = Nothing
        Me.DataCheck24.DataTable = ""
        Me.DataCheck24.Descripcion = "NO Downtown"
        Me.DataCheck24.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.DataCheck24.Location = New System.Drawing.Point(0, 267)
        Me.DataCheck24.Name = "DataCheck24"
        Me.DataCheck24.Size = New System.Drawing.Size(104, 18)
        Me.DataCheck24.TabIndex = 11
        Me.DataCheck24.Text = "NO Downtown"
        Me.DataCheck24.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.DataCheck24.ThemeName = "Windows8"
        Me.DataCheck24.Value = False
        '
        'DataCheck22
        '
        Me.DataCheck22.DataField = Nothing
        Me.DataCheck22.DataTable = ""
        Me.DataCheck22.Descripcion = "No ver Grupos sin precios"
        Me.DataCheck22.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.DataCheck22.Location = New System.Drawing.Point(0, 243)
        Me.DataCheck22.Name = "DataCheck22"
        Me.DataCheck22.Size = New System.Drawing.Size(170, 18)
        Me.DataCheck22.TabIndex = 10
        Me.DataCheck22.Text = "No ver Grupos sin precios"
        Me.DataCheck22.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.DataCheck22.ThemeName = "Windows8"
        Me.DataCheck22.Value = False
        '
        'DataCheck20
        '
        Me.DataCheck20.DataField = Nothing
        Me.DataCheck20.DataTable = ""
        Me.DataCheck20.Descripcion = "Obligatorio Comisionista"
        Me.DataCheck20.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.DataCheck20.Location = New System.Drawing.Point(0, 219)
        Me.DataCheck20.Name = "DataCheck20"
        Me.DataCheck20.Size = New System.Drawing.Size(162, 18)
        Me.DataCheck20.TabIndex = 9
        Me.DataCheck20.Text = "Obligatorio Comisionista"
        Me.DataCheck20.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.DataCheck20.ThemeName = "Windows8"
        Me.DataCheck20.Value = False
        '
        'DataCheck19
        '
        Me.DataCheck19.DataField = Nothing
        Me.DataCheck19.DataTable = ""
        Me.DataCheck19.Descripcion = "Sólo Operadores"
        Me.DataCheck19.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.DataCheck19.Location = New System.Drawing.Point(0, 195)
        Me.DataCheck19.Name = "DataCheck19"
        Me.DataCheck19.Size = New System.Drawing.Size(118, 18)
        Me.DataCheck19.TabIndex = 8
        Me.DataCheck19.Text = "Sólo Operadores"
        Me.DataCheck19.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.DataCheck19.ThemeName = "Windows8"
        Me.DataCheck19.Value = False
        '
        'DataCheck16
        '
        Me.DataCheck16.DataField = Nothing
        Me.DataCheck16.DataTable = ""
        Me.DataCheck16.Descripcion = "Sólo para Reservas"
        Me.DataCheck16.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.DataCheck16.Location = New System.Drawing.Point(0, 171)
        Me.DataCheck16.Name = "DataCheck16"
        Me.DataCheck16.Size = New System.Drawing.Size(133, 18)
        Me.DataCheck16.TabIndex = 7
        Me.DataCheck16.Text = "Sólo para Reservas"
        Me.DataCheck16.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.DataCheck16.ThemeName = "Windows8"
        Me.DataCheck16.Value = False
        '
        'DataCheck15
        '
        Me.DataCheck15.DataField = Nothing
        Me.DataCheck15.DataTable = ""
        Me.DataCheck15.Descripcion = "Tarifa Corporativa"
        Me.DataCheck15.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.DataCheck15.Location = New System.Drawing.Point(0, 147)
        Me.DataCheck15.Name = "DataCheck15"
        Me.DataCheck15.Size = New System.Drawing.Size(126, 18)
        Me.DataCheck15.TabIndex = 6
        Me.DataCheck15.Text = "Tarifa Corporativa"
        Me.DataCheck15.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.DataCheck15.ThemeName = "Windows8"
        Me.DataCheck15.Value = False
        '
        'DataCheck14
        '
        Me.DataCheck14.DataField = Nothing
        Me.DataCheck14.DataTable = ""
        Me.DataCheck14.Descripcion = "Bono Prepago"
        Me.DataCheck14.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.DataCheck14.Location = New System.Drawing.Point(0, 123)
        Me.DataCheck14.Name = "DataCheck14"
        Me.DataCheck14.Size = New System.Drawing.Size(102, 18)
        Me.DataCheck14.TabIndex = 5
        Me.DataCheck14.Text = "Bono Prepago"
        Me.DataCheck14.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.DataCheck14.ThemeName = "Windows8"
        Me.DataCheck14.Value = False
        '
        'DataCheck13
        '
        Me.DataCheck13.DataField = Nothing
        Me.DataCheck13.DataTable = ""
        Me.DataCheck13.Descripcion = "No Relpicar Servicio"
        Me.DataCheck13.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.DataCheck13.Location = New System.Drawing.Point(0, 99)
        Me.DataCheck13.Name = "DataCheck13"
        Me.DataCheck13.Size = New System.Drawing.Size(137, 18)
        Me.DataCheck13.TabIndex = 4
        Me.DataCheck13.Text = "No Relpicar Servicio"
        Me.DataCheck13.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.DataCheck13.ThemeName = "Windows8"
        Me.DataCheck13.Value = False
        '
        'DataCheck12
        '
        Me.DataCheck12.DataField = Nothing
        Me.DataCheck12.DataTable = ""
        Me.DataCheck12.Descripcion = "No mostrar en Web"
        Me.DataCheck12.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.DataCheck12.Location = New System.Drawing.Point(0, 75)
        Me.DataCheck12.Name = "DataCheck12"
        Me.DataCheck12.Size = New System.Drawing.Size(134, 18)
        Me.DataCheck12.TabIndex = 3
        Me.DataCheck12.Text = "No mostrar en Web"
        Me.DataCheck12.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.DataCheck12.ThemeName = "Windows8"
        Me.DataCheck12.Value = False
        '
        'DataCheck11
        '
        Me.DataCheck11.DataField = Nothing
        Me.DataCheck11.DataTable = ""
        Me.DataCheck11.Descripcion = "Tarifa por Medio Día"
        Me.DataCheck11.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.DataCheck11.Location = New System.Drawing.Point(0, 51)
        Me.DataCheck11.Name = "DataCheck11"
        Me.DataCheck11.Size = New System.Drawing.Size(138, 18)
        Me.DataCheck11.TabIndex = 2
        Me.DataCheck11.Text = "Tarifa por Medio Día"
        Me.DataCheck11.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.DataCheck11.ThemeName = "Windows8"
        Me.DataCheck11.Value = False
        '
        'DataCheck10
        '
        Me.DataCheck10.DataField = Nothing
        Me.DataCheck10.DataTable = ""
        Me.DataCheck10.Descripcion = "Tarifa Anual"
        Me.DataCheck10.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.DataCheck10.Location = New System.Drawing.Point(0, 27)
        Me.DataCheck10.Name = "DataCheck10"
        Me.DataCheck10.Size = New System.Drawing.Size(92, 18)
        Me.DataCheck10.TabIndex = 1
        Me.DataCheck10.Text = "Tarifa Anual"
        Me.DataCheck10.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.DataCheck10.ThemeName = "Windows8"
        Me.DataCheck10.Value = False
        '
        'DataCheck8
        '
        Me.DataCheck8.DataField = Nothing
        Me.DataCheck8.DataTable = ""
        Me.DataCheck8.Descripcion = "Ocultar Precios en Contrato"
        Me.DataCheck8.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.DataCheck8.Location = New System.Drawing.Point(0, 3)
        Me.DataCheck8.Name = "DataCheck8"
        Me.DataCheck8.Size = New System.Drawing.Size(180, 18)
        Me.DataCheck8.TabIndex = 0
        Me.DataCheck8.Text = "Ocultar Precios en Contrato"
        Me.DataCheck8.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.DataCheck8.ThemeName = "Windows8"
        Me.DataCheck8.Value = False
        '
        'pnlChecksCol1
        '
        Me.pnlChecksCol1.Auto_Size = False
        Me.pnlChecksCol1.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlChecksCol1.ChangeDock = True
        Me.pnlChecksCol1.Control_Resize = False
        Me.pnlChecksCol1.Controls.Add(Me.DataCheck25)
        Me.pnlChecksCol1.Controls.Add(Me.DataCheck23)
        Me.pnlChecksCol1.Controls.Add(Me.DataCheck21)
        Me.pnlChecksCol1.Controls.Add(Me.DataCheck18)
        Me.pnlChecksCol1.Controls.Add(Me.DataCheck17)
        Me.pnlChecksCol1.Controls.Add(Me.DataCheck7)
        Me.pnlChecksCol1.Controls.Add(Me.DataCheck6)
        Me.pnlChecksCol1.Controls.Add(Me.DataCheck5)
        Me.pnlChecksCol1.Controls.Add(Me.DataCheck4)
        Me.pnlChecksCol1.Controls.Add(Me.DataCheck3)
        Me.pnlChecksCol1.Controls.Add(Me.DataCheck9)
        Me.pnlChecksCol1.Controls.Add(Me.DataCheck2)
        Me.pnlChecksCol1.Controls.Add(Me.DataCheck1)
        Me.pnlChecksCol1.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlChecksCol1.isSpace = False
        Me.pnlChecksCol1.Location = New System.Drawing.Point(6, 6)
        Me.pnlChecksCol1.Name = "pnlChecksCol1"
        Me.pnlChecksCol1.numRows = 0
        Me.pnlChecksCol1.Reorder = True
        Me.pnlChecksCol1.Size = New System.Drawing.Size(301, 310)
        Me.pnlChecksCol1.TabIndex = 0
        '
        'DataCheck25
        '
        Me.DataCheck25.DataField = Nothing
        Me.DataCheck25.DataTable = ""
        Me.DataCheck25.Descripcion = "IVA incluido"
        Me.DataCheck25.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.DataCheck25.Location = New System.Drawing.Point(3, 291)
        Me.DataCheck25.Name = "DataCheck25"
        Me.DataCheck25.Size = New System.Drawing.Size(91, 18)
        Me.DataCheck25.TabIndex = 12
        Me.DataCheck25.Text = "IVA incluido"
        Me.DataCheck25.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.DataCheck25.ThemeName = "Windows8"
        Me.DataCheck25.Value = False
        '
        'DataCheck23
        '
        Me.DataCheck23.DataField = Nothing
        Me.DataCheck23.DataTable = ""
        Me.DataCheck23.Descripcion = "NO Aeropuertos"
        Me.DataCheck23.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.DataCheck23.Location = New System.Drawing.Point(3, 267)
        Me.DataCheck23.Name = "DataCheck23"
        Me.DataCheck23.Size = New System.Drawing.Size(114, 18)
        Me.DataCheck23.TabIndex = 11
        Me.DataCheck23.Text = "NO Aeropuertos"
        Me.DataCheck23.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.DataCheck23.ThemeName = "Windows8"
        Me.DataCheck23.Value = False
        '
        'DataCheck21
        '
        Me.DataCheck21.DataField = Nothing
        Me.DataCheck21.DataTable = ""
        Me.DataCheck21.Descripcion = "Cotización No Editable en Contrato"
        Me.DataCheck21.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.DataCheck21.Location = New System.Drawing.Point(3, 243)
        Me.DataCheck21.Name = "DataCheck21"
        Me.DataCheck21.Size = New System.Drawing.Size(221, 18)
        Me.DataCheck21.TabIndex = 10
        Me.DataCheck21.Text = "Cotización No Editable en Contrato"
        Me.DataCheck21.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.DataCheck21.ThemeName = "Windows8"
        Me.DataCheck21.Value = False
        '
        'DataCheck18
        '
        Me.DataCheck18.DataField = Nothing
        Me.DataCheck18.DataTable = ""
        Me.DataCheck18.Descripcion = "Pública"
        Me.DataCheck18.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.DataCheck18.Location = New System.Drawing.Point(3, 219)
        Me.DataCheck18.Name = "DataCheck18"
        Me.DataCheck18.Size = New System.Drawing.Size(63, 18)
        Me.DataCheck18.TabIndex = 9
        Me.DataCheck18.Text = "Pública"
        Me.DataCheck18.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.DataCheck18.ThemeName = "Windows8"
        Me.DataCheck18.Value = False
        '
        'DataCheck17
        '
        Me.DataCheck17.DataField = Nothing
        Me.DataCheck17.DataTable = ""
        Me.DataCheck17.Descripcion = "Activa"
        Me.DataCheck17.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.DataCheck17.Location = New System.Drawing.Point(3, 195)
        Me.DataCheck17.Name = "DataCheck17"
        Me.DataCheck17.Size = New System.Drawing.Size(58, 18)
        Me.DataCheck17.TabIndex = 8
        Me.DataCheck17.Text = "Activa"
        Me.DataCheck17.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.DataCheck17.ThemeName = "Windows8"
        Me.DataCheck17.Value = False
        '
        'DataCheck7
        '
        Me.DataCheck7.DataField = Nothing
        Me.DataCheck7.DataTable = ""
        Me.DataCheck7.Descripcion = "Tarifa por Horas Tramos Variables"
        Me.DataCheck7.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.DataCheck7.Location = New System.Drawing.Point(3, 147)
        Me.DataCheck7.Name = "DataCheck7"
        Me.DataCheck7.Size = New System.Drawing.Size(218, 18)
        Me.DataCheck7.TabIndex = 6
        Me.DataCheck7.Text = "Tarifa por Horas Tramos Variables"
        Me.DataCheck7.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.DataCheck7.ThemeName = "Windows8"
        Me.DataCheck7.Value = False
        '
        'DataCheck6
        '
        Me.DataCheck6.DataField = Nothing
        Me.DataCheck6.DataTable = ""
        Me.DataCheck6.Descripcion = "Tarifa por Horas Precio Acumulado"
        Me.DataCheck6.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.DataCheck6.Location = New System.Drawing.Point(3, 123)
        Me.DataCheck6.Name = "DataCheck6"
        Me.DataCheck6.Size = New System.Drawing.Size(220, 18)
        Me.DataCheck6.TabIndex = 5
        Me.DataCheck6.Text = "Tarifa por Horas Precio Acumulado"
        Me.DataCheck6.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.DataCheck6.ThemeName = "Windows8"
        Me.DataCheck6.Value = False
        '
        'DataCheck5
        '
        Me.DataCheck5.DataField = Nothing
        Me.DataCheck5.DataTable = ""
        Me.DataCheck5.Descripcion = "Tarifa por Horas"
        Me.DataCheck5.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.DataCheck5.Location = New System.Drawing.Point(3, 99)
        Me.DataCheck5.Name = "DataCheck5"
        Me.DataCheck5.Size = New System.Drawing.Size(115, 18)
        Me.DataCheck5.TabIndex = 4
        Me.DataCheck5.Text = "Tarifa por Horas"
        Me.DataCheck5.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.DataCheck5.ThemeName = "Windows8"
        Me.DataCheck5.Value = False
        '
        'DataCheck4
        '
        Me.DataCheck4.DataField = Nothing
        Me.DataCheck4.DataTable = ""
        Me.DataCheck4.Descripcion = "Tramo Fin de Semana"
        Me.DataCheck4.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.DataCheck4.Location = New System.Drawing.Point(3, 75)
        Me.DataCheck4.Name = "DataCheck4"
        Me.DataCheck4.Size = New System.Drawing.Size(149, 18)
        Me.DataCheck4.TabIndex = 3
        Me.DataCheck4.Text = "Tramo Fin de Semana"
        Me.DataCheck4.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.DataCheck4.ThemeName = "Windows8"
        Me.DataCheck4.Value = False
        '
        'DataCheck3
        '
        Me.DataCheck3.DataField = Nothing
        Me.DataCheck3.DataTable = ""
        Me.DataCheck3.Descripcion = "Tarifa Fin de Semana"
        Me.DataCheck3.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.DataCheck3.Location = New System.Drawing.Point(3, 51)
        Me.DataCheck3.Name = "DataCheck3"
        Me.DataCheck3.Size = New System.Drawing.Size(145, 18)
        Me.DataCheck3.TabIndex = 2
        Me.DataCheck3.Text = "Tarifa Fin de Semana"
        Me.DataCheck3.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.DataCheck3.ThemeName = "Windows8"
        Me.DataCheck3.Value = False
        '
        'DataCheck9
        '
        Me.DataCheck9.DataField = Nothing
        Me.DataCheck9.DataTable = ""
        Me.DataCheck9.Descripcion = "Tarifa Servicio sin Horas"
        Me.DataCheck9.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.DataCheck9.Location = New System.Drawing.Point(3, 171)
        Me.DataCheck9.Name = "DataCheck9"
        Me.DataCheck9.Size = New System.Drawing.Size(162, 18)
        Me.DataCheck9.TabIndex = 7
        Me.DataCheck9.Text = "Tarifa Servicio sin Horas"
        Me.DataCheck9.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.DataCheck9.ThemeName = "Windows8"
        Me.DataCheck9.Value = False
        '
        'DataCheck2
        '
        Me.DataCheck2.DataField = Nothing
        Me.DataCheck2.DataTable = ""
        Me.DataCheck2.Descripcion = "Tarifa ONE WAY"
        Me.DataCheck2.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.DataCheck2.Location = New System.Drawing.Point(3, 27)
        Me.DataCheck2.Name = "DataCheck2"
        Me.DataCheck2.Size = New System.Drawing.Size(114, 18)
        Me.DataCheck2.TabIndex = 1
        Me.DataCheck2.Text = "Tarifa ONE WAY"
        Me.DataCheck2.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.DataCheck2.ThemeName = "Windows8"
        Me.DataCheck2.Value = False
        '
        'DataCheck1
        '
        Me.DataCheck1.DataField = Nothing
        Me.DataCheck1.DataTable = ""
        Me.DataCheck1.Descripcion = "Km Ilimitados"
        Me.DataCheck1.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.DataCheck1.Location = New System.Drawing.Point(3, 3)
        Me.DataCheck1.Name = "DataCheck1"
        Me.DataCheck1.Size = New System.Drawing.Size(102, 18)
        Me.DataCheck1.TabIndex = 0
        Me.DataCheck1.Text = "Km Ilimitados"
        Me.DataCheck1.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.DataCheck1.ThemeName = "Windows8"
        Me.DataCheck1.Value = False
        '
        'pnlGeneralIzq
        '
        Me.pnlGeneralIzq.Auto_Size = False
        Me.pnlGeneralIzq.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlGeneralIzq.ChangeDock = True
        Me.pnlGeneralIzq.Control_Resize = False
        Me.pnlGeneralIzq.Controls.Add(Me.DualDatafieldLabel4)
        Me.pnlGeneralIzq.Controls.Add(Me.DualDatafieldLabel3)
        Me.pnlGeneralIzq.Controls.Add(Me.DualDatafieldLabel2)
        Me.pnlGeneralIzq.Controls.Add(Me.pnlSapce25)
        Me.pnlGeneralIzq.Controls.Add(Me.GroupBox1)
        Me.pnlGeneralIzq.Controls.Add(Me.pnlSpace19)
        Me.pnlGeneralIzq.Controls.Add(Me.gbxFechasValidez)
        Me.pnlGeneralIzq.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlGeneralIzq.isSpace = False
        Me.pnlGeneralIzq.Location = New System.Drawing.Point(0, 26)
        Me.pnlGeneralIzq.Name = "pnlGeneralIzq"
        Me.pnlGeneralIzq.numRows = 0
        Me.pnlGeneralIzq.Padding = New System.Windows.Forms.Padding(3)
        Me.pnlGeneralIzq.Reorder = True
        Me.pnlGeneralIzq.Size = New System.Drawing.Size(622, 533)
        Me.pnlGeneralIzq.TabIndex = 1
        '
        'DualDatafieldLabel4
        '
        Me.DualDatafieldLabel4.Allow_Empty = True
        Me.DualDatafieldLabel4.Allow_Negative = True
        Me.DualDatafieldLabel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.DualDatafieldLabel4.BackColor = System.Drawing.SystemColors.Control
        Me.DualDatafieldLabel4.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.DualDatafieldLabel4.DataField = Nothing
        Me.DualDatafieldLabel4.DataTable = ""
        Me.DualDatafieldLabel4.DB = Connection1
        Me.DualDatafieldLabel4.Desc_Datafield = Nothing
        Me.DualDatafieldLabel4.Desc_DBPK = Nothing
        Me.DualDatafieldLabel4.Desc_DBTable = Nothing
        Me.DualDatafieldLabel4.Desc_Where = Nothing
        Me.DualDatafieldLabel4.Desc_WhereObligatoria = Nothing
        Me.DualDatafieldLabel4.Descripcion = "Clase"
        Me.DualDatafieldLabel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.DualDatafieldLabel4.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.DualDatafieldLabel4.ExtraSQL = ""
        Me.DualDatafieldLabel4.FocoEnAgregar = False
        Me.DualDatafieldLabel4.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.DualDatafieldLabel4.Formulario = Nothing
        Me.DualDatafieldLabel4.Label_Space = 100
        Me.DualDatafieldLabel4.Length_Data = 32767
        Me.DualDatafieldLabel4.Location = New System.Drawing.Point(3, 434)
        Me.DualDatafieldLabel4.Lupa = Nothing
        Me.DualDatafieldLabel4.Max_Value = 0.0R
        Me.DualDatafieldLabel4.MensajeIncorrectoCustom = Nothing
        Me.DualDatafieldLabel4.Name = "DualDatafieldLabel4"
        Me.DualDatafieldLabel4.Null_on_Empty = True
        Me.DualDatafieldLabel4.OpenForm = Nothing
        Me.DualDatafieldLabel4.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.DualDatafieldLabel4.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.DualDatafieldLabel4.Query_on_Text_Changed = True
        Me.DualDatafieldLabel4.ReadOnly_Data = False
        Me.DualDatafieldLabel4.ReQuery = False
        Me.DualDatafieldLabel4.ShowButton = True
        Me.DualDatafieldLabel4.Size = New System.Drawing.Size(616, 26)
        Me.DualDatafieldLabel4.TabIndex = 6
        Me.DualDatafieldLabel4.Text_Data = ""
        Me.DualDatafieldLabel4.Text_Data_Desc = ""
        Me.DualDatafieldLabel4.Text_Width = 58
        Me.DualDatafieldLabel4.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.DualDatafieldLabel4.TopPadding = 0
        Me.DualDatafieldLabel4.Upper_Case = False
        Me.DualDatafieldLabel4.Validate_on_lost_focus = True
        '
        'DualDatafieldLabel3
        '
        Me.DualDatafieldLabel3.Allow_Empty = True
        Me.DualDatafieldLabel3.Allow_Negative = True
        Me.DualDatafieldLabel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.DualDatafieldLabel3.BackColor = System.Drawing.SystemColors.Control
        Me.DualDatafieldLabel3.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.DualDatafieldLabel3.DataField = Nothing
        Me.DualDatafieldLabel3.DataTable = ""
        Me.DualDatafieldLabel3.DB = Connection2
        Me.DualDatafieldLabel3.Desc_Datafield = Nothing
        Me.DualDatafieldLabel3.Desc_DBPK = Nothing
        Me.DualDatafieldLabel3.Desc_DBTable = Nothing
        Me.DualDatafieldLabel3.Desc_Where = Nothing
        Me.DualDatafieldLabel3.Desc_WhereObligatoria = Nothing
        Me.DualDatafieldLabel3.Descripcion = "Empresa"
        Me.DualDatafieldLabel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.DualDatafieldLabel3.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.DualDatafieldLabel3.ExtraSQL = ""
        Me.DualDatafieldLabel3.FocoEnAgregar = False
        Me.DualDatafieldLabel3.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.DualDatafieldLabel3.Formulario = Nothing
        Me.DualDatafieldLabel3.Label_Space = 100
        Me.DualDatafieldLabel3.Length_Data = 32767
        Me.DualDatafieldLabel3.Location = New System.Drawing.Point(3, 408)
        Me.DualDatafieldLabel3.Lupa = Nothing
        Me.DualDatafieldLabel3.Max_Value = 0.0R
        Me.DualDatafieldLabel3.MensajeIncorrectoCustom = Nothing
        Me.DualDatafieldLabel3.Name = "DualDatafieldLabel3"
        Me.DualDatafieldLabel3.Null_on_Empty = True
        Me.DualDatafieldLabel3.OpenForm = Nothing
        Me.DualDatafieldLabel3.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.DualDatafieldLabel3.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.DualDatafieldLabel3.Query_on_Text_Changed = True
        Me.DualDatafieldLabel3.ReadOnly_Data = False
        Me.DualDatafieldLabel3.ReQuery = False
        Me.DualDatafieldLabel3.ShowButton = True
        Me.DualDatafieldLabel3.Size = New System.Drawing.Size(616, 26)
        Me.DualDatafieldLabel3.TabIndex = 5
        Me.DualDatafieldLabel3.Text_Data = ""
        Me.DualDatafieldLabel3.Text_Data_Desc = ""
        Me.DualDatafieldLabel3.Text_Width = 58
        Me.DualDatafieldLabel3.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.DualDatafieldLabel3.TopPadding = 0
        Me.DualDatafieldLabel3.Upper_Case = False
        Me.DualDatafieldLabel3.Validate_on_lost_focus = True
        '
        'DualDatafieldLabel2
        '
        Me.DualDatafieldLabel2.Allow_Empty = True
        Me.DualDatafieldLabel2.Allow_Negative = True
        Me.DualDatafieldLabel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.DualDatafieldLabel2.BackColor = System.Drawing.SystemColors.Control
        Me.DualDatafieldLabel2.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.DualDatafieldLabel2.DataField = Nothing
        Me.DualDatafieldLabel2.DataTable = ""
        Me.DualDatafieldLabel2.DB = Connection3
        Me.DualDatafieldLabel2.Desc_Datafield = Nothing
        Me.DualDatafieldLabel2.Desc_DBPK = Nothing
        Me.DualDatafieldLabel2.Desc_DBTable = Nothing
        Me.DualDatafieldLabel2.Desc_Where = Nothing
        Me.DualDatafieldLabel2.Desc_WhereObligatoria = Nothing
        Me.DualDatafieldLabel2.Descripcion = "Moneda"
        Me.DualDatafieldLabel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.DualDatafieldLabel2.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.DualDatafieldLabel2.ExtraSQL = ""
        Me.DualDatafieldLabel2.FocoEnAgregar = False
        Me.DualDatafieldLabel2.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.DualDatafieldLabel2.Formulario = Nothing
        Me.DualDatafieldLabel2.Label_Space = 100
        Me.DualDatafieldLabel2.Length_Data = 32767
        Me.DualDatafieldLabel2.Location = New System.Drawing.Point(3, 382)
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
        Me.DualDatafieldLabel2.ReQuery = False
        Me.DualDatafieldLabel2.ShowButton = True
        Me.DualDatafieldLabel2.Size = New System.Drawing.Size(616, 26)
        Me.DualDatafieldLabel2.TabIndex = 4
        Me.DualDatafieldLabel2.Text_Data = ""
        Me.DualDatafieldLabel2.Text_Data_Desc = ""
        Me.DualDatafieldLabel2.Text_Width = 58
        Me.DualDatafieldLabel2.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.DualDatafieldLabel2.TopPadding = 0
        Me.DualDatafieldLabel2.Upper_Case = False
        Me.DualDatafieldLabel2.Validate_on_lost_focus = True
        '
        'pnlSapce25
        '
        Me.pnlSapce25.Auto_Size = False
        Me.pnlSapce25.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSapce25.ChangeDock = True
        Me.pnlSapce25.Control_Resize = False
        Me.pnlSapce25.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlSapce25.isSpace = False
        Me.pnlSapce25.Location = New System.Drawing.Point(3, 370)
        Me.pnlSapce25.Name = "pnlSapce25"
        Me.pnlSapce25.numRows = 1
        Me.pnlSapce25.Reorder = True
        Me.pnlSapce25.Size = New System.Drawing.Size(616, 12)
        Me.pnlSapce25.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.GroupBox1.Controls.Add(Me.rdgCobrosDefecto)
        Me.GroupBox1.Controls.Add(Me.DualDatafieldLabel1)
        Me.GroupBox1.Controls.Add(Me.pnlDtosPrioridad)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.GroupBox1.HeaderText = ""
        Me.GroupBox1.Location = New System.Drawing.Point(3, 259)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.numRows = 0
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(6, 10, 6, 6)
        Me.GroupBox1.Reorder = True
        Me.GroupBox1.Size = New System.Drawing.Size(616, 111)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.GroupBox1.ThemeName = "Windows8"
        Me.GroupBox1.Title = ""
        '
        'rdgCobrosDefecto
        '
        Me.rdgCobrosDefecto.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.rdgCobrosDefecto.Controls.Add(Me.DataRadio2)
        Me.rdgCobrosDefecto.Controls.Add(Me.DataRadio1)
        Me.rdgCobrosDefecto.Controls.Add(Me.DataCheck27)
        Me.rdgCobrosDefecto.DataField = Nothing
        Me.rdgCobrosDefecto.DataTable = ""
        Me.rdgCobrosDefecto.DefaultIndex = Nothing
        Me.rdgCobrosDefecto.Descripcion = "Cobros por defecto a"
        Me.rdgCobrosDefecto.Dock = System.Windows.Forms.DockStyle.Top
        Me.rdgCobrosDefecto.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.rdgCobrosDefecto.HeaderText = "Cobros por defecto a"
        Me.rdgCobrosDefecto.Index = Nothing
        Me.rdgCobrosDefecto.Location = New System.Drawing.Point(6, 62)
        Me.rdgCobrosDefecto.Name = "rdgCobrosDefecto"
        Me.rdgCobrosDefecto.numRows = 1
        Me.rdgCobrosDefecto.Padding = New System.Windows.Forms.Padding(6, 18, 6, 6)
        Me.rdgCobrosDefecto.Reorder = True
        Me.rdgCobrosDefecto.Size = New System.Drawing.Size(604, 46)
        Me.rdgCobrosDefecto.TabIndex = 2
        Me.rdgCobrosDefecto.Text = "Cobros por defecto a"
        Me.rdgCobrosDefecto.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.rdgCobrosDefecto.ThemeName = "Windows8"
        Me.rdgCobrosDefecto.Title = "Cobros por defecto a"
        '
        'DataRadio2
        '
        Me.DataRadio2.BackColor = System.Drawing.SystemColors.Control
        Me.DataRadio2.Checked = True
        Me.DataRadio2.CheckState = System.Windows.Forms.CheckState.Checked
        Me.DataRadio2.Descripcion = "Conductor"
        Me.DataRadio2.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.DataRadio2.Index = Nothing
        Me.DataRadio2.Location = New System.Drawing.Point(220, 21)
        Me.DataRadio2.Name = "DataRadio2"
        Me.DataRadio2.Size = New System.Drawing.Size(81, 18)
        Me.DataRadio2.TabIndex = 2
        Me.DataRadio2.TabStop = True
        Me.DataRadio2.Text = "Conductor"
        Me.DataRadio2.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.DataRadio2.ThemeName = "Windows8"
        Me.DataRadio2.ToggleState = Telerik.WinControls.Enumerations.ToggleState.[On]
        '
        'DataRadio1
        '
        Me.DataRadio1.BackColor = System.Drawing.SystemColors.Control
        Me.DataRadio1.Checked = False
        Me.DataRadio1.Descripcion = "Cliente"
        Me.DataRadio1.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.DataRadio1.Index = Nothing
        Me.DataRadio1.Location = New System.Drawing.Point(128, 21)
        Me.DataRadio1.Name = "DataRadio1"
        Me.DataRadio1.Size = New System.Drawing.Size(62, 18)
        Me.DataRadio1.TabIndex = 1
        Me.DataRadio1.Text = "Cliente"
        Me.DataRadio1.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.DataRadio1.ThemeName = "Windows8"
        '
        'DataCheck27
        '
        Me.DataCheck27.DataField = Nothing
        Me.DataCheck27.DataTable = ""
        Me.DataCheck27.Descripcion = "Por Tarifa"
        Me.DataCheck27.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.DataCheck27.Location = New System.Drawing.Point(9, 21)
        Me.DataCheck27.Name = "DataCheck27"
        Me.DataCheck27.Size = New System.Drawing.Size(78, 18)
        Me.DataCheck27.TabIndex = 0
        Me.DataCheck27.Text = "Por Tarifa"
        Me.DataCheck27.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.DataCheck27.ThemeName = "Windows8"
        Me.DataCheck27.Value = False
        '
        'DualDatafieldLabel1
        '
        Me.DualDatafieldLabel1.Allow_Empty = True
        Me.DualDatafieldLabel1.Allow_Negative = True
        Me.DualDatafieldLabel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.DualDatafieldLabel1.BackColor = System.Drawing.SystemColors.Control
        Me.DualDatafieldLabel1.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.DualDatafieldLabel1.DataField = Nothing
        Me.DualDatafieldLabel1.DataTable = ""
        Me.DualDatafieldLabel1.DB = Connection4
        Me.DualDatafieldLabel1.Desc_Datafield = Nothing
        Me.DualDatafieldLabel1.Desc_DBPK = Nothing
        Me.DualDatafieldLabel1.Desc_DBTable = Nothing
        Me.DualDatafieldLabel1.Desc_Where = Nothing
        Me.DualDatafieldLabel1.Desc_WhereObligatoria = Nothing
        Me.DualDatafieldLabel1.Descripcion = "Forma Cobro"
        Me.DualDatafieldLabel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.DualDatafieldLabel1.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.DualDatafieldLabel1.ExtraSQL = ""
        Me.DualDatafieldLabel1.FocoEnAgregar = False
        Me.DualDatafieldLabel1.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.DualDatafieldLabel1.Formulario = Nothing
        Me.DualDatafieldLabel1.Label_Space = 100
        Me.DualDatafieldLabel1.Length_Data = 32767
        Me.DualDatafieldLabel1.Location = New System.Drawing.Point(6, 36)
        Me.DualDatafieldLabel1.Lupa = Nothing
        Me.DualDatafieldLabel1.Max_Value = 0.0R
        Me.DualDatafieldLabel1.MensajeIncorrectoCustom = Nothing
        Me.DualDatafieldLabel1.Name = "DualDatafieldLabel1"
        Me.DualDatafieldLabel1.Null_on_Empty = True
        Me.DualDatafieldLabel1.OpenForm = Nothing
        Me.DualDatafieldLabel1.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.DualDatafieldLabel1.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.DualDatafieldLabel1.Query_on_Text_Changed = True
        Me.DualDatafieldLabel1.ReadOnly_Data = False
        Me.DualDatafieldLabel1.ReQuery = False
        Me.DualDatafieldLabel1.ShowButton = True
        Me.DualDatafieldLabel1.Size = New System.Drawing.Size(604, 26)
        Me.DualDatafieldLabel1.TabIndex = 1
        Me.DualDatafieldLabel1.Text_Data = ""
        Me.DualDatafieldLabel1.Text_Data_Desc = ""
        Me.DualDatafieldLabel1.Text_Width = 58
        Me.DualDatafieldLabel1.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.DualDatafieldLabel1.TopPadding = 0
        Me.DualDatafieldLabel1.Upper_Case = False
        Me.DualDatafieldLabel1.Validate_on_lost_focus = True
        '
        'pnlDtosPrioridad
        '
        Me.pnlDtosPrioridad.Auto_Size = False
        Me.pnlDtosPrioridad.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlDtosPrioridad.ChangeDock = True
        Me.pnlDtosPrioridad.Control_Resize = False
        Me.pnlDtosPrioridad.Controls.Add(Me.DatafieldLabel5)
        Me.pnlDtosPrioridad.Controls.Add(Me.pnlSapce23)
        Me.pnlDtosPrioridad.Controls.Add(Me.DatafieldLabel4)
        Me.pnlDtosPrioridad.Controls.Add(Me.pnlSapce22)
        Me.pnlDtosPrioridad.Controls.Add(Me.DatafieldLabel3)
        Me.pnlDtosPrioridad.Controls.Add(Me.pnlSapce21)
        Me.pnlDtosPrioridad.Controls.Add(Me.lblPorcenDto2)
        Me.pnlDtosPrioridad.Controls.Add(Me.DatafieldLabel2)
        Me.pnlDtosPrioridad.Controls.Add(Me.pnlSapce20)
        Me.pnlDtosPrioridad.Controls.Add(Me.lblPorcenDto)
        Me.pnlDtosPrioridad.Controls.Add(Me.DatafieldLabel1)
        Me.pnlDtosPrioridad.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlDtosPrioridad.isSpace = False
        Me.pnlDtosPrioridad.Location = New System.Drawing.Point(6, 10)
        Me.pnlDtosPrioridad.Name = "pnlDtosPrioridad"
        Me.pnlDtosPrioridad.numRows = 1
        Me.pnlDtosPrioridad.Reorder = True
        Me.pnlDtosPrioridad.Size = New System.Drawing.Size(604, 26)
        Me.pnlDtosPrioridad.TabIndex = 0
        '
        'DatafieldLabel5
        '
        Me.DatafieldLabel5.Allow_Empty = True
        Me.DatafieldLabel5.Allow_Negative = True
        Me.DatafieldLabel5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.DatafieldLabel5.BackColor = System.Drawing.SystemColors.Control
        Me.DatafieldLabel5.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.DatafieldLabel5.DataField = Nothing
        Me.DatafieldLabel5.DataTable = ""
        Me.DatafieldLabel5.Descripcion = "Tiempo Resta"
        Me.DatafieldLabel5.Dock = System.Windows.Forms.DockStyle.Left
        Me.DatafieldLabel5.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.DatafieldLabel5.FocoEnAgregar = False
        Me.DatafieldLabel5.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.DatafieldLabel5.Image = Nothing
        Me.DatafieldLabel5.Label_Space = 85
        Me.DatafieldLabel5.Length_Data = 32767
        Me.DatafieldLabel5.Location = New System.Drawing.Point(445, 0)
        Me.DatafieldLabel5.Max_Value = 0.0R
        Me.DatafieldLabel5.MensajeIncorrectoCustom = Nothing
        Me.DatafieldLabel5.Name = "DatafieldLabel5"
        Me.DatafieldLabel5.Null_on_Empty = True
        Me.DatafieldLabel5.OpenForm = Nothing
        Me.DatafieldLabel5.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.DatafieldLabel5.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.DatafieldLabel5.ReadOnly_Data = False
        Me.DatafieldLabel5.Show_Button = False
        Me.DatafieldLabel5.Size = New System.Drawing.Size(140, 26)
        Me.DatafieldLabel5.TabIndex = 10
        Me.DatafieldLabel5.Text_Data = ""
        Me.DatafieldLabel5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.DatafieldLabel5.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.DatafieldLabel5.TopPadding = 0
        Me.DatafieldLabel5.Upper_Case = False
        Me.DatafieldLabel5.Validate_on_lost_focus = True
        '
        'pnlSapce23
        '
        Me.pnlSapce23.Auto_Size = False
        Me.pnlSapce23.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSapce23.ChangeDock = True
        Me.pnlSapce23.Control_Resize = False
        Me.pnlSapce23.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSapce23.isSpace = True
        Me.pnlSapce23.Location = New System.Drawing.Point(439, 0)
        Me.pnlSapce23.Name = "pnlSapce23"
        Me.pnlSapce23.numRows = 0
        Me.pnlSapce23.Reorder = True
        Me.pnlSapce23.Size = New System.Drawing.Size(6, 26)
        Me.pnlSapce23.TabIndex = 9
        '
        'DatafieldLabel4
        '
        Me.DatafieldLabel4.Allow_Empty = True
        Me.DatafieldLabel4.Allow_Negative = True
        Me.DatafieldLabel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.DatafieldLabel4.BackColor = System.Drawing.SystemColors.Control
        Me.DatafieldLabel4.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.DatafieldLabel4.DataField = Nothing
        Me.DatafieldLabel4.DataTable = ""
        Me.DatafieldLabel4.Descripcion = "Orden Web"
        Me.DatafieldLabel4.Dock = System.Windows.Forms.DockStyle.Left
        Me.DatafieldLabel4.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.DatafieldLabel4.FocoEnAgregar = False
        Me.DatafieldLabel4.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.DatafieldLabel4.Image = Nothing
        Me.DatafieldLabel4.Label_Space = 70
        Me.DatafieldLabel4.Length_Data = 32767
        Me.DatafieldLabel4.Location = New System.Drawing.Point(339, 0)
        Me.DatafieldLabel4.Max_Value = 0.0R
        Me.DatafieldLabel4.MensajeIncorrectoCustom = Nothing
        Me.DatafieldLabel4.Name = "DatafieldLabel4"
        Me.DatafieldLabel4.Null_on_Empty = True
        Me.DatafieldLabel4.OpenForm = Nothing
        Me.DatafieldLabel4.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.DatafieldLabel4.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.DatafieldLabel4.ReadOnly_Data = False
        Me.DatafieldLabel4.Show_Button = False
        Me.DatafieldLabel4.Size = New System.Drawing.Size(100, 26)
        Me.DatafieldLabel4.TabIndex = 8
        Me.DatafieldLabel4.Text_Data = ""
        Me.DatafieldLabel4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.DatafieldLabel4.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.DatafieldLabel4.TopPadding = 0
        Me.DatafieldLabel4.Upper_Case = False
        Me.DatafieldLabel4.Validate_on_lost_focus = True
        '
        'pnlSapce22
        '
        Me.pnlSapce22.Auto_Size = False
        Me.pnlSapce22.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSapce22.ChangeDock = True
        Me.pnlSapce22.Control_Resize = False
        Me.pnlSapce22.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSapce22.isSpace = True
        Me.pnlSapce22.Location = New System.Drawing.Point(333, 0)
        Me.pnlSapce22.Name = "pnlSapce22"
        Me.pnlSapce22.numRows = 0
        Me.pnlSapce22.Reorder = True
        Me.pnlSapce22.Size = New System.Drawing.Size(6, 26)
        Me.pnlSapce22.TabIndex = 7
        '
        'DatafieldLabel3
        '
        Me.DatafieldLabel3.Allow_Empty = True
        Me.DatafieldLabel3.Allow_Negative = True
        Me.DatafieldLabel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.DatafieldLabel3.BackColor = System.Drawing.SystemColors.Control
        Me.DatafieldLabel3.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.DatafieldLabel3.DataField = Nothing
        Me.DatafieldLabel3.DataTable = ""
        Me.DatafieldLabel3.Descripcion = "Prioridad"
        Me.DatafieldLabel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.DatafieldLabel3.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.DatafieldLabel3.FocoEnAgregar = False
        Me.DatafieldLabel3.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.DatafieldLabel3.Image = Nothing
        Me.DatafieldLabel3.Label_Space = 60
        Me.DatafieldLabel3.Length_Data = 32767
        Me.DatafieldLabel3.Location = New System.Drawing.Point(238, 0)
        Me.DatafieldLabel3.Max_Value = 0.0R
        Me.DatafieldLabel3.MensajeIncorrectoCustom = Nothing
        Me.DatafieldLabel3.Name = "DatafieldLabel3"
        Me.DatafieldLabel3.Null_on_Empty = True
        Me.DatafieldLabel3.OpenForm = Nothing
        Me.DatafieldLabel3.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.DatafieldLabel3.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.DatafieldLabel3.ReadOnly_Data = False
        Me.DatafieldLabel3.Show_Button = False
        Me.DatafieldLabel3.Size = New System.Drawing.Size(95, 26)
        Me.DatafieldLabel3.TabIndex = 6
        Me.DatafieldLabel3.Text_Data = ""
        Me.DatafieldLabel3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.DatafieldLabel3.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.DatafieldLabel3.TopPadding = 0
        Me.DatafieldLabel3.Upper_Case = False
        Me.DatafieldLabel3.Validate_on_lost_focus = True
        '
        'pnlSapce21
        '
        Me.pnlSapce21.Auto_Size = False
        Me.pnlSapce21.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSapce21.ChangeDock = True
        Me.pnlSapce21.Control_Resize = False
        Me.pnlSapce21.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSapce21.isSpace = True
        Me.pnlSapce21.Location = New System.Drawing.Point(232, 0)
        Me.pnlSapce21.Name = "pnlSapce21"
        Me.pnlSapce21.numRows = 0
        Me.pnlSapce21.Reorder = True
        Me.pnlSapce21.Size = New System.Drawing.Size(6, 26)
        Me.pnlSapce21.TabIndex = 5
        '
        'lblPorcenDto2
        '
        Me.lblPorcenDto2.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblPorcenDto2.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblPorcenDto2.Location = New System.Drawing.Point(214, 0)
        Me.lblPorcenDto2.Name = "lblPorcenDto2"
        Me.lblPorcenDto2.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.lblPorcenDto2.Size = New System.Drawing.Size(18, 26)
        Me.lblPorcenDto2.TabIndex = 4
        Me.lblPorcenDto2.Text = "%"
        '
        'DatafieldLabel2
        '
        Me.DatafieldLabel2.Allow_Empty = True
        Me.DatafieldLabel2.Allow_Negative = True
        Me.DatafieldLabel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.DatafieldLabel2.BackColor = System.Drawing.SystemColors.Control
        Me.DatafieldLabel2.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.DatafieldLabel2.DataField = Nothing
        Me.DatafieldLabel2.DataTable = ""
        Me.DatafieldLabel2.Descripcion = "Dto. W.S."
        Me.DatafieldLabel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.DatafieldLabel2.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.DatafieldLabel2.FocoEnAgregar = False
        Me.DatafieldLabel2.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.DatafieldLabel2.Image = Nothing
        Me.DatafieldLabel2.Label_Space = 60
        Me.DatafieldLabel2.Length_Data = 32767
        Me.DatafieldLabel2.Location = New System.Drawing.Point(119, 0)
        Me.DatafieldLabel2.Max_Value = 0.0R
        Me.DatafieldLabel2.MensajeIncorrectoCustom = Nothing
        Me.DatafieldLabel2.Name = "DatafieldLabel2"
        Me.DatafieldLabel2.Null_on_Empty = True
        Me.DatafieldLabel2.OpenForm = Nothing
        Me.DatafieldLabel2.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.DatafieldLabel2.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.DatafieldLabel2.ReadOnly_Data = False
        Me.DatafieldLabel2.Show_Button = False
        Me.DatafieldLabel2.Size = New System.Drawing.Size(95, 26)
        Me.DatafieldLabel2.TabIndex = 3
        Me.DatafieldLabel2.Text_Data = ""
        Me.DatafieldLabel2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.DatafieldLabel2.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.DatafieldLabel2.TopPadding = 0
        Me.DatafieldLabel2.Upper_Case = False
        Me.DatafieldLabel2.Validate_on_lost_focus = True
        '
        'pnlSapce20
        '
        Me.pnlSapce20.Auto_Size = False
        Me.pnlSapce20.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSapce20.ChangeDock = True
        Me.pnlSapce20.Control_Resize = False
        Me.pnlSapce20.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSapce20.isSpace = True
        Me.pnlSapce20.Location = New System.Drawing.Point(113, 0)
        Me.pnlSapce20.Name = "pnlSapce20"
        Me.pnlSapce20.numRows = 0
        Me.pnlSapce20.Reorder = True
        Me.pnlSapce20.Size = New System.Drawing.Size(6, 26)
        Me.pnlSapce20.TabIndex = 2
        '
        'lblPorcenDto
        '
        Me.lblPorcenDto.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblPorcenDto.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblPorcenDto.Location = New System.Drawing.Point(95, 0)
        Me.lblPorcenDto.Name = "lblPorcenDto"
        Me.lblPorcenDto.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.lblPorcenDto.Size = New System.Drawing.Size(18, 26)
        Me.lblPorcenDto.TabIndex = 1
        Me.lblPorcenDto.Text = "%"
        '
        'DatafieldLabel1
        '
        Me.DatafieldLabel1.Allow_Empty = True
        Me.DatafieldLabel1.Allow_Negative = True
        Me.DatafieldLabel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.DatafieldLabel1.BackColor = System.Drawing.SystemColors.Control
        Me.DatafieldLabel1.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.DatafieldLabel1.DataField = Nothing
        Me.DatafieldLabel1.DataTable = ""
        Me.DatafieldLabel1.Descripcion = "Dto. Máx."
        Me.DatafieldLabel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.DatafieldLabel1.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.DatafieldLabel1.FocoEnAgregar = False
        Me.DatafieldLabel1.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.DatafieldLabel1.Image = Nothing
        Me.DatafieldLabel1.Label_Space = 60
        Me.DatafieldLabel1.Length_Data = 32767
        Me.DatafieldLabel1.Location = New System.Drawing.Point(0, 0)
        Me.DatafieldLabel1.Max_Value = 0.0R
        Me.DatafieldLabel1.MensajeIncorrectoCustom = Nothing
        Me.DatafieldLabel1.Name = "DatafieldLabel1"
        Me.DatafieldLabel1.Null_on_Empty = True
        Me.DatafieldLabel1.OpenForm = Nothing
        Me.DatafieldLabel1.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.DatafieldLabel1.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.DatafieldLabel1.ReadOnly_Data = False
        Me.DatafieldLabel1.Show_Button = False
        Me.DatafieldLabel1.Size = New System.Drawing.Size(95, 26)
        Me.DatafieldLabel1.TabIndex = 0
        Me.DatafieldLabel1.Text_Data = ""
        Me.DatafieldLabel1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.DatafieldLabel1.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.DatafieldLabel1.TopPadding = 0
        Me.DatafieldLabel1.Upper_Case = False
        Me.DatafieldLabel1.Validate_on_lost_focus = True
        '
        'pnlSpace19
        '
        Me.pnlSpace19.Auto_Size = False
        Me.pnlSpace19.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace19.ChangeDock = True
        Me.pnlSpace19.Control_Resize = False
        Me.pnlSpace19.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlSpace19.isSpace = False
        Me.pnlSpace19.Location = New System.Drawing.Point(3, 253)
        Me.pnlSpace19.Name = "pnlSpace19"
        Me.pnlSpace19.numRows = 1
        Me.pnlSpace19.Reorder = True
        Me.pnlSpace19.Size = New System.Drawing.Size(616, 6)
        Me.pnlSpace19.TabIndex = 1
        '
        'gbxFechasValidez
        '
        Me.gbxFechasValidez.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.gbxFechasValidez.Controls.Add(Me.gbxVapidezPreaviso)
        Me.gbxFechasValidez.Controls.Add(Me.pnlFechasSalidaRetorno)
        Me.gbxFechasValidez.Controls.Add(Me.pnlRegistroDesde)
        Me.gbxFechasValidez.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbxFechasValidez.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.gbxFechasValidez.HeaderText = "Fechas de Validez para Reservas"
        Me.gbxFechasValidez.Location = New System.Drawing.Point(3, 3)
        Me.gbxFechasValidez.Name = "gbxFechasValidez"
        Me.gbxFechasValidez.numRows = 9
        Me.gbxFechasValidez.Padding = New System.Windows.Forms.Padding(6, 18, 6, 6)
        Me.gbxFechasValidez.Reorder = True
        Me.gbxFechasValidez.Size = New System.Drawing.Size(616, 250)
        Me.gbxFechasValidez.TabIndex = 0
        Me.gbxFechasValidez.Text = "Fechas de Validez para Reservas"
        Me.gbxFechasValidez.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.gbxFechasValidez.ThemeName = "Windows8"
        Me.gbxFechasValidez.Title = "Fechas de Validez para Reservas"
        '
        'gbxVapidezPreaviso
        '
        Me.gbxVapidezPreaviso.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.gbxVapidezPreaviso.Controls.Add(Me.dtfPreaviso)
        Me.gbxVapidezPreaviso.Controls.Add(Me.pnlSpace18)
        Me.gbxVapidezPreaviso.Controls.Add(Me.dtfValidezMaximo)
        Me.gbxVapidezPreaviso.Controls.Add(Me.pnlSpace17)
        Me.gbxVapidezPreaviso.Controls.Add(Me.dtfValidezMinimo)
        Me.gbxVapidezPreaviso.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbxVapidezPreaviso.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.gbxVapidezPreaviso.HeaderText = "Días de validez y preaviso para su contratación"
        Me.gbxVapidezPreaviso.Location = New System.Drawing.Point(6, 197)
        Me.gbxVapidezPreaviso.Name = "gbxVapidezPreaviso"
        Me.gbxVapidezPreaviso.numRows = 1
        Me.gbxVapidezPreaviso.Padding = New System.Windows.Forms.Padding(6, 18, 6, 6)
        Me.gbxVapidezPreaviso.Reorder = True
        Me.gbxVapidezPreaviso.Size = New System.Drawing.Size(604, 46)
        Me.gbxVapidezPreaviso.TabIndex = 2
        Me.gbxVapidezPreaviso.Text = "Días de validez y preaviso para su contratación"
        Me.gbxVapidezPreaviso.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.gbxVapidezPreaviso.ThemeName = "Windows8"
        Me.gbxVapidezPreaviso.Title = "Días de validez y preaviso para su contratación"
        '
        'dtfPreaviso
        '
        Me.dtfPreaviso.Allow_Empty = True
        Me.dtfPreaviso.Allow_Negative = True
        Me.dtfPreaviso.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfPreaviso.BackColor = System.Drawing.SystemColors.Control
        Me.dtfPreaviso.Data_Allowed = CustomControls.Datafield.List_Data.nInteger
        Me.dtfPreaviso.DataField = Nothing
        Me.dtfPreaviso.DataTable = ""
        Me.dtfPreaviso.Descripcion = "Preaviso"
        Me.dtfPreaviso.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfPreaviso.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfPreaviso.FocoEnAgregar = False
        Me.dtfPreaviso.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfPreaviso.Image = Nothing
        Me.dtfPreaviso.Label_Space = 75
        Me.dtfPreaviso.Length_Data = 32767
        Me.dtfPreaviso.Location = New System.Drawing.Point(278, 18)
        Me.dtfPreaviso.Max_Value = 0.0R
        Me.dtfPreaviso.MensajeIncorrectoCustom = Nothing
        Me.dtfPreaviso.Name = "dtfPreaviso"
        Me.dtfPreaviso.Null_on_Empty = True
        Me.dtfPreaviso.OpenForm = Nothing
        Me.dtfPreaviso.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfPreaviso.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfPreaviso.ReadOnly_Data = False
        Me.dtfPreaviso.Show_Button = False
        Me.dtfPreaviso.Size = New System.Drawing.Size(130, 22)
        Me.dtfPreaviso.TabIndex = 4
        Me.dtfPreaviso.Text_Data = ""
        Me.dtfPreaviso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.dtfPreaviso.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfPreaviso.TopPadding = 0
        Me.dtfPreaviso.Upper_Case = False
        Me.dtfPreaviso.Validate_on_lost_focus = True
        '
        'pnlSpace18
        '
        Me.pnlSpace18.Auto_Size = False
        Me.pnlSpace18.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace18.ChangeDock = True
        Me.pnlSpace18.Control_Resize = False
        Me.pnlSpace18.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace18.isSpace = True
        Me.pnlSpace18.Location = New System.Drawing.Point(272, 18)
        Me.pnlSpace18.Name = "pnlSpace18"
        Me.pnlSpace18.numRows = 0
        Me.pnlSpace18.Reorder = True
        Me.pnlSpace18.Size = New System.Drawing.Size(6, 22)
        Me.pnlSpace18.TabIndex = 3
        '
        'dtfValidezMaximo
        '
        Me.dtfValidezMaximo.Allow_Empty = True
        Me.dtfValidezMaximo.Allow_Negative = True
        Me.dtfValidezMaximo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfValidezMaximo.BackColor = System.Drawing.SystemColors.Control
        Me.dtfValidezMaximo.Data_Allowed = CustomControls.Datafield.List_Data.nInteger
        Me.dtfValidezMaximo.DataField = Nothing
        Me.dtfValidezMaximo.DataTable = ""
        Me.dtfValidezMaximo.Descripcion = "Máximo"
        Me.dtfValidezMaximo.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfValidezMaximo.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfValidezMaximo.FocoEnAgregar = False
        Me.dtfValidezMaximo.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfValidezMaximo.Image = Nothing
        Me.dtfValidezMaximo.Label_Space = 75
        Me.dtfValidezMaximo.Length_Data = 32767
        Me.dtfValidezMaximo.Location = New System.Drawing.Point(142, 18)
        Me.dtfValidezMaximo.Max_Value = 0.0R
        Me.dtfValidezMaximo.MensajeIncorrectoCustom = Nothing
        Me.dtfValidezMaximo.Name = "dtfValidezMaximo"
        Me.dtfValidezMaximo.Null_on_Empty = True
        Me.dtfValidezMaximo.OpenForm = Nothing
        Me.dtfValidezMaximo.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfValidezMaximo.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfValidezMaximo.ReadOnly_Data = False
        Me.dtfValidezMaximo.Show_Button = False
        Me.dtfValidezMaximo.Size = New System.Drawing.Size(130, 22)
        Me.dtfValidezMaximo.TabIndex = 2
        Me.dtfValidezMaximo.Text_Data = ""
        Me.dtfValidezMaximo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.dtfValidezMaximo.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfValidezMaximo.TopPadding = 0
        Me.dtfValidezMaximo.Upper_Case = False
        Me.dtfValidezMaximo.Validate_on_lost_focus = True
        '
        'pnlSpace17
        '
        Me.pnlSpace17.Auto_Size = False
        Me.pnlSpace17.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace17.ChangeDock = True
        Me.pnlSpace17.Control_Resize = False
        Me.pnlSpace17.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace17.isSpace = True
        Me.pnlSpace17.Location = New System.Drawing.Point(136, 18)
        Me.pnlSpace17.Name = "pnlSpace17"
        Me.pnlSpace17.numRows = 0
        Me.pnlSpace17.Reorder = True
        Me.pnlSpace17.Size = New System.Drawing.Size(6, 22)
        Me.pnlSpace17.TabIndex = 1
        '
        'dtfValidezMinimo
        '
        Me.dtfValidezMinimo.Allow_Empty = True
        Me.dtfValidezMinimo.Allow_Negative = True
        Me.dtfValidezMinimo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfValidezMinimo.BackColor = System.Drawing.SystemColors.Control
        Me.dtfValidezMinimo.Data_Allowed = CustomControls.Datafield.List_Data.nInteger
        Me.dtfValidezMinimo.DataField = Nothing
        Me.dtfValidezMinimo.DataTable = ""
        Me.dtfValidezMinimo.Descripcion = "Mínimo"
        Me.dtfValidezMinimo.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfValidezMinimo.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfValidezMinimo.FocoEnAgregar = False
        Me.dtfValidezMinimo.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfValidezMinimo.Image = Nothing
        Me.dtfValidezMinimo.Label_Space = 75
        Me.dtfValidezMinimo.Length_Data = 32767
        Me.dtfValidezMinimo.Location = New System.Drawing.Point(6, 18)
        Me.dtfValidezMinimo.Max_Value = 0.0R
        Me.dtfValidezMinimo.MensajeIncorrectoCustom = Nothing
        Me.dtfValidezMinimo.Name = "dtfValidezMinimo"
        Me.dtfValidezMinimo.Null_on_Empty = True
        Me.dtfValidezMinimo.OpenForm = Nothing
        Me.dtfValidezMinimo.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfValidezMinimo.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfValidezMinimo.ReadOnly_Data = False
        Me.dtfValidezMinimo.Show_Button = False
        Me.dtfValidezMinimo.Size = New System.Drawing.Size(130, 22)
        Me.dtfValidezMinimo.TabIndex = 0
        Me.dtfValidezMinimo.Text_Data = ""
        Me.dtfValidezMinimo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.dtfValidezMinimo.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfValidezMinimo.TopPadding = 0
        Me.dtfValidezMinimo.Upper_Case = False
        Me.dtfValidezMinimo.Validate_on_lost_focus = True
        '
        'pnlFechasSalidaRetorno
        '
        Me.pnlFechasSalidaRetorno.Auto_Size = False
        Me.pnlFechasSalidaRetorno.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlFechasSalidaRetorno.ChangeDock = True
        Me.pnlFechasSalidaRetorno.Control_Resize = False
        Me.pnlFechasSalidaRetorno.Controls.Add(Me.gbxRetorno)
        Me.pnlFechasSalidaRetorno.Controls.Add(Me.pnlSpace16)
        Me.pnlFechasSalidaRetorno.Controls.Add(Me.gbxSalida)
        Me.pnlFechasSalidaRetorno.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFechasSalidaRetorno.isSpace = False
        Me.pnlFechasSalidaRetorno.Location = New System.Drawing.Point(6, 44)
        Me.pnlFechasSalidaRetorno.Name = "pnlFechasSalidaRetorno"
        Me.pnlFechasSalidaRetorno.numRows = 6
        Me.pnlFechasSalidaRetorno.Reorder = True
        Me.pnlFechasSalidaRetorno.Size = New System.Drawing.Size(604, 153)
        Me.pnlFechasSalidaRetorno.TabIndex = 1
        '
        'gbxRetorno
        '
        Me.gbxRetorno.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.gbxRetorno.Controls.Add(Me.pnlRetornoDesde5)
        Me.gbxRetorno.Controls.Add(Me.pnlRetornoDesde4)
        Me.gbxRetorno.Controls.Add(Me.pnlRetornoDesde3)
        Me.gbxRetorno.Controls.Add(Me.pnlRetornoDesde2)
        Me.gbxRetorno.Controls.Add(Me.pnlRetornoDesde)
        Me.gbxRetorno.Dock = System.Windows.Forms.DockStyle.Left
        Me.gbxRetorno.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.gbxRetorno.HeaderText = "Retorno"
        Me.gbxRetorno.Location = New System.Drawing.Point(296, 0)
        Me.gbxRetorno.Name = "gbxRetorno"
        Me.gbxRetorno.numRows = 5
        Me.gbxRetorno.Padding = New System.Windows.Forms.Padding(6, 18, 6, 6)
        Me.gbxRetorno.Reorder = True
        Me.gbxRetorno.Size = New System.Drawing.Size(290, 153)
        Me.gbxRetorno.TabIndex = 2
        Me.gbxRetorno.Text = "Retorno"
        Me.gbxRetorno.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.gbxRetorno.ThemeName = "Windows8"
        Me.gbxRetorno.Title = "Retorno"
        '
        'pnlRetornoDesde5
        '
        Me.pnlRetornoDesde5.Auto_Size = False
        Me.pnlRetornoDesde5.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlRetornoDesde5.ChangeDock = True
        Me.pnlRetornoDesde5.Control_Resize = False
        Me.pnlRetornoDesde5.Controls.Add(Me.dtdRetornoHasta5)
        Me.pnlRetornoDesde5.Controls.Add(Me.pnlSpace15)
        Me.pnlRetornoDesde5.Controls.Add(Me.dtdRetornoDesde5)
        Me.pnlRetornoDesde5.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlRetornoDesde5.isSpace = False
        Me.pnlRetornoDesde5.Location = New System.Drawing.Point(6, 122)
        Me.pnlRetornoDesde5.Name = "pnlRetornoDesde5"
        Me.pnlRetornoDesde5.numRows = 1
        Me.pnlRetornoDesde5.Reorder = True
        Me.pnlRetornoDesde5.Size = New System.Drawing.Size(278, 26)
        Me.pnlRetornoDesde5.TabIndex = 4
        '
        'dtdRetornoHasta5
        '
        Me.dtdRetornoHasta5.Allow_Empty = True
        Me.dtdRetornoHasta5.DataField = Nothing
        Me.dtdRetornoHasta5.DataTable = ""
        Me.dtdRetornoHasta5.Default_Value = New Date(2015, 11, 20, 0, 0, 0, 0)
        Me.dtdRetornoHasta5.Descripcion = "hasta"
        Me.dtdRetornoHasta5.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtdRetornoHasta5.FocoEnAgregar = False
        Me.dtdRetornoHasta5.Label_Space = 40
        Me.dtdRetornoHasta5.Location = New System.Drawing.Point(146, 0)
        Me.dtdRetornoHasta5.Max_Value = Nothing
        Me.dtdRetornoHasta5.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdRetornoHasta5.MensajeIncorrectoCustom = Nothing
        Me.dtdRetornoHasta5.Min_Value = Nothing
        Me.dtdRetornoHasta5.MinDate = New Date(CType(0, Long))
        Me.dtdRetornoHasta5.MinimumSize = New System.Drawing.Size(130, 26)
        Me.dtdRetornoHasta5.Name = "dtdRetornoHasta5"
        Me.dtdRetornoHasta5.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdRetornoHasta5.ReadOnly_Data = False
        Me.dtdRetornoHasta5.Size = New System.Drawing.Size(135, 26)
        Me.dtdRetornoHasta5.TabIndex = 2
        Me.dtdRetornoHasta5.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdRetornoHasta5.Validate_on_lost_focus = True
        Me.dtdRetornoHasta5.Value_Data = New Date(2015, 11, 20, 0, 0, 0, 0)
        '
        'pnlSpace15
        '
        Me.pnlSpace15.Auto_Size = False
        Me.pnlSpace15.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace15.ChangeDock = True
        Me.pnlSpace15.Control_Resize = False
        Me.pnlSpace15.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace15.isSpace = True
        Me.pnlSpace15.Location = New System.Drawing.Point(140, 0)
        Me.pnlSpace15.Name = "pnlSpace15"
        Me.pnlSpace15.numRows = 0
        Me.pnlSpace15.Reorder = True
        Me.pnlSpace15.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace15.TabIndex = 1
        '
        'dtdRetornoDesde5
        '
        Me.dtdRetornoDesde5.Allow_Empty = True
        Me.dtdRetornoDesde5.DataField = Nothing
        Me.dtdRetornoDesde5.DataTable = ""
        Me.dtdRetornoDesde5.Default_Value = New Date(2015, 11, 20, 0, 0, 0, 0)
        Me.dtdRetornoDesde5.Descripcion = "o desde"
        Me.dtdRetornoDesde5.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtdRetornoDesde5.FocoEnAgregar = False
        Me.dtdRetornoDesde5.Label_Space = 50
        Me.dtdRetornoDesde5.Location = New System.Drawing.Point(0, 0)
        Me.dtdRetornoDesde5.Max_Value = Nothing
        Me.dtdRetornoDesde5.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdRetornoDesde5.MensajeIncorrectoCustom = Nothing
        Me.dtdRetornoDesde5.Min_Value = Nothing
        Me.dtdRetornoDesde5.MinDate = New Date(CType(0, Long))
        Me.dtdRetornoDesde5.MinimumSize = New System.Drawing.Size(140, 26)
        Me.dtdRetornoDesde5.Name = "dtdRetornoDesde5"
        Me.dtdRetornoDesde5.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdRetornoDesde5.ReadOnly_Data = False
        Me.dtdRetornoDesde5.Size = New System.Drawing.Size(140, 26)
        Me.dtdRetornoDesde5.TabIndex = 0
        Me.dtdRetornoDesde5.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdRetornoDesde5.Validate_on_lost_focus = True
        Me.dtdRetornoDesde5.Value_Data = New Date(2015, 11, 20, 0, 0, 0, 0)
        '
        'pnlRetornoDesde4
        '
        Me.pnlRetornoDesde4.Auto_Size = False
        Me.pnlRetornoDesde4.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlRetornoDesde4.ChangeDock = True
        Me.pnlRetornoDesde4.Control_Resize = False
        Me.pnlRetornoDesde4.Controls.Add(Me.dtdRetornoHasta4)
        Me.pnlRetornoDesde4.Controls.Add(Me.pnlSpace14)
        Me.pnlRetornoDesde4.Controls.Add(Me.dtdRetornoDesde4)
        Me.pnlRetornoDesde4.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlRetornoDesde4.isSpace = False
        Me.pnlRetornoDesde4.Location = New System.Drawing.Point(6, 96)
        Me.pnlRetornoDesde4.Name = "pnlRetornoDesde4"
        Me.pnlRetornoDesde4.numRows = 1
        Me.pnlRetornoDesde4.Reorder = True
        Me.pnlRetornoDesde4.Size = New System.Drawing.Size(278, 26)
        Me.pnlRetornoDesde4.TabIndex = 3
        '
        'dtdRetornoHasta4
        '
        Me.dtdRetornoHasta4.Allow_Empty = True
        Me.dtdRetornoHasta4.DataField = Nothing
        Me.dtdRetornoHasta4.DataTable = ""
        Me.dtdRetornoHasta4.Default_Value = New Date(2015, 11, 20, 0, 0, 0, 0)
        Me.dtdRetornoHasta4.Descripcion = "hasta"
        Me.dtdRetornoHasta4.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtdRetornoHasta4.FocoEnAgregar = False
        Me.dtdRetornoHasta4.Label_Space = 40
        Me.dtdRetornoHasta4.Location = New System.Drawing.Point(146, 0)
        Me.dtdRetornoHasta4.Max_Value = Nothing
        Me.dtdRetornoHasta4.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdRetornoHasta4.MensajeIncorrectoCustom = Nothing
        Me.dtdRetornoHasta4.Min_Value = Nothing
        Me.dtdRetornoHasta4.MinDate = New Date(CType(0, Long))
        Me.dtdRetornoHasta4.MinimumSize = New System.Drawing.Size(130, 26)
        Me.dtdRetornoHasta4.Name = "dtdRetornoHasta4"
        Me.dtdRetornoHasta4.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdRetornoHasta4.ReadOnly_Data = False
        Me.dtdRetornoHasta4.Size = New System.Drawing.Size(135, 26)
        Me.dtdRetornoHasta4.TabIndex = 2
        Me.dtdRetornoHasta4.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdRetornoHasta4.Validate_on_lost_focus = True
        Me.dtdRetornoHasta4.Value_Data = New Date(2015, 11, 20, 0, 0, 0, 0)
        '
        'pnlSpace14
        '
        Me.pnlSpace14.Auto_Size = False
        Me.pnlSpace14.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace14.ChangeDock = True
        Me.pnlSpace14.Control_Resize = False
        Me.pnlSpace14.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace14.isSpace = True
        Me.pnlSpace14.Location = New System.Drawing.Point(140, 0)
        Me.pnlSpace14.Name = "pnlSpace14"
        Me.pnlSpace14.numRows = 0
        Me.pnlSpace14.Reorder = True
        Me.pnlSpace14.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace14.TabIndex = 1
        '
        'dtdRetornoDesde4
        '
        Me.dtdRetornoDesde4.Allow_Empty = True
        Me.dtdRetornoDesde4.DataField = Nothing
        Me.dtdRetornoDesde4.DataTable = ""
        Me.dtdRetornoDesde4.Default_Value = New Date(2015, 11, 20, 0, 0, 0, 0)
        Me.dtdRetornoDesde4.Descripcion = "o desde"
        Me.dtdRetornoDesde4.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtdRetornoDesde4.FocoEnAgregar = False
        Me.dtdRetornoDesde4.Label_Space = 50
        Me.dtdRetornoDesde4.Location = New System.Drawing.Point(0, 0)
        Me.dtdRetornoDesde4.Max_Value = Nothing
        Me.dtdRetornoDesde4.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdRetornoDesde4.MensajeIncorrectoCustom = Nothing
        Me.dtdRetornoDesde4.Min_Value = Nothing
        Me.dtdRetornoDesde4.MinDate = New Date(CType(0, Long))
        Me.dtdRetornoDesde4.MinimumSize = New System.Drawing.Size(140, 26)
        Me.dtdRetornoDesde4.Name = "dtdRetornoDesde4"
        Me.dtdRetornoDesde4.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdRetornoDesde4.ReadOnly_Data = False
        Me.dtdRetornoDesde4.Size = New System.Drawing.Size(140, 26)
        Me.dtdRetornoDesde4.TabIndex = 0
        Me.dtdRetornoDesde4.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdRetornoDesde4.Validate_on_lost_focus = True
        Me.dtdRetornoDesde4.Value_Data = New Date(2015, 11, 20, 0, 0, 0, 0)
        '
        'pnlRetornoDesde3
        '
        Me.pnlRetornoDesde3.Auto_Size = False
        Me.pnlRetornoDesde3.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlRetornoDesde3.ChangeDock = True
        Me.pnlRetornoDesde3.Control_Resize = False
        Me.pnlRetornoDesde3.Controls.Add(Me.dtdRetornoHasta3)
        Me.pnlRetornoDesde3.Controls.Add(Me.pnlSpace13)
        Me.pnlRetornoDesde3.Controls.Add(Me.dtdRetornoDesde3)
        Me.pnlRetornoDesde3.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlRetornoDesde3.isSpace = False
        Me.pnlRetornoDesde3.Location = New System.Drawing.Point(6, 70)
        Me.pnlRetornoDesde3.Name = "pnlRetornoDesde3"
        Me.pnlRetornoDesde3.numRows = 1
        Me.pnlRetornoDesde3.Reorder = True
        Me.pnlRetornoDesde3.Size = New System.Drawing.Size(278, 26)
        Me.pnlRetornoDesde3.TabIndex = 2
        '
        'dtdRetornoHasta3
        '
        Me.dtdRetornoHasta3.Allow_Empty = True
        Me.dtdRetornoHasta3.DataField = Nothing
        Me.dtdRetornoHasta3.DataTable = ""
        Me.dtdRetornoHasta3.Default_Value = New Date(2015, 11, 20, 0, 0, 0, 0)
        Me.dtdRetornoHasta3.Descripcion = "hasta"
        Me.dtdRetornoHasta3.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtdRetornoHasta3.FocoEnAgregar = False
        Me.dtdRetornoHasta3.Label_Space = 40
        Me.dtdRetornoHasta3.Location = New System.Drawing.Point(146, 0)
        Me.dtdRetornoHasta3.Max_Value = Nothing
        Me.dtdRetornoHasta3.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdRetornoHasta3.MensajeIncorrectoCustom = Nothing
        Me.dtdRetornoHasta3.Min_Value = Nothing
        Me.dtdRetornoHasta3.MinDate = New Date(CType(0, Long))
        Me.dtdRetornoHasta3.MinimumSize = New System.Drawing.Size(130, 26)
        Me.dtdRetornoHasta3.Name = "dtdRetornoHasta3"
        Me.dtdRetornoHasta3.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdRetornoHasta3.ReadOnly_Data = False
        Me.dtdRetornoHasta3.Size = New System.Drawing.Size(135, 26)
        Me.dtdRetornoHasta3.TabIndex = 2
        Me.dtdRetornoHasta3.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdRetornoHasta3.Validate_on_lost_focus = True
        Me.dtdRetornoHasta3.Value_Data = New Date(2015, 11, 20, 0, 0, 0, 0)
        '
        'pnlSpace13
        '
        Me.pnlSpace13.Auto_Size = False
        Me.pnlSpace13.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace13.ChangeDock = True
        Me.pnlSpace13.Control_Resize = False
        Me.pnlSpace13.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace13.isSpace = True
        Me.pnlSpace13.Location = New System.Drawing.Point(140, 0)
        Me.pnlSpace13.Name = "pnlSpace13"
        Me.pnlSpace13.numRows = 0
        Me.pnlSpace13.Reorder = True
        Me.pnlSpace13.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace13.TabIndex = 1
        '
        'dtdRetornoDesde3
        '
        Me.dtdRetornoDesde3.Allow_Empty = True
        Me.dtdRetornoDesde3.DataField = Nothing
        Me.dtdRetornoDesde3.DataTable = ""
        Me.dtdRetornoDesde3.Default_Value = New Date(2015, 11, 20, 0, 0, 0, 0)
        Me.dtdRetornoDesde3.Descripcion = "o desde"
        Me.dtdRetornoDesde3.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtdRetornoDesde3.FocoEnAgregar = False
        Me.dtdRetornoDesde3.Label_Space = 50
        Me.dtdRetornoDesde3.Location = New System.Drawing.Point(0, 0)
        Me.dtdRetornoDesde3.Max_Value = Nothing
        Me.dtdRetornoDesde3.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdRetornoDesde3.MensajeIncorrectoCustom = Nothing
        Me.dtdRetornoDesde3.Min_Value = Nothing
        Me.dtdRetornoDesde3.MinDate = New Date(CType(0, Long))
        Me.dtdRetornoDesde3.MinimumSize = New System.Drawing.Size(140, 26)
        Me.dtdRetornoDesde3.Name = "dtdRetornoDesde3"
        Me.dtdRetornoDesde3.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdRetornoDesde3.ReadOnly_Data = False
        Me.dtdRetornoDesde3.Size = New System.Drawing.Size(140, 26)
        Me.dtdRetornoDesde3.TabIndex = 0
        Me.dtdRetornoDesde3.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdRetornoDesde3.Validate_on_lost_focus = True
        Me.dtdRetornoDesde3.Value_Data = New Date(2015, 11, 20, 0, 0, 0, 0)
        '
        'pnlRetornoDesde2
        '
        Me.pnlRetornoDesde2.Auto_Size = False
        Me.pnlRetornoDesde2.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlRetornoDesde2.ChangeDock = True
        Me.pnlRetornoDesde2.Control_Resize = False
        Me.pnlRetornoDesde2.Controls.Add(Me.dtdRetornoHasta2)
        Me.pnlRetornoDesde2.Controls.Add(Me.pnlSpace12)
        Me.pnlRetornoDesde2.Controls.Add(Me.dtdRetornoDesde2)
        Me.pnlRetornoDesde2.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlRetornoDesde2.isSpace = False
        Me.pnlRetornoDesde2.Location = New System.Drawing.Point(6, 44)
        Me.pnlRetornoDesde2.Name = "pnlRetornoDesde2"
        Me.pnlRetornoDesde2.numRows = 1
        Me.pnlRetornoDesde2.Reorder = True
        Me.pnlRetornoDesde2.Size = New System.Drawing.Size(278, 26)
        Me.pnlRetornoDesde2.TabIndex = 1
        '
        'dtdRetornoHasta2
        '
        Me.dtdRetornoHasta2.Allow_Empty = True
        Me.dtdRetornoHasta2.DataField = Nothing
        Me.dtdRetornoHasta2.DataTable = ""
        Me.dtdRetornoHasta2.Default_Value = New Date(2015, 11, 20, 0, 0, 0, 0)
        Me.dtdRetornoHasta2.Descripcion = "hasta"
        Me.dtdRetornoHasta2.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtdRetornoHasta2.FocoEnAgregar = False
        Me.dtdRetornoHasta2.Label_Space = 40
        Me.dtdRetornoHasta2.Location = New System.Drawing.Point(146, 0)
        Me.dtdRetornoHasta2.Max_Value = Nothing
        Me.dtdRetornoHasta2.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdRetornoHasta2.MensajeIncorrectoCustom = Nothing
        Me.dtdRetornoHasta2.Min_Value = Nothing
        Me.dtdRetornoHasta2.MinDate = New Date(CType(0, Long))
        Me.dtdRetornoHasta2.MinimumSize = New System.Drawing.Size(130, 26)
        Me.dtdRetornoHasta2.Name = "dtdRetornoHasta2"
        Me.dtdRetornoHasta2.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdRetornoHasta2.ReadOnly_Data = False
        Me.dtdRetornoHasta2.Size = New System.Drawing.Size(135, 26)
        Me.dtdRetornoHasta2.TabIndex = 2
        Me.dtdRetornoHasta2.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdRetornoHasta2.Validate_on_lost_focus = True
        Me.dtdRetornoHasta2.Value_Data = New Date(2015, 11, 20, 0, 0, 0, 0)
        '
        'pnlSpace12
        '
        Me.pnlSpace12.Auto_Size = False
        Me.pnlSpace12.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace12.ChangeDock = True
        Me.pnlSpace12.Control_Resize = False
        Me.pnlSpace12.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace12.isSpace = True
        Me.pnlSpace12.Location = New System.Drawing.Point(140, 0)
        Me.pnlSpace12.Name = "pnlSpace12"
        Me.pnlSpace12.numRows = 0
        Me.pnlSpace12.Reorder = True
        Me.pnlSpace12.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace12.TabIndex = 1
        '
        'dtdRetornoDesde2
        '
        Me.dtdRetornoDesde2.Allow_Empty = True
        Me.dtdRetornoDesde2.DataField = Nothing
        Me.dtdRetornoDesde2.DataTable = ""
        Me.dtdRetornoDesde2.Default_Value = New Date(2015, 11, 20, 0, 0, 0, 0)
        Me.dtdRetornoDesde2.Descripcion = "o desde"
        Me.dtdRetornoDesde2.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtdRetornoDesde2.FocoEnAgregar = False
        Me.dtdRetornoDesde2.Label_Space = 50
        Me.dtdRetornoDesde2.Location = New System.Drawing.Point(0, 0)
        Me.dtdRetornoDesde2.Max_Value = Nothing
        Me.dtdRetornoDesde2.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdRetornoDesde2.MensajeIncorrectoCustom = Nothing
        Me.dtdRetornoDesde2.Min_Value = Nothing
        Me.dtdRetornoDesde2.MinDate = New Date(CType(0, Long))
        Me.dtdRetornoDesde2.MinimumSize = New System.Drawing.Size(140, 26)
        Me.dtdRetornoDesde2.Name = "dtdRetornoDesde2"
        Me.dtdRetornoDesde2.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdRetornoDesde2.ReadOnly_Data = False
        Me.dtdRetornoDesde2.Size = New System.Drawing.Size(140, 26)
        Me.dtdRetornoDesde2.TabIndex = 0
        Me.dtdRetornoDesde2.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdRetornoDesde2.Validate_on_lost_focus = True
        Me.dtdRetornoDesde2.Value_Data = New Date(2015, 11, 20, 0, 0, 0, 0)
        '
        'pnlRetornoDesde
        '
        Me.pnlRetornoDesde.Auto_Size = False
        Me.pnlRetornoDesde.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlRetornoDesde.ChangeDock = True
        Me.pnlRetornoDesde.Control_Resize = False
        Me.pnlRetornoDesde.Controls.Add(Me.dtdRetornoHasta)
        Me.pnlRetornoDesde.Controls.Add(Me.pnlSpace11)
        Me.pnlRetornoDesde.Controls.Add(Me.dtdRetornoDesde)
        Me.pnlRetornoDesde.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlRetornoDesde.isSpace = False
        Me.pnlRetornoDesde.Location = New System.Drawing.Point(6, 18)
        Me.pnlRetornoDesde.Name = "pnlRetornoDesde"
        Me.pnlRetornoDesde.numRows = 1
        Me.pnlRetornoDesde.Reorder = True
        Me.pnlRetornoDesde.Size = New System.Drawing.Size(278, 26)
        Me.pnlRetornoDesde.TabIndex = 0
        '
        'dtdRetornoHasta
        '
        Me.dtdRetornoHasta.Allow_Empty = True
        Me.dtdRetornoHasta.DataField = Nothing
        Me.dtdRetornoHasta.DataTable = ""
        Me.dtdRetornoHasta.Default_Value = New Date(2015, 11, 20, 0, 0, 0, 0)
        Me.dtdRetornoHasta.Descripcion = "hasta"
        Me.dtdRetornoHasta.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtdRetornoHasta.FocoEnAgregar = False
        Me.dtdRetornoHasta.Label_Space = 40
        Me.dtdRetornoHasta.Location = New System.Drawing.Point(146, 0)
        Me.dtdRetornoHasta.Max_Value = Nothing
        Me.dtdRetornoHasta.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdRetornoHasta.MensajeIncorrectoCustom = Nothing
        Me.dtdRetornoHasta.Min_Value = Nothing
        Me.dtdRetornoHasta.MinDate = New Date(CType(0, Long))
        Me.dtdRetornoHasta.MinimumSize = New System.Drawing.Size(130, 26)
        Me.dtdRetornoHasta.Name = "dtdRetornoHasta"
        Me.dtdRetornoHasta.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdRetornoHasta.ReadOnly_Data = False
        Me.dtdRetornoHasta.Size = New System.Drawing.Size(135, 26)
        Me.dtdRetornoHasta.TabIndex = 2
        Me.dtdRetornoHasta.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdRetornoHasta.Validate_on_lost_focus = True
        Me.dtdRetornoHasta.Value_Data = New Date(2015, 11, 20, 0, 0, 0, 0)
        '
        'pnlSpace11
        '
        Me.pnlSpace11.Auto_Size = False
        Me.pnlSpace11.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace11.ChangeDock = True
        Me.pnlSpace11.Control_Resize = False
        Me.pnlSpace11.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace11.isSpace = True
        Me.pnlSpace11.Location = New System.Drawing.Point(140, 0)
        Me.pnlSpace11.Name = "pnlSpace11"
        Me.pnlSpace11.numRows = 0
        Me.pnlSpace11.Reorder = True
        Me.pnlSpace11.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace11.TabIndex = 1
        '
        'dtdRetornoDesde
        '
        Me.dtdRetornoDesde.Allow_Empty = True
        Me.dtdRetornoDesde.DataField = Nothing
        Me.dtdRetornoDesde.DataTable = ""
        Me.dtdRetornoDesde.Default_Value = New Date(2015, 11, 20, 0, 0, 0, 0)
        Me.dtdRetornoDesde.Descripcion = "Desde"
        Me.dtdRetornoDesde.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtdRetornoDesde.FocoEnAgregar = False
        Me.dtdRetornoDesde.Label_Space = 50
        Me.dtdRetornoDesde.Location = New System.Drawing.Point(0, 0)
        Me.dtdRetornoDesde.Max_Value = Nothing
        Me.dtdRetornoDesde.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdRetornoDesde.MensajeIncorrectoCustom = Nothing
        Me.dtdRetornoDesde.Min_Value = Nothing
        Me.dtdRetornoDesde.MinDate = New Date(CType(0, Long))
        Me.dtdRetornoDesde.MinimumSize = New System.Drawing.Size(140, 26)
        Me.dtdRetornoDesde.Name = "dtdRetornoDesde"
        Me.dtdRetornoDesde.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdRetornoDesde.ReadOnly_Data = False
        Me.dtdRetornoDesde.Size = New System.Drawing.Size(140, 26)
        Me.dtdRetornoDesde.TabIndex = 0
        Me.dtdRetornoDesde.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdRetornoDesde.Validate_on_lost_focus = True
        Me.dtdRetornoDesde.Value_Data = New Date(2015, 11, 20, 0, 0, 0, 0)
        '
        'pnlSpace16
        '
        Me.pnlSpace16.Auto_Size = False
        Me.pnlSpace16.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace16.ChangeDock = True
        Me.pnlSpace16.Control_Resize = False
        Me.pnlSpace16.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace16.isSpace = True
        Me.pnlSpace16.Location = New System.Drawing.Point(290, 0)
        Me.pnlSpace16.Name = "pnlSpace16"
        Me.pnlSpace16.numRows = 0
        Me.pnlSpace16.Reorder = True
        Me.pnlSpace16.Size = New System.Drawing.Size(6, 153)
        Me.pnlSpace16.TabIndex = 1
        '
        'gbxSalida
        '
        Me.gbxSalida.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.gbxSalida.Controls.Add(Me.pnlSalidaDesde5)
        Me.gbxSalida.Controls.Add(Me.pnlSalidaDesde4)
        Me.gbxSalida.Controls.Add(Me.pnlSalidaDesde3)
        Me.gbxSalida.Controls.Add(Me.pnlSalidaDesde2)
        Me.gbxSalida.Controls.Add(Me.pnlSalidaDesde)
        Me.gbxSalida.Dock = System.Windows.Forms.DockStyle.Left
        Me.gbxSalida.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.gbxSalida.HeaderText = "Salida"
        Me.gbxSalida.Location = New System.Drawing.Point(0, 0)
        Me.gbxSalida.Name = "gbxSalida"
        Me.gbxSalida.numRows = 5
        Me.gbxSalida.Padding = New System.Windows.Forms.Padding(6, 18, 6, 6)
        Me.gbxSalida.Reorder = True
        Me.gbxSalida.Size = New System.Drawing.Size(290, 153)
        Me.gbxSalida.TabIndex = 0
        Me.gbxSalida.Text = "Salida"
        Me.gbxSalida.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.gbxSalida.ThemeName = "Windows8"
        Me.gbxSalida.Title = "Salida"
        '
        'pnlSalidaDesde5
        '
        Me.pnlSalidaDesde5.Auto_Size = False
        Me.pnlSalidaDesde5.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSalidaDesde5.ChangeDock = True
        Me.pnlSalidaDesde5.Control_Resize = False
        Me.pnlSalidaDesde5.Controls.Add(Me.dtdSalidaHasta5)
        Me.pnlSalidaDesde5.Controls.Add(Me.pnlSpace10)
        Me.pnlSalidaDesde5.Controls.Add(Me.dtdSalidaDesde5)
        Me.pnlSalidaDesde5.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlSalidaDesde5.isSpace = False
        Me.pnlSalidaDesde5.Location = New System.Drawing.Point(6, 122)
        Me.pnlSalidaDesde5.Name = "pnlSalidaDesde5"
        Me.pnlSalidaDesde5.numRows = 1
        Me.pnlSalidaDesde5.Reorder = True
        Me.pnlSalidaDesde5.Size = New System.Drawing.Size(278, 26)
        Me.pnlSalidaDesde5.TabIndex = 4
        '
        'dtdSalidaHasta5
        '
        Me.dtdSalidaHasta5.Allow_Empty = True
        Me.dtdSalidaHasta5.DataField = Nothing
        Me.dtdSalidaHasta5.DataTable = ""
        Me.dtdSalidaHasta5.Default_Value = New Date(2015, 11, 20, 0, 0, 0, 0)
        Me.dtdSalidaHasta5.Descripcion = "hasta"
        Me.dtdSalidaHasta5.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtdSalidaHasta5.FocoEnAgregar = False
        Me.dtdSalidaHasta5.Label_Space = 40
        Me.dtdSalidaHasta5.Location = New System.Drawing.Point(146, 0)
        Me.dtdSalidaHasta5.Max_Value = Nothing
        Me.dtdSalidaHasta5.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdSalidaHasta5.MensajeIncorrectoCustom = Nothing
        Me.dtdSalidaHasta5.Min_Value = Nothing
        Me.dtdSalidaHasta5.MinDate = New Date(CType(0, Long))
        Me.dtdSalidaHasta5.MinimumSize = New System.Drawing.Size(130, 26)
        Me.dtdSalidaHasta5.Name = "dtdSalidaHasta5"
        Me.dtdSalidaHasta5.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdSalidaHasta5.ReadOnly_Data = False
        Me.dtdSalidaHasta5.Size = New System.Drawing.Size(135, 26)
        Me.dtdSalidaHasta5.TabIndex = 2
        Me.dtdSalidaHasta5.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdSalidaHasta5.Validate_on_lost_focus = True
        Me.dtdSalidaHasta5.Value_Data = New Date(2015, 11, 20, 0, 0, 0, 0)
        '
        'pnlSpace10
        '
        Me.pnlSpace10.Auto_Size = False
        Me.pnlSpace10.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace10.ChangeDock = True
        Me.pnlSpace10.Control_Resize = False
        Me.pnlSpace10.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace10.isSpace = True
        Me.pnlSpace10.Location = New System.Drawing.Point(140, 0)
        Me.pnlSpace10.Name = "pnlSpace10"
        Me.pnlSpace10.numRows = 0
        Me.pnlSpace10.Reorder = True
        Me.pnlSpace10.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace10.TabIndex = 1
        '
        'dtdSalidaDesde5
        '
        Me.dtdSalidaDesde5.Allow_Empty = True
        Me.dtdSalidaDesde5.DataField = Nothing
        Me.dtdSalidaDesde5.DataTable = ""
        Me.dtdSalidaDesde5.Default_Value = New Date(2015, 11, 20, 0, 0, 0, 0)
        Me.dtdSalidaDesde5.Descripcion = "o desde"
        Me.dtdSalidaDesde5.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtdSalidaDesde5.FocoEnAgregar = False
        Me.dtdSalidaDesde5.Label_Space = 50
        Me.dtdSalidaDesde5.Location = New System.Drawing.Point(0, 0)
        Me.dtdSalidaDesde5.Max_Value = Nothing
        Me.dtdSalidaDesde5.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdSalidaDesde5.MensajeIncorrectoCustom = Nothing
        Me.dtdSalidaDesde5.Min_Value = Nothing
        Me.dtdSalidaDesde5.MinDate = New Date(CType(0, Long))
        Me.dtdSalidaDesde5.MinimumSize = New System.Drawing.Size(140, 26)
        Me.dtdSalidaDesde5.Name = "dtdSalidaDesde5"
        Me.dtdSalidaDesde5.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdSalidaDesde5.ReadOnly_Data = False
        Me.dtdSalidaDesde5.Size = New System.Drawing.Size(140, 26)
        Me.dtdSalidaDesde5.TabIndex = 0
        Me.dtdSalidaDesde5.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdSalidaDesde5.Validate_on_lost_focus = True
        Me.dtdSalidaDesde5.Value_Data = New Date(2015, 11, 20, 0, 0, 0, 0)
        '
        'pnlSalidaDesde4
        '
        Me.pnlSalidaDesde4.Auto_Size = False
        Me.pnlSalidaDesde4.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSalidaDesde4.ChangeDock = True
        Me.pnlSalidaDesde4.Control_Resize = False
        Me.pnlSalidaDesde4.Controls.Add(Me.dtdSalidaHasta4)
        Me.pnlSalidaDesde4.Controls.Add(Me.pnlSpace9)
        Me.pnlSalidaDesde4.Controls.Add(Me.dtdSalidaDesde4)
        Me.pnlSalidaDesde4.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlSalidaDesde4.isSpace = False
        Me.pnlSalidaDesde4.Location = New System.Drawing.Point(6, 96)
        Me.pnlSalidaDesde4.Name = "pnlSalidaDesde4"
        Me.pnlSalidaDesde4.numRows = 1
        Me.pnlSalidaDesde4.Reorder = True
        Me.pnlSalidaDesde4.Size = New System.Drawing.Size(278, 26)
        Me.pnlSalidaDesde4.TabIndex = 3
        '
        'dtdSalidaHasta4
        '
        Me.dtdSalidaHasta4.Allow_Empty = True
        Me.dtdSalidaHasta4.DataField = Nothing
        Me.dtdSalidaHasta4.DataTable = ""
        Me.dtdSalidaHasta4.Default_Value = New Date(2015, 11, 20, 0, 0, 0, 0)
        Me.dtdSalidaHasta4.Descripcion = "hasta"
        Me.dtdSalidaHasta4.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtdSalidaHasta4.FocoEnAgregar = False
        Me.dtdSalidaHasta4.Label_Space = 40
        Me.dtdSalidaHasta4.Location = New System.Drawing.Point(146, 0)
        Me.dtdSalidaHasta4.Max_Value = Nothing
        Me.dtdSalidaHasta4.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdSalidaHasta4.MensajeIncorrectoCustom = Nothing
        Me.dtdSalidaHasta4.Min_Value = Nothing
        Me.dtdSalidaHasta4.MinDate = New Date(CType(0, Long))
        Me.dtdSalidaHasta4.MinimumSize = New System.Drawing.Size(130, 26)
        Me.dtdSalidaHasta4.Name = "dtdSalidaHasta4"
        Me.dtdSalidaHasta4.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdSalidaHasta4.ReadOnly_Data = False
        Me.dtdSalidaHasta4.Size = New System.Drawing.Size(135, 26)
        Me.dtdSalidaHasta4.TabIndex = 2
        Me.dtdSalidaHasta4.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdSalidaHasta4.Validate_on_lost_focus = True
        Me.dtdSalidaHasta4.Value_Data = New Date(2015, 11, 20, 0, 0, 0, 0)
        '
        'pnlSpace9
        '
        Me.pnlSpace9.Auto_Size = False
        Me.pnlSpace9.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace9.ChangeDock = True
        Me.pnlSpace9.Control_Resize = False
        Me.pnlSpace9.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace9.isSpace = True
        Me.pnlSpace9.Location = New System.Drawing.Point(140, 0)
        Me.pnlSpace9.Name = "pnlSpace9"
        Me.pnlSpace9.numRows = 0
        Me.pnlSpace9.Reorder = True
        Me.pnlSpace9.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace9.TabIndex = 1
        '
        'dtdSalidaDesde4
        '
        Me.dtdSalidaDesde4.Allow_Empty = True
        Me.dtdSalidaDesde4.DataField = Nothing
        Me.dtdSalidaDesde4.DataTable = ""
        Me.dtdSalidaDesde4.Default_Value = New Date(2015, 11, 20, 0, 0, 0, 0)
        Me.dtdSalidaDesde4.Descripcion = "o desde"
        Me.dtdSalidaDesde4.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtdSalidaDesde4.FocoEnAgregar = False
        Me.dtdSalidaDesde4.Label_Space = 50
        Me.dtdSalidaDesde4.Location = New System.Drawing.Point(0, 0)
        Me.dtdSalidaDesde4.Max_Value = Nothing
        Me.dtdSalidaDesde4.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdSalidaDesde4.MensajeIncorrectoCustom = Nothing
        Me.dtdSalidaDesde4.Min_Value = Nothing
        Me.dtdSalidaDesde4.MinDate = New Date(CType(0, Long))
        Me.dtdSalidaDesde4.MinimumSize = New System.Drawing.Size(140, 26)
        Me.dtdSalidaDesde4.Name = "dtdSalidaDesde4"
        Me.dtdSalidaDesde4.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdSalidaDesde4.ReadOnly_Data = False
        Me.dtdSalidaDesde4.Size = New System.Drawing.Size(140, 26)
        Me.dtdSalidaDesde4.TabIndex = 0
        Me.dtdSalidaDesde4.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdSalidaDesde4.Validate_on_lost_focus = True
        Me.dtdSalidaDesde4.Value_Data = New Date(2015, 11, 20, 0, 0, 0, 0)
        '
        'pnlSalidaDesde3
        '
        Me.pnlSalidaDesde3.Auto_Size = False
        Me.pnlSalidaDesde3.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSalidaDesde3.ChangeDock = True
        Me.pnlSalidaDesde3.Control_Resize = False
        Me.pnlSalidaDesde3.Controls.Add(Me.dtdSalidaHasta3)
        Me.pnlSalidaDesde3.Controls.Add(Me.pnlSpace8)
        Me.pnlSalidaDesde3.Controls.Add(Me.dtdSalidaDesde3)
        Me.pnlSalidaDesde3.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlSalidaDesde3.isSpace = False
        Me.pnlSalidaDesde3.Location = New System.Drawing.Point(6, 70)
        Me.pnlSalidaDesde3.Name = "pnlSalidaDesde3"
        Me.pnlSalidaDesde3.numRows = 1
        Me.pnlSalidaDesde3.Reorder = True
        Me.pnlSalidaDesde3.Size = New System.Drawing.Size(278, 26)
        Me.pnlSalidaDesde3.TabIndex = 2
        '
        'dtdSalidaHasta3
        '
        Me.dtdSalidaHasta3.Allow_Empty = True
        Me.dtdSalidaHasta3.DataField = Nothing
        Me.dtdSalidaHasta3.DataTable = ""
        Me.dtdSalidaHasta3.Default_Value = New Date(2015, 11, 20, 0, 0, 0, 0)
        Me.dtdSalidaHasta3.Descripcion = "hasta"
        Me.dtdSalidaHasta3.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtdSalidaHasta3.FocoEnAgregar = False
        Me.dtdSalidaHasta3.Label_Space = 40
        Me.dtdSalidaHasta3.Location = New System.Drawing.Point(146, 0)
        Me.dtdSalidaHasta3.Max_Value = Nothing
        Me.dtdSalidaHasta3.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdSalidaHasta3.MensajeIncorrectoCustom = Nothing
        Me.dtdSalidaHasta3.Min_Value = Nothing
        Me.dtdSalidaHasta3.MinDate = New Date(CType(0, Long))
        Me.dtdSalidaHasta3.MinimumSize = New System.Drawing.Size(130, 26)
        Me.dtdSalidaHasta3.Name = "dtdSalidaHasta3"
        Me.dtdSalidaHasta3.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdSalidaHasta3.ReadOnly_Data = False
        Me.dtdSalidaHasta3.Size = New System.Drawing.Size(135, 26)
        Me.dtdSalidaHasta3.TabIndex = 2
        Me.dtdSalidaHasta3.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdSalidaHasta3.Validate_on_lost_focus = True
        Me.dtdSalidaHasta3.Value_Data = New Date(2015, 11, 20, 0, 0, 0, 0)
        '
        'pnlSpace8
        '
        Me.pnlSpace8.Auto_Size = False
        Me.pnlSpace8.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace8.ChangeDock = True
        Me.pnlSpace8.Control_Resize = False
        Me.pnlSpace8.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace8.isSpace = True
        Me.pnlSpace8.Location = New System.Drawing.Point(140, 0)
        Me.pnlSpace8.Name = "pnlSpace8"
        Me.pnlSpace8.numRows = 0
        Me.pnlSpace8.Reorder = True
        Me.pnlSpace8.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace8.TabIndex = 1
        '
        'dtdSalidaDesde3
        '
        Me.dtdSalidaDesde3.Allow_Empty = True
        Me.dtdSalidaDesde3.DataField = Nothing
        Me.dtdSalidaDesde3.DataTable = ""
        Me.dtdSalidaDesde3.Default_Value = New Date(2015, 11, 20, 0, 0, 0, 0)
        Me.dtdSalidaDesde3.Descripcion = "o desde"
        Me.dtdSalidaDesde3.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtdSalidaDesde3.FocoEnAgregar = False
        Me.dtdSalidaDesde3.Label_Space = 50
        Me.dtdSalidaDesde3.Location = New System.Drawing.Point(0, 0)
        Me.dtdSalidaDesde3.Max_Value = Nothing
        Me.dtdSalidaDesde3.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdSalidaDesde3.MensajeIncorrectoCustom = Nothing
        Me.dtdSalidaDesde3.Min_Value = Nothing
        Me.dtdSalidaDesde3.MinDate = New Date(CType(0, Long))
        Me.dtdSalidaDesde3.MinimumSize = New System.Drawing.Size(140, 26)
        Me.dtdSalidaDesde3.Name = "dtdSalidaDesde3"
        Me.dtdSalidaDesde3.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdSalidaDesde3.ReadOnly_Data = False
        Me.dtdSalidaDesde3.Size = New System.Drawing.Size(140, 26)
        Me.dtdSalidaDesde3.TabIndex = 0
        Me.dtdSalidaDesde3.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdSalidaDesde3.Validate_on_lost_focus = True
        Me.dtdSalidaDesde3.Value_Data = New Date(2015, 11, 20, 0, 0, 0, 0)
        '
        'pnlSalidaDesde2
        '
        Me.pnlSalidaDesde2.Auto_Size = False
        Me.pnlSalidaDesde2.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSalidaDesde2.ChangeDock = True
        Me.pnlSalidaDesde2.Control_Resize = False
        Me.pnlSalidaDesde2.Controls.Add(Me.dtdSalidaHasta2)
        Me.pnlSalidaDesde2.Controls.Add(Me.pnlSpace7)
        Me.pnlSalidaDesde2.Controls.Add(Me.dtdSalidaDesde2)
        Me.pnlSalidaDesde2.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlSalidaDesde2.isSpace = False
        Me.pnlSalidaDesde2.Location = New System.Drawing.Point(6, 44)
        Me.pnlSalidaDesde2.Name = "pnlSalidaDesde2"
        Me.pnlSalidaDesde2.numRows = 1
        Me.pnlSalidaDesde2.Reorder = True
        Me.pnlSalidaDesde2.Size = New System.Drawing.Size(278, 26)
        Me.pnlSalidaDesde2.TabIndex = 1
        '
        'dtdSalidaHasta2
        '
        Me.dtdSalidaHasta2.Allow_Empty = True
        Me.dtdSalidaHasta2.DataField = Nothing
        Me.dtdSalidaHasta2.DataTable = ""
        Me.dtdSalidaHasta2.Default_Value = New Date(2015, 11, 20, 0, 0, 0, 0)
        Me.dtdSalidaHasta2.Descripcion = "hasta"
        Me.dtdSalidaHasta2.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtdSalidaHasta2.FocoEnAgregar = False
        Me.dtdSalidaHasta2.Label_Space = 40
        Me.dtdSalidaHasta2.Location = New System.Drawing.Point(146, 0)
        Me.dtdSalidaHasta2.Max_Value = Nothing
        Me.dtdSalidaHasta2.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdSalidaHasta2.MensajeIncorrectoCustom = Nothing
        Me.dtdSalidaHasta2.Min_Value = Nothing
        Me.dtdSalidaHasta2.MinDate = New Date(CType(0, Long))
        Me.dtdSalidaHasta2.MinimumSize = New System.Drawing.Size(130, 26)
        Me.dtdSalidaHasta2.Name = "dtdSalidaHasta2"
        Me.dtdSalidaHasta2.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdSalidaHasta2.ReadOnly_Data = False
        Me.dtdSalidaHasta2.Size = New System.Drawing.Size(135, 26)
        Me.dtdSalidaHasta2.TabIndex = 2
        Me.dtdSalidaHasta2.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdSalidaHasta2.Validate_on_lost_focus = True
        Me.dtdSalidaHasta2.Value_Data = New Date(2015, 11, 20, 0, 0, 0, 0)
        '
        'pnlSpace7
        '
        Me.pnlSpace7.Auto_Size = False
        Me.pnlSpace7.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace7.ChangeDock = True
        Me.pnlSpace7.Control_Resize = False
        Me.pnlSpace7.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace7.isSpace = True
        Me.pnlSpace7.Location = New System.Drawing.Point(140, 0)
        Me.pnlSpace7.Name = "pnlSpace7"
        Me.pnlSpace7.numRows = 0
        Me.pnlSpace7.Reorder = True
        Me.pnlSpace7.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace7.TabIndex = 1
        '
        'dtdSalidaDesde2
        '
        Me.dtdSalidaDesde2.Allow_Empty = True
        Me.dtdSalidaDesde2.DataField = Nothing
        Me.dtdSalidaDesde2.DataTable = ""
        Me.dtdSalidaDesde2.Default_Value = New Date(2015, 11, 20, 0, 0, 0, 0)
        Me.dtdSalidaDesde2.Descripcion = "o desde"
        Me.dtdSalidaDesde2.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtdSalidaDesde2.FocoEnAgregar = False
        Me.dtdSalidaDesde2.Label_Space = 50
        Me.dtdSalidaDesde2.Location = New System.Drawing.Point(0, 0)
        Me.dtdSalidaDesde2.Max_Value = Nothing
        Me.dtdSalidaDesde2.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdSalidaDesde2.MensajeIncorrectoCustom = Nothing
        Me.dtdSalidaDesde2.Min_Value = Nothing
        Me.dtdSalidaDesde2.MinDate = New Date(CType(0, Long))
        Me.dtdSalidaDesde2.MinimumSize = New System.Drawing.Size(140, 26)
        Me.dtdSalidaDesde2.Name = "dtdSalidaDesde2"
        Me.dtdSalidaDesde2.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdSalidaDesde2.ReadOnly_Data = False
        Me.dtdSalidaDesde2.Size = New System.Drawing.Size(140, 26)
        Me.dtdSalidaDesde2.TabIndex = 0
        Me.dtdSalidaDesde2.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdSalidaDesde2.Validate_on_lost_focus = True
        Me.dtdSalidaDesde2.Value_Data = New Date(2015, 11, 20, 0, 0, 0, 0)
        '
        'pnlSalidaDesde
        '
        Me.pnlSalidaDesde.Auto_Size = False
        Me.pnlSalidaDesde.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSalidaDesde.ChangeDock = True
        Me.pnlSalidaDesde.Control_Resize = False
        Me.pnlSalidaDesde.Controls.Add(Me.dtdSalidaHasta)
        Me.pnlSalidaDesde.Controls.Add(Me.pnlSpace6)
        Me.pnlSalidaDesde.Controls.Add(Me.dtdSalidaDesde)
        Me.pnlSalidaDesde.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlSalidaDesde.isSpace = False
        Me.pnlSalidaDesde.Location = New System.Drawing.Point(6, 18)
        Me.pnlSalidaDesde.Name = "pnlSalidaDesde"
        Me.pnlSalidaDesde.numRows = 1
        Me.pnlSalidaDesde.Reorder = True
        Me.pnlSalidaDesde.Size = New System.Drawing.Size(278, 26)
        Me.pnlSalidaDesde.TabIndex = 0
        '
        'dtdSalidaHasta
        '
        Me.dtdSalidaHasta.Allow_Empty = True
        Me.dtdSalidaHasta.DataField = Nothing
        Me.dtdSalidaHasta.DataTable = ""
        Me.dtdSalidaHasta.Default_Value = New Date(2015, 11, 20, 0, 0, 0, 0)
        Me.dtdSalidaHasta.Descripcion = "hasta"
        Me.dtdSalidaHasta.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtdSalidaHasta.FocoEnAgregar = False
        Me.dtdSalidaHasta.Label_Space = 40
        Me.dtdSalidaHasta.Location = New System.Drawing.Point(146, 0)
        Me.dtdSalidaHasta.Max_Value = Nothing
        Me.dtdSalidaHasta.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdSalidaHasta.MensajeIncorrectoCustom = Nothing
        Me.dtdSalidaHasta.Min_Value = Nothing
        Me.dtdSalidaHasta.MinDate = New Date(CType(0, Long))
        Me.dtdSalidaHasta.MinimumSize = New System.Drawing.Size(130, 26)
        Me.dtdSalidaHasta.Name = "dtdSalidaHasta"
        Me.dtdSalidaHasta.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdSalidaHasta.ReadOnly_Data = False
        Me.dtdSalidaHasta.Size = New System.Drawing.Size(135, 26)
        Me.dtdSalidaHasta.TabIndex = 2
        Me.dtdSalidaHasta.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdSalidaHasta.Validate_on_lost_focus = True
        Me.dtdSalidaHasta.Value_Data = New Date(2015, 11, 20, 0, 0, 0, 0)
        '
        'pnlSpace6
        '
        Me.pnlSpace6.Auto_Size = False
        Me.pnlSpace6.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace6.ChangeDock = True
        Me.pnlSpace6.Control_Resize = False
        Me.pnlSpace6.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace6.isSpace = True
        Me.pnlSpace6.Location = New System.Drawing.Point(140, 0)
        Me.pnlSpace6.Name = "pnlSpace6"
        Me.pnlSpace6.numRows = 0
        Me.pnlSpace6.Reorder = True
        Me.pnlSpace6.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace6.TabIndex = 1
        '
        'dtdSalidaDesde
        '
        Me.dtdSalidaDesde.Allow_Empty = True
        Me.dtdSalidaDesde.DataField = Nothing
        Me.dtdSalidaDesde.DataTable = ""
        Me.dtdSalidaDesde.Default_Value = New Date(2015, 11, 20, 0, 0, 0, 0)
        Me.dtdSalidaDesde.Descripcion = "Desde"
        Me.dtdSalidaDesde.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtdSalidaDesde.FocoEnAgregar = False
        Me.dtdSalidaDesde.Label_Space = 50
        Me.dtdSalidaDesde.Location = New System.Drawing.Point(0, 0)
        Me.dtdSalidaDesde.Max_Value = Nothing
        Me.dtdSalidaDesde.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdSalidaDesde.MensajeIncorrectoCustom = Nothing
        Me.dtdSalidaDesde.Min_Value = Nothing
        Me.dtdSalidaDesde.MinDate = New Date(CType(0, Long))
        Me.dtdSalidaDesde.MinimumSize = New System.Drawing.Size(140, 26)
        Me.dtdSalidaDesde.Name = "dtdSalidaDesde"
        Me.dtdSalidaDesde.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdSalidaDesde.ReadOnly_Data = False
        Me.dtdSalidaDesde.Size = New System.Drawing.Size(140, 26)
        Me.dtdSalidaDesde.TabIndex = 0
        Me.dtdSalidaDesde.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdSalidaDesde.Validate_on_lost_focus = True
        Me.dtdSalidaDesde.Value_Data = New Date(2015, 11, 20, 0, 0, 0, 0)
        '
        'pnlRegistroDesde
        '
        Me.pnlRegistroDesde.Auto_Size = False
        Me.pnlRegistroDesde.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlRegistroDesde.ChangeDock = True
        Me.pnlRegistroDesde.Control_Resize = False
        Me.pnlRegistroDesde.Controls.Add(Me.dtdRegistroHasta)
        Me.pnlRegistroDesde.Controls.Add(Me.pnlSpace5)
        Me.pnlRegistroDesde.Controls.Add(Me.dtdRegistroDesde)
        Me.pnlRegistroDesde.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlRegistroDesde.isSpace = False
        Me.pnlRegistroDesde.Location = New System.Drawing.Point(6, 18)
        Me.pnlRegistroDesde.Name = "pnlRegistroDesde"
        Me.pnlRegistroDesde.numRows = 1
        Me.pnlRegistroDesde.Reorder = True
        Me.pnlRegistroDesde.Size = New System.Drawing.Size(604, 26)
        Me.pnlRegistroDesde.TabIndex = 0
        '
        'dtdRegistroHasta
        '
        Me.dtdRegistroHasta.Allow_Empty = True
        Me.dtdRegistroHasta.DataField = Nothing
        Me.dtdRegistroHasta.DataTable = ""
        Me.dtdRegistroHasta.Default_Value = New Date(2015, 11, 20, 0, 0, 0, 0)
        Me.dtdRegistroHasta.Descripcion = "hasta"
        Me.dtdRegistroHasta.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtdRegistroHasta.FocoEnAgregar = False
        Me.dtdRegistroHasta.Label_Space = 60
        Me.dtdRegistroHasta.Location = New System.Drawing.Point(196, 0)
        Me.dtdRegistroHasta.Max_Value = Nothing
        Me.dtdRegistroHasta.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdRegistroHasta.MensajeIncorrectoCustom = Nothing
        Me.dtdRegistroHasta.Min_Value = Nothing
        Me.dtdRegistroHasta.MinDate = New Date(CType(0, Long))
        Me.dtdRegistroHasta.MinimumSize = New System.Drawing.Size(150, 26)
        Me.dtdRegistroHasta.Name = "dtdRegistroHasta"
        Me.dtdRegistroHasta.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdRegistroHasta.ReadOnly_Data = False
        Me.dtdRegistroHasta.Size = New System.Drawing.Size(150, 26)
        Me.dtdRegistroHasta.TabIndex = 2
        Me.dtdRegistroHasta.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdRegistroHasta.Validate_on_lost_focus = True
        Me.dtdRegistroHasta.Value_Data = New Date(2015, 11, 20, 0, 0, 0, 0)
        '
        'pnlSpace5
        '
        Me.pnlSpace5.Auto_Size = False
        Me.pnlSpace5.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace5.ChangeDock = True
        Me.pnlSpace5.Control_Resize = False
        Me.pnlSpace5.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace5.isSpace = True
        Me.pnlSpace5.Location = New System.Drawing.Point(190, 0)
        Me.pnlSpace5.Name = "pnlSpace5"
        Me.pnlSpace5.numRows = 0
        Me.pnlSpace5.Reorder = True
        Me.pnlSpace5.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace5.TabIndex = 1
        '
        'dtdRegistroDesde
        '
        Me.dtdRegistroDesde.Allow_Empty = True
        Me.dtdRegistroDesde.DataField = Nothing
        Me.dtdRegistroDesde.DataTable = ""
        Me.dtdRegistroDesde.Default_Value = New Date(2015, 11, 20, 0, 0, 0, 0)
        Me.dtdRegistroDesde.Descripcion = "Registro desde"
        Me.dtdRegistroDesde.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtdRegistroDesde.FocoEnAgregar = False
        Me.dtdRegistroDesde.Label_Space = 100
        Me.dtdRegistroDesde.Location = New System.Drawing.Point(0, 0)
        Me.dtdRegistroDesde.Max_Value = Nothing
        Me.dtdRegistroDesde.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdRegistroDesde.MensajeIncorrectoCustom = Nothing
        Me.dtdRegistroDesde.Min_Value = Nothing
        Me.dtdRegistroDesde.MinDate = New Date(CType(0, Long))
        Me.dtdRegistroDesde.MinimumSize = New System.Drawing.Size(190, 26)
        Me.dtdRegistroDesde.Name = "dtdRegistroDesde"
        Me.dtdRegistroDesde.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdRegistroDesde.ReadOnly_Data = False
        Me.dtdRegistroDesde.Size = New System.Drawing.Size(190, 26)
        Me.dtdRegistroDesde.TabIndex = 0
        Me.dtdRegistroDesde.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdRegistroDesde.Validate_on_lost_focus = True
        Me.dtdRegistroDesde.Value_Data = New Date(2015, 11, 20, 0, 0, 0, 0)
        '
        'pnlCabeceraGeneral
        '
        Me.pnlCabeceraGeneral.Auto_Size = False
        Me.pnlCabeceraGeneral.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlCabeceraGeneral.ChangeDock = False
        Me.pnlCabeceraGeneral.Control_Resize = False
        Me.pnlCabeceraGeneral.Controls.Add(Me.pnlCabecera)
        Me.pnlCabeceraGeneral.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCabeceraGeneral.isSpace = False
        Me.pnlCabeceraGeneral.Location = New System.Drawing.Point(0, 0)
        Me.pnlCabeceraGeneral.Name = "pnlCabeceraGeneral"
        Me.pnlCabeceraGeneral.numRows = 1
        Me.pnlCabeceraGeneral.Reorder = True
        Me.pnlCabeceraGeneral.Size = New System.Drawing.Size(1246, 26)
        Me.pnlCabeceraGeneral.TabIndex = 0
        '
        'pnlCabecera
        '
        Me.pnlCabecera.Auto_Size = False
        Me.pnlCabecera.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlCabecera.ChangeDock = False
        Me.pnlCabecera.Control_Resize = False
        Me.pnlCabecera.Controls.Add(Me.dtfNombre)
        Me.pnlCabecera.Controls.Add(Me.pnlSpace3)
        Me.pnlCabecera.Controls.Add(Me.dtlUsumodi)
        Me.pnlCabecera.Controls.Add(Me.pnlSpace2)
        Me.pnlCabecera.Controls.Add(Me.pnlSpace1)
        Me.pnlCabecera.Controls.Add(Me.dtfCodigo)
        Me.pnlCabecera.Controls.Add(Me.dtlUltmodi)
        Me.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCabecera.isSpace = False
        Me.pnlCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlCabecera.Name = "pnlCabecera"
        Me.pnlCabecera.numRows = 1
        Me.pnlCabecera.Reorder = True
        Me.pnlCabecera.Size = New System.Drawing.Size(1246, 26)
        Me.pnlCabecera.TabIndex = 0
        '
        'dtfNombre
        '
        Me.dtfNombre.Allow_Empty = True
        Me.dtfNombre.Allow_Negative = True
        Me.dtfNombre.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfNombre.BackColor = System.Drawing.SystemColors.Control
        Me.dtfNombre.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfNombre.DataField = "NOMBRE"
        Me.dtfNombre.DataTable = "NT"
        Me.dtfNombre.Descripcion = "Nombre"
        Me.dtfNombre.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfNombre.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfNombre.FocoEnAgregar = False
        Me.dtfNombre.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfNombre.Image = Nothing
        Me.dtfNombre.Label_Space = 75
        Me.dtfNombre.Length_Data = 32767
        Me.dtfNombre.Location = New System.Drawing.Point(156, 0)
        Me.dtfNombre.Max_Value = 0.0R
        Me.dtfNombre.MensajeIncorrectoCustom = Nothing
        Me.dtfNombre.Name = "dtfNombre"
        Me.dtfNombre.Null_on_Empty = True
        Me.dtfNombre.OpenForm = Nothing
        Me.dtfNombre.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfNombre.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfNombre.ReadOnly_Data = False
        Me.dtfNombre.Show_Button = False
        Me.dtfNombre.Size = New System.Drawing.Size(908, 26)
        Me.dtfNombre.TabIndex = 2
        Me.dtfNombre.Text_Data = ""
        Me.dtfNombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfNombre.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfNombre.TopPadding = 0
        Me.dtfNombre.Upper_Case = False
        Me.dtfNombre.Validate_on_lost_focus = True
        '
        'pnlSpace3
        '
        Me.pnlSpace3.Auto_Size = False
        Me.pnlSpace3.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace3.ChangeDock = True
        Me.pnlSpace3.Control_Resize = False
        Me.pnlSpace3.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSpace3.isSpace = True
        Me.pnlSpace3.Location = New System.Drawing.Point(1064, 0)
        Me.pnlSpace3.Name = "pnlSpace3"
        Me.pnlSpace3.numRows = 0
        Me.pnlSpace3.Reorder = True
        Me.pnlSpace3.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace3.TabIndex = 3
        '
        'dtlUsumodi
        '
        Me.dtlUsumodi.AutoSize = False
        Me.dtlUsumodi.BorderVisible = True
        Me.dtlUsumodi.DataField = "USUARIO"
        Me.dtlUsumodi.DataTable = "NT"
        Me.dtlUsumodi.Descripcion = ""
        Me.dtlUsumodi.Dock = System.Windows.Forms.DockStyle.Right
        Me.dtlUsumodi.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtlUsumodi.Fromat = CustomControls.DataLabel.fotmatType.plain
        Me.dtlUsumodi.Location = New System.Drawing.Point(1070, 0)
        Me.dtlUsumodi.Name = "dtlUsumodi"
        Me.dtlUsumodi.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtlUsumodi.Size = New System.Drawing.Size(38, 26)
        Me.dtlUsumodi.TabIndex = 4
        Me.dtlUsumodi.TextAlignment = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlSpace2
        '
        Me.pnlSpace2.Auto_Size = False
        Me.pnlSpace2.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace2.ChangeDock = True
        Me.pnlSpace2.Control_Resize = False
        Me.pnlSpace2.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSpace2.isSpace = True
        Me.pnlSpace2.Location = New System.Drawing.Point(1108, 0)
        Me.pnlSpace2.Name = "pnlSpace2"
        Me.pnlSpace2.numRows = 0
        Me.pnlSpace2.Reorder = True
        Me.pnlSpace2.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace2.TabIndex = 5
        '
        'pnlSpace1
        '
        Me.pnlSpace1.Auto_Size = False
        Me.pnlSpace1.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace1.ChangeDock = True
        Me.pnlSpace1.Control_Resize = False
        Me.pnlSpace1.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace1.isSpace = True
        Me.pnlSpace1.Location = New System.Drawing.Point(150, 0)
        Me.pnlSpace1.Name = "pnlSpace1"
        Me.pnlSpace1.numRows = 0
        Me.pnlSpace1.Reorder = True
        Me.pnlSpace1.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace1.TabIndex = 1
        '
        'dtfCodigo
        '
        Me.dtfCodigo.Allow_Empty = True
        Me.dtfCodigo.Allow_Negative = True
        Me.dtfCodigo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfCodigo.BackColor = System.Drawing.SystemColors.Control
        Me.dtfCodigo.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfCodigo.DataField = "CODIGO"
        Me.dtfCodigo.DataTable = "NT"
        Me.dtfCodigo.Descripcion = "Codigo"
        Me.dtfCodigo.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfCodigo.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfCodigo.FocoEnAgregar = False
        Me.dtfCodigo.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfCodigo.Image = Nothing
        Me.dtfCodigo.Label_Space = 50
        Me.dtfCodigo.Length_Data = 32767
        Me.dtfCodigo.Location = New System.Drawing.Point(0, 0)
        Me.dtfCodigo.Max_Value = 0.0R
        Me.dtfCodigo.MensajeIncorrectoCustom = Nothing
        Me.dtfCodigo.Name = "dtfCodigo"
        Me.dtfCodigo.Null_on_Empty = True
        Me.dtfCodigo.OpenForm = Nothing
        Me.dtfCodigo.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfCodigo.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfCodigo.ReadOnly_Data = True
        Me.dtfCodigo.Show_Button = False
        Me.dtfCodigo.Size = New System.Drawing.Size(150, 26)
        Me.dtfCodigo.TabIndex = 0
        Me.dtfCodigo.TabStop = False
        Me.dtfCodigo.Text_Data = ""
        Me.dtfCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfCodigo.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfCodigo.TopPadding = 0
        Me.dtfCodigo.Upper_Case = False
        Me.dtfCodigo.Validate_on_lost_focus = True
        '
        'dtlUltmodi
        '
        Me.dtlUltmodi.AutoSize = False
        Me.dtlUltmodi.BorderVisible = True
        Me.dtlUltmodi.DataField = "ULTMODI"
        Me.dtlUltmodi.DataTable = "NT"
        Me.dtlUltmodi.Descripcion = ""
        Me.dtlUltmodi.Dock = System.Windows.Forms.DockStyle.Right
        Me.dtlUltmodi.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtlUltmodi.Fromat = CustomControls.DataLabel.fotmatType.ultmodi
        Me.dtlUltmodi.Location = New System.Drawing.Point(1114, 0)
        Me.dtlUltmodi.Name = "dtlUltmodi"
        Me.dtlUltmodi.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtlUltmodi.Size = New System.Drawing.Size(132, 26)
        Me.dtlUltmodi.TabIndex = 6
        Me.dtlUltmodi.TextAlignment = System.Drawing.ContentAlignment.TopCenter
        '
        'RibbonTab1
        '
        Me.RibbonTab1.AccessibleDescription = "Tarifa"
        Me.RibbonTab1.AccessibleName = "Tarifa"
        Me.RibbonTab1.Name = "RibbonTab1"
        Me.RibbonTab1.Text = "Tarifa"
        Me.RibbonTab1.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'pvpTramos
        '
        Me.pvpTramos.Controls.Add(Me.pnlTramosIzq)
        Me.pvpTramos.Controls.Add(Me.pnlCabeceraTramos)
        Me.pvpTramos.ItemSize = New System.Drawing.SizeF(114.0!, 23.0!)
        Me.pvpTramos.Location = New System.Drawing.Point(129, 5)
        Me.pvpTramos.Name = "pvpTramos"
        Me.pvpTramos.PanelCabezeraContainer = Me.pnlCabeceraTramos
        Me.pvpTramos.Size = New System.Drawing.Size(1224, 500)
        Me.pvpTramos.Text = "Tramos"
        '
        'pnlTramosIzq
        '
        Me.pnlTramosIzq.Auto_Size = False
        Me.pnlTramosIzq.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlTramosIzq.ChangeDock = True
        Me.pnlTramosIzq.Control_Resize = False
        Me.pnlTramosIzq.Controls.Add(Me.dgvTramos)
        Me.pnlTramosIzq.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlTramosIzq.isSpace = False
        Me.pnlTramosIzq.Location = New System.Drawing.Point(0, 26)
        Me.pnlTramosIzq.Name = "pnlTramosIzq"
        Me.pnlTramosIzq.numRows = 0
        Me.pnlTramosIzq.Reorder = True
        Me.pnlTramosIzq.Size = New System.Drawing.Size(611, 474)
        Me.pnlTramosIzq.TabIndex = 2
        '
        'dgvTramos
        '
        Me.dgvTramos.ColRel = Nothing
        Me.dgvTramos.ColSelectFilter = Nothing
        Me.dgvTramos.DataGridType = CustomControls.DataGrid.GridType.Edit
        Me.dgvTramos.DBConnection = Nothing
        Me.dgvTramos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvTramos.EnforceConstrains = True
        Me.dgvTramos.idRel = Nothing
        Me.dgvTramos.Location = New System.Drawing.Point(0, 0)
        Me.dgvTramos.MarcarFilas = False
        '
        'dgvTramos
        '
        Me.dgvTramos.MasterTemplate.AllowColumnChooser = False
        Me.dgvTramos.MasterTemplate.EnableFiltering = True
        Me.dgvTramos.MasterTemplate.EnableGrouping = False
        Me.dgvTramos.MasterTemplate.MultiSelect = True
        Me.dgvTramos.MasterTemplate.SelectionMode = Telerik.WinControls.UI.GridViewSelectionMode.CellSelect
        Me.dgvTramos.Name = "dgvTramos"
        Me.dgvTramos.Size = New System.Drawing.Size(611, 474)
        Me.dgvTramos.TabIndex = 0
        Me.dgvTramos.TablaEdit = Nothing
        Me.dgvTramos.Text = "dgvTramos"
        Me.dgvTramos.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dgvTramos.ThemeName = "TelerikMetroBlue"
        '
        'pnlCabeceraTramos
        '
        Me.pnlCabeceraTramos.Auto_Size = False
        Me.pnlCabeceraTramos.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlCabeceraTramos.ChangeDock = False
        Me.pnlCabeceraTramos.Control_Resize = False
        Me.pnlCabeceraTramos.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCabeceraTramos.isSpace = False
        Me.pnlCabeceraTramos.Location = New System.Drawing.Point(0, 0)
        Me.pnlCabeceraTramos.Name = "pnlCabeceraTramos"
        Me.pnlCabeceraTramos.numRows = 1
        Me.pnlCabeceraTramos.Reorder = True
        Me.pnlCabeceraTramos.Size = New System.Drawing.Size(1224, 26)
        Me.pnlCabeceraTramos.TabIndex = 1
        '
        'pvpComporta
        '
        Me.pvpComporta.Controls.Add(Me.pnlCabeceraComporta)
        Me.pvpComporta.ItemSize = New System.Drawing.SizeF(114.0!, 23.0!)
        Me.pvpComporta.Location = New System.Drawing.Point(129, 5)
        Me.pvpComporta.Name = "pvpComporta"
        Me.pvpComporta.PanelCabezeraContainer = Me.pnlCabeceraComporta
        Me.pvpComporta.Size = New System.Drawing.Size(1224, 500)
        Me.pvpComporta.Text = "Conceptos"
        '
        'pnlCabeceraComporta
        '
        Me.pnlCabeceraComporta.Auto_Size = False
        Me.pnlCabeceraComporta.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlCabeceraComporta.ChangeDock = False
        Me.pnlCabeceraComporta.Control_Resize = False
        Me.pnlCabeceraComporta.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCabeceraComporta.isSpace = False
        Me.pnlCabeceraComporta.Location = New System.Drawing.Point(0, 0)
        Me.pnlCabeceraComporta.Name = "pnlCabeceraComporta"
        Me.pnlCabeceraComporta.numRows = 1
        Me.pnlCabeceraComporta.Reorder = True
        Me.pnlCabeceraComporta.Size = New System.Drawing.Size(1224, 26)
        Me.pnlCabeceraComporta.TabIndex = 2
        '
        'pvpPrecios
        '
        Me.pvpPrecios.Controls.Add(Me.pnlCabeceraPrecios)
        Me.pvpPrecios.ItemSize = New System.Drawing.SizeF(114.0!, 23.0!)
        Me.pvpPrecios.Location = New System.Drawing.Point(129, 5)
        Me.pvpPrecios.Name = "pvpPrecios"
        Me.pvpPrecios.PanelCabezeraContainer = Me.pnlCabeceraPrecios
        Me.pvpPrecios.Size = New System.Drawing.Size(1224, 500)
        Me.pvpPrecios.Text = "Precios por Grupo"
        '
        'pnlCabeceraPrecios
        '
        Me.pnlCabeceraPrecios.Auto_Size = False
        Me.pnlCabeceraPrecios.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlCabeceraPrecios.ChangeDock = False
        Me.pnlCabeceraPrecios.Control_Resize = False
        Me.pnlCabeceraPrecios.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCabeceraPrecios.isSpace = False
        Me.pnlCabeceraPrecios.Location = New System.Drawing.Point(0, 0)
        Me.pnlCabeceraPrecios.Name = "pnlCabeceraPrecios"
        Me.pnlCabeceraPrecios.numRows = 1
        Me.pnlCabeceraPrecios.Reorder = True
        Me.pnlCabeceraPrecios.Size = New System.Drawing.Size(1224, 26)
        Me.pnlCabeceraPrecios.TabIndex = 2
        '
        'pvpDestinos
        '
        Me.pvpDestinos.Controls.Add(Me.pnlCabeceraDestinos)
        Me.pvpDestinos.ItemSize = New System.Drawing.SizeF(114.0!, 23.0!)
        Me.pvpDestinos.Location = New System.Drawing.Point(129, 5)
        Me.pvpDestinos.Name = "pvpDestinos"
        Me.pvpDestinos.PanelCabezeraContainer = Me.pnlCabeceraDestinos
        Me.pvpDestinos.Size = New System.Drawing.Size(1224, 500)
        Me.pvpDestinos.Text = "Destinos"
        '
        'pnlCabeceraDestinos
        '
        Me.pnlCabeceraDestinos.Auto_Size = False
        Me.pnlCabeceraDestinos.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlCabeceraDestinos.ChangeDock = False
        Me.pnlCabeceraDestinos.Control_Resize = False
        Me.pnlCabeceraDestinos.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCabeceraDestinos.isSpace = False
        Me.pnlCabeceraDestinos.Location = New System.Drawing.Point(0, 0)
        Me.pnlCabeceraDestinos.Name = "pnlCabeceraDestinos"
        Me.pnlCabeceraDestinos.numRows = 1
        Me.pnlCabeceraDestinos.Reorder = True
        Me.pnlCabeceraDestinos.Size = New System.Drawing.Size(1224, 26)
        Me.pnlCabeceraDestinos.TabIndex = 2
        '
        'pvpFijos
        '
        Me.pvpFijos.Controls.Add(Me.pnlCabeceraFijos)
        Me.pvpFijos.ItemSize = New System.Drawing.SizeF(114.0!, 23.0!)
        Me.pvpFijos.Location = New System.Drawing.Point(129, 5)
        Me.pvpFijos.Name = "pvpFijos"
        Me.pvpFijos.PanelCabezeraContainer = Me.pnlCabeceraFijos
        Me.pvpFijos.Size = New System.Drawing.Size(1224, 500)
        Me.pvpFijos.Text = "Fijos por Grupo"
        '
        'pnlCabeceraFijos
        '
        Me.pnlCabeceraFijos.Auto_Size = False
        Me.pnlCabeceraFijos.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlCabeceraFijos.ChangeDock = False
        Me.pnlCabeceraFijos.Control_Resize = False
        Me.pnlCabeceraFijos.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCabeceraFijos.isSpace = False
        Me.pnlCabeceraFijos.Location = New System.Drawing.Point(0, 0)
        Me.pnlCabeceraFijos.Name = "pnlCabeceraFijos"
        Me.pnlCabeceraFijos.numRows = 1
        Me.pnlCabeceraFijos.Reorder = True
        Me.pnlCabeceraFijos.Size = New System.Drawing.Size(1224, 26)
        Me.pnlCabeceraFijos.TabIndex = 3
        '
        'Tarifas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1358, 695)
        Me.Name = "Tarifas"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Tarifas"
        CType(Me.pnlBlock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pvwBase, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pvwBase.ResumeLayout(False)
        CType(Me.stbBase, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pvpGeneral.ResumeLayout(False)
        CType(Me.pnlGeneralDer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlGeneralDer.ResumeLayout(False)
        CType(Me.gbxChecks, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxChecks.ResumeLayout(False)
        CType(Me.pnlChecksCol2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlChecksCol2.ResumeLayout(False)
        Me.pnlChecksCol2.PerformLayout()
        CType(Me.DataCheck26, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataCheck24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataCheck22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataCheck20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataCheck19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataCheck16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataCheck15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataCheck14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataCheck13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataCheck12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataCheck11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataCheck10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataCheck8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlChecksCol1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlChecksCol1.ResumeLayout(False)
        Me.pnlChecksCol1.PerformLayout()
        CType(Me.DataCheck25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataCheck23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataCheck21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataCheck18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataCheck17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataCheck7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataCheck6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataCheck5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataCheck4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataCheck3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataCheck9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataCheck2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataCheck1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlGeneralIzq, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlGeneralIzq.ResumeLayout(False)
        CType(Me.pnlSapce25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.rdgCobrosDefecto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rdgCobrosDefecto.ResumeLayout(False)
        Me.rdgCobrosDefecto.PerformLayout()
        CType(Me.DataRadio2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataRadio1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataCheck27, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlDtosPrioridad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDtosPrioridad.ResumeLayout(False)
        Me.pnlDtosPrioridad.PerformLayout()
        CType(Me.pnlSapce23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSapce22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSapce21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPorcenDto2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSapce20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPorcenDto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSpace19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbxFechasValidez, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxFechasValidez.ResumeLayout(False)
        CType(Me.gbxVapidezPreaviso, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxVapidezPreaviso.ResumeLayout(False)
        CType(Me.pnlSpace18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSpace17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlFechasSalidaRetorno, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFechasSalidaRetorno.ResumeLayout(False)
        CType(Me.gbxRetorno, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxRetorno.ResumeLayout(False)
        CType(Me.pnlRetornoDesde5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlRetornoDesde5.ResumeLayout(False)
        CType(Me.pnlSpace15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlRetornoDesde4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlRetornoDesde4.ResumeLayout(False)
        CType(Me.pnlSpace14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlRetornoDesde3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlRetornoDesde3.ResumeLayout(False)
        CType(Me.pnlSpace13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlRetornoDesde2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlRetornoDesde2.ResumeLayout(False)
        CType(Me.pnlSpace12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlRetornoDesde, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlRetornoDesde.ResumeLayout(False)
        CType(Me.pnlSpace11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSpace16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbxSalida, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxSalida.ResumeLayout(False)
        CType(Me.pnlSalidaDesde5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSalidaDesde5.ResumeLayout(False)
        CType(Me.pnlSpace10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSalidaDesde4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSalidaDesde4.ResumeLayout(False)
        CType(Me.pnlSpace9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSalidaDesde3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSalidaDesde3.ResumeLayout(False)
        CType(Me.pnlSpace8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSalidaDesde2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSalidaDesde2.ResumeLayout(False)
        CType(Me.pnlSpace7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSalidaDesde, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSalidaDesde.ResumeLayout(False)
        CType(Me.pnlSpace6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlRegistroDesde, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlRegistroDesde.ResumeLayout(False)
        CType(Me.pnlSpace5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlCabeceraGeneral, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCabeceraGeneral.ResumeLayout(False)
        CType(Me.pnlCabecera, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCabecera.ResumeLayout(False)
        CType(Me.pnlSpace3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtlUsumodi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSpace2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSpace1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtlUltmodi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pvpTramos.ResumeLayout(False)
        CType(Me.pnlTramosIzq, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTramosIzq.ResumeLayout(False)
        CType(Me.dgvTramos.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvTramos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlCabeceraTramos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pvpComporta.ResumeLayout(False)
        CType(Me.pnlCabeceraComporta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pvpPrecios.ResumeLayout(False)
        CType(Me.pnlCabeceraPrecios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pvpDestinos.ResumeLayout(False)
        CType(Me.pnlCabeceraDestinos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pvpFijos.ResumeLayout(False)
        CType(Me.pnlCabeceraFijos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pvpGeneral As CustomControls.PageViewPage
    Friend WithEvents pnlCabeceraGeneral As CustomControls.Panel
    Friend WithEvents pnlCabecera As CustomControls.Panel
    Friend WithEvents dtfCodigo As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace1 As CustomControls.Panel
    Friend WithEvents dtfNombre As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace3 As CustomControls.Panel
    Friend WithEvents dtlUsumodi As CustomControls.DataLabel
    Friend WithEvents pnlSpace2 As CustomControls.Panel
    Friend WithEvents dtlUltmodi As CustomControls.DataLabel
    Friend WithEvents pnlGeneralIzq As CustomControls.Panel
    Friend WithEvents pnlGeneralDer As CustomControls.Panel
    Friend WithEvents gbxFechasValidez As CustomControls.GroupBox
    Friend WithEvents pnlRegistroDesde As CustomControls.Panel
    Friend WithEvents dtdRegistroDesde As CustomControls.DataDateLabel
    Friend WithEvents dtdRegistroHasta As CustomControls.DataDateLabel
    Friend WithEvents pnlSpace5 As CustomControls.Panel
    Friend WithEvents pnlFechasSalidaRetorno As CustomControls.Panel
    Friend WithEvents gbxRetorno As CustomControls.GroupBox
    Friend WithEvents pnlRetornoDesde5 As CustomControls.Panel
    Friend WithEvents dtdRetornoHasta5 As CustomControls.DataDateLabel
    Friend WithEvents pnlSpace15 As CustomControls.Panel
    Friend WithEvents dtdRetornoDesde5 As CustomControls.DataDateLabel
    Friend WithEvents pnlRetornoDesde4 As CustomControls.Panel
    Friend WithEvents dtdRetornoHasta4 As CustomControls.DataDateLabel
    Friend WithEvents pnlSpace14 As CustomControls.Panel
    Friend WithEvents dtdRetornoDesde4 As CustomControls.DataDateLabel
    Friend WithEvents pnlRetornoDesde3 As CustomControls.Panel
    Friend WithEvents dtdRetornoHasta3 As CustomControls.DataDateLabel
    Friend WithEvents pnlSpace13 As CustomControls.Panel
    Friend WithEvents dtdRetornoDesde3 As CustomControls.DataDateLabel
    Friend WithEvents pnlRetornoDesde2 As CustomControls.Panel
    Friend WithEvents dtdRetornoHasta2 As CustomControls.DataDateLabel
    Friend WithEvents pnlSpace12 As CustomControls.Panel
    Friend WithEvents dtdRetornoDesde2 As CustomControls.DataDateLabel
    Friend WithEvents pnlRetornoDesde As CustomControls.Panel
    Friend WithEvents dtdRetornoHasta As CustomControls.DataDateLabel
    Friend WithEvents pnlSpace11 As CustomControls.Panel
    Friend WithEvents dtdRetornoDesde As CustomControls.DataDateLabel
    Friend WithEvents pnlSpace16 As CustomControls.Panel
    Friend WithEvents gbxSalida As CustomControls.GroupBox
    Friend WithEvents pnlSalidaDesde5 As CustomControls.Panel
    Friend WithEvents dtdSalidaHasta5 As CustomControls.DataDateLabel
    Friend WithEvents pnlSpace10 As CustomControls.Panel
    Friend WithEvents dtdSalidaDesde5 As CustomControls.DataDateLabel
    Friend WithEvents pnlSalidaDesde4 As CustomControls.Panel
    Friend WithEvents dtdSalidaHasta4 As CustomControls.DataDateLabel
    Friend WithEvents pnlSpace9 As CustomControls.Panel
    Friend WithEvents dtdSalidaDesde4 As CustomControls.DataDateLabel
    Friend WithEvents pnlSalidaDesde3 As CustomControls.Panel
    Friend WithEvents dtdSalidaHasta3 As CustomControls.DataDateLabel
    Friend WithEvents pnlSpace8 As CustomControls.Panel
    Friend WithEvents dtdSalidaDesde3 As CustomControls.DataDateLabel
    Friend WithEvents pnlSalidaDesde2 As CustomControls.Panel
    Friend WithEvents dtdSalidaHasta2 As CustomControls.DataDateLabel
    Friend WithEvents pnlSpace7 As CustomControls.Panel
    Friend WithEvents dtdSalidaDesde2 As CustomControls.DataDateLabel
    Friend WithEvents pnlSalidaDesde As CustomControls.Panel
    Friend WithEvents dtdSalidaHasta As CustomControls.DataDateLabel
    Friend WithEvents pnlSpace6 As CustomControls.Panel
    Friend WithEvents dtdSalidaDesde As CustomControls.DataDateLabel
    Friend WithEvents gbxVapidezPreaviso As CustomControls.GroupBox
    Friend WithEvents dtfPreaviso As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace18 As CustomControls.Panel
    Friend WithEvents dtfValidezMaximo As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace17 As CustomControls.Panel
    Friend WithEvents dtfValidezMinimo As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace19 As CustomControls.Panel
    Friend WithEvents gbxChecks As CustomControls.GroupBox
    Friend WithEvents pnlChecksCol2 As CustomControls.Panel
    Friend WithEvents DataCheck24 As CustomControls.DataCheck
    Friend WithEvents DataCheck22 As CustomControls.DataCheck
    Friend WithEvents DataCheck20 As CustomControls.DataCheck
    Friend WithEvents DataCheck19 As CustomControls.DataCheck
    Friend WithEvents DataCheck16 As CustomControls.DataCheck
    Friend WithEvents DataCheck15 As CustomControls.DataCheck
    Friend WithEvents DataCheck14 As CustomControls.DataCheck
    Friend WithEvents DataCheck13 As CustomControls.DataCheck
    Friend WithEvents DataCheck12 As CustomControls.DataCheck
    Friend WithEvents DataCheck11 As CustomControls.DataCheck
    Friend WithEvents DataCheck10 As CustomControls.DataCheck
    Friend WithEvents DataCheck8 As CustomControls.DataCheck
    Friend WithEvents pnlChecksCol1 As CustomControls.Panel
    Friend WithEvents DataCheck23 As CustomControls.DataCheck
    Friend WithEvents DataCheck21 As CustomControls.DataCheck
    Friend WithEvents DataCheck18 As CustomControls.DataCheck
    Friend WithEvents DataCheck17 As CustomControls.DataCheck
    Friend WithEvents DataCheck7 As CustomControls.DataCheck
    Friend WithEvents DataCheck6 As CustomControls.DataCheck
    Friend WithEvents DataCheck5 As CustomControls.DataCheck
    Friend WithEvents DataCheck4 As CustomControls.DataCheck
    Friend WithEvents DataCheck3 As CustomControls.DataCheck
    Friend WithEvents DataCheck9 As CustomControls.DataCheck
    Friend WithEvents DataCheck2 As CustomControls.DataCheck
    Friend WithEvents DataCheck1 As CustomControls.DataCheck
    Friend WithEvents DataCheck26 As CustomControls.DataCheck
    Friend WithEvents DataCheck25 As CustomControls.DataCheck
    Friend WithEvents GroupBox1 As CustomControls.GroupBox
    Friend WithEvents rdgCobrosDefecto As CustomControls.RadioGroup
    Friend WithEvents DataRadio2 As CustomControls.DataRadio
    Friend WithEvents DataRadio1 As CustomControls.DataRadio
    Friend WithEvents DataCheck27 As CustomControls.DataCheck
    Friend WithEvents DualDatafieldLabel1 As CustomControls.DualDatafieldLabel
    Friend WithEvents pnlDtosPrioridad As CustomControls.Panel
    Friend WithEvents DatafieldLabel5 As CustomControls.DatafieldLabel
    Friend WithEvents pnlSapce23 As CustomControls.Panel
    Friend WithEvents DatafieldLabel4 As CustomControls.DatafieldLabel
    Friend WithEvents pnlSapce22 As CustomControls.Panel
    Friend WithEvents DatafieldLabel3 As CustomControls.DatafieldLabel
    Friend WithEvents pnlSapce21 As CustomControls.Panel
    Friend WithEvents lblPorcenDto2 As CustomControls.Label
    Friend WithEvents DatafieldLabel2 As CustomControls.DatafieldLabel
    Friend WithEvents pnlSapce20 As CustomControls.Panel
    Friend WithEvents lblPorcenDto As CustomControls.Label
    Friend WithEvents DatafieldLabel1 As CustomControls.DatafieldLabel
    Friend WithEvents dtaCondiciones As CustomControls.DataAreaLabel
    Friend WithEvents dtaObservaciones As CustomControls.DataAreaLabel
    Friend WithEvents RibbonTab1 As Telerik.WinControls.UI.RibbonTab
    Friend WithEvents DualDatafieldLabel4 As CustomControls.DualDatafieldLabel
    Friend WithEvents DualDatafieldLabel3 As CustomControls.DualDatafieldLabel
    Friend WithEvents DualDatafieldLabel2 As CustomControls.DualDatafieldLabel
    Friend WithEvents pnlSapce25 As CustomControls.Panel
    Friend WithEvents pvpTramos As CustomControls.PageViewPage
    Friend WithEvents pnlCabeceraTramos As CustomControls.Panel
    Friend WithEvents pvpComporta As CustomControls.PageViewPage
    Friend WithEvents pvpPrecios As CustomControls.PageViewPage
    Friend WithEvents pvpDestinos As CustomControls.PageViewPage
    Friend WithEvents pnlCabeceraComporta As CustomControls.Panel
    Friend WithEvents pnlCabeceraPrecios As CustomControls.Panel
    Friend WithEvents pnlCabeceraDestinos As CustomControls.Panel
    Friend WithEvents pvpFijos As CustomControls.PageViewPage
    Friend WithEvents pnlCabeceraFijos As CustomControls.Panel
    Friend WithEvents pnlTramosIzq As CustomControls.Panel
    Friend WithEvents dgvTramos As Karve.frm.Tarifas.GridTramos
End Class
