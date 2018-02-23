<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FilesSelector
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
        Me.lstData = New Telerik.WinControls.UI.RadListView()
        Me.btnAction = New CustomControls.Button()
        Me.lblDesc = New CustomControls.Label()
        CType(Me.lstData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnAction, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDesc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lstData
        '
        Me.lstData.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstData.FullRowSelect = False
        Me.lstData.ItemSize = New System.Drawing.Size(100, 18)
        Me.lstData.Location = New System.Drawing.Point(75, 0)
        Me.lstData.Name = "lstData"
        Me.lstData.Size = New System.Drawing.Size(99, 44)
        Me.lstData.TabIndex = 0
        Me.lstData.ThemeName = "Windows8"
        Me.lstData.ViewType = Telerik.WinControls.UI.ListViewType.IconsView
        '
        'btnAction
        '
        Me.btnAction.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAction.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnAction.Location = New System.Drawing.Point(180, 0)
        Me.btnAction.Name = "btnAction"
        Me.btnAction.Size = New System.Drawing.Size(20, 20)
        Me.btnAction.TabIndex = 3
        Me.btnAction.TabStop = False
        Me.btnAction.Tag = ""
        Me.btnAction.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.btnAction.ThemeName = "Windows8"
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
        'FilesSelector
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lstData)
        Me.Controls.Add(Me.btnAction)
        Me.Controls.Add(Me.lblDesc)
        Me.Name = "FilesSelector"
        Me.Size = New System.Drawing.Size(200, 52)
        CType(Me.lstData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnAction, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDesc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblDesc As CustomControls.Label
    Friend WithEvents btnAction As CustomControls.Button
    Friend WithEvents lstData As Telerik.WinControls.UI.RadListView

End Class
