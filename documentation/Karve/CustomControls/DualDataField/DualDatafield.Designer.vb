Imports VariablesGlobales.Modulo_VariablesGlobales

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DualDatafield
    Inherits CustomControls.Datafield

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
        Me.dtfDesc = New CustomControls.Datafield()
        CType(Me.txtData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtData
        '
        Me.txtData.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtData.Size = New System.Drawing.Size(175, 20)
        '
        'dtfDesc
        '
        Me.dtfDesc.Allow_Empty = True
        Me.dtfDesc.Allow_Negative = True
        Me.dtfDesc.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtfDesc.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfDesc.BackColor = System.Drawing.SystemColors.Control
        Me.dtfDesc.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfDesc.DataField = Nothing
        Me.dtfDesc.DataTable = ""
        Me.dtfDesc.Descripcion = Nothing
        Me.dtfDesc.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfDesc.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfDesc.Length_Data = 32767
        Me.dtfDesc.Location = New System.Drawing.Point(53, -4)
        Me.dtfDesc.Max_Value = 0.0R
        Me.dtfDesc.MensajeIncorrectoCustom = Nothing
        Me.dtfDesc.Name = "dtfDesc"
        Me.dtfDesc.Null_on_Empty = False
        Me.dtfDesc.Padding = New System.Windows.Forms.Padding(0, 4, 0, 4)
        Me.dtfDesc.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfDesc.ReadOnly_Data = True
        Me.dtfDesc.Size = New System.Drawing.Size(119, 28)
        Me.dtfDesc.TabIndex = 2
        Me.dtfDesc.TabStop = False
        Me.dtfDesc.Text_Data = ""
        Me.dtfDesc.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfDesc.TopPadding = 0
        Me.dtfDesc.Upper_Case = False
        Me.dtfDesc.Validate_on_lost_focus = True
        '
        'DualDatafield
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.dtfDesc)
        Me.Name = "DualDatafield"
        Me.Size = New System.Drawing.Size(175, 26)
        Me.Controls.SetChildIndex(Me.txtData, 0)
        Me.Controls.SetChildIndex(Me.dtfDesc, 0)
        CType(Me.txtData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Protected Friend WithEvents dtfDesc As CustomControls.Datafield

End Class
