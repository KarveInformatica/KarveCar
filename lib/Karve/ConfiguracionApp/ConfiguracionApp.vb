Imports VariablesGlobales

Public Class ConfiguracionApp
    Dim DR As DataRow

    Public Function GBool(Value As String) As Boolean
        Try
            Return VD.getInt(DR(Value)) <> 0
        Catch ex As Exception
            Return False
        End Try
        '*===================================================================
    End Function

    Public Function GInt(Value As String) As Integer
        Try
            Return VD.getInt(DR(Value))
        Catch ex As Exception
            Return False
        End Try
        '*===================================================================
    End Function

    Public Function GDbl(Value As String) As Double
        Try
            Return VD.getDouble(DR(Value))
        Catch ex As Exception
            Return False
        End Try
        '*===================================================================
    End Function

    Public Function GStr(Value As String) As String
        Try
            Return VD.getString(DR(Value))
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Sub LoadConfig(mySQL As String)
        Dim DB As New ASADB.Connection
        DR = DB.fillDts(mySQL).Tables(0).Rows(0)
    End Sub
End Class
