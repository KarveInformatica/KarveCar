<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ColoresVehiculo
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
        Me.rdgTipoPintura = New CustomControls.RadioGroup()
        Me.radSinMetalizar = New CustomControls.DataRadio()
        Me.radBicolor = New CustomControls.DataRadio()
        Me.radMetalizada = New CustomControls.DataRadio()
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
        CType(Me.rdgTipoPintura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rdgTipoPintura.SuspendLayout()
        CType(Me.radSinMetalizar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.radBicolor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.radMetalizada, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pnlBlock.Location = New System.Drawing.Point(0, 547)
        '
        'pvwBase
        '
        Me.pvwBase.Controls.Add(Me.pvpGeneral)
        Me.pvwBase.SelectedPage = Me.pvpGeneral
        Me.pvwBase.Size = New System.Drawing.Size(1016, 454)
        '
        'rbgEdicion
        '
        Me.rbgEdicion.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.rbgEdicion.Bounds = New System.Drawing.Rectangle(0, 0, 246, 96)
        Me.rbgEdicion.ForeColor = System.Drawing.Color.Black
        '
        'pvpGeneral
        '
        Me.pvpGeneral.Controls.Add(Me.pnlPpal)
        Me.pvpGeneral.ItemSize = New System.Drawing.SizeF(51.0!, 24.0!)
        Me.pvpGeneral.Location = New System.Drawing.Point(129, 5)
        Me.pvpGeneral.Name = "pvpGeneral"
        Me.pvpGeneral.Size = New System.Drawing.Size(882, 444)
        Me.pvpGeneral.Text = "General"
        '
        'pnlPpal
        '
        Me.pnlPpal.Auto_Size = False
        Me.pnlPpal.BackColor = System.Drawing.SystemColors.Control
        Me.pnlPpal.BorderColor = System.Drawing.Color.Transparent
        Me.pnlPpal.ChangeDock = True
        Me.pnlPpal.Control_Resize = False
        Me.pnlPpal.Controls.Add(Me.rdgTipoPintura)
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
        Me.pnlPpal.Size = New System.Drawing.Size(882, 446)
        Me.pnlPpal.TabIndex = 10
        '
        'rdgTipoPintura
        '
        Me.rdgTipoPintura.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.rdgTipoPintura.Controls.Add(Me.radSinMetalizar)
        Me.rdgTipoPintura.Controls.Add(Me.radBicolor)
        Me.rdgTipoPintura.Controls.Add(Me.radMetalizada)
        Me.rdgTipoPintura.DataField = "TIPOCOLOR"
        Me.rdgTipoPintura.DataTable = "CLF"
        Me.rdgTipoPintura.Descripcion = ""
        Me.rdgTipoPintura.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.rdgTipoPintura.HeaderText = ""
        Me.rdgTipoPintura.Index = Nothing
        Me.rdgTipoPintura.Location = New System.Drawing.Point(8, 62)
        Me.rdgTipoPintura.Name = "rdgTipoPintura"
        Me.rdgTipoPintura.numRows = 0
        Me.rdgTipoPintura.Padding = New System.Windows.Forms.Padding(6, 18, 6, 6)
        Me.rdgTipoPintura.Reorder = True
        Me.rdgTipoPintura.Size = New System.Drawing.Size(295, 29)
        Me.rdgTipoPintura.TabIndex = 2
        Me.rdgTipoPintura.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.rdgTipoPintura.ThemeName = "Windows8"
        Me.rdgTipoPintura.Title = ""
        '
        'radSinMetalizar
        '
        Me.radSinMetalizar.BackColor = System.Drawing.SystemColors.Control
        Me.radSinMetalizar.Checked = False
        Me.radSinMetalizar.Descripcion = "Sin Metalizar"
        Me.radSinMetalizar.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.radSinMetalizar.Index = "S"
        Me.radSinMetalizar.Location = New System.Drawing.Point(177, 6)
        Me.radSinMetalizar.Name = "radSinMetalizar"
        Me.radSinMetalizar.Size = New System.Drawing.Size(97, 18)
        Me.radSinMetalizar.TabIndex = 2
        Me.radSinMetalizar.Text = "Sin Metalizar"
        Me.radSinMetalizar.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.radSinMetalizar.ThemeName = "Windows8"
        '
        'radBicolor
        '
        Me.radBicolor.BackColor = System.Drawing.SystemColors.Control
        Me.radBicolor.Checked = False
        Me.radBicolor.Descripcion = "Bicolor"
        Me.radBicolor.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.radBicolor.Index = "B"
        Me.radBicolor.Location = New System.Drawing.Point(109, 6)
        Me.radBicolor.Name = "radBicolor"
        Me.radBicolor.Size = New System.Drawing.Size(62, 18)
        Me.radBicolor.TabIndex = 0
        Me.radBicolor.Text = "Bicolor"
        Me.radBicolor.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.radBicolor.ThemeName = "Windows8"
        '
        'radMetalizada
        '
        Me.radMetalizada.BackColor = System.Drawing.SystemColors.Control
        Me.radMetalizada.Checked = False
        Me.radMetalizada.Descripcion = "Metalizada"
        Me.radMetalizada.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.radMetalizada.Index = "M"
        Me.radMetalizada.Location = New System.Drawing.Point(22, 7)
        Me.radMetalizada.Name = "radMetalizada"
        Me.radMetalizada.Size = New System.Drawing.Size(81, 17)
        Me.radMetalizada.TabIndex = 1
        Me.radMetalizada.Text = "Metalizada"
        Me.radMetalizada.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.radMetalizada.ThemeName = "Windows8"
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
        Me.pnlBottomGen.Location = New System.Drawing.Point(5, 415)
        Me.pnlBottomGen.Name = "pnlBottomGen"
        Me.pnlBottomGen.numRows = 1
        Me.pnlBottomGen.Reorder = True
        Me.pnlBottomGen.Size = New System.Drawing.Size(872, 26)
        Me.pnlBottomGen.TabIndex = 3
        '
        'dtlUltmodi
        '
        Me.dtlUltmodi.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtlUltmodi.AutoSize = False
        Me.dtlUltmodi.BorderVisible = True
        Me.dtlUltmodi.DataField = "ULTMODI"
        Me.dtlUltmodi.DataTable = "CLF"
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
        Me.dtlUsumodi.DataTable = "CLF"
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
        Me.dtfNombre.DataTable = "CLF"
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
        Me.dtfNombre.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfNombre.TopPadding = 0
        Me.dtfNombre.Upper_Case = False
        Me.dtfNombre.Validate_on_lost_focus = True
        '
        'pnlCodigo
        '
        Me.pnlCodigo.Auto_Size = False
        Me.pnlCodigo.BackColor = System.Drawing.SystemColors.Control
        Me.pnlCodigo.BorderColor = System.Drawing.Color.Transparent
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
        Me.dtfCodigo.DataTable = "CLF"
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
        Me.dtfCodigo.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfCodigo.TopPadding = 0
        Me.dtfCodigo.Upper_Case = True
        Me.dtfCodigo.Validate_on_lost_focus = True
        '
        'ColoresVehiculo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1016, 639)
        Me.Name = "ColoresVehiculo"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Coloresvehiculo"
        CType(Me.pnlBlock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pvwBase, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pvwBase.ResumeLayout(False)
        CType(Me.stbBase, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pvpGeneral.ResumeLayout(False)
        CType(Me.pnlPpal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPpal.ResumeLayout(False)
        CType(Me.rdgTipoPintura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rdgTipoPintura.ResumeLayout(False)
        Me.rdgTipoPintura.PerformLayout()
        CType(Me.radSinMetalizar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.radBicolor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.radMetalizada, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents rdgTipoPintura As CustomControls.RadioGroup
    Friend WithEvents radMetalizada As CustomControls.DataRadio
    Friend WithEvents radSinMetalizar As CustomControls.DataRadio
    Friend WithEvents radBicolor As CustomControls.DataRadio
End Class
