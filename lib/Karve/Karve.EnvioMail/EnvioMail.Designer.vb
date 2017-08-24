<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EnvioMail
    Inherits CrystalPreview.CrystalViewer

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
        Me.RibbonTab1 = New Telerik.WinControls.UI.RibbonTab()
        Me.RadRibbonBarGroup1 = New Telerik.WinControls.UI.RadRibbonBarGroup()
        Me.rbgEMail = New Telerik.WinControls.UI.RadRibbonBarGroup()
        Me.btnEnviar = New Telerik.WinControls.UI.RadButtonElement()
        Me.pnlRpt = New CustomControls.Panel()
        Me.pnlMail = New CustomControls.Panel()
        Me.drfBody = New CustomControls.DataRichField()
        Me.dtfTextoEstandar = New CustomControls.DualDatafieldLabel()
        Me.flsAttachments = New CustomControls.FilesSelector()
        Me.dtfSubject = New CustomControls.DatafieldLabel()
        Me.dtfRcpt = New CustomControls.DatafieldLabel()
        Me.dtfFrom = New CustomControls.DatafieldLabel()
        CType(Me.stbStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlRpt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlMail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMail.SuspendLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rbgImpresion
        '
        Me.rbgImpresion.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.rbgImpresion.Bounds = New System.Drawing.Rectangle(0, 0, 126, 92)
        Me.rbgImpresion.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.rbgImpresion.ForeColor = System.Drawing.Color.Black
        Me.rbgImpresion.Margin = New System.Windows.Forms.Padding(2)
        Me.rbgImpresion.MaxSize = New System.Drawing.Size(0, 100)
        Me.rbgImpresion.MinSize = New System.Drawing.Size(20, 86)
        '
        'btnPrint
        '
        Me.btnPrint.BackColor = System.Drawing.Color.Transparent
        Me.btnPrint.Bounds = New System.Drawing.Rectangle(0, 0, 52, 70)
        Me.btnPrint.CanFocus = True
        Me.btnPrint.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.btnPrint.ForeColor = System.Drawing.Color.Black
        '
        'btnExport
        '
        Me.btnExport.BackColor = System.Drawing.Color.Transparent
        Me.btnExport.Bounds = New System.Drawing.Rectangle(0, 0, 52, 70)
        Me.btnExport.CanFocus = True
        Me.btnExport.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.btnExport.ForeColor = System.Drawing.Color.Black
        '
        'rbgNavegacion
        '
        Me.rbgNavegacion.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.rbgNavegacion.Bounds = New System.Drawing.Rectangle(0, 0, 218, 92)
        Me.rbgNavegacion.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.rbgNavegacion.ForeColor = System.Drawing.Color.Black
        Me.rbgNavegacion.Margin = New System.Windows.Forms.Padding(2)
        Me.rbgNavegacion.MaxSize = New System.Drawing.Size(0, 100)
        Me.rbgNavegacion.MinSize = New System.Drawing.Size(20, 86)
        '
        'btnFirstPage
        '
        Me.btnFirstPage.BackColor = System.Drawing.Color.Transparent
        Me.btnFirstPage.Bounds = New System.Drawing.Rectangle(0, 0, 45, 70)
        Me.btnFirstPage.CanFocus = True
        Me.btnFirstPage.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.btnFirstPage.ForeColor = System.Drawing.Color.Black
        '
        'btnPrevPage
        '
        Me.btnPrevPage.BackColor = System.Drawing.Color.Transparent
        Me.btnPrevPage.Bounds = New System.Drawing.Rectangle(0, 0, 47, 70)
        Me.btnPrevPage.CanFocus = True
        Me.btnPrevPage.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.btnPrevPage.ForeColor = System.Drawing.Color.Black
        '
        'btnNextPage
        '
        Me.btnNextPage.BackColor = System.Drawing.Color.Transparent
        Me.btnNextPage.Bounds = New System.Drawing.Rectangle(0, 0, 53, 70)
        Me.btnNextPage.CanFocus = True
        Me.btnNextPage.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.btnNextPage.ForeColor = System.Drawing.Color.Black
        '
        'btnLastPage
        '
        Me.btnLastPage.BackColor = System.Drawing.Color.Transparent
        Me.btnLastPage.Bounds = New System.Drawing.Rectangle(0, 0, 39, 70)
        Me.btnLastPage.CanFocus = True
        Me.btnLastPage.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.btnLastPage.ForeColor = System.Drawing.Color.Black
        '
        'RadRibbonBarGroup3
        '
        Me.RadRibbonBarGroup3.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.RadRibbonBarGroup3.Bounds = New System.Drawing.Rectangle(0, 0, 174, 92)
        Me.RadRibbonBarGroup3.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.RadRibbonBarGroup3.ForeColor = System.Drawing.Color.Black
        Me.RadRibbonBarGroup3.Margin = New System.Windows.Forms.Padding(2)
        Me.RadRibbonBarGroup3.MaxSize = New System.Drawing.Size(0, 100)
        Me.RadRibbonBarGroup3.MinSize = New System.Drawing.Size(20, 86)
        '
        'txtBuscar
        '
        Me.txtBuscar.BackColor = System.Drawing.Color.Transparent
        Me.txtBuscar.CanFocus = True
        Me.txtBuscar.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.txtBuscar.ForeColor = System.Drawing.Color.Black
        Me.txtBuscar.MinSize = New System.Drawing.Size(140, 0)
        Me.txtBuscar.StretchVertically = False
        '
        'btnBuscar
        '
        Me.btnBuscar.BackColor = System.Drawing.Color.Transparent
        Me.btnBuscar.Bounds = New System.Drawing.Rectangle(0, 0, 65, 22)
        Me.btnBuscar.CanFocus = True
        Me.btnBuscar.ForeColor = System.Drawing.Color.Black
        '
        'cbxZoom
        '
        Me.cbxZoom.BackColor = System.Drawing.Color.Transparent
        Me.cbxZoom.Bounds = New System.Drawing.Rectangle(0, 0, 70, 22)
        Me.cbxZoom.CanFocus = True
        Me.cbxZoom.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.cbxZoom.ForeColor = System.Drawing.Color.Black
        Me.cbxZoom.Padding = New System.Windows.Forms.Padding(-1)
        '
        'btnRefresh
        '
        Me.btnRefresh.BackColor = System.Drawing.Color.Transparent
        Me.btnRefresh.Bounds = New System.Drawing.Rectangle(0, 0, 75, 22)
        Me.btnRefresh.CanFocus = True
        Me.btnRefresh.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.btnRefresh.ForeColor = System.Drawing.Color.Black
        '
        'lblPagAct
        '
        Me.lblPagAct.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.lblPagAct.Bounds = New System.Drawing.Rectangle(0, 0, 135, 17)
        Me.lblPagAct.ForeColor = System.Drawing.Color.Black
        Me.stbStatus.SetSpring(Me.lblPagAct, False)
        '
        'lblMaxPag
        '
        Me.lblMaxPag.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.lblMaxPag.Bounds = New System.Drawing.Rectangle(0, 0, 133, 17)
        Me.lblMaxPag.ForeColor = System.Drawing.Color.Black
        Me.stbStatus.SetSpring(Me.lblMaxPag, False)
        '
        'lblZoom
        '
        Me.lblZoom.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.lblZoom.Bounds = New System.Drawing.Rectangle(0, 0, 82, 17)
        Me.lblZoom.ForeColor = System.Drawing.Color.Black
        Me.stbStatus.SetSpring(Me.lblZoom, False)
        '
        'rbtImpresion
        '
        Me.rbtImpresion.AutoEllipsis = True
        Me.rbtImpresion.BackColor = System.Drawing.Color.White
        Me.rbtImpresion.BorderColor = System.Drawing.Color.Transparent
        Me.rbtImpresion.BorderGradientStyle = Telerik.WinControls.GradientStyles.Solid
        Me.rbtImpresion.Bounds = New System.Drawing.Rectangle(0, 0, 46, 28)
        Me.rbtImpresion.ClipDrawing = True
        Me.rbtImpresion.ClipText = True
        Me.rbtImpresion.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit
        Me.rbtImpresion.DrawBorder = True
        Me.rbtImpresion.DrawFill = True
        Me.rbtImpresion.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.rbtImpresion.ForeColor = System.Drawing.Color.Black
        Me.rbtImpresion.GradientStyle = Telerik.WinControls.GradientStyles.Solid
        Me.rbtImpresion.ImageAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.rbtImpresion.ImageLayout = System.Windows.Forms.ImageLayout.None
        Me.rbtImpresion.IsSelected = False
        Me.rbtImpresion.Items.AddRange(New Telerik.WinControls.RadItem() {Me.rbgEMail})
        Me.rbtImpresion.MinSize = New System.Drawing.Size(8, 8)
        Me.rbtImpresion.NumberOfColors = 1
        Me.rbtImpresion.Padding = New System.Windows.Forms.Padding(4)
        Me.rbtImpresion.Text = "E-Mail"
        Me.rbtImpresion.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.rbtImpresion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.rbtImpresion.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        '
        'stbStatus
        '
        Me.stbStatus.Location = New System.Drawing.Point(0, 587)
        Me.stbStatus.Size = New System.Drawing.Size(1095, 25)
        '
        'RibbonTab1
        '
        Me.RibbonTab1.AccessibleDescription = "Email"
        Me.RibbonTab1.AccessibleName = "Email"
        Me.RibbonTab1.IsSelected = True
        Me.RibbonTab1.Name = "RibbonTab1"
        Me.RibbonTab1.Text = "Email"
        Me.RibbonTab1.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'RadRibbonBarGroup1
        '
        Me.RadRibbonBarGroup1.AccessibleDescription = "Envio"
        Me.RadRibbonBarGroup1.AccessibleName = "Envio"
        Me.RadRibbonBarGroup1.Name = "RadRibbonBarGroup1"
        Me.RadRibbonBarGroup1.Text = "Envio"
        Me.RadRibbonBarGroup1.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'rbgEMail
        '
        Me.rbgEMail.AccessibleDescription = "E-Mail"
        Me.rbgEMail.AccessibleName = "E-Mail"
        Me.rbgEMail.Alignment = System.Drawing.ContentAlignment.TopLeft
        Me.rbgEMail.Items.AddRange(New Telerik.WinControls.RadItem() {Me.btnEnviar})
        Me.rbgEMail.Name = "rbgEMail"
        Me.rbgEMail.Text = "E-Mail"
        Me.rbgEMail.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'btnEnviar
        '
        Me.btnEnviar.AccessibleDescription = "Enviar"
        Me.btnEnviar.AccessibleName = "Enviar"
        Me.btnEnviar.Image = Global.Karve.EnvioMail.My.Resources.Resources.Mail_Def
        Me.btnEnviar.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.btnEnviar.Name = "btnEnviar"
        Me.btnEnviar.Text = "Enviar"
        Me.btnEnviar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnEnviar.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'pnlRpt
        '
        Me.pnlRpt.Auto_Size = False
        Me.pnlRpt.BackColor = System.Drawing.SystemColors.Control
        Me.pnlRpt.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlRpt.ChangeDock = True
        Me.pnlRpt.Control_Resize = False
        Me.pnlRpt.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlRpt.isSpace = False
        Me.pnlRpt.Location = New System.Drawing.Point(550, 160)
        Me.pnlRpt.Name = "pnlRpt"
        Me.pnlRpt.numRows = 0
        Me.pnlRpt.Reorder = True
        Me.pnlRpt.Size = New System.Drawing.Size(550, 427)
        Me.pnlRpt.TabIndex = 6
        '
        'pnlMail
        '
        Me.pnlMail.Auto_Size = False
        Me.pnlMail.BackColor = System.Drawing.SystemColors.Control
        Me.pnlMail.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlMail.ChangeDock = True
        Me.pnlMail.Control_Resize = False
        Me.pnlMail.Controls.Add(Me.drfBody)
        Me.pnlMail.Controls.Add(Me.dtfTextoEstandar)
        Me.pnlMail.Controls.Add(Me.flsAttachments)
        Me.pnlMail.Controls.Add(Me.dtfSubject)
        Me.pnlMail.Controls.Add(Me.dtfRcpt)
        Me.pnlMail.Controls.Add(Me.dtfFrom)
        Me.pnlMail.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlMail.isSpace = False
        Me.pnlMail.Location = New System.Drawing.Point(0, 160)
        Me.pnlMail.Name = "pnlMail"
        Me.pnlMail.numRows = 0
        Me.pnlMail.Padding = New System.Windows.Forms.Padding(3)
        Me.pnlMail.Reorder = True
        Me.pnlMail.Size = New System.Drawing.Size(550, 427)
        Me.pnlMail.TabIndex = 5
        '
        'drfBody
        '
        Me.drfBody.Allow_Empty = True
        Me.drfBody.Byte_Data = Nothing
        Me.drfBody.Data_Allowed = CustomControls.DataRichField.List_Data.Libre
        Me.drfBody.DataField = Nothing
        Me.drfBody.DataTable = ""
        Me.drfBody.Descripcion = Nothing
        Me.drfBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.drfBody.Encoding = CustomControls.DataRichField.Code_Collation.LATIN
        Me.drfBody.FocoEnAgregar = False
        Me.drfBody.Location = New System.Drawing.Point(3, 159)
        Me.drfBody.Name = "drfBody"
        Me.drfBody.Null_on_Empty = False
        Me.drfBody.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.drfBody.ReadOnly_Data = False
        Me.drfBody.Size = New System.Drawing.Size(544, 265)
        Me.drfBody.TabIndex = 5
        Me.drfBody.Text_Data = Nothing
        Me.drfBody.Text_Type = CustomControls.DataRichField.TextType.HTML
        Me.drfBody.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.drfBody.Upper_Case = False
        Me.drfBody.Validate_on_lost_focus = True
        '
        'dtfTextoEstandar
        '
        Me.dtfTextoEstandar.Allow_Empty = True
        Me.dtfTextoEstandar.Allow_Negative = True
        Me.dtfTextoEstandar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfTextoEstandar.BackColor = System.Drawing.SystemColors.Control
        Me.dtfTextoEstandar.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfTextoEstandar.DataField = ""
        Me.dtfTextoEstandar.DataTable = ""
        Me.dtfTextoEstandar.DB = Connection1
        Me.dtfTextoEstandar.Desc_Datafield = "NOMBRE"
        Me.dtfTextoEstandar.Desc_DBPK = "CODIGO"
        Me.dtfTextoEstandar.Desc_DBTable = "RESERCONFIRM"
        Me.dtfTextoEstandar.Desc_Where = Nothing
        Me.dtfTextoEstandar.Desc_WhereObligatoria = Nothing
        Me.dtfTextoEstandar.Descripcion = "Texto"
        Me.dtfTextoEstandar.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfTextoEstandar.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfTextoEstandar.ExtraSQL = "TEXTO"
        Me.dtfTextoEstandar.FocoEnAgregar = False
        Me.dtfTextoEstandar.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfTextoEstandar.Formulario = Nothing
        Me.dtfTextoEstandar.Label_Space = 75
        Me.dtfTextoEstandar.Length_Data = 32767
        Me.dtfTextoEstandar.Location = New System.Drawing.Point(3, 133)
        Me.dtfTextoEstandar.Lupa = Nothing
        Me.dtfTextoEstandar.Max_Value = 0.0R
        Me.dtfTextoEstandar.MensajeIncorrectoCustom = Nothing
        Me.dtfTextoEstandar.Name = "dtfTextoEstandar"
        Me.dtfTextoEstandar.Null_on_Empty = True
        Me.dtfTextoEstandar.OpenForm = Nothing
        Me.dtfTextoEstandar.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfTextoEstandar.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfTextoEstandar.Query_on_Text_Changed = True
        Me.dtfTextoEstandar.ReadOnly_Data = False
        Me.dtfTextoEstandar.ReQuery = False
        Me.dtfTextoEstandar.ShowButton = True
        Me.dtfTextoEstandar.Size = New System.Drawing.Size(544, 26)
        Me.dtfTextoEstandar.TabIndex = 4
        Me.dtfTextoEstandar.Text_Data = ""
        Me.dtfTextoEstandar.Text_Data_Desc = ""
        Me.dtfTextoEstandar.Text_Width = 58
        Me.dtfTextoEstandar.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfTextoEstandar.TopPadding = 0
        Me.dtfTextoEstandar.Upper_Case = False
        Me.dtfTextoEstandar.Validate_on_lost_focus = True
        '
        'flsAttachments
        '
        Me.flsAttachments.Descripcion = "Adjuntos"
        Me.flsAttachments.Dock = System.Windows.Forms.DockStyle.Top
        Me.flsAttachments.Label_Space = 75
        Me.flsAttachments.Location = New System.Drawing.Point(3, 81)
        Me.flsAttachments.Name = "flsAttachments"
        Me.flsAttachments.Size = New System.Drawing.Size(544, 52)
        Me.flsAttachments.TabIndex = 3
        Me.flsAttachments.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        '
        'dtfSubject
        '
        Me.dtfSubject.Allow_Empty = True
        Me.dtfSubject.Allow_Negative = True
        Me.dtfSubject.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfSubject.BackColor = System.Drawing.SystemColors.Control
        Me.dtfSubject.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfSubject.DataField = Nothing
        Me.dtfSubject.DataTable = ""
        Me.dtfSubject.Descripcion = "Asunto"
        Me.dtfSubject.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfSubject.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfSubject.FocoEnAgregar = False
        Me.dtfSubject.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfSubject.Image = Nothing
        Me.dtfSubject.Label_Space = 75
        Me.dtfSubject.Length_Data = 32767
        Me.dtfSubject.Location = New System.Drawing.Point(3, 55)
        Me.dtfSubject.Max_Value = 0.0R
        Me.dtfSubject.MensajeIncorrectoCustom = Nothing
        Me.dtfSubject.Name = "dtfSubject"
        Me.dtfSubject.Null_on_Empty = True
        Me.dtfSubject.OpenForm = Nothing
        Me.dtfSubject.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfSubject.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfSubject.ReadOnly_Data = False
        Me.dtfSubject.Show_Button = False
        Me.dtfSubject.Size = New System.Drawing.Size(544, 26)
        Me.dtfSubject.TabIndex = 2
        Me.dtfSubject.Text_Data = ""
        Me.dtfSubject.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfSubject.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfSubject.TopPadding = 0
        Me.dtfSubject.Upper_Case = False
        Me.dtfSubject.Validate_on_lost_focus = True
        '
        'dtfRcpt
        '
        Me.dtfRcpt.Allow_Empty = True
        Me.dtfRcpt.Allow_Negative = True
        Me.dtfRcpt.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfRcpt.BackColor = System.Drawing.SystemColors.Control
        Me.dtfRcpt.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfRcpt.DataField = Nothing
        Me.dtfRcpt.DataTable = ""
        Me.dtfRcpt.Descripcion = "Para"
        Me.dtfRcpt.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfRcpt.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfRcpt.FocoEnAgregar = False
        Me.dtfRcpt.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfRcpt.Image = Nothing
        Me.dtfRcpt.Label_Space = 75
        Me.dtfRcpt.Length_Data = 32767
        Me.dtfRcpt.Location = New System.Drawing.Point(3, 29)
        Me.dtfRcpt.Max_Value = 0.0R
        Me.dtfRcpt.MensajeIncorrectoCustom = Nothing
        Me.dtfRcpt.Name = "dtfRcpt"
        Me.dtfRcpt.Null_on_Empty = True
        Me.dtfRcpt.OpenForm = Nothing
        Me.dtfRcpt.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfRcpt.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfRcpt.ReadOnly_Data = False
        Me.dtfRcpt.Show_Button = True
        Me.dtfRcpt.Size = New System.Drawing.Size(544, 26)
        Me.dtfRcpt.TabIndex = 1
        Me.dtfRcpt.Text_Data = ""
        Me.dtfRcpt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfRcpt.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfRcpt.TopPadding = 0
        Me.dtfRcpt.Upper_Case = False
        Me.dtfRcpt.Validate_on_lost_focus = True
        '
        'dtfFrom
        '
        Me.dtfFrom.Allow_Empty = True
        Me.dtfFrom.Allow_Negative = True
        Me.dtfFrom.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfFrom.BackColor = System.Drawing.SystemColors.Control
        Me.dtfFrom.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfFrom.DataField = Nothing
        Me.dtfFrom.DataTable = ""
        Me.dtfFrom.Descripcion = "De"
        Me.dtfFrom.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfFrom.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfFrom.FocoEnAgregar = False
        Me.dtfFrom.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfFrom.Image = Nothing
        Me.dtfFrom.Label_Space = 75
        Me.dtfFrom.Length_Data = 32767
        Me.dtfFrom.Location = New System.Drawing.Point(3, 3)
        Me.dtfFrom.Max_Value = 0.0R
        Me.dtfFrom.MensajeIncorrectoCustom = Nothing
        Me.dtfFrom.Name = "dtfFrom"
        Me.dtfFrom.Null_on_Empty = True
        Me.dtfFrom.OpenForm = Nothing
        Me.dtfFrom.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfFrom.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfFrom.ReadOnly_Data = True
        Me.dtfFrom.Show_Button = True
        Me.dtfFrom.Size = New System.Drawing.Size(544, 26)
        Me.dtfFrom.TabIndex = 0
        Me.dtfFrom.TabStop = False
        Me.dtfFrom.Text_Data = ""
        Me.dtfFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfFrom.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfFrom.TopPadding = 0
        Me.dtfFrom.Upper_Case = False
        Me.dtfFrom.Validate_on_lost_focus = True
        '
        'EnvioMail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1095, 612)
        Me.Controls.Add(Me.pnlRpt)
        Me.Controls.Add(Me.pnlMail)
        Me.Name = "EnvioMail"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "EnvioMail"
        Me.Controls.SetChildIndex(Me.stbStatus, 0)
        Me.Controls.SetChildIndex(Me.pnlMail, 0)
        Me.Controls.SetChildIndex(Me.pnlRpt, 0)
        CType(Me.stbStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlRpt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlMail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMail.ResumeLayout(False)
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RibbonTab1 As Telerik.WinControls.UI.RibbonTab
    Friend WithEvents RadRibbonBarGroup1 As Telerik.WinControls.UI.RadRibbonBarGroup
    Friend WithEvents rbgEMail As Telerik.WinControls.UI.RadRibbonBarGroup
    Friend WithEvents btnEnviar As Telerik.WinControls.UI.RadButtonElement
    Protected WithEvents drfBody As CustomControls.DataRichField
    Protected WithEvents dtfSubject As CustomControls.DatafieldLabel
    Protected WithEvents dtfRcpt As CustomControls.DatafieldLabel
    Protected WithEvents dtfFrom As CustomControls.DatafieldLabel
    Protected WithEvents dtfTextoEstandar As CustomControls.DualDatafieldLabel
    Protected WithEvents flsAttachments As CustomControls.FilesSelector
    Protected WithEvents pnlRpt As CustomControls.Panel
    Protected WithEvents pnlMail As CustomControls.Panel
End Class
