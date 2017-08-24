<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Facturas
    Inherits Bases.frmBase

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
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
        Me.pvpCabezera = New CustomControls.PageViewPage()
        Me.pnlLifacs = New CustomControls.Panel()
        Me.dgvLifacs = New Karve.frm.Facturas.GridLiFacs()
        Me.pnlCabecera = New CustomControls.Panel()
        Me.pnlCabezeraDer = New CustomControls.Panel()
        Me.pnlPago = New CustomControls.Panel()
        Me.pnlReferencia = New CustomControls.Panel()
        Me.dtfReferencia = New CustomControls.DatafieldLabel()
        Me.pnlSpace5 = New CustomControls.Panel()
        Me.dtfAsiento = New CustomControls.DatafieldLabel()
        Me.pnlIbanSwift = New CustomControls.Panel()
        Me.dtfIban = New CustomControls.DatafieldLabel()
        Me.pnlSpace4 = New CustomControls.Panel()
        Me.dtfSwift = New CustomControls.DatafieldLabel()
        Me.pnlFormaPago = New CustomControls.Panel()
        Me.dtfFormaPago = New CustomControls.DualDatafieldLabel()
        Me.pnlSpace3 = New CustomControls.Panel()
        Me.dtdVencimiento = New CustomControls.DataDateLabel()
        Me.btnHideCabecera = New CustomControls.Button()
        Me.dtfVendedor = New CustomControls.DualDatafieldLabel()
        Me.dtfPersona = New CustomControls.DatafieldLabel()
        Me.dtfDelegacion = New CustomControls.DualDatafieldLabel()
        Me.dtfCliente = New CustomControls.DualDatafieldLabel()
        Me.pnlCabezeraIzq = New CustomControls.Panel()
        Me.btnMotivoAbono = New CustomControls.Button()
        Me.pnlRectifica = New CustomControls.Panel()
        Me.dtfFacRectifPor = New CustomControls.DatafieldLabel()
        Me.dtfAbonoDeFac = New CustomControls.DatafieldLabel()
        Me.dtfExtra = New CustomControls.DualDatafieldLabel()
        Me.dtfTipoImpreso = New CustomControls.DualDatafieldLabel()
        Me.dtfOrigen = New CustomControls.DualDatafieldLabel()
        Me.dtfDepartamento = New CustomControls.DualDatafieldLabel()
        Me.pnlEmpOfi = New CustomControls.Panel()
        Me.dtfOficina = New CustomControls.DualDatafieldLabel()
        Me.pnlSpace2 = New CustomControls.Panel()
        Me.dtfEmpresa = New CustomControls.DualDatafieldLabel()
        Me.pnlNumeroFecha = New CustomControls.Panel()
        Me.dtdFefchaFac = New CustomControls.DataDateLabel()
        Me.pnlSpace1 = New CustomControls.Panel()
        Me.dtfNumero = New CustomControls.DatafieldLabel()
        Me.pnlPie = New CustomControls.Panel()
        Me.dgvBases = New Karve.frm.Facturas.GridBasesFac()
        Me.pnlTotales = New CustomControls.Panel()
        Me.btnHidePie = New CustomControls.Button()
        Me.dtfTotalFac = New CustomControls.DatafieldLabel()
        Me.pnlDtoPie = New CustomControls.Panel()
        Me.dtfImpDtoPie = New CustomControls.Datafield()
        Me.pnlSpace7 = New CustomControls.Panel()
        Me.lblPorcen2 = New CustomControls.Label()
        Me.dtfDtoPie = New CustomControls.DatafieldLabel()
        Me.pnlDtoPP = New CustomControls.Panel()
        Me.dtfImpDtoPP = New CustomControls.Datafield()
        Me.pnlSpace6 = New CustomControls.Panel()
        Me.lblPorcen1 = New CustomControls.Label()
        Me.dtfDtoPP = New CustomControls.DatafieldLabel()
        Me.dtfBaseSin = New CustomControls.DatafieldLabel()
        Me.dtfBrutoFac = New CustomControls.DatafieldLabel()
        Me.pnlDivisa = New CustomControls.Panel()
        Me.lblDivisa5 = New CustomControls.Label()
        Me.lblDivisa4 = New CustomControls.Label()
        Me.lblDivisa3 = New CustomControls.Label()
        Me.lblDivisa2 = New CustomControls.Label()
        Me.lblDivisa1 = New CustomControls.Label()
        Me.TelerikMetroBlueTheme1 = New Telerik.WinControls.Themes.TelerikMetroBlueTheme()
        Me.pvpOtrosDatos = New CustomControls.PageViewPage()
        Me.pnlOtrosDatos = New CustomControls.Panel()
        Me.gbxCliFac = New CustomControls.GroupBox()
        Me.dirCliFac = New CustomControls.DataDir()
        Me.pnlNomNifCliFac = New CustomControls.Panel()
        Me.dtfNombreCliFac = New CustomControls.DatafieldLabel()
        Me.Panel1 = New CustomControls.Panel()
        Me.dtfNIFCliFac = New CustomControls.DatafieldLabel()
        Me.pnlOtrosIzq = New CustomControls.Panel()
        Me.gbxVencimientos = New CustomControls.GroupBox()
        Me.btnRecalcVtos = New CustomControls.Button()
        Me.btnResetVto = New CustomControls.Button()
        Me.pnlVto10 = New CustomControls.Panel()
        Me.dtfImpVto10 = New CustomControls.DatafieldLabel()
        Me.pnlSpace36 = New CustomControls.Panel()
        Me.lblGuion10 = New CustomControls.Label()
        Me.pnlSpace37 = New CustomControls.Panel()
        Me.lblEur10 = New CustomControls.Label()
        Me.pnlSpace35 = New CustomControls.Panel()
        Me.dtdVto10 = New CustomControls.DataDateLabel()
        Me.pnlVto9 = New CustomControls.Panel()
        Me.dtfImpVto9 = New CustomControls.DatafieldLabel()
        Me.pnlSpace33 = New CustomControls.Panel()
        Me.lblGuion9 = New CustomControls.Label()
        Me.pnlSpace34 = New CustomControls.Panel()
        Me.lblEur9 = New CustomControls.Label()
        Me.pnlSpace32 = New CustomControls.Panel()
        Me.dtdVto9 = New CustomControls.DataDateLabel()
        Me.pnlVto8 = New CustomControls.Panel()
        Me.dtfImpVto8 = New CustomControls.DatafieldLabel()
        Me.pnlSpace30 = New CustomControls.Panel()
        Me.lblGuion8 = New CustomControls.Label()
        Me.pnlSpace31 = New CustomControls.Panel()
        Me.lblEur8 = New CustomControls.Label()
        Me.pnlSpace29 = New CustomControls.Panel()
        Me.dtdVto8 = New CustomControls.DataDateLabel()
        Me.pnlVto7 = New CustomControls.Panel()
        Me.dtfImpVto7 = New CustomControls.DatafieldLabel()
        Me.pnlSpace27 = New CustomControls.Panel()
        Me.lblGuion7 = New CustomControls.Label()
        Me.pnlSpace28 = New CustomControls.Panel()
        Me.lblEur7 = New CustomControls.Label()
        Me.pnlSpace26 = New CustomControls.Panel()
        Me.dtdVto7 = New CustomControls.DataDateLabel()
        Me.pnlVto6 = New CustomControls.Panel()
        Me.dtfImpVto6 = New CustomControls.DatafieldLabel()
        Me.pnlSpace24 = New CustomControls.Panel()
        Me.lblGuion6 = New CustomControls.Label()
        Me.pnlSpace25 = New CustomControls.Panel()
        Me.lblEur6 = New CustomControls.Label()
        Me.pnlSpace23 = New CustomControls.Panel()
        Me.dtdVto6 = New CustomControls.DataDateLabel()
        Me.pnlVto5 = New CustomControls.Panel()
        Me.dtfImpVto5 = New CustomControls.DatafieldLabel()
        Me.pnlSpace21 = New CustomControls.Panel()
        Me.lblGuion5 = New CustomControls.Label()
        Me.pnlSpace22 = New CustomControls.Panel()
        Me.lblEur5 = New CustomControls.Label()
        Me.pnlSpace20 = New CustomControls.Panel()
        Me.dtdVto5 = New CustomControls.DataDateLabel()
        Me.pnlVto4 = New CustomControls.Panel()
        Me.dtfImpVto4 = New CustomControls.DatafieldLabel()
        Me.pnlSpace18 = New CustomControls.Panel()
        Me.lblGuion4 = New CustomControls.Label()
        Me.pnlSpace19 = New CustomControls.Panel()
        Me.lblEur4 = New CustomControls.Label()
        Me.pnlSpace17 = New CustomControls.Panel()
        Me.dtdVto4 = New CustomControls.DataDateLabel()
        Me.pnlVto3 = New CustomControls.Panel()
        Me.dtfImpVto3 = New CustomControls.DatafieldLabel()
        Me.pnlSpace15 = New CustomControls.Panel()
        Me.lblGuion3 = New CustomControls.Label()
        Me.pnlSpace16 = New CustomControls.Panel()
        Me.lblEur3 = New CustomControls.Label()
        Me.pnlSpace14 = New CustomControls.Panel()
        Me.dtdVto3 = New CustomControls.DataDateLabel()
        Me.pnlVto2 = New CustomControls.Panel()
        Me.dtfImpVto2 = New CustomControls.DatafieldLabel()
        Me.pnlSpace12 = New CustomControls.Panel()
        Me.lblGuion2 = New CustomControls.Label()
        Me.pnlSpace13 = New CustomControls.Panel()
        Me.lblEur2 = New CustomControls.Label()
        Me.pnlSpace11 = New CustomControls.Panel()
        Me.dtdVto2 = New CustomControls.DataDateLabel()
        Me.pnlVto1 = New CustomControls.Panel()
        Me.dtfImpVto1 = New CustomControls.DatafieldLabel()
        Me.pnlSpace9 = New CustomControls.Panel()
        Me.lblGuion1 = New CustomControls.Label()
        Me.pnlSpace10 = New CustomControls.Panel()
        Me.lblEur1 = New CustomControls.Label()
        Me.pnlSpace8 = New CustomControls.Panel()
        Me.dtdVto1 = New CustomControls.DataDateLabel()
        CType(Me.pnlBlock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pvwBase, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pvwBase.SuspendLayout()
        CType(Me.stbBase, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pvpCabezera.SuspendLayout()
        CType(Me.pnlLifacs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlLifacs.SuspendLayout()
        CType(Me.dgvLifacs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvLifacs.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlCabecera, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCabecera.SuspendLayout()
        CType(Me.pnlCabezeraDer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCabezeraDer.SuspendLayout()
        CType(Me.pnlPago, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPago.SuspendLayout()
        CType(Me.pnlReferencia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlReferencia.SuspendLayout()
        CType(Me.pnlSpace5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlIbanSwift, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlIbanSwift.SuspendLayout()
        CType(Me.pnlSpace4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlFormaPago, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFormaPago.SuspendLayout()
        CType(Me.pnlSpace3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnHideCabecera, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlCabezeraIzq, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCabezeraIzq.SuspendLayout()
        CType(Me.btnMotivoAbono, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlRectifica, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlRectifica.SuspendLayout()
        CType(Me.pnlEmpOfi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEmpOfi.SuspendLayout()
        CType(Me.pnlSpace2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlNumeroFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlNumeroFecha.SuspendLayout()
        CType(Me.pnlSpace1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlPie, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPie.SuspendLayout()
        CType(Me.dgvBases, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvBases.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlTotales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTotales.SuspendLayout()
        CType(Me.btnHidePie, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlDtoPie, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDtoPie.SuspendLayout()
        CType(Me.pnlSpace7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPorcen2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlDtoPP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDtoPP.SuspendLayout()
        CType(Me.pnlSpace6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPorcen1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlDivisa, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDivisa.SuspendLayout()
        CType(Me.lblDivisa5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDivisa4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDivisa3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDivisa2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDivisa1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pvpOtrosDatos.SuspendLayout()
        CType(Me.pnlOtrosDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlOtrosDatos.SuspendLayout()
        CType(Me.gbxCliFac, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxCliFac.SuspendLayout()
        CType(Me.pnlNomNifCliFac, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlNomNifCliFac.SuspendLayout()
        CType(Me.Panel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlOtrosIzq, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlOtrosIzq.SuspendLayout()
        CType(Me.gbxVencimientos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxVencimientos.SuspendLayout()
        CType(Me.btnRecalcVtos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnResetVto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlVto10, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlVto10.SuspendLayout()
        CType(Me.pnlSpace36, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblGuion10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSpace37, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblEur10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSpace35, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlVto9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlVto9.SuspendLayout()
        CType(Me.pnlSpace33, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblGuion9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSpace34, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblEur9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSpace32, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlVto8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlVto8.SuspendLayout()
        CType(Me.pnlSpace30, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblGuion8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSpace31, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblEur8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSpace29, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlVto7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlVto7.SuspendLayout()
        CType(Me.pnlSpace27, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblGuion7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSpace28, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblEur7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSpace26, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlVto6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlVto6.SuspendLayout()
        CType(Me.pnlSpace24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblGuion6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSpace25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblEur6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSpace23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlVto5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlVto5.SuspendLayout()
        CType(Me.pnlSpace21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblGuion5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSpace22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblEur5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSpace20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlVto4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlVto4.SuspendLayout()
        CType(Me.pnlSpace18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblGuion4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSpace19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblEur4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSpace17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlVto3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlVto3.SuspendLayout()
        CType(Me.pnlSpace15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblGuion3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSpace16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblEur3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSpace14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlVto2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlVto2.SuspendLayout()
        CType(Me.pnlSpace12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblGuion2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSpace13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblEur2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSpace11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlVto1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlVto1.SuspendLayout()
        CType(Me.pnlSpace9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblGuion1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSpace10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblEur1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSpace8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlBlock
        '
        Me.pnlBlock.Location = New System.Drawing.Point(0, 547)
        '
        'pvwBase
        '
        Me.pvwBase.Controls.Add(Me.pvpCabezera)
        Me.pvwBase.Controls.Add(Me.pvpOtrosDatos)
        Me.pvwBase.SelectedPage = Me.pvpCabezera
        Me.pvwBase.Size = New System.Drawing.Size(1073, 454)
        '
        'stbBase
        '
        Me.stbBase.Location = New System.Drawing.Point(0, 454)
        Me.stbBase.Size = New System.Drawing.Size(1073, 25)
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
        'pvpCabezera
        '
        Me.pvpCabezera.Controls.Add(Me.pnlLifacs)
        Me.pvpCabezera.Controls.Add(Me.pnlCabecera)
        Me.pvpCabezera.Controls.Add(Me.pnlPie)
        Me.pvpCabezera.ItemSize = New System.Drawing.SizeF(106.0!, 23.0!)
        Me.pvpCabezera.Location = New System.Drawing.Point(129, 5)
        Me.pvpCabezera.Name = "pvpCabezera"
        Me.pvpCabezera.PanelCabezeraContainer = Nothing
        Me.pvpCabezera.Size = New System.Drawing.Size(939, 444)
        Me.pvpCabezera.Text = "Datos Generales"
        '
        'pnlLifacs
        '
        Me.pnlLifacs.Auto_Size = False
        Me.pnlLifacs.BackColor = System.Drawing.SystemColors.Control
        Me.pnlLifacs.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlLifacs.ChangeDock = False
        Me.pnlLifacs.Control_Resize = False
        Me.pnlLifacs.Controls.Add(Me.dgvLifacs)
        Me.pnlLifacs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlLifacs.isSpace = False
        Me.pnlLifacs.Location = New System.Drawing.Point(0, 182)
        Me.pnlLifacs.Name = "pnlLifacs"
        Me.pnlLifacs.numRows = 0
        Me.pnlLifacs.Padding = New System.Windows.Forms.Padding(0, 3, 0, 5)
        Me.pnlLifacs.Reorder = False
        Me.pnlLifacs.Size = New System.Drawing.Size(939, 132)
        Me.pnlLifacs.TabIndex = 6
        '
        'dgvLifacs
        '
        Me.dgvLifacs.AllowDrop = True
        Me.dgvLifacs.ColRel = Nothing
        Me.dgvLifacs.ColSelectFilter = Nothing
        Me.dgvLifacs.DataGridType = CustomControls.DataGrid.GridType.Edit
        Me.dgvLifacs.DBConnection = Nothing
        Me.dgvLifacs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvLifacs.EnforceConstrains = True
        Me.dgvLifacs.idRel = Nothing
        Me.dgvLifacs.Location = New System.Drawing.Point(0, 3)
        Me.dgvLifacs.MarcarFilas = False
        '
        'dgvLifacs
        '
        Me.dgvLifacs.MasterTemplate.AllowColumnChooser = False
        Me.dgvLifacs.MasterTemplate.AllowRowReorder = True
        Me.dgvLifacs.MasterTemplate.AllowRowResize = False
        Me.dgvLifacs.MasterTemplate.EnableFiltering = True
        Me.dgvLifacs.MasterTemplate.EnableGrouping = False
        Me.dgvLifacs.MasterTemplate.MultiSelect = True
        Me.dgvLifacs.MasterTemplate.SelectionMode = Telerik.WinControls.UI.GridViewSelectionMode.CellSelect
        Me.dgvLifacs.Name = "dgvLifacs"
        Me.dgvLifacs.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.dgvLifacs.Size = New System.Drawing.Size(939, 124)
        Me.dgvLifacs.TabIndex = 4
        Me.dgvLifacs.TablaEdit = Nothing
        Me.dgvLifacs.Text = "DataGrid1"
        Me.dgvLifacs.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dgvLifacs.ThemeName = "TelerikMetroBlue"
        '
        'pnlCabecera
        '
        Me.pnlCabecera.Auto_Size = False
        Me.pnlCabecera.BackColor = System.Drawing.SystemColors.Control
        Me.pnlCabecera.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlCabecera.ChangeDock = False
        Me.pnlCabecera.Control_Resize = False
        Me.pnlCabecera.Controls.Add(Me.pnlCabezeraDer)
        Me.pnlCabecera.Controls.Add(Me.pnlCabezeraIzq)
        Me.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCabecera.isSpace = False
        Me.pnlCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlCabecera.Name = "pnlCabecera"
        Me.pnlCabecera.numRows = 7
        Me.pnlCabecera.Reorder = True
        Me.pnlCabecera.Size = New System.Drawing.Size(939, 182)
        Me.pnlCabecera.TabIndex = 0
        '
        'pnlCabezeraDer
        '
        Me.pnlCabezeraDer.Auto_Size = False
        Me.pnlCabezeraDer.BackColor = System.Drawing.SystemColors.Control
        Me.pnlCabezeraDer.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlCabezeraDer.ChangeDock = True
        Me.pnlCabezeraDer.Control_Resize = False
        Me.pnlCabezeraDer.Controls.Add(Me.pnlPago)
        Me.pnlCabezeraDer.Controls.Add(Me.btnHideCabecera)
        Me.pnlCabezeraDer.Controls.Add(Me.dtfVendedor)
        Me.pnlCabezeraDer.Controls.Add(Me.dtfPersona)
        Me.pnlCabezeraDer.Controls.Add(Me.dtfDelegacion)
        Me.pnlCabezeraDer.Controls.Add(Me.dtfCliente)
        Me.pnlCabezeraDer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlCabezeraDer.isSpace = False
        Me.pnlCabezeraDer.Location = New System.Drawing.Point(358, 0)
        Me.pnlCabezeraDer.Name = "pnlCabezeraDer"
        Me.pnlCabezeraDer.numRows = 8
        Me.pnlCabezeraDer.Padding = New System.Windows.Forms.Padding(3, 3, 26, 3)
        Me.pnlCabezeraDer.Reorder = True
        Me.pnlCabezeraDer.Size = New System.Drawing.Size(581, 182)
        Me.pnlCabezeraDer.TabIndex = 1
        '
        'pnlPago
        '
        Me.pnlPago.Auto_Size = False
        Me.pnlPago.BackColor = System.Drawing.SystemColors.Control
        Me.pnlPago.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlPago.ChangeDock = True
        Me.pnlPago.Control_Resize = False
        Me.pnlPago.Controls.Add(Me.pnlReferencia)
        Me.pnlPago.Controls.Add(Me.pnlIbanSwift)
        Me.pnlPago.Controls.Add(Me.pnlFormaPago)
        Me.pnlPago.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlPago.isSpace = False
        Me.pnlPago.Location = New System.Drawing.Point(3, 107)
        Me.pnlPago.Name = "pnlPago"
        Me.pnlPago.numRows = 3
        Me.pnlPago.Reorder = True
        Me.pnlPago.Size = New System.Drawing.Size(552, 78)
        Me.pnlPago.TabIndex = 5
        '
        'pnlReferencia
        '
        Me.pnlReferencia.Auto_Size = False
        Me.pnlReferencia.BackColor = System.Drawing.SystemColors.Control
        Me.pnlReferencia.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlReferencia.ChangeDock = True
        Me.pnlReferencia.Control_Resize = False
        Me.pnlReferencia.Controls.Add(Me.dtfReferencia)
        Me.pnlReferencia.Controls.Add(Me.pnlSpace5)
        Me.pnlReferencia.Controls.Add(Me.dtfAsiento)
        Me.pnlReferencia.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlReferencia.isSpace = False
        Me.pnlReferencia.Location = New System.Drawing.Point(0, 52)
        Me.pnlReferencia.Name = "pnlReferencia"
        Me.pnlReferencia.numRows = 1
        Me.pnlReferencia.Reorder = True
        Me.pnlReferencia.Size = New System.Drawing.Size(552, 26)
        Me.pnlReferencia.TabIndex = 2
        '
        'dtfReferencia
        '
        Me.dtfReferencia.Allow_Empty = True
        Me.dtfReferencia.Allow_Negative = True
        Me.dtfReferencia.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfReferencia.BackColor = System.Drawing.SystemColors.Control
        Me.dtfReferencia.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfReferencia.DataField = "REFEREN_FAC"
        Me.dtfReferencia.DataTable = "F"
        Me.dtfReferencia.Descripcion = "Referencia"
        Me.dtfReferencia.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfReferencia.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfReferencia.FocoEnAgregar = False
        Me.dtfReferencia.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfReferencia.Image = Nothing
        Me.dtfReferencia.Label_Space = 75
        Me.dtfReferencia.Length_Data = 32767
        Me.dtfReferencia.Location = New System.Drawing.Point(0, 0)
        Me.dtfReferencia.Max_Value = 0R
        Me.dtfReferencia.MensajeIncorrectoCustom = Nothing
        Me.dtfReferencia.Name = "dtfReferencia"
        Me.dtfReferencia.Null_on_Empty = True
        Me.dtfReferencia.OpenForm = Nothing
        Me.dtfReferencia.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfReferencia.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfReferencia.ReadOnly_Data = False
        Me.dtfReferencia.Show_Button = False
        Me.dtfReferencia.Size = New System.Drawing.Size(381, 26)
        Me.dtfReferencia.TabIndex = 0
        Me.dtfReferencia.Text_Data = ""
        Me.dtfReferencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfReferencia.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfReferencia.TopPadding = 0
        Me.dtfReferencia.Upper_Case = False
        Me.dtfReferencia.Validate_on_lost_focus = True
        '
        'pnlSpace5
        '
        Me.pnlSpace5.Auto_Size = False
        Me.pnlSpace5.BackColor = System.Drawing.SystemColors.Control
        Me.pnlSpace5.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace5.ChangeDock = True
        Me.pnlSpace5.Control_Resize = False
        Me.pnlSpace5.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSpace5.isSpace = True
        Me.pnlSpace5.Location = New System.Drawing.Point(381, 0)
        Me.pnlSpace5.Name = "pnlSpace5"
        Me.pnlSpace5.numRows = 0
        Me.pnlSpace5.Reorder = True
        Me.pnlSpace5.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace5.TabIndex = 1
        '
        'dtfAsiento
        '
        Me.dtfAsiento.Allow_Empty = True
        Me.dtfAsiento.Allow_Negative = True
        Me.dtfAsiento.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfAsiento.BackColor = System.Drawing.SystemColors.Control
        Me.dtfAsiento.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfAsiento.DataField = "ASIENTO_FAC"
        Me.dtfAsiento.DataTable = "F"
        Me.dtfAsiento.Descripcion = "Asiento"
        Me.dtfAsiento.Dock = System.Windows.Forms.DockStyle.Right
        Me.dtfAsiento.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfAsiento.FocoEnAgregar = False
        Me.dtfAsiento.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfAsiento.Image = Nothing
        Me.dtfAsiento.Label_Space = 50
        Me.dtfAsiento.Length_Data = 32767
        Me.dtfAsiento.Location = New System.Drawing.Point(387, 0)
        Me.dtfAsiento.Max_Value = 0R
        Me.dtfAsiento.MensajeIncorrectoCustom = Nothing
        Me.dtfAsiento.Name = "dtfAsiento"
        Me.dtfAsiento.Null_on_Empty = True
        Me.dtfAsiento.OpenForm = Nothing
        Me.dtfAsiento.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfAsiento.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfAsiento.ReadOnly_Data = True
        Me.dtfAsiento.Show_Button = True
        Me.dtfAsiento.Size = New System.Drawing.Size(165, 26)
        Me.dtfAsiento.TabIndex = 2
        Me.dtfAsiento.TabStop = False
        Me.dtfAsiento.Text_Data = ""
        Me.dtfAsiento.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfAsiento.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfAsiento.TopPadding = 0
        Me.dtfAsiento.Upper_Case = False
        Me.dtfAsiento.Validate_on_lost_focus = True
        '
        'pnlIbanSwift
        '
        Me.pnlIbanSwift.Auto_Size = False
        Me.pnlIbanSwift.BackColor = System.Drawing.SystemColors.Control
        Me.pnlIbanSwift.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlIbanSwift.ChangeDock = True
        Me.pnlIbanSwift.Control_Resize = False
        Me.pnlIbanSwift.Controls.Add(Me.dtfIban)
        Me.pnlIbanSwift.Controls.Add(Me.pnlSpace4)
        Me.pnlIbanSwift.Controls.Add(Me.dtfSwift)
        Me.pnlIbanSwift.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlIbanSwift.isSpace = False
        Me.pnlIbanSwift.Location = New System.Drawing.Point(0, 26)
        Me.pnlIbanSwift.Name = "pnlIbanSwift"
        Me.pnlIbanSwift.numRows = 1
        Me.pnlIbanSwift.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.pnlIbanSwift.Reorder = True
        Me.pnlIbanSwift.Size = New System.Drawing.Size(552, 26)
        Me.pnlIbanSwift.TabIndex = 1
        '
        'dtfIban
        '
        Me.dtfIban.Allow_Empty = True
        Me.dtfIban.Allow_Negative = True
        Me.dtfIban.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfIban.BackColor = System.Drawing.SystemColors.Control
        Me.dtfIban.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfIban.DataField = "IBAN_FAC"
        Me.dtfIban.DataTable = "F"
        Me.dtfIban.Descripcion = "IBAN"
        Me.dtfIban.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfIban.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfIban.FocoEnAgregar = False
        Me.dtfIban.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfIban.Image = Nothing
        Me.dtfIban.Label_Space = 75
        Me.dtfIban.Length_Data = 32767
        Me.dtfIban.Location = New System.Drawing.Point(0, 0)
        Me.dtfIban.Max_Value = 0R
        Me.dtfIban.MensajeIncorrectoCustom = Nothing
        Me.dtfIban.Name = "dtfIban"
        Me.dtfIban.Null_on_Empty = True
        Me.dtfIban.OpenForm = Nothing
        Me.dtfIban.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfIban.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfIban.ReadOnly_Data = False
        Me.dtfIban.Show_Button = False
        Me.dtfIban.Size = New System.Drawing.Size(381, 26)
        Me.dtfIban.TabIndex = 0
        Me.dtfIban.Text_Data = ""
        Me.dtfIban.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfIban.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfIban.TopPadding = 0
        Me.dtfIban.Upper_Case = False
        Me.dtfIban.Validate_on_lost_focus = True
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
        Me.pnlSpace4.Location = New System.Drawing.Point(381, 0)
        Me.pnlSpace4.Name = "pnlSpace4"
        Me.pnlSpace4.numRows = 0
        Me.pnlSpace4.Reorder = True
        Me.pnlSpace4.Size = New System.Drawing.Size(6, 20)
        Me.pnlSpace4.TabIndex = 1
        '
        'dtfSwift
        '
        Me.dtfSwift.Allow_Empty = True
        Me.dtfSwift.Allow_Negative = True
        Me.dtfSwift.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfSwift.BackColor = System.Drawing.SystemColors.Control
        Me.dtfSwift.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfSwift.DataField = "SWIFT_FAC"
        Me.dtfSwift.DataTable = "F"
        Me.dtfSwift.Descripcion = "SWIFT"
        Me.dtfSwift.Dock = System.Windows.Forms.DockStyle.Right
        Me.dtfSwift.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfSwift.FocoEnAgregar = False
        Me.dtfSwift.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfSwift.Image = Nothing
        Me.dtfSwift.Label_Space = 50
        Me.dtfSwift.Length_Data = 32767
        Me.dtfSwift.Location = New System.Drawing.Point(387, 0)
        Me.dtfSwift.Max_Value = 0R
        Me.dtfSwift.MensajeIncorrectoCustom = Nothing
        Me.dtfSwift.Name = "dtfSwift"
        Me.dtfSwift.Null_on_Empty = True
        Me.dtfSwift.OpenForm = Nothing
        Me.dtfSwift.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfSwift.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfSwift.ReadOnly_Data = False
        Me.dtfSwift.Show_Button = False
        Me.dtfSwift.Size = New System.Drawing.Size(165, 20)
        Me.dtfSwift.TabIndex = 2
        Me.dtfSwift.Text_Data = ""
        Me.dtfSwift.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfSwift.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfSwift.TopPadding = 0
        Me.dtfSwift.Upper_Case = False
        Me.dtfSwift.Validate_on_lost_focus = True
        '
        'pnlFormaPago
        '
        Me.pnlFormaPago.Auto_Size = False
        Me.pnlFormaPago.BackColor = System.Drawing.SystemColors.Control
        Me.pnlFormaPago.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlFormaPago.ChangeDock = True
        Me.pnlFormaPago.Control_Resize = False
        Me.pnlFormaPago.Controls.Add(Me.dtfFormaPago)
        Me.pnlFormaPago.Controls.Add(Me.pnlSpace3)
        Me.pnlFormaPago.Controls.Add(Me.dtdVencimiento)
        Me.pnlFormaPago.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFormaPago.isSpace = False
        Me.pnlFormaPago.Location = New System.Drawing.Point(0, 0)
        Me.pnlFormaPago.Name = "pnlFormaPago"
        Me.pnlFormaPago.numRows = 1
        Me.pnlFormaPago.Reorder = True
        Me.pnlFormaPago.Size = New System.Drawing.Size(552, 26)
        Me.pnlFormaPago.TabIndex = 0
        '
        'dtfFormaPago
        '
        Me.dtfFormaPago.Allow_Empty = True
        Me.dtfFormaPago.Allow_Negative = True
        Me.dtfFormaPago.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfFormaPago.BackColor = System.Drawing.SystemColors.Control
        Me.dtfFormaPago.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfFormaPago.DataField = "FPAGO_FAC"
        Me.dtfFormaPago.DataTable = "F"
        Me.dtfFormaPago.DB = Connection11
        Me.dtfFormaPago.Desc_Datafield = "NOMBRE"
        Me.dtfFormaPago.Desc_DBPK = "CODIGO"
        Me.dtfFormaPago.Desc_DBTable = "FORMAS"
        Me.dtfFormaPago.Desc_Where = Nothing
        Me.dtfFormaPago.Desc_WhereObligatoria = Nothing
        Me.dtfFormaPago.Descripcion = "Forma Pago"
        Me.dtfFormaPago.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfFormaPago.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfFormaPago.ExtraSQL = ""
        Me.dtfFormaPago.FocoEnAgregar = False
        Me.dtfFormaPago.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfFormaPago.Formulario = Nothing
        Me.dtfFormaPago.Label_Space = 75
        Me.dtfFormaPago.Length_Data = 32767
        Me.dtfFormaPago.Location = New System.Drawing.Point(0, 0)
        Me.dtfFormaPago.Lupa = Nothing
        Me.dtfFormaPago.Max_Value = 0R
        Me.dtfFormaPago.MensajeIncorrectoCustom = Nothing
        Me.dtfFormaPago.Name = "dtfFormaPago"
        Me.dtfFormaPago.Null_on_Empty = True
        Me.dtfFormaPago.OpenForm = Nothing
        Me.dtfFormaPago.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfFormaPago.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfFormaPago.Query_on_Text_Changed = True
        Me.dtfFormaPago.ReadOnly_Data = False
        Me.dtfFormaPago.ReQuery = False
        Me.dtfFormaPago.ShowButton = True
        Me.dtfFormaPago.Size = New System.Drawing.Size(381, 26)
        Me.dtfFormaPago.TabIndex = 0
        Me.dtfFormaPago.Text_Data = ""
        Me.dtfFormaPago.Text_Data_Desc = ""
        Me.dtfFormaPago.Text_Width = 80
        Me.dtfFormaPago.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfFormaPago.TopPadding = 0
        Me.dtfFormaPago.Upper_Case = False
        Me.dtfFormaPago.Validate_on_lost_focus = True
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
        Me.pnlSpace3.Location = New System.Drawing.Point(381, 0)
        Me.pnlSpace3.Name = "pnlSpace3"
        Me.pnlSpace3.numRows = 0
        Me.pnlSpace3.Reorder = False
        Me.pnlSpace3.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace3.TabIndex = 1
        '
        'dtdVencimiento
        '
        Me.dtdVencimiento.Allow_Empty = False
        Me.dtdVencimiento.DataField = "VTO1_FAC"
        Me.dtdVencimiento.DataTable = "F"
        Me.dtdVencimiento.Default_Value = New Date(2015, 6, 12, 0, 0, 0, 0)
        Me.dtdVencimiento.Descripcion = "Vencimiento"
        Me.dtdVencimiento.Dock = System.Windows.Forms.DockStyle.Right
        Me.dtdVencimiento.FocoEnAgregar = False
        Me.dtdVencimiento.Label_Space = 75
        Me.dtdVencimiento.Location = New System.Drawing.Point(387, 0)
        Me.dtdVencimiento.Max_Value = Nothing
        Me.dtdVencimiento.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdVencimiento.MensajeIncorrectoCustom = Nothing
        Me.dtdVencimiento.Min_Value = Nothing
        Me.dtdVencimiento.MinDate = New Date(CType(0, Long))
        Me.dtdVencimiento.MinimumSize = New System.Drawing.Size(165, 26)
        Me.dtdVencimiento.Name = "dtdVencimiento"
        Me.dtdVencimiento.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdVencimiento.ReadOnly_Data = False
        Me.dtdVencimiento.Size = New System.Drawing.Size(165, 26)
        Me.dtdVencimiento.TabIndex = 2
        Me.dtdVencimiento.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdVencimiento.Validate_on_lost_focus = True
        Me.dtdVencimiento.Value_Data = New Date(2015, 6, 12, 0, 0, 0, 0)
        '
        'btnHideCabecera
        '
        Me.btnHideCabecera.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnHideCabecera.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnHideCabecera.Image = Global.Karve.frm.Facturas.My.Resources.Resources.Collapse_Arrow
        Me.btnHideCabecera.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnHideCabecera.Location = New System.Drawing.Point(561, 3)
        Me.btnHideCabecera.Name = "btnHideCabecera"
        Me.btnHideCabecera.Size = New System.Drawing.Size(20, 20)
        Me.btnHideCabecera.TabIndex = 1
        Me.btnHideCabecera.TabStop = False
        Me.btnHideCabecera.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.btnHideCabecera.ThemeName = "Windows8"
        '
        'dtfVendedor
        '
        Me.dtfVendedor.Allow_Empty = True
        Me.dtfVendedor.Allow_Negative = True
        Me.dtfVendedor.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfVendedor.BackColor = System.Drawing.SystemColors.Control
        Me.dtfVendedor.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfVendedor.DataField = "VENDEDOR_FAC"
        Me.dtfVendedor.DataTable = "F"
        Me.dtfVendedor.DB = Connection12
        Me.dtfVendedor.Desc_Datafield = "NOMBRE"
        Me.dtfVendedor.Desc_DBPK = "NUM_VENDE"
        Me.dtfVendedor.Desc_DBTable = "VENDEDOR"
        Me.dtfVendedor.Desc_Where = Nothing
        Me.dtfVendedor.Desc_WhereObligatoria = Nothing
        Me.dtfVendedor.Descripcion = "Vendedor"
        Me.dtfVendedor.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfVendedor.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfVendedor.ExtraSQL = ""
        Me.dtfVendedor.FocoEnAgregar = False
        Me.dtfVendedor.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfVendedor.Formulario = Nothing
        Me.dtfVendedor.Label_Space = 75
        Me.dtfVendedor.Length_Data = 32767
        Me.dtfVendedor.Location = New System.Drawing.Point(3, 81)
        Me.dtfVendedor.Lupa = Nothing
        Me.dtfVendedor.Max_Value = 0R
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
        Me.dtfVendedor.Size = New System.Drawing.Size(552, 26)
        Me.dtfVendedor.TabIndex = 4
        Me.dtfVendedor.Text_Data = ""
        Me.dtfVendedor.Text_Data_Desc = ""
        Me.dtfVendedor.Text_Width = 80
        Me.dtfVendedor.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfVendedor.TopPadding = 0
        Me.dtfVendedor.Upper_Case = False
        Me.dtfVendedor.Validate_on_lost_focus = True
        '
        'dtfPersona
        '
        Me.dtfPersona.Allow_Empty = True
        Me.dtfPersona.Allow_Negative = True
        Me.dtfPersona.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfPersona.BackColor = System.Drawing.SystemColors.Control
        Me.dtfPersona.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfPersona.DataField = "PERSONA_FAC"
        Me.dtfPersona.DataTable = "F"
        Me.dtfPersona.Descripcion = "Persona"
        Me.dtfPersona.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfPersona.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfPersona.FocoEnAgregar = False
        Me.dtfPersona.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfPersona.Image = Nothing
        Me.dtfPersona.Label_Space = 75
        Me.dtfPersona.Length_Data = 32767
        Me.dtfPersona.Location = New System.Drawing.Point(3, 55)
        Me.dtfPersona.Max_Value = 0R
        Me.dtfPersona.MensajeIncorrectoCustom = Nothing
        Me.dtfPersona.Name = "dtfPersona"
        Me.dtfPersona.Null_on_Empty = True
        Me.dtfPersona.OpenForm = Nothing
        Me.dtfPersona.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfPersona.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfPersona.ReadOnly_Data = False
        Me.dtfPersona.Show_Button = False
        Me.dtfPersona.Size = New System.Drawing.Size(552, 26)
        Me.dtfPersona.TabIndex = 3
        Me.dtfPersona.Text_Data = ""
        Me.dtfPersona.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfPersona.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfPersona.TopPadding = 0
        Me.dtfPersona.Upper_Case = False
        Me.dtfPersona.Validate_on_lost_focus = True
        '
        'dtfDelegacion
        '
        Me.dtfDelegacion.Allow_Empty = True
        Me.dtfDelegacion.Allow_Negative = True
        Me.dtfDelegacion.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfDelegacion.BackColor = System.Drawing.SystemColors.Control
        Me.dtfDelegacion.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfDelegacion.DataField = "CLI_DELEGA_FAC"
        Me.dtfDelegacion.DataTable = "F"
        Me.dtfDelegacion.DB = Connection13
        Me.dtfDelegacion.Desc_Datafield = "CLDDELEGACION"
        Me.dtfDelegacion.Desc_DBPK = "CLDIDDELEGA"
        Me.dtfDelegacion.Desc_DBTable = "CLIDELEGA"
        Me.dtfDelegacion.Desc_Where = "1 = 0"
        Me.dtfDelegacion.Desc_WhereObligatoria = Nothing
        Me.dtfDelegacion.Descripcion = "Delegacion"
        Me.dtfDelegacion.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfDelegacion.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfDelegacion.ExtraSQL = ""
        Me.dtfDelegacion.FocoEnAgregar = False
        Me.dtfDelegacion.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfDelegacion.Formulario = Nothing
        Me.dtfDelegacion.Label_Space = 75
        Me.dtfDelegacion.Length_Data = 32767
        Me.dtfDelegacion.Location = New System.Drawing.Point(3, 29)
        Me.dtfDelegacion.Lupa = Nothing
        Me.dtfDelegacion.Max_Value = 0R
        Me.dtfDelegacion.MensajeIncorrectoCustom = Nothing
        Me.dtfDelegacion.Name = "dtfDelegacion"
        Me.dtfDelegacion.Null_on_Empty = True
        Me.dtfDelegacion.OpenForm = Nothing
        Me.dtfDelegacion.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfDelegacion.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfDelegacion.Query_on_Text_Changed = True
        Me.dtfDelegacion.ReadOnly_Data = False
        Me.dtfDelegacion.ReQuery = False
        Me.dtfDelegacion.ShowButton = True
        Me.dtfDelegacion.Size = New System.Drawing.Size(552, 26)
        Me.dtfDelegacion.TabIndex = 2
        Me.dtfDelegacion.Text_Data = ""
        Me.dtfDelegacion.Text_Data_Desc = ""
        Me.dtfDelegacion.Text_Width = 80
        Me.dtfDelegacion.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfDelegacion.TopPadding = 0
        Me.dtfDelegacion.Upper_Case = False
        Me.dtfDelegacion.Validate_on_lost_focus = True
        '
        'dtfCliente
        '
        Me.dtfCliente.Allow_Empty = False
        Me.dtfCliente.Allow_Negative = True
        Me.dtfCliente.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfCliente.BackColor = System.Drawing.SystemColors.Control
        Me.dtfCliente.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfCliente.DataField = "CLIENTE_FAC"
        Me.dtfCliente.DataTable = "F"
        Me.dtfCliente.DB = Connection14
        Me.dtfCliente.Desc_Datafield = "NOMBRE"
        Me.dtfCliente.Desc_DBPK = "NUMERO_CLI"
        Me.dtfCliente.Desc_DBTable = "CLIENTES1"
        Me.dtfCliente.Desc_Where = Nothing
        Me.dtfCliente.Desc_WhereObligatoria = Nothing
        Me.dtfCliente.Descripcion = "Cliente"
        Me.dtfCliente.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfCliente.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfCliente.ExtraSQL = "NIF, DIRECCION, CP, POBLACION, PROVINCIA, NACIODOMI"
        Me.dtfCliente.FocoEnAgregar = False
        Me.dtfCliente.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfCliente.Formulario = Nothing
        Me.dtfCliente.Label_Space = 75
        Me.dtfCliente.Length_Data = 32767
        Me.dtfCliente.Location = New System.Drawing.Point(3, 3)
        Me.dtfCliente.Lupa = Nothing
        Me.dtfCliente.Max_Value = 0R
        Me.dtfCliente.MensajeIncorrectoCustom = "Debe asignar un Cliente válido"
        Me.dtfCliente.Name = "dtfCliente"
        Me.dtfCliente.Null_on_Empty = True
        Me.dtfCliente.OpenForm = Nothing
        Me.dtfCliente.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfCliente.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfCliente.Query_on_Text_Changed = True
        Me.dtfCliente.ReadOnly_Data = False
        Me.dtfCliente.ReQuery = False
        Me.dtfCliente.ShowButton = True
        Me.dtfCliente.Size = New System.Drawing.Size(552, 26)
        Me.dtfCliente.TabIndex = 0
        Me.dtfCliente.Text_Data = ""
        Me.dtfCliente.Text_Data_Desc = ""
        Me.dtfCliente.Text_Width = 80
        Me.dtfCliente.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfCliente.TopPadding = 0
        Me.dtfCliente.Upper_Case = False
        Me.dtfCliente.Validate_on_lost_focus = True
        '
        'pnlCabezeraIzq
        '
        Me.pnlCabezeraIzq.Auto_Size = False
        Me.pnlCabezeraIzq.BackColor = System.Drawing.SystemColors.Control
        Me.pnlCabezeraIzq.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlCabezeraIzq.ChangeDock = True
        Me.pnlCabezeraIzq.Control_Resize = False
        Me.pnlCabezeraIzq.Controls.Add(Me.btnMotivoAbono)
        Me.pnlCabezeraIzq.Controls.Add(Me.pnlRectifica)
        Me.pnlCabezeraIzq.Controls.Add(Me.dtfExtra)
        Me.pnlCabezeraIzq.Controls.Add(Me.dtfTipoImpreso)
        Me.pnlCabezeraIzq.Controls.Add(Me.dtfOrigen)
        Me.pnlCabezeraIzq.Controls.Add(Me.dtfDepartamento)
        Me.pnlCabezeraIzq.Controls.Add(Me.pnlEmpOfi)
        Me.pnlCabezeraIzq.Controls.Add(Me.pnlNumeroFecha)
        Me.pnlCabezeraIzq.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlCabezeraIzq.isSpace = False
        Me.pnlCabezeraIzq.Location = New System.Drawing.Point(0, 0)
        Me.pnlCabezeraIzq.Name = "pnlCabezeraIzq"
        Me.pnlCabezeraIzq.numRows = 0
        Me.pnlCabezeraIzq.Padding = New System.Windows.Forms.Padding(3)
        Me.pnlCabezeraIzq.Reorder = True
        Me.pnlCabezeraIzq.Size = New System.Drawing.Size(358, 182)
        Me.pnlCabezeraIzq.TabIndex = 0
        '
        'btnMotivoAbono
        '
        Me.btnMotivoAbono.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnMotivoAbono.Location = New System.Drawing.Point(278, 159)
        Me.btnMotivoAbono.Name = "btnMotivoAbono"
        Me.btnMotivoAbono.Size = New System.Drawing.Size(77, 20)
        Me.btnMotivoAbono.TabIndex = 7
        Me.btnMotivoAbono.Text = "Motivo"
        Me.btnMotivoAbono.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.btnMotivoAbono.ThemeName = "Windows8"
        Me.btnMotivoAbono.Visible = False
        '
        'pnlRectifica
        '
        Me.pnlRectifica.Auto_Size = False
        Me.pnlRectifica.BackColor = System.Drawing.SystemColors.Control
        Me.pnlRectifica.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlRectifica.ChangeDock = True
        Me.pnlRectifica.Control_Resize = False
        Me.pnlRectifica.Controls.Add(Me.dtfFacRectifPor)
        Me.pnlRectifica.Controls.Add(Me.dtfAbonoDeFac)
        Me.pnlRectifica.isSpace = False
        Me.pnlRectifica.Location = New System.Drawing.Point(3, 159)
        Me.pnlRectifica.Name = "pnlRectifica"
        Me.pnlRectifica.numRows = 2
        Me.pnlRectifica.Reorder = True
        Me.pnlRectifica.Size = New System.Drawing.Size(269, 20)
        Me.pnlRectifica.TabIndex = 6
        '
        'dtfFacRectifPor
        '
        Me.dtfFacRectifPor.Allow_Empty = True
        Me.dtfFacRectifPor.Allow_Negative = True
        Me.dtfFacRectifPor.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfFacRectifPor.BackColor = System.Drawing.SystemColors.Control
        Me.dtfFacRectifPor.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfFacRectifPor.DataField = "FAC_RECTIF_POR"
        Me.dtfFacRectifPor.DataTable = "F"
        Me.dtfFacRectifPor.Descripcion = "Factura Rectificada por"
        Me.dtfFacRectifPor.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfFacRectifPor.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfFacRectifPor.FocoEnAgregar = False
        Me.dtfFacRectifPor.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfFacRectifPor.Image = Nothing
        Me.dtfFacRectifPor.Label_Space = 156
        Me.dtfFacRectifPor.Length_Data = 32767
        Me.dtfFacRectifPor.Location = New System.Drawing.Point(0, 20)
        Me.dtfFacRectifPor.Max_Value = 0R
        Me.dtfFacRectifPor.MensajeIncorrectoCustom = Nothing
        Me.dtfFacRectifPor.Name = "dtfFacRectifPor"
        Me.dtfFacRectifPor.Null_on_Empty = True
        Me.dtfFacRectifPor.OpenForm = Nothing
        Me.dtfFacRectifPor.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfFacRectifPor.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfFacRectifPor.ReadOnly_Data = True
        Me.dtfFacRectifPor.Show_Button = True
        Me.dtfFacRectifPor.Size = New System.Drawing.Size(269, 20)
        Me.dtfFacRectifPor.TabIndex = 1
        Me.dtfFacRectifPor.TabStop = False
        Me.dtfFacRectifPor.Text_Data = ""
        Me.dtfFacRectifPor.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfFacRectifPor.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfFacRectifPor.TopPadding = 0
        Me.dtfFacRectifPor.Upper_Case = False
        Me.dtfFacRectifPor.Validate_on_lost_focus = True
        Me.dtfFacRectifPor.Visible = False
        '
        'dtfAbonoDeFac
        '
        Me.dtfAbonoDeFac.Allow_Empty = True
        Me.dtfAbonoDeFac.Allow_Negative = True
        Me.dtfAbonoDeFac.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfAbonoDeFac.BackColor = System.Drawing.SystemColors.Control
        Me.dtfAbonoDeFac.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfAbonoDeFac.DataField = "ABONODE_FAC"
        Me.dtfAbonoDeFac.DataTable = "F"
        Me.dtfAbonoDeFac.Descripcion = "Factura Rectificativa de"
        Me.dtfAbonoDeFac.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfAbonoDeFac.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfAbonoDeFac.FocoEnAgregar = False
        Me.dtfAbonoDeFac.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfAbonoDeFac.Image = Nothing
        Me.dtfAbonoDeFac.Label_Space = 156
        Me.dtfAbonoDeFac.Length_Data = 32767
        Me.dtfAbonoDeFac.Location = New System.Drawing.Point(0, 0)
        Me.dtfAbonoDeFac.Max_Value = 0R
        Me.dtfAbonoDeFac.MensajeIncorrectoCustom = Nothing
        Me.dtfAbonoDeFac.Name = "dtfAbonoDeFac"
        Me.dtfAbonoDeFac.Null_on_Empty = True
        Me.dtfAbonoDeFac.OpenForm = Nothing
        Me.dtfAbonoDeFac.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfAbonoDeFac.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfAbonoDeFac.ReadOnly_Data = True
        Me.dtfAbonoDeFac.Show_Button = True
        Me.dtfAbonoDeFac.Size = New System.Drawing.Size(269, 20)
        Me.dtfAbonoDeFac.TabIndex = 0
        Me.dtfAbonoDeFac.TabStop = False
        Me.dtfAbonoDeFac.Text_Data = ""
        Me.dtfAbonoDeFac.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfAbonoDeFac.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfAbonoDeFac.TopPadding = 0
        Me.dtfAbonoDeFac.Upper_Case = False
        Me.dtfAbonoDeFac.Validate_on_lost_focus = True
        Me.dtfAbonoDeFac.Visible = False
        '
        'dtfExtra
        '
        Me.dtfExtra.Allow_Empty = True
        Me.dtfExtra.Allow_Negative = True
        Me.dtfExtra.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfExtra.BackColor = System.Drawing.SystemColors.Control
        Me.dtfExtra.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfExtra.DataField = ""
        Me.dtfExtra.DataTable = ""
        Me.dtfExtra.DB = Connection15
        Me.dtfExtra.Desc_Datafield = ""
        Me.dtfExtra.Desc_DBPK = ""
        Me.dtfExtra.Desc_DBTable = ""
        Me.dtfExtra.Desc_Where = Nothing
        Me.dtfExtra.Desc_WhereObligatoria = Nothing
        Me.dtfExtra.Descripcion = "Extra"
        Me.dtfExtra.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfExtra.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfExtra.ExtraSQL = ""
        Me.dtfExtra.FocoEnAgregar = False
        Me.dtfExtra.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfExtra.Formulario = Nothing
        Me.dtfExtra.Label_Space = 100
        Me.dtfExtra.Length_Data = 32767
        Me.dtfExtra.Location = New System.Drawing.Point(3, 133)
        Me.dtfExtra.Lupa = Nothing
        Me.dtfExtra.Max_Value = 0R
        Me.dtfExtra.MensajeIncorrectoCustom = Nothing
        Me.dtfExtra.Name = "dtfExtra"
        Me.dtfExtra.Null_on_Empty = True
        Me.dtfExtra.OpenForm = Nothing
        Me.dtfExtra.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfExtra.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfExtra.Query_on_Text_Changed = True
        Me.dtfExtra.ReadOnly_Data = False
        Me.dtfExtra.ReQuery = False
        Me.dtfExtra.ShowButton = True
        Me.dtfExtra.Size = New System.Drawing.Size(352, 26)
        Me.dtfExtra.TabIndex = 5
        Me.dtfExtra.Text_Data = ""
        Me.dtfExtra.Text_Data_Desc = ""
        Me.dtfExtra.Text_Width = 50
        Me.dtfExtra.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfExtra.TopPadding = 0
        Me.dtfExtra.Upper_Case = False
        Me.dtfExtra.Validate_on_lost_focus = True
        Me.dtfExtra.Visible = False
        '
        'dtfTipoImpreso
        '
        Me.dtfTipoImpreso.Allow_Empty = True
        Me.dtfTipoImpreso.Allow_Negative = True
        Me.dtfTipoImpreso.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfTipoImpreso.BackColor = System.Drawing.SystemColors.Control
        Me.dtfTipoImpreso.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfTipoImpreso.DataField = "FRATIPIMPR"
        Me.dtfTipoImpreso.DataTable = "F"
        Me.dtfTipoImpreso.DB = Connection16
        Me.dtfTipoImpreso.Desc_Datafield = "CODIGO"
        Me.dtfTipoImpreso.Desc_DBPK = "NOMBRE"
        Me.dtfTipoImpreso.Desc_DBTable = "FRATIPIMPR"
        Me.dtfTipoImpreso.Desc_Where = Nothing
        Me.dtfTipoImpreso.Desc_WhereObligatoria = Nothing
        Me.dtfTipoImpreso.Descripcion = "Tipo de Impreso"
        Me.dtfTipoImpreso.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfTipoImpreso.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfTipoImpreso.ExtraSQL = ""
        Me.dtfTipoImpreso.FocoEnAgregar = False
        Me.dtfTipoImpreso.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfTipoImpreso.Formulario = Nothing
        Me.dtfTipoImpreso.Label_Space = 100
        Me.dtfTipoImpreso.Length_Data = 32767
        Me.dtfTipoImpreso.Location = New System.Drawing.Point(3, 107)
        Me.dtfTipoImpreso.Lupa = Nothing
        Me.dtfTipoImpreso.Max_Value = 0R
        Me.dtfTipoImpreso.MensajeIncorrectoCustom = Nothing
        Me.dtfTipoImpreso.Name = "dtfTipoImpreso"
        Me.dtfTipoImpreso.Null_on_Empty = True
        Me.dtfTipoImpreso.OpenForm = Nothing
        Me.dtfTipoImpreso.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfTipoImpreso.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfTipoImpreso.Query_on_Text_Changed = True
        Me.dtfTipoImpreso.ReadOnly_Data = False
        Me.dtfTipoImpreso.ReQuery = False
        Me.dtfTipoImpreso.ShowButton = True
        Me.dtfTipoImpreso.Size = New System.Drawing.Size(352, 26)
        Me.dtfTipoImpreso.TabIndex = 4
        Me.dtfTipoImpreso.Text_Data = ""
        Me.dtfTipoImpreso.Text_Data_Desc = ""
        Me.dtfTipoImpreso.Text_Width = 50
        Me.dtfTipoImpreso.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfTipoImpreso.TopPadding = 0
        Me.dtfTipoImpreso.Upper_Case = False
        Me.dtfTipoImpreso.Validate_on_lost_focus = True
        '
        'dtfOrigen
        '
        Me.dtfOrigen.Allow_Empty = True
        Me.dtfOrigen.Allow_Negative = True
        Me.dtfOrigen.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfOrigen.BackColor = System.Drawing.SystemColors.Control
        Me.dtfOrigen.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfOrigen.DataField = "VIENEDE_FAC"
        Me.dtfOrigen.DataTable = "F"
        Me.dtfOrigen.DB = Connection17
        Me.dtfOrigen.Desc_Datafield = "NOMBRE"
        Me.dtfOrigen.Desc_DBPK = "CODIGO"
        Me.dtfOrigen.Desc_DBTable = "FACVIENEDE"
        Me.dtfOrigen.Desc_Where = Nothing
        Me.dtfOrigen.Desc_WhereObligatoria = Nothing
        Me.dtfOrigen.Descripcion = "Origen"
        Me.dtfOrigen.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfOrigen.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfOrigen.ExtraSQL = ""
        Me.dtfOrigen.FocoEnAgregar = False
        Me.dtfOrigen.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfOrigen.Formulario = Nothing
        Me.dtfOrigen.Label_Space = 100
        Me.dtfOrigen.Length_Data = 32767
        Me.dtfOrigen.Location = New System.Drawing.Point(3, 81)
        Me.dtfOrigen.Lupa = Nothing
        Me.dtfOrigen.Max_Value = 0R
        Me.dtfOrigen.MensajeIncorrectoCustom = Nothing
        Me.dtfOrigen.Name = "dtfOrigen"
        Me.dtfOrigen.Null_on_Empty = True
        Me.dtfOrigen.OpenForm = Nothing
        Me.dtfOrigen.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfOrigen.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfOrigen.Query_on_Text_Changed = True
        Me.dtfOrigen.ReadOnly_Data = False
        Me.dtfOrigen.ReQuery = False
        Me.dtfOrigen.ShowButton = True
        Me.dtfOrigen.Size = New System.Drawing.Size(352, 26)
        Me.dtfOrigen.TabIndex = 3
        Me.dtfOrigen.Text_Data = ""
        Me.dtfOrigen.Text_Data_Desc = ""
        Me.dtfOrigen.Text_Width = 50
        Me.dtfOrigen.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfOrigen.TopPadding = 0
        Me.dtfOrigen.Upper_Case = False
        Me.dtfOrigen.Validate_on_lost_focus = True
        '
        'dtfDepartamento
        '
        Me.dtfDepartamento.Allow_Empty = True
        Me.dtfDepartamento.Allow_Negative = True
        Me.dtfDepartamento.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfDepartamento.BackColor = System.Drawing.SystemColors.Control
        Me.dtfDepartamento.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfDepartamento.DataField = "DPT_FAC"
        Me.dtfDepartamento.DataTable = "F"
        Me.dtfDepartamento.DB = Connection18
        Me.dtfDepartamento.Desc_Datafield = ""
        Me.dtfDepartamento.Desc_DBPK = ""
        Me.dtfDepartamento.Desc_DBTable = ""
        Me.dtfDepartamento.Desc_Where = Nothing
        Me.dtfDepartamento.Desc_WhereObligatoria = Nothing
        Me.dtfDepartamento.Descripcion = "Departamento"
        Me.dtfDepartamento.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfDepartamento.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfDepartamento.ExtraSQL = "SUBLICEN"
        Me.dtfDepartamento.FocoEnAgregar = False
        Me.dtfDepartamento.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfDepartamento.Formulario = Nothing
        Me.dtfDepartamento.Label_Space = 100
        Me.dtfDepartamento.Length_Data = 32767
        Me.dtfDepartamento.Location = New System.Drawing.Point(3, 55)
        Me.dtfDepartamento.Lupa = Nothing
        Me.dtfDepartamento.Max_Value = 0R
        Me.dtfDepartamento.MensajeIncorrectoCustom = Nothing
        Me.dtfDepartamento.Name = "dtfDepartamento"
        Me.dtfDepartamento.Null_on_Empty = True
        Me.dtfDepartamento.OpenForm = Nothing
        Me.dtfDepartamento.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfDepartamento.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfDepartamento.Query_on_Text_Changed = True
        Me.dtfDepartamento.ReadOnly_Data = False
        Me.dtfDepartamento.ReQuery = False
        Me.dtfDepartamento.ShowButton = True
        Me.dtfDepartamento.Size = New System.Drawing.Size(352, 26)
        Me.dtfDepartamento.TabIndex = 2
        Me.dtfDepartamento.Text_Data = ""
        Me.dtfDepartamento.Text_Data_Desc = ""
        Me.dtfDepartamento.Text_Width = 50
        Me.dtfDepartamento.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfDepartamento.TopPadding = 0
        Me.dtfDepartamento.Upper_Case = False
        Me.dtfDepartamento.Validate_on_lost_focus = True
        '
        'pnlEmpOfi
        '
        Me.pnlEmpOfi.Auto_Size = False
        Me.pnlEmpOfi.BackColor = System.Drawing.SystemColors.Control
        Me.pnlEmpOfi.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlEmpOfi.ChangeDock = True
        Me.pnlEmpOfi.Control_Resize = False
        Me.pnlEmpOfi.Controls.Add(Me.dtfOficina)
        Me.pnlEmpOfi.Controls.Add(Me.pnlSpace2)
        Me.pnlEmpOfi.Controls.Add(Me.dtfEmpresa)
        Me.pnlEmpOfi.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEmpOfi.isSpace = False
        Me.pnlEmpOfi.Location = New System.Drawing.Point(3, 29)
        Me.pnlEmpOfi.Name = "pnlEmpOfi"
        Me.pnlEmpOfi.numRows = 1
        Me.pnlEmpOfi.Reorder = True
        Me.pnlEmpOfi.Size = New System.Drawing.Size(352, 26)
        Me.pnlEmpOfi.TabIndex = 1
        '
        'dtfOficina
        '
        Me.dtfOficina.Allow_Empty = True
        Me.dtfOficina.Allow_Negative = True
        Me.dtfOficina.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfOficina.BackColor = System.Drawing.SystemColors.Control
        Me.dtfOficina.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfOficina.DataField = "OFICINA_FAC"
        Me.dtfOficina.DataTable = "F"
        Me.dtfOficina.DB = Connection19
        Me.dtfOficina.Desc_Datafield = "NOMBRE"
        Me.dtfOficina.Desc_DBPK = "CODIGO"
        Me.dtfOficina.Desc_DBTable = "OFICINAS"
        Me.dtfOficina.Desc_Where = Nothing
        Me.dtfOficina.Desc_WhereObligatoria = Nothing
        Me.dtfOficina.Descripcion = "Oficina"
        Me.dtfOficina.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfOficina.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfOficina.ExtraSQL = "SUBLICEN"
        Me.dtfOficina.FocoEnAgregar = False
        Me.dtfOficina.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfOficina.Formulario = Nothing
        Me.dtfOficina.Label_Space = 55
        Me.dtfOficina.Length_Data = 32767
        Me.dtfOficina.Location = New System.Drawing.Point(131, 0)
        Me.dtfOficina.Lupa = Nothing
        Me.dtfOficina.Max_Value = 0R
        Me.dtfOficina.MensajeIncorrectoCustom = Nothing
        Me.dtfOficina.Name = "dtfOficina"
        Me.dtfOficina.Null_on_Empty = True
        Me.dtfOficina.OpenForm = Nothing
        Me.dtfOficina.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfOficina.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfOficina.Query_on_Text_Changed = True
        Me.dtfOficina.ReadOnly_Data = False
        Me.dtfOficina.ReQuery = False
        Me.dtfOficina.ShowButton = True
        Me.dtfOficina.Size = New System.Drawing.Size(221, 26)
        Me.dtfOficina.TabIndex = 2
        Me.dtfOficina.Text_Data = ""
        Me.dtfOficina.Text_Data_Desc = ""
        Me.dtfOficina.Text_Width = 25
        Me.dtfOficina.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfOficina.TopPadding = 0
        Me.dtfOficina.Upper_Case = False
        Me.dtfOficina.Validate_on_lost_focus = True
        '
        'pnlSpace2
        '
        Me.pnlSpace2.Auto_Size = False
        Me.pnlSpace2.BackColor = System.Drawing.SystemColors.Control
        Me.pnlSpace2.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace2.ChangeDock = True
        Me.pnlSpace2.Control_Resize = False
        Me.pnlSpace2.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace2.isSpace = False
        Me.pnlSpace2.Location = New System.Drawing.Point(125, 0)
        Me.pnlSpace2.Name = "pnlSpace2"
        Me.pnlSpace2.numRows = 0
        Me.pnlSpace2.Reorder = False
        Me.pnlSpace2.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace2.TabIndex = 1
        '
        'dtfEmpresa
        '
        Me.dtfEmpresa.Allow_Empty = True
        Me.dtfEmpresa.Allow_Negative = True
        Me.dtfEmpresa.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfEmpresa.BackColor = System.Drawing.SystemColors.Control
        Me.dtfEmpresa.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfEmpresa.DataField = "SUBLICEN_FAC"
        Me.dtfEmpresa.DataTable = "F"
        Me.dtfEmpresa.DB = Connection20
        Me.dtfEmpresa.Desc_Datafield = "NOMBRE"
        Me.dtfEmpresa.Desc_DBPK = "CODIGO"
        Me.dtfEmpresa.Desc_DBTable = "SUBLICEN"
        Me.dtfEmpresa.Desc_Where = Nothing
        Me.dtfEmpresa.Desc_WhereObligatoria = Nothing
        Me.dtfEmpresa.Descripcion = "Empresa"
        Me.dtfEmpresa.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfEmpresa.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfEmpresa.ExtraSQL = ""
        Me.dtfEmpresa.FocoEnAgregar = False
        Me.dtfEmpresa.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfEmpresa.Formulario = Nothing
        Me.dtfEmpresa.Label_Space = 100
        Me.dtfEmpresa.Length_Data = 32767
        Me.dtfEmpresa.Location = New System.Drawing.Point(0, 0)
        Me.dtfEmpresa.Lupa = Nothing
        Me.dtfEmpresa.Max_Value = 0R
        Me.dtfEmpresa.MensajeIncorrectoCustom = Nothing
        Me.dtfEmpresa.Name = "dtfEmpresa"
        Me.dtfEmpresa.Null_on_Empty = True
        Me.dtfEmpresa.OpenForm = Nothing
        Me.dtfEmpresa.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfEmpresa.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfEmpresa.Query_on_Text_Changed = True
        Me.dtfEmpresa.ReadOnly_Data = True
        Me.dtfEmpresa.ReQuery = False
        Me.dtfEmpresa.ShowButton = False
        Me.dtfEmpresa.Size = New System.Drawing.Size(125, 26)
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
        'pnlNumeroFecha
        '
        Me.pnlNumeroFecha.Auto_Size = False
        Me.pnlNumeroFecha.BackColor = System.Drawing.SystemColors.Control
        Me.pnlNumeroFecha.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlNumeroFecha.ChangeDock = True
        Me.pnlNumeroFecha.Control_Resize = False
        Me.pnlNumeroFecha.Controls.Add(Me.dtdFefchaFac)
        Me.pnlNumeroFecha.Controls.Add(Me.pnlSpace1)
        Me.pnlNumeroFecha.Controls.Add(Me.dtfNumero)
        Me.pnlNumeroFecha.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlNumeroFecha.isSpace = False
        Me.pnlNumeroFecha.Location = New System.Drawing.Point(3, 3)
        Me.pnlNumeroFecha.Name = "pnlNumeroFecha"
        Me.pnlNumeroFecha.numRows = 1
        Me.pnlNumeroFecha.Reorder = True
        Me.pnlNumeroFecha.Size = New System.Drawing.Size(352, 26)
        Me.pnlNumeroFecha.TabIndex = 0
        '
        'dtdFefchaFac
        '
        Me.dtdFefchaFac.Allow_Empty = False
        Me.dtdFefchaFac.DataField = "FECHA_FAC"
        Me.dtdFefchaFac.DataTable = "F"
        Me.dtdFefchaFac.Default_Value = New Date(2015, 6, 12, 0, 0, 0, 0)
        Me.dtdFefchaFac.Descripcion = "Fecha"
        Me.dtdFefchaFac.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtdFefchaFac.FocoEnAgregar = False
        Me.dtdFefchaFac.Label_Space = 50
        Me.dtdFefchaFac.Location = New System.Drawing.Point(212, 0)
        Me.dtdFefchaFac.Max_Value = Nothing
        Me.dtdFefchaFac.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdFefchaFac.MensajeIncorrectoCustom = Nothing
        Me.dtdFefchaFac.Min_Value = Nothing
        Me.dtdFefchaFac.MinDate = New Date(CType(0, Long))
        Me.dtdFefchaFac.MinimumSize = New System.Drawing.Size(140, 26)
        Me.dtdFefchaFac.Name = "dtdFefchaFac"
        Me.dtdFefchaFac.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdFefchaFac.ReadOnly_Data = False
        Me.dtdFefchaFac.Size = New System.Drawing.Size(140, 26)
        Me.dtdFefchaFac.TabIndex = 2
        Me.dtdFefchaFac.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdFefchaFac.Validate_on_lost_focus = True
        Me.dtdFefchaFac.Value_Data = New Date(2015, 6, 12, 0, 0, 0, 0)
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
        Me.pnlSpace1.Location = New System.Drawing.Point(206, 0)
        Me.pnlSpace1.Name = "pnlSpace1"
        Me.pnlSpace1.numRows = 0
        Me.pnlSpace1.Reorder = False
        Me.pnlSpace1.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace1.TabIndex = 1
        '
        'dtfNumero
        '
        Me.dtfNumero.Allow_Empty = False
        Me.dtfNumero.Allow_Negative = True
        Me.dtfNumero.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfNumero.BackColor = System.Drawing.SystemColors.Control
        Me.dtfNumero.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfNumero.DataField = "NUMERO_FAC"
        Me.dtfNumero.DataTable = "F"
        Me.dtfNumero.Descripcion = "Numero Factura"
        Me.dtfNumero.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfNumero.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfNumero.FocoEnAgregar = False
        Me.dtfNumero.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfNumero.Image = Nothing
        Me.dtfNumero.Label_Space = 100
        Me.dtfNumero.Length_Data = 32767
        Me.dtfNumero.Location = New System.Drawing.Point(0, 0)
        Me.dtfNumero.Max_Value = 0R
        Me.dtfNumero.MensajeIncorrectoCustom = Nothing
        Me.dtfNumero.Name = "dtfNumero"
        Me.dtfNumero.Null_on_Empty = True
        Me.dtfNumero.OpenForm = Nothing
        Me.dtfNumero.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfNumero.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfNumero.ReadOnly_Data = True
        Me.dtfNumero.Show_Button = False
        Me.dtfNumero.Size = New System.Drawing.Size(206, 26)
        Me.dtfNumero.TabIndex = 0
        Me.dtfNumero.TabStop = False
        Me.dtfNumero.Text_Data = ""
        Me.dtfNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfNumero.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfNumero.TopPadding = 0
        Me.dtfNumero.Upper_Case = False
        Me.dtfNumero.Validate_on_lost_focus = True
        '
        'pnlPie
        '
        Me.pnlPie.Auto_Size = False
        Me.pnlPie.BackColor = System.Drawing.SystemColors.Control
        Me.pnlPie.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlPie.ChangeDock = False
        Me.pnlPie.Control_Resize = False
        Me.pnlPie.Controls.Add(Me.dgvBases)
        Me.pnlPie.Controls.Add(Me.pnlTotales)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.isSpace = False
        Me.pnlPie.Location = New System.Drawing.Point(0, 314)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.numRows = 5
        Me.pnlPie.Reorder = True
        Me.pnlPie.Size = New System.Drawing.Size(939, 130)
        Me.pnlPie.TabIndex = 5
        '
        'dgvBases
        '
        Me.dgvBases.ColRel = Nothing
        Me.dgvBases.ColSelectFilter = Nothing
        Me.dgvBases.DataGridType = CustomControls.DataGrid.GridType.Edit
        Me.dgvBases.DBConnection = Nothing
        Me.dgvBases.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvBases.EnforceConstrains = True
        Me.dgvBases.idRel = Nothing
        Me.dgvBases.Location = New System.Drawing.Point(0, 0)
        Me.dgvBases.MarcarFilas = False
        '
        'dgvBases
        '
        Me.dgvBases.MasterTemplate.AddNewRowPosition = Telerik.WinControls.UI.SystemRowPosition.Bottom
        Me.dgvBases.MasterTemplate.AllowColumnChooser = False
        Me.dgvBases.MasterTemplate.EnableFiltering = True
        Me.dgvBases.MasterTemplate.EnableGrouping = False
        Me.dgvBases.MasterTemplate.MultiSelect = True
        Me.dgvBases.MasterTemplate.SelectionMode = Telerik.WinControls.UI.GridViewSelectionMode.CellSelect
        Me.dgvBases.Name = "dgvBases"
        Me.dgvBases.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.dgvBases.Size = New System.Drawing.Size(673, 130)
        Me.dgvBases.TabIndex = 0
        Me.dgvBases.TablaEdit = Nothing
        Me.dgvBases.Text = "DataGrid2"
        Me.dgvBases.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dgvBases.ThemeName = "TelerikMetroBlue"
        '
        'pnlTotales
        '
        Me.pnlTotales.Auto_Size = False
        Me.pnlTotales.BackColor = System.Drawing.SystemColors.Control
        Me.pnlTotales.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlTotales.ChangeDock = True
        Me.pnlTotales.Control_Resize = False
        Me.pnlTotales.Controls.Add(Me.btnHidePie)
        Me.pnlTotales.Controls.Add(Me.dtfTotalFac)
        Me.pnlTotales.Controls.Add(Me.pnlDtoPie)
        Me.pnlTotales.Controls.Add(Me.pnlDtoPP)
        Me.pnlTotales.Controls.Add(Me.dtfBaseSin)
        Me.pnlTotales.Controls.Add(Me.dtfBrutoFac)
        Me.pnlTotales.Controls.Add(Me.pnlDivisa)
        Me.pnlTotales.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTotales.isSpace = False
        Me.pnlTotales.Location = New System.Drawing.Point(673, 0)
        Me.pnlTotales.Name = "pnlTotales"
        Me.pnlTotales.numRows = 0
        Me.pnlTotales.Padding = New System.Windows.Forms.Padding(6, 3, 26, 3)
        Me.pnlTotales.Reorder = True
        Me.pnlTotales.Size = New System.Drawing.Size(266, 130)
        Me.pnlTotales.TabIndex = 1
        '
        'btnHidePie
        '
        Me.btnHidePie.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnHidePie.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnHidePie.Image = Global.Karve.frm.Facturas.My.Resources.Resources.Expand_Arrow
        Me.btnHidePie.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnHidePie.Location = New System.Drawing.Point(246, 107)
        Me.btnHidePie.Name = "btnHidePie"
        Me.btnHidePie.Size = New System.Drawing.Size(20, 20)
        Me.btnHidePie.TabIndex = 6
        Me.btnHidePie.TabStop = False
        Me.btnHidePie.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.btnHidePie.ThemeName = "Windows8"
        '
        'dtfTotalFac
        '
        Me.dtfTotalFac.Allow_Empty = True
        Me.dtfTotalFac.Allow_Negative = True
        Me.dtfTotalFac.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfTotalFac.BackColor = System.Drawing.SystemColors.Control
        Me.dtfTotalFac.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfTotalFac.DataField = "TODO_FAC"
        Me.dtfTotalFac.DataTable = "F"
        Me.dtfTotalFac.Descripcion = "Total Factura"
        Me.dtfTotalFac.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfTotalFac.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfTotalFac.FocoEnAgregar = False
        Me.dtfTotalFac.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfTotalFac.Image = Nothing
        Me.dtfTotalFac.Label_Space = 109
        Me.dtfTotalFac.Length_Data = 32767
        Me.dtfTotalFac.Location = New System.Drawing.Point(6, 107)
        Me.dtfTotalFac.Max_Value = 0R
        Me.dtfTotalFac.MensajeIncorrectoCustom = Nothing
        Me.dtfTotalFac.Name = "dtfTotalFac"
        Me.dtfTotalFac.Null_on_Empty = True
        Me.dtfTotalFac.OpenForm = Nothing
        Me.dtfTotalFac.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfTotalFac.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfTotalFac.ReadOnly_Data = True
        Me.dtfTotalFac.Show_Button = False
        Me.dtfTotalFac.Size = New System.Drawing.Size(222, 26)
        Me.dtfTotalFac.TabIndex = 5
        Me.dtfTotalFac.TabStop = False
        Me.dtfTotalFac.Text_Data = ""
        Me.dtfTotalFac.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfTotalFac.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfTotalFac.TopPadding = 0
        Me.dtfTotalFac.Upper_Case = False
        Me.dtfTotalFac.Validate_on_lost_focus = True
        '
        'pnlDtoPie
        '
        Me.pnlDtoPie.Auto_Size = False
        Me.pnlDtoPie.BackColor = System.Drawing.SystemColors.Control
        Me.pnlDtoPie.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlDtoPie.ChangeDock = True
        Me.pnlDtoPie.Control_Resize = False
        Me.pnlDtoPie.Controls.Add(Me.dtfImpDtoPie)
        Me.pnlDtoPie.Controls.Add(Me.pnlSpace7)
        Me.pnlDtoPie.Controls.Add(Me.lblPorcen2)
        Me.pnlDtoPie.Controls.Add(Me.dtfDtoPie)
        Me.pnlDtoPie.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlDtoPie.isSpace = False
        Me.pnlDtoPie.Location = New System.Drawing.Point(6, 81)
        Me.pnlDtoPie.Name = "pnlDtoPie"
        Me.pnlDtoPie.numRows = 1
        Me.pnlDtoPie.Reorder = True
        Me.pnlDtoPie.Size = New System.Drawing.Size(222, 26)
        Me.pnlDtoPie.TabIndex = 4
        '
        'dtfImpDtoPie
        '
        Me.dtfImpDtoPie.Allow_Empty = True
        Me.dtfImpDtoPie.Allow_Negative = True
        Me.dtfImpDtoPie.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfImpDtoPie.BackColor = System.Drawing.SystemColors.Control
        Me.dtfImpDtoPie.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfImpDtoPie.DataField = Nothing
        Me.dtfImpDtoPie.DataTable = ""
        Me.dtfImpDtoPie.Descripcion = Nothing
        Me.dtfImpDtoPie.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtfImpDtoPie.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfImpDtoPie.FocoEnAgregar = False
        Me.dtfImpDtoPie.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfImpDtoPie.Length_Data = 32767
        Me.dtfImpDtoPie.Location = New System.Drawing.Point(109, 0)
        Me.dtfImpDtoPie.Max_Value = 0R
        Me.dtfImpDtoPie.MensajeIncorrectoCustom = Nothing
        Me.dtfImpDtoPie.Name = "dtfImpDtoPie"
        Me.dtfImpDtoPie.Null_on_Empty = True
        Me.dtfImpDtoPie.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfImpDtoPie.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfImpDtoPie.ReadOnly_Data = True
        Me.dtfImpDtoPie.Size = New System.Drawing.Size(113, 26)
        Me.dtfImpDtoPie.TabIndex = 3
        Me.dtfImpDtoPie.TabStop = False
        Me.dtfImpDtoPie.Text_Data = ""
        Me.dtfImpDtoPie.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfImpDtoPie.TopPadding = 0
        Me.dtfImpDtoPie.Upper_Case = False
        Me.dtfImpDtoPie.Validate_on_lost_focus = True
        '
        'pnlSpace7
        '
        Me.pnlSpace7.Auto_Size = False
        Me.pnlSpace7.BackColor = System.Drawing.SystemColors.Control
        Me.pnlSpace7.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace7.ChangeDock = True
        Me.pnlSpace7.Control_Resize = False
        Me.pnlSpace7.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace7.isSpace = True
        Me.pnlSpace7.Location = New System.Drawing.Point(103, 0)
        Me.pnlSpace7.Name = "pnlSpace7"
        Me.pnlSpace7.numRows = 0
        Me.pnlSpace7.Reorder = True
        Me.pnlSpace7.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace7.TabIndex = 2
        '
        'lblPorcen2
        '
        Me.lblPorcen2.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblPorcen2.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblPorcen2.Location = New System.Drawing.Point(85, 0)
        Me.lblPorcen2.Name = "lblPorcen2"
        Me.lblPorcen2.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.lblPorcen2.Size = New System.Drawing.Size(18, 26)
        Me.lblPorcen2.TabIndex = 1
        Me.lblPorcen2.Text = "%"
        '
        'dtfDtoPie
        '
        Me.dtfDtoPie.Allow_Empty = True
        Me.dtfDtoPie.Allow_Negative = False
        Me.dtfDtoPie.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfDtoPie.BackColor = System.Drawing.SystemColors.Control
        Me.dtfDtoPie.Data_Allowed = CustomControls.Datafield.List_Data.nDouble
        Me.dtfDtoPie.DataField = "DTOPIE_FAC"
        Me.dtfDtoPie.DataTable = "F"
        Me.dtfDtoPie.Descripcion = "Dto Pie"
        Me.dtfDtoPie.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfDtoPie.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfDtoPie.FocoEnAgregar = False
        Me.dtfDtoPie.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfDtoPie.Image = Nothing
        Me.dtfDtoPie.Label_Space = 45
        Me.dtfDtoPie.Length_Data = 32767
        Me.dtfDtoPie.Location = New System.Drawing.Point(0, 0)
        Me.dtfDtoPie.Max_Value = 100.0R
        Me.dtfDtoPie.MensajeIncorrectoCustom = Nothing
        Me.dtfDtoPie.Name = "dtfDtoPie"
        Me.dtfDtoPie.Null_on_Empty = True
        Me.dtfDtoPie.OpenForm = Nothing
        Me.dtfDtoPie.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfDtoPie.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfDtoPie.ReadOnly_Data = False
        Me.dtfDtoPie.Show_Button = False
        Me.dtfDtoPie.Size = New System.Drawing.Size(85, 26)
        Me.dtfDtoPie.TabIndex = 0
        Me.dtfDtoPie.Text_Data = ""
        Me.dtfDtoPie.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.dtfDtoPie.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfDtoPie.TopPadding = 0
        Me.dtfDtoPie.Upper_Case = False
        Me.dtfDtoPie.Validate_on_lost_focus = True
        '
        'pnlDtoPP
        '
        Me.pnlDtoPP.Auto_Size = False
        Me.pnlDtoPP.BackColor = System.Drawing.SystemColors.Control
        Me.pnlDtoPP.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlDtoPP.ChangeDock = True
        Me.pnlDtoPP.Control_Resize = False
        Me.pnlDtoPP.Controls.Add(Me.dtfImpDtoPP)
        Me.pnlDtoPP.Controls.Add(Me.pnlSpace6)
        Me.pnlDtoPP.Controls.Add(Me.lblPorcen1)
        Me.pnlDtoPP.Controls.Add(Me.dtfDtoPP)
        Me.pnlDtoPP.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlDtoPP.isSpace = False
        Me.pnlDtoPP.Location = New System.Drawing.Point(6, 55)
        Me.pnlDtoPP.Name = "pnlDtoPP"
        Me.pnlDtoPP.numRows = 1
        Me.pnlDtoPP.Reorder = True
        Me.pnlDtoPP.Size = New System.Drawing.Size(222, 26)
        Me.pnlDtoPP.TabIndex = 3
        '
        'dtfImpDtoPP
        '
        Me.dtfImpDtoPP.Allow_Empty = True
        Me.dtfImpDtoPP.Allow_Negative = True
        Me.dtfImpDtoPP.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfImpDtoPP.BackColor = System.Drawing.SystemColors.Control
        Me.dtfImpDtoPP.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfImpDtoPP.DataField = Nothing
        Me.dtfImpDtoPP.DataTable = ""
        Me.dtfImpDtoPP.Descripcion = Nothing
        Me.dtfImpDtoPP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtfImpDtoPP.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfImpDtoPP.FocoEnAgregar = False
        Me.dtfImpDtoPP.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfImpDtoPP.Length_Data = 32767
        Me.dtfImpDtoPP.Location = New System.Drawing.Point(109, 0)
        Me.dtfImpDtoPP.Max_Value = 0R
        Me.dtfImpDtoPP.MensajeIncorrectoCustom = Nothing
        Me.dtfImpDtoPP.Name = "dtfImpDtoPP"
        Me.dtfImpDtoPP.Null_on_Empty = True
        Me.dtfImpDtoPP.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfImpDtoPP.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfImpDtoPP.ReadOnly_Data = True
        Me.dtfImpDtoPP.Size = New System.Drawing.Size(113, 26)
        Me.dtfImpDtoPP.TabIndex = 3
        Me.dtfImpDtoPP.TabStop = False
        Me.dtfImpDtoPP.Text_Data = ""
        Me.dtfImpDtoPP.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfImpDtoPP.TopPadding = 0
        Me.dtfImpDtoPP.Upper_Case = False
        Me.dtfImpDtoPP.Validate_on_lost_focus = True
        '
        'pnlSpace6
        '
        Me.pnlSpace6.Auto_Size = False
        Me.pnlSpace6.BackColor = System.Drawing.SystemColors.Control
        Me.pnlSpace6.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace6.ChangeDock = True
        Me.pnlSpace6.Control_Resize = False
        Me.pnlSpace6.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace6.isSpace = True
        Me.pnlSpace6.Location = New System.Drawing.Point(103, 0)
        Me.pnlSpace6.Name = "pnlSpace6"
        Me.pnlSpace6.numRows = 0
        Me.pnlSpace6.Reorder = True
        Me.pnlSpace6.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace6.TabIndex = 2
        '
        'lblPorcen1
        '
        Me.lblPorcen1.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblPorcen1.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblPorcen1.Location = New System.Drawing.Point(85, 0)
        Me.lblPorcen1.Name = "lblPorcen1"
        Me.lblPorcen1.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.lblPorcen1.Size = New System.Drawing.Size(18, 26)
        Me.lblPorcen1.TabIndex = 1
        Me.lblPorcen1.Text = "%"
        '
        'dtfDtoPP
        '
        Me.dtfDtoPP.Allow_Empty = True
        Me.dtfDtoPP.Allow_Negative = False
        Me.dtfDtoPP.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfDtoPP.BackColor = System.Drawing.SystemColors.Control
        Me.dtfDtoPP.Data_Allowed = CustomControls.Datafield.List_Data.nDouble
        Me.dtfDtoPP.DataField = "DTOPP"
        Me.dtfDtoPP.DataTable = "F"
        Me.dtfDtoPP.Descripcion = "Dto PP"
        Me.dtfDtoPP.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfDtoPP.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfDtoPP.FocoEnAgregar = False
        Me.dtfDtoPP.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfDtoPP.Image = Nothing
        Me.dtfDtoPP.Label_Space = 45
        Me.dtfDtoPP.Length_Data = 32767
        Me.dtfDtoPP.Location = New System.Drawing.Point(0, 0)
        Me.dtfDtoPP.Max_Value = 100.0R
        Me.dtfDtoPP.MensajeIncorrectoCustom = Nothing
        Me.dtfDtoPP.Name = "dtfDtoPP"
        Me.dtfDtoPP.Null_on_Empty = True
        Me.dtfDtoPP.OpenForm = Nothing
        Me.dtfDtoPP.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfDtoPP.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfDtoPP.ReadOnly_Data = False
        Me.dtfDtoPP.Show_Button = False
        Me.dtfDtoPP.Size = New System.Drawing.Size(85, 26)
        Me.dtfDtoPP.TabIndex = 0
        Me.dtfDtoPP.Text_Data = ""
        Me.dtfDtoPP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.dtfDtoPP.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfDtoPP.TopPadding = 0
        Me.dtfDtoPP.Upper_Case = False
        Me.dtfDtoPP.Validate_on_lost_focus = True
        '
        'dtfBaseSin
        '
        Me.dtfBaseSin.Allow_Empty = True
        Me.dtfBaseSin.Allow_Negative = True
        Me.dtfBaseSin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfBaseSin.BackColor = System.Drawing.SystemColors.Control
        Me.dtfBaseSin.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfBaseSin.DataField = "BASESIN"
        Me.dtfBaseSin.DataTable = "F"
        Me.dtfBaseSin.Descripcion = "Base exenta IVA"
        Me.dtfBaseSin.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfBaseSin.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfBaseSin.FocoEnAgregar = False
        Me.dtfBaseSin.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfBaseSin.Image = Nothing
        Me.dtfBaseSin.Label_Space = 109
        Me.dtfBaseSin.Length_Data = 32767
        Me.dtfBaseSin.Location = New System.Drawing.Point(6, 29)
        Me.dtfBaseSin.Max_Value = 0R
        Me.dtfBaseSin.MensajeIncorrectoCustom = Nothing
        Me.dtfBaseSin.Name = "dtfBaseSin"
        Me.dtfBaseSin.Null_on_Empty = True
        Me.dtfBaseSin.OpenForm = Nothing
        Me.dtfBaseSin.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfBaseSin.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfBaseSin.ReadOnly_Data = True
        Me.dtfBaseSin.Show_Button = False
        Me.dtfBaseSin.Size = New System.Drawing.Size(222, 26)
        Me.dtfBaseSin.TabIndex = 2
        Me.dtfBaseSin.TabStop = False
        Me.dtfBaseSin.Text_Data = ""
        Me.dtfBaseSin.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfBaseSin.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfBaseSin.TopPadding = 0
        Me.dtfBaseSin.Upper_Case = False
        Me.dtfBaseSin.Validate_on_lost_focus = True
        '
        'dtfBrutoFac
        '
        Me.dtfBrutoFac.Allow_Empty = True
        Me.dtfBrutoFac.Allow_Negative = True
        Me.dtfBrutoFac.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfBrutoFac.BackColor = System.Drawing.SystemColors.Control
        Me.dtfBrutoFac.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfBrutoFac.DataField = "BRUTO_FAC"
        Me.dtfBrutoFac.DataTable = "F"
        Me.dtfBrutoFac.Descripcion = "Bruto Factura"
        Me.dtfBrutoFac.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfBrutoFac.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfBrutoFac.FocoEnAgregar = False
        Me.dtfBrutoFac.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfBrutoFac.Image = Nothing
        Me.dtfBrutoFac.Label_Space = 109
        Me.dtfBrutoFac.Length_Data = 32767
        Me.dtfBrutoFac.Location = New System.Drawing.Point(6, 3)
        Me.dtfBrutoFac.Max_Value = 0R
        Me.dtfBrutoFac.MensajeIncorrectoCustom = Nothing
        Me.dtfBrutoFac.Name = "dtfBrutoFac"
        Me.dtfBrutoFac.Null_on_Empty = True
        Me.dtfBrutoFac.OpenForm = Nothing
        Me.dtfBrutoFac.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfBrutoFac.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfBrutoFac.ReadOnly_Data = True
        Me.dtfBrutoFac.Show_Button = False
        Me.dtfBrutoFac.Size = New System.Drawing.Size(222, 26)
        Me.dtfBrutoFac.TabIndex = 0
        Me.dtfBrutoFac.TabStop = False
        Me.dtfBrutoFac.Text_Data = ""
        Me.dtfBrutoFac.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfBrutoFac.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfBrutoFac.TopPadding = 0
        Me.dtfBrutoFac.Upper_Case = False
        Me.dtfBrutoFac.Validate_on_lost_focus = True
        '
        'pnlDivisa
        '
        Me.pnlDivisa.Auto_Size = False
        Me.pnlDivisa.BackColor = System.Drawing.SystemColors.Control
        Me.pnlDivisa.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlDivisa.ChangeDock = True
        Me.pnlDivisa.Control_Resize = False
        Me.pnlDivisa.Controls.Add(Me.lblDivisa5)
        Me.pnlDivisa.Controls.Add(Me.lblDivisa4)
        Me.pnlDivisa.Controls.Add(Me.lblDivisa3)
        Me.pnlDivisa.Controls.Add(Me.lblDivisa2)
        Me.pnlDivisa.Controls.Add(Me.lblDivisa1)
        Me.pnlDivisa.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDivisa.isSpace = False
        Me.pnlDivisa.Location = New System.Drawing.Point(228, 3)
        Me.pnlDivisa.Name = "pnlDivisa"
        Me.pnlDivisa.numRows = 0
        Me.pnlDivisa.Reorder = True
        Me.pnlDivisa.Size = New System.Drawing.Size(12, 124)
        Me.pnlDivisa.TabIndex = 1
        '
        'lblDivisa5
        '
        Me.lblDivisa5.AutoSize = False
        Me.lblDivisa5.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblDivisa5.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblDivisa5.Location = New System.Drawing.Point(0, 104)
        Me.lblDivisa5.Name = "lblDivisa5"
        Me.lblDivisa5.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.lblDivisa5.Size = New System.Drawing.Size(12, 26)
        Me.lblDivisa5.TabIndex = 4
        Me.lblDivisa5.Text = "€"
        '
        'lblDivisa4
        '
        Me.lblDivisa4.AutoSize = False
        Me.lblDivisa4.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblDivisa4.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblDivisa4.Location = New System.Drawing.Point(0, 78)
        Me.lblDivisa4.Name = "lblDivisa4"
        Me.lblDivisa4.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.lblDivisa4.Size = New System.Drawing.Size(12, 26)
        Me.lblDivisa4.TabIndex = 3
        Me.lblDivisa4.Text = "€"
        '
        'lblDivisa3
        '
        Me.lblDivisa3.AutoSize = False
        Me.lblDivisa3.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblDivisa3.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblDivisa3.Location = New System.Drawing.Point(0, 52)
        Me.lblDivisa3.Name = "lblDivisa3"
        Me.lblDivisa3.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.lblDivisa3.Size = New System.Drawing.Size(12, 26)
        Me.lblDivisa3.TabIndex = 2
        Me.lblDivisa3.Text = "€"
        '
        'lblDivisa2
        '
        Me.lblDivisa2.AutoSize = False
        Me.lblDivisa2.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblDivisa2.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblDivisa2.Location = New System.Drawing.Point(0, 26)
        Me.lblDivisa2.Name = "lblDivisa2"
        Me.lblDivisa2.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.lblDivisa2.Size = New System.Drawing.Size(12, 26)
        Me.lblDivisa2.TabIndex = 1
        Me.lblDivisa2.Text = "€"
        '
        'lblDivisa1
        '
        Me.lblDivisa1.AutoSize = False
        Me.lblDivisa1.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblDivisa1.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblDivisa1.Location = New System.Drawing.Point(0, 0)
        Me.lblDivisa1.Name = "lblDivisa1"
        Me.lblDivisa1.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.lblDivisa1.Size = New System.Drawing.Size(12, 26)
        Me.lblDivisa1.TabIndex = 0
        Me.lblDivisa1.Text = "€"
        '
        'pvpOtrosDatos
        '
        Me.pvpOtrosDatos.Controls.Add(Me.pnlOtrosDatos)
        Me.pvpOtrosDatos.ItemSize = New System.Drawing.SizeF(106.0!, 23.0!)
        Me.pvpOtrosDatos.Location = New System.Drawing.Point(129, 5)
        Me.pvpOtrosDatos.Name = "pvpOtrosDatos"
        Me.pvpOtrosDatos.PanelCabezeraContainer = Nothing
        Me.pvpOtrosDatos.Size = New System.Drawing.Size(939, 444)
        Me.pvpOtrosDatos.Text = "Otros Datos"
        '
        'pnlOtrosDatos
        '
        Me.pnlOtrosDatos.Auto_Size = False
        Me.pnlOtrosDatos.AutoScroll = True
        Me.pnlOtrosDatos.BackColor = System.Drawing.SystemColors.Control
        Me.pnlOtrosDatos.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlOtrosDatos.ChangeDock = False
        Me.pnlOtrosDatos.Control_Resize = False
        Me.pnlOtrosDatos.Controls.Add(Me.gbxCliFac)
        Me.pnlOtrosDatos.Controls.Add(Me.pnlOtrosIzq)
        Me.pnlOtrosDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlOtrosDatos.isSpace = False
        Me.pnlOtrosDatos.Location = New System.Drawing.Point(0, 0)
        Me.pnlOtrosDatos.Name = "pnlOtrosDatos"
        Me.pnlOtrosDatos.numRows = 0
        Me.pnlOtrosDatos.Padding = New System.Windows.Forms.Padding(3)
        Me.pnlOtrosDatos.Reorder = True
        Me.pnlOtrosDatos.Size = New System.Drawing.Size(939, 444)
        Me.pnlOtrosDatos.TabIndex = 0
        '
        'gbxCliFac
        '
        Me.gbxCliFac.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.gbxCliFac.Controls.Add(Me.dirCliFac)
        Me.gbxCliFac.Controls.Add(Me.pnlNomNifCliFac)
        Me.gbxCliFac.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbxCliFac.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.gbxCliFac.HeaderText = "Cliente en Factura"
        Me.gbxCliFac.Location = New System.Drawing.Point(394, 3)
        Me.gbxCliFac.Name = "gbxCliFac"
        Me.gbxCliFac.numRows = 5
        Me.gbxCliFac.Padding = New System.Windows.Forms.Padding(6, 18, 6, 6)
        Me.gbxCliFac.Reorder = True
        Me.gbxCliFac.Size = New System.Drawing.Size(542, 150)
        Me.gbxCliFac.TabIndex = 1
        Me.gbxCliFac.Text = "Cliente en Factura"
        Me.gbxCliFac.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.gbxCliFac.ThemeName = "Windows8"
        Me.gbxCliFac.Title = "Cliente en Factura"
        '
        'dirCliFac
        '
        Me.dirCliFac.AutoSize = True
        Me.dirCliFac.Datafield_CP = "CP_CLI"
        Me.dirCliFac.Datafield_Direccion = "DIR_CLI"
        Me.dirCliFac.Datafield_Direccion2L = Nothing
        Me.dirCliFac.Datafield_GPS = Nothing
        Me.dirCliFac.Datafield_Pais = "PAIS_CLI"
        Me.dirCliFac.Datafield_Poblacion = "POB_CLI"
        Me.dirCliFac.Datafield_Provincia = "PRO_CLI"
        Me.dirCliFac.Datatable_CP = "F"
        Me.dirCliFac.Datatable_Direccion = "F"
        Me.dirCliFac.Datatable_Direccion2L = ""
        Me.dirCliFac.Datatable_GPS = "0"
        Me.dirCliFac.Datatable_Pais = "F"
        Me.dirCliFac.Datatable_Poblacion = "F"
        Me.dirCliFac.Datatable_Provincia = "F"
        Me.dirCliFac.Descripcion = Nothing
        Me.dirCliFac.Dock = System.Windows.Forms.DockStyle.Top
        Me.dirCliFac.FocoEnAgregar = False
        Me.dirCliFac.Label_Space = 75
        Me.dirCliFac.Location = New System.Drawing.Point(6, 44)
        Me.dirCliFac.Name = "dirCliFac"
        Me.dirCliFac.ReadOnly_Data = True
        Me.dirCliFac.requeryCP = False
        Me.dirCliFac.Show_Dir2L = False
        Me.dirCliFac.Show_GPS = False
        Me.dirCliFac.Show_Pais = True
        Me.dirCliFac.Size = New System.Drawing.Size(530, 104)
        Me.dirCliFac.TabIndex = 1
        Me.dirCliFac.Text_Data_CP = ""
        Me.dirCliFac.Text_Data_Direccion = ""
        Me.dirCliFac.Text_Data_Direccion2L = ""
        Me.dirCliFac.Text_Data_GPS = ""
        Me.dirCliFac.Text_Data_Pais = ""
        Me.dirCliFac.Text_Data_Poblacion = ""
        Me.dirCliFac.Text_Data_Provincia = ""
        '
        'pnlNomNifCliFac
        '
        Me.pnlNomNifCliFac.Auto_Size = False
        Me.pnlNomNifCliFac.BackColor = System.Drawing.SystemColors.Control
        Me.pnlNomNifCliFac.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlNomNifCliFac.ChangeDock = True
        Me.pnlNomNifCliFac.Control_Resize = False
        Me.pnlNomNifCliFac.Controls.Add(Me.dtfNombreCliFac)
        Me.pnlNomNifCliFac.Controls.Add(Me.Panel1)
        Me.pnlNomNifCliFac.Controls.Add(Me.dtfNIFCliFac)
        Me.pnlNomNifCliFac.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlNomNifCliFac.isSpace = False
        Me.pnlNomNifCliFac.Location = New System.Drawing.Point(6, 18)
        Me.pnlNomNifCliFac.Name = "pnlNomNifCliFac"
        Me.pnlNomNifCliFac.numRows = 1
        Me.pnlNomNifCliFac.Reorder = True
        Me.pnlNomNifCliFac.Size = New System.Drawing.Size(530, 26)
        Me.pnlNomNifCliFac.TabIndex = 0
        '
        'dtfNombreCliFac
        '
        Me.dtfNombreCliFac.Allow_Empty = True
        Me.dtfNombreCliFac.Allow_Negative = True
        Me.dtfNombreCliFac.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfNombreCliFac.BackColor = System.Drawing.SystemColors.Control
        Me.dtfNombreCliFac.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfNombreCliFac.DataField = "NOMBRE_CLI"
        Me.dtfNombreCliFac.DataTable = "F"
        Me.dtfNombreCliFac.Descripcion = "Nombre"
        Me.dtfNombreCliFac.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfNombreCliFac.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfNombreCliFac.FocoEnAgregar = False
        Me.dtfNombreCliFac.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfNombreCliFac.Image = Nothing
        Me.dtfNombreCliFac.Label_Space = 75
        Me.dtfNombreCliFac.Length_Data = 32767
        Me.dtfNombreCliFac.Location = New System.Drawing.Point(0, 0)
        Me.dtfNombreCliFac.Max_Value = 0R
        Me.dtfNombreCliFac.MensajeIncorrectoCustom = Nothing
        Me.dtfNombreCliFac.Name = "dtfNombreCliFac"
        Me.dtfNombreCliFac.Null_on_Empty = True
        Me.dtfNombreCliFac.OpenForm = Nothing
        Me.dtfNombreCliFac.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfNombreCliFac.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfNombreCliFac.ReadOnly_Data = True
        Me.dtfNombreCliFac.Show_Button = False
        Me.dtfNombreCliFac.Size = New System.Drawing.Size(410, 26)
        Me.dtfNombreCliFac.TabIndex = 0
        Me.dtfNombreCliFac.TabStop = False
        Me.dtfNombreCliFac.Text_Data = ""
        Me.dtfNombreCliFac.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfNombreCliFac.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfNombreCliFac.TopPadding = 0
        Me.dtfNombreCliFac.Upper_Case = False
        Me.dtfNombreCliFac.Validate_on_lost_focus = True
        '
        'Panel1
        '
        Me.Panel1.Auto_Size = False
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.BorderColor = System.Drawing.SystemColors.Control
        Me.Panel1.ChangeDock = True
        Me.Panel1.Control_Resize = True
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.isSpace = True
        Me.Panel1.Location = New System.Drawing.Point(410, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.numRows = 0
        Me.Panel1.Reorder = False
        Me.Panel1.Size = New System.Drawing.Size(6, 26)
        Me.Panel1.TabIndex = 1
        '
        'dtfNIFCliFac
        '
        Me.dtfNIFCliFac.Allow_Empty = True
        Me.dtfNIFCliFac.Allow_Negative = True
        Me.dtfNIFCliFac.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfNIFCliFac.BackColor = System.Drawing.SystemColors.Control
        Me.dtfNIFCliFac.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfNIFCliFac.DataField = "NIF_FAC"
        Me.dtfNIFCliFac.DataTable = "F"
        Me.dtfNIFCliFac.Descripcion = "NIF"
        Me.dtfNIFCliFac.Dock = System.Windows.Forms.DockStyle.Right
        Me.dtfNIFCliFac.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfNIFCliFac.FocoEnAgregar = False
        Me.dtfNIFCliFac.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfNIFCliFac.Image = Nothing
        Me.dtfNIFCliFac.Label_Space = 30
        Me.dtfNIFCliFac.Length_Data = 32767
        Me.dtfNIFCliFac.Location = New System.Drawing.Point(416, 0)
        Me.dtfNIFCliFac.Max_Value = 0R
        Me.dtfNIFCliFac.MensajeIncorrectoCustom = Nothing
        Me.dtfNIFCliFac.Name = "dtfNIFCliFac"
        Me.dtfNIFCliFac.Null_on_Empty = True
        Me.dtfNIFCliFac.OpenForm = Nothing
        Me.dtfNIFCliFac.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfNIFCliFac.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfNIFCliFac.ReadOnly_Data = True
        Me.dtfNIFCliFac.Show_Button = False
        Me.dtfNIFCliFac.Size = New System.Drawing.Size(114, 26)
        Me.dtfNIFCliFac.TabIndex = 2
        Me.dtfNIFCliFac.TabStop = False
        Me.dtfNIFCliFac.Text_Data = ""
        Me.dtfNIFCliFac.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfNIFCliFac.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfNIFCliFac.TopPadding = 0
        Me.dtfNIFCliFac.Upper_Case = False
        Me.dtfNIFCliFac.Validate_on_lost_focus = True
        '
        'pnlOtrosIzq
        '
        Me.pnlOtrosIzq.Auto_Size = False
        Me.pnlOtrosIzq.BackColor = System.Drawing.SystemColors.Control
        Me.pnlOtrosIzq.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlOtrosIzq.ChangeDock = False
        Me.pnlOtrosIzq.Control_Resize = False
        Me.pnlOtrosIzq.Controls.Add(Me.gbxVencimientos)
        Me.pnlOtrosIzq.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlOtrosIzq.isSpace = False
        Me.pnlOtrosIzq.Location = New System.Drawing.Point(3, 3)
        Me.pnlOtrosIzq.Name = "pnlOtrosIzq"
        Me.pnlOtrosIzq.numRows = 0
        Me.pnlOtrosIzq.Padding = New System.Windows.Forms.Padding(0, 1, 6, 0)
        Me.pnlOtrosIzq.Reorder = True
        Me.pnlOtrosIzq.Size = New System.Drawing.Size(391, 438)
        Me.pnlOtrosIzq.TabIndex = 0
        '
        'gbxVencimientos
        '
        Me.gbxVencimientos.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.gbxVencimientos.Controls.Add(Me.btnRecalcVtos)
        Me.gbxVencimientos.Controls.Add(Me.btnResetVto)
        Me.gbxVencimientos.Controls.Add(Me.pnlVto10)
        Me.gbxVencimientos.Controls.Add(Me.pnlVto9)
        Me.gbxVencimientos.Controls.Add(Me.pnlVto8)
        Me.gbxVencimientos.Controls.Add(Me.pnlVto7)
        Me.gbxVencimientos.Controls.Add(Me.pnlVto6)
        Me.gbxVencimientos.Controls.Add(Me.pnlVto5)
        Me.gbxVencimientos.Controls.Add(Me.pnlVto4)
        Me.gbxVencimientos.Controls.Add(Me.pnlVto3)
        Me.gbxVencimientos.Controls.Add(Me.pnlVto2)
        Me.gbxVencimientos.Controls.Add(Me.pnlVto1)
        Me.gbxVencimientos.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbxVencimientos.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.gbxVencimientos.HeaderText = "Vencimientos"
        Me.gbxVencimientos.Location = New System.Drawing.Point(0, 1)
        Me.gbxVencimientos.Name = "gbxVencimientos"
        Me.gbxVencimientos.numRows = 11
        Me.gbxVencimientos.Padding = New System.Windows.Forms.Padding(6, 18, 6, 6)
        Me.gbxVencimientos.Reorder = True
        Me.gbxVencimientos.Size = New System.Drawing.Size(385, 308)
        Me.gbxVencimientos.TabIndex = 0
        Me.gbxVencimientos.Text = "Vencimientos"
        Me.gbxVencimientos.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.gbxVencimientos.ThemeName = "Windows8"
        Me.gbxVencimientos.Title = "Vencimientos"
        '
        'btnRecalcVtos
        '
        Me.btnRecalcVtos.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnRecalcVtos.Location = New System.Drawing.Point(222, 277)
        Me.btnRecalcVtos.Name = "btnRecalcVtos"
        Me.btnRecalcVtos.Size = New System.Drawing.Size(160, 23)
        Me.btnRecalcVtos.TabIndex = 11
        Me.btnRecalcVtos.Text = "Recalcular Vencimientos"
        Me.btnRecalcVtos.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.btnRecalcVtos.ThemeName = "Windows8"
        '
        'btnResetVto
        '
        Me.btnResetVto.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnResetVto.Location = New System.Drawing.Point(6, 277)
        Me.btnResetVto.Name = "btnResetVto"
        Me.btnResetVto.Size = New System.Drawing.Size(160, 23)
        Me.btnResetVto.TabIndex = 10
        Me.btnResetVto.Text = "Reiniciar Vencimientos"
        Me.btnResetVto.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.btnResetVto.ThemeName = "Windows8"
        '
        'pnlVto10
        '
        Me.pnlVto10.Auto_Size = False
        Me.pnlVto10.BackColor = System.Drawing.SystemColors.Control
        Me.pnlVto10.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlVto10.ChangeDock = False
        Me.pnlVto10.Control_Resize = False
        Me.pnlVto10.Controls.Add(Me.dtfImpVto10)
        Me.pnlVto10.Controls.Add(Me.pnlSpace36)
        Me.pnlVto10.Controls.Add(Me.lblGuion10)
        Me.pnlVto10.Controls.Add(Me.pnlSpace37)
        Me.pnlVto10.Controls.Add(Me.lblEur10)
        Me.pnlVto10.Controls.Add(Me.pnlSpace35)
        Me.pnlVto10.Controls.Add(Me.dtdVto10)
        Me.pnlVto10.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlVto10.isSpace = False
        Me.pnlVto10.Location = New System.Drawing.Point(6, 252)
        Me.pnlVto10.Name = "pnlVto10"
        Me.pnlVto10.numRows = 1
        Me.pnlVto10.Reorder = False
        Me.pnlVto10.Size = New System.Drawing.Size(373, 26)
        Me.pnlVto10.TabIndex = 9
        '
        'dtfImpVto10
        '
        Me.dtfImpVto10.Allow_Empty = True
        Me.dtfImpVto10.Allow_Negative = True
        Me.dtfImpVto10.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfImpVto10.BackColor = System.Drawing.SystemColors.Control
        Me.dtfImpVto10.Data_Allowed = CustomControls.Datafield.List_Data.nDouble
        Me.dtfImpVto10.DataField = "IMP10_FAC"
        Me.dtfImpVto10.DataTable = "F"
        Me.dtfImpVto10.Descripcion = "Importe"
        Me.dtfImpVto10.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfImpVto10.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfImpVto10.FocoEnAgregar = False
        Me.dtfImpVto10.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfImpVto10.Image = Nothing
        Me.dtfImpVto10.Label_Space = 60
        Me.dtfImpVto10.Length_Data = 32767
        Me.dtfImpVto10.Location = New System.Drawing.Point(213, 0)
        Me.dtfImpVto10.Max_Value = 0R
        Me.dtfImpVto10.MensajeIncorrectoCustom = Nothing
        Me.dtfImpVto10.Name = "dtfImpVto10"
        Me.dtfImpVto10.Null_on_Empty = True
        Me.dtfImpVto10.OpenForm = Nothing
        Me.dtfImpVto10.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfImpVto10.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfImpVto10.ReadOnly_Data = False
        Me.dtfImpVto10.Show_Button = False
        Me.dtfImpVto10.Size = New System.Drawing.Size(141, 26)
        Me.dtfImpVto10.TabIndex = 2
        Me.dtfImpVto10.Text_Data = ""
        Me.dtfImpVto10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.dtfImpVto10.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfImpVto10.TopPadding = 0
        Me.dtfImpVto10.Upper_Case = False
        Me.dtfImpVto10.Validate_on_lost_focus = True
        '
        'pnlSpace36
        '
        Me.pnlSpace36.Auto_Size = False
        Me.pnlSpace36.BackColor = System.Drawing.SystemColors.Control
        Me.pnlSpace36.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace36.ChangeDock = True
        Me.pnlSpace36.Control_Resize = True
        Me.pnlSpace36.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace36.isSpace = True
        Me.pnlSpace36.Location = New System.Drawing.Point(207, 0)
        Me.pnlSpace36.Name = "pnlSpace36"
        Me.pnlSpace36.numRows = 0
        Me.pnlSpace36.Reorder = False
        Me.pnlSpace36.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace36.TabIndex = 7
        '
        'lblGuion10
        '
        Me.lblGuion10.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblGuion10.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblGuion10.Location = New System.Drawing.Point(196, 0)
        Me.lblGuion10.Name = "lblGuion10"
        Me.lblGuion10.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.lblGuion10.Size = New System.Drawing.Size(11, 26)
        Me.lblGuion10.TabIndex = 8
        Me.lblGuion10.Text = "-"
        '
        'pnlSpace37
        '
        Me.pnlSpace37.Auto_Size = False
        Me.pnlSpace37.BackColor = System.Drawing.SystemColors.Control
        Me.pnlSpace37.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace37.ChangeDock = True
        Me.pnlSpace37.Control_Resize = True
        Me.pnlSpace37.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSpace37.isSpace = True
        Me.pnlSpace37.Location = New System.Drawing.Point(354, 0)
        Me.pnlSpace37.Name = "pnlSpace37"
        Me.pnlSpace37.numRows = 0
        Me.pnlSpace37.Reorder = False
        Me.pnlSpace37.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace37.TabIndex = 6
        '
        'lblEur10
        '
        Me.lblEur10.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblEur10.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblEur10.Location = New System.Drawing.Point(360, 0)
        Me.lblEur10.Name = "lblEur10"
        Me.lblEur10.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.lblEur10.Size = New System.Drawing.Size(13, 26)
        Me.lblEur10.TabIndex = 5
        Me.lblEur10.Text = "€"
        '
        'pnlSpace35
        '
        Me.pnlSpace35.Auto_Size = False
        Me.pnlSpace35.BackColor = System.Drawing.SystemColors.Control
        Me.pnlSpace35.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace35.ChangeDock = True
        Me.pnlSpace35.Control_Resize = True
        Me.pnlSpace35.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace35.isSpace = True
        Me.pnlSpace35.Location = New System.Drawing.Point(190, 0)
        Me.pnlSpace35.Name = "pnlSpace35"
        Me.pnlSpace35.numRows = 0
        Me.pnlSpace35.Reorder = False
        Me.pnlSpace35.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace35.TabIndex = 3
        '
        'dtdVto10
        '
        Me.dtdVto10.Allow_Empty = True
        Me.dtdVto10.DataField = "VTO10_FAC"
        Me.dtdVto10.DataTable = "F"
        Me.dtdVto10.Default_Value = Nothing
        Me.dtdVto10.Descripcion = "Vencimiento 10"
        Me.dtdVto10.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtdVto10.FocoEnAgregar = False
        Me.dtdVto10.Label_Space = 100
        Me.dtdVto10.Location = New System.Drawing.Point(0, 0)
        Me.dtdVto10.Max_Value = Nothing
        Me.dtdVto10.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdVto10.MensajeIncorrectoCustom = Nothing
        Me.dtdVto10.Min_Value = Nothing
        Me.dtdVto10.MinDate = New Date(CType(0, Long))
        Me.dtdVto10.MinimumSize = New System.Drawing.Size(190, 26)
        Me.dtdVto10.Name = "dtdVto10"
        Me.dtdVto10.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdVto10.ReadOnly_Data = False
        Me.dtdVto10.Size = New System.Drawing.Size(190, 26)
        Me.dtdVto10.TabIndex = 1
        Me.dtdVto10.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdVto10.Validate_on_lost_focus = True
        Me.dtdVto10.Value_Data = Nothing
        '
        'pnlVto9
        '
        Me.pnlVto9.Auto_Size = False
        Me.pnlVto9.BackColor = System.Drawing.SystemColors.Control
        Me.pnlVto9.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlVto9.ChangeDock = False
        Me.pnlVto9.Control_Resize = False
        Me.pnlVto9.Controls.Add(Me.dtfImpVto9)
        Me.pnlVto9.Controls.Add(Me.pnlSpace33)
        Me.pnlVto9.Controls.Add(Me.lblGuion9)
        Me.pnlVto9.Controls.Add(Me.pnlSpace34)
        Me.pnlVto9.Controls.Add(Me.lblEur9)
        Me.pnlVto9.Controls.Add(Me.pnlSpace32)
        Me.pnlVto9.Controls.Add(Me.dtdVto9)
        Me.pnlVto9.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlVto9.isSpace = False
        Me.pnlVto9.Location = New System.Drawing.Point(6, 226)
        Me.pnlVto9.Name = "pnlVto9"
        Me.pnlVto9.numRows = 1
        Me.pnlVto9.Reorder = False
        Me.pnlVto9.Size = New System.Drawing.Size(373, 26)
        Me.pnlVto9.TabIndex = 8
        '
        'dtfImpVto9
        '
        Me.dtfImpVto9.Allow_Empty = True
        Me.dtfImpVto9.Allow_Negative = True
        Me.dtfImpVto9.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfImpVto9.BackColor = System.Drawing.SystemColors.Control
        Me.dtfImpVto9.Data_Allowed = CustomControls.Datafield.List_Data.nDouble
        Me.dtfImpVto9.DataField = "IMP9_FAC"
        Me.dtfImpVto9.DataTable = "F"
        Me.dtfImpVto9.Descripcion = "Importe"
        Me.dtfImpVto9.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfImpVto9.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfImpVto9.FocoEnAgregar = False
        Me.dtfImpVto9.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfImpVto9.Image = Nothing
        Me.dtfImpVto9.Label_Space = 60
        Me.dtfImpVto9.Length_Data = 32767
        Me.dtfImpVto9.Location = New System.Drawing.Point(213, 0)
        Me.dtfImpVto9.Max_Value = 0R
        Me.dtfImpVto9.MensajeIncorrectoCustom = Nothing
        Me.dtfImpVto9.Name = "dtfImpVto9"
        Me.dtfImpVto9.Null_on_Empty = True
        Me.dtfImpVto9.OpenForm = Nothing
        Me.dtfImpVto9.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfImpVto9.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfImpVto9.ReadOnly_Data = False
        Me.dtfImpVto9.Show_Button = False
        Me.dtfImpVto9.Size = New System.Drawing.Size(141, 26)
        Me.dtfImpVto9.TabIndex = 2
        Me.dtfImpVto9.Text_Data = ""
        Me.dtfImpVto9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.dtfImpVto9.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfImpVto9.TopPadding = 0
        Me.dtfImpVto9.Upper_Case = False
        Me.dtfImpVto9.Validate_on_lost_focus = True
        '
        'pnlSpace33
        '
        Me.pnlSpace33.Auto_Size = False
        Me.pnlSpace33.BackColor = System.Drawing.SystemColors.Control
        Me.pnlSpace33.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace33.ChangeDock = True
        Me.pnlSpace33.Control_Resize = True
        Me.pnlSpace33.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace33.isSpace = True
        Me.pnlSpace33.Location = New System.Drawing.Point(207, 0)
        Me.pnlSpace33.Name = "pnlSpace33"
        Me.pnlSpace33.numRows = 0
        Me.pnlSpace33.Reorder = False
        Me.pnlSpace33.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace33.TabIndex = 7
        '
        'lblGuion9
        '
        Me.lblGuion9.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblGuion9.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblGuion9.Location = New System.Drawing.Point(196, 0)
        Me.lblGuion9.Name = "lblGuion9"
        Me.lblGuion9.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.lblGuion9.Size = New System.Drawing.Size(11, 26)
        Me.lblGuion9.TabIndex = 8
        Me.lblGuion9.Text = "-"
        '
        'pnlSpace34
        '
        Me.pnlSpace34.Auto_Size = False
        Me.pnlSpace34.BackColor = System.Drawing.SystemColors.Control
        Me.pnlSpace34.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace34.ChangeDock = True
        Me.pnlSpace34.Control_Resize = True
        Me.pnlSpace34.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSpace34.isSpace = True
        Me.pnlSpace34.Location = New System.Drawing.Point(354, 0)
        Me.pnlSpace34.Name = "pnlSpace34"
        Me.pnlSpace34.numRows = 0
        Me.pnlSpace34.Reorder = False
        Me.pnlSpace34.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace34.TabIndex = 6
        '
        'lblEur9
        '
        Me.lblEur9.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblEur9.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblEur9.Location = New System.Drawing.Point(360, 0)
        Me.lblEur9.Name = "lblEur9"
        Me.lblEur9.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.lblEur9.Size = New System.Drawing.Size(13, 26)
        Me.lblEur9.TabIndex = 5
        Me.lblEur9.Text = "€"
        '
        'pnlSpace32
        '
        Me.pnlSpace32.Auto_Size = False
        Me.pnlSpace32.BackColor = System.Drawing.SystemColors.Control
        Me.pnlSpace32.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace32.ChangeDock = True
        Me.pnlSpace32.Control_Resize = True
        Me.pnlSpace32.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace32.isSpace = True
        Me.pnlSpace32.Location = New System.Drawing.Point(190, 0)
        Me.pnlSpace32.Name = "pnlSpace32"
        Me.pnlSpace32.numRows = 0
        Me.pnlSpace32.Reorder = False
        Me.pnlSpace32.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace32.TabIndex = 3
        '
        'dtdVto9
        '
        Me.dtdVto9.Allow_Empty = True
        Me.dtdVto9.DataField = "VTO9_FAC"
        Me.dtdVto9.DataTable = "F"
        Me.dtdVto9.Default_Value = Nothing
        Me.dtdVto9.Descripcion = "Vencimiento 9"
        Me.dtdVto9.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtdVto9.FocoEnAgregar = False
        Me.dtdVto9.Label_Space = 100
        Me.dtdVto9.Location = New System.Drawing.Point(0, 0)
        Me.dtdVto9.Max_Value = Nothing
        Me.dtdVto9.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdVto9.MensajeIncorrectoCustom = Nothing
        Me.dtdVto9.Min_Value = Nothing
        Me.dtdVto9.MinDate = New Date(CType(0, Long))
        Me.dtdVto9.MinimumSize = New System.Drawing.Size(190, 26)
        Me.dtdVto9.Name = "dtdVto9"
        Me.dtdVto9.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdVto9.ReadOnly_Data = False
        Me.dtdVto9.Size = New System.Drawing.Size(190, 26)
        Me.dtdVto9.TabIndex = 1
        Me.dtdVto9.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdVto9.Validate_on_lost_focus = True
        Me.dtdVto9.Value_Data = Nothing
        '
        'pnlVto8
        '
        Me.pnlVto8.Auto_Size = False
        Me.pnlVto8.BackColor = System.Drawing.SystemColors.Control
        Me.pnlVto8.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlVto8.ChangeDock = False
        Me.pnlVto8.Control_Resize = False
        Me.pnlVto8.Controls.Add(Me.dtfImpVto8)
        Me.pnlVto8.Controls.Add(Me.pnlSpace30)
        Me.pnlVto8.Controls.Add(Me.lblGuion8)
        Me.pnlVto8.Controls.Add(Me.pnlSpace31)
        Me.pnlVto8.Controls.Add(Me.lblEur8)
        Me.pnlVto8.Controls.Add(Me.pnlSpace29)
        Me.pnlVto8.Controls.Add(Me.dtdVto8)
        Me.pnlVto8.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlVto8.isSpace = False
        Me.pnlVto8.Location = New System.Drawing.Point(6, 200)
        Me.pnlVto8.Name = "pnlVto8"
        Me.pnlVto8.numRows = 1
        Me.pnlVto8.Reorder = False
        Me.pnlVto8.Size = New System.Drawing.Size(373, 26)
        Me.pnlVto8.TabIndex = 7
        '
        'dtfImpVto8
        '
        Me.dtfImpVto8.Allow_Empty = True
        Me.dtfImpVto8.Allow_Negative = True
        Me.dtfImpVto8.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfImpVto8.BackColor = System.Drawing.SystemColors.Control
        Me.dtfImpVto8.Data_Allowed = CustomControls.Datafield.List_Data.nDouble
        Me.dtfImpVto8.DataField = "IMP8_FAC"
        Me.dtfImpVto8.DataTable = "F"
        Me.dtfImpVto8.Descripcion = "Importe"
        Me.dtfImpVto8.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfImpVto8.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfImpVto8.FocoEnAgregar = False
        Me.dtfImpVto8.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfImpVto8.Image = Nothing
        Me.dtfImpVto8.Label_Space = 60
        Me.dtfImpVto8.Length_Data = 32767
        Me.dtfImpVto8.Location = New System.Drawing.Point(213, 0)
        Me.dtfImpVto8.Max_Value = 0R
        Me.dtfImpVto8.MensajeIncorrectoCustom = Nothing
        Me.dtfImpVto8.Name = "dtfImpVto8"
        Me.dtfImpVto8.Null_on_Empty = True
        Me.dtfImpVto8.OpenForm = Nothing
        Me.dtfImpVto8.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfImpVto8.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfImpVto8.ReadOnly_Data = False
        Me.dtfImpVto8.Show_Button = False
        Me.dtfImpVto8.Size = New System.Drawing.Size(141, 26)
        Me.dtfImpVto8.TabIndex = 2
        Me.dtfImpVto8.Text_Data = ""
        Me.dtfImpVto8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.dtfImpVto8.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfImpVto8.TopPadding = 0
        Me.dtfImpVto8.Upper_Case = False
        Me.dtfImpVto8.Validate_on_lost_focus = True
        '
        'pnlSpace30
        '
        Me.pnlSpace30.Auto_Size = False
        Me.pnlSpace30.BackColor = System.Drawing.SystemColors.Control
        Me.pnlSpace30.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace30.ChangeDock = True
        Me.pnlSpace30.Control_Resize = True
        Me.pnlSpace30.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace30.isSpace = True
        Me.pnlSpace30.Location = New System.Drawing.Point(207, 0)
        Me.pnlSpace30.Name = "pnlSpace30"
        Me.pnlSpace30.numRows = 0
        Me.pnlSpace30.Reorder = False
        Me.pnlSpace30.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace30.TabIndex = 7
        '
        'lblGuion8
        '
        Me.lblGuion8.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblGuion8.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblGuion8.Location = New System.Drawing.Point(196, 0)
        Me.lblGuion8.Name = "lblGuion8"
        Me.lblGuion8.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.lblGuion8.Size = New System.Drawing.Size(11, 26)
        Me.lblGuion8.TabIndex = 8
        Me.lblGuion8.Text = "-"
        '
        'pnlSpace31
        '
        Me.pnlSpace31.Auto_Size = False
        Me.pnlSpace31.BackColor = System.Drawing.SystemColors.Control
        Me.pnlSpace31.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace31.ChangeDock = True
        Me.pnlSpace31.Control_Resize = True
        Me.pnlSpace31.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSpace31.isSpace = True
        Me.pnlSpace31.Location = New System.Drawing.Point(354, 0)
        Me.pnlSpace31.Name = "pnlSpace31"
        Me.pnlSpace31.numRows = 0
        Me.pnlSpace31.Reorder = False
        Me.pnlSpace31.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace31.TabIndex = 6
        '
        'lblEur8
        '
        Me.lblEur8.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblEur8.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblEur8.Location = New System.Drawing.Point(360, 0)
        Me.lblEur8.Name = "lblEur8"
        Me.lblEur8.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.lblEur8.Size = New System.Drawing.Size(13, 26)
        Me.lblEur8.TabIndex = 5
        Me.lblEur8.Text = "€"
        '
        'pnlSpace29
        '
        Me.pnlSpace29.Auto_Size = False
        Me.pnlSpace29.BackColor = System.Drawing.SystemColors.Control
        Me.pnlSpace29.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace29.ChangeDock = True
        Me.pnlSpace29.Control_Resize = True
        Me.pnlSpace29.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace29.isSpace = True
        Me.pnlSpace29.Location = New System.Drawing.Point(190, 0)
        Me.pnlSpace29.Name = "pnlSpace29"
        Me.pnlSpace29.numRows = 0
        Me.pnlSpace29.Reorder = False
        Me.pnlSpace29.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace29.TabIndex = 3
        '
        'dtdVto8
        '
        Me.dtdVto8.Allow_Empty = True
        Me.dtdVto8.DataField = "VTO8_FAC"
        Me.dtdVto8.DataTable = "F"
        Me.dtdVto8.Default_Value = Nothing
        Me.dtdVto8.Descripcion = "Vencimiento 8"
        Me.dtdVto8.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtdVto8.FocoEnAgregar = False
        Me.dtdVto8.Label_Space = 100
        Me.dtdVto8.Location = New System.Drawing.Point(0, 0)
        Me.dtdVto8.Max_Value = Nothing
        Me.dtdVto8.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdVto8.MensajeIncorrectoCustom = Nothing
        Me.dtdVto8.Min_Value = Nothing
        Me.dtdVto8.MinDate = New Date(CType(0, Long))
        Me.dtdVto8.MinimumSize = New System.Drawing.Size(190, 26)
        Me.dtdVto8.Name = "dtdVto8"
        Me.dtdVto8.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdVto8.ReadOnly_Data = False
        Me.dtdVto8.Size = New System.Drawing.Size(190, 26)
        Me.dtdVto8.TabIndex = 1
        Me.dtdVto8.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdVto8.Validate_on_lost_focus = True
        Me.dtdVto8.Value_Data = Nothing
        '
        'pnlVto7
        '
        Me.pnlVto7.Auto_Size = False
        Me.pnlVto7.BackColor = System.Drawing.SystemColors.Control
        Me.pnlVto7.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlVto7.ChangeDock = False
        Me.pnlVto7.Control_Resize = False
        Me.pnlVto7.Controls.Add(Me.dtfImpVto7)
        Me.pnlVto7.Controls.Add(Me.pnlSpace27)
        Me.pnlVto7.Controls.Add(Me.lblGuion7)
        Me.pnlVto7.Controls.Add(Me.pnlSpace28)
        Me.pnlVto7.Controls.Add(Me.lblEur7)
        Me.pnlVto7.Controls.Add(Me.pnlSpace26)
        Me.pnlVto7.Controls.Add(Me.dtdVto7)
        Me.pnlVto7.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlVto7.isSpace = False
        Me.pnlVto7.Location = New System.Drawing.Point(6, 174)
        Me.pnlVto7.Name = "pnlVto7"
        Me.pnlVto7.numRows = 1
        Me.pnlVto7.Reorder = False
        Me.pnlVto7.Size = New System.Drawing.Size(373, 26)
        Me.pnlVto7.TabIndex = 6
        '
        'dtfImpVto7
        '
        Me.dtfImpVto7.Allow_Empty = True
        Me.dtfImpVto7.Allow_Negative = True
        Me.dtfImpVto7.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfImpVto7.BackColor = System.Drawing.SystemColors.Control
        Me.dtfImpVto7.Data_Allowed = CustomControls.Datafield.List_Data.nDouble
        Me.dtfImpVto7.DataField = "IMP7_FAC"
        Me.dtfImpVto7.DataTable = "F"
        Me.dtfImpVto7.Descripcion = "Importe"
        Me.dtfImpVto7.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfImpVto7.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfImpVto7.FocoEnAgregar = False
        Me.dtfImpVto7.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfImpVto7.Image = Nothing
        Me.dtfImpVto7.Label_Space = 60
        Me.dtfImpVto7.Length_Data = 32767
        Me.dtfImpVto7.Location = New System.Drawing.Point(213, 0)
        Me.dtfImpVto7.Max_Value = 0R
        Me.dtfImpVto7.MensajeIncorrectoCustom = Nothing
        Me.dtfImpVto7.Name = "dtfImpVto7"
        Me.dtfImpVto7.Null_on_Empty = True
        Me.dtfImpVto7.OpenForm = Nothing
        Me.dtfImpVto7.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfImpVto7.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfImpVto7.ReadOnly_Data = False
        Me.dtfImpVto7.Show_Button = False
        Me.dtfImpVto7.Size = New System.Drawing.Size(141, 26)
        Me.dtfImpVto7.TabIndex = 2
        Me.dtfImpVto7.Text_Data = ""
        Me.dtfImpVto7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.dtfImpVto7.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfImpVto7.TopPadding = 0
        Me.dtfImpVto7.Upper_Case = False
        Me.dtfImpVto7.Validate_on_lost_focus = True
        '
        'pnlSpace27
        '
        Me.pnlSpace27.Auto_Size = False
        Me.pnlSpace27.BackColor = System.Drawing.SystemColors.Control
        Me.pnlSpace27.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace27.ChangeDock = True
        Me.pnlSpace27.Control_Resize = True
        Me.pnlSpace27.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace27.isSpace = True
        Me.pnlSpace27.Location = New System.Drawing.Point(207, 0)
        Me.pnlSpace27.Name = "pnlSpace27"
        Me.pnlSpace27.numRows = 0
        Me.pnlSpace27.Reorder = False
        Me.pnlSpace27.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace27.TabIndex = 7
        '
        'lblGuion7
        '
        Me.lblGuion7.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblGuion7.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblGuion7.Location = New System.Drawing.Point(196, 0)
        Me.lblGuion7.Name = "lblGuion7"
        Me.lblGuion7.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.lblGuion7.Size = New System.Drawing.Size(11, 26)
        Me.lblGuion7.TabIndex = 8
        Me.lblGuion7.Text = "-"
        '
        'pnlSpace28
        '
        Me.pnlSpace28.Auto_Size = False
        Me.pnlSpace28.BackColor = System.Drawing.SystemColors.Control
        Me.pnlSpace28.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace28.ChangeDock = True
        Me.pnlSpace28.Control_Resize = True
        Me.pnlSpace28.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSpace28.isSpace = True
        Me.pnlSpace28.Location = New System.Drawing.Point(354, 0)
        Me.pnlSpace28.Name = "pnlSpace28"
        Me.pnlSpace28.numRows = 0
        Me.pnlSpace28.Reorder = False
        Me.pnlSpace28.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace28.TabIndex = 6
        '
        'lblEur7
        '
        Me.lblEur7.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblEur7.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblEur7.Location = New System.Drawing.Point(360, 0)
        Me.lblEur7.Name = "lblEur7"
        Me.lblEur7.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.lblEur7.Size = New System.Drawing.Size(13, 26)
        Me.lblEur7.TabIndex = 5
        Me.lblEur7.Text = "€"
        '
        'pnlSpace26
        '
        Me.pnlSpace26.Auto_Size = False
        Me.pnlSpace26.BackColor = System.Drawing.SystemColors.Control
        Me.pnlSpace26.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace26.ChangeDock = True
        Me.pnlSpace26.Control_Resize = True
        Me.pnlSpace26.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace26.isSpace = True
        Me.pnlSpace26.Location = New System.Drawing.Point(190, 0)
        Me.pnlSpace26.Name = "pnlSpace26"
        Me.pnlSpace26.numRows = 0
        Me.pnlSpace26.Reorder = False
        Me.pnlSpace26.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace26.TabIndex = 3
        '
        'dtdVto7
        '
        Me.dtdVto7.Allow_Empty = True
        Me.dtdVto7.DataField = "VTO7_FAC"
        Me.dtdVto7.DataTable = "F"
        Me.dtdVto7.Default_Value = Nothing
        Me.dtdVto7.Descripcion = "Vencimiento 7"
        Me.dtdVto7.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtdVto7.FocoEnAgregar = False
        Me.dtdVto7.Label_Space = 100
        Me.dtdVto7.Location = New System.Drawing.Point(0, 0)
        Me.dtdVto7.Max_Value = Nothing
        Me.dtdVto7.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdVto7.MensajeIncorrectoCustom = Nothing
        Me.dtdVto7.Min_Value = Nothing
        Me.dtdVto7.MinDate = New Date(CType(0, Long))
        Me.dtdVto7.MinimumSize = New System.Drawing.Size(190, 26)
        Me.dtdVto7.Name = "dtdVto7"
        Me.dtdVto7.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdVto7.ReadOnly_Data = False
        Me.dtdVto7.Size = New System.Drawing.Size(190, 26)
        Me.dtdVto7.TabIndex = 1
        Me.dtdVto7.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdVto7.Validate_on_lost_focus = True
        Me.dtdVto7.Value_Data = Nothing
        '
        'pnlVto6
        '
        Me.pnlVto6.Auto_Size = False
        Me.pnlVto6.BackColor = System.Drawing.SystemColors.Control
        Me.pnlVto6.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlVto6.ChangeDock = False
        Me.pnlVto6.Control_Resize = False
        Me.pnlVto6.Controls.Add(Me.dtfImpVto6)
        Me.pnlVto6.Controls.Add(Me.pnlSpace24)
        Me.pnlVto6.Controls.Add(Me.lblGuion6)
        Me.pnlVto6.Controls.Add(Me.pnlSpace25)
        Me.pnlVto6.Controls.Add(Me.lblEur6)
        Me.pnlVto6.Controls.Add(Me.pnlSpace23)
        Me.pnlVto6.Controls.Add(Me.dtdVto6)
        Me.pnlVto6.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlVto6.isSpace = False
        Me.pnlVto6.Location = New System.Drawing.Point(6, 148)
        Me.pnlVto6.Name = "pnlVto6"
        Me.pnlVto6.numRows = 1
        Me.pnlVto6.Reorder = False
        Me.pnlVto6.Size = New System.Drawing.Size(373, 26)
        Me.pnlVto6.TabIndex = 5
        '
        'dtfImpVto6
        '
        Me.dtfImpVto6.Allow_Empty = True
        Me.dtfImpVto6.Allow_Negative = True
        Me.dtfImpVto6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfImpVto6.BackColor = System.Drawing.SystemColors.Control
        Me.dtfImpVto6.Data_Allowed = CustomControls.Datafield.List_Data.nDouble
        Me.dtfImpVto6.DataField = "IMP6_FAC"
        Me.dtfImpVto6.DataTable = "F"
        Me.dtfImpVto6.Descripcion = "Importe"
        Me.dtfImpVto6.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfImpVto6.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfImpVto6.FocoEnAgregar = False
        Me.dtfImpVto6.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfImpVto6.Image = Nothing
        Me.dtfImpVto6.Label_Space = 60
        Me.dtfImpVto6.Length_Data = 32767
        Me.dtfImpVto6.Location = New System.Drawing.Point(213, 0)
        Me.dtfImpVto6.Max_Value = 0R
        Me.dtfImpVto6.MensajeIncorrectoCustom = Nothing
        Me.dtfImpVto6.Name = "dtfImpVto6"
        Me.dtfImpVto6.Null_on_Empty = True
        Me.dtfImpVto6.OpenForm = Nothing
        Me.dtfImpVto6.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfImpVto6.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfImpVto6.ReadOnly_Data = False
        Me.dtfImpVto6.Show_Button = False
        Me.dtfImpVto6.Size = New System.Drawing.Size(141, 26)
        Me.dtfImpVto6.TabIndex = 2
        Me.dtfImpVto6.Text_Data = ""
        Me.dtfImpVto6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.dtfImpVto6.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfImpVto6.TopPadding = 0
        Me.dtfImpVto6.Upper_Case = False
        Me.dtfImpVto6.Validate_on_lost_focus = True
        '
        'pnlSpace24
        '
        Me.pnlSpace24.Auto_Size = False
        Me.pnlSpace24.BackColor = System.Drawing.SystemColors.Control
        Me.pnlSpace24.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace24.ChangeDock = True
        Me.pnlSpace24.Control_Resize = True
        Me.pnlSpace24.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace24.isSpace = True
        Me.pnlSpace24.Location = New System.Drawing.Point(207, 0)
        Me.pnlSpace24.Name = "pnlSpace24"
        Me.pnlSpace24.numRows = 0
        Me.pnlSpace24.Reorder = False
        Me.pnlSpace24.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace24.TabIndex = 7
        '
        'lblGuion6
        '
        Me.lblGuion6.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblGuion6.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblGuion6.Location = New System.Drawing.Point(196, 0)
        Me.lblGuion6.Name = "lblGuion6"
        Me.lblGuion6.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.lblGuion6.Size = New System.Drawing.Size(11, 26)
        Me.lblGuion6.TabIndex = 8
        Me.lblGuion6.Text = "-"
        '
        'pnlSpace25
        '
        Me.pnlSpace25.Auto_Size = False
        Me.pnlSpace25.BackColor = System.Drawing.SystemColors.Control
        Me.pnlSpace25.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace25.ChangeDock = True
        Me.pnlSpace25.Control_Resize = True
        Me.pnlSpace25.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSpace25.isSpace = True
        Me.pnlSpace25.Location = New System.Drawing.Point(354, 0)
        Me.pnlSpace25.Name = "pnlSpace25"
        Me.pnlSpace25.numRows = 0
        Me.pnlSpace25.Reorder = False
        Me.pnlSpace25.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace25.TabIndex = 6
        '
        'lblEur6
        '
        Me.lblEur6.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblEur6.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblEur6.Location = New System.Drawing.Point(360, 0)
        Me.lblEur6.Name = "lblEur6"
        Me.lblEur6.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.lblEur6.Size = New System.Drawing.Size(13, 26)
        Me.lblEur6.TabIndex = 5
        Me.lblEur6.Text = "€"
        '
        'pnlSpace23
        '
        Me.pnlSpace23.Auto_Size = False
        Me.pnlSpace23.BackColor = System.Drawing.SystemColors.Control
        Me.pnlSpace23.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace23.ChangeDock = True
        Me.pnlSpace23.Control_Resize = True
        Me.pnlSpace23.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace23.isSpace = True
        Me.pnlSpace23.Location = New System.Drawing.Point(190, 0)
        Me.pnlSpace23.Name = "pnlSpace23"
        Me.pnlSpace23.numRows = 0
        Me.pnlSpace23.Reorder = False
        Me.pnlSpace23.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace23.TabIndex = 3
        '
        'dtdVto6
        '
        Me.dtdVto6.Allow_Empty = True
        Me.dtdVto6.DataField = "VTO6_FAC"
        Me.dtdVto6.DataTable = "F"
        Me.dtdVto6.Default_Value = Nothing
        Me.dtdVto6.Descripcion = "Vencimiento 6"
        Me.dtdVto6.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtdVto6.FocoEnAgregar = False
        Me.dtdVto6.Label_Space = 100
        Me.dtdVto6.Location = New System.Drawing.Point(0, 0)
        Me.dtdVto6.Max_Value = Nothing
        Me.dtdVto6.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdVto6.MensajeIncorrectoCustom = Nothing
        Me.dtdVto6.Min_Value = Nothing
        Me.dtdVto6.MinDate = New Date(CType(0, Long))
        Me.dtdVto6.MinimumSize = New System.Drawing.Size(190, 26)
        Me.dtdVto6.Name = "dtdVto6"
        Me.dtdVto6.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdVto6.ReadOnly_Data = False
        Me.dtdVto6.Size = New System.Drawing.Size(190, 26)
        Me.dtdVto6.TabIndex = 1
        Me.dtdVto6.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdVto6.Validate_on_lost_focus = True
        Me.dtdVto6.Value_Data = Nothing
        '
        'pnlVto5
        '
        Me.pnlVto5.Auto_Size = False
        Me.pnlVto5.BackColor = System.Drawing.SystemColors.Control
        Me.pnlVto5.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlVto5.ChangeDock = False
        Me.pnlVto5.Control_Resize = False
        Me.pnlVto5.Controls.Add(Me.dtfImpVto5)
        Me.pnlVto5.Controls.Add(Me.pnlSpace21)
        Me.pnlVto5.Controls.Add(Me.lblGuion5)
        Me.pnlVto5.Controls.Add(Me.pnlSpace22)
        Me.pnlVto5.Controls.Add(Me.lblEur5)
        Me.pnlVto5.Controls.Add(Me.pnlSpace20)
        Me.pnlVto5.Controls.Add(Me.dtdVto5)
        Me.pnlVto5.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlVto5.isSpace = False
        Me.pnlVto5.Location = New System.Drawing.Point(6, 122)
        Me.pnlVto5.Name = "pnlVto5"
        Me.pnlVto5.numRows = 1
        Me.pnlVto5.Reorder = False
        Me.pnlVto5.Size = New System.Drawing.Size(373, 26)
        Me.pnlVto5.TabIndex = 4
        '
        'dtfImpVto5
        '
        Me.dtfImpVto5.Allow_Empty = True
        Me.dtfImpVto5.Allow_Negative = True
        Me.dtfImpVto5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfImpVto5.BackColor = System.Drawing.SystemColors.Control
        Me.dtfImpVto5.Data_Allowed = CustomControls.Datafield.List_Data.nDouble
        Me.dtfImpVto5.DataField = "IMP5_FAC"
        Me.dtfImpVto5.DataTable = "F"
        Me.dtfImpVto5.Descripcion = "Importe"
        Me.dtfImpVto5.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfImpVto5.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfImpVto5.FocoEnAgregar = False
        Me.dtfImpVto5.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfImpVto5.Image = Nothing
        Me.dtfImpVto5.Label_Space = 60
        Me.dtfImpVto5.Length_Data = 32767
        Me.dtfImpVto5.Location = New System.Drawing.Point(213, 0)
        Me.dtfImpVto5.Max_Value = 0R
        Me.dtfImpVto5.MensajeIncorrectoCustom = Nothing
        Me.dtfImpVto5.Name = "dtfImpVto5"
        Me.dtfImpVto5.Null_on_Empty = True
        Me.dtfImpVto5.OpenForm = Nothing
        Me.dtfImpVto5.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfImpVto5.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfImpVto5.ReadOnly_Data = False
        Me.dtfImpVto5.Show_Button = False
        Me.dtfImpVto5.Size = New System.Drawing.Size(141, 26)
        Me.dtfImpVto5.TabIndex = 2
        Me.dtfImpVto5.Text_Data = ""
        Me.dtfImpVto5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.dtfImpVto5.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfImpVto5.TopPadding = 0
        Me.dtfImpVto5.Upper_Case = False
        Me.dtfImpVto5.Validate_on_lost_focus = True
        '
        'pnlSpace21
        '
        Me.pnlSpace21.Auto_Size = False
        Me.pnlSpace21.BackColor = System.Drawing.SystemColors.Control
        Me.pnlSpace21.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace21.ChangeDock = True
        Me.pnlSpace21.Control_Resize = True
        Me.pnlSpace21.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace21.isSpace = True
        Me.pnlSpace21.Location = New System.Drawing.Point(207, 0)
        Me.pnlSpace21.Name = "pnlSpace21"
        Me.pnlSpace21.numRows = 0
        Me.pnlSpace21.Reorder = False
        Me.pnlSpace21.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace21.TabIndex = 7
        '
        'lblGuion5
        '
        Me.lblGuion5.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblGuion5.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblGuion5.Location = New System.Drawing.Point(196, 0)
        Me.lblGuion5.Name = "lblGuion5"
        Me.lblGuion5.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.lblGuion5.Size = New System.Drawing.Size(11, 26)
        Me.lblGuion5.TabIndex = 8
        Me.lblGuion5.Text = "-"
        '
        'pnlSpace22
        '
        Me.pnlSpace22.Auto_Size = False
        Me.pnlSpace22.BackColor = System.Drawing.SystemColors.Control
        Me.pnlSpace22.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace22.ChangeDock = True
        Me.pnlSpace22.Control_Resize = True
        Me.pnlSpace22.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSpace22.isSpace = True
        Me.pnlSpace22.Location = New System.Drawing.Point(354, 0)
        Me.pnlSpace22.Name = "pnlSpace22"
        Me.pnlSpace22.numRows = 0
        Me.pnlSpace22.Reorder = False
        Me.pnlSpace22.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace22.TabIndex = 6
        '
        'lblEur5
        '
        Me.lblEur5.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblEur5.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblEur5.Location = New System.Drawing.Point(360, 0)
        Me.lblEur5.Name = "lblEur5"
        Me.lblEur5.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.lblEur5.Size = New System.Drawing.Size(13, 26)
        Me.lblEur5.TabIndex = 5
        Me.lblEur5.Text = "€"
        '
        'pnlSpace20
        '
        Me.pnlSpace20.Auto_Size = False
        Me.pnlSpace20.BackColor = System.Drawing.SystemColors.Control
        Me.pnlSpace20.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace20.ChangeDock = True
        Me.pnlSpace20.Control_Resize = True
        Me.pnlSpace20.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace20.isSpace = True
        Me.pnlSpace20.Location = New System.Drawing.Point(190, 0)
        Me.pnlSpace20.Name = "pnlSpace20"
        Me.pnlSpace20.numRows = 0
        Me.pnlSpace20.Reorder = False
        Me.pnlSpace20.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace20.TabIndex = 3
        '
        'dtdVto5
        '
        Me.dtdVto5.Allow_Empty = True
        Me.dtdVto5.DataField = "VTO5_FAC"
        Me.dtdVto5.DataTable = "F"
        Me.dtdVto5.Default_Value = Nothing
        Me.dtdVto5.Descripcion = "Vencimiento 5"
        Me.dtdVto5.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtdVto5.FocoEnAgregar = False
        Me.dtdVto5.Label_Space = 100
        Me.dtdVto5.Location = New System.Drawing.Point(0, 0)
        Me.dtdVto5.Max_Value = Nothing
        Me.dtdVto5.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdVto5.MensajeIncorrectoCustom = Nothing
        Me.dtdVto5.Min_Value = Nothing
        Me.dtdVto5.MinDate = New Date(CType(0, Long))
        Me.dtdVto5.MinimumSize = New System.Drawing.Size(190, 26)
        Me.dtdVto5.Name = "dtdVto5"
        Me.dtdVto5.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdVto5.ReadOnly_Data = False
        Me.dtdVto5.Size = New System.Drawing.Size(190, 26)
        Me.dtdVto5.TabIndex = 1
        Me.dtdVto5.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdVto5.Validate_on_lost_focus = True
        Me.dtdVto5.Value_Data = Nothing
        '
        'pnlVto4
        '
        Me.pnlVto4.Auto_Size = False
        Me.pnlVto4.BackColor = System.Drawing.SystemColors.Control
        Me.pnlVto4.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlVto4.ChangeDock = False
        Me.pnlVto4.Control_Resize = False
        Me.pnlVto4.Controls.Add(Me.dtfImpVto4)
        Me.pnlVto4.Controls.Add(Me.pnlSpace18)
        Me.pnlVto4.Controls.Add(Me.lblGuion4)
        Me.pnlVto4.Controls.Add(Me.pnlSpace19)
        Me.pnlVto4.Controls.Add(Me.lblEur4)
        Me.pnlVto4.Controls.Add(Me.pnlSpace17)
        Me.pnlVto4.Controls.Add(Me.dtdVto4)
        Me.pnlVto4.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlVto4.isSpace = False
        Me.pnlVto4.Location = New System.Drawing.Point(6, 96)
        Me.pnlVto4.Name = "pnlVto4"
        Me.pnlVto4.numRows = 1
        Me.pnlVto4.Reorder = False
        Me.pnlVto4.Size = New System.Drawing.Size(373, 26)
        Me.pnlVto4.TabIndex = 3
        '
        'dtfImpVto4
        '
        Me.dtfImpVto4.Allow_Empty = True
        Me.dtfImpVto4.Allow_Negative = True
        Me.dtfImpVto4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfImpVto4.BackColor = System.Drawing.SystemColors.Control
        Me.dtfImpVto4.Data_Allowed = CustomControls.Datafield.List_Data.nDouble
        Me.dtfImpVto4.DataField = "IMP4_FAC"
        Me.dtfImpVto4.DataTable = "F"
        Me.dtfImpVto4.Descripcion = "Importe"
        Me.dtfImpVto4.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfImpVto4.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfImpVto4.FocoEnAgregar = False
        Me.dtfImpVto4.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfImpVto4.Image = Nothing
        Me.dtfImpVto4.Label_Space = 60
        Me.dtfImpVto4.Length_Data = 32767
        Me.dtfImpVto4.Location = New System.Drawing.Point(213, 0)
        Me.dtfImpVto4.Max_Value = 0R
        Me.dtfImpVto4.MensajeIncorrectoCustom = Nothing
        Me.dtfImpVto4.Name = "dtfImpVto4"
        Me.dtfImpVto4.Null_on_Empty = True
        Me.dtfImpVto4.OpenForm = Nothing
        Me.dtfImpVto4.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfImpVto4.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfImpVto4.ReadOnly_Data = False
        Me.dtfImpVto4.Show_Button = False
        Me.dtfImpVto4.Size = New System.Drawing.Size(141, 26)
        Me.dtfImpVto4.TabIndex = 2
        Me.dtfImpVto4.Text_Data = ""
        Me.dtfImpVto4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.dtfImpVto4.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfImpVto4.TopPadding = 0
        Me.dtfImpVto4.Upper_Case = False
        Me.dtfImpVto4.Validate_on_lost_focus = True
        '
        'pnlSpace18
        '
        Me.pnlSpace18.Auto_Size = False
        Me.pnlSpace18.BackColor = System.Drawing.SystemColors.Control
        Me.pnlSpace18.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace18.ChangeDock = True
        Me.pnlSpace18.Control_Resize = True
        Me.pnlSpace18.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace18.isSpace = True
        Me.pnlSpace18.Location = New System.Drawing.Point(207, 0)
        Me.pnlSpace18.Name = "pnlSpace18"
        Me.pnlSpace18.numRows = 0
        Me.pnlSpace18.Reorder = False
        Me.pnlSpace18.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace18.TabIndex = 7
        '
        'lblGuion4
        '
        Me.lblGuion4.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblGuion4.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblGuion4.Location = New System.Drawing.Point(196, 0)
        Me.lblGuion4.Name = "lblGuion4"
        Me.lblGuion4.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.lblGuion4.Size = New System.Drawing.Size(11, 26)
        Me.lblGuion4.TabIndex = 8
        Me.lblGuion4.Text = "-"
        '
        'pnlSpace19
        '
        Me.pnlSpace19.Auto_Size = False
        Me.pnlSpace19.BackColor = System.Drawing.SystemColors.Control
        Me.pnlSpace19.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace19.ChangeDock = True
        Me.pnlSpace19.Control_Resize = True
        Me.pnlSpace19.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSpace19.isSpace = True
        Me.pnlSpace19.Location = New System.Drawing.Point(354, 0)
        Me.pnlSpace19.Name = "pnlSpace19"
        Me.pnlSpace19.numRows = 0
        Me.pnlSpace19.Reorder = False
        Me.pnlSpace19.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace19.TabIndex = 6
        '
        'lblEur4
        '
        Me.lblEur4.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblEur4.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblEur4.Location = New System.Drawing.Point(360, 0)
        Me.lblEur4.Name = "lblEur4"
        Me.lblEur4.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.lblEur4.Size = New System.Drawing.Size(13, 26)
        Me.lblEur4.TabIndex = 5
        Me.lblEur4.Text = "€"
        '
        'pnlSpace17
        '
        Me.pnlSpace17.Auto_Size = False
        Me.pnlSpace17.BackColor = System.Drawing.SystemColors.Control
        Me.pnlSpace17.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace17.ChangeDock = True
        Me.pnlSpace17.Control_Resize = True
        Me.pnlSpace17.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace17.isSpace = True
        Me.pnlSpace17.Location = New System.Drawing.Point(190, 0)
        Me.pnlSpace17.Name = "pnlSpace17"
        Me.pnlSpace17.numRows = 0
        Me.pnlSpace17.Reorder = False
        Me.pnlSpace17.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace17.TabIndex = 3
        '
        'dtdVto4
        '
        Me.dtdVto4.Allow_Empty = True
        Me.dtdVto4.DataField = "VTO4_FAC"
        Me.dtdVto4.DataTable = "F"
        Me.dtdVto4.Default_Value = Nothing
        Me.dtdVto4.Descripcion = "Vencimiento 4"
        Me.dtdVto4.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtdVto4.FocoEnAgregar = False
        Me.dtdVto4.Label_Space = 100
        Me.dtdVto4.Location = New System.Drawing.Point(0, 0)
        Me.dtdVto4.Max_Value = Nothing
        Me.dtdVto4.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdVto4.MensajeIncorrectoCustom = Nothing
        Me.dtdVto4.Min_Value = Nothing
        Me.dtdVto4.MinDate = New Date(CType(0, Long))
        Me.dtdVto4.MinimumSize = New System.Drawing.Size(190, 26)
        Me.dtdVto4.Name = "dtdVto4"
        Me.dtdVto4.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdVto4.ReadOnly_Data = False
        Me.dtdVto4.Size = New System.Drawing.Size(190, 26)
        Me.dtdVto4.TabIndex = 1
        Me.dtdVto4.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdVto4.Validate_on_lost_focus = True
        Me.dtdVto4.Value_Data = Nothing
        '
        'pnlVto3
        '
        Me.pnlVto3.Auto_Size = False
        Me.pnlVto3.BackColor = System.Drawing.SystemColors.Control
        Me.pnlVto3.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlVto3.ChangeDock = False
        Me.pnlVto3.Control_Resize = False
        Me.pnlVto3.Controls.Add(Me.dtfImpVto3)
        Me.pnlVto3.Controls.Add(Me.pnlSpace15)
        Me.pnlVto3.Controls.Add(Me.lblGuion3)
        Me.pnlVto3.Controls.Add(Me.pnlSpace16)
        Me.pnlVto3.Controls.Add(Me.lblEur3)
        Me.pnlVto3.Controls.Add(Me.pnlSpace14)
        Me.pnlVto3.Controls.Add(Me.dtdVto3)
        Me.pnlVto3.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlVto3.isSpace = False
        Me.pnlVto3.Location = New System.Drawing.Point(6, 70)
        Me.pnlVto3.Name = "pnlVto3"
        Me.pnlVto3.numRows = 1
        Me.pnlVto3.Reorder = False
        Me.pnlVto3.Size = New System.Drawing.Size(373, 26)
        Me.pnlVto3.TabIndex = 2
        '
        'dtfImpVto3
        '
        Me.dtfImpVto3.Allow_Empty = True
        Me.dtfImpVto3.Allow_Negative = True
        Me.dtfImpVto3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfImpVto3.BackColor = System.Drawing.SystemColors.Control
        Me.dtfImpVto3.Data_Allowed = CustomControls.Datafield.List_Data.nDouble
        Me.dtfImpVto3.DataField = "IMP3_FAC"
        Me.dtfImpVto3.DataTable = "F"
        Me.dtfImpVto3.Descripcion = "Importe"
        Me.dtfImpVto3.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfImpVto3.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfImpVto3.FocoEnAgregar = False
        Me.dtfImpVto3.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfImpVto3.Image = Nothing
        Me.dtfImpVto3.Label_Space = 60
        Me.dtfImpVto3.Length_Data = 32767
        Me.dtfImpVto3.Location = New System.Drawing.Point(213, 0)
        Me.dtfImpVto3.Max_Value = 0R
        Me.dtfImpVto3.MensajeIncorrectoCustom = Nothing
        Me.dtfImpVto3.Name = "dtfImpVto3"
        Me.dtfImpVto3.Null_on_Empty = True
        Me.dtfImpVto3.OpenForm = Nothing
        Me.dtfImpVto3.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfImpVto3.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfImpVto3.ReadOnly_Data = False
        Me.dtfImpVto3.Show_Button = False
        Me.dtfImpVto3.Size = New System.Drawing.Size(141, 26)
        Me.dtfImpVto3.TabIndex = 2
        Me.dtfImpVto3.Text_Data = ""
        Me.dtfImpVto3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.dtfImpVto3.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfImpVto3.TopPadding = 0
        Me.dtfImpVto3.Upper_Case = False
        Me.dtfImpVto3.Validate_on_lost_focus = True
        '
        'pnlSpace15
        '
        Me.pnlSpace15.Auto_Size = False
        Me.pnlSpace15.BackColor = System.Drawing.SystemColors.Control
        Me.pnlSpace15.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace15.ChangeDock = True
        Me.pnlSpace15.Control_Resize = True
        Me.pnlSpace15.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace15.isSpace = True
        Me.pnlSpace15.Location = New System.Drawing.Point(207, 0)
        Me.pnlSpace15.Name = "pnlSpace15"
        Me.pnlSpace15.numRows = 0
        Me.pnlSpace15.Reorder = False
        Me.pnlSpace15.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace15.TabIndex = 7
        '
        'lblGuion3
        '
        Me.lblGuion3.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblGuion3.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblGuion3.Location = New System.Drawing.Point(196, 0)
        Me.lblGuion3.Name = "lblGuion3"
        Me.lblGuion3.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.lblGuion3.Size = New System.Drawing.Size(11, 26)
        Me.lblGuion3.TabIndex = 8
        Me.lblGuion3.Text = "-"
        '
        'pnlSpace16
        '
        Me.pnlSpace16.Auto_Size = False
        Me.pnlSpace16.BackColor = System.Drawing.SystemColors.Control
        Me.pnlSpace16.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace16.ChangeDock = True
        Me.pnlSpace16.Control_Resize = True
        Me.pnlSpace16.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSpace16.isSpace = True
        Me.pnlSpace16.Location = New System.Drawing.Point(354, 0)
        Me.pnlSpace16.Name = "pnlSpace16"
        Me.pnlSpace16.numRows = 0
        Me.pnlSpace16.Reorder = False
        Me.pnlSpace16.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace16.TabIndex = 6
        '
        'lblEur3
        '
        Me.lblEur3.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblEur3.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblEur3.Location = New System.Drawing.Point(360, 0)
        Me.lblEur3.Name = "lblEur3"
        Me.lblEur3.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.lblEur3.Size = New System.Drawing.Size(13, 26)
        Me.lblEur3.TabIndex = 5
        Me.lblEur3.Text = "€"
        '
        'pnlSpace14
        '
        Me.pnlSpace14.Auto_Size = False
        Me.pnlSpace14.BackColor = System.Drawing.SystemColors.Control
        Me.pnlSpace14.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace14.ChangeDock = True
        Me.pnlSpace14.Control_Resize = True
        Me.pnlSpace14.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace14.isSpace = True
        Me.pnlSpace14.Location = New System.Drawing.Point(190, 0)
        Me.pnlSpace14.Name = "pnlSpace14"
        Me.pnlSpace14.numRows = 0
        Me.pnlSpace14.Reorder = False
        Me.pnlSpace14.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace14.TabIndex = 3
        '
        'dtdVto3
        '
        Me.dtdVto3.Allow_Empty = True
        Me.dtdVto3.DataField = "VTO3_FAC"
        Me.dtdVto3.DataTable = "F"
        Me.dtdVto3.Default_Value = Nothing
        Me.dtdVto3.Descripcion = "Vencimiento 3"
        Me.dtdVto3.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtdVto3.FocoEnAgregar = False
        Me.dtdVto3.Label_Space = 100
        Me.dtdVto3.Location = New System.Drawing.Point(0, 0)
        Me.dtdVto3.Max_Value = Nothing
        Me.dtdVto3.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdVto3.MensajeIncorrectoCustom = Nothing
        Me.dtdVto3.Min_Value = Nothing
        Me.dtdVto3.MinDate = New Date(CType(0, Long))
        Me.dtdVto3.MinimumSize = New System.Drawing.Size(190, 26)
        Me.dtdVto3.Name = "dtdVto3"
        Me.dtdVto3.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdVto3.ReadOnly_Data = False
        Me.dtdVto3.Size = New System.Drawing.Size(190, 26)
        Me.dtdVto3.TabIndex = 1
        Me.dtdVto3.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdVto3.Validate_on_lost_focus = True
        Me.dtdVto3.Value_Data = Nothing
        '
        'pnlVto2
        '
        Me.pnlVto2.Auto_Size = False
        Me.pnlVto2.BackColor = System.Drawing.SystemColors.Control
        Me.pnlVto2.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlVto2.ChangeDock = False
        Me.pnlVto2.Control_Resize = False
        Me.pnlVto2.Controls.Add(Me.dtfImpVto2)
        Me.pnlVto2.Controls.Add(Me.pnlSpace12)
        Me.pnlVto2.Controls.Add(Me.lblGuion2)
        Me.pnlVto2.Controls.Add(Me.pnlSpace13)
        Me.pnlVto2.Controls.Add(Me.lblEur2)
        Me.pnlVto2.Controls.Add(Me.pnlSpace11)
        Me.pnlVto2.Controls.Add(Me.dtdVto2)
        Me.pnlVto2.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlVto2.isSpace = False
        Me.pnlVto2.Location = New System.Drawing.Point(6, 44)
        Me.pnlVto2.Name = "pnlVto2"
        Me.pnlVto2.numRows = 1
        Me.pnlVto2.Reorder = False
        Me.pnlVto2.Size = New System.Drawing.Size(373, 26)
        Me.pnlVto2.TabIndex = 1
        '
        'dtfImpVto2
        '
        Me.dtfImpVto2.Allow_Empty = True
        Me.dtfImpVto2.Allow_Negative = True
        Me.dtfImpVto2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfImpVto2.BackColor = System.Drawing.SystemColors.Control
        Me.dtfImpVto2.Data_Allowed = CustomControls.Datafield.List_Data.nDouble
        Me.dtfImpVto2.DataField = "IMP2_FAC"
        Me.dtfImpVto2.DataTable = "F"
        Me.dtfImpVto2.Descripcion = "Importe"
        Me.dtfImpVto2.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfImpVto2.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfImpVto2.FocoEnAgregar = False
        Me.dtfImpVto2.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfImpVto2.Image = Nothing
        Me.dtfImpVto2.Label_Space = 60
        Me.dtfImpVto2.Length_Data = 32767
        Me.dtfImpVto2.Location = New System.Drawing.Point(213, 0)
        Me.dtfImpVto2.Max_Value = 0R
        Me.dtfImpVto2.MensajeIncorrectoCustom = Nothing
        Me.dtfImpVto2.Name = "dtfImpVto2"
        Me.dtfImpVto2.Null_on_Empty = True
        Me.dtfImpVto2.OpenForm = Nothing
        Me.dtfImpVto2.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfImpVto2.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfImpVto2.ReadOnly_Data = False
        Me.dtfImpVto2.Show_Button = False
        Me.dtfImpVto2.Size = New System.Drawing.Size(141, 26)
        Me.dtfImpVto2.TabIndex = 2
        Me.dtfImpVto2.Text_Data = ""
        Me.dtfImpVto2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.dtfImpVto2.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfImpVto2.TopPadding = 0
        Me.dtfImpVto2.Upper_Case = False
        Me.dtfImpVto2.Validate_on_lost_focus = True
        '
        'pnlSpace12
        '
        Me.pnlSpace12.Auto_Size = False
        Me.pnlSpace12.BackColor = System.Drawing.SystemColors.Control
        Me.pnlSpace12.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace12.ChangeDock = True
        Me.pnlSpace12.Control_Resize = True
        Me.pnlSpace12.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace12.isSpace = True
        Me.pnlSpace12.Location = New System.Drawing.Point(207, 0)
        Me.pnlSpace12.Name = "pnlSpace12"
        Me.pnlSpace12.numRows = 0
        Me.pnlSpace12.Reorder = False
        Me.pnlSpace12.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace12.TabIndex = 7
        '
        'lblGuion2
        '
        Me.lblGuion2.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblGuion2.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblGuion2.Location = New System.Drawing.Point(196, 0)
        Me.lblGuion2.Name = "lblGuion2"
        Me.lblGuion2.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.lblGuion2.Size = New System.Drawing.Size(11, 26)
        Me.lblGuion2.TabIndex = 8
        Me.lblGuion2.Text = "-"
        '
        'pnlSpace13
        '
        Me.pnlSpace13.Auto_Size = False
        Me.pnlSpace13.BackColor = System.Drawing.SystemColors.Control
        Me.pnlSpace13.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace13.ChangeDock = True
        Me.pnlSpace13.Control_Resize = True
        Me.pnlSpace13.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSpace13.isSpace = True
        Me.pnlSpace13.Location = New System.Drawing.Point(354, 0)
        Me.pnlSpace13.Name = "pnlSpace13"
        Me.pnlSpace13.numRows = 0
        Me.pnlSpace13.Reorder = False
        Me.pnlSpace13.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace13.TabIndex = 6
        '
        'lblEur2
        '
        Me.lblEur2.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblEur2.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblEur2.Location = New System.Drawing.Point(360, 0)
        Me.lblEur2.Name = "lblEur2"
        Me.lblEur2.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.lblEur2.Size = New System.Drawing.Size(13, 26)
        Me.lblEur2.TabIndex = 5
        Me.lblEur2.Text = "€"
        '
        'pnlSpace11
        '
        Me.pnlSpace11.Auto_Size = False
        Me.pnlSpace11.BackColor = System.Drawing.SystemColors.Control
        Me.pnlSpace11.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace11.ChangeDock = True
        Me.pnlSpace11.Control_Resize = True
        Me.pnlSpace11.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace11.isSpace = True
        Me.pnlSpace11.Location = New System.Drawing.Point(190, 0)
        Me.pnlSpace11.Name = "pnlSpace11"
        Me.pnlSpace11.numRows = 0
        Me.pnlSpace11.Reorder = False
        Me.pnlSpace11.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace11.TabIndex = 3
        '
        'dtdVto2
        '
        Me.dtdVto2.Allow_Empty = True
        Me.dtdVto2.DataField = "VTO2_FAC"
        Me.dtdVto2.DataTable = "F"
        Me.dtdVto2.Default_Value = Nothing
        Me.dtdVto2.Descripcion = "Vencimiento 2"
        Me.dtdVto2.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtdVto2.FocoEnAgregar = False
        Me.dtdVto2.Label_Space = 100
        Me.dtdVto2.Location = New System.Drawing.Point(0, 0)
        Me.dtdVto2.Max_Value = Nothing
        Me.dtdVto2.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdVto2.MensajeIncorrectoCustom = Nothing
        Me.dtdVto2.Min_Value = Nothing
        Me.dtdVto2.MinDate = New Date(CType(0, Long))
        Me.dtdVto2.MinimumSize = New System.Drawing.Size(190, 26)
        Me.dtdVto2.Name = "dtdVto2"
        Me.dtdVto2.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdVto2.ReadOnly_Data = False
        Me.dtdVto2.Size = New System.Drawing.Size(190, 26)
        Me.dtdVto2.TabIndex = 1
        Me.dtdVto2.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdVto2.Validate_on_lost_focus = True
        Me.dtdVto2.Value_Data = Nothing
        '
        'pnlVto1
        '
        Me.pnlVto1.Auto_Size = False
        Me.pnlVto1.BackColor = System.Drawing.SystemColors.Control
        Me.pnlVto1.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlVto1.ChangeDock = False
        Me.pnlVto1.Control_Resize = False
        Me.pnlVto1.Controls.Add(Me.dtfImpVto1)
        Me.pnlVto1.Controls.Add(Me.pnlSpace9)
        Me.pnlVto1.Controls.Add(Me.lblGuion1)
        Me.pnlVto1.Controls.Add(Me.pnlSpace10)
        Me.pnlVto1.Controls.Add(Me.lblEur1)
        Me.pnlVto1.Controls.Add(Me.pnlSpace8)
        Me.pnlVto1.Controls.Add(Me.dtdVto1)
        Me.pnlVto1.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlVto1.isSpace = False
        Me.pnlVto1.Location = New System.Drawing.Point(6, 18)
        Me.pnlVto1.Name = "pnlVto1"
        Me.pnlVto1.numRows = 1
        Me.pnlVto1.Reorder = False
        Me.pnlVto1.Size = New System.Drawing.Size(373, 26)
        Me.pnlVto1.TabIndex = 0
        '
        'dtfImpVto1
        '
        Me.dtfImpVto1.Allow_Empty = True
        Me.dtfImpVto1.Allow_Negative = True
        Me.dtfImpVto1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfImpVto1.BackColor = System.Drawing.SystemColors.Control
        Me.dtfImpVto1.Data_Allowed = CustomControls.Datafield.List_Data.nDouble
        Me.dtfImpVto1.DataField = "IMP1_FAC"
        Me.dtfImpVto1.DataTable = "F"
        Me.dtfImpVto1.Descripcion = "Importe"
        Me.dtfImpVto1.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfImpVto1.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfImpVto1.FocoEnAgregar = False
        Me.dtfImpVto1.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfImpVto1.Image = Nothing
        Me.dtfImpVto1.Label_Space = 60
        Me.dtfImpVto1.Length_Data = 32767
        Me.dtfImpVto1.Location = New System.Drawing.Point(213, 0)
        Me.dtfImpVto1.Max_Value = 0R
        Me.dtfImpVto1.MensajeIncorrectoCustom = Nothing
        Me.dtfImpVto1.Name = "dtfImpVto1"
        Me.dtfImpVto1.Null_on_Empty = True
        Me.dtfImpVto1.OpenForm = Nothing
        Me.dtfImpVto1.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfImpVto1.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfImpVto1.ReadOnly_Data = False
        Me.dtfImpVto1.Show_Button = False
        Me.dtfImpVto1.Size = New System.Drawing.Size(141, 26)
        Me.dtfImpVto1.TabIndex = 2
        Me.dtfImpVto1.Text_Data = ""
        Me.dtfImpVto1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.dtfImpVto1.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfImpVto1.TopPadding = 0
        Me.dtfImpVto1.Upper_Case = False
        Me.dtfImpVto1.Validate_on_lost_focus = True
        '
        'pnlSpace9
        '
        Me.pnlSpace9.Auto_Size = False
        Me.pnlSpace9.BackColor = System.Drawing.SystemColors.Control
        Me.pnlSpace9.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace9.ChangeDock = True
        Me.pnlSpace9.Control_Resize = True
        Me.pnlSpace9.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace9.isSpace = True
        Me.pnlSpace9.Location = New System.Drawing.Point(207, 0)
        Me.pnlSpace9.Name = "pnlSpace9"
        Me.pnlSpace9.numRows = 0
        Me.pnlSpace9.Reorder = False
        Me.pnlSpace9.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace9.TabIndex = 7
        '
        'lblGuion1
        '
        Me.lblGuion1.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblGuion1.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblGuion1.Location = New System.Drawing.Point(196, 0)
        Me.lblGuion1.Name = "lblGuion1"
        Me.lblGuion1.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.lblGuion1.Size = New System.Drawing.Size(11, 26)
        Me.lblGuion1.TabIndex = 8
        Me.lblGuion1.Text = "-"
        '
        'pnlSpace10
        '
        Me.pnlSpace10.Auto_Size = False
        Me.pnlSpace10.BackColor = System.Drawing.SystemColors.Control
        Me.pnlSpace10.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace10.ChangeDock = True
        Me.pnlSpace10.Control_Resize = True
        Me.pnlSpace10.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSpace10.isSpace = True
        Me.pnlSpace10.Location = New System.Drawing.Point(354, 0)
        Me.pnlSpace10.Name = "pnlSpace10"
        Me.pnlSpace10.numRows = 0
        Me.pnlSpace10.Reorder = False
        Me.pnlSpace10.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace10.TabIndex = 6
        '
        'lblEur1
        '
        Me.lblEur1.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblEur1.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblEur1.Location = New System.Drawing.Point(360, 0)
        Me.lblEur1.Name = "lblEur1"
        Me.lblEur1.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.lblEur1.Size = New System.Drawing.Size(13, 26)
        Me.lblEur1.TabIndex = 5
        Me.lblEur1.Text = "€"
        '
        'pnlSpace8
        '
        Me.pnlSpace8.Auto_Size = False
        Me.pnlSpace8.BackColor = System.Drawing.SystemColors.Control
        Me.pnlSpace8.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace8.ChangeDock = True
        Me.pnlSpace8.Control_Resize = True
        Me.pnlSpace8.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace8.isSpace = True
        Me.pnlSpace8.Location = New System.Drawing.Point(190, 0)
        Me.pnlSpace8.Name = "pnlSpace8"
        Me.pnlSpace8.numRows = 0
        Me.pnlSpace8.Reorder = False
        Me.pnlSpace8.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace8.TabIndex = 3
        '
        'dtdVto1
        '
        Me.dtdVto1.Allow_Empty = False
        Me.dtdVto1.DataField = "VTO1_FAC"
        Me.dtdVto1.DataTable = "F"
        Me.dtdVto1.Default_Value = New Date(2015, 6, 12, 0, 0, 0, 0)
        Me.dtdVto1.Descripcion = "Vencimiento 1"
        Me.dtdVto1.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtdVto1.FocoEnAgregar = False
        Me.dtdVto1.Label_Space = 100
        Me.dtdVto1.Location = New System.Drawing.Point(0, 0)
        Me.dtdVto1.Max_Value = Nothing
        Me.dtdVto1.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdVto1.MensajeIncorrectoCustom = Nothing
        Me.dtdVto1.Min_Value = Nothing
        Me.dtdVto1.MinDate = New Date(CType(0, Long))
        Me.dtdVto1.MinimumSize = New System.Drawing.Size(190, 26)
        Me.dtdVto1.Name = "dtdVto1"
        Me.dtdVto1.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdVto1.ReadOnly_Data = False
        Me.dtdVto1.Size = New System.Drawing.Size(190, 26)
        Me.dtdVto1.TabIndex = 1
        Me.dtdVto1.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdVto1.Validate_on_lost_focus = True
        Me.dtdVto1.Value_Data = New Date(2015, 6, 12, 0, 0, 0, 0)
        '
        'Facturas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1073, 639)
        Me.Name = "Facturas"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Facturas"
        CType(Me.pnlBlock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pvwBase, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pvwBase.ResumeLayout(False)
        CType(Me.stbBase, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pvpCabezera.ResumeLayout(False)
        CType(Me.pnlLifacs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlLifacs.ResumeLayout(False)
        CType(Me.dgvLifacs.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvLifacs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlCabecera, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCabecera.ResumeLayout(False)
        CType(Me.pnlCabezeraDer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCabezeraDer.ResumeLayout(False)
        CType(Me.pnlPago, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPago.ResumeLayout(False)
        CType(Me.pnlReferencia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlReferencia.ResumeLayout(False)
        CType(Me.pnlSpace5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlIbanSwift, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlIbanSwift.ResumeLayout(False)
        CType(Me.pnlSpace4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlFormaPago, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFormaPago.ResumeLayout(False)
        CType(Me.pnlSpace3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnHideCabecera, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlCabezeraIzq, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCabezeraIzq.ResumeLayout(False)
        CType(Me.btnMotivoAbono, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlRectifica, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlRectifica.ResumeLayout(False)
        CType(Me.pnlEmpOfi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEmpOfi.ResumeLayout(False)
        CType(Me.pnlSpace2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlNumeroFecha, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlNumeroFecha.ResumeLayout(False)
        CType(Me.pnlSpace1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlPie, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPie.ResumeLayout(False)
        CType(Me.dgvBases.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvBases, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlTotales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTotales.ResumeLayout(False)
        CType(Me.btnHidePie, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlDtoPie, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDtoPie.ResumeLayout(False)
        Me.pnlDtoPie.PerformLayout()
        CType(Me.pnlSpace7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPorcen2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlDtoPP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDtoPP.ResumeLayout(False)
        Me.pnlDtoPP.PerformLayout()
        CType(Me.pnlSpace6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPorcen1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlDivisa, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDivisa.ResumeLayout(False)
        CType(Me.lblDivisa5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDivisa4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDivisa3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDivisa2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDivisa1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pvpOtrosDatos.ResumeLayout(False)
        CType(Me.pnlOtrosDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlOtrosDatos.ResumeLayout(False)
        CType(Me.gbxCliFac, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxCliFac.ResumeLayout(False)
        Me.gbxCliFac.PerformLayout()
        CType(Me.pnlNomNifCliFac, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlNomNifCliFac.ResumeLayout(False)
        CType(Me.Panel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlOtrosIzq, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlOtrosIzq.ResumeLayout(False)
        CType(Me.gbxVencimientos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxVencimientos.ResumeLayout(False)
        CType(Me.btnRecalcVtos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnResetVto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlVto10, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlVto10.ResumeLayout(False)
        Me.pnlVto10.PerformLayout()
        CType(Me.pnlSpace36, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblGuion10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSpace37, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblEur10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSpace35, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlVto9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlVto9.ResumeLayout(False)
        Me.pnlVto9.PerformLayout()
        CType(Me.pnlSpace33, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblGuion9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSpace34, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblEur9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSpace32, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlVto8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlVto8.ResumeLayout(False)
        Me.pnlVto8.PerformLayout()
        CType(Me.pnlSpace30, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblGuion8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSpace31, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblEur8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSpace29, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlVto7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlVto7.ResumeLayout(False)
        Me.pnlVto7.PerformLayout()
        CType(Me.pnlSpace27, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblGuion7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSpace28, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblEur7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSpace26, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlVto6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlVto6.ResumeLayout(False)
        Me.pnlVto6.PerformLayout()
        CType(Me.pnlSpace24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblGuion6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSpace25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblEur6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSpace23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlVto5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlVto5.ResumeLayout(False)
        Me.pnlVto5.PerformLayout()
        CType(Me.pnlSpace21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblGuion5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSpace22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblEur5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSpace20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlVto4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlVto4.ResumeLayout(False)
        Me.pnlVto4.PerformLayout()
        CType(Me.pnlSpace18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblGuion4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSpace19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblEur4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSpace17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlVto3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlVto3.ResumeLayout(False)
        Me.pnlVto3.PerformLayout()
        CType(Me.pnlSpace15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblGuion3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSpace16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblEur3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSpace14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlVto2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlVto2.ResumeLayout(False)
        Me.pnlVto2.PerformLayout()
        CType(Me.pnlSpace12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblGuion2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSpace13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblEur2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSpace11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlVto1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlVto1.ResumeLayout(False)
        Me.pnlVto1.PerformLayout()
        CType(Me.pnlSpace9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblGuion1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSpace10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblEur1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSpace8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pvpCabezera As CustomControls.PageViewPage
    Friend WithEvents pnlCabecera As CustomControls.Panel
    Friend WithEvents pnlCabezeraIzq As CustomControls.Panel
    Friend WithEvents pnlCabezeraDer As CustomControls.Panel
    Friend WithEvents dtfNumero As CustomControls.DatafieldLabel
    Friend WithEvents dtdFefchaFac As CustomControls.DataDateLabel
    Friend WithEvents pnlEmpOfi As CustomControls.Panel
    Friend WithEvents dtfOficina As CustomControls.DualDatafieldLabel
    Friend WithEvents pnlSpace2 As CustomControls.Panel
    Friend WithEvents dtfEmpresa As CustomControls.DualDatafieldLabel
    Friend WithEvents pnlNumeroFecha As CustomControls.Panel
    Friend WithEvents pnlSpace1 As CustomControls.Panel
    Friend WithEvents dtfTipoImpreso As CustomControls.DualDatafieldLabel
    Friend WithEvents dtfOrigen As CustomControls.DualDatafieldLabel
    Friend WithEvents dtfDepartamento As CustomControls.DualDatafieldLabel
    Friend WithEvents dtfCliente As CustomControls.DualDatafieldLabel
    Friend WithEvents dtfPersona As CustomControls.DatafieldLabel
    Friend WithEvents dtfDelegacion As CustomControls.DualDatafieldLabel
    Friend WithEvents dtfVendedor As CustomControls.DualDatafieldLabel
    Friend WithEvents pnlPago As CustomControls.Panel
    Friend WithEvents pnlFormaPago As CustomControls.Panel
    Friend WithEvents dtfFormaPago As CustomControls.DualDatafieldLabel
    Friend WithEvents pnlSpace3 As CustomControls.Panel
    Friend WithEvents dtdVencimiento As CustomControls.DataDateLabel
    Friend WithEvents pnlIbanSwift As CustomControls.Panel
    Friend WithEvents dtfIban As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace4 As CustomControls.Panel
    Friend WithEvents dtfSwift As CustomControls.DatafieldLabel
    Friend WithEvents pnlReferencia As CustomControls.Panel
    Friend WithEvents dtfReferencia As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace5 As CustomControls.Panel
    Friend WithEvents TelerikMetroBlueTheme1 As Telerik.WinControls.Themes.TelerikMetroBlueTheme
    Friend WithEvents btnHideCabecera As CustomControls.Button
    Friend WithEvents dgvLifacs As Karve.frm.Facturas.GridLiFacs
    Friend WithEvents dgvBases As Karve.frm.Facturas.GridBasesFac
    Friend WithEvents dtfAsiento As CustomControls.DatafieldLabel
    Friend WithEvents pnlRectifica As CustomControls.Panel
    Friend WithEvents dtfFacRectifPor As CustomControls.DatafieldLabel
    Friend WithEvents dtfAbonoDeFac As CustomControls.DatafieldLabel
    Friend WithEvents dtfExtra As CustomControls.DualDatafieldLabel
    Friend WithEvents btnMotivoAbono As CustomControls.Button
    Friend WithEvents pvpOtrosDatos As CustomControls.PageViewPage
    Friend WithEvents pnlPie As CustomControls.Panel
    Friend WithEvents pnlTotales As CustomControls.Panel
    Friend WithEvents dtfBaseSin As CustomControls.DatafieldLabel
    Friend WithEvents dtfTotalFac As CustomControls.DatafieldLabel
    Friend WithEvents pnlDtoPP As CustomControls.Panel
    Friend WithEvents pnlSpace6 As CustomControls.Panel
    Friend WithEvents lblPorcen1 As CustomControls.Label
    Friend WithEvents dtfDtoPP As CustomControls.DatafieldLabel
    Friend WithEvents pnlDtoPie As CustomControls.Panel
    Friend WithEvents dtfImpDtoPie As CustomControls.Datafield
    Friend WithEvents pnlSpace7 As CustomControls.Panel
    Friend WithEvents lblPorcen2 As CustomControls.Label
    Friend WithEvents dtfDtoPie As CustomControls.DatafieldLabel
    Friend WithEvents dtfImpDtoPP As CustomControls.Datafield
    Friend WithEvents dtfBrutoFac As CustomControls.DatafieldLabel
    Friend WithEvents pnlDivisa As CustomControls.Panel
    Friend WithEvents lblDivisa5 As CustomControls.Label
    Friend WithEvents lblDivisa4 As CustomControls.Label
    Friend WithEvents lblDivisa3 As CustomControls.Label
    Friend WithEvents lblDivisa2 As CustomControls.Label
    Friend WithEvents lblDivisa1 As CustomControls.Label
    Friend WithEvents btnHidePie As CustomControls.Button
    Friend WithEvents pnlOtrosDatos As CustomControls.Panel
    Friend WithEvents gbxVencimientos As CustomControls.GroupBox
    Friend WithEvents pnlVto1 As CustomControls.Panel
    Friend WithEvents dtfImpVto1 As CustomControls.DatafieldLabel
    Friend WithEvents lblEur1 As CustomControls.Label
    Friend WithEvents pnlSpace8 As CustomControls.Panel
    Friend WithEvents dtdVto1 As CustomControls.DataDateLabel
    Friend WithEvents pnlSpace10 As CustomControls.Panel
    Friend WithEvents pnlVto9 As CustomControls.Panel
    Friend WithEvents dtfImpVto9 As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace33 As CustomControls.Panel
    Friend WithEvents lblGuion9 As CustomControls.Label
    Friend WithEvents pnlSpace34 As CustomControls.Panel
    Friend WithEvents lblEur9 As CustomControls.Label
    Friend WithEvents pnlSpace32 As CustomControls.Panel
    Friend WithEvents dtdVto9 As CustomControls.DataDateLabel
    Friend WithEvents pnlVto8 As CustomControls.Panel
    Friend WithEvents dtfImpVto8 As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace30 As CustomControls.Panel
    Friend WithEvents lblGuion8 As CustomControls.Label
    Friend WithEvents pnlSpace31 As CustomControls.Panel
    Friend WithEvents lblEur8 As CustomControls.Label
    Friend WithEvents pnlSpace29 As CustomControls.Panel
    Friend WithEvents dtdVto8 As CustomControls.DataDateLabel
    Friend WithEvents pnlVto7 As CustomControls.Panel
    Friend WithEvents dtfImpVto7 As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace27 As CustomControls.Panel
    Friend WithEvents lblGuion7 As CustomControls.Label
    Friend WithEvents pnlSpace28 As CustomControls.Panel
    Friend WithEvents lblEur7 As CustomControls.Label
    Friend WithEvents pnlSpace26 As CustomControls.Panel
    Friend WithEvents dtdVto7 As CustomControls.DataDateLabel
    Friend WithEvents pnlVto6 As CustomControls.Panel
    Friend WithEvents dtfImpVto6 As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace24 As CustomControls.Panel
    Friend WithEvents lblGuion6 As CustomControls.Label
    Friend WithEvents pnlSpace25 As CustomControls.Panel
    Friend WithEvents lblEur6 As CustomControls.Label
    Friend WithEvents pnlSpace23 As CustomControls.Panel
    Friend WithEvents dtdVto6 As CustomControls.DataDateLabel
    Friend WithEvents pnlVto5 As CustomControls.Panel
    Friend WithEvents dtfImpVto5 As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace21 As CustomControls.Panel
    Friend WithEvents lblGuion5 As CustomControls.Label
    Friend WithEvents pnlSpace22 As CustomControls.Panel
    Friend WithEvents lblEur5 As CustomControls.Label
    Friend WithEvents pnlSpace20 As CustomControls.Panel
    Friend WithEvents dtdVto5 As CustomControls.DataDateLabel
    Friend WithEvents pnlVto4 As CustomControls.Panel
    Friend WithEvents dtfImpVto4 As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace18 As CustomControls.Panel
    Friend WithEvents lblGuion4 As CustomControls.Label
    Friend WithEvents pnlSpace19 As CustomControls.Panel
    Friend WithEvents lblEur4 As CustomControls.Label
    Friend WithEvents pnlSpace17 As CustomControls.Panel
    Friend WithEvents dtdVto4 As CustomControls.DataDateLabel
    Friend WithEvents pnlVto3 As CustomControls.Panel
    Friend WithEvents dtfImpVto3 As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace15 As CustomControls.Panel
    Friend WithEvents lblGuion3 As CustomControls.Label
    Friend WithEvents pnlSpace16 As CustomControls.Panel
    Friend WithEvents lblEur3 As CustomControls.Label
    Friend WithEvents pnlSpace14 As CustomControls.Panel
    Friend WithEvents dtdVto3 As CustomControls.DataDateLabel
    Friend WithEvents pnlVto2 As CustomControls.Panel
    Friend WithEvents dtfImpVto2 As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace12 As CustomControls.Panel
    Friend WithEvents lblGuion2 As CustomControls.Label
    Friend WithEvents pnlSpace13 As CustomControls.Panel
    Friend WithEvents lblEur2 As CustomControls.Label
    Friend WithEvents pnlSpace11 As CustomControls.Panel
    Friend WithEvents dtdVto2 As CustomControls.DataDateLabel
    Friend WithEvents pnlSpace9 As CustomControls.Panel
    Friend WithEvents lblGuion1 As CustomControls.Label
    Friend WithEvents pnlVto10 As CustomControls.Panel
    Friend WithEvents dtfImpVto10 As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace36 As CustomControls.Panel
    Friend WithEvents lblGuion10 As CustomControls.Label
    Friend WithEvents pnlSpace37 As CustomControls.Panel
    Friend WithEvents lblEur10 As CustomControls.Label
    Friend WithEvents pnlSpace35 As CustomControls.Panel
    Friend WithEvents dtdVto10 As CustomControls.DataDateLabel
    Friend WithEvents btnRecalcVtos As CustomControls.Button
    Friend WithEvents btnResetVto As CustomControls.Button
    Friend WithEvents gbxCliFac As CustomControls.GroupBox
    Friend WithEvents dirCliFac As CustomControls.DataDir
    Friend WithEvents pnlNomNifCliFac As CustomControls.Panel
    Friend WithEvents dtfNombreCliFac As CustomControls.DatafieldLabel
    Friend WithEvents Panel1 As CustomControls.Panel
    Friend WithEvents dtfNIFCliFac As CustomControls.DatafieldLabel
    Friend WithEvents pnlOtrosIzq As CustomControls.Panel
    Friend WithEvents pnlLifacs As CustomControls.Panel
End Class
