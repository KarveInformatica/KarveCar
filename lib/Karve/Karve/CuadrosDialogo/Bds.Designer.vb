<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Bds
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Bds))
        Me.penPpal = New System.Windows.Forms.Panel()
        Me.cboBds = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.penImage = New System.Windows.Forms.Panel()
        Me.Sep2 = New System.Windows.Forms.Label()
        Me.picBox = New System.Windows.Forms.PictureBox()
        Me.penPie = New System.Windows.Forms.Panel()
        Me.Sep1 = New System.Windows.Forms.Label()
        Me.penPpal.SuspendLayout()
        Me.penImage.SuspendLayout()
        CType(Me.picBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.penPie.SuspendLayout()
        Me.SuspendLayout()
        '
        'penPpal
        '
        Me.penPpal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.penPpal.Controls.Add(Me.cboBds)
        Me.penPpal.Controls.Add(Me.Label1)
        Me.penPpal.Controls.Add(Me.penImage)
        Me.penPpal.Controls.Add(Me.penPie)
        Me.penPpal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.penPpal.Location = New System.Drawing.Point(0, 0)
        Me.penPpal.Name = "penPpal"
        Me.penPpal.Size = New System.Drawing.Size(354, 135)
        Me.penPpal.TabIndex = 0
        '
        'cboBds
        '
        Me.cboBds.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cboBds.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboBds.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboBds.FormattingEnabled = True
        Me.cboBds.Location = New System.Drawing.Point(205, 42)
        Me.cboBds.Name = "cboBds"
        Me.cboBds.Size = New System.Drawing.Size(138, 21)
        Me.cboBds.TabIndex = 15
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(73, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(123, 13)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "CONECTARSE A BD"
        '
        'penImage
        '
        Me.penImage.Controls.Add(Me.Sep2)
        Me.penImage.Controls.Add(Me.picBox)
        Me.penImage.Dock = System.Windows.Forms.DockStyle.Left
        Me.penImage.Location = New System.Drawing.Point(0, 0)
        Me.penImage.Name = "penImage"
        Me.penImage.Size = New System.Drawing.Size(67, 97)
        Me.penImage.TabIndex = 13
        '
        'Sep2
        '
        Me.Sep2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Sep2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Sep2.Location = New System.Drawing.Point(65, 0)
        Me.Sep2.Name = "Sep2"
        Me.Sep2.Size = New System.Drawing.Size(2, 97)
        Me.Sep2.TabIndex = 1
        '
        'picBox
        '
        Me.picBox.Image = CType(resources.GetObject("picBox.Image"), System.Drawing.Image)
        Me.picBox.Location = New System.Drawing.Point(6, 24)
        Me.picBox.Name = "picBox"
        Me.picBox.Size = New System.Drawing.Size(54, 56)
        Me.picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.picBox.TabIndex = 0
        Me.picBox.TabStop = False
        '
        'penPie
        '
        Me.penPie.BackColor = System.Drawing.Color.White
        Me.penPie.Controls.Add(Me.Sep1)
        Me.penPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.penPie.Location = New System.Drawing.Point(0, 97)
        Me.penPie.Margin = New System.Windows.Forms.Padding(0)
        Me.penPie.Name = "penPie"
        Me.penPie.Size = New System.Drawing.Size(352, 36)
        Me.penPie.TabIndex = 12
        '
        'Sep1
        '
        Me.Sep1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Sep1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Sep1.Location = New System.Drawing.Point(0, 0)
        Me.Sep1.Name = "Sep1"
        Me.Sep1.Size = New System.Drawing.Size(352, 1)
        Me.Sep1.TabIndex = 6
        '
        'Bds
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(354, 135)
        Me.Controls.Add(Me.penPpal)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "Bds"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Bds"
        Me.penPpal.ResumeLayout(False)
        Me.penPpal.PerformLayout()
        Me.penImage.ResumeLayout(False)
        CType(Me.picBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.penPie.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents penPpal As System.Windows.Forms.Panel
    Friend WithEvents cboBds As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents penImage As System.Windows.Forms.Panel
    Friend WithEvents Sep2 As System.Windows.Forms.Label
    Friend WithEvents picBox As System.Windows.Forms.PictureBox
    Friend WithEvents penPie As System.Windows.Forms.Panel
    Friend WithEvents Sep1 As System.Windows.Forms.Label
End Class
