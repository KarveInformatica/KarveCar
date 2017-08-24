Imports System.Windows.Forms
Imports VariablesGlobales
Imports Telerik.WinControls.UI
Imports System.ComponentModel
Imports Karve.ConfiguracionApp
Imports Karve.Theme

Public Class DualDataFieldEditableLabel
    Inherits DualDataFieldEditable

#Region "Variables"
    Private space As Integer = 75 'espacio desde el margen izq hasta el inicio del textbox
    Private _form As String 'el formulario que abre al hacer click en la label
    Private tt As New ToolTip 'tool tip text de la label cuando hay un error
    Private _showButton As Boolean = True
#End Region

#Region "Propiedades"

    Overrides Property Descripcion As String
        Get
            Return lblDesc.Text
        End Get
        Set(value As String)
            lblDesc.Text = value
            _Descripcion = value
        End Set
    End Property

    Property Label_Space As Integer
        Get
            Return space
        End Get
        Set(value As Integer)
            space = value
            txtData.Location = New System.Drawing.Point(space, txtData.Location.Y)
            dtfDesc.Location = New System.Drawing.Point(txtData.Width + space + 7, dtfDesc.Location.Y)
            dtfDesc.Width = Me.Width - (space + txtData.Width + 7) - IIf(_showButton, 27, 0)
        End Set
    End Property

    Protected Overrides Sub Text_Width_Change()
        txtData.Width = _txtDataWidth
        dtfDesc.Location = New System.Drawing.Point(_txtDataWidth + Label_Space() + 6, dtfDesc.Location.Y)
        dtfDesc.Width = Me.Width - (_txtDataWidth + Label_Space() + 6) - IIf(_showButton, 27, 0)
    End Sub

    Property OpenForm As String
        Get
            Return _form
        End Get
        Set(value As String)
            _form = value
            MyBase.Formulario = _form
            If value <> "" Then
                lblDesc.Font = New Drawing.Font(lblDesc.Font.FontFamily, lblDesc.Font.Size, Drawing.FontStyle.Underline)
            Else
                lblDesc.Font = New Drawing.Font(lblDesc.Font.FontFamily, lblDesc.Font.Size, Drawing.FontStyle.Regular)
            End If
        End Set
    End Property

    Property ShowButton As Boolean
        Get
            Return _showButton
        End Get
        Set(value As Boolean)
            _showButton = value
            btnAction.Visible = _showButton
            Text_Width_Change()
        End Set
    End Property
#End Region

#Region "Eventos"

    'Private Sub DualDatafieldLabel_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
    '    If e.KeyCode = Windows.Forms.Keys.F4 Then
    '        abrirLupa()
    '    ElseIf e.KeyCode = Windows.Forms.Keys.F2 Then
    '        AbrirForm()
    '    End If
    'End Sub

    Private Sub DualDatafieldLabel_Load(sender As Object, e As EventArgs) Handles Me.Load
        'recoloca los controles al cargar
        If Not DesignMode Then
            If TemaAplicacion.IconosMini.Count > 0 Then btnAction.Image = TemaAplicacion.IconosMini(Theme_Definicion.euIconosMini.Buscar_Ic)
        Else
            btnAction.Image = Nothing
        End If


        txtData.Location = New System.Drawing.Point(space, _topPadding)
        dtfDesc.Location = New System.Drawing.Point(txtData.Location.X + space + 7, _topPadding)
        dtfDesc.Width = Me.Width - (space + _txtDataWidth + 7) - 25
        Text_Width_Change()
        Me.Padding = New Padding(0, 0, 0, 6)
    End Sub


    Private frm As RadForm

    Private Sub AbrirForm()
        If _form <> "" Then
            frm = VariablesGlobales.OpenForm(_form)
            Dim tipo = frm.GetType()
            Dim handleSetNewid = New PropertyChangedEventHandler(AddressOf setNewid)
            tipo.GetEvent("PropertyChanged").AddEventHandler(frm, handleSetNewid)
            OpenTab(frm, txtData.Text)
        End If
    End Sub

    Private Sub setNewid(sender As Object, e As PropertyChangedEventArgs)
        If e.PropertyName = "CodigoRegistro" Then
            txtData.Text = CType(frm, Object).CodigoEdicion
            forceQuery(True)
        End If
    End Sub

    Private Sub lblDesc_DoubleClick(sender As Object, e As EventArgs) Handles lblDesc.Click
        AbrirForm()
    End Sub
    Private Sub lblDesc_MouseHover(sender As Object, e As EventArgs) Handles lblDesc.MouseHover
        If _form <> "" Then
            Cursor = Windows.Forms.Cursors.Hand
        End If
    End Sub
    Private Sub lblDesc_MouseLeave(sender As Object, e As EventArgs) Handles lblDesc.MouseLeave
        Cursor = Windows.Forms.Cursors.Arrow
    End Sub

    Protected Overrides Sub change_theme()
        MyBase.change_theme()
        If Theme = ThemeType.Plain Then
            btnAction.ThemeName = "Windows8"
        Else
            btnAction.ThemeName = "Windows7"
        End If
    End Sub

    Protected Overrides Sub ReadOnly_ProperyChanged()
        If ReadOnly_Data Then
            btnAction.Enabled = False
        Else
            btnAction.Enabled = True
        End If
    End Sub

#End Region

#Region "Funciones de Validacion"
    Protected Overrides Sub ValidateLabel()
        'pone la label de color rojo y un tool tip cuando hay error, cuando no hay lo quita
        If _Incorrecto Then
            lblDesc.ForeColor = Drawing.Color.Red
            tt.SetToolTip(lblDesc, MensajeIncorrecto)
        Else
            lblDesc.ForeColor = Drawing.Color.Black
            tt.RemoveAll()
        End If
    End Sub
    Protected Overrides Sub ClearLabel()
        lblDesc.ForeColor = Drawing.Color.Black
        tt.RemoveAll()
    End Sub
#End Region

    Private Sub DualDatafieldLabel_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        Text_Width_Change()
    End Sub

    Private Sub btnAction_Click(sender As Object, e As EventArgs) Handles btnAction.Click
        abrirLupa()
    End Sub

End Class
