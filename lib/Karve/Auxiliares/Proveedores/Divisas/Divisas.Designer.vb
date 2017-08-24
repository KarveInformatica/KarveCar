<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Divisas
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
        Me.PageViewPage1 = New CustomControls.PageViewPage()
        Me.pnlBottomGen = New CustomControls.Panel()
        Me.pnlGeneral = New CustomControls.Panel()
        Me.pnlPrecios = New CustomControls.Panel()
        Me.dtfPrecioCompra = New CustomControls.DatafieldLabel()
        Me.pnlSpace1 = New CustomControls.Panel()
        Me.dtfPrecioVenta = New CustomControls.DatafieldLabel()
        Me.dtfNombre = New CustomControls.DatafieldLabel()
        Me.pnlCodigo = New CustomControls.Panel()
        Me.dtfCodigo = New CustomControls.DatafieldLabel()
        Me.dtlUltmodi = New CustomControls.DataLabel()
        Me.dtlUsumodi = New CustomControls.DataLabel()
        CType(Me.pnlBlock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pvwBase, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pvwBase.SuspendLayout()
        CType(Me.stbBase, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PageViewPage1.SuspendLayout()
        CType(Me.pnlBottomGen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlGeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlGeneral.SuspendLayout()
        CType(Me.pnlPrecios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPrecios.SuspendLayout()
        CType(Me.pnlSpace1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlCodigo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCodigo.SuspendLayout()
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
        Me.PageViewPage1.Controls.Add(Me.pnlGeneral)
        Me.PageViewPage1.Controls.Add(Me.pnlBottomGen)
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
        Me.pnlBottomGen.ChangeDock = True
        Me.pnlBottomGen.Control_Resize = False
        Me.pnlBottomGen.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBottomGen.isSpace = False
        Me.pnlBottomGen.Location = New System.Drawing.Point(0, 474)
        Me.pnlBottomGen.Name = "pnlBottomGen"
        Me.pnlBottomGen.numRows = 1
        Me.pnlBottomGen.Reorder = True
        Me.pnlBottomGen.Size = New System.Drawing.Size(1138, 26)
        Me.pnlBottomGen.TabIndex = 6
        '
        'pnlGeneral
        '
        Me.pnlGeneral.Auto_Size = False
        Me.pnlGeneral.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlGeneral.ChangeDock = True
        Me.pnlGeneral.Control_Resize = False
        Me.pnlGeneral.Controls.Add(Me.dtlUltmodi)
        Me.pnlGeneral.Controls.Add(Me.dtlUsumodi)
        Me.pnlGeneral.Controls.Add(Me.pnlPrecios)
        Me.pnlGeneral.Controls.Add(Me.dtfNombre)
        Me.pnlGeneral.Controls.Add(Me.pnlCodigo)
        Me.pnlGeneral.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlGeneral.isSpace = False
        Me.pnlGeneral.Location = New System.Drawing.Point(0, 0)
        Me.pnlGeneral.Name = "pnlGeneral"
        Me.pnlGeneral.numRows = 0
        Me.pnlGeneral.Reorder = True
        Me.pnlGeneral.Size = New System.Drawing.Size(513, 474)
        Me.pnlGeneral.TabIndex = 7
        '
        'pnlPrecios
        '
        Me.pnlPrecios.Auto_Size = False
        Me.pnlPrecios.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlPrecios.ChangeDock = False
        Me.pnlPrecios.Control_Resize = False
        Me.pnlPrecios.Controls.Add(Me.dtfPrecioCompra)
        Me.pnlPrecios.Controls.Add(Me.pnlSpace1)
        Me.pnlPrecios.Controls.Add(Me.dtfPrecioVenta)
        Me.pnlPrecios.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlPrecios.isSpace = False
        Me.pnlPrecios.Location = New System.Drawing.Point(0, 52)
        Me.pnlPrecios.Name = "pnlPrecios"
        Me.pnlPrecios.numRows = 1
        Me.pnlPrecios.Reorder = True
        Me.pnlPrecios.Size = New System.Drawing.Size(513, 26)
        Me.pnlPrecios.TabIndex = 11
        '
        'dtfPrecioCompra
        '
        Me.dtfPrecioCompra.Allow_Empty = False
        Me.dtfPrecioCompra.Allow_Negative = True
        Me.dtfPrecioCompra.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfPrecioCompra.BackColor = System.Drawing.SystemColors.Control
        Me.dtfPrecioCompra.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfPrecioCompra.DataField = "COMPRA"
        Me.dtfPrecioCompra.DataTable = "DIVI"
        Me.dtfPrecioCompra.Descripcion = "Precio Venta"
        Me.dtfPrecioCompra.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfPrecioCompra.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfPrecioCompra.FocoEnAgregar = False
        Me.dtfPrecioCompra.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfPrecioCompra.Image = Nothing
        Me.dtfPrecioCompra.Label_Space = 75
        Me.dtfPrecioCompra.Length_Data = 32767
        Me.dtfPrecioCompra.Location = New System.Drawing.Point(199, 0)
        Me.dtfPrecioCompra.Max_Value = 0.0R
        Me.dtfPrecioCompra.MensajeIncorrectoCustom = Nothing
        Me.dtfPrecioCompra.Name = "dtfPrecioCompra"
        Me.dtfPrecioCompra.Null_on_Empty = True
        Me.dtfPrecioCompra.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfPrecioCompra.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfPrecioCompra.ReadOnly_Data = False
        Me.dtfPrecioCompra.Show_Button = False
        Me.dtfPrecioCompra.Size = New System.Drawing.Size(160, 26)
        Me.dtfPrecioCompra.TabIndex = 2
        Me.dtfPrecioCompra.Text_Data = ""
        Me.dtfPrecioCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfPrecioCompra.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfPrecioCompra.TopPadding = 0
        Me.dtfPrecioCompra.Upper_Case = False
        Me.dtfPrecioCompra.Validate_on_lost_focus = True
        '
        'pnlSpace1
        '
        Me.pnlSpace1.Auto_Size = False
        Me.pnlSpace1.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace1.ChangeDock = True
        Me.pnlSpace1.Control_Resize = False
        Me.pnlSpace1.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace1.isSpace = True
        Me.pnlSpace1.Location = New System.Drawing.Point(160, 0)
        Me.pnlSpace1.Name = "pnlSpace1"
        Me.pnlSpace1.numRows = 0
        Me.pnlSpace1.Reorder = True
        Me.pnlSpace1.Size = New System.Drawing.Size(39, 26)
        Me.pnlSpace1.TabIndex = 1
        '
        'dtfPrecioVenta
        '
        Me.dtfPrecioVenta.Allow_Empty = False
        Me.dtfPrecioVenta.Allow_Negative = True
        Me.dtfPrecioVenta.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfPrecioVenta.BackColor = System.Drawing.SystemColors.Control
        Me.dtfPrecioVenta.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfPrecioVenta.DataField = "VENTA"
        Me.dtfPrecioVenta.DataTable = "DIVI"
        Me.dtfPrecioVenta.Descripcion = "Precio Venta"
        Me.dtfPrecioVenta.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfPrecioVenta.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfPrecioVenta.FocoEnAgregar = False
        Me.dtfPrecioVenta.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfPrecioVenta.Image = Nothing
        Me.dtfPrecioVenta.Label_Space = 75
        Me.dtfPrecioVenta.Length_Data = 32767
        Me.dtfPrecioVenta.Location = New System.Drawing.Point(0, 0)
        Me.dtfPrecioVenta.Max_Value = 0.0R
        Me.dtfPrecioVenta.MensajeIncorrectoCustom = Nothing
        Me.dtfPrecioVenta.Name = "dtfPrecioVenta"
        Me.dtfPrecioVenta.Null_on_Empty = True
        Me.dtfPrecioVenta.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfPrecioVenta.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfPrecioVenta.ReadOnly_Data = False
        Me.dtfPrecioVenta.Show_Button = False
        Me.dtfPrecioVenta.Size = New System.Drawing.Size(160, 26)
        Me.dtfPrecioVenta.TabIndex = 0
        Me.dtfPrecioVenta.Text_Data = ""
        Me.dtfPrecioVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfPrecioVenta.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfPrecioVenta.TopPadding = 0
        Me.dtfPrecioVenta.Upper_Case = False
        Me.dtfPrecioVenta.Validate_on_lost_focus = True
        '
        'dtfNombre
        '
        Me.dtfNombre.Allow_Empty = False
        Me.dtfNombre.Allow_Negative = True
        Me.dtfNombre.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfNombre.BackColor = System.Drawing.SystemColors.Control
        Me.dtfNombre.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfNombre.DataField = "NOMBRE"
        Me.dtfNombre.DataTable = "DIVI"
        Me.dtfNombre.Descripcion = "Nombre"
        Me.dtfNombre.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfNombre.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfNombre.FocoEnAgregar = False
        Me.dtfNombre.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfNombre.Image = Nothing
        Me.dtfNombre.Label_Space = 75
        Me.dtfNombre.Length_Data = 32767
        Me.dtfNombre.Location = New System.Drawing.Point(0, 26)
        Me.dtfNombre.Max_Value = 0.0R
        Me.dtfNombre.MensajeIncorrectoCustom = Nothing
        Me.dtfNombre.Name = "dtfNombre"
        Me.dtfNombre.Null_on_Empty = True
        Me.dtfNombre.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfNombre.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfNombre.ReadOnly_Data = False
        Me.dtfNombre.Show_Button = False
        Me.dtfNombre.Size = New System.Drawing.Size(513, 26)
        Me.dtfNombre.TabIndex = 9
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
        Me.pnlCodigo.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlCodigo.ChangeDock = False
        Me.pnlCodigo.Control_Resize = False
        Me.pnlCodigo.Controls.Add(Me.dtfCodigo)
        Me.pnlCodigo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCodigo.isSpace = False
        Me.pnlCodigo.Location = New System.Drawing.Point(0, 0)
        Me.pnlCodigo.Name = "pnlCodigo"
        Me.pnlCodigo.numRows = 1
        Me.pnlCodigo.Reorder = True
        Me.pnlCodigo.Size = New System.Drawing.Size(513, 26)
        Me.pnlCodigo.TabIndex = 10
        '
        'dtfCodigo
        '
        Me.dtfCodigo.Allow_Empty = False
        Me.dtfCodigo.Allow_Negative = True
        Me.dtfCodigo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfCodigo.BackColor = System.Drawing.SystemColors.Control
        Me.dtfCodigo.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfCodigo.DataField = "CODIGO"
        Me.dtfCodigo.DataTable = "DIVI"
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
        Me.dtfCodigo.Size = New System.Drawing.Size(160, 26)
        Me.dtfCodigo.TabIndex = 0
        Me.dtfCodigo.TabStop = False
        Me.dtfCodigo.Text_Data = ""
        Me.dtfCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfCodigo.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfCodigo.TopPadding = 0
        Me.dtfCodigo.Upper_Case = True
        Me.dtfCodigo.Validate_on_lost_focus = True
        '
        'dtlUltmodi
        '
        Me.dtlUltmodi.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtlUltmodi.AutoSize = False
        Me.dtlUltmodi.BorderVisible = True
        Me.dtlUltmodi.DataField = "ULTMODI"
        Me.dtlUltmodi.DataTable = "DIVI"
        Me.dtlUltmodi.Descripcion = ""
        Me.dtlUltmodi.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtlUltmodi.Fromat = CustomControls.DataLabel.fotmatType.ultmodi
        Me.dtlUltmodi.Location = New System.Drawing.Point(381, 428)
        Me.dtlUltmodi.Name = "dtlUltmodi"
        Me.dtlUltmodi.Size = New System.Drawing.Size(132, 17)
        Me.dtlUltmodi.TabIndex = 13
        Me.dtlUltmodi.TextAlignment = System.Drawing.ContentAlignment.TopCenter
        '
        'dtlUsumodi
        '
        Me.dtlUsumodi.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtlUsumodi.AutoSize = False
        Me.dtlUsumodi.BorderVisible = True
        Me.dtlUsumodi.DataField = "USUARIO"
        Me.dtlUsumodi.DataTable = "DIVI"
        Me.dtlUsumodi.Descripcion = ""
        Me.dtlUsumodi.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtlUsumodi.Fromat = CustomControls.DataLabel.fotmatType.plain
        Me.dtlUsumodi.Location = New System.Drawing.Point(337, 428)
        Me.dtlUsumodi.Name = "dtlUsumodi"
        Me.dtlUsumodi.Size = New System.Drawing.Size(38, 17)
        Me.dtlUsumodi.TabIndex = 12
        Me.dtlUsumodi.TextAlignment = System.Drawing.ContentAlignment.TopCenter
        '
        'Divisas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1272, 695)
        Me.Name = "Divisas"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Divisas"
        CType(Me.pnlBlock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pvwBase, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pvwBase.ResumeLayout(False)
        CType(Me.stbBase, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PageViewPage1.ResumeLayout(False)
        CType(Me.pnlBottomGen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlGeneral, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlGeneral.ResumeLayout(False)
        CType(Me.pnlPrecios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPrecios.ResumeLayout(False)
        CType(Me.pnlSpace1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlCodigo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCodigo.ResumeLayout(False)
        CType(Me.dtlUltmodi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtlUsumodi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PageViewPage1 As CustomControls.PageViewPage
    Friend WithEvents pnlBottomGen As CustomControls.Panel
    Friend WithEvents pnlGeneral As CustomControls.Panel
    Friend WithEvents dtlUltmodi As CustomControls.DataLabel
    Friend WithEvents dtlUsumodi As CustomControls.DataLabel
    Friend WithEvents pnlPrecios As CustomControls.Panel
    Friend WithEvents dtfPrecioCompra As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace1 As CustomControls.Panel
    Friend WithEvents dtfPrecioVenta As CustomControls.DatafieldLabel
    Friend WithEvents dtfNombre As CustomControls.DatafieldLabel
    Friend WithEvents pnlCodigo As CustomControls.Panel
    Friend WithEvents dtfCodigo As CustomControls.DatafieldLabel
End Class
