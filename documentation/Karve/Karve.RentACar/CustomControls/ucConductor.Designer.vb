<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucConductor
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
        Me.SuspendLayout()
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
        Me.gbxConductor.Location = New System.Drawing.Point(0, 0)
        Me.gbxConductor.Name = "gbxConductor"
        Me.gbxConductor.numRows = 13
        Me.gbxConductor.Padding = New System.Windows.Forms.Padding(6, 18, 6, 6)
        Me.gbxConductor.Reorder = True
        Me.gbxConductor.Size = New System.Drawing.Size(571, 358)
        Me.gbxConductor.TabIndex = 1
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
        Me.pnlTarjeta.Size = New System.Drawing.Size(559, 26)
        Me.pnlTarjeta.TabIndex = 8
        '
        'dtfTarNum
        '
        Me.dtfTarNum.Allow_Empty = True
        Me.dtfTarNum.Allow_Negative = True
        Me.dtfTarNum.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfTarNum.BackColor = System.Drawing.SystemColors.Control
        Me.dtfTarNum.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfTarNum.DataField = "TARUM"
        Me.dtfTarNum.DataTable = ""
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
        Me.dtfTarNum.Size = New System.Drawing.Size(400, 26)
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
        Me.pnlSpace31.Location = New System.Drawing.Point(400, 0)
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
        Me.lblTarCadu.Location = New System.Drawing.Point(406, 0)
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
        Me.pnlSpace30.Location = New System.Drawing.Point(508, 0)
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
        Me.mdfTarcadu.DataField = "TARCADU"
        Me.mdfTarcadu.DataTable = ""
        Me.mdfTarcadu.Descripcion = "Clase"
        Me.mdfTarcadu.Dock = System.Windows.Forms.DockStyle.Right
        Me.mdfTarcadu.FocoEnAgregar = False
        Me.mdfTarcadu.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.mdfTarcadu.Location = New System.Drawing.Point(514, 0)
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
        Me.dtfTarjetaCond.DataField = "TARTI"
        Me.dtfTarjetaCond.DataTable = ""
        Me.dtfTarjetaCond.DB = Connection1
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
        Me.dtfTarjetaCond.Size = New System.Drawing.Size(559, 26)
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
        Me.dtfEmailCond.DataField = "MAILCOND"
        Me.dtfEmailCond.DataTable = ""
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
        Me.dtfEmailCond.Size = New System.Drawing.Size(559, 26)
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
        Me.pnlPermiso.Size = New System.Drawing.Size(559, 52)
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
        Me.pnlPermisoInf.Size = New System.Drawing.Size(559, 26)
        Me.pnlPermisoInf.TabIndex = 1
        '
        'dtfLuExpe
        '
        Me.dtfLuExpe.Allow_Empty = True
        Me.dtfLuExpe.Allow_Negative = True
        Me.dtfLuExpe.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfLuExpe.BackColor = System.Drawing.SystemColors.Control
        Me.dtfLuExpe.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfLuExpe.DataField = "LUEXPE"
        Me.dtfLuExpe.DataTable = ""
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
        Me.dtfLuExpe.Size = New System.Drawing.Size(388, 26)
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
        Me.dtdFeExpe.DataField = "FEEXPE"
        Me.dtdFeExpe.DataTable = ""
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
        Me.pnlPermisoSup.Size = New System.Drawing.Size(559, 26)
        Me.pnlPermisoSup.TabIndex = 0
        '
        'dtfPermiso
        '
        Me.dtfPermiso.Allow_Empty = True
        Me.dtfPermiso.Allow_Negative = True
        Me.dtfPermiso.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfPermiso.BackColor = System.Drawing.SystemColors.Control
        Me.dtfPermiso.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfPermiso.DataField = "PERMISO"
        Me.dtfPermiso.DataTable = ""
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
        Me.dtfPermiso.Size = New System.Drawing.Size(388, 26)
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
        Me.pnlSpace28.Location = New System.Drawing.Point(388, 0)
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
        Me.dtfClase.DataField = "CLASE"
        Me.dtfClase.DataTable = ""
        Me.dtfClase.Descripcion = "Clase"
        Me.dtfClase.Dock = System.Windows.Forms.DockStyle.Right
        Me.dtfClase.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfClase.FocoEnAgregar = False
        Me.dtfClase.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfClase.Image = Nothing
        Me.dtfClase.Label_Space = 75
        Me.dtfClase.Length_Data = 32767
        Me.dtfClase.Location = New System.Drawing.Point(394, 0)
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
        Me.pnlLuNace.Size = New System.Drawing.Size(559, 26)
        Me.pnlLuNace.TabIndex = 4
        '
        'dtfLuNace
        '
        Me.dtfLuNace.Allow_Empty = True
        Me.dtfLuNace.Allow_Negative = True
        Me.dtfLuNace.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfLuNace.BackColor = System.Drawing.SystemColors.Control
        Me.dtfLuNace.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfLuNace.DataField = "LUNACI"
        Me.dtfLuNace.DataTable = ""
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
        Me.dtfLuNace.Size = New System.Drawing.Size(373, 26)
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
        Me.pnlSpace27.Location = New System.Drawing.Point(373, 0)
        Me.pnlSpace27.Name = "pnlSpace27"
        Me.pnlSpace27.numRows = 0
        Me.pnlSpace27.Reorder = True
        Me.pnlSpace27.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace27.TabIndex = 1
        '
        'dtdFechaNac
        '
        Me.dtdFechaNac.Allow_Empty = True
        Me.dtdFechaNac.DataField = "FENACI"
        Me.dtdFechaNac.DataTable = ""
        Me.dtdFechaNac.Default_Value = New Date(2015, 9, 21, 0, 0, 0, 0)
        Me.dtdFechaNac.Descripcion = "F. Nacimiento"
        Me.dtdFechaNac.Dock = System.Windows.Forms.DockStyle.Right
        Me.dtdFechaNac.FocoEnAgregar = False
        Me.dtdFechaNac.Label_Space = 90
        Me.dtdFechaNac.Location = New System.Drawing.Point(379, 0)
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
        Me.pnlNifTelf.Size = New System.Drawing.Size(559, 26)
        Me.pnlNifTelf.TabIndex = 3
        '
        'dtfNIFCond
        '
        Me.dtfNIFCond.Allow_Empty = True
        Me.dtfNIFCond.Allow_Negative = True
        Me.dtfNIFCond.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfNIFCond.BackColor = System.Drawing.SystemColors.Control
        Me.dtfNIFCond.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfNIFCond.DataField = "DNICOND"
        Me.dtfNIFCond.DataTable = ""
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
        Me.dtfNIFCond.Size = New System.Drawing.Size(267, 26)
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
        Me.pnlSpace25.Location = New System.Drawing.Point(267, 0)
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
        Me.dtfTelfCond.DataField = "TELCOND"
        Me.dtfTelfCond.DataTable = ""
        Me.dtfTelfCond.Descripcion = "Telefono"
        Me.dtfTelfCond.Dock = System.Windows.Forms.DockStyle.Right
        Me.dtfTelfCond.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfTelfCond.FocoEnAgregar = False
        Me.dtfTelfCond.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfTelfCond.Image = Nothing
        Me.dtfTelfCond.Label_Space = 60
        Me.dtfTelfCond.Length_Data = 32767
        Me.dtfTelfCond.Location = New System.Drawing.Point(273, 0)
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
        Me.pnlSpace24.Location = New System.Drawing.Point(443, 0)
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
        Me.dtfTelfCond2.DataField = "TEL2COND"
        Me.dtfTelfCond2.DataTable = ""
        Me.dtfTelfCond2.Descripcion = "Telefono"
        Me.dtfTelfCond2.Dock = System.Windows.Forms.DockStyle.Right
        Me.dtfTelfCond2.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfTelfCond2.FocoEnAgregar = False
        Me.dtfTelfCond2.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfTelfCond2.Length_Data = 32767
        Me.dtfTelfCond2.Location = New System.Drawing.Point(449, 0)
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
        Me.dtdDirCond.Datafield_CP = "CPCOND"
        Me.dtdDirCond.Datafield_Direccion = "DIRCOND"
        Me.dtdDirCond.Datafield_Direccion2L = Nothing
        Me.dtdDirCond.Datafield_GPS = Nothing
        Me.dtdDirCond.Datafield_Pais = "PAISCOND"
        Me.dtdDirCond.Datafield_Poblacion = "POBCOND"
        Me.dtdDirCond.Datafield_Provincia = "PROVCOND"
        Me.dtdDirCond.Datatable_CP = ""
        Me.dtdDirCond.Datatable_Direccion = ""
        Me.dtdDirCond.Datatable_Direccion2L = ""
        Me.dtdDirCond.Datatable_GPS = ""
        Me.dtdDirCond.Datatable_Pais = ""
        Me.dtdDirCond.Datatable_Poblacion = ""
        Me.dtdDirCond.Datatable_Provincia = ""
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
        Me.dtdDirCond.Size = New System.Drawing.Size(559, 104)
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
        Me.dtfNombreCond.DataField = "NOMBRE"
        Me.dtfNombreCond.DataTable = ""
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
        Me.dtfNombreCond.Size = New System.Drawing.Size(559, 26)
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
        Me.pnlConductor.Size = New System.Drawing.Size(559, 26)
        Me.pnlConductor.TabIndex = 0
        '
        'dtfConductorDetalles
        '
        Me.dtfConductorDetalles.Allow_Empty = True
        Me.dtfConductorDetalles.Allow_Negative = True
        Me.dtfConductorDetalles.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfConductorDetalles.BackColor = System.Drawing.SystemColors.Control
        Me.dtfConductorDetalles.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfConductorDetalles.DataField = ""
        Me.dtfConductorDetalles.DataTable = ""
        Me.dtfConductorDetalles.DB = Connection2
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
        Me.dtfConductorDetalles.Size = New System.Drawing.Size(444, 26)
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
        Me.pnlSpace23.Location = New System.Drawing.Point(444, 0)
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
        Me.btnCargarCond.Location = New System.Drawing.Point(450, 0)
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
        Me.pnlSpace26.Location = New System.Drawing.Point(494, 0)
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
        Me.btnGuardar.Location = New System.Drawing.Point(500, 0)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(59, 20)
        Me.btnGuardar.TabIndex = 4
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.btnGuardar.ThemeName = "Windows8"
        '
        'ucConductor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.gbxConductor)
        Me.Name = "ucConductor"
        Me.Size = New System.Drawing.Size(571, 358)
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
        Me.ResumeLayout(False)

    End Sub
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
