Imports CustomControls

Public Class TablasIdiomas

    Public Function IdiomasFrom() As DataGridTable
        Dim Tb As DataGridTable
        Tb = New DataGridTable
        Tb.Table = "IDIOMAS"
        Tb.AliasTabla = "IDI"

        Return Tb
    End Function


End Class
