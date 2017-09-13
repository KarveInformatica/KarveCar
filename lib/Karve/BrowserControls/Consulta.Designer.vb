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
        Me.Windows8Theme1 = New Telerik.WinControls.Themes.Windows8Theme()
        Me.RadStatusStrip1 = New Telerik.WinControls.UI.RadStatusStrip()
        Me.Grid = New CustomControls.DataGrid()
        Me.RibbonTab1 = New Telerik.WinControls.UI.RibbonTab()
        Me.Cinta = New Telerik.WinControls.UI.RadRibbonBar()
        Me.RadRibbonFormBehavior1 = New Telerik.WinControls.UI.RadRibbonFormBehavior()
        Me.RadRibbonBarGroup1 = New Telerik.WinControls.UI.RadRibbonBarGroup()
        Me.rbAceptar = New Telerik.WinControls.UI.RadButtonElement()
        Me.rbCancelar = New Telerik.WinControls.UI.RadButtonElement()
        CType(Me.RadStatusStrip1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grid.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cinta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RadStatusStrip1
        '
        Me.RadStatusStrip1.Location = New System.Drawing.Point(0, 645)
        Me.RadStatusStrip1.Name = "RadStatusStrip1"
        Me.RadStatusStrip1.Size = New System.Drawing.Size(702, 26)
        Me.RadStatusStrip1.TabIndex = 1
        Me.RadStatusStrip1.Text = "RadStatusStrip1"
        Me.RadStatusStrip1.ThemeName = "Windows8"
        '
        'Grid
        '
        Me.Grid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid.Location = New System.Drawing.Point(0, 158)
        Me.Grid.Name = "Grid"
        Me.Grid.Size = New System.Drawing.Size(702, 487)
        Me.Grid.TabIndex = 2
        Me.Grid.Text = "DataGrid1"
        Me.Grid.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.Grid.ThemeName = "TelerikMetroBlue"
        '
        'RibbonTab1
        '
        Me.RibbonTab1.AccessibleDescription = "Edición"
        Me.RibbonTab1.AccessibleName = "Edición"
        Me.RibbonTab1.AutoEllipsis = False
        Me.RibbonTab1.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.RibbonTab1.IsSelected = True
        Me.RibbonTab1.Items.AddRange(New Telerik.WinControls.RadItem() {Me.RadRibbonBarGroup1})
        Me.RibbonTab1.Name = "RibbonTab1"
        Me.RibbonTab1.Text = "Edición"
        Me.RibbonTab1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.RibbonTab1.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'Cinta
        '
        Me.Cinta.CommandTabs.AddRange(New Telerik.WinControls.RadItem() {Me.RibbonTab1})
        Me.Cinta.Location = New System.Drawing.Point(0, 0)
        Me.Cinta.Name = "Cinta"
        Me.Cinta.Size = New System.Drawing.Size(702, 158)
        Me.Cinta.StartButtonImage = CType(resources.GetObject("Cinta.StartButtonImage"), System.Drawing.Image)
        Me.Cinta.TabIndex = 0
        Me.Cinta.Text = "Consulta"
        Me.Cinta.ThemeName = "Windows8"
        Me.Cinta.Visible = False
        '
        'RadRibbonFormBehavior1
        '
        Me.RadRibbonFormBehavior1.Form = Me
        '
        'RadRibbonBarGroup1
        '
        Me.RadRibbonBarGroup1.AccessibleDescription = "Edición"
        Me.RadRibbonBarGroup1.AccessibleName = "Edición"
        Me.RadRibbonBarGroup1.Items.AddRange(New Telerik.WinControls.RadItem() {Me.rbAceptar, Me.rbCancelar})
        Me.RadRibbonBarGroup1.Name = "RadRibbonBarGroup1"
        Me.RadRibbonBarGroup1.Text = "Edición"
        Me.RadRibbonBarGroup1.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'rbAceptar
        '
        Me.rbAceptar.AccessibleDescription = "Aceptar"
        Me.rbAceptar.AccessibleName = "Aceptar"
        Me.rbAceptar.Name = "rbAceptar"
        Me.rbAceptar.Text = "Aceptar"
        Me.rbAceptar.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'rbCancelar
        '
        Me.rbCancelar.AccessibleDescription = "Cancelar"
        Me.rbCancelar.AccessibleName = "Cancelar"
        Me.rbCancelar.Name = "rbCancelar"
        Me.rbCancelar.Text = "Cancelar"
        Me.rbCancelar.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'Consulta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(702, 671)
        Me.Controls.Add(Me.Grid)
        Me.Controls.Add(Me.RadStatusStrip1)
        Me.Controls.Add(Me.Cinta)
        Me.FormBehavior = Me.RadRibbonFormBehavior1
        Me.IconScaling = Telerik.WinControls.Enumerations.ImageScaling.None
        Me.Name = "Consulta"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Consulta"
        Me.ThemeName = "Windows8"
        CType(Me.RadStatusStrip1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grid.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cinta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Windows7Theme1 As Telerik.WinControls.Themes.Windows7Theme
    Friend WithEvents Windows8Theme1 As Telerik.WinControls.Themes.Windows8Theme
    Friend WithEvents RadStatusStrip1 As Telerik.WinControls.UI.RadStatusStrip
    Friend WithEvents Grid As CustomControls.DataGrid
    Friend WithEvents RibbonTab1 As Telerik.WinControls.UI.RibbonTab
    Friend WithEvents Cinta As Telerik.WinControls.UI.RadRibbonBar
    Friend WithEvents RadRibbonFormBehavior1 As Telerik.WinControls.UI.RadRibbonFormBehavior
    Friend WithEvents RadRibbonBarGroup1 As Telerik.WinControls.UI.RadRibbonBarGroup
    Friend WithEvents rbAceptar As Telerik.WinControls.UI.RadButtonElement
    Friend WithEvents rbCancelar As Telerik.WinControls.UI.RadButtonElement
End Class

