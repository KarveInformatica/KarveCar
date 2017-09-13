<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CrystalViewer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CrystalViewer))
        Me.Windows7Theme1 = New Telerik.WinControls.Themes.Windows7Theme()
        Me.Windows8Theme1 = New Telerik.WinControls.Themes.Windows8Theme()
        Me.rbnRibbon = New Telerik.WinControls.UI.RadRibbonBar()
        Me.rbtImpresion = New Telerik.WinControls.UI.RibbonTab()
        Me.rbgImpresion = New Telerik.WinControls.UI.RadRibbonBarGroup()
        Me.btnPrint = New Telerik.WinControls.UI.RadButtonElement()
        Me.btnExport = New Telerik.WinControls.UI.RadButtonElement()
        Me.rbgNavegacion = New Telerik.WinControls.UI.RadRibbonBarGroup()
        Me.btnFirstPage = New Telerik.WinControls.UI.RadButtonElement()
        Me.btnPrevPage = New Telerik.WinControls.UI.RadButtonElement()
        Me.btnNextPage = New Telerik.WinControls.UI.RadButtonElement()
        Me.btnLastPage = New Telerik.WinControls.UI.RadButtonElement()
        Me.RadRibbonBarGroup3 = New Telerik.WinControls.UI.RadRibbonBarGroup()
        Me.rbgBuscar = New Telerik.WinControls.UI.RadRibbonBarButtonGroup()
        Me.txtBuscar = New Telerik.WinControls.UI.RadTextBoxElement()
        Me.btnBuscar = New Telerik.WinControls.UI.RadButtonElement()
        Me.RadRibbonBarButtonGroup1 = New Telerik.WinControls.UI.RadRibbonBarButtonGroup()
        Me.cbxZoom = New Telerik.WinControls.UI.RadDropDownButtonElement()
        Me.opt400 = New Telerik.WinControls.UI.RadMenuItem()
        Me.opt300 = New Telerik.WinControls.UI.RadMenuItem()
        Me.opt200 = New Telerik.WinControls.UI.RadMenuItem()
        Me.opt150 = New Telerik.WinControls.UI.RadMenuItem()
        Me.opt100 = New Telerik.WinControls.UI.RadMenuItem()
        Me.opt75 = New Telerik.WinControls.UI.RadMenuItem()
        Me.opt50 = New Telerik.WinControls.UI.RadMenuItem()
        Me.opt25 = New Telerik.WinControls.UI.RadMenuItem()
        Me.btnRefresh = New Telerik.WinControls.UI.RadButtonElement()
        Me.stbStatus = New Telerik.WinControls.UI.RadStatusStrip()
        Me.lblPagAct = New Telerik.WinControls.UI.RadLabelElement()
        Me.lblSpace1 = New Telerik.WinControls.UI.RadLabelElement()
        Me.lblMaxPag = New Telerik.WinControls.UI.RadLabelElement()
        Me.lblSpace2 = New Telerik.WinControls.UI.RadLabelElement()
        Me.lblZoom = New Telerik.WinControls.UI.RadLabelElement()
        CType(Me.rbnRibbon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.stbStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rbnRibbon
        '
        Me.rbnRibbon.CommandTabs.AddRange(New Telerik.WinControls.RadItem() {Me.rbtImpresion})
        Me.rbnRibbon.Location = New System.Drawing.Point(0, 0)
        Me.rbnRibbon.Name = "rbnRibbon"
        '
        '
        '
        Me.rbnRibbon.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren
        Me.rbnRibbon.Size = New System.Drawing.Size(1046, 160)
        Me.rbnRibbon.StartButtonImage = CType(resources.GetObject("rbnRibbon.StartButtonImage"), System.Drawing.Image)
        Me.rbnRibbon.TabIndex = 0
        Me.rbnRibbon.Text = "Impresion"
        Me.rbnRibbon.ThemeName = "Windows8"
        Me.rbnRibbon.Visible = False
        '
        'rbtImpresion
        '
        Me.rbtImpresion.AccessibleDescription = "Impresion"
        Me.rbtImpresion.AccessibleName = "Impresion"
        Me.rbtImpresion.IsSelected = True
        Me.rbtImpresion.Items.AddRange(New Telerik.WinControls.RadItem() {Me.rbgImpresion, Me.rbgNavegacion, Me.RadRibbonBarGroup3})
        Me.rbtImpresion.Name = "rbtImpresion"
        Me.rbtImpresion.Tag = "1"
        Me.rbtImpresion.Text = "Impresion"
        Me.rbtImpresion.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'rbgImpresion
        '
        Me.rbgImpresion.AccessibleDescription = "Impresion"
        Me.rbgImpresion.AccessibleName = "Impresion"
        Me.rbgImpresion.Items.AddRange(New Telerik.WinControls.RadItem() {Me.btnPrint, Me.btnExport})
        Me.rbgImpresion.Name = "rbgImpresion"
        Me.rbgImpresion.Text = "Impresion"
        Me.rbgImpresion.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'btnPrint
        '
        Me.btnPrint.AccessibleDescription = "RadButtonElement1"
        Me.btnPrint.AccessibleName = "RadButtonElement1"
        Me.btnPrint.Image = Global.Karve.CrystalPreview.My.Resources.Resources.Print_Def
        Me.btnPrint.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnPrint.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Text = "Imprimir"
        Me.btnPrint.TextAlignment = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnPrint.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'btnExport
        '
        Me.btnExport.AccessibleDescription = "Exportar"
        Me.btnExport.AccessibleName = "Exportar"
        Me.btnExport.Image = Global.Karve.CrystalPreview.My.Resources.Resources.Export_Def
        Me.btnExport.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnExport.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Text = "Exportar"
        Me.btnExport.TextAlignment = System.Drawing.ContentAlignment.BottomCenter
        Me.btnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnExport.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'rbgNavegacion
        '
        Me.rbgNavegacion.AccessibleDescription = "Navegacion"
        Me.rbgNavegacion.AccessibleName = "Navegacion"
        Me.rbgNavegacion.Items.AddRange(New Telerik.WinControls.RadItem() {Me.btnFirstPage, Me.btnPrevPage, Me.btnNextPage, Me.btnLastPage})
        Me.rbgNavegacion.Name = "rbgNavegacion"
        Me.rbgNavegacion.Text = "Navegacion"
        Me.rbgNavegacion.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'btnFirstPage
        '
        Me.btnFirstPage.AccessibleDescription = "Primera"
        Me.btnFirstPage.AccessibleName = "Primera"
        Me.btnFirstPage.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnFirstPage.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.btnFirstPage.Name = "btnFirstPage"
        Me.btnFirstPage.Text = "Primera"
        Me.btnFirstPage.TextAlignment = System.Drawing.ContentAlignment.BottomCenter
        Me.btnFirstPage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnFirstPage.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'btnPrevPage
        '
        Me.btnPrevPage.AccessibleDescription = "Anterior"
        Me.btnPrevPage.AccessibleName = "Anterior"
        Me.btnPrevPage.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnPrevPage.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.btnPrevPage.Name = "btnPrevPage"
        Me.btnPrevPage.Text = "Anterior"
        Me.btnPrevPage.TextAlignment = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPrevPage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnPrevPage.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'btnNextPage
        '
        Me.btnNextPage.AccessibleDescription = "Siguiente"
        Me.btnNextPage.AccessibleName = "Siguiente"
        Me.btnNextPage.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnNextPage.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.btnNextPage.Name = "btnNextPage"
        Me.btnNextPage.Text = "Siguiente"
        Me.btnNextPage.TextAlignment = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNextPage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnNextPage.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'btnLastPage
        '
        Me.btnLastPage.AccessibleDescription = "Utlima"
        Me.btnLastPage.AccessibleName = "Utlima"
        Me.btnLastPage.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnLastPage.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.btnLastPage.Name = "btnLastPage"
        Me.btnLastPage.Text = "Utlima"
        Me.btnLastPage.TextAlignment = System.Drawing.ContentAlignment.BottomCenter
        Me.btnLastPage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnLastPage.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'RadRibbonBarGroup3
        '
        Me.RadRibbonBarGroup3.AccessibleDescription = "Funciones"
        Me.RadRibbonBarGroup3.AccessibleName = "Funciones"
        Me.RadRibbonBarGroup3.Items.AddRange(New Telerik.WinControls.RadItem() {Me.rbgBuscar, Me.RadRibbonBarButtonGroup1})
        Me.RadRibbonBarGroup3.Name = "RadRibbonBarGroup3"
        Me.RadRibbonBarGroup3.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.RadRibbonBarGroup3.Text = "Funciones"
        Me.RadRibbonBarGroup3.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'rbgBuscar
        '
        Me.rbgBuscar.Alignment = System.Drawing.ContentAlignment.TopLeft
        Me.rbgBuscar.Items.AddRange(New Telerik.WinControls.RadItem() {Me.txtBuscar, Me.btnBuscar})
        Me.rbgBuscar.Margin = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.rbgBuscar.Name = "rbgBuscar"
        Me.rbgBuscar.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.rbgBuscar.ShouldPaint = False
        Me.rbgBuscar.StretchHorizontally = True
        Me.rbgBuscar.StretchVertically = False
        Me.rbgBuscar.UseCompatibleTextRendering = True
        Me.rbgBuscar.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'txtBuscar
        '
        Me.txtBuscar.AccessibleDescription = "RadTextBoxElement1"
        Me.txtBuscar.AccessibleName = "RadTextBoxElement1"
        Me.txtBuscar.AutoSize = False
        Me.txtBuscar.Bounds = New System.Drawing.Rectangle(0, 0, 90, 20)
        Me.txtBuscar.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Padding = New System.Windows.Forms.Padding(0, 2, 0, 1)
        Me.txtBuscar.Text = ""
        Me.txtBuscar.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtBuscar.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'btnBuscar
        '
        Me.btnBuscar.AccessibleDescription = "Buscar"
        Me.btnBuscar.AccessibleName = "Buscar"
        Me.btnBuscar.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnBuscar.Image = Global.Karve.CrystalPreview.My.Resources.Resources.Search_20
        Me.btnBuscar.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnBuscar.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'RadRibbonBarButtonGroup1
        '
        Me.RadRibbonBarButtonGroup1.Alignment = System.Drawing.ContentAlignment.TopLeft
        Me.RadRibbonBarButtonGroup1.Items.AddRange(New Telerik.WinControls.RadItem() {Me.cbxZoom, Me.btnRefresh})
        Me.RadRibbonBarButtonGroup1.Name = "RadRibbonBarButtonGroup1"
        Me.RadRibbonBarButtonGroup1.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.RadRibbonBarButtonGroup1.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'cbxZoom
        '
        Me.cbxZoom.AccessibleDescription = "Zoom"
        Me.cbxZoom.AccessibleName = "Zoom"
        Me.cbxZoom.ArrowButtonMinSize = New System.Drawing.Size(12, 12)
        Me.cbxZoom.DropDownDirection = Telerik.WinControls.UI.RadDirection.Down
        Me.cbxZoom.ExpandArrowButton = False
        Me.cbxZoom.Image = Global.Karve.CrystalPreview.My.Resources.Resources.Lupa_mini_Def
        Me.cbxZoom.Items.AddRange(New Telerik.WinControls.RadItem() {Me.opt400, Me.opt300, Me.opt200, Me.opt150, Me.opt100, Me.opt75, Me.opt50, Me.opt25})
        Me.cbxZoom.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.cbxZoom.Name = "cbxZoom"
        Me.cbxZoom.Text = "Zoom"
        Me.cbxZoom.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cbxZoom.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'opt400
        '
        Me.opt400.AccessibleDescription = "400%"
        Me.opt400.AccessibleName = "400%"
        Me.opt400.KeyTip = "400"
        Me.opt400.Name = "opt400"
        Me.opt400.Text = "400%"
        Me.opt400.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'opt300
        '
        Me.opt300.AccessibleDescription = "300%"
        Me.opt300.AccessibleName = "300%"
        Me.opt300.KeyTip = "300"
        Me.opt300.Name = "opt300"
        Me.opt300.Text = "300%"
        Me.opt300.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'opt200
        '
        Me.opt200.AccessibleDescription = "200%"
        Me.opt200.AccessibleName = "200%"
        Me.opt200.KeyTip = "200"
        Me.opt200.Name = "opt200"
        Me.opt200.Text = "200%"
        Me.opt200.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'opt150
        '
        Me.opt150.AccessibleDescription = "150%"
        Me.opt150.AccessibleName = "150%"
        Me.opt150.KeyTip = "150"
        Me.opt150.Name = "opt150"
        Me.opt150.Text = "150%"
        Me.opt150.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'opt100
        '
        Me.opt100.AccessibleDescription = "100%"
        Me.opt100.AccessibleName = "100%"
        Me.opt100.KeyTip = "100"
        Me.opt100.Name = "opt100"
        Me.opt100.Text = "100%"
        Me.opt100.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'opt75
        '
        Me.opt75.AccessibleDescription = "75%"
        Me.opt75.AccessibleName = "75%"
        Me.opt75.KeyTip = "75"
        Me.opt75.Name = "opt75"
        Me.opt75.Text = "75%"
        Me.opt75.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'opt50
        '
        Me.opt50.AccessibleDescription = "50%"
        Me.opt50.AccessibleName = "50%"
        Me.opt50.KeyTip = "50"
        Me.opt50.Name = "opt50"
        Me.opt50.Text = "50%"
        Me.opt50.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'opt25
        '
        Me.opt25.AccessibleDescription = "25%"
        Me.opt25.AccessibleName = "25%"
        Me.opt25.KeyTip = "25"
        Me.opt25.Name = "opt25"
        Me.opt25.Text = "25%"
        Me.opt25.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'btnRefresh
        '
        Me.btnRefresh.AccessibleDescription = "Actualizar"
        Me.btnRefresh.AccessibleName = "Actualizar"
        Me.btnRefresh.Alignment = System.Drawing.ContentAlignment.TopLeft
        Me.btnRefresh.Image = Global.Karve.CrystalPreview.My.Resources.Resources.Actualizar_mini_Def
        Me.btnRefresh.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Text = "Actualizar"
        Me.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnRefresh.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'stbStatus
        '
        Me.stbStatus.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.stbStatus.Items.AddRange(New Telerik.WinControls.RadItem() {Me.lblPagAct, Me.lblSpace1, Me.lblMaxPag, Me.lblSpace2, Me.lblZoom})
        Me.stbStatus.Location = New System.Drawing.Point(0, 518)
        Me.stbStatus.Name = "stbStatus"
        Me.stbStatus.Size = New System.Drawing.Size(1046, 25)
        Me.stbStatus.TabIndex = 1
        Me.stbStatus.ThemeName = "Windows8"
        Me.stbStatus.Visible = False
        '
        'lblPagAct
        '
        Me.lblPagAct.AccessibleDescription = "Nº de página actual: 0"
        Me.lblPagAct.AccessibleName = "Nº de página actual: 0"
        Me.lblPagAct.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblPagAct.Name = "lblPagAct"
        Me.stbStatus.SetSpring(Me.lblPagAct, False)
        Me.lblPagAct.Text = "Nº de página actual: 0"
        Me.lblPagAct.TextWrap = True
        Me.lblPagAct.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'lblSpace1
        '
        Me.lblSpace1.AccessibleDescription = " | "
        Me.lblSpace1.AccessibleName = " | "
        Me.lblSpace1.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblSpace1.Name = "lblSpace1"
        Me.stbStatus.SetSpring(Me.lblSpace1, False)
        Me.lblSpace1.Text = " | "
        Me.lblSpace1.TextWrap = True
        Me.lblSpace1.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'lblMaxPag
        '
        Me.lblMaxPag.AccessibleDescription = "Nº total de páginas: 0"
        Me.lblMaxPag.AccessibleName = "Nº total de páginas: 0"
        Me.lblMaxPag.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblMaxPag.Name = "lblMaxPag"
        Me.stbStatus.SetSpring(Me.lblMaxPag, False)
        Me.lblMaxPag.Text = "Nº total de páginas: 0"
        Me.lblMaxPag.TextWrap = True
        Me.lblMaxPag.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'lblSpace2
        '
        Me.lblSpace2.AccessibleDescription = " | "
        Me.lblSpace2.AccessibleName = " | "
        Me.lblSpace2.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblSpace2.Name = "lblSpace2"
        Me.stbStatus.SetSpring(Me.lblSpace2, False)
        Me.lblSpace2.Text = " | "
        Me.lblSpace2.TextWrap = True
        Me.lblSpace2.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'lblZoom
        '
        Me.lblZoom.AccessibleDescription = "Zoom: 100%"
        Me.lblZoom.AccessibleName = "Zoom: 100%"
        Me.lblZoom.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblZoom.Name = "lblZoom"
        Me.stbStatus.SetSpring(Me.lblZoom, False)
        Me.lblZoom.Text = "Zoom: 100%"
        Me.lblZoom.TextWrap = True
        Me.lblZoom.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'CrystalViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1046, 543)
        Me.Controls.Add(Me.stbStatus)
        Me.Controls.Add(Me.rbnRibbon)
        Me.Name = "CrystalViewer"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Impresion"
        Me.ThemeName = "Windows8"
        CType(Me.rbnRibbon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.stbStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Windows7Theme1 As Telerik.WinControls.Themes.Windows7Theme
    Friend WithEvents Windows8Theme1 As Telerik.WinControls.Themes.Windows8Theme
    Friend WithEvents rbgBuscar As Telerik.WinControls.UI.RadRibbonBarButtonGroup
    Friend WithEvents RadRibbonBarButtonGroup1 As Telerik.WinControls.UI.RadRibbonBarButtonGroup
    Friend WithEvents opt400 As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents opt300 As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents opt200 As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents opt150 As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents opt100 As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents opt75 As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents opt50 As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents opt25 As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents lblSpace1 As Telerik.WinControls.UI.RadLabelElement
    Friend WithEvents lblSpace2 As Telerik.WinControls.UI.RadLabelElement
    Protected Friend WithEvents rbgImpresion As Telerik.WinControls.UI.RadRibbonBarGroup
    Protected Friend WithEvents btnPrint As Telerik.WinControls.UI.RadButtonElement
    Protected Friend WithEvents btnExport As Telerik.WinControls.UI.RadButtonElement
    Protected Friend WithEvents rbgNavegacion As Telerik.WinControls.UI.RadRibbonBarGroup
    Protected Friend WithEvents btnFirstPage As Telerik.WinControls.UI.RadButtonElement
    Protected Friend WithEvents btnPrevPage As Telerik.WinControls.UI.RadButtonElement
    Protected Friend WithEvents btnNextPage As Telerik.WinControls.UI.RadButtonElement
    Protected Friend WithEvents btnLastPage As Telerik.WinControls.UI.RadButtonElement
    Protected Friend WithEvents RadRibbonBarGroup3 As Telerik.WinControls.UI.RadRibbonBarGroup
    Protected Friend WithEvents txtBuscar As Telerik.WinControls.UI.RadTextBoxElement
    Protected Friend WithEvents btnBuscar As Telerik.WinControls.UI.RadButtonElement
    Protected Friend WithEvents cbxZoom As Telerik.WinControls.UI.RadDropDownButtonElement
    Protected Friend WithEvents btnRefresh As Telerik.WinControls.UI.RadButtonElement
    Protected Friend WithEvents lblPagAct As Telerik.WinControls.UI.RadLabelElement
    Protected Friend WithEvents lblMaxPag As Telerik.WinControls.UI.RadLabelElement
    Protected Friend WithEvents lblZoom As Telerik.WinControls.UI.RadLabelElement
    Protected Friend WithEvents rbtImpresion As Telerik.WinControls.UI.RibbonTab
    Protected WithEvents stbStatus As Telerik.WinControls.UI.RadStatusStrip
    Protected Friend WithEvents rbnRibbon As Telerik.WinControls.UI.RadRibbonBar

End Class
