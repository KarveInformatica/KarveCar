Public Module Modulo_Traduccion_SQL

#Region "   .  MODULO CON FUNCIONES PARA TRADUCIR SQLS.  "

    Public Function CaseMeses_SQL(Value As String) As String
        Dim sSQL As String = " CASE ISNULL(" & Value & ", 0) " & vbNewLine & _
                                DameWhenMeses() & vbNewLine & _
                             " END "

        Return sSQL
    End Function

    Private Function DameWhenMeses() As String
        Return " WHEN 1 THEN '" & Translate("Enero") & "'" & vbNewLine & _
               " WHEN 2 THEN '" & Translate("Febrero") & "'" & vbNewLine & _
               " WHEN 3 THEN '" & Translate("Marzo") & "'" & vbNewLine & _
               " WHEN 4 THEN '" & Translate("Abril") & "'" & vbNewLine & _
               " WHEN 5 THEN '" & Translate("Mayo") & "'" & vbNewLine & _
               " WHEN 6 THEN '" & Translate("Junio") & "'" & vbNewLine & _
               " WHEN 7 THEN '" & Translate("Julio") & "'" & vbNewLine & _
               " WHEN 8 THEN '" & Translate("Agosto") & "'" & vbNewLine & _
               " WHEN 9 THEN '" & Translate("Septiembre") & "'" & vbNewLine & _
               " WHEN 10 THEN '" & Translate("Octubre") & "'" & vbNewLine & _
               " WHEN 11 THEN '" & Translate("Noviembre") & "'" & vbNewLine & _
               " WHEN 12 THEN '" & Translate("Diciembre") & "'"

    End Function

#End Region

End Module
