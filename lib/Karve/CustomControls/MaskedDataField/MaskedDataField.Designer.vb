<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MaskedDataField
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
        Me.txtData = New Telerik.WinControls.UI.RadMaskedEditBox()
        Me.Windows8Theme1 = New Telerik.WinControls.Themes.Windows8Theme()
        Me.Windows7Theme1 = New Telerik.WinControls.Themes.Windows7Theme()
        CType(Me.txtData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtData
        '
        Me.txtData.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtData.AutoSize = False
        Me.txtData.BackColor = System.Drawing.SystemColors.Window
        Me.txtData.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.txtData.Location = New System.Drawing.Point(0, 0)
        Me.txtData.MaskType = Telerik.WinControls.UI.MaskType.Standard
        Me.txtData.Name = "txtData"
        Me.txtData.Size = New System.Drawing.Size(100, 20)
        Me.txtData.TabIndex = 1
        Me.txtData.TabStop = False
        Me.txtData.Text = "____________"
        Me.txtData.ThemeName = "Windows8"
        Me.txtData.UseGenericBorderPaint = True
        CType(Me.txtData.GetChildAt(0), Telerik.WinControls.UI.RadMaskedEditBoxElement).Text = "____________"
        CType(Me.txtData.GetChildAt(0).GetChildAt(2), Telerik.WinControls.Primitives.BorderPrimitive).BottomColor = System.Drawing.Color.FromArgb(CType(CType(172, Byte), Integer), CType(CType(172, Byte), Integer), CType(CType(172, Byte), Integer))
        CType(Me.txtData.GetChildAt(0).GetChildAt(2), Telerik.WinControls.Primitives.BorderPrimitive).ShouldPaint = True
        '
        'MaskedDataField
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.Controls.Add(Me.txtData)
        Me.Name = "MaskedDataField"
        Me.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.Size = New System.Drawing.Size(100, 26)
        CType(Me.txtData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Windows8Theme1 As Telerik.WinControls.Themes.Windows8Theme
    Friend WithEvents Windows7Theme1 As Telerik.WinControls.Themes.Windows7Theme
    Protected Friend WithEvents txtData As Telerik.WinControls.UI.RadMaskedEditBox
End Class
