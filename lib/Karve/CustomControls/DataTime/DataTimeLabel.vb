Imports System.Windows.Forms

Public Class DataTimeLabel
    Inherits DataTime

#Region "Variables"
    Private space As Integer = 75
    Public Event btnActionClick()
    Private tt As New ToolTip
#End Region

#Region "Propiedades"
    Property Label_Space As Integer
        Get
            Return space
        End Get
        Set(value As Integer)
            space = value
            tmpData.Location = New System.Drawing.Point(value, 0)
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
#End Region

#Region "Eventos"

#End Region

#Region "Funciones de Validacion"
    Protected Overrides Sub ValidateLabel()
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
End Class
