Imports VariablesGlobales.Modulo_VariablesGlobales

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
    Inherits Bases.frmBase

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form2))
        Me.DataDateLabel1 = New CustomControls.DataDateLabel()
        Me.DataAreaLabel1 = New CustomControls.DataAreaLabel()
        Me.RadioGroup1 = New CustomControls.RadioGroup()
        Me.DataRadio2 = New CustomControls.DataRadio()
        Me.DataRadio1 = New CustomControls.DataRadio()
        Me.dtfCodigo = New CustomControls.DatafieldLabel()
        Me.DataCheck1 = New CustomControls.DataCheck()
        Me.dtfVendedor = New CustomControls.DualDatafieldLabel()
        Me.dtfEmail = New CustomControls.DatafieldLabel()
        Me.dtfPoblacion = New CustomControls.DatafieldLabel()
        Me.dtfCP = New CustomControls.DatafieldLabel()
        Me.dtfPais = New CustomControls.DualDatafieldLabel()
        Me.dtfNombre = New CustomControls.DatafieldLabel()
        Me.dtfDireccion = New CustomControls.DatafieldLabel()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Panel1 = New CustomControls.Panel()
        Me.Datafield1 = New CustomControls.Datafield()
        Me.Datafield2 = New CustomControls.Datafield()
        Me.RadMaskedEditBox1 = New Telerik.WinControls.UI.RadMaskedEditBox()
        Me.RadTimePicker1 = New Telerik.WinControls.UI.RadTimePicker()
        Me.Button1 = New CustomControls.Button()
        CType(Me.RadioGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadioGroup1.SuspendLayout()
        CType(Me.DataRadio2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataRadio1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataCheck1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Panel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.RadMaskedEditBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadTimePicker1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Button1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rbtEdicion
        '
        Me.rbtEdicion.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.rbtEdicion.BorderColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.rbtEdicion.BorderGradientStyle = Telerik.WinControls.GradientStyles.Solid
        Me.rbtEdicion.Bounds = New System.Drawing.Rectangle(0, 0, 50, 28)
        Me.rbtEdicion.ClipDrawing = True
        Me.rbtEdicion.ClipText = True
        Me.rbtEdicion.DrawBorder = True
        Me.rbtEdicion.DrawFill = True
        Me.rbtEdicion.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.rbtEdicion.ForeColor = System.Drawing.Color.Black
        Me.rbtEdicion.GradientStyle = Telerik.WinControls.GradientStyles.Solid
        Me.rbtEdicion.ImageAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.rbtEdicion.ImageLayout = System.Windows.Forms.ImageLayout.None
        Me.rbtEdicion.MinSize = New System.Drawing.Size(8, 8)
        Me.rbtEdicion.NumberOfColors = 1
        Me.rbtEdicion.Padding = New System.Windows.Forms.Padding(4)
        Me.rbtEdicion.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.rbtEdicion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        '
        'DataDateLabel1
        '
        Me.DataDateLabel1.Allow_Empty = True
        Me.DataDateLabel1.DataField = "baja"
        Me.DataDateLabel1.DataTable = 0
        Me.DataDateLabel1.Default_Value = New Date(CType(0, Long))
        Me.DataDateLabel1.Descripcion = "F.Baja"
        Me.DataDateLabel1.Label_Space = 50
        Me.DataDateLabel1.Location = New System.Drawing.Point(108, 181)
        Me.DataDateLabel1.Max_Value = Nothing
        Me.DataDateLabel1.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.DataDateLabel1.Min_Value = Nothing
        Me.DataDateLabel1.MinDate = New Date(CType(0, Long))
        Me.DataDateLabel1.Name = "DataDateLabel1"
        Me.DataDateLabel1.ReadOnly_Data = False
        Me.DataDateLabel1.Size = New System.Drawing.Size(165, 20)
        Me.DataDateLabel1.TabIndex = 0
        Me.DataDateLabel1.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.DataDateLabel1.Validate_on_lost_focus = True
        Me.DataDateLabel1.Value_Data = New Date(2014, 10, 14, 0, 0, 0, 0)
        '
        'DataAreaLabel1
        '
        Me.DataAreaLabel1.Allow_Empty = True
        Me.DataAreaLabel1.Data_Allowed = CustomControls.DataRichField.List_Data.Libre
        Me.DataAreaLabel1.DataField = "notas"
        Me.DataAreaLabel1.DataTable = 0
        Me.DataAreaLabel1.Descripcion = "Label1"
        Me.DataAreaLabel1.Encoding = CustomControls.DataRichField.Code_Collation.LATIN
        Me.DataAreaLabel1.Location = New System.Drawing.Point(3, 262)
        Me.DataAreaLabel1.Name = "DataAreaLabel1"
        Me.DataAreaLabel1.Null_on_Empty = False
        Me.DataAreaLabel1.ReadOnly_Data = False
        Me.DataAreaLabel1.Size = New System.Drawing.Size(283, 101)
        Me.DataAreaLabel1.TabIndex = 11
        Me.DataAreaLabel1.Text_Data = ""
        Me.DataAreaLabel1.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
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
        Me.RadioGroup1.HeaderText = "Persona"
        Me.RadioGroup1.Index = ""
        Me.RadioGroup1.Location = New System.Drawing.Point(3, 208)
        Me.RadioGroup1.Name = "RadioGroup1"
        Me.RadioGroup1.Size = New System.Drawing.Size(283, 48)
        Me.RadioGroup1.TabIndex = 10
        Me.RadioGroup1.TabStop = False
        Me.RadioGroup1.Text = "Persona"
        Me.RadioGroup1.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.RadioGroup1.ThemeName = "Windows8"
        CType(Me.RadioGroup1.GetChildAt(0).GetChildAt(1).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor = System.Drawing.SystemColors.Control
        CType(Me.RadioGroup1.GetChildAt(0).GetChildAt(1).GetChildAt(2).GetChildAt(1), Telerik.WinControls.Primitives.TextPrimitive).Text = "Persona"
        CType(Me.RadioGroup1.GetChildAt(0).GetChildAt(1).GetChildAt(2).GetChildAt(1), Telerik.WinControls.Primitives.TextPrimitive).BackColor = System.Drawing.SystemColors.Control
        CType(Me.RadioGroup1.GetChildAt(0).GetChildAt(1).GetChildAt(2).GetChildAt(1), Telerik.WinControls.Primitives.TextPrimitive).Alignment = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DataRadio2
        '
        Me.DataRadio2.BackColor = System.Drawing.SystemColors.Control
        Me.DataRadio2.Checked = False
        Me.DataRadio2.Descripcion = "Juridica"
        Me.DataRadio2.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.DataRadio2.Index = "J"
        Me.DataRadio2.Location = New System.Drawing.Point(72, 19)
        Me.DataRadio2.Name = "DataRadio2"
        Me.DataRadio2.Size = New System.Drawing.Size(66, 18)
        Me.DataRadio2.TabIndex = 1
        Me.DataRadio2.Text = "Juridica"
        Me.DataRadio2.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.DataRadio2.ThemeName = "Windows8"
        '
        'DataRadio1
        '
        Me.DataRadio1.BackColor = System.Drawing.SystemColors.Control
        Me.DataRadio1.Checked = False
        Me.DataRadio1.Descripcion = "Fisica"
        Me.DataRadio1.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.DataRadio1.Index = "F"
        Me.DataRadio1.Location = New System.Drawing.Point(6, 19)
        Me.DataRadio1.Name = "DataRadio1"
        Me.DataRadio1.Size = New System.Drawing.Size(55, 18)
        Me.DataRadio1.TabIndex = 0
        Me.DataRadio1.Text = "Fisica"
        Me.DataRadio1.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.DataRadio1.ThemeName = "Windows8"
        '
        'dtfCodigo
        '
        Me.dtfCodigo.Allow_Empty = True
        Me.dtfCodigo.Allow_Negative = True
        Me.dtfCodigo.AutoSize = True
        Me.dtfCodigo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
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
        Me.dtfCodigo.Location = New System.Drawing.Point(3, 7)
        Me.dtfCodigo.Max_Value = 0.0R
        Me.dtfCodigo.Name = "dtfCodigo"
        Me.dtfCodigo.Null_on_Empty = False
        Me.dtfCodigo.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfCodigo.ReadOnly_Data = True
        Me.dtfCodigo.Show_Button = False
        Me.dtfCodigo.Size = New System.Drawing.Size(110, 23)
        Me.dtfCodigo.TabIndex = 1
        Me.dtfCodigo.TabStop = False
        Me.dtfCodigo.Text_Data = ""
        Me.dtfCodigo.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfCodigo.TopPadding = 0
        Me.dtfCodigo.Upper_Case = False
        Me.dtfCodigo.Validate_on_lost_focus = True
        '
        'DataCheck1
        '
        Me.DataCheck1.DataField = "plazo"
        Me.DataCheck1.DataTable = 0
        Me.DataCheck1.Descripcion = "Moroso"
        Me.DataCheck1.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.DataCheck1.Location = New System.Drawing.Point(3, 181)
        Me.DataCheck1.Name = "DataCheck1"
        Me.DataCheck1.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.DataCheck1.Size = New System.Drawing.Size(64, 21)
        Me.DataCheck1.TabIndex = 9
        Me.DataCheck1.Text = "Moroso"
        Me.DataCheck1.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.DataCheck1.ThemeName = "Windows8"
        Me.DataCheck1.Value = False
        '
        'dtfVendedor
        '
        Me.dtfVendedor.Allow_Empty = True
        Me.dtfVendedor.Allow_Negative = True
        Me.dtfVendedor.AutoSize = True
        Me.dtfVendedor.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
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
        Me.dtfVendedor.Location = New System.Drawing.Point(3, 152)
        Me.dtfVendedor.Max_Value = 0.0R
        Me.dtfVendedor.Name = "dtfVendedor"
        Me.dtfVendedor.Null_on_Empty = False
        Me.dtfVendedor.OpenForm = "KarvePruebas.Form1"
        Me.dtfVendedor.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfVendedor.Query_on_Text_Changed = True
        Me.dtfVendedor.ReadOnly_Data = False
        Me.dtfVendedor.Size = New System.Drawing.Size(283, 23)
        Me.dtfVendedor.TabIndex = 8
        Me.dtfVendedor.Text_Data = ""
        Me.dtfVendedor.Text_Width = 58
        Me.dtfVendedor.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfVendedor.TopPadding = 0
        Me.dtfVendedor.Upper_Case = False
        Me.dtfVendedor.Validate_on_lost_focus = True
        '
        'dtfEmail
        '
        Me.dtfEmail.Allow_Empty = True
        Me.dtfEmail.Allow_Negative = True
        Me.dtfEmail.AutoSize = True
        Me.dtfEmail.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
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
        Me.dtfEmail.Location = New System.Drawing.Point(3, 123)
        Me.dtfEmail.Max_Value = 0.0R
        Me.dtfEmail.Name = "dtfEmail"
        Me.dtfEmail.Null_on_Empty = False
        Me.dtfEmail.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfEmail.ReadOnly_Data = False
        Me.dtfEmail.Show_Button = False
        Me.dtfEmail.Size = New System.Drawing.Size(283, 23)
        Me.dtfEmail.TabIndex = 7
        Me.dtfEmail.Text_Data = ""
        Me.dtfEmail.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfEmail.TopPadding = 0
        Me.dtfEmail.Upper_Case = False
        Me.dtfEmail.Validate_on_lost_focus = True
        '
        'dtfPoblacion
        '
        Me.dtfPoblacion.Allow_Empty = True
        Me.dtfPoblacion.Allow_Negative = True
        Me.dtfPoblacion.AutoSize = True
        Me.dtfPoblacion.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
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
        Me.dtfPoblacion.Location = New System.Drawing.Point(139, 65)
        Me.dtfPoblacion.Max_Value = 0.0R
        Me.dtfPoblacion.Name = "dtfPoblacion"
        Me.dtfPoblacion.Null_on_Empty = False
        Me.dtfPoblacion.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfPoblacion.ReadOnly_Data = False
        Me.dtfPoblacion.Show_Button = False
        Me.dtfPoblacion.Size = New System.Drawing.Size(147, 23)
        Me.dtfPoblacion.TabIndex = 5
        Me.dtfPoblacion.Text_Data = ""
        Me.dtfPoblacion.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfPoblacion.TopPadding = 0
        Me.dtfPoblacion.Upper_Case = False
        Me.dtfPoblacion.Validate_on_lost_focus = True
        '
        'dtfCP
        '
        Me.dtfCP.Allow_Empty = True
        Me.dtfCP.Allow_Negative = True
        Me.dtfCP.AutoSize = True
        Me.dtfCP.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
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
        Me.dtfCP.Location = New System.Drawing.Point(3, 65)
        Me.dtfCP.Max_Value = 0.0R
        Me.dtfCP.Name = "dtfCP"
        Me.dtfCP.Null_on_Empty = False
        Me.dtfCP.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfCP.ReadOnly_Data = False
        Me.dtfCP.Show_Button = True
        Me.dtfCP.Size = New System.Drawing.Size(116, 23)
        Me.dtfCP.TabIndex = 4
        Me.dtfCP.Text_Data = ""
        Me.dtfCP.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfCP.TopPadding = 0
        Me.dtfCP.Upper_Case = False
        Me.dtfCP.Validate_on_lost_focus = True
        '
        'dtfPais
        '
        Me.dtfPais.Allow_Empty = True
        Me.dtfPais.Allow_Negative = True
        Me.dtfPais.AutoSize = True
        Me.dtfPais.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
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
        Me.dtfPais.Location = New System.Drawing.Point(3, 94)
        Me.dtfPais.Max_Value = 0.0R
        Me.dtfPais.Name = "dtfPais"
        Me.dtfPais.Null_on_Empty = True
        Me.dtfPais.OpenForm = Nothing
        Me.dtfPais.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfPais.Query_on_Text_Changed = True
        Me.dtfPais.ReadOnly_Data = False
        Me.dtfPais.Size = New System.Drawing.Size(283, 23)
        Me.dtfPais.TabIndex = 6
        Me.dtfPais.Text_Data = ""
        Me.dtfPais.Text_Width = 58
        Me.dtfPais.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfPais.TopPadding = 0
        Me.dtfPais.Upper_Case = False
        Me.dtfPais.Validate_on_lost_focus = True
        '
        'dtfNombre
        '
        Me.dtfNombre.Allow_Empty = True
        Me.dtfNombre.Allow_Negative = True
        Me.dtfNombre.AutoSize = True
        Me.dtfNombre.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
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
        Me.dtfNombre.Location = New System.Drawing.Point(133, 7)
        Me.dtfNombre.Max_Value = 0.0R
        Me.dtfNombre.Name = "dtfNombre"
        Me.dtfNombre.Null_on_Empty = False
        Me.dtfNombre.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfNombre.ReadOnly_Data = False
        Me.dtfNombre.Show_Button = False
        Me.dtfNombre.Size = New System.Drawing.Size(153, 23)
        Me.dtfNombre.TabIndex = 2
        Me.dtfNombre.Text_Data = ""
        Me.dtfNombre.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfNombre.TopPadding = 0
        Me.dtfNombre.Upper_Case = False
        Me.dtfNombre.Validate_on_lost_focus = True
        '
        'dtfDireccion
        '
        Me.dtfDireccion.Allow_Empty = True
        Me.dtfDireccion.Allow_Negative = True
        Me.dtfDireccion.AutoSize = True
        Me.dtfDireccion.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
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
        Me.dtfDireccion.Location = New System.Drawing.Point(3, 36)
        Me.dtfDireccion.Max_Value = 0.0R
        Me.dtfDireccion.Name = "dtfDireccion"
        Me.dtfDireccion.Null_on_Empty = False
        Me.dtfDireccion.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfDireccion.ReadOnly_Data = False
        Me.dtfDireccion.Show_Button = False
        Me.dtfDireccion.Size = New System.Drawing.Size(283, 23)
        Me.dtfDireccion.TabIndex = 3
        Me.dtfDireccion.Text_Data = ""
        Me.dtfDireccion.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfDireccion.TopPadding = 0
        Me.dtfDireccion.Upper_Case = False
        Me.dtfDireccion.Validate_on_lost_focus = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(690, 154)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 29
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(690, 38)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnAdd.TabIndex = 28
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(690, 125)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 27
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnLoad
        '
        Me.btnLoad.Location = New System.Drawing.Point(690, 67)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(75, 23)
        Me.btnLoad.TabIndex = 26
        Me.btnLoad.Text = "Load"
        Me.btnLoad.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(690, 96)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 25
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.dtfCodigo)
        Me.Panel1.Controls.Add(Me.dtfDireccion)
        Me.Panel1.Controls.Add(Me.DataDateLabel1)
        Me.Panel1.Controls.Add(Me.dtfNombre)
        Me.Panel1.Controls.Add(Me.dtfPais)
        Me.Panel1.Controls.Add(Me.dtfCP)
        Me.Panel1.Controls.Add(Me.dtfPoblacion)
        Me.Panel1.Controls.Add(Me.dtfEmail)
        Me.Panel1.Controls.Add(Me.DataAreaLabel1)
        Me.Panel1.Controls.Add(Me.dtfVendedor)
        Me.Panel1.Controls.Add(Me.RadioGroup1)
        Me.Panel1.Controls.Add(Me.DataCheck1)
        Me.Panel1.Location = New System.Drawing.Point(31, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(302, 390)
        Me.Panel1.TabIndex = 30
        Me.Panel1.ThemeName = "Windows8"
        '
        'Datafield1
        '
        Me.Datafield1.Allow_Empty = True
        Me.Datafield1.Allow_Negative = True
        Me.Datafield1.AutoSize = True
        Me.Datafield1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Datafield1.BackColor = System.Drawing.SystemColors.Control
        Me.Datafield1.Data_Allowed = CustomControls.Datafield.List_Data.NIF
        Me.Datafield1.DataField = Nothing
        Me.Datafield1.DataTable = 0
        Me.Datafield1.Descripcion = Nothing
        Me.Datafield1.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.Datafield1.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.Datafield1.Length_Data = 32767
        Me.Datafield1.Location = New System.Drawing.Point(481, 96)
        Me.Datafield1.Max_Value = 0.0R
        Me.Datafield1.Name = "Datafield1"
        Me.Datafield1.Null_on_Empty = False
        Me.Datafield1.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.Datafield1.ReadOnly_Data = False
        Me.Datafield1.Size = New System.Drawing.Size(100, 23)
        Me.Datafield1.TabIndex = 31
        Me.Datafield1.Text_Data = ""
        Me.Datafield1.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.Datafield1.TopPadding = 0
        Me.Datafield1.Upper_Case = False
        Me.Datafield1.Validate_on_lost_focus = True
        '
        'Datafield2
        '
        Me.Datafield2.Allow_Empty = True
        Me.Datafield2.Allow_Negative = True
        Me.Datafield2.AutoSize = True
        Me.Datafield2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Datafield2.BackColor = System.Drawing.SystemColors.Control
        Me.Datafield2.Data_Allowed = CustomControls.Datafield.List_Data.nDouble
        Me.Datafield2.DataField = Nothing
        Me.Datafield2.DataTable = 0
        Me.Datafield2.Descripcion = Nothing
        Me.Datafield2.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.Datafield2.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.Datafield2.Length_Data = 32767
        Me.Datafield2.Location = New System.Drawing.Point(481, 67)
        Me.Datafield2.Max_Value = 0.0R
        Me.Datafield2.Name = "Datafield2"
        Me.Datafield2.Null_on_Empty = False
        Me.Datafield2.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.Datafield2.ReadOnly_Data = False
        Me.Datafield2.Size = New System.Drawing.Size(100, 23)
        Me.Datafield2.TabIndex = 32
        Me.Datafield2.Text_Data = ""
        Me.Datafield2.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.Datafield2.TopPadding = 0
        Me.Datafield2.Upper_Case = False
        Me.Datafield2.Validate_on_lost_focus = True
        '
        'RadMaskedEditBox1
        '
        Me.RadMaskedEditBox1.Location = New System.Drawing.Point(481, 237)
        Me.RadMaskedEditBox1.Mask = "[0-9]{2}:[0-9]{2}"
        Me.RadMaskedEditBox1.MaskType = Telerik.WinControls.UI.MaskType.Regex
        Me.RadMaskedEditBox1.Name = "RadMaskedEditBox1"
        Me.RadMaskedEditBox1.Size = New System.Drawing.Size(125, 20)
        Me.RadMaskedEditBox1.TabIndex = 33
        Me.RadMaskedEditBox1.TabStop = False
        Me.RadMaskedEditBox1.ThemeName = "Windows8"
        '
        'RadTimePicker1
        '
        Me.RadTimePicker1.Location = New System.Drawing.Point(481, 289)
        Me.RadTimePicker1.Name = "RadTimePicker1"
        Me.RadTimePicker1.Size = New System.Drawing.Size(85, 20)
        Me.RadTimePicker1.TabIndex = 34
        Me.RadTimePicker1.TabStop = False
        Me.RadTimePicker1.Text = "RadTimePicker1"
        Me.RadTimePicker1.ThemeName = "Windows8"
        Me.RadTimePicker1.Value = New Date(2014, 10, 14, 10, 0, 0, 0)
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.Button1.Location = New System.Drawing.Point(572, 288)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 35
        Me.Button1.Text = "Button1"
        Me.Button1.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.Button1.ThemeName = "Windows8"
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(840, 556)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.RadTimePicker1)
        Me.Controls.Add(Me.RadMaskedEditBox1)
        Me.Controls.Add(Me.Datafield2)
        Me.Controls.Add(Me.Datafield1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.btnSave)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form2"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "TEST"
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.btnLoad, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnAdd, 0)
        Me.Controls.SetChildIndex(Me.btnDelete, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.Datafield1, 0)
        Me.Controls.SetChildIndex(Me.Datafield2, 0)
        Me.Controls.SetChildIndex(Me.RadMaskedEditBox1, 0)
        Me.Controls.SetChildIndex(Me.RadTimePicker1, 0)
        Me.Controls.SetChildIndex(Me.Button1, 0)
        CType(Me.RadioGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadioGroup1.ResumeLayout(False)
        Me.RadioGroup1.PerformLayout()
        CType(Me.DataRadio2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataRadio1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataCheck1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Panel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.RadMaskedEditBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadTimePicker1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Button1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataDateLabel1 As CustomControls.DataDateLabel
    Friend WithEvents DataAreaLabel1 As CustomControls.DataAreaLabel
    Friend WithEvents RadioGroup1 As CustomControls.RadioGroup
    Friend WithEvents DataRadio2 As CustomControls.DataRadio
    Friend WithEvents DataRadio1 As CustomControls.DataRadio
    Friend WithEvents dtfCodigo As CustomControls.DatafieldLabel
    Friend WithEvents DataCheck1 As CustomControls.DataCheck
    Friend WithEvents dtfVendedor As CustomControls.DualDatafieldLabel
    Friend WithEvents dtfEmail As CustomControls.DatafieldLabel
    Friend WithEvents dtfPoblacion As CustomControls.DatafieldLabel
    Friend WithEvents dtfCP As CustomControls.DatafieldLabel
    Friend WithEvents dtfPais As CustomControls.DualDatafieldLabel
    Friend WithEvents dtfNombre As CustomControls.DatafieldLabel
    Friend WithEvents dtfDireccion As CustomControls.DatafieldLabel
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Panel1 As CustomControls.Panel
    Friend WithEvents Datafield1 As CustomControls.Datafield
    Friend WithEvents Datafield2 As CustomControls.Datafield
    Friend WithEvents RadMaskedEditBox1 As Telerik.WinControls.UI.RadMaskedEditBox
    Friend WithEvents RadTimePicker1 As Telerik.WinControls.UI.RadTimePicker
    Friend WithEvents Button1 As CustomControls.Button
End Class
