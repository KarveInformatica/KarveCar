<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DualDataFieldEditableLabel
    Inherits CustomControls.DualDataFieldEditable

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
        Me.lblDesc = New CustomControls.Label()
        Me.btnAction = New CustomControls.Button()
        CType(Me.txtData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDesc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnAction, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtfDesc
        '
        Me.dtfDesc.Location = New System.Drawing.Point(64, 0)
        Me.dtfDesc.Padding = New System.Windows.Forms.Padding(0, 0, 0, 8)
        Me.dtfDesc.Size = New System.Drawing.Size(186, 28)
        '
        'txtData
        '
        Me.txtData.Location = New System.Drawing.Point(50, 0)
        Me.txtData.Size = New System.Drawing.Size(58, 20)
        '
        'lblDesc
        '
        Me.lblDesc.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblDesc.Location = New System.Drawing.Point(-3, 2)
        Me.lblDesc.Name = "lblDesc"
        Me.lblDesc.Size = New System.Drawing.Size(43, 17)
        Me.lblDesc.TabIndex = 2
        Me.lblDesc.Text = "Label1"
        '
        'btnAction
        '
        Me.btnAction.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnAction.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnAction.Image = Global.CustomControls.My.Resources.Resources.lupa_18
        Me.btnAction.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnAction.ImageScalingSize = New System.Drawing.Size(18, 18)
        Me.btnAction.Location = New System.Drawing.Point(230, 0)
        Me.btnAction.Name = "btnAction"
        Me.btnAction.Size = New System.Drawing.Size(20, 20)
        Me.btnAction.TabIndex = 1
        Me.btnAction.TabStop = False
        Me.btnAction.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.btnAction.ThemeName = "Windows8"
        '
        'DualDatafieldLabel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnAction)
        Me.Controls.Add(Me.lblDesc)
        Me.Name = "DualDatafieldEditableLabel"
        Me.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.Size = New System.Drawing.Size(250, 26)
        Me.Text_Width = 58
        Me.Controls.SetChildIndex(Me.dtfDesc, 0)
        Me.Controls.SetChildIndex(Me.lblDesc, 0)
        Me.Controls.SetChildIndex(Me.txtData, 0)
        Me.Controls.SetChildIndex(Me.btnAction, 0)
        CType(Me.txtData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDesc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnAction, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblDesc As CustomControls.Label
    Friend WithEvents btnAction As CustomControls.Button

End Class
