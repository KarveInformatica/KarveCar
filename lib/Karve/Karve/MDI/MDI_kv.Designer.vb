<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MDI_kv
    Inherits System.Windows.Forms.Form

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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnCambioOfi = New System.Windows.Forms.Button()
        Me.btnRelogin = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Tabs = New System.Windows.Forms.TabControl()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblUsu = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblOfi = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btnTest = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnTest)
        Me.Panel1.Controls.Add(Me.btnCambioOfi)
        Me.Panel1.Controls.Add(Me.btnRelogin)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(165, 468)
        Me.Panel1.TabIndex = 3
        '
        'btnCambioOfi
        '
        Me.btnCambioOfi.Location = New System.Drawing.Point(0, 101)
        Me.btnCambioOfi.Name = "btnCambioOfi"
        Me.btnCambioOfi.Size = New System.Drawing.Size(55, 44)
        Me.btnCambioOfi.TabIndex = 2
        Me.btnCambioOfi.Text = "Cambio Ofi."
        Me.btnCambioOfi.UseVisualStyleBackColor = True
        '
        'btnRelogin
        '
        Me.btnRelogin.Location = New System.Drawing.Point(0, 51)
        Me.btnRelogin.Name = "btnRelogin"
        Me.btnRelogin.Size = New System.Drawing.Size(55, 44)
        Me.btnRelogin.TabIndex = 1
        Me.btnRelogin.Text = "Relogin"
        Me.btnRelogin.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(0, 1)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(55, 44)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Tabs
        '
        Me.Tabs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tabs.Location = New System.Drawing.Point(165, 0)
        Me.Tabs.Name = "Tabs"
        Me.Tabs.SelectedIndex = 0
        Me.Tabs.Size = New System.Drawing.Size(582, 468)
        Me.Tabs.TabIndex = 6
        '
        'Panel2
        '
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(165, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(582, 33)
        Me.Panel2.TabIndex = 7
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblUsu, Me.lblOfi})
        Me.StatusStrip1.Location = New System.Drawing.Point(165, 446)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(582, 22)
        Me.StatusStrip1.TabIndex = 9
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblUsu
        '
        Me.lblUsu.Name = "lblUsu"
        Me.lblUsu.Size = New System.Drawing.Size(0, 17)
        '
        'lblOfi
        '
        Me.lblOfi.Name = "lblOfi"
        Me.lblOfi.Size = New System.Drawing.Size(0, 17)
        '
        'btnTest
        '
        Me.btnTest.Location = New System.Drawing.Point(33, 229)
        Me.btnTest.Name = "btnTest"
        Me.btnTest.Size = New System.Drawing.Size(75, 23)
        Me.btnTest.TabIndex = 11
        Me.btnTest.Text = "TEST"
        Me.btnTest.UseVisualStyleBackColor = True
        '
        'MDI_kv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(747, 468)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Tabs)
        Me.Controls.Add(Me.Panel1)
        Me.IsMdiContainer = True
        Me.Name = "MDI_kv"
        Me.Text = "MDI_kv"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Tabs As System.Windows.Forms.TabControl
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnRelogin As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lblUsu As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblOfi As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents btnCambioOfi As System.Windows.Forms.Button
    Friend WithEvents btnTest As System.Windows.Forms.Button
End Class
