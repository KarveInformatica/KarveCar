<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MDI
    Inherits Telerik.WinControls.UI.RadRibbonForm

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
        Me.components = New System.ComponentModel.Container()
        Me.stbMDI = New Telerik.WinControls.UI.RadStatusStrip()
        Me.Windows7Theme1 = New Telerik.WinControls.Themes.Windows7Theme()
        Me.Windows8Theme1 = New Telerik.WinControls.Themes.Windows8Theme()
        Me.Office2013LightTheme1 = New Telerik.WinControls.Themes.Office2013LightTheme()
        Me.dockMDI = New Telerik.WinControls.UI.Docking.RadDock()
        Me.ttsMenu = New Telerik.WinControls.UI.Docking.ToolTabStrip()
        Me.twdTaller = New Telerik.WinControls.UI.Docking.ToolWindow()
        Me.tvwTaller = New Telerik.WinControls.UI.RadTreeView()
        Me.twdConta = New Telerik.WinControls.UI.Docking.ToolWindow()
        Me.tvwConta = New Telerik.WinControls.UI.RadTreeView()
        Me.docContainer = New Telerik.WinControls.UI.Docking.DocumentContainer()
        Me.VisualStudio2012LightTheme1 = New Telerik.WinControls.Themes.VisualStudio2012LightTheme()
        Me.TelerikMetroBlueTheme1 = New Telerik.WinControls.Themes.TelerikMetroBlueTheme()
        Me.Iconos = New System.Windows.Forms.ImageList(Me.components)
        Me.ribbonMDI = New Telerik.WinControls.UI.RadRibbonBar()
        Me.rbtAccesos = New Telerik.WinControls.UI.RibbonTab()
        Me.rbgComunes = New Telerik.WinControls.UI.RadRibbonBarGroup()
        Me.rbgAlquiler = New Telerik.WinControls.UI.RadRibbonBarGroup()
        Me.rbgTaller = New Telerik.WinControls.UI.RadRibbonBarGroup()
        Me.rbgFacturacion = New Telerik.WinControls.UI.RadRibbonBarGroup()
        Me.rbgContabilidad = New Telerik.WinControls.UI.RadRibbonBarGroup()
        Me.rbeIcon = New Telerik.WinControls.UI.RadButtonElement()
        Me.rmiTemas = New Telerik.WinControls.UI.RadMenuItem()
        Me.rmcboTemas = New Telerik.WinControls.UI.RadMenuComboItem()
        Me.rmiConfig = New Telerik.WinControls.UI.RadMenuItem()
        Me.twdAlq = New Telerik.WinControls.UI.Docking.ToolWindow()
        Me.tvwAlq = New Telerik.WinControls.UI.RadTreeView()
        Me.dtfSearchAlq = New CustomControls.Datafield()
        Me.dtfSearchTaller = New CustomControls.Datafield()
        Me.dtfSearchConta = New CustomControls.Datafield()
        CType(Me.stbMDI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dockMDI, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.dockMDI.SuspendLayout()
        CType(Me.ttsMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ttsMenu.SuspendLayout()
        Me.twdTaller.SuspendLayout()
        CType(Me.tvwTaller, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.twdConta.SuspendLayout()
        CType(Me.tvwConta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.docContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ribbonMDI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rmcboTemas.ComboBoxElement, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.twdAlq.SuspendLayout()
        CType(Me.tvwAlq, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'stbMDI
        '
        Me.stbMDI.Location = New System.Drawing.Point(0, 689)
        Me.stbMDI.Name = "stbMDI"
        Me.stbMDI.Size = New System.Drawing.Size(1272, 26)
        Me.stbMDI.SizingGrip = False
        Me.stbMDI.TabIndex = 1
        Me.stbMDI.Text = "RadStatusStrip1"
        Me.stbMDI.ThemeName = "Windows8"
        '
        'dockMDI
        '
        Me.dockMDI.ActiveWindow = Me.twdAlq
        Me.dockMDI.CausesValidation = False
        Me.dockMDI.Controls.Add(Me.ttsMenu)
        Me.dockMDI.Controls.Add(Me.docContainer)
        Me.dockMDI.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dockMDI.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.dockMDI.IsCleanUpTarget = True
        Me.dockMDI.Location = New System.Drawing.Point(0, 163)
        Me.dockMDI.MainDocumentContainer = Me.docContainer
        Me.dockMDI.Name = "dockMDI"
        Me.dockMDI.Padding = New System.Windows.Forms.Padding(0)
        '
        '
        '
        Me.dockMDI.RootElement.MinSize = New System.Drawing.Size(0, 0)
        Me.dockMDI.Size = New System.Drawing.Size(1272, 526)
        Me.dockMDI.SplitterWidth = 2
        Me.dockMDI.TabIndex = 2
        Me.dockMDI.TabStop = False
        Me.dockMDI.Text = "radDock1"
        Me.dockMDI.ThemeName = "Windows8"
        '
        'ttsMenu
        '
        Me.ttsMenu.BackColor = System.Drawing.SystemColors.Control
        Me.ttsMenu.CanUpdateChildIndex = True
        Me.ttsMenu.CausesValidation = False
        Me.ttsMenu.Controls.Add(Me.twdAlq)
        Me.ttsMenu.Controls.Add(Me.twdTaller)
        Me.ttsMenu.Controls.Add(Me.twdConta)
        Me.ttsMenu.Location = New System.Drawing.Point(0, 0)
        Me.ttsMenu.Name = "ttsMenu"
        Me.ttsMenu.SelectedIndex = 0
        Me.ttsMenu.Size = New System.Drawing.Size(200, 526)
        Me.ttsMenu.SizeInfo.SplitterCorrection = New System.Drawing.Size(11, 0)
        Me.ttsMenu.TabIndex = 1
        Me.ttsMenu.TabStop = False
        Me.ttsMenu.ThemeName = "Windows8"
        CType(Me.ttsMenu.GetChildAt(0).GetChildAt(1), Telerik.WinControls.Primitives.BorderPrimitive).BackColor = System.Drawing.SystemColors.Control
        CType(Me.ttsMenu.GetChildAt(0).GetChildAt(1), Telerik.WinControls.Primitives.BorderPrimitive).Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold)
        CType(Me.ttsMenu.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(235, Byte), Integer))
        CType(Me.ttsMenu.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold)
        CType(Me.ttsMenu.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(2).GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Enabled = False
        CType(Me.ttsMenu.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(2).GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Visibility = Telerik.WinControls.ElementVisibility.Visible
        CType(Me.ttsMenu.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(2).GetChildAt(2), Telerik.WinControls.UI.OverflowDropDownButtonElement).AutoSize = False
        CType(Me.ttsMenu.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(2).GetChildAt(2), Telerik.WinControls.UI.OverflowDropDownButtonElement).Enabled = False
        CType(Me.ttsMenu.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(2).GetChildAt(2), Telerik.WinControls.UI.OverflowDropDownButtonElement).Visibility = Telerik.WinControls.ElementVisibility.Visible
        CType(Me.ttsMenu.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(2).GetChildAt(2), Telerik.WinControls.UI.OverflowDropDownButtonElement).StretchHorizontally = True
        CType(Me.ttsMenu.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(2).GetChildAt(2), Telerik.WinControls.UI.OverflowDropDownButtonElement).StretchVertically = True
        CType(Me.ttsMenu.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(2).GetChildAt(3), Telerik.WinControls.Primitives.TextPrimitive).Text = "Alquiler"
        CType(Me.ttsMenu.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(2).GetChildAt(3), Telerik.WinControls.Primitives.TextPrimitive).Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'twdTaller
        '
        Me.twdTaller.Caption = Nothing
        Me.twdTaller.Controls.Add(Me.tvwTaller)
        Me.twdTaller.Controls.Add(Me.dtfSearchTaller)
        Me.twdTaller.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold)
        Me.twdTaller.Location = New System.Drawing.Point(4, 27)
        Me.twdTaller.Name = "twdTaller"
        Me.twdTaller.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.Docked
        Me.twdTaller.Size = New System.Drawing.Size(192, 470)
        Me.twdTaller.Text = "Taller"
        '
        'tvwTaller
        '
        Me.tvwTaller.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvwTaller.Location = New System.Drawing.Point(0, 23)
        Me.tvwTaller.Name = "tvwTaller"
        Me.tvwTaller.Size = New System.Drawing.Size(192, 447)
        Me.tvwTaller.TabIndex = 0
        Me.tvwTaller.Text = "RadTreeView1"
        Me.tvwTaller.ThemeName = "Windows8"
        '
        'twdConta
        '
        Me.twdConta.BackColor = System.Drawing.SystemColors.Control
        Me.twdConta.Caption = Nothing
        Me.twdConta.Controls.Add(Me.tvwConta)
        Me.twdConta.Controls.Add(Me.dtfSearchConta)
        Me.twdConta.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.twdConta.Location = New System.Drawing.Point(4, 27)
        Me.twdConta.Name = "twdConta"
        Me.twdConta.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.Docked
        Me.twdConta.Size = New System.Drawing.Size(192, 470)
        Me.twdConta.Text = "Contabilidad"
        '
        'tvwConta
        '
        Me.tvwConta.BackColor = System.Drawing.SystemColors.Control
        Me.tvwConta.Cursor = System.Windows.Forms.Cursors.Default
        Me.tvwConta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvwConta.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.tvwConta.ForeColor = System.Drawing.SystemColors.ControlText
        Me.tvwConta.Location = New System.Drawing.Point(0, 23)
        Me.tvwConta.Name = "tvwConta"
        Me.tvwConta.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tvwConta.Size = New System.Drawing.Size(192, 447)
        Me.tvwConta.TabIndex = 3
        Me.tvwConta.ThemeName = "Windows8"
        '
        'docContainer
        '
        Me.docContainer.Name = "docContainer"
        '
        '
        '
        Me.docContainer.RootElement.MinSize = New System.Drawing.Size(0, 0)
        Me.docContainer.SizeInfo.AbsoluteSize = New System.Drawing.Size(599, 200)
        Me.docContainer.SizeInfo.SizeMode = Telerik.WinControls.UI.Docking.SplitPanelSizeMode.Fill
        Me.docContainer.SizeInfo.SplitterCorrection = New System.Drawing.Size(-11, 0)
        Me.docContainer.SplitterWidth = 2
        Me.docContainer.TabIndex = 2
        Me.docContainer.ThemeName = "Windows8"
        '
        'Iconos
        '
        Me.Iconos.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.Iconos.ImageSize = New System.Drawing.Size(16, 16)
        Me.Iconos.TransparentColor = System.Drawing.Color.Transparent
        '
        'ribbonMDI
        '
        Me.ribbonMDI.CommandTabs.AddRange(New Telerik.WinControls.RadItem() {Me.rbtAccesos})
        Me.ribbonMDI.Font = New System.Drawing.Font("Verdana", 10.0!)
        Me.ribbonMDI.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ribbonMDI.Location = New System.Drawing.Point(0, 0)
        Me.ribbonMDI.MaximumSize = New System.Drawing.Size(0, 163)
        Me.ribbonMDI.MinimumSize = New System.Drawing.Size(0, 163)
        Me.ribbonMDI.Name = "ribbonMDI"
        Me.ribbonMDI.QuickAccessToolBarHeight = 20
        Me.ribbonMDI.QuickAccessToolBarItems.AddRange(New Telerik.WinControls.RadItem() {Me.rbeIcon})
        '
        '
        '
        Me.ribbonMDI.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren
        Me.ribbonMDI.RootElement.MaxSize = New System.Drawing.Size(0, 163)
        Me.ribbonMDI.RootElement.MinSize = New System.Drawing.Size(0, 163)
        Me.ribbonMDI.Size = New System.Drawing.Size(1272, 163)
        Me.ribbonMDI.StartButtonImage = Global.Karve.My.Resources.Resources.Services_24
        Me.ribbonMDI.StartMenuItems.AddRange(New Telerik.WinControls.RadItem() {Me.rmiTemas, Me.rmiConfig})
        Me.ribbonMDI.TabIndex = 0
        Me.ribbonMDI.Text = "MDI"
        Me.ribbonMDI.ThemeName = "Windows8"
        CType(Me.ribbonMDI.GetChildAt(0), Telerik.WinControls.UI.RadRibbonBarElement).QuickAccessMenuHeight = 20
        CType(Me.ribbonMDI.GetChildAt(0), Telerik.WinControls.UI.RadRibbonBarElement).Text = "MDI"
        CType(Me.ribbonMDI.GetChildAt(0).GetChildAt(2), Telerik.WinControls.UI.RadQuickAccessToolBar).BackColor = System.Drawing.Color.Transparent
        CType(Me.ribbonMDI.GetChildAt(0).GetChildAt(2), Telerik.WinControls.UI.RadQuickAccessToolBar).MinSize = New System.Drawing.Size(0, 20)
        CType(Me.ribbonMDI.GetChildAt(0).GetChildAt(2), Telerik.WinControls.UI.RadQuickAccessToolBar).MaxSize = New System.Drawing.Size(0, 20)
        CType(Me.ribbonMDI.GetChildAt(0).GetChildAt(2).GetChildAt(0), Telerik.WinControls.UI.InnerItem).BackColor = System.Drawing.Color.Transparent
        CType(Me.ribbonMDI.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor = System.Drawing.Color.Transparent
        CType(Me.ribbonMDI.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(2), Telerik.WinControls.UI.InnerItemLayoutElement).BackColor = System.Drawing.Color.Transparent
        CType(Me.ribbonMDI.GetChildAt(0).GetChildAt(2).GetChildAt(1), Telerik.WinControls.UI.RadQuickAccessOverflowButton).Visibility = Telerik.WinControls.ElementVisibility.Hidden
        CType(Me.ribbonMDI.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor = System.Drawing.Color.Transparent
        '
        'rbtAccesos
        '
        Me.rbtAccesos.AccessibleDescription = "Tab1"
        Me.rbtAccesos.AccessibleName = "Tab1"
        Me.rbtAccesos.AutoEllipsis = False
        Me.rbtAccesos.Description = "Tab1"
        Me.rbtAccesos.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.rbtAccesos.EnableImageTransparency = False
        Me.rbtAccesos.IsSelected = True
        Me.rbtAccesos.Items.AddRange(New Telerik.WinControls.RadItem() {Me.rbgComunes, Me.rbgAlquiler, Me.rbgTaller, Me.rbgFacturacion, Me.rbgContabilidad})
        Me.rbtAccesos.Name = "rbtAccesos"
        Me.rbtAccesos.Text = "Accesos Rápidos"
        Me.rbtAccesos.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.rbtAccesos.Title = "Accesos Rápidos"
        Me.rbtAccesos.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'rbgComunes
        '
        Me.rbgComunes.AccessibleDescription = "Comunes"
        Me.rbgComunes.AccessibleName = "Comunes"
        Me.rbgComunes.Name = "rbgComunes"
        Me.rbgComunes.ShowDialogButton = True
        Me.rbgComunes.Text = "Comunes"
        Me.rbgComunes.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'rbgAlquiler
        '
        Me.rbgAlquiler.AccessibleDescription = "Alquiler"
        Me.rbgAlquiler.AccessibleName = "Alquiler"
        Me.rbgAlquiler.Name = "rbgAlquiler"
        Me.rbgAlquiler.ShowDialogButton = True
        Me.rbgAlquiler.Text = "Alquiler"
        Me.rbgAlquiler.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'rbgTaller
        '
        Me.rbgTaller.AccessibleDescription = "Taller"
        Me.rbgTaller.AccessibleName = "Taller"
        Me.rbgTaller.Name = "rbgTaller"
        Me.rbgTaller.ShowDialogButton = True
        Me.rbgTaller.Text = "Taller"
        Me.rbgTaller.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'rbgFacturacion
        '
        Me.rbgFacturacion.AccessibleDescription = "Facturación"
        Me.rbgFacturacion.AccessibleName = "Facturación"
        Me.rbgFacturacion.Name = "rbgFacturacion"
        Me.rbgFacturacion.ShowDialogButton = True
        Me.rbgFacturacion.Text = "Facturación"
        Me.rbgFacturacion.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'rbgContabilidad
        '
        Me.rbgContabilidad.AccessibleDescription = "Contabilidad"
        Me.rbgContabilidad.AccessibleName = "Contabilidad"
        Me.rbgContabilidad.Name = "rbgContabilidad"
        Me.rbgContabilidad.ShowDialogButton = True
        Me.rbgContabilidad.Text = "Contabilidad"
        Me.rbgContabilidad.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'rbeIcon
        '
        Me.rbeIcon.AutoSize = True
        Me.rbeIcon.BackColor = System.Drawing.Color.Transparent
        Me.rbeIcon.DisplayStyle = Telerik.WinControls.DisplayStyle.Image
        Me.rbeIcon.Image = Global.Karve.My.Resources.Resources.K2
        Me.rbeIcon.Name = "rbeIcon"
        Me.rbeIcon.StretchHorizontally = False
        Me.rbeIcon.StretchVertically = False
        Me.rbeIcon.Text = ""
        Me.rbeIcon.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'rmiTemas
        '
        Me.rmiTemas.AccessibleDescription = "Temas"
        Me.rmiTemas.AccessibleName = "Temas"
        Me.rmiTemas.DisplayStyle = Telerik.WinControls.DisplayStyle.ImageAndText
        Me.rmiTemas.Items.AddRange(New Telerik.WinControls.RadItem() {Me.rmcboTemas})
        Me.rmiTemas.Name = "rmiTemas"
        Me.rmiTemas.ShowArrow = True
        Me.rmiTemas.Text = "Temas"
        Me.rmiTemas.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'rmcboTemas
        '
        '
        '
        '
        Me.rmcboTemas.ComboBoxElement.AccessibleDescription = "Defecto"
        Me.rmcboTemas.ComboBoxElement.AccessibleName = "Defecto"
        Me.rmcboTemas.ComboBoxElement.AutoCompleteAppend = Nothing
        Me.rmcboTemas.ComboBoxElement.AutoCompleteDataSource = Nothing
        Me.rmcboTemas.ComboBoxElement.AutoCompleteDisplayMember = Nothing
        Me.rmcboTemas.ComboBoxElement.AutoCompleteSuggest = Nothing
        Me.rmcboTemas.ComboBoxElement.AutoCompleteValueMember = Nothing
        Me.rmcboTemas.ComboBoxElement.DataMember = ""
        Me.rmcboTemas.ComboBoxElement.DataSource = Nothing
        Me.rmcboTemas.ComboBoxElement.DefaultItemsCountInDropDown = 6
        Me.rmcboTemas.ComboBoxElement.DefaultValue = Nothing
        Me.rmcboTemas.ComboBoxElement.DisplayMember = ""
        Me.rmcboTemas.ComboBoxElement.DropDownAnimationEasing = Telerik.WinControls.RadEasingType.InQuad
        Me.rmcboTemas.ComboBoxElement.DropDownAnimationEnabled = True
        Me.rmcboTemas.ComboBoxElement.EditableElementText = ""
        Me.rmcboTemas.ComboBoxElement.EditorElement = Me.rmcboTemas.ComboBoxElement
        Me.rmcboTemas.ComboBoxElement.EditorManager = Nothing
        Me.rmcboTemas.ComboBoxElement.Filter = Nothing
        Me.rmcboTemas.ComboBoxElement.FilterExpression = ""
        Me.rmcboTemas.ComboBoxElement.Focusable = True
        Me.rmcboTemas.ComboBoxElement.FormatString = ""
        Me.rmcboTemas.ComboBoxElement.FormattingEnabled = True
        Me.rmcboTemas.ComboBoxElement.ItemHeight = 18
        Me.rmcboTemas.ComboBoxElement.MaxDropDownItems = 0
        Me.rmcboTemas.ComboBoxElement.MaxLength = 32767
        Me.rmcboTemas.ComboBoxElement.MaxValue = Nothing
        Me.rmcboTemas.ComboBoxElement.MinValue = Nothing
        Me.rmcboTemas.ComboBoxElement.NullValue = Nothing
        Me.rmcboTemas.ComboBoxElement.OwnerOffset = 0
        Me.rmcboTemas.ComboBoxElement.ShowImageInEditorArea = True
        Me.rmcboTemas.ComboBoxElement.SortStyle = Telerik.WinControls.Enumerations.SortStyle.None
        Me.rmcboTemas.ComboBoxElement.Value = Nothing
        Me.rmcboTemas.ComboBoxElement.ValueMember = ""
        Me.rmcboTemas.Name = "rmcboTemas"
        Me.rmcboTemas.Text = ""
        Me.rmcboTemas.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'rmiConfig
        '
        Me.rmiConfig.AccessibleDescription = "rmiConfig"
        Me.rmiConfig.AccessibleName = "rmiConfig"
        Me.rmiConfig.Name = "rmiConfig"
        Me.rmiConfig.Text = "Configuración"
        Me.rmiConfig.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'twdAlq
        '
        Me.twdAlq.Caption = Nothing
        Me.twdAlq.Controls.Add(Me.tvwAlq)
        Me.twdAlq.Controls.Add(Me.dtfSearchAlq)
        Me.twdAlq.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold)
        Me.twdAlq.Location = New System.Drawing.Point(4, 27)
        Me.twdAlq.Name = "twdAlq"
        Me.twdAlq.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.Docked
        Me.twdAlq.Size = New System.Drawing.Size(192, 472)
        Me.twdAlq.Text = "Alquiler"
        '
        'tvwAlq
        '
        Me.tvwAlq.BackColor = System.Drawing.SystemColors.Control
        Me.tvwAlq.Cursor = System.Windows.Forms.Cursors.Default
        Me.tvwAlq.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvwAlq.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.tvwAlq.ForeColor = System.Drawing.SystemColors.ControlText
        Me.tvwAlq.Location = New System.Drawing.Point(0, 23)
        Me.tvwAlq.Name = "tvwAlq"
        Me.tvwAlq.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tvwAlq.Size = New System.Drawing.Size(192, 449)
        Me.tvwAlq.TabIndex = 3
        Me.tvwAlq.ThemeName = "Windows8"
        '
        'dtfSearchAlq
        '
        Me.dtfSearchAlq.Allow_Empty = True
        Me.dtfSearchAlq.Allow_Negative = True
        Me.dtfSearchAlq.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfSearchAlq.BackColor = System.Drawing.SystemColors.Control
        Me.dtfSearchAlq.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfSearchAlq.DataField = Nothing
        Me.dtfSearchAlq.DataTable = "0"
        Me.dtfSearchAlq.Descripcion = Nothing
        Me.dtfSearchAlq.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfSearchAlq.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfSearchAlq.FocoEnAgregar = False
        Me.dtfSearchAlq.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfSearchAlq.Length_Data = 32767
        Me.dtfSearchAlq.Location = New System.Drawing.Point(0, 0)
        Me.dtfSearchAlq.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.dtfSearchAlq.Max_Value = 0.0R
        Me.dtfSearchAlq.MensajeIncorrectoCustom = Nothing
        Me.dtfSearchAlq.Name = "dtfSearchAlq"
        Me.dtfSearchAlq.Null_on_Empty = False
        Me.dtfSearchAlq.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfSearchAlq.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfSearchAlq.ReadOnly_Data = False
        Me.dtfSearchAlq.Size = New System.Drawing.Size(192, 23)
        Me.dtfSearchAlq.TabIndex = 0
        Me.dtfSearchAlq.Text_Data = ""
        Me.dtfSearchAlq.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfSearchAlq.TopPadding = 0
        Me.dtfSearchAlq.Upper_Case = False
        Me.dtfSearchAlq.Validate_on_lost_focus = True
        '
        'dtfSearchTaller
        '
        Me.dtfSearchTaller.Allow_Empty = True
        Me.dtfSearchTaller.Allow_Negative = True
        Me.dtfSearchTaller.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfSearchTaller.BackColor = System.Drawing.SystemColors.Control
        Me.dtfSearchTaller.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfSearchTaller.DataField = Nothing
        Me.dtfSearchTaller.DataTable = "0"
        Me.dtfSearchTaller.Descripcion = Nothing
        Me.dtfSearchTaller.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfSearchTaller.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfSearchTaller.FocoEnAgregar = False
        Me.dtfSearchTaller.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfSearchTaller.Length_Data = 32767
        Me.dtfSearchTaller.Location = New System.Drawing.Point(0, 0)
        Me.dtfSearchTaller.Margin = New System.Windows.Forms.Padding(5, 3, 5, 3)
        Me.dtfSearchTaller.Max_Value = 0.0R
        Me.dtfSearchTaller.MensajeIncorrectoCustom = Nothing
        Me.dtfSearchTaller.Name = "dtfSearchTaller"
        Me.dtfSearchTaller.Null_on_Empty = False
        Me.dtfSearchTaller.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfSearchTaller.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfSearchTaller.ReadOnly_Data = False
        Me.dtfSearchTaller.Size = New System.Drawing.Size(192, 23)
        Me.dtfSearchTaller.TabIndex = 1
        Me.dtfSearchTaller.Text_Data = ""
        Me.dtfSearchTaller.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfSearchTaller.TopPadding = 0
        Me.dtfSearchTaller.Upper_Case = False
        Me.dtfSearchTaller.Validate_on_lost_focus = True
        '
        'dtfSearchConta
        '
        Me.dtfSearchConta.Allow_Empty = True
        Me.dtfSearchConta.Allow_Negative = True
        Me.dtfSearchConta.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfSearchConta.BackColor = System.Drawing.SystemColors.Control
        Me.dtfSearchConta.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfSearchConta.DataField = Nothing
        Me.dtfSearchConta.DataTable = "0"
        Me.dtfSearchConta.Descripcion = Nothing
        Me.dtfSearchConta.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfSearchConta.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfSearchConta.FocoEnAgregar = False
        Me.dtfSearchConta.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfSearchConta.Length_Data = 32767
        Me.dtfSearchConta.Location = New System.Drawing.Point(0, 0)
        Me.dtfSearchConta.Margin = New System.Windows.Forms.Padding(7, 3, 7, 3)
        Me.dtfSearchConta.Max_Value = 0.0R
        Me.dtfSearchConta.MensajeIncorrectoCustom = Nothing
        Me.dtfSearchConta.Name = "dtfSearchConta"
        Me.dtfSearchConta.Null_on_Empty = False
        Me.dtfSearchConta.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfSearchConta.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfSearchConta.ReadOnly_Data = False
        Me.dtfSearchConta.Size = New System.Drawing.Size(192, 23)
        Me.dtfSearchConta.TabIndex = 2
        Me.dtfSearchConta.Text_Data = ""
        Me.dtfSearchConta.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfSearchConta.TopPadding = 0
        Me.dtfSearchConta.Upper_Case = False
        Me.dtfSearchConta.Validate_on_lost_focus = True
        '
        'MDI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1272, 715)
        Me.Controls.Add(Me.dockMDI)
        Me.Controls.Add(Me.ribbonMDI)
        Me.Controls.Add(Me.stbMDI)
        Me.KeyPreview = True
        Me.MainMenuStrip = Nothing
        Me.MinimumSize = New System.Drawing.Size(1278, 720)
        Me.Name = "MDI"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.RootElement.MaxSize = New System.Drawing.Size(0, 0)
        Me.Text = "MDI"
        Me.ThemeName = "Windows8"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.stbMDI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dockMDI, System.ComponentModel.ISupportInitialize).EndInit()
        Me.dockMDI.ResumeLayout(False)
        CType(Me.ttsMenu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ttsMenu.ResumeLayout(False)
        Me.twdTaller.ResumeLayout(False)
        CType(Me.tvwTaller, System.ComponentModel.ISupportInitialize).EndInit()
        Me.twdConta.ResumeLayout(False)
        CType(Me.tvwConta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.docContainer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ribbonMDI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rmcboTemas.ComboBoxElement, System.ComponentModel.ISupportInitialize).EndInit()
        Me.twdAlq.ResumeLayout(False)
        CType(Me.tvwAlq, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ribbonMDI As Telerik.WinControls.UI.RadRibbonBar
    Friend WithEvents stbMDI As Telerik.WinControls.UI.RadStatusStrip
    Friend WithEvents Windows7Theme1 As Telerik.WinControls.Themes.Windows7Theme
    Friend WithEvents Windows8Theme1 As Telerik.WinControls.Themes.Windows8Theme
    Friend WithEvents Office2013LightTheme1 As Telerik.WinControls.Themes.Office2013LightTheme
    Friend WithEvents dockMDI As Telerik.WinControls.UI.Docking.RadDock
    Friend WithEvents docContainer As Telerik.WinControls.UI.Docking.DocumentContainer
    Friend WithEvents rbtAccesos As Telerik.WinControls.UI.RibbonTab
    Friend WithEvents tvwAlq As Telerik.WinControls.UI.RadTreeView
    Friend WithEvents twdAlq As Telerik.WinControls.UI.Docking.ToolWindow
    Friend WithEvents ttsMenu As Telerik.WinControls.UI.Docking.ToolTabStrip
    Friend WithEvents VisualStudio2012LightTheme1 As Telerik.WinControls.Themes.VisualStudio2012LightTheme
    Friend WithEvents twdTaller As Telerik.WinControls.UI.Docking.ToolWindow
    Friend WithEvents tvwTaller As Telerik.WinControls.UI.RadTreeView
    Friend WithEvents twdConta As Telerik.WinControls.UI.Docking.ToolWindow
    Friend WithEvents tvwConta As Telerik.WinControls.UI.RadTreeView
    Friend WithEvents rbeIcon As Telerik.WinControls.UI.RadButtonElement
    Friend WithEvents dtfSearchAlq As CustomControls.Datafield
    Friend WithEvents dtfSearchConta As CustomControls.Datafield
    Friend WithEvents dtfSearchTaller As CustomControls.Datafield
    Friend WithEvents TelerikMetroBlueTheme1 As Telerik.WinControls.Themes.TelerikMetroBlueTheme
    Friend WithEvents rbgComunes As Telerik.WinControls.UI.RadRibbonBarGroup
    Friend WithEvents rbgAlquiler As Telerik.WinControls.UI.RadRibbonBarGroup
    Friend WithEvents rbgTaller As Telerik.WinControls.UI.RadRibbonBarGroup
    Friend WithEvents rbgContabilidad As Telerik.WinControls.UI.RadRibbonBarGroup
    Friend WithEvents Iconos As System.Windows.Forms.ImageList
    Friend WithEvents rbgFacturacion As Telerik.WinControls.UI.RadRibbonBarGroup
    Friend WithEvents rmiTemas As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents rmcboTemas As Telerik.WinControls.UI.RadMenuComboItem
    Friend WithEvents rmiConfig As Telerik.WinControls.UI.RadMenuItem

End Class
