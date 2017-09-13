<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Vendedores
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
        Me.pnlOtros = New CustomControls.Panel()
        Me.dtlUltmodi = New CustomControls.DataLabel()
        Me.dtaObser = New CustomControls.DataAreaLabel()
        Me.dtlUsumodi = New CustomControls.DataLabel()
        Me.dtfContacto = New CustomControls.DatafieldLabel()
        Me.dtfNotas = New CustomControls.DatafieldLabel()
        Me.dtfEmail = New CustomControls.DatafieldLabel()
        Me.dtfWeb = New CustomControls.DatafieldLabel()
        Me.pnlDatosPersonales = New CustomControls.Panel()
        Me.pnlFechas = New CustomControls.Panel()
        Me.dtlBaja = New CustomControls.DataDateLabel()
        Me.pnlSpace = New CustomControls.Panel()
        Me.dtlAlta = New CustomControls.DataDateLabel()
        Me.dtfZona = New CustomControls.DualDatafieldLabel()
        Me.pnlFAX = New CustomControls.Panel()
        Me.dtfFAX = New CustomControls.DatafieldLabel()
        Me.pnlMovil = New CustomControls.Panel()
        Me.dtfMovil = New CustomControls.DatafieldLabel()
        Me.pnltelf = New CustomControls.Panel()
        Me.dtfTelefono = New CustomControls.DatafieldLabel()
        Me.dirPrincipal = New CustomControls.DataDir()
        Me.pnlNIF = New CustomControls.Panel()
        Me.dtfNIF = New CustomControls.DatafieldLabel()
        Me.pnlNombre = New CustomControls.Panel()
        Me.dtfNombre = New CustomControls.DatafieldLabel()
        Me.pnlSpace2 = New CustomControls.Panel()
        Me.dtfCodigo = New CustomControls.DatafieldLabel()
        CType(Me.pnlBlock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pvwBase, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pvwBase.SuspendLayout()
        CType(Me.stbBase, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PageViewPage1.SuspendLayout()
        CType(Me.pnlOtros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlOtros.SuspendLayout()
        CType(Me.dtlUltmodi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtlUsumodi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlDatosPersonales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDatosPersonales.SuspendLayout()
        CType(Me.pnlFechas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFechas.SuspendLayout()
        CType(Me.pnlSpace, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlFAX, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFAX.SuspendLayout()
        CType(Me.pnlMovil, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMovil.SuspendLayout()
        CType(Me.pnltelf, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnltelf.SuspendLayout()
        CType(Me.pnlNIF, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlNIF.SuspendLayout()
        CType(Me.pnlNombre, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlNombre.SuspendLayout()
        CType(Me.pnlSpace2, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.PageViewPage1.Controls.Add(Me.pnlOtros)
        Me.PageViewPage1.Controls.Add(Me.pnlDatosPersonales)
        Me.PageViewPage1.ItemSize = New System.Drawing.SizeF(110.0!, 23.0!)
        Me.PageViewPage1.Location = New System.Drawing.Point(129, 5)
        Me.PageViewPage1.Name = "PageViewPage1"
        Me.PageViewPage1.PanelCabezeraContainer = Nothing
        Me.PageViewPage1.Size = New System.Drawing.Size(1138, 500)
        Me.PageViewPage1.Text = "Datos Personales"
        '
        'pnlOtros
        '
        Me.pnlOtros.Auto_Size = False
        Me.pnlOtros.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlOtros.ChangeDock = True
        Me.pnlOtros.Control_Resize = False
        Me.pnlOtros.Controls.Add(Me.dtlUltmodi)
        Me.pnlOtros.Controls.Add(Me.dtaObser)
        Me.pnlOtros.Controls.Add(Me.dtlUsumodi)
        Me.pnlOtros.Controls.Add(Me.dtfContacto)
        Me.pnlOtros.Controls.Add(Me.dtfNotas)
        Me.pnlOtros.Controls.Add(Me.dtfEmail)
        Me.pnlOtros.Controls.Add(Me.dtfWeb)
        Me.pnlOtros.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlOtros.isSpace = False
        Me.pnlOtros.Location = New System.Drawing.Point(493, 0)
        Me.pnlOtros.Name = "pnlOtros"
        Me.pnlOtros.numRows = 0
        Me.pnlOtros.Padding = New System.Windows.Forms.Padding(3)
        Me.pnlOtros.Reorder = True
        Me.pnlOtros.Size = New System.Drawing.Size(642, 500)
        Me.pnlOtros.TabIndex = 15
        '
        'dtlUltmodi
        '
        Me.dtlUltmodi.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtlUltmodi.AutoSize = False
        Me.dtlUltmodi.BorderVisible = True
        Me.dtlUltmodi.DataField = "ULTMODI"
        Me.dtlUltmodi.DataTable = "VEND"
        Me.dtlUltmodi.Descripcion = ""
        Me.dtlUltmodi.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtlUltmodi.Fromat = CustomControls.DataLabel.fotmatType.ultmodi
        Me.dtlUltmodi.Location = New System.Drawing.Point(498, 466)
        Me.dtlUltmodi.Name = "dtlUltmodi"
        Me.dtlUltmodi.Size = New System.Drawing.Size(132, 17)
        Me.dtlUltmodi.TabIndex = 6
        Me.dtlUltmodi.TextAlignment = System.Drawing.ContentAlignment.TopCenter
        '
        'dtaObser
        '
        Me.dtaObser.Allow_Empty = True
        Me.dtaObser.Allow_Negative = True
        Me.dtaObser.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtaObser.BackColor = System.Drawing.SystemColors.Control
        Me.dtaObser.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtaObser.DataField = "OBS1"
        Me.dtaObser.DataTable = "VEND"
        Me.dtaObser.Descripcion = "Observaciones"
        Me.dtaObser.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtaObser.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtaObser.FocoEnAgregar = False
        Me.dtaObser.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtaObser.Length_Data = 32767
        Me.dtaObser.Location = New System.Drawing.Point(3, 103)
        Me.dtaObser.Max_Value = 0.0R
        Me.dtaObser.MensajeIncorrectoCustom = Nothing
        Me.dtaObser.Name = "dtaObser"
        Me.dtaObser.Null_on_Empty = True
        Me.dtaObser.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtaObser.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtaObser.ReadOnly_Data = False
        Me.dtaObser.Size = New System.Drawing.Size(636, 124)
        Me.dtaObser.TabIndex = 4
        Me.dtaObser.Text_Data = ""
        Me.dtaObser.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtaObser.TopPadding = 0
        Me.dtaObser.Upper_Case = False
        Me.dtaObser.Validate_on_lost_focus = True
        '
        'dtlUsumodi
        '
        Me.dtlUsumodi.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtlUsumodi.AutoSize = False
        Me.dtlUsumodi.BorderVisible = True
        Me.dtlUsumodi.DataField = "USUARIO"
        Me.dtlUsumodi.DataTable = "VEND"
        Me.dtlUsumodi.Descripcion = ""
        Me.dtlUsumodi.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtlUsumodi.Fromat = CustomControls.DataLabel.fotmatType.plain
        Me.dtlUsumodi.Location = New System.Drawing.Point(454, 466)
        Me.dtlUsumodi.Name = "dtlUsumodi"
        Me.dtlUsumodi.Size = New System.Drawing.Size(38, 17)
        Me.dtlUsumodi.TabIndex = 5
        Me.dtlUsumodi.TextAlignment = System.Drawing.ContentAlignment.TopCenter
        '
        'dtfContacto
        '
        Me.dtfContacto.Allow_Empty = True
        Me.dtfContacto.Allow_Negative = True
        Me.dtfContacto.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfContacto.BackColor = System.Drawing.SystemColors.Control
        Me.dtfContacto.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfContacto.DataField = Nothing
        Me.dtfContacto.DataTable = ""
        Me.dtfContacto.Descripcion = "Contacto"
        Me.dtfContacto.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfContacto.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfContacto.FocoEnAgregar = False
        Me.dtfContacto.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfContacto.Image = Nothing
        Me.dtfContacto.Label_Space = 75
        Me.dtfContacto.Length_Data = 32767
        Me.dtfContacto.Location = New System.Drawing.Point(3, 78)
        Me.dtfContacto.Max_Value = 0.0R
        Me.dtfContacto.MensajeIncorrectoCustom = Nothing
        Me.dtfContacto.Name = "dtfContacto"
        Me.dtfContacto.Null_on_Empty = True
        Me.dtfContacto.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfContacto.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfContacto.ReadOnly_Data = False
        Me.dtfContacto.Show_Button = False
        Me.dtfContacto.Size = New System.Drawing.Size(636, 25)
        Me.dtfContacto.TabIndex = 3
        Me.dtfContacto.Text_Data = ""
        Me.dtfContacto.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfContacto.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfContacto.TopPadding = 0
        Me.dtfContacto.Upper_Case = False
        Me.dtfContacto.Validate_on_lost_focus = True
        '
        'dtfNotas
        '
        Me.dtfNotas.Allow_Empty = True
        Me.dtfNotas.Allow_Negative = True
        Me.dtfNotas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfNotas.BackColor = System.Drawing.SystemColors.Control
        Me.dtfNotas.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfNotas.DataField = "notas"
        Me.dtfNotas.DataTable = "vend"
        Me.dtfNotas.Descripcion = "Notas"
        Me.dtfNotas.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfNotas.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfNotas.FocoEnAgregar = False
        Me.dtfNotas.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfNotas.Image = Nothing
        Me.dtfNotas.Label_Space = 75
        Me.dtfNotas.Length_Data = 32767
        Me.dtfNotas.Location = New System.Drawing.Point(3, 53)
        Me.dtfNotas.Max_Value = 0.0R
        Me.dtfNotas.MensajeIncorrectoCustom = Nothing
        Me.dtfNotas.Name = "dtfNotas"
        Me.dtfNotas.Null_on_Empty = True
        Me.dtfNotas.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfNotas.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfNotas.ReadOnly_Data = False
        Me.dtfNotas.Show_Button = True
        Me.dtfNotas.Size = New System.Drawing.Size(636, 25)
        Me.dtfNotas.TabIndex = 2
        Me.dtfNotas.Text_Data = ""
        Me.dtfNotas.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfNotas.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfNotas.TopPadding = 0
        Me.dtfNotas.Upper_Case = False
        Me.dtfNotas.Validate_on_lost_focus = True
        '
        'dtfEmail
        '
        Me.dtfEmail.Allow_Empty = True
        Me.dtfEmail.Allow_Negative = True
        Me.dtfEmail.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfEmail.BackColor = System.Drawing.SystemColors.Control
        Me.dtfEmail.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfEmail.DataField = "email"
        Me.dtfEmail.DataTable = "vend"
        Me.dtfEmail.Descripcion = "Email"
        Me.dtfEmail.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfEmail.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfEmail.FocoEnAgregar = False
        Me.dtfEmail.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfEmail.Image = Nothing
        Me.dtfEmail.Label_Space = 75
        Me.dtfEmail.Length_Data = 32767
        Me.dtfEmail.Location = New System.Drawing.Point(3, 28)
        Me.dtfEmail.Max_Value = 0.0R
        Me.dtfEmail.MensajeIncorrectoCustom = Nothing
        Me.dtfEmail.Name = "dtfEmail"
        Me.dtfEmail.Null_on_Empty = True
        Me.dtfEmail.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfEmail.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfEmail.ReadOnly_Data = False
        Me.dtfEmail.Show_Button = True
        Me.dtfEmail.Size = New System.Drawing.Size(636, 25)
        Me.dtfEmail.TabIndex = 1
        Me.dtfEmail.Text_Data = ""
        Me.dtfEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfEmail.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfEmail.TopPadding = 0
        Me.dtfEmail.Upper_Case = False
        Me.dtfEmail.Validate_on_lost_focus = True
        '
        'dtfWeb
        '
        Me.dtfWeb.Allow_Empty = True
        Me.dtfWeb.Allow_Negative = True
        Me.dtfWeb.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfWeb.BackColor = System.Drawing.SystemColors.Control
        Me.dtfWeb.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfWeb.DataField = "web"
        Me.dtfWeb.DataTable = "vend"
        Me.dtfWeb.Descripcion = "Web"
        Me.dtfWeb.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfWeb.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfWeb.FocoEnAgregar = False
        Me.dtfWeb.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfWeb.Image = Nothing
        Me.dtfWeb.Label_Space = 75
        Me.dtfWeb.Length_Data = 32767
        Me.dtfWeb.Location = New System.Drawing.Point(3, 3)
        Me.dtfWeb.Max_Value = 0.0R
        Me.dtfWeb.MensajeIncorrectoCustom = Nothing
        Me.dtfWeb.Name = "dtfWeb"
        Me.dtfWeb.Null_on_Empty = True
        Me.dtfWeb.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfWeb.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfWeb.ReadOnly_Data = False
        Me.dtfWeb.Show_Button = True
        Me.dtfWeb.Size = New System.Drawing.Size(636, 25)
        Me.dtfWeb.TabIndex = 0
        Me.dtfWeb.Text_Data = ""
        Me.dtfWeb.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfWeb.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfWeb.TopPadding = 0
        Me.dtfWeb.Upper_Case = False
        Me.dtfWeb.Validate_on_lost_focus = True
        '
        'pnlDatosPersonales
        '
        Me.pnlDatosPersonales.Auto_Size = False
        Me.pnlDatosPersonales.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlDatosPersonales.ChangeDock = True
        Me.pnlDatosPersonales.Control_Resize = False
        Me.pnlDatosPersonales.Controls.Add(Me.pnlFechas)
        Me.pnlDatosPersonales.Controls.Add(Me.dtfZona)
        Me.pnlDatosPersonales.Controls.Add(Me.pnlFAX)
        Me.pnlDatosPersonales.Controls.Add(Me.pnlMovil)
        Me.pnlDatosPersonales.Controls.Add(Me.pnltelf)
        Me.pnlDatosPersonales.Controls.Add(Me.dirPrincipal)
        Me.pnlDatosPersonales.Controls.Add(Me.pnlNIF)
        Me.pnlDatosPersonales.Controls.Add(Me.pnlNombre)
        Me.pnlDatosPersonales.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlDatosPersonales.isSpace = False
        Me.pnlDatosPersonales.Location = New System.Drawing.Point(0, 0)
        Me.pnlDatosPersonales.Name = "pnlDatosPersonales"
        Me.pnlDatosPersonales.numRows = 0
        Me.pnlDatosPersonales.Padding = New System.Windows.Forms.Padding(3)
        Me.pnlDatosPersonales.Reorder = True
        Me.pnlDatosPersonales.Size = New System.Drawing.Size(493, 500)
        Me.pnlDatosPersonales.TabIndex = 14
        '
        'pnlFechas
        '
        Me.pnlFechas.Auto_Size = False
        Me.pnlFechas.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlFechas.ChangeDock = True
        Me.pnlFechas.Control_Resize = False
        Me.pnlFechas.Controls.Add(Me.dtlBaja)
        Me.pnlFechas.Controls.Add(Me.pnlSpace)
        Me.pnlFechas.Controls.Add(Me.dtlAlta)
        Me.pnlFechas.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFechas.isSpace = False
        Me.pnlFechas.Location = New System.Drawing.Point(3, 263)
        Me.pnlFechas.Name = "pnlFechas"
        Me.pnlFechas.numRows = 1
        Me.pnlFechas.Reorder = True
        Me.pnlFechas.Size = New System.Drawing.Size(487, 26)
        Me.pnlFechas.TabIndex = 7
        '
        'dtlBaja
        '
        Me.dtlBaja.Allow_Empty = True
        Me.dtlBaja.DataField = "FECHABAJA"
        Me.dtlBaja.DataTable = "VEND"
        Me.dtlBaja.Default_Value = Nothing
        Me.dtlBaja.Descripcion = "Fecha Baja"
        Me.dtlBaja.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtlBaja.FocoEnAgregar = False
        Me.dtlBaja.Label_Space = 75
        Me.dtlBaja.Location = New System.Drawing.Point(175, 0)
        Me.dtlBaja.Max_Value = Nothing
        Me.dtlBaja.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtlBaja.MensajeIncorrectoCustom = Nothing
        Me.dtlBaja.Min_Value = Nothing
        Me.dtlBaja.MinDate = New Date(CType(0, Long))
        Me.dtlBaja.MinimumSize = New System.Drawing.Size(165, 26)
        Me.dtlBaja.Name = "dtlBaja"
        Me.dtlBaja.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtlBaja.ReadOnly_Data = False
        Me.dtlBaja.Size = New System.Drawing.Size(307, 26)
        Me.dtlBaja.TabIndex = 2
        Me.dtlBaja.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtlBaja.Validate_on_lost_focus = True
        Me.dtlBaja.Value_Data = Nothing
        '
        'pnlSpace
        '
        Me.pnlSpace.Auto_Size = False
        Me.pnlSpace.BackColor = System.Drawing.SystemColors.Control
        Me.pnlSpace.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace.ChangeDock = True
        Me.pnlSpace.Control_Resize = False
        Me.pnlSpace.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace.isSpace = True
        Me.pnlSpace.Location = New System.Drawing.Point(165, 0)
        Me.pnlSpace.Name = "pnlSpace"
        Me.pnlSpace.numRows = 0
        Me.pnlSpace.Reorder = True
        Me.pnlSpace.Size = New System.Drawing.Size(10, 26)
        Me.pnlSpace.TabIndex = 1
        '
        'dtlAlta
        '
        Me.dtlAlta.Allow_Empty = True
        Me.dtlAlta.DataField = "FECHALTA"
        Me.dtlAlta.DataTable = "VEND"
        Me.dtlAlta.Default_Value = Nothing
        Me.dtlAlta.Descripcion = "Fecha Alta"
        Me.dtlAlta.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtlAlta.FocoEnAgregar = False
        Me.dtlAlta.Label_Space = 75
        Me.dtlAlta.Location = New System.Drawing.Point(0, 0)
        Me.dtlAlta.Max_Value = Nothing
        Me.dtlAlta.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtlAlta.MensajeIncorrectoCustom = Nothing
        Me.dtlAlta.Min_Value = Nothing
        Me.dtlAlta.MinDate = New Date(CType(0, Long))
        Me.dtlAlta.MinimumSize = New System.Drawing.Size(165, 26)
        Me.dtlAlta.Name = "dtlAlta"
        Me.dtlAlta.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtlAlta.ReadOnly_Data = False
        Me.dtlAlta.Size = New System.Drawing.Size(165, 26)
        Me.dtlAlta.TabIndex = 0
        Me.dtlAlta.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtlAlta.Validate_on_lost_focus = True
        Me.dtlAlta.Value_Data = Nothing
        '
        'dtfZona
        '
        Me.dtfZona.Allow_Empty = True
        Me.dtfZona.Allow_Negative = True
        Me.dtfZona.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfZona.BackColor = System.Drawing.SystemColors.Control
        Me.dtfZona.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfZona.DataField = "ZONA"
        Me.dtfZona.DataTable = "VEND"
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
        Me.dtfZona.Label_Space = 76
        Me.dtfZona.Length_Data = 32767
        Me.dtfZona.Location = New System.Drawing.Point(3, 237)
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
        Me.dtfZona.Size = New System.Drawing.Size(487, 26)
        Me.dtfZona.TabIndex = 6
        Me.dtfZona.Text_Data = ""
        Me.dtfZona.Text_Data_Desc = ""
        Me.dtfZona.Text_Width = 58
        Me.dtfZona.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfZona.TopPadding = 0
        Me.dtfZona.Upper_Case = False
        Me.dtfZona.Validate_on_lost_focus = True
        '
        'pnlFAX
        '
        Me.pnlFAX.Auto_Size = False
        Me.pnlFAX.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlFAX.ChangeDock = True
        Me.pnlFAX.Control_Resize = False
        Me.pnlFAX.Controls.Add(Me.dtfFAX)
        Me.pnlFAX.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFAX.isSpace = False
        Me.pnlFAX.Location = New System.Drawing.Point(3, 211)
        Me.pnlFAX.Name = "pnlFAX"
        Me.pnlFAX.numRows = 1
        Me.pnlFAX.Reorder = True
        Me.pnlFAX.Size = New System.Drawing.Size(487, 26)
        Me.pnlFAX.TabIndex = 5
        '
        'dtfFAX
        '
        Me.dtfFAX.Allow_Empty = True
        Me.dtfFAX.Allow_Negative = True
        Me.dtfFAX.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfFAX.BackColor = System.Drawing.SystemColors.Control
        Me.dtfFAX.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfFAX.DataField = "FAX"
        Me.dtfFAX.DataTable = "VEND"
        Me.dtfFAX.Descripcion = "FAX"
        Me.dtfFAX.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfFAX.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfFAX.FocoEnAgregar = False
        Me.dtfFAX.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfFAX.Image = Nothing
        Me.dtfFAX.Label_Space = 75
        Me.dtfFAX.Length_Data = 32767
        Me.dtfFAX.Location = New System.Drawing.Point(0, 0)
        Me.dtfFAX.Max_Value = 0.0R
        Me.dtfFAX.MensajeIncorrectoCustom = Nothing
        Me.dtfFAX.Name = "dtfFAX"
        Me.dtfFAX.Null_on_Empty = True
        Me.dtfFAX.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfFAX.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfFAX.ReadOnly_Data = False
        Me.dtfFAX.Show_Button = False
        Me.dtfFAX.Size = New System.Drawing.Size(209, 26)
        Me.dtfFAX.TabIndex = 0
        Me.dtfFAX.Text_Data = ""
        Me.dtfFAX.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfFAX.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfFAX.TopPadding = 0
        Me.dtfFAX.Upper_Case = False
        Me.dtfFAX.Validate_on_lost_focus = True
        '
        'pnlMovil
        '
        Me.pnlMovil.Auto_Size = False
        Me.pnlMovil.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlMovil.ChangeDock = True
        Me.pnlMovil.Control_Resize = False
        Me.pnlMovil.Controls.Add(Me.dtfMovil)
        Me.pnlMovil.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlMovil.isSpace = False
        Me.pnlMovil.Location = New System.Drawing.Point(3, 185)
        Me.pnlMovil.Name = "pnlMovil"
        Me.pnlMovil.numRows = 1
        Me.pnlMovil.Reorder = True
        Me.pnlMovil.Size = New System.Drawing.Size(487, 26)
        Me.pnlMovil.TabIndex = 4
        '
        'dtfMovil
        '
        Me.dtfMovil.Allow_Empty = True
        Me.dtfMovil.Allow_Negative = True
        Me.dtfMovil.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfMovil.BackColor = System.Drawing.SystemColors.Control
        Me.dtfMovil.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfMovil.DataField = "MOVIL"
        Me.dtfMovil.DataTable = "VEND"
        Me.dtfMovil.Descripcion = "Móvil"
        Me.dtfMovil.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfMovil.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfMovil.FocoEnAgregar = False
        Me.dtfMovil.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfMovil.Image = Nothing
        Me.dtfMovil.Label_Space = 75
        Me.dtfMovil.Length_Data = 32767
        Me.dtfMovil.Location = New System.Drawing.Point(0, 0)
        Me.dtfMovil.Max_Value = 0.0R
        Me.dtfMovil.MensajeIncorrectoCustom = Nothing
        Me.dtfMovil.Name = "dtfMovil"
        Me.dtfMovil.Null_on_Empty = True
        Me.dtfMovil.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfMovil.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfMovil.ReadOnly_Data = False
        Me.dtfMovil.Show_Button = False
        Me.dtfMovil.Size = New System.Drawing.Size(209, 26)
        Me.dtfMovil.TabIndex = 0
        Me.dtfMovil.Text_Data = ""
        Me.dtfMovil.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfMovil.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfMovil.TopPadding = 0
        Me.dtfMovil.Upper_Case = False
        Me.dtfMovil.Validate_on_lost_focus = True
        '
        'pnltelf
        '
        Me.pnltelf.Auto_Size = False
        Me.pnltelf.BorderColor = System.Drawing.SystemColors.Control
        Me.pnltelf.ChangeDock = True
        Me.pnltelf.Control_Resize = False
        Me.pnltelf.Controls.Add(Me.dtfTelefono)
        Me.pnltelf.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnltelf.isSpace = False
        Me.pnltelf.Location = New System.Drawing.Point(3, 159)
        Me.pnltelf.Name = "pnltelf"
        Me.pnltelf.numRows = 1
        Me.pnltelf.Reorder = True
        Me.pnltelf.Size = New System.Drawing.Size(487, 26)
        Me.pnltelf.TabIndex = 3
        '
        'dtfTelefono
        '
        Me.dtfTelefono.Allow_Empty = True
        Me.dtfTelefono.Allow_Negative = True
        Me.dtfTelefono.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfTelefono.BackColor = System.Drawing.SystemColors.Control
        Me.dtfTelefono.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfTelefono.DataField = "Telefono"
        Me.dtfTelefono.DataTable = "VEND"
        Me.dtfTelefono.Descripcion = "Teléfono"
        Me.dtfTelefono.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfTelefono.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfTelefono.FocoEnAgregar = False
        Me.dtfTelefono.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfTelefono.Image = Nothing
        Me.dtfTelefono.Label_Space = 76
        Me.dtfTelefono.Length_Data = 32767
        Me.dtfTelefono.Location = New System.Drawing.Point(0, 0)
        Me.dtfTelefono.Max_Value = 0.0R
        Me.dtfTelefono.MensajeIncorrectoCustom = Nothing
        Me.dtfTelefono.Name = "dtfTelefono"
        Me.dtfTelefono.Null_on_Empty = True
        Me.dtfTelefono.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfTelefono.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfTelefono.ReadOnly_Data = False
        Me.dtfTelefono.Show_Button = False
        Me.dtfTelefono.Size = New System.Drawing.Size(209, 26)
        Me.dtfTelefono.TabIndex = 0
        Me.dtfTelefono.Text_Data = ""
        Me.dtfTelefono.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfTelefono.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfTelefono.TopPadding = 0
        Me.dtfTelefono.Upper_Case = False
        Me.dtfTelefono.Validate_on_lost_focus = True
        '
        'dirPrincipal
        '
        Me.dirPrincipal.AutoSize = True
        Me.dirPrincipal.Datafield_CP = "CP"
        Me.dirPrincipal.Datafield_Direccion = "DIRECCION"
        Me.dirPrincipal.Datafield_Direccion2L = Nothing
        Me.dirPrincipal.Datafield_GPS = "COORDGPS"
        Me.dirPrincipal.Datafield_Pais = ""
        Me.dirPrincipal.Datafield_Poblacion = "POBLACION"
        Me.dirPrincipal.Datafield_Provincia = "PROVINCIA"
        Me.dirPrincipal.Datatable_CP = "VEND"
        Me.dirPrincipal.Datatable_Direccion = "VEND"
        Me.dirPrincipal.Datatable_Direccion2L = ""
        Me.dirPrincipal.Datatable_GPS = "VEND"
        Me.dirPrincipal.Datatable_Pais = ""
        Me.dirPrincipal.Datatable_Poblacion = "VEND"
        Me.dirPrincipal.Datatable_Provincia = "VEND"
        Me.dirPrincipal.Descripcion = Nothing
        Me.dirPrincipal.Dock = System.Windows.Forms.DockStyle.Top
        Me.dirPrincipal.FocoEnAgregar = False
        Me.dirPrincipal.Label_Space = 75
        Me.dirPrincipal.Location = New System.Drawing.Point(3, 55)
        Me.dirPrincipal.Name = "dirPrincipal"
        Me.dirPrincipal.ReadOnly_Data = False
        Me.dirPrincipal.requeryCP = False
        Me.dirPrincipal.Show_Dir2L = False
        Me.dirPrincipal.Show_GPS = True
        Me.dirPrincipal.Show_Pais = False
        Me.dirPrincipal.Size = New System.Drawing.Size(487, 104)
        Me.dirPrincipal.TabIndex = 2
        Me.dirPrincipal.Text_Data_CP = ""
        Me.dirPrincipal.Text_Data_Direccion = ""
        Me.dirPrincipal.Text_Data_Direccion2L = ""
        Me.dirPrincipal.Text_Data_GPS = ""
        Me.dirPrincipal.Text_Data_Pais = ""
        Me.dirPrincipal.Text_Data_Poblacion = ""
        Me.dirPrincipal.Text_Data_Provincia = ""
        '
        'pnlNIF
        '
        Me.pnlNIF.Auto_Size = False
        Me.pnlNIF.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlNIF.ChangeDock = True
        Me.pnlNIF.Control_Resize = False
        Me.pnlNIF.Controls.Add(Me.dtfNIF)
        Me.pnlNIF.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlNIF.isSpace = False
        Me.pnlNIF.Location = New System.Drawing.Point(3, 29)
        Me.pnlNIF.Name = "pnlNIF"
        Me.pnlNIF.numRows = 1
        Me.pnlNIF.Reorder = True
        Me.pnlNIF.Size = New System.Drawing.Size(487, 26)
        Me.pnlNIF.TabIndex = 1
        '
        'dtfNIF
        '
        Me.dtfNIF.Allow_Empty = True
        Me.dtfNIF.Allow_Negative = True
        Me.dtfNIF.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfNIF.BackColor = System.Drawing.SystemColors.Control
        Me.dtfNIF.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfNIF.DataField = "NIF"
        Me.dtfNIF.DataTable = "VEND"
        Me.dtfNIF.Descripcion = "NIF"
        Me.dtfNIF.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfNIF.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfNIF.FocoEnAgregar = False
        Me.dtfNIF.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfNIF.Image = Nothing
        Me.dtfNIF.Label_Space = 75
        Me.dtfNIF.Length_Data = 32767
        Me.dtfNIF.Location = New System.Drawing.Point(0, 0)
        Me.dtfNIF.Max_Value = 0.0R
        Me.dtfNIF.MensajeIncorrectoCustom = Nothing
        Me.dtfNIF.Name = "dtfNIF"
        Me.dtfNIF.Null_on_Empty = True
        Me.dtfNIF.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfNIF.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfNIF.ReadOnly_Data = False
        Me.dtfNIF.Show_Button = False
        Me.dtfNIF.Size = New System.Drawing.Size(195, 26)
        Me.dtfNIF.TabIndex = 0
        Me.dtfNIF.Text_Data = ""
        Me.dtfNIF.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfNIF.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfNIF.TopPadding = 0
        Me.dtfNIF.Upper_Case = False
        Me.dtfNIF.Validate_on_lost_focus = True
        '
        'pnlNombre
        '
        Me.pnlNombre.Auto_Size = False
        Me.pnlNombre.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlNombre.ChangeDock = True
        Me.pnlNombre.Control_Resize = False
        Me.pnlNombre.Controls.Add(Me.dtfNombre)
        Me.pnlNombre.Controls.Add(Me.pnlSpace2)
        Me.pnlNombre.Controls.Add(Me.dtfCodigo)
        Me.pnlNombre.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlNombre.isSpace = False
        Me.pnlNombre.Location = New System.Drawing.Point(3, 3)
        Me.pnlNombre.Name = "pnlNombre"
        Me.pnlNombre.numRows = 1
        Me.pnlNombre.Reorder = True
        Me.pnlNombre.Size = New System.Drawing.Size(487, 26)
        Me.pnlNombre.TabIndex = 0
        '
        'dtfNombre
        '
        Me.dtfNombre.Allow_Empty = True
        Me.dtfNombre.Allow_Negative = True
        Me.dtfNombre.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfNombre.BackColor = System.Drawing.SystemColors.Control
        Me.dtfNombre.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfNombre.DataField = "NOMBRE"
        Me.dtfNombre.DataTable = "VEND"
        Me.dtfNombre.Descripcion = "Nombre"
        Me.dtfNombre.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfNombre.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfNombre.FocoEnAgregar = False
        Me.dtfNombre.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfNombre.Image = Nothing
        Me.dtfNombre.Label_Space = 75
        Me.dtfNombre.Length_Data = 32767
        Me.dtfNombre.Location = New System.Drawing.Point(201, 0)
        Me.dtfNombre.Max_Value = 0.0R
        Me.dtfNombre.MensajeIncorrectoCustom = Nothing
        Me.dtfNombre.Name = "dtfNombre"
        Me.dtfNombre.Null_on_Empty = True
        Me.dtfNombre.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfNombre.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfNombre.ReadOnly_Data = False
        Me.dtfNombre.Show_Button = False
        Me.dtfNombre.Size = New System.Drawing.Size(286, 26)
        Me.dtfNombre.TabIndex = 2
        Me.dtfNombre.Text_Data = ""
        Me.dtfNombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfNombre.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfNombre.TopPadding = 0
        Me.dtfNombre.Upper_Case = False
        Me.dtfNombre.Validate_on_lost_focus = True
        '
        'pnlSpace2
        '
        Me.pnlSpace2.Auto_Size = False
        Me.pnlSpace2.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace2.ChangeDock = True
        Me.pnlSpace2.Control_Resize = False
        Me.pnlSpace2.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace2.isSpace = True
        Me.pnlSpace2.Location = New System.Drawing.Point(195, 0)
        Me.pnlSpace2.Name = "pnlSpace2"
        Me.pnlSpace2.numRows = 0
        Me.pnlSpace2.Reorder = True
        Me.pnlSpace2.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace2.TabIndex = 1
        '
        'dtfCodigo
        '
        Me.dtfCodigo.Allow_Empty = True
        Me.dtfCodigo.Allow_Negative = True
        Me.dtfCodigo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfCodigo.BackColor = System.Drawing.SystemColors.Control
        Me.dtfCodigo.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfCodigo.DataField = "NUM_VENDE"
        Me.dtfCodigo.DataTable = "VEND"
        Me.dtfCodigo.Descripcion = "Código"
        Me.dtfCodigo.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfCodigo.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfCodigo.FocoEnAgregar = False
        Me.dtfCodigo.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfCodigo.Image = Nothing
        Me.dtfCodigo.Label_Space = 75
        Me.dtfCodigo.Length_Data = 32767
        Me.dtfCodigo.Location = New System.Drawing.Point(0, 0)
        Me.dtfCodigo.Max_Value = 0.0R
        Me.dtfCodigo.MensajeIncorrectoCustom = Nothing
        Me.dtfCodigo.Name = "dtfCodigo"
        Me.dtfCodigo.Null_on_Empty = True
        Me.dtfCodigo.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfCodigo.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfCodigo.ReadOnly_Data = True
        Me.dtfCodigo.Show_Button = False
        Me.dtfCodigo.Size = New System.Drawing.Size(195, 26)
        Me.dtfCodigo.TabIndex = 0
        Me.dtfCodigo.TabStop = False
        Me.dtfCodigo.Text_Data = ""
        Me.dtfCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfCodigo.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfCodigo.TopPadding = 0
        Me.dtfCodigo.Upper_Case = False
        Me.dtfCodigo.Validate_on_lost_focus = True
        '
        'Vendedores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1272, 695)
        Me.Name = "Vendedores"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Vendedores"
        CType(Me.pnlBlock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pvwBase, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pvwBase.ResumeLayout(False)
        CType(Me.stbBase, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PageViewPage1.ResumeLayout(False)
        CType(Me.pnlOtros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlOtros.ResumeLayout(False)
        CType(Me.dtlUltmodi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtlUsumodi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlDatosPersonales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDatosPersonales.ResumeLayout(False)
        Me.pnlDatosPersonales.PerformLayout()
        CType(Me.pnlFechas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFechas.ResumeLayout(False)
        CType(Me.pnlSpace, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlFAX, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFAX.ResumeLayout(False)
        CType(Me.pnlMovil, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMovil.ResumeLayout(False)
        CType(Me.pnltelf, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnltelf.ResumeLayout(False)
        CType(Me.pnlNIF, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlNIF.ResumeLayout(False)
        CType(Me.pnlNombre, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlNombre.ResumeLayout(False)
        CType(Me.pnlSpace2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PageViewPage1 As CustomControls.PageViewPage
    Friend WithEvents dtfNIF As CustomControls.DatafieldLabel
    Friend WithEvents dtfFAX As CustomControls.DatafieldLabel
    Friend WithEvents dtfMovil As CustomControls.DatafieldLabel
    Friend WithEvents dtfTelefono As CustomControls.DatafieldLabel
    Friend WithEvents dirPrincipal As CustomControls.DataDir
    Friend WithEvents dtlBaja As CustomControls.DataDateLabel
    Friend WithEvents dtlAlta As CustomControls.DataDateLabel
    Friend WithEvents dtfZona As CustomControls.DualDatafieldLabel
    Friend WithEvents pnlNombre As CustomControls.Panel
    Friend WithEvents dtfNombre As CustomControls.DatafieldLabel
    Friend WithEvents dtfCodigo As CustomControls.DatafieldLabel
    Friend WithEvents pnlDatosPersonales As CustomControls.Panel
    Friend WithEvents pnlSpace2 As CustomControls.Panel
    Friend WithEvents pnlFechas As CustomControls.Panel
    Friend WithEvents pnlSpace As CustomControls.Panel
    Friend WithEvents pnlFAX As CustomControls.Panel
    Friend WithEvents pnlMovil As CustomControls.Panel
    Friend WithEvents pnltelf As CustomControls.Panel
    Friend WithEvents pnlNIF As CustomControls.Panel
    Friend WithEvents pnlOtros As CustomControls.Panel
    Friend WithEvents dtaObser As CustomControls.DataAreaLabel
    Friend WithEvents dtfContacto As CustomControls.DatafieldLabel
    Friend WithEvents dtfNotas As CustomControls.DatafieldLabel
    Friend WithEvents dtfEmail As CustomControls.DatafieldLabel
    Friend WithEvents dtfWeb As CustomControls.DatafieldLabel
    Friend WithEvents dtlUltmodi As CustomControls.DataLabel
    Friend WithEvents dtlUsumodi As CustomControls.DataLabel
End Class
