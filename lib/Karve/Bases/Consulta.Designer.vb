<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Consulta
    Inherits Telerik.WinControls.UI.RadForm

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Consulta))
        Me.Windows7Theme1 = New Telerik.WinControls.Themes.Windows7Theme()
        Me.CustomShape1 = New Telerik.WinControls.OldShapeEditor.CustomShape()
        Me.Cinta = New Telerik.WinControls.UI.RadRibbonBar()
        Me.rbtEdicion = New Telerik.WinControls.UI.RibbonTab()
        Me.rbgEdicion = New Telerik.WinControls.UI.RadRibbonBarGroup()
        Me.rbAceptar = New Telerik.WinControls.UI.RadButtonElement()
        Me.rbCancelar = New Telerik.WinControls.UI.RadButtonElement()
        Me.rbNuevo = New Telerik.WinControls.UI.RadButtonElement()
        Me.rbgBuscar = New Telerik.WinControls.UI.RadRibbonBarGroup()
        Me.rbBuscar = New Telerik.WinControls.UI.RadButtonElement()
        Me.rbgSelectMult = New Telerik.WinControls.UI.RadRibbonBarGroup()
        Me.rbSMSelected = New Telerik.WinControls.UI.RadButtonElement()
        Me.rbSMDesSelected = New Telerik.WinControls.UI.RadButtonElement()
        Me.rbConfigura = New Telerik.WinControls.UI.RibbonTab()
        Me.rbgConfiguracion = New Telerik.WinControls.UI.RadRibbonBarGroup()
        Me.rbGuardar = New Telerik.WinControls.UI.RadButtonElement()
        Me.rbOpenForm = New Telerik.WinControls.UI.RadButtonElement()
        Me.Windows8Theme1 = New Telerik.WinControls.Themes.Windows8Theme()
        Me.rsStatus = New Telerik.WinControls.UI.RadStatusStrip()
        Me.btnAdd = New Telerik.WinControls.UI.RadButtonElement()
        Me.Grid = New CustomControls.DataGrid()
        CType(Me.Cinta,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.rsStatus,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.Grid,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.Grid.MasterTemplate,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'CustomShape1
        '
        Me.CustomShape1.Dimension = New System.Drawing.Rectangle(0, 0, 0, 0)
        '
        'Cinta
        '
        Me.Cinta.CommandTabs.AddRange(New Telerik.WinControls.RadItem() {Me.rbtEdicion, Me.rbConfigura})
        Me.Cinta.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.Cinta.Location = New System.Drawing.Point(0, 0)
        Me.Cinta.MaximizeButton = false
        Me.Cinta.MinimizeButton = false
        Me.Cinta.Name = "Cinta"
        Me.Cinta.Size = New System.Drawing.Size(1016, 164)
        Me.Cinta.StartButtonImage = CType(resources.GetObject("Cinta.StartButtonImage"), System.Drawing.Image)
        Me.Cinta.TabIndex = 0
        Me.Cinta.Tag = "1"
        Me.Cinta.Text = "RadRibbonBar1"
        Me.Cinta.ThemeName = "Windows8"
        Me.Cinta.Visible = False
        CType(Me.Cinta.GetChildAt(0), Telerik.WinControls.UI.RadRibbonBarElement).Text = "RadRibbonBar1"
        CType(Me.Cinta.GetChildAt(0).GetChildAt(2), Telerik.WinControls.UI.RadQuickAccessToolBar).ShouldPaint = True
        CType(Me.Cinta.GetChildAt(0).GetChildAt(2), Telerik.WinControls.UI.RadQuickAccessToolBar).ShowHorizontalLine = False
        CType(Me.Cinta.GetChildAt(0).GetChildAt(2), Telerik.WinControls.UI.RadQuickAccessToolBar).Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'rbtEdicion
        '
        Me.rbtEdicion.AccessibleDescription = "Edicion"
        Me.rbtEdicion.AccessibleName = "Edicion"
        Me.rbtEdicion.AutoEllipsis = False
        Me.rbtEdicion.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.rbtEdicion.Font = New System.Drawing.Font("Verdana", 10.0!)
        Me.rbtEdicion.IsSelected = False
        Me.rbtEdicion.Items.AddRange(New Telerik.WinControls.RadItem() {Me.rbgEdicion, Me.rbgBuscar, Me.rbgSelectMult})
        Me.rbtEdicion.Name = "rbtEdicion"
        Me.rbtEdicion.Tag = "1"
        Me.rbtEdicion.Text = "Edición"
        Me.rbtEdicion.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.rbtEdicion.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'rbgEdicion
        '
        Me.rbgEdicion.AccessibleDescription = "a"
        Me.rbgEdicion.AccessibleName = "a"
        Me.rbgEdicion.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.rbgEdicion.Items.AddRange(New Telerik.WinControls.RadItem() {Me.rbAceptar, Me.rbCancelar, Me.rbNuevo})
        Me.rbgEdicion.Margin = New System.Windows.Forms.Padding(0)
        Me.rbgEdicion.MaxSize = New System.Drawing.Size(0, 0)
        Me.rbgEdicion.MinSize = New System.Drawing.Size(0, 0)
        Me.rbgEdicion.Name = "rbgEdicion"
        Me.rbgEdicion.Text = "Edición"
        Me.rbgEdicion.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'rbAceptar
        '
        Me.rbAceptar.AccessibleDescription = "Aceptar"
        Me.rbAceptar.AccessibleName = "Aceptar"
        Me.rbAceptar.Image = CType(resources.GetObject("rbAceptar.Image"), System.Drawing.Image)
        Me.rbAceptar.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbAceptar.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.rbAceptar.Name = "rbAceptar"
        Me.rbAceptar.Text = "Aceptar"
        Me.rbAceptar.TextAlignment = System.Drawing.ContentAlignment.BottomCenter
        Me.rbAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.rbAceptar.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'rbCancelar
        '
        Me.rbCancelar.AccessibleDescription = "Cancelar"
        Me.rbCancelar.AccessibleName = "Cancelar"
        Me.rbCancelar.Image = CType(resources.GetObject("rbCancelar.Image"), System.Drawing.Image)
        Me.rbCancelar.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbCancelar.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.rbCancelar.Name = "rbCancelar"
        Me.rbCancelar.Text = "Cancelar"
        Me.rbCancelar.TextAlignment = System.Drawing.ContentAlignment.BottomCenter
        Me.rbCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.rbCancelar.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'rbNuevo
        '
        Me.rbNuevo.AccessibleDescription = "Nuevo"
        Me.rbNuevo.AccessibleName = "Nuevo"
        Me.rbNuevo.Image = CType(resources.GetObject("rbNuevo.Image"), System.Drawing.Image)
        Me.rbNuevo.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbNuevo.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.rbNuevo.Name = "rbNuevo"
        Me.rbNuevo.Text = "Nuevo"
        Me.rbNuevo.TextAlignment = System.Drawing.ContentAlignment.BottomCenter
        Me.rbNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.rbNuevo.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'rbgBuscar
        '
        Me.rbgBuscar.AccessibleDescription = "Buscar"
        Me.rbgBuscar.AccessibleName = "Buscar"
        Me.rbgBuscar.Items.AddRange(New Telerik.WinControls.RadItem() {Me.rbBuscar})
        Me.rbgBuscar.Margin = New System.Windows.Forms.Padding(0)
        Me.rbgBuscar.MinSize = New System.Drawing.Size(0, 0)
        Me.rbgBuscar.Name = "rbgBuscar"
        Me.rbgBuscar.Text = "Buscar"
        Me.rbgBuscar.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'rbBuscar
        '
        Me.rbBuscar.AccessibleDescription = "Buscar"
        Me.rbBuscar.AccessibleName = "Buscar"
        Me.rbBuscar.AutoSize = True
        Me.rbBuscar.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbBuscar.Image = CType(resources.GetObject("rbBuscar.Image"), System.Drawing.Image)
        Me.rbBuscar.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbBuscar.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.rbBuscar.Name = "rbBuscar"
        Me.rbBuscar.Text = "Buscar"
        Me.rbBuscar.TextAlignment = System.Drawing.ContentAlignment.BottomCenter
        Me.rbBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.rbBuscar.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'rbgSelectMult
        '
        Me.rbgSelectMult.AccessibleDescription = "Selección Multiple"
        Me.rbgSelectMult.AccessibleName = "Selección Multiple"
        Me.rbgSelectMult.AutoSize = False
        Me.rbgSelectMult.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren
        Me.rbgSelectMult.Bounds = New System.Drawing.Rectangle(0, 0, 130, 96)
        Me.rbgSelectMult.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbgSelectMult.Items.AddRange(New Telerik.WinControls.RadItem() {Me.rbSMSelected, Me.rbSMDesSelected})
        Me.rbgSelectMult.Margin = New System.Windows.Forms.Padding(0)
        Me.rbgSelectMult.MaxSize = New System.Drawing.Size(200, 88)
        Me.rbgSelectMult.MinSize = New System.Drawing.Size(130, 0)
        Me.rbgSelectMult.Name = "rbgSelectMult"
        Me.rbgSelectMult.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.rbgSelectMult.Padding = New System.Windows.Forms.Padding(0, 0, 0, -2)
        Me.rbgSelectMult.ShouldPaint = False
        Me.rbgSelectMult.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.[Default]
        Me.rbgSelectMult.StretchHorizontally = True
        Me.rbgSelectMult.StretchVertically = True
        Me.rbgSelectMult.Text = "Selección Multiple"
        Me.rbgSelectMult.TextOrientation = System.Windows.Forms.Orientation.Horizontal
        Me.rbgSelectMult.UseCompatibleTextRendering = True
        Me.rbgSelectMult.UseDefaultDisabledPaint = True
        Me.rbgSelectMult.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'rbSMSelected
        '
        Me.rbSMSelected.AccessibleDescription = "Marcar Todos"
        Me.rbSMSelected.AccessibleName = "Marcar Todos"
        Me.rbSMSelected.Alignment = System.Drawing.ContentAlignment.TopLeft
        Me.rbSMSelected.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.FitToAvailableSize
        Me.rbSMSelected.DisplayStyle = Telerik.WinControls.DisplayStyle.ImageAndText
        Me.rbSMSelected.FitToSizeMode = Telerik.WinControls.RadFitToSizeMode.FitToParentContent
        Me.rbSMSelected.Image = CType(resources.GetObject("rbSMSelected.Image"), System.Drawing.Image)
        Me.rbSMSelected.ImageAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.rbSMSelected.Margin = New System.Windows.Forms.Padding(3, 0, 3, 6)
        Me.rbSMSelected.Name = "rbSMSelected"
        Me.rbSMSelected.StretchHorizontally = True
        Me.rbSMSelected.StretchVertically = False
        Me.rbSMSelected.Text = "Marcar Todos"
        Me.rbSMSelected.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.rbSMSelected.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.rbSMSelected.ToolTipText = "Marcar Todos"
        Me.rbSMSelected.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'rbSMDesSelected
        '
        Me.rbSMDesSelected.AccessibleDescription = "Desmarcar Todos"
        Me.rbSMDesSelected.AccessibleName = "Desmarcar Todos"
        Me.rbSMDesSelected.Alignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.rbSMDesSelected.AutoSize = True
        Me.rbSMDesSelected.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren
        Me.rbSMDesSelected.Image = CType(resources.GetObject("rbSMDesSelected.Image"), System.Drawing.Image)
        Me.rbSMDesSelected.Margin = New System.Windows.Forms.Padding(3, 0, 3, 6)
        Me.rbSMDesSelected.Name = "rbSMDesSelected"
        Me.rbSMDesSelected.StretchHorizontally = True
        Me.rbSMDesSelected.StretchVertically = True
        Me.rbSMDesSelected.Text = "Desmarcar Todos"
        Me.rbSMDesSelected.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.rbSMDesSelected.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.rbSMDesSelected.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'rbConfigura
        '
        Me.rbConfigura.AccessibleDescription = "Configuración"
        Me.rbConfigura.AccessibleName = "Configuración"
        Me.rbConfigura.Font = New System.Drawing.Font("Verdana", 10.0!)
        Me.rbConfigura.IsSelected = True
        Me.rbConfigura.Items.AddRange(New Telerik.WinControls.RadItem() {Me.rbgConfiguracion})
        Me.rbConfigura.Name = "rbConfigura"
        Me.rbConfigura.Text = "Configuración"
        Me.rbConfigura.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'rbgConfiguracion
        '
        Me.rbgConfiguracion.AccessibleDescription = "Configuración"
        Me.rbgConfiguracion.AccessibleName = "Configuración"
        Me.rbgConfiguracion.Items.AddRange(New Telerik.WinControls.RadItem() {Me.rbGuardar, Me.rbOpenForm})
        Me.rbgConfiguracion.Name = "rbgConfiguracion"
        Me.rbgConfiguracion.Text = "Configuración"
        Me.rbgConfiguracion.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'rbGuardar
        '
        Me.rbGuardar.AccessibleDescription = "Guardar"
        Me.rbGuardar.AccessibleName = "Guardar"
        Me.rbGuardar.Alignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbGuardar.DisplayStyle = Telerik.WinControls.DisplayStyle.ImageAndText
        Me.rbGuardar.Image = Global.Bases.My.Resources.Resources.Save
        Me.rbGuardar.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbGuardar.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.rbGuardar.Name = "rbGuardar"
        Me.rbGuardar.Text = "Guardar"
        Me.rbGuardar.TextAlignment = System.Drawing.ContentAlignment.BottomCenter
        Me.rbGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.rbGuardar.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'rbOpenForm
        '
        Me.rbOpenForm.AccessibleDescription = "Abrir Columnas"
        Me.rbOpenForm.AccessibleName = "Abrir Columnas"
        Me.rbOpenForm.DisplayStyle = Telerik.WinControls.DisplayStyle.ImageAndText
        Me.rbOpenForm.Image = Global.Bases.My.Resources.Resources.Add
        Me.rbOpenForm.ImageAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.rbOpenForm.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.rbOpenForm.Name = "rbOpenForm"
        Me.rbOpenForm.Text = "Columnas"
        Me.rbOpenForm.TextAlignment = System.Drawing.ContentAlignment.BottomCenter
        Me.rbOpenForm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.rbOpenForm.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'rsStatus
        '
        Me.rsStatus.Location = New System.Drawing.Point(0, 670)
        Me.rsStatus.Name = "rsStatus"
        Me.rsStatus.Size = New System.Drawing.Size(1016, 25)
        Me.rsStatus.TabIndex = 2
        Me.rsStatus.Text = "RadStatusStrip1"
        Me.rsStatus.ThemeName = "Windows8"
        '
        'btnAdd
        '
        Me.btnAdd.AccessibleDescription = "RadButtonElement1"
        Me.btnAdd.AccessibleName = "RadButtonElement1"
        Me.btnAdd.AutoSize = False
        Me.btnAdd.Bounds = New System.Drawing.Rectangle(0, 0, 80, 62)
        Me.btnAdd.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Text = "Agregar"
        Me.btnAdd.TextAlignment = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnAdd.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'Grid
        '
        Me.Grid.ColRel = Nothing
        Me.Grid.ColSelectFilter = Nothing
        Me.Grid.DataGridType = CustomControls.DataGrid.GridType.Search
        Me.Grid.DBConnection = Nothing
        Me.Grid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid.idRel = Nothing
        Me.Grid.Location = New System.Drawing.Point(0, 164)
        Me.Grid.MarcarFilas = False
        '
        'Grid
        '
        Me.Grid.MasterTemplate.AllowAddNewRow = False
        Me.Grid.MasterTemplate.AllowDeleteRow = False
        Me.Grid.MasterTemplate.AllowEditRow = False
        Me.Grid.MasterTemplate.EnableFiltering = True
        Me.Grid.Name = "Grid"
        Me.Grid.Size = New System.Drawing.Size(1016, 506)
        Me.Grid.TabIndex = 3
        Me.Grid.TablaEdit = Nothing
        Me.Grid.Text = "DataGrid1"
        Me.Grid.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.Grid.ThemeName = "TelerikMetroBlue"
        '
        'Consulta
        '
        Me.AcceptButton = Me.rbAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.rbCancelar
        Me.ClientSize = New System.Drawing.Size(1016, 695)
        Me.Controls.Add(Me.Grid)
        Me.Controls.Add(Me.Cinta)
        Me.Controls.Add(Me.rsStatus)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.KeyPreview = true
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "Consulta"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = true
        Me.Text = "RadRibbonBar1"
        Me.ThemeName = "Windows8"
        CType(Me.Cinta,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.rsStatus,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.Grid.MasterTemplate,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.Grid,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents CustomShape1 As Telerik.WinControls.OldShapeEditor.CustomShape
    Public WithEvents rbtEdicion As Telerik.WinControls.UI.RibbonTab
    Protected Friend WithEvents Windows7Theme1 As Telerik.WinControls.Themes.Windows7Theme
    Protected Friend WithEvents Windows8Theme1 As Telerik.WinControls.Themes.Windows8Theme
    Protected Friend WithEvents rbgEdicion As Telerik.WinControls.UI.RadRibbonBarGroup
    Public WithEvents Cinta As Telerik.WinControls.UI.RadRibbonBar
    Friend WithEvents rsStatus As Telerik.WinControls.UI.RadStatusStrip
    Friend WithEvents rbAceptar As Telerik.WinControls.UI.RadButtonElement
    Friend WithEvents rbCancelar As Telerik.WinControls.UI.RadButtonElement
    Friend WithEvents rbNuevo As Telerik.WinControls.UI.RadButtonElement
    Friend WithEvents btnAdd As Telerik.WinControls.UI.RadButtonElement
    Friend WithEvents rbgSelectMult As Telerik.WinControls.UI.RadRibbonBarGroup
    Friend WithEvents rbSMSelected As Telerik.WinControls.UI.RadButtonElement
    Friend WithEvents rbSMDesSelected As Telerik.WinControls.UI.RadButtonElement
    Friend WithEvents rbgBuscar As Telerik.WinControls.UI.RadRibbonBarGroup
    Friend WithEvents rbBuscar As Telerik.WinControls.UI.RadButtonElement
    Protected WithEvents Grid As CustomControls.DataGrid
    Friend WithEvents rbConfigura As Telerik.WinControls.UI.RibbonTab
    Friend WithEvents rbgConfiguracion As Telerik.WinControls.UI.RadRibbonBarGroup
    Friend WithEvents rbGuardar As Telerik.WinControls.UI.RadButtonElement
    Friend WithEvents rbOpenForm As Telerik.WinControls.UI.RadButtonElement
End Class

