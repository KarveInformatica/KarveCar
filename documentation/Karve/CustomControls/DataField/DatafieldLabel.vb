Imports System.Windows.Forms
Imports VariablesGlobales.Modulo_VariablesGlobales
Imports Karve.Theme
Imports Karve.ConfiguracionApp
Imports System.ComponentModel
Imports Telerik.WinControls.UI

Public Class DatafieldLabel
    Inherits Datafield

#Region "Variables"
    Private space As Integer = 75 'espacio desde el margen izq hasta el inicio del textbox
    Public Event btnActionClick() 'evento cuando se clica el boton
    Private tt As New ToolTip 'tool tip text de la label cuando hay un error
    Private _showButton As Boolean = False
    Private _form As String
#End Region

#Region "Propiedades"
    Property Label_Space As Integer
        Get
            Return space
        End Get
        Set(value As Integer)
            space = value
            txtData.Location = New System.Drawing.Point(value, 0)
            change_width()
        End Set
    End Property

    Property Show_Button As Boolean
        Get
            Return _showButton
        End Get
        Set(value As Boolean)
            _showButton = value
            btnAction.Visible = _showButton
            change_width()
        End Set
    End Property

    Overrides Property Descripcion As String
        Get
            Return lblDesc.Text
        End Get
        Set(value As String)
            lblDesc.Text = value
            _Descripcion = value
        End Set
    End Property
    Protected Overrides Sub change_theme()
        MyBase.change_theme()
        If Theme = ThemeType.Plain Then
            btnAction.ThemeName = "Windows8"
        Else
            btnAction.ThemeName = "Windows7"
        End If
    End Sub

    Property Image As System.Drawing.Image
        Get
            Return btnAction.Image
        End Get
        Set(value As System.Drawing.Image)
            btnAction.Image = value
        End Set
    End Property

    Property TextAlign As System.Windows.Forms.HorizontalAlignment
        Get
            Return txtData.TextAlign
        End Get
        Set(value As System.Windows.Forms.HorizontalAlignment)
            txtData.TextAlign = value
        End Set
    End Property

    Property OpenForm As String
        Get
            Return _form
        End Get
        Set(value As String)
            _form = value
            If value <> "" Then
                lblDesc.Font = New Drawing.Font(lblDesc.Font.FontFamily, lblDesc.Font.Size, Drawing.FontStyle.Underline)
            Else
                lblDesc.Font = New Drawing.Font(lblDesc.Font.FontFamily, lblDesc.Font.Size, Drawing.FontStyle.Regular)
            End If
        End Set
    End Property

#End Region

#Region "Eventos"
    Private Sub btnAction_Click(sender As Object, e As EventArgs) Handles btnAction.Click
        'cuando se clica el boton levanta un evento, hay que programarlo en el form
        RaiseEvent btnActionClick()
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

#End Region

#Region "Funciones"
    Protected Overridable Sub change_width()
        'cambia el ancho del textbox en funcion de la label y si hay o no boton
        If Not _showButton Then
            txtData.Width = Me.Width - (space)
        Else
            txtData.Width = Me.Width - (space + 27)
        End If
    End Sub

    Protected Overrides Sub size_changed()

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
        'limpia el tool tip de la label cuando se limpia el texto
        lblDesc.ForeColor = Drawing.Color.Black
        tt.RemoveAll()
    End Sub
#End Region

    Private Sub DatafieldLabel_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not DesignMode Then
            If btnAction.Image Is Nothing Then
                If TemaAplicacion.IconosMini.Count > 0 Then btnAction.Image = TemaAplicacion.IconosMini(Theme_Definicion.euIconosMini.Buscar_Ic)
            End If
        End If
    End Sub

    Private Sub DatafieldLabel_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        change_width()
    End Sub
End Class
