<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FichaTecnicaVehiculo
    Inherits Karve.frm.Auxiliares.FichaTecnica

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
        Me.dtfNombre = New CustomControls.DatafieldLabel()
        CType(Me.pnPpalR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlLeft, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlLeft.SuspendLayout()
        CType(Me.pnPpalL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnPpalL.SuspendLayout()
        CType(Me.pnlRight, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlRight.SuspendLayout()
        CType(Me.pnlPpal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPpal.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnPpalR
        '
        Me.pnPpalR.Size = New System.Drawing.Size(289, 59)
        '
        'pnlLeft
        '
        Me.pnlLeft.Location = New System.Drawing.Point(0, 61)
        Me.pnlLeft.Size = New System.Drawing.Size(444, 468)
        '
        'pnPpalL
        '
        Me.pnPpalL.Controls.Add(Me.dtfNombre)
        Me.pnPpalL.Size = New System.Drawing.Size(444, 59)
        Me.pnPpalL.Controls.SetChildIndex(Me.dtfNombre, 0)
        Me.pnPpalL.Controls.SetChildIndex(Me.dtfClasificaVehi, 0)
        '
        'dtfClasificaVehi
        '
        Me.dtfClasificaVehi.Location = New System.Drawing.Point(0, 26)
        '
        'pnlRight
        '
        Me.pnlRight.Location = New System.Drawing.Point(450, 61)
        Me.pnlRight.Size = New System.Drawing.Size(283, 468)
        '
        'pnlPpal
        '
        Me.pnlPpal.Size = New System.Drawing.Size(733, 61)
        '
        'dtfVariante
        '
        Me.dtfVariante.TabIndex = 2
        '
        'dtfTipo
        '
        Me.dtfTipo.TabIndex = 1
        '
        'dtfMarca
        '
        Me.dtfMarca.TabIndex = 0
        '
        'dtfTara
        '
        Me.dtfTara.TabIndex = 4
        '
        'dtfComercial
        '
        Me.dtfComercial.TabIndex = 3
        '
        'dtfMMA2
        '
        Me.dtfMMA2.TabIndex = 7
        '
        'dtfMMA1
        '
        Me.dtfMMA1.TabIndex = 6
        '
        'dtfMMA
        '
        Me.dtfMMA.TabIndex = 5
        '
        'dtfMMA4
        '
        Me.dtfMMA4.TabIndex = 9
        '
        'dtfMMA3
        '
        Me.dtfMMA3.TabIndex = 8
        '
        'dtfBodega
        '
        Me.dtfBodega.TabIndex = 13
        '
        'dtfAsientos
        '
        Me.dtfAsientos.TabIndex = 12
        '
        'dtfNeumaticos
        '
        Me.dtfNeumaticos.TabIndex = 11
        '
        'dtfMMR
        '
        Me.dtfMMR.TabIndex = 10
        '
        'dtfDistanciaE1
        '
        Me.dtfDistanciaE1.TabIndex = 6
        '
        'dtfVoladizo
        '
        Me.dtfVoladizo.TabIndex = 5
        '
        'dtfLongitud
        '
        Me.dtfLongitud.TabIndex = 4
        '
        'dtfVias
        '
        Me.dtfVias.TabIndex = 3
        '
        'dtfAnchura
        '
        Me.dtfAnchura.TabIndex = 2
        '
        'dtfAltura
        '
        Me.dtfAltura.TabIndex = 1
        '
        'dtfClase
        '
        Me.dtfClase.TabIndex = 0
        '
        'dtfDistanciaE3
        '
        Me.dtfDistanciaE3.TabIndex = 8
        '
        'dtfDistanciaE2
        '
        Me.dtfDistanciaE2.TabIndex = 7
        '
        'dtfMotorTipo
        '
        Me.dtfMotorTipo.TabIndex = 11
        '
        'dtfMotorMarca
        '
        Me.dtfMotorMarca.TabIndex = 10
        '
        'dtfDistanciaR
        '
        Me.dtfDistanciaR.TabIndex = 9
        '
        'dtfPotenciaFiscal
        '
        Me.dtfPotenciaFiscal.TabIndex = 13
        '
        'dtfCilindros
        '
        Me.dtfCilindros.TabIndex = 12
        '
        'DatafieldLabel2
        '
        Me.DatafieldLabel2.TabIndex = 2
        '
        'DatafieldLabel1
        '
        Me.DatafieldLabel1.TabIndex = 0
        '
        'DatafieldLabel3
        '
        Me.DatafieldLabel3.TabIndex = 4
        '
        'dtfNombre
        '
        Me.dtfNombre.Allow_Empty = False
        Me.dtfNombre.Allow_Negative = True
        Me.dtfNombre.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfNombre.BackColor = System.Drawing.SystemColors.Control
        Me.dtfNombre.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfNombre.DataField = "FT_ID"
        Me.dtfNombre.DataTable = ""
        Me.dtfNombre.Descripcion = "Nº de Identificación"
        Me.dtfNombre.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfNombre.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfNombre.FocoEnAgregar = False
        Me.dtfNombre.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfNombre.Image = Nothing
        Me.dtfNombre.Label_Space = 125
        Me.dtfNombre.Length_Data = 32767
        Me.dtfNombre.Location = New System.Drawing.Point(0, 0)
        Me.dtfNombre.Max_Value = 0.0R
        Me.dtfNombre.MensajeIncorrectoCustom = Nothing
        Me.dtfNombre.Name = "dtfNombre"
        Me.dtfNombre.Null_on_Empty = True
        Me.dtfNombre.Padding = New System.Windows.Forms.Padding(0, 0, 5, 3)
        Me.dtfNombre.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfNombre.ReadOnly_Data = False
        Me.dtfNombre.Show_Button = False
        Me.dtfNombre.Size = New System.Drawing.Size(444, 26)
        Me.dtfNombre.TabIndex = 2
        Me.dtfNombre.Text_Data = ""
        Me.dtfNombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfNombre.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfNombre.TopPadding = 0
        Me.dtfNombre.Upper_Case = False
        Me.dtfNombre.Validate_on_lost_focus = True
        '
        'FichaTecnicaVehiculo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Name = "FichaTecnicaVehiculo"
        Me.Size = New System.Drawing.Size(733, 656)
        CType(Me.pnPpalR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlLeft, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlLeft.ResumeLayout(False)
        CType(Me.pnPpalL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnPpalL.ResumeLayout(False)
        CType(Me.pnlRight, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlRight.ResumeLayout(False)
        CType(Me.pnlPpal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPpal.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dtfNombre As CustomControls.DatafieldLabel

End Class
