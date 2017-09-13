<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ExtrasVehiculo
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
        Dim Connection2 As ASADB.Connection = New ASADB.Connection()
        Me.PageViewPage1 = New CustomControls.PageViewPage()
        Me.pnlPpal = New CustomControls.Panel()
        Me.dtaObser = New CustomControls.DataAreaLabel()
        Me.dtfTipoVeh = New CustomControls.DualDatafieldLabel()
        Me.pnlBottomGen = New CustomControls.Panel()
        Me.dtlUltmodi = New CustomControls.DataLabel()
        Me.dtlUsumodi = New CustomControls.DataLabel()
        Me.dtfNombre = New CustomControls.DatafieldLabel()
        Me.pnlCodigo = New CustomControls.Panel()
        Me.dtfReferencia = New CustomControls.DatafieldLabel()
        Me.Panel1 = New CustomControls.Panel()
        Me.dtfCodigo = New CustomControls.DatafieldLabel()
        CType(Me.pnlBlock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pvwBase, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pvwBase.SuspendLayout()
        CType(Me.stbBase, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PageViewPage1.SuspendLayout()
        CType(Me.pnlPpal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPpal.SuspendLayout()
        CType(Me.pnlBottomGen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBottomGen.SuspendLayout()
        CType(Me.dtlUltmodi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtlUsumodi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlCodigo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCodigo.SuspendLayout()
        CType(Me.Panel1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.PageViewPage1.Controls.Add(Me.pnlPpal)
        Me.PageViewPage1.ItemSize = New System.Drawing.SizeF(56.0!, 23.0!)
        Me.PageViewPage1.Location = New System.Drawing.Point(129, 5)
        Me.PageViewPage1.Name = "PageViewPage1"
        Me.PageViewPage1.PanelCabezeraContainer = Nothing
        Me.PageViewPage1.Size = New System.Drawing.Size(1138, 500)
        Me.PageViewPage1.Text = "General"
        '
        'pnlPpal
        '
        Me.pnlPpal.Auto_Size = False
        Me.pnlPpal.BackColor = System.Drawing.SystemColors.Control
        Me.pnlPpal.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlPpal.ChangeDock = True
        Me.pnlPpal.Control_Resize = False
        Me.pnlPpal.Controls.Add(Me.dtaObser)
        Me.pnlPpal.Controls.Add(Me.dtfTipoVeh)
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
        Me.pnlPpal.Size = New System.Drawing.Size(1138, 446)
        Me.pnlPpal.TabIndex = 9
        '
        'dtaObser
        '
        Me.dtaObser.Allow_Empty = True
        Me.dtaObser.Allow_Negative = True
        Me.dtaObser.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtaObser.BackColor = System.Drawing.SystemColors.Control
        Me.dtaObser.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtaObser.DataField = "OBS"
        Me.dtaObser.DataTable = "EXVEH"
        Me.dtaObser.Descripcion = "Observaciones"
        Me.dtaObser.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtaObser.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtaObser.FocoEnAgregar = False
        Me.dtaObser.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtaObser.Length_Data = 32767
        Me.dtaObser.Location = New System.Drawing.Point(5, 87)
        Me.dtaObser.Max_Value = 0.0R
        Me.dtaObser.MensajeIncorrectoCustom = Nothing
        Me.dtaObser.Name = "dtaObser"
        Me.dtaObser.Null_on_Empty = True
        Me.dtaObser.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtaObser.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtaObser.ReadOnly_Data = False
        Me.dtaObser.Size = New System.Drawing.Size(1128, 124)
        Me.dtaObser.TabIndex = 3
        Me.dtaObser.Text_Data = ""
        Me.dtaObser.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtaObser.TopPadding = 0
        Me.dtaObser.Upper_Case = False
        Me.dtaObser.Validate_on_lost_focus = True
        '
        'dtfTipoVeh
        '
        Me.dtfTipoVeh.Allow_Empty = False
        Me.dtfTipoVeh.Allow_Negative = True
        Me.dtfTipoVeh.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfTipoVeh.BackColor = System.Drawing.SystemColors.Control
        Me.dtfTipoVeh.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfTipoVeh.DataField = "TIPO_VEHI"
        Me.dtfTipoVeh.DataTable = "EXVEH"
        Me.dtfTipoVeh.DB = Connection2
        Me.dtfTipoVeh.Desc_Datafield = "NOMBRE"
        Me.dtfTipoVeh.Desc_DBPK = "CODIGO"
        Me.dtfTipoVeh.Desc_DBTable = "CATEGO"
        Me.dtfTipoVeh.Desc_Where = Nothing
        Me.dtfTipoVeh.Desc_WhereObligatoria = Nothing
        Me.dtfTipoVeh.Descripcion = "Tipo Vehículo"
        Me.dtfTipoVeh.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfTipoVeh.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfTipoVeh.ExtraSQL = ""
        Me.dtfTipoVeh.FocoEnAgregar = False
        Me.dtfTipoVeh.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfTipoVeh.Formulario = Nothing
        Me.dtfTipoVeh.Label_Space = 88
        Me.dtfTipoVeh.Length_Data = 32767
        Me.dtfTipoVeh.Location = New System.Drawing.Point(5, 61)
        Me.dtfTipoVeh.Lupa = "hola"
        Me.dtfTipoVeh.Max_Value = 0.0R
        Me.dtfTipoVeh.MensajeIncorrectoCustom = Nothing
        Me.dtfTipoVeh.Name = "dtfTipoVeh"
        Me.dtfTipoVeh.Null_on_Empty = True
        Me.dtfTipoVeh.OpenForm = Nothing
        Me.dtfTipoVeh.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfTipoVeh.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfTipoVeh.Query_on_Text_Changed = True
        Me.dtfTipoVeh.ReadOnly_Data = False
        Me.dtfTipoVeh.ReQuery = False
        Me.dtfTipoVeh.ShowButton = True
        Me.dtfTipoVeh.Size = New System.Drawing.Size(1128, 26)
        Me.dtfTipoVeh.TabIndex = 2
        Me.dtfTipoVeh.Text_Data = ""
        Me.dtfTipoVeh.Text_Data_Desc = ""
        Me.dtfTipoVeh.Text_Width = 58
        Me.dtfTipoVeh.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfTipoVeh.TopPadding = 0
        Me.dtfTipoVeh.Upper_Case = False
        Me.dtfTipoVeh.Validate_on_lost_focus = True
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
        Me.pnlBottomGen.Size = New System.Drawing.Size(1128, 26)
        Me.pnlBottomGen.TabIndex = 4
        '
        'dtlUltmodi
        '
        Me.dtlUltmodi.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtlUltmodi.AutoSize = False
        Me.dtlUltmodi.BorderVisible = True
        Me.dtlUltmodi.DataField = "ULTMODI"
        Me.dtlUltmodi.DataTable = "EXVEH"
        Me.dtlUltmodi.Descripcion = ""
        Me.dtlUltmodi.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtlUltmodi.Fromat = CustomControls.DataLabel.fotmatType.ultmodi
        Me.dtlUltmodi.Location = New System.Drawing.Point(996, 6)
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
        Me.dtlUsumodi.DataTable = "EXVEH"
        Me.dtlUsumodi.Descripcion = ""
        Me.dtlUsumodi.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtlUsumodi.Fromat = CustomControls.DataLabel.fotmatType.plain
        Me.dtlUsumodi.Location = New System.Drawing.Point(952, 6)
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
        Me.dtfNombre.DataTable = "EXVEH"
        Me.dtfNombre.Descripcion = "Nombre"
        Me.dtfNombre.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfNombre.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfNombre.FocoEnAgregar = False
        Me.dtfNombre.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfNombre.Image = Nothing
        Me.dtfNombre.Label_Space = 88
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
        Me.dtfNombre.Size = New System.Drawing.Size(1128, 26)
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
        Me.pnlCodigo.Controls.Add(Me.dtfReferencia)
        Me.pnlCodigo.Controls.Add(Me.Panel1)
        Me.pnlCodigo.Controls.Add(Me.dtfCodigo)
        Me.pnlCodigo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCodigo.isSpace = False
        Me.pnlCodigo.Location = New System.Drawing.Point(5, 5)
        Me.pnlCodigo.Name = "pnlCodigo"
        Me.pnlCodigo.numRows = 0
        Me.pnlCodigo.Padding = New System.Windows.Forms.Padding(0, 5, 5, 5)
        Me.pnlCodigo.Reorder = True
        Me.pnlCodigo.Size = New System.Drawing.Size(1128, 30)
        Me.pnlCodigo.TabIndex = 0
        '
        'dtfReferencia
        '
        Me.dtfReferencia.Allow_Empty = False
        Me.dtfReferencia.Allow_Negative = True
        Me.dtfReferencia.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfReferencia.BackColor = System.Drawing.SystemColors.Control
        Me.dtfReferencia.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfReferencia.DataField = "REFERENCIA"
        Me.dtfReferencia.DataTable = "EXVEH"
        Me.dtfReferencia.Descripcion = "Referencia"
        Me.dtfReferencia.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfReferencia.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfReferencia.FocoEnAgregar = False
        Me.dtfReferencia.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfReferencia.Image = Nothing
        Me.dtfReferencia.Label_Space = 75
        Me.dtfReferencia.Length_Data = 32767
        Me.dtfReferencia.Location = New System.Drawing.Point(192, 5)
        Me.dtfReferencia.Max_Value = 0.0R
        Me.dtfReferencia.MensajeIncorrectoCustom = Nothing
        Me.dtfReferencia.Name = "dtfReferencia"
        Me.dtfReferencia.Null_on_Empty = True
        Me.dtfReferencia.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfReferencia.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfReferencia.ReadOnly_Data = False
        Me.dtfReferencia.Show_Button = False
        Me.dtfReferencia.Size = New System.Drawing.Size(668, 20)
        Me.dtfReferencia.TabIndex = 2
        Me.dtfReferencia.Text_Data = ""
        Me.dtfReferencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfReferencia.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfReferencia.TopPadding = 0
        Me.dtfReferencia.Upper_Case = False
        Me.dtfReferencia.Validate_on_lost_focus = True
        '
        'Panel1
        '
        Me.Panel1.Auto_Size = False
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.BorderColor = System.Drawing.SystemColors.Control
        Me.Panel1.ChangeDock = True
        Me.Panel1.Control_Resize = False
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.isSpace = False
        Me.Panel1.Location = New System.Drawing.Point(160, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.numRows = 0
        Me.Panel1.Reorder = True
        Me.Panel1.Size = New System.Drawing.Size(32, 20)
        Me.Panel1.TabIndex = 1
        '
        'dtfCodigo
        '
        Me.dtfCodigo.Allow_Empty = False
        Me.dtfCodigo.Allow_Negative = True
        Me.dtfCodigo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfCodigo.BackColor = System.Drawing.SystemColors.Control
        Me.dtfCodigo.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfCodigo.DataField = "CODIGO"
        Me.dtfCodigo.DataTable = "EXVEH"
        Me.dtfCodigo.Descripcion = "Código"
        Me.dtfCodigo.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfCodigo.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfCodigo.FocoEnAgregar = False
        Me.dtfCodigo.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfCodigo.Image = Nothing
        Me.dtfCodigo.Label_Space = 88
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
        'ExtrasVehiculo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1272, 695)
        Me.Name = "ExtrasVehiculo"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "ExtrasVehiculo"
        CType(Me.pnlBlock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pvwBase, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pvwBase.ResumeLayout(False)
        CType(Me.stbBase, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PageViewPage1.ResumeLayout(False)
        CType(Me.pnlPpal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPpal.ResumeLayout(False)
        CType(Me.pnlBottomGen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBottomGen.ResumeLayout(False)
        CType(Me.dtlUltmodi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtlUsumodi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlCodigo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCodigo.ResumeLayout(False)
        CType(Me.Panel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PageViewPage1 As CustomControls.PageViewPage
    Friend WithEvents pnlPpal As CustomControls.Panel
    Friend WithEvents pnlBottomGen As CustomControls.Panel
    Friend WithEvents dtlUltmodi As CustomControls.DataLabel
    Friend WithEvents dtlUsumodi As CustomControls.DataLabel
    Friend WithEvents dtfNombre As CustomControls.DatafieldLabel
    Friend WithEvents pnlCodigo As CustomControls.Panel
    Friend WithEvents dtfCodigo As CustomControls.DatafieldLabel
    Friend WithEvents dtfReferencia As CustomControls.DatafieldLabel
    Friend WithEvents Panel1 As CustomControls.Panel
    Friend WithEvents dtaObser As CustomControls.DataAreaLabel
    Friend WithEvents dtfTipoVeh As CustomControls.DualDatafieldLabel
End Class
