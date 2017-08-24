<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DataDir
    Inherits CustomControls.ctrBase

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
        Me.Windows8Theme1 = New Telerik.WinControls.Themes.Windows8Theme()
        Me.pnlCPPob = New System.Windows.Forms.Panel()
        Me.dtfPoblacion = New CustomControls.DatafieldLabel()
        Me.pnlSpace = New System.Windows.Forms.Panel()
        Me.dtfCP = New CustomControls.DatafieldLabel()
        Me.dtfPais = New CustomControls.DualDatafieldLabel()
        Me.dtfProvincia = New CustomControls.DualDatafieldLabel()
        Me.dtfGPS = New CustomControls.DatafieldLabel()
        Me.dtfDireccion2L = New CustomControls.DatafieldLabel()
        Me.dtfDireccion = New CustomControls.DatafieldLabel()
        Me.pnlCPPob.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlCPPob
        '
        Me.pnlCPPob.Controls.Add(Me.dtfPoblacion)
        Me.pnlCPPob.Controls.Add(Me.pnlSpace)
        Me.pnlCPPob.Controls.Add(Me.dtfCP)
        Me.pnlCPPob.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCPPob.Location = New System.Drawing.Point(0, 78)
        Me.pnlCPPob.Name = "pnlCPPob"
        Me.pnlCPPob.Size = New System.Drawing.Size(446, 26)
        Me.pnlCPPob.TabIndex = 3
        '
        'dtfPoblacion
        '
        Me.dtfPoblacion.Allow_Empty = True
        Me.dtfPoblacion.Allow_Negative = True
        Me.dtfPoblacion.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfPoblacion.BackColor = System.Drawing.SystemColors.Control
        Me.dtfPoblacion.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfPoblacion.DataField = Nothing
        Me.dtfPoblacion.DataTable = ""
        Me.dtfPoblacion.Descripcion = "Poblacion"
        Me.dtfPoblacion.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfPoblacion.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfPoblacion.FocoEnAgregar = False
        Me.dtfPoblacion.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfPoblacion.Image = Nothing
        Me.dtfPoblacion.Label_Space = 60
        Me.dtfPoblacion.Length_Data = 32767
        Me.dtfPoblacion.Location = New System.Drawing.Point(158, 0)
        Me.dtfPoblacion.Max_Value = 0.0R
        Me.dtfPoblacion.MensajeIncorrectoCustom = Nothing
        Me.dtfPoblacion.Name = "dtfPoblacion"
        Me.dtfPoblacion.Null_on_Empty = True
        Me.dtfPoblacion.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfPoblacion.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfPoblacion.ReadOnly_Data = False
        Me.dtfPoblacion.Show_Button = False
        Me.dtfPoblacion.Size = New System.Drawing.Size(288, 26)
        Me.dtfPoblacion.TabIndex = 1
        Me.dtfPoblacion.Text_Data = ""
        Me.dtfPoblacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfPoblacion.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfPoblacion.TopPadding = 0
        Me.dtfPoblacion.Upper_Case = False
        Me.dtfPoblacion.Validate_on_lost_focus = True
        '
        'pnlSpace
        '
        Me.pnlSpace.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace.Location = New System.Drawing.Point(152, 0)
        Me.pnlSpace.Name = "pnlSpace"
        Me.pnlSpace.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace.TabIndex = 2
        '
        'dtfCP
        '
        Me.dtfCP.Allow_Empty = True
        Me.dtfCP.Allow_Negative = True
        Me.dtfCP.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfCP.BackColor = System.Drawing.SystemColors.Control
        Me.dtfCP.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfCP.DataField = Nothing
        Me.dtfCP.DataTable = ""
        Me.dtfCP.Descripcion = "CP"
        Me.dtfCP.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfCP.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfCP.FocoEnAgregar = False
        Me.dtfCP.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfCP.Image = Nothing
        Me.dtfCP.Label_Space = 75
        Me.dtfCP.Length_Data = 32767
        Me.dtfCP.Location = New System.Drawing.Point(0, 0)
        Me.dtfCP.Max_Value = 0.0R
        Me.dtfCP.MensajeIncorrectoCustom = Nothing
        Me.dtfCP.Name = "dtfCP"
        Me.dtfCP.Null_on_Empty = True
        Me.dtfCP.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfCP.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfCP.ReadOnly_Data = False
        Me.dtfCP.Show_Button = True
        Me.dtfCP.Size = New System.Drawing.Size(152, 26)
        Me.dtfCP.TabIndex = 0
        Me.dtfCP.Text_Data = ""
        Me.dtfCP.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfCP.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfCP.TopPadding = 0
        Me.dtfCP.Upper_Case = False
        Me.dtfCP.Validate_on_lost_focus = True
        '
        'dtfPais
        '
        Me.dtfPais.Allow_Empty = True
        Me.dtfPais.Allow_Negative = True
        Me.dtfPais.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfPais.BackColor = System.Drawing.SystemColors.Control
        Me.dtfPais.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfPais.DataField = Nothing
        Me.dtfPais.DataTable = ""
        Me.dtfPais.DB = Connection1
        Me.dtfPais.Desc_Datafield = "pais"
        Me.dtfPais.Desc_DBPK = "siglas"
        Me.dtfPais.Desc_DBTable = "pais"
        Me.dtfPais.Desc_Where = Nothing
        Me.dtfPais.Desc_WhereObligatoria = Nothing
        Me.dtfPais.Descripcion = "Pais"
        Me.dtfPais.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfPais.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfPais.ExtraSQL = ""
        Me.dtfPais.FocoEnAgregar = False
        Me.dtfPais.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfPais.Formulario = ""
        Me.dtfPais.Label_Space = 75
        Me.dtfPais.Length_Data = 32767
        Me.dtfPais.Location = New System.Drawing.Point(0, 130)
        Me.dtfPais.Lupa = Nothing
        Me.dtfPais.Max_Value = 0.0R
        Me.dtfPais.MensajeIncorrectoCustom = Nothing
        Me.dtfPais.Name = "dtfPais"
        Me.dtfPais.Null_on_Empty = True
        Me.dtfPais.OpenForm = ""
        Me.dtfPais.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfPais.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfPais.Query_on_Text_Changed = True
        Me.dtfPais.ReadOnly_Data = False
        Me.dtfPais.ShowButton = True
        Me.dtfPais.Size = New System.Drawing.Size(446, 26)
        Me.dtfPais.TabIndex = 5
        Me.dtfPais.Text_Data = ""
        Me.dtfPais.Text_Data_Desc = ""
        Me.dtfPais.Text_Width = 50
        Me.dtfPais.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfPais.TopPadding = 0
        Me.dtfPais.Upper_Case = False
        Me.dtfPais.Validate_on_lost_focus = True
        '
        'dtfProvincia
        '
        Me.dtfProvincia.Allow_Empty = True
        Me.dtfProvincia.Allow_Negative = True
        Me.dtfProvincia.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfProvincia.BackColor = System.Drawing.SystemColors.Control
        Me.dtfProvincia.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfProvincia.DataField = Nothing
        Me.dtfProvincia.DataTable = ""
        Me.dtfProvincia.DB = Connection2
        Me.dtfProvincia.Desc_Datafield = "prov"
        Me.dtfProvincia.Desc_DBPK = "siglas"
        Me.dtfProvincia.Desc_DBTable = "provincia"
        Me.dtfProvincia.Desc_Where = Nothing
        Me.dtfProvincia.Desc_WhereObligatoria = Nothing
        Me.dtfProvincia.Descripcion = "Provincia"
        Me.dtfProvincia.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfProvincia.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfProvincia.ExtraSQL = ""
        Me.dtfProvincia.FocoEnAgregar = False
        Me.dtfProvincia.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfProvincia.Formulario = Nothing
        Me.dtfProvincia.Label_Space = 75
        Me.dtfProvincia.Length_Data = 32767
        Me.dtfProvincia.Location = New System.Drawing.Point(0, 104)
        Me.dtfProvincia.Lupa = Nothing
        Me.dtfProvincia.Max_Value = 0.0R
        Me.dtfProvincia.MensajeIncorrectoCustom = Nothing
        Me.dtfProvincia.Name = "dtfProvincia"
        Me.dtfProvincia.Null_on_Empty = True
        Me.dtfProvincia.OpenForm = Nothing
        Me.dtfProvincia.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfProvincia.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfProvincia.Query_on_Text_Changed = True
        Me.dtfProvincia.ReadOnly_Data = False
        Me.dtfProvincia.ShowButton = True
        Me.dtfProvincia.Size = New System.Drawing.Size(446, 26)
        Me.dtfProvincia.TabIndex = 4
        Me.dtfProvincia.Text_Data = ""
        Me.dtfProvincia.Text_Data_Desc = ""
        Me.dtfProvincia.Text_Width = 50
        Me.dtfProvincia.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfProvincia.TopPadding = 0
        Me.dtfProvincia.Upper_Case = False
        Me.dtfProvincia.Validate_on_lost_focus = True
        '
        'dtfGPS
        '
        Me.dtfGPS.Allow_Empty = True
        Me.dtfGPS.Allow_Negative = True
        Me.dtfGPS.AutoSize = True
        Me.dtfGPS.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfGPS.BackColor = System.Drawing.SystemColors.Control
        Me.dtfGPS.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfGPS.DataField = Nothing
        Me.dtfGPS.DataTable = ""
        Me.dtfGPS.Descripcion = "GPS"
        Me.dtfGPS.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfGPS.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfGPS.FocoEnAgregar = False
        Me.dtfGPS.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfGPS.Image = Nothing
        Me.dtfGPS.Label_Space = 75
        Me.dtfGPS.Length_Data = 32767
        Me.dtfGPS.Location = New System.Drawing.Point(0, 52)
        Me.dtfGPS.Max_Value = 0.0R
        Me.dtfGPS.MensajeIncorrectoCustom = Nothing
        Me.dtfGPS.Name = "dtfGPS"
        Me.dtfGPS.Null_on_Empty = True
        Me.dtfGPS.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfGPS.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfGPS.ReadOnly_Data = False
        Me.dtfGPS.Show_Button = True
        Me.dtfGPS.Size = New System.Drawing.Size(446, 26)
        Me.dtfGPS.TabIndex = 2
        Me.dtfGPS.Text_Data = ""
        Me.dtfGPS.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfGPS.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfGPS.TopPadding = 0
        Me.dtfGPS.Upper_Case = False
        Me.dtfGPS.Validate_on_lost_focus = True
        '
        'dtfDireccion2L
        '
        Me.dtfDireccion2L.Allow_Empty = True
        Me.dtfDireccion2L.Allow_Negative = True
        Me.dtfDireccion2L.AutoSize = True
        Me.dtfDireccion2L.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfDireccion2L.BackColor = System.Drawing.SystemColors.Control
        Me.dtfDireccion2L.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfDireccion2L.DataField = Nothing
        Me.dtfDireccion2L.DataTable = ""
        Me.dtfDireccion2L.Descripcion = ""
        Me.dtfDireccion2L.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfDireccion2L.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfDireccion2L.FocoEnAgregar = False
        Me.dtfDireccion2L.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfDireccion2L.Image = Nothing
        Me.dtfDireccion2L.Label_Space = 75
        Me.dtfDireccion2L.Length_Data = 32767
        Me.dtfDireccion2L.Location = New System.Drawing.Point(0, 26)
        Me.dtfDireccion2L.Max_Value = 0.0R
        Me.dtfDireccion2L.MensajeIncorrectoCustom = Nothing
        Me.dtfDireccion2L.Name = "dtfDireccion2L"
        Me.dtfDireccion2L.Null_on_Empty = True
        Me.dtfDireccion2L.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfDireccion2L.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfDireccion2L.ReadOnly_Data = False
        Me.dtfDireccion2L.Show_Button = False
        Me.dtfDireccion2L.Size = New System.Drawing.Size(446, 26)
        Me.dtfDireccion2L.TabIndex = 1
        Me.dtfDireccion2L.Text_Data = ""
        Me.dtfDireccion2L.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfDireccion2L.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfDireccion2L.TopPadding = 0
        Me.dtfDireccion2L.Upper_Case = False
        Me.dtfDireccion2L.Validate_on_lost_focus = True
        '
        'dtfDireccion
        '
        Me.dtfDireccion.Allow_Empty = True
        Me.dtfDireccion.Allow_Negative = True
        Me.dtfDireccion.AutoSize = True
        Me.dtfDireccion.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfDireccion.BackColor = System.Drawing.SystemColors.Control
        Me.dtfDireccion.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfDireccion.DataField = Nothing
        Me.dtfDireccion.DataTable = ""
        Me.dtfDireccion.Descripcion = "Dirección"
        Me.dtfDireccion.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfDireccion.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfDireccion.FocoEnAgregar = False
        Me.dtfDireccion.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfDireccion.Image = Nothing
        Me.dtfDireccion.Label_Space = 75
        Me.dtfDireccion.Length_Data = 32767
        Me.dtfDireccion.Location = New System.Drawing.Point(0, 0)
        Me.dtfDireccion.Max_Value = 0.0R
        Me.dtfDireccion.MensajeIncorrectoCustom = Nothing
        Me.dtfDireccion.Name = "dtfDireccion"
        Me.dtfDireccion.Null_on_Empty = True
        Me.dtfDireccion.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfDireccion.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfDireccion.ReadOnly_Data = False
        Me.dtfDireccion.Show_Button = False
        Me.dtfDireccion.Size = New System.Drawing.Size(446, 26)
        Me.dtfDireccion.TabIndex = 0
        Me.dtfDireccion.Text_Data = ""
        Me.dtfDireccion.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfDireccion.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfDireccion.TopPadding = 0
        Me.dtfDireccion.Upper_Case = False
        Me.dtfDireccion.Validate_on_lost_focus = True
        '
        'DataDir
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.Controls.Add(Me.dtfPais)
        Me.Controls.Add(Me.dtfProvincia)
        Me.Controls.Add(Me.pnlCPPob)
        Me.Controls.Add(Me.dtfGPS)
        Me.Controls.Add(Me.dtfDireccion2L)
        Me.Controls.Add(Me.dtfDireccion)
        Me.Name = "DataDir"
        Me.Size = New System.Drawing.Size(446, 156)
        Me.pnlCPPob.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Windows8Theme1 As Telerik.WinControls.Themes.Windows8Theme
    Friend WithEvents pnlCPPob As System.Windows.Forms.Panel
    Friend WithEvents dtfCP As CustomControls.DatafieldLabel
    Friend WithEvents dtfDireccion As CustomControls.DatafieldLabel
    Friend WithEvents dtfProvincia As CustomControls.DualDatafieldLabel
    Friend WithEvents dtfPais As CustomControls.DualDatafieldLabel
    Friend WithEvents pnlSpace As System.Windows.Forms.Panel
    Friend WithEvents dtfPoblacion As CustomControls.DatafieldLabel
    Friend WithEvents dtfDireccion2L As CustomControls.DatafieldLabel
    Friend WithEvents dtfGPS As CustomControls.DatafieldLabel

End Class
