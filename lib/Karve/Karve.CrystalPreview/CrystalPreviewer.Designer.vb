<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CrystalPreviewer
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
        Me.bgwPrint = New System.ComponentModel.BackgroundWorker()
        Me.bgwPrintToFile = New System.ComponentModel.BackgroundWorker()
        Me.SuspendLayout()
        '
        'bgwPrint
        '
        '
        'CrystalPreviewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Name = "CrystalPreviewer"
        Me.ResumeLayout(False)

    End Sub
    Protected Friend WithEvents bgwPrint As System.ComponentModel.BackgroundWorker
    Friend WithEvents bgwPrintToFile As System.ComponentModel.BackgroundWorker

End Class
