Imports VariablesGlobales.Modulo_VariablesGlobales

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
<Global.System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726")> _
Partial Class Login_kv
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
    Friend WithEvents OK As System.Windows.Forms.Button
    Friend WithEvents Cancel As System.Windows.Forms.Button

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Login_kv))
        Me.OK = New System.Windows.Forms.Button()
        Me.Cancel = New System.Windows.Forms.Button()
        Me.penPpal = New System.Windows.Forms.Panel()
        Me.penLogon = New System.Windows.Forms.Panel()
        Me.CstNomUsure = New CustomControls.Datafield()
        Me.lblError = New System.Windows.Forms.Label()
        Me.CstPass = New CustomControls.DatafieldLabel()
        Me.CstOficina = New CustomControls.DualDatafieldLabel()
        Me.CstUsuario = New CustomControls.DatafieldLabel()
        Me.penImage = New System.Windows.Forms.Panel()
        Me.Sep2 = New System.Windows.Forms.Label()
        Me.picBox = New System.Windows.Forms.PictureBox()
        Me.penPie = New System.Windows.Forms.Panel()
        Me.Sep1 = New System.Windows.Forms.Label()
        Me.penPpal.SuspendLayout()
        Me.penLogon.SuspendLayout()
        Me.penImage.SuspendLayout()
        CType(Me.picBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.penPie.SuspendLayout()
        Me.SuspendLayout()
        '
        'OK
        '
        Me.OK.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.OK.Location = New System.Drawing.Point(227, 6)
        Me.OK.Name = "OK"
        Me.OK.Size = New System.Drawing.Size(67, 23)
        Me.OK.TabIndex = 4
        Me.OK.Text = "&Aceptar"
        '
        'Cancel
        '
        Me.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Cancel.Location = New System.Drawing.Point(295, 6)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(67, 23)
        Me.Cancel.TabIndex = 5
        Me.Cancel.Text = "&Cancelar"
        '
        'penPpal
        '
        Me.penPpal.BackColor = System.Drawing.SystemColors.Control
        Me.penPpal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.penPpal.Controls.Add(Me.penLogon)
        Me.penPpal.Controls.Add(Me.penImage)
        Me.penPpal.Controls.Add(Me.penPie)
        Me.penPpal.Location = New System.Drawing.Point(2, 3)
        Me.penPpal.Name = "penPpal"
        Me.penPpal.Size = New System.Drawing.Size(375, 176)
        Me.penPpal.TabIndex = 0
        '
        'penLogon
        '
        Me.penLogon.Controls.Add(Me.CstNomUsure)
        Me.penLogon.Controls.Add(Me.lblError)
        Me.penLogon.Controls.Add(Me.CstPass)
        Me.penLogon.Controls.Add(Me.CstOficina)
        Me.penLogon.Controls.Add(Me.CstUsuario)
        Me.penLogon.Dock = System.Windows.Forms.DockStyle.Fill
        Me.penLogon.Location = New System.Drawing.Point(67, 0)
        Me.penLogon.Name = "penLogon"
        Me.penLogon.Size = New System.Drawing.Size(306, 138)
        Me.penLogon.TabIndex = 8
        '
        'CstNomUsure
        '
        Me.CstNomUsure.Allow_Empty = True
        Me.CstNomUsure.Allow_Negative = True
        Me.CstNomUsure.BackColor = System.Drawing.SystemColors.Control
        Me.CstNomUsure.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.CstNomUsure.DataField = Nothing
        Me.CstNomUsure.DataTable = 0
        Me.CstNomUsure.Descripcion = Nothing
        Me.CstNomUsure.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.CstNomUsure.Font_Data = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CstNomUsure.Length_Data = 32767
        Me.CstNomUsure.Location = New System.Drawing.Point(139, 18)
        Me.CstNomUsure.Max_Value = 0.0R
        Me.CstNomUsure.Name = "CstNomUsure"
        Me.CstNomUsure.Null_on_Empty = False
        Me.CstNomUsure.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.CstNomUsure.ReadOnly_Data = True
        Me.CstNomUsure.Size = New System.Drawing.Size(156, 20)
        Me.CstNomUsure.TabIndex = 8
        Me.CstNomUsure.Text_Data = ""
        Me.CstNomUsure.Theme = ThemeType.Plain
        Me.CstNomUsure.Upper_Case = False
        Me.CstNomUsure.Validate_on_lost_focus = True
        '
        'lblError
        '
        Me.lblError.AutoSize = True
        Me.lblError.ForeColor = System.Drawing.Color.Red
        Me.lblError.Location = New System.Drawing.Point(6, 99)
        Me.lblError.Name = "lblError"
        Me.lblError.Size = New System.Drawing.Size(97, 13)
        Me.lblError.TabIndex = 7
        Me.lblError.Text = "Usuario Inexistente"
        Me.lblError.Visible = False
        '
        'CstPass
        '
        Me.CstPass.Allow_Empty = True
        Me.CstPass.Allow_Negative = True
        Me.CstPass.BackColor = System.Drawing.SystemColors.Control
        Me.CstPass.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.CstPass.DataField = Nothing
        Me.CstPass.DataTable = 0
        Me.CstPass.Descripcion = "Contraseña:"
        Me.CstPass.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.CstPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CstPass.Font_Data = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.CstPass.Image = Nothing
        Me.CstPass.Label_Space = 80
        Me.CstPass.Length_Data = 32767
        Me.CstPass.Location = New System.Drawing.Point(3, 44)
        Me.CstPass.Max_Value = 0.0R
        Me.CstPass.Name = "CstPass"
        Me.CstPass.Null_on_Empty = False
        Me.CstPass.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(8226)
        Me.CstPass.ReadOnly_Data = False
        Me.CstPass.Show_Button = False
        Me.CstPass.Size = New System.Drawing.Size(292, 20)
        Me.CstPass.TabIndex = 5
        Me.CstPass.Text_Data = ""
        Me.CstPass.Theme = ThemeType.Plain
        Me.CstPass.Upper_Case = True
        Me.CstPass.Validate_on_lost_focus = True
        '
        'CstOficina
        '
        Me.CstOficina.Allow_Empty = True
        Me.CstOficina.Allow_Negative = True
        Me.CstOficina.BackColor = System.Drawing.SystemColors.Control
        Me.CstOficina.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.CstOficina.DataField = Nothing
        Me.CstOficina.DataTable = 0
        Me.CstOficina.Desc_Datafield = "NOMBRE"
        Me.CstOficina.Desc_DBPK = "CODIGO"
        Me.CstOficina.Desc_DBTable = "OFICINAS"
        Me.CstOficina.Desc_Where = Nothing
        Me.CstOficina.Descripcion = "Oficina:"
        Me.CstOficina.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.CstOficina.Font_Data = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CstOficina.Label_Space = 80
        Me.CstOficina.Length_Data = 32767
        Me.CstOficina.Location = New System.Drawing.Point(3, 70)
        Me.CstOficina.Max_Value = 0.0R
        Me.CstOficina.Name = "CstOficina"
        Me.CstOficina.Null_on_Empty = False
        Me.CstOficina.OpenForm = Nothing
        Me.CstOficina.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.CstOficina.Query_on_Text_Changed = True
        Me.CstOficina.ReadOnly_Data = False
        Me.CstOficina.Size = New System.Drawing.Size(295, 20)
        Me.CstOficina.TabIndex = 6
        Me.CstOficina.Text_Data = ""
        Me.CstOficina.Text_Width = 50
        Me.CstOficina.Theme = ThemeType.Plain
        Me.CstOficina.Upper_Case = True
        Me.CstOficina.Validate_on_lost_focus = True
        '
        'CstUsuario
        '
        Me.CstUsuario.Allow_Empty = True
        Me.CstUsuario.Allow_Negative = True
        Me.CstUsuario.BackColor = System.Drawing.SystemColors.Control
        Me.CstUsuario.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.CstUsuario.DataField = Nothing
        Me.CstUsuario.DataTable = 0
        Me.CstUsuario.Descripcion = "Usuario:"
        Me.CstUsuario.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.CstUsuario.Font_Data = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CstUsuario.Image = Nothing
        Me.CstUsuario.Label_Space = 80
        Me.CstUsuario.Length_Data = 32767
        Me.CstUsuario.Location = New System.Drawing.Point(3, 18)
        Me.CstUsuario.Max_Value = 0.0R
        Me.CstUsuario.Name = "CstUsuario"
        Me.CstUsuario.Null_on_Empty = False
        Me.CstUsuario.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.CstUsuario.ReadOnly_Data = False
        Me.CstUsuario.Show_Button = False
        Me.CstUsuario.Size = New System.Drawing.Size(130, 20)
        Me.CstUsuario.TabIndex = 4
        Me.CstUsuario.Text_Data = ""
        Me.CstUsuario.Theme = ThemeType.Plain
        Me.CstUsuario.Upper_Case = True
        Me.CstUsuario.Validate_on_lost_focus = True
        '
        'penImage
        '
        Me.penImage.Controls.Add(Me.Sep2)
        Me.penImage.Controls.Add(Me.picBox)
        Me.penImage.Dock = System.Windows.Forms.DockStyle.Left
        Me.penImage.Location = New System.Drawing.Point(0, 0)
        Me.penImage.Name = "penImage"
        Me.penImage.Size = New System.Drawing.Size(67, 138)
        Me.penImage.TabIndex = 7
        '
        'Sep2
        '
        Me.Sep2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Sep2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Sep2.Location = New System.Drawing.Point(65, 0)
        Me.Sep2.Name = "Sep2"
        Me.Sep2.Size = New System.Drawing.Size(2, 138)
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
        Me.penPie.Controls.Add(Me.Cancel)
        Me.penPie.Controls.Add(Me.OK)
        Me.penPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.penPie.Location = New System.Drawing.Point(0, 138)
        Me.penPie.Margin = New System.Windows.Forms.Padding(0)
        Me.penPie.Name = "penPie"
        Me.penPie.Size = New System.Drawing.Size(373, 36)
        Me.penPie.TabIndex = 6
        '
        'Sep1
        '
        Me.Sep1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Sep1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Sep1.Location = New System.Drawing.Point(0, 0)
        Me.Sep1.Name = "Sep1"
        Me.Sep1.Size = New System.Drawing.Size(373, 1)
        Me.Sep1.TabIndex = 6
        '
        'Login_kv
        '
        Me.AcceptButton = Me.OK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.MediumTurquoise
        Me.CancelButton = Me.Cancel
        Me.ClientSize = New System.Drawing.Size(380, 182)
        Me.ControlBox = False
        Me.Controls.Add(Me.penPpal)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Login_kv"
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login"
        Me.TransparencyKey = System.Drawing.Color.MediumTurquoise
        Me.penPpal.ResumeLayout(False)
        Me.penLogon.ResumeLayout(False)
        Me.penLogon.PerformLayout()
        Me.penImage.ResumeLayout(False)
        CType(Me.picBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.penPie.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents penPpal As System.Windows.Forms.Panel
    Friend WithEvents penPie As System.Windows.Forms.Panel
    Friend WithEvents Sep1 As System.Windows.Forms.Label
    Friend WithEvents penLogon As System.Windows.Forms.Panel
    Friend WithEvents lblError As System.Windows.Forms.Label
    Friend WithEvents CstPass As CustomControls.DatafieldLabel
    Friend WithEvents CstOficina As CustomControls.DualDatafieldLabel
    Friend WithEvents CstUsuario As CustomControls.DatafieldLabel
    Friend WithEvents penImage As System.Windows.Forms.Panel
    Friend WithEvents picBox As System.Windows.Forms.PictureBox
    Friend WithEvents Sep2 As System.Windows.Forms.Label
    Friend WithEvents CstNomUsure As CustomControls.Datafield

End Class
