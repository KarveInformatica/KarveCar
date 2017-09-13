Imports System.Windows.Forms

Public Class DataDateLabel
    Inherits DataDate

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
            dtpData.Location = New System.Drawing.Point(value, 0)
            Me.MinimumSize = New System.Drawing.Size(165 + (value - 75), 26)
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
            tt.SetToolTip(lblDesc, _MensajeIncorrecto)
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
