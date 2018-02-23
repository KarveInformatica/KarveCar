<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TrackBar
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
        Me.trbBarra = New Telerik.WinControls.UI.RadTrackBar()
        CType(Me.trbBarra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'trbBarra
        '
        Me.trbBarra.Dock = System.Windows.Forms.DockStyle.Fill
        Me.trbBarra.LargeTickFrequency = 2
        Me.trbBarra.Location = New System.Drawing.Point(0, 0)
        Me.trbBarra.Maximum = 16.0!
        Me.trbBarra.Name = "trbBarra"
        Me.trbBarra.Padding = New System.Windows.Forms.Padding(6, 5, 6, 0)
        Me.trbBarra.Size = New System.Drawing.Size(318, 42)
        Me.trbBarra.TabIndex = 0
        Me.trbBarra.ThemeName = "Windows8"
        '
        'TrackBar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.trbBarra)
        Me.Name = "TrackBar"
        Me.Size = New System.Drawing.Size(318, 49)
        CType(Me.trbBarra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents trbBarra As Telerik.WinControls.UI.RadTrackBar

End Class
