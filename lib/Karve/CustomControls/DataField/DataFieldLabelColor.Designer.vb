<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DataFieldLabelColor
    Inherits CustomControls.DatafieldLabel

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DataFieldLabelColor))
        Me.btnColorLimpiar = New CustomControls.Button()
        Me.RCD = New Telerik.WinControls.RadColorDialog()
        Me.Windows8Theme1 = New Telerik.WinControls.Themes.Windows8Theme()
        CType(Me.btnAction, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnColorLimpiar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnAction
        '
        Me.btnAction.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnAction.Location = New System.Drawing.Point(210, 0)
        Me.btnAction.Padding = New System.Windows.Forms.Padding(2)
        '
        'txtData
        '
        Me.txtData.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtData.ForeColor = System.Drawing.Color.Black
        '
        '
        '
        Me.txtData.RootElement.AngleTransform = 0.0!
        Me.txtData.RootElement.ApplyShapeToControl = False
        Me.txtData.RootElement.ClipDrawing = False
        Me.txtData.RootElement.FitToSizeMode = Telerik.WinControls.RadFitToSizeMode.FitToParentBounds
        Me.txtData.RootElement.FlipText = True
        Me.txtData.RootElement.Opacity = 100.0R
        Me.txtData.RootElement.ShouldPaint = False
        Me.txtData.RootElement.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.[Default]
        Me.txtData.Size = New System.Drawing.Size(155, 20)
        '
        'btnColorLimpiar
        '
        Me.btnColorLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnColorLimpiar.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnColorLimpiar.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnColorLimpiar.Location = New System.Drawing.Point(236, 0)
        Me.btnColorLimpiar.Name = "btnColorLimpiar"
        Me.btnColorLimpiar.Size = New System.Drawing.Size(20, 20)
        Me.btnColorLimpiar.TabIndex = 3
        Me.btnColorLimpiar.TabStop = False
        Me.btnColorLimpiar.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.btnColorLimpiar.ThemeName = "Windows8"
        '
        'RCD
        '
        Me.RCD.Icon = CType(resources.GetObject("RCD.Icon"), System.Drawing.Icon)
        Me.RCD.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RCD.SelectedColor = System.Drawing.Color.Red
        Me.RCD.SelectedHslColor = Telerik.WinControls.HslColor.FromAhsl(0.0R, 1.0R, 1.0R)
        '
        'DataFieldLabelColor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnColorLimpiar)
        Me.Font_Data = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Name = "DataFieldLabelColor"
        Me.Show_Button = True
        Me.Size = New System.Drawing.Size(257, 25)
        Me.Controls.SetChildIndex(Me.txtData, 0)
        Me.Controls.SetChildIndex(Me.btnAction, 0)
        Me.Controls.SetChildIndex(Me.btnColorLimpiar, 0)
        CType(Me.btnAction, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnColorLimpiar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnColorLimpiar As CustomControls.Button
    Friend WithEvents RCD As Telerik.WinControls.RadColorDialog

End Class
