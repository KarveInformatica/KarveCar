<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DataAreaLabel
    Inherits CustomControls.DataArea

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
        CType(Me.txtData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDesc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtData
        '
        Me.txtData.Location = New System.Drawing.Point(0, 23)
        Me.txtData.Size = New System.Drawing.Size(250, 95)
        '
        'lblDesc
        '
        Me.lblDesc.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblDesc.Location = New System.Drawing.Point(-3, 3)
        Me.lblDesc.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblDesc.Name = "lblDesc"
        Me.lblDesc.Size = New System.Drawing.Size(43, 17)
        Me.lblDesc.TabIndex = 2
        Me.lblDesc.Text = "Label1"
        '
        'DataAreaLabel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblDesc)
        Me.Name = "DataAreaLabel"
        Me.Size = New System.Drawing.Size(250, 124)
        Me.Controls.SetChildIndex(Me.txtData, 0)
        Me.Controls.SetChildIndex(Me.lblDesc, 0)
        CType(Me.txtData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDesc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblDesc As CustomControls.Label

End Class
