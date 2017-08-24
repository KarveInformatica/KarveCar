Imports CustomControls
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class cargaControles
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
        Me.pvpDummy = New CustomControls.PageViewPage()
        Me.RadioGroup1 = New CustomControls.RadioGroup()
        Me.Panel1 = New CustomControls.Panel()
        Me.Label1 = New CustomControls.Label()
        Me.GroupBox1 = New CustomControls.GroupBox()
        Me.DataTimeLabel1 = New CustomControls.DataTimeLabel()
        Me.DataTime1 = New CustomControls.DataTime()
        Me.DataRadio1 = New CustomControls.DataRadio()
        Me.DataLabel1 = New CustomControls.DataLabel()
        Me.DatafieldLabel1 = New CustomControls.DatafieldLabel()
        Me.Datafield1 = New CustomControls.Datafield()
        Me.DataGrid1 = New CustomControls.DataGrid()
        Me.DataDateLabel1 = New CustomControls.DataDateLabel()
        Me.DataDate1 = New CustomControls.DataDate()
        Me.DataCheck1 = New CustomControls.DataCheck()
        Me.DataAreaLabel1 = New CustomControls.DataAreaLabel()
        Me.DataArea1 = New CustomControls.DataRichField()
        Me.Button1 = New CustomControls.Button()
        CType(Me.pnlBlock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.stbBase, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pvpDummy.SuspendLayout()
        CType(Me.RadioGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Panel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataRadio1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGrid1.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataCheck1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Button1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rbtEdicion
        '
        Me.rbtEdicion.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.rbtEdicion.BorderColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.rbtEdicion.BorderGradientStyle = Telerik.WinControls.GradientStyles.Solid
        Me.rbtEdicion.Bounds = New System.Drawing.Rectangle(0, 0, 64, 28)
        Me.rbtEdicion.ClipDrawing = True
        Me.rbtEdicion.ClipText = True
        Me.rbtEdicion.DrawBorder = True
        Me.rbtEdicion.DrawFill = True
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
        'pnlBlock
        '
        Me.pnlBlock.Location = New System.Drawing.Point(0, 547)
        '
        'rbgEdicion
        '
        Me.rbgEdicion.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.rbgEdicion.Bounds = New System.Drawing.Rectangle(0, 0, 246, 96)
        Me.rbgEdicion.ForeColor = System.Drawing.Color.Black
        '
        'pvpDummy
        '
        Me.pvwBase.Pages.Add(pvpDummy)
        Me.pvpDummy.Controls.Add(Me.RadioGroup1)
        Me.pvpDummy.Controls.Add(Me.Panel1)
        Me.pvpDummy.Controls.Add(Me.Label1)
        Me.pvpDummy.Controls.Add(Me.GroupBox1)
        Me.pvpDummy.Controls.Add(Me.DataTimeLabel1)
        Me.pvpDummy.Controls.Add(Me.DataTime1)
        Me.pvpDummy.Controls.Add(Me.DataRadio1)
        Me.pvpDummy.Controls.Add(Me.DataLabel1)
        Me.pvpDummy.Controls.Add(Me.DatafieldLabel1)
        Me.pvpDummy.Controls.Add(Me.Datafield1)
        Me.pvpDummy.Controls.Add(Me.DataGrid1)
        Me.pvpDummy.Controls.Add(Me.DataDateLabel1)
        Me.pvpDummy.Controls.Add(Me.DataDate1)
        Me.pvpDummy.Controls.Add(Me.DataCheck1)
        Me.pvpDummy.Controls.Add(Me.DataAreaLabel1)
        Me.pvpDummy.Controls.Add(Me.DataArea1)
        Me.pvpDummy.Controls.Add(Me.Button1)
        Me.pvpDummy.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pvpDummy.Location = New System.Drawing.Point(129, 5)
        Me.pvpDummy.Name = "pvpDummy"
        Me.pvpDummy.Size = New System.Drawing.Size(882, 471)
        Me.pvpDummy.Text = "Dummy"
        '
        'RadioGroup1
        '
        Me.RadioGroup1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.RadioGroup1.DataField = Nothing
        Me.RadioGroup1.DataTable = ""
        Me.RadioGroup1.Descripcion = "RadioGroup1"
        Me.RadioGroup1.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.RadioGroup1.HeaderText = "RadioGroup1"
        Me.RadioGroup1.Index = Nothing
        Me.RadioGroup1.Location = New System.Drawing.Point(576, 18)
        Me.RadioGroup1.Name = "RadioGroup1"
        Me.RadioGroup1.numRows = 0
        Me.RadioGroup1.Padding = New System.Windows.Forms.Padding(6, 18, 6, 6)
        Me.RadioGroup1.Reorder = True
        Me.RadioGroup1.Size = New System.Drawing.Size(200, 100)
        Me.RadioGroup1.TabIndex = 16
        Me.RadioGroup1.Text = "RadioGroup1"
        Me.RadioGroup1.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.RadioGroup1.ThemeName = "Windows8"
        Me.RadioGroup1.Title = "RadioGroup1"
        '
        'Panel1
        '
        Me.Panel1.Auto_Size = False
        Me.Panel1.BorderColor = System.Drawing.SystemColors.Control
        Me.Panel1.ChangeDock = True
        Me.Panel1.Control_Resize = False
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.isSpace = False
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.numRows = 0
        Me.Panel1.Reorder = True
        Me.Panel1.Size = New System.Drawing.Size(882, 100)
        Me.Panel1.TabIndex = 15
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.Label1.Location = New System.Drawing.Point(90, 246)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 17)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Label1"
        '
        'GroupBox1
        '
        Me.GroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.GroupBox1.HeaderText = "GroupBox1"
        Me.GroupBox1.Location = New System.Drawing.Point(90, 340)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.numRows = 0
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(6, 18, 6, 6)
        Me.GroupBox1.Reorder = True
        Me.GroupBox1.Size = New System.Drawing.Size(200, 100)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.Text = "GroupBox1"
        Me.GroupBox1.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.GroupBox1.ThemeName = "Windows8"
        Me.GroupBox1.Title = "GroupBox1"
        '
        'DataTimeLabel1
        '
        Me.DataTimeLabel1.Allow_Empty = True
        Me.DataTimeLabel1.DataField = Nothing
        Me.DataTimeLabel1.DataTable = ""
        Me.DataTimeLabel1.Descripcion = "Label1"
        Me.DataTimeLabel1.Label_Space = 75
        Me.DataTimeLabel1.Location = New System.Drawing.Point(81, 294)
        Me.DataTimeLabel1.MensajeIncorrectoCustom = Nothing
        Me.DataTimeLabel1.Name = "DataTimeLabel1"
        Me.DataTimeLabel1.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.DataTimeLabel1.ReadOnly_Data = False
        Me.DataTimeLabel1.Size = New System.Drawing.Size(151, 26)
        Me.DataTimeLabel1.TabIndex = 12
        Me.DataTimeLabel1.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.DataTimeLabel1.Time = System.TimeSpan.Parse("10:59:00")
        Me.DataTimeLabel1.Validate_on_lost_focus = True
        '
        'DataTime1
        '
        Me.DataTime1.Allow_Empty = True
        Me.DataTime1.DataField = Nothing
        Me.DataTime1.DataTable = ""
        Me.DataTime1.Descripcion = Nothing
        Me.DataTime1.Location = New System.Drawing.Point(90, 88)
        Me.DataTime1.MensajeIncorrectoCustom = Nothing
        Me.DataTime1.Name = "DataTime1"
        Me.DataTime1.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.DataTime1.ReadOnly_Data = False
        Me.DataTime1.Size = New System.Drawing.Size(77, 26)
        Me.DataTime1.TabIndex = 11
        Me.DataTime1.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.DataTime1.Time = System.TimeSpan.Parse("10:59:00")
        Me.DataTime1.Validate_on_lost_focus = True
        '
        'DataRadio1
        '
        Me.DataRadio1.BackColor = System.Drawing.SystemColors.Control
        Me.DataRadio1.Checked = False
        Me.DataRadio1.Descripcion = "DataRadio1"
        Me.DataRadio1.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.DataRadio1.Index = Nothing
        Me.DataRadio1.Location = New System.Drawing.Point(232, 79)
        Me.DataRadio1.Name = "DataRadio1"
        Me.DataRadio1.Size = New System.Drawing.Size(86, 17)
        Me.DataRadio1.TabIndex = 10
        Me.DataRadio1.Text = "DataRadio1"
        Me.DataRadio1.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.DataRadio1.ThemeName = "Windows8"
        '
        'DataLabel1
        '
        Me.DataLabel1.AutoSize = False
        Me.DataLabel1.DataField = Nothing
        Me.DataLabel1.DataTable = ""
        Me.DataLabel1.Descripcion = "DataLabel1"
        Me.DataLabel1.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.DataLabel1.Fromat = CustomControls.DataLabel.fotmatType.plain
        Me.DataLabel1.Location = New System.Drawing.Point(232, 208)
        Me.DataLabel1.Name = "DataLabel1"
        Me.DataLabel1.Size = New System.Drawing.Size(100, 18)
        Me.DataLabel1.TabIndex = 9
        Me.DataLabel1.Text = "DataLabel1"
        '
        'DatafieldLabel1
        '
        Me.DatafieldLabel1.Allow_Empty = True
        Me.DatafieldLabel1.Allow_Negative = True
        Me.DatafieldLabel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.DatafieldLabel1.BackColor = System.Drawing.SystemColors.Control
        Me.DatafieldLabel1.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.DatafieldLabel1.DataField = Nothing
        Me.DatafieldLabel1.DataTable = ""
        Me.DatafieldLabel1.Descripcion = "Label1"
        Me.DatafieldLabel1.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.DatafieldLabel1.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.DatafieldLabel1.Image = Nothing
        Me.DatafieldLabel1.Label_Space = 75
        Me.DatafieldLabel1.Length_Data = 32767
        Me.DatafieldLabel1.Location = New System.Drawing.Point(600, 185)
        Me.DatafieldLabel1.Max_Value = 0.0R
        Me.DatafieldLabel1.MensajeIncorrectoCustom = Nothing
        Me.DatafieldLabel1.Name = "DatafieldLabel1"
        Me.DatafieldLabel1.Null_on_Empty = True
        Me.DatafieldLabel1.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.DatafieldLabel1.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.DatafieldLabel1.ReadOnly_Data = False
        Me.DatafieldLabel1.Show_Button = False
        Me.DatafieldLabel1.Size = New System.Drawing.Size(200, 26)
        Me.DatafieldLabel1.TabIndex = 8
        Me.DatafieldLabel1.Text_Data = ""
        Me.DatafieldLabel1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.DatafieldLabel1.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.DatafieldLabel1.TopPadding = 0
        Me.DatafieldLabel1.Upper_Case = False
        Me.DatafieldLabel1.Validate_on_lost_focus = True
        '
        'Datafield1
        '
        Me.Datafield1.Allow_Empty = True
        Me.Datafield1.Allow_Negative = True
        Me.Datafield1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Datafield1.BackColor = System.Drawing.SystemColors.Control
        Me.Datafield1.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.Datafield1.DataField = Nothing
        Me.Datafield1.DataTable = ""
        Me.Datafield1.Descripcion = Nothing
        Me.Datafield1.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.Datafield1.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.Datafield1.Length_Data = 32767
        Me.Datafield1.Location = New System.Drawing.Point(700, 246)
        Me.Datafield1.Max_Value = 0.0R
        Me.Datafield1.MensajeIncorrectoCustom = Nothing
        Me.Datafield1.Name = "Datafield1"
        Me.Datafield1.Null_on_Empty = True
        Me.Datafield1.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.Datafield1.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.Datafield1.ReadOnly_Data = False
        Me.Datafield1.Size = New System.Drawing.Size(100, 26)
        Me.Datafield1.TabIndex = 7
        Me.Datafield1.Text_Data = ""
        Me.Datafield1.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.Datafield1.TopPadding = 0
        Me.Datafield1.Upper_Case = False
        Me.Datafield1.Validate_on_lost_focus = True
        '
        'DataGrid1
        '
        Me.DataGrid1.ColRel = Nothing
        Me.DataGrid1.ColSelectFilter = Nothing
        Me.DataGrid1.DataGridType = CustomControls.DataGrid.GridType.Search
        Me.DataGrid1.DBConnection = Nothing
        Me.DataGrid1.idRel = Nothing
        Me.DataGrid1.Location = New System.Drawing.Point(304, 340)
        Me.DataGrid1.MarcarFilas = False
        '
        'DataGrid1
        '
        Me.DataGrid1.MasterTemplate.AllowAddNewRow = False
        Me.DataGrid1.MasterTemplate.AllowDeleteRow = False
        Me.DataGrid1.MasterTemplate.EnableFiltering = True
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.Size = New System.Drawing.Size(240, 150)
        Me.DataGrid1.TabIndex = 6
        Me.DataGrid1.TablaEdit = Nothing
        Me.DataGrid1.Text = "DataGrid1"
        Me.DataGrid1.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.DataGrid1.ThemeName = "TelerikMetroBlue"
        '
        'DataDateLabel1
        '
        Me.DataDateLabel1.Allow_Empty = True
        Me.DataDateLabel1.DataField = Nothing
        Me.DataDateLabel1.DataTable = ""
        Me.DataDateLabel1.Default_Value = New Date(2015, 5, 14, 0, 0, 0, 0)
        Me.DataDateLabel1.Descripcion = "Label1"
        Me.DataDateLabel1.Label_Space = 75
        Me.DataDateLabel1.Location = New System.Drawing.Point(109, 175)
        Me.DataDateLabel1.Max_Value = Nothing
        Me.DataDateLabel1.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.DataDateLabel1.MensajeIncorrectoCustom = Nothing
        Me.DataDateLabel1.Min_Value = Nothing
        Me.DataDateLabel1.MinDate = New Date(CType(0, Long))
        Me.DataDateLabel1.MinimumSize = New System.Drawing.Size(165, 26)
        Me.DataDateLabel1.Name = "DataDateLabel1"
        Me.DataDateLabel1.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.DataDateLabel1.ReadOnly_Data = False
        Me.DataDateLabel1.Size = New System.Drawing.Size(209, 26)
        Me.DataDateLabel1.TabIndex = 5
        Me.DataDateLabel1.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.DataDateLabel1.Validate_on_lost_focus = True
        Me.DataDateLabel1.Value_Data = New Date(2015, 5, 14, 0, 0, 0, 0)
        '
        'DataDate1
        '
        Me.DataDate1.Allow_Empty = True
        Me.DataDate1.DataField = Nothing
        Me.DataDate1.DataTable = ""
        Me.DataDate1.Default_Value = New Date(2015, 5, 14, 0, 0, 0, 0)
        Me.DataDate1.Descripcion = Nothing
        Me.DataDate1.Location = New System.Drawing.Point(162, 246)
        Me.DataDate1.Max_Value = Nothing
        Me.DataDate1.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.DataDate1.MensajeIncorrectoCustom = Nothing
        Me.DataDate1.Min_Value = Nothing
        Me.DataDate1.MinDate = New Date(CType(0, Long))
        Me.DataDate1.Name = "DataDate1"
        Me.DataDate1.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.DataDate1.ReadOnly_Data = False
        Me.DataDate1.Size = New System.Drawing.Size(111, 26)
        Me.DataDate1.TabIndex = 4
        Me.DataDate1.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.DataDate1.Validate_on_lost_focus = True
        Me.DataDate1.Value_Data = New Date(2015, 5, 14, 0, 0, 0, 0)
        '
        'DataCheck1
        '
        Me.DataCheck1.DataField = Nothing
        Me.DataCheck1.DataTable = ""
        Me.DataCheck1.Descripcion = "DataCheck1"
        Me.DataCheck1.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.DataCheck1.Location = New System.Drawing.Point(173, 126)
        Me.DataCheck1.Name = "DataCheck1"
        Me.DataCheck1.Size = New System.Drawing.Size(92, 18)
        Me.DataCheck1.TabIndex = 3
        Me.DataCheck1.Text = "DataCheck1"
        Me.DataCheck1.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.DataCheck1.ThemeName = "Windows8"
        Me.DataCheck1.Value = False
        '
        'DataAreaLabel1
        '
        Me.DataAreaLabel1.Allow_Empty = True
        Me.DataAreaLabel1.Allow_Negative = True
        Me.DataAreaLabel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.DataAreaLabel1.BackColor = System.Drawing.SystemColors.Control
        Me.DataAreaLabel1.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.DataAreaLabel1.DataField = Nothing
        Me.DataAreaLabel1.DataTable = ""
        Me.DataAreaLabel1.Descripcion = "Label1"
        Me.DataAreaLabel1.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.DataAreaLabel1.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.DataAreaLabel1.Length_Data = 32767
        Me.DataAreaLabel1.Location = New System.Drawing.Point(3, 77)
        Me.DataAreaLabel1.Max_Value = 0.0R
        Me.DataAreaLabel1.MensajeIncorrectoCustom = Nothing
        Me.DataAreaLabel1.Name = "DataAreaLabel1"
        Me.DataAreaLabel1.Null_on_Empty = True
        Me.DataAreaLabel1.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.DataAreaLabel1.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.DataAreaLabel1.ReadOnly_Data = False
        Me.DataAreaLabel1.Size = New System.Drawing.Size(250, 124)
        Me.DataAreaLabel1.TabIndex = 17
        Me.DataAreaLabel1.Text_Data = ""
        Me.DataAreaLabel1.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.DataAreaLabel1.TopPadding = 0
        Me.DataAreaLabel1.Upper_Case = False
        Me.DataAreaLabel1.Validate_on_lost_focus = True
        '
        'DataArea1
        '
        Me.DataArea1.Allow_Empty = True
        Me.DataArea1.Byte_Data = Nothing
        Me.DataArea1.Data_Allowed = CustomControls.DataRichField.List_Data.Libre
        Me.DataArea1.DataField = Nothing
        Me.DataArea1.DataTable = ""
        Me.DataArea1.Descripcion = Nothing
        Me.DataArea1.Encoding = CustomControls.DataRichField.Code_Collation.LATIN
        Me.DataArea1.Location = New System.Drawing.Point(0, 0)
        Me.DataArea1.Name = "DataArea1"
        Me.DataArea1.Null_on_Empty = False
        Me.DataArea1.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.DataArea1.ReadOnly_Data = False
        Me.DataArea1.Size = New System.Drawing.Size(250, 100)
        Me.DataArea1.TabIndex = 18
        Me.DataArea1.Text_Data = Nothing
        Me.DataArea1.Text_Type = CustomControls.DataRichField.TextType.Plain
        Me.DataArea1.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.DataArea1.Upper_Case = False
        Me.DataArea1.Validate_on_lost_focus = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.Button1.Location = New System.Drawing.Point(232, 18)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Button1"
        Me.Button1.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.Button1.ThemeName = "Windows8"
        '
        'cargaControles
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1016, 639)
        Me.Name = "cargaControles"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "cargaControles"
        CType(Me.pnlBlock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.stbBase, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pvpDummy.ResumeLayout(False)
        Me.pvpDummy.PerformLayout()
        CType(Me.RadioGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Panel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataRadio1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGrid1.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataCheck1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Button1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pvpDummy As CustomControls.PageViewPage
    Friend WithEvents RadioGroup1 As CustomControls.RadioGroup
    Friend WithEvents Panel1 As CustomControls.Panel
    Friend WithEvents Label1 As CustomControls.Label
    Friend WithEvents GroupBox1 As CustomControls.GroupBox
    Friend WithEvents DataTimeLabel1 As CustomControls.DataTimeLabel
    Friend WithEvents DataTime1 As CustomControls.DataTime
    Friend WithEvents DataRadio1 As CustomControls.DataRadio
    Friend WithEvents DataLabel1 As CustomControls.DataLabel
    Friend WithEvents DatafieldLabel1 As CustomControls.DatafieldLabel
    Friend WithEvents Datafield1 As CustomControls.Datafield
    Friend WithEvents DataGrid1 As CustomControls.DataGrid
    Friend WithEvents DataDateLabel1 As CustomControls.DataDateLabel
    Friend WithEvents DataDate1 As CustomControls.DataDate
    Friend WithEvents DataCheck1 As CustomControls.DataCheck
    Friend WithEvents DataAreaLabel1 As CustomControls.DataAreaLabel
    Friend WithEvents DataArea1 As CustomControls.DataRichField
    Friend WithEvents Button1 As CustomControls.Button
End Class
