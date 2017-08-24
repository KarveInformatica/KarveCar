<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Pais
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
        Dim Connection3 As ASADB.Connection = New ASADB.Connection()
        Me.PageViewPage1 = New CustomControls.PageViewPage()
        Me.pnlBottomGen = New CustomControls.Panel()
        Me.dtfIdioma = New CustomControls.DualDatafieldLabel()
        Me.dtcIntra = New CustomControls.DataCheck()
        Me.dtfNomIng = New CustomControls.DatafieldLabel()
        Me.dtfCodigo = New CustomControls.DatafieldLabel()
        Me.dtfSiglas = New CustomControls.DatafieldLabel()
        Me.dtfPais = New CustomControls.DatafieldLabel()
        Me.dtlUltmodi = New CustomControls.DataLabel()
        Me.dtlUsumodi = New CustomControls.DataLabel()
        CType(Me.pnlBlock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pvwBase, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pvwBase.SuspendLayout()
        CType(Me.stbBase, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PageViewPage1.SuspendLayout()
        CType(Me.pnlBottomGen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBottomGen.SuspendLayout()
        CType(Me.dtcIntra, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.PageViewPage1.Controls.Add(Me.pnlBottomGen)
        Me.PageViewPage1.Controls.Add(Me.dtfIdioma)
        Me.PageViewPage1.Controls.Add(Me.dtcIntra)
        Me.PageViewPage1.Controls.Add(Me.dtfNomIng)
        Me.PageViewPage1.Controls.Add(Me.dtfCodigo)
        Me.PageViewPage1.Controls.Add(Me.dtfSiglas)
        Me.PageViewPage1.Controls.Add(Me.dtfPais)
        Me.PageViewPage1.ItemSize = New System.Drawing.SizeF(56.0!, 23.0!)
        Me.PageViewPage1.Location = New System.Drawing.Point(129, 5)
        Me.PageViewPage1.Name = "PageViewPage1"
        Me.PageViewPage1.PanelCabezeraContainer = Nothing
        Me.PageViewPage1.Size = New System.Drawing.Size(1138, 500)
        Me.PageViewPage1.Text = "General"
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
        'dtfIdioma
        '
        Me.dtfIdioma.Allow_Empty = True
        Me.dtfIdioma.Allow_Negative = True
        Me.dtfIdioma.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfIdioma.BackColor = System.Drawing.SystemColors.Control
        Me.dtfIdioma.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfIdioma.DataField = "IDIOMA_PAIS"
        Me.dtfIdioma.DataTable = "P"
        Me.dtfIdioma.DB = Connection3
        Me.dtfIdioma.Desc_Datafield = "NOMBRE"
        Me.dtfIdioma.Desc_DBPK = "CODIGO"
        Me.dtfIdioma.Desc_DBTable = "IDIOMAS"
        Me.dtfIdioma.Desc_Where = Nothing
        Me.dtfIdioma.Desc_WhereObligatoria = Nothing
        Me.dtfIdioma.Descripcion = "Idioma"
        Me.dtfIdioma.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfIdioma.ExtraSQL = ""
        Me.dtfIdioma.FocoEnAgregar = False
        Me.dtfIdioma.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfIdioma.Formulario = Nothing
        Me.dtfIdioma.Label_Space = 75
        Me.dtfIdioma.Length_Data = 32767
        Me.dtfIdioma.Location = New System.Drawing.Point(14, 104)
        Me.dtfIdioma.Lupa = Nothing
        Me.dtfIdioma.Max_Value = 0.0R
        Me.dtfIdioma.MensajeIncorrectoCustom = Nothing
        Me.dtfIdioma.Name = "dtfIdioma"
        Me.dtfIdioma.Null_on_Empty = True
        Me.dtfIdioma.OpenForm = Nothing
        Me.dtfIdioma.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfIdioma.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfIdioma.Query_on_Text_Changed = True
        Me.dtfIdioma.ReadOnly_Data = False
        Me.dtfIdioma.ReQuery = False
        Me.dtfIdioma.ShowButton = True
        Me.dtfIdioma.Size = New System.Drawing.Size(256, 26)
        Me.dtfIdioma.TabIndex = 5
        Me.dtfIdioma.Text_Data = ""
        Me.dtfIdioma.Text_Data_Desc = ""
        Me.dtfIdioma.Text_Width = 58
        Me.dtfIdioma.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfIdioma.TopPadding = 0
        Me.dtfIdioma.Upper_Case = False
        Me.dtfIdioma.Validate_on_lost_focus = True
        '
        'dtcIntra
        '
        Me.dtcIntra.DataField = "INTRACO"
        Me.dtcIntra.DataTable = "P"
        Me.dtcIntra.Descripcion = "Intra."
        Me.dtcIntra.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtcIntra.Location = New System.Drawing.Point(249, 7)
        Me.dtcIntra.Name = "dtcIntra"
        Me.dtcIntra.Size = New System.Drawing.Size(55, 18)
        Me.dtcIntra.TabIndex = 2
        Me.dtcIntra.Text = "Intra."
        Me.dtcIntra.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtcIntra.ThemeName = "Windows8"
        Me.dtcIntra.Value = False
        '
        'dtfNomIng
        '
        Me.dtfNomIng.Allow_Empty = True
        Me.dtfNomIng.Allow_Negative = True
        Me.dtfNomIng.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfNomIng.BackColor = System.Drawing.SystemColors.Control
        Me.dtfNomIng.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfNomIng.DataField = "NOM_INGLES"
        Me.dtfNomIng.DataTable = "P"
        Me.dtfNomIng.Descripcion = "Nom.Inglés"
        Me.dtfNomIng.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfNomIng.FocoEnAgregar = False
        Me.dtfNomIng.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfNomIng.Image = Nothing
        Me.dtfNomIng.Label_Space = 75
        Me.dtfNomIng.Length_Data = 32767
        Me.dtfNomIng.Location = New System.Drawing.Point(14, 71)
        Me.dtfNomIng.Max_Value = 0.0R
        Me.dtfNomIng.MensajeIncorrectoCustom = Nothing
        Me.dtfNomIng.Name = "dtfNomIng"
        Me.dtfNomIng.Null_on_Empty = True
        Me.dtfNomIng.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfNomIng.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfNomIng.ReadOnly_Data = False
        Me.dtfNomIng.Show_Button = False
        Me.dtfNomIng.Size = New System.Drawing.Size(229, 26)
        Me.dtfNomIng.TabIndex = 4
        Me.dtfNomIng.Text_Data = ""
        Me.dtfNomIng.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfNomIng.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfNomIng.TopPadding = 0
        Me.dtfNomIng.Upper_Case = False
        Me.dtfNomIng.Validate_on_lost_focus = True
        '
        'dtfCodigo
        '
        Me.dtfCodigo.Allow_Empty = True
        Me.dtfCodigo.Allow_Negative = True
        Me.dtfCodigo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfCodigo.BackColor = System.Drawing.SystemColors.Control
        Me.dtfCodigo.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfCodigo.DataField = "SIGLAS"
        Me.dtfCodigo.DataTable = "P"
        Me.dtfCodigo.Descripcion = "Código"
        Me.dtfCodigo.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfCodigo.FocoEnAgregar = False
        Me.dtfCodigo.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfCodigo.Image = Nothing
        Me.dtfCodigo.Label_Space = 75
        Me.dtfCodigo.Length_Data = 32767
        Me.dtfCodigo.Location = New System.Drawing.Point(14, 7)
        Me.dtfCodigo.Max_Value = 0.0R
        Me.dtfCodigo.MensajeIncorrectoCustom = Nothing
        Me.dtfCodigo.Name = "dtfCodigo"
        Me.dtfCodigo.Null_on_Empty = True
        Me.dtfCodigo.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfCodigo.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfCodigo.ReadOnly_Data = True
        Me.dtfCodigo.Show_Button = False
        Me.dtfCodigo.Size = New System.Drawing.Size(113, 26)
        Me.dtfCodigo.TabIndex = 0
        Me.dtfCodigo.TabStop = False
        Me.dtfCodigo.Text_Data = ""
        Me.dtfCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfCodigo.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfCodigo.TopPadding = 0
        Me.dtfCodigo.Upper_Case = False
        Me.dtfCodigo.Validate_on_lost_focus = True
        '
        'dtfSiglas
        '
        Me.dtfSiglas.Allow_Empty = True
        Me.dtfSiglas.Allow_Negative = True
        Me.dtfSiglas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfSiglas.BackColor = System.Drawing.SystemColors.Control
        Me.dtfSiglas.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfSiglas.DataField = "SIGLAS3"
        Me.dtfSiglas.DataTable = "P"
        Me.dtfSiglas.Descripcion = "Siglas"
        Me.dtfSiglas.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfSiglas.FocoEnAgregar = False
        Me.dtfSiglas.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfSiglas.Image = Nothing
        Me.dtfSiglas.Label_Space = 75
        Me.dtfSiglas.Length_Data = 32767
        Me.dtfSiglas.Location = New System.Drawing.Point(133, 7)
        Me.dtfSiglas.Max_Value = 0.0R
        Me.dtfSiglas.MensajeIncorrectoCustom = Nothing
        Me.dtfSiglas.Name = "dtfSiglas"
        Me.dtfSiglas.Null_on_Empty = True
        Me.dtfSiglas.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfSiglas.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfSiglas.ReadOnly_Data = False
        Me.dtfSiglas.Show_Button = False
        Me.dtfSiglas.Size = New System.Drawing.Size(110, 26)
        Me.dtfSiglas.TabIndex = 1
        Me.dtfSiglas.Text_Data = ""
        Me.dtfSiglas.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfSiglas.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfSiglas.TopPadding = 0
        Me.dtfSiglas.Upper_Case = False
        Me.dtfSiglas.Validate_on_lost_focus = True
        '
        'dtfPais
        '
        Me.dtfPais.Allow_Empty = False
        Me.dtfPais.Allow_Negative = True
        Me.dtfPais.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfPais.BackColor = System.Drawing.SystemColors.Control
        Me.dtfPais.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfPais.DataField = "PAIS"
        Me.dtfPais.DataTable = "P"
        Me.dtfPais.Descripcion = "País"
        Me.dtfPais.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfPais.FocoEnAgregar = False
        Me.dtfPais.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfPais.Image = Nothing
        Me.dtfPais.Label_Space = 75
        Me.dtfPais.Length_Data = 32767
        Me.dtfPais.Location = New System.Drawing.Point(14, 39)
        Me.dtfPais.Max_Value = 0.0R
        Me.dtfPais.MensajeIncorrectoCustom = Nothing
        Me.dtfPais.Name = "dtfPais"
        Me.dtfPais.Null_on_Empty = True
        Me.dtfPais.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfPais.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfPais.ReadOnly_Data = False
        Me.dtfPais.Show_Button = False
        Me.dtfPais.Size = New System.Drawing.Size(229, 26)
        Me.dtfPais.TabIndex = 3
        Me.dtfPais.Text_Data = ""
        Me.dtfPais.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfPais.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfPais.TopPadding = 0
        Me.dtfPais.Upper_Case = False
        Me.dtfPais.Validate_on_lost_focus = True
        '
        'dtlUltmodi
        '
        Me.dtlUltmodi.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtlUltmodi.AutoSize = False
        Me.dtlUltmodi.BorderVisible = True
        Me.dtlUltmodi.DataField = "ULTMODI"
        Me.dtlUltmodi.DataTable = "P"
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
        Me.dtlUsumodi.DataTable = "P"
        Me.dtlUsumodi.Descripcion = ""
        Me.dtlUsumodi.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtlUsumodi.Fromat = CustomControls.DataLabel.fotmatType.plain
        Me.dtlUsumodi.Location = New System.Drawing.Point(962, 6)
        Me.dtlUsumodi.Name = "dtlUsumodi"
        Me.dtlUsumodi.Size = New System.Drawing.Size(38, 17)
        Me.dtlUsumodi.TabIndex = 0
        Me.dtlUsumodi.TextAlignment = System.Drawing.ContentAlignment.TopCenter
        '
        'Pais
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1272, 695)
        Me.Name = "Pais"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Pais"
        CType(Me.pnlBlock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pvwBase, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pvwBase.ResumeLayout(False)
        CType(Me.stbBase, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PageViewPage1.ResumeLayout(False)
        Me.PageViewPage1.PerformLayout()
        CType(Me.pnlBottomGen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBottomGen.ResumeLayout(False)
        CType(Me.dtcIntra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtlUltmodi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtlUsumodi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PageViewPage1 As CustomControls.PageViewPage
    Friend WithEvents dtfSiglas As CustomControls.DatafieldLabel
    Friend WithEvents dtfPais As CustomControls.DatafieldLabel
    Friend WithEvents dtfNomIng As CustomControls.DatafieldLabel
    Friend WithEvents dtfCodigo As CustomControls.DatafieldLabel
    Friend WithEvents dtcIntra As CustomControls.DataCheck
    Friend WithEvents dtfIdioma As CustomControls.DualDatafieldLabel
    Friend WithEvents pnlBottomGen As CustomControls.Panel
    Friend WithEvents dtlUltmodi As CustomControls.DataLabel
    Friend WithEvents dtlUsumodi As CustomControls.DataLabel
End Class
