Public Class ValidateData

    Public Function getInt(Value) As Integer
        Try
            Return Value
        Catch : Return 0
        End Try
    End Function

    Public Function getLong(Value) As Long
        Try
            Return Value
        Catch : Return 0
        End Try
    End Function

    Public Function getDouble(Value) As Double
        Try
            Return Value
        Catch : Return 0
        End Try
    End Function

    Public Function getString(Value) As String
        Try
            If Not IsDBNull(Value) Then
                getString = Value
            Else
                getString = ""
            End If
        Catch : Return ""
        End Try
    End Function

    Public Function getBool(Value) As Boolean
        Try
            Return Value
        Catch : Return 0
        End Try
    End Function

    Public Function Ok_DataSet(Value As DataSet, Tabla As String) As Boolean
        Dim iValue As Integer
        Try
            iValue = Value.Tables(Tabla).Rows.Count
            If iValue <> 0 Then
                Return True
            Else : Return False
            End If
        Catch : Return False
        End Try
    End Function

    Public Function setApostrofa(Value As String) As String
        setApostrofa = "'" & Value & "'"
    End Function

End Class
