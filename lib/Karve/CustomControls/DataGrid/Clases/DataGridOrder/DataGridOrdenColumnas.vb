Public Class DataGridOrdenColumnas
    Inherits System.Collections.ArrayList
    '*--------------------------------------------------------------------------
    '*  ESTA COLECCIÓN PERMITE REPES, POR ESO LA CREO ARRAY LIST
    '*--------------------------------------------------------------------------

    Public Overloads Sub Add(ByVal Columnas As DataGridordenColumna)
        Try
            Columnas.Item = Me.Count
            MyBase.Add(Columnas)
        Catch
        End Try
    End Sub

    Public Function DameOrder() As String
        Dim _sOrder As String = ""
        Dim RL As New DataGridOrdenColumna
        Dim _sClausula As String = ""
        Dim _sCampo As String = ""
        Dim _sOperador As String = ""
        '*====================================================================
        For Each RL In Me.ToArray
            If RL.Item > 0 Then _sOperador = ", "
            If RL.Expresion <> "" Then
                _sClausula = RL.Expresion + " " + RL.CriterioString
            ElseIf RL.ExpresionBD <> "" Then
                _sClausula = "(" & RL.ExpresionBD & ") " & RL.CriterioString
            ElseIf RL.AliasCampo <> "" Then
                _sClausula = RL.AliasCampo + " " + RL.CriterioString
            Else
                _sCampo = ""
                _sClausula = ""
                '*------------------------------------------------------------
                If RL.AliasTabla <> "" Then _sCampo = RL.AliasTabla & "."
                _sCampo += RL.Campo
                _sClausula += _sCampo + " " + RL.CriterioString
            End If
            _sOrder = _sOrder & _sOperador & _sClausula
        Next
        If _sOrder <> "" Then _sOrder = " ORDER BY " & _sOrder
        Return _sOrder
    End Function

End Class
