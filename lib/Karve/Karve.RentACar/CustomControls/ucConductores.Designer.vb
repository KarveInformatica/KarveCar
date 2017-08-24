<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucConductores
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
        Dim Connection3 As ASADB.Connection = New ASADB.Connection()
        Dim Connection4 As ASADB.Connection = New ASADB.Connection()
        Dim Connection5 As ASADB.Connection = New ASADB.Connection()
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
        Me.pnlDir = New CustomControls.Panel()
        Me.dtfNombreCond = New CustomControls.DatafieldLabel()
        Me.pnlConductor = New CustomControls.Panel()
        Me.dtfConductorDetalles = New CustomControls.DualDatafieldLabel()
        Me.pnlSpace23 = New CustomControls.Panel()
        Me.btnCargarCond = New CustomControls.Button()
        Me.pnlSpace26 = New CustomControls.Panel()
        Me.btnGuardar = New CustomControls.Button()
        Me.pnlConductoresDer = New CustomControls.Panel()
        Me.gbxConductoresAdicionales = New CustomControls.GroupBox()
        Me.gbxOtroCond3 = New CustomControls.GroupBox()
        Me.pnlOtroPermismo3 = New CustomControls.Panel()
        Me.dtdOtroNac3 = New CustomControls.DataDateLabel()
        Me.dtfOtroPer3 = New CustomControls.DatafieldLabel()
        Me.pnlOtroFPermismo3 = New CustomControls.Panel()
        Me.dtdOtroCadu3 = New CustomControls.DataDateLabel()
        Me.dtdOtroExpe3 = New CustomControls.DataDateLabel()
        Me.dtfOtroCond3 = New CustomControls.DualDataFieldEditableLabel()
        Me.gbxOtroCond2 = New CustomControls.GroupBox()
        Me.pnlOtroPermismo2 = New CustomControls.Panel()
        Me.dtdOtroNac2 = New CustomControls.DataDateLabel()
        Me.dtfOtroPer2 = New CustomControls.DatafieldLabel()
        Me.pnlOtroFPermismo2 = New CustomControls.Panel()
        Me.dtdOtroCadu2 = New CustomControls.DataDateLabel()
        Me.dtdOtroExpe2 = New CustomControls.DataDateLabel()
        Me.dtfOtroCond2 = New CustomControls.DualDataFieldEditableLabel()
        Me.gbxOtroCond = New CustomControls.GroupBox()
        Me.pnlOtroPermismo = New CustomControls.Panel()
        Me.dtdOtroNac = New CustomControls.DataDateLabel()
        Me.dtfOtroPer = New CustomControls.DatafieldLabel()
        Me.pnlOtroFPermismo = New CustomControls.Panel()
        Me.dtdOtroCadu = New CustomControls.DataDateLabel()
        Me.dtdOtroExpe = New CustomControls.DataDateLabel()
        Me.dtfOtroCond = New CustomControls.DualDataFieldEditableLabel()
        CType(Me.pnlConductoresIzq, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlConductoresIzq.SuspendLayout()
        CType(Me.gbxConductor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxConductor.SuspendLayout()
        CType(Me.pnlTarjeta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTarjeta.SuspendLayout()
        CType(Me.pnlSpace31, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTarCadu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSpace30, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CType(Me.pnlDir, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlConductor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlConductor.SuspendLayout()
        CType(Me.pnlSpace23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnCargarCond, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSpace26, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnGuardar, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.SuspendLayout()
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
        Me.pnlConductoresIzq.Location = New System.Drawing.Point(0, 0)
        Me.pnlConductoresIzq.Name = "pnlConductoresIzq"
        Me.pnlConductoresIzq.numRows = 0
        Me.pnlConductoresIzq.Padding = New System.Windows.Forms.Padding(3)
        Me.pnlConductoresIzq.Reorder = True
        Me.pnlConductoresIzq.Size = New System.Drawing.Size(502, 494)
        Me.pnlConductoresIzq.TabIndex = 3
        '
        'gbxConductor
        '
        Me.gbxConductor.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.gbxConductor.AutoSize = True
        Me.gbxConductor.Controls.Add(Me.pnlTarjeta)
        Me.gbxConductor.Controls.Add(Me.dtfTarjetaCond)
        Me.gbxConductor.Controls.Add(Me.dtfEmailCond)
        Me.gbxConductor.Controls.Add(Me.pnlPermisoInf)
        Me.gbxConductor.Controls.Add(Me.pnlPermisoSup)
        Me.gbxConductor.Controls.Add(Me.pnlLuNace)
        Me.gbxConductor.Controls.Add(Me.pnlNifTelf)
        Me.gbxConductor.Controls.Add(Me.pnlDir)
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
        Me.gbxConductor.Size = New System.Drawing.Size(496, 353)
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
        Me.pnlTarjeta.Location = New System.Drawing.Point(6, 303)
        Me.pnlTarjeta.Name = "pnlTarjeta"
        Me.pnlTarjeta.numRows = 1
        Me.pnlTarjeta.Reorder = True
        Me.pnlTarjeta.Size = New System.Drawing.Size(484, 26)
        Me.pnlTarjeta.TabIndex = 9
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
        Me.dtfTarNum.Size = New System.Drawing.Size(325, 26)
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
        Me.pnlSpace31.Location = New System.Drawing.Point(325, 0)
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
        Me.lblTarCadu.Location = New System.Drawing.Point(331, 0)
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
        Me.pnlSpace30.Location = New System.Drawing.Point(433, 0)
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
        Me.mdfTarcadu.Location = New System.Drawing.Point(439, 0)
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
        Me.dtfTarjetaCond.Location = New System.Drawing.Point(6, 277)
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
        Me.dtfTarjetaCond.Size = New System.Drawing.Size(484, 26)
        Me.dtfTarjetaCond.TabIndex = 8
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
        Me.dtfEmailCond.Location = New System.Drawing.Point(6, 251)
        Me.dtfEmailCond.Max_Value = 0.0R
        Me.dtfEmailCond.MensajeIncorrectoCustom = Nothing
        Me.dtfEmailCond.Name = "dtfEmailCond"
        Me.dtfEmailCond.Null_on_Empty = True
        Me.dtfEmailCond.OpenForm = Nothing
        Me.dtfEmailCond.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfEmailCond.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfEmailCond.ReadOnly_Data = False
        Me.dtfEmailCond.Show_Button = True
        Me.dtfEmailCond.Size = New System.Drawing.Size(484, 26)
        Me.dtfEmailCond.TabIndex = 7
        Me.dtfEmailCond.Text_Data = ""
        Me.dtfEmailCond.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfEmailCond.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfEmailCond.TopPadding = 0
        Me.dtfEmailCond.Upper_Case = False
        Me.dtfEmailCond.Validate_on_lost_focus = True
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
        Me.pnlPermisoInf.Location = New System.Drawing.Point(6, 225)
        Me.pnlPermisoInf.Name = "pnlPermisoInf"
        Me.pnlPermisoInf.numRows = 1
        Me.pnlPermisoInf.Reorder = True
        Me.pnlPermisoInf.Size = New System.Drawing.Size(484, 26)
        Me.pnlPermisoInf.TabIndex = 6
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
        Me.dtfLuExpe.Size = New System.Drawing.Size(313, 26)
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
        Me.pnlPermisoSup.Location = New System.Drawing.Point(6, 199)
        Me.pnlPermisoSup.Name = "pnlPermisoSup"
        Me.pnlPermisoSup.numRows = 1
        Me.pnlPermisoSup.Reorder = True
        Me.pnlPermisoSup.Size = New System.Drawing.Size(484, 26)
        Me.pnlPermisoSup.TabIndex = 5
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
        Me.dtfPermiso.Size = New System.Drawing.Size(313, 26)
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
        Me.pnlSpace28.Location = New System.Drawing.Point(313, 0)
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
        Me.dtfClase.Location = New System.Drawing.Point(319, 0)
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
        Me.pnlLuNace.Location = New System.Drawing.Point(6, 173)
        Me.pnlLuNace.Name = "pnlLuNace"
        Me.pnlLuNace.numRows = 1
        Me.pnlLuNace.Reorder = True
        Me.pnlLuNace.Size = New System.Drawing.Size(484, 26)
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
        Me.dtfLuNace.Size = New System.Drawing.Size(298, 26)
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
        Me.pnlSpace27.Location = New System.Drawing.Point(298, 0)
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
        Me.dtdFechaNac.Location = New System.Drawing.Point(304, 0)
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
        Me.pnlNifTelf.Location = New System.Drawing.Point(6, 147)
        Me.pnlNifTelf.Name = "pnlNifTelf"
        Me.pnlNifTelf.numRows = 1
        Me.pnlNifTelf.Reorder = True
        Me.pnlNifTelf.Size = New System.Drawing.Size(484, 26)
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
        Me.dtfNIFCond.Size = New System.Drawing.Size(192, 26)
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
        Me.pnlSpace25.Location = New System.Drawing.Point(192, 0)
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
        Me.dtfTelfCond.Location = New System.Drawing.Point(198, 0)
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
        Me.pnlSpace24.Location = New System.Drawing.Point(368, 0)
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
        Me.dtfTelfCond2.Location = New System.Drawing.Point(374, 0)
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
        'pnlDir
        '
        Me.pnlDir.Auto_Size = False
        Me.pnlDir.BackColor = System.Drawing.Color.Silver
        Me.pnlDir.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlDir.ChangeDock = True
        Me.pnlDir.Control_Resize = False
        Me.pnlDir.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlDir.isSpace = False
        Me.pnlDir.Location = New System.Drawing.Point(6, 70)
        Me.pnlDir.Name = "pnlDir"
        Me.pnlDir.numRows = 0
        Me.pnlDir.Reorder = True
        Me.pnlDir.Size = New System.Drawing.Size(484, 77)
        Me.pnlDir.TabIndex = 2
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
        Me.dtfNombreCond.Size = New System.Drawing.Size(484, 26)
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
        Me.pnlConductor.Size = New System.Drawing.Size(484, 26)
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
        Me.dtfConductorDetalles.DB = Connection2
        Me.dtfConductorDetalles.Desc_Datafield = "NOMBRE"
        Me.dtfConductorDetalles.Desc_DBPK = "NUMERO_CLI"
        Me.dtfConductorDetalles.Desc_DBTable = "CLIENTES1"
        Me.dtfConductorDetalles.Desc_Where = "BAJA IS NULL"
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
        Me.dtfConductorDetalles.Size = New System.Drawing.Size(369, 26)
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
        Me.pnlSpace23.Location = New System.Drawing.Point(369, 0)
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
        Me.btnCargarCond.Location = New System.Drawing.Point(375, 0)
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
        Me.pnlSpace26.Location = New System.Drawing.Point(419, 0)
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
        Me.btnGuardar.Location = New System.Drawing.Point(425, 0)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(59, 20)
        Me.btnGuardar.TabIndex = 4
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.btnGuardar.ThemeName = "Windows8"
        '
        'pnlConductoresDer
        '
        Me.pnlConductoresDer.Auto_Size = False
        Me.pnlConductoresDer.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlConductoresDer.ChangeDock = True
        Me.pnlConductoresDer.Control_Resize = False
        Me.pnlConductoresDer.Controls.Add(Me.gbxConductoresAdicionales)
        Me.pnlConductoresDer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlConductoresDer.isSpace = False
        Me.pnlConductoresDer.Location = New System.Drawing.Point(502, 0)
        Me.pnlConductoresDer.Name = "pnlConductoresDer"
        Me.pnlConductoresDer.numRows = 0
        Me.pnlConductoresDer.Padding = New System.Windows.Forms.Padding(3)
        Me.pnlConductoresDer.Reorder = True
        Me.pnlConductoresDer.Size = New System.Drawing.Size(398, 494)
        Me.pnlConductoresDer.TabIndex = 4
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
        Me.gbxConductoresAdicionales.Size = New System.Drawing.Size(392, 318)
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
        Me.gbxOtroCond3.Size = New System.Drawing.Size(380, 98)
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
        Me.pnlOtroPermismo3.Size = New System.Drawing.Size(182, 48)
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
        Me.dtdOtroNac3.Location = New System.Drawing.Point(2, 26)
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
        Me.dtfOtroPer3.Size = New System.Drawing.Size(182, 26)
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
        Me.pnlOtroFPermismo3.Location = New System.Drawing.Point(188, 44)
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
        Me.dtfOtroCond3.DataField = "COD_COND3_CON2"
        Me.dtfOtroCond3.DataField_DescEdit = "OTRO3COND_CON2"
        Me.dtfOtroCond3.DataTable = "C2"
        Me.dtfOtroCond3.DataTable_DescEdit = "C2"
        Me.dtfOtroCond3.DB = Connection3
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
        Me.dtfOtroCond3.Query_on_Text_Changed = False
        Me.dtfOtroCond3.ReadOnly_Data = False
        Me.dtfOtroCond3.ReadOnly_Desc = False
        Me.dtfOtroCond3.ReQuery = False
        Me.dtfOtroCond3.ShowButton = True
        Me.dtfOtroCond3.Size = New System.Drawing.Size(368, 26)
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
        Me.gbxOtroCond2.Size = New System.Drawing.Size(380, 98)
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
        Me.pnlOtroPermismo2.Size = New System.Drawing.Size(182, 48)
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
        Me.dtdOtroNac2.Location = New System.Drawing.Point(2, 26)
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
        Me.dtfOtroPer2.Size = New System.Drawing.Size(182, 26)
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
        Me.pnlOtroFPermismo2.Location = New System.Drawing.Point(188, 44)
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
        Me.dtfOtroCond2.DataField = "COD_COND2_CON2"
        Me.dtfOtroCond2.DataField_DescEdit = "OTRO2COND_CON2"
        Me.dtfOtroCond2.DataTable = "C2"
        Me.dtfOtroCond2.DataTable_DescEdit = "C2"
        Me.dtfOtroCond2.DB = Connection4
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
        Me.dtfOtroCond2.Query_on_Text_Changed = False
        Me.dtfOtroCond2.ReadOnly_Data = False
        Me.dtfOtroCond2.ReadOnly_Desc = False
        Me.dtfOtroCond2.ReQuery = False
        Me.dtfOtroCond2.ShowButton = True
        Me.dtfOtroCond2.Size = New System.Drawing.Size(368, 26)
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
        Me.gbxOtroCond.Size = New System.Drawing.Size(380, 98)
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
        Me.pnlOtroPermismo.Size = New System.Drawing.Size(182, 48)
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
        Me.dtdOtroNac.Location = New System.Drawing.Point(2, 26)
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
        Me.dtfOtroPer.Size = New System.Drawing.Size(182, 26)
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
        Me.pnlOtroFPermismo.Location = New System.Drawing.Point(188, 44)
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
        Me.dtfOtroCond.DataField = "COD_COND1_CON2"
        Me.dtfOtroCond.DataField_DescEdit = "OTROCOND_CON2"
        Me.dtfOtroCond.DataTable = "C2"
        Me.dtfOtroCond.DataTable_DescEdit = "C2"
        Me.dtfOtroCond.DB = Connection5
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
        Me.dtfOtroCond.Query_on_Text_Changed = False
        Me.dtfOtroCond.ReadOnly_Data = False
        Me.dtfOtroCond.ReadOnly_Desc = False
        Me.dtfOtroCond.ReQuery = False
        Me.dtfOtroCond.ShowButton = True
        Me.dtfOtroCond.Size = New System.Drawing.Size(368, 26)
        Me.dtfOtroCond.TabIndex = 0
        Me.dtfOtroCond.Text_Data = ""
        Me.dtfOtroCond.Text_Data_Desc = ""
        Me.dtfOtroCond.Text_Width = 58
        Me.dtfOtroCond.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfOtroCond.TopPadding = 0
        Me.dtfOtroCond.Upper_Case = False
        Me.dtfOtroCond.Validate_on_lost_focus = True
        '
        'ucConductores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.pnlConductoresDer)
        Me.Controls.Add(Me.pnlConductoresIzq)
        Me.Name = "ucConductores"
        Me.Size = New System.Drawing.Size(900, 494)
        CType(Me.pnlConductoresIzq, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlConductoresIzq.ResumeLayout(False)
        Me.pnlConductoresIzq.PerformLayout()
        CType(Me.gbxConductor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxConductor.ResumeLayout(False)
        CType(Me.pnlTarjeta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTarjeta.ResumeLayout(False)
        Me.pnlTarjeta.PerformLayout()
        CType(Me.pnlSpace31, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTarCadu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSpace30, System.ComponentModel.ISupportInitialize).EndInit()
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
        CType(Me.pnlDir, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlConductor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlConductor.ResumeLayout(False)
        CType(Me.pnlSpace23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnCargarCond, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSpace26, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnGuardar, System.ComponentModel.ISupportInitialize).EndInit()
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
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlConductoresIzq As CustomControls.Panel
    Friend WithEvents gbxConductor As CustomControls.GroupBox
    Friend WithEvents pnlConductor As CustomControls.Panel
    Friend WithEvents dtfConductorDetalles As CustomControls.DualDatafieldLabel
    Friend WithEvents pnlSpace23 As CustomControls.Panel
    Friend WithEvents btnCargarCond As CustomControls.Button
    Friend WithEvents pnlSpace26 As CustomControls.Panel
    Friend WithEvents btnGuardar As CustomControls.Button
    Friend WithEvents dtfNombreCond As CustomControls.DatafieldLabel
    Friend WithEvents pnlDir As CustomControls.Panel
    Friend WithEvents pnlNifTelf As CustomControls.Panel
    Friend WithEvents dtfNIFCond As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace25 As CustomControls.Panel
    Friend WithEvents dtfTelfCond As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace24 As CustomControls.Panel
    Friend WithEvents dtfTelfCond2 As CustomControls.Datafield
    Friend WithEvents pnlLuNace As CustomControls.Panel
    Friend WithEvents dtfLuNace As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace27 As CustomControls.Panel
    Friend WithEvents dtdFechaNac As CustomControls.DataDateLabel
    Friend WithEvents pnlPermisoSup As CustomControls.Panel
    Friend WithEvents dtfPermiso As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace28 As CustomControls.Panel
    Friend WithEvents dtfClase As CustomControls.DatafieldLabel
    Friend WithEvents pnlPermisoInf As CustomControls.Panel
    Friend WithEvents dtfLuExpe As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace29 As CustomControls.Panel
    Friend WithEvents dtdFeExpe As CustomControls.DataDateLabel
    Friend WithEvents dtfTarjetaCond As CustomControls.DualDatafieldLabel
    Friend WithEvents dtfEmailCond As CustomControls.DatafieldLabel
    Friend WithEvents pnlTarjeta As CustomControls.Panel
    Friend WithEvents dtfTarNum As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace31 As CustomControls.Panel
    Friend WithEvents lblTarCadu As CustomControls.Label
    Friend WithEvents pnlSpace30 As CustomControls.Panel
    Friend WithEvents mdfTarcadu As CustomControls.MaskedDataField
    Friend WithEvents pnlConductoresDer As CustomControls.Panel
    Friend WithEvents gbxConductoresAdicionales As CustomControls.GroupBox
    Friend WithEvents gbxOtroCond3 As CustomControls.GroupBox
    Friend WithEvents pnlOtroPermismo3 As CustomControls.Panel
    Friend WithEvents dtdOtroNac3 As CustomControls.DataDateLabel
    Friend WithEvents dtfOtroPer3 As CustomControls.DatafieldLabel
    Friend WithEvents pnlOtroFPermismo3 As CustomControls.Panel
    Friend WithEvents dtdOtroCadu3 As CustomControls.DataDateLabel
    Friend WithEvents dtdOtroExpe3 As CustomControls.DataDateLabel
    Friend WithEvents dtfOtroCond3 As CustomControls.DualDataFieldEditableLabel
    Friend WithEvents gbxOtroCond2 As CustomControls.GroupBox
    Friend WithEvents pnlOtroPermismo2 As CustomControls.Panel
    Friend WithEvents dtdOtroNac2 As CustomControls.DataDateLabel
    Friend WithEvents dtfOtroPer2 As CustomControls.DatafieldLabel
    Friend WithEvents pnlOtroFPermismo2 As CustomControls.Panel
    Friend WithEvents dtdOtroCadu2 As CustomControls.DataDateLabel
    Friend WithEvents dtdOtroExpe2 As CustomControls.DataDateLabel
    Friend WithEvents dtfOtroCond2 As CustomControls.DualDataFieldEditableLabel
    Friend WithEvents gbxOtroCond As CustomControls.GroupBox
    Friend WithEvents pnlOtroPermismo As CustomControls.Panel
    Friend WithEvents dtdOtroNac As CustomControls.DataDateLabel
    Friend WithEvents dtfOtroPer As CustomControls.DatafieldLabel
    Friend WithEvents pnlOtroFPermismo As CustomControls.Panel
    Friend WithEvents dtdOtroCadu As CustomControls.DataDateLabel
    Friend WithEvents dtdOtroExpe As CustomControls.DataDateLabel
    Friend WithEvents dtfOtroCond As CustomControls.DualDataFieldEditableLabel

End Class
