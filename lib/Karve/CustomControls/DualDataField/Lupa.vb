Imports System.Windows.Forms

Public Class Lupa

#Region "Variables"
    Private db As New ASADB.Connection
    Private mySql As String
    Private myWhere As String
    Private myResult As String = ""
#End Region

#Region "Propiedades"
    Property SQL As String
        Get
            Return mySql
        End Get
        Set(value As String)
            mySql = value
        End Set
    End Property

    Property Where As String
        Get
            Return myWhere
        End Get
        Set(value As String)
            myWhere = value
        End Set
    End Property

    Property Result As String
        Get
            Return myResult
        End Get
        Set(value As String)
            myResult = value
        End Set
    End Property

    Property Title As String
        Get
            Return Me.Text
        End Get
        Set(value As String)
            Me.Text = value
        End Set
    End Property
#End Region

#Region "Eventos"
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
#End Region

#Region "Funciones de Acceso a Datos"

#End Region


End Class
