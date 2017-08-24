<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DualDataFieldEditable
    Inherits CustomControls.DualDatafield

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
        CType(Me.txtData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtfDesc
        '
        Me.dtfDesc.DataTable = ""
        Me.dtfDesc.Location = New System.Drawing.Point(56, -4)
        Me.dtfDesc.ReadOnly_Data = False
        Me.dtfDesc.Size = New System.Drawing.Size(119, 28)
        Me.dtfDesc.TabStop = True
        '
        'txtData
        '
        Me.txtData.Size = New System.Drawing.Size(50, 20)
        '
        'DualDataFieldEditable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Name = "DualDataFieldEditable"
        Me.Text_Width = 50
        CType(Me.txtData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

End Class
