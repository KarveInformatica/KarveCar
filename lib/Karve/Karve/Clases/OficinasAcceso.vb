Imports VariablesGlobales

Public Class OficinasAcceso
    Dim DS As New DataSet
    Dim sUsu As String
    Dim MSG As New VariablesGlobales.MsgBoxError

    Public ReadOnly Property Usuario As String
        Get
            Return sUsu
        End Get
    End Property

    Public Sub LoadOfis(Value As String, _
                        AccesoOfis As Boolean)
        Dim db As New ASADB.Connection
        Dim DSU As New DataSet
        Dim DSUs As New DataSet
        Dim sWh As String = ""
        '*==============================================================================
        sUsu = Value
        If AccesoOfis Then   'Busca en OfiUsu
            DS = db.fillDts("SELECT OFICINA AS CODIGO FROM USU_OFI WHERE USURE = '" & Value & "' AND ISNULL(ACCEDE, 0) <> 0")
        Else
            DSUs = db.fillDts("SELECT SUBLIC_COD, OFI_COD, ZONAOFI, ATODAS FROM USURE WHERE CODIGO = '" & sUsu & "'")
            If VD.getInt(DSUs.Tables(0).Rows(0).Item("ATODAS")) = 0 Then
                If DSUs.Tables(0).Rows(0).Item("SUBLIC_COD").ToString <> "" Then sWh += IIf(sWh <> "", " AND ", "") & "SUBLICEN = " & VD.setApostrofa(DSUs.Tables(0).Rows(0).Item("SUBLIC_COD").ToString) 'Si tiene Empresa
                If DSUs.Tables(0).Rows(0).Item("OFI_COD").ToString <> "" Then sWh += IIf(sWh <> "", " AND ", "") & "CODIGO = " & VD.setApostrofa(DSUs.Tables(0).Rows(0).Item("OFI_COD").ToString) 'Si tiene ZonaOfi
                If DSUs.Tables(0).Rows(0).Item("ZONAOFI").ToString <> "" Then sWh += IIf(sWh <> "", " AND ", "") & "ZONA_OF = " & VD.setApostrofa(DSUs.Tables(0).Rows(0).Item("ZONAOFI").ToString) 'Si tiene Ofi
            End If
            If sWh <> "" Then sWh = " WHERE " & sWh
            DS = db.fillDts("SELECT CODIGO FROM OFICINAS " & sWh)
        End If
    End Sub

    Public Function Busca(Value As String) As Boolean
        Dim i As Integer
        Dim sValue As String
        Try
            For i = 0 To DS.Tables(0).Rows.Count - 1
                sValue = DS.Tables(0).Rows(i).Item("CODIGO").ToString
                If String.Equals(sValue, Value, CompareMethod.Text) Then Return True
                i += 1
            Next
            Return False
        Catch ex As Exception
            MSG.Print("Ha ocurrido un error inesperado", ex.Message, My.Application.Info.Title)
            Return False
        End Try
    End Function

End Class
