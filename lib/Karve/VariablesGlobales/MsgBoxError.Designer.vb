<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MsgBoxError
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.lblMasDetalles = New System.Windows.Forms.Label()
        Me.lblError = New System.Windows.Forms.Label()
        Me.txtDetallado = New System.Windows.Forms.RichTextBox()
        Me.imgError = New System.Windows.Forms.PictureBox()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.imgError, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(195, 69)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "Aceptar"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Salir"
        '
        'lblMasDetalles
        '
        Me.lblMasDetalles.AutoSize = True
        Me.lblMasDetalles.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMasDetalles.Location = New System.Drawing.Point(12, 77)
        Me.lblMasDetalles.Name = "lblMasDetalles"
        Me.lblMasDetalles.Size = New System.Drawing.Size(77, 13)
        Me.lblMasDetalles.TabIndex = 1
        Me.lblMasDetalles.Text = "+ Más Detalles"
        '
        'lblError
        '
        Me.lblError.Location = New System.Drawing.Point(69, 9)
        Me.lblError.Name = "lblError"
        Me.lblError.Size = New System.Drawing.Size(272, 57)
        Me.lblError.TabIndex = 2
        Me.lblError.Text = "Label2"
        Me.lblError.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtDetallado
        '
        Me.txtDetallado.BackColor = System.Drawing.SystemColors.Info
        Me.txtDetallado.Location = New System.Drawing.Point(12, 114)
        Me.txtDetallado.Name = "txtDetallado"
        Me.txtDetallado.ReadOnly = True
        Me.txtDetallado.Size = New System.Drawing.Size(329, 127)
        Me.txtDetallado.TabIndex = 3
        Me.txtDetallado.Text = ""
        '
        'imgError
        '
        Me.imgError.Image = Global.VariablesGlobales.My.Resources.Resources.citical
        Me.imgError.InitialImage = Nothing
        Me.imgError.Location = New System.Drawing.Point(15, 12)
        Me.imgError.Name = "imgError"
        Me.imgError.Size = New System.Drawing.Size(48, 48)
        Me.imgError.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgError.TabIndex = 4
        Me.imgError.TabStop = False
        '
        'MsgBoxError
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(353, 253)
        Me.Controls.Add(Me.imgError)
        Me.Controls.Add(Me.txtDetallado)
        Me.Controls.Add(Me.lblError)
        Me.Controls.Add(Me.lblMasDetalles)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MsgBoxError"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "MsgBoxError"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.imgError, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents lblMasDetalles As System.Windows.Forms.Label
    Friend WithEvents lblError As System.Windows.Forms.Label
    Friend WithEvents txtDetallado As System.Windows.Forms.RichTextBox
    Friend WithEvents imgError As System.Windows.Forms.PictureBox

End Class
