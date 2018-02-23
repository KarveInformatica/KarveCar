<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RibbonContratos
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RibbonContratos))
        Me.Windows8Theme1 = New Telerik.WinControls.Themes.Windows8Theme()
        Me.RadRibbonBarGroup1 = New Telerik.WinControls.UI.RadRibbonBarGroup()
        Me.ribbon = New CustomControls.RibbonBar()
        Me.rbtContrato = New Telerik.WinControls.UI.RibbonTab()
        Me.rbgCierre = New Telerik.WinControls.UI.RadRibbonBarGroup()
        Me.btnVerCierre = New Telerik.WinControls.UI.RadButtonElement()
        Me.btnCerrar = New Telerik.WinControls.UI.RadButtonElement()
        Me.btnProlongar = New Telerik.WinControls.UI.RadButtonElement()
        Me.btnReabrir = New Telerik.WinControls.UI.RadButtonElement()
        Me.rbgFacturacion = New Telerik.WinControls.UI.RadRibbonBarGroup()
        Me.btnFacturar = New Telerik.WinControls.UI.RadButtonElement()
        Me.btnCobros = New Telerik.WinControls.UI.RadButtonElement()
        CType(Me.ribbon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RadRibbonBarGroup1
        '
        Me.RadRibbonBarGroup1.AccessibleDescription = "!"
        Me.RadRibbonBarGroup1.AccessibleName = "!"
        Me.RadRibbonBarGroup1.Margin = New System.Windows.Forms.Padding(0)
        Me.RadRibbonBarGroup1.MaxSize = New System.Drawing.Size(0, 0)
        Me.RadRibbonBarGroup1.MinSize = New System.Drawing.Size(0, 0)
        Me.RadRibbonBarGroup1.Name = "RadRibbonBarGroup1"
        Me.RadRibbonBarGroup1.Text = "!"
        Me.RadRibbonBarGroup1.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'ribbon
        '
        Me.ribbon.Change = "True"
        Me.ribbon.CommandTabs.AddRange(New Telerik.WinControls.RadItem() {Me.rbtContrato})
        Me.ribbon.Location = New System.Drawing.Point(0, 0)
        Me.ribbon.Name = "ribbon"
        Me.ribbon.Size = New System.Drawing.Size(1080, 160)
        Me.ribbon.StartButtonImage = CType(resources.GetObject("ribbon.StartButtonImage"), System.Drawing.Image)
        Me.ribbon.TabIndex = 0
        Me.ribbon.Text = "RibbonBar1"
        Me.ribbon.ThemeName = "Windows8"
        '
        'rbtContrato
        '
        Me.rbtContrato.AccessibleDescription = "Contratos"
        Me.rbtContrato.AccessibleName = "Contratos"
        Me.rbtContrato.Alignment = System.Drawing.ContentAlignment.TopLeft
        Me.rbtContrato.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.rbtContrato.IsSelected = True
        Me.rbtContrato.Items.AddRange(New Telerik.WinControls.RadItem() {Me.rbgCierre, Me.rbgFacturacion})
        Me.rbtContrato.Name = "rbtContrato"
        Me.rbtContrato.Tag = ""
        Me.rbtContrato.Text = "Contrato"
        Me.rbtContrato.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'rbgCierre
        '
        Me.rbgCierre.AccessibleDescription = "Cierre"
        Me.rbgCierre.AccessibleName = "Cierre"
        Me.rbgCierre.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.rbgCierre.Items.AddRange(New Telerik.WinControls.RadItem() {Me.btnVerCierre, Me.btnCerrar, Me.btnProlongar, Me.btnReabrir})
        Me.rbgCierre.Name = "rbgCierre"
        Me.rbgCierre.Text = "Cierre"
        Me.rbgCierre.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'btnVerCierre
        '
        Me.btnVerCierre.AccessibleDescription = "Ver Cierre"
        Me.btnVerCierre.AccessibleName = "Ver Cierre"
        Me.btnVerCierre.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnVerCierre.Image = CType(resources.GetObject("btnVerCierre.Image"), System.Drawing.Image)
        Me.btnVerCierre.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnVerCierre.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.btnVerCierre.Name = "btnVerCierre"
        Me.btnVerCierre.Text = "Ver Cierre"
        Me.btnVerCierre.TextAlignment = System.Drawing.ContentAlignment.BottomCenter
        Me.btnVerCierre.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnVerCierre.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'btnCerrar
        '
        Me.btnCerrar.AccessibleDescription = "Cerrar"
        Me.btnCerrar.AccessibleName = "Cerrar"
        Me.btnCerrar.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnCerrar.Image = CType(resources.GetObject("btnCerrar.Image"), System.Drawing.Image)
        Me.btnCerrar.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnCerrar.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.TextAlignment = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnCerrar.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'btnProlongar
        '
        Me.btnProlongar.AccessibleDescription = "Prolongar"
        Me.btnProlongar.AccessibleName = "Prolongar"
        Me.btnProlongar.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnProlongar.Image = CType(resources.GetObject("btnProlongar.Image"), System.Drawing.Image)
        Me.btnProlongar.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnProlongar.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.btnProlongar.Name = "btnProlongar"
        Me.btnProlongar.Text = "Prolongar"
        Me.btnProlongar.TextAlignment = System.Drawing.ContentAlignment.BottomCenter
        Me.btnProlongar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnProlongar.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'btnReabrir
        '
        Me.btnReabrir.AccessibleDescription = "Reabrir"
        Me.btnReabrir.AccessibleName = "Reabrir"
        Me.btnReabrir.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnReabrir.Image = CType(resources.GetObject("btnReabrir.Image"), System.Drawing.Image)
        Me.btnReabrir.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnReabrir.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.btnReabrir.Name = "btnReabrir"
        Me.btnReabrir.Text = "Reabrir"
        Me.btnReabrir.TextAlignment = System.Drawing.ContentAlignment.BottomCenter
        Me.btnReabrir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnReabrir.TextOrientation = System.Windows.Forms.Orientation.Horizontal
        Me.btnReabrir.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'rbgFacturacion
        '
        Me.rbgFacturacion.AccessibleDescription = "Facturacion"
        Me.rbgFacturacion.AccessibleName = "Facturacion"
        Me.rbgFacturacion.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.rbgFacturacion.Items.AddRange(New Telerik.WinControls.RadItem() {Me.btnFacturar, Me.btnCobros})
        Me.rbgFacturacion.Name = "rbgFacturacion"
        Me.rbgFacturacion.Text = "Facturacion"
        Me.rbgFacturacion.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'btnFacturar
        '
        Me.btnFacturar.AccessibleDescription = "Facturar"
        Me.btnFacturar.AccessibleName = "Facturar"
        Me.btnFacturar.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnFacturar.Image = CType(resources.GetObject("btnFacturar.Image"), System.Drawing.Image)
        Me.btnFacturar.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.btnFacturar.Name = "btnFacturar"
        Me.btnFacturar.Text = "Facturar"
        Me.btnFacturar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnFacturar.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'btnCobros
        '
        Me.btnCobros.AccessibleDescription = "Cobros"
        Me.btnCobros.AccessibleName = "Cobros"
        Me.btnCobros.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnCobros.Image = CType(resources.GetObject("btnCobros.Image"), System.Drawing.Image)
        Me.btnCobros.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.btnCobros.Name = "btnCobros"
        Me.btnCobros.Text = "Cobros"
        Me.btnCobros.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnCobros.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'RibbonContratos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ribbon)
        Me.Name = "RibbonContratos"
        Me.Size = New System.Drawing.Size(1080, 157)
        CType(Me.ribbon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ribbon As CustomControls.RibbonBar
    Friend WithEvents Windows8Theme1 As Telerik.WinControls.Themes.Windows8Theme
    Friend WithEvents RadRibbonBarGroup1 As Telerik.WinControls.UI.RadRibbonBarGroup
    Friend WithEvents rbtContrato As Telerik.WinControls.UI.RibbonTab
    Friend WithEvents rbgCierre As Telerik.WinControls.UI.RadRibbonBarGroup
    Friend WithEvents btnVerCierre As Telerik.WinControls.UI.RadButtonElement
    Friend WithEvents btnCerrar As Telerik.WinControls.UI.RadButtonElement
    Friend WithEvents btnProlongar As Telerik.WinControls.UI.RadButtonElement
    Friend WithEvents btnReabrir As Telerik.WinControls.UI.RadButtonElement
    Friend WithEvents rbgFacturacion As Telerik.WinControls.UI.RadRibbonBarGroup
    Friend WithEvents btnFacturar As Telerik.WinControls.UI.RadButtonElement
    Friend WithEvents btnCobros As Telerik.WinControls.UI.RadButtonElement

End Class
