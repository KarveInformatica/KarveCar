Imports CustomControls

Public Class TablasPoblacion
    Public Function PoblacionFrom() As DataGridTable
        Dim Tb As DataGridTable
        Tb = New DataGridTable
        Tb.Table = "POBLACIONES"
        Tb.AliasTabla = "POBL"

        Return Tb
    End Function
End Class
