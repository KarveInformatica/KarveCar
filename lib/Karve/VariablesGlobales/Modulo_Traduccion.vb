Public Module Modulo_Traduccion
    Public dtsTraduc As New DataSet

    Public Function Translate(ByVal original As String) As String
        Try
            If Not IsNothing(dtsTraduc) Then
                If dtsTraduc.Tables.Count > 0 Then
                    Dim traduc() As Data.DataRow
                    traduc = dtsTraduc.Tables(0).Select("original = '" & deleteAccents(original) & "'")
                    If traduc.Count > 0 Then
                        Dim result As String = traduc(0).Item("traduc").ToString
                        Return IIf(AllUpperCase(original), UCase(result), result)
                    End If
                End If
            End If
        Catch
        End Try
        Return original
    End Function

    Public Function deTranslate(ByVal traduc As String)
        Try
            If Not IsNothing(dtsTraduc) Then
                If dtsTraduc.Tables.Count > 0 Then
                    Dim original() As Data.DataRow
                    original = dtsTraduc.Tables(0).Select("traduc = '" & deleteAccents(traduc) & "'")
                    If original.Count > 0 Then
                        Dim result As String = original(0).Item("original").ToString
                        Return IIf(AllUpperCase(traduc), UCase(result), result)
                    End If
                End If
            End If
        Catch
        End Try
        Return traduc
    End Function

    Public Sub TranslateDatatable(ByRef dta As DataTable, ByVal ParamArray colNames() As String)
        Try
            For Each row As DataRow In dta.Rows
                For Each col In colNames
                    Try
                        row.Item(col) = Translate(row.Item(col))
                    Catch
                    End Try
                Next
            Next
        Catch
        End Try
    End Sub

    Public Function deleteAccents(ByVal str As String) As String
        deleteAccents = LCase(str)
        deleteAccents = Replace(deleteAccents, "á", "a")
        deleteAccents = Replace(deleteAccents, "é", "e")
        deleteAccents = Replace(deleteAccents, "í", "i")
        deleteAccents = Replace(deleteAccents, "ó", "o")
        deleteAccents = Replace(deleteAccents, "ú", "u")
    End Function

    Public Function TranslateVars(ByVal original As String) As String
        Dim vars As Array = original.Split(";")
        Dim result As String = Translate(vars(0))
        If vars.Length > 1 Then
            For i = 1 To vars.Length - 1
                result = Replace(result, "%v", Translate(vars(i)), , 1)
            Next
        End If
        Return result
    End Function ' El mensaje debe ir en el siguiente formato: "some text %v sometext %v;var1;var2"

    Public Function AllUpperCase(stringToCheck As String) As Boolean

        AllUpperCase = StrComp(stringToCheck, UCase(stringToCheck), vbBinaryCompare) = 0
    End Function

    Public Function AllLowerCase(stringToCheck As String) As Boolean

        AllLowerCase = StrComp(stringToCheck, LCase(stringToCheck), vbBinaryCompare) = 0
    End Function
End Module
