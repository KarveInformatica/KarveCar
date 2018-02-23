<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DataDate
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
        Me.dtpData = New Telerik.WinControls.UI.RadDateTimePicker()
        CType(Me.dtpData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtpData
        '
        Me.dtpData.AutoSize = False
        Me.dtpData.BackColor = System.Drawing.SystemColors.Window
        Me.dtpData.CustomFormat = "__/__/____"
        Me.dtpData.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtpData.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpData.Location = New System.Drawing.Point(0, 0)
        Me.dtpData.Name = "dtpData"
        Me.dtpData.NullText = "__/__/____"
        Me.dtpData.Size = New System.Drawing.Size(90, 20)
        Me.dtpData.TabIndex = 3
        Me.dtpData.TabStop = False
        Me.dtpData.Text = "25/09/2014"
        Me.dtpData.ThemeName = "Windows8"
        Me.dtpData.Value = New Date(2014, 9, 25, 0, 0, 0, 0)
        CType(Me.dtpData.GetChildAt(0), Telerik.WinControls.UI.RadDateTimePickerElement).UseDefaultDisabledPaint = True
        CType(Me.dtpData.GetChildAt(0), Telerik.WinControls.UI.RadDateTimePickerElement).TextOrientation = System.Windows.Forms.Orientation.Horizontal
        CType(Me.dtpData.GetChildAt(0), Telerik.WinControls.UI.RadDateTimePickerElement).Visibility = Telerik.WinControls.ElementVisibility.Visible
        CType(Me.dtpData.GetChildAt(0).GetChildAt(1), Telerik.WinControls.Primitives.BorderPrimitive).BorderDashStyle = System.Drawing.Drawing2D.DashStyle.Solid
        CType(Me.dtpData.GetChildAt(0).GetChildAt(1), Telerik.WinControls.Primitives.BorderPrimitive).ForeColor2 = System.Drawing.SystemColors.ControlDark
        CType(Me.dtpData.GetChildAt(0).GetChildAt(1), Telerik.WinControls.Primitives.BorderPrimitive).ForeColor3 = System.Drawing.SystemColors.ControlDark
        CType(Me.dtpData.GetChildAt(0).GetChildAt(1), Telerik.WinControls.Primitives.BorderPrimitive).ForeColor4 = System.Drawing.SystemColors.ControlDark
        CType(Me.dtpData.GetChildAt(0).GetChildAt(1), Telerik.WinControls.Primitives.BorderPrimitive).InnerColor4 = System.Drawing.SystemColors.ControlDarkDark
        CType(Me.dtpData.GetChildAt(0).GetChildAt(1), Telerik.WinControls.Primitives.BorderPrimitive).ForeColor = System.Drawing.SystemColors.ControlDark
        CType(Me.dtpData.GetChildAt(0).GetChildAt(2), Telerik.WinControls.UI.StackLayoutElement).BorderColor = System.Drawing.SystemColors.ControlDarkDark
        CType(Me.dtpData.GetChildAt(0).GetChildAt(2), Telerik.WinControls.UI.StackLayoutElement).BorderColor2 = System.Drawing.SystemColors.ControlDark
        CType(Me.dtpData.GetChildAt(0).GetChildAt(2), Telerik.WinControls.UI.StackLayoutElement).BorderColor3 = System.Drawing.SystemColors.ControlDark
        CType(Me.dtpData.GetChildAt(0).GetChildAt(2), Telerik.WinControls.UI.StackLayoutElement).BorderColor4 = System.Drawing.SystemColors.ControlDark
        CType(Me.dtpData.GetChildAt(0).GetChildAt(2), Telerik.WinControls.UI.StackLayoutElement).BorderTopColor = System.Drawing.SystemColors.ControlDark
        CType(Me.dtpData.GetChildAt(0).GetChildAt(2), Telerik.WinControls.UI.StackLayoutElement).BorderBottomColor = System.Drawing.SystemColors.ControlDark
        CType(Me.dtpData.GetChildAt(0).GetChildAt(2), Telerik.WinControls.UI.StackLayoutElement).BackColor = System.Drawing.Color.Transparent
        CType(Me.dtpData.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(1), Telerik.WinControls.Primitives.BorderPrimitive).ForeColor = System.Drawing.Color.FromArgb(CType(CType(112, Byte), Integer), CType(CType(112, Byte), Integer), CType(CType(112, Byte), Integer))
        CType(Me.dtpData.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(2), Telerik.WinControls.Primitives.BorderPrimitive).ForeColor = System.Drawing.Color.Transparent
        CType(Me.dtpData.GetChildAt(0).GetChildAt(2).GetChildAt(1), Telerik.WinControls.UI.RadMaskedEditBoxElement).Text = "25/09/2014"
        CType(Me.dtpData.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).NullText = "__/__/____"
        CType(Me.dtpData.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).NullTextColor = System.Drawing.SystemColors.GrayText
        CType(Me.dtpData.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).ForeColor = System.Drawing.SystemColors.ControlText
        CType(Me.dtpData.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).BackColor = System.Drawing.Color.Transparent
        CType(Me.dtpData.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1), Telerik.WinControls.Primitives.FillPrimitive).BackColor = System.Drawing.Color.Transparent
        CType(Me.dtpData.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(2), Telerik.WinControls.Primitives.BorderPrimitive).ForeColor = System.Drawing.SystemColors.ControlDark
        CType(Me.dtpData.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(2), Telerik.WinControls.Primitives.BorderPrimitive).BackColor = System.Drawing.Color.Transparent
        CType(Me.dtpData.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1), Telerik.WinControls.Primitives.BorderPrimitive).ForeColor = System.Drawing.Color.Transparent
        '
        'DataDate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.dtpData)
        Me.Name = "DataDate"
        Me.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.Size = New System.Drawing.Size(90, 26)
        CType(Me.dtpData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Protected Friend WithEvents dtpData As Telerik.WinControls.UI.RadDateTimePicker

End Class
