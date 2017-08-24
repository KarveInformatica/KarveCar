Imports System.Windows.Forms

Public Class DataAreaLabel
    Inherits DataArea

#Region "Variables"
    Private space As Integer = 50
    Public Event btnActionClick()
    Private tt As New ToolTip
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
#End Region

#Region "Eventos"

#End Region

#Region "Funciones"
    Private Sub change_width()
        txtData.Width = Me.Width - (space)
    End Sub
#End Region

#Region "Funciones de Validacion"
    Protected Overrides Sub ValidateLabel()
        If _Incorrecto Then
            lblDesc.ForeColor = Drawing.Color.Red
            tt.SetToolTip(lblDesc, _MensajeIncorrecto)
        Else
            lblDesc.ForeColor = Drawing.Color.Black
            tt.RemoveAll()
        End If
    End Sub
#End Region


End Class
