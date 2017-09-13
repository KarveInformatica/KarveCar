<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ClienteBrow
    Inherits Karve.frm.Clientes.ClienteCons

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
        Me.RibbonTab1 = New Telerik.WinControls.UI.RibbonTab()
        Me.RadRibbonBarGroup1 = New Telerik.WinControls.UI.RadRibbonBarGroup()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grid.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtsResult, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rbtEdicion
        '
        Me.rbtEdicion.BackColor = System.Drawing.Color.White
        Me.rbtEdicion.Bounds = New System.Drawing.Rectangle(0, 0, 64, 28)
        '
        'rbgEdicion
        '
        Me.rbgEdicion.Bounds = New System.Drawing.Rectangle(0, 0, 175, 100)
        '
        'Grid
        '
        Me.Grid.Location = New System.Drawing.Point(0, 164)
        Me.Grid.MarcarFilas = True
        '
        'Grid
        '
        Me.Grid.MasterTemplate.AllowAddNewRow = False
        Me.Grid.MasterTemplate.AllowDeleteRow = False
        Me.Grid.MasterTemplate.AllowEditRow = False
        Me.Grid.MasterTemplate.AutoGenerateColumns = False
        Me.Grid.MasterTemplate.EnableFiltering = True
        Me.Grid.Size = New System.Drawing.Size(1016, 506)
        '
        'RibbonTab1
        '
        Me.RibbonTab1.AccessibleDescription = "Opciones"
        Me.RibbonTab1.AccessibleName = "Opciones"
        Me.RibbonTab1.IsSelected = True
        Me.RibbonTab1.Items.AddRange(New Telerik.WinControls.RadItem() {Me.RadRibbonBarGroup1})
        Me.RibbonTab1.Name = "RibbonTab1"
        Me.RibbonTab1.Text = "Opciones"
        Me.RibbonTab1.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'RadRibbonBarGroup1
        '
        Me.RadRibbonBarGroup1.AccessibleDescription = "Opciones"
        Me.RadRibbonBarGroup1.AccessibleName = "Opciones"
        Me.RadRibbonBarGroup1.Name = "RadRibbonBarGroup1"
        Me.RadRibbonBarGroup1.Text = "Opciones"
        Me.RadRibbonBarGroup1.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'ClienteBrow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1016, 695)
        Me.MarcarFilas = True
        Me.Name = "ClienteBrow"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "ClienteBrow"
        CType(Me.Grid.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtsResult, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RibbonTab1 As Telerik.WinControls.UI.RibbonTab
    Friend WithEvents RadRibbonBarGroup1 As Telerik.WinControls.UI.RadRibbonBarGroup
End Class
