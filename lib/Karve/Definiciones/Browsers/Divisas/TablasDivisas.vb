Imports CustomControls

Public Class TablasDivisas
    Public Function DivisasFrom() As DataGridTable
        Dim Tb As DataGridTable
        Tb = New DataGridTable
        Tb.Table = "DIVISAS"
        Tb.AliasTabla = "DIVI"
        Return Tb
    End Function
End Class
