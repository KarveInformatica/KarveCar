<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MarcasVehiculo
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
        Me.pvpGeneral = New CustomControls.PageViewPage()
        Me.pnlPpal = New CustomControls.Panel()
        Me.gbxProveedor = New CustomControls.GroupBox()
        Me.dtaObs = New CustomControls.DataAreaLabel()
        Me.pnlFecha = New CustomControls.Panel()
        Me.dtdFecha = New CustomControls.DataDateLabel()
        Me.dtfInterlocutor = New CustomControls.DatafieldLabel()
        Me.dtfPactadas = New CustomControls.DatafieldLabel()
        Me.dtaCondiciones = New CustomControls.DataAreaLabel()
        Me.dtfProvee = New CustomControls.DualDatafieldLabel()
        Me.pnlFaltaFbaja = New CustomControls.Panel()
        Me.dtdFBaja = New CustomControls.DataDateLabel()
        Me.pnlBottomGen = New CustomControls.Panel()
        Me.dtlUltmodi = New CustomControls.DataLabel()
        Me.dtlUsumodi = New CustomControls.DataLabel()
        Me.dtfNombre = New CustomControls.DatafieldLabel()
        Me.pnlCodigo = New CustomControls.Panel()
        Me.dtfCodigo = New CustomControls.DatafieldLabel()
        CType(Me.pnlBlock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pvwBase, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pvwBase.SuspendLayout()
        CType(Me.stbBase, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pvpGeneral.SuspendLayout()
        CType(Me.pnlPpal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPpal.SuspendLayout()
        CType(Me.gbxProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxProveedor.SuspendLayout()
        CType(Me.pnlFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFecha.SuspendLayout()
        CType(Me.pnlFaltaFbaja, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFaltaFbaja.SuspendLayout()
        CType(Me.pnlBottomGen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBottomGen.SuspendLayout()
        CType(Me.dtlUltmodi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtlUsumodi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlCodigo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCodigo.SuspendLayout()
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
        Me.pnlBlock.Location = New System.Drawing.Point(0, 456)
        '
        'pvwBase
        '
        Me.pvwBase.Controls.Add(Me.pvpGeneral)
        Me.pvwBase.SelectedPage = Me.pvpGeneral
        Me.pvwBase.Size = New System.Drawing.Size(1016, 552)
        '
        'rbgEdicion
        '
        Me.rbgEdicion.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.rbgEdicion.Bounds = New System.Drawing.Rectangle(0, 0, 246, 96)
        Me.rbgEdicion.ForeColor = System.Drawing.Color.Black
        '
        'stbBase
        '
        Me.stbBase.Location = New System.Drawing.Point(0, 552)
        '
        'pvpGeneral
        '
        Me.pvpGeneral.Controls.Add(Me.pnlPpal)
        Me.pvpGeneral.ItemSize = New System.Drawing.SizeF(51.0!, 24.0!)
        Me.pvpGeneral.Location = New System.Drawing.Point(129, 5)
        Me.pvpGeneral.Name = "pvpGeneral"
        Me.pvpGeneral.Size = New System.Drawing.Size(882, 542)
        Me.pvpGeneral.Text = "General"
        '
        'pnlPpal
        '
        Me.pnlPpal.Auto_Size = False
        Me.pnlPpal.BackColor = System.Drawing.SystemColors.Control
        Me.pnlPpal.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlPpal.ChangeDock = True
        Me.pnlPpal.Control_Resize = False
        Me.pnlPpal.Controls.Add(Me.gbxProveedor)
        Me.pnlPpal.Controls.Add(Me.pnlFaltaFbaja)
        Me.pnlPpal.Controls.Add(Me.pnlBottomGen)
        Me.pnlPpal.Controls.Add(Me.dtfNombre)
        Me.pnlPpal.Controls.Add(Me.pnlCodigo)
        Me.pnlPpal.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlPpal.isSpace = False
        Me.pnlPpal.Location = New System.Drawing.Point(0, 0)
        Me.pnlPpal.Name = "pnlPpal"
        Me.pnlPpal.numRows = 0
        Me.pnlPpal.Padding = New System.Windows.Forms.Padding(5)
        Me.pnlPpal.Reorder = True
        Me.pnlPpal.Size = New System.Drawing.Size(882, 528)
        Me.pnlPpal.TabIndex = 11
        '
        'gbxProveedor
        '
        Me.gbxProveedor.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.gbxProveedor.Controls.Add(Me.dtaObs)
        Me.gbxProveedor.Controls.Add(Me.pnlFecha)
        Me.gbxProveedor.Controls.Add(Me.dtfInterlocutor)
        Me.gbxProveedor.Controls.Add(Me.dtfPactadas)
        Me.gbxProveedor.Controls.Add(Me.dtaCondiciones)
        Me.gbxProveedor.Controls.Add(Me.dtfProvee)
        Me.gbxProveedor.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbxProveedor.HeaderText = "Proveedor"
        Me.gbxProveedor.Location = New System.Drawing.Point(5, 87)
        Me.gbxProveedor.Name = "gbxProveedor"
        Me.gbxProveedor.numRows = 0
        Me.gbxProveedor.Padding = New System.Windows.Forms.Padding(6, 18, 6, 6)
        Me.gbxProveedor.Reorder = True
        Me.gbxProveedor.Size = New System.Drawing.Size(872, 404)
        Me.gbxProveedor.TabIndex = 3
        Me.gbxProveedor.Text = "Proveedor"
        Me.gbxProveedor.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.gbxProveedor.ThemeName = "Windows8"
        Me.gbxProveedor.Title = "Proveedor"
        '
        'dtaObs
        '
        Me.dtaObs.Allow_Empty = True
        Me.dtaObs.Allow_Negative = True
        Me.dtaObs.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtaObs.BackColor = System.Drawing.SystemColors.Control
        Me.dtaObs.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtaObs.DataField = "OBS"
        Me.dtaObs.DataTable = "MAR"
        Me.dtaObs.Descripcion = "Observaciones"
        Me.dtaObs.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtaObs.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtaObs.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtaObs.Length_Data = 32767
        Me.dtaObs.Location = New System.Drawing.Point(6, 252)
        Me.dtaObs.Max_Value = 0.0R
        Me.dtaObs.MensajeIncorrectoCustom = Nothing
        Me.dtaObs.Name = "dtaObs"
        Me.dtaObs.Null_on_Empty = True
        Me.dtaObs.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtaObs.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtaObs.ReadOnly_Data = False
        Me.dtaObs.Size = New System.Drawing.Size(860, 143)
        Me.dtaObs.TabIndex = 5
        Me.dtaObs.Text_Data = ""
        Me.dtaObs.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtaObs.TopPadding = 0
        Me.dtaObs.Upper_Case = False
        Me.dtaObs.Validate_on_lost_focus = True
        '
        'pnlFecha
        '
        Me.pnlFecha.Auto_Size = False
        Me.pnlFecha.BackColor = System.Drawing.SystemColors.Control
        Me.pnlFecha.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlFecha.ChangeDock = True
        Me.pnlFecha.Control_Resize = False
        Me.pnlFecha.Controls.Add(Me.dtdFecha)
        Me.pnlFecha.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFecha.isSpace = False
        Me.pnlFecha.Location = New System.Drawing.Point(6, 226)
        Me.pnlFecha.Name = "pnlFecha"
        Me.pnlFecha.numRows = 1
        Me.pnlFecha.Reorder = True
        Me.pnlFecha.Size = New System.Drawing.Size(860, 26)
        Me.pnlFecha.TabIndex = 4
        '
        'dtdFecha
        '
        Me.dtdFecha.Allow_Empty = True
        Me.dtdFecha.DataField = "FECHA"
        Me.dtdFecha.DataTable = "MAR"
        Me.dtdFecha.Default_Value = Nothing
        Me.dtdFecha.Descripcion = "En Fecha"
        Me.dtdFecha.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtdFecha.Label_Space = 75
        Me.dtdFecha.Location = New System.Drawing.Point(0, 0)
        Me.dtdFecha.Max_Value = Nothing
        Me.dtdFecha.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdFecha.MensajeIncorrectoCustom = Nothing
        Me.dtdFecha.Min_Value = Nothing
        Me.dtdFecha.MinDate = New Date(CType(0, Long))
        Me.dtdFecha.MinimumSize = New System.Drawing.Size(165, 26)
        Me.dtdFecha.Name = "dtdFecha"
        Me.dtdFecha.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdFecha.ReadOnly_Data = False
        Me.dtdFecha.Size = New System.Drawing.Size(166, 26)
        Me.dtdFecha.TabIndex = 0
        Me.dtdFecha.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdFecha.Validate_on_lost_focus = True
        Me.dtdFecha.Value_Data = Nothing
        '
        'dtfInterlocutor
        '
        Me.dtfInterlocutor.Allow_Empty = True
        Me.dtfInterlocutor.Allow_Negative = True
        Me.dtfInterlocutor.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfInterlocutor.BackColor = System.Drawing.SystemColors.Control
        Me.dtfInterlocutor.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfInterlocutor.DataField = "LOCUTOR"
        Me.dtfInterlocutor.DataTable = "MAR"
        Me.dtfInterlocutor.Descripcion = "Interlocutor"
        Me.dtfInterlocutor.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfInterlocutor.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfInterlocutor.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfInterlocutor.Image = Nothing
        Me.dtfInterlocutor.Label_Space = 75
        Me.dtfInterlocutor.Length_Data = 32767
        Me.dtfInterlocutor.Location = New System.Drawing.Point(6, 200)
        Me.dtfInterlocutor.Max_Value = 0.0R
        Me.dtfInterlocutor.MensajeIncorrectoCustom = Nothing
        Me.dtfInterlocutor.Name = "dtfInterlocutor"
        Me.dtfInterlocutor.Null_on_Empty = True
        Me.dtfInterlocutor.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfInterlocutor.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfInterlocutor.ReadOnly_Data = False
        Me.dtfInterlocutor.Show_Button = False
        Me.dtfInterlocutor.Size = New System.Drawing.Size(860, 26)
        Me.dtfInterlocutor.TabIndex = 3
        Me.dtfInterlocutor.Text_Data = ""
        Me.dtfInterlocutor.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfInterlocutor.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfInterlocutor.TopPadding = 0
        Me.dtfInterlocutor.Upper_Case = False
        Me.dtfInterlocutor.Validate_on_lost_focus = True
        '
        'dtfPactadas
        '
        Me.dtfPactadas.Allow_Empty = True
        Me.dtfPactadas.Allow_Negative = True
        Me.dtfPactadas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfPactadas.BackColor = System.Drawing.SystemColors.Control
        Me.dtfPactadas.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfPactadas.DataField = "PACTADAS"
        Me.dtfPactadas.DataTable = "MAR"
        Me.dtfPactadas.Descripcion = "Pactadas Con"
        Me.dtfPactadas.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfPactadas.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfPactadas.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfPactadas.Image = Nothing
        Me.dtfPactadas.Label_Space = 100
        Me.dtfPactadas.Length_Data = 32767
        Me.dtfPactadas.Location = New System.Drawing.Point(6, 174)
        Me.dtfPactadas.Max_Value = 0.0R
        Me.dtfPactadas.MensajeIncorrectoCustom = Nothing
        Me.dtfPactadas.Name = "dtfPactadas"
        Me.dtfPactadas.Null_on_Empty = True
        Me.dtfPactadas.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfPactadas.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfPactadas.ReadOnly_Data = False
        Me.dtfPactadas.Show_Button = False
        Me.dtfPactadas.Size = New System.Drawing.Size(860, 26)
        Me.dtfPactadas.TabIndex = 2
        Me.dtfPactadas.Text_Data = ""
        Me.dtfPactadas.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfPactadas.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfPactadas.TopPadding = 0
        Me.dtfPactadas.Upper_Case = False
        Me.dtfPactadas.Validate_on_lost_focus = True
        '
        'dtaCondiciones
        '
        Me.dtaCondiciones.Allow_Empty = True
        Me.dtaCondiciones.Allow_Negative = True
        Me.dtaCondiciones.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtaCondiciones.BackColor = System.Drawing.SystemColors.Control
        Me.dtaCondiciones.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtaCondiciones.DataField = "CONDICIONES"
        Me.dtaCondiciones.DataTable = "MAR"
        Me.dtaCondiciones.Descripcion = "Condiciones Generales"
        Me.dtaCondiciones.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtaCondiciones.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtaCondiciones.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtaCondiciones.Length_Data = 32767
        Me.dtaCondiciones.Location = New System.Drawing.Point(6, 44)
        Me.dtaCondiciones.Max_Value = 0.0R
        Me.dtaCondiciones.MensajeIncorrectoCustom = Nothing
        Me.dtaCondiciones.Name = "dtaCondiciones"
        Me.dtaCondiciones.Null_on_Empty = True
        Me.dtaCondiciones.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtaCondiciones.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtaCondiciones.ReadOnly_Data = False
        Me.dtaCondiciones.Size = New System.Drawing.Size(860, 130)
        Me.dtaCondiciones.TabIndex = 1
        Me.dtaCondiciones.Text_Data = ""
        Me.dtaCondiciones.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtaCondiciones.TopPadding = 0
        Me.dtaCondiciones.Upper_Case = False
        Me.dtaCondiciones.Validate_on_lost_focus = True
        '
        'dtfProvee
        '
        Me.dtfProvee.Allow_Empty = True
        Me.dtfProvee.Allow_Negative = True
        Me.dtfProvee.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfProvee.BackColor = System.Drawing.SystemColors.Control
        Me.dtfProvee.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfProvee.DataField = "PROVEE"
        Me.dtfProvee.DataTable = "MAR"
        Me.dtfProvee.Desc_Datafield = "NOMBRE"
        Me.dtfProvee.Desc_DBPK = "NUM_PROVEE"
        Me.dtfProvee.Desc_DBTable = "PROVEE1"
        Me.dtfProvee.Desc_Where = Nothing
        Me.dtfProvee.Descripcion = "Proveedor"
        Me.dtfProvee.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfProvee.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfProvee.ExtraSQL = ""
        Me.dtfProvee.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfProvee.Formulario = Nothing
        Me.dtfProvee.Label_Space = 75
        Me.dtfProvee.Length_Data = 32767
        Me.dtfProvee.Location = New System.Drawing.Point(6, 18)
        Me.dtfProvee.Lupa = Nothing
        Me.dtfProvee.Max_Value = 0.0R
        Me.dtfProvee.MensajeIncorrectoCustom = Nothing
        Me.dtfProvee.Name = "dtfProvee"
        Me.dtfProvee.Null_on_Empty = True
        Me.dtfProvee.OpenForm = Nothing
        Me.dtfProvee.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfProvee.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfProvee.Query_on_Text_Changed = True
        Me.dtfProvee.ReadOnly_Data = False
        Me.dtfProvee.ShowButton = True
        Me.dtfProvee.Size = New System.Drawing.Size(860, 26)
        Me.dtfProvee.TabIndex = 0
        Me.dtfProvee.Text_Data = ""
        Me.dtfProvee.Text_Width = 58
        Me.dtfProvee.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfProvee.TopPadding = 0
        Me.dtfProvee.Upper_Case = False
        Me.dtfProvee.Validate_on_lost_focus = True
        '
        'pnlFaltaFbaja
        '
        Me.pnlFaltaFbaja.Auto_Size = False
        Me.pnlFaltaFbaja.BackColor = System.Drawing.SystemColors.Control
        Me.pnlFaltaFbaja.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlFaltaFbaja.ChangeDock = True
        Me.pnlFaltaFbaja.Control_Resize = False
        Me.pnlFaltaFbaja.Controls.Add(Me.dtdFBaja)
        Me.pnlFaltaFbaja.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFaltaFbaja.isSpace = False
        Me.pnlFaltaFbaja.Location = New System.Drawing.Point(5, 61)
        Me.pnlFaltaFbaja.Name = "pnlFaltaFbaja"
        Me.pnlFaltaFbaja.numRows = 1
        Me.pnlFaltaFbaja.Reorder = True
        Me.pnlFaltaFbaja.Size = New System.Drawing.Size(872, 26)
        Me.pnlFaltaFbaja.TabIndex = 2
        '
        'dtdFBaja
        '
        Me.dtdFBaja.Allow_Empty = True
        Me.dtdFBaja.DataField = "FBAJA"
        Me.dtdFBaja.DataTable = "MAR"
        Me.dtdFBaja.Default_Value = Nothing
        Me.dtdFBaja.Descripcion = "Fecha Baja"
        Me.dtdFBaja.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtdFBaja.Label_Space = 75
        Me.dtdFBaja.Location = New System.Drawing.Point(0, 0)
        Me.dtdFBaja.Max_Value = Nothing
        Me.dtdFBaja.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdFBaja.MensajeIncorrectoCustom = Nothing
        Me.dtdFBaja.Min_Value = Nothing
        Me.dtdFBaja.MinDate = New Date(CType(0, Long))
        Me.dtdFBaja.MinimumSize = New System.Drawing.Size(165, 26)
        Me.dtdFBaja.Name = "dtdFBaja"
        Me.dtdFBaja.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdFBaja.ReadOnly_Data = False
        Me.dtdFBaja.Size = New System.Drawing.Size(166, 26)
        Me.dtdFBaja.TabIndex = 0
        Me.dtdFBaja.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdFBaja.Validate_on_lost_focus = True
        Me.dtdFBaja.Value_Data = Nothing
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
        Me.pnlBottomGen.Location = New System.Drawing.Point(5, 497)
        Me.pnlBottomGen.Name = "pnlBottomGen"
        Me.pnlBottomGen.numRows = 1
        Me.pnlBottomGen.Reorder = True
        Me.pnlBottomGen.Size = New System.Drawing.Size(872, 26)
        Me.pnlBottomGen.TabIndex = 4
        '
        'dtlUltmodi
        '
        Me.dtlUltmodi.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtlUltmodi.AutoSize = False
        Me.dtlUltmodi.BorderVisible = True
        Me.dtlUltmodi.DataField = "ULTMODI"
        Me.dtlUltmodi.DataTable = "MAR"
        Me.dtlUltmodi.Descripcion = ""
        Me.dtlUltmodi.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtlUltmodi.Fromat = CustomControls.DataLabel.fotmatType.ultmodi
        Me.dtlUltmodi.Location = New System.Drawing.Point(740, 6)
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
        Me.dtlUsumodi.DataTable = "MAR"
        Me.dtlUsumodi.Descripcion = ""
        Me.dtlUsumodi.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtlUsumodi.Fromat = CustomControls.DataLabel.fotmatType.plain
        Me.dtlUsumodi.Location = New System.Drawing.Point(696, 6)
        Me.dtlUsumodi.Name = "dtlUsumodi"
        Me.dtlUsumodi.Size = New System.Drawing.Size(38, 17)
        Me.dtlUsumodi.TabIndex = 0
        Me.dtlUsumodi.TextAlignment = System.Drawing.ContentAlignment.TopCenter
        '
        'dtfNombre
        '
        Me.dtfNombre.Allow_Empty = False
        Me.dtfNombre.Allow_Negative = True
        Me.dtfNombre.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfNombre.BackColor = System.Drawing.SystemColors.Control
        Me.dtfNombre.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfNombre.DataField = "NOMBRE"
        Me.dtfNombre.DataTable = "MAR"
        Me.dtfNombre.Descripcion = "Nombre"
        Me.dtfNombre.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfNombre.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfNombre.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfNombre.Image = Nothing
        Me.dtfNombre.Label_Space = 75
        Me.dtfNombre.Length_Data = 32767
        Me.dtfNombre.Location = New System.Drawing.Point(5, 35)
        Me.dtfNombre.Max_Value = 0.0R
        Me.dtfNombre.MensajeIncorrectoCustom = Nothing
        Me.dtfNombre.Name = "dtfNombre"
        Me.dtfNombre.Null_on_Empty = True
        Me.dtfNombre.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfNombre.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfNombre.ReadOnly_Data = False
        Me.dtfNombre.Show_Button = False
        Me.dtfNombre.Size = New System.Drawing.Size(872, 26)
        Me.dtfNombre.TabIndex = 1
        Me.dtfNombre.Text_Data = ""
        Me.dtfNombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfNombre.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfNombre.TopPadding = 0
        Me.dtfNombre.Upper_Case = False
        Me.dtfNombre.Validate_on_lost_focus = True
        '
        'pnlCodigo
        '
        Me.pnlCodigo.Auto_Size = False
        Me.pnlCodigo.BackColor = System.Drawing.SystemColors.Control
        Me.pnlCodigo.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlCodigo.ChangeDock = True
        Me.pnlCodigo.Control_Resize = False
        Me.pnlCodigo.Controls.Add(Me.dtfCodigo)
        Me.pnlCodigo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCodigo.isSpace = False
        Me.pnlCodigo.Location = New System.Drawing.Point(5, 5)
        Me.pnlCodigo.Name = "pnlCodigo"
        Me.pnlCodigo.numRows = 0
        Me.pnlCodigo.Padding = New System.Windows.Forms.Padding(0, 5, 5, 5)
        Me.pnlCodigo.Reorder = True
        Me.pnlCodigo.Size = New System.Drawing.Size(872, 30)
        Me.pnlCodigo.TabIndex = 0
        '
        'dtfCodigo
        '
        Me.dtfCodigo.Allow_Empty = False
        Me.dtfCodigo.Allow_Negative = True
        Me.dtfCodigo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfCodigo.BackColor = System.Drawing.SystemColors.Control
        Me.dtfCodigo.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfCodigo.DataField = "CODIGO"
        Me.dtfCodigo.DataTable = "MAR"
        Me.dtfCodigo.Descripcion = "Código"
        Me.dtfCodigo.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfCodigo.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfCodigo.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfCodigo.Image = Nothing
        Me.dtfCodigo.Label_Space = 75
        Me.dtfCodigo.Length_Data = 32767
        Me.dtfCodigo.Location = New System.Drawing.Point(0, 5)
        Me.dtfCodigo.Max_Value = 0.0R
        Me.dtfCodigo.MensajeIncorrectoCustom = Nothing
        Me.dtfCodigo.Name = "dtfCodigo"
        Me.dtfCodigo.Null_on_Empty = True
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
        'MarcasVehiculo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1016, 737)
        Me.Name = "MarcasVehiculo"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "MarcasVehiculo"
        CType(Me.pnlBlock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pvwBase, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pvwBase.ResumeLayout(False)
        CType(Me.stbBase, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pvpGeneral.ResumeLayout(False)
        CType(Me.pnlPpal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPpal.ResumeLayout(False)
        CType(Me.gbxProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxProveedor.ResumeLayout(False)
        CType(Me.pnlFecha, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFecha.ResumeLayout(False)
        CType(Me.pnlFaltaFbaja, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFaltaFbaja.ResumeLayout(False)
        CType(Me.pnlBottomGen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBottomGen.ResumeLayout(False)
        CType(Me.dtlUltmodi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtlUsumodi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlCodigo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCodigo.ResumeLayout(False)
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pvpGeneral As CustomControls.PageViewPage
    Friend WithEvents pnlPpal As CustomControls.Panel
    Friend WithEvents pnlBottomGen As CustomControls.Panel
    Friend WithEvents dtlUltmodi As CustomControls.DataLabel
    Friend WithEvents dtlUsumodi As CustomControls.DataLabel
    Friend WithEvents dtfNombre As CustomControls.DatafieldLabel
    Friend WithEvents pnlCodigo As CustomControls.Panel
    Friend WithEvents dtfCodigo As CustomControls.DatafieldLabel
    Friend WithEvents pnlFaltaFbaja As CustomControls.Panel
    Friend WithEvents dtdFBaja As CustomControls.DataDateLabel
    Friend WithEvents gbxProveedor As CustomControls.GroupBox
    Friend WithEvents dtfProvee As CustomControls.DualDatafieldLabel
    Friend WithEvents dtaObs As CustomControls.DataAreaLabel
    Friend WithEvents pnlFecha As CustomControls.Panel
    Friend WithEvents dtdFecha As CustomControls.DataDateLabel
    Friend WithEvents dtfInterlocutor As CustomControls.DatafieldLabel
    Friend WithEvents dtfPactadas As CustomControls.DatafieldLabel
    Friend WithEvents dtaCondiciones As CustomControls.DataAreaLabel
End Class
