Imports CustomControls

Public Class TablasOrigen

    Public Function OrigenClienteFrom() As DataGridTable
        Dim Tb As DataGridTable
        Tb = New DataGridTable
        Tb.Table = "ORIGEN"
        Tb.AliasTabla = "OC"

        Return Tb
    End Function

End Class
