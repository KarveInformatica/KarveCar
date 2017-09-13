<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Reservas
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
        Dim Connection30 As ASADB.Connection = New ASADB.Connection()
        Dim Connection31 As ASADB.Connection = New ASADB.Connection()
        Dim Connection32 As ASADB.Connection = New ASADB.Connection()
        Dim Connection33 As ASADB.Connection = New ASADB.Connection()
        Dim Connection34 As ASADB.Connection = New ASADB.Connection()
        Dim Connection35 As ASADB.Connection = New ASADB.Connection()
        Dim Connection36 As ASADB.Connection = New ASADB.Connection()
        Dim Connection37 As ASADB.Connection = New ASADB.Connection()
        Dim Connection38 As ASADB.Connection = New ASADB.Connection()
        Dim Connection39 As ASADB.Connection = New ASADB.Connection()
        Dim Connection40 As ASADB.Connection = New ASADB.Connection()
        Dim Connection41 As ASADB.Connection = New ASADB.Connection()
        Dim Connection42 As ASADB.Connection = New ASADB.Connection()
        Me.pvpGeneral = New CustomControls.PageViewPage()
        Me.pnlObs = New CustomControls.Panel()
        Me.dtaObs = New CustomControls.DataAreaLabel()
        Me.pnlPpal = New CustomControls.Panel()
        Me.pnlGenDer = New CustomControls.Panel()
        Me.gbxCotiza = New CustomControls.GroupBox()
        Me.pnlCotiza = New CustomControls.Panel()
        Me.dgvLiRes = New Karve.frm.RentACar.GridLiRes()
        Me.pnlGenIzq = New CustomControls.Panel()
        Me.gbxParamCotiza = New CustomControls.GroupBox()
        Me.dtfSubComisio = New CustomControls.DualDatafieldLabel()
        Me.dtfComisio = New CustomControls.DualDatafieldLabel()
        Me.dtfPreferencia = New CustomControls.DatafieldLabel()
        Me.dtfGrupo = New CustomControls.DualDatafieldLabel()
        Me.dtfTarifa = New CustomControls.DualDatafieldLabel()
        Me.Space4 = New CustomControls.Panel()
        Me.gbxCliente = New CustomControls.GroupBox()
        Me.dtfConductor = New CustomControls.DualDataFieldEditableLabel()
        Me.Panel2 = New CustomControls.Panel()
        Me.pnlObsCli = New CustomControls.Panel()
        Me.dtaObsCli = New CustomControls.DataArea()
        Me.pnlObsCliIzq = New CustomControls.Panel()
        Me.dtfCliente = New CustomControls.DualDataFieldEditableLabel()
        Me.Space2 = New CustomControls.Panel()
        Me.gbxLocaliza = New CustomControls.GroupBox()
        Me.pnlReferencia = New CustomControls.Panel()
        Me.dtfReferencia = New CustomControls.DatafieldLabel()
        Me.pnlVuelo = New CustomControls.Panel()
        Me.dtfVuelo = New CustomControls.DatafieldLabel()
        Me.pnlLocaliza = New CustomControls.Panel()
        Me.dtfLocaliza = New CustomControls.DatafieldLabel()
        Me.pnlCabeceraGen = New CustomControls.Panel()
        Me.pnlCabecera = New CustomControls.Panel()
        Me.pnlPeriodo = New CustomControls.Panel()
        Me.pnlDatosPrevistos = New CustomControls.Panel()
        Me.dtfLugarRecogida = New CustomControls.DatafieldLabel()
        Me.pnlSpace16 = New CustomControls.Panel()
        Me.pnlSpace15 = New CustomControls.Panel()
        Me.dtfOfiLlegada = New CustomControls.DualDatafieldLabel()
        Me.pnlSpace14 = New CustomControls.Panel()
        Me.dttHPrevista = New CustomControls.DataTime()
        Me.pnlSpace13 = New CustomControls.Panel()
        Me.dtdFPrevista = New CustomControls.DataDateLabel()
        Me.pnlSpace12 = New CustomControls.Panel()
        Me.pnlDatosSalida = New CustomControls.Panel()
        Me.dtfLugarEntrega = New CustomControls.DatafieldLabel()
        Me.pnlSpace10 = New CustomControls.Panel()
        Me.pnlSpace19 = New CustomControls.Panel()
        Me.pnlSpace9 = New CustomControls.Panel()
        Me.dtfOfiSalida = New CustomControls.DualDatafieldLabel()
        Me.pnlSpace8 = New CustomControls.Panel()
        Me.dttHSalida = New CustomControls.DataTime()
        Me.pnlSpace7 = New CustomControls.Panel()
        Me.dtdFSalida = New CustomControls.DataDateLabel()
        Me.pnlSpace6 = New CustomControls.Panel()
        Me.dtfDiasPrevistos = New CustomControls.DatafieldLabel()
        Me.pnlCodigo = New CustomControls.Panel()
        Me.dtdFecha = New CustomControls.DataDateLabel()
        Me.pnlSpace5 = New CustomControls.Panel()
        Me.dttHora = New CustomControls.DataTime()
        Me.dtfRSC = New CustomControls.DatafieldLabel()
        Me.Space1 = New CustomControls.Panel()
        Me.pnlEO = New CustomControls.Panel()
        Me.dtfEmpresaOficina = New CustomControls.EmpresaOficina()
        Me.Space = New CustomControls.Panel()
        Me.dtfCodigo = New CustomControls.DatafieldLabel()
        Me.pnlBottomGen = New CustomControls.Panel()
        Me.dtlUltmodi = New CustomControls.DataLabel()
        Me.dtlUsumodi = New CustomControls.DataLabel()
        Me.pvpOtros = New CustomControls.PageViewPage()
        Me.pnlCabeceraOtros = New CustomControls.Panel()
        Me.pvpCond = New CustomControls.PageViewPage()
        Me.pnlCabeceraCond = New CustomControls.Panel()
        Me.pnlConductoresDer = New CustomControls.Panel()
        Me.gbxConductoresAdicionales = New CustomControls.GroupBox()
        Me.gbxOtroCond3 = New CustomControls.GroupBox()
        Me.pnlOtroPermismo3 = New CustomControls.Panel()
        Me.dtdOtroNac3 = New CustomControls.DataDateLabel()
        Me.dtfOtroPer3 = New CustomControls.DatafieldLabel()
        Me.pnlOtroFPermismo3 = New CustomControls.Panel()
        Me.dtdOtroCadu3 = New CustomControls.DataDateLabel()
        Me.dtdOtroExpe3 = New CustomControls.DataDateLabel()
        Me.dtfOtroCond3 = New CustomControls.DualDatafieldLabel()
        Me.gbxOtroCond2 = New CustomControls.GroupBox()
        Me.pnlOtroPermismo2 = New CustomControls.Panel()
        Me.dtdOtroNac2 = New CustomControls.DataDateLabel()
        Me.dtfOtroPer2 = New CustomControls.DatafieldLabel()
        Me.pnlOtroFPermismo2 = New CustomControls.Panel()
        Me.dtdOtroCadu2 = New CustomControls.DataDateLabel()
        Me.dtdOtroExpe2 = New CustomControls.DataDateLabel()
        Me.dtfOtroCond2 = New CustomControls.DualDatafieldLabel()
        Me.gbxOtroCond = New CustomControls.GroupBox()
        Me.pnlOtroPermismo = New CustomControls.Panel()
        Me.dtdOtroNac = New CustomControls.DataDateLabel()
        Me.dtfOtroPer = New CustomControls.DatafieldLabel()
        Me.pnlOtroFPermismo = New CustomControls.Panel()
        Me.dtdOtroCadu = New CustomControls.DataDateLabel()
        Me.dtdOtroExpe = New CustomControls.DataDateLabel()
        Me.dtfOtroCond = New CustomControls.DualDatafieldLabel()
        Me.pnlConductoresIzq = New CustomControls.Panel()
        Me.gbxConductor = New CustomControls.GroupBox()
        Me.pnlTarjeta = New CustomControls.Panel()
        Me.dtfTarNum = New CustomControls.DatafieldLabel()
        Me.pnlSpace31 = New CustomControls.Panel()
        Me.lblTarCadu = New CustomControls.Label()
        Me.pnlSpace30 = New CustomControls.Panel()
        Me.mdfTarcadu = New CustomControls.MaskedDataField()
        Me.dtfTarjetaCond = New CustomControls.DualDatafieldLabel()
        Me.dtfEmailCond = New CustomControls.DatafieldLabel()
        Me.pnlPermiso = New CustomControls.Panel()
        Me.pnlPermisoInf = New CustomControls.Panel()
        Me.dtfLuExpe = New CustomControls.DatafieldLabel()
        Me.pnlSpace29 = New CustomControls.Panel()
        Me.dtdFeExpe = New CustomControls.DataDateLabel()
        Me.pnlPermisoSup = New CustomControls.Panel()
        Me.dtfPermiso = New CustomControls.DatafieldLabel()
        Me.pnlSpace28 = New CustomControls.Panel()
        Me.dtfClase = New CustomControls.DatafieldLabel()
        Me.pnlLuNace = New CustomControls.Panel()
        Me.dtfLuNace = New CustomControls.DatafieldLabel()
        Me.pnlSpace27 = New CustomControls.Panel()
        Me.dtdFechaNac = New CustomControls.DataDateLabel()
        Me.pnlNifTelf = New CustomControls.Panel()
        Me.dtfNIFCond = New CustomControls.DatafieldLabel()
        Me.pnlSpace25 = New CustomControls.Panel()
        Me.dtfTelfCond = New CustomControls.DatafieldLabel()
        Me.pnlSpace24 = New CustomControls.Panel()
        Me.dtfTelfCond2 = New CustomControls.Datafield()
        Me.dtdDirCond = New CustomControls.DataDir()
        Me.dtfNombreCond = New CustomControls.DatafieldLabel()
        Me.pnlConductor = New CustomControls.Panel()
        Me.dtfConductorDetalles = New CustomControls.DualDatafieldLabel()
        Me.pnlSpace23 = New CustomControls.Panel()
        Me.btnCargarCond = New CustomControls.Button()
        Me.pnlSpace26 = New CustomControls.Panel()
        Me.btnGuardar = New CustomControls.Button()
        CType(Me.pnlBlock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pvwBase, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pvwBase.SuspendLayout()
        CType(Me.stbBase, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pvpGeneral.SuspendLayout()
        CType(Me.pnlObs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlObs.SuspendLayout()
        CType(Me.pnlPpal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPpal.SuspendLayout()
        CType(Me.pnlGenDer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlGenDer.SuspendLayout()
        CType(Me.gbxCotiza, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxCotiza.SuspendLayout()
        CType(Me.pnlCotiza, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCotiza.SuspendLayout()
        CType(Me.dgvLiRes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvLiRes.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlGenIzq, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlGenIzq.SuspendLayout()
        CType(Me.gbxParamCotiza, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxParamCotiza.SuspendLayout()
        CType(Me.Space4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbxCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxCliente.SuspendLayout()
        CType(Me.Panel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlObsCli, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlObsCli.SuspendLayout()
        CType(Me.pnlObsCliIzq, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Space2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbxLocaliza, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxLocaliza.SuspendLayout()
        CType(Me.pnlReferencia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlReferencia.SuspendLayout()
        CType(Me.pnlVuelo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlVuelo.SuspendLayout()
        CType(Me.pnlLocaliza, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlLocaliza.SuspendLayout()
        CType(Me.pnlCabeceraGen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCabeceraGen.SuspendLayout()
        CType(Me.pnlCabecera, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCabecera.SuspendLayout()
        CType(Me.pnlPeriodo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPeriodo.SuspendLayout()
        CType(Me.pnlDatosPrevistos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDatosPrevistos.SuspendLayout()
        CType(Me.pnlSpace16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSpace15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSpace14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSpace13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSpace12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlDatosSalida, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDatosSalida.SuspendLayout()
        CType(Me.pnlSpace10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSpace19, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSpace19.SuspendLayout()
        CType(Me.pnlSpace9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSpace8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSpace7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSpace6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlCodigo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCodigo.SuspendLayout()
        CType(Me.pnlSpace5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Space1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlEO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEO.SuspendLayout()
        CType(Me.Space, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlBottomGen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBottomGen.SuspendLayout()
        CType(Me.dtlUltmodi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtlUsumodi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pvpOtros.SuspendLayout()
        CType(Me.pnlCabeceraOtros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pvpCond.SuspendLayout()
        CType(Me.pnlCabeceraCond, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlConductoresDer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlConductoresDer.SuspendLayout()
        CType(Me.gbxConductoresAdicionales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxConductoresAdicionales.SuspendLayout()
        CType(Me.gbxOtroCond3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxOtroCond3.SuspendLayout()
        CType(Me.pnlOtroPermismo3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlOtroPermismo3.SuspendLayout()
        CType(Me.pnlOtroFPermismo3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlOtroFPermismo3.SuspendLayout()
        CType(Me.gbxOtroCond2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxOtroCond2.SuspendLayout()
        CType(Me.pnlOtroPermismo2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlOtroPermismo2.SuspendLayout()
        CType(Me.pnlOtroFPermismo2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlOtroFPermismo2.SuspendLayout()
        CType(Me.gbxOtroCond, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxOtroCond.SuspendLayout()
        CType(Me.pnlOtroPermismo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlOtroPermismo.SuspendLayout()
        CType(Me.pnlOtroFPermismo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlOtroFPermismo.SuspendLayout()
        CType(Me.pnlConductoresIzq, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlConductoresIzq.SuspendLayout()
        CType(Me.gbxConductor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxConductor.SuspendLayout()
        CType(Me.pnlTarjeta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTarjeta.SuspendLayout()
        CType(Me.pnlSpace31, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTarCadu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSpace30, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlPermiso, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPermiso.SuspendLayout()
        CType(Me.pnlPermisoInf, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPermisoInf.SuspendLayout()
        CType(Me.pnlSpace29, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlPermisoSup, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPermisoSup.SuspendLayout()
        CType(Me.pnlSpace28, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlLuNace, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlLuNace.SuspendLayout()
        CType(Me.pnlSpace27, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlNifTelf, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlNifTelf.SuspendLayout()
        CType(Me.pnlSpace25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSpace24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlConductor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlConductor.SuspendLayout()
        CType(Me.pnlSpace23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnCargarCond, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSpace26, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnGuardar, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pvwBase.Controls.Add(Me.pvpOtros)
        Me.pvwBase.Controls.Add(Me.pvpCond)
        Me.pvwBase.DefaultPage = Me.pvpGeneral
        Me.pvwBase.PanelCabezera = Me.pnlCabecera
        Me.pvwBase.SelectedPage = Me.pvpCond
        Me.pvwBase.Size = New System.Drawing.Size(1272, 569)
        '
        'stbBase
        '
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
        Me.pvpGeneral.Controls.Add(Me.pnlObs)
        Me.pvpGeneral.Controls.Add(Me.pnlPpal)
        Me.pvpGeneral.Controls.Add(Me.pnlCabeceraGen)
        Me.pvpGeneral.Controls.Add(Me.pnlBottomGen)
        Me.pvpGeneral.ItemSize = New System.Drawing.SizeF(83.0!, 23.0!)
        Me.pvpGeneral.Location = New System.Drawing.Point(129, 5)
        Me.pvpGeneral.Name = "pvpGeneral"
        Me.pvpGeneral.PanelCabezeraContainer = Me.pnlCabeceraGen
        Me.pvpGeneral.Size = New System.Drawing.Size(1138, 559)
        Me.pvpGeneral.Text = "General"
        '
        'pnlObs
        '
        Me.pnlObs.Auto_Size = False
        Me.pnlObs.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlObs.ChangeDock = False
        Me.pnlObs.Control_Resize = False
        Me.pnlObs.Controls.Add(Me.dtaObs)
        Me.pnlObs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlObs.isSpace = False
        Me.pnlObs.Location = New System.Drawing.Point(0, 457)
        Me.pnlObs.MinimumSize = New System.Drawing.Size(0, 80)
        Me.pnlObs.Name = "pnlObs"
        Me.pnlObs.numRows = 0
        Me.pnlObs.Reorder = True
        '
        '
        '
        Me.pnlObs.RootElement.MinSize = New System.Drawing.Size(0, 80)
        Me.pnlObs.Size = New System.Drawing.Size(1138, 80)
        Me.pnlObs.TabIndex = 11
        '
        'dtaObs
        '
        Me.dtaObs.Allow_Empty = True
        Me.dtaObs.Allow_Negative = True
        Me.dtaObs.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtaObs.BackColor = System.Drawing.SystemColors.Control
        Me.dtaObs.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtaObs.DataField = "OBS1_RES2"
        Me.dtaObs.DataTable = "R2"
        Me.dtaObs.Descripcion = "Observaciones"
        Me.dtaObs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtaObs.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtaObs.FocoEnAgregar = False
        Me.dtaObs.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtaObs.Length_Data = 32767
        Me.dtaObs.Location = New System.Drawing.Point(0, 0)
        Me.dtaObs.Max_Value = 0.0R
        Me.dtaObs.MensajeIncorrectoCustom = Nothing
        Me.dtaObs.Name = "dtaObs"
        Me.dtaObs.Null_on_Empty = True
        Me.dtaObs.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtaObs.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtaObs.ReadOnly_Data = False
        Me.dtaObs.Size = New System.Drawing.Size(1138, 80)
        Me.dtaObs.TabIndex = 0
        Me.dtaObs.Text_Data = ""
        Me.dtaObs.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtaObs.TopPadding = 0
        Me.dtaObs.Upper_Case = False
        Me.dtaObs.Validate_on_lost_focus = True
        '
        'pnlPpal
        '
        Me.pnlPpal.Auto_Size = False
        Me.pnlPpal.BackColor = System.Drawing.SystemColors.Control
        Me.pnlPpal.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlPpal.ChangeDock = False
        Me.pnlPpal.Control_Resize = False
        Me.pnlPpal.Controls.Add(Me.pnlGenDer)
        Me.pnlPpal.Controls.Add(Me.pnlGenIzq)
        Me.pnlPpal.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlPpal.isSpace = False
        Me.pnlPpal.Location = New System.Drawing.Point(0, 80)
        Me.pnlPpal.Name = "pnlPpal"
        Me.pnlPpal.numRows = 0
        Me.pnlPpal.Padding = New System.Windows.Forms.Padding(5)
        Me.pnlPpal.Reorder = True
        Me.pnlPpal.Size = New System.Drawing.Size(1138, 377)
        Me.pnlPpal.TabIndex = 10
        '
        'pnlGenDer
        '
        Me.pnlGenDer.Auto_Size = False
        Me.pnlGenDer.BackColor = System.Drawing.SystemColors.Control
        Me.pnlGenDer.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlGenDer.ChangeDock = True
        Me.pnlGenDer.Control_Resize = False
        Me.pnlGenDer.Controls.Add(Me.gbxCotiza)
        Me.pnlGenDer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlGenDer.isSpace = False
        Me.pnlGenDer.Location = New System.Drawing.Point(428, 5)
        Me.pnlGenDer.Name = "pnlGenDer"
        Me.pnlGenDer.numRows = 0
        Me.pnlGenDer.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.pnlGenDer.Reorder = True
        Me.pnlGenDer.Size = New System.Drawing.Size(705, 367)
        Me.pnlGenDer.TabIndex = 1
        '
        'gbxCotiza
        '
        Me.gbxCotiza.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.gbxCotiza.BackColor = System.Drawing.SystemColors.Control
        Me.gbxCotiza.Controls.Add(Me.pnlCotiza)
        Me.gbxCotiza.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbxCotiza.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.gbxCotiza.HeaderText = "Cotización"
        Me.gbxCotiza.Location = New System.Drawing.Point(6, 0)
        Me.gbxCotiza.Name = "gbxCotiza"
        Me.gbxCotiza.numRows = 0
        Me.gbxCotiza.Padding = New System.Windows.Forms.Padding(6, 18, 6, 6)
        Me.gbxCotiza.Reorder = True
        Me.gbxCotiza.Size = New System.Drawing.Size(699, 367)
        Me.gbxCotiza.TabIndex = 0
        Me.gbxCotiza.Text = "Cotización"
        Me.gbxCotiza.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.gbxCotiza.ThemeName = "Windows8"
        Me.gbxCotiza.Title = "Cotización"
        '
        'pnlCotiza
        '
        Me.pnlCotiza.Auto_Size = False
        Me.pnlCotiza.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlCotiza.ChangeDock = True
        Me.pnlCotiza.Control_Resize = False
        Me.pnlCotiza.Controls.Add(Me.dgvLiRes)
        Me.pnlCotiza.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlCotiza.isSpace = False
        Me.pnlCotiza.Location = New System.Drawing.Point(6, 18)
        Me.pnlCotiza.Name = "pnlCotiza"
        Me.pnlCotiza.numRows = 0
        Me.pnlCotiza.Reorder = True
        Me.pnlCotiza.Size = New System.Drawing.Size(687, 343)
        Me.pnlCotiza.TabIndex = 0
        '
        'dgvLiRes
        '
        Me.dgvLiRes.ColRel = Nothing
        Me.dgvLiRes.ColSelectFilter = Nothing
        Me.dgvLiRes.DataGridType = CustomControls.DataGrid.GridType.Edit
        Me.dgvLiRes.DBConnection = Nothing
        Me.dgvLiRes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvLiRes.EnforceConstrains = True
        Me.dgvLiRes.Grupo = Nothing
        Me.dgvLiRes.idRel = Nothing
        Me.dgvLiRes.Location = New System.Drawing.Point(0, 0)
        Me.dgvLiRes.MarcarFilas = False
        '
        'dgvLiRes
        '
        Me.dgvLiRes.MasterTemplate.AllowColumnChooser = False
        Me.dgvLiRes.MasterTemplate.EnableFiltering = True
        Me.dgvLiRes.MasterTemplate.EnableGrouping = False
        Me.dgvLiRes.MasterTemplate.MultiSelect = True
        Me.dgvLiRes.MasterTemplate.SelectionMode = Telerik.WinControls.UI.GridViewSelectionMode.CellSelect
        Me.dgvLiRes.Name = "dgvLiRes"
        Me.dgvLiRes.Size = New System.Drawing.Size(687, 343)
        Me.dgvLiRes.TabIndex = 0
        Me.dgvLiRes.TablaEdit = Nothing
        Me.dgvLiRes.Tarifa = Nothing
        Me.dgvLiRes.Text = "GridLiRes1"
        Me.dgvLiRes.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dgvLiRes.ThemeName = "TelerikMetroBlue"
        '
        'pnlGenIzq
        '
        Me.pnlGenIzq.Auto_Size = False
        Me.pnlGenIzq.BackColor = System.Drawing.Color.Lavender
        Me.pnlGenIzq.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlGenIzq.ChangeDock = True
        Me.pnlGenIzq.Control_Resize = False
        Me.pnlGenIzq.Controls.Add(Me.gbxParamCotiza)
        Me.pnlGenIzq.Controls.Add(Me.Space4)
        Me.pnlGenIzq.Controls.Add(Me.gbxCliente)
        Me.pnlGenIzq.Controls.Add(Me.Space2)
        Me.pnlGenIzq.Controls.Add(Me.gbxLocaliza)
        Me.pnlGenIzq.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlGenIzq.isSpace = False
        Me.pnlGenIzq.Location = New System.Drawing.Point(5, 5)
        Me.pnlGenIzq.Name = "pnlGenIzq"
        Me.pnlGenIzq.numRows = 0
        Me.pnlGenIzq.Reorder = True
        Me.pnlGenIzq.Size = New System.Drawing.Size(423, 367)
        Me.pnlGenIzq.TabIndex = 0
        '
        'gbxParamCotiza
        '
        Me.gbxParamCotiza.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.gbxParamCotiza.AutoSize = True
        Me.gbxParamCotiza.BackColor = System.Drawing.SystemColors.Control
        Me.gbxParamCotiza.Controls.Add(Me.dtfSubComisio)
        Me.gbxParamCotiza.Controls.Add(Me.dtfComisio)
        Me.gbxParamCotiza.Controls.Add(Me.dtfPreferencia)
        Me.gbxParamCotiza.Controls.Add(Me.dtfGrupo)
        Me.gbxParamCotiza.Controls.Add(Me.dtfTarifa)
        Me.gbxParamCotiza.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbxParamCotiza.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.gbxParamCotiza.HeaderText = ""
        Me.gbxParamCotiza.Location = New System.Drawing.Point(0, 218)
        Me.gbxParamCotiza.Name = "gbxParamCotiza"
        Me.gbxParamCotiza.numRows = 0
        Me.gbxParamCotiza.Padding = New System.Windows.Forms.Padding(6)
        Me.gbxParamCotiza.Reorder = True
        Me.gbxParamCotiza.Size = New System.Drawing.Size(423, 136)
        Me.gbxParamCotiza.TabIndex = 4
        Me.gbxParamCotiza.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.gbxParamCotiza.ThemeName = "Windows8"
        Me.gbxParamCotiza.Title = ""
        '
        'dtfSubComisio
        '
        Me.dtfSubComisio.Allow_Empty = True
        Me.dtfSubComisio.Allow_Negative = True
        Me.dtfSubComisio.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfSubComisio.BackColor = System.Drawing.SystemColors.Control
        Me.dtfSubComisio.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfSubComisio.DataField = "COMISIO2_RES2"
        Me.dtfSubComisio.DataTable = "R2"
        Me.dtfSubComisio.DB = Connection30
        Me.dtfSubComisio.Desc_Datafield = "NOMBRE"
        Me.dtfSubComisio.Desc_DBPK = "NUM_COMI"
        Me.dtfSubComisio.Desc_DBTable = "COMISIO"
        Me.dtfSubComisio.Desc_Where = Nothing
        Me.dtfSubComisio.Desc_WhereObligatoria = Nothing
        Me.dtfSubComisio.Descripcion = "Sub Comi."
        Me.dtfSubComisio.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfSubComisio.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfSubComisio.ExtraSQL = ""
        Me.dtfSubComisio.FocoEnAgregar = False
        Me.dtfSubComisio.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfSubComisio.Formulario = Nothing
        Me.dtfSubComisio.Label_Space = 75
        Me.dtfSubComisio.Length_Data = 32767
        Me.dtfSubComisio.Location = New System.Drawing.Point(6, 109)
        Me.dtfSubComisio.Lupa = Nothing
        Me.dtfSubComisio.Max_Value = 0.0R
        Me.dtfSubComisio.MensajeIncorrectoCustom = Nothing
        Me.dtfSubComisio.Name = "dtfSubComisio"
        Me.dtfSubComisio.Null_on_Empty = True
        Me.dtfSubComisio.OpenForm = Nothing
        Me.dtfSubComisio.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfSubComisio.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfSubComisio.Query_on_Text_Changed = True
        Me.dtfSubComisio.ReadOnly_Data = False
        Me.dtfSubComisio.ReQuery = False
        Me.dtfSubComisio.ShowButton = True
        Me.dtfSubComisio.Size = New System.Drawing.Size(411, 26)
        Me.dtfSubComisio.TabIndex = 4
        Me.dtfSubComisio.Text_Data = ""
        Me.dtfSubComisio.Text_Data_Desc = ""
        Me.dtfSubComisio.Text_Width = 80
        Me.dtfSubComisio.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfSubComisio.TopPadding = 0
        Me.dtfSubComisio.Upper_Case = False
        Me.dtfSubComisio.Validate_on_lost_focus = True
        '
        'dtfComisio
        '
        Me.dtfComisio.Allow_Empty = True
        Me.dtfComisio.Allow_Negative = True
        Me.dtfComisio.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfComisio.BackColor = System.Drawing.SystemColors.Control
        Me.dtfComisio.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfComisio.DataField = "COMISIO_RES2"
        Me.dtfComisio.DataTable = "R2"
        Me.dtfComisio.DB = Connection31
        Me.dtfComisio.Desc_Datafield = "NOMBRE"
        Me.dtfComisio.Desc_DBPK = "NUM_COMI"
        Me.dtfComisio.Desc_DBTable = "COMISIO"
        Me.dtfComisio.Desc_Where = Nothing
        Me.dtfComisio.Desc_WhereObligatoria = Nothing
        Me.dtfComisio.Descripcion = "Comisionista"
        Me.dtfComisio.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfComisio.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfComisio.ExtraSQL = ""
        Me.dtfComisio.FocoEnAgregar = False
        Me.dtfComisio.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfComisio.Formulario = Nothing
        Me.dtfComisio.Label_Space = 75
        Me.dtfComisio.Length_Data = 32767
        Me.dtfComisio.Location = New System.Drawing.Point(6, 83)
        Me.dtfComisio.Lupa = Nothing
        Me.dtfComisio.Max_Value = 0.0R
        Me.dtfComisio.MensajeIncorrectoCustom = Nothing
        Me.dtfComisio.Name = "dtfComisio"
        Me.dtfComisio.Null_on_Empty = True
        Me.dtfComisio.OpenForm = Nothing
        Me.dtfComisio.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfComisio.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfComisio.Query_on_Text_Changed = True
        Me.dtfComisio.ReadOnly_Data = False
        Me.dtfComisio.ReQuery = False
        Me.dtfComisio.ShowButton = True
        Me.dtfComisio.Size = New System.Drawing.Size(411, 26)
        Me.dtfComisio.TabIndex = 3
        Me.dtfComisio.Text_Data = ""
        Me.dtfComisio.Text_Data_Desc = ""
        Me.dtfComisio.Text_Width = 80
        Me.dtfComisio.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfComisio.TopPadding = 0
        Me.dtfComisio.Upper_Case = False
        Me.dtfComisio.Validate_on_lost_focus = True
        '
        'dtfPreferencia
        '
        Me.dtfPreferencia.Allow_Empty = True
        Me.dtfPreferencia.Allow_Negative = True
        Me.dtfPreferencia.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfPreferencia.BackColor = System.Drawing.SystemColors.Control
        Me.dtfPreferencia.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfPreferencia.DataField = "PREFERE_RES1"
        Me.dtfPreferencia.DataTable = "R1"
        Me.dtfPreferencia.Descripcion = "Preferencia"
        Me.dtfPreferencia.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfPreferencia.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfPreferencia.FocoEnAgregar = False
        Me.dtfPreferencia.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfPreferencia.Image = Nothing
        Me.dtfPreferencia.Label_Space = 75
        Me.dtfPreferencia.Length_Data = 32767
        Me.dtfPreferencia.Location = New System.Drawing.Point(6, 58)
        Me.dtfPreferencia.Max_Value = 0.0R
        Me.dtfPreferencia.MensajeIncorrectoCustom = Nothing
        Me.dtfPreferencia.Name = "dtfPreferencia"
        Me.dtfPreferencia.Null_on_Empty = True
        Me.dtfPreferencia.OpenForm = Nothing
        Me.dtfPreferencia.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfPreferencia.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfPreferencia.ReadOnly_Data = False
        Me.dtfPreferencia.Show_Button = False
        Me.dtfPreferencia.Size = New System.Drawing.Size(411, 25)
        Me.dtfPreferencia.TabIndex = 2
        Me.dtfPreferencia.Text_Data = ""
        Me.dtfPreferencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfPreferencia.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfPreferencia.TopPadding = 0
        Me.dtfPreferencia.Upper_Case = True
        Me.dtfPreferencia.Validate_on_lost_focus = True
        '
        'dtfGrupo
        '
        Me.dtfGrupo.Allow_Empty = False
        Me.dtfGrupo.Allow_Negative = True
        Me.dtfGrupo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfGrupo.BackColor = System.Drawing.SystemColors.Control
        Me.dtfGrupo.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfGrupo.DataField = "GRUPO_RES1"
        Me.dtfGrupo.DataTable = "R1"
        Me.dtfGrupo.DB = Connection32
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
        Me.dtfGrupo.Formulario = Nothing
        Me.dtfGrupo.Label_Space = 75
        Me.dtfGrupo.Length_Data = 32767
        Me.dtfGrupo.Location = New System.Drawing.Point(6, 32)
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
        Me.dtfGrupo.Size = New System.Drawing.Size(411, 26)
        Me.dtfGrupo.TabIndex = 1
        Me.dtfGrupo.Text_Data = ""
        Me.dtfGrupo.Text_Data_Desc = ""
        Me.dtfGrupo.Text_Width = 40
        Me.dtfGrupo.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfGrupo.TopPadding = 0
        Me.dtfGrupo.Upper_Case = False
        Me.dtfGrupo.Validate_on_lost_focus = True
        '
        'dtfTarifa
        '
        Me.dtfTarifa.Allow_Empty = False
        Me.dtfTarifa.Allow_Negative = True
        Me.dtfTarifa.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfTarifa.BackColor = System.Drawing.SystemColors.Control
        Me.dtfTarifa.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfTarifa.DataField = "TARIFA_RES1"
        Me.dtfTarifa.DataTable = "R1"
        Me.dtfTarifa.DB = Connection33
        Me.dtfTarifa.Desc_Datafield = "NOMBRE"
        Me.dtfTarifa.Desc_DBPK = "CODIGO"
        Me.dtfTarifa.Desc_DBTable = "NTARI"
        Me.dtfTarifa.Desc_Where = Nothing
        Me.dtfTarifa.Desc_WhereObligatoria = Nothing
        Me.dtfTarifa.Descripcion = "Tarifa"
        Me.dtfTarifa.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfTarifa.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfTarifa.ExtraSQL = ""
        Me.dtfTarifa.FocoEnAgregar = False
        Me.dtfTarifa.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfTarifa.Formulario = Nothing
        Me.dtfTarifa.Label_Space = 75
        Me.dtfTarifa.Length_Data = 32767
        Me.dtfTarifa.Location = New System.Drawing.Point(6, 6)
        Me.dtfTarifa.Lupa = Nothing
        Me.dtfTarifa.Max_Value = 0.0R
        Me.dtfTarifa.MensajeIncorrectoCustom = Nothing
        Me.dtfTarifa.Name = "dtfTarifa"
        Me.dtfTarifa.Null_on_Empty = True
        Me.dtfTarifa.OpenForm = Nothing
        Me.dtfTarifa.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfTarifa.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfTarifa.Query_on_Text_Changed = True
        Me.dtfTarifa.ReadOnly_Data = False
        Me.dtfTarifa.ReQuery = False
        Me.dtfTarifa.ShowButton = True
        Me.dtfTarifa.Size = New System.Drawing.Size(411, 26)
        Me.dtfTarifa.TabIndex = 0
        Me.dtfTarifa.Text_Data = ""
        Me.dtfTarifa.Text_Data_Desc = ""
        Me.dtfTarifa.Text_Width = 80
        Me.dtfTarifa.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfTarifa.TopPadding = 0
        Me.dtfTarifa.Upper_Case = False
        Me.dtfTarifa.Validate_on_lost_focus = True
        '
        'Space4
        '
        Me.Space4.Auto_Size = False
        Me.Space4.BorderColor = System.Drawing.SystemColors.Control
        Me.Space4.ChangeDock = True
        Me.Space4.Control_Resize = False
        Me.Space4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Space4.isSpace = True
        Me.Space4.Location = New System.Drawing.Point(0, 212)
        Me.Space4.Name = "Space4"
        Me.Space4.numRows = 0
        Me.Space4.Reorder = True
        Me.Space4.Size = New System.Drawing.Size(423, 6)
        Me.Space4.TabIndex = 3
        '
        'gbxCliente
        '
        Me.gbxCliente.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.gbxCliente.BackColor = System.Drawing.SystemColors.Control
        Me.gbxCliente.Controls.Add(Me.dtfConductor)
        Me.gbxCliente.Controls.Add(Me.Panel2)
        Me.gbxCliente.Controls.Add(Me.pnlObsCli)
        Me.gbxCliente.Controls.Add(Me.dtfCliente)
        Me.gbxCliente.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbxCliente.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.gbxCliente.HeaderText = ""
        Me.gbxCliente.Location = New System.Drawing.Point(0, 90)
        Me.gbxCliente.Name = "gbxCliente"
        Me.gbxCliente.numRows = 0
        Me.gbxCliente.Padding = New System.Windows.Forms.Padding(6)
        Me.gbxCliente.Reorder = True
        Me.gbxCliente.Size = New System.Drawing.Size(423, 122)
        Me.gbxCliente.TabIndex = 2
        Me.gbxCliente.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.gbxCliente.ThemeName = "Windows8"
        Me.gbxCliente.Title = ""
        '
        'dtfConductor
        '
        Me.dtfConductor.Allow_Empty = False
        Me.dtfConductor.Allow_Negative = True
        Me.dtfConductor.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfConductor.BackColor = System.Drawing.SystemColors.Control
        Me.dtfConductor.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfConductor.DataField = "CONDUCTOR_RES1"
        Me.dtfConductor.DataField_DescEdit = "NOMBRE_RES1"
        Me.dtfConductor.DataTable = "R1"
        Me.dtfConductor.DataTable_DescEdit = "R1"
        Me.dtfConductor.DB = Connection34
        Me.dtfConductor.Desc_Datafield = "NOMBRE"
        Me.dtfConductor.Desc_DBPK = "NUMERO_CLI"
        Me.dtfConductor.Desc_DBTable = "CLIENTES1"
        Me.dtfConductor.Desc_Where = "BAJA IS NULL"
        Me.dtfConductor.Desc_WhereObligatoria = Nothing
        Me.dtfConductor.Descripcion = "Conductor"
        Me.dtfConductor.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfConductor.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfConductor.ExtraSQL = ""
        Me.dtfConductor.FocoEnAgregar = False
        Me.dtfConductor.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfConductor.Formulario = Nothing
        Me.dtfConductor.Label_Space = 75
        Me.dtfConductor.Length_Data = 32767
        Me.dtfConductor.Location = New System.Drawing.Point(6, 95)
        Me.dtfConductor.Lupa = Nothing
        Me.dtfConductor.Max_Value = 0.0R
        Me.dtfConductor.MensajeIncorrectoCustom = Nothing
        Me.dtfConductor.Name = "dtfConductor"
        Me.dtfConductor.Null_on_Empty = True
        Me.dtfConductor.OpenForm = Nothing
        Me.dtfConductor.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfConductor.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfConductor.Query_on_Text_Changed = True
        Me.dtfConductor.ReadOnly_Data = False
        Me.dtfConductor.ReadOnly_Desc = False
        Me.dtfConductor.ReQuery = False
        Me.dtfConductor.ShowButton = True
        Me.dtfConductor.Size = New System.Drawing.Size(411, 26)
        Me.dtfConductor.TabIndex = 3
        Me.dtfConductor.Text_Data = ""
        Me.dtfConductor.Text_Data_Desc = ""
        Me.dtfConductor.Text_Width = 80
        Me.dtfConductor.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfConductor.TopPadding = 0
        Me.dtfConductor.Upper_Case = False
        Me.dtfConductor.Validate_on_lost_focus = True
        '
        'Panel2
        '
        Me.Panel2.Auto_Size = False
        Me.Panel2.BorderColor = System.Drawing.SystemColors.Control
        Me.Panel2.ChangeDock = True
        Me.Panel2.Control_Resize = False
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.isSpace = True
        Me.Panel2.Location = New System.Drawing.Point(6, 91)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.numRows = 0
        Me.Panel2.Reorder = True
        Me.Panel2.Size = New System.Drawing.Size(411, 4)
        Me.Panel2.TabIndex = 2
        '
        'pnlObsCli
        '
        Me.pnlObsCli.Auto_Size = False
        Me.pnlObsCli.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlObsCli.ChangeDock = True
        Me.pnlObsCli.Control_Resize = False
        Me.pnlObsCli.Controls.Add(Me.dtaObsCli)
        Me.pnlObsCli.Controls.Add(Me.pnlObsCliIzq)
        Me.pnlObsCli.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlObsCli.isSpace = False
        Me.pnlObsCli.Location = New System.Drawing.Point(6, 31)
        Me.pnlObsCli.Name = "pnlObsCli"
        Me.pnlObsCli.numRows = 0
        Me.pnlObsCli.Reorder = True
        Me.pnlObsCli.Size = New System.Drawing.Size(411, 60)
        Me.pnlObsCli.TabIndex = 1
        '
        'dtaObsCli
        '
        Me.dtaObsCli.Allow_Empty = True
        Me.dtaObsCli.Allow_Negative = True
        Me.dtaObsCli.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtaObsCli.BackColor = System.Drawing.SystemColors.Control
        Me.dtaObsCli.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtaObsCli.DataField = Nothing
        Me.dtaObsCli.DataTable = ""
        Me.dtaObsCli.Descripcion = Nothing
        Me.dtaObsCli.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtaObsCli.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtaObsCli.FocoEnAgregar = False
        Me.dtaObsCli.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtaObsCli.Length_Data = 32767
        Me.dtaObsCli.Location = New System.Drawing.Point(75, 0)
        Me.dtaObsCli.Max_Value = 0.0R
        Me.dtaObsCli.MensajeIncorrectoCustom = Nothing
        Me.dtaObsCli.Name = "dtaObsCli"
        Me.dtaObsCli.Null_on_Empty = True
        Me.dtaObsCli.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtaObsCli.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtaObsCli.ReadOnly_Data = True
        Me.dtaObsCli.Size = New System.Drawing.Size(336, 65)
        Me.dtaObsCli.TabIndex = 1
        Me.dtaObsCli.TabStop = False
        Me.dtaObsCli.Text_Data = ""
        Me.dtaObsCli.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtaObsCli.TopPadding = 0
        Me.dtaObsCli.Upper_Case = False
        Me.dtaObsCli.Validate_on_lost_focus = True
        '
        'pnlObsCliIzq
        '
        Me.pnlObsCliIzq.Auto_Size = False
        Me.pnlObsCliIzq.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlObsCliIzq.ChangeDock = True
        Me.pnlObsCliIzq.Control_Resize = False
        Me.pnlObsCliIzq.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlObsCliIzq.isSpace = False
        Me.pnlObsCliIzq.Location = New System.Drawing.Point(0, 0)
        Me.pnlObsCliIzq.Name = "pnlObsCliIzq"
        Me.pnlObsCliIzq.numRows = 0
        Me.pnlObsCliIzq.Reorder = True
        Me.pnlObsCliIzq.Size = New System.Drawing.Size(75, 60)
        Me.pnlObsCliIzq.TabIndex = 0
        '
        'dtfCliente
        '
        Me.dtfCliente.Allow_Empty = False
        Me.dtfCliente.Allow_Negative = True
        Me.dtfCliente.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfCliente.BackColor = System.Drawing.SystemColors.Control
        Me.dtfCliente.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfCliente.DataField = "CLIENTE_RES1"
        Me.dtfCliente.DataField_DescEdit = "NOMCLI_RES1"
        Me.dtfCliente.DataTable = "R1"
        Me.dtfCliente.DataTable_DescEdit = "R1"
        Me.dtfCliente.DB = Connection35
        Me.dtfCliente.Desc_Datafield = "NOMBRE"
        Me.dtfCliente.Desc_DBPK = "NUMERO_CLI"
        Me.dtfCliente.Desc_DBTable = "CLIENTES1"
        Me.dtfCliente.Desc_Where = "BAJA IS NULL"
        Me.dtfCliente.Desc_WhereObligatoria = ""
        Me.dtfCliente.Descripcion = "Cliente"
        Me.dtfCliente.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfCliente.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfCliente.ExtraSQL = ""
        Me.dtfCliente.FocoEnAgregar = False
        Me.dtfCliente.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfCliente.Formulario = Nothing
        Me.dtfCliente.Label_Space = 75
        Me.dtfCliente.Length_Data = 32767
        Me.dtfCliente.Location = New System.Drawing.Point(6, 6)
        Me.dtfCliente.Lupa = Nothing
        Me.dtfCliente.Max_Value = 0.0R
        Me.dtfCliente.MensajeIncorrectoCustom = Nothing
        Me.dtfCliente.Name = "dtfCliente"
        Me.dtfCliente.Null_on_Empty = True
        Me.dtfCliente.OpenForm = Nothing
        Me.dtfCliente.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfCliente.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfCliente.Query_on_Text_Changed = True
        Me.dtfCliente.ReadOnly_Data = False
        Me.dtfCliente.ReadOnly_Desc = False
        Me.dtfCliente.ReQuery = False
        Me.dtfCliente.ShowButton = True
        Me.dtfCliente.Size = New System.Drawing.Size(411, 25)
        Me.dtfCliente.TabIndex = 0
        Me.dtfCliente.Text_Data = ""
        Me.dtfCliente.Text_Data_Desc = ""
        Me.dtfCliente.Text_Width = 80
        Me.dtfCliente.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfCliente.TopPadding = 0
        Me.dtfCliente.Upper_Case = False
        Me.dtfCliente.Validate_on_lost_focus = True
        '
        'Space2
        '
        Me.Space2.Auto_Size = False
        Me.Space2.BorderColor = System.Drawing.SystemColors.Control
        Me.Space2.ChangeDock = True
        Me.Space2.Control_Resize = False
        Me.Space2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Space2.isSpace = True
        Me.Space2.Location = New System.Drawing.Point(0, 84)
        Me.Space2.Name = "Space2"
        Me.Space2.numRows = 0
        Me.Space2.Reorder = True
        Me.Space2.Size = New System.Drawing.Size(423, 6)
        Me.Space2.TabIndex = 1
        '
        'gbxLocaliza
        '
        Me.gbxLocaliza.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.gbxLocaliza.BackColor = System.Drawing.SystemColors.Control
        Me.gbxLocaliza.Controls.Add(Me.pnlReferencia)
        Me.gbxLocaliza.Controls.Add(Me.pnlVuelo)
        Me.gbxLocaliza.Controls.Add(Me.pnlLocaliza)
        Me.gbxLocaliza.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbxLocaliza.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.gbxLocaliza.HeaderText = ""
        Me.gbxLocaliza.Location = New System.Drawing.Point(0, 0)
        Me.gbxLocaliza.Name = "gbxLocaliza"
        Me.gbxLocaliza.numRows = 0
        Me.gbxLocaliza.Padding = New System.Windows.Forms.Padding(6)
        Me.gbxLocaliza.Reorder = True
        Me.gbxLocaliza.Size = New System.Drawing.Size(423, 84)
        Me.gbxLocaliza.TabIndex = 0
        Me.gbxLocaliza.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.gbxLocaliza.ThemeName = "Windows8"
        Me.gbxLocaliza.Title = ""
        '
        'pnlReferencia
        '
        Me.pnlReferencia.Auto_Size = False
        Me.pnlReferencia.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlReferencia.ChangeDock = True
        Me.pnlReferencia.Control_Resize = False
        Me.pnlReferencia.Controls.Add(Me.dtfReferencia)
        Me.pnlReferencia.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlReferencia.isSpace = False
        Me.pnlReferencia.Location = New System.Drawing.Point(6, 56)
        Me.pnlReferencia.Name = "pnlReferencia"
        Me.pnlReferencia.numRows = 0
        Me.pnlReferencia.Reorder = True
        Me.pnlReferencia.Size = New System.Drawing.Size(411, 24)
        Me.pnlReferencia.TabIndex = 2
        '
        'dtfReferencia
        '
        Me.dtfReferencia.Allow_Empty = True
        Me.dtfReferencia.Allow_Negative = True
        Me.dtfReferencia.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfReferencia.BackColor = System.Drawing.SystemColors.Control
        Me.dtfReferencia.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfReferencia.DataField = "REFERENCIA_RES1"
        Me.dtfReferencia.DataTable = "R1"
        Me.dtfReferencia.Descripcion = "Referencia"
        Me.dtfReferencia.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfReferencia.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfReferencia.FocoEnAgregar = False
        Me.dtfReferencia.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfReferencia.Image = Nothing
        Me.dtfReferencia.Label_Space = 75
        Me.dtfReferencia.Length_Data = 32767
        Me.dtfReferencia.Location = New System.Drawing.Point(0, 0)
        Me.dtfReferencia.Max_Value = 0.0R
        Me.dtfReferencia.MensajeIncorrectoCustom = Nothing
        Me.dtfReferencia.Name = "dtfReferencia"
        Me.dtfReferencia.Null_on_Empty = True
        Me.dtfReferencia.OpenForm = Nothing
        Me.dtfReferencia.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfReferencia.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfReferencia.ReadOnly_Data = False
        Me.dtfReferencia.Show_Button = False
        Me.dtfReferencia.Size = New System.Drawing.Size(411, 21)
        Me.dtfReferencia.TabIndex = 0
        Me.dtfReferencia.Text_Data = ""
        Me.dtfReferencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfReferencia.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfReferencia.TopPadding = 0
        Me.dtfReferencia.Upper_Case = True
        Me.dtfReferencia.Validate_on_lost_focus = True
        '
        'pnlVuelo
        '
        Me.pnlVuelo.Auto_Size = False
        Me.pnlVuelo.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlVuelo.ChangeDock = True
        Me.pnlVuelo.Control_Resize = False
        Me.pnlVuelo.Controls.Add(Me.dtfVuelo)
        Me.pnlVuelo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlVuelo.isSpace = False
        Me.pnlVuelo.Location = New System.Drawing.Point(6, 31)
        Me.pnlVuelo.Name = "pnlVuelo"
        Me.pnlVuelo.numRows = 0
        Me.pnlVuelo.Reorder = True
        Me.pnlVuelo.Size = New System.Drawing.Size(411, 25)
        Me.pnlVuelo.TabIndex = 1
        '
        'dtfVuelo
        '
        Me.dtfVuelo.Allow_Empty = True
        Me.dtfVuelo.Allow_Negative = True
        Me.dtfVuelo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfVuelo.BackColor = System.Drawing.SystemColors.Control
        Me.dtfVuelo.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfVuelo.DataField = "VUELO_RES1"
        Me.dtfVuelo.DataTable = "R1"
        Me.dtfVuelo.Descripcion = "Vuelo"
        Me.dtfVuelo.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfVuelo.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfVuelo.FocoEnAgregar = False
        Me.dtfVuelo.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfVuelo.Image = Nothing
        Me.dtfVuelo.Label_Space = 75
        Me.dtfVuelo.Length_Data = 32767
        Me.dtfVuelo.Location = New System.Drawing.Point(0, 0)
        Me.dtfVuelo.Max_Value = 0.0R
        Me.dtfVuelo.MensajeIncorrectoCustom = Nothing
        Me.dtfVuelo.Name = "dtfVuelo"
        Me.dtfVuelo.Null_on_Empty = True
        Me.dtfVuelo.OpenForm = Nothing
        Me.dtfVuelo.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfVuelo.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfVuelo.ReadOnly_Data = False
        Me.dtfVuelo.Show_Button = False
        Me.dtfVuelo.Size = New System.Drawing.Size(411, 21)
        Me.dtfVuelo.TabIndex = 0
        Me.dtfVuelo.Text_Data = ""
        Me.dtfVuelo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfVuelo.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfVuelo.TopPadding = 0
        Me.dtfVuelo.Upper_Case = True
        Me.dtfVuelo.Validate_on_lost_focus = True
        '
        'pnlLocaliza
        '
        Me.pnlLocaliza.Auto_Size = False
        Me.pnlLocaliza.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlLocaliza.ChangeDock = True
        Me.pnlLocaliza.Control_Resize = False
        Me.pnlLocaliza.Controls.Add(Me.dtfLocaliza)
        Me.pnlLocaliza.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlLocaliza.isSpace = False
        Me.pnlLocaliza.Location = New System.Drawing.Point(6, 6)
        Me.pnlLocaliza.Name = "pnlLocaliza"
        Me.pnlLocaliza.numRows = 0
        Me.pnlLocaliza.Reorder = True
        Me.pnlLocaliza.Size = New System.Drawing.Size(411, 25)
        Me.pnlLocaliza.TabIndex = 0
        '
        'dtfLocaliza
        '
        Me.dtfLocaliza.Allow_Empty = True
        Me.dtfLocaliza.Allow_Negative = True
        Me.dtfLocaliza.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfLocaliza.BackColor = System.Drawing.SystemColors.Control
        Me.dtfLocaliza.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfLocaliza.DataField = "LOCALIZA_RES1"
        Me.dtfLocaliza.DataTable = "R1"
        Me.dtfLocaliza.Descripcion = "Localizador"
        Me.dtfLocaliza.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfLocaliza.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfLocaliza.FocoEnAgregar = False
        Me.dtfLocaliza.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfLocaliza.Image = Nothing
        Me.dtfLocaliza.Label_Space = 75
        Me.dtfLocaliza.Length_Data = 32767
        Me.dtfLocaliza.Location = New System.Drawing.Point(0, 0)
        Me.dtfLocaliza.Max_Value = 0.0R
        Me.dtfLocaliza.MensajeIncorrectoCustom = Nothing
        Me.dtfLocaliza.Name = "dtfLocaliza"
        Me.dtfLocaliza.Null_on_Empty = True
        Me.dtfLocaliza.OpenForm = Nothing
        Me.dtfLocaliza.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfLocaliza.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfLocaliza.ReadOnly_Data = False
        Me.dtfLocaliza.Show_Button = False
        Me.dtfLocaliza.Size = New System.Drawing.Size(411, 21)
        Me.dtfLocaliza.TabIndex = 0
        Me.dtfLocaliza.Text_Data = ""
        Me.dtfLocaliza.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfLocaliza.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfLocaliza.TopPadding = 0
        Me.dtfLocaliza.Upper_Case = True
        Me.dtfLocaliza.Validate_on_lost_focus = True
        '
        'pnlCabeceraGen
        '
        Me.pnlCabeceraGen.Auto_Size = False
        Me.pnlCabeceraGen.BackColor = System.Drawing.Color.Silver
        Me.pnlCabeceraGen.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlCabeceraGen.ChangeDock = False
        Me.pnlCabeceraGen.Control_Resize = False
        Me.pnlCabeceraGen.Controls.Add(Me.pnlCabecera)
        Me.pnlCabeceraGen.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCabeceraGen.isSpace = False
        Me.pnlCabeceraGen.Location = New System.Drawing.Point(0, 0)
        Me.pnlCabeceraGen.Name = "pnlCabeceraGen"
        Me.pnlCabeceraGen.numRows = 0
        Me.pnlCabeceraGen.Reorder = True
        Me.pnlCabeceraGen.Size = New System.Drawing.Size(1138, 80)
        Me.pnlCabeceraGen.TabIndex = 0
        '
        'pnlCabecera
        '
        Me.pnlCabecera.Auto_Size = False
        Me.pnlCabecera.BackColor = System.Drawing.SystemColors.Control
        Me.pnlCabecera.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlCabecera.ChangeDock = True
        Me.pnlCabecera.Control_Resize = False
        Me.pnlCabecera.Controls.Add(Me.pnlPeriodo)
        Me.pnlCabecera.Controls.Add(Me.pnlCodigo)
        Me.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCabecera.isSpace = False
        Me.pnlCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlCabecera.Name = "pnlCabecera"
        Me.pnlCabecera.numRows = 0
        Me.pnlCabecera.Reorder = True
        Me.pnlCabecera.Size = New System.Drawing.Size(1138, 78)
        Me.pnlCabecera.TabIndex = 0
        '
        'pnlPeriodo
        '
        Me.pnlPeriodo.Auto_Size = False
        Me.pnlPeriodo.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlPeriodo.ChangeDock = True
        Me.pnlPeriodo.Control_Resize = False
        Me.pnlPeriodo.Controls.Add(Me.pnlDatosPrevistos)
        Me.pnlPeriodo.Controls.Add(Me.pnlDatosSalida)
        Me.pnlPeriodo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlPeriodo.isSpace = False
        Me.pnlPeriodo.Location = New System.Drawing.Point(0, 30)
        Me.pnlPeriodo.Name = "pnlPeriodo"
        Me.pnlPeriodo.numRows = 0
        Me.pnlPeriodo.Reorder = True
        Me.pnlPeriodo.Size = New System.Drawing.Size(1138, 48)
        Me.pnlPeriodo.TabIndex = 1
        '
        'pnlDatosPrevistos
        '
        Me.pnlDatosPrevistos.Auto_Size = False
        Me.pnlDatosPrevistos.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlDatosPrevistos.ChangeDock = False
        Me.pnlDatosPrevistos.Control_Resize = False
        Me.pnlDatosPrevistos.Controls.Add(Me.dtfLugarRecogida)
        Me.pnlDatosPrevistos.Controls.Add(Me.pnlSpace16)
        Me.pnlDatosPrevistos.Controls.Add(Me.pnlSpace15)
        Me.pnlDatosPrevistos.Controls.Add(Me.dtfOfiLlegada)
        Me.pnlDatosPrevistos.Controls.Add(Me.pnlSpace14)
        Me.pnlDatosPrevistos.Controls.Add(Me.dttHPrevista)
        Me.pnlDatosPrevistos.Controls.Add(Me.pnlSpace13)
        Me.pnlDatosPrevistos.Controls.Add(Me.dtdFPrevista)
        Me.pnlDatosPrevistos.Controls.Add(Me.pnlSpace12)
        Me.pnlDatosPrevistos.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlDatosPrevistos.isSpace = False
        Me.pnlDatosPrevistos.Location = New System.Drawing.Point(0, 26)
        Me.pnlDatosPrevistos.Name = "pnlDatosPrevistos"
        Me.pnlDatosPrevistos.numRows = 1
        Me.pnlDatosPrevistos.Reorder = True
        Me.pnlDatosPrevistos.Size = New System.Drawing.Size(1138, 26)
        Me.pnlDatosPrevistos.TabIndex = 1
        '
        'dtfLugarRecogida
        '
        Me.dtfLugarRecogida.Allow_Empty = True
        Me.dtfLugarRecogida.Allow_Negative = True
        Me.dtfLugarRecogida.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfLugarRecogida.BackColor = System.Drawing.SystemColors.Control
        Me.dtfLugarRecogida.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfLugarRecogida.DataField = "LUDEVO_RES1"
        Me.dtfLugarRecogida.DataTable = "R1"
        Me.dtfLugarRecogida.Descripcion = "Lugar Recogida"
        Me.dtfLugarRecogida.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfLugarRecogida.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfLugarRecogida.FocoEnAgregar = False
        Me.dtfLugarRecogida.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfLugarRecogida.Image = Nothing
        Me.dtfLugarRecogida.Label_Space = 100
        Me.dtfLugarRecogida.Length_Data = 32767
        Me.dtfLugarRecogida.Location = New System.Drawing.Point(518, 0)
        Me.dtfLugarRecogida.Max_Value = 0.0R
        Me.dtfLugarRecogida.MensajeIncorrectoCustom = Nothing
        Me.dtfLugarRecogida.Name = "dtfLugarRecogida"
        Me.dtfLugarRecogida.Null_on_Empty = True
        Me.dtfLugarRecogida.OpenForm = Nothing
        Me.dtfLugarRecogida.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfLugarRecogida.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfLugarRecogida.ReadOnly_Data = False
        Me.dtfLugarRecogida.Show_Button = True
        Me.dtfLugarRecogida.Size = New System.Drawing.Size(620, 26)
        Me.dtfLugarRecogida.TabIndex = 8
        Me.dtfLugarRecogida.Text_Data = ""
        Me.dtfLugarRecogida.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfLugarRecogida.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfLugarRecogida.TopPadding = 0
        Me.dtfLugarRecogida.Upper_Case = False
        Me.dtfLugarRecogida.Validate_on_lost_focus = True
        '
        'pnlSpace16
        '
        Me.pnlSpace16.Auto_Size = False
        Me.pnlSpace16.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace16.ChangeDock = True
        Me.pnlSpace16.Control_Resize = False
        Me.pnlSpace16.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace16.isSpace = True
        Me.pnlSpace16.Location = New System.Drawing.Point(512, 0)
        Me.pnlSpace16.Name = "pnlSpace16"
        Me.pnlSpace16.numRows = 0
        Me.pnlSpace16.Reorder = True
        Me.pnlSpace16.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace16.TabIndex = 7
        '
        'pnlSpace15
        '
        Me.pnlSpace15.Auto_Size = False
        Me.pnlSpace15.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace15.ChangeDock = True
        Me.pnlSpace15.Control_Resize = False
        Me.pnlSpace15.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace15.isSpace = True
        Me.pnlSpace15.Location = New System.Drawing.Point(506, 0)
        Me.pnlSpace15.Name = "pnlSpace15"
        Me.pnlSpace15.numRows = 0
        Me.pnlSpace15.Reorder = True
        Me.pnlSpace15.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace15.TabIndex = 6
        '
        'dtfOfiLlegada
        '
        Me.dtfOfiLlegada.Allow_Empty = True
        Me.dtfOfiLlegada.Allow_Negative = True
        Me.dtfOfiLlegada.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfOfiLlegada.BackColor = System.Drawing.SystemColors.Control
        Me.dtfOfiLlegada.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfOfiLlegada.DataField = "OFIRETORNO_RES1"
        Me.dtfOfiLlegada.DataTable = "R1"
        Me.dtfOfiLlegada.DB = Connection36
        Me.dtfOfiLlegada.Desc_Datafield = "NOMBRE"
        Me.dtfOfiLlegada.Desc_DBPK = "CODIGO"
        Me.dtfOfiLlegada.Desc_DBTable = "OFICINAS"
        Me.dtfOfiLlegada.Desc_Where = "FEC_BAJA IS NULL"
        Me.dtfOfiLlegada.Desc_WhereObligatoria = Nothing
        Me.dtfOfiLlegada.Descripcion = "Oficina Llegada"
        Me.dtfOfiLlegada.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfOfiLlegada.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfOfiLlegada.ExtraSQL = ""
        Me.dtfOfiLlegada.FocoEnAgregar = False
        Me.dtfOfiLlegada.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfOfiLlegada.Formulario = Nothing
        Me.dtfOfiLlegada.Label_Space = 100
        Me.dtfOfiLlegada.Length_Data = 32767
        Me.dtfOfiLlegada.Location = New System.Drawing.Point(354, 0)
        Me.dtfOfiLlegada.Lupa = Nothing
        Me.dtfOfiLlegada.Max_Value = 0.0R
        Me.dtfOfiLlegada.MensajeIncorrectoCustom = Nothing
        Me.dtfOfiLlegada.Name = "dtfOfiLlegada"
        Me.dtfOfiLlegada.Null_on_Empty = True
        Me.dtfOfiLlegada.OpenForm = Nothing
        Me.dtfOfiLlegada.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfOfiLlegada.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfOfiLlegada.Query_on_Text_Changed = True
        Me.dtfOfiLlegada.ReadOnly_Data = False
        Me.dtfOfiLlegada.ReQuery = False
        Me.dtfOfiLlegada.ShowButton = True
        Me.dtfOfiLlegada.Size = New System.Drawing.Size(152, 26)
        Me.dtfOfiLlegada.TabIndex = 5
        Me.dtfOfiLlegada.Text_Data = ""
        Me.dtfOfiLlegada.Text_Data_Desc = ""
        Me.dtfOfiLlegada.Text_Width = 25
        Me.dtfOfiLlegada.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfOfiLlegada.TopPadding = 0
        Me.dtfOfiLlegada.Upper_Case = False
        Me.dtfOfiLlegada.Validate_on_lost_focus = True
        '
        'pnlSpace14
        '
        Me.pnlSpace14.Auto_Size = False
        Me.pnlSpace14.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace14.ChangeDock = True
        Me.pnlSpace14.Control_Resize = False
        Me.pnlSpace14.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace14.isSpace = True
        Me.pnlSpace14.Location = New System.Drawing.Point(348, 0)
        Me.pnlSpace14.Name = "pnlSpace14"
        Me.pnlSpace14.numRows = 0
        Me.pnlSpace14.Reorder = True
        Me.pnlSpace14.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace14.TabIndex = 4
        '
        'dttHPrevista
        '
        Me.dttHPrevista.Allow_Empty = False
        Me.dttHPrevista.DataField = "HPREV_RES1"
        Me.dttHPrevista.DataTable = "R1"
        Me.dttHPrevista.Descripcion = "Hora Prevista"
        Me.dttHPrevista.Dock = System.Windows.Forms.DockStyle.Left
        Me.dttHPrevista.FocoEnAgregar = False
        Me.dttHPrevista.Location = New System.Drawing.Point(272, 0)
        Me.dttHPrevista.MensajeIncorrectoCustom = Nothing
        Me.dttHPrevista.Name = "dttHPrevista"
        Me.dttHPrevista.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dttHPrevista.ReadOnly_Data = False
        Me.dttHPrevista.Size = New System.Drawing.Size(76, 26)
        Me.dttHPrevista.TabIndex = 3
        Me.dttHPrevista.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dttHPrevista.Time = System.TimeSpan.Parse("10:59:00")
        Me.dttHPrevista.Validate_on_lost_focus = True
        '
        'pnlSpace13
        '
        Me.pnlSpace13.Auto_Size = False
        Me.pnlSpace13.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace13.ChangeDock = True
        Me.pnlSpace13.Control_Resize = False
        Me.pnlSpace13.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace13.isSpace = True
        Me.pnlSpace13.Location = New System.Drawing.Point(266, 0)
        Me.pnlSpace13.Name = "pnlSpace13"
        Me.pnlSpace13.numRows = 0
        Me.pnlSpace13.Reorder = True
        Me.pnlSpace13.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace13.TabIndex = 2
        '
        'dtdFPrevista
        '
        Me.dtdFPrevista.Allow_Empty = False
        Me.dtdFPrevista.DataField = "FPREV_RES1"
        Me.dtdFPrevista.DataTable = "R1"
        Me.dtdFPrevista.Default_Value = Nothing
        Me.dtdFPrevista.Descripcion = "Fecha Prevista"
        Me.dtdFPrevista.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtdFPrevista.FocoEnAgregar = False
        Me.dtdFPrevista.Label_Space = 95
        Me.dtdFPrevista.Location = New System.Drawing.Point(81, 0)
        Me.dtdFPrevista.Max_Value = Nothing
        Me.dtdFPrevista.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdFPrevista.MensajeIncorrectoCustom = Nothing
        Me.dtdFPrevista.Min_Value = Nothing
        Me.dtdFPrevista.MinDate = New Date(CType(0, Long))
        Me.dtdFPrevista.MinimumSize = New System.Drawing.Size(185, 26)
        Me.dtdFPrevista.Name = "dtdFPrevista"
        Me.dtdFPrevista.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdFPrevista.ReadOnly_Data = False
        Me.dtdFPrevista.Size = New System.Drawing.Size(185, 26)
        Me.dtdFPrevista.TabIndex = 1
        Me.dtdFPrevista.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdFPrevista.Validate_on_lost_focus = True
        Me.dtdFPrevista.Value_Data = New Date(2016, 6, 10, 0, 0, 0, 0)
        '
        'pnlSpace12
        '
        Me.pnlSpace12.Auto_Size = False
        Me.pnlSpace12.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace12.ChangeDock = True
        Me.pnlSpace12.Control_Resize = False
        Me.pnlSpace12.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace12.isSpace = True
        Me.pnlSpace12.Location = New System.Drawing.Point(0, 0)
        Me.pnlSpace12.Name = "pnlSpace12"
        Me.pnlSpace12.numRows = 0
        Me.pnlSpace12.Reorder = True
        Me.pnlSpace12.Size = New System.Drawing.Size(81, 26)
        Me.pnlSpace12.TabIndex = 0
        '
        'pnlDatosSalida
        '
        Me.pnlDatosSalida.Auto_Size = False
        Me.pnlDatosSalida.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlDatosSalida.ChangeDock = False
        Me.pnlDatosSalida.Control_Resize = False
        Me.pnlDatosSalida.Controls.Add(Me.dtfLugarEntrega)
        Me.pnlDatosSalida.Controls.Add(Me.pnlSpace10)
        Me.pnlDatosSalida.Controls.Add(Me.pnlSpace19)
        Me.pnlDatosSalida.Controls.Add(Me.dtfOfiSalida)
        Me.pnlDatosSalida.Controls.Add(Me.pnlSpace8)
        Me.pnlDatosSalida.Controls.Add(Me.dttHSalida)
        Me.pnlDatosSalida.Controls.Add(Me.pnlSpace7)
        Me.pnlDatosSalida.Controls.Add(Me.dtdFSalida)
        Me.pnlDatosSalida.Controls.Add(Me.pnlSpace6)
        Me.pnlDatosSalida.Controls.Add(Me.dtfDiasPrevistos)
        Me.pnlDatosSalida.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlDatosSalida.isSpace = False
        Me.pnlDatosSalida.Location = New System.Drawing.Point(0, 0)
        Me.pnlDatosSalida.Name = "pnlDatosSalida"
        Me.pnlDatosSalida.numRows = 1
        Me.pnlDatosSalida.Reorder = True
        Me.pnlDatosSalida.Size = New System.Drawing.Size(1138, 26)
        Me.pnlDatosSalida.TabIndex = 0
        '
        'dtfLugarEntrega
        '
        Me.dtfLugarEntrega.Allow_Empty = True
        Me.dtfLugarEntrega.Allow_Negative = True
        Me.dtfLugarEntrega.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfLugarEntrega.BackColor = System.Drawing.SystemColors.Control
        Me.dtfLugarEntrega.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfLugarEntrega.DataField = "LUENTRE_RES1"
        Me.dtfLugarEntrega.DataTable = "R1"
        Me.dtfLugarEntrega.Descripcion = "Lugar Entrega"
        Me.dtfLugarEntrega.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfLugarEntrega.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfLugarEntrega.FocoEnAgregar = False
        Me.dtfLugarEntrega.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfLugarEntrega.Image = Nothing
        Me.dtfLugarEntrega.Label_Space = 100
        Me.dtfLugarEntrega.Length_Data = 32767
        Me.dtfLugarEntrega.Location = New System.Drawing.Point(518, 0)
        Me.dtfLugarEntrega.Max_Value = 0.0R
        Me.dtfLugarEntrega.MensajeIncorrectoCustom = Nothing
        Me.dtfLugarEntrega.Name = "dtfLugarEntrega"
        Me.dtfLugarEntrega.Null_on_Empty = True
        Me.dtfLugarEntrega.OpenForm = Nothing
        Me.dtfLugarEntrega.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfLugarEntrega.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfLugarEntrega.ReadOnly_Data = False
        Me.dtfLugarEntrega.Show_Button = True
        Me.dtfLugarEntrega.Size = New System.Drawing.Size(620, 26)
        Me.dtfLugarEntrega.TabIndex = 9
        Me.dtfLugarEntrega.Text_Data = ""
        Me.dtfLugarEntrega.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfLugarEntrega.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfLugarEntrega.TopPadding = 0
        Me.dtfLugarEntrega.Upper_Case = False
        Me.dtfLugarEntrega.Validate_on_lost_focus = True
        '
        'pnlSpace10
        '
        Me.pnlSpace10.Auto_Size = False
        Me.pnlSpace10.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace10.ChangeDock = True
        Me.pnlSpace10.Control_Resize = False
        Me.pnlSpace10.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace10.isSpace = True
        Me.pnlSpace10.Location = New System.Drawing.Point(512, 0)
        Me.pnlSpace10.Name = "pnlSpace10"
        Me.pnlSpace10.numRows = 0
        Me.pnlSpace10.Reorder = True
        Me.pnlSpace10.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace10.TabIndex = 8
        '
        'pnlSpace19
        '
        Me.pnlSpace19.Auto_Size = False
        Me.pnlSpace19.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace19.ChangeDock = True
        Me.pnlSpace19.Control_Resize = False
        Me.pnlSpace19.Controls.Add(Me.pnlSpace9)
        Me.pnlSpace19.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace19.isSpace = True
        Me.pnlSpace19.Location = New System.Drawing.Point(506, 0)
        Me.pnlSpace19.Name = "pnlSpace19"
        Me.pnlSpace19.numRows = 0
        Me.pnlSpace19.Reorder = True
        Me.pnlSpace19.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace19.TabIndex = 7
        '
        'pnlSpace9
        '
        Me.pnlSpace9.Auto_Size = False
        Me.pnlSpace9.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace9.ChangeDock = True
        Me.pnlSpace9.Control_Resize = False
        Me.pnlSpace9.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace9.isSpace = True
        Me.pnlSpace9.Location = New System.Drawing.Point(0, 0)
        Me.pnlSpace9.Name = "pnlSpace9"
        Me.pnlSpace9.numRows = 0
        Me.pnlSpace9.Reorder = True
        Me.pnlSpace9.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace9.TabIndex = 0
        '
        'dtfOfiSalida
        '
        Me.dtfOfiSalida.Allow_Empty = True
        Me.dtfOfiSalida.Allow_Negative = True
        Me.dtfOfiSalida.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfOfiSalida.BackColor = System.Drawing.SystemColors.Control
        Me.dtfOfiSalida.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfOfiSalida.DataField = "OFISALIDA_RES1"
        Me.dtfOfiSalida.DataTable = "R1"
        Me.dtfOfiSalida.DB = Connection37
        Me.dtfOfiSalida.Desc_Datafield = "NOMBRE"
        Me.dtfOfiSalida.Desc_DBPK = "CODIGO"
        Me.dtfOfiSalida.Desc_DBTable = "OFICINAS"
        Me.dtfOfiSalida.Desc_Where = "FEC_BAJA IS NULL"
        Me.dtfOfiSalida.Desc_WhereObligatoria = Nothing
        Me.dtfOfiSalida.Descripcion = "Oficina Salida"
        Me.dtfOfiSalida.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfOfiSalida.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfOfiSalida.ExtraSQL = ""
        Me.dtfOfiSalida.FocoEnAgregar = False
        Me.dtfOfiSalida.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfOfiSalida.Formulario = Nothing
        Me.dtfOfiSalida.Label_Space = 100
        Me.dtfOfiSalida.Length_Data = 32767
        Me.dtfOfiSalida.Location = New System.Drawing.Point(354, 0)
        Me.dtfOfiSalida.Lupa = Nothing
        Me.dtfOfiSalida.Max_Value = 0.0R
        Me.dtfOfiSalida.MensajeIncorrectoCustom = Nothing
        Me.dtfOfiSalida.Name = "dtfOfiSalida"
        Me.dtfOfiSalida.Null_on_Empty = True
        Me.dtfOfiSalida.OpenForm = Nothing
        Me.dtfOfiSalida.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfOfiSalida.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfOfiSalida.Query_on_Text_Changed = True
        Me.dtfOfiSalida.ReadOnly_Data = False
        Me.dtfOfiSalida.ReQuery = False
        Me.dtfOfiSalida.ShowButton = True
        Me.dtfOfiSalida.Size = New System.Drawing.Size(152, 26)
        Me.dtfOfiSalida.TabIndex = 6
        Me.dtfOfiSalida.Text_Data = ""
        Me.dtfOfiSalida.Text_Data_Desc = ""
        Me.dtfOfiSalida.Text_Width = 25
        Me.dtfOfiSalida.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfOfiSalida.TopPadding = 0
        Me.dtfOfiSalida.Upper_Case = False
        Me.dtfOfiSalida.Validate_on_lost_focus = True
        '
        'pnlSpace8
        '
        Me.pnlSpace8.Auto_Size = False
        Me.pnlSpace8.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace8.ChangeDock = True
        Me.pnlSpace8.Control_Resize = False
        Me.pnlSpace8.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace8.isSpace = True
        Me.pnlSpace8.Location = New System.Drawing.Point(348, 0)
        Me.pnlSpace8.Name = "pnlSpace8"
        Me.pnlSpace8.numRows = 0
        Me.pnlSpace8.Reorder = True
        Me.pnlSpace8.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace8.TabIndex = 5
        '
        'dttHSalida
        '
        Me.dttHSalida.Allow_Empty = False
        Me.dttHSalida.DataField = "HSALIDA_RES1"
        Me.dttHSalida.DataTable = "R1"
        Me.dttHSalida.Descripcion = "Hora de Salida"
        Me.dttHSalida.Dock = System.Windows.Forms.DockStyle.Left
        Me.dttHSalida.FocoEnAgregar = False
        Me.dttHSalida.Location = New System.Drawing.Point(272, 0)
        Me.dttHSalida.MensajeIncorrectoCustom = Nothing
        Me.dttHSalida.Name = "dttHSalida"
        Me.dttHSalida.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dttHSalida.ReadOnly_Data = False
        Me.dttHSalida.Size = New System.Drawing.Size(76, 26)
        Me.dttHSalida.TabIndex = 4
        Me.dttHSalida.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dttHSalida.Time = System.TimeSpan.Parse("10:59:00")
        Me.dttHSalida.Validate_on_lost_focus = True
        '
        'pnlSpace7
        '
        Me.pnlSpace7.Auto_Size = False
        Me.pnlSpace7.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace7.ChangeDock = True
        Me.pnlSpace7.Control_Resize = False
        Me.pnlSpace7.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace7.isSpace = True
        Me.pnlSpace7.Location = New System.Drawing.Point(266, 0)
        Me.pnlSpace7.Name = "pnlSpace7"
        Me.pnlSpace7.numRows = 0
        Me.pnlSpace7.Reorder = True
        Me.pnlSpace7.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace7.TabIndex = 3
        '
        'dtdFSalida
        '
        Me.dtdFSalida.Allow_Empty = False
        Me.dtdFSalida.DataField = "FSALIDA_RES1"
        Me.dtdFSalida.DataTable = "R1"
        Me.dtdFSalida.Default_Value = Nothing
        Me.dtdFSalida.Descripcion = "Fecha Salida"
        Me.dtdFSalida.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtdFSalida.FocoEnAgregar = False
        Me.dtdFSalida.Label_Space = 95
        Me.dtdFSalida.Location = New System.Drawing.Point(81, 0)
        Me.dtdFSalida.Max_Value = Nothing
        Me.dtdFSalida.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdFSalida.MensajeIncorrectoCustom = Nothing
        Me.dtdFSalida.Min_Value = Nothing
        Me.dtdFSalida.MinDate = New Date(CType(0, Long))
        Me.dtdFSalida.MinimumSize = New System.Drawing.Size(185, 26)
        Me.dtdFSalida.Name = "dtdFSalida"
        Me.dtdFSalida.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdFSalida.ReadOnly_Data = False
        Me.dtdFSalida.Size = New System.Drawing.Size(185, 26)
        Me.dtdFSalida.TabIndex = 2
        Me.dtdFSalida.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdFSalida.Validate_on_lost_focus = True
        Me.dtdFSalida.Value_Data = New Date(2016, 6, 10, 0, 0, 0, 0)
        '
        'pnlSpace6
        '
        Me.pnlSpace6.Auto_Size = False
        Me.pnlSpace6.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace6.ChangeDock = True
        Me.pnlSpace6.Control_Resize = False
        Me.pnlSpace6.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace6.isSpace = True
        Me.pnlSpace6.Location = New System.Drawing.Point(75, 0)
        Me.pnlSpace6.Name = "pnlSpace6"
        Me.pnlSpace6.numRows = 0
        Me.pnlSpace6.Reorder = True
        Me.pnlSpace6.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace6.TabIndex = 1
        '
        'dtfDiasPrevistos
        '
        Me.dtfDiasPrevistos.Allow_Empty = False
        Me.dtfDiasPrevistos.Allow_Negative = False
        Me.dtfDiasPrevistos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfDiasPrevistos.BackColor = System.Drawing.SystemColors.Control
        Me.dtfDiasPrevistos.Data_Allowed = CustomControls.Datafield.List_Data.nInteger
        Me.dtfDiasPrevistos.DataField = "DIAS_RES1"
        Me.dtfDiasPrevistos.DataTable = "R1"
        Me.dtfDiasPrevistos.Descripcion = "Dias"
        Me.dtfDiasPrevistos.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfDiasPrevistos.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfDiasPrevistos.FocoEnAgregar = False
        Me.dtfDiasPrevistos.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfDiasPrevistos.Image = Nothing
        Me.dtfDiasPrevistos.Label_Space = 40
        Me.dtfDiasPrevistos.Length_Data = 32767
        Me.dtfDiasPrevistos.Location = New System.Drawing.Point(0, 0)
        Me.dtfDiasPrevistos.Max_Value = 0.0R
        Me.dtfDiasPrevistos.MensajeIncorrectoCustom = Nothing
        Me.dtfDiasPrevistos.Name = "dtfDiasPrevistos"
        Me.dtfDiasPrevistos.Null_on_Empty = True
        Me.dtfDiasPrevistos.OpenForm = Nothing
        Me.dtfDiasPrevistos.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfDiasPrevistos.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfDiasPrevistos.ReadOnly_Data = False
        Me.dtfDiasPrevistos.Show_Button = False
        Me.dtfDiasPrevistos.Size = New System.Drawing.Size(75, 26)
        Me.dtfDiasPrevistos.TabIndex = 0
        Me.dtfDiasPrevistos.Text_Data = ""
        Me.dtfDiasPrevistos.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfDiasPrevistos.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfDiasPrevistos.TopPadding = 0
        Me.dtfDiasPrevistos.Upper_Case = False
        Me.dtfDiasPrevistos.Validate_on_lost_focus = True
        '
        'pnlCodigo
        '
        Me.pnlCodigo.Auto_Size = False
        Me.pnlCodigo.BackColor = System.Drawing.SystemColors.Control
        Me.pnlCodigo.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlCodigo.ChangeDock = True
        Me.pnlCodigo.Control_Resize = False
        Me.pnlCodigo.Controls.Add(Me.dtdFecha)
        Me.pnlCodigo.Controls.Add(Me.pnlSpace5)
        Me.pnlCodigo.Controls.Add(Me.dttHora)
        Me.pnlCodigo.Controls.Add(Me.dtfRSC)
        Me.pnlCodigo.Controls.Add(Me.Space1)
        Me.pnlCodigo.Controls.Add(Me.pnlEO)
        Me.pnlCodigo.Controls.Add(Me.Space)
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
        'dtdFecha
        '
        Me.dtdFecha.Allow_Empty = True
        Me.dtdFecha.DataField = "FECHA_RES1"
        Me.dtdFecha.DataTable = "R1"
        Me.dtdFecha.Default_Value = New Date(2015, 8, 28, 0, 0, 0, 0)
        Me.dtdFecha.Descripcion = "Fecha"
        Me.dtdFecha.Dock = System.Windows.Forms.DockStyle.Right
        Me.dtdFecha.FocoEnAgregar = False
        Me.dtdFecha.Label_Space = 50
        Me.dtdFecha.Location = New System.Drawing.Point(911, 5)
        Me.dtdFecha.Max_Value = Nothing
        Me.dtdFecha.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdFecha.MensajeIncorrectoCustom = Nothing
        Me.dtdFecha.Min_Value = Nothing
        Me.dtdFecha.MinDate = New Date(CType(0, Long))
        Me.dtdFecha.MinimumSize = New System.Drawing.Size(140, 26)
        Me.dtdFecha.Name = "dtdFecha"
        Me.dtdFecha.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdFecha.ReadOnly_Data = False
        Me.dtdFecha.Size = New System.Drawing.Size(140, 26)
        Me.dtdFecha.TabIndex = 5
        Me.dtdFecha.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdFecha.Validate_on_lost_focus = True
        Me.dtdFecha.Value_Data = New Date(2015, 8, 28, 0, 0, 0, 0)
        '
        'pnlSpace5
        '
        Me.pnlSpace5.Auto_Size = False
        Me.pnlSpace5.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace5.ChangeDock = True
        Me.pnlSpace5.Control_Resize = False
        Me.pnlSpace5.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSpace5.isSpace = True
        Me.pnlSpace5.Location = New System.Drawing.Point(1051, 5)
        Me.pnlSpace5.Name = "pnlSpace5"
        Me.pnlSpace5.numRows = 0
        Me.pnlSpace5.Reorder = True
        Me.pnlSpace5.Size = New System.Drawing.Size(6, 20)
        Me.pnlSpace5.TabIndex = 6
        '
        'dttHora
        '
        Me.dttHora.Allow_Empty = True
        Me.dttHora.DataField = "HORA_RES1"
        Me.dttHora.DataTable = "R1"
        Me.dttHora.Descripcion = "Hora"
        Me.dttHora.Dock = System.Windows.Forms.DockStyle.Right
        Me.dttHora.FocoEnAgregar = False
        Me.dttHora.Location = New System.Drawing.Point(1057, 5)
        Me.dttHora.MensajeIncorrectoCustom = Nothing
        Me.dttHora.Name = "dttHora"
        Me.dttHora.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dttHora.ReadOnly_Data = False
        Me.dttHora.Size = New System.Drawing.Size(76, 20)
        Me.dttHora.TabIndex = 7
        Me.dttHora.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dttHora.Time = System.TimeSpan.Parse("10:59:00")
        Me.dttHora.Validate_on_lost_focus = True
        '
        'dtfRSC
        '
        Me.dtfRSC.Allow_Empty = True
        Me.dtfRSC.Allow_Negative = True
        Me.dtfRSC.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfRSC.BackColor = System.Drawing.SystemColors.Control
        Me.dtfRSC.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfRSC.DataField = "RENTAL1_RES1"
        Me.dtfRSC.DataTable = "R1"
        Me.dtfRSC.Descripcion = "RSC"
        Me.dtfRSC.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfRSC.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfRSC.FocoEnAgregar = False
        Me.dtfRSC.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfRSC.Image = Nothing
        Me.dtfRSC.Label_Space = 50
        Me.dtfRSC.Length_Data = 32767
        Me.dtfRSC.Location = New System.Drawing.Point(548, 5)
        Me.dtfRSC.Max_Value = 0.0R
        Me.dtfRSC.MensajeIncorrectoCustom = Nothing
        Me.dtfRSC.Name = "dtfRSC"
        Me.dtfRSC.Null_on_Empty = True
        Me.dtfRSC.OpenForm = Nothing
        Me.dtfRSC.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfRSC.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfRSC.ReadOnly_Data = True
        Me.dtfRSC.Show_Button = False
        Me.dtfRSC.Size = New System.Drawing.Size(90, 20)
        Me.dtfRSC.TabIndex = 4
        Me.dtfRSC.TabStop = False
        Me.dtfRSC.Text_Data = ""
        Me.dtfRSC.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfRSC.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfRSC.TopPadding = 0
        Me.dtfRSC.Upper_Case = True
        Me.dtfRSC.Validate_on_lost_focus = True
        '
        'Space1
        '
        Me.Space1.Auto_Size = False
        Me.Space1.BorderColor = System.Drawing.SystemColors.Control
        Me.Space1.ChangeDock = True
        Me.Space1.Control_Resize = False
        Me.Space1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Space1.isSpace = True
        Me.Space1.Location = New System.Drawing.Point(542, 5)
        Me.Space1.Name = "Space1"
        Me.Space1.numRows = 0
        Me.Space1.Reorder = True
        Me.Space1.Size = New System.Drawing.Size(6, 20)
        Me.Space1.TabIndex = 3
        '
        'pnlEO
        '
        Me.pnlEO.Auto_Size = False
        Me.pnlEO.BackColor = System.Drawing.SystemColors.Control
        Me.pnlEO.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlEO.ChangeDock = True
        Me.pnlEO.Control_Resize = False
        Me.pnlEO.Controls.Add(Me.dtfEmpresaOficina)
        Me.pnlEO.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlEO.isSpace = False
        Me.pnlEO.Location = New System.Drawing.Point(166, 5)
        Me.pnlEO.Name = "pnlEO"
        Me.pnlEO.numRows = 0
        Me.pnlEO.Reorder = True
        Me.pnlEO.Size = New System.Drawing.Size(376, 20)
        Me.pnlEO.TabIndex = 2
        '
        'dtfEmpresaOficina
        '
        Me.dtfEmpresaOficina.DataField_Empresa = "SUBLICEN_RES1"
        Me.dtfEmpresaOficina.DataField_Oficina = "OFICINA_RES1"
        Me.dtfEmpresaOficina.DataTable_Empresa = "R1"
        Me.dtfEmpresaOficina.DataTable_Oficina = "R1"
        Me.dtfEmpresaOficina.Descripcion = Nothing
        Me.dtfEmpresaOficina.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfEmpresaOficina.FocoEnAgregar = False
        Me.dtfEmpresaOficina.Location = New System.Drawing.Point(0, 0)
        Me.dtfEmpresaOficina.Lupa = Nothing
        Me.dtfEmpresaOficina.MensajeIncorrectoCustom = Nothing
        Me.dtfEmpresaOficina.Name = "dtfEmpresaOficina"
        Me.dtfEmpresaOficina.OficinaReadOnly = True
        Me.dtfEmpresaOficina.ShowLupa = False
        Me.dtfEmpresaOficina.Size = New System.Drawing.Size(376, 26)
        Me.dtfEmpresaOficina.Size_Empresa = 85
        Me.dtfEmpresaOficina.TabIndex = 0
        Me.dtfEmpresaOficina.Text_Empresa = ""
        Me.dtfEmpresaOficina.Text_Oficina = ""
        '
        'Space
        '
        Me.Space.Auto_Size = False
        Me.Space.BorderColor = System.Drawing.SystemColors.Control
        Me.Space.ChangeDock = True
        Me.Space.Control_Resize = False
        Me.Space.Dock = System.Windows.Forms.DockStyle.Left
        Me.Space.isSpace = True
        Me.Space.Location = New System.Drawing.Point(160, 5)
        Me.Space.Name = "Space"
        Me.Space.numRows = 0
        Me.Space.Reorder = True
        Me.Space.Size = New System.Drawing.Size(6, 20)
        Me.Space.TabIndex = 1
        '
        'dtfCodigo
        '
        Me.dtfCodigo.Allow_Empty = False
        Me.dtfCodigo.Allow_Negative = True
        Me.dtfCodigo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfCodigo.BackColor = System.Drawing.SystemColors.Control
        Me.dtfCodigo.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfCodigo.DataField = "NUMERO_RES"
        Me.dtfCodigo.DataTable = "R1"
        Me.dtfCodigo.Descripcion = "Número"
        Me.dtfCodigo.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfCodigo.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfCodigo.FocoEnAgregar = False
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
        Me.dtfCodigo.Size = New System.Drawing.Size(160, 20)
        Me.dtfCodigo.TabIndex = 0
        Me.dtfCodigo.TabStop = False
        Me.dtfCodigo.Text_Data = ""
        Me.dtfCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfCodigo.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfCodigo.TopPadding = 0
        Me.dtfCodigo.Upper_Case = True
        Me.dtfCodigo.Validate_on_lost_focus = True
        '
        'pnlBottomGen
        '
        Me.pnlBottomGen.Auto_Size = False
        Me.pnlBottomGen.BackColor = System.Drawing.SystemColors.Control
        Me.pnlBottomGen.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlBottomGen.ChangeDock = False
        Me.pnlBottomGen.Control_Resize = False
        Me.pnlBottomGen.Controls.Add(Me.dtlUltmodi)
        Me.pnlBottomGen.Controls.Add(Me.dtlUsumodi)
        Me.pnlBottomGen.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBottomGen.isSpace = False
        Me.pnlBottomGen.Location = New System.Drawing.Point(0, 533)
        Me.pnlBottomGen.Name = "pnlBottomGen"
        Me.pnlBottomGen.numRows = 1
        Me.pnlBottomGen.Reorder = True
        Me.pnlBottomGen.Size = New System.Drawing.Size(1138, 26)
        Me.pnlBottomGen.TabIndex = 12
        '
        'dtlUltmodi
        '
        Me.dtlUltmodi.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtlUltmodi.AutoSize = False
        Me.dtlUltmodi.BorderVisible = True
        Me.dtlUltmodi.DataField = "ULTMODI_RES1"
        Me.dtlUltmodi.DataTable = "R1"
        Me.dtlUltmodi.Descripcion = ""
        Me.dtlUltmodi.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtlUltmodi.Fromat = CustomControls.DataLabel.fotmatType.ultmodi
        Me.dtlUltmodi.Location = New System.Drawing.Point(1006, 6)
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
        Me.dtlUsumodi.DataField = "USUARIO_RES1"
        Me.dtlUsumodi.DataTable = "R1"
        Me.dtlUsumodi.Descripcion = ""
        Me.dtlUsumodi.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtlUsumodi.Fromat = CustomControls.DataLabel.fotmatType.plain
        Me.dtlUsumodi.Location = New System.Drawing.Point(962, 6)
        Me.dtlUsumodi.Name = "dtlUsumodi"
        Me.dtlUsumodi.Size = New System.Drawing.Size(38, 17)
        Me.dtlUsumodi.TabIndex = 0
        Me.dtlUsumodi.TextAlignment = System.Drawing.ContentAlignment.TopCenter
        '
        'pvpOtros
        '
        Me.pvpOtros.Controls.Add(Me.pnlCabeceraOtros)
        Me.pvpOtros.ItemSize = New System.Drawing.SizeF(83.0!, 23.0!)
        Me.pvpOtros.Location = New System.Drawing.Point(129, 5)
        Me.pvpOtros.Name = "pvpOtros"
        Me.pvpOtros.PanelCabezeraContainer = Me.pnlCabeceraOtros
        Me.pvpOtros.Size = New System.Drawing.Size(1138, 559)
        Me.pvpOtros.Text = "Otros"
        '
        'pnlCabeceraOtros
        '
        Me.pnlCabeceraOtros.Auto_Size = False
        Me.pnlCabeceraOtros.BackColor = System.Drawing.SystemColors.Control
        Me.pnlCabeceraOtros.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlCabeceraOtros.ChangeDock = False
        Me.pnlCabeceraOtros.Control_Resize = False
        Me.pnlCabeceraOtros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCabeceraOtros.isSpace = False
        Me.pnlCabeceraOtros.Location = New System.Drawing.Point(0, 0)
        Me.pnlCabeceraOtros.Name = "pnlCabeceraOtros"
        Me.pnlCabeceraOtros.numRows = 0
        Me.pnlCabeceraOtros.Reorder = True
        Me.pnlCabeceraOtros.Size = New System.Drawing.Size(1138, 80)
        Me.pnlCabeceraOtros.TabIndex = 1
        '
        'pvpCond
        '
        Me.pvpCond.Controls.Add(Me.pnlConductoresDer)
        Me.pvpCond.Controls.Add(Me.pnlConductoresIzq)
        Me.pvpCond.Controls.Add(Me.pnlCabeceraCond)
        Me.pvpCond.ItemSize = New System.Drawing.SizeF(83.0!, 23.0!)
        Me.pvpCond.Location = New System.Drawing.Point(129, 5)
        Me.pvpCond.Name = "pvpCond"
        Me.pvpCond.PanelCabezeraContainer = Me.pnlCabeceraCond
        Me.pvpCond.Size = New System.Drawing.Size(1138, 559)
        Me.pvpCond.Text = "Conductores"
        '
        'pnlCabeceraCond
        '
        Me.pnlCabeceraCond.Auto_Size = False
        Me.pnlCabeceraCond.BackColor = System.Drawing.SystemColors.Control
        Me.pnlCabeceraCond.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlCabeceraCond.ChangeDock = False
        Me.pnlCabeceraCond.Control_Resize = False
        Me.pnlCabeceraCond.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCabeceraCond.isSpace = False
        Me.pnlCabeceraCond.Location = New System.Drawing.Point(0, 0)
        Me.pnlCabeceraCond.Name = "pnlCabeceraCond"
        Me.pnlCabeceraCond.numRows = 0
        Me.pnlCabeceraCond.Reorder = True
        Me.pnlCabeceraCond.Size = New System.Drawing.Size(1138, 80)
        Me.pnlCabeceraCond.TabIndex = 1
        '
        'pnlConductoresDer
        '
        Me.pnlConductoresDer.Auto_Size = False
        Me.pnlConductoresDer.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlConductoresDer.ChangeDock = True
        Me.pnlConductoresDer.Control_Resize = False
        Me.pnlConductoresDer.Controls.Add(Me.gbxConductoresAdicionales)
        Me.pnlConductoresDer.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlConductoresDer.isSpace = False
        Me.pnlConductoresDer.Location = New System.Drawing.Point(568, 80)
        Me.pnlConductoresDer.Name = "pnlConductoresDer"
        Me.pnlConductoresDer.numRows = 0
        Me.pnlConductoresDer.Padding = New System.Windows.Forms.Padding(3)
        Me.pnlConductoresDer.Reorder = True
        Me.pnlConductoresDer.Size = New System.Drawing.Size(568, 479)
        Me.pnlConductoresDer.TabIndex = 5
        '
        'gbxConductoresAdicionales
        '
        Me.gbxConductoresAdicionales.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.gbxConductoresAdicionales.Controls.Add(Me.gbxOtroCond3)
        Me.gbxConductoresAdicionales.Controls.Add(Me.gbxOtroCond2)
        Me.gbxConductoresAdicionales.Controls.Add(Me.gbxOtroCond)
        Me.gbxConductoresAdicionales.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbxConductoresAdicionales.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.gbxConductoresAdicionales.HeaderText = "Conductores Adicionales"
        Me.gbxConductoresAdicionales.Location = New System.Drawing.Point(3, 3)
        Me.gbxConductoresAdicionales.Name = "gbxConductoresAdicionales"
        Me.gbxConductoresAdicionales.numRows = 0
        Me.gbxConductoresAdicionales.Padding = New System.Windows.Forms.Padding(6, 18, 6, 6)
        Me.gbxConductoresAdicionales.Reorder = True
        Me.gbxConductoresAdicionales.Size = New System.Drawing.Size(562, 318)
        Me.gbxConductoresAdicionales.TabIndex = 0
        Me.gbxConductoresAdicionales.Text = "Conductores Adicionales"
        Me.gbxConductoresAdicionales.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.gbxConductoresAdicionales.ThemeName = "Windows8"
        Me.gbxConductoresAdicionales.Title = "Conductores Adicionales"
        '
        'gbxOtroCond3
        '
        Me.gbxOtroCond3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.gbxOtroCond3.Controls.Add(Me.pnlOtroPermismo3)
        Me.gbxOtroCond3.Controls.Add(Me.pnlOtroFPermismo3)
        Me.gbxOtroCond3.Controls.Add(Me.dtfOtroCond3)
        Me.gbxOtroCond3.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbxOtroCond3.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.gbxOtroCond3.HeaderText = "Conductor Adicional"
        Me.gbxOtroCond3.Location = New System.Drawing.Point(6, 214)
        Me.gbxOtroCond3.Name = "gbxOtroCond3"
        Me.gbxOtroCond3.numRows = 3
        Me.gbxOtroCond3.Padding = New System.Windows.Forms.Padding(6, 18, 6, 6)
        Me.gbxOtroCond3.Reorder = True
        Me.gbxOtroCond3.Size = New System.Drawing.Size(550, 98)
        Me.gbxOtroCond3.TabIndex = 2
        Me.gbxOtroCond3.Text = "Conductor Adicional"
        Me.gbxOtroCond3.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.gbxOtroCond3.ThemeName = "Windows8"
        Me.gbxOtroCond3.Title = "Conductor Adicional"
        '
        'pnlOtroPermismo3
        '
        Me.pnlOtroPermismo3.Auto_Size = False
        Me.pnlOtroPermismo3.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlOtroPermismo3.ChangeDock = False
        Me.pnlOtroPermismo3.Control_Resize = False
        Me.pnlOtroPermismo3.Controls.Add(Me.dtdOtroNac3)
        Me.pnlOtroPermismo3.Controls.Add(Me.dtfOtroPer3)
        Me.pnlOtroPermismo3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlOtroPermismo3.isSpace = False
        Me.pnlOtroPermismo3.Location = New System.Drawing.Point(6, 44)
        Me.pnlOtroPermismo3.Name = "pnlOtroPermismo3"
        Me.pnlOtroPermismo3.numRows = 0
        Me.pnlOtroPermismo3.Reorder = True
        Me.pnlOtroPermismo3.Size = New System.Drawing.Size(352, 48)
        Me.pnlOtroPermismo3.TabIndex = 1
        '
        'dtdOtroNac3
        '
        Me.dtdOtroNac3.Allow_Empty = True
        Me.dtdOtroNac3.DataField = "OTRONAC3_CON2"
        Me.dtdOtroNac3.DataTable = "C2"
        Me.dtdOtroNac3.Default_Value = New Date(2015, 10, 7, 0, 0, 0, 0)
        Me.dtdOtroNac3.Descripcion = "F. Nacimiento"
        Me.dtdOtroNac3.Dock = System.Windows.Forms.DockStyle.Right
        Me.dtdOtroNac3.FocoEnAgregar = False
        Me.dtdOtroNac3.Label_Space = 90
        Me.dtdOtroNac3.Location = New System.Drawing.Point(172, 26)
        Me.dtdOtroNac3.Max_Value = Nothing
        Me.dtdOtroNac3.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdOtroNac3.MensajeIncorrectoCustom = Nothing
        Me.dtdOtroNac3.Min_Value = Nothing
        Me.dtdOtroNac3.MinDate = New Date(CType(0, Long))
        Me.dtdOtroNac3.MinimumSize = New System.Drawing.Size(180, 26)
        Me.dtdOtroNac3.Name = "dtdOtroNac3"
        Me.dtdOtroNac3.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdOtroNac3.ReadOnly_Data = False
        Me.dtdOtroNac3.Size = New System.Drawing.Size(180, 26)
        Me.dtdOtroNac3.TabIndex = 1
        Me.dtdOtroNac3.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdOtroNac3.Validate_on_lost_focus = True
        Me.dtdOtroNac3.Value_Data = New Date(2015, 10, 7, 0, 0, 0, 0)
        '
        'dtfOtroPer3
        '
        Me.dtfOtroPer3.Allow_Empty = True
        Me.dtfOtroPer3.Allow_Negative = True
        Me.dtfOtroPer3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfOtroPer3.BackColor = System.Drawing.SystemColors.Control
        Me.dtfOtroPer3.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfOtroPer3.DataField = "OTRO3PER_CON2"
        Me.dtfOtroPer3.DataTable = "C2"
        Me.dtfOtroPer3.Descripcion = "Permiso"
        Me.dtfOtroPer3.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfOtroPer3.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfOtroPer3.FocoEnAgregar = False
        Me.dtfOtroPer3.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfOtroPer3.Image = Nothing
        Me.dtfOtroPer3.Label_Space = 75
        Me.dtfOtroPer3.Length_Data = 32767
        Me.dtfOtroPer3.Location = New System.Drawing.Point(0, 0)
        Me.dtfOtroPer3.Max_Value = 0.0R
        Me.dtfOtroPer3.MensajeIncorrectoCustom = Nothing
        Me.dtfOtroPer3.Name = "dtfOtroPer3"
        Me.dtfOtroPer3.Null_on_Empty = True
        Me.dtfOtroPer3.OpenForm = Nothing
        Me.dtfOtroPer3.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfOtroPer3.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfOtroPer3.ReadOnly_Data = False
        Me.dtfOtroPer3.Show_Button = False
        Me.dtfOtroPer3.Size = New System.Drawing.Size(352, 26)
        Me.dtfOtroPer3.TabIndex = 0
        Me.dtfOtroPer3.Text_Data = ""
        Me.dtfOtroPer3.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfOtroPer3.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfOtroPer3.TopPadding = 0
        Me.dtfOtroPer3.Upper_Case = False
        Me.dtfOtroPer3.Validate_on_lost_focus = True
        '
        'pnlOtroFPermismo3
        '
        Me.pnlOtroFPermismo3.Auto_Size = False
        Me.pnlOtroFPermismo3.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlOtroFPermismo3.ChangeDock = False
        Me.pnlOtroFPermismo3.Control_Resize = False
        Me.pnlOtroFPermismo3.Controls.Add(Me.dtdOtroCadu3)
        Me.pnlOtroFPermismo3.Controls.Add(Me.dtdOtroExpe3)
        Me.pnlOtroFPermismo3.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlOtroFPermismo3.isSpace = False
        Me.pnlOtroFPermismo3.Location = New System.Drawing.Point(358, 44)
        Me.pnlOtroFPermismo3.Name = "pnlOtroFPermismo3"
        Me.pnlOtroFPermismo3.numRows = 0
        Me.pnlOtroFPermismo3.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.pnlOtroFPermismo3.Reorder = True
        Me.pnlOtroFPermismo3.Size = New System.Drawing.Size(186, 48)
        Me.pnlOtroFPermismo3.TabIndex = 2
        '
        'dtdOtroCadu3
        '
        Me.dtdOtroCadu3.Allow_Empty = True
        Me.dtdOtroCadu3.DataField = "OTRO3FVTO_CON2"
        Me.dtdOtroCadu3.DataTable = "C2"
        Me.dtdOtroCadu3.Default_Value = New Date(2015, 10, 7, 0, 0, 0, 0)
        Me.dtdOtroCadu3.Descripcion = "F. Caducidad"
        Me.dtdOtroCadu3.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtdOtroCadu3.FocoEnAgregar = False
        Me.dtdOtroCadu3.Label_Space = 90
        Me.dtdOtroCadu3.Location = New System.Drawing.Point(6, 26)
        Me.dtdOtroCadu3.Max_Value = Nothing
        Me.dtdOtroCadu3.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdOtroCadu3.MensajeIncorrectoCustom = Nothing
        Me.dtdOtroCadu3.Min_Value = Nothing
        Me.dtdOtroCadu3.MinDate = New Date(CType(0, Long))
        Me.dtdOtroCadu3.MinimumSize = New System.Drawing.Size(180, 26)
        Me.dtdOtroCadu3.Name = "dtdOtroCadu3"
        Me.dtdOtroCadu3.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdOtroCadu3.ReadOnly_Data = False
        Me.dtdOtroCadu3.Size = New System.Drawing.Size(180, 26)
        Me.dtdOtroCadu3.TabIndex = 1
        Me.dtdOtroCadu3.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdOtroCadu3.Validate_on_lost_focus = True
        Me.dtdOtroCadu3.Value_Data = New Date(2015, 10, 7, 0, 0, 0, 0)
        '
        'dtdOtroExpe3
        '
        Me.dtdOtroExpe3.Allow_Empty = True
        Me.dtdOtroExpe3.DataField = "OTRO3FEXPE_CON2"
        Me.dtdOtroExpe3.DataTable = "C2"
        Me.dtdOtroExpe3.Default_Value = New Date(2015, 10, 7, 0, 0, 0, 0)
        Me.dtdOtroExpe3.Descripcion = "F. Expedicion"
        Me.dtdOtroExpe3.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtdOtroExpe3.FocoEnAgregar = False
        Me.dtdOtroExpe3.Label_Space = 90
        Me.dtdOtroExpe3.Location = New System.Drawing.Point(6, 0)
        Me.dtdOtroExpe3.Max_Value = Nothing
        Me.dtdOtroExpe3.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdOtroExpe3.MensajeIncorrectoCustom = Nothing
        Me.dtdOtroExpe3.Min_Value = Nothing
        Me.dtdOtroExpe3.MinDate = New Date(CType(0, Long))
        Me.dtdOtroExpe3.MinimumSize = New System.Drawing.Size(180, 26)
        Me.dtdOtroExpe3.Name = "dtdOtroExpe3"
        Me.dtdOtroExpe3.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdOtroExpe3.ReadOnly_Data = False
        Me.dtdOtroExpe3.Size = New System.Drawing.Size(180, 26)
        Me.dtdOtroExpe3.TabIndex = 0
        Me.dtdOtroExpe3.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdOtroExpe3.Validate_on_lost_focus = True
        Me.dtdOtroExpe3.Value_Data = New Date(2015, 10, 7, 0, 0, 0, 0)
        '
        'dtfOtroCond3
        '
        Me.dtfOtroCond3.Allow_Empty = True
        Me.dtfOtroCond3.Allow_Negative = True
        Me.dtfOtroCond3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfOtroCond3.BackColor = System.Drawing.SystemColors.Control
        Me.dtfOtroCond3.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfOtroCond3.DataField = "OTRO3COND_CON2"
        Me.dtfOtroCond3.DataTable = "C2"
        Me.dtfOtroCond3.DB = Connection38
        Me.dtfOtroCond3.Desc_Datafield = "NOMBRE"
        Me.dtfOtroCond3.Desc_DBPK = "NUMERO_CLI"
        Me.dtfOtroCond3.Desc_DBTable = "CLIENTES1"
        Me.dtfOtroCond3.Desc_Where = Nothing
        Me.dtfOtroCond3.Desc_WhereObligatoria = Nothing
        Me.dtfOtroCond3.Descripcion = "Conductor"
        Me.dtfOtroCond3.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfOtroCond3.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfOtroCond3.ExtraSQL = ""
        Me.dtfOtroCond3.FocoEnAgregar = False
        Me.dtfOtroCond3.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfOtroCond3.Formulario = Nothing
        Me.dtfOtroCond3.Label_Space = 75
        Me.dtfOtroCond3.Length_Data = 32767
        Me.dtfOtroCond3.Location = New System.Drawing.Point(6, 18)
        Me.dtfOtroCond3.Lupa = Nothing
        Me.dtfOtroCond3.Max_Value = 0.0R
        Me.dtfOtroCond3.MensajeIncorrectoCustom = Nothing
        Me.dtfOtroCond3.Name = "dtfOtroCond3"
        Me.dtfOtroCond3.Null_on_Empty = True
        Me.dtfOtroCond3.OpenForm = Nothing
        Me.dtfOtroCond3.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfOtroCond3.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfOtroCond3.Query_on_Text_Changed = True
        Me.dtfOtroCond3.ReadOnly_Data = False
        Me.dtfOtroCond3.ReQuery = False
        Me.dtfOtroCond3.ShowButton = True
        Me.dtfOtroCond3.Size = New System.Drawing.Size(538, 26)
        Me.dtfOtroCond3.TabIndex = 0
        Me.dtfOtroCond3.Text_Data = ""
        Me.dtfOtroCond3.Text_Data_Desc = ""
        Me.dtfOtroCond3.Text_Width = 58
        Me.dtfOtroCond3.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfOtroCond3.TopPadding = 0
        Me.dtfOtroCond3.Upper_Case = False
        Me.dtfOtroCond3.Validate_on_lost_focus = True
        '
        'gbxOtroCond2
        '
        Me.gbxOtroCond2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.gbxOtroCond2.Controls.Add(Me.pnlOtroPermismo2)
        Me.gbxOtroCond2.Controls.Add(Me.pnlOtroFPermismo2)
        Me.gbxOtroCond2.Controls.Add(Me.dtfOtroCond2)
        Me.gbxOtroCond2.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbxOtroCond2.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.gbxOtroCond2.HeaderText = "Conductor Adicional"
        Me.gbxOtroCond2.Location = New System.Drawing.Point(6, 116)
        Me.gbxOtroCond2.Name = "gbxOtroCond2"
        Me.gbxOtroCond2.numRows = 3
        Me.gbxOtroCond2.Padding = New System.Windows.Forms.Padding(6, 18, 6, 6)
        Me.gbxOtroCond2.Reorder = True
        Me.gbxOtroCond2.Size = New System.Drawing.Size(550, 98)
        Me.gbxOtroCond2.TabIndex = 1
        Me.gbxOtroCond2.Text = "Conductor Adicional"
        Me.gbxOtroCond2.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.gbxOtroCond2.ThemeName = "Windows8"
        Me.gbxOtroCond2.Title = "Conductor Adicional"
        '
        'pnlOtroPermismo2
        '
        Me.pnlOtroPermismo2.Auto_Size = False
        Me.pnlOtroPermismo2.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlOtroPermismo2.ChangeDock = False
        Me.pnlOtroPermismo2.Control_Resize = False
        Me.pnlOtroPermismo2.Controls.Add(Me.dtdOtroNac2)
        Me.pnlOtroPermismo2.Controls.Add(Me.dtfOtroPer2)
        Me.pnlOtroPermismo2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlOtroPermismo2.isSpace = False
        Me.pnlOtroPermismo2.Location = New System.Drawing.Point(6, 44)
        Me.pnlOtroPermismo2.Name = "pnlOtroPermismo2"
        Me.pnlOtroPermismo2.numRows = 0
        Me.pnlOtroPermismo2.Reorder = True
        Me.pnlOtroPermismo2.Size = New System.Drawing.Size(352, 48)
        Me.pnlOtroPermismo2.TabIndex = 1
        '
        'dtdOtroNac2
        '
        Me.dtdOtroNac2.Allow_Empty = True
        Me.dtdOtroNac2.DataField = "OTRONAC2_CON2"
        Me.dtdOtroNac2.DataTable = "C2"
        Me.dtdOtroNac2.Default_Value = New Date(2015, 10, 7, 0, 0, 0, 0)
        Me.dtdOtroNac2.Descripcion = "F. Nacimiento"
        Me.dtdOtroNac2.Dock = System.Windows.Forms.DockStyle.Right
        Me.dtdOtroNac2.FocoEnAgregar = False
        Me.dtdOtroNac2.Label_Space = 90
        Me.dtdOtroNac2.Location = New System.Drawing.Point(172, 26)
        Me.dtdOtroNac2.Max_Value = Nothing
        Me.dtdOtroNac2.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdOtroNac2.MensajeIncorrectoCustom = Nothing
        Me.dtdOtroNac2.Min_Value = Nothing
        Me.dtdOtroNac2.MinDate = New Date(CType(0, Long))
        Me.dtdOtroNac2.MinimumSize = New System.Drawing.Size(180, 26)
        Me.dtdOtroNac2.Name = "dtdOtroNac2"
        Me.dtdOtroNac2.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdOtroNac2.ReadOnly_Data = False
        Me.dtdOtroNac2.Size = New System.Drawing.Size(180, 26)
        Me.dtdOtroNac2.TabIndex = 1
        Me.dtdOtroNac2.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdOtroNac2.Validate_on_lost_focus = True
        Me.dtdOtroNac2.Value_Data = New Date(2015, 10, 7, 0, 0, 0, 0)
        '
        'dtfOtroPer2
        '
        Me.dtfOtroPer2.Allow_Empty = True
        Me.dtfOtroPer2.Allow_Negative = True
        Me.dtfOtroPer2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfOtroPer2.BackColor = System.Drawing.SystemColors.Control
        Me.dtfOtroPer2.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfOtroPer2.DataField = "OTRO2PER_CON2"
        Me.dtfOtroPer2.DataTable = "C2"
        Me.dtfOtroPer2.Descripcion = "Permiso"
        Me.dtfOtroPer2.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfOtroPer2.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfOtroPer2.FocoEnAgregar = False
        Me.dtfOtroPer2.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfOtroPer2.Image = Nothing
        Me.dtfOtroPer2.Label_Space = 75
        Me.dtfOtroPer2.Length_Data = 32767
        Me.dtfOtroPer2.Location = New System.Drawing.Point(0, 0)
        Me.dtfOtroPer2.Max_Value = 0.0R
        Me.dtfOtroPer2.MensajeIncorrectoCustom = Nothing
        Me.dtfOtroPer2.Name = "dtfOtroPer2"
        Me.dtfOtroPer2.Null_on_Empty = True
        Me.dtfOtroPer2.OpenForm = Nothing
        Me.dtfOtroPer2.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfOtroPer2.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfOtroPer2.ReadOnly_Data = False
        Me.dtfOtroPer2.Show_Button = False
        Me.dtfOtroPer2.Size = New System.Drawing.Size(352, 26)
        Me.dtfOtroPer2.TabIndex = 0
        Me.dtfOtroPer2.Text_Data = ""
        Me.dtfOtroPer2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfOtroPer2.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfOtroPer2.TopPadding = 0
        Me.dtfOtroPer2.Upper_Case = False
        Me.dtfOtroPer2.Validate_on_lost_focus = True
        '
        'pnlOtroFPermismo2
        '
        Me.pnlOtroFPermismo2.Auto_Size = False
        Me.pnlOtroFPermismo2.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlOtroFPermismo2.ChangeDock = False
        Me.pnlOtroFPermismo2.Control_Resize = False
        Me.pnlOtroFPermismo2.Controls.Add(Me.dtdOtroCadu2)
        Me.pnlOtroFPermismo2.Controls.Add(Me.dtdOtroExpe2)
        Me.pnlOtroFPermismo2.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlOtroFPermismo2.isSpace = False
        Me.pnlOtroFPermismo2.Location = New System.Drawing.Point(358, 44)
        Me.pnlOtroFPermismo2.Name = "pnlOtroFPermismo2"
        Me.pnlOtroFPermismo2.numRows = 0
        Me.pnlOtroFPermismo2.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.pnlOtroFPermismo2.Reorder = True
        Me.pnlOtroFPermismo2.Size = New System.Drawing.Size(186, 48)
        Me.pnlOtroFPermismo2.TabIndex = 2
        '
        'dtdOtroCadu2
        '
        Me.dtdOtroCadu2.Allow_Empty = True
        Me.dtdOtroCadu2.DataField = "OTRO2FVTO_CON2"
        Me.dtdOtroCadu2.DataTable = "C2"
        Me.dtdOtroCadu2.Default_Value = New Date(2015, 10, 7, 0, 0, 0, 0)
        Me.dtdOtroCadu2.Descripcion = "F. Caducidad"
        Me.dtdOtroCadu2.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtdOtroCadu2.FocoEnAgregar = False
        Me.dtdOtroCadu2.Label_Space = 90
        Me.dtdOtroCadu2.Location = New System.Drawing.Point(6, 26)
        Me.dtdOtroCadu2.Max_Value = Nothing
        Me.dtdOtroCadu2.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdOtroCadu2.MensajeIncorrectoCustom = Nothing
        Me.dtdOtroCadu2.Min_Value = Nothing
        Me.dtdOtroCadu2.MinDate = New Date(CType(0, Long))
        Me.dtdOtroCadu2.MinimumSize = New System.Drawing.Size(180, 26)
        Me.dtdOtroCadu2.Name = "dtdOtroCadu2"
        Me.dtdOtroCadu2.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdOtroCadu2.ReadOnly_Data = False
        Me.dtdOtroCadu2.Size = New System.Drawing.Size(180, 26)
        Me.dtdOtroCadu2.TabIndex = 1
        Me.dtdOtroCadu2.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdOtroCadu2.Validate_on_lost_focus = True
        Me.dtdOtroCadu2.Value_Data = New Date(2015, 10, 7, 0, 0, 0, 0)
        '
        'dtdOtroExpe2
        '
        Me.dtdOtroExpe2.Allow_Empty = True
        Me.dtdOtroExpe2.DataField = "OTRO2FEXPE_CON2"
        Me.dtdOtroExpe2.DataTable = "C2"
        Me.dtdOtroExpe2.Default_Value = New Date(2015, 10, 7, 0, 0, 0, 0)
        Me.dtdOtroExpe2.Descripcion = "F. Expedicion"
        Me.dtdOtroExpe2.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtdOtroExpe2.FocoEnAgregar = False
        Me.dtdOtroExpe2.Label_Space = 90
        Me.dtdOtroExpe2.Location = New System.Drawing.Point(6, 0)
        Me.dtdOtroExpe2.Max_Value = Nothing
        Me.dtdOtroExpe2.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdOtroExpe2.MensajeIncorrectoCustom = Nothing
        Me.dtdOtroExpe2.Min_Value = Nothing
        Me.dtdOtroExpe2.MinDate = New Date(CType(0, Long))
        Me.dtdOtroExpe2.MinimumSize = New System.Drawing.Size(180, 26)
        Me.dtdOtroExpe2.Name = "dtdOtroExpe2"
        Me.dtdOtroExpe2.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdOtroExpe2.ReadOnly_Data = False
        Me.dtdOtroExpe2.Size = New System.Drawing.Size(180, 26)
        Me.dtdOtroExpe2.TabIndex = 0
        Me.dtdOtroExpe2.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdOtroExpe2.Validate_on_lost_focus = True
        Me.dtdOtroExpe2.Value_Data = New Date(2015, 10, 7, 0, 0, 0, 0)
        '
        'dtfOtroCond2
        '
        Me.dtfOtroCond2.Allow_Empty = True
        Me.dtfOtroCond2.Allow_Negative = True
        Me.dtfOtroCond2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfOtroCond2.BackColor = System.Drawing.SystemColors.Control
        Me.dtfOtroCond2.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfOtroCond2.DataField = "OTRO2COND_CON2"
        Me.dtfOtroCond2.DataTable = "C2"
        Me.dtfOtroCond2.DB = Connection39
        Me.dtfOtroCond2.Desc_Datafield = "NOMBRE"
        Me.dtfOtroCond2.Desc_DBPK = "NUMERO_CLI"
        Me.dtfOtroCond2.Desc_DBTable = "CLIENTES1"
        Me.dtfOtroCond2.Desc_Where = Nothing
        Me.dtfOtroCond2.Desc_WhereObligatoria = Nothing
        Me.dtfOtroCond2.Descripcion = "Conductor"
        Me.dtfOtroCond2.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfOtroCond2.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfOtroCond2.ExtraSQL = ""
        Me.dtfOtroCond2.FocoEnAgregar = False
        Me.dtfOtroCond2.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfOtroCond2.Formulario = Nothing
        Me.dtfOtroCond2.Label_Space = 75
        Me.dtfOtroCond2.Length_Data = 32767
        Me.dtfOtroCond2.Location = New System.Drawing.Point(6, 18)
        Me.dtfOtroCond2.Lupa = Nothing
        Me.dtfOtroCond2.Max_Value = 0.0R
        Me.dtfOtroCond2.MensajeIncorrectoCustom = Nothing
        Me.dtfOtroCond2.Name = "dtfOtroCond2"
        Me.dtfOtroCond2.Null_on_Empty = True
        Me.dtfOtroCond2.OpenForm = Nothing
        Me.dtfOtroCond2.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfOtroCond2.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfOtroCond2.Query_on_Text_Changed = True
        Me.dtfOtroCond2.ReadOnly_Data = False
        Me.dtfOtroCond2.ReQuery = False
        Me.dtfOtroCond2.ShowButton = True
        Me.dtfOtroCond2.Size = New System.Drawing.Size(538, 26)
        Me.dtfOtroCond2.TabIndex = 0
        Me.dtfOtroCond2.Text_Data = ""
        Me.dtfOtroCond2.Text_Data_Desc = ""
        Me.dtfOtroCond2.Text_Width = 58
        Me.dtfOtroCond2.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfOtroCond2.TopPadding = 0
        Me.dtfOtroCond2.Upper_Case = False
        Me.dtfOtroCond2.Validate_on_lost_focus = True
        '
        'gbxOtroCond
        '
        Me.gbxOtroCond.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.gbxOtroCond.Controls.Add(Me.pnlOtroPermismo)
        Me.gbxOtroCond.Controls.Add(Me.pnlOtroFPermismo)
        Me.gbxOtroCond.Controls.Add(Me.dtfOtroCond)
        Me.gbxOtroCond.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbxOtroCond.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.gbxOtroCond.HeaderText = "Conductor Adicional"
        Me.gbxOtroCond.Location = New System.Drawing.Point(6, 18)
        Me.gbxOtroCond.Name = "gbxOtroCond"
        Me.gbxOtroCond.numRows = 3
        Me.gbxOtroCond.Padding = New System.Windows.Forms.Padding(6, 18, 6, 6)
        Me.gbxOtroCond.Reorder = True
        Me.gbxOtroCond.Size = New System.Drawing.Size(550, 98)
        Me.gbxOtroCond.TabIndex = 0
        Me.gbxOtroCond.Text = "Conductor Adicional"
        Me.gbxOtroCond.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.gbxOtroCond.ThemeName = "Windows8"
        Me.gbxOtroCond.Title = "Conductor Adicional"
        '
        'pnlOtroPermismo
        '
        Me.pnlOtroPermismo.Auto_Size = False
        Me.pnlOtroPermismo.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlOtroPermismo.ChangeDock = False
        Me.pnlOtroPermismo.Control_Resize = False
        Me.pnlOtroPermismo.Controls.Add(Me.dtdOtroNac)
        Me.pnlOtroPermismo.Controls.Add(Me.dtfOtroPer)
        Me.pnlOtroPermismo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlOtroPermismo.isSpace = False
        Me.pnlOtroPermismo.Location = New System.Drawing.Point(6, 44)
        Me.pnlOtroPermismo.Name = "pnlOtroPermismo"
        Me.pnlOtroPermismo.numRows = 0
        Me.pnlOtroPermismo.Reorder = True
        Me.pnlOtroPermismo.Size = New System.Drawing.Size(352, 48)
        Me.pnlOtroPermismo.TabIndex = 1
        '
        'dtdOtroNac
        '
        Me.dtdOtroNac.Allow_Empty = True
        Me.dtdOtroNac.DataField = "OTRONAC_CON2"
        Me.dtdOtroNac.DataTable = "C2"
        Me.dtdOtroNac.Default_Value = New Date(2015, 10, 7, 0, 0, 0, 0)
        Me.dtdOtroNac.Descripcion = "F. Nacimiento"
        Me.dtdOtroNac.Dock = System.Windows.Forms.DockStyle.Right
        Me.dtdOtroNac.FocoEnAgregar = False
        Me.dtdOtroNac.Label_Space = 90
        Me.dtdOtroNac.Location = New System.Drawing.Point(172, 26)
        Me.dtdOtroNac.Max_Value = Nothing
        Me.dtdOtroNac.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdOtroNac.MensajeIncorrectoCustom = Nothing
        Me.dtdOtroNac.Min_Value = Nothing
        Me.dtdOtroNac.MinDate = New Date(CType(0, Long))
        Me.dtdOtroNac.MinimumSize = New System.Drawing.Size(180, 26)
        Me.dtdOtroNac.Name = "dtdOtroNac"
        Me.dtdOtroNac.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdOtroNac.ReadOnly_Data = False
        Me.dtdOtroNac.Size = New System.Drawing.Size(180, 26)
        Me.dtdOtroNac.TabIndex = 1
        Me.dtdOtroNac.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdOtroNac.Validate_on_lost_focus = True
        Me.dtdOtroNac.Value_Data = New Date(2015, 10, 7, 0, 0, 0, 0)
        '
        'dtfOtroPer
        '
        Me.dtfOtroPer.Allow_Empty = True
        Me.dtfOtroPer.Allow_Negative = True
        Me.dtfOtroPer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfOtroPer.BackColor = System.Drawing.SystemColors.Control
        Me.dtfOtroPer.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfOtroPer.DataField = "OTROPER_CON2"
        Me.dtfOtroPer.DataTable = "C2"
        Me.dtfOtroPer.Descripcion = "Permiso"
        Me.dtfOtroPer.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfOtroPer.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfOtroPer.FocoEnAgregar = False
        Me.dtfOtroPer.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfOtroPer.Image = Nothing
        Me.dtfOtroPer.Label_Space = 75
        Me.dtfOtroPer.Length_Data = 32767
        Me.dtfOtroPer.Location = New System.Drawing.Point(0, 0)
        Me.dtfOtroPer.Max_Value = 0.0R
        Me.dtfOtroPer.MensajeIncorrectoCustom = Nothing
        Me.dtfOtroPer.Name = "dtfOtroPer"
        Me.dtfOtroPer.Null_on_Empty = True
        Me.dtfOtroPer.OpenForm = Nothing
        Me.dtfOtroPer.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfOtroPer.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfOtroPer.ReadOnly_Data = False
        Me.dtfOtroPer.Show_Button = False
        Me.dtfOtroPer.Size = New System.Drawing.Size(352, 26)
        Me.dtfOtroPer.TabIndex = 0
        Me.dtfOtroPer.Text_Data = ""
        Me.dtfOtroPer.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfOtroPer.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfOtroPer.TopPadding = 0
        Me.dtfOtroPer.Upper_Case = False
        Me.dtfOtroPer.Validate_on_lost_focus = True
        '
        'pnlOtroFPermismo
        '
        Me.pnlOtroFPermismo.Auto_Size = False
        Me.pnlOtroFPermismo.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlOtroFPermismo.ChangeDock = False
        Me.pnlOtroFPermismo.Control_Resize = False
        Me.pnlOtroFPermismo.Controls.Add(Me.dtdOtroCadu)
        Me.pnlOtroFPermismo.Controls.Add(Me.dtdOtroExpe)
        Me.pnlOtroFPermismo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlOtroFPermismo.isSpace = False
        Me.pnlOtroFPermismo.Location = New System.Drawing.Point(358, 44)
        Me.pnlOtroFPermismo.Name = "pnlOtroFPermismo"
        Me.pnlOtroFPermismo.numRows = 0
        Me.pnlOtroFPermismo.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.pnlOtroFPermismo.Reorder = True
        Me.pnlOtroFPermismo.Size = New System.Drawing.Size(186, 48)
        Me.pnlOtroFPermismo.TabIndex = 2
        '
        'dtdOtroCadu
        '
        Me.dtdOtroCadu.Allow_Empty = True
        Me.dtdOtroCadu.DataField = "OTROFVTO_CON2"
        Me.dtdOtroCadu.DataTable = "C2"
        Me.dtdOtroCadu.Default_Value = New Date(2015, 10, 7, 0, 0, 0, 0)
        Me.dtdOtroCadu.Descripcion = "F. Caducidad"
        Me.dtdOtroCadu.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtdOtroCadu.FocoEnAgregar = False
        Me.dtdOtroCadu.Label_Space = 90
        Me.dtdOtroCadu.Location = New System.Drawing.Point(6, 26)
        Me.dtdOtroCadu.Max_Value = Nothing
        Me.dtdOtroCadu.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdOtroCadu.MensajeIncorrectoCustom = Nothing
        Me.dtdOtroCadu.Min_Value = Nothing
        Me.dtdOtroCadu.MinDate = New Date(CType(0, Long))
        Me.dtdOtroCadu.MinimumSize = New System.Drawing.Size(180, 26)
        Me.dtdOtroCadu.Name = "dtdOtroCadu"
        Me.dtdOtroCadu.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdOtroCadu.ReadOnly_Data = False
        Me.dtdOtroCadu.Size = New System.Drawing.Size(180, 26)
        Me.dtdOtroCadu.TabIndex = 1
        Me.dtdOtroCadu.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdOtroCadu.Validate_on_lost_focus = True
        Me.dtdOtroCadu.Value_Data = New Date(2015, 10, 7, 0, 0, 0, 0)
        '
        'dtdOtroExpe
        '
        Me.dtdOtroExpe.Allow_Empty = True
        Me.dtdOtroExpe.DataField = "OTROFEXPE_CON2"
        Me.dtdOtroExpe.DataTable = "C2"
        Me.dtdOtroExpe.Default_Value = New Date(2015, 10, 7, 0, 0, 0, 0)
        Me.dtdOtroExpe.Descripcion = "F. Expedicion"
        Me.dtdOtroExpe.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtdOtroExpe.FocoEnAgregar = False
        Me.dtdOtroExpe.Label_Space = 90
        Me.dtdOtroExpe.Location = New System.Drawing.Point(6, 0)
        Me.dtdOtroExpe.Max_Value = Nothing
        Me.dtdOtroExpe.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdOtroExpe.MensajeIncorrectoCustom = Nothing
        Me.dtdOtroExpe.Min_Value = Nothing
        Me.dtdOtroExpe.MinDate = New Date(CType(0, Long))
        Me.dtdOtroExpe.MinimumSize = New System.Drawing.Size(180, 26)
        Me.dtdOtroExpe.Name = "dtdOtroExpe"
        Me.dtdOtroExpe.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdOtroExpe.ReadOnly_Data = False
        Me.dtdOtroExpe.Size = New System.Drawing.Size(180, 26)
        Me.dtdOtroExpe.TabIndex = 0
        Me.dtdOtroExpe.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdOtroExpe.Validate_on_lost_focus = True
        Me.dtdOtroExpe.Value_Data = New Date(2015, 10, 7, 0, 0, 0, 0)
        '
        'dtfOtroCond
        '
        Me.dtfOtroCond.Allow_Empty = True
        Me.dtfOtroCond.Allow_Negative = True
        Me.dtfOtroCond.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfOtroCond.BackColor = System.Drawing.SystemColors.Control
        Me.dtfOtroCond.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfOtroCond.DataField = "OTROCOND_CON2"
        Me.dtfOtroCond.DataTable = "C2"
        Me.dtfOtroCond.DB = Connection40
        Me.dtfOtroCond.Desc_Datafield = "NOMBRE"
        Me.dtfOtroCond.Desc_DBPK = "NUMERO_CLI"
        Me.dtfOtroCond.Desc_DBTable = "CLIENTES1"
        Me.dtfOtroCond.Desc_Where = Nothing
        Me.dtfOtroCond.Desc_WhereObligatoria = Nothing
        Me.dtfOtroCond.Descripcion = "Conductor"
        Me.dtfOtroCond.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfOtroCond.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfOtroCond.ExtraSQL = ""
        Me.dtfOtroCond.FocoEnAgregar = False
        Me.dtfOtroCond.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfOtroCond.Formulario = Nothing
        Me.dtfOtroCond.Label_Space = 75
        Me.dtfOtroCond.Length_Data = 32767
        Me.dtfOtroCond.Location = New System.Drawing.Point(6, 18)
        Me.dtfOtroCond.Lupa = Nothing
        Me.dtfOtroCond.Max_Value = 0.0R
        Me.dtfOtroCond.MensajeIncorrectoCustom = Nothing
        Me.dtfOtroCond.Name = "dtfOtroCond"
        Me.dtfOtroCond.Null_on_Empty = True
        Me.dtfOtroCond.OpenForm = Nothing
        Me.dtfOtroCond.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfOtroCond.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfOtroCond.Query_on_Text_Changed = True
        Me.dtfOtroCond.ReadOnly_Data = False
        Me.dtfOtroCond.ReQuery = False
        Me.dtfOtroCond.ShowButton = True
        Me.dtfOtroCond.Size = New System.Drawing.Size(538, 26)
        Me.dtfOtroCond.TabIndex = 0
        Me.dtfOtroCond.Text_Data = ""
        Me.dtfOtroCond.Text_Data_Desc = ""
        Me.dtfOtroCond.Text_Width = 58
        Me.dtfOtroCond.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfOtroCond.TopPadding = 0
        Me.dtfOtroCond.Upper_Case = False
        Me.dtfOtroCond.Validate_on_lost_focus = True
        '
        'pnlConductoresIzq
        '
        Me.pnlConductoresIzq.Auto_Size = False
        Me.pnlConductoresIzq.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlConductoresIzq.ChangeDock = True
        Me.pnlConductoresIzq.Control_Resize = False
        Me.pnlConductoresIzq.Controls.Add(Me.gbxConductor)
        Me.pnlConductoresIzq.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlConductoresIzq.isSpace = False
        Me.pnlConductoresIzq.Location = New System.Drawing.Point(0, 80)
        Me.pnlConductoresIzq.Name = "pnlConductoresIzq"
        Me.pnlConductoresIzq.numRows = 0
        Me.pnlConductoresIzq.Padding = New System.Windows.Forms.Padding(3)
        Me.pnlConductoresIzq.Reorder = True
        Me.pnlConductoresIzq.Size = New System.Drawing.Size(568, 479)
        Me.pnlConductoresIzq.TabIndex = 4
        '
        'gbxConductor
        '
        Me.gbxConductor.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.gbxConductor.Controls.Add(Me.pnlTarjeta)
        Me.gbxConductor.Controls.Add(Me.dtfTarjetaCond)
        Me.gbxConductor.Controls.Add(Me.dtfEmailCond)
        Me.gbxConductor.Controls.Add(Me.pnlPermiso)
        Me.gbxConductor.Controls.Add(Me.pnlLuNace)
        Me.gbxConductor.Controls.Add(Me.pnlNifTelf)
        Me.gbxConductor.Controls.Add(Me.dtdDirCond)
        Me.gbxConductor.Controls.Add(Me.dtfNombreCond)
        Me.gbxConductor.Controls.Add(Me.pnlConductor)
        Me.gbxConductor.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbxConductor.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.gbxConductor.HeaderText = "Conductor"
        Me.gbxConductor.Location = New System.Drawing.Point(3, 3)
        Me.gbxConductor.Name = "gbxConductor"
        Me.gbxConductor.numRows = 13
        Me.gbxConductor.Padding = New System.Windows.Forms.Padding(6, 18, 6, 6)
        Me.gbxConductor.Reorder = True
        Me.gbxConductor.Size = New System.Drawing.Size(562, 358)
        Me.gbxConductor.TabIndex = 0
        Me.gbxConductor.Text = "Conductor"
        Me.gbxConductor.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.gbxConductor.ThemeName = "Windows8"
        Me.gbxConductor.Title = "Conductor"
        '
        'pnlTarjeta
        '
        Me.pnlTarjeta.Auto_Size = False
        Me.pnlTarjeta.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlTarjeta.ChangeDock = True
        Me.pnlTarjeta.Control_Resize = False
        Me.pnlTarjeta.Controls.Add(Me.dtfTarNum)
        Me.pnlTarjeta.Controls.Add(Me.pnlSpace31)
        Me.pnlTarjeta.Controls.Add(Me.lblTarCadu)
        Me.pnlTarjeta.Controls.Add(Me.pnlSpace30)
        Me.pnlTarjeta.Controls.Add(Me.mdfTarcadu)
        Me.pnlTarjeta.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTarjeta.isSpace = False
        Me.pnlTarjeta.Location = New System.Drawing.Point(6, 330)
        Me.pnlTarjeta.Name = "pnlTarjeta"
        Me.pnlTarjeta.numRows = 1
        Me.pnlTarjeta.Reorder = True
        Me.pnlTarjeta.Size = New System.Drawing.Size(550, 26)
        Me.pnlTarjeta.TabIndex = 8
        '
        'dtfTarNum
        '
        Me.dtfTarNum.Allow_Empty = True
        Me.dtfTarNum.Allow_Negative = True
        Me.dtfTarNum.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfTarNum.BackColor = System.Drawing.SystemColors.Control
        Me.dtfTarNum.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfTarNum.DataField = "TARNUM_CON2"
        Me.dtfTarNum.DataTable = "C2"
        Me.dtfTarNum.Descripcion = "Número"
        Me.dtfTarNum.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfTarNum.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfTarNum.FocoEnAgregar = False
        Me.dtfTarNum.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfTarNum.Image = Nothing
        Me.dtfTarNum.Label_Space = 75
        Me.dtfTarNum.Length_Data = 32767
        Me.dtfTarNum.Location = New System.Drawing.Point(0, 0)
        Me.dtfTarNum.Max_Value = 0.0R
        Me.dtfTarNum.MensajeIncorrectoCustom = Nothing
        Me.dtfTarNum.Name = "dtfTarNum"
        Me.dtfTarNum.Null_on_Empty = True
        Me.dtfTarNum.OpenForm = Nothing
        Me.dtfTarNum.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfTarNum.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfTarNum.ReadOnly_Data = False
        Me.dtfTarNum.Show_Button = False
        Me.dtfTarNum.Size = New System.Drawing.Size(391, 26)
        Me.dtfTarNum.TabIndex = 0
        Me.dtfTarNum.Text_Data = ""
        Me.dtfTarNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfTarNum.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfTarNum.TopPadding = 0
        Me.dtfTarNum.Upper_Case = False
        Me.dtfTarNum.Validate_on_lost_focus = True
        '
        'pnlSpace31
        '
        Me.pnlSpace31.Auto_Size = False
        Me.pnlSpace31.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace31.ChangeDock = True
        Me.pnlSpace31.Control_Resize = False
        Me.pnlSpace31.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSpace31.isSpace = True
        Me.pnlSpace31.Location = New System.Drawing.Point(391, 0)
        Me.pnlSpace31.Name = "pnlSpace31"
        Me.pnlSpace31.numRows = 0
        Me.pnlSpace31.Reorder = True
        Me.pnlSpace31.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace31.TabIndex = 1
        '
        'lblTarCadu
        '
        Me.lblTarCadu.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblTarCadu.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblTarCadu.Location = New System.Drawing.Point(397, 0)
        Me.lblTarCadu.Name = "lblTarCadu"
        Me.lblTarCadu.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.lblTarCadu.Size = New System.Drawing.Size(102, 26)
        Me.lblTarCadu.TabIndex = 2
        Me.lblTarCadu.Text = "Fecha Caducidad"
        '
        'pnlSpace30
        '
        Me.pnlSpace30.Auto_Size = False
        Me.pnlSpace30.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace30.ChangeDock = True
        Me.pnlSpace30.Control_Resize = False
        Me.pnlSpace30.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSpace30.isSpace = True
        Me.pnlSpace30.Location = New System.Drawing.Point(499, 0)
        Me.pnlSpace30.Name = "pnlSpace30"
        Me.pnlSpace30.numRows = 0
        Me.pnlSpace30.Reorder = True
        Me.pnlSpace30.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace30.TabIndex = 3
        '
        'mdfTarcadu
        '
        Me.mdfTarcadu.Alignemnt = System.Windows.Forms.HorizontalAlignment.Left
        Me.mdfTarcadu.Allow_Empty = True
        Me.mdfTarcadu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.mdfTarcadu.BackColor = System.Drawing.SystemColors.Control
        Me.mdfTarcadu.DataField = "TARCADU_CON2"
        Me.mdfTarcadu.DataTable = "C2"
        Me.mdfTarcadu.Descripcion = "Clase"
        Me.mdfTarcadu.Dock = System.Windows.Forms.DockStyle.Right
        Me.mdfTarcadu.FocoEnAgregar = False
        Me.mdfTarcadu.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.mdfTarcadu.Location = New System.Drawing.Point(505, 0)
        Me.mdfTarcadu.Mask = "##/##"
        Me.mdfTarcadu.MensajeIncorrectoCustom = Nothing
        Me.mdfTarcadu.Name = "mdfTarcadu"
        Me.mdfTarcadu.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.mdfTarcadu.ReadOnly_Data = False
        Me.mdfTarcadu.Regex = "[01-12]/[00-99]"
        Me.mdfTarcadu.RegexInput = "[0-9]"
        Me.mdfTarcadu.Size = New System.Drawing.Size(45, 26)
        Me.mdfTarcadu.TabIndex = 4
        Me.mdfTarcadu.Text_Data = "__/__"
        Me.mdfTarcadu.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.mdfTarcadu.TopPadding = 0
        Me.mdfTarcadu.Upper_Case = False
        Me.mdfTarcadu.Validate_on_lost_focus = True
        '
        'dtfTarjetaCond
        '
        Me.dtfTarjetaCond.Allow_Empty = True
        Me.dtfTarjetaCond.Allow_Negative = True
        Me.dtfTarjetaCond.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfTarjetaCond.BackColor = System.Drawing.SystemColors.Control
        Me.dtfTarjetaCond.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfTarjetaCond.DataField = "TARTI_CON2"
        Me.dtfTarjetaCond.DataTable = "C2"
        Me.dtfTarjetaCond.DB = Connection41
        Me.dtfTarjetaCond.Desc_Datafield = "NOMBRE"
        Me.dtfTarjetaCond.Desc_DBPK = "CODIGO"
        Me.dtfTarjetaCond.Desc_DBTable = "TARCREDI"
        Me.dtfTarjetaCond.Desc_Where = Nothing
        Me.dtfTarjetaCond.Desc_WhereObligatoria = Nothing
        Me.dtfTarjetaCond.Descripcion = "Tarjeta"
        Me.dtfTarjetaCond.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfTarjetaCond.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfTarjetaCond.ExtraSQL = ""
        Me.dtfTarjetaCond.FocoEnAgregar = False
        Me.dtfTarjetaCond.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfTarjetaCond.Formulario = Nothing
        Me.dtfTarjetaCond.Label_Space = 75
        Me.dtfTarjetaCond.Length_Data = 32767
        Me.dtfTarjetaCond.Location = New System.Drawing.Point(6, 304)
        Me.dtfTarjetaCond.Lupa = Nothing
        Me.dtfTarjetaCond.Max_Value = 0.0R
        Me.dtfTarjetaCond.MensajeIncorrectoCustom = Nothing
        Me.dtfTarjetaCond.Name = "dtfTarjetaCond"
        Me.dtfTarjetaCond.Null_on_Empty = True
        Me.dtfTarjetaCond.OpenForm = Nothing
        Me.dtfTarjetaCond.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfTarjetaCond.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfTarjetaCond.Query_on_Text_Changed = True
        Me.dtfTarjetaCond.ReadOnly_Data = False
        Me.dtfTarjetaCond.ReQuery = False
        Me.dtfTarjetaCond.ShowButton = True
        Me.dtfTarjetaCond.Size = New System.Drawing.Size(550, 26)
        Me.dtfTarjetaCond.TabIndex = 7
        Me.dtfTarjetaCond.Text_Data = ""
        Me.dtfTarjetaCond.Text_Data_Desc = ""
        Me.dtfTarjetaCond.Text_Width = 58
        Me.dtfTarjetaCond.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfTarjetaCond.TopPadding = 0
        Me.dtfTarjetaCond.Upper_Case = False
        Me.dtfTarjetaCond.Validate_on_lost_focus = True
        '
        'dtfEmailCond
        '
        Me.dtfEmailCond.Allow_Empty = True
        Me.dtfEmailCond.Allow_Negative = True
        Me.dtfEmailCond.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfEmailCond.BackColor = System.Drawing.SystemColors.Control
        Me.dtfEmailCond.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfEmailCond.DataField = "MAILCOND_CON2"
        Me.dtfEmailCond.DataTable = "C2"
        Me.dtfEmailCond.Descripcion = "Email"
        Me.dtfEmailCond.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfEmailCond.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfEmailCond.FocoEnAgregar = False
        Me.dtfEmailCond.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfEmailCond.Image = Nothing
        Me.dtfEmailCond.Label_Space = 75
        Me.dtfEmailCond.Length_Data = 32767
        Me.dtfEmailCond.Location = New System.Drawing.Point(6, 278)
        Me.dtfEmailCond.Max_Value = 0.0R
        Me.dtfEmailCond.MensajeIncorrectoCustom = Nothing
        Me.dtfEmailCond.Name = "dtfEmailCond"
        Me.dtfEmailCond.Null_on_Empty = True
        Me.dtfEmailCond.OpenForm = Nothing
        Me.dtfEmailCond.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfEmailCond.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfEmailCond.ReadOnly_Data = False
        Me.dtfEmailCond.Show_Button = True
        Me.dtfEmailCond.Size = New System.Drawing.Size(550, 26)
        Me.dtfEmailCond.TabIndex = 6
        Me.dtfEmailCond.Text_Data = ""
        Me.dtfEmailCond.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfEmailCond.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfEmailCond.TopPadding = 0
        Me.dtfEmailCond.Upper_Case = False
        Me.dtfEmailCond.Validate_on_lost_focus = True
        '
        'pnlPermiso
        '
        Me.pnlPermiso.Auto_Size = False
        Me.pnlPermiso.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlPermiso.ChangeDock = True
        Me.pnlPermiso.Control_Resize = False
        Me.pnlPermiso.Controls.Add(Me.pnlPermisoInf)
        Me.pnlPermiso.Controls.Add(Me.pnlPermisoSup)
        Me.pnlPermiso.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlPermiso.isSpace = False
        Me.pnlPermiso.Location = New System.Drawing.Point(6, 226)
        Me.pnlPermiso.Name = "pnlPermiso"
        Me.pnlPermiso.numRows = 2
        Me.pnlPermiso.Reorder = True
        Me.pnlPermiso.Size = New System.Drawing.Size(550, 52)
        Me.pnlPermiso.TabIndex = 5
        '
        'pnlPermisoInf
        '
        Me.pnlPermisoInf.Auto_Size = False
        Me.pnlPermisoInf.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlPermisoInf.ChangeDock = True
        Me.pnlPermisoInf.Control_Resize = False
        Me.pnlPermisoInf.Controls.Add(Me.dtfLuExpe)
        Me.pnlPermisoInf.Controls.Add(Me.pnlSpace29)
        Me.pnlPermisoInf.Controls.Add(Me.dtdFeExpe)
        Me.pnlPermisoInf.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlPermisoInf.isSpace = False
        Me.pnlPermisoInf.Location = New System.Drawing.Point(0, 26)
        Me.pnlPermisoInf.Name = "pnlPermisoInf"
        Me.pnlPermisoInf.numRows = 1
        Me.pnlPermisoInf.Reorder = True
        Me.pnlPermisoInf.Size = New System.Drawing.Size(550, 26)
        Me.pnlPermisoInf.TabIndex = 1
        '
        'dtfLuExpe
        '
        Me.dtfLuExpe.Allow_Empty = True
        Me.dtfLuExpe.Allow_Negative = True
        Me.dtfLuExpe.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfLuExpe.BackColor = System.Drawing.SystemColors.Control
        Me.dtfLuExpe.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfLuExpe.DataField = "LUEXPE_CON2"
        Me.dtfLuExpe.DataTable = "C2"
        Me.dtfLuExpe.Descripcion = "en"
        Me.dtfLuExpe.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfLuExpe.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfLuExpe.FocoEnAgregar = False
        Me.dtfLuExpe.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfLuExpe.Image = Nothing
        Me.dtfLuExpe.Label_Space = 25
        Me.dtfLuExpe.Length_Data = 32767
        Me.dtfLuExpe.Location = New System.Drawing.Point(171, 0)
        Me.dtfLuExpe.Max_Value = 0.0R
        Me.dtfLuExpe.MensajeIncorrectoCustom = Nothing
        Me.dtfLuExpe.Name = "dtfLuExpe"
        Me.dtfLuExpe.Null_on_Empty = True
        Me.dtfLuExpe.OpenForm = Nothing
        Me.dtfLuExpe.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfLuExpe.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfLuExpe.ReadOnly_Data = False
        Me.dtfLuExpe.Show_Button = False
        Me.dtfLuExpe.Size = New System.Drawing.Size(379, 26)
        Me.dtfLuExpe.TabIndex = 2
        Me.dtfLuExpe.Text_Data = ""
        Me.dtfLuExpe.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfLuExpe.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfLuExpe.TopPadding = 0
        Me.dtfLuExpe.Upper_Case = False
        Me.dtfLuExpe.Validate_on_lost_focus = True
        '
        'pnlSpace29
        '
        Me.pnlSpace29.Auto_Size = False
        Me.pnlSpace29.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace29.ChangeDock = True
        Me.pnlSpace29.Control_Resize = False
        Me.pnlSpace29.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace29.isSpace = True
        Me.pnlSpace29.Location = New System.Drawing.Point(165, 0)
        Me.pnlSpace29.Name = "pnlSpace29"
        Me.pnlSpace29.numRows = 0
        Me.pnlSpace29.Reorder = True
        Me.pnlSpace29.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace29.TabIndex = 1
        '
        'dtdFeExpe
        '
        Me.dtdFeExpe.Allow_Empty = True
        Me.dtdFeExpe.DataField = "FEEXPE_CON2"
        Me.dtdFeExpe.DataTable = "C2"
        Me.dtdFeExpe.Default_Value = New Date(2015, 9, 21, 0, 0, 0, 0)
        Me.dtdFeExpe.Descripcion = "Expedido el"
        Me.dtdFeExpe.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtdFeExpe.FocoEnAgregar = False
        Me.dtdFeExpe.Label_Space = 75
        Me.dtdFeExpe.Location = New System.Drawing.Point(0, 0)
        Me.dtdFeExpe.Max_Value = Nothing
        Me.dtdFeExpe.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdFeExpe.MensajeIncorrectoCustom = Nothing
        Me.dtdFeExpe.Min_Value = Nothing
        Me.dtdFeExpe.MinDate = New Date(CType(0, Long))
        Me.dtdFeExpe.MinimumSize = New System.Drawing.Size(165, 26)
        Me.dtdFeExpe.Name = "dtdFeExpe"
        Me.dtdFeExpe.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdFeExpe.ReadOnly_Data = False
        Me.dtdFeExpe.Size = New System.Drawing.Size(165, 26)
        Me.dtdFeExpe.TabIndex = 0
        Me.dtdFeExpe.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdFeExpe.Validate_on_lost_focus = True
        Me.dtdFeExpe.Value_Data = New Date(2015, 9, 21, 0, 0, 0, 0)
        '
        'pnlPermisoSup
        '
        Me.pnlPermisoSup.Auto_Size = False
        Me.pnlPermisoSup.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlPermisoSup.ChangeDock = True
        Me.pnlPermisoSup.Control_Resize = False
        Me.pnlPermisoSup.Controls.Add(Me.dtfPermiso)
        Me.pnlPermisoSup.Controls.Add(Me.pnlSpace28)
        Me.pnlPermisoSup.Controls.Add(Me.dtfClase)
        Me.pnlPermisoSup.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlPermisoSup.isSpace = False
        Me.pnlPermisoSup.Location = New System.Drawing.Point(0, 0)
        Me.pnlPermisoSup.Name = "pnlPermisoSup"
        Me.pnlPermisoSup.numRows = 1
        Me.pnlPermisoSup.Reorder = True
        Me.pnlPermisoSup.Size = New System.Drawing.Size(550, 26)
        Me.pnlPermisoSup.TabIndex = 0
        '
        'dtfPermiso
        '
        Me.dtfPermiso.Allow_Empty = True
        Me.dtfPermiso.Allow_Negative = True
        Me.dtfPermiso.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfPermiso.BackColor = System.Drawing.SystemColors.Control
        Me.dtfPermiso.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfPermiso.DataField = "PERMISO_CON2"
        Me.dtfPermiso.DataTable = "C2"
        Me.dtfPermiso.Descripcion = "Permiso"
        Me.dtfPermiso.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfPermiso.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfPermiso.FocoEnAgregar = False
        Me.dtfPermiso.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfPermiso.Image = Nothing
        Me.dtfPermiso.Label_Space = 75
        Me.dtfPermiso.Length_Data = 32767
        Me.dtfPermiso.Location = New System.Drawing.Point(0, 0)
        Me.dtfPermiso.Max_Value = 0.0R
        Me.dtfPermiso.MensajeIncorrectoCustom = Nothing
        Me.dtfPermiso.Name = "dtfPermiso"
        Me.dtfPermiso.Null_on_Empty = True
        Me.dtfPermiso.OpenForm = Nothing
        Me.dtfPermiso.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfPermiso.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfPermiso.ReadOnly_Data = False
        Me.dtfPermiso.Show_Button = False
        Me.dtfPermiso.Size = New System.Drawing.Size(379, 26)
        Me.dtfPermiso.TabIndex = 0
        Me.dtfPermiso.Text_Data = ""
        Me.dtfPermiso.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfPermiso.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfPermiso.TopPadding = 0
        Me.dtfPermiso.Upper_Case = False
        Me.dtfPermiso.Validate_on_lost_focus = True
        '
        'pnlSpace28
        '
        Me.pnlSpace28.Auto_Size = False
        Me.pnlSpace28.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace28.ChangeDock = True
        Me.pnlSpace28.Control_Resize = False
        Me.pnlSpace28.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSpace28.isSpace = True
        Me.pnlSpace28.Location = New System.Drawing.Point(379, 0)
        Me.pnlSpace28.Name = "pnlSpace28"
        Me.pnlSpace28.numRows = 0
        Me.pnlSpace28.Reorder = True
        Me.pnlSpace28.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace28.TabIndex = 1
        '
        'dtfClase
        '
        Me.dtfClase.Allow_Empty = True
        Me.dtfClase.Allow_Negative = True
        Me.dtfClase.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfClase.BackColor = System.Drawing.SystemColors.Control
        Me.dtfClase.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfClase.DataField = "CLASE_CON2"
        Me.dtfClase.DataTable = "C2"
        Me.dtfClase.Descripcion = "Clase"
        Me.dtfClase.Dock = System.Windows.Forms.DockStyle.Right
        Me.dtfClase.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfClase.FocoEnAgregar = False
        Me.dtfClase.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfClase.Image = Nothing
        Me.dtfClase.Label_Space = 75
        Me.dtfClase.Length_Data = 32767
        Me.dtfClase.Location = New System.Drawing.Point(385, 0)
        Me.dtfClase.Max_Value = 0.0R
        Me.dtfClase.MensajeIncorrectoCustom = Nothing
        Me.dtfClase.Name = "dtfClase"
        Me.dtfClase.Null_on_Empty = True
        Me.dtfClase.OpenForm = Nothing
        Me.dtfClase.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfClase.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfClase.ReadOnly_Data = False
        Me.dtfClase.Show_Button = False
        Me.dtfClase.Size = New System.Drawing.Size(165, 26)
        Me.dtfClase.TabIndex = 2
        Me.dtfClase.Text_Data = ""
        Me.dtfClase.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfClase.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfClase.TopPadding = 0
        Me.dtfClase.Upper_Case = False
        Me.dtfClase.Validate_on_lost_focus = True
        '
        'pnlLuNace
        '
        Me.pnlLuNace.Auto_Size = False
        Me.pnlLuNace.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlLuNace.ChangeDock = True
        Me.pnlLuNace.Control_Resize = False
        Me.pnlLuNace.Controls.Add(Me.dtfLuNace)
        Me.pnlLuNace.Controls.Add(Me.pnlSpace27)
        Me.pnlLuNace.Controls.Add(Me.dtdFechaNac)
        Me.pnlLuNace.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlLuNace.isSpace = False
        Me.pnlLuNace.Location = New System.Drawing.Point(6, 200)
        Me.pnlLuNace.Name = "pnlLuNace"
        Me.pnlLuNace.numRows = 1
        Me.pnlLuNace.Reorder = True
        Me.pnlLuNace.Size = New System.Drawing.Size(550, 26)
        Me.pnlLuNace.TabIndex = 4
        '
        'dtfLuNace
        '
        Me.dtfLuNace.Allow_Empty = True
        Me.dtfLuNace.Allow_Negative = True
        Me.dtfLuNace.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfLuNace.BackColor = System.Drawing.SystemColors.Control
        Me.dtfLuNace.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfLuNace.DataField = "LUNACI_CON2"
        Me.dtfLuNace.DataTable = "C2"
        Me.dtfLuNace.Descripcion = "Lugar Nac."
        Me.dtfLuNace.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfLuNace.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfLuNace.FocoEnAgregar = False
        Me.dtfLuNace.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfLuNace.Image = Nothing
        Me.dtfLuNace.Label_Space = 75
        Me.dtfLuNace.Length_Data = 32767
        Me.dtfLuNace.Location = New System.Drawing.Point(0, 0)
        Me.dtfLuNace.Max_Value = 0.0R
        Me.dtfLuNace.MensajeIncorrectoCustom = Nothing
        Me.dtfLuNace.Name = "dtfLuNace"
        Me.dtfLuNace.Null_on_Empty = True
        Me.dtfLuNace.OpenForm = Nothing
        Me.dtfLuNace.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfLuNace.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfLuNace.ReadOnly_Data = False
        Me.dtfLuNace.Show_Button = False
        Me.dtfLuNace.Size = New System.Drawing.Size(364, 26)
        Me.dtfLuNace.TabIndex = 0
        Me.dtfLuNace.Text_Data = ""
        Me.dtfLuNace.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfLuNace.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfLuNace.TopPadding = 0
        Me.dtfLuNace.Upper_Case = False
        Me.dtfLuNace.Validate_on_lost_focus = True
        '
        'pnlSpace27
        '
        Me.pnlSpace27.Auto_Size = False
        Me.pnlSpace27.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace27.ChangeDock = True
        Me.pnlSpace27.Control_Resize = False
        Me.pnlSpace27.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSpace27.isSpace = True
        Me.pnlSpace27.Location = New System.Drawing.Point(364, 0)
        Me.pnlSpace27.Name = "pnlSpace27"
        Me.pnlSpace27.numRows = 0
        Me.pnlSpace27.Reorder = True
        Me.pnlSpace27.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace27.TabIndex = 1
        '
        'dtdFechaNac
        '
        Me.dtdFechaNac.Allow_Empty = True
        Me.dtdFechaNac.DataField = "FENACI_CON2"
        Me.dtdFechaNac.DataTable = "C2"
        Me.dtdFechaNac.Default_Value = New Date(2015, 9, 21, 0, 0, 0, 0)
        Me.dtdFechaNac.Descripcion = "F. Nacimiento"
        Me.dtdFechaNac.Dock = System.Windows.Forms.DockStyle.Right
        Me.dtdFechaNac.FocoEnAgregar = False
        Me.dtdFechaNac.Label_Space = 90
        Me.dtdFechaNac.Location = New System.Drawing.Point(370, 0)
        Me.dtdFechaNac.Max_Value = Nothing
        Me.dtdFechaNac.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdFechaNac.MensajeIncorrectoCustom = Nothing
        Me.dtdFechaNac.Min_Value = Nothing
        Me.dtdFechaNac.MinDate = New Date(CType(0, Long))
        Me.dtdFechaNac.MinimumSize = New System.Drawing.Size(180, 26)
        Me.dtdFechaNac.Name = "dtdFechaNac"
        Me.dtdFechaNac.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdFechaNac.ReadOnly_Data = False
        Me.dtdFechaNac.Size = New System.Drawing.Size(180, 26)
        Me.dtdFechaNac.TabIndex = 2
        Me.dtdFechaNac.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdFechaNac.Validate_on_lost_focus = True
        Me.dtdFechaNac.Value_Data = New Date(2015, 9, 21, 0, 0, 0, 0)
        '
        'pnlNifTelf
        '
        Me.pnlNifTelf.Auto_Size = False
        Me.pnlNifTelf.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlNifTelf.ChangeDock = False
        Me.pnlNifTelf.Control_Resize = False
        Me.pnlNifTelf.Controls.Add(Me.dtfNIFCond)
        Me.pnlNifTelf.Controls.Add(Me.pnlSpace25)
        Me.pnlNifTelf.Controls.Add(Me.dtfTelfCond)
        Me.pnlNifTelf.Controls.Add(Me.pnlSpace24)
        Me.pnlNifTelf.Controls.Add(Me.dtfTelfCond2)
        Me.pnlNifTelf.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlNifTelf.isSpace = False
        Me.pnlNifTelf.Location = New System.Drawing.Point(6, 174)
        Me.pnlNifTelf.Name = "pnlNifTelf"
        Me.pnlNifTelf.numRows = 1
        Me.pnlNifTelf.Reorder = True
        Me.pnlNifTelf.Size = New System.Drawing.Size(550, 26)
        Me.pnlNifTelf.TabIndex = 3
        '
        'dtfNIFCond
        '
        Me.dtfNIFCond.Allow_Empty = True
        Me.dtfNIFCond.Allow_Negative = True
        Me.dtfNIFCond.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfNIFCond.BackColor = System.Drawing.SystemColors.Control
        Me.dtfNIFCond.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfNIFCond.DataField = "DNICOND_CON2"
        Me.dtfNIFCond.DataTable = "C2"
        Me.dtfNIFCond.Descripcion = "NIF"
        Me.dtfNIFCond.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfNIFCond.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfNIFCond.FocoEnAgregar = False
        Me.dtfNIFCond.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfNIFCond.Image = Nothing
        Me.dtfNIFCond.Label_Space = 75
        Me.dtfNIFCond.Length_Data = 32767
        Me.dtfNIFCond.Location = New System.Drawing.Point(0, 0)
        Me.dtfNIFCond.Max_Value = 0.0R
        Me.dtfNIFCond.MensajeIncorrectoCustom = Nothing
        Me.dtfNIFCond.Name = "dtfNIFCond"
        Me.dtfNIFCond.Null_on_Empty = True
        Me.dtfNIFCond.OpenForm = Nothing
        Me.dtfNIFCond.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfNIFCond.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfNIFCond.ReadOnly_Data = False
        Me.dtfNIFCond.Show_Button = False
        Me.dtfNIFCond.Size = New System.Drawing.Size(258, 26)
        Me.dtfNIFCond.TabIndex = 0
        Me.dtfNIFCond.Text_Data = ""
        Me.dtfNIFCond.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfNIFCond.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfNIFCond.TopPadding = 0
        Me.dtfNIFCond.Upper_Case = False
        Me.dtfNIFCond.Validate_on_lost_focus = True
        '
        'pnlSpace25
        '
        Me.pnlSpace25.Auto_Size = False
        Me.pnlSpace25.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace25.ChangeDock = True
        Me.pnlSpace25.Control_Resize = False
        Me.pnlSpace25.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSpace25.isSpace = True
        Me.pnlSpace25.Location = New System.Drawing.Point(258, 0)
        Me.pnlSpace25.Name = "pnlSpace25"
        Me.pnlSpace25.numRows = 0
        Me.pnlSpace25.Reorder = True
        Me.pnlSpace25.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace25.TabIndex = 1
        '
        'dtfTelfCond
        '
        Me.dtfTelfCond.Allow_Empty = True
        Me.dtfTelfCond.Allow_Negative = True
        Me.dtfTelfCond.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfTelfCond.BackColor = System.Drawing.SystemColors.Control
        Me.dtfTelfCond.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfTelfCond.DataField = "TELCOND_CON2"
        Me.dtfTelfCond.DataTable = "C2"
        Me.dtfTelfCond.Descripcion = "Telefono"
        Me.dtfTelfCond.Dock = System.Windows.Forms.DockStyle.Right
        Me.dtfTelfCond.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfTelfCond.FocoEnAgregar = False
        Me.dtfTelfCond.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfTelfCond.Image = Nothing
        Me.dtfTelfCond.Label_Space = 60
        Me.dtfTelfCond.Length_Data = 32767
        Me.dtfTelfCond.Location = New System.Drawing.Point(264, 0)
        Me.dtfTelfCond.Max_Value = 0.0R
        Me.dtfTelfCond.MensajeIncorrectoCustom = Nothing
        Me.dtfTelfCond.Name = "dtfTelfCond"
        Me.dtfTelfCond.Null_on_Empty = True
        Me.dtfTelfCond.OpenForm = Nothing
        Me.dtfTelfCond.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfTelfCond.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfTelfCond.ReadOnly_Data = False
        Me.dtfTelfCond.Show_Button = False
        Me.dtfTelfCond.Size = New System.Drawing.Size(170, 26)
        Me.dtfTelfCond.TabIndex = 2
        Me.dtfTelfCond.Text_Data = ""
        Me.dtfTelfCond.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfTelfCond.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfTelfCond.TopPadding = 0
        Me.dtfTelfCond.Upper_Case = False
        Me.dtfTelfCond.Validate_on_lost_focus = True
        '
        'pnlSpace24
        '
        Me.pnlSpace24.Auto_Size = False
        Me.pnlSpace24.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace24.ChangeDock = True
        Me.pnlSpace24.Control_Resize = False
        Me.pnlSpace24.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSpace24.isSpace = True
        Me.pnlSpace24.Location = New System.Drawing.Point(434, 0)
        Me.pnlSpace24.Name = "pnlSpace24"
        Me.pnlSpace24.numRows = 0
        Me.pnlSpace24.Reorder = True
        Me.pnlSpace24.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace24.TabIndex = 3
        '
        'dtfTelfCond2
        '
        Me.dtfTelfCond2.Allow_Empty = True
        Me.dtfTelfCond2.Allow_Negative = True
        Me.dtfTelfCond2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfTelfCond2.BackColor = System.Drawing.SystemColors.Control
        Me.dtfTelfCond2.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfTelfCond2.DataField = "TEL2COND_CON2"
        Me.dtfTelfCond2.DataTable = "C2"
        Me.dtfTelfCond2.Descripcion = "Telefono"
        Me.dtfTelfCond2.Dock = System.Windows.Forms.DockStyle.Right
        Me.dtfTelfCond2.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfTelfCond2.FocoEnAgregar = False
        Me.dtfTelfCond2.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfTelfCond2.Length_Data = 32767
        Me.dtfTelfCond2.Location = New System.Drawing.Point(440, 0)
        Me.dtfTelfCond2.Max_Value = 0.0R
        Me.dtfTelfCond2.MensajeIncorrectoCustom = Nothing
        Me.dtfTelfCond2.Name = "dtfTelfCond2"
        Me.dtfTelfCond2.Null_on_Empty = True
        Me.dtfTelfCond2.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfTelfCond2.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfTelfCond2.ReadOnly_Data = False
        Me.dtfTelfCond2.Size = New System.Drawing.Size(110, 26)
        Me.dtfTelfCond2.TabIndex = 4
        Me.dtfTelfCond2.Text_Data = ""
        Me.dtfTelfCond2.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfTelfCond2.TopPadding = 0
        Me.dtfTelfCond2.Upper_Case = False
        Me.dtfTelfCond2.Validate_on_lost_focus = True
        '
        'dtdDirCond
        '
        Me.dtdDirCond.AutoSize = True
        Me.dtdDirCond.Datafield_CP = "CPCOND_CON2"
        Me.dtdDirCond.Datafield_Direccion = "DIRCOND_CON2"
        Me.dtdDirCond.Datafield_Direccion2L = Nothing
        Me.dtdDirCond.Datafield_GPS = Nothing
        Me.dtdDirCond.Datafield_Pais = "PAISCOND_CON2"
        Me.dtdDirCond.Datafield_Poblacion = "POCOND_CON2"
        Me.dtdDirCond.Datafield_Provincia = "PROVCOND_CON2"
        Me.dtdDirCond.Datatable_CP = "C2"
        Me.dtdDirCond.Datatable_Direccion = "C2"
        Me.dtdDirCond.Datatable_Direccion2L = ""
        Me.dtdDirCond.Datatable_GPS = ""
        Me.dtdDirCond.Datatable_Pais = "C2"
        Me.dtdDirCond.Datatable_Poblacion = "C2"
        Me.dtdDirCond.Datatable_Provincia = "C2"
        Me.dtdDirCond.Descripcion = "Direccion Conductor"
        Me.dtdDirCond.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtdDirCond.FocoEnAgregar = False
        Me.dtdDirCond.Label_Space = 75
        Me.dtdDirCond.Location = New System.Drawing.Point(6, 70)
        Me.dtdDirCond.Name = "dtdDirCond"
        Me.dtdDirCond.ReadOnly_Data = False
        Me.dtdDirCond.requeryCP = False
        Me.dtdDirCond.Show_Dir2L = False
        Me.dtdDirCond.Show_GPS = False
        Me.dtdDirCond.Show_Pais = True
        Me.dtdDirCond.Size = New System.Drawing.Size(550, 104)
        Me.dtdDirCond.TabIndex = 2
        Me.dtdDirCond.Text_Data_CP = ""
        Me.dtdDirCond.Text_Data_Direccion = ""
        Me.dtdDirCond.Text_Data_Direccion2L = ""
        Me.dtdDirCond.Text_Data_GPS = ""
        Me.dtdDirCond.Text_Data_Pais = ""
        Me.dtdDirCond.Text_Data_Poblacion = ""
        Me.dtdDirCond.Text_Data_Provincia = ""
        '
        'dtfNombreCond
        '
        Me.dtfNombreCond.Allow_Empty = True
        Me.dtfNombreCond.Allow_Negative = True
        Me.dtfNombreCond.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfNombreCond.BackColor = System.Drawing.SystemColors.Control
        Me.dtfNombreCond.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfNombreCond.DataField = "NOMBRE_CON1"
        Me.dtfNombreCond.DataTable = "C1"
        Me.dtfNombreCond.Descripcion = "Nombre"
        Me.dtfNombreCond.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfNombreCond.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfNombreCond.FocoEnAgregar = False
        Me.dtfNombreCond.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfNombreCond.Image = Nothing
        Me.dtfNombreCond.Label_Space = 75
        Me.dtfNombreCond.Length_Data = 32767
        Me.dtfNombreCond.Location = New System.Drawing.Point(6, 44)
        Me.dtfNombreCond.Max_Value = 0.0R
        Me.dtfNombreCond.MensajeIncorrectoCustom = Nothing
        Me.dtfNombreCond.Name = "dtfNombreCond"
        Me.dtfNombreCond.Null_on_Empty = True
        Me.dtfNombreCond.OpenForm = Nothing
        Me.dtfNombreCond.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfNombreCond.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfNombreCond.ReadOnly_Data = False
        Me.dtfNombreCond.Show_Button = False
        Me.dtfNombreCond.Size = New System.Drawing.Size(550, 26)
        Me.dtfNombreCond.TabIndex = 1
        Me.dtfNombreCond.Text_Data = ""
        Me.dtfNombreCond.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfNombreCond.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfNombreCond.TopPadding = 0
        Me.dtfNombreCond.Upper_Case = False
        Me.dtfNombreCond.Validate_on_lost_focus = True
        '
        'pnlConductor
        '
        Me.pnlConductor.Auto_Size = False
        Me.pnlConductor.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlConductor.ChangeDock = False
        Me.pnlConductor.Control_Resize = False
        Me.pnlConductor.Controls.Add(Me.dtfConductorDetalles)
        Me.pnlConductor.Controls.Add(Me.pnlSpace23)
        Me.pnlConductor.Controls.Add(Me.btnCargarCond)
        Me.pnlConductor.Controls.Add(Me.pnlSpace26)
        Me.pnlConductor.Controls.Add(Me.btnGuardar)
        Me.pnlConductor.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlConductor.isSpace = False
        Me.pnlConductor.Location = New System.Drawing.Point(6, 18)
        Me.pnlConductor.Name = "pnlConductor"
        Me.pnlConductor.numRows = 1
        Me.pnlConductor.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.pnlConductor.Reorder = True
        Me.pnlConductor.Size = New System.Drawing.Size(550, 26)
        Me.pnlConductor.TabIndex = 0
        '
        'dtfConductorDetalles
        '
        Me.dtfConductorDetalles.Allow_Empty = True
        Me.dtfConductorDetalles.Allow_Negative = True
        Me.dtfConductorDetalles.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfConductorDetalles.BackColor = System.Drawing.SystemColors.Control
        Me.dtfConductorDetalles.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfConductorDetalles.DataField = "CONDUCTOR_CON1"
        Me.dtfConductorDetalles.DataTable = "C1"
        Me.dtfConductorDetalles.DB = Connection42
        Me.dtfConductorDetalles.Desc_Datafield = "NOMBRE"
        Me.dtfConductorDetalles.Desc_DBPK = "NUMERO_CLI"
        Me.dtfConductorDetalles.Desc_DBTable = "CLIENTES1"
        Me.dtfConductorDetalles.Desc_Where = Nothing
        Me.dtfConductorDetalles.Desc_WhereObligatoria = Nothing
        Me.dtfConductorDetalles.Descripcion = "Conductor"
        Me.dtfConductorDetalles.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfConductorDetalles.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfConductorDetalles.ExtraSQL = ""
        Me.dtfConductorDetalles.FocoEnAgregar = False
        Me.dtfConductorDetalles.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfConductorDetalles.Formulario = Nothing
        Me.dtfConductorDetalles.Label_Space = 75
        Me.dtfConductorDetalles.Length_Data = 32767
        Me.dtfConductorDetalles.Location = New System.Drawing.Point(0, 0)
        Me.dtfConductorDetalles.Lupa = Nothing
        Me.dtfConductorDetalles.Max_Value = 0.0R
        Me.dtfConductorDetalles.MensajeIncorrectoCustom = Nothing
        Me.dtfConductorDetalles.Name = "dtfConductorDetalles"
        Me.dtfConductorDetalles.Null_on_Empty = True
        Me.dtfConductorDetalles.OpenForm = Nothing
        Me.dtfConductorDetalles.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfConductorDetalles.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfConductorDetalles.Query_on_Text_Changed = True
        Me.dtfConductorDetalles.ReadOnly_Data = False
        Me.dtfConductorDetalles.ReQuery = False
        Me.dtfConductorDetalles.ShowButton = True
        Me.dtfConductorDetalles.Size = New System.Drawing.Size(435, 26)
        Me.dtfConductorDetalles.TabIndex = 0
        Me.dtfConductorDetalles.Text_Data = ""
        Me.dtfConductorDetalles.Text_Data_Desc = ""
        Me.dtfConductorDetalles.Text_Width = 58
        Me.dtfConductorDetalles.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfConductorDetalles.TopPadding = 0
        Me.dtfConductorDetalles.Upper_Case = False
        Me.dtfConductorDetalles.Validate_on_lost_focus = True
        '
        'pnlSpace23
        '
        Me.pnlSpace23.Auto_Size = False
        Me.pnlSpace23.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace23.ChangeDock = True
        Me.pnlSpace23.Control_Resize = False
        Me.pnlSpace23.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSpace23.isSpace = True
        Me.pnlSpace23.Location = New System.Drawing.Point(435, 0)
        Me.pnlSpace23.Name = "pnlSpace23"
        Me.pnlSpace23.numRows = 0
        Me.pnlSpace23.Reorder = True
        Me.pnlSpace23.Size = New System.Drawing.Size(6, 20)
        Me.pnlSpace23.TabIndex = 1
        '
        'btnCargarCond
        '
        Me.btnCargarCond.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnCargarCond.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnCargarCond.Location = New System.Drawing.Point(441, 0)
        Me.btnCargarCond.Name = "btnCargarCond"
        Me.btnCargarCond.Size = New System.Drawing.Size(44, 20)
        Me.btnCargarCond.TabIndex = 2
        Me.btnCargarCond.Text = "Cargar"
        Me.btnCargarCond.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.btnCargarCond.ThemeName = "Windows8"
        '
        'pnlSpace26
        '
        Me.pnlSpace26.Auto_Size = False
        Me.pnlSpace26.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace26.ChangeDock = True
        Me.pnlSpace26.Control_Resize = False
        Me.pnlSpace26.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSpace26.isSpace = True
        Me.pnlSpace26.Location = New System.Drawing.Point(485, 0)
        Me.pnlSpace26.Name = "pnlSpace26"
        Me.pnlSpace26.numRows = 0
        Me.pnlSpace26.Reorder = True
        Me.pnlSpace26.Size = New System.Drawing.Size(6, 20)
        Me.pnlSpace26.TabIndex = 3
        '
        'btnGuardar
        '
        Me.btnGuardar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnGuardar.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnGuardar.Location = New System.Drawing.Point(491, 0)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(59, 20)
        Me.btnGuardar.TabIndex = 4
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.btnGuardar.ThemeName = "Windows8"
        '
        'Reservas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1272, 754)
        Me.Name = "Reservas"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Reservas"
        CType(Me.pnlBlock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pvwBase, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pvwBase.ResumeLayout(False)
        CType(Me.stbBase, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pvpGeneral.ResumeLayout(False)
        CType(Me.pnlObs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlObs.ResumeLayout(False)
        CType(Me.pnlPpal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPpal.ResumeLayout(False)
        CType(Me.pnlGenDer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlGenDer.ResumeLayout(False)
        CType(Me.gbxCotiza, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxCotiza.ResumeLayout(False)
        CType(Me.pnlCotiza, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCotiza.ResumeLayout(False)
        CType(Me.dgvLiRes.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvLiRes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlGenIzq, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlGenIzq.ResumeLayout(False)
        Me.pnlGenIzq.PerformLayout()
        CType(Me.gbxParamCotiza, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxParamCotiza.ResumeLayout(False)
        CType(Me.Space4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbxCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxCliente.ResumeLayout(False)
        CType(Me.Panel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlObsCli, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlObsCli.ResumeLayout(False)
        CType(Me.pnlObsCliIzq, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Space2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbxLocaliza, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxLocaliza.ResumeLayout(False)
        CType(Me.pnlReferencia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlReferencia.ResumeLayout(False)
        CType(Me.pnlVuelo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlVuelo.ResumeLayout(False)
        CType(Me.pnlLocaliza, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlLocaliza.ResumeLayout(False)
        CType(Me.pnlCabeceraGen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCabeceraGen.ResumeLayout(False)
        CType(Me.pnlCabecera, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCabecera.ResumeLayout(False)
        CType(Me.pnlPeriodo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPeriodo.ResumeLayout(False)
        CType(Me.pnlDatosPrevistos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDatosPrevistos.ResumeLayout(False)
        CType(Me.pnlSpace16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSpace15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSpace14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSpace13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSpace12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlDatosSalida, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDatosSalida.ResumeLayout(False)
        CType(Me.pnlSpace10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSpace19, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSpace19.ResumeLayout(False)
        CType(Me.pnlSpace9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSpace8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSpace7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSpace6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlCodigo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCodigo.ResumeLayout(False)
        CType(Me.pnlSpace5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Space1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlEO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEO.ResumeLayout(False)
        CType(Me.Space, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlBottomGen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBottomGen.ResumeLayout(False)
        CType(Me.dtlUltmodi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtlUsumodi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pvpOtros.ResumeLayout(False)
        CType(Me.pnlCabeceraOtros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pvpCond.ResumeLayout(False)
        CType(Me.pnlCabeceraCond, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlConductoresDer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlConductoresDer.ResumeLayout(False)
        CType(Me.gbxConductoresAdicionales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxConductoresAdicionales.ResumeLayout(False)
        CType(Me.gbxOtroCond3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxOtroCond3.ResumeLayout(False)
        CType(Me.pnlOtroPermismo3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlOtroPermismo3.ResumeLayout(False)
        CType(Me.pnlOtroFPermismo3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlOtroFPermismo3.ResumeLayout(False)
        CType(Me.gbxOtroCond2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxOtroCond2.ResumeLayout(False)
        CType(Me.pnlOtroPermismo2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlOtroPermismo2.ResumeLayout(False)
        CType(Me.pnlOtroFPermismo2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlOtroFPermismo2.ResumeLayout(False)
        CType(Me.gbxOtroCond, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxOtroCond.ResumeLayout(False)
        CType(Me.pnlOtroPermismo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlOtroPermismo.ResumeLayout(False)
        CType(Me.pnlOtroFPermismo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlOtroFPermismo.ResumeLayout(False)
        CType(Me.pnlConductoresIzq, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlConductoresIzq.ResumeLayout(False)
        CType(Me.gbxConductor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxConductor.ResumeLayout(False)
        Me.gbxConductor.PerformLayout()
        CType(Me.pnlTarjeta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTarjeta.ResumeLayout(False)
        Me.pnlTarjeta.PerformLayout()
        CType(Me.pnlSpace31, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTarCadu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSpace30, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlPermiso, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPermiso.ResumeLayout(False)
        CType(Me.pnlPermisoInf, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPermisoInf.ResumeLayout(False)
        CType(Me.pnlSpace29, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlPermisoSup, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPermisoSup.ResumeLayout(False)
        CType(Me.pnlSpace28, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlLuNace, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlLuNace.ResumeLayout(False)
        CType(Me.pnlSpace27, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlNifTelf, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlNifTelf.ResumeLayout(False)
        CType(Me.pnlSpace25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSpace24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlConductor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlConductor.ResumeLayout(False)
        CType(Me.pnlSpace23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnCargarCond, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSpace26, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnGuardar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pvpGeneral As CustomControls.PageViewPage
    Friend WithEvents pnlCabeceraGen As CustomControls.Panel
    Friend WithEvents pvpOtros As CustomControls.PageViewPage
    Friend WithEvents pnlCabeceraOtros As CustomControls.Panel
    Friend WithEvents pvpCond As CustomControls.PageViewPage
    Friend WithEvents pnlCabeceraCond As CustomControls.Panel
    Friend WithEvents pnlPpal As CustomControls.Panel
    Friend WithEvents pnlCabecera As CustomControls.Panel
    Friend WithEvents pnlCodigo As CustomControls.Panel
    Friend WithEvents dtfCodigo As CustomControls.DatafieldLabel
    Friend WithEvents Space As CustomControls.Panel
    Friend WithEvents dtfRSC As CustomControls.DatafieldLabel
    Friend WithEvents Space1 As CustomControls.Panel
    Friend WithEvents pnlEO As CustomControls.Panel
    Friend WithEvents dtfEmpresaOficina As CustomControls.EmpresaOficina
    Friend WithEvents dtdFecha As CustomControls.DataDateLabel
    Friend WithEvents pnlSpace5 As CustomControls.Panel
    Friend WithEvents dttHora As CustomControls.DataTime
    Friend WithEvents pnlPeriodo As CustomControls.Panel
    Friend WithEvents pnlDatosSalida As CustomControls.Panel
    Friend WithEvents dtfLugarEntrega As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace10 As CustomControls.Panel
    Friend WithEvents pnlSpace19 As CustomControls.Panel
    Friend WithEvents pnlSpace9 As CustomControls.Panel
    Friend WithEvents dtfOfiSalida As CustomControls.DualDatafieldLabel
    Friend WithEvents pnlSpace8 As CustomControls.Panel
    Friend WithEvents dttHSalida As CustomControls.DataTime
    Friend WithEvents pnlSpace7 As CustomControls.Panel
    Friend WithEvents dtdFSalida As CustomControls.DataDateLabel
    Friend WithEvents pnlSpace6 As CustomControls.Panel
    Friend WithEvents dtfDiasPrevistos As CustomControls.DatafieldLabel
    Friend WithEvents pnlDatosPrevistos As CustomControls.Panel
    Friend WithEvents dtfLugarRecogida As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace16 As CustomControls.Panel
    Friend WithEvents pnlSpace15 As CustomControls.Panel
    Friend WithEvents dtfOfiLlegada As CustomControls.DualDatafieldLabel
    Friend WithEvents pnlSpace14 As CustomControls.Panel
    Friend WithEvents dttHPrevista As CustomControls.DataTime
    Friend WithEvents pnlSpace13 As CustomControls.Panel
    Friend WithEvents dtdFPrevista As CustomControls.DataDateLabel
    Friend WithEvents pnlSpace12 As CustomControls.Panel
    Friend WithEvents pnlObs As CustomControls.Panel
    Friend WithEvents dtaObs As CustomControls.DataAreaLabel
    Friend WithEvents pnlGenDer As CustomControls.Panel
    Friend WithEvents pnlGenIzq As CustomControls.Panel
    Friend WithEvents gbxParamCotiza As CustomControls.GroupBox
    Friend WithEvents dtfSubComisio As CustomControls.DualDatafieldLabel
    Friend WithEvents dtfComisio As CustomControls.DualDatafieldLabel
    Friend WithEvents dtfPreferencia As CustomControls.DatafieldLabel
    Friend WithEvents dtfGrupo As CustomControls.DualDatafieldLabel
    Friend WithEvents dtfTarifa As CustomControls.DualDatafieldLabel
    Friend WithEvents Space4 As CustomControls.Panel
    Friend WithEvents gbxCliente As CustomControls.GroupBox
    Friend WithEvents dtfConductor As CustomControls.DualDataFieldEditableLabel
    Friend WithEvents Panel2 As CustomControls.Panel
    Friend WithEvents pnlObsCli As CustomControls.Panel
    Friend WithEvents dtaObsCli As CustomControls.DataArea
    Friend WithEvents pnlObsCliIzq As CustomControls.Panel
    Friend WithEvents dtfCliente As CustomControls.DualDataFieldEditableLabel
    Friend WithEvents Space2 As CustomControls.Panel
    Friend WithEvents gbxLocaliza As CustomControls.GroupBox
    Friend WithEvents pnlReferencia As CustomControls.Panel
    Friend WithEvents dtfReferencia As CustomControls.DatafieldLabel
    Friend WithEvents pnlVuelo As CustomControls.Panel
    Friend WithEvents dtfVuelo As CustomControls.DatafieldLabel
    Friend WithEvents pnlLocaliza As CustomControls.Panel
    Friend WithEvents dtfLocaliza As CustomControls.DatafieldLabel
    Friend WithEvents pnlBottomGen As CustomControls.Panel
    Friend WithEvents dtlUltmodi As CustomControls.DataLabel
    Friend WithEvents dtlUsumodi As CustomControls.DataLabel
    Friend WithEvents gbxCotiza As CustomControls.GroupBox
    Friend WithEvents pnlCotiza As CustomControls.Panel
    Friend WithEvents dgvLiRes As Karve.frm.RentACar.GridLiRes
    Friend WithEvents pnlConductoresDer As CustomControls.Panel
    Friend WithEvents gbxConductoresAdicionales As CustomControls.GroupBox
    Friend WithEvents gbxOtroCond3 As CustomControls.GroupBox
    Friend WithEvents pnlOtroPermismo3 As CustomControls.Panel
    Friend WithEvents dtdOtroNac3 As CustomControls.DataDateLabel
    Friend WithEvents dtfOtroPer3 As CustomControls.DatafieldLabel
    Friend WithEvents pnlOtroFPermismo3 As CustomControls.Panel
    Friend WithEvents dtdOtroCadu3 As CustomControls.DataDateLabel
    Friend WithEvents dtdOtroExpe3 As CustomControls.DataDateLabel
    Friend WithEvents dtfOtroCond3 As CustomControls.DualDatafieldLabel
    Friend WithEvents gbxOtroCond2 As CustomControls.GroupBox
    Friend WithEvents pnlOtroPermismo2 As CustomControls.Panel
    Friend WithEvents dtdOtroNac2 As CustomControls.DataDateLabel
    Friend WithEvents dtfOtroPer2 As CustomControls.DatafieldLabel
    Friend WithEvents pnlOtroFPermismo2 As CustomControls.Panel
    Friend WithEvents dtdOtroCadu2 As CustomControls.DataDateLabel
    Friend WithEvents dtdOtroExpe2 As CustomControls.DataDateLabel
    Friend WithEvents dtfOtroCond2 As CustomControls.DualDatafieldLabel
    Friend WithEvents gbxOtroCond As CustomControls.GroupBox
    Friend WithEvents pnlOtroPermismo As CustomControls.Panel
    Friend WithEvents dtdOtroNac As CustomControls.DataDateLabel
    Friend WithEvents dtfOtroPer As CustomControls.DatafieldLabel
    Friend WithEvents pnlOtroFPermismo As CustomControls.Panel
    Friend WithEvents dtdOtroCadu As CustomControls.DataDateLabel
    Friend WithEvents dtdOtroExpe As CustomControls.DataDateLabel
    Friend WithEvents dtfOtroCond As CustomControls.DualDatafieldLabel
    Friend WithEvents pnlConductoresIzq As CustomControls.Panel
    Friend WithEvents gbxConductor As CustomControls.GroupBox
    Friend WithEvents pnlTarjeta As CustomControls.Panel
    Friend WithEvents dtfTarNum As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace31 As CustomControls.Panel
    Friend WithEvents lblTarCadu As CustomControls.Label
    Friend WithEvents pnlSpace30 As CustomControls.Panel
    Friend WithEvents mdfTarcadu As CustomControls.MaskedDataField
    Friend WithEvents dtfTarjetaCond As CustomControls.DualDatafieldLabel
    Friend WithEvents dtfEmailCond As CustomControls.DatafieldLabel
    Friend WithEvents pnlPermiso As CustomControls.Panel
    Friend WithEvents pnlPermisoInf As CustomControls.Panel
    Friend WithEvents dtfLuExpe As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace29 As CustomControls.Panel
    Friend WithEvents dtdFeExpe As CustomControls.DataDateLabel
    Friend WithEvents pnlPermisoSup As CustomControls.Panel
    Friend WithEvents dtfPermiso As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace28 As CustomControls.Panel
    Friend WithEvents dtfClase As CustomControls.DatafieldLabel
    Friend WithEvents pnlLuNace As CustomControls.Panel
    Friend WithEvents dtfLuNace As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace27 As CustomControls.Panel
    Friend WithEvents dtdFechaNac As CustomControls.DataDateLabel
    Friend WithEvents pnlNifTelf As CustomControls.Panel
    Friend WithEvents dtfNIFCond As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace25 As CustomControls.Panel
    Friend WithEvents dtfTelfCond As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace24 As CustomControls.Panel
    Friend WithEvents dtfTelfCond2 As CustomControls.Datafield
    Friend WithEvents dtdDirCond As CustomControls.DataDir
    Friend WithEvents dtfNombreCond As CustomControls.DatafieldLabel
    Friend WithEvents pnlConductor As CustomControls.Panel
    Friend WithEvents dtfConductorDetalles As CustomControls.DualDatafieldLabel
    Friend WithEvents pnlSpace23 As CustomControls.Panel
    Friend WithEvents btnCargarCond As CustomControls.Button
    Friend WithEvents pnlSpace26 As CustomControls.Panel
    Friend WithEvents btnGuardar As CustomControls.Button
End Class
