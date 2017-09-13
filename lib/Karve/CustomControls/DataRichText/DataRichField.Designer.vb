Imports Telerik.WinControls.RichTextBox

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DataRichField
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
        Me.Windows8Theme1 = New Telerik.WinControls.Themes.Windows8Theme()
        Me.Windows7Theme1 = New Telerik.WinControls.Themes.Windows7Theme()
        Me.rtbData = New Telerik.WinControls.RichTextBox.RadRichTextBox()
        CType(Me.rtbData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rtbData
        '
        Me.rtbData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbData.BackColor = System.Drawing.SystemColors.Window
        Me.rtbData.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbData.HyperlinkToolTipFormatString = Nothing
        Me.rtbData.Location = New System.Drawing.Point(0, 0)
        Me.rtbData.Name = "rtbData"
        '
        '
        '
        Me.rtbData.RootElement.Text = ""
        Me.rtbData.Size = New System.Drawing.Size(250, 97)
        Me.rtbData.TabIndex = 0
        Me.rtbData.ThemeName = "Windows8"
        CType(Me.rtbData.GetChildAt(0), Telerik.WinControls.RichTextBox.RadRichTextBoxElement).Text = ""
        CType(Me.rtbData.GetChildAt(0).GetChildAt(0), Telerik.WinControls.RichTextBox.DocumentEditorElement).Text = ""
        CType(Me.rtbData.GetChildAt(0).GetChildAt(0), Telerik.WinControls.RichTextBox.DocumentEditorElement).Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'DataArea
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.rtbData)
        Me.Name = "DataArea"
        Me.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.Size = New System.Drawing.Size(250, 100)
        CType(Me.rtbData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Windows8Theme1 As Telerik.WinControls.Themes.Windows8Theme
    Friend WithEvents Windows7Theme1 As Telerik.WinControls.Themes.Windows7Theme
    Protected Friend WithEvents rtbData As Telerik.WinControls.RichTextBox.RadRichTextBox

End Class
