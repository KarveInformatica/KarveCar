<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Button
    Inherits Telerik.WinControls.UI.RadButton

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Windows7Theme1 = New Telerik.WinControls.Themes.Windows7Theme()
        Me.Windows8Theme1 = New Telerik.WinControls.Themes.Windows8Theme()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button
        '
        Me.Size = New System.Drawing.Size(75, 23)
        Me.ThemeName = "Windows8"
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents Windows7Theme1 As Telerik.WinControls.Themes.Windows7Theme
    Public WithEvents Windows8Theme1 As Telerik.WinControls.Themes.Windows8Theme

End Class

