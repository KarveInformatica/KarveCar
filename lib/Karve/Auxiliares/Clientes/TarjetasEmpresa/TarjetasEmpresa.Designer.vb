<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TarjetasEmpresa
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
        Me.pnlGeneral = New CustomControls.Panel()
        Me.dtaCondiciones = New CustomControls.DataAreaLabel()
        Me.Panel1 = New CustomControls.Panel()
        Me.DatafieldLabel1 = New CustomControls.DatafieldLabel()
        Me.pnlPrecio = New CustomControls.Panel()
        Me.dtfPrecio = New CustomControls.DatafieldLabel()
        Me.dtfNombre = New CustomControls.DatafieldLabel()
        Me.pnlCodigo = New CustomControls.Panel()
        Me.dtfCodigo = New CustomControls.DatafieldLabel()
        CType(Me.pnlBlock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pvwBase, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pvwBase.SuspendLayout()
        CType(Me.stbBase, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PageViewPage1.SuspendLayout()
        CType(Me.pnlGeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlGeneral.SuspendLayout()
        CType(Me.Panel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.pnlPrecio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPrecio.SuspendLayout()
        CType(Me.pnlCodigo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCodigo.SuspendLayout()
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
        Me.PageViewPage1.ItemSize = New System.Drawing.SizeF(56.0!, 23.0!)
        Me.PageViewPage1.Location = New System.Drawing.Point(129, 5)
        Me.PageViewPage1.Name = "PageViewPage1"
        Me.PageViewPage1.PanelCabezeraContainer = Nothing
        Me.PageViewPage1.Size = New System.Drawing.Size(1138, 500)
        Me.PageViewPage1.Text = "General"
        '
        'pnlGeneral
        '
        Me.pnlGeneral.Auto_Size = False
        Me.pnlGeneral.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlGeneral.ChangeDock = True
        Me.pnlGeneral.Control_Resize = False
        Me.pnlGeneral.Controls.Add(Me.dtaCondiciones)
        Me.pnlGeneral.Controls.Add(Me.Panel1)
        Me.pnlGeneral.Controls.Add(Me.pnlPrecio)
        Me.pnlGeneral.Controls.Add(Me.dtfNombre)
        Me.pnlGeneral.Controls.Add(Me.pnlCodigo)
        Me.pnlGeneral.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlGeneral.isSpace = False
        Me.pnlGeneral.Location = New System.Drawing.Point(0, 0)
        Me.pnlGeneral.Name = "pnlGeneral"
        Me.pnlGeneral.numRows = 0
        Me.pnlGeneral.Padding = New System.Windows.Forms.Padding(3)
        Me.pnlGeneral.Reorder = True
        Me.pnlGeneral.Size = New System.Drawing.Size(1138, 485)
        Me.pnlGeneral.TabIndex = 0
        '
        'dtaCondiciones
        '
        Me.dtaCondiciones.Allow_Empty = True
        Me.dtaCondiciones.Allow_Negative = True
        Me.dtaCondiciones.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtaCondiciones.BackColor = System.Drawing.SystemColors.Control
        Me.dtaCondiciones.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtaCondiciones.DataField = "CONDICIONES"
        Me.dtaCondiciones.DataTable = "TARE"
        Me.dtaCondiciones.Descripcion = "Condiciones"
        Me.dtaCondiciones.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtaCondiciones.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtaCondiciones.FocoEnAgregar = False
        Me.dtaCondiciones.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtaCondiciones.Length_Data = 32767
        Me.dtaCondiciones.Location = New System.Drawing.Point(3, 107)
        Me.dtaCondiciones.Max_Value = 0.0R
        Me.dtaCondiciones.MensajeIncorrectoCustom = Nothing
        Me.dtaCondiciones.Name = "dtaCondiciones"
        Me.dtaCondiciones.Null_on_Empty = True
        Me.dtaCondiciones.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtaCondiciones.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtaCondiciones.ReadOnly_Data = False
        Me.dtaCondiciones.Size = New System.Drawing.Size(1132, 124)
        Me.dtaCondiciones.TabIndex = 4
        Me.dtaCondiciones.Text_Data = ""
        Me.dtaCondiciones.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtaCondiciones.TopPadding = 0
        Me.dtaCondiciones.Upper_Case = False
        Me.dtaCondiciones.Validate_on_lost_focus = True
        '
        'Panel1
        '
        Me.Panel1.Auto_Size = False
        Me.Panel1.BorderColor = System.Drawing.SystemColors.Control
        Me.Panel1.ChangeDock = True
        Me.Panel1.Control_Resize = False
        Me.Panel1.Controls.Add(Me.DatafieldLabel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.isSpace = False
        Me.Panel1.Location = New System.Drawing.Point(3, 81)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.numRows = 1
        Me.Panel1.Reorder = True
        Me.Panel1.Size = New System.Drawing.Size(1132, 26)
        Me.Panel1.TabIndex = 3
        '
        'DatafieldLabel1
        '
        Me.DatafieldLabel1.Allow_Empty = False
        Me.DatafieldLabel1.Allow_Negative = True
        Me.DatafieldLabel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.DatafieldLabel1.BackColor = System.Drawing.SystemColors.Control
        Me.DatafieldLabel1.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.DatafieldLabel1.DataField = "PREFIJO"
        Me.DatafieldLabel1.DataTable = "TARE"
        Me.DatafieldLabel1.Descripcion = "Prefijo"
        Me.DatafieldLabel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.DatafieldLabel1.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.DatafieldLabel1.FocoEnAgregar = False
        Me.DatafieldLabel1.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.DatafieldLabel1.Image = Nothing
        Me.DatafieldLabel1.Label_Space = 75
        Me.DatafieldLabel1.Length_Data = 32767
        Me.DatafieldLabel1.Location = New System.Drawing.Point(0, 0)
        Me.DatafieldLabel1.Max_Value = 0.0R
        Me.DatafieldLabel1.MensajeIncorrectoCustom = Nothing
        Me.DatafieldLabel1.Name = "DatafieldLabel1"
        Me.DatafieldLabel1.Null_on_Empty = True
        Me.DatafieldLabel1.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.DatafieldLabel1.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.DatafieldLabel1.ReadOnly_Data = False
        Me.DatafieldLabel1.Show_Button = False
        Me.DatafieldLabel1.Size = New System.Drawing.Size(132, 26)
        Me.DatafieldLabel1.TabIndex = 0
        Me.DatafieldLabel1.Text_Data = ""
        Me.DatafieldLabel1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.DatafieldLabel1.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.DatafieldLabel1.TopPadding = 0
        Me.DatafieldLabel1.Upper_Case = False
        Me.DatafieldLabel1.Validate_on_lost_focus = True
        '
        'pnlPrecio
        '
        Me.pnlPrecio.Auto_Size = False
        Me.pnlPrecio.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlPrecio.ChangeDock = True
        Me.pnlPrecio.Control_Resize = False
        Me.pnlPrecio.Controls.Add(Me.dtfPrecio)
        Me.pnlPrecio.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlPrecio.isSpace = False
        Me.pnlPrecio.Location = New System.Drawing.Point(3, 55)
        Me.pnlPrecio.Name = "pnlPrecio"
        Me.pnlPrecio.numRows = 1
        Me.pnlPrecio.Reorder = True
        Me.pnlPrecio.Size = New System.Drawing.Size(1132, 26)
        Me.pnlPrecio.TabIndex = 2
        '
        'dtfPrecio
        '
        Me.dtfPrecio.Allow_Empty = False
        Me.dtfPrecio.Allow_Negative = True
        Me.dtfPrecio.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfPrecio.BackColor = System.Drawing.SystemColors.Control
        Me.dtfPrecio.Data_Allowed = CustomControls.Datafield.List_Data.nDouble
        Me.dtfPrecio.DataField = "PRECIO"
        Me.dtfPrecio.DataTable = "TARE"
        Me.dtfPrecio.Descripcion = "Precio"
        Me.dtfPrecio.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfPrecio.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfPrecio.FocoEnAgregar = False
        Me.dtfPrecio.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfPrecio.Image = Nothing
        Me.dtfPrecio.Label_Space = 75
        Me.dtfPrecio.Length_Data = 32767
        Me.dtfPrecio.Location = New System.Drawing.Point(0, 0)
        Me.dtfPrecio.Max_Value = 0.0R
        Me.dtfPrecio.MensajeIncorrectoCustom = Nothing
        Me.dtfPrecio.Name = "dtfPrecio"
        Me.dtfPrecio.Null_on_Empty = True
        Me.dtfPrecio.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfPrecio.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfPrecio.ReadOnly_Data = False
        Me.dtfPrecio.Show_Button = False
        Me.dtfPrecio.Size = New System.Drawing.Size(132, 26)
        Me.dtfPrecio.TabIndex = 0
        Me.dtfPrecio.Text_Data = ""
        Me.dtfPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.dtfPrecio.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfPrecio.TopPadding = 0
        Me.dtfPrecio.Upper_Case = False
        Me.dtfPrecio.Validate_on_lost_focus = True
        '
        'dtfNombre
        '
        Me.dtfNombre.Allow_Empty = False
        Me.dtfNombre.Allow_Negative = True
        Me.dtfNombre.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfNombre.BackColor = System.Drawing.SystemColors.Control
        Me.dtfNombre.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfNombre.DataField = "NOMBRE"
        Me.dtfNombre.DataTable = "TARE"
        Me.dtfNombre.Descripcion = "Nombre"
        Me.dtfNombre.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfNombre.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfNombre.FocoEnAgregar = False
        Me.dtfNombre.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfNombre.Image = Nothing
        Me.dtfNombre.Label_Space = 75
        Me.dtfNombre.Length_Data = 32767
        Me.dtfNombre.Location = New System.Drawing.Point(3, 29)
        Me.dtfNombre.Max_Value = 0.0R
        Me.dtfNombre.MensajeIncorrectoCustom = Nothing
        Me.dtfNombre.Name = "dtfNombre"
        Me.dtfNombre.Null_on_Empty = True
        Me.dtfNombre.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfNombre.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfNombre.ReadOnly_Data = False
        Me.dtfNombre.Show_Button = False
        Me.dtfNombre.Size = New System.Drawing.Size(1132, 26)
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
        Me.pnlCodigo.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlCodigo.ChangeDock = False
        Me.pnlCodigo.Control_Resize = False
        Me.pnlCodigo.Controls.Add(Me.dtfCodigo)
        Me.pnlCodigo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCodigo.isSpace = False
        Me.pnlCodigo.Location = New System.Drawing.Point(3, 3)
        Me.pnlCodigo.Name = "pnlCodigo"
        Me.pnlCodigo.numRows = 1
        Me.pnlCodigo.Reorder = True
        Me.pnlCodigo.Size = New System.Drawing.Size(1132, 26)
        Me.pnlCodigo.TabIndex = 0
        '
        'dtfCodigo
        '
        Me.dtfCodigo.Allow_Empty = False
        Me.dtfCodigo.Allow_Negative = True
        Me.dtfCodigo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfCodigo.BackColor = System.Drawing.SystemColors.Control
        Me.dtfCodigo.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfCodigo.DataField = "COD_TARJETA"
        Me.dtfCodigo.DataTable = "TARE"
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
        Me.dtfCodigo.Size = New System.Drawing.Size(175, 26)
        Me.dtfCodigo.TabIndex = 0
        Me.dtfCodigo.TabStop = False
        Me.dtfCodigo.Text_Data = ""
        Me.dtfCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfCodigo.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfCodigo.TopPadding = 0
        Me.dtfCodigo.Upper_Case = False
        Me.dtfCodigo.Validate_on_lost_focus = True
        '
        'TarjetasEmpresa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1272, 695)
        Me.Name = "TarjetasEmpresa"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "TarjetasEmpresa"
        CType(Me.pnlBlock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pvwBase, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pvwBase.ResumeLayout(False)
        CType(Me.stbBase, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PageViewPage1.ResumeLayout(False)
        CType(Me.pnlGeneral, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlGeneral.ResumeLayout(False)
        CType(Me.Panel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.pnlPrecio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPrecio.ResumeLayout(False)
        CType(Me.pnlCodigo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCodigo.ResumeLayout(False)
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PageViewPage1 As CustomControls.PageViewPage
    Friend WithEvents pnlGeneral As CustomControls.Panel
    Friend WithEvents dtaCondiciones As CustomControls.DataAreaLabel
    Friend WithEvents Panel1 As CustomControls.Panel
    Friend WithEvents DatafieldLabel1 As CustomControls.DatafieldLabel
    Friend WithEvents pnlPrecio As CustomControls.Panel
    Friend WithEvents dtfPrecio As CustomControls.DatafieldLabel
    Friend WithEvents dtfNombre As CustomControls.DatafieldLabel
    Friend WithEvents pnlCodigo As CustomControls.Panel
    Friend WithEvents dtfCodigo As CustomControls.DatafieldLabel
End Class
