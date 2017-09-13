<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class pnlBrowser
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
        Me.TelerikMetroBlueTheme1 = New Telerik.WinControls.Themes.TelerikMetroBlueTheme()
        Me.dgvDatos = New CustomControls.DataGrid()
        Me.btnActualizar = New System.Windows.Forms.Button()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.btnFiltrar = New System.Windows.Forms.Button()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDatos.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.dgvDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvDatos
        '
        Me.dgvDatos.Controls.Add(Me.btnActualizar)
        Me.dgvDatos.Controls.Add(Me.btnReset)
        Me.dgvDatos.Controls.Add(Me.btnFiltrar)
        Me.dgvDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDatos.Location = New System.Drawing.Point(0, 0)
        '
        'dgvDatos
        '
        Me.dgvDatos.MasterTemplate.AllowAddNewRow = False
        Me.dgvDatos.MasterTemplate.AllowDeleteRow = False
        Me.dgvDatos.MasterTemplate.AllowEditRow = False
        Me.dgvDatos.MasterTemplate.EnableFiltering = True
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.ReadOnly = True
        Me.dgvDatos.Size = New System.Drawing.Size(861, 472)
        Me.dgvDatos.TabIndex = 3
        Me.dgvDatos.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dgvDatos.ThemeName = "TelerikMetroBlue"
        '
        'btnActualizar
        '
        Me.btnActualizar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnActualizar.Location = New System.Drawing.Point(624, 449)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(75, 23)
        Me.btnActualizar.TabIndex = 7
        Me.btnActualizar.Text = "Actualizar"
        Me.btnActualizar.UseVisualStyleBackColor = True
        '
        'btnReset
        '
        Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnReset.Location = New System.Drawing.Point(705, 449)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(75, 23)
        Me.btnReset.TabIndex = 6
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'btnFiltrar
        '
        Me.btnFiltrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFiltrar.Location = New System.Drawing.Point(786, 449)
        Me.btnFiltrar.Name = "btnFiltrar"
        Me.btnFiltrar.Size = New System.Drawing.Size(75, 23)
        Me.btnFiltrar.TabIndex = 5
        Me.btnFiltrar.Text = "Filtrar"
        Me.btnFiltrar.UseVisualStyleBackColor = True
        '
        'pnlBrowser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.dgvDatos)
        Me.Name = "pnlBrowser"
        Me.Size = New System.Drawing.Size(861, 472)
        CType(Me.dgvDatos.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.dgvDatos.ResumeLayout(False)
        Me.dgvDatos.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvDatos As CustomControls.DataGrid
    Friend WithEvents btnFiltrar As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents btnActualizar As System.Windows.Forms.Button
    Friend WithEvents TelerikMetroBlueTheme1 As Telerik.WinControls.Themes.TelerikMetroBlueTheme

End Class
