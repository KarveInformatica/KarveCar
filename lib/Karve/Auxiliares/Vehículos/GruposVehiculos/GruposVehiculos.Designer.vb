<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GruposVehiculos
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
        Me.pvpGeneral = New CustomControls.PageViewPage()
        Me.pnlSec = New CustomControls.Panel()
        Me.dtaObs = New CustomControls.DataAreaLabel()
        Me.dtaModelos = New CustomControls.DataAreaLabel()
        Me.pnlPpal = New CustomControls.Panel()
        Me.grbCondiciones = New CustomControls.GroupBox()
        Me.Panel3 = New CustomControls.Panel()
        Me.dtfCarnetMin = New CustomControls.DatafieldLabel()
        Me.dtfEdadMinBlq = New CustomControls.DatafieldLabel()
        Me.dtfEdadMinAv = New CustomControls.DatafieldLabel()
        Me.grbImportes = New CustomControls.GroupBox()
        Me.pnConceptos2 = New CustomControls.Panel()
        Me.Panel1 = New CustomControls.Panel()
        Me.dtfPrecCesion = New CustomControls.DatafieldLabel()
        Me.Panel2 = New CustomControls.Panel()
        Me.dtfFranq = New CustomControls.DatafieldLabel()
        Me.pnPlus = New CustomControls.Panel()
        Me.dtfPlus = New CustomControls.DatafieldLabel()
        Me.pnCiego = New CustomControls.Panel()
        Me.pnConceptos = New CustomControls.Panel()
        Me.dtfPai = New CustomControls.DatafieldLabel()
        Me.dtfTp = New CustomControls.DatafieldLabel()
        Me.dtfCdw = New CustomControls.DatafieldLabel()
        Me.pnlColor = New CustomControls.Panel()
        Me.dtfColor = New CustomControls.DataFieldLabelColor()
        Me.dtfTipo = New CustomControls.DualDatafieldLabel()
        Me.pnlFaltaFbaja = New CustomControls.Panel()
        Me.dtdFBaja = New CustomControls.DataDateLabel()
        Me.pnlBottomGen = New CustomControls.Panel()
        Me.dtlUltmodi = New CustomControls.DataLabel()
        Me.dtlUsumodi = New CustomControls.DataLabel()
        Me.dtfNombre = New CustomControls.DatafieldLabel()
        Me.pnlCodigo = New CustomControls.Panel()
        Me.dtfAcriss = New CustomControls.DatafieldLabel()
        Me.dtfCodigo = New CustomControls.DatafieldLabel()
        Me.pvpFoto = New CustomControls.PageViewPage()
        CType(Me.pnlBlock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pvwBase, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pvwBase.SuspendLayout()
        CType(Me.stbBase, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pvpGeneral.SuspendLayout()
        CType(Me.pnlSec, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSec.SuspendLayout()
        CType(Me.pnlPpal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPpal.SuspendLayout()
        CType(Me.grbCondiciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbCondiciones.SuspendLayout()
        CType(Me.Panel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.grbImportes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbImportes.SuspendLayout()
        CType(Me.pnConceptos2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnConceptos2.SuspendLayout()
        CType(Me.Panel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.Panel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnPlus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnPlus.SuspendLayout()
        CType(Me.pnCiego, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnConceptos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnConceptos.SuspendLayout()
        CType(Me.pnlColor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlColor.SuspendLayout()
        CType(Me.pnlFaltaFbaja, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFaltaFbaja.SuspendLayout()
        CType(Me.pnlBottomGen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBottomGen.SuspendLayout()
        CType(Me.dtlUltmodi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtlUsumodi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlCodigo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCodigo.SuspendLayout()
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
        Me.pnlBlock.Location = New System.Drawing.Point(0, 868)
        '
        'pvwBase
        '
        Me.pvwBase.Controls.Add(Me.pvpGeneral)
        Me.pvwBase.Controls.Add(Me.pvpFoto)
        Me.pvwBase.SelectedPage = Me.pvpGeneral
        Me.pvwBase.Size = New System.Drawing.Size(1081, 766)
        Me.pvwBase.Text = ""
        '
        'rbgEdicion
        '
        Me.rbgEdicion.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.rbgEdicion.Bounds = New System.Drawing.Rectangle(0, 0, 246, 96)
        Me.rbgEdicion.ForeColor = System.Drawing.Color.Black
        '
        'stbBase
        '
        Me.stbBase.Location = New System.Drawing.Point(0, 766)
        Me.stbBase.Size = New System.Drawing.Size(1081, 25)
        '
        'pvpGeneral
        '
        Me.pvpGeneral.AutoScroll = True
        Me.pvpGeneral.Controls.Add(Me.pnlSec)
        Me.pvpGeneral.Controls.Add(Me.pnlPpal)
        Me.pvpGeneral.ItemSize = New System.Drawing.SizeF(51.0!, 24.0!)
        Me.pvpGeneral.Location = New System.Drawing.Point(129, 5)
        Me.pvpGeneral.Name = "pvpGeneral"
        Me.pvpGeneral.Size = New System.Drawing.Size(947, 756)
        Me.pvpGeneral.Text = "General"
        '
        'pnlSec
        '
        Me.pnlSec.Auto_Size = False
        Me.pnlSec.BackColor = System.Drawing.SystemColors.Control
        Me.pnlSec.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSec.ChangeDock = True
        Me.pnlSec.Control_Resize = False
        Me.pnlSec.Controls.Add(Me.dtaObs)
        Me.pnlSec.Controls.Add(Me.dtaModelos)
        Me.pnlSec.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSec.isSpace = False
        Me.pnlSec.Location = New System.Drawing.Point(472, 0)
        Me.pnlSec.Name = "pnlSec"
        Me.pnlSec.numRows = 0
        Me.pnlSec.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.pnlSec.Reorder = True
        Me.pnlSec.Size = New System.Drawing.Size(472, 756)
        Me.pnlSec.TabIndex = 10
        '
        'dtaObs
        '
        Me.dtaObs.Allow_Empty = True
        Me.dtaObs.Allow_Negative = True
        Me.dtaObs.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtaObs.BackColor = System.Drawing.SystemColors.Control
        Me.dtaObs.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtaObs.DataField = "OBS1"
        Me.dtaObs.DataTable = "GRU"
        Me.dtaObs.Descripcion = "Notas"
        Me.dtaObs.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtaObs.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtaObs.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtaObs.Length_Data = 32767
        Me.dtaObs.Location = New System.Drawing.Point(3, 130)
        Me.dtaObs.Max_Value = 0.0R
        Me.dtaObs.MensajeIncorrectoCustom = Nothing
        Me.dtaObs.Name = "dtaObs"
        Me.dtaObs.Null_on_Empty = True
        Me.dtaObs.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtaObs.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtaObs.ReadOnly_Data = False
        Me.dtaObs.Size = New System.Drawing.Size(469, 130)
        Me.dtaObs.TabIndex = 1
        Me.dtaObs.Text_Data = ""
        Me.dtaObs.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtaObs.TopPadding = 0
        Me.dtaObs.Upper_Case = False
        Me.dtaObs.Validate_on_lost_focus = True
        '
        'dtaModelos
        '
        Me.dtaModelos.Allow_Empty = True
        Me.dtaModelos.Allow_Negative = True
        Me.dtaModelos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtaModelos.BackColor = System.Drawing.SystemColors.Control
        Me.dtaModelos.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtaModelos.DataField = "MODELOS"
        Me.dtaModelos.DataTable = "GRU"
        Me.dtaModelos.Descripcion = "Modelos"
        Me.dtaModelos.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtaModelos.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtaModelos.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtaModelos.Length_Data = 32767
        Me.dtaModelos.Location = New System.Drawing.Point(3, 0)
        Me.dtaModelos.Max_Value = 0.0R
        Me.dtaModelos.MensajeIncorrectoCustom = Nothing
        Me.dtaModelos.Name = "dtaModelos"
        Me.dtaModelos.Null_on_Empty = True
        Me.dtaModelos.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtaModelos.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtaModelos.ReadOnly_Data = False
        Me.dtaModelos.Size = New System.Drawing.Size(469, 130)
        Me.dtaModelos.TabIndex = 0
        Me.dtaModelos.Text_Data = ""
        Me.dtaModelos.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtaModelos.TopPadding = 0
        Me.dtaModelos.Upper_Case = False
        Me.dtaModelos.Validate_on_lost_focus = True
        '
        'pnlPpal
        '
        Me.pnlPpal.Auto_Size = False
        Me.pnlPpal.BackColor = System.Drawing.SystemColors.Control
        Me.pnlPpal.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlPpal.ChangeDock = True
        Me.pnlPpal.Control_Resize = False
        Me.pnlPpal.Controls.Add(Me.grbCondiciones)
        Me.pnlPpal.Controls.Add(Me.grbImportes)
        Me.pnlPpal.Controls.Add(Me.pnlColor)
        Me.pnlPpal.Controls.Add(Me.dtfTipo)
        Me.pnlPpal.Controls.Add(Me.pnlFaltaFbaja)
        Me.pnlPpal.Controls.Add(Me.pnlBottomGen)
        Me.pnlPpal.Controls.Add(Me.dtfNombre)
        Me.pnlPpal.Controls.Add(Me.pnlCodigo)
        Me.pnlPpal.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlPpal.isSpace = False
        Me.pnlPpal.Location = New System.Drawing.Point(0, 0)
        Me.pnlPpal.Name = "pnlPpal"
        Me.pnlPpal.numRows = 0
        Me.pnlPpal.Padding = New System.Windows.Forms.Padding(5)
        Me.pnlPpal.Reorder = True
        Me.pnlPpal.Size = New System.Drawing.Size(472, 756)
        Me.pnlPpal.TabIndex = 11
        '
        'grbCondiciones
        '
        Me.grbCondiciones.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.grbCondiciones.Controls.Add(Me.Panel3)
        Me.grbCondiciones.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbCondiciones.HeaderText = "Requisitos Mínimos"
        Me.grbCondiciones.Location = New System.Drawing.Point(5, 306)
        Me.grbCondiciones.Name = "grbCondiciones"
        Me.grbCondiciones.numRows = 0
        Me.grbCondiciones.Padding = New System.Windows.Forms.Padding(6, 18, 6, 6)
        Me.grbCondiciones.Reorder = True
        Me.grbCondiciones.Size = New System.Drawing.Size(462, 100)
        Me.grbCondiciones.TabIndex = 6
        Me.grbCondiciones.Text = "Requisitos Mínimos"
        Me.grbCondiciones.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.grbCondiciones.ThemeName = "Windows8"
        Me.grbCondiciones.Title = "Requisitos Mínimos"
        '
        'Panel3
        '
        Me.Panel3.Auto_Size = False
        Me.Panel3.BackColor = System.Drawing.SystemColors.Control
        Me.Panel3.BorderColor = System.Drawing.SystemColors.Control
        Me.Panel3.ChangeDock = True
        Me.Panel3.Control_Resize = False
        Me.Panel3.Controls.Add(Me.dtfCarnetMin)
        Me.Panel3.Controls.Add(Me.dtfEdadMinBlq)
        Me.Panel3.Controls.Add(Me.dtfEdadMinAv)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.isSpace = False
        Me.Panel3.Location = New System.Drawing.Point(6, 18)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.numRows = 0
        Me.Panel3.Padding = New System.Windows.Forms.Padding(0, 0, 4, 0)
        Me.Panel3.Reorder = True
        Me.Panel3.Size = New System.Drawing.Size(233, 76)
        Me.Panel3.TabIndex = 0
        Me.Panel3.ThemeName = "ControlDefault"
        '
        'dtfCarnetMin
        '
        Me.dtfCarnetMin.Allow_Empty = True
        Me.dtfCarnetMin.Allow_Negative = False
        Me.dtfCarnetMin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfCarnetMin.BackColor = System.Drawing.SystemColors.Control
        Me.dtfCarnetMin.Data_Allowed = CustomControls.Datafield.List_Data.nInteger
        Me.dtfCarnetMin.DataField = "ANTIGUIMINI"
        Me.dtfCarnetMin.DataTable = "GRU"
        Me.dtfCarnetMin.Descripcion = "Antiguedad Mínima de Carnet"
        Me.dtfCarnetMin.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfCarnetMin.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfCarnetMin.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfCarnetMin.Image = Nothing
        Me.dtfCarnetMin.Label_Space = 185
        Me.dtfCarnetMin.Length_Data = 32767
        Me.dtfCarnetMin.Location = New System.Drawing.Point(0, 52)
        Me.dtfCarnetMin.Max_Value = 0.0R
        Me.dtfCarnetMin.MensajeIncorrectoCustom = Nothing
        Me.dtfCarnetMin.Name = "dtfCarnetMin"
        Me.dtfCarnetMin.Null_on_Empty = True
        Me.dtfCarnetMin.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfCarnetMin.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfCarnetMin.ReadOnly_Data = False
        Me.dtfCarnetMin.Show_Button = False
        Me.dtfCarnetMin.Size = New System.Drawing.Size(229, 26)
        Me.dtfCarnetMin.TabIndex = 2
        Me.dtfCarnetMin.Text_Data = ""
        Me.dtfCarnetMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.dtfCarnetMin.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfCarnetMin.TopPadding = 0
        Me.dtfCarnetMin.Upper_Case = True
        Me.dtfCarnetMin.Validate_on_lost_focus = True
        '
        'dtfEdadMinBlq
        '
        Me.dtfEdadMinBlq.Allow_Empty = True
        Me.dtfEdadMinBlq.Allow_Negative = False
        Me.dtfEdadMinBlq.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfEdadMinBlq.BackColor = System.Drawing.SystemColors.Control
        Me.dtfEdadMinBlq.Data_Allowed = CustomControls.Datafield.List_Data.nInteger
        Me.dtfEdadMinBlq.DataField = "EDADMINI"
        Me.dtfEdadMinBlq.DataTable = "GRU"
        Me.dtfEdadMinBlq.Descripcion = "Edad Mínima Permitida Bloqueo"
        Me.dtfEdadMinBlq.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfEdadMinBlq.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfEdadMinBlq.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfEdadMinBlq.Image = Nothing
        Me.dtfEdadMinBlq.Label_Space = 185
        Me.dtfEdadMinBlq.Length_Data = 32767
        Me.dtfEdadMinBlq.Location = New System.Drawing.Point(0, 26)
        Me.dtfEdadMinBlq.Max_Value = 0.0R
        Me.dtfEdadMinBlq.MensajeIncorrectoCustom = Nothing
        Me.dtfEdadMinBlq.Name = "dtfEdadMinBlq"
        Me.dtfEdadMinBlq.Null_on_Empty = True
        Me.dtfEdadMinBlq.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfEdadMinBlq.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfEdadMinBlq.ReadOnly_Data = False
        Me.dtfEdadMinBlq.Show_Button = False
        Me.dtfEdadMinBlq.Size = New System.Drawing.Size(229, 26)
        Me.dtfEdadMinBlq.TabIndex = 1
        Me.dtfEdadMinBlq.Text_Data = ""
        Me.dtfEdadMinBlq.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.dtfEdadMinBlq.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfEdadMinBlq.TopPadding = 0
        Me.dtfEdadMinBlq.Upper_Case = True
        Me.dtfEdadMinBlq.Validate_on_lost_focus = True
        '
        'dtfEdadMinAv
        '
        Me.dtfEdadMinAv.Allow_Empty = True
        Me.dtfEdadMinAv.Allow_Negative = False
        Me.dtfEdadMinAv.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfEdadMinAv.BackColor = System.Drawing.SystemColors.Control
        Me.dtfEdadMinAv.Data_Allowed = CustomControls.Datafield.List_Data.nInteger
        Me.dtfEdadMinAv.DataField = "EDADMINAVISO"
        Me.dtfEdadMinAv.DataTable = "GRU"
        Me.dtfEdadMinAv.Descripcion = "Edad Mínima Permitida Aviso"
        Me.dtfEdadMinAv.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfEdadMinAv.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfEdadMinAv.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfEdadMinAv.Image = Nothing
        Me.dtfEdadMinAv.Label_Space = 185
        Me.dtfEdadMinAv.Length_Data = 32767
        Me.dtfEdadMinAv.Location = New System.Drawing.Point(0, 0)
        Me.dtfEdadMinAv.Max_Value = 0.0R
        Me.dtfEdadMinAv.MensajeIncorrectoCustom = Nothing
        Me.dtfEdadMinAv.Name = "dtfEdadMinAv"
        Me.dtfEdadMinAv.Null_on_Empty = True
        Me.dtfEdadMinAv.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfEdadMinAv.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfEdadMinAv.ReadOnly_Data = False
        Me.dtfEdadMinAv.Show_Button = False
        Me.dtfEdadMinAv.Size = New System.Drawing.Size(229, 26)
        Me.dtfEdadMinAv.TabIndex = 0
        Me.dtfEdadMinAv.Text_Data = ""
        Me.dtfEdadMinAv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.dtfEdadMinAv.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfEdadMinAv.TopPadding = 0
        Me.dtfEdadMinAv.Upper_Case = True
        Me.dtfEdadMinAv.Validate_on_lost_focus = True
        '
        'grbImportes
        '
        Me.grbImportes.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.grbImportes.Controls.Add(Me.pnConceptos2)
        Me.grbImportes.Controls.Add(Me.pnConceptos)
        Me.grbImportes.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbImportes.HeaderText = "Importes por Defecto"
        Me.grbImportes.Location = New System.Drawing.Point(5, 139)
        Me.grbImportes.Name = "grbImportes"
        Me.grbImportes.numRows = 0
        Me.grbImportes.Padding = New System.Windows.Forms.Padding(6, 18, 6, 6)
        Me.grbImportes.Reorder = True
        Me.grbImportes.Size = New System.Drawing.Size(462, 167)
        Me.grbImportes.TabIndex = 5
        Me.grbImportes.Text = "Importes por Defecto"
        Me.grbImportes.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.grbImportes.ThemeName = "Windows8"
        Me.grbImportes.Title = "Importes por Defecto"
        '
        'pnConceptos2
        '
        Me.pnConceptos2.Auto_Size = False
        Me.pnConceptos2.BackColor = System.Drawing.SystemColors.Control
        Me.pnConceptos2.BorderColor = System.Drawing.SystemColors.Control
        Me.pnConceptos2.ChangeDock = True
        Me.pnConceptos2.Control_Resize = False
        Me.pnConceptos2.Controls.Add(Me.Panel1)
        Me.pnConceptos2.Controls.Add(Me.dtfFranq)
        Me.pnConceptos2.Controls.Add(Me.pnPlus)
        Me.pnConceptos2.isSpace = False
        Me.pnConceptos2.Location = New System.Drawing.Point(144, 18)
        Me.pnConceptos2.Name = "pnConceptos2"
        Me.pnConceptos2.numRows = 0
        Me.pnConceptos2.Reorder = True
        Me.pnConceptos2.Size = New System.Drawing.Size(160, 143)
        Me.pnConceptos2.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.Auto_Size = False
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.BorderColor = System.Drawing.SystemColors.Control
        Me.Panel1.ChangeDock = True
        Me.Panel1.Control_Resize = False
        Me.Panel1.Controls.Add(Me.dtfPrecCesion)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.isSpace = False
        Me.Panel1.Location = New System.Drawing.Point(0, 52)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.numRows = 0
        Me.Panel1.Reorder = True
        Me.Panel1.Size = New System.Drawing.Size(160, 26)
        Me.Panel1.TabIndex = 2
        '
        'dtfPrecCesion
        '
        Me.dtfPrecCesion.Allow_Empty = True
        Me.dtfPrecCesion.Allow_Negative = False
        Me.dtfPrecCesion.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfPrecCesion.BackColor = System.Drawing.SystemColors.Control
        Me.dtfPrecCesion.Data_Allowed = CustomControls.Datafield.List_Data.nDouble
        Me.dtfPrecCesion.DataField = "CESION"
        Me.dtfPrecCesion.DataTable = "GRU"
        Me.dtfPrecCesion.Descripcion = "Prec.Cesión"
        Me.dtfPrecCesion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtfPrecCesion.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfPrecCesion.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfPrecCesion.Image = Nothing
        Me.dtfPrecCesion.Label_Space = 75
        Me.dtfPrecCesion.Length_Data = 32767
        Me.dtfPrecCesion.Location = New System.Drawing.Point(0, 0)
        Me.dtfPrecCesion.Max_Value = 0.0R
        Me.dtfPrecCesion.MensajeIncorrectoCustom = Nothing
        Me.dtfPrecCesion.Name = "dtfPrecCesion"
        Me.dtfPrecCesion.Null_on_Empty = True
        Me.dtfPrecCesion.Padding = New System.Windows.Forms.Padding(0, 0, 92, 3)
        Me.dtfPrecCesion.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfPrecCesion.ReadOnly_Data = False
        Me.dtfPrecCesion.Show_Button = False
        Me.dtfPrecCesion.Size = New System.Drawing.Size(133, 26)
        Me.dtfPrecCesion.TabIndex = 0
        Me.dtfPrecCesion.Text_Data = ""
        Me.dtfPrecCesion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.dtfPrecCesion.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfPrecCesion.TopPadding = 0
        Me.dtfPrecCesion.Upper_Case = True
        Me.dtfPrecCesion.Validate_on_lost_focus = True
        '
        'Panel2
        '
        Me.Panel2.Auto_Size = False
        Me.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.Panel2.BorderColor = System.Drawing.SystemColors.Control
        Me.Panel2.ChangeDock = True
        Me.Panel2.Control_Resize = False
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.isSpace = False
        Me.Panel2.Location = New System.Drawing.Point(133, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.numRows = 0
        Me.Panel2.Reorder = True
        Me.Panel2.Size = New System.Drawing.Size(27, 26)
        Me.Panel2.TabIndex = 1
        '
        'dtfFranq
        '
        Me.dtfFranq.Allow_Empty = True
        Me.dtfFranq.Allow_Negative = False
        Me.dtfFranq.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfFranq.BackColor = System.Drawing.SystemColors.Control
        Me.dtfFranq.Data_Allowed = CustomControls.Datafield.List_Data.nDouble
        Me.dtfFranq.DataField = "FRANQUICIA"
        Me.dtfFranq.DataTable = "GRU"
        Me.dtfFranq.Descripcion = "Franquicia"
        Me.dtfFranq.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfFranq.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfFranq.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfFranq.Image = Nothing
        Me.dtfFranq.Label_Space = 75
        Me.dtfFranq.Length_Data = 32767
        Me.dtfFranq.Location = New System.Drawing.Point(0, 26)
        Me.dtfFranq.Max_Value = 0.0R
        Me.dtfFranq.MensajeIncorrectoCustom = Nothing
        Me.dtfFranq.Name = "dtfFranq"
        Me.dtfFranq.Null_on_Empty = True
        Me.dtfFranq.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfFranq.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfFranq.ReadOnly_Data = False
        Me.dtfFranq.Show_Button = True
        Me.dtfFranq.Size = New System.Drawing.Size(160, 26)
        Me.dtfFranq.TabIndex = 1
        Me.dtfFranq.Text_Data = ""
        Me.dtfFranq.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.dtfFranq.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfFranq.TopPadding = 0
        Me.dtfFranq.Upper_Case = True
        Me.dtfFranq.Validate_on_lost_focus = True
        '
        'pnPlus
        '
        Me.pnPlus.Auto_Size = False
        Me.pnPlus.BackColor = System.Drawing.SystemColors.Control
        Me.pnPlus.BorderColor = System.Drawing.SystemColors.Control
        Me.pnPlus.ChangeDock = True
        Me.pnPlus.Control_Resize = False
        Me.pnPlus.Controls.Add(Me.dtfPlus)
        Me.pnPlus.Controls.Add(Me.pnCiego)
        Me.pnPlus.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnPlus.isSpace = False
        Me.pnPlus.Location = New System.Drawing.Point(0, 0)
        Me.pnPlus.Name = "pnPlus"
        Me.pnPlus.numRows = 0
        Me.pnPlus.Reorder = True
        Me.pnPlus.Size = New System.Drawing.Size(160, 26)
        Me.pnPlus.TabIndex = 0
        '
        'dtfPlus
        '
        Me.dtfPlus.Allow_Empty = True
        Me.dtfPlus.Allow_Negative = False
        Me.dtfPlus.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfPlus.BackColor = System.Drawing.SystemColors.Control
        Me.dtfPlus.Data_Allowed = CustomControls.Datafield.List_Data.nDouble
        Me.dtfPlus.DataField = "SCDW"
        Me.dtfPlus.DataTable = "GRU"
        Me.dtfPlus.Descripcion = "Plus"
        Me.dtfPlus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtfPlus.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfPlus.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfPlus.Image = Nothing
        Me.dtfPlus.Label_Space = 75
        Me.dtfPlus.Length_Data = 32767
        Me.dtfPlus.Location = New System.Drawing.Point(0, 0)
        Me.dtfPlus.Max_Value = 0.0R
        Me.dtfPlus.MensajeIncorrectoCustom = Nothing
        Me.dtfPlus.Name = "dtfPlus"
        Me.dtfPlus.Null_on_Empty = True
        Me.dtfPlus.Padding = New System.Windows.Forms.Padding(0, 0, 92, 3)
        Me.dtfPlus.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfPlus.ReadOnly_Data = False
        Me.dtfPlus.Show_Button = False
        Me.dtfPlus.Size = New System.Drawing.Size(133, 26)
        Me.dtfPlus.TabIndex = 0
        Me.dtfPlus.Text_Data = ""
        Me.dtfPlus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.dtfPlus.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfPlus.TopPadding = 0
        Me.dtfPlus.Upper_Case = True
        Me.dtfPlus.Validate_on_lost_focus = True
        '
        'pnCiego
        '
        Me.pnCiego.Auto_Size = False
        Me.pnCiego.BackColor = System.Drawing.SystemColors.Control
        Me.pnCiego.BorderColor = System.Drawing.SystemColors.Control
        Me.pnCiego.ChangeDock = True
        Me.pnCiego.Control_Resize = False
        Me.pnCiego.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnCiego.isSpace = False
        Me.pnCiego.Location = New System.Drawing.Point(133, 0)
        Me.pnCiego.Name = "pnCiego"
        Me.pnCiego.numRows = 0
        Me.pnCiego.Reorder = True
        Me.pnCiego.Size = New System.Drawing.Size(27, 26)
        Me.pnCiego.TabIndex = 1
        '
        'pnConceptos
        '
        Me.pnConceptos.Auto_Size = False
        Me.pnConceptos.BackColor = System.Drawing.SystemColors.Control
        Me.pnConceptos.BorderColor = System.Drawing.SystemColors.Control
        Me.pnConceptos.ChangeDock = True
        Me.pnConceptos.Control_Resize = False
        Me.pnConceptos.Controls.Add(Me.dtfPai)
        Me.pnConceptos.Controls.Add(Me.dtfTp)
        Me.pnConceptos.Controls.Add(Me.dtfCdw)
        Me.pnConceptos.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnConceptos.isSpace = False
        Me.pnConceptos.Location = New System.Drawing.Point(6, 18)
        Me.pnConceptos.Name = "pnConceptos"
        Me.pnConceptos.numRows = 0
        Me.pnConceptos.Padding = New System.Windows.Forms.Padding(0, 0, 4, 0)
        Me.pnConceptos.Reorder = True
        Me.pnConceptos.Size = New System.Drawing.Size(138, 143)
        Me.pnConceptos.TabIndex = 0
        Me.pnConceptos.ThemeName = "ControlDefault"
        '
        'dtfPai
        '
        Me.dtfPai.Allow_Empty = True
        Me.dtfPai.Allow_Negative = False
        Me.dtfPai.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfPai.BackColor = System.Drawing.SystemColors.Control
        Me.dtfPai.Data_Allowed = CustomControls.Datafield.List_Data.nDouble
        Me.dtfPai.DataField = "PAI"
        Me.dtfPai.DataTable = "GRU"
        Me.dtfPai.Descripcion = "Pai"
        Me.dtfPai.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfPai.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfPai.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfPai.Image = Nothing
        Me.dtfPai.Label_Space = 75
        Me.dtfPai.Length_Data = 32767
        Me.dtfPai.Location = New System.Drawing.Point(0, 52)
        Me.dtfPai.Max_Value = 0.0R
        Me.dtfPai.MensajeIncorrectoCustom = Nothing
        Me.dtfPai.Name = "dtfPai"
        Me.dtfPai.Null_on_Empty = True
        Me.dtfPai.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfPai.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfPai.ReadOnly_Data = False
        Me.dtfPai.Show_Button = False
        Me.dtfPai.Size = New System.Drawing.Size(134, 26)
        Me.dtfPai.TabIndex = 2
        Me.dtfPai.Text_Data = ""
        Me.dtfPai.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.dtfPai.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfPai.TopPadding = 0
        Me.dtfPai.Upper_Case = True
        Me.dtfPai.Validate_on_lost_focus = True
        '
        'dtfTp
        '
        Me.dtfTp.Allow_Empty = True
        Me.dtfTp.Allow_Negative = False
        Me.dtfTp.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfTp.BackColor = System.Drawing.SystemColors.Control
        Me.dtfTp.Data_Allowed = CustomControls.Datafield.List_Data.nDouble
        Me.dtfTp.DataField = "TP"
        Me.dtfTp.DataTable = "GRU"
        Me.dtfTp.Descripcion = "Tp"
        Me.dtfTp.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfTp.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfTp.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfTp.Image = Nothing
        Me.dtfTp.Label_Space = 75
        Me.dtfTp.Length_Data = 32767
        Me.dtfTp.Location = New System.Drawing.Point(0, 26)
        Me.dtfTp.Max_Value = 0.0R
        Me.dtfTp.MensajeIncorrectoCustom = Nothing
        Me.dtfTp.Name = "dtfTp"
        Me.dtfTp.Null_on_Empty = True
        Me.dtfTp.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfTp.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfTp.ReadOnly_Data = False
        Me.dtfTp.Show_Button = False
        Me.dtfTp.Size = New System.Drawing.Size(134, 26)
        Me.dtfTp.TabIndex = 1
        Me.dtfTp.Text_Data = ""
        Me.dtfTp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.dtfTp.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfTp.TopPadding = 0
        Me.dtfTp.Upper_Case = True
        Me.dtfTp.Validate_on_lost_focus = True
        '
        'dtfCdw
        '
        Me.dtfCdw.Allow_Empty = True
        Me.dtfCdw.Allow_Negative = False
        Me.dtfCdw.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfCdw.BackColor = System.Drawing.SystemColors.Control
        Me.dtfCdw.Data_Allowed = CustomControls.Datafield.List_Data.nDouble
        Me.dtfCdw.DataField = "CDW"
        Me.dtfCdw.DataTable = "GRU"
        Me.dtfCdw.Descripcion = "Cdw"
        Me.dtfCdw.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfCdw.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfCdw.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfCdw.Image = Nothing
        Me.dtfCdw.Label_Space = 75
        Me.dtfCdw.Length_Data = 32767
        Me.dtfCdw.Location = New System.Drawing.Point(0, 0)
        Me.dtfCdw.Max_Value = 0.0R
        Me.dtfCdw.MensajeIncorrectoCustom = Nothing
        Me.dtfCdw.Name = "dtfCdw"
        Me.dtfCdw.Null_on_Empty = True
        Me.dtfCdw.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfCdw.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfCdw.ReadOnly_Data = False
        Me.dtfCdw.Show_Button = False
        Me.dtfCdw.Size = New System.Drawing.Size(134, 26)
        Me.dtfCdw.TabIndex = 0
        Me.dtfCdw.Text_Data = ""
        Me.dtfCdw.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.dtfCdw.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfCdw.TopPadding = 0
        Me.dtfCdw.Upper_Case = True
        Me.dtfCdw.Validate_on_lost_focus = True
        '
        'pnlColor
        '
        Me.pnlColor.Auto_Size = False
        Me.pnlColor.BackColor = System.Drawing.SystemColors.Control
        Me.pnlColor.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlColor.ChangeDock = True
        Me.pnlColor.Control_Resize = False
        Me.pnlColor.Controls.Add(Me.dtfColor)
        Me.pnlColor.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlColor.isSpace = False
        Me.pnlColor.Location = New System.Drawing.Point(5, 113)
        Me.pnlColor.Name = "pnlColor"
        Me.pnlColor.numRows = 0
        Me.pnlColor.Reorder = True
        Me.pnlColor.Size = New System.Drawing.Size(462, 26)
        Me.pnlColor.TabIndex = 4
        '
        'dtfColor
        '
        Me.dtfColor.Allow_Empty = True
        Me.dtfColor.Allow_Negative = True
        Me.dtfColor.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfColor.BackColor = System.Drawing.SystemColors.Control
        Me.dtfColor.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfColor.DataField = "COLORFONDO"
        Me.dtfColor.DataTable = "GRU"
        Me.dtfColor.Descripcion = "Color"
        Me.dtfColor.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfColor.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfColor.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfColor.Image = Nothing
        Me.dtfColor.Label_Space = 75
        Me.dtfColor.Length_Data = 32767
        Me.dtfColor.Location = New System.Drawing.Point(0, 0)
        Me.dtfColor.Max_Value = 0.0R
        Me.dtfColor.MensajeIncorrectoCustom = Nothing
        Me.dtfColor.Name = "dtfColor"
        Me.dtfColor.Null_on_Empty = True
        Me.dtfColor.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfColor.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfColor.ReadOnly_Data = False
        Me.dtfColor.Show_Button = True
        Me.dtfColor.Size = New System.Drawing.Size(166, 26)
        Me.dtfColor.TabIndex = 0
        Me.dtfColor.Text_Data = ""
        Me.dtfColor.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfColor.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfColor.TopPadding = 0
        Me.dtfColor.Upper_Case = False
        Me.dtfColor.Validate_on_lost_focus = True
        '
        'dtfTipo
        '
        Me.dtfTipo.Allow_Empty = True
        Me.dtfTipo.Allow_Negative = True
        Me.dtfTipo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfTipo.BackColor = System.Drawing.SystemColors.Control
        Me.dtfTipo.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfTipo.DataField = "CATEGO"
        Me.dtfTipo.DataTable = "GRU"
        Me.dtfTipo.Desc_Datafield = "NOMBRE"
        Me.dtfTipo.Desc_DBPK = "CODIGO"
        Me.dtfTipo.Desc_DBTable = "CATEGO"
        Me.dtfTipo.Desc_Where = Nothing
        Me.dtfTipo.Descripcion = "Tipo"
        Me.dtfTipo.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfTipo.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfTipo.ExtraSQL = ""
        Me.dtfTipo.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfTipo.Formulario = Nothing
        Me.dtfTipo.Label_Space = 75
        Me.dtfTipo.Length_Data = 32767
        Me.dtfTipo.Location = New System.Drawing.Point(5, 87)
        Me.dtfTipo.Lupa = Nothing
        Me.dtfTipo.Max_Value = 0.0R
        Me.dtfTipo.MensajeIncorrectoCustom = Nothing
        Me.dtfTipo.Name = "dtfTipo"
        Me.dtfTipo.Null_on_Empty = True
        Me.dtfTipo.OpenForm = Nothing
        Me.dtfTipo.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfTipo.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfTipo.Query_on_Text_Changed = True
        Me.dtfTipo.ReadOnly_Data = False
        Me.dtfTipo.ShowButton = True
        Me.dtfTipo.Size = New System.Drawing.Size(462, 26)
        Me.dtfTipo.TabIndex = 3
        Me.dtfTipo.Text_Data = ""
        Me.dtfTipo.Text_Width = 90
        Me.dtfTipo.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfTipo.TopPadding = 0
        Me.dtfTipo.Upper_Case = False
        Me.dtfTipo.Validate_on_lost_focus = True
        '
        'pnlFaltaFbaja
        '
        Me.pnlFaltaFbaja.Auto_Size = False
        Me.pnlFaltaFbaja.BackColor = System.Drawing.SystemColors.Control
        Me.pnlFaltaFbaja.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlFaltaFbaja.ChangeDock = True
        Me.pnlFaltaFbaja.Control_Resize = False
        Me.pnlFaltaFbaja.Controls.Add(Me.dtdFBaja)
        Me.pnlFaltaFbaja.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFaltaFbaja.isSpace = False
        Me.pnlFaltaFbaja.Location = New System.Drawing.Point(5, 61)
        Me.pnlFaltaFbaja.Name = "pnlFaltaFbaja"
        Me.pnlFaltaFbaja.numRows = 1
        Me.pnlFaltaFbaja.Reorder = True
        Me.pnlFaltaFbaja.Size = New System.Drawing.Size(462, 26)
        Me.pnlFaltaFbaja.TabIndex = 2
        '
        'dtdFBaja
        '
        Me.dtdFBaja.Allow_Empty = True
        Me.dtdFBaja.DataField = "FBAJA_GH"
        Me.dtdFBaja.DataTable = "GRU"
        Me.dtdFBaja.Default_Value = Nothing
        Me.dtdFBaja.Descripcion = "Fecha Baja"
        Me.dtdFBaja.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtdFBaja.Label_Space = 75
        Me.dtdFBaja.Location = New System.Drawing.Point(0, 0)
        Me.dtdFBaja.Max_Value = Nothing
        Me.dtdFBaja.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdFBaja.MensajeIncorrectoCustom = Nothing
        Me.dtdFBaja.Min_Value = Nothing
        Me.dtdFBaja.MinDate = New Date(CType(0, Long))
        Me.dtdFBaja.MinimumSize = New System.Drawing.Size(165, 26)
        Me.dtdFBaja.Name = "dtdFBaja"
        Me.dtdFBaja.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdFBaja.ReadOnly_Data = False
        Me.dtdFBaja.Size = New System.Drawing.Size(166, 26)
        Me.dtdFBaja.TabIndex = 0
        Me.dtdFBaja.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdFBaja.Validate_on_lost_focus = True
        Me.dtdFBaja.Value_Data = Nothing
        '
        'pnlBottomGen
        '
        Me.pnlBottomGen.Auto_Size = False
        Me.pnlBottomGen.BackColor = System.Drawing.SystemColors.Control
        Me.pnlBottomGen.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlBottomGen.ChangeDock = True
        Me.pnlBottomGen.Control_Resize = False
        Me.pnlBottomGen.Controls.Add(Me.dtlUltmodi)
        Me.pnlBottomGen.Controls.Add(Me.dtlUsumodi)
        Me.pnlBottomGen.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBottomGen.isSpace = False
        Me.pnlBottomGen.Location = New System.Drawing.Point(5, 725)
        Me.pnlBottomGen.Name = "pnlBottomGen"
        Me.pnlBottomGen.numRows = 1
        Me.pnlBottomGen.Reorder = True
        Me.pnlBottomGen.Size = New System.Drawing.Size(462, 26)
        Me.pnlBottomGen.TabIndex = 7
        '
        'dtlUltmodi
        '
        Me.dtlUltmodi.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtlUltmodi.AutoSize = False
        Me.dtlUltmodi.BorderVisible = True
        Me.dtlUltmodi.DataField = "ULTMODI"
        Me.dtlUltmodi.DataTable = "GRU"
        Me.dtlUltmodi.Descripcion = ""
        Me.dtlUltmodi.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtlUltmodi.Fromat = CustomControls.DataLabel.fotmatType.ultmodi
        Me.dtlUltmodi.Location = New System.Drawing.Point(330, 6)
        Me.dtlUltmodi.Name = "dtlUltmodi"
        Me.dtlUltmodi.Size = New System.Drawing.Size(132, 17)
        Me.dtlUltmodi.TabIndex = 1
        Me.dtlUltmodi.TextAlignment = System.Drawing.ContentAlignment.TopCenter
        '
        'dtlUsumodi
        '
        Me.dtlUsumodi.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtlUsumodi.AutoSize = False
        Me.dtlUsumodi.BorderVisible = True
        Me.dtlUsumodi.DataField = "USUARIO"
        Me.dtlUsumodi.DataTable = "GRU"
        Me.dtlUsumodi.Descripcion = ""
        Me.dtlUsumodi.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtlUsumodi.Fromat = CustomControls.DataLabel.fotmatType.plain
        Me.dtlUsumodi.Location = New System.Drawing.Point(286, 6)
        Me.dtlUsumodi.Name = "dtlUsumodi"
        Me.dtlUsumodi.Size = New System.Drawing.Size(38, 17)
        Me.dtlUsumodi.TabIndex = 0
        Me.dtlUsumodi.TextAlignment = System.Drawing.ContentAlignment.TopCenter
        '
        'dtfNombre
        '
        Me.dtfNombre.Allow_Empty = False
        Me.dtfNombre.Allow_Negative = True
        Me.dtfNombre.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfNombre.BackColor = System.Drawing.SystemColors.Control
        Me.dtfNombre.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfNombre.DataField = "NOMBRE"
        Me.dtfNombre.DataTable = "GRU"
        Me.dtfNombre.Descripcion = "Nombre"
        Me.dtfNombre.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfNombre.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfNombre.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfNombre.Image = Nothing
        Me.dtfNombre.Label_Space = 75
        Me.dtfNombre.Length_Data = 32767
        Me.dtfNombre.Location = New System.Drawing.Point(5, 35)
        Me.dtfNombre.Max_Value = 0.0R
        Me.dtfNombre.MensajeIncorrectoCustom = Nothing
        Me.dtfNombre.Name = "dtfNombre"
        Me.dtfNombre.Null_on_Empty = True
        Me.dtfNombre.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfNombre.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfNombre.ReadOnly_Data = False
        Me.dtfNombre.Show_Button = False
        Me.dtfNombre.Size = New System.Drawing.Size(462, 26)
        Me.dtfNombre.TabIndex = 1
        Me.dtfNombre.Text_Data = ""
        Me.dtfNombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfNombre.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfNombre.TopPadding = 0
        Me.dtfNombre.Upper_Case = False
        Me.dtfNombre.Validate_on_lost_focus = True
        '
        'pnlCodigo
        '
        Me.pnlCodigo.Auto_Size = False
        Me.pnlCodigo.BackColor = System.Drawing.SystemColors.Control
        Me.pnlCodigo.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlCodigo.ChangeDock = True
        Me.pnlCodigo.Control_Resize = False
        Me.pnlCodigo.Controls.Add(Me.dtfAcriss)
        Me.pnlCodigo.Controls.Add(Me.dtfCodigo)
        Me.pnlCodigo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCodigo.isSpace = False
        Me.pnlCodigo.Location = New System.Drawing.Point(5, 5)
        Me.pnlCodigo.Name = "pnlCodigo"
        Me.pnlCodigo.numRows = 0
        Me.pnlCodigo.Padding = New System.Windows.Forms.Padding(0, 5, 5, 5)
        Me.pnlCodigo.Reorder = True
        Me.pnlCodigo.Size = New System.Drawing.Size(462, 30)
        Me.pnlCodigo.TabIndex = 0
        '
        'dtfAcriss
        '
        Me.dtfAcriss.Allow_Empty = False
        Me.dtfAcriss.Allow_Negative = True
        Me.dtfAcriss.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtfAcriss.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfAcriss.BackColor = System.Drawing.SystemColors.Control
        Me.dtfAcriss.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfAcriss.DataField = "CRS"
        Me.dtfAcriss.DataTable = "GRU"
        Me.dtfAcriss.Descripcion = "Acriss"
        Me.dtfAcriss.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfAcriss.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfAcriss.Image = Nothing
        Me.dtfAcriss.Label_Space = 75
        Me.dtfAcriss.Length_Data = 32767
        Me.dtfAcriss.Location = New System.Drawing.Point(299, 5)
        Me.dtfAcriss.Max_Value = 0.0R
        Me.dtfAcriss.MensajeIncorrectoCustom = Nothing
        Me.dtfAcriss.Name = "dtfAcriss"
        Me.dtfAcriss.Null_on_Empty = True
        Me.dtfAcriss.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfAcriss.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfAcriss.ReadOnly_Data = False
        Me.dtfAcriss.Show_Button = False
        Me.dtfAcriss.Size = New System.Drawing.Size(163, 20)
        Me.dtfAcriss.TabIndex = 1
        Me.dtfAcriss.Text_Data = ""
        Me.dtfAcriss.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfAcriss.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfAcriss.TopPadding = 0
        Me.dtfAcriss.Upper_Case = True
        Me.dtfAcriss.Validate_on_lost_focus = True
        '
        'dtfCodigo
        '
        Me.dtfCodigo.Allow_Empty = False
        Me.dtfCodigo.Allow_Negative = True
        Me.dtfCodigo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfCodigo.BackColor = System.Drawing.SystemColors.Control
        Me.dtfCodigo.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfCodigo.DataField = "CODIGO"
        Me.dtfCodigo.DataTable = "GRU"
        Me.dtfCodigo.Descripcion = "Código"
        Me.dtfCodigo.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfCodigo.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfCodigo.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfCodigo.Image = Nothing
        Me.dtfCodigo.Label_Space = 75
        Me.dtfCodigo.Length_Data = 32767
        Me.dtfCodigo.Location = New System.Drawing.Point(0, 5)
        Me.dtfCodigo.Max_Value = 0.0R
        Me.dtfCodigo.MensajeIncorrectoCustom = Nothing
        Me.dtfCodigo.Name = "dtfCodigo"
        Me.dtfCodigo.Null_on_Empty = True
        Me.dtfCodigo.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfCodigo.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfCodigo.ReadOnly_Data = True
        Me.dtfCodigo.Show_Button = False
        Me.dtfCodigo.Size = New System.Drawing.Size(160, 20)
        Me.dtfCodigo.TabIndex = 0
        Me.dtfCodigo.TabStop = False
        Me.dtfCodigo.Text_Data = ""
        Me.dtfCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfCodigo.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfCodigo.TopPadding = 0
        Me.dtfCodigo.Upper_Case = True
        Me.dtfCodigo.Validate_on_lost_focus = True
        '
        'pvpFoto
        '
        Me.pvpFoto.ItemSize = New System.Drawing.SizeF(51.0!, 29.0!)
        Me.pvpFoto.Location = New System.Drawing.Point(129, 5)
        Me.pvpFoto.Name = "pvpFoto"
        Me.pvpFoto.Size = New System.Drawing.Size(947, 756)
        Me.pvpFoto.Text = "Foto"
        '
        'GruposVehiculos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1081, 951)
        Me.Name = "GruposVehiculos"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "GruposVehiculos"
        CType(Me.pnlBlock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pvwBase, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pvwBase.ResumeLayout(False)
        CType(Me.stbBase, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pvpGeneral.ResumeLayout(False)
        CType(Me.pnlSec, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSec.ResumeLayout(False)
        CType(Me.pnlPpal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPpal.ResumeLayout(False)
        CType(Me.grbCondiciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbCondiciones.ResumeLayout(False)
        CType(Me.Panel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        CType(Me.grbImportes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbImportes.ResumeLayout(False)
        CType(Me.pnConceptos2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnConceptos2.ResumeLayout(False)
        CType(Me.Panel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.Panel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnPlus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnPlus.ResumeLayout(False)
        CType(Me.pnCiego, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnConceptos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnConceptos.ResumeLayout(False)
        CType(Me.pnlColor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlColor.ResumeLayout(False)
        CType(Me.pnlFaltaFbaja, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFaltaFbaja.ResumeLayout(False)
        CType(Me.pnlBottomGen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBottomGen.ResumeLayout(False)
        CType(Me.dtlUltmodi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtlUsumodi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlCodigo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCodigo.ResumeLayout(False)
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pvpGeneral As CustomControls.PageViewPage
    Friend WithEvents pnlPpal As CustomControls.Panel
    Friend WithEvents pnlBottomGen As CustomControls.Panel
    Friend WithEvents dtlUltmodi As CustomControls.DataLabel
    Friend WithEvents dtlUsumodi As CustomControls.DataLabel
    Friend WithEvents dtfNombre As CustomControls.DatafieldLabel
    Friend WithEvents pnlCodigo As CustomControls.Panel
    Friend WithEvents dtfCodigo As CustomControls.DatafieldLabel
    Friend WithEvents dtfAcriss As CustomControls.DatafieldLabel
    Friend WithEvents pnlFaltaFbaja As CustomControls.Panel
    Friend WithEvents dtdFBaja As CustomControls.DataDateLabel
    Friend WithEvents dtfTipo As CustomControls.DualDatafieldLabel
    Friend WithEvents grbCondiciones As CustomControls.GroupBox
    Friend WithEvents Panel3 As CustomControls.Panel
    Friend WithEvents dtfCarnetMin As CustomControls.DatafieldLabel
    Friend WithEvents dtfEdadMinBlq As CustomControls.DatafieldLabel
    Friend WithEvents dtfEdadMinAv As CustomControls.DatafieldLabel
    Friend WithEvents grbImportes As CustomControls.GroupBox
    Friend WithEvents pnConceptos2 As CustomControls.Panel
    Friend WithEvents Panel1 As CustomControls.Panel
    Friend WithEvents dtfPrecCesion As CustomControls.DatafieldLabel
    Friend WithEvents Panel2 As CustomControls.Panel
    Friend WithEvents dtfFranq As CustomControls.DatafieldLabel
    Friend WithEvents pnPlus As CustomControls.Panel
    Friend WithEvents dtfPlus As CustomControls.DatafieldLabel
    Friend WithEvents pnCiego As CustomControls.Panel
    Friend WithEvents pnConceptos As CustomControls.Panel
    Friend WithEvents dtfPai As CustomControls.DatafieldLabel
    Friend WithEvents dtfTp As CustomControls.DatafieldLabel
    Friend WithEvents dtfCdw As CustomControls.DatafieldLabel
    Friend WithEvents pnlColor As CustomControls.Panel
    Friend WithEvents dtfColor As CustomControls.DataFieldLabelColor
    Friend WithEvents pnlSec As CustomControls.Panel
    Friend WithEvents dtaObs As CustomControls.DataAreaLabel
    Friend WithEvents dtaModelos As CustomControls.DataAreaLabel
    Friend WithEvents pvpFoto As CustomControls.PageViewPage
End Class
