<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LupaModelo
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
        Me.pnlLeft = New CustomControls.Panel()
        Me.dtfVar = New CustomControls.Datafield()
        Me.pnlSpace = New CustomControls.Panel()
        Me.dtfMod = New CustomControls.DatafieldLabel()
        Me.pnlSpace1 = New CustomControls.Panel()
        Me.dtfDescrip = New CustomControls.DatafieldLabel()
        CType(Me.pnlLeft, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlLeft.SuspendLayout()
        CType(Me.pnlSpace, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSpace1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlLeft
        '
        Me.pnlLeft.Auto_Size = False
        Me.pnlLeft.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlLeft.ChangeDock = True
        Me.pnlLeft.Control_Resize = False
        Me.pnlLeft.Controls.Add(Me.dtfVar)
        Me.pnlLeft.Controls.Add(Me.pnlSpace)
        Me.pnlLeft.Controls.Add(Me.dtfMod)
        Me.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlLeft.isSpace = False
        Me.pnlLeft.Location = New System.Drawing.Point(0, 0)
        Me.pnlLeft.Name = "pnlLeft"
        Me.pnlLeft.numRows = 0
        Me.pnlLeft.Reorder = True
        Me.pnlLeft.Size = New System.Drawing.Size(161, 26)
        Me.pnlLeft.TabIndex = 0
        '
        'dtfVar
        '
        Me.dtfVar.Allow_Empty = True
        Me.dtfVar.Allow_Negative = True
        Me.dtfVar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfVar.BackColor = System.Drawing.SystemColors.Control
        Me.dtfVar.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfVar.DataField = "MO2"
        Me.dtfVar.DataTable = "V1"
        Me.dtfVar.Descripcion = Nothing
        Me.dtfVar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtfVar.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfVar.FocoEnAgregar = False
        Me.dtfVar.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfVar.Length_Data = 32767
        Me.dtfVar.Location = New System.Drawing.Point(124, 0)
        Me.dtfVar.Max_Value = 0.0R
        Me.dtfVar.MensajeIncorrectoCustom = Nothing
        Me.dtfVar.Name = "dtfVar"
        Me.dtfVar.Null_on_Empty = True
        Me.dtfVar.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfVar.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfVar.ReadOnly_Data = False
        Me.dtfVar.Size = New System.Drawing.Size(37, 26)
        Me.dtfVar.TabIndex = 2
        Me.dtfVar.Text_Data = ""
        Me.dtfVar.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfVar.TopPadding = 0
        Me.dtfVar.Upper_Case = False
        Me.dtfVar.Validate_on_lost_focus = True
        '
        'pnlSpace
        '
        Me.pnlSpace.Auto_Size = False
        Me.pnlSpace.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace.ChangeDock = True
        Me.pnlSpace.Control_Resize = False
        Me.pnlSpace.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace.isSpace = True
        Me.pnlSpace.Location = New System.Drawing.Point(118, 0)
        Me.pnlSpace.Name = "pnlSpace"
        Me.pnlSpace.numRows = 0
        Me.pnlSpace.Reorder = True
        Me.pnlSpace.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace.TabIndex = 1
        '
        'dtfMod
        '
        Me.dtfMod.Allow_Empty = True
        Me.dtfMod.Allow_Negative = True
        Me.dtfMod.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfMod.BackColor = System.Drawing.SystemColors.Control
        Me.dtfMod.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfMod.DataField = "MO1"
        Me.dtfMod.DataTable = "V1"
        Me.dtfMod.Descripcion = "Modelo"
        Me.dtfMod.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfMod.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfMod.FocoEnAgregar = False
        Me.dtfMod.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfMod.Image = Nothing
        Me.dtfMod.Label_Space = 80
        Me.dtfMod.Length_Data = 32767
        Me.dtfMod.Location = New System.Drawing.Point(0, 0)
        Me.dtfMod.Max_Value = 0.0R
        Me.dtfMod.MensajeIncorrectoCustom = Nothing
        Me.dtfMod.Name = "dtfMod"
        Me.dtfMod.Null_on_Empty = True
        Me.dtfMod.OpenForm = Nothing
        Me.dtfMod.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfMod.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfMod.ReadOnly_Data = False
        Me.dtfMod.Show_Button = False
        Me.dtfMod.Size = New System.Drawing.Size(118, 26)
        Me.dtfMod.TabIndex = 0
        Me.dtfMod.Text_Data = ""
        Me.dtfMod.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfMod.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfMod.TopPadding = 0
        Me.dtfMod.Upper_Case = False
        Me.dtfMod.Validate_on_lost_focus = True
        '
        'pnlSpace1
        '
        Me.pnlSpace1.Auto_Size = False
        Me.pnlSpace1.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace1.ChangeDock = True
        Me.pnlSpace1.Control_Resize = False
        Me.pnlSpace1.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace1.isSpace = False
        Me.pnlSpace1.Location = New System.Drawing.Point(161, 0)
        Me.pnlSpace1.Name = "pnlSpace1"
        Me.pnlSpace1.numRows = 0
        Me.pnlSpace1.Reorder = True
        Me.pnlSpace1.Size = New System.Drawing.Size(5, 26)
        Me.pnlSpace1.TabIndex = 1
        '
        'dtfDescrip
        '
        Me.dtfDescrip.Allow_Empty = True
        Me.dtfDescrip.Allow_Negative = True
        Me.dtfDescrip.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfDescrip.BackColor = System.Drawing.SystemColors.Control
        Me.dtfDescrip.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfDescrip.DataField = "MODELO"
        Me.dtfDescrip.DataTable = "V1"
        Me.dtfDescrip.Descripcion = ""
        Me.dtfDescrip.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtfDescrip.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfDescrip.FocoEnAgregar = False
        Me.dtfDescrip.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfDescrip.Image = Nothing
        Me.dtfDescrip.Label_Space = 0
        Me.dtfDescrip.Length_Data = 32767
        Me.dtfDescrip.Location = New System.Drawing.Point(166, 0)
        Me.dtfDescrip.Max_Value = 0.0R
        Me.dtfDescrip.MensajeIncorrectoCustom = Nothing
        Me.dtfDescrip.Name = "dtfDescrip"
        Me.dtfDescrip.Null_on_Empty = True
        Me.dtfDescrip.OpenForm = Nothing
        Me.dtfDescrip.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfDescrip.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfDescrip.ReadOnly_Data = True
        Me.dtfDescrip.Show_Button = True
        Me.dtfDescrip.Size = New System.Drawing.Size(259, 26)
        Me.dtfDescrip.TabIndex = 2
        Me.dtfDescrip.TabStop = False
        Me.dtfDescrip.Text_Data = ""
        Me.dtfDescrip.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfDescrip.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfDescrip.TopPadding = 0
        Me.dtfDescrip.Upper_Case = False
        Me.dtfDescrip.Validate_on_lost_focus = True
        '
        'LupaModelo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.dtfDescrip)
        Me.Controls.Add(Me.pnlSpace1)
        Me.Controls.Add(Me.pnlLeft)
        Me.Name = "LupaModelo"
        Me.Size = New System.Drawing.Size(425, 26)
        CType(Me.pnlLeft, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlLeft.ResumeLayout(False)
        CType(Me.pnlSpace, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSpace1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlLeft As CustomControls.Panel
    Friend WithEvents dtfVar As CustomControls.Datafield
    Friend WithEvents pnlSpace As CustomControls.Panel
    Friend WithEvents dtfMod As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace1 As CustomControls.Panel
    Friend WithEvents dtfDescrip As CustomControls.DatafieldLabel

End Class
