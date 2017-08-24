Public Class DataGridRules
    Inherits System.Collections.Hashtable

    Public Overloads Sub Add(ByVal TablaQuery As DataGridRule)
        TablaQuery.Item = Me.Count
        MyBase.Add(TablaQuery.Name, TablaQuery)
    End Sub

    Public Overloads Sub Remove(ByVal Key As Object)
        MyBase.Remove(Key)
        Dim i As Integer = 0
        Dim HC = (From c As DataGridRule In Me.Values Order By c.Item Select c)
        Dim RS As New ArrayList
        For Each ctr As DataGridRule In HC
            ctr.Item = i
            i += 1
        Next
    End Sub

    Public Function Order() As ArrayList
        Dim HC = (From c As DataGridRule In Me.Values Order By c.Item Select c)
        Dim RS As New ArrayList
        For Each ctr As DataGridRule In HC
            RS.Add(ctr)
        Next
        Return RS
    End Function

    Public Function Existe(Value As String) As Boolean
        Return Me.ContainsKey(Value)
    End Function

    Public Function DameItemExiste(Value As String) As DataGridRule
        Dim HC = (From c As DataGridRule In Me.Values Where c.Name = Value Order By c.Item Select c)
        If HC.Count <> 0 Then
            Return HC(0)
        Else : Return Nothing
        End If
    End Function

    Public Sub Modify(ByVal TablaQuery As DataGridRule)
        MyBase.Item(TablaQuery.Name) = TablaQuery
    End Sub

    Public Function DameWhere() As String
        Dim _sWhere As String = ""
        Dim RL As New DataGridRule
        Dim _sClausula As String = ""
        Dim _sCampo As String = ""
        Dim _sOperador As String = ""
        '*====================================================================
        For Each RL In Order()
            If RL.Item > 0 Then _sOperador = RL.OperadorVal
            If RL.Expresion <> "" Then
                _sClausula = RL.Expresion
            Else
                _sClausula = DameClausula(RL)
            End If
            _sWhere = _sWhere & _sOperador & _sClausula
        Next
        If _sWhere <> "" Then _sWhere = " WHERE " & _sWhere
        Return _sWhere
    End Function

    Public Function DameClausula(RL As DataGridRule) As String
        Dim _sClausula As String = ""
        Dim _sCampo As String = ""

        _sCampo = ""

        If RL.ExpresionBD <> "" Then
            _sCampo = RL.ExpresionBD
        ElseIf RL.AliasCampo <> "" And RL.AliasCampo <> RL.Campo Then
            _sCampo = RL.AliasCampo
        Else
            _sCampo = RL.Tabla & "."
            _sCampo += RL.Campo
        End If

        If RL.Criterio = DataGridRule.euCriterio.Contiene Then
            _sClausula = _sCampo & RL.CriterioVal & "'%" & RL.Valor & "%'"
        ElseIf RL.Criterio = DataGridRule.euCriterio.NoContiene Then
            _sClausula = _sCampo & RL.CriterioVal & "'%" & RL.Valor & "%'"
        ElseIf RL.Criterio = DataGridRule.euCriterio.Distinto Then
            _sClausula = _sCampo & RL.CriterioVal & "'" & RL.Valor & "'"
        ElseIf RL.Criterio = DataGridRule.euCriterio.Igual Then
            _sClausula = _sCampo & RL.CriterioVal & "'" & RL.Valor & "'"
        ElseIf RL.Criterio = DataGridRule.euCriterio.Empieza Then
            _sClausula = _sCampo & RL.CriterioVal & "'" & RL.Valor & "%'"
        ElseIf RL.Criterio = DataGridRule.euCriterio.Termina Then
            _sClausula = _sCampo & RL.CriterioVal & "'%" & RL.Valor & "'"
        ElseIf RL.Criterio = DataGridRule.euCriterio.EsNulo Then
            _sClausula = _sCampo & " IS NULL "
        ElseIf RL.Criterio = DataGridRule.euCriterio.NoEsNulo Then
            _sClausula = _sCampo & " IS NOT NULL "
        Else
            _sClausula = _sCampo & RL.CriterioVal & "'" & RL.Valor & "'"
        End If

        Return _sClausula
    End Function

End Class
