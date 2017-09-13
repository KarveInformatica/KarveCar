Imports VariablesGlobales

Public Class DatosVehiculo
    Dim _Vehiculo As String
    Dim dts As New DataSet
    Private DR As DataRow = Nothing

    Public Sub New(Vehiculo As String, db As ASADB.Connection)
        Dim sSQL As String = "SELECT V1.CODIINT AS CODIINT, V1.MATRICULA AS MATRICULA, V1.GRUPO AS GRUPO, " & _
                             "V2.LITROS AS LITROS, MOD.DEPOSITO AS DEPOSITO, MOD.TIPOGAS AS TIPOGAS, isnull(KM, 0) AS KM" & vbNewLine & _
                             "FROM VEHICULO1 AS V1" & vbNewLine & _
                             "INNER JOIN VEHICULO2 AS V2 ON V1.CODIINT = V2.CODIINT" & vbNewLine & _
                             "LEFT OUTER JOIN MODELO AS MOD ON MOD.MARCA = V1.MAR AND MOD.CODIGO = V1.MO1 AND MOD.VARIANTE = V1.MO2" & vbNewLine & _
                             "WHERE CODIINT = '" & Vehiculo & "'"
        dts = db.fillDts(sSQL)
        If Not IsNothing(dts) Then
            If dts.Tables.Count > 0 Then
                If dts.Tables(0).Rows.Count > 0 Then
                    DR = dts.Tables(0).Rows(0)
                End If
            End If
        End If
    End Sub

    Public ReadOnly Property Datos As DataSet
        Get
            Return dts
        End Get
    End Property

    Public Function GBool(Value As String) As Boolean
        GBool = False
        If Not IsNothing(DR) Then GBool = VD.getInt(DR(Value)) <> 0
    End Function

    Public Function GInt(Value As String) As Integer
        GInt = 0
        If Not IsNothing(DR) Then GInt = VD.getInt(DR(Value))
    End Function

    Public Function GDbl(Value As String) As Integer
        GDbl = 0
        If Not IsNothing(DR) Then GDbl = VD.getDouble(DR(Value))
    End Function

    Public Function GStr(Value As String) As String
        GStr = ""
        If Not IsNothing(DR) Then GStr = VD.getString(DR(Value))
    End Function

End Class
