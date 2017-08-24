<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DataTime
    Inherits CustomControls.ctrBase

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
        Me.tmpData = New Telerik.WinControls.UI.RadTimePicker()
        Me.Windows8Theme1 = New Telerik.WinControls.Themes.Windows8Theme()
        CType(Me.tmpData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tmpData
        '
        Me.tmpData.AutoSize = False
        Me.tmpData.Location = New System.Drawing.Point(0, 0)
        Me.tmpData.MaxValue = New Date(1900, 1, 1, 23, 59, 0, 0)
        Me.tmpData.Name = "tmpData"
        Me.tmpData.NullText = "__:__"
        Me.tmpData.Size = New System.Drawing.Size(76, 20)
        Me.tmpData.TabIndex = 0
        Me.tmpData.TabStop = False
        Me.tmpData.ThemeName = "Windows8"
        Me.tmpData.Value = New Date(2015, 3, 3, 10, 59, 0, 0)
        CType(Me.tmpData.GetChildAt(0).GetChildAt(2).GetChildAt(0), Telerik.WinControls.UI.RadTimeMaskedEditBoxElement).Text = "10:59"
        '
        'DataTime
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tmpData)
        Me.Name = "DataTime"
        Me.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.Size = New System.Drawing.Size(77, 26)
        CType(Me.tmpData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Windows8Theme1 As Telerik.WinControls.Themes.Windows8Theme
    Protected Friend WithEvents tmpData As Telerik.WinControls.UI.RadTimePicker

End Class
