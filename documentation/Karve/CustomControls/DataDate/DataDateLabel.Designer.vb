<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DataDateLabel
    Inherits CustomControls.DataDate

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
        CType(Me.dtpData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDesc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtpData
        '
        Me.dtpData.Location = New System.Drawing.Point(75, 0)
        Me.dtpData.Text = "30/09/2014"
        Me.dtpData.Value = New Date(2014, 9, 30, 0, 0, 0, 0)
        '
        'lblDesc
        '
        Me.lblDesc.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblDesc.Location = New System.Drawing.Point(-3, 2)
        Me.lblDesc.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblDesc.Name = "lblDesc"
        Me.lblDesc.Size = New System.Drawing.Size(43, 17)
        Me.lblDesc.TabIndex = 2
        Me.lblDesc.Text = "Label1"
        '
        'DataDateLabel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblDesc)
        Me.Name = "DataDateLabel"
        Me.Size = New System.Drawing.Size(165, 26)
        Me.Value_Data = New Date(2014, 9, 30, 0, 0, 0, 0)
        Me.Controls.SetChildIndex(Me.dtpData, 0)
        Me.Controls.SetChildIndex(Me.lblDesc, 0)
        CType(Me.dtpData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDesc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblDesc As CustomControls.Label

End Class
