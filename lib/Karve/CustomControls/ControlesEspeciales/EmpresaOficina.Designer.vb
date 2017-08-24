<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class EmpresaOficina
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
        Me.dtfOficina = New CustomControls.DualDatafieldLabel()
        Me.pnlSpace = New CustomControls.Panel()
        Me.dtfEmpresa = New CustomControls.DualDatafieldLabel()
        CType(Me.pnlSpace, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtfOficina
        '
        Me.dtfOficina.Allow_Empty = True
        Me.dtfOficina.Allow_Negative = True
        Me.dtfOficina.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfOficina.BackColor = System.Drawing.SystemColors.Control
        Me.dtfOficina.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfOficina.DataField = ""
        Me.dtfOficina.DataTable = ""
        Me.dtfOficina.DB = Connection1
        Me.dtfOficina.Desc_Datafield = "(NOMBRE + ' - ' + (SELECT SUB.NOMBRE FROM SUBLICEN AS SUB WHERE SUB.CODIGO = OFIC" & _
    "INAS.SUBLICEN) ) AS NOMBRE"
        Me.dtfOficina.Desc_DBPK = "CODIGO"
        Me.dtfOficina.Desc_DBTable = "OFICINAS"
        Me.dtfOficina.Desc_Where = "FEC_BAJA IS NULL"
        Me.dtfOficina.Desc_WhereObligatoria = Nothing
        Me.dtfOficina.Descripcion = "Oficina"
        Me.dtfOficina.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfOficina.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfOficina.ExtraSQL = "SUBLICEN"
        Me.dtfOficina.FocoEnAgregar = False
        Me.dtfOficina.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfOficina.Formulario = Nothing
        Me.dtfOficina.Label_Space = 50
        Me.dtfOficina.Length_Data = 32767
        Me.dtfOficina.Location = New System.Drawing.Point(91, 0)
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
        Me.dtfOficina.Size = New System.Drawing.Size(359, 26)
        Me.dtfOficina.TabIndex = 9
        Me.dtfOficina.Text_Data = ""
        Me.dtfOficina.Text_Data_Desc = ""
        Me.dtfOficina.Text_Width = 25
        Me.dtfOficina.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfOficina.TopPadding = 0
        Me.dtfOficina.Upper_Case = False
        Me.dtfOficina.Validate_on_lost_focus = True
        '
        'pnlSpace
        '
        Me.pnlSpace.Auto_Size = False
        Me.pnlSpace.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace.ChangeDock = True
        Me.pnlSpace.Control_Resize = False
        Me.pnlSpace.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace.isSpace = True
        Me.pnlSpace.Location = New System.Drawing.Point(85, 0)
        Me.pnlSpace.Name = "pnlSpace"
        Me.pnlSpace.numRows = 0
        Me.pnlSpace.Reorder = True
        Me.pnlSpace.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace.TabIndex = 8
        '
        'dtfEmpresa
        '
        Me.dtfEmpresa.Allow_Empty = True
        Me.dtfEmpresa.Allow_Negative = True
        Me.dtfEmpresa.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfEmpresa.BackColor = System.Drawing.SystemColors.Control
        Me.dtfEmpresa.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfEmpresa.DataField = ""
        Me.dtfEmpresa.DataTable = ""
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
        Me.dtfEmpresa.FocoEnAgregar = False
        Me.dtfEmpresa.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfEmpresa.Formulario = Nothing
        Me.dtfEmpresa.Label_Space = 60
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
        Me.dtfEmpresa.Size = New System.Drawing.Size(85, 26)
        Me.dtfEmpresa.TabIndex = 7
        Me.dtfEmpresa.TabStop = False
        Me.dtfEmpresa.Text_Data = ""
        Me.dtfEmpresa.Text_Data_Desc = ""
        Me.dtfEmpresa.Text_Width = 25
        Me.dtfEmpresa.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfEmpresa.TopPadding = 0
        Me.dtfEmpresa.Upper_Case = False
        Me.dtfEmpresa.Validate_on_lost_focus = True
        '
        'EmpresaOficina
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.dtfOficina)
        Me.Controls.Add(Me.pnlSpace)
        Me.Controls.Add(Me.dtfEmpresa)
        Me.Name = "EmpresaOficina"
        Me.Size = New System.Drawing.Size(450, 26)
        CType(Me.pnlSpace, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dtfOficina As CustomControls.DualDatafieldLabel
    Friend WithEvents pnlSpace As CustomControls.Panel
    Friend WithEvents dtfEmpresa As CustomControls.DualDatafieldLabel

End Class
