<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class pnlBloqueo
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
        Me.pnlBlocked = New CustomControls.Panel()
        Me.txtDesde = New CustomControls.Label()
        Me.lblUsuario = New CustomControls.Label()
        Me.txtUsuario = New CustomControls.Label()
        Me.lblDesde = New CustomControls.Label()
        Me.pnlColor = New CustomControls.Panel()
        Me.lblInfo = New CustomControls.Label()
        Me.pnlEdit = New CustomControls.Panel()
        Me.btnEdit = New CustomControls.Button()
        Me.lblEdit = New CustomControls.Label()
        CType(Me.pnlBlocked, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBlocked.SuspendLayout()
        CType(Me.txtDesde, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDesde, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlColor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEdit.SuspendLayout()
        CType(Me.btnEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlBlocked
        '
        Me.pnlBlocked.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlBlocked.Controls.Add(Me.txtDesde)
        Me.pnlBlocked.Controls.Add(Me.lblUsuario)
        Me.pnlBlocked.Controls.Add(Me.txtUsuario)
        Me.pnlBlocked.Controls.Add(Me.lblDesde)
        Me.pnlBlocked.Location = New System.Drawing.Point(5, 36)
        Me.pnlBlocked.Name = "pnlBlocked"
        Me.pnlBlocked.Size = New System.Drawing.Size(118, 89)
        Me.pnlBlocked.TabIndex = 6
        Me.pnlBlocked.ThemeName = "Windows8"
        '
        'txtDesde
        '
        Me.txtDesde.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.txtDesde.Location = New System.Drawing.Point(5, 47)
        Me.txtDesde.Name = "txtDesde"
        Me.txtDesde.Size = New System.Drawing.Size(41, 17)
        Me.txtDesde.TabIndex = 5
        Me.txtDesde.Text = "Desde"
        '
        'lblUsuario
        '
        Me.lblUsuario.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblUsuario.Location = New System.Drawing.Point(0, 0)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(58, 17)
        Me.lblUsuario.TabIndex = 2
        Me.lblUsuario.Text = "Usuario :"
        '
        'txtUsuario
        '
        Me.txtUsuario.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.txtUsuario.Location = New System.Drawing.Point(5, 15)
        Me.txtUsuario.MaximumSize = New System.Drawing.Size(128, 0)
        Me.txtUsuario.Name = "txtUsuario"
        '
        '
        '
        Me.txtUsuario.RootElement.MaxSize = New System.Drawing.Size(128, 0)
        Me.txtUsuario.Size = New System.Drawing.Size(49, 17)
        Me.txtUsuario.TabIndex = 4
        Me.txtUsuario.Text = "Usuario"
        '
        'lblDesde
        '
        Me.lblDesde.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblDesde.Location = New System.Drawing.Point(0, 32)
        Me.lblDesde.Name = "lblDesde"
        Me.lblDesde.Size = New System.Drawing.Size(50, 17)
        Me.lblDesde.TabIndex = 3
        Me.lblDesde.Text = "Desde :"
        '
        'pnlColor
        '
        Me.pnlColor.BackColor = System.Drawing.Color.Red
        Me.pnlColor.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlColor.Location = New System.Drawing.Point(3, 9)
        Me.pnlColor.Name = "pnlColor"
        Me.pnlColor.Size = New System.Drawing.Size(17, 17)
        Me.pnlColor.TabIndex = 1
        Me.pnlColor.ThemeName = "Windows8"
        CType(Me.pnlColor.GetChildAt(0).GetChildAt(1), Telerik.WinControls.Primitives.BorderPrimitive).LeftColor = System.Drawing.Color.Red
        CType(Me.pnlColor.GetChildAt(0).GetChildAt(1), Telerik.WinControls.Primitives.BorderPrimitive).TopColor = System.Drawing.Color.Red
        CType(Me.pnlColor.GetChildAt(0).GetChildAt(1), Telerik.WinControls.Primitives.BorderPrimitive).RightColor = System.Drawing.Color.Red
        CType(Me.pnlColor.GetChildAt(0).GetChildAt(1), Telerik.WinControls.Primitives.BorderPrimitive).BottomColor = System.Drawing.Color.Red
        CType(Me.pnlColor.GetChildAt(0).GetChildAt(1), Telerik.WinControls.Primitives.BorderPrimitive).ForeColor = System.Drawing.SystemColors.Control
        '
        'lblInfo
        '
        Me.lblInfo.AutoSize = False
        Me.lblInfo.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblInfo.Location = New System.Drawing.Point(23, 3)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(100, 37)
        Me.lblInfo.TabIndex = 0
        Me.lblInfo.Text = "<html><p>REGISTRO </p><p>BLOQUEADO</p></html>"
        Me.lblInfo.TextAlignment = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlEdit
        '
        Me.pnlEdit.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlEdit.Controls.Add(Me.btnEdit)
        Me.pnlEdit.Controls.Add(Me.lblEdit)
        Me.pnlEdit.Location = New System.Drawing.Point(5, 36)
        Me.pnlEdit.Name = "pnlEdit"
        Me.pnlEdit.Size = New System.Drawing.Size(120, 79)
        Me.pnlEdit.TabIndex = 7
        Me.pnlEdit.ThemeName = "Windows8"
        '
        'btnEdit
        '
        Me.btnEdit.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnEdit.Location = New System.Drawing.Point(23, 49)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(75, 20)
        Me.btnEdit.TabIndex = 7
        Me.btnEdit.Text = "Editar"
        Me.btnEdit.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.btnEdit.ThemeName = "Windows8"
        '
        'lblEdit
        '
        Me.lblEdit.AutoSize = False
        Me.lblEdit.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblEdit.Location = New System.Drawing.Point(3, 7)
        Me.lblEdit.Name = "lblEdit"
        Me.lblEdit.Size = New System.Drawing.Size(111, 42)
        Me.lblEdit.TabIndex = 6
        Me.lblEdit.Text = "El registro esta desbloqueado."
        '
        'pnlBloqueo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.Controls.Add(Me.pnlBlocked)
        Me.Controls.Add(Me.pnlColor)
        Me.Controls.Add(Me.lblInfo)
        Me.Controls.Add(Me.pnlEdit)
        Me.Name = "pnlBloqueo"
        Me.Size = New System.Drawing.Size(123, 125)
        CType(Me.pnlBlocked, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBlocked.ResumeLayout(False)
        Me.pnlBlocked.PerformLayout()
        CType(Me.txtDesde, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDesde, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlColor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblInfo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlEdit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEdit.ResumeLayout(False)
        CType(Me.btnEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblEdit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblInfo As CustomControls.Label
    Friend WithEvents pnlColor As CustomControls.Panel
    Friend WithEvents lblDesde As CustomControls.Label
    Friend WithEvents lblUsuario As CustomControls.Label
    Friend WithEvents txtUsuario As CustomControls.Label
    Friend WithEvents txtDesde As CustomControls.Label
    Friend WithEvents pnlBlocked As CustomControls.Panel
    Friend WithEvents pnlEdit As CustomControls.Panel
    Friend WithEvents btnEdit As CustomControls.Button
    Friend WithEvents lblEdit As CustomControls.Label

End Class
