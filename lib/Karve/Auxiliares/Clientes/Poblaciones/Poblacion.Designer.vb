<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Poblacion
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
        Me.pwpGeneral = New CustomControls.PageViewPage()
        Me.Panel1 = New CustomControls.Panel()
        Me.dtfZona = New CustomControls.DualDatafieldLabel()
        Me.Panel2 = New CustomControls.Panel()
        Me.dtfPoblacion = New CustomControls.DatafieldLabel()
        Me.pnlSpace01 = New CustomControls.Panel()
        Me.dtfCP = New CustomControls.DualDataFieldEditableLabel()
        Me.dtfPais = New CustomControls.DualDatafieldLabel()
        CType(Me.pnlBlock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pvwBase, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pvwBase.SuspendLayout()
        CType(Me.stbBase, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pwpGeneral.SuspendLayout()
        CType(Me.Panel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.Panel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.pnlSpace01, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlBlock
        '
        Me.pnlBlock.Location = New System.Drawing.Point(0, 479)
        '
        'pvwBase
        '
        Me.pvwBase.Controls.Add(Me.pwpGeneral)
        Me.pvwBase.SelectedPage = Me.pwpGeneral
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
        'pwpGeneral
        '
        Me.pwpGeneral.Controls.Add(Me.Panel1)
        Me.pwpGeneral.ItemSize = New System.Drawing.SizeF(56.0!, 23.0!)
        Me.pwpGeneral.Location = New System.Drawing.Point(129, 5)
        Me.pwpGeneral.Name = "pwpGeneral"
        Me.pwpGeneral.PanelCabezeraContainer = Nothing
        Me.pwpGeneral.Size = New System.Drawing.Size(1224, 500)
        Me.pwpGeneral.Text = "General"
        '
        'Panel1
        '
        Me.Panel1.Auto_Size = False
        Me.Panel1.BorderColor = System.Drawing.SystemColors.Control
        Me.Panel1.ChangeDock = True
        Me.Panel1.Control_Resize = False
        Me.Panel1.Controls.Add(Me.dtfZona)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.dtfPais)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.isSpace = False
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.numRows = 0
        Me.Panel1.Reorder = True
        Me.Panel1.Size = New System.Drawing.Size(611, 500)
        Me.Panel1.TabIndex = 0
        '
        'dtfZona
        '
        Me.dtfZona.Allow_Empty = False
        Me.dtfZona.Allow_Negative = True
        Me.dtfZona.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfZona.BackColor = System.Drawing.SystemColors.Control
        Me.dtfZona.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfZona.DataField = "ZONA_CP"
        Me.dtfZona.DataTable = "POBL"
        Me.dtfZona.DB = Connection1
        Me.dtfZona.Desc_Datafield = "NOMBRE"
        Me.dtfZona.Desc_DBPK = "NUM_ZONA"
        Me.dtfZona.Desc_DBTable = "ZONAS"
        Me.dtfZona.Desc_Where = Nothing
        Me.dtfZona.Desc_WhereObligatoria = Nothing
        Me.dtfZona.Descripcion = "Zona"
        Me.dtfZona.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfZona.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfZona.ExtraSQL = ""
        Me.dtfZona.FocoEnAgregar = False
        Me.dtfZona.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfZona.Formulario = Nothing
        Me.dtfZona.Label_Space = 75
        Me.dtfZona.Length_Data = 32767
        Me.dtfZona.Location = New System.Drawing.Point(0, 52)
        Me.dtfZona.Lupa = "hola"
        Me.dtfZona.Max_Value = 0.0R
        Me.dtfZona.MensajeIncorrectoCustom = Nothing
        Me.dtfZona.Name = "dtfZona"
        Me.dtfZona.Null_on_Empty = True
        Me.dtfZona.OpenForm = Nothing
        Me.dtfZona.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfZona.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfZona.Query_on_Text_Changed = True
        Me.dtfZona.ReadOnly_Data = False
        Me.dtfZona.ReQuery = False
        Me.dtfZona.ShowButton = True
        Me.dtfZona.Size = New System.Drawing.Size(611, 26)
        Me.dtfZona.TabIndex = 2
        Me.dtfZona.Text_Data = ""
        Me.dtfZona.Text_Data_Desc = ""
        Me.dtfZona.Text_Width = 58
        Me.dtfZona.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfZona.TopPadding = 0
        Me.dtfZona.Upper_Case = False
        Me.dtfZona.Validate_on_lost_focus = True
        '
        'Panel2
        '
        Me.Panel2.Auto_Size = False
        Me.Panel2.BorderColor = System.Drawing.SystemColors.Control
        Me.Panel2.ChangeDock = True
        Me.Panel2.Control_Resize = False
        Me.Panel2.Controls.Add(Me.dtfPoblacion)
        Me.Panel2.Controls.Add(Me.pnlSpace01)
        Me.Panel2.Controls.Add(Me.dtfCP)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.isSpace = False
        Me.Panel2.Location = New System.Drawing.Point(0, 26)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.numRows = 1
        Me.Panel2.Reorder = True
        Me.Panel2.Size = New System.Drawing.Size(611, 26)
        Me.Panel2.TabIndex = 1
        '
        'dtfPoblacion
        '
        Me.dtfPoblacion.Allow_Empty = True
        Me.dtfPoblacion.Allow_Negative = True
        Me.dtfPoblacion.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfPoblacion.BackColor = System.Drawing.SystemColors.Control
        Me.dtfPoblacion.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfPoblacion.DataField = "POBLA"
        Me.dtfPoblacion.DataTable = "POBL"
        Me.dtfPoblacion.Descripcion = "Población"
        Me.dtfPoblacion.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfPoblacion.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfPoblacion.FocoEnAgregar = False
        Me.dtfPoblacion.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfPoblacion.Image = Nothing
        Me.dtfPoblacion.Label_Space = 75
        Me.dtfPoblacion.Length_Data = 32767
        Me.dtfPoblacion.Location = New System.Drawing.Point(165, 0)
        Me.dtfPoblacion.Max_Value = 0.0R
        Me.dtfPoblacion.MensajeIncorrectoCustom = Nothing
        Me.dtfPoblacion.Name = "dtfPoblacion"
        Me.dtfPoblacion.Null_on_Empty = True
        Me.dtfPoblacion.OpenForm = Nothing
        Me.dtfPoblacion.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfPoblacion.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfPoblacion.ReadOnly_Data = False
        Me.dtfPoblacion.Show_Button = False
        Me.dtfPoblacion.Size = New System.Drawing.Size(355, 26)
        Me.dtfPoblacion.TabIndex = 2
        Me.dtfPoblacion.Text_Data = ""
        Me.dtfPoblacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfPoblacion.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfPoblacion.TopPadding = 0
        Me.dtfPoblacion.Upper_Case = False
        Me.dtfPoblacion.Validate_on_lost_focus = True
        '
        'pnlSpace01
        '
        Me.pnlSpace01.Auto_Size = False
        Me.pnlSpace01.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace01.ChangeDock = True
        Me.pnlSpace01.Control_Resize = False
        Me.pnlSpace01.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace01.isSpace = True
        Me.pnlSpace01.Location = New System.Drawing.Point(159, 0)
        Me.pnlSpace01.Name = "pnlSpace01"
        Me.pnlSpace01.numRows = 0
        Me.pnlSpace01.Reorder = True
        Me.pnlSpace01.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace01.TabIndex = 1
        '
        'dtfCP
        '
        Me.dtfCP.Allow_Empty = False
        Me.dtfCP.Allow_Negative = True
        Me.dtfCP.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfCP.BackColor = System.Drawing.SystemColors.Control
        Me.dtfCP.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfCP.DataField = "CP"
        Me.dtfCP.DataField_DescEdit = Nothing
        Me.dtfCP.DataTable = "POBL"
        Me.dtfCP.DataTable_DescEdit = ""
        Me.dtfCP.DB = Connection2
        Me.dtfCP.Desc_Datafield = Nothing
        Me.dtfCP.Desc_DBPK = Nothing
        Me.dtfCP.Desc_DBTable = Nothing
        Me.dtfCP.Desc_Where = Nothing
        Me.dtfCP.Desc_WhereObligatoria = Nothing
        Me.dtfCP.Descripcion = "CP"
        Me.dtfCP.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfCP.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfCP.ExtraSQL = ""
        Me.dtfCP.FocoEnAgregar = False
        Me.dtfCP.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfCP.Formulario = Nothing
        Me.dtfCP.Label_Space = 75
        Me.dtfCP.Length_Data = 32767
        Me.dtfCP.Location = New System.Drawing.Point(0, 0)
        Me.dtfCP.Lupa = Nothing
        Me.dtfCP.Max_Value = 0.0R
        Me.dtfCP.MensajeIncorrectoCustom = Nothing
        Me.dtfCP.Name = "dtfCP"
        Me.dtfCP.Null_on_Empty = True
        Me.dtfCP.OpenForm = Nothing
        Me.dtfCP.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfCP.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfCP.Query_on_Text_Changed = True
        Me.dtfCP.ReadOnly_Data = False
        Me.dtfCP.ReadOnly_Desc = True
        Me.dtfCP.ReQuery = False
        Me.dtfCP.ShowButton = True
        Me.dtfCP.Size = New System.Drawing.Size(159, 26)
        Me.dtfCP.TabIndex = 0
        Me.dtfCP.Text_Data = ""
        Me.dtfCP.Text_Data_Desc = ""
        Me.dtfCP.Text_Width = 58
        Me.dtfCP.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfCP.TopPadding = 0
        Me.dtfCP.Upper_Case = False
        Me.dtfCP.Validate_on_lost_focus = True
        '
        'dtfPais
        '
        Me.dtfPais.Allow_Empty = False
        Me.dtfPais.Allow_Negative = True
        Me.dtfPais.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfPais.BackColor = System.Drawing.SystemColors.Control
        Me.dtfPais.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfPais.DataField = "PAIS"
        Me.dtfPais.DataTable = "POBL"
        Me.dtfPais.DB = Connection3
        Me.dtfPais.Desc_Datafield = "PAIS"
        Me.dtfPais.Desc_DBPK = "SIGLAS"
        Me.dtfPais.Desc_DBTable = "PAIS"
        Me.dtfPais.Desc_Where = Nothing
        Me.dtfPais.Desc_WhereObligatoria = Nothing
        Me.dtfPais.Descripcion = "País"
        Me.dtfPais.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfPais.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfPais.ExtraSQL = ""
        Me.dtfPais.FocoEnAgregar = False
        Me.dtfPais.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfPais.Formulario = Nothing
        Me.dtfPais.Label_Space = 75
        Me.dtfPais.Length_Data = 32767
        Me.dtfPais.Location = New System.Drawing.Point(0, 0)
        Me.dtfPais.Lupa = "hola"
        Me.dtfPais.Max_Value = 0.0R
        Me.dtfPais.MensajeIncorrectoCustom = Nothing
        Me.dtfPais.Name = "dtfPais"
        Me.dtfPais.Null_on_Empty = True
        Me.dtfPais.OpenForm = Nothing
        Me.dtfPais.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfPais.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfPais.Query_on_Text_Changed = True
        Me.dtfPais.ReadOnly_Data = False
        Me.dtfPais.ReQuery = False
        Me.dtfPais.ShowButton = True
        Me.dtfPais.Size = New System.Drawing.Size(611, 26)
        Me.dtfPais.TabIndex = 0
        Me.dtfPais.Text_Data = ""
        Me.dtfPais.Text_Data_Desc = ""
        Me.dtfPais.Text_Width = 58
        Me.dtfPais.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfPais.TopPadding = 0
        Me.dtfPais.Upper_Case = False
        Me.dtfPais.Validate_on_lost_focus = True
        '
        'Poblacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1358, 695)
        Me.Name = "Poblacion"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Poblacion"
        CType(Me.pnlBlock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pvwBase, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pvwBase.ResumeLayout(False)
        CType(Me.stbBase, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pwpGeneral.ResumeLayout(False)
        CType(Me.Panel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.Panel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.pnlSpace01, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pwpGeneral As CustomControls.PageViewPage
    Friend WithEvents Panel1 As CustomControls.Panel
    Friend WithEvents dtfZona As CustomControls.DualDatafieldLabel
    Friend WithEvents Panel2 As CustomControls.Panel
    Friend WithEvents dtfPoblacion As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace01 As CustomControls.Panel
    Friend WithEvents dtfCP As CustomControls.DualDataFieldEditableLabel
    Friend WithEvents dtfPais As CustomControls.DualDatafieldLabel
End Class
