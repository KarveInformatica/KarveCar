<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Provincia
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
        Me.PageViewPage1 = New CustomControls.PageViewPage()
        Me.dtfSiglas = New CustomControls.DatafieldLabel()
        Me.dtfPrefijo = New CustomControls.DatafieldLabel()
        Me.pnlBottomGen = New CustomControls.Panel()
        Me.dtlUltmodi = New CustomControls.DataLabel()
        Me.dtlUsumodi = New CustomControls.DataLabel()
        Me.dtfPais = New CustomControls.DualDatafieldLabel()
        Me.dtfCapital = New CustomControls.DatafieldLabel()
        Me.dtfProvincia = New CustomControls.DatafieldLabel()
        CType(Me.pnlBlock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pvwBase, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pvwBase.SuspendLayout()
        CType(Me.stbBase, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PageViewPage1.SuspendLayout()
        CType(Me.pnlBottomGen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBottomGen.SuspendLayout()
        CType(Me.dtlUltmodi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtlUsumodi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlBlock
        '
        Me.pnlBlock.Location = New System.Drawing.Point(0, 454)
        '
        'pvwBase
        '
        Me.pvwBase.Controls.Add(Me.PageViewPage1)
        Me.pvwBase.SelectedPage = Me.PageViewPage1
        Me.pvwBase.Size = New System.Drawing.Size(1272, 510)
        Me.pvwBase.Text = ""
        '
        'stbBase
        '
        Me.stbBase.Location = New System.Drawing.Point(0, 510)
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
        'PageViewPage1
        '
        Me.PageViewPage1.Controls.Add(Me.dtfSiglas)
        Me.PageViewPage1.Controls.Add(Me.dtfPrefijo)
        Me.PageViewPage1.Controls.Add(Me.pnlBottomGen)
        Me.PageViewPage1.Controls.Add(Me.dtfPais)
        Me.PageViewPage1.Controls.Add(Me.dtfCapital)
        Me.PageViewPage1.Controls.Add(Me.dtfProvincia)
        Me.PageViewPage1.ItemSize = New System.Drawing.SizeF(56.0!, 23.0!)
        Me.PageViewPage1.Location = New System.Drawing.Point(129, 5)
        Me.PageViewPage1.Name = "PageViewPage1"
        Me.PageViewPage1.PanelCabezeraContainer = Nothing
        Me.PageViewPage1.Size = New System.Drawing.Size(1138, 500)
        Me.PageViewPage1.Text = "General"
        '
        'dtfSiglas
        '
        Me.dtfSiglas.Allow_Empty = True
        Me.dtfSiglas.Allow_Negative = False
        Me.dtfSiglas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfSiglas.BackColor = System.Drawing.SystemColors.Control
        Me.dtfSiglas.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfSiglas.DataField = "ABREVIA"
        Me.dtfSiglas.DataTable = "PROV"
        Me.dtfSiglas.Descripcion = "Abreviatura"
        Me.dtfSiglas.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfSiglas.FocoEnAgregar = False
        Me.dtfSiglas.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfSiglas.Image = Nothing
        Me.dtfSiglas.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dtfSiglas.Label_Space = 75
        Me.dtfSiglas.Length_Data = 32767
        Me.dtfSiglas.Location = New System.Drawing.Point(14, 33)
        Me.dtfSiglas.Max_Value = 0.0R
        Me.dtfSiglas.MensajeIncorrectoCustom = Nothing
        Me.dtfSiglas.Name = "dtfSiglas"
        Me.dtfSiglas.Null_on_Empty = True
        Me.dtfSiglas.OpenForm = Nothing
        Me.dtfSiglas.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfSiglas.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfSiglas.ReadOnly_Data = False
        Me.dtfSiglas.Show_Button = False
        Me.dtfSiglas.Size = New System.Drawing.Size(117, 26)
        Me.dtfSiglas.TabIndex = 2
        Me.dtfSiglas.Text_Data = ""
        Me.dtfSiglas.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfSiglas.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfSiglas.TopPadding = 0
        Me.dtfSiglas.Upper_Case = False
        Me.dtfSiglas.Validate_on_lost_focus = True
        '
        'dtfPrefijo
        '
        Me.dtfPrefijo.Allow_Empty = True
        Me.dtfPrefijo.Allow_Negative = False
        Me.dtfPrefijo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfPrefijo.BackColor = System.Drawing.SystemColors.Control
        Me.dtfPrefijo.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfPrefijo.DataField = "PREFIJO"
        Me.dtfPrefijo.DataTable = "PROV"
        Me.dtfPrefijo.Descripcion = "Prefijo"
        Me.dtfPrefijo.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfPrefijo.FocoEnAgregar = False
        Me.dtfPrefijo.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfPrefijo.Image = Nothing
        Me.dtfPrefijo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dtfPrefijo.Label_Space = 75
        Me.dtfPrefijo.Length_Data = 32767
        Me.dtfPrefijo.Location = New System.Drawing.Point(14, 129)
        Me.dtfPrefijo.Max_Value = 0.0R
        Me.dtfPrefijo.MensajeIncorrectoCustom = Nothing
        Me.dtfPrefijo.Name = "dtfPrefijo"
        Me.dtfPrefijo.Null_on_Empty = True
        Me.dtfPrefijo.OpenForm = Nothing
        Me.dtfPrefijo.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfPrefijo.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfPrefijo.ReadOnly_Data = False
        Me.dtfPrefijo.Show_Button = False
        Me.dtfPrefijo.Size = New System.Drawing.Size(131, 26)
        Me.dtfPrefijo.TabIndex = 5
        Me.dtfPrefijo.Text_Data = ""
        Me.dtfPrefijo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfPrefijo.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfPrefijo.TopPadding = 0
        Me.dtfPrefijo.Upper_Case = False
        Me.dtfPrefijo.Validate_on_lost_focus = True
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
        Me.pnlBottomGen.Location = New System.Drawing.Point(0, 474)
        Me.pnlBottomGen.Name = "pnlBottomGen"
        Me.pnlBottomGen.numRows = 1
        Me.pnlBottomGen.Reorder = True
        Me.pnlBottomGen.Size = New System.Drawing.Size(1138, 26)
        Me.pnlBottomGen.TabIndex = 6
        '
        'dtlUltmodi
        '
        Me.dtlUltmodi.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtlUltmodi.AutoSize = False
        Me.dtlUltmodi.BorderVisible = True
        Me.dtlUltmodi.DataField = "ULTMODI"
        Me.dtlUltmodi.DataTable = "PROV"
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
        Me.dtlUsumodi.DataField = "USUARIO"
        Me.dtlUsumodi.DataTable = "PROV"
        Me.dtlUsumodi.Descripcion = ""
        Me.dtlUsumodi.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtlUsumodi.Fromat = CustomControls.DataLabel.fotmatType.plain
        Me.dtlUsumodi.Location = New System.Drawing.Point(962, 6)
        Me.dtlUsumodi.Name = "dtlUsumodi"
        Me.dtlUsumodi.Size = New System.Drawing.Size(38, 17)
        Me.dtlUsumodi.TabIndex = 0
        Me.dtlUsumodi.TextAlignment = System.Drawing.ContentAlignment.TopCenter
        '
        'dtfPais
        '
        Me.dtfPais.Allow_Empty = False
        Me.dtfPais.Allow_Negative = True
        Me.dtfPais.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfPais.BackColor = System.Drawing.SystemColors.Control
        Me.dtfPais.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfPais.DataField = "PAIS"
        Me.dtfPais.DataTable = "PROV"
        Me.dtfPais.DB = Connection1
        Me.dtfPais.Desc_Datafield = "PAIS"
        Me.dtfPais.Desc_DBPK = "SIGLAS"
        Me.dtfPais.Desc_DBTable = "PAIS"
        Me.dtfPais.Desc_Where = Nothing
        Me.dtfPais.Desc_WhereObligatoria = Nothing
        Me.dtfPais.Descripcion = "País"
        Me.dtfPais.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfPais.ExtraSQL = ""
        Me.dtfPais.FocoEnAgregar = False
        Me.dtfPais.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfPais.Formulario = Nothing
        Me.dtfPais.Label_Space = 75
        Me.dtfPais.Length_Data = 32767
        Me.dtfPais.Location = New System.Drawing.Point(14, 3)
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
        Me.dtfPais.Size = New System.Drawing.Size(256, 26)
        Me.dtfPais.TabIndex = 1
        Me.dtfPais.Text_Data = ""
        Me.dtfPais.Text_Data_Desc = ""
        Me.dtfPais.Text_Width = 58
        Me.dtfPais.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfPais.TopPadding = 0
        Me.dtfPais.Upper_Case = False
        Me.dtfPais.Validate_on_lost_focus = True
        '
        'dtfCapital
        '
        Me.dtfCapital.Allow_Empty = True
        Me.dtfCapital.Allow_Negative = True
        Me.dtfCapital.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfCapital.BackColor = System.Drawing.SystemColors.Control
        Me.dtfCapital.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfCapital.DataField = "CAPITAL"
        Me.dtfCapital.DataTable = "PROV"
        Me.dtfCapital.Descripcion = "Capital"
        Me.dtfCapital.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfCapital.FocoEnAgregar = False
        Me.dtfCapital.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfCapital.Image = Nothing
        Me.dtfCapital.Label_Space = 75
        Me.dtfCapital.Length_Data = 32767
        Me.dtfCapital.Location = New System.Drawing.Point(14, 97)
        Me.dtfCapital.Max_Value = 0.0R
        Me.dtfCapital.MensajeIncorrectoCustom = Nothing
        Me.dtfCapital.Name = "dtfCapital"
        Me.dtfCapital.Null_on_Empty = True
        Me.dtfCapital.OpenForm = Nothing
        Me.dtfCapital.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfCapital.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfCapital.ReadOnly_Data = False
        Me.dtfCapital.Show_Button = False
        Me.dtfCapital.Size = New System.Drawing.Size(229, 26)
        Me.dtfCapital.TabIndex = 4
        Me.dtfCapital.Text_Data = ""
        Me.dtfCapital.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfCapital.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfCapital.TopPadding = 0
        Me.dtfCapital.Upper_Case = False
        Me.dtfCapital.Validate_on_lost_focus = True
        '
        'dtfProvincia
        '
        Me.dtfProvincia.Allow_Empty = False
        Me.dtfProvincia.Allow_Negative = True
        Me.dtfProvincia.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfProvincia.BackColor = System.Drawing.SystemColors.Control
        Me.dtfProvincia.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfProvincia.DataField = "PROV"
        Me.dtfProvincia.DataTable = "PROV"
        Me.dtfProvincia.Descripcion = "Provincia"
        Me.dtfProvincia.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfProvincia.FocoEnAgregar = False
        Me.dtfProvincia.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfProvincia.Image = Nothing
        Me.dtfProvincia.Label_Space = 75
        Me.dtfProvincia.Length_Data = 32767
        Me.dtfProvincia.Location = New System.Drawing.Point(14, 65)
        Me.dtfProvincia.Max_Value = 0.0R
        Me.dtfProvincia.MensajeIncorrectoCustom = Nothing
        Me.dtfProvincia.Name = "dtfProvincia"
        Me.dtfProvincia.Null_on_Empty = True
        Me.dtfProvincia.OpenForm = Nothing
        Me.dtfProvincia.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfProvincia.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfProvincia.ReadOnly_Data = False
        Me.dtfProvincia.Show_Button = False
        Me.dtfProvincia.Size = New System.Drawing.Size(229, 26)
        Me.dtfProvincia.TabIndex = 3
        Me.dtfProvincia.Text_Data = ""
        Me.dtfProvincia.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfProvincia.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfProvincia.TopPadding = 0
        Me.dtfProvincia.Upper_Case = False
        Me.dtfProvincia.Validate_on_lost_focus = True
        '
        'Provincia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1272, 695)
        Me.Name = "Provincia"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Provincia"
        CType(Me.pnlBlock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pvwBase, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pvwBase.ResumeLayout(False)
        CType(Me.stbBase, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PageViewPage1.ResumeLayout(False)
        CType(Me.pnlBottomGen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBottomGen.ResumeLayout(False)
        CType(Me.dtlUltmodi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtlUsumodi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PageViewPage1 As CustomControls.PageViewPage
    Friend WithEvents dtfCapital As CustomControls.DatafieldLabel
    Friend WithEvents dtfPais As CustomControls.DualDatafieldLabel
    Friend WithEvents pnlBottomGen As CustomControls.Panel
    Friend WithEvents dtlUltmodi As CustomControls.DataLabel
    Friend WithEvents dtlUsumodi As CustomControls.DataLabel
    Friend WithEvents dtfProvincia As CustomControls.DatafieldLabel
    Friend WithEvents dtfPrefijo As CustomControls.DatafieldLabel
    Friend WithEvents dtfSiglas As CustomControls.DatafieldLabel
End Class
