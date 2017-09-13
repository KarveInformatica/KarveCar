Imports VariablesGlobales.Modulo_VariablesGlobales

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class pnlClientes
    Inherits Bases.pnlBase

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
        Me.DataDateLabel1 = New CustomControls.DataDateLabel()
        Me.DataAreaLabel1 = New CustomControls.DataAreaLabel()
        Me.RadioGroup1 = New CustomControls.RadioGroup()
        Me.DataRadio2 = New CustomControls.DataRadio()
        Me.DataRadio1 = New CustomControls.DataRadio()
        Me.DataCheck1 = New CustomControls.DataCheck()
        Me.dtfVendedor = New CustomControls.DualDatafieldLabel()
        Me.dtfEmail = New CustomControls.DatafieldLabel()
        Me.dtfPoblacion = New CustomControls.DatafieldLabel()
        Me.dtfCP = New CustomControls.DatafieldLabel()
        Me.dtfPais = New CustomControls.DualDatafieldLabel()
        Me.dtfNombre = New CustomControls.DatafieldLabel()
        Me.dtfDireccion = New CustomControls.DatafieldLabel()
        Me.dtfCodigo = New CustomControls.DatafieldLabel()
        Me.Windows8Theme1 = New Telerik.WinControls.Themes.Windows8Theme()
        Me.Windows7Theme1 = New Telerik.WinControls.Themes.Windows7Theme()
        Me.RadioGroup1.SuspendLayout()
        CType(Me.DataRadio2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataRadio1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataCheck1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataDateLabel1
        '
        Me.DataDateLabel1.DataField = "baja"
        Me.DataDateLabel1.DataTable = 0
        Me.DataDateLabel1.Descripcion = "F.Baja"
        Me.DataDateLabel1.Label_Space = 50
        Me.DataDateLabel1.Theme = ThemeType.Plain
        Me.DataDateLabel1.Value_Data = New Date(2014, 10, 2, 0, 0, 0, 0)
        '
        'DataAreaLabel1
        '
        Me.DataAreaLabel1.Allow_Empty = True
        Me.DataAreaLabel1.Data_Allowed = CustomControls.DataRichField.List_Data.Libre
        Me.DataAreaLabel1.DataField = "notas"
        Me.DataAreaLabel1.DataTable = 0
        Me.DataAreaLabel1.Descripcion = "Label1"
        Me.DataAreaLabel1.Encoding = CustomControls.DataRichField.Code_Collation.LATIN

        Me.DataAreaLabel1.Location = New System.Drawing.Point(3, 236)
        Me.DataAreaLabel1.Name = "DataAreaLabel1"
        Me.DataAreaLabel1.Null_on_Empty = False
        Me.DataAreaLabel1.ReadOnly_Data = False
        Me.DataAreaLabel1.Size = New System.Drawing.Size(284, 101)
        Me.DataAreaLabel1.TabIndex = 10
        Me.DataAreaLabel1.Text_Data = ""
        Me.DataAreaLabel1.Theme = ThemeType.Plain
        Me.DataAreaLabel1.Upper_Case = False
        Me.DataAreaLabel1.Validate_on_lost_focus = True
        '
        'RadioGroup1
        '
        Me.RadioGroup1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.RadioGroup1.Controls.Add(Me.DataRadio2)
        Me.RadioGroup1.Controls.Add(Me.DataRadio1)
        Me.RadioGroup1.DataField = "persona"
        Me.RadioGroup1.DataTable = 0
        Me.RadioGroup1.Descripcion = "Persona"
        Me.RadioGroup1.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.RadioGroup1.Index = Nothing
        Me.RadioGroup1.Location = New System.Drawing.Point(3, 185)
        Me.RadioGroup1.Name = "RadioGroup1"
        Me.RadioGroup1.Size = New System.Drawing.Size(283, 48)
        Me.RadioGroup1.TabIndex = 9
        Me.RadioGroup1.TabStop = False
        Me.RadioGroup1.Text = "Persona"
        Me.RadioGroup1.Theme = ThemeType.Plain
        '
        'DataRadio2
        '
        Me.DataRadio2.Checked = False
        Me.DataRadio2.Descripcion = "Juridica"
        Me.DataRadio2.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.DataRadio2.Index = "J"
        Me.DataRadio2.Location = New System.Drawing.Point(72, 19)
        Me.DataRadio2.Name = "DataRadio2"
        Me.DataRadio2.Size = New System.Drawing.Size(62, 18)
        Me.DataRadio2.TabIndex = 1
        Me.DataRadio2.Text = "Juridica"
        Me.DataRadio2.Theme = ThemeType.Plain
        Me.DataRadio2.ThemeName = "Windows8"
        '
        'DataRadio1
        '
        Me.DataRadio1.Checked = False
        Me.DataRadio1.Descripcion = "Fisica"
        Me.DataRadio1.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.DataRadio1.Index = "F"
        Me.DataRadio1.Location = New System.Drawing.Point(6, 19)
        Me.DataRadio1.Name = "DataRadio1"
        Me.DataRadio1.Size = New System.Drawing.Size(53, 18)
        Me.DataRadio1.TabIndex = 0
        Me.DataRadio1.Text = "Fisica"
        Me.DataRadio1.Theme = ThemeType.Plain
        Me.DataRadio1.ThemeName = "Windows8"
        '
        'DataCheck1
        '
        Me.DataCheck1.DataField = "plazo"
        Me.DataCheck1.DataTable = 0
        Me.DataCheck1.Descripcion = "Moroso"
        Me.DataCheck1.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.DataCheck1.Location = New System.Drawing.Point(3, 159)
        Me.DataCheck1.Name = "DataCheck1"
        Me.DataCheck1.Size = New System.Drawing.Size(64, 18)
        Me.DataCheck1.TabIndex = 8
        Me.DataCheck1.Text = "Moroso"
        Me.DataCheck1.Theme = ThemeType.Plain
        Me.DataCheck1.ThemeName = "Windows8"
        Me.DataCheck1.Value = False
        '
        'dtfVendedor
        '
        Me.dtfVendedor.Allow_Empty = True
        Me.dtfVendedor.Allow_Negative = True
        Me.dtfVendedor.BackColor = System.Drawing.SystemColors.Control
        Me.dtfVendedor.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfVendedor.DataField = "vendedor"
        Me.dtfVendedor.DataTable = 1
        Me.dtfVendedor.Desc_Datafield = "nombre"
        Me.dtfVendedor.Desc_DBPK = "num_vende"
        Me.dtfVendedor.Desc_DBTable = "vendedor"
        Me.dtfVendedor.Desc_Where = Nothing
        Me.dtfVendedor.Descripcion = "Vendedor"
        Me.dtfVendedor.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfVendedor.Font_Data = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtfVendedor.Label_Space = 75
        Me.dtfVendedor.Length_Data = 32767
        Me.dtfVendedor.Location = New System.Drawing.Point(3, 133)
        Me.dtfVendedor.Max_Value = 0.0R
        Me.dtfVendedor.Name = "dtfVendedor"
        Me.dtfVendedor.Null_on_Empty = False
        Me.dtfVendedor.OpenForm = "KarvePruebas.Form1"
        Me.dtfVendedor.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfVendedor.Query_on_Text_Changed = True
        Me.dtfVendedor.ReadOnly_Data = False
        Me.dtfVendedor.Size = New System.Drawing.Size(283, 20)
        Me.dtfVendedor.TabIndex = 7
        Me.dtfVendedor.Text_Data = ""
        Me.dtfVendedor.Text_Width = 58
        Me.dtfVendedor.Theme = ThemeType.Plain
        Me.dtfVendedor.Upper_Case = False
        Me.dtfVendedor.Validate_on_lost_focus = True
        '
        'dtfEmail
        '
        Me.dtfEmail.Allow_Empty = True
        Me.dtfEmail.Allow_Negative = True
        Me.dtfEmail.BackColor = System.Drawing.SystemColors.Control
        Me.dtfEmail.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfEmail.DataField = "email"
        Me.dtfEmail.DataTable = 1
        Me.dtfEmail.Descripcion = "Email"
        Me.dtfEmail.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfEmail.Font_Data = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtfEmail.Image = Nothing
        Me.dtfEmail.Label_Space = 50
        Me.dtfEmail.Length_Data = 32767
        Me.dtfEmail.Location = New System.Drawing.Point(3, 107)
        Me.dtfEmail.Max_Value = 0.0R
        Me.dtfEmail.Name = "dtfEmail"
        Me.dtfEmail.Null_on_Empty = False
        Me.dtfEmail.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfEmail.ReadOnly_Data = False
        Me.dtfEmail.Show_Button = False
        Me.dtfEmail.Size = New System.Drawing.Size(283, 20)
        Me.dtfEmail.TabIndex = 6
        Me.dtfEmail.Text_Data = ""
        Me.dtfEmail.Theme = ThemeType.Plain
        Me.dtfEmail.Upper_Case = False
        Me.dtfEmail.Validate_on_lost_focus = True
        '
        'dtfPoblacion
        '
        Me.dtfPoblacion.Allow_Empty = True
        Me.dtfPoblacion.Allow_Negative = True
        Me.dtfPoblacion.BackColor = System.Drawing.SystemColors.Control
        Me.dtfPoblacion.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfPoblacion.DataField = "poblacion"
        Me.dtfPoblacion.DataTable = 0
        Me.dtfPoblacion.Descripcion = "Población"
        Me.dtfPoblacion.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfPoblacion.Font_Data = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtfPoblacion.Image = Nothing
        Me.dtfPoblacion.Label_Space = 60
        Me.dtfPoblacion.Length_Data = 32767
        Me.dtfPoblacion.Location = New System.Drawing.Point(133, 55)
        Me.dtfPoblacion.Max_Value = 0.0R
        Me.dtfPoblacion.Name = "dtfPoblacion"
        Me.dtfPoblacion.Null_on_Empty = False
        Me.dtfPoblacion.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfPoblacion.ReadOnly_Data = False
        Me.dtfPoblacion.Show_Button = False
        Me.dtfPoblacion.Size = New System.Drawing.Size(153, 20)
        Me.dtfPoblacion.TabIndex = 5
        Me.dtfPoblacion.Text_Data = ""
        Me.dtfPoblacion.Theme = ThemeType.Plain
        Me.dtfPoblacion.Upper_Case = False
        Me.dtfPoblacion.Validate_on_lost_focus = True
        '
        'dtfCP
        '
        Me.dtfCP.Allow_Empty = True
        Me.dtfCP.Allow_Negative = True
        Me.dtfCP.BackColor = System.Drawing.SystemColors.Control
        Me.dtfCP.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfCP.DataField = "cp"
        Me.dtfCP.DataTable = 0
        Me.dtfCP.Descripcion = "CP"
        Me.dtfCP.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfCP.Font_Data = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtfCP.Image = Nothing
        Me.dtfCP.Label_Space = 50
        Me.dtfCP.Length_Data = 32767
        Me.dtfCP.Location = New System.Drawing.Point(3, 55)
        Me.dtfCP.Max_Value = 0.0R
        Me.dtfCP.Name = "dtfCP"
        Me.dtfCP.Null_on_Empty = False
        Me.dtfCP.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfCP.ReadOnly_Data = False
        Me.dtfCP.Show_Button = True
        Me.dtfCP.Size = New System.Drawing.Size(116, 20)
        Me.dtfCP.TabIndex = 4
        Me.dtfCP.Text_Data = ""
        Me.dtfCP.Theme = ThemeType.Plain
        Me.dtfCP.Upper_Case = False
        Me.dtfCP.Validate_on_lost_focus = True
        '
        'dtfPais
        '
        Me.dtfPais.Allow_Empty = True
        Me.dtfPais.Allow_Negative = True
        Me.dtfPais.BackColor = System.Drawing.SystemColors.Control
        Me.dtfPais.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfPais.DataField = "pais"
        Me.dtfPais.DataTable = 0
        Me.dtfPais.Desc_Datafield = "pais"
        Me.dtfPais.Desc_DBPK = "siglas"
        Me.dtfPais.Desc_DBTable = "pais"
        Me.dtfPais.Desc_Where = Nothing
        Me.dtfPais.Descripcion = "Pais"
        Me.dtfPais.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfPais.Font_Data = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtfPais.Label_Space = 50
        Me.dtfPais.Length_Data = 32767
        Me.dtfPais.Location = New System.Drawing.Point(3, 81)
        Me.dtfPais.Max_Value = 0.0R
        Me.dtfPais.Name = "dtfPais"
        Me.dtfPais.Null_on_Empty = True
        Me.dtfPais.OpenForm = Nothing
        Me.dtfPais.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfPais.Query_on_Text_Changed = True
        Me.dtfPais.ReadOnly_Data = False
        Me.dtfPais.Size = New System.Drawing.Size(283, 20)
        Me.dtfPais.TabIndex = 3
        Me.dtfPais.Text_Data = ""
        Me.dtfPais.Text_Width = 58
        Me.dtfPais.Theme = ThemeType.Plain
        Me.dtfPais.Upper_Case = False
        Me.dtfPais.Validate_on_lost_focus = True
        '
        'dtfNombre
        '
        Me.dtfNombre.Allow_Empty = True
        Me.dtfNombre.Allow_Negative = True
        Me.dtfNombre.BackColor = System.Drawing.SystemColors.Control
        Me.dtfNombre.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfNombre.DataField = "nombre"
        Me.dtfNombre.DataTable = 0
        Me.dtfNombre.Descripcion = "Nombre"
        Me.dtfNombre.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfNombre.Font_Data = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtfNombre.Image = Nothing
        Me.dtfNombre.Label_Space = 60
        Me.dtfNombre.Length_Data = 32767
        Me.dtfNombre.Location = New System.Drawing.Point(133, 3)
        Me.dtfNombre.Max_Value = 0.0R
        Me.dtfNombre.Name = "dtfNombre"
        Me.dtfNombre.Null_on_Empty = False
        Me.dtfNombre.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfNombre.ReadOnly_Data = False
        Me.dtfNombre.Show_Button = False
        Me.dtfNombre.Size = New System.Drawing.Size(153, 20)
        Me.dtfNombre.TabIndex = 2
        Me.dtfNombre.Text_Data = ""
        Me.dtfNombre.Theme = ThemeType.Plain
        Me.dtfNombre.Upper_Case = False
        Me.dtfNombre.Validate_on_lost_focus = True
        '
        'dtfDireccion
        '
        Me.dtfDireccion.Allow_Empty = True
        Me.dtfDireccion.Allow_Negative = True
        Me.dtfDireccion.BackColor = System.Drawing.SystemColors.Control
        Me.dtfDireccion.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfDireccion.DataField = "direccion"
        Me.dtfDireccion.DataTable = 0
        Me.dtfDireccion.Descripcion = "Direccion"
        Me.dtfDireccion.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfDireccion.Font_Data = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtfDireccion.Image = Nothing
        Me.dtfDireccion.Label_Space = 60
        Me.dtfDireccion.Length_Data = 32767
        Me.dtfDireccion.Location = New System.Drawing.Point(3, 29)
        Me.dtfDireccion.Max_Value = 0.0R
        Me.dtfDireccion.Name = "dtfDireccion"
        Me.dtfDireccion.Null_on_Empty = False
        Me.dtfDireccion.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfDireccion.ReadOnly_Data = False
        Me.dtfDireccion.Show_Button = False
        Me.dtfDireccion.Size = New System.Drawing.Size(283, 20)
        Me.dtfDireccion.TabIndex = 1
        Me.dtfDireccion.Text_Data = ""
        Me.dtfDireccion.Theme = ThemeType.Plain
        Me.dtfDireccion.Upper_Case = False
        Me.dtfDireccion.Validate_on_lost_focus = True
        '
        'dtfCodigo
        '
        Me.dtfCodigo.Allow_Empty = True
        Me.dtfCodigo.Allow_Negative = True
        Me.dtfCodigo.BackColor = System.Drawing.SystemColors.Control
        Me.dtfCodigo.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfCodigo.DataField = "numero_cli"
        Me.dtfCodigo.DataTable = 0
        Me.dtfCodigo.Descripcion = "Codigo"
        Me.dtfCodigo.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfCodigo.Font_Data = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtfCodigo.Image = Nothing
        Me.dtfCodigo.Label_Space = 50
        Me.dtfCodigo.Length_Data = 32767
        Me.dtfCodigo.Location = New System.Drawing.Point(3, 3)
        Me.dtfCodigo.Max_Value = 0.0R
        Me.dtfCodigo.Name = "dtfCodigo"
        Me.dtfCodigo.Null_on_Empty = False
        Me.dtfCodigo.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfCodigo.ReadOnly_Data = True
        Me.dtfCodigo.Show_Button = False
        Me.dtfCodigo.Size = New System.Drawing.Size(110, 20)
        Me.dtfCodigo.TabIndex = 0
        Me.dtfCodigo.Text_Data = ""
        Me.dtfCodigo.Theme = ThemeType.Plain
        Me.dtfCodigo.Upper_Case = False
        Me.dtfCodigo.Validate_on_lost_focus = True
        '
        'pnlClientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.Controls.Add(Me.DataDateLabel1)
        Me.Controls.Add(Me.DataAreaLabel1)
        Me.Controls.Add(Me.RadioGroup1)
        Me.Controls.Add(Me.DataCheck1)
        Me.Controls.Add(Me.dtfVendedor)
        Me.Controls.Add(Me.dtfEmail)
        Me.Controls.Add(Me.dtfPoblacion)
        Me.Controls.Add(Me.dtfCP)
        Me.Controls.Add(Me.dtfPais)
        Me.Controls.Add(Me.dtfNombre)
        Me.Controls.Add(Me.dtfDireccion)
        Me.Controls.Add(Me.dtfCodigo)
        Me.Name = "pnlClientes"
        Me.Size = New System.Drawing.Size(290, 340)
        Me.RadioGroup1.ResumeLayout(False)
        Me.RadioGroup1.PerformLayout()
        CType(Me.DataRadio2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataRadio1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataCheck1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtfCodigo As CustomControls.DatafieldLabel
    Friend WithEvents dtfDireccion As CustomControls.DatafieldLabel
    Friend WithEvents dtfNombre As CustomControls.DatafieldLabel
    Friend WithEvents dtfPais As CustomControls.DualDatafieldLabel
    Friend WithEvents dtfCP As CustomControls.DatafieldLabel
    Friend WithEvents dtfPoblacion As CustomControls.DatafieldLabel
    Friend WithEvents dtfEmail As CustomControls.DatafieldLabel
    Friend WithEvents dtfVendedor As CustomControls.DualDatafieldLabel
    Friend WithEvents DataCheck1 As CustomControls.DataCheck
    Friend WithEvents RadioGroup1 As CustomControls.RadioGroup
    Friend WithEvents DataRadio2 As CustomControls.DataRadio
    Friend WithEvents DataRadio1 As CustomControls.DataRadio
    Friend WithEvents DataAreaLabel1 As CustomControls.DataAreaLabel
    Friend WithEvents DataDateLabel1 As CustomControls.DataDateLabel
    Friend WithEvents Windows8Theme1 As Telerik.WinControls.Themes.Windows8Theme
    Friend WithEvents Windows7Theme1 As Telerik.WinControls.Themes.Windows7Theme

End Class
